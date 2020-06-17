// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.BillingInformation
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using DABL.BLL;
using DABL.DAL;
using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class BillingInformation : Page
  {
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
    private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
    private readonly CompanyPackageMasterBLL objCompanyPackageMasterBll = new CompanyPackageMasterBLL();
    private CloudAccountDA.CompanyPackageMasterDataTable objCompanyPackageMasterDT = new CloudAccountDA.CompanyPackageMasterDataTable();
    private readonly CloudPackageMasterBLL objCloudPackageMasterBll = new CloudPackageMasterBLL();
    private CloudAccountDA.CloudPackageMasterDataTable objCloudPackageMasterDT = new CloudAccountDA.CloudPackageMasterDataTable();
    private readonly CompanyClientMasterBLL objCompanyClientMasterBll = new CompanyClientMasterBLL();
    private CloudAccountDA.CompanyClientMasterDataTable objCompanyClientMasterDT = new CloudAccountDA.CompanyClientMasterDataTable();
    private readonly PackageFeatureMasterBLL objPackageFeatureMasterBll = new PackageFeatureMasterBLL();
    private CloudAccountDA.PackageFeatureMasterDataTable objPackageFeatureMasterDT = new CloudAccountDA.PackageFeatureMasterDataTable();
    private readonly CloudPackageDetailsBLL objCloudPackageDetailsBll = new CloudPackageDetailsBLL();
    private CloudAccountDA.CloudPackageDetailsDataTable objCloudPackageDetailsDT = new CloudAccountDA.CloudPackageDetailsDataTable();
    protected Label lblPackageName;
    protected HtmlGenericControl clientPro;
    protected Label lblClientPackageCount;
    protected Label lblClientCount;
    protected HtmlGenericControl staffPro;
    protected Label lblStaffPackageCount;
    protected Label lblStaffCount;
    protected Label lblUpgrades;
    protected Label lblPayments;
    protected HiddenField hfCompanyID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("account")).Attributes.Add("style", "background-color: lightgray;");
      ((HtmlControl) this.Master.FindControl("billingInfo")).Attributes.Add("class", "active open");
      MembershipUser user = Membership.GetUser();
      if (user == null)
        return;
      string str = user.ToString();
      if (Roles.IsUserInRole(str, "Admin"))
      {
        this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(str);
        if (this.objCompanyLoginMasterDT.Rows.Count > 0)
          this.hfCompanyID.Value = this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString();
      }
      else if (Roles.IsUserInRole(str, "Employee"))
      {
        this.objStaffMasterDT = this.objStaffMasterBll.GetDataByStaffUserName(str);
        if (this.objStaffMasterDT.Rows.Count > 0)
          this.hfCompanyID.Value = this.objStaffMasterDT.Rows[0]["CompanyID"].ToString();
      }
      if (string.IsNullOrEmpty(this.hfCompanyID.Value))
        return;
      this.SetUpgradePayment(this.hfCompanyID.Value);
    }

    private void SetUpgradePayment(string cId)
    {
      this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyID(int.Parse(cId));
      this.lblClientCount.Text = this.objCompanyClientMasterDT.Rows.Count.ToString();
      int count1 = this.objCompanyClientMasterDT.Rows.Count;
      this.objStaffMasterDT = this.objStaffMasterBll.GetDataByCompanyID(int.Parse(cId));
      this.lblStaffCount.Text = this.objStaffMasterDT.Rows.Count.ToString();
      int count2 = this.objStaffMasterDT.Rows.Count;
      this.objCompanyPackageMasterDT = this.objCompanyPackageMasterBll.GetDataByCompanyID(int.Parse(cId));
      if (this.objCompanyPackageMasterDT.Rows.Count > 1)
      {
        for (int index = 0; index < this.objCompanyPackageMasterDT.Rows.Count; ++index)
        {
          string s = this.objCompanyPackageMasterDT.Rows[index]["CloudPackageID"].ToString();
          if (s == "0" && index == 0)
          {
            this.lblUpgrades.Text = "FROM Free Trial";
            this.lblPayments.Text = "FOR : Free Trial : 0.00<br />";
          }
          else
          {
            this.objCloudPackageMasterDT = this.objCloudPackageMasterBll.GetDataByCloudPackageID(int.Parse(s));
            if (this.objCloudPackageMasterDT.Rows.Count > 0)
            {
              Label label1 = this.lblUpgrades;
              string str1 = label1.Text + (object) " To " + (string) this.objCloudPackageMasterDT.Rows[0]["CloudPackageName"];
              label1.Text = str1;
              Label label2 = this.lblPayments;
              string str2 = label2.Text + (object) "FOR : " + (string) this.objCloudPackageMasterDT.Rows[0]["CloudPackageName"] + " : " + (string) this.objCloudPackageMasterDT.Rows[0]["PackageAmount"] + "<br />";
              label2.Text = str2;
            }
            else
            {
              this.lblUpgrades.Text += " To Free Trial";
              this.lblPayments.Text += "FOR : Free Trial : 0.00<br />";
            }
          }
        }
      }
      this.objCompanyPackageMasterDT = this.objCompanyPackageMasterBll.GetDataByCompanyActivePackage(int.Parse(cId));
      if (this.objCompanyPackageMasterDT.Rows.Count <= 0)
        return;
      string s1 = this.objCompanyPackageMasterDT.Rows[0]["CloudPackageID"].ToString();
      if (s1 == "0")
      {
        this.lblPackageName.Text = "Free Trial";
        this.clientPro.Attributes.Add("style", "width: 100%;");
        this.staffPro.Attributes.Add("style", "width: 100%;");
        this.lblClientPackageCount.Text = "Unlimited";
        this.lblStaffPackageCount.Text = "Unlimited";
      }
      else
      {
        this.objCloudPackageMasterDT = this.objCloudPackageMasterBll.GetDataByCloudPackageID(int.Parse(s1));
        this.lblPackageName.Text = this.objCloudPackageMasterDT.Rows.Count > 0 ? this.objCloudPackageMasterDT.Rows[0]["CloudPackageName"].ToString() : "Free Trial";
        this.objPackageFeatureMasterDT = this.objPackageFeatureMasterBll.GetDataByPackageFeatureName(1, "Number of clients you can invoice");
        if (this.objPackageFeatureMasterDT.Rows.Count > 0)
        {
          int iModuleID = int.Parse(this.objPackageFeatureMasterDT.Rows[0]["PackageModuleID"].ToString());
          int iFeatureID = int.Parse(this.objPackageFeatureMasterDT.Rows[0]["PackageFeatureID"].ToString());
          this.objCloudPackageDetailsDT = this.objCloudPackageDetailsBll.GetDataByPackageModuleFeatureID(int.Parse(s1), iModuleID, iFeatureID);
          if (this.objCloudPackageDetailsDT.Rows.Count > 0)
          {
            try
            {
              int num = int.Parse(this.objCloudPackageDetailsDT.Rows[0]["CloudPackageDetailValue"].ToString());
              this.clientPro.Attributes.Add("style", "width: " + (object) (count1 / num * 100));
              this.lblClientPackageCount.Text = num.ToString();
            }
            catch (Exception ex)
            {
              this.clientPro.Attributes.Add("style", "width: 100%;");
              this.lblClientPackageCount.Text = "Unlimited";
            }
          }
        }
        this.objPackageFeatureMasterDT = this.objPackageFeatureMasterBll.GetDataByPackageFeatureName(4, "Additional staff accounts included");
        if (this.objPackageFeatureMasterDT.Rows.Count <= 0)
          return;
        int iModuleID1 = int.Parse(this.objPackageFeatureMasterDT.Rows[0]["PackageModuleID"].ToString());
        int iFeatureID1 = int.Parse(this.objPackageFeatureMasterDT.Rows[0]["PackageFeatureID"].ToString());
        this.objCloudPackageDetailsDT = this.objCloudPackageDetailsBll.GetDataByPackageModuleFeatureID(int.Parse(s1), iModuleID1, iFeatureID1);
        if (this.objCloudPackageDetailsDT.Rows.Count <= 0)
          return;
        try
        {
          int num = int.Parse(this.objCloudPackageDetailsDT.Rows[0]["CloudPackageDetailValue"].ToString());
          this.staffPro.Attributes.Add("style", "width: " + (object) (count2 / num * 100));
          this.lblStaffPackageCount.Text = num.ToString();
        }
        catch (Exception ex)
        {
          this.staffPro.Attributes.Add("style", "width: 100%;");
          this.lblStaffPackageCount.Text = "Unlimited";
        }
      }
    }
  }
}

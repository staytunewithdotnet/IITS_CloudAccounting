// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.Default
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
  public class Default : Page
  {
    private readonly CompanyPackageDetailsBLL objCompanyPackageDetailsBll = new CompanyPackageDetailsBLL();
    private CloudAccountDA.CompanyPackageDetailsDataTable objCompanyPackageDetailsDT = new CloudAccountDA.CompanyPackageDetailsDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    protected HtmlGenericControl dashboard;
    protected Panel pnlMasterAdmin;
    protected DataList dlTotalCompany;
    protected SqlDataSource sqldsTotalCompany;
    protected GridView gvCompanyPackageDate;
    protected SqlDataSource sqldsCompanyPackageDate;
    protected GridView gvCompanyPackage;
    protected SqlDataSource sqldsCompanyPackage;
    protected Panel pnlCompanyAdmin;
    protected HtmlGenericControl packageInfo;
    protected Button btnUpgrade;
    protected Panel pnlEmployee;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("home")).Attributes.Add("class", "active");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        switch (Admin.RoleName)
        {
          case "MasterAdmin":
            this.pnlMasterAdmin.Visible = true;
            this.pnlCompanyAdmin.Visible = false;
            this.pnlEmployee.Visible = false;
            break;
          case "Admin":
            this.pnlMasterAdmin.Visible = false;
            this.pnlCompanyAdmin.Visible = true;
            this.pnlEmployee.Visible = false;
            this.SetDashboardCompanyAdmin();
            break;
          case "Employee":
            this.pnlMasterAdmin.Visible = false;
            this.pnlCompanyAdmin.Visible = false;
            this.pnlEmployee.Visible = true;
            break;
        }
      }
      else
      {
        this.pnlMasterAdmin.Visible = false;
        this.pnlCompanyAdmin.Visible = false;
        this.pnlEmployee.Visible = false;
      }
    }

    public void SetDashboardCompanyAdmin()
    {
      MembershipUser user = Membership.GetUser();
      if (user == null || !Roles.IsUserInRole(user.UserName, "Admin"))
        return;
      this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(user.UserName);
      this.objCompanyPackageDetailsDT = this.objCompanyPackageDetailsBll.GetDataByCompanyActivePackage(int.Parse(this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString()));
      if (this.objCompanyPackageDetailsDT.Rows.Count <= 0)
        return;
      string s = DateTime.Parse(this.objCompanyPackageDetailsDT.Rows[0]["PackageEndDate"].ToString()).ToShortDateString();
      this.packageInfo.Visible = DateTime.Parse(s) <= DateTime.Parse(DateTime.Now.ToShortDateString());
      this.dashboard.Visible = !(DateTime.Parse(s) <= DateTime.Parse(DateTime.Now.ToShortDateString()));
    }

    protected void BtnUpgradeClick(object sender, EventArgs e)
    {
      MembershipUser user = Membership.GetUser();
      if (user == null)
        return;
      this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(user.UserName);
      this.Response.Redirect("~/BillTransact/UpgradeCompanyPackage.aspx?CompanyID=" + this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString());
    }
  }
}

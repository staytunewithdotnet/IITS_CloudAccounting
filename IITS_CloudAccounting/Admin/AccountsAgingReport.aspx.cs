// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.AccountsAgingReport
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Globalization;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class AccountsAgingReport : Page
  {
    private readonly MiscellaneousMasterBLL objMiscellaneousMasterBll = new MiscellaneousMasterBLL();
    private CloudAccountDA.MiscellaneousMasterDataTable objMiscellaneousMasterDT = new CloudAccountDA.MiscellaneousMasterDataTable();
    private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
    private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
    public string dateFormat = "MM/dd/yyyy";
    protected ToolkitScriptManager tsm;
    protected TextBox txtDate;
    protected CalendarExtender ceDate;
    protected Button btnUpdate;
    protected Image imgLogo;
    protected Label lblCompanyName;
    protected Label lblDate;
    protected GridView gvAccount;
    protected SqlDataSource sqldsAccount;
    protected HiddenField hfCompanyID;
    protected HiddenField hfDate;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("reports")).Attributes.Add("class", "active open");
      if (!this.IsPostBack)
      {
        this.txtDate.Text = DateTime.Now.ToString(this.dateFormat);
        this.BindGrid();
      }
      MembershipUser user = Membership.GetUser();
      if (user == null)
        return;
      string str = user.ToString();
      if (Roles.IsUserInRole(str, "Admin"))
      {
        this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(str);
        if (this.objCompanyLoginMasterDT.Rows.Count > 0)
        {
          this.hfCompanyID.Value = this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString();
          this.imgLogo.ImageUrl = Doyingo.SetCompanyLogo(this.hfCompanyID.Value);
        }
      }
      else if (Roles.IsUserInRole(str, "Employee"))
      {
        this.objStaffMasterDT = this.objStaffMasterBll.GetDataByStaffUserName(str);
        if (this.objStaffMasterDT.Rows.Count > 0)
        {
          this.hfCompanyID.Value = this.objStaffMasterDT.Rows[0]["CompanyID"].ToString();
          this.imgLogo.ImageUrl = Doyingo.SetCompanyLogo(this.hfCompanyID.Value);
        }
      }
      this.ceDate.Format = this.dateFormat;
      this.SetMiscValues(this.hfCompanyID.Value);
    }

    private void SetMiscValues(string companyId)
    {
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(companyId));
      this.lblCompanyName.Text = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
      this.objMiscellaneousMasterDT = this.objMiscellaneousMasterBll.GetDataByCompanyID(int.Parse(companyId));
      //if (this.objMiscellaneousMasterDT.Rows.Count <= 0)
      //  return;
      //this.dateFormat = this.objMiscellaneousMasterDT.Rows[0]["DateFormat"].ToString();
      //this.ceDate.Format = this.dateFormat;
      //string[] formats = new string[6]
      //{
      //  "MM/dd/yy",
      //  "MM/dd/yyyy",
      //  "dd/MM/yy",
      //  "dd/MM/yyyy",
      //  "yy-MM-dd",
      //  "yyyy-MM-dd"
      //};
      //      string str1 = this.txtDate.Text; //DateTime.ParseExact(this.txtDate.Text, formats, (IFormatProvider) CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("yyyy-MM-dd");
      //      string str2 = this.txtDate.Text; // DateTime.ParseExact(this.txtDate.Text, formats, (IFormatProvider) CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("MMMM dd, yyyy");
      //this.hfDate.Value = str1;
      this.lblDate.Text = txtDate.Text;
    }

    private void BindGrid()
    {
      this.gvAccount.DataBind();
    }

    protected void BtnUpdateClick(object sender, EventArgs e)
    {
      this.hfDate.Value = DateTime.ParseExact(this.txtDate.Text, new string[6]
      {
        "MM/dd/yy",
        "MM/dd/yyyy",
        "dd/MM/yy",
        "dd/MM/yyyy",
        "yy-MM-dd",
        "yyyy-MM-dd"
      }, (IFormatProvider) CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("yyyy-MM-dd");
      this.BindGrid();
    }
  }
}

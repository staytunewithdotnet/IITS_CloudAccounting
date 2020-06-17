// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.RecurringAnnualReport
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class RecurringAnnualReport : Page
  {
    private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
    private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
    protected ToolkitScriptManager tsm;
    protected DropDownList ddlClient;
    protected SqlDataSource sqldsClient;
    protected Button btnUpdate;
    protected Image imgLogo;
    protected Label lblCompanyName;
    protected GridView gvRecurringAnnual;
    protected ObjectDataSource objdsRecurringAnnual;
    protected HiddenField hfCompanyID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("reports")).Attributes.Add("class", "active open");
      if (!this.IsPostBack)
        this.BindGrid();
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
      this.SetMiscValues(this.hfCompanyID.Value);
    }

    private void BindGrid()
    {
      this.gvRecurringAnnual.DataBind();
    }

    private void SetMiscValues(string companyId)
    {
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(companyId));
      this.lblCompanyName.Text = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
    }

    protected void BtnUpdateClick(object sender, EventArgs e)
    {
      this.BindGrid();
    }
  }
}

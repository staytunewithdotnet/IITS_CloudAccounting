// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.CompanyUserPermissions
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
  public class CompanyUserPermissions : Page
  {
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly AdminPermissionMasterBLL objAdminPermissionMasterBll = new AdminPermissionMasterBLL();
    private CloudAccountDA.AdminPermissionMasterDataTable objAdminPermissionMasterDT = new CloudAccountDA.AdminPermissionMasterDataTable();
    private readonly ClientPermissionMasterBLL objClientPermissionMasterBll = new ClientPermissionMasterBLL();
    private CloudAccountDA.ClientPermissionMasterDataTable objClientPermissionMasterDT = new CloudAccountDA.ClientPermissionMasterDataTable();
    private readonly StaffPermissionMasterBLL objStaffPermissionMasterBll = new StaffPermissionMasterBLL();
    private CloudAccountDA.StaffPermissionMasterDataTable objStaffPermissionMasterDT = new CloudAccountDA.StaffPermissionMasterDataTable();
    protected HtmlGenericControl divSave;
    protected HtmlGenericControl liAdminEstimate;
    protected CheckBox chkAdminEstimate;
    protected HtmlGenericControl liAdminExpense;
    protected CheckBox chkAdminExpense;
    protected HtmlGenericControl liAdminTimesheet;
    protected CheckBox chkAdminTimesheet;
    protected HtmlGenericControl liAdminSupport;
    protected CheckBox chkAdminSupport;
    protected HtmlGenericControl liAdminDocument;
    protected CheckBox chkAdminDocument;
    protected HtmlGenericControl liStaffPeople;
    protected CheckBox chkStaffPeople;
    protected HtmlGenericControl liStaffInvoice;
    protected CheckBox chkStaffInvoice;
    protected HtmlGenericControl liStaffEstimate;
    protected CheckBox chkStaffEstimate;
    protected HtmlGenericControl liStaffExpense;
    protected CheckBox chkStaffExpense;
    protected HtmlGenericControl liStaffTimesheet;
    protected CheckBox chkStaffTimesheet;
    protected HtmlGenericControl liStaffSupport;
    protected CheckBox chkStaffSupport;
    protected HtmlGenericControl liStaffDocument;
    protected CheckBox chkStaffDocument;
    protected HtmlGenericControl liStaffReport;
    protected CheckBox chkStaffReport;
    protected CheckBox chkStaffProjectAccess;
    protected CheckBox chkStaffSendInv;
    protected CheckBox chkStaffClientManagement;
    protected CheckBox chkStaffTicketAdmin;
    protected HtmlGenericControl liClientInvoice;
    protected CheckBox chkClientInvoice;
    protected HtmlGenericControl liClientEstimate;
    protected CheckBox chkClientEstimate;
    protected HtmlGenericControl liClientProject;
    protected CheckBox chkClientProject;
    protected HtmlGenericControl liClientSupport;
    protected CheckBox chkClientSupport;
    protected HtmlGenericControl liClientDocument;
    protected CheckBox chkClientDocument;
    protected CheckBox chkClientDisputeInvoices;
    protected CheckBox chkClientDocumentAdmin;
    protected Button btnSave;
    protected HiddenField hfCompanyID;
    protected HiddenField hfAdminPerID;
    protected HiddenField hfStaffPerID;
    protected HiddenField hfClientPerID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("setting")).Attributes.Add("style", "background-color: lightgray;");
      ((HtmlControl) this.Master.FindControl("permissions")).Attributes.Add("class", "active open");
      MembershipUser user = Membership.GetUser();
      if (user != null)
      {
        string str = user.ToString();
        if (Roles.IsUserInRole(str, "Admin"))
        {
          this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(str);
          if (this.objCompanyLoginMasterDT.Rows.Count > 0)
            this.hfCompanyID.Value = this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString();
        }
      }
      if (this.IsPostBack)
        return;
      this.divSave.Visible = this.Session["savePer"] != null;
      this.Session.Abandon();
      this.SetCompanyPermission(this.hfCompanyID.Value);
    }

    private void SetCompanyPermission(string companyID)
    {
      int num = 0;
      this.objAdminPermissionMasterDT = this.objAdminPermissionMasterBll.GetDataByCompanyID(int.Parse(companyID));
      if (this.objAdminPermissionMasterDT.Rows.Count > 0)
      {
        this.hfAdminPerID.Value = this.objAdminPermissionMasterDT.Rows[0]["AdminPermissionID"].ToString();
        this.chkAdminEstimate.Checked = bool.Parse(this.objAdminPermissionMasterDT.Rows[0]["Estimate"].ToString());
        if (this.chkAdminEstimate.Checked)
          this.liAdminEstimate.Attributes.Add("class", "enabled");
        this.chkAdminExpense.Checked = bool.Parse(this.objAdminPermissionMasterDT.Rows[0]["Expenses"].ToString());
        if (this.chkAdminExpense.Checked)
          this.liAdminExpense.Attributes.Add("class", "enabled");
        this.chkAdminTimesheet.Checked = bool.Parse(this.objAdminPermissionMasterDT.Rows[0]["TimeTracking"].ToString());
        if (this.chkAdminTimesheet.Checked)
          this.liAdminTimesheet.Attributes.Add("class", "enabled");
        this.chkAdminSupport.Checked = bool.Parse(this.objAdminPermissionMasterDT.Rows[0]["Support"].ToString());
        if (this.chkAdminSupport.Checked)
          this.liAdminSupport.Attributes.Add("class", "enabled");
        this.chkAdminDocument.Checked = bool.Parse(this.objAdminPermissionMasterDT.Rows[0]["Documents"].ToString());
        if (this.chkAdminDocument.Checked)
          this.liAdminDocument.Attributes.Add("class", "enabled");
      }
      else
      {
        ++num;
        this.objAdminPermissionMasterBll.AddAdminPermission(int.Parse(companyID), true, true, true, false, false);
      }
      this.objStaffPermissionMasterDT = this.objStaffPermissionMasterBll.GetDataByCompanyID(int.Parse(companyID));
      if (this.objStaffPermissionMasterDT.Rows.Count > 0)
      {
        this.hfStaffPerID.Value = this.objStaffPermissionMasterDT.Rows[0]["StaffPermissionID"].ToString();
        this.chkStaffPeople.Checked = bool.Parse(this.objStaffPermissionMasterDT.Rows[0]["People"].ToString());
        if (this.chkStaffPeople.Checked)
          this.liStaffPeople.Attributes.Add("class", "enabled");
        this.chkStaffInvoice.Checked = bool.Parse(this.objStaffPermissionMasterDT.Rows[0]["Invoice"].ToString());
        if (this.chkStaffInvoice.Checked)
          this.liStaffInvoice.Attributes.Add("class", "enabled");
        this.chkStaffEstimate.Checked = bool.Parse(this.objStaffPermissionMasterDT.Rows[0]["Estimate"].ToString());
        if (this.chkStaffEstimate.Checked)
          this.liStaffEstimate.Attributes.Add("class", "enabled");
        this.chkStaffExpense.Checked = bool.Parse(this.objStaffPermissionMasterDT.Rows[0]["Expenses"].ToString());
        if (this.chkStaffExpense.Checked)
          this.liStaffExpense.Attributes.Add("class", "enabled");
        this.chkStaffTimesheet.Checked = bool.Parse(this.objStaffPermissionMasterDT.Rows[0]["TimeTracking"].ToString());
        if (this.chkStaffTimesheet.Checked)
          this.liStaffTimesheet.Attributes.Add("class", "enabled");
        this.chkStaffSupport.Checked = bool.Parse(this.objStaffPermissionMasterDT.Rows[0]["Support"].ToString());
        if (this.chkStaffSupport.Checked)
          this.liStaffSupport.Attributes.Add("class", "enabled");
        this.chkStaffDocument.Checked = bool.Parse(this.objStaffPermissionMasterDT.Rows[0]["Documents"].ToString());
        if (this.chkStaffDocument.Checked)
          this.liStaffDocument.Attributes.Add("class", "enabled");
        this.chkStaffReport.Checked = bool.Parse(this.objStaffPermissionMasterDT.Rows[0]["Reports"].ToString());
        if (this.chkStaffReport.Checked)
          this.liStaffReport.Attributes.Add("class", "enabled");
        this.chkStaffProjectAccess.Checked = bool.Parse(this.objStaffPermissionMasterDT.Rows[0]["ProjectAccess"].ToString());
        this.chkStaffSendInv.Checked = bool.Parse(this.objStaffPermissionMasterDT.Rows[0]["SendInvEstCre"].ToString());
        this.chkStaffClientManagement.Checked = bool.Parse(this.objStaffPermissionMasterDT.Rows[0]["ClientManagement"].ToString());
        this.chkStaffTicketAdmin.Checked = bool.Parse(this.objStaffPermissionMasterDT.Rows[0]["TicketAdministration"].ToString());
      }
      else
      {
        ++num;
        this.objStaffPermissionMasterBll.AddStaffPermission(int.Parse(companyID), true, true, true, true, true, false, false, true, true, true, true, true);
      }
      this.objClientPermissionMasterDT = this.objClientPermissionMasterBll.GetDataByCompanyID(int.Parse(companyID));
      if (this.objClientPermissionMasterDT.Rows.Count > 0)
      {
        this.hfClientPerID.Value = this.objClientPermissionMasterDT.Rows[0]["ClientPermissionID"].ToString();
        this.chkClientEstimate.Checked = bool.Parse(this.objClientPermissionMasterDT.Rows[0]["Estimate"].ToString());
        if (this.chkClientEstimate.Checked)
          this.liClientEstimate.Attributes.Add("class", "enabled");
        this.chkClientInvoice.Checked = bool.Parse(this.objClientPermissionMasterDT.Rows[0]["Invoice"].ToString());
        if (this.chkClientInvoice.Checked)
          this.liClientInvoice.Attributes.Add("class", "enabled");
        this.chkClientProject.Checked = bool.Parse(this.objClientPermissionMasterDT.Rows[0]["Projects"].ToString());
        if (this.chkClientProject.Checked)
          this.liClientProject.Attributes.Add("class", "enabled");
        this.chkClientSupport.Checked = bool.Parse(this.objClientPermissionMasterDT.Rows[0]["Support"].ToString());
        if (this.chkClientSupport.Checked)
          this.liClientSupport.Attributes.Add("class", "enabled");
        this.chkClientDocument.Checked = bool.Parse(this.objClientPermissionMasterDT.Rows[0]["Documents"].ToString());
        if (this.chkClientDocument.Checked)
          this.liClientDocument.Attributes.Add("class", "enabled");
        this.chkClientDisputeInvoices.Checked = bool.Parse(this.objClientPermissionMasterDT.Rows[0]["DisputeInvoices"].ToString());
        this.chkClientDocumentAdmin.Checked = bool.Parse(this.objClientPermissionMasterDT.Rows[0]["DocumentAdministration"].ToString());
      }
      else
      {
        ++num;
        this.objClientPermissionMasterBll.AddClientPermission(int.Parse(companyID), true, true, true, false, false, true, true);
      }
      if (num <= 0)
        return;
      this.Response.Redirect("CompanyUserPermissions.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
      this.objAdminPermissionMasterDT = this.objAdminPermissionMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objAdminPermissionMasterDT.Rows.Count > 0)
        this.objAdminPermissionMasterBll.UpdateAdminPermission(int.Parse(this.hfAdminPerID.Value), int.Parse(this.hfCompanyID.Value), this.chkAdminEstimate.Checked, this.chkAdminExpense.Checked, this.chkAdminTimesheet.Checked, this.chkAdminSupport.Checked, this.chkAdminDocument.Checked);
      else
        this.objAdminPermissionMasterBll.AddAdminPermission(int.Parse(this.hfCompanyID.Value), true, true, true, false, false);
      this.objStaffPermissionMasterDT = this.objStaffPermissionMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objStaffPermissionMasterDT.Rows.Count > 0)
        this.objStaffPermissionMasterBll.UpdateStaffPermission(int.Parse(this.hfStaffPerID.Value), int.Parse(this.hfCompanyID.Value), this.chkStaffPeople.Checked, this.chkStaffInvoice.Checked, this.chkStaffEstimate.Checked, this.chkStaffExpense.Checked, this.chkStaffTimesheet.Checked, this.chkStaffSupport.Checked, this.chkStaffDocument.Checked, this.chkStaffReport.Checked, this.chkStaffProjectAccess.Checked, this.chkStaffSendInv.Checked, this.chkStaffClientManagement.Checked, this.chkStaffTicketAdmin.Checked);
      else
        this.objStaffPermissionMasterBll.AddStaffPermission(int.Parse(this.hfCompanyID.Value), true, true, true, true, true, false, false, true, true, true, true, true);
      this.objClientPermissionMasterDT = this.objClientPermissionMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objClientPermissionMasterDT.Rows.Count > 0)
        this.objClientPermissionMasterBll.UpdateClientPermission(int.Parse(this.hfClientPerID.Value), int.Parse(this.hfCompanyID.Value), this.chkClientInvoice.Checked, this.chkClientEstimate.Checked, this.chkClientProject.Checked, this.chkClientSupport.Checked, this.chkClientDocument.Checked, this.chkClientDisputeInvoices.Checked, this.chkClientDocumentAdmin.Checked);
      else
        this.objClientPermissionMasterBll.AddClientPermission(int.Parse(this.hfCompanyID.Value), true, true, true, false, false, true, true);
      this.Session["savePer"] = (object) 1;
      this.Response.Redirect("CompanyUserPermissions.aspx");
    }
  }
}

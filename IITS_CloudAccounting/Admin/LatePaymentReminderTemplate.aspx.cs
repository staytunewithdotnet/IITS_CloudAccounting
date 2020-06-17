// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.LatePaymentReminderTemplate
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class LatePaymentReminderTemplate : Page
  {
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly LatePaymentReminderTemplateBLL objLatePaymentReminderTemplateBll = new LatePaymentReminderTemplateBLL();
    private CloudAccountDA.LatePaymentReminderTemplateDataTable objLatePaymentReminderTemplateDT = new CloudAccountDA.LatePaymentReminderTemplateDataTable();
    private readonly StringBuilder strBody1 = new StringBuilder("Your invoice is now 30 days overdue.  Please pay your invoice.<br /><br />To access your invoice from ##companyName##, go to:<br /><br />##someLink##<br />");
    private readonly StringBuilder strBody2 = new StringBuilder("Your invoice is now 60 days overdue.  Please pay your invoice.<br /><br />To access your invoice from ##companyName##, go to:<br /><br />##someLink##<br />");
    private readonly StringBuilder strBody3 = new StringBuilder("Your invoice is now 90 days overdue.  Please pay your invoice.<br /><br />To access your invoice from ##companyName##, go to:<br /><br />##someLink##<br />");
    private const string strSubject = "Your payment for invoice ##invoiceNumber## is overdue in Bill Transact";
    protected ToolkitScriptManager tsm;
    protected UpdatePanel upLatePayment;
    protected DropDownList ddlReminder;
    protected CheckBox chkEnable;
    protected TextBox txtDays;
    protected TextBox txtSubject;
    protected TextBox txtBody;
    protected Button btnSave;
    protected Button btnDefault;
    protected HiddenField hfCompanyID;
    protected HiddenField hfEmailID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("setting")).Attributes.Add("style", "background-color: lightgray;");
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
      this.SetCompanyRecords(this.hfCompanyID.Value, int.Parse(this.ddlReminder.SelectedItem.Value));
    }

    private void SetCompanyRecords(string companyID, int reminder)
    {
      this.objLatePaymentReminderTemplateDT = this.objLatePaymentReminderTemplateBll.GetDataByCompanyID(int.Parse(companyID), reminder);
      if (this.objLatePaymentReminderTemplateDT.Rows.Count > 0)
      {
        this.hfEmailID.Value = this.objLatePaymentReminderTemplateDT.Rows[0]["LatePaymentReminderID"].ToString();
        this.hfCompanyID.Value = this.objLatePaymentReminderTemplateDT.Rows[0]["CompanyID"].ToString();
        this.chkEnable.Checked = bool.Parse(this.objLatePaymentReminderTemplateDT.Rows[0]["Enable"].ToString());
        this.txtDays.Text = this.objLatePaymentReminderTemplateDT.Rows[0]["Days"].ToString();
        this.txtSubject.Text = this.objLatePaymentReminderTemplateDT.Rows[0]["EmailSubject"].ToString();
        this.txtBody.Text = this.objLatePaymentReminderTemplateDT.Rows[0]["EmailBody"].ToString();
        this.txtBody.Text = this.txtBody.Text.Replace("&nbsp;&nbsp;", "  ");
        this.txtBody.Text = this.txtBody.Text.Replace("<br />", "\n");
      }
      else
      {
        this.objLatePaymentReminderTemplateDT = this.objLatePaymentReminderTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value), 1);
        if (this.objLatePaymentReminderTemplateDT.Rows.Count == 0)
            this.objLatePaymentReminderTemplateBll.AddLatePaymentReminder(int.Parse(this.hfCompanyID.Value), 1, false, 30, "Your payment for invoice ##invoiceNumber## is overdue in Bill Transact", this.strBody1.ToString());
        this.objLatePaymentReminderTemplateDT = this.objLatePaymentReminderTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value), 2);
        if (this.objLatePaymentReminderTemplateDT.Rows.Count == 0)
            this.objLatePaymentReminderTemplateBll.AddLatePaymentReminder(int.Parse(this.hfCompanyID.Value), 2, false, 60, "Your payment for invoice ##invoiceNumber## is overdue in Bill Transact", this.strBody2.ToString());
        this.objLatePaymentReminderTemplateDT = this.objLatePaymentReminderTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value), 3);
        if (this.objLatePaymentReminderTemplateDT.Rows.Count == 0)
            this.objLatePaymentReminderTemplateBll.AddLatePaymentReminder(int.Parse(this.hfCompanyID.Value), 3, false, 90, "Your payment for invoice ##invoiceNumber## is overdue in Bill Transact", this.strBody3.ToString());
        this.Response.Redirect("LatePaymentReminderTemplate.aspx");
      }
    }

    protected void btnRestore_Click(object sender, EventArgs e)
    {
      if (this.ddlReminder.SelectedItem.Value == "1")
      {
        this.objLatePaymentReminderTemplateDT = this.objLatePaymentReminderTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value), 1);
        if (this.objLatePaymentReminderTemplateDT.Rows.Count > 0)
        {
          this.hfEmailID.Value = this.objLatePaymentReminderTemplateDT.Rows[0]["LatePaymentReminderID"].ToString();
          this.objLatePaymentReminderTemplateBll.UpdateLatePaymentReminder(int.Parse(this.hfEmailID.Value), int.Parse(this.hfCompanyID.Value), 1, false, 30, "Your payment for invoice ##invoiceNumber## is overdue in Bill Transact", this.strBody1.ToString());
        }
        else
            this.objLatePaymentReminderTemplateBll.AddLatePaymentReminder(int.Parse(this.hfCompanyID.Value), 1, false, 30, "Your payment for invoice ##invoiceNumber## is overdue in Bill Transact", this.strBody1.ToString());
      }
      else if (this.ddlReminder.SelectedItem.Value == "2")
      {
        this.objLatePaymentReminderTemplateDT = this.objLatePaymentReminderTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value), 2);
        if (this.objLatePaymentReminderTemplateDT.Rows.Count > 0)
        {
          this.hfEmailID.Value = this.objLatePaymentReminderTemplateDT.Rows[0]["LatePaymentReminderID"].ToString();
          this.objLatePaymentReminderTemplateBll.UpdateLatePaymentReminder(int.Parse(this.hfEmailID.Value), int.Parse(this.hfCompanyID.Value), 2, false, 60, "Your payment for invoice ##invoiceNumber## is overdue in Bill Transact", this.strBody2.ToString());
        }
        else
            this.objLatePaymentReminderTemplateBll.AddLatePaymentReminder(int.Parse(this.hfCompanyID.Value), 2, false, 60, "Your payment for invoice ##invoiceNumber## is overdue in Bill Transact", this.strBody2.ToString());
      }
      else if (this.ddlReminder.SelectedItem.Value == "3")
      {
        this.objLatePaymentReminderTemplateDT = this.objLatePaymentReminderTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value), 3);
        if (this.objLatePaymentReminderTemplateDT.Rows.Count > 0)
        {
          this.hfEmailID.Value = this.objLatePaymentReminderTemplateDT.Rows[0]["LatePaymentReminderID"].ToString();
          this.objLatePaymentReminderTemplateBll.UpdateLatePaymentReminder(int.Parse(this.hfEmailID.Value), int.Parse(this.hfCompanyID.Value), 3, false, 90, "Your payment for invoice ##invoiceNumber## is overdue in Bill Transact", this.strBody3.ToString());
        }
        else
            this.objLatePaymentReminderTemplateBll.AddLatePaymentReminder(int.Parse(this.hfCompanyID.Value), 3, false, 90, "Your payment for invoice ##invoiceNumber## is overdue in Bill Transact", this.strBody3.ToString());
      }
      this.Response.Redirect("LatePaymentReminderTemplate.aspx");
    }

    protected void ddlReminder_OnSelectedIndexChanged(object sender, EventArgs e)
    {
      this.SetCompanyRecords(this.hfCompanyID.Value, int.Parse(this.ddlReminder.SelectedItem.Value));
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
      this.objLatePaymentReminderTemplateDT = this.objLatePaymentReminderTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value), int.Parse(this.ddlReminder.SelectedItem.Value));
      if (this.objLatePaymentReminderTemplateDT.Rows.Count > 0)
      {
        this.hfEmailID.Value = this.objLatePaymentReminderTemplateDT.Rows[0]["LatePaymentReminderID"].ToString();
        this.objLatePaymentReminderTemplateBll.UpdateLatePaymentReminder(int.Parse(this.hfEmailID.Value), int.Parse(this.hfCompanyID.Value), int.Parse(this.ddlReminder.SelectedItem.Value), this.chkEnable.Checked, int.Parse(this.txtDays.Text), this.txtSubject.Text, new StringBuilder(this.txtBody.Text).Replace("\n", "<br />").Replace("  ", "&nbsp;&nbsp;").ToString());
      }
      this.Response.Redirect("LatePaymentReminderTemplate.aspx");
    }
  }
}

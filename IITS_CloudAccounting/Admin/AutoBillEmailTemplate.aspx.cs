// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.AutoBillEmailTemplate
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
  public class AutoBillEmailTemplate : Page
  {
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly AutoBillEmailTemplateBLL objAutoBillEmailTemplateBll = new AutoBillEmailTemplateBLL();
    private CloudAccountDA.AutoBillEmailTemplateDataTable objAutoBillEmailTemplateDT = new CloudAccountDA.AutoBillEmailTemplateDataTable();
    private readonly StringBuilder strBodyBill = new StringBuilder("This is a recurring invoice from ##companyName## for ##paymentAmt##. To view your invoice and setup automatic credit card payments, click the link below:<br /><br />##someLink##<br />");
    private readonly StringBuilder strBodyPaid = new StringBuilder("This is a recurring invoice from ##companyName## for ##paymentAmt## that was automatically paid with your saved credit card. To view your invoice, or to download a PDF copy for your records, click the link below:<br /><br />##someLink##<br />");
    private readonly StringBuilder strBodyExpired = new StringBuilder("Dear ##firstName##,<br /><br />The credit card we have on file will expire this month.<br /><br />To update your information, kindly:<br /><br />1. Access your account here: ##clientHome##.<br />2. Click on \"Profile\" near the top right of the page.<br />3. Enter your new credit card information.<br />4. Click \"Save\" at the bottom of the page.<br /><br />If you have any questions, or if you would like to have us update your credit card information for you, please contact us.<br />");
    private readonly StringBuilder strBodyFailed = new StringBuilder("Dear ##firstName##,<br /><br />A credit card transaction we have attempted to process for your account has failed twice. It is likely that the credit card information we have on file for you is not up-to-date. To update your information, kindly:<br /><br />1. Access your account here: ##clientHome##.<br />2. Click on \"Profile\", near the top right of the page.<br />3. Enter your new credit card information.<br />4. Click \"Save\" at the bottom of the page.<br /><br />If you have any questions, or if you would like to have us update your credit card information for you, please contact us.<br /><br />");
    private const string strSubjectAuto = "New recurring invoice ##invoiceNumber## from ##companyName##, sent using Bill Transact";
    private const string strSubjectExpired = "Action required: Your credit card on file with ##companyName## is expiring soon in Bill Transact";
    private const string strSubjectFailed = "Action required: Your credit card on file for invoice ##invoiceNumber## from ##companyName## needs updating in Bill Transact";
    protected ToolkitScriptManager tsm;
    protected UpdatePanel upAutoEmail;
    protected DropDownList ddlTemplateFor;
    protected HtmlGenericControl checkboxEnable;
    protected CheckBox chkEnable;
    protected TextBox txtSubject;
    protected TextBox txtBody;
    protected HtmlGenericControl divAuto;
    protected HtmlGenericControl divCard;
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
      this.SetCompanyRecords(this.hfCompanyID.Value, this.ddlTemplateFor.SelectedItem.Value);
    }

    private void SetCompanyRecords(string companyID, string templateFor)
    {
      this.objAutoBillEmailTemplateDT = this.objAutoBillEmailTemplateBll.GetDataByCompanyID(int.Parse(companyID), templateFor);
      if (this.objAutoBillEmailTemplateDT.Rows.Count > 0)
      {
        this.hfEmailID.Value = this.objAutoBillEmailTemplateDT.Rows[0]["AutoBillEmailTemplateID"].ToString();
        this.hfCompanyID.Value = this.objAutoBillEmailTemplateDT.Rows[0]["CompanyID"].ToString();
        this.chkEnable.Checked = bool.Parse(this.objAutoBillEmailTemplateDT.Rows[0]["Enable"].ToString());
        this.txtSubject.Text = this.objAutoBillEmailTemplateDT.Rows[0]["EmailSubject"].ToString();
        this.txtBody.Text = this.objAutoBillEmailTemplateDT.Rows[0]["EmailBody"].ToString();
        this.txtBody.Text = this.txtBody.Text.Replace("&nbsp;&nbsp;", "  ");
        this.txtBody.Text = this.txtBody.Text.Replace("<br />", "\n");
      }
      else
      {
        this.objAutoBillEmailTemplateDT = this.objAutoBillEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value), "Auto-bill");
        if (this.objAutoBillEmailTemplateDT.Rows.Count == 0)
            this.objAutoBillEmailTemplateBll.AddAutoBillEmail(int.Parse(this.hfCompanyID.Value), "Auto-bill", true, "New recurring invoice ##invoiceNumber## from ##companyName##, sent using Bill Transact", this.strBodyBill.ToString());
        this.objAutoBillEmailTemplateDT = this.objAutoBillEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value), "Auto-paid");
        if (this.objAutoBillEmailTemplateDT.Rows.Count == 0)
            this.objAutoBillEmailTemplateBll.AddAutoBillEmail(int.Parse(this.hfCompanyID.Value), "Auto-bill", true, "New recurring invoice ##invoiceNumber## from ##companyName##, sent using Bill Transact", this.strBodyPaid.ToString());
        this.objAutoBillEmailTemplateDT = this.objAutoBillEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value), "Card Expired");
        if (this.objAutoBillEmailTemplateDT.Rows.Count == 0)
            this.objAutoBillEmailTemplateBll.AddAutoBillEmail(int.Parse(this.hfCompanyID.Value), "Card Expired", true, "Action required: Your credit card on file with ##companyName## is expiring soon in Bill Transact", this.strBodyExpired.ToString());
        this.objAutoBillEmailTemplateDT = this.objAutoBillEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value), "Card Failed");
        if (this.objAutoBillEmailTemplateDT.Rows.Count == 0)
            this.objAutoBillEmailTemplateBll.AddAutoBillEmail(int.Parse(this.hfCompanyID.Value), "Card Failed", false, "Action required: Your credit card on file for invoice ##invoiceNumber## from ##companyName## needs updating in Bill Transact", this.strBodyFailed.ToString());
        this.Response.Redirect("AutoBillEmailTemplate.aspx");
      }
    }

    protected void btnRestore_Click(object sender, EventArgs e)
    {
      if (this.ddlTemplateFor.SelectedItem.Value == "Auto-bill")
      {
        this.objAutoBillEmailTemplateDT = this.objAutoBillEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value), "Auto-bill");
        if (this.objAutoBillEmailTemplateDT.Rows.Count > 0)
        {
          this.hfEmailID.Value = this.objAutoBillEmailTemplateDT.Rows[0]["AutoBillEmailTemplateID"].ToString();
          this.objAutoBillEmailTemplateBll.UpdateAutoBillEmail(int.Parse(this.hfEmailID.Value), int.Parse(this.hfCompanyID.Value), "Auto-bill", true, "New recurring invoice ##invoiceNumber## from ##companyName##, sent using Bill Transact", this.strBodyBill.ToString());
        }
        else
            this.objAutoBillEmailTemplateBll.AddAutoBillEmail(int.Parse(this.hfCompanyID.Value), "Auto-bill", true, "New recurring invoice ##invoiceNumber## from ##companyName##, sent using Bill Transact", this.strBodyBill.ToString());
      }
      else if (this.ddlTemplateFor.SelectedItem.Value == "Auto-paid")
      {
        this.objAutoBillEmailTemplateDT = this.objAutoBillEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value), "Auto-paid");
        if (this.objAutoBillEmailTemplateDT.Rows.Count > 0)
        {
          this.hfEmailID.Value = this.objAutoBillEmailTemplateDT.Rows[0]["AutoBillEmailTemplateID"].ToString();
          this.objAutoBillEmailTemplateBll.UpdateAutoBillEmail(int.Parse(this.hfEmailID.Value), int.Parse(this.hfCompanyID.Value), "Auto-paid", true, "New recurring invoice ##invoiceNumber## from ##companyName##, sent using Bill Transact", this.strBodyPaid.ToString());
        }
        else
            this.objAutoBillEmailTemplateBll.AddAutoBillEmail(int.Parse(this.hfCompanyID.Value), "Auto-paid", true, "New recurring invoice ##invoiceNumber## from ##companyName##, sent using Bill Transact", this.strBodyPaid.ToString());
      }
      else if (this.ddlTemplateFor.SelectedItem.Value == "Card Expired")
      {
        this.objAutoBillEmailTemplateDT = this.objAutoBillEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value), "Card Expired");
        if (this.objAutoBillEmailTemplateDT.Rows.Count > 0)
        {
          this.hfEmailID.Value = this.objAutoBillEmailTemplateDT.Rows[0]["AutoBillEmailTemplateID"].ToString();
          this.objAutoBillEmailTemplateBll.UpdateAutoBillEmail(int.Parse(this.hfEmailID.Value), int.Parse(this.hfCompanyID.Value), "Card Expired", true, "Action required: Your credit card on file with ##companyName## is expiring soon in Bill Transact", this.strBodyExpired.ToString());
        }
        else
            this.objAutoBillEmailTemplateBll.AddAutoBillEmail(int.Parse(this.hfCompanyID.Value), "Card Expired", true, "Action required: Your credit card on file with ##companyName## is expiring soon in Bill Transact", this.strBodyExpired.ToString());
      }
      else if (this.ddlTemplateFor.SelectedItem.Value == "Card Failed")
      {
        this.objAutoBillEmailTemplateDT = this.objAutoBillEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value), "Card Failed");
        if (this.objAutoBillEmailTemplateDT.Rows.Count > 0)
        {
          this.hfEmailID.Value = this.objAutoBillEmailTemplateDT.Rows[0]["AutoBillEmailTemplateID"].ToString();
          this.objAutoBillEmailTemplateBll.UpdateAutoBillEmail(int.Parse(this.hfEmailID.Value), int.Parse(this.hfCompanyID.Value), "Card Failed", false, "Action required: Your credit card on file for invoice ##invoiceNumber## from ##companyName## needs updating in Bill Transact", this.strBodyFailed.ToString());
        }
        else
            this.objAutoBillEmailTemplateBll.AddAutoBillEmail(int.Parse(this.hfCompanyID.Value), "Card Failed", false, "Action required: Your credit card on file for invoice ##invoiceNumber## from ##companyName## needs updating in Bill Transact", this.strBodyFailed.ToString());
      }
      this.Response.Redirect("AutoBillEmailTemplate.aspx");
    }

    protected void ddlTemplateFor_OnSelectedIndexChanged(object sender, EventArgs e)
    {
      this.checkboxEnable.Visible = this.ddlTemplateFor.SelectedItem.Value.Contains("Card");
      this.divCard.Visible = this.ddlTemplateFor.SelectedItem.Value.Contains("Card");
      this.divAuto.Visible = !this.ddlTemplateFor.SelectedItem.Value.Contains("Card");
      if (this.checkboxEnable.Visible)
      {
        if (this.ddlTemplateFor.SelectedItem.Value == "Card Expired")
          this.chkEnable.Text = "Yes, send my client credit card expiry emails";
        if (this.ddlTemplateFor.SelectedItem.Value == "Card Failed")
          this.chkEnable.Text = "Yes, send my client credit card failure emails";
      }
      this.SetCompanyRecords(this.hfCompanyID.Value, this.ddlTemplateFor.SelectedItem.Value);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
      this.objAutoBillEmailTemplateDT = this.objAutoBillEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value), this.ddlTemplateFor.SelectedItem.Value);
      if (this.objAutoBillEmailTemplateDT.Rows.Count > 0)
      {
        this.hfEmailID.Value = this.objAutoBillEmailTemplateDT.Rows[0]["AutoBillEmailTemplateID"].ToString();
        this.objAutoBillEmailTemplateBll.UpdateAutoBillEmail(int.Parse(this.hfEmailID.Value), int.Parse(this.hfCompanyID.Value), this.ddlTemplateFor.SelectedItem.Value, this.chkEnable.Checked, this.txtSubject.Text, new StringBuilder(this.txtBody.Text).Replace("\n", "<br />").Replace("  ", "&nbsp;&nbsp;").ToString());
      }
      this.Response.Redirect("AutoBillEmailTemplate.aspx");
    }
  }
}

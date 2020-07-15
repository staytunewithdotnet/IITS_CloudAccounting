// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.NewPaymentEmailTemplate
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
  public class NewPaymentEmailTemplate : Page
  {
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly NewPaymentEmailTemplateBLL objNewPaymentEmailTemplateBll = new NewPaymentEmailTemplateBLL();
    private CloudAccountDA.NewPaymentEmailTemplateDataTable objNewPaymentEmailTemplateDT = new CloudAccountDA.NewPaymentEmailTemplateDataTable();
    private readonly StringBuilder strBody = new StringBuilder("Thank you for your business.<br />We have received your payment in the amount of ##payment amount## for invoice ##invoice number##.<br />To view the paid invoice or download a PDF copy for your records, click the link below:<br /><br />##someLink##<br />");
    private const string strSubject = "##companyName## has received your payment for invoice ##invoiceNumber## in Bill Transact";
    protected ToolkitScriptManager tsm;
    protected UpdatePanel upPayment;
    protected DropDownList ddlPayments;
    protected CheckBox chkEnable;
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
      this.SetCompanyRecords(this.hfCompanyID.Value, this.ddlPayments.SelectedItem.Value);
    }

    private void SetCompanyRecords(string companyID, string payment)
    {
      this.objNewPaymentEmailTemplateDT = this.objNewPaymentEmailTemplateBll.GetDataByCompanyID(int.Parse(companyID), payment);
      if (this.objNewPaymentEmailTemplateDT.Rows.Count > 0)
      {
        this.hfEmailID.Value = this.objNewPaymentEmailTemplateDT.Rows[0]["NewPaymentEmailTemplateID"].ToString();
        this.hfCompanyID.Value = this.objNewPaymentEmailTemplateDT.Rows[0]["CompanyID"].ToString();
        this.chkEnable.Checked = bool.Parse(this.objNewPaymentEmailTemplateDT.Rows[0]["Enable"].ToString());
        this.txtSubject.Text = this.objNewPaymentEmailTemplateDT.Rows[0]["EmailSubject"].ToString();
        this.txtBody.Text = this.objNewPaymentEmailTemplateDT.Rows[0]["EmailBody"].ToString();
        this.txtBody.Text = this.txtBody.Text.Replace("&nbsp;&nbsp;", "  ");
        this.txtBody.Text = this.txtBody.Text.Replace("<br />", "\n");
        this.chkEnable.Text = this.ddlPayments.SelectedItem.Value == "online" ? "Yes, send my client an email when an online payment is made" : "Yes, send my client an email when I enter an offline payment (e.g. check in mail)";
      }
      else
      {
          this.objNewPaymentEmailTemplateBll.AddPaymentTemplate(int.Parse(companyID), payment, this.chkEnable.Checked, "##companyName## has received your payment for invoice ##invoiceNumber## in Bill Transact", this.strBody.ToString());
        this.Response.Redirect("NewPaymentEmailTemplate.aspx");
      }
    }

    protected void btnRestore_Click(object sender, EventArgs e)
    {
      if (this.ddlPayments.SelectedItem.Value == "online")
      {
        this.objNewPaymentEmailTemplateDT = this.objNewPaymentEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value), "online");
        if (this.objNewPaymentEmailTemplateDT.Rows.Count > 0)
            this.objNewPaymentEmailTemplateBll.UpdatePaymentTemplate(int.Parse(this.hfEmailID.Value), int.Parse(this.hfCompanyID.Value), "online", true, "##companyName## has received your payment for invoice ##invoiceNumber## in Bill Transact", this.strBody.ToString());
        else
            this.objNewPaymentEmailTemplateBll.AddPaymentTemplate(int.Parse(this.hfCompanyID.Value), "online", true, "##companyName## has received your payment for invoice ##invoiceNumber## in Bill Transact", this.strBody.ToString());
      }
      else
      {
        this.objNewPaymentEmailTemplateDT = this.objNewPaymentEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value), "other");
        if (this.objNewPaymentEmailTemplateDT.Rows.Count > 0)
            this.objNewPaymentEmailTemplateBll.UpdatePaymentTemplate(int.Parse(this.hfEmailID.Value), int.Parse(this.hfCompanyID.Value), "other", false, "##companyName## has received your payment for invoice ##invoiceNumber## in Bill Transact", this.strBody.ToString());
        else
            this.objNewPaymentEmailTemplateBll.AddPaymentTemplate(int.Parse(this.hfCompanyID.Value), "other", true, "##companyName## has received your payment for invoice ##invoiceNumber## in Bill Transact", this.strBody.ToString());
      }
      this.Response.Redirect("NewPaymentEmailTemplate.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
      this.objNewPaymentEmailTemplateDT = this.objNewPaymentEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value), this.ddlPayments.SelectedItem.Value);
      if (this.objNewPaymentEmailTemplateDT.Rows.Count > 0)
        this.objNewPaymentEmailTemplateBll.UpdatePaymentTemplate(int.Parse(this.hfEmailID.Value), int.Parse(this.hfCompanyID.Value), this.ddlPayments.SelectedItem.Value, true, this.txtSubject.Text, new StringBuilder(this.txtBody.Text).Replace("\n", "<br />").Replace("  ", "&nbsp;&nbsp;").ToString());
      else
          this.objNewPaymentEmailTemplateBll.AddPaymentTemplate(int.Parse(this.hfCompanyID.Value), this.ddlPayments.SelectedItem.Value, this.chkEnable.Checked, "##companyName## has received your payment for invoice ##invoiceNumber## in Bill Transact", new StringBuilder(this.txtBody.Text).Replace("\n", "<br />").Replace("  ", "&nbsp;&nbsp;").ToString());
      this.Response.Redirect("NewPaymentEmailTemplate.aspx");
    }

    protected void ddlPayments_OnSelectedIndexChanged(object sender, EventArgs e)
    {
      this.chkEnable.Checked = this.ddlPayments.SelectedItem.Value == "online";
      this.chkEnable.Text = this.ddlPayments.SelectedItem.Value == "online" ? "Yes, send my client an email when an online payment is made" : "Yes, send my client an email when I enter an offline payment (e.g. check in mail)";
      this.SetCompanyRecords(this.hfCompanyID.Value, this.ddlPayments.SelectedItem.Value);
    }
  }
}

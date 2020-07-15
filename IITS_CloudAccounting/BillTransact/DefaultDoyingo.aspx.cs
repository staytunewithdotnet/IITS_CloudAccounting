// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.DefaultDoyingo
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TemplateParser;

namespace IITS_CloudAccounting.Admin
{
  public class DefaultDoyingo : Page
  {
    private readonly CurrencyMasterBLL objCurrencyMasterBll = new CurrencyMasterBLL();
    private CloudAccountDA.CurrencyMasterDataTable objCurrencyMasterDT = new CloudAccountDA.CurrencyMasterDataTable();
    private readonly FreePackageSettingsBLL objFreePackageSettingsBll = new FreePackageSettingsBLL();
    private CloudAccountDA.FreePackageSettingsDataTable objFreePackageSettingsDT = new CloudAccountDA.FreePackageSettingsDataTable();
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private readonly SMTPSettingsBLL objSMTPSettingsBll = new SMTPSettingsBLL();
    private CloudAccountDA.SMTPSettingsDataTable objSMTPSettingsDT = new CloudAccountDA.SMTPSettingsDataTable();
    private readonly MiscellaneousMasterBLL objMiscellaneousMasterBll = new MiscellaneousMasterBLL();
    private CloudAccountDA.MiscellaneousMasterDataTable objMiscellaneousMasterDT = new CloudAccountDA.MiscellaneousMasterDataTable();
    private readonly AdminPermissionMasterBLL objAdminPermissionMasterBll = new AdminPermissionMasterBLL();
    private CloudAccountDA.AdminPermissionMasterDataTable objAdminPermissionMasterDT = new CloudAccountDA.AdminPermissionMasterDataTable();
    private readonly ClientPermissionMasterBLL objClientPermissionMasterBll = new ClientPermissionMasterBLL();
    private CloudAccountDA.ClientPermissionMasterDataTable objClientPermissionMasterDT = new CloudAccountDA.ClientPermissionMasterDataTable();
    private readonly StaffPermissionMasterBLL objStaffPermissionMasterBll = new StaffPermissionMasterBLL();
    private CloudAccountDA.StaffPermissionMasterDataTable objStaffPermissionMasterDT = new CloudAccountDA.StaffPermissionMasterDataTable();
    private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
    private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
    private readonly TemplateSettingsBLL objTemplateSettingsBll = new TemplateSettingsBLL();
    private CloudAccountDA.TemplateSettingsDataTable objTemplateSettingsDT = new CloudAccountDA.TemplateSettingsDataTable();
    private readonly EmailNotificationsBLL objEmailNotificationsBll = new EmailNotificationsBLL();
    private CloudAccountDA.EmailNotificationsDataTable objEmailNotificationsDT = new CloudAccountDA.EmailNotificationsDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly AccountantClientDetailBLL _objAccountantClientDetailBll = new AccountantClientDetailBLL();
    private CloudAccountDA.AccountantClientDetailDataTable _objAccountantClientDetailDt = new CloudAccountDA.AccountantClientDetailDataTable();
    private readonly NewClientEmailTemplateBLL objNewClientEmailTemplateBll = new NewClientEmailTemplateBLL();
    private CloudAccountDA.NewClientEmailTemplateDataTable objNewClientEmailTemplateDT = new CloudAccountDA.NewClientEmailTemplateDataTable();
    private readonly NewCreditEmailTemplateBLL objNewCreditEmailTemplateBll = new NewCreditEmailTemplateBLL();
    private CloudAccountDA.NewCreditEmailTemplateDataTable objNewCreditEmailTemplateDT = new CloudAccountDA.NewCreditEmailTemplateDataTable();
    private readonly NewEstimateEmailTemplateBLL objNewEstimateEmailTemplateBll = new NewEstimateEmailTemplateBLL();
    private CloudAccountDA.NewEstimateEmailTemplateDataTable objNewEstimateEmailTemplateDT = new CloudAccountDA.NewEstimateEmailTemplateDataTable();
    private readonly NewInvoiceEmailTemplateBLL objNewInvoiceEmailTemplateBll = new NewInvoiceEmailTemplateBLL();
    private CloudAccountDA.NewInvoiceEmailTemplateDataTable objNewInvoiceEmailTemplateDT = new CloudAccountDA.NewInvoiceEmailTemplateDataTable();
    private readonly NewStaffEmailTemplateBLL objNewStaffEmailTemplateBll = new NewStaffEmailTemplateBLL();
    private CloudAccountDA.NewStaffEmailTemplateDataTable objNewStaffEmailTemplateDT = new CloudAccountDA.NewStaffEmailTemplateDataTable();
    private readonly NewPaymentEmailTemplateBLL objNewPaymentEmailTemplateBll = new NewPaymentEmailTemplateBLL();
    private CloudAccountDA.NewPaymentEmailTemplateDataTable objNewPaymentEmailTemplateDT = new CloudAccountDA.NewPaymentEmailTemplateDataTable();
    private readonly LatePaymentReminderTemplateBLL objLatePaymentReminderTemplateBll = new LatePaymentReminderTemplateBLL();
    private CloudAccountDA.LatePaymentReminderTemplateDataTable objLatePaymentReminderTemplateDT = new CloudAccountDA.LatePaymentReminderTemplateDataTable();
    private readonly AutoBillEmailTemplateBLL objAutoBillEmailTemplateBll = new AutoBillEmailTemplateBLL();
    private CloudAccountDA.AutoBillEmailTemplateDataTable objAutoBillEmailTemplateDT = new CloudAccountDA.AutoBillEmailTemplateDataTable();
    private readonly CompanyPackageMasterBLL objCompanyPackageMasterBll = new CompanyPackageMasterBLL();
    private CloudAccountDA.CompanyPackageMasterDataTable objCompanyPackageMasterDT = new CloudAccountDA.CompanyPackageMasterDataTable();
    private readonly StringBuilder strBodyBill = new StringBuilder("This is a recurring invoice from ##companyName## for ##paymentAmt##. To view your invoice and setup automatic credit card payments, click the link below:<br /><br />##someLink##<br />");
    private readonly StringBuilder strBodyPaid = new StringBuilder("This is a recurring invoice from ##companyName## for ##paymentAmt## that was automatically paid with your saved credit card. To view your invoice, or to download a PDF copy for your records, click the link below:<br /><br />##someLink##<br />");
    private readonly StringBuilder strBodyExpired = new StringBuilder("Dear ##firstName##,<br /><br />The credit card we have on file will expire this month.<br /><br />To update your information, kindly:<br /><br />1. Access your account here: ##clientHome##.<br />2. Click on \"Profile\" near the top right of the page.<br />3. Enter your new credit card information.<br />4. Click \"Save\" at the bottom of the page.<br /><br />If you have any questions, or if you would like to have us update your credit card information for you, please contact us.<br />");
    private readonly StringBuilder strBodyFailed = new StringBuilder("Dear ##firstName##,<br /><br />A credit card transaction we have attempted to process for your account has failed twice. It is likely that the credit card information we have on file for you is not up-to-date. To update your information, kindly:<br /><br />1. Access your account here: ##clientHome##.<br />2. Click on \"Profile\", near the top right of the page.<br />3. Enter your new credit card information.<br />4. Click \"Save\" at the bottom of the page.<br /><br />If you have any questions, or if you would like to have us update your credit card information for you, please contact us.<br /><br />");
    private const string strSubjectAuto = "New recurring invoice ##invoiceNumber## from ##companyName##, sent using Bill Transact";
    private const string strSubjectExpired = "Action required: Your credit card on file with ##companyName## is expiring soon in Bill Transact";
    private const string strSubjectFailed = "Action required: Your credit card on file for invoice ##invoiceNumber## from ##companyName## needs updating in Bill Transact";
    protected ToolkitScriptManager ToolkitScriptManager1;
    protected HtmlGenericControl dashboard;
    protected Label lblRole;
    protected Panel pnlMasterAdmin;
    protected Panel pnlCompanyAdmin;
    protected HtmlGenericControl packageInfo;
    protected Button btnUpgrade;
    protected Panel pnlEmployee;
    protected HtmlGenericControl welcomeDiv;
    protected Label lblStaffWelcomeMsg;
    protected Panel my;
    protected ModalPopupExtender mpUserData;
    protected ModalPopupExtender mpUserDataStep2;
    protected Panel pnlUserData;
    protected TextBox txtFirstName;
    protected RequiredFieldValidator rfvFirstName;
    protected TextBox txtLastName;
    protected RequiredFieldValidator rfvLastName;
    protected TextBox txtUsername;
    protected RequiredFieldValidator rfvUsername;
    protected TextBox txtPassword;
    protected RequiredFieldValidator rfvPassword;
    protected TextBox txtConfPassword;
    protected RequiredFieldValidator rfvConfPassword;
    protected CompareValidator cvPassword;
    protected TextBox txtAboutDoyingo;
    protected Button btnSubmitUserData;
    protected Panel pnlUserDataStep2;
    protected Label lblCompany;
    protected DropDownList ddlIndustry;
    protected DropDownList ddlBussiness;
    protected DropDownList ddlRunningFor;
        protected DropDownList ddlAboutDoyingo;
        protected DropDownList ddlCurrentAccount;
    protected Button btnUserDataStep2;
    protected LinkButton lnkClick;
    protected HiddenField hfCompanyID;
    protected SqlDataSource sqldsBussiness;
    protected SqlDataSource sqldsRunningFrom;
    protected SqlDataSource sqldsIndustry;
    protected SqlDataSource sqldsCurrentAccount;

    protected void Page_Load(object sender, EventArgs e)
    {
            txtAboutDoyingo.Text = ddlAboutDoyingo.SelectedItem.Text;
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("home")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("mainHome")).Attributes.Add("class", "active open");
      if (!this.IsPostBack)
      {
        if (this.Application["companyName"] != null && this.Application["emailAddress"] != null && (!string.IsNullOrEmpty(this.Application["companyName"].ToString()) && !string.IsNullOrEmpty(this.Application["emailAddress"].ToString())))
        {
          this.txtUsername.Text = this.Application["emailAddress"].ToString();
          this.mpUserData.Show();
        }
        MembershipUser user = Membership.GetUser();
        if (user != null)
        {
          string username = user.ToString();
          if (Roles.IsUserInRole(username, "Admin"))
            Doyingo.RoleName = "Admin";
          else if (Roles.IsUserInRole(username, "Employee"))
            Doyingo.RoleName = "Employee";
        }
        if (Doyingo.RoleName != null)
        {
          switch (Doyingo.RoleName)
          {
            case "MasterAdmin":
              this.pnlMasterAdmin.Visible = true;
              this.pnlCompanyAdmin.Visible = false;
              this.pnlEmployee.Visible = false;
              this.lblRole.Text = "Master Admin";
              this.Page.Title = "Master Admin Panel";
              break;
            case "Admin":
              this.pnlMasterAdmin.Visible = false;
              this.pnlCompanyAdmin.Visible = true;
              this.pnlEmployee.Visible = false;
              this.lblRole.Text = " [Company Admin]";
              this.Page.Title = "Company Admin Panel";
              break;
            case "Employee":
              this.pnlMasterAdmin.Visible = false;
              this.pnlCompanyAdmin.Visible = false;
              this.pnlEmployee.Visible = true;
              this.lblRole.Text = " [Staff]";
              this.Page.Title = "Staff Panel";
              this.SetWelcomeMessage();
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
      if (this.Request.QueryString["accId"] != null && this.Request.QueryString["Dated"] != null && this.Request.QueryString["add"] != null)
        this.AddAccountantToClient();
      if (this.Request.QueryString["re"] == null)
        return;
      this.SetNewDefaultValues();
      this.Response.Redirect("DefaultDoyingo.aspx");
    }

    private void SetWelcomeMessage()
    {
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
        else if (Roles.IsUserInRole(str, "Employee"))
        {
          this.objStaffMasterDT = this.objStaffMasterBll.GetDataByStaffUserName(str);
          if (this.objStaffMasterDT.Rows.Count > 0)
            this.hfCompanyID.Value = this.objStaffMasterDT.Rows[0]["CompanyID"].ToString();
        }
      }
      this.objMiscellaneousMasterDT = this.objMiscellaneousMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objMiscellaneousMasterDT.Rows.Count <= 0)
        return;
      this.lblStaffWelcomeMsg.Text = this.objMiscellaneousMasterDT.Rows[0]["WelcomeMessagesStaff"].ToString();
      this.welcomeDiv.Visible = !string.IsNullOrEmpty(this.lblStaffWelcomeMsg.Text);
    }

    private void SetNewDefaultValues()
    {
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
        else if (Roles.IsUserInRole(str, "Employee"))
        {
          this.objStaffMasterDT = this.objStaffMasterBll.GetDataByStaffUserName(str);
          if (this.objStaffMasterDT.Rows.Count > 0)
            this.hfCompanyID.Value = this.objStaffMasterDT.Rows[0]["CompanyID"].ToString();
        }
      }
      int num = 30;
      this.objFreePackageSettingsDT = this.objFreePackageSettingsBll.GetAllDetail();
      if (this.objFreePackageSettingsDT.Rows.Count > 0)
        num = int.Parse(this.objFreePackageSettingsDT.Rows[0]["FreePackageDays"].ToString());
      this.objCompanyPackageMasterDT = this.objCompanyPackageMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objCompanyPackageMasterDT.Rows.Count == 0)
        this.objCompanyPackageMasterBll.AddCompanyPackage(int.Parse(this.hfCompanyID.Value), 0, new DateTime?(DateTime.Now), new DateTime?(DateTime.Now.AddDays((double) num)), "FREE", new Decimal?(new Decimal(0)), "NONE", new DateTime?(), new DateTime?(DateTime.Now), true);
      this.objAdminPermissionMasterDT = this.objAdminPermissionMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objAdminPermissionMasterDT.Rows.Count == 0)
        this.objAdminPermissionMasterBll.AddAdminPermission(int.Parse(this.hfCompanyID.Value), true, true, true, false, false);
      this.objMiscellaneousMasterDT = this.objMiscellaneousMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objMiscellaneousMasterDT.Rows.Count == 0)
        this.objMiscellaneousMasterBll.AddMiscellaneous(int.Parse(this.hfCompanyID.Value), 15, "MM/dd/yyyy", true, true, true, "", true, false, "Both", "", "", "None", "Read/Write", 30, 10);
      this.objClientPermissionMasterDT = this.objClientPermissionMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objClientPermissionMasterDT.Rows.Count == 0)
        this.objClientPermissionMasterBll.AddClientPermission(int.Parse(this.hfCompanyID.Value), true, true, true, false, false, true, true);
      this.objStaffPermissionMasterDT = this.objStaffPermissionMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objStaffPermissionMasterDT.Rows.Count == 0)
        this.objStaffPermissionMasterBll.AddStaffPermission(int.Parse(this.hfCompanyID.Value), true, true, true, true, true, false, false, true, true, true, true, true);
      this.objTemplateSettingsDT = this.objTemplateSettingsBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objTemplateSettingsDT.Rows.Count == 0)
        this.objTemplateSettingsBll.AddTemplateSettings(int.Parse(this.hfCompanyID.Value), 1, "Invoice", "Estimate", "Credit", true);
      this.objEmailNotificationsDT = this.objEmailNotificationsBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objEmailNotificationsDT.Rows.Count == 0)
        this.objEmailNotificationsBll.AddEmailNotifications(int.Parse(this.hfCompanyID.Value), true, false, false, false);
      this.objSMTPSettingsDT = this.objSMTPSettingsBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objSMTPSettingsDT.Rows.Count == 0)
          this.objSMTPSettingsBll.AddSMTPSettings(int.Parse(this.hfCompanyID.Value), Common.CommonHandler.BaseMailFrom, Common.CommonHandler.BaseHost , Convert.ToInt32(Common.CommonHandler.BasePort), Common.CommonHandler.BaseEnableSSL, Common.CommonHandler.BasePassword, Common.CommonHandler.BaseUserName, "Best regards,<br />##companyName## (##companyEmail##)");
      this.objNewClientEmailTemplateDT = this.objNewClientEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objNewClientEmailTemplateDT.Rows.Count == 0)
          this.objNewClientEmailTemplateBll.AddClientTemplate(int.Parse(this.hfCompanyID.Value), "##companyName## is now invoicing you with Bill Transact", new StringBuilder("Welcome to ##companyName##'s secure online services.  An account has been created for you.<br />To securely access your account, go to:<br />##login link##<br />Login using the following username and password:<br />Username: ##username##<br />Password: ##password##<br />").ToString());
      this.objNewCreditEmailTemplateDT = this.objNewCreditEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objNewCreditEmailTemplateDT.Rows.Count == 0)
          this.objNewCreditEmailTemplateBll.AddCreditTemplate(int.Parse(this.hfCompanyID.Value), "New Credit ##creditNumber## from ##companyName## , sent using Bill Transact", new StringBuilder("You have received credit in the amount of ##paymentAmt##. To view it and download a PDF copy for your records, click the link below.<br /><br />##creditLink##<br />").ToString());
      this.objNewEstimateEmailTemplateDT = this.objNewEstimateEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objNewEstimateEmailTemplateDT.Rows.Count == 0)
          this.objNewEstimateEmailTemplateBll.AddEstimateTemplate(int.Parse(this.hfCompanyID.Value), "New Estimate ##estimateNumber## from ##companyName## , sent using Bill Transact", new StringBuilder("To access your estimate from ##companyName## for ##paymentAmt##, go to:<br /><br /> ##estimateLink##<br />").ToString());
      this.objNewInvoiceEmailTemplateDT = this.objNewInvoiceEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objNewInvoiceEmailTemplateDT.Rows.Count == 0)
          this.objNewInvoiceEmailTemplateBll.AddInvoiceTemplate(int.Parse(this.hfCompanyID.Value), "New invoice ##invoiceNumber## from ##companyName## , sent using Bill Transact", new StringBuilder("To view your invoice from ##companyName## for ##invoiceAmt##, or to download a PDF copy for your records, click the link below:<br /><br />##someLink##<br /><br />").ToString());
      this.objNewStaffEmailTemplateDT = this.objNewStaffEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objNewStaffEmailTemplateDT.Rows.Count == 0)
          this.objNewStaffEmailTemplateBll.AddStaffTemplate(int.Parse(this.hfCompanyID.Value), "##companyName## invites you to track time and expenses in Bill Transact", new StringBuilder("You are now part of ##companyName##'s team.<br />Click here to log in to your account:<br />##login link##<br /><br />Username: ##username##<br />Password: ##password##<br />").ToString());
      this.objNewPaymentEmailTemplateDT = this.objNewPaymentEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value), "online");
      if (this.objNewPaymentEmailTemplateDT.Rows.Count == 0)
          this.objNewPaymentEmailTemplateBll.AddPaymentTemplate(int.Parse(this.hfCompanyID.Value), "online", true, "##companyName## has received your payment for invoice ##invoiceNumber## in Bill Transact", new StringBuilder("Thank you for your business.<br />We have received your payment in the amount of ##payment amount## for invoice ##invoice number##.<br />To view the paid invoice or download a PDF copy for your records, click the link below:<br /><br />##someLink##<br />").ToString());
      this.objNewPaymentEmailTemplateDT = this.objNewPaymentEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value), "other");
      if (this.objNewPaymentEmailTemplateDT.Rows.Count == 0)
          this.objNewPaymentEmailTemplateBll.AddPaymentTemplate(int.Parse(this.hfCompanyID.Value), "other", false, "##companyName## has received your payment for invoice ##invoiceNumber## in Bill Transact", new StringBuilder("Thank you for your business.<br />We have received your payment in the amount of ##payment amount## for invoice ##invoice number##.<br />To view the paid invoice or download a PDF copy for your records, click the link below:<br /><br />##someLink##<br />").ToString());
      this.objLatePaymentReminderTemplateDT = this.objLatePaymentReminderTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value), 1);
      if (this.objLatePaymentReminderTemplateDT.Rows.Count == 0)
          this.objLatePaymentReminderTemplateBll.AddLatePaymentReminder(int.Parse(this.hfCompanyID.Value), 1, false, 30, "Your payment for invoice ##invoiceNumber## is overdue in Bill Transact", new StringBuilder("Your invoice is now 30 days overdue.  Please pay your invoice.<br /><br />To access your invoice from ##companyName##, go to:<br /><br />##someLink##<br />").ToString());
      this.objLatePaymentReminderTemplateDT = this.objLatePaymentReminderTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value), 2);
      if (this.objLatePaymentReminderTemplateDT.Rows.Count == 0)
          this.objLatePaymentReminderTemplateBll.AddLatePaymentReminder(int.Parse(this.hfCompanyID.Value), 2, false, 60, "Your payment for invoice ##invoiceNumber## is overdue in Bill Transact", new StringBuilder("Your invoice is now 60 days overdue.  Please pay your invoice.<br /><br />To access your invoice from ##companyName##, go to:<br /><br />##someLink##<br />").ToString());
      this.objLatePaymentReminderTemplateDT = this.objLatePaymentReminderTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value), 3);
      if (this.objLatePaymentReminderTemplateDT.Rows.Count == 0)
          this.objLatePaymentReminderTemplateBll.AddLatePaymentReminder(int.Parse(this.hfCompanyID.Value), 3, false, 90, "Your payment for invoice ##invoiceNumber## is overdue in Bill Transact", new StringBuilder("Your invoice is now 90 days overdue.  Please pay your invoice.<br /><br />To access your invoice from ##companyName##, go to:<br /><br />##someLink##<br />").ToString());
      this.objAutoBillEmailTemplateDT = this.objAutoBillEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value), "Auto-bill");
      if (this.objAutoBillEmailTemplateDT.Rows.Count == 0)
          this.objAutoBillEmailTemplateBll.AddAutoBillEmail(int.Parse(this.hfCompanyID.Value), "Auto-bill", true, "New recurring invoice ##invoiceNumber## from ##companyName##, sent using Bill Transact", this.strBodyBill.ToString());
      this.objAutoBillEmailTemplateDT = this.objAutoBillEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value), "Auto-paid");
      if (this.objAutoBillEmailTemplateDT.Rows.Count == 0)
          this.objAutoBillEmailTemplateBll.AddAutoBillEmail(int.Parse(this.hfCompanyID.Value), "Auto-paid", true, "New recurring invoice ##invoiceNumber## from ##companyName##, sent using Bill Transact", this.strBodyPaid.ToString());
      this.objAutoBillEmailTemplateDT = this.objAutoBillEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value), "Card Expired");
      if (this.objAutoBillEmailTemplateDT.Rows.Count == 0)
          this.objAutoBillEmailTemplateBll.AddAutoBillEmail(int.Parse(this.hfCompanyID.Value), "Card Expired", true, "Action required: Your credit card on file with ##companyName## is expiring soon in Bill Transact", this.strBodyExpired.ToString());
      this.objAutoBillEmailTemplateDT = this.objAutoBillEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value), "Card Failed");
      if (this.objAutoBillEmailTemplateDT.Rows.Count != 0)
        return;
      this.objAutoBillEmailTemplateBll.AddAutoBillEmail(int.Parse(this.hfCompanyID.Value), "Card Failed", false, "Action required: Your credit card on file for invoice ##invoiceNumber## from ##companyName## needs updating in Bill Transact", this.strBodyFailed.ToString());
    }

    private void AddAccountantToClient()
    {
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
      int iAccountantID = int.Parse(this.Request.QueryString["accId"]);
      DateTime dateTime = DateTime.Parse(this.Request.QueryString["Dated"]);
      int num = 0;
      this._objAccountantClientDetailDt = this._objAccountantClientDetailBll.GetDataByAccountantID(iAccountantID);
      if (this._objAccountantClientDetailDt.Rows.Count > 0)
      {
        for (int index = 0; index < this._objAccountantClientDetailDt.Rows.Count; ++index)
        {
          if (this.hfCompanyID.Value == this._objAccountantClientDetailDt.Rows[index]["CompanyID"].ToString())
          {
            ++num;
            break;
          }
        }
      }
      if (num == 0)
        this._objAccountantClientDetailBll.AddAccountantClient(iAccountantID, int.Parse(this.hfCompanyID.Value), false, true, new DateTime?(dateTime), new DateTime?(DateTime.Now));
      this.Response.Redirect("DefaultDoyingo.aspx");
    }

    protected async void BtnSubmitUserDataClick(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      FileStream fileStream = new FileStream(this.Server.MapPath("~/App_Themes/sky/uploads/logo.png"), FileMode.Open, FileAccess.Read);
      byte[] numArray = new byte[fileStream.Length];
      fileStream.Read(numArray, 0, (int) fileStream.Length);
      fileStream.Close();
      int iCompanyID = this.objCompanyMasterBll.AddCompany(this.txtUsername.Text.Trim(), this.Application["companyName"].ToString(), this.txtFirstName.Text.Trim() + " " + this.txtLastName.Text.Trim(), "", new Decimal?(new Decimal(0)), new int?(), new int?(), new int?(), new int?(), new int?(), "", "", this.txtUsername.Text.Trim(), "", "", new int?(), new int?(), new int?(), "", "application/jpg", numArray, "", "", false, "");
      if (iCompanyID != 0)
      {
        this.Application["companyId"] = (object) iCompanyID;
        this.objCompanyLoginMasterBll.AddCompanyLogin(iCompanyID, this.txtUsername.Text.Trim(), this.txtUsername.Text.Trim(), true);
        int num = 30;
        this.objFreePackageSettingsDT = this.objFreePackageSettingsBll.GetAllDetail();
        if (this.objFreePackageSettingsDT.Rows.Count > 0)
          num = int.Parse(this.objFreePackageSettingsDT.Rows[0]["FreePackageDays"].ToString());
        this.objCompanyPackageMasterBll.AddCompanyPackage(iCompanyID, 0, new DateTime?(DateTime.Now), new DateTime?(DateTime.Now.AddDays((double) num)), "FREE", new Decimal?(new Decimal(0)), "NONE", new DateTime?(), new DateTime?(DateTime.Now), true);
        this.objMiscellaneousMasterBll.AddMiscellaneous(iCompanyID, 15, "MM/dd/yyyy", true, true, true, "", true, false, "Both", "", "", "None", "Read/Write", 30, 10);
        this.objAdminPermissionMasterBll.AddAdminPermission(iCompanyID, true, true, true, false, false);
        this.objClientPermissionMasterBll.AddClientPermission(iCompanyID, true, true, true, false, false, true, true);
        this.objStaffPermissionMasterBll.AddStaffPermission(iCompanyID, true, true, true, true, true, false, false, true, true, true, true, true);
        this.objTemplateSettingsBll.AddTemplateSettings(iCompanyID, 1, "Invoice", "Estimate", "Credit", true);
        MembershipCreateStatus status;
        Membership.CreateUser(this.txtUsername.Text.Trim(), this.txtPassword.Text.Trim(), this.txtUsername.Text.Trim(), "What is your User Name?", this.txtUsername.Text, true, out status);
        Roles.AddUserToRole(this.txtUsername.Text, "Admin");
       await this.SendMail(this.txtUsername.Text.Trim(), this.txtPassword.Text.Trim());
        if (this.Request.QueryString["accId"] != null && this.Request.QueryString["Dated"] != null)
        {
          int iAccountantID = int.Parse(this.Request.QueryString["accId"]);
          DateTime dateTime = DateTime.Parse(this.Request.QueryString["Dated"]);
          this._objAccountantClientDetailBll.AddAccountantClient(iAccountantID, iCompanyID, false, true, new DateTime?(dateTime), new DateTime?(DateTime.Now));
        }
      }
      else
        this.DisplayAlert("Problem In Insertion. Try again Later.");
      this.lblCompany.Text = this.txtFirstName.Text.Trim();
      this.mpUserData.Hide();
      this.mpUserDataStep2.Show();
    }

    private async Task SendMail(string email, string pass)
    {
      Parser parser = new Parser(this.Server.MapPath("~/MailTemplate/NewCompanySignUp.html"), new Hashtable()
      {
        {
          (object) "username",
          (object) email
        },
        {
          (object) "password",
          (object) pass
        }
      });
      try
      {
                //MailMessage message = new MailMessage()
                //{
                //  From = new MailAddress("support@wejustlink.ca", "Bill Transact")
                //https://www.billtransact.com/
                //};
                //message.To.Add(new MailAddress(email));
                //message.Subject = "Welcome to Bill Transact! Here are your account details";
                //message.BodyEncoding = Encoding.UTF8;
                //message.Body = parser.Parse();
                //message.IsBodyHtml = true;
                //        //new SmtpClient().Send(message);

                //        SmtpClient smtp =  new SmtpClient("mail.wejustlink.ca");
                //        smtp.Credentials = new NetworkCredential("support@wejustlink.ca", "Yasmin@55");
                //        smtp.Send(message);

                //Common.CommonHandler.SendSMTPEmail("0", email, "Welcome to Bill Transact! Here are your account details", parser.Parse(), true);
                await Common.CommonHandler.SendMail("0", email, "Welcome to Bill Transact! Here are your account details", parser.Parse(), true);
            }
      catch (Exception ex)
      {
        this.DisplayAlert("Error in sending mail." + (object) ex);
      }
    }

    protected string GetCurrency(string cID)
    {
      this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(cID));
      if (this.objCurrencyMasterDT.Rows.Count > 0)
        return this.objCurrencyMasterDT.Rows[0]["CurrencySymbol"].ToString();
      return "";
    }

    public void DisplayAlert(string message)
    {
      this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">" + this.GetAlertScript(message) + "</script>");
    }

    public string GetAlertScript(string message)
    {
      return "alert('" + message.Replace("'", "\\'") + "');";
    }

    protected void btnUserDataStep2_Click(object sender, EventArgs e)
    {
      int? iBussinessID = new int?();
      int? iIndustryID = new int?();
      int? iRunningID = new int?();
      int? iCurrentAccountID = new int?();
      if (this.ddlBussiness.SelectedIndex > 0)
        iBussinessID = new int?(int.Parse(this.ddlBussiness.SelectedItem.Value));
      if (this.ddlIndustry.SelectedIndex > 0)
        iIndustryID = new int?(int.Parse(this.ddlIndustry.SelectedItem.Value));
      if (this.ddlCurrentAccount.SelectedIndex > 0)
        iCurrentAccountID = new int?(int.Parse(this.ddlCurrentAccount.SelectedItem.Value));
      if (this.ddlRunningFor.SelectedIndex > 0)
        iRunningID = new int?(int.Parse(this.ddlRunningFor.SelectedItem.Value));
      this.objCompanyMasterBll.UpdateSignUpIDs(int.Parse(this.Application["companyId"].ToString()), iBussinessID, iIndustryID, iCurrentAccountID, iRunningID);
      this.Application.Clear();
      FormsAuthentication.RedirectFromLoginPage(this.txtUsername.Text.Trim(), false);
      this.Response.Redirect("~/Admin/DefaultDoyingo.aspx");
    }
  }
}

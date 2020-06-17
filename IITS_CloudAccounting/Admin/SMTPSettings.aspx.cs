// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.SMTPSettings
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using DABL.BLL;
using DABL.DAL;
using System;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class SMTPSettings : Page
  {
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
    private readonly SMTPSettingsBLL objSMTPSettingsBll = new SMTPSettingsBLL();
    private CloudAccountDA.SMTPSettingsDataTable objSMTPSettingsDT = new CloudAccountDA.SMTPSettingsDataTable();
    protected Label lblCompanyName;
    protected Label lblEmail;
    protected TextBox txtSMTPFrom;
    protected RequiredFieldValidator rfvsmtpFrom;
    protected TextBox txtHost;
    protected RequiredFieldValidator rfvHost;
    protected TextBox txtPort;
    protected RequiredFieldValidator rfvPort;
    protected CheckBox chkEnableSSL;
    protected TextBox txtUsername;
    protected RequiredFieldValidator rfvUsername;
    protected TextBox txtPassword;
    protected RequiredFieldValidator rfvPassword;
    protected TextBox txtEmailSignature;
    protected TextBox txtEmailCheck;
    protected RequiredFieldValidator rfvEmail;
    protected RegularExpressionValidator revEmail;
    protected Button btnCheck;
    protected Label lblError;
    protected Button btnSave;
    protected HiddenField hfCompanyID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("setting")).Attributes.Add("style", "background-color: lightgray;");
      ((HtmlControl) this.Master.FindControl("smtp")).Attributes.Add("class", "active open");
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
      if (this.IsPostBack)
        return;
      this.SetData(this.hfCompanyID.Value);
    }

    private void SetData(string companyID)
    {
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(companyID));
      if (this.objCompanyMasterDT.Rows.Count > 0)
      {
        this.lblCompanyName.Text = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
        this.lblEmail.Text = this.objCompanyMasterDT.Rows[0]["CompanyEmail"].ToString();
      }
      this.objSMTPSettingsDT = this.objSMTPSettingsBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objSMTPSettingsDT.Rows.Count > 0)
      {
        this.txtEmailSignature.Text = this.objSMTPSettingsDT.Rows[0]["EmailSignature"].ToString();
        this.txtEmailSignature.Text = this.txtEmailSignature.Text.Replace("<br />", "\n");
        this.txtEmailSignature.Text = this.txtEmailSignature.Text.Replace("##companyName##", this.lblCompanyName.Text);
        this.txtEmailSignature.Text = this.txtEmailSignature.Text.Replace("##companyEmail##", this.lblEmail.Text);
        this.txtHost.Text = this.objSMTPSettingsDT.Rows[0]["Host"].ToString();
        this.txtSMTPFrom.Text = this.objSMTPSettingsDT.Rows[0]["SMTPFrom"].ToString();
        this.txtPort.Text = this.objSMTPSettingsDT.Rows[0]["Port"].ToString();
        this.txtPassword.Text = this.objSMTPSettingsDT.Rows[0]["Password"].ToString();
        this.txtUsername.Text = this.objSMTPSettingsDT.Rows[0]["Username"].ToString();
        this.chkEnableSSL.Checked = bool.Parse(this.objSMTPSettingsDT.Rows[0]["EnableSSL"].ToString());
        this.txtPassword.Attributes["type"] = "password";
      }
      else
      {
          this.objSMTPSettingsBll.AddSMTPSettings(int.Parse(this.hfCompanyID.Value), "noreply@billtransact.com", "mail.billtransact.com", new int?(25), false, "bayaka20@25", "noreply@billtransact.com", "Best regards,<br />##companyName## (##companyEmail##)");
        this.Response.Redirect("SMTPSettings.aspx");
      }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      this.btnCheck_Click(sender, e);
      if (string.IsNullOrEmpty(this.lblError.Text) || !(this.lblError.ForeColor == Color.Green))
        return;
      int num = 0;
      bool flag = false;
      this.objSMTPSettingsDT = this.objSMTPSettingsBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objSMTPSettingsDT.Rows.Count > 0)
      {
        string s = this.objSMTPSettingsDT.Rows[0]["SMTPSettingsID"].ToString();
        int? iPort = new int?();
        if (this.txtPort.Text.Trim().Length > 0)
          iPort = new int?(int.Parse(this.txtPort.Text));
        this.txtEmailSignature.Text = this.txtEmailSignature.Text.Replace("\n", "<br />");
        this.txtEmailSignature.Text = this.txtEmailSignature.Text.Replace(this.lblCompanyName.Text, "##companyName##");
        this.txtEmailSignature.Text = this.txtEmailSignature.Text.Replace(this.lblEmail.Text, "##companyEmail##");
        flag = this.objSMTPSettingsBll.UpdateSMTPSettings(int.Parse(s), int.Parse(this.hfCompanyID.Value), this.txtSMTPFrom.Text, this.txtHost.Text.Trim(), iPort, this.chkEnableSSL.Checked, this.txtPassword.Text, this.txtUsername.Text, this.txtEmailSignature.Text);
      }
      else
      {
        int? iPort = new int?();
        if (this.txtPort.Text.Trim().Length > 0)
          iPort = new int?(int.Parse(this.txtPort.Text));
        this.txtEmailSignature.Text = this.txtEmailSignature.Text.Replace("\n", "<br />");
        this.txtEmailSignature.Text = this.txtEmailSignature.Text.Replace(this.lblCompanyName.Text, "##companyName##");
        this.txtEmailSignature.Text = this.txtEmailSignature.Text.Replace(this.lblEmail.Text, "##companyEmail##");
        num = this.objSMTPSettingsBll.AddSMTPSettings(int.Parse(this.hfCompanyID.Value), this.txtSMTPFrom.Text, this.txtHost.Text.Trim(), iPort, this.chkEnableSSL.Checked, this.txtPassword.Text, this.txtUsername.Text, this.txtEmailSignature.Text);
      }
      if (num == 0 && !flag)
        return;
      this.Response.Redirect("SMTPSettings.aspx");
    }

    protected void btnCheck_Click(object sender, EventArgs e)
    {
      this.lblError.Text = "";
      try
      {
        //MailMessage message = new MailMessage()
        //{
        //  From = new MailAddress("noreply@DoyniGo.com", "DoyniGo")
        //};
        //message.To.Add(new MailAddress(this.txtEmailCheck.Text));
        //message.Subject = "Test Mail, sent using DoyinGo";
        //message.BodyEncoding = Encoding.UTF8;
        //message.Body = "hi..<br /><br /> <b>This is test mail to check SMTP Settings..</b><br /><br /><hr /><span style=\"color:Red;text-align: center;\">This is system generated mail. Please don't reply on it.</span><hr />";
        //message.IsBodyHtml = true;
        Common.CommonHandler.CheckSMTPEmail(txtHost.Text.Trim(), txtPort.Text.Trim(), chkEnableSSL.Checked, txtUsername.Text.Trim(), txtPassword.Text.Trim(), txtEmailCheck.Text.Trim(), "Test Mail, sent using Bill Transact", "hi..<br /><br /> <b>This is test mail to check SMTP Settings..</b><br /><br /><hr /><span style=\"color:Red;text-align: center;\">This is system generated mail. Please don't reply on it.</span><hr />", true);
                this.lblError.Text = "Mail Sent Successfully.";
                this.lblError.ForeColor = Color.Green;
                //        NetworkCredential networkCredential = new NetworkCredential(this.txtUsername.Text, this.txtPassword.Text);
                //new SmtpClient()
                //{
                //  Port = int.Parse(this.txtPort.Text),
                //  Host = this.txtHost.Text,
                //  EnableSsl = this.chkEnableSSL.Checked,
                //  UseDefaultCredentials = true,
                //  Credentials = ((ICredentialsByHost) networkCredential)
                //}.Send(message);

            }
      catch (SmtpException ex)
      {
        this.lblError.Text = "SMTP Error in sending mail." + ex.Message;
        this.lblError.ForeColor = Color.Red;
      }
      catch (Exception ex)
      {
        this.lblError.Text = "General Error in sending mail." + ex.Message;
        this.lblError.ForeColor = Color.Red;
      }
    }
  }
}

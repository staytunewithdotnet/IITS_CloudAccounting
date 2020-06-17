// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.InviteAccountant
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Collections;
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
  public class InviteAccountant : Page
  {
    private readonly CompanyLoginMasterBLL _objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable _objCompanyLoginMasterDt = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyMasterBLL _objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable _objCompanyMasterDt = new CloudAccountDA.CompanyMasterDataTable();
    private readonly SMTPSettingsBLL _objSmtpSettingsBll = new SMTPSettingsBLL();
    private CloudAccountDA.SMTPSettingsDataTable _objSmtpSettingsDt = new CloudAccountDA.SMTPSettingsDataTable();
    private readonly AccountantClientDetailBLL _objAccountantClientDetailBll = new AccountantClientDetailBLL();
    protected ToolkitScriptManager ToolkitScriptManager1;
    protected Button btnAdd;
    protected Button btnRemove;
    protected DataList dlClientByYou;
    protected SqlDataSource sqldsClientByYou;
    protected HiddenField hfCompanyID;
    protected ModalPopupExtender mpInviteAcc1;
    protected ModalPopupExtender mpInviteAcc2;
    protected Panel pnlInviteAcc1;
    protected LinkButton lnkSecondOpen;
    protected LinkButton lnkCloseFirst;
    protected Panel pnlInviteAcc2;
    protected TextBox txtEmailAddress;
    protected RequiredFieldValidator rfvEmail;
    protected RegularExpressionValidator revEmail;
    protected Label lblSubject;
    protected Label lblCompanyPerson;
    protected Label lblCompanyName;
    protected TextBox txtDesc;
    protected Button btnSend;
    protected LinkButton lnkSecondClose;
    protected HiddenField hfEmail;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("userManagement")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("accountant")).Attributes.Add("class", "active open");
      MembershipUser user = Membership.GetUser();
      if (user != null)
      {
        string str = user.ToString();
        if (Roles.IsUserInRole(str, "Admin"))
        {
          this._objCompanyLoginMasterDt = this._objCompanyLoginMasterBll.GetDataByCompanyLoginName(str);
          if (this._objCompanyLoginMasterDt.Rows.Count > 0)
            this.hfCompanyID.Value = this._objCompanyLoginMasterDt.Rows[0]["CompanyID"].ToString();
        }
      }
      if (this.IsPostBack)
        return;
      this.dlClientByYou.DataBind();
      if (this.dlClientByYou.Items.Count > 0)
      {
        this.btnAdd.Visible = false;
        this.btnRemove.Visible = true;
      }
      else
      {
        this.btnAdd.Visible = true;
        this.btnRemove.Visible = false;
      }
      this.SetSomeRecords();
    }

    private void SetSomeRecords()
    {
      if (string.IsNullOrEmpty(this.hfCompanyID.Value))
        return;
      this._objCompanyMasterDt = this._objCompanyMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this._objCompanyMasterDt.Rows.Count <= 0)
        return;
      this.lblCompanyPerson.Text = this._objCompanyMasterDt.Rows[0]["CompanyContactPerson"].ToString();
      this.lblSubject.Text = this.lblCompanyPerson.Text + " has invited you to Bill Transact as their Accountant";
      this.lblCompanyName.Text = this._objCompanyMasterDt.Rows[0]["CompanyName"].ToString();
      this.hfEmail.Value = this._objCompanyMasterDt.Rows[0]["CompanyEmail"].ToString();
    }

    protected async void BtnSendClick(object sender, EventArgs e)
    {
      if (this.txtEmailAddress.Text.Trim().Length > 0)
       await  this.SendMail(this.txtEmailAddress.Text.Trim());
      else
        this.DisplayAlert("Please Provide Accountant's Email Address.");
    }

    private async Task SendMail(string email)
    {
      Hashtable Variables = new Hashtable()
      {
        {
          (object) "CompanyName",
          (object) this.lblCompanyName.Text.Trim()
        },
        {
          (object) "ContactPerson",
          (object) this.lblCompanyPerson.Text.Trim()
        },
        {
          (object) "CompanyDesc",
          (object) this.txtDesc.Text.Trim()
        },
        {
          (object) "URL",
          (object) ("http://www.billtransact.com/AccountantSignUp.aspx?cmd=register&cmdId=" + this.hfCompanyID.Value + "&Dated=" + DateTime.Now.ToString("dd-MMM-yyyy"))
        }
      };
      //string address = "noreply@DoyniGo.com";
      //this._objSmtpSettingsDt = this._objSmtpSettingsBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      //if (this._objSmtpSettingsDt.Rows.Count > 0)
        //address = this._objSmtpSettingsDt.Rows[0]["SMTPFrom"].ToString();
      Parser parser = new Parser(this.Server.MapPath("~/MailTemplate/AccountantInvitation.html"), Variables);
      try
      {
                //MailMessage message = new MailMessage()
                //{
                //  From = new MailAddress(address, this.lblCompanyName.Text.ToUpper())
                //};
                //message.To.Add(new MailAddress(email));
                //message.ReplyToList.Add(this.hfEmail.Value);
                //message.Subject = this.lblSubject.Text;
                //message.BodyEncoding = Encoding.UTF8;
                //message.Body = parser.Parse();
                //message.IsBodyHtml = true;
                //SmtpClientForCompany.smtpClient(this.hfCompanyID.Value).Send(message);
                Common.CommonHandler.SendSMTPEmail(hfCompanyID.Value, email, lblSubject.Text, parser.Parse(), true);
                //await Common.CommonHandler.SendMail(hfCompanyID.Value, email, lblSubject.Text, parser.Parse(), true);
            }
      catch (Exception ex)
      {
        this.DisplayAlert("Error in sending mail." + (object) ex);
      }
    }

    public void DisplayAlert(string message)
    {
      this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">" + this.GetAlertScript(message) + "</script>");
    }

    public string GetAlertScript(string message)
    {
      return "alert('" + message.Replace("'", "\\'") + "');";
    }

    protected void BtnRemoveClick(object sender, EventArgs e)
    {
      if (this.dlClientByYou.Items.Count <= 0)
        return;
      Label label = (Label) this.dlClientByYou.Items[0].FindControl("AccountantClientDetailIDLabel");
      if (label == null)
        return;
      this._objAccountantClientDetailBll.DeleteAccountantClient(int.Parse(label.Text));
      this.Response.Redirect("InviteAccountant.aspx");
    }
  }
}

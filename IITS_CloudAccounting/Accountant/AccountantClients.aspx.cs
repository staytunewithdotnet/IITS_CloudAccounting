// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Accountant.AccountantClients
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
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TemplateParser;

namespace IITS_CloudAccounting.Accountant
{
  public class AccountantClients : Page
  {
    private readonly AccountantMasterBLL _objAccountantMasterBll = new AccountantMasterBLL();
    private CloudAccountDA.AccountantMasterDataTable _objAccountantMasterDt = new CloudAccountDA.AccountantMasterDataTable();
    private readonly AccountantClientDetailBLL _objAccountantClientDetailBll = new AccountantClientDetailBLL();
    private CloudAccountDA.AccountantClientDetailDataTable _objAccountantClientDetailDt = new CloudAccountDA.AccountantClientDetailDataTable();
    protected Button btnClient;
    protected DataList dlClientByYou;
    protected SqlDataSource sqldsClientByYou;
    protected DataList dlYouByClient;
    protected SqlDataSource sqldsYouByClient;
    protected HiddenField hfAccountantID;
    protected ModalPopupExtender mpInviteAcc2;
    protected Panel pnlInviteAcc2;
    protected TextBox txtEmailAddress;
    protected RequiredFieldValidator rfvEmail;
    protected RegularExpressionValidator revEmail;
    protected Label lblSubject;
    protected Label lblAccountant;
    protected Label lblAccountantCompany;
    protected TextBox txtDesc;
    protected Button btnSend;
    protected LinkButton lnkSecondClose;
    protected HiddenField hfEmail;

    protected void Page_Load(object sender, EventArgs e)
    {
      MembershipUser user = Membership.GetUser();
      if (user != null)
      {
        string str = user.ToString();
        if (Roles.IsUserInRole(str, "Accountant"))
        {
          this._objAccountantMasterDt = this._objAccountantMasterBll.GetDataByAccountantEmail(str);
          if (this._objAccountantMasterDt.Rows.Count > 0)
            this.hfAccountantID.Value = this._objAccountantMasterDt.Rows[0]["AccountantID"].ToString();
        }
      }
      if (this.Request.QueryString["cmdId"] != null && this.Request.QueryString["Dated"] != null && this.Request.QueryString["addClient"] != null)
        this.AddClientToAccountant();
      this.SetSomeRecords();
    }

    private void AddClientToAccountant()
    {
      int iCompanyID = int.Parse(this.Request.QueryString["cmdId"]);
      DateTime dateTime = DateTime.Parse(this.Request.QueryString["Dated"]);
      int num = 0;
      this._objAccountantClientDetailDt = this._objAccountantClientDetailBll.GetDataByCompanyID(iCompanyID);
      if (this._objAccountantClientDetailDt.Rows.Count > 0)
      {
        for (int index = 0; index < this._objAccountantClientDetailDt.Rows.Count; ++index)
        {
          if (this.hfAccountantID.Value == this._objAccountantClientDetailDt.Rows[index]["AccountantID"].ToString())
          {
            ++num;
            break;
          }
        }
      }
      if (num == 0)
        this._objAccountantClientDetailBll.AddAccountantClient(int.Parse(this.hfAccountantID.Value), iCompanyID, true, false, new DateTime?(dateTime), new DateTime?(DateTime.Now));
      this.Response.Redirect("AccountantClients.aspx");
    }

    private void SetSomeRecords()
    {
      if (string.IsNullOrEmpty(this.hfAccountantID.Value))
        return;
      this._objAccountantMasterDt = this._objAccountantMasterBll.GetDataByAccountantID(int.Parse(this.hfAccountantID.Value));
      if (this._objAccountantMasterDt.Rows.Count <= 0)
        return;
      this.lblAccountant.Text = (string) this._objAccountantMasterDt.Rows[0]["AccountantFirstName"] + (object) " " + (string) this._objAccountantMasterDt.Rows[0]["AccountantLastName"];
      this.lblSubject.Text = this.lblAccountant.Text + " has invited you to connect using Bill Transact ";
      this.lblAccountantCompany.Text = this._objAccountantMasterDt.Rows[0]["CompanyName"].ToString();
      this.hfEmail.Value = this._objAccountantMasterDt.Rows[0]["AccountantEmail"].ToString();
    }

    protected void BtnSendClick(object sender, EventArgs e)
    {
      if (this.txtEmailAddress.Text.Trim().Length > 0)
        this.SendMail(this.txtEmailAddress.Text.Trim());
      else
        this.DisplayAlert("Please Provide Accountant's Email Address.");
    }

    private void SendMail(string email)
    {
      Parser parser = new Parser(this.Server.MapPath("~/MailTemplate/ClientInvitation.html"), new Hashtable()
      {
        {
          (object) "CompanyName",
          (object) this.lblAccountantCompany.Text.Trim()
        },
        {
          (object) "ContactPerson",
          (object) this.lblAccountant.Text.Trim()
        },
        {
          (object) "CompanyDesc",
          (object) this.txtDesc.Text.Trim()
        },
        {
          (object) "URL",
          (object) ("http://www.billtransact.com/InviteCompanyByAccountant.aspx?cmd=register&accId=" + this.hfAccountantID.Value + "&Dated=" + DateTime.Now.ToString("dd-MMM-yyyy"))
        }
      });
      try
      {
        MailMessage message = new MailMessage()
        {
          From = new MailAddress("noreply@DoyniGo.com", this.lblAccountant.Text)
        };
        message.To.Add(new MailAddress(email));
        message.ReplyToList.Add(this.hfEmail.Value);
        message.Subject = this.lblSubject.Text;
        message.BodyEncoding = Encoding.UTF8;
        message.Body = parser.Parse();
        message.IsBodyHtml = true;
        new SmtpClient().Send(message);
        this.DisplayAlert("Your Invitation is Sent To Client.");
        this.txtEmailAddress.Text = "";
        this.txtDesc.Text = "Bill Transact allows you to easily capture your business transactions and provides me with the information I need, reducing the stress of tax time.";
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

    protected void lnkRemoveFromClient_OnClick(object sender, EventArgs e)
    {
    }

    protected void lnkRemoveByClient_OnClick(object sender, EventArgs e)
    {
    }
  }
}

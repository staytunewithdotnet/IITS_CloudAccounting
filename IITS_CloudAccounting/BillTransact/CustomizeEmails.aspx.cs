// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.CustomizeEmails
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
  public class CustomizeEmails : Page
  {
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
    private readonly EmailNotificationsBLL objEmailNotificationsBll = new EmailNotificationsBLL();
    private CloudAccountDA.EmailNotificationsDataTable objEmailNotificationsDT = new CloudAccountDA.EmailNotificationsDataTable();
    protected Label lblCompanyName;
    protected Label lblEmail;
    protected CheckBox chkWeekAccount;
    protected CheckBox chkPayment;
    protected CheckBox chkPaymentReceive;
    protected CheckBox chkInvoice;
    protected Button btnSave;
    protected HiddenField hfCompanyID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("setting")).Attributes.Add("style", "background-color: lightgray;");
      ((HtmlControl) this.Master.FindControl("emails")).Attributes.Add("class", "active open");
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
      this.objEmailNotificationsDT = this.objEmailNotificationsBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objEmailNotificationsDT.Rows.Count > 0)
      {
        this.chkWeekAccount.Checked = bool.Parse(this.objEmailNotificationsDT.Rows[0]["WeeklySummary"].ToString());
        this.chkPaymentReceive.Checked = bool.Parse(this.objEmailNotificationsDT.Rows[0]["PaymentReceived"].ToString());
        this.chkPayment.Checked = bool.Parse(this.objEmailNotificationsDT.Rows[0]["LatePaymentRemider"].ToString());
        this.chkInvoice.Checked = bool.Parse(this.objEmailNotificationsDT.Rows[0]["InvoiceSent"].ToString());
      }
      else
      {
        this.objEmailNotificationsBll.AddEmailNotifications(int.Parse(this.hfCompanyID.Value), true, false, false, false);
        this.Response.Redirect("CustomizeEmails.aspx");
      }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
      this.objEmailNotificationsDT = this.objEmailNotificationsBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objEmailNotificationsDT.Rows.Count > 0)
        this.objEmailNotificationsBll.UpdateEmailNotifications(int.Parse(this.objEmailNotificationsDT.Rows[0]["EmailNotificationsID"].ToString()), int.Parse(this.hfCompanyID.Value), this.chkWeekAccount.Checked, this.chkPaymentReceive.Checked, this.chkPayment.Checked, this.chkInvoice.Checked);
      else
        this.objEmailNotificationsBll.AddEmailNotifications(int.Parse(this.hfCompanyID.Value), this.chkWeekAccount.Checked, this.chkPaymentReceive.Checked, this.chkPayment.Checked, this.chkInvoice.Checked);
      this.Response.Redirect("CustomizeEmails.aspx");
    }
  }
}

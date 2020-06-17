// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.Miscellaneous
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
  public class Miscellaneous : Page
  {
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly MiscellaneousMasterBLL objMiscellaneousMasterBll = new MiscellaneousMasterBLL();
    private CloudAccountDA.MiscellaneousMasterDataTable objMiscellaneousMasterDT = new CloudAccountDA.MiscellaneousMasterDataTable();
    protected HtmlGenericControl divSave;
    protected TextBox txtLines;
    protected DropDownList ddlDateFormat;
    protected CheckBox chkDirectLink;
    protected CheckBox chkBranding;
    protected CheckBox chkRequestReview;
    protected TextBox txtLogoText;
    protected CheckBox chkSendAutomatically;
    protected CheckBox chkCreditAutomatically;
    protected DropDownList ddlLineType;
    protected TextBox txtWelcomeClient;
    protected TextBox txtWelcomeStaff;
    protected DropDownList ddlDefaultClient;
    protected DropDownList ddlDefaultStaff;
    protected TextBox txtTimeMinutes;
    protected TextBox txtTimeHours;
    protected Button btnSave;
    protected Button btnRestore;
    protected HiddenField hfCompanyID;
    protected HiddenField hfMiscellaneousID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("setting")).Attributes.Add("style", "background-color: lightgray;");
      ((HtmlControl) this.Master.FindControl("misc")).Attributes.Add("class", "active open");
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
      this.divSave.Visible = this.Session["saveMisc"] != null;
      this.Session.Abandon();
      this.SetCompanyRecords(this.hfCompanyID.Value);
    }

    private void SetCompanyRecords(string companyID)
    {
      this.objMiscellaneousMasterDT = this.objMiscellaneousMasterBll.GetDataByCompanyID(int.Parse(companyID));
      if (this.objMiscellaneousMasterDT.Rows.Count > 0)
      {
        this.hfMiscellaneousID.Value = this.objMiscellaneousMasterDT.Rows[0]["MiscellaneousID"].ToString();
        this.hfCompanyID.Value = this.objMiscellaneousMasterDT.Rows[0]["CompanyID"].ToString();
        this.txtLines.Text = this.objMiscellaneousMasterDT.Rows[0]["LinesPerPage"].ToString();
        this.ddlDateFormat.SelectedValue = this.objMiscellaneousMasterDT.Rows[0]["DateFormat"].ToString();
        this.chkDirectLink.Checked = bool.Parse(this.objMiscellaneousMasterDT.Rows[0]["DirectLinks"].ToString());
        this.chkBranding.Checked = bool.Parse(this.objMiscellaneousMasterDT.Rows[0]["DoyinGoBranding"].ToString());
        this.chkRequestReview.Checked = bool.Parse(this.objMiscellaneousMasterDT.Rows[0]["RequestReviews"].ToString());
        this.txtLogoText.Text = this.objMiscellaneousMasterDT.Rows[0]["TextBelowYourLogo"].ToString();
        this.chkSendAutomatically.Checked = bool.Parse(this.objMiscellaneousMasterDT.Rows[0]["RecurringInvoices"].ToString());
        this.chkCreditAutomatically.Checked = bool.Parse(this.objMiscellaneousMasterDT.Rows[0]["CreditAutomatically"].ToString());
        this.ddlLineType.SelectedValue = this.objMiscellaneousMasterDT.Rows[0]["DefaultColumnHeadings"].ToString();
        this.txtWelcomeClient.Text = this.objMiscellaneousMasterDT.Rows[0]["WelcomeMessagesClient"].ToString();
        this.txtWelcomeStaff.Text = this.objMiscellaneousMasterDT.Rows[0]["WelcomeMessagesStaff"].ToString();
        this.ddlDefaultClient.SelectedValue = this.objMiscellaneousMasterDT.Rows[0]["DefaultClientAccess"].ToString();
        this.ddlDefaultStaff.SelectedValue = this.objMiscellaneousMasterDT.Rows[0]["DefaultStaffAccess"].ToString();
        this.txtTimeMinutes.Text = this.objMiscellaneousMasterDT.Rows[0]["SupportTimeIncrementMinute"].ToString();
        this.txtTimeHours.Text = this.objMiscellaneousMasterDT.Rows[0]["SupportTimeIncrementHours"].ToString();
      }
      else
      {
        this.objMiscellaneousMasterBll.AddMiscellaneous(int.Parse(companyID), 15, "MM/dd/yyyy", true, true, true, "", true, false, "Both", "", "", "None", "Read/Write", 30, 10);
        this.Response.Redirect("Miscellaneous.aspx");
      }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
      this.objMiscellaneousMasterDT = this.objMiscellaneousMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objMiscellaneousMasterDT.Rows.Count > 0)
      {
        int iLinesPerPage = 15;
        int iSupportTimeIncrementMinute = 30;
        int iSupportTimeIncrementHours = 10;
        if (this.txtLines.Text.Trim().Length > 0)
          iLinesPerPage = int.Parse(this.txtLines.Text.Trim());
        if (this.txtTimeMinutes.Text.Trim().Length > 0)
          iSupportTimeIncrementMinute = int.Parse(this.txtTimeMinutes.Text.Trim());
        if (this.txtTimeHours.Text.Trim().Length > 0)
          iSupportTimeIncrementHours = int.Parse(this.txtTimeHours.Text.Trim());
        this.objMiscellaneousMasterBll.UpdateMiscellaneous(int.Parse(this.hfMiscellaneousID.Value), int.Parse(this.hfCompanyID.Value), iLinesPerPage, this.ddlDateFormat.SelectedItem.Value, this.chkDirectLink.Checked, this.chkBranding.Checked, this.chkRequestReview.Checked, this.txtLogoText.Text.Trim(), this.chkSendAutomatically.Checked, this.chkCreditAutomatically.Checked, this.ddlLineType.SelectedItem.Value, this.txtWelcomeClient.Text.Trim(), this.txtWelcomeStaff.Text.Trim(), this.ddlDefaultClient.SelectedItem.Value, this.ddlDefaultStaff.SelectedItem.Value, iSupportTimeIncrementMinute, iSupportTimeIncrementHours);
      }
      else
      {
        int iLinesPerPage = 15;
        int iSupportTimeIncrementMinute = 30;
        int iSupportTimeIncrementHours = 10;
        if (this.txtLines.Text.Trim().Length > 0)
          iLinesPerPage = int.Parse(this.txtLines.Text.Trim());
        if (this.txtTimeMinutes.Text.Trim().Length > 0)
          iSupportTimeIncrementMinute = int.Parse(this.txtTimeMinutes.Text.Trim());
        if (this.txtTimeHours.Text.Trim().Length > 0)
          iSupportTimeIncrementHours = int.Parse(this.txtTimeHours.Text.Trim());
        this.objMiscellaneousMasterBll.AddMiscellaneous(int.Parse(this.hfCompanyID.Value), iLinesPerPage, this.ddlDateFormat.SelectedItem.Value, this.chkDirectLink.Checked, this.chkBranding.Checked, this.chkRequestReview.Checked, this.txtLogoText.Text.Trim(), this.chkSendAutomatically.Checked, this.chkCreditAutomatically.Checked, this.ddlLineType.SelectedItem.Value, this.txtWelcomeClient.Text.Trim(), this.txtWelcomeStaff.Text.Trim(), this.ddlDefaultClient.SelectedItem.Value, this.ddlDefaultStaff.SelectedItem.Value, iSupportTimeIncrementMinute, iSupportTimeIncrementHours);
      }
      this.Session["saveMisc"] = (object) 1;
      this.Response.Redirect("Miscellaneous.aspx");
    }

    protected void btnRestore_Click(object sender, EventArgs e)
    {
      this.objMiscellaneousMasterDT = this.objMiscellaneousMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objMiscellaneousMasterDT.Rows.Count > 0)
        this.objMiscellaneousMasterBll.UpdateMiscellaneous(int.Parse(this.hfMiscellaneousID.Value), int.Parse(this.hfCompanyID.Value), 15, "MM/dd/yyyy", true, true, true, "", true, false, "Both", "", "", "None", "Read/Write", 30, 10);
      else
        this.objMiscellaneousMasterBll.AddMiscellaneous(int.Parse(this.hfCompanyID.Value), 15, "MM/dd/yyyy", true, true, true, "", true, false, "Both", "", "", "None", "Read/Write", 30, 10);
      this.Session["saveMisc"] = (object) 1;
      this.Response.Redirect("Miscellaneous.aspx");
    }
  }
}

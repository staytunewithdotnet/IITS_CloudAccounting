// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.UpgradeCompanyPackage
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Collections;
using System.Globalization;
using System.Net.Mail;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TemplateParser;

namespace IITS_CloudAccounting.Admin
{
  public class UpgradeCompanyPackage : Page
  {
    private readonly PackageMasterBLL objPackageMasterBll = new PackageMasterBLL();
    private CloudAccountDA.PackageMasterDataTable objPackageMasterDT = new CloudAccountDA.PackageMasterDataTable();
    private readonly CurrencyMasterBLL objCurrencyMasterBll = new CurrencyMasterBLL();
    private CloudAccountDA.CurrencyMasterDataTable objCurrencyMasterDT = new CloudAccountDA.CurrencyMasterDataTable();
    private readonly CompanyPackageDetailsBLL objCompanyPackageDetailsBll = new CompanyPackageDetailsBLL();
    private CloudAccountDA.CompanyPackageDetailsDataTable objCompanyPackageDetailsDT = new CloudAccountDA.CompanyPackageDetailsDataTable();
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
    private readonly PackageUpgradeRequestMasterBLL objPackageUpgradeRequestMasterBll = new PackageUpgradeRequestMasterBLL();
    private CloudAccountDA.PackageUpgradeRequestMasterDataTable objPackageUpgradeRequestMasterDT = new CloudAccountDA.PackageUpgradeRequestMasterDataTable();
    protected ToolkitScriptManager tsm;
    protected Panel pnlUpgrade;
    protected DropDownList ddlCompanyName;
    protected SqlDataSource SqlCompanyMaster;
    protected RequiredFieldValidator rfvCompanyName;
    protected Label lblPackageName;
    protected HiddenField hfPackageID;
    protected UpdatePanel upPackage;
    protected HtmlGenericControl finalHide;
    protected DropDownList ddlPackageName;
    protected SqlDataSource SqlPackageMaster;
    protected RequiredFieldValidator rfvPackageName;
    protected HtmlGenericControl viewPackage;
    protected Label lblTrial;
    protected HtmlGenericControl NoOfTrialDaysView;
    protected Label lblNoTrialDays;
    protected Label lblAdminUsersMin;
    protected Label lblAdminUsersMax;
    protected Label lblStaffUsersMin;
    protected Label lblStaffUsersMax;
    protected Label lblMonthCurrency;
    protected Label lblPricePerMonth;
    protected Label lblYearlyCurrency;
    protected Label lblPricePerYear;
    protected Label lblDescription;
    protected Button btnUpgrade;
    protected Button btnList;
    protected HtmlGenericControl info;
    protected Label lblInfo;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("companyManagement")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("companyPackageDetails")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (this.Request.QueryString["CompanyID"] != null)
      {
        this.pnlUpgrade.Visible = true;
        this.SetRecord(this.Request.QueryString["CompanyID"]);
      }
      else
        this.pnlUpgrade.Visible = false;
    }

    private void SetRecord(string cId)
    {
      this.objCompanyPackageDetailsDT = this.objCompanyPackageDetailsBll.GetDataByCompanyActivePackage(int.Parse(cId));
      if (this.objCompanyPackageDetailsDT.Rows.Count <= 0)
        return;
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(this.objCompanyPackageDetailsDT.Rows[0]["CompanyID"].ToString()));
      if (this.objCompanyMasterDT.Rows.Count > 0)
      {
        this.ddlCompanyName.SelectedValue = this.objCompanyPackageDetailsDT.Rows[0]["CompanyID"].ToString();
        this.ddlCompanyName.Enabled = false;
      }
      this.objPackageMasterDT = this.objPackageMasterBll.GetDataByPackageID(int.Parse(this.objCompanyPackageDetailsDT.Rows[0]["PackageID"].ToString()));
      if (this.objPackageMasterDT.Rows.Count <= 0)
        return;
      this.lblPackageName.Text = this.objPackageMasterDT.Rows[0]["PackageName"].ToString();
      this.hfPackageID.Value = this.objPackageMasterDT.Rows[0]["PackageID"].ToString();
    }

    private bool ViewRecord(string i)
    {
      this.objPackageMasterDT = this.objPackageMasterBll.GetDataByPackageID(int.Parse(i));
      if (this.objPackageMasterDT.Rows.Count <= 0)
        return false;
      this.hfPackageID.Value = this.objPackageMasterDT.Rows[0]["PackageID"].ToString();
      this.lblAdminUsersMin.Text = this.objPackageMasterDT.Rows[0]["NoOfAdminUsersMin"].ToString();
      this.lblAdminUsersMax.Text = this.objPackageMasterDT.Rows[0]["NoOfAdminUsersMax"].ToString();
      this.lblStaffUsersMin.Text = this.objPackageMasterDT.Rows[0]["NoOfStaffUsersMin"].ToString();
      this.lblStaffUsersMax.Text = this.objPackageMasterDT.Rows[0]["NoOfStaffUsersMax"].ToString();
      string s1 = this.objPackageMasterDT.Rows[0]["PricePerMonth"].ToString();
      if (!string.IsNullOrEmpty(s1))
        this.lblPricePerMonth.Text = Decimal.Round(Decimal.Parse(s1), 2).ToString((IFormatProvider) CultureInfo.InvariantCulture);
      string s2 = this.objPackageMasterDT.Rows[0]["PricePerYear"].ToString();
      if (!string.IsNullOrEmpty(s2))
        this.lblPricePerYear.Text = Decimal.Round(Decimal.Parse(s2), 2).ToString((IFormatProvider) CultureInfo.InvariantCulture);
      this.lblDescription.Text = this.objPackageMasterDT.Rows[0]["Description"].ToString();
      this.lblNoTrialDays.Text = this.objPackageMasterDT.Rows[0]["NoOfTrialDays"].ToString();
      this.lblTrial.Text = this.objPackageMasterDT.Rows[0]["FreeTrialPackage"].ToString() == "True" ? "True" : "False";
      this.NoOfTrialDaysView.Visible = bool.Parse(this.lblTrial.Text);
      this.lblMonthCurrency.Text = this.objPackageMasterDT.Rows[0]["MonthlyPriceCurrencyID"].ToString();
      this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(this.lblMonthCurrency.Text));
      this.lblMonthCurrency.Text = this.objCurrencyMasterDT.Rows[0]["CurrencySymbol"].ToString();
      this.lblYearlyCurrency.Text = this.objPackageMasterDT.Rows[0]["YearlyPriceCurrencyID"].ToString();
      this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(this.lblYearlyCurrency.Text));
      this.lblYearlyCurrency.Text = this.objCurrencyMasterDT.Rows[0]["CurrencySymbol"].ToString();
      return true;
    }

    protected void ddlPackageName_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.viewPackage.Visible = this.ViewRecord(this.ddlPackageName.SelectedItem.Value);
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/CompanyPackageDetails.aspx");
    }

    protected void btnUpgrade_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.ddlCompanyName.SelectedIndex > 0 && this.ddlPackageName.SelectedIndex > 0)
      {
        this.objPackageUpgradeRequestMasterDT = this.objPackageUpgradeRequestMasterBll.GetDataByCompanyID(int.Parse(this.ddlCompanyName.SelectedItem.Value));
        int count = this.objPackageUpgradeRequestMasterDT.Rows.Count;
        this.SendMail();
        this.info.Visible = true;
        this.finalHide.Visible = this.viewPackage.Visible = false;
        this.objPackageUpgradeRequestMasterBll.AddRequest(int.Parse(this.ddlCompanyName.SelectedItem.Value), int.Parse(this.hfPackageID.Value), int.Parse(this.ddlPackageName.SelectedItem.Value), true, new DateTime?(DateTime.Now), false, "", new DateTime?(DateTime.Now), "");
        this.Response.AddHeader("REFRESH", "2;URL=CompanyPackageDetails.aspx");
      }
      else
        this.DisplayAlert("Please Select Any One Package");
    }

    protected string GetCurrency(string cID)
    {
      this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(cID));
      if (this.objCurrencyMasterDT.Rows.Count > 0)
        return this.objCurrencyMasterDT.Rows[0]["CurrencySymbol"].ToString();
      return "";
    }

    private void SendMail()
    {
      Hashtable Variables = new Hashtable();
      Variables.Add((object) "Company", (object) this.ddlCompanyName.SelectedItem.Text);
      MembershipUser user = Membership.GetUser();
      if (user != null)
        Variables.Add((object) "CompanyUser", (object) user.UserName);
      Variables.Add((object) "CurrentPackage", (object) this.lblPackageName.Text);
      this.objPackageMasterDT = this.objPackageMasterBll.GetDataByPackageID(int.Parse(this.ddlPackageName.SelectedItem.Value));
      Variables.Add((object) "PackageName", this.objPackageMasterDT.Rows[0]["PackageName"]);
      Variables.Add((object) "CurrencySymbolMonth", (object) this.GetCurrency(this.objPackageMasterDT.Rows[0]["MonthlyPriceCurrencyID"].ToString()));
      Variables.Add((object) "PricePerMonth", this.objPackageMasterDT.Rows[0]["PricePerMonth"]);
      Variables.Add((object) "CurrencySymbolYear", (object) this.GetCurrency(this.objPackageMasterDT.Rows[0]["YearlyPriceCurrencyID"].ToString()));
      Variables.Add((object) "PricePerYear", this.objPackageMasterDT.Rows[0]["PricePerYear"]);
      Variables.Add((object) "NoOfAdminUsersMin", this.objPackageMasterDT.Rows[0]["NoOfAdminUsersMin"]);
      Variables.Add((object) "NoOfAdminUsersMax", this.objPackageMasterDT.Rows[0]["NoOfAdminUsersMax"]);
      Variables.Add((object) "NoOfStaffUsersMin", this.objPackageMasterDT.Rows[0]["NoOfStaffUsersMin"]);
      Variables.Add((object) "NoOfStaffUsersMax", this.objPackageMasterDT.Rows[0]["NoOfStaffUsersMax"]);
      Parser parser = new Parser(this.Server.MapPath("~/MailTemplate/UpgradePackage.html"), Variables);
      try
      {
        MailMessage message = new MailMessage()
        {
          From = new MailAddress("noreply@DoyniGo.com", "DoyinGo")
        };
        message.To.Add(new MailAddress("nirav.desai@iits.pro"));
        message.Subject = "DoyniGo - " + this.ddlCompanyName.SelectedItem.Text + " Package Upgradation";
        message.BodyEncoding = Encoding.UTF8;
        message.Body = parser.Parse();
        message.IsBodyHtml = true;
        new SmtpClient().Send(message);
        this.DisplayAlert("Upgradation Mail Sent Successfully.");
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
  }
}

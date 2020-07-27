// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.EstimateMaster
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TemplateParser;

namespace IITS_CloudAccounting.Admin
{
  public class EstimateMaster : Page
  {
    private readonly CityMasterBLL objCityMasterBll = new CityMasterBLL();
    private CloudAccountDA.CityMasterDataTable objCityMasterDT = new CloudAccountDA.CityMasterDataTable();
    private readonly TemplateSettingsBLL objTemplateSettingsBll = new TemplateSettingsBLL();
    private CloudAccountDA.TemplateSettingsDataTable objTemplateSettingsDT = new CloudAccountDA.TemplateSettingsDataTable();
    private readonly CountryMasterBLL objCountryMasterBll = new CountryMasterBLL();
    private CloudAccountDA.CountryMasterDataTable objCountryMasterDT = new CloudAccountDA.CountryMasterDataTable();
    private readonly CurrencyMasterBLL objCurrencyMasterBll = new CurrencyMasterBLL();
    private CloudAccountDA.CurrencyMasterDataTable objCurrencyMasterDT = new CloudAccountDA.CurrencyMasterDataTable();
    private readonly CompanyClientMasterBLL objCompanyClientMasterBll = new CompanyClientMasterBLL();
    private CloudAccountDA.CompanyClientMasterDataTable objCompanyClientMasterDT = new CloudAccountDA.CompanyClientMasterDataTable();
    private readonly CompanyClientContactDetailBLL objCompanyClientContactDetailBll = new CompanyClientContactDetailBLL();
    private CloudAccountDA.CompanyClientContactDetailDataTable objCompanyClientContactDetailDT = new CloudAccountDA.CompanyClientContactDetailDataTable();
    private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
    private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
    private readonly ContractorMasterBLL objContractorMasterBll = new ContractorMasterBLL();
    private CloudAccountDA.ContractorMasterDataTable objContractorMasterDT = new CloudAccountDA.ContractorMasterDataTable();
    private readonly IndustryMasterBLL objIndustryMasterBll = new IndustryMasterBLL();
    private CloudAccountDA.IndustryMasterDataTable objIndustryMasterDT = new CloudAccountDA.IndustryMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
    private readonly TaskMasterBLL objTaskMasterBll = new TaskMasterBLL();
    private CloudAccountDA.TaskMasterDataTable objTaskMasterDT = new CloudAccountDA.TaskMasterDataTable();
    private readonly ItemMasterBLL objItemMasterBll = new ItemMasterBLL();
    private CloudAccountDA.ItemMasterDataTable objItemMasterDT = new CloudAccountDA.ItemMasterDataTable();
    private readonly EstimateMasterBLL objEstimateMasterBll = new EstimateMasterBLL();
    private CloudAccountDA.EstimateMasterDataTable objEstimateMasterDT = new CloudAccountDA.EstimateMasterDataTable();
    private readonly EstimateItemDetailBLL objEstimateItemDetailBll = new EstimateItemDetailBLL();
    private CloudAccountDA.EstimateItemDetailDataTable objEstimateItemDetailDT = new CloudAccountDA.EstimateItemDetailDataTable();
    private readonly EstimateTaskDetailBLL objEstimateTaskDetailBll = new EstimateTaskDetailBLL();
    private CloudAccountDA.EstimateTaskDetailDataTable objEstimateTaskDetailDT = new CloudAccountDA.EstimateTaskDetailDataTable();
    private readonly TaxMasterBLL objTaxMasterBll = new TaxMasterBLL();
    private CloudAccountDA.TaxMasterDataTable objTaxMasterDT = new CloudAccountDA.TaxMasterDataTable();
    private readonly EstimateDefaultTermsMasterBLL objTermsBll = new EstimateDefaultTermsMasterBLL();
    private CloudAccountDA.EstimateDefaultTermsMasterDataTable objTermsDT = new CloudAccountDA.EstimateDefaultTermsMasterDataTable();
    private readonly StateMasterBLL objStateMasterBll = new StateMasterBLL();
    private CloudAccountDA.StateMasterDataTable objStateMasterDT = new CloudAccountDA.StateMasterDataTable();
    private readonly MiscellaneousMasterBLL objMiscellaneousMasterBll = new MiscellaneousMasterBLL();
    private CloudAccountDA.MiscellaneousMasterDataTable objMiscellaneousMasterDT = new CloudAccountDA.MiscellaneousMasterDataTable();
    private readonly StaffPermissionMasterBLL objStaffPermissionMasterBll = new StaffPermissionMasterBLL();
    private CloudAccountDA.StaffPermissionMasterDataTable objStaffPermissionMasterDT = new CloudAccountDA.StaffPermissionMasterDataTable();
    public string dateFormat = "MM/dd/yyyy";
    private int linePerPage = 15;
    private string branding = "block";
    private string directLink = "block";
    private string defaultColumn = "Both";
    private readonly NewEstimateEmailTemplateBLL objNewEstimateEmailTemplateBll = new NewEstimateEmailTemplateBLL();
    private CloudAccountDA.NewEstimateEmailTemplateDataTable objNewEstimateEmailTemplateDT = new CloudAccountDA.NewEstimateEmailTemplateDataTable();
    private readonly SMTPSettingsBLL objSMTPSettingsBll = new SMTPSettingsBLL();
    private CloudAccountDA.SMTPSettingsDataTable objSMTPSettingsDT = new CloudAccountDA.SMTPSettingsDataTable();
    private readonly EstimateDisputeHistoryBLL objEstimateDisputeHistoryBll = new EstimateDisputeHistoryBLL();
    private bool isStaff;
    private bool checkInDB;
    protected ToolkitScriptManager tsm;
    protected HtmlGenericControl divSave;
    protected HtmlGenericControl divUpdate;
    protected Panel pnlAdd;
    protected UpdatePanel upClient;
    protected HtmlGenericControl clienDetails;
    protected Label lblBoxClientFor;
    protected TextBox txtBoxClientEmail;
    protected RequiredFieldValidator rfvEmail;
    protected RegularExpressionValidator revEmail;
    protected TextBox txtBoxClientFirstName;
    protected TextBox txtBoxClientLastName;
    protected TextBox txtBoxClientOrganization;
    protected DropDownList ddlBoxClientCountry;
    protected TextBox txtBoxClientAddress1;
    protected TextBox txtBoxClientAddress2;
    protected DropDownList ddlBoxClientState;
    protected DropDownList ddlBoxClientCity;
    protected TextBox txtBoxClientZipcode;
    protected SqlDataSource sqldsCountry;
    protected SqlDataSource sqldsState;
    protected SqlDataSource sqldsCity;
    protected CheckBox chkBoxClientChange;
    protected DropDownList ddlIndustry;
    protected SqlDataSource sqldsIndustry;
    protected DropDownList ddlCompanySize;
    protected Label lblBoxClientInfo;
    protected Button btnBoxSave;
    protected Button btnBoxUpdate;
    protected LinkButton lnkBoxClose;
    protected HtmlGenericControl normalDetails;
    protected DropDownList ddlClient;
    protected SqlDataSource sqldsClient;
    protected SqlDataSource sqldsClientStaff;
    protected HtmlGenericControl clientAddress;
    protected DropDownList ddlCurrency;
    protected SqlDataSource sqldsCurrency;
    protected Label lblAddress;
    protected LinkButton lblEditAddress;
    protected TextBox txtEstimateNum;
    protected TextBox txtDateOfIssue;
    protected CalendarExtender ceDateOfIssue;
    protected TextBox txtPONumber;
    protected TextBox txtDiscount;
    protected GridView gvTask;
    protected GridView gvItem;
    protected SqlDataSource sqldsTask;
    protected SqlDataSource sqldsItem;
    protected SqlDataSource sqldsTax;
    protected LinkButton lnkAddTask;
    protected LinkButton lnkAddItem;
    protected Label lblSubTotal;
    protected Label lblDiscount;
    protected HtmlGenericControl divTax;
    protected Label lblAddedTaxes;
    protected HtmlGenericControl divTaxValue;
    protected Label lblCurrencySymbol2;
    protected Label lblEstimateTotal;
    protected Label lblPaidToDate;
    protected Label lblCurrencyCode;
    protected Label lblCurrencySymbol1;
    protected Label lblBalance;
    protected LinkButton lnkSetTerms;
    protected TextBox txtTerms;
    protected TextBox txtNotes;
    protected ModalPopupExtender mpEstimateTerms;
    protected Panel pnlEstimateTerms;
    protected LinkButton lnkClose;
    protected TextBox txtDefaultTerms;
    protected Button btnSaveTerms;
    protected HtmlGenericControl savebtn;
    protected Button btnSaveDraft;
    protected Button btnSendByMail;
    protected HtmlGenericControl saveMailDiv;
    protected HtmlGenericControl updatebtn;
    protected Button btnUpdateDraft;
    protected Button btnUpdateByMail;
    protected HtmlGenericControl updateMailDiv;
    protected Panel pnlView;
    protected Label lblEstimateNumHead;
    protected Button btnAcceptView;
    protected Button btnEdit;
    protected Button btnSendEmail;
    protected HtmlGenericControl disputeDiv;
    protected HtmlGenericControl disputeDivLabel;
    protected DataList dlHistory;
    protected Button btnDispute;
    protected SqlDataSource sqldsHistory;
    protected HtmlGenericControl disputeDivText;
    protected TextBox txtDisputeText;
    protected Button btnDisputeSend;
    protected LinkButton lnkCloseDispute;
    protected HtmlGenericControl divStatus;
    protected Label lblCompanyName;
    protected Label lblCompanyAddress;
    protected Image imgLogo;
    protected Label lblCompanyLogoText;
    protected Label lblClientOrganizationName;
    protected Label lblClientFullName;
    protected Label lblClientAddress;
    protected Label lblEstimateTitle;
    protected Label lblEstimateNum;
    protected Label lblEstimateTitleDate;
    protected Label lblEstimateDate;
    protected Label lblPONumber;
    protected Label lblCurSymbolView1;
    protected Label lblEstimateAmount;
    protected Label lblCurCodeView1;
    protected GridView gvTaskView;
    protected GridView gvItemView;
    protected ObjectDataSource objdsItemView;
    protected ObjectDataSource objdsTaskView;
    protected Label lblSubTotalView;
    protected Label lblDiscout;
    protected Label lblDiscountAmt;
    protected Label lblAddedTaxesView;
    protected HtmlGenericControl divTaxView;
    protected HtmlGenericControl divTaxValueView;
    protected Label lblEstimateTotalView;
    protected Label lblPaidToDateView;
    protected Label lblCurSymbolView2;
    protected Label lblAmountDue;
    protected Label lblCurCodeView2;
    protected Label lblTerms;
    protected Label lblNotes;
    protected HtmlGenericControl brandingDiv;
    protected Panel pnlViewAll;
    protected Label lblHeader;
    protected Button btnAdd;
    protected TextBox txtEstimateNumberSearch;
    protected TextBox txtClientNameSearch;
    protected TextBox txtItemNameSearch;
    protected TextBox txtItemDescSearch;
    protected TextBox txtPONumberSearch;
    protected TextBox txtNotesSearch;
    protected DropDownList ddlStatusSearch;
    protected TextBox txtEstimateDateFrom;
    protected CalendarExtender ceDateFrom;
    protected TextBox txtEstimateDateTo;
    protected CalendarExtender ceDateTo;
    protected TextBox txtEstimateTotalFrom;
    protected TextBox txtEstimateTotalTo;
    protected DropDownList ddlCurrencySearch;
    protected SqlDataSource sqldsCurrencySearch;
    protected Button btnSearch;
    protected Button btnReset;
    protected Button btnUnDelete;
    protected Button btnArchived;
    protected Button btnUnArchived;
    protected Button btnDelete;
    protected Button btnCopy;
    protected Button btnInvoice;
    protected Button btnAccept;
    protected Button btnEmail;
    protected GridView gvEstimate;
    protected HtmlAnchor activeTag;
    protected HtmlAnchor archivedTag;
    protected HtmlAnchor deletedTag;
    protected GridView gvEstimateTotal;
    protected SqlDataSource sqldsEstimateTotalCompany;
    protected SqlDataSource sqldsEstimateTotalCompanyStaff;
    protected ObjectDataSource objdsEstimate;
    protected ObjectDataSource objdsEstimateStaff;
    protected HiddenField hfCompanyID;
    protected HiddenField hfStaffID;
    protected HiddenField hfCompanyClientID;
    protected HiddenField hfEstimateID;

    protected void Page_Load(object sender, EventArgs e)
    {
      this.Page.MaintainScrollPositionOnPostBack = true;
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("Estimate")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("newEstimate")).Attributes.Add("class", "active open");
      MembershipUser user = Membership.GetUser();
      if (user != null)
      {
        string str = user.ToString();
        if (Roles.IsUserInRole(str, "Admin"))
        {
          this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(str);
          if (this.objCompanyLoginMasterDT.Rows.Count > 0)
          {
            this.hfCompanyID.Value = this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString();
            this.isStaff = false;
          }
        }
        else if (Roles.IsUserInRole(str, "Employee"))
        {
          this.objStaffMasterDT = this.objStaffMasterBll.GetDataByStaffUserName(str);
          if (this.objStaffMasterDT.Rows.Count > 0)
          {
            this.hfCompanyID.Value = this.objStaffMasterDT.Rows[0]["CompanyID"].ToString();
            this.hfStaffID.Value = this.objStaffMasterDT.Rows[0]["StaffID"].ToString();
            this.isStaff = true;
          }
        }
        this.ceDateOfIssue.Format = this.dateFormat;
        this.ceDateFrom.Format = this.dateFormat;
        this.ceDateTo.Format = this.dateFormat;
        this.SetMiscValues(this.hfCompanyID.Value);
      }
      if (this.IsPostBack)
        return;
      this.divSave.Visible = this.Session["saveEstimate"] != null;
      this.divUpdate.Visible = this.Session["updateEstimate"] != null;
      this.Session.Abandon();
      if (this.Request.QueryString["cmd"] != null)
      {
        string str = this.Request.QueryString["cmd"];
        this.BindDropDown();
        switch (str)
        {
          case "view":
            if (this.Request.QueryString["ID"] == null)
              break;
            string id = this.Request.QueryString["ID"];
            this.pnlView.Visible = true;
            this.pnlViewAll.Visible = false;
            this.pnlAdd.Visible = false;
            this.ViewRecord(id);
            break;
          case "copied":
            if (this.Request.QueryString["ID"] == null)
              break;
            this.SetRecord(this.Request.QueryString["ID"]);
            this.pnlAdd.Visible = true;
            this.pnlView.Visible = false;
            this.pnlViewAll.Visible = false;
            this.savebtn.Visible = true;
            this.updatebtn.Visible = false;
            this.SetDefaultValues();
            this.ddlClient.Focus();
            break;
          case "add":
            if (this.Request.QueryString["ID"] != null)
            {
              this.SetRecord(this.Request.QueryString["ID"]);
              this.pnlAdd.Visible = true;
              this.pnlView.Visible = false;
              this.pnlViewAll.Visible = false;
              this.savebtn.Visible = false;
              this.updatebtn.Visible = true;
              this.ddlClient.Focus();
              break;
            }
            this.Clear();
            this.ddlClient.Focus();
            this.pnlViewAll.Visible = false;
            this.pnlView.Visible = false;
            this.pnlAdd.Visible = true;
            this.updatebtn.Visible = false;
            this.savebtn.Visible = true;
            this.FirstGridRow();
            this.SetDefaultValues();
            break;
          default:
            this.btnArchived.Visible = !this.CheckARQuery();
            this.btnCopy.Visible = !this.CheckDEQuery();
            this.btnUnArchived.Visible = this.CheckARQuery();
            this.btnDelete.Visible = !this.CheckDEQuery();
            this.btnUnDelete.Visible = this.CheckDEQuery();
            this.btnAccept.Visible = this.btnInvoice.Visible = !this.btnUnDelete.Visible;
            this.ATagStyle();
            this.pnlViewAll.Visible = true;
            this.pnlView.Visible = false;
            this.pnlAdd.Visible = false;
            this.BindGrid();
            break;
        }
      }
      else
      {
        this.btnArchived.Visible = !this.CheckARQuery();
        this.btnCopy.Visible = !this.CheckDEQuery();
        this.btnUnArchived.Visible = this.CheckARQuery();
        this.btnDelete.Visible = !this.CheckDEQuery();
        this.btnUnDelete.Visible = this.CheckDEQuery();
        this.btnAccept.Visible = this.btnInvoice.Visible = !this.btnUnDelete.Visible;
        this.ATagStyle();
        this.pnlViewAll.Visible = true;
        this.pnlView.Visible = false;
        this.pnlAdd.Visible = false;
        this.BindGrid();
      }
    }

    private void SetMiscValues(string companyID)
    {
      this.objMiscellaneousMasterDT = this.objMiscellaneousMasterBll.GetDataByCompanyID(int.Parse(companyID));
      if (this.objMiscellaneousMasterDT.Rows.Count > 0)
      {
        this.dateFormat = this.objMiscellaneousMasterDT.Rows[0]["DateFormat"].ToString();
        this.linePerPage = int.Parse(this.objMiscellaneousMasterDT.Rows[0]["LinesPerPage"].ToString());
        this.gvEstimate.PageSize = this.linePerPage;
        this.ceDateOfIssue.Format = this.dateFormat;
        this.ceDateFrom.Format = this.dateFormat;
        this.ceDateTo.Format = this.dateFormat;
        this.brandingDiv.Visible = (bool) this.objMiscellaneousMasterDT.Rows[0]["DoyinGoBranding"];
        this.branding = (bool) this.objMiscellaneousMasterDT.Rows[0]["DoyinGoBranding"] ? "none" : "block";
        this.directLink = (bool) this.objMiscellaneousMasterDT.Rows[0]["DirectLinks"] ? "none" : "block";
        this.lblCompanyLogoText.Text = this.objMiscellaneousMasterDT.Rows[0]["TextBelowYourLogo"].ToString();
        this.defaultColumn = this.objMiscellaneousMasterDT.Rows[0]["DefaultColumnHeadings"].ToString();
        switch (this.defaultColumn)
        {
          case "Both":
            this.gvItem.Visible = true;
            this.gvTask.Visible = true;
            break;
          case "time":
            this.gvItem.Visible = false;
            this.gvTask.Visible = true;
            break;
          case "items":
            this.gvItem.Visible = true;
            this.gvTask.Visible = false;
            break;
        }
      }
      if (!this.isStaff)
        return;
      this.objStaffPermissionMasterDT = this.objStaffPermissionMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objStaffPermissionMasterDT.Rows.Count <= 0)
        return;
      bool flag = bool.Parse(this.objStaffPermissionMasterDT.Rows[0]["SendInvEstCre"].ToString());
      this.btnSendByMail.Visible = flag;
      this.btnUpdateByMail.Visible = flag;
      this.saveMailDiv.Visible = flag;
      this.updateMailDiv.Visible = flag;
    }

    private void ATagStyle()
    {
      if (this.Request.QueryString["ac"] != null && bool.Parse(this.Request.QueryString["ac"]))
      {
        this.activeTag.Attributes.Add("class", "activeTag");
        this.activeTag.Attributes.Remove("href");
        this.lblHeader.Text = "Estimates";
      }
      if (this.Request.QueryString["ar"] != null && bool.Parse(this.Request.QueryString["ar"]))
      {
        this.archivedTag.Attributes.Add("class", "activeTag");
        this.archivedTag.Attributes.Remove("href");
        this.lblHeader.Text = "Archived Estimates";
      }
      if (this.Request.QueryString["de"] != null && bool.Parse(this.Request.QueryString["de"]))
      {
        this.deletedTag.Attributes.Add("class", "activeTag");
        this.deletedTag.Attributes.Remove("href");
        this.lblHeader.Text = "Deleted Estimates";
      }
      if (this.Request.QueryString["ar"] != null || this.Request.QueryString["ac"] != null || this.Request.QueryString["de"] != null)
        return;
      this.activeTag.Attributes.Add("class", "activeTag");
      this.activeTag.Attributes.Remove("href");
      this.lblHeader.Text = "Estimates";
    }

    private void BindGrid()
    {
      MembershipUser user = Membership.GetUser();
      if (user != null)
      {
        string username = user.ToString();
        if (Roles.IsUserInRole(username, "Admin"))
        {
          this.gvEstimate.DataSource = (object) this.objdsEstimate;
          this.gvEstimateTotal.DataSource = (object) this.sqldsEstimateTotalCompany;
        }
        else if (Roles.IsUserInRole(username, "Employee"))
        {
          this.gvEstimate.DataSource = (object) this.objdsEstimateStaff;
          this.gvEstimateTotal.DataSource = (object) this.sqldsEstimateTotalCompanyStaff;
        }
      }
      this.gvEstimate.DataBind();
      this.gvEstimateTotal.DataBind();
    }

    private void BindDropDown()
    {
      MembershipUser user = Membership.GetUser();
      if (user != null)
      {
        string username = user.ToString();
        if (Roles.IsUserInRole(username, "Admin"))
          this.ddlClient.DataSource = (object) this.sqldsClient;
        else if (Roles.IsUserInRole(username, "Employee"))
          this.ddlClient.DataSource = (object) this.sqldsClientStaff;
      }
      this.ddlClient.DataBind();
    }

    private void ViewRecord(string id)
    {
      this.objTermsDT = this.objTermsBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objTermsDT.Rows.Count > 0)
        this.txtDefaultTerms.Text = this.objTermsDT.Rows[0]["DefaultTerms"].ToString();
      this.objEstimateMasterDT = this.objEstimateMasterBll.GetDataByEstimateID(int.Parse(id));
      if (this.objEstimateMasterDT.Rows.Count <= 0)
        return;
      this.hfCompanyID.Value = this.objEstimateMasterDT.Rows[0]["CompanyID"].ToString();
      this.objTemplateSettingsDT = this.objTemplateSettingsBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objTemplateSettingsDT.Rows.Count > 0)
      {
        this.lblEstimateTitle.Text = (string) this.objTemplateSettingsDT.Rows[0]["EstimateTitle"] + (object) " #";
        this.lblEstimateTitleDate.Text = (string) this.objTemplateSettingsDT.Rows[0]["EstimateTitle"] + (object) " Date";
      }
      this.hfEstimateID.Value = this.objEstimateMasterDT.Rows[0]["EstimateID"].ToString();
      this.dlHistory.DataBind();
      this.disputeDivLabel.Visible = this.dlHistory.Items.Count > 0;
      this.disputeDiv.Visible = this.disputeDivText.Visible || this.disputeDivLabel.Visible;
      string str1 = this.objEstimateMasterDT.Rows[0]["EstimateStatus"].ToString();
      this.btnAcceptView.Visible = str1.ToLower() != "accepted";
      this.btnDispute.Visible = str1.ToLower() != "accepted";
      this.lblEstimateNum.Text = this.objEstimateMasterDT.Rows[0]["EstimateNumber"].ToString();
      this.lblEstimateNumHead.Text = "Estimate: " + this.objEstimateMasterDT.Rows[0]["EstimateNumber"];
      this.lblEstimateDate.Text = DateTime.Parse(this.objEstimateMasterDT.Rows[0]["EstimateDate"].ToString()).ToString("MMMM dd, yyyy");
      this.lblPONumber.Text = this.objEstimateMasterDT.Rows[0]["PONumber"].ToString();
      this.lblTerms.Text = this.objEstimateMasterDT.Rows[0]["Terms"].ToString();
      this.lblNotes.Text = this.objEstimateMasterDT.Rows[0]["Notes"].ToString();
      string s1 = this.objEstimateMasterDT.Rows[0]["Discount"].ToString();
      this.lblDiscout.Text = s1.Length > 0 ? s1 : "0.00";
      this.lblEstimateTotalView.Text = Decimal.Round(Decimal.Parse(this.objEstimateMasterDT.Rows[0]["EstimateTotal"].ToString()), 2).ToString();
      this.lblPaidToDateView.Text = Decimal.Round(Decimal.Parse(this.objEstimateMasterDT.Rows[0]["PaidToDate"].ToString()), 2).ToString();
      Label label1 = this.lblEstimateAmount;
      Label label2 = this.lblAmountDue;
      Decimal num1 = Decimal.Parse(this.lblEstimateTotalView.Text) - Decimal.Parse(this.lblPaidToDateView.Text);
      string str2;
      string str3 = str2 = num1.ToString();
      label2.Text = str2;
      string str4 = str3;
      label1.Text = str4;
      Label label3 = this.lblEstimateAmount;
      Label label4 = this.lblAmountDue;
      num1 = Decimal.Round(Decimal.Parse(this.lblAmountDue.Text), 2);
      string str5;
      string str6 = str5 = num1.ToString();
      label4.Text = str5;
      string str7 = str6;
      label3.Text = str7;
      this.divTaxValueView.Controls.Clear();
      this.divTaxView.Controls.Clear();
      Hashtable hashtable = new Hashtable();
      if (this.gvTaskView.Rows.Count > 0)
      {
        for (int index = 0; index < this.gvTaskView.Rows.Count; ++index)
        {
          string text1 = this.gvTaskView.Rows[index].Cells[2].Text;
          string text2 = this.gvTaskView.Rows[index].Cells[3].Text;
          string text3 = this.gvTaskView.Rows[index].Cells[4].Text;
          string text4 = this.gvTaskView.Rows[index].Cells[5].Text;
          try
          {
            if (!string.IsNullOrEmpty(text3) && !text3.Contains("&"))
            {
              this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxName(int.Parse(this.hfCompanyID.Value), text3);
              if (this.objTaxMasterDT.Rows.Count > 0)
              {
                string s2 = this.objTaxMasterDT.Rows[0]["TaxRate"].ToString();
                Decimal d = Decimal.Parse(text1) * Decimal.Parse(text2) * Decimal.Parse(s2) / new Decimal(100);
                Label label5 = new Label()
                {
                  Text = this.gvTaskView.Rows[index].Cells[4].Text + "(" + s2 + ")"
                };
                Label label6 = new Label()
                {
                  Text = string.Concat((object) Decimal.Round(d, 2))
                };
                if (hashtable.ContainsKey((object) label5.Text))
                {
                  object obj = hashtable[(object) label5.Text];
                  Decimal num2 = d + Decimal.Parse(obj.ToString());
                  hashtable.Remove((object) label5.Text);
                  hashtable.Add((object) label5.Text, (object) num2.ToString());
                }
                else
                  hashtable.Add((object) label5.Text, (object) label6.Text);
              }
            }
            if (!string.IsNullOrEmpty(text4))
            {
              if (!text4.Contains("&"))
              {
                this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxName(int.Parse(this.hfCompanyID.Value), text4);
                if (this.objTaxMasterDT.Rows.Count > 0)
                {
                  string s2 = this.objTaxMasterDT.Rows[0]["TaxRate"].ToString();
                  Decimal d = Decimal.Parse(text1) * Decimal.Parse(text2) * Decimal.Parse(s2) / new Decimal(100);
                  Label label5 = new Label()
                  {
                    Text = this.gvTaskView.Rows[index].Cells[5].Text + "(" + s2 + ")"
                  };
                  Label label6 = new Label()
                  {
                    Text = string.Concat((object) Decimal.Round(d, 2))
                  };
                  if (hashtable.ContainsKey((object) label5.Text))
                  {
                    object obj = hashtable[(object) label5.Text];
                    Decimal num2 = d + Decimal.Parse(obj.ToString());
                    hashtable.Remove((object) label5.Text);
                    hashtable.Add((object) label5.Text, (object) num2.ToString());
                  }
                  else
                    hashtable.Add((object) label5.Text, (object) label6.Text);
                }
              }
            }
          }
          catch (Exception ex)
          {
            this.gvTaskView.Rows[index].Cells[4].Text = "";
            this.gvTaskView.Rows[index].Cells[5].Text = "";
          }
        }
      }
      if (this.gvItemView.Rows.Count > 0)
      {
        for (int index = 0; index < this.gvItemView.Rows.Count; ++index)
        {
          string text1 = this.gvItemView.Rows[index].Cells[2].Text;
          string text2 = this.gvItemView.Rows[index].Cells[3].Text;
          string text3 = this.gvItemView.Rows[index].Cells[4].Text;
          string text4 = this.gvItemView.Rows[index].Cells[5].Text;
          try
          {
            if (!string.IsNullOrEmpty(text3) && !text3.Contains("&"))
            {
              this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxName(int.Parse(this.hfCompanyID.Value), text3);
              if (this.objTaxMasterDT.Rows.Count > 0)
              {
                string s2 = this.objTaxMasterDT.Rows[0]["TaxRate"].ToString();
                Decimal d = Decimal.Parse(text1) * Decimal.Parse(text2) * Decimal.Parse(s2) / new Decimal(100);
                Label label5 = new Label()
                {
                  Text = this.gvItemView.Rows[index].Cells[4].Text + "(" + s2 + ")"
                };
                Label label6 = new Label()
                {
                  Text = string.Concat((object) Decimal.Round(d, 2))
                };
                if (hashtable.ContainsKey((object) label5.Text))
                {
                  object obj = hashtable[(object) label5.Text];
                  Decimal num2 = d + Decimal.Parse(obj.ToString());
                  hashtable.Remove((object) label5.Text);
                  hashtable.Add((object) label5.Text, (object) num2.ToString());
                }
                else
                  hashtable.Add((object) label5.Text, (object) label6.Text);
              }
            }
            if (!string.IsNullOrEmpty(text4))
            {
              if (!text4.Contains("&"))
              {
                this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxName(int.Parse(this.hfCompanyID.Value), text4);
                if (this.objTaxMasterDT.Rows.Count > 0)
                {
                  string s2 = this.objTaxMasterDT.Rows[0]["TaxRate"].ToString();
                  Decimal d = Decimal.Parse(text1) * Decimal.Parse(text2) * Decimal.Parse(s2) / new Decimal(100);
                  Label label5 = new Label()
                  {
                    Text = this.gvItemView.Rows[index].Cells[5].Text + "(" + s2 + ")"
                  };
                  Label label6 = new Label()
                  {
                    Text = string.Concat((object) Decimal.Round(d, 2))
                  };
                  if (hashtable.ContainsKey((object) label5.Text))
                  {
                    object obj = hashtable[(object) label5.Text];
                    Decimal num2 = d + Decimal.Parse(obj.ToString());
                    hashtable.Remove((object) label5.Text);
                    hashtable.Add((object) label5.Text, (object) num2.ToString());
                  }
                  else
                    hashtable.Add((object) label5.Text, (object) label6.Text);
                }
              }
            }
          }
          catch (Exception ex)
          {
            this.gvItemView.Rows[index].Cells[4].Text = "";
            this.gvItemView.Rows[index].Cells[5].Text = "";
          }
        }
      }
      if (hashtable.Count > 0)
      {
        foreach (string str8 in (IEnumerable) hashtable.Keys)
        {
          this.divTaxView.Controls.Add((Control) new Label()
          {
            Text = str8
          });
          this.divTaxView.Controls.Add((Control) new LiteralControl("<br />"));
        }
        foreach (object obj in (IEnumerable) hashtable.Values)
        {
          this.divTaxValueView.Controls.Add((Control) new Label()
          {
            Text = ("+" + (object) Decimal.Round(Decimal.Parse(obj.ToString()), 2))
          });
          this.divTaxValueView.Controls.Add((Control) new LiteralControl("<br />"));
        }
      }
      Decimal d1 = new Decimal(0);
      if (this.gvItemView.Rows.Count > 0)
      {
        for (int index = 0; index < this.gvItemView.Rows.Count; ++index)
        {
          string text = this.gvItemView.Rows[index].Cells[6].Text;
          d1 += Decimal.Parse(text);
        }
      }
      if (this.gvTaskView.Rows.Count > 0)
      {
        for (int index = 0; index < this.gvTaskView.Rows.Count; ++index)
        {
          string text = this.gvTaskView.Rows[index].Cells[6].Text;
          d1 += Decimal.Parse(text);
        }
      }
      Label label7 = this.lblSubTotalView;
      num1 = Decimal.Round(d1, 2);
      string str9 = num1.ToString();
      label7.Text = str9;
      Label label8 = this.lblDiscountAmt;
      num1 = Decimal.Parse(this.lblSubTotalView.Text) * Decimal.Parse(s1) / new Decimal(100);
      string str10 = num1.ToString();
      label8.Text = str10;
      Label label9 = this.lblDiscountAmt;
      num1 = Decimal.Round(Decimal.Parse(this.lblDiscountAmt.Text), 2);
      string str11 = num1.ToString();
      label9.Text = str11;
      this.lblAddedTaxesView.Text = Decimal.Round(Decimal.Parse(this.lblEstimateAmount.Text) - Decimal.Parse(this.lblSubTotalView.Text) + Decimal.Parse(this.lblDiscountAmt.Text), 2).ToString();
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      this.imgLogo.ImageUrl = "../Handler/CompanyLogoFile.ashx?id=" + this.objCompanyMasterDT.Rows[0]["CompanyID"];
      this.lblCompanyName.Text = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
      string str12 = string.Empty;
      if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CompanyAddressStreet1"].ToString()))
        str12 = str12 + this.objCompanyMasterDT.Rows[0]["CompanyAddressStreet1"] + ",<br />";
      if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CompanyAddressStreet2"].ToString()))
        str12 = str12 + this.objCompanyMasterDT.Rows[0]["CompanyAddressStreet2"] + ",<br />";
      if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CompanyCityID"].ToString()))
      {
        this.objCityMasterDT = this.objCityMasterBll.GetDataByCityID(int.Parse(this.objCompanyMasterDT.Rows[0]["CompanyCityID"].ToString()));
        if (this.objCityMasterDT.Rows.Count > 0)
          str12 = str12 + this.objCityMasterDT.Rows[0]["CityName"] + " - ";
      }
      if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CompanyZipCode"].ToString()))
        str12 = str12 + this.objCompanyMasterDT.Rows[0]["CompanyZipCode"] + ",<br />";
      if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CompanyStateID"].ToString()))
      {
        this.objStateMasterDT = this.objStateMasterBll.GetDataByStateID(int.Parse(this.objCompanyMasterDT.Rows[0]["CompanyStateID"].ToString()));
        if (this.objStateMasterDT.Rows.Count > 0)
          str12 = str12 + this.objStateMasterDT.Rows[0]["StateName"] + ",<br />";
      }
      if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CompanyCountryID"].ToString()))
      {
        this.objCountryMasterDT = this.objCountryMasterBll.GetDataByCountryID(int.Parse(this.objCompanyMasterDT.Rows[0]["CompanyCountryID"].ToString()));
        if (this.objCountryMasterDT.Rows.Count > 0)
          str12 = str12 + this.objCountryMasterDT.Rows[0]["CountryName"] + ".<br />";
      }
      this.lblCompanyAddress.Text = str12;
      Label label10 = this.lblCompanyAddress;
      string str13 = label10.Text + (object) "Email: <a href=\"mailto:" + (string) this.objCompanyMasterDT.Rows[0]["CompanyEmail"] + "\">" + (string) this.objCompanyMasterDT.Rows[0]["CompanyEmail"] + "</a><br />";
      label10.Text = str13;
      Label label11 = this.lblCompanyAddress;
      string str14 = label11.Text + (object) "Phone: " + (string) this.objCompanyMasterDT.Rows[0]["CompanyPhone"];
      label11.Text = str14;
      this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(this.objEstimateMasterDT.Rows[0]["ClientId"].ToString()));
      this.lblClientOrganizationName.Text = this.objCompanyClientMasterDT.Rows[0]["OrganizationName"].ToString();
      this.lblClientFullName.Text = (string) this.objCompanyClientMasterDT.Rows[0]["FirstName"] + (object) " " + (string) this.objCompanyClientMasterDT.Rows[0]["LastName"];
      string str15 = string.Empty + this.objCompanyClientMasterDT.Rows[0]["Address1"] + ",<br />" + this.objCompanyClientMasterDT.Rows[0]["Address2"] + ",<br />";
      if (!string.IsNullOrEmpty(this.objCompanyClientMasterDT.Rows[0]["CityID"].ToString()))
      {
        this.objCityMasterDT = this.objCityMasterBll.GetDataByCityID(int.Parse(this.objCompanyClientMasterDT.Rows[0]["CityID"].ToString()));
        if (this.objCityMasterDT.Rows.Count > 0)
          str15 = str15 + this.objCityMasterDT.Rows[0]["CityName"] + " ";
      }
      if (!string.IsNullOrEmpty(this.objCompanyClientMasterDT.Rows[0]["StateID"].ToString()))
      {
        this.objStateMasterDT = this.objStateMasterBll.GetDataByStateID(int.Parse(this.objCompanyClientMasterDT.Rows[0]["StateID"].ToString()));
        if (this.objStateMasterDT.Rows.Count > 0)
          str15 = str15 + this.objStateMasterDT.Rows[0]["StateName"] + " ";
      }
      string str16 = string.Concat(new object[4]
      {
        (object) str15,
        (object) " - ",
        this.objCompanyClientMasterDT.Rows[0]["ZipCode"],
        (object) ",<br />"
      });
      if (!string.IsNullOrEmpty(this.objCompanyClientMasterDT.Rows[0]["CountryID"].ToString()))
      {
        this.objCountryMasterDT = this.objCountryMasterBll.GetDataByCountryID(int.Parse(this.objCompanyClientMasterDT.Rows[0]["CountryID"].ToString()));
        str16 += this.objCountryMasterDT.Rows[0]["CountryName"].ToString();
      }
      this.lblClientAddress.Text = str16;
      switch (this.objEstimateMasterDT.Rows[0]["EstimateStatus"].ToString())
      {
        case "draft":
          this.divStatus.Attributes.Add("class", "status-draft");
          break;
        case "draft-partial":
          this.divStatus.Attributes.Add("class", "status-draft-partial");
          break;
        case "created":
          this.divStatus.Attributes.Add("class", "status-created");
          break;
        case "sent":
          this.divStatus.Attributes.Add("class", "status-sent");
          break;
        case "viewed":
          this.divStatus.Attributes.Add("class", "status-viewed");
          break;
        case "disputed":
          this.divStatus.Attributes.Add("class", "status-disputed");
          break;
        case "paid":
          this.divStatus.Attributes.Add("class", "status-paid");
          break;
        case "partial":
          this.divStatus.Attributes.Add("class", "status-partial");
          break;
        case "pending":
          this.divStatus.Attributes.Add("class", "status-pending");
          break;
        case "declined":
          this.divStatus.Attributes.Add("class", "status-declined");
          break;
        case "auto-paid":
          this.divStatus.Attributes.Add("class", "status-auto-paid");
          break;
        case "retry":
          this.divStatus.Attributes.Add("class", "status-retry");
          break;
        case "failed":
          this.divStatus.Attributes.Add("class", "status-failed");
          break;
        case "replied":
          this.divStatus.Attributes.Add("class", "status-replied");
          break;
        case "commented":
          this.divStatus.Attributes.Add("class", "status-commented");
          break;
        case "resolved":
          this.divStatus.Attributes.Add("class", "status-resolved");
          break;
        case "accepted":
          this.divStatus.Attributes.Add("class", "status-accepted");
          break;
        case "Estimated":
          this.divStatus.Attributes.Add("class", "status-Estimated");
          break;
        case "outstanding":
          this.divStatus.Attributes.Add("class", "status-outstanding");
          break;
        case "open":
          this.divStatus.Attributes.Add("class", "status-open");
          break;
        default:
          this.divStatus.Attributes.Add("class", "status-created");
          break;
      }
      string s3 = this.objEstimateMasterDT.Rows[0]["CurrencyID"].ToString();
      if (string.IsNullOrEmpty(s3))
        return;
      this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(s3));
      if (this.objCurrencyMasterDT.Rows.Count <= 0)
        return;
      this.lblCurCodeView1.Text = this.lblCurCodeView2.Text = this.objCurrencyMasterDT.Rows[0]["CurrencyCode"].ToString();
      this.lblCurSymbolView1.Text = this.lblCurSymbolView2.Text = this.objCurrencyMasterDT.Rows[0]["CurrencySymbol"].ToString();
    }

    private void SetRecord(string id)
    {
      this.objTermsDT = this.objTermsBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objTermsDT.Rows.Count > 0)
        this.txtDefaultTerms.Text = this.objTermsDT.Rows[0]["DefaultTerms"].ToString();
      this.objEstimateMasterDT = this.objEstimateMasterBll.GetDataByEstimateID(int.Parse(id));
      if (this.objEstimateMasterDT.Rows.Count <= 0)
        return;
      this.hfCompanyID.Value = this.objEstimateMasterDT.Rows[0]["CompanyID"].ToString();
      this.hfEstimateID.Value = this.objEstimateMasterDT.Rows[0]["EstimateID"].ToString();
      if (this.Request.QueryString["cmd"] == "add")
        this.ddlClient.Items.Add(this.objEstimateMasterDT.Rows[0]["ClientID"].ToString());
      this.ddlClient.SelectedValue = this.objEstimateMasterDT.Rows[0]["ClientID"].ToString();
      this.ddlClient_SelectedIndexChanged((object) null, (EventArgs) null);
      this.txtEstimateNum.Text = this.objEstimateMasterDT.Rows[0]["EstimateNumber"].ToString();
      this.txtDateOfIssue.Text = DateTime.Parse(this.objEstimateMasterDT.Rows[0]["EstimateDate"].ToString()).ToString("MM/dd/yyyy");
      this.txtPONumber.Text = this.objEstimateMasterDT.Rows[0]["PONumber"].ToString();
      this.txtDiscount.Text = this.objEstimateMasterDT.Rows[0]["Discount"].ToString();
      this.txtTerms.Text = this.objEstimateMasterDT.Rows[0]["Terms"].ToString();
      this.txtNotes.Text = this.objEstimateMasterDT.Rows[0]["Notes"].ToString();
      this.FirstGridEditRow();
      this.objEstimateItemDetailDT = this.objEstimateItemDetailBll.GetDataByEstimateID(int.Parse(this.hfEstimateID.Value));
      if (this.objEstimateItemDetailDT.Rows.Count > 0)
      {
        int index1 = 0;
        for (int index2 = 0; index2 < this.objEstimateItemDetailDT.Rows.Count; ++index2)
        {
          this.AddNewItemRow();
          DropDownList dropDownList1 = (DropDownList) this.gvItem.Rows[index1].Cells[0].FindControl("ddlItem");
          TextBox textBox1 = (TextBox) this.gvItem.Rows[index1].Cells[1].FindControl("txtItemDesc");
          TextBox textBox2 = (TextBox) this.gvItem.Rows[index1].Cells[2].FindControl("txtUnitCost");
          TextBox textBox3 = (TextBox) this.gvItem.Rows[index1].Cells[3].FindControl("txtQty");
          DropDownList dropDownList2 = (DropDownList) this.gvItem.Rows[index1].Cells[4].FindControl("ddlItemTax1");
          DropDownList dropDownList3 = (DropDownList) this.gvItem.Rows[index1].Cells[5].FindControl("ddlItemTax2");
          Label label = (Label) this.gvItem.Rows[index1].Cells[6].FindControl("lblItemLineTotal");
          dropDownList1.SelectedValue = this.objEstimateItemDetailDT.Rows[index2]["ItemID"].ToString();
          textBox1.Text = this.objEstimateItemDetailDT.Rows[index2]["ItemDesc"].ToString();
          if (!string.IsNullOrEmpty(this.objEstimateItemDetailDT.Rows[index2]["Tax1"].ToString()))
            dropDownList2.SelectedValue = this.objEstimateItemDetailDT.Rows[index2]["Tax1"].ToString();
          if (!string.IsNullOrEmpty(this.objEstimateItemDetailDT.Rows[index2]["Tax2"].ToString()))
            dropDownList3.SelectedValue = this.objEstimateItemDetailDT.Rows[index2]["Tax2"].ToString();
          textBox2.Text = !string.IsNullOrEmpty(this.objEstimateItemDetailDT.Rows[index2]["UnitCost"].ToString()) ? this.objEstimateItemDetailDT.Rows[index2]["UnitCost"].ToString() : "0.00";
          textBox3.Text = !string.IsNullOrEmpty(this.objEstimateItemDetailDT.Rows[index2]["Quantity"].ToString()) ? this.objEstimateItemDetailDT.Rows[index2]["Quantity"].ToString() : "0.00";
          label.Text = !string.IsNullOrEmpty(this.objEstimateItemDetailDT.Rows[index2]["Total"].ToString()) ? this.objEstimateItemDetailDT.Rows[index2]["Total"].ToString() : "0.00";
          ++index1;
        }
        for (int index2 = 0; index2 < this.gvItem.Rows.Count; ++index2)
        {
          TextBox textBox1 = (TextBox) this.gvItem.Rows[index2].Cells[2].FindControl("txtUnitCost");
          TextBox textBox2 = (TextBox) this.gvItem.Rows[index2].Cells[3].FindControl("txtQty");
          DropDownList dropDownList1 = (DropDownList) this.gvItem.Rows[index2].Cells[4].FindControl("ddlItemTax1");
          DropDownList dropDownList2 = (DropDownList) this.gvItem.Rows[index2].Cells[5].FindControl("ddlItemTax2");
          Label label1 = (Label) this.gvItem.Rows[index2].Cells[4].FindControl("lblItemTax1");
          Label label2 = (Label) this.gvItem.Rows[index2].Cells[5].FindControl("lblItemTax2");
          Label label3 = (Label) this.gvItem.Rows[index2].Cells[6].FindControl("lblItemLineTotal");
          if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
          {
            Decimal hours = Decimal.Parse(textBox1.Text);
            Decimal rate = Decimal.Parse(textBox2.Text);
            string s = Decimal.Round(EstimateMaster.CalculateRowTotal(hours, rate), 2).ToString();
            label3.Text = Decimal.Round(EstimateMaster.CalculateRowTotal(hours, rate), 2).ToString();
            if (dropDownList1.SelectedIndex > 0)
            {
              this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(dropDownList1.SelectedItem.Value));
              if (this.objTaxMasterDT.Rows.Count > 0)
              {
                label1.Text = this.objTaxMasterDT.Rows[0]["TaxRate"].ToString();
                Decimal d = Decimal.Parse(s) * Decimal.Parse(label1.Text) / new Decimal(100);
                label1.Text = Decimal.Round(d, 2).ToString();
              }
            }
            if (dropDownList2.SelectedIndex > 0)
            {
              this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(dropDownList2.SelectedItem.Value));
              if (this.objTaxMasterDT.Rows.Count > 0)
              {
                label2.Text = this.objTaxMasterDT.Rows[0]["TaxRate"].ToString();
                Decimal d = Decimal.Parse(s) * Decimal.Parse(label2.Text) / new Decimal(100);
                label2.Text = Decimal.Round(d, 2).ToString();
              }
            }
          }
        }
      }
      this.objEstimateTaskDetailDT = this.objEstimateTaskDetailBll.GetDataByEstimateID(int.Parse(this.hfEstimateID.Value));
      if (this.objEstimateTaskDetailDT.Rows.Count > 0)
      {
        int index1 = 0;
        for (int index2 = 0; index2 < this.objEstimateTaskDetailDT.Rows.Count; ++index2)
        {
          this.AddNewTaskRow();
          DropDownList dropDownList1 = (DropDownList) this.gvTask.Rows[index1].Cells[0].FindControl("ddlTask");
          TextBox textBox1 = (TextBox) this.gvTask.Rows[index1].Cells[1].FindControl("txtDesc");
          TextBox textBox2 = (TextBox) this.gvTask.Rows[index1].Cells[2].FindControl("txtRate");
          TextBox textBox3 = (TextBox) this.gvTask.Rows[index1].Cells[3].FindControl("txtHours");
          DropDownList dropDownList2 = (DropDownList) this.gvTask.Rows[index1].Cells[4].FindControl("ddlTaskTax1");
          DropDownList dropDownList3 = (DropDownList) this.gvTask.Rows[index1].Cells[5].FindControl("ddlTaskTax2");
          Label label = (Label) this.gvTask.Rows[index1].Cells[6].FindControl("lblTaskLineTotal");
          dropDownList1.SelectedValue = this.objEstimateTaskDetailDT.Rows[index2]["TaskID"].ToString();
          textBox1.Text = this.objEstimateTaskDetailDT.Rows[index2]["TaskDesc"].ToString();
          textBox2.Text = !string.IsNullOrEmpty(this.objEstimateTaskDetailDT.Rows[index2]["Rate"].ToString()) ? this.objEstimateTaskDetailDT.Rows[index2]["Rate"].ToString() : "0.00";
          textBox3.Text = !string.IsNullOrEmpty(this.objEstimateTaskDetailDT.Rows[index2]["Hours"].ToString()) ? this.objEstimateTaskDetailDT.Rows[index2]["Hours"].ToString() : "0.00";
          label.Text = !string.IsNullOrEmpty(this.objEstimateTaskDetailDT.Rows[index2]["Total"].ToString()) ? this.objEstimateTaskDetailDT.Rows[index2]["Total"].ToString() : "0.00";
          if (!string.IsNullOrEmpty(this.objEstimateTaskDetailDT.Rows[index2]["Tax1"].ToString()))
            dropDownList2.SelectedValue = this.objEstimateTaskDetailDT.Rows[index2]["Tax1"].ToString();
          if (!string.IsNullOrEmpty(this.objEstimateTaskDetailDT.Rows[index2]["Tax2"].ToString()))
            dropDownList3.SelectedValue = this.objEstimateTaskDetailDT.Rows[index2]["Tax2"].ToString();
          ++index1;
        }
        for (int index2 = 0; index2 < this.gvTask.Rows.Count; ++index2)
        {
          TextBox textBox1 = (TextBox) this.gvTask.Rows[index2].Cells[2].FindControl("txtRate");
          TextBox textBox2 = (TextBox) this.gvTask.Rows[index2].Cells[3].FindControl("txtHours");
          DropDownList dropDownList1 = (DropDownList) this.gvTask.Rows[index2].Cells[4].FindControl("ddlTaskTax1");
          DropDownList dropDownList2 = (DropDownList) this.gvTask.Rows[index2].Cells[5].FindControl("ddlTaskTax2");
          Label label1 = (Label) this.gvTask.Rows[index2].Cells[4].FindControl("lblTaskTax1");
          Label label2 = (Label) this.gvTask.Rows[index2].Cells[5].FindControl("lblTaskTax2");
          Label label3 = (Label) this.gvTask.Rows[index2].Cells[6].FindControl("lblTaskLineTotal");
          if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
          {
            Decimal hours = Decimal.Parse(textBox2.Text);
            Decimal rate = Decimal.Parse(textBox1.Text);
            string s = Decimal.Round(EstimateMaster.CalculateRowTotal(hours, rate), 2).ToString();
            label3.Text = Decimal.Round(EstimateMaster.CalculateRowTotal(hours, rate), 2).ToString();
            if (dropDownList1.SelectedIndex > 0)
            {
              this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(dropDownList1.SelectedItem.Value));
              if (this.objTaxMasterDT.Rows.Count > 0)
              {
                label1.Text = this.objTaxMasterDT.Rows[0]["TaxRate"].ToString();
                Decimal d = Decimal.Parse(s) * Decimal.Parse(label1.Text) / new Decimal(100);
                label1.Text = Decimal.Round(d, 2).ToString();
              }
            }
            if (dropDownList2.SelectedIndex > 0)
            {
              this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(dropDownList2.SelectedItem.Value));
              if (this.objTaxMasterDT.Rows.Count > 0)
              {
                label2.Text = this.objTaxMasterDT.Rows[0]["TaxRate"].ToString();
                Decimal d = Decimal.Parse(s) * Decimal.Parse(label2.Text) / new Decimal(100);
                label2.Text = Decimal.Round(d, 2).ToString();
              }
            }
          }
        }
      }
      this.CalculateTotal();
    }

    private void Clear()
    {
      this.ddlClient.SelectedIndex = 0;
      this.ddlClient.Focus();
    }

    private void SetDefaultValues()
    {
      this.txtDateOfIssue.Text = DateTime.Now.ToString("MM/dd/yyyy");
      this.objTermsDT = this.objTermsBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objTermsDT.Rows.Count > 0)
        this.txtTerms.Text = this.txtDefaultTerms.Text = this.objTermsDT.Rows[0]["DefaultTerms"].ToString();
      this.objEstimateMasterDT = this.objEstimateMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objEstimateMasterDT.Rows.Count > 0)
        this.txtEstimateNum.Text = EstimateMaster.NextNum(this.objEstimateMasterDT.Rows[this.objEstimateMasterDT.Rows.Count - 1]["EstimateNumber"].ToString());
      else
        this.txtEstimateNum.Text = ConfigurationManager.AppSettings["InvoiceNoStart"];
    }

    private static string NextNum(string invNum)
    {
      string str1;
      if (invNum.Trim().Length > 1)
      {
        char ch1 = invNum[invNum.Length - 1];
        string str2 = invNum.Remove(invNum.Length - 1, 1);
        char ch2;
        switch (ch1)
        {
          case '0':
          case '1':
          case '2':
          case '3':
          case '4':
          case '5':
          case '6':
          case '7':
          case '8':
          case '9':
            str2 += (int.Parse(ch1.ToString()) + 1).ToString();
            ch2 = Convert.ToChar(" ");
            break;
          case 'Z':
            ch2 = 'A';
            str2 += "1";
            break;
          case 'z':
            ch2 = 'a';
            str2 += "1";
            break;
          default:
            ch2 = (char) ((uint) ch1 + 1U);
            break;
        }
        str1 = (str2 + (object) ch2).Trim();
      }
      else
      {
        string str2 = string.Empty;
        char ch1 = invNum[invNum.Length - 1];
        string str3;
        switch (ch1)
        {
          case '0':
          case '1':
          case '2':
          case '3':
          case '4':
          case '5':
          case '6':
          case '7':
          case '8':
            str3 = (int.Parse(ch1.ToString()) + 1).ToString();
            break;
          case '9':
            str3 = "10";
            break;
          case 'Z':
            str3 = str2 + "1A";
            break;
          case 'z':
            str3 = str2 + "1a";
            break;
          default:
            char ch2;
            str3 = str2 + (object) (ch2 = (char) ((uint) ch1 + 1U));
            break;
        }
        str1 = str3;
      }
      return str1;
    }

    private void FirstGridRow()
    {
      this.txtDateOfIssue.Text = DateTime.Now.ToString("MM/dd/yyyy");
      DataTable dataTable1 = new DataTable();
      dataTable1.Columns.Add(new DataColumn("Colum1", typeof (string)));
      dataTable1.Columns.Add(new DataColumn("Colum2", typeof (string)));
      dataTable1.Columns.Add(new DataColumn("Colum3", typeof (string)));
      dataTable1.Columns.Add(new DataColumn("Colum4", typeof (string)));
      dataTable1.Columns.Add(new DataColumn("Colum5", typeof (string)));
      dataTable1.Columns.Add(new DataColumn("Colum6", typeof (string)));
      dataTable1.Columns.Add(new DataColumn("Colum7", typeof (string)));
      DataRow row1 = dataTable1.NewRow();
      DataRow row2 = dataTable1.NewRow();
      DataRow row3 = dataTable1.NewRow();
      row1["Colum1"] = row2["Colum1"] = row3["Colum1"] = (object) string.Empty;
      row1["Colum2"] = row2["Colum2"] = row3["Colum2"] = (object) string.Empty;
      row1["Colum3"] = row2["Colum3"] = row3["Colum3"] = (object) string.Empty;
      row1["Colum4"] = row2["Colum4"] = row3["Colum4"] = (object) string.Empty;
      row1["Colum5"] = row2["Colum5"] = row3["Colum5"] = (object) string.Empty;
      row1["Colum6"] = row2["Colum6"] = row3["Colum6"] = (object) string.Empty;
      row1["Colum7"] = row2["Colum7"] = row3["Colum7"] = (object) string.Empty;
      dataTable1.Rows.Add(row1);
      dataTable1.Rows.Add(row2);
      dataTable1.Rows.Add(row3);
      this.ViewState["TaskTable"] = (object) dataTable1;
      this.gvTask.DataSource = (object) dataTable1;
      this.gvTask.DataBind();
      DataTable dataTable2 = new DataTable();
      dataTable2.Columns.Add(new DataColumn("Colum1", typeof (string)));
      dataTable2.Columns.Add(new DataColumn("Colum2", typeof (string)));
      dataTable2.Columns.Add(new DataColumn("Colum3", typeof (string)));
      dataTable2.Columns.Add(new DataColumn("Colum4", typeof (string)));
      dataTable2.Columns.Add(new DataColumn("Colum5", typeof (string)));
      dataTable2.Columns.Add(new DataColumn("Colum6", typeof (string)));
      dataTable2.Columns.Add(new DataColumn("Colum7", typeof (string)));
      DataRow row4 = dataTable2.NewRow();
      DataRow row5 = dataTable2.NewRow();
      DataRow row6 = dataTable2.NewRow();
      row4["Colum1"] = row5["Colum1"] = row6["Colum1"] = (object) string.Empty;
      row4["Colum2"] = row5["Colum2"] = row6["Colum2"] = (object) string.Empty;
      row4["Colum3"] = row5["Colum3"] = row6["Colum3"] = (object) string.Empty;
      row4["Colum4"] = row5["Colum4"] = row6["Colum4"] = (object) string.Empty;
      row4["Colum5"] = row5["Colum5"] = row6["Colum5"] = (object) string.Empty;
      row4["Colum6"] = row5["Colum6"] = row6["Colum6"] = (object) string.Empty;
      row4["Colum7"] = row5["Colum7"] = row6["Colum7"] = (object) string.Empty;
      dataTable2.Rows.Add(row4);
      dataTable2.Rows.Add(row5);
      dataTable2.Rows.Add(row6);
      this.ViewState["ItemTable"] = (object) dataTable2;
      this.gvItem.DataSource = (object) dataTable2;
      this.gvItem.DataBind();
    }

    private void FirstGridEditRow()
    {
      DataTable dataTable1 = new DataTable();
      dataTable1.Columns.Add(new DataColumn("Colum1", typeof (string)));
      dataTable1.Columns.Add(new DataColumn("Colum2", typeof (string)));
      dataTable1.Columns.Add(new DataColumn("Colum3", typeof (string)));
      dataTable1.Columns.Add(new DataColumn("Colum4", typeof (string)));
      dataTable1.Columns.Add(new DataColumn("Colum5", typeof (string)));
      dataTable1.Columns.Add(new DataColumn("Colum6", typeof (string)));
      dataTable1.Columns.Add(new DataColumn("Colum7", typeof (string)));
      DataRow row1 = dataTable1.NewRow();
      row1["Colum1"] = (object) string.Empty;
      row1["Colum2"] = (object) string.Empty;
      row1["Colum3"] = (object) string.Empty;
      row1["Colum4"] = (object) string.Empty;
      row1["Colum5"] = (object) string.Empty;
      row1["Colum6"] = (object) string.Empty;
      row1["Colum7"] = (object) string.Empty;
      dataTable1.Rows.Add(row1);
      this.ViewState["TaskTable"] = (object) dataTable1;
      this.gvTask.DataSource = (object) dataTable1;
      this.gvTask.DataBind();
      DataTable dataTable2 = new DataTable();
      dataTable2.Columns.Add(new DataColumn("Colum1", typeof (string)));
      dataTable2.Columns.Add(new DataColumn("Colum2", typeof (string)));
      dataTable2.Columns.Add(new DataColumn("Colum3", typeof (string)));
      dataTable2.Columns.Add(new DataColumn("Colum4", typeof (string)));
      dataTable2.Columns.Add(new DataColumn("Colum5", typeof (string)));
      dataTable2.Columns.Add(new DataColumn("Colum6", typeof (string)));
      dataTable2.Columns.Add(new DataColumn("Colum7", typeof (string)));
      DataRow row2 = dataTable2.NewRow();
      row2["Colum1"] = (object) string.Empty;
      row2["Colum2"] = (object) string.Empty;
      row2["Colum3"] = (object) string.Empty;
      row2["Colum4"] = (object) string.Empty;
      row2["Colum5"] = (object) string.Empty;
      row2["Colum6"] = (object) string.Empty;
      row2["Colum7"] = (object) string.Empty;
      dataTable2.Rows.Add(row2);
      this.ViewState["ItemTable"] = (object) dataTable2;
      this.gvItem.DataSource = (object) dataTable2;
      this.gvItem.DataBind();
    }

    protected void lblEditAddress_OnClick(object sender, EventArgs e)
    {
      this.ClearClient();
      this.normalDetails.Visible = false;
      this.clienDetails.Visible = true;
      this.lblBoxClientInfo.Text = "You are updating client details.";
      this.lblBoxClientFor.Text = "Edit Client";
      this.chkBoxClientChange.Visible = true;
      this.btnBoxUpdate.Visible = true;
      this.btnBoxSave.Visible = false;
      this.SetClientData(this.ddlClient.SelectedItem.Value);
    }

    private void SetClientData(string cID)
    {
      this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(cID));
      if (this.objCompanyClientMasterDT.Rows.Count <= 0)
        return;
      this.hfCompanyClientID.Value = this.objCompanyClientMasterDT.Rows[0]["CompanyClientID"].ToString();
      this.txtBoxClientOrganization.Text = this.objCompanyClientMasterDT.Rows[0]["OrganizationName"].ToString();
      this.txtBoxClientEmail.Text = this.objCompanyClientMasterDT.Rows[0]["Email"].ToString();
      this.txtBoxClientFirstName.Text = this.objCompanyClientMasterDT.Rows[0]["FirstName"].ToString();
      this.txtBoxClientLastName.Text = this.objCompanyClientMasterDT.Rows[0]["LastName"].ToString();
      this.txtBoxClientAddress1.Text = this.objCompanyClientMasterDT.Rows[0]["Address1"].ToString();
      this.txtBoxClientAddress2.Text = this.objCompanyClientMasterDT.Rows[0]["Address2"].ToString();
      this.txtBoxClientZipcode.Text = this.objCompanyClientMasterDT.Rows[0]["ZipCode"].ToString();
      this.txtBoxClientEmail.Enabled = false;
      string text = this.objCompanyClientMasterDT.Rows[0]["CompanySize"].ToString();
      string s1 = this.objCompanyClientMasterDT.Rows[0]["CountryID"].ToString();
      string s2 = this.objCompanyClientMasterDT.Rows[0]["StateID"].ToString();
      string s3 = this.objCompanyClientMasterDT.Rows[0]["CityID"].ToString();
      string s4 = this.objCompanyClientMasterDT.Rows[0]["IndustryID"].ToString();
      this.ddlCompanySize.SelectedIndex = this.ddlCompanySize.Items.IndexOf(this.ddlCompanySize.Items.FindByText(text));
      if (!string.IsNullOrEmpty(s4))
      {
        this.objIndustryMasterDT = this.objIndustryMasterBll.GetDataByIndustryID(int.Parse(s4));
        if (this.objIndustryMasterDT.Rows.Count > 0)
        {
          this.ddlIndustry.Items.Add(this.objIndustryMasterDT.Rows[0]["IndustryID"].ToString());
          this.ddlIndustry.SelectedValue = this.objIndustryMasterDT.Rows[0]["IndustryID"].ToString();
        }
      }
      if (!string.IsNullOrEmpty(s1))
      {
        this.objCountryMasterDT = this.objCountryMasterBll.GetDataByCountryID(int.Parse(s1));
        if (this.objCountryMasterDT.Rows.Count > 0)
        {
          this.ddlBoxClientCountry.Items.Add(this.objCountryMasterDT.Rows[0]["CountryID"].ToString());
          this.ddlBoxClientCountry.SelectedValue = this.objCountryMasterDT.Rows[0]["CountryID"].ToString();
        }
      }
      if (!string.IsNullOrEmpty(s2))
      {
        this.objStateMasterDT = this.objStateMasterBll.GetDataByStateID(int.Parse(s2));
        if (this.objStateMasterDT.Rows.Count > 0)
        {
          this.ddlBoxClientState.Items.Add(this.objStateMasterDT.Rows[0]["StateID"].ToString());
          this.ddlBoxClientState.SelectedValue = this.objStateMasterDT.Rows[0]["StateID"].ToString();
        }
      }
      if (string.IsNullOrEmpty(s3))
        return;
      this.objCityMasterDT = this.objCityMasterBll.GetDataByCityID(int.Parse(s3));
      if (this.objCityMasterDT.Rows.Count <= 0)
        return;
      this.ddlBoxClientCity.Items.Add(this.objCityMasterDT.Rows[0]["CityID"].ToString());
      this.ddlBoxClientCity.SelectedValue = this.objCityMasterDT.Rows[0]["CityID"].ToString();
    }

    private void ClearClient()
    {
      this.txtBoxClientFirstName.Text = this.txtBoxClientLastName.Text = this.txtBoxClientAddress1.Text = "";
      this.txtBoxClientAddress2.Text = this.txtBoxClientZipcode.Text = "";
      this.txtBoxClientOrganization.Text = this.txtBoxClientEmail.Text = "";
      this.lblBoxClientInfo.Text = this.lblBoxClientFor.Text = "";
      this.txtBoxClientEmail.Focus();
    }

    protected void lnkBoxClose_OnClick(object sender, EventArgs e)
    {
      this.ddlClient.SelectedIndex = 0;
      this.ddlClient_SelectedIndexChanged((object) null, (EventArgs) null);
      this.ddlClient.Focus();
    }

    protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.clientAddress.Visible = false;
      this.normalDetails.Visible = true;
      this.clienDetails.Visible = false;
      if (this.ddlClient.SelectedValue == "-1")
      {
        this.ClearClient();
        this.sqldsCountry.DataBind();
        this.sqldsState.DataBind();
        this.sqldsCity.DataBind();
        this.sqldsIndustry.DataBind();
        this.ddlBoxClientCountry.DataBind();
        this.ddlBoxClientState.DataBind();
        this.ddlBoxClientCity.DataBind();
        this.ddlIndustry.DataBind();
        this.ddlBoxClientCountry.SelectedIndex = this.ddlBoxClientState.SelectedIndex = this.ddlBoxClientCity.SelectedIndex = 0;
        this.ddlCompanySize.SelectedIndex = this.ddlIndustry.SelectedIndex = 0;
        this.normalDetails.Visible = false;
        this.clienDetails.Visible = true;
        this.lblBoxClientInfo.Text = "You are creating a new client.";
        this.lblBoxClientFor.Text = "New Client";
        this.btnBoxUpdate.Visible = false;
        this.btnBoxSave.Visible = true;
        this.chkBoxClientChange.Visible = false;
      }
      if (this.ddlClient.SelectedValue != "-1" && this.ddlClient.SelectedValue != "-2" && this.normalDetails.Visible)
      {
        this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(this.ddlClient.SelectedValue));
        if (this.objCompanyClientMasterDT.Rows.Count > 0)
        {
          string str1 = string.Empty;
          string s1 = this.objCompanyClientMasterDT.Rows[0]["CurrencyID"].ToString();
          string s2 = this.objCompanyClientMasterDT.Rows[0]["CountryID"].ToString();
          string s3 = this.objCompanyClientMasterDT.Rows[0]["CityID"].ToString();
          string str2 = str1 + this.objCompanyClientMasterDT.Rows[0]["Address1"] + "<br />" + this.objCompanyClientMasterDT.Rows[0]["Address2"] + "<br />";
          if (!string.IsNullOrEmpty(s1))
          {
            this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(s1));
            if (this.objCurrencyMasterDT.Rows.Count > 0)
            {
              this.ddlCurrency.Items.Add(this.objCurrencyMasterDT.Rows[0]["CurrencyID"].ToString());
              this.ddlCurrency.SelectedValue = this.objCurrencyMasterDT.Rows[0]["CurrencyID"].ToString();
              this.ddlCurrency_SelectedIndexChanged(sender, e);
            }
          }
          if (!string.IsNullOrEmpty(s3))
          {
            this.objCityMasterDT = this.objCityMasterBll.GetDataByCityID(int.Parse(s3));
            str2 = str2 + this.objCityMasterDT.Rows[0]["CityName"] + "&nbsp;&nbsp;";
          }
          string str3 = str2 + this.objCompanyClientMasterDT.Rows[0]["ZipCode"] + "<br />";
          if (!string.IsNullOrEmpty(s2))
          {
            this.objCountryMasterDT = this.objCountryMasterBll.GetDataByCountryID(int.Parse(s2));
            str3 = str3 + this.objCountryMasterDT.Rows[0]["CountryName"] + "<br />";
          }
          this.lblAddress.Text = !string.IsNullOrEmpty(s2 + (object) s3 + (string) this.objCompanyClientMasterDT.Rows[0]["Address1"] + (string) this.objCompanyClientMasterDT.Rows[0]["Address2"] + (string) this.objCompanyClientMasterDT.Rows[0]["ZipCode"]) ? str3 : "<i>No mailing address specified for this client.</i>";
          this.clientAddress.Visible = true;
        }
      }
      this.CalculateTotal();
    }

    protected void ddlTask_OnSelectedIndexChanged(object sender, EventArgs e)
    {
      DropDownList dropDownList = (DropDownList) sender;
      GridViewRow gridViewRow = (GridViewRow) dropDownList.Parent.Parent;
      TextBox textBox1 = (TextBox) gridViewRow.Cells[1].FindControl("txtDesc");
      TextBox textBox2 = (TextBox) gridViewRow.Cells[2].FindControl("txtRate");
      TextBox textBox3 = (TextBox) gridViewRow.Cells[3].FindControl("txtHours");
      Label label = (Label) gridViewRow.Cells[6].FindControl("lblTaskLineTotal");
      if (dropDownList.SelectedIndex > 0)
      {
        this.objTaskMasterDT = this.objTaskMasterBll.GetDataByTaskID(int.Parse(dropDownList.SelectedItem.Value));
        if (this.objTaskMasterDT.Rows.Count > 0)
        {
          textBox1.Text = this.objTaskMasterDT.Rows[0]["TaskDesc"].ToString();
          textBox2.Text = this.objTaskMasterDT.Rows[0]["RatePerHours"].ToString();
          textBox3.Text = "0";
          label.Text = "0.00";
          textBox1.Focus();
        }
        else
        {
          dropDownList.SelectedIndex = 0;
          textBox1.Text = "";
          textBox2.Text = "0.00";
          textBox3.Text = "0";
          label.Text = "0.00";
          dropDownList.Focus();
        }
      }
      this.CalculateTotal();
    }

    protected void txtRate_OnTextChanged(object sender, EventArgs e)
    {
      GridViewRow gvr = (GridViewRow) ((Control) sender).Parent.Parent;
      this.CalculateWholeTaskRow(gvr);
      gvr.Cells[3].FindControl("txtHours").Focus();
    }

    protected void txtHours_OnTextChanged(object sender, EventArgs e)
    {
      GridViewRow gvr = (GridViewRow) ((Control) sender).Parent.Parent;
      this.CalculateWholeTaskRow(gvr);
      gvr.Cells[4].FindControl("ddlTaskTax1").Focus();
    }

    protected void ddlTaskTax1_OnSelectedIndexChanged(object sender, EventArgs e)
    {
      GridViewRow gvr = (GridViewRow) ((Control) sender).Parent.Parent;
      this.CalculateWholeTaskRow(gvr);
      gvr.Cells[5].FindControl("ddlTaskTax2").Focus();
    }

    protected void ddlTaskTax2_OnSelectedIndexChanged(object sender, EventArgs e)
    {
      DropDownList dropDownList = (DropDownList) sender;
      this.CalculateWholeTaskRow((GridViewRow) dropDownList.Parent.Parent);
      dropDownList.Focus();
    }

    protected void ddlItem_OnSelectedIndexChanged(object sender, EventArgs e)
    {
      DropDownList dropDownList1 = (DropDownList) sender;
      GridViewRow gvr = (GridViewRow) dropDownList1.Parent.Parent;
      TextBox textBox1 = (TextBox) gvr.Cells[1].FindControl("txtItemDesc");
      TextBox textBox2 = (TextBox) gvr.Cells[2].FindControl("txtUnitCost");
      TextBox textBox3 = (TextBox) gvr.Cells[3].FindControl("txtQty");
      DropDownList dropDownList2 = (DropDownList) gvr.Cells[4].FindControl("ddlItemTax1");
      DropDownList dropDownList3 = (DropDownList) gvr.Cells[5].FindControl("ddlItemTax2");
      Label label = (Label) gvr.Cells[6].FindControl("lblItemLineTotal");
      if (dropDownList1.SelectedIndex > 0)
      {
        this.objItemMasterDT = this.objItemMasterBll.GetDataByItemID(int.Parse(dropDownList1.SelectedItem.Value));
        if (this.objItemMasterDT.Rows.Count > 0)
        {
          string str1 = this.objItemMasterDT.Rows[0]["TaxID1"].ToString();
          string str2 = this.objItemMasterDT.Rows[0]["TaxID2"].ToString();
          if (!string.IsNullOrEmpty(str1))
            dropDownList2.SelectedValue = str1;
          if (!string.IsNullOrEmpty(str2))
            dropDownList3.SelectedValue = str2;
          textBox1.Text = this.objItemMasterDT.Rows[0]["Description"].ToString();
          textBox2.Text = this.objItemMasterDT.Rows[0]["UnitCost"].ToString();
          textBox3.Text = this.objItemMasterDT.Rows[0]["Quantity"].ToString();
          label.Text = Decimal.Round(EstimateMaster.CalculateRowTotal(Decimal.Parse(textBox2.Text), Decimal.Parse(textBox3.Text)), 2).ToString();
          textBox1.Focus();
          this.CalculateWholeItemRow(gvr);
        }
        else
        {
          dropDownList1.SelectedIndex = 0;
          textBox1.Text = "";
          textBox2.Text = "0.00";
          textBox3.Text = "0";
          label.Text = "0.00";
          dropDownList1.Focus();
        }
      }
      this.CalculateTotal();
    }

    protected void txtUnitCost_OnTextChanged(object sender, EventArgs e)
    {
      GridViewRow gvr = (GridViewRow) ((Control) sender).Parent.Parent;
      TextBox textBox = (TextBox) gvr.Cells[3].FindControl("txtQty");
      this.CalculateWholeItemRow(gvr);
      textBox.Focus();
    }

    protected void txtQty_OnTextChanged(object sender, EventArgs e)
    {
      GridViewRow gvr = (GridViewRow) ((Control) sender).Parent.Parent;
      DropDownList dropDownList = (DropDownList) gvr.Cells[4].FindControl("ddlItemTax1");
      this.CalculateWholeItemRow(gvr);
      dropDownList.Focus();
    }

    protected void ddlItemTax1_OnSelectedIndexChanged(object sender, EventArgs e)
    {
      GridViewRow gvr = (GridViewRow) ((Control) sender).Parent.Parent;
      this.CalculateWholeItemRow(gvr);
      gvr.Cells[5].FindControl("ddlItemTax2").Focus();
    }

    protected void ddlItemTax2_OnSelectedIndexChanged(object sender, EventArgs e)
    {
      DropDownList dropDownList = (DropDownList) sender;
      this.CalculateWholeItemRow((GridViewRow) dropDownList.Parent.Parent);
      dropDownList.Focus();
    }

    private static Decimal CalculateRowTotal(Decimal hours, Decimal rate)
    {
      return hours * rate;
    }

    private void CalculateTotal()
    {
      Hashtable hashtable = new Hashtable();
      this.divTaxValue.Controls.Clear();
      this.divTax.Controls.Clear();
      Decimal num1 = new Decimal(0);
      Decimal d1 = new Decimal(0);
      this.lblAddedTaxes.Text = "0.00";
      if (this.gvTask.Rows.Count > 0)
      {
        for (int index = 0; index < this.gvTask.Rows.Count; ++index)
        {
          Label label1 = (Label) this.gvTask.Rows[index].Cells[4].FindControl("lblTaskTax1");
          Label label2 = (Label) this.gvTask.Rows[index].Cells[5].FindControl("lblTaskTax2");
          Label label3 = (Label) this.gvTask.Rows[index].Cells[6].FindControl("lblTaskLineTotal");
          DropDownList dropDownList1 = (DropDownList) this.gvTask.Rows[index].Cells[4].FindControl("ddlTaskTax1");
          DropDownList dropDownList2 = (DropDownList) this.gvTask.Rows[index].Cells[5].FindControl("ddlTaskTax2");
          if (string.IsNullOrEmpty(label1.Text))
            label1.Text = "0.00";
          if (string.IsNullOrEmpty(label2.Text))
            label2.Text = "0.00";
          if (dropDownList1.SelectedIndex > 0)
          {
            this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(dropDownList1.SelectedItem.Value));
            if (this.objTaxMasterDT.Rows.Count > 0)
            {
              string str = string.Concat(new object[4]
              {
                this.objTaxMasterDT.Rows[0]["TaxName"],
                (object) "(",
                this.objTaxMasterDT.Rows[0]["TaxRate"],
                (object) ")"
              });
              Decimal num2 = Decimal.Parse(label1.Text);
              if (hashtable.ContainsKey((object) str))
              {
                object obj = hashtable[(object) str];
                num2 += Decimal.Parse(obj.ToString());
                hashtable.Remove((object) str);
                hashtable.Add((object) str, (object) num2.ToString());
              }
              else
                hashtable.Add((object) str, (object) num2.ToString());
            }
          }
          if (dropDownList1.SelectedIndex > 0)
          {
            this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(dropDownList2.SelectedItem.Value));
            if (this.objTaxMasterDT.Rows.Count > 0)
            {
              string str = string.Concat(new object[4]
              {
                this.objTaxMasterDT.Rows[0]["TaxName"],
                (object) "(",
                this.objTaxMasterDT.Rows[0]["TaxRate"],
                (object) ")"
              });
              Decimal num2 = Decimal.Parse(label2.Text);
              if (hashtable.ContainsKey((object) str))
              {
                object obj = hashtable[(object) str];
                num2 += Decimal.Parse(obj.ToString());
                hashtable.Remove((object) str);
                hashtable.Add((object) str, (object) num2.ToString());
              }
              else
                hashtable.Add((object) str, (object) num2.ToString());
            }
          }
          if (!string.IsNullOrEmpty(label3.Text))
          {
            num1 += Decimal.Parse(label3.Text);
            d1 += Decimal.Parse(label3.Text);
          }
          if (!string.IsNullOrEmpty(label1.Text))
          {
            num1 += Decimal.Parse(label1.Text);
            this.lblAddedTaxes.Text = (Decimal.Parse(this.lblAddedTaxes.Text) + Decimal.Parse(label1.Text)).ToString();
          }
          if (!string.IsNullOrEmpty(label2.Text))
          {
            num1 += Decimal.Parse(label2.Text);
            this.lblAddedTaxes.Text = (Decimal.Parse(this.lblAddedTaxes.Text) + Decimal.Parse(label2.Text)).ToString();
          }
        }
      }
      if (this.gvItem.Rows.Count > 0)
      {
        for (int index = 0; index < this.gvItem.Rows.Count; ++index)
        {
          Label label1 = (Label) this.gvItem.Rows[index].Cells[4].FindControl("lblItemTax1");
          Label label2 = (Label) this.gvItem.Rows[index].Cells[5].FindControl("lblItemTax2");
          Label label3 = (Label) this.gvItem.Rows[index].Cells[6].FindControl("lblItemLineTotal");
          DropDownList dropDownList1 = (DropDownList) this.gvItem.Rows[index].Cells[4].FindControl("ddlItemTax1");
          DropDownList dropDownList2 = (DropDownList) this.gvItem.Rows[index].Cells[5].FindControl("ddlItemTax2");
          if (string.IsNullOrEmpty(label1.Text))
            label1.Text = "0.00";
          if (string.IsNullOrEmpty(label2.Text))
            label2.Text = "0.00";
          if (dropDownList1.SelectedIndex > 0)
          {
            this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(dropDownList1.SelectedItem.Value));
            if (this.objTaxMasterDT.Rows.Count > 0)
            {
              string str = string.Concat(new object[4]
              {
                this.objTaxMasterDT.Rows[0]["TaxName"],
                (object) "(",
                this.objTaxMasterDT.Rows[0]["TaxRate"],
                (object) ")"
              });
              Decimal num2 = Decimal.Parse(label1.Text);
              if (hashtable.ContainsKey((object) str))
              {
                object obj = hashtable[(object) str];
                num2 += Decimal.Parse(obj.ToString());
                hashtable.Remove((object) str);
                hashtable.Add((object) str, (object) num2.ToString());
              }
              else
                hashtable.Add((object) str, (object) num2.ToString());
            }
          }
          if (dropDownList2.SelectedIndex > 0)
          {
            this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(dropDownList2.SelectedItem.Value));
            if (this.objTaxMasterDT.Rows.Count > 0)
            {
              string str = string.Concat(new object[4]
              {
                this.objTaxMasterDT.Rows[0]["TaxName"],
                (object) "(",
                this.objTaxMasterDT.Rows[0]["TaxRate"],
                (object) ")"
              });
              Decimal num2 = Decimal.Parse(label2.Text);
              if (hashtable.ContainsKey((object) str))
              {
                object obj = hashtable[(object) str];
                num2 += Decimal.Parse(obj.ToString());
                hashtable.Remove((object) str);
                hashtable.Add((object) str, (object) num2.ToString());
              }
              else
                hashtable.Add((object) str, (object) num2.ToString());
            }
          }
          if (!string.IsNullOrEmpty(label3.Text))
          {
            num1 += Decimal.Parse(label3.Text);
            d1 += Decimal.Parse(label3.Text);
          }
          if (!string.IsNullOrEmpty(label1.Text))
          {
            num1 += Decimal.Parse(label1.Text);
            this.lblAddedTaxes.Text = (Decimal.Parse(this.lblAddedTaxes.Text) + Decimal.Parse(label1.Text)).ToString();
          }
          if (!string.IsNullOrEmpty(label2.Text))
          {
            num1 += Decimal.Parse(label2.Text);
            this.lblAddedTaxes.Text = (Decimal.Parse(this.lblAddedTaxes.Text) + Decimal.Parse(label2.Text)).ToString();
          }
        }
      }
      this.lblSubTotal.Text = Decimal.Round(d1, 2).ToString();
      Decimal d2 = Decimal.Parse(this.lblSubTotal.Text) * Decimal.Parse(this.txtDiscount.Text) / new Decimal(100);
      this.lblDiscount.Text = Decimal.Round(d2, 2).ToString();
      Label label4 = this.lblEstimateTotal;
      Label label5 = this.lblBalance;
      Decimal num3 = num1 - Decimal.Round(d2, 2);
      string str1;
      string str2 = str1 = num3.ToString();
      label5.Text = str1;
      string str3 = str2;
      label4.Text = str3;
      if (hashtable.Count <= 0)
        return;
      foreach (string str4 in (IEnumerable) hashtable.Keys)
      {
        this.divTax.Controls.Add((Control) new Label()
        {
          Text = str4
        });
        this.divTax.Controls.Add((Control) new LiteralControl("<br />"));
      }
      foreach (object obj in (IEnumerable) hashtable.Values)
      {
        this.divTaxValue.Controls.Add((Control) new Label()
        {
          Text = ("+" + (object) Decimal.Round(Decimal.Parse(obj.ToString()), 2))
        });
        this.divTaxValue.Controls.Add((Control) new LiteralControl("<br />"));
      }
    }

    private void CalculateWholeTaskRow(GridViewRow gvr)
    {
      TextBox textBox1 = (TextBox) gvr.Cells[2].FindControl("txtRate");
      TextBox textBox2 = (TextBox) gvr.Cells[3].FindControl("txtHours");
      DropDownList dropDownList1 = (DropDownList) gvr.Cells[4].FindControl("ddlTaskTax1");
      DropDownList dropDownList2 = (DropDownList) gvr.Cells[5].FindControl("ddlTaskTax2");
      Label label1 = (Label) gvr.Cells[4].FindControl("lblTaskTax1");
      Label label2 = (Label) gvr.Cells[5].FindControl("lblTaskTax2");
      Label label3 = (Label) gvr.Cells[6].FindControl("lblTaskLineTotal");
      Decimal hours = Decimal.Parse(textBox2.Text);
      Decimal rate = Decimal.Parse(textBox1.Text);
      string s = Decimal.Round(EstimateMaster.CalculateRowTotal(hours, rate), 2).ToString();
      label3.Text = Decimal.Round(EstimateMaster.CalculateRowTotal(hours, rate), 2).ToString();
      if (dropDownList1.SelectedIndex > 0)
      {
        this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(dropDownList1.SelectedItem.Value));
        if (this.objTaxMasterDT.Rows.Count > 0)
        {
          label1.Text = this.objTaxMasterDT.Rows[0]["TaxRate"].ToString();
          Decimal num1 = Decimal.Parse(this.txtDiscount.Text);
          Decimal num2 = Decimal.Parse(s) * num1 / new Decimal(100);
          s = (Decimal.Parse(s) - num2).ToString();
          Decimal d = Decimal.Parse(s) * Decimal.Parse(label1.Text) / new Decimal(100);
          label1.Text = Decimal.Round(d, 2).ToString();
        }
      }
      else
        label1.Text = "0.00";
      if (dropDownList2.SelectedIndex > 0)
      {
        this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(dropDownList2.SelectedItem.Value));
        if (this.objTaxMasterDT.Rows.Count > 0)
        {
          label2.Text = this.objTaxMasterDT.Rows[0]["TaxRate"].ToString();
          Decimal num1 = Decimal.Parse(this.txtDiscount.Text);
          Decimal num2 = Decimal.Parse(s) * num1 / new Decimal(100);
          Decimal d = Decimal.Parse((Decimal.Parse(s) - num2).ToString()) * Decimal.Parse(label2.Text) / new Decimal(100);
          label2.Text = Decimal.Round(d, 2).ToString();
        }
      }
      else
        label2.Text = "0.00";
      this.CalculateTotal();
    }

    private void CalculateWholeItemRow(GridViewRow gvr)
    {
      TextBox textBox1 = (TextBox) gvr.Cells[2].FindControl("txtUnitCost");
      TextBox textBox2 = (TextBox) gvr.Cells[3].FindControl("txtQty");
      DropDownList dropDownList1 = (DropDownList) gvr.Cells[4].FindControl("ddlItemTax1");
      DropDownList dropDownList2 = (DropDownList) gvr.Cells[5].FindControl("ddlItemTax2");
      Label label1 = (Label) gvr.Cells[4].FindControl("lblItemTax1");
      Label label2 = (Label) gvr.Cells[5].FindControl("lblItemTax2");
      Label label3 = (Label) gvr.Cells[6].FindControl("lblItemLineTotal");
      Decimal hours = Decimal.Parse(textBox1.Text);
      Decimal rate = Decimal.Parse(textBox2.Text);
      string s = Decimal.Round(EstimateMaster.CalculateRowTotal(hours, rate), 2).ToString();
      label3.Text = Decimal.Round(EstimateMaster.CalculateRowTotal(hours, rate), 2).ToString();
      if (dropDownList1.SelectedIndex > 0)
      {
        this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(dropDownList1.SelectedItem.Value));
        if (this.objTaxMasterDT.Rows.Count > 0)
        {
          label1.Text = this.objTaxMasterDT.Rows[0]["TaxRate"].ToString();
          Decimal num1 = Decimal.Parse(this.txtDiscount.Text);
          Decimal num2 = Decimal.Parse(s) * num1 / new Decimal(100);
          s = (Decimal.Parse(s) - num2).ToString();
          Decimal d = Decimal.Parse(s) * Decimal.Parse(label1.Text) / new Decimal(100);
          label1.Text = Decimal.Round(d, 2).ToString();
        }
      }
      else
        label1.Text = "0.00";
      if (dropDownList2.SelectedIndex > 0)
      {
        this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(dropDownList2.SelectedItem.Value));
        if (this.objTaxMasterDT.Rows.Count > 0)
        {
          label2.Text = this.objTaxMasterDT.Rows[0]["TaxRate"].ToString();
          Decimal num1 = Decimal.Parse(this.txtDiscount.Text);
          Decimal num2 = Decimal.Parse(s) * num1 / new Decimal(100);
          Decimal d = Decimal.Parse((Decimal.Parse(s) - num2).ToString()) * Decimal.Parse(label2.Text) / new Decimal(100);
          label2.Text = Decimal.Round(d, 2).ToString();
        }
      }
      else
        label2.Text = "0.00";
      this.CalculateTotal();
    }

    protected void lnkAddTask_OnClick(object sender, EventArgs e)
    {
      this.AddNewTaskRow();
    }

    protected void lnkAddItem_OnClick(object sender, EventArgs e)
    {
      this.AddNewItemRow();
    }

    private void AddNewTaskRow()
    {
      int index1 = 0;
      if (this.ViewState["TaskTable"] != null)
      {
        DataTable dataTable = (DataTable) this.ViewState["TaskTable"];
        DataRow row = (DataRow) null;
        if (dataTable.Rows.Count > 0)
        {
          for (int index2 = 1; index2 <= dataTable.Rows.Count; ++index2)
          {
            DropDownList dropDownList1 = (DropDownList) this.gvTask.Rows[index1].Cells[0].FindControl("ddlTask");
            TextBox textBox1 = (TextBox) this.gvTask.Rows[index1].Cells[1].FindControl("txtDesc");
            TextBox textBox2 = (TextBox) this.gvTask.Rows[index1].Cells[2].FindControl("txtRate");
            TextBox textBox3 = (TextBox) this.gvTask.Rows[index1].Cells[3].FindControl("txtHours");
            DropDownList dropDownList2 = (DropDownList) this.gvTask.Rows[index1].Cells[4].FindControl("ddlTaskTax1");
            DropDownList dropDownList3 = (DropDownList) this.gvTask.Rows[index1].Cells[5].FindControl("ddlTaskTax2");
            Label label = (Label) this.gvTask.Rows[index1].Cells[6].FindControl("lblTaskLineTotal");
            row = dataTable.NewRow();
            dataTable.Rows[index2 - 1]["Colum1"] = (object) dropDownList1.SelectedValue;
            dataTable.Rows[index2 - 1]["Colum2"] = (object) textBox1.Text;
            dataTable.Rows[index2 - 1]["Colum3"] = (object) textBox2.Text;
            dataTable.Rows[index2 - 1]["Colum4"] = (object) textBox3.Text;
            dataTable.Rows[index2 - 1]["Colum5"] = (object) dropDownList2.SelectedValue;
            dataTable.Rows[index2 - 1]["Colum6"] = (object) dropDownList3.SelectedValue;
            dataTable.Rows[index2 - 1]["Colum7"] = (object) label.Text;
            ++index1;
          }
          if (row != null)
            dataTable.Rows.Add(row);
          this.ViewState["TaskTable"] = (object) dataTable;
          this.gvTask.DataSource = (object) dataTable;
          this.gvTask.DataBind();
          this.gvTask.Rows[index1].Cells[0].FindControl("ddlTask").Focus();
        }
      }
      else
        this.Response.Write("ViewState is null");
      this.SetPreviousTaskData();
    }

    private void SetPreviousTaskData()
    {
      int index1 = 0;
      if (this.ViewState["TaskTable"] == null)
        return;
      DataTable dataTable = (DataTable) this.ViewState["TaskTable"];
      if (dataTable.Rows.Count <= 0)
        return;
      for (int index2 = 0; index2 < dataTable.Rows.Count; ++index2)
      {
        DropDownList dropDownList1 = (DropDownList) this.gvTask.Rows[index1].Cells[0].FindControl("ddlTask");
        TextBox textBox1 = (TextBox) this.gvTask.Rows[index1].Cells[1].FindControl("txtDesc");
        TextBox textBox2 = (TextBox) this.gvTask.Rows[index1].Cells[2].FindControl("txtRate");
        TextBox textBox3 = (TextBox) this.gvTask.Rows[index1].Cells[3].FindControl("txtHours");
        DropDownList dropDownList2 = (DropDownList) this.gvTask.Rows[index1].Cells[4].FindControl("ddlTaskTax1");
        DropDownList dropDownList3 = (DropDownList) this.gvTask.Rows[index1].Cells[5].FindControl("ddlTaskTax2");
        Label label = (Label) this.gvTask.Rows[index1].Cells[6].FindControl("lblTaskLineTotal");
        dropDownList1.SelectedValue = dataTable.Rows[index2]["Colum1"].ToString();
        textBox1.Text = dataTable.Rows[index2]["Colum2"].ToString();
        textBox2.Text = dataTable.Rows[index2]["Colum3"].ToString().Length > 0 ? dataTable.Rows[index2]["Colum3"].ToString() : "0.00";
        textBox3.Text = dataTable.Rows[index2]["Colum4"].ToString().Length > 0 ? dataTable.Rows[index2]["Colum4"].ToString() : "0";
        dropDownList2.SelectedValue = dataTable.Rows[index2]["Colum5"].ToString();
        dropDownList3.SelectedValue = dataTable.Rows[index2]["Colum6"].ToString();
        label.Text = dataTable.Rows[index2]["Colum7"].ToString().Length > 0 ? dataTable.Rows[index2]["Colum7"].ToString() : "0.00";
        ++index1;
      }
    }

    private void SetTaskRowData()
    {
      int index1 = 0;
      if (this.ViewState["TaskTable"] != null)
      {
        DataTable dataTable = (DataTable) this.ViewState["TaskTable"];
        if (dataTable.Rows.Count <= 0)
          return;
        for (int index2 = 1; index2 <= dataTable.Rows.Count; ++index2)
        {
          DropDownList dropDownList1 = (DropDownList) this.gvTask.Rows[index1].Cells[0].FindControl("ddlTask");
          TextBox textBox1 = (TextBox) this.gvTask.Rows[index1].Cells[1].FindControl("txtDesc");
          TextBox textBox2 = (TextBox) this.gvTask.Rows[index1].Cells[2].FindControl("txtRate");
          TextBox textBox3 = (TextBox) this.gvTask.Rows[index1].Cells[3].FindControl("txtHours");
          DropDownList dropDownList2 = (DropDownList) this.gvTask.Rows[index1].Cells[4].FindControl("ddlTaskTax1");
          DropDownList dropDownList3 = (DropDownList) this.gvTask.Rows[index1].Cells[5].FindControl("ddlTaskTax2");
          Label label = (Label) this.gvTask.Rows[index1].Cells[6].FindControl("lblTaskLineTotal");
          dataTable.Rows[index2 - 1]["Colum1"] = (object) dropDownList1.SelectedValue;
          dataTable.Rows[index2 - 1]["Colum2"] = (object) textBox1.Text;
          dataTable.Rows[index2 - 1]["Colum3"] = (object) textBox2.Text;
          dataTable.Rows[index2 - 1]["Colum4"] = (object) textBox3.Text;
          dataTable.Rows[index2 - 1]["Colum5"] = (object) dropDownList2.SelectedValue;
          dataTable.Rows[index2 - 1]["Colum6"] = (object) dropDownList3.SelectedValue;
          dataTable.Rows[index2 - 1]["Colum7"] = (object) label.Text;
          ++index1;
        }
        this.ViewState["TaskTable"] = (object) dataTable;
      }
      else
        this.Response.Write("ViewState is null");
    }

    protected void gvTask_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
      this.SetTaskRowData();
      if (this.ViewState["TaskTable"] == null)
        return;
      DataTable dataTable = (DataTable) this.ViewState["TaskTable"];
      int index = Convert.ToInt32(e.RowIndex);
      if (dataTable.Rows.Count <= 1)
        return;
      dataTable.Rows.Remove(dataTable.Rows[index]);
      dataTable.NewRow();
      this.ViewState["TaskTable"] = (object) dataTable;
      this.gvTask.DataSource = (object) dataTable;
      this.gvTask.DataBind();
      this.SetPreviousTaskData();
    }

    private void AddNewItemRow()
    {
      int index1 = 0;
      if (this.ViewState["ItemTable"] != null)
      {
        DataTable dataTable = (DataTable) this.ViewState["ItemTable"];
        DataRow row = (DataRow) null;
        if (dataTable.Rows.Count > 0)
        {
          for (int index2 = 1; index2 <= dataTable.Rows.Count; ++index2)
          {
            DropDownList dropDownList1 = (DropDownList) this.gvItem.Rows[index1].Cells[0].FindControl("ddlItem");
            TextBox textBox1 = (TextBox) this.gvItem.Rows[index1].Cells[1].FindControl("txtItemDesc");
            TextBox textBox2 = (TextBox) this.gvItem.Rows[index1].Cells[2].FindControl("txtUnitCost");
            TextBox textBox3 = (TextBox) this.gvItem.Rows[index1].Cells[3].FindControl("txtQty");
            DropDownList dropDownList2 = (DropDownList) this.gvItem.Rows[index1].Cells[4].FindControl("ddlItemTax1");
            DropDownList dropDownList3 = (DropDownList) this.gvItem.Rows[index1].Cells[5].FindControl("ddlItemTax2");
            Label label = (Label) this.gvItem.Rows[index1].Cells[6].FindControl("lblItemLineTotal");
            row = dataTable.NewRow();
            dataTable.Rows[index2 - 1]["Colum1"] = (object) dropDownList1.SelectedValue;
            dataTable.Rows[index2 - 1]["Colum2"] = (object) textBox1.Text;
            dataTable.Rows[index2 - 1]["Colum3"] = (object) textBox2.Text;
            dataTable.Rows[index2 - 1]["Colum4"] = (object) textBox3.Text;
            dataTable.Rows[index2 - 1]["Colum5"] = (object) dropDownList2.SelectedValue;
            dataTable.Rows[index2 - 1]["Colum6"] = (object) dropDownList3.SelectedValue;
            dataTable.Rows[index2 - 1]["Colum7"] = (object) label.Text;
            ++index1;
          }
          if (row != null)
            dataTable.Rows.Add(row);
          this.ViewState["ItemTable"] = (object) dataTable;
          this.gvItem.DataSource = (object) dataTable;
          this.gvItem.DataBind();
          this.gvItem.Rows[index1].Cells[0].FindControl("ddlItem").Focus();
        }
      }
      else
        this.Response.Write("ViewState is null");
      this.SetPreviousItemData();
    }

    private void SetPreviousItemData()
    {
      int index1 = 0;
      if (this.ViewState["ItemTable"] == null)
        return;
      DataTable dataTable = (DataTable) this.ViewState["ItemTable"];
      if (dataTable.Rows.Count <= 0)
        return;
      for (int index2 = 0; index2 < dataTable.Rows.Count; ++index2)
      {
        DropDownList dropDownList1 = (DropDownList) this.gvItem.Rows[index1].Cells[0].FindControl("ddlItem");
        TextBox textBox1 = (TextBox) this.gvItem.Rows[index1].Cells[1].FindControl("txtItemDesc");
        TextBox textBox2 = (TextBox) this.gvItem.Rows[index1].Cells[2].FindControl("txtUnitCost");
        TextBox textBox3 = (TextBox) this.gvItem.Rows[index1].Cells[3].FindControl("txtQty");
        DropDownList dropDownList2 = (DropDownList) this.gvItem.Rows[index1].Cells[4].FindControl("ddlItemTax1");
        DropDownList dropDownList3 = (DropDownList) this.gvItem.Rows[index1].Cells[5].FindControl("ddlItemTax2");
        Label label = (Label) this.gvItem.Rows[index1].Cells[6].FindControl("lblItemLineTotal");
        dropDownList1.SelectedValue = dataTable.Rows[index2]["Colum1"].ToString();
        textBox1.Text = dataTable.Rows[index2]["Colum2"].ToString();
        textBox2.Text = dataTable.Rows[index2]["Colum3"].ToString().Length > 0 ? dataTable.Rows[index2]["Colum3"].ToString() : "0.00";
        textBox3.Text = dataTable.Rows[index2]["Colum4"].ToString().Length > 0 ? dataTable.Rows[index2]["Colum4"].ToString() : "0.00";
        dropDownList2.SelectedValue = dataTable.Rows[index2]["Colum5"].ToString();
        dropDownList3.SelectedValue = dataTable.Rows[index2]["Colum6"].ToString();
        label.Text = dataTable.Rows[index2]["Colum7"].ToString().Length > 0 ? dataTable.Rows[index2]["Colum7"].ToString() : "0.00";
        ++index1;
      }
    }

    private void SetItemRowData()
    {
      int index1 = 0;
      if (this.ViewState["ItemTable"] != null)
      {
        DataTable dataTable = (DataTable) this.ViewState["ItemTable"];
        if (dataTable.Rows.Count <= 0)
          return;
        for (int index2 = 1; index2 <= dataTable.Rows.Count; ++index2)
        {
          DropDownList dropDownList1 = (DropDownList) this.gvItem.Rows[index1].Cells[0].FindControl("ddlItem");
          TextBox textBox1 = (TextBox) this.gvItem.Rows[index1].Cells[1].FindControl("txtItemDesc");
          TextBox textBox2 = (TextBox) this.gvItem.Rows[index1].Cells[2].FindControl("txtUnitCost");
          TextBox textBox3 = (TextBox) this.gvItem.Rows[index1].Cells[3].FindControl("txtQty");
          DropDownList dropDownList2 = (DropDownList) this.gvItem.Rows[index1].Cells[4].FindControl("ddlItemTax1");
          DropDownList dropDownList3 = (DropDownList) this.gvItem.Rows[index1].Cells[5].FindControl("ddlItemTax2");
          Label label = (Label) this.gvItem.Rows[index1].Cells[6].FindControl("lblItemLineTotal");
          dataTable.Rows[index2 - 1]["Colum1"] = (object) dropDownList1.SelectedValue;
          dataTable.Rows[index2 - 1]["Colum2"] = (object) textBox1.Text;
          dataTable.Rows[index2 - 1]["Colum3"] = (object) textBox2.Text;
          dataTable.Rows[index2 - 1]["Colum4"] = (object) textBox3.Text;
          dataTable.Rows[index2 - 1]["Colum5"] = (object) dropDownList2.SelectedValue;
          dataTable.Rows[index2 - 1]["Colum6"] = (object) dropDownList3.SelectedValue;
          dataTable.Rows[index2 - 1]["Colum7"] = (object) label.Text;
          ++index1;
        }
        this.ViewState["ItemTable"] = (object) dataTable;
      }
      else
        this.Response.Write("ViewState is null");
    }

    protected void gvItem_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
      this.SetItemRowData();
      if (this.ViewState["ItemTable"] == null)
        return;
      DataTable dataTable = (DataTable) this.ViewState["ItemTable"];
      int index = Convert.ToInt32(e.RowIndex);
      if (dataTable.Rows.Count <= 1)
        return;
      dataTable.Rows.Remove(dataTable.Rows[index]);
      dataTable.NewRow();
      this.ViewState["ItemTable"] = (object) dataTable;
      this.gvItem.DataSource = (object) dataTable;
      this.gvItem.DataBind();
      this.SetPreviousItemData();
    }

    protected void txtDiscount_OnTextChanged(object sender, EventArgs e)
    {
      this.CalculateTotal();
    }

    protected void btnSaveDraft_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      string commandArgument = ((Button) sender).CommandArgument;
      if (this.ddlClient.SelectedIndex > 0 && this.txtEstimateNum.Text.Trim().Length > 0 && this.txtDateOfIssue.Text.Trim().Length > 0)
      {
        this.objEstimateMasterDT = this.objEstimateMasterBll.GetDataByCompanyEstimate(int.Parse(this.hfCompanyID.Value), this.txtEstimateNum.Text.Trim());
        if (this.objEstimateMasterDT.Rows.Count > 0)
        {
          this.DisplayAlert("This estimate number is already in use. Please choose another.");
          this.checkInDB = true;
        }
        if (this.checkInDB)
          return;
        int? iCurrencyID = new int?();
        if (this.ddlCurrency.SelectedIndex > 0 || !string.IsNullOrEmpty(this.ddlCurrency.SelectedItem.Value))
          iCurrencyID = new int?(int.Parse(this.ddlCurrency.SelectedItem.Value));
        string s1 = DateTime.ParseExact(this.txtDateOfIssue.Text, new string[6]
        {
          "MM/dd/yy",
          "MM/dd/yyyy",
          "dd/MM/yy",
          "dd/MM/yyyy",
          "yy-MM-dd",
          "yyyy-MM-dd"
        }, (IFormatProvider) CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("MM/dd/yyyy");
        int num = this.objEstimateMasterBll.AddEstimate(int.Parse(this.hfCompanyID.Value), new int?(int.Parse(this.ddlClient.SelectedItem.Value)), iCurrencyID, this.txtEstimateNum.Text.Trim(), new DateTime?(DateTime.Parse(s1)), this.txtPONumber.Text.Trim(), new Decimal?(Decimal.Parse(this.txtDiscount.Text.Trim())), new Decimal?(Decimal.Parse(this.lblDiscount.Text.Trim())), this.txtNotes.Text.Trim(), this.txtTerms.Text.Trim(), commandArgument, new Decimal?(Decimal.Parse(this.lblEstimateTotal.Text.Trim())), new Decimal?(Decimal.Parse(this.lblPaidToDate.Text)), true, false, false, true, false, false);
        if (num != 0)
        {
          this.SetItemRowData();
          DataTable dataTable1 = this.ViewState["ItemTable"] as DataTable;
          if (dataTable1 != null)
          {
            foreach (DataRow dataRow in (InternalDataCollectionBase) dataTable1.Rows)
            {
              string s2 = dataRow.ItemArray[0] as string;
              string sItemDesc = dataRow.ItemArray[1] as string;
              string s3 = dataRow.ItemArray[2] as string;
              string s4 = dataRow.ItemArray[3] as string;
              string s5 = dataRow.ItemArray[4] as string;
              string s6 = dataRow.ItemArray[5] as string;
              string s7 = dataRow.ItemArray[6] as string;
              if (s2 != null && !string.IsNullOrEmpty(s2) && s2 != "-1")
              {
                int? iTaxID1 = new int?();
                int? iTaxID2 = new int?();
                Decimal? dUnitCost = new Decimal?();
                Decimal? dQuantity = new Decimal?();
                if (!string.IsNullOrEmpty(s5) && s5 != "-1")
                  iTaxID1 = new int?(int.Parse(s5));
                if (!string.IsNullOrEmpty(s6) && s6 != "-1")
                  iTaxID2 = new int?(int.Parse(s6));
                if (!string.IsNullOrEmpty(s3))
                  dUnitCost = new Decimal?(Decimal.Parse(s3));
                if (!string.IsNullOrEmpty(s4))
                  dQuantity = new Decimal?(Decimal.Parse(s4));
                this.objEstimateItemDetailBll.AddEstimateItem(num, int.Parse(s2), sItemDesc, dUnitCost, dQuantity, iTaxID1, iTaxID2, new Decimal?(Decimal.Parse(s7)));
              }
            }
          }
          this.SetTaskRowData();
          DataTable dataTable2 = this.ViewState["TaskTable"] as DataTable;
          if (dataTable2 != null)
          {
            foreach (DataRow dataRow in (InternalDataCollectionBase) dataTable2.Rows)
            {
              string s2 = dataRow.ItemArray[0] as string;
              string sTaskDesc = dataRow.ItemArray[1] as string;
              string s3 = dataRow.ItemArray[2] as string;
              string s4 = dataRow.ItemArray[3] as string;
              string s5 = dataRow.ItemArray[4] as string;
              string s6 = dataRow.ItemArray[5] as string;
              string s7 = dataRow.ItemArray[6] as string;
              if (s2 != null && !string.IsNullOrEmpty(s2) && s2 != "-1")
              {
                int? iTaxID1 = new int?();
                int? iTaxID2 = new int?();
                Decimal? dRate = new Decimal?();
                Decimal? dHours = new Decimal?();
                if (!string.IsNullOrEmpty(s5) && s5 != "-1")
                  iTaxID1 = new int?(int.Parse(s5));
                if (!string.IsNullOrEmpty(s6) && s6 != "-1")
                  iTaxID2 = new int?(int.Parse(s6));
                if (!string.IsNullOrEmpty(s3))
                  dRate = new Decimal?(Decimal.Parse(s3));
                if (!string.IsNullOrEmpty(s4))
                  dHours = new Decimal?(Decimal.Parse(s4));
                this.objEstimateTaskDetailBll.AddEstimateTask(num, int.Parse(s2), sTaskDesc, dRate, dHours, iTaxID1, iTaxID2, new Decimal?(Decimal.Parse(s7)));
              }
            }
          }
          if (commandArgument != "draft")
          {
            this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(this.ddlClient.SelectedItem.Value));
            if (this.objCompanyClientMasterDT.Rows.Count > 0)
              this.SendMailNew(num);
          }
          this.Session["saveEstimate"] = (object) 1;
          this.Response.Redirect("EstimateMaster.aspx?cmd=view&ID=" + (object) num);
        }
        else
          this.DisplayAlert("Problem in Insertion..Try after some time..!");
      }
      else
        this.DisplayAlert("Please Fill All Required Information");
    }

    protected void btnUpdateDraft_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      string commandArgument = ((Button) sender).CommandArgument;
      if (this.ddlClient.SelectedIndex > 0 && this.txtEstimateNum.Text.Trim().Length > 0 && this.txtDateOfIssue.Text.Trim().Length > 0)
      {
        this.objEstimateMasterDT = this.objEstimateMasterBll.GetDataByCompanyEstimateUpdate(int.Parse(this.hfCompanyID.Value), this.txtEstimateNum.Text.Trim(), int.Parse(this.hfEstimateID.Value));
        if (this.objEstimateMasterDT.Rows.Count > 0)
        {
          this.DisplayAlert("This estimate number is already in use. Please choose another.");
          this.checkInDB = true;
        }
        if (this.checkInDB)
          return;
        int? iCurrencyID = new int?();
        if (this.ddlCurrency.SelectedIndex > 0 || !string.IsNullOrEmpty(this.ddlCurrency.SelectedItem.Value))
          iCurrencyID = new int?(int.Parse(this.ddlCurrency.SelectedItem.Value));
        string s1 = DateTime.ParseExact(this.txtDateOfIssue.Text, new string[6]
        {
          "MM/dd/yy",
          "MM/dd/yyyy",
          "dd/MM/yy",
          "dd/MM/yyyy",
          "yy-MM-dd",
          "yyyy-MM-dd"
        }, (IFormatProvider) CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("MM/dd/yyyy");
        if (this.objEstimateMasterBll.UpdateEstimate(int.Parse(this.hfEstimateID.Value), int.Parse(this.hfCompanyID.Value), new int?(int.Parse(this.ddlClient.SelectedItem.Value)), iCurrencyID, this.txtEstimateNum.Text.Trim(), new DateTime?(DateTime.Parse(s1)), this.txtPONumber.Text.Trim(), new Decimal?(Decimal.Parse(this.txtDiscount.Text.Trim())), new Decimal?(Decimal.Parse(this.lblDiscount.Text.Trim())), this.txtNotes.Text.Trim(), this.txtTerms.Text.Trim(), commandArgument, new Decimal?(Decimal.Parse(this.lblEstimateTotal.Text.Trim())), new Decimal?(Decimal.Parse(this.lblPaidToDate.Text)), true, false, false, true, false, false))
        {
          this.objEstimateItemDetailBll.DeleteByEstimate(int.Parse(this.hfEstimateID.Value));
          this.objEstimateTaskDetailBll.DeleteByEstimate(int.Parse(this.hfEstimateID.Value));
          this.SetItemRowData();
          DataTable dataTable1 = this.ViewState["ItemTable"] as DataTable;
          if (dataTable1 != null)
          {
            foreach (DataRow dataRow in (InternalDataCollectionBase) dataTable1.Rows)
            {
              string s2 = dataRow.ItemArray[0] as string;
              string sItemDesc = dataRow.ItemArray[1] as string;
              string s3 = dataRow.ItemArray[2] as string;
              string s4 = dataRow.ItemArray[3] as string;
              string s5 = dataRow.ItemArray[4] as string;
              string s6 = dataRow.ItemArray[5] as string;
              string s7 = dataRow.ItemArray[6] as string;
              if (s2 != null && !string.IsNullOrEmpty(s2) && s2 != "-1")
              {
                int? iTaxID1 = new int?();
                int? iTaxID2 = new int?();
                Decimal? dUnitCost = new Decimal?();
                Decimal? dQuantity = new Decimal?();
                if (!string.IsNullOrEmpty(s5) && s5 != "-1")
                  iTaxID1 = new int?(int.Parse(s5));
                if (!string.IsNullOrEmpty(s6) && s6 != "-1")
                  iTaxID2 = new int?(int.Parse(s6));
                if (!string.IsNullOrEmpty(s3))
                  dUnitCost = new Decimal?(Decimal.Parse(s3));
                if (!string.IsNullOrEmpty(s4))
                  dQuantity = new Decimal?(Decimal.Parse(s4));
                this.objEstimateItemDetailBll.AddEstimateItem(int.Parse(this.hfEstimateID.Value), int.Parse(s2), sItemDesc, dUnitCost, dQuantity, iTaxID1, iTaxID2, new Decimal?(Decimal.Parse(s7)));
              }
            }
          }
          this.SetTaskRowData();
          DataTable dataTable2 = this.ViewState["TaskTable"] as DataTable;
          if (dataTable2 != null)
          {
            foreach (DataRow dataRow in (InternalDataCollectionBase) dataTable2.Rows)
            {
              string s2 = dataRow.ItemArray[0] as string;
              string sTaskDesc = dataRow.ItemArray[1] as string;
              string s3 = dataRow.ItemArray[2] as string;
              string s4 = dataRow.ItemArray[3] as string;
              string s5 = dataRow.ItemArray[4] as string;
              string s6 = dataRow.ItemArray[5] as string;
              string s7 = dataRow.ItemArray[6] as string;
              if (s2 != null && !string.IsNullOrEmpty(s2) && s2 != "-1")
              {
                int? iTaxID1 = new int?();
                int? iTaxID2 = new int?();
                Decimal? dRate = new Decimal?();
                Decimal? dHours = new Decimal?();
                if (!string.IsNullOrEmpty(s5) && s5 != "-1")
                  iTaxID1 = new int?(int.Parse(s5));
                if (!string.IsNullOrEmpty(s6) && s6 != "-1")
                  iTaxID2 = new int?(int.Parse(s6));
                if (!string.IsNullOrEmpty(s3))
                  dRate = new Decimal?(Decimal.Parse(s3));
                if (!string.IsNullOrEmpty(s4))
                  dHours = new Decimal?(Decimal.Parse(s4));
                this.objEstimateTaskDetailBll.AddEstimateTask(int.Parse(this.hfEstimateID.Value), int.Parse(s2), sTaskDesc, dRate, dHours, iTaxID1, iTaxID2, new Decimal?(Decimal.Parse(s7)));
              }
            }
          }
          if (commandArgument != "draft")
          {
            this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(this.ddlClient.SelectedItem.Value));
            if (this.objCompanyClientMasterDT.Rows.Count > 0)
              this.SendMailNew(int.Parse(this.hfEstimateID.Value));
          }
          this.Session["updateEstimate"] = (object) 1;
          this.Response.Redirect("EstimateMaster.aspx?cmd=view&ID=" + this.hfEstimateID.Value);
        }
        else
          this.DisplayAlert("Problem in Updation..Try after some time..!");
      }
      else
        this.DisplayAlert("Please Fill All Required Information");
    }

    private static string GenerateCode()
    {
      Random random = new Random();
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < 10; ++index)
        stringBuilder.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"[random.Next("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".Length)]);
      return stringBuilder.ToString();
    }

    private string Encrypt(string clearText, string key)
    {
      string password = key;
      byte[] bytes = Encoding.Unicode.GetBytes(clearText);
      using (Aes aes = Aes.Create())
      {
        Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, new byte[13]
        {
          (byte) 73,
          (byte) 118,
          (byte) 97,
          (byte) 110,
          (byte) 32,
          (byte) 77,
          (byte) 101,
          (byte) 100,
          (byte) 118,
          (byte) 101,
          (byte) 100,
          (byte) 101,
          (byte) 118
        });
        if (aes != null)
        {
          aes.Key = rfc2898DeriveBytes.GetBytes(32);
          aes.IV = rfc2898DeriveBytes.GetBytes(16);
          using (MemoryStream memoryStream = new MemoryStream())
          {
            using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
              cryptoStream.Write(bytes, 0, bytes.Length);
              cryptoStream.Close();
            }
            clearText = Convert.ToBase64String(memoryStream.ToArray());
          }
        }
      }
      return clearText;
    }

    private void SendMailNew(int estimateId)
    {
      this.objEstimateMasterDT = this.objEstimateMasterBll.GetDataByEstimateID(estimateId);
      string str1 = this.objEstimateMasterDT.Rows[0]["EstimateNumber"].ToString();
      string str2 = this.objEstimateMasterDT.Rows[0]["EstimateTotal"].ToString();
      string s = this.objEstimateMasterDT.Rows[0]["ClientID"].ToString();
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      string displayName = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString().ToUpper();
      string addresses = this.objCompanyMasterDT.Rows[0]["CompanyEmail"].ToString();
      string str3 = string.Empty;
      string address1 = string.Empty;
      string str4 = string.Empty;
      string str5 = string.Empty;
      string str6 = string.Empty;
      this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(s));
      if (this.objCompanyClientMasterDT.Rows.Count > 0)
      {
        string username = this.objCompanyClientMasterDT.Rows[0]["UserName"].ToString();
        str4 = this.objCompanyClientMasterDT.Rows[0]["OrganizationName"].ToString();
        str5 = this.objCompanyClientMasterDT.Rows[0]["FirstName"].ToString();
        str6 = this.objCompanyClientMasterDT.Rows[0]["LastName"].ToString();
        address1 = this.objCompanyClientMasterDT.Rows[0]["Email"].ToString();
        MembershipUser user = Membership.GetUser(username);
        if (user != null)
        {
          string key1 = EstimateMaster.GenerateCode();
          string str7 = HttpUtility.UrlEncode(this.Encrypt(user.UserName, key1));
          string password = user.GetPassword();
          string key2 = EstimateMaster.GenerateCode();
          string str8 = HttpUtility.UrlEncode(this.Encrypt(password, key2));
          str3 = string.Format("https://www.billtransact.com/CheckClient.aspx?page=estimate&anyId={0}&name={1}&tech={2}&keyname={3}&keytech={4}", (object) estimateId, (object) str7, (object) str8, (object) key1, (object) key2);
        }
      }
      string str9 = string.Empty;
      string str10 = string.Empty;
      string address2 = "noreply@DoyniGo.com";
      this.objSMTPSettingsDT = this.objSMTPSettingsBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objSMTPSettingsDT.Rows.Count > 0)
      {
        str10 = this.objSMTPSettingsDT.Rows[0]["EmailSignature"].ToString();
        address2 = this.objSMTPSettingsDT.Rows[0]["SMTPFrom"].ToString();
      }
      this.objNewEstimateEmailTemplateDT = this.objNewEstimateEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objNewEstimateEmailTemplateDT.Rows.Count > 0)
        str9 = this.objNewEstimateEmailTemplateDT.Rows[0]["EmailBody"].ToString();
      Hashtable Variables = new Hashtable()
      {
        {
          (object) "emailTemplate",
          (object) str9
        },
        {
          (object) "companyName",
          (object) displayName
        },
        {
          (object) "companyEmail",
          (object) ("<a href=\"mailto:" + addresses + "\">" + addresses + "</a>")
        },
        {
          (object) "estimateNumber",
          (object) str1
        },
        {
          (object) "clientOrgName",
          (object) str4
        },
        {
          (object) "firstName",
          (object) str5
        },
        {
          (object) "lastName",
          (object) str6
        },
        {
          (object) "estimateAmt",
          (object) str2
        },
        {
          (object) "someLink",
          (object) str3
        },
        {
          (object) "estimateLink",
          (object) str3
        },
        {
          (object) "directLink",
          (object) this.directLink
        },
        {
          (object) "branding",
          (object) this.branding
        },
        {
          (object) "emailSign",
          (object) str10
        }
      };
      Parser parser1 = new Parser(this.Server.MapPath("~/MailTemplate/SendEstimateNew.html"), Variables);
      string path1 = this.Server.MapPath("~\\TempHTMLFiles\\");
      File.WriteAllText(Path.Combine(path1, "Estimate.html"), parser1.Parse());
      Parser parser2 = new Parser(path1 + "Estimate.html", Variables);
      try
      {
        MailMessage message = new MailMessage()
        {
          From = new MailAddress(address2, displayName)
        };
        message.To.Add(new MailAddress(address1));
        message.ReplyToList.Add(addresses);
        message.Subject = "New estimate " + this.txtEstimateNum.Text + " from " + displayName + ", sent using Bill Transact";
        message.BodyEncoding = Encoding.UTF8;
        message.Body = parser2.Parse();
        message.IsBodyHtml = true;
        SmtpClientForCompany.smtpClient(this.hfCompanyID.Value).Send(message);
        File.Delete(Path.Combine(path1, "Estimate.html"));
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

    protected void btnArchived_Click(object sender, EventArgs e)
    {
      int num = 0;
      for (int index = 0; index < this.gvEstimate.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvEstimate.Rows[index].Cells[0].FindControl("chkID");
        if (checkBox.Checked)
        {
          ++num;
          this.objEstimateMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), false, false, true);
        }
      }
      if (num == 0)
        this.DisplayAlert("No Estimates were selected.");
      else
        this.Response.Redirect("EstimateMaster.aspx");
    }

    protected void btnEmail_Click(object sender, EventArgs e)
    {
      int num = 0;
      for (int index = 0; index < this.gvEstimate.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvEstimate.Rows[index].Cells[0].FindControl("chkID");
        if (checkBox.Checked)
        {
          ++num;
          this.SendMailNew(int.Parse(checkBox.ToolTip));
        }
      }
      if (num == 0)
        this.DisplayAlert("No Estimates were selected.");
      else
        this.Response.Redirect("EstimateMaster.aspx");
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      int num = 0;
      for (int index = 0; index < this.gvEstimate.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvEstimate.Rows[index].Cells[0].FindControl("chkID");
        if (checkBox.Checked)
        {
          ++num;
          this.objEstimateMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), false, true, false);
        }
      }
      if (num == 0)
        this.DisplayAlert("No Estimates were selected.");
      else
        this.Response.Redirect("EstimateMaster.aspx?de=true&ac=false");
    }

    protected void btnCopy_Click(object sender, EventArgs e)
    {
      int num = 0;
      string str = string.Empty;
      for (int index = 0; index < this.gvEstimate.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvEstimate.Rows[index].Cells[0].FindControl("chkID");
        if (checkBox.Checked)
        {
          ++num;
          str = checkBox.ToolTip;
        }
      }
      if (num == 0)
        this.DisplayAlert("No Estimates were selected.");
      else if (num > 1)
      {
        this.DisplayAlert("More than one Estimates were selected. Please Select Only One Estimate.");
      }
      else
      {
        if (num != 1 || string.IsNullOrEmpty(str))
          return;
        this.Response.Redirect("EstimateMaster.aspx?cmd=copied&ID=" + str);
      }
    }

    protected void btnUnArchived_Click(object sender, EventArgs e)
    {
      int num = 0;
      for (int index = 0; index < this.gvEstimate.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvEstimate.Rows[index].Cells[0].FindControl("chkID");
        if (checkBox.Checked)
        {
          ++num;
          this.objEstimateMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), true, false, false);
        }
      }
      if (num == 0)
        this.DisplayAlert("No Estimates were selected.");
      else
        this.Response.Redirect("EstimateMaster.aspx?ar=true&ac=false");
    }

    protected void btnUnDelete_Click(object sender, EventArgs e)
    {
      int num = 0;
      for (int index = 0; index < this.gvEstimate.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvEstimate.Rows[index].Cells[0].FindControl("chkID");
        if (checkBox.Checked)
        {
          ++num;
          this.objEstimateMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), true, false, false);
        }
      }
      if (num == 0)
        this.DisplayAlert("No Estimates were selected.");
      else
        this.Response.Redirect("EstimateMaster.aspx?de=true&ac=false");
    }

    public bool CheckARQuery()
    {
      return this.Request.QueryString["ar"] != null && bool.Parse(this.Request.QueryString["ar"]);
    }

    public bool CheckDEQuery()
    {
      return this.Request.QueryString["de"] != null && bool.Parse(this.Request.QueryString["de"]);
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("EstimateMaster.aspx?cmd=add");
    }

    protected void gvEstimate_Sorting(object sender, GridViewSortEventArgs e)
    {
      this.BindGrid();
    }

    protected void gvEstimate_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.BindGrid();
    }

    protected void gvEstimate_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvEstimate.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void gvEstimate_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(e.Row.Cells[2].Text));
        e.Row.Cells[2].Text = this.objCompanyClientMasterDT.Rows[0]["OrganizationName"].ToString();
      }
      BoundField boundField = ((GridView) sender).Columns[3] as BoundField;
      if (boundField == null)
        return;
      boundField.DataFormatString = "{0:" + this.dateFormat + "}";
    }

    protected void gvItemView_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType != DataControlRowType.DataRow)
        return;
      string text1 = e.Row.Cells[0].Text;
      string text2 = e.Row.Cells[4].Text;
      string text3 = e.Row.Cells[5].Text;
      this.objItemMasterDT = this.objItemMasterBll.GetDataByItemID(int.Parse(text1));
      if (this.objItemMasterDT.Rows.Count > 0)
        e.Row.Cells[0].Text = this.objItemMasterDT.Rows[0]["ItemName"].ToString();
      try
      {
        if (!string.IsNullOrEmpty(text2) && !text2.Contains("&"))
        {
          this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(text2));
          if (this.objTaxMasterDT.Rows.Count > 0)
            e.Row.Cells[4].Text = this.objTaxMasterDT.Rows[0]["TaxName"].ToString();
        }
        if (string.IsNullOrEmpty(text3) || text3.Contains("&"))
          return;
        this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(text3));
        if (this.objTaxMasterDT.Rows.Count <= 0)
          return;
        e.Row.Cells[5].Text = this.objTaxMasterDT.Rows[0]["TaxName"].ToString();
      }
      catch (Exception ex)
      {
        e.Row.Cells[4].Text = "";
        e.Row.Cells[5].Text = "";
      }
    }

    protected void gvTaskView_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType != DataControlRowType.DataRow)
        return;
      string text1 = e.Row.Cells[0].Text;
      string text2 = e.Row.Cells[4].Text;
      string text3 = e.Row.Cells[5].Text;
      this.objTaskMasterDT = this.objTaskMasterBll.GetDataByTaskID(int.Parse(text1));
      if (this.objTaskMasterDT.Rows.Count > 0)
        e.Row.Cells[0].Text = this.objTaskMasterDT.Rows[0]["TaskName"].ToString();
      try
      {
        if (!string.IsNullOrEmpty(text2) && !text2.Contains("&"))
        {
          this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(text2));
          if (this.objTaxMasterDT.Rows.Count > 0)
            e.Row.Cells[4].Text = this.objTaxMasterDT.Rows[0]["TaxName"].ToString();
        }
        if (string.IsNullOrEmpty(text3) || text3.Contains("&"))
          return;
        this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(text3));
        if (this.objTaxMasterDT.Rows.Count <= 0)
          return;
        e.Row.Cells[5].Text = this.objTaxMasterDT.Rows[0]["TaxName"].ToString();
      }
      catch (Exception ex)
      {
        e.Row.Cells[4].Text = "";
        e.Row.Cells[5].Text = "";
      }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("EstimateMaster.aspx?cmd=add&ID=" + this.hfEstimateID.Value);
    }

    protected void ddlCurrency_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.ddlCurrency.SelectedIndex > 0 || !string.IsNullOrEmpty(this.ddlCurrency.SelectedItem.Value))
      {
        this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(this.ddlCurrency.SelectedItem.Value));
        if (this.objCurrencyMasterDT.Rows.Count > 0)
        {
          this.lblCurrencyCode.Text = this.objCurrencyMasterDT.Rows[0]["CurrencyCode"].ToString();
          this.lblCurrencySymbol1.Text = this.lblCurrencySymbol2.Text = this.objCurrencyMasterDT.Rows[0]["CurrencySymbol"].ToString();
        }
        else
        {
          this.lblCurrencySymbol1.Text = this.lblCurrencySymbol2.Text = "₦";
          this.lblCurrencyCode.Text = "NGN";
        }
      }
      else
      {
        this.lblCurrencySymbol1.Text = this.lblCurrencySymbol2.Text = "₦";
        this.lblCurrencyCode.Text = "NGN";
      }
    }

    protected void btnSaveTerms_Click(object sender, EventArgs e)
    {
      this.objTermsDT = this.objTermsBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objTermsDT.Rows.Count > 0)
        this.objTermsBll.UpdateEstimateDefaultTerms(int.Parse(this.objTermsDT.Rows[0]["EstimateDefaultTermsID"].ToString()), int.Parse(this.hfCompanyID.Value), this.txtDefaultTerms.Text.Trim());
      else
        this.objTermsBll.AddEstimateDefaultTerms(int.Parse(this.hfCompanyID.Value), this.txtDefaultTerms.Text.Trim());
      this.mpEstimateTerms.Hide();
      this.SetDefaultValues();
    }

    protected void btnBoxSave_OnClick(object sender, EventArgs e)
    {
      if (this.txtBoxClientEmail.Text.Trim().Length <= 0)
        return;
      int? iCountryID = new int?();
      int? iStateID = new int?();
      int? iCityID = new int?();
      int? iIndustryID = new int?();
      if (this.ddlBoxClientCountry.SelectedIndex > 0)
        iCountryID = new int?(int.Parse(this.ddlBoxClientCountry.SelectedItem.Value));
      if (this.ddlBoxClientState.SelectedIndex > 0)
        iStateID = new int?(int.Parse(this.ddlBoxClientState.SelectedItem.Value));
      if (this.ddlBoxClientCity.SelectedIndex > 0)
        iCityID = new int?(int.Parse(this.ddlBoxClientCity.SelectedItem.Value));
      if (this.ddlIndustry.SelectedIndex > 0)
        iIndustryID = new int?(int.Parse(this.ddlIndustry.SelectedItem.Value));
      string sOrganizationName = this.txtBoxClientOrganization.Text.Trim();
      if (string.IsNullOrEmpty(sOrganizationName))
        sOrganizationName = this.txtBoxClientEmail.Text.Trim();
      int iClientID = this.objCompanyClientMasterBll.AddCompanyClient(int.Parse(this.hfCompanyID.Value), sOrganizationName, new int?(), false, false, this.txtBoxClientEmail.Text, this.txtBoxClientFirstName.Text.Trim(), this.txtBoxClientLastName.Text.Trim(), "", "", false, "", this.txtBoxClientAddress1.Text.Trim(), this.txtBoxClientAddress2.Text.Trim(), iCountryID, iStateID, iCityID, this.txtBoxClientZipcode.Text.Trim(), "", "", new int?(), new int?(), new int?(), "", iIndustryID, this.ddlCompanySize.SelectedItem.Text, "", "", "", true, false, false);
      StaffClientAssignDetailBLL clientAssignDetailBll = new StaffClientAssignDetailBLL();
      MembershipUser user = Membership.GetUser();
      if (user != null)
      {
        string str = user.ToString();
        if (Roles.IsUserInRole(str, "Employee"))
        {
          this.objStaffMasterDT = this.objStaffMasterBll.GetDataByStaffUserName(str);
          if (this.objStaffMasterDT.Rows.Count > 0)
          {
            this.hfCompanyID.Value = this.objStaffMasterDT.Rows[0]["CompanyID"].ToString();
            this.hfStaffID.Value = this.objStaffMasterDT.Rows[0]["StaffID"].ToString();
          }
          clientAssignDetailBll.AddStaffClientAssignDetail(int.Parse(this.hfCompanyID.Value), int.Parse(this.hfStaffID.Value), iClientID, true);
        }
      }
      this.sqldsClient.DataBind();
      this.ddlClient.DataBind();
      this.ddlClient.SelectedValue = iClientID.ToString();
      this.ddlClient_SelectedIndexChanged(sender, e);
    }

    protected void btnBoxUpdate_OnClick(object sender, EventArgs e)
    {
      if (this.txtBoxClientEmail.Text.Trim().Length <= 0)
        return;
      int? iCountryID = new int?();
      int? iStateID = new int?();
      int? iCityID = new int?();
      int? iIndustryID = new int?();
      if (this.ddlBoxClientCountry.SelectedIndex > 0)
        iCountryID = new int?(int.Parse(this.ddlBoxClientCountry.SelectedItem.Value));
      if (this.ddlBoxClientState.SelectedIndex > 0)
        iStateID = new int?(int.Parse(this.ddlBoxClientState.SelectedItem.Value));
      if (this.ddlBoxClientCity.SelectedIndex > 0)
        iCityID = new int?(int.Parse(this.ddlBoxClientCity.SelectedItem.Value));
      if (this.ddlIndustry.SelectedIndex > 0)
        iIndustryID = new int?(int.Parse(this.ddlIndustry.SelectedItem.Value));
      string sOrganizationName = this.txtBoxClientOrganization.Text.Trim();
      if (string.IsNullOrEmpty(sOrganizationName))
        sOrganizationName = this.txtBoxClientEmail.Text.Trim();
      this.hfCompanyClientID.Value = this.ddlClient.SelectedItem.Value;
      this.objCompanyClientMasterBll.UpdateBoxData(int.Parse(this.hfCompanyClientID.Value), int.Parse(this.hfCompanyID.Value), sOrganizationName, this.txtBoxClientEmail.Text, this.txtBoxClientFirstName.Text.Trim(), this.txtBoxClientLastName.Text.Trim(), this.txtBoxClientAddress1.Text.Trim(), this.txtBoxClientAddress2.Text.Trim(), iCountryID, iStateID, iCityID, this.txtBoxClientZipcode.Text.Trim(), iIndustryID, this.ddlCompanySize.SelectedItem.Text);
      this.sqldsClient.DataBind();
      this.ddlClient.DataBind();
      this.ddlClient.SelectedValue = this.hfCompanyClientID.Value;
      this.ddlClient_SelectedIndexChanged(sender, e);
    }

    protected void txtBoxClientEmail_OnTextChanged(object sender, EventArgs e)
    {
      this.objCompanyClientContactDetailDT = this.objCompanyClientContactDetailBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), this.txtBoxClientEmail.Text.Trim());
      this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), this.txtBoxClientEmail.Text.Trim());
      this.objStaffMasterDT = this.objStaffMasterBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), this.txtBoxClientEmail.Text.Trim());
      this.objContractorMasterDT = this.objContractorMasterBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), this.txtBoxClientEmail.Text.Trim());
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyEmail(this.txtBoxClientEmail.Text.Trim());
      if (this.objCompanyMasterDT.Rows.Count > 0)
      {
        this.DisplayAlert("Email Already Register With System.");
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Email Already Register With System.')", true);
        this.txtBoxClientEmail.Text = "";
        this.txtBoxClientEmail.Focus();
      }
      else if (this.objCompanyClientMasterDT.Rows.Count > 0 || this.objCompanyClientContactDetailDT.Rows.Count > 0)
      {
        this.DisplayAlert("Email Already Register With System To Some Client.");
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Email Already Register With System To Some Client.')", true);
        this.txtBoxClientEmail.Text = "";
        this.txtBoxClientEmail.Focus();
      }
      else if (this.objStaffMasterDT.Rows.Count > 0)
      {
        this.DisplayAlert("Email Already Register With System To Some Staff.");
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Email Already Register With System To Some Staff.')", true);
        this.txtBoxClientEmail.Text = "";
        this.txtBoxClientEmail.Focus();
      }
      else if (this.objContractorMasterDT.Rows.Count > 0)
      {
        this.DisplayAlert("Email Already Register With System To Some Contractor.");
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Email Already Register With System To Some Contractor.')", true);
        this.txtBoxClientEmail.Text = "";
        this.txtBoxClientEmail.Focus();
      }
      else
        this.txtBoxClientFirstName.Focus();
    }

    protected void btnInvoice_OnClick(object sender, EventArgs e)
    {
      int num = 0;
      for (int index = 0; index < this.gvEstimate.Rows.Count; ++index)
      {
        if (((CheckBox) this.gvEstimate.Rows[index].Cells[0].FindControl("chkID")).Checked)
          ++num;
      }
      if (num == 0)
        this.DisplayAlert("No estimates were selected.");
      else if (num > 1)
      {
        this.DisplayAlert("You can only convert one estimate at a time.");
      }
      else
      {
        for (int index = 0; index < this.gvEstimate.Rows.Count; ++index)
        {
          CheckBox checkBox = (CheckBox) this.gvEstimate.Rows[index].Cells[0].FindControl("chkID");
          if (checkBox.Checked)
          {
            if (checkBox.CssClass != "invoiced")
            {
              this.Response.Redirect("InvoiceMasterNew.aspx?cmd=estimate&ID=" + checkBox.ToolTip);
            }
            else
            {
              this.DisplayAlert("Invoice has already been created from this estimate.");
              break;
            }
          }
        }
      }
    }

    protected void btnAccept_OnClick(object sender, EventArgs e)
    {
      int num = 0;
      for (int index = 0; index < this.gvEstimate.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvEstimate.Rows[index].Cells[0].FindControl("chkID");
        if (checkBox.Checked)
        {
          if (checkBox.CssClass != "accepted" && checkBox.CssClass != "invoiced")
          {
            ++num;
            this.objEstimateMasterBll.UpdateEstimateStatus("accepted", int.Parse(checkBox.ToolTip));
          }
          else
            --num;
        }
      }
      if (num == 0)
        this.DisplayAlert("No estimates were selected.");
      else if (num < 0)
        this.DisplayAlert("Estimate is already invoiced. OR Estimate is already accepted.");
      else
        this.Response.Redirect("EstimateMaster.aspx");
    }

    protected string GetCurrency(string curId)
    {
      this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(curId));
      if (this.objCurrencyMasterDT.Rows.Count > 0)
        return "(" + this.objCurrencyMasterDT.Rows[0]["CurrencySymbol"] + ")";
      return "";
    }

    protected string SetName(string id, string role)
    {
      switch (role)
      {
        case "Company":
          this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(id));
          return "You";
        case "CompanyClientContact":
          this.objCompanyClientContactDetailDT = this.objCompanyClientContactDetailBll.GetDataByCompanyClientContactID(int.Parse(id));
          return (string) this.objCompanyClientContactDetailDT.Rows[0]["FirstName"] + (object) " " + (string) this.objCompanyClientContactDetailDT.Rows[0]["LastName"];
        case "CompanyClient":
          this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(id));
          return (string) this.objCompanyClientMasterDT.Rows[0]["FirstName"] + (object) " " + (string) this.objCompanyClientMasterDT.Rows[0]["LastName"];
        default:
          return string.Empty;
      }
    }

    protected void lnkCloseDispute_OnClick(object sender, EventArgs e)
    {
      this.txtDisputeText.Text = "";
      this.disputeDivText.Visible = false;
      this.disputeDivLabel.Visible = true;
    }

    protected void btnDispute_OnClick(object sender, EventArgs e)
    {
      this.txtDisputeText.Text = "";
      this.disputeDivText.Visible = true;
      this.disputeDivLabel.Visible = true;
      this.txtDisputeText.Focus();
      this.btnDispute.Visible = false;
    }

    protected void btnDisputeSend_OnClick(object sender, EventArgs e)
    {
      if (this.txtDisputeText.Text.Trim().Length > 0)
      {
        this.objEstimateDisputeHistoryBll.AddEstimateDisputeHistory(int.Parse(this.hfEstimateID.Value), "Company", int.Parse(this.hfCompanyID.Value), this.txtDisputeText.Text.Trim());
        this.objEstimateMasterDT = this.objEstimateMasterBll.GetDataByEstimateID(int.Parse(this.hfEstimateID.Value));
        if (this.objEstimateMasterDT.Rows[0]["EstimateStatus"].ToString().ToLower().Contains("replied"))
          this.objEstimateMasterBll.UpdateEstimateStatus("sent", int.Parse(this.hfEstimateID.Value));
        this.Response.Redirect("EstimateMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
      }
      else
      {
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('You must provide a reason.')", true);
        this.txtDisputeText.Focus();
      }
    }

    protected void btnAcceptView_Click(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(this.hfEstimateID.Value))
      {
        this.objEstimateMasterBll.UpdateEstimateStatus("accepted", int.Parse(this.hfEstimateID.Value));
        this.Response.Redirect("EstimateMaster.aspx?cmd=view&ID=" + this.hfEstimateID.Value);
      }
      else
        this.Response.Redirect("EstimateMaster.aspx");
    }

    protected void btnSendEmail_Click(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(this.hfEstimateID.Value))
        this.SendMailNew(int.Parse(this.hfEstimateID.Value));
      else
        this.Response.Redirect("EstimateMaster.aspx");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
      this.BindGrid();
    }
  }
}

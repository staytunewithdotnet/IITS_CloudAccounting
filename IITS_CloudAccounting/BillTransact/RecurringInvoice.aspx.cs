// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.RecurringInvoice
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
  public class RecurringInvoice : Page
  {
    private readonly CityMasterBLL objCityMasterBll = new CityMasterBLL();
    private CloudAccountDA.CityMasterDataTable objCityMasterDT = new CloudAccountDA.CityMasterDataTable();
    private readonly CountryMasterBLL objCountryMasterBll = new CountryMasterBLL();
    private CloudAccountDA.CountryMasterDataTable objCountryMasterDT = new CloudAccountDA.CountryMasterDataTable();
    private readonly FrequencyMasterBLL objFrequencyMasterBll = new FrequencyMasterBLL();
    private CloudAccountDA.FrequencyMasterDataTable objFrequencyMasterDT = new CloudAccountDA.FrequencyMasterDataTable();
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
    private readonly RecurringMasterBLL objRecurringMasterBll = new RecurringMasterBLL();
    private CloudAccountDA.RecurringMasterDataTable objRecurringMasterDT = new CloudAccountDA.RecurringMasterDataTable();
    private readonly RecurringItemDetailBLL objRecurringItemDetailBll = new RecurringItemDetailBLL();
    private CloudAccountDA.RecurringItemDetailDataTable objRecurringItemDetailDT = new CloudAccountDA.RecurringItemDetailDataTable();
    private readonly RecurringTaskDetailBLL objRecurringTaskDetailBll = new RecurringTaskDetailBLL();
    private CloudAccountDA.RecurringTaskDetailDataTable objRecurringTaskDetailDT = new CloudAccountDA.RecurringTaskDetailDataTable();
    private readonly InvoiceMasterBLL objInvoiceMasterBll = new InvoiceMasterBLL();
    private CloudAccountDA.InvoiceMasterDataTable objInvoiceMasterDT = new CloudAccountDA.InvoiceMasterDataTable();
    private readonly InvoiceItemDetailBLL objInvoiceItemDetailBll = new InvoiceItemDetailBLL();
    private readonly InvoiceTaskDetailBLL objInvoiceTaskDetailBll = new InvoiceTaskDetailBLL();
    private readonly TaxMasterBLL objTaxMasterBll = new TaxMasterBLL();
    private CloudAccountDA.TaxMasterDataTable objTaxMasterDT = new CloudAccountDA.TaxMasterDataTable();
    private readonly InvoiceDefaultTermsMasterBLL objTermsBll = new InvoiceDefaultTermsMasterBLL();
    private CloudAccountDA.InvoiceDefaultTermsMasterDataTable objTermsDT = new CloudAccountDA.InvoiceDefaultTermsMasterDataTable();
    private readonly StateMasterBLL objStateMasterBll = new StateMasterBLL();
    private CloudAccountDA.StateMasterDataTable objStateMasterDT = new CloudAccountDA.StateMasterDataTable();
    private readonly MiscellaneousMasterBLL objMiscellaneousMasterBll = new MiscellaneousMasterBLL();
    private CloudAccountDA.MiscellaneousMasterDataTable objMiscellaneousMasterDT = new CloudAccountDA.MiscellaneousMasterDataTable();
    private string dateFormat = "MM/dd/yyyy";
    private int linePerPage = 15;
    private string branding = "block";
    private string directLink = "block";
    private string defaultColumn = "Both";
    private readonly NewInvoiceEmailTemplateBLL objNewInvoiceEmailTemplateBll = new NewInvoiceEmailTemplateBLL();
    private CloudAccountDA.NewInvoiceEmailTemplateDataTable objNewInvoiceEmailTemplateDT = new CloudAccountDA.NewInvoiceEmailTemplateDataTable();
    private readonly SMTPSettingsBLL objSMTPSettingsBll = new SMTPSettingsBLL();
    private CloudAccountDA.SMTPSettingsDataTable objSMTPSettingsDT = new CloudAccountDA.SMTPSettingsDataTable();
    protected ToolkitScriptManager tsm;
    protected HtmlGenericControl divSave;
    protected HtmlGenericControl divUpdate;
    protected Panel pnlAdd;
    protected Label lblAddUpdate;
    protected UpdatePanel upRecuuring;
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
    protected TextBox txtSchedule;
    protected RequiredFieldValidator rfvSchedule;
    protected CalendarExtender ceSchedule;
    protected DropDownList ddlHowOften;
    protected SqlDataSource sqldsFrequency;
    protected RequiredFieldValidator rfvHowoften;
    protected TextBox txtHowMany;
    protected RequiredFieldValidator rfvClient;
    protected DropDownList ddlClient;
    protected SqlDataSource sqldsClient;
    protected SqlDataSource sqldsClientStaff;
    protected HtmlGenericControl clientAddress;
    protected DropDownList ddlCurrency;
    protected SqlDataSource sqldsCurrency;
    protected CheckBox chkEmail;
    protected CheckBox chkSnailMail;
    protected Label lblAddress;
    protected LinkButton lblEditAddress;
    protected TextBox txtPONumber;
    protected TextBox txtDiscount;
    protected GridView gvTask;
    protected GridView gvItem;
    protected SqlDataSource sqldsTask;
    protected SqlDataSource sqldsItem;
    protected SqlDataSource sqldsTax;
    protected LinkButton lnkAddTask;
    protected LinkButton lnkAddItem;
    protected Label lblCurrencySymbol2;
    protected Label lblSubTotal;
    protected Label lblDiscount;
    protected HtmlGenericControl divTax;
    protected Label lblAddedTaxes;
    protected HtmlGenericControl divTaxValue;
    protected Label lblCurrencyCode;
    protected Label lblCurrencySymbol1;
    protected Label lblBalance;
    protected CheckBox chkProrate;
    protected TextBox txtProrateDay;
    protected LinkButton lnkSetTerms;
    protected TextBox txtTerms;
    protected TextBox txtNotes;
    protected ModalPopupExtender mpInvoiceTerms;
    protected Panel pnlInvoiceTerms;
    protected LinkButton lnkClose;
    protected TextBox txtDefaultTerms;
    protected Button btnSaveTerms;
    protected HtmlGenericControl savebtn;
    protected Button btnSave;
    protected HtmlGenericControl updatebtn;
    protected Button btnUpdate;
    protected Button btnStopRecurring;
    protected Panel pnlViewAll;
    protected Label lblHeader;
    protected Button btnAdd;
    protected TextBox txtProfileNumberSearch;
    protected TextBox txtClientNameSearch;
    protected TextBox txtItemNameSearch;
    protected TextBox txtItemDescSearch;
    protected TextBox txtPONumberSearch;
    protected TextBox txtNotesSearch;
    protected DropDownList ddlFrequencySearch;
    protected SqlDataSource sqldsFrequencySearch;
    protected TextBox txtAmountFrom;
    protected TextBox txtAmountTo;
    protected DropDownList ddlCurrencySearch;
    protected SqlDataSource sqldsCurrencySearch;
    protected Button btnSearch;
    protected Button btnReset;
    protected Button btnUnDelete;
    protected Button btnArchived;
    protected Button btnUnArchived;
    protected Button btnDelete;
    protected Button btnCopy;
    protected GridView gvRecurring;
    protected HtmlAnchor activeTag;
    protected HtmlAnchor archivedTag;
    protected HtmlAnchor deletedTag;
    protected ObjectDataSource objdsRecurring;
    protected ObjectDataSource objdsRecurringStaff;
    protected HiddenField hfCompanyID;
    protected HiddenField hfStaffID;
    protected HiddenField hfCompanyClientID;
    protected HiddenField hfRecurringID;
    protected HiddenField hfRecurringNum;

    protected void Page_Load(object sender, EventArgs e)
    {
      this.Page.MaintainScrollPositionOnPostBack = true;
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("invoice")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("recurring")).Attributes.Add("class", "active open");
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
          {
            this.hfCompanyID.Value = this.objStaffMasterDT.Rows[0]["CompanyID"].ToString();
            this.hfStaffID.Value = this.objStaffMasterDT.Rows[0]["StaffID"].ToString();
          }
        }
        this.ceSchedule.Format = this.dateFormat;
        this.SetMiscValues(this.hfCompanyID.Value);
      }
      if (this.IsPostBack)
        return;
      this.divSave.Visible = this.Session["saveRecurring"] != null;
      this.divUpdate.Visible = this.Session["updateRecurring"] != null;
      this.Session.Abandon();
      if (this.Request.QueryString["cmd"] != null)
      {
        string str = this.Request.QueryString["cmd"];
        this.BindDropDown();
        switch (str)
        {
          case "copied":
            if (this.Request.QueryString["ID"] == null)
              break;
            this.SetRecord(this.Request.QueryString["ID"]);
            this.pnlAdd.Visible = true;
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
              this.pnlViewAll.Visible = false;
              this.savebtn.Visible = false;
              this.updatebtn.Visible = true;
              this.ddlClient.Focus();
              break;
            }
            this.Clear();
            this.ddlClient.Focus();
            this.pnlViewAll.Visible = false;
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
            this.ATagStyle();
            this.pnlViewAll.Visible = true;
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
        this.ATagStyle();
        this.pnlViewAll.Visible = true;
        this.pnlAdd.Visible = false;
        this.BindGrid();
      }
    }

    private void SetMiscValues(string companyID)
    {
      this.objMiscellaneousMasterDT = this.objMiscellaneousMasterBll.GetDataByCompanyID(int.Parse(companyID));
      if (this.objMiscellaneousMasterDT.Rows.Count <= 0)
        return;
      this.dateFormat = this.objMiscellaneousMasterDT.Rows[0]["DateFormat"].ToString();
      this.linePerPage = int.Parse(this.objMiscellaneousMasterDT.Rows[0]["LinesPerPage"].ToString());
      this.gvRecurring.PageSize = this.linePerPage;
      this.ceSchedule.Format = this.dateFormat;
      this.branding = (bool) this.objMiscellaneousMasterDT.Rows[0]["DoyinGoBranding"] ? "none" : "block";
      this.directLink = (bool) this.objMiscellaneousMasterDT.Rows[0]["DirectLinks"] ? "none" : "block";
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

    private void ATagStyle()
    {
      if (this.Request.QueryString["ac"] != null && bool.Parse(this.Request.QueryString["ac"]))
      {
        this.activeTag.Attributes.Add("class", "activeTag");
        this.activeTag.Attributes.Remove("href");
        this.lblHeader.Text = "Recurring Profiles";
      }
      if (this.Request.QueryString["ar"] != null && bool.Parse(this.Request.QueryString["ar"]))
      {
        this.archivedTag.Attributes.Add("class", "activeTag");
        this.archivedTag.Attributes.Remove("href");
        this.lblHeader.Text = "Archived Recurring Profiles";
      }
      if (this.Request.QueryString["de"] != null && bool.Parse(this.Request.QueryString["de"]))
      {
        this.deletedTag.Attributes.Add("class", "activeTag");
        this.deletedTag.Attributes.Remove("href");
        this.lblHeader.Text = "Deleted Recurring Profiles";
      }
      if (this.Request.QueryString["ar"] != null || this.Request.QueryString["ac"] != null || this.Request.QueryString["de"] != null)
        return;
      this.activeTag.Attributes.Add("class", "activeTag");
      this.activeTag.Attributes.Remove("href");
      this.lblHeader.Text = "Recurring Profiles";
    }

    private void BindGrid()
    {
      MembershipUser user = Membership.GetUser();
      if (user != null)
      {
        string username = user.ToString();
        if (Roles.IsUserInRole(username, "Admin"))
          this.gvRecurring.DataSource = (object) this.objdsRecurring;
        else if (Roles.IsUserInRole(username, "Employee"))
          this.gvRecurring.DataSource = (object) this.objdsRecurringStaff;
      }
      this.gvRecurring.DataBind();
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

    private void SetRecord(string id)
    {
      this.objTermsDT = this.objTermsBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objTermsDT.Rows.Count > 0)
        this.txtDefaultTerms.Text = this.objTermsDT.Rows[0]["DefaultTerms"].ToString();
      this.objRecurringMasterDT = this.objRecurringMasterBll.GetDataByRecurringID(int.Parse(id));
      if (this.objRecurringMasterDT.Rows.Count <= 0)
        return;
      this.hfCompanyID.Value = this.objRecurringMasterDT.Rows[0]["CompanyID"].ToString();
      this.hfRecurringID.Value = this.objRecurringMasterDT.Rows[0]["RecurringID"].ToString();
      this.hfRecurringNum.Value = this.objRecurringMasterDT.Rows[0]["RecurringNumber"].ToString();
      this.lblAddUpdate.Text = "Recurring Profile : " + this.hfRecurringNum.Value;
      if (this.Request.QueryString["cmd"] == "add")
        this.ddlClient.Items.Add(this.objRecurringMasterDT.Rows[0]["ClientID"].ToString());
      this.ddlClient.SelectedValue = this.objRecurringMasterDT.Rows[0]["ClientID"].ToString();
      this.ddlClient_SelectedIndexChanged((object) null, (EventArgs) null);
      this.txtPONumber.Text = this.objRecurringMasterDT.Rows[0]["PONumber"].ToString();
      this.txtDiscount.Text = this.objRecurringMasterDT.Rows[0]["Discount"].ToString();
      this.txtTerms.Text = this.objRecurringMasterDT.Rows[0]["Terms"].ToString();
      this.txtNotes.Text = this.objRecurringMasterDT.Rows[0]["Notes"].ToString();
      this.txtSchedule.Text = DateTime.Parse(this.objRecurringMasterDT.Rows[0]["RecurringSchedule"].ToString()).ToString(this.dateFormat);
      this.ddlHowOften.SelectedValue = this.objRecurringMasterDT.Rows[0]["HowOften"].ToString();
      this.txtHowMany.Text = this.objRecurringMasterDT.Rows[0]["HowManyInvoice"].ToString();
      this.chkProrate.Checked = bool.Parse(this.objRecurringMasterDT.Rows[0]["ProrateFirstInvoice"].ToString());
      this.txtProrateDay.Text = this.objRecurringMasterDT.Rows[0]["ProrateFirstInvoiceDays"].ToString();
      this.FirstGridEditRow();
      this.objRecurringItemDetailDT = this.objRecurringItemDetailBll.GetDataByRecurringID(int.Parse(this.hfRecurringID.Value));
      if (this.objRecurringItemDetailDT.Rows.Count > 0)
      {
        int index1 = 0;
        for (int index2 = 0; index2 < this.objRecurringItemDetailDT.Rows.Count; ++index2)
        {
          this.AddNewItemRow();
          DropDownList dropDownList1 = (DropDownList) this.gvItem.Rows[index1].Cells[0].FindControl("ddlItem");
          TextBox textBox1 = (TextBox) this.gvItem.Rows[index1].Cells[1].FindControl("txtItemDesc");
          TextBox textBox2 = (TextBox) this.gvItem.Rows[index1].Cells[2].FindControl("txtUnitCost");
          TextBox textBox3 = (TextBox) this.gvItem.Rows[index1].Cells[3].FindControl("txtQty");
          DropDownList dropDownList2 = (DropDownList) this.gvItem.Rows[index1].Cells[4].FindControl("ddlItemTax1");
          DropDownList dropDownList3 = (DropDownList) this.gvItem.Rows[index1].Cells[5].FindControl("ddlItemTax2");
          Label label = (Label) this.gvItem.Rows[index1].Cells[6].FindControl("lblItemLineTotal");
          dropDownList1.SelectedValue = this.objRecurringItemDetailDT.Rows[index2]["ItemID"].ToString();
          textBox1.Text = this.objRecurringItemDetailDT.Rows[index2]["ItemDesc"].ToString();
          if (!string.IsNullOrEmpty(this.objRecurringItemDetailDT.Rows[index2]["Tax1"].ToString()))
            dropDownList2.SelectedValue = this.objRecurringItemDetailDT.Rows[index2]["Tax1"].ToString();
          if (!string.IsNullOrEmpty(this.objRecurringItemDetailDT.Rows[index2]["Tax2"].ToString()))
            dropDownList3.SelectedValue = this.objRecurringItemDetailDT.Rows[index2]["Tax2"].ToString();
          textBox2.Text = !string.IsNullOrEmpty(this.objRecurringItemDetailDT.Rows[index2]["UnitCost"].ToString()) ? this.objRecurringItemDetailDT.Rows[index2]["UnitCost"].ToString() : "0.00";
          textBox3.Text = !string.IsNullOrEmpty(this.objRecurringItemDetailDT.Rows[index2]["Quantity"].ToString()) ? this.objRecurringItemDetailDT.Rows[index2]["Quantity"].ToString() : "0.00";
          label.Text = !string.IsNullOrEmpty(this.objRecurringItemDetailDT.Rows[index2]["Total"].ToString()) ? this.objRecurringItemDetailDT.Rows[index2]["Total"].ToString() : "0.00";
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
            string s = Decimal.Round(RecurringInvoice.CalculateRowTotal(hours, rate), 2).ToString();
            label3.Text = Decimal.Round(RecurringInvoice.CalculateRowTotal(hours, rate), 2).ToString();
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
      this.objRecurringTaskDetailDT = this.objRecurringTaskDetailBll.GetDataByRecurringID(int.Parse(this.hfRecurringID.Value));
      if (this.objRecurringTaskDetailDT.Rows.Count > 0)
      {
        int index1 = 0;
        for (int index2 = 0; index2 < this.objRecurringTaskDetailDT.Rows.Count; ++index2)
        {
          this.AddNewTaskRow();
          DropDownList dropDownList1 = (DropDownList) this.gvTask.Rows[index1].Cells[0].FindControl("ddlTask");
          TextBox textBox1 = (TextBox) this.gvTask.Rows[index1].Cells[1].FindControl("txtDesc");
          TextBox textBox2 = (TextBox) this.gvTask.Rows[index1].Cells[2].FindControl("txtRate");
          TextBox textBox3 = (TextBox) this.gvTask.Rows[index1].Cells[3].FindControl("txtHours");
          DropDownList dropDownList2 = (DropDownList) this.gvTask.Rows[index1].Cells[4].FindControl("ddlTaskTax1");
          DropDownList dropDownList3 = (DropDownList) this.gvTask.Rows[index1].Cells[5].FindControl("ddlTaskTax2");
          Label label = (Label) this.gvTask.Rows[index1].Cells[6].FindControl("lblTaskLineTotal");
          dropDownList1.SelectedValue = this.objRecurringTaskDetailDT.Rows[index2]["TaskID"].ToString();
          textBox1.Text = this.objRecurringTaskDetailDT.Rows[index2]["TaskDesc"].ToString();
          textBox2.Text = !string.IsNullOrEmpty(this.objRecurringTaskDetailDT.Rows[index2]["Rate"].ToString()) ? this.objRecurringTaskDetailDT.Rows[index2]["Rate"].ToString() : "0.00";
          textBox3.Text = !string.IsNullOrEmpty(this.objRecurringTaskDetailDT.Rows[index2]["Hours"].ToString()) ? this.objRecurringTaskDetailDT.Rows[index2]["Hours"].ToString() : "0.00";
          label.Text = !string.IsNullOrEmpty(this.objRecurringTaskDetailDT.Rows[index2]["Total"].ToString()) ? this.objRecurringTaskDetailDT.Rows[index2]["Total"].ToString() : "0.00";
          if (!string.IsNullOrEmpty(this.objRecurringTaskDetailDT.Rows[index2]["Tax1"].ToString()))
            dropDownList2.SelectedValue = this.objRecurringTaskDetailDT.Rows[index2]["Tax1"].ToString();
          if (!string.IsNullOrEmpty(this.objRecurringTaskDetailDT.Rows[index2]["Tax2"].ToString()))
            dropDownList3.SelectedValue = this.objRecurringTaskDetailDT.Rows[index2]["Tax2"].ToString();
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
            string s = Decimal.Round(RecurringInvoice.CalculateRowTotal(hours, rate), 2).ToString();
            label3.Text = Decimal.Round(RecurringInvoice.CalculateRowTotal(hours, rate), 2).ToString();
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
      this.lblAddUpdate.Text = "New Recurring Profile";
      this.txtSchedule.Text = DateTime.Now.ToString(this.dateFormat);
      this.objTermsDT = this.objTermsBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objTermsDT.Rows.Count > 0)
        this.txtTerms.Text = this.txtDefaultTerms.Text = this.objTermsDT.Rows[0]["DefaultTerms"].ToString();
      this.objRecurringMasterDT = this.objRecurringMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objRecurringMasterDT.Rows.Count > 0)
        this.hfRecurringNum.Value = RecurringInvoice.NextNum(this.objRecurringMasterDT.Rows[this.objRecurringMasterDT.Rows.Count - 1]["RecurringNumber"].ToString());
      else
        this.hfRecurringNum.Value = ConfigurationManager.AppSettings["RecurringNoStart"];
    }

    public static string NextNum(string invNum)
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
          this.chkEmail.Checked = bool.Parse(this.objCompanyClientMasterDT.Rows[0]["InvoiceByEmail"].ToString());
          this.chkSnailMail.Checked = bool.Parse(this.objCompanyClientMasterDT.Rows[0]["InvoiceBySnailMail"].ToString());
          string str1 = string.Empty;
          string s1 = this.objCompanyClientMasterDT.Rows[0]["CurrencyID"].ToString();
          string s2 = this.objCompanyClientMasterDT.Rows[0]["CountryID"].ToString();
          string s3 = this.objCompanyClientMasterDT.Rows[0]["StateID"].ToString();
          string s4 = this.objCompanyClientMasterDT.Rows[0]["CityID"].ToString();
          string str2 = str1 + this.objCompanyClientMasterDT.Rows[0]["Address1"].ToString() + (this.objCompanyClientMasterDT.Rows[0]["Address1"].ToString().Trim().Length > 0 ? "<br />" : "") + this.objCompanyClientMasterDT.Rows[0]["Address2"].ToString() + (this.objCompanyClientMasterDT.Rows[0]["Address2"].ToString().Trim().Length > 0 ? "<br />" : "");
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
          if (!string.IsNullOrEmpty(s4))
          {
            this.objCityMasterDT = this.objCityMasterBll.GetDataByCityID(int.Parse(s4));
            str2 = str2 + this.objCityMasterDT.Rows[0]["CityName"].ToString() + (this.objCityMasterDT.Rows[0]["CityName"].ToString().Trim().Length > 0 ? "&nbsp;" : "");
          }
          if (!string.IsNullOrEmpty(s3))
          {
            this.objStateMasterDT = this.objStateMasterBll.GetDataByStateID(int.Parse(s3));
            str2 = str2 + this.objStateMasterDT.Rows[0]["StateName"].ToString() + (this.objStateMasterDT.Rows[0]["StateName"].ToString().Trim().Length > 0 ? "&nbsp;&nbsp;" : "");
          }
          string str3 = str2 + this.objCompanyClientMasterDT.Rows[0]["ZipCode"].ToString() + (this.objCompanyClientMasterDT.Rows[0]["ZipCode"].ToString().Trim().Length > 0 ? "<br />" : "");
          if (!string.IsNullOrEmpty(s2))
          {
            this.objCountryMasterDT = this.objCountryMasterBll.GetDataByCountryID(int.Parse(s2));
            str3 = str3 + this.objCountryMasterDT.Rows[0]["CountryName"].ToString() + (this.objCountryMasterDT.Rows[0]["CountryName"].ToString().Trim().Length > 0 ? "<br />" : "");
          }
          this.lblAddress.Text = !string.IsNullOrEmpty(s2 + (object) s4 + (string) this.objCompanyClientMasterDT.Rows[0]["Address1"] + (string) this.objCompanyClientMasterDT.Rows[0]["Address2"] + (string) this.objCompanyClientMasterDT.Rows[0]["ZipCode"]) ? str3 : "<i>No mailing address specified for this client.</i>";
          this.clientAddress.Visible = true;
          this.normalDetails.Visible = true;
          this.clienDetails.Visible = false;
        }
      }
      this.CalculateTotal();
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
          label.Text = Decimal.Round(RecurringInvoice.CalculateRowTotal(Decimal.Parse(textBox2.Text), Decimal.Parse(textBox3.Text)), 2).ToString();
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
      if (this.txtDiscount.Text.Trim().Length <= 0)
        this.txtDiscount.Text = "0.00";
      this.lblSubTotal.Text = Decimal.Round(d1, 2).ToString();
      Decimal d2 = Decimal.Parse(this.lblSubTotal.Text) * Decimal.Parse(this.txtDiscount.Text) / new Decimal(100);
      this.lblDiscount.Text = Decimal.Round(d2, 2).ToString();
      this.lblBalance.Text = (num1 - Decimal.Round(d2, 2)).ToString();
      if (hashtable.Count <= 0)
        return;
      foreach (string str in (IEnumerable) hashtable.Keys)
      {
        this.divTax.Controls.Add((Control) new Label()
        {
          Text = str
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
      string s = Decimal.Round(RecurringInvoice.CalculateRowTotal(hours, rate), 2).ToString();
      label3.Text = Decimal.Round(RecurringInvoice.CalculateRowTotal(hours, rate), 2).ToString();
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
      string s = Decimal.Round(RecurringInvoice.CalculateRowTotal(hours, rate), 2).ToString();
      label3.Text = Decimal.Round(RecurringInvoice.CalculateRowTotal(hours, rate), 2).ToString();
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

    protected void btnSaveTerms_Click(object sender, EventArgs e)
    {
      this.objTermsDT = this.objTermsBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objTermsDT.Rows.Count > 0)
        this.objTermsBll.UpdateInvoiceDefaultTerms(int.Parse(this.objTermsDT.Rows[0]["InvoiceDefaultTermsID"].ToString()), int.Parse(this.hfCompanyID.Value), this.txtDefaultTerms.Text.Trim());
      else
        this.objTermsBll.AddInvoiceDefaultTerms(int.Parse(this.hfCompanyID.Value), this.txtDefaultTerms.Text.Trim());
      this.mpInvoiceTerms.Hide();
      this.SetDefaultValues();
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
      for (int index = 0; index < this.gvRecurring.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvRecurring.Rows[index].Cells[0].FindControl("chkID");
        if (checkBox.Checked)
        {
          ++num;
          this.objRecurringMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), false, false, true);
        }
      }
      if (num == 0)
        this.DisplayAlert("No Recurrings were selected.");
      else
        this.Response.Redirect("RecurringInvoice.aspx");
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      int num = 0;
      for (int index = 0; index < this.gvRecurring.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvRecurring.Rows[index].Cells[0].FindControl("chkID");
        if (checkBox.Checked)
        {
          ++num;
          this.objRecurringMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), false, true, false);
        }
      }
      if (num == 0)
        this.DisplayAlert("No Recurrings were selected.");
      else
        this.Response.Redirect("RecurringInvoice.aspx?de=true&ac=false");
    }

    protected void btnCopy_Click(object sender, EventArgs e)
    {
      int num = 0;
      string str = string.Empty;
      for (int index = 0; index < this.gvRecurring.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvRecurring.Rows[index].Cells[0].FindControl("chkID");
        if (checkBox.Checked)
        {
          ++num;
          str = checkBox.ToolTip;
        }
      }
      if (num == 0)
        this.DisplayAlert("No Recurrings were selected.");
      else if (num > 1)
      {
        this.DisplayAlert("More than one Recurrings were selected. Please Select Only One Recurring.");
      }
      else
      {
        if (num != 1 || string.IsNullOrEmpty(str))
          return;
        this.Response.Redirect("RecurringInvoice.aspx?cmd=copied&ID=" + str);
      }
    }

    protected void btnUnArchived_Click(object sender, EventArgs e)
    {
      int num = 0;
      for (int index = 0; index < this.gvRecurring.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvRecurring.Rows[index].Cells[0].FindControl("chkID");
        if (checkBox.Checked)
        {
          ++num;
          this.objRecurringMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), true, false, false);
        }
      }
      if (num == 0)
        this.DisplayAlert("No Recurrings were selected.");
      else
        this.Response.Redirect("RecurringInvoice.aspx?ar=true&ac=false");
    }

    protected void btnUnDelete_Click(object sender, EventArgs e)
    {
      int num = 0;
      for (int index = 0; index < this.gvRecurring.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvRecurring.Rows[index].Cells[0].FindControl("chkID");
        if (checkBox.Checked)
        {
          ++num;
          this.objRecurringMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), true, false, false);
        }
      }
      if (num == 0)
        this.DisplayAlert("No Recurrings were selected.");
      else
        this.Response.Redirect("RecurringInvoice.aspx?de=true&ac=false");
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
      this.Response.Redirect("RecurringInvoice.aspx?cmd=add");
    }

    protected void gvRecurring_Sorting(object sender, GridViewSortEventArgs e)
    {
      this.BindGrid();
    }

    protected void gvRecurring_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.BindGrid();
    }

    protected void gvRecurring_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvRecurring.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void gvRecurring_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(e.Row.Cells[2].Text));
        e.Row.Cells[2].Text = this.objCompanyClientMasterDT.Rows[0]["OrganizationName"].ToString();
        Label label = e.Row.FindControl("lbl") as Label;
        this.objFrequencyMasterDT = this.objFrequencyMasterBll.GetDataByFrequencyID(int.Parse(e.Row.Cells[4].Text));
        e.Row.Cells[4].Text = this.objFrequencyMasterDT.Rows[0]["FrequencyName"].ToString();
        if (label != null && !bool.Parse(label.CssClass))
        {
          int num = int.Parse(this.objFrequencyMasterDT.Rows[0]["NoOfDays"].ToString()) * -1;
          string[] formats = new string[6]
          {
            "MM/dd/yy",
            "MM/dd/yyyy",
            "dd/MM/yy",
            "dd/MM/yyyy",
            "yy-MM-dd",
            "yyyy-MM-dd"
          };
          string s = DateTime.ParseExact(e.Row.Cells[3].Text, formats, (IFormatProvider) CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("MM/dd/yyyy");
          e.Row.Cells[3].Text = DateTime.Parse(s).AddDays((double) num).ToString("MM/dd/yyyy");
        }
        else
          e.Row.Cells[3].Text = "never";
      }
      BoundField boundField = ((GridView) sender).Columns[3] as BoundField;
      if (boundField == null)
        return;
      boundField.DataFormatString = "{0:" + this.dateFormat + "}";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.ddlClient.SelectedIndex > 0 && this.ddlHowOften.SelectedIndex > 0 && this.txtSchedule.Text.Trim().Length > 0)
      {
        int? iCurrencyID = new int?();
        int? iProprateFirstInvoiceDay = new int?();
        bool bProprateFirstInvoice = false;
        if (this.ddlCurrency.SelectedIndex > 0 || !string.IsNullOrEmpty(this.ddlCurrency.SelectedItem.Value))
          iCurrencyID = new int?(int.Parse(this.ddlCurrency.SelectedItem.Value));
        if (this.chkProrate.Checked && !string.IsNullOrEmpty(this.txtProrateDay.Text.Trim()))
        {
          bProprateFirstInvoice = true;
          iProprateFirstInvoiceDay = new int?(int.Parse(this.txtProrateDay.Text.Trim()));
        }
        bool bRecurringActive = true;
        int num1;
        string sRemainingInvoice;
        try
        {
          num1 = int.Parse(this.txtHowMany.Text.Trim());
          sRemainingInvoice = this.txtHowMany.Text.Trim();
        }
        catch (Exception ex)
        {
          num1 = -1;
          sRemainingInvoice = this.txtHowMany.Text = "infinite";
        }
        string str = DateTime.ParseExact(this.txtSchedule.Text, new string[6]
        {
          "MM/dd/yy",
          "MM/dd/yyyy",
          "dd/MM/yy",
          "dd/MM/yyyy",
          "yy-MM-dd",
          "yyyy-MM-dd"
        }, (IFormatProvider) CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("MM/dd/yyyy");
        DateTime dateTime = DateTime.Parse(this.txtSchedule.Text.Trim());
        if (DateTime.Now.ToString("MM/dd/yyyy") == str)
        {
          this.objFrequencyMasterDT = this.objFrequencyMasterBll.GetDataByFrequencyID(int.Parse(this.ddlHowOften.SelectedItem.Value));
          if (this.objFrequencyMasterDT.Rows.Count > 0)
          {
            int num2 = int.Parse(this.objFrequencyMasterDT.Rows[0]["NoOfDays"].ToString());
            dateTime = dateTime.AddDays((double) num2);
          }
          switch (num1)
          {
            case -1:
              sRemainingInvoice = this.txtHowMany.Text = "infinite";
              break;
            case 0:
              sRemainingInvoice = this.txtHowMany.Text = num1.ToString();
              bRecurringActive = false;
              break;
            default:
              this.txtHowMany.Text = num1.ToString();
              sRemainingInvoice = (num1 - 1).ToString();
              if (sRemainingInvoice == "0")
              {
                bRecurringActive = false;
                break;
              }
              break;
          }
        }
        int iRecurringID = this.objRecurringMasterBll.AddRecurring(int.Parse(this.hfCompanyID.Value), new DateTime?(DateTime.Now), int.Parse(this.ddlHowOften.SelectedItem.Value), this.txtHowMany.Text.Trim(), sRemainingInvoice, new DateTime?(dateTime), new int?(int.Parse(this.ddlClient.SelectedItem.Value)), iCurrencyID, this.hfRecurringNum.Value, new DateTime?(DateTime.Now), this.txtPONumber.Text.Trim(), new Decimal?(Decimal.Parse(this.txtDiscount.Text.Trim())), new Decimal?(Decimal.Parse(this.lblDiscount.Text.Trim())), bProprateFirstInvoice, iProprateFirstInvoiceDay, bRecurringActive, this.txtNotes.Text.Trim(), this.txtTerms.Text.Trim(), "", new Decimal?(Decimal.Parse(this.lblBalance.Text.Trim())), true, false, false);
        if (iRecurringID != 0)
        {
          this.SetItemRowData();
          DataTable dataTable1 = this.ViewState["ItemTable"] as DataTable;
          if (dataTable1 != null)
          {
            foreach (DataRow dataRow in (InternalDataCollectionBase) dataTable1.Rows)
            {
              string s1 = dataRow.ItemArray[0] as string;
              string sItemDesc = dataRow.ItemArray[1] as string;
              string s2 = dataRow.ItemArray[2] as string;
              string s3 = dataRow.ItemArray[3] as string;
              string s4 = dataRow.ItemArray[4] as string;
              string s5 = dataRow.ItemArray[5] as string;
              string s6 = dataRow.ItemArray[6] as string;
              if (s1 != null && !string.IsNullOrEmpty(s1) && s1 != "-1")
              {
                int? iTaxID1 = new int?();
                int? iTaxID2 = new int?();
                Decimal? dUnitCost = new Decimal?();
                Decimal? dQuantity = new Decimal?();
                if (!string.IsNullOrEmpty(s4) && s4 != "-1")
                  iTaxID1 = new int?(int.Parse(s4));
                if (!string.IsNullOrEmpty(s5) && s5 != "-1")
                  iTaxID2 = new int?(int.Parse(s5));
                if (!string.IsNullOrEmpty(s2))
                  dUnitCost = new Decimal?(Decimal.Parse(s2));
                if (!string.IsNullOrEmpty(s3))
                  dQuantity = new Decimal?(Decimal.Parse(s3));
                this.objRecurringItemDetailBll.AddRecurringItem(iRecurringID, int.Parse(s1), sItemDesc, dUnitCost, dQuantity, iTaxID1, iTaxID2, new Decimal?(Decimal.Parse(s6)));
                this.objItemMasterDT = this.objItemMasterBll.GetDataByItemID(int.Parse(s1));
                if (this.objItemMasterDT.Rows.Count > 0 && bool.Parse(this.objItemMasterDT.Rows[0]["TrackInventory"].ToString()))
                {
                  Decimal num2 = Decimal.Parse(this.objItemMasterDT.Rows[0]["CurrentStock"].ToString());
                  ItemMasterBLL itemMasterBll = this.objItemMasterBll;
                  int iItemID = int.Parse(s1);
                  Decimal num3 = num2;
                  Decimal? nullable = dQuantity;
                  Decimal? dCurrentStock = nullable.HasValue ? new Decimal?(num3 - nullable.GetValueOrDefault()) : new Decimal?();
                  itemMasterBll.UpdateCurrentStock(iItemID, dCurrentStock);
                }
              }
            }
          }
          this.SetTaskRowData();
          DataTable dataTable2 = this.ViewState["TaskTable"] as DataTable;
          if (dataTable2 != null)
          {
            foreach (DataRow dataRow in (InternalDataCollectionBase) dataTable2.Rows)
            {
              string s1 = dataRow.ItemArray[0] as string;
              string sTaskDesc = dataRow.ItemArray[1] as string;
              string s2 = dataRow.ItemArray[2] as string;
              string s3 = dataRow.ItemArray[3] as string;
              string s4 = dataRow.ItemArray[4] as string;
              string s5 = dataRow.ItemArray[5] as string;
              string s6 = dataRow.ItemArray[6] as string;
              if (s1 != null && !string.IsNullOrEmpty(s1) && s1 != "-1")
              {
                int? iTaxID1 = new int?();
                int? iTaxID2 = new int?();
                Decimal? dRate = new Decimal?();
                Decimal? dHours = new Decimal?();
                if (!string.IsNullOrEmpty(s4) && s4 != "-1")
                  iTaxID1 = new int?(int.Parse(s4));
                if (!string.IsNullOrEmpty(s5) && s5 != "-1")
                  iTaxID2 = new int?(int.Parse(s5));
                if (!string.IsNullOrEmpty(s2))
                  dRate = new Decimal?(Decimal.Parse(s2));
                if (!string.IsNullOrEmpty(s3))
                  dHours = new Decimal?(Decimal.Parse(s3));
                this.objRecurringTaskDetailBll.AddRecurringTask(iRecurringID, int.Parse(s1), sTaskDesc, dRate, dHours, iTaxID1, iTaxID2, new Decimal?(Decimal.Parse(s6)));
              }
            }
          }
          if (DateTime.Now.ToString("MM/dd/yyyy") == DateTime.Parse(this.txtSchedule.Text.Trim()).ToString("MM/dd/yyyy"))
          {
            this.objInvoiceMasterDT = this.objInvoiceMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
            string sInvoiceNumber = this.objInvoiceMasterDT.Rows.Count <= 0 ? ConfigurationManager.AppSettings["InvoiceNoStart"] : InvoiceMaster.NextNum(this.objInvoiceMasterDT.Rows[this.objInvoiceMasterDT.Rows.Count - 1]["InvoiceNumber"].ToString());
            int num2 = 0;
            this.objRecurringMasterDT = this.objRecurringMasterBll.GetDataByRecurringID(iRecurringID);
            if (this.objRecurringMasterDT.Rows.Count > 0)
            {
              num2 = this.objInvoiceMasterBll.AddInvoice(sInvoiceNumber, iRecurringID);
              if (num2 != 0)
              {
                this.objRecurringItemDetailDT = this.objRecurringItemDetailBll.GetDataByRecurringID(iRecurringID);
                if (this.objRecurringItemDetailDT.Rows.Count > 0)
                  this.objInvoiceItemDetailBll.AddInvoiceItem(num2, iRecurringID);
                this.objRecurringTaskDetailDT = this.objRecurringTaskDetailBll.GetDataByRecurringID(iRecurringID);
                if (this.objRecurringTaskDetailDT.Rows.Count > 0)
                  this.objInvoiceTaskDetailBll.AddInvoiceTask(num2, iRecurringID);
              }
            }
            this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(this.ddlClient.SelectedItem.Value));
            if (this.objCompanyClientMasterDT.Rows.Count > 0 && num2 != 0)
              this.SendMailNew(num2);
          }
          this.Session["saveRecurring"] = (object) 1;
          this.Response.Redirect("RecurringInvoice.aspx?cmd=add&ID=" + (object) iRecurringID);
        }
        else
          this.DisplayAlert("Problem in Insertion..Try after some time..!");
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

    private void SendMailNew(int invoiceId)
    {
      this.objInvoiceMasterDT = this.objInvoiceMasterBll.GetDataByInvoiceID(invoiceId);
      string str1 = this.objInvoiceMasterDT.Rows[0]["InvoiceNumber"].ToString();
      string s1 = this.objInvoiceMasterDT.Rows[0]["InvoiceTotal"].ToString();
      string s2 = this.objInvoiceMasterDT.Rows[0]["PaidToDate"].ToString();
      Decimal num = Decimal.Parse(s1) - Decimal.Parse(s2);
      string s3 = this.objInvoiceMasterDT.Rows[0]["ClientID"].ToString();
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      string displayName = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString().ToUpper();
      string addresses = this.objCompanyMasterDT.Rows[0]["CompanyEmail"].ToString();
      string str2 = string.Empty;
      string address1 = string.Empty;
      string str3 = string.Empty;
      string str4 = string.Empty;
      string str5 = string.Empty;
      this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(s3));
      if (this.objCompanyClientMasterDT.Rows.Count > 0)
      {
        string username = this.objCompanyClientMasterDT.Rows[0]["UserName"].ToString();
        str3 = this.objCompanyClientMasterDT.Rows[0]["OrganizationName"].ToString();
        str4 = this.objCompanyClientMasterDT.Rows[0]["FirstName"].ToString();
        str5 = this.objCompanyClientMasterDT.Rows[0]["LastName"].ToString();
        address1 = this.objCompanyClientMasterDT.Rows[0]["Email"].ToString();
        MembershipUser user = Membership.GetUser(username);
        if (user != null)
        {
          string key1 = RecurringInvoice.GenerateCode();
          string str6 = HttpUtility.UrlEncode(this.Encrypt(user.UserName, key1));
          string password = user.GetPassword();
          string key2 = RecurringInvoice.GenerateCode();
          string str7 = HttpUtility.UrlEncode(this.Encrypt(password, key2));
          str2 = string.Format("https://www.billtransact.com/CheckClient.aspx?page=invoice&anyId={0}&name={1}&tech={2}&keyname={3}&keytech={4}", (object) invoiceId, (object) str6, (object) str7, (object) key1, (object) key2);
        }
      }
      string str8 = string.Empty;
      string str9 = string.Empty;
      string address2 = "noreply@DoyniGo.com";
      this.objSMTPSettingsDT = this.objSMTPSettingsBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objSMTPSettingsDT.Rows.Count > 0)
      {
        str9 = this.objSMTPSettingsDT.Rows[0]["EmailSignature"].ToString();
        address2 = this.objSMTPSettingsDT.Rows[0]["SMTPFrom"].ToString();
      }
      this.objNewInvoiceEmailTemplateDT = this.objNewInvoiceEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objNewInvoiceEmailTemplateDT.Rows.Count > 0)
        str8 = this.objNewInvoiceEmailTemplateDT.Rows[0]["EmailBody"].ToString();
      Hashtable Variables = new Hashtable()
      {
        {
          (object) "emailTemplate",
          (object) str8
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
          (object) "invoiceNumber",
          (object) str1
        },
        {
          (object) "amountOwned",
          (object) num
        },
        {
          (object) "clientOrgName",
          (object) str3
        },
        {
          (object) "firstName",
          (object) str4
        },
        {
          (object) "lastName",
          (object) str5
        },
        {
          (object) "invoiceAmt",
          (object) s1
        },
        {
          (object) "someLink",
          (object) str2
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
          (object) str9
        }
      };
      Parser parser1 = new Parser(this.Server.MapPath("~/MailTemplate/SendInvoiceNew.html"), Variables);
      string path1 = this.Server.MapPath("~\\TempHTMLFiles\\");
      File.WriteAllText(Path.Combine(path1, "Invoice.html"), parser1.Parse());
      Parser parser2 = new Parser(path1 + "Invoice.html", Variables);
      try
      {
        MailMessage message = new MailMessage()
        {
          From = new MailAddress(address2, displayName)
        };
        message.To.Add(new MailAddress(address1));
        message.ReplyToList.Add(addresses);
        message.Subject = "New invoice " + str1 + " from " + displayName + ", sent using Bill Transact";
        message.BodyEncoding = Encoding.UTF8;
        message.Body = parser2.Parse();
        message.IsBodyHtml = true;
        SmtpClientForCompany.smtpClient(this.hfCompanyID.Value).Send(message);
        File.Delete(Path.Combine(path1, "Invoice.html"));
      }
      catch (Exception ex)
      {
        this.DisplayAlert("Error in sending mail." + (object) ex);
      }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.ddlClient.SelectedIndex > 0 && this.ddlHowOften.SelectedIndex > 0 && this.txtSchedule.Text.Trim().Length > 0)
      {
        int? iCurrencyID = new int?();
        int? iProprateFirstInvoiceDay = new int?();
        bool bProprateFirstInvoice = false;
        if (this.ddlCurrency.SelectedIndex > 0 || !string.IsNullOrEmpty(this.ddlCurrency.SelectedItem.Value))
          iCurrencyID = new int?(int.Parse(this.ddlCurrency.SelectedItem.Value));
        if (this.chkProrate.Checked && !string.IsNullOrEmpty(this.txtProrateDay.Text.Trim()))
        {
          bProprateFirstInvoice = true;
          iProprateFirstInvoiceDay = new int?(int.Parse(this.txtProrateDay.Text.Trim()));
        }
        this.objRecurringMasterDT = this.objRecurringMasterBll.GetDataByRecurringID(int.Parse(this.hfRecurringID.Value));
        DateTime dateTime = DateTime.Parse(this.objRecurringMasterDT.Rows[0]["RecurringDate"].ToString());
        bool bActive = bool.Parse(this.objRecurringMasterDT.Rows[0]["Active"].ToString());
        bool bArchived = bool.Parse(this.objRecurringMasterDT.Rows[0]["Archived"].ToString());
        bool bDeleted = bool.Parse(this.objRecurringMasterDT.Rows[0]["Deleted"].ToString());
        this.hfRecurringNum.Value = this.objRecurringMasterDT.Rows[0]["RecurringNumber"].ToString();
        bool bRecurringActive = true;
        int num1;
        try
        {
          num1 = int.Parse(this.txtHowMany.Text.Trim());
        }
        catch (Exception ex)
        {
          num1 = -1;
          this.txtHowMany.Text = "infinite";
        }
        string str = this.objRecurringMasterDT.Rows[0]["RemainingInvoice"].ToString();
        DateTime dtNextDate = DateTime.Parse(this.objRecurringMasterDT.Rows[0]["NextDate"].ToString());
        string s1 = DateTime.ParseExact(this.txtSchedule.Text, new string[6]
        {
          "MM/dd/yy",
          "MM/dd/yyyy",
          "dd/MM/yy",
          "dd/MM/yyyy",
          "yy-MM-dd",
          "yyyy-MM-dd"
        }, (IFormatProvider) CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("MM/dd/yyyy");
        if (DateTime.Now.ToString("MM/dd/yyyy") == s1)
        {
          switch (num1)
          {
            case -1:
              str = this.txtHowMany.Text = "infinite";
              break;
            case 0:
              str = this.txtHowMany.Text = num1.ToString();
              bRecurringActive = false;
              break;
            default:
              this.txtHowMany.Text = num1.ToString();
              str = (int.Parse(str) - 1).ToString();
              if (str == "0")
              {
                bRecurringActive = false;
                break;
              }
              break;
          }
        }
        if (this.objRecurringMasterBll.UpdateRecurring(int.Parse(this.hfRecurringID.Value), int.Parse(this.hfCompanyID.Value), new DateTime?(DateTime.Parse(s1)), int.Parse(this.ddlHowOften.SelectedItem.Value), this.txtHowMany.Text.Trim(), str, dtNextDate, new int?(int.Parse(this.ddlClient.SelectedItem.Value)), iCurrencyID, this.hfRecurringNum.Value, new DateTime?(dateTime), this.txtPONumber.Text.Trim(), new Decimal?(Decimal.Parse(this.txtDiscount.Text.Trim())), new Decimal?(Decimal.Parse(this.lblDiscount.Text.Trim())), bProprateFirstInvoice, iProprateFirstInvoiceDay, bRecurringActive, this.txtNotes.Text.Trim(), this.txtTerms.Text.Trim(), "", new Decimal?(Decimal.Parse(this.lblBalance.Text.Trim())), bActive, bArchived, bDeleted))
        {
          this.objRecurringItemDetailBll.DeleteByRecurring(int.Parse(this.hfRecurringID.Value));
          this.objRecurringTaskDetailBll.DeleteByRecurring(int.Parse(this.hfRecurringID.Value));
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
                this.objRecurringItemDetailBll.AddRecurringItem(int.Parse(this.hfRecurringID.Value), int.Parse(s2), sItemDesc, dUnitCost, dQuantity, iTaxID1, iTaxID2, new Decimal?(Decimal.Parse(s7)));
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
                this.objRecurringTaskDetailBll.AddRecurringTask(int.Parse(this.hfRecurringID.Value), int.Parse(s2), sTaskDesc, dRate, dHours, iTaxID1, iTaxID2, new Decimal?(Decimal.Parse(s7)));
              }
            }
          }
          if (DateTime.Now.ToString("MM/dd/yyyy") == DateTime.Parse(this.txtSchedule.Text.Trim()).ToString("MM/dd/yyyy"))
          {
            this.objInvoiceMasterDT = this.objInvoiceMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
            string sInvoiceNumber = this.objInvoiceMasterDT.Rows.Count <= 0 ? ConfigurationManager.AppSettings["InvoiceNoStart"] : InvoiceMaster.NextNum(this.objInvoiceMasterDT.Rows[this.objInvoiceMasterDT.Rows.Count - 1]["InvoiceNumber"].ToString());
            int num2 = 0;
            this.objRecurringMasterDT = this.objRecurringMasterBll.GetDataByRecurringID(int.Parse(this.hfRecurringID.Value));
            if (this.objRecurringMasterDT.Rows.Count > 0)
            {
              num2 = this.objInvoiceMasterBll.AddInvoice(sInvoiceNumber, int.Parse(this.hfRecurringID.Value));
              if (num2 != 0)
              {
                this.objRecurringItemDetailDT = this.objRecurringItemDetailBll.GetDataByRecurringID(int.Parse(this.hfRecurringID.Value));
                if (this.objRecurringItemDetailDT.Rows.Count > 0)
                  this.objInvoiceItemDetailBll.AddInvoiceItem(num2, int.Parse(this.hfRecurringID.Value));
                this.objRecurringTaskDetailDT = this.objRecurringTaskDetailBll.GetDataByRecurringID(int.Parse(this.hfRecurringID.Value));
                if (this.objRecurringTaskDetailDT.Rows.Count > 0)
                  this.objInvoiceTaskDetailBll.AddInvoiceTask(num2, int.Parse(this.hfRecurringID.Value));
              }
            }
            this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(this.ddlClient.SelectedItem.Value));
            if (this.objCompanyClientMasterDT.Rows.Count > 0 && num2 != 0)
              this.SendMailNew(num2);
          }
          this.Session["updateRecurring"] = (object) 1;
          this.Response.Redirect("RecurringInvoice.aspx?cmd=add&ID=" + (object) int.Parse(this.hfRecurringID.Value));
        }
        else
          this.DisplayAlert("Problem in Updation..Try after some time..!");
      }
      else
        this.DisplayAlert("Please Fill All Required Information");
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
      this.BindGrid();
    }

    protected string SetTrueFalse(string remaing, string howmany)
    {
      try
      {
        return int.Parse(remaing) == int.Parse(howmany) ? "true" : "false";
      }
      catch (Exception ex)
      {
        return "false";
      }
    }
  }
}

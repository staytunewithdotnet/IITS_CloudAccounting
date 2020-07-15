// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.ExpenseMaster
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Globalization;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
    public class ExpenseMaster : Page
    {
        private readonly TaxMasterBLL objTaxMasterBll = new TaxMasterBLL();
        private CloudAccountDA.TaxMasterDataTable objTaxMasterDT = new CloudAccountDA.TaxMasterDataTable();
        private readonly ExpenseMasterBLL objExpenseMasterBll = new ExpenseMasterBLL();
        private CloudAccountDA.ExpenseMasterDataTable objExpenseMasterDT = new CloudAccountDA.ExpenseMasterDataTable();
        private readonly InvoiceMasterBLL objInvoiceMasterBll = new InvoiceMasterBLL();
        private CloudAccountDA.InvoiceMasterDataTable objInvoiceMasterDT = new CloudAccountDA.InvoiceMasterDataTable();
        private readonly FrequencyMasterBLL objFrequencyMasterBll = new FrequencyMasterBLL();
        private CloudAccountDA.FrequencyMasterDataTable objFrequencyMasterDT = new CloudAccountDA.FrequencyMasterDataTable();
        private readonly CompanyClientMasterBLL objCompanyClientMasterBll = new CompanyClientMasterBLL();
        private CloudAccountDA.CompanyClientMasterDataTable objCompanyClientMasterDT = new CloudAccountDA.CompanyClientMasterDataTable();
        private readonly SubCategoryMasterBLL objSubCategoryMasterBll = new SubCategoryMasterBLL();
        private CloudAccountDA.SubCategoryMasterDataTable objSubCategoryMasterDT = new CloudAccountDA.SubCategoryMasterDataTable();
        private readonly CategoryMasterBLL objCategoryMasterBll = new CategoryMasterBLL();
        private CloudAccountDA.CategoryMasterDataTable objCategoryMasterDT = new CloudAccountDA.CategoryMasterDataTable();
        private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
        private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
        private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
        private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
        private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
        private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
        private readonly MiscellaneousMasterBLL objMiscellaneousMasterBll = new MiscellaneousMasterBLL();
        private CloudAccountDA.MiscellaneousMasterDataTable objMiscellaneousMasterDT = new CloudAccountDA.MiscellaneousMasterDataTable();
        private int linePerPage = 15;
        private string dateFormat = "MM/dd/yyyy";
        protected ToolkitScriptManager tsm;
        protected HtmlGenericControl divImport;
        protected HtmlGenericControl divSave;
        protected HtmlGenericControl divUpdate;
        protected Panel pnlAdd;
        protected UpdatePanel upExpensesMain;
        protected RequiredFieldValidator rfvAmount;
        protected TextBox txtAmount;
        protected RequiredFieldValidator rfvDate;
        protected TextBox txtDate;
        protected CalendarExtender ceDate;
        protected TextBox txtVendor;
        protected RequiredFieldValidator rfvCategory;
        protected DropDownList ddlCategory;
        protected SqlDataSource sqldsCategory;
        protected TextBox txtNotes;
        protected UpdatePanel upExpensesCheck;
        protected CheckBox chkTaxes;
        protected CheckBox chkRecurring;
        protected CheckBox chkAssignToClient;
        protected CheckBox chkAttachImage;
        protected UpdatePanel upExpensesExtra;
        protected HtmlGenericControl divTaxes;
        protected DropDownList ddlTax1;
        protected TextBox txtTax1;
        protected DropDownList ddlTax2;
        protected TextBox txtTax2;
        protected HtmlGenericControl divRecurring;
        protected RequiredFieldValidator rfvFrequency;
        protected DropDownList ddlFrequency;
        protected SqlDataSource sqldsFrequency;
        protected DropDownList ddlUntil;
        protected HtmlGenericControl divUntilDate;
        protected TextBox txtUntilDate;
        protected CalendarExtender ceuntilDate;
        protected HtmlGenericControl divAssignClient;
        protected DropDownList ddlClient;
        protected HtmlGenericControl divAttachImg;
        protected FileUpload fuAttachRecipt;
        protected Image imgAttach;
        protected Button btnCheck;
        protected Button btnSave;
        protected Button btnUpdate;
        protected Panel pnlView;
        protected Label lblDate;
        protected Label lblAmount;
        protected Label lblVendor;
        protected Label lblCategory;
        protected Label lblNotes;
        protected HtmlGenericControl divTaxesView;
        protected Label lblTax1;
        protected Label lblTaxAmount1;
        protected Label lblTax2;
        protected Label lblTaxAmount2;
        protected HtmlGenericControl divRecurringView;
        protected Label lblFrequency;
        protected Label lblUntil;
        protected HtmlGenericControl divUntilDateView;
        protected Label lblUntilDate;
        protected HtmlGenericControl divAssignClientView;
        protected Label lblClient;
        protected HtmlGenericControl divAttachImgView;
        protected Image imgAttachView;
        protected Button btnEdit;
        protected Button btnDeleteView;
        protected Panel pnlViewAll;
        protected Label lblHeader;
        protected Button btnAdd;
        protected TextBox txtExpenseCategorySearch;
        protected TextBox txtClientNameSearch;
        protected TextBox txtVendorSearch;
        protected TextBox txtNotesSearch;
        protected DropDownList ddlStatusSearch;
        protected TextBox txtDateFrom;
        protected CalendarExtender ceDateFrom;
        protected TextBox txtDateTo;
        protected CalendarExtender ceDateTo;
        protected TextBox txtAmountFrom;
        protected TextBox txtAmountTo;
        protected DropDownList ddlReceiptSearch;
        protected Button btnSearch;
        protected Button btnReset;
        protected Button btnUnDelete;
        protected Button btnArchived;
        protected Button btnUnArchived;
        protected Button btnDelete;
        protected GridView gvExpense;
        protected HtmlAnchor activeTag;
        protected HtmlAnchor archivedTag;
        protected HtmlAnchor deletedTag;
        protected Label lblTotal;
        protected ObjectDataSource objdsExpense;
        protected SqlDataSource sqldsTax;
        protected SqlDataSource sqldsClient;
        protected SqlDataSource sqldsClientStaff;
        protected HiddenField hfCompanyID;
        protected HiddenField hfStaffID;
        protected HiddenField hfExpenseID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Master == null)
                return;
            ((HtmlControl)this.Master.FindControl("expenseMenu")).Attributes.Add("class", "active open");
            ((HtmlControl)this.Master.FindControl("expense")).Attributes.Add("class", "active open");
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
                this.SetMiscValues(this.hfCompanyID.Value);
            }
            if (this.IsPostBack)
                return;
            this.divImport.Visible = this.Session["importExp"] != null;
            this.divSave.Visible = this.Session["saveExp"] != null;
            this.divUpdate.Visible = this.Session["updateExp"] != null;
            this.Session.Abandon();
            if (this.Request.QueryString["cmd"] != null)
            {
                switch (this.Request.QueryString["cmd"])
                {
                    case "view":
                        if (this.Request.QueryString["ID"] == null)
                            break;
                        string id1 = this.Request.QueryString["ID"];
                        this.pnlView.Visible = true;
                        this.pnlViewAll.Visible = false;
                        this.pnlAdd.Visible = false;
                        this.ViewRecord(id1);
                        break;
                    case "invoice":
                        if (this.Request.QueryString["ID"] == null)
                            break;
                        string id2 = this.Request.QueryString["ID"];
                        this.pnlView.Visible = false;
                        this.pnlAdd.Visible = true;
                        this.pnlViewAll.Visible = false;
                        this.BindDropDown();
                        this.btnUpdate.Visible = false;
                        this.btnSave.Visible = true;
                        this.SetInvoiceRecord(id2);
                        this.txtAmount.Focus();
                        break;
                    case "add":
                        if (this.Request.QueryString["ID"] != null)
                        {
                            string id3 = this.Request.QueryString["ID"];
                            this.pnlView.Visible = false;
                            this.pnlAdd.Visible = true;
                            this.pnlViewAll.Visible = false;
                            this.btnSave.Visible = false;
                            this.btnUpdate.Visible = true;
                            this.BindDropDown();
                            this.ceuntilDate.StartDate = new DateTime?(DateTime.Today);
                            this.txtDate.Text = DateTime.Today.ToString(this.dateFormat);
                            this.SetRecord(id3);
                            this.txtAmount.Focus();
                            break;
                        }
                        this.Clear();
                        this.txtAmount.Focus();
                        this.pnlViewAll.Visible = false;
                        this.pnlAdd.Visible = true;
                        this.pnlView.Visible = false;
                        this.btnUpdate.Visible = false;
                        this.btnSave.Visible = true;
                        this.BindDropDown();
                        this.ceuntilDate.StartDate = new DateTime?(DateTime.Today);
                        this.txtDate.Text = DateTime.Today.ToString(this.dateFormat);
                        break;
                    default:
                        this.btnArchived.Visible = !this.CheckARQuery();
                        this.btnUnArchived.Visible = this.CheckARQuery();
                        this.btnDelete.Visible = !this.CheckDEQuery();
                        this.btnUnDelete.Visible = this.CheckDEQuery();
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
                this.btnUnArchived.Visible = this.CheckARQuery();
                this.btnDelete.Visible = !this.CheckDEQuery();
                this.btnUnDelete.Visible = this.CheckDEQuery();
                this.ATagStyle();
                this.pnlViewAll.Visible = true;
                this.pnlAdd.Visible = false;
                this.pnlView.Visible = false;
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
            this.ceDate.Format = this.dateFormat;
            this.ceDateFrom.Format = this.dateFormat;
            this.ceDateTo.Format = this.dateFormat;
            this.ceuntilDate.Format = this.dateFormat;
            this.gvExpense.PageSize = this.linePerPage;
        }

        private void Clear()
        {
            this.Session["category"] = (object)"";
            this.Session.Abandon();
            this.BindDropDown();
            this.txtAmount.Text = "0.00";
            this.txtDate.Text = this.txtNotes.Text = this.txtVendor.Text = "";
            this.chkAssignToClient.Checked = this.chkAttachImage.Checked = this.chkRecurring.Checked = this.chkTaxes.Checked = false;
            this.txtAmount.Focus();
        }

        private void ATagStyle()
        {
            if (this.Request.QueryString["ac"] != null && bool.Parse(this.Request.QueryString["ac"]))
            {
                this.activeTag.Attributes.Add("class", "activeTag");
                this.activeTag.Attributes.Remove("href");
                this.lblHeader.Text = "Expenses";
            }
            if (this.Request.QueryString["ar"] != null && bool.Parse(this.Request.QueryString["ar"]))
            {
                this.archivedTag.Attributes.Add("class", "activeTag");
                this.archivedTag.Attributes.Remove("href");
                this.lblHeader.Text = "Archived Expenses";
            }
            if (this.Request.QueryString["de"] != null && bool.Parse(this.Request.QueryString["de"]))
            {
                this.deletedTag.Attributes.Add("class", "activeTag");
                this.deletedTag.Attributes.Remove("href");
                this.lblHeader.Text = "Deleted Expenses";
            }
            if (this.Request.QueryString["ar"] != null || this.Request.QueryString["ac"] != null || this.Request.QueryString["de"] != null)
                return;
            this.activeTag.Attributes.Add("class", "activeTag");
            this.activeTag.Attributes.Remove("href");
            this.lblHeader.Text = "Expenses";
        }

        private void BindDropDown()
        {
            this.sqldsCategory.DataBind();
            this.ddlCategory.DataBind();
            foreach (ListItem listItem in this.ddlCategory.Items)
            {
                if (listItem.Value == "-1")
                {
                    listItem.Attributes.Add("Style", "background-color:#ff9;color:#000;");
                    listItem.Attributes.Add("Disabled", "true");
                }
            }
            if (this.Session["category"] == null || string.IsNullOrEmpty(this.Session["category"].ToString()))
                return;
            this.ddlCategory.SelectedValue = this.Session["category"].ToString();
        }

        private void ViewRecord(string id)
        {
            this.objExpenseMasterDT = this.objExpenseMasterBll.GetDataByExpenseID(int.Parse(id));
            if (this.objExpenseMasterDT.Rows.Count <= 0)
                return;
            this.hfCompanyID.Value = this.objExpenseMasterDT.Rows[0]["CompanyID"].ToString();
            this.hfExpenseID.Value = this.objExpenseMasterDT.Rows[0]["ExpenseID"].ToString();
            this.lblAmount.Text = this.objExpenseMasterDT.Rows[0]["ExpenseAmount"].ToString();
            this.lblDate.Text = DateTime.Parse(this.objExpenseMasterDT.Rows[0]["ExpenseDate"].ToString()).ToString(this.dateFormat);
            this.lblVendor.Text = this.objExpenseMasterDT.Rows[0]["Vendor"].ToString();
            this.lblNotes.Text = this.objExpenseMasterDT.Rows[0]["Notes"].ToString();
            this.lblCategory.Text = this.objExpenseMasterDT.Rows[0]["SubCategoryID"].ToString();
            this.objSubCategoryMasterDT = this.objSubCategoryMasterBll.GetDataBySubCategoryID(int.Parse(this.lblCategory.Text));
            if (this.objSubCategoryMasterDT.Rows.Count > 0)
            {
                this.lblCategory.Text = "";
                this.objCategoryMasterDT = this.objCategoryMasterBll.GetDataByCategoryID(int.Parse(this.objSubCategoryMasterDT.Rows[0]["CategoryID"].ToString()));
                if (this.objCategoryMasterDT.Rows.Count > 0)
                    this.lblCategory.Text = (string)this.objCategoryMasterDT.Rows[0]["CategoryName"] + (object)" -> ";
                this.lblCategory.Text += this.objSubCategoryMasterDT.Rows[0]["SubCategoryName"].ToString();
            }
            bool flag1 = bool.Parse(this.objExpenseMasterDT.Rows[0]["Taxes"].ToString());
            bool flag2 = bool.Parse(this.objExpenseMasterDT.Rows[0]["RecurringExpense"].ToString());
            bool flag3 = bool.Parse(this.objExpenseMasterDT.Rows[0]["AssignedToClient"].ToString());
            bool flag4 = bool.Parse(this.objExpenseMasterDT.Rows[0]["AttachImage"].ToString());
            this.divTaxesView.Visible = flag1;
            this.divRecurringView.Visible = flag2;
            this.divAssignClientView.Visible = flag3;
            this.divAttachImgView.Visible = flag4;
            if (flag1)
            {
                if (!string.IsNullOrEmpty(this.objExpenseMasterDT.Rows[0]["Tax1"].ToString()))
                {
                    this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(this.objExpenseMasterDT.Rows[0]["Tax1"].ToString()));
                    this.lblTax1.Text = this.objTaxMasterDT.Rows[0]["TaxName"].ToString();
                }
                if (!string.IsNullOrEmpty(this.objExpenseMasterDT.Rows[0]["Tax2"].ToString()))
                {
                    this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(this.objExpenseMasterDT.Rows[0]["Tax2"].ToString()));
                    this.lblTax2.Text = this.objTaxMasterDT.Rows[0]["TaxName"].ToString();
                }
                this.lblTaxAmount1.Text = this.objExpenseMasterDT.Rows[0]["TaxAmount1"].ToString();
                this.lblTaxAmount2.Text = this.objExpenseMasterDT.Rows[0]["TaxAmount2"].ToString();
            }
            if (flag2)
            {
                this.objFrequencyMasterDT = this.objFrequencyMasterBll.GetDataByFrequencyID(int.Parse(this.objExpenseMasterDT.Rows[0]["FrequencyID"].ToString()));
                this.lblFrequency.Text = this.objFrequencyMasterDT.Rows[0]["FrequencyName"].ToString();
                this.lblUntil.Text = this.objExpenseMasterDT.Rows[0]["UntilTimePeriod"].ToString();
                if (!string.IsNullOrEmpty(this.objExpenseMasterDT.Rows[0]["EndDate"].ToString()))
                {
                    this.divUntilDateView.Visible = true;
                    this.lblUntilDate.Text = DateTime.Parse(this.objExpenseMasterDT.Rows[0]["EndDate"].ToString()).ToString(this.dateFormat);
                }
            }
            if (flag3)
            {
                this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(this.objExpenseMasterDT.Rows[0]["ClientID"].ToString()));
                this.lblClient.Text = this.objCompanyClientMasterDT.Rows[0]["OrganizationName"].ToString();
            }
            string str = this.objExpenseMasterDT.Rows[0]["Image"].ToString();
            if (flag4 && !string.IsNullOrEmpty(str))
            {
                this.imgAttachView.Visible = true;
                this.imgAttachView.ImageUrl = "~/Handler/ExpenseHandler.ashx?id=" + this.hfExpenseID.Value;
            }
            else
                this.imgAttachView.Visible = false;
        }

        private void SetRecord(string id)
        {
            this.objExpenseMasterDT = this.objExpenseMasterBll.GetDataByExpenseID(int.Parse(id));
            if (this.objExpenseMasterDT.Rows.Count <= 0)
                return;
            this.hfCompanyID.Value = this.objExpenseMasterDT.Rows[0]["CompanyID"].ToString();
            this.hfExpenseID.Value = this.objExpenseMasterDT.Rows[0]["ExpenseID"].ToString();
            this.txtAmount.Text = this.objExpenseMasterDT.Rows[0]["ExpenseAmount"].ToString();
            this.txtDate.Text = DateTime.Parse(this.objExpenseMasterDT.Rows[0]["ExpenseDate"].ToString()).ToString(this.dateFormat);
            this.txtVendor.Text = this.objExpenseMasterDT.Rows[0]["Vendor"].ToString();
            this.txtNotes.Text = this.objExpenseMasterDT.Rows[0]["Notes"].ToString();
            this.Session["category"] = (object)this.objExpenseMasterDT.Rows[0]["SubCategoryID"].ToString();
            this.ddlCategory.SelectedValue = this.objExpenseMasterDT.Rows[0]["SubCategoryID"].ToString();
            this.chkTaxes.Checked = bool.Parse(this.objExpenseMasterDT.Rows[0]["Taxes"].ToString());
            this.chkRecurring.Checked = bool.Parse(this.objExpenseMasterDT.Rows[0]["RecurringExpense"].ToString());
            this.chkAssignToClient.Checked = bool.Parse(this.objExpenseMasterDT.Rows[0]["AssignedToClient"].ToString());
            this.chkAttachImage.Checked = bool.Parse(this.objExpenseMasterDT.Rows[0]["AttachImage"].ToString());
            this.chkTaxes_OnCheckedChanged((object)null, (EventArgs)null);
            this.chkRecurring_OnCheckedChanged((object)null, (EventArgs)null);
            this.chkAssignToClient_OnCheckedChanged((object)null, (EventArgs)null);
            if (this.chkTaxes.Checked)
            {
                if (!string.IsNullOrEmpty(this.objExpenseMasterDT.Rows[0]["Tax1"].ToString()))
                    this.ddlTax1.SelectedValue = this.objExpenseMasterDT.Rows[0]["Tax1"].ToString();
                if (!string.IsNullOrEmpty(this.objExpenseMasterDT.Rows[0]["Tax2"].ToString()))
                    this.ddlTax2.SelectedValue = this.objExpenseMasterDT.Rows[0]["Tax2"].ToString();
                this.txtTax1.Text = this.objExpenseMasterDT.Rows[0]["TaxAmount1"].ToString();
                this.txtTax2.Text = this.objExpenseMasterDT.Rows[0]["TaxAmount2"].ToString();
            }
            if (this.chkRecurring.Checked)
            {
                this.ddlFrequency.SelectedValue = this.objExpenseMasterDT.Rows[0]["FrequencyID"].ToString();
                this.ddlUntil.SelectedIndex = this.ddlUntil.Items.IndexOf(this.ddlUntil.Items.FindByText(this.objExpenseMasterDT.Rows[0]["UntilTimePeriod"].ToString()));
                this.ddlUntil_OnSelectedIndexChanged((object)null, (EventArgs)null);
                if (!string.IsNullOrEmpty(this.objExpenseMasterDT.Rows[0]["EndDate"].ToString()))
                    this.txtUntilDate.Text = DateTime.Parse(this.objExpenseMasterDT.Rows[0]["EndDate"].ToString()).ToString(this.dateFormat);
            }
            if (this.chkAssignToClient.Checked)
                this.ddlClient.SelectedValue = this.objExpenseMasterDT.Rows[0]["ClientID"].ToString();
            if (this.chkAttachImage.Checked && !string.IsNullOrEmpty(this.objExpenseMasterDT.Rows[0]["Image"].ToString()))
            {
                this.divAttachImg.Attributes.Add("style", "display: block;");
                this.imgAttach.Visible = true;
                this.imgAttach.ImageUrl = "~/Handler/ExpenseHandler.ashx?id=" + this.hfExpenseID.Value;
            }
            else
            {
                this.divAttachImg.Attributes.Add("style", "display: none;");
                this.imgAttach.Visible = false;
            }
        }

        private void SetInvoiceRecord(string id)
        {
            this.objInvoiceMasterDT = this.objInvoiceMasterBll.GetDataByInvoiceID(int.Parse(id));
            if (this.objInvoiceMasterDT.Rows.Count <= 0)
                return;
            this.hfCompanyID.Value = this.objInvoiceMasterDT.Rows[0]["CompanyID"].ToString();
            this.txtAmount.Text = this.objInvoiceMasterDT.Rows[0]["InvoiceTotal"].ToString();
            this.txtDate.Text = DateTime.Parse(this.objInvoiceMasterDT.Rows[0]["InvoiceDate"].ToString()).ToString(this.dateFormat);
            this.txtNotes.Text = string.Concat(new object[4]
      {
        (object) "Invoice #",
        this.objInvoiceMasterDT.Rows[0]["InvoiceNumber"],
        (object) " for ",
        this.objInvoiceMasterDT.Rows[0]["InvoiceTotal"]
      });
            this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
            this.txtVendor.Text = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
        }

        protected void chkTaxes_OnCheckedChanged(object sender, EventArgs e)
        {
            this.divTaxes.Visible = this.chkTaxes.Checked;
            if (this.chkAttachImage.Checked)
                this.ddlTax1.Focus();
            this.BindDropDown();
        }

        protected void chkRecurring_OnCheckedChanged(object sender, EventArgs e)
        {
            this.divRecurring.Visible = this.chkRecurring.Checked;
            this.rfvFrequency.Enabled = this.chkRecurring.Checked;
            if (this.chkRecurring.Checked)
                this.ddlFrequency.Focus();
            this.BindDropDown();
        }

        protected void chkAssignToClient_OnCheckedChanged(object sender, EventArgs e)
        {
            this.divAssignClient.Visible = this.chkAssignToClient.Checked;
            if (this.chkAssignToClient.Checked)
            {
                MembershipUser user = Membership.GetUser();
                if (user != null)
                {
                    string username = user.ToString();
                    if (Roles.IsUserInRole(username, "Admin"))
                        this.ddlClient.DataSource = (object)this.sqldsClient;
                    else if (Roles.IsUserInRole(username, "Employee"))
                        this.ddlClient.DataSource = (object)this.sqldsClientStaff;
                }
                this.ddlClient.DataBind();
                this.ddlClient.Focus();
            }
            this.BindDropDown();
        }

        protected void ddlUntil_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            this.divUntilDate.Visible = this.ddlUntil.SelectedItem.Value == "End Date";
            if (this.ddlUntil.SelectedItem.Value == "End Date")
                this.txtUntilDate.Focus();
            else
                this.ddlUntil.Focus();
            this.BindDropDown();
        }

        protected void gvExpense_Sorting(object sender, GridViewSortEventArgs e)
        {
            this.BindGrid();
        }

        private void BindGrid()
        {
            this.gvExpense.DataBind();
            this.GetExpenseTotal();
        }

        protected void gvExpense_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        protected void gvExpense_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvExpense.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void gvExpense_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            this.objSubCategoryMasterDT = this.objSubCategoryMasterBll.GetDataBySubCategoryID(int.Parse(e.Row.Cells[2].Text));
            e.Row.Cells[2].Text = this.objSubCategoryMasterDT.Rows[0]["SubCategoryName"].ToString();
        }

        private void GetExpenseTotal()
        {
            if (this.gvExpense.Rows.Count > 0)
            {
                Decimal d = new Decimal(0);
                for (int index = 0; index < this.gvExpense.Rows.Count; ++index)
                {
                    string text = this.gvExpense.Rows[index].Cells[4].Text;
                    if (!string.IsNullOrEmpty(text))
                        d += Decimal.Parse(text);
                }
                this.lblTotal.Text = Decimal.Round(d, 2).ToString();
            }
            else
                this.lblTotal.Text = "0.00";
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
            for (int index = 0; index < this.gvExpense.Rows.Count; ++index)
            {
                CheckBox checkBox = (CheckBox)this.gvExpense.Rows[index].Cells[0].FindControl("chkID");
                if (checkBox.Checked)
                {
                    ++num;
                    this.objExpenseMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), false, false, true);
                }
            }
            if (num == 0)
                this.DisplayAlert("No Expenses were selected.");
            else
                this.Response.Redirect("ExpenseMaster.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int num = 0;
            for (int index = 0; index < this.gvExpense.Rows.Count; ++index)
            {
                CheckBox checkBox = (CheckBox)this.gvExpense.Rows[index].Cells[0].FindControl("chkID");
                if (checkBox.Checked)
                {
                    ++num;
                    this.objExpenseMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), false, true, false);
                }
            }
            if (num == 0)
                this.DisplayAlert("No Expenses were selected.");
            else
                this.Response.Redirect("ExpenseMaster.aspx?de=true&ac=false");
        }

        protected void btnUnArchived_Click(object sender, EventArgs e)
        {
            int num = 0;
            for (int index = 0; index < this.gvExpense.Rows.Count; ++index)
            {
                CheckBox checkBox = (CheckBox)this.gvExpense.Rows[index].Cells[0].FindControl("chkID");
                if (checkBox.Checked)
                {
                    ++num;
                    this.objExpenseMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), true, false, false);
                }
            }
            if (num == 0)
                this.DisplayAlert("No Expenses were selected.");
            else
                this.Response.Redirect("ExpenseMaster.aspx?ar=true&ac=false");
        }

        protected void btnUnDelete_Click(object sender, EventArgs e)
        {
            int num = 0;
            for (int index = 0; index < this.gvExpense.Rows.Count; ++index)
            {
                CheckBox checkBox = (CheckBox)this.gvExpense.Rows[index].Cells[0].FindControl("chkID");
                if (checkBox.Checked)
                {
                    ++num;
                    this.objExpenseMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), true, false, false);
                }
            }
            if (num == 0)
                this.DisplayAlert("No Expenses were selected.");
            else
                this.Response.Redirect("ExpenseMaster.aspx?de=true&ac=false");
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
            this.Response.Redirect("ExpenseMaster.aspx?cmd=add");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.BindDropDown();
            try
            {
                if (!this.Page.IsValid)
                    return;
                if (this.txtAmount.Text.Trim().Length > 0 && this.txtDate.Text.Trim().Length > 0 && this.ddlCategory.SelectedIndex > 0)
                {
                    if (this.chkAttachImage.Checked && !this.btncheck())
                        return;
                    int? iTax1 = new int?();
                    int? iTax2 = new int?();
                    int? iFrequencyID = new int?();
                    int? iClientID = new int?();
                    Decimal? dTaxAmount1 = new Decimal?();
                    Decimal? dTaxAmount2 = new Decimal?();
                    DateTime? dtEndDate = new DateTime?();
                    string sUntilTimePeriod = string.Empty;
                    string sExpenseStatus = string.Empty;
                    byte[] numArray = (byte[])null;
                    if (this.chkTaxes.Checked && (this.ddlTax1.SelectedIndex > 0 || this.ddlTax2.SelectedIndex > 0))
                    {
                        this.chkTaxes.Checked = true;
                        if (this.ddlTax1.SelectedIndex > 0)
                        {
                            iTax1 = new int?(int.Parse(this.ddlTax1.SelectedItem.Value));
                            dTaxAmount1 = new Decimal?(Decimal.Parse(this.txtTax1.Text.Trim()));
                        }
                        if (this.ddlTax2.SelectedIndex > 0)
                        {
                            iTax2 = new int?(int.Parse(this.ddlTax2.SelectedItem.Value));
                            dTaxAmount2 = new Decimal?(Decimal.Parse(this.txtTax2.Text.Trim()));
                        }
                    }
                    else
                        this.chkTaxes.Checked = false;
                    if (this.chkRecurring.Checked && this.ddlFrequency.SelectedIndex > 0)
                    {
                        this.chkRecurring.Checked = true;
                        iFrequencyID = new int?(int.Parse(this.ddlFrequency.SelectedItem.Value));
                        if (this.ddlUntil.SelectedItem.Value == "End Date")
                        {
                            sUntilTimePeriod = "End Date";
                            dtEndDate = new DateTime?(DateTime.Parse(DateTime.ParseExact(this.txtUntilDate.Text, new string[6]
              {
                "MM/dd/yy",
                "MM/dd/yyyy",
                "dd/MM/yy",
                "dd/MM/yyyy",
                "yy-MM-dd",
                "yyyy-MM-dd"
              }, (IFormatProvider)CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("MM/dd/yyyy")));
                        }
                        else
                            sUntilTimePeriod = "Forever";
                    }
                    else
                        this.chkRecurring.Checked = false;
                    if (this.chkAssignToClient.Checked && this.ddlClient.SelectedIndex > 0)
                    {
                        this.chkAssignToClient.Checked = true;
                        sExpenseStatus = "unbilled";
                        iClientID = new int?(int.Parse(this.ddlClient.SelectedItem.Value));
                    }
                    else
                        this.chkAssignToClient.Checked = false;
                    if (this.chkAttachImage.Checked)
                    {
                        this.chkAttachImage.Checked = true;
                        if (this.fuAttachRecipt.HasFile)
                        {
                            numArray = new byte[this.fuAttachRecipt.PostedFile.ContentLength];
                            this.fuAttachRecipt.PostedFile.InputStream.Read(numArray, 0, this.fuAttachRecipt.PostedFile.ContentLength);
                        }
                        else
                            this.chkAttachImage.Checked = false;
                    }
                    else
                        this.chkAttachImage.Checked = false;
                    int num = this.objExpenseMasterBll.AddExpense(int.Parse(this.hfCompanyID.Value), Decimal.Parse(this.txtAmount.Text.Trim()), new DateTime?(DateTime.Parse(DateTime.ParseExact(this.txtDate.Text, new string[6]
          {
            "MM/dd/yy",
            "MM/dd/yyyy",
            "dd/MM/yy",
            "dd/MM/yyyy",
            "yy-MM-dd",
            "yyyy-MM-dd"
          }, (IFormatProvider)CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("MM/dd/yyyy"))), this.txtVendor.Text.Trim(), new int?(), new int?(int.Parse(this.ddlCategory.SelectedItem.Value)), this.txtNotes.Text, this.chkTaxes.Checked, iTax1, dTaxAmount1, iTax2, dTaxAmount2, this.chkRecurring.Checked, iFrequencyID, sUntilTimePeriod, dtEndDate, this.chkAssignToClient.Checked, iClientID, this.chkAttachImage.Checked, numArray, sExpenseStatus, true, false, false);
                    if (num != 0)
                    {
                        this.Session["saveExp"] = (object)1;
                        this.DisplayAlert("Expense Inserted Successfully");
                        if (this.Request.QueryString["cmd"] != null && this.Request.QueryString["ID"] != null && this.Request.QueryString["cmd"] == "invoice")
                            new InvoiceMasterBLL().UpdateConvertToExpence(true, int.Parse(this.Request.QueryString["ID"]));
                        this.Response.Redirect("ExpenseMaster.aspx?cmd=view&ID=" + (object)num);
                    }
                    else
                        this.DisplayAlert("Some Error occured while insert. Please try after some time..!");
                }
                else
                    this.DisplayAlert("Please Fill All Requried Fields..!");
            }
            catch (Exception ex)
            {
                this.DisplayAlert(ex.Message);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.IsValid)
                    return;
                if (this.txtAmount.Text.Trim().Length > 0 && this.txtDate.Text.Trim().Length > 0 && this.ddlCategory.SelectedIndex > 0)
                {
                    this.objExpenseMasterDT = this.objExpenseMasterBll.GetDataByExpenseID(int.Parse(this.hfExpenseID.Value));
                    string sExpenseStatus = this.objExpenseMasterDT.Rows[0]["ExpenseStatus"].ToString();
                    bool bActive = (bool)this.objExpenseMasterDT.Rows[0]["Active"];
                    bool bArchived = (bool)this.objExpenseMasterDT.Rows[0]["Archived"];
                    bool bDeleted = (bool)this.objExpenseMasterDT.Rows[0]["Deleted"];
                    int? iTax1 = new int?();
                    int? iTax2 = new int?();
                    int? iFrequencyID = new int?();
                    int? iClientID = new int?();
                    Decimal? dTaxAmount1 = new Decimal?();
                    Decimal? dTaxAmount2 = new Decimal?();
                    DateTime? dtEndDate = new DateTime?();
                    string sUntilTimePeriod = string.Empty;
                    byte[] numArray = (byte[])null;
                    if (this.chkTaxes.Checked && (this.ddlTax1.SelectedIndex > 0 || this.ddlTax2.SelectedIndex > 0))
                    {
                        this.chkTaxes.Checked = true;
                        if (this.ddlTax1.SelectedIndex > 0)
                        {
                            iTax1 = new int?(int.Parse(this.ddlTax1.SelectedItem.Value));
                            dTaxAmount1 = new Decimal?(Decimal.Parse(this.txtTax1.Text.Trim()));
                        }
                        if (this.ddlTax2.SelectedIndex > 0)
                        {
                            iTax2 = new int?(int.Parse(this.ddlTax2.SelectedItem.Value));
                            dTaxAmount2 = new Decimal?(Decimal.Parse(this.txtTax2.Text.Trim()));
                        }
                    }
                    else
                        this.chkTaxes.Checked = false;
                    if (this.chkRecurring.Checked && this.ddlFrequency.SelectedIndex > 0)
                    {
                        this.chkRecurring.Checked = true;
                        iFrequencyID = new int?(int.Parse(this.ddlFrequency.SelectedItem.Value));
                        if (this.ddlUntil.SelectedItem.Value == "End Date")
                        {
                            sUntilTimePeriod = "End Date";
                            dtEndDate = new DateTime?(DateTime.Parse(DateTime.ParseExact(this.txtUntilDate.Text, new string[6]
              {
                "MM/dd/yy",
                "MM/dd/yyyy",
                "dd/MM/yy",
                "dd/MM/yyyy",
                "yy-MM-dd",
                "yyyy-MM-dd"
              }, (IFormatProvider)CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("MM/dd/yyyy")));
                        }
                        else
                            sUntilTimePeriod = "Forever";
                    }
                    else
                        this.chkRecurring.Checked = false;
                    if (this.chkAssignToClient.Checked && this.ddlClient.SelectedIndex > 0)
                    {
                        this.chkAssignToClient.Checked = true;
                        sExpenseStatus = "unbilled";
                        iClientID = new int?(int.Parse(this.ddlClient.SelectedItem.Value));
                    }
                    else
                        this.chkAssignToClient.Checked = false;
                    if (this.chkAttachImage.Checked)
                    {
                        this.chkAttachImage.Checked = true;
                        if (this.fuAttachRecipt.HasFile)
                        {
                            numArray = new byte[this.fuAttachRecipt.PostedFile.ContentLength];
                            this.fuAttachRecipt.PostedFile.InputStream.Read(numArray, 0, this.fuAttachRecipt.PostedFile.ContentLength);
                        }
                        else if (!string.IsNullOrEmpty(this.objExpenseMasterDT.Rows[0]["Image"].ToString()))
                            numArray = (byte[])this.objExpenseMasterDT.Rows[0]["Image"];
                    }
                    else
                        this.chkAttachImage.Checked = false;
                    if (this.objExpenseMasterBll.UpdateExpense(int.Parse(this.hfExpenseID.Value), int.Parse(this.hfCompanyID.Value), Decimal.Parse(this.txtAmount.Text.Trim()), new DateTime?(DateTime.Parse(DateTime.ParseExact(this.txtDate.Text, new string[6]
          {
            "MM/dd/yy",
            "MM/dd/yyyy",
            "dd/MM/yy",
            "dd/MM/yyyy",
            "yy-MM-dd",
            "yyyy-MM-dd"
          }, (IFormatProvider)CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("MM/dd/yyyy"))), this.txtVendor.Text.Trim(), new int?(), new int?(int.Parse(this.ddlCategory.SelectedItem.Value)), this.txtNotes.Text, this.chkTaxes.Checked, iTax1, dTaxAmount1, iTax2, dTaxAmount2, this.chkRecurring.Checked, iFrequencyID, sUntilTimePeriod, dtEndDate, this.chkAssignToClient.Checked, iClientID, this.chkAttachImage.Checked, numArray, sExpenseStatus, bActive, bArchived, bDeleted))
                    {
                        this.Session["updateExp"] = (object)1;
                        this.DisplayAlert("Expense Updated Successfully");
                        this.Response.Redirect("ExpenseMaster.aspx?cmd=view&ID=" + this.hfExpenseID.Value);
                    }
                    else
                        this.DisplayAlert("Some Error occured while update. Please try after some time..!");
                }
                else
                    this.DisplayAlert("Please Fill All Requried Fields..!");
            }
            catch (Exception ex)
            {
                this.DisplayAlert(ex.Message);
            }
        }

        private void CalculateTax()
        {
            Decimal num1 = Decimal.Parse(this.txtAmount.Text);
            if (this.chkTaxes.Checked)
            {
                if (this.ddlTax1.SelectedIndex > 0 && this.ddlTax2.SelectedIndex > 0)
                {
                    this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(this.ddlTax1.SelectedItem.Value));
                    //Decimal num2 = Decimal.op_Increment(Decimal.Parse(this.objTaxMasterDT.Rows[0]["TaxRate"].ToString()) / new Decimal(100));
                    Decimal num2 = Decimal.Parse(this.objTaxMasterDT.Rows[0]["TaxRate"].ToString()) / new Decimal(100);
                    num2 = ++num2;
                    Decimal num3 = Decimal.Round(Decimal.Round(num1 / num2, 2), 2);
                    this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(this.ddlTax2.SelectedItem.Value));
                    //Decimal num4 = Decimal.op_Increment(Decimal.Parse(this.objTaxMasterDT.Rows[0]["TaxRate"].ToString()) / new Decimal(100));
                    Decimal num4 = Decimal.Parse(this.objTaxMasterDT.Rows[0]["TaxRate"].ToString()) / new Decimal(100);
                    num4 = ++num4;
                    Decimal num5 = Decimal.Round(num3 / num4, 2);
                    this.txtTax2.Text = Decimal.Round(Decimal.Round(num3 - num5, 2), 2).ToString();
                    Decimal num6 = Decimal.Parse(this.txtAmount.Text);
                    this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(this.ddlTax2.SelectedItem.Value));
                    //Decimal num7 = Decimal.op_Increment(Decimal.Parse(this.objTaxMasterDT.Rows[0]["TaxRate"].ToString()) / new Decimal(100));
                    Decimal num7 = Decimal.Parse(this.objTaxMasterDT.Rows[0]["TaxRate"].ToString()) / new Decimal(100);
                    num7 = ++num7;
                    Decimal num8 = Decimal.Round(Decimal.Round(num6 / num7, 2), 2);
                    this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(this.ddlTax1.SelectedItem.Value));
                    //Decimal num9 = Decimal.op_Increment(Decimal.Parse(this.objTaxMasterDT.Rows[0]["TaxRate"].ToString()) / new Decimal(100));
                    Decimal num9 = Decimal.Parse(this.objTaxMasterDT.Rows[0]["TaxRate"].ToString()) / new Decimal(100);
                    num9 = ++num9;
                    Decimal num10 = Decimal.Round(num8 / num9, 2);
                    this.txtTax1.Text = Decimal.Round(Decimal.Round(num8 - num10, 2), 2).ToString();
                }
                else
                {
                    if (this.ddlTax1.SelectedIndex > 0)
                    {
                        this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(this.ddlTax1.SelectedItem.Value));
                        //Decimal num2 = Decimal.op_Increment(Decimal.Parse(this.objTaxMasterDT.Rows[0]["TaxRate"].ToString()) / new Decimal(100));
                        Decimal num2 = Decimal.Parse(this.objTaxMasterDT.Rows[0]["TaxRate"].ToString()) / new Decimal(100);
                        num2 = ++num2;
                        Decimal num3 = Decimal.Round(num1 / num2, 2);
                        this.txtTax1.Text = Decimal.Round(Decimal.Round(num1 - num3, 2), 2).ToString();
                    }
                    else
                        this.txtTax1.Text = "";
                    if (this.ddlTax2.SelectedIndex > 0)
                    {
                        this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(this.ddlTax2.SelectedItem.Value));
                        //Decimal num2 = Decimal.op_Increment(Decimal.Parse(this.objTaxMasterDT.Rows[0]["TaxRate"].ToString()) / new Decimal(100));
                        Decimal num2 = Decimal.Parse(this.objTaxMasterDT.Rows[0]["TaxRate"].ToString()) / new Decimal(100);
                        num2 = ++num2;
                        Decimal num3 = Decimal.Round(num1 / num2, 2);
                        this.txtTax2.Text = Decimal.Round(Decimal.Round(num1 - num3, 2), 2).ToString();
                    }
                    else
                        this.txtTax2.Text = "";
                }
            }
            this.txtDate.Focus();
            this.BindDropDown();
        }

        protected void txtAmount_OnTextChanged(object sender, EventArgs e)
        {
            this.CalculateTax();
        }

        protected void ddlTax1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            this.CalculateTax();
        }

        protected void ddlCategory_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlCategory.SelectedIndex > 0)
            {
                this.Session["category"] = (object)this.ddlCategory.SelectedItem.Value;
                this.BindDropDown();
                this.txtNotes.Focus();
            }
            else
            {
                this.BindDropDown();
                this.ddlCategory.Focus();
            }
        }

        private bool btncheck()
        {
            if (this.fuAttachRecipt.HasFile)
                this.DisplayAlert("yes file exists" + this.fuAttachRecipt.FileName);
            else
                this.DisplayAlert("file not exists try again with same file or another file..!");
            return this.fuAttachRecipt.HasFile;
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            this.BindDropDown();
            if (this.fuAttachRecipt.HasFile)
                this.DisplayAlert("yes file exists" + this.fuAttachRecipt.FileName);
            else
                this.DisplayAlert("oooooo no file not exists..!");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("ExpenseMaster.aspx?cmd=add&ID=" + this.hfExpenseID.Value);
        }

        protected void btnDeleteView_Click(object sender, EventArgs e)
        {
            this.objExpenseMasterBll.UpdateWhenAnyBit(int.Parse(this.hfExpenseID.Value), true, false, false);
            this.Response.Redirect("ExpenseMaster.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }
    }
}

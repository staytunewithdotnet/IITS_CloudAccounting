// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.PaymentMaster
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Collections;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TemplateParser;

namespace IITS_CloudAccounting.Admin
{
    public class PaymentMaster : Page
    {
        private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
        private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
        private readonly CreditMasterBLL objCreditMasterBll = new CreditMasterBLL();
        private CloudAccountDA.CreditMasterDataTable objCreditMasterDT = new CloudAccountDA.CreditMasterDataTable();
        private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
        private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
        private readonly CurrencyMasterBLL objCurrencyMasterBll = new CurrencyMasterBLL();
        private CloudAccountDA.CurrencyMasterDataTable objCurrencyMasterDT = new CloudAccountDA.CurrencyMasterDataTable();
        private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
        private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
        private readonly PaymentMasterBLL objPaymentMasterBll = new PaymentMasterBLL();
        private CloudAccountDA.PaymentMasterDataTable objPaymentMasterDT = new CloudAccountDA.PaymentMasterDataTable();
        private readonly CompanyClientMasterBLL objCompanyClientMasterBll = new CompanyClientMasterBLL();
        private CloudAccountDA.CompanyClientMasterDataTable objCompanyClientMasterDT = new CloudAccountDA.CompanyClientMasterDataTable();
        private readonly InvoiceMasterBLL objInvoiceMasterBll = new InvoiceMasterBLL();
        private CloudAccountDA.InvoiceMasterDataTable objInvoiceMasterDT = new CloudAccountDA.InvoiceMasterDataTable();
        private readonly MiscellaneousMasterBLL objMiscellaneousMasterBll = new MiscellaneousMasterBLL();
        private CloudAccountDA.MiscellaneousMasterDataTable objMiscellaneousMasterDT = new CloudAccountDA.MiscellaneousMasterDataTable();
        private readonly NewPaymentEmailTemplateBLL objNewPaymentEmailTemplateBll = new NewPaymentEmailTemplateBLL();
        private CloudAccountDA.NewPaymentEmailTemplateDataTable objNewPaymentEmailTemplateDT = new CloudAccountDA.NewPaymentEmailTemplateDataTable();
        private readonly SMTPSettingsBLL objSMTPSettingsBll = new SMTPSettingsBLL();
        private CloudAccountDA.SMTPSettingsDataTable objSMTPSettingsDT = new CloudAccountDA.SMTPSettingsDataTable();
        private string dateFormat = "MM/dd/yyyy";
        private int linePerPage = 15;
        private string branding = "block";
        private string directLink = "block";
        protected ToolkitScriptManager tsm;
        protected HtmlGenericControl divSave;
        protected HtmlGenericControl divUpdate;
        protected Panel pnlAdd;
        protected UpdatePanel upClient;
        protected Label lblPaymentInfo;
        protected UpdatePanel upPayAll;
        protected Label lblCurrencyCode;
        protected TextBox txtPayment;
        protected CheckBox chkPayAll;
        protected Label lblInvoiceAmt;
        protected DropDownList ddlMethod;
        protected TextBox txtPaymentDate;
        protected CalendarExtender cePaymentDate;
        protected TextBox txtPaymentNote;
        protected HtmlGenericControl divOldData;
        protected GridView gvPaymentOld;
        protected ObjectDataSource objdsPaymentOld;
        protected Label lblTotalPaid;
        protected Label lblBalance;
        protected CheckBox chkEmail;
        protected Button btnSave;
        protected Button btnUpdate;
        protected Panel pnlView;
        protected Panel pnlViewAll;
        protected Button btnAdd;
        protected TextBox txtInvoiceNumberSearch;
        protected TextBox txtClientNameSearch;
        protected TextBox txtNotesSearch;
        protected DropDownList ddlMethodSearch;
        protected TextBox txtDateFrom;
        protected CalendarExtender ceDateFrom;
        protected TextBox txtDateTo;
        protected CalendarExtender ceDateTo;
        protected TextBox txtAmountFrom;
        protected TextBox txtAmountTo;
        protected DropDownList ddlCurrencySearch;
        protected SqlDataSource sqldsCurrencySearch;
        protected Button btnSearch;
        protected Button btnReset;
        protected Button btnDelete;
        protected Button btnEmail;
        protected GridView gvPayment;
        protected GridView gvPaymentTotal;
        protected SqlDataSource sqldsPaymentTotalCompany;
        protected SqlDataSource sqldsPaymentTotalCompanyStaff;
        protected ObjectDataSource objdsPayment;
        protected ObjectDataSource objdsPaymentStaff;
        protected HiddenField hfInvoiceID;
        protected HiddenField hfCompanyID;
        protected HiddenField hfStaffID;
        protected HiddenField hfPaymentID;
        protected ModalPopupExtender mpInvoicePayment;
        protected Panel pnlInvoicePayment;
        protected LinkButton lnkClose;
        protected GridView gvInvoice;
        protected SqlDataSource sqldsInvoice;
        protected SqlDataSource sqldsInvoiceStaff;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Master == null)
                return;
            ((HtmlControl)this.Master.FindControl("invoice")).Attributes.Add("class", "active open");
            ((HtmlControl)this.Master.FindControl("payments")).Attributes.Add("class", "active open");
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
                        this.gvInvoice.DataSource = (object)this.sqldsInvoice;
                        this.gvPayment.DataSource = (object)this.objdsPayment;
                        this.gvPaymentTotal.DataSource = (object)this.sqldsPaymentTotalCompany;
                    }
                }
                else if (Roles.IsUserInRole(str, "Employee"))
                {
                    this.objStaffMasterDT = this.objStaffMasterBll.GetDataByStaffUserName(str);
                    if (this.objStaffMasterDT.Rows.Count > 0)
                    {
                        this.hfCompanyID.Value = this.objStaffMasterDT.Rows[0]["CompanyID"].ToString();
                        this.hfStaffID.Value = this.objStaffMasterDT.Rows[0]["StaffID"].ToString();
                        this.gvInvoice.DataSource = (object)this.sqldsInvoiceStaff;
                        this.gvPayment.DataSource = (object)this.objdsPaymentStaff;
                        this.gvPaymentTotal.DataSource = (object)this.sqldsPaymentTotalCompanyStaff;
                    }
                }
                this.gvInvoice.DataBind();
                this.cePaymentDate.Format = this.dateFormat;
                this.ceDateFrom.Format = this.dateFormat;
                this.ceDateTo.Format = this.dateFormat;
                this.SetMiscValues(this.hfCompanyID.Value);
            }
            if (this.IsPostBack)
                return;
            this.divSave.Visible = this.Session["savePay"] != null;
            this.divUpdate.Visible = this.Session["updatePay"] != null;
            this.Session.Abandon();
            if (this.Request.QueryString["cmd"] != null)
            {
                switch (this.Request.QueryString["cmd"])
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
                    case "add":
                        if (this.Request.QueryString["ID"] != null)
                        {
                            this.SetRecord(this.Request.QueryString["ID"]);
                            this.pnlAdd.Visible = true;
                            this.pnlView.Visible = false;
                            this.pnlViewAll.Visible = false;
                            this.btnSave.Visible = false;
                            this.btnUpdate.Visible = true;
                            this.chkPayAll.Visible = false;
                            this.chkEmail.Visible = false;
                            this.txtPayment.Focus();
                            break;
                        }
                        if (this.Request.QueryString["InvoiceID"] != null)
                        {
                            this.SetInvoiceRecord(this.Request.QueryString["InvoiceID"]);
                            this.pnlAdd.Visible = true;
                            this.pnlView.Visible = false;
                            this.pnlViewAll.Visible = false;
                            this.btnSave.Visible = true;
                            this.btnUpdate.Visible = false;
                            this.chkPayAll.Visible = true;
                            this.chkEmail.Visible = true;
                            this.PreDefineControls();
                            this.txtPayment.Focus();
                            break;
                        }
                        this.Clear();
                        this.txtPayment.Focus();
                        this.pnlViewAll.Visible = false;
                        this.pnlView.Visible = false;
                        this.pnlAdd.Visible = true;
                        this.btnUpdate.Visible = false;
                        this.chkPayAll.Visible = true;
                        this.chkEmail.Visible = true;
                        this.chkEmail.Checked = true;
                        this.btnSave.Visible = true;
                        this.PreDefineControls();
                        break;
                    default:
                        this.pnlViewAll.Visible = true;
                        this.pnlView.Visible = false;
                        this.pnlAdd.Visible = false;
                        this.BindGrid();
                        break;
                }
            }
            else
            {
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
                this.gvPayment.PageSize = this.linePerPage;
                this.cePaymentDate.Format = this.dateFormat;
                this.ceDateFrom.Format = this.dateFormat;
                this.ceDateTo.Format = this.dateFormat;
                this.branding = (bool)this.objMiscellaneousMasterDT.Rows[0]["DoyinGoBranding"] ? "none" : "block";
                this.directLink = (bool)this.objMiscellaneousMasterDT.Rows[0]["DirectLinks"] ? "none" : "block";
            }
            this.objNewPaymentEmailTemplateDT = this.objNewPaymentEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value), "other");
            if (this.objNewPaymentEmailTemplateDT.Rows.Count <= 0)
                return;
            this.chkEmail.Checked = bool.Parse(this.objNewPaymentEmailTemplateDT.Rows[0]["Enable"].ToString());
        }

        private void SetInvoiceRecord(string sId)
        {
            this.objInvoiceMasterDT = this.objInvoiceMasterBll.GetDataByInvoiceID(int.Parse(sId));
            if (this.objInvoiceMasterDT.Rows.Count <= 0)
                return;
            this.hfInvoiceID.Value = this.objInvoiceMasterDT.Rows[0]["InvoiceID"].ToString();
            this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(this.objInvoiceMasterDT.Rows[0]["CurrencyID"].ToString()));
            if (this.objCurrencyMasterDT.Rows.Count > 0)
                this.lblCurrencyCode.Text = this.objCurrencyMasterDT.Rows[0]["CurrencyCode"].ToString();
            this.lblInvoiceAmt.Text = this.objInvoiceMasterDT.Rows[0]["InvoiceTotal"].ToString();
            Label label1 = this.lblBalance;
            Label label2 = this.lblInvoiceAmt;
            Decimal num = Decimal.Round(Decimal.Parse(this.lblInvoiceAmt.Text), 2);
            string str1;
            string str2 = str1 = num.ToString();
            label2.Text = str1;
            string str3 = str2;
            label1.Text = str3;
            this.gvPaymentOld.DataBind();
            this.divOldData.Visible = this.gvPaymentOld.Rows.Count > 0;
            if (this.gvPaymentOld.Rows.Count > 0)
            {
                Decimal d = new Decimal(0);
                for (int index = 0; index < this.gvPaymentOld.Rows.Count; ++index)
                {
                    string text = this.gvPaymentOld.Rows[index].Cells[3].Text;
                    d += Decimal.Parse(text);
                }
                this.lblTotalPaid.Text = Decimal.Round(d, 2).ToString();
            }
            this.lblBalance.Text = (Decimal.Parse(this.lblInvoiceAmt.Text) - Decimal.Parse(this.lblTotalPaid.Text)).ToString();
            this.lblBalance.Text = Decimal.Round(Decimal.Parse(this.lblBalance.Text), 2).ToString();
            this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(this.objInvoiceMasterDT.Rows[0]["ClientID"].ToString()));
            string newValue = this.objCompanyClientMasterDT.Rows[0]["OrganizationName"].ToString();
            this.lblPaymentInfo.Text = "Invoice #" + this.GetInvoiceNumber(sId).Replace("Invoice", "") + " for " + newValue;
            this.chkEmail.Text = this.chkEmail.Text.Replace("company", newValue);
        }

        private void BindGrid()
        {
            this.gvPayment.DataBind();
            this.gvPaymentTotal.DataBind();
        }

        private void ViewRecord(string id)
        {
            this.objPaymentMasterDT = this.objPaymentMasterBll.GetDataByPaymentID(int.Parse(id));
            if (this.objPaymentMasterDT.Rows.Count <= 0)
                return;
            this.hfPaymentID.Value = this.objPaymentMasterDT.Rows[0]["PaymentID"].ToString();
            this.hfCompanyID.Value = this.objPaymentMasterDT.Rows[0]["CompanyID"].ToString();
            this.hfInvoiceID.Value = this.objPaymentMasterDT.Rows[0]["InvoiceID"].ToString();
        }

        private void SetRecord(string id)
        {
            this.objPaymentMasterDT = this.objPaymentMasterBll.GetDataByPaymentID(int.Parse(id));
            if (this.objPaymentMasterDT.Rows.Count <= 0)
                return;
            this.hfPaymentID.Value = this.objPaymentMasterDT.Rows[0]["PaymentID"].ToString();
            this.hfCompanyID.Value = this.objPaymentMasterDT.Rows[0]["CompanyID"].ToString();
            this.hfInvoiceID.Value = this.objPaymentMasterDT.Rows[0]["InvoiceID"].ToString();
            this.objInvoiceMasterDT = this.objInvoiceMasterBll.GetDataByInvoiceID(int.Parse(this.hfInvoiceID.Value));
            if (this.objInvoiceMasterDT.Rows.Count > 0)
            {
                this.hfInvoiceID.Value = this.objInvoiceMasterDT.Rows[0]["InvoiceID"].ToString();
                this.lblInvoiceAmt.Text = this.objInvoiceMasterDT.Rows[0]["InvoiceTotal"].ToString();
                this.lblInvoiceAmt.Text = Decimal.Round(Decimal.Parse(this.lblInvoiceAmt.Text), 2).ToString();
            }
            this.txtPayment.Text = this.objPaymentMasterDT.Rows[0]["PaymentAmount"].ToString();
            this.txtPayment.Text = Decimal.Round(Decimal.Parse(this.txtPayment.Text), 2).ToString();
            this.txtPaymentDate.Text = DateTime.Parse(this.objPaymentMasterDT.Rows[0]["Date"].ToString()).ToString("MM/dd/yyyy");
            this.txtPaymentNote.Text = this.objPaymentMasterDT.Rows[0]["Notes"].ToString();
            this.ddlMethod.SelectedIndex = this.ddlMethod.Items.IndexOf(this.ddlMethod.Items.FindByText(this.objPaymentMasterDT.Rows[0]["Method"].ToString()));
        }

        private void Clear()
        {
            this.txtPayment.Text = this.txtPaymentDate.Text = this.txtPaymentNote.Text = "";
            this.chkEmail.Checked = this.chkPayAll.Checked = false;
            this.PreDefineControls();
            this.txtPayment.Focus();
        }

        private void PreDefineControls()
        {
            this.txtPaymentDate.Text = DateTime.Now.ToString(this.dateFormat);
        }

        protected string GetInvoiceNumber(string invoiceid)
        {
            this.objInvoiceMasterDT = this.objInvoiceMasterBll.GetDataByInvoiceID(int.Parse(invoiceid));
            if (this.objInvoiceMasterDT.Rows.Count > 0)
                return "Invoice " + this.objInvoiceMasterDT.Rows[0]["InvoiceNumber"];
            return "";
        }

        protected void gvPayment_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                this.objInvoiceMasterDT = this.objInvoiceMasterBll.GetDataByInvoiceID(int.Parse(e.Row.Cells[2].Text));
                if (this.objInvoiceMasterDT.Rows.Count > 0)
                {
                    this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(this.objInvoiceMasterDT.Rows[0]["ClientID"].ToString()));
                    e.Row.Cells[2].Text = this.objCompanyClientMasterDT.Rows[0]["OrganizationName"].ToString();
                }
            }
            BoundField boundField = ((GridView)sender).Columns[4] as BoundField;
            if (boundField == null)
                return;
            boundField.DataFormatString = "{0:" + this.dateFormat + "}";
        }

        protected void gvPaymentOld_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            BoundField boundField = ((GridView)sender).Columns[0] as BoundField;
            if (boundField == null)
                return;
            boundField.DataFormatString = "{0:" + this.dateFormat + "}";
        }

        protected void chkPayAll_OnCheckedChanged(object sender, EventArgs e)
        {
            if (this.chkPayAll.Checked)
            {
                this.txtPayment.Text = this.lblBalance.Text;
                this.txtPayment.Enabled = false;
                this.ddlMethod.Focus();
            }
            else
            {
                this.txtPayment.Text = "";
                this.txtPayment.Enabled = true;
                this.txtPayment.Focus();
            }
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
                        ch2 = (char)((uint)ch1 + 1U);
                        break;
                }
                str1 = (str2 + (object)ch2).Trim();
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
                        str3 = str2 + (object)(ch2 = (char)((uint)ch1 + 1U));
                        break;
                }
                str1 = str3;
            }
            return str1;
        }

        protected async void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                string s = this.txtPaymentDate.Text;
                //string s = DateTime.ParseExact(this.txtPaymentDate.Text, new string[6]
                //{
                //  "MM/dd/yy",
                //  "MM/dd/yyyy",
                //  "dd/MM/yy",
                //  "dd/MM/yyyy",
                //  "yy-MM-dd",
                //  "yyyy-MM-dd"
                //}, (IFormatProvider) CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("MM/dd/yyyy");
                Decimal num11 = 0;
                if (this.txtPayment.Text.Trim().Length > 0)
                    num11 = Decimal.Parse(this.txtPayment.Text.Trim());
                if (num11 == Decimal.Parse(this.lblBalance.Text))
                    num11 = Decimal.Parse(this.lblBalance.Text);
                else if (num11 > Decimal.Parse(this.lblBalance.Text))
                {
                    Decimal num2 = num11 - Decimal.Parse(this.lblBalance.Text);
                    num11 = Decimal.Parse(this.lblBalance.Text);
                    this.objCreditMasterDT = this.objCreditMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
                    string sCreditNumber = this.objCreditMasterDT.Rows.Count <= 0 ? ConfigurationManager.AppSettings["InvoiceNoStart"] : PaymentMaster.NextNum(this.objCreditMasterDT.Rows[0]["CreditNumber"].ToString());
                    this.objInvoiceMasterDT = this.objInvoiceMasterBll.GetDataByInvoiceID(int.Parse(this.hfInvoiceID.Value));
                    this.objCreditMasterBll.AddCredit(int.Parse(this.hfCompanyID.Value), new int?(int.Parse(this.objInvoiceMasterDT.Rows[0]["ClientID"].ToString())), new int?(int.Parse(this.objInvoiceMasterDT.Rows[0]["CurrencyID"].ToString())), sCreditNumber, new DateTime?(DateTime.Parse(s)), "Overpayment from invoice #" + this.objInvoiceMasterDT.Rows[0]["InvoiceNumber"], "", "created", new Decimal?(num2), new Decimal?(num2));
                }
                int a = int.Parse(this.hfCompanyID.Value);
                int b = int.Parse(this.hfInvoiceID.Value);
                Decimal? c = new Decimal?(num11);
                string d = this.ddlMethod.SelectedItem.Value;
                DateTime? ed = new DateTime?(DateTime.Parse(s));
                string f = this.txtPaymentNote.Text.Trim();
                //int paymentID = this.objPaymentMasterBll.AddPayment(int.Parse(this.hfCompanyID.Value), int.Parse(this.hfInvoiceID.Value), new Decimal?(num11), this.ddlMethod.SelectedItem.Value, new DateTime?(DateTime.Parse(s)), this.txtPaymentNote.Text.Trim());
                int paymentID = this.objPaymentMasterBll.AddPayment(int.Parse(this.hfCompanyID.Value), int.Parse(this.hfInvoiceID.Value), Convert.ToDecimal(txtPayment.Text), this.ddlMethod.SelectedItem.Value, Convert.ToDateTime(s), this.txtPaymentNote.Text.Trim());
                if (num11 > new Decimal(0))
                {
                    Decimal num2 = Decimal.Round(Decimal.Parse(this.lblTotalPaid.Text) + num11, 2);
                    //this.objInvoiceMasterBll.UpdatePaidToDate(new Decimal?(num2), int.Parse(this.hfInvoiceID.Value));
                    this.objInvoiceMasterBll.UpdateInvoiceStatus(num2 == Decimal.Parse(this.lblInvoiceAmt.Text) ? "paid" : "partial", int.Parse(this.hfInvoiceID.Value));
                }
                if (paymentID != 0)
                {
                    this.Session["savePay"] = (object)1;
                    if (true ||chkEmail.Checked)
                    {
                        this.objInvoiceMasterDT = this.objInvoiceMasterBll.GetDataByInvoiceID(int.Parse(this.hfInvoiceID.Value));
                        if (this.objInvoiceMasterDT.Rows.Count > 0)
                        {
                            this.lblInvoiceAmt.Text = this.objInvoiceMasterDT.Rows[0]["InvoiceTotal"].ToString();
                            this.lblInvoiceAmt.Text = Decimal.Round(Decimal.Parse(this.lblInvoiceAmt.Text), 2).ToString();
                           await this.SendMailNew(paymentID);
                        }
                    }
                    this.DisplayAlert("Payment Added Successfully");
                    this.Response.Redirect("PaymentMaster.aspx");
                }
                else
                    this.DisplayAlert("Problem in Insertion Try After Sometime..!");
            }
            else
                this.DisplayAlert("Please Fill Proper Data..!");
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
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
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

        private async Task SendMailNew(int paymentID)
        {
            this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
            string displayName = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString().ToUpper();
            string addresses = this.objCompanyMasterDT.Rows[0]["CompanyEmail"].ToString();
            this.objPaymentMasterDT = this.objPaymentMasterBll.GetDataByPaymentID(paymentID);
            string s1 = this.objPaymentMasterDT.Rows[0]["InvoiceID"].ToString();
            this.objInvoiceMasterDT = this.objInvoiceMasterBll.GetDataByInvoiceID(int.Parse(s1));
            string str1 = this.objInvoiceMasterDT.Rows[0]["InvoiceNumber"].ToString();
            string s2 = this.objInvoiceMasterDT.Rows[0]["InvoiceTotal"].ToString();
            //string s3 = this.objInvoiceMasterDT.Rows[0]["PaidToDate"].ToString();
            //Decimal num = Decimal.Parse(s2) - Decimal.Parse(s3);
            Decimal num = Decimal.Parse(s2);
            string s4 = this.objInvoiceMasterDT.Rows[0]["ClientID"].ToString();
            string str2 = string.Empty;
            string address1 = string.Empty;
            string str3 = string.Empty;
            string str4 = string.Empty;
            string str5 = string.Empty;
            this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(s4));
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
                    string key1 = PaymentMaster.GenerateCode();
                    string str6 = HttpUtility.UrlEncode(this.Encrypt(user.UserName, key1));
                    string password = user.GetPassword();
                    string key2 = PaymentMaster.GenerateCode();
                    string str7 = HttpUtility.UrlEncode(this.Encrypt(password, key2));
                    str2 = string.Format("{5}/CheckClient.aspx?page=invoice&anyId={0}&name={1}&tech={2}&keyname={3}&keytech={4}", (object)s1, (object)str6, (object)str7, (object)key1, (object)key2, Common.CommonHandler.WebsiteBaseURL);
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
            this.objNewPaymentEmailTemplateDT = this.objNewPaymentEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value), "other");
            if (this.objNewPaymentEmailTemplateDT.Rows.Count > 0)
                str8 = this.objNewPaymentEmailTemplateDT.Rows[0]["EmailBody"].ToString();
            Hashtable Variables = new Hashtable()
      {
        {
          (object) "company",
          (object) displayName
        },
        {
          (object) "companyName",
          (object) displayName
        },
        {
          (object) "invoiceNum",
          (object) str1
        },
        {
          (object) "invoiceNumber",
          (object) str1
        },
        {
          (object) "someLink",
          (object) str2
        },
        {
          (object) "emailTemplate",
          (object) str8
        },
        {
          (object) "companyEmail",
          (object) ("<a href=\"mailto:" + addresses + "\">" + addresses + "</a>")
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
          (object) s2
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
        },
        {
          (object) "loginLink",
          (object) "<a target=\"_blank\" href=\"http://www.billtransact.com/MemberArea.aspx\">https://www.billtransact.com/MemberArea.aspx</a>"
        }
      };
            Parser parser1 = new Parser(this.Server.MapPath("~/MailTemplate/PaymentInformationNew.html"), Variables);
            string path1 = this.Server.MapPath("~\\TempHTMLFiles\\");
            File.WriteAllText(Path.Combine(path1, "Payment.html"), parser1.Parse());
            Parser parser2 = new Parser(path1 + "Payment.html", Variables);
            try
            {
                //MailMessage message = new MailMessage()
                //{
                //  From = new MailAddress(address2, displayName)
                //};
                //message.To.Add(new MailAddress(address1));
                //message.ReplyToList.Add(addresses);
                //message.Subject = displayName + " has received your payment for invoice " + str1 + " in Bill Transact";
                //message.BodyEncoding = Encoding.UTF8;
                //message.Body = parser2.Parse();
                //message.IsBodyHtml = true;

                //Common.CommonHandler.SendSMTPEmail(hfCompanyID.Value, address1, displayName + " has received your payment for invoice " + str1 + " in Bill Transact", parser2.Parse(), true);
                await Common.CommonHandler.SendMail(hfCompanyID.Value, address1, displayName + " has received your payment for invoice " + str1 + " in Bill Transact", parser2.Parse(), true);
                //SmtpClientForCompany.smtpClient(this.hfCompanyID.Value).Send(message);
            }
            catch (Exception ex)
            {
                this.DisplayAlert("Error in sending mail." + (object)ex);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                string s = DateTime.ParseExact(this.txtPaymentDate.Text, new string[6]
                {
          "MM/dd/yy",
          "MM/dd/yyyy",
          "dd/MM/yy",
          "dd/MM/yyyy",
          "yy-MM-dd",
          "yyyy-MM-dd"
                }, (IFormatProvider)CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("MM/dd/yyyy");
                Decimal num1 = new Decimal(0);
                if (this.txtPayment.Text.Trim().Length > 0)
                    num1 = Decimal.Parse(this.txtPayment.Text.Trim());
                if (num1 >= Decimal.Parse(this.lblBalance.Text))
                    num1 = Decimal.Parse(this.lblBalance.Text);
                bool flag = this.objPaymentMasterBll.UpdatePayment(int.Parse(this.hfPaymentID.Value), int.Parse(this.hfCompanyID.Value), int.Parse(this.hfInvoiceID.Value), new Decimal?(num1), this.ddlMethod.SelectedItem.Value, new DateTime?(DateTime.Parse(s)), this.txtPaymentNote.Text.Trim());
                if (num1 > new Decimal(0))
                {
                    Decimal num2 = Decimal.Round(Decimal.Parse(this.lblTotalPaid.Text) + num1, 2);
                    this.objInvoiceMasterBll.UpdatePaidToDate(new Decimal?(num2), int.Parse(this.hfInvoiceID.Value));
                    this.objInvoiceMasterBll.UpdateInvoiceStatus(num2 == Decimal.Parse(this.lblInvoiceAmt.Text) ? "paid" : "partial", int.Parse(this.hfInvoiceID.Value));
                }
                if (flag)
                {
                    this.Session["updatePay"] = (object)1;
                    this.DisplayAlert("Payment Updated Successfully");
                    this.Response.Redirect("PaymentMaster.aspx");
                }
                else
                    this.DisplayAlert("Problem in Updation Try After Sometime..!");
            }
            else
                this.DisplayAlert("Please Fill Proper Data..!");
        }

        public void DisplayAlert(string message)
        {
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">" + this.GetAlertScript(message) + "</script>");
        }

        public string GetAlertScript(string message)
        {
            return "alert('" + message.Replace("'", "\\'") + "');";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.gvInvoice.DataBind();
            this.mpInvoicePayment.Show();
        }

        protected void gvInvoice_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(e.Row.Cells[2].Text));
                e.Row.Cells[2].Text = this.objCompanyClientMasterDT.Rows[0]["OrganizationName"].ToString();
            }
            BoundField boundField = ((GridView)sender).Columns[3] as BoundField;
            if (boundField == null)
                return;
            boundField.DataFormatString = "{0:" + this.dateFormat + "}";
        }

        protected void lnkClick_Click(object sender, EventArgs e)
        {
            this.mpInvoicePayment.Hide();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int num = 0;
            for (int index = 0; index < this.gvPayment.Rows.Count; ++index)
            {
                CheckBox checkBox = (CheckBox)this.gvPayment.Rows[index].Cells[0].FindControl("chkID");
                if (checkBox.Checked)
                {
                    ++num;
                    this.objPaymentMasterDT = this.objPaymentMasterBll.GetDataByPaymentID(int.Parse(checkBox.ToolTip));
                    if (this.objPaymentMasterDT.Rows.Count > 0)
                    {
                        string s1 = this.objPaymentMasterDT.Rows[0]["InvoiceID"].ToString();
                        string s2 = this.objPaymentMasterDT.Rows[0]["PaymentAmount"].ToString();
                        this.objInvoiceMasterDT = this.objInvoiceMasterBll.GetDataByInvoiceID(int.Parse(s1));
                        if (this.objInvoiceMasterDT.Rows.Count > 0)
                            this.objInvoiceMasterBll.UpdatePaidToDate(new Decimal?(Decimal.Round(Decimal.Parse(this.objInvoiceMasterDT.Rows[0]["PaidToDate"].ToString()) - Decimal.Parse(s2), 2)), int.Parse(s1));
                    }
                    this.objPaymentMasterBll.DeletePayment(int.Parse(checkBox.ToolTip));
                }
            }
            if (num == 0)
                this.DisplayAlert("No Payments were selected.");
            else
                this.Response.Redirect("PaymentMaster.aspx");
        }

        protected async void btnEmail_Click(object sender, EventArgs e)
        {
            int num = 0;
            for (int index = 0; index < this.gvPayment.Rows.Count; ++index)
            {
                CheckBox checkBox = (CheckBox)this.gvPayment.Rows[index].Cells[0].FindControl("chkID");
                if (checkBox.Checked)
                {
                    ++num;
                  await  this.SendMailNew(int.Parse(checkBox.ToolTip));
                }
            }
            if (num == 0)
                this.DisplayAlert("No Payments were selected.");
            else
                this.Response.Redirect("PaymentMaster.aspx");
        }

        protected string GetCurrency(string invId)
        {
            this.objInvoiceMasterDT = this.objInvoiceMasterBll.GetDataByInvoiceID(int.Parse(invId));
            this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(this.objInvoiceMasterDT.Rows[0]["CurrencyID"].ToString()));
            if (this.objCurrencyMasterDT.Rows.Count > 0)
                return "(" + this.objCurrencyMasterDT.Rows[0]["CurrencySymbol"] + ")";
            return "";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }
    }
}

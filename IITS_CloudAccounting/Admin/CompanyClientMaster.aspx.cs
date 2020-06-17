// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.CompanyClientMaster
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Collections;
using System.Data;
using System.IO;
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
    public class CompanyClientMaster : Page
    {
        private readonly UserBLL objUserBll = new UserBLL();
        private CloudAccountDA.aspnet_UsersDataTable objUserDT = new CloudAccountDA.aspnet_UsersDataTable();
        private readonly CityMasterBLL objCityMasterBll = new CityMasterBLL();
        private CloudAccountDA.CityMasterDataTable objCityMasterDT = new CloudAccountDA.CityMasterDataTable();
        private readonly CountryMasterBLL objCountryMasterBll = new CountryMasterBLL();
        private CloudAccountDA.CountryMasterDataTable objCountryMasterDT = new CloudAccountDA.CountryMasterDataTable();
        private readonly CurrencyMasterBLL objCurrencyMasterBll = new CurrencyMasterBLL();
        private CloudAccountDA.CurrencyMasterDataTable objCurrencyMasterDT = new CloudAccountDA.CurrencyMasterDataTable();
        private readonly IndustryMasterBLL objIndustryMasterBll = new IndustryMasterBLL();
        private CloudAccountDA.IndustryMasterDataTable objIndustryMasterDT = new CloudAccountDA.IndustryMasterDataTable();
        private readonly StateMasterBLL objStateMasterBll = new StateMasterBLL();
        private CloudAccountDA.StateMasterDataTable objStateMasterDT = new CloudAccountDA.StateMasterDataTable();
        private readonly CompanyClientMasterBLL objCompanyClientMasterBll = new CompanyClientMasterBLL();
        private CloudAccountDA.CompanyClientMasterDataTable objCompanyClientMasterDT = new CloudAccountDA.CompanyClientMasterDataTable();
        private readonly CompanyClientContactDetailBLL objCompanyClientContactDetailBll = new CompanyClientContactDetailBLL();
        private CloudAccountDA.CompanyClientContactDetailDataTable objCompanyClientContactDetailDT = new CloudAccountDA.CompanyClientContactDetailDataTable();
        private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
        private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
        private readonly ContractorMasterBLL objContractorMasterBll = new ContractorMasterBLL();
        private CloudAccountDA.ContractorMasterDataTable objContractorMasterDT = new CloudAccountDA.ContractorMasterDataTable();
        private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
        private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
        private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
        private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
        private readonly MiscellaneousMasterBLL objMiscellaneousMasterBll = new MiscellaneousMasterBLL();
        private CloudAccountDA.MiscellaneousMasterDataTable objMiscellaneousMasterDT = new CloudAccountDA.MiscellaneousMasterDataTable();
        private int linePerPage = 15;
        private readonly PackageFeatureMasterBLL objPackageFeatureMasterBll = new PackageFeatureMasterBLL();
        private CloudAccountDA.PackageFeatureMasterDataTable objPackageFeatureMasterDT = new CloudAccountDA.PackageFeatureMasterDataTable();
        private readonly CompanyPackageMasterBLL objCompanyPackageMasterBll = new CompanyPackageMasterBLL();
        private CloudAccountDA.CompanyPackageMasterDataTable objCompanyPackageMasterDT = new CloudAccountDA.CompanyPackageMasterDataTable();
        private readonly CloudPackageDetailsBLL objCloudPackageDetailsBll = new CloudPackageDetailsBLL();
        private CloudAccountDA.CloudPackageDetailsDataTable objCloudPackageDetailsDT = new CloudAccountDA.CloudPackageDetailsDataTable();
        private readonly NewClientEmailTemplateBLL objNewClientEmailTemplateBll = new NewClientEmailTemplateBLL();
        private CloudAccountDA.NewClientEmailTemplateDataTable objNewClientEmailTemplateDT = new CloudAccountDA.NewClientEmailTemplateDataTable();
        private readonly SMTPSettingsBLL objSMTPSettingsBll = new SMTPSettingsBLL();
        private CloudAccountDA.SMTPSettingsDataTable objSMTPSettingsDT = new CloudAccountDA.SMTPSettingsDataTable();
        protected ToolkitScriptManager tsm;
        protected HtmlGenericControl divImport;
        protected Label lblImported;
        protected HtmlGenericControl divSave;
        protected HtmlGenericControl divUpdate;
        protected Panel pnlAdd;
        protected UpdatePanel upCompanyClient;
        protected TextBox txtClientName;
        protected RequiredFieldValidator rfvClientName;
        protected DropDownList ddlCurrency;
        protected RequiredFieldValidator rfvCurrency;
        protected SqlDataSource sqldsCurrency;
        protected CheckBox chkEmail;
        protected CheckBox chkSnailMail;
        protected TextBox txtEmail;
        protected RequiredFieldValidator rfvEmail;
        protected RegularExpressionValidator revEmail;
        protected TextBox txtFirstName;
        protected TextBox txtLastName;
        protected TextBox txtHomePhone;
        protected TextBox txtMobile;
        protected CheckBox chkAssignUsername;
        protected HtmlGenericControl usernameDiv;
        protected TextBox txtUsername;
        protected Label lblUsernameAdd;
        protected TextBox txtPassword;
        protected Label lblPasswordAdd;
        protected TextBox txtConfPassword;
        protected CheckBox chkSend;
        protected Label lblInvitation;
        protected LinkButton lnkAddContact;
        protected HtmlGenericControl extraContact;
        protected GridView gvCompanyClientContact;
        protected Button btnAddGridRow;
        protected DropDownList ddlCountry;
        protected TextBox txtAddress1;
        protected TextBox txtAddress2;
        protected DropDownList ddlState;
        protected DropDownList ddlCity;
        protected TextBox txtZipCode;
        protected DropDownList ddlCountrySecondary;
        protected TextBox txtAddress1Secondary;
        protected TextBox txtAddress2Secondary;
        protected DropDownList ddlStateSecondary;
        protected DropDownList ddlCitySecondary;
        protected TextBox txtZipCodeSecondary;
        protected DropDownList ddlIndustry;
        protected DropDownList ddlCompanySize;
        protected TextBox txtBussinessPhone;
        protected TextBox txtFax;
        protected TextBox txtInternalNote;
        protected Button btnSubmit;
        protected Button btnUpdate;
        protected Panel pnlView;
        protected Label lblClientName;
        protected Button btnEdit;
        protected Label lblOutstandingAmt;
        protected GridView gvInvoiceRemaing;
        protected SqlDataSource sqldsInvoiceRemaing;
        protected Label lblCreditAmt;
        protected GridView gvCredit;
        protected SqlDataSource sqldsCredit;
        protected Label lblClientName1;
        protected Label lblAddress1;
        protected Label lblAddress2;
        protected Label lblCity;
        protected Label lblState;
        protected Label lblZipCode;
        protected Label lblCountry;
        protected Label lblFirstName;
        protected Label lblLastName;
        protected Label lblEmail;
        protected Label lblMobile;
        protected Label lblHomePhone;
        protected DataList dlClientContacts;
        protected SqlDataSource sqldsClientContacts;
        protected Label lblEmailMail;
        protected Panel pnlViewNo;
        protected Label lblSnailMail;
        protected Label lblAssignUsername;
        protected Label lblUsername;
        protected Label lblPassword;
        protected Label lblConfPassword;
        protected Label lblCountrySecondary;
        protected Label lblAddress1Secondary;
        protected Label lblAddress2Secondary;
        protected Label lblStateSecondary;
        protected Label lblCitySecondary;
        protected Label lblZipCodeSecondary;
        protected Label lblIndustry;
        protected Label lblCompanySize;
        protected Label lblBussinessPhone;
        protected Label lblFax;
        protected Label lblInternalNote;
        protected Panel pnlViewAll;
        protected Label lblHeader;
        protected Button btnAdd;
        protected TextBox txtOrganizationSearch;
        protected TextBox txtFirstNameSearch;
        protected TextBox txtLastNameSearch;
        protected TextBox txtAddressSearch;
        protected TextBox txtEmailSearch;
        protected TextBox txtPhoneSearch;
        protected TextBox txtNotesSearch;
        protected Button btnSearch;
        protected Button btnReset;
        protected Button btnUnDelete;
        protected Button btnArchived;
        protected Button btnUnArchived;
        protected Button btnDelete;
        protected Button btnEmail;
        protected GridView gvCompanyClient;
        protected HtmlAnchor activeTag;
        protected HtmlAnchor archivedTag;
        protected HtmlAnchor deletedTag;
        protected ObjectDataSource objdsCompanyClient;
        protected ObjectDataSource objdsCompanyClientStaff;
        protected HiddenField hfCompanyID;
        protected HiddenField hfStaffID;
        protected HiddenField hfCompanyClientID;
        protected SqlDataSource sqldsCountry;
        protected SqlDataSource sqldsState;
        protected SqlDataSource sqldsCity;
        protected SqlDataSource sqldsSecondaryCountry;
        protected SqlDataSource sqldsSecondaryState;
        protected SqlDataSource sqldsSecondaryCity;
        protected SqlDataSource sqldsIndustry;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Master == null)
                return;
            ((HtmlControl)this.Master.FindControl("userManagement")).Attributes.Add("class", "active open");
            ((HtmlControl)this.Master.FindControl("client")).Attributes.Add("class", "active open");
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
            if (this.Session["importClient"] != null)
            {
                this.divImport.Visible = true;
                this.lblImported.Text = this.Session["importClient"].ToString();
            }
            else
                this.divImport.Visible = false;
            this.divSave.Visible = this.Session["saveClient"] != null;
            this.divUpdate.Visible = this.Session["updateClient"] != null;
            this.Session.Abandon();
            if (this.Request.QueryString["cmd"] != null)
            {
                switch (this.Request.QueryString["cmd"])
                {
                    case "view":
                        if (this.Request.QueryString["ID"] == null)
                            break;
                        string i = this.Request.QueryString["ID"];
                        this.pnlView.Visible = true;
                        this.pnlViewAll.Visible = false;
                        this.pnlAdd.Visible = false;
                        this.ViewRecord(i);
                        break;
                    case "add":
                        if (this.Request.QueryString["ID"] != null)
                        {
                            string iD = this.Request.QueryString["ID"];
                            this.FirstGridRow();
                            this.SetRecord(iD);
                            this.pnlAdd.Visible = true;
                            this.pnlView.Visible = false;
                            this.pnlViewAll.Visible = false;
                            this.btnSubmit.Visible = false;
                            this.btnUpdate.Visible = true;
                            this.txtClientName.Focus();
                            break;
                        }
                        this.Clear();
                        this.lblInvitation.Text = "(not yet invited)";
                        this.lblInvitation.Style.Add("color", "red");
                        this.txtClientName.Focus();
                        this.pnlViewAll.Visible = false;
                        this.pnlAdd.Visible = true;
                        this.pnlView.Visible = false;
                        this.btnUpdate.Visible = false;
                        this.btnSubmit.Visible = true;
                        this.FirstGridRow();
                        break;
                    default:
                        this.btnArchived.Visible = !this.CheckARQuery();
                        this.btnUnArchived.Visible = this.CheckARQuery();
                        this.btnDelete.Visible = !this.CheckDEQuery();
                        this.btnUnDelete.Visible = this.CheckDEQuery();
                        this.ATagStyle();
                        this.pnlViewAll.Visible = true;
                        this.pnlAdd.Visible = false;
                        this.pnlView.Visible = false;
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
            this.linePerPage = int.Parse(this.objMiscellaneousMasterDT.Rows[0]["LinesPerPage"].ToString());
            this.gvCompanyClient.PageSize = this.linePerPage;
        }

        private void ATagStyle()
        {
            if (this.Request.QueryString["ac"] != null && bool.Parse(this.Request.QueryString["ac"]))
            {
                this.activeTag.Attributes.Add("class", "activeTag");
                this.activeTag.Attributes.Remove("href");
                this.lblHeader.Text = "Clients";
            }
            if (this.Request.QueryString["ar"] != null && bool.Parse(this.Request.QueryString["ar"]))
            {
                this.archivedTag.Attributes.Add("class", "activeTag");
                this.archivedTag.Attributes.Remove("href");
                this.lblHeader.Text = "Archived Clients";
            }
            if (this.Request.QueryString["de"] != null && bool.Parse(this.Request.QueryString["de"]))
            {
                this.deletedTag.Attributes.Add("class", "activeTag");
                this.deletedTag.Attributes.Remove("href");
                this.lblHeader.Text = "Deleted Clients";
            }
            if (this.Request.QueryString["ar"] != null || this.Request.QueryString["ac"] != null || this.Request.QueryString["de"] != null)
                return;
            this.activeTag.Attributes.Add("class", "activeTag");
            this.activeTag.Attributes.Remove("href");
            this.lblHeader.Text = "Clients";
        }

        protected void gvCompanyClient_Sorting(object sender, GridViewSortEventArgs e)
        {
            this.BindGrid();
        }

        private void Clear()
        {
            this.txtClientName.Text = this.txtEmail.Text = this.txtFirstName.Text = this.txtLastName.Text = this.txtHomePhone.Text = this.txtMobile.Text = this.txtUsername.Text = this.txtAddress1.Text = this.txtAddress2.Text = this.txtZipCode.Text = this.txtAddress1Secondary.Text = this.txtAddress2Secondary.Text = this.txtZipCodeSecondary.Text = this.txtBussinessPhone.Text = this.txtFax.Text = this.txtInternalNote.Text = "";
            this.chkAssignUsername.Checked = this.chkEmail.Checked = this.chkSnailMail.Checked = false;
            this.ddlCountry.SelectedIndex = this.ddlState.SelectedIndex = this.ddlCity.SelectedIndex = 0;
            this.ddlCountrySecondary.SelectedIndex = this.ddlStateSecondary.SelectedIndex = this.ddlCitySecondary.SelectedIndex = 0;
            this.ddlCurrency.SelectedIndex = this.ddlCompanySize.SelectedIndex = this.ddlIndustry.SelectedIndex = 0;
            this.txtClientName.Focus();
        }

        private void BindGrid()
        {
            MembershipUser user = Membership.GetUser();
            if (user != null)
            {
                string username = user.ToString();
                if (Roles.IsUserInRole(username, "Admin"))
                    this.gvCompanyClient.DataSource = (object)this.objdsCompanyClient;
                else if (Roles.IsUserInRole(username, "Employee"))
                    this.gvCompanyClient.DataSource = (object)this.objdsCompanyClientStaff;
            }
            this.gvCompanyClient.DataBind();
        }

        private void ViewRecord(string i)
        {
            this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(i));
            if (this.objCompanyClientMasterDT.Rows.Count <= 0)
                return;
            this.hfCompanyClientID.Value = this.objCompanyClientMasterDT.Rows[0]["CompanyClientID"].ToString();
            this.hfCompanyID.Value = this.objCompanyClientMasterDT.Rows[0]["CompanyID"].ToString();
            this.lblClientName1.Text = this.lblClientName.Text = this.objCompanyClientMasterDT.Rows[0]["OrganizationName"].ToString();
            this.lblEmail.Text = this.objCompanyClientMasterDT.Rows[0]["Email"].ToString();
            this.lblFirstName.Text = this.objCompanyClientMasterDT.Rows[0]["FirstName"].ToString();
            this.lblFirstName.Text += " ";
            this.lblLastName.Text = this.objCompanyClientMasterDT.Rows[0]["LastName"].ToString();
            this.lblHomePhone.Text = this.objCompanyClientMasterDT.Rows[0]["HomePhone"].ToString();
            this.lblMobile.Text = this.objCompanyClientMasterDT.Rows[0]["Mobile"].ToString();
            this.lblUsername.Text = this.objCompanyClientMasterDT.Rows[0]["UserName"].ToString();
            this.lblAddress1Secondary.Text = this.objCompanyClientMasterDT.Rows[0]["SecondaryAddress1"].ToString();
            this.lblAddress2Secondary.Text = this.objCompanyClientMasterDT.Rows[0]["SecondaryAddress2"].ToString();
            this.lblZipCodeSecondary.Text = this.objCompanyClientMasterDT.Rows[0]["SecondaryZipCode"].ToString();
            this.lblBussinessPhone.Text = this.objCompanyClientMasterDT.Rows[0]["BussinessPhone"].ToString();
            this.lblFax.Text = this.objCompanyClientMasterDT.Rows[0]["Fax"].ToString();
            this.lblInternalNote.Text = this.objCompanyClientMasterDT.Rows[0]["InternalNotes"].ToString();
            this.lblAssignUsername.Text = this.objCompanyClientMasterDT.Rows[0]["LoginCredentials"].ToString();
            this.lblEmailMail.Visible = bool.Parse(this.objCompanyClientMasterDT.Rows[0]["InvoiceByEmail"].ToString());
            this.lblSnailMail.Text = this.objCompanyClientMasterDT.Rows[0]["InvoiceBySnailMail"].ToString();
            this.lblAddress1.Text = !string.IsNullOrEmpty(this.objCompanyClientMasterDT.Rows[0]["Address1"].ToString()) ? (string)this.objCompanyClientMasterDT.Rows[0]["Address1"] + (object)"<br />" : "";
            this.lblAddress2.Text = !string.IsNullOrEmpty(this.objCompanyClientMasterDT.Rows[0]["Address2"].ToString()) ? (string)this.objCompanyClientMasterDT.Rows[0]["Address2"] + (object)"<br />" : "";
            this.lblZipCode.Text = !string.IsNullOrEmpty(this.objCompanyClientMasterDT.Rows[0]["ZipCode"].ToString()) ? (string)this.objCompanyClientMasterDT.Rows[0]["ZipCode"] + (object)" , " : "";
            this.lblCompanySize.Text = this.objCompanyClientMasterDT.Rows[0]["CompanySize"].ToString();
            string s1 = this.objCompanyClientMasterDT.Rows[0]["CountryID"].ToString();
            string s2 = this.objCompanyClientMasterDT.Rows[0]["StateID"].ToString();
            string s3 = this.objCompanyClientMasterDT.Rows[0]["CityID"].ToString();
            string s4 = this.objCompanyClientMasterDT.Rows[0]["SecondaryCountryID"].ToString();
            string s5 = this.objCompanyClientMasterDT.Rows[0]["SecondaryStateID"].ToString();
            string s6 = this.objCompanyClientMasterDT.Rows[0]["SecondaryCityID"].ToString();
            string s7 = this.objCompanyClientMasterDT.Rows[0]["IndustryID"].ToString();
            if (!string.IsNullOrEmpty(s7))
            {
                this.objIndustryMasterDT = this.objIndustryMasterBll.GetDataByIndustryID(int.Parse(s7));
                this.lblIndustry.Text = this.objIndustryMasterDT.Rows[0]["IndustryName"].ToString();
            }
            if (!string.IsNullOrEmpty(s1))
            {
                this.objCountryMasterDT = this.objCountryMasterBll.GetDataByCountryID(int.Parse(s1));
                this.lblCountry.Text = this.objCountryMasterDT.Rows[0]["CountryName"].ToString();
            }
            else
                this.lblCountry.Text = "";
            if (!string.IsNullOrEmpty(s2))
            {
                this.objStateMasterDT = this.objStateMasterBll.GetDataByStateID(int.Parse(s2));
                this.lblState.Text = (string)this.objStateMasterDT.Rows[0]["StateName"] + (object)"<br />";
            }
            else
                this.lblState.Text = "";
            if (!string.IsNullOrEmpty(s3))
            {
                this.objCityMasterDT = this.objCityMasterBll.GetDataByCityID(int.Parse(s3));
                this.lblCity.Text = (string)this.objCityMasterDT.Rows[0]["CityName"] + (object)" , ";
            }
            else
                this.lblCity.Text = "";
            if (!string.IsNullOrEmpty(s4))
            {
                this.objCountryMasterDT = this.objCountryMasterBll.GetDataByCountryID(int.Parse(s4));
                this.lblCountrySecondary.Text = this.objCountryMasterDT.Rows[0]["CountryName"].ToString();
            }
            if (!string.IsNullOrEmpty(s5))
            {
                this.objStateMasterDT = this.objStateMasterBll.GetDataByStateID(int.Parse(s5));
                this.lblStateSecondary.Text = this.objStateMasterDT.Rows[0]["StateName"].ToString();
            }
            if (!string.IsNullOrEmpty(s6))
            {
                this.objCityMasterDT = this.objCityMasterBll.GetDataByCityID(int.Parse(s6));
                this.lblCitySecondary.Text = this.objCityMasterDT.Rows[0]["CityName"].ToString();
            }
            this.gvCredit.DataBind();
            this.lblCreditAmt.Text = this.gvCredit.Rows.Count > 0 ? this.gvCredit.Rows[0].Cells[1].Text : "0.00";
            this.gvInvoiceRemaing.DataBind();
            this.lblOutstandingAmt.Text = this.gvInvoiceRemaing.Rows.Count > 0 ? this.gvInvoiceRemaing.Rows[0].Cells[1].Text : "0.00";
        }

        private void SetRecord(string iD)
        {
            this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(iD));
            if (this.objCompanyClientMasterDT.Rows.Count <= 0)
                return;
            this.hfCompanyClientID.Value = this.objCompanyClientMasterDT.Rows[0]["CompanyClientID"].ToString();
            this.hfCompanyID.Value = this.objCompanyClientMasterDT.Rows[0]["CompanyID"].ToString();
            this.txtClientName.Text = this.objCompanyClientMasterDT.Rows[0]["OrganizationName"].ToString();
            this.txtEmail.Text = this.objCompanyClientMasterDT.Rows[0]["Email"].ToString();
            this.txtFirstName.Text = this.objCompanyClientMasterDT.Rows[0]["FirstName"].ToString();
            this.txtLastName.Text = this.objCompanyClientMasterDT.Rows[0]["LastName"].ToString();
            this.txtHomePhone.Text = this.objCompanyClientMasterDT.Rows[0]["HomePhone"].ToString();
            this.txtMobile.Text = this.objCompanyClientMasterDT.Rows[0]["Mobile"].ToString();
            this.lblUsernameAdd.Text = this.txtUsername.Text = this.objCompanyClientMasterDT.Rows[0]["UserName"].ToString();
            this.txtAddress1.Text = this.objCompanyClientMasterDT.Rows[0]["Address1"].ToString();
            this.txtAddress2.Text = this.objCompanyClientMasterDT.Rows[0]["Address2"].ToString();
            this.txtZipCode.Text = this.objCompanyClientMasterDT.Rows[0]["ZipCode"].ToString();
            this.txtAddress1Secondary.Text = this.objCompanyClientMasterDT.Rows[0]["SecondaryAddress1"].ToString();
            this.txtAddress2Secondary.Text = this.objCompanyClientMasterDT.Rows[0]["SecondaryAddress2"].ToString();
            this.txtZipCodeSecondary.Text = this.objCompanyClientMasterDT.Rows[0]["SecondaryZipCode"].ToString();
            this.txtBussinessPhone.Text = this.objCompanyClientMasterDT.Rows[0]["BussinessPhone"].ToString();
            this.txtFax.Text = this.objCompanyClientMasterDT.Rows[0]["Fax"].ToString();
            this.txtInternalNote.Text = this.objCompanyClientMasterDT.Rows[0]["InternalNotes"].ToString();
            this.chkAssignUsername.Checked = bool.Parse(this.objCompanyClientMasterDT.Rows[0]["LoginCredentials"].ToString());
            this.chkAssignUsername_OnCheckedChanged((object)null, (EventArgs)null);
            this.chkEmail.Checked = bool.Parse(this.objCompanyClientMasterDT.Rows[0]["InvoiceByEmail"].ToString());
            this.chkSnailMail.Checked = bool.Parse(this.objCompanyClientMasterDT.Rows[0]["InvoiceBySnailMail"].ToString());
            MembershipUser user = Membership.GetUser(this.lblUsernameAdd.Text);
            if (user != null)
                this.lblPasswordAdd.Text = user.GetPassword();
            if (!this.chkAssignUsername.Checked)
            {
                this.lblInvitation.Text = "(not yet invited)";
                this.lblInvitation.Style.Add("color", "red");
            }
            else
            {
                this.lblInvitation.Text = "(already invited)";
                this.lblInvitation.Style.Add("color", "Green");
            }
            this.txtUsername.Enabled = false;
            string text = this.objCompanyClientMasterDT.Rows[0]["CompanySize"].ToString();
            string s1 = this.objCompanyClientMasterDT.Rows[0]["CurrencyID"].ToString();
            string s2 = this.objCompanyClientMasterDT.Rows[0]["CountryID"].ToString();
            string s3 = this.objCompanyClientMasterDT.Rows[0]["StateID"].ToString();
            string s4 = this.objCompanyClientMasterDT.Rows[0]["CityID"].ToString();
            string s5 = this.objCompanyClientMasterDT.Rows[0]["SecondaryCountryID"].ToString();
            string s6 = this.objCompanyClientMasterDT.Rows[0]["SecondaryStateID"].ToString();
            string s7 = this.objCompanyClientMasterDT.Rows[0]["SecondaryCityID"].ToString();
            string s8 = this.objCompanyClientMasterDT.Rows[0]["IndustryID"].ToString();
            this.ddlCompanySize.SelectedIndex = this.ddlCompanySize.Items.IndexOf(this.ddlCompanySize.Items.FindByText(text));
            if (!string.IsNullOrEmpty(s1))
            {
                this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(s1));
                if (this.objCurrencyMasterDT.Rows.Count > 0)
                {
                    this.ddlCurrency.Items.Add(this.objCurrencyMasterDT.Rows[0]["CurrencyID"].ToString());
                    this.ddlCurrency.SelectedValue = this.objCurrencyMasterDT.Rows[0]["CurrencyID"].ToString();
                }
            }
            if (!string.IsNullOrEmpty(s8))
            {
                this.objIndustryMasterDT = this.objIndustryMasterBll.GetDataByIndustryID(int.Parse(s8));
                if (this.objIndustryMasterDT.Rows.Count > 0)
                {
                    this.ddlIndustry.Items.Add(this.objIndustryMasterDT.Rows[0]["IndustryID"].ToString());
                    this.ddlIndustry.SelectedValue = this.objIndustryMasterDT.Rows[0]["IndustryID"].ToString();
                }
            }
            if (!string.IsNullOrEmpty(s2))
            {
                this.objCountryMasterDT = this.objCountryMasterBll.GetDataByCountryID(int.Parse(s2));
                if (this.objCountryMasterDT.Rows.Count > 0)
                {
                    this.ddlCountry.Items.Add(this.objCountryMasterDT.Rows[0]["CountryID"].ToString());
                    this.ddlCountry.SelectedValue = this.objCountryMasterDT.Rows[0]["CountryID"].ToString();
                }
            }
            if (!string.IsNullOrEmpty(s3))
            {
                this.objStateMasterDT = this.objStateMasterBll.GetDataByStateID(int.Parse(s3));
                if (this.objStateMasterDT.Rows.Count > 0)
                {
                    this.ddlState.Items.Add(this.objStateMasterDT.Rows[0]["StateID"].ToString());
                    this.ddlState.SelectedValue = this.objStateMasterDT.Rows[0]["StateID"].ToString();
                }
            }
            if (!string.IsNullOrEmpty(s4))
            {
                this.objCityMasterDT = this.objCityMasterBll.GetDataByCityID(int.Parse(s4));
                if (this.objCityMasterDT.Rows.Count > 0)
                {
                    this.ddlCity.Items.Add(this.objCityMasterDT.Rows[0]["CityID"].ToString());
                    this.ddlCity.SelectedValue = this.objCityMasterDT.Rows[0]["CityID"].ToString();
                }
            }
            if (!string.IsNullOrEmpty(s5))
            {
                this.objCountryMasterDT = this.objCountryMasterBll.GetDataByCountryID(int.Parse(s5));
                if (this.objCountryMasterDT.Rows.Count > 0)
                {
                    this.ddlCountrySecondary.Items.Add(this.objCountryMasterDT.Rows[0]["CountryID"].ToString());
                    this.ddlCountrySecondary.SelectedValue = this.objCountryMasterDT.Rows[0]["CountryID"].ToString();
                }
            }
            if (!string.IsNullOrEmpty(s6))
            {
                this.objStateMasterDT = this.objStateMasterBll.GetDataByStateID(int.Parse(s6));
                if (this.objStateMasterDT.Rows.Count > 0)
                {
                    this.ddlStateSecondary.Items.Add(this.objStateMasterDT.Rows[0]["StateID"].ToString());
                    this.ddlStateSecondary.SelectedValue = this.objStateMasterDT.Rows[0]["StateID"].ToString();
                }
            }
            if (!string.IsNullOrEmpty(s7))
            {
                this.objCityMasterDT = this.objCityMasterBll.GetDataByCityID(int.Parse(s7));
                if (this.objCityMasterDT.Rows.Count > 0)
                {
                    this.ddlCitySecondary.Items.Add(this.objCityMasterDT.Rows[0]["CityID"].ToString());
                    this.ddlCitySecondary.SelectedValue = this.objCityMasterDT.Rows[0]["CityID"].ToString();
                }
            }
            this.objCompanyClientContactDetailDT = this.objCompanyClientContactDetailBll.GetDataByCompanyClientID(int.Parse(this.hfCompanyClientID.Value));
            if (this.objCompanyClientContactDetailDT.Rows.Count <= 0)
                return;
            this.extraContact.Visible = true;
            for (int index = 0; index < this.objCompanyClientContactDetailDT.Rows.Count; ++index)
            {
                this.AddNewClientContactRow();
                TextBox textBox1 = (TextBox)this.gvCompanyClientContact.Rows[index].Cells[0].FindControl("txtGridEmail");
                TextBox textBox2 = (TextBox)this.gvCompanyClientContact.Rows[index].Cells[1].FindControl("txtGridFirstName");
                TextBox textBox3 = (TextBox)this.gvCompanyClientContact.Rows[index].Cells[2].FindControl("txtGridLastName");
                TextBox textBox4 = (TextBox)this.gvCompanyClientContact.Rows[index].Cells[3].FindControl("txtGridPhone");
                TextBox textBox5 = (TextBox)this.gvCompanyClientContact.Rows[index].Cells[4].FindControl("txtGridMobile");
                CheckBox checkBox = (CheckBox)this.gvCompanyClientContact.Rows[index].Cells[5].FindControl("chkGridLogin");
                TextBox textBox6 = (TextBox)this.gvCompanyClientContact.Rows[index].Cells[6].FindControl("txtGridUsername");
                textBox1.Text = this.objCompanyClientContactDetailDT.Rows[index]["Email"].ToString();
                textBox2.Text = this.objCompanyClientContactDetailDT.Rows[index]["FirstName"].ToString();
                textBox3.Text = this.objCompanyClientContactDetailDT.Rows[index]["LastName"].ToString();
                textBox4.Text = this.objCompanyClientContactDetailDT.Rows[index]["HomePhone"].ToString();
                textBox5.Text = this.objCompanyClientContactDetailDT.Rows[index]["Mobile"].ToString();
                textBox6.Text = this.objCompanyClientContactDetailDT.Rows[index]["UserName"].ToString();
                checkBox.Checked = bool.Parse(this.objCompanyClientContactDetailDT.Rows[index]["LoginCredentials"].ToString());
            }
        }

        protected void gvCompanyClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Response.Redirect("~/Admin/CompanyClientMaster.aspx?cmd=add&ID=" + ((WebControl)this.gvCompanyClient.SelectedRow.Cells[0].FindControl("chkID")).ToolTip);
            this.BindGrid();
        }

        protected void gvCompanyClient_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvCompanyClient.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected override void Render(HtmlTextWriter writer)
        {
            foreach (GridViewRow gridViewRow in this.gvCompanyClient.Rows)
            {
                if (gridViewRow.RowType == DataControlRowType.DataRow)
                {
                    gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
                    if (gridViewRow.RowIndex % 2 == 0)
                        gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
                    else
                        gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
                }
            }
            base.Render(writer);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
            int count = this.objCompanyClientMasterDT.Rows.Count;
            this.objCompanyPackageMasterDT = this.objCompanyPackageMasterBll.GetDataByCompanyActivePackage(int.Parse(this.hfCompanyID.Value));
            if (this.objCompanyPackageMasterDT.Rows.Count <= 0)
                return;
            int iCloudPackageID = int.Parse(this.objCompanyPackageMasterDT.Rows[0]["CloudPackageID"].ToString());
            if (iCloudPackageID != 0)
            {
                this.objPackageFeatureMasterDT = this.objPackageFeatureMasterBll.GetDataByPackageFeatureName(1, "Number of clients you can invoice");
                if (this.objPackageFeatureMasterDT.Rows.Count <= 0)
                    return;
                int iModuleID = int.Parse(this.objPackageFeatureMasterDT.Rows[0]["PackageModuleID"].ToString());
                int iFeatureID = int.Parse(this.objPackageFeatureMasterDT.Rows[0]["PackageFeatureID"].ToString());
                this.objCloudPackageDetailsDT = this.objCloudPackageDetailsBll.GetDataByPackageModuleFeatureID(iCloudPackageID, iModuleID, iFeatureID);
                if (this.objCloudPackageDetailsDT.Rows.Count <= 0)
                    return;
                try
                {
                    int num = int.Parse(this.objCloudPackageDetailsDT.Rows[0]["CloudPackageDetailValue"].ToString());
                    if (count < num)
                        this.Response.Redirect("~/Admin/CompanyClientMaster.aspx?cmd=add");
                    else
                        this.DisplayAlert("Can not add more clients in this package. To add more clients please upgrade your package.");
                }
                catch (Exception ex1)
                {
                    try
                    {
                        if (bool.Parse(this.objCloudPackageDetailsDT.Rows[0]["CloudPackageDetailValue"].ToString()))
                            this.Response.Redirect("~/Admin/CompanyClientMaster.aspx?cmd=add");
                        else
                            this.DisplayAlert("Can not add more clients in this package. To add more clients please upgrade your package.");
                    }
                    catch (Exception ex2)
                    {
                        this.Response.Redirect("~/Admin/CompanyClientMaster.aspx?cmd=add");
                    }
                }
            }
            else
                this.Response.Redirect("~/Admin/CompanyClientMaster.aspx?cmd=add");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!this.Page.IsValid)
                return;
            if (this.txtEmail.Text.Trim().Length > 0)
            {
                int? iCurrencyID = new int?();
                int? iCountryID = new int?();
                int? iStateID = new int?();
                int? iCityID = new int?();
                int? iSecondaryCountryID = new int?();
                int? iSecondaryStateID = new int?();
                int? iSecondaryCityID = new int?();
                int? iIndustryID = new int?();
                if (this.ddlCurrency.SelectedIndex > 0)
                    iCurrencyID = new int?(int.Parse(this.ddlCurrency.SelectedItem.Value));
                if (this.ddlCountry.SelectedIndex > 0)
                    iCountryID = new int?(int.Parse(this.ddlCountry.SelectedItem.Value));
                if (this.ddlState.SelectedIndex > 0)
                    iStateID = new int?(int.Parse(this.ddlState.SelectedItem.Value));
                if (this.ddlCity.SelectedIndex > 0)
                    iCityID = new int?(int.Parse(this.ddlCity.SelectedItem.Value));
                if (this.ddlCountrySecondary.SelectedIndex > 0)
                    iSecondaryCountryID = new int?(int.Parse(this.ddlCountrySecondary.SelectedItem.Value));
                if (this.ddlStateSecondary.SelectedIndex > 0)
                    iSecondaryStateID = new int?(int.Parse(this.ddlStateSecondary.SelectedItem.Value));
                if (this.ddlCitySecondary.SelectedIndex > 0)
                    iSecondaryCityID = new int?(int.Parse(this.ddlCitySecondary.SelectedItem.Value));
                if (this.ddlIndustry.SelectedIndex > 0)
                    iIndustryID = new int?(int.Parse(this.ddlIndustry.SelectedItem.Value));
                if (this.txtUsername.Text.Trim().Length > 0 && this.txtPassword.Text.Trim().Length > 0)
                {
                    if (this.txtPassword.Text.Trim().Length <= 3)
                        this.txtPassword.Text = Doyingo.GenerateCode(8);
                    MembershipCreateStatus status;
                    Membership.CreateUser(this.txtUsername.Text.Trim(), this.txtPassword.Text.Trim(), this.txtEmail.Text, "What's Your Email?", this.txtEmail.Text, true, out status);
                    if (status == MembershipCreateStatus.Success)
                    {
                        Roles.AddUserToRole(this.txtUsername.Text.Trim(), "CompanyClient");
                    }
                    else
                    {
                        do
                        {
                            this.txtUsername.Text = Doyingo.GenerateCode(6);
                            this.txtPassword.Text = Doyingo.GenerateCode(8);
                            Membership.CreateUser(this.txtUsername.Text.Trim(), this.txtPassword.Text, this.txtEmail.Text, "What's Your Email?", this.txtEmail.Text, true, out status);
                        }
                        while (status != MembershipCreateStatus.Success);
                        Roles.AddUserToRole(this.txtUsername.Text.Trim(), "CompanyClient");
                    }
                }
                if (this.txtUsername.Text.Trim().Length == 0)
                {
                    MembershipCreateStatus status;
                    do
                    {
                        this.txtUsername.Text = Doyingo.GenerateCode(6);
                        this.txtPassword.Text = Doyingo.GenerateCode(8);
                        Membership.CreateUser(this.txtUsername.Text.Trim(), this.txtPassword.Text, this.txtEmail.Text, "What's Your Email?", this.txtEmail.Text, true, out status);
                    }
                    while (status != MembershipCreateStatus.Success);
                    Roles.AddUserToRole(this.txtUsername.Text.Trim(), "CompanyClient");
                }
                string sOrganizationName = this.txtClientName.Text.Trim();
                if (string.IsNullOrEmpty(sOrganizationName))
                    sOrganizationName = this.txtEmail.Text.Trim();
                int num = this.objCompanyClientMasterBll.AddCompanyClient(int.Parse(this.hfCompanyID.Value), sOrganizationName, iCurrencyID, this.chkEmail.Checked, this.chkSnailMail.Checked, this.txtEmail.Text, this.txtFirstName.Text.Trim(), this.txtLastName.Text.Trim(), this.txtHomePhone.Text.Trim(), this.txtMobile.Text.Trim(), this.chkAssignUsername.Checked, this.txtUsername.Text.Trim(), this.txtAddress1.Text.Trim(), this.txtAddress2.Text.Trim(), iCountryID, iStateID, iCityID, this.txtZipCode.Text.Trim(), this.txtAddress1Secondary.Text.Trim(), this.txtAddress2Secondary.Text.Trim(), iSecondaryCountryID, iSecondaryStateID, iSecondaryCityID, this.txtZipCodeSecondary.Text.Trim(), iIndustryID, this.ddlCompanySize.SelectedItem.Text, this.txtBussinessPhone.Text.Trim(), this.txtFax.Text.Trim(), this.txtInternalNote.Text.Trim(), true, false, false);
                if (num != 0)
                {
                    if (this.chkSend.Checked)
                        this.SendMailNew(num);
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
                            clientAssignDetailBll.AddStaffClientAssignDetail(int.Parse(this.hfCompanyID.Value), int.Parse(this.hfStaffID.Value), num, true);
                        }
                    }
                    this.SetClientContactRowData();
                    DataTable dataTable = this.ViewState["ClientContactTable"] as DataTable;
                    if (dataTable != null)
                    {
                        foreach (DataRow dataRow in (InternalDataCollectionBase)dataTable.Rows)
                        {
                            string str1 = dataRow.ItemArray[0] as string;
                            string str2 = dataRow.ItemArray[1] as string;
                            string str3 = dataRow.ItemArray[2] as string;
                            string str4 = dataRow.ItemArray[3] as string;
                            string str5 = dataRow.ItemArray[4] as string;
                            string str6 = dataRow.ItemArray[5] as string;
                            string str7 = dataRow.ItemArray[6] as string;
                            string str8 = dataRow.ItemArray[7] as string;
                            string str9 = str1.Replace("&nbsp;", "");
                            string sFirstName = str2.Replace("&nbsp;", "");
                            string sLastName = str3.Replace("&nbsp;", "");
                            string sHomePhone = str4.Replace("&nbsp;", "");
                            string sMobile = str5.Replace("&nbsp;", "");
                            string str10 = str7.Replace("&nbsp;", "");
                            string str11 = str8.Replace("&nbsp;", "");
                            if (str9 != null && !string.IsNullOrEmpty(str9))
                            {
                                this.objCompanyClientContactDetailDT = this.objCompanyClientContactDetailBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), str9.Trim());
                                this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), str9.Trim());
                                this.objStaffMasterDT = this.objStaffMasterBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), str9.Trim());
                                this.objContractorMasterDT = this.objContractorMasterBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), str9.Trim());
                                if (this.objCompanyClientContactDetailDT.Rows.Count <= 0 || this.objCompanyClientMasterDT.Rows.Count <= 0 || (this.objStaffMasterDT.Rows.Count <= 0 || this.objContractorMasterDT.Rows.Count <= 0))
                                {
                                    while (true)
                                    {
                                        if (str10.Trim().Length == 0)
                                            str10 = Doyingo.GenerateCode(6);
                                        if (str11.Trim().Length <= 3)
                                            str11 = Doyingo.GenerateCode(8);
                                        MembershipCreateStatus status;
                                        Membership.CreateUser(str10.Trim(), str11, str9.Trim(), "What is your email?", str9.Trim(), true, out status);
                                        if (status != MembershipCreateStatus.Success)
                                            str10 = str11 = "";
                                        else
                                            break;
                                    }
                                    if (!Roles.IsUserInRole(str10.Trim(), "CompanyClient"))
                                        Roles.AddUserToRole(str10.Trim(), "CompanyClient");
                                    if (bool.Parse(str6))
                                        this.SendMail(str10, str11, str9);
                                    this.objCompanyClientContactDetailBll.AddCompanyClientContact(int.Parse(this.hfCompanyID.Value), num, str9, sFirstName, sLastName, sHomePhone, sMobile, bool.Parse(str6), str10, bool.Parse(str6));
                                }
                            }
                        }
                    }
                    this.Session["saveClient"] = (object)1;
                    this.DisplayAlert("Details Added Successfully.");
                    this.Response.Redirect("~/Admin/CompanyClientMaster.aspx?cmd=add&ID=" + (object)num);
                }
                else
                {
                    this.DisplayAlert("Fail to Add New Details.");
                    this.Clear();
                }
            }
            else
                this.DisplayAlert("Please Fill All Details...!");
        }

        private void SendMail(string user, string pass, string email)
        {
            this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
            string str = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
            string addresses = this.objCompanyMasterDT.Rows[0]["CompanyEmail"].ToString();
            Hashtable Variables = new Hashtable()
      {
        {
          (object) "company",
          (object) str
        },
        {
          (object) "companyEmail",
          (object) addresses
        },
        {
          (object) "username",
          (object) user
        },
        {
          (object) "password",
          (object) pass
        }
      };
            //string address = "noreply@DoyniGo.com";
            //this.objSMTPSettingsDT = this.objSMTPSettingsBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
            //if (this.objSMTPSettingsDT.Rows.Count > 0)
              //  address = this.objSMTPSettingsDT.Rows[0]["SMTPFrom"].ToString();
            Parser parser = new Parser(this.Server.MapPath("~/MailTemplate/CompanyClient.htm"), Variables);
            try
            {
                //MailMessage message = new MailMessage()
                //{
                //    From = new MailAddress(address, str.ToUpper())
                //};
                //message.To.Add(new MailAddress(email));
                //message.ReplyToList.Add(addresses);
                //message.Subject = str.ToUpper() + " is now invoicing you with Bill Transact";
                //message.BodyEncoding = Encoding.UTF8;
                //message.Body = parser.Parse();
                //message.IsBodyHtml = true;
                //new SmtpClient().Send(message);
            }
            catch (Exception ex)
            {
                this.DisplayAlert("Error in sending mail." + (object)ex);
            }
        }

        private void SendMailNew(int clientID)
        {
            this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
            string str1 = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
            string addresses = this.objCompanyMasterDT.Rows[0]["CompanyEmail"].ToString();
            this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(clientID);
            string username = this.objCompanyClientMasterDT.Rows[0]["UserName"].ToString();
            string str2 = this.objCompanyClientMasterDT.Rows[0]["OrganizationName"].ToString();
            string str3 = this.objCompanyClientMasterDT.Rows[0]["FirstName"].ToString();
            string str4 = this.objCompanyClientMasterDT.Rows[0]["LastName"].ToString();
            string address1 = this.objCompanyClientMasterDT.Rows[0]["Email"].ToString();
            string str5 = string.Empty;
            MembershipUser user = Membership.GetUser(username);
            if (user != null)
                str5 = user.GetPassword();
            string str6 = string.Empty;
            string str7 = string.Empty;
            string address2 = "noreply@DoyniGo.com";
            this.objSMTPSettingsDT = this.objSMTPSettingsBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
            if (this.objSMTPSettingsDT.Rows.Count > 0)
            {
                str7 = this.objSMTPSettingsDT.Rows[0]["EmailSignature"].ToString();
                address2 = this.objSMTPSettingsDT.Rows[0]["SMTPFrom"].ToString();
            }
            this.objNewClientEmailTemplateDT = this.objNewClientEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
            if (this.objNewClientEmailTemplateDT.Rows.Count > 0)
                str6 = this.objNewClientEmailTemplateDT.Rows[0]["EmailBody"].ToString();
            Hashtable Variables = new Hashtable()
      {
        {
          (object) "company",
          (object) str1
        },
        {
          (object) "companyName",
          (object) str1
        },
        {
          (object) "companyEmail",
          (object) ("<a href=\"mailto:" + addresses + "\">" + addresses + "</a>")
        },
        {
          (object) "username",
          (object) username
        },
        {
          (object) "password",
          (object) str5
        },
        {
          (object) "emailTemplate",
          (object) str6
        },
        {
          (object) "emailSign",
          (object) str7
        },
        {
          (object) "clientOrgName",
          (object) str2
        },
        {
          (object) "firstName",
          (object) str3
        },
        {
          (object) "lastName",
          (object) str4
        },
        {
          (object) "loginLink",
          (object) "<a target=\"_blank\" href=\"http://www.billtransact.com/MemberArea.aspx\">https://www.billtransact.com/MemberArea.aspx</a>"
        }
      };
            Parser parser1 = new Parser(this.Server.MapPath("~/MailTemplate/CompanyClientNew.htm"), Variables);
            string path1 = this.Server.MapPath("~\\TempHTMLFiles\\");
            File.WriteAllText(Path.Combine(path1, "Client.html"), parser1.Parse());
            Parser parser2 = new Parser(path1 + "Client.html", Variables);
            try
            {
                //MailMessage message = new MailMessage()
                //{
                //    From = new MailAddress(address2, str1.ToUpper())
                //};
                //message.To.Add(new MailAddress(address1));
                //message.ReplyToList.Add(addresses);
                //message.Subject = str1.ToUpper() + " is now invoicing you with Bill Transact";
                //message.BodyEncoding = Encoding.UTF8;
                //message.Body = parser2.Parse();
                //message.IsBodyHtml = true;
                //SmtpClientForCompany.smtpClient(this.hfCompanyID.Value).Send(message);
                Common.CommonHandler.SendSMTPEmail(hfCompanyID.Value, address1, str1.ToUpper() + " is now invoicing you with Bill Transact", parser2.Parse(), true);
                //await Common.CommonHandler.SendMail(hfCompanyID.Value, address1, str1.ToUpper() + " is now invoicing you with Bill Transact", parser2.Parse(), true);
                File.Delete(Path.Combine(path1, "Client.html"));
            }
            catch (Exception ex)
            {
                this.DisplayAlert("Error in sending mail." + (object)ex);
            }
        }

        protected  void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.IsValid)
                    return;
                if (this.txtEmail.Text.Trim().Length > 0 && this.txtClientName.Text.Trim().Length > 0)
                {
                    int? iCurrencyID = new int?();
                    int? iCountryID = new int?();
                    int? iStateID = new int?();
                    int? iCityID = new int?();
                    int? iSecondaryCountryID = new int?();
                    int? iSecondaryStateID = new int?();
                    int? iSecondaryCityID = new int?();
                    int? iIndustryID = new int?();
                    if (this.ddlCurrency.SelectedIndex > 0)
                        iCurrencyID = new int?(int.Parse(this.ddlCurrency.SelectedItem.Value));
                    if (this.ddlCountry.SelectedIndex > 0)
                        iCountryID = new int?(int.Parse(this.ddlCountry.SelectedItem.Value));
                    if (this.ddlState.SelectedIndex > 0)
                        iStateID = new int?(int.Parse(this.ddlState.SelectedItem.Value));
                    if (this.ddlCity.SelectedIndex > 0)
                        iCityID = new int?(int.Parse(this.ddlCity.SelectedItem.Value));
                    if (this.ddlCountrySecondary.SelectedIndex > 0)
                        iSecondaryCountryID = new int?(int.Parse(this.ddlCountrySecondary.SelectedItem.Value));
                    if (this.ddlStateSecondary.SelectedIndex > 0)
                        iSecondaryStateID = new int?(int.Parse(this.ddlStateSecondary.SelectedItem.Value));
                    if (this.ddlCitySecondary.SelectedIndex > 0)
                        iSecondaryCityID = new int?(int.Parse(this.ddlCitySecondary.SelectedItem.Value));
                    if (this.ddlIndustry.SelectedIndex > 0)
                        iIndustryID = new int?(int.Parse(this.ddlIndustry.SelectedItem.Value));
                    if (this.txtPassword.Text.Trim().Length > 4)
                    {
                        if (this.txtPassword.Text.Trim() == this.txtConfPassword.Text.Trim())
                        {
                            MembershipUser user = Membership.GetUser(this.txtUsername.Text);
                            if (user != null)
                            {
                                user.ChangePassword(this.lblPasswordAdd.Text.Trim(), this.txtPassword.Text.Trim());
                                this.lblPasswordAdd.Text = this.txtPassword.Text.Trim();
                                Membership.UpdateUser(user);
                            }
                        }
                        else
                            this.DisplayAlert("Password & confirm password not match");
                    }
                    if (this.objCompanyClientMasterBll.UpdateCompanyClient(int.Parse(this.hfCompanyClientID.Value), int.Parse(this.hfCompanyID.Value), this.txtClientName.Text.Trim(), iCurrencyID, this.chkEmail.Checked, this.chkSnailMail.Checked, this.txtEmail.Text, this.txtFirstName.Text.Trim(), this.txtLastName.Text.Trim(), this.txtHomePhone.Text.Trim(), this.txtMobile.Text.Trim(), this.chkAssignUsername.Checked, this.txtUsername.Text.Trim(), this.txtAddress1.Text.Trim(), this.txtAddress2.Text.Trim(), iCountryID, iStateID, iCityID, this.txtZipCode.Text.Trim(), this.txtAddress1Secondary.Text.Trim(), this.txtAddress2Secondary.Text.Trim(), iSecondaryCountryID, iSecondaryStateID, iSecondaryCityID, this.txtZipCodeSecondary.Text.Trim(), iIndustryID, this.ddlCompanySize.SelectedItem.Text, this.txtBussinessPhone.Text.Trim(), this.txtFax.Text.Trim(), this.txtInternalNote.Text.Trim(), true, false, false))
                    {
                        if (this.chkSend.Checked)
                            this.SendMailNew(int.Parse(this.hfCompanyClientID.Value));
                        this.objCompanyClientContactDetailDT = this.objCompanyClientContactDetailBll.GetDataByCompanyClientID(int.Parse(this.hfCompanyClientID.Value));
                        if (this.objCompanyClientContactDetailDT.Rows.Count > 0)
                        {
                            for (int index = 0; index < this.objCompanyClientContactDetailDT.Rows.Count; ++index)
                                Membership.DeleteUser(this.objCompanyClientContactDetailDT.Rows[index]["UserName"].ToString());
                            this.objCompanyClientContactDetailBll.DeleteByCompanyClient(int.Parse(this.hfCompanyClientID.Value));
                        }
                        this.SetClientContactRowData();
                        DataTable dataTable = this.ViewState["ClientContactTable"] as DataTable;
                        if (dataTable != null)
                        {
                            foreach (DataRow dataRow in (InternalDataCollectionBase)dataTable.Rows)
                            {
                                string str1 = dataRow.ItemArray[0] as string;
                                string str2 = dataRow.ItemArray[1] as string;
                                string str3 = dataRow.ItemArray[2] as string;
                                string str4 = dataRow.ItemArray[3] as string;
                                string str5 = dataRow.ItemArray[4] as string;
                                string str6 = dataRow.ItemArray[5] as string;
                                string str7 = dataRow.ItemArray[6] as string;
                                string str8 = dataRow.ItemArray[7] as string;
                                string str9 = str1.Replace("&nbsp;", "");
                                string sFirstName = str2.Replace("&nbsp;", "");
                                string sLastName = str3.Replace("&nbsp;", "");
                                string sHomePhone = str4.Replace("&nbsp;", "");
                                string sMobile = str5.Replace("&nbsp;", "");
                                string str10 = str7.Replace("&nbsp;", "");
                                string str11 = str8.Replace("&nbsp;", "");
                                if (str9 != null && !string.IsNullOrEmpty(str9))
                                {
                                    this.objCompanyClientContactDetailDT = this.objCompanyClientContactDetailBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), str9.Trim());
                                    this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), str9.Trim());
                                    this.objStaffMasterDT = this.objStaffMasterBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), str9.Trim());
                                    this.objContractorMasterDT = this.objContractorMasterBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), str9.Trim());
                                    if (this.objCompanyClientContactDetailDT.Rows.Count <= 0 || this.objCompanyClientMasterDT.Rows.Count <= 0 || (this.objStaffMasterDT.Rows.Count <= 0 || this.objContractorMasterDT.Rows.Count <= 0))
                                    {
                                        while (true)
                                        {
                                            if (str10.Trim().Length == 0)
                                                str10 = Doyingo.GenerateCode(6);
                                            if (str11.Trim().Length <= 3)
                                                str11 = Doyingo.GenerateCode(8);
                                            MembershipCreateStatus status;
                                            Membership.CreateUser(str10.Trim(), str11, str9.Trim(), "What is your email?", str9.Trim(), true, out status);
                                            if (status != MembershipCreateStatus.Success)
                                                str10 = str11 = "";
                                            else
                                                break;
                                        }
                                        if (!Roles.IsUserInRole(str10.Trim(), "CompanyClient"))
                                            Roles.AddUserToRole(str10.Trim(), "CompanyClient");
                                        if (bool.Parse(str6))
                                            this.SendMail(str10, str11, str9);
                                        this.objCompanyClientContactDetailBll.AddCompanyClientContact(int.Parse(this.hfCompanyID.Value), int.Parse(this.hfCompanyClientID.Value), str9, sFirstName, sLastName, sHomePhone, sMobile, bool.Parse(str6), str10, bool.Parse(str6));
                                    }
                                }
                            }
                        }
                        this.Session["updateClient"] = (object)1;
                        this.DisplayAlert("Update Successfully..");
                        this.Response.Redirect("~/Admin/CompanyClientMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
                    }
                    else
                        this.DisplayAlert("Fail to Update Details.");
                }
                else
                    this.DisplayAlert("Please Fill All Details.");
            }
            catch (Exception ex)
            {
                this.DisplayAlert(ex.Message);
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
            for (int index = 0; index < this.gvCompanyClient.Rows.Count; ++index)
            {
                CheckBox checkBox = (CheckBox)this.gvCompanyClient.Rows[index].Cells[0].FindControl("chkID");
                if (checkBox.Checked)
                {
                    ++num;
                    this.objCompanyClientMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), false, false, true);
                }
            }
            if (num == 0)
                this.DisplayAlert("No items were selected.");
            else
                this.Response.Redirect("CompanyClientMaster.aspx");
        }

        protected  void btnEmail_Click(object sender, EventArgs e)
        {
            int num = 0;
            for (int index = 0; index < this.gvCompanyClient.Rows.Count; ++index)
            {
                CheckBox checkBox = (CheckBox)this.gvCompanyClient.Rows[index].Cells[0].FindControl("chkID");
                if (checkBox.Checked)
                {
                    ++num;
                    this.SendMailNew(int.Parse(checkBox.ToolTip));
                }
            }
            if (num == 0)
                this.DisplayAlert("No items were selected.");
            else
                this.Response.Redirect("CompanyClientMaster.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int num = 0;
            for (int index = 0; index < this.gvCompanyClient.Rows.Count; ++index)
            {
                CheckBox checkBox = (CheckBox)this.gvCompanyClient.Rows[index].Cells[0].FindControl("chkID");
                if (checkBox.Checked)
                {
                    ++num;
                    this.objCompanyClientMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), false, true, false);
                }
            }
            if (num == 0)
                this.DisplayAlert("No items were selected.");
            else
                this.Response.Redirect("CompanyClientMaster.aspx?de=true&ac=false");
        }

        protected void btnUnArchived_Click(object sender, EventArgs e)
        {
            int num = 0;
            for (int index = 0; index < this.gvCompanyClient.Rows.Count; ++index)
            {
                CheckBox checkBox = (CheckBox)this.gvCompanyClient.Rows[index].Cells[0].FindControl("chkID");
                if (checkBox.Checked)
                {
                    ++num;
                    this.objCompanyClientMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), true, false, false);
                }
            }
            if (num == 0)
                this.DisplayAlert("No items were selected.");
            else
                this.Response.Redirect("CompanyClientMaster.aspx?ar=true&ac=false");
        }

        protected void btnUnDelete_Click(object sender, EventArgs e)
        {
            int num = 0;
            for (int index = 0; index < this.gvCompanyClient.Rows.Count; ++index)
            {
                CheckBox checkBox = (CheckBox)this.gvCompanyClient.Rows[index].Cells[0].FindControl("chkID");
                if (checkBox.Checked)
                {
                    ++num;
                    this.objCompanyClientMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), true, false, false);
                }
            }
            if (num == 0)
                this.DisplayAlert("No items were selected.");
            else
                this.Response.Redirect("CompanyClientMaster.aspx?de=true&ac=false");
        }

        public bool CheckARQuery()
        {
            return this.Request.QueryString["ar"] != null && bool.Parse(this.Request.QueryString["ar"]);
        }

        public bool CheckDEQuery()
        {
            return this.Request.QueryString["de"] != null && bool.Parse(this.Request.QueryString["de"]);
        }

        protected void lnkEdit_OnClick(object sender, EventArgs e)
        {
            this.Response.Redirect("~/Admin/CompanyClientMaster.aspx?cmd=add&ID=" + ((LinkButton)sender).CommandArgument);
        }

        protected void txtUsername_OnTextChanged(object sender, EventArgs e)
        {
            this.objUserDT = this.objUserBll.GetAllDetail(this.txtUsername.Text.Trim());
            if (this.objUserDT.Rows.Count > 0)
            {
                this.DisplayAlert("User Name Already Register With System.");
                ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('User Name Already Register With System.')", true);
                this.txtUsername.Text = "";
                this.txtUsername.Focus();
            }
            else
                this.txtPassword.Focus();
        }

        protected void txtEmail_OnTextChanged(object sender, EventArgs e)
        {
            this.objCompanyClientContactDetailDT = this.objCompanyClientContactDetailBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), this.txtEmail.Text.Trim());
            this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), this.txtEmail.Text.Trim());
            this.objStaffMasterDT = this.objStaffMasterBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), this.txtEmail.Text.Trim());
            this.objContractorMasterDT = this.objContractorMasterBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), this.txtEmail.Text.Trim());
            this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyEmail(this.txtEmail.Text.Trim());
            if (this.objCompanyMasterDT.Rows.Count > 0)
            {
                if (!(this.hfCompanyID.Value == this.objCompanyMasterDT.Rows[0]["CompanyID"].ToString()))
                    return;
                ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Can not Register Yourself As Client.')", true);
                this.txtEmail.Text = "";
                this.txtEmail.Focus();
            }
            else if (this.objCompanyClientMasterDT.Rows.Count > 0 || this.objCompanyClientContactDetailDT.Rows.Count > 0)
            {
                ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Email Already Register With System To Some Client.')", true);
                this.txtEmail.Text = "";
                this.txtEmail.Focus();
            }
            else if (this.objStaffMasterDT.Rows.Count > 0)
            {
                ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Email Already Register With System To Some Staff.')", true);
                this.txtEmail.Text = "";
                this.txtEmail.Focus();
            }
            else if (this.objContractorMasterDT.Rows.Count > 0)
            {
                ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Email Already Register With System To Some Contractor.')", true);
                this.txtEmail.Text = "";
                this.txtEmail.Focus();
            }
            else
                this.txtFirstName.Focus();
        }

        protected void lnkAddContact_Click(object sender, EventArgs e)
        {
            this.extraContact.Visible = true;
        }

        protected void chkGridLogin_OnCheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            GridViewRow gridViewRow = (GridViewRow)checkBox.Parent.Parent;
            TextBox textBox1 = (TextBox)gridViewRow.Cells[6].FindControl("txtGridUsername");
            TextBox textBox2 = (TextBox)gridViewRow.Cells[7].FindControl("txtGridPassword");
            textBox1.Enabled = textBox2.Enabled = checkBox.Checked;
            if (!checkBox.Checked)
                return;
            textBox1.Focus();
        }

        protected void btnAddGridRow_Click(object sender, EventArgs e)
        {
            this.AddNewClientContactRow();
        }

        private void FirstGridRow()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("Colum1", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Colum2", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Colum3", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Colum4", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Colum5", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Colum6", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Colum7", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Colum8", typeof(string)));
            DataRow row = dataTable.NewRow();
            row["Colum1"] = (object)string.Empty;
            row["Colum2"] = (object)string.Empty;
            row["Colum3"] = (object)string.Empty;
            row["Colum4"] = (object)string.Empty;
            row["Colum5"] = (object)string.Empty;
            row["Colum6"] = (object)string.Empty;
            row["Colum7"] = (object)string.Empty;
            row["Colum8"] = (object)string.Empty;
            dataTable.Rows.Add(row);
            this.ViewState["ClientContactTable"] = (object)dataTable;
            this.gvCompanyClientContact.DataSource = (object)dataTable;
            this.gvCompanyClientContact.DataBind();
        }

        private void AddNewClientContactRow()
        {
            int index1 = 0;
            if (this.ViewState["ClientContactTable"] != null)
            {
                DataTable dataTable = (DataTable)this.ViewState["ClientContactTable"];
                DataRow row = (DataRow)null;
                if (dataTable.Rows.Count > 0)
                {
                    for (int index2 = 1; index2 <= dataTable.Rows.Count; ++index2)
                    {
                        TextBox textBox1 = (TextBox)this.gvCompanyClientContact.Rows[index1].Cells[0].FindControl("txtGridEmail");
                        TextBox textBox2 = (TextBox)this.gvCompanyClientContact.Rows[index1].Cells[1].FindControl("txtGridFirstName");
                        TextBox textBox3 = (TextBox)this.gvCompanyClientContact.Rows[index1].Cells[2].FindControl("txtGridLastName");
                        TextBox textBox4 = (TextBox)this.gvCompanyClientContact.Rows[index1].Cells[3].FindControl("txtGridPhone");
                        TextBox textBox5 = (TextBox)this.gvCompanyClientContact.Rows[index1].Cells[4].FindControl("txtGridMobile");
                        CheckBox checkBox = (CheckBox)this.gvCompanyClientContact.Rows[index1].Cells[5].FindControl("chkGridLogin");
                        TextBox textBox6 = (TextBox)this.gvCompanyClientContact.Rows[index1].Cells[6].FindControl("txtGridUsername");
                        TextBox textBox7 = (TextBox)this.gvCompanyClientContact.Rows[index1].Cells[7].FindControl("txtGridPassword");
                        row = dataTable.NewRow();
                        dataTable.Rows[index2 - 1]["Colum1"] = (object)textBox1.Text;
                        dataTable.Rows[index2 - 1]["Colum2"] = (object)textBox2.Text;
                        dataTable.Rows[index2 - 1]["Colum3"] = (object)textBox3.Text;
                        dataTable.Rows[index2 - 1]["Colum4"] = (object)textBox4.Text;
                        dataTable.Rows[index2 - 1]["Colum5"] = (object)textBox5.Text;
                        dataTable.Rows[index2 - 1]["Colum6"] = (object)((bool)(checkBox.Checked) ? 1 : 0);
                        dataTable.Rows[index2 - 1]["Colum7"] = (object)textBox6.Text;
                        dataTable.Rows[index2 - 1]["Colum8"] = (object)textBox7.Text;
                        ++index1;
                    }
                    if (row != null)
                        dataTable.Rows.Add(row);
                    this.ViewState["ClientContactTable"] = (object)dataTable;
                    this.gvCompanyClientContact.DataSource = (object)dataTable;
                    this.gvCompanyClientContact.DataBind();
                    this.gvCompanyClientContact.Rows[index1].Cells[0].FindControl("txtGridEmail").Focus();
                }
            }
            else
                this.Response.Write("ViewState is null");
            this.SetPreviousClientContactData();
        }

        private void SetPreviousClientContactData()
        {
            int index1 = 0;
            if (this.ViewState["ClientContactTable"] == null)
                return;
            DataTable dataTable = (DataTable)this.ViewState["ClientContactTable"];
            if (dataTable.Rows.Count <= 0)
                return;
            for (int index2 = 0; index2 < dataTable.Rows.Count; ++index2)
            {
                TextBox textBox1 = (TextBox)this.gvCompanyClientContact.Rows[index1].Cells[0].FindControl("txtGridEmail");
                TextBox textBox2 = (TextBox)this.gvCompanyClientContact.Rows[index1].Cells[1].FindControl("txtGridFirstName");
                TextBox textBox3 = (TextBox)this.gvCompanyClientContact.Rows[index1].Cells[2].FindControl("txtGridLastName");
                TextBox textBox4 = (TextBox)this.gvCompanyClientContact.Rows[index1].Cells[3].FindControl("txtGridPhone");
                TextBox textBox5 = (TextBox)this.gvCompanyClientContact.Rows[index1].Cells[4].FindControl("txtGridMobile");
                CheckBox checkBox = (CheckBox)this.gvCompanyClientContact.Rows[index1].Cells[5].FindControl("chkGridLogin");
                TextBox textBox6 = (TextBox)this.gvCompanyClientContact.Rows[index1].Cells[6].FindControl("txtGridUsername");
                TextBox textBox7 = (TextBox)this.gvCompanyClientContact.Rows[index1].Cells[7].FindControl("txtGridPassword");
                textBox1.Text = dataTable.Rows[index2]["Colum1"].ToString();
                textBox2.Text = dataTable.Rows[index2]["Colum2"].ToString();
                textBox3.Text = dataTable.Rows[index2]["Colum3"].ToString();
                textBox4.Text = dataTable.Rows[index2]["Colum4"].ToString();
                textBox5.Text = dataTable.Rows[index2]["Colum5"].ToString();
                checkBox.Checked = !string.IsNullOrEmpty(dataTable.Rows[index2]["Colum6"].ToString()) && bool.Parse(dataTable.Rows[index2]["Colum6"].ToString());
                textBox6.Text = dataTable.Rows[index2]["Colum7"].ToString();
                textBox7.Text = dataTable.Rows[index2]["Colum8"].ToString();
                ++index1;
            }
        }

        private void SetClientContactRowData()
        {
            int index1 = 0;
            if (this.ViewState["ClientContactTable"] != null)
            {
                DataTable dataTable = (DataTable)this.ViewState["ClientContactTable"];
                if (dataTable.Rows.Count <= 0)
                    return;
                for (int index2 = 1; index2 <= dataTable.Rows.Count; ++index2)
                {
                    TextBox textBox1 = (TextBox)this.gvCompanyClientContact.Rows[index1].Cells[0].FindControl("txtGridEmail");
                    TextBox textBox2 = (TextBox)this.gvCompanyClientContact.Rows[index1].Cells[1].FindControl("txtGridFirstName");
                    TextBox textBox3 = (TextBox)this.gvCompanyClientContact.Rows[index1].Cells[2].FindControl("txtGridLastName");
                    TextBox textBox4 = (TextBox)this.gvCompanyClientContact.Rows[index1].Cells[3].FindControl("txtGridPhone");
                    TextBox textBox5 = (TextBox)this.gvCompanyClientContact.Rows[index1].Cells[4].FindControl("txtGridMobile");
                    CheckBox checkBox = (CheckBox)this.gvCompanyClientContact.Rows[index1].Cells[5].FindControl("chkGridLogin");
                    TextBox textBox6 = (TextBox)this.gvCompanyClientContact.Rows[index1].Cells[6].FindControl("txtGridUsername");
                    TextBox textBox7 = (TextBox)this.gvCompanyClientContact.Rows[index1].Cells[7].FindControl("txtGridPassword");
                    dataTable.Rows[index2 - 1]["Colum1"] = (object)textBox1.Text;
                    dataTable.Rows[index2 - 1]["Colum2"] = (object)textBox2.Text;
                    dataTable.Rows[index2 - 1]["Colum3"] = (object)textBox3.Text;
                    dataTable.Rows[index2 - 1]["Colum4"] = (object)textBox4.Text;
                    dataTable.Rows[index2 - 1]["Colum5"] = (object)textBox5.Text;
                    dataTable.Rows[index2 - 1]["Colum6"] = (object)((bool)(checkBox.Checked) ? 1 : 0);
                    dataTable.Rows[index2 - 1]["Colum7"] = (object)textBox6.Text;
                    dataTable.Rows[index2 - 1]["Colum8"] = (object)textBox7.Text;
                    ++index1;
                }
                this.ViewState["ClientContactTable"] = (object)dataTable;
            }
            else
                this.Response.Write("ViewState is null");
        }

        protected void gvCompanyClientContact_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            this.SetClientContactRowData();
            if (this.ViewState["ClientContactTable"] == null)
                return;
            DataTable dataTable = (DataTable)this.ViewState["ClientContactTable"];
            int index = Convert.ToInt32(e.RowIndex);
            if (dataTable.Rows.Count <= 1)
                return;
            dataTable.Rows.Remove(dataTable.Rows[index]);
            dataTable.NewRow();
            this.ViewState["ClientContactTable"] = (object)dataTable;
            this.gvCompanyClientContact.DataSource = (object)dataTable;
            this.gvCompanyClientContact.DataBind();
            this.SetPreviousClientContactData();
        }

        protected void txtGridEmail_OnTextChanged(object sender, EventArgs e)
        {
            TextBox textBox1 = (TextBox)sender;
            TextBox textBox2 = (TextBox)((TableRow)textBox1.Parent.Parent).Cells[1].FindControl("txtGridFirstName");
            this.objCompanyClientContactDetailDT = this.objCompanyClientContactDetailBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), textBox1.Text.Trim());
            this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), textBox1.Text.Trim());
            this.objStaffMasterDT = this.objStaffMasterBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), textBox1.Text.Trim());
            this.objContractorMasterDT = this.objContractorMasterBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), textBox1.Text.Trim());
            this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyEmail(textBox1.Text.Trim());
            if (this.objCompanyMasterDT.Rows.Count > 0)
            {
                this.DisplayAlert("Email Already Register With System.");
                ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Email Already Register With System.')", true);
                textBox1.Text = "";
                textBox1.Focus();
            }
            else if (this.objCompanyClientMasterDT.Rows.Count > 0 || this.objCompanyClientContactDetailDT.Rows.Count > 0)
            {
                this.DisplayAlert("Email Already Register With System To Some Client.");
                ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Email Already Register With System To Some Client.')", true);
                textBox1.Text = "";
                textBox1.Focus();
            }
            else if (this.objStaffMasterDT.Rows.Count > 0)
            {
                this.DisplayAlert("Email Already Register With System To Some Staff.");
                ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Email Already Register With System To Some Staff.')", true);
                textBox1.Text = "";
                textBox1.Focus();
            }
            else if (this.objContractorMasterDT.Rows.Count > 0)
            {
                this.DisplayAlert("Email Already Register With System To Some Contractor.");
                ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Email Already Register With System To Some Contractor.')", true);
                textBox1.Text = "";
                textBox1.Focus();
            }
            else
                textBox2.Focus();
        }

        protected void txtGridUsername_OnTextChanged(object sender, EventArgs e)
        {
            TextBox textBox1 = (TextBox)sender;
            TextBox textBox2 = (TextBox)((TableRow)textBox1.Parent.Parent).Cells[7].FindControl("txtGridPassword");
            this.objUserDT = this.objUserBll.GetAllDetail(textBox1.Text.Trim());
            if (this.objUserDT.Rows.Count > 0)
            {
                this.DisplayAlert("User Name Already Register With System.");
                ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('User Name Already Register With System.')", true);
                textBox1.Text = "";
                textBox1.Focus();
            }
            else
                textBox2.Focus();
        }

        protected void chkAssignUsername_OnCheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAssignUsername.Checked)
            {
                this.usernameDiv.Visible = true;
                this.txtUsername.Focus();
            }
            else
            {
                this.usernameDiv.Visible = false;
                this.chkAssignUsername.Focus();
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("CompanyClientMaster.aspx?cmd=add&ID=" + this.hfCompanyClientID.Value);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }
    }
}

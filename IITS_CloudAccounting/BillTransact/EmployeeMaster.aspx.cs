// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.EmployeeMaster
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Collections;
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
    public class EmployeeMaster : Page
    {
        private readonly UserBLL objUserBll = new UserBLL();
        private CloudAccountDA.aspnet_UsersDataTable objUserDT = new CloudAccountDA.aspnet_UsersDataTable();
        private readonly CityMasterBLL objCityMasterBll = new CityMasterBLL();
        private CloudAccountDA.CityMasterDataTable objCityMasterDT = new CloudAccountDA.CityMasterDataTable();
        private readonly CountryMasterBLL objCountryMasterBll = new CountryMasterBLL();
        private CloudAccountDA.CountryMasterDataTable objCountryMasterDT = new CloudAccountDA.CountryMasterDataTable();
        private readonly StateMasterBLL objStateMasterBll = new StateMasterBLL();
        private CloudAccountDA.StateMasterDataTable objStateMasterDT = new CloudAccountDA.StateMasterDataTable();
        private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
        private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
        private readonly ContractorMasterBLL objContractorMasterBll = new ContractorMasterBLL();
        private CloudAccountDA.ContractorMasterDataTable objContractorMasterDT = new CloudAccountDA.ContractorMasterDataTable();
        private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
        private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
        private readonly StaffProjectDetailBLL objStaffProjectDetailBll = new StaffProjectDetailBLL();
        private CloudAccountDA.StaffProjectDetailDataTable objStaffProjectDetailDT = new CloudAccountDA.StaffProjectDetailDataTable();
        private readonly CompanyClientMasterBLL objCompanyClientMasterBll = new CompanyClientMasterBLL();
        private CloudAccountDA.CompanyClientMasterDataTable objCompanyClientMasterDT = new CloudAccountDA.CompanyClientMasterDataTable();
        private readonly CompanyClientContactDetailBLL objCompanyClientContactDetailBll = new CompanyClientContactDetailBLL();
        private CloudAccountDA.CompanyClientContactDetailDataTable objCompanyClientContactDetailDT = new CloudAccountDA.CompanyClientContactDetailDataTable();
        private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
        private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
        private readonly MiscellaneousMasterBLL objMiscellaneousMasterBll = new MiscellaneousMasterBLL();
        private CloudAccountDA.MiscellaneousMasterDataTable objMiscellaneousMasterDT = new CloudAccountDA.MiscellaneousMasterDataTable();
        private int linePerPage = 15;
        private string dateFormat = "MM/dd/yyyy";
        private readonly PackageFeatureMasterBLL objPackageFeatureMasterBll = new PackageFeatureMasterBLL();
        private CloudAccountDA.PackageFeatureMasterDataTable objPackageFeatureMasterDT = new CloudAccountDA.PackageFeatureMasterDataTable();
        private readonly CompanyPackageMasterBLL objCompanyPackageMasterBll = new CompanyPackageMasterBLL();
        private CloudAccountDA.CompanyPackageMasterDataTable objCompanyPackageMasterDT = new CloudAccountDA.CompanyPackageMasterDataTable();
        private readonly CloudPackageDetailsBLL objCloudPackageDetailsBll = new CloudPackageDetailsBLL();
        private CloudAccountDA.CloudPackageDetailsDataTable objCloudPackageDetailsDT = new CloudAccountDA.CloudPackageDetailsDataTable();
        private readonly NewStaffEmailTemplateBLL objNewStaffEmailTemplateBll = new NewStaffEmailTemplateBLL();
        private CloudAccountDA.NewStaffEmailTemplateDataTable objNewStaffEmailTemplateDT = new CloudAccountDA.NewStaffEmailTemplateDataTable();
        private readonly SMTPSettingsBLL objSMTPSettingsBll = new SMTPSettingsBLL();
        private CloudAccountDA.SMTPSettingsDataTable objSMTPSettingsDT = new CloudAccountDA.SMTPSettingsDataTable();
        protected ToolkitScriptManager tsm;
        protected HtmlGenericControl divSave;
        protected HtmlGenericControl divUpdate;
        protected Panel pnlAdd;
        protected UpdatePanel upStaff;
        protected TextBox txtStaffEmail;
        protected RequiredFieldValidator rfvStaffEmail;
        protected RegularExpressionValidator revEmail;
        protected TextBox txtStaffFirstName;
        protected RequiredFieldValidator rfvStaffFirstName;
        protected TextBox txtStaffLastName;
        protected RequiredFieldValidator rfvStaffLastName;
        protected TextBox txtBillingRate;
        protected LinkButton lnkshowAUser;
        protected HtmlGenericControl usernameDiv;
        protected RequiredFieldValidator rfvUsername;
        protected TextBox txtUsername;
        protected Label lblUsernameAdd;
        protected Label lblPasswordAdd;
        protected TextBox txtPassword;
        protected RequiredFieldValidator rfvPassword;
        protected TextBox txtConfPassword;
        protected RequiredFieldValidator rfvConfPassword;
        protected CompareValidator cvPassword;
        protected CheckBox chkEmail;
        protected LinkButton lnkshowAAddress;
        protected HtmlGenericControl contactAddress;
        protected TextBox txtHomePhone;
        protected TextBox txtMobile;
        protected TextBox txtBussinessPhone;
        protected TextBox txtFax;
        protected DropDownList ddlCountry;
        protected TextBox txtAddress1;
        protected TextBox txtAddress2;
        protected DropDownList ddlState;
        protected DropDownList ddlCity;
        protected TextBox txtZipCode;
        protected TextBox txtNotes;
        protected HtmlGenericControl projectsDiv;
        protected CheckBoxList chkProjects;
        protected SqlDataSource sqldsProjects;
        protected Button btnSubmit;
        protected Button btnUpdate;
        protected Panel pnlView;
        protected Label lblStaffFirstName;
        protected Label lblStaffLastName;
        protected Button btnEdit;
        protected Label lblStaffFirstName1;
        protected Label lblStaffLastName1;
        protected Label lblUsername;
        protected Label lblStaffEmail;
        protected Label lblBussinessPhone;
        protected Label lblMobile;
        protected Label lblHomePhone;
        protected Label lblFax;
        protected Label lblAddress1;
        protected Label lblAddress2;
        protected Label lblCity;
        protected Label lblState;
        protected Label lblZipCode;
        protected Label lblCountry;
        protected Label lblBillingRate;
        protected Label lblNotes;
        protected Panel pnlViewNo;
        protected Label lblPassword;
        protected Label lblConfPassword;
        protected Panel pnlViewAll;
        protected Label lblHeader;
        protected Button btnAdd;
        protected TextBox txtNameSearch;
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
        protected GridView gvStaff;
        protected HtmlAnchor activeTag;
        protected HtmlAnchor archivedTag;
        protected HtmlAnchor deletedTag;
        protected ObjectDataSource objdsStaff;
        protected HiddenField hfCompanyID;
        protected HiddenField hfStaffID;
        protected SqlDataSource sqldsCountry;
        protected SqlDataSource sqldsState;
        protected SqlDataSource sqldsCity;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Master == null)
                return;
            ((HtmlControl)this.Master.FindControl("userManagement")).Attributes.Add("class", "active open");
            ((HtmlControl)this.Master.FindControl("staffContractor")).Attributes.Add("class", "active open");
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
                this.SetMiscValues(this.hfCompanyID.Value);
            }
            if (this.IsPostBack)
                return;
            this.divSave.Visible = this.Session["saveEmployee"] != null;
            this.divUpdate.Visible = this.Session["updateEmployee"] != null;
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
                            this.SetRecord(this.Request.QueryString["ID"]);
                            this.pnlAdd.Visible = true;
                            this.pnlView.Visible = false;
                            this.pnlViewAll.Visible = false;
                            this.btnSubmit.Visible = false;
                            this.btnUpdate.Visible = true;
                            this.txtStaffEmail.Focus();
                            break;
                        }
                        this.Clear();
                        this.txtStaffEmail.Focus();
                        this.pnlViewAll.Visible = false;
                        this.pnlAdd.Visible = true;
                        this.pnlView.Visible = false;
                        this.btnUpdate.Visible = false;
                        this.btnSubmit.Visible = true;
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
            this.dateFormat = this.objMiscellaneousMasterDT.Rows[0]["DateFormat"].ToString();
            this.gvStaff.PageSize = this.linePerPage;
        }

        private void ATagStyle()
        {
            if (this.Request.QueryString["ac"] != null && bool.Parse(this.Request.QueryString["ac"]))
            {
                this.activeTag.Attributes.Add("class", "activeTag");
                this.activeTag.Attributes.Remove("href");
                this.lblHeader.Text = "Staff and Contractors";
            }
            if (this.Request.QueryString["ar"] != null && bool.Parse(this.Request.QueryString["ar"]))
            {
                this.archivedTag.Attributes.Add("class", "activeTag");
                this.archivedTag.Attributes.Remove("href");
                this.lblHeader.Text = "Archived Staff and Contractors";
            }
            if (this.Request.QueryString["de"] != null && bool.Parse(this.Request.QueryString["de"]))
            {
                this.deletedTag.Attributes.Add("class", "activeTag");
                this.deletedTag.Attributes.Remove("href");
                this.lblHeader.Text = "Deleted Staff and Contractors";
            }
            if (this.Request.QueryString["ar"] != null || this.Request.QueryString["ac"] != null || this.Request.QueryString["de"] != null)
                return;
            this.activeTag.Attributes.Add("class", "activeTag");
            this.activeTag.Attributes.Remove("href");
            this.lblHeader.Text = "Staff and Contractors";
        }

        protected void lnkshowAUser_Click(object sender, EventArgs e)
        {
            this.rfvUsername.Enabled = this.rfvPassword.Enabled = this.rfvConfPassword.Enabled = this.cvPassword.Enabled = this.usernameDiv.Visible = true;
            this.lnkshowAUser.Visible = false;
        }

        protected void lnkshowAAddress_Click(object sender, EventArgs e)
        {
            this.contactAddress.Visible = true;
            this.lnkshowAAddress.Visible = false;
        }

        protected void gvStaff_Sorting(object sender, GridViewSortEventArgs e)
        {
            this.BindGrid();
        }

        private void Clear()
        {
            this.sqldsProjects.DataBind();
            this.chkProjects.DataBind();
            this.projectsDiv.Visible = this.chkProjects.Items.Count > 0;
            this.txtStaffEmail.Text = this.txtStaffFirstName.Text = this.txtStaffLastName.Text = this.txtHomePhone.Text = this.txtMobile.Text = this.txtUsername.Text = this.txtAddress1.Text = this.txtAddress2.Text = this.txtZipCode.Text = this.txtBussinessPhone.Text = this.txtFax.Text = this.txtNotes.Text = "";
            this.ddlCountry.SelectedIndex = this.ddlState.SelectedIndex = this.ddlCity.SelectedIndex = 0;
            this.txtStaffEmail.Focus();
        }

        private void BindGrid()
        {
            this.gvStaff.DataBind();
        }

        private void ViewRecord(string i)
        {
            this.objStaffMasterDT = this.objStaffMasterBll.GetDataByStaffID(int.Parse(i));
            if (this.objStaffMasterDT.Rows.Count <= 0)
                return;
            this.hfStaffID.Value = this.objStaffMasterDT.Rows[0]["StaffID"].ToString();
            this.hfCompanyID.Value = this.objStaffMasterDT.Rows[0]["CompanyID"].ToString();
            this.lblStaffEmail.Text = this.objStaffMasterDT.Rows[0]["Email"].ToString();
            this.lblStaffFirstName1.Text = this.lblStaffFirstName.Text = this.objStaffMasterDT.Rows[0]["FirstName"].ToString();
            this.lblStaffFirstName1.Text += " ";
            this.lblStaffFirstName.Text += " ";
            this.lblStaffLastName1.Text = this.lblStaffLastName.Text = this.objStaffMasterDT.Rows[0]["LastName"].ToString();
            this.lblHomePhone.Text = this.objStaffMasterDT.Rows[0]["HomePhone"].ToString();
            this.lblMobile.Text = this.objStaffMasterDT.Rows[0]["Mobile"].ToString();
            this.lblUsername.Text = this.objStaffMasterDT.Rows[0]["UserName"].ToString();
            this.lblBussinessPhone.Text = this.objStaffMasterDT.Rows[0]["BussinessPhone"].ToString();
            this.lblFax.Text = this.objStaffMasterDT.Rows[0]["Fax"].ToString();
            this.lblNotes.Text = this.objStaffMasterDT.Rows[0]["Notes"].ToString();
            this.lblAddress1.Text = !string.IsNullOrEmpty(this.objStaffMasterDT.Rows[0]["Address1"].ToString()) ? (string)this.objStaffMasterDT.Rows[0]["Address1"] + (object)"<br />" : "";
            this.lblAddress2.Text = !string.IsNullOrEmpty(this.objStaffMasterDT.Rows[0]["Address2"].ToString()) ? (string)this.objStaffMasterDT.Rows[0]["Address2"] + (object)"<br />" : "";
            this.lblZipCode.Text = !string.IsNullOrEmpty(this.objStaffMasterDT.Rows[0]["ZipCode"].ToString()) ? (string)this.objStaffMasterDT.Rows[0]["ZipCode"] + (object)" , " : "";
            string s1 = this.objStaffMasterDT.Rows[0]["CountryID"].ToString();
            string s2 = this.objStaffMasterDT.Rows[0]["StateID"].ToString();
            string s3 = this.objStaffMasterDT.Rows[0]["CityID"].ToString();
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
        }

        private void SetRecord(string iD)
        {
            this.objStaffMasterDT = this.objStaffMasterBll.GetDataByStaffID(int.Parse(iD));
            if (this.objStaffMasterDT.Rows.Count <= 0)
                return;
            this.hfStaffID.Value = this.objStaffMasterDT.Rows[0]["StaffID"].ToString();
            this.hfCompanyID.Value = this.objStaffMasterDT.Rows[0]["CompanyID"].ToString();
            this.txtStaffEmail.Text = this.objStaffMasterDT.Rows[0]["Email"].ToString();
            this.txtStaffFirstName.Text = this.objStaffMasterDT.Rows[0]["FirstName"].ToString();
            this.txtStaffLastName.Text = this.objStaffMasterDT.Rows[0]["LastName"].ToString();
            this.txtHomePhone.Text = this.objStaffMasterDT.Rows[0]["HomePhone"].ToString();
            this.txtMobile.Text = this.objStaffMasterDT.Rows[0]["Mobile"].ToString();
            this.txtUsername.Text = this.objStaffMasterDT.Rows[0]["UserName"].ToString();
            this.txtAddress1.Text = this.objStaffMasterDT.Rows[0]["Address1"].ToString();
            this.txtAddress2.Text = this.objStaffMasterDT.Rows[0]["Address2"].ToString();
            this.txtZipCode.Text = this.objStaffMasterDT.Rows[0]["ZipCode"].ToString();
            this.txtBussinessPhone.Text = this.objStaffMasterDT.Rows[0]["BussinessPhone"].ToString();
            this.txtFax.Text = this.objStaffMasterDT.Rows[0]["Fax"].ToString();
            this.txtNotes.Text = this.objStaffMasterDT.Rows[0]["Notes"].ToString();
            MembershipUser user = Membership.GetUser(this.txtUsername.Text);
            if (user != null)
            {
                this.lblUsernameAdd.Text = user.ToString();
                this.lblPasswordAdd.Text = user.GetPassword();
            }
            string s1 = this.objStaffMasterDT.Rows[0]["CountryID"].ToString();
            string s2 = this.objStaffMasterDT.Rows[0]["StateID"].ToString();
            string s3 = this.objStaffMasterDT.Rows[0]["CityID"].ToString();
            string str1 = this.objStaffMasterDT.Rows[0]["BillingRate"].ToString();
            if (!string.IsNullOrEmpty(str1))
                this.txtBillingRate.Text = str1;
            if (!string.IsNullOrEmpty(s1))
            {
                this.objCountryMasterDT = this.objCountryMasterBll.GetDataByCountryID(int.Parse(s1));
                if (this.objCountryMasterDT.Rows.Count > 0)
                {
                    this.ddlCountry.Items.Add(this.objCountryMasterDT.Rows[0]["CountryID"].ToString());
                    this.ddlCountry.SelectedValue = this.objCountryMasterDT.Rows[0]["CountryID"].ToString();
                }
            }
            if (!string.IsNullOrEmpty(s2))
            {
                this.objStateMasterDT = this.objStateMasterBll.GetDataByStateID(int.Parse(s2));
                if (this.objStateMasterDT.Rows.Count > 0)
                {
                    this.ddlState.Items.Add(this.objStateMasterDT.Rows[0]["StateID"].ToString());
                    this.ddlState.SelectedValue = this.objStateMasterDT.Rows[0]["StateID"].ToString();
                }
            }
            if (!string.IsNullOrEmpty(s3))
            {
                this.objCityMasterDT = this.objCityMasterBll.GetDataByCityID(int.Parse(s3));
                if (this.objCityMasterDT.Rows.Count > 0)
                {
                    this.ddlCity.Items.Add(this.objCityMasterDT.Rows[0]["CityID"].ToString());
                    this.ddlCity.SelectedValue = this.objCityMasterDT.Rows[0]["CityID"].ToString();
                }
            }
            this.lnkshowAAddress_Click((object)null, (EventArgs)null);
            this.lnkshowAUser_Click((object)null, (EventArgs)null);
            this.txtUsername.Enabled = false;
            this.sqldsProjects.DataBind();
            this.chkProjects.DataBind();
            this.projectsDiv.Visible = this.chkProjects.Items.Count > 0;
            this.objStaffProjectDetailDT = this.objStaffProjectDetailBll.GetDataByStaffID(int.Parse(this.hfStaffID.Value));
            if (this.objStaffProjectDetailDT.Rows.Count > 0)
            {
                for (int index = 0; index < this.objStaffProjectDetailDT.Rows.Count; ++index)
                {
                    string str2 = this.objStaffProjectDetailDT.Rows[index]["ProjectID"].ToString();
                    foreach (ListItem listItem in this.chkProjects.Items)
                    {
                        if (listItem.Value == str2)
                        {
                            listItem.Selected = true;
                            break;
                        }
                    }
                }
            }
            this.rfvPassword.Enabled = false;
            this.rfvConfPassword.Enabled = false;
            this.cvPassword.Enabled = true;
        }

        protected void gvStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Response.Redirect("~/BillTransact/EmployeeMaster.aspx?cmd=add&ID=" + this.gvStaff.SelectedRow.Cells[0].Text);
            this.BindGrid();
        }

        protected void gvStaff_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvStaff.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.objStaffMasterDT = this.objStaffMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
            int count = this.objStaffMasterDT.Rows.Count;
            this.objCompanyPackageMasterDT = this.objCompanyPackageMasterBll.GetDataByCompanyActivePackage(int.Parse(this.hfCompanyID.Value));
            if (this.objCompanyPackageMasterDT.Rows.Count <= 0)
                return;
            int iCloudPackageID = int.Parse(this.objCompanyPackageMasterDT.Rows[0]["CloudPackageID"].ToString());
            if (iCloudPackageID != 0)
            {
                this.objPackageFeatureMasterDT = this.objPackageFeatureMasterBll.GetDataByPackageFeatureName(4, "Additional staff accounts included");
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
                        this.Response.Redirect("~/BillTransact/EmployeeMaster.aspx?cmd=add");
                    else
                        this.DisplayAlert("Can not add more staff in this package. To add more staff please upgrade your package.");
                }
                catch (Exception ex1)
                {
                    try
                    {
                        if (bool.Parse(this.objCloudPackageDetailsDT.Rows[0]["CloudPackageDetailValue"].ToString()))
                            this.Response.Redirect("~/BillTransact/EmployeeMaster.aspx?cmd=add");
                        else
                            this.DisplayAlert("Can not add more clients in this package. To add more clients please upgrade your package.");
                    }
                    catch (Exception ex2)
                    {
                        this.Response.Redirect("~/BillTransact/EmployeeMaster.aspx?cmd=add");
                    }
                }
            }
            else
                this.Response.Redirect("~/BillTransact/EmployeeMaster.aspx?cmd=add");
        }

        protected async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!this.Page.IsValid)
                return;
            if (this.txtStaffEmail.Text.Trim().Length > 0 && this.txtStaffFirstName.Text.Trim().Length > 0 && this.txtStaffLastName.Text.Trim().Length > 0)
            {
                int? iCountryID = new int?();
                int? iStateID = new int?();
                int? iCityID = new int?();
                Decimal? dBillingRate = new Decimal?();
                if (this.ddlCountry.SelectedIndex > 0)
                    iCountryID = new int?(int.Parse(this.ddlCountry.SelectedItem.Value));
                if (this.ddlState.SelectedIndex > 0)
                    iStateID = new int?(int.Parse(this.ddlState.SelectedItem.Value));
                if (this.ddlCity.SelectedIndex > 0)
                    iCityID = new int?(int.Parse(this.ddlCity.SelectedItem.Value));
                if (this.txtBillingRate.Text.Trim().Length > 0)
                    dBillingRate = new Decimal?(Decimal.Parse(this.txtBillingRate.Text.Trim()));
                if (this.txtUsername.Text.Trim().Length > 0 && this.txtPassword.Text.Trim().Length > 0)
                {
                    if (this.txtPassword.Text.Trim().Length <= 3)
                        this.txtPassword.Text = Doyingo.GenerateCode(8);
                    MembershipCreateStatus status;
                    Membership.CreateUser(this.txtUsername.Text.Trim(), this.txtPassword.Text.Trim(), this.txtStaffEmail.Text, "What's Your First Name?", this.txtStaffFirstName.Text, true, out status);
                    if (status == MembershipCreateStatus.Success)
                    {
                        Roles.AddUserToRole(this.txtUsername.Text.Trim(), "Employee");
                    }
                    else
                    {
                        do
                        {
                            this.txtUsername.Text = this.txtStaffFirstName.Text + Doyingo.GenerateCode(5);
                            this.txtPassword.Text = Doyingo.GenerateCode(8);
                            Membership.CreateUser(this.txtUsername.Text.Trim(), this.txtPassword.Text, this.txtStaffEmail.Text, "What's Your First Name?", this.txtStaffFirstName.Text, true, out status);
                        }
                        while (status != MembershipCreateStatus.Success);
                        Roles.AddUserToRole(this.txtUsername.Text.Trim(), "Employee");
                    }
                }
                if (this.txtUsername.Text.Trim().Length == 0)
                {
                    MembershipCreateStatus status;
                    do
                    {
                        this.txtUsername.Text = this.txtStaffFirstName.Text + Doyingo.GenerateCode(5);
                        this.txtPassword.Text = Doyingo.GenerateCode(8);
                        Membership.CreateUser(this.txtUsername.Text.Trim(), this.txtPassword.Text, this.txtStaffEmail.Text, "What's Your First Name?", this.txtStaffFirstName.Text, true, out status);
                    }
                    while (status != MembershipCreateStatus.Success);
                    Roles.AddUserToRole(this.txtUsername.Text.Trim(), "Employee");
                }
                int staffID = this.objStaffMasterBll.AddStaff(int.Parse(this.hfCompanyID.Value), this.txtStaffEmail.Text.Trim(), this.txtStaffFirstName.Text.Trim(), this.txtStaffLastName.Text.Trim(), dBillingRate, this.txtUsername.Text.Trim(), this.txtAddress1.Text.Trim(), this.txtAddress2.Text.Trim(), iCountryID, iStateID, iCityID, this.txtZipCode.Text.Trim(), this.txtHomePhone.Text.Trim(), this.txtMobile.Text.Trim(), this.txtBussinessPhone.Text.Trim(), this.txtFax.Text.Trim(), this.txtNotes.Text.Trim(), true, false, false);
                if (staffID != 0)
                {
                    if (this.chkEmail.Checked)
                        await this.SendMailNew(staffID);
                    if (this.projectsDiv.Visible)
                    {
                        this.hfStaffID.Value = staffID.ToString();
                        this.objStaffProjectDetailBll.DeleteByStaff(int.Parse(this.hfStaffID.Value));
                        foreach (ListItem listItem in this.chkProjects.Items)
                        {
                            if (listItem.Selected)
                                this.objStaffProjectDetailBll.AddStaffProjectDetail(int.Parse(this.hfCompanyID.Value), int.Parse(this.hfStaffID.Value), int.Parse(listItem.Value));
                        }
                    }
                    this.Session["saveEmployee"] = (object)1;
                    this.DisplayAlert("Details Added Successfully.");
                    this.Response.Redirect("~/BillTransact/EmployeeMaster.aspx?cmd=add&ID=" + (object)staffID);
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

        private async Task SendMailNew(int staffID)
        {
            this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
            string str1 = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
            string addresses = this.objCompanyMasterDT.Rows[0]["CompanyEmail"].ToString();
            this.objStaffMasterDT = this.objStaffMasterBll.GetDataByStaffID(staffID);
            string username = this.objStaffMasterDT.Rows[0]["UserName"].ToString();
            string str2 = this.objStaffMasterDT.Rows[0]["FirstName"].ToString();
            string str3 = this.objStaffMasterDT.Rows[0]["LastName"].ToString();
            string address1 = this.objStaffMasterDT.Rows[0]["Email"].ToString();
            string str4 = string.Empty;
            MembershipUser user = Membership.GetUser(username);
            if (user != null)
                str4 = user.GetPassword();
            string str5 = string.Empty;
            string str6 = string.Empty;
            string address2 = "noreply@DoyniGo.com";
            this.objSMTPSettingsDT = this.objSMTPSettingsBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
            if (this.objSMTPSettingsDT.Rows.Count > 0)
            {
                str6 = this.objSMTPSettingsDT.Rows[0]["EmailSignature"].ToString();
                address2 = this.objSMTPSettingsDT.Rows[0]["SMTPFrom"].ToString();
            }
            this.objNewStaffEmailTemplateDT = this.objNewStaffEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
            if (this.objNewStaffEmailTemplateDT.Rows.Count > 0)
                str5 = this.objNewStaffEmailTemplateDT.Rows[0]["EmailBody"].ToString();
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
          (object) str4
        },
        {
          (object) "emailTemplate",
          (object) str5
        },
        {
          (object) "emailSign",
          (object) str6
        },
        {
          (object) "firstName",
          (object) str2
        },
        {
          (object) "lastName",
          (object) str3
        },
        {
          (object) "loginLink",
          (object) "<a target=\"_blank\" href=\"http://www.billtransact.com/MemberArea.aspx\">https://www.billtransact.com/MemberArea.aspx</a>"
        }
      };
            Parser parser1 = new Parser(this.Server.MapPath("~/MailTemplate/EmployeeInvitationNew.html"), Variables);
            string path1 = this.Server.MapPath("~\\TempHTMLFiles\\");
            File.WriteAllText(Path.Combine(path1, "Staff.html"), parser1.Parse());
            Parser parser2 = new Parser(path1 + "Staff.html", Variables);
            try
            {
                //MailMessage message = new MailMessage()
                //{
                //  From = new MailAddress(address2, str1.ToUpper())
                //};
                //message.To.Add(new MailAddress(address1));
                //message.ReplyToList.Add(addresses);
                //message.Subject = str1.ToUpper() + " invites you to track time and expenses in Bill Transact";
                //message.BodyEncoding = Encoding.UTF8;
                //message.Body = parser2.Parse();
                //message.IsBodyHtml = true;
                //SmtpClientForCompany.smtpClient(this.hfCompanyID.Value).Send(message);
                //Common.CommonHandler.SendSMTPEmail(hfCompanyID.Value, address1, str1.ToUpper() + " invites you to track time and expenses in Bill Transact", parser2.Parse(), true);
                await Common.CommonHandler.SendMail(hfCompanyID.Value, address1, str1.ToUpper() + " invites you to track time and expenses in Bill Transact", parser2.Parse(), true);
                File.Delete(Path.Combine(path1, "Staff.html"));
            }
            catch (Exception ex)
            {
                this.DisplayAlert("Error in sending mail." + (object)ex);
            }
        }

        protected async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.IsValid)
                    return;
                if (this.txtStaffEmail.Text.Trim().Length > 0 && this.txtStaffFirstName.Text.Trim().Length > 0 && this.txtStaffLastName.Text.Trim().Length > 0)
                {
                    int? iCountryID = new int?();
                    int? iStateID = new int?();
                    int? iCityID = new int?();
                    Decimal? dBillingRate = new Decimal?();
                    if (this.ddlCountry.SelectedIndex > 0)
                        iCountryID = new int?(int.Parse(this.ddlCountry.SelectedItem.Value));
                    if (this.ddlState.SelectedIndex > 0)
                        iStateID = new int?(int.Parse(this.ddlState.SelectedItem.Value));
                    if (this.ddlCity.SelectedIndex > 0)
                        iCityID = new int?(int.Parse(this.ddlCity.SelectedItem.Value));
                    if (this.txtBillingRate.Text.Trim().Length > 0)
                        dBillingRate = new Decimal?(Decimal.Parse(this.txtBillingRate.Text.Trim()));
                    bool flag = this.objStaffMasterBll.UpdateStaff(int.Parse(this.hfStaffID.Value), int.Parse(this.hfCompanyID.Value), this.txtStaffEmail.Text.Trim(), this.txtStaffFirstName.Text.Trim(), this.txtStaffLastName.Text.Trim(), dBillingRate, this.txtUsername.Text.Trim(), this.txtAddress1.Text.Trim(), this.txtAddress2.Text.Trim(), iCountryID, iStateID, iCityID, this.txtZipCode.Text.Trim(), this.txtHomePhone.Text.Trim(), this.txtMobile.Text.Trim(), this.txtBussinessPhone.Text.Trim(), this.txtFax.Text.Trim(), this.txtNotes.Text.Trim(), true, false, false);
                    if (this.txtPassword.Text.Trim().Length >= 3)
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
                    if (flag)
                    {
                        if (this.chkEmail.Checked)
                            await this.SendMailNew(int.Parse(this.hfStaffID.Value));
                        if (this.projectsDiv.Visible)
                        {
                            this.objStaffProjectDetailBll.DeleteByStaff(int.Parse(this.hfStaffID.Value));
                            foreach (ListItem listItem in this.chkProjects.Items)
                            {
                                if (listItem.Selected)
                                    this.objStaffProjectDetailBll.AddStaffProjectDetail(int.Parse(this.hfCompanyID.Value), int.Parse(this.hfStaffID.Value), int.Parse(listItem.Value));
                            }
                        }
                        this.Session["updateEmployee"] = (object)1;
                        this.DisplayAlert("Update Successfully..");
                        this.Response.Redirect("~/BillTransact/EmployeeMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
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
            for (int index = 0; index < this.gvStaff.Rows.Count; ++index)
            {
                CheckBox checkBox = (CheckBox)this.gvStaff.Rows[index].Cells[0].FindControl("chkID");
                if (checkBox.Checked)
                {
                    ++num;
                    string cssClass = checkBox.CssClass;
                    if (cssClass == "Staff")
                        this.objStaffMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), false, false, true);
                    else if (cssClass == "Contractor")
                        this.objContractorMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), false, false, true);
                }
            }
            if (num == 0)
                this.DisplayAlert("No Employees were selected.");
            else
                this.Response.Redirect("EmployeeMaster.aspx");
        }

        protected async void btnEmail_Click(object sender, EventArgs e)
        {
            int num = 0;
            for (int index = 0; index < this.gvStaff.Rows.Count; ++index)
            {
                CheckBox checkBox = (CheckBox)this.gvStaff.Rows[index].Cells[0].FindControl("chkID");
                if (checkBox.Checked && checkBox.CssClass == "Staff")
                {
                    ++num;
                    await this.SendMailNew(int.Parse(checkBox.ToolTip));
                }
            }
            if (num == 0)
                this.DisplayAlert("No Staff were selected.");
            else
                this.Response.Redirect("EmployeeMaster.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int num = 0;
            for (int index = 0; index < this.gvStaff.Rows.Count; ++index)
            {
                CheckBox checkBox = (CheckBox)this.gvStaff.Rows[index].Cells[0].FindControl("chkID");
                if (checkBox.Checked)
                {
                    ++num;
                    string cssClass = checkBox.CssClass;
                    if (cssClass == "Staff")
                        this.objStaffMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), false, true, false);
                    else if (cssClass == "Contractor")
                        this.objContractorMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), false, true, false);
                }
            }
            if (num == 0)
                this.DisplayAlert("No Employees were selected.");
            else
                this.Response.Redirect("EmployeeMaster.aspx?de=true&ac=false");
        }

        protected void btnUnArchived_Click(object sender, EventArgs e)
        {
            int num = 0;
            for (int index = 0; index < this.gvStaff.Rows.Count; ++index)
            {
                CheckBox checkBox = (CheckBox)this.gvStaff.Rows[index].Cells[0].FindControl("chkID");
                if (checkBox.Checked)
                {
                    ++num;
                    string cssClass = checkBox.CssClass;
                    if (cssClass == "Staff")
                        this.objStaffMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), true, false, false);
                    else if (cssClass == "Contractor")
                        this.objContractorMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), true, false, false);
                }
            }
            if (num == 0)
                this.DisplayAlert("No Employees were selected.");
            else
                this.Response.Redirect("EmployeeMaster.aspx?ar=true&ac=false");
        }

        protected void btnUnDelete_Click(object sender, EventArgs e)
        {
            int num = 0;
            for (int index = 0; index < this.gvStaff.Rows.Count; ++index)
            {
                CheckBox checkBox = (CheckBox)this.gvStaff.Rows[index].Cells[0].FindControl("chkID");
                if (checkBox.Checked)
                {
                    ++num;
                    string cssClass = checkBox.CssClass;
                    if (cssClass == "Staff")
                        this.objStaffMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), true, false, false);
                    else if (cssClass == "Contractor")
                        this.objContractorMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), true, false, false);
                }
            }
            if (num == 0)
                this.DisplayAlert("No Employees were selected.");
            else
                this.Response.Redirect("EmployeeMaster.aspx?de=true&ac=false");
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
            LinkButton linkButton = (LinkButton)sender;
            string commandArgument = linkButton.CommandArgument;
            switch (linkButton.ToolTip)
            {
                case "Staff":
                    this.Response.Redirect("~/BillTransact/EmployeeMaster.aspx?cmd=add&ID=" + commandArgument);
                    break;
                case "Contractor":
                    this.Response.Redirect("~/BillTransact/ContractorMaster.aspx?cmd=add&ID=" + commandArgument);
                    break;
                case "Admin":
                    this.Response.Redirect("~/BillTransact/UpdateCompanyDetail.aspx");
                    break;
                default:
                    this.Response.Redirect("~/BillTransact/EmployeeMaster.aspx");
                    break;
            }
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
            this.objCompanyClientContactDetailDT = this.objCompanyClientContactDetailBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), this.txtStaffEmail.Text.Trim());
            this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), this.txtStaffEmail.Text.Trim());
            this.objStaffMasterDT = this.objStaffMasterBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), this.txtStaffEmail.Text.Trim());
            this.objContractorMasterDT = this.objContractorMasterBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), this.txtStaffEmail.Text.Trim());
            this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyEmail(this.txtStaffEmail.Text.Trim());
            if (this.objCompanyMasterDT.Rows.Count > 0)
            {
                this.DisplayAlert("Email Already Register With System To Some Company.");
                ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Email Already Register With System  To Some Company.')", true);
                this.txtStaffEmail.Text = "";
                this.txtStaffEmail.Focus();
            }
            else if (this.objCompanyClientMasterDT.Rows.Count > 0 || this.objCompanyClientContactDetailDT.Rows.Count > 0)
            {
                this.DisplayAlert("Email Already Register With System To Some Client.");
                ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Email Already Register With System To Some Client.')", true);
                this.txtStaffEmail.Text = "";
                this.txtStaffEmail.Focus();
            }
            else if (this.objStaffMasterDT.Rows.Count > 0)
            {
                this.DisplayAlert("Email Already Register With System To Some Staff.");
                ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Email Already Register With System To Some Staff.')", true);
                this.txtStaffEmail.Text = "";
                this.txtStaffEmail.Focus();
            }
            else if (this.objContractorMasterDT.Rows.Count > 0)
            {
                this.DisplayAlert("Email Already Register With System To Some Contractor.");
                ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Email Already Register With System To Some Contractor.')", true);
                this.txtStaffEmail.Text = "";
                this.txtStaffEmail.Focus();
            }
            else
                this.txtStaffFirstName.Focus();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("EmployeeMaster.aspx?cmd=add&ID=" + this.hfStaffID.Value);
        }

        protected void lnkName_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            string commandArgument = linkButton.CommandArgument;
            switch (linkButton.ToolTip)
            {
                case "Staff":
                    this.Response.Redirect("~/BillTransact/EmployeeMaster.aspx?cmd=view&ID=" + commandArgument);
                    break;
                case "Contractor":
                    this.Response.Redirect("~/BillTransact/ContractorMaster.aspx?cmd=view&ID=" + commandArgument);
                    break;
                case "Admin":
                    this.Response.Redirect("~/BillTransact/UpdateCompanyDetail.aspx");
                    break;
                default:
                    this.Response.Redirect("~/BillTransact/EmployeeMaster.aspx");
                    break;
            }
        }

        protected void gvStaff_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            BoundField boundField = ((GridView)sender).Columns[2] as BoundField;
            if (boundField == null)
                return;
            boundField.DataFormatString = "{0:" + this.dateFormat + "}";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }
    }
}

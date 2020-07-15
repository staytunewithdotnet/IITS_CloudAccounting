// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.CompanyMaster
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Drawing;
using System.IO;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class CompanyMaster : Page
  {
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
    private readonly UserBLL objUserBll = new UserBLL();
    private CloudAccountDA.aspnet_UsersDataTable objUserDT = new CloudAccountDA.aspnet_UsersDataTable();
    private readonly CountryMasterBLL objCountryMasterBll = new CountryMasterBLL();
    private CloudAccountDA.CountryMasterDataTable objCountryMasterDT = new CloudAccountDA.CountryMasterDataTable();
    private readonly StateMasterBLL objStateMasterBll = new StateMasterBLL();
    private CloudAccountDA.StateMasterDataTable objStateMasterDT = new CloudAccountDA.StateMasterDataTable();
    private readonly CityMasterBLL objCityMasterBll = new CityMasterBLL();
    private CloudAccountDA.CityMasterDataTable objCityMasterDT = new CloudAccountDA.CityMasterDataTable();
    private readonly CompanyPackageDetailsBLL objCompanyPackageDetailsBll = new CompanyPackageDetailsBLL();
    private CloudAccountDA.CompanyPackageDetailsDataTable objCompanyPackageDetailsDT = new CloudAccountDA.CompanyPackageDetailsDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CurrencyMasterBLL objCurrencyMasterBll = new CurrencyMasterBLL();
    private CloudAccountDA.CurrencyMasterDataTable objCurrencyMasterDT = new CloudAccountDA.CurrencyMasterDataTable();
    private readonly IndustryMasterBLL objIndustryMasterBll = new IndustryMasterBLL();
    private CloudAccountDA.IndustryMasterDataTable objIndustryMasterDT = new CloudAccountDA.IndustryMasterDataTable();
    private readonly RunningFromMasterBLL objRunningFromMasterBll = new RunningFromMasterBLL();
    private CloudAccountDA.RunningFromMasterDataTable objRunningFromMasterDT = new CloudAccountDA.RunningFromMasterDataTable();
    private readonly BussinessMasterBLL objBussinessMasterBll = new BussinessMasterBLL();
    private CloudAccountDA.BussinessMasterDataTable objBussinessMasterDT = new CloudAccountDA.BussinessMasterDataTable();
    private readonly CurrentAccountMasterBLL objCurrentAccountMasterBll = new CurrentAccountMasterBLL();
    private CloudAccountDA.CurrentAccountMasterDataTable objCurrentAccountMasterDT = new CloudAccountDA.CurrentAccountMasterDataTable();
    private bool UserName;
    private bool CompanyName;
    private bool EmailID;
    protected ToolkitScriptManager tsm;
    protected Panel pnlAdd;
    protected UpdatePanel upCompany;
    protected TextBox txtCompanyUserName;
    protected RequiredFieldValidator rfvCompanyUserName;
    protected TextBox txtCompanyName;
    protected RequiredFieldValidator rfvCompanyName;
    protected TextBox txtContactPersonName;
    protected RequiredFieldValidator rfvContactPersonName;
    protected TextBox txtContactPersonNumber;
    protected RequiredFieldValidator rfvContactPersonNumber;
    protected TextBox txtBillingRate;
    protected DropDownList ddlBussiness;
    protected DropDownList ddlIndustry;
    protected DropDownList ddlCurrentAccount;
    protected DropDownList ddlRunningFor;
    protected DropDownList ddlCurrency;
    protected SqlDataSource sqldsCurrency;
    protected TextBox txtPhoneNumber;
    protected TextBox txtFaxNumber;
    protected TextBox txtEmail;
    protected RequiredFieldValidator rfvEmail;
    protected RegularExpressionValidator revtxtEmailAddress;
    protected TextBox txtAddress1;
    protected TextBox txtAddress2;
    protected DropDownList ddlCountry;
    protected SqlDataSource sqldsCountry;
    protected RequiredFieldValidator rfvCountryMaster;
    protected DropDownList ddlState;
    protected SqlDataSource sqldsState;
    protected RequiredFieldValidator rfvState1Master;
    protected DropDownList ddlCity;
    protected SqlDataSource sqldsCity;
    protected RequiredFieldValidator rfvCityMaster;
    protected TextBox txtZipCode;
    protected FileUpload fuLogo;
    protected TextBox txtNotes;
    protected UpdatePanel UpdatePanel2;
    protected TextBox txtLoginUserName;
    protected RequiredFieldValidator rfvLogiUserName;
    protected TextBox txtLoginPassword;
    protected RequiredFieldValidator rfvLoginPassword;
    protected TextBox txtLoginEmail;
    protected TextBox txtSecurityQue;
    protected TextBox txtSecurityAns;
    protected HtmlGenericControl chkkIsLockedOut;
    protected CheckBox chkIsLockedOut;
    protected CheckBox chkIsApproved;
    protected HtmlGenericControl IsLockedOut;
    protected Label lblAccount;
    protected Button btnSubmit;
    protected Button btnReset;
    protected Button btnUnlock;
    protected Button btnUpdate;
    protected Button btnListAll;
    protected Button btnCancel;
    protected Panel pnlView;
    protected Label lblCompanyUserName;
    protected Label lblCompanyName;
    protected Label lblCompanyPersonName;
    protected Label lblCompanyPersonNumber;
    protected Label lblBillingRate;
    protected Label lblBussiness;
    protected Label lblIndustry;
    protected Label lblCurrentAccounting;
    protected Label lblRunningFor;
    protected Label lblCurrency;
    protected Label lblPhoneNumber;
    protected Label lblFaxNumber;
    protected Label lblEmailID;
    protected Label lblAddressStreet1;
    protected Label lblAddressStreet2;
    protected Label lblCountry;
    protected Label lblState;
    protected Label lblCity;
    protected Label lblZipCode;
    protected Label lblCompanyLogo;
    protected System.Web.UI.WebControls.Image imgDatabase;
    protected Label lblNotes;
    protected Label lblUserNameLogin;
    protected Label lblPassword;
    protected Label lblSecurityQue;
    protected Label lblSecurityAns;
    protected Label lblLoginEmail;
    protected HtmlGenericControl Div1;
    protected CheckBox chkLocked;
    protected CheckBox chkApproved;
    protected Label lblCanLogin;
    protected Label lblCreateDate;
    protected Label lblLastPasswordChangeDate;
    protected Label lblLastLoginDate;
    protected Button btnEdit;
    protected Button btnDelete;
    protected Button btnList;
    protected Button btnAdd;
    protected Panel pnlViewAll;
    protected GridView gvCompany;
    protected GridView gvCompanyDeactive;
    protected Button btnAddCompany;
    protected ObjectDataSource objdsCompanyActive;
    protected ObjectDataSource objdsCompanyDeactive;
    protected SqlDataSource sqldsBussiness;
    protected SqlDataSource sqldsRunningFrom;
    protected SqlDataSource sqldsIndustry;
    protected SqlDataSource sqldsCurrentAccount;
    protected HiddenField hfCompany;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("companyManagement")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("companyMaster")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      MembershipUser user = Membership.GetUser();
      if (user != null)
      {
        string str = user.ToString();
        if (Roles.IsUserInRole(str, "Admin"))
        {
          this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(str);
          if (this.objCompanyLoginMasterDT.Rows.Count > 0)
            this.hfCompany.Value = this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString();
        }
      }
      if (this.Request.QueryString["cmd"] != null)
      {
        switch (this.Request.QueryString["cmd"])
        {
          case "view":
            if (this.Request.QueryString["ID"] == null || !(this.Request.QueryString["ID"] != ""))
              break;
            string iD1 = this.Request.QueryString["ID"];
            this.pnlViewAll.Visible = false;
            this.pnlAdd.Visible = false;
            this.pnlView.Visible = true;
            this.ViewRecord(iD1);
            if (Admin.RoleName == "MasterAdmin")
              this.btnAdd.Visible = true;
            else if (Admin.RoleName == "Admin")
            {
              this.btnAdd.Visible = false;
              this.btnDelete.Visible = false;
            }
            this.btnAdd.Visible = false;
            this.btnEdit.Visible = false;
            this.btnDelete.Visible = false;
            break;
          case "add":
            if (this.Request.QueryString["ID"] != null && this.Request.QueryString["ID"] != "")
            {
              string iD2 = this.Request.QueryString["ID"];
              this.pnlAdd.Visible = true;
              this.pnlViewAll.Visible = false;
              this.pnlView.Visible = false;
              this.btnUpdate.Visible = true;
              this.btnCancel.Visible = true;
              this.btnSubmit.Visible = false;
              this.btnReset.Visible = false;
              this.btnListAll.Visible = false;
              this.SetRecord(iD2);
              break;
            }
            this.Clear();
            this.btnSubmit.Visible = true;
            this.btnReset.Visible = true;
            this.btnUpdate.Visible = false;
            this.btnCancel.Visible = false;
            this.pnlAdd.Visible = true;
            this.pnlViewAll.Visible = false;
            this.pnlView.Visible = false;
            this.txtSecurityQue.Text = "What is your User Name?";
            break;
          default:
            this.BindGrid();
            this.pnlViewAll.Visible = true;
            this.pnlView.Visible = false;
            this.pnlAdd.Visible = false;
            break;
        }
      }
      else
      {
        this.BindGrid();
        this.pnlViewAll.Visible = true;
        this.pnlView.Visible = false;
        this.pnlAdd.Visible = false;
      }
    }

    private void ViewRecord(string iD)
    {
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(iD));
      if (this.objCompanyMasterDT.Rows.Count <= 0)
        return;
      this.hfCompany.Value = this.objCompanyMasterDT.Rows[0]["CompanyID"].ToString();
      this.lblCompanyName.Text = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
      this.lblCompanyUserName.Text = this.objCompanyMasterDT.Rows[0]["CompanyUserName"].ToString();
      this.lblPhoneNumber.Text = this.objCompanyMasterDT.Rows[0]["CompanyPhone"].ToString();
      this.lblFaxNumber.Text = this.objCompanyMasterDT.Rows[0]["CompanyFax"].ToString();
      this.lblEmailID.Text = this.objCompanyMasterDT.Rows[0]["CompanyEmail"].ToString();
      this.lblAddressStreet1.Text = this.objCompanyMasterDT.Rows[0]["CompanyAddressStreet1"].ToString();
      this.lblAddressStreet2.Text = this.objCompanyMasterDT.Rows[0]["CompanyAddressStreet2"].ToString();
      this.lblCompanyPersonName.Text = this.objCompanyMasterDT.Rows[0]["CompanyContactPerson"].ToString();
      this.lblCompanyPersonNumber.Text = this.objCompanyMasterDT.Rows[0]["CompanyContactPersonNumber"].ToString();
      this.lblZipCode.Text = this.objCompanyMasterDT.Rows[0]["CompanyZipCode"].ToString();
      this.lblNotes.Text = this.objCompanyMasterDT.Rows[0]["CompanyNotes"].ToString();
      if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CompanyCountryID"].ToString()))
      {
        this.objCountryMasterDT = this.objCountryMasterBll.GetDataByCountryID(int.Parse(this.objCompanyMasterDT.Rows[0]["CompanyCountryID"].ToString()));
        if (this.objCountryMasterDT.Rows.Count > 0)
          this.lblCountry.Text = this.objCountryMasterDT.Rows[0]["CountryName"].ToString();
      }
      if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CompanyStateID"].ToString()))
      {
        this.objStateMasterDT = this.objStateMasterBll.GetDataByStateID(int.Parse(this.objCompanyMasterDT.Rows[0]["CompanyStateID"].ToString()));
        if (this.objStateMasterDT.Rows.Count > 0)
          this.lblState.Text = this.objStateMasterDT.Rows[0]["StateName"].ToString();
      }
      if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CompanyCityID"].ToString()))
      {
        this.objCityMasterDT = this.objCityMasterBll.GetDataByCityID(int.Parse(this.objCompanyMasterDT.Rows[0]["CompanyCityID"].ToString()));
        if (this.objCityMasterDT.Rows.Count > 0)
          this.lblCity.Text = this.objCityMasterDT.Rows[0]["CityName"].ToString();
      }
      if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["RunningID"].ToString()))
      {
        this.objRunningFromMasterDT = this.objRunningFromMasterBll.GetDataByRunningFromID(int.Parse(this.objCompanyMasterDT.Rows[0]["RunningID"].ToString()));
        if (this.objRunningFromMasterDT.Rows.Count > 0)
          this.lblRunningFor.Text = this.objRunningFromMasterDT.Rows[0]["RunningFrom"].ToString();
      }
      if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["IndustryID"].ToString()))
      {
        this.objIndustryMasterDT = this.objIndustryMasterBll.GetDataByIndustryID(int.Parse(this.objCompanyMasterDT.Rows[0]["IndustryID"].ToString()));
        if (this.objIndustryMasterDT.Rows.Count > 0)
          this.lblIndustry.Text = this.objIndustryMasterDT.Rows[0]["IndustryName"].ToString();
      }
      if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["BussinessID"].ToString()))
      {
        this.objBussinessMasterDT = this.objBussinessMasterBll.GetDataByBussinessID(int.Parse(this.objCompanyMasterDT.Rows[0]["BussinessID"].ToString()));
        if (this.objBussinessMasterDT.Rows.Count > 0)
          this.lblBussiness.Text = this.objBussinessMasterDT.Rows[0]["BussinessName"].ToString();
      }
      if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CurrencyID"].ToString()))
      {
        this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(this.objCompanyMasterDT.Rows[0]["CurrencyID"].ToString()));
        if (this.objCurrencyMasterDT.Rows.Count > 0)
          this.lblCurrency.Text = this.objCurrencyMasterDT.Rows[0]["CurrencyName"].ToString();
      }
      if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CurrentAccountID"].ToString()))
      {
        this.objCurrentAccountMasterDT = this.objCurrentAccountMasterBll.GetDataByCurrentAccountID(int.Parse(this.objCompanyMasterDT.Rows[0]["CurrentAccountID"].ToString()));
        if (this.objCurrentAccountMasterDT.Rows.Count > 0)
          this.lblCurrentAccounting.Text = this.objCurrentAccountMasterDT.Rows[0]["CurrentAccountName"].ToString();
      }
      this.lblCompanyLogo.Text = this.objCompanyMasterDT.Rows[0]["CompanyLogo"].ToString();
      if (!string.IsNullOrEmpty(this.lblCompanyLogo.Text))
      {
        this.imgDatabase.Visible = true;
        this.imgDatabase.ImageUrl = "~/Handler/CompanyLogoFile.ashx?id=" + this.hfCompany.Value;
      }
      else
      {
        this.imgDatabase.Visible = false;
        this.imgDatabase.ImageUrl = (string) null;
      }
      MembershipUser user = Membership.GetUser(this.lblCompanyUserName.Text);
      if (user != null && !user.IsLockedOut)
      {
        this.lblUserNameLogin.Text = user.UserName;
        this.lblPassword.Text = user.GetPassword();
        this.lblSecurityQue.Text = user.PasswordQuestion;
        this.lblSecurityAns.Text = this.objCompanyMasterDT.Rows[0]["CompanyUserName"].ToString();
        this.lblLoginEmail.Text = user.Email;
      }
      else
      {
        this.lblPassword.Text = "This User Account has been Locked.";
        this.lblPassword.ForeColor = Color.Red;
        this.chkLocked.Enabled = false;
        this.chkApproved.Enabled = false;
      }
      this.chkLocked.Checked = user != null && user.IsLockedOut;
      if (user != null)
      {
        this.lblCompanyUserName.Text = user.UserName;
        this.lblEmailID.Text = user.Email;
        this.chkApproved.Checked = user.IsApproved;
        if (this.chkApproved.Checked)
        {
          this.lblCanLogin.Visible = true;
          this.lblCanLogin.Text = "Yes";
          this.chkApproved.Visible = false;
        }
        else
        {
          this.lblCanLogin.Text = "No";
          this.chkApproved.Visible = false;
        }
        this.lblCreateDate.Text = user.CreationDate.ToShortDateString();
        this.lblLastLoginDate.Text = user.LastLoginDate.ToShortDateString();
        this.lblLastPasswordChangeDate.Text = user.LastPasswordChangedDate.ToShortDateString();
        this.chkApproved.Enabled = false;
        this.chkLocked.Enabled = false;
      }
      if (Membership.GetUser(this.lblCompanyUserName.Text) != null)
        return;
      this.lblCompanyUserName.Text = this.objCompanyMasterDT.Rows[0]["CompanyUserName"].ToString();
      this.lblPassword.ForeColor = Color.Gray;
      this.lblSecurityQue.Text = "What is your User Name?";
      this.lblSecurityAns.Text = this.objCompanyMasterDT.Rows[0]["CompanyUserName"].ToString();
      this.lblEmailID.Text = this.objCompanyMasterDT.Rows[0]["CompanyEmail"].ToString();
      this.chkApproved.Checked = true;
      Label label1 = this.lblCreateDate;
      Label label2 = this.lblLastPasswordChangeDate;
      DateTime now = DateTime.Now;
      string str1;
      string str2 = str1 = now.ToShortDateString();
      label2.Text = str1;
      string str3 = str2;
      label1.Text = str3;
    }

    private void SetRecord(string iD)
    {
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(iD));
      if (this.objCompanyMasterDT.Rows.Count <= 0)
        return;
      this.hfCompany.Value = this.objCompanyMasterDT.Rows[0]["CompanyID"].ToString();
      this.txtCompanyName.Text = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
      this.txtCompanyUserName.Text = this.objCompanyMasterDT.Rows[0]["CompanyUserName"].ToString();
      this.txtPhoneNumber.Text = this.objCompanyMasterDT.Rows[0]["CompanyPhone"].ToString();
      this.txtFaxNumber.Text = this.objCompanyMasterDT.Rows[0]["CompanyFax"].ToString();
      this.txtEmail.Text = this.objCompanyMasterDT.Rows[0]["CompanyEmail"].ToString();
      this.txtAddress1.Text = this.objCompanyMasterDT.Rows[0]["CompanyAddressStreet1"].ToString();
      this.txtAddress2.Text = this.objCompanyMasterDT.Rows[0]["CompanyAddressStreet2"].ToString();
      this.txtZipCode.Text = this.objCompanyMasterDT.Rows[0]["CompanyZipCode"].ToString();
      this.txtContactPersonName.Text = this.objCompanyMasterDT.Rows[0]["CompanyContactPerson"].ToString();
      this.txtContactPersonNumber.Text = this.objCompanyMasterDT.Rows[0]["CompanyContactPersonNumber"].ToString();
      this.txtNotes.Text = this.objCompanyMasterDT.Rows[0]["CompanyNotes"].ToString();
      if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CompanyCountryID"].ToString()))
      {
        this.objCountryMasterDT = this.objCountryMasterBll.GetDataByCountryID(int.Parse(this.objCompanyMasterDT.Rows[0]["CompanyCountryID"].ToString()));
        if (this.objCountryMasterDT.Rows.Count > 0)
        {
          this.ddlCountry.Items.Add(this.objCountryMasterDT.Rows[0]["CountryID"].ToString());
          this.ddlCountry.SelectedValue = this.objCountryMasterDT.Rows[0]["CountryID"].ToString();
        }
      }
      if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CompanyStateID"].ToString()))
      {
        this.objStateMasterDT = this.objStateMasterBll.GetDataByStateID(int.Parse(this.objCompanyMasterDT.Rows[0]["CompanyStateID"].ToString()));
        if (this.objStateMasterDT.Rows.Count > 0)
        {
          this.ddlState.Items.Add(this.objStateMasterDT.Rows[0]["StateID"].ToString());
          this.ddlState.SelectedValue = this.objStateMasterDT.Rows[0]["StateID"].ToString();
        }
      }
      if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CompanyCityID"].ToString()))
      {
        this.objCityMasterDT = this.objCityMasterBll.GetDataByCityID(int.Parse(this.objCompanyMasterDT.Rows[0]["CompanyCityID"].ToString()));
        if (this.objCityMasterDT.Rows.Count > 0)
        {
          this.ddlCity.Items.Add(this.objCityMasterDT.Rows[0]["CityID"].ToString());
          this.ddlCity.SelectedValue = this.objCityMasterDT.Rows[0]["CityID"].ToString();
        }
      }
      if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["BussinessID"].ToString()))
      {
        this.objBussinessMasterDT = this.objBussinessMasterBll.GetDataByBussinessID(int.Parse(this.objCompanyMasterDT.Rows[0]["BussinessID"].ToString()));
        if (this.objBussinessMasterDT.Rows.Count > 0)
        {
          this.ddlBussiness.Items.Add(this.objBussinessMasterDT.Rows[0]["BussinessID"].ToString());
          this.ddlBussiness.SelectedValue = this.objBussinessMasterDT.Rows[0]["BussinessID"].ToString();
        }
      }
      if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["IndustryID"].ToString()))
      {
        this.objIndustryMasterDT = this.objIndustryMasterBll.GetDataByIndustryID(int.Parse(this.objCompanyMasterDT.Rows[0]["IndustryID"].ToString()));
        if (this.objIndustryMasterDT.Rows.Count > 0)
        {
          this.ddlIndustry.Items.Add(this.objIndustryMasterDT.Rows[0]["IndustryID"].ToString());
          this.ddlIndustry.SelectedValue = this.objIndustryMasterDT.Rows[0]["IndustryID"].ToString();
        }
      }
      if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CurrentAccountID"].ToString()))
      {
        this.objCurrentAccountMasterDT = this.objCurrentAccountMasterBll.GetDataByCurrentAccountID(int.Parse(this.objCompanyMasterDT.Rows[0]["CurrentAccountID"].ToString()));
        if (this.objCurrentAccountMasterDT.Rows.Count > 0)
        {
          this.ddlCurrentAccount.Items.Add(this.objCurrentAccountMasterDT.Rows[0]["CurrentAccountID"].ToString());
          this.ddlCurrentAccount.SelectedValue = this.objCurrentAccountMasterDT.Rows[0]["CurrentAccountID"].ToString();
        }
      }
      if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["RunningID"].ToString()))
      {
        this.objRunningFromMasterDT = this.objRunningFromMasterBll.GetDataByRunningFromID(int.Parse(this.objCompanyMasterDT.Rows[0]["RunningID"].ToString()));
        if (this.objRunningFromMasterDT.Rows.Count > 0)
        {
          this.ddlRunningFor.Items.Add(this.objRunningFromMasterDT.Rows[0]["RunningFromID"].ToString());
          this.ddlRunningFor.SelectedValue = this.objRunningFromMasterDT.Rows[0]["RunningFromID"].ToString();
        }
      }
      if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CurrencyID"].ToString()))
      {
        this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(this.objCompanyMasterDT.Rows[0]["CurrencyID"].ToString()));
        if (this.objCurrencyMasterDT.Rows.Count > 0)
        {
          this.ddlCurrency.Items.Add(this.objCurrencyMasterDT.Rows[0]["CurrencyID"].ToString());
          this.ddlCurrency.SelectedValue = this.objCurrencyMasterDT.Rows[0]["CurrencyID"].ToString();
        }
      }
      MembershipUser user = Membership.GetUser(this.txtCompanyUserName.Text);
      if (user == null)
      {
        this.txtLoginUserName.Text = this.objCompanyMasterDT.Rows[0]["CompanyUserName"].ToString();
        this.txtLoginEmail.Text = this.objCompanyMasterDT.Rows[0]["CompanyEmail"].ToString();
        this.txtSecurityAns.Text = this.objCompanyMasterDT.Rows[0]["CompanyUserName"].ToString();
        this.chkIsApproved.Enabled = true;
        this.chkkIsLockedOut.Visible = false;
        this.IsLockedOut.Visible = false;
        this.btnUnlock.Visible = false;
        this.chkIsApproved.Checked = true;
        this.txtLoginUserName.Enabled = false;
        this.txtLoginPassword.Enabled = false;
        this.txtSecurityAns.Enabled = false;
        this.txtSecurityQue.Enabled = false;
        this.txtLoginEmail.Enabled = false;
      }
      else if (!user.IsLockedOut)
      {
        this.txtLoginUserName.Text = user.UserName;
        this.txtLoginPassword.Text = user.GetPassword();
        this.txtLoginEmail.Text = user.Email;
        this.txtSecurityAns.Text = this.objCompanyMasterDT.Rows[0]["CompanyUserName"].ToString();
        this.btnUpdate.Visible = true;
        this.chkIsApproved.Enabled = true;
        this.txtLoginPassword.Enabled = true;
        this.btnUnlock.Visible = false;
      }
      else
      {
        this.btnUpdate.Visible = false;
        this.chkkIsLockedOut.Visible = true;
        this.btnUnlock.Visible = true;
        this.IsLockedOut.Visible = true;
        this.chkIsLockedOut.Checked = user.IsLockedOut;
        this.chkIsLockedOut.Enabled = false;
        this.chkIsApproved.Enabled = false;
        this.lblAccount.Text = "This User Account has been Locked.";
        this.lblAccount.ForeColor = Color.Red;
      }
      if (user != null)
      {
        this.chkIsApproved.Checked = user.IsApproved;
        this.txtLoginUserName.Text = user.UserName;
        this.txtLoginUserName.Enabled = false;
        this.txtLoginPassword.Enabled = false;
        this.txtSecurityAns.Enabled = false;
        this.txtSecurityQue.Enabled = false;
        this.txtSecurityQue.Text = user.PasswordQuestion;
        this.txtLoginEmail.Text = user.Email;
        this.txtLoginEmail.Enabled = false;
      }
      this.txtCompanyUserName.Enabled = false;
      this.txtEmail.Enabled = false;
    }

    private void Clear()
    {
      this.txtCompanyName.Text = this.txtPhoneNumber.Text = this.txtFaxNumber.Text = this.txtEmail.Text = this.txtAddress1.Text = this.txtAddress2.Text = this.txtZipCode.Text = this.txtNotes.Text = (string) null;
      this.ddlCountry.SelectedIndex = this.ddlState.SelectedIndex = this.ddlCity.SelectedIndex = 0;
      this.txtCompanyUserName.Focus();
    }

    private void BindGrid()
    {
      this.btnAddCompany.Visible = false;
      this.gvCompany.DataBind();
      this.gvCompanyDeactive.DataBind();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvCompany.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvCompany, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      foreach (GridViewRow gridViewRow in this.gvCompanyDeactive.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvCompanyDeactive, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void gvCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/CompanyMaster.aspx?cmd=view&ID=" + this.gvCompany.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvCompany.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void gvCompanyDeactive_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/CompanyMaster.aspx?cmd=view&ID=" + this.gvCompanyDeactive.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvCompanyDeactive_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvCompanyDeactive.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void btnAddCompany_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/CompanyMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (this.txtCompanyName.Text.Length > 0 && this.txtEmail.Text.Length > 0)
      {
        this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyUserName(this.txtLoginUserName.Text.Trim());
        if (this.objCompanyMasterDT.Rows.Count > 0)
          this.UserName = true;
        this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyName(this.txtCompanyName.Text.Trim());
        if (this.objCompanyMasterDT.Rows.Count > 0)
          this.CompanyName = true;
        this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyEmail(this.txtEmail.Text.Trim());
        if (this.objCompanyMasterDT.Rows.Count > 0)
          this.EmailID = true;
        if (!this.UserName)
        {
          if (!this.CompanyName)
          {
            if (!this.EmailID)
            {
              string str = string.Empty;
              switch (Path.GetExtension(Path.GetFileName(this.fuLogo.PostedFile.FileName)))
              {
                case ".jpg":
                  str = "image/jpg";
                  break;
                case ".png":
                  str = "image/png";
                  break;
                case ".gif":
                  str = "image/gif";
                  break;
                case ".dwg":
                  str = "image/dwg";
                  break;
              }
              Stream inputStream = this.fuLogo.PostedFile.InputStream;
              byte[] byCompanyLogo = new BinaryReader(inputStream).ReadBytes((int) inputStream.Length);
              int? iCountryID = new int?();
              int? iStateID = new int?();
              int? iCityID = new int?();
              int? iBussinessID = new int?();
              int? iIndustryID = new int?();
              int? iCurrencyID = new int?();
              int? iRunningID = new int?();
              int? iCurrentAccountID = new int?();
              if (this.ddlCountry.SelectedIndex > 0)
                iCountryID = new int?(int.Parse(this.ddlCountry.SelectedItem.Value));
              if (this.ddlState.SelectedIndex > 0)
                iStateID = new int?(int.Parse(this.ddlState.SelectedItem.Value));
              if (this.ddlCity.SelectedIndex > 0)
                iCityID = new int?(int.Parse(this.ddlCity.SelectedItem.Value));
              if (this.ddlBussiness.SelectedIndex > 0)
                iBussinessID = new int?(int.Parse(this.ddlBussiness.SelectedItem.Value));
              if (this.ddlIndustry.SelectedIndex > 0)
                iIndustryID = new int?(int.Parse(this.ddlIndustry.SelectedItem.Value));
              if (this.ddlCurrentAccount.SelectedIndex > 0)
                iCurrentAccountID = new int?(int.Parse(this.ddlCurrentAccount.SelectedItem.Value));
              if (this.ddlRunningFor.SelectedIndex > 0)
                iRunningID = new int?(int.Parse(this.ddlRunningFor.SelectedItem.Value));
              if (this.ddlCurrency.SelectedIndex > 0)
                iCurrencyID = new int?(int.Parse(this.ddlCurrency.SelectedItem.Value));
              int num = this.objCompanyMasterBll.AddCompany(this.txtCompanyUserName.Text, this.txtCompanyName.Text.Trim(), this.txtContactPersonName.Text.Trim(), this.txtContactPersonNumber.Text.Trim(), new Decimal?(Decimal.Parse(this.txtBillingRate.Text)), iBussinessID, iIndustryID, iCurrentAccountID, iRunningID, iCurrencyID, this.txtPhoneNumber.Text.Trim(), this.txtFaxNumber.Text.Trim(), this.txtEmail.Text.Trim(), this.txtAddress1.Text.Trim(), this.txtAddress2.Text.Trim(), iCountryID, iStateID, iCityID, this.txtZipCode.Text.Trim(), str.Trim(), byCompanyLogo, this.txtNotes.Text.Trim(), "", false, "");
              MembershipUser user = Membership.GetUser(this.txtCompanyUserName.Text);
              if (user == null)
              {
                this.txtLoginUserName.Text = this.txtLoginUserName.Text;
                this.txtLoginPassword.Text = this.txtLoginPassword.Text;
                this.txtSecurityQue.Text = "What is your User name.?";
                this.txtSecurityAns.Text = this.txtCompanyUserName.Text;
                this.txtLoginEmail.Text = this.txtEmail.Text.Trim();
                MembershipCreateStatus status;
                Membership.CreateUser(this.txtLoginUserName.Text.Trim(), this.txtLoginPassword.Text.Trim(), this.txtLoginEmail.Text.Trim(), this.txtSecurityQue.Text, this.txtSecurityAns.Text.Trim(), this.chkIsApproved.Checked, out status);
                Roles.AddUserToRole(this.txtLoginUserName.Text.Trim(), "Admin");
                this.objCompanyLoginMasterBll.AddCompanyLogin(Convert.ToInt32(num), this.txtLoginUserName.Text.Trim(), this.txtLoginEmail.Text.Trim(), this.chkIsApproved.Checked);
              }
              else
              {
                user.Email = this.txtEmail.Text.Trim();
                user.IsApproved = this.chkIsApproved.Checked;
                user.ChangePassword(user.GetPassword(), this.txtLoginPassword.Text);
                user.IsApproved = this.chkIsApproved.Checked;
                Membership.UpdateUser(user);
              }
              if (num != 0)
              {
                this.DisplayAlert("Details Added Successfully.");
                this.Response.Redirect("~/BillTransact/CompanyMaster.aspx?cmd=view&ID=" + (object) num);
              }
              else
              {
                this.DisplayAlert("Fail to Add New Details.");
                this.Clear();
              }
            }
            else
            {
              this.txtEmail.Text = string.Empty;
              this.DisplayAlert("Email ID Already Exist..");
            }
          }
          else
          {
            this.txtCompanyName.Text = string.Empty;
            this.DisplayAlert("Company Name Already Exist..");
          }
        }
        else
        {
          this.txtLoginUserName.Text = string.Empty;
          this.DisplayAlert("User Name Already Exist..");
        }
      }
      else
        this.DisplayAlert("Fail to Add New Details.");
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
      this.Clear();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
      try
      {
        if (!this.Page.IsValid)
          return;
        if (this.txtCompanyName.Text.Trim().Length > 0 && this.txtEmail.Text.Trim().Length > 0)
        {
          string str = string.Empty;
          byte[] byCompanyLogo;
          if (this.fuLogo.HasFile)
          {
            switch (Path.GetExtension(Path.GetFileName(this.fuLogo.PostedFile.FileName)))
            {
              case ".jpg":
                str = "image/jpg";
                break;
              case ".png":
                str = "image/png";
                break;
              case ".gif":
                str = "image/gif";
                break;
              case ".dwg":
                str = "image/dwg";
                break;
            }
            Stream inputStream = this.fuLogo.PostedFile.InputStream;
            byCompanyLogo = new BinaryReader(inputStream).ReadBytes((int) inputStream.Length);
          }
          else
          {
            this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(this.hfCompany.Value.Trim()));
            byCompanyLogo = (byte[]) this.objCompanyMasterDT.Rows[0]["CompanyLogo"];
            str = this.objCompanyMasterDT.Rows[0]["CompanyLogoContentType"].ToString();
          }
          int? iCountryID = new int?();
          int? iStateID = new int?();
          int? iCityID = new int?();
          int? iBussinessID = new int?();
          int? iIndustryID = new int?();
          int? iCurrencyID = new int?();
          int? iRunningID = new int?();
          int? iCurrentAccountID = new int?();
          if (this.ddlCountry.SelectedIndex > 0)
            iCountryID = new int?(int.Parse(this.ddlCountry.SelectedItem.Value));
          if (this.ddlState.SelectedIndex > 0)
            iStateID = new int?(int.Parse(this.ddlState.SelectedItem.Value));
          if (this.ddlCity.SelectedIndex > 0)
            iCityID = new int?(int.Parse(this.ddlCity.SelectedItem.Value));
          if (this.ddlBussiness.SelectedIndex > 0)
            iBussinessID = new int?(int.Parse(this.ddlBussiness.SelectedItem.Value));
          if (this.ddlIndustry.SelectedIndex > 0)
            iIndustryID = new int?(int.Parse(this.ddlIndustry.SelectedItem.Value));
          if (this.ddlCurrentAccount.SelectedIndex > 0)
            iCurrentAccountID = new int?(int.Parse(this.ddlCurrentAccount.SelectedItem.Value));
          if (this.ddlRunningFor.SelectedIndex > 0)
            iRunningID = new int?(int.Parse(this.ddlRunningFor.SelectedItem.Value));
          if (this.ddlCurrency.SelectedIndex > 0)
            iCurrencyID = new int?(int.Parse(this.ddlCurrency.SelectedItem.Value));
          bool flag = this.objCompanyMasterBll.UpdateCompany(int.Parse(this.hfCompany.Value.Trim()), this.txtCompanyUserName.Text, this.txtCompanyName.Text.Trim(), this.txtContactPersonName.Text.Trim(), this.txtContactPersonNumber.Text.Trim(), new Decimal?(Decimal.Parse(this.txtBillingRate.Text)), iBussinessID, iIndustryID, iCurrentAccountID, iRunningID, iCurrencyID, this.txtPhoneNumber.Text.Trim(), this.txtFaxNumber.Text.Trim(), this.txtEmail.Text.Trim(), this.txtAddress1.Text.Trim(), this.txtAddress2.Text.Trim(), iCountryID, iStateID, iCityID, this.txtZipCode.Text.Trim(), str.Trim(), byCompanyLogo, this.txtNotes.Text.Trim(), "", false, "");
          MembershipUser user = Membership.GetUser(this.txtCompanyUserName.Text);
          if (user == null)
          {
            this.txtLoginUserName.Text = this.txtLoginUserName.Text;
            this.txtLoginPassword.Text = this.txtLoginPassword.Text;
            this.txtSecurityQue.Text = "What is ur User name.?";
            this.txtSecurityAns.Text = this.txtCompanyUserName.Text;
            this.txtLoginEmail.Text = this.txtEmail.Text.Trim();
            MembershipCreateStatus status;
            Membership.CreateUser(this.txtLoginUserName.Text.Trim(), this.txtLoginPassword.Text.Trim(), this.txtLoginEmail.Text.Trim(), this.txtSecurityQue.Text, this.txtSecurityAns.Text.Trim(), this.chkIsApproved.Checked, out status);
            Roles.RemoveUserFromRole(this.txtCompanyUserName.Text, "Admin");
            Roles.AddUserToRole(this.txtLoginUserName.Text.Trim(), "Admin");
            this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(this.txtCompanyUserName.Text);
            if (this.objCompanyLoginMasterDT.Rows.Count > 0)
              this.objCompanyLoginMasterBll.UpdateCompanyLogin(Convert.ToInt32(this.objCompanyLoginMasterDT.Rows[0]["CompanyLoginID"].ToString()), Convert.ToInt32(this.ID), this.txtLoginUserName.Text.Trim(), this.txtLoginEmail.Text.Trim(), this.chkIsApproved.Checked);
          }
          else
          {
            user.Email = this.txtEmail.Text.Trim();
            user.ChangePassword(user.GetPassword(), this.txtLoginPassword.Text);
            Roles.RemoveUserFromRole(this.txtCompanyUserName.Text, Roles.GetRolesForUser(this.txtCompanyUserName.Text)[0]);
            Roles.AddUserToRole(this.txtLoginUserName.Text.Trim(), "Admin");
            user.IsApproved = this.chkIsApproved.Checked;
            Membership.UpdateUser(user);
          }
          if (flag)
          {
            this.DisplayAlert("Update Successfully..");
            this.Response.Redirect("~/BillTransact/CompanyMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
          }
          else
            this.DisplayAlert("Fail to Add New Details..!");
        }
        else
          this.DisplayAlert("Please Fill All Details...!");
      }
      catch (Exception ex)
      {
        this.DisplayAlert(ex.Message);
      }
    }

    protected void btnUnlock_Click(object sender, EventArgs e)
    {
      MembershipUser user = Membership.GetUser(this.txtCompanyName.Text.Trim());
      if (user != null)
        user.UnlockUser();
      this.Response.Redirect("~/BillTransact/CompanyMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/CompanyMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      this.objCompanyPackageDetailsDT = this.objCompanyPackageDetailsBll.GetDataByCompanyID(int.Parse(this.hfCompany.Value));
      if (this.objCompanyPackageDetailsDT.Rows.Count > 0)
        this.DisplayAlert("Child Already Exist..");
      else if (this.hfCompany.Value != null)
      {
        if (this.objCompanyMasterBll.DeleteCompany(int.Parse(this.hfCompany.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/BillTransact/CompanyMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/CompanyMaster.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/CompanyMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
    }

    public void DisplayAlert(string message)
    {
      this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">" + this.GetAlertScript(message) + "</script>");
    }

    public string GetAlertScript(string message)
    {
      return "alert('" + message.Replace("'", "\\'") + "');";
    }

    protected void txtCompanyUserName_TextChanged(object sender, EventArgs e)
    {
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyUserName(this.txtCompanyUserName.Text.Trim());
      this.objUserDT = this.objUserBll.GetAllDetail(this.txtCompanyUserName.Text.Trim());
      if (this.objCompanyMasterDT.Rows.Count > 0 || this.objUserDT.Rows.Count > 0)
      {
        this.DisplayAlert("UserName Already Exists In System.");
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('UserName Already Exists In System.')", true);
        this.txtCompanyUserName.Text = "";
        this.txtCompanyUserName.Focus();
      }
      else
      {
        this.txtLoginUserName.Text = this.txtCompanyUserName.Text;
        this.txtSecurityAns.Text = this.txtCompanyUserName.Text;
        this.txtCompanyName.Focus();
      }
    }

    protected void txtCompanyName_TextChanged(object sender, EventArgs e)
    {
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyName(this.txtCompanyName.Text.Trim());
      if (this.objCompanyMasterDT.Rows.Count > 0)
      {
        this.DisplayAlert("Company Already Register With System.");
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Company Already Register With System.')", true);
        this.txtCompanyName.Text = "";
        this.txtCompanyName.Focus();
      }
      else
        this.txtContactPersonName.Focus();
    }

    protected void txtEmail_TextChanged(object sender, EventArgs e)
    {
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyEmail(this.txtEmail.Text.Trim());
      if (this.objCompanyMasterDT.Rows.Count > 0)
      {
        this.DisplayAlert("Company Email Already Register With System.");
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Company Email Already Register With System.')", true);
        this.txtEmail.Text = "";
        this.txtEmail.Focus();
      }
      else
      {
        this.txtLoginEmail.Text = this.txtEmail.Text;
        this.txtAddress1.Focus();
      }
    }
  }
}

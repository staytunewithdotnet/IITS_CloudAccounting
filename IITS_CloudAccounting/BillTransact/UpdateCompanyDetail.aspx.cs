// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.UpdateCompanyDetail
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class UpdateCompanyDetail : Page
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
    private readonly CurrencyMasterBLL objCurrencyMasterBll = new CurrencyMasterBLL();
    private CloudAccountDA.CurrencyMasterDataTable objCurrencyMasterDT = new CloudAccountDA.CurrencyMasterDataTable();
    private readonly IndustryMasterBLL objIndustryMasterBll = new IndustryMasterBLL();
    private CloudAccountDA.IndustryMasterDataTable objIndustryMasterDT = new CloudAccountDA.IndustryMasterDataTable();
    private readonly BussinessMasterBLL objBussinessMasterBll = new BussinessMasterBLL();
    private CloudAccountDA.BussinessMasterDataTable objBussinessMasterDT = new CloudAccountDA.BussinessMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    protected ToolkitScriptManager tsm;
    protected HtmlGenericControl divInfo;
    protected HtmlGenericControl divUpdate;
    protected Panel pnlAdd;
    protected UpdatePanel upCompany;
    protected TextBox txtCompanyName;
    protected RequiredFieldValidator rfvCompanyName;
    protected TextBox txtCompanyUserName;
    protected RequiredFieldValidator rfvCompanyUserName;
    protected DropDownList ddlBussiness;
    protected DropDownList ddlIndustry;
    protected DropDownList ddlCurrency;
    protected SqlDataSource sqldsCurrency;
    protected DropDownList ddlCountry;
    protected TextBox txtAddress1;
    protected TextBox txtAddress2;
    protected DropDownList ddlState;
    protected DropDownList ddlCity;
    protected TextBox txtZipCode;
    protected TextBox txtEmail;
    protected RequiredFieldValidator rfvEmail;
    protected RegularExpressionValidator revtxtEmailAddress;
    protected TextBox txtPhoneNumber;
    protected TextBox txtFaxNumber;
    protected TextBox txtNotes;
    protected Button btnUpdate;
    protected Button btnCancel;
    protected SqlDataSource sqldsCountry;
    protected SqlDataSource sqldsState;
    protected SqlDataSource sqldsCity;
    protected HiddenField hfCompanyID;
    protected SqlDataSource sqldsBussiness;
    protected SqlDataSource sqldsIndustry;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("setting")).Attributes.Add("style", "background-color: lightgray;");
      ((HtmlControl) this.Master.FindControl("updateCompany")).Attributes.Add("class", "active open");
      MembershipUser user = Membership.GetUser();
      if (this.IsPostBack)
        return;
      if (user != null)
      {
        string str = user.ToString();
        if (Roles.IsUserInRole(str, "Admin"))
        {
          this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(str);
          if (this.objCompanyLoginMasterDT.Rows.Count > 0)
          {
            this.hfCompanyID.Value = this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString();
            this.SetRecord(this.hfCompanyID.Value);
            this.pnlAdd.Visible = true;
          }
        }
        else
        {
          this.Response.Redirect("../MemberArea.aspx");
          this.pnlAdd.Visible = false;
        }
      }
      this.divUpdate.Visible = this.Session["update"] != null;
      this.Session.Abandon();
    }

    private void SetRecord(string iD)
    {
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(iD));
      if (this.objCompanyMasterDT.Rows.Count <= 0)
        return;
      this.hfCompanyID.Value = this.objCompanyMasterDT.Rows[0]["CompanyID"].ToString();
      this.txtCompanyName.Text = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
      this.txtCompanyUserName.Text = this.objCompanyMasterDT.Rows[0]["CompanyUserName"].ToString();
      this.txtPhoneNumber.Text = this.objCompanyMasterDT.Rows[0]["CompanyPhone"].ToString();
      this.txtFaxNumber.Text = this.objCompanyMasterDT.Rows[0]["CompanyFax"].ToString();
      this.txtEmail.Text = this.objCompanyMasterDT.Rows[0]["CompanyEmail"].ToString();
      this.txtAddress1.Text = this.objCompanyMasterDT.Rows[0]["CompanyAddressStreet1"].ToString();
      this.txtAddress2.Text = this.objCompanyMasterDT.Rows[0]["CompanyAddressStreet2"].ToString();
      this.txtZipCode.Text = this.objCompanyMasterDT.Rows[0]["CompanyZipCode"].ToString();
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
      if (!string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CurrencyID"].ToString()))
      {
        this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(this.objCompanyMasterDT.Rows[0]["CurrencyID"].ToString()));
        if (this.objCurrencyMasterDT.Rows.Count > 0)
        {
          this.ddlCurrency.Items.Add(this.objCurrencyMasterDT.Rows[0]["CurrencyID"].ToString());
          this.ddlCurrency.SelectedValue = this.objCurrencyMasterDT.Rows[0]["CurrencyID"].ToString();
        }
      }
      this.txtCompanyUserName.Enabled = false;
      this.txtEmail.Enabled = false;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
      try
      {
        if (!this.Page.IsValid)
          return;
        if (this.txtCompanyName.Text.Trim().Length > 0 && this.txtEmail.Text.Trim().Length > 0)
        {
          int? iCountryID = new int?();
          int? iStateID = new int?();
          int? iCityID = new int?();
          int? iBussinessID = new int?();
          int? iIndustryID = new int?();
          int? iCurrencyID = new int?();
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
          if (this.ddlCurrency.SelectedIndex > 0)
            iCurrencyID = new int?(int.Parse(this.ddlCurrency.SelectedItem.Value));
          bool flag = this.objCompanyMasterBll.UpdateCompanyDetails(int.Parse(this.hfCompanyID.Value.Trim()), this.txtCompanyName.Text.Trim(), iBussinessID, iIndustryID, iCurrencyID, this.txtPhoneNumber.Text.Trim(), this.txtFaxNumber.Text.Trim(), this.txtEmail.Text.Trim(), this.txtAddress1.Text.Trim(), this.txtAddress2.Text.Trim(), iCountryID, iStateID, iCityID, this.txtZipCode.Text.Trim(), this.txtNotes.Text.Trim(), "", false, "");
          this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(this.txtCompanyUserName.Text);
          if (this.objCompanyLoginMasterDT.Rows.Count > 0)
            this.objCompanyLoginMasterBll.UpdateCompanyLogin(Convert.ToInt32(this.objCompanyLoginMasterDT.Rows[0]["CompanyLoginID"].ToString()), int.Parse(this.hfCompanyID.Value.Trim()), this.txtCompanyUserName.Text.Trim(), this.txtEmail.Text.Trim(), true);
          if (flag)
          {
            this.Session["update"] = (object) 1;
            this.DisplayAlert("Update Successfully..");
            this.Response.Redirect("~/BillTransact/UpdateCompanyDetail.aspx");
          }
          else
            this.DisplayAlert("Fail to Update New Details..!");
        }
        else
          this.DisplayAlert("Please Fill All Details...!");
      }
      catch (Exception ex)
      {
        this.DisplayAlert(ex.Message);
      }
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
        this.ddlBussiness.Focus();
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
        this.ddlBussiness.Focus();
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
        this.txtPhoneNumber.Focus();
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

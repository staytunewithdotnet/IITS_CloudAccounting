// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Accountant.AccountantProfile
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using DABL.BLL;
using DABL.DAL;
using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Accountant
{
  public class AccountantProfile : Page
  {
    private readonly AccountantMasterBLL objAccountantMasterBll = new AccountantMasterBLL();
    private CloudAccountDA.AccountantMasterDataTable objAccountantMasterDT = new CloudAccountDA.AccountantMasterDataTable();
    private readonly CityMasterBLL objCityMasterBll = new CityMasterBLL();
    private CloudAccountDA.CityMasterDataTable objCityMasterDT = new CloudAccountDA.CityMasterDataTable();
    private readonly CountryMasterBLL objCountryMasterBll = new CountryMasterBLL();
    private CloudAccountDA.CountryMasterDataTable objCountryMasterDT = new CloudAccountDA.CountryMasterDataTable();
    private readonly StateMasterBLL objStateMasterBll = new StateMasterBLL();
    private CloudAccountDA.StateMasterDataTable objStateMasterDT = new CloudAccountDA.StateMasterDataTable();
    protected Panel pnlRegister;
    protected TextBox txtFirstName;
    protected RequiredFieldValidator rfvFirstName;
    protected TextBox txtLastName;
    protected RequiredFieldValidator rfvLastName;
    protected TextBox txtEmail;
    protected TextBox txtPhone;
    protected RequiredFieldValidator rfvPhone;
    protected TextBox txtCompanyName;
    protected TextBox txtAddress;
    protected UpdatePanel upAddress;
    protected DropDownList ddlCountry;
    protected SqlDataSource sqldsCountry;
    protected DropDownList ddlState;
    protected SqlDataSource sqldsState;
    protected DropDownList ddlCity;
    protected SqlDataSource sqldsCity;
    protected TextBox txtZipCode;
    protected TextBox txtPassword;
    protected RequiredFieldValidator rfvPassword;
    protected TextBox txtConPassword;
    protected RequiredFieldValidator rfvConPassword;
    protected CompareValidator cvConPassword;
    protected TextBox txtProfession;
    protected TextBox txtDesignation;
    protected Button btnUpdate;
    protected HiddenField hfEmail;
    protected HiddenField hfAccountantID;

    protected void Page_Load(object sender, EventArgs e)
    {
      MembershipUser user = Membership.GetUser();
      if (user != null)
      {
        string str = user.ToString();
        if (Roles.IsUserInRole(str, "Accountant"))
        {
          this.objAccountantMasterDT = this.objAccountantMasterBll.GetDataByAccountantEmail(str);
          if (this.objAccountantMasterDT.Rows.Count > 0)
            this.hfAccountantID.Value = this.objAccountantMasterDT.Rows[0]["AccountantID"].ToString();
        }
      }
      if (this.IsPostBack)
        return;
      this.ViewRecord();
    }

    private void ViewRecord()
    {
      this.objAccountantMasterDT = this.objAccountantMasterBll.GetDataByAccountantID(int.Parse(this.hfAccountantID.Value));
      if (this.objAccountantMasterDT.Rows.Count <= 0)
        return;
      this.hfAccountantID.Value = this.objAccountantMasterDT.Rows[0]["AccountantID"].ToString();
      this.txtFirstName.Text = this.objAccountantMasterDT.Rows[0]["AccountantFirstName"].ToString();
      this.txtLastName.Text = this.objAccountantMasterDT.Rows[0]["AccountantLastName"].ToString();
      this.txtEmail.Text = this.objAccountantMasterDT.Rows[0]["AccountantEmail"].ToString();
      this.txtPhone.Text = this.objAccountantMasterDT.Rows[0]["AccountantPhone"].ToString();
      this.txtCompanyName.Text = this.objAccountantMasterDT.Rows[0]["CompanyName"].ToString();
      this.txtAddress.Text = this.objAccountantMasterDT.Rows[0]["Address1"].ToString();
      this.txtProfession.Text = this.objAccountantMasterDT.Rows[0]["AccountantProfession"].ToString();
      this.txtDesignation.Text = this.objAccountantMasterDT.Rows[0]["AccountantDesignation"].ToString();
      this.txtZipCode.Text = this.objAccountantMasterDT.Rows[0]["ZipCode"].ToString();
      string s1 = this.objAccountantMasterDT.Rows[0]["CountryID"].ToString();
      string s2 = this.objAccountantMasterDT.Rows[0]["StateID"].ToString();
      string s3 = this.objAccountantMasterDT.Rows[0]["CityID"].ToString();
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
      if (string.IsNullOrEmpty(s3))
        return;
      this.objCityMasterDT = this.objCityMasterBll.GetDataByCityID(int.Parse(s3));
      if (this.objCityMasterDT.Rows.Count <= 0)
        return;
      this.ddlCity.Items.Add(this.objCityMasterDT.Rows[0]["CityID"].ToString());
      this.ddlCity.SelectedValue = this.objCityMasterDT.Rows[0]["CityID"].ToString();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
      if (this.Page.IsValid)
        return;
      int? iCountryID = new int?();
      int? iStateID = new int?();
      int? iCityID = new int?();
      if (this.ddlCountry.SelectedIndex > 0)
        iCountryID = new int?(int.Parse(this.ddlCountry.SelectedItem.Value));
      if (this.ddlState.SelectedIndex > 0)
        iStateID = new int?(int.Parse(this.ddlState.SelectedItem.Value));
      if (this.ddlCity.SelectedIndex > 0)
        iCityID = new int?(int.Parse(this.ddlCity.SelectedItem.Value));
      this.objAccountantMasterBll.UpdateAccountant(int.Parse(this.hfAccountantID.Value), this.txtFirstName.Text.Trim(), this.txtLastName.Text.Trim(), this.hfEmail.Value, this.txtPhone.Text.Trim(), this.txtCompanyName.Text.Trim(), this.txtAddress.Text.Trim(), "", iCountryID, iStateID, iCityID, this.txtZipCode.Text.Trim(), this.txtProfession.Text.Trim(), this.txtDesignation.Text.Trim());
      this.Response.Redirect("AccountantProfile.aspx");
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Client.ClientProfile
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using DABL.BLL;
using DABL.Common;
using DABL.DAL;
using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Client
{
    public class ClientProfile : Page
    {
        private readonly CompanyClientMasterBLL objCompanyClientMasterBll = new CompanyClientMasterBLL();
        private CloudAccountDA.CompanyClientMasterDataTable objCompanyClientMasterDT = new CloudAccountDA.CompanyClientMasterDataTable();
        private readonly CityMasterBLL objCityMasterBll = new CityMasterBLL();
        private CloudAccountDA.CityMasterDataTable objCityMasterDT = new CloudAccountDA.CityMasterDataTable();
        private readonly CountryMasterBLL objCountryMasterBll = new CountryMasterBLL();
        private CloudAccountDA.CountryMasterDataTable objCountryMasterDT = new CloudAccountDA.CountryMasterDataTable();
        private readonly StateMasterBLL objStateMasterBll = new StateMasterBLL();
        private CloudAccountDA.StateMasterDataTable objStateMasterDT = new CloudAccountDA.StateMasterDataTable();
        private readonly CompanyClientContactDetailBLL objCompanyClientContactDetailBll = new CompanyClientContactDetailBLL();
        private CloudAccountDA.CompanyClientContactDetailDataTable objCompanyClientContactDetailDT = new CloudAccountDA.CompanyClientContactDetailDataTable();
        private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
        private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
        private readonly ContractorMasterBLL objContractorMasterBll = new ContractorMasterBLL();
        private CloudAccountDA.ContractorMasterDataTable objContractorMasterDT = new CloudAccountDA.ContractorMasterDataTable();
        private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
        private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
        private readonly UserBLL objUserBll = new UserBLL();
        private CloudAccountDA.aspnet_UsersDataTable objUserDT = new CloudAccountDA.aspnet_UsersDataTable();
        protected HtmlGenericControl divUpdate;
        protected UpdatePanel upBoth;
        protected TextBox txtEmail;
        protected RequiredFieldValidator rfvEmail;
        protected RegularExpressionValidator revEmail;
        protected TextBox txtFirstName;
        protected TextBox txtLastName;
        protected TextBox txtHomePhone;
        protected TextBox txtMobile;
        protected TextBox txtUsername;
        protected Label lblUsernameAdd;
        protected TextBox txtPassword;
        protected Label lblPasswordAdd;
        protected TextBox txtNewPassword;
        protected TextBox txtConfPassword;
        protected Panel pnlAddClient;
        protected UpdatePanel upCompany;
        protected TextBox txtBussinessPhone;
        protected TextBox txtFax;
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
        protected Button btnSave;
        protected HiddenField hfCompanyID;
        protected HiddenField hfClientID;
        protected HiddenField hfClientContactID;
        protected SqlDataSource sqldsCountry;
        protected SqlDataSource sqldsState;
        protected SqlDataSource sqldsCity;
        protected SqlDataSource sqldsSecondaryCountry;
        protected SqlDataSource sqldsSecondaryState;
        protected SqlDataSource sqldsSecondaryCity;

        protected TextBox txtCardNo;
        protected TextBox txtPIN;

        private Dbutility objDbutility;

        protected void Page_Load(object sender, EventArgs e)
        {
            objDbutility = new Dbutility();

            if (this.Master == null)
                return;
            ((HtmlControl)this.Master.FindControl("clientProfile")).Attributes.Add("style", "background-color: lightgray;");
            MembershipUser user = Membership.GetUser();
            if (user != null)
            {
                this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByUsername(user.ToString());
                if (this.objCompanyClientMasterDT.Rows.Count > 0)
                {
                    this.hfClientID.Value = this.objCompanyClientMasterDT.Rows[0]["CompanyClientID"].ToString();
                    this.hfCompanyID.Value = this.objCompanyClientMasterDT.Rows[0]["CompanyID"].ToString();
                    this.pnlAddClient.Visible = true;
                    this.ViewClientDetails(this.hfClientID.Value);
                }
                this.objCompanyClientContactDetailDT = this.objCompanyClientContactDetailBll.GetDataByUsername(user.ToString());
                if (this.objCompanyClientContactDetailDT.Rows.Count > 0)
                {
                    this.hfClientContactID.Value = this.objCompanyClientContactDetailDT.Rows[0]["CompanyClientContactID"].ToString();
                    this.hfClientID.Value = this.objCompanyClientContactDetailDT.Rows[0]["CompanyClientID"].ToString();
                    this.hfCompanyID.Value = this.objCompanyClientContactDetailDT.Rows[0]["CompanyID"].ToString();
                    this.pnlAddClient.Visible = false;
                    this.ViewClientContactDetails(this.hfClientContactID.Value);
                }
            }
            if (this.IsPostBack)
                return;
            this.divUpdate.Visible = this.Session["updateProfile"] != null;
            this.Session["updateProfile"] = (object)null;
            this.Session.Abandon();
        }

        private void ViewClientContactDetails(string cId)
        {
            this.objCompanyClientContactDetailDT = this.objCompanyClientContactDetailBll.GetDataByCompanyClientContactID(int.Parse(cId));
            if (this.objCompanyClientContactDetailDT.Rows.Count <= 0)
                return;
            this.hfClientContactID.Value = this.objCompanyClientContactDetailDT.Rows[0]["CompanyClientContactID"].ToString();
            this.hfClientID.Value = this.objCompanyClientContactDetailDT.Rows[0]["CompanyClientID"].ToString();
            this.hfCompanyID.Value = this.objCompanyClientContactDetailDT.Rows[0]["CompanyID"].ToString();
            this.txtEmail.Text = this.objCompanyClientContactDetailDT.Rows[0]["Email"].ToString();
            this.txtFirstName.Text = this.objCompanyClientContactDetailDT.Rows[0]["FirstName"].ToString();
            this.txtLastName.Text = this.objCompanyClientContactDetailDT.Rows[0]["LastName"].ToString();
            this.txtHomePhone.Text = this.objCompanyClientContactDetailDT.Rows[0]["HomePhone"].ToString();
            this.txtMobile.Text = this.objCompanyClientContactDetailDT.Rows[0]["Mobile"].ToString();
            this.txtUsername.Text = this.objCompanyClientContactDetailDT.Rows[0]["UserName"].ToString();
            MembershipUser user = Membership.GetUser(this.txtUsername.Text);
            if (user != null)
                this.lblPasswordAdd.Text = user.GetPassword();
            this.txtUsername.Enabled = false;
            this.txtEmail.Enabled = false;
        }

        private void ViewClientDetails(string clientID)
        {
            this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(clientID));
            if (this.objCompanyClientMasterDT.Rows.Count <= 0)
                return;
            this.hfClientID.Value = this.objCompanyClientMasterDT.Rows[0]["CompanyClientID"].ToString();
            this.hfCompanyID.Value = this.objCompanyClientMasterDT.Rows[0]["CompanyID"].ToString();
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
            MembershipUser user = Membership.GetUser(this.txtUsername.Text);
            if (user != null)
                this.lblPasswordAdd.Text = user.GetPassword();
            string s1 = this.objCompanyClientMasterDT.Rows[0]["CountryID"].ToString();
            string s2 = this.objCompanyClientMasterDT.Rows[0]["StateID"].ToString();
            string s3 = this.objCompanyClientMasterDT.Rows[0]["CityID"].ToString();
            string s4 = this.objCompanyClientMasterDT.Rows[0]["SecondaryCountryID"].ToString();
            string s5 = this.objCompanyClientMasterDT.Rows[0]["SecondaryStateID"].ToString();
            string s6 = this.objCompanyClientMasterDT.Rows[0]["SecondaryCityID"].ToString();
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
            if (!string.IsNullOrEmpty(s4))
            {
                this.objCountryMasterDT = this.objCountryMasterBll.GetDataByCountryID(int.Parse(s4));
                if (this.objCountryMasterDT.Rows.Count > 0)
                {
                    this.ddlCountrySecondary.Items.Add(this.objCountryMasterDT.Rows[0]["CountryID"].ToString());
                    this.ddlCountrySecondary.SelectedValue = this.objCountryMasterDT.Rows[0]["CountryID"].ToString();
                }
            }
            if (!string.IsNullOrEmpty(s5))
            {
                this.objStateMasterDT = this.objStateMasterBll.GetDataByStateID(int.Parse(s5));
                if (this.objStateMasterDT.Rows.Count > 0)
                {
                    this.ddlStateSecondary.Items.Add(this.objStateMasterDT.Rows[0]["StateID"].ToString());
                    this.ddlStateSecondary.SelectedValue = this.objStateMasterDT.Rows[0]["StateID"].ToString();
                }
            }
            if (!string.IsNullOrEmpty(s6))
            {
                this.objCityMasterDT = this.objCityMasterBll.GetDataByCityID(int.Parse(s6));
                if (this.objCityMasterDT.Rows.Count > 0)
                {
                    this.ddlCitySecondary.Items.Add(this.objCityMasterDT.Rows[0]["CityID"].ToString());
                    this.ddlCitySecondary.SelectedValue = this.objCityMasterDT.Rows[0]["CityID"].ToString();
                }
            }
            this.txtUsername.Enabled = false;
            this.txtEmail.Enabled = false;
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
                this.DisplayAlert("Email Already Register With System.");
                ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Email Already Register With System.')", true);
                this.txtEmail.Text = "";
                this.txtEmail.Focus();
            }
            else if (this.objCompanyClientMasterDT.Rows.Count > 0 || this.objCompanyClientContactDetailDT.Rows.Count > 0)
            {
                this.DisplayAlert("Email Already Register With System To Some Client.");
                ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Email Already Register With System To Some Client.')", true);
                this.txtEmail.Text = "";
                this.txtEmail.Focus();
            }
            else if (this.objStaffMasterDT.Rows.Count > 0)
            {
                this.DisplayAlert("Email Already Register With System To Some Staff.");
                ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Email Already Register With System To Some Staff.')", true);
                this.txtEmail.Text = "";
                this.txtEmail.Focus();
            }
            else if (this.objContractorMasterDT.Rows.Count > 0)
            {
                this.DisplayAlert("Email Already Register With System To Some Contractor.");
                ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Email Already Register With System To Some Contractor.')", true);
                this.txtEmail.Text = "";
                this.txtEmail.Focus();
            }
            else
                this.txtFirstName.Focus();
        }

        public void DisplayAlert(string message)
        {
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">" + this.GetAlertScript(message) + "</script>");
        }

        public string GetAlertScript(string message)
        {
            return "alert('" + message.Replace("'", "\\'") + "');";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.pnlAddClient.Visible)
            {
                try
                {
                    if (!this.Page.IsValid)
                        return;
                    if (this.txtEmail.Text.Trim().Length > 0)
                    {
                        int? iCountryID = new int?();
                        int? iStateID = new int?();
                        int? iCityID = new int?();
                        int? iSecondaryCountryID = new int?();
                        int? iSecondaryStateID = new int?();
                        int? iSecondaryCityID = new int?();
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
                        if (this.txtNewPassword.Text.Trim().Length >= 4)
                        {
                            if (this.txtNewPassword.Text.Trim() == this.txtConfPassword.Text.Trim())
                            {
                                MembershipUser user = Membership.GetUser(this.txtUsername.Text);
                                if (user != null)
                                {
                                    user.ChangePassword(this.lblPasswordAdd.Text.Trim(), this.txtNewPassword.Text.Trim());
                                    this.lblPasswordAdd.Text = this.txtNewPassword.Text.Trim();
                                    Membership.UpdateUser(user);
                                }
                            }
                            else
                                this.DisplayAlert("Password & confirm password not match");
                        }
                        if (this.objCompanyClientMasterBll.UpdateClientProfile(int.Parse(this.hfClientID.Value), int.Parse(this.hfCompanyID.Value), this.txtEmail.Text, this.txtFirstName.Text.Trim(), this.txtLastName.Text.Trim(), this.txtHomePhone.Text.Trim(), this.txtMobile.Text.Trim(), this.txtUsername.Text.Trim(), this.txtAddress1.Text.Trim(), this.txtAddress2.Text.Trim(), iCountryID, iStateID, iCityID, this.txtZipCode.Text.Trim(), this.txtAddress1Secondary.Text.Trim(), this.txtAddress2Secondary.Text.Trim(), iSecondaryCountryID, iSecondaryStateID, iSecondaryCityID, this.txtZipCodeSecondary.Text.Trim(), this.txtBussinessPhone.Text.Trim(), this.txtFax.Text.Trim()))
                        {                           
                            string result = objDbutility.ExecuteQuery("Update CompanyClientMaster Set CardNumber='" + txtCardNo.Text.Trim() + "', PinNumber='"
                                   + txtPIN.Text.Trim() + "' Where CompanyClientID=" + hfClientID.Value.Trim());
                            if (string.IsNullOrEmpty(result))
                            {

                                this.Session["updateProfile"] = (object)1;
                                this.DisplayAlert("Profile is updated successfully");
                                this.Response.Redirect("~/Client/ClientProfile.aspx");
                            }
                        }
                        else
                            this.DisplayAlert("Some error occured while updating your profile please try after sometime..!");
                    }
                    else
                        this.DisplayAlert("Fill All Required Feilds");
                }
                catch (Exception ex)
                {
                    this.DisplayAlert(ex.Message);
                }
            }
            else
            {
                try
                {
                    if (!this.Page.IsValid)
                        return;
                    if (this.txtEmail.Text.Trim().Length > 0)
                    {
                        if (this.txtNewPassword.Text.Trim().Length >= 4)
                        {
                            if (this.txtNewPassword.Text.Trim() == this.txtConfPassword.Text.Trim())
                            {
                                MembershipUser user = Membership.GetUser(this.txtUsername.Text);
                                if (user != null)
                                {
                                    user.ChangePassword(this.lblPasswordAdd.Text.Trim(), this.txtNewPassword.Text.Trim());
                                    this.lblPasswordAdd.Text = this.txtNewPassword.Text.Trim();
                                    Membership.UpdateUser(user);
                                }
                            }
                            else
                                this.DisplayAlert("Password & confirm password not match");
                        }
                        this.objCompanyClientContactDetailDT = this.objCompanyClientContactDetailBll.GetDataByCompanyClientContactID(int.Parse(this.hfClientContactID.Value));
                        if (this.objCompanyClientContactDetailBll.UpdateCompanyClientContact(int.Parse(this.hfClientContactID.Value), int.Parse(this.hfCompanyID.Value), int.Parse(this.hfClientID.Value), this.txtEmail.Text.Trim(), this.txtFirstName.Text.Trim(), this.txtLastName.Text.Trim(), this.txtHomePhone.Text.Trim(), this.txtMobile.Text.Trim(), bool.Parse(this.objCompanyClientContactDetailDT.Rows[0]["LoginCredentials"].ToString()), this.txtUsername.Text.Trim(), bool.Parse(this.objCompanyClientContactDetailDT.Rows[0]["LoginInfoSent"].ToString())))
                        {
                            this.Session["updateProfile"] = (object)1;
                            this.DisplayAlert("Profile is updated successfully");
                            this.Response.Redirect("~/Client/ClientProfile.aspx");
                        }
                        else
                            this.DisplayAlert("Some error occured while updating your profile please try after sometime..!");
                    }
                    else
                        this.DisplayAlert("Fill All Required Feilds");
                }
                catch (Exception ex)
                {
                    this.DisplayAlert(ex.Message);
                }
            }
        }
    }
}

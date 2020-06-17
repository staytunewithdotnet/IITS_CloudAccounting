// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.UpdateStaffProfile
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
  public class UpdateStaffProfile : Page
  {
    private readonly CityMasterBLL objCityMasterBll = new CityMasterBLL();
    private CloudAccountDA.CityMasterDataTable objCityMasterDT = new CloudAccountDA.CityMasterDataTable();
    private readonly CountryMasterBLL objCountryMasterBll = new CountryMasterBLL();
    private CloudAccountDA.CountryMasterDataTable objCountryMasterDT = new CloudAccountDA.CountryMasterDataTable();
    private readonly StateMasterBLL objStateMasterBll = new StateMasterBLL();
    private CloudAccountDA.StateMasterDataTable objStateMasterDT = new CloudAccountDA.StateMasterDataTable();
    private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
    private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
    protected ToolkitScriptManager tsm;
    protected HtmlGenericControl divUpdate;
    protected Panel pnlAdd;
    protected UpdatePanel upCompany;
    protected TextBox txtStaffEmail;
    protected RequiredFieldValidator rfvStaffEmail;
    protected RegularExpressionValidator revEmail;
    protected TextBox txtStaffFirstName;
    protected RequiredFieldValidator rfvStaffFirstName;
    protected TextBox txtStaffLastName;
    protected RequiredFieldValidator rfvStaffLastName;
    protected TextBox txtUsername;
    protected RequiredFieldValidator rfvUsername;
    protected TextBox txtCurrentPassword;
    protected TextBox txtNewPassword;
    protected TextBox txtConfirmPassword;
    protected CompareValidator cvPassword;
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
    protected Button btnSave;
    protected HiddenField hfCompanyID;
    protected HiddenField hfStaffID;
    protected SqlDataSource sqldsCountry;
    protected SqlDataSource sqldsState;
    protected SqlDataSource sqldsCity;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("staffProfile")).Attributes.Add("style", "background-color: lightgray;");
      MembershipUser user = Membership.GetUser();
      if (this.IsPostBack)
        return;
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
            this.SetRecord(this.hfStaffID.Value);
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
      string s1 = this.objStaffMasterDT.Rows[0]["CountryID"].ToString();
      string s2 = this.objStaffMasterDT.Rows[0]["StateID"].ToString();
      string s3 = this.objStaffMasterDT.Rows[0]["CityID"].ToString();
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
      this.txtUsername.Enabled = false;
      this.txtStaffEmail.Enabled = false;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
      try
      {
        if (!this.Page.IsValid)
          return;
        this.objStaffMasterDT = this.objStaffMasterBll.GetDataByStaffID(int.Parse(this.hfStaffID.Value));
        bool bActive = (bool) this.objStaffMasterDT.Rows[0]["Active"];
        bool bArchived = (bool) this.objStaffMasterDT.Rows[0]["Archived"];
        bool bDeleted = (bool) this.objStaffMasterDT.Rows[0]["Deleted"];
        string sNotes = this.objStaffMasterDT.Rows[0]["Notes"].ToString();
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
        string s = this.objStaffMasterDT.Rows[0]["BillingRate"].ToString();
        if (!string.IsNullOrEmpty(s))
          dBillingRate = new Decimal?(Decimal.Parse(s));
        if (this.txtCurrentPassword.Text.Trim().Length > 0 && this.txtCurrentPassword.Text.Trim().Length > 4 && this.txtCurrentPassword.Text.Trim().Length > 4)
        {
          MembershipUser user = Membership.GetUser();
          if (user != null)
            user.ChangePassword(this.txtCurrentPassword.Text.Trim(), this.txtNewPassword.Text.Trim());
        }
        if (this.objStaffMasterBll.UpdateStaff(int.Parse(this.hfStaffID.Value), int.Parse(this.hfCompanyID.Value), this.txtStaffEmail.Text.Trim(), this.txtStaffFirstName.Text.Trim(), this.txtStaffLastName.Text.Trim(), dBillingRate, this.txtUsername.Text.Trim(), this.txtAddress1.Text.Trim(), this.txtAddress2.Text.Trim(), iCountryID, iStateID, iCityID, this.txtZipCode.Text.Trim(), this.txtHomePhone.Text.Trim(), this.txtMobile.Text.Trim(), this.txtBussinessPhone.Text.Trim(), this.txtFax.Text.Trim(), sNotes, bActive, bArchived, bDeleted))
        {
          this.Session["update"] = (object) 1;
          this.DisplayAlert("Update Successfully..");
          this.Response.Redirect("~/Admin/UpdateStaffProfile.aspx");
        }
        else
          this.DisplayAlert("Fail to Update Details.");
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
  }
}

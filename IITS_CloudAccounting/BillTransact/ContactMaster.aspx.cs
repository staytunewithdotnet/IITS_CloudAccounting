// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.ContactMaster
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
  public class ContactMaster : Page
  {
    private static string AddStatus = string.Empty;
    private static string EditStatus = string.Empty;
    private static string ViewStatus = string.Empty;
    private static string DeleteStatus = string.Empty;
    private readonly CityMasterBLL objCityMasterBll = new CityMasterBLL();
    private CloudAccountDA.CityMasterDataTable objCityMasterDT = new CloudAccountDA.CityMasterDataTable();
    private readonly CountryMasterBLL objCountryMasterBll = new CountryMasterBLL();
    private CloudAccountDA.CountryMasterDataTable objCountryMasterDT = new CloudAccountDA.CountryMasterDataTable();
    private readonly StateMasterBLL objStateMasterBll = new StateMasterBLL();
    private CloudAccountDA.StateMasterDataTable objStateMasterDT = new CloudAccountDA.StateMasterDataTable();
    private readonly ContactMasterBLL objContactMasterBll = new ContactMasterBLL();
    private CloudAccountDA.ContactMasterDataTable objContactMasterDT = new CloudAccountDA.ContactMasterDataTable();
    private readonly MasterAdminRightsMasterBLL objMasterAdminRightsMasterBll = new MasterAdminRightsMasterBLL();
    private CloudAccountDA.MasterAdminRightsMasterDataTable objMasterAdminRightsMasterDT = new CloudAccountDA.MasterAdminRightsMasterDataTable();
    private readonly MasterAdminLoginMasterBLL objMasterAdminLoginMasterBll = new MasterAdminLoginMasterBLL();
    private CloudAccountDA.MasterAdminLoginMasterDataTable objMasterAdminLoginMasterDT = new CloudAccountDA.MasterAdminLoginMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyAdminRightsMasterBLL objCompanyAdminRightsMasterBll = new CompanyAdminRightsMasterBLL();
    private CloudAccountDA.CompanyAdminRightsMasterDataTable objCompanyAdminRightsMasterDT = new CloudAccountDA.CompanyAdminRightsMasterDataTable();
    protected ToolkitScriptManager tsm;
    protected Panel pnlAdd;
    protected TextBox txtCompanyName;
    protected RequiredFieldValidator rfvCompanyName;
    protected TextBox txtContactPerson;
    protected TextBox txtAddress1;
    protected RequiredFieldValidator rfvAddress1;
    protected TextBox txtAddress2;
    protected RequiredFieldValidator rfvtxtAddress2;
    protected TextBox txtAddress3;
    protected TextBox txtAddress4;
    protected TextBox txtZipCode;
    protected RequiredFieldValidator rfvZipCode;
    protected UpdatePanel upCountry;
    protected DropDownList ddlCountry;
    protected SqlDataSource sqldsCountry;
    protected RequiredFieldValidator rfvCountryName;
    protected DropDownList ddlState;
    protected SqlDataSource sqldsState;
    protected RequiredFieldValidator rfvCurrentState;
    protected DropDownList ddlCity;
    protected SqlDataSource sqldsCity;
    protected RequiredFieldValidator rfvCurrentCity;
    protected TextBox txtPhone1;
    protected RequiredFieldValidator rfvPhone1;
    protected TextBox txtPhone2;
    protected TextBox txtMobile1;
    protected RequiredFieldValidator rfvMobile1;
    protected TextBox txtMobile2;
    protected TextBox txtEmail1;
    protected RequiredFieldValidator rfvEmail1;
    protected TextBox txtEmail2;
    protected TextBox txtFax1;
    protected RequiredFieldValidator rfvFax1;
    protected TextBox txtFax2;
    protected TextBox txtWebsite;
    protected RequiredFieldValidator rfvtxtWebsite;
    protected RegularExpressionValidator reftxtWebsite;
    protected TextBox txtGoogleMapCode;
    protected RequiredFieldValidator rfvGoogleMapCode;
    protected CheckBox chkStatus;
    protected Button btnSubmit;
    protected Button btnReset;
    protected Button btnUpdate;
    protected HiddenField hfContact;
    protected HiddenField hfMasterAdminID;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyLoginID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("cmsMaster")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("contactMaster")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          ContactMaster.AddStatus = "True";
          ContactMaster.EditStatus = "True";
          ContactMaster.ViewStatus = "True";
          ContactMaster.DeleteStatus = "True";
        }
        else if (Admin.RoleName == "MasterAdmin")
        {
          if (user != null)
          {
            string str = user.ToString();
            if (Roles.IsUserInRole(str, "MasterAdmin"))
            {
              this.objMasterAdminLoginMasterDT = this.objMasterAdminLoginMasterBll.GetDataByUserName(str);
              if (this.objMasterAdminLoginMasterDT.Rows.Count > 0)
                this.hfMasterAdminID.Value = this.objMasterAdminLoginMasterDT.Rows[0]["MasterAdminUserID"].ToString();
            }
          }
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "ContactMaster");
          if (this.objMasterAdminRightsMasterDT.Rows.Count > 0)
          {
            ContactMaster.AddStatus = this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            ContactMaster.EditStatus = this.objMasterAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            ContactMaster.ViewStatus = this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            ContactMaster.DeleteStatus = this.objMasterAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            ContactMaster.AddStatus = "";
            ContactMaster.EditStatus = "";
            ContactMaster.ViewStatus = "";
            ContactMaster.DeleteStatus = "";
          }
        }
        else if (Admin.RoleName == "Admin")
        {
          if (user != null)
          {
            string str = user.ToString();
            if (Roles.IsUserInRole(str, "Admin"))
            {
              this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(str);
              if (this.objCompanyLoginMasterDT.Rows.Count > 0)
              {
                this.hfCompanyID.Value = this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString();
                this.hfCompanyLoginID.Value = this.objCompanyLoginMasterDT.Rows[0]["CompanyLoginID"].ToString();
              }
            }
          }
          this.objCompanyAdminRightsMasterDT = this.objCompanyAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfCompanyID.Value.Trim()), int.Parse(this.hfCompanyLoginID.Value.Trim()), "ContactMaster");
          if (this.objCompanyAdminRightsMasterDT.Rows.Count > 0)
          {
            ContactMaster.AddStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            ContactMaster.EditStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            ContactMaster.ViewStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            ContactMaster.DeleteStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            ContactMaster.AddStatus = "";
            ContactMaster.EditStatus = "";
            ContactMaster.ViewStatus = "";
            ContactMaster.DeleteStatus = "";
          }
        }
        else
        {
          ContactMaster.AddStatus = "";
          ContactMaster.EditStatus = "";
          ContactMaster.ViewStatus = "";
          ContactMaster.DeleteStatus = "";
        }
      }
      if (ContactMaster.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] == null || !(ContactMaster.ViewStatus == "True"))
                break;
              this.pnlAdd.Visible = false;
              this.btnUpdate.Visible = false;
              break;
            case "add":
              if (this.Request.QueryString["ID"] != null)
              {
                if (!(ContactMaster.EditStatus == "True"))
                  break;
                this.SetRecord(this.Request.QueryString["ID"]);
                this.pnlAdd.Visible = true;
                this.btnUpdate.Visible = true;
                this.btnSubmit.Visible = false;
                this.btnReset.Visible = false;
                break;
              }
              if (!(ContactMaster.AddStatus == "True"))
                break;
              this.Clear();
              this.btnSubmit.Visible = true;
              this.btnReset.Visible = true;
              this.btnUpdate.Visible = false;
              this.pnlAdd.Visible = true;
              break;
            default:
              this.GotoPage();
              this.pnlAdd.Visible = false;
              break;
          }
        }
        else
        {
          this.GotoPage();
          this.pnlAdd.Visible = false;
        }
      }
      else if (ContactMaster.AddStatus == "True" && ContactMaster.EditStatus == "False" && (ContactMaster.ViewStatus == "False" && ContactMaster.DeleteStatus == "False"))
      {
        this.pnlAdd.Visible = true;
        this.btnUpdate.Visible = false;
      }
      else
        this.pnlAdd.Visible = false;
    }

    private void SetRecord(string iD)
    {
      this.objContactMasterDT = this.objContactMasterBll.GetDataByContactID(int.Parse(iD));
      if (this.objContactMasterDT.Rows.Count <= 0)
        return;
      this.hfContact.Value = this.objContactMasterDT.Rows[0]["ContactID"].ToString();
      this.txtCompanyName.Text = this.objContactMasterDT.Rows[0]["CompanyName"].ToString();
      this.txtContactPerson.Text = this.objContactMasterDT.Rows[0]["ContactPerson"].ToString();
      this.txtAddress1.Text = this.objContactMasterDT.Rows[0]["Address1"].ToString();
      this.txtAddress2.Text = this.objContactMasterDT.Rows[0]["Address2"].ToString();
      this.txtAddress3.Text = this.objContactMasterDT.Rows[0]["Address3"].ToString();
      this.txtAddress4.Text = this.objContactMasterDT.Rows[0]["Address4"].ToString();
      this.txtZipCode.Text = this.objContactMasterDT.Rows[0]["ZipCode"].ToString();
      this.txtPhone1.Text = this.objContactMasterDT.Rows[0]["Phone1"].ToString();
      this.txtPhone2.Text = this.objContactMasterDT.Rows[0]["Phone2"].ToString();
      this.txtMobile1.Text = this.objContactMasterDT.Rows[0]["Mobile1"].ToString();
      this.txtMobile2.Text = this.objContactMasterDT.Rows[0]["Mobile2"].ToString();
      this.txtFax1.Text = this.objContactMasterDT.Rows[0]["Fax1"].ToString();
      this.txtFax2.Text = this.objContactMasterDT.Rows[0]["Fax2"].ToString();
      this.txtEmail1.Text = this.objContactMasterDT.Rows[0]["Email1"].ToString();
      this.txtEmail2.Text = this.objContactMasterDT.Rows[0]["Email2"].ToString();
      this.txtWebsite.Text = this.objContactMasterDT.Rows[0]["Website"].ToString();
      this.txtGoogleMapCode.Text = this.objContactMasterDT.Rows[0]["GoogleMapCode"].ToString();
      this.chkStatus.Checked = this.objContactMasterDT.Rows[0]["Status"].ToString() == "True";
      this.objCountryMasterDT = this.objCountryMasterBll.GetDataByCountryName(this.objContactMasterDT.Rows[0]["Country"].ToString());
      if (this.objCountryMasterDT.Rows.Count > 0)
      {
        this.ddlCountry.Items.Add(this.objCountryMasterDT.Rows[0]["CountryID"].ToString());
        this.ddlCountry.SelectedValue = this.objCountryMasterDT.Rows[0]["CountryID"].ToString();
      }
      this.objStateMasterDT = this.objStateMasterBll.GetDataByStateName(this.objContactMasterDT.Rows[0]["State"].ToString());
      if (this.objStateMasterDT.Rows.Count > 0)
      {
        this.ddlState.Items.Add(this.objStateMasterDT.Rows[0]["StateID"].ToString());
        this.ddlState.SelectedValue = this.objStateMasterDT.Rows[0]["StateID"].ToString();
      }
      this.objCityMasterDT = this.objCityMasterBll.GetDataByCityName(this.objContactMasterDT.Rows[0]["City"].ToString());
      if (this.objCityMasterDT.Rows.Count <= 0)
        return;
      this.ddlCity.Items.Add(this.objCityMasterDT.Rows[0]["CityID"].ToString());
      this.ddlCity.SelectedValue = this.objCityMasterDT.Rows[0]["CityID"].ToString();
    }

    private void Clear()
    {
      this.txtCompanyName.Text = this.txtContactPerson.Text = this.txtAddress1.Text = this.txtAddress2.Text = this.txtAddress3.Text = this.txtAddress4.Text = this.txtZipCode.Text = this.txtPhone1.Text = this.txtPhone2.Text = this.txtMobile1.Text = this.txtMobile2.Text = this.txtFax1.Text = this.txtFax2.Text = this.txtEmail1.Text = this.txtEmail2.Text = this.txtWebsite.Text = this.txtGoogleMapCode.Text = "";
      this.ddlCountry.SelectedIndex = this.ddlState.SelectedIndex = this.ddlCity.SelectedIndex = 0;
      this.chkStatus.Checked = false;
      this.txtCompanyName.Focus();
    }

    private void GotoPage()
    {
      this.objContactMasterDT = this.objContactMasterBll.GetAllDetail();
      if (this.objContactMasterDT.Rows.Count > 0)
      {
        this.hfContact.Value = this.objContactMasterDT.Rows[0]["ContactID"].ToString();
        this.Response.Redirect("~/BillTransact/ContactMaster.aspx?cmd=add&ID=" + this.hfContact.Value);
      }
      else
        this.Response.Redirect("~/BillTransact/ContactMaster.aspx?cmd=add");
    }

    protected void btnAddContact_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/ContactMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      int num = this.objContactMasterBll.AddContact(this.txtCompanyName.Text.Trim(), this.txtContactPerson.Text.Trim(), this.txtAddress1.Text.Trim(), this.txtAddress2.Text.Trim(), this.txtAddress3.Text.Trim(), this.txtAddress4.Text.Trim(), this.txtZipCode.Text.Trim(), this.ddlCity.SelectedItem.Text, this.ddlState.SelectedItem.Text, this.ddlCountry.SelectedItem.Text, this.txtPhone1.Text.Trim(), this.txtPhone2.Text.Trim(), this.txtFax1.Text.Trim(), this.txtFax2.Text.Trim(), this.txtMobile1.Text.Trim(), this.txtMobile2.Text.Trim(), this.txtEmail1.Text.Trim(), this.txtEmail2.Text.Trim(), this.txtWebsite.Text.Trim(), this.txtGoogleMapCode.Text.Trim(), this.chkStatus.Checked);
      if (num != 0)
      {
        this.DisplayAlert("Details Added Successfully.");
        this.Response.Redirect("~/BillTransact/ContactMaster.aspx?cmd=add&ID=" + (object) num);
      }
      else
      {
        this.DisplayAlert("Fail to Add New Details.");
        this.Clear();
      }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.Page.IsValid)
        {
          if (this.objContactMasterBll.UpdateContact(int.Parse(this.hfContact.Value.Trim()), this.txtCompanyName.Text.Trim(), this.txtContactPerson.Text.Trim(), this.txtAddress1.Text.Trim(), this.txtAddress2.Text.Trim(), this.txtAddress3.Text.Trim(), this.txtAddress4.Text.Trim(), this.txtZipCode.Text.Trim(), this.ddlCity.SelectedItem.Text, this.ddlState.SelectedItem.Text, this.ddlCountry.SelectedItem.Text, this.txtPhone1.Text.Trim(), this.txtPhone2.Text.Trim(), this.txtFax1.Text.Trim(), this.txtFax2.Text.Trim(), this.txtMobile1.Text.Trim(), this.txtMobile2.Text.Trim(), this.txtEmail1.Text.Trim(), this.txtEmail2.Text.Trim(), this.txtWebsite.Text.Trim(), this.txtGoogleMapCode.Text.Trim(), this.chkStatus.Checked))
          {
            this.DisplayAlert("Update Successfully..");
            this.Response.Redirect("~/BillTransact/ContactMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
          }
          else
            this.DisplayAlert("Fail to Update Details.");
        }
        else
          this.DisplayAlert("Fail to Update Details.");
      }
      catch (Exception ex)
      {
        this.DisplayAlert(ex.Message);
      }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
      this.Clear();
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/ContactMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfContact.Value != null)
      {
        if (this.objContactMasterBll.DeleteContact(int.Parse(this.hfContact.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/BillTransact/ContactMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/ContactMaster.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/ContactMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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

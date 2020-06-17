// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.CityMaster
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
  public class CityMaster : Page
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
    private readonly MasterAdminRightsMasterBLL objMasterAdminRightsMasterBll = new MasterAdminRightsMasterBLL();
    private CloudAccountDA.MasterAdminRightsMasterDataTable objMasterAdminRightsMasterDT = new CloudAccountDA.MasterAdminRightsMasterDataTable();
    private readonly MasterAdminLoginMasterBLL objMasterAdminLoginMasterBll = new MasterAdminLoginMasterBLL();
    private CloudAccountDA.MasterAdminLoginMasterDataTable objMasterAdminLoginMasterDT = new CloudAccountDA.MasterAdminLoginMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyAdminRightsMasterBLL objCompanyAdminRightsMasterBll = new CompanyAdminRightsMasterBLL();
    private CloudAccountDA.CompanyAdminRightsMasterDataTable objCompanyAdminRightsMasterDT = new CloudAccountDA.CompanyAdminRightsMasterDataTable();
    private bool checkInDB;
    protected ToolkitScriptManager tsm;
    protected Panel pnlAdd;
    protected UpdatePanel upCountryState;
    protected DropDownList ddlCountry;
    protected SqlDataSource sqldsCountry;
    protected RequiredFieldValidator rfvCityMaster;
    protected DropDownList ddlState;
    protected SqlDataSource sqldsState;
    protected RequiredFieldValidator rfvState1Master;
    protected TextBox txtCode;
    protected RequiredFieldValidator RequiredFieldValidator1;
    protected TextBox txtName;
    protected RequiredFieldValidator RequiredFieldValidator2;
    protected TextBox txtDesc;
    protected CheckBox chkStatus;
    protected Button btnSubmit;
    protected Button btnReset;
    protected Button btnUpdate;
    protected Button btnCancel;
    protected Button btnListAll;
    protected Panel pnlView;
    protected Label lblCountry;
    protected Label lblState;
    protected Label lblCode;
    protected Label lblName;
    protected Label lblDesc;
    protected Label lblStatus;
    protected Button btnEdit;
    protected Button btnDelete;
    protected Button btnList;
    protected Button btnAdd;
    protected Panel pnlViewAll;
    protected GridView gvCity;
    protected Button btnAddCity;
    protected HiddenField hfCity;
    protected HiddenField hfMasterAdminID;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyLoginID;
    protected ObjectDataSource objdsCity;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("generalMaster")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("city")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          CityMaster.AddStatus = "True";
          CityMaster.EditStatus = "True";
          CityMaster.ViewStatus = "True";
          CityMaster.DeleteStatus = "True";
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
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "CityMaster");
          if (this.objMasterAdminRightsMasterDT.Rows.Count > 0)
          {
            CityMaster.AddStatus = this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            CityMaster.EditStatus = this.objMasterAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            CityMaster.ViewStatus = this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            CityMaster.DeleteStatus = this.objMasterAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            CityMaster.AddStatus = "";
            CityMaster.EditStatus = "";
            CityMaster.ViewStatus = "";
            CityMaster.DeleteStatus = "";
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
          this.objCompanyAdminRightsMasterDT = this.objCompanyAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfCompanyID.Value.Trim()), int.Parse(this.hfCompanyLoginID.Value.Trim()), "CityMaster");
          if (this.objCompanyAdminRightsMasterDT.Rows.Count > 0)
          {
            CityMaster.AddStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            CityMaster.EditStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            CityMaster.ViewStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            CityMaster.DeleteStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            CityMaster.AddStatus = "";
            CityMaster.EditStatus = "";
            CityMaster.ViewStatus = "";
            CityMaster.DeleteStatus = "";
          }
        }
        else
        {
          CityMaster.AddStatus = "";
          CityMaster.EditStatus = "";
          CityMaster.ViewStatus = "";
          CityMaster.DeleteStatus = "";
        }
      }
      if (CityMaster.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] == null || !(CityMaster.ViewStatus == "True"))
                break;
              string i = this.Request.QueryString["ID"];
              this.pnlViewAll.Visible = false;
              this.pnlAdd.Visible = false;
              this.pnlView.Visible = true;
              this.ViewRecord(i);
              this.btnEdit.Visible = CityMaster.EditStatus == "True";
              this.btnAddCity.Visible = this.btnAdd.Visible = CityMaster.AddStatus == "True";
              this.btnDelete.Visible = CityMaster.DeleteStatus == "True";
              this.btnListAll.Visible = true;
              this.btnUpdate.Visible = false;
              this.btnCancel.Visible = false;
              break;
            case "add":
              if (this.Request.QueryString["ID"] != null)
              {
                if (!(CityMaster.EditStatus == "True"))
                  break;
                this.SetRecord(this.Request.QueryString["ID"]);
                this.pnlAdd.Visible = true;
                this.pnlViewAll.Visible = false;
                this.pnlView.Visible = false;
                this.btnUpdate.Visible = true;
                this.btnCancel.Visible = true;
                this.btnSubmit.Visible = false;
                this.btnReset.Visible = false;
                break;
              }
              if (!(CityMaster.AddStatus == "True"))
                break;
              this.Clear();
              this.btnSubmit.Visible = true;
              this.btnReset.Visible = true;
              this.btnUpdate.Visible = false;
              this.btnCancel.Visible = false;
              this.pnlAdd.Visible = true;
              this.pnlViewAll.Visible = false;
              this.pnlView.Visible = false;
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
          if (CityMaster.AddStatus == "False")
            this.btnAddCity.Visible = this.btnAdd.Visible = false;
          else
            this.btnAddCity.Visible = this.btnAdd.Visible = true;
        }
      }
      else if (CityMaster.AddStatus == "True" && CityMaster.EditStatus == "False" && (CityMaster.ViewStatus == "False" && CityMaster.DeleteStatus == "False"))
      {
        this.pnlAdd.Visible = true;
        this.btnUpdate.Visible = false;
        this.btnCancel.Visible = false;
        this.pnlViewAll.Visible = false;
        this.pnlView.Visible = false;
      }
      else
      {
        this.pnlViewAll.Visible = false;
        this.pnlView.Visible = false;
        this.pnlAdd.Visible = false;
      }
    }

    protected void gvCity_Sorting(object sender, GridViewSortEventArgs e)
    {
      this.BindGrid();
    }

    private void Clear()
    {
      this.txtName.Text = this.txtCode.Text = "";
      this.txtDesc.Text = "";
      this.chkStatus.Checked = false;
      this.ddlCountry.SelectedIndex = this.ddlState.SelectedIndex = 0;
      this.ddlCountry.Focus();
    }

    private void BindGrid()
    {
      this.gvCity.DataBind();
    }

    private void ViewRecord(string i)
    {
      this.objCityMasterDT = this.objCityMasterBll.GetDataByCityID(int.Parse(i));
      if (this.objCityMasterDT.Rows.Count <= 0)
        return;
      this.hfCity.Value = this.objCityMasterDT.Rows[0]["CityID"].ToString();
      this.lblCode.Text = this.objCityMasterDT.Rows[0]["CityCode"].ToString();
      this.lblName.Text = this.objCityMasterDT.Rows[0]["CityName"].ToString();
      this.lblDesc.Text = this.objCityMasterDT.Rows[0]["CityDesc"].ToString();
      this.lblStatus.Text = this.objCityMasterDT.Rows[0]["CityStatus"].ToString();
      this.objCountryMasterDT = this.objCountryMasterBll.GetDataByCountryID(int.Parse(this.objCityMasterDT.Rows[0]["CountryID"].ToString()));
      this.lblCountry.Text = this.objCountryMasterDT.Rows[0]["CountryName"].ToString();
      this.objStateMasterDT = this.objStateMasterBll.GetDataByStateID(int.Parse(this.objCityMasterDT.Rows[0]["StateID"].ToString()));
      this.lblState.Text = this.objStateMasterDT.Rows[0]["StateName"].ToString();
    }

    private void SetRecord(string iD)
    {
      this.objCityMasterDT = this.objCityMasterBll.GetDataByCityID(int.Parse(iD));
      if (this.objCityMasterDT.Rows.Count <= 0)
        return;
      this.hfCity.Value = this.objCityMasterDT.Rows[0]["CityID"].ToString();
      this.txtCode.Text = this.objCityMasterDT.Rows[0]["CityCode"].ToString();
      this.txtName.Text = this.objCityMasterDT.Rows[0]["CityName"].ToString();
      this.txtDesc.Text = this.objCityMasterDT.Rows[0]["CityDesc"].ToString();
      this.chkStatus.Checked = this.objCityMasterDT.Rows[0]["CityStatus"].ToString() == "True";
      this.objCountryMasterDT = this.objCountryMasterBll.GetDataByCountryID(int.Parse(this.objCityMasterDT.Rows[0]["CountryID"].ToString()));
      if (this.objCountryMasterDT.Rows.Count > 0)
      {
        this.ddlCountry.Items.Add(this.objCountryMasterDT.Rows[0]["CountryID"].ToString());
        this.ddlCountry.SelectedValue = this.objCountryMasterDT.Rows[0]["CountryID"].ToString();
      }
      this.objStateMasterDT = this.objStateMasterBll.GetDataByStateID(int.Parse(this.objCityMasterDT.Rows[0]["StateID"].ToString()));
      if (this.objStateMasterDT.Rows.Count <= 0)
        return;
      this.ddlState.Items.Add(this.objStateMasterDT.Rows[0]["StateID"].ToString());
      this.ddlState.SelectedValue = this.objStateMasterDT.Rows[0]["StateID"].ToString();
    }

    protected void gvCity_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/CityMaster.aspx?cmd=view&ID=" + this.gvCity.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvCity_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvCity.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void gvCity_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        this.objCountryMasterDT = this.objCountryMasterBll.GetDataByCountryID(int.Parse(e.Row.Cells[1].Text));
        if (this.objCountryMasterDT.Rows.Count != 0)
          e.Row.Cells[1].Text = this.objCountryMasterDT.Rows[0]["CountryName"].ToString();
      }
      if (e.Row.RowType != DataControlRowType.DataRow)
        return;
      this.objStateMasterDT = this.objStateMasterBll.GetDataByStateID(int.Parse(e.Row.Cells[2].Text));
      if (this.objStateMasterDT.Rows.Count == 0)
        return;
      e.Row.Cells[2].Text = this.objStateMasterDT.Rows[0]["StateName"].ToString();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvCity.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvCity, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void btnAddCity_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/CityMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.ddlCountry.SelectedIndex > 0 && this.ddlState.SelectedIndex > 0 && (this.txtCode.Text.Trim().Length > 0 && this.txtName.Text.Trim().Length > 0))
      {
        this.objCityMasterDT = this.objCityMasterBll.GetDataByStateCityName(int.Parse(this.ddlState.SelectedItem.Value), int.Parse(this.ddlCountry.SelectedItem.Value), this.txtName.Text);
        if (this.objCityMasterDT.Rows.Count > 0)
        {
          this.DisplayAlert("City is Already Exist in State - Country...");
          this.checkInDB = true;
        }
        else
          this.checkInDB = false;
        if (this.checkInDB)
          return;
        int num = this.objCityMasterBll.AddCity(int.Parse(this.ddlCountry.SelectedItem.Value), int.Parse(this.ddlState.SelectedItem.Value), this.txtCode.Text.Trim(), this.txtName.Text.Trim(), this.txtDesc.Text.Trim(), this.chkStatus.Checked);
        if (num != 0)
        {
          this.DisplayAlert("Details Added Successfully.");
          this.Response.Redirect("~/Admin/CityMaster.aspx?cmd=view&ID=" + (object) num);
        }
        else
          this.DisplayAlert("Fail to Add New Details.");
      }
      else
        this.DisplayAlert("Please Fill All Details...!");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
      try
      {
        if (!this.Page.IsValid)
          return;
        if (this.ddlCountry.SelectedIndex > 0 && this.ddlState.SelectedIndex > 0 && (this.txtCode.Text.Trim().Length > 0 && this.txtName.Text.Trim().Length > 0))
        {
          this.objCityMasterDT = this.objCityMasterBll.GetDataByStateCityName(int.Parse(this.hfCity.Value), int.Parse(this.ddlState.SelectedItem.Value), int.Parse(this.ddlCountry.SelectedItem.Value), this.txtName.Text);
          if (this.objCityMasterDT.Rows.Count > 0)
          {
            this.DisplayAlert("City is Already Exist in State - Country...");
            this.checkInDB = true;
          }
          else
            this.checkInDB = false;
          if (this.checkInDB)
            return;
          if (this.objCityMasterBll.UpdateCity(int.Parse(this.hfCity.Value), int.Parse(this.ddlCountry.SelectedItem.Value), int.Parse(this.ddlState.SelectedItem.Value), this.txtCode.Text.Trim(), this.txtName.Text.Trim(), this.txtDesc.Text.Trim(), this.chkStatus.Checked))
          {
            this.DisplayAlert("Update Successfully..");
            this.Response.Redirect("~/Admin/CityMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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

    protected void btnEdit_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/CityMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfCity.Value != null)
      {
        if (this.objCityMasterBll.DeleteCity(int.Parse(this.hfCity.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/Admin/CityMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/CityMaster.aspx");
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
      this.Clear();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/CityMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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

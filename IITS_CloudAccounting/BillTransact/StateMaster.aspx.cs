// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.StateMaster
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using DABL.BLL;
using DABL.DAL;
using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class StateMaster : Page
  {
    private static string AddStatus = string.Empty;
    private static string EditStatus = string.Empty;
    private static string ViewStatus = string.Empty;
    private static string DeleteStatus = string.Empty;
    private readonly CountryMasterBLL objCountryMasterBll = new CountryMasterBLL();
    private CloudAccountDA.CountryMasterDataTable objCountryMasterDT = new CloudAccountDA.CountryMasterDataTable();
    private readonly CityMasterBLL objCityMasterBll = new CityMasterBLL();
    private CloudAccountDA.CityMasterDataTable objCityMasteDT = new CloudAccountDA.CityMasterDataTable();
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
    protected Panel pnlAdd;
    protected DropDownList ddlCountry;
    protected SqlDataSource sqldsCountry;
    protected RequiredFieldValidator rfvCountryName;
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
    protected Label lblCode;
    protected Label lblName;
    protected Label lblDesc;
    protected Label lblStatus;
    protected Button btnEdit;
    protected Button btnDelete;
    protected Button btnList;
    protected Button btnAdd;
    protected Panel pnlViewAll;
    protected GridView gvState;
    protected Button btnAddState;
    protected HiddenField hfState;
    protected HiddenField hfMasterAdminID;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyLoginID;
    protected ObjectDataSource objdsState;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("generalMaster")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("state")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          StateMaster.AddStatus = "True";
          StateMaster.EditStatus = "True";
          StateMaster.ViewStatus = "True";
          StateMaster.DeleteStatus = "True";
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
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "StateMaster");
          if (this.objMasterAdminRightsMasterDT.Rows.Count > 0)
          {
            StateMaster.AddStatus = this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            StateMaster.EditStatus = this.objMasterAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            StateMaster.ViewStatus = this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            StateMaster.DeleteStatus = this.objMasterAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            StateMaster.AddStatus = "";
            StateMaster.EditStatus = "";
            StateMaster.ViewStatus = "";
            StateMaster.DeleteStatus = "";
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
          this.objCompanyAdminRightsMasterDT = this.objCompanyAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfCompanyID.Value.Trim()), int.Parse(this.hfCompanyLoginID.Value.Trim()), "StateMaster");
          if (this.objCompanyAdminRightsMasterDT.Rows.Count > 0)
          {
            StateMaster.AddStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            StateMaster.EditStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            StateMaster.ViewStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            StateMaster.DeleteStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            StateMaster.AddStatus = "";
            StateMaster.EditStatus = "";
            StateMaster.ViewStatus = "";
            StateMaster.DeleteStatus = "";
          }
        }
        else
        {
          StateMaster.AddStatus = "";
          StateMaster.EditStatus = "";
          StateMaster.ViewStatus = "";
          StateMaster.DeleteStatus = "";
        }
      }
      if (StateMaster.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] == null || !(StateMaster.ViewStatus == "True"))
                break;
              string i = this.Request.QueryString["ID"];
              this.pnlViewAll.Visible = false;
              this.pnlAdd.Visible = false;
              this.pnlView.Visible = true;
              this.ViewRecord(i);
              this.btnEdit.Visible = StateMaster.EditStatus == "True";
              this.btnAddState.Visible = this.btnAdd.Visible = StateMaster.AddStatus == "True";
              this.btnDelete.Visible = StateMaster.DeleteStatus == "True";
              this.btnListAll.Visible = true;
              this.btnUpdate.Visible = false;
              this.btnCancel.Visible = false;
              break;
            case "add":
              if (this.Request.QueryString["ID"] != null)
              {
                if (!(StateMaster.EditStatus == "True"))
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
              if (!(StateMaster.AddStatus == "True"))
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
          if (StateMaster.AddStatus == "False")
            this.btnAddState.Visible = this.btnAdd.Visible = false;
          else
            this.btnAddState.Visible = this.btnAdd.Visible = true;
        }
      }
      else if (StateMaster.AddStatus == "True" && StateMaster.EditStatus == "False" && (StateMaster.ViewStatus == "False" && StateMaster.DeleteStatus == "False"))
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

    protected void gvState_Sorting(object sender, GridViewSortEventArgs e)
    {
      this.BindGrid();
    }

    private void BindGrid()
    {
      this.gvState.DataBind();
    }

    private void Clear()
    {
      this.txtName.Text = this.txtCode.Text = "";
      this.chkStatus.Checked = false;
      this.txtDesc.Text = "";
      this.ddlCountry.SelectedIndex = 0;
      this.ddlCountry.Focus();
    }

    private void ViewRecord(string i)
    {
      this.objStateMasterDT = this.objStateMasterBll.GetDataByStateID(int.Parse(i));
      if (this.objStateMasterDT.Rows.Count <= 0)
        return;
      this.hfState.Value = this.objStateMasterDT.Rows[0]["StateID"].ToString();
      this.lblCode.Text = this.objStateMasterDT.Rows[0]["StateCode"].ToString();
      this.lblName.Text = this.objStateMasterDT.Rows[0]["StateName"].ToString();
      this.lblDesc.Text = this.objStateMasterDT.Rows[0]["StateDesc"].ToString();
      this.lblStatus.Text = this.objStateMasterDT.Rows[0]["StateStatus"].ToString() == "True" ? "True" : "False";
      this.objCountryMasterDT = this.objCountryMasterBll.GetDataByCountryID(int.Parse(this.objStateMasterDT.Rows[0]["CountryID"].ToString()));
      this.lblCountry.Text = this.objCountryMasterDT.Rows[0]["CountryName"].ToString();
    }

    private void SetRecord(string iD)
    {
      this.objStateMasterDT = this.objStateMasterBll.GetDataByStateID(int.Parse(iD));
      if (this.objStateMasterDT.Rows.Count <= 0)
        return;
      this.hfState.Value = this.objStateMasterDT.Rows[0]["StateID"].ToString();
      this.ddlCountry.SelectedValue = this.objStateMasterDT.Rows[0]["CountryID"].ToString();
      this.txtCode.Text = this.objStateMasterDT.Rows[0]["StateCode"].ToString();
      this.txtName.Text = this.objStateMasterDT.Rows[0]["StateName"].ToString();
      this.txtDesc.Text = this.objStateMasterDT.Rows[0]["StateDesc"].ToString();
      this.chkStatus.Checked = this.objStateMasterDT.Rows[0]["StateStatus"].ToString() == "True";
    }

    protected void gvState_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/StateMaster.aspx?cmd=view&ID=" + this.gvState.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvState_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvState.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void gvState_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType != DataControlRowType.DataRow)
        return;
      this.objCountryMasterDT = this.objCountryMasterBll.GetDataByCountryID(int.Parse(e.Row.Cells[1].Text));
      if (this.objCountryMasterDT.Rows.Count == 0)
        return;
      e.Row.Cells[1].Text = this.objCountryMasterDT.Rows[0]["CountryName"].ToString();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvState.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvState, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void btnAddState_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/StateMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      try
      {
        if (!this.Page.IsValid)
          return;
        if (this.ddlCountry.SelectedIndex > 0 && this.txtCode.Text.Trim().Length > 0 && this.txtName.Text.Trim().Length > 0)
        {
          this.objStateMasterDT = this.objStateMasterBll.GetDataByCountryStateName(int.Parse(this.ddlCountry.SelectedItem.Value), this.txtName.Text);
          if (this.objStateMasterDT.Rows.Count > 0)
          {
            this.DisplayAlert("State is Already Exist in Country...");
            this.checkInDB = true;
          }
          else
            this.checkInDB = false;
          if (this.checkInDB)
            return;
          int num = this.objStateMasterBll.AddState(int.Parse(this.ddlCountry.SelectedItem.Value), this.txtCode.Text.Trim(), this.txtName.Text.Trim(), this.txtDesc.Text.Trim(), this.chkStatus.Checked);
          if (num != 0)
          {
            this.DisplayAlert("Details Added Successfully.");
            this.Response.Redirect("~/BillTransact/StateMaster.aspx?cmd=view&ID=" + (object) num);
          }
          else
            this.DisplayAlert("Fail to Add New Details.");
        }
        else
          this.DisplayAlert("Please Fill All Data...!");
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

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.Page.IsValid)
        {
          if (this.ddlCountry.SelectedIndex > 0 && this.txtCode.Text.Trim().Length > 0 && this.txtName.Text.Trim().Length > 0)
          {
            this.objStateMasterDT = this.objStateMasterBll.GetDataByCountryStateName(int.Parse(this.hfState.Value.Trim()), int.Parse(this.ddlCountry.SelectedItem.Value), this.txtName.Text);
            if (this.objStateMasterDT.Rows.Count > 0)
            {
              this.DisplayAlert("State is Already Exist in Country...");
              this.checkInDB = true;
            }
            else
              this.checkInDB = false;
            if (this.checkInDB)
              return;
            if (this.objStateMasterBll.UpdateState(int.Parse(this.hfState.Value.Trim()), int.Parse(this.ddlCountry.SelectedItem.Value), this.txtCode.Text.Trim(), this.txtName.Text.Trim(), this.txtDesc.Text.Trim(), this.chkStatus.Checked))
            {
              this.DisplayAlert("Update Successfully..");
              this.Response.Redirect("~/BillTransact/StateMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
            }
            else
              this.DisplayAlert("Fail to Update Details.");
          }
          else
            this.DisplayAlert("Please Fill All Data...!");
        }
        else
          this.DisplayAlert("Fail to Update Details.");
      }
      catch (Exception ex)
      {
        this.DisplayAlert(ex.Message);
      }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/StateMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      this.objCityMasteDT = this.objCityMasterBll.GetDataByStateID(int.Parse(this.hfState.Value));
      if (this.objCityMasteDT.Rows.Count > 0)
        this.DisplayAlert("Child Data Exist..");
      else if (this.hfState.Value != null)
      {
        if (this.objStateMasterBll.DeleteState(int.Parse(this.hfState.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/BillTransact/StateMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/StateMaster.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/StateMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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

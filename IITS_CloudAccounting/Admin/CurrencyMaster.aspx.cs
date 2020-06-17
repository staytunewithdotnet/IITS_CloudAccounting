// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.CurrencyMaster
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
  public class CurrencyMaster : Page
  {
    public static bool checkInDB = false;
    private static string AddStatus = string.Empty;
    private static string EditStatus = string.Empty;
    private static string ViewStatus = string.Empty;
    private static string DeleteStatus = string.Empty;
    private readonly CountryMasterBLL objCountryMasterBll = new CountryMasterBLL();
    private readonly CurrencyMasterBLL objCurrencyMasterBll = new CurrencyMasterBLL();
    private CloudAccountDA.CountryMasterDataTable objCountryMasterDT = new CloudAccountDA.CountryMasterDataTable();
    private CloudAccountDA.CurrencyMasterDataTable objCurrencyMasterDT = new CloudAccountDA.CurrencyMasterDataTable();
    private readonly MasterAdminRightsMasterBLL objMasterAdminRightsMasterBll = new MasterAdminRightsMasterBLL();
    private CloudAccountDA.MasterAdminRightsMasterDataTable objMasterAdminRightsMasterDT = new CloudAccountDA.MasterAdminRightsMasterDataTable();
    private readonly MasterAdminLoginMasterBLL objMasterAdminLoginMasterBll = new MasterAdminLoginMasterBLL();
    private CloudAccountDA.MasterAdminLoginMasterDataTable objMasterAdminLoginMasterDT = new CloudAccountDA.MasterAdminLoginMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyAdminRightsMasterBLL objCompanyAdminRightsMasterBll = new CompanyAdminRightsMasterBLL();
    private CloudAccountDA.CompanyAdminRightsMasterDataTable objCompanyAdminRightsMasterDT = new CloudAccountDA.CompanyAdminRightsMasterDataTable();
    protected Panel pnlAdd;
    protected DropDownList ddlCountry;
    protected SqlDataSource sqldsCountry;
    protected RequiredFieldValidator rfvCityMaster;
    protected TextBox txtCode;
    protected TextBox txtName;
    protected RequiredFieldValidator RequiredFieldValidator2;
    protected TextBox txtSymbol;
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
    protected Label lblSymbol;
    protected Label lblDesc;
    protected Label lblStatus;
    protected Button btnEdit;
    protected Button btnDelete;
    protected Button btnList;
    protected Button btnAdd;
    protected Panel pnlViewAll;
    protected GridView gvCurrency;
    protected Button btnAddCurrency;
    protected HiddenField hfCurrency;
    protected HiddenField hfMasterAdminID;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyLoginID;
    protected ObjectDataSource objdsCurrency;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("generalMaster")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("currency")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          CurrencyMaster.AddStatus = "True";
          CurrencyMaster.EditStatus = "True";
          CurrencyMaster.ViewStatus = "True";
          CurrencyMaster.DeleteStatus = "True";
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
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "CurrencyMaster");
          if (this.objMasterAdminRightsMasterDT.Rows.Count > 0)
          {
            CurrencyMaster.AddStatus = this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            CurrencyMaster.EditStatus = this.objMasterAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            CurrencyMaster.ViewStatus = this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            CurrencyMaster.DeleteStatus = this.objMasterAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            CurrencyMaster.AddStatus = "";
            CurrencyMaster.EditStatus = "";
            CurrencyMaster.ViewStatus = "";
            CurrencyMaster.DeleteStatus = "";
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
          this.objCompanyAdminRightsMasterDT = this.objCompanyAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfCompanyID.Value.Trim()), int.Parse(this.hfCompanyLoginID.Value.Trim()), "CurrencyMaster");
          if (this.objCompanyAdminRightsMasterDT.Rows.Count > 0)
          {
            CurrencyMaster.AddStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            CurrencyMaster.EditStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            CurrencyMaster.ViewStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            CurrencyMaster.DeleteStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            CurrencyMaster.AddStatus = "";
            CurrencyMaster.EditStatus = "";
            CurrencyMaster.ViewStatus = "";
            CurrencyMaster.DeleteStatus = "";
          }
        }
        else
        {
          CurrencyMaster.AddStatus = "";
          CurrencyMaster.EditStatus = "";
          CurrencyMaster.ViewStatus = "";
          CurrencyMaster.DeleteStatus = "";
        }
      }
      if (CurrencyMaster.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] == null || !(CurrencyMaster.ViewStatus == "True"))
                break;
              string i = this.Request.QueryString["ID"];
              this.pnlViewAll.Visible = false;
              this.pnlAdd.Visible = false;
              this.pnlView.Visible = true;
              this.ViewRecord(i);
              this.btnEdit.Visible = CurrencyMaster.EditStatus == "True";
              this.btnAddCurrency.Visible = this.btnAdd.Visible = CurrencyMaster.AddStatus == "True";
              this.btnDelete.Visible = CurrencyMaster.DeleteStatus == "True";
              this.btnListAll.Visible = true;
              this.btnUpdate.Visible = false;
              this.btnCancel.Visible = false;
              break;
            case "add":
              if (this.Request.QueryString["ID"] != null)
              {
                if (!(CurrencyMaster.EditStatus == "True"))
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
              if (!(CurrencyMaster.AddStatus == "True"))
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
          if (CurrencyMaster.AddStatus == "False")
            this.btnAddCurrency.Visible = this.btnAdd.Visible = false;
          else
            this.btnAddCurrency.Visible = this.btnAdd.Visible = true;
        }
      }
      else if (CurrencyMaster.AddStatus == "True" && CurrencyMaster.EditStatus == "False" && (CurrencyMaster.ViewStatus == "False" && CurrencyMaster.DeleteStatus == "False"))
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

    private void BindGrid()
    {
      this.gvCurrency.DataBind();
    }

    private void Clear()
    {
      this.ddlCountry.SelectedIndex = 0;
      this.txtCode.Text = this.txtName.Text = this.txtSymbol.Text = this.txtDesc.Text = "";
      this.chkStatus.Checked = false;
      this.ddlCountry.Focus();
    }

    private void ViewRecord(string i)
    {
      this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(i));
      if (this.objCurrencyMasterDT.Rows.Count <= 0)
        return;
      this.hfCurrency.Value = this.objCurrencyMasterDT.Rows[0]["CurrencyID"].ToString();
      this.lblCode.Text = this.objCurrencyMasterDT.Rows[0]["CurrencyCode"].ToString();
      this.lblName.Text = this.objCurrencyMasterDT.Rows[0]["CurrencyName"].ToString();
      this.lblSymbol.Text = this.objCurrencyMasterDT.Rows[0]["CurrencySymbol"].ToString();
      this.lblDesc.Text = this.objCurrencyMasterDT.Rows[0]["CurrencyDesc"].ToString();
      this.lblStatus.Text = this.objCurrencyMasterDT.Rows[0]["CurrencyStatus"].ToString();
      this.objCountryMasterDT = this.objCountryMasterBll.GetDataByCountryID(int.Parse(this.objCurrencyMasterDT.Rows[0]["CountryID"].ToString()));
      this.lblCountry.Text = this.objCountryMasterDT.Rows[0]["CountryName"].ToString();
    }

    private void SetRecord(string iD)
    {
      this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(iD));
      if (this.objCurrencyMasterDT.Rows.Count <= 0)
        return;
      this.hfCurrency.Value = this.objCurrencyMasterDT.Rows[0]["CurrencyID"].ToString();
      this.txtCode.Text = this.objCurrencyMasterDT.Rows[0]["CurrencyCode"].ToString();
      this.txtName.Text = this.objCurrencyMasterDT.Rows[0]["CurrencyName"].ToString();
      this.txtSymbol.Text = this.objCurrencyMasterDT.Rows[0]["CurrencySymbol"].ToString();
      this.txtDesc.Text = this.objCurrencyMasterDT.Rows[0]["CurrencyDesc"].ToString();
      this.chkStatus.Checked = bool.Parse(this.objCurrencyMasterDT.Rows[0]["CurrencyStatus"].ToString());
      this.objCountryMasterDT = this.objCountryMasterBll.GetDataByCountryID(int.Parse(this.objCurrencyMasterDT.Rows[0]["CountryID"].ToString()));
      if (this.objCountryMasterDT.Rows.Count <= 0)
        return;
      this.ddlCountry.Items.Add(this.objCountryMasterDT.Rows[0]["CountryID"].ToString());
      this.ddlCountry.SelectedValue = this.objCountryMasterDT.Rows[0]["CountryID"].ToString();
    }

    protected void gvCurrency_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType != DataControlRowType.DataRow)
        return;
      this.objCountryMasterDT = this.objCountryMasterBll.GetDataByCountryID(int.Parse(e.Row.Cells[1].Text));
      if (this.objCountryMasterDT.Rows.Count == 0)
        return;
      e.Row.Cells[1].Text = this.objCountryMasterDT.Rows[0]["CountryName"].ToString();
    }

    protected void gvCurrency_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvCurrency.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void gvCurrency_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/CurrencyMaster.aspx?cmd=view&ID=" + this.gvCurrency.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvCurrency.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvCurrency, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/CurrencyMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      try
      {
        if (!this.Page.IsValid)
          return;
        this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyName(this.txtName.Text.Trim());
        if (this.objCurrencyMasterDT.Rows.Count > 0)
        {
          this.DisplayAlert("Currency is already entered...!");
          CurrencyMaster.checkInDB = this.objCurrencyMasterDT.Rows.Count > 0;
        }
        this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCountryID(int.Parse(this.ddlCountry.SelectedItem.Value));
        if (this.objCurrencyMasterDT.Rows.Count > 0)
        {
          this.DisplayAlert("Country currency is already entered...!");
          CurrencyMaster.checkInDB = this.objCurrencyMasterDT.Rows.Count > 0;
        }
        if (CurrencyMaster.checkInDB)
          return;
        int num = this.objCurrencyMasterBll.AddCurrency(int.Parse(this.ddlCountry.SelectedItem.Value), this.txtCode.Text.Trim(), this.txtName.Text.Trim(), this.txtSymbol.Text.Trim(), this.txtDesc.Text.Trim(), this.chkStatus.Checked);
        if (num != 0)
        {
          this.DisplayAlert("Details Added Successfully.");
          this.Response.Redirect("~/Admin/CurrencyMaster.aspx?cmd=view&ID=" + (object) num);
        }
        else
          this.DisplayAlert("Fail to Add New Details.");
      }
      catch (Exception ex)
      {
        this.DisplayAlert(ex.Message);
        throw;
      }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
      try
      {
        if (!this.Page.IsValid)
          return;
        this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyNameUpdate(int.Parse(this.hfCurrency.Value), this.txtName.Text.Trim());
        if (this.objCurrencyMasterDT.Rows.Count > 0)
        {
          this.DisplayAlert("Currency is already entered...!");
          CurrencyMaster.checkInDB = this.objCurrencyMasterDT.Rows.Count > 0;
        }
        this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCountryIDUpdate(int.Parse(this.hfCurrency.Value), int.Parse(this.ddlCountry.SelectedItem.Value));
        if (this.objCurrencyMasterDT.Rows.Count > 0)
        {
          this.DisplayAlert("Country currency is already entered...!");
          CurrencyMaster.checkInDB = this.objCurrencyMasterDT.Rows.Count > 0;
        }
        if (CurrencyMaster.checkInDB)
          return;
        if (this.objCurrencyMasterBll.UpdateCurrency(int.Parse(this.hfCurrency.Value), int.Parse(this.ddlCountry.SelectedItem.Value), this.txtCode.Text.Trim(), this.txtName.Text.Trim(), this.txtSymbol.Text.Trim(), this.txtDesc.Text.Trim(), this.chkStatus.Checked))
        {
          this.DisplayAlert("Details Updated Successfully.");
          this.Response.Redirect("~/Admin/CurrencyMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
        }
        else
          this.DisplayAlert("Fail to Update Details.");
      }
      catch (Exception ex)
      {
        this.DisplayAlert(ex.Message);
        throw;
      }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfCurrency.Value != null)
      {
        if (this.objCurrencyMasterBll.DeleteCurrency(int.Parse(this.hfCurrency.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/Admin/CurrencyMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/CurrencyMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
      this.Clear();
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/CurrencyMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/CurrencyMaster.aspx");
    }

    protected void gvCurrency_Sorting(object sender, GridViewSortEventArgs e)
    {
      this.BindGrid();
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

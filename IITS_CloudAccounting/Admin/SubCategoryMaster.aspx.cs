// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.SubCategoryMaster
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
  public class SubCategoryMaster : Page
  {
    private static string AddStatus = string.Empty;
    private static string EditStatus = string.Empty;
    private static string ViewStatus = string.Empty;
    private static string DeleteStatus = string.Empty;
    private readonly CategoryMasterBLL objCategoryMasterBll = new CategoryMasterBLL();
    private CloudAccountDA.CategoryMasterDataTable objCategoryMasterDT = new CloudAccountDA.CategoryMasterDataTable();
    private readonly SubCategoryMasterBLL objSubCategoryMasterBll = new SubCategoryMasterBLL();
    private CloudAccountDA.SubCategoryMasterDataTable objSubCategoryMasterDT = new CloudAccountDA.SubCategoryMasterDataTable();
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
    protected DropDownList ddlCategory;
    protected SqlDataSource sqldsCategory;
    protected RequiredFieldValidator rfvCategoryName;
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
    protected Label lblCategory;
    protected Label lblCode;
    protected Label lblName;
    protected Label lblDesc;
    protected Label lblStatus;
    protected Button btnEdit;
    protected Button btnDelete;
    protected Button btnList;
    protected Button btnAdd;
    protected Panel pnlViewAll;
    protected GridView gvSubCategory;
    protected Button btnAddSubCategory;
    protected HiddenField hfSubCategory;
    protected HiddenField hfMasterAdminID;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyLoginID;
    protected ObjectDataSource objdsSubCategory;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("generalMaster")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("SubCategory")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          SubCategoryMaster.AddStatus = "True";
          SubCategoryMaster.EditStatus = "True";
          SubCategoryMaster.ViewStatus = "True";
          SubCategoryMaster.DeleteStatus = "True";
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
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "SubCategoryMaster");
          if (this.objMasterAdminRightsMasterDT.Rows.Count > 0)
          {
            SubCategoryMaster.AddStatus = this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            SubCategoryMaster.EditStatus = this.objMasterAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            SubCategoryMaster.ViewStatus = this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            SubCategoryMaster.DeleteStatus = this.objMasterAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            SubCategoryMaster.AddStatus = "";
            SubCategoryMaster.EditStatus = "";
            SubCategoryMaster.ViewStatus = "";
            SubCategoryMaster.DeleteStatus = "";
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
          this.objCompanyAdminRightsMasterDT = this.objCompanyAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfCompanyID.Value.Trim()), int.Parse(this.hfCompanyLoginID.Value.Trim()), "SubCategoryMaster");
          if (this.objCompanyAdminRightsMasterDT.Rows.Count > 0)
          {
            SubCategoryMaster.AddStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            SubCategoryMaster.EditStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            SubCategoryMaster.ViewStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            SubCategoryMaster.DeleteStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            SubCategoryMaster.AddStatus = "";
            SubCategoryMaster.EditStatus = "";
            SubCategoryMaster.ViewStatus = "";
            SubCategoryMaster.DeleteStatus = "";
          }
        }
        else
        {
          SubCategoryMaster.AddStatus = "";
          SubCategoryMaster.EditStatus = "";
          SubCategoryMaster.ViewStatus = "";
          SubCategoryMaster.DeleteStatus = "";
        }
      }
      if (SubCategoryMaster.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] == null || !(SubCategoryMaster.ViewStatus == "True"))
                break;
              string i = this.Request.QueryString["ID"];
              this.pnlViewAll.Visible = false;
              this.pnlAdd.Visible = false;
              this.pnlView.Visible = true;
              this.ViewRecord(i);
              this.btnEdit.Visible = SubCategoryMaster.EditStatus == "True";
              this.btnAddSubCategory.Visible = this.btnAdd.Visible = SubCategoryMaster.AddStatus == "True";
              this.btnDelete.Visible = SubCategoryMaster.DeleteStatus == "True";
              this.btnListAll.Visible = true;
              this.btnUpdate.Visible = false;
              this.btnCancel.Visible = false;
              break;
            case "add":
              if (this.Request.QueryString["ID"] != null)
              {
                if (!(SubCategoryMaster.EditStatus == "True"))
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
              if (!(SubCategoryMaster.AddStatus == "True"))
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
          if (SubCategoryMaster.AddStatus == "False")
            this.btnAddSubCategory.Visible = this.btnAdd.Visible = false;
          else
            this.btnAddSubCategory.Visible = this.btnAdd.Visible = true;
        }
      }
      else if (SubCategoryMaster.AddStatus == "True" && SubCategoryMaster.EditStatus == "False" && (SubCategoryMaster.ViewStatus == "False" && SubCategoryMaster.DeleteStatus == "False"))
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

    protected void gvSubCategory_Sorting(object sender, GridViewSortEventArgs e)
    {
      this.BindGrid();
    }

    private void BindGrid()
    {
      this.gvSubCategory.DataBind();
    }

    private void Clear()
    {
      this.txtName.Text = this.txtCode.Text = "";
      this.chkStatus.Checked = false;
      this.txtDesc.Text = "";
      this.ddlCategory.SelectedIndex = 0;
      this.ddlCategory.Focus();
    }

    private void ViewRecord(string i)
    {
      this.objSubCategoryMasterDT = this.objSubCategoryMasterBll.GetDataBySubCategoryID(int.Parse(i));
      if (this.objSubCategoryMasterDT.Rows.Count <= 0)
        return;
      this.hfSubCategory.Value = this.objSubCategoryMasterDT.Rows[0]["SubCategoryID"].ToString();
      this.lblCode.Text = this.objSubCategoryMasterDT.Rows[0]["SubCategoryCode"].ToString();
      this.lblName.Text = this.objSubCategoryMasterDT.Rows[0]["SubCategoryName"].ToString();
      this.lblDesc.Text = this.objSubCategoryMasterDT.Rows[0]["SubCategoryDesc"].ToString();
      this.lblStatus.Text = this.objSubCategoryMasterDT.Rows[0]["SubCategoryStatus"].ToString() == "True" ? "True" : "False";
      this.objCategoryMasterDT = this.objCategoryMasterBll.GetDataByCategoryID(int.Parse(this.objSubCategoryMasterDT.Rows[0]["CategoryID"].ToString()));
      this.lblCategory.Text = this.objCategoryMasterDT.Rows[0]["CategoryName"].ToString();
    }

    private void SetRecord(string iD)
    {
      this.objSubCategoryMasterDT = this.objSubCategoryMasterBll.GetDataBySubCategoryID(int.Parse(iD));
      if (this.objSubCategoryMasterDT.Rows.Count <= 0)
        return;
      this.hfSubCategory.Value = this.objSubCategoryMasterDT.Rows[0]["SubCategoryID"].ToString();
      this.ddlCategory.SelectedValue = this.objSubCategoryMasterDT.Rows[0]["CategoryID"].ToString();
      this.txtCode.Text = this.objSubCategoryMasterDT.Rows[0]["SubCategoryCode"].ToString();
      this.txtName.Text = this.objSubCategoryMasterDT.Rows[0]["SubCategoryName"].ToString();
      this.txtDesc.Text = this.objSubCategoryMasterDT.Rows[0]["SubCategoryDesc"].ToString();
      this.chkStatus.Checked = this.objSubCategoryMasterDT.Rows[0]["SubCategoryStatus"].ToString() == "True";
    }

    protected void gvSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/SubCategoryMaster.aspx?cmd=view&ID=" + this.gvSubCategory.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvSubCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvSubCategory.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void gvSubCategory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType != DataControlRowType.DataRow)
        return;
      this.objCategoryMasterDT = this.objCategoryMasterBll.GetDataByCategoryID(int.Parse(e.Row.Cells[1].Text));
      if (this.objCategoryMasterDT.Rows.Count == 0)
        return;
      e.Row.Cells[1].Text = this.objCategoryMasterDT.Rows[0]["CategoryName"].ToString();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvSubCategory.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvSubCategory, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void btnAddSubCategory_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/SubCategoryMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      try
      {
        if (!this.Page.IsValid)
          return;
        if (this.ddlCategory.SelectedIndex > 0 && this.txtCode.Text.Trim().Length > 0 && this.txtName.Text.Trim().Length > 0)
        {
          this.objSubCategoryMasterDT = this.objSubCategoryMasterBll.GetDataByCategorySubCategoryName(int.Parse(this.ddlCategory.SelectedItem.Value), this.txtName.Text);
          if (this.objSubCategoryMasterDT.Rows.Count > 0)
          {
            this.DisplayAlert("SubCategory is Already Exist in Category...");
            this.checkInDB = true;
          }
          else
            this.checkInDB = false;
          if (this.checkInDB)
            return;
          int num = this.objSubCategoryMasterBll.AddSubCategory(int.Parse(this.ddlCategory.SelectedItem.Value), this.txtCode.Text.Trim(), this.txtName.Text.Trim(), this.txtDesc.Text.Trim(), this.chkStatus.Checked);
          if (num != 0)
          {
            this.DisplayAlert("Details Added Successfully.");
            this.Response.Redirect("~/Admin/SubCategoryMaster.aspx?cmd=view&ID=" + (object) num);
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
          if (this.ddlCategory.SelectedIndex > 0 && this.txtCode.Text.Trim().Length > 0 && this.txtName.Text.Trim().Length > 0)
          {
            this.objSubCategoryMasterDT = this.objSubCategoryMasterBll.GetDataByCategorySubCategoryName(int.Parse(this.hfSubCategory.Value.Trim()), int.Parse(this.ddlCategory.SelectedItem.Value), this.txtName.Text);
            if (this.objSubCategoryMasterDT.Rows.Count > 0)
            {
              this.DisplayAlert("SubCategory is Already Exist in Category...");
              this.checkInDB = true;
            }
            else
              this.checkInDB = false;
            if (this.checkInDB)
              return;
            if (this.objSubCategoryMasterBll.UpdateSubCategory(int.Parse(this.hfSubCategory.Value.Trim()), int.Parse(this.ddlCategory.SelectedItem.Value), this.txtCode.Text.Trim(), this.txtName.Text.Trim(), this.txtDesc.Text.Trim(), this.chkStatus.Checked))
            {
              this.DisplayAlert("Update Successfully..");
              this.Response.Redirect("~/Admin/SubCategoryMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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
      this.Response.Redirect("~/Admin/SubCategoryMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfSubCategory.Value != null)
      {
        if (this.objSubCategoryMasterBll.DeleteSubCategory(int.Parse(this.hfSubCategory.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/Admin/SubCategoryMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/SubCategoryMaster.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/SubCategoryMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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

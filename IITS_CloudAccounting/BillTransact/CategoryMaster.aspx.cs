// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.CategoryMaster
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
  public class CategoryMaster : Page
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
    protected Label lblCode;
    protected Label lblName;
    protected Label lblDesc;
    protected Label lblStatus;
    protected Button btnEdit;
    protected Button btnDelete;
    protected Button btnList;
    protected Button btnAdd;
    protected Panel pnlViewAll;
    protected GridView gvCategory;
    protected Button btnAddCategory;
    protected HiddenField hfCategory;
    protected HiddenField hfMasterAdminID;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyLoginID;
    protected ObjectDataSource objdsCategory;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("generalMaster")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("Category")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          CategoryMaster.AddStatus = "True";
          CategoryMaster.EditStatus = "True";
          CategoryMaster.ViewStatus = "True";
          CategoryMaster.DeleteStatus = "True";
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
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "CategoryMaster");
          if (this.objMasterAdminRightsMasterDT.Rows.Count > 0)
          {
            CategoryMaster.AddStatus = this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            CategoryMaster.EditStatus = this.objMasterAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            CategoryMaster.ViewStatus = this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            CategoryMaster.DeleteStatus = this.objMasterAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            CategoryMaster.AddStatus = "";
            CategoryMaster.EditStatus = "";
            CategoryMaster.ViewStatus = "";
            CategoryMaster.DeleteStatus = "";
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
          this.objCompanyAdminRightsMasterDT = this.objCompanyAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfCompanyID.Value.Trim()), int.Parse(this.hfCompanyLoginID.Value.Trim()), "CategoryMaster");
          if (this.objCompanyAdminRightsMasterDT.Rows.Count > 0)
          {
            CategoryMaster.AddStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            CategoryMaster.EditStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            CategoryMaster.ViewStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            CategoryMaster.DeleteStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            CategoryMaster.AddStatus = "";
            CategoryMaster.EditStatus = "";
            CategoryMaster.ViewStatus = "";
            CategoryMaster.DeleteStatus = "";
          }
        }
        else
        {
          CategoryMaster.AddStatus = "";
          CategoryMaster.EditStatus = "";
          CategoryMaster.ViewStatus = "";
          CategoryMaster.DeleteStatus = "";
        }
      }
      if (CategoryMaster.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] == null || !(CategoryMaster.ViewStatus == "True"))
                break;
              string i = this.Request.QueryString["ID"];
              this.pnlViewAll.Visible = false;
              this.pnlAdd.Visible = false;
              this.pnlView.Visible = true;
              this.ViewRecord(i);
              this.btnEdit.Visible = CategoryMaster.EditStatus == "True";
              this.btnAddCategory.Visible = this.btnAdd.Visible = CategoryMaster.AddStatus == "True";
              this.btnDelete.Visible = CategoryMaster.DeleteStatus == "True";
              this.btnListAll.Visible = true;
              this.btnUpdate.Visible = false;
              this.btnCancel.Visible = false;
              break;
            case "add":
              if (this.Request.QueryString["ID"] != null)
              {
                if (!(CategoryMaster.EditStatus == "True"))
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
              if (!(CategoryMaster.AddStatus == "True"))
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
          if (CategoryMaster.AddStatus == "False")
            this.btnAddCategory.Visible = this.btnAdd.Visible = false;
          else
            this.btnAddCategory.Visible = this.btnAdd.Visible = true;
        }
      }
      else if (CategoryMaster.AddStatus == "True" && CategoryMaster.EditStatus == "False" && (CategoryMaster.ViewStatus == "False" && CategoryMaster.DeleteStatus == "False"))
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

    private void ViewRecord(string i)
    {
      this.objCategoryMasterDT = this.objCategoryMasterBll.GetDataByCategoryID(int.Parse(i));
      if (this.objCategoryMasterDT.Rows.Count <= 0)
        return;
      this.hfCategory.Value = this.objCategoryMasterDT.Rows[0]["CategoryID"].ToString();
      this.lblCode.Text = this.objCategoryMasterDT.Rows[0]["CategoryCode"].ToString();
      this.lblName.Text = this.objCategoryMasterDT.Rows[0]["CategoryName"].ToString();
      this.lblDesc.Text = this.objCategoryMasterDT.Rows[0]["CategoryDesc"].ToString();
      this.lblStatus.Text = this.objCategoryMasterDT.Rows[0]["CategoryStatus"].ToString() == "True" ? "True" : "False";
    }

    private void SetRecord(string iD)
    {
      this.objCategoryMasterDT = this.objCategoryMasterBll.GetDataByCategoryID(int.Parse(iD));
      if (this.objCategoryMasterDT.Rows.Count <= 0)
        return;
      this.hfCategory.Value = this.objCategoryMasterDT.Rows[0]["CategoryID"].ToString();
      this.txtCode.Text = this.objCategoryMasterDT.Rows[0]["CategoryCode"].ToString();
      this.txtName.Text = this.objCategoryMasterDT.Rows[0]["CategoryName"].ToString();
      this.txtDesc.Text = this.objCategoryMasterDT.Rows[0]["CategoryDesc"].ToString();
      this.chkStatus.Checked = this.objCategoryMasterDT.Rows[0]["CategoryStatus"].ToString() == "True";
    }

    private void Clear()
    {
      this.txtCode.Text = this.txtDesc.Text = this.txtName.Text = (string) null;
      this.chkStatus.Checked = false;
      this.txtCode.Focus();
    }

    private void BindGrid()
    {
      this.gvCategory.DataBind();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvCategory.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvCategory, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void gvCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/CategoryMaster.aspx?cmd=view&ID=" + this.gvCategory.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvCategory.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void btnAddCategory_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/CategoryMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.txtCode.Text.Trim().Length > 0 && this.txtName.Text.Trim().Length > 0)
      {
        this.objCategoryMasterDT = this.objCategoryMasterBll.GetDataByCategoryName(this.txtName.Text);
        if (this.objCategoryMasterDT.Rows.Count > 0)
        {
          this.DisplayAlert("Category Already Exist..");
          this.checkInDB = true;
        }
        else
          this.checkInDB = false;
        if (this.checkInDB)
          return;
        int num = this.objCategoryMasterBll.AddCategory(this.txtCode.Text.Trim(), this.txtName.Text.Trim(), this.txtDesc.Text.Trim(), this.chkStatus.Checked);
        if (num != 0)
        {
          this.DisplayAlert("Details Added Successfully.");
          this.Response.Redirect("~/BillTransact/CategoryMaster.aspx?cmd=view&ID=" + (object) num);
        }
        else
          this.DisplayAlert("Fail to Add New Details.");
      }
      else
        this.DisplayAlert("Please Fill All Details...!");
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
          if (this.txtCode.Text.Trim().Length > 0 && this.txtName.Text.Trim().Length > 0)
          {
            this.objCategoryMasterDT = this.objCategoryMasterBll.GetDataByCategoryName(int.Parse(this.hfCategory.Value.Trim()), this.txtName.Text);
            if (this.objCategoryMasterDT.Rows.Count > 0)
            {
              this.DisplayAlert("Category Already Exist..");
              this.checkInDB = true;
            }
            else
              this.checkInDB = false;
            if (this.checkInDB)
              return;
            if (this.objCategoryMasterBll.UpdateCategory(int.Parse(this.hfCategory.Value.Trim()), this.txtCode.Text.Trim(), this.txtName.Text.Trim(), this.txtDesc.Text.Trim(), this.chkStatus.Checked))
            {
              this.DisplayAlert("Update Successfully..");
              this.Response.Redirect("~/BillTransact/CategoryMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
            }
            else
              this.DisplayAlert("Fail to Update Details.");
          }
          else
            this.DisplayAlert("Please Fill All Details...!");
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
      this.Response.Redirect("~/BillTransact/CategoryMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      this.objSubCategoryMasterDT = this.objSubCategoryMasterBll.GetDataByCategoryID(int.Parse(this.hfCategory.Value));
      if (this.objSubCategoryMasterDT.Rows.Count > 0)
        this.DisplayAlert("Child Data Exist..");
      else if (this.hfCategory.Value != null)
      {
        if (this.objCategoryMasterBll.DeleteCategory(int.Parse(this.hfCategory.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/BillTransact/CategoryMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/CategoryMaster.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/CategoryMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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

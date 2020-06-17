// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.FAQCategoryMaster
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
  public class FAQCategoryMaster : Page
  {
    private static string AddStatus = string.Empty;
    private static string EditStatus = string.Empty;
    private static string ViewStatus = string.Empty;
    private static string DeleteStatus = string.Empty;
    private readonly FAQCategoryMasterBLL objFAQCategoryMasterBll = new FAQCategoryMasterBLL();
    private CloudAccountDA.FAQCategoryMasterDataTable objFAQCategoryMasterDT = new CloudAccountDA.FAQCategoryMasterDataTable();
    private readonly MasterAdminRightsMasterBLL objMasterAdminRightsMasterBll = new MasterAdminRightsMasterBLL();
    private CloudAccountDA.MasterAdminRightsMasterDataTable objMasterAdminRightsMasterDT = new CloudAccountDA.MasterAdminRightsMasterDataTable();
    private readonly MasterAdminLoginMasterBLL objMasterAdminLoginMasterBll = new MasterAdminLoginMasterBLL();
    private CloudAccountDA.MasterAdminLoginMasterDataTable objMasterAdminLoginMasterDT = new CloudAccountDA.MasterAdminLoginMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyAdminRightsMasterBLL objCompanyAdminRightsMasterBll = new CompanyAdminRightsMasterBLL();
    private CloudAccountDA.CompanyAdminRightsMasterDataTable objCompanyAdminRightsMasterDT = new CloudAccountDA.CompanyAdminRightsMasterDataTable();
    public static bool checkInDB;
    protected Panel pnlAdd;
    protected TextBox txtFAQCategoryName;
    protected RequiredFieldValidator rfvFAQCategoryName;
    protected CheckBox chkStatus;
    protected TextBox txtDesc;
    protected Button btnSubmit;
    protected Button btnReset;
    protected Button btnUpdate;
    protected Button btnCancel;
    protected Button btnListAll;
    protected Panel pnlView;
    protected Label lblFAQCategoryName;
    protected Label lblStatus;
    protected Label lblDesc;
    protected Button btnEdit;
    protected Button btnDelete;
    protected Button btnList;
    protected Button btnAdd;
    protected Panel pnlViewAll;
    protected GridView gvFAQCategory;
    protected Button btnAddNew;
    protected ObjectDataSource objdsFAQCategory;
    protected HiddenField hfFAQCategory;
    protected HiddenField hfMasterAdminID;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyLoginID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("cmsMaster")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("faqCat")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          FAQCategoryMaster.AddStatus = "True";
          FAQCategoryMaster.EditStatus = "True";
          FAQCategoryMaster.ViewStatus = "True";
          FAQCategoryMaster.DeleteStatus = "True";
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
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "FAQCategoryMaster");
          if (this.objMasterAdminRightsMasterDT.Rows.Count > 0)
          {
            FAQCategoryMaster.AddStatus = this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            FAQCategoryMaster.EditStatus = this.objMasterAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            FAQCategoryMaster.ViewStatus = this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            FAQCategoryMaster.DeleteStatus = this.objMasterAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            FAQCategoryMaster.AddStatus = "";
            FAQCategoryMaster.EditStatus = "";
            FAQCategoryMaster.ViewStatus = "";
            FAQCategoryMaster.DeleteStatus = "";
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
          this.objCompanyAdminRightsMasterDT = this.objCompanyAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfCompanyID.Value.Trim()), int.Parse(this.hfCompanyLoginID.Value.Trim()), "FAQCategoryMaster");
          if (this.objCompanyAdminRightsMasterDT.Rows.Count > 0)
          {
            FAQCategoryMaster.AddStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            FAQCategoryMaster.EditStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            FAQCategoryMaster.ViewStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            FAQCategoryMaster.DeleteStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            FAQCategoryMaster.AddStatus = "";
            FAQCategoryMaster.EditStatus = "";
            FAQCategoryMaster.ViewStatus = "";
            FAQCategoryMaster.DeleteStatus = "";
          }
        }
        else
        {
          FAQCategoryMaster.AddStatus = "";
          FAQCategoryMaster.EditStatus = "";
          FAQCategoryMaster.ViewStatus = "";
          FAQCategoryMaster.DeleteStatus = "";
        }
      }
      if (FAQCategoryMaster.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] == null || !(FAQCategoryMaster.ViewStatus == "True"))
                break;
              string i = this.Request.QueryString["ID"];
              this.pnlViewAll.Visible = false;
              this.pnlAdd.Visible = false;
              this.pnlView.Visible = true;
              this.ViewRecord(i);
              this.btnEdit.Visible = FAQCategoryMaster.EditStatus == "True";
              this.btnAddNew.Visible = this.btnAdd.Visible = FAQCategoryMaster.AddStatus == "True";
              this.btnDelete.Visible = FAQCategoryMaster.DeleteStatus == "True";
              this.btnListAll.Visible = true;
              this.btnUpdate.Visible = false;
              this.btnCancel.Visible = false;
              break;
            case "add":
              if (this.Request.QueryString["ID"] != null)
              {
                if (!(FAQCategoryMaster.EditStatus == "True"))
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
              if (!(FAQCategoryMaster.AddStatus == "True"))
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
          if (FAQCategoryMaster.AddStatus == "False")
            this.btnAddNew.Visible = this.btnAdd.Visible = false;
          else
            this.btnAddNew.Visible = this.btnAdd.Visible = true;
        }
      }
      else if (FAQCategoryMaster.AddStatus == "True" && FAQCategoryMaster.EditStatus == "False" && (FAQCategoryMaster.ViewStatus == "False" && FAQCategoryMaster.DeleteStatus == "False"))
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
      this.objFAQCategoryMasterDT = this.objFAQCategoryMasterBll.GetDataByFAQCategoryID(int.Parse(i));
      if (this.objFAQCategoryMasterDT.Rows.Count <= 0)
        return;
      this.hfFAQCategory.Value = this.objFAQCategoryMasterDT.Rows[0]["FAQCategoryID"].ToString();
      this.lblFAQCategoryName.Text = this.objFAQCategoryMasterDT.Rows[0]["FAQCategoryName"].ToString();
      this.lblDesc.Text = this.objFAQCategoryMasterDT.Rows[0]["FAQCategoryDesc"].ToString();
      this.lblStatus.Text = this.objFAQCategoryMasterDT.Rows[0]["FAQCategoryStatus"].ToString() == "True" ? "True" : "False";
    }

    private void SetRecord(string iD)
    {
      this.objFAQCategoryMasterDT = this.objFAQCategoryMasterBll.GetDataByFAQCategoryID(int.Parse(iD));
      if (this.objFAQCategoryMasterDT.Rows.Count <= 0)
        return;
      this.hfFAQCategory.Value = this.objFAQCategoryMasterDT.Rows[0]["FAQCategoryID"].ToString();
      this.txtFAQCategoryName.Text = this.objFAQCategoryMasterDT.Rows[0]["FAQCategoryName"].ToString();
      this.txtDesc.Text = this.objFAQCategoryMasterDT.Rows[0]["FAQCategoryDesc"].ToString();
      this.chkStatus.Checked = this.objFAQCategoryMasterDT.Rows[0]["FAQCategoryStatus"].ToString() == "True";
    }

    private void Clear()
    {
      this.txtFAQCategoryName.Text = this.txtDesc.Text = "";
      this.chkStatus.Checked = false;
      this.txtFAQCategoryName.Focus();
    }

    private void BindGrid()
    {
      this.gvFAQCategory.DataBind();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvFAQCategory.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvFAQCategory, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void gvFAQCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/FAQCategoryMaster.aspx?cmd=view&ID=" + this.gvFAQCategory.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvFAQCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvFAQCategory.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void btnAddFAQCategory_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/FAQCategoryMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.txtFAQCategoryName.Text.Trim().Length > 0)
      {
        this.objFAQCategoryMasterDT = this.objFAQCategoryMasterBll.GetDataByFAQCategoryName(this.txtFAQCategoryName.Text);
        if (this.objFAQCategoryMasterDT.Rows.Count > 0)
        {
          this.DisplayAlert("FAQ Category Already Exist..");
          FAQCategoryMaster.checkInDB = true;
        }
        else
          FAQCategoryMaster.checkInDB = false;
        if (!FAQCategoryMaster.checkInDB)
        {
          int num = this.objFAQCategoryMasterBll.AddFAQCategory(this.txtFAQCategoryName.Text.Trim(), this.txtDesc.Text.Trim(), this.chkStatus.Checked);
          if (num != 0)
          {
            this.DisplayAlert("Details Added Successfully.");
            this.Response.Redirect("~/Admin/FAQCategoryMaster.aspx?cmd=view&ID=" + (object) num);
          }
          else
          {
            this.DisplayAlert("Fail to Add New Details.");
            this.Clear();
          }
        }
        else
        {
          this.DisplayAlert("Fail to Add New Details.");
          this.Clear();
        }
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
          if (this.txtFAQCategoryName.Text.Trim().Length > 0)
          {
            if (this.objFAQCategoryMasterBll.UpdateFAQCategory(int.Parse(this.hfFAQCategory.Value.Trim()), this.txtFAQCategoryName.Text.Trim(), this.txtDesc.Text.Trim(), this.chkStatus.Checked))
            {
              this.DisplayAlert("Update Successfully..");
              this.Response.Redirect("~/Admin/FAQCategoryMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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
      this.Response.Redirect("~/Admin/FAQCategoryMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfFAQCategory.Value != null)
      {
        if (this.objFAQCategoryMasterBll.DeleteFAQCategory(int.Parse(this.hfFAQCategory.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/Admin/FAQCategoryMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/FAQCategoryMaster.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/FAQCategoryMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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

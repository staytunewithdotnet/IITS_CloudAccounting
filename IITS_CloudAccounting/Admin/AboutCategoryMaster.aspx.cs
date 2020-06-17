// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.AboutCategoryMaster
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
  public class AboutCategoryMaster : Page
  {
    private static string AddStatus = string.Empty;
    private static string EditStatus = string.Empty;
    private static string ViewStatus = string.Empty;
    private static string DeleteStatus = string.Empty;
    private readonly AboutCategoryMasterBLL objAboutCategoryMasterBll = new AboutCategoryMasterBLL();
    private CloudAccountDA.AboutCategoryMasterDataTable objAboutCategoryMasterDT = new CloudAccountDA.AboutCategoryMasterDataTable();
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
    protected TextBox txtAboutCategoryName;
    protected RequiredFieldValidator rfvAboutCategoryName;
    protected CheckBox chkStatus;
    protected TextBox txtDesc;
    protected Button btnSubmit;
    protected Button btnReset;
    protected Button btnUpdate;
    protected Button btnCancel;
    protected Button btnListAll;
    protected Panel pnlView;
    protected Label lblAboutCategoryName;
    protected Label lblStatus;
    protected Label lblDesc;
    protected Button btnEdit;
    protected Button btnDelete;
    protected Button btnList;
    protected Button btnAdd;
    protected Panel pnlViewAll;
    protected GridView gvAboutCategory;
    protected Button btnAddNew;
    protected ObjectDataSource objdsAboutCategory;
    protected HiddenField hfAboutCategory;
    protected HiddenField hfMasterAdminID;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyLoginID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("cmsMaster")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("aboutCat")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          AboutCategoryMaster.AddStatus = "True";
          AboutCategoryMaster.EditStatus = "True";
          AboutCategoryMaster.ViewStatus = "True";
          AboutCategoryMaster.DeleteStatus = "True";
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
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "AboutCategoryMaster");
          if (this.objMasterAdminRightsMasterDT.Rows.Count > 0)
          {
            AboutCategoryMaster.AddStatus = this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            AboutCategoryMaster.EditStatus = this.objMasterAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            AboutCategoryMaster.ViewStatus = this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            AboutCategoryMaster.DeleteStatus = this.objMasterAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            AboutCategoryMaster.AddStatus = "";
            AboutCategoryMaster.EditStatus = "";
            AboutCategoryMaster.ViewStatus = "";
            AboutCategoryMaster.DeleteStatus = "";
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
          this.objCompanyAdminRightsMasterDT = this.objCompanyAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfCompanyID.Value.Trim()), int.Parse(this.hfCompanyLoginID.Value.Trim()), "AboutCategoryMaster");
          if (this.objCompanyAdminRightsMasterDT.Rows.Count > 0)
          {
            AboutCategoryMaster.AddStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            AboutCategoryMaster.EditStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            AboutCategoryMaster.ViewStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            AboutCategoryMaster.DeleteStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            AboutCategoryMaster.AddStatus = "";
            AboutCategoryMaster.EditStatus = "";
            AboutCategoryMaster.ViewStatus = "";
            AboutCategoryMaster.DeleteStatus = "";
          }
        }
        else
        {
          AboutCategoryMaster.AddStatus = "";
          AboutCategoryMaster.EditStatus = "";
          AboutCategoryMaster.ViewStatus = "";
          AboutCategoryMaster.DeleteStatus = "";
        }
      }
      if (AboutCategoryMaster.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] == null || !(AboutCategoryMaster.ViewStatus == "True"))
                break;
              string i = this.Request.QueryString["ID"];
              this.pnlViewAll.Visible = false;
              this.pnlAdd.Visible = false;
              this.pnlView.Visible = true;
              this.ViewRecord(i);
              this.btnEdit.Visible = AboutCategoryMaster.EditStatus == "True";
              this.btnAddNew.Visible = this.btnAdd.Visible = AboutCategoryMaster.AddStatus == "True";
              this.btnDelete.Visible = AboutCategoryMaster.DeleteStatus == "True";
              this.btnListAll.Visible = true;
              this.btnUpdate.Visible = false;
              this.btnCancel.Visible = false;
              break;
            case "add":
              if (this.Request.QueryString["ID"] != null)
              {
                if (!(AboutCategoryMaster.EditStatus == "True"))
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
              if (!(AboutCategoryMaster.AddStatus == "True"))
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
          if (AboutCategoryMaster.AddStatus == "False")
            this.btnAddNew.Visible = this.btnAdd.Visible = false;
          else
            this.btnAddNew.Visible = this.btnAdd.Visible = true;
        }
      }
      else if (AboutCategoryMaster.AddStatus == "True" && AboutCategoryMaster.EditStatus == "False" && (AboutCategoryMaster.ViewStatus == "False" && AboutCategoryMaster.DeleteStatus == "False"))
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
      this.objAboutCategoryMasterDT = this.objAboutCategoryMasterBll.GetDataByAboutCategoryID(int.Parse(i));
      if (this.objAboutCategoryMasterDT.Rows.Count <= 0)
        return;
      this.hfAboutCategory.Value = this.objAboutCategoryMasterDT.Rows[0]["AboutCategoryID"].ToString();
      this.lblAboutCategoryName.Text = this.objAboutCategoryMasterDT.Rows[0]["AboutCategoryName"].ToString();
      this.lblDesc.Text = this.objAboutCategoryMasterDT.Rows[0]["AboutCategoryDesc"].ToString();
      this.lblStatus.Text = this.objAboutCategoryMasterDT.Rows[0]["AboutCategoryStatus"].ToString() == "True" ? "True" : "False";
    }

    private void SetRecord(string iD)
    {
      this.objAboutCategoryMasterDT = this.objAboutCategoryMasterBll.GetDataByAboutCategoryID(int.Parse(iD));
      if (this.objAboutCategoryMasterDT.Rows.Count <= 0)
        return;
      this.hfAboutCategory.Value = this.objAboutCategoryMasterDT.Rows[0]["AboutCategoryID"].ToString();
      this.txtAboutCategoryName.Text = this.objAboutCategoryMasterDT.Rows[0]["AboutCategoryName"].ToString();
      this.txtDesc.Text = this.objAboutCategoryMasterDT.Rows[0]["AboutCategoryDesc"].ToString();
      this.chkStatus.Checked = this.objAboutCategoryMasterDT.Rows[0]["AboutCategoryStatus"].ToString() == "True";
    }

    private void Clear()
    {
      this.txtAboutCategoryName.Text = this.txtDesc.Text = "";
      this.chkStatus.Checked = false;
      this.txtAboutCategoryName.Focus();
    }

    private void BindGrid()
    {
      this.gvAboutCategory.DataBind();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvAboutCategory.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvAboutCategory, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void gvAboutCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/AboutCategoryMaster.aspx?cmd=view&ID=" + this.gvAboutCategory.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvAboutCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvAboutCategory.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void gvAboutCategory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType != DataControlRowType.DataRow)
        return;
      this.objAboutCategoryMasterDT = this.objAboutCategoryMasterBll.GetDataByAboutCategoryID(int.Parse(e.Row.Cells[1].Text));
      if (this.objAboutCategoryMasterDT.Rows.Count == 0)
        return;
      e.Row.Cells[1].Text = this.objAboutCategoryMasterDT.Rows[0]["AboutCategoryName"].ToString();
    }

    protected void btnAddAboutCategory_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/AboutCategoryMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.txtAboutCategoryName.Text.Trim().Length > 0)
      {
        this.objAboutCategoryMasterDT = this.objAboutCategoryMasterBll.GetDataByAboutCategoryName(this.txtAboutCategoryName.Text);
        if (this.objAboutCategoryMasterDT.Rows.Count > 0)
        {
          this.DisplayAlert("About Category Already Exist..");
          AboutCategoryMaster.checkInDB = true;
        }
        else
          AboutCategoryMaster.checkInDB = false;
        if (!AboutCategoryMaster.checkInDB)
        {
          int num = this.objAboutCategoryMasterBll.AddAboutCategory(this.txtAboutCategoryName.Text.Trim(), this.txtDesc.Text.Trim(), this.chkStatus.Checked);
          if (num != 0)
          {
            this.DisplayAlert("Details Added Successfully.");
            this.Response.Redirect("~/Admin/AboutCategoryMaster.aspx?cmd=view&ID=" + (object) num);
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
          if (this.txtAboutCategoryName.Text.Trim().Length > 0)
          {
            if (this.objAboutCategoryMasterBll.UpdateAboutCategory(int.Parse(this.hfAboutCategory.Value.Trim()), this.txtAboutCategoryName.Text.Trim(), this.txtDesc.Text.Trim(), this.chkStatus.Checked))
            {
              this.DisplayAlert("Update Successfully..");
              this.Response.Redirect("~/Admin/AboutCategoryMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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
      this.Response.Redirect("~/Admin/AboutCategoryMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfAboutCategory.Value != null)
      {
        if (this.objAboutCategoryMasterBll.DeleteAboutCategory(int.Parse(this.hfAboutCategory.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/Admin/AboutCategoryMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/AboutCategoryMaster.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/AboutCategoryMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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

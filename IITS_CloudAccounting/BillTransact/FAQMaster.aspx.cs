// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.FAQMaster
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
  public class FAQMaster : Page
  {
    private static string AddStatus = string.Empty;
    private static string EditStatus = string.Empty;
    private static string ViewStatus = string.Empty;
    private static string DeleteStatus = string.Empty;
    private readonly FAQMasterBLL objFAQMasterBll = new FAQMasterBLL();
    private CloudAccountDA.FAQMasterDataTable objFAQMasterDT = new CloudAccountDA.FAQMasterDataTable();
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
    protected DropDownList ddlFAQCategory;
    protected SqlDataSource sqldsFAQCategory;
    protected RequiredFieldValidator rfvFAQName;
    protected TextBox txtFAQQuestion;
    protected RequiredFieldValidator rfvFAQQuestion;
    protected TextBox txtFAQAnswer;
    protected CheckBox chkStatus;
    protected Button btnSubmit;
    protected Button btnReset;
    protected Button btnUpdate;
    protected Button btnCancel;
    protected Button btnListAll;
    protected Panel pnlView;
    protected Label lblFAQCategory;
    protected Label lblFAQQuestion;
    protected Label lblFAQAnswer;
    protected Label lblStatus;
    protected Button btnEdit;
    protected Button btnDelete;
    protected Button btnList;
    protected Button btnAdd;
    protected Panel pnlViewAll;
    protected GridView gvFAQ;
    protected Button btnAddNew;
    protected ObjectDataSource objdsFAQ;
    protected HiddenField hfFAQ;
    protected HiddenField hfMasterAdminID;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyLoginID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("cmsMaster")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("faqMaster")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          FAQMaster.AddStatus = "True";
          FAQMaster.EditStatus = "True";
          FAQMaster.ViewStatus = "True";
          FAQMaster.DeleteStatus = "True";
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
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "FAQMaster");
          if (this.objMasterAdminRightsMasterDT.Rows.Count > 0)
          {
            FAQMaster.AddStatus = this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            FAQMaster.EditStatus = this.objMasterAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            FAQMaster.ViewStatus = this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            FAQMaster.DeleteStatus = this.objMasterAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            FAQMaster.AddStatus = "";
            FAQMaster.EditStatus = "";
            FAQMaster.ViewStatus = "";
            FAQMaster.DeleteStatus = "";
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
          this.objCompanyAdminRightsMasterDT = this.objCompanyAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfCompanyID.Value.Trim()), int.Parse(this.hfCompanyLoginID.Value.Trim()), "FAQMaster");
          if (this.objCompanyAdminRightsMasterDT.Rows.Count > 0)
          {
            FAQMaster.AddStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            FAQMaster.EditStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            FAQMaster.ViewStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            FAQMaster.DeleteStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            FAQMaster.AddStatus = "";
            FAQMaster.EditStatus = "";
            FAQMaster.ViewStatus = "";
            FAQMaster.DeleteStatus = "";
          }
        }
        else
        {
          FAQMaster.AddStatus = "";
          FAQMaster.EditStatus = "";
          FAQMaster.ViewStatus = "";
          FAQMaster.DeleteStatus = "";
        }
      }
      if (FAQMaster.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] == null || !(FAQMaster.ViewStatus == "True"))
                break;
              string i = this.Request.QueryString["ID"];
              this.pnlViewAll.Visible = false;
              this.pnlAdd.Visible = false;
              this.pnlView.Visible = true;
              this.ViewRecord(i);
              this.btnEdit.Visible = FAQMaster.EditStatus == "True";
              this.btnAddNew.Visible = this.btnAdd.Visible = FAQMaster.AddStatus == "True";
              this.btnDelete.Visible = FAQMaster.DeleteStatus == "True";
              this.btnListAll.Visible = true;
              this.btnUpdate.Visible = false;
              this.btnCancel.Visible = false;
              break;
            case "add":
              if (this.Request.QueryString["ID"] != null)
              {
                if (!(FAQMaster.EditStatus == "True"))
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
              if (!(FAQMaster.AddStatus == "True"))
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
          if (FAQMaster.AddStatus == "False")
            this.btnAddNew.Visible = this.btnAdd.Visible = false;
          else
            this.btnAddNew.Visible = this.btnAdd.Visible = true;
        }
      }
      else if (FAQMaster.AddStatus == "True" && FAQMaster.EditStatus == "False" && (FAQMaster.ViewStatus == "False" && FAQMaster.DeleteStatus == "False"))
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
      this.objFAQMasterDT = this.objFAQMasterBll.GetDataByFAQID(int.Parse(i));
      if (this.objFAQMasterDT.Rows.Count <= 0)
        return;
      this.hfFAQ.Value = this.objFAQMasterDT.Rows[0]["FAQID"].ToString();
      this.lblFAQQuestion.Text = this.objFAQMasterDT.Rows[0]["Question"].ToString();
      this.lblFAQAnswer.Text = this.objFAQMasterDT.Rows[0]["Answer"].ToString();
      this.lblStatus.Text = this.objFAQMasterDT.Rows[0]["Status"].ToString() == "True" ? "True" : "False";
      this.lblFAQCategory.Text = this.objFAQMasterDT.Rows[0]["FAQCategoryID"].ToString();
      this.objFAQCategoryMasterDT = this.objFAQCategoryMasterBll.GetDataByFAQCategoryID(int.Parse(this.lblFAQCategory.Text));
      this.lblFAQCategory.Text = this.objFAQCategoryMasterDT.Rows[0]["FAQCategoryName"].ToString();
    }

    private void SetRecord(string iD)
    {
      this.objFAQMasterDT = this.objFAQMasterBll.GetDataByFAQID(int.Parse(iD));
      if (this.objFAQMasterDT.Rows.Count <= 0)
        return;
      this.hfFAQ.Value = this.objFAQMasterDT.Rows[0]["FAQID"].ToString();
      this.txtFAQQuestion.Text = this.objFAQMasterDT.Rows[0]["Question"].ToString();
      this.txtFAQAnswer.Text = this.objFAQMasterDT.Rows[0]["Answer"].ToString();
      this.chkStatus.Checked = this.objFAQMasterDT.Rows[0]["Status"].ToString() == "True";
      this.objFAQCategoryMasterDT = this.objFAQCategoryMasterBll.GetDataByFAQCategoryID(int.Parse(this.objFAQMasterDT.Rows[0]["FAQCategoryID"].ToString()));
      if (this.objFAQCategoryMasterDT.Rows.Count <= 0)
        return;
      this.ddlFAQCategory.Items.Add(this.objFAQCategoryMasterDT.Rows[0]["FAQCategoryID"].ToString());
      this.ddlFAQCategory.SelectedValue = this.objFAQCategoryMasterDT.Rows[0]["FAQCategoryID"].ToString();
    }

    private void Clear()
    {
      this.txtFAQQuestion.Text = this.txtFAQAnswer.Text = "";
      this.chkStatus.Checked = false;
      this.ddlFAQCategory.SelectedIndex = 0;
      this.ddlFAQCategory.Focus();
    }

    private void BindGrid()
    {
      this.gvFAQ.DataBind();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvFAQ.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvFAQ, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void gvFAQ_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/FAQMaster.aspx?cmd=view&ID=" + this.gvFAQ.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvFAQ_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvFAQ.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void gvFAQ_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType != DataControlRowType.DataRow)
        return;
      this.objFAQCategoryMasterDT = this.objFAQCategoryMasterBll.GetDataByFAQCategoryID(int.Parse(e.Row.Cells[1].Text));
      if (this.objFAQCategoryMasterDT.Rows.Count == 0)
        return;
      e.Row.Cells[1].Text = this.objFAQCategoryMasterDT.Rows[0]["FAQCategoryName"].ToString();
    }

    protected void btnAddFAQ_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/FAQMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.ddlFAQCategory.SelectedIndex > 0 && this.txtFAQQuestion.Text.Trim().Length > 0 && this.txtFAQAnswer.Text.Trim().Length > 0)
      {
        int num = this.objFAQMasterBll.AddFAQ(int.Parse(this.ddlFAQCategory.SelectedItem.Value), this.txtFAQQuestion.Text.Trim(), this.txtFAQAnswer.Text.Trim(), this.chkStatus.Checked);
        if (num != 0)
        {
          this.DisplayAlert("Details Added Successfully.");
          this.Response.Redirect("~/BillTransact/FAQMaster.aspx?cmd=view&ID=" + (object) num);
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
          if (this.ddlFAQCategory.SelectedIndex > 0 && this.txtFAQQuestion.Text.Trim().Length > 0 && this.txtFAQAnswer.Text.Trim().Length > 0)
          {
            if (this.objFAQMasterBll.UpdateFAQ(int.Parse(this.hfFAQ.Value.Trim()), int.Parse(this.ddlFAQCategory.SelectedItem.Value), this.txtFAQQuestion.Text.Trim(), this.txtFAQAnswer.Text.Trim(), this.chkStatus.Checked))
            {
              this.DisplayAlert("Update Successfully..");
              this.Response.Redirect("~/BillTransact/FAQMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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
      this.Response.Redirect("~/BillTransact/FAQMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfFAQ.Value != null)
      {
        if (this.objFAQMasterBll.DeleteFAQ(int.Parse(this.hfFAQ.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/BillTransact/FAQMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/FAQMaster.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/FAQMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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

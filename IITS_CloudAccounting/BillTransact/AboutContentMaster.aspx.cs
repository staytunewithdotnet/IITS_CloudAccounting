// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.AboutContentMaster
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using AjaxControlToolkit.HTMLEditor;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class AboutContentMaster : Page
  {
    private static string AddStatus = string.Empty;
    private static string EditStatus = string.Empty;
    private static string ViewStatus = string.Empty;
    private static string DeleteStatus = string.Empty;
    private readonly AboutContentMasterBLL objAboutContentMasterBll = new AboutContentMasterBLL();
    private CloudAccountDA.AboutContentMasterDataTable objAboutContentMasterDT = new CloudAccountDA.AboutContentMasterDataTable();
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
    protected ToolkitScriptManager tsm;
    protected Panel pnlAdd;
    protected DropDownList ddlAboutCategory;
    protected SqlDataSource sqldsAboutCategory;
    protected RequiredFieldValidator rfvAboutCategory;
    protected CheckBox chkStatus;
    protected FileUpload fuAboutContentImage;
    protected Editor edContent;
    protected RequiredFieldValidator rfvAboutContent;
    protected Button btnSubmit;
    protected Button btnReset;
    protected Button btnUpdate;
    protected Button btnCancel;
    protected Button btnListAll;
    protected Panel pnlView;
    protected Label lblAboutCategory;
    protected Label lblStatus;
    protected Image imgAboutContentImage;
    protected Label lblContent;
    protected Button btnEdit;
    protected Button btnDelete;
    protected Button btnList;
    protected Button btnAdd;
    protected Panel pnlViewAll;
    protected GridView gvAboutContent;
    protected Button btnAddNew;
    protected ObjectDataSource objdsAboutContent;
    protected HiddenField hfAboutContent;
    protected HiddenField hfMasterAdminID;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyLoginID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("cmsMaster")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("aboutCon")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          AboutContentMaster.AddStatus = "True";
          AboutContentMaster.EditStatus = "True";
          AboutContentMaster.ViewStatus = "True";
          AboutContentMaster.DeleteStatus = "True";
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
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "AboutContentMaster");
          if (this.objMasterAdminRightsMasterDT.Rows.Count > 0)
          {
            AboutContentMaster.AddStatus = this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            AboutContentMaster.EditStatus = this.objMasterAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            AboutContentMaster.ViewStatus = this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            AboutContentMaster.DeleteStatus = this.objMasterAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            AboutContentMaster.AddStatus = "";
            AboutContentMaster.EditStatus = "";
            AboutContentMaster.ViewStatus = "";
            AboutContentMaster.DeleteStatus = "";
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
          this.objCompanyAdminRightsMasterDT = this.objCompanyAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfCompanyID.Value.Trim()), int.Parse(this.hfCompanyLoginID.Value.Trim()), "AboutContentMaster");
          if (this.objCompanyAdminRightsMasterDT.Rows.Count > 0)
          {
            AboutContentMaster.AddStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            AboutContentMaster.EditStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            AboutContentMaster.ViewStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            AboutContentMaster.DeleteStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            AboutContentMaster.AddStatus = "";
            AboutContentMaster.EditStatus = "";
            AboutContentMaster.ViewStatus = "";
            AboutContentMaster.DeleteStatus = "";
          }
        }
        else
        {
          AboutContentMaster.AddStatus = "";
          AboutContentMaster.EditStatus = "";
          AboutContentMaster.ViewStatus = "";
          AboutContentMaster.DeleteStatus = "";
        }
      }
      if (AboutContentMaster.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] == null || !(AboutContentMaster.ViewStatus == "True"))
                break;
              string i = this.Request.QueryString["ID"];
              this.pnlViewAll.Visible = false;
              this.pnlAdd.Visible = false;
              this.pnlView.Visible = true;
              this.ViewRecord(i);
              this.btnEdit.Visible = AboutContentMaster.EditStatus == "True";
              this.btnAddNew.Visible = this.btnAdd.Visible = AboutContentMaster.AddStatus == "True";
              this.btnDelete.Visible = AboutContentMaster.DeleteStatus == "True";
              this.btnListAll.Visible = true;
              this.btnUpdate.Visible = false;
              this.btnCancel.Visible = false;
              break;
            case "add":
              if (this.Request.QueryString["ID"] != null)
              {
                if (!(AboutContentMaster.EditStatus == "True"))
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
              if (!(AboutContentMaster.AddStatus == "True"))
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
          if (AboutContentMaster.AddStatus == "False")
            this.btnAddNew.Visible = this.btnAdd.Visible = false;
          else
            this.btnAddNew.Visible = this.btnAdd.Visible = true;
        }
      }
      else if (AboutContentMaster.AddStatus == "True" && AboutContentMaster.EditStatus == "False" && (AboutContentMaster.ViewStatus == "False" && AboutContentMaster.DeleteStatus == "False"))
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
      this.objAboutContentMasterDT = this.objAboutContentMasterBll.GetDataByAboutContentID(int.Parse(i));
      if (this.objAboutContentMasterDT.Rows.Count <= 0)
        return;
      this.hfAboutContent.Value = this.objAboutContentMasterDT.Rows[0]["AboutContentID"].ToString();
      this.lblContent.Text = this.objAboutContentMasterDT.Rows[0]["AboutContent"].ToString();
      this.lblStatus.Text = this.objAboutContentMasterDT.Rows[0]["AboutContentStatus"].ToString() == "True" ? "True" : "False";
      if (!string.IsNullOrEmpty(this.objAboutContentMasterDT.Rows[0]["AboutContentImage"].ToString()))
      {
        this.imgAboutContentImage.ImageUrl = "~/Handler/AboutContentHandler.ashx?id=" + this.hfAboutContent.Value;
      }
      else
      {
        this.imgAboutContentImage.ImageUrl = (string) null;
        this.imgAboutContentImage.Visible = false;
      }
      this.lblAboutCategory.Text = this.objAboutContentMasterDT.Rows[0]["AboutCategoryID"].ToString();
      this.objAboutCategoryMasterDT = this.objAboutCategoryMasterBll.GetDataByAboutCategoryID(int.Parse(this.lblAboutCategory.Text));
      this.lblAboutCategory.Text = this.objAboutCategoryMasterDT.Rows[0]["AboutCategoryName"].ToString();
    }

    private void SetRecord(string iD)
    {
      this.objAboutContentMasterDT = this.objAboutContentMasterBll.GetDataByAboutContentID(int.Parse(iD));
      if (this.objAboutContentMasterDT.Rows.Count <= 0)
        return;
      this.hfAboutContent.Value = this.objAboutContentMasterDT.Rows[0]["AboutContentID"].ToString();
      this.objAboutCategoryMasterDT = this.objAboutCategoryMasterBll.GetDataByAboutCategoryID(int.Parse(this.objAboutContentMasterDT.Rows[0]["AboutCategoryID"].ToString()));
      if (this.objAboutCategoryMasterDT.Rows.Count > 0)
      {
        this.ddlAboutCategory.Items.Add(this.objAboutCategoryMasterDT.Rows[0]["AboutCategoryID"].ToString());
        this.ddlAboutCategory.SelectedValue = this.objAboutCategoryMasterDT.Rows[0]["AboutCategoryID"].ToString();
      }
      this.edContent.Content = this.objAboutContentMasterDT.Rows[0]["AboutContent"].ToString();
      this.chkStatus.Checked = this.objAboutContentMasterDT.Rows[0]["AboutContentStatus"].ToString() == "True";
    }

    private void Clear()
    {
      this.edContent.Content = "";
      this.chkStatus.Checked = false;
      this.ddlAboutCategory.SelectedIndex = 0;
      this.ddlAboutCategory.Focus();
    }

    private void BindGrid()
    {
      this.gvAboutContent.DataBind();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvAboutContent.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvAboutContent, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void gvAboutContent_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/AboutContentMaster.aspx?cmd=view&ID=" + this.gvAboutContent.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvAboutContent_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvAboutContent.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void gvAboutContent_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType != DataControlRowType.DataRow)
        return;
      this.objAboutCategoryMasterDT = this.objAboutCategoryMasterBll.GetDataByAboutCategoryID(int.Parse(e.Row.Cells[1].Text));
      if (this.objAboutCategoryMasterDT.Rows.Count == 0)
        return;
      e.Row.Cells[1].Text = this.objAboutCategoryMasterDT.Rows[0]["AboutCategoryName"].ToString();
    }

    protected void btnAddAboutContent_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/AboutContentMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.ddlAboutCategory.SelectedIndex > 0)
      {
        byte[] numArray = (byte[]) null;
        if (this.fuAboutContentImage.HasFile)
        {
          int contentLength = this.fuAboutContentImage.PostedFile.ContentLength;
          numArray = new byte[contentLength];
          this.fuAboutContentImage.PostedFile.InputStream.Read(numArray, 0, contentLength);
        }
        int num = this.objAboutContentMasterBll.AddAboutContent(int.Parse(this.ddlAboutCategory.SelectedItem.Value), this.edContent.Content, numArray, this.chkStatus.Checked);
        if (num != 0)
        {
          this.DisplayAlert("Details Added Successfully.");
          this.Response.Redirect("~/Admin/AboutContentMaster.aspx?cmd=view&ID=" + (object) num);
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
          if (this.ddlAboutCategory.SelectedIndex > 0)
          {
            bool flag;
            if (this.fuAboutContentImage.HasFile)
            {
              int contentLength = this.fuAboutContentImage.PostedFile.ContentLength;
              byte[] numArray = new byte[contentLength];
              this.fuAboutContentImage.PostedFile.InputStream.Read(numArray, 0, contentLength);
              flag = this.objAboutContentMasterBll.UpdateAboutContent(int.Parse(this.hfAboutContent.Value.Trim()), int.Parse(this.ddlAboutCategory.SelectedItem.Value), this.edContent.Content, numArray, this.chkStatus.Checked);
            }
            else
            {
              this.objAboutContentMasterDT = this.objAboutContentMasterBll.GetDataByAboutContentID(int.Parse(this.hfAboutContent.Value.Trim()));
              byte[] byAboutContentImage = (byte[]) null;
              if (!string.IsNullOrEmpty(this.objAboutContentMasterDT.Rows[0]["AboutContentImage"].ToString()))
                byAboutContentImage = (byte[]) this.objAboutContentMasterDT.Rows[0]["AboutContentImage"];
              flag = this.objAboutContentMasterBll.UpdateAboutContent(int.Parse(this.hfAboutContent.Value.Trim()), int.Parse(this.ddlAboutCategory.SelectedItem.Value), this.edContent.Content, byAboutContentImage, this.chkStatus.Checked);
            }
            if (flag)
            {
              this.DisplayAlert("Update Successfully..");
              this.Response.Redirect("~/Admin/AboutContentMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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
      this.Response.Redirect("~/Admin/AboutContentMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfAboutContent.Value != null)
      {
        if (this.objAboutContentMasterBll.DeleteAboutContent(int.Parse(this.hfAboutContent.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/Admin/AboutContentMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/AboutContentMaster.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/AboutContentMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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

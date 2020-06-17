// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.FeatureContentMaster
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using AjaxControlToolkit.HTMLEditor;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class FeatureContentMaster : Page
  {
    private readonly FeatureContentMasterBLL objFeatureContentMasterBll = new FeatureContentMasterBLL();
    private CloudAccountDA.FeatureContentMasterDataTable objFeatureContentMasterDT = new CloudAccountDA.FeatureContentMasterDataTable();
    private readonly FeatureCategoryMasterBLL objFeatureCategoryMasterBll = new FeatureCategoryMasterBLL();
    private CloudAccountDA.FeatureCategoryMasterDataTable objFeatureCategoryMasterDT = new CloudAccountDA.FeatureCategoryMasterDataTable();
    protected ToolkitScriptManager tsm;
    protected Panel pnlAdd;
    protected DropDownList ddlFeatureCategory;
    protected SqlDataSource sqldsFeatureCategory;
    protected RequiredFieldValidator rfvFeatureCategory;
    protected CheckBox chkStatus;
    protected Editor edContent;
    protected RequiredFieldValidator rfvFeatureContent;
    protected Button btnSubmit;
    protected Button btnReset;
    protected Button btnUpdate;
    protected Button btnCancel;
    protected Button btnListAll;
    protected Panel pnlView;
    protected Label lblFeatureCategory;
    protected Label lblStatus;
    protected Label lblContent;
    protected Button btnEdit;
    protected Button btnDelete;
    protected Button btnList;
    protected Button btnAdd;
    protected Panel pnlViewAll;
    protected GridView gvFeatureContent;
    protected Button btnAddNew;
    protected ObjectDataSource objdsFeatureContent;
    protected HiddenField hfFeatureContent;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("cmsMaster")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("featureCon")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (this.Request.QueryString["cmd"] != null)
      {
        switch (this.Request.QueryString["cmd"])
        {
          case "view":
            if (this.Request.QueryString["ID"] == null)
              break;
            string i = this.Request.QueryString["ID"];
            this.pnlView.Visible = true;
            this.pnlViewAll.Visible = false;
            this.pnlAdd.Visible = false;
            this.ViewRecord(i);
            break;
          case "add":
            if (this.Request.QueryString["ID"] != null)
            {
              this.SetRecord(this.Request.QueryString["ID"]);
              this.pnlAdd.Visible = true;
              this.pnlView.Visible = false;
              this.pnlViewAll.Visible = false;
              this.btnSubmit.Visible = false;
              this.btnUpdate.Visible = true;
              this.btnReset.Visible = false;
              this.btnListAll.Visible = false;
              this.btnCancel.Visible = true;
              this.ddlFeatureCategory.Focus();
              break;
            }
            this.pnlAdd.Visible = true;
            this.pnlView.Visible = false;
            this.pnlViewAll.Visible = false;
            this.btnSubmit.Visible = true;
            this.btnUpdate.Visible = false;
            this.btnReset.Visible = true;
            this.btnListAll.Visible = true;
            this.btnCancel.Visible = false;
            this.Clear();
            break;
          default:
            this.pnlAdd.Visible = false;
            this.pnlView.Visible = false;
            this.pnlViewAll.Visible = true;
            this.BindGrid();
            break;
        }
      }
      else
      {
        this.pnlAdd.Visible = false;
        this.pnlView.Visible = false;
        this.pnlViewAll.Visible = true;
        this.BindGrid();
      }
    }

    private void ViewRecord(string i)
    {
      this.objFeatureContentMasterDT = this.objFeatureContentMasterBll.GetDataByFeatureContentID(int.Parse(i));
      if (this.objFeatureContentMasterDT.Rows.Count <= 0)
        return;
      this.hfFeatureContent.Value = this.objFeatureContentMasterDT.Rows[0]["FeatureContentID"].ToString();
      this.lblContent.Text = this.objFeatureContentMasterDT.Rows[0]["FeatureContent"].ToString();
      this.lblStatus.Text = this.objFeatureContentMasterDT.Rows[0]["Status"].ToString() == "True" ? "True" : "False";
      this.lblFeatureCategory.Text = this.objFeatureContentMasterDT.Rows[0]["FeatureCategoryID"].ToString();
      this.objFeatureCategoryMasterDT = this.objFeatureCategoryMasterBll.GetDataByFeatureCategoryID(int.Parse(this.lblFeatureCategory.Text));
      this.lblFeatureCategory.Text = this.objFeatureCategoryMasterDT.Rows[0]["FeatureCategoryName"].ToString();
    }

    private void SetRecord(string iD)
    {
      this.objFeatureContentMasterDT = this.objFeatureContentMasterBll.GetDataByFeatureContentID(int.Parse(iD));
      if (this.objFeatureContentMasterDT.Rows.Count <= 0)
        return;
      this.hfFeatureContent.Value = this.objFeatureContentMasterDT.Rows[0]["FeatureContentID"].ToString();
      this.objFeatureCategoryMasterDT = this.objFeatureCategoryMasterBll.GetDataByFeatureCategoryID(int.Parse(this.objFeatureContentMasterDT.Rows[0]["FeatureCategoryID"].ToString()));
      if (this.objFeatureCategoryMasterDT.Rows.Count > 0)
      {
        this.ddlFeatureCategory.Items.Add(this.objFeatureCategoryMasterDT.Rows[0]["FeatureCategoryID"].ToString());
        this.ddlFeatureCategory.SelectedValue = this.objFeatureCategoryMasterDT.Rows[0]["FeatureCategoryID"].ToString();
      }
      this.edContent.Content = this.objFeatureContentMasterDT.Rows[0]["FeatureContent"].ToString();
      this.chkStatus.Checked = this.objFeatureContentMasterDT.Rows[0]["Status"].ToString() == "True";
    }

    private void Clear()
    {
      this.edContent.Content = "";
      this.chkStatus.Checked = false;
      this.ddlFeatureCategory.SelectedIndex = 0;
      this.ddlFeatureCategory.Focus();
    }

    private void BindGrid()
    {
      this.gvFeatureContent.DataBind();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvFeatureContent.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvFeatureContent, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void gvFeatureContent_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/FeatureContentMaster.aspx?cmd=view&ID=" + this.gvFeatureContent.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvFeatureContent_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvFeatureContent.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void gvFeatureContent_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType != DataControlRowType.DataRow)
        return;
      this.objFeatureCategoryMasterDT = this.objFeatureCategoryMasterBll.GetDataByFeatureCategoryID(int.Parse(e.Row.Cells[1].Text));
      if (this.objFeatureCategoryMasterDT.Rows.Count == 0)
        return;
      e.Row.Cells[1].Text = this.objFeatureCategoryMasterDT.Rows[0]["FeatureCategoryName"].ToString();
    }

    protected void btnAddFeatureContent_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/FeatureContentMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.ddlFeatureCategory.SelectedIndex > 0 && this.edContent.Content.Trim().Length > 0)
      {
        int num = this.objFeatureContentMasterBll.AddFeatureContent(int.Parse(this.ddlFeatureCategory.SelectedItem.Value), this.edContent.Content, this.chkStatus.Checked);
        if (num != 0)
        {
          this.DisplayAlert("Details Added Successfully.");
          this.Response.Redirect("~/Admin/FeatureContentMaster.aspx?cmd=view&ID=" + (object) num);
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
          if (this.ddlFeatureCategory.SelectedIndex > 0 && this.edContent.Content.Trim().Length > 0)
          {
            this.objFeatureContentMasterDT = this.objFeatureContentMasterBll.GetDataByFeatureContentID(int.Parse(this.hfFeatureContent.Value.Trim()));
            if (this.objFeatureContentMasterBll.UpdateFeatureContent(int.Parse(this.hfFeatureContent.Value.Trim()), int.Parse(this.ddlFeatureCategory.SelectedItem.Value), this.edContent.Content, this.chkStatus.Checked))
            {
              this.DisplayAlert("Update Successfully..");
              this.Response.Redirect("~/Admin/FeatureContentMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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
      this.Response.Redirect("~/Admin/FeatureContentMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfFeatureContent.Value != null)
      {
        if (this.objFeatureContentMasterBll.DeleteFeatureContent(int.Parse(this.hfFeatureContent.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/Admin/FeatureContentMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/FeatureContentMaster.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/FeatureContentMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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

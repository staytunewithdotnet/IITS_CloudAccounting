// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.FeatureCategoryMaster
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using DABL.BLL;
using DABL.DAL;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class FeatureCategoryMaster : Page
  {
    private readonly FeatureCategoryMasterBLL objFeatureCategoryMasterBll = new FeatureCategoryMasterBLL();
    private CloudAccountDA.FeatureCategoryMasterDataTable objFeatureCategoryMasterDT = new CloudAccountDA.FeatureCategoryMasterDataTable();
    public static bool checkInDB;
    protected Panel pnlAdd;
    protected TextBox txtFeatureCategoryName;
    protected RequiredFieldValidator rfvFeatureCategoryName;
    protected CheckBox chkStatus;
    protected CheckBox chkHome;
    protected TextBox txtDesc;
    protected Button btnSubmit;
    protected Button btnReset;
    protected Button btnUpdate;
    protected Button btnCancel;
    protected Button btnListAll;
    protected Panel pnlView;
    protected Label lblFeatureCategoryName;
    protected Label lblStatus;
    protected Label lblHome;
    protected Label lblDesc;
    protected Button btnEdit;
    protected Button btnDelete;
    protected Button btnList;
    protected Button btnAdd;
    protected Panel pnlViewAll;
    protected GridView gvFeatureCategory;
    protected Button btnAddNew;
    protected ObjectDataSource objdsFeatureCategory;
    protected HiddenField hfFeatureCategory;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("cmsMaster")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("featureCat")).Attributes.Add("class", "active open");
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
              this.txtFeatureCategoryName.Focus();
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
      this.objFeatureCategoryMasterDT = this.objFeatureCategoryMasterBll.GetDataByFeatureCategoryID(int.Parse(i));
      if (this.objFeatureCategoryMasterDT.Rows.Count <= 0)
        return;
      this.hfFeatureCategory.Value = this.objFeatureCategoryMasterDT.Rows[0]["FeatureCategoryID"].ToString();
      this.lblFeatureCategoryName.Text = this.objFeatureCategoryMasterDT.Rows[0]["FeatureCategoryName"].ToString();
      this.lblDesc.Text = this.objFeatureCategoryMasterDT.Rows[0]["Description"].ToString();
      this.lblStatus.Text = this.objFeatureCategoryMasterDT.Rows[0]["Status"].ToString() == "True" ? "True" : "False";
      this.lblHome.Text = this.objFeatureCategoryMasterDT.Rows[0]["ShowOnHomePage"].ToString() == "True" ? "True" : "False";
    }

    private void SetRecord(string iD)
    {
      this.objFeatureCategoryMasterDT = this.objFeatureCategoryMasterBll.GetDataByFeatureCategoryID(int.Parse(iD));
      if (this.objFeatureCategoryMasterDT.Rows.Count <= 0)
        return;
      this.hfFeatureCategory.Value = this.objFeatureCategoryMasterDT.Rows[0]["FeatureCategoryID"].ToString();
      this.txtFeatureCategoryName.Text = this.objFeatureCategoryMasterDT.Rows[0]["FeatureCategoryName"].ToString();
      this.txtDesc.Text = this.objFeatureCategoryMasterDT.Rows[0]["Description"].ToString();
      this.chkStatus.Checked = this.objFeatureCategoryMasterDT.Rows[0]["Status"].ToString() == "True";
      this.chkHome.Checked = this.objFeatureCategoryMasterDT.Rows[0]["ShowOnHomePage"].ToString() == "True";
    }

    private void Clear()
    {
      this.txtFeatureCategoryName.Text = this.txtDesc.Text = "";
      this.chkStatus.Checked = this.chkHome.Checked = false;
      this.txtFeatureCategoryName.Focus();
    }

    private void BindGrid()
    {
      this.gvFeatureCategory.DataBind();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvFeatureCategory.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvFeatureCategory, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void gvFeatureCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/FeatureCategoryMaster.aspx?cmd=view&ID=" + this.gvFeatureCategory.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvFeatureCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvFeatureCategory.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void gvFeatureCategory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType != DataControlRowType.DataRow)
        return;
      this.objFeatureCategoryMasterDT = this.objFeatureCategoryMasterBll.GetDataByFeatureCategoryID(int.Parse(e.Row.Cells[1].Text));
      if (this.objFeatureCategoryMasterDT.Rows.Count == 0)
        return;
      e.Row.Cells[1].Text = this.objFeatureCategoryMasterDT.Rows[0]["FeatureCategoryName"].ToString();
    }

    protected void btnAddFeatureCategory_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/FeatureCategoryMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.txtFeatureCategoryName.Text.Trim().Length > 0)
      {
        this.objFeatureCategoryMasterDT = this.objFeatureCategoryMasterBll.GetDataByFeatureCategoryName(this.txtFeatureCategoryName.Text);
        if (this.objFeatureCategoryMasterDT.Rows.Count > 0)
        {
          this.DisplayAlert("Feature Category Already Exist..");
          FeatureCategoryMaster.checkInDB = true;
        }
        else
          FeatureCategoryMaster.checkInDB = false;
        if (!FeatureCategoryMaster.checkInDB)
        {
          int num = this.objFeatureCategoryMasterBll.AddFeatureCategory(this.txtFeatureCategoryName.Text.Trim(), this.txtDesc.Text.Trim(), this.chkHome.Checked, this.chkStatus.Checked);
          if (num != 0)
          {
            this.DisplayAlert("Details Added Successfully.");
            this.Response.Redirect("~/Admin/FeatureCategoryMaster.aspx?cmd=view&ID=" + (object) num);
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
          if (this.txtFeatureCategoryName.Text.Trim().Length > 0)
          {
            if (this.objFeatureCategoryMasterBll.UpdateFeatureCategory(int.Parse(this.hfFeatureCategory.Value.Trim()), this.txtFeatureCategoryName.Text.Trim(), this.txtDesc.Text.Trim(), this.chkHome.Checked, this.chkStatus.Checked))
            {
              this.DisplayAlert("Update Successfully..");
              this.Response.Redirect("~/Admin/FeatureCategoryMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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
      this.Response.Redirect("~/Admin/FeatureCategoryMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfFeatureCategory.Value != null)
      {
        if (this.objFeatureCategoryMasterBll.DeleteFeatureCategory(int.Parse(this.hfFeatureCategory.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/Admin/FeatureCategoryMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/FeatureCategoryMaster.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/FeatureCategoryMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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

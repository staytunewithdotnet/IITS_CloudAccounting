// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.PackageFeatureMaster
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
  public class PackageFeatureMaster : Page
  {
    private static string AddStatus = string.Empty;
    private static string EditStatus = string.Empty;
    private static string ViewStatus = string.Empty;
    private static string DeleteStatus = string.Empty;
    private readonly PackageModuleMasterBLL objPackageModuleMasterBll = new PackageModuleMasterBLL();
    private CloudAccountDA.PackageModuleMasterDataTable objPackageModuleMasterDT = new CloudAccountDA.PackageModuleMasterDataTable();
    private readonly PackageFeatureMasterBLL objPackageFeatureMasterBll = new PackageFeatureMasterBLL();
    private CloudAccountDA.PackageFeatureMasterDataTable objPackageFeatureMasterDT = new CloudAccountDA.PackageFeatureMasterDataTable();
    private readonly MasterAdminRightsMasterBLL objMasterAdminRightsMasterBll = new MasterAdminRightsMasterBLL();
    private CloudAccountDA.MasterAdminRightsMasterDataTable objMasterAdminRightsMasterDT = new CloudAccountDA.MasterAdminRightsMasterDataTable();
    private readonly MasterAdminLoginMasterBLL objMasterAdminLoginMasterBll = new MasterAdminLoginMasterBLL();
    private CloudAccountDA.MasterAdminLoginMasterDataTable objMasterAdminLoginMasterDT = new CloudAccountDA.MasterAdminLoginMasterDataTable();
    private bool checkInDB;
    protected Panel pnlAdd;
    protected DropDownList ddlPackageModule;
    protected SqlDataSource sqldsPackageModule;
    protected RequiredFieldValidator rfvPackageModuleName;
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
    protected Label lblPackageModule;
    protected Label lblName;
    protected Label lblDesc;
    protected Label lblStatus;
    protected Button btnEdit;
    protected Button btnDelete;
    protected Button btnList;
    protected Button btnAdd;
    protected Panel pnlViewAll;
    protected GridView gvPackageFeature;
    protected Button btnAddPackageFeature;
    protected HiddenField hfPackageFeature;
    protected HiddenField hfMasterAdminID;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyLoginID;
    protected ObjectDataSource objdsPackageFeature;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("packageManagement")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("PackageFeature")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          PackageFeatureMaster.AddStatus = "True";
          PackageFeatureMaster.EditStatus = "True";
          PackageFeatureMaster.ViewStatus = "True";
          PackageFeatureMaster.DeleteStatus = "True";
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
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "PackageFeatureMaster");
          if (this.objMasterAdminRightsMasterDT.Rows.Count > 0)
          {
            PackageFeatureMaster.AddStatus = this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            PackageFeatureMaster.EditStatus = this.objMasterAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            PackageFeatureMaster.ViewStatus = this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            PackageFeatureMaster.DeleteStatus = this.objMasterAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            PackageFeatureMaster.AddStatus = "";
            PackageFeatureMaster.EditStatus = "";
            PackageFeatureMaster.ViewStatus = "";
            PackageFeatureMaster.DeleteStatus = "";
          }
        }
        else
        {
          PackageFeatureMaster.AddStatus = "";
          PackageFeatureMaster.EditStatus = "";
          PackageFeatureMaster.ViewStatus = "";
          PackageFeatureMaster.DeleteStatus = "";
        }
      }
      if (PackageFeatureMaster.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] == null || !(PackageFeatureMaster.ViewStatus == "True"))
                break;
              string i = this.Request.QueryString["ID"];
              this.pnlViewAll.Visible = false;
              this.pnlAdd.Visible = false;
              this.pnlView.Visible = true;
              this.ViewRecord(i);
              this.btnEdit.Visible = PackageFeatureMaster.EditStatus == "True";
              this.btnAddPackageFeature.Visible = this.btnAdd.Visible = PackageFeatureMaster.AddStatus == "True";
              this.btnDelete.Visible = PackageFeatureMaster.DeleteStatus == "True";
              this.btnListAll.Visible = true;
              this.btnUpdate.Visible = false;
              this.btnCancel.Visible = false;
              break;
            case "add":
              if (this.Request.QueryString["ID"] != null)
              {
                if (!(PackageFeatureMaster.EditStatus == "True"))
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
              if (!(PackageFeatureMaster.AddStatus == "True"))
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
          if (PackageFeatureMaster.AddStatus == "False")
            this.btnAddPackageFeature.Visible = this.btnAdd.Visible = false;
          else
            this.btnAddPackageFeature.Visible = this.btnAdd.Visible = true;
        }
      }
      else if (PackageFeatureMaster.AddStatus == "True" && PackageFeatureMaster.EditStatus == "False" && (PackageFeatureMaster.ViewStatus == "False" && PackageFeatureMaster.DeleteStatus == "False"))
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

    protected void gvPackageFeature_Sorting(object sender, GridViewSortEventArgs e)
    {
      this.BindGrid();
    }

    private void BindGrid()
    {
      this.gvPackageFeature.DataBind();
    }

    private void Clear()
    {
      this.txtName.Text = "";
      this.chkStatus.Checked = false;
      this.txtDesc.Text = "";
      this.ddlPackageModule.SelectedIndex = 0;
      this.ddlPackageModule.Focus();
    }

    private void ViewRecord(string i)
    {
      this.objPackageFeatureMasterDT = this.objPackageFeatureMasterBll.GetDataByPackageFeatureID(int.Parse(i));
      if (this.objPackageFeatureMasterDT.Rows.Count <= 0)
        return;
      this.hfPackageFeature.Value = this.objPackageFeatureMasterDT.Rows[0]["PackageFeatureID"].ToString();
      this.lblName.Text = this.objPackageFeatureMasterDT.Rows[0]["PackageFeatureName"].ToString();
      this.lblDesc.Text = this.objPackageFeatureMasterDT.Rows[0]["PackageFeatureDesc"].ToString();
      this.lblStatus.Text = this.objPackageFeatureMasterDT.Rows[0]["PackageFeatureStatus"].ToString() == "True" ? "True" : "False";
      this.objPackageModuleMasterDT = this.objPackageModuleMasterBll.GetDataByPackageModuleID(int.Parse(this.objPackageFeatureMasterDT.Rows[0]["PackageModuleID"].ToString()));
      this.lblPackageModule.Text = this.objPackageModuleMasterDT.Rows[0]["PackageModuleName"].ToString();
    }

    private void SetRecord(string iD)
    {
      this.objPackageFeatureMasterDT = this.objPackageFeatureMasterBll.GetDataByPackageFeatureID(int.Parse(iD));
      if (this.objPackageFeatureMasterDT.Rows.Count <= 0)
        return;
      this.hfPackageFeature.Value = this.objPackageFeatureMasterDT.Rows[0]["PackageFeatureID"].ToString();
      this.ddlPackageModule.SelectedValue = this.objPackageFeatureMasterDT.Rows[0]["PackageModuleID"].ToString();
      this.txtName.Text = this.objPackageFeatureMasterDT.Rows[0]["PackageFeatureName"].ToString();
      this.txtDesc.Text = this.objPackageFeatureMasterDT.Rows[0]["PackageFeatureDesc"].ToString();
      this.chkStatus.Checked = this.objPackageFeatureMasterDT.Rows[0]["PackageFeatureStatus"].ToString() == "True";
    }

    protected void gvPackageFeature_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/PackageFeatureMaster.aspx?cmd=view&ID=" + this.gvPackageFeature.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvPackageFeature_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvPackageFeature.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void gvPackageFeature_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType != DataControlRowType.DataRow)
        return;
      this.objPackageModuleMasterDT = this.objPackageModuleMasterBll.GetDataByPackageModuleID(int.Parse(e.Row.Cells[1].Text));
      if (this.objPackageModuleMasterDT.Rows.Count == 0)
        return;
      e.Row.Cells[1].Text = this.objPackageModuleMasterDT.Rows[0]["PackageModuleName"].ToString();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvPackageFeature.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvPackageFeature, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void btnAddPackageFeature_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/PackageFeatureMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      try
      {
        if (!this.Page.IsValid)
          return;
        if (this.ddlPackageModule.SelectedIndex > 0 && this.txtName.Text.Trim().Length > 0)
        {
          this.objPackageFeatureMasterDT = this.objPackageFeatureMasterBll.GetDataByPackageFeatureName(int.Parse(this.ddlPackageModule.SelectedItem.Value), this.txtName.Text.Trim());
          if (this.objPackageFeatureMasterDT.Rows.Count > 0)
          {
            this.DisplayAlert("Package Feature Already Exist..");
            this.checkInDB = true;
          }
          if (!this.checkInDB)
          {
            int num = this.objPackageFeatureMasterBll.AddPackageFeature(int.Parse(this.ddlPackageModule.SelectedItem.Value), this.txtName.Text.Trim(), this.txtDesc.Text.Trim(), this.chkStatus.Checked);
            if (num != 0)
            {
              this.DisplayAlert("Details Added Successfully.");
              this.Response.Redirect("~/BillTransact/PackageFeatureMaster.aspx?cmd=view&ID=" + (object) num);
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
          this.DisplayAlert("Please Fill All Data...!");
      }
      catch (Exception ex)
      {
        this.DisplayAlert(ex.Message);
        throw;
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
          if (this.ddlPackageModule.SelectedIndex > 0 && this.txtName.Text.Trim().Length > 0)
          {
            if (this.objPackageFeatureMasterBll.UpdatePackageFeature(int.Parse(this.hfPackageFeature.Value.Trim()), int.Parse(this.ddlPackageModule.SelectedItem.Value), this.txtName.Text.Trim(), this.txtDesc.Text.Trim(), this.chkStatus.Checked))
            {
              this.DisplayAlert("Update Successfully..");
              this.Response.Redirect("~/BillTransact/PackageFeatureMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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
      this.Response.Redirect("~/BillTransact/PackageFeatureMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfPackageFeature.Value != null)
      {
        if (this.objPackageFeatureMasterBll.DeletePackageFeature(int.Parse(this.hfPackageFeature.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/BillTransact/PackageFeatureMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/PackageFeatureMaster.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/PackageFeatureMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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

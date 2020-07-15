// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.ModuleMaster
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
  public class ModuleMaster : Page
  {
    private static string AddStatus = string.Empty;
    private static string EditStatus = string.Empty;
    private static string ViewStatus = string.Empty;
    private static string DeleteStatus = string.Empty;
    private readonly ModuleMasterBLL objModuleMasterBll = new ModuleMasterBLL();
    private CloudAccountDA.ModuleMasterDataTable objModuleMasterDT = new CloudAccountDA.ModuleMasterDataTable();
    private readonly PackageDetailsBLL objPackageDetailsBll = new PackageDetailsBLL();
    private readonly PackageMasterBLL objPackageMasterBll = new PackageMasterBLL();
    private CloudAccountDA.PackageMasterDataTable objPackageMasterDT = new CloudAccountDA.PackageMasterDataTable();
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
    protected Label lblName;
    protected Label lblDesc;
    protected Label lblStatus;
    protected Button btnEdit;
    protected Button btnDelete;
    protected Button btnList;
    protected Button btnAdd;
    protected Panel pnlViewAll;
    protected GridView gvModule;
    protected Button btnAddModule;
    protected HiddenField hfModule;
    protected HiddenField hfMasterAdminID;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyLoginID;
    protected ObjectDataSource objdsModule;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("packageManagement")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("module")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          ModuleMaster.AddStatus = "True";
          ModuleMaster.EditStatus = "True";
          ModuleMaster.ViewStatus = "True";
          ModuleMaster.DeleteStatus = "True";
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
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "ModuleMaster");
          if (this.objMasterAdminRightsMasterDT.Rows.Count > 0)
          {
            ModuleMaster.AddStatus = this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            ModuleMaster.EditStatus = this.objMasterAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            ModuleMaster.ViewStatus = this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            ModuleMaster.DeleteStatus = this.objMasterAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            ModuleMaster.AddStatus = "";
            ModuleMaster.EditStatus = "";
            ModuleMaster.ViewStatus = "";
            ModuleMaster.DeleteStatus = "";
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
          this.objCompanyAdminRightsMasterDT = this.objCompanyAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfCompanyID.Value.Trim()), int.Parse(this.hfCompanyLoginID.Value.Trim()), "ModuleMaster");
          if (this.objCompanyAdminRightsMasterDT.Rows.Count > 0)
          {
            ModuleMaster.AddStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            ModuleMaster.EditStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            ModuleMaster.ViewStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            ModuleMaster.DeleteStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            ModuleMaster.AddStatus = "";
            ModuleMaster.EditStatus = "";
            ModuleMaster.ViewStatus = "";
            ModuleMaster.DeleteStatus = "";
          }
        }
        else
        {
          ModuleMaster.AddStatus = "";
          ModuleMaster.EditStatus = "";
          ModuleMaster.ViewStatus = "";
          ModuleMaster.DeleteStatus = "";
        }
      }
      if (ModuleMaster.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] == null || !(ModuleMaster.ViewStatus == "True"))
                break;
              string i = this.Request.QueryString["ID"];
              this.pnlViewAll.Visible = false;
              this.pnlAdd.Visible = false;
              this.pnlView.Visible = true;
              this.ViewRecord(i);
              this.btnEdit.Visible = ModuleMaster.EditStatus == "True";
              this.btnAddModule.Visible = this.btnAdd.Visible = ModuleMaster.AddStatus == "True";
              this.btnDelete.Visible = ModuleMaster.DeleteStatus == "True";
              this.btnListAll.Visible = true;
              this.btnUpdate.Visible = false;
              this.btnCancel.Visible = false;
              break;
            case "add":
              if (this.Request.QueryString["ID"] != null)
              {
                if (!(ModuleMaster.EditStatus == "True"))
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
              if (!(ModuleMaster.AddStatus == "True"))
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
          if (ModuleMaster.AddStatus == "False")
            this.btnAddModule.Visible = this.btnAdd.Visible = false;
          else
            this.btnAddModule.Visible = this.btnAdd.Visible = true;
        }
      }
      else if (ModuleMaster.AddStatus == "True" && ModuleMaster.EditStatus == "False" && (ModuleMaster.ViewStatus == "False" && ModuleMaster.DeleteStatus == "False"))
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
      this.objModuleMasterDT = this.objModuleMasterBll.GetDataByModuleID(int.Parse(i));
      if (this.objModuleMasterDT.Rows.Count <= 0)
        return;
      this.hfModule.Value = this.objModuleMasterDT.Rows[0]["ModuleID"].ToString();
      this.lblName.Text = this.objModuleMasterDT.Rows[0]["ModuleName"].ToString();
      this.lblDesc.Text = this.objModuleMasterDT.Rows[0]["ModuleDesc"].ToString();
      this.lblStatus.Text = this.objModuleMasterDT.Rows[0]["ModuleStatus"].ToString() == "True" ? "True" : "False";
    }

    private void SetRecord(string iD)
    {
      this.objModuleMasterDT = this.objModuleMasterBll.GetDataByModuleID(int.Parse(iD));
      if (this.objModuleMasterDT.Rows.Count <= 0)
        return;
      this.hfModule.Value = this.objModuleMasterDT.Rows[0]["ModuleID"].ToString();
      this.txtName.Text = this.objModuleMasterDT.Rows[0]["ModuleName"].ToString();
      this.txtDesc.Text = this.objModuleMasterDT.Rows[0]["ModuleDesc"].ToString();
      this.chkStatus.Checked = this.objModuleMasterDT.Rows[0]["ModuleStatus"].ToString() == "True";
    }

    private void Clear()
    {
      this.txtDesc.Text = this.txtName.Text = (string) null;
      this.chkStatus.Checked = false;
      this.txtName.Focus();
    }

    private void BindGrid()
    {
      this.gvModule.DataBind();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvModule.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvModule, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void gvModule_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/ModuleMaster.aspx?cmd=view&ID=" + this.gvModule.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvModule_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvModule.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void btnAddModule_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/ModuleMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.txtName.Text.Trim().Length > 0)
      {
        this.objModuleMasterDT = this.objModuleMasterBll.GetDataByModuleName(this.txtName.Text);
        if (this.objModuleMasterDT.Rows.Count > 0)
        {
          this.DisplayAlert("Module Already Exist..");
          this.checkInDB = true;
        }
        else
          this.checkInDB = false;
        if (!this.checkInDB)
        {
          int iModuleID = this.objModuleMasterBll.AddModule(this.txtName.Text.Trim(), this.txtDesc.Text.Trim(), this.chkStatus.Checked);
          if (iModuleID != 0)
          {
            this.objPackageMasterDT = this.objPackageMasterBll.GetAllDetail();
            if (this.objPackageMasterDT.Rows.Count > 0)
            {
              for (int index = 0; index < this.objPackageMasterDT.Rows.Count; ++index)
                this.objPackageDetailsBll.AddPackageDetails(int.Parse(this.objPackageMasterDT.Rows[index]["PackageID"].ToString()), iModuleID, false);
            }
            this.DisplayAlert("Details Added Successfully.");
            this.Response.Redirect("~/Admin/ModuleMaster.aspx?cmd=view&ID=" + (object) iModuleID);
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
          if (this.txtName.Text.Trim().Length > 0)
          {
            if (this.objModuleMasterBll.UpdateModule(int.Parse(this.hfModule.Value.Trim()), this.txtName.Text.Trim(), this.txtDesc.Text.Trim(), this.chkStatus.Checked))
            {
              this.DisplayAlert("Update Successfully..");
              this.Response.Redirect("~/Admin/ModuleMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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
      this.Response.Redirect("~/Admin/ModuleMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfModule.Value != null)
      {
        if (this.objModuleMasterBll.DeleteModule(int.Parse(this.hfModule.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/Admin/ModuleMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/ModuleMaster.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/ModuleMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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

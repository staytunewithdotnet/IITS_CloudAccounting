// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.PackageModuleMaster
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
  public class PackageModuleMaster : Page
  {
    private static string AddStatus = string.Empty;
    private static string EditStatus = string.Empty;
    private static string ViewStatus = string.Empty;
    private static string DeleteStatus = string.Empty;
    private readonly PackageModuleMasterBLL objPackageModuleMasterBll = new PackageModuleMasterBLL();
    private CloudAccountDA.PackageModuleMasterDataTable objPackageModuleMasterDT = new CloudAccountDA.PackageModuleMasterDataTable();
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
    protected GridView gvPackageModule;
    protected Button btnAddPackageModule;
    protected HiddenField hfPackageModule;
    protected HiddenField hfMasterAdminID;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyLoginID;
    protected ObjectDataSource objdsPackageModule;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("packageManagement")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("PackageModule")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          PackageModuleMaster.AddStatus = "True";
          PackageModuleMaster.EditStatus = "True";
          PackageModuleMaster.ViewStatus = "True";
          PackageModuleMaster.DeleteStatus = "True";
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
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "PackageModuleMaster");
          if (this.objMasterAdminRightsMasterDT.Rows.Count > 0)
          {
            PackageModuleMaster.AddStatus = this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            PackageModuleMaster.EditStatus = this.objMasterAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            PackageModuleMaster.ViewStatus = this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            PackageModuleMaster.DeleteStatus = this.objMasterAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            PackageModuleMaster.AddStatus = "";
            PackageModuleMaster.EditStatus = "";
            PackageModuleMaster.ViewStatus = "";
            PackageModuleMaster.DeleteStatus = "";
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
          this.objCompanyAdminRightsMasterDT = this.objCompanyAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfCompanyID.Value.Trim()), int.Parse(this.hfCompanyLoginID.Value.Trim()), "PackageModuleMaster");
          if (this.objCompanyAdminRightsMasterDT.Rows.Count > 0)
          {
            PackageModuleMaster.AddStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            PackageModuleMaster.EditStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            PackageModuleMaster.ViewStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            PackageModuleMaster.DeleteStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            PackageModuleMaster.AddStatus = "";
            PackageModuleMaster.EditStatus = "";
            PackageModuleMaster.ViewStatus = "";
            PackageModuleMaster.DeleteStatus = "";
          }
        }
        else
        {
          PackageModuleMaster.AddStatus = "";
          PackageModuleMaster.EditStatus = "";
          PackageModuleMaster.ViewStatus = "";
          PackageModuleMaster.DeleteStatus = "";
        }
      }
      if (PackageModuleMaster.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] == null || !(PackageModuleMaster.ViewStatus == "True"))
                break;
              string i = this.Request.QueryString["ID"];
              this.pnlViewAll.Visible = false;
              this.pnlAdd.Visible = false;
              this.pnlView.Visible = true;
              this.ViewRecord(i);
              this.btnEdit.Visible = PackageModuleMaster.EditStatus == "True";
              this.btnAddPackageModule.Visible = this.btnAdd.Visible = PackageModuleMaster.AddStatus == "True";
              this.btnDelete.Visible = PackageModuleMaster.DeleteStatus == "True";
              this.btnListAll.Visible = true;
              this.btnUpdate.Visible = false;
              this.btnCancel.Visible = false;
              break;
            case "add":
              if (this.Request.QueryString["ID"] != null)
              {
                if (!(PackageModuleMaster.EditStatus == "True"))
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
              if (!(PackageModuleMaster.AddStatus == "True"))
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
          if (PackageModuleMaster.AddStatus == "False")
            this.btnAddPackageModule.Visible = this.btnAdd.Visible = false;
          else
            this.btnAddPackageModule.Visible = this.btnAdd.Visible = true;
        }
      }
      else if (PackageModuleMaster.AddStatus == "True" && PackageModuleMaster.EditStatus == "False" && (PackageModuleMaster.ViewStatus == "False" && PackageModuleMaster.DeleteStatus == "False"))
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
      this.objPackageModuleMasterDT = this.objPackageModuleMasterBll.GetDataByPackageModuleID(int.Parse(i));
      if (this.objPackageModuleMasterDT.Rows.Count <= 0)
        return;
      this.hfPackageModule.Value = this.objPackageModuleMasterDT.Rows[0]["PackageModuleID"].ToString();
      this.lblName.Text = this.objPackageModuleMasterDT.Rows[0]["PackageModuleName"].ToString();
      this.lblDesc.Text = this.objPackageModuleMasterDT.Rows[0]["PackageModuleDesc"].ToString();
      this.lblStatus.Text = this.objPackageModuleMasterDT.Rows[0]["PackageModuleStatus"].ToString() == "True" ? "True" : "False";
    }

    private void SetRecord(string iD)
    {
      this.objPackageModuleMasterDT = this.objPackageModuleMasterBll.GetDataByPackageModuleID(int.Parse(iD));
      if (this.objPackageModuleMasterDT.Rows.Count <= 0)
        return;
      this.hfPackageModule.Value = this.objPackageModuleMasterDT.Rows[0]["PackageModuleID"].ToString();
      this.txtName.Text = this.objPackageModuleMasterDT.Rows[0]["PackageModuleName"].ToString();
      this.txtDesc.Text = this.objPackageModuleMasterDT.Rows[0]["PackageModuleDesc"].ToString();
      this.chkStatus.Checked = this.objPackageModuleMasterDT.Rows[0]["PackageModuleStatus"].ToString() == "True";
    }

    private void Clear()
    {
      this.txtDesc.Text = this.txtName.Text = (string) null;
      this.chkStatus.Checked = false;
      this.txtName.Focus();
    }

    private void BindGrid()
    {
      this.gvPackageModule.DataBind();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvPackageModule.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvPackageModule, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void gvPackageModule_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/PackageModuleMaster.aspx?cmd=view&ID=" + this.gvPackageModule.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvPackageModule_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvPackageModule.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void btnAddPackageModule_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/PackageModuleMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.txtName.Text.Trim().Length > 0)
      {
        this.objPackageModuleMasterDT = this.objPackageModuleMasterBll.GetDataByPackageModuleName(this.txtName.Text);
        if (this.objPackageModuleMasterDT.Rows.Count > 0)
        {
          this.DisplayAlert("PackageModule Already Exist..");
          this.checkInDB = true;
        }
        else
          this.checkInDB = false;
        if (!this.checkInDB)
        {
          int num = this.objPackageModuleMasterBll.AddPackageModule(this.txtName.Text.Trim(), this.txtDesc.Text.Trim(), this.chkStatus.Checked);
          if (num != 0)
          {
            this.DisplayAlert("Details Added Successfully.");
            this.Response.Redirect("~/Admin/PackageModuleMaster.aspx?cmd=view&ID=" + (object) num);
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
            if (this.objPackageModuleMasterBll.UpdatePackageModule(int.Parse(this.hfPackageModule.Value.Trim()), this.txtName.Text.Trim(), this.txtDesc.Text.Trim(), this.chkStatus.Checked))
            {
              this.DisplayAlert("Update Successfully..");
              this.Response.Redirect("~/Admin/PackageModuleMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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
      this.Response.Redirect("~/Admin/PackageModuleMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfPackageModule.Value != null)
      {
        if (this.objPackageModuleMasterBll.DeletePackageModule(int.Parse(this.hfPackageModule.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/Admin/PackageModuleMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/PackageModuleMaster.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/PackageModuleMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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

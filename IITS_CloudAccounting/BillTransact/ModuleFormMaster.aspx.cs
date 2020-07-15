// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.ModuleFormMaster
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
  public class ModuleFormMaster : Page
  {
    private static string AddStatus = string.Empty;
    private static string EditStatus = string.Empty;
    private static string ViewStatus = string.Empty;
    private static string DeleteStatus = string.Empty;
    private readonly ModuleFormMasterBLL objModuleFormMasterBll = new ModuleFormMasterBLL();
    private CloudAccountDA.ModuleFormMasterDataTable objModuleFormMasterDT = new CloudAccountDA.ModuleFormMasterDataTable();
    private readonly ModuleMasterBLL objModuleMasterBll = new ModuleMasterBLL();
    private CloudAccountDA.ModuleMasterDataTable objModuleMasterDT = new CloudAccountDA.ModuleMasterDataTable();
    private readonly MasterAdminRightsMasterBLL objMasterAdminRightsMasterBll = new MasterAdminRightsMasterBLL();
    private CloudAccountDA.MasterAdminRightsMasterDataTable objMasterAdminRightsMasterDT = new CloudAccountDA.MasterAdminRightsMasterDataTable();
    private readonly MasterAdminLoginMasterBLL objMasterAdminLoginMasterBll = new MasterAdminLoginMasterBLL();
    private CloudAccountDA.MasterAdminLoginMasterDataTable objMasterAdminLoginMasterDT = new CloudAccountDA.MasterAdminLoginMasterDataTable();
    private bool checkInDB;
    protected Panel pnlAdd;
    protected DropDownList ddlModule;
    protected SqlDataSource sqldsModule;
    protected RequiredFieldValidator rfvModule;
    protected GridView gvFormAdd;
    protected ObjectDataSource objdsForm;
    protected Button btnSubmit;
    protected Button btnReset;
    protected Button btnUpdate;
    protected Button btnCancel;
    protected Button btnListAll;
    protected Panel pnlView;
    protected Label lblModule;
    protected GridView gvFormView;
    protected ObjectDataSource objdsFormView;
    protected Button btnEdit;
    protected Button btnDelete;
    protected Button btnList;
    protected Button btnAdd;
    protected Panel pnlViewAll;
    protected GridView gvModuleForm;
    protected SqlDataSource sqldsModuleForm;
    protected Button btnAddModuleForm;
    protected HiddenField hfModuleFormID;
    protected HiddenField hfFormID;
    protected HiddenField hfModuleID;
    protected HiddenField hfMasterAdminID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("formManagement")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("moduleFormMaster")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          ModuleFormMaster.AddStatus = "True";
          ModuleFormMaster.EditStatus = "True";
          ModuleFormMaster.ViewStatus = "True";
          ModuleFormMaster.DeleteStatus = "True";
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
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "ModuleFormMaster");
          if (this.objMasterAdminRightsMasterDT.Rows.Count > 0)
          {
            ModuleFormMaster.AddStatus = this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            ModuleFormMaster.EditStatus = this.objMasterAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            ModuleFormMaster.ViewStatus = this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            ModuleFormMaster.DeleteStatus = this.objMasterAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            ModuleFormMaster.AddStatus = "";
            ModuleFormMaster.EditStatus = "";
            ModuleFormMaster.ViewStatus = "";
            ModuleFormMaster.DeleteStatus = "";
          }
        }
        else
        {
          ModuleFormMaster.AddStatus = "";
          ModuleFormMaster.EditStatus = "";
          ModuleFormMaster.ViewStatus = "";
          ModuleFormMaster.DeleteStatus = "";
        }
      }
      if (ModuleFormMaster.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] == null || !(ModuleFormMaster.ViewStatus == "True"))
                break;
              string i = this.Request.QueryString["ID"];
              this.pnlViewAll.Visible = false;
              this.pnlAdd.Visible = false;
              this.pnlView.Visible = true;
              this.ViewRecord(i);
              this.btnEdit.Visible = ModuleFormMaster.EditStatus == "True";
              this.btnAddModuleForm.Visible = this.btnAdd.Visible = ModuleFormMaster.AddStatus == "True";
              this.btnDelete.Visible = ModuleFormMaster.DeleteStatus == "True";
              this.btnListAll.Visible = true;
              this.btnUpdate.Visible = false;
              this.btnCancel.Visible = false;
              break;
            case "add":
              if (this.Request.QueryString["ID"] != null)
              {
                if (!(ModuleFormMaster.EditStatus == "True"))
                  break;
                this.SetRecord(this.Request.QueryString["ID"]);
                this.pnlAdd.Visible = true;
                this.pnlView.Visible = false;
                this.pnlViewAll.Visible = false;
                this.btnSubmit.Visible = false;
                this.btnUpdate.Visible = true;
                this.btnReset.Visible = false;
                this.btnListAll.Visible = false;
                this.ddlModule.Focus();
                break;
              }
              if (!(ModuleFormMaster.AddStatus == "True"))
                break;
              this.Clear();
              this.ddlModule.Focus();
              this.pnlViewAll.Visible = false;
              this.pnlAdd.Visible = true;
              this.pnlView.Visible = false;
              this.btnListAll.Visible = true;
              this.btnUpdate.Visible = false;
              this.btnSubmit.Visible = true;
              this.btnReset.Visible = true;
              this.btnCancel.Visible = false;
              this.SetGridForNewRecord();
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
          if (ModuleFormMaster.AddStatus == "False")
            this.btnAddModuleForm.Visible = this.btnAdd.Visible = false;
          else
            this.btnAddModuleForm.Visible = this.btnAdd.Visible = true;
        }
      }
      else if (ModuleFormMaster.AddStatus == "True" && ModuleFormMaster.EditStatus == "False" && (ModuleFormMaster.ViewStatus == "False" && ModuleFormMaster.DeleteStatus == "False"))
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

    private void SetGridForNewRecord()
    {
      this.objModuleFormMasterDT = this.objModuleFormMasterBll.GetAllDetail();
      for (int index1 = 0; index1 < this.objModuleFormMasterDT.Rows.Count; ++index1)
      {
        string str = this.objModuleFormMasterDT.Rows[index1]["ModuleFormName"].ToString();
        for (int index2 = 0; index2 < this.gvFormAdd.Rows.Count; ++index2)
        {
          string text = this.gvFormAdd.Rows[index2].Cells[1].Text;
          CheckBox checkBox = (CheckBox) this.gvFormAdd.Rows[index2].FindControl("chkModuleForm");
          if (text == str)
          {
            checkBox.Enabled = false;
            break;
          }
        }
      }
    }

    private void Clear()
    {
      this.ddlModule.SelectedIndex = 0;
      this.ddlModule.Focus();
    }

    private void BindGrid()
    {
      this.gvModuleForm.DataBind();
    }

    private void ViewRecord(string i)
    {
      this.objModuleFormMasterDT = this.objModuleFormMasterBll.GetDataByModuleFormID(int.Parse(i));
      if (this.objModuleFormMasterDT.Rows.Count <= 0)
        return;
      this.hfModuleFormID.Value = this.objModuleFormMasterDT.Rows[0]["ModuleFormID"].ToString();
      this.hfFormID.Value = this.objModuleFormMasterDT.Rows[0]["FormID"].ToString();
      this.hfModuleID.Value = this.objModuleFormMasterDT.Rows[0]["ModuleID"].ToString();
      this.objModuleMasterDT = this.objModuleMasterBll.GetDataByModuleID(int.Parse(this.hfModuleID.Value));
      this.lblModule.Text = this.objModuleMasterDT.Rows[0]["ModuleName"].ToString();
    }

    private void SetRecord(string iD)
    {
      this.objModuleFormMasterDT = this.objModuleFormMasterBll.GetDataByModuleFormID(int.Parse(iD));
      if (this.objModuleFormMasterDT.Rows.Count <= 0)
        return;
      this.hfModuleFormID.Value = this.objModuleFormMasterDT.Rows[0]["ModuleFormID"].ToString();
      this.hfFormID.Value = this.objModuleFormMasterDT.Rows[0]["FormID"].ToString();
      this.hfModuleID.Value = this.objModuleFormMasterDT.Rows[0]["ModuleID"].ToString();
      this.objModuleMasterDT = this.objModuleMasterBll.GetDataByModuleID(int.Parse(this.hfModuleID.Value));
      if (this.objModuleMasterDT.Rows.Count > 0)
      {
        this.ddlModule.Items.Add(this.objModuleMasterDT.Rows[0]["ModuleID"].ToString());
        this.ddlModule.SelectedValue = this.objModuleMasterDT.Rows[0]["ModuleID"].ToString();
      }
      this.ddlModule.Enabled = false;
      this.SetGridForNewRecord();
      this.objModuleFormMasterDT = this.objModuleFormMasterBll.GetDataByModuleID(int.Parse(this.hfModuleID.Value));
      for (int index1 = 0; index1 < this.objModuleFormMasterDT.Rows.Count; ++index1)
      {
        string str = this.objModuleFormMasterDT.Rows[index1]["ModuleFormName"].ToString();
        for (int index2 = 0; index2 < this.gvFormAdd.Rows.Count; ++index2)
        {
          string text = this.gvFormAdd.Rows[index2].Cells[1].Text;
          CheckBox checkBox = (CheckBox) this.gvFormAdd.Rows[index2].FindControl("chkModuleForm");
          if (text == str)
          {
            checkBox.Checked = true;
            checkBox.Enabled = true;
            break;
          }
        }
      }
    }

    protected void gvModuleForm_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/ModuleFormMaster.aspx?cmd=view&ID=" + this.gvModuleForm.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvModuleForm_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvModuleForm.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvModuleForm.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvModuleForm, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/ModuleFormMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      int num = 0;
      if (this.ddlModule.Text.Trim().Length > 0)
      {
        this.objModuleFormMasterDT = this.objModuleFormMasterBll.GetDataByModuleID(int.Parse(this.ddlModule.SelectedItem.Value));
        if (this.objModuleFormMasterDT.Rows.Count > 0)
        {
          this.DisplayAlert("Module Entry Already Exists..!");
          this.checkInDB = true;
        }
        if (this.checkInDB)
          return;
        if (this.gvFormAdd.Rows.Count > 0)
        {
          for (int index = 0; index < this.gvFormAdd.Rows.Count; ++index)
          {
            string text1 = this.gvFormAdd.Rows[index].Cells[0].Text;
            string text2 = this.gvFormAdd.Rows[index].Cells[1].Text;
            CheckBox checkBox = (CheckBox) this.gvFormAdd.Rows[index].Cells[2].FindControl("chkModuleForm");
            if (checkBox.Checked)
              num = this.objModuleFormMasterBll.AddModuleForm(int.Parse(this.ddlModule.SelectedItem.Value), int.Parse(text1), text2, checkBox.Checked);
          }
        }
        if (num != 0)
        {
          this.DisplayAlert("Details Added Successfully.");
          this.Response.Redirect("~/Admin/ModuleFormMaster.aspx?cmd=view&ID=" + (object) num);
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

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
      try
      {
        if (!this.Page.IsValid)
          return;
        if (this.ddlModule.SelectedIndex > 0)
        {
          int num = 0;
          if (this.gvFormAdd.Rows.Count > 0)
          {
            this.objModuleFormMasterBll.DeleteByModuleID(int.Parse(this.hfModuleID.Value));
            for (int index = 0; index < this.gvFormAdd.Rows.Count; ++index)
            {
              string text1 = this.gvFormAdd.Rows[index].Cells[0].Text;
              string text2 = this.gvFormAdd.Rows[index].Cells[1].Text;
              CheckBox checkBox = (CheckBox) this.gvFormAdd.Rows[index].Cells[2].FindControl("chkModuleForm");
              if (checkBox.Checked)
                num = this.objModuleFormMasterBll.AddModuleForm(int.Parse(this.ddlModule.SelectedItem.Value), int.Parse(text1), text2, checkBox.Checked);
            }
          }
          if (num != 0)
          {
            this.DisplayAlert("Update Successfully..");
            this.Response.Redirect("~/Admin/ModuleFormMaster.aspx?cmd=view&ID=" + (object) num);
          }
          else
            this.DisplayAlert("Fail to Update Details.");
        }
        else
          this.DisplayAlert("Please Fill All Details.");
      }
      catch (Exception ex)
      {
        this.DisplayAlert(ex.Message);
      }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/ModuleFormMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfModuleFormID.Value != null)
      {
        if (this.objModuleFormMasterBll.DeleteModuleForm(int.Parse(this.hfModuleFormID.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/Admin/ModuleFormMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/ModuleFormMaster.aspx");
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
      this.Clear();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/ModuleFormMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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

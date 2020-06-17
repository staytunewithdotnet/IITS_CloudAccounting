// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.CompanyAdminRightsMaster
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
  public class CompanyAdminRightsMaster : Page
  {
    private static string CompanyID = string.Empty;
    private static string CompanyAdminID = string.Empty;
    private static string ModuleID = string.Empty;
    private static string AddMode = string.Empty;
    private readonly FormGridCompanyAdminMasterBLL objFormGridMasterBll = new FormGridCompanyAdminMasterBLL();
    private CloudAccountDA.FormGridCompanyAdminMasterDataTable objFormGridMasterDT = new CloudAccountDA.FormGridCompanyAdminMasterDataTable();
    private readonly CompanyPackageDetailsBLL objCompanyPackageDetailsBll = new CompanyPackageDetailsBLL();
    private CloudAccountDA.CompanyPackageDetailsDataTable objCompanyPackageDetailsDT = new CloudAccountDA.CompanyPackageDetailsDataTable();
    private readonly CompanyAdminRightsMasterBLL objCompanyAdminUserRightsMasterBll = new CompanyAdminRightsMasterBLL();
    private CloudAccountDA.CompanyAdminRightsMasterDataTable objCompanyAdminUserRightsMasterDT = new CloudAccountDA.CompanyAdminRightsMasterDataTable();
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    protected ScriptManager ScriptManager1;
    protected Panel gridPanel;
    protected GridView gvCompanyAdminUserRights;
    protected Button btnAdd;
    protected Panel addPanel;
    protected UpdatePanel upMainGrid;
    protected DropDownList ddlCompanyAdmin;
    protected DropDownList ddlCompanyLogin;
    protected DropDownList ddlModule;
    protected GridView gvForm;
    protected Button btnSubmit;
    protected HtmlInputButton btnReset;
    protected Button btnUpdate;
    protected Button btnEdit;
    protected Button btnListAll;
    protected Button btnCancel;
    protected HiddenField hfCompanyAdminRightsID;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyAdminID;
    protected HiddenField hfPackageID;
    protected SqlDataSource sqldscmpRights;
    protected SqlDataSource sqldsOnlyCompanyRights;
    protected SqlDataSource sqldsCompanyAdmin;
    protected SqlDataSource sqldsCompanyLogin;
    protected SqlDataSource sqldsModule;
    protected SqlDataSource sqldsForm;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("companyManagement")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("companyRightsMaster")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      MembershipUser user = Membership.GetUser();
      if (user != null)
      {
        string str = user.ToString();
        if (Roles.IsUserInRole(str, "Admin"))
        {
          this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(str);
          if (this.objCompanyLoginMasterDT.Rows.Count > 0)
            this.hfCompanyID.Value = this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString();
        }
      }
      if (this.Request.QueryString["cmd"] != null)
      {
        switch (this.Request.QueryString["cmd"])
        {
          case "view":
            if (this.Request.QueryString["ID"] == null || this.Request.QueryString["CompanyAdminID"] == null)
              break;
            CompanyAdminRightsMaster.CompanyID = this.Request.QueryString["ID"];
            CompanyAdminRightsMaster.CompanyAdminID = this.Request.QueryString["CompanyAdminID"];
            CompanyAdminRightsMaster.AddMode = "Edit";
            this.gridPanel.Visible = false;
            this.addPanel.Visible = true;
            if (this.Request.QueryString["ModuleID"] != null)
            {
              CompanyAdminRightsMaster.CompanyAdminID = this.Request.QueryString["CompanyAdminID"];
              CompanyAdminRightsMaster.ModuleID = this.Request.QueryString["ModuleID"];
              this.BindDropCompanyAdminGrid();
              this.SetRecord(CompanyAdminRightsMaster.CompanyID, CompanyAdminRightsMaster.CompanyAdminID, CompanyAdminRightsMaster.ModuleID);
            }
            else
            {
              this.BindDropCompanyAdminGrid();
              this.ViewRecord(CompanyAdminRightsMaster.CompanyID, CompanyAdminRightsMaster.CompanyAdminID);
            }
            this.ddlCompanyAdmin.Enabled = false;
            this.btnListAll.Visible = true;
            this.btnSubmit.Visible = false;
            this.btnReset.Visible = false;
            this.btnUpdate.Visible = false;
            this.btnCancel.Visible = false;
            break;
          case "add":
            if (this.Request.QueryString["ID"] != null && this.Request.QueryString["CompanyAdminID"] != null && this.Request.QueryString["ModuleID"] != null)
            {
              CompanyAdminRightsMaster.CompanyID = this.Request.QueryString["ID"];
              CompanyAdminRightsMaster.CompanyAdminID = this.Request.QueryString["CompanyAdminID"];
              CompanyAdminRightsMaster.ModuleID = this.Request.QueryString["ModuleID"];
              this.BindDropCompanyAdminGrid();
              CompanyAdminRightsMaster.AddMode = "Add";
              this.SetRecord(CompanyAdminRightsMaster.CompanyID, CompanyAdminRightsMaster.CompanyAdminID, CompanyAdminRightsMaster.ModuleID);
              this.addPanel.Visible = true;
              this.gridPanel.Visible = false;
              this.ddlCompanyAdmin.Enabled = false;
              this.ddlModule.Enabled = false;
              this.btnUpdate.Visible = true;
              this.btnCancel.Visible = true;
              this.btnEdit.Visible = false;
              this.btnListAll.Visible = false;
              this.btnSubmit.Visible = false;
              this.btnReset.Visible = false;
              break;
            }
            this.SubBindGrid();
            this.BindDropCompanyAdminGrid();
            this.btnEdit.Visible = false;
            this.btnListAll.Visible = false;
            this.btnUpdate.Visible = false;
            this.btnCancel.Visible = false;
            this.addPanel.Visible = true;
            this.gridPanel.Visible = false;
            CompanyAdminRightsMaster.AddMode = "Add";
            if (user == null)
              break;
            string str1 = user.ToString();
            if (!Roles.IsUserInRole(str1, "Admin"))
              break;
            this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(str1);
            if (this.objCompanyLoginMasterDT.Rows.Count <= 0)
              break;
            this.hfCompanyID.Value = this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString();
            this.ddlCompanyAdmin.SelectedValue = this.hfCompanyID.Value;
            this.ddlCompanyAdmin_SelectedIndexChanged((object) null, (EventArgs) null);
            this.ddlCompanyAdmin.Enabled = false;
            break;
          default:
            this.BindGrid();
            this.gridPanel.Visible = true;
            this.addPanel.Visible = false;
            break;
        }
      }
      else
      {
        this.BindGrid();
        this.gridPanel.Visible = true;
        this.addPanel.Visible = false;
      }
    }

    private void BindGrid()
    {
      if (Admin.RoleName == "MasterAdmin")
        this.gvCompanyAdminUserRights.DataSource = (object) this.sqldscmpRights;
      else if (Admin.RoleName == "Admin")
        this.gvCompanyAdminUserRights.DataSource = (object) this.sqldsOnlyCompanyRights;
      this.gvCompanyAdminUserRights.DataBind();
    }

    private void ViewRecord(string cmpID, string cmpLoginID)
    {
      this.objCompanyAdminUserRightsMasterDT = this.objCompanyAdminUserRightsMasterBll.GetDataByViewRecords(int.Parse(cmpID), int.Parse(cmpLoginID));
      if (this.objCompanyAdminUserRightsMasterDT.Rows.Count <= 0)
        return;
      this.ddlCompanyAdmin.SelectedValue = this.objCompanyAdminUserRightsMasterDT.Rows[0]["CompanyID"].ToString();
      this.ddlCompanyAdmin.DataBind();
      this.ddlCompanyAdmin_SelectedIndexChanged((object) null, (EventArgs) null);
      this.ddlCompanyLogin.SelectedValue = this.objCompanyAdminUserRightsMasterDT.Rows[0]["CompanyAdminID"].ToString();
      this.ddlCompanyLogin.DataBind();
      this.objFormGridMasterDT = this.objFormGridMasterBll.GetAllData(new int?());
      if (this.objFormGridMasterDT.Rows.Count <= 0)
        return;
      this.gvForm.DataSource = (object) this.objFormGridMasterDT;
      this.gvForm.DataBind();
      this.gvForm.Enabled = false;
      this.btnEdit.Visible = false;
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvCompanyAdminUserRights.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvCompanyAdminUserRights, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    private void SetRecord(string cmpID, string cmpLoginID, string mID)
    {
      if (CompanyAdminRightsMaster.AddMode == "Edit")
      {
        this.objCompanyAdminUserRightsMasterDT = this.objCompanyAdminUserRightsMasterBll.GetDataBySelectRightsDetails(int.Parse(cmpID), int.Parse(cmpLoginID), int.Parse(mID));
        if (this.objCompanyAdminUserRightsMasterDT.Rows.Count <= 0)
          return;
        this.ddlCompanyAdmin.SelectedValue = this.objCompanyAdminUserRightsMasterDT.Rows[0]["CompanyID"].ToString();
        this.ddlCompanyAdmin.DataBind();
        this.ddlCompanyAdmin_SelectedIndexChanged((object) null, (EventArgs) null);
        this.ddlCompanyLogin.SelectedValue = this.objCompanyAdminUserRightsMasterDT.Rows[0]["CompanyAdminID"].ToString();
        this.ddlCompanyLogin.DataBind();
        this.ddlModule.SelectedValue = this.objCompanyAdminUserRightsMasterDT.Rows[0]["ModuleID"].ToString();
        this.ddlModule.DataBind();
        this.objFormGridMasterDT = this.objFormGridMasterBll.GetAllData(new int?());
        this.gvForm.DataSource = (object) this.objCompanyAdminUserRightsMasterDT;
        this.gvForm.DataBind();
        this.gvForm.Enabled = false;
        this.btnEdit.Visible = true;
      }
      else
      {
        this.objCompanyAdminUserRightsMasterDT = this.objCompanyAdminUserRightsMasterBll.GetDataBySelectRightsDetails(int.Parse(cmpID), int.Parse(cmpLoginID), int.Parse(mID));
        if (this.objCompanyAdminUserRightsMasterDT.Rows.Count <= 0)
          return;
        this.hfCompanyID.Value = this.ddlCompanyAdmin.SelectedValue = this.objCompanyAdminUserRightsMasterDT.Rows[0]["CompanyID"].ToString();
        this.ddlCompanyAdmin.DataBind();
        this.ddlCompanyAdmin_SelectedIndexChanged((object) null, (EventArgs) null);
        this.ddlCompanyLogin.SelectedValue = this.objCompanyAdminUserRightsMasterDT.Rows[0]["CompanyAdminID"].ToString();
        this.ddlCompanyLogin.DataBind();
        this.ddlModule.SelectedValue = this.objCompanyAdminUserRightsMasterDT.Rows[0]["ModuleID"].ToString();
        this.ddlModule.DataBind();
        this.objFormGridMasterDT = this.objFormGridMasterBll.GetAllData(new int?());
        this.gvForm.DataSource = (object) this.objCompanyAdminUserRightsMasterDT;
        this.gvForm.DataBind();
        this.gvForm.Enabled = true;
        this.btnEdit.Visible = true;
      }
    }

    private void BindDropCompanyAdminGrid()
    {
      this.ddlCompanyAdmin.DataBind();
      this.sqldsCompanyLogin.DataBind();
      this.ddlCompanyLogin.DataBind();
      this.sqldsModule.DataBind();
      this.ddlModule.DataBind();
    }

    private void SubBindGrid()
    {
      if (CompanyAdminRightsMaster.AddMode == "Edit")
      {
        string selectedValue = this.ddlModule.SelectedValue;
        if (string.IsNullOrEmpty(this.ddlModule.SelectedValue) && string.IsNullOrEmpty(this.ddlCompanyAdmin.SelectedValue))
        {
          this.objFormGridMasterDT = this.objFormGridMasterBll.GetAllData(new int?());
          if (this.objFormGridMasterDT.Rows.Count <= 0)
            return;
          this.gvForm.DataSource = (object) this.objFormGridMasterDT;
          this.gvForm.DataBind();
          this.gvForm.Enabled = false;
          this.btnEdit.Visible = false;
        }
        else
        {
          this.objCompanyAdminUserRightsMasterDT = this.objCompanyAdminUserRightsMasterBll.GetDataBySelectRightsDetails(int.Parse(this.ddlCompanyAdmin.SelectedValue.Trim()), int.Parse(this.ddlCompanyLogin.SelectedValue.Trim()), int.Parse(this.ddlModule.SelectedValue.Trim()));
          if (this.objCompanyAdminUserRightsMasterDT.Rows.Count > 0)
          {
            this.gvForm.DataSource = (object) this.objCompanyAdminUserRightsMasterDT;
            this.gvForm.DataBind();
            this.gvForm.Enabled = false;
            this.btnEdit.Visible = true;
          }
          else
          {
            this.objFormGridMasterDT = this.objFormGridMasterBll.GetAllData(new int?(int.Parse(selectedValue)));
            if (this.objFormGridMasterDT.Rows.Count > 0)
            {
              this.gvForm.DataSource = (object) this.objFormGridMasterDT;
              this.gvForm.DataBind();
              this.gvForm.Enabled = false;
              this.btnEdit.Visible = false;
            }
            else
            {
              this.gvForm.DataSource = (object) this.objFormGridMasterDT;
              this.gvForm.DataBind();
              this.btnEdit.Visible = false;
            }
          }
        }
      }
      else
      {
        string selectedValue = this.ddlModule.SelectedValue;
        if (string.IsNullOrEmpty(this.ddlModule.SelectedValue) && string.IsNullOrEmpty(this.ddlCompanyAdmin.SelectedValue))
        {
          this.objFormGridMasterDT = this.objFormGridMasterBll.GetAllData(new int?());
          if (this.objFormGridMasterDT.Rows.Count <= 0)
            return;
          this.gvForm.DataSource = (object) this.objFormGridMasterDT;
          this.gvForm.Enabled = false;
          this.btnSubmit.Visible = false;
          this.btnReset.Visible = false;
          this.gvForm.DataBind();
        }
        else
        {
          this.objCompanyAdminUserRightsMasterDT = this.objCompanyAdminUserRightsMasterBll.GetDataBySelectRightsDetails(int.Parse(this.ddlCompanyAdmin.SelectedValue.Trim()), int.Parse(this.ddlCompanyLogin.SelectedValue.Trim()), int.Parse(this.ddlModule.SelectedValue.Trim()));
          if (this.objCompanyAdminUserRightsMasterDT.Rows.Count > 0)
          {
            this.gvForm.DataSource = (object) this.objCompanyAdminUserRightsMasterDT;
            this.gvForm.DataBind();
            this.gvForm.Enabled = false;
            this.btnSubmit.Visible = false;
            this.btnReset.Visible = false;
          }
          else
          {
            this.objFormGridMasterDT = this.objFormGridMasterBll.GetAllData(new int?(int.Parse(selectedValue)));
            if (this.objFormGridMasterDT.Rows.Count > 0)
            {
              this.gvForm.DataSource = (object) this.objFormGridMasterDT;
              this.gvForm.DataBind();
              this.gvForm.Enabled = true;
              this.btnSubmit.Visible = true;
              this.btnReset.Visible = true;
            }
            else
            {
              this.gvForm.DataSource = (object) this.objFormGridMasterDT;
              this.gvForm.DataBind();
              this.btnSubmit.Visible = false;
              this.btnReset.Visible = false;
            }
          }
        }
      }
    }

    protected void gvCompanyAdminUserRights_SelectedIndexChanged(object sender, EventArgs e)
    {
      Label label1 = this.gvCompanyAdminUserRights.SelectedRow.FindControl("lblCompanyID") as Label;
      Label label2 = this.gvCompanyAdminUserRights.SelectedRow.FindControl("lblCompanyAdminID") as Label;
      if (label1 == null || label2 == null)
        return;
      this.Response.Redirect("~/Admin/CompanyAdminRightsMaster.aspx?cmd=view&ID=" + label1.Text + "&CompanyAdminID=" + label2.Text);
    }

    protected void gvCompanyAdminUserRights_PageIndexChanged(object sender, EventArgs e)
    {
      this.BindGrid();
    }

    protected void gvCompanyAdminUserRights_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(e.Row.Cells[1].Text));
        if (this.objCompanyMasterDT.Rows.Count > 0)
        {
          string str = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
          e.Row.Cells[1].Text = str;
        }
      }
      if (e.Row.RowType != DataControlRowType.DataRow)
        return;
      this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginID(int.Parse(e.Row.Cells[2].Text));
      if (this.objCompanyLoginMasterDT.Rows.Count <= 0)
        return;
      string str1 = this.objCompanyLoginMasterDT.Rows[0]["CompanyUserName"].ToString();
      e.Row.Cells[2].Text = str1;
    }

    protected void gvForm_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvForm.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!(this.ddlCompanyAdmin.SelectedValue != "-1") || !(this.ddlModule.SelectedValue != "0") || (!(this.ddlModule.SelectedValue != "-1") || !(this.ddlCompanyLogin.SelectedValue != "-1")))
        return;
      this.SubBindGrid();
    }

    protected void chkEdit_CheckedChanged(object sender, EventArgs e)
    {
      for (int index = 0; index < this.gvForm.Rows.Count; ++index)
      {
        bool @checked = ((CheckBox) this.gvForm.Rows[index].FindControl("chkEdit")).Checked;
        CheckBox checkBox = (CheckBox) this.gvForm.Rows[index].FindControl("chkView");
        if (@checked)
          checkBox.Checked = true;
      }
    }

    protected void chkDelete_CheckedChanged(object sender, EventArgs e)
    {
      for (int index = 0; index < this.gvForm.Rows.Count; ++index)
      {
        bool @checked = ((CheckBox) this.gvForm.Rows[index].FindControl("chkDelete")).Checked;
        CheckBox checkBox = (CheckBox) this.gvForm.Rows[index].FindControl("chkView");
        if (@checked)
          checkBox.Checked = true;
      }
    }

    protected void chkView_CheckedChanged(object sender, EventArgs e)
    {
      for (int index = 0; index < this.gvForm.Rows.Count; ++index)
      {
        bool checked1 = ((CheckBox) this.gvForm.Rows[index].FindControl("chkDelete")).Checked;
        bool checked2 = ((CheckBox) this.gvForm.Rows[index].FindControl("chkEdit")).Checked;
        CheckBox checkBox = (CheckBox) this.gvForm.Rows[index].FindControl("chkView");
        if (checked2)
          checkBox.Checked = true;
        else if (checked1)
          checkBox.Checked = true;
      }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/CompanyAdminRightsMaster.aspx?cmd=add");
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/CompanyAdminRightsMaster.aspx?cmd=add&ID=" + this.ddlCompanyAdmin.SelectedValue.Trim() + "&CompanyAdminID=" + this.ddlCompanyLogin.SelectedValue.Trim() + "&ModuleID=" + this.ddlModule.SelectedValue.Trim());
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/CompanyAdminRightsMaster.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/CompanyAdminRightsMaster.aspx?cmd=view&ID=" + this.ddlCompanyAdmin.SelectedValue.Trim() + "&CompanyAdminID=" + this.ddlCompanyLogin.SelectedValue.Trim() + "&ModuleID=" + this.ddlModule.SelectedValue.Trim());
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      this.objCompanyAdminUserRightsMasterDT = this.objCompanyAdminUserRightsMasterBll.GetDataBySelectRightsDetails(int.Parse(this.ddlCompanyAdmin.SelectedValue.Trim()), int.Parse(this.ddlCompanyLogin.SelectedValue.Trim()), int.Parse(this.ddlModule.SelectedValue.Trim()));
      if (this.objCompanyAdminUserRightsMasterDT.Rows.Count > 0)
        this.DisplayAlert("User Rights Already Entered.");
      else if (this.ddlCompanyAdmin.SelectedValue != "-1" && this.ddlCompanyAdmin.SelectedValue != "-1" && this.ddlModule.SelectedValue != "0")
      {
        for (int index = 0; index < this.gvForm.Rows.Count; ++index)
        {
          if (this.objCompanyAdminUserRightsMasterBll.AddCompanyAdminRights(int.Parse(this.ddlCompanyAdmin.SelectedValue.Trim()), int.Parse(this.ddlCompanyLogin.SelectedValue.Trim()), int.Parse(this.ddlModule.SelectedValue.Trim()), int.Parse(((Label) this.gvForm.Rows[index].FindControl("lblFormID")).Text), ((Label) this.gvForm.Rows[index].FindControl("lblFormName")).Text.Trim(), ((CheckBox) this.gvForm.Rows[index].FindControl("chkAdd")).Checked, ((CheckBox) this.gvForm.Rows[index].FindControl("chkEdit")).Checked, ((CheckBox) this.gvForm.Rows[index].FindControl("chkDelete")).Checked, ((CheckBox) this.gvForm.Rows[index].FindControl("chkView")).Checked) == 0)
            this.DisplayAlert("Fail to Add New Details.");
        }
        this.Response.Redirect("~/Admin/CompanyAdminRightsMaster.aspx?cmd=view&ID=" + this.ddlCompanyAdmin.SelectedValue.Trim() + "&CompanyAdminID=" + this.ddlCompanyLogin.SelectedValue.Trim() + "&ModuleID=" + this.ddlModule.SelectedValue.Trim());
      }
      else
        this.DisplayAlert("Please Enter All Details.");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
      if (this.ddlCompanyAdmin.SelectedValue != "0" && this.ddlModule.SelectedValue != "0")
      {
        for (int index = 0; index < this.gvForm.Rows.Count; ++index)
        {
          this.hfCompanyAdminRightsID.Value = ((Label) this.gvForm.Rows[index].FindControl("lblUesrRightsID")).Text;
          Label label1 = (Label) this.gvForm.Rows[index].FindControl("lblFormName");
          Label label2 = (Label) this.gvForm.Rows[index].FindControl("lblFormID");
          CheckBox checkBox1 = (CheckBox) this.gvForm.Rows[index].FindControl("chkAdd");
          CheckBox checkBox2 = (CheckBox) this.gvForm.Rows[index].FindControl("chkEdit");
          CheckBox checkBox3 = (CheckBox) this.gvForm.Rows[index].FindControl("chkDelete");
          CheckBox checkBox4 = (CheckBox) this.gvForm.Rows[index].FindControl("chkView");
          if (!this.objCompanyAdminUserRightsMasterBll.UpdateCompanyAdminRights(int.Parse(this.hfCompanyAdminRightsID.Value.Trim()), int.Parse(this.ddlCompanyAdmin.SelectedValue.Trim()), int.Parse(this.ddlCompanyLogin.SelectedValue.Trim()), int.Parse(this.ddlModule.SelectedValue.Trim()), int.Parse(label2.Text), label1.Text.Trim(), checkBox1.Checked, checkBox2.Checked, checkBox3.Checked, checkBox4.Checked))
            this.DisplayAlert("Fail to Update Details.");
        }
        this.Response.Redirect("~/Admin/CompanyAdminRightsMaster.aspx?cmd=view&ID=" + this.ddlCompanyAdmin.SelectedValue.Trim() + "&CompanyAdminID=" + this.ddlCompanyLogin.SelectedValue.Trim() + "&ModuleID=" + this.ddlModule.SelectedValue.Trim());
      }
      else
        this.DisplayAlert("Please Enter All Details.");
    }

    public void DisplayAlert(string message)
    {
      this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">" + this.GetAlertScript(message) + "</script>");
    }

    public string GetAlertScript(string message)
    {
      return "alert('" + message.Replace("'", "\\'") + "');";
    }

    protected void gvCompanyAdminUserRights_Sorting(object sender, GridViewSortEventArgs e)
    {
      this.BindGrid();
    }

    protected void ddlCompanyAdmin_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.hfCompanyID.Value = this.ddlCompanyAdmin.SelectedItem.Value;
      this.objCompanyPackageDetailsDT = this.objCompanyPackageDetailsBll.GetDataByCompanyActivePackage(int.Parse(this.ddlCompanyAdmin.SelectedItem.Value));
      if (this.objCompanyPackageDetailsDT.Rows.Count > 0)
        this.Session["PackageID"] = (object) this.objCompanyPackageDetailsDT.Rows[0]["PackageID"].ToString();
      this.ddlModule_SelectedIndexChanged(sender, e);
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.MasterAdminRightsMaster
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
  public class MasterAdminRightsMaster : Page
  {
    private static string MasterAdminID = string.Empty;
    private static string ModuleID = string.Empty;
    private static string AddMode = string.Empty;
    private readonly FormGridMasterAdminMasterAdminMasterBLL objFormGridMasterBll = new FormGridMasterAdminMasterAdminMasterBLL();
    private CloudAccountDA.FormGridMasterAdminMasterDataTable objFormGridMasterDT = new CloudAccountDA.FormGridMasterAdminMasterDataTable();
    private readonly MasterAdminRightsMasterBLL objMasterAdminUserRightsMasterBll = new MasterAdminRightsMasterBLL();
    private CloudAccountDA.MasterAdminRightsMasterDataTable objMasterAdminUserRightsMasterDT = new CloudAccountDA.MasterAdminRightsMasterDataTable();
    private readonly MasterAdminLoginMasterBLL objMasterAdminMasterBll = new MasterAdminLoginMasterBLL();
    private CloudAccountDA.MasterAdminLoginMasterDataTable objMasterAdminMasterDT = new CloudAccountDA.MasterAdminLoginMasterDataTable();
    protected ScriptManager ScriptManager1;
    protected Panel gridPanel;
    protected GridView gvMasterAdminUserRights;
    protected Button btnAdd;
    protected Panel addPanel;
    protected DropDownList ddlMasterAdmin;
    protected DropDownList ddlModule;
    protected UpdatePanel upMainGrid;
    protected GridView gvForm;
    protected Button btnSubmit;
    protected HtmlInputButton btnReset;
    protected Button btnUpdate;
    protected Button btnEdit;
    protected Button btnListAll;
    protected Button btnCancel;
    protected HiddenField hfMasterAdminRightsID;
    protected HiddenField hfCompanyID;
    protected HiddenField hfMasterAdminID;
    protected HiddenField hfDealerID;
    protected SqlDataSource SqdsEmprights;
    protected SqlDataSource sqldsMasterAdmin;
    protected SqlDataSource sqldsModule;
    protected SqlDataSource sqldsForm;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("masterAdminMagmnt")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("masterAdminRights")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (this.Request.QueryString["cmd"] != null)
      {
        switch (this.Request.QueryString["cmd"])
        {
          case "view":
            if (this.Request.QueryString["MasterAdminID"] == null)
              break;
            MasterAdminRightsMaster.MasterAdminID = this.Request.QueryString["MasterAdminID"];
            MasterAdminRightsMaster.AddMode = "Edit";
            this.gridPanel.Visible = false;
            this.addPanel.Visible = true;
            if (this.Request.QueryString["ModuleID"] != null)
            {
              MasterAdminRightsMaster.MasterAdminID = this.Request.QueryString["MasterAdminID"];
              MasterAdminRightsMaster.ModuleID = this.Request.QueryString["ModuleID"];
              this.BindDropMasterAdminGrid();
              this.SetRecord(MasterAdminRightsMaster.MasterAdminID, MasterAdminRightsMaster.ModuleID);
            }
            else
            {
              this.BindDropMasterAdminGrid();
              this.ViewRecord(MasterAdminRightsMaster.MasterAdminID);
            }
            this.ddlMasterAdmin.Enabled = false;
            this.btnListAll.Visible = true;
            this.btnSubmit.Visible = false;
            this.btnReset.Visible = false;
            this.btnUpdate.Visible = false;
            this.btnCancel.Visible = false;
            break;
          case "add":
            if (this.Request.QueryString["MasterAdminID"] != null && this.Request.QueryString["ModuleID"] != null)
            {
              MasterAdminRightsMaster.MasterAdminID = this.Request.QueryString["MasterAdminID"];
              MasterAdminRightsMaster.ModuleID = this.Request.QueryString["ModuleID"];
              this.BindDropMasterAdminGrid();
              MasterAdminRightsMaster.AddMode = "Add";
              this.SetRecord(MasterAdminRightsMaster.MasterAdminID, MasterAdminRightsMaster.ModuleID);
              this.addPanel.Visible = true;
              this.gridPanel.Visible = false;
              this.ddlMasterAdmin.Enabled = false;
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
            this.BindDropMasterAdminGrid();
            this.btnEdit.Visible = false;
            this.btnListAll.Visible = false;
            this.btnUpdate.Visible = false;
            this.btnCancel.Visible = false;
            this.addPanel.Visible = true;
            this.gridPanel.Visible = false;
            MasterAdminRightsMaster.AddMode = "Add";
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
      this.gvMasterAdminUserRights.DataBind();
    }

    private void ViewRecord(string empID)
    {
      this.objMasterAdminUserRightsMasterDT = this.objMasterAdminUserRightsMasterBll.GetDataByViewRecords(int.Parse(empID));
      if (this.objMasterAdminUserRightsMasterDT.Rows.Count <= 0)
        return;
      this.ddlMasterAdmin.SelectedValue = this.objMasterAdminUserRightsMasterDT.Rows[0]["MasterAdminID"].ToString();
      this.ddlMasterAdmin.DataBind();
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
      foreach (GridViewRow gridViewRow in this.gvMasterAdminUserRights.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvMasterAdminUserRights, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    private void SetRecord(string empID, string mID)
    {
      if (MasterAdminRightsMaster.AddMode == "Edit")
      {
        this.objMasterAdminUserRightsMasterDT = this.objMasterAdminUserRightsMasterBll.GetDataBySelectRightsDetails(int.Parse(empID), int.Parse(mID));
        if (this.objMasterAdminUserRightsMasterDT.Rows.Count <= 0)
          return;
        this.ddlMasterAdmin.SelectedValue = this.objMasterAdminUserRightsMasterDT.Rows[0]["MasterAdminID"].ToString();
        this.ddlMasterAdmin.DataBind();
        this.ddlModule.SelectedValue = this.objMasterAdminUserRightsMasterDT.Rows[0]["ModuleID"].ToString();
        this.ddlModule.DataBind();
        this.objFormGridMasterDT = this.objFormGridMasterBll.GetAllData(new int?());
        this.gvForm.DataSource = (object) this.objMasterAdminUserRightsMasterDT;
        this.gvForm.DataBind();
        this.gvForm.Enabled = false;
        this.btnEdit.Visible = true;
      }
      else
      {
        this.objMasterAdminUserRightsMasterDT = this.objMasterAdminUserRightsMasterBll.GetDataBySelectRightsDetails(int.Parse(empID), int.Parse(mID));
        if (this.objMasterAdminUserRightsMasterDT.Rows.Count <= 0)
          return;
        this.ddlMasterAdmin.SelectedValue = this.objMasterAdminUserRightsMasterDT.Rows[0]["MasterAdminID"].ToString();
        this.ddlMasterAdmin.DataBind();
        this.ddlModule.SelectedValue = this.objMasterAdminUserRightsMasterDT.Rows[0]["ModuleID"].ToString();
        this.ddlModule.DataBind();
        this.objFormGridMasterDT = this.objFormGridMasterBll.GetAllData(new int?());
        this.gvForm.DataSource = (object) this.objMasterAdminUserRightsMasterDT;
        this.gvForm.DataBind();
        this.gvForm.Enabled = true;
        this.btnEdit.Visible = true;
      }
    }

    private void BindDropMasterAdminGrid()
    {
      this.ddlMasterAdmin.DataBind();
    }

    private void SubBindGrid()
    {
      if (MasterAdminRightsMaster.AddMode == "Edit")
      {
        string selectedValue = this.ddlModule.SelectedValue;
        if (string.IsNullOrEmpty(this.ddlModule.SelectedValue) && string.IsNullOrEmpty(this.ddlMasterAdmin.SelectedValue))
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
          this.objMasterAdminUserRightsMasterDT = this.objMasterAdminUserRightsMasterBll.GetDataBySelectRightsDetails(int.Parse(this.ddlMasterAdmin.SelectedValue.Trim()), int.Parse(this.ddlModule.SelectedValue.Trim()));
          if (this.objMasterAdminUserRightsMasterDT.Rows.Count > 0)
          {
            this.gvForm.DataSource = (object) this.objMasterAdminUserRightsMasterDT;
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
        if (string.IsNullOrEmpty(this.ddlModule.SelectedValue) && string.IsNullOrEmpty(this.ddlMasterAdmin.SelectedValue))
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
          this.objMasterAdminUserRightsMasterDT = this.objMasterAdminUserRightsMasterBll.GetDataBySelectRightsDetails(int.Parse(this.ddlMasterAdmin.SelectedValue.Trim()), int.Parse(this.ddlModule.SelectedValue.Trim()));
          if (this.objMasterAdminUserRightsMasterDT.Rows.Count > 0)
          {
            this.gvForm.DataSource = (object) this.objMasterAdminUserRightsMasterDT;
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

    protected void gvMasterAdminUserRights_SelectedIndexChanged(object sender, EventArgs e)
    {
      Label label = this.gvMasterAdminUserRights.SelectedRow.FindControl("lblMasterAdminID") as Label;
      if (label == null)
        return;
      this.Response.Redirect("~/BillTransact/MasterAdminRightsMaster.aspx?cmd=view&ID=&MasterAdminID=" + label.Text);
    }

    protected void gvMasterAdminUserRights_PageIndexChanged(object sender, EventArgs e)
    {
      this.BindGrid();
    }

    protected void gvMasterAdminUserRights_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType != DataControlRowType.DataRow)
        return;
      this.objMasterAdminMasterDT = this.objMasterAdminMasterBll.GetDataByMasterAdminUserID(int.Parse(e.Row.Cells[1].Text));
      if (this.objMasterAdminMasterDT.Rows.Count <= 0)
        return;
      string str1 = this.objMasterAdminMasterDT.Rows[0]["UserName"].ToString();
      string str2 = this.objMasterAdminMasterDT.Rows[0]["FirstName"].ToString();
      string str3 = this.objMasterAdminMasterDT.Rows[0]["LastName"].ToString();
      e.Row.Cells[1].Text = str2 + " " + str3 + " (" + str1 + ")";
    }

    protected void gvForm_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvForm.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!(this.ddlMasterAdmin.SelectedValue != "0") || !(this.ddlModule.SelectedValue != "0") || !(this.ddlModule.SelectedValue != "-1"))
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
      this.Response.Redirect("~/BillTransact/MasterAdminRightsMaster.aspx?cmd=add");
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/MasterAdminRightsMaster.aspx?cmd=add&ID=&MasterAdminID=" + this.ddlMasterAdmin.SelectedValue.Trim() + "&ModuleID=" + this.ddlModule.SelectedValue.Trim());
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/MasterAdminRightsMaster.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/MasterAdminRightsMaster.aspx?cmd=view&ID=&MasterAdminID=" + this.ddlMasterAdmin.SelectedValue.Trim() + "&ModuleID=" + this.ddlModule.SelectedValue.Trim());
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      this.objMasterAdminUserRightsMasterDT = this.objMasterAdminUserRightsMasterBll.GetDataBySelectRightsDetails(int.Parse(this.ddlMasterAdmin.SelectedValue.Trim()), int.Parse(this.ddlModule.SelectedValue.Trim()));
      if (this.objMasterAdminUserRightsMasterDT.Rows.Count > 0)
        this.DisplayAlert("User Rights Already Entered.");
      else if (this.ddlMasterAdmin.SelectedValue != "0" && this.ddlModule.SelectedValue != "0")
      {
        for (int index = 0; index < this.gvForm.Rows.Count; ++index)
        {
          if (this.objMasterAdminUserRightsMasterBll.AddMasterAdminRights(int.Parse(this.ddlMasterAdmin.SelectedValue.Trim()), int.Parse(this.ddlModule.SelectedValue.Trim()), int.Parse(((Label) this.gvForm.Rows[index].FindControl("lblFormID")).Text), ((Label) this.gvForm.Rows[index].FindControl("lblFormName")).Text.Trim(), ((CheckBox) this.gvForm.Rows[index].FindControl("chkAdd")).Checked, ((CheckBox) this.gvForm.Rows[index].FindControl("chkEdit")).Checked, ((CheckBox) this.gvForm.Rows[index].FindControl("chkDelete")).Checked, ((CheckBox) this.gvForm.Rows[index].FindControl("chkView")).Checked) == 0)
            this.DisplayAlert("Fail to Add New Details.");
        }
        this.Response.Redirect("~/BillTransact/MasterAdminRightsMaster.aspx?cmd=view&ID=&MasterAdminID=" + this.ddlMasterAdmin.SelectedValue.Trim() + "&ModuleID=" + this.ddlModule.SelectedValue.Trim());
      }
      else
        this.DisplayAlert("Please Enter All Details.");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
      if (this.ddlMasterAdmin.SelectedValue != "0" && this.ddlModule.SelectedValue != "0")
      {
        for (int index = 0; index < this.gvForm.Rows.Count; ++index)
        {
          this.hfMasterAdminRightsID.Value = ((Label) this.gvForm.Rows[index].FindControl("lblUesrRightsID")).Text;
          Label label1 = (Label) this.gvForm.Rows[index].FindControl("lblFormName");
          Label label2 = (Label) this.gvForm.Rows[index].FindControl("lblFormID");
          CheckBox checkBox1 = (CheckBox) this.gvForm.Rows[index].FindControl("chkAdd");
          CheckBox checkBox2 = (CheckBox) this.gvForm.Rows[index].FindControl("chkEdit");
          CheckBox checkBox3 = (CheckBox) this.gvForm.Rows[index].FindControl("chkDelete");
          CheckBox checkBox4 = (CheckBox) this.gvForm.Rows[index].FindControl("chkView");
          if (!this.objMasterAdminUserRightsMasterBll.UpdateMasterAdminRights(int.Parse(this.hfMasterAdminRightsID.Value.Trim()), int.Parse(this.ddlMasterAdmin.SelectedValue.Trim()), int.Parse(this.ddlModule.SelectedValue.Trim()), int.Parse(label2.Text), label1.Text.Trim(), checkBox1.Checked, checkBox2.Checked, checkBox3.Checked, checkBox4.Checked))
            this.DisplayAlert("Fail to Update Details.");
        }
        this.Response.Redirect("~/BillTransact/MasterAdminRightsMaster.aspx?cmd=view&ID=&MasterAdminID=" + this.ddlMasterAdmin.SelectedValue.Trim() + "&ModuleID=" + this.ddlModule.SelectedValue.Trim());
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

    protected void gvMasterAdminUserRights_Sorting(object sender, GridViewSortEventArgs e)
    {
      this.BindGrid();
    }
  }
}

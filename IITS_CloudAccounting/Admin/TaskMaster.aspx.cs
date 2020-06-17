// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.TaskMaster
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using DABL.BLL;
using DABL.DAL;
using System;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class TaskMaster : Page
  {
    private readonly TaskMasterBLL objTaskMasterBll = new TaskMasterBLL();
    private CloudAccountDA.TaskMasterDataTable objTaskMasterDT = new CloudAccountDA.TaskMasterDataTable();
    private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
    private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly MiscellaneousMasterBLL objMiscellaneousMasterBll = new MiscellaneousMasterBLL();
    private CloudAccountDA.MiscellaneousMasterDataTable objMiscellaneousMasterDT = new CloudAccountDA.MiscellaneousMasterDataTable();
    private int linePerPage = 15;
    private bool checkInDB;
    protected HtmlGenericControl divSave;
    protected HtmlGenericControl divUpdate;
    protected Panel pnlAdd;
    protected TextBox txtTaskName;
    protected RequiredFieldValidator rfvTask;
    protected TextBox txtTaskDesc;
    protected CheckBox chkBill;
    protected TextBox txtBillClient;
    protected Button btnSubmit;
    protected Button btnUpdate;
    protected Button btnSaveAdd;
    protected Panel pnlView;
    protected Label lblTaskName;
    protected Label lblTaskDesc;
    protected Label lblBill;
    protected Label lblBillClient;
    protected Panel pnlViewAll;
    protected Label lblHeader;
    protected Button btnAdd;
    protected Button btnUnDelete;
    protected Button btnArchived;
    protected Button btnUnArchived;
    protected Button btnDelete;
    protected GridView gvTask;
    protected HtmlAnchor activeTag;
    protected HtmlAnchor archivedTag;
    protected HtmlAnchor deletedTag;
    protected ObjectDataSource objdsTask;
    protected HiddenField hfCompanyID;
    protected HiddenField hfTaskID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("timeTracking")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("tasks")).Attributes.Add("class", "active open");
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
        else if (Roles.IsUserInRole(str, "Employee"))
        {
          this.objStaffMasterDT = this.objStaffMasterBll.GetDataByStaffUserName(str);
          if (this.objStaffMasterDT.Rows.Count > 0)
            this.hfCompanyID.Value = this.objStaffMasterDT.Rows[0]["CompanyID"].ToString();
        }
        this.SetMiscValues(this.hfCompanyID.Value);
      }
      if (this.IsPostBack)
        return;
      this.divSave.Visible = this.Session["saveTask"] != null;
      this.divUpdate.Visible = this.Session["updateTask"] != null;
      this.Session.Abandon();
      if (this.Request.QueryString["cmd"] != null)
      {
        switch (this.Request.QueryString["cmd"])
        {
          case "view":
            if (this.Request.QueryString["ID"] == null)
              break;
            string iD = this.Request.QueryString["ID"];
            this.pnlView.Visible = true;
            this.pnlViewAll.Visible = false;
            this.pnlAdd.Visible = false;
            this.ViewRecord(iD);
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
              this.btnSaveAdd.Visible = false;
              this.txtTaskName.Focus();
              break;
            }
            this.Clear();
            this.txtTaskName.Focus();
            this.pnlViewAll.Visible = false;
            this.pnlAdd.Visible = true;
            this.pnlView.Visible = false;
            this.btnUpdate.Visible = false;
            this.btnSubmit.Visible = true;
            this.btnSaveAdd.Visible = true;
            break;
          default:
            this.btnArchived.Visible = !this.CheckARQuery();
            this.btnUnArchived.Visible = this.CheckARQuery();
            this.btnDelete.Visible = !this.CheckDEQuery();
            this.btnUnDelete.Visible = this.CheckDEQuery();
            this.ATagStyle();
            this.pnlViewAll.Visible = true;
            this.pnlAdd.Visible = false;
            this.pnlView.Visible = false;
            this.BindGrid();
            break;
        }
      }
      else
      {
        this.btnArchived.Visible = !this.CheckARQuery();
        this.btnUnArchived.Visible = this.CheckARQuery();
        this.btnDelete.Visible = !this.CheckDEQuery();
        this.btnUnDelete.Visible = this.CheckDEQuery();
        this.ATagStyle();
        this.pnlViewAll.Visible = true;
        this.pnlAdd.Visible = false;
        this.pnlView.Visible = false;
        this.BindGrid();
      }
    }

    private void SetMiscValues(string companyID)
    {
      this.objMiscellaneousMasterDT = this.objMiscellaneousMasterBll.GetDataByCompanyID(int.Parse(companyID));
      if (this.objMiscellaneousMasterDT.Rows.Count <= 0)
        return;
      this.linePerPage = int.Parse(this.objMiscellaneousMasterDT.Rows[0]["LinesPerPage"].ToString());
      this.gvTask.PageSize = this.linePerPage;
    }

    private void ATagStyle()
    {
      if (this.Request.QueryString["ac"] != null && bool.Parse(this.Request.QueryString["ac"]))
      {
        this.activeTag.Attributes.Add("class", "activeTag");
        this.activeTag.Attributes.Remove("href");
        this.lblHeader.Text = "Tasks";
      }
      if (this.Request.QueryString["ar"] != null && bool.Parse(this.Request.QueryString["ar"]))
      {
        this.archivedTag.Attributes.Add("class", "activeTag");
        this.archivedTag.Attributes.Remove("href");
        this.lblHeader.Text = "Archived Tasks";
      }
      if (this.Request.QueryString["de"] != null && bool.Parse(this.Request.QueryString["de"]))
      {
        this.deletedTag.Attributes.Add("class", "activeTag");
        this.deletedTag.Attributes.Remove("href");
        this.lblHeader.Text = "Deleted Tasks";
      }
      if (this.Request.QueryString["ar"] != null || this.Request.QueryString["ac"] != null || this.Request.QueryString["de"] != null)
        return;
      this.activeTag.Attributes.Add("class", "activeTag");
      this.activeTag.Attributes.Remove("href");
      this.lblHeader.Text = "Tasks";
    }

    protected void gvTask_Sorting(object sender, GridViewSortEventArgs e)
    {
      this.BindGrid();
    }

    private void Clear()
    {
      this.txtTaskName.Text = this.txtTaskDesc.Text = "";
      this.txtBillClient.Text = "0.00";
      this.chkBill.Checked = false;
      this.txtTaskName.Focus();
    }

    private void ViewRecord(string iD)
    {
      this.objTaskMasterDT = this.objTaskMasterBll.GetDataByTaskID(int.Parse(iD));
      if (this.objTaskMasterDT.Rows.Count <= 0)
        return;
      this.hfTaskID.Value = this.objTaskMasterDT.Rows[0]["TaskID"].ToString();
      this.hfCompanyID.Value = this.objTaskMasterDT.Rows[0]["CompanyID"].ToString();
      this.lblTaskName.Text = this.objTaskMasterDT.Rows[0]["TaskName"].ToString();
      this.lblTaskDesc.Text = this.objTaskMasterDT.Rows[0]["TaskDesc"].ToString();
      this.lblBillClient.Text = this.objTaskMasterDT.Rows[0]["RatePerHours"].ToString();
      this.lblBill.Text = this.objTaskMasterDT.Rows[0]["BillToClient"].ToString();
    }

    private void SetRecord(string iD)
    {
      this.objTaskMasterDT = this.objTaskMasterBll.GetDataByTaskID(int.Parse(iD));
      if (this.objTaskMasterDT.Rows.Count <= 0)
        return;
      this.hfTaskID.Value = this.objTaskMasterDT.Rows[0]["TaskID"].ToString();
      this.hfCompanyID.Value = this.objTaskMasterDT.Rows[0]["CompanyID"].ToString();
      this.txtTaskName.Text = this.objTaskMasterDT.Rows[0]["TaskName"].ToString();
      this.txtTaskDesc.Text = this.objTaskMasterDT.Rows[0]["TaskDesc"].ToString();
      this.txtBillClient.Text = this.objTaskMasterDT.Rows[0]["RatePerHours"].ToString();
      this.chkBill.Checked = bool.Parse(this.objTaskMasterDT.Rows[0]["BillToClient"].ToString());
    }

    private void BindGrid()
    {
      this.gvTask.DataBind();
    }

    protected void gvTask_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/TaskMaster.aspx?cmd=add&ID=" + ((WebControl) this.gvTask.SelectedRow.Cells[0].FindControl("chkID")).ToolTip);
      this.BindGrid();
    }

    protected void gvTask_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvTask.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/TaskMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.txtTaskName.Text.Trim().Length > 0)
      {
        this.objTaskMasterDT = this.objTaskMasterBll.GetDataByTaskName(int.Parse(this.hfCompanyID.Value), this.txtTaskName.Text.Trim());
        if (this.objTaskMasterDT.Rows.Count > 0)
        {
          this.checkInDB = true;
          this.DisplayAlert("Task Already Exists..!");
        }
        if (this.checkInDB)
          return;
        int num = this.objTaskMasterBll.AddTask(int.Parse(this.hfCompanyID.Value), this.txtTaskName.Text.Trim(), this.txtTaskDesc.Text.Trim(), this.chkBill.Checked, new Decimal?(Decimal.Parse(this.txtBillClient.Text.Trim())), true, false, false);
        if (num != 0)
        {
          this.Session["saveTask"] = (object) 1;
          this.DisplayAlert("Details Added Successfully.");
          this.Response.Redirect("~/Admin/TaskMaster.aspx?cmd=add&ID=" + (object) num);
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
        if (this.txtTaskName.Text.Trim().Length > 0)
        {
          if (this.objTaskMasterBll.UpdateTask(int.Parse(this.hfTaskID.Value), int.Parse(this.hfCompanyID.Value), this.txtTaskName.Text.Trim(), this.txtTaskDesc.Text.Trim(), this.chkBill.Checked, new Decimal?(Decimal.Parse(this.txtBillClient.Text.Trim())), true, false, false))
          {
            this.Session["updateTask"] = (object) 1;
            this.DisplayAlert("Update Successfully..");
            this.Response.Redirect("~/Admin/TaskMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
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

    public void DisplayAlert(string message)
    {
      this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">" + this.GetAlertScript(message) + "</script>");
    }

    public string GetAlertScript(string message)
    {
      return "alert('" + message.Replace("'", "\\'") + "');";
    }

    protected string SetDescriptionLimit(string desc)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Insert(0, desc);
      if (stringBuilder.Length > 30)
        return stringBuilder.ToString().Substring(0, 30) + "...";
      return stringBuilder.ToString();
    }

    protected void btnSaveAdd_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid || !this.Page.IsValid)
        return;
      if (this.txtTaskName.Text.Trim().Length > 0)
      {
        this.objTaskMasterDT = this.objTaskMasterBll.GetDataByTaskName(int.Parse(this.hfCompanyID.Value), this.txtTaskName.Text.Trim());
        if (this.objTaskMasterDT.Rows.Count > 0)
        {
          this.checkInDB = true;
          this.DisplayAlert("Task Already Exists..!");
        }
        if (this.checkInDB)
          return;
        if (this.objTaskMasterBll.AddTask(int.Parse(this.hfCompanyID.Value), this.txtTaskName.Text.Trim(), this.txtTaskDesc.Text.Trim(), this.chkBill.Checked, new Decimal?(Decimal.Parse(this.txtBillClient.Text.Trim())), true, false, false) != 0)
        {
          this.Session["saveTask"] = (object) 1;
          this.DisplayAlert("Details Added Successfully.");
          this.btnAdd_Click(sender, e);
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

    protected void btnArchived_Click(object sender, EventArgs e)
    {
      int num = 0;
      for (int index = 0; index < this.gvTask.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvTask.Rows[index].Cells[0].FindControl("chkID");
        if (checkBox.Checked)
        {
          ++num;
          this.objTaskMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), false, false, true);
        }
      }
      if (num == 0)
        this.DisplayAlert("No Tasks were selected.");
      else
        this.Response.Redirect("TaskMaster.aspx");
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      int num = 0;
      for (int index = 0; index < this.gvTask.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvTask.Rows[index].Cells[0].FindControl("chkID");
        if (checkBox.Checked)
        {
          ++num;
          this.objTaskMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), false, true, false);
        }
      }
      if (num == 0)
        this.DisplayAlert("No Tasks were selected.");
      else
        this.Response.Redirect("TaskMaster.aspx?de=true&ac=false");
    }

    protected void btnUnArchived_Click(object sender, EventArgs e)
    {
      int num = 0;
      for (int index = 0; index < this.gvTask.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvTask.Rows[index].Cells[0].FindControl("chkID");
        if (checkBox.Checked)
        {
          ++num;
          this.objTaskMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), true, false, false);
        }
      }
      if (num == 0)
        this.DisplayAlert("No Tasks were selected.");
      else
        this.Response.Redirect("TaskMaster.aspx?ar=true&ac=false");
    }

    protected void btnUnDelete_Click(object sender, EventArgs e)
    {
      int num = 0;
      for (int index = 0; index < this.gvTask.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvTask.Rows[index].Cells[0].FindControl("chkID");
        if (checkBox.Checked)
        {
          ++num;
          this.objTaskMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), true, false, false);
        }
      }
      if (num == 0)
        this.DisplayAlert("No Tasks were selected.");
      else
        this.Response.Redirect("TaskMaster.aspx?de=true&ac=false");
    }

    public bool CheckARQuery()
    {
      return this.Request.QueryString["ar"] != null && bool.Parse(this.Request.QueryString["ar"]);
    }

    public bool CheckDEQuery()
    {
      return this.Request.QueryString["de"] != null && bool.Parse(this.Request.QueryString["de"]);
    }

    protected void lnkEdit_OnClick(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/TaskMaster.aspx?cmd=add&ID=" + ((LinkButton) sender).CommandArgument);
    }
  }
}

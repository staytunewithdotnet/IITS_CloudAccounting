// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.ContractorMaster
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class ContractorMaster : Page
  {
    private readonly ContractorMasterBLL objContractorMasterBll = new ContractorMasterBLL();
    private CloudAccountDA.ContractorMasterDataTable objContractorMasterDT = new CloudAccountDA.ContractorMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
    private readonly TaskMasterBLL objTaskMasterBll = new TaskMasterBLL();
    private CloudAccountDA.TaskMasterDataTable objTaskMasterDT = new CloudAccountDA.TaskMasterDataTable();
    private readonly CompanyClientMasterBLL objCompanyClientMasterBll = new CompanyClientMasterBLL();
    private CloudAccountDA.CompanyClientMasterDataTable objCompanyClientMasterDT = new CloudAccountDA.CompanyClientMasterDataTable();
    private readonly CompanyClientContactDetailBLL objCompanyClientContactDetailBll = new CompanyClientContactDetailBLL();
    private CloudAccountDA.CompanyClientContactDetailDataTable objCompanyClientContactDetailDT = new CloudAccountDA.CompanyClientContactDetailDataTable();
    private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
    private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
    private readonly ContractorProjectDetailBLL objContractorProjectDetailBll = new ContractorProjectDetailBLL();
    private CloudAccountDA.ContractorProjectDetailDataTable objContractorProjectDetailDT = new CloudAccountDA.ContractorProjectDetailDataTable();
    protected ToolkitScriptManager tsm;
    protected HtmlGenericControl divSave;
    protected HtmlGenericControl divUpdate;
    protected Panel pnlAdd;
    protected UpdatePanel upContractor;
    protected TextBox txtContractorEmail;
    protected RequiredFieldValidator rfvContractorEmail;
    protected RegularExpressionValidator revEmail;
    protected TextBox txtContractorName;
    protected RequiredFieldValidator rfvContractorName;
    protected UpdatePanel upTask;
    protected HtmlGenericControl taskDropdown;
    protected DropDownList ddlTask;
    protected RequiredFieldValidator rfvTaskDrop;
    protected HtmlGenericControl taskTextbox;
    protected TextBox txtTask;
    protected RequiredFieldValidator rfvTaskText;
    protected LinkButton lnkPick;
    protected TextBox txtRebillRate;
    protected HtmlGenericControl projectsDiv;
    protected CheckBoxList chkProjects;
    protected SqlDataSource sqldsProjects;
    protected Button btnSubmit;
    protected Button btnUpdate;
    protected Panel pnlView;
    protected Label lblContractorName;
    protected Button btnEdit;
    protected Label lblContractorName1;
    protected Label lblContractorEmail;
    protected Label lblRebillRate;
    protected DataList dlProjectsView;
    protected SqlDataSource sqldsProjectView;
    protected Label lblTask;
    protected Panel pnlViewNo;
    protected Panel pnlViewAll;
    protected Button btnAdd;
    protected GridView gvContractor;
    protected ObjectDataSource objdsContractor;
    protected HiddenField hfCompanyID;
    protected HiddenField hfContractorID;
    protected SqlDataSource sqldsTask;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("userManagement")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("staffContractor")).Attributes.Add("class", "active open");
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
      if (this.IsPostBack)
        return;
      this.divSave.Visible = this.Session["saveContractor"] != null;
      this.divUpdate.Visible = this.Session["updateContractor"] != null;
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
              this.txtContractorEmail.Focus();
              break;
            }
            this.Clear();
            this.txtContractorEmail.Focus();
            this.pnlViewAll.Visible = false;
            this.pnlAdd.Visible = true;
            this.pnlView.Visible = false;
            this.btnUpdate.Visible = false;
            this.btnSubmit.Visible = true;
            break;
          default:
            this.pnlViewAll.Visible = true;
            this.pnlAdd.Visible = false;
            this.pnlView.Visible = false;
            this.BindGrid();
            break;
        }
      }
      else
      {
        this.pnlViewAll.Visible = true;
        this.pnlAdd.Visible = false;
        this.pnlView.Visible = false;
        this.BindGrid();
      }
    }

    protected void gvContractor_Sorting(object sender, GridViewSortEventArgs e)
    {
      this.BindGrid();
    }

    private void Clear()
    {
      this.sqldsProjects.DataBind();
      this.chkProjects.DataBind();
      this.projectsDiv.Visible = this.chkProjects.Items.Count > 0;
      this.txtContractorName.Text = this.txtContractorEmail.Text = "";
      this.txtRebillRate.Text = "0.00";
      this.ddlTask.SelectedIndex = 0;
      this.txtContractorEmail.Focus();
    }

    private void ViewRecord(string iD)
    {
      this.objContractorMasterDT = this.objContractorMasterBll.GetDataByContractorID(int.Parse(iD));
      if (this.objContractorMasterDT.Rows.Count <= 0)
        return;
      this.hfContractorID.Value = this.objContractorMasterDT.Rows[0]["ContractorID"].ToString();
      this.hfCompanyID.Value = this.objContractorMasterDT.Rows[0]["CompanyID"].ToString();
      this.lblContractorName1.Text = this.lblContractorName.Text = this.objContractorMasterDT.Rows[0]["ContractorName"].ToString();
      this.lblContractorEmail.Text = this.objContractorMasterDT.Rows[0]["ContractorEmail"].ToString();
      this.lblRebillRate.Text = this.objContractorMasterDT.Rows[0]["RebillRate"].ToString();
      string s = this.objContractorMasterDT.Rows[0]["TaskID"].ToString();
      if (string.IsNullOrEmpty(s))
        return;
      this.objTaskMasterDT = this.objTaskMasterBll.GetDataByTaskID(int.Parse(s));
      this.lblTask.Text = this.objTaskMasterDT.Rows[0]["TaskName"].ToString();
    }

    private void SetRecord(string iD)
    {
      this.objContractorMasterDT = this.objContractorMasterBll.GetDataByContractorID(int.Parse(iD));
      if (this.objContractorMasterDT.Rows.Count <= 0)
        return;
      this.hfContractorID.Value = this.objContractorMasterDT.Rows[0]["ContractorID"].ToString();
      this.hfCompanyID.Value = this.objContractorMasterDT.Rows[0]["CompanyID"].ToString();
      this.txtContractorName.Text = this.objContractorMasterDT.Rows[0]["ContractorName"].ToString();
      this.txtContractorEmail.Text = this.objContractorMasterDT.Rows[0]["ContractorEmail"].ToString();
      this.txtRebillRate.Text = this.objContractorMasterDT.Rows[0]["RebillRate"].ToString();
      string str1 = this.objContractorMasterDT.Rows[0]["TaskID"].ToString();
      if (!string.IsNullOrEmpty(str1))
        this.ddlTask.SelectedValue = str1;
      this.sqldsProjects.DataBind();
      this.chkProjects.DataBind();
      this.projectsDiv.Visible = this.chkProjects.Items.Count > 0;
      this.objContractorProjectDetailDT = this.objContractorProjectDetailBll.GetDataByContractorID(int.Parse(this.hfContractorID.Value));
      if (this.objContractorProjectDetailDT.Rows.Count <= 0)
        return;
      for (int index = 0; index < this.objContractorProjectDetailDT.Rows.Count; ++index)
      {
        string str2 = this.objContractorProjectDetailDT.Rows[index]["ProjectID"].ToString();
        foreach (ListItem listItem in this.chkProjects.Items)
        {
          if (listItem.Value == str2)
          {
            listItem.Selected = true;
            break;
          }
        }
      }
    }

    private void BindGrid()
    {
      this.gvContractor.DataBind();
    }

    protected void gvContractor_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/ContractorMaster.aspx?cmd=add&ID=" + this.gvContractor.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvContractor_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvContractor.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvContractor.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvContractor, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/ContractorMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.txtContractorEmail.Text.Trim().Length > 0 && this.ddlTask.SelectedIndex > 0)
      {
        int num;
        if (int.Parse(this.ddlTask.SelectedItem.Value) == 99999999)
        {
          num = this.objContractorMasterBll.AddContractor(int.Parse(this.hfCompanyID.Value), this.txtContractorEmail.Text.Trim(), this.txtContractorName.Text.Trim(), new int?(this.objTaskMasterBll.AddTask(int.Parse(this.hfCompanyID.Value), this.txtTask.Text.Trim(), "", true, new Decimal?(new Decimal(0)), true, false, false)), new Decimal?(Decimal.Parse(this.txtRebillRate.Text.Trim())), true, false, false);
        }
        else
        {
          int? iTaskID = new int?();
          if (this.ddlTask.SelectedIndex > 0)
            iTaskID = new int?(int.Parse(this.ddlTask.SelectedItem.Value));
          num = this.objContractorMasterBll.AddContractor(int.Parse(this.hfCompanyID.Value), this.txtContractorEmail.Text.Trim(), this.txtContractorName.Text.Trim(), iTaskID, new Decimal?(Decimal.Parse(this.txtRebillRate.Text.Trim())), true, false, false);
        }
        if (num != 0)
        {
          if (this.projectsDiv.Visible)
          {
            this.hfContractorID.Value = num.ToString();
            this.objContractorProjectDetailBll.DeleteByContractor(int.Parse(this.hfContractorID.Value));
            foreach (ListItem listItem in this.chkProjects.Items)
            {
              if (listItem.Selected)
                this.objContractorProjectDetailBll.AddContractorProjectDetail(int.Parse(this.hfCompanyID.Value), int.Parse(this.hfContractorID.Value), int.Parse(listItem.Value));
            }
          }
          this.Session["saveContractor"] = (object) 1;
          this.DisplayAlert("Details Added Successfully.");
          this.Response.Redirect("~/BillTransact/ContractorMaster.aspx?cmd=add&ID=" + (object) num);
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
        if (this.txtContractorName.Text.Trim().Length > 0 && this.ddlTask.SelectedIndex > 0)
        {
          bool flag;
          if (int.Parse(this.ddlTask.SelectedItem.Value) == 99999999)
          {
            flag = this.objContractorMasterBll.UpdateContractor(int.Parse(this.hfContractorID.Value), int.Parse(this.hfCompanyID.Value), this.txtContractorEmail.Text.Trim(), this.txtContractorName.Text.Trim(), new int?(this.objTaskMasterBll.AddTask(int.Parse(this.hfCompanyID.Value), this.txtTask.Text.Trim(), "", true, new Decimal?(new Decimal(0)), true, false, false)), new Decimal?(Decimal.Parse(this.txtRebillRate.Text.Trim())), true, false, false);
          }
          else
          {
            int? iTaskID = new int?();
            if (this.ddlTask.SelectedIndex > 0)
              iTaskID = new int?(int.Parse(this.ddlTask.SelectedItem.Value));
            flag = this.objContractorMasterBll.UpdateContractor(int.Parse(this.hfContractorID.Value), int.Parse(this.hfCompanyID.Value), this.txtContractorEmail.Text.Trim(), this.txtContractorName.Text.Trim(), iTaskID, new Decimal?(Decimal.Parse(this.txtRebillRate.Text.Trim())), true, false, false);
          }
          if (flag)
          {
            if (this.projectsDiv.Visible)
            {
              this.objContractorProjectDetailBll.DeleteByContractor(int.Parse(this.hfContractorID.Value));
              foreach (ListItem listItem in this.chkProjects.Items)
              {
                if (listItem.Selected)
                  this.objContractorProjectDetailBll.AddContractorProjectDetail(int.Parse(this.hfCompanyID.Value), int.Parse(this.hfContractorID.Value), int.Parse(listItem.Value));
              }
            }
            this.Session["updateContractor"] = (object) 1;
            this.DisplayAlert("Update Successfully..");
            this.Response.Redirect("~/BillTransact/ContractorMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
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

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfContractorID.Value != null)
      {
        if (this.objContractorMasterBll.UpdateWhenDelete(int.Parse(this.hfContractorID.Value), false, true))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/BillTransact/ContractorMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    public void DisplayAlert(string message)
    {
      this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">" + this.GetAlertScript(message) + "</script>");
    }

    public string GetAlertScript(string message)
    {
      return "alert('" + message.Replace("'", "\\'") + "');";
    }

    protected void ddlTask_OnSelectedIndexChanged(object sender, EventArgs e)
    {
      if (int.Parse(this.ddlTask.SelectedItem.Value) == 99999999)
      {
        this.taskDropdown.Visible = false;
        this.taskTextbox.Visible = true;
        this.rfvTaskDrop.Enabled = false;
        this.rfvTaskText.Enabled = true;
        this.txtTask.Focus();
      }
      else
      {
        this.taskDropdown.Visible = true;
        this.taskTextbox.Visible = false;
        this.rfvTaskDrop.Enabled = true;
        this.rfvTaskText.Enabled = false;
        this.ddlTask.Focus();
      }
    }

    protected void lnkPick_OnClick(object sender, EventArgs e)
    {
      this.ddlTask.SelectedIndex = 0;
      this.ddlTask_OnSelectedIndexChanged(sender, e);
    }

    protected void txtEmail_OnTextChanged(object sender, EventArgs e)
    {
      this.objCompanyClientContactDetailDT = this.objCompanyClientContactDetailBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), this.txtContractorEmail.Text.Trim());
      this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), this.txtContractorEmail.Text.Trim());
      this.objStaffMasterDT = this.objStaffMasterBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), this.txtContractorEmail.Text.Trim());
      this.objContractorMasterDT = this.objContractorMasterBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), this.txtContractorEmail.Text.Trim());
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyEmail(this.txtContractorEmail.Text.Trim());
      if (this.objCompanyMasterDT.Rows.Count > 0)
      {
        this.DisplayAlert("Email Already Register With System To Some Company.");
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Email Already Register With System To Some Company.')", true);
        this.txtContractorEmail.Text = "";
        this.txtContractorEmail.Focus();
      }
      else if (this.objCompanyClientMasterDT.Rows.Count > 0 || this.objCompanyClientContactDetailDT.Rows.Count > 0)
      {
        this.DisplayAlert("Email Already Register With System To Some Client.");
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Email Already Register With System To Some Client.')", true);
        this.txtContractorEmail.Text = "";
        this.txtContractorEmail.Focus();
      }
      else if (this.objStaffMasterDT.Rows.Count > 0)
      {
        this.DisplayAlert("Email Already Register With System To Some Staff.");
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Email Already Register With System To Some Staff.')", true);
        this.txtContractorEmail.Text = "";
        this.txtContractorEmail.Focus();
      }
      else if (this.objContractorMasterDT.Rows.Count > 0)
      {
        this.DisplayAlert("Email Already Register With System To Some Contractor.");
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Email Already Register With System To Some Contractor.')", true);
        this.txtContractorEmail.Text = "";
        this.txtContractorEmail.Focus();
      }
      else
        this.txtContractorName.Focus();
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("ContractorMaster.aspx?cmd=add&ID=" + this.hfContractorID.Value);
    }
  }
}

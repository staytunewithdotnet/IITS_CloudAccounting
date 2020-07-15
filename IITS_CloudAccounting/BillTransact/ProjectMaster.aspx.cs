// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.ProjectMaster
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
  public class ProjectMaster : Page
  {
    private readonly ProjectMasterBLL objProjectMasterBll = new ProjectMasterBLL();
    private CloudAccountDA.ProjectMasterDataTable objProjectMasterDT = new CloudAccountDA.ProjectMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
    private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
    private readonly StaffProjectDetailBLL objStaffProjectDetailBll = new StaffProjectDetailBLL();
    private CloudAccountDA.StaffProjectDetailDataTable objStaffProjectDetailDT = new CloudAccountDA.StaffProjectDetailDataTable();
    private readonly ContractorProjectDetailBLL objContractorProjectDetailBll = new ContractorProjectDetailBLL();
    private CloudAccountDA.ContractorProjectDetailDataTable objContractorProjectDetailDT = new CloudAccountDA.ContractorProjectDetailDataTable();
    private readonly ProjectTaskDetailBLL objProjectTaskDetailBll = new ProjectTaskDetailBLL();
    private CloudAccountDA.ProjectTaskDetailDataTable objProjectTaskDetailDT = new CloudAccountDA.ProjectTaskDetailDataTable();
    private readonly CompanyClientMasterBLL objCompanyClientMasterBll = new CompanyClientMasterBLL();
    private CloudAccountDA.CompanyClientMasterDataTable objCompanyClientMasterDT = new CloudAccountDA.CompanyClientMasterDataTable();
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
    private readonly MiscellaneousMasterBLL objMiscellaneousMasterBll = new MiscellaneousMasterBLL();
    private CloudAccountDA.MiscellaneousMasterDataTable objMiscellaneousMasterDT = new CloudAccountDA.MiscellaneousMasterDataTable();
    private int linePerPage = 15;
    private bool checkInDB;
    protected ToolkitScriptManager tsm;
    protected HtmlGenericControl divSave;
    protected HtmlGenericControl divUpdate;
    protected Panel pnlAdd;
    protected UpdatePanel upProject;
    protected TextBox txtProjectName;
    protected RequiredFieldValidator rfvProjectName;
    protected TextBox txtProjectDesc;
    protected DropDownList ddlClient;
    protected CheckBox chkCanClient;
    protected SqlDataSource sqldsClient;
    protected DropDownList ddlManager;
    protected SqlDataSource sqldsStaff;
    protected DropDownList ddlMethod;
    protected HtmlGenericControl hourlyRate;
    protected TextBox txtProjectRate;
    protected HtmlGenericControl flatAmount;
    protected TextBox txtFlatAmount;
    protected TextBox txtTimeEstimate;
    protected UpdatePanel upTaskStaff;
    protected GridView gvTask;
    protected SqlDataSource sqldsTask;
    protected GridView gvUsers;
    protected SqlDataSource sqldsUser;
    protected Button btnSubmit;
    protected Button btnUpdate;
    protected Panel pnlView;
    protected Label lblProjectName;
    protected Button btnEdit;
    protected Button btnAddNew;
    protected GridView gvPersonTime;
    protected SqlDataSource sqldsPersonTime;
    protected GridView gvTaskTime;
    protected SqlDataSource sqldsTaskTime;
    protected Label lblMethod;
    protected HtmlAnchor aMethod;
    protected HtmlGenericControl divPro;
    protected Label lblProDetails;
    protected Label lblManager;
    protected GridView gvBudget;
    protected SqlDataSource sqldsBudget;
    protected Panel pnlViewAll;
    protected Label lblHeader;
    protected Button btnAdd;
    protected TextBox txtProjectSearch;
    protected TextBox txtClientNameSearch;
    protected TextBox txtTaskSearch;
    protected TextBox txtDescriptionSearch;
    protected TextBox txtTeamMenberSearch;
    protected TextBox txtInvoiceDateFrom;
    protected CalendarExtender ceDateFrom;
    protected TextBox txtInvoiceDateTo;
    protected CalendarExtender ceDateTo;
    protected Button btnSearch;
    protected Button btnReset;
    protected Button btnUnDelete;
    protected Button btnArchived;
    protected Button btnUnArchived;
    protected Button btnDelete;
    protected GridView gvProject;
    protected HtmlAnchor activeTag;
    protected HtmlAnchor archivedTag;
    protected HtmlAnchor deletedTag;
    protected ObjectDataSource objdsProject;
    protected ObjectDataSource objdsProjectStaff;
    protected HiddenField hfCompanyID;
    protected HiddenField hfStaffID;
    protected HiddenField hfProjectID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("timeTracking")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("projects")).Attributes.Add("class", "active open");
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
          {
            this.Response.Redirect("~/Admin/ProjectMasters.aspx");
            this.hfCompanyID.Value = this.objStaffMasterDT.Rows[0]["CompanyID"].ToString();
            this.hfStaffID.Value = this.objStaffMasterDT.Rows[0]["StaffID"].ToString();
          }
        }
        this.SetMiscValues(this.hfCompanyID.Value);
      }
      if (this.IsPostBack)
        return;
      this.divSave.Visible = this.Session["saveProject"] != null;
      this.divUpdate.Visible = this.Session["updateProject"] != null;
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
              this.txtProjectName.Focus();
              break;
            }
            this.Clear();
            this.txtProjectName.Focus();
            this.pnlViewAll.Visible = false;
            this.pnlAdd.Visible = true;
            this.pnlView.Visible = false;
            this.btnUpdate.Visible = false;
            this.btnSubmit.Visible = true;
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
      this.gvProject.PageSize = this.linePerPage;
    }

    private void SetRecord(string iD)
    {
      this.objProjectMasterDT = this.objProjectMasterBll.GetDataByProjectID(int.Parse(iD));
      if (this.objProjectMasterDT.Rows.Count <= 0)
        return;
      this.hfProjectID.Value = this.objProjectMasterDT.Rows[0]["ProjectID"].ToString();
      this.hfCompanyID.Value = this.objProjectMasterDT.Rows[0]["CompanyID"].ToString();
      this.txtProjectName.Text = this.objProjectMasterDT.Rows[0]["ProjectName"].ToString();
      this.txtProjectDesc.Text = this.objProjectMasterDT.Rows[0]["ProjectDesc"].ToString();
      this.ddlManager.SelectedValue = this.objProjectMasterDT.Rows[0]["ProjectManager"].ToString();
      this.ddlClient.SelectedValue = this.objProjectMasterDT.Rows[0]["ClientID"].ToString();
      this.chkCanClient.Visible = this.objProjectMasterDT.Rows[0]["ClientID"].ToString() != "0";
      this.chkCanClient.Checked = bool.Parse(this.objProjectMasterDT.Rows[0]["CanClient"].ToString());
      this.ddlMethod.SelectedIndex = this.ddlMethod.Items.IndexOf(this.ddlMethod.Items.FindByText(this.objProjectMasterDT.Rows[0]["BillingMethod"].ToString()));
      this.ddlMethod_SelectedIndexChanged((object) null, (EventArgs) null);
      this.txtFlatAmount.Text = this.objProjectMasterDT.Rows[0]["FlatAmount"].ToString();
      this.txtProjectRate.Text = this.objProjectMasterDT.Rows[0]["ProjectRate"].ToString();
      this.txtTimeEstimate.Text = this.objProjectMasterDT.Rows[0]["TimeEstimate"].ToString();
      bool flag = bool.Parse(this.objProjectMasterDT.Rows[0]["CompanyTeam"].ToString());
      this.gvUsers.DataBind();
      this.gvTask.DataBind();
      if (this.gvUsers.Rows.Count > 0 && flag)
      {
        for (int index = 0; index < this.gvUsers.Rows.Count; ++index)
        {
          CheckBox checkBox = (CheckBox) this.gvUsers.Rows[index].Cells[0].FindControl("chkUserID");
          if (checkBox.CssClass == "Admin")
          {
            checkBox.Checked = true;
            break;
          }
        }
      }
      this.objStaffProjectDetailDT = this.objStaffProjectDetailBll.GetDataByProjectID(int.Parse(this.hfProjectID.Value));
      if (this.objStaffProjectDetailDT.Rows.Count > 0)
      {
        for (int index1 = 0; index1 < this.objStaffProjectDetailDT.Rows.Count; ++index1)
        {
          for (int index2 = 0; index2 < this.gvUsers.Rows.Count; ++index2)
          {
            CheckBox checkBox = (CheckBox) this.gvUsers.Rows[index2].Cells[0].FindControl("chkUserID");
            if (checkBox.CssClass == "Staff" && checkBox.ToolTip == this.objStaffProjectDetailDT.Rows[index1]["StaffID"].ToString())
            {
              checkBox.Checked = true;
              break;
            }
          }
        }
      }
      this.objContractorProjectDetailDT = this.objContractorProjectDetailBll.GetDataByProjectID(int.Parse(this.hfProjectID.Value));
      if (this.objContractorProjectDetailDT.Rows.Count > 0)
      {
        for (int index1 = 0; index1 < this.objContractorProjectDetailDT.Rows.Count; ++index1)
        {
          for (int index2 = 0; index2 < this.gvUsers.Rows.Count; ++index2)
          {
            CheckBox checkBox = (CheckBox) this.gvUsers.Rows[index2].Cells[0].FindControl("chkUserID");
            if (checkBox.CssClass == "Contractor" && checkBox.ToolTip == this.objContractorProjectDetailDT.Rows[index1]["ContractorID"].ToString())
              checkBox.Checked = true;
          }
        }
      }
      this.objProjectTaskDetailDT = this.objProjectTaskDetailBll.GetDataByProjectID(int.Parse(this.hfProjectID.Value));
      if (this.objProjectTaskDetailDT.Rows.Count <= 0)
        return;
      for (int index = 0; index < this.objProjectTaskDetailDT.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvTask.Rows[index].Cells[0].FindControl("chkTaskID");
        if (checkBox.ToolTip == this.objProjectTaskDetailDT.Rows[index]["TaskID"].ToString())
          checkBox.Checked = true;
      }
    }

    private void ViewRecord(string iD)
    {
      this.objProjectMasterDT = this.objProjectMasterBll.GetDataByProjectID(int.Parse(iD));
      if (this.objProjectMasterDT.Rows.Count <= 0)
        return;
      this.hfProjectID.Value = this.objProjectMasterDT.Rows[0]["ProjectID"].ToString();
      this.aMethod.Attributes.Add("href", "ProjectMaster.aspx?cmd=add&ID=" + this.hfProjectID.Value);
      this.hfCompanyID.Value = this.objProjectMasterDT.Rows[0]["CompanyID"].ToString();
      this.lblProjectName.Text = this.objProjectMasterDT.Rows[0]["ProjectName"].ToString();
      this.lblManager.Text = this.objProjectMasterDT.Rows[0]["ProjectManager"].ToString();
      this.lblMethod.Text = this.objProjectMasterDT.Rows[0]["BillingMethod"].ToString();
      string str1 = "<b>Estimate:</b> " + this.objProjectMasterDT.Rows[0]["TimeEstimate"] + " hrs<br />";
      string str2 = "width: 0;";
      this.lblProDetails.Text = str1 + "<b>Progress:</b> 0%";
      this.gvBudget.DataBind();
      if (this.gvBudget.Rows.Count > 0)
      {
        string text = this.gvBudget.Rows[0].Cells[3].Text;
        str2 = "width: " + text + "%;";
        this.lblProDetails.Text = str1 + "<b>Progress:</b> " + text + "%";
      }
      this.divPro.Attributes.Add("style", str2);
      if (this.lblManager.Text == "0")
      {
        this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
        this.lblManager.Text = this.objCompanyMasterDT.Rows[0]["CompanyContactPerson"].ToString();
      }
      else
      {
        this.objStaffMasterDT = this.objStaffMasterBll.GetDataByStaffID(int.Parse(this.lblManager.Text));
        this.lblManager.Text = (string) this.objStaffMasterDT.Rows[0]["FirstName"] + (object) " " + (string) this.objStaffMasterDT.Rows[0]["LastName"];
      }
    }

    private void ATagStyle()
    {
      if (this.Request.QueryString["ac"] != null && bool.Parse(this.Request.QueryString["ac"]))
      {
        this.activeTag.Attributes.Add("class", "activeTag");
        this.activeTag.Attributes.Remove("href");
        this.lblHeader.Text = "Projects";
      }
      if (this.Request.QueryString["ar"] != null && bool.Parse(this.Request.QueryString["ar"]))
      {
        this.archivedTag.Attributes.Add("class", "activeTag");
        this.archivedTag.Attributes.Remove("href");
        this.lblHeader.Text = "Archived Projects";
      }
      if (this.Request.QueryString["de"] != null && bool.Parse(this.Request.QueryString["de"]))
      {
        this.deletedTag.Attributes.Add("class", "activeTag");
        this.deletedTag.Attributes.Remove("href");
        this.lblHeader.Text = "Deleted Projects";
      }
      if (this.Request.QueryString["ar"] != null || this.Request.QueryString["ac"] != null || this.Request.QueryString["de"] != null)
        return;
      this.activeTag.Attributes.Add("class", "activeTag");
      this.activeTag.Attributes.Remove("href");
      this.lblHeader.Text = "Projects";
    }

    protected void gvProject_Sorting(object sender, GridViewSortEventArgs e)
    {
      this.BindGrid();
    }

    private void BindGrid()
    {
      MembershipUser user = Membership.GetUser();
      if (user != null)
      {
        string username = user.ToString();
        if (Roles.IsUserInRole(username, "Admin"))
          this.gvProject.DataSource = (object) this.objdsProject;
        else if (Roles.IsUserInRole(username, "Employee"))
          this.gvProject.DataSource = (object) this.objdsProjectStaff;
      }
      this.gvProject.DataBind();
      if (this.gvProject.DataSource != this.objdsProjectStaff || this.gvProject.Rows.Count <= 0)
        return;
      for (int index = 0; index < this.gvProject.Rows.Count; ++index)
      {
        this.gvProject.Rows[index].Cells[0].FindControl("chkID").Visible = false;
        this.gvProject.Rows[index].Cells[4].FindControl("lnkEdit").Visible = false;
      }
    }

    private void Clear()
    {
      this.txtProjectName.Text = this.txtProjectDesc.Text = this.txtFlatAmount.Text = this.txtProjectRate.Text = "";
      this.txtTimeEstimate.Text = "0.00";
      this.ddlClient.SelectedIndex = this.ddlManager.SelectedIndex = this.ddlMethod.SelectedIndex = 0;
      this.chkCanClient.Checked = false;
      this.txtProjectName.Focus();
    }

    protected void gvProject_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/ProjectMaster.aspx?cmd=add&ID=" + ((WebControl) this.gvProject.SelectedRow.Cells[0].FindControl("chkID")).ToolTip);
      this.BindGrid();
    }

    protected void gvProject_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvProject.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/ProjectMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.txtProjectName.Text.Trim().Length > 0)
      {
        this.objProjectMasterDT = this.objProjectMasterBll.GetDataByProjectName(int.Parse(this.hfCompanyID.Value), this.txtProjectName.Text.Trim());
        if (this.objProjectMasterDT.Rows.Count > 0)
        {
          this.checkInDB = true;
          this.DisplayAlert("Project Already Exists..!");
        }
        if (this.checkInDB)
          return;
        Decimal? dPackageRate = new Decimal?();
        Decimal? dFlatAmount = new Decimal?();
        if (this.txtProjectRate.Text.Trim().Length > 0)
          dPackageRate = new Decimal?(Decimal.Parse(this.txtProjectRate.Text.Trim()));
        if (this.txtFlatAmount.Text.Trim().Length > 0)
          dFlatAmount = new Decimal?(Decimal.Parse(this.txtFlatAmount.Text.Trim()));
        int iProjectID = this.objProjectMasterBll.AddProject(int.Parse(this.hfCompanyID.Value), this.txtProjectName.Text.Trim(), this.txtProjectDesc.Text.Trim(), new int?(int.Parse(this.ddlClient.SelectedItem.Value)), this.chkCanClient.Checked, new int?(int.Parse(this.ddlManager.SelectedItem.Value)), this.ddlMethod.SelectedItem.Value, dPackageRate, dFlatAmount, new Decimal?(Decimal.Parse(this.txtTimeEstimate.Text.Trim())), true, false, false, false);
        if (iProjectID != 0)
        {
          if (this.gvUsers.Rows.Count > 0)
          {
            for (int index = 0; index < this.gvUsers.Rows.Count; ++index)
            {
              CheckBox checkBox = (CheckBox) this.gvUsers.Rows[index].Cells[0].FindControl("chkUserID");
              if (checkBox.Checked)
              {
                string cssClass = checkBox.CssClass;
                string toolTip = checkBox.ToolTip;
                switch (cssClass)
                {
                  case "Staff":
                    this.objStaffProjectDetailBll.AddStaffProjectDetail(int.Parse(this.hfCompanyID.Value), int.Parse(toolTip), iProjectID);
                    continue;
                  case "Contractor":
                    this.objContractorProjectDetailBll.AddContractorProjectDetail(int.Parse(this.hfCompanyID.Value), int.Parse(toolTip), iProjectID);
                    continue;
                  case "Admin":
                    this.objProjectMasterBll.UpdateCompanyTeam(true, iProjectID);
                    continue;
                  default:
                    continue;
                }
              }
            }
          }
          if (this.gvTask.Rows.Count > 0)
          {
            for (int index = 0; index < this.gvTask.Rows.Count; ++index)
            {
              CheckBox checkBox = (CheckBox) this.gvTask.Rows[index].Cells[0].FindControl("chkTaskID");
              if (checkBox.Checked)
              {
                string toolTip = checkBox.ToolTip;
                this.objProjectTaskDetailBll.AddProjectTaskDetail(int.Parse(this.hfCompanyID.Value), iProjectID, int.Parse(toolTip));
              }
            }
          }
          this.Session["saveProject"] = (object) 1;
          this.DisplayAlert("Project Successfully Added..!");
          this.Response.Redirect("~/Admin/ProjectMaster.aspx?cmd=add&ID=" + (object) iProjectID);
        }
        else
          this.DisplayAlert("Some Error Occured Please Try After Sometime..!");
      }
      else
        this.DisplayAlert("Project Name Is Required");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.txtProjectName.Text.Trim().Length > 0)
      {
        Decimal? dPackageRate = new Decimal?();
        Decimal? dFlatAmount = new Decimal?();
        if (this.txtProjectRate.Text.Trim().Length > 0)
          dPackageRate = new Decimal?(Decimal.Parse(this.txtProjectRate.Text.Trim()));
        if (this.txtFlatAmount.Text.Trim().Length > 0)
          dFlatAmount = new Decimal?(Decimal.Parse(this.txtFlatAmount.Text.Trim()));
        if (this.objProjectMasterBll.UpdateProject(int.Parse(this.hfProjectID.Value), int.Parse(this.hfCompanyID.Value), this.txtProjectName.Text.Trim(), this.txtProjectDesc.Text.Trim(), new int?(int.Parse(this.ddlClient.SelectedItem.Value)), this.chkCanClient.Checked, new int?(int.Parse(this.ddlManager.SelectedItem.Value)), this.ddlMethod.SelectedItem.Value, dPackageRate, dFlatAmount, new Decimal?(Decimal.Parse(this.txtTimeEstimate.Text.Trim())), true, false, false, false))
        {
          this.objStaffProjectDetailBll.DeleteByProject(int.Parse(this.hfProjectID.Value));
          this.objContractorProjectDetailBll.DeleteByProject(int.Parse(this.hfProjectID.Value));
          this.objProjectTaskDetailBll.DeleteByProject(int.Parse(this.hfProjectID.Value));
          if (this.gvUsers.Rows.Count > 0)
          {
            for (int index = 0; index < this.gvUsers.Rows.Count; ++index)
            {
              CheckBox checkBox = (CheckBox) this.gvUsers.Rows[index].Cells[0].FindControl("chkUserID");
              if (checkBox.Checked)
              {
                string cssClass = checkBox.CssClass;
                string toolTip = checkBox.ToolTip;
                switch (cssClass)
                {
                  case "Staff":
                    this.objStaffProjectDetailBll.AddStaffProjectDetail(int.Parse(this.hfCompanyID.Value), int.Parse(toolTip), int.Parse(this.hfProjectID.Value));
                    continue;
                  case "Contractor":
                    this.objContractorProjectDetailBll.AddContractorProjectDetail(int.Parse(this.hfCompanyID.Value), int.Parse(toolTip), int.Parse(this.hfProjectID.Value));
                    continue;
                  case "Admin":
                    this.objProjectMasterBll.UpdateCompanyTeam(true, int.Parse(this.hfProjectID.Value));
                    continue;
                  default:
                    continue;
                }
              }
            }
          }
          if (this.gvTask.Rows.Count > 0)
          {
            for (int index = 0; index < this.gvTask.Rows.Count; ++index)
            {
              CheckBox checkBox = (CheckBox) this.gvTask.Rows[index].Cells[0].FindControl("chkTaskID");
              if (checkBox.Checked)
                this.objProjectTaskDetailBll.AddProjectTaskDetail(int.Parse(this.hfCompanyID.Value), int.Parse(this.hfProjectID.Value), int.Parse(checkBox.ToolTip));
            }
          }
          this.Session["updateProject"] = (object) 1;
          this.DisplayAlert("Project Successfully Added..!");
          this.Response.Redirect("~/Admin/ProjectMaster.aspx?cmd=add&ID=" + (object) int.Parse(this.hfProjectID.Value));
        }
        else
          this.DisplayAlert("Some Error Occured Please Try After Sometime..!");
      }
      else
        this.DisplayAlert("Project Name Is Required");
    }

    protected void ddlMethod_SelectedIndexChanged(object sender, EventArgs e)
    {
      switch (this.ddlMethod.SelectedValue)
      {
        case "Hourly Project Rate":
          this.hourlyRate.Visible = true;
          this.txtProjectRate.Text = "0.00";
          this.txtProjectRate.Focus();
          this.flatAmount.Visible = false;
          this.txtFlatAmount.Text = "";
          break;
        case "Flat Project Amount":
          this.flatAmount.Visible = true;
          this.txtFlatAmount.Text = "0.00";
          this.txtFlatAmount.Focus();
          this.hourlyRate.Visible = false;
          this.txtProjectRate.Text = "";
          break;
        default:
          this.hourlyRate.Visible = false;
          this.flatAmount.Visible = false;
          this.txtProjectRate.Text = "";
          this.txtFlatAmount.Text = "";
          this.txtTimeEstimate.Text = "0.00";
          this.txtTimeEstimate.Focus();
          break;
      }
    }

    protected void chkTaskAll_CheckedChanged(object sender, EventArgs e)
    {
      CheckBox checkBox = (CheckBox) sender;
      for (int index = 0; index < this.gvTask.Rows.Count; ++index)
        ((CheckBox) this.gvTask.Rows[index].Cells[0].FindControl("chkTaskID")).Checked = checkBox.Checked;
    }

    protected void chkUserAll_CheckedChanged(object sender, EventArgs e)
    {
      CheckBox checkBox = (CheckBox) sender;
      for (int index = 0; index < this.gvUsers.Rows.Count; ++index)
        ((CheckBox) this.gvUsers.Rows[index].Cells[0].FindControl("chkUserID")).Checked = checkBox.Checked;
    }

    protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.chkCanClient.Visible = this.ddlClient.SelectedValue != "0";
    }

    protected void btnArchived_Click(object sender, EventArgs e)
    {
      int num = 0;
      for (int index = 0; index < this.gvProject.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvProject.Rows[index].Cells[0].FindControl("chkID");
        if (checkBox.Checked)
        {
          ++num;
          this.objProjectMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), false, false, true);
        }
      }
      if (num == 0)
        this.DisplayAlert("No items were selected.");
      else
        this.Response.Redirect("ProjectMaster.aspx");
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      int num = 0;
      for (int index = 0; index < this.gvProject.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvProject.Rows[index].Cells[0].FindControl("chkID");
        if (checkBox.Checked)
        {
          ++num;
          this.objProjectMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), false, true, false);
        }
      }
      if (num == 0)
        this.DisplayAlert("No items were selected.");
      else
        this.Response.Redirect("ProjectMaster.aspx?de=true&ac=false");
    }

    protected void btnUnArchived_Click(object sender, EventArgs e)
    {
      int num = 0;
      for (int index = 0; index < this.gvProject.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvProject.Rows[index].Cells[0].FindControl("chkID");
        if (checkBox.Checked)
        {
          ++num;
          this.objProjectMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), true, false, false);
        }
      }
      if (num == 0)
        this.DisplayAlert("No items were selected.");
      else
        this.Response.Redirect("ProjectMaster.aspx?ar=true&ac=false");
    }

    protected void btnUnDelete_Click(object sender, EventArgs e)
    {
      int num = 0;
      for (int index = 0; index < this.gvProject.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvProject.Rows[index].Cells[0].FindControl("chkID");
        if (checkBox.Checked)
        {
          ++num;
          this.objProjectMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), true, false, false);
        }
      }
      if (num == 0)
        this.DisplayAlert("No items were selected.");
      else
        this.Response.Redirect("ProjectMaster.aspx?de=true&ac=false");
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
      this.Response.Redirect("~/Admin/ProjectMaster.aspx?cmd=add&ID=" + ((LinkButton) sender).CommandArgument);
    }

    public void DisplayAlert(string message)
    {
      this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">" + this.GetAlertScript(message) + "</script>");
    }

    public string GetAlertScript(string message)
    {
      return "alert('" + message.Replace("'", "\\'") + "');";
    }

    protected string GetClientName(string cId)
    {
      if (!string.IsNullOrEmpty(cId))
      {
        if (cId == "0")
          return "- internal -";
        this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(cId));
        if (this.objCompanyClientMasterDT.Rows.Count > 0)
          return (string) this.objCompanyClientMasterDT.Rows[0]["OrganizationName"] + (object) " (" + (string) this.objCompanyClientMasterDT.Rows[0]["LastName"] + "," + (string) this.objCompanyClientMasterDT.Rows[0]["FirstName"] + ")";
      }
      return "";
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("ProjectMaster.aspx?cmd=add&ID=" + this.hfProjectID.Value);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
      this.BindGrid();
    }
  }
}

﻿// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.ProjectUserReport
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Drawing;
using System.Globalization;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class ProjectUserReport : Page
  {
    private readonly MiscellaneousMasterBLL objMiscellaneousMasterBll = new MiscellaneousMasterBLL();
    private CloudAccountDA.MiscellaneousMasterDataTable objMiscellaneousMasterDT = new CloudAccountDA.MiscellaneousMasterDataTable();
    private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
    private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
    private readonly ProjectMasterBLL objProjectMasterBll = new ProjectMasterBLL();
    private CloudAccountDA.ProjectMasterDataTable objProjectMasterDT = new CloudAccountDA.ProjectMasterDataTable();
    private readonly TaskMasterBLL objTaskMasterBll = new TaskMasterBLL();
    private CloudAccountDA.TaskMasterDataTable objTaskMasterDT = new CloudAccountDA.TaskMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
    private readonly ReportProjectUserBLL objReportProjectUserBll = new ReportProjectUserBLL();
    private CloudAccountDA.ReportProjectUserDataTable objReportProjectUserDT = new CloudAccountDA.ReportProjectUserDataTable();
    public string dateFormat = "dd/MMM/yyyy";
    protected ToolkitScriptManager tsm;
    protected TextBox txtDateFrom;
    protected CalendarExtender ceDateFrom;
    protected TextBox txtDateTo;
    protected CalendarExtender ceDateTo;
    protected DropDownList ddlTeam;
    protected SqlDataSource sqldsTeam;
    protected Button btnUpdate;
    protected System.Web.UI.WebControls.Image imgLogo;
    protected Label lblCompanyName;
    protected Label lblInfo;
    protected HtmlGenericControl divGrids;
    protected HiddenField hfCompanyID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("reports")).Attributes.Add("class", "active open");
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
        this.imgLogo.ImageUrl = Doyingo.SetCompanyLogo(this.hfCompanyID.Value);
        this.SetMiscValues(this.hfCompanyID.Value);
      }
      if (this.IsPostBack)
        return;
      DateTime dateTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
      DateTime dateTime2 = dateTime1.AddMonths(1).AddDays(-1.0);
      this.txtDateFrom.Text = dateTime1.ToString(this.dateFormat);
      this.txtDateTo.Text = dateTime2.ToString(this.dateFormat);
      this.BindGrid();
    }

    private void SetMiscValues(string companyId)
    {
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(companyId));
      this.lblCompanyName.Text = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
      this.objMiscellaneousMasterDT = this.objMiscellaneousMasterBll.GetDataByCompanyID(int.Parse(companyId));
      if (this.objMiscellaneousMasterDT.Rows.Count <= 0)
        return;
      if (string.IsNullOrEmpty(this.txtDateFrom.Text.Trim()) || string.IsNullOrEmpty(this.txtDateTo.Text.Trim()))
      {
        DateTime dateTime1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        DateTime dateTime2 = dateTime1.AddMonths(1).AddDays(-1.0);
        this.txtDateFrom.Text = dateTime1.ToString(this.dateFormat);
        this.txtDateTo.Text = dateTime2.ToString(this.dateFormat);
      }
      string[] formats = new string[7]
      {
        this.dateFormat,
        "MM/dd/yy",
        "MM/dd/yyyy",
        "dd/MM/yy",
        "dd/MM/yyyy",
        "yy-MM-dd",
        "yyyy-MM-dd"
      };
      this.lblInfo.Text = "Between " + DateTime.ParseExact(this.txtDateFrom.Text, formats, (IFormatProvider) CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("MMMM dd, yyyy") + " and " + DateTime.ParseExact(this.txtDateTo.Text, formats, (IFormatProvider) CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("MMMM dd, yyyy");
    }

    private void BindGrid()
    {
      string[] formats = new string[7]
      {
        this.dateFormat,
        "MM/dd/yy",
        "MM/dd/yyyy",
        "dd/MM/yy",
        "dd/MM/yyyy",
        "yy-MM-dd",
        "yyyy-MM-dd"
      };
      string str = DateTime.ParseExact(this.txtDateFrom.Text, formats, (IFormatProvider) CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("dd/MMM/yy") + " to " + DateTime.ParseExact(this.txtDateTo.Text, formats, (IFormatProvider) CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("dd/MMM/yy");
      if (this.ddlTeam.SelectedIndex > 0)
      {
        string sEntryFor = (string) null;
        DateTime? dtFromDate = new DateTime?();
        DateTime? dtToDate = new DateTime?();
        if (this.ddlTeam.SelectedIndex > 0)
          sEntryFor = this.ddlTeam.SelectedItem.Value;
        if (this.txtDateFrom.Text.Trim().Length > 0)
          dtFromDate = new DateTime?(DateTime.Parse(this.txtDateFrom.Text.Trim()));
        if (this.txtDateTo.Text.Trim().Length > 0)
          dtToDate = new DateTime?(DateTime.Parse(this.txtDateTo.Text.Trim()));
        this.objReportProjectUserDT = this.objReportProjectUserBll.GetData(int.Parse(this.hfCompanyID.Value), sEntryFor, dtFromDate, dtToDate);
        Label label1 = new Label()
        {
          Text = this.ddlTeam.SelectedItem.Text
        };
        label1.Font.Bold = true;
        this.divGrids.Controls.Add((Control) label1);
        Label label2 = new Label()
        {
          Text = str
        };
        label2.Font.Bold = true;
        label2.Attributes.Add("style", "float: right;");
        this.divGrids.Controls.Add((Control) label2);
        this.divGrids.Controls.Add((Control) new LiteralControl("<br />"));
        GridView gridView1 = new GridView();
        gridView1.DataSource = (object) this.objReportProjectUserDT;
        gridView1.CssClass = "reportTable table table-responsive";
        gridView1.Width = Unit.Percentage(100.0);
        gridView1.GridLines = GridLines.None;
        gridView1.EmptyDataText = "No Timesheet entry found";
        GridView gridView2 = gridView1;
        gridView2.HeaderStyle.BackColor = ColorTranslator.FromHtml("#0083E0");
        gridView2.HeaderStyle.ForeColor = Color.White;
        gridView2.RowDataBound += new GridViewRowEventHandler(this.gv_RowDataBound);
        gridView2.DataBind();
        this.divGrids.Controls.Add((Control) gridView2);
        this.divGrids.Controls.Add((Control) new LiteralControl("<br />"));
      }
      else
      {
        this.ddlTeam.DataBind();
        foreach (ListItem listItem in this.ddlTeam.Items)
        {
          if (!string.IsNullOrEmpty(listItem.Value))
          {
            DateTime? dtFromDate = new DateTime?();
            DateTime? dtToDate = new DateTime?();
            string sEntryFor = listItem.Value;
            if (this.txtDateFrom.Text.Trim().Length > 0)
              dtFromDate = new DateTime?(DateTime.Parse(this.txtDateFrom.Text.Trim()));
            if (this.txtDateTo.Text.Trim().Length > 0)
              dtToDate = new DateTime?(DateTime.Parse(this.txtDateTo.Text.Trim()));
            this.objReportProjectUserDT = this.objReportProjectUserBll.GetData(int.Parse(this.hfCompanyID.Value), sEntryFor, dtFromDate, dtToDate);
            Label label1 = new Label()
            {
              Text = listItem.Text
            };
            label1.Font.Bold = true;
            this.divGrids.Controls.Add((Control) label1);
            Label label2 = new Label()
            {
              Text = str
            };
            label2.Font.Bold = true;
            label2.Attributes.Add("style", "float: right;");
            this.divGrids.Controls.Add((Control) label2);
            this.divGrids.Controls.Add((Control) new LiteralControl("<br />"));
            GridView gridView1 = new GridView();
            gridView1.DataSource = (object) this.objReportProjectUserDT;
            gridView1.CssClass = "reportTable table table-responsive";
            gridView1.Width = Unit.Percentage(100.0);
            gridView1.GridLines = GridLines.None;
            gridView1.EmptyDataText = "No Timesheet entry found";
            GridView gridView2 = gridView1;
            gridView2.HeaderStyle.BackColor = ColorTranslator.FromHtml("#0083E0");
            gridView2.HeaderStyle.ForeColor = Color.White;
            gridView2.RowDataBound += new GridViewRowEventHandler(this.gv_RowDataBound);
            gridView2.DataBind();
            this.divGrids.Controls.Add((Control) gridView2);
            this.divGrids.Controls.Add((Control) new LiteralControl("<br />"));
          }
        }
      }
    }

    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType != DataControlRowType.DataRow)
        return;
      this.objProjectMasterDT = this.objProjectMasterBll.GetDataByProjectID(int.Parse(e.Row.Cells[0].Text));
      e.Row.Cells[0].Text = this.objProjectMasterDT.Rows[0]["ProjectName"].ToString();
      this.objTaskMasterDT = this.objTaskMasterBll.GetDataByTaskID(int.Parse(e.Row.Cells[1].Text));
      e.Row.Cells[1].Text = this.objTaskMasterDT.Rows[0]["TaskName"].ToString();
    }

    protected void BtnUpdateClick(object sender, EventArgs e)
    {
      this.BindGrid();
    }
  }
}

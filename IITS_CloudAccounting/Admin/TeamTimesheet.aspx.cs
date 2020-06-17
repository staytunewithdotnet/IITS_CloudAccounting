// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.TeamTimesheet
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
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
  public class TeamTimesheet : Page
  {
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
    private readonly TaskMasterBLL objTaskMasterBll = new TaskMasterBLL();
    private CloudAccountDA.TaskMasterDataTable objTaskMasterDT = new CloudAccountDA.TaskMasterDataTable();
    private readonly ProjectMasterBLL objProjectMasterBll = new ProjectMasterBLL();
    private CloudAccountDA.ProjectMasterDataTable objProjectMasterDT = new CloudAccountDA.ProjectMasterDataTable();
    private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
    private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
    private readonly string[,] schedDay = new string[13, 32];
    private readonly TeamSummaryBLL objTeamSummaryBll = new TeamSummaryBLL();
    private CloudAccountDA.TeamSummaryDataTable objTeamSummaryDT = new CloudAccountDA.TeamSummaryDataTable();
    protected ToolkitScriptManager tsm;
    protected UpdatePanel upCalander;
    protected Label lblTeamName;
    protected DropDownList ddlTeam;
    protected SqlDataSource sqldsTeam;
    protected DropDownList ddlProject;
    protected SqlDataSource sqldsProject;
    protected TextBox t1;
    protected DropDownList ddlTask;
    protected SqlDataSource sqldsTask;
    protected LinkButton lnkPrevYear;
    protected LinkButton lnkPrevMonth;
    protected Label lblTitle;
    protected LinkButton lnkNextMonth;
    protected LinkButton lnkNextYear;
    protected Calendar Calendar1;
    protected Label lblInformation;
    protected GridView gvTimeSheet;
    protected HtmlGenericControl gridDiv;
    protected Label lblDivDate;
    protected Label lblTotalHours;
    protected ObjectDataSource objdsTimesheet;
    protected HtmlGenericControl divName;
    protected HtmlGenericControl divHoursWeek;
    protected HtmlGenericControl divHoursMonth;
    protected Label lblCurrentWeek;
    protected GridView gvTemp;
    protected ObjectDataSource objdsTemp;
    protected HiddenField hfCompanyID;
    protected HiddenField hfProjectID;
    protected HiddenField hfTaskID;
    protected HiddenField hfStaffID;
    protected GridView gvCurrentWeek;
    protected SqlDataSource sqldsCurrentWeek;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("timeTracking")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("teamTimeSheet")).Attributes.Add("class", "active open");
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
      }
      this.SetPageData();
      if (this.IsPostBack)
        return;
      this.Calendar1.SelectedDate = DateTime.Today;
      this.Calendar1_OnSelectionChanged(sender, e);
    }

    private void SetPageData()
    {
      this.gvCurrentWeek.DataBind();
      if (this.gvCurrentWeek.Rows.Count > 0)
        this.lblCurrentWeek.Text = DateTime.Parse(this.gvCurrentWeek.Rows[0].Cells[0].Text).ToString("MMM dd/yy") + " - " + DateTime.Parse(this.gvCurrentWeek.Rows[0].Cells[1].Text).ToString("MMM dd/yy");
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      string str1 = this.objCompanyMasterDT.Rows[0]["CompanyContactPerson"].ToString();
      StringBuilder stringBuilder1 = new StringBuilder();
      stringBuilder1.Insert(0, str1);
      if (stringBuilder1.Length > 12)
        str1 = stringBuilder1.ToString().Substring(0, 10) + "...";
      string sEntryFor1 = this.objCompanyMasterDT.Rows[0]["CompanyUserName"].ToString();
      this.objTeamSummaryDT = this.objTeamSummaryBll.GetDataByMonth(int.Parse(this.hfCompanyID.Value), sEntryFor1);
      string str2 = "0.00";
      if (this.objTeamSummaryDT.Rows.Count > 0)
        str2 = this.objTeamSummaryDT.Rows[0]["Hours"].ToString();
      this.objTeamSummaryDT = this.objTeamSummaryBll.GetDataByWeek(int.Parse(this.hfCompanyID.Value), sEntryFor1);
      string str3 = "0.00";
      if (this.objTeamSummaryDT.Rows.Count > 0)
        str3 = this.objTeamSummaryDT.Rows[0]["Hours"].ToString();
      Label label1 = new Label();
      label1.ID = "lblNameCmp" + str1;
      label1.Text = str1;
      Label label2 = label1;
      Label label3 = new Label();
      label3.ID = "lblHoursMonthCmp" + str1;
      label3.Text = str2;
      Label label4 = label3;
      Label label5 = new Label();
      label5.ID = "lblHoursWeekCmp" + str1;
      label5.Text = str3;
      Label label6 = label5;
      this.divName.Controls.Add((Control) label2);
      this.divHoursMonth.Controls.Add((Control) label4);
      this.divHoursWeek.Controls.Add((Control) label6);
      this.divName.Controls.Add((Control) new LiteralControl("<BR>"));
      this.divHoursMonth.Controls.Add((Control) new LiteralControl("<BR>"));
      this.divHoursWeek.Controls.Add((Control) new LiteralControl("<BR>"));
      this.objStaffMasterDT = this.objStaffMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objStaffMasterDT.Rows.Count <= 0)
        return;
      for (int index = 0; index < this.objStaffMasterDT.Rows.Count; ++index)
      {
        string sEntryFor2 = this.objStaffMasterDT.Rows[index]["UserName"].ToString();
        string str4 = (string) this.objStaffMasterDT.Rows[index]["FirstName"] + (object) " " + (string) this.objStaffMasterDT.Rows[index]["LastName"];
        StringBuilder stringBuilder2 = new StringBuilder();
        stringBuilder2.Insert(0, str4);
        if (stringBuilder2.Length > 12)
          str4 = stringBuilder2.ToString().Substring(0, 10) + "...";
        this.objTeamSummaryDT = this.objTeamSummaryBll.GetDataByMonth(int.Parse(this.hfCompanyID.Value), sEntryFor2);
        string str5 = "0.00";
        if (this.objTeamSummaryDT.Rows.Count > 0)
          str5 = this.objTeamSummaryDT.Rows[0]["Hours"].ToString();
        this.objTeamSummaryDT = this.objTeamSummaryBll.GetDataByWeek(int.Parse(this.hfCompanyID.Value), sEntryFor2);
        string str6 = "0.00";
        if (this.objTeamSummaryDT.Rows.Count > 0)
          str6 = this.objTeamSummaryDT.Rows[0]["Hours"].ToString();
        Label label7 = new Label();
        label7.ID = "lblNameStaff" + str4;
        label7.Text = str4;
        Label label8 = label7;
        Label label9 = new Label();
        label9.ID = "lblHoursMonthStaff" + str4;
        label9.Text = str5;
        Label label10 = label9;
        Label label11 = new Label();
        label11.ID = "lblHoursWeekStaff" + str4;
        label11.Text = str6;
        Label label12 = label11;
        this.divName.Controls.Add((Control) label8);
        this.divHoursMonth.Controls.Add((Control) label10);
        this.divHoursWeek.Controls.Add((Control) label12);
        this.divName.Controls.Add((Control) new LiteralControl("<BR>"));
        this.divHoursMonth.Controls.Add((Control) new LiteralControl("<BR>"));
        this.divHoursWeek.Controls.Add((Control) new LiteralControl("<BR>"));
      }
    }

    protected void Calendar1_OnSelectionChanged(object sender, EventArgs e)
    {
      this.lblDivDate.Text = this.Calendar1.SelectedDate.ToString("MMMM dd, yyyy");
      this.lblTitle.Text = this.Calendar1.SelectedDate.ToString("MMMM yyyy");
      this.BindGrid();
    }

    protected void lnkPrevYear_Click(object sender, EventArgs e)
    {
      this.Calendar1.TodaysDate = new DateTime(int.Parse(this.Calendar1.SelectedDate.ToString("yyyy")) - 1, int.Parse(this.Calendar1.SelectedDate.ToString("MM")), 1);
      this.Calendar1.SelectedDate = this.Calendar1.TodaysDate;
      this.Calendar1_OnSelectionChanged(sender, e);
    }

    protected void lnkPrevMonth_Click(object sender, EventArgs e)
    {
      int year = int.Parse(this.Calendar1.SelectedDate.ToString("yyyy"));
      int month = int.Parse(this.Calendar1.SelectedDate.ToString("MM")) - 1;
      if (month == 0)
      {
        --year;
        month = 12;
      }
      this.Calendar1.TodaysDate = new DateTime(year, month, 1);
      this.Calendar1.SelectedDate = this.Calendar1.TodaysDate;
      this.Calendar1_OnSelectionChanged(sender, e);
    }

    protected void lnkNextMonth_Click(object sender, EventArgs e)
    {
      int year = int.Parse(this.Calendar1.SelectedDate.ToString("yyyy"));
      int month = int.Parse(this.Calendar1.SelectedDate.ToString("MM")) + 1;
      if (month == 13)
      {
        ++year;
        month = 1;
      }
      this.Calendar1.TodaysDate = new DateTime(year, month, 1);
      this.Calendar1.SelectedDate = this.Calendar1.TodaysDate;
      this.Calendar1_OnSelectionChanged(sender, e);
    }

    protected void lnkNextYear_Click(object sender, EventArgs e)
    {
      this.Calendar1.TodaysDate = new DateTime(int.Parse(this.Calendar1.SelectedDate.ToString("yyyy")) + 1, int.Parse(this.Calendar1.SelectedDate.ToString("MM")), 1);
      this.Calendar1.SelectedDate = this.Calendar1.TodaysDate;
      this.Calendar1_OnSelectionChanged(sender, e);
    }

    public void DisplayAlert(string message)
    {
      this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">" + this.GetAlertScript(message) + "</script>");
    }

    public string GetAlertScript(string message)
    {
      return "alert('" + message.Replace("'", "\\'") + "');";
    }

    protected void gvTimeSheet_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType != DataControlRowType.DataRow)
        return;
      this.objProjectMasterDT = this.objProjectMasterBll.GetDataByProjectID(int.Parse(e.Row.Cells[0].Text));
      if (this.objProjectMasterDT.Rows.Count > 0)
        e.Row.Cells[0].Text = this.objProjectMasterDT.Rows[0]["ProjectName"].ToString();
      this.objTaskMasterDT = this.objTaskMasterBll.GetDataByTaskID(int.Parse(e.Row.Cells[1].Text));
      if (this.objTaskMasterDT.Rows.Count <= 0)
        return;
      e.Row.Cells[1].Text = this.objTaskMasterDT.Rows[0]["TaskName"].ToString();
    }

    private void BindGrid()
    {
      this.lblTeamName.Text = " Whole Team ";
      string str1 = "All Projects";
      string str2 = "All Tasks";
      if (this.ddlTeam.SelectedIndex > 0)
      {
        this.hfStaffID.Value = this.ddlTeam.SelectedItem.Value;
        if (this.ddlTeam.SelectedItem.Text.Contains(","))
        {
          this.hfStaffID.Value = this.hfStaffID.Value.Replace("S", "");
          this.objStaffMasterDT = this.objStaffMasterBll.GetDataByStaffID(int.Parse(this.hfStaffID.Value));
          if (this.objStaffMasterDT.Rows.Count > 0)
          {
            this.hfStaffID.Value = this.objStaffMasterDT.Rows[0]["UserName"].ToString();
            this.lblTeamName.Text = (string) this.objStaffMasterDT.Rows[0]["FirstName"] + (object) " " + (string) this.objStaffMasterDT.Rows[0]["LastName"];
          }
        }
        else
        {
          this.hfStaffID.Value = this.hfStaffID.Value.Replace("C", "");
          this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(this.hfStaffID.Value));
          if (this.objCompanyMasterDT.Rows.Count > 0)
          {
            this.hfStaffID.Value = this.objCompanyMasterDT.Rows[0]["CompanyUserName"].ToString();
            this.lblTeamName.Text = this.objCompanyMasterDT.Rows[0]["CompanyContactPerson"].ToString();
          }
        }
      }
      else
        this.hfStaffID.Value = "";
      if (this.ddlProject.SelectedIndex > 0)
      {
        this.hfProjectID.Value = this.ddlProject.SelectedItem.Value;
        str1 = this.ddlProject.SelectedItem.Text;
      }
      else
        this.hfProjectID.Value = "";
      if (this.ddlTask.SelectedIndex > 0)
      {
        this.hfTaskID.Value = this.ddlTask.SelectedItem.Value;
        str2 = this.ddlTask.SelectedItem.Text;
      }
      else
        this.hfTaskID.Value = "";
      this.objdsTimesheet.DataBind();
      this.gvTimeSheet.DataBind();
      this.gridDiv.Visible = this.gvTimeSheet.Rows.Count > 0;
      this.CountHours();
      this.gvTemp.DataBind();
      if (this.gvTemp.Rows.Count > 0)
      {
        for (int index = 0; index < this.gvTemp.Rows.Count; ++index)
        {
          string s1 = DateTime.Parse(this.gvTemp.Rows[index].Cells[1].Text).ToString("dd");
          string s2 = DateTime.Parse(this.gvTemp.Rows[index].Cells[1].Text).ToString("MM");
          string text = this.gvTemp.Rows[index].Cells[0].Text;
          this.schedDay[int.Parse(s2), int.Parse(s1)] = text;
        }
      }
      this.lblInformation.Text = this.Calendar1.SelectedDate.ToString("MMMM dd, yyyy") + " - " + str1 + " - " + str2;
    }

    private void CountHours()
    {
      if (this.gvTimeSheet.Rows.Count > 0)
      {
        Decimal d = new Decimal(0);
        for (int index = 0; index < this.gvTimeSheet.Rows.Count; ++index)
        {
          Decimal num = Decimal.Parse(this.gvTimeSheet.Rows[index].Cells[3].Text);
          d += num;
        }
        this.lblTotalHours.Text = Decimal.Round(d, 2).ToString();
      }
      else
        this.lblTotalHours.Text = "0.00";
    }

    protected void lnkEdit_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("Timesheet.aspx?cmd=add&ID=" + ((LinkButton) sender).CommandArgument);
    }

    protected void ddlTask_OnSelectedIndexChanged(object sender, EventArgs e)
    {
      this.BindGrid();
    }

    protected void ddlProject_OnSelectedIndexChanged(object sender, EventArgs e)
    {
      this.BindGrid();
    }

    protected void ddlTeam_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.BindGrid();
    }

    protected void Calendar1_OnDayRender(object sender, DayRenderEventArgs e)
    {
      CalendarDay day = e.Day;
      TableCell cell = e.Cell;
      if (!day.IsOtherMonth)
      {
        string str = this.schedDay[day.Date.Month, day.Date.Day];
        if (str != null)
        {
          Label label1 = new Label();
          label1.ID = "lbl" + str;
          Label label2 = label1;
          label2.Attributes.Add("style", "background-color: #fff4d6;float: right;color: black;padding-left: 10px;");
          label2.Text = str;
          cell.Controls.Add((Control) new LiteralControl("<BR>"));
          cell.Controls.Add((Control) label2);
        }
      }
      if (!e.Day.IsOtherMonth)
        return;
      e.Cell.Enabled = false;
    }
  }
}

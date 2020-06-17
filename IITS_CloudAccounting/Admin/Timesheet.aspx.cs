// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.Timesheet
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class Timesheet : Page
  {
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly TimesheetMasterBLL objTimesheetMasterBll = new TimesheetMasterBLL();
    private CloudAccountDA.TimesheetMasterDataTable objTimesheetMasterDT = new CloudAccountDA.TimesheetMasterDataTable();
    private readonly ProjectMasterBLL objProjectMasterBll = new ProjectMasterBLL();
    private CloudAccountDA.ProjectMasterDataTable objProjectMasterDT = new CloudAccountDA.ProjectMasterDataTable();
    private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
    private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
    private readonly TaskMasterBLL objTaskMasterBll = new TaskMasterBLL();
    private CloudAccountDA.TaskMasterDataTable objTaskMasterDT = new CloudAccountDA.TaskMasterDataTable();
    private readonly string[,] schedDay = new string[13, 32];
    private static DateTime startOfWeek;
    private static DateTime endOfWeek;
    protected ToolkitScriptManager tsm;
    protected UpdatePanel upButton;
    protected Button btnMonthly;
    protected Button btnWeekly;
    protected Button btnDaily;
    protected UpdatePanel upCalander;
    protected Panel pnlMonthly;
    protected LinkButton lnkPrevYear;
    protected LinkButton lnkPrevMonth;
    protected Label lblTitle;
    protected LinkButton lnkNextMonth;
    protected LinkButton lnkNextYear;
    protected Calendar Calendar1;
    protected Label lblDate;
    protected Label lblTime;
    protected RequiredFieldValidator rfvProject;
    protected DropDownList ddlProject;
    protected SqlDataSource sqldsProject;
    protected SqlDataSource sqldsProjectStaff;
    protected RequiredFieldValidator rfvTask;
    protected DropDownList ddlTask;
    protected SqlDataSource sqldsTask;
    protected TextBox txtHours;
    protected TextBox txtNotes;
    protected HtmlGenericControl btnsa;
    protected Button btnSave;
    protected HtmlGenericControl btnup;
    protected Button btnUpdate;
    protected LinkButton lnkCancel;
    protected Panel pnlWeekly;
    protected LinkButton lnkPrevYear1;
    protected LinkButton lnkPrevMonth1;
    protected Label lblTitle1;
    protected LinkButton lnkNextMonth1;
    protected LinkButton lnkNextYear1;
    protected GridView gvWeeklyTime;
    protected Button btnAdd;
    protected Button btnSave3;
    protected Panel pnlDaily;
    protected LinkButton lnkPrevYear2;
    protected LinkButton lnkPrevMonth2;
    protected Label lblTitle2;
    protected LinkButton lnkNextMonth2;
    protected LinkButton lnkNextYear2;
    protected Calendar Calendar2;
    protected Label lblDate2;
    protected RequiredFieldValidator rfvProject2;
    protected DropDownList ddlProject2;
    protected SqlDataSource sqldsProject2;
    protected SqlDataSource sqldsProjectStaff2;
    protected RequiredFieldValidator rfvTask2;
    protected DropDownList ddlTask2;
    protected SqlDataSource sqldsTask2;
    protected TextBox txtHours2;
    protected TextBox txtNotes2;
    protected Button btnSave2;
    protected Button btnDelete;
    protected Button btnMarkBill;
    protected Button btnMarkUnBill;
    protected GridView gvTimeSheet;
    protected HtmlGenericControl gridDiv;
    protected Label lblBilledHours;
    protected Label lblUnbilledHours;
    protected Label lblDivDate;
    protected Label lblDivDate1;
    protected Label lblTotalHours;
    protected ObjectDataSource objdsTimesheet;
    protected ObjectDataSource objdsTimesheetRange;
    protected HiddenField hfTimesheetID;
    protected GridView gvTemp;
    protected SqlDataSource sqldsTemp;
    protected HiddenField hfCompanyID;
    protected HiddenField hfStaffID;
    protected HiddenField hfEntryFor;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("timeTracking")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("timeSheet")).Attributes.Add("class", "active open");
      MembershipUser user = Membership.GetUser();
      if (user != null)
      {
        string str = user.ToString();
        this.hfEntryFor.Value = user.ToString();
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
            this.hfCompanyID.Value = this.objStaffMasterDT.Rows[0]["CompanyID"].ToString();
            this.hfStaffID.Value = this.objStaffMasterDT.Rows[0]["StaffID"].ToString();
          }
        }
      }
      if (this.IsPostBack)
        return;
      if (this.Request.QueryString["cmd"] != null && this.Request.QueryString["ID"] != null)
      {
        this.SetRecord(this.Request.QueryString["ID"]);
      }
      else
      {
        this.Calendar1.SelectedDate = DateTime.Today;
        this.Calendar2.SelectedDate = DateTime.Today;
        this.BindDropDown();
        this.Calendar1_OnSelectionChanged(sender, e);
        this.Calendar2_OnSelectionChanged(sender, e);
        Timesheet.startOfWeek = DateTime.Today.AddDays((double) (-1 * (int) DateTime.Today.DayOfWeek));
        Timesheet.endOfWeek = Timesheet.startOfWeek.AddDays(6.0);
        this.lblTitle1.Text = Timesheet.startOfWeek.ToString("MMMM dd") + " - " + Timesheet.endOfWeek.ToString("MMMM dd, yyyy");
        this.FirstGridViewRow();
      }
    }

    private void FirstGridViewRow()
    {
      DataTable dataTable = new DataTable();
      dataTable.Columns.Add(new DataColumn("Project", typeof (string)));
      dataTable.Columns.Add(new DataColumn("Task", typeof (string)));
      dataTable.Columns.Add(new DataColumn("Col1", typeof (string)));
      dataTable.Columns.Add(new DataColumn("Col2", typeof (string)));
      dataTable.Columns.Add(new DataColumn("Col3", typeof (string)));
      dataTable.Columns.Add(new DataColumn("Col4", typeof (string)));
      dataTable.Columns.Add(new DataColumn("Col5", typeof (string)));
      dataTable.Columns.Add(new DataColumn("Col6", typeof (string)));
      dataTable.Columns.Add(new DataColumn("Col7", typeof (string)));
      DataRow row = dataTable.NewRow();
      row["Project"] = (object) string.Empty;
      row["Task"] = (object) string.Empty;
      row["Col1"] = (object) string.Empty;
      row["Col2"] = (object) string.Empty;
      row["Col3"] = (object) string.Empty;
      row["Col4"] = (object) string.Empty;
      row["Col5"] = (object) string.Empty;
      row["Col6"] = (object) string.Empty;
      row["Col7"] = (object) string.Empty;
      dataTable.Rows.Add(row);
      this.ViewState["WeeklyTime"] = (object) dataTable;
      this.gvWeeklyTime.DataSource = (object) dataTable;
      this.gvWeeklyTime.DataBind();
      this.gvWeeklyTime.Rows[0].Cells[0].FindControl("ddlProject1").Focus();
    }

    private void BindGrid()
    {
      this.objdsTimesheet.SelectMethod = "GetDataByCompanyIDANDEntryForWithDate";
      this.objdsTimesheet.SelectParameters.Clear();
      this.objdsTimesheet.SelectParameters.Add("CompanyID", DbType.String, this.hfCompanyID.Value);
      this.objdsTimesheet.SelectParameters.Add("EntryFor", DbType.String, this.hfEntryFor.Value);
      this.objdsTimesheet.SelectParameters.Add("TimesheetDate", DbType.DateTime, this.pnlDaily.Visible ? this.Calendar2.SelectedDate.ToString() : this.Calendar1.SelectedDate.ToString());
      this.objdsTimesheet.DataBind();
      this.objdsTimesheetRange.SelectMethod = "GetDataByCompanyIDANDEntryForWithDateRange";
      this.objdsTimesheetRange.SelectParameters.Clear();
      this.objdsTimesheetRange.SelectParameters.Add("CompanyID", DbType.String, this.hfCompanyID.Value);
      this.objdsTimesheetRange.SelectParameters.Add("EntryFor", DbType.String, this.hfEntryFor.Value);
      this.objdsTimesheetRange.SelectParameters.Add("FromDate", DbType.DateTime, Timesheet.startOfWeek.ToString());
      this.objdsTimesheetRange.SelectParameters.Add("ToDate", DbType.DateTime, Timesheet.endOfWeek.ToString());
      this.objdsTimesheetRange.DataBind();
      this.gvTimeSheet.DataSource = this.pnlWeekly.Visible ? (object) this.objdsTimesheetRange : (object) this.objdsTimesheet;
      if (this.pnlWeekly.Visible)
        this.lblDivDate1.Text = this.lblTitle1.Text;
      this.lblDivDate1.Visible = this.pnlWeekly.Visible;
      this.lblDivDate.Visible = !this.pnlWeekly.Visible;
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
      if (this.ViewState["WeeklyTime"] == null)
        return;
      this.gvWeeklyTime.DataSource = this.ViewState["WeeklyTime"];
      this.gvWeeklyTime.DataBind();
    }

    private void CountHours()
    {
      if (this.gvTimeSheet.Rows.Count > 0)
      {
        Decimal d1 = new Decimal(0);
        Decimal d2 = new Decimal(0);
        for (int index = 0; index < this.gvTimeSheet.Rows.Count; ++index)
        {
          Decimal num = Decimal.Parse(this.gvTimeSheet.Rows[index].Cells[4].Text);
          switch (((WebControl) this.gvTimeSheet.Rows[index].Cells[0].FindControl("chkID")).CssClass)
          {
            case "billed":
              d1 += num;
              break;
            case "unbilled":
              d2 += num;
              break;
          }
        }
        Decimal d3 = d1 + d2;
        this.lblBilledHours.Text = Decimal.Round(d1, 2).ToString();
        this.lblUnbilledHours.Text = Decimal.Round(d2, 2).ToString();
        this.lblTotalHours.Text = Decimal.Round(d3, 2).ToString();
      }
      else
        this.lblBilledHours.Text = this.lblUnbilledHours.Text = this.lblTotalHours.Text = "0.00";
    }

    private void BindDropDown()
    {
      MembershipUser user = Membership.GetUser();
      if (user != null)
      {
        string username = user.ToString();
        if (Roles.IsUserInRole(username, "Admin"))
        {
          this.ddlProject.DataSource = (object) this.sqldsProject;
          this.ddlProject2.DataSource = (object) this.sqldsProject2;
        }
        else if (Roles.IsUserInRole(username, "Employee"))
        {
          this.ddlProject.DataSource = (object) this.sqldsProjectStaff;
          this.ddlProject2.DataSource = (object) this.sqldsProjectStaff2;
        }
      }
      this.ddlProject.DataBind();
      this.ddlProject2.DataBind();
      this.BindGrid();
      foreach (ListItem listItem in this.ddlProject.Items)
      {
        if (listItem.Value == "-1")
        {
          listItem.Attributes.Add("style", "color: #0D83DE;font-size: 18px;");
          listItem.Attributes.Add("Disabled", "true");
        }
      }
      if (this.Session["project"] != null && !string.IsNullOrEmpty(this.Session["project"].ToString()))
        this.ddlProject.SelectedValue = this.Session["project"].ToString();
      foreach (ListItem listItem in this.ddlProject2.Items)
      {
        if (listItem.Value == "-1")
        {
          listItem.Attributes.Add("style", "color: #0D83DE;font-size: 18px;");
          listItem.Attributes.Add("Disabled", "true");
        }
      }
      if (this.Session["project2"] == null || string.IsNullOrEmpty(this.Session["project2"].ToString()))
        return;
      this.ddlProject2.SelectedValue = this.Session["project2"].ToString();
    }

    protected void Calendar1_OnSelectionChanged(object sender, EventArgs e)
    {
      this.lblDate.Text = this.Calendar1.SelectedDate.ToString("MMMM dd, yyyy");
      this.lblDivDate.Text = this.Calendar1.SelectedDate.ToString("MMMM dd, yyyy");
      this.gvTimeSheet.EmptyDataText = "No hours logged on for " + this.Calendar1.SelectedDate.ToString("MMMM dd, yyyy");
      this.lblTitle.Text = this.Calendar1.SelectedDate.ToString("MMMM yyyy");
      this.BindDropDown();
    }

    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
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

    protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
    {
      CalendarDay day = e.Day;
      TableCell cell = e.Cell;
      if (!day.IsOtherMonth && this.schedDay[day.Date.Month, day.Date.Day] != null)
        cell.Font.Bold = true;
      if (!e.Day.IsOtherMonth)
        return;
      e.Cell.Enabled = false;
    }

    protected void lnkPrevYear_Click(object sender, EventArgs e)
    {
      this.Calendar1.TodaysDate = new DateTime(int.Parse(this.Calendar1.SelectedDate.ToString("yyyy")) - 1, int.Parse(this.Calendar1.SelectedDate.ToString("MM")), 1);
      this.Calendar1.SelectedDate = this.Calendar1.TodaysDate;
      this.Calendar1_OnSelectionChanged(sender, e);
      this.BindDropDown();
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
      this.BindDropDown();
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
      this.BindDropDown();
    }

    protected void lnkNextYear_Click(object sender, EventArgs e)
    {
      this.Calendar1.TodaysDate = new DateTime(int.Parse(this.Calendar1.SelectedDate.ToString("yyyy")) + 1, int.Parse(this.Calendar1.SelectedDate.ToString("MM")), 1);
      this.Calendar1.SelectedDate = this.Calendar1.TodaysDate;
      this.Calendar1_OnSelectionChanged(sender, e);
      this.BindDropDown();
    }

    protected void lnkPrevYear1_Click(object sender, EventArgs e)
    {
      Timesheet.startOfWeek = Timesheet.startOfWeek.AddDays(-28.0);
      Timesheet.endOfWeek = Timesheet.startOfWeek.AddDays(6.0);
      this.lblTitle1.Text = Timesheet.startOfWeek.ToString("MMMM dd") + " - " + Timesheet.endOfWeek.ToString("MMMM dd, yyyy");
      this.BindDropDown();
    }

    protected void lnkPrevMonth1_Click(object sender, EventArgs e)
    {
      Timesheet.startOfWeek = Timesheet.startOfWeek.AddDays(-7.0);
      Timesheet.endOfWeek = Timesheet.startOfWeek.AddDays(6.0);
      this.lblTitle1.Text = Timesheet.startOfWeek.ToString("MMMM dd") + " - " + Timesheet.endOfWeek.ToString("MMMM dd, yyyy");
      this.BindDropDown();
    }

    protected void lnkNextMonth1_Click(object sender, EventArgs e)
    {
      Timesheet.startOfWeek = Timesheet.startOfWeek.AddDays(7.0);
      Timesheet.endOfWeek = Timesheet.startOfWeek.AddDays(6.0);
      this.lblTitle1.Text = Timesheet.startOfWeek.ToString("MMMM dd") + " - " + Timesheet.endOfWeek.ToString("MMMM dd, yyyy");
      this.BindDropDown();
    }

    protected void lnkNextYear1_Click(object sender, EventArgs e)
    {
      Timesheet.startOfWeek = Timesheet.startOfWeek.AddDays(28.0);
      Timesheet.endOfWeek = Timesheet.startOfWeek.AddDays(6.0);
      this.lblTitle1.Text = Timesheet.startOfWeek.ToString("MMMM dd") + " - " + Timesheet.endOfWeek.ToString("MMMM dd, yyyy");
      this.BindDropDown();
    }

    protected void Calendar2_OnSelectionChanged(object sender, EventArgs e)
    {
      this.lblDate2.Text = this.Calendar2.SelectedDate.ToString("MMMM dd, yyyy");
      this.lblDivDate.Text = this.Calendar2.SelectedDate.ToString("MMMM dd, yyyy");
      this.lblTitle2.Text = this.Calendar2.SelectedDate.ToString("MMMM yyyy");
      this.BindDropDown();
    }

    protected void lnkPrevYear2_Click(object sender, EventArgs e)
    {
      this.Calendar2.TodaysDate = new DateTime(int.Parse(this.Calendar2.SelectedDate.ToString("yyyy")) - 1, int.Parse(this.Calendar2.SelectedDate.ToString("MM")), 1);
      this.Calendar2.SelectedDate = this.Calendar2.TodaysDate;
      this.Calendar2_OnSelectionChanged(sender, e);
      this.BindDropDown();
    }

    protected void lnkPrevMonth2_Click(object sender, EventArgs e)
    {
      int year = int.Parse(this.Calendar2.SelectedDate.ToString("yyyy"));
      int month = int.Parse(this.Calendar2.SelectedDate.ToString("MM")) - 1;
      if (month == 0)
      {
        --year;
        month = 12;
      }
      this.Calendar2.TodaysDate = new DateTime(year, month, 1);
      this.Calendar2.SelectedDate = this.Calendar2.TodaysDate;
      this.Calendar2_OnSelectionChanged(sender, e);
      this.BindDropDown();
    }

    protected void lnkNextMonth2_Click(object sender, EventArgs e)
    {
      int year = int.Parse(this.Calendar2.SelectedDate.ToString("yyyy"));
      int month = int.Parse(this.Calendar2.SelectedDate.ToString("MM")) + 1;
      if (month == 13)
      {
        ++year;
        month = 1;
      }
      this.Calendar2.TodaysDate = new DateTime(year, month, 1);
      this.Calendar2.SelectedDate = this.Calendar2.TodaysDate;
      this.Calendar2_OnSelectionChanged(sender, e);
      this.BindDropDown();
    }

    protected void lnkNextYear2_Click(object sender, EventArgs e)
    {
      this.Calendar2.TodaysDate = new DateTime(int.Parse(this.Calendar2.SelectedDate.ToString("yyyy")) + 1, int.Parse(this.Calendar2.SelectedDate.ToString("MM")), 1);
      this.Calendar2.SelectedDate = this.Calendar2.TodaysDate;
      this.Calendar2_OnSelectionChanged(sender, e);
      this.BindDropDown();
    }

    protected void ddlProject_OnSelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.ddlProject.SelectedIndex > 0)
      {
        this.Session["project"] = (object) this.ddlProject.SelectedItem.Value;
        this.ddlTask.Focus();
      }
      else
      {
        this.Session["project"] = (object) "";
        this.ddlProject.Focus();
      }
      this.BindDropDown();
    }

    private void Clear()
    {
      this.Session["project"] = (object) "";
      this.BindDropDown();
      this.txtHours.Text = this.txtNotes.Text = "";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.ddlProject.SelectedIndex > 0 && this.ddlTask.SelectedIndex > 0)
      {
        Decimal? dHours = new Decimal?();
        if (this.txtHours.Text.Trim().Length > 0)
          dHours = new Decimal?(Decimal.Parse(this.txtHours.Text.Trim()));
        string[] rolesForUser = Roles.GetRolesForUser(HttpContext.Current.User.Identity.Name);
        if (this.objTimesheetMasterBll.AddTimesheet(int.Parse(this.hfCompanyID.Value), new DateTime?(this.Calendar1.SelectedDate), int.Parse(this.ddlProject.SelectedItem.Value), int.Parse(this.ddlTask.SelectedItem.Value), dHours, this.txtNotes.Text.Trim(), false, true, HttpContext.Current.User.Identity.Name, rolesForUser[0], HttpContext.Current.User.Identity.Name, new DateTime?(DateTime.Now)) != 0)
        {
          this.Clear();
          this.DisplayAlert("Entry Successfully done");
          this.Calendar1_OnSelectionChanged(sender, e);
        }
        else
          this.DisplayAlert("Not inserted please try after some time");
      }
      else
        this.DisplayAlert("Please Fill All Required Fields..!");
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
      this.objProjectMasterDT = this.objProjectMasterBll.GetDataByProjectID(int.Parse(e.Row.Cells[1].Text));
      if (this.objProjectMasterDT.Rows.Count > 0)
        e.Row.Cells[1].Text = this.objProjectMasterDT.Rows[0]["ProjectName"].ToString();
      this.objTaskMasterDT = this.objTaskMasterBll.GetDataByTaskID(int.Parse(e.Row.Cells[2].Text));
      if (this.objTaskMasterDT.Rows.Count <= 0)
        return;
      e.Row.Cells[2].Text = this.objTaskMasterDT.Rows[0]["TaskName"].ToString();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      int num = 0;
      for (int index = 0; index < this.gvTimeSheet.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvTimeSheet.Rows[index].Cells[0].FindControl("chkID");
        if (checkBox.Checked)
        {
          ++num;
          this.objTimesheetMasterBll.DeleteTimesheet(int.Parse(checkBox.ToolTip));
        }
      }
      if (num == 0)
      {
        this.DisplayAlert("No items were selected.");
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('No items were selected.')", true);
      }
      else
      {
        this.Clear();
        this.Calendar1.SelectedDate = this.Calendar1.SelectedDate;
        this.Calendar1_OnSelectionChanged(sender, e);
        this.BindDropDown();
      }
    }

    protected void btnMarkBill_Click(object sender, EventArgs e)
    {
      int num = 0;
      for (int index = 0; index < this.gvTimeSheet.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvTimeSheet.Rows[index].Cells[0].FindControl("chkID");
        if (checkBox.Checked)
        {
          ++num;
          this.objTimesheetMasterBll.UpdateBillValue(int.Parse(checkBox.ToolTip), true, false);
        }
      }
      if (num == 0)
      {
        this.DisplayAlert("No items were selected.");
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('No items were selected.')", true);
      }
      else
      {
        this.Clear();
        this.Calendar1.SelectedDate = this.Calendar1.SelectedDate;
        this.Calendar1_OnSelectionChanged(sender, e);
        this.BindDropDown();
      }
    }

    protected void btnMarkUnBill_Click(object sender, EventArgs e)
    {
      int num = 0;
      for (int index = 0; index < this.gvTimeSheet.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvTimeSheet.Rows[index].Cells[0].FindControl("chkID");
        if (checkBox.Checked)
        {
          ++num;
          this.objTimesheetMasterBll.UpdateBillValue(int.Parse(checkBox.ToolTip), false, true);
        }
      }
      if (num == 0)
      {
        this.DisplayAlert("No items were selected.");
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('No items were selected.')", true);
      }
      else
      {
        this.Clear();
        this.Calendar1.SelectedDate = this.Calendar1.SelectedDate;
        this.Calendar1_OnSelectionChanged(sender, e);
        this.BindDropDown();
      }
    }

    protected void lnkEdit_Click(object sender, EventArgs e)
    {
      this.btnMonthly_OnClick(sender, e);
      this.SetRecord(((LinkButton) sender).CommandArgument);
    }

    private void SetRecord(string timeId)
    {
      this.objTimesheetMasterDT = this.objTimesheetMasterBll.GetDataByTimesheetID(int.Parse(timeId));
      if (this.objTimesheetMasterDT.Rows.Count <= 0)
        return;
      this.btnsa.Visible = false;
      this.btnup.Visible = true;
      this.hfCompanyID.Value = this.objTimesheetMasterDT.Rows[0]["CompanyID"].ToString();
      this.lblTime.Text = this.hfTimesheetID.Value = this.objTimesheetMasterDT.Rows[0]["TimesheetID"].ToString();
      this.txtHours.Text = this.objTimesheetMasterDT.Rows[0]["Hours"].ToString();
      this.txtNotes.Text = this.objTimesheetMasterDT.Rows[0]["Notes"].ToString();
      this.Calendar1.SelectedDate = DateTime.Parse(this.objTimesheetMasterDT.Rows[0]["TimesheetDate"].ToString());
      this.Calendar1_OnSelectionChanged((object) null, (EventArgs) null);
      string str1 = this.objTimesheetMasterDT.Rows[0]["ProjectID"].ToString();
      string str2 = this.objTimesheetMasterDT.Rows[0]["TaskID"].ToString();
      if (!string.IsNullOrEmpty(str1))
      {
        this.ddlProject.SelectedValue = str1;
        this.Session["project"] = (object) str1;
      }
      if (string.IsNullOrEmpty(str2))
        return;
      this.ddlTask.Items.Add(str2);
      this.ddlTask.SelectedValue = str2;
    }

    protected void lnkCancel_OnClick(object sender, EventArgs e)
    {
      this.btnsa.Visible = true;
      this.btnup.Visible = false;
      this.Clear();
      this.Calendar1.SelectedDate = DateTime.Today;
      this.Calendar1_OnSelectionChanged(sender, e);
      this.BindDropDown();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (!string.IsNullOrEmpty(this.lblTime.Text) && this.ddlProject.SelectedIndex > 0 && this.ddlTask.SelectedIndex > 0)
      {
        this.hfTimesheetID.Value = this.lblTime.Text;
        this.objTimesheetMasterDT = this.objTimesheetMasterBll.GetDataByTimesheetID(int.Parse(this.hfTimesheetID.Value));
        string sEntryFor = this.objTimesheetMasterDT.Rows[0]["EntryFor"].ToString();
        string sEntryForRole = this.objTimesheetMasterDT.Rows[0]["EntryForRole"].ToString();
        string sEntryBy = this.objTimesheetMasterDT.Rows[0]["EntryBy"].ToString();
        DateTime dateTime = DateTime.Parse(this.objTimesheetMasterDT.Rows[0]["EntryDate"].ToString());
        Decimal? dHours = new Decimal?();
        if (this.txtHours.Text.Trim().Length > 0)
          dHours = new Decimal?(Decimal.Parse(this.txtHours.Text.Trim()));
        if (this.objTimesheetMasterBll.UpdateTimesheet(int.Parse(this.hfTimesheetID.Value), int.Parse(this.hfCompanyID.Value), new DateTime?(this.Calendar1.SelectedDate), int.Parse(this.ddlProject.SelectedItem.Value), int.Parse(this.ddlTask.SelectedItem.Value), dHours, this.txtNotes.Text.Trim(), false, true, sEntryFor, sEntryForRole, sEntryBy, new DateTime?(dateTime)))
        {
          this.btnsa.Visible = true;
          this.btnup.Visible = false;
          this.Clear();
          this.Calendar1.SelectedDate = this.Calendar1.SelectedDate;
          this.Calendar1_OnSelectionChanged(sender, e);
          this.BindDropDown();
        }
        else
          this.DisplayAlert("Not updated please try after some time");
      }
      else
        this.DisplayAlert("Please Fill All Required Fields..!");
    }

    protected void btnMonthly_OnClick(object sender, EventArgs e)
    {
      this.btnMonthly.CssClass = "btn-success";
      this.btnWeekly.CssClass = "btn-primary";
      this.btnDaily.CssClass = "btn-primary";
      this.pnlMonthly.Visible = true;
      this.pnlWeekly.Visible = false;
      this.pnlDaily.Visible = false;
      this.BindDropDown();
    }

    protected void btnWeekly_OnClick(object sender, EventArgs e)
    {
      this.btnMonthly.CssClass = "btn-primary";
      this.btnWeekly.CssClass = "btn-success";
      this.btnDaily.CssClass = "btn-primary";
      this.pnlMonthly.Visible = false;
      this.pnlWeekly.Visible = true;
      this.pnlDaily.Visible = false;
      this.BindDropDown();
    }

    protected void btnDaily_OnClick(object sender, EventArgs e)
    {
      this.btnMonthly.CssClass = "btn-primary";
      this.btnWeekly.CssClass = "btn-primary";
      this.btnDaily.CssClass = "btn-success";
      this.pnlMonthly.Visible = false;
      this.pnlWeekly.Visible = false;
      this.pnlDaily.Visible = true;
      this.BindDropDown();
    }

    protected void btnSave2_OnClick(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.ddlProject2.SelectedIndex > 0 && this.ddlTask2.SelectedIndex > 0)
      {
        Decimal? dHours = new Decimal?();
        if (this.txtHours2.Text.Trim().Length > 0)
          dHours = new Decimal?(Decimal.Parse(this.txtHours2.Text.Trim()));
        string[] rolesForUser = Roles.GetRolesForUser(HttpContext.Current.User.Identity.Name);
        if (this.objTimesheetMasterBll.AddTimesheet(int.Parse(this.hfCompanyID.Value), new DateTime?(this.Calendar2.SelectedDate), int.Parse(this.ddlProject2.SelectedItem.Value), int.Parse(this.ddlTask2.SelectedItem.Value), dHours, this.txtNotes2.Text.Trim(), false, true, HttpContext.Current.User.Identity.Name, rolesForUser[0], HttpContext.Current.User.Identity.Name, new DateTime?(DateTime.Now)) != 0)
        {
          this.Clear();
          this.DisplayAlert("Entry Successfully done");
          this.Calendar2_OnSelectionChanged(sender, e);
        }
        else
          this.DisplayAlert("Not inserted please try after some time");
      }
      else
        this.DisplayAlert("Please Fill All Required Fields..!");
    }

    protected void gvWeeklyTime_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.Header)
      {
        DateTime dateTime = Timesheet.endOfWeek;
        e.Row.Cells[2].Text = "Sat <br />" + dateTime.AddDays(-6.0).ToString("MMM dd");
        e.Row.Cells[3].Text = "Fri <br />" + dateTime.AddDays(-5.0).ToString("MMM dd");
        e.Row.Cells[4].Text = "Thu <br />" + dateTime.AddDays(-4.0).ToString("MMM dd");
        e.Row.Cells[5].Text = "Wed <br />" + dateTime.AddDays(-3.0).ToString("MMM dd");
        e.Row.Cells[6].Text = "Tue <br />" + dateTime.AddDays(-2.0).ToString("MMM dd");
        e.Row.Cells[7].Text = "Mon <br />" + dateTime.AddDays(-1.0).ToString("MMM dd");
        e.Row.Cells[8].Text = "Sun <br />" + dateTime.ToString("MMM dd");
      }
      if (e.Row.RowType != DataControlRowType.DataRow)
        return;
      DropDownList dropDownList = (DropDownList) e.Row.Cells[0].FindControl("ddlProject1");
      SqlDataSource sqlDataSource1 = (SqlDataSource) e.Row.Cells[0].FindControl("sqldsProject1");
      SqlDataSource sqlDataSource2 = (SqlDataSource) e.Row.Cells[0].FindControl("sqldsProjectStaff1");
      dropDownList.DataSource = !string.IsNullOrEmpty(this.hfStaffID.Value) ? (object) sqlDataSource2 : (object) sqlDataSource1;
      dropDownList.DataBind();
    }

    protected void btnSave3_OnClick(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      DateTime dateTime = Timesheet.startOfWeek;
      string name = HttpContext.Current.User.Identity.Name;
      string[] rolesForUser = Roles.GetRolesForUser(name);
      if (this.gvWeeklyTime.Rows.Count <= 0)
        return;
      for (int index = 0; index < this.gvWeeklyTime.Rows.Count; ++index)
      {
        DropDownList dropDownList1 = (DropDownList) this.gvWeeklyTime.Rows[index].Cells[0].FindControl("ddlProject1");
        DropDownList dropDownList2 = (DropDownList) this.gvWeeklyTime.Rows[index].Cells[1].FindControl("ddlTask1");
        TextBox textBox1 = (TextBox) this.gvWeeklyTime.Rows[index].Cells[2].FindControl("txt1");
        TextBox textBox2 = (TextBox) this.gvWeeklyTime.Rows[index].Cells[3].FindControl("txt2");
        TextBox textBox3 = (TextBox) this.gvWeeklyTime.Rows[index].Cells[4].FindControl("txt3");
        TextBox textBox4 = (TextBox) this.gvWeeklyTime.Rows[index].Cells[5].FindControl("txt4");
        TextBox textBox5 = (TextBox) this.gvWeeklyTime.Rows[index].Cells[6].FindControl("txt5");
        TextBox textBox6 = (TextBox) this.gvWeeklyTime.Rows[index].Cells[7].FindControl("txt6");
        TextBox textBox7 = (TextBox) this.gvWeeklyTime.Rows[index].Cells[8].FindControl("txt7");
        if (dropDownList1.SelectedIndex > 0 && dropDownList2.SelectedIndex > 0 && !string.IsNullOrEmpty(textBox1.Text.Trim()))
        {
          Decimal? dHours = new Decimal?(Decimal.Parse(textBox1.Text.Trim()));
          Decimal? nullable = dHours;
          if ((!(nullable.GetValueOrDefault() > new Decimal(0)) ? 0 : (nullable.HasValue ? 1 : 0)) != 0)
            this.objTimesheetMasterBll.AddTimesheet(int.Parse(this.hfCompanyID.Value), new DateTime?(dateTime), int.Parse(dropDownList1.SelectedItem.Value), int.Parse(dropDownList2.SelectedItem.Value), dHours, "", false, true, name, rolesForUser[0], name, new DateTime?(DateTime.Now));
        }
        if (dropDownList1.SelectedIndex > 0 && dropDownList2.SelectedIndex > 0 && !string.IsNullOrEmpty(textBox2.Text.Trim()))
        {
          Decimal? dHours = new Decimal?(Decimal.Parse(textBox2.Text.Trim()));
          Decimal? nullable = dHours;
          if ((!(nullable.GetValueOrDefault() > new Decimal(0)) ? 0 : (nullable.HasValue ? 1 : 0)) != 0)
            this.objTimesheetMasterBll.AddTimesheet(int.Parse(this.hfCompanyID.Value), new DateTime?(dateTime.AddDays(1.0)), int.Parse(dropDownList1.SelectedItem.Value), int.Parse(dropDownList2.SelectedItem.Value), dHours, "", false, true, name, rolesForUser[0], name, new DateTime?(DateTime.Now));
        }
        if (dropDownList1.SelectedIndex > 0 && dropDownList2.SelectedIndex > 0 && !string.IsNullOrEmpty(textBox3.Text.Trim()))
        {
          Decimal? dHours = new Decimal?(Decimal.Parse(textBox3.Text.Trim()));
          Decimal? nullable = dHours;
          if ((!(nullable.GetValueOrDefault() > new Decimal(0)) ? 0 : (nullable.HasValue ? 1 : 0)) != 0)
            this.objTimesheetMasterBll.AddTimesheet(int.Parse(this.hfCompanyID.Value), new DateTime?(dateTime.AddDays(2.0)), int.Parse(dropDownList1.SelectedItem.Value), int.Parse(dropDownList2.SelectedItem.Value), dHours, "", false, true, name, rolesForUser[0], name, new DateTime?(DateTime.Now));
        }
        if (dropDownList1.SelectedIndex > 0 && dropDownList2.SelectedIndex > 0 && !string.IsNullOrEmpty(textBox4.Text.Trim()))
        {
          Decimal? dHours = new Decimal?(Decimal.Parse(textBox4.Text.Trim()));
          Decimal? nullable = dHours;
          if ((!(nullable.GetValueOrDefault() > new Decimal(0)) ? 0 : (nullable.HasValue ? 1 : 0)) != 0)
            this.objTimesheetMasterBll.AddTimesheet(int.Parse(this.hfCompanyID.Value), new DateTime?(dateTime.AddDays(3.0)), int.Parse(dropDownList1.SelectedItem.Value), int.Parse(dropDownList2.SelectedItem.Value), dHours, "", false, true, name, rolesForUser[0], name, new DateTime?(DateTime.Now));
        }
        if (dropDownList1.SelectedIndex > 0 && dropDownList2.SelectedIndex > 0 && !string.IsNullOrEmpty(textBox5.Text.Trim()))
        {
          Decimal? dHours = new Decimal?(Decimal.Parse(textBox5.Text.Trim()));
          Decimal? nullable = dHours;
          if ((!(nullable.GetValueOrDefault() > new Decimal(0)) ? 0 : (nullable.HasValue ? 1 : 0)) != 0)
            this.objTimesheetMasterBll.AddTimesheet(int.Parse(this.hfCompanyID.Value), new DateTime?(dateTime.AddDays(4.0)), int.Parse(dropDownList1.SelectedItem.Value), int.Parse(dropDownList2.SelectedItem.Value), dHours, "", false, true, name, rolesForUser[0], name, new DateTime?(DateTime.Now));
        }
        if (dropDownList1.SelectedIndex > 0 && dropDownList2.SelectedIndex > 0 && !string.IsNullOrEmpty(textBox6.Text.Trim()))
        {
          Decimal? dHours = new Decimal?(Decimal.Parse(textBox6.Text.Trim()));
          Decimal? nullable = dHours;
          if ((!(nullable.GetValueOrDefault() > new Decimal(0)) ? 0 : (nullable.HasValue ? 1 : 0)) != 0)
            this.objTimesheetMasterBll.AddTimesheet(int.Parse(this.hfCompanyID.Value), new DateTime?(dateTime.AddDays(5.0)), int.Parse(dropDownList1.SelectedItem.Value), int.Parse(dropDownList2.SelectedItem.Value), dHours, "", false, true, name, rolesForUser[0], name, new DateTime?(DateTime.Now));
        }
        if (dropDownList1.SelectedIndex > 0 && dropDownList2.SelectedIndex > 0 && !string.IsNullOrEmpty(textBox7.Text.Trim()))
        {
          Decimal? dHours = new Decimal?(Decimal.Parse(textBox7.Text.Trim()));
          Decimal? nullable = dHours;
          if ((!(nullable.GetValueOrDefault() > new Decimal(0)) ? 0 : (nullable.HasValue ? 1 : 0)) != 0)
            this.objTimesheetMasterBll.AddTimesheet(int.Parse(this.hfCompanyID.Value), new DateTime?(dateTime.AddDays(6.0)), int.Parse(dropDownList1.SelectedItem.Value), int.Parse(dropDownList2.SelectedItem.Value), dHours, "", false, true, name, rolesForUser[0], name, new DateTime?(DateTime.Now));
        }
      }
    }

    protected void btnAdd_OnClick(object sender, EventArgs e)
    {
      this.AddNewRow();
    }

    private void AddNewRow()
    {
      int index1 = 0;
      if (this.ViewState["WeeklyTime"] != null)
      {
        DataTable dataTable = (DataTable) this.ViewState["WeeklyTime"];
        DataRow row = (DataRow) null;
        if (dataTable.Rows.Count > 0)
        {
          for (int index2 = 1; index2 <= dataTable.Rows.Count; ++index2)
          {
            DropDownList dropDownList1 = (DropDownList) this.gvWeeklyTime.Rows[index1].Cells[0].FindControl("ddlProject1");
            DropDownList dropDownList2 = (DropDownList) this.gvWeeklyTime.Rows[index1].Cells[1].FindControl("ddlTask1");
            TextBox textBox1 = (TextBox) this.gvWeeklyTime.Rows[index1].Cells[2].FindControl("txt1");
            TextBox textBox2 = (TextBox) this.gvWeeklyTime.Rows[index1].Cells[3].FindControl("txt2");
            TextBox textBox3 = (TextBox) this.gvWeeklyTime.Rows[index1].Cells[4].FindControl("txt3");
            TextBox textBox4 = (TextBox) this.gvWeeklyTime.Rows[index1].Cells[5].FindControl("txt4");
            TextBox textBox5 = (TextBox) this.gvWeeklyTime.Rows[index1].Cells[6].FindControl("txt5");
            TextBox textBox6 = (TextBox) this.gvWeeklyTime.Rows[index1].Cells[7].FindControl("txt6");
            TextBox textBox7 = (TextBox) this.gvWeeklyTime.Rows[index1].Cells[8].FindControl("txt7");
            row = dataTable.NewRow();
            dataTable.Rows[index2 - 1]["Project"] = (object) dropDownList1.SelectedValue;
            dataTable.Rows[index2 - 1]["Task"] = (object) dropDownList2.SelectedValue;
            dataTable.Rows[index2 - 1]["Col1"] = (object) textBox1.Text;
            dataTable.Rows[index2 - 1]["Col2"] = (object) textBox2.Text;
            dataTable.Rows[index2 - 1]["Col3"] = (object) textBox3.Text;
            dataTable.Rows[index2 - 1]["Col4"] = (object) textBox4.Text;
            dataTable.Rows[index2 - 1]["Col5"] = (object) textBox5.Text;
            dataTable.Rows[index2 - 1]["Col6"] = (object) textBox6.Text;
            dataTable.Rows[index2 - 1]["Col7"] = (object) textBox7.Text;
            ++index1;
          }
          if (row != null)
            dataTable.Rows.Add(row);
          this.ViewState["WeeklyTime"] = (object) dataTable;
          this.gvWeeklyTime.DataSource = (object) dataTable;
          this.gvWeeklyTime.DataBind();
          this.gvWeeklyTime.Rows[index1].Cells[0].FindControl("ddlProject1").Focus();
        }
      }
      else
        this.Response.Write("ViewState is null");
      this.SetPreviousData();
    }

    private void SetPreviousData()
    {
      int index1 = 0;
      if (this.ViewState["WeeklyTime"] == null)
        return;
      DataTable dataTable = (DataTable) this.ViewState["WeeklyTime"];
      if (dataTable.Rows.Count <= 0)
        return;
      for (int index2 = 0; index2 < dataTable.Rows.Count; ++index2)
      {
        DropDownList dropDownList1 = (DropDownList) this.gvWeeklyTime.Rows[index1].Cells[0].FindControl("ddlProject1");
        DropDownList dropDownList2 = (DropDownList) this.gvWeeklyTime.Rows[index1].Cells[1].FindControl("ddlTask1");
        TextBox textBox1 = (TextBox) this.gvWeeklyTime.Rows[index1].Cells[2].FindControl("txt1");
        TextBox textBox2 = (TextBox) this.gvWeeklyTime.Rows[index1].Cells[3].FindControl("txt2");
        TextBox textBox3 = (TextBox) this.gvWeeklyTime.Rows[index1].Cells[4].FindControl("txt3");
        TextBox textBox4 = (TextBox) this.gvWeeklyTime.Rows[index1].Cells[5].FindControl("txt4");
        TextBox textBox5 = (TextBox) this.gvWeeklyTime.Rows[index1].Cells[6].FindControl("txt5");
        TextBox textBox6 = (TextBox) this.gvWeeklyTime.Rows[index1].Cells[7].FindControl("txt6");
        TextBox textBox7 = (TextBox) this.gvWeeklyTime.Rows[index1].Cells[8].FindControl("txt7");
        if (!string.IsNullOrEmpty(dataTable.Rows[index2]["Project"].ToString()) && !string.IsNullOrEmpty(dataTable.Rows[index2]["Task"].ToString()))
        {
          dropDownList1.SelectedValue = dataTable.Rows[index2]["Project"].ToString();
          dropDownList2.Items.Add(dataTable.Rows[index2]["Task"].ToString());
          dropDownList2.SelectedValue = dataTable.Rows[index2]["Task"].ToString();
          textBox1.Text = dataTable.Rows[index2]["Col1"].ToString();
          textBox2.Text = dataTable.Rows[index2]["Col2"].ToString();
          textBox3.Text = dataTable.Rows[index2]["Col3"].ToString();
          textBox4.Text = dataTable.Rows[index2]["Col4"].ToString();
          textBox5.Text = dataTable.Rows[index2]["Col5"].ToString();
          textBox6.Text = dataTable.Rows[index2]["Col6"].ToString();
          textBox7.Text = dataTable.Rows[index2]["Col7"].ToString();
        }
        ++index1;
      }
    }
  }
}

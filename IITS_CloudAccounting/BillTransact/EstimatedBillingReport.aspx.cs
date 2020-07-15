// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.EstimatedBillingReport
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
  public class EstimatedBillingReport : Page
  {
    private readonly MiscellaneousMasterBLL objMiscellaneousMasterBll = new MiscellaneousMasterBLL();
    private CloudAccountDA.MiscellaneousMasterDataTable objMiscellaneousMasterDT = new CloudAccountDA.MiscellaneousMasterDataTable();
    private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
    private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
    private readonly ReportEstimatedBillingTeamBLL objReportEstimatedBillingTeamBll = new ReportEstimatedBillingTeamBLL();
    private CloudAccountDA.ReportEstimatedBillingTeamDataTable objReportEstimatedBillingTeamDT = new CloudAccountDA.ReportEstimatedBillingTeamDataTable();
    private readonly ReportEstimatedBillingClientBLL objReportEstimatedBillingClientBll = new ReportEstimatedBillingClientBLL();
    private CloudAccountDA.ReportEstimatedBillingClientDataTable objReportEstimatedBillingClientDT = new CloudAccountDA.ReportEstimatedBillingClientDataTable();
    private readonly ReportEstimatedBillingProjectBLL objReportEstimatedBillingProjectBll = new ReportEstimatedBillingProjectBLL();
    private CloudAccountDA.ReportEstimatedBillingProjectDataTable objReportEstimatedBillingProjectDT = new CloudAccountDA.ReportEstimatedBillingProjectDataTable();
    private readonly ReportEstimatedBillingTaskBLL objReportEstimatedBillingTaskBll = new ReportEstimatedBillingTaskBLL();
    private CloudAccountDA.ReportEstimatedBillingTaskDataTable objReportEstimatedBillingTaskDT = new CloudAccountDA.ReportEstimatedBillingTaskDataTable();
    public string dateFormat = "dd/MMM/yyyy";
    protected ToolkitScriptManager tsm;
    protected TextBox txtDateFrom;
    protected CalendarExtender ceDateFrom;
    protected TextBox txtDateTo;
    protected CalendarExtender ceDateTo;
    protected DropDownList ddlGroupBy;
    protected DropDownList ddlProject;
    protected SqlDataSource sqldsProject;
    protected DropDownList ddlTeam;
    protected SqlDataSource sqldsTeam;
    protected DropDownList ddlBilled;
    protected Button btnUpdate;
    protected System.Web.UI.WebControls.Image imgLogo;
    protected Label lblGroup;
    protected Label lblCompanyName;
    protected Label lblInfo;
    protected HtmlGenericControl divGrids;
    protected HiddenField hfCompanyID;
    protected DropDownList ddlClient;
    protected SqlDataSource sqldsClient;
    protected DropDownList ddlTask;
    protected SqlDataSource sqldsTask;

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
      DateTime now = DateTime.Now;
      this.txtDateFrom.Text = now.AddDays(-30.0).ToString(this.dateFormat);
      this.txtDateTo.Text = now.ToString(this.dateFormat);
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
        DateTime now = DateTime.Now;
        this.txtDateFrom.Text = now.AddDays(-30.0).ToString(this.dateFormat);
        this.txtDateTo.Text = now.ToString(this.dateFormat);
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
      this.lblGroup.Text = " by " + this.ddlGroupBy.SelectedItem.Text;
    }

    private void BindGrid()
    {
      DateTime? dtFromDate = new DateTime?();
      DateTime? dtToDate = new DateTime?();
      bool? bBilled = new bool?();
      if (this.txtDateFrom.Text.Trim().Length > 0)
        dtFromDate = new DateTime?(DateTime.Parse(this.txtDateFrom.Text.Trim()));
      if (this.txtDateTo.Text.Trim().Length > 0)
        dtToDate = new DateTime?(DateTime.Parse(this.txtDateTo.Text.Trim()));
      if (this.ddlBilled.SelectedIndex > 0)
        bBilled = new bool?(bool.Parse(this.ddlBilled.SelectedItem.Value));
      if (this.ddlGroupBy.SelectedItem.Text == "Team")
      {
        int? iProjectID = new int?();
        if (this.ddlProject.SelectedIndex > 0)
          iProjectID = new int?(int.Parse(this.ddlProject.SelectedItem.Value));
        if (this.ddlTeam.SelectedIndex > 0)
        {
          this.objReportEstimatedBillingTeamDT = this.objReportEstimatedBillingTeamBll.GetData(int.Parse(this.hfCompanyID.Value), this.ddlTeam.SelectedItem.Text, iProjectID, bBilled, dtFromDate, dtToDate);
          Label label = new Label()
          {
            Text = this.ddlTeam.SelectedItem.Text
          };
          label.Font.Bold = true;
          this.divGrids.Controls.Add((Control) label);
          this.divGrids.Controls.Add((Control) new LiteralControl("<br />"));
          GridView gridView1 = new GridView();
          gridView1.DataSource = (object) this.objReportEstimatedBillingTeamDT;
          gridView1.CssClass = "reportTable table table-responsive";
          gridView1.Width = Unit.Percentage(100.0);
          gridView1.GridLines = GridLines.None;
          gridView1.EmptyDataText = "No Timesheet entry found";
          GridView gridView2 = gridView1;
          gridView2.HeaderStyle.BackColor = ColorTranslator.FromHtml("#0083E0");
          gridView2.HeaderStyle.ForeColor = Color.White;
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
              this.objReportEstimatedBillingTeamDT = this.objReportEstimatedBillingTeamBll.GetData(int.Parse(this.hfCompanyID.Value), listItem.Value, iProjectID, bBilled, dtFromDate, dtToDate);
              Label label = new Label()
              {
                Text = listItem.Text
              };
              label.Font.Bold = true;
              this.divGrids.Controls.Add((Control) label);
              this.divGrids.Controls.Add((Control) new LiteralControl("<br />"));
              GridView gridView1 = new GridView();
              gridView1.DataSource = (object) this.objReportEstimatedBillingTeamDT;
              gridView1.CssClass = "reportTable table table-responsive";
              gridView1.Width = Unit.Percentage(100.0);
              gridView1.GridLines = GridLines.None;
              gridView1.EmptyDataText = "No Timesheet entry found";
              GridView gridView2 = gridView1;
              gridView2.HeaderStyle.BackColor = ColorTranslator.FromHtml("#0083E0");
              gridView2.HeaderStyle.ForeColor = Color.White;
              gridView2.DataBind();
              this.divGrids.Controls.Add((Control) gridView2);
              this.divGrids.Controls.Add((Control) new LiteralControl("<br />"));
            }
          }
        }
      }
      else if (this.ddlGroupBy.SelectedItem.Text == "Client")
      {
        int? iProjectID = new int?();
        if (this.ddlProject.SelectedIndex > 0)
          iProjectID = new int?(int.Parse(this.ddlProject.SelectedItem.Value));
        this.ddlClient.DataBind();
        foreach (ListItem listItem in this.ddlClient.Items)
        {
          if (!string.IsNullOrEmpty(listItem.Value))
          {
            this.objReportEstimatedBillingClientDT = this.objReportEstimatedBillingClientBll.GetData(int.Parse(this.hfCompanyID.Value), new int?(int.Parse(listItem.Value)), iProjectID, bBilled, dtFromDate, dtToDate);
            Label label = new Label()
            {
              Text = listItem.Text
            };
            label.Font.Bold = true;
            this.divGrids.Controls.Add((Control) label);
            this.divGrids.Controls.Add((Control) new LiteralControl("<br />"));
            GridView gridView1 = new GridView();
            gridView1.DataSource = (object) this.objReportEstimatedBillingClientDT;
            gridView1.CssClass = "reportTable table table-responsive";
            gridView1.Width = Unit.Percentage(100.0);
            gridView1.GridLines = GridLines.None;
            gridView1.EmptyDataText = "No Timesheet entry found";
            GridView gridView2 = gridView1;
            gridView2.HeaderStyle.BackColor = ColorTranslator.FromHtml("#0083E0");
            gridView2.HeaderStyle.ForeColor = Color.White;
            gridView2.DataBind();
            this.divGrids.Controls.Add((Control) gridView2);
            this.divGrids.Controls.Add((Control) new LiteralControl("<br />"));
          }
        }
      }
      else if (this.ddlGroupBy.SelectedItem.Text == "Project")
      {
        if (this.ddlProject.SelectedIndex > 0)
        {
          int? iProjectID = new int?();
          if (this.ddlProject.SelectedIndex > 0)
            iProjectID = new int?(int.Parse(this.ddlProject.SelectedItem.Value));
          this.objReportEstimatedBillingProjectDT = this.objReportEstimatedBillingProjectBll.GetData(int.Parse(this.hfCompanyID.Value), iProjectID, bBilled, dtFromDate, dtToDate);
          Label label = new Label()
          {
            Text = this.ddlProject.SelectedItem.Text
          };
          label.Font.Bold = true;
          this.divGrids.Controls.Add((Control) label);
          this.divGrids.Controls.Add((Control) new LiteralControl("<br />"));
          GridView gridView1 = new GridView();
          gridView1.DataSource = (object) this.objReportEstimatedBillingProjectDT;
          gridView1.CssClass = "reportTable table table-responsive";
          gridView1.Width = Unit.Percentage(100.0);
          gridView1.GridLines = GridLines.None;
          gridView1.EmptyDataText = "No Timesheet entry found";
          GridView gridView2 = gridView1;
          gridView2.HeaderStyle.BackColor = ColorTranslator.FromHtml("#0083E0");
          gridView2.HeaderStyle.ForeColor = Color.White;
          gridView2.DataBind();
          this.divGrids.Controls.Add((Control) gridView2);
          this.divGrids.Controls.Add((Control) new LiteralControl("<br />"));
        }
        else
        {
          this.ddlProject.DataBind();
          foreach (ListItem listItem in this.ddlProject.Items)
          {
            if (!string.IsNullOrEmpty(listItem.Value))
            {
              this.objReportEstimatedBillingProjectDT = this.objReportEstimatedBillingProjectBll.GetData(int.Parse(this.hfCompanyID.Value), new int?(int.Parse(listItem.Value)), bBilled, dtFromDate, dtToDate);
              Label label = new Label()
              {
                Text = listItem.Text
              };
              label.Font.Bold = true;
              this.divGrids.Controls.Add((Control) label);
              this.divGrids.Controls.Add((Control) new LiteralControl("<br />"));
              GridView gridView1 = new GridView();
              gridView1.DataSource = (object) this.objReportEstimatedBillingProjectDT;
              gridView1.CssClass = "reportTable table table-responsive";
              gridView1.Width = Unit.Percentage(100.0);
              gridView1.GridLines = GridLines.None;
              gridView1.EmptyDataText = "No Timesheet entry found";
              GridView gridView2 = gridView1;
              gridView2.HeaderStyle.BackColor = ColorTranslator.FromHtml("#0083E0");
              gridView2.HeaderStyle.ForeColor = Color.White;
              gridView2.DataBind();
              this.divGrids.Controls.Add((Control) gridView2);
              this.divGrids.Controls.Add((Control) new LiteralControl("<br />"));
            }
          }
        }
      }
      else
      {
        if (!(this.ddlGroupBy.SelectedItem.Text == "Task"))
          return;
        this.ddlTask.DataBind();
        foreach (ListItem listItem in this.ddlTask.Items)
        {
          if (!string.IsNullOrEmpty(listItem.Value))
          {
            this.objReportEstimatedBillingTaskDT = this.objReportEstimatedBillingTaskBll.GetData(int.Parse(this.hfCompanyID.Value), int.Parse(listItem.Value), bBilled, dtFromDate, dtToDate);
            Label label = new Label()
            {
              Text = listItem.Text
            };
            label.Font.Bold = true;
            this.divGrids.Controls.Add((Control) label);
            this.divGrids.Controls.Add((Control) new LiteralControl("<br />"));
            GridView gridView1 = new GridView();
            gridView1.DataSource = (object) this.objReportEstimatedBillingTaskDT;
            gridView1.CssClass = "reportTable table table-responsive";
            gridView1.Width = Unit.Percentage(100.0);
            gridView1.GridLines = GridLines.None;
            gridView1.EmptyDataText = "No Timesheet entry found";
            GridView gridView2 = gridView1;
            gridView2.HeaderStyle.BackColor = ColorTranslator.FromHtml("#0083E0");
            gridView2.HeaderStyle.ForeColor = Color.White;
            gridView2.DataBind();
            this.divGrids.Controls.Add((Control) gridView2);
            this.divGrids.Controls.Add((Control) new LiteralControl("<br />"));
          }
        }
      }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
      this.BindGrid();
    }
  }
}

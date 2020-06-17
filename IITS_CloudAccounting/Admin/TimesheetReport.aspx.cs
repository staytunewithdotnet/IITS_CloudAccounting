// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.TimesheetReport
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Drawing;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class TimesheetReport : Page
  {
    private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
    private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
    private readonly ReportTimesheetBLL objReportTimesheetBll = new ReportTimesheetBLL();
    private CloudAccountDA.ReportTimesheetDataTable objReportTimesheetDT = new CloudAccountDA.ReportTimesheetDataTable();
    public string dateFormat = "dd/MMM/yyyy";
    protected ToolkitScriptManager tsm;
    protected DropDownList ddlMonth;
    protected DropDownList ddlYear;
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
      if (!this.IsPostBack)
      {
        this.ddlMonth.SelectedValue = DateTime.Now.Month.ToString();
        this.ddlYear.Items.Add(new ListItem(DateTime.Now.Year.ToString(), DateTime.Now.Year.ToString()));
        this.ddlYear.SelectedValue = DateTime.Now.Year.ToString();
        this.BindGrid();
      }
      MembershipUser user = Membership.GetUser();
      if (user == null)
        return;
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

    private void SetMiscValues(string companyId)
    {
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(companyId));
      this.lblCompanyName.Text = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
      this.lblInfo.Text = this.ddlMonth.SelectedItem.Text + " " + this.ddlYear.SelectedItem.Text;
    }

    private void BindGrid()
    {
      if (this.ddlTeam.SelectedIndex > 0)
      {
        string sEntryFor = (string) null;
        if (this.ddlTeam.SelectedIndex > 0)
          sEntryFor = this.ddlTeam.SelectedItem.Value;
        this.objReportTimesheetDT = this.objReportTimesheetBll.GetData(int.Parse(this.hfCompanyID.Value), int.Parse(this.ddlMonth.SelectedItem.Value), int.Parse(this.ddlYear.SelectedItem.Text), sEntryFor);
        Label label = new Label()
        {
          Text = "Hours for " + this.ddlTeam.SelectedItem.Text + " : " + this.lblInfo.Text
        };
        label.Font.Bold = true;
        label.Attributes.Add("style", "float: right;");
        this.divGrids.Controls.Add((Control) label);
        this.divGrids.Controls.Add((Control) new LiteralControl("<br />"));
        GridView gridView1 = new GridView();
        gridView1.DataSource = (object) this.objReportTimesheetDT;
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
            this.objReportTimesheetDT = this.objReportTimesheetBll.GetData(int.Parse(this.hfCompanyID.Value), int.Parse(this.ddlMonth.SelectedItem.Value), int.Parse(this.ddlYear.SelectedItem.Text), listItem.Value);
            Label label = new Label()
            {
              Text = "Hours for " + listItem.Text + " : " + this.lblInfo.Text
            };
            label.Font.Bold = true;
            label.Attributes.Add("style", "float: right;");
            this.divGrids.Controls.Add((Control) label);
            this.divGrids.Controls.Add((Control) new LiteralControl("<br />"));
            GridView gridView1 = new GridView();
            gridView1.DataSource = (object) this.objReportTimesheetDT;
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

    protected void BtnUpdateClick(object sender, EventArgs e)
    {
      this.BindGrid();
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Client.Projects
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

namespace IITS_CloudAccounting.Client
{
  public class Projects : Page
  {
    private readonly CompanyClientMasterBLL objCompanyClientMasterBll = new CompanyClientMasterBLL();
    private CloudAccountDA.CompanyClientMasterDataTable objCompanyClientMasterDT = new CloudAccountDA.CompanyClientMasterDataTable();
    private readonly ProjectMasterBLL objProjectMasterBll = new ProjectMasterBLL();
    private CloudAccountDA.ProjectMasterDataTable objProjectMasterDT = new CloudAccountDA.ProjectMasterDataTable();
    private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
    private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
    private readonly CompanyClientContactDetailBLL objCompanyClientContactDetailBll = new CompanyClientContactDetailBLL();
    private CloudAccountDA.CompanyClientContactDetailDataTable objCompanyClientContactDetailDT = new CloudAccountDA.CompanyClientContactDetailDataTable();
    private readonly MiscellaneousMasterBLL objMiscellaneousMasterBll = new MiscellaneousMasterBLL();
    private CloudAccountDA.MiscellaneousMasterDataTable objMiscellaneousMasterDT = new CloudAccountDA.MiscellaneousMasterDataTable();
    private int linePerPage = 15;
    private readonly string[,] schedDay = new string[13, 32];
    protected Panel pnlView;
    protected Label lblProject;
    protected GridView gvTask;
    protected SqlDataSource sqldsTask;
    protected UpdatePanel upCalander;
    protected LinkButton lnkPrevYear;
    protected LinkButton lnkPrevMonth;
    protected Label lblTitle;
    protected LinkButton lnkNextMonth;
    protected LinkButton lnkNextYear;
    protected Calendar Calendar1;
    protected GridView gvTemp;
    protected SqlDataSource sqldsTemp;
    protected Label lblProjectManager;
    protected Panel pnlViewAll;
    protected GridView gvProject;
    protected ObjectDataSource objdsProject;
    protected HiddenField hfClientID;
    protected HiddenField hfProjectID;
    protected HiddenField hfClientContactID;
    protected HiddenField hfCompanyID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("timeTracking")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("project")).Attributes.Add("class", "active open");
      MembershipUser user = Membership.GetUser();
      if (user != null)
      {
        this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByUsername(user.ToString());
        if (this.objCompanyClientMasterDT.Rows.Count > 0)
        {
          this.hfClientID.Value = this.objCompanyClientMasterDT.Rows[0]["CompanyClientID"].ToString();
          this.hfCompanyID.Value = this.objCompanyClientMasterDT.Rows[0]["CompanyID"].ToString();
        }
        this.objCompanyClientContactDetailDT = this.objCompanyClientContactDetailBll.GetDataByUsername(user.ToString());
        if (this.objCompanyClientContactDetailDT.Rows.Count > 0)
        {
          this.hfClientContactID.Value = this.objCompanyClientContactDetailDT.Rows[0]["CompanyClientContactID"].ToString();
          this.hfClientID.Value = this.objCompanyClientContactDetailDT.Rows[0]["CompanyClientID"].ToString();
          this.hfCompanyID.Value = this.objCompanyClientContactDetailDT.Rows[0]["CompanyID"].ToString();
        }
        this.SetMiscValues(this.hfCompanyID.Value);
      }
      if (!this.IsPostBack)
      {
        this.Calendar1.SelectedDate = DateTime.Today;
        this.BindGrid();
      }
      if (this.IsPostBack)
        return;
      if (this.Request.QueryString["cmd"] != null)
      {
        switch (this.Request.QueryString["cmd"])
        {
          case "view":
            if (this.Request.QueryString["ID"] == null)
              break;
            string sId = this.Request.QueryString["ID"];
            this.pnlView.Visible = true;
            this.pnlViewAll.Visible = false;
            this.ViewRecord(sId);
            break;
          default:
            this.pnlViewAll.Visible = true;
            this.pnlView.Visible = false;
            this.BindGrid();
            break;
        }
      }
      else
      {
        this.pnlViewAll.Visible = true;
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

    private void ViewRecord(string sId)
    {
      bool flag = false;
      this.objProjectMasterDT = this.objProjectMasterBll.GetDataByProjectID(int.Parse(sId));
      if (this.objProjectMasterDT.Rows.Count > 0)
        flag = this.objProjectMasterDT.Rows[0]["ClientID"].ToString() == this.hfClientID.Value;
      if (this.objProjectMasterDT.Rows.Count > 0 && flag)
      {
        this.hfProjectID.Value = this.objProjectMasterDT.Rows[0]["ProjectID"].ToString();
        this.lblProject.Text = this.objProjectMasterDT.Rows[0]["ProjectName"].ToString();
        this.hfCompanyID.Value = this.objProjectMasterDT.Rows[0]["CompanyID"].ToString();
        this.lblProjectManager.Text = this.objProjectMasterDT.Rows[0]["ProjectManager"].ToString();
        if (string.IsNullOrEmpty(this.lblProjectManager.Text))
          return;
        int iStaffID = int.Parse(this.lblProjectManager.Text);
        if (iStaffID == 0)
        {
          this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
          this.lblProjectManager.Text = this.objCompanyMasterDT.Rows[0]["CompanyContactPerson"].ToString();
        }
        else
        {
          this.objStaffMasterDT = this.objStaffMasterBll.GetDataByStaffID(iStaffID);
          if (this.objStaffMasterDT.Rows.Count <= 0)
            return;
          this.lblProjectManager.Text = (string) this.objStaffMasterDT.Rows[0]["FirstName"] + (object) " " + (string) this.objStaffMasterDT.Rows[0]["LastName"];
        }
      }
      else
      {
        this.pnlViewAll.Visible = true;
        this.pnlView.Visible = false;
        this.BindGrid();
      }
    }

    private void BindGrid()
    {
      this.gvProject.DataBind();
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
      this.lblTitle.Text = this.Calendar1.SelectedDate.ToString("MMMM yyyy");
    }

    protected void gvProject_OnSorting(object sender, GridViewSortEventArgs e)
    {
      this.BindGrid();
    }

    protected void gvProject_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvProject.PageIndex = e.NewPageIndex;
      this.BindGrid();
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

    protected void lnkPrevYear_Click(object sender, EventArgs e)
    {
      this.Calendar1.TodaysDate = new DateTime(int.Parse(this.Calendar1.SelectedDate.ToString("yyyy")) - 1, int.Parse(this.Calendar1.SelectedDate.ToString("MM")), 1);
      this.Calendar1.SelectedDate = this.Calendar1.TodaysDate;
      this.BindGrid();
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
      this.BindGrid();
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
      this.BindGrid();
    }

    protected void lnkNextYear_Click(object sender, EventArgs e)
    {
      this.Calendar1.TodaysDate = new DateTime(int.Parse(this.Calendar1.SelectedDate.ToString("yyyy")) + 1, int.Parse(this.Calendar1.SelectedDate.ToString("MM")), 1);
      this.Calendar1.SelectedDate = this.Calendar1.TodaysDate;
      this.BindGrid();
    }
  }
}

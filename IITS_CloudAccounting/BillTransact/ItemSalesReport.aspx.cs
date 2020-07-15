// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.ItemSalesReport
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
  public class ItemSalesReport : Page
  {
    private readonly MiscellaneousMasterBLL objMiscellaneousMasterBll = new MiscellaneousMasterBLL();
    private CloudAccountDA.MiscellaneousMasterDataTable objMiscellaneousMasterDT = new CloudAccountDA.MiscellaneousMasterDataTable();
    private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
    private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
    private readonly CompanyClientMasterBLL objCompanyClientMasterBll = new CompanyClientMasterBLL();
    private CloudAccountDA.CompanyClientMasterDataTable objCompanyClientMasterDT = new CloudAccountDA.CompanyClientMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
    private readonly ReportItemSalesBLL objReportItemSalesBll = new ReportItemSalesBLL();
    private CloudAccountDA.ReportItemSalesDataTable objReportItemSalesDT = new CloudAccountDA.ReportItemSalesDataTable();
    public string dateFormat = "dd/MMM/yyyy";
    protected ToolkitScriptManager tsm;
    protected TextBox txtDateFrom;
    protected CalendarExtender ceDateFrom;
    protected TextBox txtDateTo;
    protected CalendarExtender ceDateTo;
    protected DropDownList ddlItems;
    protected SqlDataSource sqldsItems;
    protected DropDownList ddlStatusSearch;
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
          {
            this.hfCompanyID.Value = this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString();
            this.imgLogo.ImageUrl = Doyingo.SetCompanyLogo(this.hfCompanyID.Value);
          }
        }
        else if (Roles.IsUserInRole(str, "Employee"))
        {
          this.objStaffMasterDT = this.objStaffMasterBll.GetDataByStaffUserName(str);
          if (this.objStaffMasterDT.Rows.Count > 0)
          {
            this.hfCompanyID.Value = this.objStaffMasterDT.Rows[0]["CompanyID"].ToString();
            this.imgLogo.ImageUrl = Doyingo.SetCompanyLogo(this.hfCompanyID.Value);
          }
        }
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
      if (this.ddlItems.SelectedIndex > 0)
      {
        int iItemID = int.Parse(this.ddlItems.SelectedItem.Value);
        string sStatus = (string) null;
        DateTime? dtFromDate = new DateTime?();
        DateTime? dtToDate = new DateTime?();
        if (this.ddlStatusSearch.SelectedIndex > 0)
          sStatus = this.ddlStatusSearch.SelectedItem.Text;
        if (this.txtDateFrom.Text.Trim().Length > 0)
          dtFromDate = new DateTime?(DateTime.Parse(this.txtDateFrom.Text.Trim()));
        if (this.txtDateTo.Text.Trim().Length > 0)
          dtToDate = new DateTime?(DateTime.Parse(this.txtDateTo.Text.Trim()));
        this.objReportItemSalesDT = this.objReportItemSalesBll.GetData(iItemID, sStatus, dtFromDate, dtToDate);
        Label label1 = new Label()
        {
          Text = this.ddlItems.SelectedItem.Text
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
        gridView1.DataSource = (object) this.objReportItemSalesDT;
        gridView1.CssClass = "reportTable table table-responsive";
        gridView1.Width = Unit.Percentage(100.0);
        gridView1.GridLines = GridLines.None;
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
        this.ddlItems.DataBind();
        foreach (ListItem listItem in this.ddlItems.Items)
        {
          string s = listItem.Value;
          if (!string.IsNullOrEmpty(s))
          {
            int iItemID = int.Parse(s);
            string sStatus = (string) null;
            DateTime? dtFromDate = new DateTime?();
            DateTime? dtToDate = new DateTime?();
            if (this.ddlStatusSearch.SelectedIndex > 0)
              sStatus = this.ddlStatusSearch.SelectedItem.Text;
            if (this.txtDateFrom.Text.Trim().Length > 0)
              dtFromDate = new DateTime?(DateTime.Parse(this.txtDateFrom.Text.Trim()));
            if (this.txtDateTo.Text.Trim().Length > 0)
              dtToDate = new DateTime?(DateTime.Parse(this.txtDateTo.Text.Trim()));
            this.objReportItemSalesDT = this.objReportItemSalesBll.GetData(iItemID, sStatus, dtFromDate, dtToDate);
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
            gridView1.DataSource = (object) this.objReportItemSalesDT;
            gridView1.CssClass = "reportTable table table-responsive";
            gridView1.Width = Unit.Percentage(100.0);
            gridView1.GridLines = GridLines.None;
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
      this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(e.Row.Cells[0].Text));
      e.Row.Cells[0].Text = this.objCompanyClientMasterDT.Rows[0]["OrganizationName"].ToString();
      string[] strArray = e.Row.Cells[2].Text.Split(' ');
      e.Row.Cells[2].Text = strArray[0];
      string text1 = e.Row.Cells[3].Text;
      e.Row.Cells[3].Text = Decimal.Round(Decimal.Parse(text1), 2).ToString();
      string text2 = e.Row.Cells[4].Text;
      e.Row.Cells[4].Text = Decimal.Round(Decimal.Parse(text2), 2).ToString();
      string text3 = e.Row.Cells[5].Text;
      e.Row.Cells[5].Text = Decimal.Round(Decimal.Parse(text3), 2).ToString();
      string text4 = e.Row.Cells[6].Text;
      e.Row.Cells[6].Text = Decimal.Round(Decimal.Parse(text4), 2).ToString();
    }

    protected void BtnUpdateClick(object sender, EventArgs e)
    {
      this.BindGrid();
    }
  }
}

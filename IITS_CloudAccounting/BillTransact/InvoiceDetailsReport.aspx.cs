// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.InvoiceDetailsReport
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
    public class InvoiceDetailsReport : Page
    {
        private readonly MiscellaneousMasterBLL objMiscellaneousMasterBll = new MiscellaneousMasterBLL();
        private CloudAccountDA.MiscellaneousMasterDataTable objMiscellaneousMasterDT = new CloudAccountDA.MiscellaneousMasterDataTable();
        private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
        private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
        private readonly TaxMasterBLL objTaxMasterBll = new TaxMasterBLL();
        private CloudAccountDA.TaxMasterDataTable objTaxMasterDT = new CloudAccountDA.TaxMasterDataTable();
        private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
        private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
        private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
        private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
        private readonly ReportInvoiceDetailsBLL objReportInvoiceDetailsBll = new ReportInvoiceDetailsBLL();
        private CloudAccountDA.ReportInvoiceDetailsDataTable objReportInvoiceDetailsDT = new CloudAccountDA.ReportInvoiceDetailsDataTable();
        public string dateFormat = "dd/MMM/yyyy";
        protected ToolkitScriptManager tsm;
        protected TextBox txtDateFrom;
        protected CalendarExtender ceDateFrom;
        protected TextBox txtDateTo;
        protected CalendarExtender ceDateTo;
        protected DropDownList ddlClient;
        protected SqlDataSource sqldsClient;
        protected DropDownList ddlStatus;
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
            ((HtmlControl)this.Master.FindControl("reports")).Attributes.Add("class", "active open");
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
            //this.lblInfo.Text = "Between " + DateTime.ParseExact(this.txtDateFrom.Text, formats, (IFormatProvider) CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("MMMM dd, yyyy") + " and " + DateTime.ParseExact(this.txtDateTo.Text, formats, (IFormatProvider) CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("MMMM dd, yyyy");

            this.lblInfo.Text = "Between " + txtDateFrom.Text + " and " + txtDateTo.Text;
        }

        private void BindGrid()
        {
            DateTime? dtFromDate = new DateTime?();
            DateTime? dtToDate = new DateTime?();
            string sStatus = (string)null;
            if (this.txtDateFrom.Text.Trim().Length > 0)
                dtFromDate = new DateTime?(DateTime.Parse(this.txtDateFrom.Text.Trim()));
            if (this.txtDateTo.Text.Trim().Length > 0)
                dtToDate = new DateTime?(DateTime.Parse(this.txtDateTo.Text.Trim()));
            if (this.ddlStatus.SelectedIndex > 0)
                sStatus = this.ddlStatus.SelectedItem.Value;
            if (this.ddlClient.SelectedIndex > 0)
            {
                string s = this.ddlClient.SelectedItem.Value;
                if (string.IsNullOrEmpty(s))
                    return;
                this.objReportInvoiceDetailsDT = this.objReportInvoiceDetailsBll.GetData(int.Parse(this.hfCompanyID.Value), int.Parse(s), sStatus, dtFromDate, dtToDate);
                Label label = new Label()
                {
                    Text = this.ddlClient.SelectedItem.Text
                };
                label.Font.Bold = true;
                this.divGrids.Controls.Add((Control)label);
                this.divGrids.Controls.Add((Control)new LiteralControl("<br />"));
                GridView gridView1 = new GridView();
                gridView1.DataSource = (object)this.objReportInvoiceDetailsDT;
                gridView1.CssClass = "reportTable table table-responsive";
                gridView1.Width = Unit.Percentage(100.0);
                gridView1.GridLines = GridLines.None;
                gridView1.EmptyDataText = "No invoice available in this search values.";
                GridView gridView2 = gridView1;
                gridView2.HeaderStyle.BackColor = ColorTranslator.FromHtml("#0083E0");
                gridView2.HeaderStyle.ForeColor = Color.White;
                gridView2.RowDataBound += new GridViewRowEventHandler(this.gv_RowDataBound);
                gridView2.DataBind();
                this.divGrids.Controls.Add((Control)gridView2);
                InvoiceDetailsReport.MergeRows(gridView2);
                this.divGrids.Controls.Add((Control)new LiteralControl("<br />"));
            }
            else
            {
                this.ddlClient.DataBind();
                foreach (ListItem listItem in this.ddlClient.Items)
                {
                    if (!string.IsNullOrEmpty(listItem.Value))
                    {
                        this.objReportInvoiceDetailsDT = this.objReportInvoiceDetailsBll.GetData(int.Parse(this.hfCompanyID.Value), int.Parse(listItem.Value), sStatus, dtFromDate, dtToDate);
                        Label label = new Label()
                        {
                            Text = listItem.Text
                        };
                        label.Font.Bold = true;
                        this.divGrids.Controls.Add((Control)label);
                        this.divGrids.Controls.Add((Control)new LiteralControl("<br />"));
                        GridView gridView1 = new GridView();
                        gridView1.DataSource = (object)this.objReportInvoiceDetailsDT;
                        gridView1.CssClass = "reportTable table table-responsive";
                        gridView1.Width = Unit.Percentage(100.0);
                        gridView1.GridLines = GridLines.None;
                        gridView1.EmptyDataText = "No invoice available in this search values.";
                        GridView gridView2 = gridView1;
                        gridView2.HeaderStyle.BackColor = ColorTranslator.FromHtml("#0083E0");
                        gridView2.HeaderStyle.ForeColor = Color.White;
                        gridView2.RowDataBound += new GridViewRowEventHandler(this.gv_RowDataBound);
                        gridView2.DataBind();
                        InvoiceDetailsReport.MergeRows(gridView2);
                        this.divGrids.Controls.Add((Control)gridView2);
                        this.divGrids.Controls.Add((Control)new LiteralControl("<br />"));
                    }
                }
            }
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            string[] strArray = e.Row.Cells[2].Text.Split(' ');
            e.Row.Cells[2].Text = strArray[0];
            string s1 = e.Row.Cells[5].Text.Replace("&nbsp;", "");
            if (!string.IsNullOrEmpty(s1))
                e.Row.Cells[5].Text = Decimal.Round(Decimal.Parse(s1), 2).ToString();
            string s2 = e.Row.Cells[6].Text.Replace("&nbsp;", "");
            if (!string.IsNullOrEmpty(s2))
                e.Row.Cells[6].Text = Decimal.Round(Decimal.Parse(s2), 2).ToString();
            string s3 = e.Row.Cells[9].Text.Replace("&nbsp;", "");
            if (!string.IsNullOrEmpty(s3))
                e.Row.Cells[9].Text = Decimal.Round(Decimal.Parse(s3), 2).ToString();
            if (!string.IsNullOrEmpty(e.Row.Cells[7].Text.Replace("&nbsp;", "")))
            {
                try
                {
                    this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(e.Row.Cells[7].Text));
                    if (this.objTaxMasterDT.Rows.Count > 0)
                    {
                        string s4 = this.objTaxMasterDT.Rows[0]["TaxRate"].ToString();
                        string text = e.Row.Cells[9].Text;
                        if (string.IsNullOrEmpty(text))
                        {
                            if (string.IsNullOrEmpty(s4))
                                goto label_15;
                        }
                        Decimal d = Decimal.Parse(s4) * Decimal.Parse(text) / new Decimal(100);
                        e.Row.Cells[7].Text = Decimal.Round(d, 2).ToString();
                    }
                    else
                        e.Row.Cells[7].Text = "0.00";
                }
                catch (Exception ex)
                {
                    e.Row.Cells[7].Text = "0.00";
                }
            }
            else
                e.Row.Cells[7].Text = "0.00";
            label_15:
            if (!string.IsNullOrEmpty(e.Row.Cells[8].Text.Replace("&nbsp;", "")))
            {
                try
                {
                    this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(e.Row.Cells[8].Text));
                    if (this.objTaxMasterDT.Rows.Count > 0)
                    {
                        string s4 = this.objTaxMasterDT.Rows[0]["TaxRate"].ToString();
                        string text = e.Row.Cells[9].Text;
                        if (string.IsNullOrEmpty(text) && string.IsNullOrEmpty(s4))
                            return;
                        Decimal d = Decimal.Parse(s4) * Decimal.Parse(text) / new Decimal(100);
                        e.Row.Cells[8].Text = Decimal.Round(d, 2).ToString();
                    }
                    else
                        e.Row.Cells[8].Text = "0.00";
                }
                catch (Exception ex)
                {
                    e.Row.Cells[8].Text = "0.00";
                }
            }
            else
                e.Row.Cells[8].Text = "0.00";
        }

        private static void MergeRows(GridView gridView)
        {
            for (int index = gridView.Rows.Count - 2; index >= 0; --index)
            {
                GridViewRow gridViewRow1 = gridView.Rows[index];
                GridViewRow gridViewRow2 = gridView.Rows[index + 1];
                if (gridViewRow1.Cells[0].Text == gridViewRow2.Cells[0].Text)
                {
                    gridViewRow1.Cells[0].RowSpan = gridViewRow2.Cells[0].RowSpan < 2 ? 2 : gridViewRow2.Cells[0].RowSpan + 1;
                    gridViewRow2.Cells[0].Visible = false;
                    gridViewRow1.Cells[1].RowSpan = gridViewRow2.Cells[1].RowSpan < 2 ? 2 : gridViewRow2.Cells[1].RowSpan + 1;
                    gridViewRow2.Cells[1].Visible = false;
                    gridViewRow1.Cells[2].RowSpan = gridViewRow2.Cells[2].RowSpan < 2 ? 2 : gridViewRow2.Cells[2].RowSpan + 1;
                    gridViewRow2.Cells[2].Visible = false;
                    gridViewRow1.Cells[3].RowSpan = gridViewRow2.Cells[3].RowSpan < 2 ? 2 : gridViewRow2.Cells[3].RowSpan + 1;
                    gridViewRow2.Cells[3].Visible = false;
                }
            }
        }

        protected void BtnUpdateClick(object sender, EventArgs e)
        {
            this.BindGrid();
        }
    }
}

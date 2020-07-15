// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.PaymentsCollectedReport
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Globalization;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class PaymentsCollectedReport : Page
  {
    private readonly MiscellaneousMasterBLL objMiscellaneousMasterBll = new MiscellaneousMasterBLL();
    private CloudAccountDA.MiscellaneousMasterDataTable objMiscellaneousMasterDT = new CloudAccountDA.MiscellaneousMasterDataTable();
    private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
    private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyClientMasterBLL objCompanyClientMasterBll = new CompanyClientMasterBLL();
    private CloudAccountDA.CompanyClientMasterDataTable objCompanyClientMasterDT = new CloudAccountDA.CompanyClientMasterDataTable();
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
    private readonly CurrencyMasterBLL objCurrencyMasterBll = new CurrencyMasterBLL();
    private CloudAccountDA.CurrencyMasterDataTable objCurrencyMasterDT = new CloudAccountDA.CurrencyMasterDataTable();
    private readonly InvoiceMasterBLL objInvoiceMasterBll = new InvoiceMasterBLL();
    private CloudAccountDA.InvoiceMasterDataTable objInvoiceMasterDT = new CloudAccountDA.InvoiceMasterDataTable();
    public string dateFormat = "dd/MMM/yyyy";
    protected ToolkitScriptManager tsm;
    protected TextBox txtDateFrom;
    protected CalendarExtender ceDateFrom;
    protected TextBox txtDateTo;
    protected CalendarExtender ceDateTo;
    protected DropDownList ddlClient;
    protected SqlDataSource sqldsClient;
    protected DropDownList ddlMethod;
    protected Button btnUpdate;
    protected Image imgLogo;
    protected Label lblCompanyName;
    protected Label lblInfo;
    protected GridView gvPayments;
    protected ObjectDataSource objdsPayments;
    protected HiddenField hfCompanyID;
    protected HiddenField hfDate;

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

    protected void gvPayment_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        this.objInvoiceMasterDT = this.objInvoiceMasterBll.GetDataByInvoiceID(int.Parse(e.Row.Cells[1].Text));
        if (this.objInvoiceMasterDT.Rows.Count > 0)
        {
          this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(this.objInvoiceMasterDT.Rows[0]["ClientID"].ToString()));
          e.Row.Cells[1].Text = this.objCompanyClientMasterDT.Rows[0]["OrganizationName"].ToString();
        }
      }
      BoundField boundField = ((GridView) sender).Columns[4] as BoundField;
      if (boundField == null)
        return;
      boundField.DataFormatString = "{0:" + this.dateFormat + "}";
    }

    protected string GetInvoiceNumber(string invoiceid)
    {
      this.objInvoiceMasterDT = this.objInvoiceMasterBll.GetDataByInvoiceID(int.Parse(invoiceid));
      if (this.objInvoiceMasterDT.Rows.Count > 0)
        return "Invoice " + this.objInvoiceMasterDT.Rows[0]["InvoiceNumber"];
      return "";
    }

    protected string GetCurrency(string invId)
    {
      this.objInvoiceMasterDT = this.objInvoiceMasterBll.GetDataByInvoiceID(int.Parse(invId));
      this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(this.objInvoiceMasterDT.Rows[0]["CurrencyID"].ToString()));
      if (this.objCurrencyMasterDT.Rows.Count > 0)
        return "(" + this.objCurrencyMasterDT.Rows[0]["CurrencySymbol"] + ")";
      return "";
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
      this.gvPayments.DataBind();
    }

    protected void BtnUpdateClick(object sender, EventArgs e)
    {
      this.BindGrid();
    }

    protected void gvPayments_OnSorting(object sender, GridViewSortEventArgs e)
    {
      this.BindGrid();
    }
  }
}

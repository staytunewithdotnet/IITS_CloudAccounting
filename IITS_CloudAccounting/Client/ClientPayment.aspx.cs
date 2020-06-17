// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Client.ClientPayment
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
  public class ClientPayment : Page
  {
    private readonly CompanyClientMasterBLL objCompanyClientMasterBll = new CompanyClientMasterBLL();
    private CloudAccountDA.CompanyClientMasterDataTable objCompanyClientMasterDT = new CloudAccountDA.CompanyClientMasterDataTable();
    private readonly CompanyClientContactDetailBLL objCompanyClientContactDetailBll = new CompanyClientContactDetailBLL();
    private CloudAccountDA.CompanyClientContactDetailDataTable objCompanyClientContactDetailDT = new CloudAccountDA.CompanyClientContactDetailDataTable();
    private readonly CurrencyMasterBLL objCurrencyMasterBll = new CurrencyMasterBLL();
    private CloudAccountDA.CurrencyMasterDataTable objCurrencyMasterDT = new CloudAccountDA.CurrencyMasterDataTable();
    private readonly InvoiceMasterBLL objInvoiceMasterBll = new InvoiceMasterBLL();
    private CloudAccountDA.InvoiceMasterDataTable objInvoiceMasterDT = new CloudAccountDA.InvoiceMasterDataTable();
    private readonly MiscellaneousMasterBLL objMiscellaneousMasterBll = new MiscellaneousMasterBLL();
    private CloudAccountDA.MiscellaneousMasterDataTable objMiscellaneousMasterDT = new CloudAccountDA.MiscellaneousMasterDataTable();
    private string dateFormat = "MM/dd/yyyy";
    private int linePerPage = 15;
    protected Panel pnlViewAll;
    protected GridView gvPayment;
    protected Label lblTotal;
    protected Label lblCurCode;
    protected SqlDataSource sqldsPayment;
    protected HiddenField hfClientID;
    protected HiddenField hfInvoiceID;
    protected HiddenField hfClientContactID;
    protected HiddenField hfCompanyID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("invoice")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("payments")).Attributes.Add("class", "active open");
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
      if (this.IsPostBack)
        return;
      this.BindGrid();
    }

    private void SetMiscValues(string companyID)
    {
      this.objMiscellaneousMasterDT = this.objMiscellaneousMasterBll.GetDataByCompanyID(int.Parse(companyID));
      if (this.objMiscellaneousMasterDT.Rows.Count <= 0)
        return;
      this.dateFormat = this.objMiscellaneousMasterDT.Rows[0]["DateFormat"].ToString();
      this.linePerPage = int.Parse(this.objMiscellaneousMasterDT.Rows[0]["LinesPerPage"].ToString());
      this.gvPayment.PageSize = this.linePerPage;
    }

    private void BindGrid()
    {
      this.gvPayment.DataBind();
      this.GetPaymentTotal();
    }

    private void GetPaymentTotal()
    {
      if (this.gvPayment.Rows.Count > 0)
      {
        Decimal d = new Decimal(0);
        for (int index = 0; index < this.gvPayment.Rows.Count; ++index)
        {
          string text = this.gvPayment.Rows[index].Cells[5].Text;
          if (!string.IsNullOrEmpty(text))
            d += Decimal.Parse(text);
        }
        this.lblTotal.Text = Decimal.Round(d, 2).ToString();
      }
      else
        this.lblTotal.Text = "0.00";
      this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(this.hfClientID.Value));
      string s = this.objCompanyClientMasterDT.Rows[0]["CurrencyID"].ToString();
      if (!string.IsNullOrEmpty(s))
      {
        this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(s));
        if (this.objCurrencyMasterDT.Rows.Count <= 0)
          return;
        this.lblCurCode.Text = this.objCurrencyMasterDT.Rows[0]["CurrencyCode"].ToString();
      }
      else
        this.lblCurCode.Text = "NGN";
    }

    protected string GetInvoiceNumber(string invoiceid)
    {
      this.objInvoiceMasterDT = this.objInvoiceMasterBll.GetDataByInvoiceID(int.Parse(invoiceid));
      if (this.objInvoiceMasterDT.Rows.Count > 0)
        return "Invoice " + this.objInvoiceMasterDT.Rows[0]["InvoiceNumber"];
      return "";
    }

    protected void gvPayment_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        this.objInvoiceMasterDT = this.objInvoiceMasterBll.GetDataByInvoiceID(int.Parse(e.Row.Cells[2].Text));
        if (this.objInvoiceMasterDT.Rows.Count > 0)
        {
          this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(int.Parse(this.objInvoiceMasterDT.Rows[0]["ClientID"].ToString()));
          e.Row.Cells[2].Text = this.objCompanyClientMasterDT.Rows[0]["OrganizationName"].ToString();
        }
      }
      BoundField boundField = ((GridView) sender).Columns[4] as BoundField;
      if (boundField == null)
        return;
      boundField.DataFormatString = "{0:" + this.dateFormat + "}";
    }
  }
}

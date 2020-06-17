// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Client.InvoicePayment
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using DABL.BLL;
using DABL.DAL;
using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Client
{
  public class InvoicePayment : Page
  {
    private readonly CompanyPaypalMasterBLL objCompanyPaypalMasterBll = new CompanyPaypalMasterBLL();
    private CloudAccountDA.CompanyPaypalMasterDataTable objCompanyPaypalMasterDT = new CloudAccountDA.CompanyPaypalMasterDataTable();
    private readonly MiscellaneousMasterBLL objMiscellaneousMasterBll = new MiscellaneousMasterBLL();
    private CloudAccountDA.MiscellaneousMasterDataTable objMiscellaneousMasterDT = new CloudAccountDA.MiscellaneousMasterDataTable();
    private readonly CompanyClientMasterBLL objCompanyClientMasterBll = new CompanyClientMasterBLL();
    private CloudAccountDA.CompanyClientMasterDataTable objCompanyClientMasterDT = new CloudAccountDA.CompanyClientMasterDataTable();
    private readonly CompanyClientContactDetailBLL objCompanyClientContactDetailBll = new CompanyClientContactDetailBLL();
    private CloudAccountDA.CompanyClientContactDetailDataTable objCompanyClientContactDetailDT = new CloudAccountDA.CompanyClientContactDetailDataTable();
    public string dateFormat = "MM/dd/yyyy";
    private int linePerPage = 15;
    protected Panel pnlPayment;
    protected Label lblPaymentDue;
    protected GridView gvInvoice;
    protected ObjectDataSource objdsInvoice;
    protected TextBox txtPaymentAmount;
    protected ImageButton btnPay;
    protected Panel pnlError;
    protected HtmlAnchor aContact;
    protected Label lblContact;
    protected HiddenField hfClientID;
    protected HiddenField hfInvoiceID;
    protected HiddenField hfClientContactID;
    protected HiddenField hfCompanyID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("invoice")).Attributes.Add("class", "active open");
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

    private void BindGrid()
    {
      if (this.Request.QueryString["invoice"] != null && this.Request.QueryString["val"] != null)
      {
        this.pnlError.Visible = false;
        this.pnlPayment.Visible = true;
        this.hfInvoiceID.Value = InvoicePayment.Decrypt(HttpUtility.UrlDecode(this.Request.QueryString["invoice"]), this.Request.QueryString["val"]);
        this.gvInvoice.DataBind();
        if (this.gvInvoice.Rows.Count > 0)
        {
          this.pnlError.Visible = false;
          this.pnlPayment.Visible = true;
          Label label = this.gvInvoice.Rows[0].Cells[3].FindControl("lblBalancePending") as Label;
          if (label == null)
            return;
          this.txtPaymentAmount.Text = this.lblPaymentDue.Text = label.Text;
        }
        else
        {
          this.pnlError.Visible = true;
          this.pnlPayment.Visible = false;
        }
      }
      else
      {
        this.pnlError.Visible = true;
        this.pnlPayment.Visible = false;
      }
    }

    private static string Decrypt(string cipherText, string key)
    {
      string password = key;
      cipherText = cipherText.Replace(" ", "+");
      byte[] buffer = Convert.FromBase64String(cipherText);
      using (Aes aes = Aes.Create())
      {
        Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, new byte[13]
        {
          (byte) 73,
          (byte) 118,
          (byte) 97,
          (byte) 110,
          (byte) 32,
          (byte) 77,
          (byte) 101,
          (byte) 100,
          (byte) 118,
          (byte) 101,
          (byte) 100,
          (byte) 101,
          (byte) 118
        });
        if (aes != null)
        {
          aes.Key = rfc2898DeriveBytes.GetBytes(32);
          aes.IV = rfc2898DeriveBytes.GetBytes(16);
          using (MemoryStream memoryStream = new MemoryStream())
          {
            using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
            {
              cryptoStream.Write(buffer, 0, buffer.Length);
              cryptoStream.Close();
            }
            cipherText = Encoding.Unicode.GetString(memoryStream.ToArray());
          }
        }
      }
      return cipherText;
    }

    private void SetMiscValues(string companyID)
    {
      this.objMiscellaneousMasterDT = this.objMiscellaneousMasterBll.GetDataByCompanyID(int.Parse(companyID));
      if (this.objMiscellaneousMasterDT.Rows.Count <= 0)
        return;
      this.dateFormat = this.objMiscellaneousMasterDT.Rows[0]["DateFormat"].ToString();
      this.linePerPage = int.Parse(this.objMiscellaneousMasterDT.Rows[0]["LinesPerPage"].ToString());
      this.gvInvoice.PageSize = this.linePerPage;
    }

    protected void gvInvoice_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
      BoundField boundField = ((GridView) sender).Columns[1] as BoundField;
      if (boundField == null)
        return;
      boundField.DataFormatString = "{0:" + this.dateFormat + "}";
    }

    protected void btnPay_Click(object sender, ImageClickEventArgs e)
    {
      string str1 = "https://www.paypal.com/cgi-bin/webscr?cmd=_xclick";
      this.objCompanyPaypalMasterDT = this.objCompanyPaypalMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objCompanyPaypalMasterDT.Rows.Count > 0 && this.gvInvoice.Rows.Count > 0)
      {
        string str2 = str1 + (object) "&business=" + (string) this.objCompanyPaypalMasterDT.Rows[0]["PaypalID"];
        if (!string.IsNullOrEmpty(this.gvInvoice.Rows[0].Cells[0].Text))
          str2 = str2 + "&item_name=invoice no: " + this.gvInvoice.Rows[0].Cells[0].Text;
        if (!string.IsNullOrEmpty(this.txtPaymentAmount.Text))
          str2 = str2 + "&amount=" + this.txtPaymentAmount.Text;
        this.Response.Redirect(str2 + "&return=" + ConfigurationManager.AppSettings["SuccessClientURL"] + "&cancel_return=" + ConfigurationManager.AppSettings["FailedClientURL"]);
      }
      else
      {
        this.pnlError.Visible = true;
        this.pnlPayment.Visible = false;
      }
    }
  }
}

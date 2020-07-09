// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Client.InvoicePayment
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using DABL.BLL;
using DABL.Common;
using DABL.DAL;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Client
{
    public class InvoiceIOPayment : Page
    {
        private readonly InvoiceMasterBLL objInvoiceMasterBLL = new InvoiceMasterBLL();
        private CloudAccountDA.InvoiceMasterDataTable objInvoiceMasterDT = new CloudAccountDA.InvoiceMasterDataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            string invoiceId = InvoiceIOPayment.Decrypt(HttpUtility.UrlDecode(this.Request.QueryString["invoice"]), this.Request.QueryString["val"]);
            objInvoiceMasterDT = objInvoiceMasterBLL.GetDataByInvoiceID(Convert.ToInt32(invoiceId));
            string postData = string.Empty;
            if (objInvoiceMasterDT?.Rows.Count > 0)
            {
                var request = (HttpWebRequest)WebRequest.Create("http://www.iopayer.com/iopg/IOPayerPaymentGateway.aspx");

                MembershipUser user = Membership.GetUser();
                if (user != null)
                {
                    string str = user.ToString();
                    Dbutility objDbutility = new Dbutility();
                    CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
                    CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
                    objCompanyLoginMasterDT = objCompanyLoginMasterBll.GetDataByCompanyLoginName(str);
                    if (objCompanyLoginMasterDT.Rows.Count > 0)
                    {
                        str = objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString();
                        str = " Select ProductID,MerchantID,MerchantAuthkey,TransactionTypeID,TransactionAuthkey " +
                            "From CompanyIOPayerMaster Where CompanyID='" + str + "'";
                        DataTable dtCompanyIOMaster = objDbutility.BindDataTable(str);
                        if (dtCompanyIOMaster.Rows.Count > 0)
                        {
                            str = Convert.ToString(dtCompanyIOMaster.Rows[0]["MerchantID"]);
                            postData = "MerchantID=" + Uri.EscapeDataString(str);

                            str = Convert.ToString(dtCompanyIOMaster.Rows[0]["ProductID"]);
                            postData += "&ProductID=" + Uri.EscapeDataString(str);

                            str = Convert.ToString(dtCompanyIOMaster.Rows[0]["TransactionTypeID"]);
                            postData += "&TransactionTypeID=" + Uri.EscapeDataString(str);

                            str = Convert.ToString(dtCompanyIOMaster.Rows[0]["MerchantAuthkey"]);
                            postData += "&MerchantAuthKey=" + Uri.EscapeDataString(str);

                            str = Convert.ToString(dtCompanyIOMaster.Rows[0]["TransactionAuthkey"]);
                            postData += "&TranAuthKey=" + Uri.EscapeDataString(str);

                            postData += "&OrderAmount=" + Uri.EscapeDataString(Convert.ToString(objInvoiceMasterDT.Rows[0]["InvoiceTotal"]));
                            postData += "&ReturnURL=" + Uri.EscapeDataString(ConfigurationManager.AppSettings["SuccessClientURL"]);
                            postData += "&OrderNo=" + Uri.EscapeDataString(Convert.ToString(objInvoiceMasterDT.Rows[0]["InvoiceNumber"]) + "BT");
                        }
                    }
                }

                if (!string.IsNullOrEmpty(postData))
                {
                    var data = Encoding.ASCII.GetBytes(postData);
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = data.Length;

                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                    Response.Clear();

                    var response = (HttpWebResponse)request.GetResponse();
                    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    string strResultnew = responseString.Replace("./IOPayerPaymentGateway.aspx", "http://www.iopayer.com/iopg/IOPayerPaymentGateway.aspx");
                    Response.Write(strResultnew);
                }

                else
                {
                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(),
                        "<script language=\"JavaScript\">" + "alert('Please fill Company IO Payer Master for before proceeding!');" + "</script>");
                }
            }
            else
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(),
                    "<script language=\"JavaScript\">" + "alert('Invoice detail not found!');" + "</script>");
            }
            return;
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
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
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
    }
}

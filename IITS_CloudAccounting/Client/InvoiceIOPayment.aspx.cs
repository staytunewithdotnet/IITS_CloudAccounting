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
using System.Net;
using System.Security.Cryptography;
using System.Text;
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
            var request = (HttpWebRequest)WebRequest.Create("http://www.iopayer.com/iopg/IOPayerPaymentGateway.aspx");

            //string MerchantName = "Billtransact";
            string MerchantID = "7";
            string MerchantAuthKey = "Billtransact";
            string TransactionTypeID = "14";
            string TranAuthKey = "Debit";
            string ProductID = "7";
            string ReturnURL = ConfigurationManager.AppSettings["SuccessClientURL"];
            //string ExtraParam1 = "";
            //string ExtraParam2 = "";
            //string ExtraParam3 = "";

            //var postData = "MerchantName=" + Uri.EscapeDataString(MerchantName);
            //postData += "MerchantID=" + Uri.EscapeDataString(MerchantID);
            var postData = "MerchantID=" + Uri.EscapeDataString(MerchantID);
            postData += "&ProductID=" + Uri.EscapeDataString(ProductID);
            postData += "&TransactionTypeID=" + Uri.EscapeDataString(TransactionTypeID);
            postData += "&MerchantAuthKey=" + Uri.EscapeDataString(MerchantAuthKey);
            postData += "&TranAuthKey=" + Uri.EscapeDataString(TranAuthKey);
            postData += "&OrderAmount=" + Uri.EscapeDataString(Convert.ToString(objInvoiceMasterDT.Rows[0]["InvoiceTotal"]));
            postData += "&ReturnURL=" + Uri.EscapeDataString(ReturnURL);
            postData += "&OrderNo=" + Uri.EscapeDataString(Convert.ToString(objInvoiceMasterDT.Rows[0]["InvoiceNumber"]) + "BT");
            //postData += "&ExtraParam1=" + Uri.EscapeDataString(ExtraParam1);
            //postData += "&ExtraParam2=" + Uri.EscapeDataString(ExtraParam2);
            //postData += "&ExtraParam3=" + Uri.EscapeDataString(ExtraParam3);

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

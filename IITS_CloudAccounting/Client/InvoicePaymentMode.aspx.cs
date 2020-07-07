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
    public class InvoicePaymentMode : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rdButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Request.Form["__EVENTTARGET"] != null && Request.Form["__EVENTTARGET"] == "ctl00$ContentPlaceHolder1$rdIOPayment")
            {
                this.Response.Redirect(string.Format("InvoiceIOPayment.aspx?invoice={0}&val={1}", this.Request.QueryString["invoice"], this.Request.QueryString["val"]));
            }
            else
            {
                this.Response.Redirect(string.Format("InvoicePayment.aspx?invoice={0}&val={1}", this.Request.QueryString["invoice"], this.Request.QueryString["val"]));
            }
        }

    }
}

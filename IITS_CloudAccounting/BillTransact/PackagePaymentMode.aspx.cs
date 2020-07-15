using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
    public class PackagePaymentMode : Page
    {
        protected RadioButtonList rdButton;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void rdButton_CheckedChanged(object sender, EventArgs e)
        {
            if (rdButton.SelectedValue == "0")
            {
                this.Response.Redirect(string.Format("PackagePaymentIOPayer.aspx?id={0}&type={1}", this.Request.QueryString["id"], this.Request.QueryString["type"]));
            }
            else
            {
                this.Response.Redirect(string.Format("PackagePaymentPayPalPayer.aspx?id={0}&type={1}", this.Request.QueryString["id"], this.Request.QueryString["type"]));
            }
        }
    }
}

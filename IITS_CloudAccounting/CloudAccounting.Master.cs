using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DABL.BLL;
using DABL.DAL;

namespace IITS_CloudAccounting
{
    public partial class CloudAccounting : System.Web.UI.MasterPage
    {
        private readonly ContactMasterBLL _objContactMasterBll = new ContactMasterBLL();
        private CloudAccountDA.ContactMasterDataTable _objContactMasterDt = new CloudAccountDA.ContactMasterDataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            this._objContactMasterDt = this._objContactMasterBll.GetAllDetail();
            if (this._objContactMasterDt.Rows.Count > 0)
            {
                //string str = this._objContactMasterDt.Rows.get_Item(0).get_Item("Phone1").ToString();
                string str = this._objContactMasterDt.Rows[0]["Phone1"].ToString();
                string str2 = this._objContactMasterDt.Rows[0]["Email1"].ToString();
                string str3 = string.Concat((string[])new string[] { "<li>Call Us Now. : <a href=\"tele:", str, "\">", str, "</a></li><li>Get In Touch. : <a href=\"mailto:", str2, "\">", str2, "</a></li>" });
                this.lblContact.Text = str3;
            }
        }
    }
}
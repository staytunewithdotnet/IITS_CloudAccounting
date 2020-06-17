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
    public partial class Default : System.Web.UI.Page
    {

        private readonly CurrencyMasterBLL objCurrencyMasterBll = new CurrencyMasterBLL();
        private CloudAccountDA.CurrencyMasterDataTable objCurrencyMasterDT = new CloudAccountDA.CurrencyMasterDataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            //SliderControl control = base.LoadControl("SliderControl.ascx") as SliderControl;
            if (base.Master != null)
            {
                //HtmlControl control2 = (HtmlControl)base.Master.FindControl("home");
                //control2.Attributes.Add("class", "current-menu-item current-menu-ancestor");
                //HtmlControl control3 = (HtmlControl)base.Master.FindControl("s");
                ////if (control != null)
                //{
                //    //control3.Controls.Add(control);
                //}
            }
        }

        protected string GetCurrency(string cID)
        {
            this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(cID));
            if (this.objCurrencyMasterDT.Rows.Count > 0)
            {
                return this.objCurrencyMasterDT.Rows[0]["CurrencySymbol"].ToString();
            }
            return "";
        }

        protected string SetIconTrueFalse(bool icon)
        {
            if (icon)
            {
                return "<i class=\"fa fa-check-circle\" title=\"Yes\" style=\"font-size: 30px;\"></i>";
            }
            return "<i class=\"fa fa-exclamation-circle\" title=\"No\" style=\"font-size: 30px;\"></i>";
        }

        protected string SetIconValue(string value)
        {
            switch (value)
            {
                case "True":
                    return "<i class=\"fa fa-check\" style=\"font-size: 20px;\"></i>";

                case "False":
                    return "<i class=\"fa fa-remove\" style=\"color: red;font-size: 20px;\"></i>";
            }
            return value;
        }
    }
}
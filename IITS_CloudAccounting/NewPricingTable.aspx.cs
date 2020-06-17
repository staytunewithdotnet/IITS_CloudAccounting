// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.NewPricingTable
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using DABL.BLL;
using DABL.DAL;
using IITS_CloudAccounting.com.mobiletranzact.www;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting
{
    public class NewPricingTable : Page
    {
        private readonly CurrencyMasterBLL objCurrencyMasterBll = new CurrencyMasterBLL();
        private CloudAccountDA.CurrencyMasterDataTable objCurrencyMasterDT = new CloudAccountDA.CurrencyMasterDataTable();
        private readonly MobileTranzactServiceSoapClient objMobileTranzactService = new MobileTranzactServiceSoapClient();
        protected Button btnClick;
        protected DataList dlPackageModuleOuter;
        protected SqlDataSource sqldsPackageModuleOuter;
        protected Repeater rpPackage;
        protected SqlDataSource sqldsPackage;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Master == null)
                return;
            ((HtmlControl)this.Master.FindControl("pricing")).Attributes.Add("class", "current-menu-item current-menu-ancestor");
        }

        public void DisplayAlert(string message)
        {
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">" + this.GetAlertScript(message) + "</script>");
        }

        public string GetAlertScript(string message)
        {
            return "alert('" + message.Replace("'", "\\'") + "');";
        }

        protected string GetCurrency(string cID)
        {
            this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(cID));
            if (this.objCurrencyMasterDT.Rows.Count > 0)
                return this.objCurrencyMasterDT.Rows[0]["CurrencySymbol"].ToString();
            return "";
        }

        protected string SetIconValue(string value)
        {
            switch (value)
            {
                case "True":
                    return "<i class=\"fa fa-check\" style=\"font-size: 20px;\"></i>";
                case "False":
                    return "<i class=\"fa fa-remove\" style=\"color: red;font-size: 20px;\"></i>";
                default:
                    return value;
            }
        }

        protected void btnClick_Click(object sender, EventArgs e)
        {
            string CardTransactionID = (string)null;
            long ErrorNo = 0L;
            string ErrorDesc = (string)null;
            this.DisplayAlert((string)(object)((bool)(this.objMobileTranzactService.MakeOrderPayment(ref CardTransactionID, "12345678901234", "1234", "1", "Mobile Tranzact", "1", "Mobile Tranzact Debit", "2", "10", "Uniq123", ref ErrorNo, ref ErrorDesc)) ? 1 : 0) + (object)" id: " + CardTransactionID + " code: " + (string)(object)ErrorNo + " desc:" + ErrorDesc + " ");

        }
    }
}

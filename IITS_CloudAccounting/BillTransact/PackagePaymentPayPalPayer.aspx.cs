using DABL.BLL;
using DABL.Common;
using DABL.DAL;
using System;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
    public class PackagePaymentPayPalPayer : Page
    {
        private readonly CurrencyMasterBLL objCurrencyMasterBll = new CurrencyMasterBLL();
        private CloudAccountDA.CurrencyMasterDataTable objCurrencyMasterDT = new CloudAccountDA.CurrencyMasterDataTable();

        private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
        private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
        private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
        private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();

        private readonly CompanyPaypalMasterBLL objCompanyPaypalMasterBll = new CompanyPaypalMasterBLL();
        private CloudAccountDA.CompanyPaypalMasterDataTable objCompanyPaypalMasterDT = new CloudAccountDA.CompanyPaypalMasterDataTable();
        protected HiddenField hfCompanyID, hCloudPackageType;

        protected Label lblPaymentAmount;
        Dbutility objDbutility = new Dbutility(); string query;string amount;
        DataTable dtCloudPackageMaster = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            MembershipUser user = Membership.GetUser();
            if (user != null)
            {
                string str = user.ToString();
                if (Roles.IsUserInRole(str, "Admin"))
                {
                    this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(str);
                    if (this.objCompanyLoginMasterDT.Rows.Count > 0)
                        this.hfCompanyID.Value = this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString();
                }
                else if (Roles.IsUserInRole(str, "Employee"))
                {
                    this.objStaffMasterDT = this.objStaffMasterBll.GetDataByStaffUserName(str);
                    if (this.objStaffMasterDT.Rows.Count > 0)
                        this.hfCompanyID.Value = this.objStaffMasterDT.Rows[0]["CompanyID"].ToString();
                }
                Dbutility objDbutility = new Dbutility();
                query = string.Format("SELECT CloudPackageID,CloudPackageName,CloudPackagePriceMonthly,CloudPackagePriceYearly,CloudPackageCurrency FROM CloudPackageMaster " +
                    " Where CloudPackageID={0}", this.Request.QueryString["id"]);
                dtCloudPackageMaster = objDbutility.BindDataTable(query);
                if (dtCloudPackageMaster?.Rows.Count > 0)
                {
                    hCloudPackageType.Value = Convert.ToString(dtCloudPackageMaster.Rows[0]["CloudPackageName"]);
                    if (this.Request.QueryString["type"] == "M")
                    {
                        amount = Convert.ToString(dtCloudPackageMaster.Rows[0]["CloudPackagePriceMonthly"]);
                        lblPaymentAmount.Text = String.Format("{0:0.00}", dtCloudPackageMaster.Rows[0]["CloudPackagePriceMonthly"]);
                    }
                    else
                    {
                        amount = Convert.ToString(dtCloudPackageMaster.Rows[0]["CloudPackagePriceMonthly"]);
                        lblPaymentAmount.Text = String.Format("{0:0.00}", dtCloudPackageMaster.Rows[0]["CloudPackagePriceYearly"]);
                    }
                    lblPaymentAmount.Text = String.Format("{0} {1}", GetCurrency(Convert.ToString(dtCloudPackageMaster.Rows[0]["CloudPackageCurrency"])),
                        lblPaymentAmount.Text);
                }
            }
        }

        protected void btnPay_Click(object sender, ImageClickEventArgs e)
        {
            string str1 = "https://www.paypal.com/cgi-bin/webscr?cmd=_xclick";
            this.objCompanyPaypalMasterDT = this.objCompanyPaypalMasterBll.GetDataByCompanyID(Convert.ToInt32(this.hfCompanyID.Value));
            if (this.objCompanyPaypalMasterDT.Rows.Count > 0)
            {
                int num = (this.Request.QueryString["type"] == "Y") ? 365 : 30;
                query = String.Format("SELECT COMPANYID FROM COMPANYPACKAGEMASTER WHERE COMPANYID={0}; ", this.hfCompanyID.Value);
                dtCloudPackageMaster = objDbutility.BindDataTable(query);
                if (dtCloudPackageMaster?.Rows.Count > 0)
                {
                    query = " Update c Set c.CloudPackageID={1},c.PackageStartDate='{2}',c.PackageEndDate='{3}',c.PackageType='{4}', " +
                        " c.PackageAmount={5},c.PackagePaymentTransDetail='{6}',c.PackagePaymentTransDate='{7}',c.PackageAssignDate='{8}',c.ActivePackage='{9}' " +
                        " From CompanyPackageMaster c Where c.CompanyID={0}; ";
                }
                else
                {
                    query = "Insert Into CompanyPackageMaster (CompanyID,CloudPackageID,PackageStartDate,PackageEndDate, " +
                        "PackageType,PackageAmount,PackagePaymentTransDetail,PackagePaymentTransDate,PackageAssignDate, ActivePackage) " +
                        " Select {0},{1},'{2}','{3}','{4}',{5},'{6}','{7}','{8}','{9}' ";

                }
                query = string.Format(query, this.hfCompanyID.Value, this.Request.QueryString["id"], new DateTime?(DateTime.Now), new DateTime?(DateTime.Now.AddDays((double)num)),
                       hCloudPackageType.Value, new Decimal?(Decimal.Parse(amount)), "Pay by PayPal", new DateTime?(DateTime.Now), new DateTime?(DateTime.Now), true);
                objDbutility.ExecuteQuery(query);

                string invoiceno = DateTime.Now.ToString("dd MM yyyy HH:mm:ss");
                invoiceno = invoiceno.Replace(":", string.Empty);
                invoiceno = Regex.Replace(invoiceno, "\\s", string.Empty);
                string str2 = str1 + (object)"&business=" + (string)this.objCompanyPaypalMasterDT.Rows[0]["PaypalID"];
                str2 = str2 + "&item_name=invoice no: " + invoiceno;
                if (!string.IsNullOrEmpty(amount))
                    str2 = str2 + "&amount=" + amount;
                this.Response.Redirect(str2 + "&return=" + ConfigurationManager.AppSettings["SuccessClientURL"] + "&cancel_return=" + ConfigurationManager.AppSettings["FailedClientURL"]);
            }
        }
              
        private string GetCurrency(string cID)
        {
            this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(cID));
            if (this.objCurrencyMasterDT.Rows.Count > 0)
                return this.objCurrencyMasterDT.Rows[0]["CurrencySymbol"].ToString();
            return "";
        }
    }
}

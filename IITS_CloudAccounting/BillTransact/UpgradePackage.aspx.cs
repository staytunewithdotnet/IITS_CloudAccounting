// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.UpgradePackage
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using IITS_CloudAccounting.com.mobiletranzact.www;
using System;
using System.Configuration;
using System.Drawing;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
    public class UpgradePackage : Page
    {
        private readonly CurrencyMasterBLL objCurrencyMasterBll = new CurrencyMasterBLL();
        private CloudAccountDA.CurrencyMasterDataTable objCurrencyMasterDT = new CloudAccountDA.CurrencyMasterDataTable();
        private readonly CompanyPaymentMasterBLL objCompanyPaymentMasterBll = new CompanyPaymentMasterBLL();
        private readonly CloudPackageMasterBLL objCloudPackageMasterBll = new CloudPackageMasterBLL();
        private CloudAccountDA.CloudPackageMasterDataTable objCloudPackageMasterDT = new CloudAccountDA.CloudPackageMasterDataTable();
        private readonly CompanyPackageMasterBLL objCompanyPackageMasterBll = new CompanyPackageMasterBLL();
        private CloudAccountDA.CompanyPackageMasterDataTable objCompanyPackageMasterDT = new CloudAccountDA.CompanyPackageMasterDataTable();
        private readonly ContactMasterBLL _objContactMasterBll = new ContactMasterBLL();
        private CloudAccountDA.ContactMasterDataTable _objContactMasterDt = new CloudAccountDA.ContactMasterDataTable();
        private readonly PaymentGatewayPaypalMasterBLL objPaymentGatewayPaypalMasterBll = new PaymentGatewayPaypalMasterBLL();
        private CloudAccountDA.PaymentGatewayPaypalMasterDataTable objPaymentGatewayPaypalMasterDT = new CloudAccountDA.PaymentGatewayPaypalMasterDataTable();
        private readonly PaymentGatewayMasterBLL objPaymentGatewayMasterBll = new PaymentGatewayMasterBLL();
        private CloudAccountDA.PaymentGatewayMasterDataTable objPaymentGatewayMasterDT = new CloudAccountDA.PaymentGatewayMasterDataTable();
        private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
        private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
        private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
        private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
        private readonly MobileTranzactServiceSoapClient objMobileTranzactService = new MobileTranzactServiceSoapClient();
        protected HtmlLink switcherstylecss;
        protected HtmlLink fontawesomecss;
        protected HtmlLink bootstrapcss;
        protected HtmlLink css3animationscss;
        protected HtmlLink stylecss;
        protected HtmlLink skinscss;
        protected HtmlLink responsivecss;
        protected HtmlLink js_composer_front_css;
        protected HtmlLink js_composer_custom_css_css;
        protected HtmlForm form1;
        protected ToolkitScriptManager tsm;
        protected Label lblContact;
        protected HtmlGenericControl s;
        protected Label lblBack;
        protected Label lblError;
        protected DataList dlPackageModuleOuter;
        protected SqlDataSource sqldsPackageModuleOuter;
        protected Repeater rpPackage;
        protected SqlDataSource sqldsPackage;
        protected DataList dlFooter;
        protected SqlDataSource sqldsFooter;
        protected Panel pnlPackage;
        protected RadioButton rbMobile;
        protected RadioButton rbPaypal;
        protected Label lblPackageName1;
        protected RadioButton rblMonth1;
        protected Label lblPriceMonth1;
        protected RadioButton rblYear1;
        protected Label lblPriceYear1;
        protected ImageButton btnPay;
        protected HiddenField hfPackageID;
        protected Label lblPackageName;
        protected TextBox txtCardNo;
        protected RequiredFieldValidator rfvCardNo;
        protected TextBox txtPinNo;
        protected RequiredFieldValidator rfvPinNo;
        protected RadioButton rblMonth;
        protected Label lblPriceMonth;
        protected RadioButton rblYear;
        protected Label lblPriceYear;
        protected Button btnSubmit;
        protected LinkButton lnkbtnClose;
        protected HiddenField hfCompanyID;

        protected void Page_Load(object sender, EventArgs e)
        {
            this._objContactMasterDt = this._objContactMasterBll.GetAllDetail();
            if (this._objContactMasterDt.Rows.Count > 0)
            {
                string str1 = this._objContactMasterDt.Rows[0]["Phone1"].ToString();
                string str2 = this._objContactMasterDt.Rows[0]["Email1"].ToString();
                this.lblContact.Text = "<li>Call Us Now. : <a href=\"tele:" + str1 + "\">" + str1 + "</a></li><li>Get In Touch. : <a href=\"mailto:" + str2 + "\">" + str2 + "</a></li>";
            }
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
            }
            this.objCompanyPackageMasterDT = this.objCompanyPackageMasterBll.GetDataByCompanyActivePackage(int.Parse(this.hfCompanyID.Value));
            if (this.objCompanyPackageMasterDT.Rows.Count <= 0)
                return;
            this.lblBack.Visible = (DateTime.Parse(DateTime.Parse(this.objCompanyPackageMasterDT.Rows[0]["PackageEndDate"].ToString()).ToShortDateString()) - DateTime.Parse(DateTime.UtcNow.ToShortDateString())).TotalDays > 0.0;
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
            this.lblError.Text = "";
            Button button = (Button)sender;
            this.hfPackageID.Value = button.CommandArgument;
            this.lblPackageName1.Text = this.lblPackageName.Text = button.ToolTip;
            if (string.IsNullOrEmpty(this.hfPackageID.Value))
                return;
            this.objCloudPackageMasterDT = this.objCloudPackageMasterBll.GetDataByCloudPackageID(int.Parse(this.hfPackageID.Value));
            if (this.objCloudPackageMasterDT.Rows.Count <= 0)
                return;
            this.lblPriceMonth1.Text = this.lblPriceMonth.Text = this.objCloudPackageMasterDT.Rows[0]["CloudPackagePriceMonthly"].ToString();
            this.lblPriceYear1.Text = this.lblPriceYear.Text = this.objCloudPackageMasterDT.Rows[0]["CloudPackagePriceYearly"].ToString();
        }

        public void DisplayAlert(string message)
        {
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">" + this.GetAlertScript(message) + "</script>");
        }

        public string GetAlertScript(string message)
        {
            return "alert('" + message.Replace("'", "\\'") + "');";
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            string CardTransactionID = (string)null;
            long ErrorNo = 0L;
            string ErrorDesc = (string)null;
            this.lblError.Text = "";
            string MerchantID = "1";
            string MerchantAuthkey = "Mobile Tranzact";
            string TransactionTypeID = "2";
            string TransactionAuthkey = "Mobile Tranzact Debit";
            this.objPaymentGatewayMasterDT = this.objPaymentGatewayMasterBll.GetAllDetail();
            if (this.objPaymentGatewayMasterDT.Rows.Count > 0)
            {
                MerchantID = this.objPaymentGatewayMasterDT.Rows[0]["MerchantID"].ToString();
                MerchantAuthkey = this.objPaymentGatewayMasterDT.Rows[0]["MerchantAuthkey"].ToString();
                TransactionTypeID = this.objPaymentGatewayMasterDT.Rows[0]["TransactionTypeID"].ToString();
                TransactionAuthkey = this.objPaymentGatewayMasterDT.Rows[0]["TransactionAuthkey"].ToString();
            }
            string str1 = this.rblYear.Checked ? this.lblPriceYear.Text : this.lblPriceMonth.Text;
            int num = this.rblYear.Checked ? 365 : 30;
            string sPackageType = this.rblYear.Checked ? "Yearly" : "Monthly";
            int iCompanyPaymentID = this.objCompanyPaymentMasterBll.AddCompanyPayment(int.Parse(this.hfCompanyID.Value), int.Parse(this.hfPackageID.Value), Decimal.Parse(str1), "Pending", "", "", "Pay by Mobiletranzact");
            bool flag = this.objMobileTranzactService.MakeOrderPayment(ref CardTransactionID, this.txtCardNo.Text, this.txtPinNo.Text, MerchantID, MerchantAuthkey, TransactionTypeID, TransactionAuthkey, this.hfPackageID.Value, str1, iCompanyPaymentID.ToString(), ref ErrorNo, ref ErrorDesc);
            string str2 = (string)(object)((bool)(flag) ? 1 : 0) + (object)" cardTranid: " + CardTransactionID + " code: " + (string)(object)ErrorNo + " desc: " + ErrorDesc + " \n PackageId: " + this.hfPackageID.Value + " Package Name: " + this.lblPackageName.Text;
            if (flag && !string.IsNullOrEmpty(CardTransactionID))
            {
                this.objCompanyPackageMasterBll.UpdateCompanyPackages(int.Parse(this.hfCompanyID.Value));
                this.objCompanyPackageMasterBll.AddCompanyPackage(int.Parse(this.hfCompanyID.Value), int.Parse(this.hfPackageID.Value), new DateTime?(DateTime.Now), new DateTime?(DateTime.Now.AddDays((double)num)), sPackageType, new Decimal?(Decimal.Parse(str1)), "Pay by Mobiletranzact", new DateTime?(DateTime.Now), new DateTime?(DateTime.Now), true);
                this.objCompanyPaymentMasterBll.UpdateAfterPayment(iCompanyPaymentID, "Completed", ErrorNo.ToString(), ErrorDesc);
                this.lblError.Text = this.lblPackageName.Text + " Package Sucessfully Upgrade by you.";
                this.lblError.ForeColor = Color.Green;
            }
            else
            {
                this.lblError.Text = str2.Replace("\n", "<br />");
                this.lblError.ForeColor = Color.Red;
            }
        }

        protected void rpPackage_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (!(e.CommandName == "openPopup"))
                return;
            ModalPopupExtender modalPopupExtender = (ModalPopupExtender)e.Item.FindControl("mpPackage");
            //RepeaterItem item = (source as Button).NamingContainer as RepeaterItem;
            //LinkButton button = (LinkButton)item.FindControl("btnClick");
            //this.lblError.Text = "";
            //if (button.CommandArgument != null)
            //    this.hfPackageID.Value = button.CommandArgument;
            //this.lblPackageName1.Text = this.lblPackageName.Text = button.ToolTip;
            //if (!string.IsNullOrEmpty(this.hfPackageID.Value))
            //{
            //    this.objCloudPackageMasterDT = this.objCloudPackageMasterBll.GetDataByCloudPackageID(int.Parse(this.hfPackageID.Value));
            //    if (this.objCloudPackageMasterDT.Rows.Count > 0)
            //    {
            //        this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(this.objCloudPackageMasterDT.Rows[0]["CloudPackageCurrency"].ToString()));
            //        this.lblPriceMonth1.Text = this.lblPriceMonth.Text = (string)this.objCurrencyMasterDT.Rows[0]["CurrencySymbol"] + (object)" " + (string)this.objCloudPackageMasterDT.Rows[0]["CloudPackagePriceMonthly"];
            //        this.lblPriceYear1.Text = this.lblPriceYear.Text = (string)this.objCurrencyMasterDT.Rows[0]["CurrencySymbol"] + (object)" " + (string)this.objCloudPackageMasterDT.Rows[0]["CloudPackagePriceYearly"];
            //    }
            //}
            modalPopupExtender.Show();
        }

        protected void btnPay_Click(object sender, ImageClickEventArgs e)
        {
            string str1 = "https://www.paypal.com/cgi-bin/webscr?cmd=_xclick";
            this.objPaymentGatewayPaypalMasterDT = this.objPaymentGatewayPaypalMasterBll.GetAllDetail();
            string str2 = this.objPaymentGatewayPaypalMasterDT.Rows.Count <= 0 ? str1 + "&business=info@DoyinGo.com" : str1 + (object)"&business=" + (string)this.objPaymentGatewayPaypalMasterDT.Rows[0]["PaypalID"];
            if (!string.IsNullOrEmpty(this.lblPackageName.Text))
                str2 = str2 + "&item_name=" + this.lblPackageName.Text;
            if (this.rblMonth1.Checked)
            {
                if (!string.IsNullOrEmpty(this.lblPriceMonth.Text))
                    str2 = str2 + "&amount=" + this.lblPriceMonth.Text;
            }
            else if (this.rblYear1.Checked && !string.IsNullOrEmpty(this.lblPriceYear.Text))
                str2 = str2 + "&amount=" + this.lblPriceYear.Text;
            this.Response.Redirect(str2 + "&return=" + ConfigurationManager.AppSettings["SuccessAdminURL"] + "&cancel_return=" + ConfigurationManager.AppSettings["FailedAdminURL"]);
        }
    }
}

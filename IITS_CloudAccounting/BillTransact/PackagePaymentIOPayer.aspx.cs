using DABL.BLL;
using DABL.Common;
using DABL.DAL;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Web.UI;

namespace IITS_CloudAccounting.Admin
{
    public class PackagePaymentIOPayer : Page
    {
        private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
        private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
        private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
        private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();

        private readonly CompanyPaypalMasterBLL objCompanyPaypalMasterBll = new CompanyPaypalMasterBLL();
        private CloudAccountDA.CompanyPaypalMasterDataTable objCompanyPaypalMasterDT = new CloudAccountDA.CompanyPaypalMasterDataTable();

        string query; string companyId; string amount;
        DataTable dtCloudPackageMaster = new DataTable();
        DataTable dtCompanyPackageMaster = new DataTable();
        Dbutility objDbutility = new Dbutility();

        protected void Page_Load(object sender, EventArgs e)
        {
            MembershipUser user = Membership.GetUser();
            if (user != null)
            {
                query = user.ToString();
                if (Roles.IsUserInRole(query, "Admin"))
                {
                    this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(query);
                    if (this.objCompanyLoginMasterDT.Rows.Count > 0)
                        companyId = this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString();
                }
                else if (Roles.IsUserInRole(query, "Employee"))
                {
                    this.objStaffMasterDT = this.objStaffMasterBll.GetDataByStaffUserName(query);
                    if (this.objStaffMasterDT.Rows.Count > 0)
                        companyId = this.objStaffMasterDT.Rows[0]["CompanyID"].ToString();
                }
                query = string.Format("SELECT CloudPackageID,CloudPackageName,CloudPackagePriceMonthly,CloudPackagePriceYearly FROM CloudPackageMaster " +
                    " Where CloudPackageID={0}", this.Request.QueryString["id"]);
                dtCloudPackageMaster = objDbutility.BindDataTable(query);
                
                if (dtCloudPackageMaster?.Rows.Count > 0)
                {
                    if (this.Request.QueryString["type"] == "M")
                    {
                        amount = String.Format("{0:0.00}", dtCloudPackageMaster.Rows[0]["CloudPackagePriceMonthly"]);
                    }
                    else
                    {
                        amount = String.Format("{0:0.00}", dtCloudPackageMaster.Rows[0]["CloudPackagePriceYearly"]);
                    }

                    int num = (this.Request.QueryString["type"] == "Y") ? 365 : 30;
                    query = String.Format("SELECT COMPANYID FROM COMPANYPACKAGEMASTER WHERE COMPANYID={0}; ", companyId);
                    dtCompanyPackageMaster = objDbutility.BindDataTable(query);
                    if (dtCompanyPackageMaster?.Rows.Count > 0)
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

                    query = string.Format(query, companyId, this.Request.QueryString["id"], new DateTime?(DateTime.Now), new DateTime?(DateTime.Now.AddDays((double)num)),
                        Convert.ToString(dtCloudPackageMaster.Rows[0]["CloudPackageName"]), new Decimal?(Decimal.Parse(amount))
                        , "Pay by Billtransact", new DateTime?(DateTime.Now), new DateTime?(DateTime.Now), true);
                    objDbutility.ExecuteQuery(query);
                }
            }

            var request = (HttpWebRequest)WebRequest.Create("http://www.iopayer.com/iopg/IOPayerPaymentGateway.aspx");
            objDbutility = new Dbutility();
            string str = "  Select ProductID,MerchantID,MerchantAuthkey,TransactionTypeID,TransactionAuthkey From PaymentGatewayIOPayer Where PaymentGatewayID=1";
            DataTable dtIOPayerMaster = objDbutility.BindDataTable(str);
            if (dtIOPayerMaster?.Rows.Count > 0)
            {
                str = Convert.ToString(dtIOPayerMaster.Rows[0]["MerchantID"]);
                string postData = "MerchantID=" + Uri.EscapeDataString(str);

                str = Convert.ToString(dtIOPayerMaster.Rows[0]["ProductID"]);
                postData += "&ProductID=" + Uri.EscapeDataString(str);

                str = Convert.ToString(dtIOPayerMaster.Rows[0]["TransactionTypeID"]);
                postData += "&TransactionTypeID=" + Uri.EscapeDataString(str);

                str = Convert.ToString(dtIOPayerMaster.Rows[0]["MerchantAuthkey"]);
                postData += "&MerchantAuthKey=" + Uri.EscapeDataString(str);

                str = Convert.ToString(dtIOPayerMaster.Rows[0]["TransactionAuthkey"]);
                postData += "&TranAuthKey=" + Uri.EscapeDataString(str);

                postData += "&OrderAmount=" + Uri.EscapeDataString(amount);
                postData += "&ReturnURL=" + Uri.EscapeDataString(ConfigurationManager.AppSettings["SuccessClientURL"]);

                string invoiceno = DateTime.Now.ToString("dd MM yyyy HH:mm:ss");
                invoiceno = invoiceno.Replace(":", string.Empty);
                invoiceno = Regex.Replace(invoiceno, "\\s", string.Empty);
                postData += "&OrderNo=" + Uri.EscapeDataString(invoiceno);

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
            else
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(),
                    "<script language=\"JavaScript\">" + "alert('IO Payer Master detail not found!');" + "</script>");
            }
        }
                
    }
}

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
    public class PaymentSuccess : Page
    {
        protected Image imgLogo;
        private readonly CompanyClientMasterBLL objClientMasterBll = new CompanyClientMasterBLL();
        private CloudAccountDA.CompanyClientMasterDataTable objClientMasterDT = new CloudAccountDA.CompanyClientMasterDataTable();
        private readonly CompanyClientContactDetailBLL objCompanyClientContactDetailBll = new CompanyClientContactDetailBLL();
        private CloudAccountDA.CompanyClientContactDetailDataTable objCompanyClientContactDetailDT = new CloudAccountDA.CompanyClientContactDetailDataTable();
        private readonly ClientPermissionMasterBLL objClientPermissionMasterBll = new ClientPermissionMasterBLL();
        private CloudAccountDA.ClientPermissionMasterDataTable objClientPermissionMasterDT = new CloudAccountDA.ClientPermissionMasterDataTable();
        private string query;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MembershipUser user = Membership.GetUser();
                if (user != null)
                {
                    this.objClientMasterDT = this.objClientMasterBll.GetDataByUsername(user.ToString());
                    if (this.objClientMasterDT.Rows.Count > 0)
                    {
                        query = this.objClientMasterDT.Rows[0]["CompanyID"].ToString();
                    }
                    else
                    {
                        this.objCompanyClientContactDetailDT = this.objCompanyClientContactDetailBll.GetDataByUsername(user.ToString());
                        if (this.objCompanyClientContactDetailDT.Rows.Count > 0)
                        {
                            query = this.objCompanyClientContactDetailDT.Rows[0]["CompanyID"].ToString();
                        }
                    }
                    SetCompanyLogo(query);
                }
                if (Request.UrlReferrer != null)
                {
                    query = HttpUtility.ParseQueryString(Request.UrlReferrer.Query)["Status"];
                    if (query.ToLower() == "success")
                    {
                        query = HttpUtility.ParseQueryString(Request.UrlReferrer.Query)["OrderNo"];
                        Dbutility dbutility = new Dbutility();
                        query = dbutility.ExecuteQuery("Update InvoiceMaster Set InvoiceStatus='paid' Where OrderNo='" + query + "'");
                    }
                }
            }
        }

        private void SetCompanyLogo(string companyId)
        {
            //if (!string.IsNullOrEmpty(companyId))
            //    this.imgLogo.ImageUrl = "../Handler/CompanyLogoFile.ashx?id=" + companyId;
            //else
            //    this.imgLogo.ImageUrl = "../App_Themes/Blue/images/logo.jpg";
            this.imgLogo.ImageUrl = "../App_Themes/Blue/images/defaultlogo.png";
            
        }

    }
}

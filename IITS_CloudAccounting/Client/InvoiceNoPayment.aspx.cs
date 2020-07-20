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
    public class InvoiceNoPayment : Page
    {
        protected Image imgLogo;      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SetCompanyLogo(this.Request.QueryString["companyid"]);
                            
            }
        }

        private void SetCompanyLogo(string companyId)
        {
            if (!string.IsNullOrEmpty(companyId))
                this.imgLogo.ImageUrl = "../Handler/CompanyLogoFile.ashx?id=" + companyId;
            else
                this.imgLogo.ImageUrl = "../App_Themes/Blue/images/logo.jpg";
        }

    }
}

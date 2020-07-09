// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.CompanyPaypalMaster
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using DABL.BLL;
using DABL.Common;
using DABL.DAL;
using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
    public class CompanyIOPayerMaster : Page
    {
        private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
        private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
        protected Button btnSave;

        protected TextBox txtProductID;
        protected TextBox txtMerchantID; protected TextBox txtMerchantAuthkey;
        protected TextBox txtTransactionTypeID; protected TextBox txtTransactionAuthkey;
        protected HiddenField hfCompanyID;
        private Dbutility objDbutility; string query; DataTable dtCompanyIOMaster;

        protected void Page_Load(object sender, EventArgs e)
        {
            objDbutility = new Dbutility();
            if (this.Master == null)
                return;
            ((HtmlControl)this.Master.FindControl("setting")).Attributes.Add("style", "background-color: lightgray;");
            ((HtmlControl)this.Master.FindControl("ioSetting")).Attributes.Add("class", "active open");
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
            }
            if (this.IsPostBack)
                return;

            this.SetCompanyRecords(this.hfCompanyID.Value);
        }

        private void SetCompanyRecords(string companyID)
        {
            query = " Select ProductID,MerchantID,MerchantAuthkey,TransactionTypeID,TransactionAuthkey " +
                "From CompanyIOPayerMaster Where CompanyID='" + this.hfCompanyID.Value.Trim() + "'";
            dtCompanyIOMaster = objDbutility.BindDataTable(query);
            if (dtCompanyIOMaster.Rows.Count > 0)
            {
                txtProductID.Text = Convert.ToString(dtCompanyIOMaster.Rows[0]["ProductID"]);
                txtMerchantID.Text = Convert.ToString(dtCompanyIOMaster.Rows[0]["MerchantID"]);
                txtMerchantAuthkey.Text = Convert.ToString(dtCompanyIOMaster.Rows[0]["MerchantAuthkey"]);
                txtTransactionTypeID.Text = Convert.ToString(dtCompanyIOMaster.Rows[0]["TransactionTypeID"]);
                txtTransactionAuthkey.Text = Convert.ToString(dtCompanyIOMaster.Rows[0]["TransactionAuthkey"]);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            query = " Select CompanyID From CompanyIOPayerMaster Where CompanyID=" + this.hfCompanyID.Value.Trim();
            try
            {
                dtCompanyIOMaster = objDbutility.BindDataTable(query);
                if (dtCompanyIOMaster?.Rows.Count > 0)
                {
                    query = "Update CompanyIOPayerMaster Set ProductID='{0}',MerchantID='{1}'," +
                        "MerchantAuthkey='{2}',TransactionTypeID='{3}',TransactionAuthkey='{4}' Where CompanyID={5} ";
                    query = string.Format(query, txtProductID.Text.Trim(), txtMerchantID.Text.Trim(), txtMerchantAuthkey.Text.Trim(),
                       txtTransactionTypeID.Text.Trim(), txtTransactionAuthkey.Text.Trim(), hfCompanyID.Value.Trim());
                    query = objDbutility.ExecuteQuery(query);
                }
                else
                {
                    query = "Insert Into CompanyIOPayerMaster (CompanyID,ProductID,MerchantID,MerchantAuthkey,TransactionTypeID,TransactionAuthkey)" +
                        " Select {0},'{1}','{2}','{3}','{4}','{5}' ";
                    query = string.Format(query, hfCompanyID.Value.Trim(), txtProductID.Text.Trim(), txtMerchantID.Text.Trim(), txtMerchantAuthkey.Text.Trim(),
                       txtTransactionTypeID.Text.Trim(), txtTransactionAuthkey.Text.Trim());
                    query = objDbutility.ExecuteQuery(query);
                }

                if (string.IsNullOrEmpty(query))
                {
                    this.DisplayAlert("Details Added Successfully.");
                    this.Response.Redirect("CompanyIOPayerMaster.aspx");
                }
                else
                    this.DisplayAlert("Fail to Save Details.");
            }
            catch (Exception ex)
            {
                this.DisplayAlert("Error :" + (object)ex);
            }
        }

        public void DisplayAlert(string message)
        {
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">" + this.GetAlertScript(message) + "</script>");
        }

        public string GetAlertScript(string message)
        {
            return "alert('" + message.Replace("'", "\\'") + "');";
        }
    }
}

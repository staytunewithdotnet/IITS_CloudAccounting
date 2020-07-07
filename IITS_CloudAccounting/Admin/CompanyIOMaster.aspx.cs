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
    public class CompanyIOMaster : Page
    {
        private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
        private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
        protected Button btnSave;

        protected TextBox txtCardNo; protected TextBox txtPINNo;
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
            query = " Select CardNumber,PinNumber From CompanyIOMaster Where CompanyID='" + this.hfCompanyID.Value.Trim() + "'";
            dtCompanyIOMaster = objDbutility.BindDataTable(query);
            if (dtCompanyIOMaster.Rows.Count > 0)
            {
                txtCardNo.Text = Convert.ToString(dtCompanyIOMaster.Rows[0]["CardNumber"]);
                txtPINNo.Text = Convert.ToString(dtCompanyIOMaster.Rows[0]["PinNumber"]);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            query = " Select CardNumber,PinNumber From CompanyIOMaster Where CompanyID=" + this.hfCompanyID.Value.Trim() ;
            dtCompanyIOMaster = objDbutility.BindDataTable(query);
            if (dtCompanyIOMaster?.Rows.Count > 0)
            {
                query = "Update CompanyIOMaster Set CardNumber='" + txtCardNo.Text.Trim() + "', PinNumber='"
                                    + txtPINNo.Text.Trim() + "' Where CompanyID=" + hfCompanyID.Value.Trim();
                query = objDbutility.ExecuteQuery(query);
            }
            else
            {
                query = "Insert Into CompanyIOMaster Select " + hfCompanyID.Value.Trim() + ",'" + txtCardNo.Text.Trim() + "','" + txtPINNo.Text.Trim() + "'";
                query = objDbutility.ExecuteQuery(query);
            }
                
            if (string.IsNullOrEmpty(query))
            {
                this.Response.Redirect("CompanyIOMaster.aspx");
            }
        }
    }
}

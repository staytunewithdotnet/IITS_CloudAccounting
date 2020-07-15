// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.CompanySignUp
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using IITS_CloudAccounting.Admin;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting
{
    public class CompanySignUp : Page
    {
        private readonly UserBLL objUserBll = new UserBLL();
        private CloudAccountDA.aspnet_UsersDataTable objUserDT = new CloudAccountDA.aspnet_UsersDataTable();
        private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
        private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
        private readonly FreePackageSettingsBLL objFreePackageSettingsBll = new FreePackageSettingsBLL();
        private CloudAccountDA.FreePackageSettingsDataTable objFreePackageSettingsDT = new CloudAccountDA.FreePackageSettingsDataTable();
        private readonly ContactMasterBLL _objContactMasterBll = new ContactMasterBLL();
        private CloudAccountDA.ContactMasterDataTable _objContactMasterDt = new CloudAccountDA.ContactMasterDataTable();
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
        protected UpdatePanel upChecking;
        protected TextBox txtCompanyName;
        protected RequiredFieldValidator rfvCompanyName;
        protected TextBox txtEmailAddress;
        protected RequiredFieldValidator rfvEmail;
        protected RegularExpressionValidator revtxtEmailAddress;
        protected Button btnSubmit;
        protected DataList dlFooter;
        protected SqlDataSource sqldsFooter;

        protected void Page_Load(object sender, EventArgs e)
        {
            this._objContactMasterDt = this._objContactMasterBll.GetAllDetail();
            if (this._objContactMasterDt.Rows.Count > 0)
            {
                string str1 = this._objContactMasterDt.Rows[0]["Phone1"].ToString();
                string str2 = this._objContactMasterDt.Rows[0]["Email1"].ToString();
                
            }
            this.objFreePackageSettingsDT = this.objFreePackageSettingsBll.GetAllDetail();
            if (this.objFreePackageSettingsDT.Rows.Count <= 0)
                return;
            this.btnSubmit.Text = "Try it Free for " + this.objFreePackageSettingsDT.Rows[0]["FreePackageDays"] + " Days";
        }

        protected void txtCompanyName_OnTextChanged(object sender, EventArgs e)
        {
            this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyName(this.txtCompanyName.Text.Trim());
            if (this.objCompanyMasterDT.Rows.Count > 0)
            {
                this.DisplayAlert("Company Already Register With System.");
                ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Company Already Register With System.')", true);
                this.txtCompanyName.Text = "";
                this.txtCompanyName.Focus();
            }
            else
                this.txtEmailAddress.Focus();
        }

        protected void txtEmail_OnTextChanged(object sender, EventArgs e)
        {
            this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyEmail(this.txtEmailAddress.Text.Trim());
            this.objUserDT = this.objUserBll.GetAllDetail(this.txtEmailAddress.Text.Trim());
            if (this.objCompanyMasterDT.Rows.Count > 0 || this.objUserDT.Rows.Count > 0)
            {
                this.DisplayAlert("Company Email Already Register With System.");
                ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Company Email Already Register With System.')", true);
                this.txtEmailAddress.Text = "";
                this.txtEmailAddress.Focus();
            }
            else
                this.btnSubmit.Focus();
        }

        protected void BtnSubmitClick(object sender, EventArgs e)
        {
            if (!this.Page.IsValid || this.txtCompanyName.Text.Trim().Length <= 0 || this.txtEmailAddress.Text.Trim().Length <= 0)
                return;
            this.Application["companyName"] = (object)this.txtCompanyName.Text.Trim();
            this.Application["emailAddress"] = (object)this.txtEmailAddress.Text.Trim();
            Admin.Admin.RoleName = "Admin";
            Doyingo.RoleName = "Admin";
            this.Response.Redirect("~/BillTransact/DefaultDoyingo.aspx");
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

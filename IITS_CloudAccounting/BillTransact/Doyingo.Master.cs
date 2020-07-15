// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.Doyingo
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using DABL.BLL;
using DABL.DAL;
using System;
using System.Globalization;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
    public class Doyingo : MasterPage
    {
        private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
        private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
        private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
        private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
        private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
        private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
        private readonly StaffPermissionMasterBLL objStaffPermissionMasterBll = new StaffPermissionMasterBLL();
        private CloudAccountDA.StaffPermissionMasterDataTable objStaffPermissionMasterDT = new CloudAccountDA.StaffPermissionMasterDataTable();
        private readonly AdminPermissionMasterBLL objAdminPermissionMasterBll = new AdminPermissionMasterBLL();
        private CloudAccountDA.AdminPermissionMasterDataTable objAdminPermissionMasterDT = new CloudAccountDA.AdminPermissionMasterDataTable();
        private readonly CompanyPackageMasterBLL objCompanyPackageMasterBll = new CompanyPackageMasterBLL();
        private CloudAccountDA.CompanyPackageMasterDataTable objCompanyPackageMasterDT = new CloudAccountDA.CompanyPackageMasterDataTable();
        private readonly CloudPackageMasterBLL objCloudPackageMasterBll = new CloudPackageMasterBLL();
        private CloudAccountDA.CloudPackageMasterDataTable objCloudPackageMasterDT = new CloudAccountDA.CloudPackageMasterDataTable();
        public static string RoleName;
        protected ContentPlaceHolder head;
        protected HtmlForm form1;
        protected HtmlGenericControl account;
        protected HtmlGenericControl setting;
        protected HtmlGenericControl staffProfile;
        protected HtmlGenericControl help;
        protected LoginStatus LoginStatus2;
        protected Image imgLogo;
        protected HtmlGenericControl uploadLogo;
        protected LoginName LoginName1;
        protected LoginStatus LoginStatus1;
        protected HtmlGenericControl mainUl;
        protected HtmlGenericControl home;
        protected HtmlGenericControl userManagement;
        protected HtmlGenericControl invoice;
        protected HtmlGenericControl Estimate;
        protected HtmlGenericControl expenseMenu;
        protected HtmlGenericControl timeTracking;
        protected HtmlGenericControl reports;
        protected HtmlGenericControl moreMenu;
        protected HtmlGenericControl mainHome;
        protected HtmlGenericControl referDoyingo;
        protected HtmlGenericControl pricing;
        protected HtmlGenericControl doyinGoSupport;
        protected HtmlGenericControl buyStamp;
        protected HtmlGenericControl client;
        protected HtmlGenericControl staffContractor;
        protected HtmlGenericControl accountant;
        protected HtmlGenericControl assignClient;
        protected HtmlGenericControl sentEmail;
        protected HtmlGenericControl newInvoice;
        protected HtmlGenericControl recurring;
        protected HtmlGenericControl receivedInvoice;
        protected HtmlGenericControl payments;
        protected HtmlGenericControl credits;
        protected HtmlGenericControl item;
        protected HtmlGenericControl newEstimate;
        protected HtmlGenericControl receivedEstimate;
        protected HtmlGenericControl expense;
        protected HtmlGenericControl importExpense;
        protected HtmlGenericControl timeSheet;
        protected HtmlGenericControl projects;
        protected HtmlGenericControl tasks;
        protected HtmlGenericControl teamTimeSheet;
        protected HtmlGenericControl genrateInv;
        protected HtmlGenericControl billingInfo;
        protected HtmlGenericControl adminProfile;
        protected HtmlGenericControl invite;
        protected HtmlGenericControl importExport;
        protected HtmlGenericControl updateCompany;
        protected HtmlGenericControl paypalSetting;
        protected HtmlGenericControl taxes;
        protected HtmlGenericControl colorLogo;
        protected HtmlGenericControl templates;
        protected HtmlGenericControl permissions;
        protected HtmlGenericControl emails;
        protected HtmlGenericControl smtp;
        protected HtmlGenericControl misc;
        protected ContentPlaceHolder ContentPlaceHolder1;
        protected HtmlGenericControl footerRow;
        protected Label lblDays;
        protected Label lblPackageName;
        protected DataList dlFooter;
        protected SqlDataSource sqldsFooter;
        protected HtmlGenericControl overlay;
        protected HiddenField hfCompanyID;
        protected HiddenField hfStaffID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Application["companyName"] == null && this.Application["emailAddress"] == null)
            {
                MembershipUser user = Membership.GetUser();
                if (user != null)
                {
                    string str = user.ToString();
                    if (Roles.IsUserInRole(str, "SuperAdmin"))
                        Doyingo.RoleName = "SuperAdmin";
                    else if (Roles.IsUserInRole(str, "MasterAdmin"))
                        Doyingo.RoleName = "MasterAdmin";
                    else if (Roles.IsUserInRole(str, "Admin"))
                    {
                        Doyingo.RoleName = "Admin";
                        this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(str);
                        if (this.objCompanyLoginMasterDT.Rows.Count > 0)
                            this.hfCompanyID.Value = this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString();
                    }
                    else if (Roles.IsUserInRole(str, "Employee"))
                    {
                        Doyingo.RoleName = "Employee";
                        this.objStaffMasterDT = this.objStaffMasterBll.GetDataByStaffUserName(str);
                        if (this.objStaffMasterDT.Rows.Count > 0)
                        {
                            this.hfCompanyID.Value = this.objStaffMasterDT.Rows[0]["CompanyID"].ToString();
                            this.hfStaffID.Value = this.objStaffMasterDT.Rows[0]["StaffID"].ToString();
                        }
                    }
                    else
                        Doyingo.RoleName = string.Empty;
                }
            }
            if (this.IsPostBack)
                return;
            if (!string.IsNullOrEmpty(Doyingo.RoleName))
            {
                this.mainUl.Visible = true;
                switch (Doyingo.RoleName)
                {
                    case "SuperAdmin":
                        this.mainUl.Visible = true;
                        this.Page.Title = "Super Admin Panel";
                        break;
                    case "MasterAdmin":
                        this.mainUl.Visible = true;
                        this.Page.Title = "Master Admin Panel";
                        break;
                    case "Admin":
                        this.mainUl.Visible = true;
                        this.MenuAdmin();
                        this.SetCompanyLogo();
                        break;
                    case "Employee":
                        this.mainUl.Visible = true;
                        this.MenuEmployee();
                        this.SetCompanyLogo();
                        break;
                    default:
                        this.mainUl.Visible = false;
                        break;
                }
            }
            else
                this.mainUl.Visible = false;
        }

        private void SetCompanyLogo()
        {
            MembershipUser user = Membership.GetUser();
            if (user != null)
            {
                string str1 = user.ToString();
                if (Roles.IsUserInRole(str1, "Admin"))
                {
                    this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(str1);
                    if (this.objCompanyLoginMasterDT.Rows.Count > 0)
                    {
                        string str2 = this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString();
                        this.hfCompanyID.Value = this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString();
                        this.imgLogo.ImageUrl = "../Handler/CompanyLogoFile.ashx?id=" + str2;
                    }
                }
                else if (Roles.IsUserInRole(str1, "Employee"))
                {
                    this.objStaffMasterDT = this.objStaffMasterBll.GetDataByStaffUserName(str1);
                    if (this.objStaffMasterDT.Rows.Count > 0)
                    {
                        string str2 = this.objStaffMasterDT.Rows[0]["CompanyID"].ToString();
                        this.hfCompanyID.Value = this.objStaffMasterDT.Rows[0]["CompanyID"].ToString();
                        this.imgLogo.ImageUrl = "../Handler/CompanyLogoFile.ashx?id=" + str2;
                    }
                }
                else
                    this.imgLogo.ImageUrl = "../App_Themes/sky/uploads/logo.png";
                if (this.hfCompanyID.Value.ToString() != "")
                {
                    this.objCompanyPackageMasterDT = this.objCompanyPackageMasterBll.GetDataByCompanyActivePackage(int.Parse(this.hfCompanyID.Value));
                }
                if (this.objCompanyPackageMasterDT.Rows.Count <= 0)
                    return;
                string s = this.objCompanyPackageMasterDT.Rows[0]["CloudPackageID"].ToString();
                if (s == "0")
                {
                    this.lblPackageName.Text = "Free Trial";
                }
                else
                {
                    this.objCloudPackageMasterDT = this.objCloudPackageMasterBll.GetDataByCloudPackageID(int.Parse(s));
                    if (this.objCloudPackageMasterDT.Rows.Count > 0)
                        this.lblPackageName.Text = this.objCloudPackageMasterDT.Rows[0]["CloudPackageName"].ToString() + " Package";
                }
                TimeSpan timeSpan = DateTime.Parse(DateTime.Parse(this.objCompanyPackageMasterDT.Rows[0]["PackageEndDate"].ToString()).ToShortDateString()) - DateTime.Parse(DateTime.UtcNow.ToShortDateString());
                if (timeSpan.TotalDays <= 0.0)
                    this.Response.Redirect("UpgradePackage.aspx");
                else
                    this.lblDays.Text = timeSpan.TotalDays.ToString((IFormatProvider)CultureInfo.InvariantCulture);
            }
            else
            {
                this.imgLogo.ImageUrl = "../App_Themes/sky/uploads/logo.png";
                this.LoginStatus1_OnLoggingOut((object)null, (LoginCancelEventArgs)null);
            }
        }

        public static string SetCompanyLogo(string companyID)
        {
            if (!string.IsNullOrEmpty(companyID))
                return "../Handler/CompanyLogoFile.ashx?id=" + companyID;
            return "../App_Themes/sky/uploads/logo.png";
        }

        private void MenuEmployee()
        {
            this.uploadLogo.Visible = false;
            this.account.Visible = false;
            this.setting.Visible = false;
            this.staffProfile.Visible = true;
            this.help.Visible = true;
            this.footerRow.Visible = false;
            this.home.Visible = true;
            if (!string.IsNullOrEmpty(this.hfCompanyID.Value))
            {
                this.objStaffPermissionMasterDT = this.objStaffPermissionMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
                if (this.objStaffPermissionMasterDT.Rows.Count > 0)
                {
                    this.userManagement.Visible = bool.Parse(this.objStaffPermissionMasterDT.Rows[0]["People"].ToString());
                    this.invoice.Visible = bool.Parse(this.objStaffPermissionMasterDT.Rows[0]["Invoice"].ToString());
                    this.Estimate.Visible = bool.Parse(this.objStaffPermissionMasterDT.Rows[0]["Estimate"].ToString());
                    this.expenseMenu.Visible = bool.Parse(this.objStaffPermissionMasterDT.Rows[0]["Expenses"].ToString());
                    this.timeTracking.Visible = bool.Parse(this.objStaffPermissionMasterDT.Rows[0]["TimeTracking"].ToString());
                    if (bool.Parse(this.objStaffPermissionMasterDT.Rows[0]["Documents"].ToString()) || bool.Parse(this.objStaffPermissionMasterDT.Rows[0]["Support"].ToString()))
                        this.moreMenu.Visible = true;
                    else
                        this.moreMenu.Visible = false;
                    this.reports.Visible = bool.Parse(this.objStaffPermissionMasterDT.Rows[0]["Reports"].ToString());
                }
                else
                {
                    this.userManagement.Visible = true;
                    this.invoice.Visible = true;
                    this.Estimate.Visible = true;
                    this.expenseMenu.Visible = true;
                    this.timeTracking.Visible = true;
                    this.reports.Visible = true;
                    this.moreMenu.Visible = false;
                }
            }
            else
            {
                this.userManagement.Visible = true;
                this.invoice.Visible = true;
                this.Estimate.Visible = true;
                this.expenseMenu.Visible = true;
                this.timeTracking.Visible = true;
                this.reports.Visible = true;
                this.moreMenu.Visible = false;
            }
            this.mainHome.Visible = true;
            this.referDoyingo.Visible = false;
            this.pricing.Visible = false;
            this.buyStamp.Visible = false;
            this.doyinGoSupport.Visible = false;
            this.client.Visible = true;
            this.staffContractor.Visible = false;
            this.accountant.Visible = false;
            this.assignClient.Visible = false;
            this.sentEmail.Visible = true;
            this.newInvoice.Visible = true;
            this.recurring.Visible = true;
            this.receivedInvoice.Visible = false;
            this.payments.Visible = true;
            this.credits.Visible = true;
            this.item.Visible = true;
            this.newEstimate.Visible = true;
            this.receivedEstimate.Visible = false;
            this.expense.Visible = true;
            this.importExpense.Visible = true;
            this.timeSheet.Visible = true;
            if (!string.IsNullOrEmpty(this.hfCompanyID.Value))
            {
                this.objStaffPermissionMasterDT = this.objStaffPermissionMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
                if (this.objStaffPermissionMasterDT.Rows.Count > 0)
                {
                    this.projects.Visible = false;
                    this.tasks.Visible = false;
                    this.teamTimeSheet.Visible = false;
                    this.genrateInv.Visible = false;
                }
                else
                {
                    this.projects.Visible = true;
                    this.tasks.Visible = true;
                    this.teamTimeSheet.Visible = true;
                    this.genrateInv.Visible = true;
                }
            }
            else
            {
                this.projects.Visible = true;
                this.tasks.Visible = true;
                this.teamTimeSheet.Visible = true;
                this.genrateInv.Visible = true;
            }
        }

        private void MenuAdmin()
        {
            this.uploadLogo.Visible = true;
            this.account.Visible = true;
            this.setting.Visible = true;
            this.staffProfile.Visible = false;
            this.help.Visible = true;
            this.footerRow.Visible = true;
            this.home.Visible = true;
            this.userManagement.Visible = true;
            this.invoice.Visible = true;
            this.reports.Visible = true;
            if (!string.IsNullOrEmpty(this.hfCompanyID.Value))
            {
                this.objAdminPermissionMasterDT = this.objAdminPermissionMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
                if (this.objAdminPermissionMasterDT.Rows.Count > 0)
                {
                    this.Estimate.Visible = bool.Parse(this.objAdminPermissionMasterDT.Rows[0]["Estimate"].ToString());
                    this.expenseMenu.Visible = bool.Parse(this.objAdminPermissionMasterDT.Rows[0]["Expenses"].ToString());
                    this.timeTracking.Visible = bool.Parse(this.objAdminPermissionMasterDT.Rows[0]["TimeTracking"].ToString());
                    if (bool.Parse(this.objAdminPermissionMasterDT.Rows[0]["Documents"].ToString()) || bool.Parse(this.objAdminPermissionMasterDT.Rows[0]["Support"].ToString()))
                        this.moreMenu.Visible = true;
                    else
                        this.moreMenu.Visible = false;
                }
                else
                {
                    this.Estimate.Visible = true;
                    this.expenseMenu.Visible = true;
                    this.timeTracking.Visible = true;
                    this.moreMenu.Visible = true;
                }
            }
            else
            {
                this.Estimate.Visible = true;
                this.expenseMenu.Visible = true;
                this.timeTracking.Visible = true;
                this.moreMenu.Visible = true;
            }
            this.mainHome.Visible = true;
            this.referDoyingo.Visible = true;
            this.pricing.Visible = true;
            this.buyStamp.Visible = false;
            this.doyinGoSupport.Visible = true;
            this.client.Visible = true;
            this.staffContractor.Visible = true;
            this.accountant.Visible = true;
            this.assignClient.Visible = true;
            this.sentEmail.Visible = true;
            this.newInvoice.Visible = true;
            this.recurring.Visible = true;
            this.receivedInvoice.Visible = true;
            this.payments.Visible = true;
            this.credits.Visible = true;
            this.item.Visible = true;
            this.newEstimate.Visible = true;
            this.receivedEstimate.Visible = true;
            this.expense.Visible = true;
            this.importExpense.Visible = true;
            this.timeSheet.Visible = true;
            this.projects.Visible = true;
            this.tasks.Visible = true;
            this.teamTimeSheet.Visible = true;
            this.genrateInv.Visible = true;
        }

        protected void LoginStatus1_OnLoggingOut(object sender, LoginCancelEventArgs e)
        {
            Doyingo.RoleName = string.Empty;
            FormsAuthentication.SignOut();
        }

        public static string GenerateCode()
        {
            Random random = new Random();
            StringBuilder stringBuilder = new StringBuilder();
            for (int index = 0; index < 10; ++index)
                stringBuilder.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@#$%&*(}[abcdefghijklmnopqrstuvwxyz!)_?{]/"[random.Next("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@#$%&*(}[abcdefghijklmnopqrstuvwxyz!)_?{]/".Length)]);
            return stringBuilder.ToString();
        }

        public static string GenerateCode(int length)
        {
            Random random = new Random();
            StringBuilder stringBuilder = new StringBuilder();
            for (int index = 0; index < length; ++index)
                stringBuilder.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@abcdefghijklmnopqrstuvwxyz!_"[random.Next("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@abcdefghijklmnopqrstuvwxyz!_".Length)]);
            return stringBuilder.ToString();
        }

        public bool CheckCurrency()
        {
            MembershipUser user = Membership.GetUser();
            string s = string.Empty;
            if (user != null)
            {
                string str = user.ToString();
                if (Roles.IsUserInRole(str, "Admin"))
                {
                    this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(str);
                    if (this.objCompanyLoginMasterDT.Rows.Count > 0)
                        s = this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString();
                }
                else if (Roles.IsUserInRole(str, "Employee"))
                {
                    this.objStaffMasterDT = this.objStaffMasterBll.GetDataByStaffUserName(str);
                    if (this.objStaffMasterDT.Rows.Count > 0)
                        s = this.objStaffMasterDT.Rows[0]["CompanyID"].ToString();
                }
                this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(s));
                if (this.objCompanyMasterDT.Rows.Count > 0 && (string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CurrencyID"].ToString()) || string.IsNullOrEmpty(this.objCompanyMasterDT.Rows[0]["CompanyAddressStreet1"].ToString())))
                    return true;
            }
            return false;
        }
    }
}

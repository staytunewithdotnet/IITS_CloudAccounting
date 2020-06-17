// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.Admin
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using DABL.BLL;
using DABL.DAL;
using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class Admin : MasterPage
  {
    private readonly MasterAdminRightsMasterBLL _objMasterAdminRightsMasterBll = new MasterAdminRightsMasterBLL();
    private CloudAccountDA.MasterAdminRightsMasterDataTable _objMasterAdminRightsMasterDt = new CloudAccountDA.MasterAdminRightsMasterDataTable();
    private readonly MasterAdminLoginMasterBLL _objMasterAdminLoginMasterBll = new MasterAdminLoginMasterBLL();
    private CloudAccountDA.MasterAdminLoginMasterDataTable _objMasterAdminLoginMasterDt = new CloudAccountDA.MasterAdminLoginMasterDataTable();
    public static string AddMode;
    public static string EditMode;
    public static string ViewMode;
    public static string DeleteMode;
    private string _formName;
    public static string RoleName;
    protected HtmlLink skin_color;
    protected ContentPlaceHolder head;
    protected HtmlForm form1;
    protected LoginName LoginName1;
    protected LoginStatus LoginStatus1;
    protected HtmlGenericControl mainUl;
    protected HtmlGenericControl home;
    protected HtmlGenericControl generalMaster;
    protected HtmlGenericControl freePackage;
    protected HtmlGenericControl paymentGateway;
    protected HtmlGenericControl paymentGatewayPaypal;
    protected HtmlGenericControl country;
    protected HtmlGenericControl state;
    protected HtmlGenericControl city;
    protected HtmlGenericControl currency;
    protected HtmlGenericControl securityQuestion;
    protected HtmlGenericControl frequency;
    protected HtmlGenericControl bussiness;
    protected HtmlGenericControl industry;
    protected HtmlGenericControl currentAccount;
    protected HtmlGenericControl runningFrom;
    protected HtmlGenericControl Category;
    protected HtmlGenericControl SubCategory;
    protected HtmlGenericControl supportMasters;
    protected HtmlGenericControl supportDepartment;
    protected HtmlGenericControl supportTickets;
    protected HtmlGenericControl masterAdminMagmnt;
    protected HtmlGenericControl masterAdmin;
    protected HtmlGenericControl masterAdminRights;
    protected HtmlGenericControl packageManagement;
    protected HtmlGenericControl PackageModule;
    protected HtmlGenericControl PackageFeature;
    protected HtmlGenericControl cloudPackage;
    protected HtmlGenericControl companyManagement;
    protected HtmlGenericControl companyMaster;
    protected HtmlGenericControl companyLoginMaster;
    protected HtmlGenericControl companyPackageInfo;
    protected HtmlGenericControl formManagement;
    protected HtmlGenericControl formMaster;
    protected HtmlGenericControl moduleFormMaster;
    protected HtmlGenericControl adminReports;
    protected HtmlGenericControl companyActive;
    protected HtmlGenericControl companyActiveDate;
    protected HtmlGenericControl companyPackageReport;
    protected HtmlGenericControl salesReport;
    protected HtmlGenericControl cmsMaster;
    protected HtmlGenericControl homeMaster;
    protected HtmlGenericControl homePageSlider;
    protected HtmlGenericControl clientMaster;
    protected HtmlGenericControl FooterContent;
    protected HtmlGenericControl privacyPolicy;
    protected HtmlGenericControl termService;
    protected HtmlGenericControl TestimonialsMaster;
    protected HtmlGenericControl inquiryMaster;
    protected HtmlGenericControl contactMaster;
    protected HtmlGenericControl aboutCat;
    protected HtmlGenericControl aboutCon;
    protected HtmlGenericControl featureCat;
    protected HtmlGenericControl faqCat;
    protected HtmlGenericControl faqMaster;
    protected HtmlGenericControl supportMaster;
    protected ContentPlaceHolder ContentPlaceHolder1;
    protected DataList dlFooter;
    protected SqlDataSource sqldsFooter;

    protected void Page_Load(object sender, EventArgs e)
    {
      MembershipUser user = Membership.GetUser();
      if (user != null)
      {
        string username = user.ToString();
        Admin.RoleName = !Roles.IsUserInRole(username, "SuperAdmin") ? (!Roles.IsUserInRole(username, "MasterAdmin") ? string.Empty : "MasterAdmin") : "SuperAdmin";
      }
      else
        this.Response.Redirect("../MemberArea.aspx");
      if (this.IsPostBack)
        return;
      if (!string.IsNullOrEmpty(Admin.RoleName))
      {
        this.mainUl.Visible = true;
        switch (Admin.RoleName)
        {
          case "SuperAdmin":
            this.mainUl.Visible = true;
            break;
          case "MasterAdmin":
            this.mainUl.Visible = true;
            this.MenuMasterAdmin();
            break;
          default:
            this.mainUl.Visible = false;
            break;
        }
      }
      else
        this.mainUl.Visible = false;
    }

    private void MenuMasterAdmin()
    {
      string s = string.Empty;
      MembershipUser user = Membership.GetUser();
      if (user != null)
        this._objMasterAdminLoginMasterDt = this._objMasterAdminLoginMasterBll.GetDataByUserName(user.UserName);
      if (this._objMasterAdminLoginMasterDt.Rows.Count > 0)
        s = this._objMasterAdminLoginMasterDt.Rows[0]["MasterAdminUserID"].ToString();
      this.generalMaster.Visible = true;
      this.masterAdminMagmnt.Visible = true;
      this.packageManagement.Visible = true;
      this.companyManagement.Visible = true;
      this.formManagement.Visible = true;
      this.adminReports.Visible = true;
      this.cmsMaster.Visible = true;
      this._objMasterAdminRightsMasterDt = this._objMasterAdminRightsMasterBll.GetDataByViewRecords(int.Parse(s));
      if (this._objMasterAdminRightsMasterDt.Rows.Count > 0)
      {
        this.freePackage.Visible = false;
        this.paymentGateway.Visible = false;
        this.paymentGatewayPaypal.Visible = false;
        this.country.Visible = false;
        this.state.Visible = false;
        this.city.Visible = false;
        this.currency.Visible = false;
        this.securityQuestion.Visible = false;
        this.bussiness.Visible = false;
        this.industry.Visible = false;
        this.currentAccount.Visible = false;
        this.runningFrom.Visible = false;
        this.masterAdmin.Visible = false;
        this.masterAdminRights.Visible = false;
        this.PackageModule.Visible = false;
        this.PackageFeature.Visible = false;
        this.cloudPackage.Visible = false;
        this.companyMaster.Visible = false;
        this.companyLoginMaster.Visible = false;
        this.companyPackageInfo.Visible = false;
        this.formMaster.Visible = false;
        this.moduleFormMaster.Visible = false;
        this.companyActive.Visible = false;
        this.companyActiveDate.Visible = false;
        this.companyPackageReport.Visible = false;
        this.salesReport.Visible = false;
        this.homeMaster.Visible = false;
        this.homePageSlider.Visible = false;
        this.clientMaster.Visible = false;
        this.FooterContent.Visible = false;
        this.TestimonialsMaster.Visible = false;
        this.inquiryMaster.Visible = false;
        this.contactMaster.Visible = false;
        this.aboutCat.Visible = false;
        this.aboutCon.Visible = false;
        this.featureCat.Visible = false;
        this.faqCat.Visible = false;
        this.faqMaster.Visible = false;
        this.supportMaster.Visible = false;
        for (int index = 0; index < this._objMasterAdminRightsMasterDt.Rows.Count; ++index)
        {
          this._formName = this._objMasterAdminRightsMasterDt.Rows[index]["ModuleFormName"].ToString();
          Admin.AddMode = this._objMasterAdminRightsMasterDt.Rows[index]["AddMode"].ToString();
          Admin.EditMode = this._objMasterAdminRightsMasterDt.Rows[index]["EditMode"].ToString();
          Admin.DeleteMode = this._objMasterAdminRightsMasterDt.Rows[index]["DeleteMode"].ToString();
          Admin.ViewMode = this._objMasterAdminRightsMasterDt.Rows[index]["ViewMode"].ToString();
          if (Admin.AddMode != "False" || Admin.EditMode != "False" || (Admin.DeleteMode != "False" || Admin.ViewMode != "False"))
          {
            if (this._formName == "PaymentGatewayMaster")
              this.paymentGateway.Visible = true;
            else if (this._formName == "PaymentGatewayPaypalMaster")
              this.paymentGatewayPaypal.Visible = true;
            else if (this._formName == "FreePackageSettings")
              this.freePackage.Visible = true;
            else if (this._formName == "CountryMaster")
              this.country.Visible = true;
            else if (this._formName == "StateMaster")
              this.state.Visible = true;
            else if (this._formName == "CityMaster")
              this.city.Visible = true;
            else if (this._formName == "CurrencyMaster")
              this.currency.Visible = true;
            else if (this._formName == "SecurityQuestionMaster")
              this.securityQuestion.Visible = true;
            else if (this._formName == "FrequencyMaster")
              this.frequency.Visible = true;
            else if (this._formName == "BussinessMaster")
              this.bussiness.Visible = true;
            else if (this._formName == "IndustryMaster")
              this.industry.Visible = true;
            else if (this._formName == "CurrentAccountMaster")
              this.currentAccount.Visible = true;
            else if (this._formName == "RunningFromMaster")
              this.runningFrom.Visible = true;
            else if (this._formName == "CategoryMaster")
              this.Category.Visible = true;
            else if (this._formName == "SubCategoryMaster")
              this.SubCategory.Visible = true;
            else if (this._formName == "MasterAdminLoginMaster")
              this.masterAdmin.Visible = true;
            else if (this._formName == "MasterAdminRightsMaster")
              this.masterAdminRights.Visible = true;
            else if (this._formName == "PackageModuleMaster")
              this.PackageModule.Visible = true;
            else if (this._formName == "PackageFeatureMaster")
              this.PackageFeature.Visible = true;
            else if (this._formName == "CloudPackageMaster")
              this.cloudPackage.Visible = true;
            else if (this._formName == "CompanyMaster")
              this.companyMaster.Visible = true;
            else if (this._formName == "CompanyLoginMaster")
              this.companyLoginMaster.Visible = true;
            else if (this._formName == "CompanyPackageInfo")
              this.companyPackageInfo.Visible = true;
            else if (this._formName == "FormMaster")
              this.formMaster.Visible = true;
            else if (this._formName == "ModuleFormMaster")
              this.moduleFormMaster.Visible = true;
            else if (this._formName == "CompanyReportStatus")
              this.companyActive.Visible = true;
            else if (this._formName == "CompanyStatusDateReport")
              this.companyActiveDate.Visible = true;
            else if (this._formName == "CompanyPackageReport")
              this.companyPackageReport.Visible = true;
            else if (this._formName == "SalesReport")
              this.salesReport.Visible = true;
            else if (this._formName == "HomeMaster")
              this.homeMaster.Visible = true;
            else if (this._formName == "HomePageSlider")
              this.homePageSlider.Visible = true;
            else if (this._formName == "ClientMaster")
              this.clientMaster.Visible = true;
            else if (this._formName == "FooterContent")
              this.FooterContent.Visible = true;
            else if (this._formName == "TestimonialsMaster")
              this.TestimonialsMaster.Visible = true;
            else if (this._formName == "InquiryMaster")
              this.inquiryMaster.Visible = true;
            else if (this._formName == "ContactMaster")
              this.contactMaster.Visible = true;
            else if (this._formName == "AboutCategoryMaster")
              this.aboutCat.Visible = true;
            else if (this._formName == "AboutContentMaster")
              this.aboutCon.Visible = true;
            else if (this._formName == "FeatureMaster")
              this.featureCat.Visible = true;
            else if (this._formName == "FAQCategoryMaster")
              this.faqCat.Visible = true;
            else if (this._formName == "FAQMaster")
              this.faqMaster.Visible = true;
          }
        }
        if (this.country.Visible || this.state.Visible || (this.city.Visible || this.currency.Visible) || (this.securityQuestion.Visible || this.bussiness.Visible || (this.industry.Visible || this.currentAccount.Visible)) || (this.runningFrom.Visible || this.frequency.Visible || (this.Category.Visible || this.SubCategory.Visible) || (this.paymentGateway.Visible || this.paymentGatewayPaypal.Visible || this.freePackage.Visible)))
          this.generalMaster.Visible = true;
        else
          this.generalMaster.Visible = false;
        if (this.masterAdmin.Visible || this.masterAdminRights.Visible)
          this.masterAdminMagmnt.Visible = true;
        else
          this.masterAdminMagmnt.Visible = false;
        if (this.PackageModule.Visible || this.PackageFeature.Visible || this.cloudPackage.Visible)
          this.packageManagement.Visible = true;
        else
          this.packageManagement.Visible = false;
        if (this.companyMaster.Visible || this.companyLoginMaster.Visible)
          this.companyManagement.Visible = true;
        else
          this.companyManagement.Visible = false;
        if (this.formMaster.Visible || this.moduleFormMaster.Visible)
          this.formManagement.Visible = true;
        else
          this.formManagement.Visible = false;
        if (this.companyActive.Visible || this.companyActiveDate.Visible || (this.companyPackageReport.Visible || this.salesReport.Visible))
          this.adminReports.Visible = true;
        else
          this.adminReports.Visible = false;
        if (this.homeMaster.Visible || this.homePageSlider.Visible || (this.clientMaster.Visible || this.FooterContent.Visible) || (this.TestimonialsMaster.Visible || this.inquiryMaster.Visible || (this.contactMaster.Visible || this.aboutCat.Visible)) || (this.aboutCon.Visible || this.featureCat.Visible || (this.faqCat.Visible || this.faqMaster.Visible) || this.supportMaster.Visible))
          this.cmsMaster.Visible = true;
        else
          this.cmsMaster.Visible = false;
      }
      else
      {
        this.generalMaster.Visible = false;
        this.masterAdminMagmnt.Visible = false;
        this.packageManagement.Visible = false;
        this.companyManagement.Visible = false;
        this.formManagement.Visible = false;
        this.adminReports.Visible = false;
        this.cmsMaster.Visible = false;
      }
    }

    protected void LoginStatus1_OnLoggingOut(object sender, LoginCancelEventArgs e)
    {
      Admin.RoleName = string.Empty;
      FormsAuthentication.SignOut();
    }
  }
}

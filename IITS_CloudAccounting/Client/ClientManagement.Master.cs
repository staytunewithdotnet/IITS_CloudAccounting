// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Client.ClientManagement
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Client
{
  public class ClientManagement : MasterPage
  {
    private readonly CompanyClientMasterBLL objClientMasterBll = new CompanyClientMasterBLL();
    private CloudAccountDA.CompanyClientMasterDataTable objClientMasterDT = new CloudAccountDA.CompanyClientMasterDataTable();
    private readonly CompanyClientContactDetailBLL objCompanyClientContactDetailBll = new CompanyClientContactDetailBLL();
    private CloudAccountDA.CompanyClientContactDetailDataTable objCompanyClientContactDetailDT = new CloudAccountDA.CompanyClientContactDetailDataTable();
    private readonly ClientPermissionMasterBLL objClientPermissionMasterBll = new ClientPermissionMasterBLL();
    private CloudAccountDA.ClientPermissionMasterDataTable objClientPermissionMasterDT = new CloudAccountDA.ClientPermissionMasterDataTable();
    protected HtmlHead Head1;
    protected ContentPlaceHolder head;
    protected HtmlForm form1;
    protected ToolkitScriptManager ToolkitScriptManager1;
    protected HtmlGenericControl clientProfile;
    protected LoginStatus LoginStatus2;
    protected Image imgLogo;
    protected HtmlGenericControl mainUl;
    protected HtmlGenericControl home;
    protected HtmlGenericControl invoice;
    protected HtmlGenericControl Estimate;
    protected HtmlGenericControl timeTracking;
    protected HtmlGenericControl moreMenu;
    protected HtmlGenericControl mainHome;
    protected HtmlGenericControl referDoyingo;
    protected HtmlGenericControl allInvoice;
    protected HtmlGenericControl unpaidInvoice;
    protected HtmlGenericControl payments;
    protected HtmlGenericControl credits;
    protected HtmlGenericControl newEstimate;
    protected HtmlGenericControl project;
    protected ContentPlaceHolder ContentPlaceHolder1;
    protected DataList dlFooter;
    protected SqlDataSource sqldsFooter;
    protected HtmlGenericControl overlay;
    protected HiddenField hfClientID;
    protected HiddenField hfClientContactID;
    protected HiddenField hfCompanyID;

    protected void Page_Load(object sender, EventArgs e)
    {
      MembershipUser user = Membership.GetUser();
      if (user != null)
      {
        this.objClientMasterDT = this.objClientMasterBll.GetDataByUsername(user.ToString());
        if (this.objClientMasterDT.Rows.Count > 0)
        {
          this.hfClientID.Value = this.objClientMasterDT.Rows[0]["CompanyClientID"].ToString();
          this.hfCompanyID.Value = this.objClientMasterDT.Rows[0]["CompanyID"].ToString();
          this.SetMenu();
          this.Estimate.Visible = true;
        }
        this.objCompanyClientContactDetailDT = this.objCompanyClientContactDetailBll.GetDataByUsername(user.ToString());
        if (this.objCompanyClientContactDetailDT.Rows.Count > 0)
        {
          this.hfClientContactID.Value = this.objCompanyClientContactDetailDT.Rows[0]["CompanyClientContactID"].ToString();
          this.hfClientID.Value = this.objCompanyClientContactDetailDT.Rows[0]["CompanyClientID"].ToString();
          this.hfCompanyID.Value = this.objCompanyClientContactDetailDT.Rows[0]["CompanyID"].ToString();
          this.SetMenu();
          this.Estimate.Visible = false;
        }
      }
      if (this.IsPostBack)
        return;
      this.SetCompanyLogo();
    }

    private void SetMenu()
    {
      this.home.Visible = true;
      if (!string.IsNullOrEmpty(this.hfCompanyID.Value))
      {
        this.objClientPermissionMasterDT = this.objClientPermissionMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
        if (this.objClientPermissionMasterDT.Rows.Count > 0)
        {
          this.Estimate.Visible = bool.Parse(this.objClientPermissionMasterDT.Rows[0]["Estimate"].ToString());
          this.invoice.Visible = bool.Parse(this.objClientPermissionMasterDT.Rows[0]["Invoice"].ToString());
          this.timeTracking.Visible = bool.Parse(this.objClientPermissionMasterDT.Rows[0]["Projects"].ToString());
          if (bool.Parse(this.objClientPermissionMasterDT.Rows[0]["Documents"].ToString()) || bool.Parse(this.objClientPermissionMasterDT.Rows[0]["Support"].ToString()))
            this.moreMenu.Visible = true;
          else
            this.moreMenu.Visible = false;
        }
        else
        {
          this.Estimate.Visible = true;
          this.invoice.Visible = true;
          this.timeTracking.Visible = true;
          this.moreMenu.Visible = true;
        }
      }
      else
      {
        this.Estimate.Visible = true;
        this.invoice.Visible = true;
        this.timeTracking.Visible = true;
        this.moreMenu.Visible = true;
      }
    }

    private void SetCompanyLogo()
    {
      if (!string.IsNullOrEmpty(this.hfCompanyID.Value))
        this.imgLogo.ImageUrl = "../Handler/CompanyLogoFile.ashx?id=" + this.hfCompanyID.Value;
      else
        this.imgLogo.ImageUrl = "../App_Themes/Blue/images/logo.jpg";
    }

    protected void LoginStatus1_OnLoggingOut(object sender, LoginCancelEventArgs e)
    {
      FormsAuthentication.SignOut();
    }
  }
}

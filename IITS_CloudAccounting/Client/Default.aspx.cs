// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Client.Default
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

namespace IITS_CloudAccounting.Client
{
  public class Default : Page
  {
    private readonly CompanyClientMasterBLL objCompanyClientMasterBll = new CompanyClientMasterBLL();
    private CloudAccountDA.CompanyClientMasterDataTable objCompanyClientMasterDT = new CloudAccountDA.CompanyClientMasterDataTable();
    private readonly MiscellaneousMasterBLL objMiscellaneousMasterBll = new MiscellaneousMasterBLL();
    private CloudAccountDA.MiscellaneousMasterDataTable objMiscellaneousMasterDT = new CloudAccountDA.MiscellaneousMasterDataTable();
    private readonly CompanyClientContactDetailBLL objCompanyClientContactDetailBll = new CompanyClientContactDetailBLL();
    private CloudAccountDA.CompanyClientContactDetailDataTable objCompanyClientContactDetailDT = new CloudAccountDA.CompanyClientContactDetailDataTable();
    protected Label lblClientInfo;
    protected HtmlGenericControl welcomeDiv;
    protected Label lblClientWelcomeMsg;
    protected HiddenField hfClientID;
    protected HiddenField hfClientContactID;
    protected HiddenField hfCompanyID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("home")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("mainHome")).Attributes.Add("class", "active open");
      MembershipUser user = Membership.GetUser();
      if (user == null)
        return;
      this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByUsername(user.ToString());
      if (this.objCompanyClientMasterDT.Rows.Count > 0)
      {
        this.hfClientID.Value = this.objCompanyClientMasterDT.Rows[0]["CompanyClientID"].ToString();
        this.hfCompanyID.Value = this.objCompanyClientMasterDT.Rows[0]["CompanyID"].ToString();
        this.lblClientInfo.Text = "Company Client";
      }
      this.objCompanyClientContactDetailDT = this.objCompanyClientContactDetailBll.GetDataByUsername(user.ToString());
      if (this.objCompanyClientContactDetailDT.Rows.Count > 0)
      {
        this.hfClientContactID.Value = this.objCompanyClientContactDetailDT.Rows[0]["CompanyClientContactID"].ToString();
        this.hfClientID.Value = this.objCompanyClientContactDetailDT.Rows[0]["CompanyClientID"].ToString();
        this.hfCompanyID.Value = this.objCompanyClientContactDetailDT.Rows[0]["CompanyID"].ToString();
        this.lblClientInfo.Text = "Company Client Contact";
      }
      this.SetWelcomeMessage(this.hfCompanyID.Value);
    }

    private void SetWelcomeMessage(string companyID)
    {
      this.objMiscellaneousMasterDT = this.objMiscellaneousMasterBll.GetDataByCompanyID(int.Parse(companyID));
      if (this.objMiscellaneousMasterDT.Rows.Count <= 0)
        return;
      this.lblClientWelcomeMsg.Text = this.objMiscellaneousMasterDT.Rows[0]["WelcomeMessagesClient"].ToString();
      this.welcomeDiv.Visible = !string.IsNullOrEmpty(this.lblClientWelcomeMsg.Text);
    }
  }
}

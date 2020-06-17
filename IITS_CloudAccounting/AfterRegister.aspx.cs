// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.AfterRegister
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

namespace IITS_CloudAccounting
{
  public class AfterRegister : Page
  {
    private readonly CompanyLoginMasterBLL _objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable _objCompanyLoginMasterDt = new CloudAccountDA.CompanyLoginMasterDataTable();
    protected HtmlGenericControl verifiedEmailDiv;
    protected Button btnMakePayment;
    protected Button btnLoginwithtrial;
    protected HtmlGenericControl unverifiedEmailDiv;
    protected Button btnRegister;
    protected HtmlGenericControl noEmailDiv;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("pricing")).Attributes.Add("class", "current-menu-item current-menu-ancestor");
      if (this.Request.QueryString["UserName"] != null)
      {
        MembershipUser user = Membership.GetUser(this.Request.QueryString["UserName"]);
        if (user != null)
        {
          this.verifiedEmailDiv.Visible = true;
          this.unverifiedEmailDiv.Visible = false;
          this.noEmailDiv.Visible = false;
          user.IsApproved = true;
          Membership.UpdateUser(user);
          this._objCompanyLoginMasterDt = this._objCompanyLoginMasterBll.GetDataByCompanyLoginName(user.UserName);
          if (this._objCompanyLoginMasterDt.Rows.Count <= 0)
            return;
          this._objCompanyLoginMasterBll.UpdateCompanyLogin(int.Parse(this._objCompanyLoginMasterDt.Rows[0]["CompanyLoginID"].ToString()), int.Parse(this._objCompanyLoginMasterDt.Rows[0]["CompanyID"].ToString()), this._objCompanyLoginMasterDt.Rows[0]["CompanyUserName"].ToString(), this._objCompanyLoginMasterDt.Rows[0]["CompanyEmail"].ToString(), true);
        }
        else
        {
          this.verifiedEmailDiv.Visible = false;
          this.unverifiedEmailDiv.Visible = true;
          this.noEmailDiv.Visible = false;
        }
      }
      else
      {
        this.noEmailDiv.Visible = true;
        this.verifiedEmailDiv.Visible = false;
        this.unverifiedEmailDiv.Visible = false;
      }
    }

    protected void BtnLoginwithtrialClick(object sender, EventArgs e)
    {
      this.Response.Redirect("~/MemberArea.aspx");
    }

    protected void BtnRegisterClick(object sender, EventArgs e)
    {
      this.Response.Redirect("~/PricingTable.aspx");
    }
  }
}

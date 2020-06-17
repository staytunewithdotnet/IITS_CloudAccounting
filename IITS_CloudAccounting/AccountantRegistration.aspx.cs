// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.AccountantRegistration
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting
{
  public class AccountantRegistration : Page
  {
    private readonly AccountantMasterBLL objAccountantMasterBll = new AccountantMasterBLL();
    private readonly AccountantClientDetailBLL objAccountantClientDetailBll = new AccountantClientDetailBLL();
    protected ToolkitScriptManager tsm;
    protected Panel pnlRegister;
    protected TextBox txtFirstName;
    protected RequiredFieldValidator rfvFirstName;
    protected TextBox txtLastName;
    protected RequiredFieldValidator rfvLastName;
    protected TextBox txtPhone;
    protected RequiredFieldValidator rfvPhone;
    protected TextBox txtCompanyName;
    protected TextBox txtAddress;
    protected UpdatePanel upAddress;
    protected DropDownList ddlCountry;
    protected SqlDataSource sqldsCountry;
    protected DropDownList ddlState;
    protected SqlDataSource sqldsState;
    protected DropDownList ddlCity;
    protected SqlDataSource sqldsCity;
    protected TextBox txtZipCode;
    protected TextBox txtProfession;
    protected TextBox txtDesignation;
    protected Button btnFinish;
    protected HiddenField hfEmail;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Request.QueryString["em"] == null)
        return;
      this.hfEmail.Value = this.Request.QueryString["em"];
    }

    protected void btnFinish_OnClick(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      int? iCountryID = new int?();
      int? iStateID = new int?();
      int? iCityID = new int?();
      if (this.ddlCountry.SelectedIndex > 0)
        iCountryID = new int?(int.Parse(this.ddlCountry.SelectedItem.Value));
      if (this.ddlState.SelectedIndex > 0)
        iStateID = new int?(int.Parse(this.ddlState.SelectedItem.Value));
      if (this.ddlCity.SelectedIndex > 0)
        iCityID = new int?(int.Parse(this.ddlCity.SelectedItem.Value));
      int iAccountantID = this.objAccountantMasterBll.AddAccountant(this.txtFirstName.Text.Trim(), this.txtLastName.Text.Trim(), this.hfEmail.Value, this.txtPhone.Text.Trim(), this.txtCompanyName.Text.Trim(), this.txtAddress.Text.Trim(), "", iCountryID, iStateID, iCityID, this.txtZipCode.Text.Trim(), this.txtProfession.Text.Trim(), this.txtDesignation.Text.Trim());
      if (iAccountantID == 0)
        return;
      if (this.Request.QueryString["cmdId"] != null && this.Request.QueryString["Dated"] != null)
      {
        int iCompanyID = int.Parse(this.Request.QueryString["cmdId"]);
        DateTime dateTime = DateTime.Parse(this.Request.QueryString["Dated"]);
        this.objAccountantClientDetailBll.AddAccountantClient(iAccountantID, iCompanyID, true, false, new DateTime?(dateTime), new DateTime?(DateTime.Now));
      }
      FormsAuthentication.RedirectFromLoginPage(this.hfEmail.Value, false);
      this.Response.Redirect("~/Accountant/AccountantClients.aspx");
    }
  }
}

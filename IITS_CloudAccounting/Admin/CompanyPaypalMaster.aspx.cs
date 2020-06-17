// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.CompanyPaypalMaster
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
  public class CompanyPaypalMaster : Page
  {
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyPaypalMasterBLL objCompanyPaypalMasterBll = new CompanyPaypalMasterBLL();
    private CloudAccountDA.CompanyPaypalMasterDataTable objCompanyPaypalMasterDT = new CloudAccountDA.CompanyPaypalMasterDataTable();
    protected TextBox txtPaypal;
    protected Button btnSave;
    protected HiddenField hfCompanyID;
    protected HiddenField hfPaypalID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("setting")).Attributes.Add("style", "background-color: lightgray;");
      ((HtmlControl) this.Master.FindControl("paypalSetting")).Attributes.Add("class", "active open");
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
      this.objCompanyPaypalMasterDT = this.objCompanyPaypalMasterBll.GetDataByCompanyID(int.Parse(companyID));
      if (this.objCompanyPaypalMasterDT.Rows.Count <= 0)
        return;
      this.hfPaypalID.Value = this.objCompanyPaypalMasterDT.Rows[0]["CompanyPaypalID"].ToString();
      this.hfCompanyID.Value = this.objCompanyPaypalMasterDT.Rows[0]["CompanyID"].ToString();
      this.txtPaypal.Text = this.objCompanyPaypalMasterDT.Rows[0]["PaypalID"].ToString();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
      this.objCompanyPaypalMasterDT = this.objCompanyPaypalMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objCompanyPaypalMasterDT.Rows.Count > 0)
        this.objCompanyPaypalMasterBll.UpdateCompanyPaypal(int.Parse(this.hfPaypalID.Value), int.Parse(this.hfCompanyID.Value), this.txtPaypal.Text);
      else
        this.objCompanyPaypalMasterBll.AddCompanyPaypal(int.Parse(this.hfCompanyID.Value), this.txtPaypal.Text);
      this.Response.Redirect("CompanyPaypalMaster.aspx");
    }
  }
}

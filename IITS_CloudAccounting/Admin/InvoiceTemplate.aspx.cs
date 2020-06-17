// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.InvoiceTemplate
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
  public class InvoiceTemplate : Page
  {
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly TemplateSettingsBLL objTemplateSettingsBll = new TemplateSettingsBLL();
    private CloudAccountDA.TemplateSettingsDataTable objTemplateSettingsDT = new CloudAccountDA.TemplateSettingsDataTable();
    protected HtmlGenericControl divSave;
    protected DropDownList ddlInvoiceTemplate;
    protected TextBox txtInvoiceTitle;
    protected TextBox txtEstimateTitle;
    protected TextBox txtCreditTitle;
    protected CheckBox chkPaymentStub;
    protected Button btnSave;
    protected HiddenField hfCompanyID;
    protected HiddenField hfTempalteID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("setting")).Attributes.Add("style", "background-color: lightgray;");
      ((HtmlControl) this.Master.FindControl("templates")).Attributes.Add("class", "active open");
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
      this.divSave.Visible = this.Session["saveTemp"] != null;
      this.Session.Abandon();
      this.SetCompanyRecords(this.hfCompanyID.Value);
    }

    private void SetCompanyRecords(string companyID)
    {
      this.objTemplateSettingsDT = this.objTemplateSettingsBll.GetDataByCompanyID(int.Parse(companyID));
      if (this.objTemplateSettingsDT.Rows.Count > 0)
      {
        this.hfTempalteID.Value = this.objTemplateSettingsDT.Rows[0]["TemplateSettingsID"].ToString();
        this.hfCompanyID.Value = this.objTemplateSettingsDT.Rows[0]["CompanyID"].ToString();
        this.txtInvoiceTitle.Text = this.objTemplateSettingsDT.Rows[0]["InvoiceTitle"].ToString();
        this.txtEstimateTitle.Text = this.objTemplateSettingsDT.Rows[0]["EstimateTitle"].ToString();
        this.txtCreditTitle.Text = this.objTemplateSettingsDT.Rows[0]["CreditTitle"].ToString();
        this.chkPaymentStub.Checked = bool.Parse(this.objTemplateSettingsDT.Rows[0]["PaymentStub"].ToString());
      }
      else
      {
        this.objTemplateSettingsBll.AddTemplateSettings(int.Parse(this.hfCompanyID.Value), 1, "Invoice", "Estimate", "Credit", true);
        this.Response.Redirect("InvoiceTemplate.aspx");
      }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
      this.objTemplateSettingsDT = this.objTemplateSettingsBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objTemplateSettingsDT.Rows.Count > 0)
        this.objTemplateSettingsBll.UpdateTemplateSettings(int.Parse(this.hfTempalteID.Value), int.Parse(this.hfCompanyID.Value), 1, this.txtInvoiceTitle.Text.Trim(), this.txtEstimateTitle.Text.Trim(), this.txtCreditTitle.Text.Trim(), true);
      else
        this.objTemplateSettingsBll.AddTemplateSettings(int.Parse(this.hfCompanyID.Value), 1, this.txtInvoiceTitle.Text.Trim(), this.txtEstimateTitle.Text.Trim(), this.txtCreditTitle.Text.Trim(), true);
      this.Session["saveTemp"] = (object) 1;
      this.Response.Redirect("InvoiceTemplate.aspx");
    }
  }
}

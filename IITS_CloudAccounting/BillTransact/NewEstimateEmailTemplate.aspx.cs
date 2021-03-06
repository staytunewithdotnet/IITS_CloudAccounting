﻿// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.NewEstimateEmailTemplate
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using DABL.BLL;
using DABL.DAL;
using System;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class NewEstimateEmailTemplate : Page
  {
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly NewEstimateEmailTemplateBLL objNewEstimateEmailTemplateBll = new NewEstimateEmailTemplateBLL();
    private CloudAccountDA.NewEstimateEmailTemplateDataTable objNewEstimateEmailTemplateDT = new CloudAccountDA.NewEstimateEmailTemplateDataTable();
    private readonly StringBuilder strBody = new StringBuilder("To access your estimate from ##companyName## for ##paymentAmt##, go to:<br /><br /> ##estimateLink##<br />");
    private const string strSubject = "New Estimate ##estimateNumber## from ##companyName## , sent using Bill Transact";
    protected TextBox txtSubject;
    protected TextBox txtBody;
    protected Button btnSave;
    protected Button btnDefault;
    protected HiddenField hfCompanyID;
    protected HiddenField hfEmailID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("setting")).Attributes.Add("style", "background-color: lightgray;");
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
      this.objNewEstimateEmailTemplateDT = this.objNewEstimateEmailTemplateBll.GetDataByCompanyID(int.Parse(companyID));
      if (this.objNewEstimateEmailTemplateDT.Rows.Count > 0)
      {
        this.hfEmailID.Value = this.objNewEstimateEmailTemplateDT.Rows[0]["NewEstimateEmailTemplateID"].ToString();
        this.hfCompanyID.Value = this.objNewEstimateEmailTemplateDT.Rows[0]["CompanyID"].ToString();
        this.txtSubject.Text = this.objNewEstimateEmailTemplateDT.Rows[0]["EmailSubject"].ToString();
        this.txtBody.Text = this.objNewEstimateEmailTemplateDT.Rows[0]["EmailBody"].ToString();
        this.txtBody.Text = this.txtBody.Text.Replace("&nbsp;&nbsp;", "  ");
        this.txtBody.Text = this.txtBody.Text.Replace("<br />", "\n");
      }
      else
      {
          this.objNewEstimateEmailTemplateBll.AddEstimateTemplate(int.Parse(companyID), "New Estimate ##estimateNumber## from ##companyName## , sent using Bill Transact", this.strBody.ToString());
        this.Response.Redirect("NewEstimateEmailTemplate.aspx");
      }
    }

    protected void btnRestore_Click(object sender, EventArgs e)
    {
      this.objNewEstimateEmailTemplateDT = this.objNewEstimateEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objNewEstimateEmailTemplateDT.Rows.Count > 0)
          this.objNewEstimateEmailTemplateBll.UpdateEstimateTemplate(int.Parse(this.hfEmailID.Value), int.Parse(this.hfCompanyID.Value), "New Estimate ##estimateNumber## from ##companyName## , sent using Bill Transact", this.strBody.ToString());
      else
          this.objNewEstimateEmailTemplateBll.AddEstimateTemplate(int.Parse(this.hfCompanyID.Value), "New Estimate ##estimateNumber## from ##companyName## , sent using Bill Transact", this.strBody.ToString());
      this.Response.Redirect("NewEstimateEmailTemplate.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
      this.objNewEstimateEmailTemplateDT = this.objNewEstimateEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objNewEstimateEmailTemplateDT.Rows.Count > 0)
        this.objNewEstimateEmailTemplateBll.UpdateEstimateTemplate(int.Parse(this.hfEmailID.Value), int.Parse(this.hfCompanyID.Value), this.txtSubject.Text, new StringBuilder(this.txtBody.Text).Replace("\n", "<br />").Replace("  ", "&nbsp;&nbsp;").ToString());
      else
        this.objNewEstimateEmailTemplateBll.AddEstimateTemplate(int.Parse(this.hfCompanyID.Value), this.txtSubject.Text, new StringBuilder(this.txtBody.Text).Replace("\n", "<br />").Replace("  ", "&nbsp;&nbsp;").ToString());
      this.Response.Redirect("NewEstimateEmailTemplate.aspx");
    }
  }
}

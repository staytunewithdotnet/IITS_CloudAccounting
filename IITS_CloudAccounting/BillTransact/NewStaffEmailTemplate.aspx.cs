// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.NewStaffEmailTemplate
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
  public class NewStaffEmailTemplate : Page
  {
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly NewStaffEmailTemplateBLL objNewStaffEmailTemplateBll = new NewStaffEmailTemplateBLL();
    private CloudAccountDA.NewStaffEmailTemplateDataTable objNewStaffEmailTemplateDT = new CloudAccountDA.NewStaffEmailTemplateDataTable();
    private readonly StringBuilder strBody = new StringBuilder("You are now part of ##companyName##'s team.<br />Click here to log in to your account:<br />##login link##<br /><br />Username: ##username##<br />Password: ##password##<br />");
    private const string strSubject = "##companyName## invites you to track time and expenses in Bill Transact";
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
      this.objNewStaffEmailTemplateDT = this.objNewStaffEmailTemplateBll.GetDataByCompanyID(int.Parse(companyID));
      if (this.objNewStaffEmailTemplateDT.Rows.Count > 0)
      {
        this.hfEmailID.Value = this.objNewStaffEmailTemplateDT.Rows[0]["NewStaffEmailTemplateID"].ToString();
        this.hfCompanyID.Value = this.objNewStaffEmailTemplateDT.Rows[0]["CompanyID"].ToString();
        this.txtSubject.Text = this.objNewStaffEmailTemplateDT.Rows[0]["EmailSubject"].ToString();
        this.txtBody.Text = this.objNewStaffEmailTemplateDT.Rows[0]["EmailBody"].ToString();
        this.txtBody.Text = this.txtBody.Text.Replace("&nbsp;&nbsp;", "  ");
        this.txtBody.Text = this.txtBody.Text.Replace("<br />", "\n");
      }
      else
      {
          this.objNewStaffEmailTemplateBll.AddStaffTemplate(int.Parse(companyID), "##companyName## invites you to track time and expenses in Bill Transact", this.strBody.ToString());
        this.Response.Redirect("NewStaffEmailTemplate.aspx");
      }
    }

    protected void btnRestore_Click(object sender, EventArgs e)
    {
      this.objNewStaffEmailTemplateDT = this.objNewStaffEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objNewStaffEmailTemplateDT.Rows.Count > 0)
          this.objNewStaffEmailTemplateBll.UpdateStaffTemplate(int.Parse(this.hfEmailID.Value), int.Parse(this.hfCompanyID.Value), "##companyName## invites you to track time and expenses in Bill Transact", this.strBody.ToString());
      else
          this.objNewStaffEmailTemplateBll.AddStaffTemplate(int.Parse(this.hfCompanyID.Value), "##companyName## invites you to track time and expenses in Bill Transact", this.strBody.ToString());
      this.Response.Redirect("NewStaffEmailTemplate.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
      this.objNewStaffEmailTemplateDT = this.objNewStaffEmailTemplateBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objNewStaffEmailTemplateDT.Rows.Count > 0)
        this.objNewStaffEmailTemplateBll.UpdateStaffTemplate(int.Parse(this.hfEmailID.Value), int.Parse(this.hfCompanyID.Value), this.txtSubject.Text, new StringBuilder(this.txtBody.Text).Replace("\n", "<br />").Replace("  ", "&nbsp;&nbsp;").ToString());
      else
        this.objNewStaffEmailTemplateBll.AddStaffTemplate(int.Parse(this.hfCompanyID.Value), this.txtSubject.Text, new StringBuilder(this.txtBody.Text).Replace("\n", "<br />").Replace("  ", "&nbsp;&nbsp;").ToString());
      this.Response.Redirect("NewStaffEmailTemplate.aspx");
    }
  }
}

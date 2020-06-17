// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.ContactUs
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using DABL.BLL;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting
{
  public class ContactUs : Page
  {
    private readonly InquiryMasterBLL _objInquiryMasterBll = new InquiryMasterBLL();
    protected DataList DataList1;
    protected TextBox txtName;
    protected RequiredFieldValidator rfvName;
    protected TextBox txtEmail;
    protected RequiredFieldValidator rfvEmail;
    protected TextBox txtPhone;
    protected RequiredFieldValidator rfvPhone;
    protected TextBox txtSubject;
    protected TextBox txtLocation;
    protected TextBox txtWebsite;
    protected TextBox txtComments;
    protected RequiredFieldValidator rfvComment;
    protected Button btnSubmit;
    protected DataList dlContact;
    protected SqlDataSource sqldsContact;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("contactUs")).Attributes.Add("class", "current-menu-item current-menu-ancestor");
    }

    private void Clear()
    {
      this.txtName.Text = this.txtEmail.Text = this.txtPhone.Text = this.txtSubject.Text = this.txtLocation.Text = this.txtWebsite.Text = this.txtComments.Text = "";
      this.txtName.Focus();
    }

    protected void BtnSubmitClick(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this._objInquiryMasterBll.AddInquiry(this.txtName.Text.Trim(), this.txtEmail.Text.Trim(), this.txtPhone.Text.Trim(), this.txtSubject.Text.Trim(), this.txtLocation.Text.Trim(), this.txtWebsite.Text.Trim(), this.txtComments.Text.Trim(), false) != 0)
      {
        this.DisplayAlert("Details Added Successfully.");
        this.Response.Redirect("ContactUs.aspx");
      }
      else
      {
        this.DisplayAlert("Fail to Add New Details.");
        this.Clear();
      }
    }

    public void DisplayAlert(string message)
    {
      this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">" + this.GetAlertScript(message) + "</script>");
    }

    public string GetAlertScript(string message)
    {
      return "alert('" + message.Replace("'", "\\'") + "');";
    }
  }
}

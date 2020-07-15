// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.UpdateAdminProfile
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
  public class UpdateAdminProfile : Page
  {
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    protected HtmlGenericControl divUpdate;
    protected TextBox txtEmail;
    protected TextBox txtFirstName;
    protected TextBox txtLastName;
    protected TextBox txtBillingRate;
    protected TextBox txtHomePhone;
    protected TextBox txtUsername;
    protected TextBox txtCurrentPassword;
    protected TextBox txtNewPassword;
    protected TextBox txtConfPassword;
    protected Button btnUpdate;
    protected HiddenField hfCompanyID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("account")).Attributes.Add("style", "background-color: lightgray;");
      ((HtmlControl) this.Master.FindControl("adminProfile")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      MembershipUser user = Membership.GetUser();
      if (user != null)
      {
        string str = user.ToString();
        if (Roles.IsUserInRole(str, "Admin"))
        {
          this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(str);
          if (this.objCompanyLoginMasterDT.Rows.Count > 0)
          {
            this.hfCompanyID.Value = this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString();
            this.SetRecord(this.hfCompanyID.Value);
          }
        }
        else
          this.Response.Redirect("../MemberArea.aspx");
      }
      this.divUpdate.Visible = this.Session["update"] != null;
      this.Session.Abandon();
    }

    private void SetRecord(string iD)
    {
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(iD));
      if (this.objCompanyMasterDT.Rows.Count <= 0)
        return;
      this.hfCompanyID.Value = this.objCompanyMasterDT.Rows[0]["CompanyID"].ToString();
      this.txtUsername.Text = this.objCompanyMasterDT.Rows[0]["CompanyUserName"].ToString();
      this.txtEmail.Text = this.objCompanyMasterDT.Rows[0]["CompanyEmail"].ToString();
      string[] strArray = this.objCompanyMasterDT.Rows[0]["CompanyContactPerson"].ToString().Split(' ');
      this.txtFirstName.Text = !string.IsNullOrEmpty(strArray[0]) ? strArray[0] : "";
      this.txtLastName.Text = !string.IsNullOrEmpty(strArray[1]) ? strArray[1] : "";
      this.txtHomePhone.Text = this.objCompanyMasterDT.Rows[0]["CompanyContactPersonNumber"].ToString();
      this.txtUsername.Enabled = false;
      this.txtEmail.Focus();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.txtEmail.Text.Trim().Length > 0 && this.txtFirstName.Text.Trim().Length > 0 && (this.txtLastName.Text.Trim().Length > 0 && this.txtUsername.Text.Trim().Length > 0))
      {
        if (this.txtCurrentPassword.Text.Trim().Length > 0 && this.txtCurrentPassword.Text.Trim().Length > 3 && this.txtCurrentPassword.Text.Trim().Length > 3)
        {
          MembershipUser user = Membership.GetUser();
          if (user != null && !user.IsLockedOut)
          {
            if (this.txtCurrentPassword.Text.Trim() == user.GetPassword())
            {
              if (this.txtNewPassword.Text.Trim() == this.txtConfPassword.Text.Trim())
              {
                user.ChangePassword(this.txtCurrentPassword.Text.Trim(), this.txtNewPassword.Text.Trim());
                Membership.UpdateUser(user);
              }
              else
                this.DisplayAlert("New Password & Confirm Password must be same..!");
            }
            else
              this.DisplayAlert("Current Password Not Match With Current User..!");
          }
        }
        Decimal num = new Decimal(0);
        if (this.txtBillingRate.Text.Trim().Length > 0)
          num = Decimal.Parse(this.txtBillingRate.Text.Trim());
        bool flag = this.objCompanyMasterBll.UpdateAdminProfile(int.Parse(this.hfCompanyID.Value), this.txtUsername.Text.Trim(), this.txtFirstName.Text.Trim() + " " + this.txtLastName.Text.Trim(), this.txtHomePhone.Text.Trim(), new Decimal?(num), this.txtEmail.Text.Trim());
        MembershipUser user1 = Membership.GetUser();
        if (user1 != null && !user1.IsLockedOut)
        {
          user1.Email = this.txtEmail.Text.Trim();
          Membership.UpdateUser(user1);
        }
        if (flag)
        {
          this.Session["update"] = (object) 1;
          this.DisplayAlert("Admin Profile Updated Successfully..!");
          this.Response.Redirect("~/BillTransact/UpdateAdminProfile.aspx");
        }
        else
          this.DisplayAlert("Some Error Occured..Please Try After Some Time..!");
      }
      else
        this.DisplayAlert("Please Fill All Fields..!");
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

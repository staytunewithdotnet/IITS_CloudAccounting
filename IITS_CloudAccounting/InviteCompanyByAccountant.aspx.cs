// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.InviteCompanyByAccountant
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

namespace IITS_CloudAccounting
{
  public class InviteCompanyByAccountant : Page
  {
    private readonly UserBLL objUserBll = new UserBLL();
    private CloudAccountDA.aspnet_UsersDataTable objUserDT = new CloudAccountDA.aspnet_UsersDataTable();
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
    protected HtmlLink stylecss;
    protected HtmlForm form1;
    protected ToolkitScriptManager tsm;
    protected Panel pnlRegister;
    protected UpdatePanel upEmail;
    protected TextBox txtCompanyName;
    protected RequiredFieldValidator rfvCompanyName;
    protected TextBox txtEmailAddress;
    protected RequiredFieldValidator rfvEmail;
    protected RegularExpressionValidator revEmail;
    protected Button btnCreate;
    protected LinkButton lnkBtnLogin;
    protected Panel pnlLogin;
    protected Login Login1;
    protected DataList dlFooter;
    protected SqlDataSource sqldsFooter;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.IsPostBack)
        return;
      if (this.Request.QueryString["cmd"] != null)
      {
        if (this.Request.QueryString["cmd"] == "register")
        {
          this.pnlLogin.Visible = false;
          this.pnlRegister.Visible = true;
        }
        else
        {
          this.pnlLogin.Visible = true;
          this.pnlRegister.Visible = false;
          this.Login1.FindControl("UserName").Focus();
        }
      }
      else
      {
        this.pnlLogin.Visible = true;
        this.pnlRegister.Visible = false;
        this.Login1.FindControl("UserName").Focus();
      }
    }

    protected void txtCompanyName_OnTextChanged(object sender, EventArgs e)
    {
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyName(this.txtCompanyName.Text.Trim());
      if (this.objCompanyMasterDT.Rows.Count > 0)
      {
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Company Already Register With System.')", true);
        this.txtCompanyName.Text = "";
        this.txtCompanyName.Focus();
      }
      else
        this.txtEmailAddress.Focus();
    }

    protected void txtEmail_OnTextChanged(object sender, EventArgs e)
    {
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyEmail(this.txtEmailAddress.Text.Trim());
      this.objUserDT = this.objUserBll.GetAllDetail(this.txtEmailAddress.Text.Trim());
      if (this.objCompanyMasterDT.Rows.Count > 0 || this.objUserDT.Rows.Count > 0)
      {
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Company Email Already Register With System.')", true);
        this.txtEmailAddress.Text = "";
        this.txtEmailAddress.Focus();
      }
      else
        this.btnCreate.Focus();
    }

    public void DisplayAlert(string message)
    {
      this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">" + this.GetAlertScript(message) + "</script>");
    }

    public string GetAlertScript(string message)
    {
      return "alert('" + message.Replace("'", "\\'") + "');";
    }

    protected void BtnCreateClick(object sender, EventArgs e)
    {
      if (!this.Page.IsValid || this.txtCompanyName.Text.Trim().Length <= 0 || this.txtEmailAddress.Text.Trim().Length <= 0)
        return;
      this.Application["companyName"] = (object) this.txtCompanyName.Text.Trim();
      this.Application["emailAddress"] = (object) this.txtEmailAddress.Text.Trim();
      string str = string.Empty;
      if (this.Request.QueryString["accId"] != null && this.Request.QueryString["Dated"] != null)
        str = str + "&accId=" + this.Request.QueryString["accId"] + "&Dated=" + this.Request.QueryString["Dated"];
      this.Response.Redirect("~/BillTransact/DefaultDoyingo.aspx?" + str);
    }

    protected void LoginButtonClick(object sender, EventArgs e)
    {
      try
      {
        if (this.Page.IsValid)
        {
          MembershipUser user = Membership.GetUser(this.Login1.UserName);
          if (user != null)
          {
            if (user.IsApproved)
            {
              if (!user.IsLockedOut)
              {
                if (Membership.ValidateUser(this.Login1.UserName, this.Login1.Password))
                {
                  FormsAuthentication.RedirectFromLoginPage(this.Login1.UserName, false);
                  if (!Roles.IsUserInRole(this.Login1.UserName, "Admin"))
                    return;
                  if (this.Application.Count > 0)
                    this.Application.Clear();
                  string str = string.Empty;
                  if (this.Request.QueryString["accId"] != null && this.Request.QueryString["Dated"] != null)
                    str = str + "&accId=" + this.Request.QueryString["accId"] + "&Dated=" + this.Request.QueryString["Dated"];
                  this.Response.Redirect("~/BillTransact/DefaultDoyingo.aspx?add=1" + str);
                }
                else
                {
                  this.Login1.FailureText = "";
                  ((Label) this.Login1.FindControl("errorLabel")).Text = "Invalid UserName or Password.";
                }
              }
              else
              {
                this.Login1.FailureText = "";
                ((Label) this.Login1.FindControl("errorLabel")).Text = "You have process many wrong Passwords. Your account has been Locked. Contact Support for UnLock your account.";
              }
            }
            else
            {
              this.Login1.FailureText = "";
              ((Label) this.Login1.FindControl("errorLabel")).Text = "Your account is locked by system. Contact Support to Unlock your account.";
            }
          }
          else
          {
            this.Login1.FailureText = "";
            ((Label) this.Login1.FindControl("errorLabel")).Text = "Invalid UserName.";
          }
        }
        else
        {
          this.Login1.FailureText = "";
          ((Label) this.Login1.FindControl("errorLabel")).Text = "Provide valid UserName or Password.";
        }
      }
      catch (Exception ex)
      {
        this.Login1.FailureText = "";
        ((Label) this.Login1.FindControl("errorLabel")).Text = ex.Message;
      }
    }

    protected void lnkBtnLogin_OnClick(object sender, EventArgs e)
    {
      string str = string.Empty;
      if (this.Request.QueryString["accId"] != null && this.Request.QueryString["Dated"] != null)
        str = str + "&accId=" + this.Request.QueryString["accId"] + "&Dated=" + this.Request.QueryString["Dated"];
      this.Response.Redirect("InviteCompanyByAccountant.aspx?" + str);
    }

    protected void lnkBtnRegister_OnClick(object sender, EventArgs e)
    {
      string str = string.Empty;
      if (this.Request.QueryString["accId"] != null && this.Request.QueryString["Dated"] != null)
        str = str + "&accId=" + this.Request.QueryString["accId"] + "&Dated=" + this.Request.QueryString["Dated"];
      this.Response.Redirect("InviteCompanyByAccountant.aspx?cmd=register" + str);
    }
  }
}

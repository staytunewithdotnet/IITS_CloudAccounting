// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.AccountantSignUp
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
  public class AccountantSignUp : Page
  {
    private readonly UserBLL objUserBll = new UserBLL();
    private CloudAccountDA.aspnet_UsersDataTable objUserDT = new CloudAccountDA.aspnet_UsersDataTable();
    private readonly AccountantMasterBLL objAccountantMasterBll = new AccountantMasterBLL();
    private CloudAccountDA.AccountantMasterDataTable objAccountantMasterDT = new CloudAccountDA.AccountantMasterDataTable();
    private bool checkInDB;
    protected ToolkitScriptManager tsm;
    protected Panel pnlRegister;
    protected UpdatePanel upEmail;
    protected TextBox txtEmailAddress;
    protected RequiredFieldValidator rfvEmail;
    protected RegularExpressionValidator revEmail;
    protected TextBox txtPassword;
    protected RequiredFieldValidator rfvPassword;
    protected TextBox txtConPassword;
    protected RequiredFieldValidator rfvConPassword;
    protected CompareValidator cvConPassword;
    protected Button btnCreate;
    protected LinkButton lnkBtnLogin;
    protected Panel pnlLogin;
    protected Login Login1;
    protected Panel pnlPassword;
    protected PasswordRecovery PasswordRecovery1;

    protected void Page_Load(object sender, EventArgs e)
    {
      //if (this.Master == null)
      //  return;
      //((HtmlControl) this.Master.FindControl("login")).Attributes.Add("class", "current-menu-item current-menu-ancestor");
      if (this.IsPostBack)
        return;
      if (this.Request.QueryString["cmd"] != null)
      {
        switch (this.Request.QueryString["cmd"])
        {
          case "pr":
            this.pnlRegister.Visible = false;
            this.pnlLogin.Visible = false;
            this.pnlPassword.Visible = true;
            break;
          case "register":
            this.pnlRegister.Visible = true;
            this.pnlLogin.Visible = false;
            this.pnlPassword.Visible = false;
            this.txtEmailAddress.Focus();
            break;
          default:
            this.pnlRegister.Visible = false;
            this.pnlLogin.Visible = true;
            this.pnlPassword.Visible = false;
            this.Login1.FindControl("UserName").Focus();
            break;
        }
      }
      else
      {
        this.pnlRegister.Visible = false;
        this.pnlLogin.Visible = true;
        this.pnlPassword.Visible = false;
        this.Login1.FindControl("UserName").Focus();
      }
    }

    protected void BtnContClick(object sender, EventArgs e)
    {
      string str = string.Empty;
      if (this.Request.QueryString["cmdId"] != null && this.Request.QueryString["Dated"] != null)
        str = str + "&cmdId=" + this.Request.QueryString["cmdId"] + "&Dated=" + this.Request.QueryString["Dated"];
      this.Response.Redirect("AccountantSignUp.aspx?" + str);
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
                  if (Roles.IsUserInRole(this.Login1.UserName, "Accountant"))
                  {
                    string str = string.Empty;
                    if (this.Request.QueryString["cmdId"] != null && this.Request.QueryString["Dated"] != null)
                      str = str + "&cmdId=" + this.Request.QueryString["cmdId"] + "&Dated=" + this.Request.QueryString["Dated"] + "&addClient=1";
                    this.Response.Redirect("~/Accountant/AccountantClients.aspx?" + str);
                  }
                  else
                  {
                    this.Login1.FailureText = "";
                    ((Label) this.Login1.FindControl("errorLabel")).Text = "Not An Accountant but Member of System Please Login From Login Menu.";
                  }
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

    protected void TxtEmailAddressTextChanged(object sender, EventArgs e)
    {
      if (this.txtEmailAddress.Text.Trim().Length <= 0)
        return;
      this.objAccountantMasterDT = this.objAccountantMasterBll.GetDataByAccountantEmail(this.txtEmailAddress.Text.Trim());
      this.objUserDT = this.objUserBll.GetAllDetail(this.txtEmailAddress.Text.Trim());
      if (this.objAccountantMasterDT.Rows.Count > 0 || this.objUserDT.Rows.Count > 0)
      {
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Email has already been taken.')", true);
        this.txtEmailAddress.Text = "";
        this.txtEmailAddress.Focus();
      }
      else
        this.txtPassword.Focus();
    }

    protected void BtnCreateClick(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.txtEmailAddress.Text.Trim().Length > 0 && this.txtPassword.Text.Trim().Length > 0 && this.txtConPassword.Text.Trim().Length > 0)
      {
        this.objAccountantMasterDT = this.objAccountantMasterBll.GetDataByAccountantEmail(this.txtEmailAddress.Text.Trim());
        this.objUserDT = this.objUserBll.GetAllDetail(this.txtEmailAddress.Text.Trim());
        if (this.objAccountantMasterDT.Rows.Count > 0 || this.objUserDT.Rows.Count > 0)
        {
          this.DisplayAlert("Email has already been taken.");
          this.txtEmailAddress.Text = "";
          this.txtEmailAddress.Focus();
          this.checkInDB = true;
        }
        else
          this.checkInDB = false;
        if (this.checkInDB)
          return;
        string str = string.Empty;
        if (this.Request.QueryString["cmdId"] != null && this.Request.QueryString["Dated"] != null)
          str = str + "&cmdId=" + this.Request.QueryString["cmdId"] + "&Dated=" + this.Request.QueryString["Dated"];
        MembershipCreateStatus status;
        Membership.CreateUser(this.txtEmailAddress.Text, this.txtPassword.Text, this.txtEmailAddress.Text, "What is Your Email.?", this.txtEmailAddress.Text, true, out status);
        if (status != MembershipCreateStatus.Success)
          return;
        Roles.AddUserToRole(this.txtEmailAddress.Text, "Accountant");
        this.Response.Redirect("AccountantRegistration.aspx?em=" + this.txtEmailAddress.Text + str);
      }
      else
        this.DisplayAlert("Please Fill All Required Fields");
    }

    public void DisplayAlert(string message)
    {
      this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">" + this.GetAlertScript(message) + "</script>");
    }

    public string GetAlertScript(string message)
    {
      return "alert('" + message.Replace("'", "\\'") + "');";
    }

    protected void lnkBtnPassword_OnClick(object sender, EventArgs e)
    {
      string str = string.Empty;
      if (this.Request.QueryString["cmdId"] != null && this.Request.QueryString["Dated"] != null)
        str = str + "&cmdId=" + this.Request.QueryString["cmdId"] + "&Dated=" + this.Request.QueryString["Dated"];
      this.Response.Redirect("AccountantSignUp.aspx?cmd=pr" + str);
    }

    protected void lnkBtnRegister_OnClick(object sender, EventArgs e)
    {
      string str = string.Empty;
      if (this.Request.QueryString["cmdId"] != null && this.Request.QueryString["Dated"] != null)
        str = str + "&cmdId=" + this.Request.QueryString["cmdId"] + "&Dated=" + this.Request.QueryString["Dated"];
      this.Response.Redirect("AccountantSignUp.aspx?cmd=register" + str);
    }

    protected void lnkBtnLogin_OnClick(object sender, EventArgs e)
    {
      string str = string.Empty;
      if (this.Request.QueryString["cmdId"] != null && this.Request.QueryString["Dated"] != null)
        str = str + "&cmdId=" + this.Request.QueryString["cmdId"] + "&Dated=" + this.Request.QueryString["Dated"];
      this.Response.Redirect("AccountantSignUp.aspx?" + str);
    }
  }
}

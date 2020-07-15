// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.AdminLogin
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting
{
  public class AdminLogin : Page
  {
    protected HtmlLink skin_color;
    protected HtmlForm form1;
    protected Login Login1;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.IsPostBack)
        return;
      this.Login1.FindControl("UserName").Focus();
    }

    protected void LoginButtonClick(object sender, EventArgs e)
    {
      try
      {
        if (this.Page.IsValid)
        {
          MembershipUser user = Membership.GetUser(this.Login1.UserName);
          if (user != null && !user.IsLockedOut)
          {
            if (Membership.ValidateUser(this.Login1.UserName, this.Login1.Password))
            {
              FormsAuthentication.RedirectFromLoginPage(this.Login1.UserName, false);
              if (!Roles.IsUserInRole(this.Login1.UserName, "Admin"))
                return;
              this.Response.Redirect("~/BillTransact/Default.aspx");
            }
            else
            {
              this.Login1.FailureText = "";
              ((Label) this.Login1.FindControl("errorLabel")).Text = "Invalid UserName or Password";
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
          ((Label) this.Login1.FindControl("errorLabel")).Text = "Provide valid UserName or Password";
        }
      }
      catch (Exception ex)
      {
        this.Login1.FailureText = "";
        ((Label) this.Login1.FindControl("errorLabel")).Text = ex.Message;
      }
    }
  }
}

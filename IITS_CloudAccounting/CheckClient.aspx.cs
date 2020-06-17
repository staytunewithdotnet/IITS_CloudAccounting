// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.CheckClient
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting
{
  public class CheckClient : Page
  {
    protected HiddenField hfUsername;
    protected HiddenField hfPassword;
    protected HiddenField hfRequestID;
    protected HiddenField hfPageName;
    protected Label errorLabel;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.IsPostBack)
        return;
      this.hfPageName.Value = this.Request.QueryString["page"];
      string key1 = this.Request.QueryString["keyname"];
      string key2 = this.Request.QueryString["keytech"];
      this.hfRequestID.Value = this.Request.QueryString["anyId"];
      this.hfUsername.Value = CheckClient.Decrypt(HttpUtility.UrlDecode(this.Request.QueryString["name"]), key1);
      this.hfPassword.Value = CheckClient.Decrypt(HttpUtility.UrlDecode(this.Request.QueryString["tech"]), key2);
      if (string.IsNullOrEmpty(this.hfRequestID.Value) || string.IsNullOrEmpty(this.hfUsername.Value) || (string.IsNullOrEmpty(this.hfPassword.Value) || string.IsNullOrEmpty(this.hfPageName.Value)))
        return;
      this.ClientLoginWithPages();
    }

    private void ClientLoginWithPages()
    {
      MembershipUser user = Membership.GetUser(this.hfUsername.Value);
      if (user != null)
      {
        if (user.IsApproved)
        {
          if (!user.IsLockedOut)
          {
            if (Membership.ValidateUser(this.hfUsername.Value, this.hfPassword.Value))
            {
              FormsAuthentication.RedirectFromLoginPage(this.hfUsername.Value, false);
              if (!Roles.IsUserInRole(this.hfUsername.Value, "CompanyClient"))
                return;
              switch (this.hfPageName.Value)
              {
                case "invoice":
                  this.Response.Redirect("~/Client/AllInvoice.aspx?cmd=view&ID=" + this.hfRequestID.Value);
                  break;
                case "estimate":
                  this.Response.Redirect("~/Client/ClientEstimate.aspx?cmd=view&ID=" + this.hfRequestID.Value);
                  break;
                case "credit":
                  this.Response.Redirect("~/Client/ClientCredit.aspx?cmd=view&ID=" + this.hfRequestID.Value);
                  break;
                default:
                  this.Response.Redirect("MemberArea.aspx");
                  break;
              }
            }
            else
              this.errorLabel.Text = "Invalid URL. Or URL is expired.";
          }
          else
            this.errorLabel.Text = "This account has been Locked. Contact Support for UnLock your account.";
        }
        else
          this.errorLabel.Text = "This account is locked by system adminstrator. Contact Support to Unlock your account.";
      }
      else
        this.errorLabel.Text = "Invalid URL. Or URL is expired.";
    }

    private static string Decrypt(string cipherText, string key)
    {
      string password = key;
      cipherText = cipherText.Replace(" ", "+");
      byte[] buffer = Convert.FromBase64String(cipherText);
      using (Aes aes = Aes.Create())
      {
        Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, new byte[13]
        {
          (byte) 73,
          (byte) 118,
          (byte) 97,
          (byte) 110,
          (byte) 32,
          (byte) 77,
          (byte) 101,
          (byte) 100,
          (byte) 118,
          (byte) 101,
          (byte) 100,
          (byte) 101,
          (byte) 118
        });
        if (aes != null)
        {
          aes.Key = rfc2898DeriveBytes.GetBytes(32);
          aes.IV = rfc2898DeriveBytes.GetBytes(16);
          using (MemoryStream memoryStream = new MemoryStream())
          {
            using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
            {
              cryptoStream.Write(buffer, 0, buffer.Length);
              cryptoStream.Close();
            }
            cipherText = Encoding.Unicode.GetString(memoryStream.ToArray());
          }
        }
      }
      return cipherText;
    }
  }
}

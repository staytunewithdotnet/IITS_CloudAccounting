// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.CompanyRegistration
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TemplateParser;

namespace IITS_CloudAccounting
{
  public class CompanyRegistration : Page
  {
    private readonly CurrencyMasterBLL objCurrencyMasterBll = new CurrencyMasterBLL();
    private CloudAccountDA.CurrencyMasterDataTable objCurrencyMasterDT = new CloudAccountDA.CurrencyMasterDataTable();
    private readonly UserBLL objUserBll = new UserBLL();
    private CloudAccountDA.aspnet_UsersDataTable objUserDT = new CloudAccountDA.aspnet_UsersDataTable();
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
    private readonly PackageMasterBLL objPackageMasterBll = new PackageMasterBLL();
    private CloudAccountDA.PackageMasterDataTable objPackageMasterDT = new CloudAccountDA.PackageMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private readonly CompanyPackageDetailsBLL objCompanyPackageDetailsBll = new CompanyPackageDetailsBLL();
    protected ToolkitScriptManager tsm;
    protected Panel pnlConfirmation;
    protected Panel pnlRegistration;
    protected UpdatePanel upCaptcha;
    protected TextBox txtCompanyName;
    protected RequiredFieldValidator rfvCompanyName;
    protected TextBox txtContactPerson;
    protected RequiredFieldValidator rfvContactPerson;
    protected TextBox txtContactPersonNumber;
    protected RequiredFieldValidator rfvContactPersonNumber;
    protected TextBox txtPhoneNum;
    protected RequiredFieldValidator rfvPhoneNum;
    protected DropDownList ddlCountry;
    protected RequiredFieldValidator rfvCountry;
    protected TextBox txtEmail;
    protected RequiredFieldValidator rfvEmail;
    protected RegularExpressionValidator revtxtEmailAddress;
    protected TextBox txtUserName;
    protected RequiredFieldValidator rfvUserName;
    protected TextBox txtPassword;
    protected RequiredFieldValidator rfvPassword;
    protected Image imgCaptcha;
    protected Button btnRefresh;
    protected TextBox txtCaptcha;
    protected RequiredFieldValidator rfvCaptcha;
    protected Button btnSubmit;
    protected DropDownList ddlPackage;
    protected SqlDataSource sqldsPackageName;
    protected Repeater rpPackageDetail;
    protected SqlDataSource sqldsPackage;
    protected SqlDataSource sqldsCountry;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("pricing")).Attributes.Add("class", "current-menu-item current-menu-ancestor");
      if (this.IsPostBack)
        return;
      this.Clear();
      this.FillCapctha();
      if (this.Request.QueryString["pId"] != null)
      {
        this.ddlPackage.Items.Add(this.Request.QueryString["pId"]);
        this.ddlPackage.SelectedValue = this.Request.QueryString["pId"];
        this.pnlConfirmation.Visible = false;
        this.pnlRegistration.Visible = true;
        this.Clear();
      }
      else
      {
        this.pnlConfirmation.Visible = true;
        this.pnlRegistration.Visible = false;
        this.Clear();
      }
    }

    private void FillCapctha()
    {
      try
      {
        Random random = new Random();
        StringBuilder stringBuilder = new StringBuilder();
        for (int index = 0; index < 6; ++index)
          stringBuilder.Append("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"[random.Next("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".Length)]);
        this.Session["captcha"] = (object) stringBuilder.ToString();
        this.imgCaptcha.ImageUrl = "GenerateCaptcha.aspx?" + DateTime.Now.Ticks.ToString((IFormatProvider) CultureInfo.InvariantCulture);
      }
      catch (Exception ex)
      {
        this.DisplayAlert(ex.Message);
        throw;
      }
    }

    protected void BtnRefreshClick(object sender, EventArgs e)
    {
      this.FillCapctha();
    }

    protected string GetCurrency(string cID)
    {
      this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(cID));
      if (this.objCurrencyMasterDT.Rows.Count > 0)
        return this.objCurrencyMasterDT.Rows[0]["CurrencySymbol"].ToString();
      return "";
    }

    private void Clear()
    {
      this.txtCompanyName.Text = this.txtUserName.Text = this.txtPassword.Text = this.txtContactPerson.Text = "";
      this.txtContactPersonNumber.Text = this.txtEmail.Text = this.txtPhoneNum.Text = "";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.Request.QueryString["pId"] != null)
      {
        if (this.txtCompanyName.Text.Trim().Length > 0 && this.txtUserName.Text.Trim().Length > 0 && (this.txtPassword.Text.Trim().Length > 0 && this.txtContactPerson.Text.Trim().Length > 0) && (this.txtContactPersonNumber.Text.Trim().Length > 0 && this.txtEmail.Text.Trim().Length > 0 && (this.txtPhoneNum.Text.Trim().Length > 0 && this.ddlCountry.SelectedIndex > 0)) && this.txtCaptcha.Text.Trim().Length > 0)
        {
          bool flag1 = this.Session["captcha"].ToString() == this.txtCaptcha.Text;
          this.FillCapctha();
          if (flag1)
          {
            FileStream fileStream = new FileStream(this.Server.MapPath("~/App_Themes/Blue/images/logo.jpg"), FileMode.Open, FileAccess.Read);
            byte[] numArray = new byte[fileStream.Length];
            fileStream.Read(numArray, 0, (int) fileStream.Length);
            fileStream.Close();
            int iCompanyID = this.objCompanyMasterBll.AddCompany(this.txtUserName.Text.Trim(), this.Application["companyName"].ToString(), this.txtContactPerson.Text.Trim(), "", new Decimal?(new Decimal(0)), new int?(), new int?(), new int?(), new int?(), new int?(), "", "", this.txtUserName.Text.Trim(), "", "", new int?(), new int?(), new int?(), "", "application/jpg", numArray, "", "", false, "");
            if (iCompanyID != 0)
            {
              this.objCompanyLoginMasterBll.AddCompanyLogin(iCompanyID, this.txtUserName.Text.Trim(), this.txtEmail.Text.Trim(), false);
              int iPackageID = int.Parse(this.Request.QueryString["pId"]);
              this.objPackageMasterDT = this.objPackageMasterBll.GetDataByPackageID(iPackageID);
              bool flag2 = bool.Parse(this.objPackageMasterDT.Rows[0]["FreeTrialPackage"].ToString());
              double num1 = 0.0;
              if (flag2)
                num1 = double.Parse(this.objPackageMasterDT.Rows[0]["NoOfTrialDays"].ToString());
              Decimal num2 = Decimal.Parse(this.objPackageMasterDT.Rows[0]["PricePerMonth"].ToString());
              Decimal num3 = Decimal.Parse(this.objPackageMasterDT.Rows[0]["PricePerYear"].ToString());
              DateTime dateTime = DateTime.Now.AddDays(flag2 ? num1 : 365.0);
              this.objCompanyPackageDetailsBll.AddCompanyPackage(iCompanyID, iPackageID, new DateTime?(DateTime.Now), new DateTime?(dateTime), new Decimal?(num2), new Decimal?(num3), false, new Decimal?(new Decimal(0)), "", new DateTime?(), new DateTime?(), true);
              MembershipCreateStatus status;
              Membership.CreateUser(this.txtUserName.Text.Trim(), this.txtPassword.Text.Trim(), this.txtEmail.Text.Trim(), "What is your User Name?", this.txtUserName.Text, false, out status);
              Roles.AddUserToRole(this.txtUserName.Text, "Admin");
              this.SendMail(this.txtCompanyName.Text, this.txtUserName.Text, this.txtEmail.Text);
              this.pnlConfirmation.Visible = true;
              this.pnlRegistration.Visible = false;
              this.Clear();
            }
            else
              this.DisplayAlert("Problem In Insertion. Try again Later.");
          }
          else
          {
            this.DisplayAlert("Please Enter Valid Captcha Code..!");
            this.FillCapctha();
          }
        }
        else
        {
          this.DisplayAlert("Please Fill All Required Details");
          this.Clear();
        }
      }
      else
        this.DisplayAlert("Please Select Proper Package");
    }

    private void SendMail(string u, string uName, string uEmail)
    {
      string str = "http://www.billtransact.com/AfterRegister.aspx?UserName=" + uName;
      Hashtable Variables = new Hashtable();
      Variables.Add((object) "User", (object) u);
      Variables.Add((object) "UserName", (object) uName);
      Variables.Add((object) "Email", (object) uEmail);
      Variables.Add((object) "Url", (object) str);
      Variables.Add((object) "Password", (object) this.txtPassword.Text);
      Variables.Add((object) "SecurityQuestion", (object) "What is your User Name?");
      Variables.Add((object) "SecurityAnswer", (object) this.txtUserName.Text);
      Variables.Add((object) "ContactPersonName", (object) this.txtContactPerson.Text);
      Variables.Add((object) "ContactPersonNumber", (object) this.txtContactPersonNumber.Text);
      Variables.Add((object) "CompanyName", (object) this.txtCompanyName.Text);
      this.objPackageMasterDT = this.objPackageMasterBll.GetDataByPackageID(int.Parse(this.Request.QueryString["pId"]));
      Variables.Add((object) "PackageName", this.objPackageMasterDT.Rows[0]["PackageName"]);
      Variables.Add((object) "CurrencySymbolMonth", (object) this.GetCurrency(this.objPackageMasterDT.Rows[0]["MonthlyPriceCurrencyID"].ToString()));
      Variables.Add((object) "PricePerMonth", this.objPackageMasterDT.Rows[0]["PricePerMonth"]);
      Variables.Add((object) "CurrencySymbolYear", (object) this.GetCurrency(this.objPackageMasterDT.Rows[0]["YearlyPriceCurrencyID"].ToString()));
      Variables.Add((object) "PricePerYear", this.objPackageMasterDT.Rows[0]["PricePerYear"]);
      Variables.Add((object) "NoOfAdminUsersMin", this.objPackageMasterDT.Rows[0]["NoOfAdminUsersMin"]);
      Variables.Add((object) "NoOfAdminUsersMax", this.objPackageMasterDT.Rows[0]["NoOfAdminUsersMax"]);
      Variables.Add((object) "NoOfStaffUsersMin", this.objPackageMasterDT.Rows[0]["NoOfStaffUsersMin"]);
      Variables.Add((object) "NoOfStaffUsersMax", this.objPackageMasterDT.Rows[0]["NoOfStaffUsersMax"]);
      Parser parser = new Parser(this.Server.MapPath("~/MailTemplate/CompanyRegistration.htm"), Variables);
      try
      {
        MailMessage message = new MailMessage()
        {
          From = new MailAddress("noreply@DoyniGo.com", "DoyinGo")
        };
        message.To.Add(new MailAddress(uEmail));
        message.Subject = "DoyniGo Registration";
        message.BodyEncoding = Encoding.UTF8;
        message.Body = parser.Parse();
        message.IsBodyHtml = true;
        new SmtpClient().Send(message);
        this.DisplayAlert("Registration Mail sent successfully.");
      }
      catch (Exception ex)
      {
        this.DisplayAlert("Error in sending mail." + (object) ex);
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

    protected void txtCompanyName_OnTextChanged(object sender, EventArgs e)
    {
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyName(this.txtCompanyName.Text.Trim());
      if (this.objCompanyMasterDT.Rows.Count > 0)
      {
        this.DisplayAlert("Company Already Register With System.");
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Company Already Register With System.')", true);
        this.txtCompanyName.Text = "";
        this.txtCompanyName.Focus();
      }
      else
        this.txtContactPerson.Focus();
    }

    protected void txtUserName_OnTextChanged(object sender, EventArgs e)
    {
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyUserName(this.txtUserName.Text.Trim());
      this.objUserDT = this.objUserBll.GetAllDetail(this.txtUserName.Text.Trim());
      if (this.objCompanyMasterDT.Rows.Count > 0 || this.objUserDT.Rows.Count > 0)
      {
        this.DisplayAlert("UserName Already Exists In System.");
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('UserName Already Exists In System.')", true);
        this.txtUserName.Text = "";
        this.txtUserName.Focus();
      }
      else
        this.txtPassword.Focus();
    }

    protected void txtEmail_OnTextChanged(object sender, EventArgs e)
    {
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyEmail(this.txtEmail.Text.Trim());
      if (this.objCompanyMasterDT.Rows.Count > 0)
      {
        this.DisplayAlert("Company Email Already Register With System.");
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Company Email Already Register With System.')", true);
        this.txtEmail.Text = "";
        this.txtEmail.Focus();
      }
      else
        this.txtUserName.Focus();
    }

    protected void ddlPackage_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("CompanyRegistration.aspx?pId=" + this.ddlPackage.SelectedItem.Value);
    }
  }
}

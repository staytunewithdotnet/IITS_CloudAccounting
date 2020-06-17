// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.MemberArea
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using DABL.BLL;
using DABL.DAL;
using IITS_CloudAccounting.Admin;
using System;
using System.Collections;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TemplateParser;

namespace IITS_CloudAccounting
{
    public class MemberArea : Page
    {
        private readonly RecurringMasterBLL objRecurringMasterBll = new RecurringMasterBLL();
        private CloudAccountDA.RecurringMasterDataTable objRecurringMasterDT = new CloudAccountDA.RecurringMasterDataTable();
        private readonly FrequencyMasterBLL objFrequencyMasterBll = new FrequencyMasterBLL();
        private CloudAccountDA.FrequencyMasterDataTable objFrequencyMasterDT = new CloudAccountDA.FrequencyMasterDataTable();
        private readonly InvoiceMasterBLL objInvoiceMasterBll = new InvoiceMasterBLL();
        private CloudAccountDA.InvoiceMasterDataTable objInvoiceMasterDT = new CloudAccountDA.InvoiceMasterDataTable();
        private readonly CompanyClientMasterBLL objCompanyClientMasterBll = new CompanyClientMasterBLL();
        private CloudAccountDA.CompanyClientMasterDataTable objCompanyClientMasterDT = new CloudAccountDA.CompanyClientMasterDataTable();
        private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
        private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
        private readonly RecurringItemDetailBLL objRecurringItemDetailBll = new RecurringItemDetailBLL();
        private CloudAccountDA.RecurringItemDetailDataTable objRecurringItemDetailDT = new CloudAccountDA.RecurringItemDetailDataTable();
        private readonly RecurringTaskDetailBLL objRecurringTaskDetailBll = new RecurringTaskDetailBLL();
        private CloudAccountDA.RecurringTaskDetailDataTable objRecurringTaskDetailDT = new CloudAccountDA.RecurringTaskDetailDataTable();
        private readonly NewInvoiceEmailTemplateBLL objNewInvoiceEmailTemplateBll = new NewInvoiceEmailTemplateBLL();
        private CloudAccountDA.NewInvoiceEmailTemplateDataTable objNewInvoiceEmailTemplateDT = new CloudAccountDA.NewInvoiceEmailTemplateDataTable();
        private readonly SMTPSettingsBLL objSMTPSettingsBll = new SMTPSettingsBLL();
        private CloudAccountDA.SMTPSettingsDataTable objSMTPSettingsDT = new CloudAccountDA.SMTPSettingsDataTable();
        private readonly InvoiceItemDetailBLL objInvoiceItemDetailBll = new InvoiceItemDetailBLL();
        private readonly InvoiceTaskDetailBLL objInvoiceTaskDetailBll = new InvoiceTaskDetailBLL();
        protected Panel pnlLogin;
        protected Login Login1;
        protected Panel pnlPassword;
        protected PasswordRecovery PasswordRecovery1;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (this.Master == null)
            //    return;
            //((HtmlControl)this.Master.FindControl("login")).Attributes.Add("class", "current-menu-item current-menu-ancestor");
            if (this.IsPostBack)
                return;
            if (this.Request.QueryString["cmd"] != null)
            {
                if (this.Request.QueryString["cmd"] == "pr")
                {
                    this.pnlLogin.Visible = false;
                    this.pnlPassword.Visible = true;
                }
                else
                {
                    this.pnlLogin.Visible = true;
                    this.pnlPassword.Visible = false;
                    this.Login1.FindControl("UserName").Focus();
                }
            }
            else
            {
                this.pnlLogin.Visible = true;
                this.pnlPassword.Visible = false;
                this.Login1.FindControl("UserName").Focus();
            }
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
                        //this.CallAllRecurringInvoice();
                        if (user.IsApproved)
                        {
                            if (!user.IsLockedOut)
                            {
                                if (Membership.ValidateUser(this.Login1.UserName, this.Login1.Password))
                                {
                                    ///this["IITS_CloudAccountingConnectionString"] = '';
                                    FormsAuthentication.RedirectFromLoginPage(this.Login1.UserName, false);
                                    if (Roles.IsUserInRole(this.Login1.UserName, "SuperAdmin"))
                                    {
                                        Admin.Admin.RoleName = "SuperAdmin";
                                        this.Response.Redirect("~/Admin/Default.aspx");
                                    }
                                    else if (Roles.IsUserInRole(this.Login1.UserName, "MasterAdmin"))
                                    {
                                        Admin.Admin.RoleName = "MasterAdmin";
                                        this.Response.Redirect("~/Admin/Default.aspx");
                                    }
                                    else if (Roles.IsUserInRole(this.Login1.UserName, "Admin") || Roles.IsUserInRole(this.Login1.UserName, "Employee"))
                                    {
                                        if (this.Application.Count > 0)
                                            this.Application.Clear();
                                        this.Response.Redirect("~/Admin/DefaultDoyingo.aspx?re=1");
                                    }
                                    else
                                    {
                                        if (!Roles.IsUserInRole(this.Login1.UserName, "CompanyClient"))
                                            return;
                                        this.Response.Redirect("~/Client/Default.aspx");
                                    }
                                }
                                else
                                {
                                    this.Login1.FailureText = "";
                                    ((Label)this.Login1.FindControl("errorLabel")).Text = "Invalid UserName or Password.";
                                }
                            }
                            else
                            {
                                this.Login1.FailureText = "";
                                ((Label)this.Login1.FindControl("errorLabel")).Text = "You have process many wrong Passwords. Your account has been Locked. Contact Support for UnLock your account.";
                            }
                        }
                        else
                        {
                            this.Login1.FailureText = "";
                            ((Label)this.Login1.FindControl("errorLabel")).Text = "Your account is locked by system. Contact Support to Unlock your account.";
                        }
                    }
                    else
                    {
                        this.Login1.FailureText = "";
                        ((Label)this.Login1.FindControl("errorLabel")).Text = "Invalid UserName.";
                    }
                }
                else
                {
                    this.Login1.FailureText = "";
                    ((Label)this.Login1.FindControl("errorLabel")).Text = "Provide valid UserName or Password.";
                }
            }
            catch (Exception ex)
            {
                this.Login1.FailureText = "";
                ((Label)this.Login1.FindControl("errorLabel")).Text = ex.Message;
            }
        }

        protected void BtnContClick(object sender, EventArgs e)
        {
            this.Response.Redirect("MemberArea.aspx");
        }

        private void CallAllRecurringInvoice()
        {
            this.objRecurringMasterDT = this.objRecurringMasterBll.GetAllActiveTodayRecurring();
            if (this.objRecurringMasterDT.Rows.Count <= 0)
                return;
            for (int index = 0; index < this.objRecurringMasterDT.Rows.Count; ++index)
            {
                int iRecurringID = int.Parse(this.objRecurringMasterDT.Rows[index]["RecurringID"].ToString());
                int num1 = int.Parse(this.objRecurringMasterDT.Rows[index]["CompanyID"].ToString());
                int num2 = int.Parse(this.objRecurringMasterDT.Rows[index]["ClientID"].ToString());
                int iFrequencyID = int.Parse(this.objRecurringMasterDT.Rows[index]["HowOften"].ToString());
                DateTime dtNextDate = DateTime.Parse(this.objRecurringMasterDT.Rows[index]["NextDate"].ToString());
                string str1 = this.objRecurringMasterDT.Rows[index]["RemainingInvoice"].ToString();
                bool bRecurringActive = true;
                string s;
                try
                {
                    s = int.Parse(str1.Trim()).ToString();
                }
                catch (Exception ex)
                {
                    s = "-1";
                }
                this.objFrequencyMasterDT = this.objFrequencyMasterBll.GetDataByFrequencyID(iFrequencyID);
                if (this.objFrequencyMasterDT.Rows.Count > 0)
                {
                    int num3 = int.Parse(this.objFrequencyMasterDT.Rows[0]["NoOfDays"].ToString());
                    dtNextDate = dtNextDate.AddDays((double)num3);
                }
                string sRemainingInvoice;
                switch (s)
                {
                    case "-1":
                        sRemainingInvoice = "infinite";
                        break;
                    default:
                        sRemainingInvoice = (int.Parse(s) - 1).ToString();
                        if (sRemainingInvoice == "0")
                        {
                            bRecurringActive = false;
                            break;
                        }
                        break;
                }
                this.objRecurringMasterBll.UpdateForSentInvoice(iRecurringID, sRemainingInvoice, dtNextDate, bRecurringActive);
                this.objInvoiceMasterDT = this.objInvoiceMasterBll.GetDataByCompanyID(num1);
                string str2 = this.objInvoiceMasterDT.Rows.Count <= 0 ? ConfigurationManager.AppSettings["InvoiceNoStart"] : InvoiceMaster.NextNum(this.objInvoiceMasterDT.Rows[this.objInvoiceMasterDT.Rows.Count - 1]["InvoiceNumber"].ToString());
                int num4 = this.objInvoiceMasterBll.AddInvoice(str2, iRecurringID);
                this.objRecurringItemDetailDT = this.objRecurringItemDetailBll.GetDataByRecurringID(iRecurringID);
                if (this.objRecurringItemDetailDT.Rows.Count > 0)
                    this.objInvoiceItemDetailBll.AddInvoiceItem(num4, iRecurringID);
                this.objRecurringTaskDetailDT = this.objRecurringTaskDetailBll.GetDataByRecurringID(iRecurringID);
                if (this.objRecurringTaskDetailDT.Rows.Count > 0)
                    this.objInvoiceTaskDetailBll.AddInvoiceTask(num4, iRecurringID);
                this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(num2);
                if (this.objCompanyClientMasterDT.Rows.Count > 0)
                    this.SendMail(this.objCompanyClientMasterDT.Rows[0]["Email"].ToString(), str2, num4, num2, num1);
            }
        }

        private static string GenerateCode()
        {
            Random random = new Random();
            StringBuilder stringBuilder = new StringBuilder();
            for (int index = 0; index < 10; ++index)
                stringBuilder.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"[random.Next("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".Length)]);
            return stringBuilder.ToString();
        }

        private string Encrypt(string clearText, string key)
        {
            string password = key;
            byte[] bytes = Encoding.Unicode.GetBytes(clearText);
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
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(bytes, 0, bytes.Length);
                            cryptoStream.Close();
                        }
                        clearText = Convert.ToBase64String(memoryStream.ToArray());
                    }
                }
            }
            return clearText;
        }

        private void SendMail(string email, string invoiceNum, int invoiceId, int clientId, int companyID)
        {
            this.objInvoiceMasterDT = this.objInvoiceMasterBll.GetDataByInvoiceID(invoiceId);
            string str1 = this.objInvoiceMasterDT.Rows[0]["InvoiceNumber"].ToString();
            string s1 = this.objInvoiceMasterDT.Rows[0]["InvoiceTotal"].ToString();
            string s2 = this.objInvoiceMasterDT.Rows[0]["PaidToDate"].ToString();
            Decimal num = Decimal.Parse(s1) - Decimal.Parse(s2);
            this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(companyID);
            string displayName = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString().ToUpper();
            string addresses = this.objCompanyMasterDT.Rows[0]["CompanyEmail"].ToString();
            string str2 = string.Empty;
            string str3 = string.Empty;
            string str4 = string.Empty;
            string str5 = string.Empty;
            this.objCompanyClientMasterDT = this.objCompanyClientMasterBll.GetDataByCompanyClientID(clientId);
            if (this.objCompanyClientMasterDT.Rows.Count > 0)
            {
                string username = this.objCompanyClientMasterDT.Rows[0]["UserName"].ToString();
                str3 = this.objCompanyClientMasterDT.Rows[0]["OrganizationName"].ToString();
                str4 = this.objCompanyClientMasterDT.Rows[0]["FirstName"].ToString();
                str5 = this.objCompanyClientMasterDT.Rows[0]["LastName"].ToString();
                email = this.objCompanyClientMasterDT.Rows[0]["Email"].ToString();
                MembershipUser user = Membership.GetUser(username);
                if (user != null)
                {
                    string key1 = MemberArea.GenerateCode();
                    string str6 = HttpUtility.UrlEncode(this.Encrypt(user.UserName, key1));
                    string password = user.GetPassword();
                    string key2 = MemberArea.GenerateCode();
                    string str7 = HttpUtility.UrlEncode(this.Encrypt(password, key2));
                    str2 = string.Format("http://www.billtransact.com/CheckClient.aspx?page=invoice&anyId={0}&name={1}&tech={2}&keyname={3}&keytech={4}", (object)invoiceId, (object)str6, (object)str7, (object)key1, (object)key2);
                }
            }
            string str8 = string.Empty;
            string str9 = string.Empty;
            string address = "noreply@DoyniGo.com";
            this.objSMTPSettingsDT = this.objSMTPSettingsBll.GetDataByCompanyID(companyID);
            if (this.objSMTPSettingsDT.Rows.Count > 0)
            {
                str9 = this.objSMTPSettingsDT.Rows[0]["EmailSignature"].ToString();
                address = this.objSMTPSettingsDT.Rows[0]["SMTPFrom"].ToString();
            }
            this.objNewInvoiceEmailTemplateDT = this.objNewInvoiceEmailTemplateBll.GetDataByCompanyID(companyID);
            if (this.objNewInvoiceEmailTemplateDT.Rows.Count > 0)
                str8 = this.objNewInvoiceEmailTemplateDT.Rows[0]["EmailBody"].ToString();
            Hashtable Variables = new Hashtable()
      {
        {
          (object) "emailTemplate",
          (object) str8
        },
        {
          (object) "companyName",
          (object) displayName
        },
        {
          (object) "companyEmail",
          (object) ("<a href=\"mailto:" + addresses + "\">" + addresses + "</a>")
        },
        {
          (object) "invoiceNumber",
          (object) str1
        },
        {
          (object) "amountOwned",
          (object) num
        },
        {
          (object) "clientOrgName",
          (object) str3
        },
        {
          (object) "firstName",
          (object) str4
        },
        {
          (object) "lastName",
          (object) str5
        },
        {
          (object) "invoiceAmt",
          (object) s1
        },
        {
          (object) "someLink",
          (object) str2
        },
        {
          (object) "directLink",
          (object) "block"
        },
        {
          (object) "branding",
          (object) "block"
        },
        {
          (object) "emailSign",
          (object) str9
        }
      };
            Parser parser1 = new Parser(this.Server.MapPath("~/MailTemplate/SendInvoiceNew.html"), Variables);
            string path1 = this.Server.MapPath("~\\TempHTMLFiles\\");
            File.WriteAllText(Path.Combine(path1, "Invoice.html"), parser1.Parse());
            Parser parser2 = new Parser(path1 + "Invoice.html", Variables);
            try
            {
                MailMessage message = new MailMessage()
                {
                    From = new MailAddress(address, displayName)
                };
                message.To.Add(new MailAddress(email));
                message.ReplyToList.Add(addresses);
                message.Subject = "New invoice " + invoiceNum + " from " + displayName + ", sent using Bill Transact";
                message.BodyEncoding = Encoding.UTF8;
                message.Body = parser2.Parse();
                message.IsBodyHtml = true;
                SmtpClientForCompany.smtpClient(companyID.ToString()).Send(message);
            }
            catch (Exception ex)
            {
            }
        }
    }
}

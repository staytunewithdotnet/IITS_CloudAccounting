using DABL.BLL;
using DABL.DAL;
using Newtonsoft.Json;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace IITS_CloudAccounting.Common
{
    public class CommonHandler
    {
        public static string WebsiteBaseURL = "https://billtransact.com";
        public static string BaseHost = "mail.billtransact.com";
        public static string BasePort = "25";
        public static string BasePassword = "mykamil@2019";
        public static string BaseUserName = "noreply@billtransact.com";
        public static string BaseMailFrom = "raushan790@hotmail.com";// "noreply@billtransact.com";
        public static bool BaseEnableSSL = false;
        public static async Task SendMail(string CompanyID, string MailTo, string Subject, string Body, bool IsBodyHTML)
        {
            try
            {
                string apiKey = "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";
                //string apiKey = "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";
                // apiKey = "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";
                var client = new SendGridClient(apiKey);
                
                string data = @"{
                          'personalizations': [
                            {
                              'to': [
                                {
                                  'email': '" + MailTo + @"'
                                }
                              ],
                                'subject': '" + Subject + @"'
                            }
                          ],
                          'from': {
                            'email': '" + BaseMailFrom + @"'
                          },
                          'content': [
                            {
                              'type': 'text/html',
                               'value': '" + Body.Replace("'","##") + @"'
                            }
                          ]
                        }";

                Object json = JsonConvert.DeserializeObject<Object>(data);

                var response = await client.RequestAsync(SendGridClient.Method.POST,
                                                     json.ToString().Replace("##","'"),
                                                     urlPath: "mail/send");
                //var response = await client.RequestAsync(SendGridClient.Method.POST,data, urlPath: "mail/send");
            }
            catch (Exception ex) { throw ex; }
        }
        public static void SendSMTPEmail(string CompanyID, string MailTo, string Subject, string Body, bool IsBodyHTML)
        {
            try
            {
                string Host = "", Port = "", Password = "", UserName = "", MailFrom = "";
                bool EnableSSL = false;
                CloudAccountDA.SMTPSettingsDataTable dataByCompanyId = new SMTPSettingsBLL().GetDataByCompanyID(int.Parse(CompanyID));
                if (dataByCompanyId.Rows.Count > 0)
                {
                    Host = dataByCompanyId.Rows[0]["Host"].ToString();
                    Port = dataByCompanyId.Rows[0]["Port"].ToString();
                    Password = dataByCompanyId.Rows[0]["Password"].ToString();
                    UserName = dataByCompanyId.Rows[0]["Username"].ToString();
                    EnableSSL = bool.Parse(dataByCompanyId.Rows[0]["EnableSSL"].ToString());
                    MailFrom = UserName;
                }
                else
                {
                    Host = BaseHost;
                    Port = BasePort;
                    Password = BasePassword;
                    UserName = BaseUserName;
                    EnableSSL = BaseEnableSSL;
                    MailFrom = BaseMailFrom;
                }
                SmtpClient smtp = new SmtpClient();
                smtp.Host = Host;
                smtp.Port = Convert.ToInt32(Port);
                smtp.EnableSsl = EnableSSL;
                smtp.Credentials = new NetworkCredential(UserName, Password);

                MailMessage message = new MailMessage();
                message.From = new MailAddress(MailFrom, "Bill Transact");
                message.To.Add(new MailAddress(MailTo));
                message.Subject = Subject;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.Body = Body;
                message.IsBodyHtml = IsBodyHTML;

                smtp.Send(message);
            }
            catch (Exception ex)
            {
            }
        }
        public static void CheckSMTPEmail(string Host, string Port, bool EnableSSL, string UserName, string Password, string MailTo, string Subject, string Body, bool IsBodyHTML)
        {
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = Host;
                smtp.Port = Convert.ToInt32(Port);
                smtp.EnableSsl = EnableSSL;
                smtp.Credentials = new NetworkCredential(UserName, Password);

                MailMessage message = new MailMessage();
                message.From = new MailAddress(BaseMailFrom, "Bill Transact");
                message.To.Add(new MailAddress(MailTo));
                message.Subject = Subject;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.Body = Body;
                message.IsBodyHtml = IsBodyHTML;

                smtp.Send(message);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
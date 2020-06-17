// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.SmtpClientForCompany
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using DABL.BLL;
using DABL.DAL;
using System.Net;
using System.Net.Mail;

namespace IITS_CloudAccounting.Admin
{
  public class SmtpClientForCompany
  {
    public static SmtpClient smtpClient(string companyId)
    {
      CloudAccountDA.SMTPSettingsDataTable dataByCompanyId = new SMTPSettingsBLL().GetDataByCompanyID(int.Parse(companyId));
      if (dataByCompanyId.Rows.Count <= 0)
        return new SmtpClient();
      string str = dataByCompanyId.Rows[0]["Host"].ToString();
      string s = dataByCompanyId.Rows[0]["Port"].ToString();
      string password = dataByCompanyId.Rows[0]["Password"].ToString();
      string userName = dataByCompanyId.Rows[0]["Username"].ToString();
      bool flag = bool.Parse(dataByCompanyId.Rows[0]["EnableSSL"].ToString());
      NetworkCredential networkCredential = new NetworkCredential(userName, password);
            SmtpClient smtp = new SmtpClient();
            smtp.Host = str;
            smtp.Port = int.Parse(s);
            smtp.EnableSsl = flag;
            smtp.Credentials = networkCredential;

            return smtp;
      //      return new SmtpClient()
      //{
      //  Port = int.Parse(s),
      //  Host = str,
      //  EnableSsl = flag,
      //  UseDefaultCredentials = true,
      //  Credentials = (ICredentialsByHost) networkCredential
      //};
            
        }
  }
}

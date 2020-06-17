// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Handler.CompanyLogoFile
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using DABL.BLL;
using DABL.DAL;
using System;
using System.IO;
using System.Web;

namespace IITS_CloudAccounting.Handler
{
  public class CompanyLogoFile : IHttpHandler
  {
    private readonly CompanyMasterBLL _objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable _objCompanyMasterDt = new CloudAccountDA.CompanyMasterDataTable();

    public bool IsReusable
    {
      get
      {
        return false;
      }
    }

    public void ProcessRequest(HttpContext context)
    {
      if (context.Request.QueryString["id"] == null)
        throw new ArgumentException("No parameter specified");
      int conId = Convert.ToInt32(context.Request.QueryString["id"]);
      context.Response.ContentType = "image/jpeg";
      Stream stream = this.ShowProfileImage(conId);
      byte[] buffer = new byte[4096];
      for (int count = stream.Read(buffer, 0, 4096); count > 0; count = stream.Read(buffer, 0, 4096))
        context.Response.OutputStream.Write(buffer, 0, count);
    }

    public Stream ShowProfileImage(int conId)
    {
      this._objCompanyMasterDt = this._objCompanyMasterBll.GetDataByCompanyID(conId);
      try
      {
        return (Stream) new MemoryStream((byte[]) this._objCompanyMasterDt.Rows[0]["CompanyLogo"]);
      }
      catch
      {
        return (Stream) null;
      }
    }
  }
}

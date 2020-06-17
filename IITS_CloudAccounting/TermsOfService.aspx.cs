// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.TermsOfService
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using DABL.BLL;
using DABL.DAL;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting
{
  public class TermsOfService : Page
  {
    private readonly TermServiceContentBLL _objTermsContentBll = new TermServiceContentBLL();
    private CloudAccountDA.TermServiceContentDataTable _objTermsContentDt = new CloudAccountDA.TermServiceContentDataTable();
    protected Label lblTerms;

    protected void Page_Load(object sender, EventArgs e)
    {
      this._objTermsContentDt = this._objTermsContentBll.GetAllDetail();
      if (this._objTermsContentDt.Rows.Count <= 0)
        return;
      this.lblTerms.Text = this._objTermsContentDt.Rows[0]["TermServiceContent"].ToString();
    }
  }
}

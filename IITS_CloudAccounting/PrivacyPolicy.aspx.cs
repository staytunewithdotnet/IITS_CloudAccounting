// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.PrivacyPolicy
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
  public class PrivacyPolicy : Page
  {
    private readonly PrivacyPolicyContentBLL _objPolicyContentBll = new PrivacyPolicyContentBLL();
    private CloudAccountDA.PrivacyPolicyContentDataTable _objPolicyContentDt = new CloudAccountDA.PrivacyPolicyContentDataTable();
    protected Label lblPrivacy;

    protected void Page_Load(object sender, EventArgs e)
    {
      this._objPolicyContentDt = this._objPolicyContentBll.GetAllDetail();
      if (this._objPolicyContentDt.Rows.Count <= 0)
        return;
      this.lblPrivacy.Text = this._objPolicyContentDt.Rows[0]["PrivacyPolicyContent"].ToString();
    }
  }
}

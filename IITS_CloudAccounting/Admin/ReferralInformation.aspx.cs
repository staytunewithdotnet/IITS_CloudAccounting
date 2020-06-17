// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.ReferralInformation
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace IITS_CloudAccounting.Admin
{
  public class ReferralInformation : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("home")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("referDoyingo")).Attributes.Add("class", "active open");
    }
  }
}

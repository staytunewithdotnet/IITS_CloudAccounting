// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.ChangePassword
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using System;
using System.Web.UI;

namespace IITS_CloudAccounting.Admin
{
  public class ChangePassword : Page
  {
    protected System.Web.UI.WebControls.ChangePassword ChangePassword1;

    private void Page_PreInit(object sender, EventArgs e)
    {
      if (Admin.RoleName == "Admin" || Doyingo.RoleName == "Admin")
        this.MasterPageFile = "~/Admin/Doyingo.Master";
      else
        this.MasterPageFile = "~/Admin/Admin.Master";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void CancelPushButtonClick(object sender, EventArgs e)
    {
      if (Admin.RoleName == "Admin" || Doyingo.RoleName == "Admin")
        this.Response.Redirect("~/Admin/DefaultDoyingo.aspx");
      else
        this.Response.Redirect("~/Admin/Default.aspx");
    }
  }
}

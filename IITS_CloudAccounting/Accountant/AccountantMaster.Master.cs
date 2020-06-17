// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Accountant.AccountantMaster
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Accountant
{
  public class AccountantMaster : MasterPage
  {
    protected ContentPlaceHolder head;
    protected HtmlForm form1;
    protected HtmlGenericControl staffProfile;
    protected LoginStatus LoginStatus2;
    protected Image imgLogo;
    protected ToolkitScriptManager ToolkitScriptManager1;
    protected ContentPlaceHolder ContentPlaceHolder1;
    protected DataList dlFooter;
    protected SqlDataSource sqldsFooter;
    protected HtmlGenericControl overlay;

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void LoginStatus1_OnLoggingOut(object sender, LoginCancelEventArgs e)
    {
      FormsAuthentication.SignOut();
    }
  }
}

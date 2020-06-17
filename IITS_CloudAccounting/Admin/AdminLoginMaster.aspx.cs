// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.AdminLoginMaster
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class AdminLoginMaster : Page
  {
    protected Panel pnlAdd;
    protected HtmlGenericControl companyDropDownDiv;
    protected DropDownList ddlCompanyName;
    protected TextBox txtFirstName;
    protected RequiredFieldValidator rfvFirstName;
    protected TextBox txtLastName;
    protected RequiredFieldValidator rfvLastName;
    protected TextBox txtLoginUserName;
    protected RequiredFieldValidator rfvLogiUserName;
    protected TextBox txtLoginEmail;
    protected DropDownList ddlRoles;
    protected SqlDataSource sdsRole;
    protected TextBox txtLoginPassword;
    protected RequiredFieldValidator rfvLoginPassword;
    protected TextBox txtSecurityQue;
    protected TextBox txtSecurityAns;
    protected HtmlGenericControl chkkIsLockedOut;
    protected CheckBox chkIsLockedOut;
    protected CheckBox chkIsApproved;
    protected HtmlGenericControl IsLockedOut;
    protected Label lblAccount;
    protected Button btnSubmit;
    protected Button btnReset;
    protected Button btnUpdate;
    protected Button btnCancel;
    protected Button btnListAll;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("cmsMaster")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("adminLogin")).Attributes.Add("class", "active open");
    }
  }
}

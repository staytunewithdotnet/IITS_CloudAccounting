// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.ClientContactDetail
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using DABL.BLL;
using DABL.DAL;
using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class ClientContactDetail : UserControl
  {
    private readonly UserBLL objUserBll = new UserBLL();
    private CloudAccountDA.aspnet_UsersDataTable objUserDT = new CloudAccountDA.aspnet_UsersDataTable();
    private readonly CompanyClientContactDetailBLL objCompanyClientContactDetailBll = new CompanyClientContactDetailBLL();
    private readonly ContractorMasterBLL objContractorMasterBll = new ContractorMasterBLL();
    private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
    private CloudAccountDA.CompanyClientContactDetailDataTable objCompanyClientContactDetailDT = new CloudAccountDA.CompanyClientContactDetailDataTable();
    private CloudAccountDA.ContractorMasterDataTable objContractorMasterDT = new CloudAccountDA.ContractorMasterDataTable();
    private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    protected TextBox txtEmail;
    protected RequiredFieldValidator rfvEmail;
    protected RegularExpressionValidator revEmail;
    protected TextBox txtFirstName;
    protected TextBox txtLastName;
    protected TextBox txtHomePhone;
    protected TextBox txtMobile;
    protected CheckBox chkAssignUsername;
    protected TextBox txtUsername;
    protected TextBox txtPassword;
    protected TextBox txtConfPassword;
    protected CheckBox chkSend;
    protected Label lblInvitation;
    protected LinkButton lnkAddContact;
    protected LinkButton lnkRemoveContact;
    protected HtmlGenericControl extraContact;
    protected HiddenField hfCompanyID;

    protected void Page_Load(object sender, EventArgs e)
    {
      MembershipUser user = Membership.GetUser();
      if (user == null)
        return;
      string str = user.ToString();
      if (!Roles.IsUserInRole(str, "Admin"))
        return;
      this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(str);
      if (this.objCompanyLoginMasterDT.Rows.Count <= 0)
        return;
      this.hfCompanyID.Value = this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString();
    }

    protected void txtUsername_OnTextChanged(object sender, EventArgs e)
    {
      this.objUserDT = this.objUserBll.GetAllDetail(this.txtUsername.Text.Trim());
      if (this.objUserDT.Rows.Count > 0)
      {
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('User Name Already Register With System.')", true);
        this.txtUsername.Text = "";
        this.txtUsername.Focus();
      }
      else
        this.txtPassword.Focus();
    }

    protected void txtEmail_OnTextChanged(object sender, EventArgs e)
    {
      this.objCompanyClientContactDetailDT = this.objCompanyClientContactDetailBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), this.txtEmail.Text.Trim());
      this.objStaffMasterDT = this.objStaffMasterBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), this.txtEmail.Text.Trim());
      this.objContractorMasterDT = this.objContractorMasterBll.GetDataByCompanyEmail(int.Parse(this.hfCompanyID.Value), this.txtEmail.Text.Trim());
      if (this.objCompanyClientContactDetailDT.Rows.Count > 0)
      {
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Email Already Register With System To Some Client.')", true);
        this.txtEmail.Text = "";
        this.txtEmail.Focus();
      }
      else if (this.objStaffMasterDT.Rows.Count > 0)
      {
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Email Already Register With System To Some Staff.')", true);
        this.txtEmail.Text = "";
        this.txtEmail.Focus();
      }
      else if (this.objContractorMasterDT.Rows.Count > 0)
      {
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('Email Already Register With System To Some Contractor.')", true);
        this.txtEmail.Text = "";
        this.txtEmail.Focus();
      }
      else
        this.txtFirstName.Focus();
    }

    protected void lnkAddContact_Click(object sender, EventArgs e)
    {
      this.extraContact.Controls.Add(this.LoadControl("ClientContactDetail.ascx"));
    }
  }
}

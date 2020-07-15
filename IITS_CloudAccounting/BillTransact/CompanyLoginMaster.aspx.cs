// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.CompanyLoginMaster
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Drawing;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class CompanyLoginMaster : Page
  {
    private readonly UserBLL objUserBll = new UserBLL();
    private CloudAccountDA.aspnet_UsersDataTable objUserDT = new CloudAccountDA.aspnet_UsersDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyPackageDetailsBLL objCompanyPackageDetailsBll = new CompanyPackageDetailsBLL();
    private CloudAccountDA.CompanyPackageDetailsDataTable objCompanyPackageDetailsDT = new CloudAccountDA.CompanyPackageDetailsDataTable();
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
    private readonly PackageMasterBLL objPackageMasterBll = new PackageMasterBLL();
    private CloudAccountDA.PackageMasterDataTable objPackageMasterDT = new CloudAccountDA.PackageMasterDataTable();
    public static bool checkInDB;
    protected ToolkitScriptManager tsm;
    protected Panel pnlAdd;
    protected UpdatePanel upName;
    protected DropDownList ddlCompany;
    protected SqlDataSource sqldsCompany;
    protected RequiredFieldValidator rfvFirstName;
    protected Label lblError;
    protected TextBox txtUserName;
    protected RequiredFieldValidator rfvUserName;
    protected TextBox txtEmail;
    protected RequiredFieldValidator rfvEmail;
    protected RegularExpressionValidator refEmail;
    protected DropDownList ddlRole;
    protected SqlDataSource sqldsRole;
    protected TextBox txtPassword;
    protected RequiredFieldValidator rfvPassword;
    protected TextBox txtQuestion;
    protected RequiredFieldValidator rfvQuestion;
    protected TextBox txtAnswer;
    protected CheckBox chkStatus;
    protected HtmlGenericControl chkkIsLockedOut;
    protected CheckBox chkIsLockedOut;
    protected HtmlGenericControl IsLockedOut;
    protected Label lblAccount;
    protected Button btnSubmit;
    protected Button btnReset;
    protected Button btnUnlock;
    protected Button btnUpdate;
    protected Button btnCancel;
    protected Button btnListAll;
    protected Panel pnlView;
    protected Label lblCompany;
    protected Label lblUserName;
    protected Label lblEmail;
    protected Label lblRole;
    protected Label lblPassword;
    protected Label lblCreateDate;
    protected Label lblStatus;
    protected CheckBox chkLocked;
    protected Label lblLastLoginDate;
    protected Button btnEdit;
    protected Button btnList;
    protected Button btnDelete;
    protected Button btnAdd;
    protected Panel pnlViewAll;
    protected GridView gvCompanyAdmin;
    protected GridView gvCompanyAdminDeactive;
    protected Button btnAddCompanyAdmin;
    protected HiddenField hfCompanyAdmin;
    protected HiddenField hfCompanyID;
    protected HiddenField hfUserName;
    protected SqlDataSource sqldsCompanyAdminActive;
    protected SqlDataSource sqldsCompanyAdminDeactive;
    protected SqlDataSource sqldsOnlyCompany;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("companyManagement")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("companyLoginMaster")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      MembershipUser user = Membership.GetUser();
      if (user != null)
      {
        string str = user.ToString();
        if (Roles.IsUserInRole(str, "Admin"))
        {
          this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(str);
          if (this.objCompanyLoginMasterDT.Rows.Count > 0)
            this.hfCompanyID.Value = this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString();
        }
      }
      if (this.Request.QueryString["cmd"] != null)
      {
        switch (this.Request.QueryString["cmd"])
        {
          case "view":
            if (this.Request.QueryString["ID"] == null)
              break;
            string i = this.Request.QueryString["ID"];
            this.pnlView.Visible = true;
            this.pnlViewAll.Visible = false;
            this.pnlAdd.Visible = false;
            this.ViewRecord(i);
            break;
          case "add":
            if (this.Request.QueryString["ID"] != null)
            {
              string iD = this.Request.QueryString["ID"];
              this.pnlAdd.Visible = true;
              this.pnlView.Visible = false;
              this.pnlViewAll.Visible = false;
              this.btnSubmit.Visible = false;
              this.btnUpdate.Visible = true;
              this.btnReset.Visible = false;
              this.btnListAll.Visible = false;
              this.btnCancel.Visible = true;
              this.ddlCompany.Focus();
              this.txtUserName.Enabled = false;
              this.txtEmail.Enabled = false;
              this.ddlCompany.Enabled = false;
              this.SetRecord(iD);
              break;
            }
            this.pnlAdd.Visible = true;
            this.pnlView.Visible = false;
            this.pnlViewAll.Visible = false;
            this.btnSubmit.Visible = true;
            this.btnUpdate.Visible = false;
            this.btnReset.Visible = true;
            this.btnListAll.Visible = true;
            this.btnCancel.Visible = false;
            this.Clear();
            if (user == null)
              break;
            string str1 = user.ToString();
            if (!Roles.IsUserInRole(str1, "Admin"))
              break;
            this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(str1);
            if (this.objCompanyLoginMasterDT.Rows.Count <= 0)
              break;
            this.hfCompanyID.Value = this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString();
            this.ddlCompany.SelectedValue = this.hfCompanyID.Value;
            this.ddlCompany.Enabled = false;
            this.txtUserName.Focus();
            break;
          default:
            this.pnlAdd.Visible = false;
            this.pnlView.Visible = false;
            this.pnlViewAll.Visible = true;
            this.BindGrid();
            break;
        }
      }
      else
      {
        this.pnlAdd.Visible = false;
        this.pnlView.Visible = false;
        this.pnlViewAll.Visible = true;
        this.BindGrid();
      }
    }

    private void ViewRecord(string i)
    {
      this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(i);
      if (this.objCompanyLoginMasterDT.Rows.Count <= 0)
        return;
      this.hfCompanyAdmin.Value = this.objCompanyLoginMasterDT.Rows[0]["CompanyLoginID"].ToString();
      this.hfCompanyID.Value = this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString();
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objCompanyMasterDT.Rows.Count > 0)
        this.lblCompany.Text = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
      this.hfUserName.Value = this.lblUserName.Text = this.objCompanyLoginMasterDT.Rows[0]["CompanyUserName"].ToString();
      this.lblEmail.Text = this.objCompanyLoginMasterDT.Rows[0]["CompanyEmail"].ToString();
      this.lblStatus.Text = this.objCompanyLoginMasterDT.Rows[0]["CompanyStatus"].ToString();
      MembershipUser user = Membership.GetUser(i);
      if (user != null && !user.IsLockedOut)
      {
        this.lblUserName.Text = user.UserName;
        this.lblPassword.Text = user.GetPassword();
      }
      else
      {
        this.lblPassword.Text = "This User Account has been Locked.";
        this.lblPassword.ForeColor = Color.Red;
        this.btnUpdate.Enabled = false;
        this.chkLocked.Enabled = false;
        this.chkStatus.Enabled = false;
      }
      this.chkLocked.Checked = user != null && user.IsLockedOut;
      if (user == null)
        return;
      this.lblUserName.Text = user.UserName;
      this.lblEmail.Text = user.Email;
      this.chkStatus.Checked = user.IsApproved;
      this.lblStatus.Text = user.IsApproved.ToString();
      this.lblCreateDate.Text = user.CreationDate.ToShortDateString();
      this.lblLastLoginDate.Text = user.LastLoginDate.ToShortDateString();
      string userName = user.UserName;
      this.chkStatus.Enabled = false;
      this.chkLocked.Enabled = false;
      this.hfUserName.Value = userName;
    }

    private void SetRecord(string iD)
    {
      this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(iD);
      if (this.objCompanyLoginMasterDT.Rows.Count <= 0)
        return;
      this.hfCompanyAdmin.Value = this.objCompanyLoginMasterDT.Rows[0]["CompanyLoginID"].ToString();
      this.hfCompanyID.Value = this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString();
      this.hfUserName.Value = this.lblUserName.Text = this.objCompanyLoginMasterDT.Rows[0]["CompanyUserName"].ToString();
      this.txtEmail.Text = this.objCompanyLoginMasterDT.Rows[0]["CompanyEmail"].ToString();
      this.chkStatus.Checked = bool.Parse(this.objCompanyLoginMasterDT.Rows[0]["CompanyStatus"].ToString());
      this.ddlCompany.SelectedValue = this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString();
      this.txtQuestion.Text = "What Is Your First Name?";
      MembershipUser user1 = Membership.GetUser(iD);
      if (user1 != null && !user1.IsLockedOut)
      {
        this.txtPassword.Text = user1.GetPassword();
        this.btnUpdate.Visible = true;
        this.chkStatus.Enabled = true;
        this.txtPassword.Enabled = true;
        this.txtPassword.Enabled = false;
      }
      else
      {
        this.btnUpdate.Visible = false;
        this.chkkIsLockedOut.Visible = true;
        this.btnUnlock.Visible = true;
        this.IsLockedOut.Visible = true;
        if (user1 != null)
          this.chkIsLockedOut.Checked = user1.IsLockedOut;
        this.chkIsLockedOut.Enabled = false;
        this.chkStatus.Enabled = false;
        this.txtPassword.Enabled = false;
        this.lblAccount.Text = "This User Account has been Locked.";
        this.lblAccount.ForeColor = Color.Red;
      }
      if (user1 != null)
      {
        string userName = user1.UserName;
        this.chkStatus.Checked = user1.IsApproved;
        this.txtUserName.Text = user1.UserName;
        this.txtUserName.Enabled = false;
        this.txtAnswer.Enabled = false;
        this.txtQuestion.Enabled = false;
        this.txtEmail.Text = user1.Email;
        this.txtEmail.Enabled = false;
        this.hfUserName.Value = userName;
      }
      MembershipUser user2 = Membership.GetUser(this.txtUserName.Text);
      if (user2 == null)
        return;
      this.txtQuestion.Text = user2.PasswordQuestion;
      this.txtPassword.ReadOnly = this.txtQuestion.ReadOnly = this.txtAnswer.ReadOnly = this.txtEmail.ReadOnly = true;
    }

    protected void BtnUnlockClick(object sender, EventArgs e)
    {
      MembershipUser user = Membership.GetUser(this.Request.QueryString["ID"]);
      if (user != null)
        user.UnlockUser();
      this.Response.Redirect("~/BillTransact/CompanyLoginMaster.aspx?ID=" + this.Request.QueryString["ID"]);
    }

    private void Clear()
    {
      this.txtUserName.Text = this.txtEmail.Text = "";
      this.txtAnswer.Text = this.txtPassword.Text = "";
      this.chkStatus.Checked = false;
      this.ddlCompany.Focus();
    }

    private void BindGrid()
    {
      this.gvCompanyAdmin.DataBind();
      this.gvCompanyAdminDeactive.DataBind();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvCompanyAdmin.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvCompanyAdmin, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      foreach (GridViewRow gridViewRow in this.gvCompanyAdminDeactive.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvCompanyAdminDeactive, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void gvCompanyAdmin_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/CompanyLoginMaster.aspx?cmd=view&ID=" + this.gvCompanyAdmin.SelectedRow.Cells[2].Text);
      this.BindGrid();
    }

    protected void gvCompanyAdmin_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvCompanyAdmin.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void gvCompanyAdminDeactive_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/CompanyLoginMaster.aspx?cmd=view&ID=" + this.gvCompanyAdminDeactive.SelectedRow.Cells[2].Text);
      this.BindGrid();
    }

    protected void gvCompanyAdminDeactive_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvCompanyAdminDeactive.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void btnAddCompanyAdmin_Click(object sender, EventArgs e)
    {
      if (Admin.RoleName == "MasterAdmin")
      {
        this.Response.Redirect("~/BillTransact/CompanyLoginMaster.aspx?cmd=add");
      }
      else
      {
        if (!(Admin.RoleName == "Admin"))
          return;
        this.objCompanyPackageDetailsDT = this.objCompanyPackageDetailsBll.GetDataByCompanyActivePackage(int.Parse(this.hfCompanyID.Value));
        int num = 0;
        if (this.objCompanyPackageDetailsDT.Rows.Count > 0)
        {
          this.objPackageMasterDT = this.objPackageMasterBll.GetDataByPackageID(int.Parse(this.objCompanyPackageDetailsDT.Rows[0]["PackageID"].ToString()));
          if (this.objPackageMasterDT.Rows.Count > 0)
            num = int.Parse(this.objPackageMasterDT.Rows[0]["NoOfAdminUsersMax"].ToString());
        }
        this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
        if (this.objCompanyLoginMasterDT.Rows.Count < num)
          this.Response.Redirect("~/BillTransact/CompanyLoginMaster.aspx?cmd=add");
        else
          this.DisplayAlert("SORRY.!! You Can Not Create More Company Admin. To Create More Company Admin Please Upgrade From Current Package.");
      }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.txtUserName.Text.Trim().Length > 0 && this.txtPassword.Text.Trim().Length > 0 && this.txtEmail.Text.Trim().Length > 0)
      {
        this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(this.txtUserName.Text);
        if (this.objCompanyLoginMasterDT.Rows.Count > 0)
        {
          this.DisplayAlert("User Name Already Exist..");
          CompanyLoginMaster.checkInDB = true;
        }
        else
          CompanyLoginMaster.checkInDB = false;
        if (!CompanyLoginMaster.checkInDB)
        {
          MembershipCreateStatus status;
          Membership.CreateUser(this.txtUserName.Text.Trim(), this.txtPassword.Text.Trim(), this.txtEmail.Text.Trim(), this.txtQuestion.Text.Trim(), this.txtAnswer.Text.Trim(), this.chkStatus.Checked, out status);
          Roles.AddUserToRole(this.txtUserName.Text, this.ddlRole.SelectedItem.Value);
          if (this.objCompanyLoginMasterBll.AddCompanyLogin(int.Parse(this.ddlCompany.SelectedItem.Value), this.txtUserName.Text.Trim(), this.txtEmail.Text, this.chkStatus.Checked) != 0 && status == MembershipCreateStatus.Success)
          {
            this.DisplayAlert("Details Added Successfully.");
            this.Response.Redirect("~/BillTransact/CompanyLoginMaster.aspx?cmd=view&ID=" + this.txtUserName.Text.Trim());
          }
          else
          {
            this.DisplayAlert("Fail to Add New Details.");
            this.Clear();
          }
        }
        else
        {
          this.DisplayAlert("Fail to Add New Details.");
          this.Clear();
        }
      }
      else
        this.DisplayAlert("Please Fill All Details...!");
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
      this.Clear();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.Page.IsValid)
        {
          if (this.txtUserName.Text.Trim().Length > 0 && this.txtPassword.Text.Trim().Length > 0 && this.txtEmail.Text.Trim().Length > 0)
          {
            MembershipUser user = Membership.GetUser(this.txtUserName.Text);
            if (user != null)
            {
              user.IsApproved = this.chkStatus.Checked;
              Membership.UpdateUser(user);
            }
            if (this.objCompanyLoginMasterBll.UpdateCompanyLogin(int.Parse(this.hfCompanyAdmin.Value.Trim()), int.Parse(this.ddlCompany.SelectedItem.Value), this.txtUserName.Text.Trim(), this.txtEmail.Text, this.chkStatus.Checked))
            {
              this.DisplayAlert("Update Successfully..");
              this.Response.Redirect("~/BillTransact/CompanyLoginMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
            }
            else
              this.DisplayAlert("Fail to Update Details.");
          }
          else
            this.DisplayAlert("Please Fill All Details...!");
        }
        else
          this.DisplayAlert("Fail to Update Details.");
      }
      catch (Exception ex)
      {
        this.DisplayAlert(ex.Message);
      }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/CompanyLoginMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfCompanyAdmin.Value != null)
      {
        Membership.DeleteUser(this.hfUserName.Value);
        if (this.objCompanyLoginMasterBll.DeleteCompanyLogin(int.Parse(this.hfCompanyAdmin.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/BillTransact/CompanyLoginMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/CompanyLoginMaster.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/CompanyLoginMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
    }

    public void DisplayAlert(string message)
    {
      this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">" + this.GetAlertScript(message) + "</script>");
    }

    public string GetAlertScript(string message)
    {
      return "alert('" + message.Replace("'", "\\'") + "');";
    }

    protected void txtUserName_TextChanged(object sender, EventArgs e)
    {
      if (this.txtUserName.Text.Trim().Length <= 0)
        return;
      this.objUserDT = this.objUserBll.GetAllDetail(this.txtUserName.Text.Trim());
      this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(this.txtUserName.Text.Trim());
      if (this.objCompanyLoginMasterDT.Rows.Count > 0 && this.objUserDT.Rows.Count > 0)
      {
        this.DisplayAlert("UserName Already Assigned To Someone.");
        this.txtUserName.Text = "";
        this.txtUserName.Focus();
      }
      else
      {
        this.txtAnswer.Text = this.txtUserName.Text;
        this.txtEmail.Focus();
      }
    }

    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.lblError.Text = "";
      this.hfCompanyID.Value = this.ddlCompany.SelectedItem.Value;
      this.objCompanyPackageDetailsDT = this.objCompanyPackageDetailsBll.GetDataByCompanyActivePackage(int.Parse(this.hfCompanyID.Value));
      int num = 0;
      if (this.objCompanyPackageDetailsDT.Rows.Count > 0)
      {
        this.objPackageMasterDT = this.objPackageMasterBll.GetDataByPackageID(int.Parse(this.objCompanyPackageDetailsDT.Rows[0]["PackageID"].ToString()));
        if (this.objPackageMasterDT.Rows.Count > 0)
          num = int.Parse(this.objPackageMasterDT.Rows[0]["NoOfAdminUsersMax"].ToString());
      }
      this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
      if (this.objCompanyLoginMasterDT.Rows.Count < num)
      {
        this.txtUserName.Focus();
      }
      else
      {
        this.ddlCompany.SelectedIndex = 0;
        this.ddlCompany.Focus();
        this.DisplayAlert("SORRY.!! Can Not Create More Company Admin. To Create More Company Admin Please Upgrade Company Package.");
        this.lblError.Text = "SORRY.!! Can Not Create More Company Admin. To Create More Company Admin Please Upgrade Company Package.";
      }
    }

    protected void gvCompanyAdmin_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType != DataControlRowType.DataRow)
        return;
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(e.Row.Cells[1].Text));
      if (this.objCompanyMasterDT.Rows.Count <= 0)
        return;
      string str = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
      e.Row.Cells[1].Text = str;
    }

    protected void gvCompanyAdminDeactive_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType != DataControlRowType.DataRow)
        return;
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(e.Row.Cells[1].Text));
      if (this.objCompanyMasterDT.Rows.Count <= 0)
        return;
      string str = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
      e.Row.Cells[1].Text = str;
    }
  }
}

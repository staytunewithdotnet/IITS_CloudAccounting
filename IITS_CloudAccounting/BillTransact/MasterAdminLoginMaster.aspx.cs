// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.MasterAdminLoginMaster
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
  public class MasterAdminLoginMaster : Page
  {
    private static string AddStatus = string.Empty;
    private static string EditStatus = string.Empty;
    private static string ViewStatus = string.Empty;
    private static string DeleteStatus = string.Empty;
    private readonly UserBLL objUserBll = new UserBLL();
    private CloudAccountDA.aspnet_UsersDataTable objUserDT = new CloudAccountDA.aspnet_UsersDataTable();
    private readonly SecurityQuestionMasterBLL objSecurityQuestionMasterBll = new SecurityQuestionMasterBLL();
    private CloudAccountDA.SecurityQuestionMasterDataTable objSecurityQuestionMasterDT = new CloudAccountDA.SecurityQuestionMasterDataTable();
    private readonly MasterAdminLoginMasterBLL objMasterAdminLoginMasterBll = new MasterAdminLoginMasterBLL();
    private CloudAccountDA.MasterAdminLoginMasterDataTable objMasterAdminLoginMasterDT = new CloudAccountDA.MasterAdminLoginMasterDataTable();
    private readonly MasterAdminRightsMasterBLL objMasterAdminRightsMasterBll = new MasterAdminRightsMasterBLL();
    private CloudAccountDA.MasterAdminRightsMasterDataTable objMasterAdminRightsMasterDT = new CloudAccountDA.MasterAdminRightsMasterDataTable();
    public static bool checkInDB;
    protected ToolkitScriptManager tsm;
    protected Panel pnlAdd;
    protected UpdatePanel upName;
    protected TextBox txtFirstName;
    protected RequiredFieldValidator rfvFirstName;
    protected TextBox txtLastName;
    protected RequiredFieldValidator rfvLastName;
    protected TextBox txtUserName;
    protected RequiredFieldValidator rfvUserName;
    protected TextBox txtEmail;
    protected RequiredFieldValidator rfvEmail;
    protected RegularExpressionValidator refEmail;
    protected DropDownList ddlRole;
    protected SqlDataSource sqldsRole;
    protected TextBox txtPassword;
    protected RequiredFieldValidator rfvPassword;
    protected UpdatePanel upQuestionAnswer;
    protected DropDownList ddlQuestion;
    protected SqlDataSource sqldsQuestion;
    protected RequiredFieldValidator rfvQuestion;
    protected TextBox txtAnswer;
    protected RequiredFieldValidator rfvAnswer;
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
    protected Label lblFirstName;
    protected Label lblLastName;
    protected Label lblUserName;
    protected Label lblEmail;
    protected Label lblRole;
    protected Label lblPassword;
    protected Label lblCreateDate;
    protected Label lblStatus;
    protected CheckBox chkLocked;
    protected Label lblLastLoginDate;
    protected Button btnEdit;
    protected Button btnDelete;
    protected Button btnList;
    protected Button btnAdd;
    protected Panel pnlViewAll;
    protected GridView gvMasterAdmin;
    protected Button btnAddMasterAdmin;
    protected HiddenField hfMasterAdmin;
    protected HiddenField hfMasterAdminID;
    protected HiddenField hfUserName;
    protected SqlDataSource sqldsMasterAdmin;
    protected ObjectDataSource objdsMasterAdmin;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("masterAdminMagmnt")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("masterAdmin")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          MasterAdminLoginMaster.AddStatus = "True";
          MasterAdminLoginMaster.EditStatus = "True";
          MasterAdminLoginMaster.ViewStatus = "True";
          MasterAdminLoginMaster.DeleteStatus = "True";
        }
        else if (Admin.RoleName == "MasterAdmin")
        {
          if (user != null)
          {
            string str = user.ToString();
            if (Roles.IsUserInRole(str, "MasterAdmin"))
            {
              this.objMasterAdminLoginMasterDT = this.objMasterAdminLoginMasterBll.GetDataByUserName(str);
              if (this.objMasterAdminLoginMasterDT.Rows.Count > 0)
                this.hfMasterAdminID.Value = this.objMasterAdminLoginMasterDT.Rows[0]["MasterAdminUserID"].ToString();
            }
          }
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "MasterAdminLoginMaster");
          if (this.objMasterAdminRightsMasterDT.Rows.Count > 0)
          {
            MasterAdminLoginMaster.AddStatus = this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            MasterAdminLoginMaster.EditStatus = this.objMasterAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            MasterAdminLoginMaster.ViewStatus = this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            MasterAdminLoginMaster.DeleteStatus = this.objMasterAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            MasterAdminLoginMaster.AddStatus = "";
            MasterAdminLoginMaster.EditStatus = "";
            MasterAdminLoginMaster.ViewStatus = "";
            MasterAdminLoginMaster.DeleteStatus = "";
          }
        }
        else
        {
          MasterAdminLoginMaster.AddStatus = "";
          MasterAdminLoginMaster.EditStatus = "";
          MasterAdminLoginMaster.ViewStatus = "";
          MasterAdminLoginMaster.DeleteStatus = "";
        }
      }
      if (MasterAdminLoginMaster.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] == null || !(MasterAdminLoginMaster.ViewStatus == "True"))
                break;
              string i = this.Request.QueryString["ID"];
              this.pnlViewAll.Visible = false;
              this.pnlAdd.Visible = false;
              this.pnlView.Visible = true;
              this.ViewRecord(i);
              this.btnEdit.Visible = MasterAdminLoginMaster.EditStatus == "True";
              this.btnAddMasterAdmin.Visible = this.btnAdd.Visible = MasterAdminLoginMaster.AddStatus == "True";
              this.btnDelete.Visible = MasterAdminLoginMaster.DeleteStatus == "True";
              this.btnListAll.Visible = true;
              this.btnUpdate.Visible = false;
              this.btnCancel.Visible = false;
              break;
            case "add":
              if (this.Request.QueryString["ID"] != null)
              {
                if (!(MasterAdminLoginMaster.EditStatus == "True"))
                  break;
                string iD = this.Request.QueryString["ID"];
                this.pnlAdd.Visible = true;
                this.pnlView.Visible = false;
                this.pnlViewAll.Visible = false;
                this.btnSubmit.Visible = false;
                this.btnUpdate.Visible = true;
                this.btnReset.Visible = false;
                this.btnListAll.Visible = false;
                this.btnCancel.Visible = true;
                this.txtFirstName.Focus();
                this.txtUserName.Enabled = false;
                this.txtEmail.Enabled = false;
                this.rfvAnswer.Enabled = false;
                this.SetRecord(iD);
                break;
              }
              if (!(MasterAdminLoginMaster.AddStatus == "True"))
                break;
              this.pnlAdd.Visible = true;
              this.pnlView.Visible = false;
              this.pnlViewAll.Visible = false;
              this.btnSubmit.Visible = true;
              this.btnUpdate.Visible = false;
              this.btnReset.Visible = true;
              this.btnListAll.Visible = true;
              this.btnCancel.Visible = false;
              this.rfvAnswer.Enabled = true;
              this.Clear();
              break;
            default:
              this.BindGrid();
              this.pnlViewAll.Visible = true;
              this.pnlView.Visible = false;
              this.pnlAdd.Visible = false;
              break;
          }
        }
        else
        {
          this.BindGrid();
          this.pnlViewAll.Visible = true;
          this.pnlView.Visible = false;
          this.pnlAdd.Visible = false;
          if (MasterAdminLoginMaster.AddStatus == "False")
            this.btnAddMasterAdmin.Visible = this.btnAdd.Visible = false;
          else
            this.btnAddMasterAdmin.Visible = this.btnAdd.Visible = true;
        }
      }
      else if (MasterAdminLoginMaster.AddStatus == "True" && MasterAdminLoginMaster.EditStatus == "False" && (MasterAdminLoginMaster.ViewStatus == "False" && MasterAdminLoginMaster.DeleteStatus == "False"))
      {
        this.pnlAdd.Visible = true;
        this.btnUpdate.Visible = false;
        this.btnCancel.Visible = false;
        this.pnlViewAll.Visible = false;
        this.pnlView.Visible = false;
      }
      else
      {
        this.pnlViewAll.Visible = false;
        this.pnlView.Visible = false;
        this.pnlAdd.Visible = false;
      }
    }

    private void ViewRecord(string i)
    {
      this.objMasterAdminLoginMasterDT = this.objMasterAdminLoginMasterBll.GetDataByUserName(i);
      if (this.objMasterAdminLoginMasterDT.Rows.Count <= 0)
        return;
      this.hfMasterAdmin.Value = this.objMasterAdminLoginMasterDT.Rows[0]["MasterAdminUserID"].ToString();
      this.lblFirstName.Text = this.objMasterAdminLoginMasterDT.Rows[0]["FirstName"].ToString();
      this.lblLastName.Text = this.objMasterAdminLoginMasterDT.Rows[0]["LastName"].ToString();
      this.hfUserName.Value = this.lblUserName.Text = this.objMasterAdminLoginMasterDT.Rows[0]["UserName"].ToString();
      this.lblEmail.Text = this.objMasterAdminLoginMasterDT.Rows[0]["EmailID"].ToString();
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
      this.objMasterAdminLoginMasterDT = this.objMasterAdminLoginMasterBll.GetDataByUserName(iD);
      if (this.objMasterAdminLoginMasterDT.Rows.Count <= 0)
        return;
      this.hfMasterAdmin.Value = this.objMasterAdminLoginMasterDT.Rows[0]["MasterAdminUserID"].ToString();
      this.txtFirstName.Text = this.objMasterAdminLoginMasterDT.Rows[0]["FirstName"].ToString();
      this.txtLastName.Text = this.objMasterAdminLoginMasterDT.Rows[0]["LastName"].ToString();
      this.hfUserName.Value = this.txtUserName.Text = this.objMasterAdminLoginMasterDT.Rows[0]["UserName"].ToString();
      this.txtEmail.Text = this.objMasterAdminLoginMasterDT.Rows[0]["EmailID"].ToString();
      MembershipUser user1 = Membership.GetUser(iD);
      if (user1 != null && !user1.IsLockedOut)
      {
        this.txtPassword.Text = user1.GetPassword();
        this.btnUpdate.Visible = true;
        this.chkStatus.Enabled = true;
        this.txtPassword.Enabled = true;
        this.txtPassword.Enabled = false;
        string passwordQuestion = user1.PasswordQuestion;
        this.ddlQuestion.DataBind();
        this.ddlQuestion.SelectedIndex = this.ddlQuestion.Items.IndexOf(this.ddlQuestion.Items.FindByText(passwordQuestion));
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
        this.txtEmail.Text = user1.Email;
        this.txtEmail.Enabled = false;
        this.hfUserName.Value = userName;
      }
      MembershipUser user2 = Membership.GetUser(this.txtUserName.Text);
      if (user2 == null)
        return;
      this.ddlQuestion.DataBind();
      this.ddlQuestion.SelectedIndex = this.ddlQuestion.Items.IndexOf(this.ddlQuestion.Items.FindByText(user2.PasswordQuestion));
      this.txtPassword.ReadOnly = this.txtAnswer.ReadOnly = this.txtEmail.ReadOnly = true;
      this.ddlQuestion.Enabled = false;
    }

    protected void BtnUnlockClick(object sender, EventArgs e)
    {
      MembershipUser user = Membership.GetUser(this.Request.QueryString["ID"]);
      if (user != null)
        user.UnlockUser();
      this.Response.Redirect("~/BillTransact/MasterAdminLoginMaster.aspx?ID=" + this.Request.QueryString["ID"]);
    }

    private void Clear()
    {
      this.txtFirstName.Text = this.txtLastName.Text = this.txtUserName.Text = this.txtEmail.Text = "";
      this.txtAnswer.Text = this.txtPassword.Text = "";
      this.chkStatus.Checked = false;
      this.txtFirstName.Focus();
    }

    private void BindGrid()
    {
      this.gvMasterAdmin.DataBind();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvMasterAdmin.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvMasterAdmin, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void gvMasterAdmin_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/MasterAdminLoginMaster.aspx?cmd=view&ID=" + this.gvMasterAdmin.SelectedRow.Cells[3].Text);
      this.BindGrid();
    }

    protected void gvMasterAdmin_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvMasterAdmin.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void btnAddMasterAdmin_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/MasterAdminLoginMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.txtFirstName.Text.Trim().Length > 0 && this.txtLastName.Text.Trim().Length > 0 && (this.txtUserName.Text.Trim().Length > 0 && this.txtPassword.Text.Trim().Length > 0) && this.txtEmail.Text.Trim().Length > 0)
      {
        this.objMasterAdminLoginMasterDT = this.objMasterAdminLoginMasterBll.GetDataByUserName(this.txtUserName.Text);
        if (this.objMasterAdminLoginMasterDT.Rows.Count > 0)
        {
          this.DisplayAlert("User Name Already Exist..");
          MasterAdminLoginMaster.checkInDB = true;
        }
        else
          MasterAdminLoginMaster.checkInDB = false;
        if (!MasterAdminLoginMaster.checkInDB)
        {
          MembershipCreateStatus status;
          Membership.CreateUser(this.txtUserName.Text.Trim(), this.txtPassword.Text.Trim(), this.txtEmail.Text.Trim(), this.ddlQuestion.SelectedItem.Text, this.txtAnswer.Text.Trim(), this.chkStatus.Checked, out status);
          Roles.AddUserToRole(this.txtUserName.Text, this.ddlRole.SelectedItem.Value);
          if (this.objMasterAdminLoginMasterBll.AddMasterAdmin(this.txtFirstName.Text.Trim(), this.txtLastName.Text.Trim(), this.txtUserName.Text.Trim(), this.txtEmail.Text) != 0 && status == MembershipCreateStatus.Success)
          {
            this.DisplayAlert("Details Added Successfully.");
            this.Response.Redirect("~/BillTransact/MasterAdminLoginMaster.aspx?cmd=view&ID=" + this.txtUserName.Text.Trim());
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
        if (!this.Page.IsValid)
          return;
        if (this.txtFirstName.Text.Trim().Length > 0 && this.txtLastName.Text.Trim().Length > 0 && (this.txtUserName.Text.Trim().Length > 0 && this.txtPassword.Text.Trim().Length > 0) && this.txtEmail.Text.Trim().Length > 0)
        {
          MembershipUser user = Membership.GetUser(this.txtUserName.Text.Trim());
          if (user != null)
          {
            user.IsApproved = this.chkStatus.Checked;
            Membership.UpdateUser(user);
          }
          if (this.objMasterAdminLoginMasterBll.UpdateMasterAdmin(int.Parse(this.hfMasterAdmin.Value.Trim()), this.txtFirstName.Text.Trim(), this.txtLastName.Text.Trim(), this.txtUserName.Text.Trim(), this.txtEmail.Text))
          {
            this.DisplayAlert("Update Successfully..");
            this.Response.Redirect("~/BillTransact/MasterAdminLoginMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
          }
          else
            this.DisplayAlert("Fail to Update Details.");
        }
        else
          this.DisplayAlert("Please Fill All Details...!");
      }
      catch (Exception ex)
      {
        this.DisplayAlert(ex.Message);
      }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/MasterAdminLoginMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfMasterAdmin.Value != null)
      {
        Membership.DeleteUser(this.hfUserName.Value);
        if (this.objMasterAdminLoginMasterBll.DeleteMasterAdmin(int.Parse(this.hfMasterAdmin.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/BillTransact/MasterAdminLoginMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/MasterAdminLoginMaster.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/MasterAdminLoginMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
    }

    public void DisplayAlert(string message)
    {
      this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">" + this.GetAlertScript(message) + "</script>");
    }

    public string GetAlertScript(string message)
    {
      return "alert('" + message.Replace("'", "\\'") + "');";
    }

    protected void txtFirstName_TextChanged(object sender, EventArgs e)
    {
      if (this.txtFirstName.Text.Trim().Length > 0)
        this.txtLastName.Focus();
      else
        this.txtFirstName.Focus();
    }

    protected void txtUserName_TextChanged(object sender, EventArgs e)
    {
      if (this.txtUserName.Text.Trim().Length <= 0)
        return;
      this.objUserDT = this.objUserBll.GetAllDetail(this.txtUserName.Text.Trim());
      this.objMasterAdminLoginMasterDT = this.objMasterAdminLoginMasterBll.GetDataByUserName(this.txtUserName.Text.Trim());
      if (this.objMasterAdminLoginMasterDT.Rows.Count > 0 && this.objUserDT.Rows.Count > 0)
      {
        this.DisplayAlert("UserName Already Assigned To Someone.");
        this.txtUserName.Text = "";
        this.txtUserName.Focus();
      }
      else
        this.txtEmail.Focus();
    }

    protected void ddlQuestion_OnSelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.ddlQuestion.SelectedIndex > 0)
      {
        this.objSecurityQuestionMasterDT = this.objSecurityQuestionMasterBll.GetDataBySecurityQuestionID(int.Parse(this.ddlQuestion.SelectedItem.Value));
        if (this.objSecurityQuestionMasterDT.Rows.Count > 0)
        {
          this.txtAnswer.Text = this.objSecurityQuestionMasterDT.Rows[0]["DefaultAnswer"].ToString();
          this.txtAnswer.Focus();
        }
        else
        {
          this.ddlQuestion.SelectedIndex = 0;
          this.txtAnswer.Text = "";
          this.ddlQuestion.Focus();
        }
      }
      else
      {
        this.txtAnswer.Text = "";
        this.ddlQuestion.Focus();
      }
    }
  }
}

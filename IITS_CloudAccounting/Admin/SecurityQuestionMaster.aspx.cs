// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.SecurityQuestionMaster
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
  public class SecurityQuestionMaster : Page
  {
    private static string AddStatus = string.Empty;
    private static string EditStatus = string.Empty;
    private static string ViewStatus = string.Empty;
    private static string DeleteStatus = string.Empty;
    private readonly SecurityQuestionMasterBLL objSecurityQuestionMasterBll = new SecurityQuestionMasterBLL();
    private CloudAccountDA.SecurityQuestionMasterDataTable objSecurityQuestionMasterDT = new CloudAccountDA.SecurityQuestionMasterDataTable();
    private readonly MasterAdminRightsMasterBLL objMasterAdminRightsMasterBll = new MasterAdminRightsMasterBLL();
    private CloudAccountDA.MasterAdminRightsMasterDataTable objMasterAdminRightsMasterDT = new CloudAccountDA.MasterAdminRightsMasterDataTable();
    private readonly MasterAdminLoginMasterBLL objMasterAdminLoginMasterBll = new MasterAdminLoginMasterBLL();
    private CloudAccountDA.MasterAdminLoginMasterDataTable objMasterAdminLoginMasterDT = new CloudAccountDA.MasterAdminLoginMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyAdminRightsMasterBLL objCompanyAdminRightsMasterBll = new CompanyAdminRightsMasterBLL();
    private CloudAccountDA.CompanyAdminRightsMasterDataTable objCompanyAdminRightsMasterDT = new CloudAccountDA.CompanyAdminRightsMasterDataTable();
    private readonly PasswordQuestionBLL objPasswordQuestionBll = new PasswordQuestionBLL();
    private CloudAccountDA.aspnet_MembershipDataTable objPasswordQuestionDT = new CloudAccountDA.aspnet_MembershipDataTable();
    private bool checkInDB;
    protected Panel pnlAdd;
    protected TextBox txtQuestion;
    protected RequiredFieldValidator RequiredFieldValidator1;
    protected Label lblError;
    protected TextBox txtAnswer;
    protected RequiredFieldValidator RequiredFieldValidator2;
    protected TextBox txtDesc;
    protected CheckBox chkStatus;
    protected Button btnSubmit;
    protected Button btnReset;
    protected Button btnUpdate;
    protected Button btnCancel;
    protected Button btnListAll;
    protected Panel pnlView;
    protected Label lblQuestion;
    protected Label lblAnswer;
    protected Label lblDesc;
    protected Label lblStatus;
    protected Button btnEdit;
    protected Button btnDelete;
    protected Button btnList;
    protected Button btnAdd;
    protected Panel pnlViewAll;
    protected GridView gvSecurityQuestion;
    protected Button btnAddSecurityQuestion;
    protected HiddenField hfSecurityQuestion;
    protected HiddenField hfMasterAdminID;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyLoginID;
    protected ObjectDataSource objdsSecurityQuestion;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("generalMaster")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("SecurityQuestion")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          SecurityQuestionMaster.AddStatus = "True";
          SecurityQuestionMaster.EditStatus = "True";
          SecurityQuestionMaster.ViewStatus = "True";
          SecurityQuestionMaster.DeleteStatus = "True";
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
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "SecurityQuestionMaster");
          if (this.objMasterAdminRightsMasterDT.Rows.Count > 0)
          {
            SecurityQuestionMaster.AddStatus = this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            SecurityQuestionMaster.EditStatus = this.objMasterAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            SecurityQuestionMaster.ViewStatus = this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            SecurityQuestionMaster.DeleteStatus = this.objMasterAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            SecurityQuestionMaster.AddStatus = "";
            SecurityQuestionMaster.EditStatus = "";
            SecurityQuestionMaster.ViewStatus = "";
            SecurityQuestionMaster.DeleteStatus = "";
          }
        }
        else if (Admin.RoleName == "Admin")
        {
          if (user != null)
          {
            string str = user.ToString();
            if (Roles.IsUserInRole(str, "Admin"))
            {
              this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(str);
              if (this.objCompanyLoginMasterDT.Rows.Count > 0)
              {
                this.hfCompanyID.Value = this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString();
                this.hfCompanyLoginID.Value = this.objCompanyLoginMasterDT.Rows[0]["CompanyLoginID"].ToString();
              }
            }
          }
          this.objCompanyAdminRightsMasterDT = this.objCompanyAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfCompanyID.Value.Trim()), int.Parse(this.hfCompanyLoginID.Value.Trim()), "SecurityQuestionMaster");
          if (this.objCompanyAdminRightsMasterDT.Rows.Count > 0)
          {
            SecurityQuestionMaster.AddStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            SecurityQuestionMaster.EditStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            SecurityQuestionMaster.ViewStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            SecurityQuestionMaster.DeleteStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            SecurityQuestionMaster.AddStatus = "";
            SecurityQuestionMaster.EditStatus = "";
            SecurityQuestionMaster.ViewStatus = "";
            SecurityQuestionMaster.DeleteStatus = "";
          }
        }
        else
        {
          SecurityQuestionMaster.AddStatus = "";
          SecurityQuestionMaster.EditStatus = "";
          SecurityQuestionMaster.ViewStatus = "";
          SecurityQuestionMaster.DeleteStatus = "";
        }
      }
      if (SecurityQuestionMaster.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] == null || !(SecurityQuestionMaster.ViewStatus == "True"))
                break;
              string i = this.Request.QueryString["ID"];
              this.pnlViewAll.Visible = false;
              this.pnlAdd.Visible = false;
              this.pnlView.Visible = true;
              this.ViewRecord(i);
              this.btnEdit.Visible = SecurityQuestionMaster.EditStatus == "True";
              this.btnAddSecurityQuestion.Visible = this.btnAdd.Visible = SecurityQuestionMaster.AddStatus == "True";
              this.btnDelete.Visible = SecurityQuestionMaster.DeleteStatus == "True";
              this.btnListAll.Visible = true;
              this.btnUpdate.Visible = false;
              this.btnCancel.Visible = false;
              break;
            case "add":
              if (this.Request.QueryString["ID"] != null)
              {
                if (!(SecurityQuestionMaster.EditStatus == "True"))
                  break;
                this.SetRecord(this.Request.QueryString["ID"]);
                this.pnlAdd.Visible = true;
                this.pnlViewAll.Visible = false;
                this.pnlView.Visible = false;
                this.btnUpdate.Visible = true;
                this.btnCancel.Visible = true;
                this.btnSubmit.Visible = false;
                this.btnReset.Visible = false;
                break;
              }
              if (!(SecurityQuestionMaster.AddStatus == "True"))
                break;
              this.Clear();
              this.btnSubmit.Visible = true;
              this.btnReset.Visible = true;
              this.btnUpdate.Visible = false;
              this.btnCancel.Visible = false;
              this.pnlAdd.Visible = true;
              this.pnlViewAll.Visible = false;
              this.pnlView.Visible = false;
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
          if (SecurityQuestionMaster.AddStatus == "False")
            this.btnAddSecurityQuestion.Visible = this.btnAdd.Visible = false;
          else
            this.btnAddSecurityQuestion.Visible = this.btnAdd.Visible = true;
        }
      }
      else if (SecurityQuestionMaster.AddStatus == "True" && SecurityQuestionMaster.EditStatus == "False" && (SecurityQuestionMaster.ViewStatus == "False" && SecurityQuestionMaster.DeleteStatus == "False"))
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
      this.objSecurityQuestionMasterDT = this.objSecurityQuestionMasterBll.GetDataBySecurityQuestionID(int.Parse(i));
      if (this.objSecurityQuestionMasterDT.Rows.Count <= 0)
        return;
      this.hfSecurityQuestion.Value = this.objSecurityQuestionMasterDT.Rows[0]["SecurityQuestionID"].ToString();
      this.lblQuestion.Text = this.objSecurityQuestionMasterDT.Rows[0]["Question"].ToString();
      this.lblAnswer.Text = this.objSecurityQuestionMasterDT.Rows[0]["DefaultAnswer"].ToString();
      this.lblDesc.Text = this.objSecurityQuestionMasterDT.Rows[0]["Description"].ToString();
      this.lblStatus.Text = this.objSecurityQuestionMasterDT.Rows[0]["Status"].ToString() == "True" ? "True" : "False";
    }

    private void SetRecord(string iD)
    {
      this.objSecurityQuestionMasterDT = this.objSecurityQuestionMasterBll.GetDataBySecurityQuestionID(int.Parse(iD));
      if (this.objSecurityQuestionMasterDT.Rows.Count <= 0)
        return;
      this.hfSecurityQuestion.Value = this.objSecurityQuestionMasterDT.Rows[0]["SecurityQuestionID"].ToString();
      this.txtQuestion.Text = this.objSecurityQuestionMasterDT.Rows[0]["Question"].ToString();
      this.txtAnswer.Text = this.objSecurityQuestionMasterDT.Rows[0]["DefaultAnswer"].ToString();
      this.txtDesc.Text = this.objSecurityQuestionMasterDT.Rows[0]["Description"].ToString();
      this.chkStatus.Checked = this.objSecurityQuestionMasterDT.Rows[0]["Status"].ToString() == "True";
      this.objPasswordQuestionDT = this.objPasswordQuestionBll.GetAllPasswordQuestion(this.txtQuestion.Text);
      if (this.objPasswordQuestionDT.Rows.Count > 0)
      {
        this.lblError.Text = "Security Question Is Assign To Some User..! So Can't Update This Question..!";
        this.txtQuestion.Enabled = false;
        this.chkStatus.Enabled = false;
      }
      else
      {
        this.txtQuestion.Enabled = true;
        this.chkStatus.Enabled = true;
      }
    }

    private void Clear()
    {
      this.txtQuestion.Text = this.txtDesc.Text = this.txtAnswer.Text = (string) null;
      this.chkStatus.Checked = false;
      this.txtQuestion.Focus();
    }

    private void BindGrid()
    {
      this.gvSecurityQuestion.DataBind();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvSecurityQuestion.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvSecurityQuestion, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void gvSecurityQuestion_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/SecurityQuestionMaster.aspx?cmd=view&ID=" + this.gvSecurityQuestion.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvSecurityQuestion_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvSecurityQuestion.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void btnAddSecurityQuestion_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/SecurityQuestionMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.txtQuestion.Text.Trim().Length > 0)
      {
        this.objSecurityQuestionMasterDT = this.objSecurityQuestionMasterBll.GetDataByQuestion(this.txtQuestion.Text.Trim());
        if (this.objSecurityQuestionMasterDT.Rows.Count > 0)
        {
          this.DisplayAlert("Security Question Already Exist..");
          this.checkInDB = true;
        }
        else
          this.checkInDB = false;
        if (!this.checkInDB)
        {
          int num = this.objSecurityQuestionMasterBll.AddSecurityQuestion(this.txtQuestion.Text.Trim(), "", this.txtDesc.Text.Trim(), this.chkStatus.Checked);
          if (num != 0)
          {
            this.DisplayAlert("Details Added Successfully.");
            this.Response.Redirect("~/Admin/SecurityQuestionMaster.aspx?cmd=view&ID=" + (object) num);
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
          if (this.txtQuestion.Text.Trim().Length > 0 && this.txtAnswer.Text.Trim().Length > 0)
          {
            if (this.objSecurityQuestionMasterBll.UpdateSecurityQuestion(int.Parse(this.hfSecurityQuestion.Value.Trim()), this.txtQuestion.Text.Trim(), "", this.txtDesc.Text.Trim(), this.chkStatus.Checked))
            {
              this.DisplayAlert("Update Successfully..");
              this.Response.Redirect("~/Admin/SecurityQuestionMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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
      this.Response.Redirect("~/Admin/SecurityQuestionMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfSecurityQuestion.Value != null)
      {
        this.objPasswordQuestionDT = this.objPasswordQuestionBll.GetAllPasswordQuestion(this.lblQuestion.Text);
        if (this.objPasswordQuestionDT.Rows.Count > 0)
          this.DisplayAlert("Security Question Is Assign To Some User..! So Can't Delete This Question..!");
        else if (this.objSecurityQuestionMasterBll.DeleteSecurityQuestion(int.Parse(this.hfSecurityQuestion.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/Admin/SecurityQuestionMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/SecurityQuestionMaster.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/SecurityQuestionMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
    }

    public void DisplayAlert(string message)
    {
      this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">" + this.GetAlertScript(message) + "</script>");
    }

    public string GetAlertScript(string message)
    {
      return "alert('" + message.Replace("'", "\\'") + "');";
    }
  }
}

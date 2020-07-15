// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.SupportDepartmentMaster
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
  public class SupportDepartmentMaster : Page
  {
    private static string AddStatus = string.Empty;
    private static string EditStatus = string.Empty;
    private static string ViewStatus = string.Empty;
    private static string DeleteStatus = string.Empty;
    private readonly SupportDepartmentMasterBLL objSupportDepartmentMasterBll = new SupportDepartmentMasterBLL();
    private CloudAccountDA.SupportDepartmentMasterDataTable objSupportDepartmentMasterDT = new CloudAccountDA.SupportDepartmentMasterDataTable();
    private readonly MasterAdminRightsMasterBLL objMasterAdminRightsMasterBll = new MasterAdminRightsMasterBLL();
    private CloudAccountDA.MasterAdminRightsMasterDataTable objMasterAdminRightsMasterDT = new CloudAccountDA.MasterAdminRightsMasterDataTable();
    private readonly MasterAdminLoginMasterBLL objMasterAdminLoginMasterBll = new MasterAdminLoginMasterBLL();
    private CloudAccountDA.MasterAdminLoginMasterDataTable objMasterAdminLoginMasterDT = new CloudAccountDA.MasterAdminLoginMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyAdminRightsMasterBLL objCompanyAdminRightsMasterBll = new CompanyAdminRightsMasterBLL();
    private CloudAccountDA.CompanyAdminRightsMasterDataTable objCompanyAdminRightsMasterDT = new CloudAccountDA.CompanyAdminRightsMasterDataTable();
    private bool checkInDB;
    protected Panel pnlAdd;
    protected TextBox txtCode;
    protected RequiredFieldValidator RequiredFieldValidator1;
    protected TextBox txtName;
    protected RequiredFieldValidator RequiredFieldValidator2;
    protected TextBox txtDesc;
    protected CheckBox chkStatus;
    protected Button btnSubmit;
    protected Button btnReset;
    protected Button btnUpdate;
    protected Button btnCancel;
    protected Button btnListAll;
    protected Panel pnlView;
    protected Label lblCode;
    protected Label lblName;
    protected Label lblDesc;
    protected Label lblStatus;
    protected Button btnEdit;
    protected Button btnDelete;
    protected Button btnList;
    protected Button btnAdd;
    protected Panel pnlViewAll;
    protected GridView gvSupportDepartment;
    protected Button btnAddSupportDepartment;
    protected HiddenField hfSupportDepartment;
    protected HiddenField hfMasterAdminID;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyLoginID;
    protected ObjectDataSource objdsSupportDepartment;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("supportMasters")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("supportDepartment")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          SupportDepartmentMaster.AddStatus = "True";
          SupportDepartmentMaster.EditStatus = "True";
          SupportDepartmentMaster.ViewStatus = "True";
          SupportDepartmentMaster.DeleteStatus = "True";
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
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "SupportDepartmentMaster");
          if (this.objMasterAdminRightsMasterDT.Rows.Count > 0)
          {
            SupportDepartmentMaster.AddStatus = this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            SupportDepartmentMaster.EditStatus = this.objMasterAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            SupportDepartmentMaster.ViewStatus = this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            SupportDepartmentMaster.DeleteStatus = this.objMasterAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            SupportDepartmentMaster.AddStatus = "";
            SupportDepartmentMaster.EditStatus = "";
            SupportDepartmentMaster.ViewStatus = "";
            SupportDepartmentMaster.DeleteStatus = "";
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
          this.objCompanyAdminRightsMasterDT = this.objCompanyAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfCompanyID.Value.Trim()), int.Parse(this.hfCompanyLoginID.Value.Trim()), "SupportDepartmentMaster");
          if (this.objCompanyAdminRightsMasterDT.Rows.Count > 0)
          {
            SupportDepartmentMaster.AddStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            SupportDepartmentMaster.EditStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            SupportDepartmentMaster.ViewStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            SupportDepartmentMaster.DeleteStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            SupportDepartmentMaster.AddStatus = "";
            SupportDepartmentMaster.EditStatus = "";
            SupportDepartmentMaster.ViewStatus = "";
            SupportDepartmentMaster.DeleteStatus = "";
          }
        }
        else
        {
          SupportDepartmentMaster.AddStatus = "";
          SupportDepartmentMaster.EditStatus = "";
          SupportDepartmentMaster.ViewStatus = "";
          SupportDepartmentMaster.DeleteStatus = "";
        }
      }
      if (SupportDepartmentMaster.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] == null || !(SupportDepartmentMaster.ViewStatus == "True"))
                break;
              string i = this.Request.QueryString["ID"];
              this.pnlViewAll.Visible = false;
              this.pnlAdd.Visible = false;
              this.pnlView.Visible = true;
              this.ViewRecord(i);
              this.btnEdit.Visible = SupportDepartmentMaster.EditStatus == "True";
              this.btnAddSupportDepartment.Visible = this.btnAdd.Visible = SupportDepartmentMaster.AddStatus == "True";
              this.btnDelete.Visible = SupportDepartmentMaster.DeleteStatus == "True";
              this.btnListAll.Visible = true;
              this.btnUpdate.Visible = false;
              this.btnCancel.Visible = false;
              break;
            case "add":
              if (this.Request.QueryString["ID"] != null)
              {
                if (!(SupportDepartmentMaster.EditStatus == "True"))
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
              if (!(SupportDepartmentMaster.AddStatus == "True"))
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
          if (SupportDepartmentMaster.AddStatus == "False")
            this.btnAddSupportDepartment.Visible = this.btnAdd.Visible = false;
          else
            this.btnAddSupportDepartment.Visible = this.btnAdd.Visible = true;
        }
      }
      else if (SupportDepartmentMaster.AddStatus == "True" && SupportDepartmentMaster.EditStatus == "False" && (SupportDepartmentMaster.ViewStatus == "False" && SupportDepartmentMaster.DeleteStatus == "False"))
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
      this.objSupportDepartmentMasterDT = this.objSupportDepartmentMasterBll.GetDataBySupportDepartmentID(int.Parse(i));
      if (this.objSupportDepartmentMasterDT.Rows.Count <= 0)
        return;
      this.hfSupportDepartment.Value = this.objSupportDepartmentMasterDT.Rows[0]["SupportDepartmentID"].ToString();
      this.lblCode.Text = this.objSupportDepartmentMasterDT.Rows[0]["SupportDepartmentCode"].ToString();
      this.lblName.Text = this.objSupportDepartmentMasterDT.Rows[0]["SupportDepartmentName"].ToString();
      this.lblDesc.Text = this.objSupportDepartmentMasterDT.Rows[0]["SupportDepartmentDesc"].ToString();
      this.lblStatus.Text = this.objSupportDepartmentMasterDT.Rows[0]["SupportDepartmentStatus"].ToString() == "True" ? "True" : "False";
    }

    private void SetRecord(string iD)
    {
      this.objSupportDepartmentMasterDT = this.objSupportDepartmentMasterBll.GetDataBySupportDepartmentID(int.Parse(iD));
      if (this.objSupportDepartmentMasterDT.Rows.Count <= 0)
        return;
      this.hfSupportDepartment.Value = this.objSupportDepartmentMasterDT.Rows[0]["SupportDepartmentID"].ToString();
      this.txtCode.Text = this.objSupportDepartmentMasterDT.Rows[0]["SupportDepartmentCode"].ToString();
      this.txtName.Text = this.objSupportDepartmentMasterDT.Rows[0]["SupportDepartmentName"].ToString();
      this.txtDesc.Text = this.objSupportDepartmentMasterDT.Rows[0]["SupportDepartmentDesc"].ToString();
      this.chkStatus.Checked = this.objSupportDepartmentMasterDT.Rows[0]["SupportDepartmentStatus"].ToString() == "True";
    }

    private void Clear()
    {
      this.txtCode.Text = this.txtDesc.Text = this.txtName.Text = (string) null;
      this.chkStatus.Checked = false;
      this.txtCode.Focus();
    }

    private void BindGrid()
    {
      this.gvSupportDepartment.DataBind();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvSupportDepartment.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvSupportDepartment, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void gvSupportDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/SupportDepartmentMaster.aspx?cmd=view&ID=" + this.gvSupportDepartment.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvSupportDepartment_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvSupportDepartment.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void btnAddSupportDepartment_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/SupportDepartmentMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.txtCode.Text.Trim().Length > 0 && this.txtName.Text.Trim().Length > 0)
      {
        this.objSupportDepartmentMasterDT = this.objSupportDepartmentMasterBll.GetDataBySupportDepartmentName(this.txtName.Text);
        if (this.objSupportDepartmentMasterDT.Rows.Count > 0)
        {
          this.DisplayAlert("SupportDepartment Already Exist..");
          this.checkInDB = true;
        }
        else
          this.checkInDB = false;
        if (this.checkInDB)
          return;
        int num = this.objSupportDepartmentMasterBll.AddSupportDepartment(this.txtCode.Text.Trim(), this.txtName.Text.Trim(), this.chkStatus.Checked, this.txtDesc.Text.Trim());
        if (num != 0)
        {
          this.DisplayAlert("Details Added Successfully.");
          this.Response.Redirect("~/Admin/SupportDepartmentMaster.aspx?cmd=view&ID=" + (object) num);
        }
        else
          this.DisplayAlert("Fail to Add New Details.");
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
          if (this.txtCode.Text.Trim().Length > 0 && this.txtName.Text.Trim().Length > 0)
          {
            this.objSupportDepartmentMasterDT = this.objSupportDepartmentMasterBll.GetDataBySupportDepartmentName(int.Parse(this.hfSupportDepartment.Value.Trim()), this.txtName.Text);
            if (this.objSupportDepartmentMasterDT.Rows.Count > 0)
            {
              this.DisplayAlert("SupportDepartment Already Exist..");
              this.checkInDB = true;
            }
            else
              this.checkInDB = false;
            if (this.checkInDB)
              return;
            if (this.objSupportDepartmentMasterBll.UpdateSupportDepartment(int.Parse(this.hfSupportDepartment.Value.Trim()), this.txtCode.Text.Trim(), this.txtName.Text.Trim(), this.chkStatus.Checked, this.txtDesc.Text.Trim()))
            {
              this.DisplayAlert("Update Successfully..");
              this.Response.Redirect("~/Admin/SupportDepartmentMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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
      this.Response.Redirect("~/Admin/SupportDepartmentMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfSupportDepartment.Value != null)
      {
        if (this.objSupportDepartmentMasterBll.DeleteSupportDepartment(int.Parse(this.hfSupportDepartment.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/Admin/SupportDepartmentMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/SupportDepartmentMaster.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/SupportDepartmentMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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

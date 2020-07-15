// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.InquiryMaster
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
  public class InquiryMaster : Page
  {
    private static string AddStatus = string.Empty;
    private static string EditStatus = string.Empty;
    private static string ViewStatus = string.Empty;
    private static string DeleteStatus = string.Empty;
    private readonly InquiryMasterBLL objInquiryMasterBll = new InquiryMasterBLL();
    private CloudAccountDA.InquiryMasterDataTable objInquiryMasterDT = new CloudAccountDA.InquiryMasterDataTable();
    private readonly MasterAdminRightsMasterBLL objMasterAdminRightsMasterBll = new MasterAdminRightsMasterBLL();
    private CloudAccountDA.MasterAdminRightsMasterDataTable objMasterAdminRightsMasterDT = new CloudAccountDA.MasterAdminRightsMasterDataTable();
    private readonly MasterAdminLoginMasterBLL objMasterAdminLoginMasterBll = new MasterAdminLoginMasterBLL();
    private CloudAccountDA.MasterAdminLoginMasterDataTable objMasterAdminLoginMasterDT = new CloudAccountDA.MasterAdminLoginMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyAdminRightsMasterBLL objCompanyAdminRightsMasterBll = new CompanyAdminRightsMasterBLL();
    private CloudAccountDA.CompanyAdminRightsMasterDataTable objCompanyAdminRightsMasterDT = new CloudAccountDA.CompanyAdminRightsMasterDataTable();
    protected Panel pnlAdd;
    protected TextBox txtName;
    protected RequiredFieldValidator rfvName;
    protected TextBox txtEmail;
    protected RequiredFieldValidator rfvEmail;
    protected TextBox txtContactNo;
    protected RequiredFieldValidator rfvContactNo;
    protected TextBox txtSubject;
    protected TextBox txtLocation;
    protected TextBox txtWebsite;
    protected TextBox txtComments;
    protected RequiredFieldValidator rfvComments;
    protected CheckBox chkStatus;
    protected Button btnSubmit;
    protected Button btnReset;
    protected Button btnUpdate;
    protected Button btnCancel;
    protected Button btnListAll;
    protected Panel pnlView;
    protected Label lblName;
    protected Label lblEmail;
    protected Label lblContactNo;
    protected Label lblSubject;
    protected Label lblLocation;
    protected Label lblWebsite;
    protected Label lblComments;
    protected Label lblStatus;
    protected Button btnEdit;
    protected Button btnDelete;
    protected Button btnList;
    protected Button btnAdd;
    protected Panel pnlViewAll;
    protected GridView gvInquiry;
    protected Button btnAddNew;
    protected ObjectDataSource objdsInquiry;
    protected HiddenField hfInquiry;
    protected HiddenField hfMasterAdminID;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyLoginID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("cmsMaster")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("inquiryMaster")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          InquiryMaster.AddStatus = "True";
          InquiryMaster.EditStatus = "True";
          InquiryMaster.ViewStatus = "True";
          InquiryMaster.DeleteStatus = "True";
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
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "InquiryMaster");
          if (this.objMasterAdminRightsMasterDT.Rows.Count > 0)
          {
            InquiryMaster.AddStatus = this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            InquiryMaster.EditStatus = this.objMasterAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            InquiryMaster.ViewStatus = this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            InquiryMaster.DeleteStatus = this.objMasterAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            InquiryMaster.AddStatus = "";
            InquiryMaster.EditStatus = "";
            InquiryMaster.ViewStatus = "";
            InquiryMaster.DeleteStatus = "";
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
          this.objCompanyAdminRightsMasterDT = this.objCompanyAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfCompanyID.Value.Trim()), int.Parse(this.hfCompanyLoginID.Value.Trim()), "InquiryMaster");
          if (this.objCompanyAdminRightsMasterDT.Rows.Count > 0)
          {
            InquiryMaster.AddStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            InquiryMaster.EditStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            InquiryMaster.ViewStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            InquiryMaster.DeleteStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            InquiryMaster.AddStatus = "";
            InquiryMaster.EditStatus = "";
            InquiryMaster.ViewStatus = "";
            InquiryMaster.DeleteStatus = "";
          }
        }
        else
        {
          InquiryMaster.AddStatus = "";
          InquiryMaster.EditStatus = "";
          InquiryMaster.ViewStatus = "";
          InquiryMaster.DeleteStatus = "";
        }
      }
      if (InquiryMaster.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] == null || !(InquiryMaster.ViewStatus == "True"))
                break;
              string i = this.Request.QueryString["ID"];
              this.pnlViewAll.Visible = false;
              this.pnlAdd.Visible = false;
              this.pnlView.Visible = true;
              this.ViewRecord(i);
              this.btnEdit.Visible = InquiryMaster.EditStatus == "True";
              this.btnAddNew.Visible = this.btnAdd.Visible = InquiryMaster.AddStatus == "True";
              this.btnDelete.Visible = InquiryMaster.DeleteStatus == "True";
              this.btnListAll.Visible = true;
              this.btnUpdate.Visible = false;
              this.btnCancel.Visible = false;
              break;
            case "add":
              if (this.Request.QueryString["ID"] != null)
              {
                if (!(InquiryMaster.EditStatus == "True"))
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
              if (!(InquiryMaster.AddStatus == "True"))
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
          if (InquiryMaster.AddStatus == "False")
            this.btnAddNew.Visible = this.btnAdd.Visible = false;
          else
            this.btnAddNew.Visible = this.btnAdd.Visible = true;
        }
      }
      else if (InquiryMaster.AddStatus == "True" && InquiryMaster.EditStatus == "False" && (InquiryMaster.ViewStatus == "False" && InquiryMaster.DeleteStatus == "False"))
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
      this.objInquiryMasterDT = this.objInquiryMasterBll.GetDataByInquiryID(int.Parse(i));
      if (this.objInquiryMasterDT.Rows.Count <= 0)
        return;
      this.hfInquiry.Value = this.objInquiryMasterDT.Rows[0]["InquiryID"].ToString();
      this.lblName.Text = this.objInquiryMasterDT.Rows[0]["Name"].ToString();
      this.lblEmail.Text = this.objInquiryMasterDT.Rows[0]["Email"].ToString();
      this.lblContactNo.Text = this.objInquiryMasterDT.Rows[0]["ContactNo"].ToString();
      this.lblSubject.Text = this.objInquiryMasterDT.Rows[0]["Subject"].ToString();
      this.lblLocation.Text = this.objInquiryMasterDT.Rows[0]["Location"].ToString();
      this.lblWebsite.Text = this.objInquiryMasterDT.Rows[0]["Website"].ToString();
      this.lblComments.Text = this.objInquiryMasterDT.Rows[0]["Message"].ToString();
      this.lblStatus.Text = this.objInquiryMasterDT.Rows[0]["status"].ToString() == "True" ? "True" : "False";
    }

    private void SetRecord(string iD)
    {
      this.objInquiryMasterDT = this.objInquiryMasterBll.GetDataByInquiryID(int.Parse(iD));
      if (this.objInquiryMasterDT.Rows.Count <= 0)
        return;
      this.hfInquiry.Value = this.objInquiryMasterDT.Rows[0]["InquiryID"].ToString();
      this.txtName.Text = this.objInquiryMasterDT.Rows[0]["Name"].ToString();
      this.txtEmail.Text = this.objInquiryMasterDT.Rows[0]["Email"].ToString();
      this.txtContactNo.Text = this.objInquiryMasterDT.Rows[0]["ContactNo"].ToString();
      this.txtSubject.Text = this.objInquiryMasterDT.Rows[0]["Subject"].ToString();
      this.txtLocation.Text = this.objInquiryMasterDT.Rows[0]["Location"].ToString();
      this.txtWebsite.Text = this.objInquiryMasterDT.Rows[0]["Website"].ToString();
      this.txtComments.Text = this.objInquiryMasterDT.Rows[0]["Message"].ToString();
      this.chkStatus.Checked = this.objInquiryMasterDT.Rows[0]["status"].ToString() == "True";
    }

    private void Clear()
    {
      this.txtName.Text = this.txtEmail.Text = this.txtContactNo.Text = this.txtSubject.Text = this.txtLocation.Text = this.txtWebsite.Text = this.txtComments.Text = "";
      this.chkStatus.Checked = false;
      this.txtName.Focus();
    }

    private void BindGrid()
    {
      this.gvInquiry.DataBind();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvInquiry.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvInquiry, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void gvInquiry_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/InquiryMaster.aspx?cmd=view&ID=" + this.gvInquiry.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvInquiry_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvInquiry.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void btnAddInquiry_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/InquiryMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      int num = this.objInquiryMasterBll.AddInquiry(this.txtName.Text.Trim(), this.txtEmail.Text.Trim(), this.txtContactNo.Text.Trim(), this.txtSubject.Text.Trim(), this.txtLocation.Text.Trim(), this.txtWebsite.Text.Trim(), this.txtComments.Text.Trim(), this.chkStatus.Checked);
      if (num != 0)
      {
        this.DisplayAlert("Details Added Successfully.");
        this.Response.Redirect("~/BillTransact/InquiryMaster.aspx?cmd=view&ID=" + (object) num);
      }
      else
      {
        this.DisplayAlert("Fail to Add New Details.");
        this.Clear();
      }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.Page.IsValid)
        {
          if (this.objInquiryMasterBll.UpdateInquiry(int.Parse(this.hfInquiry.Value.Trim()), this.txtName.Text.Trim(), this.txtEmail.Text.Trim(), this.txtContactNo.Text.Trim(), this.txtSubject.Text.Trim(), this.txtLocation.Text.Trim(), this.txtWebsite.Text.Trim(), this.txtComments.Text.Trim(), this.chkStatus.Checked))
          {
            this.DisplayAlert("Update Successfully..");
            this.Response.Redirect("~/BillTransact/InquiryMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
          }
          else
            this.DisplayAlert("Fail to Update Details.");
        }
        else
          this.DisplayAlert("Fail to Update Details.");
      }
      catch (Exception ex)
      {
        this.DisplayAlert(ex.Message);
      }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
      this.Clear();
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/InquiryMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfInquiry.Value != null)
      {
        if (this.objInquiryMasterBll.DeleteInquiry(int.Parse(this.hfInquiry.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/BillTransact/InquiryMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/InquiryMaster.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/InquiryMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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

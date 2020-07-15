// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.TestimonialsMaster
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class TestimonialsMaster : Page
  {
    private static string AddStatus = string.Empty;
    private static string EditStatus = string.Empty;
    private static string ViewStatus = string.Empty;
    private static string DeleteStatus = string.Empty;
    private readonly TestimonialsMasterBLL objTestimonialsMasterBll = new TestimonialsMasterBLL();
    private CloudAccountDA.TestimonialsMasterDataTable objTestimonialsMasterDT = new CloudAccountDA.TestimonialsMasterDataTable();
    private readonly MasterAdminRightsMasterBLL objMasterAdminRightsMasterBll = new MasterAdminRightsMasterBLL();
    private CloudAccountDA.MasterAdminRightsMasterDataTable objMasterAdminRightsMasterDT = new CloudAccountDA.MasterAdminRightsMasterDataTable();
    private readonly MasterAdminLoginMasterBLL objMasterAdminLoginMasterBll = new MasterAdminLoginMasterBLL();
    private CloudAccountDA.MasterAdminLoginMasterDataTable objMasterAdminLoginMasterDT = new CloudAccountDA.MasterAdminLoginMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyAdminRightsMasterBLL objCompanyAdminRightsMasterBll = new CompanyAdminRightsMasterBLL();
    private CloudAccountDA.CompanyAdminRightsMasterDataTable objCompanyAdminRightsMasterDT = new CloudAccountDA.CompanyAdminRightsMasterDataTable();
    protected ToolkitScriptManager tsm;
    protected Panel pnlAdd;
    protected TextBox txtName;
    protected RequiredFieldValidator RequiredFieldValidator2;
    protected TextBox txtCompanyName;
    protected RequiredFieldValidator RequiredFieldValidator1;
    protected TextBox txtLocation;
    protected RequiredFieldValidator RequiredFieldValidator3;
    protected TextBox txtComment;
    protected TextBox txtDate;
    protected CalendarExtender ceDate;
    protected CheckBox chkStatus;
    protected Button btnSubmit;
    protected Button btnReset;
    protected Button btnUpdate;
    protected Button btnCancel;
    protected Button btnListAll;
    protected Panel pnlView;
    protected Label lblName;
    protected Label lblCompanyName;
    protected Label lblLocation;
    protected Label lblComment;
    protected Label lblDate;
    protected Label lblStatus;
    protected Button btnEdit;
    protected Button btnDelete;
    protected Button btnList;
    protected Button btnAdd;
    protected Panel pnlViewAll;
    protected GridView gvTestimonials;
    protected Button btnAddTestimonials;
    protected HiddenField hfTestimonials;
    protected HiddenField hfMasterAdminID;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyLoginID;
    protected ObjectDataSource objdsTestimonials;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("cmsMaster")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("TestimonialsMaster")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          TestimonialsMaster.AddStatus = "True";
          TestimonialsMaster.EditStatus = "True";
          TestimonialsMaster.ViewStatus = "True";
          TestimonialsMaster.DeleteStatus = "True";
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
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "TestimonialsMaster");
          if (this.objMasterAdminRightsMasterDT.Rows.Count > 0)
          {
            TestimonialsMaster.AddStatus = this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            TestimonialsMaster.EditStatus = this.objMasterAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            TestimonialsMaster.ViewStatus = this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            TestimonialsMaster.DeleteStatus = this.objMasterAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            TestimonialsMaster.AddStatus = "";
            TestimonialsMaster.EditStatus = "";
            TestimonialsMaster.ViewStatus = "";
            TestimonialsMaster.DeleteStatus = "";
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
          this.objCompanyAdminRightsMasterDT = this.objCompanyAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfCompanyID.Value.Trim()), int.Parse(this.hfCompanyLoginID.Value.Trim()), "TestimonialsMaster");
          if (this.objCompanyAdminRightsMasterDT.Rows.Count > 0)
          {
            TestimonialsMaster.AddStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            TestimonialsMaster.EditStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            TestimonialsMaster.ViewStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            TestimonialsMaster.DeleteStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            TestimonialsMaster.AddStatus = "";
            TestimonialsMaster.EditStatus = "";
            TestimonialsMaster.ViewStatus = "";
            TestimonialsMaster.DeleteStatus = "";
          }
        }
        else
        {
          TestimonialsMaster.AddStatus = "";
          TestimonialsMaster.EditStatus = "";
          TestimonialsMaster.ViewStatus = "";
          TestimonialsMaster.DeleteStatus = "";
        }
      }
      if (TestimonialsMaster.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] == null || !(TestimonialsMaster.ViewStatus == "True"))
                break;
              string i = this.Request.QueryString["ID"];
              this.pnlViewAll.Visible = false;
              this.pnlAdd.Visible = false;
              this.pnlView.Visible = true;
              this.ViewRecord(i);
              this.btnEdit.Visible = TestimonialsMaster.EditStatus == "True";
              this.btnAddTestimonials.Visible = this.btnAdd.Visible = TestimonialsMaster.AddStatus == "True";
              this.btnDelete.Visible = TestimonialsMaster.DeleteStatus == "True";
              this.btnListAll.Visible = true;
              this.btnUpdate.Visible = false;
              this.btnCancel.Visible = false;
              break;
            case "add":
              if (this.Request.QueryString["ID"] != null)
              {
                if (!(TestimonialsMaster.EditStatus == "True"))
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
              if (!(TestimonialsMaster.AddStatus == "True"))
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
          if (TestimonialsMaster.AddStatus == "False")
            this.btnAddTestimonials.Visible = this.btnAdd.Visible = false;
          else
            this.btnAddTestimonials.Visible = this.btnAdd.Visible = true;
        }
      }
      else if (TestimonialsMaster.AddStatus == "True" && TestimonialsMaster.EditStatus == "False" && (TestimonialsMaster.ViewStatus == "False" && TestimonialsMaster.DeleteStatus == "False"))
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
      this.objTestimonialsMasterDT = this.objTestimonialsMasterBll.GetDataByTestimonialsID(int.Parse(i));
      if (this.objTestimonialsMasterDT.Rows.Count <= 0)
        return;
      this.hfTestimonials.Value = this.objTestimonialsMasterDT.Rows[0]["TestimonialID"].ToString();
      this.lblName.Text = this.objTestimonialsMasterDT.Rows[0]["TestimonialName"].ToString();
      this.lblCompanyName.Text = this.objTestimonialsMasterDT.Rows[0]["TestimonialCompanyName"].ToString();
      this.lblLocation.Text = this.objTestimonialsMasterDT.Rows[0]["TestimonialLocation"].ToString();
      this.lblComment.Text = this.objTestimonialsMasterDT.Rows[0]["TestimonialComment"].ToString();
      string s = this.objTestimonialsMasterDT.Rows[0]["TestimonialDate"].ToString();
      if (!string.IsNullOrEmpty(s))
        this.lblDate.Text = DateTime.Parse(s).ToString("MM/dd/yyyy");
      this.lblStatus.Text = this.objTestimonialsMasterDT.Rows[0]["TestimonialStatus"].ToString() == "True" ? "True" : "False";
    }

    private void SetRecord(string iD)
    {
      this.objTestimonialsMasterDT = this.objTestimonialsMasterBll.GetDataByTestimonialsID(int.Parse(iD));
      if (this.objTestimonialsMasterDT.Rows.Count <= 0)
        return;
      this.hfTestimonials.Value = this.objTestimonialsMasterDT.Rows[0]["TestimonialID"].ToString();
      this.txtName.Text = this.objTestimonialsMasterDT.Rows[0]["TestimonialName"].ToString();
      this.txtCompanyName.Text = this.objTestimonialsMasterDT.Rows[0]["TestimonialCompanyName"].ToString();
      this.txtLocation.Text = this.objTestimonialsMasterDT.Rows[0]["TestimonialLocation"].ToString();
      this.txtComment.Text = this.objTestimonialsMasterDT.Rows[0]["TestimonialComment"].ToString();
      string s = this.objTestimonialsMasterDT.Rows[0]["TestimonialDate"].ToString();
      if (!string.IsNullOrEmpty(s))
        this.txtDate.Text = DateTime.Parse(s).ToString("MM/dd/yyyy");
      this.chkStatus.Checked = this.objTestimonialsMasterDT.Rows[0]["TestimonialStatus"].ToString() == "True";
    }

    private void Clear()
    {
      this.txtName.Text = this.txtCompanyName.Text = this.txtLocation.Text = this.txtComment.Text = this.txtDate.Text = "";
      this.chkStatus.Checked = false;
      this.txtName.Focus();
    }

    private void BindGrid()
    {
      this.gvTestimonials.DataBind();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvTestimonials.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvTestimonials, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void gvTestimonials_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/TestimonialsMaster.aspx?cmd=view&ID=" + this.gvTestimonials.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvTestimonials_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvTestimonials.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void btnAddTestimonials_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/TestimonialsMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.txtCompanyName.Text.Trim().Length > 0 && this.txtName.Text.Trim().Length > 0 && this.txtLocation.Text.Trim().Length > 0)
      {
        DateTime? dtTestimonialDate = new DateTime?();
        if (this.txtDate.Text.Trim().Length > 0)
          dtTestimonialDate = new DateTime?(DateTime.Parse(this.txtDate.Text.Trim()));
        int num = this.objTestimonialsMasterBll.AddTestimonials(this.txtName.Text.Trim(), this.txtCompanyName.Text.Trim(), this.txtLocation.Text.Trim(), this.txtComment.Text.Trim(), dtTestimonialDate, this.chkStatus.Checked);
        if (num != 0)
        {
          this.DisplayAlert("Details Added Successfully.");
          this.Response.Redirect("~/BillTransact/TestimonialsMaster.aspx?cmd=view&ID=" + (object) num);
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
          if (this.txtCompanyName.Text.Trim().Length > 0 && this.txtName.Text.Trim().Length > 0 && this.txtLocation.Text.Trim().Length > 0)
          {
            DateTime? dtTestimonialDate = new DateTime?();
            if (this.txtDate.Text.Trim().Length > 0)
              dtTestimonialDate = new DateTime?(DateTime.Parse(this.txtDate.Text.Trim()));
            if (this.objTestimonialsMasterBll.UpdateTestimonials(int.Parse(this.hfTestimonials.Value.Trim()), this.txtName.Text.Trim(), this.txtCompanyName.Text.Trim(), this.txtLocation.Text.Trim(), this.txtComment.Text.Trim(), dtTestimonialDate, this.chkStatus.Checked))
            {
              this.DisplayAlert("Update Successfully..");
              this.Response.Redirect("~/BillTransact/TestimonialsMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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
      this.Response.Redirect("~/BillTransact/TestimonialsMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfTestimonials.Value != null)
      {
        if (this.objTestimonialsMasterBll.DeleteTestimonials(int.Parse(this.hfTestimonials.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/BillTransact/TestimonialsMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/TestimonialsMaster.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/TestimonialsMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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

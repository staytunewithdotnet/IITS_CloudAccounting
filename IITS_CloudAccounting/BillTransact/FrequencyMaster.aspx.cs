// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.FrequencyMaster
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
  public class FrequencyMaster : Page
  {
    private static string AddStatus = string.Empty;
    private static string EditStatus = string.Empty;
    private static string ViewStatus = string.Empty;
    private static string DeleteStatus = string.Empty;
    private readonly FrequencyMasterBLL objFrequencyMasterBll = new FrequencyMasterBLL();
    private CloudAccountDA.FrequencyMasterDataTable objFrequencyMasterDT = new CloudAccountDA.FrequencyMasterDataTable();
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
    protected TextBox txtName;
    protected RequiredFieldValidator RequiredFieldValidator2;
    protected TextBox txtNoOfDays;
    protected TextBox txtDesc;
    protected CheckBox chkStatus;
    protected Button btnSubmit;
    protected Button btnReset;
    protected Button btnUpdate;
    protected Button btnCancel;
    protected Button btnListAll;
    protected Panel pnlView;
    protected Label lblName;
    protected Label lblNoOfDays;
    protected Label lblDesc;
    protected Label lblStatus;
    protected Button btnEdit;
    protected Button btnDelete;
    protected Button btnList;
    protected Button btnAdd;
    protected Panel pnlViewAll;
    protected GridView gvFrequency;
    protected Button btnAddFrequency;
    protected HiddenField hfFrequency;
    protected HiddenField hfMasterAdminID;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyLoginID;
    protected ObjectDataSource objdsFrequency;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("generalMaster")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("frequency")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          FrequencyMaster.AddStatus = "True";
          FrequencyMaster.EditStatus = "True";
          FrequencyMaster.ViewStatus = "True";
          FrequencyMaster.DeleteStatus = "True";
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
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "FrequencyMaster");
          if (this.objMasterAdminRightsMasterDT.Rows.Count > 0)
          {
            FrequencyMaster.AddStatus = this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            FrequencyMaster.EditStatus = this.objMasterAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            FrequencyMaster.ViewStatus = this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            FrequencyMaster.DeleteStatus = this.objMasterAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            FrequencyMaster.AddStatus = "";
            FrequencyMaster.EditStatus = "";
            FrequencyMaster.ViewStatus = "";
            FrequencyMaster.DeleteStatus = "";
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
          this.objCompanyAdminRightsMasterDT = this.objCompanyAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfCompanyID.Value.Trim()), int.Parse(this.hfCompanyLoginID.Value.Trim()), "FrequencyMaster");
          if (this.objCompanyAdminRightsMasterDT.Rows.Count > 0)
          {
            FrequencyMaster.AddStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            FrequencyMaster.EditStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            FrequencyMaster.ViewStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            FrequencyMaster.DeleteStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            FrequencyMaster.AddStatus = "";
            FrequencyMaster.EditStatus = "";
            FrequencyMaster.ViewStatus = "";
            FrequencyMaster.DeleteStatus = "";
          }
        }
        else
        {
          FrequencyMaster.AddStatus = "";
          FrequencyMaster.EditStatus = "";
          FrequencyMaster.ViewStatus = "";
          FrequencyMaster.DeleteStatus = "";
        }
      }
      if (FrequencyMaster.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] == null || !(FrequencyMaster.ViewStatus == "True"))
                break;
              string i = this.Request.QueryString["ID"];
              this.pnlViewAll.Visible = false;
              this.pnlAdd.Visible = false;
              this.pnlView.Visible = true;
              this.ViewRecord(i);
              this.btnEdit.Visible = FrequencyMaster.EditStatus == "True";
              this.btnAddFrequency.Visible = this.btnAdd.Visible = FrequencyMaster.AddStatus == "True";
              this.btnDelete.Visible = FrequencyMaster.DeleteStatus == "True";
              this.btnListAll.Visible = true;
              this.btnUpdate.Visible = false;
              this.btnCancel.Visible = false;
              break;
            case "add":
              if (this.Request.QueryString["ID"] != null)
              {
                if (!(FrequencyMaster.EditStatus == "True"))
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
              if (!(FrequencyMaster.AddStatus == "True"))
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
          if (FrequencyMaster.AddStatus == "False")
            this.btnAddFrequency.Visible = this.btnAdd.Visible = false;
          else
            this.btnAddFrequency.Visible = this.btnAdd.Visible = true;
        }
      }
      else if (FrequencyMaster.AddStatus == "True" && FrequencyMaster.EditStatus == "False" && (FrequencyMaster.ViewStatus == "False" && FrequencyMaster.DeleteStatus == "False"))
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
      this.objFrequencyMasterDT = this.objFrequencyMasterBll.GetDataByFrequencyID(int.Parse(i));
      if (this.objFrequencyMasterDT.Rows.Count <= 0)
        return;
      this.hfFrequency.Value = this.objFrequencyMasterDT.Rows[0]["FrequencyID"].ToString();
      this.lblName.Text = this.objFrequencyMasterDT.Rows[0]["FrequencyName"].ToString();
      this.lblNoOfDays.Text = this.objFrequencyMasterDT.Rows[0]["NoOfDays"].ToString();
      this.lblDesc.Text = this.objFrequencyMasterDT.Rows[0]["FrequencyDesc"].ToString();
      this.lblStatus.Text = this.objFrequencyMasterDT.Rows[0]["FrequencyStatus"].ToString() == "True" ? "True" : "False";
    }

    private void SetRecord(string iD)
    {
      this.objFrequencyMasterDT = this.objFrequencyMasterBll.GetDataByFrequencyID(int.Parse(iD));
      if (this.objFrequencyMasterDT.Rows.Count <= 0)
        return;
      this.hfFrequency.Value = this.objFrequencyMasterDT.Rows[0]["FrequencyID"].ToString();
      this.txtName.Text = this.objFrequencyMasterDT.Rows[0]["FrequencyName"].ToString();
      this.txtNoOfDays.Text = this.objFrequencyMasterDT.Rows[0]["NoOfDays"].ToString();
      this.txtDesc.Text = this.objFrequencyMasterDT.Rows[0]["FrequencyDesc"].ToString();
      this.chkStatus.Checked = this.objFrequencyMasterDT.Rows[0]["FrequencyStatus"].ToString() == "True";
    }

    private void Clear()
    {
      this.txtDesc.Text = this.txtName.Text = (string) null;
      this.chkStatus.Checked = false;
      this.txtName.Focus();
    }

    private void BindGrid()
    {
      this.gvFrequency.DataBind();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvFrequency.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvFrequency, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void gvFrequency_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/FrequencyMaster.aspx?cmd=view&ID=" + this.gvFrequency.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvFrequency_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvFrequency.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void btnAddFrequency_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/FrequencyMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.txtName.Text.Trim().Length > 0 && this.txtNoOfDays.Text.Trim().Length > 0)
      {
        this.objFrequencyMasterDT = this.objFrequencyMasterBll.GetDataByFrequencyName(this.txtName.Text);
        if (this.objFrequencyMasterDT.Rows.Count > 0)
        {
          this.DisplayAlert("Frequency Already Exist..");
          this.checkInDB = true;
        }
        else
          this.checkInDB = false;
        if (!this.checkInDB)
        {
          int num = this.objFrequencyMasterBll.AddFrequency(this.txtName.Text.Trim(), int.Parse(this.txtNoOfDays.Text.Trim()), this.txtDesc.Text.Trim(), this.chkStatus.Checked);
          if (num != 0)
          {
            this.DisplayAlert("Details Added Successfully.");
            this.Response.Redirect("~/BillTransact/FrequencyMaster.aspx?cmd=view&ID=" + (object) num);
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
          if (this.txtName.Text.Trim().Length > 0 && this.txtNoOfDays.Text.Trim().Length > 0)
          {
            if (this.objFrequencyMasterBll.UpdateFrequency(int.Parse(this.hfFrequency.Value.Trim()), this.txtName.Text.Trim(), int.Parse(this.txtNoOfDays.Text.Trim()), this.txtDesc.Text.Trim(), this.chkStatus.Checked))
            {
              this.DisplayAlert("Update Successfully..");
              this.Response.Redirect("~/BillTransact/FrequencyMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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
      this.Response.Redirect("~/BillTransact/FrequencyMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfFrequency.Value != null)
      {
        if (this.objFrequencyMasterBll.DeleteFrequency(int.Parse(this.hfFrequency.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/BillTransact/FrequencyMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/FrequencyMaster.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/FrequencyMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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

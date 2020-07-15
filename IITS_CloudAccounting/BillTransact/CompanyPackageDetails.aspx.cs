// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.CompanyPackageDetails
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
  public class CompanyPackageDetails : Page
  {
    private readonly CompanyPackageDetailsBLL objCompanyPackageDetailsBll = new CompanyPackageDetailsBLL();
    private CloudAccountDA.CompanyPackageDetailsDataTable objCompanyPackageDetailsDT = new CloudAccountDA.CompanyPackageDetailsDataTable();
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly PackageMasterBLL objPackageMasterBll = new PackageMasterBLL();
    private CloudAccountDA.PackageMasterDataTable objPackageMasterDT = new CloudAccountDA.PackageMasterDataTable();
    public static bool abc;
    protected ToolkitScriptManager tsm;
    protected Panel pnlAdd;
    protected DropDownList ddlCompanyName;
    protected SqlDataSource SqlCompanyMaster;
    protected RequiredFieldValidator rfvCompanyName;
    protected DropDownList ddlPackageName;
    protected SqlDataSource SqlPackageMaster;
    protected RequiredFieldValidator rfvPackageName;
    protected TextBox txtStartDate;
    protected CalendarExtender cStartDate;
    protected RequiredFieldValidator rfvStartDate;
    protected TextBox txtEndDate;
    protected CalendarExtender cEndDate;
    protected RequiredFieldValidator rfvEndDate;
    protected TextBox txtPackageMonthlyAmount;
    protected RequiredFieldValidator rfvPackageMonthlyAmount;
    protected TextBox txtPackageYearlyAmount;
    protected RequiredFieldValidator rfvPackageYearlyAmount;
    protected CheckBox chkPackagePaid;
    protected TextBox txtPackageAmountPaid;
    protected TextBox txtPackagePaymentTransaction;
    protected TextBox txtPackagePaymentDate;
    protected CalendarExtender CPackageAmountDate;
    protected RequiredFieldValidator rfvPackageAmountDate;
    protected TextBox txtPackageAssignDate;
    protected CalendarExtender CPackageAssignDate;
    protected RequiredFieldValidator rfvPackageAssignDate;
    protected CheckBox chkStatus;
    protected Button btnSubmit;
    protected Button btnReset;
    protected Button btnUpdate;
    protected Button btnListAll;
    protected Button btnCancel;
    protected Panel pnlView;
    protected Label lblCompanyName;
    protected Label lblPackageName;
    protected Label lblStartDate;
    protected Label lblEndDate;
    protected Label lblPackageMonthlyAmount;
    protected Label lblPackageYearlyAmount;
    protected Label lblPackagePaid;
    protected Label lblPackageAmountPaid;
    protected Label lblPackagePaymentTransaction;
    protected Label lblPackagePaymentDate;
    protected Label lblPackageAssignDate;
    protected Label lblStatus;
    protected Button btnUpgrade;
    protected Button btnEdit;
    protected Button btnDelete;
    protected Button btnList;
    protected Button btnAdd;
    protected Panel pnlViewAll;
    protected GridView gvCompanyPackage;
    protected Button btnAddCompanyPackage;
    protected ObjectDataSource objdsCompanyPackage;
    protected ObjectDataSource objdsOnlyCompanyPackage;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyPackage;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("companyManagement")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("companyPackageDetails")).Attributes.Add("class", "active open");
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
            if (this.Request.QueryString["ID"] == null || !(this.Request.QueryString["ID"] != ""))
              break;
            string iD = this.Request.QueryString["ID"];
            this.pnlViewAll.Visible = false;
            this.pnlAdd.Visible = false;
            this.pnlView.Visible = true;
            this.ViewRecord(iD);
            if (user == null || !Roles.IsUserInRole(user.ToString(), "Admin"))
              break;
            this.btnAdd.Visible = false;
            this.btnDelete.Visible = false;
            this.btnEdit.Visible = false;
            this.btnUpgrade.Visible = true;
            break;
          case "add":
            if (this.Request.QueryString["ID"] != null && this.Request.QueryString["ID"] != "")
            {
              this.SetRecord(this.Request.QueryString["ID"]);
              this.pnlAdd.Visible = true;
              this.pnlViewAll.Visible = false;
              this.pnlView.Visible = false;
              this.btnUpdate.Visible = true;
              this.btnCancel.Visible = true;
              this.btnSubmit.Visible = false;
              this.btnReset.Visible = false;
              this.btnListAll.Visible = false;
              this.ddlCompanyName.Focus();
              if (user == null || !Roles.IsUserInRole(user.ToString(), "Admin"))
                break;
              this.ddlCompanyName.Enabled = false;
              this.txtStartDate.Enabled = this.txtEndDate.Enabled = this.txtPackageMonthlyAmount.Enabled = this.txtPackageYearlyAmount.Enabled = this.txtPackageAmountPaid.Enabled = this.txtPackagePaymentTransaction.Enabled = this.txtPackagePaymentDate.Enabled = this.txtPackageAssignDate.Enabled = false;
              this.chkStatus.Enabled = this.chkPackagePaid.Enabled = false;
              break;
            }
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
        this.btnAddCompanyPackage.Visible = false;
      }
    }

    private void ViewRecord(string iD)
    {
      this.objCompanyPackageDetailsDT = this.objCompanyPackageDetailsBll.GetDataByCompanyPackageID(int.Parse(iD));
      if (this.objCompanyPackageDetailsDT.Rows.Count <= 0)
        return;
      this.hfCompanyPackage.Value = this.objCompanyPackageDetailsDT.Rows[0]["CompanyPackageID"].ToString();
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(this.objCompanyPackageDetailsDT.Rows[0]["CompanyID"].ToString()));
      if (this.objCompanyMasterDT.Rows.Count > 0)
      {
        this.lblCompanyName.Text = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
        this.hfCompanyID.Value = this.objCompanyPackageDetailsDT.Rows[0]["CompanyID"].ToString();
      }
      this.objPackageMasterDT = this.objPackageMasterBll.GetDataByPackageID(int.Parse(this.objCompanyPackageDetailsDT.Rows[0]["PackageID"].ToString()));
      if (this.objPackageMasterDT.Rows.Count > 0)
        this.lblPackageName.Text = this.objPackageMasterDT.Rows[0]["PackageName"].ToString();
      this.lblStartDate.Text = Convert.ToDateTime(this.objCompanyPackageDetailsDT.Rows[0]["PackageStartDate"].ToString()).ToShortDateString();
      this.lblEndDate.Text = Convert.ToDateTime(this.objCompanyPackageDetailsDT.Rows[0]["PackageEndDate"].ToString()).ToShortDateString();
      this.lblPackageMonthlyAmount.Text = this.objCompanyPackageDetailsDT.Rows[0]["PackageMonthlyAmount"].ToString();
      this.lblPackageMonthlyAmount.Text = double.Parse(this.lblPackageMonthlyAmount.Text).ToString("0.00");
      this.lblPackageYearlyAmount.Text = this.objCompanyPackageDetailsDT.Rows[0]["PackageYearlyAmount"].ToString();
      this.lblPackageYearlyAmount.Text = double.Parse(this.lblPackageYearlyAmount.Text).ToString("0.00");
      this.lblPackagePaid.Text = this.objCompanyPackageDetailsDT.Rows[0]["PackagePaid"].ToString() == "True" ? "True" : "False";
      this.lblPackageAmountPaid.Text = this.objCompanyPackageDetailsDT.Rows[0]["PackagePaidAmount"].ToString();
      this.lblPackageAmountPaid.Text = double.Parse(this.lblPackageAmountPaid.Text).ToString("0.00");
      this.lblPackagePaymentTransaction.Text = this.objCompanyPackageDetailsDT.Rows[0]["PackagePaymentTransDetail"].ToString();
      if (!string.IsNullOrEmpty(this.objCompanyPackageDetailsDT.Rows[0]["PackagePaymentTransDate"].ToString()))
        this.lblPackagePaymentDate.Text = Convert.ToDateTime(this.objCompanyPackageDetailsDT.Rows[0]["PackagePaymentTransDate"].ToString()).ToShortDateString();
      if (!string.IsNullOrEmpty(this.objCompanyPackageDetailsDT.Rows[0]["PackageAssignDate"].ToString()))
        this.lblPackageAssignDate.Text = Convert.ToDateTime(this.objCompanyPackageDetailsDT.Rows[0]["PackageAssignDate"].ToString()).ToShortDateString();
      this.lblStatus.Text = this.objCompanyPackageDetailsDT.Rows[0]["ActivePackage"].ToString() == "True" ? "True" : "False";
    }

    private void SetRecord(string iD)
    {
      this.objCompanyPackageDetailsDT = this.objCompanyPackageDetailsBll.GetDataByCompanyPackageID(int.Parse(iD));
      if (this.objCompanyPackageDetailsDT.Rows.Count <= 0)
        return;
      this.hfCompanyPackage.Value = this.objCompanyPackageDetailsDT.Rows[0]["CompanyPackageID"].ToString();
      this.hfCompanyID.Value = this.objCompanyPackageDetailsDT.Rows[0]["CompanyID"].ToString();
      this.ddlCompanyName.SelectedValue = this.objCompanyPackageDetailsDT.Rows[0]["CompanyID"].ToString();
      this.ddlPackageName.SelectedValue = this.objCompanyPackageDetailsDT.Rows[0]["PackageID"].ToString();
      this.txtStartDate.Text = Convert.ToDateTime(this.objCompanyPackageDetailsDT.Rows[0]["PackageStartDate"].ToString()).ToShortDateString();
      this.txtEndDate.Text = Convert.ToDateTime(this.objCompanyPackageDetailsDT.Rows[0]["PackageEndDate"].ToString()).ToShortDateString();
      this.txtPackageMonthlyAmount.Text = this.objCompanyPackageDetailsDT.Rows[0]["PackageMonthlyAmount"].ToString();
      this.txtPackageMonthlyAmount.Text = double.Parse(this.txtPackageMonthlyAmount.Text).ToString("0.00");
      this.txtPackageYearlyAmount.Text = this.objCompanyPackageDetailsDT.Rows[0]["PackageYearlyAmount"].ToString();
      this.txtPackageYearlyAmount.Text = double.Parse(this.txtPackageYearlyAmount.Text).ToString("0.00");
      this.chkPackagePaid.Checked = Convert.ToBoolean(this.objCompanyPackageDetailsDT.Rows[0]["PackagePaid"].ToString());
      this.txtPackageAmountPaid.Text = this.objCompanyPackageDetailsDT.Rows[0]["PackagePaidAmount"].ToString();
      this.txtPackageAmountPaid.Text = double.Parse(this.txtPackageAmountPaid.Text).ToString("0.00");
      this.txtPackagePaymentTransaction.Text = this.objCompanyPackageDetailsDT.Rows[0]["PackagePaymentTransDetail"].ToString();
      if (!string.IsNullOrEmpty(this.objCompanyPackageDetailsDT.Rows[0]["PackagePaymentTransDate"].ToString()))
        this.txtPackagePaymentDate.Text = Convert.ToDateTime(this.objCompanyPackageDetailsDT.Rows[0]["PackagePaymentTransDate"].ToString()).ToShortDateString();
      if (!string.IsNullOrEmpty(this.objCompanyPackageDetailsDT.Rows[0]["PackageAssignDate"].ToString()))
        this.txtPackageAssignDate.Text = Convert.ToDateTime(this.objCompanyPackageDetailsDT.Rows[0]["PackageAssignDate"].ToString()).ToShortDateString();
      this.chkStatus.Checked = Convert.ToBoolean(this.objCompanyPackageDetailsDT.Rows[0]["ActivePackage"].ToString());
    }

    private void Clear()
    {
      this.txtStartDate.Text = this.txtEndDate.Text = this.txtPackageMonthlyAmount.Text = this.txtPackageYearlyAmount.Text = this.txtPackageAmountPaid.Text = this.txtPackagePaymentTransaction.Text = this.txtPackagePaymentDate.Text = this.txtPackageAssignDate.Text = (string) null;
      this.chkStatus.Checked = this.chkPackagePaid.Checked = false;
      this.ddlCompanyName.Focus();
    }

    private void BindGrid()
    {
      if (Admin.RoleName == "MasterAdmin")
      {
        this.gvCompanyPackage.DataSource = (object) this.objdsCompanyPackage;
        this.btnAddCompanyPackage.Visible = true;
      }
      else if (Admin.RoleName == "Admin")
      {
        this.gvCompanyPackage.DataSource = (object) this.objdsOnlyCompanyPackage;
        this.btnAddCompanyPackage.Visible = false;
      }
      this.gvCompanyPackage.DataBind();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvCompanyPackage.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvCompanyPackage, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void gvCompanyPackage_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/CompanyPackageDetails.aspx?cmd=view&ID=" + this.gvCompanyPackage.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvCompanyPackage_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvCompanyPackage.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void btnAddCompanyPackage_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/CompanyPackageDetails.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (Convert.ToInt32(this.ddlCompanyName.SelectedValue) != 0 && Convert.ToInt32(this.ddlPackageName.SelectedValue) != 0)
      {
        int num = this.objCompanyPackageDetailsBll.AddCompanyPackage(Convert.ToInt32(this.ddlCompanyName.SelectedValue), Convert.ToInt32(this.ddlPackageName.SelectedValue), new DateTime?(DateTime.Parse(this.txtStartDate.Text)), new DateTime?(DateTime.Parse(this.txtEndDate.Text.Trim())), new Decimal?(Convert.ToDecimal(this.txtPackageMonthlyAmount.Text.Trim())), new Decimal?(Convert.ToDecimal(this.txtPackageYearlyAmount.Text.Trim())), this.chkPackagePaid.Checked, new Decimal?(Convert.ToDecimal(this.txtPackageAmountPaid.Text.Trim())), this.txtPackagePaymentTransaction.Text.Trim(), new DateTime?(DateTime.Parse(this.txtPackagePaymentDate.Text.Trim())), new DateTime?(DateTime.Parse(this.txtPackageAssignDate.Text.Trim())), this.chkStatus.Checked);
        if (num != 0)
        {
          this.DisplayAlert("Details Added Successfully.");
          this.Response.Redirect("~/BillTransact/CompanyPackageDetails.aspx?cmd=view&ID=" + (object) num);
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
          if (Convert.ToInt32(this.ddlCompanyName.SelectedValue) != 0 && Convert.ToInt32(this.ddlPackageName.SelectedValue) != 0)
          {
            if (this.objCompanyPackageDetailsBll.UpdateCompanyPackage(int.Parse(this.hfCompanyPackage.Value.Trim()), Convert.ToInt32(this.ddlCompanyName.SelectedValue), Convert.ToInt32(this.ddlPackageName.SelectedValue), new DateTime?(Convert.ToDateTime(this.txtStartDate.Text.Trim())), new DateTime?(Convert.ToDateTime(this.txtEndDate.Text.Trim())), new Decimal?(Convert.ToDecimal(this.txtPackageMonthlyAmount.Text.Trim())), new Decimal?(Convert.ToDecimal(this.txtPackageYearlyAmount.Text.Trim())), this.chkPackagePaid.Checked, new Decimal?(Convert.ToDecimal(this.txtPackageAmountPaid.Text.Trim())), this.txtPackagePaymentTransaction.Text.Trim(), new DateTime?(Convert.ToDateTime(this.txtPackagePaymentDate.Text.Trim())), new DateTime?(Convert.ToDateTime(this.txtPackageAssignDate.Text.Trim())), this.chkStatus.Checked))
            {
              this.DisplayAlert("Update Successfully..");
              this.Response.Redirect("~/BillTransact/CompanyPackageDetails.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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
      this.Response.Redirect("~/BillTransact/CompanyPackageDetails.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfCompanyPackage.Value != null)
      {
        if (this.objCompanyPackageDetailsBll.DeleteCompanyPackage(int.Parse(this.hfCompanyPackage.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/BillTransact/CompanyPackageDetails.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/CompanyPackageDetails.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/CompanyPackageDetails.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
    }

    public void DisplayAlert(string message)
    {
      this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">" + this.GetAlertScript(message) + "</script>");
    }

    public string GetAlertScript(string message)
    {
      return "alert('" + message.Replace("'", "\\'") + "');";
    }

    protected void gvCompanyPackage_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType != DataControlRowType.DataRow)
        return;
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(e.Row.Cells[1].Text));
      if (this.objCompanyMasterDT.Rows.Count != 0)
        e.Row.Cells[1].Text = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
      this.objPackageMasterDT = this.objPackageMasterBll.GetDataByPackageID(int.Parse(e.Row.Cells[2].Text));
      if (this.objCompanyMasterDT.Rows.Count == 0)
        return;
      e.Row.Cells[2].Text = this.objPackageMasterDT.Rows[0]["PackageName"].ToString();
    }

    protected void btnUpgrade_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/UpgradeCompanyPackage.aspx?CompanyID=" + this.hfCompanyID.Value);
    }
  }
}

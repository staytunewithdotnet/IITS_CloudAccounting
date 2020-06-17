// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.PackageMaster
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
  public class PackageMaster : Page
  {
    private static string AddStatus = string.Empty;
    private static string EditStatus = string.Empty;
    private static string ViewStatus = string.Empty;
    private static string DeleteStatus = string.Empty;
    private readonly PackageMasterBLL objPackageMasterBll = new PackageMasterBLL();
    private CloudAccountDA.PackageMasterDataTable objPackageMasterDT = new CloudAccountDA.PackageMasterDataTable();
    private readonly CurrencyMasterBLL objCurrencyMasterBll = new CurrencyMasterBLL();
    private CloudAccountDA.CurrencyMasterDataTable objCurrencyMasterDT = new CloudAccountDA.CurrencyMasterDataTable();
    private readonly PackageDetailsBLL objPackageDetailsBll = new PackageDetailsBLL();
    private CloudAccountDA.PackageDetailsDataTable objPackageDetailsDT = new CloudAccountDA.PackageDetailsDataTable();
    private readonly MasterAdminRightsMasterBLL objMasterAdminRightsMasterBll = new MasterAdminRightsMasterBLL();
    private CloudAccountDA.MasterAdminRightsMasterDataTable objMasterAdminRightsMasterDT = new CloudAccountDA.MasterAdminRightsMasterDataTable();
    private readonly MasterAdminLoginMasterBLL objMasterAdminLoginMasterBll = new MasterAdminLoginMasterBLL();
    private CloudAccountDA.MasterAdminLoginMasterDataTable objMasterAdminLoginMasterDT = new CloudAccountDA.MasterAdminLoginMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyAdminRightsMasterBLL objCompanyAdminRightsMasterBll = new CompanyAdminRightsMasterBLL();
    private CloudAccountDA.CompanyAdminRightsMasterDataTable objCompanyAdminRightsMasterDT = new CloudAccountDA.CompanyAdminRightsMasterDataTable();
    private bool checkInDB;
    protected ToolkitScriptManager tsm;
    protected Panel pnlAdd;
    protected UpdatePanel upAdd;
    protected TextBox txtName;
    protected RequiredFieldValidator RequiredFieldValidator2;
    protected CheckBox chkTrial;
    protected HtmlGenericControl NoOfTrialDays;
    protected TextBox txtNoTrialDays;
    protected TextBox txtAdminUsersMin;
    protected TextBox txtAdminUsersMax;
    protected TextBox txtStaffUsersMin;
    protected TextBox txtStaffUsersMax;
    protected DropDownList ddlMonthCurrency;
    protected TextBox txtPricePerMonth;
    protected DropDownList ddlYearlyCurrency;
    protected TextBox txtPricePerYear;
    protected TextBox txtDescription;
    protected CheckBox chkStatus;
    protected GridView gvPackageDetails;
    protected Button btnSubmit;
    protected Button btnReset;
    protected Button btnUpdate;
    protected Button btnCancel;
    protected Button btnListAll;
    protected Panel pnlView;
    protected Label lblName;
    protected Label lblTrial;
    protected HtmlGenericControl NoOfTrialDaysView;
    protected Label lblNoTrialDays;
    protected Label lblAdminUsersMin;
    protected Label lblAdminUsersMax;
    protected Label lblStaffUsersMin;
    protected Label lblStaffUsersMax;
    protected Label lblMonthCurrency;
    protected Label lblPricePerMonth;
    protected Label lblYearlyCurrency;
    protected Label lblPricePerYear;
    protected Label lblDescription;
    protected Label lblStatus;
    protected GridView gvViewModule;
    protected Button btnEdit;
    protected Button btnDelete;
    protected Button btnList;
    protected Button btnAdd;
    protected Panel pnlViewAll;
    protected GridView gvPackage;
    protected Button btnAddPackage;
    protected ObjectDataSource objdsPackage;
    protected ObjectDataSource objdsModule;
    protected SqlDataSource sqldsCurrency;
    protected SqlDataSource sqldsModule;
    protected SqlDataSource sqldsViewPackage;
    protected HiddenField hfPackage;
    protected HiddenField hfMasterAdminID;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyLoginID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("packageManagement")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("package")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          PackageMaster.AddStatus = "True";
          PackageMaster.EditStatus = "True";
          PackageMaster.ViewStatus = "True";
          PackageMaster.DeleteStatus = "True";
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
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "PackageMaster");
          if (this.objMasterAdminRightsMasterDT.Rows.Count > 0)
          {
            PackageMaster.AddStatus = this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            PackageMaster.EditStatus = this.objMasterAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            PackageMaster.ViewStatus = this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            PackageMaster.DeleteStatus = this.objMasterAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            PackageMaster.AddStatus = "";
            PackageMaster.EditStatus = "";
            PackageMaster.ViewStatus = "";
            PackageMaster.DeleteStatus = "";
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
          this.objCompanyAdminRightsMasterDT = this.objCompanyAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfCompanyID.Value.Trim()), int.Parse(this.hfCompanyLoginID.Value.Trim()), "PackageMaster");
          if (this.objCompanyAdminRightsMasterDT.Rows.Count > 0)
          {
            PackageMaster.AddStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            PackageMaster.EditStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            PackageMaster.ViewStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            PackageMaster.DeleteStatus = this.objCompanyAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            PackageMaster.AddStatus = "";
            PackageMaster.EditStatus = "";
            PackageMaster.ViewStatus = "";
            PackageMaster.DeleteStatus = "";
          }
        }
        else
        {
          PackageMaster.AddStatus = "";
          PackageMaster.EditStatus = "";
          PackageMaster.ViewStatus = "";
          PackageMaster.DeleteStatus = "";
        }
      }
      if (PackageMaster.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] == null || !(PackageMaster.ViewStatus == "True"))
                break;
              string i = this.Request.QueryString["ID"];
              this.pnlViewAll.Visible = false;
              this.pnlAdd.Visible = false;
              this.pnlView.Visible = true;
              this.ViewRecord(i);
              this.btnEdit.Visible = PackageMaster.EditStatus == "True";
              this.btnAddPackage.Visible = this.btnAdd.Visible = PackageMaster.AddStatus == "True";
              this.btnDelete.Visible = PackageMaster.DeleteStatus == "True";
              this.btnListAll.Visible = true;
              this.btnUpdate.Visible = false;
              this.btnCancel.Visible = false;
              break;
            case "add":
              if (this.Request.QueryString["ID"] != null)
              {
                if (!(PackageMaster.EditStatus == "True"))
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
              if (!(PackageMaster.AddStatus == "True"))
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
          if (PackageMaster.AddStatus == "False")
            this.btnAddPackage.Visible = this.btnAdd.Visible = false;
          else
            this.btnAddPackage.Visible = this.btnAdd.Visible = true;
        }
      }
      else if (PackageMaster.AddStatus == "True" && PackageMaster.EditStatus == "False" && (PackageMaster.ViewStatus == "False" && PackageMaster.DeleteStatus == "False"))
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
      this.objPackageMasterDT = this.objPackageMasterBll.GetDataByPackageID(int.Parse(i));
      if (this.objPackageMasterDT.Rows.Count <= 0)
        return;
      this.hfPackage.Value = this.objPackageMasterDT.Rows[0]["PackageID"].ToString();
      this.lblName.Text = this.objPackageMasterDT.Rows[0]["PackageName"].ToString();
      this.lblAdminUsersMin.Text = this.objPackageMasterDT.Rows[0]["NoOfAdminUsersMin"].ToString();
      this.lblAdminUsersMax.Text = this.objPackageMasterDT.Rows[0]["NoOfAdminUsersMax"].ToString();
      this.lblStaffUsersMin.Text = this.objPackageMasterDT.Rows[0]["NoOfStaffUsersMin"].ToString();
      this.lblStaffUsersMax.Text = this.objPackageMasterDT.Rows[0]["NoOfStaffUsersMax"].ToString();
      this.lblPricePerMonth.Text = this.objPackageMasterDT.Rows[0]["PricePerMonth"].ToString();
      this.lblPricePerYear.Text = this.objPackageMasterDT.Rows[0]["PricePerYear"].ToString();
      this.lblDescription.Text = this.objPackageMasterDT.Rows[0]["Description"].ToString();
      this.lblNoTrialDays.Text = this.objPackageMasterDT.Rows[0]["NoOfTrialDays"].ToString();
      this.lblTrial.Text = this.objPackageMasterDT.Rows[0]["FreeTrialPackage"].ToString() == "True" ? "True" : "False";
      this.lblStatus.Text = this.objPackageMasterDT.Rows[0]["Status"].ToString() == "True" ? "True" : "False";
      this.NoOfTrialDaysView.Visible = bool.Parse(this.lblTrial.Text);
      this.lblMonthCurrency.Text = this.objPackageMasterDT.Rows[0]["MonthlyPriceCurrencyID"].ToString();
      this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(this.lblMonthCurrency.Text));
      this.lblMonthCurrency.Text = this.objCurrencyMasterDT.Rows[0]["CurrencyName"].ToString();
      this.lblYearlyCurrency.Text = this.objPackageMasterDT.Rows[0]["YearlyPriceCurrencyID"].ToString();
      this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(this.lblYearlyCurrency.Text));
      this.lblYearlyCurrency.Text = this.objCurrencyMasterDT.Rows[0]["CurrencyName"].ToString();
    }

    private void SetRecord(string iD)
    {
      this.objPackageMasterDT = this.objPackageMasterBll.GetDataByPackageID(int.Parse(iD));
      if (this.objPackageMasterDT.Rows.Count <= 0)
        return;
      this.hfPackage.Value = this.objPackageMasterDT.Rows[0]["PackageID"].ToString();
      this.chkTrial.Checked = this.objPackageMasterDT.Rows[0]["FreeTrialPackage"].ToString() == "True";
      this.chkTrial_CheckedChanged((object) null, (EventArgs) null);
      this.txtName.Text = this.objPackageMasterDT.Rows[0]["PackageName"].ToString();
      this.txtAdminUsersMin.Text = this.objPackageMasterDT.Rows[0]["NoOfAdminUsersMin"].ToString();
      this.txtAdminUsersMax.Text = this.objPackageMasterDT.Rows[0]["NoOfAdminUsersMax"].ToString();
      this.txtStaffUsersMin.Text = this.objPackageMasterDT.Rows[0]["NoOfStaffUsersMin"].ToString();
      this.txtStaffUsersMax.Text = this.objPackageMasterDT.Rows[0]["NoOfStaffUsersMax"].ToString();
      this.txtPricePerMonth.Text = this.objPackageMasterDT.Rows[0]["PricePerMonth"].ToString();
      this.txtPricePerYear.Text = this.objPackageMasterDT.Rows[0]["PricePerYear"].ToString();
      this.txtDescription.Text = this.objPackageMasterDT.Rows[0]["Description"].ToString();
      this.txtNoTrialDays.Text = this.objPackageMasterDT.Rows[0]["NoOfTrialDays"].ToString();
      this.chkStatus.Checked = this.objPackageMasterDT.Rows[0]["Status"].ToString() == "True";
      this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(this.objPackageMasterDT.Rows[0]["MonthlyPriceCurrencyID"].ToString()));
      if (this.objCurrencyMasterDT.Rows.Count > 0)
      {
        this.ddlMonthCurrency.Items.Add(this.objCurrencyMasterDT.Rows[0]["CurrencyID"].ToString());
        this.ddlMonthCurrency.SelectedValue = this.objCurrencyMasterDT.Rows[0]["CurrencyID"].ToString();
      }
      this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(this.objPackageMasterDT.Rows[0]["YearlyPriceCurrencyID"].ToString()));
      if (this.objCurrencyMasterDT.Rows.Count > 0)
      {
        this.ddlYearlyCurrency.Items.Add(this.objCurrencyMasterDT.Rows[0]["CurrencyID"].ToString());
        this.ddlYearlyCurrency.SelectedValue = this.objCurrencyMasterDT.Rows[0]["CurrencyID"].ToString();
      }
      this.objPackageDetailsDT = this.objPackageDetailsBll.GetDataByPackageID(int.Parse(this.hfPackage.Value));
      for (int index = 0; index < this.objPackageDetailsDT.Rows.Count; ++index)
      {
        Label label1 = (Label) this.gvPackageDetails.Rows[index].FindControl("lnkModuleID");
        Label label2 = (Label) this.gvPackageDetails.Rows[index].FindControl("lnkModuleName");
        CheckBox checkBox = (CheckBox) this.gvPackageDetails.Rows[index].FindControl("chkModuleStatus");
        string str1 = this.objPackageDetailsDT.Rows[index]["ModuleID"].ToString();
        string str2 = this.objPackageDetailsDT.Rows[index]["ModuleName"].ToString();
        bool flag = Convert.ToBoolean(this.objPackageDetailsDT.Rows[index]["ModuleStatus"].ToString());
        label1.Text = str1;
        label2.Text = str2;
        if (flag)
          checkBox.Checked = true;
      }
    }

    private void Clear()
    {
      this.txtDescription.Text = this.txtName.Text = (string) null;
      this.chkStatus.Checked = false;
      this.txtName.Focus();
    }

    private void BindGrid()
    {
      this.gvPackage.DataBind();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvPackage.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvPackage, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void gvPackage_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/PackageMaster.aspx?cmd=view&ID=" + this.gvPackage.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvPackage_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvPackage.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void btnAddPackage_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/PackageMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.txtName.Text.Trim().Length > 0)
      {
        this.objPackageMasterDT = this.objPackageMasterBll.GetDataByPackageName(this.txtName.Text);
        if (this.objPackageMasterDT.Rows.Count > 0)
        {
          this.DisplayAlert("Package Already Exist..");
          this.checkInDB = true;
        }
        else
          this.checkInDB = false;
        if (!this.checkInDB)
        {
          int? iNoOfTrialDays = new int?();
          if (this.txtNoTrialDays.Text.Trim().Length > 0)
            iNoOfTrialDays = new int?(int.Parse(this.txtNoTrialDays.Text.Trim()));
          int iPackageID = this.objPackageMasterBll.AddPackage("", this.txtName.Text.Trim(), this.chkTrial.Checked, int.Parse(this.txtAdminUsersMin.Text.Trim()), int.Parse(this.txtAdminUsersMax.Text.Trim()), int.Parse(this.txtStaffUsersMin.Text.Trim()), int.Parse(this.txtStaffUsersMax.Text.Trim()), new Decimal?(Decimal.Parse(this.txtPricePerMonth.Text.Trim())), int.Parse(this.ddlMonthCurrency.SelectedItem.Value), new Decimal?(Decimal.Parse(this.txtPricePerYear.Text.Trim())), int.Parse(this.ddlYearlyCurrency.SelectedItem.Value), this.txtDescription.Text.Trim(), iNoOfTrialDays, this.chkStatus.Checked);
          if (iPackageID != 0)
          {
            if (this.gvPackageDetails.Rows.Count > 0)
            {
              for (int index = 0; index < this.gvPackageDetails.Rows.Count; ++index)
              {
                CheckBox checkBox = (CheckBox) this.gvPackageDetails.Rows[index].FindControl("chkModuleStatus");
                Label label = (Label) this.gvPackageDetails.Rows[index].FindControl("lnkModuleID");
                this.objPackageDetailsBll.AddPackageDetails(iPackageID, int.Parse(label.Text), checkBox.Checked);
              }
            }
            this.DisplayAlert("Details Added Successfully.");
            this.Response.Redirect("~/Admin/PackageMaster.aspx?cmd=view&ID=" + (object) iPackageID);
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
          if (this.txtName.Text.Trim().Length > 0)
          {
            int? iNoOfTrialDays = new int?();
            if (this.txtNoTrialDays.Text.Trim().Length > 0)
              iNoOfTrialDays = new int?(int.Parse(this.txtNoTrialDays.Text.Trim()));
            bool flag = this.objPackageMasterBll.UpdatePackage(int.Parse(this.hfPackage.Value.Trim()), "", this.txtName.Text.Trim(), this.chkTrial.Checked, int.Parse(this.txtAdminUsersMin.Text.Trim()), int.Parse(this.txtAdminUsersMax.Text.Trim()), int.Parse(this.txtStaffUsersMin.Text.Trim()), int.Parse(this.txtStaffUsersMax.Text.Trim()), new Decimal?(Decimal.Parse(this.txtPricePerMonth.Text.Trim())), int.Parse(this.ddlMonthCurrency.SelectedItem.Value), new Decimal?(Decimal.Parse(this.txtPricePerYear.Text.Trim())), int.Parse(this.ddlYearlyCurrency.SelectedItem.Value), this.txtDescription.Text.Trim(), iNoOfTrialDays, this.chkStatus.Checked);
            this.objPackageDetailsBll.DeleteByPackageID(int.Parse(this.hfPackage.Value.Trim()));
            if (flag)
            {
              if (this.gvPackageDetails.Rows.Count > 0)
              {
                for (int index = 0; index < this.gvPackageDetails.Rows.Count; ++index)
                {
                  CheckBox checkBox = (CheckBox) this.gvPackageDetails.Rows[index].FindControl("chkModuleStatus");
                  this.objPackageDetailsBll.AddPackageDetails(int.Parse(this.hfPackage.Value.Trim()), int.Parse(((Label) this.gvPackageDetails.Rows[index].FindControl("lnkModuleID")).Text), checkBox.Checked);
                }
              }
              this.DisplayAlert("Update Successfully..");
              this.Response.Redirect("~/Admin/PackageMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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
      this.Response.Redirect("~/Admin/PackageMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfPackage.Value != null)
      {
        if (this.objPackageMasterBll.DeletePackage(int.Parse(this.hfPackage.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/Admin/PackageMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/PackageMaster.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/PackageMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
    }

    public void DisplayAlert(string message)
    {
      this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">" + this.GetAlertScript(message) + "</script>");
    }

    public string GetAlertScript(string message)
    {
      return "alert('" + message.Replace("'", "\\'") + "');";
    }

    protected void chkTrial_CheckedChanged(object sender, EventArgs e)
    {
      if (this.chkTrial.Checked)
      {
        this.NoOfTrialDays.Visible = true;
        this.txtPricePerMonth.Text = "0";
        this.txtPricePerYear.Text = "0";
        this.txtNoTrialDays.Focus();
      }
      else
      {
        this.NoOfTrialDays.Visible = false;
        this.txtPricePerMonth.Text = "";
        this.txtPricePerYear.Text = "";
        this.txtAdminUsersMin.Focus();
      }
    }
  }
}

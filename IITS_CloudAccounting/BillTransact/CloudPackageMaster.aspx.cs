// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.CloudPackageMaster
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
  public class CloudPackageMaster : Page
  {
    private static string AddStatus = string.Empty;
    private static string EditStatus = string.Empty;
    private static string ViewStatus = string.Empty;
    private static string DeleteStatus = string.Empty;
    private readonly CloudPackageMasterBLL objCloudPackageMasterBll = new CloudPackageMasterBLL();
    private CloudAccountDA.CloudPackageMasterDataTable objCloudPackageMasterDT = new CloudAccountDA.CloudPackageMasterDataTable();
    private readonly CurrencyMasterBLL objCurrencyMasterBll = new CurrencyMasterBLL();
    private CloudAccountDA.CurrencyMasterDataTable objCurrencyMasterDT = new CloudAccountDA.CurrencyMasterDataTable();
    private readonly CloudPackageDetailsBLL objCloudPackageDetailsBll = new CloudPackageDetailsBLL();
    private CloudAccountDA.CloudPackageDetailsDataTable objCloudPackageDetailsDT = new CloudAccountDA.CloudPackageDetailsDataTable();
    private readonly MasterAdminRightsMasterBLL objMasterAdminRightsMasterBll = new MasterAdminRightsMasterBLL();
    private CloudAccountDA.MasterAdminRightsMasterDataTable objMasterAdminRightsMasterDT = new CloudAccountDA.MasterAdminRightsMasterDataTable();
    private readonly MasterAdminLoginMasterBLL objMasterAdminLoginMasterBll = new MasterAdminLoginMasterBLL();
    private CloudAccountDA.MasterAdminLoginMasterDataTable objMasterAdminLoginMasterDT = new CloudAccountDA.MasterAdminLoginMasterDataTable();
    private bool checkInDB;
    protected ToolkitScriptManager tsm;
    protected Panel pnlAdd;
    protected TextBox txtName;
    protected RequiredFieldValidator RequiredFieldValidator2;
    protected DropDownList ddlMonthCurrency;
    protected TextBox txtPricePerMonth;
    protected TextBox txtPricePerYear;
    protected TextBox txtDescription;
    protected CheckBox chkStatus;
    protected UpdatePanel upModuleGrid;
    protected GridView gvAddModule;
    protected Button btnSubmit;
    protected Button btnReset;
    protected Button btnUpdate;
    protected Button btnCancel;
    protected Button btnListAll;
    protected Panel pnlView;
    protected Label lblName;
    protected Label lblMonthCurrency;
    protected Label lblPricePerMonth;
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
    protected SqlDataSource sqldsAddModule;
    protected SqlDataSource sqldsCurrency;
    protected SqlDataSource sqldsViewPackage;
    protected HiddenField hfPackage;
    protected HiddenField hfMasterAdminID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("packageManagement")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("cloudPackage")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          CloudPackageMaster.AddStatus = "True";
          CloudPackageMaster.EditStatus = "True";
          CloudPackageMaster.ViewStatus = "True";
          CloudPackageMaster.DeleteStatus = "True";
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
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "CloudPackageMaster");
          if (this.objMasterAdminRightsMasterDT.Rows.Count > 0)
          {
            CloudPackageMaster.AddStatus = this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString();
            CloudPackageMaster.EditStatus = this.objMasterAdminRightsMasterDT.Rows[0]["EditMode"].ToString();
            CloudPackageMaster.ViewStatus = this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString();
            CloudPackageMaster.DeleteStatus = this.objMasterAdminRightsMasterDT.Rows[0]["DeleteMode"].ToString();
          }
          else
          {
            CloudPackageMaster.AddStatus = "";
            CloudPackageMaster.EditStatus = "";
            CloudPackageMaster.ViewStatus = "";
            CloudPackageMaster.DeleteStatus = "";
          }
        }
        else
        {
          CloudPackageMaster.AddStatus = "";
          CloudPackageMaster.EditStatus = "";
          CloudPackageMaster.ViewStatus = "";
          CloudPackageMaster.DeleteStatus = "";
        }
      }
      if (CloudPackageMaster.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] != null && CloudPackageMaster.ViewStatus == "True")
              {
                string i = this.Request.QueryString["ID"];
                this.pnlViewAll.Visible = false;
                this.pnlAdd.Visible = false;
                this.pnlView.Visible = true;
                this.ViewRecord(i);
                this.btnEdit.Visible = CloudPackageMaster.EditStatus == "True";
                this.btnAddPackage.Visible = this.btnAdd.Visible = CloudPackageMaster.AddStatus == "True";
                this.btnDelete.Visible = CloudPackageMaster.DeleteStatus == "True";
                this.btnListAll.Visible = true;
                this.btnUpdate.Visible = false;
                this.btnCancel.Visible = false;
              }
              CloudPackageMaster.MergeRows(this.gvViewModule);
              break;
            case "add":
              if (this.Request.QueryString["ID"] != null)
              {
                if (CloudPackageMaster.EditStatus == "True")
                {
                  this.SetRecord(this.Request.QueryString["ID"]);
                  this.pnlAdd.Visible = true;
                  this.pnlViewAll.Visible = false;
                  this.pnlView.Visible = false;
                  this.btnUpdate.Visible = true;
                  this.btnCancel.Visible = true;
                  this.btnSubmit.Visible = false;
                  this.btnReset.Visible = false;
                  this.txtName.Focus();
                }
              }
              else if (CloudPackageMaster.AddStatus == "True")
              {
                this.Clear();
                this.btnSubmit.Visible = true;
                this.btnReset.Visible = true;
                this.btnUpdate.Visible = false;
                this.btnCancel.Visible = false;
                this.pnlAdd.Visible = true;
                this.pnlViewAll.Visible = false;
                this.pnlView.Visible = false;
              }
              CloudPackageMaster.MergeRows(this.gvAddModule);
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
          if (CloudPackageMaster.AddStatus == "False")
            this.btnAddPackage.Visible = this.btnAdd.Visible = false;
          else
            this.btnAddPackage.Visible = this.btnAdd.Visible = true;
        }
      }
      else if (CloudPackageMaster.AddStatus == "True" && CloudPackageMaster.EditStatus == "False" && (CloudPackageMaster.ViewStatus == "False" && CloudPackageMaster.DeleteStatus == "False"))
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
      this.objCloudPackageMasterDT = this.objCloudPackageMasterBll.GetDataByCloudPackageID(int.Parse(i));
      if (this.objCloudPackageMasterDT.Rows.Count <= 0)
        return;
      this.hfPackage.Value = this.objCloudPackageMasterDT.Rows[0]["CloudPackageID"].ToString();
      this.lblName.Text = this.objCloudPackageMasterDT.Rows[0]["CloudPackageName"].ToString();
      this.lblPricePerMonth.Text = this.objCloudPackageMasterDT.Rows[0]["CloudPackagePriceMonthly"].ToString();
      this.lblPricePerYear.Text = this.objCloudPackageMasterDT.Rows[0]["CloudPackagePriceYearly"].ToString();
      this.lblDescription.Text = this.objCloudPackageMasterDT.Rows[0]["CloudPackageDescription"].ToString();
      this.lblStatus.Text = this.objCloudPackageMasterDT.Rows[0]["CloudPackageStatus"].ToString() == "True" ? "True" : "False";
      this.lblMonthCurrency.Text = this.objCloudPackageMasterDT.Rows[0]["CloudPackageCurrency"].ToString();
      this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(this.lblMonthCurrency.Text));
      this.lblMonthCurrency.Text = this.objCurrencyMasterDT.Rows[0]["CurrencyName"].ToString();
            if(Convert.ToString(this.objCurrencyMasterDT.Rows[0]["CurrencySymbol"])=="")
            {
                if (this.lblPricePerMonth.Text == "")
                {
                    this.lblPricePerMonth.Text = "0.0";
                }
                this.lblPricePerMonth.Text = "0" + (object)" " + (string)(object)Decimal.Round(Decimal.Parse(this.lblPricePerMonth.Text), 2);
            }
            else
            {
                if(this.lblPricePerMonth.Text=="")
                {
                    this.lblPricePerMonth.Text = "0.0";
                }
                this.lblPricePerMonth.Text = (string)this.objCurrencyMasterDT.Rows[0]["CurrencySymbol"] + (object)" " + Convert.ToString(Decimal.Round(Decimal.Parse(this.lblPricePerMonth.Text), 2));
            }
        }

    private void SetRecord(string iD)
    {
      this.objCloudPackageMasterDT = this.objCloudPackageMasterBll.GetDataByCloudPackageID(int.Parse(iD));
      if (this.objCloudPackageMasterDT.Rows.Count <= 0)
        return;
      this.hfPackage.Value = this.objCloudPackageMasterDT.Rows[0]["CloudPackageID"].ToString();
      this.txtName.Text = this.objCloudPackageMasterDT.Rows[0]["CloudPackageName"].ToString();
      this.txtPricePerMonth.Text = this.objCloudPackageMasterDT.Rows[0]["CloudPackagePriceMonthly"].ToString();
      this.txtPricePerYear.Text = this.objCloudPackageMasterDT.Rows[0]["CloudPackagePriceYearly"].ToString();
      this.txtDescription.Text = this.objCloudPackageMasterDT.Rows[0]["CloudPackageDescription"].ToString();
      this.chkStatus.Checked = this.objCloudPackageMasterDT.Rows[0]["CloudPackageStatus"].ToString() == "True";
      this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(this.objCloudPackageMasterDT.Rows[0]["CloudPackageCurrency"].ToString()));
      if (this.objCurrencyMasterDT.Rows.Count > 0)
      {
        this.ddlMonthCurrency.Items.Add(this.objCurrencyMasterDT.Rows[0]["CurrencyID"].ToString());
        this.ddlMonthCurrency.SelectedValue = this.objCurrencyMasterDT.Rows[0]["CurrencyID"].ToString();
      }
      this.objCloudPackageDetailsDT = this.objCloudPackageDetailsBll.GetDataByCloudPackageID(int.Parse(this.hfPackage.Value));
      for (int index = 0; index < this.objCloudPackageDetailsDT.Rows.Count; ++index)
      {
        RadioButtonList radioButtonList = (RadioButtonList) this.gvAddModule.Rows[index].FindControl("rblInput");
        string str = this.objCloudPackageDetailsDT.Rows[index]["CloudPackageDetailValue"].ToString();
        if (str == "True" || str == "False")
        {
          radioButtonList.SelectedValue = "2";
          this.rblInput_SelectedIndexChanged((object) radioButtonList, (EventArgs) null);
          CheckBox checkBox = (CheckBox) this.gvAddModule.Rows[index].FindControl("chkValue");
          checkBox.Visible = true;
          checkBox.Checked = bool.Parse(str);
        }
        else
        {
          radioButtonList.SelectedValue = "1";
          this.rblInput_SelectedIndexChanged((object) radioButtonList, (EventArgs) null);
          TextBox textBox = (TextBox) this.gvAddModule.Rows[index].FindControl("txtValue");
          textBox.Visible = true;
          textBox.Text = str;
        }
      }
    }

    private void Clear()
    {
      this.txtDescription.Text = this.txtName.Text = (string) null;
      this.txtPricePerMonth.Text = "0.00";
      this.txtPricePerYear.Text = "0.00";
      this.ddlMonthCurrency.SelectedIndex = 0;
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
      this.Response.Redirect("~/Admin/CloudPackageMaster.aspx?cmd=view&ID=" + this.gvPackage.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvPackage_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvPackage.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void btnAddPackage_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/CloudPackageMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.txtName.Text.Trim().Length > 0)
      {
        this.objCloudPackageMasterDT = this.objCloudPackageMasterBll.GetDataByCloudPackageName(this.txtName.Text);
        if (this.objCloudPackageMasterDT.Rows.Count > 0)
        {
          this.DisplayAlert("Package Already Exist..");
          this.checkInDB = true;
        }
        else
          this.checkInDB = false;
        if (!this.checkInDB)
        {
          int iCloudPackageID = this.objCloudPackageMasterBll.AddCloudPackage("", this.txtName.Text.Trim(), new Decimal?(Decimal.Parse(this.txtPricePerMonth.Text.Trim())), new Decimal?(Decimal.Parse(this.txtPricePerYear.Text.Trim())), int.Parse(this.ddlMonthCurrency.SelectedItem.Value), this.txtDescription.Text.Trim(), this.chkStatus.Checked);
          if (iCloudPackageID != 0)
          {
            if (this.gvAddModule.Rows.Count > 0)
            {
              for (int index = 0; index < this.gvAddModule.Rows.Count; ++index)
              {
                Label label1 = (Label) this.gvAddModule.Rows[index].FindControl("lblPackageFeatureID");
                Label label2 = (Label) this.gvAddModule.Rows[index].FindControl("lblPackageModuleID");
                string sCloudPackageDetailValue = !(((ListControl) this.gvAddModule.Rows[index].FindControl("rblInput")).SelectedItem.Value == "1") ? ((CheckBox) this.gvAddModule.Rows[index].FindControl("chkValue")).Checked.ToString() : ((TextBox) this.gvAddModule.Rows[index].FindControl("txtValue")).Text.Trim();
                this.objCloudPackageDetailsBll.AddCloudPackageDetails(iCloudPackageID, int.Parse(label2.Text), int.Parse(label1.Text), sCloudPackageDetailValue);
              }
            }
            this.DisplayAlert("Details Added Successfully.");
            this.Response.Redirect("~/Admin/CloudPackageMaster.aspx?cmd=view&ID=" + (object) iCloudPackageID);
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
            bool flag = this.objCloudPackageMasterBll.UpdateCloudPackage(int.Parse(this.hfPackage.Value.Trim()), "", this.txtName.Text.Trim(), new Decimal?(Decimal.Parse(this.txtPricePerMonth.Text.Trim())), new Decimal?(Decimal.Parse(this.txtPricePerYear.Text.Trim())), int.Parse(this.ddlMonthCurrency.SelectedItem.Value), this.txtDescription.Text.Trim(), this.chkStatus.Checked);
            this.objCloudPackageDetailsBll.DeleteByCloudPackage(int.Parse(this.hfPackage.Value.Trim()));
            if (flag)
            {
              if (this.gvAddModule.Rows.Count > 0)
              {
                for (int index = 0; index < this.gvAddModule.Rows.Count; ++index)
                {
                  Label label1 = (Label) this.gvAddModule.Rows[index].FindControl("lblPackageFeatureID");
                  Label label2 = (Label) this.gvAddModule.Rows[index].FindControl("lblPackageModuleID");
                  string sCloudPackageDetailValue = !(((ListControl) this.gvAddModule.Rows[index].FindControl("rblInput")).SelectedItem.Value == "1") ? ((CheckBox) this.gvAddModule.Rows[index].FindControl("chkValue")).Checked.ToString() : ((TextBox) this.gvAddModule.Rows[index].FindControl("txtValue")).Text.Trim();
                  this.objCloudPackageDetailsBll.AddCloudPackageDetails(int.Parse(this.hfPackage.Value.Trim()), int.Parse(label2.Text), int.Parse(label1.Text), sCloudPackageDetailValue);
                }
              }
              this.DisplayAlert("Update Successfully..");
              this.Response.Redirect("~/Admin/CloudPackageMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
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
      this.Response.Redirect("~/Admin/CloudPackageMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfPackage.Value != null)
      {
        if (this.objCloudPackageMasterBll.DeleteCloudPackage(int.Parse(this.hfPackage.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/Admin/CloudPackageMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/CloudPackageMaster.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/CloudPackageMaster.aspx?cmd=view&ID=" + this.Request.QueryString["ID"]);
    }

    public void DisplayAlert(string message)
    {
      this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">" + this.GetAlertScript(message) + "</script>");
    }

    public string GetAlertScript(string message)
    {
      return "alert('" + message.Replace("'", "\\'") + "');";
    }

    public static void MergeRows(GridView gridView)
    {
      for (int index = gridView.Rows.Count - 2; index >= 0; --index)
      {
        GridViewRow gridViewRow1 = gridView.Rows[index];
        GridViewRow gridViewRow2 = gridView.Rows[index + 1];
        if (gridViewRow1.Cells[1].Text == gridViewRow2.Cells[1].Text)
        {
          gridViewRow1.Cells[1].RowSpan = gridViewRow2.Cells[1].RowSpan < 2 ? 2 : gridViewRow2.Cells[1].RowSpan + 1;
          gridViewRow2.Cells[1].Visible = false;
        }
      }
    }

    protected void rblInput_SelectedIndexChanged(object sender, EventArgs e)
    {
      RadioButtonList radioButtonList = (RadioButtonList) sender;
      GridViewRow gridViewRow = (GridViewRow) radioButtonList.Parent.Parent;
      TextBox textBox = (TextBox) gridViewRow.Cells[3].FindControl("txtValue");
      CheckBox checkBox = (CheckBox) gridViewRow.Cells[3].FindControl("chkValue");
      textBox.Visible = radioButtonList.SelectedItem.Value == "1";
      checkBox.Visible = radioButtonList.SelectedItem.Value == "2";
    }

    protected void gvPackage_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType != DataControlRowType.DataRow)
        return;
      this.objCurrencyMasterDT = this.objCurrencyMasterBll.GetDataByCurrencyID(int.Parse(e.Row.Cells[2].Text));
      if (this.objCurrencyMasterDT.Rows.Count <= 0)
        return;
      e.Row.Cells[2].Text = string.Concat(new object[4]
      {
        this.objCurrencyMasterDT.Rows[0]["CurrencyName"],
        (object) " (",
        this.objCurrencyMasterDT.Rows[0]["CurrencySymbol"],
        (object) ")"
      });
    }
  }
}

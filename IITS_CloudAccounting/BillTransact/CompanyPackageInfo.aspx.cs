// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.CompanyPackageInfo
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
  public class CompanyPackageInfo : Page
  {
    private static string ViewStatus = string.Empty;
    private static string AddStatus = string.Empty;
    private readonly MasterAdminRightsMasterBLL objMasterAdminRightsMasterBll = new MasterAdminRightsMasterBLL();
    private CloudAccountDA.MasterAdminRightsMasterDataTable objMasterAdminRightsMasterDT = new CloudAccountDA.MasterAdminRightsMasterDataTable();
    private readonly MasterAdminLoginMasterBLL objMasterAdminLoginMasterBll = new MasterAdminLoginMasterBLL();
    private CloudAccountDA.MasterAdminLoginMasterDataTable objMasterAdminLoginMasterDT = new CloudAccountDA.MasterAdminLoginMasterDataTable();
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
    private readonly CloudPackageMasterBLL objCloudPackageMasterBll = new CloudPackageMasterBLL();
    private CloudAccountDA.CloudPackageMasterDataTable objCloudPackageMasterDT = new CloudAccountDA.CloudPackageMasterDataTable();
    private readonly CompanyPackageMasterBLL objCompanyPackageMasterBll = new CompanyPackageMasterBLL();
    protected ToolkitScriptManager tsm;
    protected Panel pnlAdd;
    protected DropDownList ddlCompany;
    protected SqlDataSource sqldsCompany;
    protected UpdatePanel upPayment;
    protected DropDownList ddlPackage;
    protected SqlDataSource sqldsCloudPackage;
    protected RadioButtonList rblType;
    protected Label lblPriceMonth;
    protected Label lblPriceYear;
    protected Button btnSubmit;
    protected Button btnCancel;
    protected Panel pnlView;
    protected DataList dlCompanyPackage;
    protected ObjectDataSource objdsCompanyPackage;
    protected Button btnUpgrade;
    protected Button btnList;
    protected Panel pnlViewAll;
    protected GridView gvCompanyPackageFree;
    protected SqlDataSource sqldsCompanyPackageFree;
    protected GridView gvCompanyPackage;
    protected SqlDataSource sqldsCompanyPackage;
    protected HiddenField hfCompanyAdmin;
    protected HiddenField hfCompanyID;
    protected HiddenField hfUserName;
    protected HiddenField hfMasterAdminID;
    protected HiddenField hfCompanyLoginID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("companyManagement")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("companyPackageInfo")).Attributes.Add("class", "active open");
      if (this.IsPostBack)
        return;
      if (Admin.RoleName != null)
      {
        MembershipUser user = Membership.GetUser();
        if (Admin.RoleName == "SuperAdmin")
        {
          CompanyPackageInfo.ViewStatus = "True";
          CompanyPackageInfo.AddStatus = "True";
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
          this.objMasterAdminRightsMasterDT = this.objMasterAdminRightsMasterBll.GetDataByViewPageRights(int.Parse(this.hfMasterAdminID.Value.Trim()), "CompanyPackageInfo");
          CompanyPackageInfo.ViewStatus = this.objMasterAdminRightsMasterDT.Rows.Count > 0 ? this.objMasterAdminRightsMasterDT.Rows[0]["ViewMode"].ToString() : "";
          CompanyPackageInfo.AddStatus = this.objMasterAdminRightsMasterDT.Rows.Count > 0 ? this.objMasterAdminRightsMasterDT.Rows[0]["AddMode"].ToString() : "";
        }
        else
        {
          CompanyPackageInfo.ViewStatus = "";
          CompanyPackageInfo.AddStatus = "";
        }
      }
      if (CompanyPackageInfo.ViewStatus == "True")
      {
        if (this.Request.QueryString["cmd"] != null)
        {
          switch (this.Request.QueryString["cmd"])
          {
            case "view":
              if (this.Request.QueryString["ID"] == null || !(CompanyPackageInfo.ViewStatus == "True"))
                break;
              this.hfCompanyID.Value = this.Request.QueryString["ID"];
              this.pnlAdd.Visible = false;
              this.pnlViewAll.Visible = false;
              this.pnlView.Visible = true;
              this.btnList.Visible = true;
              this.dlCompanyPackage.DataBind();
              break;
            case "add":
              if (this.Request.QueryString["ID"] == null || !(CompanyPackageInfo.AddStatus == "True"))
                break;
              this.hfCompanyID.Value = this.Request.QueryString["ID"];
              this.pnlViewAll.Visible = false;
              this.pnlView.Visible = false;
              this.pnlAdd.Visible = true;
              this.ddlCompany.SelectedValue = this.hfCompanyID.Value;
              if (string.IsNullOrEmpty(this.ddlCompany.SelectedValue))
                this.Response.Redirect("CompanyPackageInfo.aspx");
              this.ddlPackage.Focus();
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
        }
      }
      else
      {
        this.pnlViewAll.Visible = false;
        this.pnlView.Visible = false;
        this.pnlAdd.Visible = false;
      }
    }

    private void BindGrid()
    {
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
      foreach (GridViewRow gridViewRow in this.gvCompanyPackageFree.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvCompanyPackageFree, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void gvCompanyPackage_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/CompanyPackageInfo.aspx?cmd=view&ID=" + this.gvCompanyPackage.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvCompanyPackage_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvCompanyPackage.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void gvCompanyPackageFree_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/CompanyPackageInfo.aspx?cmd=view&ID=" + this.gvCompanyPackageFree.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvCompanyPackageFree_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvCompanyPackageFree.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void btnListAll_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/CompanyPackageInfo.aspx");
    }

    public void DisplayAlert(string message)
    {
      this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">" + this.GetAlertScript(message) + "</script>");
    }

    public string GetAlertScript(string message)
    {
      return "alert('" + message.Replace("'", "\\'") + "');";
    }

    protected void gvCompanyPackage_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType != DataControlRowType.DataRow)
        return;
      this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(e.Row.Cells[1].Text));
      e.Row.Cells[1].Text = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
      this.objCloudPackageMasterDT = this.objCloudPackageMasterBll.GetDataByCloudPackageID(int.Parse(e.Row.Cells[2].Text));
      e.Row.Cells[2].Text = this.objCloudPackageMasterDT.Rows.Count > 0 ? this.objCloudPackageMasterDT.Rows[0]["CloudPackageName"].ToString() : "FREE";
    }

    protected string GetPackageName(string pId)
    {
      this.objCloudPackageMasterDT = this.objCloudPackageMasterBll.GetDataByCloudPackageID(int.Parse(pId));
      if (this.objCloudPackageMasterDT.Rows.Count > 0)
        return this.objCloudPackageMasterDT.Rows[0]["CloudPackageName"].ToString();
      return "FREE";
    }

    protected void rblType_SelectedIndexChanged(object sender, EventArgs e)
    {
      switch (this.rblType.SelectedItem.Text)
      {
        case "Monthly":
          this.lblPriceMonth.Visible = true;
          this.lblPriceYear.Visible = false;
          break;
        case "Yearly":
          this.lblPriceMonth.Visible = false;
          this.lblPriceYear.Visible = true;
          break;
      }
    }

    protected void ddlPackage_OnSelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.ddlPackage.SelectedIndex <= 0)
        return;
      this.objCloudPackageMasterDT = this.objCloudPackageMasterBll.GetDataByCloudPackageID(int.Parse(this.ddlPackage.SelectedItem.Value));
      if (this.objCloudPackageMasterDT.Rows.Count <= 0)
        return;
      this.lblPriceMonth.Text = this.objCloudPackageMasterDT.Rows[0]["CloudPackagePriceMonthly"].ToString();
      this.lblPriceYear.Text = this.objCloudPackageMasterDT.Rows[0]["CloudPackagePriceYearly"].ToString();
    }

    protected void btnUpgrade_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("CompanyPackageInfo.aspx?cmd=add&ID=" + this.hfCompanyID.Value);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("CompanyPackageInfo.aspx?cmd=view&ID=" + this.hfCompanyID.Value);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (this.ddlCompany.SelectedIndex > 0 && this.ddlPackage.SelectedIndex > 0)
      {
        string s = this.rblType.SelectedItem.Text == "Yearly" ? this.lblPriceYear.Text : this.lblPriceMonth.Text;
        int num = this.rblType.SelectedItem.Text == "Yearly" ? 365 : 30;
        string sPackageType = this.rblType.SelectedItem.Text == "Yearly" ? "Yearly" : "Monthly";
        this.objCompanyPackageMasterBll.UpdateCompanyPackages(int.Parse(this.hfCompanyID.Value));
        this.objCompanyPackageMasterBll.AddCompanyPackage(int.Parse(this.hfCompanyID.Value), int.Parse(this.ddlPackage.SelectedItem.Value), new DateTime?(DateTime.Now), new DateTime?(DateTime.Now.AddDays((double)num)), sPackageType, new Decimal?(Decimal.Parse(s)), "Upgrade by Bill Transact Support", new DateTime?(DateTime.Now), new DateTime?(DateTime.Now), true);
        this.Response.Redirect("CompanyPackageInfo.aspx?cmd=view&ID=" + this.hfCompanyID.Value);
      }
      else
        this.DisplayAlert("Please select new package to upgrade.");
    }
  }
}

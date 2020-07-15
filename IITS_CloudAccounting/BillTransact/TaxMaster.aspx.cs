// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.TaxMaster
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
  public class TaxMaster : Page
  {
    private readonly TaxMasterBLL objTaxMasterBll = new TaxMasterBLL();
    private CloudAccountDA.TaxMasterDataTable objTaxMasterDT = new CloudAccountDA.TaxMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly MiscellaneousMasterBLL objMiscellaneousMasterBll = new MiscellaneousMasterBLL();
    private CloudAccountDA.MiscellaneousMasterDataTable objMiscellaneousMasterDT = new CloudAccountDA.MiscellaneousMasterDataTable();
    private int linePerPage = 15;
    private bool checkInDB;
    protected HtmlGenericControl divSave;
    protected HtmlGenericControl divUpdate;
    protected Panel pnlAdd;
    protected TextBox txtTaxName;
    protected RequiredFieldValidator rfvTaxName;
    protected TextBox txtTaxRate;
    protected TextBox txtTaxNumber;
    protected Button btnSubmit;
    protected Button btnUpdate;
    protected Button btnSaveAdd;
    protected Panel pnlView;
    protected Label lblTaxName;
    protected Label lblTaxRate;
    protected Label lblTaxNumber;
    protected Panel pnlViewAll;
    protected Button btnAdd;
    protected GridView gvTax;
    protected ObjectDataSource objdsTax;
    protected HiddenField hfCompanyID;
    protected HiddenField hfTaxID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("setting")).Attributes.Add("style", "background-color: lightgray;");
      ((HtmlControl) this.Master.FindControl("taxes")).Attributes.Add("class", "active open");
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
        this.SetMiscValues(this.hfCompanyID.Value);
      }
      if (this.IsPostBack)
        return;
      this.divSave.Visible = this.Session["saveTax"] != null;
      this.divUpdate.Visible = this.Session["updateTax"] != null;
      this.Session.Abandon();
      if (this.Request.QueryString["cmd"] != null)
      {
        switch (this.Request.QueryString["cmd"])
        {
          case "view":
            if (this.Request.QueryString["ID"] == null)
              break;
            string iD = this.Request.QueryString["ID"];
            this.pnlView.Visible = true;
            this.pnlViewAll.Visible = false;
            this.pnlAdd.Visible = false;
            this.ViewRecord(iD);
            break;
          case "add":
            if (this.Request.QueryString["ID"] != null)
            {
              this.SetRecord(this.Request.QueryString["ID"]);
              this.pnlAdd.Visible = true;
              this.pnlView.Visible = false;
              this.pnlViewAll.Visible = false;
              this.btnSubmit.Visible = false;
              this.btnUpdate.Visible = true;
              this.btnSaveAdd.Visible = false;
              this.txtTaxName.Focus();
              break;
            }
            this.Clear();
            this.txtTaxName.Focus();
            this.pnlViewAll.Visible = false;
            this.pnlAdd.Visible = true;
            this.pnlView.Visible = false;
            this.btnUpdate.Visible = false;
            this.btnSubmit.Visible = true;
            this.btnSaveAdd.Visible = true;
            break;
          default:
            this.pnlViewAll.Visible = true;
            this.pnlAdd.Visible = false;
            this.pnlView.Visible = false;
            this.BindGrid();
            break;
        }
      }
      else
      {
        this.pnlViewAll.Visible = true;
        this.pnlAdd.Visible = false;
        this.pnlView.Visible = false;
        this.BindGrid();
      }
    }

    private void SetMiscValues(string companyID)
    {
      this.objMiscellaneousMasterDT = this.objMiscellaneousMasterBll.GetDataByCompanyID(int.Parse(companyID));
      if (this.objMiscellaneousMasterDT.Rows.Count <= 0)
        return;
      this.linePerPage = int.Parse(this.objMiscellaneousMasterDT.Rows[0]["LinesPerPage"].ToString());
      this.gvTax.PageSize = this.linePerPage;
    }

    protected void gvTax_Sorting(object sender, GridViewSortEventArgs e)
    {
      this.BindGrid();
    }

    private void Clear()
    {
      this.txtTaxName.Text = this.txtTaxNumber.Text = this.txtTaxRate.Text = "";
      this.txtTaxName.Focus();
    }

    private void ViewRecord(string iD)
    {
      this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(iD));
      if (this.objTaxMasterDT.Rows.Count <= 0)
        return;
      this.hfTaxID.Value = this.objTaxMasterDT.Rows[0]["TaxID"].ToString();
      this.hfCompanyID.Value = this.objTaxMasterDT.Rows[0]["CompanyID"].ToString();
      this.lblTaxName.Text = this.objTaxMasterDT.Rows[0]["TaxName"].ToString();
      this.lblTaxNumber.Text = this.objTaxMasterDT.Rows[0]["TaxNumber"].ToString();
      this.lblTaxRate.Text = this.objTaxMasterDT.Rows[0]["TaxRate"].ToString();
    }

    private void SetRecord(string iD)
    {
      this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(iD));
      if (this.objTaxMasterDT.Rows.Count <= 0)
        return;
      this.hfTaxID.Value = this.objTaxMasterDT.Rows[0]["TaxID"].ToString();
      this.hfCompanyID.Value = this.objTaxMasterDT.Rows[0]["CompanyID"].ToString();
      this.txtTaxName.Text = this.objTaxMasterDT.Rows[0]["TaxName"].ToString();
      this.txtTaxNumber.Text = this.objTaxMasterDT.Rows[0]["TaxNumber"].ToString();
      this.txtTaxRate.Text = this.objTaxMasterDT.Rows[0]["TaxRate"].ToString();
    }

    private void BindGrid()
    {
      this.gvTax.DataBind();
    }

    protected void gvTax_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/TaxMaster.aspx?cmd=add&ID=" + this.gvTax.SelectedRow.Cells[0].Text);
      this.BindGrid();
    }

    protected void gvTax_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvTax.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected override void Render(HtmlTextWriter writer)
    {
      foreach (GridViewRow gridViewRow in this.gvTax.Rows)
      {
        if (gridViewRow.RowType == DataControlRowType.DataRow)
        {
          gridViewRow.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.backgroundColor='#D5D7B2'";
          if (gridViewRow.RowIndex % 2 == 0)
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          else
            gridViewRow.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='#fff'";
          gridViewRow.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink((Control) this.gvTax, "Select$" + (object) gridViewRow.RowIndex, true);
        }
      }
      base.Render(writer);
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/Admin/TaxMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.txtTaxName.Text.Trim().Length > 0)
      {
        this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxName(int.Parse(this.hfCompanyID.Value), this.txtTaxName.Text.Trim());
        if (this.objTaxMasterDT.Rows.Count > 0)
        {
          this.checkInDB = true;
          this.DisplayAlert("Tax Already Exists..!");
        }
        if (this.checkInDB)
          return;
        Decimal? dTaxRate = new Decimal?();
        if (this.txtTaxRate.Text.Trim().Length > 0)
          dTaxRate = new Decimal?(Decimal.Parse(this.txtTaxRate.Text.Trim()));
        int num = this.objTaxMasterBll.AddTax(int.Parse(this.hfCompanyID.Value), this.txtTaxName.Text.Trim(), dTaxRate, this.txtTaxNumber.Text.Trim());
        if (num != 0)
        {
          this.Session["saveTax"] = (object) 1;
          this.DisplayAlert("Details Added Successfully.");
          this.Response.Redirect("~/Admin/TaxMaster.aspx?cmd=add&ID=" + (object) num);
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

    protected void btnSaveAdd_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.txtTaxName.Text.Trim().Length > 0)
      {
        this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxName(int.Parse(this.hfCompanyID.Value), this.txtTaxName.Text.Trim());
        if (this.objTaxMasterDT.Rows.Count > 0)
        {
          this.checkInDB = true;
          this.DisplayAlert("Tax Already Exists..!");
        }
        if (this.checkInDB)
          return;
        Decimal? dTaxRate = new Decimal?();
        if (this.txtTaxRate.Text.Trim().Length > 0)
          dTaxRate = new Decimal?(Decimal.Parse(this.txtTaxRate.Text.Trim()));
        if (this.objTaxMasterBll.AddTax(int.Parse(this.hfCompanyID.Value), this.txtTaxName.Text.Trim(), dTaxRate, this.txtTaxNumber.Text.Trim()) != 0)
        {
          this.Session["saveTax"] = (object) 1;
          this.DisplayAlert("Details Added Successfully.");
          this.btnAdd_Click(sender, e);
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

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
      try
      {
        if (!this.Page.IsValid)
          return;
        if (this.txtTaxName.Text.Trim().Length > 0)
        {
          Decimal? dTaxRate = new Decimal?();
          if (this.txtTaxRate.Text.Trim().Length > 0)
            dTaxRate = new Decimal?(Decimal.Parse(this.txtTaxRate.Text.Trim()));
          if (this.objTaxMasterBll.UpdateTax(int.Parse(this.hfTaxID.Value), int.Parse(this.hfCompanyID.Value), this.txtTaxName.Text.Trim(), dTaxRate, this.txtTaxNumber.Text.Trim()))
          {
            this.Session["updateTax"] = (object) 1;
            this.DisplayAlert("Update Successfully..");
            this.Response.Redirect("~/Admin/TaxMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
          }
          else
            this.DisplayAlert("Fail to Update Details.");
        }
        else
          this.DisplayAlert("Please Fill All Details.");
      }
      catch (Exception ex)
      {
        this.DisplayAlert(ex.Message);
      }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      if (this.hfTaxID.Value != null)
      {
        if (this.objTaxMasterBll.DeleteTax(int.Parse(this.hfTaxID.Value)))
        {
          this.DisplayAlert("Details has been Deleted");
          this.Response.Redirect("~/Admin/TaxMaster.aspx");
        }
        else
          this.DisplayAlert("Error In Deleting Detail");
      }
      else
        this.DisplayAlert("Error In Deleting Detail");
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

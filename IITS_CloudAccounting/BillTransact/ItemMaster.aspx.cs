// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.ItemMaster
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class ItemMaster : Page
  {
    private readonly ItemMasterBLL objItemMasterBll = new ItemMasterBLL();
    private CloudAccountDA.ItemMasterDataTable objItemMasterDT = new CloudAccountDA.ItemMasterDataTable();
    private readonly TaxMasterBLL objTaxMasterBll = new TaxMasterBLL();
    private CloudAccountDA.TaxMasterDataTable objTaxMasterDT = new CloudAccountDA.TaxMasterDataTable();
    private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
    private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly MiscellaneousMasterBLL objMiscellaneousMasterBll = new MiscellaneousMasterBLL();
    private CloudAccountDA.MiscellaneousMasterDataTable objMiscellaneousMasterDT = new CloudAccountDA.MiscellaneousMasterDataTable();
    private int linePerPage = 15;
    private bool checkInDB;
    protected ToolkitScriptManager tsm;
    protected HtmlGenericControl divSave;
    protected HtmlGenericControl divUpdate;
    protected Panel pnlAdd;
    protected TextBox txtItemName;
    protected RequiredFieldValidator rfvItemName;
    protected TextBox txtItemDesc;
    protected TextBox txtUnitCost;
    protected TextBox txtQuantity;
    protected DropDownList ddlTax;
    protected SqlDataSource sqldsTax;
    protected DropDownList ddlTax2;
    protected UpdatePanel upChk;
    protected CheckBox chkInventory;
    protected UpdatePanel upInventory;
    protected HtmlGenericControl stock;
    protected TextBox txtCurrentStock;
    protected Button btnSubmit;
    protected Button btnUpdate;
    protected Button btnSaveAdd;
    protected Panel pnlView;
    protected Label lblItemName;
    protected Label lblItemDesc;
    protected Label lblUnitCost;
    protected Label lblQuantity;
    protected Label lblTax;
    protected Label lblTax2;
    protected Label lblInventory;
    protected HtmlGenericControl stockEdit;
    protected Label lblCurrentStock;
    protected Panel pnlViewAll;
    protected Label lblHeader;
    protected Button btnAdd;
    protected TextBox txtItemNameSearch;
    protected TextBox txtItemDescSearch;
    protected DropDownList ddlTaxSearch;
    protected SqlDataSource sqldsTaxSearch;
    protected TextBox txtUnitCostFrom;
    protected TextBox txtUnitCostTo;
    protected TextBox txtInventoryFrom;
    protected TextBox txtInventoryTo;
    protected TextBox txtQuantityFrom;
    protected TextBox txtQuantityTo;
    protected Button btnSearch;
    protected Button btnReset;
    protected Button btnUnDelete;
    protected Button btnArchived;
    protected Button btnUnArchived;
    protected Button btnDelete;
    protected GridView gvItem;
    protected HtmlAnchor activeTag;
    protected HtmlAnchor archivedTag;
    protected HtmlAnchor deletedTag;
    protected ObjectDataSource objdsItem;
    protected HiddenField hfCompanyID;
    protected HiddenField hfItemID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("invoice")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("item")).Attributes.Add("class", "active open");
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
        else if (Roles.IsUserInRole(str, "Employee"))
        {
          this.objStaffMasterDT = this.objStaffMasterBll.GetDataByStaffUserName(str);
          if (this.objStaffMasterDT.Rows.Count > 0)
            this.hfCompanyID.Value = this.objStaffMasterDT.Rows[0]["CompanyID"].ToString();
        }
        this.SetMiscValues(this.hfCompanyID.Value);
      }
      if (this.IsPostBack)
        return;
      this.divSave.Visible = this.Session["saveItem"] != null;
      this.divUpdate.Visible = this.Session["updateItem"] != null;
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
              this.txtItemName.Focus();
              break;
            }
            this.Clear();
            this.txtItemName.Focus();
            this.pnlViewAll.Visible = false;
            this.pnlAdd.Visible = true;
            this.pnlView.Visible = false;
            this.btnUpdate.Visible = false;
            this.btnSubmit.Visible = true;
            this.btnSaveAdd.Visible = true;
            break;
          default:
            this.btnArchived.Visible = !this.CheckARQuery();
            this.btnUnArchived.Visible = this.CheckARQuery();
            this.btnDelete.Visible = !this.CheckDEQuery();
            this.btnUnDelete.Visible = this.CheckDEQuery();
            this.ATagStyle();
            this.pnlViewAll.Visible = true;
            this.pnlAdd.Visible = false;
            this.pnlView.Visible = false;
            this.BindGrid();
            break;
        }
      }
      else
      {
        this.btnArchived.Visible = !this.CheckARQuery();
        this.btnUnArchived.Visible = this.CheckARQuery();
        this.btnDelete.Visible = !this.CheckDEQuery();
        this.btnUnDelete.Visible = this.CheckDEQuery();
        this.ATagStyle();
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
      this.gvItem.PageSize = this.linePerPage;
    }

    private void ATagStyle()
    {
      if (this.Request.QueryString["ac"] != null && bool.Parse(this.Request.QueryString["ac"]))
      {
        this.activeTag.Attributes.Add("class", "activeTag");
        this.activeTag.Attributes.Remove("href");
        this.lblHeader.Text = "Items";
      }
      if (this.Request.QueryString["ar"] != null && bool.Parse(this.Request.QueryString["ar"]))
      {
        this.archivedTag.Attributes.Add("class", "activeTag");
        this.archivedTag.Attributes.Remove("href");
        this.lblHeader.Text = "Archived Items";
      }
      if (this.Request.QueryString["de"] != null && bool.Parse(this.Request.QueryString["de"]))
      {
        this.deletedTag.Attributes.Add("class", "activeTag");
        this.deletedTag.Attributes.Remove("href");
        this.lblHeader.Text = "Deleted Items";
      }
      if (this.Request.QueryString["ar"] != null || this.Request.QueryString["ac"] != null || this.Request.QueryString["de"] != null)
        return;
      this.activeTag.Attributes.Add("class", "activeTag");
      this.activeTag.Attributes.Remove("href");
      this.lblHeader.Text = "Items";
    }

    protected void gvItem_Sorting(object sender, GridViewSortEventArgs e)
    {
      this.BindGrid();
    }

    private void Clear()
    {
      this.txtItemName.Text = this.txtItemDesc.Text = this.txtUnitCost.Text = this.txtCurrentStock.Text = "";
      this.ddlTax.SelectedIndex = this.ddlTax2.SelectedIndex = 0;
      this.txtQuantity.Text = "1";
      this.chkInventory.Checked = false;
      this.txtItemName.Focus();
    }

    private void ViewRecord(string iD)
    {
      this.objItemMasterDT = this.objItemMasterBll.GetDataByItemID(int.Parse(iD));
      if (this.objItemMasterDT.Rows.Count <= 0)
        return;
      this.hfItemID.Value = this.objItemMasterDT.Rows[0]["ItemID"].ToString();
      this.hfCompanyID.Value = this.objItemMasterDT.Rows[0]["CompanyID"].ToString();
      this.lblItemName.Text = this.objItemMasterDT.Rows[0]["ItemName"].ToString();
      this.lblItemDesc.Text = this.objItemMasterDT.Rows[0]["Description"].ToString();
      this.lblUnitCost.Text = this.objItemMasterDT.Rows[0]["UnitCost"].ToString();
      this.lblCurrentStock.Text = this.objItemMasterDT.Rows[0]["CurrentStock"].ToString();
      this.lblQuantity.Text = this.objItemMasterDT.Rows[0]["Quantity"].ToString();
      this.lblInventory.Text = this.objItemMasterDT.Rows[0]["TrackInventory"].ToString();
      string s1 = this.objItemMasterDT.Rows[0]["TaxID1"].ToString();
      string s2 = this.objItemMasterDT.Rows[0]["TaxID2"].ToString();
      if (!string.IsNullOrEmpty(s1))
      {
        this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(s1));
        this.lblTax.Text = this.objTaxMasterDT.Rows[0]["TaxName"].ToString();
      }
      if (string.IsNullOrEmpty(s2))
        return;
      this.objTaxMasterDT = this.objTaxMasterBll.GetDataByTaxID(int.Parse(s2));
      this.lblTax2.Text = this.objTaxMasterDT.Rows[0]["TaxName"].ToString();
    }

    private void SetRecord(string iD)
    {
      this.objItemMasterDT = this.objItemMasterBll.GetDataByItemID(int.Parse(iD));
      if (this.objItemMasterDT.Rows.Count <= 0)
        return;
      this.hfItemID.Value = this.objItemMasterDT.Rows[0]["ItemID"].ToString();
      this.hfCompanyID.Value = this.objItemMasterDT.Rows[0]["CompanyID"].ToString();
      this.txtItemName.Text = this.objItemMasterDT.Rows[0]["ItemName"].ToString();
      this.txtItemDesc.Text = this.objItemMasterDT.Rows[0]["Description"].ToString();
      this.txtUnitCost.Text = this.objItemMasterDT.Rows[0]["UnitCost"].ToString();
      this.txtCurrentStock.Text = this.objItemMasterDT.Rows[0]["CurrentStock"].ToString();
      this.txtQuantity.Text = this.objItemMasterDT.Rows[0]["Quantity"].ToString();
      this.chkInventory.Checked = bool.Parse(this.objItemMasterDT.Rows[0]["TrackInventory"].ToString());
      this.chkInventory_CheckedChanged((object) null, (EventArgs) null);
      string str1 = this.objItemMasterDT.Rows[0]["TaxID1"].ToString();
      string str2 = this.objItemMasterDT.Rows[0]["TaxID2"].ToString();
      if (!string.IsNullOrEmpty(str1))
        this.ddlTax.SelectedValue = str1;
      if (string.IsNullOrEmpty(str2))
        return;
      this.ddlTax.SelectedValue = str2;
    }

    private void BindGrid()
    {
      this.gvItem.DataBind();
    }

    protected void gvItem_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/ItemMaster.aspx?cmd=add&ID=" + ((WebControl) this.gvItem.SelectedRow.Cells[0].FindControl("chkID")).ToolTip);
      this.BindGrid();
    }

    protected void gvItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      this.gvItem.PageIndex = e.NewPageIndex;
      this.BindGrid();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/ItemMaster.aspx?cmd=add");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.txtItemName.Text.Trim().Length > 0)
      {
        this.objItemMasterDT = this.objItemMasterBll.GetDataByItemName(int.Parse(this.hfCompanyID.Value), this.txtItemName.Text.Trim());
        if (this.objItemMasterDT.Rows.Count > 0)
        {
          this.checkInDB = true;
          this.DisplayAlert("Item Already Exists..!");
        }
        if (this.checkInDB)
          return;
        Decimal? dUnitCost = new Decimal?();
        Decimal? dQuantity = new Decimal?();
        Decimal? dCurrentStock = new Decimal?();
        int? iTaskID1 = new int?();
        int? iTaskID2 = new int?();
        if (this.ddlTax.SelectedIndex > 0)
          iTaskID1 = new int?(int.Parse(this.ddlTax.SelectedItem.Value));
        if (this.ddlTax2.SelectedIndex > 0)
          iTaskID2 = new int?(int.Parse(this.ddlTax2.SelectedItem.Value));
        if (this.txtQuantity.Text.Trim().Length > 0)
          dQuantity = new Decimal?(Decimal.Parse(this.txtQuantity.Text.Trim()));
        if (this.txtCurrentStock.Text.Trim().Length > 0)
          dCurrentStock = new Decimal?(Decimal.Parse(this.txtCurrentStock.Text.Trim()));
        else
          this.chkInventory.Checked = false;
        if (this.txtUnitCost.Text.Trim().Length > 0)
          dUnitCost = new Decimal?(Decimal.Parse(this.txtUnitCost.Text.Trim()));
        int num = this.objItemMasterBll.AddItem(int.Parse(this.hfCompanyID.Value), this.txtItemName.Text.Trim(), this.txtItemDesc.Text.Trim(), dUnitCost, dQuantity, iTaskID1, iTaskID2, this.chkInventory.Checked, dCurrentStock, true, false, false);
        if (num != 0)
        {
          this.Session["saveItem"] = (object) 1;
          this.DisplayAlert("Details Added Successfully.");
          this.Response.Redirect("~/BillTransact/ItemMaster.aspx?cmd=add&ID=" + (object) num);
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
        if (this.txtItemName.Text.Trim().Length > 0)
        {
          Decimal? dUnitCost = new Decimal?();
          Decimal? dQuantity = new Decimal?();
          Decimal? dCurrentStock = new Decimal?();
          int? iTaskID1 = new int?();
          int? iTaskID2 = new int?();
          if (this.ddlTax.SelectedIndex > 0)
            iTaskID1 = new int?(int.Parse(this.ddlTax.SelectedItem.Value));
          if (this.ddlTax2.SelectedIndex > 0)
            iTaskID2 = new int?(int.Parse(this.ddlTax2.SelectedItem.Value));
          if (this.txtQuantity.Text.Trim().Length > 0)
            dQuantity = new Decimal?(Decimal.Parse(this.txtQuantity.Text.Trim()));
          if (this.txtCurrentStock.Text.Trim().Length > 0)
            dCurrentStock = new Decimal?(Decimal.Parse(this.txtCurrentStock.Text.Trim()));
          else
            this.chkInventory.Checked = false;
          if (this.txtUnitCost.Text.Trim().Length > 0)
            dUnitCost = new Decimal?(Decimal.Parse(this.txtUnitCost.Text.Trim()));
          if (this.objItemMasterBll.UpdateItem(int.Parse(this.hfItemID.Value), int.Parse(this.hfCompanyID.Value), this.txtItemName.Text.Trim(), this.txtItemDesc.Text.Trim(), dUnitCost, dQuantity, iTaskID1, iTaskID2, this.chkInventory.Checked, dCurrentStock, true, false, false))
          {
            this.Session["updateItem"] = (object) 1;
            this.DisplayAlert("Update Successfully..");
            this.Response.Redirect("~/BillTransact/ItemMaster.aspx?cmd=add&ID=" + this.Request.QueryString["ID"]);
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

    public void DisplayAlert(string message)
    {
      this.ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), "<script language=\"JavaScript\">" + this.GetAlertScript(message) + "</script>");
    }

    public string GetAlertScript(string message)
    {
      return "alert('" + message.Replace("'", "\\'") + "');";
    }

    protected string SetDescriptionLimit(string desc)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Insert(0, desc);
      if (stringBuilder.Length > 30)
        return stringBuilder.ToString().Substring(0, 30) + "...";
      return stringBuilder.ToString();
    }

    protected void btnSaveAdd_Click(object sender, EventArgs e)
    {
      if (!this.Page.IsValid)
        return;
      if (this.txtItemName.Text.Trim().Length > 0)
      {
        this.objItemMasterDT = this.objItemMasterBll.GetDataByItemName(int.Parse(this.hfCompanyID.Value), this.txtItemName.Text.Trim());
        if (this.objItemMasterDT.Rows.Count > 0)
        {
          this.checkInDB = true;
          this.DisplayAlert("Item Already Exists..!");
        }
        if (this.checkInDB)
          return;
        Decimal? dUnitCost = new Decimal?();
        Decimal? dQuantity = new Decimal?();
        Decimal? dCurrentStock = new Decimal?();
        int? iTaskID1 = new int?();
        int? iTaskID2 = new int?();
        if (this.ddlTax.SelectedIndex > 0)
          iTaskID1 = new int?(int.Parse(this.ddlTax.SelectedItem.Value));
        if (this.ddlTax2.SelectedIndex > 0)
          iTaskID2 = new int?(int.Parse(this.ddlTax2.SelectedItem.Value));
        if (this.txtQuantity.Text.Trim().Length > 0)
          dQuantity = new Decimal?(Decimal.Parse(this.txtQuantity.Text.Trim()));
        if (this.txtCurrentStock.Text.Trim().Length > 0)
          dCurrentStock = new Decimal?(Decimal.Parse(this.txtCurrentStock.Text.Trim()));
        if (this.txtUnitCost.Text.Trim().Length > 0)
          dUnitCost = new Decimal?(Decimal.Parse(this.txtUnitCost.Text.Trim()));
        if (this.objItemMasterBll.AddItem(int.Parse(this.hfCompanyID.Value), this.txtItemName.Text.Trim(), this.txtItemDesc.Text.Trim(), dUnitCost, dQuantity, iTaskID1, iTaskID2, this.chkInventory.Checked, dCurrentStock, true, false, false) != 0)
        {
          this.Session["saveItem"] = (object) 1;
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

    protected void chkInventory_CheckedChanged(object sender, EventArgs e)
    {
      this.stock.Visible = this.chkInventory.Checked;
    }

    protected void btnArchived_Click(object sender, EventArgs e)
    {
      int num = 0;
      for (int index = 0; index < this.gvItem.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvItem.Rows[index].Cells[0].FindControl("chkID");
        if (checkBox.Checked)
        {
          ++num;
          this.objItemMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), false, false, true);
        }
      }
      if (num == 0)
        this.DisplayAlert("No items were selected.");
      else
        this.Response.Redirect("ItemMaster.aspx");
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
      int num = 0;
      for (int index = 0; index < this.gvItem.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvItem.Rows[index].Cells[0].FindControl("chkID");
        if (checkBox.Checked)
        {
          ++num;
          this.objItemMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), false, true, false);
        }
      }
      if (num == 0)
        this.DisplayAlert("No items were selected.");
      else
        this.Response.Redirect("ItemMaster.aspx?de=true&ac=false");
    }

    protected void btnUnArchived_Click(object sender, EventArgs e)
    {
      int num = 0;
      for (int index = 0; index < this.gvItem.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvItem.Rows[index].Cells[0].FindControl("chkID");
        if (checkBox.Checked)
        {
          ++num;
          this.objItemMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), true, false, false);
        }
      }
      if (num == 0)
        this.DisplayAlert("No items were selected.");
      else
        this.Response.Redirect("ItemMaster.aspx?ar=true&ac=false");
    }

    protected void btnUnDelete_Click(object sender, EventArgs e)
    {
      int num = 0;
      for (int index = 0; index < this.gvItem.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvItem.Rows[index].Cells[0].FindControl("chkID");
        if (checkBox.Checked)
        {
          ++num;
          this.objItemMasterBll.UpdateWhenAnyBit(int.Parse(checkBox.ToolTip), true, false, false);
        }
      }
      if (num == 0)
        this.DisplayAlert("No items were selected.");
      else
        this.Response.Redirect("ItemMaster.aspx?de=true&ac=false");
    }

    public bool CheckARQuery()
    {
      return this.Request.QueryString["ar"] != null && bool.Parse(this.Request.QueryString["ar"]);
    }

    public bool CheckDEQuery()
    {
      return this.Request.QueryString["de"] != null && bool.Parse(this.Request.QueryString["de"]);
    }

    protected void lnkEdit_OnClick(object sender, EventArgs e)
    {
      this.Response.Redirect("~/BillTransact/ItemMaster.aspx?cmd=add&ID=" + ((LinkButton) sender).CommandArgument);
    }

    protected string GetColor(string curStock)
    {
      return !string.IsNullOrEmpty(curStock) && Decimal.Parse(curStock) <= new Decimal(0) ? "red" : "black";
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
      this.BindGrid();
    }
  }
}

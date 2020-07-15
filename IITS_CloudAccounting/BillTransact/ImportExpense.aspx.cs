// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.ImportExpense
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using DABL.BLL;
using DABL.DAL;
using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class ImportExpense : Page
  {
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
    private readonly SubCategoryMasterBLL objSubCategoryMasterBll = new SubCategoryMasterBLL();
    private CloudAccountDA.SubCategoryMasterDataTable objSubCategoryMasterDT = new CloudAccountDA.SubCategoryMasterDataTable();
    private readonly CategoryMasterBLL objCategoryMasterBll = new CategoryMasterBLL();
    private CloudAccountDA.CategoryMasterDataTable objCategoryMasterDT = new CloudAccountDA.CategoryMasterDataTable();
    private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
    private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
    private readonly ExpenseMasterBLL objExpenseMasterBll = new ExpenseMasterBLL();
    protected ToolkitScriptManager tsm;
    protected HtmlGenericControl divError;
    protected Label lblError;
    protected LinkButton lnkDownloadFile;
    protected LinkButton lnkDownload;
    protected MultiView mvCsv;
    protected View csvFile;
    protected FileUpload fuCsv;
    protected DropDownList ddlDateFormat;
    protected DropDownList ddlAmountFormat;
    protected Button btnUploadCsv;
    protected View csvGrid;
    protected GridView gvCsvExpence;
    protected Button btnUploadCsvExpence;
    protected Button btnCancelCsv;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyName;
    protected HiddenField hfStaffID;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("expenseMenu")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("importExpense")).Attributes.Add("class", "active open");
      MembershipUser user = Membership.GetUser();
      if (user != null)
      {
        string str = user.ToString();
        if (Roles.IsUserInRole(str, "Admin"))
        {
          this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(str);
          if (this.objCompanyLoginMasterDT.Rows.Count > 0)
          {
            this.hfCompanyID.Value = this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString();
            this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
            if (this.objCompanyMasterDT.Rows.Count > 0)
            {
              this.hfCompanyID.Value = this.objCompanyMasterDT.Rows[0]["CompanyID"].ToString();
              this.hfCompanyName.Value = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
            }
          }
        }
        else if (Roles.IsUserInRole(str, "Employee"))
        {
          this.objStaffMasterDT = this.objStaffMasterBll.GetDataByStaffUserName(str);
          if (this.objStaffMasterDT.Rows.Count > 0)
          {
            this.hfCompanyID.Value = this.objStaffMasterDT.Rows[0]["CompanyID"].ToString();
            this.hfStaffID.Value = this.objStaffMasterDT.Rows[0]["StaffID"].ToString();
            this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
            if (this.objCompanyMasterDT.Rows.Count > 0)
            {
              this.hfCompanyID.Value = this.objCompanyMasterDT.Rows[0]["CompanyID"].ToString();
              this.hfCompanyName.Value = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
            }
          }
        }
      }
      if (this.IsPostBack)
        return;
      this.mvCsv.SetActiveView(this.csvFile);
    }

    protected void btnUploadCsv_OnClick(object sender, EventArgs e)
    {
      this.lblError.Text = "";
      this.divError.Visible = false;
      if (this.fuCsv.HasFile)
      {
        string fileName = Path.GetFileName(this.fuCsv.FileName);
        if (fileName != null && fileName.Contains(".csv"))
        {
          DataTable csvdt = new DataTable();
          this.fuCsv.SaveAs(this.Server.MapPath("~/UploadCSVFile/") + fileName);
          string str1 = File.ReadAllText(this.Server.MapPath("~/UploadCSVFile/") + fileName);
          int num = 0;
          string str2 = str1;
          char[] chArray1 = new char[1]
          {
            '\n'
          };
          foreach (string str3 in str2.Split(chArray1))
          {
            if (!string.IsNullOrEmpty(str3) && num == 0)
            {
              string str4 = str3;
              char[] chArray2 = new char[1]
              {
                ','
              };
              foreach (string str5 in str4.Split(chArray2))
                csvdt.Columns.Add(str5.Replace("\r", "").Replace("\n", ""));
            }
            if (csvdt.Columns.Contains("date") && csvdt.Columns.Contains("vendor") && (csvdt.Columns.Contains("category") && csvdt.Columns.Contains("amount")))
            {
              if (!string.IsNullOrEmpty(str3) && num != 0)
              {
                csvdt.Rows.Add();
                int index = 0;
                string str4 = str3;
                char[] chArray2 = new char[1]
                {
                  ','
                };
                foreach (string str5 in str4.Split(chArray2))
                {
                  csvdt.Rows[csvdt.Rows.Count - 1][index] = (object) str5;
                  ++index;
                }
              }
              ++num;
            }
            else
            {
              this.divError.Visible = true;
              this.lblError.Text = "The CSV file is invalid. OR file is not CSV";
              break;
            }
          }
          this.Bindgrid(csvdt);
          File.Delete(this.Server.MapPath("~/UploadCSVFile/") + fileName);
        }
        else
        {
          this.divError.Visible = true;
          this.lblError.Text = "The CSV file is invalid. OR file is not CSV";
        }
      }
      else
      {
        this.divError.Visible = true;
        this.lblError.Text = "No File Selected. Please Select CSV file.";
      }
    }

    private void Bindgrid(DataTable csvdt)
    {
      this.gvCsvExpence.DataSource = (object) csvdt;
      this.gvCsvExpence.DataBind();
      if (this.gvCsvExpence.Rows.Count > 0 && !this.divError.Visible)
      {
        this.btnUploadCsvExpence.Visible = true;
        this.mvCsv.SetActiveView(this.csvGrid);
      }
      else if (this.divError.Visible)
      {
        this.btnUploadCsvExpence.Visible = false;
        this.mvCsv.SetActiveView(this.csvFile);
      }
      else
      {
        this.btnUploadCsvExpence.Visible = false;
        this.divError.Visible = true;
        this.lblError.Text = "No records found in file. Please select other file.";
      }
    }

    protected void btnCancelCsv_OnClick(object sender, EventArgs e)
    {
      this.mvCsv.SetActiveView(this.csvFile);
    }

    protected void gvCsvExpence_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType != DataControlRowType.DataRow)
        return;
      TextBox textBox1 = (TextBox) e.Row.FindControl("txtDate");
      TextBox textBox2 = (TextBox) e.Row.FindControl("txtVendor");
      TextBox textBox3 = (TextBox) e.Row.FindControl("txtNotes");
      TextBox textBox4 = (TextBox) e.Row.FindControl("txtAmount");
      DropDownList dropDownList = (DropDownList) e.Row.FindControl("ddlCategory");
      SqlDataSource sqlDataSource = (SqlDataSource) e.Row.FindControl("sqldsCategory");
      DataRowView dataRowView = (DataRowView) e.Row.DataItem;
      string columnNameToCheck = "Vendor";
      if (Enumerable.Any<DataColumn>(Enumerable.Cast<DataColumn>((IEnumerable) dataRowView.Row.Table.Columns), (Func<DataColumn, bool>) (x => x.ColumnName.Equals(columnNameToCheck, StringComparison.InvariantCultureIgnoreCase))))
        textBox2.Text = DataBinder.Eval(e.Row.DataItem, "Vendor").ToString();
      columnNameToCheck = "Notes";
      if (Enumerable.Any<DataColumn>(Enumerable.Cast<DataColumn>((IEnumerable) dataRowView.Row.Table.Columns), (Func<DataColumn, bool>) (x => x.ColumnName.Equals(columnNameToCheck, StringComparison.InvariantCultureIgnoreCase))))
        textBox3.Text = DataBinder.Eval(e.Row.DataItem, "Notes").ToString();
      columnNameToCheck = "Amount";
      if (Enumerable.Any<DataColumn>(Enumerable.Cast<DataColumn>((IEnumerable) dataRowView.Row.Table.Columns), (Func<DataColumn, bool>) (x => x.ColumnName.Equals(columnNameToCheck, StringComparison.InvariantCultureIgnoreCase))))
      {
        Decimal num = Decimal.Parse(DataBinder.Eval(e.Row.DataItem, "Amount").ToString());
        if (num >= new Decimal(0) && this.ddlAmountFormat.SelectedItem.Value == "+")
          e.Row.Visible = true;
        else if (num < new Decimal(0) && this.ddlAmountFormat.SelectedItem.Value == "-")
          e.Row.Visible = true;
        else
          e.Row.Visible = false;
        textBox4.Text = Math.Abs(num).ToString();
      }
      columnNameToCheck = "Category";
      if (Enumerable.Any<DataColumn>(Enumerable.Cast<DataColumn>((IEnumerable) dataRowView.Row.Table.Columns), (Func<DataColumn, bool>) (x => x.ColumnName.Equals(columnNameToCheck, StringComparison.InvariantCultureIgnoreCase))))
      {
        string str = DataBinder.Eval(e.Row.DataItem, "Category").ToString();
        this.objSubCategoryMasterDT = this.objSubCategoryMasterBll.GetDataBySubCategoryName(str);
        if (this.objSubCategoryMasterDT.Rows.Count > 0)
        {
          dropDownList.SelectedValue = this.objSubCategoryMasterDT.Rows[0]["SubCategoryID"].ToString();
        }
        else
        {
          this.objCategoryMasterDT = this.objCategoryMasterBll.GetDataByCategoryName("Other Expenses");
          int num = this.objCategoryMasterDT.Rows.Count <= 0 ? this.objSubCategoryMasterBll.AddSubCategory(this.objCategoryMasterBll.AddCategory("", "Other Expenses", "Other Expenses", true), "", str, str, true) : this.objSubCategoryMasterBll.AddSubCategory(int.Parse(this.objCategoryMasterDT.Rows[0]["CategoryID"].ToString()), "", str, str, true);
          sqlDataSource.DataBind();
          dropDownList.DataBind();
          dropDownList.SelectedValue = num.ToString();
        }
      }
      columnNameToCheck = "Date";
      if (!Enumerable.Any<DataColumn>(Enumerable.Cast<DataColumn>((IEnumerable) dataRowView.Row.Table.Columns), (Func<DataColumn, bool>) (x => x.ColumnName.Equals(columnNameToCheck, StringComparison.InvariantCultureIgnoreCase))))
        return;
      try
      {
        textBox1.Text = DataBinder.Eval(e.Row.DataItem, "Date").ToString();
        string[] formats = new string[18]
        {
          "MM/dd/yy",
          "MM/dd/yyyy",
          "MMM/dd/yy",
          "MMM/dd/yyyy",
          "MMMM/dd/yy",
          "MMMM/dd/yyyy",
          "dd/MM/yy",
          "dd/MM/yyyy",
          "dd/MMM/yy",
          "dd/MMM/yyyy",
          "dd/MMMM/yy",
          "dd/MMMM/yyyy",
          "yy-MM-dd",
          "yyyy-MM-dd",
          "yy-MMM-dd",
          "yyyy-MMM-dd",
          "yy-MMMM-dd",
          "yyyy-MMMM-dd"
        };
        textBox1.Text = DateTime.ParseExact(textBox1.Text, formats, (IFormatProvider) CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("MM/dd/yyyy");
      }
      catch (Exception ex)
      {
        this.lblError.Text = "Expence date format / date is not valid please correct the format / date and re-upload that file or upload new file.";
        this.divError.Visible = true;
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

    protected void lnkDownload_OnClick(object sender, EventArgs e)
    {
      this.Response.ContentType = "application/text";
      this.Response.AppendHeader("Content-Disposition", "attachment; filename=sample_expenses.csv");
      this.Response.TransmitFile(this.Server.MapPath("~/SampleFile/sample_expenses.csv"));
      this.Response.End();
    }

    protected void btnUploadCsvExpence_OnClick(object sender, EventArgs e)
    {
      if (this.gvCsvExpence.Rows.Count <= 0)
        return;
      int num = 0;
      for (int index = 0; index < this.gvCsvExpence.Rows.Count; ++index)
      {
        CheckBox checkBox = (CheckBox) this.gvCsvExpence.Rows[index].FindControl("chk");
        TextBox textBox1 = (TextBox) this.gvCsvExpence.Rows[index].FindControl("txtDate");
        TextBox textBox2 = (TextBox) this.gvCsvExpence.Rows[index].FindControl("txtVendor");
        TextBox textBox3 = (TextBox) this.gvCsvExpence.Rows[index].FindControl("txtNotes");
        TextBox textBox4 = (TextBox) this.gvCsvExpence.Rows[index].FindControl("txtAmount");
        DropDownList dropDownList = (DropDownList) this.gvCsvExpence.Rows[index].FindControl("ddlCategory");
        if (checkBox.Checked && !string.IsNullOrEmpty(textBox1.Text.Trim()) && (!string.IsNullOrEmpty(textBox2.Text.Trim()) && !string.IsNullOrEmpty(textBox4.Text.Trim())) && dropDownList.SelectedIndex > 0)
        {
          int? iCategoryID = new int?();
          int? iSubCategoryID = new int?();
          this.objSubCategoryMasterDT = this.objSubCategoryMasterBll.GetDataBySubCategoryID(int.Parse(dropDownList.SelectedItem.Value));
          if (this.objSubCategoryMasterDT.Rows.Count > 0)
          {
            iCategoryID = new int?(int.Parse(this.objSubCategoryMasterDT.Rows[0]["CategoryID"].ToString()));
            iSubCategoryID = new int?(int.Parse(this.objSubCategoryMasterDT.Rows[0]["SubCategoryID"].ToString()));
          }
          if (this.objExpenseMasterBll.AddExpense(int.Parse(this.hfCompanyID.Value), Decimal.Parse(textBox4.Text), new DateTime?(DateTime.Parse(textBox1.Text)), textBox2.Text, iCategoryID, iSubCategoryID, textBox3.Text, false, new int?(), new Decimal?(), new int?(), new Decimal?(), false, new int?(), (string) null, new DateTime?(), false, new int?(), false, (byte[]) null, "", true, false, false) != 0)
            ++num;
        }
      }
      this.Session["importExp"] = (object) num;
      this.Response.Redirect("~/Admin/ExpenseMaster.aspx");
    }
  }
}

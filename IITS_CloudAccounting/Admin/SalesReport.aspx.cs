// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.SalesReport
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using AjaxControlToolkit;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class SalesReport : Page
  {
    private readonly string conn = ConfigurationManager.ConnectionStrings["IITS_CloudAccountConnectionString"].ConnectionString;
    protected ToolkitScriptManager tsm;
    protected GridView gvDaily;
    protected SqlDataSource sqldsDaily;
    protected GridView gvWeekly;
    protected SqlDataSource sqldsWeekly;
    protected GridView gvMonthly;
    protected SqlDataSource sqldsMonthly;
    protected GridView gvYearly;
    protected SqlDataSource sqldsYearly;
    protected Button btnExportDaily;
    protected Button btnExportWeekly;
    protected Button btnExportMonthly;
    protected Button btnExportYearly;
    protected GridView gvCurrentWeek;
    protected SqlDataSource sqldsCurrentWeek;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("adminReports")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("salesReport")).Attributes.Add("class", "active open");
    }

    protected string GetWeekDate()
    {
      this.gvCurrentWeek.DataBind();
      if (this.gvCurrentWeek.Rows.Count > 0)
        return DateTime.Parse(this.gvCurrentWeek.Rows[0].Cells[0].Text).ToString("MMMM dd, yyyy") + " - " + DateTime.Parse(this.gvCurrentWeek.Rows[0].Cells[1].Text).ToString("MMMM dd, yyyy");
      return "";
    }

    protected Decimal GetDailyTotal()
    {
      this.gvDaily.DataBind();
      Decimal d = new Decimal(0);
      if (this.gvDaily.Rows.Count <= 0)
        return Decimal.Round(d, 2);
      for (int index = 0; index < this.gvDaily.Rows.Count; ++index)
      {
        Decimal num = Decimal.Parse(this.gvDaily.Rows[index].Cells[7].Text);
        d += num;
      }
      return Decimal.Round(d, 2);
    }

    protected Decimal GetWeeklyTotal()
    {
      this.gvWeekly.DataBind();
      Decimal d = new Decimal(0);
      if (this.gvWeekly.Rows.Count <= 0)
        return Decimal.Round(d, 2);
      for (int index = 0; index < this.gvWeekly.Rows.Count; ++index)
      {
        Decimal num = Decimal.Parse(this.gvWeekly.Rows[index].Cells[7].Text);
        d += num;
      }
      return Decimal.Round(d, 2);
    }

    protected Decimal GetMonthlyTotal()
    {
      this.gvMonthly.DataBind();
      Decimal d = new Decimal(0);
      if (this.gvMonthly.Rows.Count <= 0)
        return Decimal.Round(d, 2);
      for (int index = 0; index < this.gvMonthly.Rows.Count; ++index)
      {
        Decimal num = Decimal.Parse(this.gvMonthly.Rows[index].Cells[7].Text);
        d += num;
      }
      return Decimal.Round(d, 2);
    }

    protected Decimal GetYearlyTotal()
    {
      this.gvYearly.DataBind();
      Decimal d = new Decimal(0);
      if (this.gvYearly.Rows.Count <= 0)
        return Decimal.Round(d, 2);
      for (int index = 0; index < this.gvYearly.Rows.Count; ++index)
      {
        Decimal num = Decimal.Parse(this.gvYearly.Rows[index].Cells[7].Text);
        d += num;
      }
      return Decimal.Round(d, 2);
    }

    protected void btnExportDaily_Click(object sender, EventArgs e)
    {
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(new SqlCommand("SELECT a.[CompanyID],[CompanyName],[CompanyEmail],[CompanyContactPerson],ISNULL(CloudPackageName,'FREE') AS 'Package Name',CONVERT(date,PackageStartDate)PackageStartDate,CONVERT(date,PackageEndDate)PackageEndDate,PackageAmount AS 'Amount' FROM CompanyMaster a INNER JOIN CompanyPackageMaster b ON a.CompanyID = b.CompanyID LEFT JOIN CloudPackageMaster c ON b.CloudPackageID = c.CloudPackageID WHERE ActivePackage = 1 AND CONVERT(date,PackageStartDate) = CONVERT(date,GETDATE())", new SqlConnection(this.conn)));
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      DataTable dataTable = dataSet.Tables[0];
      if (dataTable.Rows.Count > 0)
      {
        string str1 = string.Empty;
        foreach (DataColumn dataColumn in (InternalDataCollectionBase) dataTable.Columns)
          str1 = str1 + (object) dataColumn.ColumnName + (string) (object) ',';
        string str2 = str1 + "\r\n";
        foreach (DataRow dataRow in (InternalDataCollectionBase) dataTable.Rows)
        {
          foreach (DataColumn dataColumn in (InternalDataCollectionBase) dataTable.Columns)
            str2 = str2 + (object) dataRow[dataColumn.ColumnName].ToString().Replace(",", ";") + (string) (object) ',';
          str2 += "\r\n";
        }
        this.Response.Clear();
        this.Response.Buffer = true;
        this.Response.AddHeader("content-disposition", "attachment;filename=DailyPackages.csv");
        this.Response.Charset = "";
        this.Response.ContentType = "application/text";
        this.Response.Output.Write(str2);
        this.Response.Flush();
        this.Response.End();
      }
      else
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('No Active Companies Found')", true);
    }

    protected void btnExportWeekly_Click(object sender, EventArgs e)
    {
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(new SqlCommand("SELECT a.[CompanyID],[CompanyName],[CompanyEmail],[CompanyContactPerson],ISNULL(CloudPackageName,'FREE') AS 'Package Name',CONVERT(date,PackageStartDate)PackageStartDate,CONVERT(date,PackageEndDate)PackageEndDate,PackageAmount AS 'Amount' FROM CompanyMaster a INNER JOIN CompanyPackageMaster b ON a.CompanyID = b.CompanyID LEFT JOIN CloudPackageMaster c ON b.CloudPackageID = c.CloudPackageID WHERE ActivePackage = 1 AND CONVERT(date,PackageStartDate) >= dateadd(day, 1-datepart(dw, getdate()), CONVERT(date,getdate())) AND CONVERT(date,PackageStartDate) <= dateadd(day, 7-datepart(dw, getdate()), CONVERT(date,getdate()))", new SqlConnection(this.conn)));
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      DataTable dataTable = dataSet.Tables[0];
      if (dataTable.Rows.Count > 0)
      {
        string str1 = string.Empty;
        foreach (DataColumn dataColumn in (InternalDataCollectionBase) dataTable.Columns)
          str1 = str1 + (object) dataColumn.ColumnName + (string) (object) ',';
        string str2 = str1 + "\r\n";
        foreach (DataRow dataRow in (InternalDataCollectionBase) dataTable.Rows)
        {
          foreach (DataColumn dataColumn in (InternalDataCollectionBase) dataTable.Columns)
            str2 = str2 + (object) dataRow[dataColumn.ColumnName].ToString().Replace(",", ";") + (string) (object) ',';
          str2 += "\r\n";
        }
        this.Response.Clear();
        this.Response.Buffer = true;
        this.Response.AddHeader("content-disposition", "attachment;filename=WeeklyPackages.csv");
        this.Response.Charset = "";
        this.Response.ContentType = "application/text";
        this.Response.Output.Write(str2);
        this.Response.Flush();
        this.Response.End();
      }
      else
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('No Active Companies Found')", true);
    }

    protected void btnExportMonthly_Click(object sender, EventArgs e)
    {
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(new SqlCommand("SELECT a.[CompanyID],[CompanyName],[CompanyEmail],[CompanyContactPerson],ISNULL(CloudPackageName,'FREE') AS 'Package Name',CONVERT(date,PackageStartDate)PackageStartDate,CONVERT(date,PackageEndDate)PackageEndDate,PackageAmount AS 'Amount' FROM CompanyMaster a INNER JOIN CompanyPackageMaster b ON a.CompanyID = b.CompanyID LEFT JOIN CloudPackageMaster c ON b.CloudPackageID = c.CloudPackageID WHERE ActivePackage = 1 AND MONTH(PackageStartDate) = MONTH(GETDATE())", new SqlConnection(this.conn)));
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      DataTable dataTable = dataSet.Tables[0];
      if (dataTable.Rows.Count > 0)
      {
        string str1 = string.Empty;
        foreach (DataColumn dataColumn in (InternalDataCollectionBase) dataTable.Columns)
          str1 = str1 + (object) dataColumn.ColumnName + (string) (object) ',';
        string str2 = str1 + "\r\n";
        foreach (DataRow dataRow in (InternalDataCollectionBase) dataTable.Rows)
        {
          foreach (DataColumn dataColumn in (InternalDataCollectionBase) dataTable.Columns)
            str2 = str2 + (object) dataRow[dataColumn.ColumnName].ToString().Replace(",", ";") + (string) (object) ',';
          str2 += "\r\n";
        }
        this.Response.Clear();
        this.Response.Buffer = true;
        this.Response.AddHeader("content-disposition", "attachment;filename=MonthlyPackage.csv");
        this.Response.Charset = "";
        this.Response.ContentType = "application/text";
        this.Response.Output.Write(str2);
        this.Response.Flush();
        this.Response.End();
      }
      else
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('No Active Companies Found')", true);
    }

    protected void btnExportYearly_Click(object sender, EventArgs e)
    {
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(new SqlCommand("SELECT a.[CompanyID],[CompanyName],[CompanyEmail],[CompanyContactPerson],ISNULL(CloudPackageName,'FREE') AS 'Package Name',CONVERT(date,PackageStartDate)PackageStartDate,CONVERT(date,PackageEndDate)PackageEndDate,PackageAmount AS 'Amount' FROM CompanyMaster a INNER JOIN CompanyPackageMaster b ON a.CompanyID = b.CompanyID LEFT JOIN CloudPackageMaster c ON b.CloudPackageID = c.CloudPackageID WHERE ActivePackage = 1 AND YEAR(PackageStartDate) = YEAR(GETDATE())", new SqlConnection(this.conn)));
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      DataTable dataTable = dataSet.Tables[0];
      if (dataTable.Rows.Count > 0)
      {
        string str1 = string.Empty;
        foreach (DataColumn dataColumn in (InternalDataCollectionBase) dataTable.Columns)
          str1 = str1 + (object) dataColumn.ColumnName + (string) (object) ',';
        string str2 = str1 + "\r\n";
        foreach (DataRow dataRow in (InternalDataCollectionBase) dataTable.Rows)
        {
          foreach (DataColumn dataColumn in (InternalDataCollectionBase) dataTable.Columns)
            str2 = str2 + (object) dataRow[dataColumn.ColumnName].ToString().Replace(",", ";") + (string) (object) ',';
          str2 += "\r\n";
        }
        this.Response.Clear();
        this.Response.Buffer = true;
        this.Response.AddHeader("content-disposition", "attachment;filename=YearlyPackage.csv");
        this.Response.Charset = "";
        this.Response.ContentType = "application/text";
        this.Response.Output.Write(str2);
        this.Response.Flush();
        this.Response.End();
      }
      else
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('No Active Companies Found')", true);
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.CompanyReportStatus
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
  public class CompanyReportStatus : Page
  {
    private readonly string conn = ConfigurationManager.ConnectionStrings["IITS_CloudAccountConnectionString"].ConnectionString;
    protected ToolkitScriptManager tsm;
    protected Panel pnlViewAll;
    protected DropDownList ddlPackage;
    protected GridView gvCompany;
    protected SqlDataSource sqldsCompany;
    protected GridView gvCompanyDeactive;
    protected SqlDataSource sqldsCompanyDeactive;
    protected Button btnExportCompany;
    protected Button btnExportCompanyDeactive;

    protected void Page_Load(object sender, EventArgs e)
    {
      if (this.Master == null)
        return;
      ((HtmlControl) this.Master.FindControl("adminReports")).Attributes.Add("class", "active open");
      ((HtmlControl) this.Master.FindControl("companyActive")).Attributes.Add("class", "active open");
    }

    protected void btnExportCompany_Click(object sender, EventArgs e)
    {
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(new SqlCommand("SELECT a.[CompanyID],[CompanyName],[CompanyContactPerson],[CompanyContactPersonNumber],[CompanyEmail],CONVERT(date,PackageEndDate)PackageEndDate,ISNULL(CloudPackageName,'FREE') AS 'Package Name' FROM CompanyMaster a INNER JOIN CompanyPackageMaster b ON a.CompanyID = b.CompanyID LEFT JOIN CloudPackageMaster c ON b.CloudPackageID = c.CloudPackageID WHERE CONVERT(date,PackageEndDate) >= CONVERT(date,GETDATE()) AND ActivePackage = 1", new SqlConnection(this.conn)));
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
        this.Response.AddHeader("content-disposition", "attachment;filename=ActiveCompanies.csv");
        this.Response.Charset = "";
        this.Response.ContentType = "application/text";
        this.Response.Output.Write(str2);
        this.Response.Flush();
        this.Response.End();
      }
      else
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('No Active Companies Found')", true);
    }

    protected void btnExportCompanyDeactive_Click(object sender, EventArgs e)
    {
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(new SqlCommand("SELECT a.[CompanyID],[CompanyName],[CompanyContactPerson],[CompanyContactPersonNumber],[CompanyEmail],CONVERT(date,PackageEndDate)PackageEndDate,ISNULL(CloudPackageName,'FREE') AS 'Package Name' FROM CompanyMaster a INNER JOIN CompanyPackageMaster b ON a.CompanyID = b.CompanyID LEFT JOIN CloudPackageMaster c ON b.CloudPackageID = c.CloudPackageID WHERE CONVERT(date,PackageEndDate) < CONVERT(date,GETDATE()) AND ActivePackage = 1", new SqlConnection(this.conn)));
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
        this.Response.AddHeader("content-disposition", "attachment;filename=DeactiveCompanies.csv");
        this.Response.Charset = "";
        this.Response.ContentType = "application/text";
        this.Response.Output.Write(str2);
        this.Response.Flush();
        this.Response.End();
      }
      else
        ScriptManager.RegisterClientScriptBlock(sender as Control, this.GetType(), "alert", "alert('No Deactive Companies Found')", true);
    }
  }
}

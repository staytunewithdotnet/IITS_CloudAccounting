// Decompiled with JetBrains decompiler
// Type: IITS_CloudAccounting.Admin.ExportToCSV
// Assembly: IITS_CloudAccounting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C719F6B7-714F-4D96-9390-4C1725564C7A
// Assembly location: E:\Projects\Doyingo_Migration\Website\bin\IITS_CloudAccounting.dll

using DABL.BLL;
using DABL.DAL;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IITS_CloudAccounting.Admin
{
  public class ExportToCSV : Page
  {
    private readonly CityMasterBLL objCityMasterBll = new CityMasterBLL();
    private CloudAccountDA.CityMasterDataTable objCityMasterDT = new CloudAccountDA.CityMasterDataTable();
    private readonly CountryMasterBLL objCountryMasterBll = new CountryMasterBLL();
    private CloudAccountDA.CountryMasterDataTable objCountryMasterDT = new CloudAccountDA.CountryMasterDataTable();
    private readonly ProjectMasterBLL objProjectMasterBll = new ProjectMasterBLL();
    private CloudAccountDA.ProjectMasterDataTable objProjectMasterDT = new CloudAccountDA.ProjectMasterDataTable();
    private readonly TaskMasterBLL objTaskMasterBll = new TaskMasterBLL();
    private CloudAccountDA.TaskMasterDataTable objTaskMasterDT = new CloudAccountDA.TaskMasterDataTable();
    private readonly CompanyMasterBLL objCompanyMasterBll = new CompanyMasterBLL();
    private CloudAccountDA.CompanyMasterDataTable objCompanyMasterDT = new CloudAccountDA.CompanyMasterDataTable();
    private readonly StateMasterBLL objStateMasterBll = new StateMasterBLL();
    private CloudAccountDA.StateMasterDataTable objStateMasterDT = new CloudAccountDA.StateMasterDataTable();
    private readonly StaffMasterBLL objStaffMasterBll = new StaffMasterBLL();
    private CloudAccountDA.StaffMasterDataTable objStaffMasterDT = new CloudAccountDA.StaffMasterDataTable();
    private readonly CompanyLoginMasterBLL objCompanyLoginMasterBll = new CompanyLoginMasterBLL();
    private CloudAccountDA.CompanyLoginMasterDataTable objCompanyLoginMasterDT = new CloudAccountDA.CompanyLoginMasterDataTable();
    private readonly string conn = ConfigurationManager.ConnectionStrings["IITS_CloudAccountConnectionString"].ConnectionString;
    protected LinkButton lnkClient;
    protected LinkButton lnkStaff;
    protected LinkButton lnkInvoice;
    protected LinkButton lnkTimesheet;
    protected HiddenField hfCompanyID;
    protected HiddenField hfCompanyName;
    protected HiddenField hfStaffID;

    protected void Page_Load(object sender, EventArgs e)
    {
      MembershipUser user = Membership.GetUser();
      if (user == null)
        return;
      string str = user.ToString();
      if (Roles.IsUserInRole(str, "Admin"))
      {
        this.objCompanyLoginMasterDT = this.objCompanyLoginMasterBll.GetDataByCompanyLoginName(str);
        if (this.objCompanyLoginMasterDT.Rows.Count <= 0)
          return;
        this.hfCompanyID.Value = this.objCompanyLoginMasterDT.Rows[0]["CompanyID"].ToString();
        this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
        if (this.objCompanyMasterDT.Rows.Count <= 0)
          return;
        this.hfCompanyID.Value = this.objCompanyMasterDT.Rows[0]["CompanyID"].ToString();
        this.hfCompanyName.Value = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
      }
      else
      {
        if (!Roles.IsUserInRole(str, "Employee"))
          return;
        this.objStaffMasterDT = this.objStaffMasterBll.GetDataByStaffUserName(str);
        if (this.objStaffMasterDT.Rows.Count <= 0)
          return;
        this.hfCompanyID.Value = this.objStaffMasterDT.Rows[0]["CompanyID"].ToString();
        this.hfStaffID.Value = this.objStaffMasterDT.Rows[0]["StaffID"].ToString();
        this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyID(int.Parse(this.hfCompanyID.Value));
        if (this.objCompanyMasterDT.Rows.Count <= 0)
          return;
        this.hfCompanyID.Value = this.objCompanyMasterDT.Rows[0]["CompanyID"].ToString();
        this.hfCompanyName.Value = this.objCompanyMasterDT.Rows[0]["CompanyName"].ToString();
      }
    }

    protected void lnkClient_OnClick(object sender, EventArgs e)
    {
      SqlCommand sqlCommand = new SqlCommand("PR_ExportClientTocsv_SelectAll", new SqlConnection(this.conn));
      sqlCommand.CommandType = CommandType.StoredProcedure;
      SqlCommand selectCommand = sqlCommand;
      selectCommand.Parameters.Add(new SqlParameter("@CompanyID", (object) this.hfCompanyID.Value));
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      DataTable dataTable = dataSet.Tables[0];
      if (dataTable.Rows.Count <= 0)
        return;
      string str1 = string.Empty;
      foreach (DataColumn dataColumn in (InternalDataCollectionBase) dataTable.Columns)
        str1 = str1 + (object) dataColumn.ColumnName + (string) (object) ',';
      string str2 = str1 + "\r\n";
      foreach (DataRow dataRow in (InternalDataCollectionBase) dataTable.Rows)
      {
        foreach (DataColumn dataColumn in (InternalDataCollectionBase) dataTable.Columns)
        {
          if (dataColumn.ColumnName == "City" || dataColumn.ColumnName == "SecCity")
          {
            string s = dataRow[dataColumn.ColumnName].ToString();
            if (!string.IsNullOrEmpty(s))
            {
              this.objCityMasterDT = this.objCityMasterBll.GetDataByCityID(int.Parse(s));
              dataRow[dataColumn.ColumnName] = (object) this.objCityMasterDT.Rows[0]["CityName"].ToString();
            }
            else
              dataRow[dataColumn.ColumnName] = (object) "";
          }
          if (dataColumn.ColumnName == "Province" || dataColumn.ColumnName == "SecProvince")
          {
            string s = dataRow[dataColumn.ColumnName].ToString();
            if (!string.IsNullOrEmpty(s))
            {
              this.objStateMasterDT = this.objStateMasterBll.GetDataByStateID(int.Parse(s));
              dataRow[dataColumn.ColumnName] = (object) this.objStateMasterDT.Rows[0]["StateName"].ToString();
            }
            else
              dataRow[dataColumn.ColumnName] = (object) "";
          }
          if (dataColumn.ColumnName == "Country" || dataColumn.ColumnName == "SecCountry")
          {
            string s = dataRow[dataColumn.ColumnName].ToString();
            if (!string.IsNullOrEmpty(s))
            {
              this.objCountryMasterDT = this.objCountryMasterBll.GetDataByCountryID(int.Parse(s));
              dataRow[dataColumn.ColumnName] = (object) this.objCountryMasterDT.Rows[0]["CountryName"].ToString();
            }
            else
              dataRow[dataColumn.ColumnName] = (object) "";
          }
          str2 = str2 + (object) dataRow[dataColumn.ColumnName].ToString().Replace(",", ";") + (string) (object) ',';
        }
        str2 += "\r\n";
      }
      this.Response.Clear();
      this.Response.Buffer = true;
      this.Response.AddHeader("content-disposition", "attachment;filename=" + this.hfCompanyName.Value + "_Clients.csv");
      this.Response.Charset = "";
      this.Response.ContentType = "application/text";
      this.Response.Output.Write(str2);
      this.Response.Flush();
      this.Response.End();
    }

    protected void lnkStaff_OnClick(object sender, EventArgs e)
    {
      SqlCommand sqlCommand = new SqlCommand("PR_ExportStaffTocsv_SelectAll", new SqlConnection(this.conn));
      sqlCommand.CommandType = CommandType.StoredProcedure;
      SqlCommand selectCommand = sqlCommand;
      selectCommand.Parameters.Add(new SqlParameter("@CompanyID", (object) this.hfCompanyID.Value));
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      DataTable dataTable = dataSet.Tables[0];
      if (dataTable.Rows.Count <= 0)
        return;
      string str1 = string.Empty;
      foreach (DataColumn dataColumn in (InternalDataCollectionBase) dataTable.Columns)
        str1 = str1 + (object) dataColumn.ColumnName + (string) (object) ',';
      string str2 = str1 + "\r\n";
      foreach (DataRow dataRow in (InternalDataCollectionBase) dataTable.Rows)
      {
        foreach (DataColumn dataColumn in (InternalDataCollectionBase) dataTable.Columns)
        {
          if (dataColumn.ColumnName == "city")
          {
            string s = dataRow[dataColumn.ColumnName].ToString();
            if (!string.IsNullOrEmpty(s))
            {
              this.objCityMasterDT = this.objCityMasterBll.GetDataByCityID(int.Parse(s));
              dataRow[dataColumn.ColumnName] = (object) this.objCityMasterDT.Rows[0]["CityName"].ToString();
            }
            else
              dataRow[dataColumn.ColumnName] = (object) "";
          }
          if (dataColumn.ColumnName == "province")
          {
            string s = dataRow[dataColumn.ColumnName].ToString();
            if (!string.IsNullOrEmpty(s))
            {
              this.objStateMasterDT = this.objStateMasterBll.GetDataByStateID(int.Parse(s));
              dataRow[dataColumn.ColumnName] = (object) this.objStateMasterDT.Rows[0]["StateName"].ToString();
            }
            else
              dataRow[dataColumn.ColumnName] = (object) "";
          }
          if (dataColumn.ColumnName == "country")
          {
            string s = dataRow[dataColumn.ColumnName].ToString();
            if (!string.IsNullOrEmpty(s))
            {
              this.objCountryMasterDT = this.objCountryMasterBll.GetDataByCountryID(int.Parse(s));
              dataRow[dataColumn.ColumnName] = (object) this.objCountryMasterDT.Rows[0]["CountryName"].ToString();
            }
            else
              dataRow[dataColumn.ColumnName] = (object) "";
          }
          str2 = str2 + (object) dataRow[dataColumn.ColumnName].ToString().Replace(",", ";") + (string) (object) ',';
        }
        str2 += "\r\n";
      }
      this.Response.Clear();
      this.Response.Buffer = true;
      this.Response.AddHeader("content-disposition", "attachment;filename=" + this.hfCompanyName.Value + "_Staff.csv");
      this.Response.Charset = "";
      this.Response.ContentType = "application/text";
      this.Response.Output.Write(str2);
      this.Response.Flush();
      this.Response.End();
    }

    protected void lnkInvoice_OnClick(object sender, EventArgs e)
    {
      SqlCommand sqlCommand = new SqlCommand("PR_ExportInvoiceTocsv_SelectAll", new SqlConnection(this.conn));
      sqlCommand.CommandType = CommandType.StoredProcedure;
      SqlCommand selectCommand = sqlCommand;
      selectCommand.Parameters.Add(new SqlParameter("@CompanyID", (object) this.hfCompanyID.Value));
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      DataTable dataTable = dataSet.Tables[0];
      if (dataTable.Rows.Count <= 0)
        return;
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
      this.Response.AddHeader("content-disposition", "attachment;filename=" + this.hfCompanyName.Value + "_Invoices.csv");
      this.Response.Charset = "";
      this.Response.ContentType = "application/text";
      this.Response.Output.Write(str2);
      this.Response.Flush();
      this.Response.End();
    }

    protected void lnkTimesheet_OnClick(object sender, EventArgs e)
    {
      SqlCommand sqlCommand = new SqlCommand("PR_ExportTimesheetTocsv_SelectAll", new SqlConnection(this.conn));
      sqlCommand.CommandType = CommandType.StoredProcedure;
      SqlCommand selectCommand = sqlCommand;
      selectCommand.Parameters.Add(new SqlParameter("@CompanyID", (object) this.hfCompanyID.Value));
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
      DataSet dataSet = new DataSet();
      sqlDataAdapter.Fill(dataSet);
      DataTable dataTable = dataSet.Tables[0];
      if (dataTable.Rows.Count <= 0)
        return;
      string str1 = string.Empty;
      foreach (DataColumn dataColumn in (InternalDataCollectionBase) dataTable.Columns)
        str1 = str1 + (object) dataColumn.ColumnName + (string) (object) ',';
      string str2 = str1 + "\r\n";
      foreach (DataRow dataRow in (InternalDataCollectionBase) dataTable.Rows)
      {
        foreach (DataColumn dataColumn in (InternalDataCollectionBase) dataTable.Columns)
        {
          if (dataColumn.ColumnName == "full_name")
          {
            bool flag = false;
            string str3 = dataRow[dataColumn.ColumnName].ToString();
            this.objCompanyMasterDT = this.objCompanyMasterBll.GetDataByCompanyUserName(str3);
            if (this.objCompanyMasterDT.Rows.Count > 0)
            {
              dataRow[dataColumn.ColumnName] = (object) this.objCompanyMasterDT.Rows[0]["CompanyContactPerson"].ToString();
              flag = true;
            }
            if (!flag)
            {
              this.objStaffMasterDT = this.objStaffMasterBll.GetDataByStaffUserName(str3);
              if (this.objStaffMasterDT.Rows.Count > 0)
                dataRow[dataColumn.ColumnName] = (object) ((string) this.objStaffMasterDT.Rows[0]["FirstName"] + (object) " " + (string) this.objStaffMasterDT.Rows[0]["LastName"]);
            }
          }
          if (dataColumn.ColumnName == "project")
          {
            string s = dataRow[dataColumn.ColumnName].ToString();
            if (!string.IsNullOrEmpty(s))
            {
              this.objProjectMasterDT = this.objProjectMasterBll.GetDataByProjectID(int.Parse(s));
              dataRow[dataColumn.ColumnName] = (object) this.objProjectMasterDT.Rows[0]["ProjectName"].ToString();
            }
            else
              dataRow[dataColumn.ColumnName] = (object) "";
          }
          if (dataColumn.ColumnName == "task")
          {
            string s = dataRow[dataColumn.ColumnName].ToString();
            if (!string.IsNullOrEmpty(s))
            {
              this.objTaskMasterDT = this.objTaskMasterBll.GetDataByTaskID(int.Parse(s));
              dataRow[dataColumn.ColumnName] = (object) this.objTaskMasterDT.Rows[0]["TaskName"].ToString();
            }
            else
              dataRow[dataColumn.ColumnName] = (object) "";
          }
          str2 = str2 + (object) dataRow[dataColumn.ColumnName].ToString().Replace(",", ";") + (string) (object) ',';
        }
        str2 += "\r\n";
      }
      this.Response.Clear();
      this.Response.Buffer = true;
      this.Response.AddHeader("content-disposition", "attachment;filename=" + this.hfCompanyName.Value + "_Timesheets.csv");
      this.Response.Charset = "";
      this.Response.ContentType = "application/text";
      this.Response.Output.Write(str2);
      this.Response.Flush();
      this.Response.End();
    }
  }
}

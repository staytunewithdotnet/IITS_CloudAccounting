// Generated by .NET Reflector from E:\Projects\Doyingo_Migration\Website\bin\DABL.dll
namespace DABL.DAL.CloudAccountDATableAdapters
{
    using DABL.DAL;
    using DABL.Properties;
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Diagnostics;
    
    [DataObject(true), HelpKeyword("vs.data.TableAdapter"), Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), ToolboxItem(true), DesignerCategory("code")]
    public class ReportTimesheetDetailsTaskTableAdapter : Component
    {
        private SqlDataAdapter _adapter;
        private bool _clearBeforeFill;
        private SqlCommand[] _commandCollection;
        private SqlConnection _connection;
        private SqlTransaction _transaction;
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        public ReportTimesheetDetailsTaskTableAdapter()
        {
            this.ClearBeforeFill = true;
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, DataObjectMethod(DataObjectMethodType.Fill, true)]
        public virtual int Fill(CloudAccountDA.ReportTimesheetDetailsTaskDataTable dataTable, int? CompanyID, int? TaskID, bool? Billed, DateTime? FromDate, DateTime? ToDate)
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            if (CompanyID.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[1].Value = CompanyID.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[1].Value = DBNull.Value;
            }
            if (TaskID.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[2].Value = TaskID.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[2].Value = DBNull.Value;
            }
            if (Billed.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[3].Value = Billed.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[3].Value = DBNull.Value;
            }
            if (FromDate.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[4].Value = FromDate.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[4].Value = DBNull.Value;
            }
            if (ToDate.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[5].Value = ToDate.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[5].Value = DBNull.Value;
            }
            if (this.ClearBeforeFill)
            {
                dataTable.Clear();
            }
            return this.Adapter.Fill(dataTable);
        }
        
        [HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, DataObjectMethod(DataObjectMethodType.Select, true), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual CloudAccountDA.ReportTimesheetDetailsTaskDataTable GetData(int? CompanyID, int? TaskID, bool? Billed, DateTime? FromDate, DateTime? ToDate)
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            if (CompanyID.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[1].Value = CompanyID.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[1].Value = DBNull.Value;
            }
            if (TaskID.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[2].Value = TaskID.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[2].Value = DBNull.Value;
            }
            if (Billed.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[3].Value = Billed.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[3].Value = DBNull.Value;
            }
            if (FromDate.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[4].Value = FromDate.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[4].Value = DBNull.Value;
            }
            if (ToDate.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[5].Value = ToDate.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[5].Value = DBNull.Value;
            }
            CloudAccountDA.ReportTimesheetDetailsTaskDataTable dataTable = new CloudAccountDA.ReportTimesheetDetailsTaskDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private void InitAdapter()
        {
            this._adapter = new SqlDataAdapter();
            DataTableMapping mapping = new DataTableMapping {
                SourceTable = "Table",
                DataSetTable = "ReportTimesheetDetailsTask"
            };
            mapping.ColumnMappings.Add("Date", "Date");
            mapping.ColumnMappings.Add("Team", "Team");
            mapping.ColumnMappings.Add("Client", "Client");
            mapping.ColumnMappings.Add("Project", "Project");
            mapping.ColumnMappings.Add("Notes", "Notes");
            mapping.ColumnMappings.Add("Billed", "Billed");
            mapping.ColumnMappings.Add("Hours", "Hours");
            this._adapter.TableMappings.Add(mapping);
        }
        
        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private void InitCommandCollection()
        {
            this._commandCollection = new SqlCommand[] { new SqlCommand() };
            this._commandCollection[0].Connection = this.Connection;
            this._commandCollection[0].CommandText = "dbo.PR_Report_TimesheetDetailsTask";
            this._commandCollection[0].CommandType = CommandType.StoredProcedure;
            this._commandCollection[0].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[0].Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[0].Parameters.Add(new SqlParameter("@TaskID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[0].Parameters.Add(new SqlParameter("@Billed", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[0].Parameters.Add(new SqlParameter("@FromDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, 0x10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[0].Parameters.Add(new SqlParameter("@ToDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, 0x10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private void InitConnection()
        {
            this._connection = new SqlConnection();
            this._connection.ConnectionString = Settings.Default.IITS_CloudAccountingConnectionString;
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        protected internal SqlDataAdapter Adapter
        {
            get
            {
                if (this._adapter == null)
                {
                    this.InitAdapter();
                }
                return this._adapter;
            }
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        public bool ClearBeforeFill
        {
            get
            {
                return this._clearBeforeFill;
            }
            set
            {
                this._clearBeforeFill = value;
            }
        }
        
        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        protected SqlCommand[] CommandCollection
        {
            get
            {
                if (this._commandCollection == null)
                {
                    this.InitCommandCollection();
                }
                return this._commandCollection;
            }
        }
        
        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        internal SqlConnection Connection
        {
            get
            {
                if (this._connection == null)
                {
                    this.InitConnection();
                }
                return this._connection;
            }
            set
            {
                this._connection = value;
                if (this.Adapter.InsertCommand != null)
                {
                    this.Adapter.InsertCommand.Connection = value;
                }
                if (this.Adapter.DeleteCommand != null)
                {
                    this.Adapter.DeleteCommand.Connection = value;
                }
                if (this.Adapter.UpdateCommand != null)
                {
                    this.Adapter.UpdateCommand.Connection = value;
                }
                for (int i = 0; i < this.CommandCollection.Length; i++)
                {
                    if (this.CommandCollection[i] != null)
                    {
                        this.CommandCollection[i].Connection = value;
                    }
                }
            }
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        internal SqlTransaction Transaction
        {
            get
            {
                return this._transaction;
            }
            set
            {
                this._transaction = value;
                for (int i = 0; i < this.CommandCollection.Length; i++)
                {
                    this.CommandCollection[i].Transaction = this._transaction;
                }
                if ((this.Adapter != null) && (this.Adapter.DeleteCommand != null))
                {
                    this.Adapter.DeleteCommand.Transaction = this._transaction;
                }
                if ((this.Adapter != null) && (this.Adapter.InsertCommand != null))
                {
                    this.Adapter.InsertCommand.Transaction = this._transaction;
                }
                if ((this.Adapter != null) && (this.Adapter.UpdateCommand != null))
                {
                    this.Adapter.UpdateCommand.Transaction = this._transaction;
                }
            }
        }
    }
}

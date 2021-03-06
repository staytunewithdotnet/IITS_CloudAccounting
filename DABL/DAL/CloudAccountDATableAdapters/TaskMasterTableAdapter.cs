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
    
    [Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), ToolboxItem(true), DataObject(true), HelpKeyword("vs.data.TableAdapter"), DesignerCategory("code")]
    public class TaskMasterTableAdapter : Component
    {
        private SqlDataAdapter _adapter;
        private bool _clearBeforeFill;
        private SqlCommand[] _commandCollection;
        private SqlConnection _connection;
        private SqlTransaction _transaction;
        
        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public TaskMasterTableAdapter()
        {
            this.ClearBeforeFill = true;
        }
        
        [DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Delete, true), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual int Delete(int? TaskID)
        {
            int num2;
            if (TaskID.HasValue)
            {
                this.Adapter.DeleteCommand.Parameters[1].Value = TaskID.Value;
            }
            else
            {
                this.Adapter.DeleteCommand.Parameters[1].Value = DBNull.Value;
            }
            ConnectionState state = this.Adapter.DeleteCommand.Connection.State;
            if ((this.Adapter.DeleteCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
            {
                this.Adapter.DeleteCommand.Connection.Open();
            }
            try
            {
                num2 = this.Adapter.DeleteCommand.ExecuteNonQuery();
            }
            finally
            {
                if (state == ConnectionState.Closed)
                {
                    this.Adapter.DeleteCommand.Connection.Close();
                }
            }
            return num2;
        }
        
        [DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Select, false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual CloudAccountDA.TaskMasterDataTable DeleteByCompanyID(int? CompanyID)
        {
            this.Adapter.SelectCommand = this.CommandCollection[1];
            if (CompanyID.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[1].Value = CompanyID.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[1].Value = DBNull.Value;
            }
            CloudAccountDA.TaskMasterDataTable dataTable = new CloudAccountDA.TaskMasterDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [DataObjectMethod(DataObjectMethodType.Fill, true), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual int Fill(CloudAccountDA.TaskMasterDataTable dataTable)
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            if (this.ClearBeforeFill)
            {
                dataTable.Clear();
            }
            return this.Adapter.Fill(dataTable);
        }
        
        [DebuggerNonUserCode, DataObjectMethod(DataObjectMethodType.Select, true), HelpKeyword("vs.data.TableAdapter"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual CloudAccountDA.TaskMasterDataTable GetData()
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            CloudAccountDA.TaskMasterDataTable dataTable = new CloudAccountDA.TaskMasterDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [DebuggerNonUserCode, DataObjectMethod(DataObjectMethodType.Select, false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual CloudAccountDA.TaskMasterDataTable GetDataByCompanyID(int? CompanyID)
        {
            this.Adapter.SelectCommand = this.CommandCollection[2];
            if (CompanyID.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[1].Value = CompanyID.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[1].Value = DBNull.Value;
            }
            CloudAccountDA.TaskMasterDataTable dataTable = new CloudAccountDA.TaskMasterDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual CloudAccountDA.TaskMasterDataTable GetDataByCompanyIDAndStatus(int? CompanyID, bool? Active, bool? Archived, bool? Deleted)
        {
            this.Adapter.SelectCommand = this.CommandCollection[3];
            if (CompanyID.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[1].Value = CompanyID.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[1].Value = DBNull.Value;
            }
            if (Active.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[2].Value = Active.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[2].Value = DBNull.Value;
            }
            if (Archived.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[3].Value = Archived.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[3].Value = DBNull.Value;
            }
            if (Deleted.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[4].Value = Deleted.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[4].Value = DBNull.Value;
            }
            CloudAccountDA.TaskMasterDataTable dataTable = new CloudAccountDA.TaskMasterDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual CloudAccountDA.TaskMasterDataTable GetDataByTaskID(int? TaskID)
        {
            this.Adapter.SelectCommand = this.CommandCollection[4];
            if (TaskID.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[1].Value = TaskID.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[1].Value = DBNull.Value;
            }
            CloudAccountDA.TaskMasterDataTable dataTable = new CloudAccountDA.TaskMasterDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual CloudAccountDA.TaskMasterDataTable GetDataByTaskName(int? CompanyID, string TaskName)
        {
            this.Adapter.SelectCommand = this.CommandCollection[5];
            if (CompanyID.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[1].Value = CompanyID.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[1].Value = DBNull.Value;
            }
            if (TaskName == null)
            {
                this.Adapter.SelectCommand.Parameters[2].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[2].Value = TaskName;
            }
            CloudAccountDA.TaskMasterDataTable dataTable = new CloudAccountDA.TaskMasterDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private void InitAdapter()
        {
            this._adapter = new SqlDataAdapter();
            DataTableMapping mapping = new DataTableMapping {
                SourceTable = "Table",
                DataSetTable = "TaskMaster"
            };
            mapping.ColumnMappings.Add("TaskID", "TaskID");
            mapping.ColumnMappings.Add("CompanyID", "CompanyID");
            mapping.ColumnMappings.Add("TaskName", "TaskName");
            mapping.ColumnMappings.Add("TaskDesc", "TaskDesc");
            mapping.ColumnMappings.Add("BillToClient", "BillToClient");
            mapping.ColumnMappings.Add("RatePerHours", "RatePerHours");
            mapping.ColumnMappings.Add("Active", "Active");
            mapping.ColumnMappings.Add("Archived", "Archived");
            mapping.ColumnMappings.Add("Deleted", "Deleted");
            this._adapter.TableMappings.Add(mapping);
            this._adapter.DeleteCommand = new SqlCommand();
            this._adapter.DeleteCommand.Connection = this.Connection;
            this._adapter.DeleteCommand.CommandText = "dbo.PR_TaskMaster_Delete";
            this._adapter.DeleteCommand.CommandType = CommandType.StoredProcedure;
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@TaskID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "TaskID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand = new SqlCommand();
            this._adapter.InsertCommand.Connection = this.Connection;
            this._adapter.InsertCommand.CommandText = "dbo.PR_TaskMaster_Insert";
            this._adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@TaskID", SqlDbType.Int, 4, ParameterDirection.InputOutput, 10, 0, "TaskID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "CompanyID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@TaskName", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "TaskName", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@TaskDesc", SqlDbType.NVarChar, 0x7fffffff, ParameterDirection.Input, 0, 0, "TaskDesc", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@BillToClient", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, "BillToClient", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@RatePerHours", SqlDbType.Decimal, 9, ParameterDirection.Input, 10, 2, "RatePerHours", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Active", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, "Active", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Archived", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, "Archived", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Deleted", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, "Deleted", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand = new SqlCommand();
            this._adapter.UpdateCommand.Connection = this.Connection;
            this._adapter.UpdateCommand.CommandText = "dbo.PR_TaskMaster_Update";
            this._adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@TaskID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "TaskID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "CompanyID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@TaskName", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "TaskName", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@TaskDesc", SqlDbType.NVarChar, 0x7fffffff, ParameterDirection.Input, 0, 0, "TaskDesc", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@BillToClient", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, "BillToClient", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@RatePerHours", SqlDbType.Decimal, 9, ParameterDirection.Input, 10, 2, "RatePerHours", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Active", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, "Active", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Archived", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, "Archived", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Deleted", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, "Deleted", DataRowVersion.Current, false, null, "", "", ""));
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private void InitCommandCollection()
        {
            this._commandCollection = new SqlCommand[8];
            this._commandCollection[0] = new SqlCommand();
            this._commandCollection[0].Connection = this.Connection;
            this._commandCollection[0].CommandText = "dbo.PR_TaskMaster_SelectAll";
            this._commandCollection[0].CommandType = CommandType.StoredProcedure;
            this._commandCollection[0].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[1] = new SqlCommand();
            this._commandCollection[1].Connection = this.Connection;
            this._commandCollection[1].CommandText = "dbo.PR_TaskMaster_DeleteByCompanyID";
            this._commandCollection[1].CommandType = CommandType.StoredProcedure;
            this._commandCollection[1].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[1].Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[2] = new SqlCommand();
            this._commandCollection[2].Connection = this.Connection;
            this._commandCollection[2].CommandText = "dbo.PR_TaskMaster_SelectByCompanyID";
            this._commandCollection[2].CommandType = CommandType.StoredProcedure;
            this._commandCollection[2].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[2].Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[3] = new SqlCommand();
            this._commandCollection[3].Connection = this.Connection;
            this._commandCollection[3].CommandText = "dbo.PR_TaskMaster_SelectByCompanyIDAndStatus";
            this._commandCollection[3].CommandType = CommandType.StoredProcedure;
            this._commandCollection[3].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[3].Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[3].Parameters.Add(new SqlParameter("@Active", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[3].Parameters.Add(new SqlParameter("@Archived", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[3].Parameters.Add(new SqlParameter("@Deleted", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[4] = new SqlCommand();
            this._commandCollection[4].Connection = this.Connection;
            this._commandCollection[4].CommandText = "dbo.PR_TaskMaster_SelectByTaskID";
            this._commandCollection[4].CommandType = CommandType.StoredProcedure;
            this._commandCollection[4].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[4].Parameters.Add(new SqlParameter("@TaskID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[5] = new SqlCommand();
            this._commandCollection[5].Connection = this.Connection;
            this._commandCollection[5].CommandText = "dbo.PR_TaskMaster_SelectByTaskName";
            this._commandCollection[5].CommandType = CommandType.StoredProcedure;
            this._commandCollection[5].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[5].Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[5].Parameters.Add(new SqlParameter("@TaskName", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[6] = new SqlCommand();
            this._commandCollection[6].Connection = this.Connection;
            this._commandCollection[6].CommandText = "dbo.PR_TaskMaster_UpdateWhenAnyBit";
            this._commandCollection[6].CommandType = CommandType.StoredProcedure;
            this._commandCollection[6].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[6].Parameters.Add(new SqlParameter("@TaskID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[6].Parameters.Add(new SqlParameter("@Active", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[6].Parameters.Add(new SqlParameter("@Deleted", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[6].Parameters.Add(new SqlParameter("@Archived", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[7] = new SqlCommand();
            this._commandCollection[7].Connection = this.Connection;
            this._commandCollection[7].CommandText = "dbo.PR_TaskMaster_UpdateWhenDelete";
            this._commandCollection[7].CommandType = CommandType.StoredProcedure;
            this._commandCollection[7].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[7].Parameters.Add(new SqlParameter("@TaskID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[7].Parameters.Add(new SqlParameter("@Active", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[7].Parameters.Add(new SqlParameter("@Deleted", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, null, DataRowVersion.Current, false, null, "", "", ""));
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private void InitConnection()
        {
            this._connection = new SqlConnection();
            this._connection.ConnectionString = Settings.Default.IITS_CloudAccountingConnectionString;
        }
        
        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Insert, true)]
        public virtual int Insert(ref int? TaskID, int? CompanyID, string TaskName, string TaskDesc, bool? BillToClient, decimal? RatePerHours, bool? Active, bool? Archived, bool? Deleted)
        {
            int num2;
            if (TaskID.HasValue)
            {
                this.Adapter.InsertCommand.Parameters[1].Value = TaskID.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[1].Value = DBNull.Value;
            }
            if (CompanyID.HasValue)
            {
                this.Adapter.InsertCommand.Parameters[2].Value = CompanyID.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[2].Value = DBNull.Value;
            }
            if (TaskName == null)
            {
                this.Adapter.InsertCommand.Parameters[3].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[3].Value = TaskName;
            }
            if (TaskDesc == null)
            {
                this.Adapter.InsertCommand.Parameters[4].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[4].Value = TaskDesc;
            }
            if (BillToClient.HasValue)
            {
                this.Adapter.InsertCommand.Parameters[5].Value = BillToClient.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[5].Value = DBNull.Value;
            }
            if (RatePerHours.HasValue)
            {
                this.Adapter.InsertCommand.Parameters[6].Value = RatePerHours.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[6].Value = DBNull.Value;
            }
            if (Active.HasValue)
            {
                this.Adapter.InsertCommand.Parameters[7].Value = Active.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[7].Value = DBNull.Value;
            }
            if (Archived.HasValue)
            {
                this.Adapter.InsertCommand.Parameters[8].Value = Archived.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[8].Value = DBNull.Value;
            }
            if (Deleted.HasValue)
            {
                this.Adapter.InsertCommand.Parameters[9].Value = Deleted.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[9].Value = DBNull.Value;
            }
            ConnectionState state = this.Adapter.InsertCommand.Connection.State;
            if ((this.Adapter.InsertCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
            {
                this.Adapter.InsertCommand.Connection.Open();
            }
            try
            {
                int num = this.Adapter.InsertCommand.ExecuteNonQuery();
                if ((this.Adapter.InsertCommand.Parameters[1].Value == null) || (this.Adapter.InsertCommand.Parameters[1].Value.GetType() == typeof(DBNull)))
                {
                    TaskID = 0;
                }
                else
                {
                    TaskID = new int?((int) this.Adapter.InsertCommand.Parameters[1].Value);
                }
                num2 = num;
            }
            finally
            {
                if (state == ConnectionState.Closed)
                {
                    this.Adapter.InsertCommand.Connection.Close();
                }
            }
            return num2;
        }
        
        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual int Update(CloudAccountDA dataSet)
        {
            return this.Adapter.Update(dataSet, "TaskMaster");
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter")]
        public virtual int Update(CloudAccountDA.TaskMasterDataTable dataTable)
        {
            return this.Adapter.Update(dataTable);
        }
        
        [HelpKeyword("vs.data.TableAdapter"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        public virtual int Update(DataRow dataRow)
        {
            return this.Adapter.Update(new DataRow[] { dataRow });
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter")]
        public virtual int Update(DataRow[] dataRows)
        {
            return this.Adapter.Update(dataRows);
        }
        
        [HelpKeyword("vs.data.TableAdapter"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, DataObjectMethod(DataObjectMethodType.Update, true)]
        public virtual int Update(int? TaskID, int? CompanyID, string TaskName, string TaskDesc, bool? BillToClient, decimal? RatePerHours, bool? Active, bool? Archived, bool? Deleted)
        {
            int num2;
            if (TaskID.HasValue)
            {
                this.Adapter.UpdateCommand.Parameters[1].Value = TaskID.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[1].Value = DBNull.Value;
            }
            if (CompanyID.HasValue)
            {
                this.Adapter.UpdateCommand.Parameters[2].Value = CompanyID.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[2].Value = DBNull.Value;
            }
            if (TaskName == null)
            {
                this.Adapter.UpdateCommand.Parameters[3].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[3].Value = TaskName;
            }
            if (TaskDesc == null)
            {
                this.Adapter.UpdateCommand.Parameters[4].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[4].Value = TaskDesc;
            }
            if (BillToClient.HasValue)
            {
                this.Adapter.UpdateCommand.Parameters[5].Value = BillToClient.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[5].Value = DBNull.Value;
            }
            if (RatePerHours.HasValue)
            {
                this.Adapter.UpdateCommand.Parameters[6].Value = RatePerHours.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[6].Value = DBNull.Value;
            }
            if (Active.HasValue)
            {
                this.Adapter.UpdateCommand.Parameters[7].Value = Active.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[7].Value = DBNull.Value;
            }
            if (Archived.HasValue)
            {
                this.Adapter.UpdateCommand.Parameters[8].Value = Archived.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[8].Value = DBNull.Value;
            }
            if (Deleted.HasValue)
            {
                this.Adapter.UpdateCommand.Parameters[9].Value = Deleted.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[9].Value = DBNull.Value;
            }
            ConnectionState state = this.Adapter.UpdateCommand.Connection.State;
            if ((this.Adapter.UpdateCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
            {
                this.Adapter.UpdateCommand.Connection.Open();
            }
            try
            {
                num2 = this.Adapter.UpdateCommand.ExecuteNonQuery();
            }
            finally
            {
                if (state == ConnectionState.Closed)
                {
                    this.Adapter.UpdateCommand.Connection.Close();
                }
            }
            return num2;
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Select, false)]
        public virtual CloudAccountDA.TaskMasterDataTable UpdateWhenAnyBit(int? TaskID, bool? Active, bool? Deleted, bool? Archived)
        {
            this.Adapter.SelectCommand = this.CommandCollection[6];
            if (TaskID.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[1].Value = TaskID.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[1].Value = DBNull.Value;
            }
            if (Active.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[2].Value = Active.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[2].Value = DBNull.Value;
            }
            if (Deleted.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[3].Value = Deleted.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[3].Value = DBNull.Value;
            }
            if (Archived.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[4].Value = Archived.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[4].Value = DBNull.Value;
            }
            CloudAccountDA.TaskMasterDataTable dataTable = new CloudAccountDA.TaskMasterDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, DataObjectMethod(DataObjectMethodType.Select, false)]
        public virtual CloudAccountDA.TaskMasterDataTable UpdateWhenDelete(int? TaskID, bool? Active, bool? Deleted)
        {
            this.Adapter.SelectCommand = this.CommandCollection[7];
            if (TaskID.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[1].Value = TaskID.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[1].Value = DBNull.Value;
            }
            if (Active.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[2].Value = Active.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[2].Value = DBNull.Value;
            }
            if (Deleted.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[3].Value = Deleted.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[3].Value = DBNull.Value;
            }
            CloudAccountDA.TaskMasterDataTable dataTable = new CloudAccountDA.TaskMasterDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
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
        
        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

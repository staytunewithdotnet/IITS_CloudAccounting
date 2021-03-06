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
    
    [DataObject(true), ToolboxItem(true), Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), HelpKeyword("vs.data.TableAdapter"), DesignerCategory("code")]
    public class ContractorMasterTableAdapter : Component
    {
        private SqlDataAdapter _adapter;
        private bool _clearBeforeFill;
        private SqlCommand[] _commandCollection;
        private SqlConnection _connection;
        private SqlTransaction _transaction;
        
        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public ContractorMasterTableAdapter()
        {
            this.ClearBeforeFill = true;
        }
        
        [DataObjectMethod(DataObjectMethodType.Delete, true), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter")]
        public virtual int Delete(int? ContractorID)
        {
            int num2;
            if (ContractorID.HasValue)
            {
                this.Adapter.DeleteCommand.Parameters[1].Value = ContractorID.Value;
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
        
        [HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Select, false), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual CloudAccountDA.ContractorMasterDataTable DeleteByCompanyID(int? CompanyID)
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
            CloudAccountDA.ContractorMasterDataTable dataTable = new CloudAccountDA.ContractorMasterDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Fill, true), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual int Fill(CloudAccountDA.ContractorMasterDataTable dataTable)
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            if (this.ClearBeforeFill)
            {
                dataTable.Clear();
            }
            return this.Adapter.Fill(dataTable);
        }
        
        [DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Select, true), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual CloudAccountDA.ContractorMasterDataTable GetData()
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            CloudAccountDA.ContractorMasterDataTable dataTable = new CloudAccountDA.ContractorMasterDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Select, false)]
        public virtual CloudAccountDA.ContractorMasterDataTable GetDataByCompanyID(int? CompanyID)
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
            CloudAccountDA.ContractorMasterDataTable dataTable = new CloudAccountDA.ContractorMasterDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter")]
        public virtual CloudAccountDA.ContractorMasterDataTable GetDataByCompanyIDAndEmail(int? CompanyID, string Email)
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
            if (Email == null)
            {
                this.Adapter.SelectCommand.Parameters[2].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[2].Value = Email;
            }
            CloudAccountDA.ContractorMasterDataTable dataTable = new CloudAccountDA.ContractorMasterDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Select, false), DebuggerNonUserCode]
        public virtual CloudAccountDA.ContractorMasterDataTable GetDataByContractorID(int? ContractorID)
        {
            this.Adapter.SelectCommand = this.CommandCollection[4];
            if (ContractorID.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[1].Value = ContractorID.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[1].Value = DBNull.Value;
            }
            CloudAccountDA.ContractorMasterDataTable dataTable = new CloudAccountDA.ContractorMasterDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private void InitAdapter()
        {
            this._adapter = new SqlDataAdapter();
            DataTableMapping mapping = new DataTableMapping {
                SourceTable = "Table",
                DataSetTable = "ContractorMaster"
            };
            mapping.ColumnMappings.Add("ContractorID", "ContractorID");
            mapping.ColumnMappings.Add("CompanyID", "CompanyID");
            mapping.ColumnMappings.Add("ContractorEmail", "ContractorEmail");
            mapping.ColumnMappings.Add("ContractorName", "ContractorName");
            mapping.ColumnMappings.Add("TaskID", "TaskID");
            mapping.ColumnMappings.Add("RebillRate", "RebillRate");
            mapping.ColumnMappings.Add("Active", "Active");
            mapping.ColumnMappings.Add("Archived", "Archived");
            mapping.ColumnMappings.Add("Deleted", "Deleted");
            this._adapter.TableMappings.Add(mapping);
            this._adapter.DeleteCommand = new SqlCommand();
            this._adapter.DeleteCommand.Connection = this.Connection;
            this._adapter.DeleteCommand.CommandText = "dbo.PR_ContractorMaster_Delete";
            this._adapter.DeleteCommand.CommandType = CommandType.StoredProcedure;
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@ContractorID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "ContractorID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand = new SqlCommand();
            this._adapter.InsertCommand.Connection = this.Connection;
            this._adapter.InsertCommand.CommandText = "dbo.PR_ContractorMaster_Insert";
            this._adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ContractorID", SqlDbType.Int, 4, ParameterDirection.InputOutput, 10, 0, "ContractorID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "CompanyID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ContractorEmail", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ContractorEmail", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ContractorName", SqlDbType.NVarChar, 100, ParameterDirection.Input, 0, 0, "ContractorName", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@TaskID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "TaskID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@RebillRate", SqlDbType.Decimal, 9, ParameterDirection.Input, 10, 2, "RebillRate", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Active", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, "Active", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Archived", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, "Archived", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Deleted", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, "Deleted", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand = new SqlCommand();
            this._adapter.UpdateCommand.Connection = this.Connection;
            this._adapter.UpdateCommand.CommandText = "dbo.PR_ContractorMaster_Update";
            this._adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ContractorID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "ContractorID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "CompanyID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ContractorEmail", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ContractorEmail", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ContractorName", SqlDbType.NVarChar, 100, ParameterDirection.Input, 0, 0, "ContractorName", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@TaskID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "TaskID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@RebillRate", SqlDbType.Decimal, 9, ParameterDirection.Input, 10, 2, "RebillRate", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Active", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, "Active", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Archived", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, "Archived", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Deleted", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, "Deleted", DataRowVersion.Current, false, null, "", "", ""));
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private void InitCommandCollection()
        {
            this._commandCollection = new SqlCommand[7];
            this._commandCollection[0] = new SqlCommand();
            this._commandCollection[0].Connection = this.Connection;
            this._commandCollection[0].CommandText = "dbo.PR_ContractorMaster_SelectAll";
            this._commandCollection[0].CommandType = CommandType.StoredProcedure;
            this._commandCollection[0].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[1] = new SqlCommand();
            this._commandCollection[1].Connection = this.Connection;
            this._commandCollection[1].CommandText = "dbo.PR_ContractorMaster_DeleteByCompanyID";
            this._commandCollection[1].CommandType = CommandType.StoredProcedure;
            this._commandCollection[1].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[1].Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[2] = new SqlCommand();
            this._commandCollection[2].Connection = this.Connection;
            this._commandCollection[2].CommandText = "dbo.PR_ContractorMaster_SelectByCompanyID";
            this._commandCollection[2].CommandType = CommandType.StoredProcedure;
            this._commandCollection[2].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[2].Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[3] = new SqlCommand();
            this._commandCollection[3].Connection = this.Connection;
            this._commandCollection[3].CommandText = "dbo.PR_ContractorMaster_SelectByCompanyIDAndEmail";
            this._commandCollection[3].CommandType = CommandType.StoredProcedure;
            this._commandCollection[3].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[3].Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[3].Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[4] = new SqlCommand();
            this._commandCollection[4].Connection = this.Connection;
            this._commandCollection[4].CommandText = "dbo.PR_ContractorMaster_SelectByContractorID";
            this._commandCollection[4].CommandType = CommandType.StoredProcedure;
            this._commandCollection[4].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[4].Parameters.Add(new SqlParameter("@ContractorID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[5] = new SqlCommand();
            this._commandCollection[5].Connection = this.Connection;
            this._commandCollection[5].CommandText = "dbo.PR_ContractorMaster_UpdateWhenAnyBit";
            this._commandCollection[5].CommandType = CommandType.StoredProcedure;
            this._commandCollection[5].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[5].Parameters.Add(new SqlParameter("@ContractorID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[5].Parameters.Add(new SqlParameter("@Active", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[5].Parameters.Add(new SqlParameter("@Deleted", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[5].Parameters.Add(new SqlParameter("@Archived", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[6] = new SqlCommand();
            this._commandCollection[6].Connection = this.Connection;
            this._commandCollection[6].CommandText = "dbo.PR_ContractorMaster_UpdateWhenDelete";
            this._commandCollection[6].CommandType = CommandType.StoredProcedure;
            this._commandCollection[6].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[6].Parameters.Add(new SqlParameter("@ContractorID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[6].Parameters.Add(new SqlParameter("@Active", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[6].Parameters.Add(new SqlParameter("@Deleted", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, null, DataRowVersion.Current, false, null, "", "", ""));
        }
        
        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private void InitConnection()
        {
            this._connection = new SqlConnection();
            this._connection.ConnectionString = Settings.Default.IITS_CloudAccountingConnectionString;
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Insert, true), DebuggerNonUserCode]
        public virtual int Insert(ref int? ContractorID, int? CompanyID, string ContractorEmail, string ContractorName, int? TaskID, decimal? RebillRate, bool? Active, bool? Archived, bool? Deleted)
        {
            int num2;
            if (ContractorID.HasValue)
            {
                this.Adapter.InsertCommand.Parameters[1].Value = ContractorID.Value;
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
            if (ContractorEmail == null)
            {
                this.Adapter.InsertCommand.Parameters[3].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[3].Value = ContractorEmail;
            }
            if (ContractorName == null)
            {
                this.Adapter.InsertCommand.Parameters[4].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[4].Value = ContractorName;
            }
            if (TaskID.HasValue)
            {
                this.Adapter.InsertCommand.Parameters[5].Value = TaskID.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[5].Value = DBNull.Value;
            }
            if (RebillRate.HasValue)
            {
                this.Adapter.InsertCommand.Parameters[6].Value = RebillRate.Value;
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
                    ContractorID = 0;
                }
                else
                {
                    ContractorID = new int?((int) this.Adapter.InsertCommand.Parameters[1].Value);
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
        
        [HelpKeyword("vs.data.TableAdapter"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        public virtual int Update(CloudAccountDA dataSet)
        {
            return this.Adapter.Update(dataSet, "ContractorMaster");
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter")]
        public virtual int Update(CloudAccountDA.ContractorMasterDataTable dataTable)
        {
            return this.Adapter.Update(dataTable);
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode]
        public virtual int Update(DataRow dataRow)
        {
            return this.Adapter.Update(new DataRow[] { dataRow });
        }
        
        [HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual int Update(DataRow[] dataRows)
        {
            return this.Adapter.Update(dataRows);
        }
        
        [DataObjectMethod(DataObjectMethodType.Update, true), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual int Update(int? ContractorID, int? CompanyID, string ContractorEmail, string ContractorName, int? TaskID, decimal? RebillRate, bool? Active, bool? Archived, bool? Deleted)
        {
            int num2;
            if (ContractorID.HasValue)
            {
                this.Adapter.UpdateCommand.Parameters[1].Value = ContractorID.Value;
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
            if (ContractorEmail == null)
            {
                this.Adapter.UpdateCommand.Parameters[3].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[3].Value = ContractorEmail;
            }
            if (ContractorName == null)
            {
                this.Adapter.UpdateCommand.Parameters[4].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[4].Value = ContractorName;
            }
            if (TaskID.HasValue)
            {
                this.Adapter.UpdateCommand.Parameters[5].Value = TaskID.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[5].Value = DBNull.Value;
            }
            if (RebillRate.HasValue)
            {
                this.Adapter.UpdateCommand.Parameters[6].Value = RebillRate.Value;
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
        
        [DataObjectMethod(DataObjectMethodType.Select, false), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual CloudAccountDA.ContractorMasterDataTable UpdateWhenAnyBit(int? ContractorID, bool? Active, bool? Deleted, bool? Archived)
        {
            this.Adapter.SelectCommand = this.CommandCollection[5];
            if (ContractorID.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[1].Value = ContractorID.Value;
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
            CloudAccountDA.ContractorMasterDataTable dataTable = new CloudAccountDA.ContractorMasterDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Select, false), DebuggerNonUserCode]
        public virtual CloudAccountDA.ContractorMasterDataTable UpdateWhenDelete(int? ContractorID, bool? Active, bool? Deleted)
        {
            this.Adapter.SelectCommand = this.CommandCollection[6];
            if (ContractorID.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[1].Value = ContractorID.Value;
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
            CloudAccountDA.ContractorMasterDataTable dataTable = new CloudAccountDA.ContractorMasterDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
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
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
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
        
        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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

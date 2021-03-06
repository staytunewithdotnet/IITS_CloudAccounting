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
    
    [ToolboxItem(true), Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), HelpKeyword("vs.data.TableAdapter"), DesignerCategory("code"), DataObject(true)]
    public class FAQCategoryMasterTableAdapter : Component
    {
        private SqlDataAdapter _adapter;
        private bool _clearBeforeFill;
        private SqlCommand[] _commandCollection;
        private SqlConnection _connection;
        private SqlTransaction _transaction;
        
        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public FAQCategoryMasterTableAdapter()
        {
            this.ClearBeforeFill = true;
        }
        
        [DataObjectMethod(DataObjectMethodType.Delete, true), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual int Delete(int? FAQCategoryID)
        {
            int num2;
            if (FAQCategoryID.HasValue)
            {
                this.Adapter.DeleteCommand.Parameters[1].Value = FAQCategoryID.Value;
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
        
        [DebuggerNonUserCode, DataObjectMethod(DataObjectMethodType.Fill, true), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual int Fill(CloudAccountDA.FAQCategoryMasterDataTable dataTable)
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            if (this.ClearBeforeFill)
            {
                dataTable.Clear();
            }
            return this.Adapter.Fill(dataTable);
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, true), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual CloudAccountDA.FAQCategoryMasterDataTable GetData()
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            CloudAccountDA.FAQCategoryMasterDataTable dataTable = new CloudAccountDA.FAQCategoryMasterDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DataObjectMethod(DataObjectMethodType.Select, false)]
        public virtual CloudAccountDA.FAQCategoryMasterDataTable GetDataByFAQCategoryID(int? FAQCategoryID)
        {
            this.Adapter.SelectCommand = this.CommandCollection[1];
            if (FAQCategoryID.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[1].Value = FAQCategoryID.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[1].Value = DBNull.Value;
            }
            CloudAccountDA.FAQCategoryMasterDataTable dataTable = new CloudAccountDA.FAQCategoryMasterDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DataObjectMethod(DataObjectMethodType.Select, false)]
        public virtual CloudAccountDA.FAQCategoryMasterDataTable GetDataByFAQCategoryName(string FAQCategoryName)
        {
            this.Adapter.SelectCommand = this.CommandCollection[2];
            if (FAQCategoryName == null)
            {
                this.Adapter.SelectCommand.Parameters[1].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[1].Value = FAQCategoryName;
            }
            CloudAccountDA.FAQCategoryMasterDataTable dataTable = new CloudAccountDA.FAQCategoryMasterDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private void InitAdapter()
        {
            this._adapter = new SqlDataAdapter();
            DataTableMapping mapping = new DataTableMapping {
                SourceTable = "Table",
                DataSetTable = "FAQCategoryMaster"
            };
            mapping.ColumnMappings.Add("FAQCategoryID", "FAQCategoryID");
            mapping.ColumnMappings.Add("FAQCategoryName", "FAQCategoryName");
            mapping.ColumnMappings.Add("FAQCategoryDesc", "FAQCategoryDesc");
            mapping.ColumnMappings.Add("FAQCategoryStatus", "FAQCategoryStatus");
            this._adapter.TableMappings.Add(mapping);
            this._adapter.DeleteCommand = new SqlCommand();
            this._adapter.DeleteCommand.Connection = this.Connection;
            this._adapter.DeleteCommand.CommandText = "dbo.PR_FAQCategoryMaster_Delete";
            this._adapter.DeleteCommand.CommandType = CommandType.StoredProcedure;
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@FAQCategoryID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "FAQCategoryID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand = new SqlCommand();
            this._adapter.InsertCommand.Connection = this.Connection;
            this._adapter.InsertCommand.CommandText = "dbo.PR_FAQCategoryMaster_Insert";
            this._adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FAQCategoryID", SqlDbType.Int, 4, ParameterDirection.InputOutput, 10, 0, "FAQCategoryID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FAQCategoryName", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "FAQCategoryName", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FAQCategoryDesc", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, "FAQCategoryDesc", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FAQCategoryStatus", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, "FAQCategoryStatus", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand = new SqlCommand();
            this._adapter.UpdateCommand.Connection = this.Connection;
            this._adapter.UpdateCommand.CommandText = "dbo.PR_FAQCategoryMaster_Update";
            this._adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FAQCategoryID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "FAQCategoryID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FAQCategoryName", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "FAQCategoryName", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FAQCategoryDesc", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, "FAQCategoryDesc", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FAQCategoryStatus", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, "FAQCategoryStatus", DataRowVersion.Current, false, null, "", "", ""));
        }
        
        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private void InitCommandCollection()
        {
            this._commandCollection = new SqlCommand[4];
            this._commandCollection[0] = new SqlCommand();
            this._commandCollection[0].Connection = this.Connection;
            this._commandCollection[0].CommandText = "dbo.PR_FAQCategoryMaster_SelectAll";
            this._commandCollection[0].CommandType = CommandType.StoredProcedure;
            this._commandCollection[0].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[1] = new SqlCommand();
            this._commandCollection[1].Connection = this.Connection;
            this._commandCollection[1].CommandText = "dbo.PR_FAQCategoryMaster_SelectByFAQCategoryID";
            this._commandCollection[1].CommandType = CommandType.StoredProcedure;
            this._commandCollection[1].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[1].Parameters.Add(new SqlParameter("@FAQCategoryID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[2] = new SqlCommand();
            this._commandCollection[2].Connection = this.Connection;
            this._commandCollection[2].CommandText = "dbo.PR_FAQCategoryMaster_SelectByFAQCategoryName";
            this._commandCollection[2].CommandType = CommandType.StoredProcedure;
            this._commandCollection[2].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[2].Parameters.Add(new SqlParameter("@FAQCategoryName", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[3] = new SqlCommand();
            this._commandCollection[3].Connection = this.Connection;
            this._commandCollection[3].CommandText = "dbo.PR_FAQCategoryID_SelectByMaxFAQCategoryID";
            this._commandCollection[3].CommandType = CommandType.StoredProcedure;
            this._commandCollection[3].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private void InitConnection()
        {
            this._connection = new SqlConnection();
            this._connection.ConnectionString = Settings.Default.IITS_CloudAccountingConnectionString;
        }
        
        [HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DataObjectMethod(DataObjectMethodType.Insert, true)]
        public virtual int Insert(ref int? FAQCategoryID, string FAQCategoryName, string FAQCategoryDesc, bool? FAQCategoryStatus)
        {
            int num2;
            if (FAQCategoryID.HasValue)
            {
                this.Adapter.InsertCommand.Parameters[1].Value = FAQCategoryID.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[1].Value = DBNull.Value;
            }
            if (FAQCategoryName == null)
            {
                this.Adapter.InsertCommand.Parameters[2].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[2].Value = FAQCategoryName;
            }
            if (FAQCategoryDesc == null)
            {
                this.Adapter.InsertCommand.Parameters[3].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[3].Value = FAQCategoryDesc;
            }
            if (FAQCategoryStatus.HasValue)
            {
                this.Adapter.InsertCommand.Parameters[4].Value = FAQCategoryStatus.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[4].Value = DBNull.Value;
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
                    FAQCategoryID = 0;
                }
                else
                {
                    FAQCategoryID = new int?((int) this.Adapter.InsertCommand.Parameters[1].Value);
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
        
        [DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DataObjectMethod(DataObjectMethodType.Select, false)]
        public virtual CloudAccountDA.FAQCategoryMasterDataTable MaxFAQCategoryID()
        {
            this.Adapter.SelectCommand = this.CommandCollection[3];
            CloudAccountDA.FAQCategoryMasterDataTable dataTable = new CloudAccountDA.FAQCategoryMasterDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode]
        public virtual int Update(CloudAccountDA dataSet)
        {
            return this.Adapter.Update(dataSet, "FAQCategoryMaster");
        }
        
        [HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual int Update(CloudAccountDA.FAQCategoryMasterDataTable dataTable)
        {
            return this.Adapter.Update(dataTable);
        }
        
        [HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual int Update(DataRow dataRow)
        {
            return this.Adapter.Update(new DataRow[] { dataRow });
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter")]
        public virtual int Update(DataRow[] dataRows)
        {
            return this.Adapter.Update(dataRows);
        }
        
        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Update, true)]
        public virtual int Update(int? FAQCategoryID, string FAQCategoryName, string FAQCategoryDesc, bool? FAQCategoryStatus)
        {
            int num2;
            if (FAQCategoryID.HasValue)
            {
                this.Adapter.UpdateCommand.Parameters[1].Value = FAQCategoryID.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[1].Value = DBNull.Value;
            }
            if (FAQCategoryName == null)
            {
                this.Adapter.UpdateCommand.Parameters[2].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[2].Value = FAQCategoryName;
            }
            if (FAQCategoryDesc == null)
            {
                this.Adapter.UpdateCommand.Parameters[3].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[3].Value = FAQCategoryDesc;
            }
            if (FAQCategoryStatus.HasValue)
            {
                this.Adapter.UpdateCommand.Parameters[4].Value = FAQCategoryStatus.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[4].Value = DBNull.Value;
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

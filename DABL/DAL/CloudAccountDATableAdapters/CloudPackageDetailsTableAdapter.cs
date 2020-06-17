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
    
    [ToolboxItem(true), DataObject(true), Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), HelpKeyword("vs.data.TableAdapter"), DesignerCategory("code")]
    public class CloudPackageDetailsTableAdapter : Component
    {
        private SqlDataAdapter _adapter;
        private bool _clearBeforeFill;
        private SqlCommand[] _commandCollection;
        private SqlConnection _connection;
        private SqlTransaction _transaction;
        
        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public CloudPackageDetailsTableAdapter()
        {
            this.ClearBeforeFill = true;
        }
        
        [DebuggerNonUserCode, DataObjectMethod(DataObjectMethodType.Delete, true), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual int Delete(int? CloudPackageDetailID)
        {
            int num2;
            if (CloudPackageDetailID.HasValue)
            {
                this.Adapter.DeleteCommand.Parameters[1].Value = CloudPackageDetailID.Value;
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
        
        [HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, DataObjectMethod(DataObjectMethodType.Select, false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual CloudAccountDA.CloudPackageDetailsDataTable DeleteByCloudPackage(int? CloudPackageID)
        {
            this.Adapter.SelectCommand = this.CommandCollection[1];
            if (CloudPackageID.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[1].Value = CloudPackageID.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[1].Value = DBNull.Value;
            }
            CloudAccountDA.CloudPackageDetailsDataTable dataTable = new CloudAccountDA.CloudPackageDetailsDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [DataObjectMethod(DataObjectMethodType.Fill, true), DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual int Fill(CloudAccountDA.CloudPackageDetailsDataTable dataTable)
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            if (this.ClearBeforeFill)
            {
                dataTable.Clear();
            }
            return this.Adapter.Fill(dataTable);
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, true), DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual CloudAccountDA.CloudPackageDetailsDataTable GetData()
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            CloudAccountDA.CloudPackageDetailsDataTable dataTable = new CloudAccountDA.CloudPackageDetailsDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual CloudAccountDA.CloudPackageDetailsDataTable GetDataByCloudPackageDetailID(int? CloudPackageDetailID)
        {
            this.Adapter.SelectCommand = this.CommandCollection[2];
            if (CloudPackageDetailID.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[1].Value = CloudPackageDetailID.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[1].Value = DBNull.Value;
            }
            CloudAccountDA.CloudPackageDetailsDataTable dataTable = new CloudAccountDA.CloudPackageDetailsDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode]
        public virtual CloudAccountDA.CloudPackageDetailsDataTable GetDataByCloudPackageID(int? CloudPackageID)
        {
            this.Adapter.SelectCommand = this.CommandCollection[3];
            if (CloudPackageID.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[1].Value = CloudPackageID.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[1].Value = DBNull.Value;
            }
            CloudAccountDA.CloudPackageDetailsDataTable dataTable = new CloudAccountDA.CloudPackageDetailsDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual CloudAccountDA.CloudPackageDetailsDataTable GetDataByPackageFeatureID(int? PackageFeatureID)
        {
            this.Adapter.SelectCommand = this.CommandCollection[4];
            if (PackageFeatureID.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[1].Value = PackageFeatureID.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[1].Value = DBNull.Value;
            }
            CloudAccountDA.CloudPackageDetailsDataTable dataTable = new CloudAccountDA.CloudPackageDetailsDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode]
        public virtual CloudAccountDA.CloudPackageDetailsDataTable GetDataByPackageModuleFeatureID(int? CloudPackageID, int? PackageModuleID, int? PackageFeatureID)
        {
            this.Adapter.SelectCommand = this.CommandCollection[5];
            if (CloudPackageID.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[1].Value = CloudPackageID.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[1].Value = DBNull.Value;
            }
            if (PackageModuleID.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[2].Value = PackageModuleID.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[2].Value = DBNull.Value;
            }
            if (PackageFeatureID.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[3].Value = PackageFeatureID.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[3].Value = DBNull.Value;
            }
            CloudAccountDA.CloudPackageDetailsDataTable dataTable = new CloudAccountDA.CloudPackageDetailsDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter")]
        public virtual CloudAccountDA.CloudPackageDetailsDataTable GetDataByPackageModuleID(int? PackageModuleID)
        {
            this.Adapter.SelectCommand = this.CommandCollection[6];
            if (PackageModuleID.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[1].Value = PackageModuleID.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[1].Value = DBNull.Value;
            }
            CloudAccountDA.CloudPackageDetailsDataTable dataTable = new CloudAccountDA.CloudPackageDetailsDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private void InitAdapter()
        {
            this._adapter = new SqlDataAdapter();
            DataTableMapping mapping = new DataTableMapping {
                SourceTable = "Table",
                DataSetTable = "CloudPackageDetails"
            };
            mapping.ColumnMappings.Add("CloudPackageDetailID", "CloudPackageDetailID");
            mapping.ColumnMappings.Add("CloudPackageID", "CloudPackageID");
            mapping.ColumnMappings.Add("PackageModuleID", "PackageModuleID");
            mapping.ColumnMappings.Add("PackageFeatureID", "PackageFeatureID");
            mapping.ColumnMappings.Add("CloudPackageDetailValue", "CloudPackageDetailValue");
            this._adapter.TableMappings.Add(mapping);
            this._adapter.DeleteCommand = new SqlCommand();
            this._adapter.DeleteCommand.Connection = this.Connection;
            this._adapter.DeleteCommand.CommandText = "dbo.PR_CloudPackageDetails_Delete";
            this._adapter.DeleteCommand.CommandType = CommandType.StoredProcedure;
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@CloudPackageDetailID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "CloudPackageDetailID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand = new SqlCommand();
            this._adapter.InsertCommand.Connection = this.Connection;
            this._adapter.InsertCommand.CommandText = "dbo.PR_CloudPackageDetails_Insert";
            this._adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@CloudPackageDetailID", SqlDbType.Int, 4, ParameterDirection.InputOutput, 10, 0, "CloudPackageDetailID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@CloudPackageID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "CloudPackageID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@PackageModuleID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "PackageModuleID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@PackageFeatureID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "PackageFeatureID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@CloudPackageDetailValue", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "CloudPackageDetailValue", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand = new SqlCommand();
            this._adapter.UpdateCommand.Connection = this.Connection;
            this._adapter.UpdateCommand.CommandText = "dbo.PR_CloudPackageDetails_Update";
            this._adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CloudPackageDetailID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "CloudPackageDetailID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CloudPackageID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "CloudPackageID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@PackageModuleID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "PackageModuleID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@PackageFeatureID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "PackageFeatureID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CloudPackageDetailValue", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "CloudPackageDetailValue", DataRowVersion.Current, false, null, "", "", ""));
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private void InitCommandCollection()
        {
            this._commandCollection = new SqlCommand[7];
            this._commandCollection[0] = new SqlCommand();
            this._commandCollection[0].Connection = this.Connection;
            this._commandCollection[0].CommandText = "dbo.PR_CloudPackageDetails_SelectAll";
            this._commandCollection[0].CommandType = CommandType.StoredProcedure;
            this._commandCollection[0].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[1] = new SqlCommand();
            this._commandCollection[1].Connection = this.Connection;
            this._commandCollection[1].CommandText = "dbo.PR_CloudPackageDetails_DeleteByCloudPackageID";
            this._commandCollection[1].CommandType = CommandType.StoredProcedure;
            this._commandCollection[1].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[1].Parameters.Add(new SqlParameter("@CloudPackageID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[2] = new SqlCommand();
            this._commandCollection[2].Connection = this.Connection;
            this._commandCollection[2].CommandText = "dbo.PR_CloudPackageDetails_SelectByCloudPackageDetailID";
            this._commandCollection[2].CommandType = CommandType.StoredProcedure;
            this._commandCollection[2].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[2].Parameters.Add(new SqlParameter("@CloudPackageDetailID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[3] = new SqlCommand();
            this._commandCollection[3].Connection = this.Connection;
            this._commandCollection[3].CommandText = "dbo.PR_CloudPackageDetails_SelectByCloudPackageID";
            this._commandCollection[3].CommandType = CommandType.StoredProcedure;
            this._commandCollection[3].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[3].Parameters.Add(new SqlParameter("@CloudPackageID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[4] = new SqlCommand();
            this._commandCollection[4].Connection = this.Connection;
            this._commandCollection[4].CommandText = "dbo.PR_CloudPackageDetails_SelectByPackageFeatureID";
            this._commandCollection[4].CommandType = CommandType.StoredProcedure;
            this._commandCollection[4].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[4].Parameters.Add(new SqlParameter("@PackageFeatureID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[5] = new SqlCommand();
            this._commandCollection[5].Connection = this.Connection;
            this._commandCollection[5].CommandText = "dbo.PR_CloudPackageDetails_SelectByPackageModuleFeatureID";
            this._commandCollection[5].CommandType = CommandType.StoredProcedure;
            this._commandCollection[5].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[5].Parameters.Add(new SqlParameter("@CloudPackageID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[5].Parameters.Add(new SqlParameter("@PackageModuleID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[5].Parameters.Add(new SqlParameter("@PackageFeatureID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[6] = new SqlCommand();
            this._commandCollection[6].Connection = this.Connection;
            this._commandCollection[6].CommandText = "dbo.PR_CloudPackageDetails_SelectByPackageModuleID";
            this._commandCollection[6].CommandType = CommandType.StoredProcedure;
            this._commandCollection[6].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[6].Parameters.Add(new SqlParameter("@PackageModuleID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
        }
        
        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private void InitConnection()
        {
            this._connection = new SqlConnection();
            this._connection.ConnectionString = Settings.Default.IITS_CloudAccountingConnectionString;
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, DataObjectMethod(DataObjectMethodType.Insert, true)]
        public virtual int Insert(ref int? CloudPackageDetailID, int? CloudPackageID, int? PackageModuleID, int? PackageFeatureID, string CloudPackageDetailValue)
        {
            int num2;
            if (CloudPackageDetailID.HasValue)
            {
                this.Adapter.InsertCommand.Parameters[1].Value = CloudPackageDetailID.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[1].Value = DBNull.Value;
            }
            if (CloudPackageID.HasValue)
            {
                this.Adapter.InsertCommand.Parameters[2].Value = CloudPackageID.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[2].Value = DBNull.Value;
            }
            if (PackageModuleID.HasValue)
            {
                this.Adapter.InsertCommand.Parameters[3].Value = PackageModuleID.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[3].Value = DBNull.Value;
            }
            if (PackageFeatureID.HasValue)
            {
                this.Adapter.InsertCommand.Parameters[4].Value = PackageFeatureID.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[4].Value = DBNull.Value;
            }
            if (CloudPackageDetailValue == null)
            {
                this.Adapter.InsertCommand.Parameters[5].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[5].Value = CloudPackageDetailValue;
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
                    CloudPackageDetailID = 0;
                }
                else
                {
                    CloudPackageDetailID = new int?((int) this.Adapter.InsertCommand.Parameters[1].Value);
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
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode]
        public virtual int Update(CloudAccountDA dataSet)
        {
            return this.Adapter.Update(dataSet, "CloudPackageDetails");
        }
        
        [HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual int Update(CloudAccountDA.CloudPackageDetailsDataTable dataTable)
        {
            return this.Adapter.Update(dataTable);
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode]
        public virtual int Update(DataRow dataRow)
        {
            return this.Adapter.Update(new DataRow[] { dataRow });
        }
        
        [HelpKeyword("vs.data.TableAdapter"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        public virtual int Update(DataRow[] dataRows)
        {
            return this.Adapter.Update(dataRows);
        }
        
        [DataObjectMethod(DataObjectMethodType.Update, true), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual int Update(int? CloudPackageDetailID, int? CloudPackageID, int? PackageModuleID, int? PackageFeatureID, string CloudPackageDetailValue)
        {
            int num2;
            if (CloudPackageDetailID.HasValue)
            {
                this.Adapter.UpdateCommand.Parameters[1].Value = CloudPackageDetailID.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[1].Value = DBNull.Value;
            }
            if (CloudPackageID.HasValue)
            {
                this.Adapter.UpdateCommand.Parameters[2].Value = CloudPackageID.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[2].Value = DBNull.Value;
            }
            if (PackageModuleID.HasValue)
            {
                this.Adapter.UpdateCommand.Parameters[3].Value = PackageModuleID.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[3].Value = DBNull.Value;
            }
            if (PackageFeatureID.HasValue)
            {
                this.Adapter.UpdateCommand.Parameters[4].Value = PackageFeatureID.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[4].Value = DBNull.Value;
            }
            if (CloudPackageDetailValue == null)
            {
                this.Adapter.UpdateCommand.Parameters[5].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[5].Value = CloudPackageDetailValue;
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

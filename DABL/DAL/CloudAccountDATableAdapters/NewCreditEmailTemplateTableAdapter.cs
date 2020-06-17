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
    
    [Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), HelpKeyword("vs.data.TableAdapter"), DesignerCategory("code"), ToolboxItem(true), DataObject(true)]
    public class NewCreditEmailTemplateTableAdapter : Component
    {
        private SqlDataAdapter _adapter;
        private bool _clearBeforeFill;
        private SqlCommand[] _commandCollection;
        private SqlConnection _connection;
        private SqlTransaction _transaction;
        
        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public NewCreditEmailTemplateTableAdapter()
        {
            this.ClearBeforeFill = true;
        }
        
        [DataObjectMethod(DataObjectMethodType.Delete, true), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual int Delete(int? NewCreditEmailTemplateID)
        {
            int num2;
            if (NewCreditEmailTemplateID.HasValue)
            {
                this.Adapter.DeleteCommand.Parameters[1].Value = NewCreditEmailTemplateID.Value;
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
        public virtual CloudAccountDA.NewCreditEmailTemplateDataTable DeleteByCompanyID(int? CompanyID)
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
            CloudAccountDA.NewCreditEmailTemplateDataTable dataTable = new CloudAccountDA.NewCreditEmailTemplateDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [DataObjectMethod(DataObjectMethodType.Fill, true), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual int Fill(CloudAccountDA.NewCreditEmailTemplateDataTable dataTable)
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            if (this.ClearBeforeFill)
            {
                dataTable.Clear();
            }
            return this.Adapter.Fill(dataTable);
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, true), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual CloudAccountDA.NewCreditEmailTemplateDataTable GetData()
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            CloudAccountDA.NewCreditEmailTemplateDataTable dataTable = new CloudAccountDA.NewCreditEmailTemplateDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Select, false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual CloudAccountDA.NewCreditEmailTemplateDataTable GetDataByCompanyID(int? CompanyID)
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
            CloudAccountDA.NewCreditEmailTemplateDataTable dataTable = new CloudAccountDA.NewCreditEmailTemplateDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private void InitAdapter()
        {
            this._adapter = new SqlDataAdapter();
            DataTableMapping mapping = new DataTableMapping {
                SourceTable = "Table",
                DataSetTable = "NewCreditEmailTemplate"
            };
            mapping.ColumnMappings.Add("NewCreditEmailTemplateID", "NewCreditEmailTemplateID");
            mapping.ColumnMappings.Add("CompanyID", "CompanyID");
            mapping.ColumnMappings.Add("EmailSubject", "EmailSubject");
            mapping.ColumnMappings.Add("EmailBody", "EmailBody");
            this._adapter.TableMappings.Add(mapping);
            this._adapter.DeleteCommand = new SqlCommand();
            this._adapter.DeleteCommand.Connection = this.Connection;
            this._adapter.DeleteCommand.CommandText = "dbo.PR_NewCreditEmailTemplate_Delete";
            this._adapter.DeleteCommand.CommandType = CommandType.StoredProcedure;
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@NewCreditEmailTemplateID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "NewCreditEmailTemplateID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand = new SqlCommand();
            this._adapter.InsertCommand.Connection = this.Connection;
            this._adapter.InsertCommand.CommandText = "dbo.PR_NewCreditEmailTemplate_Insert";
            this._adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@NewCreditEmailTemplateID", SqlDbType.Int, 4, ParameterDirection.InputOutput, 10, 0, "NewCreditEmailTemplateID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "CompanyID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@EmailSubject", SqlDbType.NVarChar, 500, ParameterDirection.Input, 0, 0, "EmailSubject", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@EmailBody", SqlDbType.NVarChar, 0x7fffffff, ParameterDirection.Input, 0, 0, "EmailBody", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand = new SqlCommand();
            this._adapter.UpdateCommand.Connection = this.Connection;
            this._adapter.UpdateCommand.CommandText = "dbo.PR_NewCreditEmailTemplate_Update";
            this._adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NewCreditEmailTemplateID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "NewCreditEmailTemplateID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "CompanyID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EmailSubject", SqlDbType.NVarChar, 500, ParameterDirection.Input, 0, 0, "EmailSubject", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EmailBody", SqlDbType.NVarChar, 0x7fffffff, ParameterDirection.Input, 0, 0, "EmailBody", DataRowVersion.Current, false, null, "", "", ""));
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private void InitCommandCollection()
        {
            this._commandCollection = new SqlCommand[3];
            this._commandCollection[0] = new SqlCommand();
            this._commandCollection[0].Connection = this.Connection;
            this._commandCollection[0].CommandText = "dbo.PR_NewCreditEmailTemplate_SelectAll";
            this._commandCollection[0].CommandType = CommandType.StoredProcedure;
            this._commandCollection[0].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[1] = new SqlCommand();
            this._commandCollection[1].Connection = this.Connection;
            this._commandCollection[1].CommandText = "dbo.PR_NewCreditEmailTemplate_DeleteByCompanyID";
            this._commandCollection[1].CommandType = CommandType.StoredProcedure;
            this._commandCollection[1].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[1].Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[2] = new SqlCommand();
            this._commandCollection[2].Connection = this.Connection;
            this._commandCollection[2].CommandText = "dbo.PR_NewCreditEmailTemplate_SelectByCompanyID";
            this._commandCollection[2].CommandType = CommandType.StoredProcedure;
            this._commandCollection[2].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[2].Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
        }
        
        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private void InitConnection()
        {
            this._connection = new SqlConnection();
            this._connection.ConnectionString = Settings.Default.IITS_CloudAccountingConnectionString;
        }
        
        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Insert, true)]
        public virtual int Insert(ref int? NewCreditEmailTemplateID, int? CompanyID, string EmailSubject, string EmailBody)
        {
            int num2;
            if (NewCreditEmailTemplateID.HasValue)
            {
                this.Adapter.InsertCommand.Parameters[1].Value = NewCreditEmailTemplateID.Value;
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
            if (EmailSubject == null)
            {
                this.Adapter.InsertCommand.Parameters[3].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[3].Value = EmailSubject;
            }
            if (EmailBody == null)
            {
                this.Adapter.InsertCommand.Parameters[4].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[4].Value = EmailBody;
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
                    NewCreditEmailTemplateID = 0;
                }
                else
                {
                    NewCreditEmailTemplateID = new int?((int) this.Adapter.InsertCommand.Parameters[1].Value);
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
        
        [DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual int Update(CloudAccountDA dataSet)
        {
            return this.Adapter.Update(dataSet, "NewCreditEmailTemplate");
        }
        
        [HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual int Update(CloudAccountDA.NewCreditEmailTemplateDataTable dataTable)
        {
            return this.Adapter.Update(dataTable);
        }
        
        [DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual int Update(DataRow dataRow)
        {
            return this.Adapter.Update(new DataRow[] { dataRow });
        }
        
        [HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual int Update(DataRow[] dataRows)
        {
            return this.Adapter.Update(dataRows);
        }
        
        [DataObjectMethod(DataObjectMethodType.Update, true), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual int Update(int? NewCreditEmailTemplateID, int? CompanyID, string EmailSubject, string EmailBody)
        {
            int num2;
            if (NewCreditEmailTemplateID.HasValue)
            {
                this.Adapter.UpdateCommand.Parameters[1].Value = NewCreditEmailTemplateID.Value;
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
            if (EmailSubject == null)
            {
                this.Adapter.UpdateCommand.Parameters[3].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[3].Value = EmailSubject;
            }
            if (EmailBody == null)
            {
                this.Adapter.UpdateCommand.Parameters[4].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[4].Value = EmailBody;
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

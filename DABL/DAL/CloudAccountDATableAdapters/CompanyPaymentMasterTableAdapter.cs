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
    
    [HelpKeyword("vs.data.TableAdapter"), DesignerCategory("code"), ToolboxItem(true), DataObject(true), Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    public class CompanyPaymentMasterTableAdapter : Component
    {
        private SqlDataAdapter _adapter;
        private bool _clearBeforeFill;
        private SqlCommand[] _commandCollection;
        private SqlConnection _connection;
        private SqlTransaction _transaction;
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        public CompanyPaymentMasterTableAdapter()
        {
            this.ClearBeforeFill = true;
        }
        
        [DataObjectMethod(DataObjectMethodType.Delete, true), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual int Delete(int? CompanyPaymentID)
        {
            int num2;
            if (CompanyPaymentID.HasValue)
            {
                this.Adapter.DeleteCommand.Parameters[1].Value = CompanyPaymentID.Value;
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
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Select, false)]
        public virtual CloudAccountDA.CompanyPaymentMasterDataTable DeleteByCompanyID(int? CompanyID)
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
            CloudAccountDA.CompanyPaymentMasterDataTable dataTable = new CloudAccountDA.CompanyPaymentMasterDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [DebuggerNonUserCode, DataObjectMethod(DataObjectMethodType.Fill, true), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual int Fill(CloudAccountDA.CompanyPaymentMasterDataTable dataTable)
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            if (this.ClearBeforeFill)
            {
                dataTable.Clear();
            }
            return this.Adapter.Fill(dataTable);
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, true), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual CloudAccountDA.CompanyPaymentMasterDataTable GetData()
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            CloudAccountDA.CompanyPaymentMasterDataTable dataTable = new CloudAccountDA.CompanyPaymentMasterDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, DataObjectMethod(DataObjectMethodType.Select, false), HelpKeyword("vs.data.TableAdapter")]
        public virtual CloudAccountDA.CompanyPaymentMasterDataTable GetDataByCloudPackageID(int? CloudPackageID)
        {
            this.Adapter.SelectCommand = this.CommandCollection[2];
            if (CloudPackageID.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[1].Value = CloudPackageID.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[1].Value = DBNull.Value;
            }
            CloudAccountDA.CompanyPaymentMasterDataTable dataTable = new CloudAccountDA.CompanyPaymentMasterDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [DebuggerNonUserCode, DataObjectMethod(DataObjectMethodType.Select, false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual CloudAccountDA.CompanyPaymentMasterDataTable GetDataByCompanyID(int? CompanyID)
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
            CloudAccountDA.CompanyPaymentMasterDataTable dataTable = new CloudAccountDA.CompanyPaymentMasterDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Select, false)]
        public virtual CloudAccountDA.CompanyPaymentMasterDataTable GetDataByCompanyPaymentID(int? CompanyPaymentID)
        {
            this.Adapter.SelectCommand = this.CommandCollection[4];
            if (CompanyPaymentID.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[1].Value = CompanyPaymentID.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[1].Value = DBNull.Value;
            }
            CloudAccountDA.CompanyPaymentMasterDataTable dataTable = new CloudAccountDA.CompanyPaymentMasterDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private void InitAdapter()
        {
            this._adapter = new SqlDataAdapter();
            DataTableMapping mapping = new DataTableMapping {
                SourceTable = "Table",
                DataSetTable = "CompanyPaymentMaster"
            };
            mapping.ColumnMappings.Add("CompanyPaymentID", "CompanyPaymentID");
            mapping.ColumnMappings.Add("CompanyID", "CompanyID");
            mapping.ColumnMappings.Add("CloudPackageID", "CloudPackageID");
            mapping.ColumnMappings.Add("PackageAmount", "PackageAmount");
            mapping.ColumnMappings.Add("Status", "Status");
            mapping.ColumnMappings.Add("ResponseCode", "ResponseCode");
            mapping.ColumnMappings.Add("ResponseMessage", "ResponseMessage");
            mapping.ColumnMappings.Add("TransactionDate", "TransactionDate");
            mapping.ColumnMappings.Add("PaymentMode", "PaymentMode");
            this._adapter.TableMappings.Add(mapping);
            this._adapter.DeleteCommand = new SqlCommand();
            this._adapter.DeleteCommand.Connection = this.Connection;
            this._adapter.DeleteCommand.CommandText = "dbo.PR_CompanyPaymentMaster_Delete";
            this._adapter.DeleteCommand.CommandType = CommandType.StoredProcedure;
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@CompanyPaymentID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "CompanyPaymentID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand = new SqlCommand();
            this._adapter.InsertCommand.Connection = this.Connection;
            this._adapter.InsertCommand.CommandText = "dbo.PR_CompanyPaymentMaster_Insert";
            this._adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@CompanyPaymentID", SqlDbType.Int, 4, ParameterDirection.InputOutput, 10, 0, "CompanyPaymentID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "CompanyID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@CloudPackageID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "CloudPackageID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@PackageAmount", SqlDbType.Money, 8, ParameterDirection.Input, 0x13, 4, "PackageAmount", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Status", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ResponseCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ResponseCode", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ResponseMessage", SqlDbType.NVarChar, 0x3e8, ParameterDirection.Input, 0, 0, "ResponseMessage", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@TransactionDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, 0x10, 0, "TransactionDate", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@PaymentMode", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "PaymentMode", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand = new SqlCommand();
            this._adapter.UpdateCommand.Connection = this.Connection;
            this._adapter.UpdateCommand.CommandText = "dbo.PR_CompanyPaymentMaster_Update";
            this._adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CompanyPaymentID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "CompanyPaymentID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "CompanyID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CloudPackageID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "CloudPackageID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@PackageAmount", SqlDbType.Money, 8, ParameterDirection.Input, 0x13, 4, "PackageAmount", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "Status", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ResponseCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "ResponseCode", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ResponseMessage", SqlDbType.NVarChar, 0x3e8, ParameterDirection.Input, 0, 0, "ResponseMessage", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@TransactionDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, 0x10, 0, "TransactionDate", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@PaymentMode", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "PaymentMode", DataRowVersion.Current, false, null, "", "", ""));
        }
        
        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private void InitCommandCollection()
        {
            this._commandCollection = new SqlCommand[6];
            this._commandCollection[0] = new SqlCommand();
            this._commandCollection[0].Connection = this.Connection;
            this._commandCollection[0].CommandText = "dbo.PR_CompanyPaymentMaster_SelectAll";
            this._commandCollection[0].CommandType = CommandType.StoredProcedure;
            this._commandCollection[0].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[1] = new SqlCommand();
            this._commandCollection[1].Connection = this.Connection;
            this._commandCollection[1].CommandText = "dbo.PR_CompanyPaymentMaster_DeleteByCompanyID";
            this._commandCollection[1].CommandType = CommandType.StoredProcedure;
            this._commandCollection[1].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[1].Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[2] = new SqlCommand();
            this._commandCollection[2].Connection = this.Connection;
            this._commandCollection[2].CommandText = "dbo.PR_CompanyPaymentMaster_SelectByCloudPackageID";
            this._commandCollection[2].CommandType = CommandType.StoredProcedure;
            this._commandCollection[2].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[2].Parameters.Add(new SqlParameter("@CloudPackageID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[3] = new SqlCommand();
            this._commandCollection[3].Connection = this.Connection;
            this._commandCollection[3].CommandText = "dbo.PR_CompanyPaymentMaster_SelectByCompanyID";
            this._commandCollection[3].CommandType = CommandType.StoredProcedure;
            this._commandCollection[3].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[3].Parameters.Add(new SqlParameter("@CompanyID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[4] = new SqlCommand();
            this._commandCollection[4].Connection = this.Connection;
            this._commandCollection[4].CommandText = "dbo.PR_CompanyPaymentMaster_SelectByCompanyPaymentID";
            this._commandCollection[4].CommandType = CommandType.StoredProcedure;
            this._commandCollection[4].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[4].Parameters.Add(new SqlParameter("@CompanyPaymentID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[5] = new SqlCommand();
            this._commandCollection[5].Connection = this.Connection;
            this._commandCollection[5].CommandText = "dbo.PR_CompanyPaymentMaster_UpdateAfterPayment";
            this._commandCollection[5].CommandType = CommandType.StoredProcedure;
            this._commandCollection[5].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[5].Parameters.Add(new SqlParameter("@CompanyPaymentID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[5].Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[5].Parameters.Add(new SqlParameter("@ResponseCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[5].Parameters.Add(new SqlParameter("@ResponseMessage", SqlDbType.NVarChar, 0x3e8, ParameterDirection.Input, 0, 0, null, DataRowVersion.Current, false, null, "", "", ""));
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private void InitConnection()
        {
            this._connection = new SqlConnection();
            this._connection.ConnectionString = Settings.Default.IITS_CloudAccountingConnectionString;
        }
        
        [HelpKeyword("vs.data.TableAdapter"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DataObjectMethod(DataObjectMethodType.Insert, true), DebuggerNonUserCode]
        public virtual int Insert(ref int? CompanyPaymentID, int? CompanyID, int? CloudPackageID, decimal? PackageAmount, string Status, string ResponseCode, string ResponseMessage, DateTime? TransactionDate, string PaymentMode)
        {
            int num2;
            if (CompanyPaymentID.HasValue)
            {
                this.Adapter.InsertCommand.Parameters[1].Value = CompanyPaymentID.Value;
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
            if (CloudPackageID.HasValue)
            {
                this.Adapter.InsertCommand.Parameters[3].Value = CloudPackageID.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[3].Value = DBNull.Value;
            }
            if (PackageAmount.HasValue)
            {
                this.Adapter.InsertCommand.Parameters[4].Value = PackageAmount.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[4].Value = DBNull.Value;
            }
            if (Status == null)
            {
                this.Adapter.InsertCommand.Parameters[5].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[5].Value = Status;
            }
            if (ResponseCode == null)
            {
                this.Adapter.InsertCommand.Parameters[6].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[6].Value = ResponseCode;
            }
            if (ResponseMessage == null)
            {
                this.Adapter.InsertCommand.Parameters[7].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[7].Value = ResponseMessage;
            }
            if (TransactionDate.HasValue)
            {
                this.Adapter.InsertCommand.Parameters[8].Value = TransactionDate.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[8].Value = DBNull.Value;
            }
            if (PaymentMode == null)
            {
                this.Adapter.InsertCommand.Parameters[9].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[9].Value = PaymentMode;
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
                    CompanyPaymentID = 0;
                }
                else
                {
                    CompanyPaymentID = new int?((int) this.Adapter.InsertCommand.Parameters[1].Value);
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
            return this.Adapter.Update(dataSet, "CompanyPaymentMaster");
        }
        
        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual int Update(CloudAccountDA.CompanyPaymentMasterDataTable dataTable)
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
        
        [DataObjectMethod(DataObjectMethodType.Update, true), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode]
        public virtual int Update(int? CompanyPaymentID, int? CompanyID, int? CloudPackageID, decimal? PackageAmount, string Status, string ResponseCode, string ResponseMessage, DateTime? TransactionDate, string PaymentMode)
        {
            int num2;
            if (CompanyPaymentID.HasValue)
            {
                this.Adapter.UpdateCommand.Parameters[1].Value = CompanyPaymentID.Value;
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
            if (CloudPackageID.HasValue)
            {
                this.Adapter.UpdateCommand.Parameters[3].Value = CloudPackageID.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[3].Value = DBNull.Value;
            }
            if (PackageAmount.HasValue)
            {
                this.Adapter.UpdateCommand.Parameters[4].Value = PackageAmount.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[4].Value = DBNull.Value;
            }
            if (Status == null)
            {
                this.Adapter.UpdateCommand.Parameters[5].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[5].Value = Status;
            }
            if (ResponseCode == null)
            {
                this.Adapter.UpdateCommand.Parameters[6].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[6].Value = ResponseCode;
            }
            if (ResponseMessage == null)
            {
                this.Adapter.UpdateCommand.Parameters[7].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[7].Value = ResponseMessage;
            }
            if (TransactionDate.HasValue)
            {
                this.Adapter.UpdateCommand.Parameters[8].Value = TransactionDate.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[8].Value = DBNull.Value;
            }
            if (PaymentMode == null)
            {
                this.Adapter.UpdateCommand.Parameters[9].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[9].Value = PaymentMode;
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
        public virtual CloudAccountDA.CompanyPaymentMasterDataTable UpdateAfterPayment(int? CompanyPaymentID, string Status, string ResponseCode, string ResponseMessage)
        {
            this.Adapter.SelectCommand = this.CommandCollection[5];
            if (CompanyPaymentID.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[1].Value = CompanyPaymentID.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[1].Value = DBNull.Value;
            }
            if (Status == null)
            {
                this.Adapter.SelectCommand.Parameters[2].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[2].Value = Status;
            }
            if (ResponseCode == null)
            {
                this.Adapter.SelectCommand.Parameters[3].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[3].Value = ResponseCode;
            }
            if (ResponseMessage == null)
            {
                this.Adapter.SelectCommand.Parameters[4].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[4].Value = ResponseMessage;
            }
            CloudAccountDA.CompanyPaymentMasterDataTable dataTable = new CloudAccountDA.CompanyPaymentMasterDataTable();
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

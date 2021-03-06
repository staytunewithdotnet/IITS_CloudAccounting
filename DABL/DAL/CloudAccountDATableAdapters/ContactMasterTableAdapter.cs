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
    
    [Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), DataObject(true), HelpKeyword("vs.data.TableAdapter"), DesignerCategory("code"), ToolboxItem(true)]
    public class ContactMasterTableAdapter : Component
    {
        private SqlDataAdapter _adapter;
        private bool _clearBeforeFill;
        private SqlCommand[] _commandCollection;
        private SqlConnection _connection;
        private SqlTransaction _transaction;
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        public ContactMasterTableAdapter()
        {
            this.ClearBeforeFill = true;
        }
        
        [DebuggerNonUserCode, DataObjectMethod(DataObjectMethodType.Delete, true), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual int Delete(int? ContactID)
        {
            int num2;
            if (ContactID.HasValue)
            {
                this.Adapter.DeleteCommand.Parameters[1].Value = ContactID.Value;
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
        
        [HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DataObjectMethod(DataObjectMethodType.Fill, true)]
        public virtual int Fill(CloudAccountDA.ContactMasterDataTable dataTable)
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            if (this.ClearBeforeFill)
            {
                dataTable.Clear();
            }
            return this.Adapter.Fill(dataTable);
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode, DataObjectMethod(DataObjectMethodType.Select, true), HelpKeyword("vs.data.TableAdapter")]
        public virtual CloudAccountDA.ContactMasterDataTable GetData()
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            CloudAccountDA.ContactMasterDataTable dataTable = new CloudAccountDA.ContactMasterDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [DebuggerNonUserCode, DataObjectMethod(DataObjectMethodType.Select, false), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual CloudAccountDA.ContactMasterDataTable GetDataByContactID(int? ContactID)
        {
            this.Adapter.SelectCommand = this.CommandCollection[1];
            if (ContactID.HasValue)
            {
                this.Adapter.SelectCommand.Parameters[1].Value = ContactID.Value;
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[1].Value = DBNull.Value;
            }
            CloudAccountDA.ContactMasterDataTable dataTable = new CloudAccountDA.ContactMasterDataTable();
            this.Adapter.Fill(dataTable);
            return dataTable;
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private void InitAdapter()
        {
            this._adapter = new SqlDataAdapter();
            DataTableMapping mapping = new DataTableMapping {
                SourceTable = "Table",
                DataSetTable = "ContactMaster"
            };
            mapping.ColumnMappings.Add("ContactID", "ContactID");
            mapping.ColumnMappings.Add("CompanyName", "CompanyName");
            mapping.ColumnMappings.Add("ContactPerson", "ContactPerson");
            mapping.ColumnMappings.Add("Address1", "Address1");
            mapping.ColumnMappings.Add("Address2", "Address2");
            mapping.ColumnMappings.Add("Address3", "Address3");
            mapping.ColumnMappings.Add("Address4", "Address4");
            mapping.ColumnMappings.Add("ZipCode", "ZipCode");
            mapping.ColumnMappings.Add("City", "City");
            mapping.ColumnMappings.Add("State", "State");
            mapping.ColumnMappings.Add("Country", "Country");
            mapping.ColumnMappings.Add("Phone1", "Phone1");
            mapping.ColumnMappings.Add("Phone2", "Phone2");
            mapping.ColumnMappings.Add("Fax1", "Fax1");
            mapping.ColumnMappings.Add("Fax2", "Fax2");
            mapping.ColumnMappings.Add("Mobile1", "Mobile1");
            mapping.ColumnMappings.Add("Mobile2", "Mobile2");
            mapping.ColumnMappings.Add("Email1", "Email1");
            mapping.ColumnMappings.Add("Email2", "Email2");
            mapping.ColumnMappings.Add("Website", "Website");
            mapping.ColumnMappings.Add("GoogleMapCode", "GoogleMapCode");
            mapping.ColumnMappings.Add("Status", "Status");
            this._adapter.TableMappings.Add(mapping);
            this._adapter.DeleteCommand = new SqlCommand();
            this._adapter.DeleteCommand.Connection = this.Connection;
            this._adapter.DeleteCommand.CommandText = "dbo.PR_ContactMaster_Delete";
            this._adapter.DeleteCommand.CommandType = CommandType.StoredProcedure;
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@ContactID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "ContactID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand = new SqlCommand();
            this._adapter.InsertCommand.Connection = this.Connection;
            this._adapter.InsertCommand.CommandText = "dbo.PR_ContactMaster_Insert";
            this._adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ContactID", SqlDbType.Int, 4, ParameterDirection.InputOutput, 10, 0, "ContactID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@CompanyName", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, "CompanyName", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ContactPerson", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "ContactPerson", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Address1", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "Address1", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Address2", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "Address2", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Address3", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "Address3", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Address4", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "Address4", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ZipCode", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "ZipCode", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@City", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "City", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@State", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "State", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Country", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "Country", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Phone1", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "Phone1", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Phone2", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "Phone2", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Fax1", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "Fax1", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Fax2", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "Fax2", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Mobile1", SqlDbType.VarChar, 15, ParameterDirection.Input, 0, 0, "Mobile1", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Mobile2", SqlDbType.VarChar, 15, ParameterDirection.Input, 0, 0, "Mobile2", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Email1", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "Email1", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Email2", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "Email2", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Website", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "Website", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@GoogleMapCode", SqlDbType.NVarChar, 0x7fffffff, ParameterDirection.Input, 0, 0, "GoogleMapCode", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Status", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, "Status", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand = new SqlCommand();
            this._adapter.UpdateCommand.Connection = this.Connection;
            this._adapter.UpdateCommand.CommandText = "dbo.PR_ContactMaster_Update";
            this._adapter.UpdateCommand.CommandType = CommandType.StoredProcedure;
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ContactID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, "ContactID", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CompanyName", SqlDbType.VarChar, 100, ParameterDirection.Input, 0, 0, "CompanyName", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ContactPerson", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "ContactPerson", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Address1", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "Address1", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Address2", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "Address2", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Address3", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "Address3", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Address4", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "Address4", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ZipCode", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "ZipCode", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@City", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "City", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@State", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "State", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Country", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "Country", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Phone1", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "Phone1", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Phone2", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "Phone2", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Fax1", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "Fax1", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Fax2", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "Fax2", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Mobile1", SqlDbType.VarChar, 15, ParameterDirection.Input, 0, 0, "Mobile1", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Mobile2", SqlDbType.VarChar, 15, ParameterDirection.Input, 0, 0, "Mobile2", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Email1", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "Email1", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Email2", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "Email2", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Website", SqlDbType.VarChar, 50, ParameterDirection.Input, 0, 0, "Website", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@GoogleMapCode", SqlDbType.NVarChar, 0x7fffffff, ParameterDirection.Input, 0, 0, "GoogleMapCode", DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Status", SqlDbType.Bit, 1, ParameterDirection.Input, 1, 0, "Status", DataRowVersion.Current, false, null, "", "", ""));
        }
        
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        private void InitCommandCollection()
        {
            this._commandCollection = new SqlCommand[2];
            this._commandCollection[0] = new SqlCommand();
            this._commandCollection[0].Connection = this.Connection;
            this._commandCollection[0].CommandText = "dbo.PR_ContactMaster_SelectAll";
            this._commandCollection[0].CommandType = CommandType.StoredProcedure;
            this._commandCollection[0].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[1] = new SqlCommand();
            this._commandCollection[1].Connection = this.Connection;
            this._commandCollection[1].CommandText = "dbo.PR_ContactMaster_SelectByContactID";
            this._commandCollection[1].CommandType = CommandType.StoredProcedure;
            this._commandCollection[1].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
            this._commandCollection[1].Parameters.Add(new SqlParameter("@ContactID", SqlDbType.Int, 4, ParameterDirection.Input, 10, 0, null, DataRowVersion.Current, false, null, "", "", ""));
        }
        
        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private void InitConnection()
        {
            this._connection = new SqlConnection();
            this._connection.ConnectionString = Settings.Default.IITS_CloudAccountingConnectionString;
        }
        
        [DebuggerNonUserCode, DataObjectMethod(DataObjectMethodType.Insert, true), HelpKeyword("vs.data.TableAdapter"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual int Insert(ref int? ContactID, string CompanyName, string ContactPerson, string Address1, string Address2, string Address3, string Address4, string ZipCode, string City, string State, string Country, string Phone1, string Phone2, string Fax1, string Fax2, string Mobile1, string Mobile2, string Email1, string Email2, string Website, string GoogleMapCode, bool? Status)
        {
            int num2;
            if (ContactID.HasValue)
            {
                this.Adapter.InsertCommand.Parameters[1].Value = ContactID.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[1].Value = DBNull.Value;
            }
            if (CompanyName == null)
            {
                this.Adapter.InsertCommand.Parameters[2].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[2].Value = CompanyName;
            }
            if (ContactPerson == null)
            {
                this.Adapter.InsertCommand.Parameters[3].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[3].Value = ContactPerson;
            }
            if (Address1 == null)
            {
                this.Adapter.InsertCommand.Parameters[4].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[4].Value = Address1;
            }
            if (Address2 == null)
            {
                this.Adapter.InsertCommand.Parameters[5].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[5].Value = Address2;
            }
            if (Address3 == null)
            {
                this.Adapter.InsertCommand.Parameters[6].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[6].Value = Address3;
            }
            if (Address4 == null)
            {
                this.Adapter.InsertCommand.Parameters[7].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[7].Value = Address4;
            }
            if (ZipCode == null)
            {
                this.Adapter.InsertCommand.Parameters[8].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[8].Value = ZipCode;
            }
            if (City == null)
            {
                this.Adapter.InsertCommand.Parameters[9].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[9].Value = City;
            }
            if (State == null)
            {
                this.Adapter.InsertCommand.Parameters[10].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[10].Value = State;
            }
            if (Country == null)
            {
                this.Adapter.InsertCommand.Parameters[11].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[11].Value = Country;
            }
            if (Phone1 == null)
            {
                this.Adapter.InsertCommand.Parameters[12].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[12].Value = Phone1;
            }
            if (Phone2 == null)
            {
                this.Adapter.InsertCommand.Parameters[13].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[13].Value = Phone2;
            }
            if (Fax1 == null)
            {
                this.Adapter.InsertCommand.Parameters[14].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[14].Value = Fax1;
            }
            if (Fax2 == null)
            {
                this.Adapter.InsertCommand.Parameters[15].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[15].Value = Fax2;
            }
            if (Mobile1 == null)
            {
                this.Adapter.InsertCommand.Parameters[0x10].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[0x10].Value = Mobile1;
            }
            if (Mobile2 == null)
            {
                this.Adapter.InsertCommand.Parameters[0x11].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[0x11].Value = Mobile2;
            }
            if (Email1 == null)
            {
                this.Adapter.InsertCommand.Parameters[0x12].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[0x12].Value = Email1;
            }
            if (Email2 == null)
            {
                this.Adapter.InsertCommand.Parameters[0x13].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[0x13].Value = Email2;
            }
            if (Website == null)
            {
                this.Adapter.InsertCommand.Parameters[20].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[20].Value = Website;
            }
            if (GoogleMapCode == null)
            {
                this.Adapter.InsertCommand.Parameters[0x15].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[0x15].Value = GoogleMapCode;
            }
            if (Status.HasValue)
            {
                this.Adapter.InsertCommand.Parameters[0x16].Value = Status.Value;
            }
            else
            {
                this.Adapter.InsertCommand.Parameters[0x16].Value = DBNull.Value;
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
                    ContactID = 0;
                }
                else
                {
                    ContactID = new int?((int) this.Adapter.InsertCommand.Parameters[1].Value);
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
            return this.Adapter.Update(dataSet, "ContactMaster");
        }
        
        [HelpKeyword("vs.data.TableAdapter"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        public virtual int Update(CloudAccountDA.ContactMasterDataTable dataTable)
        {
            return this.Adapter.Update(dataTable);
        }
        
        [HelpKeyword("vs.data.TableAdapter"), DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public virtual int Update(DataRow dataRow)
        {
            return this.Adapter.Update(new DataRow[] { dataRow });
        }
        
        [HelpKeyword("vs.data.TableAdapter"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DebuggerNonUserCode]
        public virtual int Update(DataRow[] dataRows)
        {
            return this.Adapter.Update(dataRows);
        }
        
        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Update, true)]
        public virtual int Update(int? ContactID, string CompanyName, string ContactPerson, string Address1, string Address2, string Address3, string Address4, string ZipCode, string City, string State, string Country, string Phone1, string Phone2, string Fax1, string Fax2, string Mobile1, string Mobile2, string Email1, string Email2, string Website, string GoogleMapCode, bool? Status)
        {
            int num2;
            if (ContactID.HasValue)
            {
                this.Adapter.UpdateCommand.Parameters[1].Value = ContactID.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[1].Value = DBNull.Value;
            }
            if (CompanyName == null)
            {
                this.Adapter.UpdateCommand.Parameters[2].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[2].Value = CompanyName;
            }
            if (ContactPerson == null)
            {
                this.Adapter.UpdateCommand.Parameters[3].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[3].Value = ContactPerson;
            }
            if (Address1 == null)
            {
                this.Adapter.UpdateCommand.Parameters[4].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[4].Value = Address1;
            }
            if (Address2 == null)
            {
                this.Adapter.UpdateCommand.Parameters[5].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[5].Value = Address2;
            }
            if (Address3 == null)
            {
                this.Adapter.UpdateCommand.Parameters[6].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[6].Value = Address3;
            }
            if (Address4 == null)
            {
                this.Adapter.UpdateCommand.Parameters[7].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[7].Value = Address4;
            }
            if (ZipCode == null)
            {
                this.Adapter.UpdateCommand.Parameters[8].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[8].Value = ZipCode;
            }
            if (City == null)
            {
                this.Adapter.UpdateCommand.Parameters[9].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[9].Value = City;
            }
            if (State == null)
            {
                this.Adapter.UpdateCommand.Parameters[10].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[10].Value = State;
            }
            if (Country == null)
            {
                this.Adapter.UpdateCommand.Parameters[11].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[11].Value = Country;
            }
            if (Phone1 == null)
            {
                this.Adapter.UpdateCommand.Parameters[12].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[12].Value = Phone1;
            }
            if (Phone2 == null)
            {
                this.Adapter.UpdateCommand.Parameters[13].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[13].Value = Phone2;
            }
            if (Fax1 == null)
            {
                this.Adapter.UpdateCommand.Parameters[14].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[14].Value = Fax1;
            }
            if (Fax2 == null)
            {
                this.Adapter.UpdateCommand.Parameters[15].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[15].Value = Fax2;
            }
            if (Mobile1 == null)
            {
                this.Adapter.UpdateCommand.Parameters[0x10].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[0x10].Value = Mobile1;
            }
            if (Mobile2 == null)
            {
                this.Adapter.UpdateCommand.Parameters[0x11].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[0x11].Value = Mobile2;
            }
            if (Email1 == null)
            {
                this.Adapter.UpdateCommand.Parameters[0x12].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[0x12].Value = Email1;
            }
            if (Email2 == null)
            {
                this.Adapter.UpdateCommand.Parameters[0x13].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[0x13].Value = Email2;
            }
            if (Website == null)
            {
                this.Adapter.UpdateCommand.Parameters[20].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[20].Value = Website;
            }
            if (GoogleMapCode == null)
            {
                this.Adapter.UpdateCommand.Parameters[0x15].Value = DBNull.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[0x15].Value = GoogleMapCode;
            }
            if (Status.HasValue)
            {
                this.Adapter.UpdateCommand.Parameters[0x16].Value = Status.Value;
            }
            else
            {
                this.Adapter.UpdateCommand.Parameters[0x16].Value = DBNull.Value;
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

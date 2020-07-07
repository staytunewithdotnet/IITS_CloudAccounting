namespace DABL.Common
{
    using DABL.Properties;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Net.NetworkInformation;
    using System.Text.RegularExpressions;

    public class Dbutility
    {
        string strConnectionString;
        public Dbutility()
        {
            strConnectionString = Settings.Default.IITS_CloudAccountingConnectionString;
        }

        public string ReturnSingleValue(string strSQL)
        {
            string strValue = "";
            SqlConnection conValue = new SqlConnection();
            SqlCommand cmdValue = new SqlCommand();
            conValue.ConnectionString = strConnectionString;//ConfigurationManager.AppSettings.Get("Connectionstring");
            conValue.Open();
            cmdValue.Connection = conValue;
            cmdValue.CommandText = strSQL;
            SqlDataReader rdrValue = cmdValue.ExecuteReader();
            if (rdrValue.Read())
                strValue = rdrValue.GetValue(0).ToString();
            rdrValue.Close();
            rdrValue.Dispose();
            cmdValue.Dispose();
            conValue.Close();
            conValue.Dispose();
            return strValue;
        }

        public int ReturnNumericValue(string strSQL)
        {


            int intValue = 0;
            SqlConnection conValue = new SqlConnection();
            SqlCommand cmdValue = new SqlCommand();
            conValue.ConnectionString = strConnectionString;//ConfigurationManager.AppSettings.Get("Connectionstring");
            conValue.Open();

            cmdValue.Connection = conValue;
            cmdValue.CommandText = strSQL;
            SqlDataReader rdrValue = cmdValue.ExecuteReader();

            if (rdrValue.Read() == true)
            {
                intValue = Convert.ToInt32(rdrValue.GetValue(0));

            }

            rdrValue.Close();
            rdrValue.Dispose();
            cmdValue.Dispose();
            conValue.Close();
            conValue.Dispose();
            return intValue;

        }

        public void Sp_RunProc(string Sp_Name, SqlParameter[] parameters)
        {
            SqlConnection conExecute = new SqlConnection();
            SqlCommand cmdExecute = new SqlCommand();
            try
            {
                conExecute.ConnectionString = strConnectionString;//ConfigurationManager.AppSettings.Get("Connectionstring");
                if (conExecute.State == ConnectionState.Closed)
                {
                    conExecute.Open();
                }
                SqlCommand Cmd = new SqlCommand(Sp_Name, conExecute);
                for (int i = 0; i < parameters.Length; i++)
                {

                    Cmd.Parameters.Add(parameters.GetValue(i));

                }
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conExecute.Close();
            }

        }

        public string ExecuteQuery(string strSQL)
        {
            SqlTransaction transExecute = null;
            SqlConnection conExecute = new SqlConnection();
            SqlCommand cmdExecute = new SqlCommand();
            string strResult = "";
            try
            {
                conExecute.ConnectionString = strConnectionString;//ConfigurationManager.AppSettings.Get("Connectionstring");
                if (conExecute.State == ConnectionState.Closed)
                    conExecute.Open();
                transExecute = conExecute.BeginTransaction();
                cmdExecute = new SqlCommand(strSQL, conExecute);
                cmdExecute.CommandTimeout = 0;
                cmdExecute.Transaction = transExecute;
                cmdExecute.ExecuteNonQuery();

                transExecute.Commit();
            }
            catch (SqlException sqlex)
            {
                if (transExecute != null)
                {
                    transExecute.Rollback();
                    strResult = sqlex.Message.Replace("'", "");
                }
            }
            catch (Exception ex)
            {
                if (transExecute != null)
                {
                    transExecute.Rollback();
                    strResult = ex.Message.Replace("'", "");
                }
            }
            finally
            {
                cmdExecute.Dispose();
                conExecute.Close();
                conExecute.Dispose();
                GC.Collect();
            }
            return strResult;
        }

        public string ExecuteQueryList(List<string> strSQL)
        {

            SqlTransaction transExecute = null;
            SqlConnection conExecute = new SqlConnection();
            SqlCommand cmdExecute = new SqlCommand();
            string strReturn = "";
            try
            {
                conExecute.ConnectionString = strConnectionString;//ConfigurationManager.AppSettings.Get("Connectionstring");
                if (conExecute.State == ConnectionState.Closed)
                    conExecute.Open();
                transExecute = conExecute.BeginTransaction();
                for (int intLoopVariable = 0; intLoopVariable < strSQL.Count; intLoopVariable++)
                {
                    cmdExecute = new SqlCommand(strSQL[intLoopVariable], conExecute);
                    cmdExecute.Transaction = transExecute;
                    cmdExecute.ExecuteNonQuery();
                }
                cmdExecute.CommandTimeout = 0;
                transExecute.Commit();

            }
            catch (SqlException sqlex)
            {
                if (transExecute != null)
                {
                    transExecute.Rollback();
                    strReturn = sqlex.Message.Replace("'", "");
                }
            }
            catch (Exception ex)
            {
                if (transExecute != null)
                {
                    transExecute.Rollback();
                    strReturn = ex.Message.Replace("'", "");
                }
            }
            finally
            {
                cmdExecute.Dispose();
                cmdExecute.Connection = null;
                conExecute.Close();
                conExecute.Dispose();
                GC.Collect();
            }
            return strReturn;
        }

        public DataSet BindDataSet(string strSQL)
        {
            SqlConnection conGetData = new SqlConnection(strConnectionString);//new SqlConnection(ConfigurationManager.AppSettings.Get("Connectionstring"));
            conGetData.Open();
            SqlCommand cmdGetData = new SqlCommand(strSQL, conGetData);
            cmdGetData.CommandTimeout = 0;
            SqlDataAdapter rdrAdptr = new SqlDataAdapter(cmdGetData);
            DataSet ds = new DataSet();
            rdrAdptr.Fill(ds);
            conGetData.Close();
            conGetData.Dispose();
            rdrAdptr.Dispose();
            return ds;
        }

        public string ExecuteCommandQuery(SqlCommand cmd)
        {
            SqlConnection con = new SqlConnection();
            SqlTransaction transExecute = null;

            string result;
            con.ConnectionString = strConnectionString;//ConfigurationManager.AppSettings.Get("Connectionstring");
            cmd.Connection = con;

            try
            {
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                transExecute = con.BeginTransaction();
                cmd.ExecuteNonQuery();

                transExecute.Commit();
                result = "Success...";
                return result;
            }
            catch (SqlException sqlex)
            {
                if (sqlex.Number == 2627)
                {
                    result = "Duplicate Value can not be inserted...";


                }
                else
                {
                    result = sqlex.Message;
                }
                transExecute.Rollback();
                return result;
            }


            catch (Exception ex)
            {

                result = ex.Message;
                transExecute.Rollback();
                return result;
            }

            finally
            {
                cmd.Dispose();
                cmd.Connection.Close();
                con.Close();
                con.Dispose();
                GC.Collect();
            }

        }

        public decimal ReturnDecimalValue(string strSQL)
        {
            decimal intValue = 0;
            SqlConnection conValue = new SqlConnection();
            SqlCommand cmdValue = new SqlCommand();
            conValue.ConnectionString = strConnectionString;//ConfigurationManager.AppSettings.Get("Connectionstring");
            conValue.Open();

            cmdValue.Connection = conValue;
            cmdValue.CommandText = strSQL;
            SqlDataReader rdrValue = cmdValue.ExecuteReader();

            if (rdrValue.Read() == true)
            {
                intValue = Convert.ToDecimal(rdrValue.GetValue(0));

            }

            rdrValue.Close();
            cmdValue.Dispose();
            conValue.Close();
            conValue.Dispose();
            return intValue;

        }

        public DataTable BindDataTable(string strSQL)
        {
            try
            {
                SqlConnection conGetData = new SqlConnection(strConnectionString);//new SqlConnection(ConfigurationManager.AppSettings.Get("Connectionstring"));
                conGetData.Open();
                SqlCommand cmdGetData = new SqlCommand(strSQL, conGetData);
                cmdGetData.CommandTimeout = 0;
                SqlDataAdapter rdrAdptr = new SqlDataAdapter(cmdGetData);
                DataTable dt = new DataTable();
                rdrAdptr.Fill(dt);
                conGetData.Close();
                conGetData.Dispose();
                rdrAdptr.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

    }
}
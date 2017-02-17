using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement_DAL
{
    public class SqlHelper
    {
        public static SqlConnection getConnection()
        {
            SqlConnection con;

            //if (ConfigurationManager.ConnectionStrings["CMConnectionString"] != null)
            //    con = new SqlConnection(ConfigurationManager.ConnectionStrings["CMConnectionString"].ToString());
            //else
            //{
            //Development Server Connection String
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["CMConnectionString"].ToString());
            con.Open();
            //}

            return con;
        }

        public static void ExecuteSP(object[] dbCallIngrediats)
        {
            SqlCommand cmd = new SqlCommand(dbCallIngrediats[0].ToString(), getConnection());

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 1; i < dbCallIngrediats.Length; i += 2)
                {
                    string parValue = null;
                    if (dbCallIngrediats[i + 1] != null)
                        parValue = dbCallIngrediats[i + 1].ToString();

                    cmd.Parameters.AddWithValue(dbCallIngrediats[i].ToString(), parValue);
                }
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            { throw (ex); }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                    cmd.Dispose();
                }
            }
        }

        public static void ExecuteSPObjectValue(object[] dbCallIngrediats)
        {
            SqlCommand cmd = new SqlCommand(dbCallIngrediats[0].ToString(), getConnection());

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 1; i < dbCallIngrediats.Length; i += 2)
                {
                    if (dbCallIngrediats[i + 1] == null) continue;
                    cmd.Parameters.AddWithValue(dbCallIngrediats[i].ToString(), dbCallIngrediats[i + 1]);
                }
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { throw (ex); }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                    cmd.Dispose();
                }
            }
        }

        public static void ExecuteSPWithType(object[] dbCallIngrediats)
        {
            SqlCommand cmd = new SqlCommand(dbCallIngrediats[0].ToString(), getConnection());

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 1; i < dbCallIngrediats.Length; i += 3)
                {
                    SqlParameter prm = new SqlParameter(dbCallIngrediats[i].ToString(), (SqlDbType)dbCallIngrediats[i + 1]);
                    prm.Value = dbCallIngrediats[i + 2].ToString();
                    cmd.Parameters.Add(prm);
                    cmd.Parameters.AddWithValue(dbCallIngrediats[i].ToString(), dbCallIngrediats[i + 1].ToString());
                }
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { throw ex; }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                    cmd.Dispose();
                }
            }
        }

        public static DataTable ExecuteSPReturnDT(object[] dbCallIngrediats)
        {
            SqlCommand cmd = new SqlCommand(dbCallIngrediats[0].ToString(), getConnection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 1; i < dbCallIngrediats.Length; i += 2)
                {
                    string parValue = null;
                    if (dbCallIngrediats[i + 1] != null)
                        parValue = dbCallIngrediats[i + 1].ToString();

                    cmd.Parameters.AddWithValue(dbCallIngrediats[i].ToString(), parValue);
                }

                da.Fill(dt);
            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                    cmd.Dispose();
                    da.Dispose();
                }
            }
            return dt;
        }

        public static DataSet ExecuteSPReturnDS(object[] dbCallIngrediats)
        {
            SqlCommand cmd = new SqlCommand(dbCallIngrediats[0].ToString(), getConnection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 1; i < dbCallIngrediats.Length; i += 2)
                {
                    string parValue = null;
                    if (dbCallIngrediats[i + 1] != null)
                        parValue = dbCallIngrediats[i + 1].ToString();

                    cmd.Parameters.AddWithValue(dbCallIngrediats[i].ToString(), parValue);
                }

                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                da.Fill(ds);
            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                    cmd.Dispose();
                    da.Dispose();
                }
            }
            return ds;
        }

        public static object ExecuteSPReturnScaler(object[] dbCallIngrediats)
        {
            SqlCommand cmd = new SqlCommand(dbCallIngrediats[0].ToString(), getConnection());
            object ReturnValue = new object();
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 1; i < dbCallIngrediats.Length; i += 2)
                {
                    string parValue = null;
                    if (dbCallIngrediats[i + 1] != null)
                        parValue = dbCallIngrediats[i + 1].ToString();

                    cmd.Parameters.AddWithValue(dbCallIngrediats[i].ToString(), parValue);
                }
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();
                ReturnValue = cmd.ExecuteScalar();
            }
            catch (Exception ex)

            { throw ex; }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                    cmd.Dispose();
                }
            }
            return ReturnValue;
        }

        public static object ExecuteSPReturnString(object[] dbCallIngrediats)
        {
            SqlCommand cmd = new SqlCommand(dbCallIngrediats[0].ToString(), getConnection());
            object ObjValue = string.Empty;
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 1; i < dbCallIngrediats.Length; i += 2)
                {
                    string parValue = null;
                    if (dbCallIngrediats[i + 1] != null)
                        parValue = dbCallIngrediats[i + 1].ToString();

                    cmd.Parameters.AddWithValue(dbCallIngrediats[i].ToString(), parValue);
                }
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();
                ObjValue = cmd.ExecuteScalar();

            }
            catch (Exception ex)
            { ex.Message.ToString(); }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                    cmd.Dispose();
                }
            }
            return ObjValue;
        }

        public static object ExecuteSP_NotStringValue(object[] dbCallIngrediats)
        {
            SqlCommand cmd = new SqlCommand(dbCallIngrediats[0].ToString(), getConnection());
            object rValue = null;
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 1; i < dbCallIngrediats.Length; i += 2)
                {
                    if (dbCallIngrediats[i + 1] == null) continue;
                    cmd.Parameters.AddWithValue(dbCallIngrediats[i].ToString(), dbCallIngrediats[i + 1]);
                }
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();
                rValue = cmd.ExecuteScalar();

            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                    cmd.Dispose();
                }

            }
            return rValue;
        } //Same as Object Value

        public static DataTable ExecuteSP_NotStringValueForDT(object[] dbCallIngrediats)
        {
            SqlCommand cmd = new SqlCommand(dbCallIngrediats[0].ToString(), getConnection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 1; i < dbCallIngrediats.Length; i += 2)
                {
                    if (dbCallIngrediats[i + 1] == null) continue;
                    cmd.Parameters.AddWithValue(dbCallIngrediats[i].ToString(), dbCallIngrediats[i + 1]);
                }
                //cmd.Connection.Open();
                da.Fill(dt);
            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                    cmd.Dispose();
                }
            }
            return dt;
        }

        public static void ExecuteNonQuery(string query, int commandTimeOut = 30)
        {
            SqlCommand cmd = new SqlCommand(query, getConnection());
            try
            {
                cmd.CommandTimeout = commandTimeOut;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { throw (ex); }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                    cmd.Dispose();
                }
            }
        }

        public static DataTable ExecuteSelectDT(string query)
        {
            SqlCommand cmd = new SqlCommand(query, getConnection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                    cmd.Dispose();
                }
            }
            return dt;
        }

        public static DataSet ExecuteSelectDS(string query)
        {
            SqlCommand cmd = new SqlCommand(query, getConnection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
            }
            catch (Exception ex)
            { throw ex; }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                    cmd.Dispose();
                }
            }
            return ds;
        }

    }
}

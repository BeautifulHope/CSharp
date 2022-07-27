using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SQLite;

namespace Simon2
{
    class SQLiteHelper
    {
        public static string ConnectionString = "Data Source=data\\data.db;Pooling=true;FailIfMissing=false";

        private static void PrepareCommand(SQLiteCommand cmd,SQLiteConnection connect,string sqlstr,params SQLiteParameter[] p)
        {
            try
            {
                if (connect.State != ConnectionState.Open)//判断是否连接  
                {
                    connect.Open();
                }

                cmd.Parameters.Clear();
                cmd.Connection = connect;
                cmd.CommandText = sqlstr;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 30;

                if (p != null)
                {
                    foreach (SQLiteParameter parm in p)
                    {
                        cmd.Parameters.AddWithValue(parm.ParameterName, parm.Value);
                    }
                }

            }
            catch (Exception ex)
            {

                return;
            }
        }

        public static DataSet ExecuteQuery(string sqlStr, params SQLiteParameter[] p)
        {
            using (SQLiteConnection connect = new SQLiteConnection(ConnectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand())
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        PrepareCommand(command, connect, sqlStr, p);
                        SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                        da.Fill(ds);
                        return ds;
                        
                    }
                    catch (Exception)
                    {
                        return ds;
                    }
                }
            }
        }

        public static bool ExecSQL(string sqlStr, params SQLiteParameter[] p)
        {
            bool result = true;
            using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand())
                {
                    PrepareCommand(command, conn, sqlStr, p);
                    SQLiteTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        command.Transaction = transaction;
                        command.ExecuteNonQuery();
                        transaction.Commit();
                        result = true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        result = false;
                    }
                }
            }
            return result;
        }

    }
}

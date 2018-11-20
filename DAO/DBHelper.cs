using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace DAO
{
    public class DBHelper
    {
        /*
        //本地数据库连接
        private static string connString = ConfigurationManager.AppSettings["connString"].ToString();
        private static DBHelper instance;
        public static DBHelper GetDbHelper()
        {
            if (instance == null)
            {
                instance = new DBHelper();
            }
            return instance;
        }

        //执行查询，返回dataset
        public DataSet GetDataSet(string SQLquery)
        {
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                DataSet set = new DataSet();
                try
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(SQLquery, connection);
                    adapter.Fill(set, "ds");
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                return set;

            }
        }

        //执行查询
        public int ExecuteSql(string SQLString)
        {
            int id = 0;
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                MySqlCommand sqlcommnd = new MySqlCommand(SQLString, connection);
                connection.Open();
                try
                {
                    id = Convert.ToInt32(sqlcommnd.ExecuteScalar());
                    connection.Dispose();
                    return id;
                }
                catch (MySqlException e)
                {
                    connection.Close();
                    throw new Exception(e.Message.ToString());
                }
            }
        }

        public DataTable QueryDataTable(string SQLString)
        {
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                MySqlCommand cmd = new MySqlCommand(SQLString, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                DataSet dataSet = new DataSet();
                try
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dataSet, "ds");
                    table = (DataTable)dataSet.Tables[0];
                }
                catch
                {
                    return null;
                }
                return table;
            }
        }

        public DataSet GetDataSet(List<string> listSql)
        {
            DataSet ds = new DataSet();
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();
                for (int i = 0; i < listSql.Count; i++)
                {
                    DataTable dt = new DataTable();
                    MySqlCommand cmd = new MySqlCommand(listSql[i], connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    ds.Tables.Add(dt);
                }
                return ds;
            }
        }

        public void ExecuteSqlTran(List<string> listSql)
        {
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                MySqlTransaction tx = connection.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < listSql.Count; n++)
                    {
                        cmd.CommandText = listSql[n].ToString();
                        cmd.ExecuteNonQuery();
                    }
                    tx.Commit();
                }
                catch (MySqlException E)
                {
                    tx.Rollback();
                    throw new Exception(E.Message);
                }
            }
        }

        /// <summary>
        /// 执行SQL语句，返回影响的记录行数
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <returns>int</returns>
        public int Update(string sql)
        {
            int result = -1;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        result = cmd.ExecuteNonQuery();
                        conn.Close();
                        return result;
                    }
                }
            }
            catch
            {
                return 0;
            }
        }


        /// <summary>
        /// 执行一行查询返回结果
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object QueryScalar(string sql)
        {
            object result = null;
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        result = cmd.ExecuteScalar();
                        return result;
                    }
                }
                catch
                {
                    return null;
                }
            }
        }
        */
    }
}

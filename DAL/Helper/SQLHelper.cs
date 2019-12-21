using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL.Helper
{
    public class SQLHelper
    {/// <summary>
    /// 链接字符串
    /// </summary>
        private static readonly string connstring = 
            ConfigurationManager.ConnectionStrings["connstring"].ToString();
        public static int Update(string sql)
        {
            SqlConnection conn = new SqlConnection(connstring);
            SqlCommand cmd = new SqlCommand(sql,conn);
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                conn.Close();
            }
        }
        public static object GetSingleResult(string sql)
        {
            SqlConnection conn = new SqlConnection(connstring);
            SqlCommand cmd = new SqlCommand(sql, conn);

            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                conn.Close();
            }
        }
        public static SqlDataReader GetReader(string sql)
        {
            SqlConnection conn = new SqlConnection(connstring);
            SqlCommand cmd = new SqlCommand(sql,conn);
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception e)
            {
                conn.Close();
                throw e;
            } 
        }
    }
}

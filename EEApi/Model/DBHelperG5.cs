using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace DbAccess
{
    public static class DBHelper
    {

        public static string strConn = "Data Source=.;Initial Catalog=EE;Integrated Security=True";
       // public static string strConn = ConfigurationManager.ConnectionStrings["SQLConnString"].ConnectionString;

        /// <summary>
        /// 增、删、改
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="strConn"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql)
        {
            SqlConnection conn=new SqlConnection(strConn);
            int n=0;
            try 
	        {	        
		        conn.Open();
                SqlCommand cmd=new SqlCommand(sql,conn);
                n=cmd.ExecuteNonQuery();
	        }
	        catch (Exception es)
	        {
		
		        throw es;
	        }
            finally 
            {
                conn.Close();
            }
            return n;
        }

        /// <summary>
        /// 这是执行存储过程的增、删、改
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="strConn">数据库连接字符串</param>
        /// <param name="par">参数数组</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql,SqlParameter[] par)
        {
            SqlConnection conn = new SqlConnection(strConn);
            int n = 0;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(par);
                n = cmd.ExecuteNonQuery();
            }
            catch (Exception es)
            {

                throw es;
            }
            finally
            {
                conn.Close();
            }
            return n;
        }

        /// <summary>
        /// 一行一列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="strConn"></param>
        /// <returns></returns>
        public static int ExecuteScalar(string sql)
        {
            SqlConnection conn = new SqlConnection(strConn);
            int n = 0;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                n = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception es)
            {

                throw es;
            }
            finally
            {
                conn.Close();
            }
            return n;
        }

        /// <summary>
        /// 执行存储过程的一行一列
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="strConn">数据库连接字符串</param>
        /// <param name="par">参数数组</param>
        /// <returns></returns>
        public static int ExecuteScalar(string sql,SqlParameter[] par)
        {
            SqlConnection conn = new SqlConnection(strConn);
            int n = 0;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(par);
                n = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception es)
            {

                throw es;
            }
            finally
            {
                conn.Close();
            }
            return n;
        }

        /// <summary>
        /// 查询表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="strConn"></param>
        /// <returns></returns>
        public static DataTable GetTable(string sql)
        {
            SqlConnection conn=new SqlConnection(strConn);
            DataTable db = new DataTable();
            try
            {
                SqlDataAdapter dap = new SqlDataAdapter(sql, conn);
                dap.Fill(db);
            }
            catch (Exception es)
            {
                
                throw es;
            }
            return db;
        }

        /// <summary>
        /// 使用存储过程填充表填充表，并且同事得到输出参数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="strConn"></param>
        /// <param name="par"></param>
        /// <returns></returns>
        public static DataTable GetTable(string sql,SqlParameter[] par)
        {
            SqlConnection conn = new SqlConnection(strConn);
            DataTable db = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(par);//添加参数
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                dap.Fill(db);
            }
            catch (Exception es)
            {

                throw es;
            }
            return db;
        }
    }
}

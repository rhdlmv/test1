using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlConnection
{
    public static class DataAccessHelper
    {
        /// <summary>
        /// 创建DbCommand对象
        /// </summary>
        /// <returns>DbCommand对象</returns>
        public static DbCommand GetCommand()
        {
            //得到webConfig里面的要引用的名称空间
            string DBProviderName = WebConfigHelper.GetProviderName;
            //得到webConfig里面的链接字符串
            string DBConnectionString = WebConfigHelper.GetConnectionString;

            //数据库工厂类为此数据库创建一个数据库链接对象

            DbProviderFactory dpf = DbProviderFactories.GetFactory(DBProviderName);
            //创建Connection
            DbConnection conn = dpf.CreateConnection();
            conn.ConnectionString = DBConnectionString;
            //创建Command
            DbCommand comm = conn.CreateCommand();
            comm.CommandType = CommandType.Text;
            return comm;
        }

        /// <summary>
        /// 执行查询，返回datatable
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static DataTable ExecuteSelectCommand(DbCommand command)
        {
            DataTable table;
            try
            {
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }
                DbDataReader reader = command.ExecuteReader();
                table = new DataTable();
                table.Load(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                command.Connection.Close();
            }
            return table;

        }
        /// <summary>
        /// 执行update insert del操作
        /// </summary>
        /// <param name="command"></param>
        /// <returns>返回影响行数</returns>
        public static int ExecuteNonQuery(DbCommand command)
        {
            int affectRows = -1;
            try
            {
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }
                affectRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                command.Connection.Close();
            }
            return affectRows;
        }
        /// <summary>
        /// 返回第一列第一行
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static string ExecuteScalar(DbCommand command)
        {
            string value = "";
            try
            {
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }
                value = command.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                command.Connection.Close();
            }
            return value;
        }
    }
}
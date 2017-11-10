using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace DAL
{
    public class TestLinServer
    {
        public static readonly string connstr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        #region 采用Socket方式，测试服务器连接 
        /// <summary> 
        /// 采用Socket方式，测试服务器连接 
        /// </summary> 
        /// <param name="host">服务器主机名或IP</param> 
        /// <param name="port">端口号</param> 
        /// <param name="millisecondsTimeout">等待时间：毫秒</param> 
        /// <returns></returns> 
        public  bool TestConnection(string host, int port, int millisecondsTimeout)
        {
            TcpClient client = new TcpClient();
            try
            {
                var ar = client.BeginConnect(host, port, null, null);
                ar.AsyncWaitHandle.WaitOne(millisecondsTimeout);
                return client.Connected;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                client.Close();
            }
        }
        #endregion
        /// <summary> 
        /// 数据库连接操作，可替换为你自己的程序 
        /// </summary> 
        /// <param name="ConnectionString">连接字符串</param> 
        /// <returns></returns> 
        public List<string> TestConnection(string ConnectionString)
        {
           // bool result = true;
            try
            {
                SqlConnection m_myConnection = new SqlConnection(ConnectionString);
                m_myConnection.Open();
                string sql = "Select Name From Master..SysDatabases order By Name;";
                using (SqlCommand cmd = m_myConnection.CreateCommand())
                {
                    cmd.CommandTimeout = 180;
                    cmd.CommandText = sql;
                    DataSet dataset = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataset);
                    //result = true;
                    m_myConnection.Close();

                    //
                    List<string> lists = new List<string>();

                    for (int i=0;i< dataset.Tables[0].Rows.Count;i++)
                    {
                        lists.Add(dataset.Tables[0].Rows[i][0].ToString());
                       // lists[i] =;

                    }
                   
                    return lists;
                }

            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                List<string> lists = new List<string>();
                lists.Add("连接数据库错误");
                 
                return lists;
            }
           // return result;
        }



        public bool LinServer(string strIP )
        {
            
            if (TestConnection(strIP, 1433, 500))
            {
                ////连接服务器成功 
                ////    MessageBox.Show("连接服务器成功！");
                //// 数据库操作，我这里用了连接测试。
                ////测试连接数据库
                //if (TestConnection(connstr))
                //{
                //    //连接数据库成功 
                //    return true;
                //}
                //else
                //{
                //    //连接数据库失败
                //    return false;
                //}
                return true;
            }
            else
            {
                //   MessageBox.Show("连接服务器失败！");
                return false;
            }
                
        }

    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace JITSystem.BLL
{
    public class TestLinServer
    {
        public static readonly string connstr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        #region 采用Socket方式，测试服务器连接 
        /// <summary> S
        /// 采用Socket方式，测试服务器连接 
        /// </summary> 
        /// <param name="host">服务器主机名或IP</param> 
        /// <param name="port">端口号</param> 
        /// <param name="millisecondsTimeout">等待时间：毫秒</param> 
        /// <returns></returns> 
        public static bool TestConnection(string host, int port, int millisecondsTimeout)
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
        private static bool TestConnection(string ConnectionString)
        {
            bool result = true;
            try
            {
                SqlConnection m_myConnection = new SqlConnection(ConnectionString);
                m_myConnection.Open();
                //数据库操作...... 
                m_myConnection.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                result = false;
            }
            return result;
        }



        public bool LinServer()
        {
            string strCon = "Data Source=192.168.2.8; Initial Catalog=newstarnew;User ID=sa_cambodia;Password=fwx@uy%t;Connect Timeout=0";
            string[] s = connstr.Split(';');
            s = s[0].Split('=');
            //获取IP 
            string strIP = s[1];
            //发送数据，判断是否连接到指定ip  
            if (TestConnection(strIP, 1433, 500))
            {
                //连接成功 
                //    MessageBox.Show("连接服务器成功！");
                // 数据库操作，我这里用了连接测试。可根据你的系统自行修改 
                if (TestConnection(connstr))
                {
                    string[] t = strCon.Split(';');
                    t = t[0].Split('=');
                    //获取IP 
                    string tstrIP = t[1];
                    if (TestConnection(tstrIP, 1433, 500))
                    {
                        //      MessageBox.Show("连接数据库成功！");
                        //连接192.168.2.8成功
                        return true;
                    }
                    else
                    {
                        //    连接192.168.2.8失败;
                        return false;
                    }
                }

                else
                    //     MessageBox.Show("连接数据库失败！");
                    return false;
            }
            else
                //   MessageBox.Show("连接服务器失败！");
                return false;
        }

    }
}

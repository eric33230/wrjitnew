using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Reflection;

namespace DAL
{






    /// <summary>
    /// 数据操作的公共类
    /// </summary>
      class SqlHelper
    {




        public static readonly string connstr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        public static int result;

        public static Object ToDbValue(Object value)
        {
            if(value == null)
            { return DBNull.Value; }
            else
            {
                return value;
            }
        }


        public static Object FromDbValue(Object value)
        {
            if (value == DBNull.Value)
            { return null; }
            else
            {
                return value;
            }
        }


        public static DataTable GetPackingList(string sql)
        {

            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandText = sql;
                    DataSet dataset = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataset);
                    return dataset.Tables[0];
                }
            }
        }
        public static DataTable MTphoto(string sql)
        {

            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandTimeout = 180;
                    cmd.CommandText = sql;
                    DataSet dataset = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataset);
                    return dataset.Tables[0];
                }
            }
        }

        #region 私有的静态的只读的连接字符串  -private static readonly string connStr
        /// <summary>
        /// 私有的静态的只读的连接字符串
        /// </summary>
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        private static readonly string connStr1 = ConfigurationManager.ConnectionStrings["connStr198"].ConnectionString;
        #endregion

        #region  执行操作，返回表对象 + static DataTable ExcuteTable(string sql, params SqlParameter[] ps)
        /// <summary>
        /// 执行操作，返回表对象
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        public static DataTable ExcuteTable(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                //创建数据适配器
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                //添加参数
                da.SelectCommand.Parameters.AddRange(ps);
                //创建数据表
                DataTable dt = new DataTable();
                //填充数据
                da.Fill(dt);
                return dt;
            }
        }
        #endregion

        #region  执行操作，返回表对象 + static DataTable ExcuteTable1(string sql, params SqlParameter[] ps)
        /// <summary>
        /// 执行操作，返回表对象
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        public static DataTable ExcuteTable1(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(connStr1))
            {
                //创建数据适配器
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                //添加参数
                da.SelectCommand.Parameters.AddRange(ps);
                //创建数据表
                DataTable dt = new DataTable();
                //填充数据
                da.Fill(dt);
                return dt;
            }
        }
        #endregion




        #region  执行操作，返回表对象 + static DataTable ExcuteTable1(string sql)
        /// <summary>
        /// 执行操作，返回表对象
        /// </summary>
        /// <param name="sql"></param>   
        /// <returns></returns>
        public static DataTable ExcuteTable1(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connStr1))
            {
                //创建数据适配器
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                // 不需要添加参数
                // da.SelectCommand.Parameters.AddRange(ps);
                //创建数据表
                DataTable dt = new DataTable();
                //填充数据
                da.Fill(dt);
                return dt;
            }
        }
        #endregion




        #region  执行操作，返回表对象 + static DataTable ExcuteTable(string sql)
        /// <summary>
        /// 执行操作，返回表对象
        /// </summary>
        /// <param name="sql"></param>   
        /// <returns></returns>
        public static DataTable ExcuteTable(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandTimeout = 180;
                    cmd.CommandText = sql;
                    DataSet dataset = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataset);
                    return dataset.Tables[0];
                    // return i;
                }





               // //创建数据适配器
               // SqlDataAdapter da = new SqlDataAdapter(sql, conn);
               // // 不需要添加参数
               //// da.SelectCommand.Parameters.AddRange(ps);
               // //创建数据表
               // DataTable dt = new DataTable();
               // //填充数据
               // da.Fill(dt);
               // return dt;
            }
        }
        #endregion




        //返回一行一列字符串
        public static DataTable ExecuteReader(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandTimeout = 180;
                    cmd.CommandText = sql;
                    DataSet dataset = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataset);
                    return dataset.Tables[0];
                    // return i;
                }
            }
        }






        #region 执行增加，删除和修改的操作 -- static int ExecuteNonQuery(string sql, params SqlParameter[] ps)
        /// <summary>
        /// 执行增加，删除和修改的操作
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        ///

        public static int ExecuteNonQuery(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandTimeout = 180;
                   cmd.CommandText = sql;
                   //   SqlCommand comm = new SqlCommand(sql, conn);
                    cmd.Parameters.AddRange(ps);
                    // comm.Parameters.AddRange(ps);
                   return cmd.ExecuteNonQuery();                  
                }
            }
          
        } 


        #endregion

        #region 执行方法，返回结果集的第一个值，T是返回值的类型 -static T ExcuteScalar<T>(string sql, params SqlParameter[] ps)
        /// <summary>
        /// 执行方法，返回结果集的第一个值，T是返回值的类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        public static T ExcuteScalar<T>(string sql, params SqlParameter[] ps)
        {
            

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.CommandTimeout = 0;
                comm.Parameters.AddRange(ps);
                //                return (T)comm.ExecuteScalar();
                object dd= comm.ExecuteScalar();
                //    return (T)dd;

                if (dd == DBNull.Value)
                {
                    return default(T);
                }
                else
                {
                    return (T)comm.ExecuteScalar();
                }
            }
        }
        #endregion



        /// <summary>
        /// Sqlbulkcopies the specified SMS.批量插入到数据库
        /// </summary>
        /// <param name="data">list类型数据.</param>
        /// <param name="sqlconn">数据库连接字符串.</param>
        public static void SqlbulkcopyPackList<T>(List<T> data)
        {
            
            #region 待处理数据初始化处理
            List<PropertyInfo> pList = new List<PropertyInfo>();//创建属性的集合
            DataTable dt = new DataTable();
            //把所有的public属性加入到集合 并添加DataTable的列    
            Array.ForEach<PropertyInfo>(typeof(T).GetProperties(), p => { pList.Add(p); dt.Columns.Add(p.Name, p.PropertyType); });  //获得反射的入口（typeof（）） //要对 array 的每个元素执行的 System.Action。
            foreach (var item in data)
            {
                DataRow row = dt.NewRow(); //创建一个DataRow实例  
                pList.ForEach(p => row[p.Name] = p.GetValue(item, null)); //给row 赋值
                dt.Rows.Add(row); //加入到DataTable    
            }
            #endregion
            #region 批量插入数据库 SqlBulkCopy声明及参数设置

            using (SqlBulkCopy bulkcopy = new SqlBulkCopy(connStr))
            {



                bulkcopy.BulkCopyTimeout = 0;//超时设置
                bulkcopy.DestinationTableName = "doc_PackList";
                bulkcopy.ColumnMappings.Add("Guid", "Guid");
                bulkcopy.ColumnMappings.Add("CustomStyleCode", "CustomStyleCode");
                bulkcopy.ColumnMappings.Add("BoxSize", "BoxSize");
                bulkcopy.ColumnMappings.Add("BOXTONO", "BOXTONO");
                bulkcopy.ColumnMappings.Add("BoxNoTotal", "BoxNoTotal");
                bulkcopy.ColumnMappings.Add("BOXNO", "BOXNO");
                bulkcopy.ColumnMappings.Add("SizeName", "SizeName");
                bulkcopy.ColumnMappings.Add("PerCount", "PerCount");
                bulkcopy.ColumnMappings.Add("TotalCount", "TotalCount");
                bulkcopy.ColumnMappings.Add("CustomStyleName", "CustomStyleName");

                try
                {

                    bulkcopy.WriteToServer(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

          
            }

      #endregion


         }


        public static void SqlbulkcopyPack(DataTable table)
        {


            using (SqlBulkCopy bulkcopy = new SqlBulkCopy(connStr))
            {
                

                bulkcopy.BulkCopyTimeout = 0;//超时设置
                bulkcopy.DestinationTableName = "doc_PackList";
                bulkcopy.ColumnMappings.Add("Guid", "Guid");
                bulkcopy.ColumnMappings.Add("CustomStyleCode", "CustomStyleCode");
                bulkcopy.ColumnMappings.Add("BoxSize", "BoxSize");
                bulkcopy.ColumnMappings.Add("BOXTONO", "BOXTONO");
                bulkcopy.ColumnMappings.Add("BoxNoTotal", "BoxNoTotal");
                bulkcopy.ColumnMappings.Add("BOXNO", "BOXNO");
                bulkcopy.ColumnMappings.Add("SizeName", "SizeName");
                bulkcopy.ColumnMappings.Add("PerCount", "PerCount");
                bulkcopy.ColumnMappings.Add("TotalCount", "TotalCount");
                bulkcopy.ColumnMappings.Add("CustomStyleName", "CustomStyleName");

                try
                {

                    bulkcopy.WriteToServer(table);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }


            }



        }


        public static void SqlBulkCopy(DataTable table)
        {

            using (SqlBulkCopy bulkcopy = new SqlBulkCopy(connStr))
            {
                bulkcopy.BulkCopyTimeout = 0;//超时设置
                bulkcopy.DestinationTableName = "doc_InnerBox";
                bulkcopy.ColumnMappings.Add("Guid", "Guid");
                bulkcopy.ColumnMappings.Add("InnerBarcode", "InnerBarcode");
                bulkcopy.ColumnMappings.Add("StyleCode", "StyleCode");
                bulkcopy.ColumnMappings.Add("Name", "Name");
                bulkcopy.ColumnMappings.Add("Style", "Style");
                bulkcopy.ColumnMappings.Add("Color", "Color");
                bulkcopy.ColumnMappings.Add("Size", "Size");
                bulkcopy.ColumnMappings.Add("Type", "Type");
                bulkcopy.ColumnMappings.Add("NewCode", "NewCode");
                bulkcopy.ColumnMappings.Add("CustomName", "CustomName");

                try
                {
                    bulkcopy.WriteToServer(table);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        public static DataTable GetSizeRun(string sql)
        {

            // string connERPStr = "Data Source=192.168.2.8; Initial Catalog=newstarnew;User ID=sa_cambodia;Password=fwx@uy%t;";
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandTimeout = 180;
                    cmd.CommandText = sql;
                    DataSet dataset = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataset);
                    return dataset.Tables[0];
                }
            }
        }

        public static DataTable getPhoto(string sql)
        {
            string connERPStr = "Data Source=192.168.2.8; Initial Catalog=newstarnew;User ID=sa_cambodia;Password=fwx@uy%t;";
            using (SqlConnection conn = new SqlConnection(connERPStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandTimeout = 180;
                    cmd.CommandText = sql;
                    DataSet dataset = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataset);
                    return dataset.Tables[0];
                }
            }
        }
        public static DataTable IsNotTmp(string sql)
        {

            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandText = sql;
                    DataSet dataset = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataset);
                    return dataset.Tables[0];
                }
            }
        }
        public static DataTable GetStyleCodeInfo(string sql)
        {

            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandText = sql;
                    // cmd.Parameters.AddRange(parameters);
                    DataSet dataset = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataset);
                    return dataset.Tables[0];
                }
            }
        }
        public static int bulkattlist(DataTable table)
        {
            using (SqlBulkCopy bulkcopy = new SqlBulkCopy(connStr, SqlBulkCopyOptions.UseInternalTransaction))
            {
                bulkcopy.BulkCopyTimeout = 0;//超时设置
                bulkcopy.DestinationTableName = "KQ_Data";
                bulkcopy.ColumnMappings.Add("guid", "Guid");
                bulkcopy.ColumnMappings.Add("data", "KQTime");
                bulkcopy.ColumnMappings.Add("userid", "EnrollNo");
                bulkcopy.ColumnMappings.Add("fip", "Machine");

                bulkcopy.SqlRowsCopied += new SqlRowsCopiedEventHandler(OnRowsCopied);
                bulkcopy.NotifyAfter = table.Rows.Count;
                try
                {
                    bulkcopy.WriteToServer(table);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            return result;//要清空

        }
        private static void OnRowsCopied(object sender, SqlRowsCopiedEventArgs args)
        {
            result = Convert.ToInt32(args.RowsCopied);
            //   return args;
            // lblCounter.Text += args.RowsCopied.ToString() + " rows are copied<Br>";
            // TimeSpan copyTime = DateTime.Now - startTime;
            //  lblCounter.Text += "Copy Time:" + copyTime.Seconds.ToString() + "." + copyTime.Milliseconds.ToString() + " seconds";
        }
        public static DataTable getMaterialClass(string sql)
        {
            string connERPStr = "Data Source=192.168.2.8; Initial Catalog=newstarnew;User ID=sa_cambodia;Password=fwx@uy%t;";
            using (SqlConnection conn = new SqlConnection(connERPStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandTimeout = 180;
                    cmd.CommandText = sql;
                    DataSet dataset = new DataSet();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataset);
                    return dataset.Tables[0];
                    // return i;
                }
                
            }
        }

    }

}


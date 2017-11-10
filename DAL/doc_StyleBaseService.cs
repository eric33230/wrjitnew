using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
     public class doc_StyleBaseService
    {

        #region 增加型体大类 - int AddStyleBase(MODEL.doc_StyleBase addStyleBase)
        /// 增加人员信息
        /// </summary>
        /// <param name="addStyleBase"></param>
        /// <returns></returns>
        public int AddStyleBase(MODEL.doc_StyleBase addStyleBase)
        {
            //string sql = "";

          string   sql = @"
    insert into doc_StyleBase(Guid, Style, StyleBase,CustomName,GoodsTypeName,Name,ModelNo,RBcode,MDcode,Editionhandle,Innor,OrderDate,NewCode)
        values(@Guid, @Style, @StyleBase, @CustomName, @GoodsTypeName, @Name, @ModelNo,@RBcode,@MDcode, @Editionhandle, @Innor, @OrderDate, @NewCode)";
        SqlParameter[] ps = {
                                new SqlParameter("Guid",addStyleBase.Guid),
                                new SqlParameter("Style",addStyleBase.Style),
                                new SqlParameter("StyleBase",addStyleBase.StyleBase),
                                new SqlParameter("CustomName",addStyleBase.CustomName),
                                new SqlParameter("GoodsTypeName",addStyleBase.GoodsTypeName),
                                new SqlParameter("Name",addStyleBase.Name),
                                new SqlParameter("@ModelNo",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue( addStyleBase.ModelNo)},
                               new SqlParameter("@RBcode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue( addStyleBase.RBcode)},
                               new SqlParameter("@MDcode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue( addStyleBase.MDcode)},

                                new SqlParameter("Editionhandle",addStyleBase.Editionhandle),
                                new SqlParameter("Innor",addStyleBase.Innor) ,
                                new SqlParameter("OrderDate",addStyleBase.OrderDate),
                               new SqlParameter("NewCode",addStyleBase.NewCode)
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion

        #region 验证型体大类是否存在 -int IsStyleBaseExisits(string name)
        /// <summary>
        ///  形体大类 可能一个工厂型体会有多个客户型体 ,所以判断有没有客户型体Name
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int IsStyleBaseExisits(string name)
        {
       //     string[] mycode = code.Split('/');
         //   string stylebase = mycode[0].ToString().Trim();
            string sql = "select count(*) from doc_StyleBase  where name=@name";
            SqlParameter p1 = new SqlParameter("Name", name);
            return SqlHelper.ExcuteScalar<int>(sql, p1);
        }
        #endregion

        

        #region 获取所有大类信息  - List<MODEL.doc_StyleBase> GetAllStyleBase()
        /// <summary>
        /// 获取所有班级信息
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_StyleBase> GetAllStyleBase()
        {
            string sql = "select * from  doc_StyleBase  order by  CustomName ";
      //      SqlParameter p = new SqlParameter("", );
            DataTable dt = SqlHelper.ExcuteTable(sql);
            List<MODEL.doc_StyleBase> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_StyleBase>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_StyleBase c = new MODEL.doc_StyleBase();
                    LoadDataToList(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }
        #endregion
        
        #region 加载行数据到对象--集合  void LoadDataToList(DataRow dr, MODEL.doc_StyleBase stylebase)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList(DataRow dr, MODEL.doc_StyleBase stylebase)
        {
            stylebase.Guid= (Guid) SqlHelper.FromDbValue( dr["Guid"]);          //GUiD
            stylebase.CustomName = dr["CustomName"].ToString();//客户名称
            stylebase.CustomNameS = dr["CustomNameS"].ToString();//客户名称
            stylebase.Style = (string) SqlHelper.FromDbValue(dr["Style"]);
            stylebase.StyleBase = (string)SqlHelper.FromDbValue(dr["StyleBase"]);
            stylebase.Name = (string) SqlHelper.FromDbValue( dr["Name"]); //客户型体
            stylebase.GoodsTypeName = dr["GoodsTypeName"].ToString(); //鞋型种类名称
            stylebase.Editionhandle = dr["Editionhandle"].ToString();//楦头编号  
            stylebase.Innor = (string)SqlHelper.FromDbValue(dr["Innor"]);            
            stylebase.RBcode = dr["RBcode"].ToString();//RB模号  
            stylebase.MDcode = dr["MDcode"].ToString();//MD模号  
            stylebase.ModelNo = dr["ModelNo"].ToString();//大底编号  
            stylebase.OrderDate = dr["OrderDate"].ToString();//大底编号 
            stylebase.NewCode = (string)SqlHelper.FromDbValue(dr["NewCode"]);
            stylebase.HourQty = (string)SqlHelper.FromDbValue(dr["HourQty"]);

        }
        #endregion


        #region 根據訂單年月获取型體大类的信息  - List<MODEL.doc_StyleBase> GetStyleBaseNewCode(stirng yyyymm,string name)
        /// <summary>
        /// 比較OrderDate and NewCode 就可以知道是否為新型體        /
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_StyleBase> GetStyleBaseNewCode(string yyyymm,string name)
        {
            string sql = @"
          select distinct Name,NewCode=(select distinct OrderDate+' ' from T_StyleCodeInfo  b
            where OrderDate>=@OrderDate 
		    and b.Name=a.Name for XML PATH('') )  
            from T_StyleCodeInfo a
            where OrderDate>=@OrderDate  and Name=@name
            ";
            SqlParameter[] ps = {
                               new SqlParameter("@OrderDate",yyyymm),
                               new SqlParameter("@Name",name)
                                };
            DataTable dt = SqlHelper.ExcuteTable(sql,ps);
            List<MODEL.doc_StyleBase> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_StyleBase>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_StyleBase c = new MODEL.doc_StyleBase();
                    LoadDataToList1(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }
        #endregion

        #region 根據訂單年月获取型體大类年月的信息  -  string GetSBNewCode(string yyyymm, string name)
        /// <summary>
        /// 比較OrderDate and NewCode 就可以知道是否為新型體        /
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
  
        public string GetSBNewCode(string yyyymm, string name)
        {
            string sql = @"
          select distinct NewCode=(select distinct OrderDate+' ' from T_StyleCodeInfo  b
            where OrderDate>=@OrderDate 
		    and b.Name=a.Name for XML PATH('') ) ,Name  
            from T_StyleCodeInfo a
            where OrderDate>=@OrderDate  and Name=@name
            ";
            SqlParameter[] ps = {
                               new SqlParameter("@OrderDate",yyyymm),
                               new SqlParameter("@Name",name)
                                };            


            return SqlHelper.ExcuteScalar<string>(sql, ps);
            
           
        }
        #endregion

        #region 加载行数据到对象--集合  void LoadDataToList1(DataRow dr, MODEL.doc_StyleBase stylebase)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="name"></param>
        /// <param name="newcode"></param>
        public void LoadDataToList1(DataRow dr, MODEL.doc_StyleBase stylebase)
        {
            stylebase.Name = (string) SqlHelper.FromDbValue( dr["Name"]); //客户型体
            stylebase.NewCode = (string) SqlHelper.FromDbValue(dr["NewCode"]);   //新型體的訂單年月
        }
        #endregion


        #region 更新型體大類的newcode日期  - int updateStylebaseNewCode(string name, string newcode)
        /// <summary>
        /// NewCode日期可能後續月份,表示此新型體,後續月份還有,以此判斷新型體會做多久
        /// </summary>
        /// <param name="name , newcode"></param>
        /// <returns></returns>

        public int updateStylebaseNewCode(string name, string newcode)
        {
            string sql = @"
                                    update doc_StyleBase set NewCode=@NewCode  where Name=@Name
                                   ";
            SqlParameter[] ps = {
                             new SqlParameter("@Name",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue( name) },
                             new SqlParameter("@NewCode", SqlDbType.NVarChar) { Value = SqlHelper.ToDbValue(newcode) }      
                                };
                            return SqlHelper.ExecuteNonQuery(sql, ps);      
        }
        #endregion

        #region 更新型體大類  int updateStylebase(string colname, string colvalue,string guid)
        /// <summary>
        ///  传入要更新的栏位名称,栏位值,与唯一的GUID
        ///  
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>

        public int updateStylebase(string colname, string colvalue,string guid)
        {

            string sql = @" update doc_StyleBase set " + colname + "=@" + colname + "  where Guid=@Guid";

            SqlParameter[] ps = {
                             new SqlParameter("@"+colname,colvalue) ,
                             new SqlParameter("@Guid", guid)
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion



        #region  查询型體大类- List<MODEL.doc_StyleBase> SeeStylebase(string stylebase, string style)
        /// <summary>
        /// 
        /// </summary>
        /// <param name=" Newcode,Style,StyleBase,Name , ModelNo"></param>
        /// <returns></returns>

        public List<MODEL.doc_StyleBase> SeeStylebase(string stylebase, string style,string name,string modelno,bool cbdate,string yyyymm)
        {
            string sql = @"
           select  *  from doc_StyleBase     ";
            List<string> listWhere = new List<string>();
            List<SqlParameter> listParameters = new List<SqlParameter>();
            if(stylebase!="")
            {
                listWhere.Add(" StyleBase like @StyleBase ");
                listParameters.Add(new SqlParameter("@StyleBase", "%" + stylebase + "%"));
            }
            if(style!="")
            {
                listWhere.Add(" Style like @Style ");
                listParameters.Add(new SqlParameter("@Style", "%" + style + "%"));
            }
            if (name!= "")
            {
                listWhere.Add(" Name like @Name ");
                listParameters.Add(new SqlParameter("@Name", "%" + name + "%"));
            }
            if (modelno!= "")
            {
                listWhere.Add(" ModelNo like @ModelNo ");
                listParameters.Add(new SqlParameter("@ModelNo", "%" + modelno + "%"));
            }
            if (cbdate)
            {
                listWhere.Add(" NewCode >=@Newcode ");
                listParameters.Add(new SqlParameter("@NewCode", "%" + yyyymm + "%"));
            }

            if (listWhere.Count >0)
            {
                string sqlWhere = string.Join(" and ", listWhere.ToArray());
                sql=sql+" where " + sqlWhere;
            }
              
            DataTable dt = SqlHelper.ExcuteTable(sql,listParameters.ToArray());
            List<MODEL.doc_StyleBase> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.doc_StyleBase>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.doc_StyleBase c = new MODEL.doc_StyleBase();
                    LoadDataToList2(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }
        #endregion

        #region 加载行数据到对象--集合  void LoadDataToList2(DataRow dr, MODEL.doc_StyleBase stylebase)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList2(DataRow dr, MODEL.doc_StyleBase stylebase)
        {
            stylebase.Guid = (Guid)SqlHelper.FromDbValue(dr["Guid"]);          //GUiD
            stylebase.CustomName = dr["CustomName"].ToString();//客户名称
            stylebase.CustomNameS = dr["CustomNameS"].ToString();//客户名称简称..ASICS订单分JR用
            stylebase.Style = (string)SqlHelper.FromDbValue(dr["Style"]);
            stylebase.StyleBase = (string)SqlHelper.FromDbValue(dr["StyleBase"]);
            stylebase.Name = (string)SqlHelper.FromDbValue(dr["Name"]); //客户型体
            stylebase.GoodsTypeName = dr["GoodsTypeName"].ToString(); //鞋型种类名称
            stylebase.Editionhandle = dr["Editionhandle"].ToString();//楦头编号  
            stylebase.Innor = (string)SqlHelper.FromDbValue(dr["Innor"]);
            stylebase.RBcode = dr["RBcode"].ToString();//RB模号  
            stylebase.MDcode = dr["MDcode"].ToString();//MD模号  
            stylebase.ModelNo = dr["ModelNo"].ToString();//大底编号  
            stylebase.OrderDate = dr["OrderDate"].ToString();//大底编号 
            stylebase.NewCode = (string)SqlHelper.FromDbValue(dr["NewCode"]);
            stylebase.HourQty = (string)SqlHelper.FromDbValue(dr["HourQty"]);

        }
        #endregion








    }
}

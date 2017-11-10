using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
//using Microsoft.International.Converters.PinYinConverter;
using System.Security.Cryptography;

namespace BLL
{
    /// <summary>
    /// Person类的业务逻辑层类
    /// </summary>
    public class PersonManager
    {
        //创建一个公共的person类数据访问层对象
        DAL.PersonService ps = new DAL.PersonService();

        public List<string> Login(string PLoginName,string PLoginPWD)
        {
            return ps.Login(PLoginName, PLoginPWD);
        }

//        #region 登录  + bool Login(Person loginPerson, ref string msg)
//            /// <summary>
//            /// 登录
//            /// </summary>
//            /// <param name="loginPerson"></param>
//            /// <returns></returns>
//        public bool Login(Person loginPerson, ref string msg)
//        {

//            return ps.Login(PLoginName);
//            Person p = ps.Login(loginPerson.PLoginName);
//            if (p == null) //这个你输入的用户名压根不存在
//            {
//                msg = "用户名不存在";
//                return false;
//            }
//            else
//            {
//                //protected MD5();  提供了静态的方法来创建对象
//                //MD5 md5 = MD5.Create();
//                //byte[] bytes=md5.ComputeHash(Encoding.UTF8.GetBytes(loginPerson.PPwd));
//                StringBuilder sb = new StringBuilder();
//                //for (int i = 0; i < bytes.Length;i++ )
//                //{
//                //    sb.Append(bytes[i].ToString("X"));  //x就是指定了转换之后的加密字符串是大写还是小写
//                //}
//                //返回的对象的密码是加密过后的密码，与当前加密过后的字符串值进行匹配，在C#里面区分大小写
////                if (p.PPwd ==sb.ToString()) //找到了一个对象，同时密码也匹配，说明存在这个用户，密码也正确
//                   if (p.PPwd == loginPerson.PPwd) //找到了一个对象，同时密码也匹配，说明存在这个用户，密码也正确

//                    {
//                        return true;
//                }
//                else
//                {
//                    msg = "密码错误了";
//                    return false;
//                }
//            }
//        } 
//        #endregion

        #region 获取所有用户信息  -List<Person> GetAllPersonList(bool isDel)
        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <param name="isDel"></param>
        /// <returns></returns>
        public List<Person> GetAllPersonList(bool isDel)
        {
            return ps.GetAllPersonList(isDel);
        } 
        #endregion

        #region 增加人员信息  - int AddPerson(MODEL.Person addPerson)
        /// <summary>
        /// 增加人员信息
        /// </summary>
        /// <param name="addPerson"></param>
        /// <returns></returns>
        public int AddPerson(MODEL.Person addPerson)
        {
            //1.得到拼音
            StringBuilder sb = new StringBuilder();
            foreach (char cname in addPerson.PCName)
            {
                //if (ChineseChar.IsValidChar(cname)) //判断如果是一个有效的中文字符，就进行拼音的获取
                //{
                //    ChineseChar c = new ChineseChar(cname);
                //    System.Collections.ObjectModel.ReadOnlyCollection<string> lists = c.Pinyins;
                //    sb.Append(lists[0].Substring(0, lists[0].Length - 1)); //只是取得其中得到的多种拼音中的每一个,同时去除最后的声调
                //}
                //else //否则就直接获取这个字符
                //{
                //    sb.Append(cname);
                //}
            }
            addPerson.PPYName = sb.ToString();
            //2.得到加密之后的密码
            //addPerson.PPwd= System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(addPerson.PPwd, "md5");
            return ps.AddPerson(addPerson);
        } 
        #endregion

        #region 并不是真正的删除，只是将状态修改为已经删除
        /// <summary>
        /// 并不是真正的删除，只是将状态修改为已经删除 -bool DeletePersonSoftly(int pid)
        /// </summary>
        public bool DeletePersonSoftly(int pid)
        {
            return ps.DeletePersonSoftly(pid) == 1;
        } 
        #endregion

        #region 修改用户信息  -int UpdatePerson(MODEL.Person upPerson)
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="upPerson"></param>
        /// <returns></returns>
        public int UpdatePerson(MODEL.Person upPerson)
        {        
            return ps.UpdatePerson(upPerson);
        }
        #endregion

        #region 查询人员信息  - List<MODEL.Person> SearchPersonList(bool isdel, Dictionary<string, string> dics)
        /// <summary>
        /// 查询人员信息
        /// </summary>
        /// <param name="isdel"></param>
        /// <param name="dics"></param>
        /// <returns></returns>
        public List<MODEL.Person> SearchPersonList(bool isdel, Dictionary<string, string> dics)
        {
            return ps.SearchPersonList(isdel, dics);
        } 
        #endregion

        #region 验证登录名是否已经存在  -bool IsLoginNameExisits(string loginName)
        /// <summary>
        /// 验证登录名是否已经存在
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public bool IsLoginNameExisits(string loginName)
        {
            return ps.IsLoginNameExisits(loginName) == 1;
        } 
        #endregion
    }
}

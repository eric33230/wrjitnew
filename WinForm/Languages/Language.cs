using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace WinForm.Languages
{
    public class Language
    {
   #region 登陆界面
        public string Login_UserName = "";
        public string Login_UserPwd = "";
        public string Login_Login = "";
         #endregion               
 
         protected Dictionary<string, string> DicLanguage = new Dictionary<string, string>();
         public Language()
         {
             XmlLoad(GlobalData.SystemLanguage);
             BindLanguageText();
         }
 
         /// <summary>
         /// 读取XML放到内存
         /// </summary>
         /// <param name="language"></param>
         protected void XmlLoad(string language)
         {
             try
             {
                 XmlDocument doc = new XmlDocument();
                  string address = AppDomain.CurrentDomain.BaseDirectory + "Languages\\" + language + ".xml";

                doc.Load(address);
                 XmlElement root = doc.DocumentElement;
 
                 XmlNodeList nodeLst1 = root.ChildNodes;
                 foreach (XmlNode item in nodeLst1)
                 {
                     DicLanguage.Add(item.Name, item.InnerText);
                 }
             }
             catch (Exception ex)
             {                
                 throw ex;
             }            
         }
 
         public void BindLanguageText()
         {
             Login_UserName = DicLanguage["Login_UserName"];
             Login_UserPwd = DicLanguage["Login_UserPwd"];
             Login_Login = DicLanguage["Login_Login"];
         }




    }
}

using System;
using System.Web;

public partial class Upload : System.Web.UI.Page
{
    //服务器默认保存路径
    private readonly string serverPath = @"./";

    private void Page_Load(object sender, System.EventArgs e)
    {   // 获取 http提交上传的文件, 并改名保存
        foreach (string key in Request.Files.AllKeys)
        {
            HttpPostedFile file = Request.Files[key];
            string newFilename = DateTime.Now.ToString("yyMMddhhmmssffff")
                + file.FileName.Substring(file.FileName.LastIndexOf('.'));

            try
            {   //文件保存并返回相对路径地址
                file.SaveAs(this.serverPath + newFilename);
                Response.Write("upload/" + newFilename);
            }
            catch (Exception)
            {                
            }
        }
    }
}
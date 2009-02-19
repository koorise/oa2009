using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

namespace OAWeb
{
    public partial class FJUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button1.Attributes.Add("onclick", "return Check()");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string TempFileName;    //服务器文件名路径
            TempFileName = Page.MapPath("UploadFile\\" + System.IO.Path.GetFileName(myFile.Value));
            if (File.Exists(TempFileName))  //文件已经存在
            {
                string NoFileExtension; //不包含文件扩展名
                string FileExtension = "";   //文件扩展名
                if (TempFileName.LastIndexOf(".") > 0)
                {
                    //有扩展名
                    NoFileExtension = TempFileName.Substring(0, TempFileName.LastIndexOf("."));
                    FileExtension = System.IO.Path.GetExtension(TempFileName);
                }
                else
                    NoFileExtension = TempFileName;     //没有有扩展名
                for (int i = 1; i < 100; i++)
                {
                    TempFileName = NoFileExtension + Convert.ToString(i) + FileExtension;   //因为文件已经存在，所以为文件改名
                    if (!File.Exists(TempFileName))
                    {
                        myFile.PostedFile.SaveAs(TempFileName);
                        break;
                    }
                }

            }
            else
                myFile.PostedFile.SaveAs(TempFileName);
            //Response.Write(ConfigurationSettings.AppSettings["FCKeditor:UserFilesPath"].ToString());
            //TempFileName=TempFileName.Replace("\\", "\\\\");
            //Response.Write(TempFileName);
            Session["SendNotice_UploadFileName"] = System.IO.Path.GetFileName(myFile.Value);
            Session["SendNotice_SaveFileName"] = System.IO.Path.GetFileName(TempFileName);
            //Response.Write("<script>var sData = dialogArguments;window.close();sData.UploadBind('" + TempFileName + "','" + System.IO.Path.GetFileName(myFile.Value) + "');</script>");
            Response.Write("<script>var sData = dialogArguments;window.close();sData.UploadBind('2');</script>");
        }
    }
}
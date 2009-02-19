using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace OAWeb
{
    public class PageBase : System.Web.UI.Page
    {
        public SqlHelper conn;
        public string strSQL;
        public string PopedomName = "";
        public PageBase()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //

            this.Load += new System.EventHandler(this.Page_Load);
        }
        private void Page_Load(object sender, System.EventArgs e)
        {
            // 在此处放置用户代码以初始化页面
            Common.CheckLogin();
            if (PopedomName != null)
            {
                if (Common.CheckPopedom(PopedomName, "MView") == false)      //判断用户是否有查看权限
                {
                    Session["ShowMsg"] = "您没有权限操作该功能 !";
                    Response.Redirect("ShowMessage.aspx?PreviousPage=Main.aspx");
                    return;
                }
            }
            
            conn = new SqlHelper();
        }
    }
}

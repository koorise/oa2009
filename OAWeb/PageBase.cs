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
            // TODO: �ڴ˴���ӹ��캯���߼�
            //

            this.Load += new System.EventHandler(this.Page_Load);
        }
        private void Page_Load(object sender, System.EventArgs e)
        {
            // �ڴ˴������û������Գ�ʼ��ҳ��
            Common.CheckLogin();
            if (PopedomName != null)
            {
                if (Common.CheckPopedom(PopedomName, "MView") == false)      //�ж��û��Ƿ��в鿴Ȩ��
                {
                    Session["ShowMsg"] = "��û��Ȩ�޲����ù��� !";
                    Response.Redirect("ShowMessage.aspx?PreviousPage=Main.aspx");
                    return;
                }
            }
            
            conn = new SqlHelper();
        }
    }
}

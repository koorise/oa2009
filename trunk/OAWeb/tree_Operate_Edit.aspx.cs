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

namespace OAWeb
{
    public partial class tree_Operate_Edit : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // �ڴ˴������û������Գ�ʼ��ҳ��
            if (!Page.IsPostBack)
            {
                string str_Sql = "select * from department where autoid=" + Request["nodeid"].ToString();
                conn.GetRowRecord(str_Sql,null);
                txt_Node_Name.Text = conn.dr["depart"].ToString();
            }
        }

        protected void imgbtn_Add_Click(object sender, ImageClickEventArgs e)
        {
            conn.ExeSql("update department set depart='"+txt_Node_Name.Text+"' where autoid=" + Request["nodeid"].ToString(),null);
            //ˢ�����������
            Response.Write("<script language=\"javascript\">parent.frames(\"leftFrame\").document.location.reload();window.location.href='tree_Operate.aspx?autoid=" + Request["location"].ToString() + "&nodeid=" + Request["nodeid"].ToString() + "'</script>");
            //Response.Redirect("tree_Operate.aspx?autoid="+Request["location"].ToString()+"&nodeid="+Request["nodeid"].ToString());

        }

        protected void imgbtn_Return_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("tree_Operate.aspx?autoid=" + Request["location"].ToString() + "&nodeid=" + Request["nodeid"].ToString());
        }
    }
}

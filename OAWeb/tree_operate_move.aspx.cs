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
    public partial class tree_operate_move : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // �ڴ˴������û������Գ�ʼ��ҳ��
            if (!Page.IsPostBack)
            {
                string str_Down;
                string str_Mid;
                string str_Top;
                string str_Sql = "select * from department where layid=" + Request["location"].ToString() + " order by order_id";
                conn.BindRepeater(str_Sql,null, rpt_Graduate); // ��ʾѡ�н��ӵ��ӽڵ�
                // top����
                if (Request["itemindex"].ToString() == "0" && Request["operate"] == "top")
                {
                    Response.Redirect("tree_Operate.aspx?autoid=" + Request["location"].ToString());  // ֱ�ӷ���
                }
                if (Request["itemindex"].ToString() != "0" && Request["operate"] == "top")
                {
                    // ��ô�������order_id
                    str_Down = ((Label)rpt_Graduate.Items[int.Parse(Request["itemindex"].ToString())].FindControl("lbl_Order_Id")).Text;
                    str_Mid = str_Down;  // �м����
                    str_Top = ((Label)rpt_Graduate.Items[int.Parse(Request["itemindex"].ToString()) - 1].FindControl("lbl_Order_Id")).Text;
                    // �ı�����order_id
                    str_Sql = "update department set order_id=" + str_Top + " where autoid=" + ((Label)rpt_Graduate.Items[int.Parse(Request["itemindex"].ToString())].FindControl("lbl_NodeId")).Text;
                    conn.ExeSql(str_Sql,null);
                    // �ı�����order_id
                    str_Sql = "update department set order_id=" + str_Mid + " where autoid=" + ((Label)rpt_Graduate.Items[int.Parse(Request["itemindex"].ToString()) - 1].FindControl("lbl_NodeId")).Text;
                    conn.ExeSql(str_Sql,null);
                    // ˢ�����������
                    Response.Write("<script language=\"javascript\">parent.frames(\"leftFrame\").document.location.reload();window.location.href='tree_Operate.aspx?autoid=" + Request["location"].ToString() + "&nodeid=" + Request["nodeid"].ToString() + "'</script>");
                    //Response.Redirect("tree_Operate.aspx?autoid="+Request["location"].ToString()+"&nodeid="+Request["nodeid"].ToString());  
                }

                // down����
                if (Request["itemindex"].ToString() == (rpt_Graduate.Items.Count - 1).ToString() && Request["operate"] == "down")
                {
                    Response.Redirect("tree_Operate.aspx?autoid=" + Request["location"].ToString());  // ֱ�ӷ���
                }
                if (Request["itemindex"].ToString() != (rpt_Graduate.Items.Count - 1).ToString() && Request["operate"] == "down")
                {
                    // ��ô�������order_id
                    str_Top = ((Label)rpt_Graduate.Items[int.Parse(Request["itemindex"].ToString())].FindControl("lbl_Order_Id")).Text;
                    str_Mid = str_Top;  // �м����
                    str_Down = ((Label)rpt_Graduate.Items[int.Parse(Request["itemindex"].ToString()) + 1].FindControl("lbl_Order_Id")).Text;
                    // �ı�����order_id
                    str_Sql = "update department set order_id=" + str_Down + " where autoid=" + ((Label)rpt_Graduate.Items[int.Parse(Request["itemindex"].ToString())].FindControl("lbl_NodeId")).Text;
                    conn.ExeSql(str_Sql,null);
                    // �ı�����order_id
                    str_Sql = "update department set order_id=" + str_Mid + " where autoid=" + ((Label)rpt_Graduate.Items[int.Parse(Request["itemindex"].ToString()) + 1].FindControl("lbl_NodeId")).Text;
                    conn.ExeSql(str_Sql,null);
                    // ˢ�����������
                    Response.Write("<script language=\"javascript\">parent.frames(\"leftFrame\").document.location.reload();window.location.href='tree_Operate.aspx?autoid=" + Request["location"].ToString() + "&nodeid=" + Request["nodeid"].ToString() + "'</script>");
                    //Response.Redirect("tree_Operate.aspx?autoid="+Request["location"].ToString()+"&nodeid="+Request["nodeid"].ToString());  
                }
            }
        }
    }
}

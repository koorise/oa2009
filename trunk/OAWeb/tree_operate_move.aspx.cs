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
            // 在此处放置用户代码以初始化页面
            if (!Page.IsPostBack)
            {
                string str_Down;
                string str_Mid;
                string str_Top;
                string str_Sql = "select * from department where layid=" + Request["location"].ToString() + " order by order_id";
                conn.BindRepeater(str_Sql,null, rpt_Graduate); // 显示选中节子的子节点
                // top操作
                if (Request["itemindex"].ToString() == "0" && Request["operate"] == "top")
                {
                    Response.Redirect("tree_Operate.aspx?autoid=" + Request["location"].ToString());  // 直接返回
                }
                if (Request["itemindex"].ToString() != "0" && Request["operate"] == "top")
                {
                    // 获得传过来的order_id
                    str_Down = ((Label)rpt_Graduate.Items[int.Parse(Request["itemindex"].ToString())].FindControl("lbl_Order_Id")).Text;
                    str_Mid = str_Down;  // 中间变量
                    str_Top = ((Label)rpt_Graduate.Items[int.Parse(Request["itemindex"].ToString()) - 1].FindControl("lbl_Order_Id")).Text;
                    // 改变下面order_id
                    str_Sql = "update department set order_id=" + str_Top + " where autoid=" + ((Label)rpt_Graduate.Items[int.Parse(Request["itemindex"].ToString())].FindControl("lbl_NodeId")).Text;
                    conn.ExeSql(str_Sql,null);
                    // 改变上面order_id
                    str_Sql = "update department set order_id=" + str_Mid + " where autoid=" + ((Label)rpt_Graduate.Items[int.Parse(Request["itemindex"].ToString()) - 1].FindControl("lbl_NodeId")).Text;
                    conn.ExeSql(str_Sql,null);
                    // 刷新左边树导航
                    Response.Write("<script language=\"javascript\">parent.frames(\"leftFrame\").document.location.reload();window.location.href='tree_Operate.aspx?autoid=" + Request["location"].ToString() + "&nodeid=" + Request["nodeid"].ToString() + "'</script>");
                    //Response.Redirect("tree_Operate.aspx?autoid="+Request["location"].ToString()+"&nodeid="+Request["nodeid"].ToString());  
                }

                // down操作
                if (Request["itemindex"].ToString() == (rpt_Graduate.Items.Count - 1).ToString() && Request["operate"] == "down")
                {
                    Response.Redirect("tree_Operate.aspx?autoid=" + Request["location"].ToString());  // 直接返回
                }
                if (Request["itemindex"].ToString() != (rpt_Graduate.Items.Count - 1).ToString() && Request["operate"] == "down")
                {
                    // 获得传过来的order_id
                    str_Top = ((Label)rpt_Graduate.Items[int.Parse(Request["itemindex"].ToString())].FindControl("lbl_Order_Id")).Text;
                    str_Mid = str_Top;  // 中间变量
                    str_Down = ((Label)rpt_Graduate.Items[int.Parse(Request["itemindex"].ToString()) + 1].FindControl("lbl_Order_Id")).Text;
                    // 改变上面order_id
                    str_Sql = "update department set order_id=" + str_Down + " where autoid=" + ((Label)rpt_Graduate.Items[int.Parse(Request["itemindex"].ToString())].FindControl("lbl_NodeId")).Text;
                    conn.ExeSql(str_Sql,null);
                    // 改变下面order_id
                    str_Sql = "update department set order_id=" + str_Mid + " where autoid=" + ((Label)rpt_Graduate.Items[int.Parse(Request["itemindex"].ToString()) + 1].FindControl("lbl_NodeId")).Text;
                    conn.ExeSql(str_Sql,null);
                    // 刷新左边树导航
                    Response.Write("<script language=\"javascript\">parent.frames(\"leftFrame\").document.location.reload();window.location.href='tree_Operate.aspx?autoid=" + Request["location"].ToString() + "&nodeid=" + Request["nodeid"].ToString() + "'</script>");
                    //Response.Redirect("tree_Operate.aspx?autoid="+Request["location"].ToString()+"&nodeid="+Request["nodeid"].ToString());  
                }
            }
        }
    }
}

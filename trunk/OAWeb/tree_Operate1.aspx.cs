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
    public partial class tree_Operate : PageBase
    {
        public tree_Operate()
        {
            //PopedomName = "用户部门设置";   //设置权限名称
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //if (!Public.CheckAuth(1))
                //{
                //    Response.Write("<script>alert('" + "您没有权限使用这个功能！" + "');window.location.href='MainPage.aspx'</script>");
                //    return;
                //}

                if (Request["autoid"] != null)
                {
                    //string str_Location=Request["autoid"].ToString().Substring(0,Request["autoid"].ToString().Length-1);

                    lbl_Curnodeid.Text = Request["autoid"].ToString();
                    //如果是根节点则隐藏imgbtn_DelNode
                    conn.GetRowRecord("select * from Department where AutoID="+Request["autoid"].ToString());
                    if(conn.dr["layid"].ToString()=="0")
                        imgbtn_DelNode.Visible = false;

                }
                //conn.Logon('B',Session["limit_code"],Page); // 判断是否有权限登陆该页面
                // 下面四行是客户段验证，包括判断是否输入文字等
                imgbtn_AddChildNode.Attributes.Add("onclick", "return vdf('admin_Tree.txt_Mytext','请输入节点的内容','r');");
                imgbtn_AddBrotherNode.Attributes.Add("onclick", "return vdf('admin_Tree.txt_Mytext','请输入节点的内容','r');");
                imgbtn_AddRootNode.Attributes.Add("onclick", "return vdf('admin_Tree.txt_Mytext','请输入节点的内容','r');");
                imgbtn_DelNode.Attributes.Add("onclick", "return confirm('您真的要删除吗？')");
                string str_Sql = "select * from  department where EnterpriseID=" + Session["EnterpriseID"].ToString();
                if (conn.GetRowCount(str_Sql) > 0) // 树表存在记录,做遍历操作
                {
                    imgbtn_AddRootNode.Visible = false;

                }
                else // 数表不存在记录,不做遍历操作
                {
                    imgbtn_DelNode.Visible = false;
                    imgbtn_AddBrotherNode.Visible = false;
                    imgbtn_AddChildNode.Visible = false;
                }
                if (conn.GetRowCount(str_Sql) == 0) // 如果数据库表没有存在记录
                {
                    str_Sql = "select * from department where EnterpriseID='" + Session["EnterpriseID"].ToString() + "' order by order_id";
                }
                else
                {
                    str_Sql = "select * from department where layid='" + Request["autoid"].ToString() + "' and EnterpriseID='" + Session["EnterpriseID"].ToString() + "' order by order_id";
                }
                conn.BindRepeater(str_Sql, rpt_Graduate); // 显示选中节子的子节点


            }
        }

        protected void imgbtn_AddChildNode_Click(object sender, ImageClickEventArgs e)
        {
            if (Request["autoid"] == null) // 判断是否选择右边树导航
            {
                conn.JsIsNull("请选择左边导航树节点,再做添加操作!", lbl_Error);
                return;
            }
            // 下面是增加子节点
            conn.AddChildNode("autoid", "order_id", "layid", "depart", "department", lbl_Curnodeid, txt_Mytext, lbl_Error);
            string str_Sql = "select * from department where layid='" + Request["autoid"].ToString() + "' and EnterpriseID='" + Session["EnterpriseID"] + "' order by order_id";
            conn.BindRepeater(str_Sql, rpt_Graduate); // 显示选中节子的子节点
            // 刷新左边树导航
            lbl_Error.Text = "<script language=\"javascript\">parent.frames(\"leftFrame\").document.location.reload();</" + "script>";
        }

        protected void imgbtn_AddBrotherNode_Click(object sender, ImageClickEventArgs e)
        {
            if (Request["autoid"] == null) // 判断是否选择右边树导航
            {
                conn.JsIsNull("请选择左边导航树节点,再做添加操作!", lbl_Error);
                return;
            }
            string str_Sql = "select * from department where autoid=" + lbl_Curnodeid.Text;
            conn.GetRowRecord(str_Sql);
            if (conn.dr["layid"].ToString() == "0")
            {
                conn.JsIsNull("不能给根节点增加兄弟节点,请增加子节点!", lbl_Error); // 判断不能给跟节点增加兄弟节点
                return;
            }
            // 下面是增加兄弟节点
            conn.AddBrotherNode("autoid", "order_id", "layid", "depart", "department", lbl_Curnodeid, txt_Mytext, lbl_Error); // 增加兄弟节点
            str_Sql = "select * from department where layid='" + Request["autoid"].ToString() + "' and EnterpriseID='" + Session["EnterpriseID"] + "' order by order_id";
            conn.BindRepeater(str_Sql, rpt_Graduate); // 显示选中节子的子节点
            // 刷新左边树导航
            lbl_Error.Text = "<script language=\"javascript\">parent.frames(\"leftFrame\").document.location.reload();</" + "script>";
        }

        protected void imgbtn_DelNode_Click(object sender, ImageClickEventArgs e)
        {
            if (Request["autoid"] == null) // 判断是否选择右边树导航
            {
                conn.JsIsNull("请选择右边岗位名称!", lbl_Error);
                return;
            }
            try
            {
                conn.DelTreeViewNode("autoid", "layid", "department", lbl_Curnodeid); // 递归删除节点
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("约束") > 0)
                   System.Web.HttpContext.Current.Session["ShowMsg"] = "删除失败，该记录正被别的模块使用着，请先在别的模块中删除与该记录关联的数据后再删除该记录！";
                else
                    System.Web.HttpContext.Current.Session["ShowMsg"] = "删除失败！";
                return;
            }
            Response.Redirect(Request.Url.LocalPath.Substring((Request.Url.LocalPath.LastIndexOf("/") + 1), Request.Url.LocalPath.Length - Request.Url.LocalPath.LastIndexOf("/") - 1) + "?autoid=" + Session["RootID"].ToString() + "&depart=" + Session["RootText"].ToString() + "&isReload=1");  //zz
            return;
            string str_Sql = "select * from department";
            if (conn.GetRowCount(str_Sql) > 0) // 如果树表中存在记录，就做遍历树等操作
            {
                imgbtn_DelNode.Visible = true;
                imgbtn_AddBrotherNode.Visible = true;
                imgbtn_AddChildNode.Visible = true;
                imgbtn_AddRootNode.Visible = false;
            }
            else // 如果数表中不存在记录,就清空数
            {
                imgbtn_DelNode.Visible = false;
                imgbtn_AddBrotherNode.Visible = false;
                imgbtn_AddChildNode.Visible = false;
                imgbtn_AddRootNode.Visible = true;
            }
            str_Sql = "select * from department where layid='" + Request["autoid"].ToString() + "' and EnterpriseID='" + Session["EnterpriseID"].ToString() + "' order by order_id";
            conn.BindRepeater(str_Sql, rpt_Graduate); // 显示选中节子的子节点
            lbl_Error.Text = "<script language=\"javascript\">parent.frames(\"leftFrame\").document.location.reload();</" + "script>";
        }

        protected void imgbtn_AddRootNode_Click(object sender, ImageClickEventArgs e)
        {
            if (txt_Mytext.Text != "")
            {
                // 下面增加根节点
                string str_Sql = "select * from department";
                conn.Builder(str_Sql); // 开始增加
                conn.dr["order_id"] = 1; // 排序
                conn.dr["layid"] = "0"; // 父接点key值
                conn.dr["depart"] = txt_Mytext.Text; // 接点显示文字
                conn.dr["EnterpriseID"] = Session["EnterpriseID"].ToString();
                conn.ds.Tables[0].Rows.Add(conn.dr);
                conn.myAdapter.Update(conn.ds); // 添加成功
                imgbtn_DelNode.Visible = true;
                imgbtn_AddBrotherNode.Visible = true;
                imgbtn_AddChildNode.Visible = true;
                imgbtn_AddRootNode.Visible = false;
            }
            // 刷新左边树导航
            lbl_Error.Text = "<script language=\"javascript\">parent.frames(\"leftFrame\").document.location.reload();</" + "script>";
        }
    }
}

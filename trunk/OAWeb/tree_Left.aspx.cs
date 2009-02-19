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
    public partial class tree_Left : PageBase
    {
        public tree_Left()
        {
            //PopedomName = "用户部门设置";   //设置权限名称
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string str_Sql = "select * from Department where EnterpriseID='" + Session["EnterpriseID"] + "' order by order_id";
                if (conn.GetRowCount(str_Sql,null) > 0) // 遍历树
                {
                    conn.BindTreeView("autoid", "layid", "depart", str_Sql, "treeFrame", "tree_Operate.aspx", lbl_Curnodeid, TreeView1);
                }
            }
        }

        protected void TreeView1_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {
            lbl_Curnodeid.Text = TreeView1.SelectedValue;
        }
    }
}

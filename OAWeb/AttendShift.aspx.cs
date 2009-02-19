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
    public partial class AttendShift : PageBase
    {
        string TableName = "AttendShift";     //表名
        public AttendShift()
        {
            //PopedomName = "轮班设置";   //设置权限名称
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
            SqlDataSource1.ConnectionString = Session["ConnectionString"].ToString();
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect(TableName + "Add.aspx");
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Del":      //删除数据
                    //conn.ExeSql("delete " + TableName + " where AutoID=" + GridView1.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
                    if (Common.CheckPopedom(PopedomName, "MEdit") == false)      //判断用户是否有查看权限
                    {
                        ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('您没有权限操作该功能 !')", true);
                        return;
                    }
                    else
                    {
                        try
                        {
                            conn.ExeSql("delete " + TableName + " where AutoID=" + e.CommandArgument.ToString(),null);
                        }
                        catch (Exception ex)
                        {
                            if (ex.ToString().IndexOf("约束") > 0)
                                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('删除失败，该记录正被别的模块使用着，请先在别的模块中删除与该记录关联的数据后再删除该记录！')", true);
                            else
                                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('删除失败！" + ex.ToString() + "')", true);
                        }
                    }
                    break;
            }
            GridView1.DataBind();
        }
    }
}
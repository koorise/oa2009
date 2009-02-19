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
using System.Data.SqlClient;


namespace OAWeb
{
    public partial class Role : PageBase
    {
        string TableName = "Role";     //表名
        public Role()
        {
            //PopedomName = "角色权限设置";   //设置权限名称
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
            }
            SqlDataSource1.ConnectionString = Session["ConnectionString"].ToString();
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            switch (e.CommandName)
            {
                case "Sel":
                    Session["SelRoleID"] = GridView1.DataKeys[Convert.ToInt32(e.CommandArgument)]["AutoID"].ToString();
                    Session["IsAdminRole"] = GridView1.DataKeys[Convert.ToInt32(e.CommandArgument)]["IsAdminRole"].ToString();
                    Session["SelRoleName"] = GridView1.DataKeys[Convert.ToInt32(e.CommandArgument)]["RoleName"].ToString();
                    Response.Redirect("RolePopedom.aspx");
                    break;
                case "Del":      //删除数据
                    //conn.ExeSql("delete " + TableName + " where AutoID=" + GridView1.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
                    if (Common.CheckPopedom(PopedomName, "MEdit") == false)      //判断用户是否有查看权限  
                    {
                        ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('您没有权限操作该功能 !')", true);
                    }
                    else
                    {
                        Control cmdControl = e.CommandSource as Control;
                        GridViewRow row = cmdControl.NamingContainer as GridViewRow;
                        string str = row.Cells[2].Text;

                        if (row.Cells[3].Text == "是")
                            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('该角色为系统默认角色不可以删除 !')", true);
                        else
                        {
                            try
                            {
                                SqlParameter[] parameters ={
                                        new SqlParameter("@AutoID",SqlDbType.Int)
                                    };
                                parameters[0].Value = e.CommandArgument.ToString();
                                conn.ExeSql("delete " + TableName + " where AutoID=@AutoID", parameters);
                            }
                            catch (Exception ex)
                            {
                                if (ex.ToString().IndexOf("约束") > 0)
                                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('删除失败，该记录正被别的模块使用着，请先在别的模块中删除与该记录关联的数据后再删除该记录！')", true);
                                else
                                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('删除失败！')", true);
                            }
                        }
                    }
                    break;
            }
            GridView1.DataBind();
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect(TableName + "Add.aspx");
        }
    }
}
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
    public partial class RolePopedom : PageBase
    {
        public RolePopedom()
        {
            //PopedomName = "角色权限设置";   //设置权限名称
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Common.CheckLogin();
            Label1.Text = "[" + Session["SelRoleName"].ToString() + "]的权限设置";
            SqlDataSource1.ConnectionString = Session["ConnectionString"].ToString();
            strSQL = "SELECT * FROM [RolePopedomV] WHERE ([RoleID] = @RoleID) order by PopedomOrder";  
            SqlDataSource1.SelectCommand = strSQL;
            SqlDataSource1.SelectParameters.Clear();
            SqlDataSource1.SelectParameters.Add("RoleID", Session["SelRoleID"].ToString());
            SqlDataSource1.DataBind();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //根据数据库的值给查看和修改的CheckBox赋值 
                CheckBox _CheckBox = (CheckBox)e.Row.FindControl("CheckBox_V");
                if (GridView1.DataKeys[e.Row.RowIndex]["MView"].ToString() == "1")
                {
                    _CheckBox.Checked = true;
                }
                _CheckBox = (CheckBox)e.Row.FindControl("CheckBox_E");
                if (GridView1.DataKeys[e.Row.RowIndex]["MEdit"].ToString() == "1")
                {
                    _CheckBox.Checked = true;
                }
                if (GridView1.DataKeys[e.Row.RowIndex]["MEdit"].ToString() == "-1")
                {
                    _CheckBox.Visible = false;
                }
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                CheckBox ChkBoxSelectAllV = (CheckBox)e.Row.FindControl("ChkBoxSelectAllV");
                ChkBoxSelectAllV.Attributes.Add("onclick", "SelectAll('V')");
                CheckBox ChkBoxSelectAllE = (CheckBox)e.Row.FindControl("ChkBoxSelectAllE");
                ChkBoxSelectAllE.Attributes.Add("onclick", "SelectAll('E')");
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            if (Common.CheckPopedom("角色权限设置", "MEdit") == false)      //判断用户是否有查看权限
            {
                Session["ShowMsg"] = "您没有权限操作该功能 !";
                Response.Redirect("ShowMessage.aspx?PreviousPage=RolePopedom.aspx&Param=AutoID=" + Request.QueryString["AutoID"].ToString() + "$ParentID=" + Request.QueryString["ParentID"].ToString());
                return;
            }
            if (Session["IsAdminRole"].ToString() == "是")
            {
                Session["ShowMsg"] = "该角色为系统默认角色，不可以修改 !";
                Response.Redirect("ShowMessage.aspx?PreviousPage=RolePopedom.aspx&Param=AutoID=" + Request.QueryString["AutoID"].ToString() + "$ParentID=" + Request.QueryString["ParentID"].ToString());
                return;
            }
            string strSQL;
            SqlHelper conn = new SqlHelper();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (GridView1.DataKeys[i]["MView"].ToString() != "2")
                {
                    CheckBox _CheckBox = (CheckBox)GridView1.Rows[i].Cells[1].FindControl("CheckBox_V");
                    if (_CheckBox.Checked)
                    {
                        strSQL = "Update RolePopedom set MView=1 where AutoID=" + GridView1.DataKeys[i]["AutoID"].ToString();
                    }
                    else
                    {
                        strSQL = "Update RolePopedom set MView=0 where AutoID=" + GridView1.DataKeys[i]["AutoID"].ToString();
                    }
                    _CheckBox = (CheckBox)GridView1.Rows[i].Cells[2].FindControl("CheckBox_E");
                    //Response.Write(strSQL+"<br>");
                    conn.ExeSql(strSQL,null);
                    if (_CheckBox.Visible)
                    {
                        if (_CheckBox.Checked)
                            strSQL = "Update RolePopedom set MEdit=1 where AutoID=" + GridView1.DataKeys[i]["AutoID"].ToString();
                        else
                            strSQL = "Update RolePopedom set MEdit=0 where AutoID=" + GridView1.DataKeys[i]["AutoID"].ToString();
                        //Response.Write(strSQL+"<br>");
                        conn.ExeSql(strSQL,null);
                    }
                }
            }
            Session["ShowMsg"] = "保存成功，重新登陆系统后，权限才会生效";
            Response.Redirect("ShowMessage.aspx?PreviousPage=RolePopedom.aspx&Param=AutoID=" + Request.QueryString["AutoID"].ToString() + "$ParentID=" + Request.QueryString["ParentID"].ToString());
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            //Response.Write("<script>window.location.href='Role.aspx'</script>");
            Response.Redirect("Role.aspx");
        }

    }
}
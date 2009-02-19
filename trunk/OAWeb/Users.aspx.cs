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
    public partial class Users : PageBase
    {
        string TableName = "Users";     //表名
        public Users()
        {
            //PopedomName = "用户设置";   //设置权限名称
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataSource1.ConnectionString = Session["ConnectionString"].ToString();
            if (!this.IsPostBack)
            {
                Filter1.XMLFileName = "UsersV.xml";
            }
            DoBindGridView();
        }
        protected void DoBindGridView()
        {
            strSQL = "SELECT * FROM [UsersV] WHERE  [EnterpriseID] =" + Session["EnterpriseID"].ToString();
            if (Filter1.Value != "")
            {
                CheckBox1.Visible = false;
                strSQL += " and " + Filter1.Value;
            }
            else
            {
                CheckBox1.Visible = true;
                if (!CheckBox1.Checked)
                    strSQL += " and IsStop=0";
            }
            strSQL += " ORDER BY AutoID";
            SqlDataSource1.SelectCommand = strSQL;
            SqlDataSource1.DataBind();
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Del":      //删除数据
                    if (Common.CheckPopedom(PopedomName, "MEdit") == false)      //判断用户是否有修改权限
                    {
                        ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('您没有权限操作该功能 !')", true);
                        DoBindGridView();
                        return;
                    }
                    
                    try
                    {
                        strSQL = "delete " + TableName + " where AutoID=@AutoID";
                        SqlParameter[] parameters ={
                                new SqlParameter("@AutoID",SqlDbType.Int)
                            };
                        parameters[0].Value =GridView1.DataKeys[Convert.ToInt32(e.CommandArgument)]["AutoID"].ToString();
                        conn.ExeSql(strSQL, parameters);
                    }
                    catch (Exception ex)
                    {
                        if (ex.ToString().IndexOf("约束") > 0)
                            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('删除失败，该记录正被别的模块使用着，请先在别的模块中删除与该记录关联的数据后再删除该记录！')", true);
                        else
                            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('删除失败！')", true);
                    }

                    break;
            }
            DoBindGridView();
            
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect(TableName + "Add.aspx");
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            LinkButton _LinkButton;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                _LinkButton = (LinkButton)e.Row.FindControl("LinkButton1");
                if (_LinkButton != null)
                {
                    if (_LinkButton.CommandName == "Del")
                        _LinkButton.CommandArgument = e.Row.RowIndex.ToString();
                }
                if (e.Row.Cells[5].Text == "True")
                    e.Row.Cells[5].Text = "是";
                else
                    e.Row.Cells[5].Text = "否";
            } 
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                int m = e.Row.Cells.Count;
                for (int i = 0; i < m - 1; i++)
                    e.Row.Cells.RemoveAt(0);
                e.Row.Cells[0].ColumnSpan = m + 1;
                e.Row.Cells[0].Text = "&nbsp;总共有" + Convert.ToString(((DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty)).Count) + "条记录；" + "当前页为：" + Convert.ToString(GridView1.PageIndex + 1) + "；总共：" + Convert.ToString(GridView1.PageCount) + "页；每页" + Convert.ToString(GridView1.PageSize) + "条记录";
            }
        }

        protected void OnConditionChanged(object sender, EventArgs e)
        {
            GridView1.PageIndex = 0;
            DoBindGridView();
        }

        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {
            DoBindGridView();
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            GridView1.PageIndex = 0;
            DoBindGridView();
        }
    }
}

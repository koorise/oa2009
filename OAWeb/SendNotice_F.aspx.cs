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
using System.IO;

namespace OAWeb
{
    public partial class SendNotice_F : PageBase
    {
        public SendNotice_F()
        {
            //PopedomName = "已发通知";   //设置权限名称
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //删除意外断电而没有删除的记录
                conn.ExeSql("delete SendNotice where SendTime is null",null);
            }
            SqlDataSource1.ConnectionString = Session["ConnectionString"].ToString();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                int m = e.Row.Cells.Count;
                for (int i = 0; i < m - 1; i++)
                    e.Row.Cells.RemoveAt(0);
                e.Row.Cells[0].ColumnSpan = m + 1;
                e.Row.Cells[0].Text = "&nbsp;总共有" + Convert.ToString(((DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty)).Count) + "条记录；" + "当前页为：" + Convert.ToString(GridView1.PageIndex + 1) + "；总共：" + Convert.ToString(GridView1.PageCount) + "页；每页" + Convert.ToString(GridView1.PageSize) + "条记录";
            }
        }
        protected void DDLSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sel")
            {
                Response.Redirect("SendNotice_S.aspx?AutoID=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "Sel1")
            {
                Response.Redirect("SendNotice_V.aspx?AutoID=" + GridView1.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
            }
            if (e.CommandName == "Del")
            {
                //先删除附件
                conn.GetReader("select * from SendNotice_FJ where SendNoticeID=" + e.CommandArgument.ToString(),null);
                if (conn.myReader.HasRows)
                    while (conn.myReader.Read())
                    {
                        File.Delete(Page.MapPath("OAWebWeb\\UploadFile\\" + conn.myReader.GetValue(conn.myReader.GetOrdinal("SaveFileName")).ToString()));
                    }
                //删除数据库数据
                conn.Close();
                conn.ExeSql("delete SendNotice where AutoID=" + e.CommandArgument.ToString(),null);
                //外键会删除子表数据
            }
            GridView1.DataBind();
        }
    }
}
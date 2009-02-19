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
    public partial class SendNotice_R : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataSource1.ConnectionString = Session["ConnectionString"].ToString();
            if (!this.IsPostBack)
            {
                //删除意外断电而没有删除的记录
                conn.ExeSql("delete SendNotice where SendTime is null", null);
                Filter1.XMLFileName = "SendNoticeV.xml";
                DoBindGridView();
            }
        }
        protected void DoBindGridView()
        {
            strSQL = "SELECT * FROM SendNoticeV a WHERE  " + Session["UserID"].ToString() + " in" +
                          "(select RUserID from dbo.SendNotice_M where SendNoticeID=a.AutoID)";
            if (Filter1.Value != "")
                strSQL += " and " + Filter1.Value;
            strSQL += " ORDER BY [SendTime] DESC";
            SqlDataSource1.SelectParameters.Clear();
            SqlDataSource1.SelectCommand = strSQL;
            SqlDataSource1.DataBind();
            GridView1.DataBind();
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
            DoBindGridView();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sel")
            {
                Response.Redirect("SendNotice_S.aspx?AutoID=" + e.CommandArgument.ToString() + "&R=1");
            }
            DoBindGridView();
        }
        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {
            DoBindGridView();
        }

        protected void OnConditionChanged(object sender, EventArgs e)
        {
            GridView1.PageIndex = 0;
            DoBindGridView();
        }
    }
}
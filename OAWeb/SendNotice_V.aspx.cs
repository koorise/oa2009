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
    public partial class SendNotice_V : PageBase
    {
        public SendNotice_V()
        {
            //PopedomName = "已发通知";   //设置权限名称
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
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
    }
}
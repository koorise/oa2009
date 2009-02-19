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
    public partial class AttendRecord : PageBase
    {
        public AttendRecord()
        {
            PopedomName = "老师考勤记录查询";   //设置权限名称
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataSource1.ConnectionString = Session["ConnectionString"].ToString();
            if (!this.IsPostBack)
            {
                //DatePicker1.Value = String.Format("{0:d}", DateTime.Today.AddDays(-DateTime.Today.Day + 1));
                DatePicker1.Value = String.Format("{0:d}", DateTime.Today);
                DatePicker2.Value = String.Format("{0:d}", DateTime.Today);
                Button1.Attributes.Add("onclick", "return Check()");
            }
        }
        protected void DDLSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoBingGridView();
        }
        protected void DoBingGridView()
        {
            strSQL = "SELECT * FROM [AttendRecordV] WHERE RecordTime>='" + DatePicker1.Value
                    + "' and RecordTime<='" + Convert.ToDateTime(DatePicker2.Value).AddDays(1)
                    + "' and EnterpriseID=" + Session["EnterpriseID"].ToString();
            if (TimeSign.SelectedValue != "0")
                strSQL += " and TimeSign=" + TimeSign.SelectedValue;
            if (UserName.Text != "")
                strSQL += " and UserName like '" + UserName.Text + "%'";
            strSQL += " ORDER BY [RecordTime] DESC";

            SqlDataSource1.SelectCommand = strSQL;
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
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[0].Text = "&nbsp;总共有" + Convert.ToString(((DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty)).Count) + "条记录；" + "当前页为：" + Convert.ToString(GridView1.PageIndex + 1) + "；总共：" + Convert.ToString(GridView1.PageCount) + "页；每页" + Convert.ToString(GridView1.PageSize) + "条记录";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DoBingGridView();
        }
    }
}
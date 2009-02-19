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
using System.Text;

namespace OAWeb
{
    public partial class TimeBookReport : PageBase
    {
        public TimeBookReport()
        {
            //PopedomName = "老师考勤统计";   //设置权限名称
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataSource1.ConnectionString = Session["ConnectionString"].ToString();
            if (!this.IsPostBack)
            {
                //DatePicker1.Value = String.Format("{0:d}", DateTime.Today.AddDays(-DateTime.Today.Day + 1));
                DatePicker1.Value = String.Format("{0:d}", DateTime.Today.AddDays(-DateTime.Today.Day + 1));
                DatePicker2.Value = String.Format("{0:d}", DateTime.Today);
                Button1.Attributes.Add("onclick", "return Check()");
                Button3.Attributes.Add("style", "display:none");
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //OverRide　为了使导出成Excel可行！
        }
        protected void DDLSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DoBingGridView();
        }
        protected void DoBingGridView()
        {
            SqlDataSource1.SelectParameters.Clear();
            SqlDataSource1.SelectCommand = "TimeBookReport";
            SqlDataSource1.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            SqlDataSource1.SelectParameters.Add("SDate",DatePicker1.Value);
            SqlDataSource1.SelectParameters.Add("EDate", DatePicker2.Value);
            SqlDataSource1.SelectParameters.Add("EnterpriseID", TypeCode.Int32,Session["EnterpriseID"].ToString());
            SqlDataSource1.DataBind();
            GridView1.DataBind();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].ColumnSpan = e.Row.Cells.Count;
                e.Row.Cells[0].VerticalAlign = VerticalAlign.Middle;
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[0].Wrap = false;
                StringBuilder strtext = new StringBuilder();
                //标题
                strtext.Append("<FONT face=宋体 size=2>考勤统计报表" + DatePicker1.Value + "至" + DatePicker2.Value + "</Font></td>");
                strtext.Append("</tr>");
                strtext.Append("<tr>");
                //多行跨列表头
                strtext.Append("<td rowspan=3  align=center valign=middle>姓名</TD>");
                strtext.Append("<td rowspan=3  align=center valign=middle>序号</td>");
                for (DateTime dt = Convert.ToDateTime(DatePicker1.Value);
                    dt <= Convert.ToDateTime(DatePicker2.Value); dt = dt.AddDays(1))
                {
                    strtext.Append("<td  align=center valign=middle colspan=6>" + getdatestr(dt) + "</td>");
                }
                strtext.Append("<td  align=center valign=middle colspan=3 rowspan=2><table width=85><tr><td align=center>总计</td></tr></table></td>");
                strtext.Append("</tr>");
                strtext.Append("<tr>");
                for (DateTime dt = Convert.ToDateTime(DatePicker1.Value);
                    dt <= Convert.ToDateTime(DatePicker2.Value); dt = dt.AddDays(1))
                {
                    strtext.Append("<td  align=center valign=middle colspan=2>上班1</td>");
                    strtext.Append("<td  align=center valign=middle colspan=2>上班2</td>");
                    strtext.Append("<td  align=center valign=middle colspan=2>上班3</td>");
                }
                strtext.Append("</tr>");
                strtext.Append("<tr>");
                for (DateTime dt = Convert.ToDateTime(DatePicker1.Value);
                    dt <= Convert.ToDateTime(DatePicker2.Value); dt = dt.AddDays(1))
                {
                    strtext.Append("<td  align=center valign=middle colspan=1>上班</td>");
                    strtext.Append("<td  align=center valign=middle colspan=1>下班</td>");
                    strtext.Append("<td  align=center valign=middle colspan=1>上班</td>");
                    strtext.Append("<td  align=center valign=middle colspan=1>下班</td>");
                    strtext.Append("<td  align=center valign=middle colspan=1>上班</td>");
                    strtext.Append("<td  align=center valign=middle colspan=1>下班</td>");
                }
                strtext.Append("<td  align=center valign=middle>正常</td>");
                strtext.Append("<td  align=center valign=middle>迟到</td>");
                strtext.Append("<td  align=center valign=middle>缺勤</td>");

                strtext.Append("</tr>");
                strtext.Append("<tr style='DISPLAY: none;VISIBILITY: hidden'>");
                strtext.Append("<td>" + e.Row.Cells[0].Text);
                e.Row.Cells[0].Text = strtext.ToString();
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Wrap = false;
                e.Row.Cells[0].Wrap = false;
                e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
                TableCell tc;

                for (int i = 2; i < e.Row.Cells.Count; i++)
                {
                    tc = e.Row.Cells[i];
                    tc.Wrap = false;
                    //符号表示: √正常 ×缺勤 △迟到 请假○ 出差◇ 休息●	
                    string timesign;
                    try
                    {
                        timesign = tc.Text.Trim();
                        if (timesign == "√")
                        {

                            if (!CheckBox1.Checked)
                                tc.Text = "正常";
                            tc.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                            if (timesign == "△")
                            {
                                if (!CheckBox1.Checked)
                                    tc.Text = "迟到";
                                tc.ForeColor = System.Drawing.Color.SteelBlue;
                            }
                            else if (timesign == "×" || timesign == "&#215;")
                            {
                                if (!CheckBox1.Checked)
                                    tc.Text = "缺勤";
                                tc.ForeColor = System.Drawing.Color.Red;
                            }
                            else if (timesign == "○")
                            {
                                if (!CheckBox1.Checked)
                                    tc.Text = "请假";
                                tc.ForeColor = System.Drawing.Color.DodgerBlue;
                            }
                            else if (timesign == "◇")
                            {
                                if (!CheckBox1.Checked)
                                    tc.Text = "出差";
                                tc.ForeColor = System.Drawing.Color.Maroon;
                            }
                            else if (timesign == "●")
                            {
                                if (!CheckBox1.Checked)
                                    tc.Text = "休息";
                                tc.ForeColor = System.Drawing.Color.Turquoise;
                            }
                    }
                    catch
                    {
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                int m = e.Row.Cells.Count;
                for (int i = 0; i < m - 1; i++)
                    e.Row.Cells.RemoveAt(0);
                e.Row.Cells[0].ColumnSpan = m + 1;
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[0].Text = "&nbsp;总共有" + Convert.ToString(((DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty)).Count) + "条记录";
            }
        }

        private string getdatestr(DateTime dt)
        {
            string Result = "";
            string Weekstr = "日一二三四五六";
            Result = "<NOBR>" + dt.ToShortDateString() + "</NOBR><br>" + Weekstr.Substring((int)dt.DayOfWeek, 1);
            return Result;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DoBingGridView();
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            DoBingGridView();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Common.ToExcel(GridView1, "TimeBookReport.xls");
        }
    }
}
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
    public partial class AttendShiftAdd : PageBase
    {
        string TabelName = "AttendShift";
        public int i;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Button1.Attributes.Add("onclick", "return Save()");
                int NowMonth;		//当前月份
                NowMonth = System.DateTime.Now.Month;
                //绑定时段
                string str;
                str = "select * from AttendTime where EnterpriseID=" + Session["EnterpriseID"].ToString() + "";
                for (i = 1; i < 39; i++)
                {
                    DropDownList d = (DropDownList)FindControl("Dropdownlist" + Convert.ToString(i));
                    conn.BindDropDownList("AutoID", "AttendTimeName", str, d);
                    ListItem l = new ListItem("休息", "-1");
                    d.Items.Add(l);
                }
                if (Request.QueryString["AutoID"] != null)
                {
                    //修改
                    SqlParameter[] parameters ={
                                new SqlParameter("@AutoID",SqlDbType.Int)
                            };
                    parameters[0].Value =  Request.QueryString["AutoID"].ToString();
                    conn.GetRowRecord("select * from " + TabelName + " where AutoID=@AutoID", parameters);
                    ShiftName.Text = conn.dr["ShiftName"].ToString();//名称
                    ShiftType.SelectedValue = conn.dr["ShiftType"].ToString();//轮班类型
                    //周轮班
                    if (ShiftType.SelectedValue.ToString() == Convert.ToString(Convert.ToInt32(1)))
                    {
                        for (i = 1; i < 8; i++)
                        {
                            //星期1到星期日
                            DropDownList _DropDownList = (DropDownList)FindControl("Dropdownlist" + Convert.ToString(i));
                            _DropDownList.SelectedValue = conn.dr["Shift" + Convert.ToString(i)].ToString();
                        }
                    }
                    //月轮班
                    if (ShiftType.SelectedValue.ToString() == Convert.ToString(Convert.ToInt32(2)))
                    {
                        ShiftYear.SelectedValue = conn.dr["ShiftYear"].ToString();//年
                        ShiftMonth.SelectedValue = conn.dr["ShiftMonth"].ToString();//月
                        int a = (int)Convert.ToDateTime(conn.dr["ShiftYear"].ToString() + "-" + conn.dr["ShiftMonth"].ToString() + "-1").DayOfWeek;
                        int b = DateTime.DaysInMonth(Convert.ToInt32(conn.dr["ShiftYear"].ToString()), Convert.ToInt32(conn.dr["ShiftMonth"].ToString()));
                        for (i = a + 1; i < a + 1 + b; i++)
                        {
                            DropDownList _DropDownList = (DropDownList)FindControl("Dropdownlist" + Convert.ToString(i));
                            _DropDownList.SelectedValue = conn.dr["Shift" + Convert.ToString(i - a)].ToString();
                        }
                    }
                    ViewState["sTitle"] = "修改";
                    Button1.Text = "保 存";
                }
                else
                {
                    //添加
                    ViewState["sTitle"] = "添加";

                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ViewState["sTitle"].ToString() == "添加")
            {
                //添加
                strSQL = "select top 1 * from " + TabelName;
                conn.Builder(strSQL);
            }
            else
            {
                //修改
                strSQL = "select * from " + TabelName + " where AutoID=" + Request.QueryString["AutoID"].ToString();
                conn.BuilderEdit(strSQL);
            }
            conn.dr["EnterpriseID"] = Session["EnterpriseID"].ToString();
            conn.dr["ShiftName"] = ShiftName.Text.Trim();
            conn.dr["ShiftType"] = ShiftType.SelectedValue.ToString();
            int f = Convert.ToInt32(FirstDayToWeek.Text.Trim());
            //按周轮班
            if (ShiftType.SelectedValue.ToString() == Convert.ToString(Convert.ToInt32(1)))
            {
                for (i = 1; i < 8; i++)
                {
                    //周一到周日
                    DropDownList _DropDownList = (DropDownList)FindControl("Dropdownlist" + Convert.ToString(i));
                    conn.dr["Shift" + Convert.ToString(i)] = _DropDownList.SelectedValue.ToString();
                }
            }
            //按月轮班
            if (ShiftType.SelectedValue.ToString() == Convert.ToString(Convert.ToInt32(2)))
            {
                conn.dr["ShiftYear"] = ShiftYear.SelectedValue.ToString();//年
                conn.dr["ShiftMonth"] = ShiftMonth.SelectedValue.ToString();//月
                for (i = 0; i < Convert.ToInt32(MonthDayNum.Text.Trim()); i++)
                {
                    DropDownList _DropDownList = (DropDownList)FindControl("Dropdownlist" + Convert.ToString(f + i));
                    conn.dr["Shift" + Convert.ToString(i + 1)] = _DropDownList.SelectedValue.ToString();
                }
            }
            if (Common.CheckPopedom(PopedomName, "MEdit") == false)      //判断用户是否有查看权限
            {
                Session["ShowMsg"] = "您没有权限操作该功能 !";
                Response.Redirect("ShowMessage.aspx?PreviousPage=" + TabelName + ".aspx");
            }
            else
            {
                conn.Update(ViewState["sTitle"].ToString(), TabelName + "Add");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect(TabelName + ".aspx");
        }
    }
}
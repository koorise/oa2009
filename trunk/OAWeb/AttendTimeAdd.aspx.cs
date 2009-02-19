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
    public partial class AttendTimeAdd : PageBase
    {
        string TabelName = "AttendTime";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Button1.Attributes.Add("onclick", "return Add()");
                if (Request.QueryString["AutoID"] != null)
                {
                    //修改
                    SqlParameter[] parameters ={
                                new SqlParameter("@AutoID",SqlDbType.Int)
                            };
                    parameters[0].Value = Request.QueryString["AutoID"].ToString();

                    conn.GetRowRecord("select * from " + TabelName + " where AutoID=@AutoID", parameters);
                    DDLAttendTimeNum.SelectedValue = conn.dr["AttendTimeNum"].ToString();
                    txtAttendTimeName.Text = conn.dr["AttendTimeName"].ToString();
                    txtBelated.Text = conn.dr["Belated"].ToString();
                    //时段一
                    txtBefore1.Text = conn.dr["Before1"].ToString();
                    txtStartTime1_1.Text = Convert.ToDateTime(conn.dr["StartTime1"].ToString()).Hour.ToString();
                    txtStartTime1_2.Text = Convert.ToDateTime(conn.dr["StartTime1"].ToString()).Minute.ToString();
                    txtEndTime1_1.Text = Convert.ToDateTime(conn.dr["EndTime1"].ToString()).Hour.ToString();
                    txtEndTime1_2.Text = Convert.ToDateTime(conn.dr["EndTime1"].ToString()).Minute.ToString();
                    txtAfter1.Text = conn.dr["After1"].ToString();
                    //时段二
                    if (DDLAttendTimeNum.SelectedValue.ToString() == Convert.ToString(Convert.ToInt32(2)))
                    {
                        txtBefore2.Text = conn.dr["Before2"].ToString();
                        txtStartTime2_1.Text = Convert.ToDateTime(conn.dr["StartTime2"].ToString()).Hour.ToString();
                        txtStartTime2_2.Text = Convert.ToDateTime(conn.dr["StartTime2"].ToString()).Minute.ToString();
                        txtEndTime2_1.Text = Convert.ToDateTime(conn.dr["EndTime2"].ToString()).Hour.ToString();
                        txtEndTime2_2.Text = Convert.ToDateTime(conn.dr["EndTime2"].ToString()).Minute.ToString();
                        txtAfter2.Text = conn.dr["After2"].ToString();
                    }
                    //时段三
                    if (DDLAttendTimeNum.SelectedValue.ToString() == Convert.ToString(Convert.ToInt32(3)))
                    {
                        //时段二
                        txtBefore2.Text = conn.dr["Before2"].ToString();
                        txtStartTime2_1.Text = Convert.ToDateTime(conn.dr["StartTime2"].ToString()).Hour.ToString();
                        txtStartTime2_2.Text = Convert.ToDateTime(conn.dr["StartTime2"].ToString()).Minute.ToString();
                        txtEndTime2_1.Text = Convert.ToDateTime(conn.dr["EndTime2"].ToString()).Hour.ToString();
                        txtEndTime2_2.Text = Convert.ToDateTime(conn.dr["EndTime2"].ToString()).Minute.ToString();
                        txtAfter2.Text = conn.dr["After2"].ToString();
                        //时段三
                        txtBefore3.Text = conn.dr["Before3"].ToString();
                        txtStartTime3_1.Text = Convert.ToDateTime(conn.dr["StartTime3"].ToString()).Hour.ToString();
                        txtStartTime3_2.Text = Convert.ToDateTime(conn.dr["StartTime3"].ToString()).Minute.ToString();
                        txtEndTime3_1.Text = Convert.ToDateTime(conn.dr["EndTime3"].ToString()).Hour.ToString();
                        txtEndTime3_2.Text = Convert.ToDateTime(conn.dr["EndTime3"].ToString()).Minute.ToString();
                        txtAfter3.Text = conn.dr["After3"].ToString();
                    }
                    ViewState["sTitle"] = "修改";
                    Button1.Text = "保 存";
                }
                else
                {
                    //添加
                    ViewState["sTitle"] = "添加";
                    DDLAttendTimeNum.Attributes.Add("onchange", "PeriodNumChange()");
                }
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect(TabelName + ".aspx");
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
            conn.dr["AttendTimeName"] = txtAttendTimeName.Text;
            conn.dr["AttendTimeNum"] = DDLAttendTimeNum.SelectedValue.ToString();
            conn.dr["Belated"] = txtBelated.Text;
            //时段一
            conn.dr["Before1"] = txtBefore1.Text;
            conn.dr["StartTime1"] = txtStartTime1_1.Text + ":" + txtStartTime1_2.Text;
            conn.dr["EndTime1"] = txtEndTime1_1.Text + ":" + txtEndTime1_2.Text;
            conn.dr["After1"] = txtAfter1.Text;
            if (DDLAttendTimeNum.SelectedValue.ToString() == Convert.ToString(Convert.ToInt32(2)))
            {
                //时段二
                conn.dr["Before2"] = txtBefore2.Text;
                conn.dr["StartTime2"] = txtStartTime2_1.Text + ":" + txtStartTime2_2.Text;
                conn.dr["EndTime2"] = txtEndTime2_1.Text + ":" + txtEndTime2_2.Text;
                conn.dr["After2"] = txtAfter2.Text;
            }
            if (DDLAttendTimeNum.SelectedValue.ToString() == Convert.ToString(Convert.ToInt32(3)))
            {
                //时段二
                conn.dr["Before2"] = txtBefore2.Text;
                conn.dr["StartTime2"] = txtStartTime2_1.Text + ":" + txtStartTime2_2.Text;
                conn.dr["EndTime2"] = txtEndTime2_1.Text + ":" + txtEndTime2_2.Text;
                conn.dr["After2"] = txtAfter2.Text;
                //时段三
                conn.dr["Before3"] = txtBefore3.Text;
                conn.dr["StartTime3"] = txtStartTime3_1.Text + ":" + txtStartTime3_2.Text;
                conn.dr["EndTime3"] = txtEndTime3_1.Text + ":" + txtEndTime3_2.Text;
                conn.dr["After3"] = txtAfter3.Text;
            }
            if (Common.CheckPopedom(PopedomName, "MEdit") == false)      //判断用户是否有查看权限
            {
                Session["ShowMsg"] = "您没有权限操作该功能 !";
                Response.Redirect("ShowMessage.aspx?PreviousPage=" + TabelName + ".aspx");
            }
            else
                conn.Update(ViewState["sTitle"].ToString(), TabelName + "Add");
        }
    }
}
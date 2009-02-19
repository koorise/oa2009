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
    public partial class UserAttendShift : PageBase
    {
        public UserAttendShift()
        {
            PopedomName = "用户排班设置";   //设置权限名称
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataSource1.ConnectionString = Session["ConnectionString"].ToString();
            SqlDataSource2.ConnectionString = Session["ConnectionString"].ToString();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (Common.CheckPopedom(PopedomName, "MEdit") == false)      //判断用户是否有权限
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('您没有权限操作该功能！')", true);
                return;
            }
            DropDownList DDLShiftName = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("DDLShiftName");
            if (DDLShiftName.Items.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('请先设置轮班！')", true);
                return;
            }
            conn.BuilderEdit("Select * from Users where AutoID=" + GridView1.DataKeys[(int)e.RowIndex]["AutoID"].ToString());
            conn.dr["AttendShiftID"] = DDLShiftName.SelectedValue;
            conn.myAdapter.Update(conn.ds); // 更新数据库
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
            {
                DropDownList DDLShiftName = (DropDownList)e.Row.FindControl("DDLShiftName");
                DDLShiftName.SelectedValue = GridView1.DataKeys[e.Row.RowIndex]["AttendShiftID"].ToString();
            }
        }
    }
}
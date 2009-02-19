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
    public partial class UserDepartment : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataSource1.ConnectionString = Session["ConnectionString"].ToString();
            SqlDataSource2.ConnectionString = Session["ConnectionString"].ToString();

            if (!this.IsPostBack)
            {
                Common.BindDepartmentToDropDownList(DropDownList2);
                //UserIDStr.Attributes.Add("style", "display:none");
            }

        }
        protected void Button2_Click(object sender, EventArgs e)    //保存
        {
            //删除部门
            if(UserIDStr.Value=="")
                strSQL = "delete UserDepartment where DepartmentID=@DepartmentID";
            else
                strSQL = "delete UserDepartment where DepartmentID=@DepartmentID and UserID not in(" + UserIDStr.Value + ")";
            SqlParameter[] parameters ={
                                new SqlParameter("@DepartmentID",SqlDbType.Int)
                            };
            parameters[0].Value = DropDownList2.SelectedValue;

            conn.ExeSql(strSQL, parameters);
            //添加用户部门
            if (UserIDStr.Value != "")
            {
                strSQL = "insert into UserDepartment(DepartmentID,UserID) " +
                        "select " + DropDownList2.SelectedValue + ",AutoID from Users where AutoID in(" + UserIDStr.Value + ") " +
                        "and  " + DropDownList2.SelectedValue + " not in(select AutoID from Department where layid=0)" +
                        "and AutoID not in (select UserID from UserDepartment where ([DepartmentID] =" + DropDownList2.SelectedValue + "))";
                conn.ExeSql(strSQL,null);
            }
            ListBox1.DataBind();
            ListBox2.DataBind();  
        }

        protected void BtnFind_Click(object sender, EventArgs e)
        {
            strSQL = "select AutoID,UserName from Users WHERE ([EnterpriseID] = " + Session["EnterpriseID"].ToString() + ") and AutoID not in(select UserID from UserDepartment where ([DepartmentID] = " + DropDownList2.SelectedValue + "))" +
                        " and UserName like '%"+TextBox1.Text.Trim()+"%'";
            SqlDataSource1.SelectCommand = strSQL;
            ListBox1.DataBind();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox1.DataBind();
        }
        
    }
}

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
using System.Configuration;

namespace OAWeb
{
    public partial class index : System.Web.UI.Page
    {
        protected string GetEnterpriseCode()
        {
            DataSet ConfigData = new DataSet();
            ConfigData.ReadXml(HttpContext.Current.Server.MapPath("Enterprise.config"));
            string EnterpriseCode;


            if (System.Configuration.ConfigurationManager.AppSettings["EnterpriseCode"] != null)  //如果webconfig中设置有企业id则取webconfig中的企业id,否则根据网址取Enterprise.config中的企业id
                EnterpriseCode = System.Configuration.ConfigurationManager.AppSettings["EnterpriseCode"];
            else
            {
                string UrlHead = HttpContext.Current.Request.Url.Host.ToString();
                if (HttpContext.Current.Request.Url.Segments.Length > 2)
                {
                    UrlHead = HttpContext.Current.Request.Url.Segments[1];
                    UrlHead = UrlHead.ToLower().Replace("/", "");
                }
                DataRow[] rows = ConfigData.Tables["Enterprise"].Select("Url='" + UrlHead + "'");
                EnterpriseCode = rows[0][0].ToString();
            }
            return EnterpriseCode;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Button1.Attributes.Add("onclick", "CheckLogin()");
            }
            if (this.isSubmit.Text == "1")
            {
                Button1_Click(null, null);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["Style"] = "1";
            Session["ConnectionString"] = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnection MyConn;
            SqlCommand MyCommand = new SqlCommand();
            try
            {
                MyConn = new SqlConnection(Session["ConnectionString"].ToString());
                MyCommand.Connection = MyConn;
                MyConn.Open();
            }
            catch (Exception ex)
            {
                Session["ShowMsg"] = "连接数据库服务器失败!" + ex.ToString();
                Response.Redirect("ShowMessage.aspx?PreviousPage=index.aspx");
                return;
            }
            string EnterpriseCode = GetEnterpriseCode();
            MyCommand.CommandText = "select top 1 * from UsersV where LoginName=@LoginName and LoginPW=@Password and EnterpriseCode='" + EnterpriseCode + "'";
            MyCommand.Parameters.Add("@LoginName", SqlDbType.VarChar, 20).Value = LoginName.Text.Trim();
            MyCommand.Parameters.Add("@Password", SqlDbType.VarChar, 20).Value = LoginPW.Text.Trim();
            try
            {
                SqlDataReader MyReader = MyCommand.ExecuteReader();    //验证
                if (MyReader.Read())
                {
                    //记录进Cookie中


                    Session["UserID"] = MyReader.GetValue(MyReader.GetOrdinal("AutoID"));
                    Session["EnterpriseID"] = MyReader.GetValue(MyReader.GetOrdinal("EnterpriseID"));
                    Session["UserName"] = MyReader.GetString(MyReader.GetOrdinal("UserName"));
                    //Session["RoleID"] = MyReader.GetValue(MyReader.GetOrdinal("RoleID"));
                    /*
                    //缓存权限
                    Session["MyPopedom"] = conn.GetDataSet("select * from RolePopedomV where RoleID=" + MyReader.GetValue(MyReader.GetOrdinal("RoleID")).ToString());
                    //缓存系统设置表
                    Session["SysSet"] = conn.GetDataSet("select * from SysSet");
                    */
                    Session["LoginFlag"] = 1;
                    //Application["1xleft1_bgimage"] = "images/left-1.gif";
                    //写入日记
                    //conn.Close();
                    //conn.Open;
                    SqlHelper conn = new SqlHelper();
                    SqlParameter[] parameters ={
                                new SqlParameter("@OperatorID",SqlDbType.Int)
                            };
                    parameters[0].Value = Session["UserID"].ToString();
                    conn.ExeSql("insert into Diary(OperatorID,Note)values(@OperatorID,'登陆系统')", parameters);
                    Response.Redirect("main.htm");
                }
                else
                {
                    lbl_message.Text = "登陆失败，请检查你的用户名和密码。";
                }
                MyReader.Close();
            }
            catch (Exception ex)
            {
                lbl_message.Text = "登陆失败." + ex.ToString();
            }
            MyConn.Close();
            isSubmit.Text = "0";
        }
    }
}
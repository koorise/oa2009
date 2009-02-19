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
    public partial class SendNotice_S : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                SqlParameter[] parameters ={
                                new SqlParameter("@SendNoticeID",SqlDbType.Int)
                            };
                parameters[0].Value = Request.QueryString["AutoID"].ToString();

                if (conn.GetRowCount("select * from SendNotice_fj where SendNoticeID=@SendNoticeID", parameters) == 0)
                    Label5.Visible = false;
                conn.Close();
                conn.Open();
                SqlParameter[] parameters1 ={
                                new SqlParameter("@AutoID",SqlDbType.Int)
                            };
                parameters1[0].Value = Request.QueryString["AutoID"].ToString();
                conn.GetRowRecord("select * from SendNoticeV where AutoID=@AutoID", parameters1);
                Label1.Text = conn.dr["Title"].ToString();
                Label2.Text = conn.dr["UserName"].ToString();
                Label3.Text = conn.dr["SendTime"].ToString();
                Label4.Text = conn.dr["MsgContent"].ToString();
                if (Request.QueryString["R"] != null)
                {
                    conn.ExeSql("Update SendNotice_M set ViewTime=getdate() where (ViewTime is null) and SendNoticeID=@AutoID and RUserID=" + Session["UserID"].ToString(), parameters);
                }
            }
            SqlDataSource1.ConnectionString = Session["ConnectionString"].ToString();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["R"] != null)
                Response.Redirect("SendNotice_R.aspx");
            else
                Response.Redirect("SendNotice_F.aspx");
        }
    }
}
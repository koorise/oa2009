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
using System.IO;

namespace OAWeb
{
    public partial class SendNotice : PageBase
    {
        public SendNotice()
        {
            //PopedomName = "发送通知";   //设置权限名称
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                isSubmit.Attributes.Add("style", "display:none");
                DelSendNotice.Attributes.Add("style", "display:none");
                Button2.Enabled = false;
            }
        }
        protected void isSubmit_Click(object sender, EventArgs e)
        {
            if (SubmitType.Value == "1")    //接受人
            {
                if (Session["SendNoticeIDStr"] != null)
                {
                    strSQL = "select AutoID,UserName from Users where AutoID in(" + Session["SendNoticeIDStr"].ToString() + ")";
                    conn.Fill(strSQL,null);
                    DropDownList1.DataValueField = "AutoID";
                    DropDownList1.DataTextField = "UserName";
                    DropDownList1.DataSource = conn.ds;
                    DropDownList1.DataBind();
                }
            }
            else     //附件
            {
                GetRAutoID();
                conn.ExeSql("insert SendNotice_FJ select " + ViewState["RAutoID"].ToString() + ",'" + Session["SendNotice_SaveFileName"].ToString() + "','" + Session["SendNotice_UploadFileName"].ToString() + "'",null);
                conn.BindDropDownList("AutoID", "UploadFileName", "select * from SendNotice_FJ where SendNoticeID=" + ViewState["RAutoID"].ToString(), DropDownList2);
                if (DropDownList2.Items.Count > 0)
                    Button2.Enabled = true;
            }
        }
        protected void GetRAutoID()
        {
            if (ViewState["RAutoID"] == null)
            {
                //生成主表
                SqlParameter[] parameters ={
                    new SqlParameter("@SUserID",SqlDbType.Int,4),
                    new SqlParameter("@RAutoID",SqlDbType.Int,4)
                };
                parameters[0].Value = Convert.ToInt32(Session["UserID"]);
                parameters[1].Value = 0;
                parameters[1].Direction = ParameterDirection.Output;
                conn.RunProcedure("SendNoticeAdd", parameters);
                ViewState["RAutoID"] = parameters[1].Value;
                conn.Close();
                conn.Open();
            }
        }
        protected void DelFJ()  //删除附件
        {
            conn.GetReader("select * from SendNotice_FJ where SendNoticeID=" + ViewState["RAutoID"].ToString(),null);
            if (conn.myReader.HasRows)
                while (conn.myReader.Read())
                {
                    File.Delete(Page.MapPath("UploadFile\\" + conn.myReader.GetValue(conn.myReader.GetOrdinal("SaveFileName")).ToString()));
                }
            conn.Close();
            conn.Open();
        }
        protected void DelSendNotice_Click(object sender, EventArgs e)
        {
            //没有发送就删除
            if (ViewState["RAutoID"] != null)
            {
                //先删除附件
                DelFJ();
                //删除数据库数据
                conn.ExeSql("delete SendNotice where AutoID=" + ViewState["RAutoID"].ToString(),null);
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (ViewState["RAutoID"] != null)
            {
                //先删除附件
                DelFJ();
                strSQL = "delete SendNotice_FJ where AutoID=@AutoID";
                SqlParameter[] parameters ={
                        new SqlParameter("@RAutoID",SqlDbType.Int)
                    };
                parameters[0].Value = ViewState["RAutoID"].ToString();

                conn.ExeSql(strSQL,parameters);
                DropDownList2.Items.Clear();
                Button2.Enabled = false;
            }
        }
        protected void BtnSend_Click(object sender, EventArgs e)
        {
            GetRAutoID();
            strSQL = "insert into SendNotice_M(SendNoticeID,RUserID)select @RAutoID,AutoID from Users where AutoID in(" + Session["SendNoticeIDStr"].ToString() + ")";
            conn.Close();
            conn.Open();
            SqlParameter[] parameters ={
                new SqlParameter("@RAutoID",SqlDbType.Int)
            };
            parameters[0].Value = ViewState["RAutoID"].ToString();

            conn.ExeSql(strSQL, parameters);
            strSQL = "update SendNotice set SendType=";
            if (RadioButton1.Checked)
                strSQL += "'普通'";
            else
                strSQL += "'重要'";
            //strSQL += ",SendTime=getdate(),Title='" + TxtTitle.Text.Trim() + "',MsgContent='" + FCKeditor1.Value.Replace("iframe", "") + "',SenderIP='" + Common.GetClientIP() + "' where AutoID=" + ViewState["RAutoID"].ToString();
            strSQL += ",SendTime=getdate(),Title=@Title,MsgContent=@MsgContent,SenderIP='" + Common.GetClientIP() + "' where AutoID=" + ViewState["RAutoID"].ToString();
            SqlParameter[] parameters1 ={
                new SqlParameter("@Title",SqlDbType.VarChar,80),
                new SqlParameter("@MsgContent",SqlDbType.NText)
            };
            parameters1[0].Value = TxtTitle.Text.Trim();
            parameters1[1].Value = FCKeditor1.Value.Replace("iframe", "");

            conn.ExeSql(strSQL, parameters1);
            Session["ShowMsg"] = "发送成功!";
            Response.Redirect("ShowMessage.aspx?PreviousPage=SendNotice.aspx");
        }
    }
}
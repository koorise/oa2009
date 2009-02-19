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
    public partial class UsersAdd : PageBase
    {
        string TabelName = "Users";
        public UsersAdd()
        {
            //PopedomName = "用户设置";   //设置权限名称
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Button1.Attributes.Add("onclick", "return Add()");
                txtMobile.Attributes.Add("onkeyup", "value=value.replace(/[^\\d]/g,'')");
                txtMobile.Attributes.Add("onbeforepaste", "clipboardData.setData('text',clipboardData.getData('text').replace(/[^\\d]/g,''))");
                DDLRoleDataBind();//用户角色
                if (Request.QueryString["AutoID"] != null)
                {
                    //修改
                    conn.GetRowRecord("select * from " + TabelName + "V where AutoID=" + Request.QueryString["AutoID"].ToString(),null);
                    txtLoginName.Text = conn.dr["LoginName"].ToString();
                    txtLoginPW.Text = conn.dr["LoginPW"].ToString();
                    txtUserName.Text = conn.dr["UserName"].ToString();
                    txtMobile.Text = conn.dr["Mobile"].ToString();
                    DDLRole.SelectedValue = conn.dr["RoleID"].ToString();
                    if (conn.dr["IsStop"].ToString() == "True")
                        DDLIsStop.SelectedValue = "1";
                    else
                        DDLIsStop.SelectedValue = "0";
                    if (conn.dr["AttendShiftID"].ToString() != "")
                        DDLShiftName.SelectedValue = conn.dr["AttendShiftID"].ToString();
                    ViewState["sTitle"] = "修改";
                    Button1.Text = "保 存";
                }
                else
                {
                    //添加
                    ViewState["sTitle"] = "添加";
                }
                //考勤类型
                conn.BindDropDownList("AutoID", "ShiftName", "select * from AttendShift", DDLShiftName);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ViewState["sTitle"].ToString() == "添加")
            {
                //添加
                strSQL = "select top 1 * from " + TabelName;
                conn.Builder(strSQL);
                conn.dr["RegOperatorID"] = Session["UserID"].ToString();
            }
            else
            {
                //修改
                strSQL = "select * from " + TabelName + " where AutoID=" + Request.QueryString["AutoID"].ToString();
                conn.BuilderEdit(strSQL);
                if (DDLIsStop.SelectedValue.ToString() == "1")
                {
                    conn.dr["IsStop"] = 1;
                }
                else
                {
                    conn.dr["IsStop"] = 0;
                }
            }
            conn.dr["EnterpriseID"] = Session["EnterpriseID"].ToString();
            conn.dr["LoginName"] = txtLoginName.Text.Trim();
            conn.dr["LoginPW"] = txtLoginPW.Text.Trim();
            conn.dr["UserName"] = txtUserName.Text.Trim();
            conn.dr["Mobile"] = txtMobile.Text.Trim();
            if (DDLRole.Items.Count > 0)
                conn.dr["RoleID"] = DDLRole.SelectedValue.ToString();
            if (DDLShiftName.Items.Count > 0)
                conn.dr["AttendShiftID"] = DDLShiftName.SelectedValue.ToString();
            conn.SupportViewIX();       //由于Users表建有计算字段索引，所以先要让当前连接支持计算字段索引
            if (Common.CheckPopedom(PopedomName, "MEdit") == false)      //判断用户是否有查看权限
            {
                Session["ShowMsg"] = "您没有权限操作该功能 !";
                Response.Redirect("ShowMessage.aspx?PreviousPage=" + TabelName + ".aspx");
            }
            else
            {
                Session["ShowMsg"] = ViewState["sTitle"].ToString() + "成功！";
                if (ViewState["sTitle"].ToString() == "添加")
                    conn.ds.Tables[0].Rows.Add(conn.dr);
                try
                {
                    conn.myAdapter.Update(conn.ds); // 更新数据库
                }
                catch (Exception ex)
                {
                    if (ex.ToString().IndexOf("重复键") > 0)
                    {
                        if (ex.ToString().IndexOf("LoginName") > 0)
                            System.Web.HttpContext.Current.Session["ShowMsg"] = ViewState["sTitle"].ToString() + "失败！登陆名已存在，请输入其他的登陆名";
                        else
                            System.Web.HttpContext.Current.Session["ShowMsg"] = ViewState["sTitle"].ToString() + "失败！该校已存在该用户名字，请输入其他的用户名字";
                    }
                    else
                    {
                        System.Web.HttpContext.Current.Session["ShowMsg"] = ViewState["sTitle"].ToString() + "失败！" + ex.ToString();
                    }
                }
                if (ViewState["sTitle"].ToString() == "添加")
                    System.Web.HttpContext.Current.Response.Redirect("ShowMessage.aspx?PreviousPage=" + TabelName + "Add" + ".aspx");
                else
                    System.Web.HttpContext.Current.Response.Redirect("ShowMessage.aspx?PreviousPage=" + TabelName + "Add" + ".aspx?AutoID=" + Request.QueryString["AutoID"].ToString());  //注意修改页面的传递参数名必须是AutoID
            }

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect(TabelName + ".aspx");
        }
        private void DDLRoleDataBind()
        {
            //用户角色
            conn.BindDropDownList("AutoID", "RoleName", "select * from Role where EnterpriseID=" + Session["EnterpriseID"].ToString(), DDLRole);
        }
    }
}
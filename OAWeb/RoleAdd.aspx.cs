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
    public partial class RoleAdd : PageBase
    {
        string TabelName = "Role";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Button1.Attributes.Add("onclick", "return Add()");
                conn.Open();
                if (Request.QueryString["AutoID"] != null)
                {
                    //修改
                    conn.GetRowRecord("select * from " + TabelName + " where AutoID=" + Request.QueryString["AutoID"].ToString(),null);
                    RoleName.Text = conn.dr["RoleName"].ToString();
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
            conn.dr["RoleName"] = RoleName.Text.Trim();
            if (Common.CheckPopedom(PopedomName, "MEdit") == false)      //判断用户是否有查看权限
            {
                Session["ShowMsg"] = "您没有权限操作该功能 !";
                Response.Redirect("ShowMessage.aspx?PreviousPage=" + TabelName + ".aspx");
            }
            else
                conn.Update(ViewState["sTitle"].ToString(), TabelName + "Add");

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect(TabelName + ".aspx");
        }
    }
}
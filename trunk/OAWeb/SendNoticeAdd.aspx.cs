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
//using AjaxControlToolkit;

namespace OAWeb
{
    public partial class SendNoticeAdd : PageBase
    {
        public SendNoticeAdd()
        {
            //PopedomName = "发送通知";   //设置权限名称
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                isSubmit.Attributes.Add("style", "display:none");
                ReceiveUserIDStr.Attributes.Add("style", "display:none");
                Common.BindDepartmentToDropDownList(DropDownList1);
                DropDownList1_SelectedIndexChanged(null, null);
            }
        }
        protected void BtnOK_Click(object sender, EventArgs e)
        {
            if (ReceiveUserIDStr.Text != "")
                Session["SendNoticeIDStr"] = ReceiveUserIDStr.Text;
            Response.Write("<script>var sData = dialogArguments;window.close();sData.UploadBind('1');</script>");
        }

        protected void DDLSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ReceiveUserIDStr.Text!="")
                strSQL = "select AutoID,UserName+'('+Mobile+')' as NameMobile from UsersV where EnterpriseID=" + Session["EnterpriseID"].ToString() + " and AutoID not in(" + ReceiveUserIDStr.Text + ")";
            else
                strSQL = "select AutoID,UserName+'('+Mobile+')' as NameMobile from UsersV where EnterpriseID=" + Session["EnterpriseID"].ToString();
            conn.Fill(strSQL,null);
            ListBox1.DataValueField = "AutoID";
            ListBox1.DataTextField = "NameMobile";
            ListBox1.DataSource = conn.ds;
            ListBox1.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ReceiveUserIDStr.Text != "")
            {

                strSQL = "if((select top 1 layid from Department where AutoID=" + DropDownList1.SelectedValue + ")=0)" +    //是否是根节点，如果是显示所有该企业的人员，如果不是则显示该部门的人员
                    "select AutoID,UserName from UsersV where EnterpriseID=" + Session["EnterpriseID"].ToString() + " and AutoID not in(" + ReceiveUserIDStr.Text + ")" +
                    " else " +
                    "select UserID as AutoID,UserName from UserDepartmentV where EnterpriseID=" + Session["EnterpriseID"].ToString() + " and DepartmentID=" + DropDownList1.SelectedValue + " and AutoID not in(" + ReceiveUserIDStr.Text + ")";
            }
            else
            {
                strSQL = "if((select top 1 layid from Department where AutoID=" + DropDownList1.SelectedValue + ")=0)" +    //是否是根节点，如果是显示所有该企业的人员，如果不是则显示该部门的人员
                    "select AutoID,UserName from UsersV where EnterpriseID=" + Session["EnterpriseID"].ToString() +
                    " else " +
                    "select UserID as AutoID,UserName from UserDepartmentV where EnterpriseID=" + Session["EnterpriseID"].ToString() + " and DepartmentID=" + DropDownList1.SelectedValue;
            }
            conn.BindListBox("AutoID", "UserName", strSQL, ListBox1);
        }
    }
}
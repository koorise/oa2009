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
    public partial class ShowMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ShowMsg"] != null) 
                    Label1.Text = Session["ShowMsg"].ToString();
                if(Request.QueryString["PreviousPage"].ToString()=="Back")
                    Button1.Attributes.Add("onclick", "history.go(-2);return false;");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string ss;
            ss = Request.QueryString["PreviousPage"].ToString();
            if (Request.QueryString["Param"] != null)
                ss += "?" + Request.QueryString["Param"].ToString();
            //Response.Write(Request.QueryString["Param"]);
            Response.Redirect(ss.Replace("$", "&"));
        }
    }
}
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
    public partial class Filter : System.Web.UI.Page
    {
        protected int i;
        protected DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ds = new DataSet();
                if(Request.QueryString[0].ToString().IndexOf(".xml")>0)
                    ds.ReadXml(System.Web.HttpContext.Current.Server.MapPath("Services/Filter/" + Request.QueryString[0].ToString()));
                else
                    ds.ReadXml(System.Web.HttpContext.Current.Server.MapPath("Services/Filter/" + Request.QueryString[0].ToString() + ".xml"));
            }
        }
    }
}
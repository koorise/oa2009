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
    public partial class tree_top : PageBase
    {
        public tree_top()
        {
            //PopedomName = "�û���������";   //����Ȩ������
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("tree_index.aspx");
        }
    }
}

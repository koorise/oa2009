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

namespace OAWeb.UserControl
{
    public partial class Filter : System.Web.UI.UserControl
    {
        public string _XMLFileName;
        public string XMLFileName      
        {
            set { _XMLFileName = value; }   //XML配置文件名
        }
        string _Text;
        public string Text
        {
            set { _Text = value; }          
        }
        string _Value = "";
        public string Value
        {
            set { _Value = value; }
            get { return _Value; }
        }
        public event EventHandler ConditionChanged;     //添加查询条件改变事件句柄

        protected void Page_Load(object sender, EventArgs e)
        {
            BtnSubmit.Attributes.Add("style","display:none");
            if (ConditionValue.Value != "")
            {
                Value = ConditionValue.Value;
                Label1.Text = "取消查询";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                Label1.Text = "查询";
                Label1.ForeColor = System.Drawing.Color.Black;
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            Value = ConditionValue.Value;
            try
            {
                ConditionChanged(this, new EventArgs());     //触发查询条件改变事件
            }
            catch { }
        }
    }
}
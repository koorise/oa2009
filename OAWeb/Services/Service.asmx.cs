using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Web.Script.Services;

namespace OAWeb
{
    /// <summary>
    /// Service 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [ScriptService]
    public class Service : System.Web.Services.WebService
    {
        private IContainer components = null;
        public Service()
        {

        }
        ///  <summary> 
        ///  清理所有正在使用的资源。 
        ///  </summary> 
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        } 
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        /// 返回通用过滤条件的控件
        /// </summary>
        /// <param name="XMLFileName">XML文件名</param>
        /// <param name="PKFieldValue">字段名称</param>
        [WebMethod(EnableSession = true)]
        public string ReturnControl(string XMLFileName, string PKFieldValue)
        {
            SqlHelper conn = new SqlHelper();
            string Control;
            string DDLTable;
            string ControlStr = "";
            Control = Common.GetXmlValue("Filter\\" + XMLFileName, "jxt", "FieldName", PKFieldValue, 2);
            switch (Control)
            {
                case "dropdownlist":
                    //生成下拉列表控件
                    DDLTable = Common.GetXmlValue("Filter\\" + XMLFileName, "jxt", "FieldName", PKFieldValue, 3);
                    conn.GetReader(DDLTable,null);
                    ControlStr = "<SELECT id='dropdownlist1'>";
                    while (conn.myReader.Read())
                    {
                        ControlStr += "<OPTION value='" + conn.myReader.GetValue(0) + "'>" + conn.myReader.GetValue(1) + "</OPTION>";
                    }
                    ControlStr += "</SELECT>";
                    break;
                case "datetime":
                    ControlStr = "起始日期&nbsp;&nbsp;<A Style='width:100;'><input name='DatePicker1' id='DatePicker1' type='text' value='" + String.Format("{0:d}", DateTime.Today) + "' style='Width:78;Border:1Px Solid #3D4D81;Border-Right:0px;' ReadOnly='True' Class='DatePicker_Text' />" +
                        "<input type='button' style='Border:1Px Solid #3D4D81;Border-Left:0px;' Class='DatePicker_Button' AutoPostBack='False' onClick=\"StartDateControl(this,'yyyy-mm-dd');\" onMouseOver='HiddenDateControl(this);' onFocus='HiddenDateControl(this);' /></A>" +
                        "<br><br>&nbsp;&nbsp;终止日期&nbsp;&nbsp;" +
                        "<A Style='width:100;'><input name='DatePicker2' id='DatePicker2' type='text' value='" + String.Format("{0:d}", DateTime.Today.AddDays(1)) + "' style='Width:78;Border:1Px Solid #3D4D81;Border-Right:0px;' ReadOnly='True' Class='DatePicker_Text' />" +
                        "<input type='button' style='Border:1Px Solid #3D4D81;Border-Left:0px;' Class='DatePicker_Button' AutoPostBack='False' onClick=\"StartDateControl(this,'yyyy-mm-dd');\" onMouseOver='HiddenDateControl(this);' onFocus='HiddenDateControl(this);' /></A>";

                    break;
                case "TextBox":
                    ControlStr = "<input type=text id='TextBox1' maxlength=20><br><br><input type=radio id='RadioButton1' name='a' Checked='True'><label for='RadioButton1'>包含</label><input type=radio  id='RadioButton2' name='a'><label for='RadioButton2'>等于</label>";

                    break;

            }
            return ControlStr;
        }

        /// <summary>
        /// 取得工作流路径字符串
        /// </summary>
        /// <param name="MsgContent">需要发送的内容</param>
        [WebMethod(EnableSession = true)]
        public string GetWorkflowPathShow(string WorkflowID)
        {
            SqlHelper cn = new SqlHelper();
            SqlParameter[] parameters ={
                        new SqlParameter("@WorkflowID",SqlDbType.Int,4),
                        new SqlParameter("@OutStr",SqlDbType.VarChar,8000)};
            parameters[0].Value = Convert.ToInt32(WorkflowID);
            parameters[1].Value = "";
            parameters[1].Direction = ParameterDirection.Output;
            cn.RunProcedure("WorkflowPathShow",parameters);
            return parameters[1].Value.ToString();
        }
    }
}

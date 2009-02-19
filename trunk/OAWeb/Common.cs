using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace OAWeb
{
    public class Common
    {
        public Common()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 取得客户端IP地址
        /// </summary>
        public static string GetClientIP()
        {
            string _IP;
            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
            {
                _IP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else
            {
                _IP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            }
            return _IP;
        }
        /// <summary>
        /// 清除缓存，用于模式窗体，否则会丢失Session
        /// </summary>
        public static void ClearCache()
        { 
            System.Web.HttpContext.Current.Response.Expires = 0;
            System.Web.HttpContext.Current.Response.Cache.SetNoStore();
            System.Web.HttpContext.Current.Response.AppendHeader("Pragma", "no-cache");

            System.Web.HttpContext.Current.Response.Cache.SetNoServerCaching();
            System.Web.HttpContext.Current.Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            System.Web.HttpContext.Current.Response.Cache.SetNoStore();
            System.Web.HttpContext.Current.Response.Cache.SetExpires(new DateTime(1900, 01, 01, 00, 00, 00, 00));
        }
        /// <summary>
        /// 导出到Excel(注意：需要设置服务器控件的EnableViewState="true";并覆盖VerifyRenderingInServerForm方法;如果使用了ajax,那么必须整个窗体都要提交,即必须添加外部隐含提交按钮)
        /// </summary>
        /// <param name="ctl">控件ID</param>
        /// <param name="FileName">导出的文件名</param>
        public static void ToExcel(System.Web.UI.Control ctl, string FileName)
        {
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + FileName);
            HttpContext.Current.Response.Charset = "UTF-8";
            //HttpContext.Current.Response.Charset ="gb2312";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            HttpContext.Current.Response.ContentType = "application/ms-excel";//image/JPEG;text/HTML;image/GIF;vnd.ms-excel/msword
            System.Globalization.CultureInfo myCItrad = new System.Globalization.CultureInfo("ZH-CN", true);
            ctl.Page.EnableViewState = false;
            System.IO.StringWriter tw = new System.IO.StringWriter(myCItrad);
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            ctl.RenderControl(hw);
            HttpContext.Current.Response.Write("<html><head><meta content='text/html; charset=gb2312'   http-epuiv='content-type'></head><body>");
            HttpContext.Current.Response.Write(tw.ToString());
            HttpContext.Current.Response.Write("</body></html>");
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 根据XML文件关键字段查询XML文件的某字段值
        /// </summary>
        /// <param name="FileName">需要查询的XML文件名</param>
        /// <param name="Node">需要查询的节点</param>
        /// <param name="FindPKFieldName">需要查询的关键字段名</param>
        /// <param name="FindPKFieldValue">需要查询的关键字段值</param>
        /// <param name="index">需要查询某字段值的字段索引</param>
        public static string GetXmlValue(string FileName, string Node, string FindPKFieldName, string FindPKFieldValue, int index)
        {
            try
            {
                XmlDocument myDoc = new XmlDocument();
                if (FileName.IndexOf(".xml") > 0)
                    myDoc.Load(System.Web.HttpContext.Current.Server.MapPath(FileName));
                else
                    myDoc.Load(System.Web.HttpContext.Current.Server.MapPath(FileName + ".xml"));

                return myDoc.SelectSingleNode("//" + Node + "[" + FindPKFieldName + "='" + FindPKFieldValue + "']").ChildNodes.Item(index).InnerText;
            }
            catch
            {
                return "";
            }

        }
        /// <summary>
        /// 有效登陆判断
        /// </summary>
        public static void CheckLogin()
        {
            if (System.Web.HttpContext.Current.Session["LoginFlag"] == null)
            {
                System.Web.HttpContext.Current.Response.Redirect("Logout.aspx");
            }
            else
            {
                if (System.Web.HttpContext.Current.Session["LoginFlag"].ToString() != "1")
                    System.Web.HttpContext.Current.Response.Redirect("Logout.aspx");
            }

        }
        /// <summary>
        /// 检查用户的是否有操作权限
        /// </summary>
        /// <param name="PopedomName">权限名称</param>
        /// <param name="FieldName">字段名称</param>
        public static Boolean CheckPopedom(string PopedomName, string FieldName)
        {
            bool result = false;
            DataSet ds;
            if (System.Web.HttpContext.Current.Session["MyPopedom"] != null)
            {
                ds = (DataSet)System.Web.HttpContext.Current.Session["MyPopedom"];
                DataRow[] rows = ds.Tables[0].Select("PopedomName ='" + PopedomName + "'");
                if (rows.Length != 0)
                {
                    if ((int)rows[0][FieldName] == 1)
                        result = true;
                }
            }
            if (PopedomName == "")
                result = true;
            return result;
            //return true;
        }
        /// <summary>
        /// 取得系统设置表的值
        /// </summary>
        /// <param name="sName">查找的关键字名</param>
        public static string GetSysSet(string sName)
        {
            string result = "";
            DataSet ds;
            if (System.Web.HttpContext.Current.Session["SysSet"] != null)
            {
                ds = (DataSet)System.Web.HttpContext.Current.Session["SysSet"];
                DataRow[] rows = ds.Tables[0].Select("sName ='" + sName + "'");
                if (rows.Length != 0)
                {
                    result = rows[0]["sValue"].ToString();
                }
            }
            return result;
        }
        ///   <summary > 
        ///   文件下载 
        ///   </summary > 
        ///   <param   name= "SaveFileName " >存在服务器的文件名</param > 
        ///   <param   name= "DownloadFileName " >下载保存的文件名</param > 
        public static void FileDownload(string SaveFileName, string DownloadFileName)
        {
            FileStream fs = new FileStream(SaveFileName, FileMode.Open);
            long fsize = fs.Length;
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename= " + HttpUtility.UrlEncode(DownloadFileName, System.Text.Encoding.UTF8));
            HttpContext.Current.Response.AddHeader("Content-Length ", fsize.ToString());
            byte[] fileBuffer = new byte[fsize];
            fs.Read(fileBuffer, 0, (int)fsize);
            fs.Close();
            HttpContext.Current.Response.BinaryWrite(fileBuffer);
            HttpContext.Current.Response.End();
        }

        /// <summary>
        ///SQL注入过滤
        /// </summary>
        /// <param name="InText">要过滤的字符串</param>
        /// <returns>如果参数存在不安全字符，则返回true</returns>
        public static bool SqlFilter2(string InText)
        {
            string word = "exec|insert|select|delete|update|chr|mid|master|or|truncate|char|declare|join";
            if (InText == null)
                return false;
            foreach (string i in word.Split('|'))
            {
                if ((InText.ToLower().IndexOf(i + " ") > -1) || (InText.ToLower().IndexOf(" " + i) > -1) || (InText.ToLower().IndexOf(i + "+") > -1) || (InText.ToLower().IndexOf("+" + i) > -1))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        ///取字符串的长度(1个英文字符按1个字符算,1个中文按2个字符算)
        /// </summary>
        /// <param name="Str">字符串</param>
        /// <returns>字符串的长度</returns>
        public static int GetStrCount(string Str)
        {
            byte[] bStrCount = Encoding.GetEncoding("GB2312").GetBytes(Str);
            return bStrCount.Length;

        }
        ///   <summary>  
        ///   合并GridView列中相同的行  
        ///   </summary>  
        ///   <param   name="GridView1">GridView对象</param>  
        ///   <param   name="cellNum">需要合并的列</param>  
        public static void GroupRows(GridView GridView1, int cellNum)
        {
            int i = 0, rowSpanNum = 1;
            while (i < GridView1.Rows.Count - 1)
            {
                GridViewRow gvr = GridView1.Rows[i];
                for (++i; i < GridView1.Rows.Count; i++)
                {
                    GridViewRow gvrNext = GridView1.Rows[i];
                    if (gvr.Cells[cellNum].Text == gvrNext.Cells[cellNum].Text)
                    {
                        gvrNext.Cells[cellNum].Visible = false;
                        rowSpanNum++;
                    }
                    else
                    {
                        gvr.Cells[cellNum].RowSpan = rowSpanNum;
                        rowSpanNum = 1;
                        break;
                    }

                    if (i == GridView1.Rows.Count - 1)
                    {
                        gvr.Cells[cellNum].RowSpan = rowSpanNum;
                    }
                }
            }
        }

        ///   <summary>  
        ///   根据条件列合并GridView列中相同的行  
        ///   </summary>  
        ///   <param   name="GridView1">GridView对象</param>  
        ///   <param   name="cellNum">需要合并的列</param>
        ///   ///   <param   name="cellNum2">条件列(根据某条件列还合并)</param>
        public static void GroupRows(GridView GridView1, int cellNum, int cellNum2)
        {
            int i = 0, rowSpanNum = 1;
            while (i < GridView1.Rows.Count - 1)
            {
                GridViewRow gvr = GridView1.Rows[i];
                for (++i; i < GridView1.Rows.Count; i++)
                {
                    GridViewRow gvrNext = GridView1.Rows[i];
                    if (gvr.Cells[cellNum].Text + gvr.Cells[cellNum2].Text == gvrNext.Cells[cellNum].Text + gvrNext.Cells[cellNum2].Text)
                    {
                        gvrNext.Cells[cellNum].Visible = false;
                        rowSpanNum++;
                    }
                    else
                    {
                        gvr.Cells[cellNum].RowSpan = rowSpanNum;
                        rowSpanNum = 1;
                        break;
                    }

                    if (i == GridView1.Rows.Count - 1)
                    {
                        gvr.Cells[cellNum].RowSpan = rowSpanNum;
                    }
                }
            }
        }

        /// <summary>
        /// GridView合并列中相同的行(在PreRender事件中调用：MergeGridViewRows(gridView,0,5)）
        /// </summary>
        /// <param name="gdv">GridView</param>
        /// <param name="startColumnIndex">起始列Index</param>
        /// <param name="endColumnIndex">结束列Index</param>
        public static void MergeGridViewRows(GridView gdv, int startColumnIndex, int endColumnIndex)
        {
            if (gdv == null || endColumnIndex < startColumnIndex || gdv.Rows.Count < 2)
                return;
            //if (startColumnIndex < 0 || endColumnIndex > gdv.Columns.Count - 1)
            //    throw new ArgumentOutOfRangeException("列Index超出GridView可用列的范围。");
            EndColumnIndex = endColumnIndex;
            MergeCellWithSubColumn(gdv, 0, 0, gdv.Rows.Count - 1);
        }
        private static int EndColumnIndex = 0;

        /**//// <summary>
        /// 合并当前列和后续列
        /// </summary>
        /// <param name="currentColumnIndex">当前列</param>
        /// <param name="startRowIndex">起始行</param>
        /// <param name="endRowIndex">结束行</param>
        /// <summary>
        private static void MergeCellWithSubColumn(GridView gdv, int currentColumnIndex, int startRowIndex, int endRowIndex)
        {
            if (currentColumnIndex > EndColumnIndex)//结束递归
                return;
            string preValue = GetCellValue(gdv,startRowIndex, currentColumnIndex);
            string curValue = string.Empty;
            int endIndex = startRowIndex;
            for (int i = startRowIndex + 1; i <= endRowIndex + 1; i++)
            {
                if (i == endRowIndex + 1)
                    curValue = null;//完成最后一次合并
                else
                    curValue = GetCellValue(gdv, i, currentColumnIndex);
                if (curValue != preValue)
                {
                    //合并当前列
                    MergeColumnCell(gdv, currentColumnIndex, endIndex, i - 1);
                    //合并后续列
                    MergeCellWithSubColumn(gdv, currentColumnIndex + 1, endIndex, i - 1);
                    endIndex = i;
                    preValue = curValue;
                }
            }
        }

        /**//// <summary>
        /// 取得GridView中单个Cell的值
        /// </summary>
        /// <param name="gdv">GridView</param>
        /// <param name="rowIndex">行Index</param>
        /// <param name="columnIndex">列Index</param>
        /// <returns></returns>
        private static string GetCellValue(GridView gdv, int rowIndex, int columnIndex)
        {
            return gdv.Rows[rowIndex].Cells[columnIndex].Text;
        }

        /**//// <summary>
        /// 合并同列中连续的N个单元格
        /// 注意：这里只是隐藏后续的单元格，而没有删除单元格
        /// 主要考虑到删除后会如下两种情况：
        /// 1. PostBack后找不回来；
        /// 2.通过rowIndex和columnIndex来定位单元格的过程会更复杂
        /// </summary>
        /// <param name="gdv">GridView</param>
        /// <param name="columnIndex">列Index</param>
        /// <param name="startRowIndex">起始行Index</param>
        /// <param name="endRowIndex">结束行Index</param>
        private static void MergeColumnCell(GridView gdv, int columnIndex, int startRowIndex, int endRowIndex)
        {
            gdv.Rows[startRowIndex].Cells[columnIndex].RowSpan = endRowIndex - startRowIndex + 1;
            for (int i = startRowIndex + 1; i <= endRowIndex; i++)
                gdv.Rows[i].Cells[columnIndex].Visible = false;
        }
        /// <summary>
        /// 绑定部门到下拉列表
        /// </summary>
        /// <param name="DDLDepartment">部门下拉列表的ID</param>
        public static void BindDepartmentToDropDownList(DropDownList DDLDepartment)
        {
            SqlHelper conn=new SqlHelper();
            conn.BindTreeToDropDownList("AutoID", "Depart", "LayID", "Select * from Department where EnterpriseID=" + System.Web.HttpContext.Current.Session["EnterpriseID"].ToString() + " order by AutoID", 0, DDLDepartment);
        }

        
    }
}

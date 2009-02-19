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
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
        }

        /// <summary>
        /// ȡ�ÿͻ���IP��ַ
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
        /// ������棬����ģʽ���壬����ᶪʧSession
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
        /// ������Excel(ע�⣺��Ҫ���÷������ؼ���EnableViewState="true";������VerifyRenderingInServerForm����;���ʹ����ajax,��ô�����������嶼Ҫ�ύ,����������ⲿ�����ύ��ť)
        /// </summary>
        /// <param name="ctl">�ؼ�ID</param>
        /// <param name="FileName">�������ļ���</param>
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
        /// ����XML�ļ��ؼ��ֶβ�ѯXML�ļ���ĳ�ֶ�ֵ
        /// </summary>
        /// <param name="FileName">��Ҫ��ѯ��XML�ļ���</param>
        /// <param name="Node">��Ҫ��ѯ�Ľڵ�</param>
        /// <param name="FindPKFieldName">��Ҫ��ѯ�Ĺؼ��ֶ���</param>
        /// <param name="FindPKFieldValue">��Ҫ��ѯ�Ĺؼ��ֶ�ֵ</param>
        /// <param name="index">��Ҫ��ѯĳ�ֶ�ֵ���ֶ�����</param>
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
        /// ��Ч��½�ж�
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
        /// ����û����Ƿ��в���Ȩ��
        /// </summary>
        /// <param name="PopedomName">Ȩ������</param>
        /// <param name="FieldName">�ֶ�����</param>
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
        /// ȡ��ϵͳ���ñ��ֵ
        /// </summary>
        /// <param name="sName">���ҵĹؼ�����</param>
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
        ///   �ļ����� 
        ///   </summary > 
        ///   <param   name= "SaveFileName " >���ڷ��������ļ���</param > 
        ///   <param   name= "DownloadFileName " >���ر�����ļ���</param > 
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
        ///SQLע�����
        /// </summary>
        /// <param name="InText">Ҫ���˵��ַ���</param>
        /// <returns>����������ڲ���ȫ�ַ����򷵻�true</returns>
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
        ///ȡ�ַ����ĳ���(1��Ӣ���ַ���1���ַ���,1�����İ�2���ַ���)
        /// </summary>
        /// <param name="Str">�ַ���</param>
        /// <returns>�ַ����ĳ���</returns>
        public static int GetStrCount(string Str)
        {
            byte[] bStrCount = Encoding.GetEncoding("GB2312").GetBytes(Str);
            return bStrCount.Length;

        }
        ///   <summary>  
        ///   �ϲ�GridView������ͬ����  
        ///   </summary>  
        ///   <param   name="GridView1">GridView����</param>  
        ///   <param   name="cellNum">��Ҫ�ϲ�����</param>  
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
        ///   ���������кϲ�GridView������ͬ����  
        ///   </summary>  
        ///   <param   name="GridView1">GridView����</param>  
        ///   <param   name="cellNum">��Ҫ�ϲ�����</param>
        ///   ///   <param   name="cellNum2">������(����ĳ�����л��ϲ�)</param>
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
        /// GridView�ϲ�������ͬ����(��PreRender�¼��е��ã�MergeGridViewRows(gridView,0,5)��
        /// </summary>
        /// <param name="gdv">GridView</param>
        /// <param name="startColumnIndex">��ʼ��Index</param>
        /// <param name="endColumnIndex">������Index</param>
        public static void MergeGridViewRows(GridView gdv, int startColumnIndex, int endColumnIndex)
        {
            if (gdv == null || endColumnIndex < startColumnIndex || gdv.Rows.Count < 2)
                return;
            //if (startColumnIndex < 0 || endColumnIndex > gdv.Columns.Count - 1)
            //    throw new ArgumentOutOfRangeException("��Index����GridView�����еķ�Χ��");
            EndColumnIndex = endColumnIndex;
            MergeCellWithSubColumn(gdv, 0, 0, gdv.Rows.Count - 1);
        }
        private static int EndColumnIndex = 0;

        /**//// <summary>
        /// �ϲ���ǰ�кͺ�����
        /// </summary>
        /// <param name="currentColumnIndex">��ǰ��</param>
        /// <param name="startRowIndex">��ʼ��</param>
        /// <param name="endRowIndex">������</param>
        /// <summary>
        private static void MergeCellWithSubColumn(GridView gdv, int currentColumnIndex, int startRowIndex, int endRowIndex)
        {
            if (currentColumnIndex > EndColumnIndex)//�����ݹ�
                return;
            string preValue = GetCellValue(gdv,startRowIndex, currentColumnIndex);
            string curValue = string.Empty;
            int endIndex = startRowIndex;
            for (int i = startRowIndex + 1; i <= endRowIndex + 1; i++)
            {
                if (i == endRowIndex + 1)
                    curValue = null;//������һ�κϲ�
                else
                    curValue = GetCellValue(gdv, i, currentColumnIndex);
                if (curValue != preValue)
                {
                    //�ϲ���ǰ��
                    MergeColumnCell(gdv, currentColumnIndex, endIndex, i - 1);
                    //�ϲ�������
                    MergeCellWithSubColumn(gdv, currentColumnIndex + 1, endIndex, i - 1);
                    endIndex = i;
                    preValue = curValue;
                }
            }
        }

        /**//// <summary>
        /// ȡ��GridView�е���Cell��ֵ
        /// </summary>
        /// <param name="gdv">GridView</param>
        /// <param name="rowIndex">��Index</param>
        /// <param name="columnIndex">��Index</param>
        /// <returns></returns>
        private static string GetCellValue(GridView gdv, int rowIndex, int columnIndex)
        {
            return gdv.Rows[rowIndex].Cells[columnIndex].Text;
        }

        /**//// <summary>
        /// �ϲ�ͬ����������N����Ԫ��
        /// ע�⣺����ֻ�����غ����ĵ�Ԫ�񣬶�û��ɾ����Ԫ��
        /// ��Ҫ���ǵ�ɾ������������������
        /// 1. PostBack���Ҳ�������
        /// 2.ͨ��rowIndex��columnIndex����λ��Ԫ��Ĺ��̻������
        /// </summary>
        /// <param name="gdv">GridView</param>
        /// <param name="columnIndex">��Index</param>
        /// <param name="startRowIndex">��ʼ��Index</param>
        /// <param name="endRowIndex">������Index</param>
        private static void MergeColumnCell(GridView gdv, int columnIndex, int startRowIndex, int endRowIndex)
        {
            gdv.Rows[startRowIndex].Cells[columnIndex].RowSpan = endRowIndex - startRowIndex + 1;
            for (int i = startRowIndex + 1; i <= endRowIndex; i++)
                gdv.Rows[i].Cells[columnIndex].Visible = false;
        }
        /// <summary>
        /// �󶨲��ŵ������б�
        /// </summary>
        /// <param name="DDLDepartment">���������б��ID</param>
        public static void BindDepartmentToDropDownList(DropDownList DDLDepartment)
        {
            SqlHelper conn=new SqlHelper();
            conn.BindTreeToDropDownList("AutoID", "Depart", "LayID", "Select * from Department where EnterpriseID=" + System.Web.HttpContext.Current.Session["EnterpriseID"].ToString() + " order by AutoID", 0, DDLDepartment);
        }

        
    }
}

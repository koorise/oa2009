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
    public partial class tree_Operate : PageBase
    {
        public tree_Operate()
        {
            //PopedomName = "�û���������";   //����Ȩ������
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //if (!Public.CheckAuth(1))
                //{
                //    Response.Write("<script>alert('" + "��û��Ȩ��ʹ��������ܣ�" + "');window.location.href='MainPage.aspx'</script>");
                //    return;
                //}

                if (Request["autoid"] != null)
                {
                    //string str_Location=Request["autoid"].ToString().Substring(0,Request["autoid"].ToString().Length-1);

                    lbl_Curnodeid.Text = Request["autoid"].ToString();
                    //����Ǹ��ڵ�������imgbtn_DelNode
                    conn.GetRowRecord("select * from Department where AutoID="+Request["autoid"].ToString());
                    if(conn.dr["layid"].ToString()=="0")
                        imgbtn_DelNode.Visible = false;

                }
                //conn.Logon('B',Session["limit_code"],Page); // �ж��Ƿ���Ȩ�޵�½��ҳ��
                // ���������ǿͻ�����֤�������ж��Ƿ��������ֵ�
                imgbtn_AddChildNode.Attributes.Add("onclick", "return vdf('admin_Tree.txt_Mytext','������ڵ������','r');");
                imgbtn_AddBrotherNode.Attributes.Add("onclick", "return vdf('admin_Tree.txt_Mytext','������ڵ������','r');");
                imgbtn_AddRootNode.Attributes.Add("onclick", "return vdf('admin_Tree.txt_Mytext','������ڵ������','r');");
                imgbtn_DelNode.Attributes.Add("onclick", "return confirm('�����Ҫɾ����')");
                string str_Sql = "select * from  department where EnterpriseID=" + Session["EnterpriseID"].ToString();
                if (conn.GetRowCount(str_Sql) > 0) // ������ڼ�¼,����������
                {
                    imgbtn_AddRootNode.Visible = false;

                }
                else // �������ڼ�¼,������������
                {
                    imgbtn_DelNode.Visible = false;
                    imgbtn_AddBrotherNode.Visible = false;
                    imgbtn_AddChildNode.Visible = false;
                }
                if (conn.GetRowCount(str_Sql) == 0) // ������ݿ��û�д��ڼ�¼
                {
                    str_Sql = "select * from department where EnterpriseID='" + Session["EnterpriseID"].ToString() + "' order by order_id";
                }
                else
                {
                    str_Sql = "select * from department where layid='" + Request["autoid"].ToString() + "' and EnterpriseID='" + Session["EnterpriseID"].ToString() + "' order by order_id";
                }
                conn.BindRepeater(str_Sql, rpt_Graduate); // ��ʾѡ�н��ӵ��ӽڵ�


            }
        }

        protected void imgbtn_AddChildNode_Click(object sender, ImageClickEventArgs e)
        {
            if (Request["autoid"] == null) // �ж��Ƿ�ѡ���ұ�������
            {
                conn.JsIsNull("��ѡ����ߵ������ڵ�,������Ӳ���!", lbl_Error);
                return;
            }
            // �����������ӽڵ�
            conn.AddChildNode("autoid", "order_id", "layid", "depart", "department", lbl_Curnodeid, txt_Mytext, lbl_Error);
            string str_Sql = "select * from department where layid='" + Request["autoid"].ToString() + "' and EnterpriseID='" + Session["EnterpriseID"] + "' order by order_id";
            conn.BindRepeater(str_Sql, rpt_Graduate); // ��ʾѡ�н��ӵ��ӽڵ�
            // ˢ�����������
            lbl_Error.Text = "<script language=\"javascript\">parent.frames(\"leftFrame\").document.location.reload();</" + "script>";
        }

        protected void imgbtn_AddBrotherNode_Click(object sender, ImageClickEventArgs e)
        {
            if (Request["autoid"] == null) // �ж��Ƿ�ѡ���ұ�������
            {
                conn.JsIsNull("��ѡ����ߵ������ڵ�,������Ӳ���!", lbl_Error);
                return;
            }
            string str_Sql = "select * from department where autoid=" + lbl_Curnodeid.Text;
            conn.GetRowRecord(str_Sql);
            if (conn.dr["layid"].ToString() == "0")
            {
                conn.JsIsNull("���ܸ����ڵ������ֵܽڵ�,�������ӽڵ�!", lbl_Error); // �жϲ��ܸ����ڵ������ֵܽڵ�
                return;
            }
            // �����������ֵܽڵ�
            conn.AddBrotherNode("autoid", "order_id", "layid", "depart", "department", lbl_Curnodeid, txt_Mytext, lbl_Error); // �����ֵܽڵ�
            str_Sql = "select * from department where layid='" + Request["autoid"].ToString() + "' and EnterpriseID='" + Session["EnterpriseID"] + "' order by order_id";
            conn.BindRepeater(str_Sql, rpt_Graduate); // ��ʾѡ�н��ӵ��ӽڵ�
            // ˢ�����������
            lbl_Error.Text = "<script language=\"javascript\">parent.frames(\"leftFrame\").document.location.reload();</" + "script>";
        }

        protected void imgbtn_DelNode_Click(object sender, ImageClickEventArgs e)
        {
            if (Request["autoid"] == null) // �ж��Ƿ�ѡ���ұ�������
            {
                conn.JsIsNull("��ѡ���ұ߸�λ����!", lbl_Error);
                return;
            }
            try
            {
                conn.DelTreeViewNode("autoid", "layid", "department", lbl_Curnodeid); // �ݹ�ɾ���ڵ�
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Լ��") > 0)
                   System.Web.HttpContext.Current.Session["ShowMsg"] = "ɾ��ʧ�ܣ��ü�¼�������ģ��ʹ���ţ������ڱ��ģ����ɾ����ü�¼���������ݺ���ɾ���ü�¼��";
                else
                    System.Web.HttpContext.Current.Session["ShowMsg"] = "ɾ��ʧ�ܣ�";
                return;
            }
            Response.Redirect(Request.Url.LocalPath.Substring((Request.Url.LocalPath.LastIndexOf("/") + 1), Request.Url.LocalPath.Length - Request.Url.LocalPath.LastIndexOf("/") - 1) + "?autoid=" + Session["RootID"].ToString() + "&depart=" + Session["RootText"].ToString() + "&isReload=1");  //zz
            return;
            string str_Sql = "select * from department";
            if (conn.GetRowCount(str_Sql) > 0) // ��������д��ڼ�¼�������������Ȳ���
            {
                imgbtn_DelNode.Visible = true;
                imgbtn_AddBrotherNode.Visible = true;
                imgbtn_AddChildNode.Visible = true;
                imgbtn_AddRootNode.Visible = false;
            }
            else // ��������в����ڼ�¼,�������
            {
                imgbtn_DelNode.Visible = false;
                imgbtn_AddBrotherNode.Visible = false;
                imgbtn_AddChildNode.Visible = false;
                imgbtn_AddRootNode.Visible = true;
            }
            str_Sql = "select * from department where layid='" + Request["autoid"].ToString() + "' and EnterpriseID='" + Session["EnterpriseID"].ToString() + "' order by order_id";
            conn.BindRepeater(str_Sql, rpt_Graduate); // ��ʾѡ�н��ӵ��ӽڵ�
            lbl_Error.Text = "<script language=\"javascript\">parent.frames(\"leftFrame\").document.location.reload();</" + "script>";
        }

        protected void imgbtn_AddRootNode_Click(object sender, ImageClickEventArgs e)
        {
            if (txt_Mytext.Text != "")
            {
                // �������Ӹ��ڵ�
                string str_Sql = "select * from department";
                conn.Builder(str_Sql); // ��ʼ����
                conn.dr["order_id"] = 1; // ����
                conn.dr["layid"] = "0"; // ���ӵ�keyֵ
                conn.dr["depart"] = txt_Mytext.Text; // �ӵ���ʾ����
                conn.dr["EnterpriseID"] = Session["EnterpriseID"].ToString();
                conn.ds.Tables[0].Rows.Add(conn.dr);
                conn.myAdapter.Update(conn.ds); // ��ӳɹ�
                imgbtn_DelNode.Visible = true;
                imgbtn_AddBrotherNode.Visible = true;
                imgbtn_AddChildNode.Visible = true;
                imgbtn_AddRootNode.Visible = false;
            }
            // ˢ�����������
            lbl_Error.Text = "<script language=\"javascript\">parent.frames(\"leftFrame\").document.location.reload();</" + "script>";
        }
    }
}

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;
using System.Collections;

namespace OAWeb
{
    public class SqlHelper
    {
        /// <summary>
        /// ���ݷ��ʻ�����(����SQLServer)
        /// </summary>
        public SqlConnection myConnection;
        public SqlCommand myCommand;
        public SqlDataAdapter myAdapter;
        public SqlDataAdapter myAdapter1;
        public SqlDataReader myReader;
        public SqlCommandBuilder myCommandBuilder;
        public DataSet ds;
        public DataTable dt;
        public DataRow dr;
        public string strSQL;

        /// <summary>
        /// ����
        /// </summary>
        public SqlHelper()
        {
            Open();
            myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
        }
        /// <summary>
        /// ����
        /// </summary>
        ~SqlHelper()
        {
            Close();
        }
        /// <summary>
        /// �����ݿ�
        /// </summary>
        public void Open()
        {
            try
            {
                myConnection = new SqlConnection(System.Web.HttpContext.Current.Session["ConnectionString"].ToString());
                myConnection.Open();
            }
            catch (Exception ex)
            {
                System.Web.HttpContext.Current.Session["ShowMsg"] = "�������ݿ������ʧ��!" + ex.ToString();
                System.Web.HttpContext.Current.Response.Redirect("ShowMessage.aspx?PreviousPage=index.aspx");
            }
        }
        /// <summary>
        /// ��÷��ϸ�Sql���ı��¼��
        /// </summary>
        /// <param name="str_Sql">Select-SQL���</param>
        /// <returns>���ر��¼����</returns>
        public int GetRowCount(string str_Sql, SqlParameter[] cmdParms)
        {
            Fill(str_Sql, cmdParms);
            try
            {
                int count = ds.Tables[0].Rows.Count;
                ds.Clear();
                return count;
            }
            catch
            {
                ds.Clear();
                return 0;
            }
        }
        /// <summary>
        /// ��SqlDataReader������
        /// </summary>
        /// <param name="str_Sql">Select-SQL���</param>
        public void GetReader(string str_Sql, SqlParameter[] cmdParms)
        {
            PrepareCommand(myCommand, myConnection, null, str_Sql, cmdParms);
            myReader = myCommand.ExecuteReader();
            myCommand.Dispose();
        }
        /// <summary>
        /// ��ð�����DataSet�����ӳл�����е�indexΪ0��ӳл��
        /// </summary>
        /// <param name="str_Sql">Select-SQL���</param>
        public void GetTable(string str_Sql, SqlParameter[] cmdParms)
        {
            Fill(str_Sql, cmdParms);
            dt = ds.Tables[0];
        }
        /// <summary>
        /// ִ�в�ѯ��䣬����DataTable
        /// </summary>
        /// <param name="str_Sql">��ѯ���</param>
        /// <returns>DataTable</returns>
        public DataTable GetDataTable(string str_Sql, SqlParameter[] cmdParms)
        {
            GetTable(str_Sql, cmdParms);
            return dt;
        }

        /// <summary>
        /// ����DataSet����,�ü�¼���򹹼�(�����Ҫ)DataSet����,DataSet�����������ڴ�Ļ���
        /// </summary>
        /// <param name="str_Sql">�򿪱�Sql���</param>
        public void Fill(string str_Sql, SqlParameter[] cmdParms)
        {
            PrepareCommand(myCommand, myConnection, null, str_Sql, cmdParms);
            myAdapter = new SqlDataAdapter(myCommand);
            ds = new DataSet();
            myAdapter.Fill(ds);
        }
        /// <summary>
        /// ִ�в�ѯ��䣬����DataSet
        /// </summary>
        /// <param name="SQLString">��ѯ���</param>
        /// <returns>DataSet</returns>
        public DataSet GetDataSet(string str_Sql, SqlParameter[] cmdParms)
        {
            Fill(str_Sql, cmdParms);
            return ds;
        }
        /// <summary>
        /// �ر����ݿ�����DateSet����
        /// </summary>
        public void Close()
        {
            try
            {
                if (ds != null) // ���DataSet����
                {
                    ds.Clear();
                    ds.Dispose();
                }
                if (myConnection != null)
                {
                    if (myConnection.State == ConnectionState.Open)
                        myConnection.Close(); // �ر����ݿ�
                    myConnection.Dispose();
                }
                if (myCommand != null)
                {
                    myCommand.Dispose();
                }
            }
            catch { }
        }

        /// <summary>
        /// ��Repeater�ؼ�����ʾ��
        /// </summary>
        /// <param name="sql">Select-SQL���</param>
        /// <param name="myrepeater">Repeater�ؼ�idֵ</param>
        public void BindRepeater(string sql, SqlParameter[] cmdParms, Repeater myrepeater)
        {
            Fill(sql,cmdParms);
            myrepeater.DataSource = ds.Tables[0].DefaultView;
            myrepeater.DataBind();
        }
        /// <summary>
        /// ͨ����Sql���ؼ�keyֵ��ñ���һ�е�����
        /// </summary>
        /// <param name="str_Sql">���ؼ�Keyֵ������Select-SQL���</param>
        public void GetRowRecord(string str_Sql, SqlParameter[] cmdParms)
        {
            Fill(str_Sql, cmdParms);
            if (ds.Tables[0].Rows.Count > 0)
                dr = ds.Tables[0].Rows[0];
        }
        /// <summary>
        /// ����ʱ������ʾ�Ի���
        /// </summary>
        /// <param name="str_Prompt">��ʾ��Ϣ</param>
        /// <param name="lbl_Error">Label�ؼ�idֵ</param>
        public void JsIsNull(string str_Prompt, Label lbl_Error)
        {
            lbl_Error.Text = "<script language=\"javascript\">alert('" + str_Prompt + "');</" + "script>";
        }


        /// <summary>
        /// ִ�д�������SQL��䣬����Ӱ��ļ�¼��
        /// </summary>
        /// <param name="SQLString">SQL���</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public int ExeSql(string SQLString, SqlParameter[] cmdParms)
        {
            try
            {
                PrepareCommand(myCommand, myConnection, null, SQLString, cmdParms);
                int rows = myCommand.ExecuteNonQuery();
                myCommand.Parameters.Clear();
                return rows;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
            }
        }
        private void PrepareCommand(SqlCommand cmd, SqlConnection _SqlConnection, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            cmd.Connection = _SqlConnection;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }
        /// <summary>
        /// ִ�ж���SQL��䣬ʵ�����ݿ�����
        /// </summary>
        /// <param name="SQLStringList">����SQL���</param>		
        public void ExecuteSqlTran(ArrayList SQLStringList)
        {
            if (myConnection.State == ConnectionState.Closed)
                myConnection.Open();
            SupportViewIX();
            using (SqlTransaction tx = myConnection.BeginTransaction())
            {
                myCommand.Transaction = tx;
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            myCommand.CommandText = strsql;
                            myCommand.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    tx.Rollback();
                    throw new Exception(E.Message);
                }
            }
        }
        /// <summary>
        /// ͨ��SqlCommandBuilder�����������ݿ��¼
        /// </summary>
        /// <param name="sql">Select-SQL���</param>
        public void Builder(string sql)
        {
            myAdapter = new SqlDataAdapter(sql, myConnection);
            myCommandBuilder = new SqlCommandBuilder(myAdapter);
            ds = new DataSet();
            myAdapter.Fill(ds);
            dr = ds.Tables[0].NewRow();
        }
        /// <summary>
        /// ͨ��SqlCommandBuilder�����޸����ݿ��¼
        /// </summary>
        /// <param name="sql">Select-SQL���</param>
        public void BuilderEdit(string sql)
        {
            myAdapter = new SqlDataAdapter(sql, myConnection);
            myCommandBuilder = new SqlCommandBuilder(myAdapter);
            ds = new DataSet();
            myAdapter.Fill(ds);
            dr = ds.Tables[0].Rows[0];
        }
        /// <summary>
        /// �������ݿ�
        /// </summary>
        /// <param name="UpdateType">�������ݿ������(��Ϊ����:��Ӻ��޸�)</param>
        /// <param name="PreviousPage">��ʾ��Ϣ��ʾҳ���Ҫ���ص�ҳ��</param>
        public void Update(string UpdateType, string PreviousPage)
        {
           System.Web.HttpContext.Current.Session["ShowMsg"] = UpdateType + "�ɹ���";
            if (UpdateType == "���")
                ds.Tables[0].Rows.Add(dr);
            try
            {
                myAdapter.Update(ds); // �������ݿ�
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("�ظ���") > 0)
                {
                    System.Web.HttpContext.Current.Session["ShowMsg"] = UpdateType + "ʧ�ܣ����������ظ�������";
                }
                else
                {
                    System.Web.HttpContext.Current.Session["ShowMsg"] = UpdateType + "ʧ�ܣ�" + ex.ToString();
                }
            }
            if (UpdateType == "���")
                System.Web.HttpContext.Current.Response.Redirect("ShowMessage.aspx?PreviousPage=" + PreviousPage + ".aspx");
            else
                System.Web.HttpContext.Current.Response.Redirect("ShowMessage.aspx?PreviousPage=" + PreviousPage + ".aspx?AutoID=" + System.Web.HttpContext.Current.Request.QueryString["AutoID"].ToString());  //ע���޸�ҳ��Ĵ��ݲ�����������AutoID
        }
        /// <summary>
        /// ��DropDownList�ؼ�����ʾ����,DropDownList�ؼ�Value,Textֵ������str_Textֵ
        /// </summary>
        /// <param name="str_Text">��DropDownList�ؼ�Value,Textֵ���Ӧ���ݿ���ֶ���</param>
        /// <param name="sql">Select-SQL���</param>
        /// <param name="myDropDownList">DropDownList�ؼ�idֵ</param>
        public void BindDropDownList(string str_Text, string sql, DropDownList myDropDownList)
        {
            // ��DropDownList�ؼ���ע���ĸ�����,�ú�����Ҫһ���ֶ������ֱ��Value��Text��ֵ��Ĭ�ϱ�����
            Fill(sql,null);
            myDropDownList.DataSource = ds.Tables[0].DefaultView;
            myDropDownList.DataValueField = str_Text;
            myDropDownList.DataTextField = str_Text;
            myDropDownList.DataBind();
        }
        /// <summary>
        /// ��DropDownList�ؼ�����ʾ����,DropDownList�ؼ�Value,Textֵ���ֱ���ڵ���str_Value,str_Textֵ
        /// </summary>
        /// <param name="str_Value">��DropDownList�ؼ�Valueֵ���Ӧ���ݿ���ֶ���</param>
        /// <param name="str_Text">��DropDownList�ؼ�Textֵ���Ӧ���ݿ���ֶ���</param>
        /// <param name="sql">Select-SQL���</param>
        /// <param name="myDropDownList">DropDownList�ؼ�idֵ</param>
        public void BindDropDownList(string str_Value, string str_Text, string sql, DropDownList myDropDownList)
        {
            Fill(sql,null);
            myDropDownList.DataSource = ds.Tables[0].DefaultView;
            myDropDownList.DataValueField = str_Value;
            myDropDownList.DataTextField = str_Text;
            myDropDownList.DataBind();
        }
        /// <summary>
        /// ��ListBox�ؼ�����ʾ����,ListBox�ؼ�Value,Textֵ���ֱ���ڵ���str_Value,str_Textֵ
        /// </summary>
        /// <param name="str_Value">��ListBox�ؼ�Valueֵ���Ӧ���ݿ���ֶ���</param>
        /// <param name="str_Text">��ListBox�ؼ�Textֵ���Ӧ���ݿ���ֶ���</param>
        /// <param name="sql">Select-SQL���</param>
        /// <param name="myDropDownList">ListBox�ؼ�idֵ</param>
        public void BindListBox(string str_Value, string str_Text, string sql, ListBox myListBox)
        {
            Fill(sql,null);
            myListBox.DataSource = ds.Tables[0].DefaultView;
            myListBox.DataValueField = str_Value;
            myListBox.DataTextField = str_Text;
            myListBox.DataBind();
        }
        /// <summary>
        /// �����νṹ��DropDownList�ؼ����󶨲˵�
        /// </summary>
        /// <param name="sql">sql���</param>
        /// <param name="F_NodeID">�ڵ�IDֵ���ֶ���</param>
        /// <param name="F_NodeText">�ڵ��ı�ֵ���ֶ���</param>
        /// <param name="F_ParentID">���ڵ���ֶ���</param>
        /// <param name="NodeID">ֻ��ʾ�ýڵ������Ľڵ�</param>
        /// <param name="ddlPartent">�б�ؼ�</param>
        public void BindTreeToDropDownList(string F_NodeID, string F_NodeText, string F_ParentID, string sql, int NodeID, DropDownList ddlPartent)
        {
            DataTable dt = GetDataTable(sql,null);
            ddlPartent.Items.Clear();
            //������
            DataRow[] drs = dt.Select(F_ParentID + "=" + NodeID.ToString());
            foreach (DataRow r in drs)
            {
                string nodeid = r[F_NodeID].ToString();
                string text = r[F_NodeText].ToString();
                //string parentid=r["ParentID"].ToString();
                //string permissionid=r["PermissionID"].ToString();
                text = "��" + text;
                ddlPartent.Items.Add(new ListItem(text, nodeid));
                int sonparentid = int.Parse(nodeid);
                string blank = "��";

                BindNode(F_NodeID, F_NodeText, F_ParentID, sonparentid, dt, blank, ddlPartent);

            }
            ddlPartent.DataBind();

        }
        /// <summary>
        /// �ݹ�ڵ�
        /// </summary>
        /// <param name="parentid">���ڵ�</param>
        /// <param name="dt">���ݱ�</param>
        /// <param name="blank">ǰ׺</param>
        /// <param name="ddlPartent">�б����</param>
        public void BindNode(string F_NodeID, string F_NodeText, string F_ParentID, int parentid, DataTable dt, string blank, DropDownList ddlPartent)
        {
            DataRow[] drs = dt.Select(F_ParentID + "=" + parentid.ToString());

            foreach (DataRow r in drs)
            {
                string nodeid = r[F_NodeID].ToString();
                string text = r[F_NodeText].ToString();
                //string permissionid=r["PermissionID"].ToString();
                text = blank + "��" + text + "��";

                ddlPartent.Items.Add(new ListItem(text, nodeid));
                int sonparentid = int.Parse(nodeid);
                string blank2 = blank + "��";
                BindNode(F_NodeID, F_NodeText, F_ParentID, sonparentid, dt, blank2, ddlPartent);
            }
        }
        /// <summary>
        /// ��XML��DropDownList�ؼ�����ʾ����,DropDownList�ؼ�Value,Textֵ���ֱ���ڵ���str_Value,str_Textֵ
        /// </summary>
        /// <param name="str_Value">��DropDownList�ؼ�Valueֵ���Ӧ���ݿ���ֶ���</param>
        /// <param name="str_Text">��DropDownList�ؼ�Textֵ���Ӧ���ݿ���ֶ���</param>
        /// <param name="XMLPath">XML�ļ����·��</param>
        /// <param name="myDropDownList">DropDownList�ؼ�idֵ</param>
        public static void BindXMLToDropDownList(string str_Value, string str_Text, string XMLPath, DropDownList myDropDownList)
        {
            DataSet ds;
            ds = new DataSet();
            ds.ReadXml(System.Web.HttpContext.Current.Server.MapPath(XMLPath));
            myDropDownList.DataSource = ds.Tables[0];
            myDropDownList.DataTextField = ds.Tables[0].Columns[str_Text].ToString();
            myDropDownList.DataValueField = ds.Tables[0].Columns[str_Value].ToString();
            myDropDownList.DataBind();
        }
        /// <summary>
        /// ����1�������ؼ�����ʾ����>�ڵ�������,���Ӵ���һ������,���ݵĲ�����location
        /// </summary>
        /// <param name="f_key">���ݿ��ؼ���keyֵ��</param>
        /// <param name="f_parentkey">���ݿ���游�ڵ�idֵ�ֶ���</param>
        /// <param name="f_text">�ڵ���ʾ���������ݿ���ֶ���</param>
        /// <param name="str_Sql">Select-SQL���</param>
        /// <param name="Frame">�������ڵ�ʱ���ӵ�Ŀ����</param>
        /// <param name="Url">����ʱ������ҳ��</param>
        /// <param name="TreeView1">TreeView�ؼ�idֵ</param>
        public void BindTreeView(string f_key, string f_parentkey, string f_text, string str_Sql, string Frame, string Url, Label lbl_Curnodeid, TreeView TreeView1)
        {
            GetTable(str_Sql,null); // ��������ڴ��
            TreeView1.Nodes.Clear(); // �����
            TreeNode rootnode = new TreeNode();
            rootnode.Text = dt.Rows[0][f_text].ToString(); // ���ڵ����ʾֵ
            rootnode.Value = dt.Rows[0][f_key].ToString(); // ���ڵ��keyֵ
            lbl_Curnodeid.Text = dt.Rows[0][f_key].ToString(); //������ѡ��keyֵ
            rootnode.Expanded = true; //��Ĭ�ϸ����Ϊչ��
            rootnode.Target = Frame;
            rootnode.NavigateUrl = Url + "?" + f_key + "=" + dt.Rows[0][f_key].ToString() + "&" + f_parentkey + "=" + dt.Rows[0][f_parentkey].ToString();
            TreeView1.Nodes.Add(rootnode);
            string parentid = dt.Rows[0][f_key].ToString(); //���ӽڵ��parentid�ֶ�ֵ
            CreateNode(f_key, f_parentkey, f_text, Frame, Url, parentid, rootnode);//���������и�������µĽ�㡡												
        }
        /// <summary>
        /// ����1�������ؼ�����ʾ����>�ڵ�������,���Ӵ���һ������,���ݵĲ�����location
        /// </summary>
        /// <param name="f_key">���ݿ��ؼ���keyֵ��</param>
        /// <param name="f_parentkey">���ݿ���游�ڵ�idֵ�ֶ���</param>
        /// <param name="f_text">�ڵ���ʾ���������ݿ���ֶ���</param>
        /// <param name="str_Sql">Select-SQL���</param>
        /// <param name="Frame">�������ڵ�ʱ���ӵ�Ŀ����</param>
        /// <param name="Url">����ʱ������ҳ��</param>
        /// <param name="TreeView1">TreeView�ؼ�idֵ</param>

        public void CreateNode(string f_key, string f_parentkey, string f_text, string Frame, string Url, string parentid, TreeNode parentnode)
        {
            DataRow[] drs = dt.Select(f_parentkey + "= " + parentid);//��ѡ�������ӽڵ�
            //���������ӽڵ�
            foreach (DataRow r in drs)
            {
                TreeNode tempnode = new TreeNode();
                tempnode.Text = r[f_text].ToString();
                tempnode.Value = r[f_key].ToString();
                parentnode.ChildNodes.Add(tempnode);
                tempnode.Expanded = true;
                tempnode.Target = Frame;
                tempnode.NavigateUrl = Url + "?" + f_key + "=" + r[f_key].ToString() + "&" + f_parentkey + "=" + r[f_parentkey].ToString();
                parentid = r[f_key].ToString();		//�ı�ݹ�����
                CreateNode(f_key, f_parentkey, f_text, Frame, Url, parentid, tempnode);	//�ݹ�
            }
        }
        #region �洢���̲���

        /// <summary>
        /// ִ�д洢���̣���֧�ֶ�ε���,֧���з���ֵ�Ĵ洢����
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            SqlDataReader returnReader;
            SqlCommand command = BuildQueryCommand(myConnection, storedProcName, parameters);
            command.CommandType = CommandType.StoredProcedure;
            returnReader = command.ExecuteReader();
            return returnReader;
        }
        /// <summary>
        /// ִ�д洢����,֧�ֶ�ε���,��֧���з���ֵ�Ĵ洢����
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <returns>SqlDataReader</returns>
        public void ExecProcedure(string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, myConnection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                //command.Parameters.Add(parameter);    //��ε��û����
                command.Parameters.Add(parameter.ParameterName, parameter.DbType).Value = parameter.Value;  //�����ε��ó��������
            }
            command.ExecuteNonQuery();
        }
        /// <summary>
        /// ִ�д洢����
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <param name="tableName">DataSet����еı���</param>
        /// <returns>DataSet</returns>
        public DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            DataSet dataSet = new DataSet();
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = BuildQueryCommand(myConnection, storedProcName, parameters);
            sqlDA.Fill(dataSet, tableName);
            return dataSet;
        }


        /// <summary>
        /// ���� SqlCommand ����(��������һ���������������һ������ֵ)
        /// </summary>
        /// <param name="connection">���ݿ�����</param>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <returns>SqlCommand</returns>
        private SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);    //��ε��û����
                //command.Parameters.Add(parameter.ParameterName, parameter.DbType).Value = parameter.Value;  //�����ε��ó��������
            }
            return command;
        }

        /// <summary>
        /// ִ�д洢���̣�����Ӱ�������		
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <param name="rowsAffected">Ӱ�������</param>
        /// <returns></returns>
        public int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            int result;
            SqlCommand command = BuildIntCommand(myConnection, storedProcName, parameters);
            rowsAffected = command.ExecuteNonQuery();
            result = (int)command.Parameters["ReturnValue"].Value;
            //Connection.Close();
            return result;
        }

        /// <summary>
        /// ���� SqlCommand ����ʵ��(��������һ������ֵ)	
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <returns>SqlCommand ����ʵ��</returns>
        private SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue",
                SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }
        /// <summary>
        /// �󶨵�GridView�ؼ�		
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <param name="MyGridView">GridView�ؼ�ID</param>
        public void BindGridView(string sql, GridView MyGridView)
        {
            Fill(sql,null);
            MyGridView.DataSource = ds;
            MyGridView.DataBind();
        }
        /// <summary>
        /// �洢���̰󶨵�GridView�ؼ�		
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <param name="MyGridView">GridView�ؼ�ID</param>
        public void BindProcedureToGridView(string storedProcName, IDataParameter[] parameters, GridView MyGridView)
        {
            DataSet ds;
            ds = RunProcedure(storedProcName, parameters, "aa");
            MyGridView.DataSource = ds;
            MyGridView.DataBind();
        }
        /// <summary>
        /// �õ�ǰ����֧������ͼ����������������ı�Ĳ���
        /// </summary>
        /// <param name="storedProcName">�洢������</param>
        /// <param name="parameters">�洢���̲���</param>
        /// <returns>SqlDataReader</returns>
        public void SupportViewIX()
        {
            strSQL = "SET ANSI_PADDING,ANSI_WARNINGS,ARITHABORT,CONCAT_NULL_YIELDS_NULL,QUOTED_IDENTIFIER,ANSI_NULLS ON SET NUMERIC_ROUNDABORT OFF";   //��ִ��֧������ͼ�����ı�Ĳ��������
            myCommand.CommandText = strSQL;
            myCommand.ExecuteNonQuery();
        }
        /// <summary>
        /// �����ӽڵ�
        /// </summary>
        /// <param name="nodeid">���ݿ��ؼ���keyֵ�ֶ�</param>
        /// <param name="parentid">���ݿ���游�ڵ�idֵ�ֶ���</param>
        /// <param name="text">�ڵ���ʾ���������ݿ���ֶ���</param>
        /// <param name="tablename">���ݿ����</param>
        /// <param name="lbl_Curnodeid">��ǰ�ڵ�nodeidֵ</param>
        /// <param name="myText">Ҫ�����ֵܽڵ������TextBox�ؼ�Textֵ</param>
        /// <param name="lbl_Error">��ʾ������ʾ����˵��Label�ؼ�Textֵ</param>
        public void AddChildNode(string nodeid, string order_id, string parentid, string text, string tablename, Label lbl_Curnodeid, TextBox myText, Label lbl_Error)
        {
            if (myText.Text != "")
            {
                string str_Sql = "select max(" + nodeid + ") from  " + tablename;
                GetRowRecord(str_Sql,null);
                string str_MaxId = (int.Parse(dr[0].ToString()) + 1).ToString();
                //string str_Sql1 = "INSERT INTO " + tablename + "(" + order_id + "," + parentid + "," + text + ",EnterpriseID) VALUES (" + str_MaxId + "," + lbl_Curnodeid.Text + ",'" + myText.Text.Replace(" ", "") + "','" + System.Web.HttpContext.Current.Session["EnterpriseID"].ToString() + "')";
                string str_Sql1 = "INSERT INTO " + tablename + "(" + order_id + "," + parentid + "," + text + ",EnterpriseID) VALUES (@order_id,@parentid,@text,@EnterpriseID)";
                SqlParameter[] parameters ={
                                        new SqlParameter("@order_id",SqlDbType.Int),
                                        new SqlParameter("@parentid",SqlDbType.Int),
                                        new SqlParameter("@text",SqlDbType.VarChar,20),
                                        new SqlParameter("@EnterpriseID",SqlDbType.Int),
                                    };
                parameters[0].Value = str_MaxId;
                parameters[1].Value = Convert.ToInt32(lbl_Curnodeid.Text);
                parameters[2].Value = myText.Text.Replace(" ", "");
                parameters[3].Value = System.Web.HttpContext.Current.Session["EnterpriseID"].ToString();

                try
                {
                    ExeSql(str_Sql1, parameters);
                }
                catch
                {
                    HttpContext.Current.Session["ShowMsg"] = "�������Ʋ����ظ��������벻�ظ��Ĳ������� !";
                    string ss;
                    ss = "ShowMessage.aspx?PreviousPage=tree_Operate.aspx&Param=autoid=" + HttpContext.Current.Request["autoid"].ToString();
                    if (HttpContext.Current.Request["layid"] != null)
                        ss += "$layid=" + HttpContext.Current.Request["layid"].ToString();
                    if (HttpContext.Current.Request["depart"] != null)
                        ss += "$depart=" + HttpContext.Current.Request["depart"].ToString();
                    HttpContext.Current.Response.Redirect(ss);
                }
            }
            else
            {
                JsIsNull("����д�ڵ�����", lbl_Error);
            }
        }
        /// <summary>
        /// �����ֵܽڵ�
        /// </summary>
        /// <param name="nodeid">���ݿ��ؼ���keyֵ�ֶ�</param>
        /// <param name="parentid">���ݿ���游�ڵ�idֵ�ֶ���</param>
        /// <param name="text">�ڵ���ʾ���������ݿ���ֶ���</param>
        /// <param name="tablename">���ݿ����</param>
        /// <param name="lbl_Curnodeid">��ǰ�ڵ�nodeidֵ</param>
        /// <param name="myText">Ҫ�����ֵܽڵ������TextBox�ؼ�Textֵ</param>
        /// <param name="lbl_Error">��ʾ������ʾ����˵��Label�ؼ�Textֵ</param>
        public void AddBrotherNode(string nodeid, string order_id, string parentid, string text, string tablename, Label lbl_Curnodeid, TextBox myText, Label lbl_Error)
        {
            if (myText.Text != "")
            {
                string str_Sql = "select max(" + nodeid + ") from  " + tablename;
                GetRowRecord(str_Sql,null);
                string str_MaxId = (int.Parse(dr[0].ToString()) + 1).ToString();
                str_Sql = "select * from " + tablename + " where " + nodeid + "=" + lbl_Curnodeid.Text;
                GetRowRecord(str_Sql,null);
                //str_Sql = "INSERT INTO " + tablename + "(" + order_id + "," + parentid + "," + text + ",EnterpriseID) VALUES (" + str_MaxId + "," + dr["layid"].ToString() + ",'" + myText.Text.Replace(" ", "") + "','" + System.Web.HttpContext.Current.Session["EnterpriseID"].ToString() + "')";
                str_Sql = "INSERT INTO " + tablename + "(" + order_id + "," + parentid + "," + text + ",EnterpriseID) VALUES (@order_id,@parentid,@text,@EnterpriseID)";
                SqlParameter[] parameters ={
                                        new SqlParameter("@order_id",SqlDbType.Int),
                                        new SqlParameter("@parentid",SqlDbType.Int),
                                        new SqlParameter("@text",SqlDbType.VarChar,20),
                                        new SqlParameter("@EnterpriseID",SqlDbType.Int),
                                    };
                parameters[0].Value = str_MaxId;
                parameters[1].Value = Convert.ToInt32(dr["layid"]);
                parameters[2].Value = myText.Text.Replace(" ", "");
                parameters[3].Value = System.Web.HttpContext.Current.Session["EnterpriseID"].ToString();

                try
                {
                    ExeSql(str_Sql, parameters);
                }
                catch
                {
                    HttpContext.Current.Session["ShowMsg"] = "�������Ʋ����ظ��������벻�ظ��Ĳ������� !";
                    string ss;
                    ss = "ShowMessage.aspx?PreviousPage=tree_Operate.aspx&Param=autoid=" + HttpContext.Current.Request["autoid"].ToString();
                    if (HttpContext.Current.Request["layid"] != null)
                        ss += "$layid=" + HttpContext.Current.Request["layid"].ToString();
                    if (HttpContext.Current.Request["depart"] != null)
                        ss += "$depart=" + HttpContext.Current.Request["depart"].ToString();
                    HttpContext.Current.Response.Redirect(ss);
                }
            }
            else
            {
                JsIsNull("����д�ڵ�����", lbl_Error);
            }
        }
        /// <summary>
        /// ɾ�����ڵ�
        /// </summary>
        /// <param name="nodeid">���ݿ��ؼ���keyֵ�ֶ�</param>
        /// <param name="parentid">���ݿ���游�ڵ�idֵ�ֶ���</param>
        /// <param name="tablename">���ݿ����</param>
        /// <param name="lbl_Curnodeid">��ǰ�ڵ�nodeidֵ</param>
        public void DelTreeViewNode(string nodeid, string parentid, string tablename, Label lbl_Curnodeid)
        {
            //string str_Sql = "delete from " + tablename + " where " + nodeid + "=" + lbl_Curnodeid.Text + " or " + parentid + " like '%" + lbl_Curnodeid.Text + "%'";
            string str_Sql = "delete from " + tablename + " where " + nodeid + "=@nodeid or " + parentid + " like '%'+@nodeid+'%'";
            SqlParameter[] parameters ={
                                        new SqlParameter("@nodeid",SqlDbType.Int),
                                    };
            parameters[0].Value = lbl_Curnodeid.Text;

            ExeSql(str_Sql, parameters);
        }
        #endregion

    }
}

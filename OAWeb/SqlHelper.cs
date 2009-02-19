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
        /// 数据访问基础类(基于SQLServer)
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
        /// 构造
        /// </summary>
        public SqlHelper()
        {
            Open();
            myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
        }
        /// <summary>
        /// 析构
        /// </summary>
        ~SqlHelper()
        {
            Close();
        }
        /// <summary>
        /// 打开数据库
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
                System.Web.HttpContext.Current.Session["ShowMsg"] = "连接数据库服务器失败!" + ex.ToString();
                System.Web.HttpContext.Current.Response.Redirect("ShowMessage.aspx?PreviousPage=index.aspx");
            }
        }
        /// <summary>
        /// 获得符合该Sql语句的表记录数
        /// </summary>
        /// <param name="str_Sql">Select-SQL语句</param>
        /// <returns>返回表记录条数</returns>
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
        /// 用SqlDataReader读数据
        /// </summary>
        /// <param name="str_Sql">Select-SQL语句</param>
        public void GetReader(string str_Sql, SqlParameter[] cmdParms)
        {
            PrepareCommand(myCommand, myConnection, null, str_Sql, cmdParms);
            myReader = myCommand.ExecuteReader();
            myCommand.Dispose();
        }
        /// <summary>
        /// 获得包含在DataSet对象的映谢表集合中的index为0的映谢表
        /// </summary>
        /// <param name="str_Sql">Select-SQL语句</param>
        public void GetTable(string str_Sql, SqlParameter[] cmdParms)
        {
            Fill(str_Sql, cmdParms);
            dt = ds.Tables[0];
        }
        /// <summary>
        /// 执行查询语句，返回DataTable
        /// </summary>
        /// <param name="str_Sql">查询语句</param>
        /// <returns>DataTable</returns>
        public DataTable GetDataTable(string str_Sql, SqlParameter[] cmdParms)
        {
            GetTable(str_Sql, cmdParms);
            return dt;
        }

        /// <summary>
        /// 建立DataSet对象,用记录填充或构架(如果必要)DataSet对象,DataSet即是数据在内存的缓存
        /// </summary>
        /// <param name="str_Sql">打开表Sql语句</param>
        public void Fill(string str_Sql, SqlParameter[] cmdParms)
        {
            PrepareCommand(myCommand, myConnection, null, str_Sql, cmdParms);
            myAdapter = new SqlDataAdapter(myCommand);
            ds = new DataSet();
            myAdapter.Fill(ds);
        }
        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public DataSet GetDataSet(string str_Sql, SqlParameter[] cmdParms)
        {
            Fill(str_Sql, cmdParms);
            return ds;
        }
        /// <summary>
        /// 关闭数据库和清除DateSet对象
        /// </summary>
        public void Close()
        {
            try
            {
                if (ds != null) // 清除DataSet对象
                {
                    ds.Clear();
                    ds.Dispose();
                }
                if (myConnection != null)
                {
                    if (myConnection.State == ConnectionState.Open)
                        myConnection.Close(); // 关闭数据库
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
        /// 绑定Repeater控件并显示数
        /// </summary>
        /// <param name="sql">Select-SQL语句</param>
        /// <param name="myrepeater">Repeater控件id值</param>
        public void BindRepeater(string sql, SqlParameter[] cmdParms, Repeater myrepeater)
        {
            Fill(sql,cmdParms);
            myrepeater.DataSource = ds.Tables[0].DefaultView;
            myrepeater.DataBind();
        }
        /// <summary>
        /// 通过传Sql语句关键key值获得表中一行的数据
        /// </summary>
        /// <param name="str_Sql">带关键Key值参数的Select-SQL语句</param>
        public void GetRowRecord(string str_Sql, SqlParameter[] cmdParms)
        {
            Fill(str_Sql, cmdParms);
            if (ds.Tables[0].Rows.Count > 0)
                dr = ds.Tables[0].Rows[0];
        }
        /// <summary>
        /// 出错时弹出提示对话框
        /// </summary>
        /// <param name="str_Prompt">提示信息</param>
        /// <param name="lbl_Error">Label控件id值</param>
        public void JsIsNull(string str_Prompt, Label lbl_Error)
        {
            lbl_Error.Text = "<script language=\"javascript\">alert('" + str_Prompt + "');</" + "script>";
        }


        /// <summary>
        /// 执行带参数的SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
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
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
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
        /// 通过SqlCommandBuilder对象增加数据库记录
        /// </summary>
        /// <param name="sql">Select-SQL语句</param>
        public void Builder(string sql)
        {
            myAdapter = new SqlDataAdapter(sql, myConnection);
            myCommandBuilder = new SqlCommandBuilder(myAdapter);
            ds = new DataSet();
            myAdapter.Fill(ds);
            dr = ds.Tables[0].NewRow();
        }
        /// <summary>
        /// 通过SqlCommandBuilder对象修改数据库记录
        /// </summary>
        /// <param name="sql">Select-SQL语句</param>
        public void BuilderEdit(string sql)
        {
            myAdapter = new SqlDataAdapter(sql, myConnection);
            myCommandBuilder = new SqlCommandBuilder(myAdapter);
            ds = new DataSet();
            myAdapter.Fill(ds);
            dr = ds.Tables[0].Rows[0];
        }
        /// <summary>
        /// 更新数据库
        /// </summary>
        /// <param name="UpdateType">更新数据库的类型(分为两种:添加和修改)</param>
        /// <param name="PreviousPage">显示信息提示页面后要返回的页面</param>
        public void Update(string UpdateType, string PreviousPage)
        {
           System.Web.HttpContext.Current.Session["ShowMsg"] = UpdateType + "成功！";
            if (UpdateType == "添加")
                ds.Tables[0].Rows.Add(dr);
            try
            {
                myAdapter.Update(ds); // 更新数据库
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("重复键") > 0)
                {
                    System.Web.HttpContext.Current.Session["ShowMsg"] = UpdateType + "失败！不能输入重复的内容";
                }
                else
                {
                    System.Web.HttpContext.Current.Session["ShowMsg"] = UpdateType + "失败！" + ex.ToString();
                }
            }
            if (UpdateType == "添加")
                System.Web.HttpContext.Current.Response.Redirect("ShowMessage.aspx?PreviousPage=" + PreviousPage + ".aspx");
            else
                System.Web.HttpContext.Current.Response.Redirect("ShowMessage.aspx?PreviousPage=" + PreviousPage + ".aspx?AutoID=" + System.Web.HttpContext.Current.Request.QueryString["AutoID"].ToString());  //注意修改页面的传递参数名必须是AutoID
        }
        /// <summary>
        /// 绑定DropDownList控件并显示数据,DropDownList控件Value,Text值将等于str_Text值
        /// </summary>
        /// <param name="str_Text">绑定DropDownList控件Value,Text值相对应数据库表字段名</param>
        /// <param name="sql">Select-SQL语句</param>
        /// <param name="myDropDownList">DropDownList控件id值</param>
        public void BindDropDownList(string str_Text, string sql, DropDownList myDropDownList)
        {
            // 绑定DropDownList控件（注：四个函数,该函数需要一个字段名，分别绑定Value和Text两值，默认表名）
            Fill(sql,null);
            myDropDownList.DataSource = ds.Tables[0].DefaultView;
            myDropDownList.DataValueField = str_Text;
            myDropDownList.DataTextField = str_Text;
            myDropDownList.DataBind();
        }
        /// <summary>
        /// 绑定DropDownList控件并显示数据,DropDownList控件Value,Text值将分别等于等于str_Value,str_Text值
        /// </summary>
        /// <param name="str_Value">绑定DropDownList控件Value值相对应数据库表字段名</param>
        /// <param name="str_Text">绑定DropDownList控件Text值相对应数据库表字段名</param>
        /// <param name="sql">Select-SQL语句</param>
        /// <param name="myDropDownList">DropDownList控件id值</param>
        public void BindDropDownList(string str_Value, string str_Text, string sql, DropDownList myDropDownList)
        {
            Fill(sql,null);
            myDropDownList.DataSource = ds.Tables[0].DefaultView;
            myDropDownList.DataValueField = str_Value;
            myDropDownList.DataTextField = str_Text;
            myDropDownList.DataBind();
        }
        /// <summary>
        /// 绑定ListBox控件并显示数据,ListBox控件Value,Text值将分别等于等于str_Value,str_Text值
        /// </summary>
        /// <param name="str_Value">绑定ListBox控件Value值相对应数据库表字段名</param>
        /// <param name="str_Text">绑定ListBox控件Text值相对应数据库表字段名</param>
        /// <param name="sql">Select-SQL语句</param>
        /// <param name="myDropDownList">ListBox控件id值</param>
        public void BindListBox(string str_Value, string str_Text, string sql, ListBox myListBox)
        {
            Fill(sql,null);
            myListBox.DataSource = ds.Tables[0].DefaultView;
            myListBox.DataValueField = str_Value;
            myListBox.DataTextField = str_Text;
            myListBox.DataBind();
        }
        /// <summary>
        /// 绑定树形结构到DropDownList控件，绑定菜单
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="F_NodeID">节点ID值的字段名</param>
        /// <param name="F_NodeText">节点文本值的字段名</param>
        /// <param name="F_ParentID">父节点的字段名</param>
        /// <param name="NodeID">只显示该节点的下面的节点</param>
        /// <param name="ddlPartent">列表控件</param>
        public void BindTreeToDropDownList(string F_NodeID, string F_NodeText, string F_ParentID, string sql, int NodeID, DropDownList ddlPartent)
        {
            DataTable dt = GetDataTable(sql,null);
            ddlPartent.Items.Clear();
            //加载树
            DataRow[] drs = dt.Select(F_ParentID + "=" + NodeID.ToString());
            foreach (DataRow r in drs)
            {
                string nodeid = r[F_NodeID].ToString();
                string text = r[F_NodeText].ToString();
                //string parentid=r["ParentID"].ToString();
                //string permissionid=r["PermissionID"].ToString();
                text = "┼" + text;
                ddlPartent.Items.Add(new ListItem(text, nodeid));
                int sonparentid = int.Parse(nodeid);
                string blank = "├";

                BindNode(F_NodeID, F_NodeText, F_ParentID, sonparentid, dt, blank, ddlPartent);

            }
            ddlPartent.DataBind();

        }
        /// <summary>
        /// 递归节点
        /// </summary>
        /// <param name="parentid">父节点</param>
        /// <param name="dt">数据表</param>
        /// <param name="blank">前缀</param>
        /// <param name="ddlPartent">列表控制</param>
        public void BindNode(string F_NodeID, string F_NodeText, string F_ParentID, int parentid, DataTable dt, string blank, DropDownList ddlPartent)
        {
            DataRow[] drs = dt.Select(F_ParentID + "=" + parentid.ToString());

            foreach (DataRow r in drs)
            {
                string nodeid = r[F_NodeID].ToString();
                string text = r[F_NodeText].ToString();
                //string permissionid=r["PermissionID"].ToString();
                text = blank + "『" + text + "』";

                ddlPartent.Items.Add(new ListItem(text, nodeid));
                int sonparentid = int.Parse(nodeid);
                string blank2 = blank + "─";
                BindNode(F_NodeID, F_NodeText, F_ParentID, sonparentid, dt, blank2, ddlPartent);
            }
        }
        /// <summary>
        /// 把XML绑定DropDownList控件并显示数据,DropDownList控件Value,Text值将分别等于等于str_Value,str_Text值
        /// </summary>
        /// <param name="str_Value">绑定DropDownList控件Value值相对应数据库表字段名</param>
        /// <param name="str_Text">绑定DropDownList控件Text值相对应数据库表字段名</param>
        /// <param name="XMLPath">XML文件存放路径</param>
        /// <param name="myDropDownList">DropDownList控件id值</param>
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
        /// 重载1：绑定树控件并显示——>节点有连接,连接传递一个参数,传递的参数是location
        /// </summary>
        /// <param name="f_key">数据库表关键字key值名</param>
        /// <param name="f_parentkey">数据库表保存父节点id值字段名</param>
        /// <param name="f_text">节点显示文字树数据库表字段名</param>
        /// <param name="str_Sql">Select-SQL语句</param>
        /// <param name="Frame">单击树节点时连接的目标框架</param>
        /// <param name="Url">单击时连接网页名</param>
        /// <param name="TreeView1">TreeView控件id值</param>
        public void BindTreeView(string f_key, string f_parentkey, string f_text, string str_Sql, string Frame, string Url, Label lbl_Curnodeid, TreeView TreeView1)
        {
            GetTable(str_Sql,null); // 获得树的内存表
            TreeView1.Nodes.Clear(); // 清空树
            TreeNode rootnode = new TreeNode();
            rootnode.Text = dt.Rows[0][f_text].ToString(); // 给节点绑定显示值
            rootnode.Value = dt.Rows[0][f_key].ToString(); // 给节点绑定key值
            lbl_Curnodeid.Text = dt.Rows[0][f_key].ToString(); //　保存选中key值
            rootnode.Expanded = true; //　默认根结点为展开
            rootnode.Target = Frame;
            rootnode.NavigateUrl = Url + "?" + f_key + "=" + dt.Rows[0][f_key].ToString() + "&" + f_parentkey + "=" + dt.Rows[0][f_parentkey].ToString();
            TreeView1.Nodes.Add(rootnode);
            string parentid = dt.Rows[0][f_key].ToString(); //他子节点的parentid字段值
            CreateNode(f_key, f_parentkey, f_text, Frame, Url, parentid, rootnode);//　加入所有根结点以下的结点　												
        }
        /// <summary>
        /// 重载1：绑定树控件并显示——>节点有连接,连接传递一个参数,传递的参数是location
        /// </summary>
        /// <param name="f_key">数据库表关键字key值名</param>
        /// <param name="f_parentkey">数据库表保存父节点id值字段名</param>
        /// <param name="f_text">节点显示文字树数据库表字段名</param>
        /// <param name="str_Sql">Select-SQL语句</param>
        /// <param name="Frame">单击树节点时连接的目标框架</param>
        /// <param name="Url">单击时连接网页名</param>
        /// <param name="TreeView1">TreeView控件id值</param>

        public void CreateNode(string f_key, string f_parentkey, string f_text, string Frame, string Url, string parentid, TreeNode parentnode)
        {
            DataRow[] drs = dt.Select(f_parentkey + "= " + parentid);//　选出所有子节点
            //遍历所有子节点
            foreach (DataRow r in drs)
            {
                TreeNode tempnode = new TreeNode();
                tempnode.Text = r[f_text].ToString();
                tempnode.Value = r[f_key].ToString();
                parentnode.ChildNodes.Add(tempnode);
                tempnode.Expanded = true;
                tempnode.Target = Frame;
                tempnode.NavigateUrl = Url + "?" + f_key + "=" + r[f_key].ToString() + "&" + f_parentkey + "=" + r[f_parentkey].ToString();
                parentid = r[f_key].ToString();		//改变递归因子
                CreateNode(f_key, f_parentkey, f_text, Frame, Url, parentid, tempnode);	//递归
            }
        }
        #region 存储过程操作

        /// <summary>
        /// 执行存储过程，不支持多次调用,支持有返回值的存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
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
        /// 执行存储过程,支持多次调用,不支持有返回值的存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlDataReader</returns>
        public void ExecProcedure(string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, myConnection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                //command.Parameters.Add(parameter);    //多次调用会出错
                command.Parameters.Add(parameter.ParameterName, parameter.DbType).Value = parameter.Value;  //解决多次调用出错的问题
            }
            command.ExecuteNonQuery();
        }
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
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
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        private SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);    //多次调用会出错
                //command.Parameters.Add(parameter.ParameterName, parameter.DbType).Value = parameter.Value;  //解决多次调用出错的问题
            }
            return command;
        }

        /// <summary>
        /// 执行存储过程，返回影响的行数		
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowsAffected">影响的行数</param>
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
        /// 创建 SqlCommand 对象实例(用来返回一个整数值)	
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand 对象实例</returns>
        private SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue",
                SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }
        /// <summary>
        /// 绑定到GridView控件		
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="MyGridView">GridView控件ID</param>
        public void BindGridView(string sql, GridView MyGridView)
        {
            Fill(sql,null);
            MyGridView.DataSource = ds;
            MyGridView.DataBind();
        }
        /// <summary>
        /// 存储过程绑定到GridView控件		
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="MyGridView">GridView控件ID</param>
        public void BindProcedureToGridView(string storedProcName, IDataParameter[] parameters, GridView MyGridView)
        {
            DataSet ds;
            ds = RunProcedure(storedProcName, parameters, "aa");
            MyGridView.DataSource = ds;
            MyGridView.DataBind();
        }
        /// <summary>
        /// 让当前连接支持有视图索引或计算列索引的表的操作
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlDataReader</returns>
        public void SupportViewIX()
        {
            strSQL = "SET ANSI_PADDING,ANSI_WARNINGS,ARITHABORT,CONCAT_NULL_YIELDS_NULL,QUOTED_IDENTIFIER,ANSI_NULLS ON SET NUMERIC_ROUNDABORT OFF";   //先执行支持有视图索引的表的操作的语句
            myCommand.CommandText = strSQL;
            myCommand.ExecuteNonQuery();
        }
        /// <summary>
        /// 增加子节点
        /// </summary>
        /// <param name="nodeid">数据库表关键字key值字段</param>
        /// <param name="parentid">数据库表保存父节点id值字段名</param>
        /// <param name="text">节点显示文字树数据库表字段名</param>
        /// <param name="tablename">数据库表名</param>
        /// <param name="lbl_Curnodeid">当前节点nodeid值</param>
        /// <param name="myText">要增加兄弟节点的文字TextBox控件Text值</param>
        /// <param name="lbl_Error">显示错误提示文字说明Label控件Text值</param>
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
                    HttpContext.Current.Session["ShowMsg"] = "部门名称不能重复，请输入不重复的部门名称 !";
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
                JsIsNull("请填写节点内容", lbl_Error);
            }
        }
        /// <summary>
        /// 增加兄弟节点
        /// </summary>
        /// <param name="nodeid">数据库表关键字key值字段</param>
        /// <param name="parentid">数据库表保存父节点id值字段名</param>
        /// <param name="text">节点显示文字树数据库表字段名</param>
        /// <param name="tablename">数据库表名</param>
        /// <param name="lbl_Curnodeid">当前节点nodeid值</param>
        /// <param name="myText">要增加兄弟节点的文字TextBox控件Text值</param>
        /// <param name="lbl_Error">显示错误提示文字说明Label控件Text值</param>
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
                    HttpContext.Current.Session["ShowMsg"] = "部门名称不能重复，请输入不重复的部门名称 !";
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
                JsIsNull("请填写节点内容", lbl_Error);
            }
        }
        /// <summary>
        /// 删除树节点
        /// </summary>
        /// <param name="nodeid">数据库表关键字key值字段</param>
        /// <param name="parentid">数据库表保存父节点id值字段名</param>
        /// <param name="tablename">数据库表名</param>
        /// <param name="lbl_Curnodeid">当前节点nodeid值</param>
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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tree_Index.aspx.cs" Inherits="OAWeb.tree_Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ import Namespace="System.Data.SqlClient"%>
<%
//取m_department表第一条记录的autoid字段值
    SqlConnection MyConn1 = new SqlConnection(Session["ConnectionString"].ToString());
SqlCommand MyCommand1 = new SqlCommand();
MyCommand1.Connection = MyConn1;
MyConn1.Open();
SqlDataReader MyReader1;
MyCommand1.CommandText = "select * from department where EnterpriseID=" + Session["EnterpriseID"].ToString();
MyReader1 = MyCommand1.ExecuteReader();
string autoid="";
string depart="";
if(MyReader1.Read())
{
    Session["RootID"] = Server.UrlEncode(System.Convert.ToString(MyReader1.GetValue(0)));
    Session["RootText"] = Server.UrlEncode(System.Convert.ToString(MyReader1.GetValue(MyReader1.GetOrdinal("depart"))));
}
MyReader1.Close();
MyConn1.Close();
%>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
		<title>部门信息</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</head>
	 <frameset cols="250,*" frameborder="YES" border="2" framespacing="2" rows="*" bordercolor="#ffffff">
		<frame name="leftFrame" scrolling="AUTO" src="tree_Left.aspx" frameborder="YES" bordercolor="#FFE6BF" borderColorDark="#ffffff" bgColor="#fff3e1" borderColorLight="#ffb766">
		<frame name="treeFrame" id="treeFrame" src="tree_Operate.aspx?autoid=<%=Session["RootID"]%>&depart=<%=Session["RootText"]%>" frameborder="YES" scrolling="AUTO" bordercolor="#ffffff">
	</frameset>
	<noframes>
		<body bgcolor="#FFFFFF" text="#000000">
		</body>
	</noframes>
</html>

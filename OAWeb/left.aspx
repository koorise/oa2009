<%@ Page Language="C#" AutoEventWireup="True" Inherits="OAWeb.left" Codebehind="left.aspx.cs" %>

<html>
<head runat="server">
    <title>无标题页</title>
	<link href="style.css" type="text/css" rel="stylesheet" />
	<style>
        a { color: #000000; text-decoration: none}
	</style>
</head>
	<body bgColor='<%=Application[Session["Style"].ToString()+"xtree_bgcolor"]%>' 
	text=#000000 leftMargin=0 topMargin=0 onload="" marginheight="0" marginwidth="0" MS_POSITIONING="FlowLayout"
	style="SCROLLBAR-FACE-COLOR:<%=Application[Session["Style"].ToString()+"xtree_bgcolor"]%>; SCROLLBAR-HIGHLIGHT-COLOR: #ffffff; SCROLLBAR-SHADOW-COLOR: #9ebdf6; SCROLLBAR-3DLIGHT-COLOR: #9ebdf6; SCROLLBAR-ARROW-COLOR: #a7c4f7; SCROLLBAR-DARKSHADOW-COLOR: #ffffff; SCROLLBAR-BASE-COLOR: #c8dafa;"
	>
    <form id="form1" runat="server">
		<table height="100%" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td height="27"><img src='<%=Application[Session["Style"].ToString()+"xleft1_bgimage"]%>' width="200" height="27"></td>
			</tr>
			<tr>
				<td height="100%" valign="top" background='<%=Application[Session["Style"].ToString()+"xleftbj_bgimage"]%>'>
                    <asp:TreeView ID="TreeView2" runat="server" ShowLines="true" Font-Size="10pt">
                        <Nodes>
                            <asp:TreeNode ImageUrl="~/images/Menu/img-globe.gif" NavigateUrl="main.aspx" Target="mainFrame"
                                Text="回到首页" Value="回到首页"></asp:TreeNode>
                            <asp:TreeNode Expanded="false" Text="基础信息管理" SelectAction="expand">
                                <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="Role.aspx" Target="mainFrame"
                                    Text="角色权限设置"></asp:TreeNode>
                                <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="tree_index.aspx" Target="mainFrame"
                                    Text="部门设置"></asp:TreeNode>                                                                   
                                <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="Users.aspx" Target="mainFrame"
                                    Text="用户设置"></asp:TreeNode>
                                <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="UserDepartment.aspx" Target="mainFrame"
                                    Text="用户部门安排"></asp:TreeNode>                                    
                                 <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="MakeCardForUser.aspx" Target="mainFrame"
                                    Text="用户发卡"></asp:TreeNode>                                    
                                <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="ClientSetInfo.aspx" Target="mainFrame"
                                    Text="设备关联"></asp:TreeNode>
                            </asp:TreeNode>
                            
                            <asp:TreeNode Expanded="false" Text="考勤系统" SelectAction="expand">
                                <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="AttendTime.aspx" Target="mainFrame"
                                    Text="考勤时段设置"></asp:TreeNode>
                                <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="AttendShift.aspx" Target="mainFrame"
                                    Text="轮班设置"></asp:TreeNode>
                                <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="AttendShift.aspx" Target="mainFrame"
                                    Text="排班设置"></asp:TreeNode>
                                <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="AttendRecord.aspx" Target="mainFrame"
                                    Text="考勤记录查询"></asp:TreeNode>
                                <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="TimeBookReport.aspx" Target="mainFrame"
                                    Text="考勤统计"></asp:TreeNode>                        
                            </asp:TreeNode>
                            <asp:TreeNode Expanded="false" Text="OA系统" SelectAction="expand">
                                <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="SendTo.aspx" Target="mainFrame"
                                    Text="发送短信"></asp:TreeNode>
                                <asp:TreeNode Expanded="true"  SelectAction="expand" Text="通知">
                                    <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="SendNotice.aspx" Target="mainFrame"
                                        Text="发送通知"></asp:TreeNode>
                                    <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="SendNotice_F.aspx" Target="mainFrame"
                                        Text="已发通知"></asp:TreeNode>
                                    <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="SendNotice_R.aspx" Target="mainFrame"
                                        Text="已收通知"></asp:TreeNode>
                                </asp:TreeNode>
                                <asp:TreeNode Expanded="true"  SelectAction="expand" Text="工作流">
                                    <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="Workflow_Create.aspx" Target="mainFrame"
                                        Text="新建工作流"></asp:TreeNode>
                                    <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="Workflow_Find.aspx" Target="mainFrame"
                                        Text="工作流查询"></asp:TreeNode>
                                    <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="Workflow_Approval.aspx" Target="mainFrame"
                                        Text="待我审批"></asp:TreeNode>
                                    <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="Workflow_Approvaled.aspx" Target="mainFrame"
                                        Text="已办审批"></asp:TreeNode>
                                </asp:TreeNode>                                
                            </asp:TreeNode>
                            <asp:TreeNode  NavigateUrl="OCXDownload.aspx" Target="mainFrame"
                                Text="控件下载"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="images/logout1.gif" NavigateUrl="logout.aspx" Text="&lt;span onclick=&quot;return confirm('你确定要退出吗?')&quot; /&gt;退出系统&lt;/span/&gt;">
                            </asp:TreeNode>
                        </Nodes>
                    </asp:TreeView>
				</td>
			</tr>
			<tr>
				<td height="19"><img src='<%=Application[Session["Style"].ToString()+"xleft2_bgimage"]%>' width="200" height="19"></td>
			</tr>
		</table>
    </form>
</body>
</html>

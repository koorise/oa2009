<%@ Page Language="C#" AutoEventWireup="True" Inherits="OAWeb.left" Codebehind="left.aspx.cs" %>

<html>
<head runat="server">
    <title>�ޱ���ҳ</title>
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
                                Text="�ص���ҳ" Value="�ص���ҳ"></asp:TreeNode>
                            <asp:TreeNode Expanded="false" Text="������Ϣ����" SelectAction="expand">
                                <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="Role.aspx" Target="mainFrame"
                                    Text="��ɫȨ������"></asp:TreeNode>
                                <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="tree_index.aspx" Target="mainFrame"
                                    Text="��������"></asp:TreeNode>                                                                   
                                <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="Users.aspx" Target="mainFrame"
                                    Text="�û�����"></asp:TreeNode>
                                <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="UserDepartment.aspx" Target="mainFrame"
                                    Text="�û����Ű���"></asp:TreeNode>                                    
                                 <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="MakeCardForUser.aspx" Target="mainFrame"
                                    Text="�û�����"></asp:TreeNode>                                    
                                <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="ClientSetInfo.aspx" Target="mainFrame"
                                    Text="�豸����"></asp:TreeNode>
                            </asp:TreeNode>
                            
                            <asp:TreeNode Expanded="false" Text="����ϵͳ" SelectAction="expand">
                                <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="AttendTime.aspx" Target="mainFrame"
                                    Text="����ʱ������"></asp:TreeNode>
                                <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="AttendShift.aspx" Target="mainFrame"
                                    Text="�ְ�����"></asp:TreeNode>
                                <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="AttendShift.aspx" Target="mainFrame"
                                    Text="�Ű�����"></asp:TreeNode>
                                <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="AttendRecord.aspx" Target="mainFrame"
                                    Text="���ڼ�¼��ѯ"></asp:TreeNode>
                                <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="TimeBookReport.aspx" Target="mainFrame"
                                    Text="����ͳ��"></asp:TreeNode>                        
                            </asp:TreeNode>
                            <asp:TreeNode Expanded="false" Text="OAϵͳ" SelectAction="expand">
                                <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="SendTo.aspx" Target="mainFrame"
                                    Text="���Ͷ���"></asp:TreeNode>
                                <asp:TreeNode Expanded="true"  SelectAction="expand" Text="֪ͨ">
                                    <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="SendNotice.aspx" Target="mainFrame"
                                        Text="����֪ͨ"></asp:TreeNode>
                                    <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="SendNotice_F.aspx" Target="mainFrame"
                                        Text="�ѷ�֪ͨ"></asp:TreeNode>
                                    <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="SendNotice_R.aspx" Target="mainFrame"
                                        Text="����֪ͨ"></asp:TreeNode>
                                </asp:TreeNode>
                                <asp:TreeNode Expanded="true"  SelectAction="expand" Text="������">
                                    <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="Workflow_Create.aspx" Target="mainFrame"
                                        Text="�½�������"></asp:TreeNode>
                                    <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="Workflow_Find.aspx" Target="mainFrame"
                                        Text="��������ѯ"></asp:TreeNode>
                                    <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="Workflow_Approval.aspx" Target="mainFrame"
                                        Text="��������"></asp:TreeNode>
                                    <asp:TreeNode ImageUrl="images/Menu/man.gif" NavigateUrl="Workflow_Approvaled.aspx" Target="mainFrame"
                                        Text="�Ѱ�����"></asp:TreeNode>
                                </asp:TreeNode>                                
                            </asp:TreeNode>
                            <asp:TreeNode  NavigateUrl="OCXDownload.aspx" Target="mainFrame"
                                Text="�ؼ�����"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="images/logout1.gif" NavigateUrl="logout.aspx" Text="&lt;span onclick=&quot;return confirm('��ȷ��Ҫ�˳���?')&quot; /&gt;�˳�ϵͳ&lt;/span/&gt;">
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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tree_Operate.aspx.cs" Inherits="OAWeb.tree_Operate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
	<link href="style.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    
    <div style="text-align:center">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    
		<table id="Table1" cellspacing="0" cellpadding="0"  border="0" style="text-align:center">
			<tr>
				<td>
					<table cellspacing="0" cellpadding="5" width="700" border="0">
						<tr>
							<td align="right">
							    <img src="images/imgbtn/page_icon.gif"  align="absBottom"  border="0" />
							    部门名称
                                <asp:TextBox ID="DepartmentName" runat="server"></asp:TextBox>
                                <asp:Button ID="Button1" runat="server" Text="增加下级部门" />	
                                <asp:Button ID="Button2" runat="server" Text="增加同级部门" />	
                                <asp:Button ID="Button3" runat="server" Text="删除部门" />	
							</td>
						</tr>			
                        		
						<tr>
							<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>">	
                                <asp:GridView ID="GridView1" runat="server" DataKeyNames="AutoID" Width="700" DataSourceID="SqlDataSource1" ShowFooter="true">
                                    <EmptyDataTemplate>
                                        没有数据
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:HyperLinkField DataNavigateUrlFields="AutoID" Text="&lt;img src=images/button_edit.gif border=0 alt=修改 /&gt;" DataNavigateUrlFormatString="UsersAdd.aspx?AutoID={0}" HeaderText="编辑" />
                                        <asp:BoundField DataField="UserName" HeaderText="用户姓名" SortExpression="UserName" />
                                        <asp:BoundField DataField="Mobile" HeaderText="手机号码" SortExpression="Mobile" />
                                        <asp:BoundField DataField="RoleName" HeaderText="角色" SortExpression="RoleName"/>
                                        <asp:BoundField DataField="ShiftName" HeaderText="轮班名称" SortExpression="ShiftName" />
                                        <asp:BoundField DataField="IsStop" HeaderText="是否停用" SortExpression="IsStop" />
                                        <asp:BoundField DataField="CardAddress" HeaderText="卡地址" />
                                        <asp:TemplateField HeaderText="删除">
                                             <ItemTemplate>
                       							<SPAN onclick="return window.confirm('你确定要删除该记录吗？')">
                                                    <asp:LinkButton ID="LinkButton1" CommandName="Del" runat="server" Text="&lt;img src=images/button_del.gif border=0 /&gt;"></asp:LinkButton>
           										</SPAN>
                                             </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server">
                                </asp:SqlDataSource>
                                </td>
						</tr>
					</table>
				</td>
			</tr>
		</table>    
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress ID="UpdateProgress1" runat="server">
    <ProgressTemplate>
        <div class="abc"></div>
        <div class="abc1"><div style="color:Red; font-size:13pt;"> 正在读取数据... <img src="images/progress.gif" /></div></div>
    </ProgressTemplate>
</asp:UpdateProgress>
	</div>    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="True" Inherits="OAWeb.Users" Codebehind="Users.aspx.cs" %>
<%@ Register Src="UserControl/Filter.ascx" TagName="Filter" TagPrefix="uc2" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>�ޱ���ҳ</title>
	<link href="style.css" type="text/css" rel="stylesheet" />
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
							<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>">
								<table cellspacing=0 borderColorDark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' 
                                    cellPadding=5 width="100%" 
                                    borderColorLight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>' 
                                    border=1>
									<tr>
										<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>">                      
                                            <asp:Label ID="Label1" runat="server" Text="Label" SkinID="Title">�û�����</asp:Label></td>
									</tr>									
								</table>
							</td>
						</tr>
						<tr>
							<td align="right">
                                <asp:CheckBox ID="CheckBox1" runat="server" Text="��ʾ��ͣ�õ��û�" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" />
							    &nbsp;&nbsp;&nbsp;&nbsp;
                                <uc2:Filter ID="Filter1" runat="server"   OnConditionChanged="OnConditionChanged" />
							    &nbsp;&nbsp;
								<asp:LinkButton id="LinkButton1" runat="server" OnClick="LinkButton1_Click">
								<IMG src="images/add.gif" align="absBottom" border="0">����</asp:LinkButton>
							</td>
						</tr>						
						<tr>
							<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>">	
                                <asp:GridView ID="GridView1" runat="server" DataKeyNames="AutoID" Width="700" DataSourceID="SqlDataSource1" ShowFooter="true" 
                                OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanged="GridView1_PageIndexChanged">
                                    <EmptyDataTemplate>
                                        û������
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:HyperLinkField DataNavigateUrlFields="AutoID" Text="&lt;img src=images/button_edit.gif border=0 alt=�޸� /&gt;" DataNavigateUrlFormatString="UsersAdd.aspx?AutoID={0}" HeaderText="�༭" />
                                        <asp:BoundField DataField="UserName" HeaderText="�û�����" SortExpression="UserName" />
                                        <asp:BoundField DataField="Mobile" HeaderText="�ֻ�����" SortExpression="Mobile" />
                                        <asp:BoundField DataField="RoleName" HeaderText="��ɫ" SortExpression="RoleName"/>
                                        <asp:BoundField DataField="ShiftName" HeaderText="�ְ�����" SortExpression="ShiftName" />
                                        <asp:BoundField DataField="IsStop" HeaderText="�Ƿ�ͣ��" SortExpression="IsStop" />
                                        <asp:BoundField DataField="CardAddress" HeaderText="����ַ" />
                                        <asp:TemplateField HeaderText="ɾ��">
                                             <ItemTemplate>
                       							<SPAN onclick="return window.confirm('��ȷ��Ҫɾ���ü�¼��')">
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
        <div class="abc1"><div style="color:Red; font-size:13pt;"> ���ڶ�ȡ����... <img src="images/progress.gif" /></div></div>
    </ProgressTemplate>
</asp:UpdateProgress>
	</div>
    </form>
</body>
</html>

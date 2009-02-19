<%@ Page Language="C#" AutoEventWireup="True" Inherits="OAWeb.SendNotice_F" Codebehind="SendNotice_F.aspx.cs" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
	<link href="style.css" type="text/css" rel="stylesheet">
	<style>
        a { color:blue; text-decoration: none}
	</style>	
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
					<table cellspacing="0" cellpadding="5" width="750" border="0">
						<tr>
							<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>">
								<table cellspacing=0 borderColorDark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' 
                                    cellPadding=5 width="100%" 
                                    borderColorLight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>' 
                                    border=1>
									<tr>
										<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>">                      
                                            <asp:Label ID="Label1" runat="server" Text="Label" SkinID="Title">已发通知</asp:Label></td>
									</tr>
								</table>
							</td>
						</tr>
						<tr>
							<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>">	
                                        <asp:GridView ID="GridView1" DataKeyNames="AutoID" runat="server" ShowFooter="true" DataSourceID="SqlDataSource1"
                                          OnRowDataBound="GridView1_RowDataBound" Width="750" OnRowCommand="GridView1_RowCommand">
                                            <EmptyDataTemplate>
                                                没有数据
                                            </EmptyDataTemplate>
                                            <Columns>
                                                <asp:BoundField DataField="UserName" HeaderText="发送人"/>
                                                <asp:BoundField DataField="SendTime" HeaderText="发送时间" HeaderStyle-Width="115" />
                                                <asp:TemplateField HeaderText="标题" HeaderStyle-Width="400">
                                                     <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton2" CommandName="Sel" CommandArgument='<%# Eval("AutoID") %>' runat="server" Text='<%# Eval("Title") %>'></asp:LinkButton>
                                                     </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="SendType" HeaderText="类别" />
                                                <asp:ButtonField CommandName="Sel1" HeaderText="接收情况" ButtonType="Image" ImageUrl="images/user16.gif" />
                                                <asp:TemplateField HeaderText="删除">
                                                     <ItemTemplate>
                               							<SPAN onclick="return window.confirm('你确定要删除该记录吗？')">
                                                            <asp:LinkButton ID="LinkButton1" CommandName="Del" CommandArgument='<%# Eval("AutoID") %>' runat="server" Text="&lt;img src=images/button_del.gif border=0 /&gt;"></asp:LinkButton>
                   										</SPAN>
                                                     </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>                                                
                                        </asp:GridView>
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                        <div class="abc"></div>
                                        <div class="abc1"><div style="color:Red; font-size:13pt;"> 正在读取数据... <img src="images/progress.gif" /></div></div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                                SelectCommand="SELECT * FROM SendNoticeV WHERE ([SUserID] = @SUserID) ORDER BY [SendTime] DESC">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="SUserID" SessionField="UserID" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
						</tr>
					</table>
				</td>
			</tr>
		</table>    
        </ContentTemplate>
    </asp:UpdatePanel>
	</div>
    </form>
</body>
</html>

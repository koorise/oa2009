<%@ Page Language="C#" AutoEventWireup="True" Inherits="OAWeb.SendNotice_V" Codebehind="SendNotice_V.aspx.cs" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
	<LINK href="style.css" type="text/css" rel="stylesheet">
	<style>
        a { color:blue; text-decoration: none}
	</style>	
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    
    <div style="text-align:center">
<%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    
		<table id="Table1" cellspacing="0" cellpadding="0"  border="0" style="text-align:center">
			<tr>
				<td>
					<table cellspacing="0" cellpadding="5" width="500" border="0">
						<tr>
							<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>">
								<table cellspacing=0 borderColorDark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' 
                                    cellPadding=5 width="100%" 
                                    borderColorLight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>' 
                                    border=1>
									<tr>
										<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>">                      
                                            <asp:Label ID="Label1" runat="server" Text="Label" SkinID="Title">接收情况</asp:Label></td>
									</tr>
								</table>
							</td>
						</tr>
						<tr>
							<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>">	
                                        <asp:GridView ID="GridView1" DataKeyNames="AutoID" runat="server" ShowFooter="True" DataSourceID="SqlDataSource1"
                                          OnRowDataBound="GridView1_RowDataBound" Width="500px">
                                            <EmptyDataTemplate>
                                                没有数据
                                            </EmptyDataTemplate>
                                            <Columns>
                                                <asp:BoundField DataField="Name" HeaderText="接收人"/>
                                                <asp:BoundField DataField="ViewTime" HeaderText="查看时间" />
                                            </Columns>                                                
                                        </asp:GridView>
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                        <div class="abc"></div>
                                        <div class="abc1"><div style="color:Red; font-size:13pt;"> 正在读取数据... <img src="images/progress.gif" /></div></div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                                SelectCommand="SELECT * FROM [SendNotice_MV] WHERE ([SendNoticeID] = @SendNoticeID) ORDER BY [ViewTime] DESC">
                                    <SelectParameters>
                                        <asp:QueryStringParameter Name="SendNoticeID" QueryStringField="AutoID" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
						</tr>
					</table>
				</td>
			</tr>
		</table>    
<%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
		<input type="button" value="返   回" class="button" onclick="window.location.href='SendNotice_F.aspx'" />          
	</div>
    </form>
</body>
</html>

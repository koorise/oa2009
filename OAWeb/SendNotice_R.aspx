<%@ Page Language="C#" AutoEventWireup="True" Inherits="OAWeb.SendNotice_R" Codebehind="SendNotice_R.aspx.cs" %>
<%@ Register Src="UserControl/Filter.ascx" TagName="Filter" TagPrefix="uc2" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=gb2312">
	<LINK href="style.css" type="text/css" rel="stylesheet">
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
                                            <asp:Label ID="Label1" runat="server" Text="Label" SkinID="Title">已收通知</asp:Label></td>
									</tr>
								</table>
							</td>
						</tr>
						<tr>
							<td align="right">
                                <uc2:Filter ID="Filter1" runat="server"   OnConditionChanged="OnConditionChanged" />
							</td>
						</tr>						
						<tr>
							<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>">	
                                        <asp:GridView ID="GridView1" DataKeyNames="AutoID" runat="server" ShowFooter="true" DataSourceID="SqlDataSource1"
                                          OnRowDataBound="GridView1_RowDataBound" Width="750" OnRowCommand="GridView1_RowCommand" OnPageIndexChanged="GridView1_PageIndexChanged">
                                            <EmptyDataTemplate>
                                                没有数据
                                            </EmptyDataTemplate>
                                            <Columns>
                                                <asp:BoundField DataField="UserName" HeaderText="发送人"/>
                                                <asp:BoundField DataField="SendTime" HeaderText="发送时间" HeaderStyle-Width="115" />
                                                <asp:TemplateField HeaderText="标题" HeaderStyle-Width="450">
                                                     <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton2" CommandName="Sel" CommandArgument='<%# Eval("AutoID") %>' runat="server" Text='<%# Eval("Title") %>'></asp:LinkButton>
                                                     </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="SendType" HeaderText="类别" />
                                            </Columns>                                                
                                        </asp:GridView>
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                        <div class="abc"></div>
                                        <div class="abc1"><div style="color:Red; font-size:13pt;"> 正在读取数据... <img src="images/progress.gif" /></div></div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
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
	</div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="True" Inherits="OAWeb.AttendTime" Codebehind="AttendTime.aspx.cs" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div style="text-align:center">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    
        <table id="Table1" border="0" cellpadding="0" cellspacing="0" style="width: 600px">
            <tr>
                <td>
                <table cellspacing="0" cellpadding="5" border="0" style="width: 600px">
						<tr>
							<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>; width: 612px;">
								<table cellspacing=0 borderColorDark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' 
                                    cellPadding=5 width="100%" 
                                    borderColorLight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>' 
                                    border=1>
									<tr>
										<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>">                      
                                            <asp:Label ID="Label1" runat="server" Text="Label" SkinID="Title">考勤时段设置</asp:Label></td>
									</tr>
								</table>
                            </td>
                        </tr>
                        <tr>
							            <td align="right" style="width: 600px">
								            <asp:LinkButton id="LinkButton1" runat="server" OnClick="LinkButton1_Click"><IMG src="images/add.gif" align="absBottom" border="0">新增</asp:LinkButton>
							            </td>
						            </tr>
                        <tr>
                            <td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>">
                                        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" OnRowCommand="GridView1_RowCommand">
                                            <EmptyDataTemplate>
                                                没有数据
                                            </EmptyDataTemplate>
                                            <Columns>
                                                <asp:HyperLinkField HeaderText="编辑" Text="&lt;img src=images/button_edit.gif border=0 alt=修改 /&gt;" DataNavigateUrlFields="AutoID" DataNavigateUrlFormatString="AttendTimeAdd.aspx?AutoID={0}" />
                                                <asp:BoundField HeaderText="时段名称" DataField="AttendTimeName" />
                                                <asp:BoundField HeaderText="每天时段数" DataField="AttendTimeNum" />
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
                                    OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [AttendTime] WHERE ([EnterpriseID] = @EnterpriseID)">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="EnterpriseID" SessionField="EnterpriseID" Type="Int32" />
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

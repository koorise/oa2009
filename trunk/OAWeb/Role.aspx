<%@ Page Language="C#" AutoEventWireup="True" Inherits="OAWeb.Role" Codebehind="Role.aspx.cs" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
	<link href="style.css" type="text/css" rel="stylesheet">
	<script>
	    function Check()
	    {
	        return window.confirm('你确定要删除该记录吗？');
	    }
	</script>	
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
    
    <div style="text-align:center">
		<table id="Table1" cellspacing="0" cellpadding="0"  border="0" style="text-align:center">
			<tr>
				<td>
					<table cellspacing="0" cellpadding="5" width="600" border="0">
						<tr>
							<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>">
								<table cellspacing=0 borderColorDark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' 
                                    cellPadding=5 width="100%" 
                                    borderColorLight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>' 
                                    border=1>
									<tr>
										<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>">                      
                                            <asp:Label ID="Label1" runat="server" Text="Label" SkinID="Title">角色设置</asp:Label></td>
									</tr>
								</table>
							</td>
						</tr>
						<tr>
							<td align="right">
								<asp:LinkButton id="LinkButton1" runat="server" OnClick="LinkButton1_Click"><IMG src="images/add.gif" align="absBottom" border="0">新增</asp:LinkButton>
							</td>
						</tr>						
						<tr>
							<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>">	
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="GridView1" DataKeyNames="AutoID,IsAdminRole,RoleName" runat="server" DataSourceID="SqlDataSource1" OnRowCommand="GridView1_RowCommand">
                                            <EmptyDataTemplate>
                                                没有数据
                                            </EmptyDataTemplate>
                                            <Columns>
                                                <asp:HyperLinkField DataNavigateUrlFields="AutoID" Text="&lt;img src=images/button_edit.gif border=0 alt=修改 /&gt;" DataNavigateUrlFormatString="RoleAdd.aspx?AutoID={0}" HeaderText="编辑" />
                                                <asp:ButtonField CommandName="Sel" HeaderText="权限分配" ButtonType="Image" ImageUrl="images/key.gif" />
                                                <asp:BoundField DataField="RoleName" HeaderText="角色名称" />
                                                <asp:BoundField DataField="IsAdminRole" HeaderText="系统默认角色" />
                                                <asp:TemplateField HeaderText="删除">
                                                     <ItemTemplate>
                               							<SPAN onclick="return window.confirm('你确定要删除该记录吗？')">
                                                            <asp:LinkButton ID="LinkButton1" CommandName="Del" CommandArgument='<%# Eval("AutoID") %>' runat="server" Text="&lt;img src=images/button_del.gif border=0 /&gt;"></asp:LinkButton>
                   										</SPAN>
                                                     </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                        <div class="abc"></div>
                                        <div class="abc1"><div style="color:Red; font-size:13pt;"> 正在读取数据... <img src="images/progress.gif" /></div></div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                    SelectCommand="SELECT AutoID,EnterpriseID,RoleName,Case when isAdminRole=0 then '否' else '是' End as isAdminRole FROM [Role] WHERE ([EnterpriseID] = @EnterpriseID)" 
                                    OldValuesParameterFormatString="original_{0}">
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
	</div>
        </ContentTemplate>
    </asp:UpdatePanel>                                            
		
    </form>
</body>
</html>

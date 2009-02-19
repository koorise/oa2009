<%@ Page Language="C#" AutoEventWireup="True" Inherits="OAWeb.AttendShift" Codebehind="AttendShift.aspx.cs" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
	<LINK href="style.css" type="text/css" rel="stylesheet">	
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
					<table cellspacing="0" cellpadding="5" width="600" border="0">
						<tr>
							<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>">
								<table cellspacing=0 borderColorDark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' 
                                    cellPadding=5 width="100%" 
                                    borderColorLight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>' 
                                    border=1>
									<tr>
										<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>">                      
                                            <asp:Label ID="Label1" runat="server" Text="Label" SkinID="Title">用户排班设置</asp:Label></td>
									</tr>
								</table>
							</td>
						</tr>
						<tr>
							<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>">	
                                        <asp:GridView ID="GridView1" runat="server" DataKeyNames="AutoID,AttendShiftID" DataSourceID="SqlDataSource1" OnRowUpdating="GridView1_RowUpdating" OnRowDataBound="GridView1_RowDataBound">
                                            <EmptyDataTemplate>
                                                没有数据
                                            </EmptyDataTemplate>
                                            <Columns>
                                                <asp:BoundField DataField="UserName" HeaderText="用户姓名" SortExpression="UserName" ReadOnly="True" />
                                                <asp:BoundField DataField="RoleName" HeaderText="角色" ReadOnly="True" />
                                                <asp:TemplateField HeaderText="轮班名称" SortExpression="ShiftName">
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="DDLShiftName" runat="server" DataSourceID="SqlDataSource2" DataTextField="ShiftName" DataValueField="AutoID">
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("ShiftName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:CommandField  ShowEditButton="True" UpdateText="&lt;img src=images/save.gif border=0 alt=保存 /&gt;" CancelText="&lt;img src=images/logout1.gif border=0 alt=取消 /&gt;" EditText="&lt;img src=images/edit.gif border=0 alt=修改 /&gt;" HeaderText="修改">
                                                
                                                </asp:CommandField>                                            
                                             </Columns>
                                        </asp:GridView>
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                        <div class="abc"></div>
                                        <div class="abc1"><div style="color:Red; font-size:13pt;"> 正在读取数据... <img src="images/progress.gif" /></div></div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                                    SelectCommand="SELECT * FROM [UsersV] WHERE (([EnterpriseID] = @EnterpriseID) AND ([IsStop] = @IsStop))"
                                    OldValuesParameterFormatString="original_{0}" DeleteCommand="DELETE FROM [Users] WHERE [AutoID] = @original_AutoID" InsertCommand="INSERT INTO [Users] ([EnterpriseID], [LoginName], [LoginPW], [UserName], [Mobile], [CardAddress], [RoleID], [AttendShiftID], [IsAdminUser], [IsStop]) VALUES (@EnterpriseID, @LoginName, @LoginPW, @UserName, @Mobile, @CardAddress, @RoleID, @AttendShiftID, @IsAdminUser, @IsStop)" 
                                    UpdateCommand="UPDATE [Users] SET [IsStop] = 0 WHERE [AutoID] = @original_AutoID">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="EnterpriseID" SessionField="EnterpriseID" Type="Int32" />
                                        <asp:Parameter DefaultValue="False" Name="IsStop" Type="Boolean" />
                                    </SelectParameters>
                                    <DeleteParameters>
                                        <asp:Parameter Name="original_AutoID" Type="Int32" />
                                    </DeleteParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="original_AutoID" Type="Int32" />
                                    </UpdateParameters>
                                    <InsertParameters>
                                        <asp:Parameter Name="EnterpriseID" Type="Int32" />
                                        <asp:Parameter Name="LoginName" Type="String" />
                                        <asp:Parameter Name="LoginPW" Type="String" />
                                        <asp:Parameter Name="UserName" Type="String" />
                                        <asp:Parameter Name="Mobile" Type="String" />
                                        <asp:Parameter Name="CardAddress" Type="String" />
                                        <asp:Parameter Name="RoleID" Type="Int32" />
                                        <asp:Parameter Name="AttendShiftID" Type="Int32" />
                                        <asp:Parameter Name="IsAdminUser" Type="Boolean" />
                                        <asp:Parameter Name="IsStop" Type="Boolean" />
                                    </InsertParameters>
                                </asp:SqlDataSource>
                                
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                    SelectCommand="SELECT [AutoID], [ShiftName] FROM [AttendShift] WHERE ([EnterpriseID] = @EnterpriseID)">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="EnterpriseID" SessionField="EnterpriseID" Type="Int32" />
                                    </SelectParameters>
                                    <DeleteParameters>
                                        <asp:Parameter Name="AutoID" Type="Int32" />
                                    </DeleteParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="ShiftName" Type="String" />
                                        <asp:Parameter Name="AutoID" Type="Int32" />
                                    </UpdateParameters>
                                    <InsertParameters>
                                        <asp:Parameter Name="ShiftName" Type="String" />
                                    </InsertParameters>
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

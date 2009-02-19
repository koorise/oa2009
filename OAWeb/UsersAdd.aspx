<%@ Page Language="C#" AutoEventWireup="True" Inherits="OAWeb.UsersAdd" Codebehind="UsersAdd.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
	<LINK href="style.css" type="text/css" rel="stylesheet">
	<script language="javascript" src="js/Public.js"></script>
	<script>
	function Add()
	{
		if(vdf('form1.txtLoginName','请先输入用户登陆名称','r')==false)
			return false;
		if(vdf('form1.txtLoginPW','请先输入用户登陆密码','r')==false)
			return false;
		if(vdf('form1.txtUserName','请先输入用户姓名','r')==false)
			return false;
	    if(GetStrLen(document.getElementById('txtUserName').value)>20)
	    {
	        alert('输入的用户姓名长度不能大于20个字符!');
	        document.getElementById('txtUserName').focus();
	        return false;
	    }					
	}
	</script>
</head>
<body>
    <form id="form1" runat="server" onkeydown="keydown()">
    <div style="text-align:center;">
 			<table id="Table1" cellspacing="0" cellpadding="0" width="500" border="0">
				<tr>
					<td>
						<table cellspacing="0" cellpadding="5" width="100%" border="0">
							<tr>
								<td bgColor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>'>
									<table cellspacing=0 bordercolorDark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' 
										cellpadding="5" width="100%" 
										bordercolorLight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>' 
										border=1>
										<tr>
											<td style="text-align:center; background-color:<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>"  
											colspan="2"><asp:Label ID="Label1" runat="server" Text="Label" SkinID="Title"><%=ViewState["sTitle"].ToString()%>用户资料</asp:Label>
											</td>
										</tr>
										<TR>
											<td>
                                                登陆名&nbsp;</td>
											<td>
												<asp:TextBox id="txtLoginName" runat="server" MaxLength="10"></asp:TextBox>
											</td>
										</TR>
										<tr>
											<td>
                                                登陆密码</td>
											<td>
												<asp:TextBox id="txtLoginPW" runat="server" MaxLength="20" TextMode="Password" Width="147px"></asp:TextBox>
											</td>
										</tr>
                                        <tr>
                                            <td>
                                                用户姓名</td>
                                            <td>
                                                <asp:TextBox ID="txtUserName" runat="server" MaxLength="20"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                手机号码</td>
                                            <td>
                                                <asp:TextBox ID="txtMobile" runat="server" MaxLength="20"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                轮班名称</td>
                                            <td>
                                                <asp:DropDownList ID="DDLShiftName" runat="server" Width="155">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                所属角色</td>
                                            <td>
                                                <asp:DropDownList ID="DDLRole" runat="server" Width="155">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <%if(ViewState["sTitle"].ToString()=="修改"){ %>
                                        <tr>
                                            <td>
                                                是否停用</td>
                                            <td>
                                                <asp:DropDownList ID="DDLIsStop" runat="server" Width="155">
                                                    <asp:ListItem Value="0">否</asp:ListItem>
                                                    <asp:ListItem Value="1">是</asp:ListItem>
                                                </asp:DropDownList></td>
                                        </tr>
                                        <%} %>

										<tr>
											<td colspan="2" align="center">
												<asp:Button id="Button1" runat="server" Text="添 加" OnClick="Button1_Click"></asp:Button>
												&nbsp;&nbsp;
												<asp:Button id="Button2" runat="server" Text="返 回" OnClick="Button2_Click"></asp:Button>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>   
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="True" Inherits="OAWeb.RoleAdd" Codebehind="RoleAdd.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>�ޱ���ҳ</title>
	<LINK href="style.css" type="text/css" rel="stylesheet">
	<script language="javascript" src="js/Public.js"></script>
	<script>
	function Add()
	{
		if(vdf('form1.RoleName','���������ɫ����','r')==false)
			return false;
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
											colspan="2"><asp:Label ID="Label1" runat="server" Text="Label" SkinID="Title"><%=ViewState["sTitle"].ToString()%>��ɫ����</asp:Label>
											</td>
										</tr>
										<tr>
											<td>
												��ɫ����
											</td>
											<td>
												<asp:TextBox id="RoleName" runat="server" MaxLength="20"></asp:TextBox>
											</td>
										</tr>

										<tr>
											<td colspan="2" align="center">
												<asp:Button id="Button1" runat="server" Text="�� ��" OnClick="Button1_Click"></asp:Button>
												&nbsp;&nbsp;
												<asp:Button id="Button2" runat="server" Text="�� ��" OnClick="Button2_Click"></asp:Button>
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

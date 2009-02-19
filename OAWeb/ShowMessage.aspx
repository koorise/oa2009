<%@ Page Language="C#" AutoEventWireup="True" Inherits="OAWeb.ShowMessage" Codebehind="ShowMessage.aspx.cs" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
			<br>
			<table cellSpacing="0" cellPadding="5" width="600" align="center" border="0">
				<tr>
					<td bgColor='#F5F9FF'>
						<table cellSpacing=0 
      borderColorDark='#D3D8E0' 
      cellPadding=5 width="100%" 
      borderColorLight='#4F7FC9' 
      border=1>
							<tr bgColor="#e4e4e4">
								<td align=center 
          bgColor='#E3EFFF' 
          height=22><STRONG>【提示】</STRONG></td>
							</tr>
							<tr>
								<td align="center" height="22">
									<table cellSpacing="10" cellPadding="0" border="0">
										<tr>
											<td align="center" height="50">
												<asp:Label id="Label1" runat="server" ForeColor="red" Font-Size="20pt" Font-Names="隶书"></asp:Label>&nbsp;
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<TD align="center">&nbsp;
								    
									<asp:Button id="Button1" runat="server" Text="返 回" OnClick="Button1_Click"></asp:Button>
								</TD>
							</tr>
						</table>
					</td>
				</tr>
			</table>
    </form>
</body>
</html>

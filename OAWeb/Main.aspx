<%@ Page Language="C#" AutoEventWireup="True" Inherits="OAWeb.Main" Codebehind="Main.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
	<LINK href="style.css" type="text/css" rel="stylesheet">
</head>
<body background='<%=Application[Session["Style"].ToString()+"xdesktop_bj"]%>' MS_POSITIONING="FlowLayout">
	<form id="Form1" method="post" runat="server">
		<FONT face="宋体"></FONT><FONT face="宋体"></FONT>
		<br>
		<table style="width:638;height:380;" cellSpacing="0" cellPadding="0" align="center" border="0">
			<tr>
				<td style="PADDING-LEFT: 60px; PADDING-TOP: 20px" vAlign=top width=574 
background='<%=Application[Session["Style"].ToString()+"xdesktop_bgimage"]%>' 
height=380>
					<table cellSpacing="0" cellPadding="0" width="95%" border="0">
						<tr>
							<td></td>
						</tr>
						<tr>
							<td height="36"></td>
						</tr>
						<tr>
							<td align="center"></td>
						</tr>
						<tr>
							<td align="right" height="36"></td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
    </form>
</body>
</html>

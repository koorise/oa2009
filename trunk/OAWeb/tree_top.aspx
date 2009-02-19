<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tree_top.aspx.cs" Inherits="OAWeb.tree_top" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div style=" text-align:center">
    <br />
    <br />
    <br />
   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
					<table cellspacing="0" cellpadding="5" width="500" border="0" style="height: 93px">
						<tr>
							<td valign="top" align="center" style="background-color:<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>; height: 89px;">
								<table cellspacing=0 borderColorDark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' 
                                    cellPadding=5 width="100%" 
                                    borderColorLight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>' 
                                    border=1>
									<tr>
										<td  align="center" style="background-color:<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>">                      
                                            <asp:Label ID="Label1" runat="server" Text="Label" SkinID="Title">用户部门设置——请先选择需要设置的学校</asp:Label></td>
									</tr>

									<tr>
										<td align="center" >
                                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="下一步" /></td>
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

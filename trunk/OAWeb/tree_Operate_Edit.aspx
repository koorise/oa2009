<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tree_Operate_Edit.aspx.cs" Inherits="OAWeb.tree_Operate_Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="admin_Tree" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
					<TR>
						<TD vAlign="top" align="left" width="82%" height="67"><br>
							<table cellSpacing="0" cellPadding="0" width="95%" align="center" border="0">
								<tr>
									<td width="146">
										<table cellSpacing="0" cellPadding="0" width="100%" border="0">
											<tr>
												<td class="jnfont6" vAlign="center" noWrap>
													<div align="left"><IMG height="20" src="images/imgbtn/page_icon.gif" width="23"><font color="#000000" size="3"><b>&nbsp;部门维护</b></font></div>
												</td>
											</tr>
										</table>
									</td>
									<td width="609">
										<table id="Table2" cellSpacing="0" cellPadding="0" align="right" border="0">
											<tr>
												<td align="middle" width="120">
													<div align="center">&nbsp;</div>
												</td>
												<td align="middle" width="1">
													<div align="center">&nbsp;</div>
												</td>
												<td align="middle" width="120">
													<div align="center">&nbsp;</div>
												</td>
												<td align="middle" width="110">
													<div align="center">&nbsp;</div>
												</td>
												<td align="middle" width="110">
													<div align="right">
														<asp:ImageButton id="imgbtn_Return" runat="server" ImageUrl="images/link_Exit.gif" OnClick="imgbtn_Return_Click"></asp:ImageButton></div>
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td background="images/hline.gif" colSpan="2" height="1"></td>
								</tr>
							</table>
							<br>
							<table id="Table3" cellspacing="0" bordercolordark="#ffffff" cellpadding="1" width="95%" align="center" bgcolor="#ffffff" bordercolorlight="#3677b1" border="1">
								<tr valign="center" align="middle">
									<th valign="center" align="middle" bgcolor="#ffdcb5" colspan="8" height="25">
										<table id="Table29" height="100%" cellspacing="0" cellpadding="0" width="100%" border="0">
											<tr>
												<td>
													
                    <div align="left"><font class="table_head_font" color="#ffffff">&nbsp;&nbsp;修 
                      改&nbsp;部 门 名 称&nbsp;</font></div>
												</td>
											</tr>
										</table>
									</th>
								</tr>
								<tr valign="center" align="middle">
									<td valign="center" align="middle" width="106" height="0">
										<table id="Table30" height="100%" cellspacing="0" cellpadding="0" width="100%" border="0">
											<tr>
												<td class="font_dropshadow" valign="center">&nbsp;&nbsp; 部门名称</td>
											</tr>
										</table>
									</td>
									<td valign="center" align="middle" colspan="7" height="11">
										<table id="Table4" height="100%" cellspacing="0" cellpadding="0" width="100%" border="0">
											<tr>
												<td class="font_dropshadow" valign="center">&nbsp;&nbsp;
													<asp:TextBox id="txt_Node_Name" runat="server" Width="250px" ForeColor="ControlDark" BorderStyle="Groove" Height="21px"></asp:TextBox></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td valign="center" align="middle" colspan="8" height="22">
										<table id="Table22" height="100%" cellspacing="0" cellpadding="0" width="100%" border="0">
											<tr>
												<td class="font_dropshadow" valign="center" height="32">
													<div align="center">
														<asp:ImageButton id="imgbtn_Add" runat="server" ImageUrl="images/imgbtn/imgbtn_Sure.jpg" OnClick="imgbtn_Add_Click" ></asp:ImageButton></div>
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
							<br>
							<font size="2"></font>
						</TD>
					</TR>
				</TABLE>
			</FONT>
			<asp:label id="lbl_Curnodeid" EnableViewState="True" Visible="False" Runat="server"></asp:label><asp:label id="lbl_Error" EnableViewState="False" Visible="True" Runat="server"></asp:label></form>
	</body>
</html>

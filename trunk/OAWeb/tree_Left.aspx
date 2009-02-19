<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tree_Left.aspx.cs" Inherits="OAWeb.tree_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
	<link rel="stylesheet" href="css/blue.css" type="text/css">
</head>
<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="default1" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
					<TR>
						<TD vAlign="top" align="left" width="82%" ><br>
							<table cellSpacing="0" cellPadding="0" width="95%" align="center" border="0">
								<tr>
									<td style="height: 26px">
										<table cellSpacing="0" cellPadding="0" width="100%" border="0">
											<tr>
												<td class="jnfont6" vAlign="center" noWrap height="31">
													<div align="left">
														<table width="180" border="0" cellspacing="0" cellpadding="0" bgcolor="#f4f4f4" height="35" align="left">
															<tr>
																<td background="images/tree_dh.gif">
																	<table id="Table28" cellspacing="0" cellpadding="0" width="100%" border="0">
																		<tr>
																			<td valign="bottom"><font size="2"><b> </b></font><font color="#000000" size="3"><b><font color="#330000">
																							<font size="4">&nbsp;&nbsp;&nbsp;&nbsp;部门信息</font></font></b></font>
																			</td>
																		</tr>
																	</table>
																</td>
															</tr>
														</table>
													</div>
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td height="1">
                                        <asp:TreeView ID="TreeView1" runat="server"  OnTreeNodeCheckChanged="TreeView1_TreeNodeCheckChanged" ShowLines="True">
                                        </asp:TreeView>
                                    </td>
								</tr>
							</table>
							<br>
							<font size="2">
								<table id="Table7" cellSpacing="0" cellPadding="0" width="95%" align="center" border="0">
									<tr>
										<td><font face="宋体" color="#8a5e00"><font face="宋体" size="2"><font color="#8a5e00">&nbsp;</font></font></font></td>
									</tr>
									<tr>
										<td>&nbsp;</td>
									</tr>
								</table>
							</font>
						</TD>
					</TR>
				</TABLE>
			</FONT>
			<asp:label id="lbl_Curnodeid" Visible="False" EnableViewState="True" Runat="server"></asp:label>
			<asp:Label ID="lbl_Error" Runat="server" EnableViewState="False" Visible="True"></asp:Label></form>
	</body>
</html>

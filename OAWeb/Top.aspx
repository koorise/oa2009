<%@ Page Language="C#" AutoEventWireup="True" Inherits="OAWeb.Top" Codebehind="OAWeb.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>�ޱ���ҳ</title>
	<LINK href="style.css" type="text/css" rel="stylesheet">
	<style>
        a { color: #000000; text-decoration: none}
	</style>	
</head>
<body MS_POSITIONING="FlowLayout" text="#000000" leftmargin="0" topmargin="0" marginwidth="0"
	marginheight="0">
    <form id="form1" runat="server">
		<table width="100%" height="102" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td background='<%=Application[Session["Style"].ToString()+"xtopbj_bgimage"]%>'>
					<table width="778" height="102" border="0" cellpadding="0" cellspacing="0">
						<tr>
							<td colspan="3"><img src='<%=Application[Session["Style"].ToString()+"xtop1_bgimage"]%>' width="778" height="71"></td>
						</tr>
						<tr>
							<td width="217" background='<%=Application[Session["Style"].ToString()+"xtop2_bgimage"]%>'><table width="100%" height="31" border="0" cellpadding="0" cellspacing="0">
									<tr>
										<td height="3" colspan="2"></td>
									</tr>
									<tr>
										<td width="30"><div align="center"><img src="images/bar_00.gif" width="16" height="16"></div>
										</td>
										<td>
											����ǰ�û���
											<asp:Label id="lblSignIn" runat="server"></asp:Label>��</td>
									</tr>
								</table>
							</td>
							<td width="486" background='<%=Application[Session["Style"].ToString()+"xtop3_bgimage"]%>'><table width="100%" height="31" border="0" cellpadding="0" cellspacing="0">
									<tr>
										<td width="9%">&nbsp;</td>
										<td>
											<table height="31" border="0" cellpadding="0" cellspacing="0">
												<tr>
													<td rowspan="2"><img src='<%=Application[Session["Style"].ToString()+"xtop4_bgimage"]%>' width="39" height="31"></td>
													<td height="8"><FONT face="����"></FONT></td>
												</tr>
												<tr>
													<td><a href="Main.aspx" target="mainFrame">��ҳ</a></td>
												</tr>
											</table>
										</td>
										<td>
											<table height="31" border="0" cellpadding="0" cellspacing="0">
												<tr>
													<td rowspan="2"><img src='<%=Application[Session["Style"].ToString()+"xtop4_bgimage"]%>' width="39" height="31"></td>
													<td height="8"></td>
												</tr>
												<tr>
													<td><a href="#" onclick="javascript:parent.mainFrame.focus();parent.mainFrame.print();">��ӡ</a></td>
												</tr>
											</table>
										</td>
										<td>
											<table height="31" border="0" cellpadding="0" cellspacing="0">
												<tr>
													<td rowspan="2"><img src='<%=Application[Session["Style"].ToString()+"xtop4_bgimage"]%>' width="39" height="31"></td>
													<td height="8"></td>
												</tr>
												<tr>
													<td><a href="javascript:history.go(-1)">����</a></td>
												</tr>
											</table>
										</td>
										<td>
											<table height="31" border="0" cellpadding="0" cellspacing="0">
												<tr>
													<td rowspan="2"><img src='<%=Application[Session["Style"].ToString()+"xtop4_bgimage"]%>' width="39" height="31"></td>
													<td height="8"></td>
												</tr>
												<tr>
													<td><a href="javascript:history.go(1)">ǰ��</a></td>
												</tr>
											</table>
										</td>
										<td>
											<table height="31" border="0" cellpadding="0" cellspacing="0">
												<tr>
													<td rowspan="2"><img src='<%=Application[Session["Style"].ToString()+"xtop4_bgimage"]%>' width="39" height="31"></td>
													<td height="8"></td>
												</tr>
												<tr>
													<td><a href="Relogin.aspx" target="_top" onClick="if (!window.confirm('��ȷ��Ҫע����ǰ��¼�û���')){return false;}">ע��</a></td>
												</tr>
											</table>
										</td>
										<td>
											<table height="31" border="0" cellpadding="0" cellspacing="0">
												<tr>
													<td rowspan="2"><img src='<%=Application[Session["Style"].ToString()+"xtop4_bgimage"]%>' width="39" height="31"></td>
													<td height="8"></td>
												</tr>
												<tr>
													<td><a href="Logout.aspx" target="_top">�˳�</a></td>
												</tr>
											</table>
										</td>
										<td>
											<table height="31" border="0" cellpadding="0" cellspacing="0">
												<tr>
													<td width="39" rowspan="2"><img src='<%=Application[Session["Style"].ToString()+"xtop4_bgimage"]%>' width="39" height="31"></td>
													<td height="8"></td>
												</tr>
												<tr>
													<td><img src="images/bar_07.gif" width="16" height="16" onClick="if(parent.topset.rows!='22,*'){parent.topset.rows='22,*';window.scroll(0,93)}else{parent.topset.rows='93,*'};"
															style="CURSOR: hand" title="������������������"></td>
												</tr>
											</table>
										</td>
									</tr>
								</table>
							</td>
							<td width="75"><img src='<%=Application[Session["Style"].ToString()+"xtop5_bgimage"]%>' width="75" height="31"></td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
    </form>
</body>
</html>

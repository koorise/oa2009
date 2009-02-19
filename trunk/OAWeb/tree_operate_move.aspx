<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tree_operate_move.aspx.cs" Inherits="OAWeb.tree_operate_move" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body MS_POSITIONING="GridLayout">
		<form id="tree_operate_move" method="post" runat="server">
			<table cellspacing="0" bordercolordark="#ffffff" bordercolorlight="#3677b1" bgcolor="#ffffff" cellpadding="1" width="95%" border="1" align="center">
				<asp:repeater id="rpt_Graduate" runat="server">
					<headertemplate>
						<tr bgcolor="#ffdcb5">
							<th height="26" width="36">
								<table width="100%" border="0" cellspacing="0" cellpadding="0" height="100%">
									<tr>
										<td>
											<div align="center"></div>
										</td>
									</tr>
								</table>
							</th>
							<%if (Session["limit_code"]!=null){if (Session["limit_code"].ToString().IndexOf('H')!=-1 || Session["limit_code"].ToString().IndexOf('A')!=-1){%>
							<%}}%>
							<th height="26" width="504">
								<table width="100%" border="0" cellspacing="0" cellpadding="0" height="100%">
									<tr>
										<td>
											<div align="center"><font color="#FFFFFF">子 节 点</font></div>
										</td>
									</tr>
								</table>
							</th>
							<th height="26" width="67">
								<table width="100%" border="0" cellspacing="0" cellpadding="0" height="100%">
									<tr>
										<td>
											<div align="center"><font color="#FFFFFF">上移</font></div>
										</td>
									</tr>
								</table>
							</th>
							<th height="26" width="59">
								<table width="100%" border="0" cellspacing="0" cellpadding="0" height="100%">
									<tr>
										<td>
											<div align="center"><font color="#FFFFFF">下移</font></div>
										</td>
									</tr>
								</table>
							</th>
							<th height="26" width="61">
								<table width="100%" border="0" cellspacing="0" cellpadding="0" height="100%">
									<tr>
										<td>
											<div align="center"><font color="#FFFFFF" class="table_head_font">修改</font></div>
										</td>
									</tr>
								</table>
							</th>
						</tr>
					</headertemplate>
					<itemtemplate>
						<tr>
							<td height="24" width="36" align="center">
								<table width="100%" border="0" cellspacing="0" cellpadding="0" height="100%">
									<tr>
										<td>
											<div align="center">
												<%# Container.ItemIndex+1%>
												<asp:Label ID="lbl_Order_Id" Visible=False Text='<%# DataBinder.Eval(Container.DataItem,"order_id").ToString() %>' Runat=server/>
												<asp:Label ID="lbl_NodeId" Visible=False Text='<%# DataBinder.Eval(Container.DataItem,"autoid").ToString() %>' Runat=server/>
											</div>
										</td>
									</tr>
								</table>
							</td>
							<td height="24" width="504" align="center">
								<table width="100%" border="0" cellspacing="0" cellpadding="0" height="100%">
									<tr>
										<td class="font_dropshadow">
											<div align="center">
												<%# DataBinder.Eval(Container.DataItem,"depart").ToString() %>
											</div>
										</td>
									</tr>
								</table>
							</td>
							<td height="24" align="center" width="67">&nbsp;
							</td>
							<td height="24" align="center" width="59">&nbsp;
							</td>
							<td height="24" width="61">
								<table width="100%" border="0" cellspacing="0" cellpadding="0" height="100%">
									<tr>
										<td class="font_dropshadow">
											<div align="center">
												<asp:HyperLink Text='修改' NavigateUrl='<%# "tree_Operate_edit.aspx?location="+Request["location"].ToString()+"&nodeid="+DataBinder.Eval(Container.DataItem,"autoid").ToString() %>' runat="server" ID="Hyperlink7"/>
											</div>
										</td>
									</tr>
								</table>
							</td>
						</tr>
					</itemtemplate>
				</asp:repeater>
			</table>
			<asp:label id="lbl_Error" EnableViewState="False" Visible="True" Runat="server"></asp:label>
		</form>
	</body>
</html>

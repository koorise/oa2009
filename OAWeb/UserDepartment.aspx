<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDepartment.aspx.cs" Inherits="OAWeb.UserDepartment" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
<LINK href="style.css" type="text/css" rel="stylesheet">
	<script language="jscript">
	function MoveName()
	{
		if(form1.ListBox1.value=="")
			return;
		var coll = document.all.ListBox1.options;
		//添加
		if (coll.length>0) {
			for (i=0; i< coll.length; i++)
				if(coll[i].selected){
					form1.ListBox2.options.add(new Option(coll[i].text,coll[i].value));
				}
			}
		//删除
		i=0;
		if (coll.length>0) {
			while(i< coll.length){
				if(coll[i].selected)
					form1.ListBox1.remove(i);
				else
					i++;
			}
		}


	
	}
	function MoveNameBack()
	{
		if(form1.ListBox2.value=="")
			return;
		var coll = document.all.ListBox2.options;
		//添加
		if (coll.length>0) {
			for (i=0; i< coll.length; i++)
				if(coll[i].selected){
					form1.ListBox1.options.add(new Option(coll[i].text,coll[i].value));
				}
			}
		//删除
		i=0;
		if (coll.length>0) {
			while(i< coll.length){
				if(coll[i].selected)
					form1.ListBox2.remove(i);
				else
					i++;
			}
		}			
	}
	
	function Check(){
//		if(form1.ListBox2.length==0){  
//			alert('请先选择');
//			return false;
//		}
		var coll = document.all.ListBox2.options;
		form1.UserIDStr.value = "";
		//把选择的部门存为格式：DepartmentID,DepartmentID,DepartmentID.....
		for (i=0; i< coll.length; i++){
			str=coll[i].value;
			var v=str.split('#');
			form1.UserIDStr.value = form1.UserIDStr.value+v[0]
			if(i<coll.length-1)
				form1.UserIDStr.value = form1.UserIDStr.value+',';
		}
	}
	
	</script>    
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center;">
		<table id="Table1" cellspacing="0" cellpadding="0"  border="0" style="text-align:center">
			<tr>
				<td>
					<table cellspacing="0" cellpadding="5" width="600" border="0">
						<tr>
							<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>">
								<table cellspacing="0" borderColorDark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' 
                                    cellPadding="5" width="100%" 
                                    borderColorLight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>' 
                                    border="1">											
                                    <tr>
												<td align=center bgColor='<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>' 
												height=25 colspan=3><asp:Label ID="Label1" runat="server" Text="安排用户所属部门" SkinID="Title"></asp:Label>
												</td>
											</tr>
											<tr>
												<td align="center">
                                                    用户姓名<asp:TextBox ID="TextBox1" runat="server" Width="75px"></asp:TextBox>
                                                    <asp:Button ID="BtnFind" runat="server" Text="查找" OnClick="BtnFind_Click" /></td>
												<td style="WIDTH: 66px">&nbsp;</td>
												<td align="center">
                                                    安排进入的部门<asp:DropDownList ID="DropDownList2" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                                    </asp:DropDownList></td>
											</tr>
											<tr>
												<td>
                                                    <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource1" DataTextField="UserName" SelectionMode="Multiple"
                                                        DataValueField="AutoID" Height="231px" Width="188px"></asp:ListBox>
                                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                                                            SelectCommand="SELECT * FROM Users WHERE ([EnterpriseID] = @EnterpriseID) and AutoID not in(select UserID from UserDepartment where ([DepartmentID] = @DepartmentID))">
                                                            <SelectParameters>
                                                                <asp:SessionParameter Name="EnterpriseID" SessionField="EnterpriseID" Type="Int32" />
                                                                <asp:ControlParameter ControlID="DropDownList2" DefaultValue="0" Name="DepartmentID" PropertyName="SelectedValue"
                                                                    Type="Int32" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>

												</td>
												<td style="WIDTH: 66px">
													<p align="center"><input style="WIDTH: 48px; HEIGHT: 24px" type="button" value=">>" onclick="MoveName()"></p>
													<p align="center"><input style="WIDTH: 48px; HEIGHT: 24px" onclick="MoveNameBack()" type="button" value="<<"></p>
                                                    <p align="center">
														&nbsp;</p>
												</td>
												<td>
                                                    <asp:ListBox ID="ListBox2" runat="server" DataSourceID="SqlDataSource2" DataTextField="UserName" SelectionMode="Multiple"
                                                        DataValueField="AutoID" Height="231px" Width="188px"></asp:ListBox>
                                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server"
                                                            SelectCommand="SELECT * FROM UserDepartmentV WHERE ([DepartmentID] = @DepartmentID)">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="DropDownList2" DefaultValue="0" Name="DepartmentID" PropertyName="SelectedValue"
                                                                    Type="Int32" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
												</td>
											</tr>
											<tr>
												<td colspan="3" align="center" style="height: 4px">
													&nbsp;<span onclick="return Check()">
														<asp:Button id="Button2" runat="server" Text="保  存" OnClick="Button2_Click"></asp:Button></span></td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
		</td></tr></table>    
							<br/>
							<input id="UserIDStr" runat="server" type="hidden" />
    </div>
    </form>
</body>
</html>

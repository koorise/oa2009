<%@ Page Language="C#" AutoEventWireup="True" Inherits="OAWeb.index" Codebehind="index.aspx.cs" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>中国移动校信通</title>
		<script language="JavaScript" type="text/JavaScript">
            function CheckLogin(){
	            if(form1.LoginName.value=="")
	            {
		            alert('请先输入登陆名!');
		            form1.LoginName.focus();
		            return;
	            }
	            form1.submit();
            }
            function keydown(){
	            if(event.keyCode==13)
	            {
		            event.keyCode=9;
		            if(event.srcElement.name=="LoginPW")
		            {
			            if(form1.LoginName.value=="")
			            {
				            alert('请先输入登陆名!');
				            form1.LoginName.focus();
				            return;
			            }
			            form1.isSubmit.value="1";
			            form1.submit();
		            }
	            }
            		
            	
            }
		</script>    
		
</head>
<body  onkeydown="keydown()">
    <form id="form1" runat="server">
        &nbsp;
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
		    <table style="height:80%; width:100%; text-align:center">
			    <tr>
				    <td>
					    <table id="d1" style="height:357; width:727;" background="img/Agent.jpg">
						    <tr>
							    <td height="80">&nbsp;
							    </td>
							    <td>&nbsp;
							    </td>
							    <td>&nbsp;
							    </td>
							    <td>&nbsp;
							    </td>
						    </tr>
						    <tr>
							    <td width="300">&nbsp;&nbsp;&nbsp;
							    </td>
							    <td>
							    </td>
							    <td>&nbsp;
							    </td>
							    <td>&nbsp;
							    <table>
							        <tr>
							            <td>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
								            <table id="d2" align="left">
									            <tr>
										            <td colspan="2" align="center">
										            </td>
									            </tr>
									            <tr>
										            <td align="right">
											            <asp:Label id="Label1" runat="server">登&nbsp;陆&nbsp;名：</asp:Label></td>
										            <td width="161"><asp:textbox id="LoginName" runat="server" Width="109px" MaxLength="50" Columns="16"></asp:textbox><font face="" color="red">(*)</font>
										            </td>
									            </tr>
									            <tr height="20">
										            <td align="right">密&nbsp;&nbsp;&nbsp;&nbsp;码：</td>
										            <td><asp:textbox id="LoginPW" runat="server" Width="110px" MaxLength="50" Columns="16" TextMode="Password"></asp:textbox><font face="" color="red"></font></td>
									            </tr>
								            </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>	
                                        </td>
								    </tr>
								    <tr>
									    <td colspan="2" align="center"><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="登 陆" />
									    </td>
								    </tr>
								    <tr>
									    <td colspan="2">
									    &nbsp;<asp:label id="lbl_message" runat="server" ForeColor="Red"></asp:label>
									    </td>
								    </tr>
								    <tr>
									    <td colspan="2">
									    &nbsp;
									    </td>
								    </tr>
							    </table>

							    </td>
						    </tr>
					    </table>
				    </td>
			    </tr>
		    </table>
 		<asp:textbox id="isSubmit" Width="0" Runat="server"></asp:textbox>
   </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="True" Inherits="OAWeb.FJUpload" Codebehind="FJUpload.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <base target="_self">
	<link href="style.css" type="text/css" rel="stylesheet" />
	<script>
		function Check()
		{
		    if(form1.myFile.value=='')
		    {
			    alert('请先选择文件！');
			    form1.myFile.focus();
			    return false;
		    }		
		}	
	</script>    
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<table id="Table1" cellspacing="0" cellpadding="0"  border="0" style="text-align:center">
			<tr>
				<td>
					<table cellspacing="0" cellpadding="5" width="500" border="0">
						<tr>
							<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>">
								<table cellspacing="0" bordercolordark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' 
                                    cellpadding="5" width="100%" 
                                    bordercolorlight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>' 
                                    border="1">
									<tr>
										<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>">                      
                                            <asp:Label ID="Label1" runat="server" Text="Label" SkinID="Title">上传附件</asp:Label></td>
									</tr>
									<tr>
										<td align="center">
					                        文件路径 <input type="file" id="myFile" NAME="myFile" size="35" runat="server">
					                        &nbsp;&nbsp;
				                            <asp:Button id="Button1" runat="server" Text="上  传" OnClick="Button1_Click" SkinID="ww"></asp:Button> 
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

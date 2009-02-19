<%@ Page Language="C#" AutoEventWireup="True" Inherits="OAWeb.SendNotice_S" Codebehind="SendNotice_S.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
	<LINK href="style.css" type="text/css" rel="stylesheet">
    <META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=gb2312">
	<script>
        function openUrl(src) 
        { 
            var strUrl=escape(src); 
            window.open(strUrl); 
        } 
          

        function change_url(src) 
        { 
            document.location.href=escape(src); 
        } 	
	    function DownLoad(SaveFileName,UploadFileName)
	    {
	        window.open("FileDownLoad.aspx?s="+escape(SaveFileName)+"&u="+escape(UploadFileName));
	        //openUrl("FileDownLoad.aspx?s="+SaveFileName+"&u="+UploadFileName);
	    }
	</script>
</head>
<body style="width:760px">
    <form id="form1" runat="server">
    <div style="text-align:center">
		<table id="Table1" cellspacing="0" cellpadding="0"  border="0" style="text-align:center">
			<tr>
				<td>
					<table cellspacing="0" cellpadding="5" width="700" border="0">
						<tr>
							<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>">
								<table cellspacing="0" bordercolordark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' 
                                    cellpadding="5" width="100%" 
                                    bordercolorlight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>' 
                                    border="1">
									<tr>
										<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>">                      
                                            <asp:Label ID="Label1" runat="server" Text="Label" SkinID="Title" Font-Size="Large">通知</asp:Label></td>
									</tr>
									<tr>
										<td>
								            &nbsp;&nbsp;<strong>发送人:</strong>&nbsp;
								            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
								             &nbsp;&nbsp;
								            <strong>发送时间:</strong>&nbsp;
								            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                        </td>
									</tr>
								</table>
							</td>
						</tr>
						<tr>
						    <td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>">
	                            <table width="100%" height="300">
		                            <tr>
			                            <td align="left" valign="top">
		                                    <table>
		                                        <tr>
		                                            <td valign="top">
                        			                           
                                                            <asp:Label ID="Label5" runat="server" Text="附件:" Font-Bold="true"></asp:Label>
                                                    </td>
                                                    <td align="left">										            
                                                        <asp:DataList ID="DataList1" DataSourceID="SqlDataSource1" runat="server">
                                                            <ItemTemplate> 
                                                                <a href="javascript:DownLoad('<%# DataBinder.Eval(Container.DataItem,"SaveFileName").ToString() %>','<%# DataBinder.Eval(Container.DataItem,"UploadFileName").ToString() %>')"><%# DataBinder.Eval(Container.DataItem,"UploadFileName") %></a>
                                                            </ItemTemplate>                                             
                                                        </asp:DataList>
                                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                                        SelectCommand="select * from SendNotice_FJ where SendNoticeID=@SendNoticeID">
                                                            <SelectParameters>
                                                                <asp:QueryStringParameter Name="SendNoticeID" QueryStringField="AutoID" Type="int32" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>

                                                    </td>
                                                </tr>
                                            </table>
	                                        <table cellspacing="0" cellpadding="5"  border="0" style="height:280px;" class="TabelNode">
		                                        <tr>
			                                        <td valign="top">
				                                        <table cellspacing="0" cellpadding="5" width="700" border="0">
					                                        <tr>
						                                        <td>
                                                                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
						                                        </td>
					                                        </tr>
				                                        </table>
			                                        </td>
		                                        </tr>
	                                        </table> 	            				    
                                        </td>
		                            </tr>
	                            </table>	
						    </td>
						</tr>
					</table>
				</td>
			</tr>
		</table> 
        <asp:Button ID="Button1" runat="server" Text="返   回" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>

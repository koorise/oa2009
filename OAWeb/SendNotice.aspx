<%@ Page Language="C#" AutoEventWireup="true" Inherits="OAWeb.SendNotice" ValidateRequest="false" Codebehind="SendNotice.aspx.cs" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=gb2312">
	<link href="style.css" type="text/css" rel="stylesheet" />
	<script language="javascript" src="js/Public.js"></script>
	<script>
	    function AddMan()
	    {
			//window.open('SendNoticeAdd.aspx');
			window.showModelessDialog('SendNoticeAdd.aspx',window,'dialogHeight:410px;dialogWidth:610px;help:no;status:no;scroll=no');
	    }
		function FJUpload()
		{
			//window.open('FJUpload.aspx');
			window.showModelessDialog('FJUpload.aspx',window,'dialogHeight:120px;dialogWidth:510px;help:no;status:no;scroll=no');
		}	
		function UploadBind(SubmitType)
		{
		    document.getElementById('SubmitType').value=SubmitType;
			document.getElementById('isSubmit').click();
		}		
		function Check()
		{
			if(document.all.DropDownList1.length==0)
			{  
				alert('请先添加接收通知的用户');
				return false;
			}				
			if(form1.RadioButton1.checked==false&&form1.RadioButton2.checked==false)
			{
			    alert('请先选择通知的类别')
			    return false;
			}
		    if(vdf('form1.TxtTitle','请先输入标题','r')==false)
			    return false;
//		    if(vdf('form1.FCKeditor1','请先输入通知的内容','r')==false)
//			    return false;		
    		if(window.confirm('你确定要发送吗？')==false)
    		    return false;
    		form1.isSend.value="1";
		}		
		function WindowClose()
		{
		    if(form1.isSend.value=="")
			    document.getElementById('DelSendNotice').click();
		}
		window.onunload=WindowClose;
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="text-align:center">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
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
                                            <asp:Label ID="Label1" runat="server" Text="Label" SkinID="Title">发送通知</asp:Label></td>
									</tr>
									<tr>
										<td align="left">
								            &nbsp;&nbsp;接收人&nbsp;
								            <asp:DropDownList ID="DropDownList1" runat="server" Width="150">
                                            </asp:DropDownList>&nbsp;
                                            <input type="button" value="添加接收人" class="button" onclick="AddMan()" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                            通知类别
			                                <asp:RadioButton id="RadioButton1" runat="server" GroupName="a" Text="普通"></asp:RadioButton>
			                                <asp:RadioButton id="RadioButton2" runat="server" GroupName="a" Text="重要"></asp:RadioButton>
                                        </td>
									</tr>
									<tr>
										<td align="left">
										            &nbsp;&nbsp;附　件&nbsp;
										            <asp:DropDownList ID="DropDownList2" runat="server" Width="300">
                                                    </asp:DropDownList>&nbsp;
                                                    <input type="button" value="添加附件" class="button" onclick="FJUpload()" />
                                                    &nbsp;
                                                    <asp:Button ID="Button2" runat="server" Text="清除附件" OnClick="Button2_Click" />
                                        </td>
									</tr>
									
									<tr>
										<td align="left">
										    &nbsp;&nbsp;标　题&nbsp;
										    <asp:TextBox ID="TxtTitle" runat="server" Width="600" MaxLength="80"></asp:TextBox>
                                        </td>
									</tr>
									
									<tr>
										<td>内容
                                            <fckeditorv2:fckeditor id="FCKeditor1" runat="server" Height="250"></fckeditorv2:fckeditor>
										    
                                        </td>
									</tr>									
								</table>
							</td>
						</tr>
					</table>
				</td>
			</tr>
		</table>       
                                                    <asp:button runat="server" text="Button" ID="isSubmit" OnClick="isSubmit_Click" />
                                                    <asp:button runat="server" text="Button" ID="DelSendNotice" OnClick="DelSendNotice_Click" />
		
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <div class="abc"></div>
            <div class="abc1"><div style="color:Red; font-size:13pt;"> 正在读取数据... <img src="images/progress.gif" /></div></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:Button ID="BtnSend" runat="server" Text=" 发 送 " OnClientClick="return Check()" OnClick="BtnSend_Click" />

    </div>
    <input type="hidden" id="isSend" />
    <input id="SubmitType" type="hidden" runat="server" />
    </form>
</body>
</html>

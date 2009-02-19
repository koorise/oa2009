<%@ Page Language="C#" AutoEventWireup="True" Inherits="OAWeb.SendNoticeAdd" Codebehind="SendNoticeAdd.aspx.cs" %>


<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <base target="_self">
	<link href="style.css" type="text/css" rel="stylesheet" />
	<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
	<script language="JavaScript">	
		function Check(){
			if(document.all.ListBox2.length==0){  
				alert('请先选择接收通知的用户');
				return false;
			}	
		}
        function CreateUserIDStr()
        {
			var coll = document.all.ListBox2.options;
			document.all.ReceiveUserIDStr.value = "";
			//把选择的用户ID存为格式：UserID,UserID,UserID.....
			for (i=0; i< coll.length; i++){
				KinID=coll[i].value;
				document.all.ReceiveUserIDStr.value = document.all.ReceiveUserIDStr.value+KinID;
				if(i<coll.length-1)
					document.all.ReceiveUserIDStr.value = document.all.ReceiveUserIDStr.value+',';
			}    	        
        }
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
            CreateUserIDStr();
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
		    CreateUserIDStr();
	    }	
    </script>	
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="text-align:center;">
		<table id="Table1" cellspacing="0" cellpadding="0"  border="0" style="text-align:center">
			<tr>
				<td>
					<table cellspacing="0" cellpadding="5" width="600" border="0">
						<tr>
							<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>">
								<table cellspacing="0" bordercolordark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' 
                                    cellpadding="5" width="100%" 
                                    bordercolorLight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>' 
                                    border="1">
									<tr>
										<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>" colspan="3">                      
										<asp:Label ID="Label3" runat="server" Text="Label" SkinID="Title">发送通知</asp:Label>
                                        </td>
									</tr>
									<tr>
									    <td>用户
									    </td>
									    <td>
                                            &nbsp;
									    </td>
									    <td>接收通知的用户
									    </td>
									</tr>
									<tr>
                                            <td style="width: 100px">
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        部门&nbsp;<asp:DropDownList ID="DropDownList1" runat="server" Width="178px" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple" Height="210px" Width="220px"></asp:ListBox>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            
                                            </td>
                                            <td style="width: 100px">
                                                <table>
                                                    <tr>
                                                        <td style="width: 100px">
                                                <input style="WIDTH: 48px; HEIGHT: 24px" type="button" value=">>" class="button" onclick="MoveName()" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px">
                                                
                                                <input style="WIDTH: 48px; HEIGHT: 24px" onclick="MoveNameBack()" class="button" type="button" value="<<" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 100px">
                                                <br />&nbsp;
                                                <asp:ListBox ID="ListBox2" runat="server" SelectionMode="Multiple" Height="210px" Width="220px"></asp:ListBox>
                                            </td>
									</tr>
									<tr>
										<td colspan="3">
                                            &nbsp;
                                            <asp:Button ID="BtnOK" runat="server" OnClientClick="return Check()" Text="确 定" OnClick="BtnOK_Click" />
                                            &nbsp;&nbsp;
                                            <input id="BtnCancel" type="button" class="button" value="取 消" onclick="window.close()" />
                                              
                                        </td>
									</tr>									
								</table>
                            </td>
						</tr>
					</table>
				</td>
			</tr>
		</table>     
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <div class="abc"></div>
                <div class="abc1"><div style="color:Red; font-size:13pt;"> 正在读取数据... <img src="images/progress.gif" /></div></div>
            </ProgressTemplate>
        </asp:UpdateProgress>		   

    </div>
    <asp:TextBox ID="isSubmit" runat="server"></asp:TextBox>
    <asp:TextBox ID="ReceiveUserIDStr" runat="server"></asp:TextBox>
   </form>
</body>
</html>

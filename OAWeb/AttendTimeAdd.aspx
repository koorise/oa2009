<%@ Page Language="C#" AutoEventWireup="True" Inherits="OAWeb.AttendTimeAdd" Codebehind="AttendTimeAdd.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
	<LINK href="style.css" type="text/css" rel="stylesheet">
	<script language="javascript" src="js/Public.js"></script>
	<script>
function TABLE2_onclick() {

}
    function window_load()
    {
        PeriodNumChange();
    }
    function PeriodNumChange(){
        if(document.all("DDLAttendTimeNum").value=="1")
        {
        document.all('Panel1').style.display="";
        document.all('Panel2').style.display="none";
        document.all('Panel3').style.display="none";
        }
        if(document.all("DDLAttendTimeNum").value=="2")
        {
        document.all('Panel1').style.display="";
        document.all('Panel2').style.display="";
        document.all('Panel3').style.display="none";
        }
        if(document.all("DDLAttendTimeNum").value=="3")
        {
        document.all('Panel1').style.display="";
        document.all('Panel2').style.display="";
        document.all('Panel3').style.display="";
        }
    }
    //保存
		function Add()
		{
		    if(vdf('form1.txtAttendTimeName','请先输入时段名称！','r')==false)
			return false;
			if(vdf('form1.txtBelated','多少分钟内为迟到时间！','r')==false)
			return false;
			//时段一
			if(vdf('form1.txtStartTime1_1','请先输入时段一上班时间！','r')==false)
			return false;
			if(vdf('form1.txtEndTime1_1','请先输入时段一下班时间！','r')==false)
			return false;
			//上下班开始结束时间分为空判断
			if(vdf('form1.txtBefore1','请先输入时段一上班前多少分钟开始时间！','r')==false)
			return false;
			if(vdf('form1.txtAfter1','请先输入时段一下班后多少分钟结束时间！','r')==false)
			return false;
			//分为空判断
			if(document.all("txtStartTime1_2").value=="")
				document.all("txtStartTime1_2").value="00";
			if(document.all("txtEndTime1_2").value=="")
				document.all("txtEndTime1_2").value="00";
			//时段二
			if(document.all("DDLAttendTimeNum").value=="2")
			{
			if(vdf('form1.txtStartTime2_1','请先输入时段二上班时间！','r')==false)
			return false;
			if(vdf('form1.txtEndTime2_1','请先输入时段二下班时间！','r')==false)
			return false;
			//上下班开始结束时间分为空判断
			if(vdf('form1.txtBefore2','请先输入时段二上班前多少分钟开始时间！','r')==false)
			return false;
			if(vdf('form1.txtAfter2','请先输入时段二下班后多少分钟结束时间！','r')==false)
			return false;
			//分为空判断
			if(document.all("txtStartTime2_2").value=="")
				document.all("txtStartTime2_2").value="00";
			if(document.all("txtEndTime2_2").value=="")
				document.all("txtEndTime2_2").value="00";
			}
			//时段三
			if(document.all("DDLAttendTimeNum").value=="3")
			{
			//时段二
			if(vdf('form1.txtStartTime2_1','请先输入时段二上班时间！','r')==false)
			return false;
			if(vdf('form1.txtEndTime2_1','请先输入时段二下班时间！','r')==false)
			return false;
			//上下班开始结束时间分为空判断
			if(vdf('form1.txtBefore2','请先输入时时段二上班前多少分钟开始时间！','r')==false)
			return false;
			if(vdf('form1.txtAfter3','请先输入时段二下班后多少分钟结束时间！','r')==false)
			return false;
			//分为空判断
			if(document.all("txtStartTime2_2").value=="")
				document.all("txtStartTime2_2").value="00";
			if(document.all("txtEndTime2_2").value=="")
				document.all("txtEndTime2_2").value="00";
			//时段三
			if(vdf('form1.txtStartTime3_1','请先输入时段三上班时间！','r')==false)
			return false;
			if(vdf('form1.txtStartTime3_1','请先输入时段三上班时间！','r')==false)
			return false;
			//上下班开始结束时间分为空判断
			if(vdf('form1.txtBefore3','请先输入时段三上班前多少分钟开始时间！','r')==false)
			return false;
			if(vdf('form1.txtAfter3','请先输入时段三下班后多少分钟结束时间！','r')==false)
			return false;
			//分为空判断
			if(document.all("txtStartTime3_2").value=="")
				document.all("txtStartTime3_2").value="00";
			if(document.all("txtEndTime3_2").value=="")
				document.all("txtEndTime3_2").value="00";
			}
		}
		function CheckNum23(a)
		{
            if(document.all(a.id).value>23)
            {
                alert('不能大于23');
                document.all(a.id).focus();
                document.all(a.id).value="";
                return false;
            }
		}
		function CheckNum1(a)
		{
            if(document.all(a.id).value>59)
            {
                alert('不能大于59');
                document.all(a.id).focus();
                document.all(a.id).value="";
                return false;
            }
		}
	</script>
</head>
<body onload="window_load()" style="margin-top: 5px; width:760px">
    <form id="form1" runat="server" onkeydown="keydown()" onchange="return Add()">
    <div style="text-align:center;">
 			<table id="Table1" cellspacing="0" cellpadding="0" width="600" border="0">
				<tr>
					<td>
						<table cellspacing="0" cellpadding="5" width="100%" border="0">
							<tr>
								<td bgColor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>'>
									<table cellspacing=0 bordercolorDark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' 
										cellpadding="5" width="600px" 
										bordercolorLight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>' 
										border=1>
										<tr>
											<td style="text-align:center; background-color:<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>"  
											colspan="2"><asp:Label ID="Label1" runat="server" Text="Label" SkinID="Title"><%=ViewState["sTitle"].ToString()%>考勤资料</asp:Label>
											</td>
										</tr>
                                        <tr>
                                            <td colspan="2">
                                                每天时段数:<asp:DropDownList ID="DDLAttendTimeNum" runat="server" onchange="PeriodNumChange()">
                                                    <asp:ListItem>1</asp:ListItem>
                                                    <asp:ListItem>2</asp:ListItem>
                                                    <asp:ListItem>3</asp:ListItem>
                                                </asp:DropDownList>
                                                时段名称:<asp:TextBox ID="txtAttendTimeName" runat="server" Width="110px" MaxLength="20"></asp:TextBox>
                                                多少分钟内为迟到:<asp:TextBox ID="txtBelated" runat="server" Width="30px" MaxLength="2" onKeypress="CheckNum()" onkeyup="CheckNum1(this)"></asp:TextBox></td>
                                        </tr>
									</table>
								</td>
							</tr>
						</table><br />
						<asp:Panel ID="Panel1" runat="server">
                                                    <table cellspacing=0 bordercolorDark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' 
										cellpadding="5" width="600" 
										bordercolorLight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>' 
										border=1 id="TABLE2" onclick="return TABLE2_onclick()">
                                                        <tr>
                                                            <td colspan="4" style="text-align:center; background-color:<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>">
                                                                时段一</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                上班前多少分钟开始</td>
                                                            <td>
                                                                上班时间</td>
                                                            <td>
                                                                下班时间</td>
                                                            <td>
                                                                下班后多少分钟结束</td>
                                                        </tr>
                                                        <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtBefore1" runat="server" Width="40px" MaxLength="2" onKeypress="CheckNum()"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtStartTime1_1" runat="server" Width="30px" MaxLength="2" onKeypress="CheckNum()" onkeyup="CheckNum23(this)"></asp:TextBox>时<asp:TextBox
                                                                ID="txtStartTime1_2" runat="server" Width="30px" MaxLength="2" onKeypress="CheckNum()" onkeyup="CheckNum1(this)"></asp:TextBox>分</td>
                                                        <td>
                                                            <asp:TextBox ID="txtEndTime1_1" runat="server" Width="30px" MaxLength="2" onKeypress="CheckNum()" onkeyup="CheckNum23(this)"></asp:TextBox>时<asp:TextBox
                                                                ID="txtEndTime1_2" runat="server" Width="30px" MaxLength="2" onKeypress="CheckNum()" onkeyup="CheckNum1(this)"></asp:TextBox>分</td>
                                                        <td>
                                                            <asp:TextBox ID="txtAfter1" runat="server" Width="40px" MaxLength="2" onKeypress="CheckNum()"></asp:TextBox></td>
                                                    </tr>
                                                    </table><br />
                                                    </asp:Panel>
                                                    <asp:Panel ID="Panel2" runat="server">
                                                    <table cellspacing=0 bordercolorDark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' 
										cellpadding="5" width="600" 
										bordercolorLight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>' 
										border=1 id="TABLE3" onclick="return TABLE2_onclick()">
                                                        <tr>
                                                            <td colspan="4" style="text-align:center; background-color:<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>">
                                                                时段二</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                上班前多少分钟开始</td>
                                                            <td>
                                                                上班时间</td>
                                                            <td>
                                                                下班时间</td>
                                                            <td>
                                                                下班后多少分钟结束</td>
                                                        </tr>
                                                        <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtBefore2" runat="server" Width="40px" MaxLength="2" onKeypress="CheckNum()"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtStartTime2_1" runat="server" Width="30px" MaxLength="2" onKeypress="CheckNum()" onkeyup="CheckNum23(this)"></asp:TextBox>时<asp:TextBox
                                                                ID="txtStartTime2_2" runat="server" Width="30px" MaxLength="2" onKeypress="CheckNum()" onkeyup="CheckNum1(this)"></asp:TextBox>分</td>
                                                        <td>
                                                            <asp:TextBox ID="txtEndTime2_1" runat="server" Width="30px" MaxLength="2" onKeypress="CheckNum()" onkeyup="CheckNum23(this)"></asp:TextBox>时<asp:TextBox
                                                                ID="txtEndTime2_2" runat="server" Width="30px" MaxLength="2" onKeypress="CheckNum()" onkeyup="CheckNum1(this)"></asp:TextBox>分</td>
                                                        <td>
                                                            <asp:TextBox ID="txtAfter2" runat="server" Width="40px" MaxLength="2" onKeypress="CheckNum()"></asp:TextBox></td>
                                                    </tr>
                                                    </table><br />
                                                </asp:Panel>
                                                <asp:Panel ID="Panel3" runat="server">
                                                <table cellspacing=0 bordercolorDark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' 
										cellpadding="5" width="600" 
										bordercolorLight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>' 
										border=1 id="TABLE4" onclick="return TABLE2_onclick()">
                                                        <tr>
                                                            <td colspan="4" style="text-align:center; background-color:<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>">
                                                                时段三</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                上班前多少分钟开始</td>
                                                            <td>
                                                                上班时间</td>
                                                            <td>
                                                                下班时间</td>
                                                            <td>
                                                                下班后多少分钟结束</td>
                                                        </tr>
                                                        <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtBefore3" runat="server" Width="40px" MaxLength="2" onKeypress="CheckNum()"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtStartTime3_1" runat="server" Width="30px" MaxLength="2" onKeypress="CheckNum()" onkeyup="CheckNum23(this)"></asp:TextBox>时<asp:TextBox
                                                                ID="txtStartTime3_2" runat="server" Width="30px" MaxLength="2" onKeypress="CheckNum()" onkeyup="CheckNum1(this)"></asp:TextBox>分</td>
                                                        <td>
                                                            <asp:TextBox ID="txtEndTime3_1" runat="server" Width="30px" MaxLength="2" onKeypress="CheckNum()" onkeyup="CheckNum23(this)"></asp:TextBox>时<asp:TextBox
                                                                ID="txtEndTime3_2" runat="server" Width="30px" MaxLength="2" onKeypress="CheckNum()" onkeyup="CheckNum1(this)"></asp:TextBox>分</td>
                                                        <td>
                                                            <asp:TextBox ID="txtAfter3" runat="server" Width="40px" MaxLength="2" onKeypress="CheckNum()"></asp:TextBox></td>
                                                    </tr>
                                                    </table><br />
                                                </asp:Panel>
					<asp:Button ID="Button1" runat="server" Text="添 加" OnClick="Button1_Click" />
                                                <asp:Button ID="Button2" runat="server" Text="返 回" OnClick="Button2_Click" /></td>
				</tr>
                 <tr>
                     <td>
                     </td>
                 </tr>
			</table>   
    </div>
    </form>
</body>
</html>

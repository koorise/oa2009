<%@ Page Language="C#" AutoEventWireup="True" Inherits="OAWeb.AttendShiftAdd" Codebehind="AttendShiftAdd.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>�ޱ���ҳ</title>
    <LINK href="style.css" type="text/css" rel="stylesheet">
	<script language="javascript" src="js/Public.js"></script>
	<script language="javascript">
		
		//������Ϊ����
		function aa(){
			//document.all("Dropdownlist1").style.display="none"
			trdisplay();
			if(form1.ShiftType[1].checked)
			{
				MonthChange();
			}
			else
			{
			  for(i=1;i<8;i++)
				{
					eval("document.all('Label"+i+"').style.display='none';");
					eval("document.all('Dropdownlist"+i+"').style.display='';");
				}
				for(i=8;i<43;i++)
				{
					eval("document.all('Label"+i+"').style.display='none';");
					eval("document.all('Dropdownlist"+i+"').style.display='none';");
				}
			}
		}
		function MonthChange()
		{
			for(i=1;i<43;i++)
			{
				eval("document.all('Label"+i+"').style.display='';");
				eval("document.all('Dropdownlist"+i+"').style.display='';");
			}
		}
		//������
		function trdisplay()
		{
		        document.all('FirstDayToWeek').style.display="none";
		        document.all('MonthDayNum').style.display="none";
		   if(form1.ShiftType[1].checked)
		   {
		        document.all('ShiftYear').style.display="";
		        document.all('ShiftMonth').style.display="";
		        document.all('tr2').style.display="";
				document.all('tr3').style.display="";
				document.all('tr4').style.display="";
				document.all('tr5').style.display="";
				document.all('tr6').style.display="";
		   }
		   else
		   {
		        document.all('ShiftYear').style.display="none";
		        document.all('ShiftMonth').style.display="none";
		        document.all('tr2').style.display="none";
				document.all('tr3').style.display="none";
				document.all('tr4').style.display="none";
				document.all('tr5').style.display="none";
				document.all('tr6').style.display="none";
		   }
		   
		}
		function window_load()
		{
		aa();
		}
		function MonthChange()
		{
		//һ�������ڼ�
		    a=form1.ShiftYear.value+"/"+form1.ShiftMonth.value+"/1";
		    var dd=new Date(a);
			form1.FirstDayToWeek.value=dd.getDay()+1;		//��¼һ�Ŷ�Ӧ�Ŀؼ�
			form1.MonthDayNum.value=MonthDayNum(form1.ShiftYear.value,form1.ShiftMonth.value);		//��¼ѡ������ж�����	
		//�������пؼ�
			for(i=1;i<43;i++)
			{
				eval("document.all('Label"+i+"').style.display='none';");
				eval("document.all('Dropdownlist"+i+"').style.display='none';");
			}
			
			//��ʾ���µĿؼ�
			n=0;	
			for(i=dd.getDay()+1;i<dd.getDay()+MonthDayNum(form1.ShiftYear.value,form1.ShiftMonth.value)+1;i++)
			{
				n++;
				eval("document.all('Label"+i+"').style.display='';");
				eval("Label"+i+".innerText='"+n+"'");
				eval("document.all('Dropdownlist"+i+"').style.display=''");
			}
		}
		//ĳ���ĳ���ж�����
		function MonthDayNum(y,m)
		{
			var a = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
			if(0==y%4 && (y%100!=0 || y%400==0)) a[1] = 29;
			return a[m-1];
		}
		//����
		function Save()
		{
            if(vdf('form1.ShiftName','�����������ƣ�','r')==false)
			    return false;
			if(form1.ShiftType[1].checked==true)
			{
			   //document.all("FirstDayToWeek").value="1";
			   //document.all("MonthDayNum").value="7";
			}
			else
			{
			   document.all("FirstDayToWeek").value="1";
			   document.all("MonthDayNum").value="7";
			}
		}	
		</script>
</head>
<body onload="window_load()">
    <form id="form1" runat="server" onkeydown="keydown()">
    <div style="text-align:center;">
 			<table id="Table1" cellspacing="0" cellpadding="0" width="650" border="0">
                 <tr>
                     <td>
                     </td>
                 </tr>
				<tr>
					<td>
						<table cellspacing="0" cellpadding="5" width="100%" border="0">
							<tr>
								<td bgColor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>'>
									<table cellspacing=0 bordercolorDark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' 
										cellpadding="5" width="100%" 
										bordercolorLight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>' 
										border=1>
										<tr>
											<td style="text-align:center; background-color:<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>"  
											colspan="2"><asp:Label ID="Label43" runat="server" Text="Label" SkinID="Title"><%=ViewState["sTitle"].ToString()%>�ְ�����</asp:Label>
											</td>
										</tr>
										<tr>
											<td>
                                                �ְ�����&nbsp;</td>
											<td>
												<asp:TextBox id="ShiftName" runat="server" MaxLength="30"></asp:TextBox>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 650px">
                            <tr>
                                <td align="center">
                                                <asp:RadioButtonList ID="ShiftType" runat="server" RepeatDirection="Horizontal" onclick="aa()">
                                                    <asp:ListItem Selected="True" Value="1">������Ϊ����</asp:ListItem>
                                                    <asp:ListItem Value="2">����Ϊ����</asp:ListItem>
                                                </asp:RadioButtonList>
                                                <asp:DropDownList ID="ShiftYear" runat="server" onchange="MonthChange()">
                                                    <asp:ListItem Value="2007">2007��</asp:ListItem>
                                                    <asp:ListItem Value="2008">2008��</asp:ListItem>
                                                    <asp:ListItem Value="2009">2009��</asp:ListItem>
                                                    <asp:ListItem Value="2010">2010��</asp:ListItem>
                                                    <asp:ListItem Value="2011">2011��</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ShiftMonth" runat="server" onchange="MonthChange()">
                                                    <asp:ListItem Value="1">1��</asp:ListItem>
                                                    <asp:ListItem Value="2">2��</asp:ListItem>
                                                    <asp:ListItem Value="3">3��</asp:ListItem>
                                                    <asp:ListItem Value="4">4��</asp:ListItem>
                                                    <asp:ListItem Value="5">5��</asp:ListItem>
                                                    <asp:ListItem Value="6">6��</asp:ListItem>
                                                    <asp:ListItem Value="7">7��</asp:ListItem>
                                                    <asp:ListItem Value="8">8��</asp:ListItem>
                                                    <asp:ListItem Value="9">9��</asp:ListItem>
                                                    <asp:ListItem Value="10">10��</asp:ListItem>
                                                    <asp:ListItem Value="11">11��</asp:ListItem>
                                                    <asp:ListItem Value="12">12��</asp:ListItem>
                                                </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                </td>
                            </tr>
                        </table>
						<table cellspacing=0 bordercolorDark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' 
										cellpadding="2" width="650px" 
										bordercolorLight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>' 
										border=1>
                                                    <tr style="text-align:center; background-color:<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>">
                                                        <td style="height: 25px; width: 90px;">
                                                            ������</td>
                                                        <td style="width: 91px; height: 25px">
                                                            ����һ</td>
                                                        <td style="width: 91px; height: 25px">
                                                            ���ڶ�</td>
                                                        <td style="width: 90px; height: 25px">
                                                            ������</td>
                                                        <td style="width: 90px; height: 25px">
                                                            ������</td>
                                                        <td style="width: 90px; height: 25px">
                                                            ������</td>
                                                        <td style="width: 90px; height: 25px">
                                                            ������</td>
                                                    </tr>
                                                    <tr id="tr1">
                                                        <td align="left" style="width: 90px">
                                                            <asp:Label ID="Label1" runat="server" Text="Label" Width="15px"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList1" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 91px">
                                                            <asp:Label ID="Label2" runat="server" Text="Label" Width="15px"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList2" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 91px">
                                                            <asp:Label ID="Label3" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList3" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 90px">
                                                            <asp:Label ID="Label4" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList4" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 90px">
                                                            <asp:Label ID="Label5" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList5" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 90px">
                                                            <asp:Label ID="Label6" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList6" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 90px">
                                                            <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList7" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr id="tr2">
                                                        <td align="left" style="width: 90px">
                                                            <asp:Label ID="Label8" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList8" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 91px">
                                                            <asp:Label ID="Label9" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList9" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 91px">
                                                            <asp:Label ID="Label10" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList10" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 90px">
                                                            <asp:Label ID="Label11" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList11" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 90px">
                                                            <asp:Label ID="Label12" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList12" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 90px">
                                                            <asp:Label ID="Label13" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList13" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 90px">
                                                            <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList14" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr id="tr3">
                                                        <td align="left" style="width: 90px">
                                                            <asp:Label ID="Label15" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList15" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 91px">
                                                            <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList16" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 91px">
                                                            <asp:Label ID="Label17" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList17" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 90px">
                                                            <asp:Label ID="Label18" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList18" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 90px">
                                                            <asp:Label ID="Label19" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList19" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 90px">
                                                            <asp:Label ID="Label20" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList20" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 90px">
                                                            <asp:Label ID="Label21" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList21" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr id="tr4">
                                                        <td align="left" style="width: 90px">
                                                            <asp:Label ID="Label22" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList22" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 91px">
                                                            <asp:Label ID="Label23" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList23" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 91px">
                                                            <asp:Label ID="Label24" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList24" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 90px">
                                                            <asp:Label ID="Label25" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList25" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 90px">
                                                            <asp:Label ID="Label26" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList26" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 90px">
                                                            <asp:Label ID="Label27" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList27" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 90px">
                                                            <asp:Label ID="Label28" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList28" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr id="tr5">
                                                        <td align="left" style="width: 90px">
                                                            <asp:Label ID="Label29" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList29" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 91px">
                                                            <asp:Label ID="Label30" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList30" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 91px">
                                                            <asp:Label ID="Label31" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList31" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 90px">
                                                            <asp:Label ID="Label32" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList32" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 90px">
                                                            <asp:Label ID="Label33" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList33" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 90px">
                                                            <asp:Label ID="Label34" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList34" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 90px">
                                                            <asp:Label ID="Label35" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList35" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr id="tr6">
                                                        <td align="left" style="width: 90px">
                                                            <asp:Label ID="Label36" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList36" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 91px">
                                                            <asp:Label ID="Label37" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList37" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 91px">
                                                            <asp:Label ID="Label38" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList38" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 90px">
                                                            <asp:Label ID="Label39" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList39" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 90px">
                                                            <asp:Label ID="Label40" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList40" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 90px">
                                                            <asp:Label ID="Label41" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList41" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                        <td align="left" style="width: 90px">
                                                            <asp:Label ID="Label42" runat="server" Text="Label" Width="15"></asp:Label>
                                                            <asp:DropDownList ID="DropDownList42" runat="server" Width="65">
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                </table>
					</td>
				</tr>
                 <tr>
                     <td>
												<asp:Button id="Button1" runat="server" Text="�� ��" OnClick="Button1_Click"></asp:Button>
												<asp:Button id="Button2" runat="server" Text="�� ��" OnClick="Button2_Click"></asp:Button></td>
                 </tr>
			</table>   
    </div>
        <asp:TextBox ID="FirstDayToWeek" runat="server"></asp:TextBox>
        <asp:TextBox ID="MonthDayNum" runat="server"></asp:TextBox>
    </form>
</body>
</html>

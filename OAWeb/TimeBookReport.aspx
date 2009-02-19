<%@ Page Language="C#" AutoEventWireup="true" Inherits="OAWeb.TimeBookReport" Codebehind="TimeBookReport.aspx.cs" %>

<%@ Register Src="UserControl/DDLSelToSchool.ascx" TagName="DDLSelToSchool" TagPrefix="uc1" %>

<%@ Register Assembly="MSPlus.DatePicker" Namespace="MSPlus.Web.UI.WebControls" TagPrefix="cc1" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
	<link href="style.css" type="text/css" rel="stylesheet" />
	<link href="Common/CSS/Default.CSS" type="text/css" rel="stylesheet" />
	<script language="JavaScript" src="Common/JavaScript/DatePicker.js"></script>		
	<script language="javascript" src="js/Public.js"></script>
	<script>
	    function Check()
	    {
	        if(vdf('form1.DatePicker1','请先选择刷卡时间段','r')==false)
		        return false;
	        if(vdf('form1.DatePicker2','请先选择刷卡时间段','r')==false)
		        return false;
		    var xg = DateDiff(form1.DatePicker2.value,form1.DatePicker1.value);
		    if(xg>30)
		    {
		        alert('统计的刷卡日期不能大于一个月');
		        return false;
		    }		        
	    }
	</script>
</head>
<body style="background-color:White">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    
    <div style="text-align:center">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <table cellpadding="5" ><tr><td align="center">        
		<table id="Table1" cellspacing="0" cellpadding="0"  border="0">
			<tr>
				<td>
					<table cellspacing="0" cellpadding="5" width="750" border="0">
						<tr>
							<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>;">
								<table cellspacing=0 borderColorDark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' 
                                    cellPadding=5 width="100%" 
                                    borderColorLight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>' 
                                    border=1 style="text-align:center">
									<tr>
										<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>" align="center">                      
                                            <asp:Label ID="Label1" runat="server" Text="Label" SkinID="Title">老师考勤统计</asp:Label></td>
									</tr>
									<tr>
										<td align="center">      
                                            <uc1:DDLSelToSchool ID="DDLSelToSchool1" runat="server" OnSchoolOnSelectedIndexChanged="DDLSchool_SelectedIndexChanged" />
                                            
                                        </td>
							        </tr>
									<tr>
										<td align="center">      
                                            刷卡时间<cc1:datepicker id="DatePicker1" runat="server"></cc1:datepicker>
                                            至<cc1:DatePicker ID="DatePicker2" runat="server" />
                                            &nbsp;
										    <asp:checkbox id="CheckBox1" runat="server" Text="符号表示: <font color=Green>√</font>正常 <font color=Red>×</font>缺勤 <font color=SteelBlue>△</font>迟到 <font color=Turquoise>●</font>休息" Checked="True" OnCheckedChanged="CheckBox1_CheckedChanged"></asp:checkbox>
                                            <asp:Button ID="Button1" runat="server" Text="统 计" OnClick="Button1_Click" />
                                            &nbsp;
                                            <asp:Button id="Button2" runat="server" Text="导出EXCEL" OnClientClick="document.getElementById('Button3').click();return false;"></asp:Button>
                                        </td>
							        </tr>
								</table>
							</td>
						</tr> 
				
					</table>
				</td>
			</tr>
		</table>
		<tr>
			<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>">	
                        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" Width="950" RowStyle-HorizontalAlign="center" FooterStyle-HorizontalAlign="center"
                        OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="true" AllowSorting="false" ShowFooter="false" AllowPaging="false">
                        </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server">
                </asp:SqlDataSource>
             </td>
		</tr>		
	    </table> 					                    			
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Button ID="Button3" runat="server" Text="Button" OnClick="Button3_Click" />
    
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <div class="abc"></div>
            <div class="abc1"><div style="color:Red; font-size:13pt;"> 正在读取数据... <img src="images/progress.gif" /></div></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
	</div>
    </form>
</body>
</html>

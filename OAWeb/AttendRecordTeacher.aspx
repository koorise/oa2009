<%@ Page Language="C#" AutoEventWireup="true" Inherits="OAWeb.AttendRecord" Codebehind="AttendRecord.aspx.cs" %>

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
	    }
	</script>
</head>
<body style="background-color:White">
    <form id="form1" runat="server">
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    
    <div style="text-align:center">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    
		<table id="Table1" cellspacing="0" cellpadding="0"  border="0" style="text-align:center">
			<tr>
				<td>
					<table cellspacing="0" cellpadding="5" width="750" border="0">
						<tr>
							<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>">
								<table cellspacing=0 borderColorDark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' 
                                    cellPadding=5 width="100%" 
                                    borderColorLight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>' 
                                    border=1>
									<tr>
										<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>" align="center">                      
                                            <asp:Label ID="Label1" runat="server" Text="Label" SkinID="Title">老师考勤记录查询</asp:Label></td>
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
										    考勤时段
							                <asp:dropdownlist id="TimeSign" runat="server">
								                <asp:ListItem Value="0">全部</asp:ListItem>
								                <asp:ListItem Value="1">时段1上班</asp:ListItem>
								                <asp:ListItem Value="101">时段1迟到</asp:ListItem>
								                <asp:ListItem Value="2">时段1下班</asp:ListItem>
								                <asp:ListItem Value="3">时段2上班</asp:ListItem>
								                <asp:ListItem Value="103">时段2迟到</asp:ListItem>
								                <asp:ListItem Value="4">时段2下班</asp:ListItem>
								                <asp:ListItem Value="5">时段3上班</asp:ListItem>
								                <asp:ListItem Value="105">时段3迟到</asp:ListItem>
								                <asp:ListItem Value="6">时段3下班</asp:ListItem>
								                <asp:ListItem Value="200">未明</asp:ListItem>
							                </asp:dropdownlist>
							                &nbsp;
                                            老师名字
                                            <asp:TextBox ID="UserName" runat="server" Width="77px"></asp:TextBox>
										   
                                            <asp:Button ID="Button1" runat="server" Text="查 询" OnClick="Button1_Click" />
                                        </td>
							        </tr>
								</table>
							</td>
						<tr>
							<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>">	
                                <asp:GridView ID="GridView1" DataKeyNames="AutoID" runat="server" ShowFooter="True" DataSourceID="SqlDataSource1"
                                  OnRowDataBound="GridView1_RowDataBound" Width="750px">
                                    <EmptyDataTemplate>
                                        没有数据
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:BoundField DataField="UserName" HeaderText="老师姓名" >
                                        </asp:BoundField>
                                        <asp:BoundField DataField="RecordTime" HeaderText="刷卡时间" >
                                        </asp:BoundField>
                                        <asp:BoundField DataField="RecordType" HeaderText="考勤类型" >
                                        </asp:BoundField>
                                        <asp:BoundField DataField="RecordState" HeaderText="考勤状态" >
                                        </asp:BoundField>
                                   </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server">
                                </asp:SqlDataSource>
                            </td>
						</tr>
								</table>
							</td>
						</tr>
					</table>
        </ContentTemplate>
    </asp:UpdatePanel>
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

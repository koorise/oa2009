<%@ Page Language="C#" AutoEventWireup="True" Inherits="OAWeb.AttendShift" Codebehind="AttendShift.aspx.cs" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>�ޱ���ҳ</title>
	<LINK href="style.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    
    <div style="text-align:center">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    
		<table id="Table1" cellspacing="0" cellpadding="0"  border="0" style="text-align:center">
			<tr>
				<td>
					<table cellspacing="0" cellpadding="5" width="600" border="0">
						<tr>
							<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>">
								<table cellspacing=0 borderColorDark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' 
                                    cellPadding=5 width="100%" 
                                    borderColorLight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>' 
                                    border=1>
									<tr>
										<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>">                      
                                            <asp:Label ID="Label1" runat="server" Text="Label" SkinID="Title">�ְ�����</asp:Label></td>
									</tr>
								</table>
							</td>
						</tr>
						<tr>
							<td align="right">
								<asp:LinkButton id="LinkButton1" runat="server" OnClick="LinkButton1_Click"><IMG src="images/add.gif" align="absBottom" border="0">����</asp:LinkButton>
							</td>
						</tr>						
						<tr>
							<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>">	
                                        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" OnRowCommand="GridView1_RowCommand">
                                            <EmptyDataTemplate>
                                                û������
                                            </EmptyDataTemplate>
                                            <Columns>
                                                <asp:HyperLinkField DataNavigateUrlFields="AutoID" Text="&lt;img src=images/button_edit.gif border=0 alt=�޸� /&gt;" DataNavigateUrlFormatString="AttendShiftAdd.aspx?AutoID={0}" HeaderText="�༭" />
                                                <asp:BoundField DataField="ShiftName" HeaderText="�ְ�����" SortExpression="ShiftName" />
                                                <asp:BoundField DataField="ShiftType" HeaderText="�ְ෽ʽ" SortExpression="ShiftType" />
                                                <asp:TemplateField HeaderText="ɾ��">
                                                     <ItemTemplate>
                               							<SPAN onclick="return window.confirm('��ȷ��Ҫɾ���ü�¼��')">
                                                            <asp:LinkButton ID="LinkButton1" CommandName="Del" CommandArgument='<%# Eval("AutoID") %>' runat="server" Text="&lt;img src=images/button_del.gif border=0 /&gt;"></asp:LinkButton>
                   										</SPAN>
                                                     </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                        <div class="abc"></div>
                                        <div class="abc1"><div style="color:Red; font-size:13pt;"> ���ڶ�ȡ����... <img src="images/progress.gif" /></div></div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                               <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [AutoID]
      ,[EnterpriseID]
      ,[ShiftName]
      ,case [ShiftType] when 1 then '���ְ�' when 2 then '���ְ�' else '״̬����' end  as [ShiftType]
      ,[ShiftYear]
      ,[ShiftMonth]
      ,[Shift1]
      ,[Shift2]
      ,[Shift3]
      ,[Shift4]
      ,[Shift5]
      ,[Shift6]
      ,[Shift7]
      ,[Shift8]
      ,[Shift9]
      ,[Shift10]
      ,[Shift11]
      ,[Shift12]
      ,[Shift13]
      ,[Shift14]
      ,[Shift15]
      ,[Shift16]
      ,[Shift17]
      ,[Shift18]
      ,[Shift19]
      ,[Shift20]
      ,[Shift21]
      ,[Shift22]
      ,[Shift23]
      ,[Shift24]
      ,[Shift25]
      ,[Shift26]
      ,[Shift27]
      ,[Shift28]
      ,[Shift29]
      ,[Shift30]
      ,[Shift31] FROM [AttendShift] WHERE ([EnterpriseID] = @EnterpriseID)">
                        <SelectParameters>
                            <asp:SessionParameter Name="EnterpriseID" SessionField="EnterpriseID" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                                </td>
						</tr>
					</table>
				</td>
			</tr>
		</table>   
            </ContentTemplate>
        </asp:UpdatePanel>
		 
	</div>
    </form>
</body>
</html>

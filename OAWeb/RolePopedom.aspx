<%@ Page Language="C#" AutoEventWireup="True" Inherits="OAWeb.RolePopedom" Codebehind="RolePopedom.aspx.cs" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>�ޱ���ҳ</title>
	<LINK href="style.css" type="text/css" rel="stylesheet">
    <script>
	function SelectAll(t)
	{
	    if(eval("document.all.GridView1_ctl01_ChkBoxSelectAll"+t+".checked"))
	    {
		    for(i=2;i<<%=GridView1.Rows.Count+2 %>;i++)
		    {
		        try
		        {
			        eval("document.all.GridView1_ctl0"+i+"_CheckBox_"+t+".checked=true")
		        }
		        catch(e)
		        {
		            try
		            {
			            eval("document.all.GridView1_ctl"+i+"_CheckBox_"+t+".checked=true")
			        }
			        catch(e)
			        {}
		        };
		    }
	    }
	    else
	    {
		    for(i=2;i<<%=GridView1.Rows.Count+2 %>;i++)
		    {
		        try
		        {
			        eval("document.all.GridView1_ctl0"+i+"_CheckBox_"+t+".checked=false")
		        }
		        catch(e)
		        {
		            try
		            {
			            eval("document.all.GridView1_ctl"+i+"_CheckBox_"+t+".checked=false")
			        }
			        catch(e)
			        {}
		        };
		    }
	    }
	}	
    </script>		
</head>
<body>
    <form id="form1" runat="server">
  <div style="text-align:center;">
		<table id="Table1" cellspacing="0" cellpadding="0"  border="0" style="text-align:center">
			<tr>
				<td>
					<table cellspacing="0" cellpadding="5" width="200" border="0">
						<tr>
							<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>;">
								<table cellspacing=0 borderColorDark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' 
                                    cellPadding=5 width="100%" 
                                    borderColorLight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>' 
                                    border=1>
									<tr>
										<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>">                      
                                            <asp:Label ID="Label1" runat="server" Text="Label" SkinID="Title">Ȩ������</asp:Label>
                                        </td>
									</tr>
								</table>
							</td>
						</tr>
						<tr>
							<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>">	
                                <asp:GridView ID="GridView1" Width="400px" runat="server" DataSourceID="SqlDataSource1" 
                                 DataKeyNames="AutoID,MView,MEdit" AllowPaging="false" OnRowDataBound="GridView1_RowDataBound">
                                    <EmptyDataTemplate>
                                        û������
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:BoundField DataField="PopedomName" HeaderText="����ģ��" />
                                        <asp:TemplateField HeaderText="�鿴">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="ChkBoxSelectAllV" Runat="server" Text="�鿴"></asp:CheckBox>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox_V" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="�޸�">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="ChkBoxSelectAllE" Runat="server" Text="�޸�"></asp:CheckBox>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox_E" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
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
                   <asp:Button ID="Button1" runat="server" Text="�� ��" OnClick="Button1_Click" />
      &nbsp;
      <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="�� ��" />&nbsp;
  </div>
    </form>
</body>
</html>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Filter.ascx.cs" Inherits="OAWeb.UserControl.Filter" %>
<script>
	function Filter()
	{
	    if(document.all.<%=Label1.ClientID%>.innerHTML=="��ѯ")
		    window.showModalDialog('Filter.aspx?TableName=<%=_XMLFileName%>',window,'dialogHeight:395px;dialogWidth:710px;status:no;help:no;scroll=no');
		else
		{
		    //ȡ����ѯ
		    document.all.<%=Label1.ClientID%>.innerHTML="��ѯ";
            document.all.<%=ConditionValue.ClientID%>.value="";
            document.all.<%=ConditionText.ClientID%>.value="";	
            document.all.<%=ConditionText.ClientID%>.style.color="Black";
    		document.getElementById("<%=BtnSubmit.ClientID%>").click();
		}
	}	    
    function ReceiveWhere(ConditionValue,ConditionText)     //���ղ�ѯ����
    {
        document.all.<%=ConditionValue.ClientID%>.value=unescape(ConditionValue);
        document.all.<%=ConditionText.ClientID%>.value=unescape(ConditionText);
		document.getElementById("<%=BtnSubmit.ClientID%>").click();
    }
    function ShowToolTip(event)	  //��ʾ��ѯ����
    {
        if(document.all.<%=Label1.ClientID%>.innerHTML=="ȡ����ѯ")
        {
            document.all.table1.style.visibility="visible";
            document.all.table1.style.display="inline";
            document.all.table1.style.position="absolute";
            document.all.table1.style.left=event.clientX - 160;
            document.all.table1.style.top=event.clientY + 10;
            document.all.ShowText.innerHTML="��ѯ����:<br>"+document.all.<%=ConditionText.ClientID%>.value.replace("��","<br>");
        }
    }
    function HideToolTip()  //������ѯ����
    {
        document.all.table1.style.visibility="hidden";
        document.all.table1.style.display="none";
    }
</script>
<a href="javascript:Filter();" onmouseover="ShowToolTip(event)" onmouseout="HideToolTip()"><IMG src="images/find.gif" align="absBottom" border="0">
    <asp:Label ID="Label1" runat="server"></asp:Label>
</a>
<table id="table1" cellspacing="0" rules="all" border="1" style="visibility:hidden; position:absolute; width:200px;left:1px; top:1px; text-align:left; background-color:#FDF5E6;border-collapse:collapse;">
<tr><td><span id="ShowText"></span>
</td></tr>
</table>
<asp:Button ID="BtnSubmit" runat="server" Text="Button" OnClick="BtnSubmit_Click" />
<input id="ConditionValue" type="hidden" runat="server"/>
<input id="ConditionText" type="hidden" runat="server"/>



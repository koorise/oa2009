<%@ Page Language="C#" AutoEventWireup="True" Inherits="OAWeb.Filter" Codebehind="Filter.aspx.cs" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>�ޱ���ҳ</title>
	<base target="_self">
	<link href="style.css" type="text/css" rel="stylesheet" />
	<link href="Common/CSS/Default.CSS" type="text/css" rel="stylesheet" />
    <META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=gb2312">
	<script language="JavaScript" src="Common/JavaScript/DatePicker.js"></script>		
		<script>
	        //����WebService�����ķ���ֵ
            function result_fun(result){
                if(result!="0")
                {
                    Control.innerHTML=result;
                }   	
            }	    
		
			function FChange(OptionValue)
			{
				document.all("BtnSetCondition").style.visibility="visible";
				var v=OptionValue.split('#');
                //Ajax��ˢ�µ���WebService����,�ж��Ƿ����໰
                OAWeb.Service.ReturnControl("<%=Request.QueryString["TableName"].ToString()%>",v[0],result_fun);
			}
			//�������
			function SetCondition()	
			{
				var v=document.all.aaa.value.split('#');
				if(v[1]=="dropdownlist")
				{
					ConditionText=document.all.aaa.options[document.all.aaa.selectedIndex].text+" ���� "+document.all.dropdownlist1.options[document.all.dropdownlist1.selectedIndex].text;
					ConditionValue=v[0]+"='"+document.all.dropdownlist1.value+"'";
				}
				
				if(v[1]=="datetime")
				{
					if(document.all("DatePicker1").value==""&&document.all("DatePicker2").value=="")
					{
						alert('����ѡ����������');
						return;
					}
					if(document.all("DatePicker1").value!=""&&document.all("DatePicker2").value!="")
					{
						ConditionText=document.all.aaa.options[document.all.aaa.selectedIndex].text+" ��"+document.all("DatePicker1").value+"��"+document.all("DatePicker2").value+"֮��";
						ConditionValue=v[0]+">='"+document.all("DatePicker1").value+"' and "+v[0]+"<='"+document.all("DatePicker2").value+"'";
					}
					if(document.all("DatePicker1").value=="")
					{
						ConditionText=document.all.aaa.options[document.all.aaa.selectedIndex].text+" С�ڻ����"+document.all("DatePicker2").value;
						ConditionValue=v[0]+"<='"+document.all("DatePicker2").value+"'";
					}
					if(document.all("DatePicker2").value=="")
					{
						ConditionText=document.all.aaa.options[document.all.aaa.selectedIndex].text+" ���ڻ����"+document.all("DatePicker1").value;
						ConditionValue=v[0]+">='"+document.all("DatePicker1").value+"'";
					}
				}
				if(v[1]=="TextBox")
				{
					if(document.all.TextBox1.value=="")
					{
						alert('������������');
						return;
					}
					if(document.all.RadioButton1.checked==true)
					{
						ConditionText=document.all.aaa.options[document.all.aaa.selectedIndex].text+" ������:"+document.all.TextBox1.value
						ConditionValue=v[0]+" like '%"+document.all.TextBox1.value+"%'";
					}
					else
					{
						ConditionText=document.all.aaa.options[document.all.aaa.selectedIndex].text+" ����:"+document.all.TextBox1.value
						ConditionValue=v[0]+"='"+document.all.TextBox1.value+"'";
					}
				}
				var coll = document.all.bbb.options;
				
				for (i=0; i< coll.length; i++)
				{
					//�����Ƿ��Ѿ������˸ò�ѯ����
					if(coll[i].value.substring(0,v[0].length)==v[0])
						document.all.bbb.remove(i);
				}
				document.all.bbb.options.add(new Option(ConditionText,ConditionValue));
				
			}
			function ReSet()
			{
				var coll = document.all.bbb.options;
				m= coll.length
				for (i=0; i< m; i++)
				{
					document.all.bbb.options.remove(0);
				}				
			}
			function OK()
			{
				var coll = document.all.bbb.options;
				var ConditionValue="";
				var ConditionText="";
				for (i=0; i< coll.length; i++)
				{
					ConditionValue+=coll[i].value;
					ConditionText+=coll[i].text;
					if(i!=coll.length-1)
					{
						ConditionValue+=" and "
					    ConditionText+="��";
					}
				}	
				var sData = dialogArguments;
				window.close();
				sData.ReceiveWhere(escape(ConditionValue),escape(ConditionText));
			}
			
		</script>
	</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Services>
            <asp:ServiceReference Path="Services/Service.asmx" />
        </Services>
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
		<table id="Table1" cellSpacing="0" cellPadding="0" width="700" align="center" border="0">
			<tr>
				<td class="TableBody1" vAlign="top">
					<table cellSpacing="0" cellPadding="5" width="100%" align="center" border="0">
						<tr>
							<td bgColor='<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>' >
								<table cellSpacing=0 borderColorDark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' 
								cellPadding=5 width="100%" borderColorLight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>' border=1>
									<tr>
										<td align=center bgColor='<%=Application[Session["Style"].ToString()+"xtable_titlebgcolor"]%>' height=25 colspan=3>
											<b>���ò�ѯ����</b>
										</td>
									</tr>
									<tr>
										<td align="center" width="70%" colspan=2>��������</td>
										<td align="center">�����õĲ�ѯ����</td>
									</tr>
									<tr>
										<td>
											<SELECT onchange="FChange(this.value)" style="Z-INDEX: 101; WIDTH: 184px; HEIGHT: 231px" size="17"
												name="aaa">
												<%
		for(i=0;i<ds.Tables[0].Rows.Count;i++)
		{
%>
												<option  value="<%=ds.Tables[0].Rows[i].ItemArray[0].ToString()+"#"+ds.Tables[0].Rows[i].ItemArray[2].ToString()%>"><%=ds.Tables[0].Rows[i].ItemArray[1].ToString()%>
												</option>
												<%
		}
%>
											</SELECT>
										</td>
										<td align="center" width="200">
											&nbsp;
											<span id="Control"></span>
											<br>
											<br>
											&nbsp;&nbsp;<input name="BtnSetCondition" type=button value="�������>>" onclick="SetCondition()" style="visibility:hidden">
										</td>
										<td align="center">
											<SELECT style="Z-INDEX: 101; WIDTH: 260px; HEIGHT: 231px" size="17" name="bbb">
											</SELECT>
										</td>
									</tr>
									<tr>
										<td colspan=3 align=right>
											<input name="BtnReSet" type=button value="�������" onclick="ReSet()">
											&nbsp;&nbsp;
											<input name="BtnReSet" type=button value=" ȡ�� " onclick="window.close()">
											&nbsp;&nbsp;
											<input name="BtnReSet" type=button value=" ȷ�� " onclick="OK()">
											&nbsp;&nbsp;&nbsp;&nbsp;
										</td>
									</tr>
								</table>
							</td>
						</tr>
					</table>
				
				</td>
		    </tr>
		</table>
            </ContentTemplate>
        </asp:UpdatePanel>
		
	</form>
</body>
</html>

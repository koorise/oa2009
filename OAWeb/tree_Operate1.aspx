<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tree_Operate1.aspx.cs" Inherits="OAWeb.tree_Operate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
	<link rel="stylesheet" href="css/blue.css" type="text/css">
	<script language="javascript" type="text/javascript" src="js/Public.js"></script>
<%
if(Request.QueryString["isReload"]=="1"){
%>		
<script language="javascript">
	parent.frames("leftFrame").document.location.reload();
</script>
<%}%>		
		<script>
		function CheckPopedom()
		{
<%
                if (OAWeb.Common.CheckPopedom(PopedomName, "MEdit") == false)      //判断用户是否有修改权限
				{
				 	Response.Write("alert('您没有权限使用这个功能！');return false;");
				}
%>		
		}
		function Check()
		{
		    if(vdf('admin_Tree.txt_Mytext','请先输入部门名称','r')==false)
			    return false;
		}
		
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="admin_Tree" method="post" runat="server">
  <FONT face="宋体"> 
  <TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0" style="height: 64px">
    <TR> 
      <TD vAlign="top" align="left" width="82%"><br>
        <table cellSpacing="0" cellPadding="0" width="95%" align="center" border="0">
          <tr> 
            <td width="146"> 
              <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                <tr> 
                  <td class="jnfont6" vAlign="center" noWrap> 
                    <div align="left"><IMG height="20" src="images/imgbtn/page_icon.gif" width="23"><font color="#000000" size="3">&nbsp;部门名称</font></div>
                  </td>
                </tr>
              </table>
            </td>
            <td width="609"> 
              <table id="Table2" cellSpacing="0" cellPadding="0" align="right" border="0">
                <tr> 
                  <td valign="middle" width="120"> 
                    <div align="center"><asp:textbox id="txt_Mytext" runat="server" Height="21px" Width="90px" BorderStyle="Groove"></asp:textbox></div>
                  </td>
                  <td valign="middle" width="1"> 
                    <div align="center">
                    <asp:imagebutton id="imgbtn_AddChildNode" runat="server" ImageUrl="images/imgbtn/imgbtn_AddChildNode.jpg" OnClientClick="return Check()" OnClick="imgbtn_AddChildNode_Click"></asp:imagebutton></div>
                  </td>
                  <td valign="middle" width="120"> 
                    <div align="center"><asp:imagebutton id="imgbtn_AddBrotherNode" runat="server" ImageUrl="images/imgbtn/imgbtn_AddBrotherNode.jpg" OnClientClick="return Check()" OnClick="imgbtn_AddBrotherNode_Click"></asp:imagebutton></div>
                  </td>
                  <td  valign="middle" width="110"> 
                    <div><asp:imagebutton id="imgbtn_DelNode" runat="server" ImageUrl="images/imgbtn/imgbtn_DelNode.jpg" OnClick="imgbtn_DelNode_Click"></asp:imagebutton></div>
                  </td>
                  <td valign="middle"> <asp:imagebutton id="imgbtn_AddRootNode" runat="server" ImageUrl="images/imgbtn/imgbtn_AddRootNode.jpg"  OnClientClick="return Check()" OnClick="imgbtn_AddRootNode_Click"></asp:imagebutton>&nbsp;&nbsp; 
                  </td>
                  <td valign="middle"> <!--<a href="tree_info.aspx"><img src="images/link_Exit.gif" width="44" height="18" border="0"></a>--></td>
                </tr>
              </table>
            </td>
          </tr>
        </table>
        <br>
        &nbsp;&nbsp;<%=Request["depart"]%>
        <table cellspacing="0" bordercolordark="#ffffff" bordercolorlight="#3677b1" bgcolor="#ffffff" cellpadding="1" width="95%" border="1" align="center">
          <asp:repeater id="rpt_Graduate" runat="server"> <headertemplate> 
          <tr bgcolor="#ffdcb5"> 
            <th height="26" width="36"> 
              <table width="100%" border="0" cellspacing="0" cellpadding="0" height="100%">
                <tr> 
                  <td> 
                    <div align="center"></div>
                  </td>
                </tr>
              </table>
            </th>
            <%if (Session["limit_code"]!=null){if (Session["limit_code"].ToString().IndexOf('H')!=-1 || Session["limit_code"].ToString().IndexOf('A')!=-1){%>
            <%}}%>
            <th height="26" width="504"> 
              <table width="100%" border="0" cellspacing="0" cellpadding="0" height="100%">
                <tr> 
                  <td> 
                    <div align="center"><font color="#FFFFFF">子 部 门</font></div>
                  </td>
                </tr>
              </table>
            </th>
            <th height="26" width="67"> 
              <table width="100%" border="0" cellspacing="0" cellpadding="0" height="100%">
                <tr> 
                  <td> 
                    <div align="center"><font color="#FFFFFF">上移</font></div>
                  </td>
                </tr>
              </table>
            </th>
            <th height="26" width="59"> 
              <table width="100%" border="0" cellspacing="0" cellpadding="0" height="100%">
                <tr> 
                  <td> 
                    <div align="center"><font color="#FFFFFF">下移</font></div>
                  </td>
                </tr>
              </table>
            </th>
            <th height="26" width="61"> 
              <table width="100%" border="0" cellspacing="0" cellpadding="0" height="100%">
                <tr> 
                  <td> 
                    <div align="center"><font color="#FFFFFF" class="table_head_font">修改</font></div>
                  </td>
                </tr>
              </table>
            </th>
          </tr>
          </headertemplate> <itemtemplate> 
          <tr> 
            <td width="36" align="center"> 
              <table width="100%" border="0" cellspacing="0" cellpadding="0" height="100%">
                <tr> 
                  <td> 
                    <div align="center"> 
                      <%# Container.ItemIndex+1%>
                      <asp:Label ID="lbl_Order_Id" Visible=False Text='<%# DataBinder.Eval(Container.DataItem,"order_id").ToString() %>' Runat=server/> 
                    </div>
                  </td>
                </tr>
              </table>
            </td>
            <td width="504" align="center"> 
              <table width="100%" border="0" cellspacing="0" cellpadding="0" height="100%">
                <tr> 
                  <td class="font_dropshadow"> 
                    <div align="center"> 
                      <%# DataBinder.Eval(Container.DataItem,"depart").ToString() %>
                    </div>
                  </td>
                </tr>
              </table>
            </td>
            <td align="center" width="67"> 
              <table width="100%" border="0" cellspacing="0" cellpadding="0" height="100%">
                <tr> 
                  <td class="font_dropshadow"> 
                    <div align="center"> 
					<span onclick="return CheckPopedom();">
                    <asp:HyperLink Text='上移' NavigateUrl='<%# "tree_operate_move.aspx?itemindex="+Container.ItemIndex+"&operate=top&location="+Request["autoid"].ToString()+"&nodeid="+DataBinder.Eval(Container.DataItem,"autoid").ToString() %>' runat="server" ID="Hyperlink5"/> 
		            </span>   
                    </div>
                  </td>
                </tr>
              </table>
            </td>
            <td align="center" width="59"> 
              <table width="100%" border="0" cellspacing="0" cellpadding="0" height="100%">
                <tr> 
                  <td class="font_dropshadow"> 
                    <div align="center"> 
					<span onclick="return CheckPopedom();">
                    <asp:HyperLink Text='下移' NavigateUrl='<%# "tree_operate_move.aspx?itemindex="+Container.ItemIndex+"&operate=down&location="+Request["autoid"].ToString()+"&nodeid="+DataBinder.Eval(Container.DataItem,"autoid").ToString() %>' runat="server" ID="Hyperlink6"/> 
					</span>
                    </div>
                  </td>
                </tr>
              </table>
            </td>
            <td width="61"> 
              <table width="100%" border="0" cellspacing="0" cellpadding="0" height="100%">
                <tr> 
                  <td class="font_dropshadow"> 
                    <div align="center"> 
					<span onclick="return CheckPopedom();">
                    <asp:HyperLink Text='修改' NavigateUrl='<%# "tree_Operate_edit.aspx?location="+Request["autoid"].ToString()+"&nodeid="+DataBinder.Eval(Container.DataItem,"autoid").ToString() %>' runat="server" ID="Hyperlink7"/> 
					</span>
                    </div>
                  </td>
                </tr>
              </table>
            </td>
          </tr>
          </itemtemplate> </asp:repeater> 
        </table>
        <br>
        <font size="2"></font> </TD>
    </TR>
  </TABLE>
  </FONT> <br>
  <br>
  <asp:label id="lbl_Curnodeid" EnableViewState="True" Visible="False" Runat="server"></asp:label><asp:label id="lbl_Error" EnableViewState="False" Visible="True" Runat="server"></asp:label> 
</form>
	</body>
</html>

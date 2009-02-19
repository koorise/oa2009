<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MakeCardFor.aspx.cs" Inherits="OAWeb.MakeCardFor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <script type="text/javascript" language="javascript">
        function a()
        {   
            form1.User1.Initialize('<%=Session["AreaCode"].ToString()%>','<%=Session["AgentID"].ToString()%>');   //初始化控件
        }
    </script>  
</head>
<body onload="a()">
    <form id="form1" runat="server">
    <div style="text-align:center">
 <OBJECT id=User1 classid=clsid:95505046-DB6B-4737-B0CA-6DD264B30FC6  codebase="jsy.cab#version=3,1,0,0" VIEWASTEXT>
                    <br />
                    <br />
					<table cellspacing="0" cellpadding="5" width="580" border="0">
						<tr>
							<td style="background-color:<%=Application[Session["Style"].ToString()+"xtable_bgcolor"]%>">
								<table cellspacing=0 borderColorDark='<%=Application[Session["Style"].ToString()+"xtable_bordercolordark"]%>' 
                                    cellPadding=5 width="100%" 
                                    borderColorLight='<%=Application[Session["Style"].ToString()+"xtable_bordercolorlight"]%>' 
                                    border=1>
				                    <tr>
					                    <td>
					                    <span style="font-size:14px">
                                            OCX控件没有安装,请先安装OCX控件,要安装OCX控件,请先把你的浏览器安全级别设置为底级，即允许或提示下载和运行未签名的ActiveX插件。
                                            具体设置为:点击浏览器的工具菜单下的internet选项，选择安全-》默认级别-》底级,设置好浏览器安全级别后，如果你的机器装有上网助手
                                            之类的安全防护软件，请关闭即时保护IE的功能。如果经过如上设置控件都不能正常使用，请点击这里<a style="CURSOR: hand" href="JSYOCX.EXE" target='_blank'><font color=Blue>“控件下载”</font></a>
                                            下载到你的机子后运行下载的执行文件进行手工安装控件。
                                         </span>
					                    </td>
				                    </tr>								
								</table>
							</td>
						</tr>
					</table>
 <PARAM NAME="Visible" VALUE="0"><PARAM NAME="AutoScroll" VALUE="0"><PARAM NAME="AutoSize" VALUE="0"><PARAM NAME="AxBorderStyle" VALUE="1"><PARAM NAME="Caption" VALUE="User"><PARAM NAME="Color" VALUE="4278190095"><PARAM NAME="Font" VALUE="宋体"><PARAM NAME="KeyPreview" VALUE="0"><PARAM NAME="PixelsPerInch" VALUE="96"><PARAM NAME="PrintScale" VALUE="1"><PARAM NAME="Scaled" VALUE="-1"><PARAM NAME="DropTarget" VALUE="0"><PARAM NAME="HelpFile" VALUE=""><PARAM NAME="ScreenSnap" VALUE="0"><PARAM NAME="SnapBuffer" VALUE="10"><PARAM NAME="DoubleBuffered" VALUE="0"><PARAM NAME="Enabled" VALUE="-1"></OBJECT>
   
    </div>
    </form>
</body>
</html>

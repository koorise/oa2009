<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MakeCardFor.aspx.cs" Inherits="OAWeb.MakeCardFor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>�ޱ���ҳ</title>
    <script type="text/javascript" language="javascript">
        function a()
        {   
            form1.User1.Initialize('<%=Session["AreaCode"].ToString()%>','<%=Session["AgentID"].ToString()%>');   //��ʼ���ؼ�
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
                                            OCX�ؼ�û�а�װ,���Ȱ�װOCX�ؼ�,Ҫ��װOCX�ؼ�,���Ȱ�����������ȫ��������Ϊ�׼������������ʾ���غ�����δǩ����ActiveX�����
                                            ��������Ϊ:���������Ĺ��߲˵��µ�internetѡ�ѡ��ȫ-��Ĭ�ϼ���-���׼�,���ú��������ȫ����������Ļ���װ����������
                                            ֮��İ�ȫ�����������رռ�ʱ����IE�Ĺ��ܡ���������������ÿؼ�����������ʹ�ã���������<a style="CURSOR: hand" href="JSYOCX.EXE" target='_blank'><font color=Blue>���ؼ����ء�</font></a>
                                            ���ص���Ļ��Ӻ��������ص�ִ���ļ������ֹ���װ�ؼ���
                                         </span>
					                    </td>
				                    </tr>								
								</table>
							</td>
						</tr>
					</table>
 <PARAM NAME="Visible" VALUE="0"><PARAM NAME="AutoScroll" VALUE="0"><PARAM NAME="AutoSize" VALUE="0"><PARAM NAME="AxBorderStyle" VALUE="1"><PARAM NAME="Caption" VALUE="User"><PARAM NAME="Color" VALUE="4278190095"><PARAM NAME="Font" VALUE="����"><PARAM NAME="KeyPreview" VALUE="0"><PARAM NAME="PixelsPerInch" VALUE="96"><PARAM NAME="PrintScale" VALUE="1"><PARAM NAME="Scaled" VALUE="-1"><PARAM NAME="DropTarget" VALUE="0"><PARAM NAME="HelpFile" VALUE=""><PARAM NAME="ScreenSnap" VALUE="0"><PARAM NAME="SnapBuffer" VALUE="10"><PARAM NAME="DoubleBuffered" VALUE="0"><PARAM NAME="Enabled" VALUE="-1"></OBJECT>
   
    </div>
    </form>
</body>
</html>

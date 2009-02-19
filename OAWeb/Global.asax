<%@ Application Language="C#" %>

<script runat="server">
    void Application_Start(object sender, EventArgs e) 
    {
        // 在应用程序启动时运行的代码
        #region 默认蓝


        Application["1xtop1_bgimage"] = "images/top-1.gif"; //顶框背景图片
        Application["1xtop2_bgimage"] = "images/top-2.gif"; //顶框背景图片
        Application["1xtop3_bgimage"] = "images/top-3.gif"; //顶框背景图片
        Application["1xtop4_bgimage"] = "images/top-4.gif"; //顶框背景图片
        Application["1xtop5_bgimage"] = "images/top-5.gif"; //顶框背景图片
        Application["1xtopbj_bgimage"] = "images/top-bj.gif"; //顶框背景图片



        Application["1xtopbar_bgimage"] = "images/topbar_01.jpg"; //顶框工具条背景图片
        Application["1xfirstpage_bgimage"] = "images/dbsx_01.gif"; //首页背景图片
        Application["1xforumcolor"] = "#f0f4fb";
        Application["1xleft_width"] = "217"; //左框架宽度


        Application["1xtree_bgcolor"] = "#e3eeff"; //左框架树背景色
        Application["1xleft1_bgimage"] = "images/left-1.gif";
        Application["1xleft2_bgimage"] = "images/left-2.gif";
        Application["1xleft3_bgimage"] = "images/left-3.gif";
        Application["1xleftbj_bgimage"] = "images/left-bj.gif";


        Application["1xspliter_color"] = "#6B7DDE"; //分隔块色


        Application["1xdesktop_bj"] = "images/right-bj.gif";
        Application["1xdesktop_bgimage"] = "images/right.gif";

        //			Application["1xtable_bgcolor"]="#F7F7F7"; //最外层表格背景
        //			Application["1xtable_bordercolorlight"]="#7B9EBD"; //中层表格亮边框
        //			Application["1xtable_bordercolordark"]="#E4E4E4"; //中层表格暗边框
        //			Application["1xtable_titlebgcolor"]="#F1F1ED"; //中层表格标题栏

        Application["1xtable_bgcolor"] = "#F5F9FF"; //最外层表格背景
        Application["1xtable_bordercolorlight"] = "#4F7FC9"; //中层表格亮边框
        Application["1xtable_bordercolordark"] = "#D3D8E0"; //中层表格暗边框
        Application["1xtable_titlebgcolor"] = "#E3EFFF"; //中层表格标题栏


        Application["1xform_requestcolor"] = "#E78A29"; //表单中必填字段*颜色

        Application["1xfirstpage_topimage"] = "images/top_01.gif";
        Application["1xfirstpage_bottomimage"] = "images/bottom_01.gif";
        Application["1xfirstpage_middleimage"] = "images/b01.gif";

        Application["1xabout_bgimage"] = "images/about_01.gif"; //关于我们背景图片

        #endregion

        #region 绿色


        Application["2xtop1_bgimage"] = "images/top-1-2.gif"; //顶框背景图片
        Application["2xtop2_bgimage"] = "images/top-2-2.gif"; //顶框背景图片
        Application["2xtop3_bgimage"] = "images/top-3-2.gif"; //顶框背景图片
        Application["2xtop4_bgimage"] = "images/top-4-2.gif"; //顶框背景图片
        Application["2xtop5_bgimage"] = "images/top-5-2.gif"; //顶框背景图片
        Application["2xtopbj_bgimage"] = "images/top-bj-2.gif"; //顶框背景图片

        Application["2xtopbar_bgimage"] = "images/topbar_01.jpg"; //顶框工具条背景图片
        Application["2xfirstpage_bgimage"] = "images/dbsx_01.gif"; //首页背景图片
        Application["2xforumcolor"] = "#f0f4fb";
        Application["2xleft_width"] = "204"; //左框架宽度


        Application["2xtree_bgcolor"] = "#e3ffe9"; //左框架树背景色			
        Application["2xleft1_bgimage"] = "images/left-1-2.gif";
        Application["2xleft2_bgimage"] = "images/left-2-2.gif";
        Application["2xleft3_bgimage"] = "images/left-3-2.gif";
        Application["2xleftbj_bgimage"] = "images/left-bj-2.gif";

        Application["2xspliter_color"] = "#51C94F"; //分隔块色


        Application["2xdesktop_bj"] = "images/right-bj-2.gif";
        Application["2xdesktop_bgimage"] = "images/right-2.gif";


        Application["2xtable_bgcolor"] = "#F5FFF5"; //最外层表格背景
        Application["2xtable_bordercolorlight"] = "#7DBD7B"; //中层表格亮边框
        Application["2xtable_bordercolordark"] = "#D3E0D3"; //中层表格暗边框
        Application["2xtable_titlebgcolor"] = "#E4FFE3"; //中层表格标题栏


        Application["2xform_requestcolor"] = "#E78A29"; //表单中必填字段*颜色

        Application["2xfirstpage_topimage"] = "images/top_01.gif";
        Application["2xfirstpage_bottomimage"] = "images/bottom_01.gif";
        Application["2xfirstpage_middleimage"] = "images/b01.gif";



        #endregion

        #region 红色

        Application["3xtop1_bgimage"] = "images/top-1-1.gif"; //顶框背景图片
        Application["3xtop2_bgimage"] = "images/top-2-1.gif"; //顶框背景图片
        Application["3xtop3_bgimage"] = "images/top-3-1.gif"; //顶框背景图片
        Application["3xtop4_bgimage"] = "images/top-4-1.gif"; //顶框背景图片
        Application["3xtop5_bgimage"] = "images/top-5-1.gif"; //顶框背景图片
        Application["3xtopbj_bgimage"] = "images/top-bj-1.gif"; //顶框背景图片

        Application["3xtopbar_bgimage"] = "images/topbar_01.jpg"; //顶框工具条背景图片
        Application["3xfirstpage_bgimage"] = "images/dbsx_01.gif"; //首页背景图片
        Application["3xforumcolor"] = "#f0f4fb";
        Application["3xleft_width"] = "204"; //左框架宽度


        Application["3xtree_bgcolor"] = "#ffe3e5"; //左框架树背景色			
        Application["3xleft1_bgimage"] = "images/left-1-1.gif";
        Application["3xleft2_bgimage"] = "images/left-2-1.gif";
        Application["3xleft3_bgimage"] = "images/left-3-1.gif";
        Application["3xleftbj_bgimage"] = "images/left-bj-1.gif";

        Application["3xspliter_color"] = "#C94F4F"; //分隔块色


        Application["3xdesktop_bj"] = "images/right-bj-1.gif";
        Application["3xdesktop_bgimage"] = "images/right-1.gif";


        Application["3xtable_bgcolor"] = "#FFF5F5"; //最外层表格背景
        Application["3xtable_bordercolorlight"] = "#BD7B7B"; //中层表格亮边框
        Application["3xtable_bordercolordark"] = "#E1D3D3"; //中层表格暗边框
        Application["3xtable_titlebgcolor"] = "#FFE3E3"; //中层表格标题栏


        Application["3xform_requestcolor"] = "#E78A29"; //表单中必填字段*颜色

        Application["3xfirstpage_topimage"] = "images/top_01.gif";
        Application["3xfirstpage_bottomimage"] = "images/bottom_01.gif";
        Application["3xfirstpage_middleimage"] = "images/b01.gif";



        #endregion

        #region 深绿色


        Application["4xtop1_bgimage"] = "images/top-1-3.gif"; //顶框背景图片
        Application["4xtop2_bgimage"] = "images/top-2-3.gif"; //顶框背景图片
        Application["4xtop3_bgimage"] = "images/top-3-3.gif"; //顶框背景图片
        Application["4xtop4_bgimage"] = "images/top-4-3.gif"; //顶框背景图片
        Application["4xtop5_bgimage"] = "images/top-5-3.gif"; //顶框背景图片
        Application["4xtopbj_bgimage"] = "images/top-bj-3.gif"; //顶框背景图片

        Application["4xtopbar_bgimage"] = "images/topbar_01.jpg"; //顶框工具条背景图片
        Application["4xfirstpage_bgimage"] = "images/dbsx_01.gif"; //首页背景图片
        Application["4xforumcolor"] = "#f0f4fb";
        Application["4xleft_width"] = "204"; //左框架宽度


        Application["4xtree_bgcolor"] = "#e3ffe9"; //左框架树背景色			
        Application["4xleft1_bgimage"] = "images/left-1-3.gif";
        Application["4xleft2_bgimage"] = "images/left-2-3.gif";
        Application["4xleft3_bgimage"] = "images/left-3-3.gif";
        Application["4xleftbj_bgimage"] = "images/left-bj-3.gif";

        Application["4xspliter_color"] = "#51C94F"; //分隔块色


        Application["4xdesktop_bj"] = "images/right-bj-3.gif";
        Application["4xdesktop_bgimage"] = "images/right-3.gif";


        Application["4xtable_bgcolor"] = "#F5FFF5"; //最外层表格背景
        Application["4xtable_bordercolorlight"] = "#7DBD7B"; //中层表格亮边框
        Application["4xtable_bordercolordark"] = "#D3E0D3"; //中层表格暗边框
        Application["4xtable_titlebgcolor"] = "#E4FFE3"; //中层表格标题栏


        Application["4xform_requestcolor"] = "#E78A29"; //表单中必填字段*颜色

        Application["4xfirstpage_topimage"] = "images/top_01.gif";
        Application["4xfirstpage_bottomimage"] = "images/bottom_01.gif";
        Application["4xfirstpage_middleimage"] = "images/b01.gif";



        #endregion	

    }
    /**/
    /// <summary>
    /// 当有数据时交时，触发事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Application_BeginRequest(Object sender, EventArgs e)
    {
        //遍历Post参数，隐藏域除外
        foreach (string i in this.Request.Form)
        {
            if (i == "__VIEWSTATE") continue;
            this.goErr(this.Request.Form.ToString());
        }
        //遍历Get参数。
        foreach (string i in this.Request.QueryString)
        {
            this.goErr(this.Request.QueryString.ToString());
        }
    }
    /**/
    /// <summary>
    /// 校验参数是否存在SQL字符
    /// </summary>
    /// <param name="tm"></param>
    private void goErr(string tm)
    {
        if (OAWeb.Common.SqlFilter2(tm))
        {
            Response.Redirect("SQLImmit.htm");
        }
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  在应用程序关闭时运行的代码

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // 在出现未处理的错误时运行的代码
        //#region
        //Exception ex = Server.GetLastError();
        //string errmsg = "";
        //string Particular = "";
        ///*
        //if(ex.InnerException!=null)
        //{
        //    errmsg=ex.InnerException.Message;
        //    Particular=ex.InnerException.StackTrace;					
        //}
        //else
        //{
        //    errmsg=ex.Message;
        //    Particular=ex.StackTrace;
        //}*/
        //errmsg = ex.Message;
        //Particular = ex.StackTrace;
        ////写进日记文件
        //string filename = Server.MapPath("ErrorMessage.txt");
        //string strTime = DateTime.Now.ToString();
        //System.IO.StreamWriter sw = new System.IO.StreamWriter(filename, true);
        //sw.WriteLine(strTime + "：" + errmsg + Particular);
        //sw.Close();
        //Server.Transfer("ShowMessage.aspx?PreviousPage=Back");
        //#endregion        

        

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // 在新会话启动时运行的代码

    }

    void Session_End(object sender, EventArgs e) 
    {
        // 在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
        // 或 SQLServer，则不会引发该事件。

    }
       
</script>

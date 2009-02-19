//=====================.net客户段验证2.01修正版===========================
//    
//    
//                '''
//               (0 0)
//   +-----oOO----(_)------------+
//   |                           |
//   |   作者:高处不胜寒         |
//   |   QQ:28767360             |
//   |                           |
//   +------------------oOO------+
//              |__|__|
//               || ||
//              ooO Ooo   
//===========================================================

function fob(n, d)
{
   var p,i,x;if(!d) d=document;
   if((p=n.indexOf("?"))>0&&parent.frames.length) 
   {
       d=parent.frames[n.substring(p+1)].document;
       n=n.substring(0,p);
   }
   if(!(x=d[n])&&d.all) 
   x=d.all[n];
   for (i=0;!x&&i<d.forms.length;i++) 
   x=d.forms[i][n];
   for(i=0;!x&&d.layers&&i<d.layers.length;i++) 
   x=fob(n,d.layers[i].document); 
   return x;
} 	   

function cb()
{
   var a=cb.arguments;
   var name=fob(a[0]);
   e=document.forms(0).elements;
   if (name.checked==true)
   {
      for (i=0;i<e.length;i++)
      {
         e[i].checked=true;
      }
   }
   else
   {
      for (i=0;i<e.length;i++)
      {
         e[i].checked=false;
      }
   }
}

function vdf() 
{
   var i,j,name,value,message,length,type,a=vdf.arguments,cb_name;
   for (i=0; i<(a.length-2); i+=3) 
   {
       if (a[i].indexOf('#')!=-1)
       {
           name=fob(a[i].substr(0,a[i].indexOf('#')));
           cb_name=fob(a[i].substr((a[i].indexOf('#')+1),a[i].length));
       }
       else
       {
          name=fob(a[i]); // 控件名称
       }
       message=a[i+1]; // 提示信息
       type=a[i+2]; // 类型
       if (type!="r_time")
       {
          value=name.value.replace(/ +/g, ""); // 控件值
       }
       else
       {
          value=name.value;
       }
   
       if (name) 
       {
          
       // ===============判断复选框是否选中================ //
          if (type=="r_cb")
          {      
             e=document.forms(0).elements;
             var flag=false;
             for (i=0;i<e.length;i++)
             { 
                if (e[i]!=cb_name)
                {
                   if (e[i].checked==true)
                   {
                       flag=true;
                       break;
                   }
                }
                if (i==e.length-1)
                {
                    break;
                }
             }
             if (flag==false)
             {
                alert(message+"!\n"); //为空时出现的提示
                return false;
             }
          }
          
          // ===============判断下拉框是否选择================ //
          if (type=="r_sl")
          {
            if (name.selected==false)
            {
                 alert(message+"!\n"); //为空时出现的提示
                 return false;
            }
          }
          
          // ===============不能为空的判断================ //
          if (type=="r") 
          {
             if (value=="") // 判断是否为空
             {
                 alert(message+"!\n"); //为空时出现的提示
                 name.focus();
                 name.select();
                 return false;
             }
          }
          
          // ===============不能为空的判断,但不获得焦点================ //
          if (type=="o_r") 
          {
             if (value=="") // 判断是否为空
             {
                 alert(message+"!\n"); //为空时出现的提示
                 return false;
             }
          }
         // ===============只能输入中文================ //
         if (type=="r_china")
         {
             if (value.search(/^[\u4e00-\u9fa5]+$/)==-1) 
             {
                  alert(message+"!\n"); // 判断不能为空
                  name.focus();
                  name.select();
                  return false;
             }
         }
         
         // ===============只能输入数字或者字母================ //
         if (type=="r_num_char")
         {
             if (value=="")
             {
                  alert(message+"!\n"); //为空时出现的提示
                 name.focus();
                 name.select();
                 return false;
             }
             if (value.search(/^[0-9a-zA-Z]+$/)==-1) 
             {
                  alert(message+"!\n"); //为空时出现的提示
                 name.focus();
                 name.select();
                 return false;
             }
          }
          
          // ===============可以为空，不为空时，填数字================ //
         if (type=="num")
         {
             if (value.search(/^[0-9]+$/)==-1 && value!="") 
             {
                  alert(message+"!\n"); // 判断不能为空
                  name.focus();
                  name.select();
                  return false;
             }
         }
         
         // ===============只能输入数字================ //
         if (type=="r_num")
         {
             if (value=="")
             {
                  alert(message+"!\n");
                  name.focus();
                 name.select();
                  return false;
             }
             if (value.search(/^[0-9]+$/)==-1) 
             {
                  alert(message+"!\n"); // 判断不能为空
                  name.focus();
                 name.select();
                  return false;
             }
          }
          
          // ===============只能输入小于等于n位长度数字================ //
          if (type.indexOf("r_num<")!=-1)
          {
              length=type.substring((type.indexOf('<')+1),type.length); // 获得rn<后面的数 
   
              if (value=="") // 为空做的提示
              {
                  alert(message+"!\n");
                  name.focus();
                  name.select();
                  return false;
              }
              if (value.search(/^[0-9]+$/)==-1)  // 不是数字做的提示
              {
                  alert(message+"!\n");
                  name.focus();
                  name.select();
                  return false;
              }
              if (value.length>length)  // 限制数字长度做的限制
              {
                 alert(message+"!\n");
                 name.focus();
                 name.select();
                 return false;
              }
          }
          
          // ===============只能输入大于等于n位长度数字================ //
          if (type.indexOf("r_num>")!=-1)
          {
	         length=type.substring((type.indexOf('>')+1),type.length); // 获得rn>后面的数 
   
              if (value=="") // 为空做的提示
              {
                  alert(message+"!\n");
                  name.focus();
                  name.select();
                  return false;
              }
              if (value.search(/^[0-9]+$/)==-1)  // 不是数字做的提示
              {
                  alert(message+"!\n");
                  name.focus();
                  name.select();
                  return false;
              }
              if (value.length<length)  // 限制数字长度做的限制
              {
                 alert(message+"!\n");
                 name.focus();
                 name.select();
                 return false;
              }
          }
          
          // ===============必须输入a-b位之间的数字================ //		  
	      if (type.indexOf("r_num#<>")!=-1)
	      {
              length=type.substr((type.indexOf('>')+1),type.length);
              length=length.substr(0,length.lastIndexOf("-"));
	          length1=type.substring((type.indexOf('-')+1),type.length) // 获得rn<后面的数
	          
              if (value=="") // 为空做的提示
	          {
		         alert(message+"!\n");
		         name.focus();
				 name.select();
				 return false;
			  }
			  if (value.search(/^[0-9]+$/)==-1) // 不是数字做的提示
			  {
				 alert(message+"!\n");
				 name.focus();
				 name.select();
				 return false;
			  }
			  
			  if (value.length<length || value.length>length1)  // 限制数字长度做的限制
			  {
				 alert(message+"!\n");
				 name.focus();
				 name.select();
				 return false;
			  }
		  }
		  
		  // ===============判断email,不一定输入================ //	
	      if (type.indexOf("email")!=-1)
	      {
	         if (name.value!="")
	         {
	             if (value.search(/^[_\.a-z0-9]+@[a-z0-9]+[\.][a-z0-9]{2,}$/i)==-1)
		         {
		             alert(message+"!\n");
     	    	     name.focus();
		             name.select();
		             return false;
		         }
	          }
	       }

	       // ===============判断email,一定输入================ //
			if (type.indexOf("r_email")!=-1)
			{
				if (name.value=="")
				{
				alert(message+"!\n");
				name.focus();
				name.select();
				return false;
				}
				if (value.search(/^[_\.a-z0-9]+@[a-z0-9]+[\.][a-z0-9]{2,}$/i)==-1)
				{
				alert(message+"!\n");
     	    			name.focus();
				name.select();
				return false;
				}
			}
	  
	   // ===============判断日期,比如2000-12-20================ //
          if (type=="r_date")
          {
              flag=true; 
              getdate=value;         
              if (getdate.search(/^[0-9]{4}-(0[1-9]|[1-9]|1[0-2])-((0[1-9]|[1-9])|1[0-9]|2[0-9]|3[0-1])$/)==-1) // 判断输入格式时候正确
              {
                   flag=false;
               }
               else
               {
                    var year=getdate.substr(0,getdate.indexOf('-'))  // 获得年
                    // 下面操作获得月份
					var transition_month=getdate.substr(0,getdate.lastIndexOf('-')); 
					var month=transition_month.substr(transition_month.lastIndexOf('-')+1,transition_month.length);
					if (month.indexOf('0')==0)
					{
					month=month.substr(1,month.length);
					}
					// 下面操作获得日期
					var day=getdate.substr(getdate.lastIndexOf('-')+1,getdate.length);
					if (day.indexOf('0')==0)
					{
					day=day.substr(1,day.length);
					}
					//alert(month);
					//alert(day)
					//return false;
                    if ((month==4 || month==6 || month==9 || month==11) && (day>30)) // 4,6,9,11月份日期不能超过30
                    {
                    flag=false; 
                     }
					if (month==2)  // 判断2月份
					{
						if (LeapYear(year))
						{
							if (day>29 || day<1){ flag=false; }
						}
						else
						{
							if (day>28 || day<1){flag=false; }
						}
					}
					else
					{
					flag=true;
					}
			   }
          if (flag==false)
          {
              alert(message+"!\n"); //为空时出现的提示
              name.focus();
              name.select();
              return false;
          }
        }
        
        
        // ===============判断日期,比如2000-12-20================ //
          if (type=="r_time")
          {
              flag=true; 
              getdate=value;
              if (getdate.search(/^[0-9]{4}-(0[1-9]|[1-9]|1[0-2])-((0[1-9]|[1-9])|1[0-9]|2[0-9]|3[0-1]) ((0[1-9]|[1-9])|1[0-9]|2[0-4]):((0[1-9]|[1-9])|[1-5][0-9]):((0[1-9]|[1-9])|[1-5][0-9])$/)==-1) // 判断输入格式时候正确
              {
                   flag=false;
               }
               else
               {
                    var year=getdate.substr(0,getdate.indexOf('-'))  // 获得年
                    // 下面操作获得月份
					var transition_month=getdate.substr(0,getdate.lastIndexOf('-')); 
					var month=transition_month.substr(transition_month.lastIndexOf('-')+1,transition_month.length);
					if (month.indexOf('0')==0)
					{
					month=month.substr(1,month.length);
					}
					// 下面操作获得日期
					var day=getdate.substr(getdate.lastIndexOf('-')+1,getdate.length);
					if (day.indexOf('0')==0)
					{
					day=day.substr(1,day.length);
					}
                    if ((month==4 || month==6 || month==9 || month==11) && (day>30)) // 4,6,9,11月份日期不能超过30
                    { 
                        flag=false; 
                     }
					if (month==2)  // 判断2月份
					{
						if (LeapYear(year))
						{
							if (day>29 || day<1){ flag=false; }
						}
						else
						{
							if (day>28 || day<1){flag=false; }
						}
					}
					else
					{
					flag=true;
					}
			   }
          if (flag==false)
          {
              alert(message+"!\n"); //为空时出现的提示
              name.focus();
              name.select();
              return false;
          }
        }
        //判断是否闰年
//参数		intYear 代表年份的值
//return	true: 是闰年	false: 不是闰年
function LeapYear(intYear) {
	if (intYear % 100 == 0) 
	{
		if (intYear % 400 == 0) { return true; }
	}
	else {
		if ((intYear % 4) == 0) { return true; }
	}
	return false;
}

      // ===============判断电话，可以为空================ //
	  if (type.indexOf("tel")!=-1)
	  {
	     if (name.value!="")
	     {
                 if (value.search(/^(\([0-9]{3}\)|[0-9]{3}-)[0-9]{8}$/)==-1 && value.search(/^(\([0-9]{4}\)|[0-9]{4}-)[0-9]{7}$/)==-1)
		 {
		    alert(message+"!\n");
     	    	    name.focus();
		    name.select();
		    return false;
		  }
	     }
	  }
	  
	  // ===============判断电话，不能为空================ //
	  if (type.indexOf("r_tel")!=-1)
	  {
	     if (name.value=="")
	     {
		    alert(message+"!\n");
		    name.focus();
		    name.select();
		    return false;
	     }
	     if (value.search(/^(\([0-9]{3}\)|[0-9]{3}-)[0-9]{8}$/)==-1 && value.search(/^(\([0-9]{4}\)|[0-9]{4}-)[0-9]{7}$/)==-1)
	     {
	        alert(message+"!\n");
     	    name.focus();
		    name.select();
		    return false;
	     }
	  }
	  
	  // ===============判断手机，可以为空================ //
	  if (type.indexOf("mod")!=-1)
	  {
	     if (name.value!="")
	     {
                if (value.search(/^[0-9]{11}$/)==-1)
		{
		   alert(message+"!\n");
     	    	   name.focus();
		   name.select();
		   return false;
		}
	     }
	   }
	   
	   // ===============判断手机，不能为空================ //
	   if (type.indexOf("r_mod")!=-1)
	   {
	      if (name.value=="")
	      {
		  alert(message+"!\n");
		  name.focus();
		  name.select();
		  return false;
	       }
	      if (value.search(/^[0-9]{11}$/)==-1)
	      {
		 alert(message+"!\n");
     	    	 name.focus();
		 name.select();
		 return false;
	       }
	   }
	   
	   // ===============判断街道================ //
	   if (type.indexOf("city")!=-1)
	   {
	      if (name.value!="")
	      {
            	 if (value.search(/^.{1,}(市|镇|乡).{1,}(路|街|道).{1,}号.{0,}$/)==-1)
		 {
		     alert(message+"!\n");
     	    	     name.focus();
		     name.select();
		     return false;
		  }
	       }
	   }
	   
	   // ===============判断街道，不能为空================ //
	   if (type.indexOf("r_city")!=-1)
	   {

	       if (name.value=="")
	       {
		  alert(message+"!\n");
		  name.focus();
		  name.select();
		  return false;
	       }

	       if (value.search(/^.{1,}(市|镇|乡).{1,}(路|街|道).{1,}号.{0,}$/)==-1)
	       {
		  alert(message+"!\n");
     	    	  name.focus();
		  name.select();
		  return false;
	       }
	   }
        }
    }
}




// 下面是弹出无边窗口

minimizebar="js/images/minimize.gif";
minimizebar2="js/images/minimize.gif";
closebar="js/images/close.gif"; 
closebar2="js/images/close.gif";
icon="js/images/ie.gif";

function noBorderWin(fileName,w,h,titleBg,moveBg,titleColor,titleWord,scr)
{
  var contents="<html>"+
               "<head>"+
         "<title>"+titleWord+"</title>"+
      "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=gb2312\">"+
      "<object id=hhctrl type='application/x-oleobject' classid='clsid:adb880a6-d8ff-11cf-9377-00aa003b7a11'><param name='Command' value='minimize'></object>"+
      "</head>"+
               "<body topmargin=0 leftmargin=0 scroll=no onselectstart='return false' ondragstart='return false'>"+
      "  <table height=100% width=100% cellpadding=0 cellspacing=1 bgcolor="+titleBg+" id=mainTab>"+
      "    <tr height=18 style=cursor:default; onmousedown='x=event.x;y=event.y;setCapture();mainTab.bgColor=\""+moveBg+"\";' onmouseup='releaseCapture();mainTab.bgColor=\""+titleBg+"\";' onmousemove='if(event.button==1)self.moveTo(screenLeft+event.x-x,screenTop+event.y-y);'>"+
      "      <td width=22 align=center><img  border=0 src="+icon+">&nbsp;</td>"+
      "      <td width="+w+"><span style=font-size:12px;color:"+titleColor+";font-family:宋体;font-weight:bold;position:relative;top:1px;>"+titleWord+"</span></td>"+
      "      <td width=14><img border=0  src="+minimizebar+" onmousedown=hhctrl.Click(); onmouseover=this.src='"+minimizebar2+"' onmouseout=this.src='"+minimizebar+"'></td>"+
      "      <td width=14><img border=0  src="+closebar+" onmousedown=self.close(); onmouseover=this.src='"+closebar+"' onmouseout=this.src='"+closebar+"'></td>"+
 
     
      "    </tr>"+
      "    <tr height=*>"+
      "      <td colspan=4>"+
      "        <iframe name=nbw_v6_iframe src="+fileName+" scrolling="+scr+" width=100% height=100% frameborder=0></iframe>"+
      "      </td>"+
      "    </tr>"+
      "  </table>"+
      "</body>"+
      "</html>";

  pop=window.open("","_blank","fullscreen=yes");
  pop.resizeTo(w,h);
  pop.moveTo((screen.width-w)/2,(screen.height-h)/2);
  pop.document.writeln(contents);

  if(pop.document.body.clientWidth!=w||pop.document.body.clientHeight!=h)
  {
    temp=window.open("","nbw_v6");
 temp.close();
 window.showModalDialog("about:<"+"script language=javascript>window.open('','nbw_v6','fullscreen=yes');window.close();"+"</"+"script>","","dialogWidth:0px;dialogHeight:0px");
 pop2=window.open("","nbw_v6");
    pop2.resizeTo(w,h);
    pop2.moveTo((screen.width-w)/2,(screen.height-h)/2);
    pop2.document.writeln(contents);
 pop.close();
  }
}



// 下面是日期控件

var weekend = [0,6];
var weekendColor = "#F4F7EA";
var fontface = "Verdana";
var fontsize = 2;

var gNow = new Date();
var ggWinCal;
isNav = (navigator.appName.indexOf("Netscape") != -1) ? true : false;
isIE = (navigator.appName.indexOf("Microsoft") != -1) ? true : false;

Calendar.Months = ["January", "February", "March", "April", "May", "June",
"July", "August", "September", "October", "November", "December"];

// Non-Leap year Month days..
Calendar.DOMonth = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
// Leap year Month days..
Calendar.lDOMonth = [31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

function Calendar(p_item, p_WinCal, p_month, p_year, p_format) {
	if ((p_month == null) && (p_year == null))	return;

	if (p_WinCal == null)
		this.gWinCal = ggWinCal;
	else
		this.gWinCal = p_WinCal;
	
	if (p_month == null) {
		this.gMonthName = null;
		this.gMonth = null;
		this.gYearly = true;
	} else {
		this.gMonthName = Calendar.get_month(p_month);
		this.gMonth = new Number(p_month);
		this.gYearly = false;
	}

	this.gYear = p_year;
	this.gFormat = p_format;
	this.gBGColor = "white";
	this.gFGColor = "black";
	this.gTextColor = "black";
	this.gHeaderColor = "black";
	this.gReturnItem = p_item;
}

Calendar.get_month = Calendar_get_month;
Calendar.get_daysofmonth = Calendar_get_daysofmonth;
Calendar.calc_month_year = Calendar_calc_month_year;
Calendar.print = Calendar_print;

function Calendar_get_month(monthNo) {
	return Calendar.Months[monthNo];
}

function Calendar_get_daysofmonth(monthNo, p_year) {
	/* 
	Check for leap year ..
	1.Years evenly divisible by four are normally leap years, except for... 
	2.Years also evenly divisible by 100 are not leap years, except for... 
	3.Years also evenly divisible by 400 are leap years. 
	*/
	if ((p_year % 4) == 0) {
		if ((p_year % 100) == 0 && (p_year % 400) != 0)
			return Calendar.DOMonth[monthNo];
	
		return Calendar.lDOMonth[monthNo];
	} else
		return Calendar.DOMonth[monthNo];
}

function Calendar_calc_month_year(p_Month, p_Year, incr) {
	/* 
	Will return an 1-D array with 1st element being the calculated month 
	and second being the calculated year 
	after applying the month increment/decrement as specified by 'incr' parameter.
	'incr' will normally have 1/-1 to navigate thru the months.
	*/
	var ret_arr = new Array();
	
	if (incr == -1) {
		// B A C K W A R D
		if (p_Month == 0) {
			ret_arr[0] = 11;
			ret_arr[1] = parseInt(p_Year) - 1;
		}
		else {
			ret_arr[0] = parseInt(p_Month) - 1;
			ret_arr[1] = parseInt(p_Year);
		}
	} else if (incr == 1) {
		// F O R W A R D
		if (p_Month == 11) {
			ret_arr[0] = 0;
			ret_arr[1] = parseInt(p_Year) + 1;
		}
		else {
			ret_arr[0] = parseInt(p_Month) + 1;
			ret_arr[1] = parseInt(p_Year);
		}
	}
	
	return ret_arr;
}

function Calendar_print() {
	ggWinCal.print();
}

function Calendar_calc_month_year(p_Month, p_Year, incr) {
	/* 
	Will return an 1-D array with 1st element being the calculated month 
	and second being the calculated year 
	after applying the month increment/decrement as specified by 'incr' parameter.
	'incr' will normally have 1/-1 to navigate thru the months.
	*/
	var ret_arr = new Array();
	
	if (incr == -1) {
		// B A C K W A R D
		if (p_Month == 0) {
			ret_arr[0] = 11;
			ret_arr[1] = parseInt(p_Year) - 1;
		}
		else {
			ret_arr[0] = parseInt(p_Month) - 1;
			ret_arr[1] = parseInt(p_Year);
		}
	} else if (incr == 1) {
		// F O R W A R D
		if (p_Month == 11) {
			ret_arr[0] = 0;
			ret_arr[1] = parseInt(p_Year) + 1;
		}
		else {
			ret_arr[0] = parseInt(p_Month) + 1;
			ret_arr[1] = parseInt(p_Year);
		}
	}
	
	return ret_arr;
}

// This is for compatibility with Navigator 3, we have to create and discard one object before the prototype object exists.
new Calendar();

Calendar.prototype.getMonthlyCalendarCode = function() {
	var vCode = "";
	var vHeader_Code = "";
	var vData_Code = "";
	
	// Begin Table Drawing code here..
	vCode = vCode + "<table  width='100%' bordercolordark='#ffffff' bordercolorlight='#8EA525' bgcolor='#FAFCF1' border='1' cellspacing='0' cellpadding='0' >"
	
	vHeader_Code = this.cal_header();
	vData_Code = this.cal_data();
	vCode = vCode + vHeader_Code + vData_Code;
	
	vCode = vCode + "</TABLE>";
	
	return vCode;
}

Calendar.prototype.show = function() {
	var vCode = "";
	
	this.gWinCal.document.open();

	// Setup the page...
	this.wwrite("<html>");
	this.wwrite("<head><title>Calendar</title>");
	this.wwrite("</head>");
this.wwrite("<meta http-equiv='Content-Type' content='text/html; charset=gb2312'>");
this.wwrite("<style type='text/css'>");
this.wwrite(".table_dropshadow{FILTER:dropshadow(color=#EDEDF8,offx=3.3,offy=3.3,positive=1);}");
this.wwrite(".font_dropshadow{FILTER: dropshadow(color=#F2F8DA,offx=1,offy=1);}");
this.wwrite("td { font-size: 10pt; color: #666600}");
this.wwrite("tr { height: 25px} .table_head_font{font-size: 14px;  color: #7B7B00}");
this.wwrite("a:active { text-decoration: underline overline; color: #5F506D}");
this.wwrite(".table_dashed { border: 1px dashed #333333; background-color: #FFF3E8}");
this.wwrite("</style>")
//this.wwrite("<link rel='stylesheet' href='css/green.css' type='text/css'>");

	this.wwrite("<body " + "topmargin=\"0\"" +
		"link=\"" + this.gLinkColor + "\" " + 
		"vlink=\"" + this.gLinkColor + "\" " +
		"alink=\"" + this.gLinkColor + "\" " +
		"text=\"" + this.gTextColor + "\">");
this.wwriteA("<table><tr><td height=2></td></tr></table>");
	this.wwriteA("<FONT FACE='" + fontface + "' SIZE=2><B>");
	this.wwriteA(this.gMonthName + " " + this.gYear);
	this.wwriteA("</B>");

	// Show navigation buttons
	var prevMMYYYY = Calendar.calc_month_year(this.gMonth, this.gYear, -1);
	var prevMM = prevMMYYYY[0];
	var prevYYYY = prevMMYYYY[1];

	var nextMMYYYY = Calendar.calc_month_year(this.gMonth, this.gYear, 1);
	var nextMM = nextMMYYYY[0];
	var nextYYYY = nextMMYYYY[1];
	this.wwrite("<table width='100%' border='0' cellspacing='0' cellpadding='0' class='table_dropshadow'><tr><td>");
	this.wwrite("<table class='table_dashed'  width='100%' align='center' height='20'><TR style='height: 22px'><TD ALIGN=center>");
	this.wwrite("[<A HREF=\"" +
		"javascript:window.opener.Build(" + 
		"'" + this.gReturnItem + "', '" + this.gMonth + "', '" + (parseInt(this.gYear)-1) + "', '" + this.gFormat + "'" +
		");" +
		"\"><<<\/A>]</TD><TD ALIGN=center>");
	this.wwrite("[<A HREF=\"" +
		"javascript:window.opener.Build(" + 
		"'" + this.gReturnItem + "', '" + prevMM + "', '" + prevYYYY + "', '" + this.gFormat + "'" +
		");" +
		"\"><<\/A>]</TD><TD ALIGN=center>");
	this.wwrite("<b>[calendar]</b>"+"</TD><TD ALIGN=center>");
	this.wwrite("[<A HREF=\"" +
		"javascript:window.opener.Build(" + 
		"'" + this.gReturnItem + "', '" + nextMM + "', '" + nextYYYY + "', '" + this.gFormat + "'" +
		");" +
		"\">><\/A>]</TD><TD ALIGN=center>");
	this.wwrite("[<A HREF=\"" +
		"javascript:window.opener.Build(" + 
		"'" + this.gReturnItem + "', '" + this.gMonth + "', '" + (parseInt(this.gYear)+1) + "', '" + this.gFormat + "'" +
		");" +
		"\">>><\/A>]</TD></TR></TABLE><table><tr><td height=5></td></tr></table>");

	// Get the complete calendar code for the month..
	vCode = this.getMonthlyCalendarCode();
	this.wwrite(vCode);

	this.wwrite("</font></body></html>");
	this.gWinCal.document.close();
}

Calendar.prototype.showY = function() {
	var vCode = "";
	var i;
	var vr, vc, vx, vy;		// Row, Column, X-coord, Y-coord
	var vxf = 285;			// X-Factor
	var vyf = 200;			// Y-Factor
	var vxm = 10;			// X-margin
	var vym;				// Y-margin
	if (isIE)	vym = 75;
	else if (isNav)	vym = 25;
	
	this.gWinCal.document.open();

	this.wwrite("<html>");
	this.wwrite("<head><title>Calendar</title>");
this.wwrite("<meta http-equiv='Content-Type' content='text/html; charset=gb2312'>");
	this.wwrite("<style type='text/css'>\n<!--");
	for (i=0; i<12; i++) {
		vc = i % 3;
		if (i>=0 && i<= 2)	vr = 0;
		if (i>=3 && i<= 5)	vr = 1;
		if (i>=6 && i<= 8)	vr = 2;
		if (i>=9 && i<= 11)	vr = 3;
		
		vx = parseInt(vxf * vc) + vxm;
		vy = parseInt(vyf * vr) + vym;

		this.wwrite(".lclass" + i + " {position:absolute;top:" + vy + ";left:" + vx + ";}");
	}
this.wwrite("");
	this.wwrite("-->\n</style>");
	this.wwrite("</head>");

	this.wwrite("<body " + 
		"link=\"" + this.gLinkColor + "\" " + 
		"vlink=\"" + this.gLinkColor + "\" " +
		"alink=\"" + this.gLinkColor + "\" " +
		"text=\"" + this.gTextColor + "\">");
	this.wwrite("<FONT FACE='" + fontface + "' SIZE=2><B>");
	this.wwrite("Year : " + this.gYear);
	this.wwrite("</B><BR>");

	// Show navigation buttons
	var prevYYYY = parseInt(this.gYear) - 1;
	var nextYYYY = parseInt(this.gYear) + 1;

	this.wwrite("<table class='table_dropshadow'  width='100%' bordercolordark='#ffffff' bordercolorlight='#8EA525' bgcolor='#FAFCF1' border='1' cellspacing='0' cellpadding='0' align='center'><TR><TD ALIGN=center>");
	this.wwrite("[<A HREF=\"" +
		"javascript:window.opener.Build(" + 
		"'" + this.gReturnItem + "', null, '" + prevYYYY + "', '" + this.gFormat + "'" +
		");" +
		"\" alt='Prev Year'><<<\/A>]</TD><TD ALIGN=center>");
	this.wwrite("[<A HREF=\"javascript:window.print();\">Print</A>]</TD><TD ALIGN=center>");
	this.wwrite("[<A HREF=\"" +
		"javascript:window.opener.Build(" + 
		"'" + this.gReturnItem + "', null, '" + nextYYYY + "', '" + this.gFormat + "'" +
		");" +
		"\">>><\/A>]</TD></TR></TABLE><BR>");

	// Get the complete calendar code for each month..
	var j;
	for (i=11; i>=0; i--) {
		if (isIE)
			this.wwrite("<DIV ID=\"layer" + i + "\" CLASS=\"lclass" + i + "\">");
		else if (isNav)
			this.wwrite("<LAYER ID=\"layer" + i + "\" CLASS=\"lclass" + i + "\">");

		this.gMonth = i;
		this.gMonthName = Calendar.get_month(this.gMonth);
		vCode = this.getMonthlyCalendarCode();
		this.wwrite(this.gMonthName + "/" + this.gYear + "<BR>");
		this.wwrite(vCode);

		if (isIE)
			this.wwrite("</DIV>");
		else if (isNav)
			this.wwrite("</LAYER>");
	}

	this.wwrite("</font><BR></body></html>");
	this.gWinCal.document.close();
}

Calendar.prototype.wwrite = function(wtext) {
	this.gWinCal.document.writeln(wtext);
}

Calendar.prototype.wwriteA = function(wtext) {
	this.gWinCal.document.write(wtext);
}

Calendar.prototype.cal_header = function() {
	var vCode = "";
	
	vCode = vCode + "<TR bgcolor='#C8D392' height=20 align='center'>";
	vCode = vCode + "<TD align='center' WIDTH='14%'><b>Sun</b></TD>";
	vCode = vCode + "<TD align='center' WIDTH='14%'><b>Mon</b></TD>";
	vCode = vCode + "<TD align='center' WIDTH='14%'><b>Tue</b></TD>";
	vCode = vCode + "<TD align='center' WIDTH='14%'><b>Wed</b></TD>";
	vCode = vCode + "<TD align='center' WIDTH='14%'><b>Thu</b></TD>";
	vCode = vCode + "<TD align='center' WIDTH='14%'><b>Fri</b></TD>";
	vCode = vCode + "<TD align='center' WIDTH='16%'><b>Sat</b></TD>";
	vCode = vCode + "</TR>";
	
	return vCode;
}

Calendar.prototype.cal_data = function() {
	var vDate = new Date();
	vDate.setDate(1);
	vDate.setMonth(this.gMonth);
	vDate.setFullYear(this.gYear);

	var vFirstDay=vDate.getDay();
	var vDay=1;
	var vLastDay=Calendar.get_daysofmonth(this.gMonth, this.gYear);
	var vOnLastDay=0;
	var vCode = "";

	/*
	Get day for the 1st of the requested month/year..
	Place as many blank cells before the 1st day of the month as necessary. 
	*/

	vCode = vCode + "<TR>";
	for (i=0; i<vFirstDay; i++) {
		vCode = vCode + "<TD WIDTH='14%'" + this.write_weekend_string(i) + "><FONT SIZE='2' FACE='" + fontface + "'>"+"<table width='100%' border='0' cellspacing='0' cellpadding='0' height='16'><tr ><td class='font_dropshadow'><div align='center' class='table_head_font'>&nbsp;</div></td></tr></table>"+"</FONT></TD>";
	}

	// Write rest of the 1st week
	for (j=vFirstDay; j<7; j++) {
		vCode = vCode + "<TD WIDTH='14%'" + this.write_weekend_string(j) + ">"+"<table width='100%' border='0' cellspacing='0' cellpadding='0' height='16'><tr ><td class='font_dropshadow'><div align='center' class='table_head_font'>" + "<FONT SIZE='2' FACE='" + fontface + "'>" +"<A HREF='#' " + 
				"onClick=\"self.opener.document." + this.gReturnItem + ".value='" + 
				this.format_data(vDay) + 
				"';window.close();\">" + 
				this.format_day(vDay) + 
			"</A>" + 
			"</FONT>"+"</div></td></tr></table>"+"</TD>";
		vDay=vDay + 1;
	}
	vCode = vCode + "</TR>";

	// Write the rest of the weeks
	for (k=2; k<7; k++) {
		vCode = vCode + "<TR>";

		for (j=0; j<7; j++) {
			vCode = vCode + "<TD WIDTH='14%'" + this.write_weekend_string(j) + ">"+"<table width='100%' border='0' cellspacing='0' cellpadding='0' height='16'><tr ><td class='font_dropshadow'><div align='center' class='table_head_font'>"+"<FONT SIZE='2' FACE='" + fontface + "'>" + 
				"<A HREF='#' " + 
					"onClick=\"self.opener.document." + this.gReturnItem + ".value='" + 
					this.format_data(vDay) + 
					"';window.close();\">" + 
				this.format_day(vDay) + 
				"</A>" + 
				"</FONT>"+"</div></td></tr></table>"+"</TD>";
			vDay=vDay + 1;

			if (vDay > vLastDay) {
				vOnLastDay = 1;
				break;
			}
		}

		if (j == 6)
			vCode = vCode + "</TR>";
		if (vOnLastDay == 1)
			break;
	}
	
	// Fill up the rest of last week with proper blanks, so that we get proper square blocks
	for (m=1; m<(7-j); m++) {
		if (this.gYearly)
			vCode = vCode + "<TD WIDTH='14%'" + this.write_weekend_string(j+m) + 
			">"+"<table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td class='font_dropshadow'>&nbsp;</td></tr></table>"+"</TD>";
		else
			vCode = vCode + "<TD WIDTH='14%'" + this.write_weekend_string(j+m) + 
			">"+"<table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td class='font_dropshadow'>"+m+"</td></tr></table>"+"</TD>";
	}
	
	return vCode;
}

Calendar.prototype.format_day = function(vday) {
	var vNowDay = gNow.getDate();
	var vNowMonth = gNow.getMonth();
	var vNowYear = gNow.getFullYear();

	if (vday == vNowDay && this.gMonth == vNowMonth && this.gYear == vNowYear)
		return ("<FONT COLOR=\"RED\"><B>" +"<table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td class='font_dropshadow'><div align='center'>"+vday+"</div></td></tr></table>"+ "</B></FONT>");
	else
		return (vday);
}

Calendar.prototype.write_weekend_string = function(vday) {
	var i;

	// Return special formatting for the weekend day.
	for (i=0; i<weekend.length; i++) {
		if (vday == weekend[i])
			return (" BGCOLOR=\"" + weekendColor + "\"");
	}
	
	return "";
}

Calendar.prototype.format_data = function(p_day) {
	var vData;
	var vMonth = 1 + this.gMonth;
	vMonth = (vMonth.toString().length < 2) ? "0" + vMonth : vMonth;
	var vMon = Calendar.get_month(this.gMonth).substr(0,3).toUpperCase();
	var vFMon = Calendar.get_month(this.gMonth).toUpperCase();
	var vY4 = new String(this.gYear);
	var vY2 = new String(this.gYear.substr(2,2));
	var vDD = (p_day.toString().length < 2) ? "0" + p_day : p_day;

	switch (this.gFormat) {
		case "MM\/DD\/YYYY" :
			//vData = vMonth + "\/" + vDD + "\/" + vY4;
			vData = vY4+"-"+vMonth + "-" + vDD;
                        break;
		case "MM\/DD\/YY" :
			//vData = vMonth + "\/" + vDD + "\/" + vY2;
                        vData = vY2+"-"+vMonth + "-" + vDD;
			break;
		case "MM-DD-YYYY" :
			//vData = vMonth + "-" + vDD + "-" + vY4;
			vData = vY4+"-"+vMonth + "-" + vDD ;
                        break;
		case "MM-DD-YY" :
			vData = vMonth + "-" + vDD + "-" + vY2;
                        vData = vY2+"-"+vMonth + "-" + vDD ;
			break;

		case "DD\/MON\/YYYY" :
			vData = vDD + "\/" + vMon + "\/" + vY4;
			break;
		case "DD\/MON\/YY" :
			vData = vDD + "\/" + vMon + "\/" + vY2;
			break;
		case "DD-MON-YYYY" :
			vData = vDD + "-" + vMon + "-" + vY4;
			break;
		case "DD-MON-YY" :
			vData = vDD + "-" + vMon + "-" + vY2;
			break;

		case "DD\/MONTH\/YYYY" :
			vData = vDD + "\/" + vFMon + "\/" + vY4;
			break;
		case "DD\/MONTH\/YY" :
			vData = vDD + "\/" + vFMon + "\/" + vY2;
			break;
		case "DD-MONTH-YYYY" :
			vData = vDD + "-" + vFMon + "-" + vY4;
			break;
		case "DD-MONTH-YY" :
			vData = vDD + "-" + vFMon + "-" + vY2;
			break;

		case "DD\/MM\/YYYY" :
			vData = vDD + "\/" + vMonth + "\/" + vY4;
			break;
		case "DD\/MM\/YY" :
			vData = vDD + "\/" + vMonth + "\/" + vY2;
			break;
		case "DD-MM-YYYY" :
			vData = vDD + "-" + vMonth + "-" + vY4;
			break;
		case "DD-MM-YY" :
			vData = vDD + "-" + vMonth + "-" + vY2;
			break;

		default :
			vData = vMonth + "\/" + vDD + "\/" + vY4;
	}

	return vData;
}

function Build(p_item, p_month, p_year, p_format) {
	var p_WinCal = ggWinCal;
	gCal = new Calendar(p_item, p_WinCal, p_month, p_year, p_format);

	// Customize your Calendar here..
	gCal.gBGColor="white";
	gCal.gLinkColor="black";
	gCal.gTextColor="black";
	gCal.gHeaderColor="darkgreen";

	// Choose appropriate show function
	if (gCal.gYearly)	gCal.showY();
	else	gCal.show();
}

function show_calendar() {
	/* 
		p_month : 0-11 for Jan-Dec; 12 for All Months.
		p_year	: 4-digit year
		p_format: Date format (mm/dd/yyyy, dd/mm/yy, ...)
		p_item	: Return Item.
	*/

	p_item = arguments[0];
	if (arguments[1] == null)
		p_month = new String(gNow.getMonth());
	else
		p_month = arguments[1];
	if (arguments[2] == "" || arguments[2] == null)
		p_year = new String(gNow.getFullYear().toString());
	else
		p_year = arguments[2];
	if (arguments[3] == null)
		p_format = "MM/DD/YYYY";
	else
		p_format = arguments[3];

	vWinCal = window.open("", "Calendar", 
		"width=250,height=253,status=no,resizable=no,top=200,left=200");
	vWinCal.opener = self;
	ggWinCal = vWinCal;

	Build(p_item, p_month, p_year, p_format);
}
/*
Yearly Calendar Code Starts here
*/
function show_yearly_calendar(p_item, p_year, p_format) {
	// Load the defaults..
	if (p_year == null || p_year == "")
		p_year = new String(gNow.getFullYear().toString());
	if (p_format == null || p_format == "")
//		p_format = "MM/DD/YYYY";
p_format = "YYYY-MM-DD";

	var vWinCal = window.open("", "Calendar", "scrollbars=yes");
	vWinCal.opener = self;
	ggWinCal = vWinCal;

	Build(p_item, null, p_year, p_format);
}
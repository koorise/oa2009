//第一页
function First(){
	if (Form1.NowPage.value!=1)
	{
		Form1.SelID.value="";
		Form1.isFind.value="1";
		eval("Form1.NowPage.value=1");
		Form1.submit();
	}
}
//下一页
function next(){
	var k=0;     
	k=parseInt(Form1.NowPage.value);
	k=k+1;
	if (k<=parseInt(Form1.PageCount.value))
	{
		Form1.SelID.value=""; 
		Form1.isFind.value="1";
		eval("Form1.NowPage.value="+k);
		Form1.submit();
	}
}
 //前一页
function back(){
	var k=0;     
	k=parseInt(Form1.NowPage.value);
	k=k-1;
	if (k>0)
	{
		Form1.SelID.value=""; 
		Form1.isFind.value="1";
		eval("Form1.NowPage.value="+k);
		Form1.submit();
	}
}
 //末页
function last(){
	var k=0;     
	k=parseInt(Form1.PageCount.value);
	if (k>0)
	{
		if (parseInt(Form1.NowPage.value)<k)
		{
			Form1.SelID.value=""; 
			Form1.isFind.value="1";
			eval("Form1.NowPage.value="+k);
			Form1.submit();
		}
	}
}
function Go(){
	var k=0;     
	k=parseInt(Form1.GoPage.value);
	if (k>0)
	{
		Form1.SelID.value=""; 
		Form1.isFind.value="1";
		if (k<=parseInt(Form1.PageCount.value))
		{
			eval("Form1.NowPage.value="+k);
			Form1.submit();
		}
		else{
			eval("Form1.NowPage.value="+Form1.PageCount.value);
			Form1.submit();
		}
	}
}
function ShowTree(){
	if(TreeDiv.style.visibility=='visible'){
		TreeDiv.style.visibility='hidden';
	}
	else{
		TreeDiv.style.visibility='visible';
	}
}
function body_onclick(){
	if(event.srcElement.name!="Button1")
		TreeDiv.style.visibility='hidden';
}

function keydown(){
	if(event.keyCode==13) event.keyCode=9;
}

function MouseIn(i){
	if (Form1.SelID.value!=i)
	{ eval("TR"+i+".className='tr3'");}
}
function MouseOut(i){
	if (Form1.SelID.value!=i)
	if (i%2==0)
	{ eval("TR"+i+".className='tr1'");}
	else { eval("TR"+i+".className='tr2'");}
}
function CheckNum()
{
//if (Form1.Integral.value.search(/^[0-9]+$/)==-1) ascl
if(event.keyCode<48 ||event.keyCode>57)
	window.event.returnValue = false;
}
function CheckFloat()
{
	if(event.keyCode==46)
		return;
	if(event.keyCode<48 ||event.keyCode>57)
		window.event.returnValue = false;
}
function vdf(a,message,c) 
{
	var value;
	eval('value='+a+'.value.replace(/\\s+/g,"")');  //.replace(/\s+/g,"")是去掉空格
    // ===============不能为空的判断================ //
	if(c=='r')
	{
		if(value=="")
		{
			alert(message+"!\n");
			eval(a+'.focus()');
			return false;
		}
	}
	// ===============只能输入数字================ //
	if (c=="r_num")
	{
		if (value=="")
		{
			alert(message+"!\n");
			eval(a+'.focus()');
			eval(a+'.select()');
			return false;
		}
		if (value.search(/^[0-9]+$/)==-1) 
		{
			alert(message+"!\n"); // 判断不能为空
			eval(a+'.focus()');
			eval(a+'.select()');
			return false;
		}
	}	
    // ===============判断日期,比如2000-12-20================ //
	if(c=='r_date')
	{
		flag=true; 
		var getdate;
		eval("getdate="+a+".value;");
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
			// 4,6,9,11月份日期不能超过30
			if ((month==4 || month==6 || month==9 || month==11) && (day>30)) 
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
			eval(a+'.focus()');
			eval(a+'.select()');
			return false;
		}	
	}
	// ===============判断email,不一定输入================ //	
	if (c=='email')
	{
		eval("value="+a+".value");
		if(value!="")
		{
			if (value.search(/^[_\.a-z0-9]+@[a-z0-9]+[\.][a-z0-9]{2,}$/i)==-1)
			{
				alert(message+"!\n");
				eval(a+'.focus()');
				eval(a+'.select()');
				return false;
			}
		}
	}
	return true;	
}

//js中取字符串的长度 
function GetStrLen(str) 
{
    var totallength=0;   
    for (var i=0;i<str.length;i++)
    {
        var intCode=str.charCodeAt(i);    
        if (intCode>=0&&intCode<=128) 
        {
            totallength=totallength+1; //非中文单个字符长度加 1
        }
        else 
        {
            totallength=totallength+2; //中文字符长度则加 2
        }
    } //end for  
    return totallength;
}
//js中取字符串的长度 
//function getLen(sString)
//{
//    var sStr,iCount,i,strTemp ; 
//    iCount = 0 ;
//    sStr = sString.split("");
//    for (i = 0 ; i < sStr.length ; i ++)
//    {
//         strTemp = escape(sStr[i]);
//         if (strTemp.indexOf("%u",0) == -1)
//         {
//              iCount = iCount + 1 ;
//         }
//         else
//         {
//              iCount = iCount + 2 ;
//         }
//     }
// 
//     return iCount ;
//}

//计算天数差的函数，通用
function DateDiff(sDate1, sDate2){  //sDate1和sDate2是2002-12-18格式    //sDate1为结束日期 sDate2为开始日期
    var aDate, oDate1, oDate2, iDays;
    aDate = sDate1.split("-");
    oDate1 = new Date(aDate[1] + '-' + aDate[2] + '-' + aDate[0]);  //转换为12-18-2002格式
    aDate = sDate2.split("-");
    oDate2 = new Date(aDate[1] + '-' + aDate[2] + '-' + aDate[0]);
    iDays = parseInt(Math.abs(oDate1 - oDate2) / 1000 / 60 / 60 /24);  //把相差的毫秒数转换为天数
    return iDays;
}

//比较两个日期的大小
function CompareDate(sDate1, sDate2){  //sDate1和sDate2是2002-12-18格式    //sDate1为结束日期 sDate2为开始日期
    var aDate, oDate1, oDate2, iDays;
    aDate = sDate1.split("-");
    oDate1 = new Date(aDate[1] + '-' + aDate[2] + '-' + aDate[0]);  //转换为12-18-2002格式
    aDate = sDate2.split("-");
    oDate2 = new Date(aDate[1] + '-' + aDate[2] + '-' + aDate[0]);
    iDays = parseInt((oDate1 - oDate2) / 1000 / 60 / 60 /24);  //把相差的毫秒数转换为天数
    return iDays;
}

var	fixedX=-1
var	fixedY=-1
var startAt=1
var showToday=1
var imgDir="Common/Images/DatePicker/"
var gotoString="转到本月"
var todayString="星期"
var weekString="周"
var yearString="年"
var dateString="日"
var	crossobj,crossMonthObj,crossYearObj,monthSelected,yearSelected,dateSelected,omonthSelected,oyearSelected,odateSelected,monthConstructed,yearConstructed,intervalID1,intervalID2,timeoutID1,timeoutID2,ctlToPlaceValue,ctlNow,dateFormat,nStartingYear
var	bPageLoaded=false
var	ie=document.all
var	dom=document.getElementById
var	ns4=document.layers
var	today=new	Date()
var	dateNow=today.getDate()
var	monthNow=today.getMonth()
var	yearNow=today.getYear()
var	img=new Array()
var bShow=false;
var lastControl = null;

function HiddenDateControl(ctr)
{
	if(lastControl != null && ctr!=lastControl)
	{
		hideCalendar();
	}
}
function hideElement(elmID,overDiv)
{
if(ie)
{
for(i=0;i<document.all.tags(elmID).length;i++)
{
obj=document.all.tags(elmID)[i];
if(!obj||!obj.offsetParent)
{
continue;
}
objLeft=obj.offsetLeft;
objTop=obj.offsetTop;
objParent=obj.offsetParent;
while(objParent.tagName.toUpperCase()!="BODY")
{
objLeft+=objParent.offsetLeft;
objTop+=objParent.offsetTop;
objParent=objParent.offsetParent;
}
objHeight=obj.offsetHeight;
objWidth=obj.offsetWidth;
if((overDiv.offsetLeft+overDiv.offsetWidth)<=objLeft);
else if((overDiv.offsetTop+overDiv.offsetHeight)<=objTop);
else if(overDiv.offsetTop>=(objTop+objHeight));
else if(overDiv.offsetLeft>=(objLeft+objWidth));
else
{
obj.style.visibility="hidden";
}
}
}
}function showElement(elmID)
{
if(ie)
{
for(i=0;i<document.all.tags(elmID).length;i++)
{
obj=document.all.tags(elmID)[i];
if(!obj||!obj.offsetParent)
{
continue;
}
obj.style.visibility="";
}
}
}
function HolidayRec(d,m,y,desc)
{
this.d=d
this.m=m
this.y=y
this.desc=desc
}
var HolidaysCounter=0
var Holidays=new Array()
function addHoliday(d,m,y,desc)
{
Holidays[HolidaysCounter++]=new HolidayRec(d,m,y,desc)
}
if(dom)
{
document.write("<div onclick='bShow=true' id='calendar' style='z-index:+999;position:absolute;visibility:hidden;'><table width=200 style='border-width:1;border-style:solid;border-color:#0264B6;' cellpadding=\"0\" cellspacing=\"0\"><tr bgcolor='#35A2E5'><td><table width='95%' align=\"center\" cellpadding=\"0\" cellspacing=\"0\"><tr><td style='padding:2px;font-family:MS Sans Serif; font-size:11px;' height=20><font color='#ffffff'><span id='caption'></span></font></td><td align=right><IMG SRC='"+imgDir+"close.gif' BORDER='0' ALT='关闭日历' OnClonclickdeCalendar();'></td></tr></table></td></tr><tr><td bgcolor=#0159AE></td></tr><tr><td bgcolor=#F4FBFE><span id='content'></span></td></tr>")
if(showToday==1)
{
document.write("<tr bgcolor=#D8EAFC><td style='padding:3px' align=center height='22'><span id='lblToday'></span></td></tr>")
}
document.write("</table></div><div id='selectMonth' style='z-index:+999;position:absolute;visibility:hidden;'></div><div id='selectYear' style='z-index:+999;position:absolute;visibility:hidden;'></div>");
}
var monthName=new	Array("1 月","2 月","3 月","4 月","5 月","6 月","7 月","8 月","9 月","10 月","11 月","12 月")
var monthName2=new	Array("1 月","2 月","3 月","4 月","5 月","6 月","7 月","8 月","9 月","10 月","11 月","12 月")
if(startAt==0)
{
dayName=new Array("日","一","二","三","四","五","六")
}
else
{
dayName=new Array("一","二","三","四","五","六","日")
}
var	styleAnchor="text-decoration:none;color:black;"
var	styleLightBorder="border-style:solid;border-width:1px;border-color:#a0a0a0;"
function swapImage(srcImg,destImg){
if(ie){document.getElementById(srcImg).setAttribute("src",imgDir+destImg)}
}
function init(){
if(!ns4)
{
if(!ie){yearNow+=1900}
crossobj=(dom)?document.getElementById("calendar").style:ie?document.all.calendar:document.calendar
hideCalendar()
crossMonthObj=(dom)?document.getElementById("selectMonth").style:ie?document.all.selectMonth:document.selectMonth
crossYearObj=(dom)?document.getElementById("selectYear").style:ie?document.all.selectYear:document.selectYear
monthConstructed=false;
yearConstructed=false;
if(showToday==1)
{
//document.getElementById("lblToday").innerHTML="<a style='"+styleAnchor+"' href='javascript:monthSelected=monthNow;yearSelected=yearNow;dateSelected=dateNow;closeCalendar();'>"+yearNow+" "+yearString+" "+monthName[monthNow].substring(0,3)+"	"+dateNow+" "+dateString+" "+todayString+dayName[(today.getDay()-startAt==-1)?6:(today.getDay()-startAt)]+"</a>"
document.getElementById("lblToday").innerHTML="<IMG SRC='"+imgDir+"ToDay.gif' BORDER='0' ALT='"+yearNow+" "+yearString+" "+monthName[monthNow].substring(0,3)+" "+dateNow+" "+dateString+" "+todayString+dayName[(today.getDay()-startAt==-1)?6:(today.getDay()-startAt)]+"' onClick='javascript:monthSelected=monthNow;yearSelected=yearNow;dateSelected=dateNow;closeCalendar();' Style=\"cursor: hand;\"><IMG SRC='"+imgDir+"None.gif' BORDER='0' ALT='清空日期' onClick=\"javascript:hideCalendar();ctlToPlaceValue.value='';if(lastControl.AutoPostBack=='True'){document.forms[0].submit();};\" Style=\"cursor: hand;margin-left:25px;\">"

}
sHTML1="<span id='spanLeft' style=\"width:15px;\" onclick='javascript:decMonth()' onmouseout='clearInterval(intervalID1);'  onmousedown='clearTimeout(timeoutID1);timeoutID1=setTimeout(\"StartDecMonth()\",500)'	onmouseup='clearTimeout(timeoutID1);clearInterval(intervalID1)'><Font Style=\"font-family:Webdings;font-size:16px;cursor: hand;\">3</Font></span>"
sHTML1+="<span id='spanRight' style=\"width:20px;\" onmouseout='clearInterval(intervalID1)' onclick='incMonth()' onmousedown='clearTimeout(timeoutID1);timeoutID1=setTimeout(\"StartIncMonth()\",500)'	onmouseup='clearTimeout(timeoutID1);clearInterval(intervalID1)'><Font Style=\"font-family:Webdings;font-size:16px;cursor: hand;\">4</Font></span>"
sHTML1+="<span id='spanYear' onclick='popUpYear()'></span>"
sHTML1+="<span id='spanMonth' onclick='popUpMonth()'></span>"
document.getElementById("caption").innerHTML=sHTML1
bPageLoaded=true
}
}
function hideCalendar(){
crossobj.visibility="hidden"
if(crossMonthObj!=null){crossMonthObj.visibility="hidden"}
if(crossYearObj!=null){crossYearObj.visibility="hidden"}
showElement('SELECT');
showElement('APPLET');
}
function padZero(num){
return(num<10)?'0'+num:num;
}
function constructDate(d,m,y)
{
sTmp=dateFormat
sTmp=sTmp.replace("dd","<e>")
sTmp=sTmp.replace("d","<d>")
sTmp=sTmp.replace("<e>",padZero(d))
sTmp=sTmp.replace("<d>",d)
sTmp=sTmp.replace("mmmm","<p>")
sTmp=sTmp.replace("mmm","<o>")
sTmp=sTmp.replace("mm","<n>")
sTmp=sTmp.replace("m","<m>")
sTmp=sTmp.replace("<m>",m+1)
sTmp=sTmp.replace("<n>",padZero(m+1))
sTmp=sTmp.replace("<o>",monthName[m])
sTmp=sTmp.replace("<p>",monthName2[m])
sTmp=sTmp.replace("yyyy",y)
return sTmp.replace("yy",padZero(y%100))
}
function closeCalendar(){
var	sTmp
hideCalendar();
ctlToPlaceValue.value=constructDate(dateSelected,monthSelected,yearSelected);
if(lastControl.AutoPostBack == "True")
{
document.forms[0].submit();
}
}
function StartDecMonth()
{
intervalID1=setInterval("decMonth()",80)
}
function StartIncMonth()
{
intervalID1=setInterval("incMonth()",80)
}
function incMonth(){
monthSelected++
if(monthSelected>11){
monthSelected=0
yearSelected++
}
constructCalendar()
}
function decMonth(){
monthSelected--
if(monthSelected<0){
monthSelected=11
yearSelected--
}
constructCalendar()
}
function constructMonth(){
popDownYear()
if(!monthConstructed)
{
sHTML="";
x=0;
for(i=0;i<4;i++)
{
sHTML+="<TR bgcolor=\"#F4FBFE\" align=\"Center\">";
for(m=0;m<3;m++)
{
sName=monthName[x];
if(x==monthSelected)
{
sHTML+="<td id='m"+x+"' bgcolor=\"#DBEFFB\" width=\"33%\" height=\"32\"  onmouseover='this.style.backgroundColor=\"#DBEFFB\"' onmouseout='this.style.backgroundColor=\"\"' style='cursor:pointer' onclick='monthConstructed=false;monthSelected="+x+";constructCalendar();popDownMonth();event.cancelBubble=true'>"+sName+"</td>";
}
else
{
sHTML+="<td id='m"+x+"' width=\"33%\" height=\"32\"  onmouseover='this.style.backgroundColor=\"#DBEFFB\"' onmouseout='this.style.backgroundColor=\"\"' style='cursor:pointer' onclick='monthConstructed=false;monthSelected="+x+";constructCalendar();popDownMonth();event.cancelBubble=true'>"+sName+"</td>";
}
x++;
}
sHTML+="</TR>";
}
document.getElementById("selectMonth").innerHTML="<table width=\"120\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><tr bgcolor=\"#B1DDF7\"><td><table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"1\" onmouseover='clearTimeout(timeoutID1)'	onmouseout='clearTimeout(timeoutID1);timeoutID1=setTimeout(\"popDownMonth()\",100);event.cancelBubble=true'>"+sHTML+"</table></td></tr></table>"
monthConstructed=true
}
}
function popUpMonth(){
constructMonth()
crossMonthObj.visibility=(dom||ie)?"visible":"show"
crossMonthObj.left=parseInt(crossobj.left)+50
crossMonthObj.top=parseInt(crossobj.top)+26
hideElement('SELECT',document.getElementById("selectMonth"));
hideElement('APPLET',document.getElementById("selectMonth"));
}
function popDownMonth(){
crossMonthObj.visibility="hidden"
}
function incYear(){
for(i=0;i<5;i++){
newYear=(i+nStartingYear)+1
if(newYear==yearSelected)
{txtYear="&nbsp;<B>"+newYear+"</B>&nbsp;"}
else
{txtYear="&nbsp;"+newYear+"&nbsp;"}
document.getElementById("y"+i).innerHTML=txtYear
}
nStartingYear++;
bShow=true
}
function decYear(){
for(i=0;i<5;i++){
newYear=(i+nStartingYear)-1
if(newYear==yearSelected)
{txtYear="&nbsp;<B>"+newYear+"</B>&nbsp;"}
else
{txtYear="&nbsp;"+newYear+"&nbsp;"}
document.getElementById("y"+i).innerHTML=txtYear
}
nStartingYear--;
bShow=true
}
function selectYear(nYear){
yearSelected=parseInt(nYear+nStartingYear);
yearConstructed=false;
constructCalendar();
popDownYear();
}
function constructYear(){
popDownMonth()
sHTML=""
if(!yearConstructed){
sHTML="<tr><td align='center' onmouseover='this.style.backgroundColor=\"#DBEFFB\"' onmouseout='clearInterval(intervalID1);this.style.backgroundColor=\"\"' style='cursor:pointer'	onmousedown='clearInterval(intervalID1);intervalID1=setInterval(\"decYear()\",30)' onmouseup='clearInterval(intervalID1)'><Font Style=\"font-family:Webdings;font-size:16px;cursor: hand;\">5</Font></td></tr>"
j=0
nStartingYear=yearSelected-2
for(i=(yearSelected-2);i<=(yearSelected+2);i++){
sName=i;
if(i==yearSelected){
sName="<Font Color=Red>"+sName+"</Font>"
}
sHTML+="<tr bgcolor=\"#F4FBFE\"><td id='y"+j+"' align='center' onmouseover='this.style.backgroundColor=\"#DBEFFB\"' onmouseout='this.style.backgroundColor=\"\"' style='cursor:pointer' onclick='selectYear("+j+");event.cancelBubble=true'>&nbsp;"+sName+"&nbsp;</td></tr>"
j++;
}
sHTML+="<tr><td align='center' onmouseover='this.style.backgroundColor=\"#DBEFFB\"' onmouseout='clearInterval(intervalID2);this.style.backgroundColor=\"\"' style='cursor:pointer' onmousedown='clearInterval(intervalID2);intervalID2=setInterval(\"incYear()\",30)'	onmouseup='clearInterval(intervalID2)'><Font Style=\"font-family:Webdings;font-size:16px;cursor: hand;\">6</Font></td></tr>"
document.getElementById("selectYear").innerHTML="<table width=\"100\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><tr bgcolor=\"#B1DDF7\"><td><table width=100% style='font-family:MS Sans Serif; font-size:12px;' onmouseover='clearTimeout(timeoutID2)' onmouseout='clearTimeout(timeoutID2);timeoutID2=setTimeout(\"popDownYear()\",100)' cellspacing=\"1\" cellpadding=\"1\">"+sHTML+"</table></td></tr><table>"
yearConstructed=true
}
}
function popDownYear(){
clearInterval(intervalID1)
clearTimeout(timeoutID1)
clearInterval(intervalID2)
clearTimeout(timeoutID2)
crossYearObj.visibility="hidden"
}
function popUpYear(){
var	leftOffset
constructYear()
crossYearObj.visibility=(dom||ie)?"visible":"show"
leftOffset=parseInt(crossobj.left)+document.getElementById("spanYear").offsetLeft
if(ie)
{
leftOffset+=6
}
crossYearObj.left=leftOffset
crossYearObj.top=parseInt(crossobj.top)+26
}
function WeekNbr(n){
year=n.getFullYear();
month=n.getMonth()+1;
if(startAt==0){
day=n.getDate()+1;
}
else{
day=n.getDate();
}
a=Math.floor((14-month)/12);
y=year+4800-a;
m=month+12*a-3;
b=Math.floor(y/4)-Math.floor(y/100)+Math.floor(y/400);
J=day+Math.floor((153*m+2)/5)+365*y+b-32045;
d4=(((J+31741-(J%7))%146097)%36524)%1461;
L=Math.floor(d4/1460);
d1=((d4-L)%365)+L;
week=Math.floor(d1/7)+1;
return week;
}
function constructCalendar(){
var aNumDays=Array(31,0,31,30,31,30,31,31,30,31,30,31)
var dateMessage
var	startDate=new	Date(yearSelected,monthSelected,1)
var endDate
if(monthSelected==1)
{
endDate=new Date(yearSelected,monthSelected+1,1);
endDate=new Date(endDate-(24*60*60*1000));
numDaysInMonth=endDate.getDate()
}
else
{
numDaysInMonth=aNumDays[monthSelected];
}
datePointer=0
dayPointer=startDate.getDay()-startAt
if(dayPointer<0)
{
dayPointer=6
}
sHTML="<table cellspacing='1' cellpadding='1' style='width:100%;' border='0'><tr height=22 align='center'>"
for(i=0;i<7;i++){
sHTML+="<td bgcolor='#F4FBFE'>"+dayName[i]+"</td>"
}
sHTML+="</tr><tr><td colspan=\"7\" bgcolor=\"#0159AE\"></td></tr><tr>"
for(var i=1;i<=dayPointer;i++)
{
sHTML+="<td bgcolor='#F4FBFE'></td>"
}
for(datePointer=1;datePointer<=numDaysInMonth;datePointer++)
{
dateMessage="onmousemove='this.style.backgroundColor=\"#DBEFFB\";' onmouseout='this.style.backgroundColor=\"#F4FBFE\";' "
dayPointer++;
sHTML+="<td align=center bgcolor='#F4FBFE' "+dateMessage+">"
sStyle=styleAnchor
if((datePointer==odateSelected)&&(monthSelected==omonthSelected)&&(yearSelected==oyearSelected))
{sStyle+=styleLightBorder}
sHint=""
for(k=0;k<HolidaysCounter;k++)
{
if((parseInt(Holidays[k].d)==datePointer)&&(parseInt(Holidays[k].m)==(monthSelected+1)))
{
if((parseInt(Holidays[k].y)==0)||((parseInt(Holidays[k].y)==yearSelected)&&(parseInt(Holidays[k].y)!=0)))
{
sStyle+="background-color:#FFDDDD;"
sHint+=sHint==""?Holidays[k].desc:"\n"+Holidays[k].desc
}
}
}
var regexp=/\"/g
sHint=sHint.replace(regexp,"&quot;")
if((datePointer==dateNow)&&(monthSelected==monthNow)&&(yearSelected==yearNow))
{
sHTML+="<b><a title=\""+sHint+"\" style='"+sStyle+"' href='javascript:dateSelected="+datePointer+";closeCalendar();'>&nbsp;<font color=#ff0000>"+datePointer+"</font>&nbsp;</a></b>"
}
else if(dayPointer%7==(startAt*-1)+1)
{
sHTML+="<a title=\""+sHint+"\" style='"+sStyle+"' href='javascript:dateSelected="+datePointer+";closeCalendar();'><font color=#909090>&nbsp;"+datePointer+"</font>&nbsp;</a>"
}
else
{
sHTML+="<a  title=\""+sHint+"\" style='"+sStyle+"' href='javascript:dateSelected="+datePointer+";closeCalendar();'>&nbsp;"+datePointer+"&nbsp;</a>"
}
sHTML+=""
if((dayPointer+startAt)%7==startAt)
{
sHTML+="</tr><tr>"
}
}
sHTML+="<tr><td colspan=\"7\" bgcolor=\"#0159AE\"></td></tr>"
document.getElementById("content").innerHTML=sHTML
document.getElementById("spanMonth").innerHTML="<Font Style=\"font-family:MS Sans Serif;font-size:12px;cursor: hand;\"><B>"+monthName[monthSelected]+"</B></Font><Font Style=\"font-family:Webdings;font-size:16px;cursor: hand;\">6</Font>"
document.getElementById("spanYear").innerHTML="<Font Style=\"font-family:MS Sans Serif;font-size:12px;cursor: hand;\"><B>"+yearSelected+" "+yearString+"</B></Font><Font Style=\"font-family:Webdings;font-size:16px;cursor: hand;\">6</Font>&nbsp;&nbsp;&nbsp;&nbsp;"
}
function StartDateControl(ctl,format)
{
lastControl = ctl;
DatePicker(ctl,format);
}
function DatePicker(ctl,format){
ctl.blur();
var	leftpos=0
var	toppos=0
var ctl2=ctl.parentElement.children[0];
if(bPageLoaded)
{
if(crossobj.visibility=="hidden"){
ctlToPlaceValue=ctl2
dateFormat=format;
formatChar=" "
aFormat=dateFormat.split(formatChar)
if(aFormat.length<3)
{
formatChar="/"
aFormat=dateFormat.split(formatChar)
if(aFormat.length<3)
{
formatChar="."
aFormat=dateFormat.split(formatChar)
if(aFormat.length<3)
{
formatChar="-"
aFormat=dateFormat.split(formatChar)
if(aFormat.length<3)
{
formatChar=""
}
}
}
}
tokensChanged=0
if(formatChar!="")
{
aData=ctl2.value.split(formatChar)
for(i=0;i<3;i++)
{
if((aFormat[i]=="d")||(aFormat[i]=="dd"))
{
dateSelected=parseInt(aData[i],10)
tokensChanged++
}
else if((aFormat[i]=="m")||(aFormat[i]=="mm"))
{
monthSelected=parseInt(aData[i],10)-1
tokensChanged++
}
else if(aFormat[i]=="yyyy")
{
yearSelected=parseInt(aData[i],10)
tokensChanged++
}
else if(aFormat[i]=="mmm")
{
for(j=0;j<12;j++)
{
if(aData[i]==monthName[j])
{
monthSelected=j
tokensChanged++
}
}
}
else if(aFormat[i]=="mmmm")
{
for(j=0;j<12;j++)
{
if(aData[i]==monthName2[j])
{
monthSelected=j
tokensChanged++
}
}
}
}
}
if((tokensChanged!=3)||isNaN(dateSelected)||isNaN(monthSelected)||isNaN(yearSelected))
{
dateSelected=dateNow
monthSelected=monthNow
yearSelected=yearNow
}
odateSelected=dateSelected
omonthSelected=monthSelected
oyearSelected=yearSelected
aTag=ctl
do{
aTag=aTag.offsetParent;
leftpos+=aTag.offsetLeft;
toppos+=aTag.offsetTop;
}while(aTag.tagName!="BODY");
crossobj.left=fixedX==-1?leftpos:fixedX
crossobj.top=fixedY==-1?ctl.offsetTop+toppos+ctl.offsetHeight+2:fixedY
constructCalendar(1,monthSelected,yearSelected);
crossobj.visibility=(dom||ie)?"visible":"show"
hideElement('SELECT',document.getElementById("calendar"));
hideElement('APPLET',document.getElementById("calendar"));
bShow=true;
}
else
{
hideCalendar()
if(ctlNow!=ctl){DatePicker(ctl,ctl2,format)}
}
ctlNow=ctl
}
}
document.onkeypress=function hidecal1(){
if(event.keyCode==27)
{
hideCalendar()
}
}
document.onclick=function hidecal2(){
if(!bShow)
{
hideCalendar()
}
bShow=false
}
if(ie)
{
init()
}
else
{
window.onload=init
}

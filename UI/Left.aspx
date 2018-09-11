<%@ Page Language="C#"  AutoEventWireup="true" Inherits="UI.Left" Codebehind="Left.aspx.cs" %>


<!DOCTYPE html>

<html >
<head runat="server">
    <title>Untitled Page</title>


    <asp:PlaceHolder ID="PlaceHolder1" runat="server">     
          <%: Scripts.Render("~/Content/Bundle/menuJS") %>
    </asp:PlaceHolder>  
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/defaultCSS" />

    <link href="Content/CSS/XP.css" rel="stylesheet" type="text/css" />
  
   
       
    <script type="text/javascript">
    function init_dw_Scroll() {
        var wndo = new dw_scrollObj('wn', 'sggbe_xpPane');
        wndo.setUpScrollControls('scrollLinks');
        }
        if ( dw_scrollObj.isSupported() ) {
            //dw_writeStyleSheet('css/scroll.css');
            dw_Event.add( window, 'load', init_dw_Scroll);
    }
    

    function time()
            {
                var today = new Date();
                var hrs = today.getHours();
                var min = today.getMinutes();
                var secs = today.getSeconds();
                
                var alsohrs = today.getHours();
                var dayNumber = today.getDate();
                var year = today.getFullYear();
                
                var ampm="";
                var zero="0";
                var month = today.getMonth();
                var weekday = today.getDay();
                
                var wdn = new Array(7)
                wdn[0] = "SUN";
                wdn[1] = "MON";
                wdn[2] = "TUE";
                wdn[3] = "WED";
                wdn[4] = "THU";
                wdn[5] = "FRI";
                wdn[6] = "SAT";
                
                var mn = new Array(12)
                mn[0] = "JAN";
                mn[1] = "FEB";
                mn[2] = "MAR";
                mn[3] = "APR";
                mn[4] = "MAY";
                mn[5] = "JUN";
                mn[6] = "JUL";
                mn[7] = "AUG";
                mn[8] = "SEP";
                mn[9] = "OCT";
                mn[10] = "NOV";
                mn[11] = "DEC";
                
                // Statement that puts zeros in front of single minutes or seconds.
                if (min<10)
                    {
                        min=zero+min;
                    }
                if (secs<10)
                    {
                        secs=zero+secs;
                    }
                
                // Statement that eliminates metric time.
                if (hrs>12)
                    {
                        hrs=eval(hrs - 12);
                    }
                if (hrs>=0 && hrs<1)
                    {
                        hrs=12;
                    }
                
                // Statement to determine am or pm
                if (alsohrs>=12 && alsohrs<24)
                    {
                        ampm="PM";
                    }
                else
                    {
                        ampm="AM";
                    }                
                
                tmp= wdn[weekday] +', '+ dayNumber +' '+ mn[month] /*+','+ year*/ +' &nbsp;&nbsp;&nbsp;'+ hrs +'<span id="blinker">:</span>'+ min +' '+ ampm;
                document.getElementById("time").innerHTML=tmp;
                clocktime=setTimeout("time()","1000");
        }


    function blink()
        {
            var obj = document.getElementById("blinker");
            if (obj.style.visibility == "visible") 
                {
                    obj.style.visibility="hidden";
                }
            else
                {
                    obj.style.visibility="visible";
                }
            eachsecond=setTimeout("blink()","500");
        }

    </script>
     <!-- Global site tag (gtag.js) - Google Analytics -->
<script async src="https://www.googletagmanager.com/gtag/js?id=UA-125570863-1"></script>
<script>
  window.dataLayer = window.dataLayer || [];
  function gtag(){dataLayer.push(arguments);}
  gtag('js', new Date());
  gtag('config', 'UA-125570863-1');
</script> 
    <style type="text/css">
        .divPopUp1
        {
            position: absolute;
            z-index: 1;
            left: 0px;
            top: 0px;
            background-color: #E6E2CC;
            border: 0px outset #00367B;
        }
    </style>
</head>
<body style="background-color: #EEF1FB">
    <form id="form1" runat="server" enableviewstate="false">
    <div id="navbar" class="divPopUp1" style="width: 100%; height: 20px; float: right;">
        <div style="position: absolute; left: 10px; top: 3px;">
            <span id="time" class="clock">ASD</span>
        </div>
        <div id="scrollLinks" style="padding-top: 1px; padding-left: 170px; text-align: right;">
            <table>
                <tr>
                    <td>
                        <a class="mouseover_up" href="#">
                            <div class="up">
                            </div>
                            <%--<img src="images/tri-up.gif" alt="" border="0" />--%></a>
                    </td>
                    <td>
                        <a class="mouseover_down" href="#">
                            <div class="down">
                            </div>
                            <%--<img src="images/tri-dn.gif" alt="" border="0" />--%></a>
                    </td>
                </tr>
            </table>
        </div>
    </div>        
    <div id="Div1" style="position: absolute; left: 0px; top: 20px; z-index:1; background-color:#EEF1FB; width:200px; height:80px; vertical-align:middle; text-align:center;">
        <img width="80" height="85" src="Content/images/img/<%# Session[UI.ClassFiles.SessionParams.UNIT_ID].ToString() %>.png" onerror="this.onerror=null; this.src='Content/images/img/ag.png';"/>
    </div>
    <div id="wn" style="position: absolute; left: 0px; top: 100px;">
        <div id="sggbe_xpPane" style="position: absolute; left: 0px; top: 100px;">
            <%# divs.ToString() %>
            <%--<div class="sggbe_panel" id="0">
                    <div>
                        <a href="#" class="xp" target="">
                            <img src="App_Themes/Default/Icons/img.gif" class="menuicon" border="0">
                            Information</a><br />
                        <a href="#" class="xp" target="">
                            <img src="App_Themes/Default/Icons/dbfolder.gif" class="menuicon" border="0">
                            Application</a><br />
                        <a href="#" class="xp" target="">
                            <img src="App_Themes/Default/Icons/time.gif" class="menuicon" border="0">
                            Salary Info</a><br />
                    </div>
                </div>
                <div class="sggbe_panel" id="1">
                    <div>
                        <a href="#" class="xp" target="">
                            <img src="App_Themes/Default/Icons/date.gif" class="menuicon" border="0">
                            Sales Order</a><br />
                        <a href="#" class="xp" target="">
                            <img src="App_Themes/Default/Icons/edit.gif" class="menuicon" border="0">
                            Challan</a><br />
                    </div>
                </div>
                <div class="sggbe_panel" id="2">
                    <div>
                        <a href="ServiceDash.aspx" class="xp" target="main">
                            <img src="App_Themes/Default/Icons/date.gif" class="menuicon" border="0">
                            Service Dash</a><br />
                        <a href="MasterServicesList.aspx" class="xp" target="main">
                            <img src="App_Themes/Default/Icons/edit.gif" class="menuicon" border="0">
                            Master Services List</a><br />
                        <a href="GroupRole.aspx" class="xp" target="main">
                            <img src="App_Themes/Default/Icons/edit.gif" class="menuicon" border="0">
                            Service Group</a><br />
                        <a href="VehicleAssignToGroup.aspx" class="xp" target="main">
                            <img src="App_Themes/Default/Icons/edit.gif" class="menuicon" border="0">
                            Service Group By Vehicle</a><br />
                    </div>
                </div>--%>
            <%--<div class="sggbe_panel" id="3">   
        <div>
        <a href="#" class="xp" target=""><img src="App_Themes/Default/Icons/date.gif" class="menuicon" border="0" > Sales Order</a><br />
        <a href="#" class="xp" target=""><img src="App_Themes/Default/Icons/edit.gif" class="menuicon" border="0" > Challan</a><br />
        </div></div> 
    <div class="sggbe_panel" id="4">   
        <div>
        <a href="#" class="xp" target=""><img src="App_Themes/Default/Icons/date.gif" class="menuicon" border="0" > Sales Order</a><br />
        <a href="#" class="xp" target=""><img src="App_Themes/Default/Icons/edit.gif" class="menuicon" border="0" > Challan</a><br />
        </div></div>
    <div class="sggbe_panel" id="5">   
        <div>
        <a href="#" class="xp" target=""><img src="App_Themes/Default/Icons/date.gif" class="menuicon" border="0" > Sales Order</a><br />
        <a href="#" class="xp" target=""><img src="App_Themes/Default/Icons/edit.gif" class="menuicon" border="0" > Challan</a><br />
        </div></div> 
    <div class="sggbe_panel" id="6">   
        <div>
        <a href="#" class="xp" target=""><img src="App_Themes/Default/Icons/date.gif" class="menuicon" border="0" > Sales Order</a><br />
        <a href="#" class="xp" target=""><img src="App_Themes/Default/Icons/edit.gif" class="menuicon" border="0" > Challan</a><br />
        </div></div> 
    <div class="sggbe_panel" id="7">   
        <div>
        <a href="#" class="xp" target=""><img src="App_Themes/Default/Icons/date.gif" class="menuicon" border="0" > Sales Order</a><br />
        <a href="#" class="xp" target=""><img src="App_Themes/Default/Icons/edit.gif" class="menuicon" border="0" > Challan</a><br />
        </div></div> 
    <div class="sggbe_panel" id="8">   
        <div>
        <a href="#" class="xp" target=""><img src="App_Themes/Default/Icons/date.gif" class="menuicon" border="0" > Sales Order</a><br />
        <a href="#" class="xp" target=""><img src="App_Themes/Default/Icons/edit.gif" class="menuicon" border="0" > Challan</a><br />
        </div></div> 
    <div class="sggbe_panel" id="9">   
        <div>
        <a href="#" class="xp" target=""><img src="App_Themes/Default/Icons/date.gif" class="menuicon" border="0" > Sales Order</a><br />
        <a href="#" class="xp" target=""><img src="App_Themes/Default/Icons/edit.gif" class="menuicon" border="0" > Challan</a><br />
        </div></div> 
    <div class="sggbe_panel" id="10">   
        <div>
        <a href="#" class="xp" target=""><img src="App_Themes/Default/Icons/date.gif" class="menuicon" border="0" > Sales Order</a><br />
        <a href="#" class="xp" target=""><img src="App_Themes/Default/Icons/edit.gif" class="menuicon" border="0" > Challan</a><br />
        </div></div>
    <div class="sggbe_panel" id="11">   
        <div>
        <a href="#" class="xp" target=""><img src="App_Themes/Default/Icons/date.gif" class="menuicon" border="0" > Sales Order</a><br />
        <a href="#" class="xp" target=""><img src="App_Themes/Default/Icons/edit.gif" class="menuicon" border="0" > Challan</a><br />
        </div></div> 
    <div class="sggbe_panel" id="12">   
        <div>
        <a href="#" class="xp" target=""><img src="App_Themes/Default/Icons/date.gif" class="menuicon" border="0" > Sales Order</a><br />
        <a href="#" class="xp" target=""><img src="App_Themes/Default/Icons/edit.gif" class="menuicon" border="0" > Challan</a><br />
        </div></div> 
    <div class="sggbe_panel" id="13">   
        <div>
        <a href="#" class="xp" target=""><img src="App_Themes/Default/Icons/date.gif" class="menuicon" border="0" > Sales Order</a><br />
        <a href="#" class="xp" target=""><img src="App_Themes/Default/Icons/edit.gif" class="menuicon" border="0" > Challan</a><br />
        </div></div> 
    <div class="sggbe_panel" id="14">   
        <div>
        <a href="#" class="xp" target=""><img src="App_Themes/Default/Icons/date.gif" class="menuicon" border="0" > Sales Order</a><br />
        <a href="#" class="xp" target=""><img src="App_Themes/Default/Icons/edit.gif" class="menuicon" border="0" > Challan</a><br />
        </div></div> 
    <div class="sggbe_panel" id="15">    
        <div>
        <a href="#" class="xp" target=""><img src="App_Themes/Default/Icons/usmenu.gif" class="menuicon" border="0" > Employee</a><br />
        <a href="#" class="xp" target=""><img src="App_Themes/Default/Icons/SMList.gif" class="menuicon" border="0" > Driver</a><br />                
        <a href="#" class="xp" target=""><img src="App_Themes/Default/Icons/custom.gif" class="menuicon" border="0" > Customer</a><br />
        </div></div> --%>
        </div>
    </div>
    </form>

    <script type="text/javascript" language="javascript">
        //initsggbe_xpPane(
        //Array('Personal Info','Sales & Distribution','Garrage','Trip'/*,'Control','Manufacture','Production','Notice','Accounts','Logistic','Garriage','Ware House','Cleaning','Civil','Electrical','HR'*/),
        //Array('false','false','false','false'/*,'false','false','false','false','false','false','false','false','false','false','false','false'*/),
        //Array('0','1','2','3'/*,'4','5','6','7','8','9','10','11','12','13','14','15'*/),'App_Themes/Default/Images/xpmenu');
        <%# links.ToString() %>
    </script>

    <script type="text/javascript">
     /*function SetTime()
     {
        var current= new Date(); 
        var len = (''+current).length;
        document.getElementById("time").innerText = (''+current).substring(0,len-13);         
        //document.getElementById("time").innerText = current.getDay() + ' ' + current.getMonth() + ' ' +current.getYear() + ' ' +current.getHours() + ' : ' + current.getMinutes() + ' : ' + current.getSeconds(); 
        setTimeout ( "SetTime()", 1000);
     }
     SetTime();*/
     time(); 
     blink();
    </script>

</body>
</html>

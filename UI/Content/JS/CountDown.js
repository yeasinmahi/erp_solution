
/*
 
    Developed By Himadri Das 
    Used for Count Down Time
    
    ---------------------------------------------------------
    Created At: 08/08/2010

*/

var  BackColor = "white";
var  ForeColor = "navy";
var  CountActive = true;
var  CountStepper = -1;
var  LeadingZero = true;
var  DisplayFormat = "%%M%% Minutes, %%S%% Seconds.";
var  SetTimeOutPeriod = (Math.abs(CountStepper)-1)*1000 + 990;
var  PreFix;
var  FinishMessage ;

function StartTimeCalc(prifixString,CountEndMsg,waitTime)
    {

        PreFix=prifixString;
        FinishMessage =CountEndMsg;
        CountStepper = Math.ceil(CountStepper);
        if (CountStepper == 0)
          CountActive = false;
        
        putspan(BackColor, ForeColor);
        
        gsecs=waitTime
        CountBack(gsecs);
    }

function calcage(secs, num1, num2) 
    {
          s = ((Math.floor(secs/num1))%num2).toString();
          if (LeadingZero && s.length < 2)
            s = "0" + s;
          return "<b>" + s + "</b>";
    }

function CountBack(secs) 

    {
          if (secs < 0) 
          {
            document.getElementById("cntdwn").innerHTML = FinishMessage;
            document.getElementById('generateButton').style.display="block";
            return;
          }
         
          DisplayStr = DisplayFormat.replace('%%M%%', calcage(secs,60,60));
          DisplayStr = DisplayStr.replace('%%S%%', calcage(secs,1,60));

          document.getElementById("cntdwn").innerHTML = PreFix+DisplayStr;
          
          if (CountActive)
            {
               setTimeout("CountBack(" + (secs+CountStepper) + ")", SetTimeOutPeriod);
            }
    }

function putspan(backcolor, forecolor) 
{
     var  spanString="<span id='cntdwn' style='background-color:" + backcolor + 
                    "; color:" + forecolor + "'></span>";
     
     document.getElementById('lblCountDown').innerHTML=spanString;
 
}

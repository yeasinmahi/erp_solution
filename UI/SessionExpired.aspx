<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.SessionExpired" Codebehind="SessionExpired.aspx.cs" %>

<!DOCTYPE html>
<html >
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            font-family: Verdana;
            font-size: 10pt;
        }
        .style2
        {
            color: #993333;
        }
        .style3
        {
            font-family: Verdana;
            font-size: 10pt;
            color: #993333;
        }
        .style4
        {
            text-align: center;
        }
    </style>
</head>
<body  >
    <form id="form1" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%" style="position:absolute; top:30%" >
    <tr>
    <td align="center" valign="middle">
    <div style=" border-width:1px; border-color:Black; border-style:solid; padding:5px; width: 586px; height: 153px;" >
        <p class="style4">
            <span class="style3"><strong>Sorry!!!!</strong></span> <b><span class="style1">
            <span class="style2">&nbsp; Your Session Have Expired.</span> </span></b>
        </p>
        <p>
            <b><span class="style1">Please follow the following Instruction</span><br 
                class="style1" />
            </b>
            <br class="style1" /><span class="style1">Your Browser  will Close automitically after 10 Sec.&nbsp; 
            After Closing the browser Open your browser again. then Log in with with your 
            Domain ID and Password</span></p>
            <p>
                <asp:Label ID="lblTime"  runat="server" 
                    style="font-weight: 700; color: #993333" Font-Names="Verdana" Font-Size="11pt"></asp:Label>
            </p>
    </div>
    </td>
    </tr>
    </table>
    

    </form>
   

    <script type="text/javascript">
          
        var agTimer;
        var totalSeconds = 11;
        agTimer = setInterval(function () { timerInterval() }, 1000);


        function timerInterval() 
        {
            totalSeconds = totalSeconds - 1
            var d = new Date();
            var t = d.toLocaleTimeString();
            if (totalSeconds >= 10) {
                document.getElementById("lblTime").innerHTML = 'Remains  '+totalSeconds + ' Seconds......';
            }
            else {
                document.getElementById("lblTime").innerHTML = 'Remains   0'+totalSeconds + ' Seconds......';
            }

            if (totalSeconds == 0) 
            {
                clearInterval(agTimer);
                window.top.location = "Exit.aspx"; 
                        
             }

        }


    </script>

</body>
</html>

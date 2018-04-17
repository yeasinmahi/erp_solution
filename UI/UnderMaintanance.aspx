<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="UI.UnderMaintanance" Codebehind="UnderMaintanance.aspx.cs" %>

<!DOCTYPE html>
<html >
<head runat="server">
    <title>Welcome to Akij Group</title>
     
    <link href="Content/CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
    
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-top: 20px; width: 100%; margin-left: 10px; margin-right: auto;"
        align="center">
        <img alt="" src="Content/images/img/logo.gif" style="width: 74px; height: 94px" />
    </div>
    <div style="width: 400px; clear: both; margin-top: 70px; margin-left: auto; margin-right: auto;
        height: auto;">
        <div style="width: 400px; clear: both;">
            <div>
                <b class="spiffy"><b class="spiffy1"><b></b></b><b class="spiffy2"><b></b></b><b
                    class="spiffy3"></b><b class="spiffy4"></b><b class="spiffy5"></b></b>
                <div class="spiffyfg" style="height: 18px; font-size: 20px; font-weight: bold; text-align: center;">
                    &nbsp;&nbsp; UNDER MAINTANANCE
                </div>
                <div class="spiffyfg" style="height: 30px; font-size: 10px; font-weight: bold; text-align: center;">
                    &nbsp;&nbsp;
                    <asp:Panel ID="Panel1" runat="server">
                        <%# str %>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
       
    </asp:ScriptManager>
    <asp:Timer ID="Timer1" runat="server" Interval="5000" ontick="Timer1_Tick">
    </asp:Timer>
    </form>
</body>
</html>

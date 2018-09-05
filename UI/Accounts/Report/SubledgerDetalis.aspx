<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubledgerDetalis.aspx.cs" Inherits="UI.Accounts.Report.SubledgerDetalis" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.: Manual Attendance Insertion :.</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
        <webopt:BundleReference ID="BundleReference4" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />

    <script src="../../Content/JS/datepickr.min.js"></script>
     <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    

    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script> 

    <script type="text/javascript">
        function loadIframe(iframeName, url) {
            var $iframe = $('#' + iframeName);
            if ($iframe.length) {
                $iframe.attr('src', url); 
                return false;
            }
            return true;
        }


        // function ConfirmforShow() {           
            
        //    var fromdate = document.getElementById("txtFormDate").value;
        //    var todate = document.getElementById("txtToDate").value;
        //    var report = document.getElementById("DdlReport").value;
            
        //     if (fromdate == null || fromdate == "") {
        //         alert('Insert From Date');
        //         return false;
        //     }
        //     else if (todate == null || todate == "") {
        //         alert('Insert To Date');
        //          return false;
        //     }

        //     else if (report == null || report == "") {
        //         alert('Insert Report Type');
        //          return false;
        //     }
        //     else {
        //         return true;
        //     }
            
            
        //}


    </script>
   
    </head>
<body>
    <form id="frmaclmanatt" runat="server">
   <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
        <iframe runat="server" oncontextmenu="return false;" id="frame" name="frame" style="width:100%; height:1500px; border:0px solid red;"></iframe>
        
       
   <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

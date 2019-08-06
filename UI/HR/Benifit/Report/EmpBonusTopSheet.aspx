<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpBonusTopSheet.aspx.cs" Inherits="UI.HR.Benifit.Report.EmpBonusTopSheet" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.: Bonus Top Sheet :.</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../../Content/JS/datepickr.min.js"></script>
    <script src="../../../Content/JS/JSSettlement.js"></script>   
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../../../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    <script src="../../../Content/JS/CustomizeScript.js"></script>
    <link href="../../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../../../Content/CSS/Gridstyle.css" rel="stylesheet" />

    <script>
        function loadIframe(iframeName, url) {
            var $iframe = $('#' + iframeName);
            if ($iframe.length) {
                $iframe.attr('src', url);
                return false;
            }
            return true;
        }
    </script>
    <script type="text/javascript">
        //$(document).ready(function () {
        //    alert("HI");
        //    var href = $(this).attr('href');
        //    alert(href);
        //});
    </script>

</head>
<body>
    <form id="frmBonusTopSheet" runat="server">
        <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div>
                </asp:Panel>
                <div style="height: 100px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender2" runat="server">
                </cc1:AlwaysVisibleControlExtender>

                <div id="div1" runat="server">
                    <iframe runat="server" oncontextmenu="return false;" id="frame" name="frame" style="width: 100%; height: 500px; border: 0px solid red;"></iframe>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

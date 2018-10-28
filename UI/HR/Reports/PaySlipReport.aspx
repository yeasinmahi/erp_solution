<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaySlipReport.aspx.cs" Inherits="UI.HR.Reports.PaySlipReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>.: Employee Attendance Details :.</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-Frame-Options" content="allow"/>  
   <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
     <link href="../../Content/CSS/MyStyle.css" rel="stylesheet" />
    
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
      
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />
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
</head>
<body>
    <form id="frmattendancedetails" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender2" runat="server">
    </cc1:AlwaysVisibleControlExtender>
    <%--=========================================Start My Code From Here===============================================--%>
        <asp:HiddenField ID="hdnempid" runat="server" />
       <table class="tbldecoration" style="width:auto; float:left;">
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblemployeesearch" CssClass="lbl" runat="server" Text="Search-Employee : "></asp:Label></td>
            <td>
            <asp:TextBox ID="txtEmployeeSearch" runat="server" CssClass="txtBox1" AutoPostBack="true"  Width="250px"></asp:TextBox>
             <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtEmployeeSearch"
                            ServiceMethod="GetWearHouseRequesision" MinimumPrefixLength="1" CompletionSetCount="1"
                            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"></cc1:AutoCompleteExtender>
            </td>
            <td style="text-align:right;"><asp:Label ID="lbldate" CssClass="lbl" runat="server" Text="Attendance Date : "></asp:Label></td>
             <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox1" Enabled="true"></asp:TextBox>
                <cc1:CalendarExtender ID="fd" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender>                                                        
             </td>
             <td> 
                 <asp:Button ID="btnSubmit" runat="server" class="myButton" Style="font-size: 12px; cursor: pointer;" Text="Show Report" OnClick="btnSubmit_Click"/>
            </td>
            </tr>
           </table>
        <iframe runat="server" oncontextmenu="return false;" id="frame" name="frame" style="width:100%; height:600px; border:0px solid red;"></iframe>
        <%--sandbox="allow-same-origin allow-scripts allow-popups allow-forms"--%>
    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

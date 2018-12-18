<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee_Attendance_with_Overtime_Status.aspx.cs" Inherits="UI.HR.Reports.Employee_Attendance_with_Overtime_Status" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Damage Entry</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
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

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel0" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                        <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                </asp:Panel>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <div style="height: 50px; width: 100%"></div>
                <%--=========================================Start My Code From Here===============================================--%>
                <div class="container">
                       <asp:HiddenField ID="hdnEnroll" runat="server" />
                       <table>
                            <tr class="tblheader"><td class="tdheader" colspan="6"> Employee Attendance with Overtime Status :</td></tr>        
                            <tr class="tblheader"><td style=" height:2px; background-color:#c1bdbd;" colspan="6"> </td></tr>
                            <tr><td colspan="6" style="height:5px;"></td></tr>
                           <tr>
                               <td><asp:Label ID="Label20" runat="server" Text="Search Employee" ></asp:Label></td><td></td>
                               <td><asp:Label ID="Label1" runat="server" Text="From Date" ></asp:Label></td><td></td>
                               <td><asp:Label ID="Label2" runat="server" Text="To Date" ></asp:Label></td><td></td>
    
                           </tr>
                           <tr>
                               <td>
                                   <asp:TextBox ID="txtEmp" CssClass="txtBox1" Width="300" runat="server" placeholder="Search Employee Here"></asp:TextBox>
                                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtEmp"
                                        ServiceMethod="SearchEmployee" MinimumPrefixLength="1" CompletionSetCount="1"
                                        CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"></cc1:AutoCompleteExtender> 

                               </td><td></td>
                               <td>
                                   <asp:TextBox ID="txtFromDate" runat="server" ></asp:TextBox>
                                   <cc1:CalendarExtender ID="fd" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender>

                               </td><td></td>
                               <td>
                                   <asp:TextBox ID="txtToDate" runat="server" ></asp:TextBox>
                                   <cc1:CalendarExtender ID="td" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender>
                               </td>
                               <td>
                                   <asp:Button ID="btnShow" runat="server" class="btn btn-primary btn-md form-control pull-right" Text="Show" OnClientClick="return Validate();" OnClick="btnShow_Click"/>
                               </td>
    
                           </tr>
                       </table>
                                        
                             
                    <div>
                         <iframe runat="server" oncontextmenu="return false;" id="frame" name="frame" style="width:100%; height:1000px; border:0px solid red;"></iframe>
                    </div>
                    </div>

               
                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>

    </form>
    <script>
            function loadIframe(iframeName, url) {
            var $iframe = $('#' + iframeName);
            if ($iframe.length) {
                $iframe.attr('src', url); 
                return false;
            }
            return true;
        }

        function Validate() {
            var emp = document.getElementById("txtEmp").value;
            if (emp == null || emp == "") {
                alert("Please Enter Employee");
            }
        }
    </script>
    </body>
</html>

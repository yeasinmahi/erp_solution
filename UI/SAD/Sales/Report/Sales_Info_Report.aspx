<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sales_Info_Report.aspx.cs" Inherits="UI.SAD.Sales.Sales_Info_Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>.: Customer Pending List :.</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-Frame-Options" content="allow" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/updatedJs") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/updatedCss" />
    <%--<webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/defaultCSS" />--%>
    <%--<link href="../Content/CSS/CommonStyle.css" rel="stylesheet" />--%>
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
    <style type="text/css">
        
    </style>
</head>
<body>
    <form id="frmattendancedetails" runat="server">
        <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                </asp:Panel>
                <div style="height: 30px;">
                </div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender2" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <%--=========================================Start My Code From Here===============================================--%>
                <div class="leaveApplication_container">
                  
                       
                    <table class="container" style="width:1000px;">
                        <tr class="row">
                            <td colspan="5" class="text-center">
                                <h4>Delivery Challan Customize Report</h4>
                            </td>
                        </tr>
                      
                        <tr>
                            <td style="text-align: left;" class="">
                                <asp:Label ID="lblUnitName" runat="server" CssClass="lbl" Text="Unit Name:"></asp:Label></td>
                            <td style="text-align: left;" class="">
                               <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="true" AutoPostBack="True" runat="server" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList>


                            </td>
                            <td style="text-align: left;" class="">
                                <asp:Label ID="lblShipPoint" runat="server" CssClass="lbl" Text="Ship Point:"></asp:Label></td>
                            <td style="text-align: left;" class="">
                                <asp:DropDownList ID="ddlshippoint" CssClass="ddList" Font-Bold="true" AutoPostBack="True" runat="server" OnSelectedIndexChanged="ddlshippoint_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                           <td style="text-align: left;">
                                <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Customer Type:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlCustomerType" CssClass="ddList" Font-Bold="true" AutoPostBack="True" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            
                            <td style="text-align: left;">
                                <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="From Date:"></asp:Label>&nbsp;</td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" EnableCaching="false" placeholder="click here" autocomplete="off" onkeypress="if ( isNaN( String.fromCharCode(event.keyCode) )) return false;"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" SelectedDate="<%# DateTime.Today %>" StartDate="<%# DateTime.Today %>" EndDate="<%# DateTime.Now.AddYears(1) %>" Format="yyyy-MM-dd" TargetControlID="txtFromDate">
                                </cc1:CalendarExtender>
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="Label7" runat="server" CssClass="lbl" Text="To Date:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" autocomplete="off" EnableCaching="false" placeholder="click here" onkeypress="if ( isNaN( String.fromCharCode(event.keyCode) )) return false;"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" SelectedDate="<%# DateTime.Today %>" StartDate="<%# DateTime.Today %>" EndDate="<%# DateTime.Now.AddYears(1) %>" Format="yyyy-MM-dd" TargetControlID="txtToDate">
                                </cc1:CalendarExtender>
                            </td>
                            <td style="text-align: left;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Code:"></asp:Label></td>
                            <td style="text-align: left;"><asp:TextBox ID="txtCode" CssClass="txtBox" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            
                            <td style="text-align: left;"><asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Enable:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:RadioButtonList ID="rdoEnable" runat="server" RepeatDirection="Horizontal"
                                    AutoPostBack="True">
                                    <asp:ListItem Selected="True" Value="True">Yes</asp:ListItem>
                                    <asp:ListItem Value="False">No</asp:ListItem>
                                </asp:RadioButtonList></td>
                            <td style="text-align: left;"><asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Challan Completed:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:RadioButtonList ID="rdoComplete" runat="server" RepeatDirection="Horizontal"
                                    AutoPostBack="True">
                                    <asp:ListItem Selected="True" Value="True">Yes</asp:ListItem>
                                    <asp:ListItem Value="False">No</asp:ListItem>
                                </asp:RadioButtonList></td>
                            </td>
                            <td style="text-align: left;"><asp:Label ID="Label6" runat="server" CssClass="lbl" Text="DO:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:RadioButtonList ID="rdoDO" runat="server" RepeatDirection="Horizontal"
                                    AutoPostBack="True">
                                    <asp:ListItem Selected="True" Value="True">Yes</asp:ListItem>
                                    <asp:ListItem Value="False">No</asp:ListItem>
                                </asp:RadioButtonList></td>
                            </td>

                        </tr>
                        <tr>
                            <td colspan="6">
                            <asp:Button ID="btnShow" runat="server" class="btn btn-primary btn-sm pull-right" Text="Show" OnClick="btnShow_Click" OnClientClick="return validation();" />
                             </td>  
                        </tr>

                    </table>

                </div>



                <iframe runat="server" oncontextmenu="return false;" id="frame" name="frame" style="width: 100%; height: 600px; border: 0px solid red;"></iframe>
                <%--sandbox="allow-same-origin allow-scripts allow-popups allow-forms"--%>
                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    <script type="text/javascript">
        $(document).ready(function () {
           
        });
        function validation() {
            debugger;
            var code = document.getElementById("txtCode").value;
            var FromDate = document.getElementById("txtFromDate").value;
            var ToDate = document.getElementById("txtToDate").value;
            if (code === null || code === "") {
                ShowNotification('Please Enter code', 'Delivery Challan Customize', 'warning');
                return false;
            }
            else if (FromDate === null || FromDate === "") {
                ShowNotification('Please Enter From Date', 'Delivery Challan Customize', 'warning');
                return false;
            }
            else if (ToDate === null || ToDate === "") {
                ShowNotification('Please Enter To Date', 'Delivery Challan Customize', 'warning');
                return false;
            }
            return true;
        }
    </script>
</body>
</html>


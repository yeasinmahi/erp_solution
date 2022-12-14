<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Invoice_Print_Report.aspx.cs" Inherits="UI.SAD.Sales.Report.Invoice_Print_Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>.: Invoice Print Report :.</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-Frame-Options" content="allow" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/updatedJs") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/updatedCss" />
    <link href="../Content/CSS/CommonStyle.css" rel="stylesheet" />
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
    <style>
        .input-xs {
            height: 22px;
            padding: 2px 5px;
            font-size: 12px;
            line-height: 1.5;
        }
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
                            <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                        </marquee>
                    </div>
                </asp:Panel>
                <div style="height: 30px;">
                </div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender2" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <%--=========================================Start My Code From Here===============================================--%>
                <div class="leaveApplication_container">
                    <table>
                        <tr>
                            <td colspan="10">
                                <h4>Invoice Print Report</h4>
                            </td>
                        </tr>
                        <tr>
                            <td>Customer:</td>
                            <td>
                                <asp:DropDownList ID="ddlCustomer" CssClass="form-control input-xs" Font-Bold="true" AutoPostBack="True" runat="server"></asp:DropDownList>
                            </td>
                            <td style="width: 30px;"></td>
                            <td>From Date:</td>
                            <td>
                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control input-xs" Enabled="true" placeholder="click here" AutoComplete="off"></asp:TextBox>
                                <cc1:CalendarExtender ID="fd" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender>
                            </td>
                            <td style="width: 30px;"></td>
                            <td>To Date:</td>
                            <td>
                                <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control input-xs" Enabled="true" placeholder="click here" AutoComplete="off"></asp:TextBox>
                                <cc1:CalendarExtender ID="td" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender>
                            </td>
                            <td style="width: 30px;"></td>
                            <td>
                                <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-sm btn-primary" OnClick="btnShow_Click"></asp:Button></td>
                        </tr>
                    </table>

                </div>



                <iframe runat="server" oncontextmenu="return false;" id="frame" name="frame" style="width: 100%; height: 1000px; border: 0px solid red;"></iframe>
                <%--sandbox="allow-same-origin allow-scripts allow-popups allow-forms"--%>
                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>

    <script type="text/javascript">

</script>
</body>
</html>

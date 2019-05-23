<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DR_Access_Finished_Goods_Stock.aspx.cs" Inherits="UI.SAD.Sales.Report.DR_Access_Finished_Goods_Stock" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>.: DR Access Finished Goods Stock :.</title>
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
                    <table>
                        <tr>
                            <td colspan="6">
                                <h4>DR Access Finished Goods Stock Report</h4>
                            </td>
                        </tr>
                        <tr>
                            <td>Unit:</td>
                            <td>
                                <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="true" AutoPostBack="True" runat="server" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                            <td style="width: 30px;"></td>
                            <td>Shipping Point:</td>
                            <td>
                                <asp:DropDownList ID="ddlShipPoint" CssClass="ddList" Font-Bold="true" AutoPostBack="True" runat="server"></asp:DropDownList>
                            </td>
                            <td>Stock Status TypeID:</td>
                            <td>
                                <asp:TextBox ID="txtStockStatus" runat="server" CssClass="txtBox1"></asp:TextBox>
                            </td>
                            <td style="width: 30px;"></td>
                            <td><asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-sm btn-primary" OnClick="btnShow_Click"></asp:Button></td>
                        </tr>
                    </table>

                </div>



                <iframe runat="server" oncontextmenu="return false;" id="frame" name="frame" style="width: 100%; height: 1000px; border: 0px solid red;"></iframe>
                <%--sandbox="allow-same-origin allow-scripts allow-popups allow-forms"--%>
                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>

</body>
</html>

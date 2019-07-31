<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AGLandDeedReport.aspx.cs" Inherits="UI.Property.AGLandDeedReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AG Land Deed Report</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
        <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
    </asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../Content/CSS/AutoComplete.css" rel="stylesheet" />
    <script src="../Content/JS/datepickr.min.js"></script>
    <script src="../Content/JS/JSSettlement.js"></script>
    <link href="../Content/CSS/jquery-ui.css" rel="stylesheet" />
    <link href="../Content/CSS/Application.css" rel="stylesheet" />
    <script src="../Content/JS/jquery-3.3.1.js"></script>
    <script src="../Content/JS/jquery-ui.min.js"></script>
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />
    <script>
        $(document).ready(function () {
            Init();
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(Init);

        });
        function Init() {

        }
    </script>
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
    <form id="frmAGLandPlotByMouza" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                        <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div>
                </asp:Panel>
                <div style="height: 100px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <asp:HiddenField ID="hdnconfirm" runat="server" />
                <div class="divbody" style="padding-right: 10px;">
                    <div class="tabs_container" style="background-color: #dcdbdb; padding-top: 10px; padding-left: 5px; padding-right: -50px; border-radius: 5px;">
                        AG Land Deed Report<hr />
                    </div>
                    <table style="width: auto; float: left;">
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Unit Name :"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlUnit" CssClass="ddList" runat="server" Width="220px" Height="23px">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label6" runat="server" Text=""></asp:Label></td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblMouzaName" runat="server" CssClass="lbl" Text="Mouza Name :"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlMouzaName" CssClass="ddList" runat="server" Width="220px" Height="23px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblPlotType" runat="server" CssClass="lbl" Text="Plot Type : "></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlPlotType" CssClass="ddList" runat="server" Width="220px" Height="23px">
                                </asp:DropDownList></td>
                            <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblDeedYear" runat="server" CssClass="lbl" Text="Deed Year : "></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlDeedYear" CssClass="ddList" runat="server" Width="220px" Height="23px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblPlotNo" runat="server" CssClass="lbl" Text="Plot No : "></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtPlotNo" CssClass="txtBox1" runat="server"></asp:TextBox>
                                <asp:HiddenField runat="server" ID="hfPlotID" />
                            </td>
                            <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Deed No : "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDeedNo" CssClass="txtBox1" runat="server"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" CssClass="lbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label5" runat="server" CssClass="lbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label7" runat="server" CssClass="lbl" Text=""></asp:Label>
                            </td>
                            <td colspan="3">
                                <asp:Button ID="btnClear" runat="server" Style="float: right" class="myButton" Text="Clear" Width="100px" OnClick="btnClear_Click" />
                                <asp:Button ID="btnShow" runat="server" Style="float: right" class="myButton" Text="Show" Width="100px" OnClick="btnShow_Click" />
                            </td>
                        </tr>

                    </table>
                </div>
                <div>
                    <iframe runat="server" oncontextmenu="return false;" id="frame" name="frame" style="width: 100%; height: 1000px; border: 0px solid red;"></iframe>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

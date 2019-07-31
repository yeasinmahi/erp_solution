<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GLCodeEntryNreport.aspx.cs" Inherits="UI.Accounts.ChartOfAccount.GLCodeEntryNreport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GL Code Entry & Report</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
        <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
    </asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="../../Content/CSS/jquery-ui.css" rel="stylesheet" />
    <link href="../../Content/CSS/Application.css" rel="stylesheet" />
    <script src="../../Content/JS/jquery-3.3.1.js"></script>
    <script src="../../Content/JS/jquery-ui.min.js"></script>
    <script src="../../Content/JS/CustomizeScript.js"></script>
    <link href="../../Content/CSS/Gridstyle.css" rel="stylesheet" />
</head>
<body>
    <form id="frmGLCodeEntry" runat="server">
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
                <asp:HiddenField ID="hfConfirm" runat="server" />
                <div class="divbody" style="padding-right: 10px;">
                    <div class="tabs_container" style="background-color: #dcdbdb; padding-top: 10px; padding-left: 5px; padding-right: -50px; border-radius: 5px;">
                        GL Code Entry & Report<hr />
                    </div>
                    <table style="width: auto; float: left;">
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="label1" runat="server" CssClass="lbl" Text="Unit:"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlUnit" CssClass="ddList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList>
                                <asp:HiddenField ID="hfUnitID" runat="server" />
                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="label2" runat="server" CssClass="lbl" Text="GLCode Name: "></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtGLCodeName" CssClass="txtBox1" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                           <td style="text-align: right;">
                                <asp:Label ID="label3" runat="server" CssClass="lbl" Text="Dr.GLCode: "></asp:Label>
                           </td>
                            <td>
                                <asp:TextBox ID="txtDrGLCode" CssClass="txtBox1" runat="server"></asp:TextBox>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="label4" runat="server" CssClass="lbl" Text="Cr.GLCode: "></asp:Label>
                           </td>
                            <td>
                                <asp:TextBox ID="txtCrGLCode" CssClass="txtBox1" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;"></td>
                            <td style="text-align: right;"></td>
                            <td style="text-align: right;"></td>
                            <td style="text-align: right;">
                                <asp:Button ID="btnGLCodeSubmit" runat="server" Style="float: right" class="myButton" Text="Submit" Width="100px" OnClientClick="Confirms();" OnClick="btnGLCodeSubmit_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    <script type="text/javascript">
        function Confirms() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) {
                confirm_value.value = "Yes";
                document.getElementById("hfConfirm").value = "1";
            } else {
                confirm_value.value = "No";
                document.getElementById("hfConfirm").value = "0";
            }

        }
    </script>
</body>
</html>

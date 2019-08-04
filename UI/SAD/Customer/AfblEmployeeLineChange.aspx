<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AfblEmployeeLineChange.aspx.cs" Inherits="UI.SAD.Customer.AfblEmployeeLineChange" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AFBL Employee Line Change</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/Gridstyle.css" rel="stylesheet" />
</head>
<body>
    <form id="frmEmployeeSearch" runat="server">
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
                <asp:HiddenField ID="hdnLevelId" runat="server" />
                <div class="divbody" style="padding-right: 10px;">
                    <div class="tabs_container" style="background-color: #dcdbdb; padding-top: 10px; padding-left: 5px; padding-right: -50px; border-radius: 5px;">
                        AFBL Employee Line Update<hr />
                    </div>
                    <table style="width: auto; float: left;">
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblEnroll" runat="server" Text=" Enroll"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtEnroll" CssClass="txtBox1" Width="220px" Height="23px" runat="server"></asp:TextBox>
                            </td>
                            <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label4" runat="server" Text=""></asp:Label></td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblEmpName" runat="server" Text=" Employee name"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtEmpname" CssClass="txtBox1" BackColor="WhiteSmoke" Width="220px" Height="23px" ReadOnly="true" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblLineName" runat="server" Text="Line Name"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtLineName" CssClass="txtBox1" BackColor="WhiteSmoke" Width="220px" Height="23px" ReadOnly="true" runat="server"></asp:TextBox>
                            </td>
                            <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblNewLine" runat="server" CssClass="lbl" Text="New Line "></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlNewLine" CssClass="ddList" runat="server" Width="220px" Height="23px"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label12" runat="server" CssClass="lbl" Text=""></asp:Label>
                                  <asp:HiddenField ID="hdnEnroll" runat="server" />
                            </td>
                            <td>
                                <asp:Label ID="Label13" runat="server" CssClass="lbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label14" runat="server" CssClass="lbl" Text=""></asp:Label>
                            </td>
                            <td colspan="3">
                                <asp:Button ID="btnGetEnroll" runat="server" Style="float: right" class="myButton" Text="Get Employee" Width="120px" OnClick="btnGetEnroll_Click" />
                                <asp:Button ID="btnChangeLine" runat="server" Style="float: right" class="myButton" Text="Update Line" Width="120px" OnClick="btnChangeLine_Click" />
                            </td>
                        </tr>
                    </table>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AfblTerritorySetup.aspx.cs" Inherits="UI.SAD.Setup.AfblTerritorySetup" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AFBL Territory Setup</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
        <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
    </asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    <script src="../../Content/JS/CustomizeScript.js"></script>
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/Gridstyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/Application.css" rel="stylesheet" />

    <script>
        function onlyNumbers(evt) {
            var e = event || evt;
            var charCode = e.which || e.keyCode;

            if ((charCode > 57))
                return false;
            return true;
        }
    </script>
</head>
<body>
    <form id="frmTerritory" runat="server">
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
                <cc1:alwaysvisiblecontrolextender targetcontrolid="pnlUpperControl" id="AlwaysVisibleControlExtender1" runat="server">
                </cc1:alwaysvisiblecontrolextender>
                <%--=========================================Start===============================================--%>
                <asp:HiddenField ID="hdnconfirm" runat="server" />

                <div class="divbody" style="padding-right: 10px;">
                    <div class="tabs_container" style="background-color: #dcdbdb; padding-top: 10px; padding-left: 5px; padding-right: -50px; border-radius: 5px;">
                        AFBL Area Setup<hr />
                    </div>
                    <table style="width: auto; float: left;">
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblExLineName" runat="server" CssClass="lbl" Text="Line Name :"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlExLineName" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="23px"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlExLineName_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblExRegion" runat="server" CssClass="lbl" Text="Region Name"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlExRegion" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="23px"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlExRegion_SelectedIndexChanged">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblExAreaName" runat="server" CssClass="lbl" Text="Area Name"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlExArea" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="23px"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlExArea_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                              <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Exist Territory Name"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlExTerritory" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="23px"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlExTerritory_SelectedIndexChanged">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <hr />
                            </td>
                        </tr>
                        <tr>

                            <td style="text-align: right;">
                                <asp:Label ID="lblLineName" runat="server" CssClass="lbl" Text="New Territory Name"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtTerritory" runat="server" CssClass="txtBox1"></asp:TextBox></td>
                            <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblPhoneNo" runat="server" CssClass="lbl" Text="Official Phone No"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtPhoneNo" runat="server" onkeypress="return onlyNumbers();" CssClass="txtBox1"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="5" style="text-align: right; padding: 0px 0px 0px 0px">&nbsp&nbsp
                                <asp:Button ID="btnCreate" runat="server" class="myButton" Text="Create" Width="100px" OnClientClick="ConfirmAll()" OnClick="btnCreate_Click" />
                                &nbsp&nbsp<asp:Button ID="btnUpdate" runat="server" class="myButton" Text="Update" Width="100px" OnClientClick="ConfirmAll()" OnClick="btnUpdate_Click" />
                                &nbsp&nbsp<asp:Button ID="btnClear" runat="server" class="myButton" Text="Clear" Width="100px" OnClick="btnClear_Click" />
                            </td>
                        </tr>
                    </table>
                </div>

                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

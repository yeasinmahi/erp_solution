<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AfblLocationTransfer.aspx.cs" Inherits="UI.SAD.Setup.AfblLocationTransfer" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AFBL Location Transfer</title>
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
</head>
<body>
    <form id="frmTransfer" runat="server">
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
                <%--=========================================Start===============================================--%>
                <asp:HiddenField ID="hdnconfirm" runat="server" />

                <div class="divbody" style="padding-right: 10px;">
                    <div class="tabs_container" style="background-color: #dcdbdb; padding-top: 10px; padding-left: 5px; padding-right: -50px; border-radius: 5px;">
                        AFBL Location Transfer<hr />
                    </div>
                    <table style="width: auto; float: left;">
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblCatagory" runat="server" CssClass="lbl" Text="Transfer Catagory :"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlCatagory" CssClass="ddList" runat="server" AutoPostBack="True" Width="220px" Height="23px" OnSelectedIndexChanged="ddlCatagory_SelectedIndexChanged">
                                    <asp:ListItem Value="0">Select</asp:ListItem>                                    
                                    <asp:ListItem Value="1">Area</asp:ListItem>
                                    <asp:ListItem Value="2">Territory</asp:ListItem>
                                    <asp:ListItem Value="3">Point</asp:ListItem>
                                    <asp:ListItem Value="4">Section</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblExLineName" runat="server" CssClass="lbl" Text="Exist Line Name :"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlExLineName" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="23px"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlExLineName_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblExRegion" runat="server" CssClass="lbl" Text="Exist Region Name"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlExRegion" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="23px"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlExRegion_SelectedIndexChanged">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblExAreaName" runat="server" CssClass="lbl" Visible="false" Text="Exist Area Name"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlExArea" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="23px"
                                   Visible="false" AutoPostBack="True" OnSelectedIndexChanged="ddlExArea_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label2" runat="server" Visible="false" Text=""></asp:Label></td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblExTerritory" runat="server" CssClass="lbl" Visible="false" Text="Exist Territory Name"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlExTerritory" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="23px"
                                   Visible="false"  AutoPostBack="True" OnSelectedIndexChanged="ddlExTerritory_SelectedIndexChanged">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblExPoint" runat="server" CssClass="lbl" Visible="false" Text="Exist Dis. Point Name"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlExPointName" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="23px"
                                    Visible="false" AutoPostBack="True" OnSelectedIndexChanged="ddlExPointName_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label6" Visible="false" runat="server" Text=""></asp:Label></td>
                            <td style="text-align: right; width: 15px;">
                                <asp:Label ID="lblExSection" runat="server" Visible="false" CssClass="lbl" Text="Exist Section Name"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlExSectionName" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="23px"
                                    visible="false" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="5">
                                <hr />
                            </td>
                        </tr>

                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="New Line Name :"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlNLine" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="23px"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlNLine_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label7" runat="server" Text=""></asp:Label></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label8" runat="server" CssClass="lbl" Text="New Region Name"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlNRegion" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="23px"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlNRegion_SelectedIndexChanged">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblNArea" runat="server" Visible="false" CssClass="lbl" Text="New Area Name"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlNArea" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="23px"
                                   Visible="false"  AutoPostBack="True" OnSelectedIndexChanged="ddlNArea_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label11" runat="server" Text=""></asp:Label></td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblNTerritory" runat="server" Visible="false" CssClass="lbl" Text="New Territory Name"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlNTerritory" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="23px"
                                   Visible="false" AutoPostBack="True" OnSelectedIndexChanged="ddlNTerritory_SelectedIndexChanged">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblNPoint" runat="server" Visible="false" CssClass="lbl" Text="New Dis. Point Name"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlNPointName" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="23px"
                                   Visible="false" AutoPostBack="True" OnSelectedIndexChanged="ddlNPointName_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label14" runat="server" Text=""></asp:Label></td>
                            <td style="text-align: right; width: 15px;">
                                <asp:Label ID="lblNSection" runat="server" Visible="false" CssClass="lbl" Text="New Section Name"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlNSection" Visible="false" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="23px"
                                    AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                         <tr>
                            <td colspan="5">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" style="text-align: right; padding: 0px 0px 0px 0px">
                                &nbsp&nbsp<asp:Button ID="btnClear" runat="server" class="myButton" Text="Clear" Width="100px" OnClick="btnClear_Click" />
                                &nbsp&nbsp
                                <asp:Button ID="btnTransfer" runat="server" class="myButton" Text="Transfer" Width="120px" OnClientClick="ConfirmAll()" OnClick="btnTransfer_Click" />
                            </td>
                        </tr>
                    </table>
                </div>

                <%--=========================================End=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

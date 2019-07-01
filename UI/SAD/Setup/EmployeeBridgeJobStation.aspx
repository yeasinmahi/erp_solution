<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeBridgeJobStation.aspx.cs" Inherits="UI.SAD.Setup.EmployeeBridgeJobStation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Jobstation Bridge</title>
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
    <form id="frmJobstation" runat="server">
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
                <asp:HiddenField ID="hdnEnroll" runat="server" />
                <asp:HiddenField ID="hdnUnit" runat="server" />

                <div class="divbody" style="padding-right: 10px;">
                    <div class="tabs_container" style="background-color: #dcdbdb; padding-top: 10px; padding-left: 5px; padding-right: -50px; border-radius: 5px;">
                        Employee Job Station Bridge<hr />
                    </div>
                    <table class="tblRegion" style="width: auto; float: left;">
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblJobstation" runat="server" CssClass="lbl" Text="Jobstation:"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlJobStation" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="23px" AutoPostBack="false"></asp:DropDownList>
                            </td>
                            <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label13" runat="server" Text=""></asp:Label>
                            </td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblCustomer" runat="server" Text="Customer : "></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlCustomer" CssClass="ddList" Font-Bold="False" runat="server" Width="250px" Height="23px" AutoPostBack="false"></asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="5" style="text-align: right; padding: 0px 0px 0px 0px">&nbsp&nbsp
                                <asp:Button ID="btnSubmit" runat="server" class="myButtonGrey" Text="Bridge Submit" OnClientClick="ConfirmAll()" OnClick="btnSubmit_Click" />
                                &nbsp&nbsp
                                <asp:Button ID="btnGEORemove" runat="server" class="myButtonGrey" Text="Bridge Remove" OnClientClick="ConfirmAll()" OnClick="btnGEORemove_Click" />
                                &nbsp&nbsp
                                <asp:Button ID="btnDoubleBridgeRemove" runat="server" class="myButtonGrey" Text="Double Bridge Remove" OnClientClick="ConfirmAll()" OnClick="btnDoubleBridgeRemove_Click" />

                                &nbsp&nbsp
                                <asp:Button ID="btnBridgeReport" runat="server" class="myButtonNew" Text="Bridge Report" OnClick="btnBridgeReport_Click" />
                                &nbsp&nbsp
                                <asp:Button ID="btnNoBridgeReport" runat="server" class="myButtonNew" Text="No Bridge Report" OnClick="btnNoBridgeReport_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="divGrV" style="padding-right: 10px;">
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="dgvJSBridgeList" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
                                    CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true"
                                    HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
                                    FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" 
                                    FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL No.">
                                            <ItemStyle HorizontalAlign="center" Width="60px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Job Station Name" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblJobStationName" runat="server" Text='<%# Bind("strPName") %>' Width="180px"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" Width="180px" />
                                        </asp:TemplateField>

                                          <asp:TemplateField HeaderText="Job Station ID" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblJobStationID" runat="server" Text='<%# Bind("intPointId") %>' Width="80px"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" Width="80px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Customer Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCustName" runat="server" Text='<%# Bind("strCName") %>' Width="300px"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" Width="300px" />
                                        </asp:TemplateField>                                       

                                    </Columns>
                                    <HeaderStyle BackColor="#2eb8b8" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                </asp:GridView>
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

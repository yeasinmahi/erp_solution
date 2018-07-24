<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StarConsumeReport.aspx.cs" Inherits="UI.SAD.Consumer.StarConsumeReport" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

</head>
<body>
    <form id="frmpdv" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div>
                </asp:Panel>
                <div style="height: 100px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>

                <%--=========================================Start My Code From Here===============================================--%>
                <div class="leaveApplication_container">
                    <table>
                        <tr class="tblroweven">
                            <td>
                                <asp:GridView ID="grdvDoubleCashOfferReport" runat="server" AutoGenerateColumns="false" RowStyle-Wrap="true" HeaderStyle-Wrap="true">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL.">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="strName" HeaderText="Shop Name" SortExpression="strName" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="intShopId" HeaderText="Shop Id" SortExpression="intShopId" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="strName" HeaderText="Customer Name" SortExpression="strName" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="territoryName" HeaderText="Territory" SortExpression="territoryName" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="area" HeaderText="Area " SortExpression="area" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="region" HeaderText="Region" SortExpression="region" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="intSiteCardCode" HeaderText="Site Card Code" SortExpression="intSiteCardCode" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="decQntForSiteCard" HeaderText="Quantity via Side Code" SortExpression="decQntForSiteCard" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="decShopvsDelvQnt" HeaderText="Quantity shop vs Deviv" SortExpression="decShopvsDelvQnt" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="monEditedTotalCost" HeaderText="Edited Total Cost" SortExpression="monEditedTotalCost" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="dteFormDate" HeaderText="From Date" SortExpression="dteFormDate" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="dteToDate" HeaderText="To Date" SortExpression="dteToDate" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="dteInsertionDate" HeaderText="Insertion Date" SortExpression="dteInsertionDate" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        
                                        <%--<asp:CommandField ControlStyle-BackColor="#ff9900" ShowDeleteButton="True" />--%>
                                    </Columns>
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



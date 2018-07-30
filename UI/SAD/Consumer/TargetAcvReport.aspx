<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TargetAcvReport.aspx.cs" Inherits="UI.SAD.Consumer.TargetAcvReport" %>
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
                    <div class="tabs_container">
                        Star Consumer Bill Entry :
                        <asp:HiddenField ID="hdUnitId" runat="server" />
                    </div>
                    <table border="0" style="width: Auto">
                        <tr class="tblroweven">
                            <td style="text-align: right;">
                                <asp:Label ID="lbl1" CssClass="lbl" runat="server" Text="From Date"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="fromTextBox" AutoPostBack="false" runat="server" CssClass="txtBox"></asp:TextBox>
                                <script>$('#fromTextBox').datepicker();</script>
                            </td>
                            
                            <td style="text-align: right;">
                                <asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="toTextBox" AutoPostBack="false" runat="server" CssClass="txtBox"></asp:TextBox>
                                <script>$('#toTextBox').datepicker();</script>
                            </td>
                        </tr>
                        <tr class="tblroweven">
                            <td>
                                <asp:Button ID="showReport" runat="server" BackColor="#ffcccc" Font-Bold="true" Text="Show" OnClick="showReport_OnClick" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="leaveApplication_container">
                    <table>
                        <tr class="tblroweven">
                            <td>
                                <asp:GridView ID="grdv" runat="server" AutoGenerateColumns="false" RowStyle-Wrap="true" HeaderStyle-Wrap="true">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL.">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="intDispid" HeaderText="Shop Id" SortExpression="intDispid" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="strDispointName" HeaderText="Dispoint Name" SortExpression="strDispointName" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <%--<asp:BoundField DataField="strPhone" HeaderText="Phone" SortExpression="strPhone" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="strTerritory" HeaderText="Territory" SortExpression="strTerritory" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />--%>
                                        <asp:BoundField DataField="strDistr" HeaderText="District" SortExpression="strDistr" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="intCustomerid" HeaderText="CustomerId" SortExpression="intCustomerid" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="strSalesOffice" HeaderText="Sales Office" SortExpression="strSalesOffice" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="decQntFirstMonth" HeaderText="Quantity First Month" SortExpression="decQntFirstMonth" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="decQntSecondMonth" HeaderText="Quantity Second Month" SortExpression="decQntSecondMonth" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="total" HeaderText="Total" SortExpression="total" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="decTarget" HeaderText="Target" SortExpression="decTarget" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        
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


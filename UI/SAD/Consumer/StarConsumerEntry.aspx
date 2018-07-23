<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StarConsumerEntry.aspx.cs" Inherits="UI.SAD.Consumer.StarConsumerEntry" %>
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
                            <td style="text-align: right;">
                                <asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Teritory"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlTeritory" CssClass="ddList" runat="server"></asp:DropDownList>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Program"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlProgram" CssClass="ddList" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr class="tblroweven">
                            <td>
                                <asp:Button ID="showReport" runat="server" BackColor="#ffcccc" Font-Bold="true" Text="Show" OnClick="showReport_OnClick" />
                            </td>
                            <td>
                                <asp:Button ID="showFullReport" runat="server" BackColor="#ffcccc" Font-Bold="true" Text="Report" OnClick="showFullReport_OnClick" OnClientClick="aspnetForm.target ='_blank'" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="leaveApplication_container">
                    <table>
                        <tr class="tblroweven">
                            <td>
                                <asp:GridView ID="grdvDoubleCashOffer" runat="server" AutoGenerateColumns="false" RowStyle-Wrap="true" HeaderStyle-Wrap="true" OnSelectedIndexChanged="grdvOvertimeEntry_SelectedIndexChanged" OnRowDeleting="grdvOvertimeEntry_OnRowDeletingmeEntry_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL.">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                                <asp:HiddenField ID="dispId" runat="server" Value='<%# Bind("intDispid") %>' />
                                                <asp:HiddenField ID="strTerritory" runat="server" Value='<%# Bind("strTerritory") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
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
                                        <asp:TemplateField HeaderText="Side Code">
                                            <ItemTemplate>
                                                <asp:TextBox ID="siteCode" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <asp:TextBox ID="quantity" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Commision Amount">
                                            <ItemTemplate>
                                                <asp:TextBox ID="commisionAmount" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="User Details">
                                            <ItemTemplate>
                                                <asp:TextBox ID="userDetails" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:Button ID="add" runat="server" BackColor="#ffcccc" Font-Bold="true" Text="Add" OnClick="add_OnClick" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
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


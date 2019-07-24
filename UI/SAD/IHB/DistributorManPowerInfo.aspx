<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DistributorManPowerInfo.aspx.cs" Inherits="UI.SAD.IHB.DistributorManPowerInfo" %>
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
                            <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                         </marquee>
                    </div>
                    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div>
                </asp:Panel>
                <div style="height: 100px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>

                <%--=========================================Start My Code From Here===============================================--%>

                <div class="leaveApplication_container">
                    <div class="tabs_container">
                        Distributor Manpower Setup
                        <asp:HiddenField ID="hdUnitId" runat="server" />
                    </div>
                    <table border="0" style="width: Auto">
                        <tr class="tblroweven">
                            <td style="text-align: right;">
                                <asp:Label ID="lbl1" CssClass="lbl" runat="server" Text="From Date"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="fromTextBox" AutoPostBack="false" runat="server" CssClass="txtBox" autocomplete="off"></asp:TextBox>
                                <script>$('#fromTextBox').datepicker();</script>
                            </td>
                            
                            <td style="text-align: right;">
                                <asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="toTextBox" AutoPostBack="false" runat="server" CssClass="txtBox" autocomplete="off"></asp:TextBox>
                                <script>$('#toTextBox').datepicker();</script>
                            </td>
                        </tr>
                        <tr class="tblroweven">
                            <td style="text-align: right;">
                                <asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Customer"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlCustomer" CssClass="ddList" runat="server"></asp:DropDownList>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Manager"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="managerTextBox" AutoPostBack="false" runat="server" CssClass="txtBox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="tblroweven">
                            <td style="text-align: right;">
                                <asp:Label CssClass="lbl" runat="server" Text="Sales Representative 1"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="salesRepresentative1TextBox" AutoPostBack="false" runat="server" CssClass="txtBox"></asp:TextBox>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label CssClass="lbl" runat="server" Text="Sales Representative 2"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="salesRepresentative2TextBox" AutoPostBack="false" runat="server" CssClass="txtBox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="tblroweven">
                            <td>
                                <asp:Button ID="addCustomer" runat="server" BackColor="#ffcccc" Font-Bold="true" Text="Add Customer" OnClick="addCustomer_OnClick"/>
                            </td>
                            <td>
                                <asp:Button ID="getInfo" runat="server" BackColor="#ffcccc" Font-Bold="true" Text="Get Info" OnClick="getInfo_OnClick"/>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="leaveApplication_container">
                    <table>
                        <tr class="tblroweven">
                            <td>
                                <asp:GridView ID="grdvDistributorManpower" runat="server" AutoGenerateColumns="false" RowStyle-Wrap="true" HeaderStyle-Wrap="true">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL.">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                                <%--<asp:HiddenField ID="strTerritory" runat="server" Value='<%# Bind("strTerritory") %>' />--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="distributorName" HeaderText="Distributor Name" SortExpression="distributorName" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="intCusID" HeaderText="Cus ID" SortExpression="intCusID" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="strEmailAddress" HeaderText="Email Address" SortExpression="strEmailAddress" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="territory" HeaderText="Territory" SortExpression="territory" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="area" HeaderText="Area" SortExpression="area" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="region" HeaderText="Region" SortExpression="region" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        
                                        <asp:TemplateField HeaderText="Distributor Manager">
                                            <ItemTemplate>
                                                <asp:TextBox ID="strDistrManagerN" Text='<%# Bind("strDistrManagerN") %>' runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sales Representative 1">
                                            <ItemTemplate>
                                                <asp:TextBox ID="strSalesRepresentative1" Text='<%# Bind("strSalesRepresentative1") %>' runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sales Representative 2">
                                            <ItemTemplate>
                                                <asp:TextBox ID="strSalesRepresentative2" Text='<%# Bind("strSalesRepresentative2") %>' runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:Button ID="update" runat="server" BackColor="#ffcccc" Font-Bold="true" Text="Update" OnClick="update_OnClick" />
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


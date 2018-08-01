<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PumpFoodingBillReport.aspx.cs" Inherits="UI.Transport.TripvsCost.PumpFoodingBillReport" %>
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
                        Star Consumer Report :
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
                                <asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Report Type"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlReportType" CssClass="ddList" runat="server" AutoPostBack="False">
                                    <asp:ListItem Text="Top Sheet" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Details" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            
                        </tr>
                        <tr class="tblroweven" runat="server" id="enrollTr">
                            <td style="text-align: right;">
                                <asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Enroll "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="enrollTxt" AutoPostBack="false" runat="server" CssClass="txtBox"></asp:TextBox>
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
                                <asp:GridView ID="grdvTopSheet" runat="server" AutoGenerateColumns="false" RowStyle-Wrap="true" HeaderStyle-Wrap="true">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL.">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
<%--                                                <asp:HiddenField ID="intID" runat="server" Value='<%# Bind("intpkid") %>' />--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="strName" HeaderText="Name" SortExpression="strName" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="intEnroll" HeaderText="Enroll" SortExpression="intEnroll" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="strDesignation" HeaderText="Designation" SortExpression="strDesignation" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="intTripNo" HeaderText="Total Trip" SortExpression="intTripNo" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="decTotalBill" HeaderText="Total Bill " SortExpression="decTotalBill" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        
                                        <%--<asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:Button ID="inActive" runat="server" BackColor="#ffcccc" Font-Bold="true" Text="InActive" OnClick="inActive_OnClick" OnClientClick="return confirm('Are you sure you want to delete?');"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <%--<asp:CommandField ControlStyle-BackColor="#ff9900" ShowDeleteButton="True" />--%>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr class="tblroweven">
                            <td>
                                <asp:GridView ID="grdvDetails" runat="server" AutoGenerateColumns="false" RowStyle-Wrap="true" HeaderStyle-Wrap="true">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL.">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                                <asp:HiddenField ID="intID" runat="server" Value='<%# Bind("intpkid") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="strName" HeaderText="Name" SortExpression="strName" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="intEnroll" HeaderText="Enroll" SortExpression="intEnroll" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="strDesignation" HeaderText="Designation" SortExpression="strDesignation" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="intTripNo" HeaderText="Total Trip" SortExpression="intTripNo" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="decTotalBill" HeaderText="Total Bill " SortExpression="decTotalBill" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="dteInDate" HeaderText="In Date" SortExpression="dteInDate" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="dteOutDate" HeaderText="Out Date" SortExpression="dteOutDate" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="intInsertBy" HeaderText="Insert By" SortExpression="intInsertBy" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="dteInsertionDate" HeaderText="Insertion Date" SortExpression="dteInsertionDate" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:Button ID="inActive" runat="server" BackColor="#ffcccc" Font-Bold="true" Text="InActive" OnClick="inActive_OnClick" OnClientClick="return confirm('Are you sure you want to delete?');"/>
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



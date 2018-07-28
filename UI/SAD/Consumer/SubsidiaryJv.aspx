<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubsidiaryJv.aspx.cs" Inherits="UI.SAD.Consumer.SubsidiaryJv" %>

<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script type="text/javascript">
        function CheckAll(Checkbox) {
            var GridVwHeaderCheckbox = document.getElementById("<%=grdv.ClientID %>");
            for (var i = 1; i < GridVwHeaderCheckbox.rows.length; i++) {
                GridVwHeaderCheckbox.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
            }
        }
    </script>
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
                        Subsidiary JV Creation :
                        <asp:HiddenField ID="totalAmount" runat="server" />
                    </div>
                    <table border="0" style="width: Auto">
                        <tr class="tblroweven">
                            <td style="text-align: right;">
                                <asp:Label ID="lbl1" CssClass="lbl" runat="server" Text="From Date"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="fromTextBox" AutoPostBack="false" runat="server" CssClass="txtBox"></asp:TextBox>
                                <script>$('#fromTextBox').datepicker();
                                </script>
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
                                <asp:DropDownList ID="ddlSalesOffice" CssClass="ddList" runat="server">
                                    <asp:ListItem Text="Enterprise" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="ACRD" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="IHB" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Program"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlType" CssClass="ddList" runat="server">
                                    <asp:ListItem Text="Regular" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Special" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr class="tblroweven">
                            <td style="text-align: right;">
                                <asp:Label ID="Label4" CssClass="lbl" runat="server" Text="Factory Rate"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="factoryRateTextBox" AutoPostBack="false" runat="server" CssClass="txtBox"></asp:TextBox>
                            </td>

                            <td style="text-align: right;">
                                <asp:Label ID="Label5" CssClass="lbl" runat="server" Text="Ghat Rate"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="ghatRateTextBox" AutoPostBack="false" runat="server" CssClass="txtBox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="tblroweven">
                            <td>
                                <asp:Button ID="createSubsidiary" runat="server" BackColor="#ffcccc" Font-Bold="true" Text="Create Subsidiary" OnClick="createSubsidiary_OnClick" />
                            </td>
                            <td>
                                <asp:Button ID="showReport" runat="server" BackColor="#ffcccc" Font-Bold="true" Text="Show" OnClick="showReport_OnClick" OnClientClick="aspnetForm.target ='_blank'" />
                            </td>
                            <td>
                                <asp:Label ID="Label6" CssClass="lbl" runat="server" Text="Created JV No"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="jvNumverLbl" CssClass="lbl" runat="server"  Font-Bold="True" ForeColor="#006600"></asp:Label>
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
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkbx" runat="server" onclick="CheckAll(this);" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="checkBox" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SL.">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                                <%--<asp:HiddenField ID="strTerritory" runat="server" Value='<%# Bind("strTerritory") %>' />--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="customerName" HeaderText="Customer Name" SortExpression="customerName" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="tarritory" HeaderText="Tarritory" SortExpression="tarritory" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <%--<asp:BoundField DataField="strPhone" HeaderText="Phone" SortExpression="strPhone" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="strTerritory" HeaderText="Territory" SortExpression="strTerritory" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />--%>
                                        <asp:BoundField DataField="area" HeaderText="Area" SortExpression="area" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="region" HeaderText="Region" SortExpression="intCustomerid" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="coa" HeaderText="CoA" SortExpression="strSalesOffice" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="qntCustVhFactory" HeaderText="qntCustVhFactory" SortExpression="decQntFirstMonth" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="factoryRate" HeaderText="Factory Rate" SortExpression="decQntSecondMonth" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="factorySubsidiary" HeaderText="Factory Subsidiary" SortExpression="total" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="qntCustVhGhat" HeaderText="qntCustVhGhat" SortExpression="decTarget" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="ghatRate" HeaderText="Ghat Rate" SortExpression="decTarget" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="ghatSubsidiary" HeaderText="Ghat Subsidiary" SortExpression="decTarget" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="totalCusVh" HeaderText="Total Cus Vh" SortExpression="decTarget" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="qntCompanyCustomerVh" HeaderText="qnt Company Customer Vh" SortExpression="decTarget" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="qntCompanyVh" HeaderText="qnt Company Vh" SortExpression="decTarget" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="qntRentedVh" HeaderText="qnt Rented Vh" SortExpression="decTarget" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="totalVh" HeaderText="total Vh" SortExpression="decTarget" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="grandSubsidiary" HeaderText="Grand Subsidiary" SortExpression="decTarget" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="narrations" HeaderText="Narrations" SortExpression="narrations" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />

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


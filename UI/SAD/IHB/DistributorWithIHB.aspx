<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DistributorWithIHB.aspx.cs" Inherits="UI.SAD.IHB.DistributorWithIHB" %>

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
                            <span class="message-text" id="msg">
                                <%# UI.ClassFiles.CommonClass.GetGlobalMessage() %>
                            </span>
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
                        Distributor With IHB :
                        <asp:HiddenField ID="hdCustomerIdEnterprise" runat="server" />
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
                                <asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Region"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlRegion" CssClass="ddList" runat="server" EnableViewState="true" AutoPostBack="True" OnSelectedIndexChanged="ddlRegion_OnSelectedIndexChanged"></asp:DropDownList>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Area"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlArea" CssClass="ddList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlArea_OnSelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr class="tblroweven">
                            <td style="text-align: right;">
                                <asp:Label ID="Label4" CssClass="lbl" runat="server" Text="Teritory"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlTerritory" CssClass="ddList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTerritory_OnSelectedIndexChanged"></asp:DropDownList>
                            </td>

                           
                        </tr>
                        <tr class="tblroweven">
                            <td style="text-align: right;">
                                <asp:Label ID="Label5" CssClass="lbl" runat="server" Text="Distributor"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlDistributor" CssClass="ddList" runat="server"></asp:DropDownList>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label7" CssClass="lbl" runat="server" Text="Acrd"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlIhb" CssClass="ddList" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr class="tblroweven">
                            <td>
                                <asp:Button ID="add" runat="server" BackColor="#ffcccc" Font-Bold="true" Text="Add" OnClick="add_OnClick" />
                            </td>
                            <td>
                                <asp:Button ID="report" runat="server" BackColor="#ffcccc" Font-Bold="true" Text="Report" OnClick="report_OnClick" />
                            </td>
                            
                             <td>
                                <asp:Button ID="btnInactive" runat="server" BackColor="#ffcccc" Font-Bold="true" Text="Delete Bridge" OnClick="btnInactive_Click" />
                            </td>
                             <td>
                                <asp:Button ID="btnupdate" runat="server" BackColor="#ffcccc" Font-Bold="true" Text="Update Bridge" OnClick="btnupdate_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="leaveApplication_container">
                    <table>
                        <tr class="tblroweven">
                            <td>
                                <asp:GridView ID="grdvCustomerWithIhb" runat="server" AutoGenerateColumns="false" RowStyle-Wrap="true" HeaderStyle-Wrap="true">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL.">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="CustIDEntpName" HeaderText="CustIDEntpName" SortExpression="CustIDEntpName" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="intCustIDEntp" HeaderText="intCustIDEntp" SortExpression="intCustIDEntp" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="CustIDIHBName" HeaderText="CustIDIHBName" SortExpression="CustIDIHBName" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="intCustIDIHB" HeaderText="intCustIDIHB" SortExpression="intCustIDIHB" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="intSintSalesOfficeIHBACRDCustalesOffId" HeaderText="intSintSalesOfficeIHBACRDCustalesOffId" SortExpression="intSintSalesOfficeIHBACRDCustalesOffId" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="strIHBModifyPhone" HeaderText="strIHBModifyPhone" SortExpression="strIHBModifyPhone" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        
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

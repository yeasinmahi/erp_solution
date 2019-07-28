<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MDSlipCustomization.aspx.cs" Inherits="UI.Accounts.MDSlip.MDSlipCustomization" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MD Slip Customization</title>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <link href="../../Content/CSS/PropertyStyle.css" rel="stylesheet" />
</head>

<body>
    <form id="frmMDSlipCustomization" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" LoadScriptsBeforeUI="false"></asp:ScriptManager>
        <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
            <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                    scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </marquee>
            </div>
        </asp:Panel>
        <div style="height: 30px;"></div>
        <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
        </cc1:AlwaysVisibleControlExtender>
        <asp:HiddenField ID="hfConfirm" runat="server" />
        <asp:HiddenField ID="hdnconfirm" runat="server" />
        <table class="table70">
            <tr>
                <td class="td-lbl2">
                    <asp:Label ID="Label1" runat="server" CssClass="lbl-txt" Text="Unit :"></asp:Label>
                </td>
                <td class="td-txt-ddl2">
                    <asp:DropDownList runat="server" ID="ddlUnit" CssClass="ddl-field"
                        AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td class="td-lbl2">
                    <asp:Label ID="Label2" CssClass="lbl-txt" runat="server" Text="Grouping Type :"></asp:Label></td>
                <td class="td-txt-ddl2">
                    <asp:DropDownList runat="server" ID="ddlGroupingType" CssClass="ddl-field"
                        AutoPostBack="true" OnSelectedIndexChanged="ddlGroupingType_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="td-lbl2">
                    <asp:Label ID="Label3" runat="server" CssClass="lbl-txt" Text="Custom Name :"></asp:Label>
                </td>
                <td class="td-txt-ddl2">
                    <asp:DropDownList runat="server" ID="ddlCustomName" CssClass="ddl-field"></asp:DropDownList>
                </td>
                <td colspan="2">
                    <%--<asp:Button runat="server" ID="btnRemove" CssClass="btn btn-submit" Text="Remove" OnClick="btnRemove_Click" />
                    <asp:Button runat="server" ID="btnShowChild" CssClass="btnn" Text="Show Child" OnClick="btnShowChild_Click" />
                    <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-add" Text="Add" OnClick="btnAdd_Click" />--%>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label runat="server" ID="lblAccountName" ForeColor="Blue" Font-Bold="true" Visible="false" style="padding-left:20%"></asp:Label>
                    <asp:GridView ID="dgvMDSlipData" runat="server" AutoGenerateColumns="False"
                    Font-Size="11px" BackColor="White" DataKeyNames="intAccID"
                    BorderCor="#999999" BorderStyle="Solid"
                    BorderWidth="1px" CellPadding="5"
                    ForeColor="Black" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:TemplateField HeaderText="SL No.">
                            <ItemStyle HorizontalAlign="center" Width="15px" />
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                                <asp:HiddenField runat="server" ID="hfAccountID" Value='<%# Bind("intAccID") %>'/>
                                <asp:HiddenField runat="server" ID="hfParentID" Value='<%# Bind("intParentID") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Code">
                            <ItemTemplate>
                                <asp:Label ID="lblgvCode" runat="server" Text='<%# Bind("strCode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Account Name">
                            <ItemTemplate>
                                <asp:Label ID="lblgvAccountName" runat="server" Text='<%# Bind("strAccName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Childs">
                            <ItemTemplate>
                                <asp:Label ID="lblgvstrChilds" runat="server" Text='<%# Bind("intChildCount") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>

                          <asp:TemplateField HeaderText="Config">
                            <ItemTemplate>
                                <asp:Button ID="btnShowChild" runat="server" OnClick="btnShowChild_Click" Text="Show Child"></asp:Button>
                                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add"></asp:Button>
                                <asp:Button ID="btnRemove" runat="server" OnClick="btnRemove_Click" Text="Remove"></asp:Button>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>

                        <%--<asp:TemplateField HeaderText="Config">
                            <ItemTemplate>
                                <asp:Label ID="lblgvStrConfig" runat="server" Text='<%# Bind("strConfig") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>--%>

                    </Columns>
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                </asp:GridView>
                </td>
            </tr>
        </table>
        
    </form>
</body>
</html>

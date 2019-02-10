<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierDocView.aspx.cs" Inherits="UI.Inventory.SupplierDocView" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Supplier File Manager</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/updatedJs") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/updatedCss" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel0" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                        <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                </asp:Panel>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>

                <div style="height: 30px; width: 100%"></div>
                <%--=========================================Start My Code From Here===============================================--%>
                <div class="container">
                    <div class="panel panel-default" id="itemPanel">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Supplier Documents Details" Font-Bold="true" Font-Size="16px"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both" Width="100%" OnRowCommand="gridView_OnRowCommand" OnRowDataBound="gridView_OnRowDataBound">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SL">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Doc Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDocId" runat="server" Text='<%# Bind("intDocID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Document Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDocType" runat="server" Text='<%# Bind("strDoctype") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Doc Type Id" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDocTypeId" runat="server" Text='<%# Bind("intDocType") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="File Path">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFtpPath" runat="server" Text='<%# Bind("strFilePath") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action" ItemStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:Button ID="btnDownload" runat="server" class="btn btn-primary form-control" Text="Download" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Download" />
                                            <asp:Button ID="btnView" runat="server" class="btn btn-primary form-control" Text="View File" CommandArgument="<%# Container.DataItemIndex %>" CommandName="View" />
                                        </ItemTemplate>
                                        <ItemStyle Width="200px" />
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>

                        </div>

                    </div>
                    <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

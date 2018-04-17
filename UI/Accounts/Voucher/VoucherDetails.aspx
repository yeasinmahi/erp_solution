<%@ Page Language="C#" Theme="Theme1" AutoEventWireup="true" Inherits="UI.Accounts.Voucher.VoucherDetails" Codebehind="VoucherDetails.aspx.cs" %>

<!DOCTYPE html>
<html >
<head runat="server">
    <title>Voucher Details</title>
     <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/defaultCSS" />
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView SkinID="sknGrid1" ID="GridView1" runat="server" DataSourceID="XmlDataSource1"
            AutoGenerateColumns="False" CaptionAlign="Top" Caption="Journal View" 
            ShowFooter="True" ondatabound="GridView1_DataBound">
            <Columns>
                <asp:TemplateField HeaderText="Account Code" SortExpression="Cat">
                    <FooterStyle HorizontalAlign="Right" />
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("AccCode") %>'></asp:Label>
                    </ItemTemplate>                    
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Account Head" SortExpression="Cat">
                    <FooterStyle HorizontalAlign="Right" />
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Acc") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        Total
                    </FooterTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Narration" SortExpression="Narr">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("Narr") %>'></asp:Label>
                    </ItemTemplate>                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Debit" SortExpression="Dr">
                    <FooterStyle HorizontalAlign="Right" />
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Dr") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Credit" SortExpression="Cr">
                    <FooterStyle HorizontalAlign="Right" />
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Cr") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>                
            </Columns>
        </asp:GridView>
        <asp:XmlDataSource ID="XmlDataSource1" EnableCaching="false" EnableViewState="false"
            runat="server"></asp:XmlDataSource>
    </div>
    </form>
</body>
</html>

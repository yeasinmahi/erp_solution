<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BradndItemRequisitonDetaills.aspx.cs" Inherits="UI.Inventory.BradndItemRequisitonDetaills" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
<webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
</head>
<body>
    <form id="frmdtls" runat="server">
    <asp:GridView ID="dgvlist" runat="server" AutoGenerateColumns="False" Font-Size="11px" BackColor="White" BorderStyle="None" 
        BorderWidth="1px" CellPadding="3" GridLines="Vertical" AllowPaging="True" BorderColor="#999999"><AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
        <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
        <asp:BoundField DataField="DDate" HeaderText="Due Date" ItemStyle-HorizontalAlign="Center" SortExpression="DDate" DataFormatString="{0:yyyy-MM-dd}">
        <ItemStyle HorizontalAlign="Left" Width="75px" /></asp:BoundField> 
        <asp:BoundField DataField="Items" HeaderText="Particulers" ItemStyle-HorizontalAlign="Center" SortExpression="Items">
        <ItemStyle HorizontalAlign="Left" Width="230px"/></asp:BoundField>
        <asp:BoundField DataField="Department" HeaderText="Remarks" ItemStyle-HorizontalAlign="Center" SortExpression="Department">
        <ItemStyle HorizontalAlign="Center" Width="200px"/></asp:BoundField>
        <asp:BoundField DataField="Quantity" HeaderText="Quantity" ItemStyle-HorizontalAlign="Center" SortExpression="Quantity" DataFormatString="{0:0.0000}">
        <ItemStyle HorizontalAlign="right" Width="65px"/></asp:BoundField>
        <asp:BoundField DataField="IssQuantity" HeaderText="I.Quantity" ItemStyle-HorizontalAlign="Center" SortExpression="IssQuantity" DataFormatString="{0:0.0000}">
        <ItemStyle HorizontalAlign="right" Width="65px"/></asp:BoundField>
        <asp:BoundField DataField="Remarks" HeaderText="Status" ItemStyle-HorizontalAlign="Center" SortExpression="Remarks">
        <ItemStyle HorizontalAlign="Center" Width="65px"/></asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
    </form>
</body>
</html>

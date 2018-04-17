<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequisitionDetails.aspx.cs" Inherits="UI.Inventory.RequisitionDetails" %>

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
    <asp:GridView ID="dgvlist" runat="server" AutoGenerateColumns="False" Font-Size="11px" BackColor="White" BorderStyle="Solid" 
        BorderWidth="0px" CellPadding="1" ForeColor="Black" GridLines="Vertical" AllowPaging="True" Pagesize="10"><AlternatingRowStyle BackColor="#CCCCCC" />
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
        </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
    </form>
</body>
</html>

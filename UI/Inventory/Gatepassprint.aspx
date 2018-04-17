<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gatepassprint.aspx.cs" Inherits="UI.Inventory.Gatepassprint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>function Print() {
    var stat = document.getElementById("hdnstatus").value;
    if (stat == 'Approved')
    { document.getElementById("btnprint").style.display = "none"; window.print(); self.close(); }
    else
    { alert('This challan is not approved. Please try later.');}
    
}</script>
</head>
<body>
    <form id="form1" runat="server">    
        <a id="btnprint" href="#" class="nextclick" style="cursor:pointer" onclick="Print()">Print</a><asp:HiddenField ID="hdnstatus" runat="server" />
        <table align="center" border="0"; style="width:500px;"; >
         <tr><td style="text-align:left; width:100px;"><img src="../Content/images/img/ag.png" /></td>
         <td style="text-align:center;font:bold 14px verdana;" colspan="2"><b><u>GATE PASS</u></b><br />
             <asp:Label ID="lblpoint" CssClass="lbl" runat="server" style="font:bold 12px verdana;"></asp:Label><br />
             <asp:Label ID="lbladd" CssClass="lbl" runat="server" style="font:bold 10px verdana;"></asp:Label>
         </td>
        </tr>

        <tr style="font:bold 11px verdana;"><td style="text-align:right; width:100px;"><asp:Label ID="lblc"  runat="server" Text="Challan No : "></asp:Label></td>
        <td><asp:Label ID="lblCN" runat="server"></asp:Label></td>
        <td style="text-align:right;"><asp:Label ID="lbldt" runat="server"></asp:Label></td>
        </tr>
        <tr style="font:bold 11px verdana;"><td style="text-align:right; width:100px;"><asp:Label ID="lblf" runat="server" Text="From -Address : "></asp:Label></td>
        <td colspan="2"><asp:Label ID="lblfadd" runat="server"></asp:Label></td>
        </tr>
        <tr style="font:bold 11px verdana;"><td style="text-align:right; width:100px;"><asp:Label ID="lblt" runat="server" Text="To -Address : "></asp:Label></td>
        <td colspan="2"><asp:Label ID="lbltadd" runat="server"></asp:Label></td>
        </tr>

        <tr><td colspan="3" style="font:normal 10px verdana;">
        <asp:GridView ID="dgv" runat="server" AutoGenerateColumns="False" Font-Size="12px" BackColor="White" BorderColor="#999999" 
        BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Both"><AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
        <asp:BoundField DataField="Description_" HeaderText="Description" ItemStyle-HorizontalAlign="Center" SortExpression="Description_">
        <ItemStyle HorizontalAlign="Left" Width="225px" /></asp:BoundField>
        <asp:BoundField DataField="Quantity" HeaderText="Quantity" ItemStyle-HorizontalAlign="Center" SortExpression="Quantity" DataFormatString="{0:0.0000}">
        <ItemStyle HorizontalAlign="Center" Width="70px"/></asp:BoundField> 
        <asp:BoundField DataField="Uom" HeaderText="Uom" ItemStyle-HorizontalAlign="Center" SortExpression="Uom">
        <ItemStyle HorizontalAlign="Center" Width="70px"/></asp:BoundField> 
        <asp:BoundField DataField="Remarks" HeaderText="Remarks" ItemStyle-HorizontalAlign="Center" SortExpression="Remarks">
        <ItemStyle HorizontalAlign="Left" Width="200px"/></asp:BoundField>
        </Columns>
        <HeaderStyle BorderStyle="Solid" BorderColor="Black" BorderWidth="1px" Font-Bold="True"/><PagerStyle BackColor="#999999" ForeColor="Black" BorderStyle="Solid" BorderWidth="1px" BorderColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
        </td></tr>

        <tr style="font:bold 9px verdana;"><td style="text-align:left; width:100px;" colspan="3"><br /><br />
        <asp:Label ID="issby" runat="server"></asp:Label><br /><br /><asp:Label ID="appby" runat="server"></asp:Label></td>
        </tr>
        </table>

    </form>
</body>
</html>

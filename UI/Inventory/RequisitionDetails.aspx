<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequisitionDetails.aspx.cs" Inherits="UI.Inventory.RequisitionDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
<webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script>
     function Print() {
             
         document.getElementById("btnprint").style.display = "none";
         window.print();
         self.close();    
     }
    </script>
    <style type="text/css">
        .column
        {
            border: 1px solid #000;
        }
    </style>
</head>
<body>
    <form id="frmdtls" runat="server">
         <table style="width:700px">
                 
                     <tr><td colspan="3" style="text-align:center; font:bold 13px verdana;"><a id="btnprint" href="#" class="nextclick" style="cursor:pointer" onclick="Print()">Print</a></td></tr>
                  
                 <tr>
                       
                     <td><asp:Image ID="imgUnit" runat="server"   /></td>
                     <td style="text-align:center; font-size:medium; font-weight:bold; font:u" ><asp:Label ID="lblUnitName" runat="server" Text="Akij Group" Font-Underline="true"></asp:Label></td>
                 </tr>
                 <tr> 
                     <td></td>
                      <td  style="text-align:center"><asp:Label ID="lblWH" Font-Size="Small" Font-Bold="true" runat="server"></asp:Label></td>
                 </tr>
                 <tr>
                     <td></td>
                     <td style="text-align:center;"><asp:Label ID="lblDetalis" runat="server" Font-Bold="true" Font-Underline="true" Font-Size="Small" Text="Requisition Detalis"></asp:Label></td>
                 </tr>
                 <tr><td></td></tr>
              </table>
         <table>
                     
                 <tr> 
                     <td><asp:Label ID="lblReqNo" runat="server" Text="Requisition No:"></asp:Label><asp:Label ID="lblrequisition" Font-Bold="true" Font-Size="small" runat="server"></asp:Label></td>
                     <td><asp:Label ID="lblReqDate" runat="server" Text="Requested Date:"></asp:Label><asp:Label ID="lbldteRequest" Font-Bold="true" Font-Size="small" runat="server"></asp:Label></td> 
                     <td><asp:Label ID="lblAppDate" runat="server" Text="Approved Date:"></asp:Label><asp:Label ID="lbldteApprove" Font-Bold="true" Font-Size="small" runat="server"></asp:Label></td> 
                   <%--<td><asp:Button ID="btnDownload" runat="server" Text="Excel"  OnClick="btnDownload_Click"/> </td>--%>
        
                 </tr> 
              </table>
    <asp:GridView ID="dgvlist" runat="server" AutoGenerateColumns="False" Font-Size="10px" Width="800px" ShowFooter="True" BackColor="White" BorderColor="#999999"    
             BorderWidth="2px" CellPadding="3"   GridLines="Vertical" FooterStyle-Font-Bold="true"   FooterStyle-HorizontalAlign="Right" BorderStyle="Solid" ForeColor="Black" >
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:TemplateField HeaderText="SL" ItemStyle-CssClass="column"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
        <asp:BoundField DataField="DDate" HeaderText="Due Date" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="column" SortExpression="DDate" DataFormatString="{0:yyyy-MM-dd}">
        <ItemStyle HorizontalAlign="Left" Width="75px" /></asp:BoundField> 
        <asp:BoundField DataField="Items" HeaderText="Particulers" ItemStyle-HorizontalAlign="Center" SortExpression="Items" ItemStyle-CssClass="column">
        <ItemStyle HorizontalAlign="Left" Width="230px"/></asp:BoundField>
        <asp:BoundField DataField="Department" HeaderText="Remarks" ItemStyle-HorizontalAlign="Center" SortExpression="Department" ItemStyle-CssClass="column">
        <ItemStyle HorizontalAlign="Center" Width="200px"/></asp:BoundField>
        <asp:BoundField DataField="Quantity" HeaderText="Quantity" ItemStyle-HorizontalAlign="Center" SortExpression="Quantity" DataFormatString="{0:0.0000}" ItemStyle-CssClass="column">
        <ItemStyle HorizontalAlign="right" Width="65px"/></asp:BoundField>
        <asp:BoundField DataField="IssQuantity" HeaderText="I.Quantity" ItemStyle-HorizontalAlign="Center" SortExpression="IssQuantity" DataFormatString="{0:0.0000}" ItemStyle-CssClass="column">
        <ItemStyle HorizontalAlign="right" Width="65px"/></asp:BoundField>
        <asp:BoundField DataField="Remarks" HeaderText="Status" ItemStyle-HorizontalAlign="Center" SortExpression="Remarks" ItemStyle-CssClass="column">
        <ItemStyle HorizontalAlign="Center" Width="65px"/></asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <sortedascendingcellstyle backcolor="#F1F1F1" />
        <sortedascendingheaderstyle backcolor="#808080" />
        <sorteddescendingcellstyle backcolor="#CAC9C9" />
        <sorteddescendingheaderstyle backcolor="#383838" />
        </asp:GridView>
         <table>
              <%--<tr><td><asp:Image ID="imgApp" runat="server"   /></td></tr>--%>
              <tr><td></td></tr>
              <tr><td></td></tr> 
            <tr><td><asp:Label ID="lblreq" Font-Bold="true"  runat="server" Text="Requested By:"></asp:Label></td><td><asp:Label ID="lblReqBY" Font-Bold="true"  runat="server"></asp:Label></td> </tr> 
            <tr> <td> <asp:Label ID="lblApp" Font-Bold="true"  runat="server" Text="Approved By:"></asp:Label></td><td><asp:Label ID="lblApproveBy" runat="server" Font-Bold="true"></asp:Label>
             </td></tr>
                                      
          
        </table>
    </form>
</body>
</html>

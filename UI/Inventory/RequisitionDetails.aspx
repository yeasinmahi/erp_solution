﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequisitionDetails.aspx.cs" Inherits="UI.Inventory.RequisitionDetails" %>

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
                     <td><asp:Label ID="lblInd" runat="server" Text="Requisition No:"></asp:Label><asp:Label ID="lblrequisition" Font-Bold="true" Font-Size="small" runat="server"></asp:Label></td>
                     <td><asp:Label ID="Label6" runat="server" Text="Requested Date:"></asp:Label><asp:Label ID="lbldteRequest" Font-Bold="true" Font-Size="small" runat="server"></asp:Label></td> 
                     <td><asp:Label ID="Label2" runat="server" Text="Approved Date:"></asp:Label><asp:Label ID="lbldteApprove" Font-Bold="true" Font-Size="small" runat="server"></asp:Label></td> 
                   <%--<td><asp:Button ID="btnDownload" runat="server" Text="Excel"  OnClick="btnDownload_Click"/> </td>--%>
        
                 </tr> 
              </table>
    <asp:GridView ID="dgvlist" runat="server" AutoGenerateColumns="False" Font-Size="10px" Width="800px" ShowFooter="true" BackColor="White" BorderColor="#999999"    
             BorderWidth="1px" CellPadding="5"   GridLines="Vertical" FooterStyle-Font-Bold="true"   FooterStyle-HorizontalAlign="Right" ><AlternatingRowStyle BackColor="White" />
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
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <sortedascendingcellstyle backcolor="#FBFBF2" />
        <sortedascendingheaderstyle backcolor="#848384" />
        <sorteddescendingcellstyle backcolor="#EAEAD3" />
        <sorteddescendingheaderstyle backcolor="#575357" />
        </asp:GridView>
         <table>
              <%--<tr><td><asp:Image ID="imgApp" runat="server"   /></td></tr>--%>
              <tr><td></td></tr>
              <tr><td></td></tr> 
            <tr><td>Requested By:</td><td><asp:Label ID="lblReqBY" Font-Bold="true"  runat="server"></asp:Label></td> </tr> 
            <tr> <td>Approved By: </td><td><asp:Label ID="lblApproveBy" runat="server" Font-Bold="true"></asp:Label>
             </td></tr>
                                      
          
        </table>
    </form>
</body>
</html>

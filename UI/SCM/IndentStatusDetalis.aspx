<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndentStatusDetalis.aspx.cs" Inherits="UI.SCM.IndentStatusDetalis" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> 
<!DOCTYPE html> 
<html> 
<head runat="server"> 
    <title></title> 
    <meta http-equiv="X-UA-Compatible" content="IE=edge" /> 
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" /> 
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" /> 
    <script src="../../Content/JS/datepickr.min.js"></script> 
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" /> 
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" /> 
    <script src="jquery.min.js"></script> 
    <script src="jquery-ui.min.js"></script> 
    
    <script src="../Content/JS/BlueBird.min.js"></script>
   <script src="../Content/JS/html2canvas.min.js"></script>
 <script>
     function Print() {
              document.getElementById("btnDownload").hidden = true;
         document.getElementById("btnprint").style.display = "none"; window.print(); self.close();    
     }
    </script> 
  <!-- Global site tag (gtag.js) - Google Analytics -->
<script async src="https://www.googletagmanager.com/gtag/js?id=UA-125570863-1"></script>
<script>
  window.dataLayer = window.dataLayer || [];
  function gtag(){dataLayer.push(arguments);}
  gtag('js', new Date());
    gtag('config', 'UA-125570863-1');
</script>      
</head> 
<body>

     <form id="frmLoanSummaryPrint" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>  

<%--=========================================Start My Code From Here===============================================--%> 
    <div id="dvTable"   style="width:auto;background-color:white;padding-left:50px;padding-right:50px; padding-top:10px;padding-bottom:20px;"> 
         <asp:HiddenField ID="hfImageData" runat="server" />
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
                     <td style="text-align:center;"><asp:Label ID="lblDetalis" runat="server" Font-Bold="true" Font-Underline="true" Font-Size="Small" Text="Indent Detalis"></asp:Label></td>
                 </tr>
                 <tr><td></td></tr>
              </table>
               <table>
                     
                 <tr> 
                     <td><asp:Label ID="lblInd" runat="server" Text="Indent No:"></asp:Label><asp:Label ID="lblIndent" Font-Bold="true" Font-Size="small" runat="server"></asp:Label></td>  
                     <td><asp:Label ID="Label4" runat="server" Text="Indent Type:"></asp:Label><asp:Label ID="lblType" Font-Bold="true" Font-Size="small" runat="server"></asp:Label></td> 
                     <td><asp:Label ID="Label6" runat="server" Text="Indent Date:"></asp:Label><asp:Label ID="lbldteIndent" Font-Bold="true" Font-Size="small" runat="server"></asp:Label></td> 
                     <td><asp:Label ID="Label2" runat="server" Text="Due Date:"></asp:Label><asp:Label ID="lbldteDue" Font-Bold="true" Font-Size="small" runat="server"></asp:Label></td> 
                   <td><asp:Button ID="btnDownload" runat="server" Text="Excel"  OnClick="btnDownload_Click"/> </td>
        
                 </tr> 
              </table>
           
             <table style="width:800px">
             <tr><td></td></tr>
             <tr> 
             <td><asp:GridView ID="dgvIndentsDetalis" runat="server" AutoGenerateColumns="False" Font-Size="10px" Width="800px" ShowFooter="true" BackColor="White" BorderColor="#999999"    
             BorderWidth="1px" CellPadding="5"   GridLines="Vertical" FooterStyle-Font-Bold="true"   FooterStyle-HorizontalAlign="Right"  > 
           
            <Columns>
                <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="30px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>   
                
                <asp:TemplateField HeaderText="Item ID" SortExpression="intItemID"><ItemTemplate>
                <asp:Label ID="lblItemID" runat="server" Text='<%# Bind("intItemID") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="70px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Item Name" SortExpression="strName"><ItemTemplate>
                <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("strName") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="220px"/></asp:TemplateField>
                
                <asp:TemplateField HeaderText="UOM" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="strUoM" >
                <ItemTemplate><asp:Label ID="lblUOM" runat="server"  Text='<%# Bind("strUoM") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="50px"/>  </asp:TemplateField>  

                <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="right" SortExpression="numQty" >
                <ItemTemplate><asp:Label ID="lblnumQty" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("numQty","{0:n2}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" /> </asp:TemplateField>
            
                <asp:TemplateField HeaderText="Last Price" ItemStyle-HorizontalAlign="right" SortExpression="lastPrice" >
                <ItemTemplate><asp:Label ID="lblLastPrice" runat="server"   Text='<%# Bind("lastPrice","{0:n2}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Center" /> </asp:TemplateField> 
            
                <asp:TemplateField HeaderText="Remarks" ItemStyle-HorizontalAlign="right" SortExpression="strPurpose" >
                <ItemTemplate><asp:Label ID="lblRemarks" runat="server"   Text='<%# Bind("strPurpose") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>
                 
            </Columns>
            <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />  
            </asp:GridView></td> 
        </tr> 
             </table>
        <table>
              <tr><td><asp:Image ID="imgApp" runat="server"   /></td></tr>
              <tr><td></td></tr>
              <tr><td></td></tr> 
            <tr><td>Indent By:</td><td><asp:Label ID="lblIndentBY" Font-Bold="true"  runat="server"></asp:Label></td> </tr> 
            <tr> <td>e-Approved By: </td><td><asp:Label ID="lblApproveBy" runat="server" Font-Bold="true"></asp:Label>
             </td></tr>
                                      
          
        </table>

         
               
    </div> 
     
<%--=========================================End My Code From Here=================================================--%>

    
    </form>
</body>
</html>

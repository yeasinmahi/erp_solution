<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MrrDocAttachmentPopUp.aspx.cs" Inherits="UI.SCM.MrrDocAttachmentPopUp" %>
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
     
    
    <style type="text/css">
        .auto-style1 {
            width: 59px;
        }
    </style>
    
</head> 
<body>

     <form id="frmLoanSummaryPrint" runat="server">        
 

<%--=========================================Start My Code From Here===============================================--%> 
    <div id="dvTable"   style="width:auto;background-color:white;padding-left:50px;padding-right:50px; padding-top:10px;padding-bottom:20px;"> 
         <asp:HiddenField ID="hfImageData" runat="server" />
            <table style="width:700px">
                 
            <tr><td colspan="3" style="text-align:center; font:bold 13px verdana;"><a id="btnprint" href="#" class="nextclick" style="cursor:pointer" onclick="Print()"></a></td></tr>
                  
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
            <td style="text-align:center;"><asp:Label ID="lblDetalis" runat="server" Font-Bold="true" Font-Underline="true" Font-Size="Small" Text="Material Receive Report"></asp:Label></td>
            </tr>
            <tr><td></td></tr>
            </table> 
            <table> 
            <tr>  
            <td><asp:Label ID="lblInd" runat="server" Text="Challan No:"></asp:Label><asp:Label ID="lblChallan"    runat="server"></asp:Label></td>  
            <td><asp:Label ID="Label4" runat="server" Text="Challan Date Type:"></asp:Label><asp:Label ID="lblChallanDate"    runat="server"></asp:Label></td>  
            <td><asp:Label ID="Label2" runat="server" Text="Supplier Name:"></asp:Label><asp:Label ID="lblSupplier"  Font-Size="small" runat="server"></asp:Label></td> 
            </tr> 
            <tr>
            <td><asp:Label ID="Label1" runat="server" Text="MRR No:"></asp:Label><asp:Label ID="lblMrrNo"    runat="server"></asp:Label></td> 
            <td><asp:Label ID="Label5" runat="server" Text="MRR Date:"></asp:Label><asp:Label ID="lblMrrDate"    runat="server"></asp:Label></td>  

            </tr>
            </table> 
            <table>
            <tr>
            <td style="text-align:right"><asp:Label ID="Label3" Text="Name" runat="server"></asp:Label></td>
            <td><asp:TextBox ID="txtName" CssClass="txtBox" Width="250px" runat="server" /></td> 
            </tr>
            <tr>
            <td style="text-align:right" ><asp:Label ID="lblMupload" Text="Upload" runat="server"></asp:Label></td>
            <td colspan="3"><asp:FileUpload ID="docUpload" Width="250px" runat="server" /></td> 
            <td style="text-align:right"   ><asp:Button ID="btnMrr" Text="Attach MRR" Font-Bold="true" runat="server" OnClick="btnMrr_Click"    /></td> 
            </tr> 
            </table>
        
            <table> 
            <tr> 
            <td><asp:GridView ID="dgvDocument" runat="server" AutoGenerateColumns="False" ShowFooter="true" ShowHeader="true"  Width="600px"  
            CssClass="GridViewStyle">            
            <HeaderStyle CssClass="HeaderStyle" />  <FooterStyle CssClass="FooterStyle" /> <RowStyle CssClass="RowStyle" />  <PagerStyle CssClass="PagerStyle" /> 
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="30px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
  
            <asp:TemplateField HeaderText="DocID" SortExpression="intDocID"><ItemTemplate>
            <asp:Label ID="lblDocId" runat="server" Width="60px" Text='<%# Bind("intDocID") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>

            <asp:TemplateField HeaderText="Document Note" ItemStyle-HorizontalAlign="right" SortExpression="strDocName" >
            <ItemTemplate><asp:Label ID="lblNote" runat="server"  Width="150px" Text='<%# Bind("strDocName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 

            <asp:TemplateField HeaderText="File Path" ItemStyle-HorizontalAlign="right" SortExpression="strFtpPath" >
            <ItemTemplate><asp:Label ID="lblFilePath" runat="server" Width="70px"  Text='<%# Bind("strFtpPath") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 

            <asp:TemplateField HeaderText="Detalis">  <ItemTemplate>
            <asp:Button ID="btnView" runat="server" Text="View"  OnClick="btnView_Click"    CommandArgument='<%# Eval("strFtpPath") %>'  /></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>  

            <asp:TemplateField HeaderText="Detalis">  <ItemTemplate>
            <asp:Button ID="btnDownload" runat="server" Text="Download"   OnClick="btnDownload_Click"  CommandArgument='<%# Eval("strFtpPath") %>'  /></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>  
            </Columns> 
            </asp:GridView></td> 
            </tr>  
            </table> 
        <table>
            <asp:Image ID="imageView" runat="server" />
        </table> 
               
    </div> 
     
<%--=========================================End My Code From Here=================================================--%>

    
    </form>
</body>
</html>



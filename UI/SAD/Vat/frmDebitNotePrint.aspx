<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDebitNotePrint.aspx.cs" Inherits="UI.SAD.Vat.frmDebitNotePrint" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head runat="server"><title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" /> 
    <script>
        function Print() {
            document.getElementById("btnshow").style.visibility = "hidden";
            document.getElementById("btnprint").style.display = "none"; window.print();  
            //document.getElementById("btnExport").style.visibility = "visible";
        }
    </script> 
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="frmDebitNoteprint" runat="server">
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>

<%--=========================================Start My Code From Here===============================================--%>
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnCustid" runat="server" /><asp:HiddenField ID="hdnconfirm" runat="server" />
    <asp:HiddenField ID="hdnVatAccount" runat="server" /><asp:HiddenField ID="hdnVatRegNo" runat="server" />
    <asp:HiddenField ID="hdnAccno" runat="server" /> <asp:HiddenField ID="hdnysnFactory" runat="server" />
    <asp:HiddenField ID="hdnEnroll" runat="server" /> <asp:HiddenField ID="hdnCustname" runat="server" /> <asp:HiddenField ID="hdnCustAddress" runat="server" />
    <div class="tabs_container"> M18 Current Register Summary <hr /></div>
    <table><tr><td>
    <table  class="tbldecoration" style="width:auto; float:left;">    
    <tr> <td style="text-align:center" colspan="5">DEBIT NOTE</td></tr>
    <tr><td style="text-align:right" colspan="5" class="auto-style1">Mushak 12</td> </tr>
    <tr><td colspan="2" style="text-align:center; font:bold 13px verdana;"><a id="btnprint" href="#" class="nextclick" style="cursor:pointer" onclick="Print()">Print</a></td></tr>
    <tr><td>Organization Name:</td>
        <td><asp:Label ID="lblorgName" runat="server"></asp:Label></td>
        <td>Musok12 No:</td>
        <td>  <asp:TextBox ID="txtMNo" runat="server"></asp:TextBox><asp:Button ID="btnshow" runat="server" Text="Show" OnClick="btnshow_Click1" /></td>
        <td>Year<asp:TextBox ID="txtYear" runat="server"></asp:TextBox> </td>        
    </tr>
    <tr><td>Organization Address:</td>
        <td><asp:Label ID="lblOrgadd" runat="server"/></td>
        <td>Customer Address:</td>
        <td><asp:Label ID="LBLCustAddress" runat="server"></asp:Label></td>
    </tr> 
    <tr><td>Vat Reg No:</td>
        <td><asp:Label ID="lblVatregnoorg" runat="server"></asp:Label></td>
        <td>Vat Reg No:</td>
        <td><asp:Label ID="lblVatRegno" runat="server"></asp:Label></td>
    </tr> 
    <tr><td class="auto-style1">Customer Name: </td>
        <td class="auto-style1"><asp:Label ID="lblCustname" runat="server"></asp:Label></td>
        <td class="auto-style1">Vehicle Type and No:</td>
        <td class="auto-style1"><asp:Label ID="Vehicletypeno" runat="server"></asp:Label></td>
     </tr> 
     <tr><td class="auto-style1">Credit Note No:</td>
        <td class="auto-style1"><asp:Label ID="lblCreditNoteNo" runat="server"></asp:Label></td>
        <td  style="text-align:left" class="auto-style1">  Date:</td>
        <td class="auto-style1"><asp:Label ID="lblDate" runat="server"></asp:Label>Date:</td>
     </tr> 
     <tr><td colspan="5"><hr /></td></tr>  
     <tr><td colspan="5"><asp:GridView ID="dgvRpt" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
        CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
        HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
        FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" >
        <AlternatingRowStyle BackColor="#CCCCCC" />    
        <Columns>
        <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="40px" /><ItemTemplate>  <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
       
        <asp:TemplateField HeaderText="Challan No and Date" SortExpression="itemname">
        <ItemTemplate> <asp:Label ID="lbldteM11Date" runat="server" Text='<%# Bind("dteM11Date") %>' Width="40px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="40px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Product Name and Quantity" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblstrProductName" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("strProductName") %>' Width="150px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="150px" />
        </asp:TemplateField>

         <asp:TemplateField HeaderText="Amount Without SD/VAT" SortExpression="itemname">
        <ItemTemplate> <asp:Label ID="lblmonRtnAmountWithoutSDnVAT" runat="server" Text='<%# Bind("monRtnAmountWithoutSDnVAT") %>' Width="40px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="40px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Other Tax Amount" SortExpression="itemname">
        <ItemTemplate> <asp:Label ID="lblmonRtnOtherTax" runat="server" Text='<%# Bind("monChallanOtherTax") %>' Width="40px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="40px" /></asp:TemplateField>
       
        <asp:TemplateField HeaderText="VAT" SortExpression="itemname">
        <ItemTemplate> <asp:Label ID="lblVAT" runat="server" Text='<%# Bind("monChallanVAT") %>' Width="40px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="40px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Other Tax Amount" SortExpression="itemname">
        <ItemTemplate> <asp:Label ID="lblmonClnOtherTax" runat="server" Text='<%# Bind("monReduceOtherTax") %>' Width="40px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="40px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="VAT" SortExpression="itemname">
        <ItemTemplate> <asp:Label ID="lblmonRtnVAT" runat="server" Text='<%# Bind("monReduceVat") %>' Width="40px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="40px" /></asp:TemplateField>


        </Columns>
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
        </td> </tr> 
    
    </tr>                  
    </table>
    </td</tr>
    <tr><td>
    <table  class="tbldecoration" style="width:auto; float:left;"> 
                                    
    <tr><td><hr /></td></tr> 
    <tr><td></td></tr>  
    </tr>             
    </table>
    </td></tr></table>
    </div>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>


﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseVoucher.aspx.cs" Inherits="UI.PaymentModule.PurchaseVoucher" %>

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
    <link href="../Content/CSS/GridView.css" rel="stylesheet" />
     <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />
       
    
    <script>
        function DocViewdetails(MrrId) {
            window.open('MrrDocAttachmentPopUp.aspx?MrrId=' + MrrId, 'sub', "scrollbars=yes,toolbar=0,height=500,width=950,top=100,left=200, resizable=yes, directories=no,location=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no, addressbar=no");
        }
    </script>
  
     
</head>

<body>

    <form id="frmselfresign" runat="server"> 
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

    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnConfirm" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
     <asp:HiddenField ID="hdnIndentNo" runat="server" /><asp:HiddenField ID="hdnIndentDate" runat="server" />
     <asp:HiddenField ID="hdnDueDate" runat="server" /><asp:HiddenField ID="hdnIndentType" runat="server" /> 
     <div class="tabs_container" style="text-align:left">Inventory Statement<hr /></div>
         
       <table>
        <tr>
            <td></td>
        <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Font-Size="Medium" Text="Purchase Voucher"></asp:Label></td>
                                                                                        
            
        </tr>
           <tr>
            <td   style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Unit Name"></asp:Label></td>
            <td style="text-align:left;"><asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"     ></asp:DropDownList></td>                                                                                      

            <td   style="text-align:right;"><asp:Label ID="lblType" runat="server" CssClass="lbl" Text="Type"  ></asp:Label></td>
            <td style="text-align:left;"><asp:DropDownList ID="ddlType" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server">
                <asp:ListItem Value="1" Text="Purchase "></asp:ListItem>
                <asp:ListItem Value="2" Text="Purchase Return "></asp:ListItem>
                <asp:ListItem Value="3" Text="Import Purchase Voucher "></asp:ListItem>
                </asp:DropDownList></td>                                                                                      
            <td style="text-align:left"> </td><td style="text-align:left"><asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click"  /> </td>
           </tr>
        
        </table>
        <table>
           <tr><td> 
            <asp:GridView ID="dgvInvnetory"  runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
            HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
            ForeColor="Black" GridLines="Vertical" OnRowCommand="dgvBillReport_RowCommand">
            <AlternatingRowStyle BackColor="#CCCCCC" />     
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
 
            <asp:TemplateField HeaderText="MRR  ID" SortExpression="intMRR"><ItemTemplate>
            <asp:Label ID="lblMrr" runat="server" Text='<%# Bind("intMRR") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="PO ID"   ItemStyle-HorizontalAlign="right" SortExpression="intPO" >
            <ItemTemplate><asp:Label ID="lblPOID" runat="server"  Text='<%# Bind("intPO") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>   
                
            <asp:TemplateField HeaderText="Date"   ItemStyle-HorizontalAlign="right" SortExpression="dteDate" >
            <ItemTemplate><asp:Label ID="lblDate" runat="server"  Text='<%# Bind("dteDate","{0:yyyy-MM-dd}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  
            
            <asp:TemplateField HeaderText="Party ID"   ItemStyle-HorizontalAlign="right" SortExpression="intParty" >
            <ItemTemplate><asp:Label ID="lblPartyID" Width="60px" runat="server"  Text='<%# Bind("intParty") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  

            <asp:TemplateField HeaderText="Party Name" ItemStyle-HorizontalAlign="right" SortExpression="strItem" >
            <ItemTemplate><asp:Label ID="lblPartName" runat="server"  Width=""  Text='<%# Bind("strParty") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 

            <asp:TemplateField HeaderText="Value"   ItemStyle-HorizontalAlign="right" SortExpression="monValue" >
            <ItemTemplate><asp:Label ID="lblmonValue" runat="server"  Text='<%# Bind("monValue" ) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  

                       
             
             
            <asp:TemplateField HeaderText="Detalis">
            <ItemTemplate>   <asp:Button ID="btnDetalis" runat="server" Text="Detalis" OnClick="btnDetalis_Click"   /> </ItemTemplate> 
            </asp:TemplateField>

            </Columns>
                 <FooterStyle Font-Size="11px" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td> 
        </tr> 
           
        </table> 
        </div>
         
        </div> 
<%--=========================================End My Code From Here=================================================--%>

    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
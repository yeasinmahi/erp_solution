﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FpsTransferIn.aspx.cs" Inherits="UI.AEFPS.FpsTransferIn" %>
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
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/Lstyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
           
</head>
<body>
    <form id="frmSalesReturn" runat="server">        
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" />
    <asp:HiddenField ID="hdnconfirm" runat="server" /> <asp:HiddenField ID="hdnJobStation" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" /> <asp:HiddenField ID="hdnFTP" runat="server" />
    <asp:HiddenField ID="hdnCmComm" runat="server" />
          
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <div class="leaveApplication_container"> 
    <div class="tabs_container"> TRANSFER IN FORM :<hr /></div>        
        
        <table class="tbldecoration" style="width:auto; float:left;">    
            
        <tr>                
            <td style="text-align:right;"><asp:Label ID="lblFromWH" runat="server" CssClass="lbl" Text="WH Name:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlFromWH" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlFromWH_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td>

            <%--<td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="From WH Name:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlToWHName" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlToWHName_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td>--%>         
        </tr>         
        <%--<tr>
            <td colspan="4" style="text-align:right;"><asp:Button ID="btnShow" runat="server" CssClass="nextclick" ForeColor="Black" Text="Show"/></td>   
        </tr>--%>
        <tr><td colspan="4"><hr /></td></tr> 
        <tr><td colspan="4">Transfer Product List :<hr /></td></tr>  
        <tr><td colspan="4"> 
            <asp:GridView ID="dgvProductDTR" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" OnRowCommand="dgvProductDTR_RowCommand"
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"  ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="dgvProductDTR_RowDataBound" OnRowDeleting="dgvProductDTR_RowDeleting">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
            
            <asp:TemplateField HeaderText="strQRCode" Visible="false" SortExpression="strQRCode"><ItemTemplate>            
            <asp:Label ID="lblQRCode" runat="server" Text='<%# Bind("strQRCode") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="ProductID" Visible="false" SortExpression="intProductID"><ItemTemplate>            
            <asp:Label ID="lblProductID" runat="server" Text='<%# Bind("intItemID") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="From WH" SortExpression="FromWH"><ItemTemplate>            
            <asp:Label ID="lblFromWH" runat="server" Text='<%# Bind("FromWH") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="150px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="Total" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Voucher No." SortExpression="strVoucher"><ItemTemplate>            
            <asp:Label ID="lblVoucherNo" runat="server" Text='<%# Bind("strVoucher") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="100px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="Total" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Product Name" SortExpression="strItemName"><ItemTemplate>            
            <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("strItemName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="285px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="Total" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="UOM" SortExpression="strUOM"><ItemTemplate>            
            <asp:Label ID="lblUOM" runat="server" Text='<%# Bind("strUOM") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="60px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="right" SortExpression="numQty" >
            <ItemTemplate><asp:Label ID="lblQty" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("numQty"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="80px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text = '' /></FooterTemplate></asp:TemplateField>
                
            <asp:TemplateField HeaderText="Price" ItemStyle-HorizontalAlign="right" SortExpression="monPrice" >
            <ItemTemplate><asp:Label ID="lblPrice" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monPrice"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="80px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text = '' /></FooterTemplate></asp:TemplateField>
                                     
            <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="right" SortExpression="monAmount">
            <ItemTemplate><asp:Label ID="lblAmount" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monAmount"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="80px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalamount1 %>' /></FooterTemplate></asp:TemplateField>
                     
            <asp:TemplateField HeaderText="Accept" ItemStyle-HorizontalAlign="Center" SortExpression="">
            <ItemTemplate><asp:Button ID="btnAccept" class="nextclick" OnClientClick = "ConfirmAll()" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="Y"  
            Text="Accept"/></ItemTemplate><ItemStyle HorizontalAlign="center"/></asp:TemplateField>
                    
            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
        </tr> 
        <tr><td colspan="4"><hr /></td></tr> 
        <%--<tr>
            <td colspan="4" style="text-align:right;"><asp:Button ID="btnReturn" runat="server" CssClass="nextclick" ForeColor="Black" Text="Accept"/></td>   
        </tr>--%>
         
       </table>
       </div>
    </div>

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransferIn.aspx.cs" Inherits="UI.AEFPS.TransferIn" %>
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
    <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />
               
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
          
    <div class="leaveApplication_container"> 
    <div class="tabs_container"> TRANSFER IN FORM :<hr /></div>        
        
        <table class="tbldecoration" style="width:auto; float:left;">    
            
        <tr>                
            <td style="text-align:right;"><asp:Label ID="lblFromWH" runat="server" CssClass="lbl" Text="From WH Name:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlFromWH" CssClass="ddList" Font-Bold="False" runat="server"></asp:DropDownList>                                                                                       
            </td>

            <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="To WH Name:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlToWHName" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlToWHName_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td>         
        </tr> 
                      
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblitm" CssClass="lbl" runat="server" Text="Voucher No : "></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlVoucher" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlVoucher_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td> 
            
            <td colspan="2" style="text-align:right;"><asp:Button ID="btnShow" runat="server" CssClass="nextclick" ForeColor="Black" Text="Show" OnClick="btnShow_Click"/></td>                          
        </tr> 
            <%--<tr>
            <td colspan="4" style="text-align:right;"><asp:Button ID="Button1" runat="server" ForeColor="Black" Text="ddd" Width="1px" Height="1px" OnClick="Button1_Click"/></td>   
        </tr> --%>   
            
        <tr><td colspan="4"><hr /></td></tr>
        <tr><td colspan="4">Product List :<hr /></td></tr> 
        <tr>
        <td colspan="4">
            <asp:GridView ID="dgvTransferItem" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
            FooterStyle-BackColor="#808080" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" OnRowDataBound="dgvTransferItem_RowDataBound">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Voucher No." SortExpression="strVoucher" Visible="true">
            <ItemTemplate><asp:Label ID="lblVoucher" runat="server" Text='<%# Bind("strVoucher") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="center" Width="100px" /></asp:TemplateField>    
              
            <asp:TemplateField HeaderText="Item Name" SortExpression="strName">
            <ItemTemplate><asp:Label ID="lblItemName" runat="server" Text='<%# Bind("strName") %>' Width="280px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="280px" />
            <FooterTemplate><asp:Label ID="lblT" runat="server" Text="Total" /></FooterTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Quantity" SortExpression="TQty">
            <ItemTemplate><asp:Label ID="lblTQty" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("TQty") %>' Width="65px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="65px" />
            <FooterTemplate><asp:Label ID="lblGrandTotalQty" runat="server" DataFormatString="{0:0.00}" Text="<%# totalqty %>" /></FooterTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Total Value" ItemStyle-HorizontalAlign="right" SortExpression="monTotalAmount">
            <ItemTemplate><asp:Label ID="lblTotalVal" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monTotalAmount"))) %>'></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblGrandTotal1" runat="server" DataFormatString="{0:0.00}" Text="<%# totalval %>" /></FooterTemplate></asp:TemplateField>
             
            </Columns>
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
        </tr> 
        <tr><td colspan="4"><hr /></td></tr>
        <tr>
            <td colspan="4" style="text-align:right;"><asp:Button ID="btnSubmit" runat="server" CssClass="nextclick" ForeColor="Black" Text="Submit" OnClick="btnSubmit_Click"/></td>
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
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptFGVatInventory.aspx.cs" Inherits="UI.SAD.Vat.rptFGVatInventory" %>
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
        function ValidationBasicInfo() {
            document.getElementById("hdnconfirm").value = "0";
            var ChallanDate = document.forms["frmPurchase"]["txtChallandate"].value;
            var Dpositdate = document.forms["frmPurchase"]["txtDepositdate"].value;
          
            if (ChallanDate == null || ChallanDate == "") {
                alert("Please Fill-up Challan Date!");
            }

            else if (Installmentdate == null || Installmentdate == "") {
                alert("Please Fill-up Installment date!");
            }
          
            else {  document.getElementById("hdnconfirm").value = "1"; }
        }
    </script>
  
</head>
<body>
    <form id="frmPurchase" runat="server">
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
    <div class="tabs_container"> TREASURY ENTRY <hr /></div>
    <table><tr><td>
    <table  class="tbldecoration" style="width:auto; float:left;">                              
     <tr><td>Material Name</td>
        <td><asp:TextBox ID="txtMatrialName" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox>
        <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtMatrialName"
        ServiceMethod="ItemnameSearchMatrial" MinimumPrefixLength="1" CompletionSetCount="1"
        CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
        </cc1:AutoCompleteExtender> </td>
        <td>From Date</td>
        <td><asp:TextBox ID="txtdtefdate" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtdtefdate" Format="dd/MM/yyyy" PopupButtonID="imgCal_13"
            ID="CalendarExtender2" runat="server" EnableViewState="true">
            </cc1:CalendarExtender>
            <img id="imgCal_13" src="../../Content/images/img/calbtn.gif" style="border: 0px;
            width: 34px; height: 23px; vertical-align: bottom;" /></td>
        <td>To Date</td>
        <td><asp:TextBox ID="txttodate" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txttodate" Format="dd/MM/yyyy" PopupButtonID="imgCal_12"
            ID="CalendarExtender1" runat="server" EnableViewState="true">
            </cc1:CalendarExtender>
            <img id="imgCal_12" src="../../Content/images/img/calbtn.gif" style="border: 0px;
            width: 34px; height: 23px; vertical-align: bottom;" /> 
        </td>
     </tr> 
     <tr><td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>
            <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text="Show Summary" />
         </td>
     </tr>

    <tr><td colspan="6"><hr /></td></tr>                             
    </table>
    </td</tr>
    <tr><td>
    <table  class="tbldecoration" style="width:auto; float:left;"> 
   
    <tr><td style="text-align:right"></td>                                     
     <tr><td><hr /></td></tr> 
     <tr><td>
        <asp:GridView ID="dgvPurChaseRpt" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
        CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
        HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
        FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical"  OnRowDataBound="dgvProductRpt_RowDataBound"
        >
        <AlternatingRowStyle BackColor="#CCCCCC" />    
        <Columns>
        <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="40px" /><ItemTemplate>  <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
 
        <asp:TemplateField HeaderText="Product Name" SortExpression="itemname">
        <ItemTemplate> <asp:Label ID="lblstrMaterialName" runat="server" Text='<%# Bind("strMaterialName") %>' Width="200px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="200px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="UoM" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblUoM" runat="server" Text='<%# Bind("strUOM") %>' Width="30px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Opening" SortExpression="qty">
        <ItemTemplate><asp:Label ID="lblOpening" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column2","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblOpeningTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalOpening %>" /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="Purchase" SortExpression="qty">
        <ItemTemplate><asp:Label ID="lblPurchasess" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column3","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblPurchasesTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalPurchase %>" /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="Purchase Return" SortExpression="qty">
        <ItemTemplate><asp:Label ID="lblPurchasesd" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column4","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblPurchaseTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalPurchasertn %>" /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="Sales" SortExpression="qty">
        <ItemTemplate><asp:Label ID="lblSales" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column5","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblSalesTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalSales %>" /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="Sales Return" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblReturnAmount" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column6","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblReturnValueTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalSalesrValue %>" /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="Closing" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblClosing" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column7","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblValueTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalClosing %>" /></FooterTemplate></asp:TemplateField>


        </Columns>
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
        </td></tr>  
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

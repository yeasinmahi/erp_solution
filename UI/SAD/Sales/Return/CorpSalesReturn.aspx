<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CorpSalesReturn.aspx.cs" Inherits="UI.SAD.Sales.Return.CorpSalesReturn" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><title></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
<webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
 <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
<script src="../Content/JS/datepickr.min.js"></script>

<script>
    function Confirm() {
        document.getElementById("hdnconfirm").value = "0";        
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
        if (confirm("Do you want to submit?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
        else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
    }
    function funvalidate() {
        if ((document.getElementById("txtSearch").value).length == 0)
        { alert("Customer Name should not be empty"); return false; }
        if ((document.getElementById("txtprod").value).length == 0)
        { alert("Product Name should not be empty"); return false; }
        if ((document.getElementById("txtchallanno").value).length == 0)
        { alert("Challan No should not be empty"); return false; }
        if ((document.getElementById("txtqty").value).length == 0)
        { alert("Customer Claim Quantity should not be empty"); return false; }
        if ((document.getElementById("txtwhqty").value).length == 0)
        { alert("WH Receive Quantity should not be empty"); return false; }
    }
</script> 
</head>
<body>
    <form id="frmcorpsalesreturninput" runat="server">
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
    <div class="leaveApplication_container"><b>Corporate Sales Return Entry: </b><asp:HiddenField ID="hdnconfirm" runat="server" /><hr />
    <table style="width:Auto";>

    <tr><td style="text-align:right;"><asp:Label ID="lblsrch" CssClass="lbl" runat="server" Text="Customer Name : "></asp:Label></td>
    <td style="text-align:left;"><asp:TextBox ID="txtSearch" runat="server" AutoPostBack="true" Width="350px"  CssClass="txtBox" AutoCompleteType="Search"   Enabled="true" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
    <asp:HiddenField ID="hdncustid" runat="server" /><cc1:AutoCompleteExtender ID="AutoCompleteCustomer" runat="server" TargetControlID="txtSearch"
    ServiceMethod="GetCustomer" MinimumPrefixLength="1" CompletionSetCount="1"
    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElement"
     CompletionListItemCssClass="autocomplete_listItem"  CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
    </cc1:AutoCompleteExtender></td>
            
    <td style="text-align:right;" colspan="1"><asp:Label ID="lblwhrcvdt" CssClass="lbl" runat="server" Text="WHR Date : "></asp:Label></td>
    <td><asp:TextBox ID="txtwhrcvdte" runat="server" CssClass="txtBox" Width="80px" autocomplete="off"></asp:TextBox><cc1:CalendarExtender ID="tdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtwhrcvdte"></cc1:CalendarExtender></td>
    </tr>

    <tr><td style="text-align:right;"><asp:Label ID="lblchalanno" CssClass="lbl" runat="server" Text="RTV No : "></asp:Label></td>
    <td><asp:TextBox ID="txtchallanno" runat="server"  CssClass="txtBox"></asp:TextBox></td>
    <td style="text-align:right;"><asp:Label ID="lblccq" CssClass="lbl" runat="server" Text="CC Qty (Pcs) : "></asp:Label></td>
    <td><asp:TextBox ID="txtqty" runat="server" onkeypress="if ( isNaN( String.fromCharCode(event.keyCode) )) return false;" CssClass="txtBox" Width="80px"></asp:TextBox></td>
    </tr>
    
    <tr><td style="text-align:right;"><asp:Label ID="lblc" CssClass="lbl" runat="server" Text="Product Name : "></asp:Label></td>
    <td><asp:TextBox ID="txtprod" runat="server" AutoCompleteType="Search"  CssClass="txtBox" style="width:300px" AutoPostBack="true" OnTextChanged="txtprod_TextChanged"></asp:TextBox>
    <cc1:AutoCompleteExtender ID="AutoCompleteProduct" runat="server" TargetControlID="txtprod" ServiceMethod="GetProduct" MinimumPrefixLength="1" CompletionSetCount="1"
    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElement"
    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"></cc1:AutoCompleteExtender>  
    <asp:HiddenField ID="hdnprodid" runat="server" /><asp:HiddenField ID="hdnUom" runat="server" /><asp:HiddenField ID="hdnprice" runat="server" /></td>
    <td style="text-align:right;"><asp:Label ID="lblwhq" CssClass="lbl" runat="server" Text="WHR Qty (Pcs) : "></asp:Label></td>
    <td><asp:TextBox ID="txtwhqty" runat="server" onkeypress="if ( isNaN( String.fromCharCode(event.keyCode) )) return false;" CssClass="txtBox" Width="80px"></asp:TextBox></td></tr>
    <tr><td colspan="3" style="text-align:right"><asp:Button ID="btnadd" runat="server" Text="Add"  OnClick="btnadd_Click" /></td>
    <td style="text-align:right"><asp:Button ID="btvSubmit" runat="server" class="nextclick" style="font:bold 12px verdana;" Text="Submit" OnClientClick="Confirm()" OnClick="btvSubmit_Click"/></td></tr>
    
    <tr><td colspan="3">  
    <asp:GridView ID="dgvrtn" runat="server"  AutoGenerateColumns="False" Font-Size="9px" BackColor="White"
    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgvrtn_RowDeleting">
    <AlternatingRowStyle BackColor="#CCCCCC"/>
    <Columns>
     <asp:TemplateField HeaderText="SL."><ItemTemplate><%# Container.DataItemIndex + 1 %><asp:HiddenField ID="hdnprodid" runat="server" Value='<%# Bind("strprodid") %>' /></ItemTemplate></asp:TemplateField>
     <asp:TemplateField HeaderText="Product Name" ItemStyle-Width="300px"><ItemTemplate ><asp:Label ID="lblprodname" runat="server" Text='<%# Bind("strprodname") %>'></asp:Label></ItemTemplate>
     <ItemStyle Width="300px" /></asp:TemplateField>
     <asp:TemplateField HeaderText="CC Return"><ItemTemplate ><asp:Label ID="lblrtnqty" runat="server" Text='<%# Bind("strrtnqty") %>'></asp:Label></ItemTemplate>
     <ItemStyle Width="80px" /></asp:TemplateField>
     <asp:TemplateField HeaderText="WH R Qty"><ItemTemplate ><asp:Label ID="lblwhrqty" runat="server" Text='<%# Bind("strwhrqty") %>'></asp:Label></ItemTemplate>
     <ItemStyle Width="80px" /></asp:TemplateField>
     <asp:TemplateField HeaderText="Rtn Cost"><ItemTemplate ><asp:Label ID="lblcost" runat="server" Text='<%# Bind("strcost") %>'></asp:Label></ItemTemplate>
     <ItemStyle Width="80px" />
     </asp:TemplateField>
     <asp:CommandField ShowDeleteButton="True" />
     </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White"/>
     <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" /></asp:GridView>
     </td></tr>
     <tr><td style="text-align:right;" colspan="3"></tr>
     </table>
     </div>
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
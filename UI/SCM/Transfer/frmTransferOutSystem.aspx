<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmTransferOutSystem.aspx.cs" Inherits="UI.SCM.Transfer.frmTransferOutSystem" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head runat="server"><title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="~/Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
</head>
<body>
<form id="frmTransferOrder" runat="server">
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnItemid" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
       <div class="tabs_container"> TRANSFER ORDER<hr /></div>
        <table  class="tbldecoration" style="width:auto; float:left;">                           
        <tr><td colspan="5"><hr /></td></tr>                              
        <tr class="tblrowodd">           
            <td style="text-align:left;">WH Name:</td>
            <td style="text-align:left;"> <asp:DropDownList ID="ddlshippoint"  CssClass="ddList" runat="server"></asp:DropDownList>  </td>
            <td style='text-align: left; width:120px;'>Transfer Type</td>
            <td style='text-align: left;'><asp:DropDownList ID="ddlTType" runat="server" CssClass="ddList" AutoPostBack="True"></asp:DropDownList></td> 
            <td style="text-align:right;"> 
                &nbsp;</td>
        </tr>    
        <tr class="tblroweven"><td>Item Name</td>
            <td><asp:TextBox ID="txtItemName" Height="25" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" OnTextChanged="txtItemName_TextChanged" ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtItemName"
            ServiceMethod="ItemnameSearch" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender>
            </td>
            <td>Stock</td>
            <td><asp:Label ID="lblstock" runat="server"></asp:Label><asp:Label ID="lblstockUOM" runat="server"></asp:Label></td>
            <td></td>
        </tr> 
        <tr class="tblrowodd"><td>Value</td>
            <td><asp:Label ID="lblStockvalue" runat="server"></asp:Label></td>
            <td>UOM</td>
            <td><asp:Label ID="lblUOM" runat="server"></asp:Label></td>
            <td></td>
        </tr> 
        <tr><td>Transfer To</td>
            <td><asp:DropDownList ID="ddlToWH" runat="server"  CssClass="ddList"  AutoPostBack="True" ></asp:DropDownList>
            </td>
            <td>Location</td>
            <td colspan="2"><asp:DropDownList ID="ddlLocation" runat="server"  CssClass="ddList" AutoPostBack="True"></asp:DropDownList></td></tr> 
        <tr><td>Quantity </td>
            <td><asp:TextBox ID="txtQty" runat="server" AutoPostBack="true" CssClass="txtBox" MaxLength="10"></asp:TextBox></td>
            <td>Rate </td><td><asp:TextBox ID="txtRate" runat="server" AutoPostBack="true" CssClass="txtBox" MaxLength="10"></asp:TextBox></td>
        </tr>
         <tr><td>Vehicle No</td>
            <td><asp:TextBox ID="txtVehicle" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtVehicle"
            ServiceMethod="VehicleSearch" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender></td>
            <td >  Remarks</td>
            <td ><asp:TextBox ID="txtRemax" runat="server" AutoPostBack="true" CssClass="txtBox" MaxLength="10"></asp:TextBox>  </td>
        </tr> 
        <tr>
      
        <td colspan="4" style="text-align:right"><asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" /> &nbsp &nbsp 
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />&nbsp
            <asp:Button ID="btnTransfer" runat="server" Text="Transfer Out" OnClick="btnTransfer_Click" />
        </td>
        </tr>                        
        <tr><td colspan="5"><hr />
            <asp:GridView ID="dgv" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
             CellPadding="1" ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgv_RowDeleting1" ><AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField HeaderText="SL."><ItemTemplate><%# Container.DataItemIndex + 1 %> </ItemTemplate></asp:TemplateField> 
               
                <asp:TemplateField HeaderText="Item Id" SortExpression="sec">
                <ItemTemplate><asp:Label ID="lblitemid" runat="server" Text='<%# Bind("itemid") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="120px" /></asp:TemplateField>
             
                 <asp:TemplateField HeaderText="Item name" SortExpression="sec">
                <ItemTemplate><asp:Label ID="lblItemname" runat="server" Text='<%# Bind("Itemname") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="120px" /></asp:TemplateField>
             
                 <asp:TemplateField HeaderText="Item UOM" SortExpression="sec">
                <ItemTemplate><asp:Label ID="lblIUom" runat="server" Text='<%# Bind("Uom") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="120px" /></asp:TemplateField>
             
                <asp:TemplateField HeaderText="Quantity" >
                <ItemTemplate> <asp:Label ID="lblQty" runat="server" Text='<%# Bind("qty") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="75px" /></asp:TemplateField>
                  
                <asp:TemplateField HeaderText="Item Type" SortExpression="sec">
                <ItemTemplate><asp:Label ID="lbltype" runat="server" Text='<%# Bind("Type") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="120px" /></asp:TemplateField>
             
                        
                <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" > 
                <ControlStyle Font-Bold="True" ForeColor="Red" />
                </asp:CommandField>
           
             </Columns>
             <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
             </asp:GridView>
            </td></tr>          
        </tr>             
        </table>
        </div>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmItemAndMatrialsAdd.aspx.cs" Inherits="UI.SAD.Vat.frmItemAndMatrialsAdd" %>
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
</head>
<body>
    <form id="frmItemMatrialAdd" runat="server">
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
       <asp:HiddenField ID="hdnVatAccount" runat="server" /><asp:HiddenField ID="hdnVatRegNo" runat="server" />
        <asp:HiddenField ID="hdnAccno" runat="server" /> <asp:HiddenField ID="hdnysnFactory" runat="server" />
        <asp:HiddenField ID="hdnUnit" runat="server" />
       <div class="tabs_container"> ITEM & MATRIAL CREATE <hr /></div>
        <table  class="tbldecoration" style="width:auto; float:left;">                           
        <tr><td colspan="5"><hr /></td></tr>   
         <tr><td colspan="5">Vat Item Create</td>                                  
        <tr><td>Product Name</td>
            <td><asp:TextBox ID="txtItemMatrial" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtItemMatrial"
            ServiceMethod="ItemnameSearch" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender></td>
            <td>UOM Name</td>
            <td><asp:DropDownList ID="ddlUom"  CssClass="ddList" runat="server"></asp:DropDownList></td>
            <td></td>
        </tr> 
        <tr><td>HS Code</td>
            <td><asp:TextBox ID="txtHScode" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>
            <td>Tax Expacted</td>
            <td colspan="2">&nbsp &nbsp <asp:CheckBox ID="cbTax" runat="server" /> </td>
          </tr> 
        <tr><td></td> <td></td>
            <td colspan="3"><asp:Button ID="btnSaves" runat="server" Text="Save" OnClick="btnSave_Click" /> &nbsp &nbsp
            <asp:Button ID="btnUpdate" runat="server" Text="Update UOM" OnClick="btnUpdate_Click" /></td>
        </tr>
         <tr><td colspan="5"><hr /></td>
         <tr><td colspan="5">Matrial Create</td>
          <tr><td>Matrial Name</td>
            <td><asp:TextBox ID="txtVatMatrialname" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtVatMatrialname"
            ServiceMethod="ItemnameSearchMatrial" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender></td>
            <td>UOM Name</td>
            <td><asp:DropDownList ID="ddlUOMMatrial"  CssClass="ddList" runat="server"></asp:DropDownList></td>
            <td></td>
        </tr> 
         <tr><td>Type</td> <td><asp:DropDownList ID="ddlMatrialType" CssClass="ddList" runat="server"></asp:DropDownList></td>
            <td colspan="3"><asp:Button ID="btnMatrialCreate" runat="server" Text="Matrial Create" OnClick="btnMatrialCreate_Click" /></td>
        </tr>
         <tr><td colspan="5"><hr /></td>
         <tr><td colspan="5">Finish Good Bridge</td>
         <tr><td>Vat Item Name</td>
            <td><asp:TextBox ID="txtVatItem" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" TargetControlID="txtVatItem"
            ServiceMethod="ItemnameSearch" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender></td>
            <td>ERP SAD Item </td>
            <td><asp:TextBox ID="txtSADItem" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" TargetControlID="txtVatItem"
            ServiceMethod="ItemnameSearchSAD" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender> </td><td></td>
        </tr> 
        <tr><td>&nbsp;</td>
            <td>&nbsp;</td>
            <td></td>
            <td><asp:Button ID="btnVatItemBridge" runat="server" Text="Bridge" OnClick="btnVatItemBridge_Click" /></td>
          </tr> 
        </tr>                         
        <tr><td colspan="5"><hr />
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

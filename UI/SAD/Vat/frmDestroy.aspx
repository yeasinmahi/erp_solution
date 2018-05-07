<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDestroy.aspx.cs" Inherits="UI.SAD.Vat.frmDestroy" %>
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
            var VATITEM = document.forms["frmPurchase"]["txtItemVat"].value;
            var QTY = document.forms["frmPurchase"]["txtQty"].value;         
            var txtsdcharge = document.forms["frmPurchase"]["txtsdcharge"].value;
            var txtsd = document.forms["frmPurchase"]["txtsd"].value;
            var txtvat = document.forms["frmPurchase"]["txtvat"].value;
         
            if (VATITEM == null || VATITEM == "") {
                alert("Please Fill-Up Item Name !");
            }

            else if (QTY == null || QTY == "") {
                alert("Purchase Fill-up  QTY !");
            }
            else if (txtsdcharge == null || txtsdcharge == "") {
                alert("Please Fill-up  SD Chargeable Value !");
            }

            else if (txtsd == null || txtsd == "") {
                alert("Please Fill-up SD !");
            }

            else if (txtvat == null || txtvat == "") {
                alert("Please Fill-up Vat !");
            }
          
            else {  document.getElementById("hdnconfirm").value = "1"; }
        }
    </script>
     <script>
        function ValidationBasicInfoMaterial() {
            document.getElementById("hdnconfirm").value = "0";
            var matITEM = document.forms["frmPurchase"]["txtMaterial"].value;
            var QTY = document.forms["frmPurchase"]["txtQuantityMat"].value;         
            var txtsdcharge = document.forms["frmPurchase"]["txtsdChargeMat"].value;
            var txtsd = document.forms["frmPurchase"]["txtSDMat"].value;
            var txtvat = document.forms["frmPurchase"]["txtVatmat"].value;
         
            if (matITEM == null || matITEM == "") {
                alert("Please Fill-Up Item Name !");
            }

            else if (QTY == null || QTY == "") {
                alert("Purchase Fill-up  QTY !");
            }
            else if (txtsdcharge == null || txtsdcharge == "") {
                alert("Please Fill-up  SD Chargeable Value !");
            }

            else if (txtsd == null || txtsd == "") {
                alert("Please Fill-up SD !");
            }

            else if (txtvat == null || txtvat == "") {
                alert("Please Fill-up Vat !");
            }
          
            else {  document.getElementById("hdnconfirm").value = "1"; }
        }
    </script>
</head>
<body>
    <form id="frmProduction" runat="server">
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
    <div class="tabs_container"> DESTROY FINISH PRODUCT <hr /></div>
    <table><tr><td>
    <table  class="tbldecoration" style="width:auto; float:left;">                            
        <tr><td>Product Name</td>
        <td><asp:TextBox ID="txtItemVat" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox>
        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtItemVat"
        ServiceMethod="ItemnameSearch" MinimumPrefixLength="1" CompletionSetCount="1"
        CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
        </cc1:AutoCompleteExtender></td>
        <td>Quantity</td>
        <td><asp:TextBox ID="txtQty" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>
        </tr> 
        <tr><td>SD Chargeable Value:</td>
        <td><asp:TextBox ID="txtsdcharge" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>
        <td>SD</td>
        <td><asp:TextBox ID="txtsd" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox> </td>
        </tr> 
        <tr><td><asp:Label ID="lblbandroll" runat="server">Vat</asp:Label></td> <td><asp:TextBox ID="txtvat" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>
        <td>Remarks</td>
        <td><asp:TextBox ID="txtremarks" runat="server" TextMode="MultiLine" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox> </td>                   
        </tr>
        <tr><td colspan="4" style="text-align:right"><asp:Button ID="btnSaves" runat="server" OnClientClick="ValidationBasicInfo()" Text="Save FG Destory" OnClick="btnSave_Click" /></td>                                     
        <tr><td colspan="4"><hr /></td></tr>          
        </tr>             
    </table>
    </td></tr>
    <tr><td>
    <table  class="tbldecoration" style="width:auto; float:left;"> 
        <tr><td colspan="4" class="auto-style1">DESTROY MATERIAL</td>   
        <tr><td class="auto-style1">Material Name</td>
        <td class="auto-style1"><asp:TextBox ID="txtMaterial" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox>
        <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtMaterial"
        ServiceMethod="ItemnameSearchMatrial" MinimumPrefixLength="1" CompletionSetCount="1"
        CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
        </cc1:AutoCompleteExtender>  </td>
        <td class="auto-style1">Quantity</td>
        <td class="auto-style1"><asp:TextBox ID="txtQuantityMat" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>
        </tr> 
        <tr><td>SD Chargeable Value:</td>
        <td><asp:TextBox ID="txtsdChargeMat" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>
        <td>SD</td>
        <td><asp:TextBox ID="txtSDMat" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox> </td>
        </tr>                                
        <tr><td><asp:Label ID="lblvat" runat="server">Vat</asp:Label></td> <td>
        <asp:TextBox ID="txtVatmat" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>
        <td>Remarks</td>
        <td><asp:TextBox ID="txtRemarksmat" runat="server" TextMode="MultiLine" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox> </td>                   
        </tr> 
        <tr><td colspan="4" style="text-align:right"><asp:Button ID="btnMaterialSave" runat="server" OnClientClick="ValidationBasicInfo()" Text="Save RM Destory" OnClick="btnMaterialSave_Click" /></td>                                     
        <tr><td colspan="4"><hr /></td></tr> 
        <tr><td colspan="4">&nbsp;</td></tr>  
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

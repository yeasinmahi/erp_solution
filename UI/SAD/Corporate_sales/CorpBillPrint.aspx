<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CorpBillPrint.aspx.cs" Inherits="UI.SAD.Corporate_sales.CorpBillPrint" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
<webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
 <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
<script src="../Content/JS/datepickr.min.js"></script>

<script type="text/javascript">
    //function Changed() {
    //    document.getElementById('hdfSearchBoxTextChange').value = 'true';
    //}
    //function SearchText() {
    //    $("#txtItem").autocomplete({
    //        source: function (request, response) {
    //            $.ajax({
    //                type: "POST",
    //                contentType: "application/json;",
    //                url: "Requisition.aspx/GetAutoCompleteData",
    //                data: '{"whid":"' + $("#hdnwh").val() + '","searchKey":"' + document.getElementById('txtItem').value + '"}',
    //                dataType: "json",
    //                success: function (data) {
    //                    response(data.d);
    //                },
    //                error: function (result) {
    //                    alert("Error");
    //                }
    //            });
    //        }
    //    });
    //}

    function Confirm() {
        document.getElementById("hdnconfirm").value = "0";
        var txtSection = document.forms["frmreq"]["txtSection"].value;
        var txtQuantity = document.forms["frmreq"]["txtQuantity"].value;
        if (txtSection == null || txtSection == "") { alert("Please enter valid section ."); }
        else if (!isDecimal(txtQuantity) || txtQuantity.length <= 0 || txtQuantity == "0" || txtQuantity == "0.00") { alert("Please enter valid quantity ."); }
        else { document.getElementById("hdnconfirm").value = "1"; }
    }
    function isDecimal(value) {
        return parseFloat(value) == value; // Check Intiger values by value % 1 === 0;
    }



    //function Viewdetails(id) {
    //    window.open('RequisitionDetails.aspx?ID=' + id, '', "height=375, width=730, scrollbars=yes, left=250, top=200, resizable=no, title=Preview");
    //}
    function Viewdetails(url) {
        newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=1000,top=50,left=200, close=no');
        if (window.focus) { newwindow.focus() }
    }
</script>
      


</head>
<body>
    <form id="frmreq" runat="server">
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
    <div class="leaveApplication_container"><table border="0"; style="width:500PX"; >
    <tr><td colspan="2" class="tblheader">Challan Input From:<asp:HiddenField ID="hdnsearch" runat="server"/><asp:HiddenField ID="hdnUom" runat="server" /><asp:HiddenField ID="hdnprice" runat="server" />
     <asp:HiddenField ID="hdnBlance" runat="server" /> <asp:HiddenField ID="hdncredit" runat="server" /> 
         <asp:HiddenField ID="hdnTotal" runat="server" />
        </td></tr>
    <tr class='tblroweven'><td colspan="2" style="text-align:center;">
        <asp:Label ID="Label3" Font-Names="Calibri" Font-Size="25px" runat="server" Font-Bold="true" Text="Akij Corportation Ltd."></asp:Label>
        </td>
    <td> &nbsp;</td>
    </tr>
     <tr class='tblroweven'><td colspan="2" style="text-align:center;"><asp:Label ID="Label1" Font-Names="Calibri" Font-Size="14px" runat="server" Font-Bold="true" Text="Distributor : Akij Food & Beverage Ltd."></asp:Label></td>
    <td> &nbsp;</td>
    </tr>
          <tr class='tblroweven'><td colspan="2" style="text-align:center;"><asp:Label ID="Label4" Font-Names="Calibri" Font-Size="14px" runat="server" Font-Bold="true" Text="Top Sheet Bill"></asp:Label></td>
    <td> &nbsp;</td>
    </tr>
<tr class="tblrowodd"><td style="text-align:right;"><asp:Label ID="lblitm" CssClass="lbl" runat="server" Text="Customer Name : "></asp:Label></td>

    <td><asp:TextBox ID="txtItem" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" OnTextChanged="txtItem_TextChanged"  ></asp:TextBox>
    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtItem"
    ServiceMethod="GetCustomerName" MinimumPrefixLength="1" CompletionSetCount="1"
    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
    </cc1:AutoCompleteExtender>
    <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" />
    </td></tr>
    <tr class='tblroweven'><td style="text-align:right;">Address :</td>
    <td>
        &nbsp;</td>
    </tr>
   
 
   <tr class="tblrowodd">
        <td style="text-align:right;"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Date  : "></asp:Label></td>
         <td class="auto-style8">
                                <asp:TextBox ID="txtFrom" runat="server" Enabled="false" OnTextChanged="txtFrom_TextChanged" Height="22px"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFrom" Format="dd/MM/yyyy" PopupButtonID="imgCal_1"
                                    ID="CalendarExtender1" runat="server" EnableViewState="true">
                                </cc1:CalendarExtender>
                                <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />

                                 </td></tr>
    <tr class=""><td style="text-align:justify;" colspan="2">
        &nbsp;</td></tr>
    <tr class='tblrowodd'><td colspan="2" style="text-align:right;">
   <asp:Button ID="btnSubmit" runat="server" Text="Submit" Font-Bold="true" OnClick="btnSubmit_Click"  /></td></tr>

   </table></div>

 <div class="leaveSummary_container"> 
        <div class="tabs_container"><hr /></div>
       
    </div>
  








<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
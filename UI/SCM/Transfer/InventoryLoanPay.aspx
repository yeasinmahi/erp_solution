<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryLoanPay.aspx.cs" Inherits="UI.SCM.Transfer.InventoryLoanPay" %>

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
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/CommonStyle.css" rel="stylesheet" />
    <%--<link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />--%>



    <script type="text/javascript"> 

        function Confirms() {

            var e = document.getElementById("ddlFrom");
            var from = e.options[e.selectedIndex].value;
            var e = document.getElementById("ddlLocation");
            var locationId = e.options[e.selectedIndex].value;


            var item = document.getElementById("txtItem").value;
            var quantity = document.getElementById("txtReceQty").value;
            var remarks = document.getElementById("txtRemarks").value;
            var monValue = parseFloat(document.getElementById("txtValue").value);

            if ($.trim(from) == 0 || $.trim(from) == "" || $.trim(from) == null || $.trim(from) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please select From'); }
            else if ($.trim(locationId) == 0 || $.trim(locationId) == "" || $.trim(locationId) == null || $.trim(locationId) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please select Location'); }
            else if ($.trim(item) == 0 || $.trim(item) == "" || $.trim(item) == null || $.trim(item) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please select Item'); }
            else if ($.trim(quantity) == 0 || $.trim(quantity) == "" || $.trim(quantity) == null || $.trim(quantity) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Receive Quantity  must be greater than zero'); }
            else if ($.trim(remarks) == 0 || $.trim(remarks) == "" || $.trim(remarks) == null || $.trim(remarks) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please input Remarks'); }
            else if (parseFloat(monValue) == 0 || $.trim(monValue) == 0 || $.trim(monValue) == "" || $.trim(monValue) == null || $.trim(monValue) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Receive  Value must be greater than zero'); }
            else {
                if (confirm("Do you want to proceed?")) {
                    
                    showLoader();
                    return true;
                }
                else {
                    return false;
                }

                // document.getElementById("hdnPreConfirm").value = "1";
            }


        }
    </script>
</head>
<body>
    <form id="frmTransferOrder" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                </asp:Panel>
                <div style="height: 30px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <%--=========================================Start My Code From Here===============================================--%>
                <div class="leaveApplication_container">
                    <asp:HiddenField ID="hdnUom" runat="server" />
                    <asp:HiddenField ID="hdnValue" runat="server" />
                    <asp:HiddenField ID="hdnPreConfirm" runat="server" />
                    <asp:HiddenField ID="hdnTransfromValue" runat="server" />
                    <asp:HiddenField ID="hdnStockQty" runat="server" />
                    <div class="tabs_container">INVENTORY LOAN PAY
                        <hr />
                    </div>

                    <table style="width: 750px; text-align: center">
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td style="text-align: right;">WH Name:</td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlWh" CssClass="ddList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlWh_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                    </table>
                    <table style="border-radius: 10px; width: 700px; border-style: groove">
                        
                        <tr>
                            <td style='text-align: left;'>To Pay</td>
                            <td style='text-align: left;'>
                                <asp:DropDownList ID="ddlFrom" CssClass="ddList" runat="server" Width="300px" AutoPostBack="True"></asp:DropDownList></td>
                            <td style='text-align: left; width: 120px'>Location</td>
                            <td style='text-align: left;'>
                                <asp:DropDownList ID="ddlLocation" CssClass="ddList" runat="server" Width="300px" AutoPostBack="false"></asp:DropDownList></td>

                        </tr>
                        <tr>

                            <td style='text-align: left;'>Item</td>
                            <td>
                                <asp:TextBox ID="txtItem" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" Width="300px" OnTextChanged="txtItem_TextChanged"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtItem"
                                    ServiceMethod="GetIndentItemSerach" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>
                            <td style="text-align: right">
                                <asp:Label ID="Label1" Text="Quantity" runat="server"></asp:Label></td>
                            <td style="text-align: left">
                                <asp:TextBox ID="txtReceQty" CssClass="txtBox" Text="0" Width="70px" TextMode="Number" runat="server"></asp:TextBox>Value
             <asp:TextBox ID="txtValue" CssClass="txtBox" Width="70px" TextMode="Number" Text="0" runat="server"></asp:TextBox>
                                <asp:Label ID="lblUom" runat="server" ForeColor="Blue"></asp:Label>
                            </td>

                        </tr>
                        <tr>
                            <td style='text-align: left;'>Remarks</td>
                            <td style='text-align: left;' colspan="3">
                                <asp:TextBox ID="txtRemarks" Width="400px" runat="server" CssClass="txtBox" AutoPostBack="false"></asp:TextBox>
                                <asp:Label ID="lblDetalis" runat="server" ForeColor="Blue"></asp:Label>
                                <asp:Button ID="btnReceive" runat="server" Text="Submit" OnClientClick="return Confirms();" OnClick="btnReceive_OnClick" />
                            </td>
                        </tr>


                    </table>

                </div>

                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

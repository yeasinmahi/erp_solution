<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="POSupport.aspx.cs" Inherits="UI.Support.POSupport" %>
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

    <script language="javascript" type="text/javascript">
        function onlyNumbers(evt) {
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;

            if ((charCode > 57))
                return false;
            return true;
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $("[id*=txtQty]").val("0");
        });

        $("[id*=txtQty]").live("change", function () {
            if (isNaN(parseFloat($(this).val()))) {
                $(this).val('0');
            } else { parseFloat($(this).val($(this).val()).toString()).toFixed(2); }
        });
        //*** txtQty Selection Change Start ****************************************************************************
        $("[id*=txtQty]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') {

                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                    $("[id*=lblTotalVal]", row).html((((parseFloat($("[id*=txtRate]", row).val()) + parseFloat($("[id*=txtVAT]", row).val()) + parseFloat($("[id*=lblAIT]", row).html()))) * ($(this).val())).toFixed(2));
                }
            } else {
                $(this).val('');
            }

            //var at = parseFloat($("[id*=lblAIT]", row).html());
            //var atc = $("[id*=lblAIT]", row).val();
            //var atch = $("[id*=lblAIT]", row).html();

            var grandTotal = 0;
            var grandTotalqty = 0;
            var grandTotalVat = 0;
            var grandTotalait = 0;

            $("[id*=lblTotalVal]").each(function () {
                grandTotal = grandTotal + parseFloat($(this).html());
            });
            $("[id*=lblGrandTotal]").html(parseFloat(grandTotal.toString()).toFixed(2));

            $("[id*=lblAIT]").each(function () {
                grandTotalait = grandTotalait + parseFloat($(this).html());
            });
            $("[id*=lblGrandTotalAIT]").html(grandTotalait.toString());

            $("[id*=txtQty]").each(function () {
                grandTotalqty = grandTotalqty + parseFloat($(this).val());
            });
            $("[id*=lblGrandTotalQty]").html(parseFloat(grandTotalqty.toString()).toFixed(2));

            $("[id*=txtVAT]").each(function () {
                grandTotalVat = grandTotalVat + parseFloat($(this).val());
            });
            $("[id*=lblGrandTotalVAT]").html(grandTotalVat.toString());
        });
        //*** txtQty Selection Change End ****************************************************************************        
        //*** txtRate Selection Change Start ****************************************************************************
        $(function () {
            $("[id*=txtRate]").val("0");
        });

        $("[id*=txtRate]").live("change", function () {
            if (isNaN(parseFloat($(this).val()))) {
                $(this).val('0');
            } else { parseFloat($(this).val($(this).val()).toString()).toFixed(2); }
        });

        $("[id*=txtRate]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') {

                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                    $("[id*=lblTotalVal]", row).html((parseFloat($("[id*=txtQty]", row).val()) * (parseFloat($(this).val()) + parseFloat($("[id*=txtVAT]", row).val()) + parseFloat($("[id*=lblAIT]", row).html()))).toFixed(2));
                }
            } else {
                $(this).val('');
            }

            var grandTotal = 0;
            var grandTotalqty = 0;
            var grandTotalVat = 0;
            var grandTotalait = 0;

            $("[id*=lblTotalVal]").each(function () {
                grandTotal = grandTotal + parseFloat($(this).html());
            });
            $("[id*=lblGrandTotal]").html(parseFloat(grandTotal.toString()).toFixed(2));

            $("[id*=lblAIT]").each(function () {
                grandTotalait = grandTotalait + parseFloat($(this).html());
            });
            $("[id*=lblGrandTotalAIT]").html(grandTotalait.toString());

            $("[id*=txtQty]").each(function () {
                grandTotalqty = grandTotalqty + parseFloat($(this).val());
            });
            $("[id*=lblGrandTotalQty]").html(grandTotalqty.toString());

            $("[id*=txtVAT]").each(function () {
                grandTotalVat = grandTotalVat + parseFloat($(this).val());
            });
            $("[id*=lblGrandTotalVAT]").html(grandTotalVat.toString());

        });
        //*** txtRate Selection Change End ****************************************************************************
        //*** txtVAT Selection Change Start ****************************************************************************
        $(function () {
            $("[id*=txtVAT]").val("0");
        });

        $("[id*=txtVAT]").live("change", function () {
            if (isNaN(parseFloat($(this).val()))) {
                $(this).val('0');
            } else { parseFloat($(this).val($(this).val()).toString()).toFixed(2); }
        });

        $("[id*=txtVAT]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') {

                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                    $("[id*=lblTotalVal]", row).html((parseFloat($("[id*=txtQty]", row).val()) * (parseFloat($(this).val()) + parseFloat($("[id*=txtRate]", row).val()) + parseFloat($("[id*=lblAIT]", row).html()))).toFixed(2));
                }
            } else {
                $(this).val('');
            }

            var grandTotal = 0;
            var grandTotalqty = 0;
            var grandTotalVat = 0;
            var grandTotalait = 0;

            $("[id*=lblTotalVal]").each(function () {
                grandTotal = grandTotal + parseFloat($(this).html());
            });
            $("[id*=lblGrandTotal]").html(parseFloat(grandTotal.toString()).toFixed(2));

            $("[id*=lblAIT]").each(function () {
                grandTotalait = grandTotalait + parseFloat($(this).html());
            });
            $("[id*=lblGrandTotalAIT]").html(grandTotalait.toString());

            $("[id*=txtQty]").each(function () {
                grandTotalqty = grandTotalqty + parseFloat($(this).val());
            });
            $("[id*=lblGrandTotalQty]").html(grandTotalqty.toString());

            $("[id*=txtVAT]").each(function () {
                grandTotalVat = grandTotalVat + parseFloat($(this).val());
            });
            $("[id*=lblGrandTotalVAT]").html(grandTotalVat.toString());
        });
        //*** txtVAT Selection Change End ****************************************************************************

</script>
    
</head>
<body>
    <form id="frmPOSupport" runat="server">
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
    <asp:HiddenField ID="hdnconfirm" runat="server" />
    <div class="leaveApplication_container"> 
        <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
        <asp:HiddenField ID="hdnPOUnit" runat="server"/>
        
        <div class="tabs_container"> PO CORRECTION<hr /></div>        
        <table  class="tbldecoration" style="width:auto; float:left;">
            <tr>                
                <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="lblPO" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="PO No:"></asp:Label></td>
                <td style="text-align:left;">
                    <asp:TextBox ID="txtPONo" runat="server" Width="150px" CssClass="txtBox" Font-Bold="false" ForeColor="Black" Font-Size="11px" onkeypress="return onlyNumbers();"></asp:TextBox>
                    <asp:Button ID="btnShow" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Show" OnClick="btnShow_Click"/>
                </td>                                                       
                    
                <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="lblMRRNoLbl" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="MRR No:"></asp:Label></td>
                <td style="font-weight:bold; text-align:left; color:#3369ff;"><asp:Label ID="lblMRRNo" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px"></asp:Label></td>            
              </tr>
            <tr>
                 <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="lblPOType" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="P.O Type:"></asp:Label></td>
                <td style="font-weight:bold; text-align:left; color:#3369ff;"><asp:Label ID="lblPOTypevalue" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px"></asp:Label></td>            
                 <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="lblsupplierName" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text=" Supplier Name:"></asp:Label></td>
                <td style="font-weight:bold; text-align:left; color:#000000;"><asp:DropDownList ID="drdlsupplierbaseonunit" CssClass="ddList"  AutoPostBack="true" runat="server" OnSelectedIndexChanged="drdlsupplierbaseonunit_SelectedIndexChanged"></asp:DropDownList></td>            
                 <%--<td style="text-align:left;"><asp:TextBox ID="txtMRRNo" runat="server" CssClass="txtBox" Width="80px" BackColor="LightGray" BorderColor="Gray" onkeypress="return onlyNumbers();"></asp:TextBox></td>--%>                                      

            </tr>
            <tr><td colspan="4"><hr /></td></tr>               
            <tr><td colspan="4" style="font-weight:bold; font-size:11px; color:#3369ff;">PO Information:<hr /></td></tr>
                 
            <tr>                    
                <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="lblSuppN" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Supplier:"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtSupplierList" runat="server" ReadOnly="true" AutoPostBack="true"  CssClass="txtBox" TextMode="MultiLine" Width="210px" Font-Bold="false" ForeColor="Black" Font-Size="11px" OnTextChanged="txtSupplierList_TextChanged"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtSupplierList"
                ServiceMethod="GetSupplierList" MinimumPrefixLength="1" CompletionSetCount="1"
                CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                </cc1:AutoCompleteExtender></td>

                    
                <%--<td style="text-align:left;">
                    <asp:DropDownList ID="ddlSuppN" CssClass="ddList" Font-Bold="false" ForeColor="Green" Font-Size="11px" runat="server" AutoPostBack="false"></asp:DropDownList>                                                                                       
                </td> --%>
                    
                <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="Label3" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="No of Shipment"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtNoofShipment" runat="server" Width="210px" CssClass="txtBox" Font-Bold="false" ForeColor="Black" Font-Size="11px" onkeypress="return onlyNumbers();"></asp:TextBox></td> 
            </tr>
            <tr>
                <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="lblCurrency" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Currency:"></asp:Label></td>
                <td style="text-align:left;">
                    <asp:DropDownList ID="ddlCurrency" CssClass="ddList" Font-Bold="false" ForeColor="Black" Font-Size="11px" runat="server"></asp:DropDownList>                                                                                       
                </td>

                <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="Label5" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Last Shipment Date:"></asp:Label></td>                
                <td><asp:TextBox ID="txtLastShipmentDate" runat="server" AutoPostBack="false" CssClass="txtBox" Font-Bold="false" ForeColor="Black" Font-Size="11px" Enabled="true" Width="210px"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtLastShipmentDate"></cc1:CalendarExtender></td>                                     
            </tr>
            <tr>
                <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="lblPODate" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="PO Date :"></asp:Label></td>                
                <td><asp:TextBox ID="txtPODate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="210px" Font-Bold="false" ForeColor="Black" Font-Size="11px"></asp:TextBox>
                <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtPODate"></cc1:CalendarExtender></td> 

                <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="Label4" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Payment terms"></asp:Label></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlPaymentTerms" runat="server" CssClass="ddList" Font-Bold="false" ForeColor="Black" Font-Size="11px">
                <asp:ListItem Selected="True" Value="1">Cash</asp:ListItem><asp:ListItem Value="2">Credit</asp:ListItem>
                <asp:ListItem Value="3">Advance</asp:ListItem></asp:DropDownList></td>                    
            </tr>
            <tr>
                <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="Label8" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Transport Amount:"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtTransport" runat="server" Width="210px" Font-Bold="false" ForeColor="Black" Font-Size="11px" CssClass="txtBox" onkeypress="return onlyNumbers();"></asp:TextBox></td> 

                <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px"  Width="200px"  Text="Payment days after MRR (days)"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtPaymentdaysAfterMRR" runat="server" Width="210px" CssClass="txtBox" Font-Bold="false" ForeColor="Black" Font-Size="11px" onkeypress="return onlyNumbers();"></asp:TextBox></td> 
            </tr>
            <tr>
                <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="Label9" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Gross Discount:"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtGDiscount" runat="server" Width="210px" Font-Bold="false" ForeColor="Black" Font-Size="11px" CssClass="txtBox" onkeypress="return onlyNumbers();"></asp:TextBox></td> 

                <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="Label6" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px"  Width="280px"  Text="No of Installment (for installment Payment)"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtNoOfInstallment" runat="server" Width="210px" CssClass="txtBox" Font-Bold="false" ForeColor="Black" Font-Size="11px" onkeypress="return onlyNumbers();"></asp:TextBox></td>                     
            </tr>
            <tr>
                <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="Label10" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Others Amount:"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtOthers" runat="server" Width="210px" Font-Bold="false" ForeColor="Black" Font-Size="11px" CssClass="txtBox" onkeypress="return onlyNumbers();"></asp:TextBox></td> 

                <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="Label13" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px"  Width="280px"  Text="Installment Interval (Days, for installment)"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtInstallmentIntervalDays" runat="server" Width="210px" CssClass="txtBox" Font-Bold="false" ForeColor="Black" Font-Size="11px" onkeypress="return onlyNumbers();"></asp:TextBox></td>                     
            </tr>
            <tr>
                <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Partial Shipment"></asp:Label></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlPartialShipment" runat="server" CssClass="ddList" Font-Bold="false" ForeColor="Black" Font-Size="11px">
                <asp:ListItem Selected="True" Value="0">FALSE</asp:ListItem><asp:ListItem Value="1">TRUE</asp:ListItem></asp:DropDownList></td>                    

                <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="Label7" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Destination For Delivery"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtDestinationForDelivery" runat="server" Width="210px" Font-Bold="false" ForeColor="Black" Font-Size="11px" CssClass="txtBox"></asp:TextBox></td> 
            </tr>
            <tr>
                <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="Label15" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Others terms"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtOtherTerms" TextMode="MultiLine" runat="server" Width="210px" Font-Bold="false" ForeColor="Black" Font-Size="11px" CssClass="txtBox"></asp:TextBox></td>                                         
                    
                <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="Label14" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Warrenty after delivery (in months)"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtWarrentyAfterDelivery" runat="server" Width="210px" Font-Bold="false" ForeColor="Black" Font-Size="11px" CssClass="txtBox" onkeypress="return onlyNumbers();"></asp:TextBox></td>                     
            </tr>
            <tr>
                <td colspan="4" style="text-align:left;"><asp:Button ID="btnUpdate" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Update" OnClientClick="ConfirmAll()" OnClick="btnUpdate_Click"/></td> 
            </tr>
            <%--<tr><td colspan="4"><hr /></td></tr>--%>               
            <%--<tr><td colspan="4" style="font-weight:bold; font-size:11px; color:#3369ff;">Item Description:<hr /></td></tr>--%>
            <%--<tr>                
                <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="Label16" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Indent:"></asp:Label></td>
                <td style="text-align:left;">
                    <asp:TextBox ID="txtIndent" runat="server" Width="150px" CssClass="txtBox" onkeypress="return onlyNumbers();"></asp:TextBox>
                    <asp:Button ID="btnIndentShow" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Show" OnClick="btnIndentShow_Click"/>
                </td>                                                       
                    
                <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="Label17" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Stutas:"></asp:Label></td>
                <td style="font-weight:bold; text-align:left; color:#0b6016;"><asp:Label ID="lblStatus" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px"></asp:Label></td>                                
            </tr>
            <tr>
                <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="Label11" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Item Name:"></asp:Label></td>
                <td style="text-align:left;">
                    <asp:DropDownList ID="ddlItemName" CssClass="ddList" Font-Bold="false" ForeColor="Green" Font-Size="11px" runat="server"></asp:DropDownList>                                                                                       
                </td>

                <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="Label18" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="HS Code:"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtHSCode" runat="server" Width="210px" CssClass="txtBox"></asp:TextBox></td> 
            </tr>
            <tr>
                <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="Label12" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Indent Qty.:"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtIndentQty" runat="server" Width="210px" CssClass="txtBox" onkeypress="return onlyNumbers();"></asp:TextBox></td> 

                <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="Label19" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="PO Qty.:"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtPOQty" runat="server" Width="210px" CssClass="txtBox" onkeypress="return onlyNumbers();"></asp:TextBox></td> 
            </tr>
            <tr>
                <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="Label20" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Rate:"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtRatAdd" runat="server" Width="210px" CssClass="txtBox" onkeypress="return onlyNumbers();"></asp:TextBox></td> 

                <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="Label21" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="VAT:"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtVtAdd" runat="server" Width="210px" CssClass="txtBox" onkeypress="return onlyNumbers();"></asp:TextBox></td> 
            </tr>
                
            <tr>
                <td colspan="4" style="text-align:left;">
                    <asp:Button ID="btnAdd" runat="server" class="nextclick" Font-Bold="true" ForeColor="Green" OnClick="btnAdd_Click" Text="Add New Item" />
                </td>
            </tr>--%>            
        </table>
        </div>

        <div id="divItemInfo" runat="server" class="leaveApplication_container">     
        <table  class="tbldecoration" style="width:auto; float:left;">
            <tr><td colspan="4" style="font-weight:bold; font-size:11px; color:#3369ff;">Item Description:<hr /></td></tr>
            <%--<tr><td> <hr /> </td></tr>--%>
            <tr>
                <td>
                    <asp:GridView ID="dgvItemInfoByPO" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" Font-Size="10px" FooterStyle-BackColor="#999999" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" OnRowDataBound="dgvItemInfoByPO_RowDataBound" ShowFooter="true" OnRowDeleting="dgvItemInfoByPO_RowDeleting">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                    <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
                                    
                    <asp:TemplateField HeaderText="Item ID" SortExpression="intemid" Visible="true">
                    <ItemTemplate><asp:Label ID="lblItemID" runat="server" Text='<%# Bind("intemid") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>

                    <asp:TemplateField HeaderText="Item Name" SortExpression="itemname">
                    <ItemTemplate><asp:Label ID="lblItemName" runat="server" Text='<%# Bind("itemname") %>' Width="230px"></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="230px" />
                    <FooterTemplate><asp:Label ID="lblT" runat="server" Text="Total" /></FooterTemplate></asp:TemplateField>

                    <asp:TemplateField HeaderText="Item Specification" SortExpression="specification">
                    <ItemTemplate><asp:TextBox ID="txtSpecification" runat="server" CssClass="txtBoxGridAmount" Text='<%# Bind("specification") %>' TextMode="MultiLine" Width="300px"></asp:TextBox>
                    </ItemTemplate><ItemStyle HorizontalAlign="left" Width="300px" />
                    <FooterTemplate><asp:Label ID="lblBlank" runat="server" Text=""></asp:Label></FooterTemplate></asp:TemplateField>

                    <asp:TemplateField HeaderText="UOM" SortExpression="uom">
                    <ItemTemplate><asp:Label ID="lblUOM" runat="server" Text='<%# Bind("uom") %>'></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="40px" />
                    <FooterTemplate><asp:Label ID="lblT" runat="server" Text="" /></FooterTemplate></asp:TemplateField>

                    <asp:TemplateField HeaderText="Quantity" SortExpression="qty">
                    <ItemTemplate><asp:TextBox ID="txtQty" runat="server" CssClass="txtBoxGridAmount" DataFormatString="{0:0.00}" onkeypress="return onlyNumbers(event)" Text='<%# Bind("qty") %>' Width="60px"></asp:TextBox>
                    </ItemTemplate><ItemStyle HorizontalAlign="right" Width="60px" />
                    <FooterTemplate><asp:Label ID="lblGrandTotalQty" runat="server" DataFormatString="{0:0.00}" Text="<%# totalqty %>" /></FooterTemplate></asp:TemplateField>

                    <asp:TemplateField HeaderText="Rate" ItemStyle-HorizontalAlign="right" SortExpression="rate">
                    <ItemTemplate><asp:TextBox ID="txtRate" runat="server" CssClass="txtBoxGridAmount" DataFormatString="{0:0.00}" Text='<%# Bind("rate") %>' Width="45px"></asp:TextBox>
                    </ItemTemplate><ItemStyle HorizontalAlign="right" Width="40px" />
                    <FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text="" /></FooterTemplate></asp:TemplateField>

                    <asp:TemplateField HeaderText="VAT" SortExpression="vat">
                    <ItemTemplate><asp:TextBox ID="txtVAT" runat="server" CssClass="txtBoxGridAmount" DataFormatString="{0:0.00}" Text='<%# Bind("vat") %>' Width="45px"></asp:TextBox>
                    </ItemTemplate><ItemStyle HorizontalAlign="right" Width="45px" />
                    <FooterTemplate><asp:Label ID="lblGrandTotalVAT" runat="server" DataFormatString="{0:0.00}" Text="<%# totalvat %>" /></FooterTemplate></asp:TemplateField>

                    <asp:TemplateField HeaderText="AIT" ItemStyle-HorizontalAlign="right" SortExpression="ait">
                    <ItemTemplate><asp:Label ID="lblAIT" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("ait"))) %>'></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="right" Width="40px" />
                    <FooterTemplate><asp:Label ID="lblGrandTotalAIT" runat="server" DataFormatString="{0:0.00}" Text="<%# totalait %>" /></FooterTemplate></asp:TemplateField>

                    <asp:TemplateField HeaderText="Total Value" ItemStyle-HorizontalAlign="right" SortExpression="total">
                    <ItemTemplate><asp:Label ID="lblTotalVal" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("total"))) %>'></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
                    <FooterTemplate><asp:Label ID="lblGrandTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# totalval %>" /></FooterTemplate></asp:TemplateField>
                                    
                    <asp:TemplateField HeaderText="Existing" SortExpression="ysnExisting" Visible="false">
                    <ItemTemplate><asp:Label ID="lblExisting" runat="server" Text='<%# Bind("ysnExisting") %>'></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>

                    <asp:CommandField DeleteText="Update" HeaderText="Update" ShowDeleteButton="True" ControlStyle-Width="40px" ControlStyle-Font-Bold="true" ControlStyle-ForeColor="Blue"/>

                    <%--<asp:TemplateField HeaderText="Indent No" SortExpression="indentno" Visible="true">
                    <ItemTemplate><asp:Label ID="lblIndentNo" runat="server" Text='<%# Bind("indentno") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>

                    <asp:TemplateField HeaderText="PO Qty" SortExpression="poqty" Visible="true">
                    <ItemTemplate><asp:Label ID="lblPOQty" runat="server" Text='<%# Bind("poqty") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>

                    <asp:TemplateField HeaderText="HS Code" SortExpression="hscode" Visible="true">
                    <ItemTemplate><asp:Label ID="lblHSCode" runat="server" Text='<%# Bind("hscode") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>--%>

                    </Columns>
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    </asp:GridView></td>
                </tr>                               
            </table>
        </div>
        
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

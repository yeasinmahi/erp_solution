<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="POGenerate_For_Import.aspx.cs" Inherits="UI.SCM.POGenerate_For_Import" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

    <link href="../Content/CSS/CommonStyle.css" rel="stylesheet" />
    <style>
        .TextAlign {
            text-align: left;
        }
    </style>
    <script type="text/javascript">

        //function ViewPriceListPopup(Id) {
        //    window.open('../PaymentModule/PreviousPrice.aspx?ID=' + Id, 'sub', "height=600, width=1050, scrollbars=yes, left=100, top=25, resizable=no, title=Preview");
        //}
        //$("[id*=TxtNewPO]").live("change", function () {
        //    if (!jQuery.trim($(this).val()) == '') {
        //        if (!isNaN(parseFloat($(this).val()))) {
        //            var row = $(this).closest("tr");
        //            var IssueQty = parseFloat($(this).val())
        //            var StockQty = parseFloat($("[id*=lblRemaining]", row).html());
        //            if (StockQty < IssueQty) {
        //                $("[id*=TxtNewPO]", row).val('0');
        //                alert("Please Check Po Quantity");
        //            }

        //        }
        //    }


        //});



        <%-- Normal Textbox Onkey  Text Change Gridview row data  Calculation with ground Total --%>
        //function PoGenerateCheck() {

        //    var suppId = document.getElementById("txtSupplier").value;
        //    var e = document.getElementById("ddlWHPrepare");
        //    var whId = e.options[e.selectedIndex].value;
        //    var e = document.getElementById("ddlCurrency");
        //    var currencyId = e.options[e.selectedIndex].value;
        //    var e = document.getElementById("ddlCostCenter");
        //    var costId = e.options[e.selectedIndex].value;
        //    var e = document.getElementById("ddlPaymentTrams");
        //    var paymentTremsId = e.options[e.selectedIndex].value;

        //    var noOfShipment = document.getElementById("txtNoOfShipment").value;
        //    var afterMrrDay = document.getElementById("txtAfterMrrDay").value;
        //    var destDelivery = document.getElementById("txtDestinationDelivery").value;
        //    var lastShipmentDte = document.getElementById("txtLastShipmentDate").value;
        //    var poDateText = document.getElementById("txtdtePo").value;

        //    var poDate = new Date(poDateText);
        //    var lastShipmentDate = new Date(lastShipmentDte);

        //    if ($.trim(poDateText).length < 3 ||
        //        $.trim(poDateText) == "" ||
        //        $.trim(poDateText) == null ||
        //        $.trim(poDateText) == undefined) {
        //        document.getElementById("hdnPreConfirm").value = "0";
        //        alert('Please Check PO Date');
        //    }
        //    else if ($.trim(suppId).length < 3 ||
        //        $.trim(suppId) == "" ||
        //        $.trim(suppId) == null ||
        //        $.trim(suppId) == undefined) {
        //        document.getElementById("hdnPreConfirm").value = "0";
        //        alert('Please Set Suppliyer');
        //    }
        //    else if ($.trim(currencyId) == 0 ||
        //        $.trim(currencyId) == "" ||
        //        $.trim(currencyId) == null ||
        //        $.trim(currencyId) == undefined) {
        //        document.getElementById("hdnPreConfirm").value = "0";
        //        alert('Please select Currency');
        //    }
        //    else if ($.trim(paymentTremsId) == 0 ||
        //        $.trim(paymentTremsId) == "" ||
        //        $.trim(paymentTremsId) == null ||
        //        $.trim(paymentTremsId) == undefined) {
        //        document.getElementById("hdnPreConfirm").value = "0";
        //        alert('Please select PaymentTrems');
        //    }
        //    else if ($.trim(noOfShipment) == 0 ||
        //        $.trim(noOfShipment) == "" ||
        //        $.trim(noOfShipment) == null ||
        //        $.trim(noOfShipment) == undefined) {
        //        document.getElementById("hdnPreConfirm").value = "0";
        //        alert('Please set Number of Shipment');
        //    }
        //    else if ($.trim(afterMrrDay) == 0 ||
        //        $.trim(afterMrrDay) == "" ||
        //        $.trim(afterMrrDay) == null ||
        //        $.trim(afterMrrDay) == undefined) {
        //        document.getElementById("hdnPreConfirm").value = "0";
        //        alert('Please set After MRR Day');
        //    }
        //    else if ($.trim(destDelivery).length < 1 ||
        //        $.trim(destDelivery) == "" ||
        //        $.trim(destDelivery) == null ||
        //        $.trim(destDelivery) == undefined) {
        //        document.getElementById("hdnPreConfirm").value = "0";
        //        alert('Please set Destination Delivery');
        //    }
        //    else if ($.trim(lastShipmentDte).length < 3 ||
        //        $.trim(lastShipmentDte) == "" ||
        //        $.trim(lastShipmentDte) == null ||
        //        $.trim(lastShipmentDte) == undefined) {
        //        document.getElementById("hdnPreConfirm").value = "0";
        //        alert('Please set Last Shipment Date');
        //    } else if (poDate > lastShipmentDate) {
        //        document.getElementById("hdnPreConfirm").value = "0";
        //        alert('Last Shipment Date can not be less than PO Date');
        //    }
        //    else {
        //        var confirmValue = document.createElement("INPUT");
        //        confirmValue.type = "hidden";
        //        confirmValue.name = "confirm_value";
        //        if (confirm("Do you want to proceed?")) {
        //            confirmValue.value = "Yes";
        //            document.getElementById("hdnPreConfirm").value = "1";
        //        } else {
        //            confirmValue.value = "No";
        //            document.getElementById("hdnPreConfirm").value = "0";
        //        }

        //        // document.getElementById("hdnPreConfirm").value = "1";
        //    }


        //}
        //function validation() {
        //    var poDateText = document.getElementById("txtdtePo").value;
        //    var lastShipmentDateText = document.getElementById("txtLastShipmentDate").value;
        //    if (poDateText == null || poDateText == "") {
        //        return false;
        //    } else if (lastShipmentDateText == null || lastShipmentDateText == "") {
        //        return false;
        //    }
        //    var poDate = new Date(poDateText);
        //    var lastShipmentDate = new Date(lastShipmentDateText);
        //    if (poDate > lastShipmentDate) {
        //        return false;
        //    }
        //    return true;
        //}

        function GetCommision(txt) {

            var row = $(this).closest("tr");
            var ait = parseFloat($("[id*=lblGrandTotalAIT]").html());
            $("[id*=lblGrandTotalAIT]").html(parseFloat(ait + parseFloat(txt.value)));


        }

        //function GetAIT(txt) {
        //    $("[id*=txtAIT]").each(function () {
        //        var row = $(this).closest("tr");
        //        var rate = parseFloat($("[id*=txtRate]", row).val());

        //        $("[id*=txtAIT]", row).val((rate * parseFloat(txt.value.toString())) / 100);
        //    });

        //    $("[id*=lblTotalVal]").each(function () {
        //        var row = $(this).closest("tr");
        //        var a = parseFloat($("[id*=lblQty]", row).html());
        //        var b = parseFloat($("[id*=txtVAT]", row).val());
        //        var c = parseFloat($("[id*=txtAIT]", row).val());
        //        var e = parseFloat($("[id*=txtRate]", row).val());
        //        $("[id*=lblTotalVal]", row).html(a * (e + b + c)).toFixed(2);
        //    });

        //    var grandTotal = 0;
        //    var grandTotalqty = 0;
        //    var grandTotalVat = 0;
        //    var grandTotalait = 0;

        //    $("[id*=lblTotalVal]").each(function () {
        //        grandTotal = grandTotal + parseFloat($(this).html());
        //    });
        //    $("[id*=lblGrandTotal]").html(parseFloat(grandTotal.toString()).toFixed(2));

        //    $("[id*=txtAIT]").each(function () {
        //        grandTotalait = grandTotalait + parseFloat($(this).val());
        //    });
        //    $("[id*=lblGrandTotalAIT]").html(grandTotalait.toString());

        //    $("[id*=lblQty]").each(function () {
        //        grandTotalqty = grandTotalqty + parseFloat($(this).html());
        //    });
        //    $("[id*=lblGrandTotalQty]").html(parseFloat(grandTotalqty.toString()).toFixed(2));

        //    $("[id*=txtVAT]").each(function () {
        //        grandTotalVat = grandTotalVat + parseFloat($(this).val());
        //    });
        //    $("[id*=lblGrandTotalVAT]").html(grandTotalVat.toString());

        //}

        //function Registration(url) {
        //    newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=900,top=50,left=220, close=no');
        //    if (window.focus) { newwindow.focus() }
        //}
    </script>

    <%-- GridView Text Change Calculation --%>
    <%--<script type="text/javascript">

        $(function () {
            ////$("[id*=txtQty]").val("0");
        });

        $("[id*=lblQty]").live("change", function () {
            if (isNaN(parseFloat($(this).val()))) {
                $(this).val('0');
            } else { parseFloat($(this).val($(this).val()).toString()).toFixed(2); }
        });
        //*** txtQty Selection Change Start ****************************************************************************
        $("[id*=lblQty]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') {

                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                    $("[id*=lblTotalVal]", row).html((((parseFloat($("[id*=txtRate]", row).val()) + parseFloat($("[id*=txtVAT]", row).val()) + parseFloat($("[id*=txtAIT]", row).val()))) * ($(this).val())).toFixed(2));
                }
            } else {
                $(this).val('');
            }

            //var at = parseFloat($("[id*=txtAIT]", row).val());
            //var atc = $("[id*=txtAIT]", row).val();
            //var atch = $("[id*=txtAIT]", row).val();

            var grandTotal = 0;
            var grandTotalqty = 0;
            var grandTotalVat = 0;
            var grandTotalait = 0;

            $("[id*=lblTotalVal]").each(function () {
                grandTotal = grandTotal + parseFloat($(this).html());
            });
            $("[id*=lblGrandTotal]").html(parseFloat(grandTotal.toString()).toFixed(2));

            $("[id*=txtAIT]").each(function () {
                grandTotalait = grandTotalait + parseFloat($(this).val());
            });
            $("[id*=lblGrandTotalAIT]").html(grandTotalait.toString());

            $("[id*=lblQty]").each(function () {
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
            ////$("[id*=txtRate]").val("0");
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
                    var a = parseFloat($("[id*=lblQty]", row).html());
                    var b = parseFloat($("[id*=txtVAT]", row).val());
                    var c = parseFloat($("[id*=txtAIT]", row).val());
                    var d = parseFloat($(this).val());
                    var rtotal = parseFloat(a * (d + b + c));
                    $("[id*=lblTotalVal]", row).html(rtotal.toFixed(3));

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

            $("[id*=txtAIT]").each(function () {
                grandTotalait = grandTotalait + parseFloat($(this).val());
            });
            $("[id*=lblGrandTotalAIT]").html(grandTotalait.toString());

            $("[id*=lblQty]").each(function () {
                grandTotalqty = grandTotalqty + parseFloat($(this).html());
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
            ////$("[id*=txtVAT]").val("0");
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

                    var a = parseFloat($("[id*=lblQty]", row).html());
                    var b = parseFloat($("[id*=txtRate]", row).val());
                    var c = parseFloat($("[id*=txtAIT]", row).val());
                    var d = parseFloat($(this).val());
                    var rtotal = parseFloat(a * (b + d + c));
                    $("[id*=lblTotalVal]", row).html(rtotal.toFixed(3));

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

            $("[id*=txtAIT]").each(function () {
                grandTotalait = grandTotalait + parseFloat($(this).val());
            });
            $("[id*=lblGrandTotalAIT]").html(parseFloat(grandTotalait.toString()).toFixed(2));

            $("[id*=lblQty]").each(function () {
                grandTotalqty = grandTotalqty + parseFloat($(this).html());
            });
            $("[id*=lblGrandTotalQty]").html(parseFloat(grandTotalqty.toString()).toFixed(2));

            $("[id*=txtVAT]").each(function () {
                grandTotalVat = grandTotalVat + parseFloat($(this).val());
            });
            $("[id*=lblGrandTotalVAT]").html(grandTotalVat.toString());
        });
        //*** txtVAT Selection Change End ****************************************************************************

        //*** txtAIT Selection Change Start ****************************************************************************

        $(function () {

        });

        $("[id*=txtAIT]").live("change", function () {
            if (isNaN(parseFloat($(this).val()))) {
                $(this).val('0');
            } else { parseFloat($(this).val($(this).val()).toString()).toFixed(2); }
        });

        $("[id*=txtAIT]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') {

                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                    var a = parseFloat($("[id*=lblQty]", row).html());
                    var b = parseFloat($("[id*=txtRate]", row).val());
                    var c = parseFloat($("[id*=txtVAT]", row).val());
                    var d = parseFloat($(this).val());
                    var rtotal = parseFloat(a * (b + c + d));
                    $("[id*=lblTotalVal]", row).html(rtotal.toFixed(3));


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

            $("[id*=txtAIT]").each(function () {
                grandTotalait = grandTotalait + parseFloat($(this).val());
            });
            $("[id*=lblGrandTotalAIT]").html(parseFloat(grandTotalait.toString()).toFixed(2));

            $("[id*=lblQty]").each(function () {
                grandTotalqty = grandTotalqty + parseFloat($(this).html());
            });
            $("[id*=lblGrandTotalQty]").html(parseFloat(grandTotalqty.toString()).toFixed(2));

            $("[id*=txtVAT]").each(function () {
                grandTotalVat = grandTotalVat + parseFloat($(this).val());
            });
            $("[id*=lblGrandTotalVAT]").html(grandTotalVat.toString());
        });
        //*** txtAIT Selection Change End ****************************************************************************
    </script>--%>




    <%--    <style type="text/css">
        .Initial {
            display: block;
            padding: 4px 18px 4px 18px;
            float: left;
            background: url("../Images/InitialImage.png") no-repeat right top;
            color: Black;
            font-weight: bold;
        }

            .Initial:hover {
                color: White;
                background: #eeeeee;
            }

        .Clicked {
            float: left;
            display: block;
            background: padding-box;
            padding: 4px 18px 4px 18px;
            color: Black;
            font-weight: bold;
            color: Green;
        }
    </style>
    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
    </style>--%>
</head>
<body>
    <form id="frmaccountsrealize" runat="server">

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
                <div id="loading"></div>
                <%--=========================================Start My Code From Here===============================================--%>
                <div class="leaveApplication_container">
                    <asp:HiddenField ID="hdnEnroll" runat="server" />
                    <asp:HiddenField ID="hdnsearch" runat="server" />
                    <asp:HiddenField ID="hdnUnitId" runat="server" />
                    <asp:HiddenField ID="hdnUnitName" runat="server" />
                    <asp:HiddenField ID="hdnWHId" runat="server" />
                    <asp:HiddenField ID="hdnWHName" runat="server" />
                    <asp:HiddenField ID="hdnPreConfirm" runat="server" />
                    <td>
                        <asp:Label ID="lblPoNo" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="#000099"></asp:Label>


                        <%--<asp:MultiView ID="MainView" runat="server">

                            <%--//Indent Detalis TAB--%>

                        <%--//Po Prepare TAB--%>
                        <%--<asp:View ID="View3" runat="server">--%>
                        <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                            <table>
                                <caption>
                                    <asp:Label ID="lblSuppAddress" ForeColor="Red" Font-Size="Small" runat="server"></asp:Label>
                                </caption>

                                <tr>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="WH-Name"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:DropDownList ID="ddlWHPrepare" runat="server" AutoPostBack="false" CssClass="ddList" Font-Bold="False">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label6" runat="server" CssClass="lbl" Text="Supplier"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtSupplier" runat="server" AutoCompleteType="Search" placeholder="Search" CssClass="txtBox" AutoPostBack="true" Width="300px" OnTextChanged="txtSupplier_TextChanged"></asp:TextBox>
                                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSupplier"
                                            ServiceMethod="GetSupplierSearch" MinimumPrefixLength="1" CompletionSetCount="1"
                                            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                        </cc1:AutoCompleteExtender>
                                    </td>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label8" runat="server" CssClass="lbl" Text="Transport"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtTransport" runat="server" AutoPostBack="false" CssClass="txtBox" Font-Bold="False" Text="0"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label7" runat="server" CssClass="lbl" Text="CostCenter"></asp:Label></td>

                                    <td style="text-align: left;">
                                        <asp:DropDownList ID="ddlCostCenter" runat="server" AutoPostBack="false" CssClass="ddList" Font-Bold="False"></asp:DropDownList></td>

                                    <td style="text-align: right;">
                                        <asp:Label ID="Label9" runat="server" CssClass="lbl" Text="Others:"></asp:Label>
                                    </td>

                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtOthers" runat="server" Text="0" AutoPostBack="false" CssClass="txtBox" Font-Bold="False"> </asp:TextBox>
                                    </td>

                                    <td style="text-align: right;">
                                        <asp:Label ID="Label10" runat="server" CssClass="lbl" Text="Gross Discount: "></asp:Label></td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtGrossDiscount" runat="server" Text="0" AutoPostBack="false" CssClass="txtBox" Font-Bold="False"></asp:TextBox></td>

                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label11" runat="server" CssClass="lbl" Text="Currancy"></asp:Label></td>
                                    <td style="text-align: left;">
                                        <asp:DropDownList ID="ddlCurrency" runat="server" AutoPostBack="false" CssClass="ddList" Font-Bold="False"></asp:DropDownList>
                                    </td>

                                    <td style="text-align: right;">
                                        <asp:Label ID="Label12" runat="server" CssClass="lbl" Text="Pay Date: "></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:DropDownList ID="ddlDtePay" Enabled="false" runat="server" AutoPostBack="false" CssClass="ddList" Font-Bold="False">
                                        </asp:DropDownList></td>

                                    <td style="text-align: right;">
                                        <asp:Label ID="Label13" runat="server" CssClass="lbl" Text="Commision: "></asp:Label></td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtCommosion" runat="server" onkeyup="GetCommision(this);" CssClass="txtBox" AutoPostBack="false" Font-Bold="False">
                                        </asp:TextBox><asp:Button ID="btnCommision" runat="server" Text="Set commission" Visible="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label36" runat="server" CssClass="lbl" Text="PI NO: "></asp:Label></td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtPINo" runat="server" AutoPostBack="false" CssClass="txtBox" Font-Bold="False"> 
                                        </asp:TextBox></td>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label35" runat="server" CssClass="lbl" Text="PI Date:"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtPIDate" Enabled="false" runat="server" autocomplete="off" CssClass="txtBox" Font-Bold="False"> 
                                        </asp:TextBox><cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtPIDate"></cc1:CalendarExtender>
                                    </td>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label37" runat="server" CssClass="lbl" Text="LC Exp Date:"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtLCExpDate" Enabled="false" runat="server" autocomplete="off" CssClass="txtBox" Font-Bold="False"> 
                                        </asp:TextBox><cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="txtLCExpDate"></cc1:CalendarExtender>
                                    </td>

                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label14" runat="server" CssClass="lbl" Text="PO Date"></asp:Label>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtdtePo" Enabled="false" runat="server" autocomplete="off" CssClass="txtBox" Font-Bold="False"> 
                                        </asp:TextBox><cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy-MM-dd" TargetControlID="txtdtePo"></cc1:CalendarExtender>
                                    </td>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label15" runat="server" CssClass="lbl" Text="AIT: "></asp:Label></td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtAit" runat="server" onkeyup="GetAIT(this);" Text="0" AutoPostBack="false" CssClass="txtBox" Font-Bold="False"> 
                                        </asp:TextBox></td>
                                    <td></td>
                                    <td style="text-align: left;">
                                        <asp:Button ID="btnGeneratePO" Style="border-radius: 1px; height: 29px" runat="server" Text="Generate PO" ForeColor="blue" OnClientClick="PoGenerateCheck();" OnClick="btnGeneratePO_Click" AutoPostBack="false" />

                                    </td>
                                </tr>


                            </table>
                            <table>
                                <tr>
                                    <td>
                                        <asp:GridView ID="dgvIndentPrepare" runat="server" ShowFooter="true" OnRowDeleting="dgvIndentPrepare_RowDeleting" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" Font-Size="10px" FooterStyle-BackColor="#999999" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical">
                                            <AlternatingRowStyle BackColor="#CCCCCC" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="SL No.">
                                                    <ItemStyle HorizontalAlign="center" Width="30px" />
                                                    <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="IndentId" Visible="false" SortExpression="indentId">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIndentId" runat="server" Text='<%# Bind("indentId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="center" Width="45px" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="IndentQty" Visible="false" SortExpression="numIndentQty">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIndentQty" runat="server" Text='<%# Bind("numIndentQty") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="center" Width="45px" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Item ID" SortExpression="itemId">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblItemId" runat="server" Text='<%# Bind("itemId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="45px" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Item Name" SortExpression="strItem">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("strItem") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Item Specification" ItemStyle-HorizontalAlign="right" SortExpression="strDesc">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("strSpecification") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" Width="150px" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="UOM" ItemStyle-HorizontalAlign="right" SortExpression="strUom" Visible="true">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUom" runat="server" Text='<%# Bind("strUom") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="PreviousRate" ItemStyle-HorizontalAlign="right" SortExpression="monPreviousRate">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPreviousRate" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("monPreviousRate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="HSCode" ItemStyle-HorizontalAlign="right" SortExpression="strHsCode">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblHsCode" runat="server" Text='<%# Bind("strHsCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Quantity" SortExpression="qty">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblQty" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("numNewPo") %>' Width="60px"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="right" Width="60px" />
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblGrandTotalQty" runat="server" DataFormatString="{0:0.00}" Text="0" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Rate" ItemStyle-HorizontalAlign="right" SortExpression="rate">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtRate" runat="server" CssClass="txtBox" DataFormatString="{0:0.00}" Text="0" Width="80px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="right" Width="80px" />
                                                    <FooterTemplate>
                                                        <asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text="" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="VAT" SortExpression="vat">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtVAT" runat="server" CssClass="txtBox" DataFormatString="{0:0.00}" Text="0" Width="80px"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="right" Width="80px" />
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblGrandTotalVAT" runat="server" DataFormatString="{0:0.00}" Text="0" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="AIT" ItemStyle-HorizontalAlign="right" SortExpression="ait">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtAIT" runat="server" DataFormatString="{0:0.00}" CssClass="txtBox" Width="80px" Text="0"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="right" Width="80px" />
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblGrandTotalAIT" runat="server" DataFormatString="{0:0.00}" Text="0" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Total Value" ItemStyle-HorizontalAlign="right" SortExpression="total">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotalVal" runat="server" Text="0"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="right" Width="80px" />
                                                    <FooterTemplate>
                                                        <asp:Label ID="lblGrandTotal" runat="server" DataFormatString="{0:0.00}" Text="0" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>

                                                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True">
                                                    <ControlStyle ForeColor="Red" />
                                                </asp:CommandField>
                                            </Columns>
                                            <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td style="text-align: right;">
                                        <asp:Label ID="lblPartialShip" Text="Partial Shipment:" runat="server" /></td>
                                    <td style="text-align: left;">
                                        <asp:DropDownList ID="ddlPartialShip" AutoPostBack="false" CssClass="ddList" runat="server">
                                            <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td style="text-align: right;">
                                        <asp:Label ID="lblNoOfShip" runat="server" Text="No of Shipment:" /></td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtNoOfShipment" runat="server" CssClass="txtBox" Text="1" /></td>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label1" runat="server" Text="LC Type:" /></td>
                                    <td style="text-align: left;">
                                        <asp:DropDownList ID="ddlLCType" AutoPostBack="True" CssClass="ddList" runat="server">
                                        </asp:DropDownList>

                                    </td>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label2" runat="server" Text="Material Type:" /></td>
                                    <td style="text-align: left;">
                                        <asp:DropDownList ID="ddlMaterialType" AutoPostBack="True" CssClass="ddList" runat="server"></asp:DropDownList></td>

                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label17" runat="server" Text="Last Shipment Date:" /></td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtLastShipmentDate" CssClass="txtBox" runat="server"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="yyyy-MM-dd" TargetControlID="txtLastShipmentDate">
                                        </cc1:CalendarExtender>
                                    </td>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label18" runat="server" Text="Payment terms:" /></td>
                                    <td style="text-align: left;">
                                        <asp:DropDownList ID="ddlPaymentTrams" AutoPostBack="false" CssClass="ddList" runat="server">
                                            <asp:ListItem Text="Select" Selected="True" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Credit" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Advance" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Cash" Value="3"></asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label3" runat="server" Text="Inco Term:" /></td>
                                    <td style="text-align: left;">
                                        <asp:DropDownList ID="ddlIncoTerm" AutoPostBack="True" CssClass="ddList" runat="server"></asp:DropDownList></td>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label4" runat="server" Text="Origin:" /></td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtOrigin" runat="server" CssClass="txtBox" /></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label19" runat="server" Text="Payment Duration:" /></td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtAfterMrrDay" CssClass="txtBox" runat="server" Text="7" /></td>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label20" runat="server" Text="No. of Installment:" /></td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtNoOfInstall" CssClass="txtBox" runat="server" Text="1" /></td>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label16" runat="server" Text="Load Port:" /></td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtLoadPort" runat="server" CssClass="txtBox" /></td>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label27" runat="server" Text="Dest. Port:" /></td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtDestPort" runat="server" CssClass="txtBox" /></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label21" runat="server" Text="Installment Interval:" /></td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtIntervel" runat="server" CssClass="txtBox" Text="0" /></td>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label22" runat="server" Text="Delivery Destination:" /></td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtDestinationDelivery" CssClass="txtBox" runat="server" /></td>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label28" runat="server" Text="Bank:" /></td>
                                    <td style="text-align: left;">
                                        <asp:DropDownList ID="ddlBank" AutoPostBack="True" CssClass="ddList" runat="server"></asp:DropDownList></td>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label29" runat="server" Text="Present(Days):" /></td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtPresentDay" runat="server" CssClass="txtBox" /></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label23" runat="server" Text="No. of Payment:" /></td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtNoOfPayment" runat="server" Text="0" CssClass="txtBox" /></td>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label24" runat="server" Text="Payment Schedule:" /></td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtPaymentSchedule" CssClass="txtBox" runat="server" /></td>
                                    <td colspan="4">
                                        <table>
                                            <tr>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label30" runat="server" Text="Tenor(month):" /></td>
                                                <td style="text-align: left;">
                                                    <asp:TextBox ID="txtTenor" runat="server" CssClass="txtBox" Width="70px" /></td>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label31" runat="server" Text="Tolerance(LCAF):" /></td>
                                                <td style="text-align: left;">
                                                    <asp:TextBox ID="txtTolerance" runat="server" CssClass="txtBox" Width="70px" /></td>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label32" runat="server" Text="Tolerance(Qty):" /></td>
                                                <td style="text-align: left;">
                                                    <asp:TextBox ID="txtToleranceQty" runat="server" CssClass="txtBox" Width="70px" /></td>
                                            </tr>
                                        </table>

                                    </td>
                                    <%--<td style="text-align:right;">
                                                <asp:Label ID="Label30" runat="server" Text="Tenor(month):" /></td>
                                            <td style="text-align:left;">
                                                <asp:TextBox ID="txtTenor" runat="server" CssClass="txtBox" Width="50px"/></td>
                                            <td style="text-align:right;">
                                                <asp:Label ID="Label31" runat="server" Text="Tolerance(LCAF):" /></td>
                                            <td style="text-align:left;">
                                                <asp:TextBox ID="txtTolerance" runat="server" CssClass="txtBox" Width="50px"/></td>
                                            <td style="text-align:right;">
                                                <asp:Label ID="Label32" runat="server" Text="Tolerance(Qty):" /></td>
                                            <td style="text-align:left;">
                                                <asp:TextBox ID="txtToleranceQty" runat="server" CssClass="txtBox" Width="50px"/></td>--%>
                                </tr>
                                <tr>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label26" runat="server" Text="Warrenty (in months):" /></td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtWarrenty" CssClass="txtBox" runat="server" /></td>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label25" runat="server" Text="Others Trems:" /></td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtOthersTerms" runat="server" Width="200px" Height="70px" TextMode="MultiLine" CssClass="txtBox" /></td>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label33" runat="server" Text="Item Description:" /></td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="TextBox12" runat="server" Width="200px" Height="70px" TextMode="MultiLine" CssClass="txtBox" /></td>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label34" runat="server" Text="Others Trems:" /></td>
                                    <td style="text-align: left;">
                                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True" CssClass="TextAlign">
                                            <asp:ListItem Value="">SRO Benifit</asp:ListItem>
                                            <asp:ListItem Value="">Local LC</asp:ListItem>
                                            <asp:ListItem Value="">LC Confirmation</asp:ListItem>
                                        </asp:CheckBoxList>
                                    </td>

                                </tr>
                            </table>
                        </table>
                        <%--</asp:View>--%>
                        <%--//Po Generate TAB--%>
                        <%--</asp:MultiView>--%>
                </div>



                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

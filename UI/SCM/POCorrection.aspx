<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="POCorrection.aspx.cs" Inherits="UI.SCM.POCorrection" %>

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
    <link href="../../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/Gridstyle.css" rel="stylesheet" />
    <link href="../Content/CSS/bootstrap.min.css" rel="stylesheet" />
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
            ////$("[id*=txtQty]").val("0");
        });

        $("[id*=txtQty]").on("change", function () {
            if (isNaN(parseFloat($(this).val()))) {
                $(this).val('0');
            } else { parseFloat($(this).val($(this).val()).toString()).toFixed(2); }
        });
        //*** txtQty Selection Change Start ****************************************************************************
        $("[id*=txtQty]").on("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') {

                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                    $("[id*=lblTotalVal]", row).html((((parseFloat($("[id*=txtRate]", row).val()) + parseFloat($("[id*=txtVAT]", row).val()) + parseFloat($("[id*=txtAIT]", row).html()))) * ($(this).val())).toFixed(2));
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

            $("[id*=txtAIT]").each(function () {
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
            ////$("[id*=txtRate]").val("0");
        });

        $("[id*=txtRate]").on("change", function () {
            if (isNaN(parseFloat($(this).val()))) {
                $(this).val('0');
            } else { parseFloat($(this).val($(this).val()).toString()).toFixed(2); }
        });

        $("[id*=txtRate]").on("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') {

                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                    $("[id*=lblTotalVal]", row).html((parseFloat($("[id*=txtQty]", row).val()) * (parseFloat($(this).val()) + parseFloat($("[id*=txtVAT]", row).val()) + parseFloat($("[id*=txtAIT]", row).html()))).toFixed(2));
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
            ////$("[id*=txtVAT]").val("0");
        });

        $("[id*=txtVAT]").on("change", function () {
            if (isNaN(parseFloat($(this).val()))) {
                $(this).val('0');
            } else { parseFloat($(this).val($(this).val()).toString()).toFixed(2); }
        });

        $("[id*=txtVAT]").on("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') {

                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                    $("[id*=lblTotalVal]", row).html((parseFloat($("[id*=txtQty]", row).val()) * (parseFloat($(this).val()) + parseFloat($("[id*=txtRate]", row).val()) + parseFloat($("[id*=txtAIT]", row).html()))).toFixed(2));
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

    <script>
        function Confirm() {
            document.getElementById("hdnconfirm").value = "0";
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
            else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
        }
        function doSomething() {
            document.getElementById('id_confrmdiv').style.display = "block"; //this is the replace of this line


            document.getElementById('id_truebtn').onclick = function () {
                //do your delete operation
                alert('true');
            };

            document.getElementById('id_falsebtn').onclick = function () {
                alert('false');
                return false;
            };
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                        <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div>
                </asp:Panel>
                <div style="height: 100px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>

                <%--=========== Start Code =====================================================================--%>
                <asp:HiddenField ID="hdnconfirm" runat="server" />
                <asp:HiddenField ID="hdnWHID" runat="server" />
                <asp:HiddenField ID="hdnPOUnit" runat="server" />

                <div class="leaveApplication_container">
                    <table class="tbldecoration" style="width: auto; float: left;">
                        <tr class="tblheader">
                            <td class="tdheader" colspan="4">PO EDIT :</td>
                        </tr>
                        <tr class="tblheader">
                            <td style="height: 2px; background-color: #c1bdbd;" colspan="4"></td>
                        </tr>
                        <tr>
                            <td colspan="4" style="height: 5px;"></td>
                        </tr>
                        <tr>
                            <td class="tdheight" style="text-align: right;">
                                <asp:Label ID="lbltotalmanpower" CssClass="lbl" runat="server" Text="PO No. : "></asp:Label></td>
                            <td class="tdheight">
                                <asp:TextBox ID="txtPONo" runat="server" CssClass="txtBox1"></asp:TextBox></td>

                            <td class="tdheight" style="text-align: right;">
                                <asp:Label ID="Label19" CssClass="lbl" runat="server" Text="Warehouse : "></asp:Label></td>
                            <td class="tdheight">
                                <asp:TextBox ID="txtWH" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: right; padding: 10px 0px 0px 0px">
                                <asp:Button ID="btnDeletePO" runat="server" class="myButton" Text="Delete PO" ForeColor="Blue" Width="120px" OnClientClick="Confirm()" OnClick="btnDeletePO_Click" /></td>
                            <td colspan="2" style="text-align: right; padding: 10px 0px 0px 0px">
                                <asp:Button ID="btnShow" runat="server" class="myButton" Text="Show" ForeColor="Blue" Width="120px" OnClick="btnShow_Click" /></td>
                        </tr>
                        <tr>
                            <td style="padding: 15px 0px 0px 5px;" colspan="4"></td>
                        </tr>
                        <tr class="tblheader">
                            <td style="height: 2px; background-color: #c1bdbd;" colspan="4"></td>
                        </tr>
                        <tr>
                            <td style="padding: 15px 0px 0px 5px;" colspan="4"></td>
                        </tr>

                        <tr>
                            <td class="tdheight" style="text-align: right;">
                                <asp:Label ID="Label2" CssClass="lbl" runat="server" Text="PO Type : "></asp:Label></td>
                            <td class="tdheight">
                                <asp:TextBox ID="txtPOType" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>

                            <td class="tdheight" style="text-align: right;">
                                <asp:Label ID="Label1" CssClass="lbl" runat="server" Text="MRR No. : "></asp:Label></td>
                            <td class="tdheight">
                                <asp:TextBox ID="txtMrrNo" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="4" style="height: 5px;"></td>
                        </tr>
                        <tr>
                            <td class="tdheight" style="text-align: right;">
                                <asp:Label ID="Label8" CssClass="lbl" runat="server" Text="Supplier Name : "></asp:Label></td>
                            <td class="tdheight">
                                <asp:DropDownList ID="ddlSupplier" CssClass="ddList" Height="24px" Font-Bold="False" ForeColor="Black" Font-Size="11px" runat="server"></asp:DropDownList>
                            </td>
                            <%--<td class="tdheight"><asp:TextBox ID="txtSupplier" runat="server" CssClass="txtBox" Enabled="false" BackColor="WhiteSmoke" ></asp:TextBox></td>--%>

                            <td class="tdheight" style="text-align: right;">
                                <asp:Label ID="Label10" CssClass="lbl" runat="server" Text="No of Shipment : "></asp:Label></td>
                            <td class="tdheight">
                                <asp:TextBox ID="txtNoofShipment" runat="server" CssClass="txtBox1"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="4" style="height: 5px;"></td>
                        </tr>
                        <tr>
                            <td class="tdheight" style="text-align: right;">
                                <asp:Label ID="Label4" CssClass="lbl" runat="server" Text="Currency : "></asp:Label></td>
                            <td class="tdheight">
                                <asp:DropDownList ID="ddlCurrency" CssClass="ddList" Height="24px" Font-Bold="False" ForeColor="Black" Font-Size="11px" runat="server"></asp:DropDownList>
                            </td>

                            <td class="tdheight" style="text-align: right;">
                                <asp:Label ID="Label11" CssClass="lbl" runat="server" Text="Last Shipment Date : "></asp:Label></td>
                            <td class="tdheight">
                                <asp:TextBox ID="txtLastShipmentDate" runat="server" CssClass="txtBox1"></asp:TextBox>
                                <cc1:CalendarExtender ID="reqDate" runat="server" Format="yyyy-MM-dd" TargetControlID="txtLastShipmentDate"></cc1:CalendarExtender>
                                <%--<script type="text/javascript"> new datepickr('txtLastShipmentDate', { 'dateFormat': 'Y-m-d' });</script></td>--%>
                        </tr>
                        <tr>
                            <td colspan="4" style="height: 5px;"></td>
                        </tr>
                        <tr>
                            <td class="tdheight" style="text-align: right;">
                                <asp:Label ID="Label3" CssClass="lbl" runat="server" Text="PO Date : "></asp:Label></td>
                            <td class="tdheight">
                                <asp:TextBox ID="txtPODate" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox>
                                <script type="text/javascript"> new datepickr('txtPODate', { 'dateFormat': 'Y-m-d' });</script>
                            </td>

                            <td class="tdheight" style="text-align: right;">
                                <asp:Label ID="Label12" CssClass="lbl" runat="server" Text="Payment terms : "></asp:Label></td>
                            <td class="tdheight">
                                <asp:DropDownList ID="ddlPaymentTerms" runat="server" CssClass="ddList" Height="24px" Font-Bold="False">
                                    <asp:ListItem Selected="True" Value="1">Cash</asp:ListItem>
                                    <asp:ListItem Value="2">Credit</asp:ListItem>
                                    <asp:ListItem Value="3">Advance</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td colspan="4" style="height: 5px;"></td>
                        </tr>
                        <tr>
                            <td class="tdheight" style="text-align: right;">
                                <asp:Label ID="Label6" CssClass="lbl" runat="server" Text="Transport Amount : "></asp:Label></td>
                            <td class="tdheight">
                                <asp:TextBox ID="txtTransport" runat="server" CssClass="txtBox1"></asp:TextBox></td>

                            <td class="tdheight" style="text-align: right;">
                                <asp:Label ID="Label13" CssClass="lbl" runat="server" Text="Payment days after MRR (days) : "></asp:Label></td>
                            <td class="tdheight">
                                <asp:TextBox ID="txtPaymentdaysAfterMRR" runat="server" CssClass="txtBox1"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="4" style="height: 5px;"></td>
                        </tr>
                        <tr>
                            <td class="tdheight" style="text-align: right;">
                                <asp:Label ID="Label5" CssClass="lbl" runat="server" Text="Gross Discount : "></asp:Label></td>
                            <td class="tdheight">
                                <asp:TextBox ID="txtGDiscount" runat="server" CssClass="txtBox1"></asp:TextBox></td>

                            <td class="tdheight" style="text-align: right;">
                                <asp:Label ID="Label14" CssClass="lbl" runat="server" Text="No of Installment : "></asp:Label></td>
                            <td class="tdheight">
                                <asp:TextBox ID="txtNoOfInstallment" runat="server" CssClass="txtBox1"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="4" style="height: 5px;"></td>
                        </tr>
                        <tr>
                            <td class="tdheight" style="text-align: right;">
                                <asp:Label ID="Label7" CssClass="lbl" runat="server" Text="Others Amount : "></asp:Label></td>
                            <td class="tdheight">
                                <asp:TextBox ID="txtOthers" runat="server" CssClass="txtBox1"></asp:TextBox></td>

                            <td class="tdheight" style="text-align: right;">
                                <asp:Label ID="Label15" CssClass="lbl" runat="server" Text="Installment Interval : "></asp:Label></td>
                            <td class="tdheight">
                                <asp:TextBox ID="txtInstallmentIntervalDays" runat="server" CssClass="txtBox1"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="4" style="height: 5px;"></td>
                        </tr>
                        <tr>
                            <td class="tdheight" style="text-align: right;">
                                <asp:Label ID="Label9" CssClass="lbl" runat="server" Text="Partial Shipment : "></asp:Label></td>
                            <td class="tdheight">
                                <asp:DropDownList ID="ddlPartialShipment" runat="server" CssClass="ddList" Height="24px" Font-Bold="False">
                                    <asp:ListItem Selected="True" Value="0">FALSE</asp:ListItem>
                                    <asp:ListItem Value="1">TRUE</asp:ListItem>
                                </asp:DropDownList></td>

                            <td class="tdheight" style="text-align: right;">
                                <asp:Label ID="Label16" CssClass="lbl" runat="server" Text="Destination For Delivery : "></asp:Label></td>
                            <td class="tdheight">
                                <asp:TextBox ID="txtDestinationForDelivery" runat="server" CssClass="txtBox1"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="4" style="height: 5px;"></td>
                        </tr>
                        <tr>
                            <td class="tdheight" style="text-align: right;">
                                <asp:Label ID="Label18" CssClass="lbl" runat="server" Text="Other Terms : "></asp:Label></td>
                            <td class="tdheight">
                                <asp:TextBox ID="txtOtherTerms" runat="server" CssClass="txtBox1" Height="50px" TextMode="MultiLine"></asp:TextBox></td>

                            <td class="tdheight" style="text-align: right;">
                                <asp:Label ID="Label17" CssClass="lbl" runat="server" Text="Warrenty (in months) : "></asp:Label></td>
                            <td class="tdheight">
                                <asp:TextBox ID="txtWarrentyAfterDelivery" runat="server" CssClass="txtBox1"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: right; padding: 10px 0px 0px 0px">
                                <asp:Button ID="btnUpdatePO" runat="server" class="myButton" Text="Update" Width="120px" OnClientClick="Confirm()" OnClick="btnUpdatePO_Click" /></td>
                        </tr>
                        <tr>
                            <td style="padding: 15px 0px 0px 5px;" colspan="4"></td>
                        </tr>

                    </table>
                </div>

                <div id="divItemInfo" runat="server" class="leaveApplication_container hidden">
                    <table class="tbldecoration" style="width: auto; float: left;">
                        <%--<tr><td colspan="4" style="font-weight:bold; font-size:11px; color:#3369ff;">Item Description:<hr /></td></tr>--%>
                        <%--<tr><td> <hr /> </td></tr>--%>
                        <tr>
                            <td>
                                <asp:GridView ID="dgvItemInfoByPO" runat="server" AutoGenerateColumns="False" PageSize="8"
                                    CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="True"
                                    FooterStyle-BackColor="#808080" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" OnRowDataBound="dgvItemInfoByPO_RowDataBound" OnRowCommand="dgvItemInfoByPO_RowCommand">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL">
                                            <ItemStyle HorizontalAlign="center" Width="20px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Item ID" SortExpression="intemid" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemID" runat="server" Text='<%# Bind("intemid") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="45px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Item Name" SortExpression="itemname">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("itemname") %>' Width="230px"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="230px" />
                                            <FooterTemplate>
                                                <asp:Label ID="lblT" runat="server" Text="Total" /></FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Item Specification" SortExpression="specification">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtSpecification" runat="server" CssClass="txtBox" Text='<%# Bind("specification") %>' TextMode="MultiLine" Width="250px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" Width="250px" />
                                            <FooterTemplate>
                                                <asp:Label ID="lblBlank" runat="server" Text=""></asp:Label></FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="UOM" SortExpression="uom">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUOM" runat="server" Text='<%# Bind("uom") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="40px" />
                                            <FooterTemplate>
                                                <asp:Label ID="Label20" runat="server" Text="" /></FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Quantity" SortExpression="qty">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtQty" runat="server" CssClass="txtBox" DataFormatString="{0:0.00}" Text='<%# Bind("qty") %>' Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" Width="60px" />
                                            <FooterTemplate>
                                                <asp:Label ID="lblGrandTotalQty" runat="server" DataFormatString="{0:0.00}" Text="<%# totalqty %>" /></FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Rate" ItemStyle-HorizontalAlign="right" SortExpression="rate">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtRate" runat="server" CssClass="txtBox" DataFormatString="{0:0.00}" Text='<%# Bind("rate") %>' Width="80px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" Width="80px" />
                                            <FooterTemplate>
                                                <asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text="" /></FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="VAT" SortExpression="vat">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtVAT" runat="server" CssClass="txtBox" DataFormatString="{0:0.00}" Text='<%# Bind("vat") %>' Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" Width="50px" />
                                            <FooterTemplate>
                                                <asp:Label ID="lblGrandTotalVAT" runat="server" DataFormatString="{0:0.00}" Text="<%# totalvat %>" /></FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="AIT" ItemStyle-HorizontalAlign="right" SortExpression="ait">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtAIT" runat="server" DataFormatString="{0:0.00}" Width="50px" CssClass="txtBox" Text='<%# Bind("ait") %>'></asp:TextBox>
                                                <%--Text='<%# (decimal.Parse(""+Eval("ait"))) %>'--%>
                                            </ItemTemplate>
                                            <HeaderStyle Width="40px" />
                                            <ItemStyle HorizontalAlign="right" Width="50px" />
                                            <FooterTemplate>
                                                <asp:Label ID="lblGrandTotalAIT" runat="server" DataFormatString="{0:0.00}" Text="<%# totalait %>" /></FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Total Value" ItemStyle-HorizontalAlign="right" SortExpression="total">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTotalVal" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("total"))) %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" Width="80px" />
                                            <FooterTemplate>
                                                <asp:Label ID="lblGrandTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# totalval %>" /></FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Existing" SortExpression="ysnExisting" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblExisting" runat="server" Text='<%# Bind("ysnExisting") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="45px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center" SortExpression="">
                                            <ItemTemplate>
                                                <asp:Button ID="btnApprove" class="myButtonGrid" OnClientClick="Confirm()" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="UpdateItem" Text="Update" />
                                                <asp:Button ID="btnDelete" class="myButtonGrid" OnClientClick="Confirm()" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="DeleteItem" Text="Delete" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="Gray" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>

                <%--=========== End Code =====================================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    <script>
        function showPanel() {
            var itemPanel = document.getElementById("divItemInfo");
            itemPanel.classList.remove("hidden");
            return true;
        }
    </script>
</body>
</html>

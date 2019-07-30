<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InternalTransportRouteExpInEntry.aspx.cs" Inherits="UI.Transport.InternalTransportRouteExpInEntry" %>

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

    <script language="javascript" type="text/javascript">
        function onlyNumbers(evt) {
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;

            if ((charCode > 57))
                return false;
            return true;
        }

        function Add() {
            var a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, trb, unitid, tma, dtfcountcash, deiselperkmoutstation, cngperkmoutstation, singlemillag, dtfcashcount, dtfcount, dtfare, dtallow, trexp, dtfcash, da, dano, dailyallowance, mailageallowance, qty, tenperdtallow;
            a = parseFloat(document.getElementById("txtFerryToll").value);
            if (isNaN(a) == true) { a = 0; }
            var b = parseFloat(document.getElementById("txtBridgeToll").value);
            if (isNaN(b) == true) { b = 0; }
            var c = parseFloat(document.getElementById("txtLabourExp").value);
            if (isNaN(c) == true) { c = 0; }
            var d = parseFloat(document.getElementById("txtPolice").value);
            if (isNaN(d) == true) { d = 0; }
            var e = parseFloat(document.getElementById("txtFuelCash").value);
            if (isNaN(e) == true) { e = 0; }
            var h = parseFloat(document.getElementById("txtMaintananceTK").value);
            if (isNaN(h) == true) { h = 0; }
            var i = parseFloat(document.getElementById("txtOthersTK").value);
            if (isNaN(i) == true) { i = 0; }

            var trb = parseFloat(document.getElementById("txtTripBonus").value);
            if (isNaN(trb) == true) { trb = 0; }
            var tma = parseFloat(document.getElementById("txtTimeAllowance").value);
            if (isNaN(tma) == true) { tma = 0; }


            //*** Total Fuel Cost Start
            var f = parseFloat(document.getElementById("hdndgvFTTotal").value);
            if (isNaN(f) == true) { f = 0; }
            var g = parseFloat(document.getElementById("txtFuelCash").value);
            if (isNaN(g) == true) { g = 0; }
            document.getElementById("txtTFCost").value = (f + g).toFixed(0);
            //*** Total Fuel Cost End

            //*** Daily Allowance Calculation Start
            var da = parseFloat(document.getElementById("hdnDA").value);
            if (isNaN(da) == true) { da = 0; }
            var dano = parseFloat(document.getElementById("txtNoOfDA").value);
            if (isNaN(dano) == true) { dano = 0; }
            document.getElementById("txtDailyAlllownacetk").value = (dano * da).toFixed(0);
            //*** Daily Allowance Calculation End

            //***Total Millage Calculation Start
            var j = parseFloat(document.getElementById("txtAdditionalMillage").value);
            if (isNaN(j) == true) { j = 0; }
            var k = parseFloat(document.getElementById("hdnMillage").value);
            if (isNaN(k) == true) { k = 0; }
            document.getElementById("txtTotalMillage").value = (j + k).toFixed(0);
            //***Total Millage Calculation End  

            //*** Millage Allowance Calculation Start
            var n = parseFloat(document.getElementById("hdnSingleMillage100KM").value);
            if (isNaN(n) == true) { n = 0; }
            var q = parseFloat(document.getElementById("hdnSingleMillage100AboveKM").value);
            if (isNaN(a) == true) { a = 0; }

            var unitid = parseFloat(document.getElementById("hdnUnit").value);
            ///if (isNaN(unitid) == true) { unitid = 0; }

            if (unitid == 4) {
                if ((j + k) > 230) { singlemillag = q; } else { singlemillag = n; }
            }
            else if (unitid == 94) {
                if ((j + k) > 130) { singlemillag = q; } else { singlemillag = n; }
            }
            else {
                if ((j + k) > 100) { singlemillag = q; } else { singlemillag = n; }
            }

            document.getElementById("txtMillageAllowance").value = ((j + k) * singlemillag).toFixed(0);
            //*** Millage Allowance Calculation End

            //***Total Trip Fare Calculation Start
            var l = parseFloat(document.getElementById("txtAdditionalFare").value);
            if (isNaN(l) == true) { l = 0; }

            var m = parseFloat(document.getElementById("hdnTFare").value);
            if (isNaN(m) == true) { m = 0; }

            var qty = parseFloat(document.getElementById("hdnQty").value);
            if (isNaN(qty) == true) { qty = 0; }

            //if (unitid == 4)
            //{                
            //    document.getElementById("txtTotalTripFare").value = (l + (m * qty)).toFixed(0);
            //}
            //else
            //{
            //    document.getElementById("txtTotalTripFare").value = (l + m).toFixed(0);
            //}

            document.getElementById("txtTotalTripFare").value = (l + m).toFixed(0);

            //***Total Trip Fare Calculation End  

            var dailyallowance = parseFloat(document.getElementById("txtDailyAlllownacetk").value);
            if (isNaN(dailyallowance) == true) { dailyallowance = 0; }
            var mailageallowance = parseFloat(document.getElementById("txtMillageAllowance").value);
            if (isNaN(mailageallowance) == true) { mailageallowance = 0; }

            //***********************************************************************************
            if (unitid == 4) {
                if ((j + k) > 230) {
                    var o = parseFloat(document.getElementById("hdnDieselPerKMOutStation").value);
                    if (isNaN(o) == true) { o = 0; }
                }
                else {
                    var o = parseFloat(document.getElementById("hdnDieselTotalTk").value);
                    if (isNaN(o) == true) { o = 0; }
                }
            }
            else {
                var o = parseFloat(document.getElementById("hdnDieselTotalTk").value);
                if (isNaN(o) == true) { o = 0; }
            }

            if (unitid == 4) {
                if ((j + k) > 230) {
                    var p = parseFloat(document.getElementById("hdnCNGPerKMOutStation").value);
                    if (isNaN(p) == true) { p = 0; }
                }
                else {
                    var p = parseFloat(document.getElementById("hdnCNGTotalTk").value);
                    if (isNaN(p) == true) { p = 0; }
                }
            }
            else {
                var p = parseFloat(document.getElementById("hdnCNGTotalTk").value);
                if (isNaN(p) == true) { p = 0; }
            }


            //***********************************************************************************

            //////var o = parseFloat(document.getElementById("hdnDieselTotalTk").value);
            //////if (isNaN(o) == true) {o = 0;}
            //////var p = parseFloat(document.getElementById("hdnCNGTotalTk").value);
            //////if (isNaN(p) == true) { p = 0; }                   

            document.getElementById("txtDieselTotalTk").value = ((j + k) * o).toFixed(0);
            document.getElementById("txtCNGTotalTk").value = ((j + k) * p).toFixed(0);

            //*** Down Trip Fare Allowance Calculation Start
            var dtfcash = parseFloat(document.getElementById("hdndgvDTFCash").value);
            if (isNaN(dtfcash) == true) { dtfcash = 0; }

            var tenperdtallow = (dtfcash / 100 * 10).toFixed(0);
            if (isNaN(tenperdtallow) == true) { tenperdtallow = 0; }

            var dtfcount = parseFloat(document.getElementById("hdnDTFCount").value);
            if (isNaN(dtfcount) == true) { dtfcount = 0; }

            var dtfcountcash = parseFloat(document.getElementById("hdnDTFCountCash").value);
            if (isNaN(dtfcountcash) == true) { dtfcountcash = 0; }

            var dtfare = parseFloat(document.getElementById("hdnDTFare").value);
            if (isNaN(dtfare) == true) { dtfare = 0; }

            //if (dtfcash > 0 || dtfcount > 0) { dtfcashcount = 1; } else { dtfcashcount = 0; }


            if (unitid == 2) {
                document.getElementById("txtDtripAllowance").value = ((dtfcash / 100 * 10) + (dtfcount * dtfare)).toFixed(0);
            }
            else {
                document.getElementById("txtDtripAllowance").value = ((dtfcount + dtfcountcash) * dtfare).toFixed(0);
            }


            var dtallow = parseFloat(document.getElementById("txtDtripAllowance").value);
            if (isNaN(dtallow) == true) { dtallow = 0; }
            //*** Down Trip Fare Allowance Calculation End

            document.getElementById("txtTotalRouteExp").value = (trb + tma + a + b + c + d + h + i + dailyallowance + mailageallowance + dtallow + ((j + k) * o) + ((j + k) * p)).toFixed(0);
            var trexp = parseFloat(document.getElementById("txtTotalRouteExp").value);
            if (isNaN(trexp) == true) { trexp = 0; }
            document.getElementById("txtNetPayable").value = (trexp - (f + dtfcash)).toFixed(0);

            document.getElementById("txtTotalRouteExp").readOnly = true;
            document.getElementById("txtTFCost").readOnly = true;
            //document.getElementById("txtFerryToll").readOnly = true;
            //document.getElementById("txtBridgeToll").readOnly = true;
            document.getElementById("txtTotalMillage").readOnly = true;
            document.getElementById("txtTotalTripFare").readOnly = true;
            document.getElementById("txtMillageAllowance").readOnly = true;
            document.getElementById("txtDtripAllowance").readOnly = true;
            document.getElementById("txtDailyAlllownacetk").readOnly = true;
            document.getElementById("txtNetPayable").readOnly = true;
            document.getElementById("txtDieselTotalTk").readOnly = true;
            document.getElementById("txtCNGTotalTk").readOnly = true;
            //document.getElementById("txtQty").readOnly = true;

        }

        function Save() {
            document.getElementById("hdnField").value = "1";
            __doPostBack();
        }

    </script>

    <script>
        function FTPUpload() {
            document.getElementById("hdnconfirm").value = "2";
            __doPostBack();
        }
        function FTPUpload1() {
            document.getElementById("hdnconfirm").value = "0";
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "3"; }
            else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
            __doPostBack();
        }
    </script>

    <script> function CloseWindow() {
            window.close();
        } </script>

    <script type="text/javascript">
        function RefreshParent() {
            if (window.opener != null && !window.opener.closed) {
                window.opener.location.reload();
            }
        }
        window.onbeforeunload = RefreshParent;
    </script>

</head>
<body>
    <form id="frmselfresign" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <%--<asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>--%>
                <%--=========================================Start My Code From Here===============================================--%>
                <div class="leaveApplication_container">
                    <asp:HiddenField ID="hdnEnroll" runat="server" />
                    <asp:HiddenField ID="hdnUnit" runat="server" />
                    <asp:HiddenField ID="hdnDA" runat="server" />
                    <asp:HiddenField ID="hdnMillage" runat="server" />
                    <asp:HiddenField ID="hdnTFare" runat="server" />
                    <asp:HiddenField ID="hdnDTFare" runat="server" />
                    <asp:HiddenField ID="hdnSingleMillage100KM" runat="server" />
                    <asp:HiddenField ID="hdnSingleMillage100AboveKM" runat="server" />
                    <asp:HiddenField ID="hdndgvFTTotal" runat="server" />
                    <asp:HiddenField ID="hdnconfirm" runat="server" />
                    <asp:HiddenField ID="hdnDieselTotalTk" runat="server" />
                    <asp:HiddenField ID="hdnCNGTotalTk" runat="server" />
                    <asp:HiddenField ID="hdnDTFCount" runat="server" />
                    <asp:HiddenField ID="hdnDTFCountCash" runat="server" />
                    <asp:HiddenField ID="hdndgvDTFCash" runat="server" />
                    <asp:HiddenField ID="hdnQty" runat="server" />
                    <asp:HiddenField ID="hdnDieselPerKMOutStation" runat="server" />
                    <asp:HiddenField ID="hdnCNGPerKMOutStation" runat="server" />
                    <div class="tabs_container">VEHICLE TRIP IN COST ENTRY FORM<hr />
                    </div>

                    <table class="tbldecoration" style="width: auto; float: left;">

                        <tr>
                            <td style="font-weight: bold; text-align: right; color: #0b6016;">
                                <asp:Label ID="lblTrip" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Trip Sl No. :"></asp:Label></td>
                            <td style="font-weight: bold; text-align: left; color: #0b6016;">
                                <asp:Label ID="lblTripNo" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px"></asp:Label></td>

                            <td style="font-weight: bold; text-align: right; color: #0b6016;">
                                <asp:Label ID="lblCustN" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Final Destination :"></asp:Label></td>
                            <td colspan="3" style="font-weight: bold; text-align: left; color: #0b6016;">
                                <asp:Label ID="lblCustName" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold; text-align: right; color: #0b6016;">
                                <asp:Label ID="lblVehicle" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Vehicle No. :"></asp:Label></td>
                            <td style="font-weight: bold; text-align: left; color: #0b6016;">
                                <asp:Label ID="lblVehicleNo" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px"></asp:Label></td>

                            <td style="font-weight: bold; text-align: right; color: #0b6016;">
                                <asp:Label ID="lblVehicleT" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Vehicle Type :"></asp:Label></td>
                            <td style="font-weight: bold; text-align: left; color: #0b6016;">
                                <asp:Label ID="lblVehicleType" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblInDate" runat="server" CssClass="lbl" Text="In Date :"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtInDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="190px" autocomplete="off"></asp:TextBox>
                                <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtInDate"></cc1:CalendarExtender>
                            </td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblQty" runat="server" CssClass="lbl" Text="Quantity :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtQty" runat="server" CssClass="txtBox" BackColor="LightGray" BorderColor="Gray" Width="70px" onkeypress="return onlyNumbers();" MaxLength="10"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" style="font-weight: bold; font-size: 11px; color: #3369ff;">Fare:<hr />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Cause Of Additional Millage :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtCauseOfAdditionalM" runat="server" CssClass="txtBox" Width="190px" TextMode="MultiLine"></asp:TextBox></td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblAdditionalMillage" runat="server" CssClass="lbl" Text="Additional Millage :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtAdditionalMillage" runat="server" CssClass="txtBox" Width="70px" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblTotalMillage" runat="server" CssClass="lbl" Text="Total Millage :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtTotalMillage" runat="server" CssClass="txtBox" BackColor="LightGray" BorderColor="Gray" Width="70px" onkeypress="return onlyNumbers();" MaxLength="10"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Cause Of Additional Fare :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtCauseOfAdditionalF" runat="server" CssClass="txtBox" TextMode="MultiLine" Width="190px"></asp:TextBox></td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblAdditionalFare" runat="server" CssClass="lbl" Text="Additional Fare :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtAdditionalFare" runat="server" CssClass="txtBox" Width="70px" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblTotalTripFare" runat="server" CssClass="lbl" Text="Total Trip Fare :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtTotalTripFare" runat="server" CssClass="txtBox" BackColor="LightGray" BorderColor="Gray" Width="70px" onkeypress="return onlyNumbers();" MaxLength="10"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" style="font-weight: bold; font-size: 11px; color: #3369ff;">Fuel Cost:<hr />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblDieselTotalTk" runat="server" CssClass="lbl" Text="Diesel Total (Tk) :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtDieselTotalTk" runat="server" CssClass="txtBox" Width="190px" BackColor="LightGray" BorderColor="Gray" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblCNGTotalTk" runat="server" CssClass="lbl" Text="CNG Total (Tk) :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtCNGTotalTk" runat="server" CssClass="txtBox" Width="70px" BackColor="LightGray" BorderColor="Gray" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblFuelStation" runat="server" CssClass="lbl" Text="Fuel Station"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlFuelStation" CssClass="ddList" Font-Bold="False" runat="server" Width="195px"></asp:DropDownList>
                            </td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblFuelCash" runat="server" CssClass="lbl" Text="Fuel Cash :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtFuelCash" runat="server" CssClass="txtBox" Width="70px" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblTFCost" runat="server" CssClass="lbl" Text="Total Fuel Cost :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtTFCost" runat="server" CssClass="txtBox" BackColor="LightGray" BorderColor="Gray" Width="70px" onkeypress="return onlyNumbers();" MaxLength="10"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblFuelPurchaeDate" runat="server" CssClass="lbl" Text="Fuel Purchae Date :"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtFuelPurchaeDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="190px"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFuelPurchaeDate"></cc1:CalendarExtender>
                            </td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblDieselCredit" runat="server" CssClass="lbl" Text="Diesel Credit :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtDieselCredit" runat="server" CssClass="txtBox" Width="70px" onkeypress="return onlyNumbers();"></asp:TextBox></td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblCNGCredit" runat="server" CssClass="lbl" Text="CNG Credit :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtCNGCredit" runat="server" CssClass="txtBox" Width="70px" onkeypress="return onlyNumbers();"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <asp:Button ID="btnFuelCostAdd" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Add" OnClick="btnFuelCostAdd_Click" /></td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <asp:GridView ID="dgvFuelCost" runat="server" AutoGenerateColumns="False" Font-Size="10px" 
                                    BackColor="White" BorderColor="#999999" BorderStyle="Solid"
                                    BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" ShowFooter="true" 
                                    FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" 
                                    OnRowDataBound="dgvFuelCost_RowDataBound" OnRowDeleting="dgvFuelCost_RowDeleting">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL No.">
                                            <ItemStyle HorizontalAlign="center" Width="60px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="intPartyID" Visible="false" SortExpression="intPartyID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPartyID" runat="server" Text='<%# Bind("intPartyID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="45px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Fuel Purchase Date" SortExpression="strFuelPurchaseDate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFuelPurchaseDate" runat="server" Text='<%# Bind("strFuelPurchaseDate") %>' Width="70px"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="55px" />
                                            <FooterTemplate>
                                                <asp:Label ID="lblT" runat="server" Text="" /></FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Fuel Station Name" SortExpression="fuelstation">
                                            <ItemTemplate>
                                                <asp:Label ID="lblfuelstation" runat="server" Text='<%# Bind("fuelstation") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                            <FooterTemplate>
                                                <asp:Label ID="lblT" runat="server" Text="Total" /></FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="inttype" Visible="false" SortExpression="inttype">
                                            <ItemTemplate>
                                                <asp:Label ID="lblinttype" runat="server" Text='<%# Bind("inttype") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="45px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Diesel Credit" ItemStyle-HorizontalAlign="right" SortExpression="dieselcredit">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldieselcredit" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("dieselcredit"))) %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" Width="90px" />
                                            <FooterTemplate>
                                                <asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text='<%# totaldieselcredit %>' /></FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="CNG Credit" ItemStyle-HorizontalAlign="right" SortExpression="cngcredit">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcngcredit" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("cngcredit"))) %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" Width="90px" />
                                            <FooterTemplate>
                                                <asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text='<%# totalcngcredit %>' /></FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Total Credit" ItemStyle-HorizontalAlign="right" SortExpression="totalcredit">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrandTotal" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("totalcredit"))) %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" Width="90px" />
                                            <FooterTemplate>
                                                <asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text='<%# grandtotal %>' /></FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" />

                                    </Columns>
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" style="font-weight: bold; font-size: 11px; color: #3369ff;">Down Trip Fare:<hr />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblAgentName" runat="server" CssClass="lbl" Text="Agent Name :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtAgentName" runat="server" CssClass="txtBox" TextMode="MultiLine" Width="190px"></asp:TextBox></td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblDTCach" runat="server" CssClass="lbl" Text="DT Fare (Cash) :"></asp:Label></td>
                            <td colspan="4" style="text-align: left;">
                                <asp:TextBox ID="txtDTFCash" runat="server" CssClass="txtBox" Width="200px" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>
                        </tr>
                        <tr style="background-color: lightgray">
                            <td colspan="6">
                                <asp:Button ID="btnDTFareCashAdd" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Add" OnClick="btnDTFareCashAdd_Click" /></td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <asp:GridView ID="dgvDTFareCash" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"
                                    BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="dgvDTFareCash_RowDataBound" OnRowDeleting="dgvDTFareCash_RowDeleting">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL No.">
                                            <ItemStyle HorizontalAlign="center" Width="15px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Agent Name" SortExpression="agenttnam">
                                            <ItemTemplate>
                                                <asp:Label ID="lblagenttnam" runat="server" Text='<%# Bind("agenttnam") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="530px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="DT Fare (Cash)" ItemStyle-HorizontalAlign="right" SortExpression="dtfarecash">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrandTotaldtfareCash" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("dtfarecash"))) %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" Width="80px" />
                                            <FooterTemplate>
                                                <asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text='<%# grandtotaldtfarecash %>' /></FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" />

                                    </Columns>
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblUnitNameDTF" runat="server" CssClass="lbl" Text="Unit Name :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlUnitNameDTF" CssClass="ddList" Font-Bold="False" runat="server" Width="195px" AutoPostBack="true" OnSelectedIndexChanged="ddlUnitNameDTF_SelectedIndexChanged"></asp:DropDownList>
                            </td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblShipPointDTF" runat="server" CssClass="lbl" Text="Ship Point Name :"></asp:Label></td>
                            <td colspan="4" style="text-align: left;">
                                <asp:DropDownList ID="ddlShipPointDTF" CssClass="ddList" Font-Bold="False" runat="server" Width="210px"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblDTFareCredit" runat="server" CssClass="lbl" Text="DT Fare (Credit) :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtDTFareCredit" runat="server" CssClass="txtBox" Width="190px" onkeypress="return onlyNumbers();" MaxLength="10"></asp:TextBox></td>
                        </tr>
                        <tr style="background-color: lightgray">
                            <td colspan="6">
                                <asp:Button ID="btnDTFareAdd" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Add" OnClick="btnDTFareAdd_Click1" /></td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <asp:GridView ID="dgvDTFare" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"
                                    BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="dgvDTFare_RowDataBound" OnRowDeleting="dgvDTFare_RowDeleting">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL No.">
                                            <ItemStyle HorizontalAlign="center" Width="15px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="unitid" Visible="false" SortExpression="unitid">
                                            <ItemTemplate>
                                                <asp:Label ID="lblunitid" runat="server" Text='<%# Bind("unitid") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="45px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="shippointid" Visible="false" SortExpression="shippointid">
                                            <ItemTemplate>
                                                <asp:Label ID="lblshippointid" runat="server" Text='<%# Bind("shippointid") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="45px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Unit Name" SortExpression="unitname">
                                            <ItemTemplate>
                                                <asp:Label ID="lblunitname" runat="server" Text='<%# Bind("unitname") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="186px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Ship Point Name" SortExpression="shippointname">
                                            <ItemTemplate>
                                                <asp:Label ID="lblshippointname" runat="server" Text='<%# Bind("shippointname") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="325px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="DT Fare (Credit)" ItemStyle-HorizontalAlign="right" SortExpression="dtfarecredit">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrandTotaldtfare" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("dtfarecredit"))) %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" Width="80px" />
                                            <FooterTemplate>
                                                <asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text='<%# grandtotaldtfare %>' /></FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" />

                                    </Columns>
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" style="font-weight: bold; font-size: 11px; color: #3369ff;">Allowance:<hr />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblTripBonus" runat="server" CssClass="lbl" Text="Trip Bonus :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtTripBonus" runat="server" CssClass="txtBox" Width="190px" BackColor="LightGray" BorderColor="Gray" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblNoOfDA" runat="server" CssClass="lbl" Text="No. Of DA :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtNoOfDA" runat="server" CssClass="txtBox" Width="70px" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblMillageAllowance" runat="server" CssClass="lbl" Text="Millage Allowance:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtMillageAllowance" runat="server" CssClass="txtBox" BackColor="LightGray" BorderColor="Gray" Width="70px" onkeypress="return onlyNumbers();" MaxLength="10"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblTimeAllowance" runat="server" CssClass="lbl" Text="Time Allowance :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtTimeAllowance" runat="server" CssClass="txtBox" Width="190px" BackColor="LightGray" BorderColor="Gray" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblDailyAllowancetk" runat="server" CssClass="lbl" Text="Daily Allowance:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtDailyAlllownacetk" runat="server" CssClass="txtBox" BackColor="LightGray" BorderColor="Gray" Width="70px" onkeypress="return onlyNumbers();" MaxLength="10"></asp:TextBox></td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblDtripAllowance" runat="server" CssClass="lbl" Text="D. Trip Allowance:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtDtripAllowance" runat="server" CssClass="txtBox" BackColor="LightGray" BorderColor="Gray" Width="70px" onkeypress="return onlyNumbers();" MaxLength="10"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" style="font-weight: bold; font-size: 11px; color: #3369ff;">Maintanance & Others Expence:<hr />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblCauseOfMaintenance" runat="server" CssClass="lbl" Text="Cause Of Maintenance :"></asp:Label></td>
                            <td colspan="3" style="text-align: left;">
                                <asp:TextBox ID="txtCauseOfMaintenance" runat="server" CssClass="txtBox" Width="375px"></asp:TextBox></td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblMaintananceTK" runat="server" CssClass="lbl" Text="Maintanance (TK) :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtMaintananceTK" runat="server" CssClass="txtBox" Width="70px" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblCauseOfOthers" runat="server" CssClass="lbl" Text="Cause Of Others (+-) :"></asp:Label></td>
                            <td colspan="3" style="text-align: left;">
                                <asp:TextBox ID="txtCauseOfOthers" runat="server" CssClass="txtBox" Width="375px"></asp:TextBox></td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblOthersTK" runat="server" CssClass="lbl" Text="Others (TK) :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtOthersTK" runat="server" CssClass="txtBox" Width="70px" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblLabourExp" runat="server" CssClass="lbl" Text="Labour Exp. :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtLabourExp" runat="server" CssClass="txtBox" Width="190px" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblBridge" runat="server" CssClass="lbl" Text="Bridge Toll :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtBridgeToll" runat="server" CssClass="txtBox" ReadOnly="true" BackColor="LightGray" BorderColor="Gray" Width="70px" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblFerry" runat="server" CssClass="lbl" Text="Ferry Toll:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtFerryToll" runat="server" CssClass="txtBox" ReadOnly="true" BackColor="LightGray" BorderColor="Gray" Width="70px" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblPolice" runat="server" CssClass="lbl" Text="Police Tips. :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtPolice" runat="server" CssClass="txtBox" Width="190px" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblTotalRouteExp" runat="server" CssClass="lbl" Text="Total Route Exp.:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtTotalRouteExp" runat="server" CssClass="txtBox" BackColor="LightGray" BorderColor="Gray" Width="70px" onkeypress="return onlyNumbers();" MaxLength="10"></asp:TextBox></td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblNetPayable" runat="server" CssClass="lbl" Text="Net Payable :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtNetPayable" runat="server" CssClass="txtBox" BackColor="LightGray" BorderColor="Gray" Width="70px" onkeypress="return onlyNumbers();" MaxLength="10"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td colspan="6">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" style="font-weight: bold; font-size: 11px; color: #3369ff;">Document Upload:<hr />
                            </td>
                        </tr>
                        <tr class="tblrowodd">
                            <td style="text-align: right;">
                                <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Document Type :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlDocType" CssClass="ddList" Font-Bold="False" runat="server" Width="195px"></asp:DropDownList>
                            </td>

                            <td style='text-align: right; width: 120px;'>Document Upload : </td>
                            <td style='text-align: center;'>
                                <asp:FileUpload ID="txtDocUpload" runat="server" AllowMultiple="true" />
                            </td>
                            <asp:HiddenField ID="hdnField" runat="server" />
                            <%--<td><asp:Button ID="Save" runat="server" class="nextclick" Font-Bold="true" ForeColor="Green" Text="Add" onclick="Save()"/></td>--%>
                            <%--<td><a class="nextclick" onclick="FTPUpload()">Add</a></td>--%>
                            <td style="text-align: right;">
                                <a class="nextclick" onclick="FTPUpload()">Add</a> </td>
                        </tr>
                        <tr>
                            <td colspan="10">
                                <asp:GridView ID="dgvDocUp" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"
                                    BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgvDocUp_RowDeleting1">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL No.">
                                            <ItemStyle HorizontalAlign="center" Width="15px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="File Name" SortExpression="strFileName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFileName" runat="server" Text='<%# Bind("strFileName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="530px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="doctypeid" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="doctypeid">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldoctypeid" runat="server" DataFormatString="{0:0.00}" Text='<%# (""+Eval("doctypeid")) %>'></asp:Label></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" />

                                    </Columns>
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                </asp:GridView>
                            </td>
                        </tr>

                        <%--<tr>
            <td colspan="6">
            <asp:Button ID="btnDocUp" runat="server" class="nextclick" Font-Bold="true" ForeColor="Green"  OnClientClick="FTPUpload1()" Text="DocUp" />
            </td>--%>
                        <tr>
                            <td colspan="10">
                                <hr />
                            </td>
                        </tr>
                        <tr style="background-color: lightgray">
                            <td colspan="10">
                                <asp:Button ID="btnSubmit" runat="server" class="nextclick" Font-Bold="true" ForeColor="Green" OnClientClick="FTPUpload1()" Text="Submit"/>
                            </td>
                        </tr>
                        </tr> 
            
                    </table>
                </div>

                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TADAAprvSingleEmployeeByImsSuperv.aspx.cs" Inherits="UI.SAD.Order.TADAAprvSingleEmployeeByImsSuperv" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
 <script src="../../../../Content/JS/datepickr.min.js"></script>

    <script>
        function Registration(url) {
            window.open('AttachmentCheckingBySupervisor.aspx?ID=' + 'sub', "scrollbars=yes,toolbar=0,height=250,width=500,top=5,left=20, resizable=yes, title=Preview");
            return false;
        }
        function Confirm() {
            document.getElementById("hdnconfirm").value = "0";
            var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
            }
        

</script>

     <script type="text/javascript">
           
            $("[id*=txtdecCostPetrolT]").live("keyup", function () {
                if (!jQuery.trim($(this).val()) == '') {

                    if (!isNaN(parseFloat($(this).val()))) {
                        var row = $(this).closest("tr");

                        var petrol = parseFloat($("[id*=txtdecCostPetrolT]", row).val());
                        var oct = parseFloat($("[id*=txtdecCostOctenT]", row).val());
                        var CarbonNitGas = parseFloat($("[id*=txtdecCostCarbonNitGasT]", row).val());
                        var lubr = parseFloat($("[id*=txtlubricantcost]", row).val());
                        var Bus = parseFloat($("[id*=txtdecFareBusAmountT]", row).val());
                        var Rick = parseFloat($("[id*=txtdecFareRickshawAmountT]", row).val());
                        var cng = parseFloat($("[id*=txtdecFareCNGAmountT]", row).val());
                        var train = parseFloat($("[id*=txtdecFareTrainAmountT]", row).val());
                        var air = parseFloat($("[id*=txtdecFareAirPlaneT]", row).val());
                         var boat = parseFloat($("[id*=txtdecFareBoatT]", row).val());
                        var othvhcl = parseFloat($("[id*=txtdecFareOtherVheicleAmountT]", row).val());
                       
                        var mnt = parseFloat($("[id*=txtdecCostAmountMaintenaceT]", row).val());
                        var fertol = parseFloat($("[id*=txtdecFeryTollCostT]", row).val());
                        var ownda = parseFloat($("[id*=txtdecDAAmountT]", row).val());
                        var drvda = parseFloat($("[id*=txtdecDriverDACostT]", row).val());
                        var owhhotl = parseFloat($("[id*=txtdecHotelBillAmountT]", row).val());
                        var drvhotl = parseFloat($("[id*=txtdecDriverHotelBillAmountT]", row).val());
                        var phcopy = parseFloat($("[id*=txtdecPhotoCopyCostT]", row).val());
                        var courier = parseFloat($("[id*=txtdecCourierCostT]", row).val());
                        var other = parseFloat($("[id*=txtdecOtherBillAmountT]", row).val());

                        var grandtotal = petrol + oct + CarbonNitGas + lubr + Bus + Rick + cng + train + air +boat+ othvhcl + mnt + fertol + ownda + drvda + owhhotl + drvhotl + phcopy + courier + other;

                        //alert(parseFloat($("[id*=txtdecRowTotalT]", row).val(grandtotal)));

                        $("[id*=txtdecRowTotalT]", row).val(grandtotal);
                         
                    }
                } else {
                    $(this).val('');
                }
            });
               
        
            $("[id*=txtdecCostOctenT]").live("keyup", function () {
                if (!jQuery.trim($(this).val()) == '') {

                    if (!isNaN(parseFloat($(this).val()))) {
                        var row = $(this).closest("tr");

                        var petrol = parseFloat($("[id*=txtdecCostPetrolT]", row).val());
                        var oct = parseFloat($("[id*=txtdecCostOctenT]", row).val());
                        var CarbonNitGas = parseFloat($("[id*=txtdecCostCarbonNitGasT]", row).val());
                        var lubr = parseFloat($("[id*=txtlubricantcost]", row).val());
                        var Bus = parseFloat($("[id*=txtdecFareBusAmountT]", row).val());
                        var Rick = parseFloat($("[id*=txtdecFareRickshawAmountT]", row).val());
                        var cng = parseFloat($("[id*=txtdecFareCNGAmountT]", row).val());
                        var train = parseFloat($("[id*=txtdecFareTrainAmountT]", row).val());
                        var air = parseFloat($("[id*=txtdecFareAirPlaneT]", row).val());
                         var boat = parseFloat($("[id*=txtdecFareBoatT]", row).val());
                        var othvhcl = parseFloat($("[id*=txtdecFareOtherVheicleAmountT]", row).val());
                        var mnt = parseFloat($("[id*=txtdecCostAmountMaintenaceT]", row).val());
                        var fertol = parseFloat($("[id*=txtdecFeryTollCostT]", row).val());
                        var ownda = parseFloat($("[id*=txtdecDAAmountT]", row).val());
                        var drvda = parseFloat($("[id*=txtdecDriverDACostT]", row).val());
                        var owhhotl = parseFloat($("[id*=txtdecHotelBillAmountT]", row).val());
                        var drvhotl = parseFloat($("[id*=txtdecDriverHotelBillAmountT]", row).val());
                        var phcopy = parseFloat($("[id*=txtdecPhotoCopyCostT]", row).val());
                        var courier = parseFloat($("[id*=txtdecCourierCostT]", row).val());
                        var other = parseFloat($("[id*=txtdecOtherBillAmountT]", row).val());

                        var grandtotal = petrol + oct + CarbonNitGas + lubr + Bus + Rick + cng + train + air +boat+ othvhcl + mnt + fertol + ownda + drvda + owhhotl + drvhotl + phcopy + courier + other;

                        //alert(parseFloat($("[id*=txtdecRowTotalT]", row).val(grandtotal)));

                        $("[id*=txtdecRowTotalT]", row).val(grandtotal);

                    }
                } else {
                    $(this).val('');
                }
            });
            $("[id*=txtdecCostCarbonNitGasT]").live("keyup", function () {
                if (!jQuery.trim($(this).val()) == '') {

                    if (!isNaN(parseFloat($(this).val()))) {
                        var row = $(this).closest("tr");

                        var petrol = parseFloat($("[id*=txtdecCostPetrolT]", row).val());
                        var oct = parseFloat($("[id*=txtdecCostOctenT]", row).val());
                        var CarbonNitGas = parseFloat($("[id*=txtdecCostCarbonNitGasT]", row).val());
                        var lubr = parseFloat($("[id*=txtlubricantcost]", row).val());
                        var Bus = parseFloat($("[id*=txtdecFareBusAmountT]", row).val());
                        var Rick = parseFloat($("[id*=txtdecFareRickshawAmountT]", row).val());
                        var cng = parseFloat($("[id*=txtdecFareCNGAmountT]", row).val());
                        var train = parseFloat($("[id*=txtdecFareTrainAmountT]", row).val());
                        var air = parseFloat($("[id*=txtdecFareAirPlaneT]", row).val());
                         var boat = parseFloat($("[id*=txtdecFareBoatT]", row).val());
                        var othvhcl = parseFloat($("[id*=txtdecFareOtherVheicleAmountT]", row).val());
                        var mnt = parseFloat($("[id*=txtdecCostAmountMaintenaceT]", row).val());
                        var fertol = parseFloat($("[id*=txtdecFeryTollCostT]", row).val());
                        var ownda = parseFloat($("[id*=txtdecDAAmountT]", row).val());
                        var drvda = parseFloat($("[id*=txtdecDriverDACostT]", row).val());
                        var owhhotl = parseFloat($("[id*=txtdecHotelBillAmountT]", row).val());
                        var drvhotl = parseFloat($("[id*=txtdecDriverHotelBillAmountT]", row).val());
                        var phcopy = parseFloat($("[id*=txtdecPhotoCopyCostT]", row).val());
                        var courier = parseFloat($("[id*=txtdecCourierCostT]", row).val());
                        var other = parseFloat($("[id*=txtdecOtherBillAmountT]", row).val());

                        var grandtotal = petrol + oct + CarbonNitGas + lubr + Bus + Rick + cng + train + air +boat+ othvhcl + mnt + fertol + ownda + drvda + owhhotl + drvhotl + phcopy + courier + other;

                        //alert(parseFloat($("[id*=txtdecRowTotalT]", row).val(grandtotal)));

                        $("[id*=txtdecRowTotalT]", row).val(grandtotal);

                    }
                } else {
                    $(this).val('');
                }
            });
            $("[id*=txtlubricantcost]").live("keyup", function () {
                if (!jQuery.trim($(this).val()) == '') {

                    if (!isNaN(parseFloat($(this).val()))) {
                        var row = $(this).closest("tr");

                        var petrol = parseFloat($("[id*=txtdecCostPetrolT]", row).val());
                        var oct = parseFloat($("[id*=txtdecCostOctenT]", row).val());
                        var CarbonNitGas = parseFloat($("[id*=txtdecCostCarbonNitGasT]", row).val());
                        var lubr = parseFloat($("[id*=txtlubricantcost]", row).val());
                        var Bus = parseFloat($("[id*=txtdecFareBusAmountT]", row).val());
                        var Rick = parseFloat($("[id*=txtdecFareRickshawAmountT]", row).val());
                        var cng = parseFloat($("[id*=txtdecFareCNGAmountT]", row).val());
                        var train = parseFloat($("[id*=txtdecFareTrainAmountT]", row).val());
                        var air = parseFloat($("[id*=txtdecFareAirPlaneT]", row).val());
                         var boat = parseFloat($("[id*=txtdecFareBoatT]", row).val());
                        var othvhcl = parseFloat($("[id*=txtdecFareOtherVheicleAmountT]", row).val());
                        var mnt = parseFloat($("[id*=txtdecCostAmountMaintenaceT]", row).val());
                        var fertol = parseFloat($("[id*=txtdecFeryTollCostT]", row).val());
                        var ownda = parseFloat($("[id*=txtdecDAAmountT]", row).val());
                        var drvda = parseFloat($("[id*=txtdecDriverDACostT]", row).val());
                        var owhhotl = parseFloat($("[id*=txtdecHotelBillAmountT]", row).val());
                        var drvhotl = parseFloat($("[id*=txtdecDriverHotelBillAmountT]", row).val());
                        var phcopy = parseFloat($("[id*=txtdecPhotoCopyCostT]", row).val());
                        var courier = parseFloat($("[id*=txtdecCourierCostT]", row).val());
                        var other = parseFloat($("[id*=txtdecOtherBillAmountT]", row).val());

                        var grandtotal = petrol + oct + CarbonNitGas + lubr + Bus + Rick + cng + train + air+boat + othvhcl + mnt + fertol + ownda + drvda + owhhotl + drvhotl + phcopy + courier + other;

                        //alert(parseFloat($("[id*=txtdecRowTotalT]", row).val(grandtotal)));

                        $("[id*=txtdecRowTotalT]", row).val(grandtotal);

                    }
                } else {
                    $(this).val('');
                }
            });
            $("[id*=txtdecFareBusAmountT]").live("keyup", function () {
                if (!jQuery.trim($(this).val()) == '') {

                    if (!isNaN(parseFloat($(this).val()))) {
                        var row = $(this).closest("tr");

                        var petrol = parseFloat($("[id*=txtdecCostPetrolT]", row).val());
                        var oct = parseFloat($("[id*=txtdecCostOctenT]", row).val());
                        var CarbonNitGas = parseFloat($("[id*=txtdecCostCarbonNitGasT]", row).val());
                        var lubr = parseFloat($("[id*=txtlubricantcost]", row).val());
                        var Bus = parseFloat($("[id*=txtdecFareBusAmountT]", row).val());
                        var Rick = parseFloat($("[id*=txtdecFareRickshawAmountT]", row).val());
                        var cng = parseFloat($("[id*=txtdecFareCNGAmountT]", row).val());
                        var train = parseFloat($("[id*=txtdecFareTrainAmountT]", row).val());
                        var air = parseFloat($("[id*=txtdecFareAirPlaneT]", row).val());
                         var boat = parseFloat($("[id*=txtdecFareBoatT]", row).val());
                        var othvhcl = parseFloat($("[id*=txtdecFareOtherVheicleAmountT]", row).val());
                        var mnt = parseFloat($("[id*=txtdecCostAmountMaintenaceT]", row).val());
                        var fertol = parseFloat($("[id*=txtdecFeryTollCostT]", row).val());
                        var ownda = parseFloat($("[id*=txtdecDAAmountT]", row).val());
                        var drvda = parseFloat($("[id*=txtdecDriverDACostT]", row).val());
                        var owhhotl = parseFloat($("[id*=txtdecHotelBillAmountT]", row).val());
                        var drvhotl = parseFloat($("[id*=txtdecDriverHotelBillAmountT]", row).val());
                        var phcopy = parseFloat($("[id*=txtdecPhotoCopyCostT]", row).val());
                        var courier = parseFloat($("[id*=txtdecCourierCostT]", row).val());
                        var other = parseFloat($("[id*=txtdecOtherBillAmountT]", row).val());

                        var grandtotal = petrol + oct + CarbonNitGas + lubr + Bus + Rick + cng + train + air +boat + othvhcl + mnt + fertol + ownda + drvda + owhhotl + drvhotl + phcopy + courier + other;

                        //alert(parseFloat($("[id*=txtdecRowTotalT]", row).val(grandtotal)));

                        $("[id*=txtdecRowTotalT]", row).val(grandtotal);

                    }
                } else {
                    $(this).val('');
                }
            });
            $("[id*=txtdecFareRickshawAmountT]").live("keyup", function () {
                if (!jQuery.trim($(this).val()) == '') {

                    if (!isNaN(parseFloat($(this).val()))) {
                        var row = $(this).closest("tr");

                        var petrol = parseFloat($("[id*=txtdecCostPetrolT]", row).val());
                        var oct = parseFloat($("[id*=txtdecCostOctenT]", row).val());
                        var CarbonNitGas = parseFloat($("[id*=txtdecCostCarbonNitGasT]", row).val());
                        var lubr = parseFloat($("[id*=txtlubricantcost]", row).val());
                        var Bus = parseFloat($("[id*=txtdecFareBusAmountT]", row).val());
                        var Rick = parseFloat($("[id*=txtdecFareRickshawAmountT]", row).val());
                        var cng = parseFloat($("[id*=txtdecFareCNGAmountT]", row).val());
                        var train = parseFloat($("[id*=txtdecFareTrainAmountT]", row).val());
                        var air = parseFloat($("[id*=txtdecFareAirPlaneT]", row).val());
                         var boat = parseFloat($("[id*=txtdecFareBoatT]", row).val());
                        var othvhcl = parseFloat($("[id*=txtdecFareOtherVheicleAmountT]", row).val());
                        var mnt = parseFloat($("[id*=txtdecCostAmountMaintenaceT]", row).val());
                        var fertol = parseFloat($("[id*=txtdecFeryTollCostT]", row).val());
                        var ownda = parseFloat($("[id*=txtdecDAAmountT]", row).val());
                        var drvda = parseFloat($("[id*=txtdecDriverDACostT]", row).val());
                        var owhhotl = parseFloat($("[id*=txtdecHotelBillAmountT]", row).val());
                        var drvhotl = parseFloat($("[id*=txtdecDriverHotelBillAmountT]", row).val());
                        var phcopy = parseFloat($("[id*=txtdecPhotoCopyCostT]", row).val());
                        var courier = parseFloat($("[id*=txtdecCourierCostT]", row).val());
                        var other = parseFloat($("[id*=txtdecOtherBillAmountT]", row).val());

                        var grandtotal = petrol + oct + CarbonNitGas + lubr + Bus + Rick + cng + train + air+boat + othvhcl + mnt + fertol + ownda + drvda + owhhotl + drvhotl + phcopy + courier + other;

                        //alert(parseFloat($("[id*=txtdecRowTotalT]", row).val(grandtotal)));

                        $("[id*=txtdecRowTotalT]", row).val(grandtotal);

                    }
                } else {
                    $(this).val('');
                }
            });
            $("[id*=txtdecFareCNGAmountT]").live("keyup", function () {
                if (!jQuery.trim($(this).val()) == '') {

                    if (!isNaN(parseFloat($(this).val()))) {
                        var row = $(this).closest("tr");

                        var petrol = parseFloat($("[id*=txtdecCostPetrolT]", row).val());
                        var oct = parseFloat($("[id*=txtdecCostOctenT]", row).val());
                        var CarbonNitGas = parseFloat($("[id*=txtdecCostCarbonNitGasT]", row).val());
                        var lubr = parseFloat($("[id*=txtlubricantcost]", row).val());
                        var Bus = parseFloat($("[id*=txtdecFareBusAmountT]", row).val());
                        var Rick = parseFloat($("[id*=txtdecFareRickshawAmountT]", row).val());
                        var cng = parseFloat($("[id*=txtdecFareCNGAmountT]", row).val());
                        var train = parseFloat($("[id*=txtdecFareTrainAmountT]", row).val());
                        var air = parseFloat($("[id*=txtdecFareAirPlaneT]", row).val());
                         var boat = parseFloat($("[id*=txtdecFareBoatT]", row).val());
                        var othvhcl = parseFloat($("[id*=txtdecFareOtherVheicleAmountT]", row).val());
                        var mnt = parseFloat($("[id*=txtdecCostAmountMaintenaceT]", row).val());
                        var fertol = parseFloat($("[id*=txtdecFeryTollCostT]", row).val());
                        var ownda = parseFloat($("[id*=txtdecDAAmountT]", row).val());
                        var drvda = parseFloat($("[id*=txtdecDriverDACostT]", row).val());
                        var owhhotl = parseFloat($("[id*=txtdecHotelBillAmountT]", row).val());
                        var drvhotl = parseFloat($("[id*=txtdecDriverHotelBillAmountT]", row).val());
                        var phcopy = parseFloat($("[id*=txtdecPhotoCopyCostT]", row).val());
                        var courier = parseFloat($("[id*=txtdecCourierCostT]", row).val());
                        var other = parseFloat($("[id*=txtdecOtherBillAmountT]", row).val());

                        var grandtotal = petrol + oct + CarbonNitGas + lubr + Bus + Rick + cng + train + air+boat + othvhcl + mnt + fertol + ownda + drvda + owhhotl + drvhotl + phcopy + courier + other;

                        //alert(parseFloat($("[id*=txtdecRowTotalT]", row).val(grandtotal)));

                        $("[id*=txtdecRowTotalT]", row).val(grandtotal);

                    }
                } else {
                    $(this).val('');
                }
            });
            $("[id*=txtdecFareTrainAmountT]").live("keyup", function () {
                if (!jQuery.trim($(this).val()) == '') {

                    if (!isNaN(parseFloat($(this).val()))) {
                        var row = $(this).closest("tr");

                        var petrol = parseFloat($("[id*=txtdecCostPetrolT]", row).val());
                        var oct = parseFloat($("[id*=txtdecCostOctenT]", row).val());
                        var CarbonNitGas = parseFloat($("[id*=txtdecCostCarbonNitGasT]", row).val());
                        var lubr = parseFloat($("[id*=txtlubricantcost]", row).val());
                        var Bus = parseFloat($("[id*=txtdecFareBusAmountT]", row).val());
                        var Rick = parseFloat($("[id*=txtdecFareRickshawAmountT]", row).val());
                        var cng = parseFloat($("[id*=txtdecFareCNGAmountT]", row).val());
                        var train = parseFloat($("[id*=txtdecFareTrainAmountT]", row).val());
                        var air = parseFloat($("[id*=txtdecFareAirPlaneT]", row).val());
                         var boat = parseFloat($("[id*=txtdecFareBoatT]", row).val());
                        var othvhcl = parseFloat($("[id*=txtdecFareOtherVheicleAmountT]", row).val());
                        var mnt = parseFloat($("[id*=txtdecCostAmountMaintenaceT]", row).val());
                        var fertol = parseFloat($("[id*=txtdecFeryTollCostT]", row).val());
                        var ownda = parseFloat($("[id*=txtdecDAAmountT]", row).val());
                        var drvda = parseFloat($("[id*=txtdecDriverDACostT]", row).val());
                        var owhhotl = parseFloat($("[id*=txtdecHotelBillAmountT]", row).val());
                        var drvhotl = parseFloat($("[id*=txtdecDriverHotelBillAmountT]", row).val());
                        var phcopy = parseFloat($("[id*=txtdecPhotoCopyCostT]", row).val());
                        var courier = parseFloat($("[id*=txtdecCourierCostT]", row).val());
                        var other = parseFloat($("[id*=txtdecOtherBillAmountT]", row).val());

                        var grandtotal = petrol + oct + CarbonNitGas + lubr + Bus + Rick + cng + train + air+boat + othvhcl + mnt + fertol + ownda + drvda + owhhotl + drvhotl + phcopy + courier + other;

                        //alert(parseFloat($("[id*=txtdecRowTotalT]", row).val(grandtotal)));

                        $("[id*=txtdecRowTotalT]", row).val(grandtotal);

                    }
                } else {
                    $(this).val('');
                }
            });
            $("[id*=txtdecFareAirPlaneT]").live("keyup", function () {
                if (!jQuery.trim($(this).val()) == '') {

                    if (!isNaN(parseFloat($(this).val()))) {
                        var row = $(this).closest("tr");

                        var petrol = parseFloat($("[id*=txtdecCostPetrolT]", row).val());
                        var oct = parseFloat($("[id*=txtdecCostOctenT]", row).val());
                        var CarbonNitGas = parseFloat($("[id*=txtdecCostCarbonNitGasT]", row).val());
                        var lubr = parseFloat($("[id*=txtlubricantcost]", row).val());
                        var Bus = parseFloat($("[id*=txtdecFareBusAmountT]", row).val());
                        var Rick = parseFloat($("[id*=txtdecFareRickshawAmountT]", row).val());
                        var cng = parseFloat($("[id*=txtdecFareCNGAmountT]", row).val());
                        var train = parseFloat($("[id*=txtdecFareTrainAmountT]", row).val());
                        var air = parseFloat($("[id*=txtdecFareAirPlaneT]", row).val());
                         var boat = parseFloat($("[id*=txtdecFareBoatT]", row).val());
                        var othvhcl = parseFloat($("[id*=txtdecFareOtherVheicleAmountT]", row).val());
                        var mnt = parseFloat($("[id*=txtdecCostAmountMaintenaceT]", row).val());
                        var fertol = parseFloat($("[id*=txtdecFeryTollCostT]", row).val());
                        var ownda = parseFloat($("[id*=txtdecDAAmountT]", row).val());
                        var drvda = parseFloat($("[id*=txtdecDriverDACostT]", row).val());
                        var owhhotl = parseFloat($("[id*=txtdecHotelBillAmountT]", row).val());
                        var drvhotl = parseFloat($("[id*=txtdecDriverHotelBillAmountT]", row).val());
                        var phcopy = parseFloat($("[id*=txtdecPhotoCopyCostT]", row).val());
                        var courier = parseFloat($("[id*=txtdecCourierCostT]", row).val());
                        var other = parseFloat($("[id*=txtdecOtherBillAmountT]", row).val());

                        var grandtotal = petrol + oct + CarbonNitGas + lubr + Bus + Rick + cng + train + air+boat + othvhcl + mnt + fertol + ownda + drvda + owhhotl + drvhotl + phcopy + courier + other;

                        //alert(parseFloat($("[id*=txtdecRowTotalT]", row).val(grandtotal)));

                        $("[id*=txtdecRowTotalT]", row).val(grandtotal);

                    }
                } else {
                    $(this).val('');
                }
         });
         $("[id*=txtdecFareBoatT]").live("keyup", function () {
                if (!jQuery.trim($(this).val()) == '') {

                    if (!isNaN(parseFloat($(this).val()))) {
                        var row = $(this).closest("tr");

                        var petrol = parseFloat($("[id*=txtdecCostPetrolT]", row).val());
                        var oct = parseFloat($("[id*=txtdecCostOctenT]", row).val());
                        var CarbonNitGas = parseFloat($("[id*=txtdecCostCarbonNitGasT]", row).val());
                        var lubr = parseFloat($("[id*=txtlubricantcost]", row).val());
                        var Bus = parseFloat($("[id*=txtdecFareBusAmountT]", row).val());
                        var Rick = parseFloat($("[id*=txtdecFareRickshawAmountT]", row).val());
                        var cng = parseFloat($("[id*=txtdecFareCNGAmountT]", row).val());
                        var train = parseFloat($("[id*=txtdecFareTrainAmountT]", row).val());
                        var air = parseFloat($("[id*=txtdecFareAirPlaneT]", row).val());
                         var boat = parseFloat($("[id*=txtdecFareBoatT]", row).val());
                        var othvhcl = parseFloat($("[id*=txtdecFareOtherVheicleAmountT]", row).val());
                        var mnt = parseFloat($("[id*=txtdecCostAmountMaintenaceT]", row).val());
                        var fertol = parseFloat($("[id*=txtdecFeryTollCostT]", row).val());
                        var ownda = parseFloat($("[id*=txtdecDAAmountT]", row).val());
                        var drvda = parseFloat($("[id*=txtdecDriverDACostT]", row).val());
                        var owhhotl = parseFloat($("[id*=txtdecHotelBillAmountT]", row).val());
                        var drvhotl = parseFloat($("[id*=txtdecDriverHotelBillAmountT]", row).val());
                        var phcopy = parseFloat($("[id*=txtdecPhotoCopyCostT]", row).val());
                        var courier = parseFloat($("[id*=txtdecCourierCostT]", row).val());
                        var other = parseFloat($("[id*=txtdecOtherBillAmountT]", row).val());

                        var grandtotal = petrol + oct + CarbonNitGas + lubr + Bus + Rick + cng + train + air+boat + othvhcl + mnt + fertol + ownda + drvda + owhhotl + drvhotl + phcopy + courier + other;

                        //alert(parseFloat($("[id*=txtdecRowTotalT]", row).val(grandtotal)));

                        $("[id*=txtdecRowTotalT]", row).val(grandtotal);

                    }
                } else {
                    $(this).val('');
                }
            });
            $("[id*=txtdecFareOtherVheicleAmountT]").live("keyup", function () {
                if (!jQuery.trim($(this).val()) == '') {

                    if (!isNaN(parseFloat($(this).val()))) {
                        var row = $(this).closest("tr");

                        var petrol = parseFloat($("[id*=txtdecCostPetrolT]", row).val());
                        var oct = parseFloat($("[id*=txtdecCostOctenT]", row).val());
                        var CarbonNitGas = parseFloat($("[id*=txtdecCostCarbonNitGasT]", row).val());
                        var lubr = parseFloat($("[id*=txtlubricantcost]", row).val());
                        var Bus = parseFloat($("[id*=txtdecFareBusAmountT]", row).val());
                        var Rick = parseFloat($("[id*=txtdecFareRickshawAmountT]", row).val());
                        var cng = parseFloat($("[id*=txtdecFareCNGAmountT]", row).val());
                        var train = parseFloat($("[id*=txtdecFareTrainAmountT]", row).val());
                        var air = parseFloat($("[id*=txtdecFareAirPlaneT]", row).val());
                         var boat = parseFloat($("[id*=txtdecFareBoatT]", row).val());
                        var othvhcl = parseFloat($("[id*=txtdecFareOtherVheicleAmountT]", row).val());
                        var mnt = parseFloat($("[id*=txtdecCostAmountMaintenaceT]", row).val());
                        var fertol = parseFloat($("[id*=txtdecFeryTollCostT]", row).val());
                        var ownda = parseFloat($("[id*=txtdecDAAmountT]", row).val());
                        var drvda = parseFloat($("[id*=txtdecDriverDACostT]", row).val());
                        var owhhotl = parseFloat($("[id*=txtdecHotelBillAmountT]", row).val());
                        var drvhotl = parseFloat($("[id*=txtdecDriverHotelBillAmountT]", row).val());
                        var phcopy = parseFloat($("[id*=txtdecPhotoCopyCostT]", row).val());
                        var courier = parseFloat($("[id*=txtdecCourierCostT]", row).val());
                        var other = parseFloat($("[id*=txtdecOtherBillAmountT]", row).val());

                        var grandtotal = petrol + oct + CarbonNitGas + lubr + Bus + Rick + cng + train + air +boat + othvhcl + mnt + fertol + ownda + drvda + owhhotl + drvhotl + phcopy + courier + other;

                        //alert(parseFloat($("[id*=txtdecRowTotalT]", row).val(grandtotal)));

                        $("[id*=txtdecRowTotalT]", row).val(grandtotal);

                    }
                } else {
                    $(this).val('');
                }
            });
            $("[id*=txtdecCostAmountMaintenaceT]").live("keyup", function () {
                if (!jQuery.trim($(this).val()) == '') {

                    if (!isNaN(parseFloat($(this).val()))) {
                        var row = $(this).closest("tr");

                        var petrol = parseFloat($("[id*=txtdecCostPetrolT]", row).val());
                        var oct = parseFloat($("[id*=txtdecCostOctenT]", row).val());
                        var CarbonNitGas = parseFloat($("[id*=txtdecCostCarbonNitGasT]", row).val());
                        var lubr = parseFloat($("[id*=txtlubricantcost]", row).val());
                        var Bus = parseFloat($("[id*=txtdecFareBusAmountT]", row).val());
                        var Rick = parseFloat($("[id*=txtdecFareRickshawAmountT]", row).val());
                        var cng = parseFloat($("[id*=txtdecFareCNGAmountT]", row).val());
                        var train = parseFloat($("[id*=txtdecFareTrainAmountT]", row).val());
                        var air = parseFloat($("[id*=txtdecFareAirPlaneT]", row).val());
                         var boat = parseFloat($("[id*=txtdecFareBoatT]", row).val());
                        var othvhcl = parseFloat($("[id*=txtdecFareOtherVheicleAmountT]", row).val());
                        var mnt = parseFloat($("[id*=txtdecCostAmountMaintenaceT]", row).val());
                        var fertol = parseFloat($("[id*=txtdecFeryTollCostT]", row).val());
                        var ownda = parseFloat($("[id*=txtdecDAAmountT]", row).val());
                        var drvda = parseFloat($("[id*=txtdecDriverDACostT]", row).val());
                        var owhhotl = parseFloat($("[id*=txtdecHotelBillAmountT]", row).val());
                        var drvhotl = parseFloat($("[id*=txtdecDriverHotelBillAmountT]", row).val());
                        var phcopy = parseFloat($("[id*=txtdecPhotoCopyCostT]", row).val());
                        var courier = parseFloat($("[id*=txtdecCourierCostT]", row).val());
                        var other = parseFloat($("[id*=txtdecOtherBillAmountT]", row).val());

                        var grandtotal = petrol + oct + CarbonNitGas + lubr + Bus + Rick + cng + train + air +boat + othvhcl + mnt + fertol + ownda + drvda + owhhotl + drvhotl + phcopy + courier + other;

                        //alert(parseFloat($("[id*=txtdecRowTotalT]", row).val(grandtotal)));

                        $("[id*=txtdecRowTotalT]", row).val(grandtotal);

                    }
                } else {
                    $(this).val('');
                }
            });
            $("[id*=txtdecFeryTollCostT]").live("keyup", function () {
                if (!jQuery.trim($(this).val()) == '') {

                    if (!isNaN(parseFloat($(this).val()))) {
                        var row = $(this).closest("tr");

                        var petrol = parseFloat($("[id*=txtdecCostPetrolT]", row).val());
                        var oct = parseFloat($("[id*=txtdecCostOctenT]", row).val());
                        var CarbonNitGas = parseFloat($("[id*=txtdecCostCarbonNitGasT]", row).val());
                        var lubr = parseFloat($("[id*=txtlubricantcost]", row).val());
                        var Bus = parseFloat($("[id*=txtdecFareBusAmountT]", row).val());
                        var Rick = parseFloat($("[id*=txtdecFareRickshawAmountT]", row).val());
                        var cng = parseFloat($("[id*=txtdecFareCNGAmountT]", row).val());
                        var train = parseFloat($("[id*=txtdecFareTrainAmountT]", row).val());
                        var air = parseFloat($("[id*=txtdecFareAirPlaneT]", row).val());
                         var boat = parseFloat($("[id*=txtdecFareBoatT]", row).val());
                        var othvhcl = parseFloat($("[id*=txtdecFareOtherVheicleAmountT]", row).val());
                        var mnt = parseFloat($("[id*=txtdecCostAmountMaintenaceT]", row).val());
                        var fertol = parseFloat($("[id*=txtdecFeryTollCostT]", row).val());
                        var ownda = parseFloat($("[id*=txtdecDAAmountT]", row).val());
                        var drvda = parseFloat($("[id*=txtdecDriverDACostT]", row).val());
                        var owhhotl = parseFloat($("[id*=txtdecHotelBillAmountT]", row).val());
                        var drvhotl = parseFloat($("[id*=txtdecDriverHotelBillAmountT]", row).val());
                        var phcopy = parseFloat($("[id*=txtdecPhotoCopyCostT]", row).val());
                        var courier = parseFloat($("[id*=txtdecCourierCostT]", row).val());
                        var other = parseFloat($("[id*=txtdecOtherBillAmountT]", row).val());

                        var grandtotal = petrol + oct + CarbonNitGas + lubr + Bus + Rick + cng + train + air +boat + othvhcl + mnt + fertol + ownda + drvda + owhhotl + drvhotl + phcopy + courier + other;

                        //alert(parseFloat($("[id*=txtdecRowTotalT]", row).val(grandtotal)));

                        $("[id*=txtdecRowTotalT]", row).val(grandtotal);

                    }
                } else {
                    $(this).val('');
                }
            });
            $("[id*=txtdecDAAmountT]").live("keyup", function () {
                if (!jQuery.trim($(this).val()) == '') {

                    if (!isNaN(parseFloat($(this).val()))) {
                        var row = $(this).closest("tr");

                        var petrol = parseFloat($("[id*=txtdecCostPetrolT]", row).val());
                        var oct = parseFloat($("[id*=txtdecCostOctenT]", row).val());
                        var CarbonNitGas = parseFloat($("[id*=txtdecCostCarbonNitGasT]", row).val());
                        var lubr = parseFloat($("[id*=txtlubricantcost]", row).val());
                        var Bus = parseFloat($("[id*=txtdecFareBusAmountT]", row).val());
                        var Rick = parseFloat($("[id*=txtdecFareRickshawAmountT]", row).val());
                        var cng = parseFloat($("[id*=txtdecFareCNGAmountT]", row).val());
                        var train = parseFloat($("[id*=txtdecFareTrainAmountT]", row).val());
                        var air = parseFloat($("[id*=txtdecFareAirPlaneT]", row).val());
                         var boat = parseFloat($("[id*=txtdecFareBoatT]", row).val());
                        var othvhcl = parseFloat($("[id*=txtdecFareOtherVheicleAmountT]", row).val());
                        var mnt = parseFloat($("[id*=txtdecCostAmountMaintenaceT]", row).val());
                        var fertol = parseFloat($("[id*=txtdecFeryTollCostT]", row).val());
                        var ownda = parseFloat($("[id*=txtdecDAAmountT]", row).val());
                        var drvda = parseFloat($("[id*=txtdecDriverDACostT]", row).val());
                        var owhhotl = parseFloat($("[id*=txtdecHotelBillAmountT]", row).val());
                        var drvhotl = parseFloat($("[id*=txtdecDriverHotelBillAmountT]", row).val());
                        var phcopy = parseFloat($("[id*=txtdecPhotoCopyCostT]", row).val());
                        var courier = parseFloat($("[id*=txtdecCourierCostT]", row).val());
                        var other = parseFloat($("[id*=txtdecOtherBillAmountT]", row).val());

                        var grandtotal = petrol + oct + CarbonNitGas + lubr + Bus + Rick + cng + train + air +boat + othvhcl + mnt + fertol + ownda + drvda + owhhotl + drvhotl + phcopy + courier + other;

                        //alert(parseFloat($("[id*=txtdecRowTotalT]", row).val(grandtotal)));

                        $("[id*=txtdecRowTotalT]", row).val(grandtotal);

                    }
                } else {
                    $(this).val('');
                }
            });
            $("[id*=txtdecDriverDACostT]").live("keyup", function () {
                if (!jQuery.trim($(this).val()) == '') {

                    if (!isNaN(parseFloat($(this).val()))) {
                        var row = $(this).closest("tr");

                        var petrol = parseFloat($("[id*=txtdecCostPetrolT]", row).val());
                        var oct = parseFloat($("[id*=txtdecCostOctenT]", row).val());
                        var CarbonNitGas = parseFloat($("[id*=txtdecCostCarbonNitGasT]", row).val());
                        var lubr = parseFloat($("[id*=txtlubricantcost]", row).val());
                        var Bus = parseFloat($("[id*=txtdecFareBusAmountT]", row).val());
                        var Rick = parseFloat($("[id*=txtdecFareRickshawAmountT]", row).val());
                        var cng = parseFloat($("[id*=txtdecFareCNGAmountT]", row).val());
                        var train = parseFloat($("[id*=txtdecFareTrainAmountT]", row).val());
                        var air = parseFloat($("[id*=txtdecFareAirPlaneT]", row).val());
                         var boat = parseFloat($("[id*=txtdecFareBoatT]", row).val());
                        var othvhcl = parseFloat($("[id*=txtdecFareOtherVheicleAmountT]", row).val());
                        var mnt = parseFloat($("[id*=txtdecCostAmountMaintenaceT]", row).val());
                        var fertol = parseFloat($("[id*=txtdecFeryTollCostT]", row).val());
                        var ownda = parseFloat($("[id*=txtdecDAAmountT]", row).val());
                        var drvda = parseFloat($("[id*=txtdecDriverDACostT]", row).val());
                        var owhhotl = parseFloat($("[id*=txtdecHotelBillAmountT]", row).val());
                        var drvhotl = parseFloat($("[id*=txtdecDriverHotelBillAmountT]", row).val());
                        var phcopy = parseFloat($("[id*=txtdecPhotoCopyCostT]", row).val());
                        var courier = parseFloat($("[id*=txtdecCourierCostT]", row).val());
                        var other = parseFloat($("[id*=txtdecOtherBillAmountT]", row).val());

                        var grandtotal = petrol + oct + CarbonNitGas + lubr + Bus + Rick + cng + train + air +boat + othvhcl + mnt + fertol + ownda + drvda + owhhotl + drvhotl + phcopy + courier + other;

                        //alert(parseFloat($("[id*=txtdecRowTotalT]", row).val(grandtotal)));

                        $("[id*=txtdecRowTotalT]", row).val(grandtotal);

                    }
                } else {
                    $(this).val('');
                }
            });
            $("[id*=txtdecHotelBillAmountT]").live("keyup", function () {
                if (!jQuery.trim($(this).val()) == '') {

                    if (!isNaN(parseFloat($(this).val()))) {
                        var row = $(this).closest("tr");

                        var petrol = parseFloat($("[id*=txtdecCostPetrolT]", row).val());
                        var oct = parseFloat($("[id*=txtdecCostOctenT]", row).val());
                        var CarbonNitGas = parseFloat($("[id*=txtdecCostCarbonNitGasT]", row).val());
                        var lubr = parseFloat($("[id*=txtlubricantcost]", row).val());
                        var Bus = parseFloat($("[id*=txtdecFareBusAmountT]", row).val());
                        var Rick = parseFloat($("[id*=txtdecFareRickshawAmountT]", row).val());
                        var cng = parseFloat($("[id*=txtdecFareCNGAmountT]", row).val());
                        var train = parseFloat($("[id*=txtdecFareTrainAmountT]", row).val());
                        var air = parseFloat($("[id*=txtdecFareAirPlaneT]", row).val());
                         var boat = parseFloat($("[id*=txtdecFareBoatT]", row).val());
                        var othvhcl = parseFloat($("[id*=txtdecFareOtherVheicleAmountT]", row).val());
                        var mnt = parseFloat($("[id*=txtdecCostAmountMaintenaceT]", row).val());
                        var fertol = parseFloat($("[id*=txtdecFeryTollCostT]", row).val());
                        var ownda = parseFloat($("[id*=txtdecDAAmountT]", row).val());
                        var drvda = parseFloat($("[id*=txtdecDriverDACostT]", row).val());
                        var owhhotl = parseFloat($("[id*=txtdecHotelBillAmountT]", row).val());
                        var drvhotl = parseFloat($("[id*=txtdecDriverHotelBillAmountT]", row).val());
                        var phcopy = parseFloat($("[id*=txtdecPhotoCopyCostT]", row).val());
                        var courier = parseFloat($("[id*=txtdecCourierCostT]", row).val());
                        var other = parseFloat($("[id*=txtdecOtherBillAmountT]", row).val());

                        var grandtotal = petrol + oct + CarbonNitGas + lubr + Bus + Rick + cng + train + air +boat + othvhcl + mnt + fertol + ownda + drvda + owhhotl + drvhotl + phcopy + courier + other;

                        //alert(parseFloat($("[id*=txtdecRowTotalT]", row).val(grandtotal)));

                        $("[id*=txtdecRowTotalT]", row).val(grandtotal);

                    }
                } else {
                    $(this).val('');
                }
            });
            $("[id*=txtdecDriverHotelBillAmountT]").live("keyup", function () {
                if (!jQuery.trim($(this).val()) == '') {

                    if (!isNaN(parseFloat($(this).val()))) {
                        var row = $(this).closest("tr");

                        var petrol = parseFloat($("[id*=txtdecCostPetrolT]", row).val());
                        var oct = parseFloat($("[id*=txtdecCostOctenT]", row).val());
                        var CarbonNitGas = parseFloat($("[id*=txtdecCostCarbonNitGasT]", row).val());
                        var lubr = parseFloat($("[id*=txtlubricantcost]", row).val());
                        var Bus = parseFloat($("[id*=txtdecFareBusAmountT]", row).val());
                        var Rick = parseFloat($("[id*=txtdecFareRickshawAmountT]", row).val());
                        var cng = parseFloat($("[id*=txtdecFareCNGAmountT]", row).val());
                        var train = parseFloat($("[id*=txtdecFareTrainAmountT]", row).val());
                        var air = parseFloat($("[id*=txtdecFareAirPlaneT]", row).val());
                         var boat = parseFloat($("[id*=txtdecFareBoatT]", row).val());
                        var othvhcl = parseFloat($("[id*=txtdecFareOtherVheicleAmountT]", row).val());
                        var mnt = parseFloat($("[id*=txtdecCostAmountMaintenaceT]", row).val());
                        var fertol = parseFloat($("[id*=txtdecFeryTollCostT]", row).val());
                        var ownda = parseFloat($("[id*=txtdecDAAmountT]", row).val());
                        var drvda = parseFloat($("[id*=txtdecDriverDACostT]", row).val());
                        var owhhotl = parseFloat($("[id*=txtdecHotelBillAmountT]", row).val());
                        var drvhotl = parseFloat($("[id*=txtdecDriverHotelBillAmountT]", row).val());
                        var phcopy = parseFloat($("[id*=txtdecPhotoCopyCostT]", row).val());
                        var courier = parseFloat($("[id*=txtdecCourierCostT]", row).val());
                        var other = parseFloat($("[id*=txtdecOtherBillAmountT]", row).val());

                        var grandtotal = petrol + oct + CarbonNitGas + lubr + Bus + Rick + cng + train + air +boat + othvhcl + mnt + fertol + ownda + drvda + owhhotl + drvhotl + phcopy + courier + other;

                        //alert(parseFloat($("[id*=txtdecRowTotalT]", row).val(grandtotal)));

                        $("[id*=txtdecRowTotalT]", row).val(grandtotal);

                    }
                } else {
                    $(this).val('');
                }
            });
            $("[id*=txtdecPhotoCopyCostT]").live("keyup", function () {
                if (!jQuery.trim($(this).val()) == '') {

                    if (!isNaN(parseFloat($(this).val()))) {
                        var row = $(this).closest("tr");

                        var petrol = parseFloat($("[id*=txtdecCostPetrolT]", row).val());
                        var oct = parseFloat($("[id*=txtdecCostOctenT]", row).val());
                        var CarbonNitGas = parseFloat($("[id*=txtdecCostCarbonNitGasT]", row).val());
                        var lubr = parseFloat($("[id*=txtlubricantcost]", row).val());
                        var Bus = parseFloat($("[id*=txtdecFareBusAmountT]", row).val());
                        var Rick = parseFloat($("[id*=txtdecFareRickshawAmountT]", row).val());
                        var cng = parseFloat($("[id*=txtdecFareCNGAmountT]", row).val());
                        var train = parseFloat($("[id*=txtdecFareTrainAmountT]", row).val());
                        var air = parseFloat($("[id*=txtdecFareAirPlaneT]", row).val());
                         var boat = parseFloat($("[id*=txtdecFareBoatT]", row).val());
                        var othvhcl = parseFloat($("[id*=txtdecFareOtherVheicleAmountT]", row).val());
                        var mnt = parseFloat($("[id*=txtdecCostAmountMaintenaceT]", row).val());
                        var fertol = parseFloat($("[id*=txtdecFeryTollCostT]", row).val());
                        var ownda = parseFloat($("[id*=txtdecDAAmountT]", row).val());
                        var drvda = parseFloat($("[id*=txtdecDriverDACostT]", row).val());
                        var owhhotl = parseFloat($("[id*=txtdecHotelBillAmountT]", row).val());
                        var drvhotl = parseFloat($("[id*=txtdecDriverHotelBillAmountT]", row).val());
                        var phcopy = parseFloat($("[id*=txtdecPhotoCopyCostT]", row).val());
                        var courier = parseFloat($("[id*=txtdecCourierCostT]", row).val());
                        var other = parseFloat($("[id*=txtdecOtherBillAmountT]", row).val());

                        var grandtotal = petrol + oct + CarbonNitGas + lubr + Bus + Rick + cng + train + air +boat + othvhcl + mnt + fertol + ownda + drvda + owhhotl + drvhotl + phcopy + courier + other;

                        //alert(parseFloat($("[id*=txtdecRowTotalT]", row).val(grandtotal)));

                        $("[id*=txtdecRowTotalT]", row).val(grandtotal);

                    }
                } else {
                    $(this).val('');
                }
            });
            $("[id*=txtdecCourierCostT]").live("keyup", function () {
                if (!jQuery.trim($(this).val()) == '') {

                    if (!isNaN(parseFloat($(this).val()))) {
                        var row = $(this).closest("tr");

                        var petrol = parseFloat($("[id*=txtdecCostPetrolT]", row).val());
                        var oct = parseFloat($("[id*=txtdecCostOctenT]", row).val());
                        var CarbonNitGas = parseFloat($("[id*=txtdecCostCarbonNitGasT]", row).val());
                        var lubr = parseFloat($("[id*=txtlubricantcost]", row).val());
                        var Bus = parseFloat($("[id*=txtdecFareBusAmountT]", row).val());
                        var Rick = parseFloat($("[id*=txtdecFareRickshawAmountT]", row).val());
                        var cng = parseFloat($("[id*=txtdecFareCNGAmountT]", row).val());
                        var train = parseFloat($("[id*=txtdecFareTrainAmountT]", row).val());
                        var air = parseFloat($("[id*=txtdecFareAirPlaneT]", row).val());
                         var boat = parseFloat($("[id*=txtdecFareBoatT]", row).val());
                        var othvhcl = parseFloat($("[id*=txtdecFareOtherVheicleAmountT]", row).val());
                        var mnt = parseFloat($("[id*=txtdecCostAmountMaintenaceT]", row).val());
                        var fertol = parseFloat($("[id*=txtdecFeryTollCostT]", row).val());
                        var ownda = parseFloat($("[id*=txtdecDAAmountT]", row).val());
                        var drvda = parseFloat($("[id*=txtdecDriverDACostT]", row).val());
                        var owhhotl = parseFloat($("[id*=txtdecHotelBillAmountT]", row).val());
                        var drvhotl = parseFloat($("[id*=txtdecDriverHotelBillAmountT]", row).val());
                        var phcopy = parseFloat($("[id*=txtdecPhotoCopyCostT]", row).val());
                        var courier = parseFloat($("[id*=txtdecCourierCostT]", row).val());
                        var other = parseFloat($("[id*=txtdecOtherBillAmountT]", row).val());

                        var grandtotal = petrol + oct + CarbonNitGas + lubr + Bus + Rick + cng + train + air+boat + othvhcl + mnt + fertol + ownda + drvda + owhhotl + drvhotl + phcopy + courier + other;

                        //alert(parseFloat($("[id*=txtdecRowTotalT]", row).val(grandtotal)));

                        $("[id*=txtdecRowTotalT]", row).val(grandtotal);

                    }
                } else {
                    $(this).val('');
                }
            });
            $("[id*=txtdecOtherBillAmountT]").live("keyup", function () {
                if (!jQuery.trim($(this).val()) == '') {

                    if (!isNaN(parseFloat($(this).val()))) {
                        var row = $(this).closest("tr");

                        var petrol = parseFloat($("[id*=txtdecCostPetrolT]", row).val());
                        var oct = parseFloat($("[id*=txtdecCostOctenT]", row).val());
                        var CarbonNitGas = parseFloat($("[id*=txtdecCostCarbonNitGasT]", row).val());
                        var lubr = parseFloat($("[id*=txtlubricantcost]", row).val());
                        var Bus = parseFloat($("[id*=txtdecFareBusAmountT]", row).val());
                        var Rick = parseFloat($("[id*=txtdecFareRickshawAmountT]", row).val());
                        var cng = parseFloat($("[id*=txtdecFareCNGAmountT]", row).val());
                        var train = parseFloat($("[id*=txtdecFareTrainAmountT]", row).val());
                        var air = parseFloat($("[id*=txtdecFareAirPlaneT]", row).val());
                         var boat = parseFloat($("[id*=txtdecFareBoatT]", row).val());
                        var othvhcl = parseFloat($("[id*=txtdecFareOtherVheicleAmountT]", row).val());
                        var mnt = parseFloat($("[id*=txtdecCostAmountMaintenaceT]", row).val());
                        var fertol = parseFloat($("[id*=txtdecFeryTollCostT]", row).val());
                        var ownda = parseFloat($("[id*=txtdecDAAmountT]", row).val());
                        var drvda = parseFloat($("[id*=txtdecDriverDACostT]", row).val());
                        var owhhotl = parseFloat($("[id*=txtdecHotelBillAmountT]", row).val());
                        var drvhotl = parseFloat($("[id*=txtdecDriverHotelBillAmountT]", row).val());
                        var phcopy = parseFloat($("[id*=txtdecPhotoCopyCostT]", row).val());
                        var courier = parseFloat($("[id*=txtdecCourierCostT]", row).val());
                        var other = parseFloat($("[id*=txtdecOtherBillAmountT]", row).val());

                        var grandtotal = petrol + oct + CarbonNitGas +lubr + Bus + Rick + cng + train + air +boat+ othvhcl + mnt + fertol + ownda + drvda + owhhotl + drvhotl + phcopy + courier + other;

                        //alert(parseFloat($("[id*=txtdecRowTotalT]", row).val(grandtotal)));

                        $("[id*=txtdecRowTotalT]", row).val(grandtotal);

                    }
                } else {
                    $(this).val('');
                }
            });
</script>
    <script type="text/javascript">
       
        $("[id*=txtdecCostPetrolT]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') { 
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                }
            } else {
                $(this).val('');
            }
            var grandTotalPetrol = 0;
            $("[id*=txtdecCostPetrolT]").each(function () {
                grandTotalPetrol = grandTotalPetrol + parseFloat($(this).val());
            });
            $("[id*=lblGTCostpetr]").html(grandTotalPetrol.toString());
        });
    </script>
    <script type="text/javascript">
       
        $("[id*=txtdecCostOctenT]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') { 
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                }
            } else {
                $(this).val('');
            }
            var grandTotalOcten = 0;
            $("[id*=txtdecCostOctenT]").each(function () {
                grandTotalOcten = grandTotalOcten + parseFloat($(this).val());
            });
            $("[id*=lbloctc]").html(grandTotalOcten.toString());
        });
    </script>

    <script type="text/javascript">
       
        $("[id*=txtdecCostCarbonNitGasT]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') { 
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                }
            } else {
                $(this).val('');
            }
            var grandTotalCostCarbonNitGas = 0;
            $("[id*=txtdecCostCarbonNitGasT]").each(function () {
                grandTotalCostCarbonNitGas = grandTotalCostCarbonNitGas + parseFloat($(this).val());
            });
            $("[id*=lblcngc]").html(grandTotalCostCarbonNitGas.toString());
        });
    </script>
       <script type="text/javascript">
       
        $("[id*=txtlubricantcost]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') { 
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                }
            } else {
                $(this).val('');
            }
            var grandTotallubc = 0;
            $("[id*=txtlubricantcost]").each(function () {
                grandTotallubc = grandTotallubc + parseFloat($(this).val());
            });
            $("[id*=lbllubc]").html(grandTotallubc.toString());
        });
    </script>
     <script type="text/javascript">
       
        $("[id*=txtdecFareBusAmountT]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') { 
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                }
            } else {
                $(this).val('');
            }
            var grandTotalbusc = 0;
            $("[id*=txtdecFareBusAmountT]").each(function () {
                grandTotalbusc = grandTotalbusc + parseFloat($(this).val());
            });
            $("[id*=lblbusc]").html(grandTotalbusc.toString());
        });
    </script>
    
    <script type="text/javascript">
       
        $("[id*=txtdecFareRickshawAmountT]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') { 
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                }
            } else {
                $(this).val('');
            }
            var grandTotalrickc = 0;
            $("[id*=txtdecFareRickshawAmountT]").each(function () {
                grandTotalrickc = grandTotalrickc + parseFloat($(this).val());
            });
            $("[id*=lblrickc]").html(grandTotalrickc.toString());
        });
    </script>
      <script type="text/javascript">
       
        $("[id*=txtdecFareCNGAmountT]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') { 
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                }
            } else {
                $(this).val('');
            }
            var grandTotaltaxi = 0;
            $("[id*=txtdecFareCNGAmountT]").each(function () {
                grandTotaltaxi = grandTotaltaxi + parseFloat($(this).val());
            });
            $("[id*=lbltaxic]").html(grandTotaltaxi.toString());
        });
    </script>
    <script type="text/javascript">
       
        $("[id*=txtdecFareTrainAmountT]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') { 
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                }
            } else {
                $(this).val('');
            }
            var grandTotaltrain = 0;
            $("[id*=txtdecFareTrainAmountT]").each(function () {
                grandTotaltrain = grandTotaltrain + parseFloat($(this).val());
            });
            $("[id*=lbltrainc]").html(grandTotaltrain.toString());
        });
    </script>
     <script type="text/javascript">
       
        $("[id*=txtdecFareBoatT]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') { 
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                }
            } else {
                $(this).val('');
            }
            var grandTotalboat = 0;
            $("[id*=txtdecFareBoatT]").each(function () {
                grandTotalboat = grandTotalboat + parseFloat($(this).val());
            });
            $("[id*=lblboatc]").html(grandTotalboat.toString());
        });
    </script>
      <script type="text/javascript">
       
        $("[id*=txtdecFareAirPlaneT]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') { 
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                }
            } else {
                $(this).val('');
            }
            var grandTotalair = 0;
            $("[id*=txtdecFareAirPlaneT]").each(function () {
                grandTotalair = grandTotalair + parseFloat($(this).val());
            });
            $("[id*=lblairpc]").html(grandTotalair.toString());
        });
    </script>
      <script type="text/javascript">
       
        $("[id*=txtdecFareOtherVheicleAmountT]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') { 
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                }
            } else {
                $(this).val('');
            }
            var grandTotalothvc = 0;
            $("[id*=txtdecFareOtherVheicleAmountT]").each(function () {
                grandTotalothvc = grandTotalothvc + parseFloat($(this).val());
            });
            $("[id*=lblothvc]").html(grandTotalothvc.toString());
        });
    </script>
    <script type="text/javascript">
       
        $("[id*=txtdecCostAmountMaintenaceT]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') { 
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                }
            } else {
                $(this).val('');
            }
            var grandTotalmntcc = 0;
            $("[id*=txtdecCostAmountMaintenaceT]").each(function () {
                grandTotalmntcc = grandTotalmntcc + parseFloat($(this).val());
            });
            $("[id*=lblmntcc]").html(grandTotalmntcc.toString());
        });
    </script>
    <script type="text/javascript">
       
        $("[id*=txtdecFeryTollCostT]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') { 
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                }
            } else {
                $(this).val('');
            }
            var grandTotalferyc = 0;
            $("[id*=txtdecFeryTollCostT]").each(function () {
                grandTotalferyc = grandTotalferyc + parseFloat($(this).val());
            });
            $("[id*=lblferyc]").html(grandTotalferyc.toString());
        });
    </script>
    <script type="text/javascript">
       
        $("[id*=txtdecDAAmountT]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') { 
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                }
            } else {
                $(this).val('');
            }
            var grandTotalowndc = 0;
            $("[id*=txtdecDAAmountT]").each(function () {
                grandTotalowndc = grandTotalowndc + parseFloat($(this).val());
            });
            $("[id*=lblowndc]").html(grandTotalowndc.toString());
        });
    </script>
    <script type="text/javascript">
       
        $("[id*=txtdecDriverDACostT]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') { 
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                }
            } else {
                $(this).val('');
            }
            var grandTotaldrvdc = 0;
            $("[id*=txtdecDriverDACostT]").each(function () {
                grandTotaldrvdc = grandTotaldrvdc + parseFloat($(this).val());
            });
            $("[id*=lbldrivc]").html(grandTotaldrvdc.toString());
        });
    </script>
    <script type="text/javascript">
       
        $("[id*=txtdecHotelBillAmountT]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') { 
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                }
            } else {
                $(this).val('');
            }
            var grandTotaldrvdc = 0;
            $("[id*=txtdecHotelBillAmountT]").each(function () {
                grandTotaldrvdc = grandTotaldrvdc + parseFloat($(this).val());
            });
            $("[id*=lblownhc]").html(grandTotaldrvdc.toString());
        });
    </script>

    <script type="text/javascript">
       
        $("[id*=txtdecDriverHotelBillAmountT]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') { 
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                }
            } else {
                $(this).val('');
            }
            var grandTotaldrihc = 0;
            $("[id*=txtdecDriverHotelBillAmountT]").each(function () {
                grandTotaldrihc = grandTotaldrihc + parseFloat($(this).val());
            });
            $("[id*=lbldrihc]").html(grandTotaldrihc.toString());
        });
    </script>

    <script type="text/javascript">
       
        $("[id*=txtdecPhotoCopyCostT]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') { 
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                }
            } else {
                $(this).val('');
            }
            var grandTotalphotc = 0;
            $("[id*=txtdecPhotoCopyCostT]").each(function () {
                grandTotalphotc = grandTotalphotc + parseFloat($(this).val());
            });
            $("[id*=lblphotc]").html(grandTotalphotc.toString());
        });
    </script>

     <script type="text/javascript">
       
        $("[id*=txtdecCourierCostT]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') { 
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                }
            } else {
                $(this).val('');
            }
            var grandTotalcourc = 0;
            $("[id*=txtdecCourierCostT]").each(function () {
                grandTotalcourc = grandTotalcourc + parseFloat($(this).val());
            });
            $("[id*=lblcourc]").html(grandTotalcourc.toString());
        });
    </script>
     <script type="text/javascript">
       
        $("[id*=txtdecOtherBillAmountT]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') { 
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                }
            } else {
                $(this).val('');
            }
            var grandTotalother = 0;
            $("[id*=txtdecOtherBillAmountT]").each(function () {
                grandTotalother = grandTotalother + parseFloat($(this).val());
            });
            $("[id*=lblothec]").html(grandTotalother.toString());
        });
    </script>
    
     <script type="text/javascript">
       
        $("[id*=txtdecRowTotalT]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') { 
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                }
            } else {
                $(this).val('');
            }
            var grandrowtotal = 0;
            $("[id*=txtdecRowTotalT]").each(function () {
                grandrowtotal = grandrowtotal + parseFloat($(this).val());
            });
            $("[id*=lblrowtotal]").html(grandrowtotal.toString());
        });
    </script>

     <script type="text/javascript">
       
        $("[id*=txtdecSupplierCNG]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') { 
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                }
            } else {
                $(this).val('');
            }
            var grandTotalsupplier = 0;
            $("[id*=txtdecSupplierCNG]").each(function () {
                grandTotalsupplier = grandTotalsupplier + parseFloat($(this).val());
            });
            $("[id*=lblsupplierCNG]").html(grandTotalsupplier.toString());
        });
    </script>
    
     <script type="text/javascript">
       
        $("[id*=txtdecSupplierGas]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') { 
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                }
            } else {
                $(this).val('');
            }
            var grandTotalsupplierGAS = 0;
            $("[id*=txtdecSupplierGas]").each(function () {
                grandTotalsupplierGAS = grandTotalsupplierGAS + parseFloat($(this).val());
            });
            $("[id*=lblsupplierGAS]").html(grandTotalsupplierGAS.toString());
        });
    </script>

      <script type="text/javascript">
       
        $("[id*=txtdecQntPetrolT]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') { 
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                }
            } else {
                $(this).val('');
            }
            var grandTotalqntpetr = 0;
            $("[id*=txtdecQntPetrolT]").each(function () {
                grandTotalqntpetr = grandTotalqntpetr + parseFloat($(this).val());
            });
            $("[id*=lblqntpetr]").html(grandTotalqntpetr.toString());
        });
    </script>

      <script type="text/javascript">
       
        $("[id*=txtdecQntOctenT]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') { 
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                }
            } else {
                $(this).val('');
            }
            var grandTotalqntoct = 0;
            $("[id*=txtdecQntOctenT]").each(function () {
                grandTotalqntoct = grandTotalqntoct + parseFloat($(this).val());
            });
            $("[id*=lbloctq]").html(grandTotalqntoct.toString());
        });
    </script>

      <script type="text/javascript">
       
        $("[id*=txtdecQntCarbonNitGasT]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') { 
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                }
            } else {
                $(this).val('');
            }
            var grandTotalqntcarbonnitg = 0;
            $("[id*=txtdecQntCarbonNitGasT]").each(function () {
                grandTotalqntcarbonnitg = grandTotalqntcarbonnitg + parseFloat($(this).val());
            });
            $("[id*=lblcngq]").html(grandTotalqntcarbonnitg.toString());
        });
    </script>

     <script type="text/javascript">
       
        $("[id*=txtdecQntLubricant]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') { 
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                }
            } else {
                $(this).val('');
            }
            var grandTotalqntlub = 0;
            $("[id*=txtdecQntLubricant]").each(function () {
                grandTotalqntlub = grandTotalqntlub + parseFloat($(this).val());
            });
            $("[id*=lbllubq]").html(grandTotalqntlub.toString());
        });
    </script>

</head>
<body>
    <form id="frmpdv" runat="server">
  <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>





<%--=========================================Start My Code From Here===============================================--%>
          <div id="divcontentholder">
        <table class="tbldecoration" style="width:auto; float:left;">
        <tr class="tblheader"><td colspan="4"> Employee base Detaills :<asp:HiddenField ID="hdnSeprationID" runat="server" /><asp:HiddenField ID="hdnconfirm" runat="server" /></td></tr>
            <tr class="tblroweven">
                <td><asp:Label ID="lblName" runat="server" Text="Name"></asp:Label></td>
                <td ><asp:TextBox ID="txtName" BackColor="#ffffcc" runat="server"></asp:TextBox></td>
                <td><asp:Label ID="dsg" runat="server" Text="Designation"></asp:Label></td>
                <td><asp:TextBox ID="textDesg" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lblDepartment" runat="server" Text="Dept."></asp:Label></td>
                <td><asp:TextBox ID="txtDept" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lbLastMonthAudit" runat="server" Text="LM Bill"></asp:Label></td>
                <td><asp:TextBox ID="txtLMbILL" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lblCMBill" runat="server" Text="CM Bill"></asp:Label></td>
                <td><asp:TextBox ID="txtcmbill" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lblIdealMilage" runat="server" Text="Ideal Milage"></asp:Label></td>
                <td><asp:TextBox ID="txtIdealMilage" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lblConsMilage" runat="server" Text="Cons Milge"></asp:Label></td>
                <td><asp:TextBox ID="txtConsMilage" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lblQnt" runat="server" Text="Qnt"></asp:Label></td>
                <td><asp:TextBox ID="txtQnt" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
             </tr>
             <tr class="tblrowodd">
                
                
                <td><asp:Label ID="lblRatio" runat="server" Text="Cons Ratio"></asp:Label></td>
                <td><asp:TextBox ID="txtRation" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lblPresentDay" runat="server" Text="Present"></asp:Label></td>
                <td><asp:TextBox ID="txtPresent" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lblBillday" runat="server" Text="Bill day"></asp:Label></td>
                <td><asp:TextBox ID="txtBillday" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lblEnrol" runat="server" Text="Enrol"></asp:Label></td>
                <td><asp:TextBox ID="txtEnrol" BackColor="#ffffcc" ReadOnly="true"  runat="server"></asp:TextBox></td>
               
                  <td><asp:Label ID="lblJobstation" runat="server" Text="Jobstationid"></asp:Label></td>
                 <td><asp:TextBox ID="txtJobstation" BackColor="#ffffcc" ReadOnly="true"  runat="server"></asp:TextBox></td>

                  <td><asp:Label ID="lblUnit" runat="server" Text="Unitid"></asp:Label></td>
                <td><asp:TextBox ID="txtUnitID" BackColor="#ffffcc"  ReadOnly="true" runat="server"></asp:TextBox></td>

                <td><asp:Button ID="btnSubmitSingleEmployee" runat="server" Text="Approve" BackColor="#ffcc99" OnClientClick = "Confirm()" OnClick="btnSubmitSingleEmployee_Click" /></td>
            </tr>
                
            
            
            </div>
        
        
        
        
        
        
          <div class="leaveApplication_container"> 
                 <table>
              
          <tr class="tblroweven"><td>
              </td>
         </tr>          
        
            <tr class="tblrowOdd" >
             <td>
                 <asp:GridView ID="grdvForApproveTADAByImmdediatesupervisor" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="3000" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" HeaderStyle-Wrap="true" OnRowDataBound="grdvForApproveTADAByImmdediatesupervisor_RowDataBound" ShowFooter="true" OnSelectedIndexChanged="grdvForApproveTADAByImmdediatesupervisor_SelectedIndexChanged">
                     <Columns>
                       
  <asp:BoundField DataField="Id" HeaderText="Sl" SortExpression="intid" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

  <asp:TemplateField HeaderText="From Date" SortExpression="dteFromDate">
                    <ItemTemplate>
                     <asp:HiddenField   ID="hdBillDate"   runat="server" Value='<%# Bind("dteFromdate", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="dteFromdateNoBikeDet"   CssClass="txtBox" runat="server" Width="75px" TextMode="Date"  Text='<%# Bind("dteFromdate") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

 <asp:TemplateField HeaderText="Inst. Date" SortExpression="dteToDate">
                    <ItemTemplate>
                     <asp:HiddenField   ID="hdInsdate"   runat="server" Value='<%# Bind("dtIns", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="dteInsdateNoBikeDet"  CssClass="txtBox" runat="server" Width="75px" TextMode="Date"  Text='<%# Bind("dtIns") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>
 <asp:TemplateField HeaderText="Employee  Name" SortExpression="strEmplName">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdEmpName" runat="server"  Value='<%# Bind("strNam", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="strNamNoBikeDet" CssClass="txtBox" runat="server" Width="75px" TextMode="SingleLine" Text='<%# Bind("strNam") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

 <asp:TemplateField HeaderText="Designation" SortExpression="strDesignation">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdDesignation" runat="server"  Value='<%# Bind("strDesg", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="strDesgNoBikeDet" CssClass="txtBox" runat="server" Width="75px" TextMode="SingleLine" Text='<%# Bind("strDesg") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


 <asp:TemplateField HeaderText="Start Time" SortExpression="decstartt">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdstarttime" runat="server"  Value='<%# Bind("decStartTimeT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtStarTime" CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decStartTimeT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>

 <asp:TemplateField HeaderText="End Time" SortExpression="decdecEndHourT">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdEndHour" runat="server"  Value='<%# Bind("decEndHourT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecEndHourT" CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decEndHourT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>

 <asp:TemplateField HeaderText="Duration" SortExpression="decMov">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdMovedur" runat="server"  Value='<%# Bind("decMovementDurationT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecmovdur" CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decMovementDurationT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>

 <asp:TemplateField HeaderText="From  Address" SortExpression="strFromAdr">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdfromadr" runat="server"  Value='<%# Bind("strFromAddressT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtstrFromAddressT" CssClass="txtBox" runat="server" Width="100px" TextMode="SingleLine" Text='<%# Bind("strFromAddressT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                     </asp:TemplateField>

<asp:TemplateField HeaderText="Movem spots" SortExpression="strmovmentspot">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdMovementspots" runat="server"  Value='<%# Bind("strMovementAreaT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtstrMovementAreaT" CssClass="txtBox" runat="server" Width="100px" TextMode="SingleLine" Text='<%# Bind("strMovementAreaT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                     </asp:TemplateField>




 <asp:TemplateField HeaderText="To      Address" SortExpression="strToAdr">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdToAdr" runat="server"  Value='<%# Bind("strToAddressT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtstrToAddressT" CssClass="txtBox" runat="server" Width="100px" TextMode="SingleLine" Text='<%# Bind("strToAddressT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                     </asp:TemplateField>

<asp:TemplateField HeaderText="Night    Stay" SortExpression="strNight">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdNightstay" runat="server"  Value='<%# Bind("strNightStayT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtstrNightStayT" CssClass="txtBox" runat="server" Width="50px" TextMode="SingleLine" Text='<%# Bind("strNightStayT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>


 <asp:TemplateField HeaderText="start  Milage" SortExpression="decstarmil">
                    <ItemTemplate>

                     <asp:HiddenField  ID="hdstartmilage"  runat="server" Value='<%# Bind("decStartMilageT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecStartMilageT"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decStartMilageT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>
                      
    <asp:TemplateField HeaderText="End  Milage" SortExpression="decEndmil">
    <ItemTemplate>
    <asp:HiddenField  ID="hdEndmilage" runat="server" Value='<%# Bind("decEndMilageT", "{0:0.0}") %>'></asp:HiddenField>
    <asp:TextBox ID="txtdecEndMilageT"   CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decEndMilageT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="75px" />
    </asp:TemplateField>


    <asp:TemplateField HeaderText="Consumed  km" SortExpression="consumedkm">
    <ItemTemplate>
    <asp:HiddenField  ID="hdConsumedkm" runat="server" Value='<%# Bind("decConsumedKmT", "{0:0.0}") %>'></asp:HiddenField>
    <asp:TextBox ID="txtdecConsumedKmT"   CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decConsumedKmT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="75px" />
    </asp:TemplateField>


    <asp:TemplateField HeaderText="Supporting" SortExpression="strsuppor">

    <ItemTemplate>
    <asp:HiddenField  ID="hdstrsuppor" runat="server" Value='<%# Bind("strSupportingNoT", "{0:0.0}") %>'></asp:HiddenField>
    <asp:TextBox ID="txtstrSupportingNoT"  CssClass="txtBox" runat="server" Width="75px" TextMode="MultiLine" Text='<%# Bind("strSupportingNoT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="75px" />
    </asp:TemplateField>


    <asp:TemplateField HeaderText="QntPet" SortExpression="decpet">
    <ItemTemplate>

    <asp:HiddenField  ID="hdQpetr"  runat="server" Value='<%# Bind("decQntPetrolT", "{0:0.0}") %>'></asp:HiddenField>
    <asp:TextBox ID="txtdecQntPetrolT"   CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decQntPetrolT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="50px" />
     <FooterTemplate><asp:Label ID="lblqntpetr" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate>
    </asp:TemplateField>
                     
    <asp:TemplateField HeaderText="CostPet" SortExpression="costpet">
    <ItemTemplate>
    <asp:HiddenField  ID="hdnCostpetr" runat="server" Value='<%# Bind("decCostPetrolT", "{0:0.0}") %>'></asp:HiddenField>
    <asp:TextBox ID="txtdecCostPetrolT"    CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decCostPetrolT") %>'></asp:TextBox></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="50px" />
    <FooterTemplate><asp:Label ID="lblGTCostpetr" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate>
    </asp:TemplateField>


    <asp:TemplateField HeaderText="QntOct" SortExpression="decQntOcten">
    <ItemTemplate>
    <asp:HiddenField  ID="hdQntOcten" runat="server" Value='<%# Bind("decQntOctenT", "{0:0.0}") %>'></asp:HiddenField>
    <asp:TextBox ID="txtdecQntOctenT"   CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decQntOctenT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="50px" />
    <FooterTemplate><asp:Label ID="lbloctq" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate>
    </asp:TemplateField>

                     <asp:TemplateField HeaderText="CosOct" SortExpression="decCostOcten">
                     <ItemTemplate>
                     <asp:HiddenField  ID="hdCostocte" runat="server" Value='<%# Bind("decCostOctenT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecCostOctenT"  CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decCostOctenT") %>'></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                         <FooterTemplate><asp:Label ID="lbloctc" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate>
                     </asp:TemplateField>

   
                      <asp:TemplateField HeaderText="QntCNG" SortExpression="decQntCNG">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdQCNG" runat="server" Value='<%# Bind("decQntCarbonNitGasT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecQntCarbonNitGasT"  CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decQntCarbonNitGasT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                          <FooterTemplate><asp:Label ID="lblcngq" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate>
                     </asp:TemplateField>

                        <asp:TemplateField HeaderText="CosCNG." SortExpression="CostCNG">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdCostcng" runat="server" Value='<%# Bind("decCostCarbonNitGasT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecCostCarbonNitGasT"   CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decCostCarbonNitGasT") %>' ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                            <FooterTemplate><asp:Label ID="lblcngc" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate>
                     </asp:TemplateField>


                    <asp:TemplateField HeaderText="QntLub" SortExpression="decQntLubricant">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdQlubricantt" runat="server" Value='<%# Bind("decLubricantQnt", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecQntLubricant"  CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decLubricantQnt") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                        <FooterTemplate><asp:Label ID="lbllubq" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate>
                     </asp:TemplateField>

                        <asp:TemplateField HeaderText="CosLub" SortExpression="decCostLubricant">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdCostLubricant" runat="server" Value='<%# Bind("lubricantcost", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtlubricantcost"   CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("lubricantcost") %>'></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                             <FooterTemplate><asp:Label ID="lbllubc" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate>
                     </asp:TemplateField>

                   <asp:TemplateField HeaderText="BusFar" SortExpression="decBus">
                    <ItemTemplate> <asp:HiddenField  ID="hdBus"  runat="server" Value='<%# Bind("decFareBusAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFareBusAmountT"    CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decFareBusAmountT") %>'></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                        <FooterTemplate><asp:Label ID="lblbusc" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate>
                     </asp:TemplateField>
                      
                          <asp:TemplateField HeaderText="RickFa" SortExpression="decRick">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdnRick" runat="server" Value='<%# Bind("decFareRickshawAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFareRickshawAmountT"    CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decFareRickshawAmountT") %>' ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                               <FooterTemplate><asp:Label ID="lblrickc" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate>
                     </asp:TemplateField>


                    <asp:TemplateField HeaderText="TaxiCab" SortExpression="decTaxiCab">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdtaxicab" runat="server" Value='<%# Bind("decFareCNGAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFareCNGAmountT"  CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decFareCNGAmountT") %>'></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                         <FooterTemplate><asp:Label ID="lbltaxic" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate>
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="TrainF" SortExpression="decTrain">
                     <ItemTemplate>
                     <asp:HiddenField  ID="hdTrain" runat="server" Value='<%# Bind("decFareTrainAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFareTrainAmountT"    CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decFareTrainAmountT") %>'></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                          <FooterTemplate><asp:Label ID="lbltrainc" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate>
                     </asp:TemplateField>

                      <asp:TemplateField HeaderText="BoatF" SortExpression="decFareBoatT">
                     <ItemTemplate>
                     <asp:HiddenField  ID="hdBoat" runat="server" Value='<%# Bind("decFareBoatT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFareBoatT"    CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decFareBoatT") %>'></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                           <FooterTemplate><asp:Label ID="lblboatc" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate>
                     </asp:TemplateField>


                        

                      <asp:TemplateField HeaderText="AirPla" SortExpression="decAirPlane">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdPlane" runat="server" Value='<%# Bind("decFareAirPlaneT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFareAirPlaneT"  CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decFareAirPlaneT") %>'></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                           <FooterTemplate><asp:Label ID="lblairpc" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate>
                     </asp:TemplateField>

                        <asp:TemplateField HeaderText="OthVh." SortExpression="decOtherVhc">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdothevh" runat="server" Value='<%# Bind("decFareOtherVheicleAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFareOtherVheicleAmountT"  CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decFareOtherVheicleAmountT") %>'></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                             <FooterTemplate><asp:Label ID="lblothvc" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate>
                            
                     </asp:TemplateField>

                  
           
            <asp:TemplateField HeaderText="MntCos" SortExpression="decMnt">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdMntcost" runat="server" Value='<%# Bind("decCostAmountMaintenaceT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecCostAmountMaintenaceT"   CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decCostAmountMaintenaceT") %>'></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                 <FooterTemplate><asp:Label ID="lblmntcc" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate>
                     </asp:TemplateField>

                        <asp:TemplateField HeaderText="FerryToll." SortExpression="ferytol">
                             
                              <ItemTemplate>
                     <asp:HiddenField  ID="hdoFerrytoll" runat="server" Value='<%# Bind("decFeryTollCostT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFeryTollCostT"  CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decFeryTollCostT") %>'></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                             <FooterTemplate><asp:Label ID="lblferyc" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate>
                     </asp:TemplateField>
              
                         
                         
                                   

                      <asp:TemplateField HeaderText="OwnDA." SortExpression="decownda">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddecownda" runat="server" Value='<%# Bind("decDAAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecDAAmountT"  CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decDAAmountT") %>'></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                           <FooterTemplate><asp:Label ID="lblowndc" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate>
                     </asp:TemplateField>


                       <asp:TemplateField HeaderText="Driver DA." SortExpression="decDriver">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddecOtherda" runat="server" Value='<%# Bind("decDriverDACostT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecDriverDACostT" CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decDriverDACostT") %>'></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                            <FooterTemplate><asp:Label ID="lbldrivc" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate>
                     </asp:TemplateField>

                       <asp:TemplateField HeaderText="Own Hotel" SortExpression="decownhotel">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddechotel" runat="server" Value='<%# Bind("decHotelBillAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecHotelBillAmountT"   CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decHotelBillAmountT") %>'></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                            <FooterTemplate><asp:Label ID="lblownhc" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate>
                     </asp:TemplateField>

                         <asp:TemplateField HeaderText="Driver Hotel" SortExpression="decdrivhotel">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddrivehote" runat="server" Value='<%# Bind("decDriverHotelBillAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecDriverHotelBillAmountT"  CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decDriverHotelBillAmountT") %>'></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                              <FooterTemplate><asp:Label ID="lbldrihc" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate>
                     </asp:TemplateField>

                   
                    <asp:TemplateField HeaderText="Photocopy" SortExpression="decPhotocopy">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdPhotocpy" runat="server" Value='<%# Bind("decPhotoCopyCostT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecPhotoCopyCostT"   CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decPhotoCopyCostT") %>'></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                         <FooterTemplate><asp:Label ID="lblphotc" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate>
                     </asp:TemplateField>

                         <asp:TemplateField HeaderText="Courier" SortExpression="decCourier">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddCourier" runat="server" Value='<%# Bind("decCourierCostT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecCourierCostT"   CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decCourierCostT") %>'></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                              <FooterTemplate><asp:Label ID="lblcourc" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate>
                     </asp:TemplateField>


                     
                      <asp:TemplateField HeaderText="OtherCost" SortExpression="decOtherCostAmount">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddecOtherCostAmount" runat="server" Value='<%# Bind("decOtherBillAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecOtherBillAmountT" CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decOtherBillAmountT") %>'></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                           <FooterTemplate><asp:Label ID="lblothec" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate>
                     </asp:TemplateField>

                     
                     <%--  <asp:TemplateField HeaderText="Row Total" SortExpression="decrowtotal">
                           
                              <ItemTemplate>
                     <asp:HiddenField  ID="hddecrowtotal" runat="server" Value='<%# Bind("decRowTotalT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecRowTotalT"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decRowTotalT") %>'></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>--%>
                         <asp:TemplateField HeaderText="Row Total" SortExpression="decrowtotal">

                    <ItemTemplate>
                    <asp:HiddenField  ID="hddecrowtotal" runat="server" Value='<%# Bind("decRowTotalT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecRowTotalT"  CssClass="txtBox" runat="server" Width="35px"  Text='<%# Bind("decRowTotalT") %>'  ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                               <FooterTemplate><asp:Label ID="lblrowtotal" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate>
                    </asp:TemplateField>

                        <asp:TemplateField HeaderText="Supplier CNG" SortExpression="decSupplierCNG">
                            
                              <ItemTemplate>
                     <asp:HiddenField  ID="hdndecSupplierCNG" runat="server" Value='<%# Bind("decSupplierCNG", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecSupplierCNG" OnTextChanged="txtdecSupplierCNG_TextChanged" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decSupplierCNG") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                              <FooterTemplate><asp:Label ID="lblsupplierCNG" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate>
                     </asp:TemplateField>

                     
                   <asp:TemplateField HeaderText="Supplier Gas" SortExpression="decSupplierGas">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdndecSupplierGas" runat="server" Value='<%# Bind("decSupplierGas", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecSupplierGas" OnTextChanged="txtdecSupplierGas_TextChanged" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decSupplierGas") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                        <FooterTemplate><asp:Label ID="lblsupplierGAS" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate>
                     </asp:TemplateField>

                   <asp:TemplateField HeaderText="Personal Milage" SortExpression="decPersonalMilage">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdndecPersonalMilage" runat="server" Value='<%# Bind("decPersonalMilage", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecPersonalMilage" OnTextChanged="txtdecPersonalMilage_TextChanged" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decPersonalMilage") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>
                         

                  <asp:TemplateField HeaderText="Milage Rate" SortExpression="decMlgRate">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdndecMlgRate" runat="server" Value='<%# Bind("decMlgRate", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecMlgRate" OnTextChanged="txtdecMlgRate_TextChanged" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decMlgRate") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                         
                    


                         <asp:TemplateField HeaderText="PMlag Total" SortExpression="decPersonalTotalcost">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdndecPersonalTotalcost" runat="server" Value='<%# Bind("decPersonalTotalcost", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecPersonalTotalcost" OnTextChanged="txtdecPersonalTotalcost_TextChanged" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decPersonalTotalcost") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                          <asp:TemplateField HeaderText="PayType" SortExpression="PaymentType">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdnPaymentType" runat="server" Value='<%# Bind("PaymentType", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtPaymentType" OnTextChanged="txtPaymentType_TextChanged" CssClass="txtBox" runat="server" Width="50px" TextMode="SingleLine" Text='<%# Bind("PaymentType") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>
                          <asp:TemplateField HeaderText="Det.">
             <ItemTemplate>
             <asp:Button ID="CompleteAttachment" runat="server" Text="Attachment" class="button" CommandName="complete" OnClick="CompleteAttachment_Click"  CommandArgument='<%# Eval("intApplicantEnrol")+","+Eval("dteFromdate")+","+Eval("intApplicantUnit")%>' /></ItemTemplate>
             </asp:TemplateField>  
                          <asp:BoundField DataField="dteattachdate" HeaderText="UploadDate" ItemStyle-Width="400px" SortExpression="dteattachdate" DataFormatString="{0:dd-MM-yyyy}" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
                  <asp:BoundField DataField="ysnattachment" HeaderText="Attachment status" SortExpression="ysnattachment" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
                     
                          <asp:TemplateField HeaderText="Fuel Station" SortExpression="strFuelStationaname">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdnstrFuelStationaname" runat="server" Value='<%# Bind("strFuelStationaname", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtstrFuelStationaname" OnTextChanged="txtstrFuelStationaname_TextChanged" CssClass="txtBox" runat="server" Width="75px" TextMode="MultiLine" Text='<%# Bind("strFuelStationaname") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>
                          
                         <asp:BoundField DataField="intApplicantEnrol" HeaderText="Enrol" SortExpression="intApplicantEnrol" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
                <asp:BoundField DataField="intApplicantUnit" HeaderText="unit" SortExpression="intApplicantUnit" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
                        
                        

                     </Columns>
                     <FooterStyle BackColor="#CCCCCC" />
                     <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                     <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                     <RowStyle BackColor="White" />
                     <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                     <SortedAscendingCellStyle BackColor="#F1F1F1" />
                     <SortedAscendingHeaderStyle BackColor="#808080" />
                     <SortedDescendingCellStyle BackColor="#CAC9C9" />
                     <SortedDescendingHeaderStyle BackColor="#383838" />
                     <HeaderStyle CssClass="GridviewScrollHeader" /><PagerStyle CssClass="GridviewScrollPager" />
                 </asp:GridView>
             </td>
             
         </tr>  
 </table>
 </div>


    <%--=========================================End My Code From Here=================================================--%>
<%--  </ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>  
            
            
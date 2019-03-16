<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetTransaction.aspx.cs" Inherits="UI.Asset.AssetTransaction" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
 <html xmlns="http://www.w3.org/1999/xhtml">   
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
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>

    <script type="text/javascript"> 
         function OpenHdnDiv() {
             $("#hdnDivision").fadeIn("slow");
             document.getElementById('hdnDivision').style.visibility = 'visible';
         }

         function ClosehdnDivision() {

             $("#hdnDivision").fadeOut("slow");
         }

         function OpenHdnDivDisposal() {
             $("#hdnDivisionDisposal").fadeIn("slow");
             document.getElementById('hdnDivisionDisposal').style.visibility = 'visible';
         }

         function ClosehdnDisposal() {

             $("#hdnDivisionDisposal").fadeOut("slow");
         }

         function OpenHdnRevDiv() {
             $("#hdnDivisionRevalution").fadeIn("slow");
             document.getElementById('hdnDivisionRevalution').style.visibility = 'visible';
         }

         function CloseHdnRevDiv() {

             $("#hdnDivisionRevalution").fadeOut("slow");
         }

         function OpenHdnReclassDiv() {
             $("#hdnDivisionReClasification").fadeIn("slow");
             document.getElementById('hdnDivisionReClasification').style.visibility = 'visible';
         }

         function CloseHdnReclassDiv() {

             $("#hdnDivisionReClasification").fadeOut("slow");
         }

         function OpenHdnSaleDiv() {
             $("#hdnDivisionSale").fadeIn("slow");
             document.getElementById('hdnDivisionSale').style.visibility = 'visible';
         }

         function CloseHdnSaleDiv() {

             $("#hdnDivisionSale").fadeOut("slow");
        }

         function Clasification() { 
            
            var e = document.getElementById("ddlReAssetType");
            var type = e.options[e.selectedIndex].value;
            var e = document.getElementById("ddlReMejorCat");
            var majorcat = e.options[e.selectedIndex].value;
            var e = document.getElementById("ddlReMinorCat1");
            var minorcat1 = e.options[e.selectedIndex].value;
            var e = document.getElementById("ddlRemonorCat2");
            var minorcat2 = e.options[e.selectedIndex].value;

             var e = document.getElementById("ddlReCostCenter");
            var costcenter = e.options[e.selectedIndex].value;
            
            var dtedate = document.getElementById("txtReDate").value;
            

            if ($.trim(type).length < 1 ||
                $.trim(type) == "" ||
                $.trim(type) == null ||
                $.trim(type) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please select asset type');
                return false
            }
            else if ($.trim(majorcat).length ==0 ||
                $.trim(majorcat) == "" ||
                $.trim(majorcat) == null ||
                $.trim(majorcat) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please SelectMajor Category');
                return false
            }
            else if ($.trim(minorcat1) == 0 ||
                $.trim(minorcat1) == "" ||
                $.trim(minorcat1) == null ||
                $.trim(minorcat1) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please select Minor Category 1');
                return false
            }
            
            else if ($.trim(costcenter) == 0 ||
                $.trim(costcenter) == "" ||
                $.trim(costcenter) == null ||
                $.trim(costcenter) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please Select Cost Center');
                return false
            }
            else if ($.trim(dtedate) == 0 ||
                $.trim(dtedate) == "" ||
                $.trim(dtedate) == null ||
                $.trim(dtedate) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  se Date');
                return false
            } 
            
            else {
                var confirmValue = document.createElement("INPUT");
                confirmValue.type = "hidden";
                confirmValue.name = "confirm_value";
                if (confirm("Do you want to proceed?")) {
                    confirmValue.value = "Yes";
                    document.getElementById("hdnPreConfirm").value = "1";
                } else {
                    confirmValue.value = "No";
                    document.getElementById("hdnPreConfirm").value = "0";
                    return false
                }
                return true 
            } 
        }
        
        function Transfer() { 
            
            var e = document.getElementById("ddlTrnsUnit");
            var unit = e.options[e.selectedIndex].value;
            var e = document.getElementById("ddlTrnsJobstation");
            var job = e.options[e.selectedIndex].value;
            var e = document.getElementById("ddlTrnsAssetType");
            var type = e.options[e.selectedIndex].value;
            var e = document.getElementById("ddlTrnsMajorCat");
            var majorcat = e.options[e.selectedIndex].value;

             var e = document.getElementById("ddlTrnsMinorCat1");
            var minorcat1 = e.options[e.selectedIndex].value;

            var e = document.getElementById("ddlTrnsCostCenter");
            var costcenter = e.options[e.selectedIndex].value;
            
            var asetname = document.getElementById("txtTrnsAssetName").value;  

            if ($.trim(unit).length < 1 ||
                $.trim(unit) == "" ||
                $.trim(unit) == null ||
                $.trim(unit) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please select Transfer Unit ');
                return false
            }
            else if ($.trim(job).length ==0 ||
                $.trim(job) == "" ||
                $.trim(job) == null ||
                $.trim(job) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please Select Transfer Jobstation');
                return false
            }
            else if ($.trim(type) == 0 ||
                $.trim(type) == "" ||
                $.trim(type) == null ||
                $.trim(type) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please select Type');
                return false
            }
            else if ($.trim(majorcat) == 0 ||
                $.trim(majorcat) == "" ||
                $.trim(majorcat) == null ||
                $.trim(majorcat) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please select Major Category');
                return false
            }
            else if ($.trim(minorcat1) == 0 ||
                $.trim(minorcat1) == "" ||
                $.trim(minorcat1) == null ||
                $.trim(minorcat1) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please Select Minor Category 1');
                return false
            }
            else if ($.trim(costcenter) == 0 ||
                $.trim(costcenter) == "" ||
                $.trim(costcenter) == null ||
                $.trim(costcenter) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  select Cost Center');
                return false
            } 
             else if ($.trim(asetname) <3 ||
                $.trim(asetname) == "" ||
                $.trim(asetname) == null ||
                $.trim(asetname) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  Set Asset Name');
                return false
            } 
            
            else {
                var confirmValue = document.createElement("INPUT");
                confirmValue.type = "hidden";
                confirmValue.name = "confirm_value";
                if (confirm("Do you want to proceed?")) {
                    confirmValue.value = "Yes";
                    document.getElementById("hdnPreConfirm").value = "1";
                } else {
                    confirmValue.value = "No";
                    document.getElementById("hdnPreConfirm").value = "0";
                    return false
                }
                return true 
            } 
        }

        function Disposal() { 
            
            var e = document.getElementById("ddlDispoUnit");
            var unit = e.options[e.selectedIndex].value;
            var e = document.getElementById("ddlDispoJobstation");
            var job = e.options[e.selectedIndex].value;
            var e = document.getElementById("ddlDispoAssetType");
            var type = e.options[e.selectedIndex].value;
            var e = document.getElementById("ddlDispoMejorCat");
            var majorcat = e.options[e.selectedIndex].value;

             var e = document.getElementById("ddlDispoMonorCat1");
            var minorcat1 = e.options[e.selectedIndex].value;

            var e = document.getElementById("ddlDispoCostCenter");
            var costcenter = e.options[e.selectedIndex].value; 
            
            var asetname = document.getElementById("txtDispoAssetName").value;  
            var disreff = document.getElementById("txtDispoReff").value;  
            var disdate = document.getElementById("txtDispoDate").value;  
            var remarks = document.getElementById("txtDispoRemarks").value;  
            var totaldep = document.getElementById("txtDispoTotalDep").value;  
            var totalcost = document.getElementById("txtDispoTotalCost").value; 
            var capitallos = document.getElementById("txtDispoCapitalLoss").value; 


            if ($.trim(unit).length < 1 ||
                $.trim(unit) == "" ||
                $.trim(unit) == null ||
                $.trim(unit) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please select Transfer Unit ');
                return false
            }
            else if ($.trim(job).length ==0 ||
                $.trim(job) == "" ||
                $.trim(job) == null ||
                $.trim(job) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please Select Transfer Jobstation');
                return false
            }
            else if ($.trim(type) == 0 ||
                $.trim(type) == "" ||
                $.trim(type) == null ||
                $.trim(type) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please select Type');
                return false
            }
            else if ($.trim(majorcat) == 0 ||
                $.trim(majorcat) == "" ||
                $.trim(majorcat) == null ||
                $.trim(majorcat) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please select Major Category');
                return false
            }
            else if ($.trim(minorcat1) == 0 ||
                $.trim(minorcat1) == "" ||
                $.trim(minorcat1) == null ||
                $.trim(minorcat1) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please Select Minor Category 1');
                return false
            }
            else if ($.trim(costcenter) == 0 ||
                $.trim(costcenter) == "" ||
                $.trim(costcenter) == null ||
                $.trim(costcenter) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  select Cost Center');
                return false
            } 
             else if ($.trim(asetname) <3 ||
                $.trim(asetname) == "" ||
                $.trim(asetname) == null ||
                $.trim(asetname) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  Set Asset Name');
                return false
            } 
            else if ($.trim(disreff) <3 ||
                $.trim(disreff) == "" ||
                $.trim(disreff) == null ||
                $.trim(disreff) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  Set Disposal Referance No');
                return false
            } 
                else if ($.trim(disdate) <3 ||
                $.trim(disdate) == "" ||
                $.trim(disdate) == null ||
                $.trim(disdate) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  Set Disposal Date');
                return false
            } 
                else if ($.trim(remarks) <3 ||
                $.trim(remarks) == "" ||
                $.trim(remarks) == null ||
                $.trim(remarks) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  Set Remarks');
                return false
            } 
            //    else if ($.trim(totaldep) <3 ||
            //    $.trim(totaldep) == "" ||
            //    $.trim(totaldep) == null ||
            //    $.trim(totaldep) == undefined) {
            //    document.getElementById("hdnPreConfirm").value = "0";
            //    alert('Please  Set Total Depreciation');
            //    return false
            //} 
                else if ($.trim(totalcost) <3 ||
                $.trim(totalcost) == "" ||
                $.trim(totalcost) == null ||
                $.trim(totalcost) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  Set Asset Total Cost');
                return false
            } 
                else if ($.trim(capitallos) ==0 ||
                $.trim(capitallos) == "" ||
                $.trim(capitallos) == null ||
                $.trim(capitallos) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  Set Capital Loss');
                return false
            } 
            else {
                var confirmValue = document.createElement("INPUT");
                confirmValue.type = "hidden";
                confirmValue.name = "confirm_value";
                if (confirm("Do you want to proceed?")) {
                    confirmValue.value = "Yes";
                    document.getElementById("hdnPreConfirm").value = "1";
                } else {
                    confirmValue.value = "No";
                    document.getElementById("hdnPreConfirm").value = "0";
                    return false
                }
                return true 
            } 
        }

        function Reviloation() { 
            
            var e = document.getElementById("ddlRevUnit");
            var unit = e.options[e.selectedIndex].value;
            var e = document.getElementById("ddlRevJobstation");
            var job = e.options[e.selectedIndex].value;
            var e = document.getElementById("ddlRevType");
            var type = e.options[e.selectedIndex].value;
            var e = document.getElementById("ddlRevMejorCat");
            var majorcat = e.options[e.selectedIndex].value; 
             var e = document.getElementById("ddlRevMinorCat1");
            var minorcat1 = e.options[e.selectedIndex].value;  

            var e = document.getElementById("ddlRevCostCenter");
            var costcenter = e.options[e.selectedIndex].value; 
            
            var asetname = document.getElementById("txtRevAssetname").value;  
            var reff = document.getElementById("txtRevReff").value;  
            var revdate = document.getElementById("txtRevDate").value;  
            var remarks = document.getElementById("txtReVRemarks").value;  
            var increse = document.getElementById("txtRevLossGain").value;  
            var totalcost = document.getElementById("txtRevTotalCost").value; 
            var fairmarket = document.getElementById("txtRevFairMarket").value; 
            var revalued = document.getElementById("txtRevalued").value; 
            var carying = document.getElementById("txtRevCarying").value; 
            var accdep = document.getElementById("txtRevAccDep").value;  

            if ($.trim(unit).length < 1 ||
                $.trim(unit) == "" ||
                $.trim(unit) == null ||
                $.trim(unit) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please select   Unit ');
                return false
            }
            else if ($.trim(job).length ==0 ||
                $.trim(job) == "" ||
                $.trim(job) == null ||
                $.trim(job) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please Select   Jobstation');
                return false
            }
            else if ($.trim(type) == 0 ||
                $.trim(type) == "" ||
                $.trim(type) == null ||
                $.trim(type) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please select Type');
                return false
            }
            else if ($.trim(majorcat) == 0 ||
                $.trim(majorcat) == "" ||
                $.trim(majorcat) == null ||
                $.trim(majorcat) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please select Major Category');
                return false
            }
            else if ($.trim(minorcat1) == 0 ||
                $.trim(minorcat1) == "" ||
                $.trim(minorcat1) == null ||
                $.trim(minorcat1) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please Select Minor Category 1');
                return false
            }
            else if ($.trim(costcenter) == 0 ||
                $.trim(costcenter) == "" ||
                $.trim(costcenter) == null ||
                $.trim(costcenter) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  select Cost Center');
                return false
            } 
             else if ($.trim(asetname) <3 ||
                $.trim(asetname) == "" ||
                $.trim(asetname) == null ||
                $.trim(asetname) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  Set Asset Name');
                return false
            } 
            else if ($.trim(reff) <3 ||
                $.trim(reff) == "" ||
                $.trim(reff) == null ||
                $.trim(reff) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  Set   Referance No');
                return false
            } 
                else if ($.trim(revdate) <3 ||
                $.trim(revdate) == "" ||
                $.trim(revdate) == null ||
                $.trim(revdate) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  Set Transection Date');
                return false
            } 
                else if ($.trim(remarks) <3 ||
                $.trim(remarks) == "" ||
                $.trim(remarks) == null ||
                $.trim(remarks) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  Set Remarks');
                return false
            } 
                else if ($.trim(increse)=="0" ||
                $.trim(increse) == "" ||
                $.trim(increse) == null ||
                $.trim(increse) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  Set increse cost');
                return false
            } 
                else if ($.trim(totalcost)=="0" ||
                $.trim(totalcost) == "" ||
                $.trim(totalcost) == null ||
                $.trim(totalcost) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  Set Asset Total Cost');
                return false
            } 

             else if ($.trim(fairmarket)=="0" ||
                $.trim(fairmarket) == "" ||
                $.trim(fairmarket) == null ||
                $.trim(fairmarket) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  Set Asset Fair Market Value');
                return false
            } 
                else if ( 
                $.trim(carying) == "" ||
                $.trim(carying) == null ||
                $.trim(carying) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  Set Asset Carying Amount');
                return false
            } 
               else if ( 
                $.trim(accdep) == "" ||
                $.trim(accdep) == null ||
                $.trim(accdep) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  Set Asset Acc Depreciation Value');
                return false
            } 
                 else if ( 
                $.trim(revalued) == "" ||
                $.trim(revalued) == null ||
                $.trim(revalued) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  Set Asset Revalued Amount');
                return false
            } 
                
            else {
                var confirmValue = document.createElement("INPUT");
                confirmValue.type = "hidden";
                confirmValue.name = "confirm_value";
                if (confirm("Do you want to proceed?")) {
                    confirmValue.value = "Yes";
                    document.getElementById("hdnPreConfirm").value = "1";
                } else {
                    confirmValue.value = "No";
                    document.getElementById("hdnPreConfirm").value = "0";
                    return false
                }
                return true 
            } 
        }

        function Sales() { 
              
            var e = document.getElementById("ddlSaleUnit");
            var unit = e.options[e.selectedIndex].value;
            var e = document.getElementById("ddlSaleJob");
            var job = e.options[e.selectedIndex].value;
            var e = document.getElementById("ddlSaleAssetType");
            var type = e.options[e.selectedIndex].value;
            var e = document.getElementById("ddlSaMajorCat");
            var majorcat = e.options[e.selectedIndex].value; 
             var e = document.getElementById("ddlSaMinorCat1");
            var minorcat1 = e.options[e.selectedIndex].value;  

            var e = document.getElementById("ddlSaCostCenter");
            var costcenter = e.options[e.selectedIndex].value; 
            
            var asetname = document.getElementById("txtSaleAssetName").value;  
            var reff = document.getElementById("txtSaReff").value;  
            var revdate = document.getElementById("txtSaDteDate").value;  
            var remarks = document.getElementById("txtSaRemarks").value;  
            var dep = document.getElementById("txtSaTotalDep").value;  
            var totalcost = document.getElementById("txtSaTotalCost").value; 
            var capital = document.getElementById("txtSaCapitalLoss").value;  
            var recieveName = document.getElementById("txtSaReceiveableName").value;  
            var coaReceuveId = document.getElementById("txtSaReceivealeID").value;  
            var salesProced = document.getElementById("txtSalesProcess").value;  


            if ($.trim(unit).length < 1 ||
                $.trim(unit) == "" ||
                $.trim(unit) == "0" ||
                $.trim(unit) == null ||
                $.trim(unit) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please select   Unit ');
                return false
            }
            else if ($.trim(job).length ==0 ||
                $.trim(job) == "" ||
                $.trim(job) == "0" ||
                $.trim(job) == null ||
                $.trim(job) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please Select   Jobstation');
                return false
            }
            else if ($.trim(type) == 0 ||
                $.trim(type) == "" ||
                $.trim(type) == null ||
                $.trim(type) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please select Type');
                return false
            }
            else if ($.trim(majorcat) == 0 ||
                $.trim(majorcat) == "" ||
                $.trim(majorcat) == null ||
                $.trim(majorcat) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please select Major Category');
                return false
            }
            else if ($.trim(minorcat1) == 0 ||
                $.trim(minorcat1) == "" ||
                $.trim(minorcat1) == null ||
                $.trim(minorcat1) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please Select Minor Category 1');
                return false
            }
            else if ($.trim(costcenter) == 0 ||
                $.trim(costcenter) == "" ||
                $.trim(costcenter) == null ||
                $.trim(costcenter) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  select Cost Center');
                return false
            } 
             else if ($.trim(asetname) <3 ||
                $.trim(asetname) == "" ||
                $.trim(asetname) == null ||
                $.trim(asetname) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  Set Asset Name');
                return false
            } 
            else if ($.trim(reff) <3 ||
                $.trim(reff) == "" ||
                $.trim(reff) == null ||
                $.trim(reff) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  Set   Referance No');
                return false
            } 
                else if ($.trim(revdate) <3 ||
                $.trim(revdate) == "" ||
                $.trim(revdate) == null ||
                $.trim(revdate) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  Set Disposal Date');
                return false
            } 
                else if ($.trim(remarks) <3 ||
                $.trim(remarks) == "" ||
                $.trim(remarks) == null ||
                $.trim(remarks) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  Set Remarks');
                return false
            } 
                else if ( 
                $.trim(dep) == "" ||
                $.trim(dep) == null ||
                $.trim(dep) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  Set Total Depreciation Value');
                return false
            } 
                else if ($.trim(totalcost) =="0" ||
                $.trim(totalcost) == "" ||
                $.trim(totalcost) == null ||
                $.trim(totalcost) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  Set Asset Total Cost');
                return false
            }
             else if ($.trim(capital)=="0" ||
                $.trim(capital) == "" ||
                $.trim(capital) == null ||
                $.trim(capital) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  Set Asset Capital Loss Cost');
                return false
            }
            else if ($.trim(recieveName).length <2 ||
                $.trim(recieveName) == "" ||
                $.trim(recieveName) == null ||
                $.trim(recieveName) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  Set Receive Name');
                return false
            }
            else if ($.trim(salesProced) < 2 ||
                $.trim(salesProced) == "" ||
                $.trim(salesProced) == null ||
                $.trim(salesProced) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  Set Sales Proceed Amount');
                return false
            }
            else if ($.trim(coaReceuveId).length < 6 ||
                $.trim(coaReceuveId) == "0" ||
                $.trim(coaReceuveId) == null ||
                $.trim(coaReceuveId) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please  Set Receive COA Account');
                return false
                }
                
            else {
                var confirmValue = document.createElement("INPUT");
                confirmValue.type = "hidden";
                confirmValue.name = "confirm_value";
                if (confirm("Do you want to proceed?")) {
                    confirmValue.value = "Yes";
                    document.getElementById("hdnPreConfirm").value = "1";
                } else {
                    confirmValue.value = "No";
                    document.getElementById("hdnPreConfirm").value = "0";
                    return false
                }
                return true 
            } 
        }

        function disDepCal() {
            var totaldep = parseFloat(document.getElementById("txtDispoTotalDep").value);  
            var totalcost = parseFloat(document.getElementById("txtDispoTotalCost").value);
            
            document.getElementById("txtDispoCapitalLoss").value = parseFloat( totaldep -totalcost)

        }

        function LossGain() {
            var fairmarket = parseFloat(document.getElementById("txtRevFairMarket").value);  
            var carying = parseFloat(document.getElementById("txtRevCarying").value); 
            var accdep = parseFloat(document.getElementById("txtRevAccDep").value);
            document.getElementById("txtRevLossGain").value = parseFloat(fairmarket - carying).toFixed(2);
            document.getElementById("txtRevalued").value = parseFloat(fairmarket - carying - accdep).toFixed(2);
        }

        function SaleLosgain() {
            var totalcost = parseFloat(document.getElementById("txtSaTotalCost").value);  
            var dep = document.getElementById("txtSaTotalDep").value; 
            var salesProced = parseFloat(document.getElementById("txtSalesProcess").value);
            document.getElementById("txtSaCapitalLoss").value = parseFloat(dep - totalcost + salesProced).toFixed(2);
        }

    </script>

     
        <style type="text/css"> 
        .rounds {
        height: 80px;
        width: 30px;
           
        -moz-border-colors:25px;
        border-radius:25px;
        } 

        .HyperLinkButtonStyle { float:right; text-align:left; border: none; background: none; 
        color: blue; text-decoration: underline; font: normal 10px verdana;} 
        .hdnDivision { background-color: #EFEFEF; position:absolute;z-index:1; visibility:hidden; border:10px double black; text-align:center;
        width:100%; height: 100%;    margin-left:100px;  margin-top:10px; margin-right:00px; padding: 15px; overflow-y:scroll; }
        </style>

    <style type="text/css"> 
        .rounds {
        height:100px;
        width: 100px;
           
        -moz-border-colors:25px;
        border-radius:25px;
        } 

        .HyperLinkButtonStyle { float:right; text-align:left; border: none; background: none; 
        color: blue; text-decoration: underline; font: normal 10px verdana;} 
        .hdnDivisionDisposal { background-color: #EFEFEF; position:absolute;z-index:1; visibility:hidden; border:10px double black; text-align:center;
        width:80%; height:80%;    margin-left:100px;  margin-top:10px; margin-right:00px; padding: 15px; overflow-y:scroll; }
        </style>
     <style type="text/css"> 
        .rounds {
        height:100px;
        width: 100px;
           
        -moz-border-colors:25px;
        border-radius:25px;
        } 

        .HyperLinkButtonStyle { float:right; text-align:left; border: none; background: none; 
        color: blue; text-decoration: underline; font: normal 10px verdana;} 
        .hdnDivisionRevalution { background-color: #EFEFEF; position:absolute;z-index:1; visibility:hidden; border:10px double black; text-align:center;
        width:80%; height:80%;    margin-left:100px;  margin-top:10px; margin-right:00px; padding: 15px; overflow-y:scroll; }
        </style>
    <style type="text/css"> 
        .rounds {
        height:100px;
        width: 100px;
           
        -moz-border-colors:25px;
        border-radius:25px;
        } 

        .HyperLinkButtonStyle { float:right; text-align:left; border: none; background: none; 
        color: blue; text-decoration: underline; font: normal 10px verdana;} 
        .hdnDivisionReClasification { background-color: #EFEFEF; position:absolute;z-index:1; visibility:hidden; border:10px double black; text-align:center;
        width:80%; height:80%;    margin-left:100px;  margin-top:10px; margin-right:00px; padding: 15px; overflow-y:scroll; }
        </style>

     <style type="text/css"> 
        .rounds {
        height:100px;
        width: 100px;
           
        -moz-border-colors:25px;
        border-radius:25px;
        } 

        .HyperLinkButtonStyle { float:right; text-align:left; border: none; background: none; 
        color: blue; text-decoration: underline; font: normal 10px verdana;} 
        .hdnDivisionSale { background-color: #EFEFEF; position:absolute;z-index:1; visibility:hidden; border:10px double black; text-align:center;
        width:80%; height:80%;    margin-left:100px;  margin-top:10px; margin-right:00px; padding: 15px; overflow-y:scroll; }
        </style>
  
 <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        
        }
        .ddList {}
        .txtBox {}
        </style>
    </head>
<body>
    <form id="frmaccountsrealize" runat="server">
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
       <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnsearch" runat="server" /><asp:HiddenField ID="hdnPreConfirm" runat="server" />
   
    
        <div>
            <table>
                <tr>
                <td style="text-align:right;"> <asp:Label ID="Label99" runat="server" CssClass="lbl" font-size="small" Font-Bold="true" Text="Unit-:"></asp:Label></td>
                <td style="text-align: left;"><asp:DropDownList ID="ddlunit" runat="server" AutoPostBack="True" CssClass="ddList" Font-Bold="true" OnSelectedIndexChanged="ddlunit_SelectedIndexChanged"  ></asp:DropDownList> </td>


                <td style="text-align:right;"><asp:Label ID="Label84" CssClass="lbl" runat="server" Text="Asset ID: "></asp:Label></td>
               <td style="text-align:left;"> <asp:TextBox ID="txtAssetID" runat="server" CssClass="txtBox" Font-Bold="False" AutoPostBack="true"  ></asp:TextBox>
                 <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtAssetID"
                 ServiceMethod="GetAssetTransaction" MinimumPrefixLength="1" CompletionSetCount="1"
                 CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                 CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"></cc1:AutoCompleteExtender>
        
               <td style="text-align:right;"><asp:Label ID="Label85" CssClass="lbl" runat="server" Text="Asset Name:"></asp:Label></td>
                 <td><asp:DropDownList ID="ddlTransactionType" runat="server" AutoPostBack="true" CssClass="txtBox" OnSelectedIndexChanged="ddlTransactionType_SelectedIndexChanged">
                     <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                     <asp:ListItem Value="3" Text="Transfer"></asp:ListItem>
                     <%--<asp:ListItem Value="7" Text="Disposal/Retirment"></asp:ListItem>--%>
                     <asp:ListItem Value="6" Text="Revalution"></asp:ListItem>
                     <asp:ListItem Value="4" Text="Re-Clasification"></asp:ListItem>
                     <asp:ListItem Value="5" Text="Sale/Disposal"></asp:ListItem> 
                     </asp:DropDownList>
                     <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                     <asp:Label ID="lblMsg" runat="server" ForeColor="Red" ></asp:Label>
                 </td>        

                </tr>
            </table>
        </div>

                <%--   General Asset Transaction Transfer        class="hdnDivision" --%>       

                <div id="hdnDivision"   class="hdnDivision"   style="width:auto;  height:500px;">
                <table style="width:auto;  float:left; " >   
                <tr><td style="text-align:left;" colspan="4"><asp:Label ID="Label105" CssClass="lbl" runat="server" Font-Size="small" Font-Bold="true"  Text="Asset Transfer From: "></asp:Label></td>
                </tr>
                
                        <tr>
                <td style="text-align:right;"><asp:Label ID="Label77" CssClass="lbl" runat="server" Text="Unit Name: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlTrunitp" runat="server" Enabled="false"  CssClass="dropdownList"  AutoPostBack="True" OnSelectedIndexChanged="ddlTrnsUnit_SelectedIndexChanged" > </asp:DropDownList>  </td>                 
                  
                <td style="text-align:right;"><asp:Label ID="Label87" CssClass="lbl" runat="server" Text="Asset Name:"></asp:Label></td>
                <td><asp:TextBox ID="txtTAssetP" runat="server"  Enabled="false" CssClass="txtBox"></asp:TextBox></td>        

                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label88" CssClass="lbl" runat="server" Text="Branch:"></asp:Label></td>
                <td><asp:DropDownList ID="ddlTjobp" runat="server"  Enabled="false"  CssClass="dropdownList"  AutoPostBack="True" OnSelectedIndexChanged="ddlTrnsJobstation_SelectedIndexChanged" ></asp:DropDownList> </td>

                <td style="text-align:right;"><asp:Label ID="Label89" CssClass="lbl" runat="server" Text="Description:"></asp:Label></td>
                <td><asp:TextBox ID="txtTdescriptionp" runat="server"  Enabled="false" CssClass="txtBox"></asp:TextBox></td>        

                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label90" CssClass="lbl" runat="server" Text="Asset Type : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlTassetTypep" runat="server"  Enabled="false"  CssClass="dropdownList"  >
                <asp:ListItem Value="1">Adminstrative</asp:ListItem><asp:ListItem Value="2">Manufacturer</asp:ListItem>
                </asp:DropDownList> </td>

                <td style="text-align:right;"><asp:Label ID="Label91" CssClass="lbl" runat="server" Text="Asset Major Catagory : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlTmajorCatp" runat="server"  Enabled="false"  CssClass="dropdownList"   >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> </td>
                </tr>
                <tr>
                

                <td style="text-align:right;"><asp:Label ID="Label92" CssClass="lbl" runat="server" Text="Asset Minor Catagory 1 : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlTminorCatp1" runat="server"  Enabled="false"  CssClass="dropdownList"  >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> </td>  

                <td style="text-align:right;"><asp:Label ID="Label93" CssClass="lbl" runat="server" Text="Asset Minor Catagory 2: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlTminorcatp2" runat="server"  Enabled="false"  CssClass="dropdownList"   >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> </td>
                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label94" CssClass="lbl" runat="server" Text="CostCenter : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlTCostcenterp" runat="server"  CssClass="dropdownList"  >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> </td> 
               
                </tr>

                <tr>
                <td><asp:Label runat="server" ID="lblms" Text="Transfer To" Font-Bold="true"></asp:Label></td>
                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label51" CssClass="lbl" runat="server" Text="Unit Name: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlTrnsUnit" runat="server"  CssClass="dropdownList"  AutoPostBack="True" OnSelectedIndexChanged="ddlTrnsUnit_SelectedIndexChanged" > </asp:DropDownList>  </td>                 
                  
                <td style="text-align:right;"><asp:Label ID="Label15" CssClass="lbl" runat="server" Text="Asset Name:"></asp:Label></td>
                <td><asp:TextBox ID="txtTrnsAssetName" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="lblBranch" CssClass="lbl" runat="server" Text="Branch:"></asp:Label></td>
                <td><asp:DropDownList ID="ddlTrnsJobstation" runat="server"  CssClass="dropdownList"  AutoPostBack="True" OnSelectedIndexChanged="ddlTrnsJobstation_SelectedIndexChanged" ></asp:DropDownList> </td>

                <td style="text-align:right;"><asp:Label ID="Label16" CssClass="lbl" runat="server" Text="Description:"></asp:Label></td>
                <td><asp:TextBox ID="txtTrnsDescription" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="lblAssetType" CssClass="lbl" runat="server" Text="Asset Type : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlTrnsAssetType" runat="server"  CssClass="dropdownList"  >
                <asp:ListItem Value="1">Adminstrative</asp:ListItem><asp:ListItem Value="2">Manufacturer</asp:ListItem>
                </asp:DropDownList> </td>

                <td style="text-align:right;"><asp:Label ID="lblMajor" CssClass="lbl" runat="server" Text="Asset Major Catagory : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlTrnsMajorCat" runat="server"    CssClass="dropdownList"   >
                
                </asp:DropDownList> </td>
                </tr>
                <tr>
                

                <td style="text-align:right;"><asp:Label ID="Label7" CssClass="lbl" runat="server" Text="Asset Minor Catagory 1 : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlTrnsMinorCat1" runat="server"  CssClass="dropdownList"  >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> </td>  

                <td style="text-align:right;"><asp:Label ID="Label8" CssClass="lbl" runat="server" Text="Asset Minor Catagory 2: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlTrnsMinorCat2" runat="server"  CssClass="dropdownList"   >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> </td>
                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label11" CssClass="lbl" runat="server" Text="CostCenter : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlTrnsCostCenter" runat="server"  CssClass="dropdownList"  >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> </td>

                <td style="text-align:right;"><asp:Label ID="Label12" CssClass="lbl" runat="server" Text="User Enroll:"></asp:Label></td>
                <td><asp:TextBox ID="txtTrnsUserEnroll" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                </tr>
                    <tr>
                        <td style="text-align:right;"><asp:Label ID="Label13" CssClass="lbl" runat="server" Text="Reference No:"></asp:Label></td>
                 <td><asp:TextBox ID="txtTrnsRefe" runat="server" CssClass="txtBox"></asp:TextBox></td> 
                        <td style="text-align:right;"><asp:Label ID="Label14" CssClass="lbl" runat="server" Text="Transaction Date:"></asp:Label></td>
                 <td><asp:TextBox ID="txtDteTrnsDate" runat="server" CssClass="txtBox"></asp:TextBox>
                  <cc1:CalendarExtender ID="CalendarExtender8" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDteTrnsDate">
                </cc1:CalendarExtender>   </td>      

                    </tr>
                     <tr>
                        <td style="text-align:right;"><asp:Label ID="Label17" CssClass="lbl" runat="server" Text="Remarks:"></asp:Label></td>
                 <td><asp:TextBox ID="txtTrnsRemarks" runat="server" CssClass="txtBox"></asp:TextBox></td>                        
                    </tr>

                     <tr>
                      <td colspan="2" style="text-align:right;"><asp:Button ID="btnTransfer" OnClientClick="return Transfer();" runat="server" Text="Save" OnClick="btnTransfer_Click" /> </td>                          
                       
                      <td colspan="2" style="text-align:right;"><asp:Button ID="btnCloseTrns" runat="server" OnClick="btnClose_Click" Text="Close" /> </td>
                      
                    </tr>      
                </table>
                </div>
          

                <%--   General Asset Transaction Transfer        class="hdnDivisionDisposal" --%>       

                <div id="hdnDivisionDisposal"     class="hdnDivisionDisposal"  style="width:auto;   height:500px;">
                <table style="width:auto;  float:left; " >   
                <tr><td style="text-align:left;" colspan="4"><asp:Label ID="Label18" CssClass="lbl" runat="server" Font-Size="small" Font-Bold="true"  Text="Asset Disposal/Retirement: "></asp:Label></td>
                </tr>
                
                
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label19" CssClass="lbl" runat="server" Text="Unit Name: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlDispoUnit" runat="server"  CssClass="dropdownList" Enabled="false"  AutoPostBack="True" OnSelectedIndexChanged="ddlDispoUnit_SelectedIndexChanged" > </asp:DropDownList>  </td>                 
                  
               <td style="text-align:right;"><asp:Label ID="Label20" CssClass="lbl" runat="server" Text="Asset Name:"></asp:Label></td>
                 <td><asp:TextBox ID="txtDispoAssetName" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                </tr>
                     <tr>
                <td style="text-align:right;"><asp:Label ID="Label21" CssClass="lbl" runat="server" Text="Branch:"></asp:Label></td>
                <td><asp:DropDownList ID="ddlDispoJobstation" runat="server" Enabled="false"  CssClass="dropdownList"  AutoPostBack="True" OnSelectedIndexChanged="ddlDispoJobstation_SelectedIndexChanged" ></asp:DropDownList> </td>

                <td style="text-align:right;"><asp:Label ID="Label22" CssClass="lbl" runat="server" Text="Description:"></asp:Label></td>
                 <td><asp:TextBox ID="txtDespoDescrip" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label23" CssClass="lbl" runat="server" Text="Asset Type : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlDispoAssetType" runat="server" Enabled="false"  CssClass="dropdownList"  >
                <asp:ListItem Value="1">Adminstrative</asp:ListItem><asp:ListItem Value="2">Manufacturer</asp:ListItem>
                </asp:DropDownList> </td>

                 <td style="text-align:right;"><asp:Label ID="Label24" CssClass="lbl" runat="server" Text="Asset Major Catagory : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlDispoMejorCat" runat="server" Enabled="false"  CssClass="dropdownList"   >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> </td>
                </tr>
                <tr>
                

                   <td style="text-align:right;"><asp:Label ID="Label25" CssClass="lbl" runat="server" Text="Asset Minor Catagory 1 : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlDispoMonorCat1" runat="server" Enabled="false"  CssClass="dropdownList"  >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> </td>  

                <td style="text-align:right;"><asp:Label ID="Label26" CssClass="lbl" runat="server" Text="Asset Minor Catagory 2: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlDisMinorCat2" runat="server"  CssClass="dropdownList"  >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> </td>
                </tr>
                    <tr>
                        <td style="text-align:right;"><asp:Label ID="Label27" CssClass="lbl" runat="server" Text="CostCenter : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlDispoCostCenter" runat="server" Enabled="false" CssClass="dropdownList"   >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> </td>

                 <td style="text-align:right;"><asp:Label ID="Label28" CssClass="lbl" runat="server" Text="User Enroll:"></asp:Label></td>
                 <td><asp:TextBox ID="txtDispoUserenroll" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                    </tr>
                    <tr>
                        <td style="text-align:right;"><asp:Label ID="Label29" CssClass="lbl" runat="server" Text="Reference No:"></asp:Label></td>
                 <td><asp:TextBox ID="txtDispoReff" runat="server" CssClass="txtBox"></asp:TextBox></td> 
                        <td style="text-align:right;"><asp:Label ID="Label30" CssClass="lbl" runat="server" Text="Transaction Date:"></asp:Label></td>
                 <td><asp:TextBox ID="txtDispoDate" runat="server" CssClass="txtBox"></asp:TextBox>
                     <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDispoDate">
                </cc1:CalendarExtender> </td>    
                       
       

                    </tr>
                     <tr>
                        <td style="text-align:right;"><asp:Label ID="Label31" CssClass="lbl" runat="server" Text="Remarks:"></asp:Label></td>
                 <td><asp:TextBox ID="txtDispoRemarks" runat="server" CssClass="txtBox"></asp:TextBox></td> 
                        
                 <td style="text-align:right;"><asp:Label ID="Label35" CssClass="lbl" runat="server" Text="Total Depreciation:"></asp:Label></td>
                 <td><asp:TextBox ID="txtDispoTotalDep" runat="server" onkeyup="disDepCal(this);" CssClass="txtBox"></asp:TextBox></td> 

                    </tr>
                     
                      <tr>
                  <td style="text-align:right;"><asp:Label ID="Label36" CssClass="lbl" runat="server" Text="Total Cost:"></asp:Label></td>
                 <td><asp:TextBox ID="txtDispoTotalCost" runat="server"   CssClass="txtBox"></asp:TextBox></td> 
                 <td style="text-align:right;"><asp:Label ID="Label37" CssClass="lbl" runat="server" Text="Capital Loss/Gain:"></asp:Label></td>
                 <td><asp:TextBox ID="txtDispoCapitalLoss" runat="server"   CssClass="txtBox"></asp:TextBox></td>                      
                 </tr>
                     <tr>
                      <td colspan="2" style="text-align:right;"><asp:Button ID="btnDisposal" runat="server" Text="Save" OnClientClick="return Disposal();" OnClick="btnDisposal_Click" /> </td>                          
                       
                      <td colspan="2" style="text-align:right;"><asp:Button ID="btnDisClose" runat="server" OnClick="btnClose_Click" Text="Close" /> </td>
                      
                    </tr>      
                </table>
                </div>
         <%--   General Asset Transaction Revulation        class="hdnDivisionRevalution" --%> 
                <div id="hdnDivisionRevalution"  class="hdnDivisionRevalution"  style="width:auto;  height:500px;">
                <table style="width:auto;  float:left; " >   
                <tr><td style="text-align:left;" colspan="4"><asp:Label ID="Label1" CssClass="lbl" runat="server" Font-Size="small" Font-Bold="true"  Text="Asset Revaluation: "></asp:Label></td>
                </tr>
                
                
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Unit Name: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlRevUnit" runat="server"  Enabled="false" CssClass="dropdownList"  AutoPostBack="True" OnSelectedIndexChanged="ddlRevUnit_SelectedIndexChanged"> </asp:DropDownList>  </td>                 
                  
               <td style="text-align:right;"><asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Asset Name:"></asp:Label></td>
                 <td><asp:TextBox ID="txtRevAssetname" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                </tr>
                     <tr>
                <td style="text-align:right;"><asp:Label ID="Label4" CssClass="lbl" runat="server" Text="Branch:"></asp:Label></td>
                <td><asp:DropDownList ID="ddlRevJobstation" runat="server" Enabled="false" CssClass="dropdownList"  AutoPostBack="True" OnSelectedIndexChanged="ddlRevJobstation_SelectedIndexChanged"></asp:DropDownList> </td>

                <td style="text-align:right;"><asp:Label ID="Label5" CssClass="lbl" runat="server" Text="Description:"></asp:Label></td>
                 <td><asp:TextBox ID="txtRevDescrip" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label6" CssClass="lbl" runat="server" Text="Asset Type : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlRevType" runat="server" Enabled="false"  CssClass="dropdownList"  >
                <asp:ListItem Value="1">Adminstrative</asp:ListItem><asp:ListItem Value="2">Manufacturer</asp:ListItem>
                </asp:DropDownList> </td>

                 <td style="text-align:right;"><asp:Label ID="Label9" CssClass="lbl" runat="server" Text="Asset Major Catagory : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlRevMejorCat" runat="server" Enabled="false"  CssClass="dropdownList"   >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> </td>
                </tr>
                <tr>
                

                   <td style="text-align:right;"><asp:Label ID="Label10" CssClass="lbl" runat="server" Text="Asset Minor Catagory 1 : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlRevMinorCat1" runat="server" Enabled="false"  CssClass="dropdownList"  >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> </td>  

                <td style="text-align:right;"><asp:Label ID="Label38" CssClass="lbl" runat="server" Text="Asset Minor Catagory 2: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlRevMinorCat2" runat="server"  CssClass="dropdownList"   >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> </td>
                </tr>
                    <tr>
                        <td style="text-align:right;"><asp:Label ID="Label39" CssClass="lbl" runat="server" Text="CostCenter : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlRevCostCenter" runat="server" Enabled="false"  CssClass="dropdownList"  >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> </td>

                 <td style="text-align:right;"><asp:Label ID="Label40" CssClass="lbl" runat="server" Text="User Enroll:"></asp:Label></td>
                 <td><asp:TextBox ID="txtRevUserEnroll" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                    </tr>
                    <tr>
                        <td style="text-align:right;"><asp:Label ID="Label41" CssClass="lbl" runat="server" Text="Reference No:"></asp:Label></td>
                 <td><asp:TextBox ID="txtRevReff" runat="server" CssClass="txtBox"></asp:TextBox></td> 
                        <td style="text-align:right;"><asp:Label ID="Label42" CssClass="lbl" runat="server" Text="Transaction Date:"></asp:Label></td>
                 <td><asp:TextBox ID="txtRevDate" runat="server" CssClass="txtBox"></asp:TextBox>
                     <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="txtRevDate">
                </cc1:CalendarExtender> </td>   
                    </tr>
                     <tr>
                        <td style="text-align:right;"><asp:Label ID="Label43" CssClass="lbl" runat="server" Text="Remarks:"></asp:Label></td>
                        <td><asp:TextBox ID="txtReVRemarks" runat="server" CssClass="txtBox"></asp:TextBox></td>
                         <td style="text-align:right;"><asp:Label ID="Label45" CssClass="lbl" runat="server" Text="Total Cost"></asp:Label></td>
                        <td><asp:TextBox ID="txtRevTotalCost" TextMode="Number" Enabled="false" runat="server" CssClass="txtBox"></asp:TextBox></td>
                    </tr> 
                    <tr>
                 <td style="text-align:right;"><asp:Label ID="Label95" CssClass="lbl" runat="server" Text="Total Acc Dep:"></asp:Label></td>
                 <td><asp:TextBox ID="txtRevAccDep" runat="server" TextMode="Number" Enabled="false" CssClass="txtBox"></asp:TextBox></td> 
                 <td style="text-align:right;"><asp:Label ID="Label96" CssClass="lbl" runat="server" Text="Carying Amount"></asp:Label></td>
                 <td><asp:TextBox ID="txtRevCarying" runat="server" TextMode="Number" Enabled="false" CssClass="txtBox"></asp:TextBox></td>                       

                    </tr>
                    <tr>
                 <td style="text-align:right;"><asp:Label ID="Label97" CssClass="lbl" runat="server" Text="Revalued Amount:"></asp:Label></td>
                 <td><asp:TextBox ID="txtRevalued" runat="server" TextMode="Number" Enabled="false" CssClass="txtBox"></asp:TextBox></td> 
                 <td style="text-align:right;"><asp:Label ID="Label98" CssClass="lbl" runat="server" Text="Fair Market"></asp:Label></td>
                 <td><asp:TextBox ID="txtRevFairMarket" runat="server" onkeyup="LossGain();" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>                       

                    </tr>
                    <tr>
                  
                  <td style="text-align:right;"><asp:Label ID="Label44" Enabled="false" CssClass="lbl" runat="server" Text="Loss/Gain:"></asp:Label></td>
                 <td><asp:TextBox ID="txtRevLossGain" runat="server" TextMode="Number" Enabled="false" CssClass="txtBox"></asp:TextBox></td> 
                   <td colspan="2" style="text-align:right;"><asp:Button ID="btnReValution" runat="server" OnClientClick="return Reviloation();" Text="Save" OnClick="btnReValution_Click" />   
                   <asp:Button ID="btnRevclose" runat="server" OnClick="btnClose_Click" Text="Close" /> </td>
                
                 </tr>
                </table>
                </div>
              

          <%--   General Asset Transaction Re-Classification        class="hdnDivisionReClasification" --%> 

                <div id="hdnDivisionReClasification"   class="hdnDivisionReClasification" style="width:auto;  height:500px;">
                <table style="width:auto;  float:left; " >   
                <tr><td style="text-align:left;" colspan="4"><asp:Label ID="Label46" CssClass="lbl" runat="server" Font-Size="small" Font-Bold="true"  Text="Asset Re-Clasification: "></asp:Label></td>
                </tr>  
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label47" CssClass="lbl" runat="server" Text="Unit Name: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlReUnit" runat="server" Enabled="false"  CssClass="dropdownList"  AutoPostBack="True" OnSelectedIndexChanged="ddlReUnit_SelectedIndexChanged"> </asp:DropDownList>  </td>                 
                  
                <td style="text-align:right;"><asp:Label ID="Label48" CssClass="lbl" runat="server" Text="Asset Name:"></asp:Label></td>
                <td><asp:TextBox ID="txtReAsetname" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label49" CssClass="lbl" runat="server" Text="Branch:"></asp:Label></td>
                <td><asp:DropDownList ID="ddlRejobstation" runat="server" Enabled="false"  CssClass="dropdownList"  AutoPostBack="True" OnSelectedIndexChanged="ddlRejobstation_SelectedIndexChanged"></asp:DropDownList> </td>

                <td style="text-align:right;"><asp:Label ID="Label50" CssClass="lbl" runat="server" Text="Description:"></asp:Label></td>
                <td><asp:TextBox ID="txtReDescrip" runat="server" CssClass="txtBox"></asp:TextBox></td>   
                </tr>
                  <tr>
                <td style="text-align:right;"><asp:Label ID="Label32" CssClass="lbl" runat="server" Text="Asset Type : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlRassetTypep" runat="server"  CssClass="dropdownList"  >
                <asp:ListItem Value="1">Adminstrative</asp:ListItem><asp:ListItem Value="2">Manufacturer</asp:ListItem>
                </asp:DropDownList> </td>

                <td style="text-align:right;"><asp:Label ID="Label33" CssClass="lbl" runat="server" Text="Asset Major Catagory : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlRemajorCatp" runat="server"  CssClass="dropdownList"  >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> </td>
                </tr>
                <tr> 
                <td style="text-align:right;"><asp:Label ID="Label34" CssClass="lbl" runat="server" Text="Asset Minor Catagory 1 : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlReMinorCat1P" runat="server"  CssClass="dropdownList"  >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> </td>  

                <td style="text-align:right;"><asp:Label ID="Label75" CssClass="lbl" runat="server" Text="Asset Minor Catagory 2: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlReMinorCat2p" runat="server"  CssClass="dropdownList"  >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> </td>
                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label76" CssClass="lbl" runat="server" Text="CostCenter : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlReCostcenterp" runat="server"  CssClass="dropdownList"   >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> </td> 
                </tr>
                <tr>
                     <td style="text-align:right;"><asp:Label ID="Label86" CssClass="lbl" runat="server" Text="Change Clasification:"></asp:Label></td>
                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label52" CssClass="lbl" runat="server" Text="Asset Type : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlReAssetType" runat="server"  CssClass="dropdownList"  >
                <asp:ListItem Value="1">Adminstrative</asp:ListItem><asp:ListItem Value="2">Manufacturer</asp:ListItem>
                </asp:DropDownList> </td>

                <td style="text-align:right;"><asp:Label ID="Label53" CssClass="lbl" runat="server" Text="Asset Major Catagory : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlReMejorCat" runat="server"  CssClass="dropdownList"  >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> </td>
                </tr>
                <tr> 
                <td style="text-align:right;"><asp:Label ID="Label54" CssClass="lbl" runat="server" Text="Asset Minor Catagory 1 : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlReMinorCat1" runat="server"  CssClass="dropdownList"  >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> </td>  

                <td style="text-align:right;"><asp:Label ID="Label55" CssClass="lbl" runat="server" Text="Asset Minor Catagory 2: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlRemonorCat2" runat="server"  CssClass="dropdownList"  >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> </td>
                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label56" CssClass="lbl" runat="server" Text="CostCenter : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlReCostCenter" runat="server"  CssClass="dropdownList"   >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> </td> 

                 <td style="text-align:right;"><asp:Label ID="Label58" CssClass="lbl" runat="server" Text="Reference No:"></asp:Label></td>
                <td><asp:TextBox ID="txtReReff" runat="server" CssClass="txtBox"></asp:TextBox></td> 

                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label59" CssClass="lbl" runat="server" Text="Transaction Date:"></asp:Label></td>
                <td><asp:TextBox ID="txtReDate" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy-MM-dd" TargetControlID="txtReDate">
                </cc1:CalendarExtender>   </td>   

                 <td style="text-align:right;"><asp:Label ID="Label60" CssClass="lbl" runat="server" Text="Remarks:"></asp:Label></td>
                <td><asp:TextBox ID="txtReRemarks" runat="server" CssClass="txtBox"></asp:TextBox></td>  
                </tr> 
                 <tr>
                     <td style="text-align:right;"><asp:Label ID="Label57" CssClass="lbl"    runat="server" Text="User Enroll:"></asp:Label></td>
                     <td><asp:TextBox ID="txtReUserEnroll" runat="server"  CssClass="txtBox"></asp:TextBox></td>        
                      <td colspan="2" style="text-align:right;"><asp:Button ID="btnReclassSubmit" OnClientClick="return Clasification();" runat="server" Text="Save" OnClick="btnReclassSubmit_Click" /> </td>                          
                       
                      <td style="text-align:right;"><asp:Button ID="btnReclassClose" runat="server" OnClick="btnClose_Click" Text="Close" /> </td>
                      
                    </tr>                     
                </table>
                </div>

           <%--   General Asset Transaction Sale        class="hdnDivisionSale" --%>
        

                <div id="hdnDivisionSale"   class="hdnDivisionSale"   style="width:auto;  height:500px;">
                <table style="width:auto;  float:left; " >   
                <tr><td style="text-align:left;" colspan="4"><asp:Label ID="Label61" CssClass="lbl" runat="server" Font-Size="small" Font-Bold="true"  Text="Asset Sale/Disposal: "></asp:Label></td>
                </tr>                
                
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label62" CssClass="lbl" runat="server" Text="Unit Name: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlSaleUnit" runat="server"  CssClass="dropdownList"  AutoPostBack="True" OnDataBound="ddlSaleUnit_DataBound"  OnSelectedIndexChanged="ddlSaleUnit_SelectedIndexChanged" > </asp:DropDownList>  </td>                 

                <td style="text-align:right;"><asp:Label ID="Label63" CssClass="lbl" runat="server" Text="Asset Name:"></asp:Label></td>
                <td><asp:TextBox ID="txtSaleAssetName" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label64" CssClass="lbl" runat="server" Text="Branch:"></asp:Label></td>
                <td><asp:DropDownList ID="ddlSaleJob" runat="server"  CssClass="dropdownList"  AutoPostBack="True" OnSelectedIndexChanged="ddlSaleJob_SelectedIndexChanged" ></asp:DropDownList> </td>

                <td style="text-align:right;"><asp:Label ID="Label65" CssClass="lbl" runat="server" Text="Description:"></asp:Label></td>
                <td><asp:TextBox ID="txtSaleAssetDescrip" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label66" CssClass="lbl" runat="server" Text="Asset Type : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlSaleAssetType" runat="server"  CssClass="dropdownList"  >
                <asp:ListItem Value="1">Adminstrative</asp:ListItem><asp:ListItem Value="2">Manufacturer</asp:ListItem>
                </asp:DropDownList> </td>

                <td style="text-align:right;"><asp:Label ID="Label67" CssClass="lbl" runat="server" Text="Asset Major Catagory : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlSaMajorCat" runat="server"  CssClass="dropdownList"   >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> </td>
                </tr>
                <tr> 

                <td style="text-align:right;"><asp:Label ID="Label68" CssClass="lbl" runat="server" Text="Asset Minor Catagory 1 : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlSaMinorCat1" runat="server"  CssClass="dropdownList"  >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> </td>  

                <td style="text-align:right;"><asp:Label ID="Label69" CssClass="lbl" runat="server" Text="Asset Minor Catagory 2: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlSaMinorCat2" runat="server"  CssClass="dropdownList"   >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> </td>
                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label70" CssClass="lbl" runat="server" Text="CostCenter : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlSaCostCenter" runat="server"  CssClass="dropdownList"   >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> </td>

                <td style="text-align:right;"><asp:Label ID="Label71" CssClass="lbl" runat="server" Text="User Enroll:"></asp:Label></td>
                <td><asp:TextBox ID="txtSaUserEnroll" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label72" CssClass="lbl" runat="server" Text="Reference No:"></asp:Label></td>
                <td><asp:TextBox ID="txtSaReff" runat="server" CssClass="txtBox"></asp:TextBox></td> 
                <td style="text-align:right;"><asp:Label ID="Label73" CssClass="lbl" runat="server" Text="Transaction Date:"></asp:Label></td>
                <td><asp:TextBox ID="txtSaDteDate" runat="server" CssClass="txtBox"></asp:TextBox>
                 <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtSaDteDate"> </cc1:CalendarExtender></td>    
                
                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label74" CssClass="lbl" runat="server" Text="Remarks:"></asp:Label></td>
                <td><asp:TextBox ID="txtSaRemarks" runat="server" CssClass="txtBox"></asp:TextBox></td>                       
       
                </tr> 
                <tr>
                                   
                <td style="text-align:right;"><asp:Label ID="Label78" CssClass="lbl" runat="server" Text="Total Depreciation:"></asp:Label></td>
                <td><asp:TextBox ID="txtSaTotalDep" runat="server"  CssClass="txtBox"></asp:TextBox></td> 
                </tr>
                 <tr>
                <td style="text-align:right;"><asp:Label ID="Label79" CssClass="lbl" runat="server" Text="Total Cost:"></asp:Label></td>
                <td><asp:TextBox ID="txtSaTotalCost" runat="server" ReadOnly="false" CssClass="txtBox"></asp:TextBox></td>                       
                <td style="text-align:right;"><asp:Label ID="Label80" CssClass="lbl" runat="server" Text="Sales Proceed:"></asp:Label></td>
                <td><asp:TextBox ID="txtSalesProcess" runat="server" TextMode="Number"  onkeyup="SaleLosgain();" CssClass="txtBox"  ></asp:TextBox></td> 
                </tr>

                    <tr>
                <td style="text-align:right;"><asp:Label ID="Label81" CssClass="lbl" runat="server" Text="Loss Gain :"></asp:Label></td>
                <td><asp:TextBox ID="txtSaCapitalLoss" runat="server" ReadOnly="false" CssClass="txtBox"></asp:TextBox></td>                       
                <td style="text-align:right;"><asp:Label ID="Label82" CssClass="lbl" runat="server" Text="Receiveable Name:"></asp:Label></td>
                <td><asp:TextBox ID="txtSaReceiveableName" runat="server" CssClass="txtBox"></asp:TextBox></td> 
                </tr>

                     <tr>
                <td style="text-align:right;"><asp:Label ID="Label83" CssClass="lbl" runat="server" Text="Recieveable ID :"></asp:Label></td>
                <td><asp:TextBox ID="txtSaReceivealeID" runat="server" CssClass="txtBox"></asp:TextBox>
                 <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSaReceivealeID"
                 ServiceMethod="GetAccCoaSearch" MinimumPrefixLength="1" CompletionSetCount="1"
                 CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                 CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"></cc1:AutoCompleteExtender></td>
        
                </tr>
                     <tr>
                      <td colspan="2" style="text-align:right;"><asp:Button ID="btnSales" runat="server" OnClientClick="return Sales();" Text="Save" OnClick="btnSales_Click" /> </td>                          
                       
                      <td colspan="2" style="text-align:right;"><asp:Button ID="btnclosev" runat="server" OnClick="btnClose_Click" Text="Close" /> </td>
                      
                    </tr>
                                     
                </table>
                </div> 
<%--=========================================End My Code From Here=================================================--%>
      
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

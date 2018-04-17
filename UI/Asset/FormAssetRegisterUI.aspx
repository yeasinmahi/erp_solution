<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormAssetRegisterUI.aspx.cs" Inherits="UI.Asset.FormAssetRegisterUI" %>

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
    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .Textbox {}
        </style>

   

    <style type="text/css">
    .Initial
{
  display: block;
  padding: 4px 18px 4px 18px;
  float: left;
  background: url("../Images/InitialImage.png") no-repeat right top;
  color: Black;
  font-weight: bold;
}
     .Initial:hover
     {
  color: White;
  background:#eeeeee;
   }
     .Clicked
     {
  float: left;
  display: block;
  background:padding-box;
  padding: 4px 18px 4px 18px;
  color: Black;
  font-weight: bold;
  color:Green;
}
</style>

    <script>
        function FTPBuildingUpload() {
            document.getElementById("hdnBuild").value = "4";
            __doPostBack();
        }
        </script>
    <script>
        function Confirm() {

            var TxtAssetName = document.forms["frmaccountsrealize"]["TxtAssetName"].value;
            var TxtDteWarranty = document.forms["frmaccountsrealize"]["TxtDteWarranty"].value;
            var TxtDtePo = document.forms["frmaccountsrealize"]["TxtDtePo"].value;
            var TxtDteLC = document.forms["frmaccountsrealize"]["TxtDteLC"].value;
            var TxtInvoice = document.forms["frmaccountsrealize"]["TxtInvoice"].value;

            var TxtManuProvideSl = document.forms["frmaccountsrealize"]["TxtManuProvideSl"].value;
            var TxtDteInstalation = document.forms["frmaccountsrealize"]["TxtDteInstalation"].value;

            var TxtErectionCost = document.forms["frmaccountsrealize"]["TxtErectionCost"].value;
            var TxtDteAcusition = document.forms["frmaccountsrealize"]["TxtDteAcusition"].value;

            var TxtEstSalvageValue = document.forms["frmaccountsrealize"]["TxtEstSalvageValue"].value;
            var TxtLandedCost = document.forms["frmaccountsrealize"]["TxtLandedCost"].value;

            var TxtRateDepeciation = document.forms["frmaccountsrealize"]["TxtRateDepeciation"].value;
            var TxtAccumulatedDepreciation = document.forms["frmaccountsrealize"]["TxtAccumulatedDepreciation"].value;
            var TxtValueDepreciation = document.forms["frmaccountsrealize"]["TxtValueDepreciation"].value;
            var TxtWrittenDownValue = document.forms["frmaccountsrealize"]["TxtWrittenDownValue"].value;

            if (TxtAssetName == null || TxtAssetName == "") {
                alert("Please select a valid Name of Asset");
                document.getElementById("TxtAssetName").focus();
            }
            else if (TxtDteWarranty == null || TxtDteWarranty == "") {
                alert("From date must be filled by valid formate (yyyy-MM-dd).");
                document.getElementById("TxtDteWarranty").focus();
            }
            if (TxtDtePo == null || TxtDtePo == "") {
                alert("Please select a valid PO Date formate (yyyy-MM-dd)");
                document.getElementById("TxtDtePo").focus();
            }
            if (TxtDteLC == null || TxtDteLC == "") {
                alert("Please select a valid LCDate formate (yyyy-MM-dd)");
                document.getElementById("TxtDteLC").focus();
            }
            else if (TxtInvoice == null || TxtInvoice == "") {
                alert("From date must be filled by valid Invoice Value");
                document.getElementById("TxtInvoice").focus();
            }
            if (TxtManuProvideSl == null || TxtManuProvideSl == "") {
                alert("Please select a valid ManuFactacturer Provided Sl No");
                document.getElementById("TxtManuProvideSl").focus();
            }
            else if (TxtDteInstalation == null || TxtDteInstalation == "") {
                alert("From date must be filled by valid Date of Installation formate (yyyy-MM-dd).");
                document.getElementById("TxtDteInstalation").focus();
            }
            if (TxtErectionCost == null || TxtErectionCost == "") {
                alert("Please select a valid Erection Installation Cost");
                document.getElementById("TxtErectionCost").focus();
            }
            else if (TxtDteAcusition == null || TxtDteAcusition == "") {
                alert("From date must be filled by valid Acusition Date formate (yyyy-MM-dd).");
                document.getElementById("TxtDteAcusition").focus();
            }
            if (TxtEstSalvageValue == null || TxtEstSalvageValue == "") {
                alert("Please select a valid Estimation salvage Value");
                document.getElementById("TxtEstSalvageValue").focus();
            }
            else if (TxtLandedCost == null || TxtLandedCost == "") {
                alert("From date must be filled by valid Landed Cost.");
                document.getElementById("TxtLandedCost").focus();
            }
            if (TxtRateDepeciation == null || TxtRateDepeciation == "") {
                alert("Please select a valid Rate of Depreciation");
                document.getElementById("TxtRateDepeciation").focus();
            }
            else if (TxtAccumulatedDepreciation == null || TxtAccumulatedDepreciation == "") {
                alert("From date must be filled by valid Accumulated Depreciation.");
                document.getElementById("TxtDteWarranty").focus();
            }
            else if (TxtValueDepreciation == null || TxtValueDepreciation == "") {
                alert("From date must be filled by valid Value after Depreciation.");
                document.getElementById("TxtValueDepreciation").focus();
            }
            else if (TxtWrittenDownValue == null || TxtWrittenDownValue == "") {
                alert("From date must be filled by valid Written Down Value.");
                document.getElementById("TxtWrittenDownValue").focus();
            }

        }

        </script>
      <script>
       
         function isNumber(evt) {
             var iKeyCode = (evt.which) ? evt.which : evt.keyCode
             if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57))
                 return false;
             return true;
         }

         function Confirmforadd() {
             document.getElementById("hdnconfirm").value = "0";
             var txt1 = document.forms["frmaccountsrealize"]["txtdagcs"].value;
             var txt2 = document.forms["frmaccountsrealize"]["txtdagsa"].value;
             var txt3 = document.forms["frmaccountsrealize"]["txtdagrs"].value;
             var txt4 = document.forms["frmaccountsrealize"]["txtdagbrs"].value;

             var confirm_value = document.createElement("INPUT");
                 confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                 if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
             else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
         
         }

         function Confirmforsubmitasset() {
             document.getElementById("hdnconfirm").value = "0";
             var TxtAssetLand = document.forms["frmaccountsrealize"]["TxtAssetLand"].value;
             var TxtDescriptionLand = document.forms["frmaccountsrealize"]["TxtDescriptionLand"].value;
             var LandPo = document.forms["frmaccountsrealize"]["LandPo"].value;
             var TxtBuyer = document.forms["frmaccountsrealize"]["TxtBuyer"].value;
             var TxtNameofSeller = document.forms["frmaccountsrealize"]["TxtNameofSeller"].value;
             var TxtMouza = document.forms["frmaccountsrealize"]["TxtMouza"].value;
             var TxtDeedReceoiptNo = document.forms["frmaccountsrealize"]["TxtDeedReceoiptNo"].value;
             var TxtDeedNo = document.forms["frmaccountsrealize"]["TxtDeedNo"].value;
             var TxtOrginalDeedReceiveDate = document.forms["frmaccountsrealize"]["TxtOrginalDeedReceiveDate"].value;
             var TxtTotalArea = document.forms["frmaccountsrealize"]["TxtTotalArea"].value;
             var TxtTotalArealandinDecimal = document.forms["frmaccountsrealize"]["TxtTotalArealandinDecimal"].value;
             var TxtPricePerKatha = document.forms["frmaccountsrealize"]["TxtPricePerKatha"].value;
             var TxtPriceperDecimal = document.forms["frmaccountsrealize"]["TxtPriceperDecimal"].value;
             var TxtTotalValuelandTk = document.forms["frmaccountsrealize"]["TxtTotalValuelandTk"].value;
             var TxtRegistryBainaAmount = document.forms["frmaccountsrealize"]["TxtRegistryBainaAmount"].value;
             var TxtBalancelandValue = document.forms["frmaccountsrealize"]["TxtBalancelandValue"].value;
             var TxtRegistrationExpance = document.forms["frmaccountsrealize"]["TxtRegistrationExpance"].value;
             var TxtDeedValueLand = document.forms["frmaccountsrealize"]["TxtDeedValueLand"].value;
             var TxtLandofficevolumeCheckingexp = document.forms["frmaccountsrealize"]["TxtLandofficevolumeCheckingexp"].value;
             var TxtNfees = document.forms["frmaccountsrealize"]["TxtNfees"].value;
             var TxtLocalgovtTax = document.forms["frmaccountsrealize"]["TxtLocalgovtTax"].value;
             var TxtStamp = document.forms["frmaccountsrealize"]["TxtStamp"].value;
             var TxtIncomeTax = document.forms["frmaccountsrealize"]["TxtIncomeTax"].value;
             var TxtGainTax = document.forms["frmaccountsrealize"]["TxtGainTax"].value;
             var TxtPayOrderExpense = document.forms["frmaccountsrealize"]["TxtPayOrderExpense"].value;
             //TxtSubRegisterCommission TxtDeedCertifiescopyExpance TxtMutionExpanse TxtOtherExpanse TxtTotalArealandMuted 
             //Txtjlno TxtHoldingNoJotNo TxtLandDevlopmentTaxExpance TxtBrokrCommission TxtTotalLandAccusitionCost
             var TxtSubRegisterCommission = document.forms["frmaccountsrealize"]["TxtSubRegisterCommission"].value;
             var TxtDeedCertifiescopyExpance = document.forms["frmaccountsrealize"]["TxtDeedCertifiescopyExpance"].value;
             var TxtMutionExpanse = document.forms["frmaccountsrealize"]["TxtMutionExpanse"].value;
             var TxtOtherExpanse = document.forms["frmaccountsrealize"]["TxtOtherExpanse"].value;
             var TxtTotalArealandMuted = document.forms["frmaccountsrealize"]["TxtTotalArealandMuted"].value;
             var Txtjlno = document.forms["frmaccountsrealize"]["Txtjlno"].value;
             var TxtHoldingNoJotNo = document.forms["frmaccountsrealize"]["TxtHoldingNoJotNo"].value;
             var TxtLandDevlopmentTaxExpance = document.forms["frmaccountsrealize"]["TxtLandDevlopmentTaxExpance"].value;
             var TxtBrokrCommission = document.forms["frmaccountsrealize"]["TxtBrokrCommission"].value;
             var TxtTotalLandAccusitionCost = document.forms["frmaccountsrealize"]["TxtTotalLandAccusitionCost"].value;







             if (TxtAssetLand == null || TxtAssetLand == "") {
                 alert("TxtAssetLand box must be filledd");
                 document.getElementById("TxtAssetLand").focus();
             }
             else if (TxtDescriptionLand == null || TxtDescriptionLand == "") {
                 alert("TxtDescriptionLand box must be filledd");
                 document.getElementById("TxtDescriptionLand").focus();
             }
             else if (LandPo == null || LandPo == "") {
                 alert("LandPo box must be filledd");
                 document.getElementById("LandPo").focus();
             }
             else if (TxtBuyer == null || TxtBuyer == "") {
                 alert("TxtBuyer box must be filledd");
                 document.getElementById("TxtBuyer").focus();
             }
             else if (TxtNameofSeller == null || TxtNameofSeller == "") {
                 alert("TxtNameofSeller box must be filledd");
                 document.getElementById("TxtNameofSeller").focus();
             }
             else if (TxtMouza == null || TxtMouza == "") {
                 alert("TxtMouza box must be filledd");
                 document.getElementById("TxtMouza").focus();
             }
             else if (TxtDeedReceoiptNo == null || TxtDeedReceoiptNo == "") {
                 alert("TxtDeedReceoiptNo box must be filledd");
                 document.getElementById("TxtDeedReceoiptNo").focus();
             }
             
             else if (TxtDeedNo == null || TxtDeedNo == "") {
                 alert("TxtDeedNo box must be filledd");
                 document.getElementById("TxtDeedNo").focus();
             }

             else if (TxtOrginalDeedReceiveDate == null || TxtOrginalDeedReceiveDate == "") {
                 alert("TxtOrginalDeedReceiveDate box must be filledd");
                 document.getElementById("TxtOrginalDeedReceiveDate").focus();
              }
             else if (TxtTotalArea == null || TxtTotalArea == "") {
                 alert("TxtTotalArea box must be filledd");
                 document.getElementById("TxtTotalArea").focus();
             }
             else if (TxtTotalArealandinDecimal == null || TxtTotalArealandinDecimal == "") {
                 alert("TxtTotalArealandinDecimal box must be filledd");
                 document.getElementById("TxtTotalArealandinDecimal").focus();
             }
             else if (TxtPricePerKatha == null || TxtPricePerKatha == "") {
                 alert("TxtPricePerKatha box must be filledd");
                 document.getElementById("TxtPricePerKatha").focus();
             }

             else if (TxtPriceperDecimal == null || TxtPriceperDecimal == "") {
                 alert("TxtPriceperDecimal box must be filledd");
                 document.getElementById("TxtPriceperDecimal").focus();
             }

             else if (TxtTotalValuelandTk == null || TxtTotalValuelandTk == "") {
                 alert("TxtTotalValuelandTk box must be filledd");
                 document.getElementById("TxtTotalValuelandTk").focus();
             }

             else if (TxtRegistryBainaAmount == null || TxtRegistryBainaAmount == "") {
                 alert("TxtRegistryBainaAmount box must be filledd");
                 document.getElementById("TxtRegistryBainaAmount").focus();
             }
             else if (TxtBalancelandValue == null || TxtBalancelandValue == "") {
                 alert("TxtBalancelandValue box must be filledd");
                 document.getElementById("TxtBalancelandValue").focus();
             }
             else if (TxtRegistrationExpance == null || TxtRegistrationExpance == "") {
                 alert("TxtRegistrationExpance box must be filledd");
                 document.getElementById("TxtRegistrationExpance").focus();
             }
             
             else if (TxtDeedValueLand == null || TxtDeedValueLand == "") {
                 alert("TxtDeedValueLand box must be filledd");
                 document.getElementById("TxtDeedValueLand").focus();
             }
             else if (TxtLandofficevolumeCheckingexp == null || TxtLandofficevolumeCheckingexp == "") {
                 alert("TxtLandofficevolumeCheckingexp box must be filledd");
                 document.getElementById("TxtLandofficevolumeCheckingexp").focus();
             }

             else if (TxtNfees == null || TxtNfees == "") {
                 alert("TxtNfees box must be filledd");
                 document.getElementById("TxtNfees").focus();
             }
             else if (TxtLocalgovtTax == null || TxtLocalgovtTax == "") {
                 alert("TxtLocalgovtTax box must be filledd");
                 document.getElementById("TxtLocalgovtTax").focus();
             }
             else if (TxtStamp == null || TxtStamp == "") {
                 alert("TxtStamp box must be filledd");
                 document.getElementById("TxtStamp").focus();
             }
             else if (TxtIncomeTax == null || TxtIncomeTax == "") {
                 alert("TxtIncomeTax box must be filledd");
                 document.getElementById("TxtIncomeTax").focus();
             }
             
             else if (TxtGainTax == null || TxtGainTax == "") {
                 alert("TxtGainTax box must be filledd");
                 document.getElementById("TxtGainTax").focus();
             }
             else if (TxtPayOrderExpense == null || TxtPayOrderExpense == "") {
                 alert("TxtPayOrderExpense box must be filledd");
                 document.getElementById("TxtPayOrderExpense").focus();
             }

             else if (TxtSubRegisterCommission == null || TxtSubRegisterCommission == "") {
                 alert("TxtSubRegisterCommission box must be filledd");
                 document.getElementById("TxtSubRegisterCommission").focus();
             }

             else if (TxtDeedCertifiescopyExpance == null || TxtDeedCertifiescopyExpance == "") {
                 alert("TxtDeedCertifiescopyExpance box must be filledd");
                 document.getElementById("TxtDeedCertifiescopyExpance").focus();
             }
             
             else if (TxtMutionExpanse == null || TxtMutionExpanse == "") {
                 alert("TxtMutionExpanse box must be filledd");
                 document.getElementById("TxtMutionExpanse").focus();
             }
             
             else if (TxtOtherExpanse == null || TxtOtherExpanse == "") {
                 alert("TxtOtherExpanse box must be filledd");
                 document.getElementById("TxtOtherExpanse").focus();
             }

             else if (TxtTotalArealandMuted == null || TxtTotalArealandMuted == "") {
                 alert("TxtTotalArealandMuted box must be filledd");
                 document.getElementById("TxtTotalArealandMuted").focus();
             }
             else if (Txtjlno == null || Txtjlno == "") {
                 alert("Txtjlno box must be filledd");
                 document.getElementById("Txtjlno").focus();
             }
             else if (TxtHoldingNoJotNo == null || TxtHoldingNoJotNo == "") {
                 alert("TxtHoldingNoJotNo box must be filledd");
                 document.getElementById("TxtHoldingNoJotNo").focus();
             }
             else if (TxtLandDevlopmentTaxExpance == null || TxtLandDevlopmentTaxExpance == "") {
                 alert("TxtLandDevlopmentTaxExpance box must be filledd");
                 document.getElementById("TxtLandDevlopmentTaxExpance").focus();
             }
             
             else if (TxtBrokrCommission == null || TxtBrokrCommission == "") {
                 alert("TxtBrokrCommission box must be filledd");
                 document.getElementById("TxtBrokrCommission").focus();
             }
             else if (TxtTotalLandAccusitionCost == null || TxtTotalLandAccusitionCost == "") {
                 alert("TxtTotalLandAccusitionCost box must be filledd");
                 document.getElementById("TxtTotalLandAccusitionCost").focus();
             }


             else {
                 var confirm_value = document.createElement("INPUT");
                 confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                 if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
                 else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
             }
         }

</script>

  <script>
        function RemoveRow(item) {
        var table = document.getElementById('GridView1');
        table.deleteRow(item.parentNode.parentNode.rowIndex);
        return false;
        }

    </script>
     <script type="text/javascript">
         $('input.required').each(function () {
             $(this).prev('label').after('*');
         });

    </script>

   
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
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1s" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
     <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnsearch" runat="server" />
    <asp:HiddenField ID="hdnEnrollUnit" runat="server" /><asp:HiddenField ID="hdnUnitIDByddl" runat="server" /><asp:HiddenField ID="hdnBankID" runat="server" />
                <asp:HiddenField ID="hdnApplicantEnrol" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="HiddenField1" runat="server"/><asp:HiddenField ID="hdnconfirm" runat="server" />
        
        <asp:HiddenField ID="HiddenUnit" runat="server"/>  
     
          
        
    <td>
          <asp:Button Text="General Registration" BorderStyle="Solid" ID="Tab1" CssClass="Initial" runat="server"
              OnClick="Tab1_Click" BackColor="#FFCC99" />
          <asp:Button Text="Vehicle Registration" BorderStyle="Solid" ID="Tab2" CssClass="Initial" runat="server"
                 BackColor="#FFCC99" OnClick="Tab2_Click"/>
          <asp:Button Text="Land Registration" BorderStyle="Solid" ID="Tab3" CssClass="Initial" runat="server"
            OnClick="Tab3_Click"  BackColor="#FFCC99" />
         <asp:Button Text="Building Registration" BorderStyle="Solid" ID="Tab4" CssClass="Initial" runat="server"
            OnClick="Tab4_Click"  BackColor="#FFCC99" />
          <asp:MultiView ID="MainView" runat="server">
            <asp:View ID="View1" runat="server">
              <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                <tr>
                  <td>
                    <h3>
                      <span>

                        
                   <table>
           <tr>
       <td style="text-align:right;"><asp:Label ID="Label105" CssClass="lbl" runat="server" Font-Size="small" Font-Bold="true"  Text="Procurement (Local & Foreign) : "></asp:Label></td>
          </tr>
        <tr>
                <td style="text-align:right;"><asp:Label ID="LblUnit" CssClass="lbl" runat="server" Text="Unit : "></asp:Label></td>
                <td><asp:DropDownList ID="DdlUnit" runat="server"  CssClass="dropdownList" OnSelectedIndexChanged="DdlUnit_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                <td style="text-align:right;"><asp:Label ID="LblJobStation" CssClass="lbl" runat="server" Text="Job Station : "></asp:Label></td>
                <td><asp:DropDownList ID="DlJobStation" runat="server" AutoPostBack="true" CssClass="dropdownList" OnSelectedIndexChanged="DlJobStation_SelectedIndexChanged"></asp:DropDownList>
                
                
               <td style="text-align:right;"><asp:Label ID="Label150" CssClass="lbl" runat="server" Text="Asset Type: "></asp:Label></td>
                <td><asp:DropDownList ID="DdlMainType" runat="server"  CssClass="dropdownList">
                     <asp:ListItem Text="Administrative"></asp:ListItem>
                    <asp:ListItem Text="Manufacturing"></asp:ListItem>
                    </asp:DropDownList> 
                </tr>
                 <tr>
                   <td style="text-align:right;"><asp:Label ID="LTypeblAsset" CssClass="lbl" runat="server" Text="Asset Class : "></asp:Label></td>
                <td><asp:DropDownList ID="DdlAssetType" runat="server"  CssClass="dropdownList"></asp:DropDownList>   
               
                    <td style="text-align:right;"><asp:Label ID="Label151" CssClass="lbl" runat="server" Text="Plant Name: "></asp:Label></td>
                <td><asp:DropDownList ID="DdlPlantF" runat="server"  CssClass="dropdownList"></asp:DropDownList> 
               
               <td style="text-align:right;"><asp:Label ID="LblCategory" CssClass="lbl" runat="server" Text="Asset Sub Class : "></asp:Label></td>
                <td><asp:DropDownList ID="DdlCategory" runat="server"  CssClass="dropdownList"></asp:DropDownList> 
                 </tr>

                <tr>
               
                <td style="text-align:right;"><asp:Label ID="Label152" CssClass="lbl" runat="server" Text="Cost Center: "></asp:Label></td>
                <td><asp:DropDownList ID="DdlCostCenterF" runat="server"  CssClass="dropdownList"></asp:DropDownList> 
                <td style="text-align:right;"><asp:Label ID="LblAssetName" CssClass="lbl" runat="server" Text="Name of Asset : "></asp:Label></td>
                <td><asp:TextBox ID="TxtAssetName" runat="server" CssClass="txtBox"  ></asp:TextBox></td>
               
                 <td style="text-align:right;"><asp:Label ID="LblAssetDescription" CssClass="lbl" runat="server" Text="Description of Asset : "></asp:Label></td>
                <td><asp:TextBox ID="TxtAssetDescription" runat="server" CssClass="txtBox"></asp:TextBox></td>
              
                   
                </tr>

                <tr>
               
                    <td style="text-align:right;"><asp:Label ID="LblHSCode" CssClass="lbl" runat="server" Text="HSCode : "></asp:Label></td>
                <td><asp:TextBox ID="TxtHSCode" runat="server" CssClass="txtBox"></asp:TextBox></td>
               

               <td style="text-align:right;"><asp:Label ID="LblManufacturer" CssClass="lbl" runat="server" Text="Name of Manufacturer : "></asp:Label></td>
                <td><asp:TextBox ID="TxtManufacturer" runat="server" CssClass="txtBox" ></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="LblContryOrigin" CssClass="lbl" runat="server" Text="Country of Origin : "></asp:Label></td>
                <td><asp:TextBox ID="TxtContryOrigin" runat="server" CssClass="txtBox"></asp:TextBox></td>
              
                </tr>
                 <tr>

                <td style="text-align:right;"><asp:Label ID="LblCountryManufacture" CssClass="lbl" runat="server" Text="Country of Manufacturing : "></asp:Label></td>
                <td><asp:TextBox ID="TxtCountryManufacture" runat="server" CssClass="txtBox"></asp:TextBox></td>
  
                 <td style="text-align:right;"><asp:Label ID="LblSuppName" CssClass="lbl" runat="server" Text="Supplier / Local Agent Name : "></asp:Label></td>
                <td><asp:TextBox ID="TxtSuppName" runat="server" CssClass="txtBox"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="LblLCNo" CssClass="lbl" runat="server" Text="LC Number : "></asp:Label></td>
                <td><asp:TextBox ID="TxtLCNo" runat="server" CssClass="txtBox"  ></asp:TextBox></td>
                       
                </tr>
               <tr>
                  
                <td style="text-align:right;"><asp:Label ID="LblDteLC" CssClass="lbl" runat="server" Text="LC Date : "></asp:Label></td>
                 <td><asp:TextBox ID="TxtDteLC" runat="server" CssClass="txtBox"  ></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDteLC">
                    </cc1:CalendarExtender> 
                   
                <td style="text-align:right;"><asp:Label ID="LblPONo" CssClass="lbl" runat="server" Text="Po Number : "></asp:Label></td>
                <td><asp:TextBox ID="TxtPONo" runat="server" CssClass="txtBox"  ></asp:TextBox></td>
                 <td style="text-align:right;"><asp:Label ID="LblDtePO" CssClass="lbl" runat="server" Text="Po Date : "></asp:Label></td>
                  <td><asp:TextBox ID="TxtDtePo" runat="server" CssClass="txtBox"  ></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDtePo">
                    </cc1:CalendarExtender> 
                </tr>
                 
                 <tr>
               
            <td style="text-align:right;"><asp:Label ID="LblWarrintyPreoid" CssClass="lbl" runat="server" Text="Warranty Expiry Date : "></asp:Label></td>
                
              <td><asp:TextBox ID="TxtDteWarranty" runat="server" CssClass="txtBox"  ></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDteWarranty">
                    </cc1:CalendarExtender> 
              
                     
              <td style="text-align:right;"><asp:Label ID="LblInvoice" CssClass="lbl" runat="server" Text="Invoice Value : "></asp:Label></td>
                <td><asp:TextBox ID="TxtInvoice" runat="server" CssClass="txtBox"  ></asp:TextBox></td>

               <td style="text-align:right;"><asp:Label ID="LblCurrency" CssClass="lbl" runat="server" Text="Currency : "></asp:Label></td>
                  <td><asp:DropDownList ID="DdlCurrency" runat="server"  CssClass="dropdownList">
                       <asp:ListItem>BDT</asp:ListItem>
                              <asp:ListItem>USD</asp:ListItem>
                              <asp:ListItem>EUR</asp:ListItem>
                            <asp:ListItem>JPY</asp:ListItem>
                              <asp:ListItem>GPD</asp:ListItem>
                          <asp:ListItem>AUD</asp:ListItem>
                              <asp:ListItem>KRW</asp:ListItem>
                       <asp:ListItem>RUB</asp:ListItem>
                              <asp:ListItem>CNY</asp:ListItem>
                      <asp:ListItem>HKD</asp:ListItem>
                              <asp:ListItem>INR</asp:ListItem>
                                   <asp:ListItem>ZNR</asp:ListItem>
                    
                      </asp:DropDownList> 
         
                 <td><asp:Button ID="Button2" runat="server" Text="Save" /></td>
               </tr>
             <tr>
                 
                  <td style="text-align:right;"><asp:Label ID="LblIncoterms" CssClass="lbl" runat="server" Text="Incoterms : "></asp:Label></td>
                  <td><asp:DropDownList ID="DdlInCoterms" runat="server"  CssClass="dropdownList">
                       <asp:ListItem>CFR (Ctg)</asp:ListItem>
                              <asp:ListItem>CPT (Dhaka)</asp:ListItem>
                              <asp:ListItem>FOB</asp:ListItem>
                      <asp:ListItem>Ex Factory</asp:ListItem>
                      <asp:ListItem>Ex Showroom</asp:ListItem>
                      </asp:DropDownList>
                      
                      <td style="text-align:right;">
                             <asp:Label ID="LblDteAcusition" runat="server" CssClass="lbl" Text="Date Of Acusition: "></asp:Label>
                         </td>
                         <td>
                             <asp:TextBox ID="TxtDteAcusition" runat="server" CssClass="txtBox"  ></asp:TextBox>
                             <cc1:CalendarExtender ID="dteAcusition" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDteAcusition">
                             </cc1:CalendarExtender> 
             </tr>
          
                <tr>
       <td style="text-align:right;"><asp:Label ID="Label109" CssClass="lbl" runat="server" Font-Size="Small"  Font-Bold="true" Text="Operation Of Factory: "></asp:Label></td>
           </tr>
        
                 <tr>
                     <td style="text-align:right;">
                         <asp:Label ID="LblInsLocation" runat="server" CssClass="lbl" Text="Installation Location: "></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="TxtInsLocation" runat="server" CssClass="txtBox"  ></asp:TextBox>
                     </td>
                     <td style="text-align:right;">
                         <asp:Label ID="LblManuProvideSl" runat="server" CssClass="lbl" Text="Manufacturer Provided SL No : "></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="TxtManuProvideSl" runat="server" CssClass="txtBox"  ></asp:TextBox>
                     </td>
                     <td style="text-align:right;">
                         <asp:Label ID="LblFunction" runat="server" CssClass="lbl" Text="Function of the Machine : "></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="TxtFunction" runat="server" CssClass="txtBox"   ></asp:TextBox>
                          </td>
                 </tr>
                 <tr>
                     <td style="text-align:right;">
                         <asp:Label ID="LblCapacity" runat="server" CssClass="lbl" Text="Rated Capacity: "></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="TxtCapacity" runat="server" CssClass="txtBox"></asp:TextBox>
                     </td>
                     <td style="text-align:right;">
                         <asp:Label ID="LblDteInstalation" runat="server" CssClass="lbl" Text="Date Of Installation : "></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="TxtDteInstalation" runat="server" CssClass="txtBox"  ></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDteInstalation">
                         </cc1:CalendarExtender>
                         <td style="text-align:right;">
                             <asp:Label ID="LblErectionCost" runat="server" CssClass="lbl" Text="Erection Installation Cost: "></asp:Label>
                         </td>
                         <td>
                             <asp:TextBox ID="TxtErectionCost" runat="server" CssClass="txtBox"  ></asp:TextBox>
                         </td>
                         <td>
                             <asp:Button ID="Button3" runat="server" Text="Save" />
                         </td>
                    
                 </tr>
               <tr>
                <td style="text-align:right;"><asp:Label ID="LblDepartment" CssClass="lbl" runat="server" Text="Department : "></asp:Label></td>
                <td><asp:DropDownList ID="DdlDept" runat="server"  CssClass="dropdownList"></asp:DropDownList> 
              
                      <td style="text-align:right;">
                                 <asp:Label ID="LblRecomandLife" runat="server" CssClass="lbl" Text="Recommand Life : "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtRecomandLife" runat="server" CssClass="txtBox"  ></asp:TextBox>
                             </td>
                             
                        <td style="text-align:right;">
                                 <asp:Label ID="Label153" runat="server" CssClass="lbl" Text="Model No : "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtFModel" runat="server" CssClass="txtBox"  ></asp:TextBox>
                             </td>
                        </tr>
                       <tr>
                           <td style="text-align:right;">
                                 <asp:Label ID="LblSalvageValue" runat="server" CssClass="lbl" Text="Estimation Salvage Value : "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtEstSalvageValue" runat="server" CssClass="txtBox"  ></asp:TextBox>
                             </td>
                       </tr>
               
                     <tr>
                         <td style="text-align:right;">
                             <asp:Label ID="Label110" runat="server" CssClass="lbl" Font-Size="Small"  Font-Bold="true" Text=" Accounts Department: "></asp:Label>
                         </td>
                     </tr>
                                     
             <tr>
                 <td style="text-align:right;">
                     <asp:Label ID="LblLandedCost" runat="server" CssClass="lbl" Text="Landed Cost: "></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="TxtLandedCost" runat="server" CssClass="txtBox"></asp:TextBox>
                 </td>
                 <td style="text-align:right;">
                     <asp:Label ID="LblAccumulatedCost" runat="server" CssClass="lbl" Text="Total Accumulated Cost: "></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="TxtTAccumulatedCost" runat="server" CssClass="txtBox"></asp:TextBox>
                 </td>
                 <td style="text-align:right;">
                     <asp:Label ID="LblRateDepeciation" runat="server" CssClass="lbl" Text="Rate of Depreciation: "></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="TxtRateDepeciation" runat="server" CssClass="txtBox"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td style="text-align:right;">
                     <asp:Label ID="LblAccumulatedDepreciatedValue" runat="server" CssClass="lbl" Text="Accumulated Depreciation: "></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="TxtAccumulatedDepreciation" runat="server" CssClass="txtBox"></asp:TextBox>
                 </td>
                 <td style="text-align:right;">
                     <asp:Label ID="LblMethodDepreciation" runat="server" CssClass="lbl" Text="Method of Depreciation: "></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="TxtMethodDepreciation" runat="server" CssClass="txtBox"></asp:TextBox>
                 </td>
                 <td style="text-align:right;">
                     <asp:Label ID="LblvalueAfterDepreciation" runat="server" CssClass="lbl" Text="Value after Depreciation: "></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="TxtValueDepreciation" runat="server" CssClass="txtBox"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td style="text-align:right;">
                     <asp:Label ID="LblWrittenDownValue" runat="server" CssClass="lbl" Text="Written DownValue : "></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="TxtWrittenDownValue" runat="server" CssClass="txtBox"></asp:TextBox>
                 </td>
                 <td style="text-align:right;">
                     <asp:Label ID="LblRemarks" runat="server" CssClass="lbl" Text="Remarks : "></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="TxtRemarks" runat="server" CssClass="txtBox"></asp:TextBox>
                 </td>
                </tr>
                  <tr>
                 
                     
                      
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td style="text-align:right;">
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click"  Text="Save" Width="128px" />
                        </td>
                    </tr>                   
             </table>
              <table>
                    
                    <tr>
                        <td>
                            <asp:PlaceHolder ID="plBarCode" runat="server" />
                        </td>
                    </tr>
                </table>

                      </span>
                    </h3>
                  </td>
                </tr>
              </table>
                </span></h3>
                
                <%--//Vehicle Registration TAB--%>
               
                
               </asp:View>
                      <asp:View ID="View2" runat="server">
              <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                <tr>
                  <td>
                    <h3>
                        <span>     
         <table>
     <%--//**********************************************Vehicle Registration TAB***********************************************************--%>


                     <tr>
                     <td style="text-align:right;">
                         <asp:Label ID="Label108" runat="server" CssClass="lbl" Font-Size="Small" Font-Bold="true"  Text=" Procurement (Local & Foreign: "></asp:Label>
                     </td></tr>
             <tr>
                 <td style="text-align: right;">
                     <asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Unit : "></asp:Label></td>
                 <td>
                     <asp:DropDownList ID="ddlUnits" runat="server" CssClass="dropdownList" AutoPostBack="True" OnSelectedIndexChanged="ddlUnits_SelectedIndexChanged"></asp:DropDownList>
                 <td style="text-align: right;">
                     <asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Job Station : "></asp:Label></td>
                 <td>
                     <asp:DropDownList ID="Ddljob" runat="server" AutoPostBack="true" CssClass="dropdownList" OnSelectedIndexChanged="Ddljob_SelectedIndexChanged"></asp:DropDownList>

                 <td style="text-align: right;">
                     <asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Asset Type : "></asp:Label></td>
                 <td>
                     <asp:DropDownList ID="DdlAsetTypes" runat="server" CssClass="dropdownList"></asp:DropDownList>
             </tr>
             <tr>

                 <td style="text-align: right;">
                     <asp:Label ID="Label5" CssClass="lbl" runat="server" Text="Vehicle Type : "></asp:Label></td>
                 <td>
                     <asp:DropDownList ID="DdlAssetCate" runat="server" CssClass="dropdownList"></asp:DropDownList>

               <td style="text-align: right;">
                     <asp:Label ID="Label132" CssClass="lbl" runat="server" Text="Exixting Vehicle : "></asp:Label></td>
                 <td>
                     <asp:DropDownList ID="DdlExixtingVehicle" runat="server" CssClass="dropdownList"></asp:DropDownList>
                      <td style="text-align: right;">
                     <asp:Label ID="Label144" CssClass="lbl" runat="server" Text="City/Area : "></asp:Label></td>
                 <td>
                     <asp:DropDownList ID="DvehicleArea" runat="server" CssClass="dropdownList"></asp:DropDownList>

            
                 </tr>
             <tr>

                <td style="text-align: right;">
                     <asp:Label ID="Label55" CssClass="lbl" runat="server" Text="Indentifier : "></asp:Label></td>
                 <td>
                     <asp:DropDownList ID="Ddlindentity" runat="server" CssClass="dropdownList">
                        
                     </asp:DropDownList> 

                 
                <td style="text-align: right;">
                     <asp:Label ID="Label145" CssClass="lbl" runat="server" Text="Serial Number: "></asp:Label></td>
                 <td>
                     <asp:DropDownList ID="ddlBeginNo" runat="server" CssClass="dropdownList">
                       <asp:ListItem>00</asp:ListItem>
                         <asp:ListItem>01</asp:ListItem><asp:ListItem>02</asp:ListItem><asp:ListItem>03</asp:ListItem><asp:ListItem>04</asp:ListItem>
                         <asp:ListItem>05</asp:ListItem><asp:ListItem>06</asp:ListItem><asp:ListItem>07</asp:ListItem><asp:ListItem>08</asp:ListItem>
                         <asp:ListItem>09</asp:ListItem><asp:ListItem>10</asp:ListItem><asp:ListItem>11</asp:ListItem><asp:ListItem>12</asp:ListItem>
                         <asp:ListItem>13</asp:ListItem><asp:ListItem>14</asp:ListItem><asp:ListItem>15</asp:ListItem><asp:ListItem>16</asp:ListItem>
                         <asp:ListItem>17</asp:ListItem><asp:ListItem>18</asp:ListItem><asp:ListItem>19</asp:ListItem><asp:ListItem>20</asp:ListItem>
                         <asp:ListItem>21</asp:ListItem><asp:ListItem>32</asp:ListItem><asp:ListItem>23</asp:ListItem><asp:ListItem>24</asp:ListItem>
                         <asp:ListItem>25</asp:ListItem><asp:ListItem>26</asp:ListItem><asp:ListItem>27</asp:ListItem><asp:ListItem>28</asp:ListItem>
                         <asp:ListItem>29</asp:ListItem><asp:ListItem>30</asp:ListItem><asp:ListItem>31</asp:ListItem><asp:ListItem>32</asp:ListItem>
                         <asp:ListItem>33</asp:ListItem><asp:ListItem>34</asp:ListItem><asp:ListItem>35</asp:ListItem><asp:ListItem>36</asp:ListItem>
                         <asp:ListItem>37</asp:ListItem><asp:ListItem>38</asp:ListItem><asp:ListItem>39</asp:ListItem><asp:ListItem>40</asp:ListItem>
                         <asp:ListItem>41</asp:ListItem><asp:ListItem>42</asp:ListItem><asp:ListItem>43</asp:ListItem><asp:ListItem>44</asp:ListItem>
                         <asp:ListItem>45</asp:ListItem><asp:ListItem>46</asp:ListItem><asp:ListItem>47</asp:ListItem><asp:ListItem>48</asp:ListItem>
                         <asp:ListItem>49</asp:ListItem><asp:ListItem>50</asp:ListItem><asp:ListItem>51</asp:ListItem><asp:ListItem>52</asp:ListItem>
                          <asp:ListItem>53</asp:ListItem><asp:ListItem>54</asp:ListItem><asp:ListItem>55</asp:ListItem><asp:ListItem>56</asp:ListItem>
                         <asp:ListItem>57</asp:ListItem><asp:ListItem>58</asp:ListItem><asp:ListItem>59</asp:ListItem><asp:ListItem>60</asp:ListItem>
                         <asp:ListItem>61</asp:ListItem><asp:ListItem>62</asp:ListItem><asp:ListItem>63</asp:ListItem><asp:ListItem>64</asp:ListItem>
                         <asp:ListItem>65</asp:ListItem><asp:ListItem>66</asp:ListItem><asp:ListItem>67</asp:ListItem><asp:ListItem>68</asp:ListItem>
                         <asp:ListItem>69</asp:ListItem><asp:ListItem>70</asp:ListItem><asp:ListItem>71</asp:ListItem><asp:ListItem>72</asp:ListItem>
                         <asp:ListItem>73</asp:ListItem><asp:ListItem>74</asp:ListItem><asp:ListItem>75</asp:ListItem><asp:ListItem>76</asp:ListItem>
                         <asp:ListItem>77</asp:ListItem><asp:ListItem>78</asp:ListItem><asp:ListItem>79</asp:ListItem><asp:ListItem>80</asp:ListItem>
                         <asp:ListItem>81</asp:ListItem><asp:ListItem>82</asp:ListItem><asp:ListItem>83</asp:ListItem><asp:ListItem>84</asp:ListItem>
                         <asp:ListItem>85</asp:ListItem><asp:ListItem>86</asp:ListItem><asp:ListItem>87</asp:ListItem><asp:ListItem>88</asp:ListItem>
                         <asp:ListItem>89</asp:ListItem><asp:ListItem>90</asp:ListItem><asp:ListItem>91</asp:ListItem><asp:ListItem>92</asp:ListItem>
                         <asp:ListItem>93</asp:ListItem><asp:ListItem>94</asp:ListItem><asp:ListItem>95</asp:ListItem><asp:ListItem>96</asp:ListItem>
                         <asp:ListItem>97</asp:ListItem><asp:ListItem>98</asp:ListItem><asp:ListItem>99</asp:ListItem>
                    
                    
                    
                          </asp:DropDownList> 

                 <td style="text-align: right;">
                     <asp:Label ID="Label4" CssClass="lbl" runat="server" Text="End Number : "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtVechilReg" runat="server" CssClass="txtBox"  ></asp:TextBox></td>
                     
                 
             </tr>
             

             <tr>
                 <td style="text-align: right;">
                     <asp:Label ID="Label7" CssClass="lbl" runat="server" Text="Description of Vehicle : "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtDscVechile" runat="server" CssClass="txtBox"></asp:TextBox></td>


                 <td style="text-align: right;">
                     <asp:Label ID="Label8" CssClass="lbl" runat="server" Text="Name of Manufacturer : "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtManuFactrurer" runat="server" CssClass="txtBox"></asp:TextBox></td>
                 <td style="text-align: right;">
                     <asp:Label ID="Label9" CssClass="lbl" runat="server" Text="Country of Origin : "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtOrigin" runat="server" CssClass="txtBox"></asp:TextBox></td>

             </tr>
             <tr>

                 <td style="text-align: right;">
                     <asp:Label ID="Label10" CssClass="lbl" runat="server" Text="Country of Manufacturing : "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtCountryManu" runat="server" CssClass="txtBox"></asp:TextBox></td>

                 <td style="text-align: right;">
                     <asp:Label ID="Label11" CssClass="lbl" runat="server" Text="Supplier / Local Agent Name : "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtSupplier" runat="server" CssClass="txtBox"></asp:TextBox></td>
                 <%--<td style="text-align:right;"><asp:Label ID="LblMachineQty" CssClass="lbl" runat="server" Text="Qty. Of Machine: "></asp:Label></td>
                <td><asp:TextBox ID="TxtMachineQty" runat="server" CssClass="txtBox"></asp:TextBox></td>
                 --%>
                 <td style="text-align: right;">
                     <asp:Label ID="Label12" CssClass="lbl" runat="server" Text="LC Number : "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtLcNumbers" runat="server" CssClass="txtBox"  ></asp:TextBox></td>

             </tr>
             <tr>

                 <td style="text-align: right;">
                     <asp:Label ID="Label13" CssClass="lbl" runat="server" Text="LC Date : "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtDteVLcDate" runat="server" CssClass="txtBox"  ></asp:TextBox>
                     <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDteVLcDate">
                     </cc1:CalendarExtender>
                 </td>

                 <td style="text-align: right;">
                     <asp:Label ID="Label14" CssClass="lbl" runat="server" Text="Po Number : "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtPonumber" runat="server" CssClass="txtBox"  ></asp:TextBox></td>
                 <td style="text-align: right;">
                     <asp:Label ID="Label15" CssClass="lbl" runat="server" Text="Po Date : "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtVPoDate" runat="server" CssClass="txtBox"  ></asp:TextBox>
                     <cc1:CalendarExtender ID="CalendarExtender6" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtVPoDate">
                     </cc1:CalendarExtender>
             </tr>

             <tr>

                 <td style="text-align: right;">
                     <asp:Label ID="Label16" CssClass="lbl" runat="server" Text="Warranty Expiry Date : "></asp:Label></td>

                 <td>
                     <asp:TextBox ID="TxtDteVWarranty" runat="server" CssClass="txtBox"></asp:TextBox>
                     <cc1:CalendarExtender ID="CalendarExtender7" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDteVWarranty">
                     </cc1:CalendarExtender>


                     <td style="text-align: right;">
                         <asp:Label ID="Label17" CssClass="lbl" runat="server" Text="Invoice Value : "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtInvoices" runat="server" CssClass="txtBox"></asp:TextBox></td>

                 <td style="text-align: right;">
                     <asp:Label ID="Label18" CssClass="lbl" runat="server" Text="Currency : "></asp:Label></td>
                 <td>
                     <asp:DropDownList ID="DdlCurrencys" runat="server" CssClass="dropdownList">
                         <asp:ListItem>BDT</asp:ListItem>
                         <asp:ListItem>USD</asp:ListItem>
                         <asp:ListItem>EUR</asp:ListItem>
                         <asp:ListItem>JPY</asp:ListItem>
                         <asp:ListItem>GPD</asp:ListItem>
                         <asp:ListItem>AUD</asp:ListItem>
                         <asp:ListItem>KRW</asp:ListItem>
                         <asp:ListItem>RUB</asp:ListItem>
                         <asp:ListItem>CNY</asp:ListItem>
                         <asp:ListItem>HKD</asp:ListItem>
                         <asp:ListItem>INR</asp:ListItem>
                         <asp:ListItem>ZNR</asp:ListItem>

                     </asp:DropDownList>
             </tr>
             <tr>

                 <td style="text-align: right;">
                     <asp:Label ID="Label19" CssClass="lbl" runat="server" Text="Incoterms : "></asp:Label></td>
                 <td>
                     <asp:DropDownList ID="DdlIncotermsd" runat="server" CssClass="dropdownList">
                         <asp:ListItem>CFR (Ctg)</asp:ListItem>
                         <asp:ListItem>CPT (Dhaka)</asp:ListItem>
                         <asp:ListItem>FOB</asp:ListItem>
                         <asp:ListItem>Ex Factory</asp:ListItem>
                         <asp:ListItem>Ex Showroom</asp:ListItem>
                     </asp:DropDownList>

                 <td style="text-align: right;">
                     <asp:Label ID="Label20" runat="server" CssClass="lbl" Text="Date Of Acusition: "></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="TxtDteAccusition" runat="server" CssClass="txtBox"  ></asp:TextBox>
                     <cc1:CalendarExtender ID="CalendarExtender8" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDteAccusition">
                     </cc1:CalendarExtender>

                     <td style="text-align: right;">
                         <asp:Label ID="Label50" CssClass="lbl" runat="server" Text="Service Type : "></asp:Label></td>
                 <td>
                     <asp:DropDownList ID="DdlServiceType" runat="server" CssClass="dropdownList">
                         <asp:ListItem>Transport</asp:ListItem>
                         <asp:ListItem>passenger </asp:ListItem>
                     </asp:DropDownList>
             </tr>
             <tr>
                 <td style="text-align: right;">
                     <asp:Label ID="Label6" CssClass="lbl" runat="server" Text="HSCode : "></asp:Label></td>
                 
                   <td>  <asp:TextBox ID="TxtHSCodes" runat="server" CssClass="txtBox"></asp:TextBox></td>

                    <%-- <td><asp:Label ID="lblBRTAType" runat="server" CssClass="lbl" Text="BRTA Type: "></asp:Label></td> 
                      <td> <asp:DropDownList ID="ddlBrtaType" runat="server" CssClass="dropdownList">  </asp:DropDownList></td>
                 <td><asp:Label ID="lbluseJobstation" runat="server" CssClass="lbl" Text="BRTA Type: "></asp:Label></td> 
                  <td> <asp:DropDownList ID="ddlInUseJobstation" runat="server" CssClass="dropdownList">  </asp:DropDownList></td>
                --%>            
                       
                     

             </tr>

             <tr>
                  <td style="text-align:right;">
                      <asp:Label ID="Label106" runat="server" CssClass="lbl" Font-Size="Small" Font-Bold="true"  Text="Operation Of Factory: "></asp:Label>
                  </td>
                 <tr>
                     <td style="text-align: right;">
                         <asp:Label ID="Label21" runat="server" CssClass="lbl" Text="Brand Name: "></asp:Label>
                     </td>

                     <td>
                         <asp:DropDownList ID="DdlBrand" runat="server" CssClass="dropdownList">
                            
                         </asp:DropDownList>
                     </td>
                     <td style="text-align: right;">
                         <asp:Label ID="Label22" runat="server" CssClass="lbl" Text="Model Name: "></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="TxtModel" runat="server" CssClass="txtBox"  ></asp:TextBox>
                     </td>
                      <td style="text-align: right;">
                         <asp:Label ID="Label49" runat="server" CssClass="lbl" Text="Year of Model: "></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="TxtModelYear" runat="server"  TextMode="Number" CssClass="txtBox"  ></asp:TextBox>
                     </td>
                       
                     
                 </tr>
                 <tr>
                     <td style="text-align: right;">
                         <asp:Label ID="Label23" runat="server" CssClass="lbl" Text="CC: "></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="TxtCC" runat="server" CssClass="txtBox"  ></asp:TextBox>
                     </td>


                     <td style="text-align: right;">
                         <asp:Label ID="Label24" runat="server" CssClass="lbl" Text="Color: "></asp:Label>
                     </td>
                     <td>
                         <asp:DropDownList ID="DDlColor" runat="server" CssClass="dropdownList">
                             <asp:ListItem>White</asp:ListItem>
                             <asp:ListItem>Black</asp:ListItem>
                             <asp:ListItem>Red</asp:ListItem>
                             <asp:ListItem>Yellow</asp:ListItem>
                             <asp:ListItem>Brown</asp:ListItem>
                             <asp:ListItem>Multi Color</asp:ListItem>
                             <asp:ListItem>Gray</asp:ListItem>
                             <asp:ListItem>Blue</asp:ListItem>
                             <asp:ListItem>Maroon</asp:ListItem>
                             <asp:ListItem>Perl</asp:ListItem> 
                             <asp:ListItem>White Perl</asp:ListItem>
                             <asp:ListItem>Silver</asp:ListItem>
                              <asp:ListItem>Beige</asp:ListItem>
                             
                         </asp:DropDownList>
                     </td>
                     <td style="text-align: right;">
                         <asp:Label ID="Label25" runat="server" CssClass="lbl" Text="Engine No : "></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="TxtEngine" runat="server" CssClass="txtBox"  ></asp:TextBox>
                          
                 </tr>

                 <tr>

                     <td style="text-align: right;">
                             <asp:Label ID="Label26" runat="server" CssClass="lbl" Text="Chassis No: "></asp:Label>
                         </td>
                         <td>
                             <asp:TextBox ID="TxtCassis" runat="server" CssClass="txtBox"  ></asp:TextBox>
                         </td>

                     <td style="text-align: right;">
                         <asp:Label ID="Label38" runat="server" CssClass="lbl" Text="Initial mileage: "></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="TxtInitialM" runat="server" CssClass="txtBox"></asp:TextBox>
                     </td>

                     <td style="text-align: right;">
                         <asp:Label ID="Label39" runat="server" CssClass="lbl" Text="Fuel Status : "></asp:Label>
                     </td>


                     
                     <td>
                     <asp:DropDownList ID="DdlFuelStatus" runat="server" CssClass="dropdownList">
                     <asp:ListItem>CNG</asp:ListItem>
                         <asp:ListItem>Petrol </asp:ListItem>
                        <asp:ListItem>Diesel </asp:ListItem>
                        <asp:ListItem>Octen </asp:ListItem>
                          <asp:ListItem>CNG+Diesel  </asp:ListItem>
                         <asp:ListItem>CNG+Octen </asp:ListItem>
                          <asp:ListItem>CNG+Petrol </asp:ListItem>
                     </asp:DropDownList>

                     
                 </tr>
                 <tr>
                     <td style="text-align: right;">
                             <asp:Label ID="Label28" runat="server" CssClass="lbl" Text="Recommand Life : "></asp:Label>
                         </td>
                         <td>
                             <asp:TextBox ID="TxtRecommand" runat="server" CssClass="txtBox"  ></asp:TextBox>
                         </td>

                     <td style="text-align: right;">
                         <asp:Label ID="Label41" runat="server" CssClass="lbl" Text="UnladanWeight: "></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="TxtUnladanW" runat="server" CssClass="txtBox"></asp:TextBox>
                     </td>
                     <td style="text-align: right;">
                         <asp:Label ID="Label42" runat="server" CssClass="lbl" Text="Laden Weight : "></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="TxtladenW" runat="server" CssClass="txtBox"  ></asp:TextBox>
                        
                 </tr>
                 <tr>
                     <td style="text-align: right;">
                             <asp:Label ID="Label43" runat="server" CssClass="lbl" Text="Registration Date : "></asp:Label>
                         </td>
                         <td>

                             <asp:TextBox ID="TxtDteReg" runat="server" CssClass="txtBox"></asp:TextBox>
                             <cc1:CalendarExtender ID="CalendarExtender14" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDteReg">
                             </cc1:CalendarExtender>
                         </td>

                     <td style="text-align: right;">
                         <asp:Label ID="Label44" runat="server" CssClass="lbl" Text="Tax Token Validity: "></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="TxtDteToken" runat="server" CssClass="txtBox"></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender10" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDteToken">
                         </cc1:CalendarExtender>
                     </td>


                     <td style="text-align: right;">
                         <asp:Label ID="Label46" runat="server" CssClass="lbl" Text="Fitness Validity: "></asp:Label>
                     </td>
                     <td>

                         <asp:TextBox ID="TxtDteFitness" runat="server" CssClass="txtBox"></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender11" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDteFitness">
                         </cc1:CalendarExtender>
                     </td>

                    

                 </tr>

                 <tr>
                      <td style="text-align: right;">
                         <asp:Label ID="Label45" runat="server" CssClass="lbl" Text="Insurance Name: "></asp:Label>
                     </td>
                     <td>
                         
                         <asp:DropDownList ID="DdlInsurance" runat="server" CssClass="dropdownList">
                     <asp:ListItem>Rupali</asp:ListItem>
                         
                     </asp:DropDownList>
                     </td>

                <td style="text-align: right;">
                             <asp:Label ID="Label146" runat="server" CssClass="lbl" Text=" Policy Number : "></asp:Label>
                         </td>
                         <td>
                             <asp:TextBox ID="Txtpolicy" runat="server" CssClass="txtBox"  ></asp:TextBox>
                         </td>
                         <td style="text-align: right;">
                             <asp:Label ID="Label147" runat="server" CssClass="lbl" Text="Policy Type : "></asp:Label>
                         </td>
                         <td>
                         
                         <asp:DropDownList ID="DdlpolicyType" runat="server" CssClass="dropdownList">
                     <asp:ListItem>First Party</asp:ListItem>
                        <asp:ListItem>Second Party</asp:ListItem>
                             <asp:ListItem>Third Party</asp:ListItem> 
                     </asp:DropDownList></td>


                    
                    
                 </tr>

                 <tr>
                     <td style="text-align: right;">
                         <asp:Label ID="Label48" runat="server" CssClass="lbl" Text="Insurance Validity Date : "></asp:Label>
                     </td>
                     <td>

                         <asp:TextBox ID="TxtDteInsurance" runat="server" CssClass="txtBox"></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender12" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDteInsurance">
                         </cc1:CalendarExtender>
                     </td>

                     <td style="text-align: right;">
                         <asp:Label ID="Label47" runat="server" CssClass="lbl" Text="Root Permit Validity: "></asp:Label>
                     </td>
                     <td>

                         <asp:TextBox ID="TxtDteRoot" runat="server" CssClass="txtBox"></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender13" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDteRoot">
                         </cc1:CalendarExtender>
                     </td>


                     <td style="text-align: right;">
                         <asp:Label ID="Label27" CssClass="lbl" runat="server" Text="Department : "></asp:Label></td>
                     <td>
                         <asp:DropDownList ID="DdlDepartments" runat="server" CssClass="dropdownList"></asp:DropDownList>
                          
                 </tr>
                <tr>
                  <td style="text-align: right;">
                         <asp:Label ID="Label40" runat="server" CssClass="lbl" Text="User Enroll: "></asp:Label></td>

                     <td>
                          
                         <asp:TextBox ID="txtUser" runat="server" CssClass="txtBox"></asp:TextBox></td>

                         <td style="text-align: right;">
                             <asp:Label ID="Label29" runat="server" CssClass="lbl" Text="Estimation Salvage Value : "></asp:Label>
                         </td>
                         <td>
                             <asp:TextBox ID="TxtEstSalvase" runat="server" CssClass="txtBox"  ></asp:TextBox>
                         </td>
                
             </tr>


                 <tr>
                     <td style="text-align:right;">
                         <asp:Label ID="Label107" runat="server" CssClass="lbl" Font-Size="Small" Font-Bold="true" Text="Accounts Department: "></asp:Label>
                     </td></tr>
                 <tr>
                  <td style="text-align:right;">
                      <asp:Label ID="Label30" runat="server" CssClass="lbl" Text="Landed Cost: "></asp:Label>
                  </td>
                     <td>
                         <asp:TextBox ID="TxtLandedCosts" runat="server" CssClass="txtBox"></asp:TextBox>
                     </td>
                     <td style="text-align: right;">
                         <asp:Label ID="Label31" runat="server" CssClass="lbl" Text="Total Accumulated Cost: "></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="Txttotalcost" runat="server" CssClass="txtBox"></asp:TextBox>
                     </td>
                     <td style="text-align: right;">
                         <asp:Label ID="Label32" runat="server" CssClass="lbl" Text="Rate of Depreciation: "></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="TxtRateDepriciation" runat="server" CssClass="txtBox"></asp:TextBox>
                     </td>
                     <tr>
                         <td style="text-align: right;">
                             <asp:Label ID="Label33" runat="server" CssClass="lbl" Text="Accumulated Depreciation: "></asp:Label>
                         </td>
                         <td>
                             <asp:TextBox ID="TxtTotalAccumatleted" runat="server" CssClass="txtBox"></asp:TextBox>
                         </td>
                         <td style="text-align: right;">
                             <asp:Label ID="Label34" runat="server" CssClass="lbl" Text="Method of Depreciation: "></asp:Label>
                         </td>
                         <td>
                             <asp:TextBox ID="TxtMethode" runat="server" CssClass="txtBox"></asp:TextBox>
                         </td>
                         <td style="text-align: right;">
                             <asp:Label ID="Label35" runat="server" CssClass="lbl" Text="Value after Depreciation: "></asp:Label>
                         </td>
                         <td>
                             <asp:TextBox ID="TxtValueAfterDep" runat="server" CssClass="txtBox"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td style="text-align: right;">
                             <asp:Label ID="Label36" runat="server" CssClass="lbl" Text="Written DownValue : "></asp:Label>
                         </td>
                         <td>
                             <asp:TextBox ID="TxtWritenDownValue" runat="server" CssClass="txtBox"></asp:TextBox>
                         </td>
                         <td style="text-align: right;">
                             <asp:Label ID="Label37" runat="server" CssClass="lbl" Text="Remarks : "></asp:Label>
                         </td>
                         <td>
                             <asp:TextBox ID="TxtRemarksd" runat="server" CssClass="txtBox"></asp:TextBox>
                         </td>
                     </tr>
               
                            
               <tr>
                <td></td><td></td><td></td><td></td><td style="text-align:right;"><asp:Button ID="BtnVSave" runat="server" Text="Save"  Width="128px" OnClick="BtnVechileSave_Click"  /> </td>
                
                 </tr>
          
         </table>


            <table>
           
                
               
                
                 <tr>
                    
                     <td>
                         <asp:PlaceHolder ID="PlaceHolder2" runat="server" />
                     </td>
                 </tr>
                
               
                
             </table>
                  </span>
                    </h3>
                  </td>
                </tr>
              </table>
            </asp:View>
              
            <asp:View ID="View3" runat="server">
              <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                <tr>
                  <td>
                    <h3>
                        <span>
                     
<%--//**********************************************Land Registration TAB***********************************************************--%>

       
         
         
      <div>
         <table>

            <tr>
                <td style="text-align:right;"><asp:Label ID="Label51" CssClass="lbl" runat="server" Text="Unit : "></asp:Label></td>
                <td><asp:DropDownList ID="DdlUnitLand" runat="server"  CssClass="dropdownList" OnSelectedIndexChanged="DdlUnitLand_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                <td style="text-align:right;"><asp:Label ID="Label52" CssClass="lbl" runat="server" Text="Job Station : "></asp:Label></td>
                <td><asp:DropDownList ID="DdlJobland" runat="server" AutoPostBack="true" CssClass="dropdownList" ></asp:DropDownList>
                
                <td style="text-align:right;"><asp:Label ID="Label53" CssClass="lbl" runat="server" Text="Asset Type : "></asp:Label></td>
                <td><asp:DropDownList ID="DdlAssetLand" runat="server" autoPostback="true"  CssClass="dropdownList"></asp:DropDownList> 
               
                </tr>

                <tr>
               
                <td style="text-align:right;"><asp:Label ID="Label54" CssClass="lbl" runat="server" Text="Name of Asset : "></asp:Label></td>
                <td><asp:TextBox ID="TxtAssetLand" runat="server" CssClass="txtBox"  ></asp:TextBox></td>
               
               
                <td style="text-align:right;"><asp:Label ID="Label56" CssClass="lbl" runat="server" Text="Description of Asset: "></asp:Label></td>
                <td><asp:TextBox ID="TxtDescriptionLand" runat="server" CssClass="txtBox"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="Label57" CssClass="lbl" runat="server" Text="Land PO : "></asp:Label></td>
                <td><asp:TextBox ID="LandPo" runat="server" CssClass="txtBox"></asp:TextBox></td>
               
                </tr>

                <tr>
               

               <td style="text-align:right;"><asp:Label ID="Label58" CssClass="lbl" runat="server" Text="Land Buyer Name: "></asp:Label></td>
                <td><asp:TextBox ID="TxtBuyer" runat="server" CssClass="txtBox" ></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="Label59" CssClass="lbl" runat="server" Text="Name of Seller : "></asp:Label></td>
                <td><asp:TextBox ID="TxtNameofSeller" runat="server" CssClass="txtBox"></asp:TextBox></td>
              
                    <td style="text-align:right;"><asp:Label ID="Label60" CssClass="lbl" runat="server" Text="Class of Land : "></asp:Label></td>
                <td><asp:DropDownList ID="DdlClass" runat="server"  CssClass="dropdownList">
        
                              <asp:ListItem>Vita</asp:ListItem>
                              <asp:ListItem>Nali</asp:ListItem>
                      <asp:ListItem>Doba</asp:ListItem>
                      <asp:ListItem>Pokur</asp:ListItem>

                    </asp:DropDownList> 
                </tr>
                 <tr>
                      
                 <td style="text-align:right;"><asp:Label ID="Label61" CssClass="lbl" runat="server" Text="Districts: "></asp:Label></td>
                <td><asp:DropDownList ID="Ddldistrict" runat="server" Font-Size="Medium" CssClass="dropdownList" AutoPostBack="true" OnSelectedIndexChanged="Ddldistrict_SelectedIndexChanged"></asp:DropDownList> </td>
                <td style="text-align:right;"><asp:Label ID="Label62" CssClass="lbl" runat="server" Text="Thana : "></asp:Label></td>
                <td><asp:DropDownList ID="DDlThana" runat="server" Font-Size="Medium"   CssClass="dropdownList"></asp:DropDownList> 
                
                 
                    </td>

                       <td style="text-align:right;"><asp:Label ID="Label64" CssClass="lbl" runat="server" Text="Type for Land status  : "></asp:Label></td>
                     <td style="text-align:left; font-size:11px;">
                    
                      <asp:DropDownList ID="drdlDagforland" runat="server"  CssClass="dropdownList" DataSourceID="odsDagDetaills" DataTextField="strDagName" DataValueField="intID" OnSelectedIndexChanged="drdlDagforland_SelectedIndexChanged">
                      
                      </asp:DropDownList>
                      <asp:ObjectDataSource ID="odsDagDetaills" runat="server" SelectMethod="GetDataDagCategory" TypeName="Purchase_BLL.VehicleRegRenewal_BLL.RegistrationRenewals_BLL"></asp:ObjectDataSource>
                </td>
                </tr>
               <tr>
                  
                         
               

                    <td style="text-align:right">
                        <asp:Label ID="Labeldagcs" runat="server" CssClass="lbl" Text="DAG CS:  "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtdagcs" runat="server" CssClass="txtBox" TextMode="Number"></asp:TextBox>
                        <span style="color:red">*</span></td>
                    <td style="text-align:right">
                        <asp:Label ID="Labeldagsa" runat="server" CssClass="lbl" Text="DAG SA:  "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtdagsa" runat="server" CssClass="txtBox" OnTextChanged="txtdagsa_TextChanged" TextMode="Number"></asp:TextBox>
                    </td>
                    <td style="text-align:right">
                        <asp:Label ID="Labeldagrs" runat="server" CssClass="lbl" Text="DAG RS:  "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtdagrs" runat="server" CssClass="txtBox" OnTextChanged="txtdagrs_TextChanged" TextMode="Number"></asp:TextBox>
                    </td>
           
             <tr>
                  <td style="text-align:right"><asp:Label ID="Labeldagbrs" CssClass="lbl" runat="server" Text="DAG BRS:  " ></asp:Label></td>   
            <td> <asp:TextBox ID="txtdagbrs" runat="server"  TextMode="Number" CssClass="txtBox" OnTextChanged="txtdagbrs_TextChanged"></asp:TextBox></td> 
            <td style="text-align:right"><asp:Label ID="lblkhatiancs" CssClass="lbl" runat="server" Text="Khatian CS:  " ></asp:Label></td>
            <td> <asp:TextBox ID="txtkhatiancs" runat="server"  TextMode="Number" CssClass="txtBox" OnTextChanged="txtkhatiancs_TextChanged"></asp:TextBox></td>
            <td style="text-align:right"><asp:Label ID="lblkhatiansa" CssClass="lbl" runat="server" Text="Khatian SA:  " ></asp:Label></td>   
            <td> <asp:TextBox ID="txtkhatiansa" runat="server"  TextMode="Number" CssClass="txtBox"></asp:TextBox></td>
             <tr>
                  <td style="text-align:right"><asp:Label ID="lblkhatianrs" CssClass="lbl" runat="server" Text="Khatian RS:  " ></asp:Label></td>   
            <td> <asp:TextBox ID="txtkhatianrs" runat="server"  TextMode="Number" CssClass="txtBox"></asp:TextBox></td>
                                 
            <td style="text-align:right"><asp:Label ID="lblkhatianbrs" CssClass="lbl" runat="server" Text="Khatian BRS:  " ></asp:Label></td>   
            <td> <asp:TextBox ID="txtkhatianbrs" runat="server"  TextMode="Number" CssClass="txtBox"></asp:TextBox></td> 
            <td><asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" BackColor="#ffff99" OnClientClick = "Confirmforadd()" Text="Add" />
                
                  
            </td>
            
                  
                 <td>
                   <asp:Label ID="Label63" CssClass="lbl" runat="server" Text=" Mouza: "></asp:Label>

                     <asp:TextBox ID="TxtMouza" runat="server" CssClass="txtBox"  ></asp:TextBox></td>
          </tr>
                 <tr>
                  <td style="text-align:right;">
                         <asp:Label ID="Label74" runat="server" CssClass="lbl" Text="Deed Recepipt No  "></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="TxtDeedReceoiptNo" runat="server" CssClass="txtBox"></asp:TextBox>
                     </td>
                     <td style="text-align:right;">
                         <asp:Label ID="Label75" runat="server" CssClass="lbl" Text="Deed No: "></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="TxtDeedNo" runat="server" CssClass="txtBox"  ></asp:TextBox></td>
                     <td style="text-align:right;">
                                 <asp:Label ID="Label87" runat="server" CssClass="lbl" Text="Deed Value Land : "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtDeedValueLand" runat="server" CssClass="txtBox"></asp:TextBox>
                             </td>
                         </tr>
                 <tr>
                    
                         
                         <td style="text-align:right;">
                             <asp:Label ID="Label76" runat="server" CssClass="lbl" Text="Deed Date: "></asp:Label>
                         </td>
                         <td>
                             <asp:TextBox ID="DteDeedDate" runat="server" CssClass="txtBox"  ></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender15" runat="server" Format="yyyy-MM-dd" TargetControlID="DteDeedDate">
                    </cc1:CalendarExtender> 
              

                             <td style="text-align:right;"><asp:Label ID="Label77" CssClass="lbl" runat="server" Text="Deed Certify receive date: "></asp:Label></td>
               <td><asp:TextBox ID="dteDeedCertifyreceivedate" runat="server" CssClass="txtBox"  ></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender17" runat="server" Format="yyyy-MM-dd" TargetControlID="dteDeedCertifyreceivedate">
                    </cc1:CalendarExtender> </td>
              
                      <td style="text-align:right;">
                                 <asp:Label ID="Label78" runat="server" CssClass="lbl" Text="Orginal Deed Receive Date: "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtOrginalDeedReceiveDate" runat="server" CssClass="txtBox"  ></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender100" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtOrginalDeedReceiveDate">
                    </cc1:CalendarExtender> 
              
                             </td>
                        
                         
                    
                 </tr>
               <tr>
                
                             <td style="text-align:right;">
                                 <asp:Label ID="Label79" runat="server" CssClass="lbl" Text="Total Area : "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtTotalArea" runat="server" CssClass="txtBox"  ></asp:TextBox>
                             </td>
                  
                   <td style="text-align:right;">
                                 <asp:Label ID="Label80" runat="server" CssClass="lbl" Text="Total Area land in Decimal: "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtTotalArealandinDecimal" runat="server" CssClass="txtBox" OnTextChanged="TxtTotalArealandinDecimal_TextChanged"></asp:TextBox>
                             </td>
                             <td style="text-align:right;">
                                 <asp:Label ID="Label81" runat="server" CssClass="lbl" Text="Price Per Katha: "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtPricePerKatha" runat="server" CssClass="txtBox"></asp:TextBox>
                             </td>
                        </tr>
               
                     
                        
                         <tr>
                             
                             <td style="text-align:right;">
                                 <asp:Label ID="Label82" runat="server" CssClass="lbl" Text="Price per Decimal: "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtPriceperDecimal" runat="server" CssClass="txtBox"></asp:TextBox>
                             </td>
                             <td style="text-align:right;">
                                 <asp:Label ID="Label83" runat="server" CssClass="lbl" Text="Total Value of land Tk: "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtTotalValuelandTk" runat="server" CssClass="txtBox"></asp:TextBox>
                             </td>
                             <td style="text-align:right;">
                                 <asp:Label ID="Label84" runat="server" CssClass="lbl" Text="Registry Baina Amount: "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtRegistryBainaAmount" runat="server" CssClass="txtBox"></asp:TextBox>
                             </td>

                              

                             
                             
                         </tr>
                         <tr>
                             
                             <td style="text-align:right;">
                                 <asp:Label ID="Label85" runat="server" CssClass="lbl" Text="Balance land Value: "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtBalancelandValue" runat="server" CssClass="txtBox"></asp:TextBox>
                             </td>

                              <td style="text-align:right;">
                                 <asp:Label ID="Label90" runat="server" CssClass="lbl" Text="Local Govt tax: "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtLocalgovtTax" runat="server" CssClass="txtBox"></asp:TextBox>
                             </td>

                              <td style="text-align:right;">
                                 <asp:Label ID="Label91" runat="server" CssClass="lbl" Text="STAMP: "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtStamp" runat="server" CssClass="txtBox"></asp:TextBox>
                             </td>
                         </tr>
                        
                    
             
                 
                         <tr>
                            
                             <td style="text-align:right;">
                                 <asp:Label ID="Label92" runat="server" CssClass="lbl" Text="Income Tax: "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtIncomeTax" runat="server" CssClass="txtBox"></asp:TextBox>
                             </td>
                             <td style="text-align:right;">
                                 <asp:Label ID="Label93" runat="server" CssClass="lbl" Text="GAIN TAX: "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtGainTax" runat="server" CssClass="txtBox"></asp:TextBox>
                             </td>
                             <td style="text-align:right;">
                                 <asp:Label ID="Label89" runat="server" CssClass="lbl" Text="N Fees: "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtNfees" runat="server" CssClass="txtBox"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td style="text-align:right;">
                                 <asp:Label ID="Label94" runat="server" CssClass="lbl" Text="Pay Order Expense : "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtPayOrderExpense" runat="server" CssClass="txtBox"></asp:TextBox>
                             </td>
                             <td style="text-align:right;">
                                 <asp:Label ID="Label95" runat="server" CssClass="lbl" Text="Sub Register Commission: "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtSubRegisterCommission" runat="server" CssClass="txtBox"></asp:TextBox>
                             </td>
                              <td style="text-align:right;">
                                 <asp:Label ID="Label88" runat="server" CssClass="lbl" Text="Land office volume Checking exp: "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtLandofficevolumeCheckingexp" runat="server" CssClass="txtBox"></asp:TextBox>
                             </td>
                                  </tr>

                
                         <tr>
                             <td style="text-align:right;">
                                 <asp:Label ID="Label96" runat="server" CssClass="lbl" Text="Deed Certifies copy Expance: "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtDeedCertifiescopyExpance" runat="server" CssClass="txtBox"></asp:TextBox>
                             </td>
                             <td style="text-align:right;">
                                 <asp:Label ID="Label97" runat="server" CssClass="lbl" Text="Mution Expanse: "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtMutionExpanse" runat="server" CssClass="txtBox"></asp:TextBox>
                             </td>
                             <td style="text-align:right;">
                                 <asp:Label ID="Label98" runat="server" CssClass="lbl" Text="Other Expanse: "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtOtherExpanse" runat="server" CssClass="txtBox"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td style="text-align:right;">
                                 <asp:Label ID="Label99" runat="server" CssClass="lbl" Text="Total Area of land Muted: "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtTotalArealandMuted" runat="server" CssClass="txtBox"></asp:TextBox>
                             </td>
                             <td style="text-align:right;">
                                 <asp:Label ID="Label100" runat="server" CssClass="lbl" Text="JL No: "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="Txtjlno" runat="server" CssClass="txtBox"></asp:TextBox>
                             </td>
                             <td style="text-align:right;">
                                 <asp:Label ID="Label101" runat="server" CssClass="lbl" Text="Holding No/Jot No: "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtHoldingNoJotNo" runat="server" CssClass="txtBox"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td style="text-align:right;">
                                 <asp:Label ID="Label102" runat="server" CssClass="lbl" Text="Land Devlopment Tax Expance: "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtLandDevlopmentTaxExpance" runat="server" CssClass="txtBox"></asp:TextBox>
                             </td>
                             <td style="text-align:right;">
                                 <asp:Label ID="Label103" runat="server" CssClass="lbl" Text="Broker Commission: "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtBrokrCommission" runat="server" CssClass="txtBox"></asp:TextBox>
                             </td>
                             <td style="text-align:right;">
                                 <asp:Label ID="Label104" runat="server" CssClass="lbl" Text="Total Land Accusition Cost: "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtTotalLandAccusitionCost" runat="server" CssClass="txtBox"></asp:TextBox>
                             </td>
                                   </tr>
             <tr>
                 <td style="text-align:right;">
                                 <asp:Label ID="Label86" runat="server" CssClass="lbl" Text="Registration Expance : "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtRegistrationExpance" runat="server" CssClass="txtBox"></asp:TextBox>
                             </td> 
             </tr>
              <tr>
                           <td>

                           </td>
                           <td>
                               
                           </td>
                           <td>

                           </td>
                           <td></td>
                           <td style="text-align:right;"><asp:Button ID="BtnLand" runat="server" Text="Save" BackColor="#ffcc99" Width="128px" OnClick="BtnLand_Click" OnClientClick="Confirmforsubmitasset()" /> </td>
                
                       </tr> 
                          </table>    
          
                 </div>
          <div>
                <td><asp:GridView ID="grdvassetinfo" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
                    BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="grdvassetinfo_RowDataBound" OnRowDeleting="grdvassetinfo_RowDeleting">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                        
                    <Columns>
                     <asp:TemplateField  HeaderText="SL."><ItemTemplate><%# Container.DataItemIndex + 1 %><asp:HiddenField ID="hdnSL" runat="server" Value='<%# Bind("dagcs") %>' /></ItemTemplate></asp:TemplateField> 
                    <asp:BoundField DataField="dagcs" HeaderText="DAG CS" SortExpression="dagcs" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                    <asp:BoundField DataField="dagsa" HeaderText="DAG SA" SortExpression="dagsa" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                    <asp:BoundField DataField="dagrs" HeaderText="DAG RS" SortExpression="dagrs" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                    <asp:BoundField DataField="dagbrs" HeaderText="DAG BRS" SortExpression="dagbrs" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                     <asp:BoundField DataField="khatiancs" HeaderText="Khatian CS" SortExpression="khatiancs" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                    <asp:BoundField DataField="khatiansa" HeaderText="Khatian SA" SortExpression="khatiansa" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                    <asp:BoundField DataField="khatianrs" HeaderText="Khatian RS" SortExpression="khatianrs" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                    <asp:BoundField DataField="khatianbrs" HeaderText="Khatian BRS" SortExpression="khatianbrs" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                    
                        
                        
                        
                        <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" /> 

                  </Columns></asp:GridView> </td>

          </div> 
              <div>

            <table>
            
               
                
                 <tr>
                    
                     <td>
                         <asp:PlaceHolder ID="PlaceHolder3" runat="server" />
                     </td>
                 </tr>
                
               
                
             </table>
                  </div>

               </span>
                        <h3></h3>
                        <h3></h3>
                        <h3></h3>
                        <h3></h3>
                    </h3>
                  </td>
                </tr>
              </table>
            </asp:View>

         <asp:View ID="View4" runat="server">
              <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                <tr>
                  <td>
                    <h3>
                        <span>      
          
         <table>
     <%--//**********************************************Building Registration TAB***********************************************************--%>


                     <%--<tr>
                     <td style="text-align:right;">
                         <asp:Label ID="Label55" runat="server" CssClass="lbl" Font-Size="Small" Font-Bold="true"  Text=" Procurement (Local & Foreign: "></asp:Label>
                     </td></tr>--%>
             <tr>
                 <td style="text-align: right;">
                     <asp:Label ID="Label111" CssClass="lbl" runat="server" Text="Unit : "></asp:Label></td>
                 <td>
                     <asp:DropDownList ID="DdlBuildUnit" runat="server" CssClass="dropdownList" AutoPostBack="True" OnSelectedIndexChanged="DdlBuildUnit_SelectedIndexChanged"></asp:DropDownList>
                 <td style="text-align: right;">
                     <asp:Label ID="Label112" CssClass="lbl" runat="server" Text="Job Station : "></asp:Label></td>
                 <td>
                     <asp:DropDownList ID="DdlbuildJobstation" runat="server" AutoPostBack="true" CssClass="dropdownList"></asp:DropDownList></td>

                 <td style="text-align: right;">
                     <asp:Label ID="Label113" CssClass="lbl" runat="server" Text="Asset Type : "></asp:Label></td>
                 <td>
                     <asp:DropDownList ID="DdlBuildAssetType" runat="server" CssClass="dropdownList"></asp:DropDownList>
             </tr>

             <tr>

                 <td style="text-align: right;">
                     <asp:Label ID="Label114" CssClass="lbl" runat="server" Text="Name Of Structure: "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtNameStructer" runat="server" CssClass="txtBox"  ></asp:TextBox></td>

                 <td style="text-align: right;">
                     <asp:Label ID="Label115" CssClass="lbl" runat="server" Text="Asset Category : "></asp:Label></td>
                 <td>
                     <asp:DropDownList ID="DdlBAssetCategory" runat="server" CssClass="dropdownList"></asp:DropDownList>

                 <td style="text-align: right;">
                     <asp:Label ID="Label116" CssClass="lbl" runat="server" Text="Description of Structure: "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtBDescription" runat="server" CssClass="txtBox"></asp:TextBox></td>

             </tr>

             <tr>
                 <td style="text-align: right;">
                     <asp:Label ID="Label117" CssClass="lbl" runat="server" Text="Project Request By: "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtRequestBy" runat="server" CssClass="txtBox"></asp:TextBox></td>


                 <td style="text-align: right;">
                     <asp:Label ID="Label118" CssClass="lbl" runat="server" Text="Project Approve By : "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtBapproveBy" runat="server" CssClass="txtBox"></asp:TextBox></td>
                 <td style="text-align: right;">
                     <asp:Label ID="Label119" CssClass="lbl" runat="server" Text="Project Location: "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtLocation" runat="server" CssClass="txtBox"></asp:TextBox></td>

             </tr>
             <tr>

                 <td style="text-align: right;">
                     <asp:Label ID="Label120" CssClass="lbl" runat="server" Text="Po No: "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtBPoNo" runat="server" CssClass="txtBox"></asp:TextBox></td>

                 <td style="text-align: right;">
                     <asp:Label ID="Label121" CssClass="lbl" runat="server" Text="Po Date : "></asp:Label></td>
              <td><asp:TextBox ID="TxtDteBPodate" runat="server" CssClass="txtBox"  ></asp:TextBox>
                     <cc1:CalendarExtender ID="CalendarExtender19" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDteBPodate">
                     </cc1:CalendarExtender></td>
                
                 <td style="text-align: right;">
                     <asp:Label ID="Label122" CssClass="lbl" runat="server" Text="Project start Date : "></asp:Label></td>
                 <td><asp:TextBox ID="TxtdteProjectStart" runat="server" CssClass="txtBox"  ></asp:TextBox>
                     <cc1:CalendarExtender ID="CalendarExtender18" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtdteProjectStart">
                     </cc1:CalendarExtender></td>
                  

             </tr>
             <tr>

                 <td style="text-align: right;">
                     <asp:Label ID="Label123" CssClass="lbl" runat="server" Text="Project Delivery Date: "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtdteBDeliveryDate" runat="server" CssClass="txtBox"  ></asp:TextBox>
                     <cc1:CalendarExtender ID="CalendarExtender16" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtdteBDeliveryDate">
                     </cc1:CalendarExtender>
                 </td>

                 <td style="text-align: right;">
                     <asp:Label ID="Label124" CssClass="lbl" runat="server" Text="Length (Feet) : "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtLength" runat="server" CssClass="txtBox"  ></asp:TextBox></td>
                 <td style="text-align: right;">
                     <asp:Label ID="Label125" CssClass="lbl" runat="server" Text="Breadth (Feet) "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtBreadth" runat="server" CssClass="txtBox"  ></asp:TextBox></td>
                     
             </tr>

             <tr>

                 <td style="text-align: right;">
                     <asp:Label ID="Label126" CssClass="lbl" runat="server" Text="Height (Feet): "></asp:Label></td>

                 <td>
                     <asp:TextBox ID="TxtHeight" runat="server" CssClass="txtBox"></asp:TextBox></td>
                     


                     <td style="text-align: right;">
                         <asp:Label ID="Label127" CssClass="lbl" runat="server" Text="Total Area (SFT): "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtBTotalArea" runat="server" CssClass="txtBox"></asp:TextBox></td>

                 <td style="text-align: right;">
                     <asp:Label ID="Label128" CssClass="lbl" runat="server" Text="Estimated Cost Per unit(SFT) rate (Tk): "></asp:Label></td>
                <td> <asp:TextBox ID="TxtBEstimatedCost" runat="server" CssClass="txtBox"  ></asp:TextBox></td>
             </tr>
             <tr>

                 <td style="text-align: right;">
                     <asp:Label ID="Label129" CssClass="lbl" runat="server" Text="Estimated Cost of Construction  (Tk.): "></asp:Label></td>
                <td> <asp:TextBox ID="TxtBEstimatedConstruction" runat="server" CssClass="txtBox"  ></asp:TextBox></td>

                 <td style="text-align: right;">
                     <asp:Label ID="Label130" runat="server" CssClass="lbl" Text="Actual Cost of Construction  (Tk.): "></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="TxtActualConstruction" runat="server" CssClass="txtBox"  ></asp:TextBox>
                     </td>

                     <td style="text-align: right;">
                         <asp:Label ID="Label131" CssClass="lbl" runat="server" Text="Estimated Life: "></asp:Label></td>
               
                    <td> <asp:TextBox ID="TxtEstimatedLife" runat="server" CssClass="txtBox"  ></asp:TextBox></td>
                     
             </tr>

           
                 <tr>
                     <td style="text-align: right;">
                         <asp:Label ID="Label133" runat="server" CssClass="lbl" Text="Year of Construction: "></asp:Label>
                     </td>
                      <td>
                     <asp:TextBox ID="TxtYearConstruction" runat="server" CssClass="txtBox"  ></asp:TextBox>
                    
                     </td>
                    
               
                     <td style="text-align: right;">
                         <asp:Label ID="Label134" runat="server" CssClass="lbl" Text="Service Department: "></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="TxtServciceDept" runat="server" CssClass="txtBox"  ></asp:TextBox>
                     </td>
                     <td style="text-align: right;">
                         <asp:Label ID="Label135" runat="server" CssClass="lbl" Text="Project Funding Source "></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="TxtBprojectFundingSource" runat="server" CssClass="txtBox"  ></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td style="text-align: right;">
                         <asp:Label ID="Label136" runat="server" CssClass="lbl" Text="Project Materials Supply by: "></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="TxtMaterailsSupplyby" runat="server" CssClass="txtBox"  ></asp:TextBox></td>
                     <td style="text-align: right;">
                         <asp:Label ID="Label137" runat="server" CssClass="lbl" Text="Consultant Name: "></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="TxtConsultantName" runat="server" CssClass="txtBox"  ></asp:TextBox>

                         <td style="text-align: right;">
                             <asp:Label ID="Label138" runat="server" CssClass="lbl" Text="Contractor Name: "></asp:Label>
                         </td>
                         <td>
                             <asp:TextBox ID="TxtContractorName" runat="server" CssClass="txtBox"  ></asp:TextBox>
                         </td>

                     </td>
                 </tr>

                 <tr>
                     <td style="text-align: right;">
                         <asp:Label ID="Label139" runat="server" CssClass="lbl" Text="Renovation Work: "></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="TxtRenovationWork" runat="server" CssClass="txtBox"></asp:TextBox>
                     </td>

                     <td style="text-align: right;">
                         <asp:Label ID="Label140" runat="server" CssClass="lbl" Text="Renovation Approximatly Date: "></asp:Label>
                     </td>


                    <td>
                     <asp:TextBox ID="TxtdteApproximatly" runat="server" CssClass="txtBox"  ></asp:TextBox>
                     <cc1:CalendarExtender ID="CalendarExtender20" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtdteApproximatly">
                     </cc1:CalendarExtender>


                     <td style="text-align: right;">
                         <asp:Label ID="Label141" runat="server" CssClass="lbl" Text="Renovation Materials: "></asp:Label></td>

                     <td>
                         <asp:TextBox ID="TxtRenovationMaterilas" runat="server" CssClass="txtBox"></asp:TextBox></td>


                 </tr>
                 <tr>
                     <td style="text-align: right;">
                         <asp:Label ID="Label142" runat="server" CssClass="lbl" Text="Project Number: "></asp:Label>
                     </td>
                    <td>
                         <asp:TextBox ID="TxtProkjectNumber" runat="server" CssClass="txtBox"  ></asp:TextBox>
                        </td>
                 <td style="text-align: right;">
                         <asp:Label ID="Label143" runat="server" CssClass="lbl" Text="Remarks: "></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="TxtBRemarks" runat="server" CssClass="txtBox"  ></asp:TextBox>
                        </td>
                      <td style="text-align: right;">
                         <asp:Label ID="Label148" runat="server" CssClass="lbl" Text="TotalAccumulatedCost: "></asp:Label>
                     </td>
                      <td>
                         <asp:TextBox ID="TxtTotalAccumulatedCost" runat="server" CssClass="txtBox"  ></asp:TextBox>
                        </td>
                     
                
                          
                     
                       
                     </tr>
               
                            
               <tr>
                <td></td><td></td><td></td><td></td><td style="text-align:right;"><asp:Button ID="BtnBuilding" runat="server" Text="Save"  Width="128px" OnClick="BtnBuilding_Click"  /> </td>
                
                 </tr>
          
         </table>


            <table>
           
                
               
                
                 <tr>
                    
                     <td>
                         <asp:PlaceHolder ID="PlaceHolder4" runat="server" />
                     </td>
                 </tr>
                
               
                
             </table>
                  </span>
                    </h3>
                  </td>
                </tr>
              </table>
            </asp:View>
          </asp:MultiView>
     
             </formview> 
              
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
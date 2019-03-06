<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CWIPAssetAccountsPart.aspx.cs" Inherits="UI.Asset.CWIPAssetAccountsPart" %>

<!DOCTYPE html>

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
    <script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
    <script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>
    <link rel="stylesheet" href='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css' media="screen" />

    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .Textbox {}
        
        .modal-dialog.modla-table {
            width: 1000px;
        }
        .modal-header.parking-header {
            border-bottom: none;
            margin-bottom: -26px;
        }
        .table>thead>tr>th, .table>tbody>tr>th, .table>tfoot>tr>th, .table>thead>tr>td, .table>tbody>tr>td, .table>tfoot>tr>td {
            padding: 8px;
            line-height: 1.428571429;
            vertical-align: top;
            border-top: none;
        }
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

     <script type="text/javascript">
         function OpenHdnDiv() {
             $("#hdnDivision").fadeIn("slow");
             document.getElementById('hdnDivision').style.visibility = 'visible';
         }

         function ClosehdnDivision() {

             $("#hdnDivision").fadeOut("slow");
         }

         function OpenHdnDivVehicle() {
             $("#hdnDivisionVehicle").fadeIn("slow");
             document.getElementById('hdnDivisionVehicle').style.visibility = 'visible';
         }

         function ClosehdnVehicle() {

             $("#hdnDivisionVehicle").fadeOut("slow");
         }

         function OpenHdnLandDiv() {
             $("#hdnLandDivision").fadeIn("slow");
             document.getElementById('hdnLandDivision').style.visibility = 'visible';
         }

         function CloseHdnLandDiv() {

             $("#hdnLandDivision").fadeOut("slow");
         }

         function OpenHdnBuildingDiv() {
             $("#hdnBuildingDivision").fadeIn("slow");
             document.getElementById('hdnBuildingDivision').style.visibility = 'visible';
         }

         function CloseHdnBuildingDiv() {

             $("#hdnBuildingDivision").fadeOut("slow");
         }
    </script>

       
      
    <script type="text/javascript"> 
            function ShowPopup(title, body) {   
            $('#MyPopup').modal({
            show: true,
            keyboard: false,
                    backdrop: 'static'
                }); return false;
            }

        function Validation() { 
            var Assetname = document.getElementById("txtAssetname").value;
            alert(Assetname);
            var e = document.getElementById("ddlUnit");
            var unitid = e.options[e.selectedIndex].value;
            var e = document.getElementById("dlJobstation");
            var jobstation = e.options[e.selectedIndex].value;
            var e = document.getElementById("ddlMajorCat");
            var majorcat = e.options[e.selectedIndex].value;
            var e = document.getElementById("ddlCostCenter");
            var costcenter = e.options[e.selectedIndex].value;

             var e = document.getElementById("ddlMinorCate1");
            var minorcat1 = e.options[e.selectedIndex].value;
            
            var acisitionCost = document.getElementById("txtAcisitionCost").value;
            var astqty = document.getElementById("txtAssetQty").value;

            if ($.trim(Assetname).length < 3 ||
                $.trim(Assetname) == "" ||
                $.trim(Assetname) == null ||
                $.trim(Assetname) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please Fill-Up Asset Name');
                return false
            }
            else if ($.trim(unitid).length ==0 ||
                $.trim(unitid) == "" ||
                $.trim(unitid) == null ||
                $.trim(unitid) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please Select Unit Name');
                return false
            }
            else if ($.trim(jobstation) == 0 ||
                $.trim(jobstation) == "" ||
                $.trim(jobstation) == null ||
                $.trim(jobstation) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please select Jobstation');
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
            else if ($.trim(costcenter) == 0 ||
                $.trim(costcenter) == "" ||
                $.trim(costcenter) == null ||
                $.trim(costcenter) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please Select Cost Center');
                return false
            }
            else if ($.trim(minorcat1) == 0 ||
                $.trim(minorcat1) == "" ||
                $.trim(minorcat1) == null ||
                $.trim(minorcat1) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please Select Minor Category');
                return false
            }
            else if ($.trim(astqty) == 0 ||
                $.trim(astqty) == "" ||
                $.trim(astqty) == null ||
                $.trim(astqty) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please set Asset Quantity');
                return false
            }
            else if ($.trim(acisitionCost).length < 1 ||
                $.trim(acisitionCost) == "" ||
                $.trim(acisitionCost) == null ||
                $.trim(acisitionCost) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please Fill-Up  Acusition Cost');
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
        width:100%; height: 100%;    margin-left:100px;  margin-top:40px; margin-right:00px; padding: 15px; overflow-y:scroll; }
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
        .hdnDivisionVehicle { background-color: #EFEFEF; position:absolute;z-index:1; visibility:hidden; border:10px double black; text-align:center;
        width:80%; height:80%;    margin-left:100px;  margin-top:05%; margin-right:00px; padding: 15px; overflow-y:scroll; }
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
        .hdnLandDivision { background-color: #EFEFEF; position:absolute;z-index:1; visibility:hidden; border:10px double black; text-align:center;
        width:80%; height:80%;    margin-left:100px;  margin-top:05%; margin-right:00px; padding: 15px; overflow-y:scroll; }
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
        .hdnBuildingDivision { background-color: #EFEFEF; position:absolute;z-index:1; visibility:hidden; border:10px double black; text-align:center;
        width:80%; height:80%;    margin-left:100px;  margin-top:05%; margin-right:00px; padding: 15px; overflow-y:scroll; }
        </style>

   
    </head>
   <body>
    <form id="frmaccountsrealize" runat="server">

    
   <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <%--<asp:UpdatePanel ID="UpdatePanel0" runat="server">--%>
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
     <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnsearch" runat="server" />
    <asp:HiddenField ID="hdnEnrollUnit" runat="server" /><asp:HiddenField ID="hdnReceive" runat="server" /><asp:HiddenField ID="hdnBankID" runat="server" />
                
           <table>
               <tr>
                 <%--   <td style="text-align:left;"><asp:Label ID="Label47" CssClass="lbl" runat="server" Font-Size="small" Font-Bold="true"  Text="Asset Accounting: "></asp:Label></td>--%> 
                   <td style="text-align:right;" ><asp:Label ID="Label105" Font-Bold="true" CssClass="lbl" runat="server" Text="Unit Name: "></asp:Label></td>
                   <td ><asp:DropDownList ID="ddlUnitby" runat="server"   CssClass="ddList"> </asp:DropDownList>  </td>  
                   <td><asp:Button runat="server" ID="btnShow"  class="btn btn-primary"    Text="Show" Height="27px" Width="67px" />
                    <asp:Label ID="lblVoucher" CssClass="lbl" runat="server" Font-Size="small" Font-Bold="true"></asp:Label>
                   </td> 
                </tr>
           </table>
           <table>
             <tr>

              <td>
               <asp:GridView ID="dgvGridView" runat="server"  Font-Bold="False" AutoGenerateColumns="False">
                   <Columns>
                    <asp:TemplateField HeaderText="SL.N"> 
                     <ItemTemplate> <%# Container.DataItemIndex + 1 %>  </ItemTemplate></asp:TemplateField>
                           
                    <asp:BoundField DataField="intAutoid" HeaderText="intAutoID" SortExpression="intAutoid"/>
                    <asp:BoundField DataField="strAssetId" HeaderText="Asset ID"  SortExpression="strAssetId" />
                    <asp:BoundField DataField="strlcoation" HeaderText="Location"  SortExpression="strlcoation" />
                    <%-- <asp:BoundField DataField="MainType" HeaderText="Asset Type" SortExpression="MainType" />--%>
                    <asp:BoundField DataField="intAssetTypeID" HeaderText="MejorCategoryID" Visible="false" SortExpression="strAssetTypeName" />
                    <asp:BoundField DataField="strAssetTypeName" HeaderText="Asset Type"  SortExpression="strAssetTypeName" />

                    <asp:BoundField DataField="strUnit" HeaderText="Unit" SortExpression="strUnit" />
                    <asp:BoundField DataField="strJobStationName" HeaderText="Jobstation"  SortExpression="strJobStationName" />        
                    <asp:BoundField DataField="strNameOfAsset" HeaderText="Asset Name" SortExpression="strNameOfAsset" />
                    <asp:BoundField DataField="strDescription" HeaderText="Description"  SortExpression="strDescription" /> 
                    <asp:BoundField DataField="monAccusitioncost" HeaderText="AccusitionValue"  SortExpression="monAccusitioncost" /> 

                       <asp:TemplateField HeaderText="Submit">
                           <ItemTemplate>
                            <asp:Button ID="btnSubmit" runat="server"  CommandArgument='<%#GetJSFunctionString( Eval("intAutoid"),Eval("intAssetTypeID"))%>' Text="View & Edit" OnClick="btnSubmit_Click" />
                           </ItemTemplate>
                       </asp:TemplateField> 
         
                   </Columns>  </asp:GridView> </td>                   
                 
               </tr>
           </table>
         </div>

     <%--   General Asset Parking Registratiron         class="hdnDivision" --%>
        

                <div id="hdnDivision"  class="hdnDivision"   style="width:auto; height:500px;">
              
                </div>

        <!-- Modal Popup -->
        <div id="MyPopup" class="modal fade" role="dialog">
        <div class="modal-dialog modla-table">
        <!-- Modal content-->
        <div class="modal-content">
        <div class="modal-header parking-header">
        <button type="button" class="close" data-dismiss="modal">
        &times;</button>
        <h4 class="modal-title">Asset Additon/Recognition/Registration: </h4>
        </div>
        <div class="modal-body"> 
                  <table  class="table"  >   
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label51" CssClass="lbl" runat="server" Text="Unit Name: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlUnit" runat="server" Enabled="false"  CssClass="dropdownList"  AutoPostBack="True" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"> </asp:DropDownList> </td>                    
                  
               <td style="text-align:right;"><asp:Label ID="Label15" CssClass="lbl" runat="server" Text="Asset Name:"></asp:Label></td>
                 <td><asp:TextBox ID="txtAssetname" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                </tr>
                     <tr>
                <td style="text-align:right;"><asp:Label ID="lblBranch" CssClass="lbl" runat="server" Text="Branch:"></asp:Label></td>
                <td><asp:DropDownList ID="dlJobstation" runat="server" Enabled="false"  CssClass="dropdownList" OnSelectedIndexChanged="ddlJobstation_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>   

                <td style="text-align:right;"><asp:Label ID="Label16" CssClass="lbl" runat="server" Text="Description:"></asp:Label></td>
                 <td><asp:TextBox ID="txtDescription" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="lblAssetType" CssClass="lbl" runat="server" Text="Asset Type : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlAssetType" runat="server"  CssClass="dropdownList"  AutoPostBack="False"   >
                <asp:ListItem Value="1">Adminstrative</asp:ListItem><asp:ListItem Value="2">Manufacturer</asp:ListItem>
                </asp:DropDownList> </td>  

                    <td style="text-align:right;"><asp:Label ID="Label17" CssClass="lbl" runat="server" Text="HS Code:"></asp:Label></td>
                 <td><asp:TextBox ID="txtHsCode" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="lblMajor" CssClass="lbl" runat="server" Text="Asset Major Catagory : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlMajorCat" runat="server"  CssClass="dropdownList"  OnSelectedIndexChanged="ddlMajorCat_SelectedIndexChanged">              
                </asp:DropDownList> </td>  

                    <td style="text-align:right;"><asp:Label ID="Label18" CssClass="lbl" runat="server" Text="Store Issue Date:"></asp:Label></td>
                <td><asp:TextBox ID="txtIssueDate" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender8" runat="server" Format="yyyy-MM-dd" TargetControlID="txtIssueDate">
                </cc1:CalendarExtender>   </td>     

                </tr>
                   
                <tr>
                <td style="text-align:right;"><asp:Label ID="lblMinorCat1" CssClass="lbl" runat="server" Text="Asset Minor Category_1: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlMinorCate1" runat="server"  CssClass="dropdownList"  OnSelectedIndexChanged="ddlMinorCate1_SelectedIndexChanged">
               
                </asp:DropDownList> </td>  
                    <td style="text-align:right;"><asp:Label ID="lblGrndDate" CssClass="lbl" runat="server" Text="GRN Date: "></asp:Label></td>
                <td><asp:TextBox ID="txtGrndDate" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy-MM-dd" TargetControlID="txtGrndDate">
                </cc1:CalendarExtender>   </td>  
               

                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label53" CssClass="lbl" runat="server" Text="Asset Minor Category_2: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlMinorCate2" runat="server"  CssClass="dropdownList"  > </asp:DropDownList> </td>  
              
               
                    <td style="text-align:right;"><asp:Label ID="lblPlaceDate" CssClass="lbl" runat="server" Text="Date Place in Service(DPS): "></asp:Label></td>
                <td><asp:TextBox ID="txtServiceDate" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Format="yyyy-MM-dd" TargetControlID="txtServiceDate">
                </cc1:CalendarExtender>   </td>
                </tr>
                    <tr>
                 <td style="text-align:right;"><asp:Label ID="Label180" CssClass="lbl" runat="server" Text="Project ID:"></asp:Label></td>
                 <td><asp:TextBox ID="txtProjectID" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                <td style="text-align:right;"><asp:Label ID="Label181" CssClass="lbl" runat="server" Text="Project Name: "></asp:Label></td>
                <td><asp:TextBox ID="txtProjectName" runat="server" CssClass="txtBox"></asp:TextBox></td>
   
                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="lblCost" CssClass="lbl" runat="server" Text="Cost Center: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlCostCenter" runat="server"  CssClass="dropdownList"  ></asp:DropDownList>  </td>  
                

                     
                </tr>
                
                 <tr>
                <td style="text-align:left;" colspan="4"><asp:Label ID="Label2" CssClass="lbl" runat="server" Font-Size="small" Font-Bold="true"  Text="Admin Part: "></asp:Label></td>
                </tr>
                 <tr>
                 <td style="text-align:right;"><asp:Label ID="lblSupplier" CssClass="lbl" runat="server" Text="Supplier/Local Agent Name:"></asp:Label></td>
                 <td><asp:TextBox ID="txtSuppliers" runat="server" Enabled="false" CssClass="txtBox"></asp:TextBox></td>        

                <td style="text-align:right;"><asp:Label ID="lblCountryOrigin" CssClass="lbl" runat="server" Text="Country Origin : "></asp:Label></td>
                <td><asp:TextBox ID="txtCountryOrigin" runat="server" CssClass="txtBox"></asp:TextBox></td>
   
                </tr>
                  <tr>
                <td style="text-align:right;"><asp:Label ID="lblPonumber" CssClass="lbl" runat="server" Text="Po Number:"></asp:Label></td>
                <td><asp:TextBox ID="txtPonumbers" runat="server" Enabled="false" CssClass="txtBox"></asp:TextBox></td>     
                 <td style="text-align:right;"><asp:Label ID="Label52" CssClass="lbl" runat="server" Text="Name of Manufacturer : "></asp:Label></td>
                <td><asp:TextBox ID="txtManufacturer" runat="server" CssClass="txtBox"></asp:TextBox></td>
                   </tr>
                    <tr>
                         <td style="text-align:right;"><asp:Label ID="lblPodate" CssClass="lbl" runat="server" Text="Po Date:"></asp:Label></td>
                          <td><asp:TextBox ID="dtePoDate" runat="server" CssClass="txtBox"></asp:TextBox>  
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="dtePoDate">
                            </cc1:CalendarExtender></td>

                        <td style="text-align:right;"><asp:Label ID="Label57" CssClass="lbl" runat="server" Text="Manufacturer Provice SL No:"></asp:Label></td>
                         <td><asp:TextBox ID="txtManuProviceSlNo" runat="server" CssClass="txtBox"></asp:TextBox></td>     

                    </tr>
                    <tr>
                        <td style="text-align:right;"><asp:Label ID="Label54" CssClass="lbl" runat="server" Text="Waranty Expiry Date:"></asp:Label></td>
                <td><asp:TextBox ID="dteWarintyExpire" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="dteWarintyExpire">
                </cc1:CalendarExtender>   </td>
                         <td style="text-align:right;"><asp:Label ID="lblModel" CssClass="lbl" runat="server" Text="Model No:"></asp:Label></td>
                <td><asp:TextBox ID="txtModelNo" runat="server" CssClass="txtBox"></asp:TextBox></td>  
                    </tr>
                    <tr>
                        <td style="text-align:right;"><asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Date of Instalation:"></asp:Label></td>
                <td><asp:TextBox ID="txtDateInstalation" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender6" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDateInstalation">
                </cc1:CalendarExtender>   </td>
                         <td style="text-align:right;"><asp:Label ID="lblLcnumber" CssClass="lbl" runat="server" Text="LC Number:"></asp:Label></td>
                <td><asp:TextBox ID="txtLCnumber" runat="server" CssClass="txtBox"></asp:TextBox></td>   
                    </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="lblAssetLocation" CssClass="lbl" runat="server" Text="Asset Location:"></asp:Label></td>
                <td><asp:TextBox ID="txtAssetLocation" runat="server" CssClass="txtBox"></asp:TextBox></td>  
                <td style="text-align:right;"><asp:Label ID="lblOthers" CssClass="lbl" runat="server" Text="Others:"></asp:Label></td>
                <td><asp:TextBox ID="txtOthers" runat="server" CssClass="txtBox"></asp:TextBox></td>     

                </tr>
                    <tr>
                  <td style="text-align:right;"><asp:Label ID="Label4" CssClass="lbl" runat="server" Text="User Enrollment:"></asp:Label></td>
                <td><asp:TextBox ID="txtEnrolment" runat="server" CssClass="txtBox"></asp:TextBox></td>  
                <td style="text-align:right;"><asp:Label ID="Label5" CssClass="lbl" runat="server" Text="Rated Capacity:"></asp:Label></td>
                <td><asp:TextBox ID="txtCapacity" runat="server" CssClass="txtBox"></asp:TextBox></td>     

                    </tr>
                   
            
                     <tr>
                <td style="text-align:left;" colspan="4"><asp:Label ID="Label6" CssClass="lbl" runat="server" Font-Size="small" Font-Bold="true"  Text="Accounts Part: "></asp:Label></td>
                </tr>
                    <tr>
                   <td style="text-align:right;"><asp:Label ID="Label7" CssClass="lbl" runat="server" Text="Invoice Value BDT:"></asp:Label></td>
                <td><asp:TextBox ID="txtInvoiceValue" runat="server" AutoPostBack="true" CssClass="txtBox" OnTextChanged="txtInvoiceValue_TextChanged"></asp:TextBox></td>  
                <td style="text-align:right;"><asp:Label ID="Label8" CssClass="lbl" runat="server" Text="Recommand Life:"></asp:Label></td>
                <td><asp:TextBox ID="txtRecommandLife" runat="server" CssClass="txtBox"></asp:TextBox></td>     

                    </tr>
                    <tr>
                         <td style="text-align:right;"><asp:Label ID="Label9" CssClass="lbl" runat="server" Text="LandedCostt:"></asp:Label></td>
                <td><asp:TextBox ID="txtLandedCost" runat="server" AutoPostBack="true" CssClass="txtBox" OnTextChanged="txtLandedCost_TextChanged"></asp:TextBox></td>  
                <td style="text-align:right;"><asp:Label ID="Label10" CssClass="lbl" runat="server" Text="Method of Depreciation:"></asp:Label></td>
                 <td><asp:DropDownList ID="ddlMethodOfDep" runat="server"  CssClass="dropdownList" >  
                     <asp:ListItem Value="1" Text="Straight line "></asp:ListItem>    <asp:ListItem Value="2" Text="Reducing Balance"></asp:ListItem>          
                </asp:DropDownList> </td>
                 

                    </tr>
                    <tr>
                         <td style="text-align:right;"><asp:Label ID="Label11" CssClass="lbl" runat="server" Text="Erection & Other Cost:"></asp:Label></td>
                <td><asp:TextBox ID="txtErectionOtherCost" runat="server" AutoPostBack="true" CssClass="txtBox" OnTextChanged="txtErectionOtherCost_TextChanged"></asp:TextBox></td>  
                <td style="text-align:right;"><asp:Label ID="Label12" CssClass="lbl" runat="server" Text="Rate of Depreciation:"></asp:Label></td>
                <td><asp:TextBox ID="txtRateDep" runat="server" CssClass="txtBox"></asp:TextBox></td>     

                    </tr>
                    <tr>
                         <td style="text-align:right;"><asp:Label ID="Label13" CssClass="lbl" runat="server" Text="Total Acquisition Cost:"></asp:Label></td>
                <td><asp:TextBox ID="txtAcisitionCost" runat="server" CssClass="txtBox"></asp:TextBox></td>  
                <td style="text-align:right;"><asp:Label ID="Label14" CssClass="lbl" runat="server" Text="Depreciation Run Date:"></asp:Label></td>
                 <td><asp:TextBox ID="txtDepRunDate" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender7" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDepRunDate">
                </cc1:CalendarExtender>   </td>  

                    </tr>
                <tr>
               
                <td style="text-align:right;"><asp:Label ID="lblGlCode" CssClass="lbl" runat="server" Text="Remarks:"></asp:Label></td>
                <td><asp:TextBox ID="txtRemarks" runat="server" CssClass="txtBox"></asp:TextBox></td>      

                </tr>  
                       
                  <tr>
                        <td colspan="4" style="text-align:right;">
                            <asp:Button ID="btnSave" runat="server"  OnClientClick="return Validation();" class="btn btn-primary" OnClick="btnSave_Click" Text="Save" />
                            <asp:Button ID="btnClose" runat="server"  class="btn btn-secondary" OnClick="btnClose_Click" Text="Close" />
                        </td>
                    </tr>
                       
                </table>
         </div> 
        </div>
        </div>
    <!-- Modal Popup --> 

        </div> 

          <%-- Close  --%>

      <%-- Vehicle Asset Parking class="hdnDivisionVehicle"   --%>
            <div id="hdnDivisionVehicle" class="hdnDivisionVehicle" style="width:auto; height:700px;">
                <table style="width:auto;  float:left; " >    
                   
               <tr>
                <td style="text-align:left;" colspan="4"><asp:Label ID="Label1" CssClass="lbl" runat="server" Font-Size="small" Font-Bold="true"  Text="Asset Additon/Recognition/Registration: "></asp:Label></td>
                </tr>
                
                
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label19" CssClass="lbl" runat="server" Text="Unit Name: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlUnitV" runat="server" Enabled="false"  CssClass="dropdownList"  AutoPostBack="True" OnSelectedIndexChanged="ddlUnitV_SelectedIndexChanged"> </asp:DropDownList>                   
                  
               <td style="text-align:right;"><asp:Label ID="Label20" CssClass="lbl" runat="server" Text="Asset Name:"></asp:Label></td>
                 <td><asp:TextBox ID="txtAssetnameV" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                </tr>
                     <tr>
                <td style="text-align:right;"><asp:Label ID="Label21" CssClass="lbl" runat="server" Text="Branch:"></asp:Label></td>
                <td><asp:DropDownList ID="ddlJobstationV" runat="server" Enabled="false"  CssClass="dropdownList" ></asp:DropDownList> 

                <td style="text-align:right;"><asp:Label ID="Label22" CssClass="lbl" runat="server" Text="Description:"></asp:Label></td>
                 <td><asp:TextBox ID="txtDescriptionV" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label23" CssClass="lbl" runat="server" Text="Asset Type : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlAssetTypeV" runat="server"  CssClass="dropdownList"   AutoPostBack="False" >
                <asp:ListItem Value="1">Adminstrative</asp:ListItem><asp:ListItem Value="2">Manufacturer</asp:ListItem>
                </asp:DropDownList> 

                    <td style="text-align:right;"><asp:Label ID="Label24" CssClass="lbl" runat="server" Text="HS Code:"></asp:Label></td>
                 <td><asp:TextBox ID="txtHsCodeV" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label25" CssClass="lbl" runat="server" Text="Asset Major Catagory : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlMajorCatV" runat="server"  CssClass="dropdownList"  AutoPostBack="False" >                
                </asp:DropDownList> 

                    <td style="text-align:right;"><asp:Label ID="Label26" CssClass="lbl" runat="server" Text="Store Issue Date:"></asp:Label></td>
                <td><asp:TextBox ID="txtIssueDateV" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="yyyy-MM-dd" TargetControlID="txtIssueDateV">
                </cc1:CalendarExtender>   </td>       

                
                </tr>
                   
                <tr>
                <td style="text-align:right;"><asp:Label ID="lblMinorCat1V" CssClass="lbl" runat="server" Text="Asset Minor Category_1: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlMinorCate1V" runat="server"  CssClass="dropdownList"   AutoPostBack="False" >
                
                </asp:DropDownList> 
                    <td style="text-align:right;"><asp:Label ID="lblGrndDateV" CssClass="lbl" runat="server" Text="GRN Date: "></asp:Label></td>
                <td><asp:TextBox ID="txtGrndDateV" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender9" runat="server" Format="yyyy-MM-dd" TargetControlID="txtGrndDateV">
                </cc1:CalendarExtender>   </td>  
               

                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label27" CssClass="lbl" runat="server" Text="Asset Minor Category_2: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlMinorCate2V" runat="server"  CssClass="dropdownList"   AutoPostBack="False" >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> 
                    <td style="text-align:right;"><asp:Label ID="lblPlaceDateV" CssClass="lbl" runat="server" Text="Date Place in Service(DPS): "></asp:Label></td>
                <td><asp:TextBox ID="txtServiceDateV" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender10" runat="server" Format="yyyy-MM-dd" TargetControlID="txtServiceDateV">
                </cc1:CalendarExtender>   </td> 

                </tr>
                 <tr>
                 <td style="text-align:right;"><asp:Label ID="Label116" CssClass="lbl" runat="server" Text="Project ID:"></asp:Label></td>
                 <td><asp:TextBox ID="txtProjectIDV" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                <td style="text-align:right;"><asp:Label ID="Label175" CssClass="lbl" runat="server" Text="Project Name: "></asp:Label></td>
                <td><asp:TextBox ID="txtProjectNameV" runat="server" CssClass="txtBox"></asp:TextBox></td>
   
                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="lblCostV" CssClass="lbl" runat="server" Text="Cost Center: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlCostCenterV" runat="server"  CssClass="dropdownList"  AutoPostBack="False" ></asp:DropDownList> 
                

                     
                </tr>
                 <tr>
                <td style="text-align:left;" colspan="4"><asp:Label ID="Label48" CssClass="lbl" runat="server" Font-Size="small" Font-Bold="true"  Text="Vehicle Info: "></asp:Label></td>
                </tr>
                <tr>
                 <td style="text-align:right;"><asp:Label ID="Label49" CssClass="lbl" runat="server" Text="City/Area:"></asp:Label></td>
                  <td><asp:DropDownList ID="ddlCity" runat="server"  CssClass="dropdownList"  AutoPostBack="False" ></asp:DropDownList> </td>        

                 <td style="text-align:right;"><asp:Label ID="Label50" CssClass="lbl" runat="server" Text="Indentifier :"></asp:Label></td>
                  <td><asp:DropDownList ID="ddlIdentifire" runat="server"  CssClass="dropdownList"  AutoPostBack="False" ></asp:DropDownList>
                  </td>
   
                </tr>
                 <tr>
                 <td style="text-align:right;"><asp:Label ID="Label55" CssClass="lbl" runat="server" Text="Serial Number:"></asp:Label></td>
                 <td><asp:DropDownList ID="ddlSerialNo" runat="server"  CssClass="dropdownList"   AutoPostBack="False" >
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
                    
                          </asp:DropDownList> </td>                            

                 <td style="text-align:right;"><asp:Label ID="Label56" CssClass="lbl" runat="server" Text="End Number :"></asp:Label></td>
                 <td><asp:TextBox ID="txtEndNumber" runat="server" CssClass="txtBox"></asp:TextBox></td>   
                </tr>

                 <tr>
                 <td style="text-align:right;"><asp:Label ID="Label58" CssClass="lbl" runat="server" Text="Brand Name:"></asp:Label></td>
                  <td><asp:DropDownList ID="ddlBrand" runat="server"  CssClass="dropdownList"  ></asp:DropDownList> </td>        

                 <td style="text-align:right;"><asp:Label ID="Label59" CssClass="lbl" runat="server" Text="Model Name:"></asp:Label></td>
                 <td><asp:TextBox ID="txtModelName" runat="server" CssClass="txtBox"></asp:TextBox></td>   
                </tr>
                 <tr>
                 <td style="text-align:right;"><asp:Label ID="Label60" CssClass="lbl" runat="server" Text="Year of Model:"></asp:Label></td>
                 <td><asp:TextBox ID="txtYearOfModel" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                 <td style="text-align:right;"><asp:Label ID="Label61" CssClass="lbl" runat="server" Text="CC:"></asp:Label></td>
                 <td><asp:TextBox ID="txtCC" runat="server" CssClass="txtBox"></asp:TextBox></td>   
                </tr>
                 <tr>
                 <td style="text-align:right;"><asp:Label ID="Label62" CssClass="lbl" runat="server" Text="Color:"></asp:Label></td>
                  <td><asp:DropDownList ID="ddlColor" runat="server"  CssClass="dropdownList"   AutoPostBack="False" >
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
                      </asp:DropDownList> </td>        

                 <td style="text-align:right;"><asp:Label ID="Label63" CssClass="lbl" runat="server" Text="Engine No :"></asp:Label></td>
                 <td><asp:TextBox ID="txtEngineNo" runat="server" CssClass="txtBox"></asp:TextBox></td>   
                </tr>
                 <tr>
                 <td style="text-align:right;"><asp:Label ID="Label64" CssClass="lbl" runat="server" Text="Chassis No:"></asp:Label></td>
                 <td><asp:TextBox ID="txtChassisNo" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                 <td style="text-align:right;"><asp:Label ID="Label65" CssClass="lbl" runat="server" Text="Initial mileage:"></asp:Label></td>
                 <td><asp:TextBox ID="txtInitialMile" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>   
                </tr>
                  <tr>
                 <td style="text-align:right;"><asp:Label ID="Label66" CssClass="lbl" runat="server" Text="Fuel Status :"></asp:Label></td>
                  <td><asp:DropDownList ID="ddlFuelStatus" runat="server"  CssClass="dropdownList"  AutoPostBack="False" >
                        <asp:ListItem>CNG</asp:ListItem>
                         <asp:ListItem>Petrol </asp:ListItem>
                         <asp:ListItem>Diesel </asp:ListItem>
                         <asp:ListItem>Octen </asp:ListItem>
                         <asp:ListItem>CNG+Diesel  </asp:ListItem>
                         <asp:ListItem>CNG+Octen </asp:ListItem>
                         <asp:ListItem>CNG+Petrol </asp:ListItem>
                      </asp:DropDownList> </td>       

                 <td style="text-align:right;"><asp:Label ID="Label67" CssClass="lbl" runat="server" Text="UnladanWeight:"></asp:Label></td>
                 <td><asp:TextBox ID="txtUnladanWeight" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>   
                </tr>
                    <tr>
                 <td style="text-align:right;"><asp:Label ID="Label68" CssClass="lbl" runat="server" Text="Laden Weight:"></asp:Label></td>
                 <td><asp:TextBox ID="txtLadenWeight" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>        

                 
                </tr>
                 <tr>
                <td style="text-align:left;" colspan="4"><asp:Label ID="Label28" CssClass="lbl" runat="server" Font-Size="small" Font-Bold="true"  Text="Admin Part: "></asp:Label></td>
                </tr>
                 <tr>
                 <td style="text-align:right;"><asp:Label ID="lblSupplierV" CssClass="lbl" runat="server" Text="Supplier/Local Agent Name:"></asp:Label></td>
                 <td><asp:TextBox ID="txtSuppliersV" Enabled="false" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                <td style="text-align:right;"><asp:Label ID="lblCountryOriginV" CssClass="lbl" runat="server" Text="Country Origin : "></asp:Label></td>
                <td><asp:TextBox ID="txtCountryOriginV" runat="server" CssClass="txtBox"></asp:TextBox></td>
   
                </tr>
                  <tr>
                <td style="text-align:right;"><asp:Label ID="lblPonumberV" CssClass="lbl" runat="server" Text="Po Number:"></asp:Label></td>
                <td><asp:TextBox ID="txtPonumbersV" runat="server" Enabled="false" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>     
                 <td style="text-align:right;"><asp:Label ID="Label29" CssClass="lbl" runat="server" Text="Name of Manufacturer : "></asp:Label></td>
                <td><asp:TextBox ID="txtManufacturerV" runat="server" CssClass="txtBox"></asp:TextBox></td>
                   </tr>
                    <tr>
                         <td style="text-align:right;"><asp:Label ID="lblPodateV" CssClass="lbl" runat="server" Text="Po Date:"></asp:Label></td>
                <td><asp:TextBox ID="dtePoDateV" runat="server" CssClass="txtBox"></asp:TextBox>  
                <cc1:CalendarExtender ID="CalendarExtender11" runat="server" Format="yyyy-MM-dd" TargetControlID="dtePoDateV">
                </cc1:CalendarExtender>   </td>

                        <td style="text-align:right;"><asp:Label ID="Label30" CssClass="lbl" runat="server" Text="Manufacturer Provice SL No:"></asp:Label></td>
                <td><asp:TextBox ID="txtManuProviceSlNoV" runat="server" CssClass="txtBox"></asp:TextBox></td>     

                    </tr>
                    <tr>
                        <td style="text-align:right;"><asp:Label ID="Label31" CssClass="lbl" runat="server" Text="Waranty Expiry Date:"></asp:Label></td>
                <td><asp:TextBox ID="dteWarintyExpireV" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender12" runat="server" Format="yyyy-MM-dd" TargetControlID="dteWarintyExpireV">
                </cc1:CalendarExtender>   </td>
                         <td style="text-align:right;"><asp:Label ID="Label32" CssClass="lbl" runat="server" Text="Model No:"></asp:Label></td>
                <td><asp:TextBox ID="txtModelNoV" runat="server" CssClass="txtBox"></asp:TextBox></td>  
                    </tr>
                    <tr>
                        <td style="text-align:right;"><asp:Label ID="Label33" CssClass="lbl" runat="server" Text="Date of Instalation:"></asp:Label></td>
                <td><asp:TextBox ID="txtDateInstalationV" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender13" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDateInstalationV">
                </cc1:CalendarExtender>   </td>
                         <td style="text-align:right;"><asp:Label ID="Label34" CssClass="lbl" runat="server" Text="LC Number:"></asp:Label></td>
                <td><asp:TextBox ID="txtLCnumberV" runat="server" CssClass="txtBox"></asp:TextBox></td>   
                    </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label35" CssClass="lbl" runat="server" Text="Asset Location:"></asp:Label></td>
                <td><asp:TextBox ID="txtAssetLocationV" runat="server" CssClass="txtBox"></asp:TextBox></td>  
                <td style="text-align:right;"><asp:Label ID="lblOthersV" CssClass="lbl" runat="server" Text="Others:"></asp:Label></td>
                <td><asp:TextBox ID="txtOthersV" runat="server" CssClass="txtBox"></asp:TextBox></td>     

                </tr>
                    <tr>
                  <td style="text-align:right;"><asp:Label ID="Label36" CssClass="lbl" runat="server" Text="User Enrollment:"></asp:Label></td>
                <td><asp:TextBox ID="txtEnrolmentV" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>  
                <td style="text-align:right;"><asp:Label ID="Label37" CssClass="lbl" runat="server" Text="Rated Capacity:"></asp:Label></td>
                <td><asp:TextBox ID="txtCapacityV" runat="server" CssClass="txtBox"></asp:TextBox></td>     

                    </tr>
                   
              
                     <tr>
                <td style="text-align:left;" colspan="4"><asp:Label ID="Label38" CssClass="lbl" runat="server" Font-Size="small" Font-Bold="true"  Text="Accounts Part: "></asp:Label></td>
                </tr>
                    <tr>
                   <td style="text-align:right;"><asp:Label ID="Label39" CssClass="lbl" runat="server" Text="Invoice Value BDT:"></asp:Label></td>
                <td><asp:TextBox ID="txtInvoiceValueV" runat="server" CssClass="txtBox" TextMode="Number"></asp:TextBox></td>  
                <td style="text-align:right;"><asp:Label ID="Label40" CssClass="lbl" runat="server" Text="Recommand Life:"></asp:Label></td>
                <td><asp:TextBox ID="txtRecommandLifeV" runat="server" CssClass="txtBox"></asp:TextBox></td>     

                    </tr>
                    <tr>
                         <td style="text-align:right;"><asp:Label ID="Label41" CssClass="lbl" runat="server" Text="LandedCost:"></asp:Label></td>
                <td><asp:TextBox ID="txtLandedCostV" runat="server" CssClass="txtBox" TextMode="Number"></asp:TextBox></td>  
                <td style="text-align:right;"><asp:Label ID="Label42" CssClass="lbl" runat="server" Text="Method of Depreciation:"></asp:Label></td>
                 <td><asp:DropDownList ID="ddlMethodOfDepV" runat="server"  CssClass="dropdownList"  AutoPostBack="False"  >  
                 <asp:ListItem Value="1" Text="Straight line "></asp:ListItem><asp:ListItem Value="2" Text="Reducing Balance"></asp:ListItem> 
                  </asp:DropDownList> </td>
                 

                    </tr>
                    <tr>
                         <td style="text-align:right;"><asp:Label ID="Label43" CssClass="lbl" runat="server" Text="Erection & Other Cost:"></asp:Label></td>
                <td><asp:TextBox ID="txtErectionOtherCostV" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>  
                <td style="text-align:right;"><asp:Label ID="Label44" CssClass="lbl" runat="server" Text="Rate of Depreciation:"></asp:Label></td>
                <td><asp:TextBox ID="txtRateDepV" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>     

                    </tr>
                    <tr>
                         <td style="text-align:right;"><asp:Label ID="Label45" CssClass="lbl" runat="server" Text="Total Acquisition Cost:"></asp:Label></td>
                <td><asp:TextBox ID="txtAcisitionCostV" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>  
                <td style="text-align:right;"><asp:Label ID="Label119" CssClass="lbl" runat="server" Text="Depreciation Run Date:"></asp:Label></td>
                <td><asp:TextBox ID="txtDteDepRunV" runat="server" CssClass="txtBox"></asp:TextBox>
                     <cc1:CalendarExtender ID="CalendarExtender28" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDteDepRunV">
                </cc1:CalendarExtender>   </td>
               

                    </tr>
                <tr>
               
                <td style="text-align:right;"><asp:Label ID="lblGlCodeV" CssClass="lbl" runat="server" Text="Remarks:"></asp:Label></td>
                <td><asp:TextBox ID="txtRemarksV" runat="server" CssClass="txtBox"></asp:TextBox></td>      

                </tr>               
                                    
                    <tr>
                      <td colspan="2" style="text-align:right;"><asp:Button ID="btnSaveVehicle" runat="server" Text="Save" OnClick="btnSaveVehicle_Click" /> </td>                          
                       
                      <td colspan="2" style="text-align:right;"><asp:Button ID="btnclosev" runat="server" OnClick="btnClose_Click" Text="Close" /> </td>
                      
                    </tr>
                       
                </table>
                </div>

         <%-- Land Asset Parking class="hdnLandDivision"  --%>
            <div id="hdnLandDivision"  class="hdnLandDivision"   style="width:auto;  height:700px;">
                <table style="width:auto;  float:left; " >    
                   
               <tr>
                <td style="text-align:left;" colspan="4"><asp:Label ID="Label69" CssClass="lbl" runat="server" Font-Size="small" Font-Bold="true"  Text="Asset Additon/Recognition/Registration: "></asp:Label></td>
                </tr>
                
                
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label70" CssClass="lbl" runat="server" Text="Unit Name: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlUnitLand" runat="server"  CssClass="dropdownList"  AutoPostBack="True" OnSelectedIndexChanged="ddlUnitLand_SelectedIndexChanged"> </asp:DropDownList>                   
                  
               <td style="text-align:right;"><asp:Label ID="Label71" CssClass="lbl" runat="server" Text="Asset Name:"></asp:Label></td>
                 <td><asp:TextBox ID="txtAssetNameL" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                </tr>
                     <tr>
                <td style="text-align:right;"><asp:Label ID="Label72" CssClass="lbl" runat="server" Text="Branch:"></asp:Label></td>
                <td><asp:DropDownList ID="ddlJobstationL" runat="server"  CssClass="dropdownList"  AutoPostBack="False"  ></asp:DropDownList> 

                <td style="text-align:right;"><asp:Label ID="Label73" CssClass="lbl" runat="server" Text="Description:"></asp:Label></td>
                 <td><asp:TextBox ID="txtDescriptionL" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label74" CssClass="lbl" runat="server" Text="Asset Type : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlAssetTypeL" runat="server"  CssClass="dropdownList"   AutoPostBack="False" >
                <asp:ListItem Value="1">Adminstrative</asp:ListItem><asp:ListItem Value="2">Manufacturer</asp:ListItem>
                </asp:DropDownList> 

                    <td style="text-align:right;"><asp:Label ID="Label75" CssClass="lbl" runat="server" Text="HS Code:"></asp:Label></td>
                 <td><asp:TextBox ID="txtHScodeL" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label76" CssClass="lbl" runat="server" Text="Asset Major Catagory : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlMajorCategoryL" runat="server"  CssClass="dropdownList"  AutoPostBack="false">
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> 

                    <td style="text-align:right;"><asp:Label ID="Label77" CssClass="lbl" runat="server" Text="Store Issue Date:"></asp:Label></td>
                <td><asp:TextBox ID="txtIssueDateL" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender15" runat="server" Format="yyyy-MM-dd" TargetControlID="txtIssueDateL">
                </cc1:CalendarExtender>   </td>       

                
                </tr>
                   
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label78" CssClass="lbl" runat="server" Text="Asset Minor Category_1: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlMinorCategory1L" runat="server"  CssClass="dropdownList"  AutoPostBack="False"   >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> 
                    <td style="text-align:right;"><asp:Label ID="Label79" CssClass="lbl" runat="server" Text="GRN Date: "></asp:Label></td>
                <td><asp:TextBox ID="txtGRNDateL" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender16" runat="server" Format="yyyy-MM-dd" TargetControlID="txtGRNDateL">
                </cc1:CalendarExtender>   </td>  
               

                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label80" CssClass="lbl" runat="server" Text="Asset Minor Category_2: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlMinorCategory2L" runat="server"  CssClass="dropdownList"  AutoPostBack="False"  >
               
                </asp:DropDownList> 
                    <td style="text-align:right;"><asp:Label ID="Label81" CssClass="lbl" runat="server" Text="Date Place in Service(DPS): "></asp:Label></td>
                <td><asp:TextBox ID="txtServiceDateL" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender17" runat="server" Format="yyyy-MM-dd" TargetControlID="txtServiceDateL">
                </cc1:CalendarExtender>   </td> 
                
                      

                </tr>
                  <tr>
                 <td style="text-align:right;"><asp:Label ID="Label176" CssClass="lbl" runat="server" Text="Project ID:"></asp:Label></td>
                 <td><asp:TextBox ID="txtProjectIDL" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                <td style="text-align:right;"><asp:Label ID="Label177" CssClass="lbl" runat="server" Text="Project Name: "></asp:Label></td>
                <td><asp:TextBox ID="txtProjectNameL" runat="server" CssClass="txtBox"></asp:TextBox></td>
   
                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label82" CssClass="lbl" runat="server" Text="Cost Center: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlCostCenterL" runat="server"  CssClass="dropdownList"  AutoPostBack="False"   ></asp:DropDownList> 
                

                     
                </tr>
                 <tr>
                <td style="text-align:left;" colspan="4"><asp:Label ID="Label83" CssClass="lbl" runat="server" Font-Size="small" Font-Bold="true"  Text="Land Location: "></asp:Label></td>
                </tr>
                <tr>
                 <td style="text-align:right;"><asp:Label ID="Label84" CssClass="lbl" runat="server" Text="District:"></asp:Label></td>
                  <td><asp:DropDownList ID="ddlDistrictL" runat="server"  CssClass="dropdownList"  AutoPostBack="True" OnSelectedIndexChanged="ddlDistrictL_SelectedIndexChanged"></asp:DropDownList> </td>        

                 <td style="text-align:right;"><asp:Label ID="Label85" CssClass="lbl" runat="server" Text="Thana:"></asp:Label></td>
                  <td><asp:DropDownList ID="ddlThanaL" runat="server"  CssClass="dropdownList"  AutoPostBack="False"   ></asp:DropDownList> </td>
   
                </tr>
                 <tr>                 
                 <td style="text-align:right;"><asp:Label ID="Label87" CssClass="lbl" runat="server" Text="Mouza:"></asp:Label></td>
                 <td><asp:TextBox ID="txtMouzaL" runat="server" CssClass="txtBox"></asp:TextBox></td>   
                </tr>

               
                 <tr>
                <td style="text-align:left;" colspan="4"><asp:Label ID="Label99" CssClass="lbl" runat="server" Font-Size="small" Font-Bold="true"  Text="Admin Part: "></asp:Label></td>
                </tr>
                 <tr>
                 <td style="text-align:right;"><asp:Label ID="Label100" CssClass="lbl" runat="server" Text="Supplier/Local Agent Name:"></asp:Label></td>
                 <td><asp:TextBox ID="txtSupplierL" runat="server" Enabled="false" CssClass="txtBox"></asp:TextBox></td>        

                <td style="text-align:right;"><asp:Label ID="Label101" CssClass="lbl" runat="server" Text="Name of Buyer as per Deed: "></asp:Label></td>
                <td><asp:TextBox ID="txtBuyerName" runat="server" CssClass="txtBox"></asp:TextBox></td>
   
                </tr>
                  <tr>
                <td style="text-align:right;"><asp:Label ID="Label102" CssClass="lbl" runat="server" Text="Po Number:"></asp:Label></td>
                <td><asp:TextBox ID="txtPoNumberL" runat="server" Enabled="false" CssClass="txtBox"></asp:TextBox></td>     
                 <td style="text-align:right;"><asp:Label ID="Label103" CssClass="lbl" runat="server" Text="Deed Receipt NO:"></asp:Label></td>
                <td><asp:TextBox ID="txtDeedReceiptNo" runat="server" CssClass="txtBox"></asp:TextBox></td>
                   </tr>
                    <tr>
                         <td style="text-align:right;"><asp:Label ID="Label104" CssClass="lbl" runat="server" Text="Po Date:"></asp:Label></td>
                <td><asp:TextBox ID="txtPoDateL" Enabled="false"  runat="server" CssClass="txtBox"></asp:TextBox>  
                <cc1:CalendarExtender ID="CalendarExtender18" runat="server" Format="yyyy-MM-dd" TargetControlID="dtePoDateV">
                </cc1:CalendarExtender>   </td>

                        <td style="text-align:right;"><asp:Label ID="Label106" CssClass="lbl" runat="server" Text="Deed NO:"></asp:Label></td>
                <td><asp:TextBox ID="txtDeedNo" runat="server" CssClass="txtBox"></asp:TextBox></td>     

                    </tr>
                    <tr>
                        <td style="text-align:right;"><asp:Label ID="Label107" CssClass="lbl" runat="server" Text="Date of Deed:"></asp:Label></td>
                <td><asp:TextBox ID="txtDeedDate" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender19" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDeedDate">
                </cc1:CalendarExtender>   </td>
                         <td style="text-align:right;"><asp:Label ID="Label108" CssClass="lbl" runat="server" Text="Total Land in Decimal:"></asp:Label></td>
                <td><asp:TextBox ID="txtTotalLandinDecimal" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>  
                    </tr>
                    <tr>
                        <td style="text-align:right;"><asp:Label ID="Label109" CssClass="lbl" runat="server" Text="Deed Certify Receive Date:"></asp:Label></td>
                <td><asp:TextBox ID="txtDeedCertifyRecDate" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender20" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDeedCertifyRecDate">
                </cc1:CalendarExtender>   </td>
                         <td style="text-align:right;"><asp:Label ID="Label110" CssClass="lbl" runat="server" Text="Rate Per Decimal:"></asp:Label></td>
                <td><asp:TextBox ID="txtRatePerDecimal" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>   
                    </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label111" CssClass="lbl" runat="server" Text="Orignal Deed Receive Date:"></asp:Label></td>
                <td><asp:TextBox ID="txtDeedReceiveDate" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender27" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDeedReceiveDate">
                </cc1:CalendarExtender>   </td>

                <td style="text-align:right;"><asp:Label ID="Label112" CssClass="lbl" runat="server" Text=" Registration Cost:"></asp:Label></td>
                <td><asp:TextBox ID="txtRegistrationCost" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>     

                </tr>
                 <tr>
                 <td style="text-align:right;"><asp:Label ID="Label113" CssClass="lbl" runat="server" Text="User Enrollment:"></asp:Label></td>
                <td><asp:TextBox ID="txtEnrollmentL" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>  
                <td style="text-align:right;"><asp:Label ID="Label114" CssClass="lbl" runat="server" Text="Total Value of Land:"></asp:Label></td>
                <td><asp:TextBox ID="txtTotalLandValue" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>   
                 </tr>

                 <tr>
                <td style="text-align:left;" colspan="4"><asp:Label ID="Label131" CssClass="lbl" runat="server" Font-Size="small" Font-Bold="true"  Text="Add Information: "></asp:Label></td>
                </tr>

                 <tr>
                <td style="text-align:right;"><asp:Label ID="Label132" CssClass="lbl" runat="server" Text="Dag CS:"></asp:Label></td>
                <td><asp:TextBox ID="txtDagCs" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="Label123" CssClass="lbl" runat="server" Text="Dag CS Total:"></asp:Label></td>
                <td><asp:TextBox ID="txtDagCsTotal" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>
                   </tr>
                    <tr>
                <td style="text-align:right;"><asp:Label ID="Label133" CssClass="lbl" runat="server" Text="DAG SA:"></asp:Label></td>
                <td><asp:TextBox ID="txtDagSa" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>  
                   <td style="text-align:right;"><asp:Label ID="Label140" CssClass="lbl" runat="server" Text="Dag SA Total:"></asp:Label></td>
                <td><asp:TextBox ID="txtDagSaTotal" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td> 

                </tr>

                 <tr>
                <td style="text-align:right;"><asp:Label ID="Label136" CssClass="lbl" runat="server" Text="DAG RS:"></asp:Label></td>
                <td><asp:TextBox ID="txtDagRs" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td> 
               <td style="text-align:right;"><asp:Label ID="Label171" CssClass="lbl" runat="server" Text="Dag RS Total:"></asp:Label></td>
                <td><asp:TextBox ID="txtDagRsTotal" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>
                </tr>
                 <tr> 
                <td style="text-align:right;"><asp:Label ID="Label137" CssClass="lbl" runat="server" Text="DAG BRS:"></asp:Label></td>
                <td><asp:TextBox ID="txtDagBrs" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>
             <td style="text-align:right;"><asp:Label ID="Label172" CssClass="lbl" runat="server" Text="Dag Brs Total:"></asp:Label></td>
                <td><asp:TextBox ID="txtDagBrsTotal" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>
                </tr>
                    <tr> 
                <td style="text-align:right;"><asp:Label ID="Label173" CssClass="lbl" runat="server" Text="DP Dag No:"></asp:Label></td>
                <td><asp:TextBox ID="txtDpDagNo" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>
             <td style="text-align:right;"><asp:Label ID="Label174" CssClass="lbl" runat="server" Text="Dp Dag Total:"></asp:Label></td>
                <td><asp:TextBox ID="txtDpDagTotal" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>
                </tr>
                    <tr>
                       <td colspan="4" style="text-align:right;"><asp:Button ID="btnAddL" runat="server" Text="Add"  OnClick="btnAddL_Click" /></td>
                        
                    </tr>
                    <tr>
                         <td  colspan="4" style="text-align:right;">
                             <asp:GridView ID="dgvLand" runat="server" AutoGenerateColumns="False" Font-Bold="False" OnRowDeleting="dgvLand_RowDeleting">
                                 <Columns>
                                     <asp:TemplateField HeaderText="SL.N">
                                         <ItemTemplate>
                                             <%# Container.DataItemIndex + 1 %>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:BoundField DataField="csdagno" HeaderText="CSdagno" SortExpression="intMRRID" />
                                     <asp:BoundField DataField="tCsDag" HeaderText="TotalCsDag" SortExpression="intPOID" />
                                     <asp:BoundField DataField="sadDagNo" HeaderText="SAdagNo" SortExpression="intitemid" />
                                     <asp:BoundField DataField="tSaDag" HeaderText="TotalSaDag" SortExpression="strItem" />
                                     <asp:BoundField DataField="rsDagNo" HeaderText="RSdagNo" SortExpression="rsDagNo" />
                                     <asp:BoundField DataField="tRsDag" HeaderText="TotalRsDag" SortExpression="tRsDag" />
                                     <asp:BoundField DataField="brsDagno" HeaderText="BRsDagno" SortExpression="brsDagno" />
                                     <asp:BoundField DataField="tBrsDag" HeaderText="TotalBrsDag" SortExpression="tBrsDag" />
                                     <asp:BoundField DataField="dpDagno" HeaderText="DpDagno" SortExpression="dpDagno" />
                                     <asp:BoundField DataField="tDpDagno" HeaderText="TotalDpDagno" SortExpression="tDpDagno" />
                                     <asp:CommandField ShowDeleteButton="True" DeleteText="Delete"  />
                                 </Columns>
                             </asp:GridView>
                         </td>
                    </tr>

                <tr>
                <td style="text-align:right;"><asp:Label ID="Label134" CssClass="lbl" runat="server" Text="Khatian CS:"></asp:Label></td>
                <td><asp:TextBox ID="txtKhatianCs" runat="server" CssClass="txtBox"></asp:TextBox></td>  
                <td style="text-align:right;"><asp:Label ID="Label135" CssClass="lbl" runat="server" Text="Khatian SA:"></asp:Label></td>
                <td><asp:TextBox ID="txtKhatian" runat="server" CssClass="txtBox"></asp:TextBox></td>   
                </tr>

                 <tr>
                <td style="text-align:right;"><asp:Label ID="Label138" CssClass="lbl" runat="server" Text="Khatian RS:"></asp:Label></td>
                <td><asp:TextBox ID="txtKhatianRs" runat="server" CssClass="txtBox"></asp:TextBox></td>  
                <td style="text-align:right;"><asp:Label ID="Label139" CssClass="lbl" runat="server" Text="Khatian BRS:"></asp:Label></td>
                <td><asp:TextBox ID="txtKathinBrs" runat="server"  CssClass="txtBox"></asp:TextBox></td>   
                </tr>


                   
                <tr>
                <td style="text-align:left;" colspan="4"><asp:Label ID="Label125" CssClass="lbl" runat="server" Font-Size="small" Font-Bold="true"  Text="Others Information: "></asp:Label></td>
                </tr>

                <tr>
                <td style="text-align:right;"><asp:Label ID="Label126" CssClass="lbl" runat="server" Text="Length(Feet):"></asp:Label></td>
                <td><asp:TextBox ID="txtLengthFeetL" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>  
                <td style="text-align:right;"><asp:Label ID="Label127" CssClass="lbl" runat="server" Text="Breadth (Feet):"></asp:Label></td>
                <td><asp:TextBox ID="txtBreadthFeetL" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>   

                </tr>

                <tr>
                <td style="text-align:right;"><asp:Label ID="Label128" CssClass="lbl" runat="server" Text="Height (Feet):"></asp:Label></td>
                <td><asp:TextBox ID="txtHeightFeetL" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>  
                <td style="text-align:right;"><asp:Label ID="Label129" CssClass="lbl" runat="server" Text="Total Area (SFT):"></asp:Label></td>
                <td><asp:TextBox ID="txtTotalAreaSftL" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>   
                </tr>

                <tr>
                <td style="text-align:right;"><asp:Label ID="Label130" CssClass="lbl" runat="server" Text="Rate Per (SFT):"></asp:Label></td>
                <td><asp:TextBox ID="txtRateSftL" runat="server" CssClass="txtBox"></asp:TextBox></td>  
                
                </tr>


                <tr>
                <td style="text-align:left;" colspan="4"><asp:Label ID="Label115" CssClass="lbl" runat="server" Font-Size="small" Font-Bold="true"  Text="Accounts Part: "></asp:Label></td>
                </tr>
                    <tr>
                 <%--  <td style="text-align:right;"><asp:Label ID="Label116" CssClass="lbl" runat="server" Text="Invoice Value BDT:"></asp:Label></td>
                <td><asp:TextBox ID="txtInvoiceValueL" runat="server" CssClass="txtBox"></asp:TextBox></td>    --%> 
          <td style="text-align:right;"><asp:Label ID="Label118" CssClass="lbl" runat="server" Text="Total Landed Cost:"></asp:Label></td>
                <td><asp:TextBox ID="txtLandedCostL" runat="server" CssClass="txtBox" TextMode="Number"></asp:TextBox></td>  
                <td style="text-align:right;"><asp:Label ID="Label120" CssClass="lbl" runat="server" Text="Other Cost:"></asp:Label></td>
                <td><asp:TextBox ID="txtOtherCostL" runat="server" CssClass="txtBox" TextMode="Number"></asp:TextBox></td>  
          
               
                    </tr>
                    
                    <tr>
                              <td style="text-align:right;"><asp:Label ID="Label122" CssClass="lbl" runat="server" Text="Total  Cost:"></asp:Label></td>
                <td><asp:TextBox ID="txtAcqusitionCostL" runat="server" CssClass="txtBox" TextMode="Number"></asp:TextBox></td>  
                  <td style="text-align:right;"><asp:Label ID="Label124" CssClass="lbl" runat="server" Text="Remarks:"></asp:Label></td>
                <td><asp:TextBox ID="txtRemarksL" runat="server" CssClass="txtBox"></asp:TextBox></td>      

                    </tr>
                  
                    <tr>
                      <td colspan="2" style="text-align:right;"><asp:Button ID="btnSaveLand" runat="server" Text="Save" OnClick="btnSaveLand_Click" /> </td>                         
                       
                      <td colspan="2" style="text-align:right;"><asp:Button ID="btnCloseLand" runat="server" OnClick="btnClose_Click" Text="Close" /> </td>
                                         
                    </tr>
                       
                </table>
                </div>
  
          <%-- Building Asset Parking  class="hdnBuildingDivision"  --%>
            <div id="hdnBuildingDivision"  class="hdnBuildingDivision"   style="width:auto;   height:700px;">
                <table style="width:auto;  float:left; " >    
                   
               <tr>
                <td style="text-align:left;" colspan="4"><asp:Label ID="Label46" CssClass="lbl" runat="server" Font-Size="small" Font-Bold="true"  Text="Asset Additon/Recognition/Registration: "></asp:Label></td>
                </tr>
                
                
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label86" CssClass="lbl" runat="server" Text="Unit Name: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlBuildUnit" runat="server"  CssClass="dropdownList"  AutoPostBack="True" OnSelectedIndexChanged="ddlBuildUnit_SelectedIndexChanged"> </asp:DropDownList>                   
                  
               <td style="text-align:right;"><asp:Label ID="Label88" CssClass="lbl" runat="server" Text="Asset Name:"></asp:Label></td>
                 <td><asp:TextBox ID="txtBuildAssetName" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                </tr>
                     <tr>
                <td style="text-align:right;"><asp:Label ID="Label89" CssClass="lbl" runat="server" Text="Branch:"></asp:Label></td>
                <td><asp:DropDownList ID="ddlBuildJobstation" runat="server"  CssClass="dropdownList" AutoPostBack="False"  ></asp:DropDownList> 

                <td style="text-align:right;"><asp:Label ID="Label90" CssClass="lbl" runat="server" Text="Description:"></asp:Label></td>
                 <td><asp:TextBox ID="txtBuildDescription" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label91" CssClass="lbl" runat="server" Text="Asset Type : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlBuildAssetType" runat="server"  CssClass="dropdownList"  AutoPostBack="False" >
                <asp:ListItem Value="1">Adminstrative</asp:ListItem><asp:ListItem Value="2">Manufacturer</asp:ListItem>
                </asp:DropDownList> 

                    <td style="text-align:right;"><asp:Label ID="Label92" CssClass="lbl" runat="server" Text="HS Code:"></asp:Label></td>
                 <td><asp:TextBox ID="txtBHsCode" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label93" CssClass="lbl" runat="server" Text="Asset Major Catagory : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlBuildMajorCategory" runat="server"  CssClass="dropdownList"   AutoPostBack="False" >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> 

                    <td style="text-align:right;"><asp:Label ID="Label94" CssClass="lbl" runat="server" Text="Store Issue Date:"></asp:Label></td>
                <td><asp:TextBox ID="txtBuildStoreIssueDate" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender14" runat="server" Format="yyyy-MM-dd" TargetControlID="txtBuildStoreIssueDate">
                </cc1:CalendarExtender>   </td>       

                
                </tr>
                   
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label95" CssClass="lbl" runat="server" Text="Asset Minor Category_1: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlBMinorCategory1" runat="server"  CssClass="dropdownList"   AutoPostBack="False" >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> 
                    <td style="text-align:right;"><asp:Label ID="Label96" CssClass="lbl" runat="server" Text="GRN Date: "></asp:Label></td>
                <td><asp:TextBox ID="txtBGRNDate" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender21" runat="server" Format="yyyy-MM-dd" TargetControlID="txtBGRNDate">
                </cc1:CalendarExtender>   </td>  
               

                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label97" CssClass="lbl" runat="server" Text="Asset Minor Category_2: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlBMinorCategory2" runat="server"  CssClass="dropdownList"   AutoPostBack="False" >
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> 
                    <td style="text-align:right;"><asp:Label ID="Label98" CssClass="lbl" runat="server" Text="Date Place in Service(DPS): "></asp:Label></td>
                <td><asp:TextBox ID="txtBServiceDate" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender22" runat="server" Format="yyyy-MM-dd" TargetControlID="txtBServiceDate">
                </cc1:CalendarExtender>   </td> 
                
                </tr>
                    <tr>
                 <td style="text-align:right;"><asp:Label ID="Label178" CssClass="lbl" runat="server" Text="Project ID:"></asp:Label></td>
                 <td><asp:TextBox ID="txtProjectIDB" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                <td style="text-align:right;"><asp:Label ID="Label179" CssClass="lbl" runat="server" Text="Project Name: "></asp:Label></td>
                <td><asp:TextBox ID="txtProjectNameB" runat="server" CssClass="txtBox"></asp:TextBox></td>
   
                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label117" CssClass="lbl" runat="server" Text="Cost Center: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlBCostCenter" runat="server"  CssClass="dropdownList"   AutoPostBack="False" ></asp:DropDownList> 
                

                     
                </tr>
                 <%--<tr>
                <td style="text-align:left;" colspan="4"><asp:Label ID="Label119" CssClass="lbl" runat="server" Font-Size="small" Font-Bold="true"  Text="Land Location: "></asp:Label></td>
                </tr>
                <tr>
                 <td style="text-align:right;"><asp:Label ID="Label121" CssClass="lbl" runat="server" Text="District:"></asp:Label></td>
                  <td><asp:DropDownList ID="ddlBDistict" runat="server"  CssClass="dropdownList"  AutoPostBack="True"></asp:DropDownList> </td>        

                 <td style="text-align:right;"><asp:Label ID="Label123" CssClass="lbl" runat="server" Text="Thana:"></asp:Label></td>
                  <td><asp:DropDownList ID="ddlBThana" runat="server"  CssClass="dropdownList"  AutoPostBack="True"></asp:DropDownList> </td>
   
                </tr>
                <tr>                 
                 <td style="text-align:right;"><asp:Label ID="Label140" CssClass="lbl" runat="server" Text="Mouza:"></asp:Label></td>
                 <td><asp:TextBox ID="txtBMouza" runat="server" CssClass="txtBox"></asp:TextBox></td>   
                </tr>--%>

               
                 <tr>
                <td style="text-align:left;" colspan="4"><asp:Label ID="Label141" CssClass="lbl" runat="server" Font-Size="small" Font-Bold="true"  Text="Admin Part: "></asp:Label></td>
                </tr>

                     <tr>
                 <td style="text-align:right;"><asp:Label ID="Label142" CssClass="lbl" runat="server" Text="Supplier/Local Agent Name:"></asp:Label></td>
                 <td><asp:TextBox ID="txtBSupplier" runat="server" Enabled="false" CssClass="txtBox"></asp:TextBox></td>        

                <td style="text-align:right;"><asp:Label ID="Label143" CssClass="lbl" runat="server" Text="Country Origin : "></asp:Label></td>
                <td><asp:TextBox ID="txtBCountryOrigin" runat="server" CssClass="txtBox"></asp:TextBox></td>
   
                </tr>
                  <tr>
                <td style="text-align:right;"><asp:Label ID="Label144" CssClass="lbl" runat="server" Text="Po Number:"></asp:Label></td>
                <td><asp:TextBox ID="txtBPoNumber" runat="server" Enabled="false" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>     
                 <td style="text-align:right;"><asp:Label ID="Label145" CssClass="lbl" runat="server" Text="Name of Manufacturer : "></asp:Label></td>
                <td><asp:TextBox ID="txtBNameManufacturer" runat="server" CssClass="txtBox"></asp:TextBox></td>
                   </tr>
                    <tr>
                         <td style="text-align:right;"><asp:Label ID="Label146" CssClass="lbl" runat="server" Text="Po Date:"></asp:Label></td>
                <td><asp:TextBox ID="txtBPoDate" runat="server" CssClass="txtBox"></asp:TextBox>  
                <cc1:CalendarExtender ID="CalendarExtender23" runat="server" Format="yyyy-MM-dd" TargetControlID="txtBPoDate">
                </cc1:CalendarExtender>   </td>

                        <td style="text-align:right;"><asp:Label ID="Label147" CssClass="lbl" runat="server" Text="Manufacturer Provice SL No:"></asp:Label></td>
                <td><asp:TextBox ID="txtBProvideSl" runat="server" CssClass="txtBox"></asp:TextBox></td>     

                    </tr>
                    <tr>
                        <td style="text-align:right;"><asp:Label ID="Label148" CssClass="lbl" runat="server" Text="Waranty Expiry Date:"></asp:Label></td>
                <td><asp:TextBox ID="txtBWarantyExDate" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender24" runat="server" Format="yyyy-MM-dd" TargetControlID="txtBWarantyExDate">
                </cc1:CalendarExtender>   </td>
                         <td style="text-align:right;"><asp:Label ID="Label149" CssClass="lbl" runat="server" Text="Model No:"></asp:Label></td>
                <td><asp:TextBox ID="txtBModelNo" runat="server" CssClass="txtBox"></asp:TextBox></td>  
                    </tr>
                    <tr>
                        <td style="text-align:right;"><asp:Label ID="Label150" CssClass="lbl" runat="server" Text="Date of Instalation:"></asp:Label></td>
                <td><asp:TextBox ID="txtBDateInstalation" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender25" runat="server" Format="yyyy-MM-dd" TargetControlID="txtBDateInstalation">
                </cc1:CalendarExtender>   </td>
                         <td style="text-align:right;"><asp:Label ID="Label151" CssClass="lbl" runat="server" Text="LC Number:"></asp:Label></td>
                <td><asp:TextBox ID="txtBLcNumber" runat="server" CssClass="txtBox"></asp:TextBox></td>   
                    </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label152" CssClass="lbl" runat="server" Text="Asset Location:"></asp:Label></td>
                <td><asp:TextBox ID="txtBAssetLocation" runat="server" CssClass="txtBox"></asp:TextBox></td>  
                <td style="text-align:right;"><asp:Label ID="Label153" CssClass="lbl" runat="server" Text="Others:"></asp:Label></td>
                <td><asp:TextBox ID="txtBOthers" runat="server" CssClass="txtBox"></asp:TextBox></td>     

                </tr>
                    <tr>
                  <td style="text-align:right;"><asp:Label ID="Label154" CssClass="lbl" runat="server" Text="User Enrollment:"></asp:Label></td>
                <td><asp:TextBox ID="txtBUserEnroll" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>  
                <td style="text-align:right;"><asp:Label ID="Label155" CssClass="lbl" runat="server" Text="Rated Capacity:"></asp:Label></td>
                <td><asp:TextBox ID="txtBRatedCapacity" runat="server" CssClass="txtBox"></asp:TextBox></td>     

                    </tr>
                   
               
                    
                <tr>
                <td style="text-align:left;" colspan="4"><asp:Label ID="Label164" CssClass="lbl" runat="server" Font-Size="small" Font-Bold="true"  Text="Others Information: "></asp:Label></td>
                </tr>

                <tr>
                <td style="text-align:right;"><asp:Label ID="Label165" CssClass="lbl" runat="server" Text="Length(Feet):"></asp:Label></td>
                <td><asp:TextBox ID="txtBLengthFeet" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>  
                <td style="text-align:right;"><asp:Label ID="Label166" CssClass="lbl" runat="server" Text="Breadth (Feet):"></asp:Label></td>
                <td><asp:TextBox ID="txtBBreadthFeet" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>   

                </tr>

                <tr>
                <td style="text-align:right;"><asp:Label ID="Label167" CssClass="lbl" runat="server" Text="Height (Feet):"></asp:Label></td>
                <td><asp:TextBox ID="txtBHeightfeet" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>  
                <td style="text-align:right;"><asp:Label ID="Label168" CssClass="lbl" runat="server" Text="Total Area (SFT):"></asp:Label></td>
                <td><asp:TextBox ID="txtBTotalSft" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>   
                </tr>

                <tr>
                <td style="text-align:right;"><asp:Label ID="Label169" CssClass="lbl" runat="server" Text="Rate Per (SFT):"></asp:Label></td>
                <td><asp:TextBox ID="txtBRateSft" runat="server" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>  
                
                </tr>


                 <tr>
                <td style="text-align:left;" colspan="4"><asp:Label ID="Label156" CssClass="lbl" runat="server" Font-Size="small" Font-Bold="true"  Text="Accounts Part: "></asp:Label></td>
                </tr>
                    <tr>
                   <td style="text-align:right;"><asp:Label ID="Label157" CssClass="lbl" runat="server" Text="Invoice Value BDT:"></asp:Label></td>
                <td><asp:TextBox ID="txtBInvoiceValueBdt" runat="server" CssClass="txtBox" TextMode="Number" ></asp:TextBox></td>  
                <td style="text-align:right;"><asp:Label ID="Label158" CssClass="lbl" runat="server" Text="Recommand Life:"></asp:Label></td>
                <td><asp:TextBox ID="txtBRecommandLife" runat="server" CssClass="txtBox" TextMode="Number"></asp:TextBox></td>     

                    </tr>
                    <tr>
                         <td style="text-align:right;"><asp:Label ID="Label159" CssClass="lbl" runat="server" Text="Landed Cost:"></asp:Label></td>
                <td><asp:TextBox ID="txtBLandCost" runat="server"  CssClass="txtBox" TextMode="Number"></asp:TextBox></td>  
                <td style="text-align:right;"><asp:Label ID="Label160" CssClass="lbl" runat="server" Text="Method of Depreciation:"></asp:Label></td>
                 <td><asp:DropDownList ID="ddlBDepMethod" runat="server"  CssClass="dropdownList"  AutoPostBack="False"  >  
                      <asp:ListItem Value="1" Text="Straight line "></asp:ListItem>    <asp:ListItem Value="2" Text="Reducing Balance"></asp:ListItem>   
                </asp:DropDownList> </td>
                 

                    </tr>
                    <tr>
                         <td style="text-align:right;"><asp:Label ID="Label161" CssClass="lbl" runat="server" Text="Erection & Other Cost:"></asp:Label></td>
                <td><asp:TextBox ID="txtBOtherCost" runat="server"  CssClass="txtBox"></asp:TextBox></td>  
                <td style="text-align:right;"><asp:Label ID="Label121" CssClass="lbl" runat="server" Text="Depreciation Rate:"></asp:Label></td>
                <td><asp:TextBox ID="txtDepRateB" runat="server" AutoPostBack="true" TextMode="Number" CssClass="txtBox" ></asp:TextBox></td>  
           
                    </tr>
                    <tr>
                         <td style="text-align:right;"><asp:Label ID="Label162" CssClass="lbl" runat="server" Text="Total Acquisition Cost:"></asp:Label></td>
                <td><asp:TextBox ID="txtBAcquisitionCost" runat="server" CssClass="txtBox" TextMode="Number"></asp:TextBox></td>  
                <td style="text-align:right;"><asp:Label ID="Label163" CssClass="lbl" runat="server" Text="Depreciation Run Date:"></asp:Label></td>
                 <td><asp:TextBox ID="txtBDepRunDate" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender26" runat="server" Format="yyyy-MM-dd" TargetControlID="txtBDepRunDate">
                </cc1:CalendarExtender>   </td>  

                    </tr>
                <tr>
               
                <td style="text-align:right;"><asp:Label ID="Label170" CssClass="lbl" runat="server" Text="Remarks:"></asp:Label></td>
                <td><asp:TextBox ID="txtBRemarks" runat="server" CssClass="txtBox"></asp:TextBox></td>      

                </tr>
                
                                    
                    <tr>
                      <td colspan="2" style="text-align:right;"><asp:Button ID="btnSaveBuild" runat="server" Text="Save" OnClick="btnSaveBuild_Click" /> </td>                          
                       
                      <td colspan="2" style="text-align:right;"><asp:Button ID="btnCloseVuilding" runat="server" OnClick="btnClose_Click" Text="Close" /> </td>
                      
                    </tr>
                       
                </table>
                </div>

    
              
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    <%--</asp:UpdatePanel>--%>
    </form>
</body>
</html>
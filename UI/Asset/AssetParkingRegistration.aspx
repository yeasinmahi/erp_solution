<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetParkingRegistration.aspx.cs" Inherits="UI.Asset.AssetParkingRegistration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <asp:PlaceHolder ID="PlaceHolder2" runat="server"><%: Scripts.Render("~/Content/Bundle/updatedJs") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/updatedCss" /> 

    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>    
    <!-- Bootstrap -->
<%--<script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
<script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>
<link rel="stylesheet" href='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css'--%>

    <%--media="screen" />--%>
<!-- Bootstrap -->
  
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
      
    <script type="text/javascript"> 
         function OpenHdnDiv() {
             $("#hdnDivision").fadeIn("slow");
             document.getElementById('hdnDivision').style.visibility = 'visible';
         }

         function ClosehdnDivision() {

             $("#hdnDivision").fadeOut("slow");
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
     <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnPreConfirm" runat="server" />
    <asp:HiddenField ID="hdnEnrollUnit" runat="server" /><asp:HiddenField ID="hdnReceive" runat="server" /><asp:HiddenField ID="hdnItemID" runat="server" />
         <asp:HiddenField ID="hdnMrrID" runat="server" /><asp:HiddenField ID="hdnPoID" runat="server" />
                
           <table>
                <tr>
                <td style="text-align:left;"><asp:Label ID="Label47" CssClass="lbl" runat="server" Font-Size="small" Font-Bold="true"  Text="Asset Parking Registration: "></asp:Label></td>
                </tr>
           </table>
           <table>
               <tr>
                   <td style="text-align:right;" ><asp:Label ID="Label1" CssClass="lbl" runat="server" Font-Bold="true" Text="Unit Name: "></asp:Label></td>
                   <td><asp:DropDownList ID="ddlUnitby" runat="server" AutoPostBack="true"   CssClass="ddList" OnSelectedIndexChanged="ddlUnitby_SelectedIndexChanged"> </asp:DropDownList>  </td>                 
                   <td style="text-align:right;" ><asp:Label ID="Label20" CssClass="lbl" Font-Bold="true" runat="server" Text="WH Name: "></asp:Label></td>
                   <td><asp:DropDownList ID="ddlWh" runat="server" AutoPostBack="true"   CssClass="ddList" > </asp:DropDownList>  </td>                 
                    
               </tr>
            <tr>
                 <td style="text-align:right;"><asp:Label ID="lblMrr" Text="Mrr No"  runat="server"></asp:Label></td>
                 <td>  <asp:TextBox ID="txtMrrId" runat="server" CssClass="txtBox"></asp:TextBox></td>
                 <td><asp:Button ID="btnManuals" runat="server" Visible="true"  OnClick="btnManuals_Click"  Text="Manual"  /> 
                   <asp:Button ID="btnMrrView" runat="server"  Font-Bold="true"  onclick="btnMrrView_Click" Text="Show"   /></td>
                  
                  <td style="text-align:right;"><asp:Label ID="lblMessage" Font-Bold="true" ForeColor="Green"  runat="server"></asp:Label></td>
            </tr>
                </table>
          <table>
               <tr>

                <td>
               <asp:GridView ID="dgvGridView" runat="server"  Font-Bold="False" AutoGenerateColumns="False">
                   <Columns>
                    <asp:TemplateField HeaderText="SL.N"> 
                     <ItemTemplate> <%# Container.DataItemIndex + 1 %>  </ItemTemplate></asp:TemplateField>
                           <asp:BoundField DataField="strWareHoseName" HeaderText="WH" SortExpression="strWareHoseName"/>
                      <asp:BoundField DataField="intMRRID" HeaderText="MRRID" SortExpression="intMRRID"/>
                       <asp:BoundField DataField="intPOID" HeaderText="POID" SortExpression="intPOID" />
                       <asp:BoundField DataField="intitemid" HeaderText="ItemID" SortExpression="intitemid" />

                      <asp:BoundField DataField="strItem" HeaderText="ItemName" SortExpression="strItem" />
                      <asp:BoundField DataField="strUoM" HeaderText="Description" Visible="false" SortExpression="strCategoryName" />        
                       <asp:BoundField DataField="strUoM" HeaderText="UOM" SortExpression="strUoM" />
                      <asp:BoundField DataField="numReceiveQty" HeaderText="Quantity"  SortExpression="numReceiveQty" /> 
                        <asp:BoundField DataField="monFCRate" HeaderText="Rate"  Visible="false" SortExpression="monFCRate" /> 
                       <asp:BoundField DataField="monBDTTotal" HeaderText="Value" SortExpression="monBDTTotal" />
                      <asp:BoundField DataField="strCategory" HeaderText="MajorCategory"  SortExpression="strCategory" />    
                       <asp:BoundField DataField="strCode" HeaderText="GlCode" Visible="false" SortExpression="strCode" />
                                                           
                       
         
                       <asp:TemplateField HeaderText="Submit">
                           <ItemTemplate>
                            <asp:Button ID="btnSubmit" runat="server"  CommandArgument='<%#GetJSFunctionString( Eval("intitemid"),Eval("intPOID"),Eval("intMRRID"),Eval("numReceiveQty")) %>' Text="Registration" OnClick="btnSubmit_Click" />
                           </ItemTemplate>
                       </asp:TemplateField> 
                   </Columns>  </asp:GridView> </td>     
               </tr>
           </table>
         </div>

     <%--   General Asset Parking Registratiron         class="hdnDivision" --%> 
                <div id="hdnDivision"   class="hdnDivision"  style="width:auto;  height:500px;">
                     <table style="width:auto;  float:left; " >   
                        
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label51" CssClass="lbl" runat="server" Text="Unit Name: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="true"  CssClass="ddList"    OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"> </asp:DropDownList>  </td>                 
                  
               <td style="text-align:right;"><asp:Label ID="Label15" CssClass="lbl" runat="server" Text="Asset Name:"></asp:Label></td>
                 <td><asp:TextBox ID="txtAssetname" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                </tr>
                     <tr>
                <td style="text-align:right;"><asp:Label ID="lblBranch" CssClass="lbl" runat="server" Text="Branch:"></asp:Label></td>
                <td><asp:DropDownList ID="dlJobstation" runat="server" AutoPostBack="true"   CssClass="ddList"   OnSelectedIndexChanged="ddlJob_SelectedIndexChanged"></asp:DropDownList> </td>

                <td style="text-align:right;"><asp:Label ID="Label16" CssClass="lbl" runat="server" Text="Description:"></asp:Label></td>
                 <td><asp:TextBox ID="txtDescription" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="lblAssetType" CssClass="lbl" runat="server" Text="Asset Type : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlAssetType" runat="server"  CssClass="ddList"  >
                <asp:ListItem Value="1">Adminstrative</asp:ListItem><asp:ListItem Value="2">Manufacturer</asp:ListItem>
                </asp:DropDownList> </td>

                    <td style="text-align:right;"><asp:Label ID="Label17" CssClass="lbl" runat="server" Text="HS Code:"></asp:Label></td>
                 <td><asp:TextBox ID="txtHsCode" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="lblMajor" CssClass="lbl" runat="server" Text="Asset Major Catagory : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlMajorCat" runat="server"   CssClass="ddList"   OnSelectedIndexChanged="ddlMajorCat_SelectedIndexChanged">
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> </td>

                    <td style="text-align:right;"><asp:Label ID="Label18" CssClass="lbl" runat="server" Text="Store Issue Date:"></asp:Label></td>
                <td><asp:TextBox ID="txtIssueDate" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender8" runat="server" Format="yyyy-MM-dd" TargetControlID="txtIssueDate">
                </cc1:CalendarExtender>   </td>       

                
                </tr>
                   
                <tr>
                <td style="text-align:right;"><asp:Label ID="lblMinorCat1" CssClass="lbl" runat="server" Text="Asset Minor Category_1: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlMinorCate1" runat="server"  CssClass="ddList"    OnSelectedIndexChanged="ddlMinorCate1_SelectedIndexChanged">
                <asp:ListItem Value="1">test1</asp:ListItem><asp:ListItem Value="2">test2</asp:ListItem>
                </asp:DropDownList> </td>
                    <td style="text-align:right;"><asp:Label ID="lblGrndDate" CssClass="lbl" runat="server" Text="GRN Date: "></asp:Label></td>
                <td><asp:TextBox ID="txtGrndDate" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy-MM-dd" TargetControlID="txtGrndDate">
                </cc1:CalendarExtender>   </td>  
               

                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label53" CssClass="lbl" runat="server" Text="Asset Minor Category_2: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlMinorCate2" runat="server"  CssClass="ddList"  > </asp:DropDownList> </td>
               
               
                    <td style="text-align:right;"><asp:Label ID="lblPlaceDate" CssClass="lbl" runat="server" Text="Date Place in Service(DPS): "></asp:Label></td>
                <td><asp:TextBox ID="txtServiceDate" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Format="yyyy-MM-dd" TargetControlID="txtServiceDate">
                </cc1:CalendarExtender>   </td> 
                
                      

                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="lblCost" CssClass="lbl" runat="server" Text="Cost Center: "></asp:Label></td>
                <td><asp:DropDownList ID="ddlCostCenter" runat="server"  CssClass="ddList"  ></asp:DropDownList></td>   
                
                <td style="text-align:right;"><asp:Label ID="lblAssetQty" CssClass="lbl" runat="server" Text="Asset Qty: "></asp:Label></td>
                 <td><asp:TextBox ID="txtAssetQty" runat="server" CssClass="txtBox"></asp:TextBox></td>  
                </tr>
                     <tr>
                <td style="text-align:right;"><asp:Label ID="Label12" CssClass="lbl" runat="server" Text="Project ID: "></asp:Label></td>
                <td><asp:TextBox ID="txtProjectID" runat="server"  CssClass="txtBox"  ></asp:TextBox></td>   
                
                <td style="text-align:right;"><asp:Label ID="Label19" CssClass="lbl" runat="server" Text="Project Name: "></asp:Label></td>
                 <td><asp:TextBox ID="txtProjectName" runat="server" CssClass="txtBox"></asp:TextBox></td>        
 
              
                     
                </tr>
                
                 <tr>
                <td style="text-align:left;" colspan="4"><asp:Label ID="Label2" CssClass="lbl" runat="server" Font-Size="small" Font-Bold="true"  Text="Admin Part: "></asp:Label></td>
                </tr>
                 <tr>
                 <td style="text-align:right;"><asp:Label ID="lblSupplier" CssClass="lbl" runat="server" Text="Supplier/Local Agent Name:"></asp:Label></td>
                 <td><asp:TextBox ID="txtSuppliers" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                <td style="text-align:right;"><asp:Label ID="lblCountryOrigin" CssClass="lbl" runat="server" Text="Country Origin : "></asp:Label></td>
                <td><asp:TextBox ID="txtCountryOrigin" runat="server" CssClass="txtBox"></asp:TextBox></td>
   
                </tr>
                  <tr>
                <td style="text-align:right;"><asp:Label ID="lblPonumber" CssClass="lbl" runat="server" Text="Po Number:"></asp:Label></td>
                <td><asp:TextBox ID="txtPonumbers" runat="server"   CssClass="txtBox"></asp:TextBox></td>     
                 <td style="text-align:right;"><asp:Label ID="Label52" CssClass="lbl" runat="server" Text="Name of Manufacturer : "></asp:Label></td>
                <td><asp:TextBox ID="txtManufacturer" runat="server" CssClass="txtBox"></asp:TextBox></td>
                   </tr>
                    <tr>
                         <td style="text-align:right;"><asp:Label ID="lblPodate" CssClass="lbl" runat="server" Text="Po Date:"></asp:Label></td>
                <td><asp:TextBox ID="dtePoDate" runat="server" CssClass="txtBox"></asp:TextBox>  
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="dtePoDate">
                </cc1:CalendarExtender>   </td>

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
                <td><asp:TextBox ID="txtInvoiceValue" runat="server" CssClass="txtBox" ></asp:TextBox></td>  
                <td style="text-align:right;"><asp:Label ID="Label8" CssClass="lbl" runat="server" Text="Recommand Life:"></asp:Label></td>
                <td><asp:TextBox ID="txtRecommandLife" runat="server" CssClass="txtBox"></asp:TextBox></td>     

                    </tr>
                    <tr>
                         <td style="text-align:right;"><asp:Label ID="Label9" CssClass="lbl" runat="server" Text="Landed Cost:"></asp:Label></td>
                <td><asp:TextBox ID="txtLandedCost" runat="server" AutoPostBack="true" CssClass="txtBox" OnTextChanged="txtLandedCost_TextChanged"></asp:TextBox></td>  
                <td style="text-align:right;"><asp:Label ID="Label10" CssClass="lbl" runat="server" Text="Method of Depreciation:"></asp:Label></td>
                 <td><asp:DropDownList ID="ddlMethodOfDep" runat="server"  CssClass="ddList"  >  
                      <asp:ListItem Value="1" Text="Straight line "></asp:ListItem>    <asp:ListItem Value="2" Text="Reducing Balance"></asp:ListItem>   
                </asp:DropDownList> </td>
                 

                    </tr>
                    <tr>
                         <td style="text-align:right;"><asp:Label ID="Label11" CssClass="lbl" runat="server" Text="Erection & Other Cost:"></asp:Label></td>
                <td><asp:TextBox ID="txtErectionOtherCost" runat="server" AutoPostBack="true" CssClass="txtBox" OnTextChanged="txtErectionOtherCost_TextChanged"></asp:TextBox></td>  
                <td style="text-align:right;"><asp:Label ID="Label170" CssClass="lbl" runat="server" Text="Rate of Depreciation:"></asp:Label></td>
                <td><asp:TextBox ID="txtRateDep" runat="server" AutoPostBack="true" CssClass="txtBox" ></asp:TextBox></td>  
               
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
                     <td style="text-align:right;"><asp:Label ID="lblAccdep" CssClass="lbl" runat="server" Text="Total Accumulated Dep:"></asp:Label></td>
                <td><asp:TextBox ID="txtAccDep" runat="server" CssClass="txtBox"></asp:TextBox></td>        

                </tr> 
                       
                    <tr>
                        <td colspan="4" style="text-align:right;">
                            <asp:Button ID="btnSave" runat="server"  OnClientClick="return Validation();" class="btn btn-primary"  OnClick="btnSave_Click" Text="Save" />
                            <asp:Button ID="btnClose" runat="server"  class="btn btn-secondary"      OnClick=" btnClose_Click" Text="Close" />
                        </td>
                         
                    </tr>
               
                </table>
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
            
              
               
           
            
        </div>
         
        </div>
        </div>
    <!-- Modal Popup --> 

    <cc1:ModalPopupExtender ID="ModalPopupExtender1" BehaviorID="mpe" runat="server"
    PopupControlID="pnlPopup" TargetControlID="btnManual" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none">
    <div class="header">
    Modal Popup
    </div>
    <div class="body">
    This is a Modal Popup.
    <br />
    <asp:Button ID="btnHide" runat="server" Text="Hide Modal Popup" OnClientClick="return HideModalPopup()" />
    </div>
    </asp:Panel>

        </div> 
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
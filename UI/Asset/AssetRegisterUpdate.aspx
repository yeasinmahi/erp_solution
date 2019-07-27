<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetRegisterUpdate.aspx.cs" Inherits="UI.Asset.AssetRegisterUpdate" %>

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
        .auto-style1 {
            height: 30px;
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
  color: Blue;
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
     <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnsearch" runat="server" />
    <asp:HiddenField ID="hdnEnrollUnit" runat="server" /><asp:HiddenField ID="hdnUnitIDByddl" runat="server" /><asp:HiddenField ID="hdnBankID" runat="server" /><asp:HiddenField ID="hdnconfirm" runat="server" />
      <td>
          <asp:Button Text="Update General Asset" BorderStyle="Solid" ID="Tab1" CssClass="Initial" runat="server"
              OnClick="Tab1_Click" BackColor="#FFCC99" />          
   <asp:Button Text="Update Vehicle Asset" BorderStyle="Solid" ID="Tab2" CssClass="Initial" runat="server"
                 BackColor="#FFCC99" OnClick="Tab2_Click"/>
          <asp:Button Text="Update Land Asset" BorderStyle="Solid" ID="Tab3" CssClass="Initial" runat="server"
            OnClick="Tab3_Click"  BackColor="#FFCC99" />
         <asp:Button Text="Update Building Asset" BorderStyle="Solid" ID="Tab4" CssClass="Initial" runat="server"
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
                 <td style="text-align:right;"><asp:Label ID="LblAssetCode" CssClass="lbl" runat="server" Text="Asset Code : "></asp:Label></td>
                <td><asp:TextBox ID="TxtAssetCode" runat="server" CssClass="txtBox" AutoPostBack="true" OnTextChanged="TxtAssetCode_TextChanged"></asp:TextBox></td>
              
             </tr>
        <tr>
                <td style="text-align:right;"><asp:Label ID="LblUnit" CssClass="lbl" runat="server" Text="Unit : "></asp:Label></td>
                <td><asp:DropDownList ID="DdlUnit" runat="server"  CssClass="dropdownList"  AutoPostBack="True" OnSelectedIndexChanged="DdlUnit_SelectedIndexChanged"></asp:DropDownList>
                <td style="text-align:right;"><asp:Label ID="LblJobStation" CssClass="lbl" runat="server" Text="Job Station : "></asp:Label></td>
                <td><asp:DropDownList ID="DlJobStation" runat="server" AutoPostBack="true" CssClass="dropdownList" OnSelectedIndexChanged="DlJobStation_SelectedIndexChanged1" ></asp:DropDownList>
                
                       <td style="text-align:right;"><asp:Label ID="Label150" CssClass="lbl" runat="server" Text="Asset Type: "></asp:Label></td>
                <td><asp:DropDownList ID="DdlMainType" runat="server"  CssClass="dropdownList">
                    <asp:ListItem Text="Administrative"></asp:ListItem>
                    <asp:ListItem Text="Manufacturing"></asp:ListItem>
                    <asp:ListItem Text="Administrative"></asp:ListItem>
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
                <td><asp:TextBox ID="TxtAssetName" runat="server" CssClass="txtBox"></asp:TextBox></td>
               
                  <td style="text-align:right;"><asp:Label ID="LblAssetDescription" CssClass="lbl" runat="server" Text="Description of Asset : "></asp:Label></td>
                <td><asp:TextBox ID="TxtAssetDescription" runat="server" CssClass="txtBox"></asp:TextBox></td>
           
                  
                </tr>

                <tr>
                    <td style="text-align:right;"><asp:Label ID="LblHSCode" CssClass="lbl" runat="server" Text="HSCode : "></asp:Label></td>
                <td><asp:TextBox ID="TxtHSCode" runat="server" CssClass="txtBox"></asp:TextBox></td>
                
                

               <td style="text-align:right;"><asp:Label ID="LblManufacturer" CssClass="lbl" runat="server" Text="Name of Manufacturer : "></asp:Label></td>
                <td><asp:TextBox ID="TxtManufacturer" runat="server" CssClass="txtBox"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="LblContryOrigin" CssClass="lbl" runat="server" Text="Country of Origin : "></asp:Label></td>
                <td><asp:TextBox ID="TxtContryOrigin" runat="server" CssClass="txtBox"></asp:TextBox></td>
              
                </tr>
                 <tr>

                <td style="text-align:right;"><asp:Label ID="LblCountryManufacture" CssClass="lbl" runat="server" Text="Country of Manufacturing : "></asp:Label></td>
                <td><asp:TextBox ID="TxtCountryManufacture" runat="server" CssClass="txtBox"></asp:TextBox></td>
  
                 <td style="text-align:right;"><asp:Label ID="LblSuppName" CssClass="lbl" runat="server" Text="Supplier / Local Agent Name : "></asp:Label></td>
                <td><asp:TextBox ID="TxtSuppName" runat="server" CssClass="txtBox"></asp:TextBox></td>
                   <td style="text-align:right;"><asp:Label ID="LblLCNo" CssClass="lbl" runat="server" Text="LC Number : "></asp:Label></td>
                <td><asp:TextBox ID="TxtLCNo" runat="server" CssClass="txtBox"></asp:TextBox></td>
                       
                </tr>
               <tr>
                  
                <td style="text-align:right;"><asp:Label ID="LblDteLC" CssClass="lbl" runat="server" Text="LC Date : "></asp:Label></td>
                 <td><asp:TextBox ID="TxtDteLC" runat="server" CssClass="txtBox" autocomplete="off"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDteLC">
                    </cc1:CalendarExtender> 
                   
                <td style="text-align:right;"><asp:Label ID="LblPONo" CssClass="lbl" runat="server" Text="Po Number : "></asp:Label></td>
                <td><asp:TextBox ID="TxtPONo" runat="server" CssClass="txtBox"></asp:TextBox></td>
                 <td style="text-align:right;"><asp:Label ID="LblDtePO" CssClass="lbl" runat="server" Text="Po Date : "></asp:Label></td>
                  <td><asp:TextBox ID="TxtDtePo" runat="server" CssClass="txtBox" autocomplete="off"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDtePo">
                    </cc1:CalendarExtender> 
                </tr>
                 
                 <tr>
               
            <td style="text-align:right;"><asp:Label ID="LblWarrintyPreoid" CssClass="lbl" runat="server" Text="Warranty Expiry Date : "></asp:Label></td>
                
              <td><asp:TextBox ID="TxtDteWarranty" runat="server" CssClass="txtBox" autocomplete="off"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDteWarranty">
                    </cc1:CalendarExtender> 
              
                     
              <td style="text-align:right;"><asp:Label ID="LblInvoice" CssClass="lbl" runat="server" Text="Invoice Value : "></asp:Label></td>
                <td><asp:TextBox ID="TxtInvoice" runat="server" CssClass="txtBox"></asp:TextBox></td>

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
             </tr>
          
             <tr>
             <td>Operation Of Factory</td>
                 <tr>
                     <td style="text-align:right;">
                         <asp:Label ID="LblInsLocation" runat="server" CssClass="lbl" Text="Installation Location: "></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="TxtInsLocation" runat="server" CssClass="txtBox"></asp:TextBox>
                     </td>
                     <td style="text-align:right;">
                         <asp:Label ID="LblManuProvideSl" runat="server" CssClass="lbl" Text="Manufacturer Provided SL No : "></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="TxtManuProvideSl" runat="server" CssClass="txtBox"></asp:TextBox>
                     </td>
                     <td style="text-align:right;">
                         <asp:Label ID="LblFunction" runat="server" CssClass="lbl" Text="Function of the Machine : "></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="TxtFunction" runat="server" CssClass="txtBox"></asp:TextBox>
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
                         <asp:TextBox ID="TxtDteInstalation" runat="server" CssClass="txtBox" autocomplete="off"></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDteInstalation">
                         </cc1:CalendarExtender>
                         <td style="text-align:right;">
                             <asp:Label ID="LblErectionCost" runat="server" CssClass="lbl" Text="Erection Installation Cost: "></asp:Label>
                         </td>
                         <td>
                             <asp:TextBox ID="TxtErectionCost" runat="server" CssClass="txtBox"></asp:TextBox>
                         </td>
                         <td>
                             <asp:Button ID="Button3" runat="server" Text="Save" />
                         </td>
                     </td>
                 </tr>
               <tr>
                <td style="text-align:right;"><asp:Label ID="LblDepartment" CssClass="lbl" runat="server" Text="Department : "></asp:Label></td>
                <td><asp:DropDownList ID="DdlDept" runat="server"  CssClass="dropdownList"></asp:DropDownList> 
              <td style="text-align:right;">
                  <asp:Label ID="Label153" runat="server" CssClass="lbl" Text="Model No : "></asp:Label>
                 </td>
                  <td>
                    <asp:TextBox ID="TxtFModel" runat="server" CssClass="txtBox"  ></asp:TextBox>
                    </td>
                 </tr>
                 <tr>
                     <td>Accounts Department</td>
                     <tr>
                         <td style="text-align:right;">
                             <asp:Label ID="LblDteAcusition" runat="server" CssClass="lbl" Text="Date Of Acusition: "></asp:Label>
                         </td>
                         <td>
                             <asp:TextBox ID="TxtDteAcusition" runat="server" CssClass="txtBox" autocomplete="off"></asp:TextBox>
                             <cc1:CalendarExtender ID="dteAcusition" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDteAcusition">
                             </cc1:CalendarExtender>
                             <td style="text-align:right;">
                                 <asp:Label ID="LblRecomandLife" runat="server" CssClass="lbl" Text="Recommand Life : "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtRecomandLife" runat="server" CssClass="txtBox"></asp:TextBox>
                             </td>
                             <td style="text-align:right;">
                                 <asp:Label ID="LblSalvageValue" runat="server" CssClass="lbl" Text="Estimation Salvage Value : "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtEstSalvageValue" runat="server" CssClass="txtBox"></asp:TextBox>
                             </td>
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
                       <td style="text-align:right;"><asp:Label ID="Label27" CssClass="lbl" runat="server" Text="Active Status : "></asp:Label></td>
                <td><asp:DropDownList ID="DdlDesiable" runat="server"  CssClass="dropdownList">
                     <asp:ListItem value="0" Selected="false">Inactive</asp:ListItem>
                    <asp:ListItem value="1" Selected="True">Active</asp:ListItem>
                        
                    </asp:DropDownList> 
                     </tr>
               
             </table>


            <table>
             <tr><td style="text-align:right;"></td><td style="text-align:right;"></td><td style="text-align:right;"></td><td style="text-align:right;"></td><td style="text-align:right;"></td><td style="text-align:right;"></td><td style="text-align:right;"></td><td style="text-align:right;"></td><td style="text-align:right;"></td><td style="text-align:right;"></td>
                 <td style="text-align:right;"></td><td style="text-align:right;"></td><td style="text-align:right;"></td><td style="text-align:right;"></td><td style="text-align:right;"></td><td style="text-align:right;"></td><td style="text-align:right;"></td><td style="text-align:right;"></td>
                 <td style="text-align:right;"></td><td style="text-align:right;"></td><td style="text-align:right;"></td><td style="text-align:right;"></td>
                 <td style="text-align:right;"></td><td style="text-align:right;"></td><td style="text-align:right;"></td><td style="text-align:right;"></td>
                 <td style="text-align:right;"></td><td style="text-align:right;"></td><td style="text-align:right;"></td><td style="text-align:right;"></td>
                 <td style="text-align:right;"></td><td style="text-align:right;"></td><td style="text-align:right;"></td><td style="text-align:right;"></td>

                <td style="text-align:right;"></td><td style="text-align:right;"></td><td style="text-align:right;"></td><td style="text-align:right;"></td> <td></td><td style="text-align:right;"><asp:Button ID="BtnUpdate" runat="server"  Text="Update" Width="128px" OnClick="BtnUpdate_Click" /> </td>
                
                 </tr>
                
               
                
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
                 </asp:View>


              <asp:View ID="View2" runat="server">
              <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                <tr>
                  <td>
                    <h3>
                        <span>                    

              
            
                   

             
                
          
         <table>
             <tr>
                     <td style="text-align:right;">
                         <asp:Label ID="Label108" runat="server" CssClass="lbl" Font-Size="Small" Font-Bold="true"  Text=" Procurement (Local & Foreign: "></asp:Label>
                     </td></tr>
     <%--//**********************************************Vehicle Registration TAB***********************************************************--%>
              <tr>
                 <td style="text-align:right;"><asp:Label ID="Label55" CssClass="lbl" runat="server" Text="Asset Code : "></asp:Label></td>
                <td><asp:TextBox ID="TxtVehicleCode" runat="server" AutoPostBack="true" CssClass="txtBox" OnTextChanged="TxtVehicleCode_TextChanged" ></asp:TextBox></td>
              
             </tr>

                     
           
             <tr>
                 <td style="text-align: right;">
                     <asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Unit : "></asp:Label></td>
                 <td>
                     <asp:DropDownList ID="ddlUnits" runat="server" CssClass="dropdownList" AutoPostBack="True" OnSelectedIndexChanged="ddlUnits_SelectedIndexChanged"></asp:DropDownList>
                 <td style="text-align: right;">
                     <asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Job Station : "></asp:Label></td>
                 <td>
                     <asp:DropDownList ID="Ddljob" runat="server" AutoPostBack="true" CssClass="dropdownList" OnSelectedIndexChanged="Ddljob_SelectedIndexChanged"></asp:DropDownList>

                 <td style="text-align: right;">
                     <asp:Label ID="Label4" CssClass="lbl" runat="server" Text="Asset Type : "></asp:Label></td>
                 <td>
                     <asp:DropDownList ID="DdlAsetTypes" runat="server" CssClass="dropdownList"></asp:DropDownList>
             </tr>
             <tr>

                 <td style="text-align: right;">
                     <asp:Label ID="Label5" CssClass="lbl" runat="server" Text="Vehicle Type : "></asp:Label></td>
                 <td>
                     <asp:DropDownList ID="DdlAssetCate" runat="server" CssClass="dropdownList"></asp:DropDownList>

                 <td style="text-align: right;">
                     <asp:Label ID="Label7" CssClass="lbl" runat="server" Text="End Number : "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtVechilReg" runat="server" CssClass="txtBox"  ></asp:TextBox></td>
                     
            
                 <td style="text-align: right;">
                     <asp:Label ID="Label8" CssClass="lbl" runat="server" Text="Description of Vehicle : "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtDscVechile" runat="server" CssClass="txtBox"></asp:TextBox></td>
                 </tr>
                 <tr>
                 <td style="text-align: right;">
                     <asp:Label ID="Label9" CssClass="lbl" runat="server" Text="Name of Manufacturer : "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtManuFactrurer" runat="server" CssClass="txtBox"></asp:TextBox></td>
                 <td style="text-align: right;">
                     <asp:Label ID="Label10" CssClass="lbl" runat="server" Text="Country of Origin : "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtOrigin" runat="server" CssClass="txtBox"></asp:TextBox></td>

        <td style="text-align: right;">
                     <asp:Label ID="Label11" CssClass="lbl" runat="server" Text="Country of Manufacturing : "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtCountryManu" runat="server" CssClass="txtBox"></asp:TextBox></td>

             </tr>
             <tr>

                 

                 <td style="text-align: right;">
                     <asp:Label ID="Label12" CssClass="lbl" runat="server" Text="Supplier / Local Agent Name : "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtSupplier" runat="server" CssClass="txtBox"></asp:TextBox></td>
                
                  <td style="text-align: right;">
                     <asp:Label ID="Label22" CssClass="lbl" runat="server" Text="HSCode : "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtHSCodes" runat="server" CssClass="txtBox"></asp:TextBox></td>

                 <td style="text-align: right;">
                     <asp:Label ID="Label13" CssClass="lbl" runat="server" Text="LC Number : "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtLcNumbers" runat="server" CssClass="txtBox"  ></asp:TextBox></td>

             </tr>
             <tr>

                 <td style="text-align: right;">
                     <asp:Label ID="Label14" CssClass="lbl" runat="server" Text="LC Date : "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtDteVLcDate" runat="server" CssClass="txtBox" autocomplete="off" ></asp:TextBox>
                     <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDteVLcDate">
                     </cc1:CalendarExtender>
                 </td>

                 <td style="text-align: right;">
                     <asp:Label ID="Label15" CssClass="lbl" runat="server" Text="Po Number : "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtPonumber" runat="server" CssClass="txtBox"  ></asp:TextBox></td>
                 <td style="text-align: right;">
                     <asp:Label ID="Label16" CssClass="lbl" runat="server" Text="Po Date : "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtVPoDate" runat="server" CssClass="txtBox" autocomplete="off" ></asp:TextBox>
                     <cc1:CalendarExtender ID="CalendarExtender6" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtVPoDate">
                     </cc1:CalendarExtender>
             </tr>

             <tr>

                 <td style="text-align: right;">
                     <asp:Label ID="Label17" CssClass="lbl" runat="server" Text="Warranty Expiry Date : "></asp:Label></td>

                 <td>
                     <asp:TextBox ID="TxtDteVWarranty" runat="server" CssClass="txtBox" autocomplete="off"></asp:TextBox>
                     <cc1:CalendarExtender ID="CalendarExtender7" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDteVWarranty">
                     </cc1:CalendarExtender>


                     <td style="text-align: right;">
                         <asp:Label ID="Label18" CssClass="lbl" runat="server" Text="Invoice Value : "></asp:Label></td>
                 <td>
                     <asp:TextBox ID="TxtInvoices" runat="server" CssClass="txtBox"></asp:TextBox></td>

                 <td style="text-align: right;">
                     <asp:Label ID="Label19" CssClass="lbl" runat="server" Text="Currency : "></asp:Label></td>
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
                     <asp:Label ID="Label20" CssClass="lbl" runat="server" Text="Incoterms : "></asp:Label></td>
                 <td>
                     <asp:DropDownList ID="DdlIncotermsd" runat="server" CssClass="dropdownList">
                         <asp:ListItem>CFR (Ctg)</asp:ListItem>
                         <asp:ListItem>CPT (Dhaka)</asp:ListItem>
                         <asp:ListItem>FOB</asp:ListItem>
                         <asp:ListItem>Ex Factory</asp:ListItem>
                         <asp:ListItem>Ex Showroom</asp:ListItem>
                     </asp:DropDownList>

                 <td style="text-align: right;">
                     <asp:Label ID="Label21" runat="server" CssClass="lbl" Text="Date Of Acusition: "></asp:Label>
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
                  <td style="text-align:right;">
                      <asp:Label ID="Label106" runat="server" CssClass="lbl" Font-Size="Small" Font-Bold="true"  Text="Operation Of Factory: "></asp:Label>
                  </td>
                 <tr>
                     <td style="text-align: right;">
                         <asp:Label ID="Label23" runat="server" CssClass="lbl" Text="Brand Name: "></asp:Label>
                     </td>

                     <td>
                         <asp:DropDownList ID="DdlBrand" runat="server" CssClass="dropdownList">
                            
                         </asp:DropDownList>
                     </td>
                     <td style="text-align: right;">
                         <asp:Label ID="Label24" runat="server" CssClass="lbl" Text="Model Name: "></asp:Label>
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
                         <asp:Label ID="Label25" runat="server" CssClass="lbl" Text="CC: "></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="TxtCC" runat="server" CssClass="txtBox"  ></asp:TextBox>
                     </td>


                     <td style="text-align: right;">
                         <asp:Label ID="Label26" runat="server" CssClass="lbl" Text="Color: "></asp:Label>
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
                             
                         </asp:DropDownList>
                     </td>
                     <td style="text-align: right;">
                         <asp:Label ID="Label28" runat="server" CssClass="lbl" Text="Engine No : "></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="TxtEngine" runat="server" CssClass="txtBox"  ></asp:TextBox>

                         
                     
                 </tr>

                 <tr>

                     <td style="text-align: right;">
                             <asp:Label ID="Label29" runat="server" CssClass="lbl" Text="Chassis No: "></asp:Label>
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
                             <asp:Label ID="Label30" runat="server" CssClass="lbl" Text="Recommand Life : "></asp:Label>
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


                    <%-- <td style="text-align: right;">
                         <asp:Label ID="Label31" CssClass="lbl" runat="server" Text="Department : "></asp:Label></td>
                     <td>
                         <asp:DropDownList ID="DdlDepartments" runat="server" CssClass="dropdownList"></asp:DropDownList>--%>

                     <td style="text-align: right;">
                         <asp:Label ID="Label40" runat="server" CssClass="lbl" Text="User Enroll: "></asp:Label></td>

                     <td>
                          
                         <asp:TextBox ID="txtUser" runat="server" CssClass="txtBox"></asp:TextBox></td>   

                   
                     
                 </tr>
                <tr>
                 

                         <td style="text-align: right;">
                             <asp:Label ID="Label32" runat="server" CssClass="lbl" Text="Estimation Salvage Value : "></asp:Label>
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
                      <asp:Label ID="Label33" runat="server" CssClass="lbl" Text="Landed Cost: "></asp:Label>
                  </td>
                     <td>
                         <asp:TextBox ID="TxtLandedCosts" runat="server" CssClass="txtBox"></asp:TextBox>
                     </td>
                     <td style="text-align: right;">
                         <asp:Label ID="Label34" runat="server" CssClass="lbl" Text="Total Accumulated Cost: "></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="Txttotalcost" runat="server" CssClass="txtBox"></asp:TextBox>
                     </td>
                     <td style="text-align: right;">
                         <asp:Label ID="Label35" runat="server" CssClass="lbl" Text="Rate of Depreciation: "></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="TxtRateDepriciation" runat="server" CssClass="txtBox"></asp:TextBox>
                     </td>
                     <tr>
                         <td style="text-align: right;">
                             <asp:Label ID="Label36" runat="server" CssClass="lbl" Text="Accumulated Depreciation: "></asp:Label>
                         </td>
                         <td>
                             <asp:TextBox ID="TxtTotalAccumatleted" runat="server" CssClass="txtBox"></asp:TextBox>
                         </td>
                         <td style="text-align: right;">
                             <asp:Label ID="Label37" runat="server" CssClass="lbl" Text="Method of Depreciation: "></asp:Label>
                         </td>
                         <td>
                             <asp:TextBox ID="TxtMethode" runat="server" CssClass="txtBox"></asp:TextBox>
                         </td>
                         <td style="text-align: right;">
                             <asp:Label ID="Label110" runat="server" CssClass="lbl" Text="Value after Depreciation: "></asp:Label>
                         </td>
                         <td>
                             <asp:TextBox ID="TxtValueAfterDep" runat="server" CssClass="txtBox"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td style="text-align: right;">
                             <asp:Label ID="Label148" runat="server" CssClass="lbl" Text="Written DownValue : "></asp:Label>
                         </td>
                         <td>
                             <asp:TextBox ID="TxtWritenDownValue" runat="server" CssClass="txtBox"></asp:TextBox>
                         </td>
                         <td style="text-align: right;">
                             <asp:Label ID="Label149" runat="server" CssClass="lbl" Text="Remarks : "></asp:Label>
                         </td>
                         <td>
                             <asp:TextBox ID="TxtRemarksd" runat="server" CssClass="txtBox"></asp:TextBox>
                         </td>
                     </tr>
               
                            
               <tr>
                <td></td><td></td><td></td><td></td><td style="text-align:right;"><asp:Button ID="BtnVSave" runat="server" Text="Update" autopostback="True" Width="128px" OnClick="BtnVechileSave_Click"  /> </td>
                
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

       
         
         
      
         <table>
             <tr>
                 <td style="text-align:right;"><asp:Label ID="Label105" CssClass="lbl" runat="server" Text="Asset Code : "></asp:Label></td>
                <td><asp:TextBox ID="TxtALandCode" runat="server" CssClass="txtBox" autopostback="true" OnTextChanged="TxtALandCode_TextChanged" ></asp:TextBox></td>
              
             </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label51" CssClass="lbl" runat="server" Text="Unit : "></asp:Label></td>
                <td><asp:DropDownList ID="DdlUnitLand" runat="server"  CssClass="dropdownList" OnSelectedIndexChanged="DdlUnitLand_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                <td style="text-align:right;"><asp:Label ID="Label52" CssClass="lbl" runat="server" Text="Job Station : "></asp:Label></td>
                <td><asp:DropDownList ID="DdlJobland" runat="server" AutoPostBack="true" CssClass="dropdownList" OnSelectedIndexChanged="DlJobStation_SelectedIndexChanged"></asp:DropDownList>
                
                <td style="text-align:right;"><asp:Label ID="Label53" CssClass="lbl" runat="server" Text="Asset Type : "></asp:Label></td>
                <td><asp:DropDownList ID="DdlAssetLand" runat="server" autoPostback="true"  CssClass="dropdownList"></asp:DropDownList> 
               
                </tr>

                <tr>
               
                <td style="text-align:right;"><asp:Label ID="Label54" CssClass="lbl" runat="server" Text="Name of Asset : "></asp:Label></td>
                <td><asp:TextBox ID="TxtAssetLand" runat="server" CssClass="txtBox"  ></asp:TextBox></td>
               
               <%--  <td style="text-align:right;"><asp:Label ID="Label55" CssClass="lbl" runat="server" Text="Asset Category : "></asp:Label></td>
                <td><asp:DropDownList ID="DdlCategoryLand" runat="server"  autopostback="true" CssClass="dropdownList"></asp:DropDownList> 
                --%>
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
                <td><asp:DropDownList ID="Ddldistrict" runat="server" Font-Size="Medium" CssClass="dropdownList" AutoPostBack="true" OnSelectedIndexChanged="Ddldistrict_SelectedIndexChanged"></asp:DropDownList> 
                <td style="text-align:right;"><asp:Label ID="Label62" CssClass="lbl" runat="server" Text="Thana : "></asp:Label></td>
                <td><asp:DropDownList ID="DDlThana" runat="server" Font-Size="Medium"   CssClass="dropdownList"></asp:DropDownList> 
                
                    <td style="text-align:right;"><asp:Label ID="Label63" CssClass="lbl" runat="server" Text=" Mouza: "></asp:Label></td>
                 <td><asp:TextBox ID="TxtMouza" runat="server" CssClass="txtBox"  ></asp:TextBox>
                     
                </tr>
               <tr>
                  
                         
                <td style="text-align:right;"><asp:Label ID="Label64" CssClass="lbl" runat="server" Text="CS Katian No : "></asp:Label></td>
                <td><asp:TextBox ID="TxtCSKatian" runat="server" CssClass="txtBox"  ></asp:TextBox></td>
                 <td style="text-align:right;"><asp:Label ID="Label65" CssClass="lbl" runat="server" Text="SA Katian No: "></asp:Label></td>
                  <td><asp:TextBox ID="TxtSaKatian" runat="server" CssClass="txtBox"  ></asp:TextBox>
               
                       <td style="text-align:right;"><asp:Label ID="Label66" CssClass="lbl" runat="server" Text="RS Khatian: "></asp:Label></td>
                
              <td><asp:TextBox ID="TxtRSKathin" runat="server" CssClass="txtBox"  ></asp:TextBox>
                
                   
                </tr>
                 
                 <tr>
               
                   
              <td style="text-align:right;"><asp:Label ID="Label67" CssClass="lbl" runat="server" Text="DS Khatian : "></asp:Label></td>
                <td><asp:TextBox ID="TxtDSKathian" runat="server" CssClass="txtBox"  ></asp:TextBox></td>

               <td style="text-align:right;"><asp:Label ID="Label68" CssClass="lbl" runat="server" Text="DP Khatian: "></asp:Label></td>
                  <td><asp:TextBox ID="TxtDpKatian" runat="server" CssClass="txtBox"  ></asp:TextBox></td>
               <td style="text-align:right;"><asp:Label ID="Label69" CssClass="lbl" runat="server" Text="CS Dag No : "></asp:Label></td>
                  <td><asp:TextBox ID="TxtCSDagNo" runat="server" CssClass="txtBox"  ></asp:TextBox></td>

                 
         
                    </tr>
             <tr>
               
           <td style="text-align:right;"> <asp:Label ID="Label70" runat="server" CssClass="lbl" Text="SA Dag No : "></asp:Label>
                         </td>
                     <td><asp:TextBox ID="TxtSADagNo" runat="server" CssClass="txtBox"  ></asp:TextBox>
                              
                         
                          
                     <td style="text-align:right;"><asp:Label ID="Label71" runat="server" CssClass="lbl" Text="RS Dag No : "></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="TxtRSDagNo" runat="server" CssClass="txtBox"></asp:TextBox>
                 </td>
                 
                <td style="text-align:right;"><asp:Label ID="Label72" runat="server" CssClass="lbl" Text="DS Dag No  : "></asp:Label>
                 </td>
                 
                 <td>
                     <asp:TextBox ID="TxtDSDagNo" runat="server" CssClass="txtBox"></asp:TextBox>
                 </td>
             </tr>
          
             <tr>
            
                
                 <td style="text-align:right;">
                     <asp:Label ID="Label73" runat="server" CssClass="lbl" Text="DP Dag No : "></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="TxtDPDagNo" runat="server" CssClass="txtBox"></asp:TextBox>
                 </td>

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
                         <asp:TextBox ID="TxtDeedNo" runat="server" CssClass="txtBox"  ></asp:TextBox>
                         </tr>
                 <tr>
                    
                         
                         <td style="text-align:right;">
                             <asp:Label ID="Label76" runat="server" CssClass="lbl" Text="Deed Date: "></asp:Label>
                         </td>
                         <td>
                             <asp:TextBox ID="DteDeedDate" runat="server" CssClass="txtBox" autocomplete="off" ></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender15" runat="server" Format="yyyy-MM-dd" TargetControlID="DteDeedDate">
                    </cc1:CalendarExtender> 
              

                             <td style="text-align:right;"><asp:Label ID="Label77" CssClass="lbl" runat="server" Text="Deed Certify receive date: "></asp:Label></td>
               <td><asp:TextBox ID="dteDeedCertifyreceivedate" runat="server" CssClass="txtBox" autocomplete="off" ></asp:TextBox>
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
                                 <asp:TextBox ID="TxtTotalArealandinDecimal" runat="server" CssClass="txtBox"></asp:TextBox>
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
                             <td style="text-align:right;">
                                 <asp:Label ID="Label87" runat="server" CssClass="lbl" Text="Deed Value Land : "></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TxtDeedValueLand" runat="server" CssClass="txtBox"></asp:TextBox>
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
                           <td style="text-align:right;"><asp:Button ID="BtnLand" runat="server" Text="Save" Width="128px" OnClick="BtnLand_Click" /> </td>
                
                       </tr>     
             </table>
              

            <table>
            
               
                
                 <tr>
                    
                     <td>
                         <asp:PlaceHolder ID="PlaceHolder3" runat="server" />
                     </td>
                 </tr>
                
               
                
             </table>

               </span>
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

        <tr>
                 <td style="text-align:right;"><asp:Label ID="Label109" CssClass="lbl" runat="server" Text="Asset Code : "></asp:Label></td>
                <td><asp:TextBox ID="TxtALandBuildCode" runat="server" CssClass="txtBox" autopostback="true"  OnTextChanged="TxtALandBuildCode_TextChanged" ></asp:TextBox></td>
              
             </tr>
                    
             <tr>
                 <td style="text-align: right;">
                     <asp:Label ID="Label111" CssClass="lbl" runat="server" Text="Unit : "></asp:Label></td>
                 <td>
                     <asp:DropDownList ID="DdlBuildUnit" runat="server" CssClass="dropdownList" AutoPostBack="True" OnSelectedIndexChanged="DdlBuildUnit_SelectedIndexChanged1" ></asp:DropDownList>
                 <td style="text-align: right;">
                     <asp:Label ID="Label112" CssClass="lbl" runat="server" Text="Job Station : "></asp:Label></td>
                 <td>
                     <asp:DropDownList ID="DdlbuildJobstation" runat="server" AutoPostBack="true" CssClass="dropdownList"></asp:DropDownList>

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
                         <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="TotalAccumulatedCost: "></asp:Label>
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

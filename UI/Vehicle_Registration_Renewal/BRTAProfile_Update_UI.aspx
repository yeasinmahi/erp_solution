<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BRTAProfile_Update_UI.aspx.cs" Inherits="UI.Vehicle_Registration_Renewal.BRTAProfile_Update_UI" %>


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
         <table>
             <tr>
                <td style="text-align:right;"><asp:Label ID="LblAssetCode" CssClass="lbl" runat="server" Text="Iteam : "></asp:Label></td>
                <td><asp:DropDownList ID="DdlItem" runat="server"  CssClass="dropdownList"  autopostback="true" OnSelectedIndexChanged="DdlItem_SelectedIndexChanged"></asp:DropDownList> </tr> 
                       
                <tr><td style="text-align:right;"> <asp:Label ID="LblHSCode" runat="server" CssClass="lbl" Text="Registration Fee "></asp:Label></td>                 
                 
                <td> <asp:TextBox ID="TxtRegistrationFee" runat="server" CssClass="txtBox"></asp:TextBox> </td>                
                
                <td style="text-align:right;"><asp:Label ID="LblManufacturer" runat="server" CssClass="lbl" Text="Name Plate : "></asp:Label></td>
                 
                <td> <asp:TextBox ID="TxtNamePlate" runat="server" CssClass="txtBox"></asp:TextBox></td>
                <td style="text-align:right;"> <asp:Label ID="LblContryOrigin" runat="server" CssClass="lbl" Text="OwnerShipChange "></asp:Label> </td>               
                 
                <td> <asp:TextBox ID="TxtOwnerShipchange" runat="server" CssClass="txtBox"></asp:TextBox>  </td></tr>
                  
                <tr><td style="text-align:right;"><asp:Label ID="LblCountryManufacture" runat="server" CssClass="lbl" Text="Address Change: "></asp:Label>                
                 
                <td> <asp:TextBox ID="TxtAddressChange" runat="server" CssClass="txtBox"></asp:TextBox></td>                 
                
                <td style="text-align:right;"><asp:Label ID="LblSuppName" runat="server" CssClass="lbl" Text="Certified Copy: "></asp:Label> </td>                
                 
                <td> <asp:TextBox ID="TxtCertificateCopy" runat="server" CssClass="txtBox"></asp:TextBox> </td>                
                 
                <td style="text-align:right;"><asp:Label ID="LblLCNo" runat="server" CssClass="lbl" Text="Duplicated Certificate"></asp:Label></td>
                <td>  <asp:TextBox ID="TxtDuplicatedCertificate" runat="server" CssClass="txtBox"></asp:TextBox></td> </tr>               
            
                <tr><td style="text-align:right;"><asp:Label ID="LblDteLC" runat="server" CssClass="lbl" Text="Registration Misc. Fee "></asp:Label></td>                 
                 
                <td> <asp:TextBox ID="TxtRegistrationMisc" runat="server" CssClass="txtBox"></asp:TextBox></td>
                     
                <td style="text-align:right;"><asp:Label ID="LblPONo" runat="server" CssClass="lbl" Text="TAX Token fee with VAT "></asp:Label> </td>
                  
                <td>  <asp:TextBox ID="TxtTaxTokenFee" runat="server" CssClass="txtBox"></asp:TextBox> </td>
                <td style="text-align:right;"><asp:Label ID="LblDtePO" runat="server" CssClass="lbl" Text="TAX Token late fine In 3 Month (10%)"></asp:Label></td>                     
                    
                <td><asp:TextBox ID="TxtTaxTokenLateFine3_1" runat="server" CssClass="txtBox"></asp:TextBox> </td></tr>
                
                <tr><td style="text-align:right;"> <asp:Label ID="LblWarrintyPreoid" runat="server" CssClass="lbl" Text="TAX Token late fine In 6 Month (20%)"></asp:Label></td>
                 
                <td>  <asp:TextBox ID="TxtTaxTokenLateFine6_2" runat="server" CssClass="txtBox"></asp:TextBox></td>
                    
                <td style="text-align:right;"><asp:Label ID="LblInvoice" runat="server" CssClass="lbl" Text="TAX Token late fine In 6 Month Above (30%) : "></asp:Label> </td>
                    
                <td><asp:TextBox ID="TxtTaxTokenLate6_30" runat="server" CssClass="txtBox"></asp:TextBox></td> </tr>
                <tr><td style="text-align:right;"><asp:Label ID="LblInsLocation" runat="server" CssClass="lbl" Text="Fitness Fee "></asp:Label></td>
                <td> <asp:TextBox ID="TxtFitnessFee" runat="server" CssClass="txtBox"></asp:TextBox></td>
                     
                <td style="text-align:right;"> <asp:Label ID="LblManuProvideSl" runat="server" CssClass="lbl" Text="Fitness Late Fee: "></asp:Label></td>
                    
                <td><asp:TextBox ID="TxtFitnessLate" runat="server" CssClass="txtBox"></asp:TextBox> </td>
                    
                <td style="text-align:right;"><asp:Label ID="LblFunction" runat="server" CssClass="lbl" Text="Fitness Miscellaneous: "></asp:Label></td>
                     
                <td> <asp:TextBox ID="TxtFitenessMisc" runat="server" CssClass="txtBox"></asp:TextBox></td> </tr>
                     
                <tr> <td style="text-align:right;"><asp:Label ID="LblCapacity" runat="server" CssClass="lbl" Text="AIT Fee "></asp:Label> </td>
                <td> <asp:TextBox ID="TxtAIT" runat="server" CssClass="txtBox"></asp:TextBox></td>
                    
                <td style="text-align:right;"> <asp:Label ID="LblDteInstalation" runat="server" CssClass="lbl" Text="Insurance Fee: "></asp:Label></td>
                    
                <td> <asp:TextBox ID="TxtInsuranceFee" runat="server" CssClass="txtBox"></asp:TextBox></td>
                        
                <td style="text-align:right;"><asp:Label ID="LblErectionCost" runat="server" CssClass="lbl" Text="Route permit Fee "></asp:Label></td>
                         
                <td><asp:TextBox ID="TxtRoutePermit" runat="server" CssClass="txtBox"></asp:TextBox> </td>  </tr>
                          
                <tr>  <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Routepermit Late Fine: "></asp:Label> </td>
                        
                <td> <asp:TextBox ID="TxtRoutepermitLateFine" runat="server" CssClass="txtBox"></asp:TextBox> </td>      
                                      
                <td style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Routepermit Misc: "></asp:Label></td>
                         
                <td> <asp:TextBox ID="TxtRoutePermitMisc" runat="server" CssClass="txtBox"></asp:TextBox> </td>
                        
                <td style="text-align:right;"><asp:Label ID="LblDepartment" runat="server" CssClass="lbl" Text="Body VAT "></asp:Label>   </td>
                     
                <td>   <asp:TextBox ID="TxtBodyVat" runat="server" CssClass="txtBox"></asp:TextBox></td>  </tr>
                <tr> <td style="text-align:right;"> <asp:Label ID="Label153" runat="server" CssClass="lbl" Text="DRC: "></asp:Label> </td>
                <td><asp:TextBox ID="TxtDRC" runat="server" CssClass="txtBox"></asp:TextBox> </td> </tr>
                <tr><td style="text-align:right;"></td>  <td style="text-align:right;"></td><td style="text-align:right;"></td>
                <td style="text-align:right;"></td>  <td style="text-align:right;"></td>  <td style="text-align:right;">
                <asp:Button ID="BtnUpdatae" runat="server" Text="Update" OnClick="BtnUpdatae_Click" /></td> </tr>
                    
                </table>

         
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>


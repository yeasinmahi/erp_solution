<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VehicleInfoUpdate_UI.aspx.cs" Inherits="UI.Asset.VehicleInfoUpdate_UI" %>

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
       

  
    <script>
        function Save() {
            document.getElementById("hdnField").value = "1";
            __doPostBack();
        }

</script>
   
    

    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .ddList {}
        .auto-style1 {
            height: 24px;
        }
        .auto-style2 {
            height: 139px;
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
    <asp:HiddenField ID="hdnEnrollUnit" runat="server" /><asp:HiddenField ID="hdnUnitIDByddl" runat="server" /><asp:HiddenField ID="hdnBankID" runat="server" />
    <asp:HiddenField ID="hfEmployeeIdp" runat="server" /><asp:HiddenField ID="hdnstation" runat="server" />       
          <asp:HiddenField ID="HdnServiceCost" runat="server" />   <asp:HiddenField ID="hdnRepairsCost" runat="server" />   
            
    <div class="tabs_container" align="Center" >Vehicle Information Update</div>
   
       <table style="width:650px; outline-color:blue;table-layout:auto;vertical-align: top; "class="tblrowodd" >
             
      
             <tr>
                    <td style="text-align:right;"><asp:Label ID="LblHSCode" CssClass="lbl" runat="server" Text="AssetID : "></asp:Label></td>
                <td><asp:TextBox ID="TxtAssetID" runat="server" CssClass="txtBox" AutoPostBack="true" OnTextChanged="TxtAssetID_TextChanged"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="TxtAssetID"
                                     ServiceMethod="GetWearHouseRequesision" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
    <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" /></td>
                
                

               <td style="text-align:right;"><asp:Label ID="LblManufacturer" CssClass="lbl" runat="server" Text="Name of Asset : "></asp:Label></td>
                <td><asp:TextBox ID="TxtxtName" runat="server" CssClass="txtBox"></asp:TextBox></td>
                 
                </tr>
                 <tr>

                     <td style="text-align:right;"><asp:Label ID="LblContryOrigin" CssClass="lbl" runat="server" Text="Billing Unit : "></asp:Label></td>
               <td><asp:DropDownList ID="DdlBillUnit" runat="server"  CssClass="dropdownList" AutoPostBack="True" OnSelectedIndexChanged="DdlBillUnit_SelectedIndexChanged"></asp:DropDownList> </td>
             
<td style="text-align:right;"><asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Billing Jobstation : "></asp:Label></td>
               <td><asp:DropDownList ID="DdlJobstation" runat="server"  CssClass="dropdownList" AutoPostBack="True"></asp:DropDownList> </td>
              
                                    
                </tr>
           <tr>
               <td style="text-align:right;"><asp:Label ID="LblCountryManufacture" CssClass="lbl" runat="server" Text="Driver Name : "></asp:Label></td>
                <td><asp:TextBox ID="TxtDriverName" runat="server" CssClass="txtBox"></asp:TextBox></td>
  
                 <td style="text-align:right;"><asp:Label ID="LblSuppName" CssClass="lbl" runat="server" Text="Driver Mobaile No : "></asp:Label></td>
                <td><asp:TextBox ID="TxtxtDriverMobaile" runat="server" CssClass="txtBox"></asp:TextBox></td>
        
           </tr>
           <tr>
               <td style="text-align:right;"><asp:Label ID="LblLCNo" CssClass="lbl" runat="server" Text="User Enroll : "></asp:Label></td>
                <td><asp:TextBox ID="TxtEnroll" runat="server" CssClass="txtBox"></asp:TextBox></td>
              
               <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="User Name: "></asp:Label></td>
                <td><asp:TextBox ID="TxtUserName" runat="server" CssClass="txtBox"></asp:TextBox></td>

              
               
           </tr>
           <tr>
                <td style="text-align:right;"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Location: "></asp:Label></td>
                <td><asp:TextBox ID="TxtLocation" runat="server" CssClass="txtBox"></asp:TextBox></td>

               <td></td><td> <asp:Button ID="BtnUpdate" runat="server" Text="Update" OnClick="BtnUpdate_Click" /> </td>
           </tr>
         </table>
        
         
            
<%--=========================================End My Code From Here=================================================--%>
      
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

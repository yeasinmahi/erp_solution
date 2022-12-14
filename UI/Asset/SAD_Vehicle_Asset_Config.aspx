<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SAD_Vehicle_Asset_Config.aspx.cs" Inherits="UI.Asset.SAD_Vehicle_Asset_Config" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

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
       
    <script src="jquery-1.8.3.min.js"></script>
    
    
   <script type="text/javascript">

        function funConfirmAll() {
             var asset = document.getElementById("txtAssetId").value;
             
            if ($.trim(asset).length < 3 ||$.trim(asset) == 0 || $.trim(asset) == "" || $.trim(asset) == null || $.trim(asset) == undefined) { document.getElementById("hdnConfirm").value = "0"; alert('Please input Asset ID'); }
             
            else {
                 var confirm_value = document.createElement("INPUT"); 
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";

                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnConfirm").value = "1"; }

                else { confirm_value.value = "No"; document.getElementById("hdnConfirm").value = "0"; }

            } 
        }

</script> 
     <script>
         function Registration(url) {
             newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=900,top=50,left=230, close=no');
             if (window.focus) { newwindow.focus() }
         }
          
         function Registrationparts(url) {
             newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=1000,top=50,left=200, close=no');
             if (window.focus) { newwindow.focus() }
         }
             function RegistrationSchedule(url) {
                 newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=900,top=50,left=230, close=no');
                 if (window.focus) { newwindow.focus() }
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
    <asp:HiddenField ID="hdnEnrollUnit" runat="server" /><asp:HiddenField ID="hdnConfirm" runat="server" /><asp:HiddenField ID="hdnBankID" runat="server" />
    <asp:HiddenField ID="hfEmployeeIdp" runat="server" /><asp:HiddenField ID="hdnstation" runat="server" />       
    <asp:HiddenField ID="HdnServiceCost" runat="server" />   <asp:HiddenField ID="hdnRepairsCost" runat="server" />   
            
    <div class="tabs_container" align="left" >SAD Vehicle Asset Configuration </div>
   
       <table style="width:500px; outline-color:blue;table-layout:auto;vertical-align: top; "class="tblrowodd" >
        <tr>
        <td style="text-align:right;"><asp:Label ID="LblContryOrigin" CssClass="lbl" runat="server" Text="Type : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlType" runat="server"  CssClass="ddList" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
            
            <asp:ListItem Value="1">Staff Vehicle</asp:ListItem>
            <asp:ListItem Value="2">Internal Vehicle</asp:ListItem>
            </asp:DropDownList> </td>

        </tr>
           
           <tr>                  
            <td style="text-align:right;" > <asp:Label ID="LblAsset" runat="server" CssClass="lbl" font-size="small" Text="Vehicle Number : "></asp:Label></td>
            <td style="text-align:left;"> <asp:TextBox ID="txtVehicle" runat="server" CssClass="txtBox" Font-Bold="False" AutoPostBack="true"    ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtVehicle"
            ServiceMethod="GetVehilcle" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender>
             </td>
                 
            </tr>
             <tr>                  
            <td style="text-align:right;" > <asp:Label ID="Label1" runat="server" CssClass="lbl" font-size="small" Text="Asset Number : "></asp:Label></td>
            <td style="text-align:left;"> <asp:TextBox ID="txtAssetId" runat="server" CssClass="txtBox" Font-Bold="False" AutoPostBack="true"></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtAssetId"
            ServiceMethod="GetAssetSearch" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender>
           </td>
                 
            </tr>
           <tr>
               
               <td style="text-align:right"><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"   /></td>
           </tr>
           </Table>
         
        
        
        
         
            
<%--=========================================End My Code From Here=================================================--%>
      
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

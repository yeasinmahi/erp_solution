<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetCheckInOut.aspx.cs" Inherits="UI.Asset.AssetCheckInOut" %>

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
   

    <script type="text/javascript">
        function OpenHdnInUseDiv() {
             $("#hdnInUse").fadeIn("slow");
             document.getElementById('hdnInUse').style.visibility = 'visible';
         }

        function CloseHdnInUseDiv() {

            $("#hdnInUse").fadeOut("slow");
         }

         function OpenHdnInStoreDiv() {
             $("#hdnInStore").fadeIn("slow");
             document.getElementById('hdnInStore').style.visibility = 'visible';
         }

         function CloseHdnInStoreDiv() {

             $("#hdnInStore").fadeOut("slow");
         }

         function OpenHdnExpireDiv() {
             $("#hdnExpire").fadeIn("slow");
             document.getElementById('hdnExpire').style.visibility = 'visible';
         }

         function CloseHdnExpireDiv() {

             $("#hdnExpire").fadeOut("slow");
         }

    </script>
    
   
   

    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .ddList {}
        .txtBox {}
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
        .hdnInUse { background-color: #EFEFEF; position:absolute;z-index:1; visibility:hidden; border:10px double black; text-align:center;
        width:100%; height: 100%;    margin-left:40px;  margin-top:20px; margin-right:00px; padding: 15px; overflow-y:scroll; }
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
        .hdnInStore { background-color: #EFEFEF; position:absolute;z-index:1; visibility:hidden; border:10px double black; text-align:center;
        width:100%; height:100%;    margin-left:40px;  margin-top:30px; margin-right:00px; padding: 15px; overflow-y:scroll; }
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
        .hdnExpire { background-color: #EFEFEF; position:absolute;z-index:1; visibility:hidden; border:10px double black; text-align:center;
        width:100%; height:100%;    margin-left:40px;  margin-top:30px; margin-right:00px; padding: 15px; overflow-y:scroll; }
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
    <div class="tabs_container" align="Center" >Asset Status </div>
   
       <table style="width:700px; outline-color:blue;table-layout:auto;vertical-align: top; background-color: #996633;"class="tblrowodd" >
         <tr  class="tblrowodd"> 
            <td colspan="2" style="text-align: center"><asp:RadioButton ID="radBarcode" AutoPostBack="true"  Checked="true" GroupName="radio" Text="Barcode" runat="server"  OnCheckedChanged="radBarcode_CheckedChanged" /><asp:RadioButton ID="radSearch" AutoPostBack="true"  GroupName="radio" Text="Search" runat="server" OnCheckedChanged="radSearch_CheckedChanged" /></td>
        </tr>
           
        <tr  class="tblrowodd">
       <td style="text-align:right;" > <asp:Label ID="LblAsset" runat="server" CssClass="lbl" font-size="small" Text="Asset Number:"></asp:Label></td>
          
        <td style="text-align:left;"> <asp:TextBox ID="TxtAsset" CssClass="txtBox" runat="server"  AutoPostBack="true" OnTextChanged="TxtAsset_TextChanged" ></asp:TextBox>
        <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="TxtAsset"
        ServiceMethod="GetAssetAutoSearch" MinimumPrefixLength="1" CompletionSetCount="1"
        CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
        </cc1:AutoCompleteExtender></td>   
                      
           <td style="text-align:right;"> <asp:Label ID="LblUnit" runat="server" CssClass="lbl" font-size="small" Text="Unit:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TxtUnit" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
       
                    </tr>
               <tr>
                     <td style="text-align:right;"> <asp:Label ID="LblName" font-size="small" runat="server" CssClass="lbl" Text="Name of Asset:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TxtName" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
         <td style="text-align:right;"> <asp:Label ID="LblStation" runat="server" font-size="small" CssClass="lbl" Text="JobStation:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TxtStation" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
       
           
             
             <tr class="tblrowodd">
                 <td style="text-align: right;">
                     <asp:Label ID="LblPriority"  runat="server" font-size="small"  CssClass="lbl" Text="Service Status:"></asp:Label></td>
                 <td style="text-align: left;">
                     <asp:DropDownList ID="DdlServiceType" runat="server" CssClass="ddList" Font-Bold="True" AutoPostBack="True" OnSelectedIndexChanged="DdlServiceType_SelectedIndexChanged">
                     <asp:ListItem Selected="True">Select</asp:ListItem> <asp:ListItem>InUse</asp:ListItem><asp:ListItem>InStore</asp:ListItem><asp:ListItem>Expire</asp:ListItem>
                       <asp:ListItem>Repair</asp:ListItem> 
                     </asp:DropDownList>

                       <td style="text-align:right;"> <asp:Label ID="Label5" runat="server" font-size="small" CssClass="lbl" Text="Narration:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TxtNarration" runat="server" CssClass="txtBox"  Font-Bold="True" Height="45px" Width="230px" TextMode="MultiLine"></asp:TextBox>
       
           
             </tr>
            
                  

         </table>
          
        
               <%--class="hdnInUse"--%>
          <div id="hdnInUse"  class="hdnInUse" style="width:auto;  height:100px;">
              <table style="width:auto;  float:left; " >  

              <tr><td colspan="2" style="text-align:right; font:bold 14px verdana;"><a class="button" onclick="CloseHdnInUseDiv()" title="Close" style="cursor:pointer;text-align:right; color:red; font:bold 10px verdana;">X</a></td></tr>
      
                <tr>                  
               <td style="text-align:right;">  <asp:Label ID="Label9" runat="server" CssClass="lbl" font-size="small" Text="Responsible Person:"></asp:Label></td>
               <td style="text-align:left;"> <asp:TextBox ID="txtResponsibleInUse" CssClass="txtBox" runat="server" Font-Bold="False" Width="582px"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtResponsibleInUse"
         ServiceMethod="GetEmployeeAutoSearch" MinimumPrefixLength="1" CompletionSetCount="1"
        CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
       CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
        </cc1:AutoCompleteExtender></td>    
                <tr>                           
                 <td style="text-align:right;">  <asp:Label ID="Label10" runat="server" CssClass="lbl" font-size="small" Text="Narration:"></asp:Label></td>
                 <td style="text-align:left;"> <asp:TextBox ID="txtInuseNaration" runat="server" CssClass="txtBox" Font-Bold="False" Height="31px" TextMode="MultiLine" Width="385px"></asp:TextBox></td>
                   
                </tr>

                   <tr>                       
                     <td style="text-align:right;" colspan="2"> <asp:Button ID="btnInUseAction" runat="server" Text="Submit" OnClick="btnInUseAction_Click"  /></td>
                   </tr>
                 
          </table>
         </div>
         <%--class="hdnInStore"--%> 
        <div id="hdnInStore" class="hdnInStore"  style="width:auto;  height:100px;">
              <table style="width:auto;  float:left; " >  
               <tr><td colspan="4" style="text-align:right; font:bold 14px verdana;"><a class="button" onclick="CloseHdnInStoreDiv()" title="Close" style="cursor:pointer;text-align:right; color:red; font:bold 10px verdana;">X</a></td></tr>
      
                <tr>
              <td style="text-align:right;">  <asp:Label ID="Label8" runat="server" CssClass="lbl" font-size="small" Text="Ware House:"></asp:Label></td>
               <td style="text-align: left;"><asp:DropDownList ID="ddlWHidSt" runat="server" CssClass="ddList" Font-Bold="False" AutoPostBack="True" OnSelectedIndexChanged="ddlWHidSt_SelectedIndexChanged"></asp:DropDownList>
                                     
               <td style="text-align:right;">  <asp:Label ID="Label6" runat="server" CssClass="lbl" font-size="small" Text="Responsible Person:"></asp:Label></td>
               <td style="text-align: left;"><asp:DropDownList ID="ddlResponsiblePersonSt" runat="server" CssClass="ddList" Font-Bold="False" AutoPostBack="false"></asp:DropDownList>
                 <tr>                           
                 <td style="text-align:right;">  <asp:Label ID="Label7" runat="server" CssClass="lbl" font-size="small" Text="Narration:"></asp:Label></td>
                 <td style="text-align:left;" colspan="3"> <asp:TextBox ID="txtInStoreNaration"  CssClass="txtBox" runat="server" Font-Bold="True" Height="31px" TextMode="MultiLine" Width="385px"></asp:TextBox></td>
                </tr>
                 <tr>                       
                     <td style="text-align:right;" colspan="4"> <asp:Button ID="btnInStore" runat="server" Text="Submit" OnClick="btnInStore_Click"   /></td>
                  </tr>
          </table>
            </div>
         <%--class="hdnExpire"--%>
    <div id="hdnExpire"   class="hdnExpire" style="width:auto;  height:200px;">
       <table style="width:auto;  float:left; " >  
       <tr><td colspan="4" style="text-align:right; font:bold 14px verdana;"><a class="button" onclick="CloseHdnExpireDiv()" title="Close" style="cursor:pointer;text-align:right; color:red; font:bold 10px verdana;">X</a></td></tr>
      
                <tr>
              <td style="text-align:right;">  <asp:Label ID="Label11" runat="server" CssClass="lbl" font-size="small" Text="Ware House:"></asp:Label></td>
               <td style="text-align: left;"><asp:DropDownList ID="ddlWareHouse" runat="server" CssClass="ddList" Font-Bold="False" AutoPostBack="True" OnSelectedIndexChanged="ddlWareHouse_SelectedIndexChanged"></asp:DropDownList>
                                     
               <td style="text-align:right;">  <asp:Label ID="Label12" runat="server" CssClass="lbl" font-size="small" Text="Responsible Person:"></asp:Label></td>
               <td style="text-align: left;"><asp:DropDownList ID="ddlResposiblePersonEx" runat="server" CssClass="ddList" Font-Bold="False" AutoPostBack="false"></asp:DropDownList>
               </tr>
                   
               <tr> 
              <td style="text-align:right;">  <asp:Label ID="Label14" runat="server" CssClass="lbl" font-size="small" Text="Expire Date:"></asp:Label></td>            
                 <td><asp:TextBox ID="txtDteExpire" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDteExpire">
                </cc1:CalendarExtender></td>                            
                 <td style="text-align:right;">  <asp:Label ID="Label13" runat="server" CssClass="lbl" font-size="small" Text="Narration:"></asp:Label></td>
                 <td style="text-align:left;"> <asp:TextBox ID="txtExpireNaration" runat="server" CssClass="txtBox" Font-Bold="True" Height="31px" TextMode="MultiLine" Width="385px"></asp:TextBox></td>
                  </tr>
                  <tr>                       
                     <td style="text-align:right;" colspan="4"> <asp:Button ID="btnExpire" runat="server" Text="Submit" OnClick="btnExpire_Click"   /></td>
                  </tr>                 
          </table>
         </div>
         <table>
             <tr>
                 <td>
                     <asp:GridView ID="dgvservice" runat="server" AutoGenerateColumns="False">
                         <Columns>
                             <asp:BoundField HeaderText="Asset Code" DataField="strAssetCode" SortExpression="strAssetCode" />
                             <asp:BoundField DataField="strNameOfAsset" HeaderText="Asset Name" SortExpression="strNameOfAsset" />
                             <asp:BoundField HeaderText="Employee Name" DataField="strEmployeeName" SortExpression="strEmployeeName" />
                             <asp:BoundField DataField="strJobStationName" HeaderText="Jobstation" SortExpression="strJobStationName" />
                             <asp:BoundField DataField="strDesignation" HeaderText="Designation" SortExpression="strDesignation" />
                             <asp:BoundField DataField="dtedate" HeaderText="Date" SortExpression="dtedate" />
                             <asp:BoundField DataField="strServiceType" HeaderText="Status" SortExpression="strServiceType" />
                             <asp:BoundField DataField="strNarration" HeaderText="Narration" SortExpression="strNarration" />
                         </Columns>
                     </asp:GridView>
                 </td>
             </tr>
         </table>
        
         
            
<%--=========================================End My Code From Here=================================================--%>
      
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>


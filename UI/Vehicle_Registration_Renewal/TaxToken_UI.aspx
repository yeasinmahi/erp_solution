<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaxToken_UI.aspx.cs" Inherits="UI.Vehicle_Registration_Renewal.TaxToken_UI" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
     <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference4" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />

    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>

  
    


    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>

    <script> function CloseWindow() { window.close(); window.onbeforeunload = RefreshParent(); }
        function RefreshParent() {
            if (window.opener != null && !window.opener.closed) {
                window.opener.location.reload();
            }
        }

    </script> 
    
    <style type="text/css">
        #divFile p { 
            font:15px tahoma, arial; 
        }
        #divFile h3 { 
            font:16px arial, tahoma; 
            font-weight:bold;
        }
        .auto-style1 {
            height: 25px;
        }
    </style>

    

          
</head>
<body>
    <form id="frmselfresign" runat="server">
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <%--<asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>--%>
<div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />        
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnDieselTotalTk" runat="server" /><asp:HiddenField ID="hdnCNGTotalTk" runat="server" />
    <asp:HiddenField ID="hdnMillage" runat="server" /><asp:HiddenField ID="hdnHightMilage" runat="server" />
      
        
        <div class="tabs_container">Tax Token Renewal<hr /></div>

        <table  class="tbldecoration" style="width:auto; float:left;">
        <tr>
           <td style="text-align:right;"><asp:Label ID="lblVehicleT" runat="server" CssClass="lbl" Text="Vehicle Name :"></asp:Label></td>                  
            <td><asp:TextBox ID="txtVehicleName" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true"   ></asp:TextBox>
             <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtVehicleName"
                                     ServiceMethod="GetWearHouseRequesision" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                 <asp:HiddenField ID="hdfVehicleCode" runat="server" /></td>  
            <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Owner Name"></asp:Label></td>
          
           <td style="text-align:left;"><asp:TextBox ID="TxtUnit" runat="server" CssClass="txtBox"  BorderColor="Green" Width="190px"></asp:TextBox></td>                                                                                                              

             
                </tr>
            <tr>
                  
                        
             
            <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Vehicle Type :"></asp:Label></td>                  
            <td style="text-align:left;"><asp:TextBox ID="TxtVehicleType" runat="server" CssClass="txtBox"  BorderColor="Green" Width="190px"></asp:TextBox></td>                                                                                                              
        <td style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="TaxToken:"></asp:Label></td>                  
            <td style="text-align:left;"><asp:TextBox ID="TxtToken" runat="server" CssClass="txtBox"  BorderColor="green" Width="190px"></asp:TextBox></td>                                                                                                              


                    </tr>
            <tr>
               
             <td style="text-align:right;"><asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Late Fine:"></asp:Label></td>                  
            <td style="text-align:left;"><asp:TextBox ID="TxtLateFine" runat="server" CssClass="txtBox"  BorderColor="green" Width="190px"></asp:TextBox></td>                                                                                                              
         
                  <td style="text-align:right;"><asp:Label ID="Label12" runat="server" CssClass="lbl" Text="Miscellcuneces" ></asp:Label></td>                  
            <td style="text-align:left;"><asp:TextBox ID="TxtMiscellcuneces" runat="server" ReadOnly="true" CssClass="txtBox"  BorderColor="Green" Width="190px"></asp:TextBox></td>                                                                                                              
        
                
                
                
             

                       </tr>
            <tr> 
                          <td style="text-align:right;"><asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Exp.Date:"></asp:Label></td>                  
            <td style="text-align:left;"><asp:TextBox ID="TxtDteExpDate" runat="server" CssClass="txtBox"  BorderColor="green" Width="190px"></asp:TextBox>                                                                                                           
 <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDteExpDate">
                         </cc1:CalendarExtender>

                           <td style="text-align:right;" class="auto-style1"><asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Renewal Date:"></asp:Label></td>                  
            <td style="text-align:left;" class="auto-style1"><asp:TextBox ID="TxtDteRenewal" runat="server" CssClass="txtBox"  BorderColor="green" Width="190px"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDteRenewal">
                         </cc1:CalendarExtender>  
                
              
                                                                                                               
                    </tr>
            <tr>
                      

                <td style="text-align:right;" class="auto-style1"><asp:Label ID="Label6" runat="server" CssClass="lbl" Text="Next ExpDate :"></asp:Label></td>                  
            <td style="text-align:left;" class="auto-style1"><asp:TextBox ID="TxtNextExpDte" runat="server" CssClass="txtBox" BorderColor="green" Width="190px"></asp:TextBox>                                                                                                              
  <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtNextExpDte">
                         </cc1:CalendarExtender>    


                 <td> <asp:Label ID="lblnowusedunit" runat="server" Text="Used by   :"></asp:Label>
                 <asp:Label ID="lbprsntus" runat="server" BackColor="#ffff66"></asp:Label> 
                      </td>
       <td>
                <asp:Button ID="BtnTaxToken" runat="server" Text="Save" OnClick="BtnTaxToken_Click"  /></td>
 
                
                 </tr>
          


       
                                  
       
       </table>
        </div>



<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Insurance_UI.aspx.cs" Inherits="UI.Vehicle_Registration_Renewal.Insurance_UI" %>

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
<%--=========================================Start My Code From Here===============================================--%>
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />        
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnDieselTotalTk" runat="server" /><asp:HiddenField ID="hdnCNGTotalTk" runat="server" />
    <asp:HiddenField ID="hdnMillage" runat="server" /><asp:HiddenField ID="hdnHightMilage" runat="server" />
      
        
        <div class="tabs_container">Insurance<hr /></div>

        <table  class="tbldecoration" style="width:auto; float:left;">
        <tr> 
            <td style="text-align:right;"><asp:Label ID="lblVehicleT" runat="server" CssClass="lbl" Text="Vehicle Name :"></asp:Label></td>                  
            <td style="text-align:left;"><asp:TextBox ID="txtVehicleName" runat="server" CssClass="txtBox"  BorderColor="green" Width="190px"  ReadOnly="true"></asp:TextBox>
                 <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtVehicleName"
                                     ServiceMethod="GetVehicleAutosearch" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                 <asp:HiddenField ID="hdfVehicleCode" runat="server" /></td>    
            <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Owner Name"></asp:Label></td>
              <td style="text-align:left;"><asp:TextBox ID="TxtUnit" runat="server" CssClass="txtBox"  BorderColor="green" Width="190px"  ReadOnly="true"></asp:TextBox>
             </td>
            
                 </tr>
            <tr>
                                                                                                                           
      
            <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Vehicle Type :"></asp:Label></td>                  
            <td style="text-align:left;"><asp:TextBox ID="TxtVehicleType" runat="server" CssClass="txtBox"   ReadOnly="true" BorderColor="Green" Width="190px"></asp:TextBox></td>                                                                                                              
       
   <td style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Insurance"></asp:Label></td>                  
            <td style="text-align:left;"><asp:TextBox ID="TxtInsurence" runat="server" CssClass="txtBox"   ReadOnly="true" BorderColor="green" Width="190px"></asp:TextBox></td>                                                                                                              

                   </tr>
              <tr>
              <td style="text-align:right;"><asp:Label ID="Label8" runat="server" CssClass="lbl" Text="Insurance Company:"></asp:Label></td>                  
            <td style="text-align:left;"><asp:TextBox ID="TxtInsuranceCompany" runat="server" CssClass="txtBox"  BorderColor="green" Width="190px"></asp:TextBox></td>                                                                                                              
    
             <td style="text-align:right;"><asp:Label ID="Label7" runat="server" CssClass="lbl" Text="Renewal Date:"></asp:Label></td>                  
            <td style="text-align:left;"><asp:TextBox ID="TextRenwalDte" runat="server" CssClass="txtBox"  BorderColor="green" Width="190px"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="TextRenwalDte">
                         </cc1:CalendarExtender>                                                                                                          
      
                         </tr>
            <tr>
               
                <td style="text-align:right;"><asp:Label ID="Label9" runat="server" CssClass="lbl" Text="CertificateCopyNo."></asp:Label></td>                  
            <td style="text-align:left;"><asp:TextBox ID="TxCertificateCopyNot" runat="server" CssClass="txtBox" BorderColor="green" Width="190px"></asp:TextBox></td>                                                                                                              
   
 <td> <asp:Label ID="lblnowusedunit" runat="server" Text="Used by   :"></asp:Label>
                 <asp:Label ID="lbprsntus" runat="server" BackColor="#ffff66"></asp:Label> 
                      </td><td>
                <asp:Button ID="BtnInsurance" runat="server" Text="Save" OnClick="BtnInsurance_Click" /></td>
            </tr>
            


       
                                  
       
       </table>
        </div>



<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
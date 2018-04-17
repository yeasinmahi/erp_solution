<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration_UI.aspx.cs" Inherits="UI.Vehicle_Registration_Renewal.Registration_UI" %>

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
      
        
        <div class="tabs_container">Registration <hr /></div>

        <table  class="tbldecoration" style="width:auto; float:left;">
        <tr> 
           <td style="text-align:right;"><asp:Label ID="lblVehicleT" runat="server" CssClass="lbl" Text="Vehicle Name :"></asp:Label></td>                  
            <td style="text-align:left;"><asp:TextBox ID="txtVehicleName" runat="server" CssClass="txtBox" BorderColor="Green"  ReadOnly="true" Width="190px" ></asp:TextBox>
                 <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtVehicleName"
                                     ServiceMethod="GetVehicleAutosearch" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                 <asp:HiddenField ID="hdfVehicleCode" runat="server" /></td>      
            <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Owner Name"></asp:Label></td>
      <td style="text-align:left;"><asp:TextBox ID="TxtUnit" runat="server" CssClass="txtBox" BorderColor="Green" Width="190px" ReadOnly="true"></asp:TextBox></td>
                                                                                                       
          
        
                  </tr>
            <tr>
                                                                                                                         
     
            <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Vehicle Type :"></asp:Label></td>                  
            <td style="text-align:left;">                                                                                                           
       <asp:DropDownList ID="ddlVechileType" CssClass="ddList" Font-Bold="False" runat="server" Width="195px" AutoPostBack="true"  ></asp:DropDownList></td>
          
                
      <td style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Registration Date :"></asp:Label></td>                  
            <td style="text-align:left;"><asp:TextBox ID="txtDteRegistration" runat="server" CssClass="txtBox"  BorderColor="Green" Width="190px"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDteRegistration">
                         </cc1:CalendarExtender> 
                                                                                                               
       </tr>
            <tr>

          
                
               <td style="text-align:right;"><asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Registration:"></asp:Label></td>                  
            <td style="text-align:left;"><asp:TextBox ID="txtRegistration" runat="server" CssClass="txtBox" ReadOnly="true" BorderColor="Green" Width="190px"></asp:TextBox></td>                                                                                                              
              <td style="text-align:right;"><asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Name Plate:"></asp:Label></td>                  
            <td style="text-align:left;"><asp:TextBox ID="TxtNamePlate" runat="server" CssClass="txtBox"  ReadOnly="true" BorderColor="Green" Width="190px"></asp:TextBox></td>                                                                                                              

            </tr>
            <tr> 

    
           
             <td style="text-align:right;" class="auto-style1"><asp:Label ID="Label5" runat="server" CssClass="lbl" Text="DRC :"></asp:Label></td>                  
            <td style="text-align:left;" class="auto-style1"><asp:TextBox ID="TxtDrc" ReadOnly="true" runat="server" CssClass="txtBox"  BorderColor="Green" Width="190px"></asp:TextBox></td>                                                                                                              
         <td style="text-align:right;" class="auto-style1"><asp:Label ID="Label6" runat="server" CssClass="lbl" Text="Owner Ship :"></asp:Label></td>                  
            <td style="text-align:left;" class="auto-style1"><asp:TextBox ID="TxtOwnerShip" ReadOnly="true" runat="server" CssClass="txtBox" BorderColor="Green" Width="190px"></asp:TextBox></td>                                                                                                              
   
                        </tr>
            <tr>
<td style="text-align:right;"><asp:Label ID="Label8" runat="server" CssClass="lbl" Text="Address Change:"></asp:Label></td>                  
            <td style="text-align:left;"><asp:TextBox ID="TxtAddress" runat="server"  ReadOnly="true" CssClass="txtBox" BorderColor="Green" Width="190px"></asp:TextBox></td>                                                                                                              

    
             <td style="text-align:right;"><asp:Label ID="Label7" runat="server" CssClass="lbl" Text="Body Vat :"></asp:Label></td>                  
            <td style="text-align:left;"><asp:TextBox ID="TxtBodyVat" runat="server" ReadOnly="true" CssClass="txtBox"  BorderColor="Green" Width="190px"></asp:TextBox></td>                                                                                                              
       
                   </tr>
            <tr>

         
             <td style="text-align:right;"><asp:Label ID="Label9" runat="server" CssClass="lbl" Text="Certificate :"></asp:Label></td>                  
            <td style="text-align:left;"><asp:TextBox ID="TxtCertificate" runat="server" ReadOnly="true" CssClass="txtBox"  BorderColor="Green" Width="190px"></asp:TextBox></td>                                                                                                              
        <td style="text-align:right;"><asp:Label ID="Label11" runat="server" CssClass="lbl" Text="Duplicate Copy :"></asp:Label></td>                  
            <td style="text-align:left;"><asp:TextBox ID="TxtDuplicateCopy" runat="server" ReadOnly="true" CssClass="txtBox"  BorderColor="Green" Width="190px"></asp:TextBox></td>                                                                                                              

                    </tr>
            <tr>
                    <td style="text-align:right;"><asp:Label ID="Label12" runat="server" CssClass="lbl" Text="Miscellcuneces" ></asp:Label></td>                  
            <td style="text-align:left;"><asp:TextBox ID="TxtMiscellcuneces" runat="server" ReadOnly="true" CssClass="txtBox"  BorderColor="Green" Width="190px"></asp:TextBox></td>                                                                                                              
        <td></td><td>
                <asp:Button ID="BtnRegistration" runat="server" Text="Save" OnClick="BtnRegistration_Click" /></td>

            </tr>
       


       
                                  
       
       </table>
        </div>



<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
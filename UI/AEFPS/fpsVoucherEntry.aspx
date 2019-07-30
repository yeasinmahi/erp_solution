<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fpsVoucherEntry.aspx.cs" Inherits="UI.AEFPS.fpsVoucherEntry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
   <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
   
  <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
<script src="../Content/JS/datepickr.min.js"></script>


</head>
<body>
    <form id="frmVoucherentry" runat="server">
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
       <asp:HiddenField ID="hdnSalary" runat="server" /><asp:HiddenField ID="hdnMillage" runat="server" /><asp:HiddenField ID="hdnSaleAmount" runat="server" />
       <asp:HiddenField ID="hdnDTFare" runat="server" /><asp:HiddenField ID="hdnSingleMillage100KM" runat="server" /><asp:HiddenField ID="hdnSingleMillage100AboveKM" runat="server" />
       <asp:HiddenField ID="hdnSalesQty" runat="server" /><asp:HiddenField ID="hdnconfirm" runat="server" />
       <asp:HiddenField ID="hdnDieselTotalTk" runat="server" /><asp:HiddenField ID="hdnCNGTotalTk" runat="server" />
       <asp:HiddenField ID="hdnDTFCount" runat="server" /> <asp:HiddenField ID="hdnDTFCountCash" runat="server" /> 
       <asp:HiddenField ID="hdnstockQty" runat="server" /> <asp:HiddenField ID="hdnQty" runat="server" />
        <asp:HiddenField ID="hdnDieselPerKMOutStation" runat="server" /><asp:HiddenField ID="hdnCNGPerKMOutStation" runat="server" />
       <div style="background-color:cadetblue;font-size:18px"  class="tabs_container">Voucher Entry Form<hr /></div>

        <table  class="tbldecoration" style="width:auto; float:left;">

        <tr><td colspan="4">Expense Entry</td></tr> 
       
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblInDate" runat="server" CssClass="lbl" Text="Wear House :"></asp:Label></td>                
            <td><asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" runat="server" Width="195px"></asp:DropDownList>
            </td>                                

            <td style="text-align:right;"><asp:Label ID="lblQty" runat="server" CssClass="lbl" Text="Date :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtfdate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="190px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="txtfdate"></cc1:CalendarExtender></td>              
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Narration :"></asp:Label></td>                
            <td><asp:TextBox ID="txtNarration" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="190px"></asp:TextBox></td>                                

            <td style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Purpose :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtPurpose" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="190px"></asp:TextBox>
           </td>              
        </tr>
       <tr>
            <td style="text-align:right;"><asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Amount :"></asp:Label></td>                
            <td colspan="3"><asp:TextBox ID="txtAmount" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="190px"></asp:TextBox></td>                                

                </td>              
        </tr>
                   
        <tr><td colspan="4"><hr /></td></tr>             
          <tr><td colspan="4" style="font-weight:bold; font-size:16px; color:#000000;">&nbsp;</td></tr>
           
          <tr>
            <td style="text-align:right;" colspan="4">
           <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </td>
            </tr>  
            </tr> 
            
        </table>

             <table  class="tbldecoration" style="width:auto; float:left;">

        <tr><td colspan="4">Employee Credit Receive Entry</td></tr> 
       
        <tr>
            <td style="text-align:right;"><asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Wear House :"></asp:Label></td>                
            <td><asp:DropDownList ID="ddlWHEntryE" CssClass="ddList" Font-Bold="False" runat="server" Width="195px"></asp:DropDownList>
            </td>                                

            <td style="text-align:right;"><asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Date :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtfdatee" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="190px" autocomplete="off"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtfdatee"></cc1:CalendarExtender></td>              
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="Label6" runat="server" CssClass="lbl" Text="Narration :"></asp:Label></td>                
            <td><asp:TextBox ID="txtNarrationE" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="190px"></asp:TextBox></td>                                

            <td style="text-align:right;">Credit Amount</td>
            <td style="text-align:left;">
                <asp:TextBox ID="txtCreditAmount" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="190px"></asp:TextBox>
            </td>              
        </tr>
       <tr>
           <td ><asp:Label ID="Label9" runat="server" CssClass="lbl" Text="Employee Name :"></asp:Label></td><td><asp:TextBox ID="txtEmployee" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" Width="180px" OnTextChanged="txtEmployee_TextChanged" ></asp:TextBox>
             <cc1:AutoCompleteExtender ID="empsearch" runat="server" TargetControlID="txtEmployee"
    ServiceMethod="EmployeeSearch" MinimumPrefixLength="1" CompletionSetCount="1"
    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
    </cc1:AutoCompleteExtender>
    <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" /></td>
              <td style="text-align:right;"><asp:Label ID="Label8" runat="server" CssClass="lbl" Text="Amount :"></asp:Label></td>                
            <td colspan="3"><asp:TextBox ID="txtAmountE" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="190px"></asp:TextBox></td> 
         
                     
        </tr>
                   
        <tr><td colspan="4"><hr /></td></tr>             
          <tr><td colspan="4" style="font-weight:bold; font-size:16px; color:#000000;">&nbsp;</td></tr>
           
          <tr>
            <td style="text-align:right;" colspan="4">
           <asp:Button ID="btnCVEntry" runat="server" Text="Save" OnClick="btnCVEntry_Click"  />
            </td>
            </tr>  
            </tr> 
            
        </table>
        </div>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

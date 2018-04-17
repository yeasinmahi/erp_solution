<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fpsSubLedger.aspx.cs" Inherits="UI.AEFPS.fpsSubLedger" %>
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

<script type="text/javascript">
    function FTPUpload() {
        document.getElementById("hdnconfirm").value = "2";
        __doPostBack();
    }
    function onlyNumbers(evt) {
        var e = event || evt; // for trans-browser compatibility
        var charCode = e.which || e.keyCode;

        if ((charCode > 57))
            return false;
        return true;
    }
    function FTPUpload1() {
        document.getElementById("hdnconfirm").value = "0";
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
        if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "3"; }
        else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
        __doPostBack();
    }
</script>

<script> function CloseWindow() {
     window.close();      
 } </script>

<script type="text/javascript">
    function RefreshParent() {
        if (window.opener != null && !window.opener.closed) {
            window.opener.location.reload();
        }
    }
    window.onbeforeunload = RefreshParent;
</script>    

</head>
<body>
    <form id="frmSubledger" runat="server">
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
       <div style="background-color:cadetblue;font-size:18px"  class="tabs_container"><b> EMPLOYEE LEDGER</b><hr /></div>

        <table  class="tbldecoration" style="width:auto; float:left;">

        <tr><td colspan="4">&nbsp;</td></tr> 
        <tr>
            <td style="text-align:right;">From Date</td>                
            <td><asp:TextBox ID="txtfdate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="190px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtfdate"></cc1:CalendarExtender></td>                                

            <td style="text-align:right;"><asp:Label ID="lblQty" runat="server" CssClass="lbl" Text="To Date :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txttdate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="190px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="txttdate"></cc1:CalendarExtender></td>              
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblemployeesearch" runat="server" CssClass="lbl" Text="Employee Search :"></asp:Label></td>                
            <td colspan="3"><asp:TextBox ID="txtEmployee" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" Width="500px" OnTextChanged="txtEmployee_TextChanged" ></asp:TextBox>
             <cc1:AutoCompleteExtender ID="empsearch" runat="server" TargetControlID="txtEmployee"
    ServiceMethod="EmployeeSearch" MinimumPrefixLength="1" CompletionSetCount="1"
    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
    </cc1:AutoCompleteExtender>
    <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" /></td> </tr>
        <tr><td colspan="4"><hr /></td></tr>             
        <tr><td colspan="4"><hr /></td></tr>             
        <tr><td colspan="4" style="font-weight:bold; background-color:cadetblue; font-size:18px; color:#000000;">Ledger Of :<asp:Label ID="lblsalesAmount" ForeColor="#ffffff" runat="server"></asp:Label><hr /></td></tr>
         <tr><td colspan="4" style="font-weight:bold; font-size:16px; color:#000000;">&nbsp;</td></tr>
           
          <tr>
            <td style="text-align:right;" colspan="4">
           <asp:Button ID="btnSave" runat="server" Text="Show" OnClick="btnSave_Click" />
           <asp:GridView ID="dgvRptTemp" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"   FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="GridView1_RowDataBound">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No" Visible="true"  ItemStyle-HorizontalAlign="left" SortExpression="strQRCode" >
            <ItemTemplate>         
            <asp:Label ID="lblSLNO" runat="server" Width="50px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("intid","{0:d}")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
   
            <asp:TemplateField HeaderText="Date" Visible="true"  ItemStyle-HorizontalAlign="left" SortExpression="strQRCode" >
            <ItemTemplate>         
            <asp:Label ID="lbldate" runat="server" Width="150px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("dtedate","{0:d}")) %>'></asp:Label></ItemTemplate></asp:TemplateField>


            <asp:TemplateField HeaderText=" Code" Visible="true" ItemStyle-HorizontalAlign="left" SortExpression="strQRCode" >
            <ItemTemplate><asp:Label ID="lblstrQRCode" runat="server" Width="150px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("code")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                             
            <asp:TemplateField HeaderText="Discribtion" SortExpression="intProductID">
            <ItemTemplate><asp:Label ID="lbldiscribtions" runat="server" Text='<%# Bind("discribtion") %>' Width="200px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="55px"/><FooterTemplate><asp:Label ID="lbldiscribtionID" runat="server" Text ="Total" /></FooterTemplate></asp:TemplateField>
              
            <asp:TemplateField HeaderText="Debit" Visible="true" ItemStyle-HorizontalAlign="center" SortExpression="mondebit" >
            <ItemTemplate><asp:Label ID="lblmondebitNames" runat="server" Width="70px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("mondebit")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Credit" ItemStyle-HorizontalAlign="right" SortExpression="MRRQty" >
            <ItemTemplate><asp:Label ID="lblmoncredit" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("moncredit"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/></asp:TemplateField>
           
             <asp:TemplateField HeaderText="Balance" ItemStyle-HorizontalAlign="right" SortExpression="MRRQty" >
            <ItemTemplate><asp:Label ID="lblBalance" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("balance"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/></asp:TemplateField>


           </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
            </td>
            </tr>  
            <tr><td colspan="4"></td></tr>
            <tr style="background-color:lightgray">
             <td colspan="4"> </td>
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

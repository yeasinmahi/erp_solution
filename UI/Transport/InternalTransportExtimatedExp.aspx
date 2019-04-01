<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InternalTransportExtimatedExp.aspx.cs" Inherits="UI.Transport.InternalTransportExtimatedExp" %>
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
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    <script src="../Content/JS/CustomizeScript.js"></script>
   
<script language="javascript" type="text/javascript">
    function onlyNumbers(evt) {
        var e = event || evt; // for trans-browser compatibility
        var charCode = e.which || e.keyCode;

        if ((charCode > 57))
            return false;
        return true;
    }           
    function Add() {
    var a, b, c, d, e, f, g, h, i, j;
    a = parseFloat(document.getElementById("txtFerryToll").value);     
    if (isNaN(a) == true) {
        a = 0;
    }
    var b = parseFloat(document.getElementById("txtBridgeToll").value);
    if (isNaN(b) == true) {
        b = 0;
    }
    var c = parseFloat(document.getElementById("txtLabourExp").value);
    if (isNaN(c) == true) {
        c = 0;
    }
    var d = parseFloat(document.getElementById("txtPolice").value);
    if (isNaN(d) == true) {
        d = 0;
    }
    //var e = parseFloat(document.getElementById("txtFuelCash").value);
    //if (isNaN(e) == true) {
    //    e = 0;
        //}
    e = 0;

    var f = parseFloat(document.getElementById("txtdgvFTTotal").value);      
    if (isNaN(f) == true) {
        f = 0;
    }              

    //var g = parseFloat(document.getElementById("txtFuelCash").value);
    //if (isNaN(g) == true) {
    //    g = 0;
        //}

    g = 0;

    var j = parseFloat(document.getElementById("txtMillage").value);
    if (isNaN(j) == true) {
        j = 0;
    }

        //***********************************************************************************
    if (unitid == 4) {
        if (j > 230) {
            var h = parseFloat(document.getElementById("hdnDieselPerKMOutStation").value);
            if (isNaN(h) == true) { h = 0; }
        }
        else {
            var h = parseFloat(document.getElementById("hdnDieselTotalTk").value);
            if (isNaN(h) == true) { h = 0; }
        }
    }
    else {
        var h = parseFloat(document.getElementById("hdnDieselTotalTk").value);
        if (isNaN(h) == true) { h = 0; }
    }

    var unitid = parseFloat(document.getElementById("hdnUnit").value);

    if (unitid == 4) {
        if (j > 230) {
            var i = parseFloat(document.getElementById("hdnCNGPerKMOutStation").value);
            if (isNaN(i) == true) { i = 0; }
        }
        else {
            var i = parseFloat(document.getElementById("hdnCNGTotalTk").value);
            if (isNaN(i) == true) { i = 0; }
        }
    }
    else {
        var i = parseFloat(document.getElementById("hdnCNGTotalTk").value);
        if (isNaN(i) == true) { i = 0; }
    }

   //***********************************************************************************


    ////////var h = parseFloat(document.getElementById("hdnDieselTotalTk").value);
    ////////if (isNaN(h) == true) {
    ////////    h = 0;
    ////////}
    ////////var i = parseFloat(document.getElementById("hdnCNGTotalTk").value);
    ////////if (isNaN(i) == true) {
    ////////    i = 0;
    ////////}
///**************************************************************
    ////var unitid = parseFloat(document.getElementById("hdnUnit").value);
    ////    ///if (isNaN(unitid) == true) { unitid = 0; }

    ////if (unitid == 4) {
    ////    if ((j + k) > 230)
    ////    { singlemillag = q; } else { singlemillag = n; }
    ////}
    ////else {
    ////    if ((j + k) > 100)
    ////    { singlemillag = q; } else { singlemillag = n; }
    ////}

    ////document.getElementById("txtMillageAllowance").value = ((j + k) * singlemillag).toFixed(0);


///*************************************************************


    document.getElementById("txtDieselTotalTk").value = (j * h).toFixed(0);
    document.getElementById("txtCNGTotalTk").value = (j * i).toFixed(0);
    
    document.getElementById("txtTotalRouteExp").value = (a + b + c + d + e + (j * h) + (j * i)).toFixed(0);
    //document.getElementById("txtTFCost").value = (f + g).toFixed(2);
        
    document.getElementById("txtTotalRouteExp").readOnly = true;
    //document.getElementById("txtTFCost").readOnly = true;
    //document.getElementById("txtFerryToll").readOnly = true;
    //document.getElementById("txtBridgeToll").readOnly = true;
    document.getElementById("txtMillage").readOnly = true;
    //document.getElementById("txtLedgerB").readOnly = true;
    document.getElementById("txtDieselTotalTk").readOnly = true;
    document.getElementById("txtCNGTotalTk").readOnly = true;
    //document.getElementById("txtQty").readOnly = true;
       
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

<%--<script> function CloseWindow() { window.close(); } </script>--%>
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
    <asp:TextBox ID="txtdgvFTTotal" runat="server" Width="0.1px" CssClass="txtBox"  Height="0.1px" MaxLength="10" BackColor="White" ForeColor="White" ></asp:TextBox>        
        <div class="leaveApplication_container"> 
        <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
        <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnDieselTotalTk" runat="server" /><asp:HiddenField ID="hdnCNGTotalTk" runat="server" />
        <asp:HiddenField ID="hdnDieselPerKMOutStation" runat="server" /><asp:HiddenField ID="hdnCNGPerKMOutStation" runat="server" />
        
        <div class="tabs_container"> VEHICLE TRIP OUT ESTIMATED EXPENSE<hr /></div>

        <table  class="tbldecoration" style="width:auto; float:left;">        
        
        <tr>
            <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="lblTrip" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Trip Sl No. :"></asp:Label></td>
            <td style="font-weight:bold; text-align:left; color:#0b6016;"><asp:Label ID="lblTripNo" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px"></asp:Label></td>

            <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="lblCustN" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Final Destination :"></asp:Label></td>
            <td colspan="3" style="font-weight:bold; text-align:left; color:#0b6016;"><asp:Label ID="lblCustName" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px"></asp:Label></td>            
        </tr>
        <tr>
            <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="lblVehicle" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Vehicle No. :"></asp:Label></td>
            <td style="font-weight:bold; text-align:left; color:#0b6016;"><asp:Label ID="lblVehicleNo" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px"></asp:Label></td>                        
            
            <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="lblVehicleT" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Vehicle Type :"></asp:Label></td>
            <td style="font-weight:bold; text-align:left; color:#0b6016;"><asp:Label ID="lblVehicleType" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px"></asp:Label></td>                    
        </tr>
        <tr><td colspan="6"><hr /></td></tr> 
                            
        <tr><td colspan="6" style="font-weight:bold; font-size:11px; color:#3369ff;">Fuel Cost:<hr /></td></tr>
        
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblFuelStation" runat="server" CssClass="lbl" Text="Fuel Station"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlFuelStation" CssClass="ddList" Font-Bold="False" runat="server" Width="195px"></asp:DropDownList>                                                                                       
            </td>
                        
            <td style="text-align:right;"><asp:Label ID="lblDieselTotalTk" runat="server" CssClass="lbl" Text="Diesel Total (Tk) :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtDieselTotalTk" runat="server" CssClass="txtBox" Width="70px" BackColor="LightGray" BorderColor="Gray" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>
            
            <td style="text-align:right;"><asp:Label ID="lblCNGTotalTk" runat="server" CssClass="lbl" Text="CNG Total (Tk) :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtCNGTotalTk" runat="server" CssClass="txtBox" Width="70px" BackColor="LightGray" BorderColor="Gray" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>                                      
      
            <%--<td style="text-align:right;"><asp:Label ID="lblFuelCash" runat="server" CssClass="lbl" Text="Fuel Cash :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtFuelCash" runat="server" CssClass="txtBox" Width="70px" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>--%>                                      

            <%--<td style="text-align:right;"><asp:Label ID="lblTFCost" runat="server" CssClass="lbl" Text="Total Fuel Cost :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtTFCost" runat="server" CssClass="txtBox" BackColor="LightGray" BorderColor="Gray" Width="160px" onkeypress="return onlyNumbers();" MaxLength="10"></asp:TextBox></td>--%>                                      
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblFuelPurchaeDate" runat="server" CssClass="lbl" Text="Fuel Purchae Date :"></asp:Label></td>                
            <td><asp:TextBox ID="txtFuelPurchaeDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="190px"></asp:TextBox>
            <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFuelPurchaeDate"></cc1:CalendarExtender></td>                                

            <td style="text-align:right;"><asp:Label ID="lblDieselCredit" runat="server" CssClass="lbl" Text="Diesel Credit :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtDieselCredit" runat="server" CssClass="txtBox" Width="70px" onkeypress="return onlyNumbers();"></asp:TextBox></td>              

            <td style="text-align:right;"><asp:Label ID="lblCNGCredit" runat="server" CssClass="lbl" Text="CNG Credit :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtCNGCredit" runat="server" CssClass="txtBox" Width="70px" onkeypress="return onlyNumbers();"></asp:TextBox></td>              

        </tr>
        <tr>
            <td colspan="6"><asp:Button ID="btnFuelCostAdd" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Add" OnClick="btnFuelCostAdd_Click"/></td>
        </tr>            
        <tr><td colspan="6"> 
            <asp:GridView ID="dgvFuelCost" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"  ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="dgvFuelCost_RowDataBound" OnRowDeleting="dgvFuelCost_RowDeleting">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
            
            <asp:TemplateField HeaderText="intPartyID" Visible="false" SortExpression="intPartyID"><ItemTemplate>            
            <asp:Label ID="lblPartyID" runat="server" Text='<%# Bind("intPartyID") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Fuel Purchase Date" SortExpression="strFuelPurchaseDate"><ItemTemplate>            
            <asp:Label ID="lblFuelPurchaseDate" runat="server" Text='<%# Bind("strFuelPurchaseDate") %>' Width="70px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="55px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="" /></FooterTemplate></asp:TemplateField>
               
            <asp:TemplateField HeaderText="Fuel Station Name" SortExpression="fuelstation"><ItemTemplate>            
            <asp:Label ID="lblfuelstation" runat="server" Text='<%# Bind("fuelstation") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="285px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="Total" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Diesel Credit" ItemStyle-HorizontalAlign="right" SortExpression="dieselcredit" >
            <ItemTemplate><asp:Label ID="lbldieselcredit" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("dieselcredit"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="80px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totaldieselcredit %>' /></FooterTemplate></asp:TemplateField>
                         
            <asp:TemplateField HeaderText="CNG Credit" ItemStyle-HorizontalAlign="right" SortExpression="cngcredit" >
            <ItemTemplate><asp:Label ID="lblcngcredit" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("cngcredit"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="80px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalcngcredit %>' /></FooterTemplate></asp:TemplateField>
                
            <asp:TemplateField HeaderText="Total Credit" ItemStyle-HorizontalAlign="right" SortExpression="totalcredit" >
            <ItemTemplate><asp:Label ID="lblGrandTotal" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("totalcredit"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="80px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# grandtotal %>' /></FooterTemplate></asp:TemplateField>
                             
            <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" /> 

            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
        </tr> 
        <tr><td colspan="6"><hr /></td></tr>             
        <tr><td colspan="6" style="font-weight:bold; font-size:11px; color:#3369ff;">Expence:<hr /></td></tr>
        
        <tr>            
            <td style="text-align:right;"><asp:Label ID="lblMillage" runat="server" CssClass="lbl" Text="Millage :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtMillage" runat="server" CssClass="txtBox" BackColor="LightGray" BorderColor="Gray" Width="190px" onkeypress="return onlyNumbers();"></asp:TextBox></td>                                                               
            
            <td style="text-align:right;"><asp:Label ID="lblBridgeToll" runat="server" CssClass="lbl" Text="Bridge Toll :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtBridgeToll" runat="server" CssClass="txtBox" BackColor="LightGray" BorderColor="Gray" Width="70px" ReadOnly="true" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>              

            <td style="text-align:right;"><asp:Label ID="lblFerryToll" runat="server" CssClass="lbl" Text="Ferry Toll:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtFerryToll" runat="server" CssClass="txtBox" BackColor="LightGray" BorderColor="Gray" Width="70px" ReadOnly="true" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>                                                               
        </tr> 
        <tr>

            <td style="text-align:right;"><asp:Label ID="lblLabourExp" runat="server" CssClass="lbl" Text="Labour Exp. :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtLabourExp" runat="server" CssClass="txtBox" Width="190px" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>                                                               

            <td style="text-align:right;"><asp:Label ID="lblPolice" runat="server" CssClass="lbl" Text="Police Tips :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtPolice" runat="server" CssClass="txtBox" Width="70px"  onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>              

            <td style="text-align:right;"><asp:Label ID="lblTotalRouteExp" runat="server" CssClass="lbl" Text="Total Route Exp.:"></asp:Label></td>
            <td style="text-align:left; color:grey;"><asp:TextBox ID="txtTotalRouteExp" runat="server" CssClass="txtBox"  BackColor="LightGray" BorderColor="Gray" Width="70px"></asp:TextBox></td>                                                                                       
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblDriver" runat="server" CssClass="lbl" Text="Driver Name :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlDriverName" CssClass="ddList" AutoPostBack="true" Font-Bold="False" runat="server" Width="195px" OnSelectedIndexChanged="ddlDriverName_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td>
            
            <td style="text-align:right;"><asp:Label ID="lblLedgerB" runat="server" CssClass="lbl" Text=""></asp:Label></td>
            <td style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text=""></asp:Label></td>
            <%--<td style="text-align:right;"><asp:Label ID="lblLedgerB" runat="server" CssClass="lbl" Text="Ledger Ballance:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtLedgerB" runat="server" CssClass="txtBox" BackColor="LightGray" BorderColor="Gray" Width="70px"></asp:TextBox></td>--%>                                                                                                              

            <td style="text-align:right;"><asp:Label ID="lblAdvance" runat="server" CssClass="lbl" Text="Advance:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtAdvance" runat="server" CssClass="txtBox" Width="70px" onkeypress="return onlyNumbers();"></asp:TextBox></td>                                                                                                              
        </tr>
        <tr>            
            <td colspan="6"><asp:Button ID="btnSubmit" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Submit" OnClientClick="ConfirmAll()" OnClick="btnSubmit_Click"/></td>
        </tr>
        
        <tr><td colspan="6" style="font-weight:bold; font-size:11px; color:#3369ff;">NEW DRIVER ADD FOR THIS APPLICATION<hr /></td></tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblDriverEnroll" runat="server" CssClass="lbl" Text="Driver Enroll :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtDriverEn" runat="server" CssClass="txtBox" Width="190px" onkeypress="return onlyNumbers();" MaxLength="10"></asp:TextBox></td>                                                               

            <td><asp:Button ID="btnAddDriver" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Add Driver" OnClientClick="ConfirmAll()" OnClick="btnAddDriver_Click"/></td>

            <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text=""></asp:Label></td>
            <td style="text-align:right;"><asp:Label ID="lblQty" runat="server" CssClass="lbl" Text="Quantity :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtQty" runat="server" CssClass="txtBox" BackColor="LightGray" BorderColor="Gray" Width="70px" onkeypress="return onlyNumbers();" MaxLength="10"></asp:TextBox></td>              
        </tr>
        <tr><td colspan="6"><hr /></td></tr>  

        </table>
    </div>
        
        <div>
            <table class="tbldecoration" style="width:auto; float:left;">
                <tr><td> <hr /></td></tr>
                <tr><td style="font-weight:bold; font-size:11px; color:#3369ff;">REPORT FOR UPDATE<hr /></td></tr>
                <tr>
                    <td><asp:GridView ID="dgvTripWiseCustomer" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" Font-Size="10px" ForeColor="Black" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                    <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px" /><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="reffid" SortExpression="reffid" Visible="false"><ItemTemplate>
                    <asp:Label ID="lblReffIDG" runat="server" Text='<%# Bind("reffid") %>'></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                          
                    <asp:TemplateField HeaderText="custid" SortExpression="intCustID" Visible="false"><ItemTemplate>
                    <asp:Label ID="lblCustIDG" runat="server" Text='<%# Bind("intCustID") %>'></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Customer Name" SortExpression="strName"><ItemTemplate>
                    <asp:Label ID="lblCustNameG" runat="server" Text='<%# Bind("strName") %>' Width="200px"></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="200px" /></asp:TemplateField>
                        
                    <asp:TemplateField HeaderText="Millage" SortExpression="intMillage"><ItemTemplate>
                    <asp:TextBox ID="txtMillageG" runat="server" CssClass="txtBox" Text='<%# Bind("intMillage") %>' TextMode="Number" Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Trip Fare" SortExpression="monTripFare"><ItemTemplate>
                    <asp:TextBox ID="txtTripFareG" runat="server" CssClass="txtBox" Text='<%# Bind("monTripFare") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Trip Fare Open Truck" SortExpression="monTripFareOpenTruck"><ItemTemplate>
                    <asp:TextBox ID="txtTFOpentruckG" runat="server" CssClass="txtBox" Text='<%# Bind("monTripFareOpenTruck") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Trip Fare Covered Van" SortExpression="monTripFareCoveredVan"><ItemTemplate>
                    <asp:TextBox ID="txtTFCoveredVanG" runat="server" CssClass="txtBox" Text='<%# Bind("monTripFareCoveredVan") %>'  Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Trip Fare Pickup" SortExpression="monTripFarePickup"><ItemTemplate>
                    <asp:TextBox ID="txtTFPickupG" runat="server" CssClass="txtBox" Text='<%# Bind("monTripFarePickup") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>

                    <asp:TemplateField HeaderText="Trip Fare 10 Ton" SortExpression="monTripFare10Tone"><ItemTemplate>
                    <asp:TextBox ID="txtTF10TonG" runat="server" CssClass="txtBox" Text='<%# Bind("monTripFare10Tone") %>'  Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Trip Fare 7 Ton" SortExpression="monTripFare7Tone"><ItemTemplate>
                    <asp:TextBox ID="txtTF7TonG" runat="server" CssClass="txtBox" Text='<%# Bind("monTripFare7Tone") %>'  Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Trip Fare 5 Ton" SortExpression="monTripFare5Tone"><ItemTemplate>
                    <asp:TextBox ID="txtTF5TonG" runat="server" CssClass="txtBox" Text='<%# Bind("monTripFare5Tone") %>'  Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Trip Fare 3 Ton" SortExpression="monTripFare3Tone"><ItemTemplate>
                    <asp:TextBox ID="txtTF3TonG" runat="server" CssClass="txtBox" Text='<%# Bind("monTripFare3Tone") %>'  Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Trip Fare 1.5 Ton" SortExpression="monTripFare1AndHalfTone"><ItemTemplate>
                    <asp:TextBox ID="txtTF1AndHalfTonG" runat="server" CssClass="txtBox" Text='<%# Bind("monTripFare1AndHalfTone") %>'  Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Bridge & Road Toll" SortExpression="monBridgeAndRoadToll"><ItemTemplate>
                    <asp:TextBox ID="txtBridgeTollG" runat="server" CssClass="txtBox" Text='<%# Bind("monBridgeAndRoadToll") %>'  Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>

                    <asp:TemplateField HeaderText="Bridge & Road Toll 20 Ton" SortExpression="monBridgeToll20Ton"><ItemTemplate>
                    <asp:TextBox ID="txtBnRToll20TonG" runat="server" CssClass="txtBox" Text='<%# Bind("monBridgeToll20Ton") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Bridge & Road Toll 10 Ton" SortExpression="monBridgeToll10Ton"><ItemTemplate>
                    <asp:TextBox ID="txtBnRToll10TonG" runat="server" CssClass="txtBox" Text='<%# Bind("monBridgeToll10Ton") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Bridge & Road Toll 7 Ton" SortExpression="monBridgeToll7Tone"><ItemTemplate>
                    <asp:TextBox ID="txtBnRToll7TonG" runat="server" CssClass="txtBox" Text='<%# Bind("monBridgeToll7Tone") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Bridge & Road Toll 5 Ton" SortExpression="monBridgeToll5Tone"><ItemTemplate>
                    <asp:TextBox ID="txtBnRToll5TonG" runat="server" CssClass="txtBox" Text='<%# Bind("monBridgeToll5Tone") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>

                    <asp:TemplateField HeaderText="Bridge & Road Toll 3 Ton" SortExpression="monBridgeToll3Tone"><ItemTemplate>
                    <asp:TextBox ID="txtBnRToll3TonG" runat="server" CssClass="txtBox" Text='<%# Bind("monBridgeToll3Tone") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>

                    <asp:TemplateField HeaderText="Bridge & Road Toll 2 Ton" SortExpression="monBridgeToll2Ton"><ItemTemplate>
                    <asp:TextBox ID="txtBnRToll2TonG" runat="server" CssClass="txtBox" Text='<%# Bind("monBridgeToll2Ton") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Bridge &amp; Road Toll 1 &amp; Half Ton" SortExpression="monBridgeToll1AndHalfTone"><ItemTemplate>
                    <asp:TextBox ID="txtBnRToll1AndHalfTonG" runat="server" CssClass="txtBox" Text='<%# Bind("monBridgeToll1AndHalfTone") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Ferry Toll" SortExpression="monFerryEXP"><ItemTemplate>
                    <asp:TextBox ID="txtFerryTollG" runat="server" CssClass="txtBox" Text='<%# Bind("monFerryEXP") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Ferry Toll 20 Ton" SortExpression="monFerryToll20Tone"><ItemTemplate>
                    <asp:TextBox ID="txtFT20TonG" runat="server" CssClass="txtBox" Text='<%# Bind("monFerryToll20Tone") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Ferry Toll 7 Ton" SortExpression="monFerryToll7Tone"><ItemTemplate>
                    <asp:TextBox ID="txtFT7TonG" runat="server" CssClass="txtBox" Text='<%# Bind("monFerryToll7Tone") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Ferry Toll 5 Ton" SortExpression="monFerryToll5Tone"><ItemTemplate>
                    <asp:TextBox ID="txtFT5TonG" runat="server" CssClass="txtBox" Text='<%# Bind("monFerryToll5Tone") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Ferry Toll 3 Ton" SortExpression="monFerryToll3Tone"><ItemTemplate>
                    <asp:TextBox ID="txtFT3TonG" runat="server" CssClass="txtBox" Text='<%# Bind("monFerryToll3Tone") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>

                    <asp:TemplateField HeaderText="Ferry Toll 1 & Half Ton" SortExpression="monFarryToll1AndHalfTone"><ItemTemplate>
                    <asp:TextBox ID="txtFT1AndHalfTonG" runat="server" CssClass="txtBox" Text='<%# Bind("monFarryToll1AndHalfTone") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>

                    </Columns>
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    </asp:GridView>
                    </td>
                </tr>
                <tr style="background-color:lightgray">
                    <td><asp:Button ID="btnUpdate" runat="server" class="nextclick" Font-Bold="true" ForeColor="Green" Text="Update" OnClientClick="ConfirmAll()" OnClick="btnUpdate_Click" /></td>
                </tr>
            </table>
        </div>
        
        <%--<asp:Label ID="lbldgvFTTotal" runat="server" CssClass="lbl"></asp:Label>--%>
        <%--=========================================End My Code From Here=================================================--%>
       
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

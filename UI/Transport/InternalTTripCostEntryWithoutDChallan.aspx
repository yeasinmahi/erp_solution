<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InternalTTripCostEntryWithoutDChallan.aspx.cs" Inherits="UI.Transport.InternalTTripCostEntryWithoutDChallan" %>
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

            //var f = parseFloat(document.getElementById("txtdgvFTTotal").value);
            //if (isNaN(f) == true) {
            //    f = 0;
            //}

            //var g = parseFloat(document.getElementById("txtFuelCash").value);
            //if (isNaN(g) == true) {
            //    g = 0;
            //}

            g = 0;

            var h = parseFloat(document.getElementById("hdnDieselTotalTk").value);
            if (isNaN(h) == true) {
                h = 0;
            }
            var i = parseFloat(document.getElementById("hdnCNGTotalTk").value);
            if (isNaN(i) == true) {
                i = 0;
            }

            var j = parseFloat(document.getElementById("hdnHightMilage").value);
            if (isNaN(j) == true) {
                j = 0;
            }
            document.getElementById("txtMillage").value = (j).toFixed(0);
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

        }
</script>
      
</head>
<body>
    <form id="frmselfresign" runat="server">
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
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnDieselTotalTk" runat="server" /><asp:HiddenField ID="hdnCNGTotalTk" runat="server" />
    <asp:HiddenField ID="hdnMillage" runat="server" /><asp:HiddenField ID="hdnHightMilage" runat="server" />
      
        
        <div class="tabs_container"> VEHICLE TRIP COST ENTRY FORM (WITHOUT DELIVERY CHALLAN)<hr /></div>

        <table  class="tbldecoration" style="width:auto; float:left;">
        <tr>  
            <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Unit"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" Width="195px" AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td>

            <td style="text-align:right;"><asp:Label ID="lblShipPoint" runat="server" CssClass="lbl" Text="Ship Point"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlShipPoint" CssClass="ddList" AutoPostBack="true" Font-Bold="False" runat="server" Width="195px" OnSelectedIndexChanged="ddlShipPoint_SelectedIndexChanged"></asp:DropDownList>                                                                       
            </td>  
            
            <td style="text-align:right;"><asp:Label ID="lblOutDate" runat="server" CssClass="lbl" Text="Out Date :"></asp:Label></td>                
            <td><asp:TextBox ID="txtOutDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="90px" autocomplete="off"></asp:TextBox>
            <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtOutDate"></cc1:CalendarExtender></td>                                
                                  
        </tr>
        <tr><td colspan="6"><hr /></td></tr>             
        <tr><td colspan="6" style="font-weight:bold; font-size:11px; color:#3369ff;">Vehicle & Driver Information:<hr /></td></tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblVehicleNo" runat="server" CssClass="lbl" Text="Vehicle No."></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlVehicleNo" CssClass="ddList" AutoPostBack="true" Font-Bold="False" runat="server" Width="195px" OnSelectedIndexChanged="ddlVehicleNo_SelectedIndexChanged"></asp:DropDownList>                                                                       
            </td> 

            <td style="text-align:right;"><asp:Label ID="lblVehicleT" runat="server" CssClass="lbl" Text="Vehicle Type :"></asp:Label></td>                  
            <td style="text-align:left;"><asp:TextBox ID="txtVehicleType" runat="server" CssClass="txtBox" BackColor="LightGray" BorderColor="Gray" Width="190px"></asp:TextBox></td>                                                                                                              
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblDriver" runat="server" CssClass="lbl" Text="Driver Name :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlDriverName" CssClass="ddList" AutoPostBack="true" Font-Bold="False" runat="server" Width="195px" OnSelectedIndexChanged="ddlDriverName_SelectedIndexChanged"></asp:DropDownList>                                                                                                                                                              
            </td>
            
            <%--<td style="text-align:right;"><asp:Label ID="lblLedgerB" runat="server" CssClass="lbl" Text="Ledger Ballance:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtLedgerB" runat="server" CssClass="txtBox" BackColor="LightGray" BorderColor="Gray" Width="190px"></asp:TextBox></td>--%>                                                                                                              

            <td style="text-align:right;"><asp:Label ID="lblAdvance" runat="server" CssClass="lbl" Text="Advance:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtAdvance" runat="server" CssClass="txtBox" Width="190px" onkeypress="return onlyNumbers();"></asp:TextBox></td>                                                                                                              
        </tr>
        <tr><td colspan="6"><hr /></td></tr> 
            
        <tr><td colspan="6" style="font-weight:bold; font-size:11px; color:#3369ff;">Challan/Gate Pass Information:<hr /></td></tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblShipPointForCustomer" runat="server" CssClass="lbl" Text="Ship Point"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlShipPointForCustomer" CssClass="ddList" AutoPostBack="true" Font-Bold="False" runat="server" Width="195px" OnSelectedIndexChanged="ddlShipPointForCustomer_SelectedIndexChanged"></asp:DropDownList>                                                                       
            </td> 
            
            <td style="text-align:right;"><asp:Label ID="lblCustomer" runat="server" CssClass="lbl" Text="Destination :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlCustomer" CssClass="ddList" AutoPostBack="true" Font-Bold="False" runat="server" Width="195px" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged"></asp:DropDownList>                                                                                                                                                              
            </td>

            <td style="text-align:right;"><asp:Label ID="lblMillage1" runat="server" CssClass="lbl" Text="Millage:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtMillage1" runat="server" CssClass="txtBox" BackColor="LightGray" BorderColor="Gray" Width="90px" onkeypress="return onlyNumbers();"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblChallanNo" runat="server" CssClass="lbl" Text="Challa/Gate Pass No.:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtChallanNo" runat="server" CssClass="txtBox" Width="190px"></asp:TextBox></td>                                                               

            <td style="text-align:right;"><asp:Label ID="lblQty" runat="server" CssClass="lbl" Text="Quantity :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtQty" runat="server" CssClass="txtBox" Width="190px" onkeypress="return onlyNumbers();"></asp:TextBox></td>                                                               

            <td colspan="2"><asp:Button ID="btnCustomerAdd" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Add" OnClick="btnCustomerAdd_Click"/></td>
        </tr>
        <%--<tr>
            <td style="text-align:right;"><asp:Label ID="lblUOMddl" runat="server" CssClass="lbl" Text="UOM :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlUOM" CssClass="ddList" AutoPostBack="false" Font-Bold="False" runat="server" Width="195px"></asp:DropDownList>                                                                                                                                                              
            </td>

            <td style="text-align:right;"><asp:Label ID="lblQty" runat="server" CssClass="lbl" Text="Quantity:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtQty" runat="server" CssClass="txtBox" Width="190px"></asp:TextBox></td>                                                                        
        </tr>--%>
        <tr><td colspan="6"> 
            <asp:GridView ID="dgvCustomerAdd" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"   ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDeleting="dgvCustomerAdd_RowDeleting" OnRowDataBound="dgvCustomerAdd_RowDataBound">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
            
            <asp:TemplateField HeaderText="custid" Visible="false" SortExpression="custid"><ItemTemplate>            
            <asp:Label ID="lblcustid" runat="server" Text='<%# Bind("custid") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Get Pass/Challan No." SortExpression="getpassno"><ItemTemplate>            
            <asp:Label ID="lblgetpassno" runat="server" Text='<%# Bind("getpassno") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="240px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Destiantion" SortExpression="custname"><ItemTemplate>            
            <asp:Label ID="lblcustname" runat="server" Text='<%# Bind("custname") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="350px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="Total" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Millage" SortExpression="milage"><ItemTemplate>            
            <asp:Label ID="lblmilag" runat="server" Text='<%# Bind("milage") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="70px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="unitid" Visible="false" SortExpression="unitid"><ItemTemplate>            
            <asp:Label ID="lblunitid" runat="server" Text='<%# Bind("unitid") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="shippid" Visible="false" SortExpression="shippid"><ItemTemplate>            
            <asp:Label ID="lblshippid" runat="server" Text='<%# Bind("shippid") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="right" SortExpression="qty" >
            <ItemTemplate><asp:Label ID="lblQty" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("qty"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="60px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalqty %>' /></FooterTemplate></asp:TemplateField>
            

            <%--<asp:TemplateField HeaderText="uomid" Visible="false" SortExpression="uomid"><ItemTemplate>            
            <asp:Label ID="lbluomid" runat="server" Text='<%# Bind("uomid") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="UOM" SortExpression="uom"><ItemTemplate>            
            <asp:Label ID="lbluom" runat="server" Text='<%# Bind("uom") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="70px"/></asp:TemplateField>
         
            <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="right" SortExpression="qty" >
            <ItemTemplate><asp:Label ID="lblqty" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("qty"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="80px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalqty %>' /></FooterTemplate></asp:TemplateField>--%>
                     
            <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" /> 

            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
        </tr> 
        <tr><td colspan="6"><hr /></td></tr>              
        <tr><td colspan="6" style="font-weight:bold; font-size:11px; color:#3369ff;">Fuel Cost:<hr /></td></tr>
        
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblFuelStation" runat="server" CssClass="lbl" Text="Fuel Station"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlFuelStation" CssClass="ddList" Font-Bold="False" runat="server" Width="195px"></asp:DropDownList>                                                                                       
            </td>
                        
            <td style="text-align:right;"><asp:Label ID="lblDieselTotalTk" runat="server" CssClass="lbl" Text="Diesel Total (Tk) :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtDieselTotalTk" runat="server" CssClass="txtBox" Width="190px" BackColor="LightGray" BorderColor="Gray" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>
            
            <td style="text-align:right;"><asp:Label ID="lblCNGTotalTk" runat="server" CssClass="lbl" Text="CNG Total (Tk) :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtCNGTotalTk" runat="server" CssClass="txtBox" Width="90px" BackColor="LightGray" BorderColor="Gray" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>                                      
      
            <%--<td style="text-align:right;"><asp:Label ID="lblFuelCash" runat="server" CssClass="lbl" Text="Fuel Cash :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtFuelCash" runat="server" CssClass="txtBox" Width="70px" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>--%>                                      

            <%--<td style="text-align:right;"><asp:Label ID="lblTFCost" runat="server" CssClass="lbl" Text="Total Fuel Cost :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtTFCost" runat="server" CssClass="txtBox" BackColor="LightGray" BorderColor="Gray" Width="160px" onkeypress="return onlyNumbers();" MaxLength="10"></asp:TextBox></td>--%>                                      
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblFuelPurchaeDate" runat="server" CssClass="lbl" Text="Fuel Purchae Date :"></asp:Label></td>                
            <td><asp:TextBox ID="txtFuelPurchaeDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="190px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFuelPurchaeDate"></cc1:CalendarExtender></td>                                

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
            <ItemStyle HorizontalAlign="Left" Width="350px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="Total" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Diesel Credit" ItemStyle-HorizontalAlign="right" SortExpression="dieselcredit" >
            <ItemTemplate><asp:Label ID="lbldieselcredit" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("dieselcredit"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="100px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totaldieselcredit %>' /></FooterTemplate></asp:TemplateField>
                         
            <asp:TemplateField HeaderText="CNG Credit" ItemStyle-HorizontalAlign="right" SortExpression="cngcredit" >
            <ItemTemplate><asp:Label ID="lblcngcredit" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("cngcredit"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="100px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalcngcredit %>' /></FooterTemplate></asp:TemplateField>
                
            <asp:TemplateField HeaderText="Total Credit" ItemStyle-HorizontalAlign="right" SortExpression="totalcredit" >
            <ItemTemplate><asp:Label ID="lblGrandTotal" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("totalcredit"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="100px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# grandtotal %>' /></FooterTemplate></asp:TemplateField>
                             
            <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" /> 

            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
        </tr> 
        <tr><td colspan="6"><hr /></td></tr>  
         <tr><td colspan="6" style="font-weight:bold; font-size:11px; color:#3369ff;">Expence:<hr /></td></tr>
        
        <tr>            
            <td style="text-align:right;"><asp:Label ID="lblMillage" runat="server" CssClass="lbl" Text="Last Millage :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtMillage" runat="server" CssClass="txtBox" BackColor="LightGray" BorderColor="Gray" Width="190px" onkeypress="return onlyNumbers();"></asp:TextBox></td>                                                               
            
            <td style="text-align:right;"><asp:Label ID="lblBridgeToll" runat="server" CssClass="lbl" Text="Bridge Toll :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtBridgeToll" runat="server" CssClass="txtBox" BackColor="LightGray" BorderColor="Gray" Width="190px" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>              

            <td style="text-align:right;"><asp:Label ID="lblFerryToll" runat="server" CssClass="lbl" Text="Ferry Toll:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtFerryToll" runat="server" CssClass="txtBox" BackColor="LightGray" BorderColor="Gray" Width="90px" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>                                                               
        </tr> 
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblLabourExp" runat="server" CssClass="lbl" Text="Labour Exp. :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtLabourExp" runat="server" CssClass="txtBox" Width="190px" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>                                                               

            <td style="text-align:right;"><asp:Label ID="lblPolice" runat="server" CssClass="lbl" Text="Police Tips :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtPolice" runat="server" CssClass="txtBox" Width="190px"  onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>              

            <td style="text-align:right;"><asp:Label ID="lblTotalRouteExp" runat="server" CssClass="lbl" Text="Total Route Exp.:"></asp:Label></td>
            <td style="text-align:left; color:grey;"><asp:TextBox ID="txtTotalRouteExp" runat="server" CssClass="txtBox"  BackColor="LightGray" BorderColor="Gray" Width="90px"></asp:TextBox></td>                                                                                       
        </tr>
                        
        <tr>
            <td colspan="6"><asp:Button ID="btnSubmit" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Submit" OnClientClick="ConfirmAll()" OnClick="btnSubmit_Click"/></td>
        </tr>
        
            
        </table>
        </div>


<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

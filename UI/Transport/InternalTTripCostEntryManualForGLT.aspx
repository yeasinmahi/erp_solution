<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InternalTTripCostEntryManualForGLT.aspx.cs" Inherits="UI.Transport.InternalTTripCostEntryManualForGLT" %>
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
            //////document.getElementById("txtMillage").value = (j).toFixed(0);
            document.getElementById("txtDieselTotalTk").value = (j * h).toFixed(0);
            document.getElementById("txtCNGTotalTk").value = (j * i).toFixed(0);

            document.getElementById("txtTotalRouteExp").value = (a + b + c + d + e + (j * h) + (j * i)).toFixed(0);
            //document.getElementById("txtTFCost").value = (f + g).toFixed(2);

            document.getElementById("txtTotalRouteExp").readOnly = true;
            //document.getElementById("txtTFCost").readOnly = true;
            //document.getElementById("txtFerryToll").readOnly = true;
            //document.getElementById("txtBridgeToll").readOnly = true;
            //////document.getElementById("txtMillage").readOnly = true;
            ////document.getElementById("txtLedgerB").readOnly = true;
            document.getElementById("txtDieselTotalTk").readOnly = true;
            document.getElementById("txtCNGTotalTk").readOnly = true;
        }
</script>
    
    <script>
        function FTPUpload() {
            document.getElementById("hdnconfirm").value = "2";
            __doPostBack();
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

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    
    <style type="text/css">
        #divFile p { 
            font:13px tahoma, arial; 
        }
        #divFile h3 { 
            font:16px arial, tahoma; 
            font-weight:bold;
        }
    </style>

    <script>
        $('#btUpload').click(function () {
            if (fileUpload.value.length == 0) {    // CHECK IF FILE(S) SELECTED.
                alert('No files selected.');
                return false;
            }
        });
</script>

          
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
        </tr>
        <tr><td colspan="10"><hr /></td></tr>             
        <tr><td colspan="10" style="font-weight:bold; font-size:11px; color:#3369ff;">Vehicle & Driver Information:<hr /></td></tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblVehicleNo" runat="server" CssClass="lbl" Text="Vehicle No."></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlVehicleNo" CssClass="ddList" AutoPostBack="true" Font-Bold="False" runat="server" Width="195px" OnSelectedIndexChanged="ddlVehicleNo_SelectedIndexChanged"></asp:DropDownList>                                                                       
            </td> 

            <td style="text-align:right;"><asp:Label ID="lblVehicleT" runat="server" CssClass="lbl" Text="Vehicle Type :"></asp:Label></td>                  
            <td style="text-align:left;"><asp:TextBox ID="txtVehicleType" runat="server" CssClass="txtBox" BackColor="LightGray" BorderColor="Gray" Width="190px"></asp:TextBox></td>                                                                                                              

            <td style="text-align:right;"><asp:Label ID="lblDriver" runat="server" CssClass="lbl" Text="Driver Name :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlDriverName" CssClass="ddList" AutoPostBack="true" Font-Bold="False" runat="server" Width="195px" OnSelectedIndexChanged="ddlDriverName_SelectedIndexChanged"></asp:DropDownList>                                                                                                                                                              
            </td>
            
            <td style="text-align:right;"><asp:Label ID="lblAdvance" runat="server" CssClass="lbl" Text="Advance:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtAdvance" runat="server" CssClass="txtBox" Width="60px" onkeypress="return onlyNumbers();"></asp:TextBox></td>  
        </tr>
        <tr><td colspan="10"><hr /></td></tr> 
            
        <tr><td colspan="10" style="font-weight:bold; font-size:11px; color:#3369ff;">Challan/Gate Pass Information:<hr /></td></tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblFromAddress" runat="server" CssClass="lbl" Text="From Address :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlFromAddress" CssClass="ddList" AutoPostBack="true" Font-Bold="False" runat="server" Width="195px" OnSelectedIndexChanged="ddlFromAddress_SelectedIndexChanged"></asp:DropDownList>                                                                       
            </td> 
            
            <td style="text-align:right;"><asp:Label ID="lblToAddress" runat="server" CssClass="lbl" Text="To Address :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlToAddress" CssClass="ddList" AutoPostBack="true" Font-Bold="False" runat="server" Width="195px" OnSelectedIndexChanged="ddlToAddress_SelectedIndexChanged"></asp:DropDownList>                                                                                                                                                              
            </td>
                        
            <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Cause Of Additional Millage :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtCauseOfAdditionalM" runat="server" CssClass="txtBox" Width="190px" TextMode="MultiLine"></asp:TextBox></td>              
                        
            <td style="text-align:right;"><asp:Label ID="lblAdditionalMillage" runat="server" CssClass="lbl" Text="Additional Millage :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtAdditionalMillage" runat="server" CssClass="txtBox" Width="60px" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>              

            <td style="text-align:right;"><asp:Label ID="lblMillage1" runat="server" CssClass="lbl" Text="Millage:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtMillage1" runat="server" CssClass="txtBox" BackColor="LightGray" BorderColor="Gray" Width="60px" onkeypress="return onlyNumbers();"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblOutDate" runat="server" CssClass="lbl" Text="Challa/Gate Pass Date :"></asp:Label></td>                
            <td><asp:TextBox ID="txtOutDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="190px" autocomplete="off"></asp:TextBox>
            <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtOutDate"></cc1:CalendarExtender></td>                                
                      
            <td style="text-align:right;"><asp:Label ID="lblChallanNo" runat="server" CssClass="lbl" Text="Challa/Gate Pass No.:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtChallanNo" runat="server" CssClass="txtBox" Width="190px"></asp:TextBox></td>                                                               

            <td style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Cause Of Additional Fare :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtCauseOfAdditionalF" runat="server" CssClass="txtBox" TextMode="MultiLine" Width="190px"></asp:TextBox></td>              

            <td style="text-align:right;"><asp:Label ID="lblAdditionalFare" runat="server" CssClass="lbl" Text="Additional Fare :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtAdditionalFare" runat="server" CssClass="txtBox" Width="60px" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>              

            <td style="text-align:right;"><asp:Label ID="lblTf" runat="server" CssClass="lbl" Text="Trip Fare:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtTripFare" runat="server" CssClass="txtBox" BackColor="LightGray" BorderColor="Gray" Width="60px" onkeypress="return onlyNumbers();"></asp:TextBox></td>

        </tr>
        <tr>
           <td style="text-align:right;"><asp:Label ID="Label4" runat="server" CssClass="lbl" Text="D. Trip Fare Cash:"></asp:Label></td>
           <td colspan="4" style="text-align:left;"><asp:TextBox ID="txtDTfareCash" runat="server" CssClass="txtBox" Width="60px" onkeypress="return onlyNumbers();"></asp:TextBox>
            <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="D. Trip Fare Credit:"></asp:Label>
            <asp:TextBox ID="txtDTfareCredit" runat="server" CssClass="txtBox" Width="60px" onkeypress="return onlyNumbers();"></asp:TextBox>

            <td colspan="5"><asp:Button ID="btnCustomerAdd" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Add" OnClick="btnCustomerAdd_Click"/></td>
        </tr>
        <%--<tr>
            <td style="text-align:right;"><asp:Label ID="lblUOMddl" runat="server" CssClass="lbl" Text="UOM :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlUOM" CssClass="ddList" AutoPostBack="false" Font-Bold="False" runat="server" Width="195px"></asp:DropDownList>                                                                                                                                                              
            </td>

            <td style="text-align:right;"><asp:Label ID="lblQty" runat="server" CssClass="lbl" Text="Quantity:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtQty" runat="server" CssClass="txtBox" Width="190px"></asp:TextBox></td>                                                                        
        </tr>--%>
        <tr><td colspan="10"> 
            <asp:GridView ID="dgvCustomerAdd" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDeleting="dgvCustomerAdd_RowDeleting" OnRowDataBound="dgvCustomerAdd_RowDataBound">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
            
            <asp:TemplateField HeaderText="fromcustid" Visible="false" SortExpression="fromcustid"><ItemTemplate>            
            <asp:Label ID="lblfromcustid" runat="server" Text='<%# Bind("fromcustid") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="tocustid" Visible="false" SortExpression="tocustid"><ItemTemplate>            
            <asp:Label ID="lbltocustid" runat="server" Text='<%# Bind("tocustid") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Get Pass/Challan Date" SortExpression="dtechallndate"><ItemTemplate>            
            <asp:Label ID="lblchallndate" runat="server" Text='<%# Bind("dtechallndate") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Get Pass/Challan No." SortExpression="getpassno"><ItemTemplate>            
            <asp:Label ID="lblgetpassno" runat="server" Text='<%# Bind("getpassno") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="From Destiantion" SortExpression="fromcustname"><ItemTemplate>            
            <asp:Label ID="lblcustnameFrom" runat="server" Text='<%# Bind("fromcustname") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="200px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="To Destiantion" SortExpression="tocustname"><ItemTemplate>            
            <asp:Label ID="lblcustnameTo" runat="server" Text='<%# Bind("tocustname") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="200px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Cause Of Additional Millage" SortExpression="causeofaddmillage"><ItemTemplate>            
            <asp:Label ID="lblCOAM" runat="server" Text='<%# Bind("causeofaddmillage") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="200px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="Total" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Additional Millage" ItemStyle-HorizontalAlign="right" SortExpression="addmillage" >
            <ItemTemplate><asp:Label ID="lblAddmilag" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("addmillage"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="70px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totaladdmilage %>' /></FooterTemplate></asp:TemplateField>
                 
            <asp:TemplateField HeaderText="Millage" ItemStyle-HorizontalAlign="right" SortExpression="milage" >
            <ItemTemplate><asp:Label ID="lblmilag" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("milage"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="70px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalmilage %>' /></FooterTemplate></asp:TemplateField>
              
            <asp:TemplateField HeaderText="Cause Of Additional Fare" SortExpression="causeofaddfare"><ItemTemplate>            
            <asp:Label ID="lblAddF" runat="server" Text='<%# Bind("causeofaddfare") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="200px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Additional Fare" ItemStyle-HorizontalAlign="right" SortExpression="addfare" >
            <ItemTemplate><asp:Label ID="lblAddFare" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("addfare"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="70px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totaladdfare %>' /></FooterTemplate></asp:TemplateField>
                                    
            <asp:TemplateField HeaderText="Trip Fare" ItemStyle-HorizontalAlign="right" SortExpression="tfare" >
            <ItemTemplate><asp:Label ID="lbltf" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("tfare"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="70px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totaltfare %>' /></FooterTemplate></asp:TemplateField>
                 
            <asp:TemplateField HeaderText="DT. Fare Cash" ItemStyle-HorizontalAlign="right" SortExpression="dtfarecash" >
            <ItemTemplate><asp:Label ID="lblDTFareCash" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("dtfarecash"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="70px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totaldtfcash %>' /></FooterTemplate></asp:TemplateField>
                
            <asp:TemplateField HeaderText="DT. Fare Credit" ItemStyle-HorizontalAlign="right" SortExpression="dtfarecredit" >
            <ItemTemplate><asp:Label ID="lblDTFareCredit" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("dtfarecredit"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="70px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totaldtfcredit %>' /></FooterTemplate></asp:TemplateField>
                                     
            <asp:TemplateField HeaderText="unitid" Visible="false" SortExpression="unitid"><ItemTemplate>            
            <asp:Label ID="lblunitid" runat="server" Text='<%# Bind("unitid") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="shippid" Visible="false" SortExpression="shippid"><ItemTemplate>            
            <asp:Label ID="lblshippid" runat="server" Text='<%# Bind("shippid") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

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
        <tr><td colspan="10"><hr /></td></tr>              
        
            
         <tr><td colspan="10" style="font-weight:bold; font-size:11px; color:#3369ff;">Fuel Cost:<hr /></td></tr>
        
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblFuelPurchaeDate" runat="server" CssClass="lbl" Text="Fuel Purchae Date :"></asp:Label></td>                
            <td colspan="9"><asp:TextBox ID="txtFuelPurchaeDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="90px" autocomplete="off"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFuelPurchaeDate"></cc1:CalendarExtender>

            <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="  "></asp:Label>
            <asp:Label ID="lblFuelStation" runat="server" CssClass="lbl" Text="Fuel Station :"></asp:Label>
            <asp:DropDownList ID="ddlFuelStation" CssClass="ddList" Font-Bold="False" runat="server" Width="190px"></asp:DropDownList>

            <asp:Label ID="lblDieselTotalTk" runat="server" CssClass="lbl" Text="Diesel (Tk) :"></asp:Label>
            <asp:TextBox ID="txtDieselTotalTk" runat="server" CssClass="txtBox" Width="60px" BackColor="LightGray" BorderColor="Gray" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox>

            <asp:Label ID="lblDieselCredit" runat="server" CssClass="lbl" Text="Diesel Credit :"></asp:Label>
            <asp:TextBox ID="txtDieselCredit" runat="server" CssClass="txtBox" Width="60px" onkeypress="return onlyNumbers();"></asp:TextBox>

            <asp:Label ID="lblCNGTotalTk" runat="server" CssClass="lbl" Text="CNG (Tk) :"></asp:Label>
            <asp:TextBox ID="txtCNGTotalTk" runat="server" CssClass="txtBox" Width="60px" BackColor="LightGray" BorderColor="Gray" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox>
            
            <asp:Label ID="lblCNGCredit" runat="server" CssClass="lbl" Text="CNG Credit :"></asp:Label>
            <asp:TextBox ID="txtCNGCredit" runat="server" CssClass="txtBox" Width="60px" onkeypress="return onlyNumbers();"></asp:TextBox>

            <asp:Button ID="btnFuelCostAdd" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Add" OnClick="btnFuelCostAdd_Click"/>
            </td>                                
            
            <%--<td style="text-align:right;"></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlFuelStation" CssClass="ddList" Font-Bold="False" runat="server" Width="195px"></asp:DropDownList>                                                                                       
            </td>--%>
             
            <%--<td style="text-align:right;"><asp:Label ID="lblFuelCash" runat="server" CssClass="lbl" Text="Fuel Cash :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtFuelCash" runat="server" CssClass="txtBox" Width="70px" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>--%>                                      

            <%--<td style="text-align:right;"><asp:Label ID="lblTFCost" runat="server" CssClass="lbl" Text="Total Fuel Cost :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtTFCost" runat="server" CssClass="txtBox" BackColor="LightGray" BorderColor="Gray" Width="160px" onkeypress="return onlyNumbers();" MaxLength="10"></asp:TextBox></td>--%>                                      
        </tr>
                   
        <tr><td colspan="10"> 
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
        <tr><td colspan="10"><hr /></td></tr>  
         <tr><td colspan="10" style="font-weight:bold; font-size:11px; color:#3369ff;">Expence:<hr /></td></tr>
        
        <tr> 
            <td style="text-align:right;"><asp:Label ID="lblBridgeToll" runat="server" CssClass="lbl" Text="Bridge Toll :"></asp:Label></td>
            <td colspan="9" style="text-align:left;"><asp:TextBox ID="txtBridgeToll" runat="server" CssClass="txtBox" BackColor="LightGray" BorderColor="Gray" Width="60px" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox>

            <asp:Label ID="lblFerryToll" runat="server" CssClass="lbl" Text="Ferry Toll:"></asp:Label>
            <asp:TextBox ID="txtFerryToll" runat="server" CssClass="txtBox" BackColor="LightGray" BorderColor="Gray" Width="60px" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox>

            <asp:Label ID="lblLabourExp" runat="server" CssClass="lbl" Text="Labour Exp. :"></asp:Label>
            <asp:TextBox ID="txtLabourExp" runat="server" CssClass="txtBox" Width="60px" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox>

            <asp:Label ID="lblPolice" runat="server" CssClass="lbl" Text="Police Tips :"></asp:Label>
            <asp:TextBox ID="txtPolice" runat="server" CssClass="txtBox" Width="60px"  onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox>

            <asp:Label ID="lblTotalRouteExp" runat="server" CssClass="lbl" Text="Total Route Exp.:"></asp:Label>
            <asp:TextBox ID="txtTotalRouteExp" runat="server" CssClass="txtBox"  BackColor="LightGray" BorderColor="Gray" Width="60px"></asp:TextBox>
                
            </td>                                          
        </tr> 
                                
        <tr>
            <td colspan="10"><asp:Button ID="btnSubmit" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Submit" OnClientClick="ConfirmAll()" OnClick="btnSubmit_Click"/></td>
        </tr>
                     

        </table>
        </div>

    <%--<div id="divFile">
            <h3>Multiple File Upload in Asp.Net (C#)</h3>
            
            <p><asp:FileUpload ID="fileUpload" multiple="true" runat="server" /></p>
            <p>
                <p><asp:Button ID="btUpload" Text ="Upload Files" 
                    OnClick="Upload_Files" runat="server" /></p>
            </p>
            <p><asp:label id="lblFileList" runat="server"></asp:label></p>
            <p><asp:Label ID="lblUploadStatus" runat="server"></asp:Label></p>
            <p><asp:Label ID="lblFailedStatus" runat="server"></asp:Label></p>
        </div>--%>

          <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true" />

<asp:Button ID="btnUpload" runat="server" Text="Submit" onclick="btnUpload_Click"  />

<hr />

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 

            EmptyDataText = "No files uploaded" CellPadding="4" 

            EnableModelValidation="True" ForeColor="#333333" GridLines="None">

    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

    <Columns>

        <asp:BoundField DataField="Text" HeaderText="File Name" />

        <asp:TemplateField>

            <ItemTemplate>

                <asp:LinkButton ID="lnkDownload" Text = "Download" CommandArgument = '<%# Eval("Value") %>' runat="server" OnClick = "DownloadFile"></asp:LinkButton>

            </ItemTemplate>

        </asp:TemplateField>

        <asp:TemplateField>

            <ItemTemplate>

                <asp:LinkButton ID = "lnkDelete" Text = "Delete" CommandArgument = '<%# Eval("Value") %>' runat = "server" OnClick = "DeleteFile" />

            </ItemTemplate>

        </asp:TemplateField>

    </Columns>

    <EditRowStyle BackColor="#999999" />

    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />

    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />

    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />

    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />

    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />

</asp:GridView>



<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

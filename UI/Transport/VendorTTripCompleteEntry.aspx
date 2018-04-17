<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VendorTTripCompleteEntry.aspx.cs" Inherits="UI.Transport.VendorTTripCompleteEntry" %>
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
            var a, b, c, d, e, f;

            //***Total Trip Fare Calculation Start

            var a = parseFloat(document.getElementById("hdnTFare").value);
            if (isNaN(a) == true) { a = 0; }

            var b = parseFloat(document.getElementById("txtSpecialFare").value);
            if (isNaN(b) == true) { b = 0; }

            var c = parseFloat(document.getElementById("txtAdditionalFare").value);
            if (isNaN(c) == true) { c = 0; }

            var d = parseFloat(document.getElementById("txtCompanyDem").value);
            if (isNaN(d) == true) { d = 0; }

            var e = parseFloat(document.getElementById("txtPartyDem").value);
            if (isNaN(e) == true) { e = 0; }

            var f = parseFloat(document.getElementById("txtOthersTK").value);
            if (isNaN(f) == true) { f = 0; }

            document.getElementById("txtTotalTripFare").value = ((a + b + c + d + f) - e).toFixed(0);
            document.getElementById("txtTotalTripFare").readOnly = true;
            //***Total Trip Fare Calculation End  

        }

        function Save() {
            document.getElementById("hdnField").value = "1";
            __doPostBack();
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
    <asp:TextBox ID="txtdgvFTTotal" runat="server" Width="0.1px" CssClass="txtBox" Height="0.1px" MaxLength="10" BackColor="White" ForeColor="White" ></asp:TextBox>        
        <div class="leaveApplication_container"> 
        <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
        <asp:HiddenField ID="hdnconfirm" runat="server" /> <asp:HiddenField ID="hdnTFare" runat="server" /> 
        <asp:HiddenField ID="hdnQty" runat="server" />
      
        <div class="tabs_container"> VENDOR TRANSPORT TRIP COMPLETE<hr /></div>

        <table  class="tbldecoration" style="width:auto; float:left;">        
        
        <tr>
            <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="lblTrip" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Trip Sl No. :"></asp:Label></td>
            <td style="font-weight:bold; text-align:left; color:#0b6016;"><asp:Label ID="lblTripNo" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px"></asp:Label></td>

            <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="lblVehicle" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Vehicle No. :"></asp:Label></td>
            <td style="font-weight:bold; text-align:left; color:#0b6016;"><asp:Label ID="lblVehicleNo" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px"></asp:Label></td>                        
        </tr>
        <tr>
            <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="lblCustN" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Final Destination :"></asp:Label></td>
            <td style="font-weight:bold; text-align:left; color:#0b6016;"><asp:Label ID="lblCustName" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px"></asp:Label></td>            
            
            <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="lblVehicleT" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Vehicle Type :"></asp:Label></td>
            <td style="font-weight:bold; text-align:left; color:#0b6016;"><asp:Label ID="lblVehicleType" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px"></asp:Label></td>            
        </tr>
        <tr><td colspan="4"><hr /></td></tr> 

        <tr>
            <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Cause Of Company Demurrage:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtCauseOfComDem" runat="server" CssClass="txtBox" TextMode="MultiLine" Width="190px"></asp:TextBox></td>              
            
            <td style="text-align:right;"><asp:Label ID="Label3" runat="server" Width="170px" CssClass="lbl" Text="Company Demurrage (Tk) :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtCompanyDem" runat="server" CssClass="txtBox" Width="110px" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>              
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Cause Of Party Demurrage:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtCauseOfPartyDem" runat="server" CssClass="txtBox" TextMode="MultiLine" Width="190px"></asp:TextBox></td>              
            
            <td style="text-align:right;"><asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Party Demurrage (Tk) :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtPartyDem" runat="server" CssClass="txtBox" Width="110px" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>              
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Cause Of Additional Fare :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtCauseOfAdditionalF" runat="server" CssClass="txtBox" TextMode="MultiLine" Width="190px"></asp:TextBox></td>              
            
            <td style="text-align:right;"><asp:Label ID="lblAdditionalFare" runat="server" CssClass="lbl" Text="Additional Fare (Tk) :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtAdditionalFare" runat="server" CssClass="txtBox" Width="110px" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>              
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="Label6" runat="server" CssClass="lbl" Text="Cause Of Special Fare :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtCauseOfSpeDem" runat="server" CssClass="txtBox" TextMode="MultiLine" Width="190px"></asp:TextBox></td>              

            <td style="text-align:right;"><asp:Label ID="Label7" runat="server" CssClass="lbl" Text="Special Fare (Tk) :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtSpecialFare" runat="server" CssClass="txtBox" Width="110px" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>              
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblCauseOfOthers" runat="server" CssClass="lbl" Text="Cause Of Others (+-) :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtCauseOfOthers" runat="server" CssClass="txtBox" TextMode="MultiLine" Width="190px"></asp:TextBox></td>              

            <td style="text-align:right;"><asp:Label ID="lblOthersTK" runat="server" CssClass="lbl" Text="Others (TK) :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtOthersTK" runat="server" CssClass="txtBox" Width="110px" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>
        </tr>            
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblQty" runat="server" CssClass="lbl" Text="Quantity :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtQuantity" runat="server" CssClass="txtBox" BackColor="LightGray" BorderColor="Gray" Width="190px" onkeypress="return onlyNumbers();" MaxLength="10"></asp:TextBox></td>
            
            <td style="text-align:right;"><asp:Label ID="Label9" runat="server" CssClass="lbl" Text="Net Payable (Tk) :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtTotalTripFare" runat="server" CssClass="txtBox" BackColor="LightGray" BorderColor="Gray" Width="110px" onkeypress="return onlyNumbers();" MaxLength="10"></asp:TextBox></td>              
        </tr>
        <tr>                
            <td style="text-align:right;"><asp:Label ID="lblVehicleSupplier" runat="server" CssClass="lbl" Text="Vehicle Supplier:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlVehicleSupplier" CssClass="ddList" Font-Bold="False" runat="server"></asp:DropDownList>                                                                                       
            </td>
        </tr>
        <tr><td colspan="4"><hr /></td></tr>             
        <tr><td colspan="4" style="font-weight:bold; font-size:11px; color:#3369ff;">Document Upload:<hr /></td></tr>       
        <tr class="tblrowodd">           
            <td style="text-align:right;"><asp:Label ID="Label11" runat="server" CssClass="lbl" Text="Document Type :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlDocType" CssClass="ddList" Font-Bold="False" runat="server" Width="195px"></asp:DropDownList>                                                                                       
            </td>
            
            <td style='text-align: right; width:120px;'>Document Upload : </td>
            <td style='text-align: center;'>
                <asp:FileUpload ID="txtDocUpload" runat="server" /></td> <asp:HiddenField ID="hdnField" runat="server" />
            <%--<td><asp:Button ID="Save" runat="server" class="nextclick" Font-Bold="true" ForeColor="Green" Text="Add" onclick="Save()"/></td>--%>
            <%--<td><a class="nextclick" onclick="FTPUpload()">Add</a></td>--%> 
            
        </tr>
        <tr>
            <td colspan="4" style="text-align:right;"> 
            <a class="nextclick" onclick="FTPUpload()">Add</a> </td>
        </tr>  
        <tr><td colspan="4"> 
            <asp:GridView ID="dgvDocUp" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgvDocUp_RowDeleting1">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
                    
            <asp:TemplateField HeaderText="File Name" SortExpression="strFileName"><ItemTemplate>            
            <asp:Label ID="lblFileName" runat="server" Text='<%# Bind("strFileName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="530px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="doctypeid" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="doctypeid" >
            <ItemTemplate><asp:Label ID="lbldoctypeid" runat="server" DataFormatString="{0:0.00}" Text='<%# (""+Eval("doctypeid")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                           
            <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" /> 

            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
        </tr> 
            
        <tr><td colspan="4"><hr /></td></tr> 
        <tr>
            <td colspan="4" style="text-align:left;"><asp:Button ID="btnTripComplete" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick"  OnClientClick="FTPUpload1()"  Text="Trip Complete"/></td>
        </tr>
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
     
<%--=========================================End My Code From Here=================================================--%>
       
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
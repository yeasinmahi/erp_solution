<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PoWithoutIndent.aspx.cs" Inherits="UI.SCM.PoWithoutIndent" %>

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
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" /> 
    <script src="jquery.min.js"></script> 
    <script src="jquery-ui.min.js"></script> 
    <link href="../Content/CSS/GridView.css" rel="stylesheet" />
    <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />


     <script type="text/javascript">
         function PoGenerateCheck() {
             var e = document.getElementById("ddlSuppliyer");
             var suppId = e.options[e.selectedIndex].value;
             var e = document.getElementById("ddlWHPrepare");
             var whId = e.options[e.selectedIndex].value;
             var e = document.getElementById("ddlCurrency");
             var currencyId = e.options[e.selectedIndex].value;
             var e = document.getElementById("ddlCostCenter");
             var costId = e.options[e.selectedIndex].value;
             var e = document.getElementById("ddlPaymentTrams");
             var paymentTremsId = e.options[e.selectedIndex].value;

             var noOfShipment = document.getElementById("txtNoOfShipment").value;
             var afterMrrDay = document.getElementById("txtAfterMrrDay").value;
             var destDelivery = document.getElementById("txtDestinationDelivery").value;
             var lastShipmentDte = document.getElementById("txtLastShipmentDate").value;

             if ($.trim(suppId) == 0 || $.trim(suppId) == "" || $.trim(suppId) == null || $.trim(suppId) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please select Suppliyer'); }
             else if ($.trim(currencyId) == 0 || $.trim(currencyId) == "" || $.trim(currencyId) == null || $.trim(currencyId) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please select Currency'); }
             else if ($.trim(paymentTremsId) == 0 || $.trim(paymentTremsId) == "" || $.trim(paymentTremsId) == null || $.trim(paymentTremsId) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please select PaymentTrems'); }
             else if ($.trim(noOfShipment) == 0 || $.trim(noOfShipment) == "" || $.trim(noOfShipment) == null || $.trim(noOfShipment) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please set Number of Shipment'); }
             else if ($.trim(afterMrrDay) == 0 || $.trim(afterMrrDay) == "" || $.trim(afterMrrDay) == null || $.trim(afterMrrDay) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please set After MRR Day'); }
             else if ($.trim(destDelivery).length < 1 || $.trim(destDelivery) == "" || $.trim(destDelivery) == null || $.trim(destDelivery) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please set Destination Delivery'); }
             else if ($.trim(lastShipmentDte).length < 3 || $.trim(lastShipmentDte) == "" || $.trim(lastShipmentDte) == null || $.trim(lastShipmentDte) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please set Last Shipment Date'); }
             else {
                 var confirm_value = document.createElement("INPUT");
                 confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                 if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnPreConfirm").value = "1"; }
                 else { confirm_value.value = "No"; document.getElementById("hdnPreConfirm").value = "0"; }

                 // document.getElementById("hdnPreConfirm").value = "1";
             }


         }
    </script>
   <%-- GridView Text Change Calculation --%>
     <script type="text/javascript">

         $(function () {
             ////$("[id*=txtQty]").val("0");
         });

         $("[id*=lblQty]").live("change", function () {
             if (isNaN(parseFloat($(this).val()))) {
                 $(this).val('0');
             } else { parseFloat($(this).val($(this).val()).toString()).toFixed(2); }
         });
         //*** txtQty Selection Change Start ****************************************************************************
         $("[id*=lblQty]").live("keyup", function () {
             if (!jQuery.trim($(this).val()) == '') {

                 if (!isNaN(parseFloat($(this).val()))) {
                     var row = $(this).closest("tr");
                     $("[id*=lblTotalVal]", row).html((((parseFloat($("[id*=txtRate]", row).val()) + parseFloat($("[id*=txtVAT]", row).val()) + parseFloat($("[id*=txtAIT]", row).val()))) * ($(this).val())).toFixed(2));
                 }
             } else {
                 $(this).val('');
             }

             //var at = parseFloat($("[id*=txtAIT]", row).val());
             //var atc = $("[id*=txtAIT]", row).val();
             //var atch = $("[id*=txtAIT]", row).val();

             var grandTotal = 0;
             var grandTotalqty = 0;
             var grandTotalVat = 0;
             var grandTotalait = 0;

             $("[id*=lblTotalVal]").each(function () {
                 grandTotal = grandTotal + parseFloat($(this).html());
             });
             $("[id*=lblGrandTotal]").html(parseFloat(grandTotal.toString()).toFixed(2));

             $("[id*=txtAIT]").each(function () {
                 grandTotalait = grandTotalait + parseFloat($(this).val());
             });
             $("[id*=lblGrandTotalAIT]").html(grandTotalait.toString());

             $("[id*=lblQty]").each(function () {
                 grandTotalqty = grandTotalqty + parseFloat($(this).val());
             });
             $("[id*=lblGrandTotalQty]").html(parseFloat(grandTotalqty.toString()).toFixed(2));

             $("[id*=txtVAT]").each(function () {
                 grandTotalVat = grandTotalVat + parseFloat($(this).val());
             });
             $("[id*=lblGrandTotalVAT]").html(grandTotalVat.toString());
         });
         //*** txtQty Selection Change End ****************************************************************************      

         //*** txtRate Selection Change Start ****************************************************************************
         $(function () {
             ////$("[id*=txtRate]").val("0");
         });

         $("[id*=txtRate]").live("change", function () {
             if (isNaN(parseFloat($(this).val()))) {
                 $(this).val('0');
             } else { parseFloat($(this).val($(this).val()).toString()).toFixed(2); }
         });

         $("[id*=txtRate]").live("keyup", function () {
             if (!jQuery.trim($(this).val()) == '') {

                 if (!isNaN(parseFloat($(this).val()))) {
                     var row = $(this).closest("tr");
                     var a = parseFloat($("[id*=lblQty]", row).html());
                     var b = parseFloat($("[id*=txtVAT]", row).val());
                     var c = parseFloat($("[id*=txtAIT]", row).val());
                     var d = parseFloat($(this).val());
                     var rtotal = parseFloat(a * (d + b + c));
                     $("[id*=lblTotalVal]", row).html(rtotal.toFixed(3));

                 }
             } else {
                 $(this).val('');
             }

             var grandTotal = 0;
             var grandTotalqty = 0;
             var grandTotalVat = 0;
             var grandTotalait = 0;

             $("[id*=lblTotalVal]").each(function () {
                 grandTotal = grandTotal + parseFloat($(this).html());
             });
             $("[id*=lblGrandTotal]").html(parseFloat(grandTotal.toString()).toFixed(2));

             $("[id*=txtAIT]").each(function () {
                 grandTotalait = grandTotalait + parseFloat($(this).val());
             });
             $("[id*=lblGrandTotalAIT]").html(grandTotalait.toString());

             $("[id*=lblQty]").each(function () {
                 grandTotalqty = grandTotalqty + parseFloat($(this).html());
             });
             $("[id*=lblGrandTotalQty]").html(grandTotalqty.toString());

             $("[id*=txtVAT]").each(function () {
                 grandTotalVat = grandTotalVat + parseFloat($(this).val());
             });
             $("[id*=lblGrandTotalVAT]").html(grandTotalVat.toString());

         });
         //*** txtRate Selection Change End ****************************************************************************
         //*** txtVAT Selection Change Start ****************************************************************************
         $(function () {
             ////$("[id*=txtVAT]").val("0");
         });

         $("[id*=txtVAT]").live("change", function () {
             if (isNaN(parseFloat($(this).val()))) {
                 $(this).val('0');
             } else { parseFloat($(this).val($(this).val()).toString()).toFixed(2); }
         });

         $("[id*=txtVAT]").live("keyup", function () {
             if (!jQuery.trim($(this).val()) == '') {

                 if (!isNaN(parseFloat($(this).val()))) {
                     var row = $(this).closest("tr");

                     var a = parseFloat($("[id*=lblQty]", row).html());
                     var b = parseFloat($("[id*=txtRate]", row).val());
                     var c = parseFloat($("[id*=txtAIT]", row).val());
                     var d = parseFloat($(this).val());
                     var rtotal = parseFloat(a * (b + d + c));
                     $("[id*=lblTotalVal]", row).html(rtotal.toFixed(3));

                 }
             } else {
                 $(this).val('');
             }

             var grandTotal = 0;
             var grandTotalqty = 0;
             var grandTotalVat = 0;
             var grandTotalait = 0;

             $("[id*=lblTotalVal]").each(function () {
                 grandTotal = grandTotal + parseFloat($(this).html());
             });
             $("[id*=lblGrandTotal]").html(parseFloat(grandTotal.toString()).toFixed(2));

             $("[id*=txtAIT]").each(function () {
                 grandTotalait = grandTotalait + parseFloat($(this).val());
             });
             $("[id*=lblGrandTotalAIT]").html(parseFloat(grandTotalait.toString()).toFixed(2));

             $("[id*=lblQty]").each(function () {
                 grandTotalqty = grandTotalqty + parseFloat($(this).html());
             });
             $("[id*=lblGrandTotalQty]").html(parseFloat(grandTotalqty.toString()).toFixed(2));

             $("[id*=txtVAT]").each(function () {
                 grandTotalVat = grandTotalVat + parseFloat($(this).val());
             });
             $("[id*=lblGrandTotalVAT]").html(grandTotalVat.toString());
         });
         //*** txtVAT Selection Change End ****************************************************************************

         //*** txtAIT Selection Change Start ****************************************************************************

         $(function () {

         }); 
         $("[id*=txtAIT]").live("change", function () {
             if (isNaN(parseFloat($(this).val()))) {
                 $(this).val('0');
             } else { parseFloat($(this).val($(this).val()).toString()).toFixed(2); }
         });

         $("[id*=txtAIT]").live("keyup", function () {
             if (!jQuery.trim($(this).val()) == '') {

                 if (!isNaN(parseFloat($(this).val()))) {
                     var row = $(this).closest("tr");
                     var a = parseFloat($("[id*=lblQty]", row).html());
                     var b = parseFloat($("[id*=txtRate]", row).val());
                     var c = parseFloat($("[id*=txtVAT]", row).val());
                     var d = parseFloat($(this).val());
                     var rtotal = parseFloat(a * (b + c + d));
                     $("[id*=lblTotalVal]", row).html(rtotal.toFixed(3));


                 }
             } else {
                 $(this).val('');
             }

             var grandTotal = 0;
             var grandTotalqty = 0;
             var grandTotalVat = 0;
             var grandTotalait = 0;

             $("[id*=lblTotalVal]").each(function () {
                 grandTotal = grandTotal + parseFloat($(this).html());
             });
             $("[id*=lblGrandTotal]").html(parseFloat(grandTotal.toString()).toFixed(2));

             $("[id*=txtAIT]").each(function () {
                 grandTotalait = grandTotalait + parseFloat($(this).val());
             });
             $("[id*=lblGrandTotalAIT]").html(parseFloat(grandTotalait.toString()).toFixed(2));

             $("[id*=lblQty]").each(function () {
                 grandTotalqty = grandTotalqty + parseFloat($(this).html());
             });
             $("[id*=lblGrandTotalQty]").html(parseFloat(grandTotalqty.toString()).toFixed(2));

             $("[id*=txtVAT]").each(function () {
                 grandTotalVat = grandTotalVat + parseFloat($(this).val());
             });
             $("[id*=lblGrandTotalVAT]").html(grandTotalVat.toString());
         });
         //*** txtAIT Selection Change End ****************************************************************************
</script>

    <script type="text/javascript"> 
        function funConfirmAll() { 
            var confirm_value = document.createElement("INPUT"); 
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value"; 
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnConfirm").value = "1"; } 
            else { confirm_value.value = "No"; document.getElementById("hdnConfirm").value = "0"; } 
        }

</script> 

  
    <style type="text/css"> 
        .rounds {
        height: 80px;
        width: 30px; 
        -moz-border-colors:25px;
        border-radius:25px;
        } 

        .HyperLinkButtonStyle { float:right; text-align:left; border: none; background: none; 
        color: blue; text-decoration: underline; font: normal 10px verdana;} 
        .hdnDivision { background-color: white; position:absolute;z-index:1; visibility:hidden; border:10px double black; text-align:center;
        width:100%; height: 100%;    margin-left:50px;  margin-top:130px; margin-right:00px; padding: 15px; overflow-y:scroll; }

        
        </style>
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

    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnPreConfirm" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
     <asp:HiddenField ID="hdnIndentNo" runat="server" /><asp:HiddenField ID="hdnIndentDate" runat="server" />
    
       <div class="tabs_container" style="text-align:left">PO without Indent From<hr /></div>
               <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                  <table>
                      
                      <caption>
                          <asp:Label ID="lblSuppAddress" ForeColor="Red" Font-Size="Small" runat="server"></asp:Label>
                      </caption>
                      <tr>
                         <td colspan="3" style="text-align:right;"> <asp:Label ID="Label16" runat="server" CssClass="lbl" Text="Department"></asp:Label></td>  
                          <td style="text-align:left;"><asp:DropDownList ID="ddlDepts" runat="server" AutoPostBack="true" CssClass="ddList" Font-Bold="False"> </asp:DropDownList></td>  
                        <td><asp:Label ID="lblPO" runat="server" ForeColor="Blue" ></asp:Label></td>
                      </tr>
                      <tr>
                          <td style="text-align:right;">
                              <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="WH-Name"></asp:Label>
                          </td>
                          <td style="text-align:left;">
                              <asp:DropDownList ID="ddlWHPrepare" runat="server" AutoPostBack="True" CssClass="ddList" Font-Bold="False" OnSelectedIndexChanged="ddlWHPrepare_SelectedIndexChanged">
                              </asp:DropDownList>
                          </td>
                          <td style="text-align:right;">
                              <asp:Label ID="Label6" runat="server" CssClass="lbl" Text="Suppliyer"></asp:Label>
                          </td>
                          <td style="text-align:left;">
                              <asp:DropDownList ID="ddlSupplier" runat="server" AutoPostBack="true" CssClass="ddList" Font-Bold="False" OnSelectedIndexChanged="ddlSuppliyer_SelectedIndexChanged">
                              </asp:DropDownList>
                          </td>
                          <td style="text-align:right;">
                              <asp:Label ID="Label8" runat="server" CssClass="lbl" Text="Transport"></asp:Label>
                          </td>
                          <td style="text-align:left;">
                              <asp:TextBox ID="txtTransport" runat="server" AutoPostBack="false" CssClass="txtBox" Font-Bold="False" Text="0"></asp:TextBox>
                          </td>
                      </tr>
                     <tr> 
                              <td style="text-align:right;"><asp:Label ID="Label7" runat="server" CssClass="lbl" Text="CostCenter"></asp:Label></td>  
                                 
                              <td style="text-align:left;">  <asp:DropDownList ID="ddlCostCenter" runat="server" AutoPostBack="false" CssClass="ddList" Font-Bold="False"></asp:DropDownList></td>
                             
                              <td style="text-align:right;"> <asp:Label ID="Label9" runat="server" CssClass="lbl" Text="Others:"></asp:Label> </td> 
                         
                              <td style="text-align:left;"> <asp:TextBox ID="txtOthers" runat="server" Text="0" AutoPostBack="false"  CssClass="txtBox" Font-Bold="False"> </asp:TextBox> </td>
                              
                              <td style="text-align:right;"><asp:Label ID="Label10" runat="server" CssClass="lbl" Text="Gross Discount: "></asp:Label></td>  
                              <td style="text-align:left;"><asp:TextBox ID="txtGrossDiscount" runat="server"  Text="0" AutoPostBack="false"  CssClass="txtBox" Font-Bold="False"></asp:TextBox></td>
                              
                      </tr>
                      <tr>
                           <td style="text-align:right;">  <asp:Label ID="Label11" runat="server" CssClass="lbl" Text="Currancy"></asp:Label></td>  
                           <td style="text-align:left;">
                           <asp:DropDownList ID="ddlCurrency" runat="server" AutoPostBack="false" CssClass="ddList" Font-Bold="False"> </asp:DropDownList>
                           </td>

                            <td style="text-align:right;"><asp:Label ID="Label12" runat="server" CssClass="lbl" Text="Pay Date: "></asp:Label> </td> 
                            <td style="text-align:left;">
                            <asp:DropDownList ID="ddlDtePay" Enabled="false" runat="server" AutoPostBack="false" CssClass="ddList" Font-Bold="False">
                            </asp:DropDownList></td>
                          
                            <td style="text-align:right;"><asp:Label ID="Label13" runat="server" CssClass="lbl" Text="Commision: "></asp:Label></td> 
                            <td style="text-align:left;">
                            <asp:TextBox ID="txtCommosion" runat="server"  onkeyup="GetCommision(this);"  CssClass="txtBox"  AutoPostBack="false" Font-Bold="False">
                            </asp:TextBox><asp:Button ID="btnCommision" runat="server" Text="Set commission" Visible="false" /> </td> 
                       </tr>

                       <tr>
                        <td style="text-align:right;"> <asp:Label ID="Label14" runat="server" CssClass="lbl" Text="Po Date"></asp:Label> </td> 
                        <td style="text-align:left;"><asp:TextBox ID="txtdtePo" runat="server"  CssClass="txtBox" Font-Bold="False"> 
                        </asp:TextBox><cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy-MM-dd" TargetControlID="txtdtePo"></cc1:CalendarExtender> 
                        </td>
                        <td style="text-align:right;"><asp:Label ID="Label15" runat="server" CssClass="lbl" Text="AIT: "></asp:Label></td> 
                        <td  style="text-align:left;"><asp:TextBox ID="txtAit" runat="server" onkeyup="GetAIT(this);" Text="0" AutoPostBack="false" CssClass="txtBox" Font-Bold="False"> 
                        </asp:TextBox></td><td></td>
                        <td   style="text-align:right;"><asp:Button ID="btnGeneratePO" style=" background-color:#FFCC99; border-radius:1px; height:29px" runat="server" Text="Generate PO" OnClientClick="PoGenerateCheck();" OnClick="btnGeneratePO_Click" AutoPostBack="false" /></td>
                      </tr>
                      </table>
                     <table style="border-color:cornflowerblue; border-radius:10px; border:1px solid blue;">
                        <tr>
                        <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Service: "></asp:Label></td>  

                        <td style="text-align:left;"><asp:TextBox ID="txtItem" runat="server"    AutoPostBack="false" Width="300px" TextMode="MultiLine"  CssClass="txtBox" Font-Bold="False"></asp:TextBox> 
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtItem" 
                        ServiceMethod="GetPoItemSerach" MinimumPrefixLength="1" CompletionSetCount="1" 
                        CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig" 
                        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"> 
                        </cc1:AutoCompleteExtender></td>  

                        <td style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Description: "></asp:Label></td>  
                        <td style="text-align:left;"><asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"    Width="300px" AutoPostBack="false"  CssClass="txtBox" Font-Bold="False"></asp:TextBox></td>

                        </tr>
                        <tr>
                        <td style="text-align:right;"><asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Quantity: "></asp:Label></td>  
                        <td style="text-align:left;"><asp:TextBox ID="txtQantity" runat="server"  Text="0" AutoPostBack="false"  CssClass="txtBox" Font-Bold="False"></asp:TextBox></td>
                        <td style="text-align:right;"><asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Rate: "></asp:Label></td>  
                        <td style="text-align:left;"><asp:TextBox ID="txtRate" runat="server"  Text="0" AutoPostBack="false"  CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                         <asp:Button ID="btnAdd" BackColor="#0099ff" style=" background-color:#FFCC99; border-radius:1px; height:29px"  runat="server" Text="Add to PO" OnClick="btnAdd_Click" /> </td> 
                        </tr>
                     </table>
                      <table> 
                      <tr>
                          <td>
                              <asp:GridView ID="dgvIndentPrepare" runat="server" ShowFooter="true" OnRowDeleting="dgvIndentPrepare_RowDeleting"  AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" Font-Size="10px" FooterStyle-BackColor="#999999" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical">
                                  <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>
                                    <asp:TemplateField HeaderText="SL No.">
                                    <ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                    </asp:TemplateField> 

                                    <asp:TemplateField HeaderText="ItemId" SortExpression="itemId" >
                                    <ItemTemplate> <asp:Label ID="lblItemId" runat="server" Text='<%# Bind("itemId") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="45px" />                                   
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Item Name" SortExpression="strItem"><ItemTemplate> 
                                    <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("strItem") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="300px" />                                     
                                    </asp:TemplateField>
                                       
                                    <asp:TemplateField HeaderText="Description" ItemStyle-HorizontalAlign="right" SortExpression="strUom">
                                    <ItemTemplate> <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("strUom") %>'></asp:Label> </ItemTemplate> <ItemStyle HorizontalAlign="Right" Width="150px" />                                    
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="UOM" ItemStyle-HorizontalAlign="right" SortExpression="strDesc" Visible="true">
                                    <ItemTemplate> <asp:Label ID="lblUom" runat="server"   Text='<%# Bind("strDesc") %>'></asp:Label> </ItemTemplate><ItemStyle HorizontalAlign="Right" />                                    
                                    </asp:TemplateField>
                                     
                                   
                                    
                                      
                                    <asp:TemplateField HeaderText="Quantity" SortExpression="poQty">
                                    <ItemTemplate><asp:Label ID="lblQty" runat="server"    DataFormatString="{0:0.00}"  Text='<%# Bind("poQty") %>' Width="60px"></asp:Label>
                                    </ItemTemplate><ItemStyle HorizontalAlign="right" Width="60px" />
                                    <FooterTemplate><asp:Label ID="lblGrandTotalQty" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate></asp:TemplateField>

                                    <asp:TemplateField HeaderText="Rate" ItemStyle-HorizontalAlign="right" SortExpression="numPoRate">
                                    <ItemTemplate><asp:TextBox ID="txtRate" runat="server" CssClass="txtBox" DataFormatString="{0:0.00}"  Text='<%# Bind("numPoRate") %>'  Width="80px"></asp:TextBox>
                                    </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
                                    <FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text="" /></FooterTemplate></asp:TemplateField>

                                    <asp:TemplateField HeaderText="VAT" SortExpression="vat">
                                    <ItemTemplate><asp:TextBox ID="txtVAT" runat="server" CssClass="txtBox" DataFormatString="{0:0.00}" Text="0" Width="80px"></asp:TextBox>
                                    </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
                                    <FooterTemplate><asp:Label ID="lblGrandTotalVAT" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate></asp:TemplateField>

                                    <asp:TemplateField HeaderText="AIT" ItemStyle-HorizontalAlign="right" SortExpression="ait">
                                    <ItemTemplate><asp:TextBox ID="txtAIT" runat="server" DataFormatString="{0:0.00}" CssClass="txtBox" Width="80px" Text="0"></asp:TextBox>
                                    </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
                                    <FooterTemplate><asp:Label ID="lblGrandTotalAIT" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate></asp:TemplateField>

                                    <asp:TemplateField HeaderText="Total Value" ItemStyle-HorizontalAlign="right" SortExpression="total">
                                    <ItemTemplate><asp:Label ID="lblTotalVal" runat="server"   Text="0"></asp:Label>
                                    </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
                                    <FooterTemplate><asp:Label ID="lblGrandTotal" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate></asp:TemplateField>
                              
                                    <asp:CommandField HeaderText="Delete"    ShowDeleteButton="True" > 
                                    <ControlStyle ForeColor="Red" />
                                    </asp:CommandField>
                                    </Columns>
                                  <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                                  <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                  <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                              </asp:GridView> 
                          </td>
                      </tr>
                  </table>
                  <Table>
                      <tr>
                          <td><asp:Label ID="lblPartialShip" Text="Partial Shipment" runat="server" /></td>
                          <td><asp:DropDownList ID="ddlPartialShip" AutoPostBack="false" CssClass="ddList" runat="server">
                           <asp:ListItem Text="No" Value="0"></asp:ListItem><asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                           </asp:DropDownList></td> 
                          <td><asp:Label ID="lblNoOfShip" runat="server" Text="No of Shipment" /></td>
                          <td><asp:TextBox ID="txtNoOfShipment" runat="server" CssClass="txtBox" Text="1" /></td> 
                      </tr>
                       <tr>
                          <td><asp:Label ID="Label17" runat="server" Text="Last Shipment Date" /></td>
                          <td><asp:TextBox ID="txtLastShipmentDate" CssClass="txtBox" runat="server"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender4" runat="server"  Format="yyyy-MM-dd" TargetControlID="txtLastShipmentDate">
                          </cc1:CalendarExtender></td>
                          <td><asp:Label ID="Label18" runat="server" Text="Payment terms" /></td>
                          <td><asp:DropDownList ID="ddlPaymentTrams" AutoPostBack="false" CssClass="ddList" runat="server">
                          <asp:ListItem Text="Select" Selected="True" Value="0"></asp:ListItem>
                          <asp:ListItem Text="Credit" Value="1"></asp:ListItem><asp:ListItem Text="Advance" Value="2"></asp:ListItem>
                          <asp:ListItem Text="Cash" Value="3"></asp:ListItem> </asp:DropDownList></td>  
                      </tr>
                       <tr>
                          <td><asp:Label ID="Label19" runat="server" Text="Payment days after MRR" /></td>
                          <td><asp:TextBox ID="txtAfterMrrDay" CssClass="txtBox" runat="server" Text="7" /></td> 
                          <td><asp:Label ID="Label20" runat="server" Text="No of Installment" /></td>
                          <td><asp:TextBox ID="txtNoOfInstall" CssClass="txtBox" runat="server"  Text="1"/></td> 
                      </tr>
                       <tr>
                          <td><asp:Label ID="Label21" runat="server" Text="Installment Interval" /></td>
                          <td><asp:TextBox ID="txtIntervel" runat="server" CssClass="txtBox"  Text="0"/></td> 
                          <td><asp:Label ID="Label22" runat="server" Text="Delivery Destination" /></td>
                          <td><asp:TextBox ID="txtDestinationDelivery" CssClass="txtBox" runat="server" /></td> 
                      </tr>
                      <tr>
                          <td><asp:Label ID="Label23" runat="server" Text="No of Payment" /></td>
                          <td><asp:TextBox ID="txtNoOfPayment" runat="server" Text="0"  CssClass="txtBox"/></td> 
                          <td><asp:Label ID="Label24" runat="server" Text="Payment Schedule" /></td>
                          <td><asp:TextBox ID="txtPaymentSchedule" CssClass="txtBox" runat="server" /></td> 
                      </tr>
                       <tr>
                           <td><asp:Label ID="Label26" runat="server" Text="Warrenty (in months)" /></td>
                          <td><asp:TextBox ID="txtWarrenty" CssClass="txtBox" runat="server" /></td> 
                          <td><asp:Label ID="Label25" runat="server" Text="Others Trems" /></td>
                          <td><asp:TextBox ID="txtOthersTerms" runat="server"  Width="220px" TextMode="MultiLine"  CssClass="txtBox"/></td> 
                         
                      </tr>
                  </Table>
              </table>
     
        </div>
         

<%--=========================================End My Code From Here=================================================--%>

    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
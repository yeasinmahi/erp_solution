<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndentRFQ.aspx.cs" Inherits="UI.SCM.IndentRFQ" %>

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
    <script type="text/javascript">
       

        $("[id*=TxtNewPO]").live("change", function () {
            if (!jQuery.trim($(this).val()) == '') {
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                    var IssueQty = parseFloat($(this).val())
                    var StockQty = parseFloat($("[id*=lblRemaining]", row).html());
                    if (StockQty >= IssueQty) { 
                    }
                    else {
                        $("[id*=TxtNewPO]", row).val('0');
                        alert("Please Check Po Quantity");
                    }

                }
            }

             
        });



        <%-- Normal Textbox Onkey  Text Change Gridview row data  Calculation with ground Total --%>
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
            var paymentTremsId =e.options[e.selectedIndex].value;

            var noOfShipment = document.getElementById("txtNoOfShipment").value;
            var afterMrrDay = document.getElementById("txtAfterMrrDay").value;
            var destDelivery = document.getElementById("txtDestinationDelivery").value;
            var lastShipmentDte = document.getElementById("txtLastShipmentDate").value;
      
            if ($.trim(suppId) == 0 || $.trim(suppId) == "" || $.trim(suppId) == null || $.trim(suppId) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please select Suppliyer'); }
            else if ($.trim(currencyId) == 0 || $.trim(currencyId) == "" || $.trim(currencyId) == null || $.trim(currencyId) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please select Currency'); }
            else if ($.trim(paymentTremsId) == 0 || $.trim(paymentTremsId) == "" || $.trim(paymentTremsId) == null || $.trim(paymentTremsId) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please select PaymentTrems'); }
            else if ($.trim(noOfShipment) == 0 || $.trim(noOfShipment) == "" || $.trim(noOfShipment) == null || $.trim(noOfShipment) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please set Number of Shipment'); }
            else if ($.trim(afterMrrDay) == 0 || $.trim(afterMrrDay) == "" || $.trim(afterMrrDay) == null || $.trim(afterMrrDay) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please set After MRR Day'); }
            else if ($.trim(destDelivery).length <1 || $.trim(destDelivery) == "" || $.trim(destDelivery) == null || $.trim(destDelivery) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please set Destination Delivery'); }
            else if ($.trim(lastShipmentDte).length < 3 || $.trim(lastShipmentDte) == "" || $.trim(lastShipmentDte) == null || $.trim(lastShipmentDte) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please set Last Shipment Date'); }
            else {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnPreConfirm").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnPreConfirm").value = "0"; } 

               // document.getElementById("hdnPreConfirm").value = "1";
            }
             
           
        }
      
        function GetCommision(txt) {
          
                var row = $(this).closest("tr");
                var ait = parseFloat($("[id*=lblGrandTotalAIT]").html()); 
                $("[id*=lblGrandTotalAIT]").html(parseFloat(ait + parseFloat(txt.value)));
              

        }
      
        function GetAIT(txt) { 
            $("[id*=txtAIT]").each(function () {
                var row = $(this).closest("tr"); 
                var rate = parseFloat($("[id*=txtRate]", row).val());
                
                $("[id*=txtAIT]", row).val((rate * parseFloat(txt.value.toString())) / 100);
            });

            $("[id*=lblTotalVal]").each(function () { 
                var row = $(this).closest("tr");
                var a = parseFloat($("[id*=lblQty]", row).html());
                var b = parseFloat($("[id*=txtVAT]", row).val());
                var c = parseFloat($("[id*=txtAIT]", row).val());
                var e = parseFloat($("[id*=txtRate]", row).val());
                $("[id*=lblTotalVal]", row).html(a * (e + b + c)).toFixed(2);
            }); 

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
            $("[id*=lblGrandTotalQty]").html(parseFloat(grandTotalqty.toString()).toFixed(2));

            $("[id*=txtVAT]").each(function () {
                grandTotalVat = grandTotalVat + parseFloat($(this).val());
            });
            $("[id*=lblGrandTotalVAT]").html(grandTotalVat.toString());  
           
        }

        function Registration(url) {
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=900,top=50,left=230, close=no');
            if (window.focus) { newwindow.focus() }
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
   <!-- Global site tag (gtag.js) - Google Analytics -->
<script async src="https://www.googletagmanager.com/gtag/js?id=UA-125570863-1"></script>
<script>
  window.dataLayer = window.dataLayer || [];
  function gtag(){dataLayer.push(arguments);}
  gtag('js', new Date());
    gtag('config', 'UA-125570863-1');
</script>     

    

     <style type="text/css">
    .Initial
    {
    display: block;
    padding: 4px 18px 4px 18px;
    float: left;
    background: url("../Images/InitialImage.png") no-repeat right top;
    color: Black;
    font-weight: bold;
    }
    .Initial:hover
    {
    color: White;
    background:#eeeeee;
    }
    .Clicked
    {
    float: left;
    display: block;
    background:padding-box;
    padding: 4px 18px 4px 18px;
    color: Black;
    font-weight: bold;
    color:Green;
}
    .auto-style1 {
        width: 819px;
    }
</style> 
     <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .Textbox {}
        </style>
   
    </head>
   <body>
    <form id="frmaccountsrealize" runat="server"> 
    
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%;  height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
     <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnsearch" runat="server" /> 
         <asp:HiddenField ID="hdnUnitId" runat="server" /> <asp:HiddenField ID="hdnUnitName" runat="server" /> <asp:HiddenField ID="hdnWHId" runat="server" /> 
         <asp:HiddenField ID="hdnWHName" runat="server" />  <asp:HiddenField ID="hdnPreConfirm" runat="server" /> 
        <td><asp:Button Text="Indent View" BorderStyle="Solid" ID="Tab1" CssClass="Initial" runat="server"
        OnClick="Tab1_Click" BackColor="#FFCC99" />
        <asp:Button Text=" Indent Detail" BorderStyle="Solid" ID="Tab2" CssClass="Initial" runat="server"
        BackColor="#FFCC99" OnClick="Tab2_Click"/>
        
      
       <asp:Label ID="lblPoNo" runat="server" Font-Bold="true"    Font-Size="Medium"  ForeColor="#FFCC99"  ></asp:Label>
        

        <asp:MultiView ID="MainView"  runat="server">
            <asp:View ID="View1" runat="server" >
              <table style="width:80%; border-width: 1px; background-color:white;  border-color: #666; border-style: solid">
                  <table>
                      <tr>
                          <td colspan="3" style="text-align:right;"> <asp:Label ID="Label16" runat="server" CssClass="lbl" Text="Department"></asp:Label></td>  
                          <td style="text-align:left;">
                          <asp:DropDownList ID="ddlDepts" runat="server" AutoPostBack="true" CssClass="ddList" Font-Bold="False"> </asp:DropDownList></td>  
                      </tr>
                      <tr>
                          <td style="text-align:right;"> <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="WH-Name"></asp:Label></td>  
                          <td style="text-align:left;">
                          <asp:DropDownList ID="ddlWH" runat="server" AutoPostBack="true" CssClass="ddList" Font-Bold="False" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"> 
                          </asp:DropDownList></td> 

                            <td style="text-align:right;">  <asp:Label ID="LblDtePO" runat="server" CssClass="lbl" Text="From-Date : "></asp:Label></td>
                            <td> <asp:TextBox ID="txtDtefroms" runat="server" CssClass="txtBox"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDtefroms">
                            </cc1:CalendarExtender>

                            <td style="text-align:right;">  <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="To-Date : "></asp:Label>  
                            <td><asp:TextBox ID="txtDteTo" runat="server" CssClass="txtBox"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDteTo">
                            </cc1:CalendarExtender></td>
                                
                             <%-- </td>
                          </td>--%>
                      </tr>
                      <tr>
                          <td style="text-align:right;">
                              <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Indent No"></asp:Label>
                          </td>
                          <td style="text-align:left;">
                              <asp:TextBox ID="txtIndentNo" runat="server" AutoPostBack="true" CssClass="ddList" Font-Bold="False"></asp:TextBox>
                          </td>
                          <td>
                              <asp:Button ID="btnSearchIndent" runat="server"  Text="Search Indent" OnClick="btnSearchIndent_Click" />
                          </td>
                          <td colspan="3" style="text-align:right">
                              <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text="Show Indent" />
                          </td>
                      </tr>
                      <tr>
                          <td colspan="6">
                              <asp:GridView ID="dgvIndent" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" Font-Size="10px" FooterStyle-BackColor="#999999" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical">
                                  <AlternatingRowStyle BackColor="#CCCCCC" />
                                  <Columns>
                                      <asp:TemplateField HeaderText="SL No.">
                                          <ItemStyle HorizontalAlign="center" Width="60px" />
                                          <ItemTemplate>
                                              <%# Container.DataItemIndex + 1 %>
                                          </ItemTemplate>
                                      </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Unit" SortExpression="strUnit" Visible="false">
                                          <ItemTemplate>
                                              <asp:Label ID="lblItemId" runat="server" Text='<%# Bind("strUnit") %>'></asp:Label>
                                          </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Left" Width="45px" />
                                      </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Location" SortExpression="strWareHoseName">
                                          <ItemTemplate>
                                              <asp:Label ID="lblLocation" runat="server" Text='<%# Bind("strWareHoseName") %>'></asp:Label>
                                          </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Left" Width="100px" />
                                      </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Indent No" ItemStyle-HorizontalAlign="right" SortExpression="intIndentID">
                                          <ItemTemplate>
                                              <asp:Label ID="lblIndent" runat="server" Text='<%# Bind("intIndentID") %>'></asp:Label>
                                          </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Right" Width="60px" />
                                      </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Indent Date" ItemStyle-HorizontalAlign="right" SortExpression="dteIndentDate" Visible="true">
                                          <ItemTemplate>
                                              <asp:Label ID="lbldteIndent" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("dteIndentDate","{0:dd-MM-yyyy}") %>'></asp:Label>
                                          </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Right" />
                                      </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Approve Date" ItemStyle-HorizontalAlign="right" SortExpression="dteApproveDate">
                                          <ItemTemplate>
                                              <asp:Label ID="lbldteApprove" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("dteApproveDate","{0:dd-MM-yyyy}") %>'></asp:Label>
                                          </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Right" />
                                      </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Approved By" ItemStyle-HorizontalAlign="right" SortExpression="strName">
                                          <ItemTemplate>
                                              <asp:Label ID="lblApproveBy" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("strName") %>'></asp:Label>
                                          </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Left" Width="250px" />
                                      </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Due Date" ItemStyle-HorizontalAlign="right" SortExpression="dteDueDate">
                                          <ItemTemplate>
                                              <asp:Label ID="lbldteDue" runat="server" Text='<%# Bind("dteDueDate","{0:dd-MM-yyyy}") %>'></asp:Label>
                                          </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Right" />
                                      </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Detalis">
                                          <ItemTemplate>
                                              <asp:Button ID="btnIndentDet" runat="server" OnClick="btnIndentDetalis_Click" Text="Detalis" />
                                          </ItemTemplate>
                                          <ItemStyle HorizontalAlign="Left" Width="30px" />
                                      </asp:TemplateField>
                                  </Columns>
                                  <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                                  <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                  <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                              </asp:GridView>
                          </td>
                      </tr>
                  </table>
                  
              </table>
              </asp:View>

                <%--//Indent Detalis TAB--%> 
              <asp:View ID="View2" runat="server">
              <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
               <tr><td class="auto-style1"/>  
               <table> 
                   <tr> 
                    <td style="vertical-align:top"> 
               <table>
                <div >
                   <table> 
                      <tr style="text-align:center">
                       <td colspan="5" style="text-align:center"><asp:Label ID="lblIndentDetUnit" Font-Bold="true" Font-Size="Medium" runat="server" /></td> 
                      </tr>
                      <tr style="text-align:center"> 
                          <td colspan="5" style="text-align:center"><asp:Label ID="lblIndentDetWH" Font-Bold="true" runat="server" /></td> 
                      </tr> 
                      <tr>
                     <td style="text-align:right;"><asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Indent No"></asp:Label></td> 
                     <td style="text-align:left;"><asp:TextBox ID="txtIndentNoDet" CssClass="txtBox" Font-Bold="False" AutoPostBack="true" runat="server"></asp:TextBox>
                      <asp:Button ID="btnIndentDetShow" runat="server" Text="Show" OnClick="btnIndentDetShow_Click" /></td>  
                                                                                                          
                     
                      <td style="text-align:right;"><asp:Label ID="lblItem" CssClass="lbl" runat="server" Text="Item: "></asp:Label></td>
                     <td><asp:DropDownList ID="ddlItem" CssClass="ddList"  runat="server"></asp:DropDownList></td>
                     <td><asp:Button ID="btnAddItem" runat="server" Text="Add" OnClick="btnAddItem_Click" />&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button ID="btnPrepare" runat="server" Text="Prepare RFQ" OnClick="btnPrepare_Click" /></td>
                     </tr> 
                  
                    </table>
                  </div>
               </table> 
               </td>
               <td style="vertical-align:top"> 
                <table>
                  <div  style="display: inline-block">
                      <tr style="text-align:left"> 
                          <td>Indent Type :</td> <td><asp:Label ID="lblIndentType" runat="server"></asp:Label></td> 
                     </tr>
                      <tr style="text-align:left"> 
                          <td>Indent Date</td> <td><asp:Label ID="lblIndentDate" runat="server" /></td> 
                     </tr>
                      <tr style="text-align:left"><td>Approve Date :</td><td><asp:Label ID="lblindentApproveDate" runat="server" /></td></tr> 
                     
                       <tr><td>Due Date:</td> <td><asp:Label ID="lblInDueDate" runat="server" /></td></tr> 
                  </div>
              </table>
              </td>
              </tr>
                 
              </table> 
              </table>
               <table>
                        <tr> 
                        <td> 
                        <asp:GridView ID="dgvIndentDet" runat="server" AutoGenerateColumns="False" OnRowDeleting="dgvIndentDet_RowDeleting" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
                        BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" > 
                        <AlternatingRowStyle BackColor="#CCCCCC" /> 
                        <Columns> 
                        <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>  
                        <asp:TemplateField HeaderText="Indent Id" Visible="true" SortExpression="indentId"><ItemTemplate>  
                        <asp:Label ID="lblIndentId" runat="server" Text='<%# Bind("indentId") %>'></asp:Label></ItemTemplate> 
                        <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField> 

                        <asp:TemplateField HeaderText="Item Id" SortExpression="ItemId"><ItemTemplate> 
                        <asp:Label ID="lblItemId" runat="server" Text='<%# Bind("ItemId") %>'></asp:Label></ItemTemplate> 
                        <ItemStyle HorizontalAlign="Left" Width="70px"/></asp:TemplateField> 

                        <asp:TemplateField HeaderText="ItemName" ItemStyle-HorizontalAlign="right" SortExpression="strItem" > 
                        <ItemTemplate><asp:Label ID="lblItemName" runat="server"  Text='<%# Bind("strItem") %>'></asp:Label></ItemTemplate> 
                        <ItemStyle HorizontalAlign="left" Width="200px" /> </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Uom" ItemStyle-HorizontalAlign="right" Visible="true" SortExpression="strUom" > 
                        <ItemTemplate><asp:Label ID="lblUom" runat="server"  Text='<%# Bind("strUom") %>'  ></asp:Label></ItemTemplate> 
                        <ItemStyle HorizontalAlign="Right" /></asp:TemplateField> 

                        <asp:TemplateField HeaderText="HS Code" ItemStyle-HorizontalAlign="right" SortExpression="strHsCode" > 
                        <ItemTemplate><asp:Label ID="lblHsCode" runat="server"  Text='<%# Bind("strHsCode") %>'></asp:Label></ItemTemplate> 
                        <ItemStyle HorizontalAlign="Right" />  </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Purpose" ItemStyle-HorizontalAlign="right" SortExpression="strDesc" > 
                        <ItemTemplate><asp:Label ID="lblPurpose" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("strDesc") %>'></asp:Label></ItemTemplate> 
                        <ItemStyle HorizontalAlign="Left" Width="200px"/></asp:TemplateField> 

                        <asp:TemplateField HeaderText="Current Stock" ItemStyle-HorizontalAlign="right" SortExpression="numCurStock" > 
                        <ItemTemplate><asp:Label ID="lblCurrentStock" runat="server"  Text='<%# Bind("numCurStock") %>'></asp:Label></ItemTemplate> 
                        <ItemStyle HorizontalAlign="Right" Width="50px" /> </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Safty Stock" ItemStyle-HorizontalAlign="right" Visible="true" SortExpression="numSafetyStock" > 
                        <ItemTemplate><asp:Label ID="lblSaftyStock" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("numSafetyStock") %>'  ></asp:Label></ItemTemplate> 
                        <ItemStyle HorizontalAlign="Right" Width="50px" /></asp:TemplateField> 

                        <asp:TemplateField HeaderText="Indent Qty" ItemStyle-HorizontalAlign="right" SortExpression="numIndentQty" > 
                        <ItemTemplate><asp:Label ID="lblIndentQty" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("numIndentQty") %>'></asp:Label></ItemTemplate> 
                        <ItemStyle HorizontalAlign="Right" Width="50px" />  </asp:TemplateField> 

                        <asp:TemplateField HeaderText="PO Issue" ItemStyle-HorizontalAlign="right" SortExpression="numPoIssued" > 
                        <ItemTemplate><asp:Label ID="lblPoIssue" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("numPoIssued") %>'></asp:Label></ItemTemplate> 
                        <ItemStyle HorizontalAlign="Left"  /></asp:TemplateField> 

                        <asp:TemplateField HeaderText="Remain" ItemStyle-HorizontalAlign="right" SortExpression="numRemain" > 
                        <ItemTemplate><asp:Label ID="lblRemaining" runat="server"  Text='<%# Bind("numRemain") %>'></asp:Label></ItemTemplate> 
                        <ItemStyle HorizontalAlign="Right" /> </asp:TemplateField> 

<%--                        <asp:TemplateField HeaderText="Specification" ItemStyle-HorizontalAlign="right" SortExpression="strSpecification" > 
                        <ItemTemplate><asp:TextBox ID="txtSpecification" runat="server" DataFormatString="{0:0.00}" TextMode="MultiLine" Text='<%# Bind("strSpecification") %>'></asp:TextBox></ItemTemplate> 
                        <ItemStyle HorizontalAlign="Right" Wrap="true" />  </asp:TemplateField> --%>

                        <asp:TemplateField HeaderText="New RFQ" ItemStyle-HorizontalAlign="right" SortExpression="numNewPo" > 
                        <ItemTemplate><asp:TextBox ID="TxtNewPO" runat="server" Width="40px"   CssClass="txtBox" Text='<%# Bind("numNewPo") %>'></asp:TextBox></ItemTemplate> 
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Previous Avg" ItemStyle-HorizontalAlign="right" Visible="false" SortExpression="monPreviousRate" > 
                        <ItemTemplate><asp:Label ID="lblPreviousAvg" runat="server"  Text='<%# Bind("monPreviousRate","{0:n2}") %>'></asp:Label></ItemTemplate> 
                        <ItemStyle HorizontalAlign="Right" Width="50px"  /> </asp:TemplateField> 

                        <asp:TemplateField HeaderText="Ask Q" Visible="false" ItemStyle-HorizontalAlign="right"  > 
                        <ItemTemplate><asp:Label ID="lblAskQ" runat="server" Text='0'></asp:Label></ItemTemplate> 
                        <ItemStyle HorizontalAlign="Right" /> </asp:TemplateField> 
                        <asp:CommandField HeaderText="Delete"   ShowDeleteButton="True" > 
                        <ControlStyle ForeColor="Red" />
                        </asp:CommandField>
                     
                           
                        </Columns> 
                        <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" /> 
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" /> 
                        </asp:GridView>
                        </td>
                    </tr>
                </table>
               </tr> 
            </asp:View>

               <%--//Po Prepare TAB--%> 
            
              <%--//Po Generate TAB--%> 
         
          </asp:MultiView>
      
            </div>
         
    
              
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

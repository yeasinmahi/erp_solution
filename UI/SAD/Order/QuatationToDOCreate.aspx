<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuatationToDOCreate.aspx.cs" Inherits="UI.SAD.Order.QuatationToDOCreate" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, heigth=device-heigth, initial-scale=1.0, user-scalable=yes" />
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference4" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../../../Content/CSS/GridHEADER.css" rel="stylesheet" />
    <script src="../../../../Content/JS/JQUERY/jquery-1.10.2.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/jquery-ui.min.js"></script>
    <script src="../../../../Content/JS/datepickr.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/MigrateJS.js"></script>
    <script src="../../../../Content/JS/JQUERY/GridviewScroll.min.js"></script>

    <script type="text/javascript">
        function SaveValidationBasicInfo() {
            document.getElementById("hdnconfirm").value = "0";
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to Save?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
            else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
        }

    </script>


    <script type="text/javascript">
        function Calculate() {
            var si = 0;
            var grid = document.getElementById("<%= grdvQuationDetails.ClientID%>");

            for (var i = 0; i < grid.rows.length - 1; i++) {
                var rate = parseFloat($("[id*=rate]", row).val());
                var nqty = parseFloat($(this).val());
                if (nqty != '') {
                    si = si + (rate * nqty);
                }
            }
            $('#lblTOAmount').val(si);
            $('#hdnodramt').val(si);
        }
       
            $(document).ready(function () {
                $("#grdvQuationDetails").on("change", "[id*=txtquantity]", function () {
                    if (!jQuery.trim($(this).val()) == '') {

                        if (!isNaN(parseFloat($(this).val()))) {
                            var row = $(this).closest("tr");
                        
                            var row = $(this).closest("tr");
                         
                            var rate = parseFloat($("[id*=hdnnumprice]", row).val());
                            var bqty = parseFloat($("[id*=hdnnumqnt]", row).val());
                            var nqty = parseFloat($(this).val());
                            var msg = "Orginal Order Qty Over";
                           
                            if (nqty > bqty) {
                                $("[id*=txtquantity]", row).val((bqty));
                                var msg = "Orginal Order Qty Over";

                                //alert(msg);

                            }
                            else {
                                if (rate != "NAN" && nqty!= "NAN")
                                {
                                    alert('Rate' + rate + 'Qty' + nqty)
                                    $("[id*=lblAmounts]", row).html((rate * nqty).toFixed(2));
                                }
                               
                            }
                            //$("[id*=lblTotalqty]", row).html(((free / UOM) * qty) + qty);

                        }
                    } else {
                        $(this).val('');
                    }
                    var grandTotalqty = 0;
                    var grndupdateqnt = 0;



                    $("[id*=lblAmounts]").each(function () {
                        grandTotalqty = grandTotalqty + parseFloat($(this).html());
                    });

                     $("[id*=hdnnumqnt]").each(function () {
                        grndupdateqnt = grndupdateqnt + parseFloat($(this).html());
                    });

                    
                    //alert(grandTotalqty)
                    $("[id*=lblfinalamount]").html(parseFloat(grandTotalqty.toString()).toFixed(2));
                       //$("[id*=lblupdateqnt]").html(parseFloat(grndupdateqnt.toString()).toFixed(2));
                   // $('#txtTotalAmount').val(grandTotalqty).html(parseFloat(grandTotalqty.toString()).toFixed(2));

                    
                });

            });
        
    </script>

    <script>
           function CloseWindow() { window.close(); window.onbeforeunload = RefreshParent(); }
           function RefreshParent() {
               if (window.opener != null && !window.opener.closed) {
                   window.opener.location.reload();
               }
           }
        </script>

    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="hfcustomerid" runat="server" />
            <asp:HiddenField ID="hdnconfirm" runat="server" />
            <asp:HiddenField ID="hdnstation" runat="server" />
            <asp:HiddenField ID="hdnavlabl" runat="server" />
            <asp:HiddenField ID="hdnLog" runat="server" />
            <asp:HiddenField ID="hdnodramt" runat="server" />
            <asp:HiddenField ID="hdnDiscountP" runat="server" />


            <div class="container">
                <div class="panel panel-info">
                    <div class="panel-heading">
                      
                        
                    </div>
                  


                </div>
                <div>
                   
                   


                    <table style="width:700px; text-align:left; height:100px" align="center">
           
           
      
            
            <tr>
                <td style="width:500px; font-size:17px;text-align:center; background-color:lightgrey; font-weight:bold;" colspan="7"> </td>
            </tr>
            <tr style="font-size:10px; background-color:#F0F0FF;">
                <td style="width:120px; font-size:12px; font-weight:bold;">
                                                                                Order Number:</td>
                <td colspan="2" style="width:300px; font-size:12px; font-weight:bold;">
                    <asp:Label ID="lblordernumberval" runat="server"></asp:Label>
                </td>               
                <td  style="text-align:center; font-size:11px;">
                   <asp:Label ID="lblFaxnAME" runat="server" Text="Customer Name:" Visible="true" ></asp:Label>
                </td>
                <td  style="text-align:center; font-size:11px;">
                  <asp:Label ID="lblcustval" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="font-size:10px; background-color:#E0E0E0;">
                <td>
                                        Date</td>
                <td colspan="2">
                       <asp:Label ID="lblqotdateval" CssClass="lbl" runat="server"></asp:Label>
                </td>
                
                <td>
                                      Credit Limit</td>
                <td>
                     <asp:Label ID="lblcreditlmval" runat="server"></asp:Label></td>
            </tr>
            <tr style="font-size:10px; background-color:#F0F0FF;">
                <td>
                                      Pending Amount</td>
                <td colspan="2">
                     <asp:Label ID="lblPendingamount" runat="server"></asp:Label>
                </td>
                
                <td>
                                      Available Balance</td>
                <td>
                    <asp:Label ID="lbloutstandingval" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="font-size:10px; background-color:#E0E0E0;">
                <td>
                                        Remarks</td>
                <td colspan="2">
                   <asp:Label ID="lblspecificationval" runat="server"></asp:Label>
                </td>                
                <td>
                                        Total Amount</td>
                <td>
                     <asp:Label ID="lbltotamounval" runat="server"></asp:Label>
            </tr>
           <tr style="font-size:10px; background-color:#E0E0E0;">
                <td>
                                        Created D.O </td>
                <td colspan="2">
                   <asp:Label ID="lblDo" runat="server"></asp:Label>
                </td>                
                <td>
                                       </td>
                <td>
                     <asp:Label ID="Label2" runat="server"></asp:Label>
            </tr>
           
            <tr>
               <td style="width:500px; font-size:15px;text-align:center; text font-weight:bold;" colspan="5">Pending Quotation Detaills </td>      
            </tr>
            <tr>
                <td class="auto-style1">
                    </td>
                <td class="auto-style1">
                     <asp:Label ID="lblupdateqnt" Visible="false" runat="server"></asp:Label>
                    </td>
                <td class="auto-style1">
                    </td>
                <td class="auto-style1">
                    Grand Total Amount</td>
                <td class="auto-style1">
                    <asp:Label ID="lblfinalamount" runat="server"></asp:Label></td>
            </tr>
             <tr>
                <td class="auto-style1">
                   
                    </td>
                <td class="auto-style1">
                   
                    </td>
                <td class="auto-style1">
                    </td>
                <td class="auto-style1">
                    </td>
                <td class="auto-style1">
                    </td>
            </tr>
        </table>








                </div>


                <div>
                    <div>
                        <asp:GridView ID="grdvQuationDetails" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="100%"  ForeColor="#333333" GridLines="Both"  Font-Size="12px" OnRowDataBound="grdvQuationDetails_RowDataBound">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                  <asp:TemplateField HeaderText="Product ID" HeaderStyle-HorizontalAlign="Center"  SortExpression="IntOrderNumber">
                                    <ItemTemplate>
                                       
                                        <asp:Label ID="lblProductID" runat="server" Text='<%# Bind("intprdid") %>'></asp:Label>
                                    </ItemTemplate>
                                   
                                </asp:TemplateField>

                               
                                 <asp:TemplateField HeaderText="Product Name"  HeaderStyle-HorizontalAlign="Center" SortExpression="strProductName">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdnprdname" runat="server" Value='<%# Eval("prdname") %>' />
                                       
                                        <asp:Label ID="lblprdname" runat="server" Text='<%# Bind("prdname") %>'></asp:Label>
                                    </ItemTemplate>
                                    
                                </asp:TemplateField>
                       


                               <%-- <asp:TemplateField HeaderText="Customer Name" HeaderStyle-HorizontalAlign="Center" SortExpression="intCustid">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdnstrName" runat="server" Value='<%# Eval("strName") %>' />
                                       <asp:HiddenField ID="hdncustid" runat="server" Value='<%# Eval("intCustomerId") %>' />
                                         <asp:HiddenField ID="hdnitemid" runat="server" Value='<%# Eval("intprdid") %>' />
                                          <asp:HiddenField ID="hdnpkid" runat="server" Value='<%# Eval("intid") %>' />
                                         <asp:HiddenField ID="hdnstrTermsNCondition" runat="server" Value='<%# Eval("strTermsNCondition") %>' />
                                        <asp:HiddenField ID="hdnintShipPointId" runat="server" Value='<%# Eval("intShipPointId") %>' />
                                         <asp:HiddenField ID="hdnintSalesOffId" runat="server" Value='<%# Eval("intSalesOffId") %>' />
                                       

                                        <asp:Label ID="lblstrName" runat="server" Text='<%# Bind("strName") %>'></asp:Label>
                                    </ItemTemplate>
                                  
                                </asp:TemplateField>--%>

                                 <asp:TemplateField HeaderText="Specifiation" HeaderStyle-HorizontalAlign="Center" SortExpression="intCustid">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdnstrName" runat="server" Value='<%# Eval("strName") %>' />
                                       <asp:HiddenField ID="hdncustid" runat="server" Value='<%# Eval("intCustomerId") %>' />
                                         <asp:HiddenField ID="hdnitemid" runat="server" Value='<%# Eval("intprdid") %>' />
                                          <asp:HiddenField ID="hdnpkid" runat="server" Value='<%# Eval("intid") %>' />
                                         <asp:HiddenField ID="hdnstrTermsNCondition" runat="server" Value='<%# Eval("strTermsNCondition") %>' />
                                        <asp:HiddenField ID="hdnintShipPointId" runat="server" Value='<%# Eval("intShipPointId") %>' />
                                         <asp:HiddenField ID="hdnintSalesOffId" runat="server" Value='<%# Eval("intSalesOffId") %>' />
                                       

                                        <asp:Label ID="lbllblstrName" runat="server" Text='<%# Bind("strTermsNCondition") %>'></asp:Label>
                                    </ItemTemplate>
                                  
                                </asp:TemplateField>



                               

                                <asp:TemplateField HeaderText="Rate" HeaderStyle-HorizontalAlign="Center" SortExpression="strProductName">
                                    <ItemTemplate>
                                        <%--<asp:HiddenField ID="hdnnumprice" runat="server" Value='<%# Eval("numprice", "{0:0.0}") %>' />--%>
                                          <asp:HiddenField ID="hdnnumprice" runat="server" Value='<%# Bind("numprice", "{0:0.0}") %>'></asp:HiddenField>  
                                        <asp:Label ID="lblnumprice" runat="server" Text='<%# Bind("numprice", "{0:0.0}") %>'></asp:Label>
                                    </ItemTemplate>
                                  
                                </asp:TemplateField>



                                <asp:TemplateField HeaderText="Quantity" HeaderStyle-HorizontalAlign="Center"  SortExpression="Quantity">
                                    <ItemTemplate>
                                     
                                        <asp:HiddenField ID="hdnnumqnt" runat="server" Value='<%# Bind("numqnt", "{0:0.0}") %>'></asp:HiddenField>  
                                   <asp:Label ID="lbltotalqnt" runat="server" Visible="false" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("numqnt", "{0:0.00}"))) %>'></asp:Label>

                                        <asp:TextBox ID="txtquantity"  runat="server" onblur="" CssClass="txtBox" Width="75px" TextMode="Number" Text='<%# Bind("numqnt", "{0:0}") %>' AutoPostBack="false"></asp:TextBox>
                                     </ItemTemplate>
                                
                                </asp:TemplateField>

                               <asp:TemplateField HeaderText="Order Amount" HeaderStyle-HorizontalAlign="Center" SortExpression="MRRValue">
                                <ItemTemplate><asp:Label ID="lblAmounts" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("montotal", "{0:0.00}"))) %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="right" Width="40px" /><FooterTemplate>
                                <asp:Label ID="lblATqty" runat="server" DataFormatString="{0:0.00}" Text='<%# TotalOrderAmounts %>' /></FooterTemplate>
                                </asp:TemplateField>

                                
                                 <asp:TemplateField HeaderText="Quatation Number" HeaderStyle-HorizontalAlign="Center" Visible="false" SortExpression="IntOrderNumber">
                                    <ItemTemplate>
                                       
                                        <asp:Label ID="IntOrderNumber" runat="server" Text='<%# Bind("intid") %>'></asp:Label>
                                    </ItemTemplate>
                                   
                                </asp:TemplateField>

                       

         
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                        
                        
                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary pull-right"  Text="Submit" OnClick="btnSubmit_Click" />
                    </div>
                    
                </div>
                
            </div>

            
        </div>
    </form>
</body>
</html>


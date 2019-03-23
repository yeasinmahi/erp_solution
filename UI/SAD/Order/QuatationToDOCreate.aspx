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
                $("#grdvQuationDetails").on("change", "[id*=Quantity1]", function () {
                    if (!jQuery.trim($(this).val()) == '') {

                        if (!isNaN(parseFloat($(this).val()))) {
                            var row = $(this).closest("tr");
                        
                            var row = $(this).closest("tr");
                         
                            var rate = parseFloat($("[id*=rate]", row).val());
                            var bqty = parseFloat($("[id*=hdnQty]", row).val());
                            var nqty = parseFloat($(this).val());
                            var msg = "Orginal Order Qty Over";
                            var Disamt = document.getElementById("hdnDiscountP").value;
                            if (nqty > bqty) {
                                $("[id*=Quantity1]", row).val((bqty));
                                var msg = "Orginal Order Qty Over";

                                alert(msg);

                            }
                            else {

                                $("[id*=lblAmounts]", row).html((rate * nqty).toFixed(2));
                                $("[id*=lblDiscount]", row).html((((rate * nqty)) * Disamt).toFixed(2));
                            }
                            //$("[id*=lblTotalqty]", row).html(((free / UOM) * qty) + qty);

                        }
                    } else {
                        $(this).val('');
                    }
                    var grandTotalqty = 0;
                    var grandTotalDiscount = 0;



                    $("[id*=lblAmounts]").each(function () {
                        grandTotalqty = grandTotalqty + parseFloat($(this).html());
                    });

                    // $("[id*=lblAmounts]").html(parseFloat(grandTotalqty.toString()).toFixed(2));
                    $('#txtTotalAmount').val(grandTotalqty).html(parseFloat(grandTotalqty.toString()).toFixed(2));

                    $("[id*=lblDiscount]").each(function () {
                        grandTotalDiscount = grandTotalDiscount + parseFloat($(this).html());
                    });

                    $('#lblTotalDiscount').val(grandTotalDiscount).html(parseFloat(grandTotalDiscount.toString()).toFixed(2));

                    $('#lblFinalOrderamount').val((grandTotalqty - grandTotalDiscount)).html(parseFloat((grandTotalqty - grandTotalDiscount).toString()).toFixed(2));

                });

            });
        
    </script>

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
                        <asp:Label runat="server" Text="DO Create" Font-Bold="true" Font-Size="16px"></asp:Label>
                        <asp:Label runat="server" ID="lblDo" Font-Bold="true" Font-Size="16px" CssClass="pull-right" ForeColor="blue"></asp:Label>
                    </div>
                  


                </div>
                <div>
                    <table>
                        <tr>
                       

                             <td>
                                <asp:Label ID="Label4" CssClass="lbl" runat="server" Text="Order Number"></asp:Label>
                            </td>
                            <td>
                               <asp:Label ID="lblordernumberval" runat="server"></asp:Label>
                            </td>

                        <td>
                                 <asp:Label ID="Label8" CssClass="lbl" runat="server" Text="Customer Name"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblcustval" runat="server"></asp:Label>
                            </td>

                        </tr>
                     

                        <tr>
                     

                             <td>
                              <asp:Label ID="lblqotdate" CssClass="lbl" runat="server" Text="Date"></asp:Label>
                            </td>
                            <td>
                              <asp:Label ID="lblqotdateval" CssClass="lbl" runat="server"></asp:Label>
                            </td>

                             <td>
                                  <asp:Label ID="Label12" CssClass="lbl" runat="server" Text="Credit Limit"></asp:Label>
                            </td>
                            <td>
                              <asp:Label ID="lblcreditlmval" runat="server"></asp:Label>
                            </td>

                        </tr>

                           <tr>
                            <td>
                                <asp:Label ID="Label14" CssClass="lbl" runat="server" Text="Due Delevary Amount"></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lblPendingamount" runat="server"></asp:Label>
                            </td>

                             <td>
                           <asp:Label ID="Label15" CssClass="lbl" runat="server" Text="Available Balance"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lbloutstandingval" runat="server"></asp:Label>
                            </td>

                         

                        </tr>

                           <tr>
                       

                             <td>
                          <asp:Label ID="Label16" CssClass="lbl" runat="server" Text="Remarks"></asp:Label>
                            </td>
                            <td>
                              <asp:Label ID="lblspecificationval" runat="server"></asp:Label>
                            </td>

                           <td>
                                 <asp:Label ID="lbltoatalamount" runat="server" Text="Total Amount"></asp:Label>
                            </td>
                            <td>
                                 <asp:Label ID="lbltotamounval" runat="server"></asp:Label>
                            </td>
                    

                        </tr>

                    </table>
                   
                </div>


                <div>
                    <div>
                        <asp:GridView ID="grdvQuationDetails" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="100%"  ForeColor="#333333" GridLines="Both"  Font-Size="12px" OnRowDataBound="grdvQuationDetails_RowDataBound">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="Quatation Number" HeaderStyle-HorizontalAlign="Center" SortExpression="IntOrderNumber">
                                    <ItemTemplate>
                                       
                                        <asp:Label ID="IntOrderNumber" runat="server" Text='<%# Bind("intid") %>'></asp:Label>
                                    </ItemTemplate>
                                   
                                </asp:TemplateField>

                       


                                <asp:TemplateField HeaderText="Customer Name" HeaderStyle-HorizontalAlign="Center" SortExpression="intCustid">
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
                                  
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Product Name"  HeaderStyle-HorizontalAlign="Center" SortExpression="strProductName">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdnprdname" runat="server" Value='<%# Eval("prdname") %>' />
                                       
                                        <asp:Label ID="lblprdname" runat="server" Text='<%# Bind("prdname") %>'></asp:Label>
                                    </ItemTemplate>
                                    
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Rate" HeaderStyle-HorizontalAlign="Center" SortExpression="strProductName">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdnnumprice" runat="server" Value='<%# Eval("numprice", "{0:0.0}") %>' />
                                        <asp:Label ID="lblnumprice" runat="server" Text='<%# Bind("numprice", "{0:0.0}") %>'></asp:Label>
                                    </ItemTemplate>
                                  
                                </asp:TemplateField>



                                <asp:TemplateField HeaderText="Quantity" HeaderStyle-HorizontalAlign="Center"  SortExpression="Quantity">
                                    <ItemTemplate>
                                     
                                        <asp:HiddenField ID="hdnnumqnt" runat="server" Value='<%# Bind("numqnt", "{0:0.0}") %>'></asp:HiddenField>                                     
                                        <asp:TextBox ID="txtquantity"  runat="server" onblur="" CssClass="txtBox" Width="75px" TextMode="Number" Text='<%# Bind("numqnt", "{0:0}") %>' AutoPostBack="false"></asp:TextBox>
                                     </ItemTemplate>
                                
                                </asp:TemplateField>

                               <asp:TemplateField HeaderText="Order Amount" HeaderStyle-HorizontalAlign="Center" SortExpression="MRRValue">
                                <ItemTemplate><asp:Label ID="lblAmounts" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("montotal", "{0:0.00}"))) %>'></asp:Label></ItemTemplate>
                                <ItemStyle HorizontalAlign="right" Width="40px" /><FooterTemplate>
                                <asp:Label ID="lblATqty" runat="server" DataFormatString="{0:0.00}" Text='<%# TotalOrderAmounts %>' /></FooterTemplate>
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


<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="PoDetalisView.aspx.cs" Inherits="UI.SCM.PoDetalisView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    
    <%--<link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />

   

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>

    <script src="../Content/JS/BlueBird.min.js"></script>
    <script src="../Content/JS/html2canvas.min.js"></script>
    --%>
   <%-- <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/html2canvas/0.4.1/html2canvas.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.0.272/jspdf.debug.js"></script>--%>

    <script src="../Content/JS/jquery-3.3.1.js"></script>
    <script src="../Content/JS/html2canvas.js"></script>
    <script src="../Content/JS/jsPDF.js"></script>
    <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />
    <%--    <script src="../Content/JS/jsPDF.min.js"></script>--%>
    <%--<script src="../Content/JS/html2pdf.js"></script>--%>

    <%-- <script type="text/javascript">
        
        function pdf() { 
        //document.getElementById("btnEmail").style.visibility = "hidden";
        //document.getElementById("txtPoNumbers").style.visibility = "hidden";
        //document.getElementById("btnPoShowByView").style.visibility = "hidden";
        //document.getElementById("btnDownload").style.visibility = "hidden"; 
        //document.getElementById("btnPDF").style.visibility = "hidden";

        html2canvas(document.getElementById('dvTable'), { 
        onrendered: function(canvas) {

            var img = canvas.toDataURL('image/png',1.0)
            var doc = new jsPDF('p', 'pt', 'A4');
            // var doc = new jsPDF();
            
            //doc.addImage(img, "JPEG", 0, 0,100,100);
            
            
        
            doc.addImage(img, 'JPEG', 0, 0);
            doc.save("PurchaseOrder.pdf")

        
            }

            });
            
        }
    </script>--%>
    <script src="https://unpkg.com/jspdf@latest/dist/jspdf.min.js"></script>
    <script type="text/javascript">
        function ConvertToImage(btnEmail) {
            document.getElementById("btnEmail").style.visibility = "hidden";
            document.getElementById("txtPoNumbers").style.visibility = "hidden";
            document.getElementById("btnPoShowByView").style.visibility = "hidden";
            document.getElementById("btnDownload").style.visibility = "hidden";

            html2canvas($("#dvTable")[0]).then(function (canvas) {
                var base64 = canvas.toDataURL();
                $("[id*=hfImageData]").val(base64);
                __doPostBack(btnEmail.name, "");
                document.getElementById("btnEmail").style.visibility = "visible";
                document.getElementById("txtPoNumbers").style.visibility = "visible";
                document.getElementById("btnPoShowByView").style.visibility = "visible";
                document.getElementById("btnDownload").style.visibility = "visible";
            });
            return false;
        }
        function DownloadPDF() {
            document.getElementById("btnEmail").style.visibility = "hidden";
            document.getElementById("btnprint").style.visibility = "hidden";
            document.getElementById("btnDownload").style.visibility = "hidden";
            document.getElementById("btnPDF").style.visibility = "hidden";
            html2canvas($("#dvTable"),
                {
                    onrendered: function(canvas) {
                        //var data1 = document.getElementById('dvTable').innerHTML;
                        var doc = new jsPDF();
                        
                        console.log(canvas);

                        doc.addHTML(document.getElementById("dvTable"),
                            function() {
                                doc.save('PurchaseOrder.pdf');
                            });
                        document.getElementById("btnEmail").style.visibility = "visible";
                        document.getElementById("btnDownload").style.visibility = "visible";
                        document.getElementById("btnprint").style.visibility = "visible";
                        document.getElementById("btnPDF").style.visibility = "visible";
                    }
                });
            return true;
        }
    </script>


    <script type="text/javascript">
        function ConvertToImageDownload(btnDownload) {
            document.getElementById("btnEmail").style.visibility = "hidden";
            document.getElementById("btnprint").style.visibility = "hidden";
            //document.getElementById("txtPoNumbers").style.visibility = "hidden";
            // document.getElementById("btnPoShowByView").style.visibility = "hidden";
            document.getElementById("btnDownload").style.visibility = "hidden";

            html2canvas($("#dvTable")[0]).then(function (canvas) {
                var base64 = canvas.toDataURL();
                $("[id*=hfImageData]").val(base64);
                __doPostBack(btnDownload.name, "");
                document.getElementById("btnEmail").style.visibility = "visible";
                //   document.getElementById("txtPoNumbers").style.visibility = "visible";
                //  document.getElementById("btnPoShowByView").style.visibility = "visible";
                document.getElementById("btnDownload").style.visibility = "visible";
                document.getElementById("btnprint").style.visibility = "visible";
            });
            return false;
        }
    </script>

    <script type="text/javascript"> 
        function funConfirmAll() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnConfirm").value = "1"; }
            else { confirm_value.value = "No"; document.getElementById("hdnConfirm").value = "0"; }
        }

    </script>
    <script>
        function Print() {
            document.getElementById("btnEmail").style.visibility = "hidden";
            document.getElementById("btnDownload").style.visibility = "hidden";

            document.getElementById("btnprint").style.display = "none"; window.print();
            document.getElementById("btnEmail").style.visibility = "visible";
            document.getElementById("btnDownload").style.visibility = "visible";

        }
    </script>

</head>
<body>
    <form id="frmselfresign" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </asp:Panel>

               <%-- <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>--%>

                <%--=========================================Start My Code From Here===============================================--%>

                <div style="text-align: left">PO Approval  From<hr />
                </div>
                <asp:HiddenField ID="hfImageData" runat="server" />

                <div id="dvTable" runat="server" style="width: 750px; background-color: white; padding-left: 50px; padding-right: 50px; padding-top: 10px; padding-bottom: 20px;">
               
                    <table style="width: 700px">
                        <tr>
                            <td colspan="2" style="text-align: center; font: bold 13px verdana;"><a id="btnprint" href="#" class="nextclick" style="cursor: pointer" onclick="Print()">Print</a></td>
                        </tr>

                        <tr>

                            <td>
                                <asp:Image ID="imgUnit" runat="server" /></td>
                            <td style="text-align: center; font-size: medium; font-weight: bold;">
                                <asp:Label ID="lblUnitName" runat="server" Text="Akij Food & Beverage" Font-Underline="true"></asp:Label></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="text-align: center">Akij House, 198 Bir Uttam Mir Shawkat Sharak, Gulshan Link Road, Tejgaon, Dhaka-1208</td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="text-align: center">
                                <asp:Label ID="lblDetaliss" runat="server" Font-Size="Small" Font-Underline="true" Font-Bold="true" Text="Purchase Order"></asp:Label></td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                    </table>
                    <table style="width: 700px">
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPurchaseOrderNo" runat="server" Text="Purchase Order No:"></asp:Label><asp:Label ID="lblpoNo" Font-Bold="true" Font-Size="Small" runat="server"></asp:Label><asp:Label ID="lblspace" runat="server"></asp:Label><asp:Label ID="lblPoDate" Font-Bold="true" runat="server"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtPoNumbers" runat="server" CssClass="txtBox" Visible="false" PlaceHolder="PO" Width="50px" /></td>
                            <td>
                                <asp:Button ID="btnPoShowByView" Visible="false" CssClass="btnButton" runat="server" Text="Show" OnClick="btnPoShowByView_Click" /></td>
                            <td>
                                <asp:Button ID="btnEmail" Text="E-mail" runat="server"  OnClick ="btnEmail_OnClick" /></td>
                            <td>
                                <asp:Button ID="btnDownload" Text="Download" runat="server" UseSubmitBehavior="false" OnClick="btnDownload_Click" OnClientClick="return ConvertToImageDownload(this)" /></td>
                            <td>
                                <asp:Button ID="btnPDF" Text="HD PDF" Visible="False" runat="server" OnClick="btnPDF_OnClick"  /></td>

                        </tr>
                    </table>
                    <table style="border-color: black; width: 700px; border-radius: 10px; border: 1px solid blue;">
                        <tr>
                            <td style="text-align:left; width:10px">Supplier</td>
                            <td style="text-align:left">Ship TO</td>
                            <td style="text-align:left; ">Bill To</td>
                        </tr>
                        <tr>
                            <td style="text-align:left"><asp:Label ID="lblSuppliyers" runat="server" Font-Bold="true"></asp:Label></td>                     
                            <td style="text-align:left"><asp:Label ID="lblShipTo" Width="200px" runat="server" Font-Bold="true"></asp:Label></td>
                            <td style="text-align:left"><asp:Label ID="lblBillTo"  Width="250px" runat="server"></asp:Label></td>                      
                        </tr>

                        <tr>
                            <td style="text-align: left">
                                <asp:Label ID="lblSupEmail" Width="200px" runat="server"></asp:Label></td>
                            <td></td>
                            <td style="text-align: left;">
                                <asp:Label ID="Label1" Width="200px" Text="Akij House, 198 Bir Uttam Mir Shawkat Sharak, Gulshan Link Road, Tejgaon, Dhaka-1208" runat="server"></asp:Label></td>
                        </tr>

                        <tr>
                            <td style="text-align: left">
                                <asp:Label ID="lblAtten" Width="200px" runat="server"></asp:Label></td>
                        </tr>

                        <tr>
                            <td style="text-align: left">
                                <asp:Label ID="lblPhone" Width="200px" runat="server"></asp:Label></td>
                        </tr>

                        <tr>
                            <td style="text-align: left">
                                <asp:Label ID="lblSuppAddress" Width="300px" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                    <table style="width: 750px">
                        
                        <tr>
                            <td><asp:GridView ID="dgvPoDetalis" runat="server" AutoGenerateColumns="False" Font-Size="11px" Width="750px" ShowFooter="true"   
                                              BorderWidth="1px" CssClass="GridWithPrint" CellPadding="5" GridLines="Vertical" FooterStyle-HorizontalAlign="Right" > 
                                    <AlternatingRowStyle BackColor="#CCCCCC" /> 
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL No.">
                                            <ItemStyle HorizontalAlign="center" Width="60px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Item Name" SortExpression="strName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("strName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="220px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Description" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="strSpecification">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescription" BorderColor="Black" runat="server" Text='<%# Bind("strSpecification") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" Width="110px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="UOM" ItemStyle-HorizontalAlign="right" SortExpression="strUoM">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUom" runat="server" Text='<%# Bind("strUoM") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Shipment" ItemStyle-HorizontalAlign="right" SortExpression="intShipmentSL">
                                            <ItemTemplate>
                                                <asp:Label ID="lblShipment" runat="server" Text='<%# Bind("intShipmentSL") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Qty." ItemStyle-HorizontalAlign="right" SortExpression="numQty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblnumQty" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("numQty") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Rate" ItemStyle-HorizontalAlign="right" SortExpression="monRate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRate" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("monRate") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="VAT" ItemStyle-HorizontalAlign="right" SortExpression="monVAT">
                                            <ItemTemplate>
                                                <asp:Label ID="lblVat" runat="server" Text='<%# Bind("monVAT") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="AIT" ItemStyle-HorizontalAlign="right" SortExpression="monAIT">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAIT" runat="server" Text='<%# Bind("monAIT") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" Width="50px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="right" SortExpression="monAmount">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPoTotalAmount" runat="server" Text='<%# Bind("monAmount") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                    </Columns>
                                    <FooterStyle BackColor="Gray" Font-Bold="True" HorizontalAlign="Right" ForeColor="Black" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" /><PagerStyle BackColor="Gray" ForeColor="Red" HorizontalAlign="Center" /> 
            
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblInWard" Font-Bold="true" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                      <td style="text-align:left;border: 1px solid gray;">Partial Shipment</td>
                      <td style="text-align:left;border: 1px solid gray;"><asp:Label ID="lblPartialShip" Width="100px" runat="server"></asp:Label></td>
                      <td></td><td></td>
                      <td style="text-align:right;border: 1px solid gray">Trnsport Charge:</td>
                      <td style="text-align:left;border: 1px solid gray"><asp:Label ID="lblTransportCharge" Width="100px" runat="server"></asp:Label></td>
                  </tr>
                  <tr>
                      <td style="text-align:left;border: 1px solid gray">No of Shipment</td>
                      <td style="text-align:left;border: 1px solid gray"><asp:Label ID="lblNoShipment" Width="100px" runat="server"></asp:Label></td>
                      <td></td><td></td>
                      <td style="text-align:right;border: 1px solid gray">Others Charge:</td>
                      <td style="text-align:left;border: 1px solid gray"><asp:Label ID="lblOthersCharge" runat="server" Width="100px"></asp:Label></td>
                  </tr>
                  <tr>
                      <td style="text-align:left;border: 1px solid gray">Last Shipment Date</td>
                      <td style="text-align:left;border: 1px solid gray"><asp:Label ID="lbllastShipmentDate" Width="100px" runat="server"></asp:Label></td>
                      <td></td><td></td>
                      <td style="text-align:right;border: 1px solid gray">Gross Disscount:</td>
                      <td style="text-align:left;border: 1px  inset gray"><asp:Label ID="lblGrossDis" runat="server" Width="100px"></asp:Label></td>
                  </tr>
                  <tr>
                      <td style="text-align:left;border: 1px solid gray">Payment terms</td>
                      <td style="text-align:left;border: 1px solid gray"><asp:Label ID="lblPaymentTrems" runat="server"  ></asp:Label></td>
                      <td></td><td></td>
                      <td style="text-align:right;border: 1px solid gray">Comission:</td>
                      <td style="text-align:left;border: 1px solid gray"><asp:Label ID="lblComission" runat="server" Width="100px"></asp:Label></td>
                  </tr>
                  <tr>
                      <td style="text-align:left;border: 1px solid gray">Payment days after MRR (days)</td>
                      <td style="text-align:left;border: 1px solid gray"><asp:Label ID="lblPaymentDaysMrr" runat="server"></asp:Label></td>
                      <td></td><td></td>
                      <td style="text-align:right;border: 1px solid gray">Grand Total:</td>
                      <td style="text-align:left;border: 1px solid gray"><asp:Label ID="lblGrandTotal" runat="server" Width="100px" Font-Bold="true"></asp:Label></td>
                  </tr>
                  <tr>
                      <td style="text-align:left;border: 1px solid gray">No of Installment</td>
                      <td style="text-align:left;border: 1px solid gray"><asp:Label ID="lblNoOfInstallment" runat="server"></asp:Label></td>
                  </tr> 
                  <tr>
                      <td style="text-align:left;border: 1px solid gray">Installment Interval (Days)</td>
                      <td style="text-align:left;border: 1px solid gray"><asp:Label ID="lblIntervelDay" runat="server"></asp:Label></td>
                  </tr>
                  <tr>
                      <td style="text-align:left;border: 1px solid gray">Warrenty after delivery (months)</td>
                      <td style="text-align:left;border: 1px solid gray"><asp:Label ID="lblDeliveryMonth" runat="server"></asp:Label></td>
                  </tr>

                    </table>
                    <table>
                        <tr>
                            <td>Others Terms:</td>
                        </tr>
                        <tr>

                            <td style="text-align: left;">
                                <asp:Label ID="lblOthersterms" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPrepareBy" Font-Bold="true" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblApprovedBy" Font-Bold="true" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" Font-Bold="true" Text="For your any query please call our Toll Free Number : 08000016609  " runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </div>

                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

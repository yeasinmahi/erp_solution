<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PoDetalisView.aspx.cs" Inherits="UI.SCM.PoDetalisView" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />
    <link href="../Content/CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/CSS/toastr.min.css" rel="stylesheet" />

    <script src="../Content/JS/jquery-3.3.1.js"></script>
    <script src="../Content/JS/bootstrap.min.js"></script>

    <script src="../Content/JS/html2canvas.js"></script>
    <script src="../Content/JS/jsPDF.js"></script>
    <script src="../Content/JS/toastr.min.js"></script>
    <script src="../Content/JS/ui-toastr.min.js"></script>
    <script src="../Content/JS/StaticFunction.js"></script>
    <script src="../Content/JS/BlueBird.min.js"></script>
    <script type="text/javascript">
        function ConvertToImage(btn) {
            document.getElementById("btnEmail").style.visibility = "hidden";
            document.getElementById("btnprint").style.visibility = "hidden";
            document.getElementById("btnDownload").style.visibility = "hidden";

            html2canvas($("#dvTable")[0]).then(function (canvas) {
                var base64 = canvas.toDataURL();
                $("[id*=hfImageData]").val(base64);
                __doPostBack(btn.name, "");
                document.getElementById("btnEmail").style.visibility = "visible";
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
            document.getElementById("btnprint").style.display = "none";
            window.print();
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
                <asp:Label runat="server" ID="lblNotification"></asp:Label>
                <asp:HiddenField ID="hfImageData" runat="server" />

                <div id="dvTable" runat="server" style="width: 850px; background-color: white; padding-left: 50px; padding-right: 50px; padding-top: 10px; padding-bottom: 20px;">

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
                                <asp:Button ID="btnEmail" Text="E-mail" runat="server" OnClick="btnEmail_OnClick" OnClientClick="return ConvertToImage(this)" /></td>
                            <td>
                                <asp:Button ID="btnDownload" Text="Download" runat="server" UseSubmitBehavior="false" OnClick="btnDownload_Click" OnClientClick="return ConvertToImage(this)" /></td>
                        </tr>
                    </table>
                    <table style="border-color: black; width: 700px; -ms-border-radius: 10px; border-radius: 10px; border: 1px solid black; border-collapse: unset; padding: 10px;">
                        <tr>
                            <td style="text-align: left; width: 10px">Supplier</td>
                            <td style="text-align: left">Ship TO</td>
                            <td style="text-align: left;">Bill To</td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <asp:Label ID="lblSuppliyers" runat="server" Font-Bold="true"></asp:Label></td>
                            <td style="text-align: left">
                                <asp:Label ID="lblShipTo" Width="200px" runat="server" Font-Bold="true"></asp:Label></td>
                            <td style="text-align: left">
                                <asp:Label ID="lblBillTo" Width="250px" runat="server"></asp:Label></td>
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
                    <table style="width: 770px">

                        <tr>
                            <td>
                                <asp:GridView ID="dgvPoDetalis" runat="server" AutoGenerateColumns="False" Font-Size="11px" Width="770px" ShowFooter="true"
                                    BorderWidth="1px" CssClass="GridWithPrint" CellPadding="5" GridLines="Vertical" HeaderStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Right">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL">
                                            <ItemStyle HorizontalAlign="center" Width="20px" />
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
                                                <asp:Label ID="lblDescription"  runat="server" Text='<%# Bind("strSpecification") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" Width="110px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="UOM" ItemStyle-HorizontalAlign="Center" SortExpression="strUoM">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUom" runat="server" Text='<%# Bind("strUoM") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Shipment" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblShipment" runat="server" Text='<%# Bind("intShipmentSL") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Qty." ItemStyle-HorizontalAlign="right" SortExpression="numQty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblnumQty" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("numQty") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Rate" ItemStyle-HorizontalAlign="right" SortExpression="monRate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRate" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("monRate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="VAT" ItemStyle-HorizontalAlign="right" SortExpression="monVAT">
                                            <ItemTemplate>
                                                <asp:Label ID="lblVat" runat="server" Text='<%# Bind("monVAT") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="AIT" ItemStyle-HorizontalAlign="right" SortExpression="monAIT">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAIT" runat="server" Text='<%# Bind("monAIT") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" Width="50px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="right" SortExpression="monAmount">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPoTotalAmount" runat="server" Text='<%# Bind("monAmount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right"/>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="Gray" Font-Bold="True" HorizontalAlign="Right" ForeColor="Black" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" />
                                    <PagerStyle BackColor="Gray" ForeColor="Red" HorizontalAlign="Center" />
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
                    <table class="detailstable">
                        <tr>
                            <td >Partial Shipment</td>
                            <td >
                                <asp:Label ID="lblPartialShip" Width="100px" runat="server"></asp:Label></td>
                            <td >Trnsport Charge</td>
                            <td >
                                <asp:Label ID="lblTransportCharge" Width="100px" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td >No of Shipment</td>
                            <td >
                                <asp:Label ID="lblNoShipment" Width="100px" runat="server"></asp:Label></td>
                            <td >Others Charge</td>
                            <td >
                                <asp:Label ID="lblOthersCharge" runat="server" Width="100px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td >Last Shipment Date</td>
                            <td >
                                <asp:Label ID="lbllastShipmentDate" Width="100px" runat="server"></asp:Label></td>
                            <td >Gross Disscount</td>
                            <td style="text-align: left; border: 1px  inset gray">
                                <asp:Label ID="lblGrossDis" runat="server" Width="100px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td >Payment terms</td>
                            <td >
                                <asp:Label ID="lblPaymentTrems" runat="server"></asp:Label></td>
                            <td >Comission</td>
                            <td >
                                <asp:Label ID="lblComission" runat="server" Width="100px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td >Payment days after MRR (days)</td>
                            <td >
                                <asp:Label ID="lblPaymentDaysMrr" runat="server"></asp:Label></td>
                            <td >Grand Total</td>
                            <td >
                                <asp:Label ID="lblGrandTotal" runat="server" Width="100px" Font-Bold="true"></asp:Label></td>
                        </tr>
                        <tr>
                            <td >No of Installment</td>
                            <td >
                                <asp:Label ID="lblNoOfInstallment" runat="server"></asp:Label></td>
                             
                        </tr>
                        <tr>
                            <td >Installment Interval (Days)</td>
                            <td >
                                <asp:Label ID="lblIntervelDay" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td >Warrenty after delivery (months)</td>
                            <td >
                                <asp:Label ID="lblDeliveryMonth" runat="server"></asp:Label></td>
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
                <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="exampleModal" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <div class="row">
                                    <div class="col-md-4 col-sm-4">
                                        <h5>New message</h5>
                                    </div>
                                    <div class="col-md-8 col-sm-8">
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-body">
                                <form>
                                    <div class="form-group row">
                                        <div class="col-md-2 col-sm-2">
                                            <p>To: </p>
                                        </div>
                                        <div class="col-md-10 col-sm-10">
                                            <asp:TextBox runat="server" ID="txtReceipentEmail" Width="100%" type="text" name="search" placeholder="Enter sender e-mail" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-md-2 col-sm-2">
                                            <p>CC: </p>
                                        </div>
                                        <div class="col-md-10 col-sm-10">
                                            <asp:TextBox runat="server" ID="txtCc" Width="100%" type="text" name="search" placeholder="Enter CC e-mail" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-md-2 col-sm-2">
                                            <p>BCC: </p>
                                        </div>
                                        <div class="col-md-10 col-sm-10">
                                            <asp:TextBox runat="server" ID="txtBcc" Width="100%" type="text" name="search" placeholder="Enter BCC e-mail" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-md-2 col-sm-2">
                                            <p>Subject: </p>
                                        </div>
                                        <div class="col-md-10 col-sm-10">
                                            <asp:TextBox runat="server" ID="txtSubject" type="text" Width="100%" name="search" placeholder="Enter subject" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-md-2 col-sm-2">
                                            <p>Message: </p>
                                        </div>
                                        <div class="col-md-10 col-sm-10">
                                            <asp:TextBox runat="server" ID="txtBody" TextMode="MultiLine" Width="100%" class="form-control" placeholder="Enter Body here ..." Rows="6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-md-2 col-sm-2">
                                            <p>Attachments: </p>
                                        </div>
                                        <div class="col-md-10 col-sm-10">
                                            <asp:Image ID="imgAttachment" CssClass="img-thumbnail image pull-left" runat="server" AlternateText="Po Image" Height="100px" Width="100px" />
                                        </div>
                                    </div>
                                </form>
                            </div>
                            <div class="modal-footer">
                                <%--<button class="btn btn-primary pull-left" id="btn_file">
                                <span class="fa fa-paperclip fa-2x"></span>
                                <input type="file" id="file" style="display: none;" />
                            </button>--%>

                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                <asp:Button runat="server" CssClass="btn btn-primary" Text="Send" ID="btnSent" OnClick="btnSent_OnClick" />
                            </div>
                        </div>
                    </div>
                </div>
                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnSent" />
            </Triggers>
        </asp:UpdatePanel>
        <script type="text/javascript">
            function openModal() {
                $('#myModal').modal('show');
            }
            function closeModal() {
                $('#myModal').modal('hide');
            }
        </script>
    </form>
</body>
</html>
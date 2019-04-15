<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MrrStatementDetalis.aspx.cs" Inherits="UI.SCM.MrrStatementDetalis" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

    <script src="../Content/JS/BlueBird.min.js"></script>
    <script src="../Content/JS/html2canvas.min.js"></script>
    <script>
        function Print() {
            document.getElementById("btnprint").style.display = "none";
            window.print();
            self.close();
        }
    </script>

    <style type="text/css">
        .auto-style2 {
            height: 23px;
        }
    </style>
</head>
<body>

    <form id="frmLoanSummaryPrint" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>

        <%--=========================================Start My Code From Here===============================================--%>
        <div id="dvTable" style="width: auto; background-color: white; padding-left: 50px; padding-right: 50px; padding-top: 10px; padding-bottom: 20px;">
            <asp:HiddenField ID="hfImageData" runat="server" />
            <table style="width: 700px">
                <tr>
                    <td colspan="3" style="text-align: center; font: bold 13px verdana;">
                        <a id="btnprint" href="#" class="nextclick" style="cursor: pointer" onclick="Print()">Print</a>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Image ID="imgUnit" runat="server" /></td>
                    <td style="text-align: center; font-size: medium; font-weight: bold;" class="auto-style2">
                        <asp:Label ID="lblUnitName" runat="server" Text="Akij Group" Font-Underline="true"></asp:Label></td>
                </tr>
                <tr>
                    <td></td>
                    <td style="text-align: center">
                        <asp:Label ID="lblWH" Font-Size="Small" Font-Bold="true" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td></td>
                    <td style="text-align: center;">
                        <asp:Label ID="lblDetalis" runat="server" Font-Bold="true" Font-Underline="true" Font-Size="Small" Text="Material Receive Report"></asp:Label></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblInd" runat="server" Text="Challan No:"></asp:Label><asp:Label ID="lblChallan" runat="server"></asp:Label></td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Challan Date Type:"></asp:Label><asp:Label ID="lblChallanDate" runat="server"></asp:Label></td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Supplier Name:"></asp:Label><asp:Label ID="lblSupplier" Font-Size="small" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="MRR No:"></asp:Label><asp:Label ID="lblMrrNo" runat="server"></asp:Label></td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="MRR Date:"></asp:Label><asp:Label ID="lblMrrDate" runat="server"></asp:Label></td>
                </tr>
            </table>

            <table style="width: 800px">
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="dgvMrrDetlais" runat="server" AutoGenerateColumns="False" Font-Size="10px" Width="800px" ShowFooter="true" BackColor="White" BorderColor="#999999"
                            BorderWidth="1px" CellPadding="5" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" OnRowDataBound="dgvMrrDetlais_OnRowDataBound">

                            <Columns>
                                <asp:TemplateField HeaderText="SL No.">
                                    <ItemStyle HorizontalAlign="center" Width="30px" />
                                    <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ID" SortExpression="intItemID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemID" runat="server" Text='<%# Bind("intItemID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="70px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Item Description" SortExpression="strName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("strName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="220px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="UOM" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="strUOM">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUOM" runat="server" Text='<%# Bind("strUOM") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="PO Quantity" ItemStyle-HorizontalAlign="right" SortExpression="numPOQty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblnumQty" runat="server" Text='<%# Bind("numPOQty","{0:n2}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Receive Quantity" ItemStyle-HorizontalAlign="right" SortExpression="numReceiveQty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRecQty" runat="server" Text='<%# Bind("numReceiveQty","{0:n2}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Rate" ItemStyle-HorizontalAlign="right" SortExpression="monFCRate">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRate" runat="server" Text='<%# Bind("monFCRate","{0:n2}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="left" />
                                    <FooterTemplate>
                                        <asp:Label runat="server" Text="Total:"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Amount(BDT)" ItemStyle-HorizontalAlign="right" SortExpression="monBDTTotal">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("monBDTTotal","{0:n2}") %>'></asp:Label>
                                    </ItemTemplate>

                                    <ItemStyle HorizontalAlign="left" />
                                    <FooterTemplate>
                                        <asp:Label runat="server" ID="lblTotalAmount" ></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Remarks" ItemStyle-HorizontalAlign="right" SortExpression="strReceiveRemarks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("strReceiveRemarks") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>MRR By:</td>
                    <td>
                        <asp:Label ID="lblMrrBy" Font-Bold="true" runat="server"></asp:Label></td>
                </tr>
            </table>
        </div>

        <%--=========================================End My Code From Here=================================================--%>
    </form>
</body>
</html>
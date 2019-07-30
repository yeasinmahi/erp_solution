<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VoucherPrint.aspx.cs" Inherits="UI.Accounts.Advice.VoucherPrint" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Print Voucher</title>

    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/printCSS" />
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <script type="text/javascript">        
        function Print() {
            Show();
            window.print();
            self.close();
        }
        function Show() {
            var dv = document.getElementById("print");
            dv.style.display = "block";

            dv = document.getElementById("btn");
            dv.style.display = "none";
        }
    </script>

    <!-- Global site tag (gtag.js) - Google Analytics -->
    <script async src="https://www.googletagmanager.com/gtag/js?id=UA-125570863-1"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());
        gtag('config', 'UA-125570863-1');
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div id="btn" style="text-align: center;">
            <a href="#" onclick="Print()"><b>Print</b></a>
        </div>
        <div id="divExport" style="overflow: auto;">
            <table style="width: 100%">
                <tr>
                    <td style="text-align: center" valign="top" width="10%">
                        <asp:Image ID="Image2" runat="server" />
                        &nbsp;
                    </td>
                    <td style="text-align: center" valign="top" width="60%">
                       <div>
                           <table>
                               <tr>
                                    <td style="font-weight: bold; text-decoration: underline; font-size: 22px; color: #000000; text-align: center;width="60%"">
                                        <asp:Label ID="lblUnitName" runat="server"></asp:Label>
                                    </td>
                               </tr>
                               <tr>
                                <td colspan="3" style="font-weight: bold; text-decoration: underline; font-size: 18px; color: #000000; text-align: center">
                                    <asp:Label ID="lblUnitAddress" runat="server"></asp:Label></td>
                            </tr>
                               <tr>
                                <td style="font-weight: bold; font-size: 15px; color: #000000; text-align: left">
                                    <asp:Label ID="lblTo" runat="server" Text="To"></asp:Label></td>
                            </tr>
                           </table>
                       </div>
                    
                    </td>
                     <td style="text-align: center" valign="top" width="60%">
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <table style="width: 100%">
                
                <tr>
                      <td style="font-weight: bold; font-size: 15px; color: #000000; text-align: left">
                                    <asp:Label ID="lblManager" runat="server" Text="The Manager"></asp:Label>
                      </td>
                </tr>
                <tr>
                       <td style="font-size: 15px; color: #000000; text-align: left">
                                    <asp:Label ID="lblBankName" runat="server"></asp:Label>

                       </td>
                </tr>
                            <tr>
                                <td style="font-size: 15px; color: #000000; text-align: left">
                                    <asp:Label ID="lblBankAddress" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; font-size: 15px; color: #000000; text-align: left">
                                    <asp:Label ID="lblSubject" runat="server" Text="<u>Subject : Payment Instruction by BEFTN.</u>"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; font-size: 15px; color: #000000; text-align: left">
                                    <asp:Label ID="lblDearSir" runat="server" Text="Dear Sir,"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; font-size: 15px; color: #000000; text-align: left">
                                    <asp:Label ID="lblMailBody" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; font-size: 15px; color: #000000; text-align: left">
                                    <asp:Label ID="lblDetails" runat="server" Text="Detailed particulars of each Account Holder :"></asp:Label></td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:GridView ID="dgvAdvice" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" Font-Size="10px" FooterStyle-BackColor="#999999" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" ShowFooter="true"
                                        OnRowDataBound="dgvAdvice_RowDataBound">
                                        <AlternatingRowStyle BackColor="#CCCCCC" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="ID No" ItemStyle-HorizontalAlign="right" SortExpression="intID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("intID") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Account Name" SortExpression="strSupplier">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAccountName" runat="server" Text='<%# Bind("strSupplier") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="220px" />
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTTText" runat="server" Text="Total :"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Code No" ItemStyle-HorizontalAlign="Center" SortExpression="intSuppID" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCodeNo" runat="server" Text='<%# Bind("intSuppID") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Bank Name" ItemStyle-HorizontalAlign="Center" SortExpression="strBankName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBankName" runat="server" Text='<%# Bind("strBankName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Branch" ItemStyle-HorizontalAlign="Center" SortExpression="strBranchName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBranch" runat="server" Text='<%# Bind("strBranchName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="A/C Type" ItemStyle-HorizontalAlign="Center" SortExpression="strAccType">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblACType" runat="server" Text='<%# Bind("strAccType") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Account No" ItemStyle-HorizontalAlign="Center" SortExpression="strBankAccountNo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAccountNo" runat="server" Text='<%# Bind("strBankAccountNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="Center" SortExpression="monVoucher">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("monVoucher", "{0:0,0.00}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" />
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTTTotal" runat="server"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Payment Info" ItemStyle-HorizontalAlign="Center" SortExpression="strPaymentInfo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPaymentInfo" runat="server" Text='<%# Bind("strPaymentInfo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Comments" ItemStyle-HorizontalAlign="Center" SortExpression="strcomments">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblComments" runat="server" Text='<%# Bind("strcomments") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Routing No" ItemStyle-HorizontalAlign="Center" SortExpression="strRoutingNumber">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRoutingNo" runat="server" Text='<%# Bind("strRoutingNumber") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Instrument No" ItemStyle-HorizontalAlign="Center" SortExpression="intInstrumentNo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInstrumentNo" runat="server" Text='<%# Bind("intInstrumentNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="SL No" ItemStyle-HorizontalAlign="Center" SortExpression="intSlNo" >
                                                <ItemTemplate>
                                                    <%--<asp:Label ID="lblSLNo" runat="server" Text='<%# Bind("intSlNo") %>'></asp:Label>--%>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Debit Account" ItemStyle-HorizontalAlign="Center" >
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDebitAcc" runat="server" ></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Mail" ItemStyle-HorizontalAlign="right" SortExpression="strOrgMail" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMail" runat="server" Text='<%# Bind("strOrgMail") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="PO NO" ItemStyle-HorizontalAlign="right" SortExpression="strPO" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPONo" runat="server" Text='<%# Bind("strPO") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Bill No" ItemStyle-HorizontalAlign="right" SortExpression="strBillID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBillNo" runat="server" Text='<%# Bind("strBillID") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="BPVoucher" ItemStyle-HorizontalAlign="right" SortExpression="strCode" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBPVoucher" runat="server" Text='<%# Bind("strCode") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="PO Issuer Mail" ItemStyle-HorizontalAlign="right" SortExpression="strPoIssuerMail" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPOIssuerMail" runat="server" Text='<%# Bind("strPoIssuerMail") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>

                                        </Columns>
                                        <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 10px"></td>
                            </tr>

                            <tr>
                                <td style="font-weight: bold; font-size: 15px; color: #000000; text-align: left">
                                    <asp:Label ID="lblWord" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="height: 30px"></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; font-size: 18px; color: #000000; text-align: left" class="auto-style1">
                                    <asp:Label ID="lblForUnit" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="height: 70px"></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; font-size: 15px; color: #000000; text-align: left">
                                    <asp:Label ID="lblAuth1" runat="server" Text="Authorize Signature"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblAuth2" runat="server" Text="Authorize Signature"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblAuth3" runat="server" Text="Authorize Signature"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; font-size: 15px; color: #000000; text-align: left">&nbsp;</td>
                            </tr>
            </table>
            <asp:HiddenField ID="HdnValue" runat="server" />
        </div>
    </form>
</body>
</html>

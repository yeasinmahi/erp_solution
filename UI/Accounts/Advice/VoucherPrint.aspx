<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VoucherPrint.aspx.cs" Inherits="UI.Accounts.Advice.VoucherPrint" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Print Voucher</title>

    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/printCSS" />
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <style>
        .topBorder {
            border-top: 1px solid black;
        }

        .auto-style1 {
            width: 900px;
        }

        .auto-style2 {
            height: 24px;
        }
    </style>
    <style type="text/css" media="print">
          @page 
          {
            size: auto;  
            margin: 0;  
          }
    </style>
    <script type="text/javascript">        
        function Print() {
            Show();
            window.print();
            //self.close();
        }
        function Show() {
            var dv = document.getElementById("divExport");
            dv.style.display = "block";

            //dv = document.getElementById("btn");
            //dv.style.display = "none";
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
        <div id="btn" style="text-align: center; width:650px;">
            <a href="#" onclick="Print()"><b>Print</b></a>
        </div>
        <div id="divExport" style="overflow: auto; font-size:10px;">
            <table style="width: 650px;">
                <tr>
                   
                                    <td style="font-weight: bold; text-decoration: underline; font-size: 16px; color: #000000; text-align: center;width="60%"">
                                        <asp:Label ID="lblUnitName" runat="server"></asp:Label>
                                    </td>
                                </tr>
                               <tr>
                                <td colspan="3" style="font-weight: bold; text-decoration: underline; font-size: 11px; color: #000000; text-align: center" class="auto-style2">
                                    <asp:Label ID="lblUnitAddress" runat="server"></asp:Label></td>
                            </tr>
                           
              
          
                <tr>
                                <td style="font-weight: bold; font-size: 11px; color: #000000; text-align: center;">
                                    <div style="width:100%;"><asp:Label ID="lblTo" runat="server" Text="Debit Voucher (Bank)"></asp:Label></div></td>
                            </tr>
                <tr>
                      <td style="font-weight: bold; font-size: 11px; color: #000000; text-align: center">
                                    <div style="width:100%;"><asp:Label ID="lblaccDetails" runat="server"></asp:Label></div></td>
                </tr>
                <tr>
                       <td style="font-size: 11px; color: #000000; text-align: left">
                                    <asp:Label ID="lblBankName" runat="server"></asp:Label>

                       </td>
                </tr>
                            <tr>
                                <td style="font-size: 11px; color: #000000; text-align: left">
                                    <asp:Label ID="lblBankAddress" runat="server"></asp:Label></td>
                            </tr>
        
                            <tr>
                                <td style=" font-size: 11px; color: #000000; text-align: left">
                                   <div style="width:50%; float:left;"><asp:Label ID="lblIntrumentNo" runat="server"></asp:Label></div> 
                                   <div style="width:50%; float:left;"><asp:Label ID="lblVoucherNo" runat="server"></asp:Label></div>  
                                </td>                                
                            </tr>
                 <tr>
                                <td style=" font-size: 11px; color: #000000; text-align: left">
                                   <div style="width:50%; float:left;"><asp:Label ID="lblIntrumentDate" runat="server"></asp:Label></div> 
                                   <div style="width:50%; float:left;"><asp:Label ID="lblVoucherDate" runat="server"></asp:Label></div>  
                                </td>                                
                            </tr>
                            <tr>
                                <td style="font-weight: bold; font-size: 11px; color: #000000; text-align: left">
                                    &nbsp;</td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:GridView ID="dgvAdvice" runat="server" AutoGenerateColumns="False" Font-Size="11px" FooterStyle-BackColor="#999999" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ShowFooter="True" OnRowDataBound="dgvAdvice_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Account Code No" ItemStyle-HorizontalAlign="Center" SortExpression="intSuppID" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCodeNo" runat="server" Text='<%# Bind("strCode") %>' Width="100"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Head of Accounts" SortExpression="strAccName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAccountName" runat="server" Text='<%# Bind("strAccName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="280px" />
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTTText" runat="server" Text="Total :"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Sub-Account" ItemStyle-HorizontalAlign="Center" SortExpression="monVoucher">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSAccount" runat="server" Text='<%# Eval("monAmountSub", "{0:0,0.00}") %>' Width="100"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" />
                                                <FooterTemplate>
                                                    <asp:Label ID="lblSTotal" runat="server"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Control-Account" ItemStyle-HorizontalAlign="Center" SortExpression="monVoucher">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCAccount" runat="server" Text='<%# Eval("monAmountControl", "{0:0,0.00}") %>' Width="100"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" />
                                                <FooterTemplate>
                                                    <asp:Label ID="lblCTotal" runat="server"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>


                                        </Columns>
                                        <FooterStyle HorizontalAlign="Right" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 10px"></td>
                            </tr>

                            <tr>
                                <td style="font-weight: bold; font-size: 11px; color: #000000; text-align: left">
                                    <asp:Label ID="lblMoneyToWord" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="height: 30px"></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; font-size: 11px; color: #000000; text-align: left" class="auto-style1">
                                    <asp:Label ID="lblDescription" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="height: 70px"></td>
                            </tr>
                            <tr>
                                <td colspan="2" style=" font-size: 11px; color: #000000; text-align: left">
                                    <asp:Label ID="lblAuth1" runat="server" Text="Prepared By" CssClass="topBorder"></asp:Label>
                                    &nbsp;
                                    <asp:Label ID="lblAuth2" runat="server" Text="Reviewed By" CssClass="topBorder"></asp:Label>
                                    &nbsp;
                                    <asp:Label ID="lblAuth3" runat="server" Text="Authorize Signature" CssClass="topBorder"></asp:Label>
                                    &nbsp;
                                    <asp:Label ID="Label1" runat="server" Text="Authorize Signature" CssClass="topBorder"></asp:Label>
                                    &nbsp;
                                    <asp:Label ID="Label3" runat="server" Text="Authorize Signature" CssClass="topBorder"></asp:Label>
                                    &nbsp;
                                    <asp:Label ID="Label4" runat="server" Text="Payee" CssClass="topBorder"></asp:Label>
                                </td>
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

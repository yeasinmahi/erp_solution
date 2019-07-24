<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubAccountVoucherEntry.aspx.cs" Inherits="UI.Accounts.Voucher.SubAccountVoucherEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sub Account Voucher Entry</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/CommonStyle.css" rel="stylesheet" />
    <style>
        .tabstyle {
            border-style: solid;
            background-color: #FFCC99;
        }

        .txtstyle {
            width: 250px;
            height: 25px;
            font-size: 15px;
            border-radius: 5px;
        }

        .ddlstyle {
            width: 250px;
            height: 30px;
            font-size: 12px;
            border-radius: 5px
        }

        .lblstyle {
            font-size: 15px;
            padding-right: 2px
        }

        .tablestyle {
            width: 100%;
            border-width: 1px;
            background-color: #d0cdcd;
            border-color: #666;
            border-style: solid;
            margin-top: 15px
        }

        .tdstyle {
            text-align: right;
        }

        .tdstyle-btn {
            text-align: right;
        }

        .btnstyle-sm {
            width: 75px;
            height: 30px;
            color: #000000;
            font-size: 15px;
            font-weight: bold;
        }

        .btnstyle-lg {
            width: 100px;
            height: 30px;
            color: #eeeeee;
            font-size: 15px;
            font-weight: bold;
            background: Green
        }

        .Initial {
            display: block;
            padding: 4px 18px 4px 18px;
            float: left;
            background: url("../Images/InitialImage.png") no-repeat right top;
            color: Black;
            font-weight: bold;
        }

            .Initial:hover {
                color: White;
                background: #eeeeee;
            }

        .Clicked {
            float: left;
            display: block;
            background: padding-box;
            padding: 4px 18px 4px 18px;
            color: Black;
            font-weight: bold;
            color: Green;
        }

        .auto-style1 {
            width: 819px;
        }
    </style>
</head>
<body>
    <form id="frmSubAccountVoucher" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                            <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                        </marquee>
                    </div>
                </asp:Panel>
                <div style="height: 30px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>

                <div class="leaveApplication_container">
                    <asp:Button Text="Bank Receive" ID="tabBankReceive" CssClass="Initial tabstyle" runat="server" OnClick="tabBankReceive_Click" />
                    <asp:Button Text="Bank Payment" ID="tabBankPayment" CssClass="Initial tabstyle" runat="server" OnClick="tabBankPayment_Click" />
                    <asp:Button Text="Cash Receive" ID="tabCashReceive" CssClass="Initial tabstyle" runat="server" OnClick="tabCashReceive_Click" />
                    <asp:Button Text="Cash Pay" ID="tabCashPay" CssClass="Initial tabstyle" runat="server" OnClick="tabCashPay_Click" />
                    <asp:Button Text="Journal Voucher" ID="tabJournalVoucher" CssClass="Initial tabstyle" runat="server" OnClick="tabJournalVoucher_Click" />
                    <asp:Button Text="Contra" ID="tabContra" CssClass="Initial tabstyle" runat="server" OnClick="tabContra_Click" />
                    <asp:Label ID="lblBankBoucher" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="#000099"></asp:Label>

                    <asp:MultiView runat="server" ID="mainView">
                        <asp:View runat="server" ID="viewBankReceive">
                            <table class="tablestyle">
                                <tr>
                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">A/C No : </asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlBRAccountNo" CssClass="ddlstyle"></asp:DropDownList></td>

                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">Instrument : </asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlBRInstrument" CssClass="ddlstyle" AutoPostBack="true" OnSelectedIndexChanged="ddlBRInstrument_SelectedIndexChanged"></asp:DropDownList></td>

                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle"> No : </asp:Label></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtBRNo" CssClass="txtstyle" Height="22px"></asp:TextBox></td>

                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">Date : </asp:Label></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtBankReceiveDate" CssClass="txtstyle" Height="22px"></asp:TextBox>
                                        <cc1:CalendarExtender runat="server" ID="txtBankReceiveDateCalender" TargetControlID="txtBankReceiveDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">Credit A/C : </asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlBRCreditAccount" CssClass="ddlstyle"></asp:DropDownList></td>

                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">Amount : </asp:Label></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtBankReceiveAmount" CssClass="txtstyle" Height="22px"></asp:TextBox>
                                        <asp:HiddenField runat="server" ID="hfTotalBRDebitAmount" />
                                        <asp:HiddenField runat="server" ID="hfTotalBRCreditAmount" />
                                    </td>

                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">Narration : </asp:Label></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtBankReceiveNarration" CssClass="txtstyle" TextMode="MultiLine" Columns="3" Rows="5"></asp:TextBox>
                                        <asp:HiddenField runat="server" ID="hfBRNarration" />
                                    </td>

                                    <td colspan="2" class="tdstyle-btn">
                                        <asp:Button runat="server" ID="btnBankReceiveAdd" Text="ADD" CssClass="btnstyle-sm" OnClick="btnBankReceiveAdd_Click" />
                                        <asp:Button runat="server" ID="btnBankReceiveDelete" Text="Delete" CssClass="btnstyle-sm" OnClick="btnBankReceiveDelete_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8" style="text-align: center">
                                        <asp:GridView ID="gvBankReceive" runat="server" Width="80%" AutoGenerateColumns="False"
                                            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                            CellPadding="5" Font-Size="12px" FooterStyle-BackColor="#999999" FooterStyle-Font-Bold="true"
                                            FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical">
                                            <AlternatingRowStyle BackColor="#CCCCCC" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="SL No.">
                                                    <ItemStyle HorizontalAlign="center" Width="60px" />
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="A/C ID" SortExpression="strUnit">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBankReceiveAccountId" runat="server" Text='<%# Bind("creditaccountid") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="45px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="A/C Name" SortExpression="strWareHoseName">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBankReceiveAccountName" runat="server" Text='<%# Bind("creditaccountname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="250px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Narration" ItemStyle-HorizontalAlign="right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBankReceiveNarration" runat="server" Text='<%# Bind("narration") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="500px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Debit" ItemStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBankReceiveDebit" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("debitamount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Credit" ItemStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBankReceiveCredit" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("creditamount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" Font-Size="20px" />
                                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"></td>
                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">Receive From : </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtBankReceiveFrom" CssClass="txtstyle"></asp:TextBox>
                                    </td>
                                    <td colspan="2" class="tdstyle-btn">
                                        <asp:Button runat="server" ID="btnBankReceiveSubmit" Text="Save BR" CssClass="btnstyle-lg" OnClick="btnBankReceiveSubmit_Click" />
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View runat="server" ID="viewBankPayment">
                            <table class="tablestyle">
                                <tr>
                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">A/C No : </asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlBankPaymentACNo" CssClass="ddlstyle"></asp:DropDownList></td>

                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">Instrument : </asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlBankPaymentInstrument" CssClass="ddlstyle" AutoPostBack="true" OnSelectedIndexChanged="ddlBankPaymentInstrument_SelectedIndexChanged"></asp:DropDownList></td>

                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">No : </asp:Label></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtBankPaymentNo" CssClass="txtstyle"></asp:TextBox></td>

                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">Date : </asp:Label></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtBankPaymentDate" CssClass="txtstyle" autocomplete="off"></asp:TextBox>
                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtBankPaymentDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">Debit A/C : </asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlBankPaymentDebitAC" CssClass="ddlstyle"></asp:DropDownList></td>

                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">Amount : </asp:Label></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtBankPaymentAmount" CssClass="txtstyle"></asp:TextBox>
                                        <asp:HiddenField runat="server" ID="hfBPDebitAmount" />
                                        <asp:HiddenField runat="server" ID="hfBPCreditAmount" />
                                    </td>

                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">Narration : </asp:Label>
                                         <asp:HiddenField runat="server" ID="hfBPNarration" />
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtBankPaymentNarration" CssClass="txtstyle" TextMode="MultiLine" Columns="3" Rows="5"></asp:TextBox></td>

                                    <td colspan="2" class="tdstyle-btn">
                                        <asp:Button runat="server" ID="btnBankPaymentAdd" Text="ADD" CssClass="btnstyle-sm" OnClick="btnBankPaymentAdd_Click" />
                                        <asp:Button runat="server" ID="btnBankPaymentDelete" Text="Delete" CssClass="btnstyle-sm" OnClick="btnBankPaymentDelete_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <asp:GridView ID="gvBankPayment" runat="server" AutoGenerateColumns="False" Width="100%"
                                            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                            CellPadding="5" Font-Size="11px" FooterStyle-BackColor="#999999" FooterStyle-Font-Bold="true"
                                            FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical">
                                            <AlternatingRowStyle BackColor="#CCCCCC" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="SL No.">
                                                    <ItemStyle HorizontalAlign="center" Width="60px" />
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="A/C ID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBankPaymentAccountId" runat="server" Text='<%# Bind("debitaccountid") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="45px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="A/C Name" SortExpression="debitaccountname">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBankPaymentAccountName" runat="server" Text='<%# Bind("debitaccountname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="250px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Narration" ItemStyle-HorizontalAlign="right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBankPaymentNarration" runat="server" Text='<%# Bind("narration") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="left" Width="500px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Debit" ItemStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBankPaymentDebit" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("debitamount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Credit" ItemStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBankPaymentCredit" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("creditamount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"></td>
                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">Pay To : </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtBankPaymentPayTo" CssClass="txtstyle"></asp:TextBox>
                                    </td>
                                    <td colspan="2" class="tdstyle-btn">
                                        <asp:Button runat="server" ID="btnBankPaymentSubmit" Text="Save BP" CssClass="btnstyle-lg" OnClick="btnBankPaymentSubmit_Click" />
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View runat="server" ID="viewCashReceive">
                            <table class="tablestyle">
                                <tr>
                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">Credit A/C : </asp:Label></td>
                                    <td colspan="3">
                                        <asp:DropDownList runat="server" ID="ddlCRCreditAccount" CssClass="ddlstyle"></asp:DropDownList>
                                    </td>

                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">Amount : </asp:Label></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtCRCreditAmount" CssClass="txtstyle"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">Narration : </asp:Label></td>
                                    <td colspan="4">
                                        <asp:TextBox runat="server" ID="TextBox1" CssClass="txtstyle"></asp:TextBox>
                                    </td>
                                    <td class="tdstyle">
                                        <asp:Button runat="server" ID="btnCRAdd" Text="ADD" CssClass="btnstyle-sm" OnClick="btnCRAdd_Click" />
                                        <asp:Button runat="server" ID="btnCRDelete" Text="Delete" CssClass="btnstyle-sm" OnClick="btnCRDelete_Click" />
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">Cost Centre : </asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlCRCostCentre" CssClass="ddlstyle"></asp:DropDownList>
                                    </td>

                                    <td></td>
                                    <td></td>

                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <asp:GridView ID="dgvCashReceive" runat="server" AutoGenerateColumns="False" Width="100%"
                                            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                            CellPadding="5" Font-Size="11px" FooterStyle-BackColor="#999999" FooterStyle-Font-Bold="true"
                                            FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical">
                                            <AlternatingRowStyle BackColor="#CCCCCC" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="SL No.">
                                                    <ItemStyle HorizontalAlign="center" Width="60px" />
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="A/C ID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCRAccountId" runat="server" Text='<%# Bind("debitaccountid") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="45px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="A/C Name" SortExpression="debitaccountname">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCRAccountName" runat="server" Text='<%# Bind("debitaccountname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="250px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Narration" ItemStyle-HorizontalAlign="right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCRNarration" runat="server" Text='<%# Bind("narration") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="left" Width="500px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Debit" ItemStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCRDebit" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("debitamount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Credit" ItemStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCRCredit" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("creditamount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"></td>
                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">Receive From : </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtCRReceiveFrom" CssClass="txtstyle"></asp:TextBox>
                                    </td>
                                    <td colspan="2" class="tdstyle-btn">
                                        <asp:Button runat="server" ID="btnSaveCR" Text="Save CR" CssClass="btnstyle-lg" OnClick="btnSaveCR_Click" />
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                         <asp:View runat="server" ID="viewCashPay">
                             <table class="tablestyle">
                                <tr>
                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">Debit A/C : </asp:Label></td>
                                    <td colspan="3">
                                        <asp:DropDownList runat="server" ID="ddlCPDebitAccount" CssClass="ddlstyle"></asp:DropDownList>
                                    </td>

                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">Amount : </asp:Label></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtCPDebitAmount" CssClass="txtstyle"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">Narration : </asp:Label></td>
                                    <td colspan="4">
                                        <asp:TextBox runat="server" ID="txtCPNarration" CssClass="txtstyle"></asp:TextBox>
                                    </td>
                                    <td class="tdstyle">
                                        <asp:Button runat="server" ID="btnCPAdd" Text="ADD" CssClass="btnstyle-sm" OnClick="btnCPAdd_Click" />
                                        <asp:Button runat="server" ID="btnCPDelete" Text="Delete" CssClass="btnstyle-sm" OnClick="btnCPDelete_Click" />
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">Cost Centre : </asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlCPCostCentre" CssClass="ddlstyle"></asp:DropDownList>
                                    </td>

                                    <td></td>
                                    <td></td>

                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <asp:GridView ID="dgvCPCostCentre" runat="server" AutoGenerateColumns="False" Width="100%"
                                            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                            CellPadding="5" Font-Size="11px" FooterStyle-BackColor="#999999" FooterStyle-Font-Bold="true"
                                            FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical">
                                            <AlternatingRowStyle BackColor="#CCCCCC" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="SL No.">
                                                    <ItemStyle HorizontalAlign="center" Width="60px" />
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="A/C ID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCRAccountId" runat="server" Text='<%# Bind("debitaccountid") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="45px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="A/C Name" SortExpression="debitaccountname">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCRAccountName" runat="server" Text='<%# Bind("debitaccountname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="250px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Narration" ItemStyle-HorizontalAlign="right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCRNarration" runat="server" Text='<%# Bind("narration") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="left" Width="500px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Debit" ItemStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCRDebit" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("debitamount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Credit" ItemStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCRCredit" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("creditamount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"></td>
                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">Pay To : </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtCPPayTo" CssClass="txtstyle"></asp:TextBox>
                                    </td>
                                    <td colspan="2" class="tdstyle-btn">
                                        <asp:Button runat="server" ID="btnCPSave" Text="Save CP" CssClass="btnstyle-lg" OnClick="btnCPSave_Click" />
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View runat="server" ID="viewJournalVoucher">
                            <table class="tablestyle">
                                <tr>
                                    <td colspan="4" style="text-align: center">
                                        <asp:RadioButton runat="server" ID="rbJVDebit" Text="Dr." AutoPostBack="true" OnCheckedChanged="rbJVDebit_CheckedChanged" GroupName="jvrb" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                        <asp:RadioButton runat="server" ID="rbJVCredit" Text="Cr." AutoPostBack="true" OnCheckedChanged="rbJVCredit_CheckedChanged" GroupName="jvrb" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">A/C Head : </asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlJVAccountHead" CssClass="ddlstyle"></asp:DropDownList></td>
                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">Amount : </asp:Label></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtJVAmount" CssClass="txtstyle"></asp:TextBox>
                                         <asp:HiddenField runat="server" ID="hfJVDebitAmount" />
                                        <asp:HiddenField runat="server" ID="hfJVCreditAmount" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">Narration : </asp:Label></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtJVNarration" CssClass="txtstyle" TextMode="MultiLine" Columns="3" Rows="5"></asp:TextBox>
                                        <asp:HiddenField runat="server" ID="hfJVNarration" />
                                    </td>

                                    <td colspan="2" class="tdstyle-btn">
                                        <asp:Button runat="server" ID="btnJVAdd" Text="ADD" CssClass="btnstyle-sm" OnClick="btnJVAdd_Click" />
                                        <asp:Button runat="server" ID="btnJVDelete" Text="Delete" CssClass="btnstyle-sm" OnClick="btnJVDelete_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:GridView ID="gvJurnalVoucher" runat="server" AutoGenerateColumns="False" Width="80%"
                                            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                            CellPadding="5" Font-Size="12px" FooterStyle-BackColor="#999999" FooterStyle-Font-Bold="true"
                                            FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical">
                                            <AlternatingRowStyle BackColor="#CCCCCC" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="SL No.">
                                                    <ItemStyle HorizontalAlign="center" Width="60px" />
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="A/C ID" SortExpression="accountid">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblJVAccountId" runat="server" Text='<%# Bind("creditaccountid") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="45px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="A/C Name" SortExpression="accountname">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblJVAccountName" runat="server" Text='<%# Bind("creditaccountname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="250px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Narration" ItemStyle-HorizontalAlign="right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblJVNarration" runat="server" Text='<%# Bind("narration") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="500px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Debit" ItemStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblJVDebit" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("debitamount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Credit" ItemStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblJVCredit" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("creditamount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:GridView>
                                    </td>

                                </tr>
                                <tr>
                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">Date : </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtJVDate" CssClass="txtstyle"></asp:TextBox>
                                        <cc1:CalendarExtender runat="server" ID="JVCE" TargetControlID="txtJVDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                    </td>
                                    <td colspan="2" class="tdstyle-btn">
                                        <asp:Button runat="server" ID="btnJVSubmit" Text="Save JV" CssClass="btnstyle-lg" OnClick="btnJVSubmit_Click" />
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View runat="server" ID="viewContra">
                            <table class="tablestyle">
                                <tr>
                                    <td colspan="8" style="text-align: center">
                                        <asp:RadioButton runat="server" ID="rbContraBanktoCash" Text="Bank to Cash" CssClass="lblstyle" AutoPostBack="true" OnCheckedChanged="rbContraBanktoCash_CheckedChanged" GroupName="contra" />
                                        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                        <asp:RadioButton runat="server" ID="rbContraCashtpoBank" Text="Cash to Bank" CssClass="lblstyle" AutoPostBack="true" OnCheckedChanged="rbContraCashtpoBank_CheckedChanged" GroupName="contra" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">A/C No : </asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlContraACNo" CssClass="ddlstyle"></asp:DropDownList></td>

                                    <td class="tdstyle">
                                        <asp:Label runat="server" ID="lblContraInstrument" CssClass="lblstyle">Instrument : </asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlContraInstrument" CssClass="ddlstyle" AutoPostBack="true" OnSelectedIndexChanged="ddlContraInstrument_SelectedIndexChanged"></asp:DropDownList></td>

                                    <td class="tdstyle">
                                        <asp:Label runat="server" ID="lblContraNo" CssClass="lblstyle">No : </asp:Label></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtContraNo" CssClass="txtstyle"></asp:TextBox></td>

                                    <td class="tdstyle">
                                        <asp:Label runat="server" ID="lblContraDate" CssClass="lblstyle">Date : </asp:Label></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtContraDate" CssClass="txtstyle"></asp:TextBox>
                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender2" TargetControlID="txtContraDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>

                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">Amount : </asp:Label></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtContraAmount" CssClass="txtstyle"></asp:TextBox>
                                        <asp:HiddenField runat="server" ID="hfContraDebitAmount" />
                                        <asp:HiddenField runat="server" ID="hfContraCreditAmount" />
                                    </td>

                                    <td class="tdstyle">
                                        <asp:Label runat="server" CssClass="lblstyle">Narration : </asp:Label>
                                        <asp:HiddenField runat="server" ID="hfContraNarration" />
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtContraNarration" CssClass="txtstyle" TextMode="MultiLine" Columns="3" Rows="5"></asp:TextBox></td>
                                    <td colspan="2"></td>
                                    <td colspan="2" class="tdstyle-btn">
                                        <asp:Button runat="server" ID="btnContraAdd" Text="ADD" CssClass="btnstyle-sm" OnClick="btnContraAdd_Click" />
                                        <asp:Button runat="server" ID="btnContraDelete" Text="Delete" CssClass="btnstyle-sm" OnClick="btnContraDelete_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <asp:GridView ID="gvContra" runat="server" AutoGenerateColumns="False" Width="80%"
                                            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                            CellPadding="5" Font-Size="12px" FooterStyle-BackColor="#999999" FooterStyle-Font-Bold="true"
                                            FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical">
                                            <AlternatingRowStyle BackColor="#CCCCCC" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="SL No.">
                                                    <ItemStyle HorizontalAlign="center" Width="60px" />
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="A/C ID" SortExpression="accountid">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblContraAccountId" runat="server" Text='<%# Bind("creditaccountid") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="45px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="A/C Name" SortExpression="accountname">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblContraAccountName" runat="server" Text='<%# Bind("creditaccountname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="250px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Narration" ItemStyle-HorizontalAlign="right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblContraNarration" runat="server" Text='<%# Bind("narration") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="left" Width="500px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Debit" ItemStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblContraDebit" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("debitamount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Credit" ItemStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblContraCredit" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("creditamount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:GridView>
                                    </td>

                                </tr>
                                <tr>
                                    <td colspan="6"></td>
                                    <td colspan="2" class="tdstyle-btn">
                                        <asp:Button runat="server" ID="btnContraSubmit" Text="Save CN" CssClass="btnstyle-lg" OnClick="btnContraSubmit_Click" />
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                    </asp:MultiView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

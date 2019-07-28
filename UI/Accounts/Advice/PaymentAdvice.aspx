<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="PaymentAdvice.aspx.cs" Inherits="UI.Accounts.Advice.PaymentAdvice" %>

<%@ Import Namespace="System.ComponentModel" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    <script src="../Content/JS/CustomizeScript.js"></script>
    <script src="../../Content/JS/CustomizeScript.js"></script>
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/Application.css" rel="stylesheet" />

    <script language="javascript" type="text/javascript">

        function ExportDivDataToExcel() {

            var html = $("#divExport").html();
            html = $.trim(html);
            html = html.replace(/>/g, '&gt;');
            html = html.replace(/</g, '&lt;');
            $("input[id$='HdnValue']").val(html);
        }
        function ExportDivDataToExcelIBBL() {

            var html = $("#divExportIBBL").html();
            html = $.trim(html);
            html = html.replace(/>/g, '&gt;');
            html = html.replace(/</g, '&lt;');
            $("input[id$='HdnValueIBBL']").val(html);
        }
        function ViewDispatchPopup(Id) {
            window.open('VoucherPrint.aspx?ID=' + Id, 'sub', "height=500, width=900, scrollbars=yes, left=100, top=25, resizable=no, title=Preview");
        }
    </script>


    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>



    <style type="text/css">
        .rounds {
            height: 200px;
            width: 150px;
            -moz-border-colors: 25px;
            -ms-border-radius: 25px;
            border-radius: 25px;
        }

        .hdnDivision {
            background-color: #EFEFEF;
            position: absolute;
            z-index: 1;
            visibility: hidden;
            border: 10px double black;
            text-align: center;
            width: 500%;
            height: 47%;
            margin-left: 300px;
            margin-top: -280px;
            margin-right: 00px;
            padding: 15px;
            overflow-y: scroll;
        }

        .auto-style1 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="frmcaf" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <%--<asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>--%>
        <%--=========================================Start My Code From Here===============================================--%>
        <table style="width: auto; float: left;">
            <tr>
                <td>
                    <div class="leaveApplication_container">
                        <asp:HiddenField ID="hdnEnroll" runat="server" />
                        <asp:HiddenField ID="hdnUnit" runat="server" />
                        <asp:HiddenField ID="hdnconfirm" runat="server" />
                        <table class="tbldecoration" style="width: auto; float: left;">
                            <div style="background-color: cadetblue; font-size: 18px" class="tabs_container">
                                <caption>
                                    <b>PAYMENT ADVICE FORM</b><hr />
                                </caption>
                            </div>

                            <tr>
                                <td style="text-align: right;">
                                    <asp:Label ID="lblDate" runat="server" CssClass="lbl" Text="Date :"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtDate" runat="server" AutoPostBack="false" CssClass="txtBox" autocomplete="off" Width="210px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDate"></cc1:CalendarExtender>
                                </td>
                                <td style="text-align: right;">
                                    <asp:Label ID="lblAdviceType" runat="server" CssClass="lbl" Text="Advice Type :"></asp:Label></td>
                                <td style="text-align: left;">
                                    <asp:DropDownList ID="ddlAdviceType" runat="server" AutoPostBack="true" CssClass="ddList" OnSelectedIndexChanged="ddlAdviceType_SelectedIndexChanged" Width="210px">
                                        <asp:ListItem Selected="True" Value="1">Party Advice</asp:ListItem>
                                        <asp:ListItem Value="2">Zakat Advice</asp:ListItem>
                                        <asp:ListItem Value="3">Milk Advice</asp:ListItem>
                                        <asp:ListItem Value="4">Salary Advice</asp:ListItem>
                                        <asp:ListItem Value="5">TADA Advice</asp:ListItem>
                                        <asp:ListItem Value="6">Piece Rate</asp:ListItem>
                                        <asp:ListItem Value="7">Zakat Advice HO</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td style="text-align: right;">
                                    <asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Unit Name :"></asp:Label></td>
                                <td style="text-align: left;">
                                    <asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" CssClass="dropdownList" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged" OnDataBound="ddlUnit_DataBound" DataSourceID="odsunit" DataTextField="strUnit" DataValueField="intUnitID" Width="210px"></asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsunit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit" OldValuesParameterFormatString="original_{0}">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    <asp:Label ID="lblMandatory" runat="server" CssClass="lbl" Text="Acc. Mandatory :"></asp:Label></td>
                                <td style="text-align: left;">
                                    <asp:DropDownList ID="ddlMandatory" runat="server" CssClass="ddList" Width="210px">
                                        <asp:ListItem Selected="True" Value="1">Yes</asp:ListItem>
                                        <asp:ListItem Value="2">No</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td style="text-align: right;">
                                    <asp:Label ID="Label11" runat="server" CssClass="lbl" Text="Advice Bank :"></asp:Label></td>
                                <td style="text-align: left;">
                                    <asp:DropDownList ID="ddlFormat" runat="server" CssClass="ddList" Width="210px" AutoPostBack="true" OnSelectedIndexChanged="ddlFormat_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="0">Select Bank</asp:ListItem>
                                        <asp:ListItem Selected="False" Value="1">IBBL</asp:ListItem>
                                        <asp:ListItem Value="2">SCB</asp:ListItem>
                                        <asp:ListItem Value="3">OTHER</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td style="text-align: right;">
                                    <asp:Label ID="Label12" runat="server" CssClass="lbl" Text="Voucher Posting :"></asp:Label></td>
                                <td style="text-align: left;">
                                    <asp:DropDownList ID="ddlVoucher" runat="server" CssClass="ddList" Width="210px">
                                        <asp:ListItem Selected="True" Value="0">Not Completed</asp:ListItem>
                                        <asp:ListItem Value="1">Completed</asp:ListItem>
                                        <asp:ListItem Value="2">All</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    <asp:Label ID="lblBankAccountNo" runat="server" CssClass="lbl" Text="Account No. :"></asp:Label></td>
                                <td style="text-align: left;">
                                    <asp:DropDownList ID="ddlBankAccount" runat="server" CssClass="ddList" Width="210px" AutoPostBack="true" OnSelectedIndexChanged="ddlBankAccount_SelectedIndexChanged"></asp:DropDownList></td>
                                <td style="text-align: right">
                                    <asp:Label ID="lblChillingCenter" runat="server" CssClass="lbl" Text="Chilling Center :"></asp:Label></td>
                                <td style="text-align: left;">
                                    <asp:DropDownList ID="ddlChillingCenter" runat="server" CssClass="ddList" Width="210px"></asp:DropDownList></td>
                                <td colspan="2" style="text-align: right;">
                                    <asp:Button ID="btnShowReport" runat="server" Text="Show Report" OnClick="btnShowReport_Click" />
                                    <asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click" OnClientClick="ExportDivDataToExcel()" />
                                    <asp:Button ID="btnExportIBBL" runat="server" Text="Export" OnClick="btnExportIBBL_Click" OnClientClick="ExportDivDataToExcelIBBL()" />
                                    <asp:Button ID="btnPrint" runat="server" Text="Print" /></td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <asp:GridView ID="dgvReport" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" Font-Size="10px" FooterStyle-BackColor="#999999" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" ShowFooter="false" OnRowDataBound="dgvReport_OnRowDataBound">
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

                                            <asp:TemplateField HeaderText="Code No" ItemStyle-HorizontalAlign="right" SortExpression="intSuppID" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCodeNo" runat="server" Text='<%# Bind("intSuppID") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Bank Name" ItemStyle-HorizontalAlign="right" SortExpression="strBankName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBankName" runat="server" Text='<%# Bind("strBankName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Branch" ItemStyle-HorizontalAlign="right" SortExpression="strBranchName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBranch" runat="server" Text='<%# Bind("strBranchName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="A/C Type" ItemStyle-HorizontalAlign="right" SortExpression="strAccType">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblACType" runat="server" Text='<%# Bind("strAccType") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Account No" ItemStyle-HorizontalAlign="right" SortExpression="strBankAccountNo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAccountNo" runat="server" Text='<%# Bind("strBankAccountNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" Width="100px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="right" SortExpression="monVoucher">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("monVoucher", "{0:0,0.00}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Payment Info" ItemStyle-HorizontalAlign="right" SortExpression="strPaymentInfo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPaymentInfo" runat="server" Text='<%# Bind("strPaymentInfo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Comments" ItemStyle-HorizontalAlign="right" SortExpression="strcomments">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblComments" runat="server" Text='<%# Bind("strcomments") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Routing No" ItemStyle-HorizontalAlign="right" SortExpression="strRoutingNumber">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRoutingNo" runat="server" Text='<%# Bind("strRoutingNumber") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Instrument No" ItemStyle-HorizontalAlign="right" SortExpression="intInstrumentNo">
                                                <ItemTemplate>
                                                    <asp:Label ID="btnInstrumentNo" runat="server" Text='<%# Bind("intInstrumentNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="SL No" ItemStyle-HorizontalAlign="right" SortExpression="intSlNo" >
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Debit Account" ItemStyle-HorizontalAlign="Center">
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


                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnDelete" runat="server" CssClass="myButtonGrey" Style="cursor: pointer; font-size: 11px;"
                                                        CommandArgument='<%# Eval("intID") %>' Text="Delete" OnClick="btnDelete_Click" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="center" Width="50px" />
                                            </asp:TemplateField>

                                        </Columns>
                                        <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                    </asp:GridView>
                                </td>
                            </tr>

                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div id="divExport" runat="server">
                        <table>
                            <tr>
                                <td style="font-weight: bold; text-decoration: underline; font-size: 22px; color: #000000; text-align: center">
                                    <asp:Label ID="lblUnitName" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; text-decoration: underline; font-size: 18px; color: #000000; text-align: center">
                                    <asp:Label ID="lblUnitAddress" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; font-size: 15px; color: #000000; text-align: left">
                                    <asp:Label ID="lblTo" runat="server" Text="To"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; font-size: 15px; color: #000000; text-align: left">
                                    <asp:Label ID="lblManager" runat="server" Text="The Manager"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-size: 15px; color: #000000; text-align: left">
                                    <asp:Label ID="lblBankName" runat="server"></asp:Label></td>
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
                </td>
            </tr>
            <tr>
                <td>
                    <div id="divExportIBBL" runat="server">
                        <table>
                            <tr>
                                <td style="font-weight: bold; text-decoration: underline; font-size: 20px; color: #000000; text-align: center">
                                    <asp:Label ID="lblUnitIBBL" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; text-decoration: underline; font-size: 16px; color: #000000; text-align: center">
                                    <asp:Label ID="lblUnitAddIBBL" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; font-size: 14px; color: #000000; text-align: left">
                                    <asp:Label ID="lblToIBBL" runat="server" Text="To"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; font-size: 14px; color: #000000; text-align: left">
                                    <asp:Label ID="lblManagerIBBL" runat="server" Text="The Manager"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-size: 14px; color: #000000; text-align: left">
                                    <asp:Label ID="lblBankNameIBBL" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-size: 14px; color: #000000; text-align: left">
                                    <asp:Label ID="lblBankAddressIBBL" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; font-size: 14px; color: #000000; text-align: left">
                                    <asp:Label ID="lblSubjectIBBL" runat="server" Text="<u>Subject : Payment Instruction.</u>"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; font-size: 14px; color: #000000; text-align: left">
                                    <asp:Label ID="lblDearSirIBBL" runat="server" Text="Dear Sir,"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; font-size: 14px; color: #000000; text-align: left">
                                    <asp:Label ID="lblMailBodyIBBL" runat="server" Width="520px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; font-size: 14px; color: #000000; text-align: left">
                                    <asp:Label ID="lblDetailsIBBL" runat="server" Text="Detailed particulars of each Account Holder :"></asp:Label></td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:GridView ID="dgvAdviceIBBL" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" Font-Size="10px" FooterStyle-BackColor="#999999" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" ShowFooter="true"
                                        OnRowDataBound="dgvAdviceIBBL_RowDataBound">
                                        <AlternatingRowStyle BackColor="#CCCCCC" />
                                        <Columns>

                                            <asp:TemplateField HeaderText="SL No.">
                                                <ItemStyle HorizontalAlign="center" Width="15px" />
                                                <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Account No" ItemStyle-HorizontalAlign="Center" SortExpression="strBankAccountNo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAccountNo" runat="server" Text='<%# Bind("strBankAccountNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="90px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Account Name" SortExpression="strSupplier">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAccountName" runat="server" Text='<%# Bind("strSupplier") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="190px" />
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTTText" runat="server" Text="Total :"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Code No" ItemStyle-HorizontalAlign="Center" SortExpression="intSuppID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCodeNo" runat="server" Text='<%# Bind("intSuppID") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
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

                                            <asp:TemplateField HeaderText="Payment Info" ItemStyle-HorizontalAlign="Center" SortExpression="intInstrumentNo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPaymentInfo" runat="server" Text='<%# Bind("intInstrumentNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Bank Name" ItemStyle-HorizontalAlign="Center" SortExpression="strBankName" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBankName" runat="server" Text='<%# Bind("strBankName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Branch" ItemStyle-HorizontalAlign="Center" SortExpression="strBranchName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBranch" runat="server" Text='<%# Bind("strBranchName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="A/C Type" ItemStyle-HorizontalAlign="Center" SortExpression="strAccType" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblACType" runat="server" Text='<%# Bind("strAccType") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Comments" ItemStyle-HorizontalAlign="right" SortExpression="strcomments" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblComments" runat="server" Text='<%# Bind("strcomments") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Routing No" ItemStyle-HorizontalAlign="right" SortExpression="strRoutingNumber" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRoutingNo" runat="server" Text='<%# Bind("strRoutingNumber") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Instrument No" ItemStyle-HorizontalAlign="right" SortExpression="intInstrumentNo" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInstrumentNo" runat="server" Text='<%# Bind("intInstrumentNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="SL No" ItemStyle-HorizontalAlign="right" SortExpression="intSlNo" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSLNo" runat="server" Text='<%# Bind("intSlNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" />
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
                                    <asp:Label ID="lblWordIBBL" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="height: 30px"></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; font-size: 18px; color: #000000; text-align: left" class="auto-style1">
                                    <asp:Label ID="lblForUnitIBBL" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="height: 70px"></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; font-size: 15px; color: #000000; text-align: left">
                                    <asp:Label ID="lblAuthIBBL1" runat="server" Text="Authorize Signature"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblAuthIBBL2" runat="server" Text="Authorize Signature"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblAuthIBBL3" runat="server" Text="Authorize Signature"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="font-weight: bold; font-size: 15px; color: #000000; text-align: left">&nbsp;</td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="HdnValueIBBL" runat="server" />
                    </div>
                </td>
            </tr>
        </table>
        <%--=========================================End My Code From Here=================================================--%>
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>

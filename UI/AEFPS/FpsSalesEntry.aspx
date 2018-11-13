<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FpsSalesEntry.aspx.cs" Inherits="UI.AEFPS.FpsSalesEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script src="../Content/JS/datepickr.min.js"></script>

    <script type="text/javascript">
        function FTPUpload() {
            document.getElementById("hdnconfirm").value = "2";
            __doPostBack();
        }
        function onlyNumbers(evt) {
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;

            if ((charCode > 57))
                return false;
            return true;
        }
        function FTPUpload1() {
            document.getElementById("hdnconfirm").value = "0";
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "3"; }
            else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
            __doPostBack();
        }
    </script>

    <script> function CloseWindow() {
            window.close();
        } </script>

    <script type="text/javascript">
        function RefreshParent() {
            if (window.opener != null && !window.opener.closed) {
                window.opener.location.reload();
            }
        }
        window.onbeforeunload = RefreshParent;
    </script>
    <script type="text/javascript">
        function OpenHdnDiv() {
            $("#hdnDivision").fadeIn("slow");
            document.getElementById('hdnDivision').style.visibility = 'visible';
        }
        function ClosehdnDivision() {

            $("#hdnDivision").fadeOut("slow");
        }
    </script>
    <script>
        function printDiv(divName) {
            var printContents = document.getElementById(divName).innerHTML;
            var originalContents = document.body.innerHTML;
            document.body.innerHTML = printContents;
            window.print();
            document.body.innerHTML = originalContents;
        }
    </script>
    <script>
        function Registration(url) {
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=500,width=300,top=20,left=0, close=no');
            if (window.focus) { newwindow.focus() }
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
    <style type="text/css">
        .txtBox {
        }
    </style>
</head>
<body>
    <form id="frmselfresign" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div>
                </asp:Panel>
                <div style="height: 100px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <%--=========================================Start My Code From Here===============================================--%>
                <div class="leaveApplication_container">
                    <asp:HiddenField ID="hdnEnroll" runat="server" />
                    <asp:HiddenField ID="hdnUnit" runat="server" />
                    <asp:HiddenField ID="hdnSalary" runat="server" />
                    <asp:HiddenField ID="hdnMillage" runat="server" />
                    <asp:HiddenField ID="hdnSaleAmount" runat="server" />
                    <asp:HiddenField ID="hdnDTFare" runat="server" />
                    <asp:HiddenField ID="hdnSingleMillage100KM" runat="server" />
                    <asp:HiddenField ID="hdnSingleMillage100AboveKM" runat="server" />
                    <asp:HiddenField ID="hdnSalesQty" runat="server" />
                    <asp:HiddenField ID="hdnconfirm" runat="server" />
                    <asp:HiddenField ID="hdnDieselTotalTk" runat="server" />
                    <asp:HiddenField ID="hdnItemid" runat="server" />
                    <asp:HiddenField ID="hdnDTFCount" runat="server" />
                    <asp:HiddenField ID="hdnDTFCountCash" runat="server" />
                    <asp:HiddenField ID="hdnstockQty" runat="server" />
                    <asp:HiddenField ID="hdnQty" runat="server" />
                    <asp:HiddenField ID="hdnDieselPerKMOutStation" runat="server" />
                    <asp:HiddenField ID="hdnActualSales" runat="server" />
                    <asp:HiddenField ID="hdnCNGPerKMOutStation" runat="server" />
                    <%--<div style="background-color:cadetblue;font-size:18px"  class="tabs_container"><b> SALES ENTRY FORM</b><hr /></div>--%>

                    <table class="tbldecoration" style="width: auto; float: left;">
                        <tr>
                            <td style="text-align: left; font-weight: bold; background-color: #385d5e; font-size: 18px; color: #ffffff;" colspan="4">
                                <asp:Label ID="Label11" runat="server"><b> SALES ENTRY FORM</b></asp:Label></td>

                            <td style="text-align: left; font-weight: bold; background-color: cadetblue; font-size: 18px; color: #000000;" colspan="2">
                                <asp:Label ID="Label13" runat="server"><b>Re-Print & Clear Printer</b><hr /></asp:Label></td>

                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblInDate" runat="server" CssClass="lbl" Text="Wear House :"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" runat="server" Width="195px"></asp:DropDownList></td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblQty" runat="server" CssClass="lbl" Text="Date :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="190px"></asp:TextBox></td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblVCNo" runat="server" CssClass="lbl" Text="Voucher No :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtVCNo" runat="server" CssClass="txtBox"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblemployeesearch" runat="server" CssClass="lbl" Text="Employee Search :"></asp:Label></td>
                            <td colspan="3">
                                <asp:TextBox ID="txtEmployee" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" Width="479px" OnTextChanged="txtEmployee_TextChanged"></asp:TextBox>
                                <%--  <cc1:AutoCompleteExtender ID="empsearch" runat="server" TargetControlID="txtEmployee"
            ServiceMethod="EmployeeSearch" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender>--%>
                                <asp:HiddenField ID="hdfEmpCode" runat="server" />
                                <asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" />
                            </td>
                            <td style="text-align: right;">
                                <asp:Button ID="btnClearPrinter" runat="server" Text="Clear Printer" CssClass="btnColore" OnClick="btnClearPrinter_Click" />
                                
                            </td>
                            <td style="text-align: right;" >
                                <asp:Button ID="btnReprint" runat="server" Text="Re-Print" OnClick="btnReprint_Click" OnClientClick="return Validate();" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" style="font-weight: bold; background-color: cadetblue; font-size: 18px; color: #000000;">Employee Info:<hr />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Employee Name :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtEmname" runat="server" CssClass="txtBox" ReadOnly="True" onkeypress="return onlyNumbers();" MaxLength="10"></asp:TextBox></td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblAdditionalMillage" runat="server" CssClass="lbl" Text="Enroll No :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtEnroll" ReadOnly="True" runat="server" CssClass="txtBox" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblTotalMillage" runat="server" CssClass="lbl" Text="Card No :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtCard" ReadOnly="True" runat="server" CssClass="txtBox" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Designation :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtDeg" ReadOnly="True" runat="server" CssClass="txtBox" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblAdditionalFare" runat="server" CssClass="lbl" Text="Department :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtDept" ReadOnly="True" runat="server" CssClass="txtBox" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblTotalTripFare" runat="server" CssClass="lbl" Text="Total Credit Amount :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtCredittotalamount" Enabled="false" ForeColor="#cc3300" runat="server" CssClass="txtBox" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" style="font-weight: bold; background-color: cadetblue; font-size: 18px; color: #000000;">Sales Info:<hr />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="QR Code Scan :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtQRcode" AutoPostBack="true" runat="server" CssClass="txtBox" MaxLength="30" OnTextChanged="txtQRcode_TextChanged"></asp:TextBox></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Stock :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtStock" runat="server" CssClass="txtBox" onkeypress="return onlyNumbers();" Enabled="false" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Credit Status :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtCreditStatus" runat="server" CssClass="txtBox" onkeypress="return onlyNumbers();" Enabled="false" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label6" runat="server" CssClass="lbl" Text="Sales Type :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlpaymenttype" CssClass="ddList" Font-Bold="False" runat="server" Width="195px" AutoPostBack="True" OnSelectedIndexChanged="ddlpaymenttype_SelectedIndexChanged">
                                    <asp:ListItem Value="1">Cash</asp:ListItem>
                                    <asp:ListItem Value="2">Credit</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label7" runat="server" CssClass="lbl" Text="Taken Amount :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtCashReceiveAmount" runat="server" CssClass="txtBox" MaxLength="10" AutoPostBack="true" OnTextChanged="txtCashReceiveAmount_TextChanged"></asp:TextBox></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label8" runat="server" CssClass="lbl" Text="Return Amount :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtReturn" Enabled="false" runat="server" CssClass="txtBox" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add();" MaxLength="10"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label9" runat="server" CssClass="lbl" Text="Item Name :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtItemname" runat="server" CssClass="txtBox" MaxLength="10" AutoPostBack="true" OnTextChanged="txtItemname_TextChanged"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtItemname"
                                    ServiceMethod="ItemnameSearch" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label10" runat="server" CssClass="lbl" Text="Price :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtPrice" runat="server" CssClass="txtBox" Enabled="false" MaxLength="10" AutoPostBack="true"></asp:TextBox></td>
                            <td style="text-align: right;">Qty :</td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtQty" runat="server" CssClass="txtBox" MaxLength="10" AutoPostBack="true" OnTextChanged="txtQty_TextChanged"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="6" style="text-align: right;">&nbsp;</td>

                        </tr>
                        <tr>
                            <td colspan="6">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" style="font-weight: bold; background-color: cadetblue; font-size: 18px; color: #000000;">Product Info :<asp:Label ID="lblsalesAmount" ForeColor="#003399" runat="server"></asp:Label><hr />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="font-weight: bold; font-size: 16px; color: #000000;">
                                <asp:Label ID="lblchallanno" runat="server"></asp:Label></td>
                        </tr>

                        <tr>
                            <td style="text-align: right;" colspan="6">
                                <asp:Button ID="btnSave" runat="server" OnClientClick="ConfirmAll()" Text="Save" OnClick="btnSave_Click" />
                                <asp:GridView ID="dgvRptTemp" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"
                                    BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="GridView1_RowDataBound">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL No.">
                                            <ItemStyle HorizontalAlign="center" Width="15px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="QR Code" Visible="true" ItemStyle-HorizontalAlign="left" SortExpression="strQRCode">
                                            <ItemTemplate>
                                                <asp:Label ID="lblstrQRCode" runat="server" Width="100px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strQRCode")) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Product Id" SortExpression="intProductID">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="sdLAServiceCharge" runat="server" Value='<%# Eval("id") %>' />
                                                <asp:Label ID="lblintProductIDs" runat="server" Text='<%# Bind("intProductID") %>' Width="70px"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="55px" />
                                            <FooterTemplate>
                                                <asp:Label ID="lblTintProductID" runat="server" Text="Total" /></FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Product Name" Visible="true" ItemStyle-HorizontalAlign="center" SortExpression="intMRRNo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblstrProductNames" runat="server" Width="150px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strProductName")) %>'></asp:Label></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Qty" ItemStyle-HorizontalAlign="right" SortExpression="MRRQty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblnumQty" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("numQty"))) %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" Width="40px" />
                                            <FooterTemplate>
                                                <asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text='<%# TotalnumQty %>' /></FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Price" Visible="true" ItemStyle-HorizontalAlign="center" SortExpression="intMRRNo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblmonPrices" runat="server" Width="70px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("monPrice")) %>'></asp:Label></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="right" SortExpression="MRRValue">
                                            <ItemTemplate>
                                                <asp:Label ID="lblmonAmount" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monAmount"))) %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" Width="40px" />
                                            <FooterTemplate>
                                                <asp:Label ID="lbldmmonAmount" runat="server" DataFormatString="{0:0.00}" Text='<%# TotalAmount %>' /></FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:Button ID="Complete1" Width="90px" Font-Bold="true" BackColor="#5effff" runat="server" Text="Delete" CommandName="complete1" OnClick="Complete1_Click" CommandArgument='<%# Eval("id") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                </asp:GridView>

                            </td>
                        </tr>
                        <tr>
                            <td colspan="6"></td>
                        </tr>
                        <tr style="background-color: lightgray">
                            <td colspan="6"></td>
                        </tr>
                        </tr>            
                    </table>
                </div>
                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    <script>
        function Validate() {
            var txtVoucherName = document.getElementById("txtVCNo").value;

            if (txtVoucherName === null || txtVoucherName === "") {
                alert("Voucher number can not be empty");
                return false;
            }
            return true;
        }

    </script>
    <style>
        .btnColore {
            background-color: #337ab7;
            font-family: "Helvetica";
            color: white;
        }
    </style>
</body>
</html>

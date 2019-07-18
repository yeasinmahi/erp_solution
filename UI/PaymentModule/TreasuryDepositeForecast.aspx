<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TreasuryDepositeForecast.aspx.cs" Inherits="UI.PaymentModule.TreasuryDepositeForecast" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.: Treasury Challan :.</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <webopt:BundleReference ID="BundleReference4" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    <script>
        function ShowReport() {

        }
        function ShowDepositeVouchar() {
            var bank = document.getElementById("ddlBank").value;
            var bankAcc = document.getElementById("ddlAccount").value;

            if (bank == null || bank == "") {
                alert("Insert Bank Name");
                return false;
            }
            else if (bankAcc == null || bankAcc == "") {
                alert("Insert Bank Account No");
                return false;
            }
            else { return true; }

        }
    </script>
</head>
<body>
    <form id="frmaclmanatt" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="hdnunit" runat="server" />
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
                    <div class="tabs_container" id="head">Treasury Deposite Forecast :<hr />
                    </div>

                    <div>
                        <table>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td>
                                    <asp:RadioButton ID="btnRadioAdvice" runat="server" Text="Advise" GroupName="radioBtn" AutoPostBack="true" OnCheckedChanged="RadioButton_CheckedChanged" /></td>
                                <td>
                                    <asp:RadioButton ID="btnRadioCheque" runat="server" Text="Cheque" GroupName="radioBtn" AutoPostBack="true" OnCheckedChanged="RadioButton_CheckedChanged" /></td>
                            </tr>
                            <tr class="tblrowodd">
                                <td style="text-align: right;">
                                    <asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit : "></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" CssClass="dropdownList" OnSelectedIndexChanged="ddlUnit_OnSelectedIndexChanged"></asp:DropDownList>
                                    <%--<asp:ObjectDataSource ID="odsUnit" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetUnitByUserId" TypeName="HR_DAL.Payment.TreasuryChallanTDSTableAdapters.sprGetVATAccountByAccountsUserTableAdapter">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="intUser" SessionField="sesUserId" Type="Int32" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>--%>
                                </td>
                                <td style="width: 10px;"></td>
                                <td>
                                    <asp:Button ID="btnShow" runat="server" class="nextclick" Style="font-size: 12px; cursor: pointer;"
                                        Text="Show Report" OnClientClick="ShowReport()" OnClick="btnShow_Click" /></td>
                                <td style="width: 10px;"></td>
                                <td>
                                    <asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Bank : "></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlBank" runat="server" AutoPostBack="True" CssClass="dropdownList" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged"></asp:DropDownList></td>
                                <td style="width: 10px;"></td>
                                <td>
                                    <asp:Label ID="Label2" CssClass="lbl" runat="server" Text="A/C No : "></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="ddlAccount" runat="server" AutoPostBack="True" CssClass="dropdownList"></asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>

                                <td style="text-align: right;">
                                    <asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Vouchar Date : "></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtVDate" CssClass="txtBox" runat="server"></asp:TextBox>
                                    <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtVDate" Format="yyyy/MM/dd" PopupButtonID="imgCal_2" ID="CalendarExtender2" runat="server" EnableViewState="true"></cc1:CalendarExtender>
                                    <img id="imgCal_2" src="../../../Content/images/img/calbtn.gif" style="border: 0px; width: 34px; height: 23px; vertical-align: bottom;" />
                                </td>
                            </tr>
                        </table>

                        <table>

                            <tr>
                                <td>
                                    <asp:GridView ID="GvDetails" runat="server" AutoGenerateColumns="False" ShowFooter="True" OnRowDataBound="GVDetails_RowDataBound" OnRowCommand="GvDetails_RowCommand" OnRowCreated="GvDetails_RowCreated">
                                        <Columns>
                                            <asp:TemplateField HeaderText="SL" SortExpression="intType">

                                                <ItemTemplate>
                                                    <asp:Label ID="lblIntType" runat="server" Text='<%# Bind("intType") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField FooterText="Total" HeaderText="Deposite For" SortExpression="strType">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Width="200px" Text='<%# Bind("strType") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Day_7" SortExpression="day_7">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl7" runat="server" Text='<%# Bind("day_7", "{0:N2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblday7" runat="server" ForeColor="Red" CssClass="align"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="right" />
                                                <FooterStyle HorizontalAlign="right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Day_6" SortExpression="day_6">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl6" runat="server" Text='<%# Bind("day_6", "{0:N2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblday6" runat="server" ForeColor="Red" CssClass="align"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="right" />
                                                <FooterStyle HorizontalAlign="right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Day_5" SortExpression="day_5">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl5" runat="server" Text='<%# Bind("day_5", "{0:N2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblday5" runat="server" ForeColor="Red" CssClass="align"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="right" />
                                                <FooterStyle HorizontalAlign="right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Day_4" SortExpression="day_4">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl4" runat="server" Text='<%# Bind("day_4", "{0:N2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblday4" runat="server" ForeColor="Red" CssClass="align"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="right" />
                                                <FooterStyle HorizontalAlign="right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Day_3" SortExpression="day_3">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl3" runat="server" Text='<%# Bind("day_3", "{0:N2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblday3" runat="server" ForeColor="Red" CssClass="align"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="right" />
                                                <FooterStyle HorizontalAlign="right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Day2" SortExpression="day_2">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl2" runat="server" Text='<%# Bind("day_2", "{0:N2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblday2" runat="server" ForeColor="Red" CssClass="align"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="right" />
                                                <FooterStyle HorizontalAlign="right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Day_1" SortExpression="day_1">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl1" runat="server" Text='<%# Bind("day_1", "{0:N2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblday1" runat="server" ForeColor="Red" CssClass="align"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="right" />
                                                <FooterStyle HorizontalAlign="right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Day_0" SortExpression="day_0">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl0" runat="server" Text='<%# Bind("day_0", "{0:N2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblday0" runat="server" ForeColor="Red" CssClass="align"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="right" />
                                                <FooterStyle HorizontalAlign="right" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Current Balance" SortExpression="monCurrentBalance">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCurrentBalance" runat="server" Text='<%# Bind("monCurrentBalance", "{0:N2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblmonCurrentBalance" runat="server" ForeColor="Red" CssClass="align"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="right" />
                                                <FooterStyle HorizontalAlign="right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Net Pay" SortExpression="Column1">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblColumn1" runat="server" Text='<%# Bind("Column1", "{0:N2}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblNetPay" runat="server" ForeColor="Red" CssClass="align"></asp:Label>
                                                </FooterTemplate>
                                                <ItemStyle HorizontalAlign="right" />
                                                <FooterStyle HorizontalAlign="right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Pay Amount">
                                                <ItemTemplate>
                                                    <asp:TextBox runat="server" ID="txtPay"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="right" />
                                            </asp:TemplateField>

                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnDeposite" runat="server" CausesValidation="false" OnClientClick="return ShowDepositeVouchar()" CommandName="DepositV" Text="Treasury Deposit Vouchar" CommandArgument="<%# Container.DataItemIndex %>" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>

                            </tr>
                        </table>
                    </div>
                </div>
                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    <style>
        #GvDetails td {
            padding: 5px;
        }
    </style>
</body>
</html>

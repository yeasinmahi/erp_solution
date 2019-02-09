<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseVoucher.aspx.cs" Inherits="UI.PaymentModule.PurchaseVoucher" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Purchase Voucher </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../Content/JS/datepickr.min.js"></script>
    <script src="../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />
    <script type="text/javascript">
        $("[id*=chkHeader]").live("click", function () {
            var chkHeader = $(this);
            var grid = $(this).closest("table");
            $("input[type=checkbox]", grid).each(function () {
                if (chkHeader.is(":checked")) {
                    $(this).attr("checked", "checked");
                    $("td", $(this).closest("tr")).addClass("selected");
                } else {
                    $(this).removeAttr("checked");
                    $("td", $(this).closest("tr")).removeClass("selected");
                }
            });
        });
        $("[id*=chkRow]").live("click", function () {
            var grid = $(this).closest("table");
            var chkHeader = $("[id*=chkHeader]", grid);
            if (!$(this).is(":checked")) {
                $("td", $(this).closest("tr")).removeClass("selected");
                chkHeader.removeAttr("checked");
            } else {
                $("td", $(this).closest("tr")).addClass("selected");
                if ($("[id*=chkRow]", grid).length == $("[id*=chkRow]:checked", grid).length) {
                    chkHeader.attr("checked", "checked");
                }
            }
        });
    </script>
</head>
<body>
    <form id="frmPurchaseVoucher" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>

                <%--=========================================Start My Code From Here===============================================--%>
                <asp:HiddenField ID="hdnconfirm" runat="server" />
                <asp:HiddenField ID="hdnEnroll" runat="server" />
                <asp:HiddenField ID="hdnUnit" runat="server" />
                <asp:HiddenField ID="hdnLevel" runat="server" />
                <asp:HiddenField ID="hdnEmail" runat="server" />
                <asp:HiddenField ID="hdnCount" runat="server" />

                <div class="divbody" style="padding-right: 10px;">
                    <div id="divLevel1" class="tabs_container" style="background-color: #dcdbdb; padding-top: 10px; padding-left: 5px; padding-right: -50px; border-radius: 5px;">
                        <asp:Label ID="lblHeading" runat="server" CssClass="lbl" Text="Purchase Voucher" Font-Bold="true" Font-Size="16px"></asp:Label><hr />
                    </div>

                    <table class="tbldecoration" style="width: auto; float: left;">
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblLoanType" runat="server" CssClass="lbl" Text="Unit"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="23px" AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label13" runat="server" Text=""></asp:Label></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Type"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlType" Font-Bold="False" runat="server" Width="220px" Height="23px" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="1">Purchase</asp:ListItem>
                                    <asp:ListItem Value="2">Purchase Return</asp:ListItem>
                                    <asp:ListItem Value="3">Import Purchase Voucher</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label4" runat="server" Text=""></asp:Label></td>
                            <td style="text-align: right; padding: 5px 0px 5px 0px">
                                <asp:Button ID="btnShow" runat="server" class="myButton" Text="Show" Height="30px" OnClick="btnShow_Click" /></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                            <td style="text-align: right; padding: 5px 0px 5px 0px">
                                <asp:Button ID="btnPrepareAllVoucher" runat="server" class="myButton" Text="Prepare All Voucher" Height="30px" OnClientClick="ConfirmAll()" OnClick="btnPrepareAllVoucher_Click" /></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="dgvPurchaseV" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
                                    CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                                    HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
                                    ForeColor="Black" GridLines="Vertical">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL No.">
                                            <ItemStyle HorizontalAlign="center" Width="60px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="ID" SortExpression="intMRR">
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Bind("intMRR") %>' Width="80px"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" Width="80px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="PO ID" SortExpression="intPO">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPOID" runat="server" Text='<%# Bind("intPO") %>' Width="80px"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" Width="80px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Date" SortExpression="dteDate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDate" runat="server" Text='<%#Eval("dteDate", "{0:yyyy-MM-dd}") %>' Width="80px"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" Width="80px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Party ID" SortExpression="intParty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPartyID" runat="server" Text='<%# Bind("intParty") %>' Width="80px"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" Width="80px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Party Name" SortExpression="strParty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPartyName" runat="server" Text='<%# Bind("strParty") %>' Width="265px"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" Width="265px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Book Value" SortExpression="monMRR">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBookValue" runat="server" Text='<%# Bind("monMRR", "{0:n2}") %>' Width="100px"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkHeader" runat="server" /></HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkRow" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>

                </div>
                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

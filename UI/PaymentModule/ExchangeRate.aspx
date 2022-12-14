<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExchangeRate.aspx.cs" Inherits="UI.PaymentModule.ExchangeRate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Bill Registration </title>
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
    <link href="../Content/CSS/CommonStyle.css" rel="stylesheet" />
    <%-- <script>
        function ViewBillDetailsPopup(Id) {
            window.open('BillDetails.aspx?ID=' + Id, 'sub', "height=600, width=1100, scrollbars=yes, left=100, top=25, resizable=no, title=Preview");
        }

        function Registration(url) {
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=900,top=50,left=220, close=no');
            if (window.focus) { newwindow.focus() }
        }
    </script>--%>
    <script type="text/javascript">
        $(function () {
            //Enable Disable all TextBoxes when Header Row CheckBox is checked.
            $("[id*=chkHeader]").bind("click", function () {
                var chkHeader = $(this);

                //Find and reference the GridView.
                var grid = $(this).closest("table");

                //Loop through the CheckBoxes in each Row.
                $("td", grid).find("input[type=checkbox]").each(function () {

                    //If Header CheckBox is checked.
                    //Then check all CheckBoxes and enable the TextBoxes.
                    if (chkHeader.is(":checked")) {
                        $(this).attr("checked", "checked");
                        var td = $("td", $(this).closest("tr"));
                        td.css({ "background-color": "#D8EBF2" });
                        $("input[type=text]", td).removeAttr("disabled");
                    } else {
                        $(this).removeAttr("checked");
                        var td = $("td", $(this).closest("tr"));
                        td.css({ "background-color": "#FFFF" });
                        $("input[type=text]", td).attr("disabled", "disabled");
                    }
                });
            });

            //Enable Disable TextBoxes in a Row when the Row CheckBox is checked.
            $("[id*=chkRow]").bind("click", function () {

                //Find and reference the GridView.
                var grid = $(this).closest("table");

                //Find and reference the Header CheckBox.
                var chkHeader = $("[id*=chkHeader]", grid);

                //If the CheckBox is Checked then enable the TextBoxes in thr Row.
                if (!$(this).is(":checked")) {
                    var td = $("td", $(this).closest("tr"));
                    td.css({ "background-color": "#FFFF" });
                    $("input[type=text]", td).attr("disabled", "disabled");
                } else {
                    var td = $("td", $(this).closest("tr"));
                    td.css({ "background-color": "#D8EBF2" });
                    $("input[type=text]", td).removeAttr("disabled");
                }

                //Enable Header Row CheckBox if all the Row CheckBoxes are checked and vice versa.
                if ($("[id*=chkRow]", grid).length == $("[id*=chkRow]:checked", grid).length) {
                    chkHeader.attr("checked", "checked");
                } else {
                    chkHeader.removeAttr("checked");
                }
            });
        });
    </script>

</head>
<body>

    <form id="frmSupplierCOA" runat="server">
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
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender2" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <div id="loading"></div>

                <%--=========================================Start My Code From Here===============================================--%>
                <asp:HiddenField ID="hdnconfirm" runat="server" />
                <asp:HiddenField ID="hdnEnroll" runat="server" />
                <asp:HiddenField ID="hdnUnit" runat="server" />

                <asp:HiddenField ID="hdnEmail" runat="server" />
                <%-- <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtAllPayDate"></cc1:CalendarExtender>--%>

                <div class="divbody" style="padding-right: 10px;">


                    <table class="tbldecoration" style="width: auto; float: left;">
                        <tr>


                            <td style="text-align: right;">
                                <asp:Label ID="lblDate" runat="server" CssClass="lbl" Text="From"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
                            <td>
                                <asp:TextBox ID="txtFrom" runat="server" AutoPostBack="false" autocomplete="off" CssClass="txtBox1" Enabled="true" Width="110"></asp:TextBox>
                                <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFrom"></cc1:CalendarExtender>
                            </td>



                            <td style="text-align: right; padding: 5px 0px 5px 0px">
                                <asp:Button ID="btnShow" runat="server" class="myButton" Text="Show" Height="30px" OnClick="btnShow_Click" OnClientClick="showLoader()" /></td>
                        </tr>

                        <tr>

                            <td colspan="3">


                                <span style="padding-left: 15px">
                                    <asp:Button ID="btnPrepareAllVoucher" runat="server" class="myButton" Height="30px" Width="180px" Text="Save Exchange Rate" OnClick="btnPrepareAllVoucher_Click" /></span>
                                <%--<asp:Button ID="Button1" runat="server" class="myButton" Height="30px" Width="180px" Text="Save Exchange Rate" OnClientClick="ConfirmAll()" OnClick="btnPrepareAllVoucher_Click" /></span>--%>

                            </td>

                        </tr>
                    </table>
                </div>

                <table>
                    <tr>
                        <td style='text-align: center;'>
                            <asp:Label ID="lblUnitName" runat="server" Font-Bold="true" Font-Size="20px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style='text-align: center;'>
                            <asp:Label ID="lblReportName" runat="server" Font-Bold="true" Font-Size="16px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style='text-align: center;'>
                            <asp:Label ID="lblFromToDate" runat="server" Font-Bold="true" Font-Size="16px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td>

                            <asp:GridView ID="dgvReport" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" Width="100%" GridLines="Both">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Request ID" SortExpression="intAutoID">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lblAutoID" ForeColor="black" runat="server" Text='<%# Bind("intAutoID") %>' Width="70px"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="70px" />
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Request ID" SortExpression="intAutoID">
                                        <ItemTemplate>
                                            <asp:Label Visible="false" ID="lblAutoIDs" ForeColor="black" runat="server" Text='<%# Bind("intAutoID") %>' Width="70px"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="70px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit" SortExpression="strUnit">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnit" runat="server" Text='<%# Bind("strUnit") %>' Width="60px"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Particualars" SortExpression="strParticualars">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lblParticualars" runat="server" ForeColor="black" Text='<%# Bind("strParticualars") %>' Width="200px"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" Width="200px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Bank" SortExpression="strPayBank">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBank" runat="server" Text='<%# Bind("strPayBank") %>' Width="90px"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" Width="90px" />
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Currency" SortExpression="strCurrencyName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCurrency" runat="server" Text='<%# Bind("strCurrencyName") %>' Width="50px"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" Width="50px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Actual Exchange Rate" ItemStyle-HorizontalAlign="right" SortExpression="numActualExcRate">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtActualRate" CssClass="txtBox" Width="70px" ForeColor="Blue" runat="server" Text='<%# Bind("numActualExcRate", "{0:n2}") %>'></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="right" Width="70px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkHeader" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkRow" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

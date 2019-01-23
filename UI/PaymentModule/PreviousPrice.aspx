<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreviousPrice.aspx.cs" Inherits="UI.PaymentModule.PreviousPrice" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>>.::: Previous Price</title>
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

    <link href="../Content/CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/CSS/morris.css" rel="stylesheet" />
    <script src="../Content/JS/raphael.min.js"></script>
    <script src="../Content/JS/morris.min.js"></script>
    <script language="javascript">      

        function ViewBillDetailsPopup(Id) {
            window.open('BillDetails.aspx?ID=' + Id, 'sub', "height=600, width=1100, scrollbars=yes, left=100, top=25, resizable=no, title=Preview");
        }

        function Print() {
            document.getElementById("btnprint").style.display = "none"; window.print(); self.close();
        }
        function Validation() {
            //var intitemid = document.getElementById("txtItemId").value;
            //var intitemname = document.getElementById("txtItem").value;
            //if (intitemname == null || intitemname == "") {
            //    if (intitemid==null||intitemid == "") {
            //    alert("Plz insert item id");
            //    return false;
            //}
            //else {
            //    return true;
            //}
            //}
            //else {
            //    return true;

            //}

        }
    </script>

    <style type="text/css">
        .dynamicDivbn {
            margin: 5px 5px 5px 5px;
            width: Auto;
            height: auto;
            background-color: #FFFFFF;
            font-size: 11px;
            font-family: verdana;
            color: #000;
            padding: 5px 5px 5px 5px;
        }

        .auto-style1 {
            height: 22px;
        }
    </style>


</head>
<body>
    <form id="frmPreviousPrice" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <%--=========================================Start My Code From Here===============================================--%>
        <asp:TextBox ID="txtdgvFTTotal" runat="server" Width="0.1px" CssClass="txtBox" Height="0.1px" MaxLength="10" BackColor="White" ForeColor="White"></asp:TextBox>
        <asp:HiddenField ID="hdnEnroll" runat="server" />
        <asp:HiddenField ID="hdnBillID" runat="server" />
        <asp:HiddenField ID="hdnItemID" runat="server" />
        <asp:HiddenField ID="hdnconfirm" runat="server" />

        <table>

            <tr>
                <td colspan="4" style="text-align: center;">
                    <a id="btnBack" href="BillDetails.aspx" class="nextclick" style="cursor: pointer; text-align: left;">Back</a>
                    <asp:Label ID="lblUnitName" runat="server" Text="PREVIOUS RATES" CssClass="lbl" Font-Size="18px" Font-Bold="true" Font-Underline="true"></asp:Label>
                    <a id="btnprint" href="#" class="nextclick" style="cursor: pointer" onclick="Print()">Print</a>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" class="auto-style1">
                    <asp:Label ID="lblC" runat="server" Text="ITEM NAME :" CssClass="lbl"></asp:Label>
                    
                </td>
                <td style="text-align: left;" class="auto-style1">
                    <asp:Label ID="lblItemName" runat="server" Text="CHALLAN NO" CssClass="lbl" ForeColor="Blue"></asp:Label>
                </td>
                <td style="text-align: right;" class="auto-style1">
                    <asp:Label ID="Label3" runat="server" Text="ITEM ID :" CssClass="lbl"></asp:Label>
                </td>
                <td style="text-align: left;" class="auto-style1">
                    
                    <asp:Label ID="lblitemid" runat="server" CssClass="lbl" ForeColor="Blue"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    <asp:Label ID="Label1" runat="server" Text="WH : "></asp:Label></td>
                <td style="text-align: left;">
                    <asp:DropDownList ID="ddlwh" runat="server" CssClass="ddList" Font-Bold="False" OnSelectedIndexChanged="ddlwh_SelectedIndexChanged"></asp:DropDownList>
                </td>
                
            </tr>
            <tr>
                <td style="text-align: right;">
                    <asp:Label ID="lblitm" CssClass="lbl" Width="55px" runat="server" Text="Item List:"></asp:Label></td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtItem" runat="server" OnTextChanged="txtItem_TextChanged" AutoCompleteType="Search" AutoPostBack="true" Width="400px" CssClass="txtBox"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtItem"
                        ServiceMethod="GetIndentItemSerach" MinimumPrefixLength="1" CompletionSetCount="1"
                        CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                    </cc1:AutoCompleteExtender>
                    <asp:Label ID="Label2" runat="server" Width="55px" Text="Item ID: "></asp:Label>
                    <asp:TextBox ID="txtItemId" runat="server" CssClass="txtBox" Width="200px" OnTextChanged="txtItemId_TextChanged"></asp:TextBox>
                </td>
                <td style="text-align: right;" colspan="2">
                    <%--<asp:TextBox ID="txtItemId" runat="server"></asp:TextBox>--%>
                    <asp:Button ID="btnShowItem" runat="server" Text="Show" OnClick="btnShowItem_Click" OnClientClick="return Validation();" />
                </td>
            </tr>
            <tr>
                <td colspan="4" style="vertical-align: top">
                    <asp:GridView ID="dgvPriceList" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
                        CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                        ShowFooter="false" HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="10px" HeaderStyle-Font-Bold="true"
                        FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>
                            <asp:TemplateField HeaderText="PO ID" SortExpression="intPOID">
                                <ItemTemplate>
                                    <asp:Label ID="lblPOID" runat="server" Text='<%# Bind("intPOID") %>' Width="60px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center"  Width="60px"/>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="PO Date" SortExpression="dtePODate">
                                <ItemTemplate>
                                    <asp:Label ID="lblPODate" runat="server" Text='<%#Eval("dtePODate", "{0:yyyy-MM-dd}") %>' Width="70px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" />
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Item Name" SortExpression="strITem">
                                <ItemTemplate>
                                    <asp:Label ID="lblItem" runat="server" Text='<%#Bind("strItemName") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" Width="150px" />
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="UoM" SortExpression="strUoM">
                                <ItemTemplate>
                                    <asp:Label ID="lblUoM" runat="server" Width="40px" Text='<%#Bind("strUoM") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" Width="40px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Supplier Name" SortExpression="strSupplierName">
                                <ItemTemplate>
                                    <asp:Label ID="lblSupplier" runat="server" Text='<%# Bind("strSupplierName") %>' Width="200px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" Width="200px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Rate" SortExpression="rate">
                                <ItemTemplate>
                                    <asp:Label ID="lblRate" runat="server" Text='<%# Bind("monRate", "{0:n2}") %>' Width="80px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="right" Width="80px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Rate" SortExpression="rate">
                                <ItemTemplate>
                                    <asp:Label ID="lblRate" runat="server" Text='<%# Bind("monRate", "{0:n2}") %>' Width="80px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="right" Width="80px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Currency" SortExpression="strCurrencyName">
                                <ItemTemplate>
                                    <asp:Label ID="lblCurrency" runat="server" Text='<%# Bind("strCurrencyName", "{0:n2}") %>' Width="50px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" Width="50px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Freight" SortExpression="Freight">
                                <ItemTemplate>
                                    <asp:Label ID="lblFreight" runat="server" Text='<%# Bind("monFreight", "{0:n2}") %>' ></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="right" Width="30px" />
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="AIT">
                                <ItemTemplate>
                                    <asp:Label ID="lblAIT" runat="server" Text='<%# Bind("monAIT", "{0:n2}") %>' ></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="right" Width="30px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="VAT">
                                <ItemTemplate>
                                    <asp:Label ID="lblVat" runat="server" Text='<%# Bind("monVAT", "{0:n2}") %>' ></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="right" Width="30px" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Packing">
                                <ItemTemplate>
                                    <asp:Label ID="lblPacking" runat="server" Text='<%# Bind("monPacking", "{0:n2}") %>' ></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="right" Width="30px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Discount" SortExpression="Discount">
                                <ItemTemplate>
                                    <asp:Label ID="lblDiscount" runat="server" Text='<%# Bind("discount", "{0:n2}") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="right" Width="30px" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Actual">
                                <ItemTemplate>
                                    <asp:Label ID="lblActual" runat="server" Text='<%# Bind("monActual", "{0:n2}") %>' Width="80px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="right" Width="80px" />
                            </asp:TemplateField>

                        </Columns>
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    </asp:GridView>
                </td>

                <%-- shows when wh dropdown selected--%>
                <td colspan="4" style="vertical-align: top">
                    <asp:GridView ID="gvItemList" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
                        CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                        ShowFooter="false" HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
                        FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>
                            <asp:TemplateField HeaderText="PO ID" SortExpression="intPOID">
                                <ItemTemplate>
                                    <asp:Label ID="lblPOID" runat="server" Text='<%# Bind("intPOID") %>' Width="80px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" Width="80px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="PO Date" SortExpression="dtePODate">
                                <ItemTemplate>
                                    <asp:Label ID="lblPODate" runat="server" Text='<%#Eval("dtePODate", "{0:yyyy-MM-dd}") %>' Width="80px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" Width="80px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Supplier ID" SortExpression="intSupplierID">
                                <ItemTemplate>
                                    <asp:Label ID="lblsupID" runat="server" Text='<%# Bind("intSupplierID") %>' Width="80px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" Width="80px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Supplier Name" SortExpression="strSupplierName">
                                <ItemTemplate>
                                    <asp:Label ID="lblSupplier" runat="server" Text='<%# Bind("strSupplierName") %>' Width="250px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" Width="250px" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Currency" SortExpression="strCurrencyName">
                                <ItemTemplate>
                                    <asp:Label ID="lblCurrency" runat="server" Text='<%# Bind("strCurrencyName", "{0:n2}") %>' Width="80px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" Width="80px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Rate" SortExpression="rate">
                                <ItemTemplate>
                                    <asp:Label ID="lblRate" runat="server" Text='<%# Bind("rate", "{0:n2}") %>' Width="80px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="right" Width="80px" />
                            </asp:TemplateField>

                            


                        </Columns>
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    </asp:GridView>
                </td>
            </tr>

            <%--<tr>
        <td colspan="4">
            <asp:Chart ID="Chart1" runat="server" EorderlineWidth="0" Width="900px">
            <Series>
                <asp:Series Name="Amount" XValueMember="strSupplierName" YValueMembers="rate" ChartType="Line"></asp:Series>
            </Series>            
            <Titles>
                <asp:Title Docking="Top" Text="PRICE CHART" />
            </Titles>
            <ChartAreas><asp:ChartArea Name="ChartArea1"></asp:ChartArea></ChartAreas>
            </asp:Chart>
        </td>
    </tr>--%>
        </table>
        <div class="row">
            <div class="col-lg-6 col-md-6 col-sm-12">
                <div class="chart" id="revenue-chart" style="position: relative; height: 300px;"></div>
            </div>
        </div>
        <%--=========================================End My Code From Here=================================================--%>
    </form>

    <script>
        $(document).ready(function () {
            var chartData = [];
            var counter = 0;
            $('#dgvPriceList tr').each(function () {
                if (counter >= 1) {
                    var dates = $(this).find("td span:eq(1)").html();
                    var rates = $(this).find("td span:eq(5)").html();
                    rates = rates.replace(/[^\d\.\-eE+]/g, "");
                    var item = {}
                    item["date"] = dates;
                    item["rate"] = rates;

                    chartData.push(item);
                }
                counter++;
            });
            counter = 0;
            var line = new Morris.Line({
                element: 'revenue-chart',
                resize: true,
                data: chartData,
                xkey: 'date',
                ykeys: ['rate'],
                labels: ['Rate'],
                lineColors: ['#a0d0e0'],
                hideHover: false,
                smooth: false
            });
        });
    </script>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PoApproval.aspx.cs" Inherits="UI.SCM.PoApproval" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>

<head runat="server">

    <title></title>

    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <%--<webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />--%>

    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    <%--<link href="../Content/CSS/GridView.css" rel="stylesheet" />--%>
    <%--<link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />--%>
    <script type="text/javascript">
        function OpenHdnDiv() {
            $("#hdnDivision").fadeIn("slow");
            document.getElementById('hdnDivision').style.visibility = 'visible';
        }

        function CloseHdnDiv() {
            $("#hdnDivision").fadeOut("slow");
        }
        function Registration(url) {
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=900,top=50,left=230, close=no');
            if (window.focus) { newwindow.focus() }
        }
    </script>
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
        function OpenHdnDiv() {
            $("#hdnDivision").fadeIn("slow");
            document.getElementById('hdnDivision').style.visibility = 'visible';
        }

        function ClosehdnDivision() {

            $("#hdnDivision").fadeOut("slow");
        }
    </script>

    <script type="text/javascript">
        function funConfirmAll() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnConfirm").value = "1"; }
            else { confirm_value.value = "No"; document.getElementById("hdnConfirm").value = "0"; }
        }
    </script>

    <style type="text/css">
        .rounds {
            height: 80px;
            width: 30px;
            -moz-border-colors: 25px;
            border-radius: 25px;
        }

        .HyperLinkButtonStyle {
            float: right;
            text-align: left;
            border: none;
            background: none;
            color: blue;
            text-decoration: underline;
            font: normal 10px verdana;
        }

        .hdnDivision {
            background-color: white;
            position: absolute;
            z-index: 1;
            visibility: hidden;
            border: 10px double black;
            text-align: center;
            width: 100%;
            height: 100%;
            margin-left: 50px;
            margin-top: 130px;
            margin-right: 00px;
            padding: 15px;
            overflow-y: scroll;
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
                    <asp:HiddenField ID="hdnConfirm" runat="server" />
                    <asp:HiddenField ID="hdnUnit" runat="server" />
                    <asp:HiddenField ID="hdnIndentNo" runat="server" />
                    <asp:HiddenField ID="hdnIndentDate" runat="server" />

                    <div class="tabs_container" style="text-align: left">
                        PO Approval  From<hr />
                    </div>

                    <table>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="WH Name:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"></asp:DropDownList></td>

                            <td style="text-align: right;">
                                <asp:Label ID="Label16" runat="server" CssClass="lbl" Text="Type:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlDepts" runat="server" AutoPostBack="true" CssClass="ddList" Font-Bold="False"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="By PO No:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtPoNo" CssClass="txtBox" Font-Bold="False" runat="server" />
                                <asp:Button ID="btnPoNoShow" runat="server" ForeColor="Blue" Text="Show" CssClass="btnButton" OnClick="btnPoNoShow_Click" />
                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="By PO User:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtPoUser" runat="server" AutoCompleteType="Search" CssClass="txtBox" Text="ALL" AutoPostBack="true" Width="300px"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtenders2" runat="server" TargetControlID="txtPoUser"
                                    ServiceMethod="GetPoUserSearch" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>

                                <%--<asp:DropDownList ID="ddlPoUser" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server">
        <asp:ListItem Value="1">Pending</asp:ListItem><asp:ListItem Value="2" >Approve</asp:ListItem><asp:ListItem Value="3">Reject</asp:ListItem> </asp:DropDownList>--%>
        <asp:Button ID="btnPoUserShow" runat="server" ForeColor="Blue" Text="Show" OnClick="btnPoUserShow_Click"   />
        </td> 
      </tr> 
       </table>
       <table> 
         <tr> 
            <td><asp:GridView ID="dgvPoApp" runat="server" AutoGenerateColumns="False" ShowFooter="True"  Width="600px"  
                CssClass="GridViewStyle" BackColor="White" BorderColor="#DEDFDE" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" >             
                <HeaderStyle CssClass="HeaderStyle" BackColor="#6B696B" Font-Bold="True" ForeColor="White" Font-Size="10px" />  
                <FooterStyle CssClass="FooterStyle" BackColor="#CCCC99" /> <RowStyle CssClass="RowStyle" BackColor="#F7F7DE" />  <PagerStyle CssClass="PagerStyle" BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" /> 
                <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="SL"><ItemStyle HorizontalAlign="center" Width="60px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
  
                <asp:TemplateField HeaderText="WareHouse" SortExpression="strShortName"><ItemTemplate>
                <asp:Label ID="lblWhName" runat="server" Width="120px" Text='<%# Bind("strShortName") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>
                
                <asp:TemplateField HeaderText="PO No" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="intPOID" >
                <ItemTemplate><asp:Label ID="lblPoNo" runat="server"  Text='<%# Bind("intPOID") %>'></asp:Label></ItemTemplate>
                  <ItemStyle HorizontalAlign="center" /> </asp:TemplateField>  

                <asp:TemplateField HeaderText="PO Date" ItemStyle-HorizontalAlign="right" SortExpression="dtePODate" >
                <ItemTemplate><asp:Label ID="lblPoDate" runat="server"  Width="75px" Text='<%# Bind("dtePODate","{0:dd-MM-yyyy}") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="center" /> </asp:TemplateField>
            
                <asp:TemplateField HeaderText="Supplier Name" ItemStyle-HorizontalAlign="right" SortExpression="strSupplierName" >
                <ItemTemplate><asp:Label ID="lblSuppliyer" runat="server" Width="200px"  Text='<%# Bind("strSupplierName") %>'></asp:Label></ItemTemplate>
                 <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>

                <asp:TemplateField HeaderText="PO Amount" ItemStyle-HorizontalAlign="right" SortExpression="monPOTotal" >
                <ItemTemplate><asp:Label ID="lblPoTotal"  runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("monPOTotal","{0:n2}") %>'></asp:Label></ItemTemplate>
                  <ItemStyle HorizontalAlign="right" /> </asp:TemplateField>
            
                <asp:TemplateField HeaderText="Currency" ItemStyle-HorizontalAlign="right" SortExpression="strCurrencyName" >
                <ItemTemplate><asp:Label ID="lblCurrency" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("strCurrencyName") %>'></asp:Label></ItemTemplate>
                  <ItemStyle HorizontalAlign="center" /> </asp:TemplateField> 
            
                <asp:TemplateField HeaderText="PO Issuer" ItemStyle-HorizontalAlign="right" SortExpression="strEmployeeName" >
                <ItemTemplate><asp:Label ID="lblEmpName" runat="server" Width="200px"  Text='<%# Bind("strEmployeeName") %>'></asp:Label></ItemTemplate>
                  <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>

                <asp:TemplateField HeaderText="Approve?" ItemStyle-HorizontalAlign="right" Visible="false" SortExpression="strIndentType" >
                <ItemTemplate><asp:Label ID="lblIndentType"   runat="server"    ></asp:Label></ItemTemplate>
                 <ItemStyle HorizontalAlign="left" />  </asp:TemplateField> 
             
                <asp:TemplateField HeaderText="Detalis">  <ItemTemplate>
                <asp:Button ID="btnDetalis" runat="server" forecolor="blue" Text="Detalis"  OnClick="btnDetalis_Click"  /></ItemTemplate>
                 <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>

                <asp:TemplateField HeaderText="PO Approval">  <ItemTemplate>
                <asp:Button ID="btnApproval" runat="server" forecolor="blue" Text="Approval" OnClientClick="funConfirmAll();" OnClick="btnApproval_Click"   /></ItemTemplate>
                <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>
            </Columns> 
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
                <EditRowStyle Font-Size="10px"></EditRowStyle>           

                </asp:GridView></td> 
        </tr>  
       </table> 
        </div>

                <div id="hdnDivision" class="hdnDivision" style="width: auto; background-color: white; height: 500px;">

                    <table>
                        <tr>
                            <td colspan="2"></td>
                            <td></td>
                            <td style="text-align: right; font-size: medium">Akij Food & Beverage</td>
                        </tr>
                        <tr>
                            <td colspan="2"></td>
                            <td></td>
                            <td style="text-align: right">73, Dilkusa C/A 1000 Dhaka</td>
                        </tr>
                        <tr>

                            <td>Purchase Order</td>
                            <td>
                                <asp:TextBox ID="txtPoNumbers" runat="server" CssClass="txtBox"></asp:TextBox><asp:Button ID="btnPoShowByView" CssClass="btnButton" runat="server" Text="Show" /></td>
                        </tr>
                    </table>
                    <table style="border-color: black; border-radius: 10px; border: 1px solid blue;">
                        <tr>
                            <td style="text-align: left">Suppliyer</td>
                            <td style="text-align: left">Ship TO</td>
                            <td style="text-align: left">Bill To</td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <asp:Label ID="lblSuppliyers" runat="server"></asp:Label></td>
                            <td style="text-align: left">
                                <asp:Label ID="lblShipTo" Width="250px" runat="server"></asp:Label></td>
                            <td style="text-align: left">
                                <asp:Label ID="lblBillTo" Width="250px" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: left">Email:</td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <asp:Label ID="lblSupEmail" Width="250px" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: left">Attn:</td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <asp:Label ID="lblAtten" Width="250px" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: left">Phone:</td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <asp:Label ID="lblPhone" Width="250px" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: left">Address:</td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <asp:Label ID="lblSuppAddress" Width="300px" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="dgvPoDetalis" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"
                                    BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL No.">
                                            <ItemStyle HorizontalAlign="center" Width="60px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Item Name" SortExpression="strName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("strName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="200px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Description" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="strSpecification">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("strSpecification") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" Width="180px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Uom" ItemStyle-HorizontalAlign="right" SortExpression="strUoM">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUom" runat="server" Text='<%# Bind("strUoM") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Shipment" ItemStyle-HorizontalAlign="right" SortExpression="intShipmentSL">
                                            <ItemTemplate>
                                                <asp:Label ID="lblShipment" runat="server" Text='<%# Bind("intShipmentSL") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Qty" ItemStyle-HorizontalAlign="right" SortExpression="numQty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblnumQty" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("numQty") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Rate" ItemStyle-HorizontalAlign="right" SortExpression="monRate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRate" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("monRate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Vat" ItemStyle-HorizontalAlign="right" SortExpression="monVAT">
                                            <ItemTemplate>
                                                <asp:Label ID="lblVat" runat="server" Text='<%# Bind("monVAT") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="AIT" ItemStyle-HorizontalAlign="right" SortExpression="monAIT">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAIT" runat="server" Text='<%# Bind("monAIT") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="right" SortExpression="monAmount">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPoTotalAmount" runat="server" Text='<%# Bind("monAmount") %>'></asp:Label>
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
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="text-align: left; border: 1px solid black;">Partial Shipment</td>
                            <td style="text-align: left; border: 1px solid black;">
                                <asp:Label ID="lblPartialShip" Width="100px" runat="server"></asp:Label></td>
                            <td style="text-align: right; border: 1px solid black">Trnsport Charge:</td>
                            <td style="text-align: left; border: 1px solid black">
                                <asp:Label ID="lblTransportCharge" Width="100px" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: left; border: 1px solid black">No of Shipment</td>
                            <td style="text-align: left; border: 1px solid black">
                                <asp:Label ID="lblNoShipment" Width="100px" runat="server"></asp:Label></td>
                            <td style="text-align: right; border: 1px solid black">Others Charge:</td>
                            <td style="text-align: left; border: 1px solid black">
                                <asp:Label ID="lblOthersCharge" runat="server" Width="100px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: left; border: 1px solid black">Last Shipment Date</td>
                            <td style="text-align: left; border: 1px solid black">
                                <asp:Label ID="lbllastShipmentDate" Width="100px" runat="server"></asp:Label></td>
                            <td style="text-align: right; border: 1px solid black">Gross Disscount:</td>
                            <td style="text-align: left; border: 1px solid black">
                                <asp:Label ID="lblGrossDis" runat="server" Width="100px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: left; border: 1px solid black">Payment terms</td>
                            <td style="text-align: left; border: 1px solid black">
                                <asp:Label ID="lblPaymentTrems" runat="server"></asp:Label></td>
                            <td style="text-align: right; border: 1px solid black">Comission:</td>
                            <td style="text-align: left; border: 1px solid black">
                                <asp:Label ID="lblComission" runat="server" Width="100px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: left; border: 1px solid black">Payment days after MRR (days)</td>
                            <td style="text-align: left; border: 1px solid black">
                                <asp:Label ID="lblPaymentDaysMrr" runat="server"></asp:Label></td>
                            <td style="text-align: right; border: 1px solid black">Grand Total:</td>
                            <td style="text-align: left; border: 1px solid black">
                                <asp:Label ID="lblGrandTotal" runat="server" Width="100px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: left; border: 1px solid black">No of Installment</td>
                            <td style="text-align: left; border: 1px solid black">
                                <asp:Label ID="lblNoOfInstallment" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: left; border: 1px solid black">Installment Interval (Days)</td>
                            <td style="text-align: left; border: 1px solid black">
                                <asp:Label ID="lblIntervelDay" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: left; border: 1px solid black">Warrenty after delivery (months)</td>
                            <td style="text-align: left; border: 1px solid black">
                                <asp:Label ID="lblDeliveryMonth" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </div>

                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
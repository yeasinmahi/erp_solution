<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinishedGoodEntryFgSavePopUP.aspx.cs" Inherits="UI.SCM.BOM.FinishedGoodEntryFgSavePopUP" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head runat="server">

    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    <link href="../Content/CSS/GridView.css" rel="stylesheet" />

    <script type="text/javascript">

        function Confirms() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnConfirm").value = "1"; }
            else { confirm_value.value = "No"; document.getElementById("hdnConfirm").value = "0"; }

        }
        function validation() {
            var actualQuantity = document.getElementById("txtActualQty").value;
            var qcQuantity = document.getElementById("txtQc").value;
            var storeQuantity = document.getElementById("txtSendToStore").value;

            if (actualQuantity == null || actualQuantity == '' || actualQuantity == '0') {
                ShowNotification('Actual Quantity should be greater than 0.', 'Production Transfer', 'warning');
                return false;
            } else if (qcQuantity == null || qcQuantity == '') {
                ShowNotification('QC hold can not be blank', 'Production Transfer', 'warning');
                return false;
            } else if (storeQuantity == null || storeQuantity == '' || storeQuantity == "0") {
                ShowNotification('Send to Store Quantity can not be blank or 0', 'Production Transfer', 'warning');
                return false;
            } else if (parseFloat(qcQuantity) > parseFloat(actualQuantity)) {
                console.log(qcQuantity + ' ' + actualQuantity);
                ShowNotification('QC quantity can not be greater than actual quantity', 'Production Transfer', 'warning');
                return false;
            }


            return true;
        }
    </script>
    <script>   function CloseWindow() { window.close(); }//window.onbeforeunload = RefreshParent();
        //function RefreshParent() {
        //    if (window.opener != null && !window.opener.closed) {
        //        window.opener.location.reload();
        //    }
        //}
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
            background-color: #EFEFEF;
            position: absolute;
            z-index: 1;
            visibility: hidden;
            border: 10px double black;
            text-align: center;
            width: 100%;
            height: 100%;
            margin-left: 70px;
            margin-top: 00px;
            margin-right: 00px;
            padding: 15px;
            overflow-y: scroll;
        }

        .auto-style1 {
            height: 23px;
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
                </asp:Panel>
                <div style="height: 30px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>

                <%--=========================================Start My Code From Here===============================================--%>

                <div class="leaveApplication_container">
                    <asp:HiddenField ID="hdnConfirm" runat="server" />
                    <asp:HiddenField ID="hdnUnit" runat="server" />
                    <asp:HiddenField ID="hdnIndentNo" runat="server" />
                    <asp:HiddenField ID="hdnIndentDate" runat="server" />
                    <asp:HiddenField ID="hdnDueDate" runat="server" />
                    <asp:HiddenField ID="hdnIndentType" runat="server" />
                    <div class="tabs_container" style="text-align: left">
                        PRODUCTION TRANSFER<hr />
                    </div>
                    <table style="width: 750px">
                        <tr>
                            <td style="text-align: left" class="auto-style1">Item Name:
                                <asp:Label ID="lblItemName" ForeColor="blue" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: left" class="auto-style1">Item ID:
                                <asp:Label ID="lblItemId" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">Production ID:
            <asp:Label ID="lblProductionId" runat="server"></asp:Label></td>
                            <td>Plan Qty :
            <asp:Label ID="lblPlanQty" runat="server"></asp:Label></td>
                            <td>Date & Time :
            <asp:Label ID="lblDate" runat="server"></asp:Label></td>
                        </tr>
                    </table>

                    <table style="width: 900px">
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblitm" CssClass="lbl" Font-Bold="true" runat="server" Text="Item List :"></asp:Label>
                            <td>
                                <asp:TextBox ID="txtItem" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" Width="300px" OnTextChanged="txtItem_TextChanged" Enabled="False"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtItem"
                                    ServiceMethod="GetItemSerach" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="Label2" runat="server" CssClass="lbl" Font-Bold="true" Text="Date :"></asp:Label></td>
                            <td style="text-align: left">
                                <asp:TextBox ID="txtDate" runat="server" CssClass="txtBox" Width="80px" autocomplete="off"></asp:TextBox>
                                <cc1:CalendarExtender ID="claenderDte" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDate"></cc1:CalendarExtender>
                            </td>

                            <td style="text-align: right;">
                                <asp:Label ID="Label1" runat="server" CssClass="lbl" Font-Bold="true" Text="Time :"></asp:Label></td>
                            <td style="text-align: left">
                                <asp:TextBox ID="txtTime" runat="server" CssClass="txtBox" Width="50px"></asp:TextBox></td>
                            <td>Job No</td>
                            <td>
                                <asp:TextBox ID="txtJob" runat="server" CssClass="txtBox" Width="70px"></asp:TextBox></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <%--<MKB:TimeSelector ID="tpkEndTime" runat="server" SelectedTimeFormat="TwentyFour" ></MKB:TimeSelector>--%>

                            <td style="text-align: left; width: 20px; display: inline">
                                <asp:Label ID="lblProductQty" Font-Bold="true" runat="server" Text="Production Qty"></asp:Label>:</td>

                            <td style="text-align: left">
                                <asp:TextBox ID="txtProductQty" Width="100px" Text="0" CssClass="txtBox" runat="server" Enabled="False"></asp:TextBox></td>


                            <td>
                                <asp:Label ID="lblUom1" runat="server" ForeColor="Blue"></asp:Label></td>

                            <td style="text-align: left; width: 20px; display: inline">
                                <asp:Label ID="Label4" Font-Bold="true" runat="server" Text="Actual Qty"></asp:Label>:</td>

                            <td style="text-align: left">
                                <asp:TextBox ID="txtActualQty" Width="90px" CssClass="txtBox" ForeColor="red" runat="server"></asp:TextBox></td>



                            <td style="text-align: left; width: 20px; display: inline">
                                <asp:Label ID="Label3" Font-Bold="true" runat="server" Text="QC Hold:"></asp:Label></td>

                            <td style="text-align: left">
                                <asp:TextBox ID="txtQc" Width="90px" Text="0" CssClass="txtBox" runat="server"></asp:TextBox></td>


                            <td style="text-align: right">
                                <asp:Label Font-Bold="true" ID="lblSendStore" runat="server" Text="Send To Store:"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtSendToStore" CssClass="txtBox" Text="0" Width="100px" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:Label ID="lblUom2" ForeColor="Blue" runat="server"></asp:Label></td>

                            <td style="text-align: right">
                                <asp:Button ID="btnAdd" runat="server" Text="Add" ForeColor="blue" OnClientClick="return validation();" OnClick="btnAdd_Click" />
                                <asp:Button ID="btnSaves" ForeColor="Black" BackColor="#ffccff" Font-Bold="true" runat="server" OnClientClick="Confirms();" Text="Save" OnClick="btnSaves_Click" /></td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">
                                <asp:Label ID="Label5" runat="server" CssClass="lbl" Font-Bold="true" Text="Expire Date :"></asp:Label></td>
                            <td style="text-align: left" colspan="3">
                                <asp:TextBox ID="txtExpDate" runat="server" CssClass="txtBox" Width="80px" autocomplete="off"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtenderExp" runat="server" Format="yyyy-MM-dd" TargetControlID="txtExpDate"></cc1:CalendarExtender>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td></td>
                        </tr>
                    </table>
                    <table style="border-color: black; width: 900px; border-radius: 10px;">
                        <tr>
                            <td>
                                <asp:GridView ID="dgvStore" runat="server" Width="800px" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
                                    CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" OnRowDeleting="dgvGridView_RowDeleting"
                                    HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
                                    ForeColor="Black" GridLines="Vertical">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL No.">
                                            <ItemStyle HorizontalAlign="center" Width="60px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Product Name" ItemStyle-HorizontalAlign="right" SortExpression="item">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("item") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Time" ItemStyle-HorizontalAlign="right" SortExpression="times">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTime" runat="server" Text='<%# Bind("times") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Production" ItemStyle-HorizontalAlign="right" SortExpression="qty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductionQty" Width="60px" runat="server" Text='<%# Bind("qty") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Store" ItemStyle-HorizontalAlign="right" SortExpression="storeQty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStore" runat="server" Width="" Text='<%# Bind("storeQty") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Act.Qty" ItemStyle-HorizontalAlign="right" SortExpression="actualQty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblActQty" runat="server" Width="" Text='<%# Bind("actualQty") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Qc.Hold" ItemStyle-HorizontalAlign="right" SortExpression="qcHoldQty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQcHo" runat="server" Width="" Text='<%# Bind("qcHoldQty") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Exp.Date" ItemStyle-HorizontalAlign="right" SortExpression="expDate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblExpD" runat="server" Width="" Text='<%# Bind("expDate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Job No" ItemStyle-HorizontalAlign="right" SortExpression="jobno">
                                            <ItemTemplate>
                                                <asp:Label ID="lblJobNo" runat="server" Width="" Text='<%# Bind("jobno") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:CommandField ShowDeleteButton="True" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" />
                                    </Columns>
                                    <FooterStyle Font-Size="11px" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td></td>
                        </tr>
                    </table>
                    <table style="border-color: black; width: 100%; border-radius: 10px; border: 1px solid blue;">
                        <caption style="text-align: left; color: blue">Previous Entry</caption>
                        <tr>
                            <td>
                                <asp:GridView ID="dgvProductionEntry" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="8" ShowFooter="True"
                                    CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                                    HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true" OnRowDataBound="dgvProductionEntry_OnRowDataBound"
                                    ForeColor="#333333" GridLines="both" CellPadding="4">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL">
                                            <ItemStyle HorizontalAlign="center" Width="10px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Prod. Trans. ID" ItemStyle-HorizontalAlign="right" SortExpression="strItem">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAutoId" runat="server" Text='<%# Bind("intAutoID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Product Name" ItemStyle-HorizontalAlign="right" SortExpression="strItem">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("strItem") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Date" ItemStyle-HorizontalAlign="right" SortExpression="strTime">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTime" runat="server" Text='<%# Bind("strTime") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Prod. Qty" ItemStyle-HorizontalAlign="right" SortExpression="numProdQty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductionQty" Width="60px" runat="server" Text='<%# Bind("numProdQty","{0:n4}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Actual Qty" ItemStyle-HorizontalAlign="right">
                                            <ItemTemplate>
                                                <asp:Label ID="lblActualQty" Width="60px" runat="server" Text='<%# Bind("numActualQty","{0:n4}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="QC Qty" ItemStyle-HorizontalAlign="right">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQCQty" Width="60px" runat="server" Text='<%# Bind("numQCHoldQty","{0:n4}") %>'></asp:Label>
                                            </ItemTemplate>

                                            <FooterTemplate>
                                                Total Store
                                            </FooterTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                            <FooterStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Store Qty" ItemStyle-HorizontalAlign="right" SortExpression="numSendStoreQty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStore" runat="server" Width="" Text='<%# Bind("numSendStoreQty","{0:n4}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="lblTotalStore" runat="server" Width="" Text='<%# Bind("totalSentToStore","{0:n4}") %>'></asp:Label>
                                            </FooterTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                            <FooterStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Is Received" ItemStyle-HorizontalAlign="right" SortExpression="numSendStoreQty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStoreReceivedStatus" runat="server" Width="" Text='<%# Bind("ysnStoreReceive") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="right" SortExpression="numSendStoreQty">
                                            <ItemTemplate>
                                                <asp:Button ID="btnEdit" runat="server" Width="" Text="Edit"></asp:Button>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle Font-Bold="True" Font-Size="11px" BackColor="#5D7B9D" ForeColor="White" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
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
</body>
</html>

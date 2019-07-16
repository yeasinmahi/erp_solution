<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinishedGoodEntryPopup.aspx.cs" Inherits="UI.SCM.BOM.FinishedGoodEntryPopup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/updatedJs") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/updatedCss" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript">

        function Confirms() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) {
                confirm_value.value = "Yes";
                document.getElementById("hdnConfirm").value = "1";
            } else {
                confirm_value.value = "No";
                document.getElementById("hdnConfirm").value = "0";
            }

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
    <script>   function CloseWindow() {
            window.close();
        }//window.onbeforeunload = RefreshParent();
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
        <asp:UpdatePanel ID="UpdatePanel0" runat="server" UpdateMode="Conditional" style="padding-left:10px; padding-right:10px">
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
                
                <div class="erpContainer">
                    <asp:HiddenField ID="hdnConfirm" runat="server" />
                    <asp:HiddenField ID="hdnUnit" runat="server" />
                    <asp:HiddenField ID="hdnIndentNo" runat="server" />
                    <asp:HiddenField ID="hdnIndentDate" runat="server" />
                    <asp:HiddenField ID="hdnDueDate" runat="server" />
                    <asp:HiddenField ID="hdnIndentType" runat="server" />
                    <asp:HiddenField ID="hfTotalQty" runat="server" />
                    <div class="tabs_container" style="text-align: left">
                        <u>Production Details</u>
                    </div>
                    <table style="width: 100%">
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label7" CssClass="lbl" Font-Bold="true" runat="server" ForeColor="blue" Text="Item Name:"></asp:Label>
                            </td>
                            <td style="text-align: left;padding:5px">
                                <asp:Label ID="lblItemName" ForeColor="blue" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label8" CssClass="lbl" Font-Bold="true" runat="server" ForeColor="blue" Text="Item ID:"></asp:Label>
                            </td>
                            <td style="text-align: left;padding:5px">
                                <asp:Label ID="lblItemId" runat="server" ForeColor="blue"></asp:Label>
                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label9" CssClass="lbl" Font-Bold="true" runat="server" Text="Production ID:"></asp:Label>
                            </td>
                            <td style="text-align: left;padding:5px">
                                <asp:Label ID="lblProductionId" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label10" CssClass="lbl" Font-Bold="true" runat="server" Text="Order Qty:"></asp:Label>
                            </td>
                            <td style="text-align: left;padding:5px">
                                 <asp:Label ID="lblOrderQty" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label11" CssClass="lbl" Font-Bold="true" runat="server" Text="Date & Time:"></asp:Label>
                            </td>
                            <td style="text-align: left;padding:5px">
                                <asp:Label ID="lblDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblitm" CssClass="lbl" Font-Bold="true" runat="server" Text="Item List :"></asp:Label>
                            </td>
                            <td style="text-align: left;padding-left:5px">
                                <asp:TextBox ID="txtItem" runat="server" style="width:100%; height:30px; text-align:left;padding:5px" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" OnTextChanged="txtItem_TextChanged"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtItem"
                                    ServiceMethod="GetItemSerach" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblProductQuantity" Font-Bold="true" runat="server" Text="Production Qty:"></asp:Label>
                            </td>
                            <td style="text-align: left;padding-left:5px">
                                <asp:TextBox ID="txtProductQty" style="width:80%; height:30px; text-align:left;padding:5px" Text="0" CssClass="txtBox" runat="server"></asp:TextBox>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label16" Font-Bold="true" runat="server" Text="Good Production Qty:"></asp:Label>
                            </td>
                            <td style="text-align: left;padding-left:5px">
                                <asp:TextBox ID="txtGoodsProductionQty" style="width:80%; height:30px; text-align:left;padding:5px" Text="0" CssClass="txtBox" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label2" runat="server" CssClass="lbl" Font-Bold="true" Text="Date:"></asp:Label></td>
                            <td style="text-align: left;padding-left:5px">
                                <asp:TextBox ID="txtDate" runat="server" CssClass="txtBox" style="width:80%; height:30px; text-align:left;padding:5px" autocomplete="off"></asp:TextBox>
                                <cc1:CalendarExtender ID="claenderDte" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDate"></cc1:CalendarExtender>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label1" runat="server" CssClass="lbl" Font-Bold="true" Text="Time:"></asp:Label>
                            </td>
                            <td style="text-align: left;padding-left:5px">
                                <asp:TextBox ID="txtTime" runat="server" CssClass="txtBox" style="width:80%; height:30px; text-align:left;padding:5px"></asp:TextBox></td>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label17" runat="server" CssClass="lbl" Font-Bold="true" Text="Job No:"></asp:Label>
                            </td>
                            <td style="text-align: left;padding-left:5px">
                                <asp:TextBox ID="txtJob" runat="server" CssClass="txtBox" style="width:80%; height:30px; text-align:left;padding:5px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label5" runat="server" CssClass="lbl" Font-Bold="true" Text="Expire Date:" Visible="false"></asp:Label>
                            </td>
                            <td style="text-align: left;padding-left:5px">
                                <asp:TextBox ID="txtExpDate" runat="server" CssClass="txtBox" style="width:80%; height:30px; text-align:left;padding:5px" autocomplete="off" Visible="false"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtenderExp" runat="server" Format="yyyy-MM-dd" TargetControlID="txtExpDate"></cc1:CalendarExtender>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblOrder" runat="server" CssClass="lbl" Font-Bold="true" Text="Order Id:"></asp:Label>
                            </td>
                            <td style="text-align: left;padding-left:5px">
                                <asp:DropDownList ID="ddlOrderId" runat="server" CssClass="ddList" style="width:80%; height:30px; text-align:left;padding:5px" autocomplete="off"></asp:DropDownList>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblUom1" runat="server" ForeColor="Blue"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblUom2" ForeColor="Blue" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label18" runat="server" CssClass="lbl" Font-Bold="true" Text="Item:"></asp:Label>
                            </td>
                            <td style="text-align: left;padding-left:5px">
                                <asp:DropDownList ID="ddlWastageItem" runat="server" CssClass="ddList" style="width:80%; height:30px; text-align:left;padding:5px" autocomplete="off"></asp:DropDownList>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label19" runat="server" CssClass="lbl" Font-Bold="true" Text="Quantity:"></asp:Label>
                            </td>
                            <td style="text-align: left;padding-left:5px">
                                <asp:TextBox ID="txtWastageQuantity" runat="server" CssClass="txtBox" style="width:80%; height:30px; text-align:left;padding:5px" autocomplete="off"></asp:TextBox>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label20" runat="server" CssClass="lbl" Font-Bold="true" Text="Type:"></asp:Label>
                            </td>
                            <td style="text-align: left;padding-left:5px">
                                <asp:DropDownList ID="ddlWastageType" runat="server" CssClass="ddList" style="width:80%; height:30px; text-align:left;padding:5px" autocomplete="off"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td>
                                <asp:Button ID="btnAdd" CssClass="btn btn-success" Font-Bold="true" runat="server" Text="Add"  OnClientClick="return validation();" OnClick="btnAdd_Click" />
                                <asp:Button ID="btnSaves" CssClass="btn btn-primary"  Font-Bold="true" runat="server" OnClientClick="Confirms();" Text="Save" OnClick="btnSaves_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div>
                    <table style="border-color: black; width: 100%; border-radius: 10px; border: 1px solid blue;">
                        <caption style="text-align: left; color: blue">Previous Entry</caption>
                        <tr>
                            <td>
                                <asp:GridView ID="gridViewProductionEntry" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="8" ShowFooter="True"
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

                                        <asp:TemplateField HeaderText="Order Qty" ItemStyle-HorizontalAlign="right" SortExpression="numProdQty">
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
                                        <asp:TemplateField HeaderText="Production Type" ItemStyle-HorizontalAlign="right">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductionType" Width="250px" runat="server" Text='<%# Bind("strType") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="right">
                                            <ItemTemplate>
                                                <asp:Button ID="btnEdit" runat="server" Width="" Text="Edit" CssClass="btn btn-default" OnClick="btnEdit_OnClick"></asp:Button>
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
                        <tr>
                            <td>
                                <asp:GridView ID="gridViewProductionEntryAdd" runat="server" Width="100%" AutoGenerateColumns="False" 
                                    OnRowDataBound="dgvProductionEntry_OnRowDataBound">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL">
                                            <ItemStyle HorizontalAlign="center" Width="15px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>
                                       <%-- <asp:TemplateField HeaderText="Prod. Trans. ID" ItemStyle-HorizontalAlign="right" SortExpression="strItem">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAutoId" runat="server" Text='<%# Bind("ProductionId") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Product Name" ItemStyle-HorizontalAlign="right" SortExpression="FProductItem">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("FProductItem") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" Width="250px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Date" ItemStyle-HorizontalAlign="right" SortExpression="Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Time" ItemStyle-HorizontalAlign="right" SortExpression="Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Order Qty" ItemStyle-HorizontalAlign="right">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOrderQty" runat="server" Text='<%# Bind("OrderQty","{0:n4}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" Width="65px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Production Qty" ItemStyle-HorizontalAlign="right">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductQty" runat="server" Text='<%# Bind("ProductQty","{0:n4}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" Width="65px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Receive Qty" ItemStyle-HorizontalAlign="right" SortExpression="FProductQty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGoodNwastageQty" runat="server" Text='<%# Bind("FProductQty","{0:n4}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" Width="65px" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Type" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductType" runat="server" Text='<%# Bind("FProductType") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" Width="200px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle Height="25px" Font-Size="11pt" BackColor="#0099ff" VerticalAlign="Middle" />
                                    <RowStyle BorderStyle="Solid" BorderWidth="1px" Font-Size="10pt" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
                <div>
                    <table style="border-color: black; width: 100%; border-radius: 10px;padding-left:5px; padding-right:5px">
                         <caption style="text-align: left; color: blue">Finish Product Extra Production</caption>
                        <tr>
                            <td>
                                <asp:GridView ID="gridViewWastage" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"  ShowFooter="True"
                                    CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" OnRowDeleting="dgvGridView_RowDeleting"
                                    HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="10px" HeaderStyle-Font-Bold="true" GridLines="both"
                                              ForeColor="#333333" CellPadding="4">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

                                    <Columns>
                                        <asp:TemplateField HeaderText="SL No.">
                                            <ItemStyle HorizontalAlign="center" Width="60px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Product Name" ItemStyle-HorizontalAlign="right" SortExpression="item">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("FProductItem") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Product Type" ItemStyle-HorizontalAlign="right" SortExpression="times">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductType" runat="server" Text='<%# Bind("FProductType") %>'></asp:Label>
                                            </ItemTemplate>
                                             <FooterTemplate>
                                                Total : 
                                            </FooterTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                            <FooterStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Production" ItemStyle-HorizontalAlign="right" SortExpression="qty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductionQty" Width="60px" runat="server" Text='<%# Bind("FProductQty","{0:n4}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="lblTotalExtraStore" runat="server" Text='<%# Bind("totalExtraStore","{0:n4}") %>'></asp:Label>
                                            </FooterTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                            <FooterStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Job No" ItemStyle-HorizontalAlign="right" SortExpression="jobno">
                                            <ItemTemplate>
                                                <asp:Label ID="lblJobNo" runat="server" Width="" Text='<%# Bind("JobNo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:CommandField ShowDeleteButton="True" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" />
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
                        <tr>
                            <td>
                                <asp:GridView ID="gridViewWastageAdd" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"  ShowFooter="True"
                                    CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" OnRowDeleting="dgvGridView_RowDeleting"
                                    HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="10px" HeaderStyle-Font-Bold="true" GridLines="both"
                                              ForeColor="#333333" CellPadding="4">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

                                    <Columns>
                                        <asp:TemplateField HeaderText="SL No.">
                                            <ItemStyle HorizontalAlign="center" Width="60px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Product Name" ItemStyle-HorizontalAlign="right" SortExpression="item">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("FProductItem") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Product Type" ItemStyle-HorizontalAlign="right" SortExpression="times">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductType" runat="server" Text='<%# Bind("FProductType") %>'></asp:Label>
                                            </ItemTemplate>
                                             <FooterTemplate>
                                                Total : 
                                            </FooterTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                            <FooterStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Production" ItemStyle-HorizontalAlign="right" SortExpression="qty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductionQty" Width="60px" runat="server" Text='<%# Bind("FProductQty","{0:n4}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="lblTotalExtraStore" runat="server" Text='<%# Bind("totalExtraStore","{0:n4}") %>'></asp:Label>
                                            </FooterTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                            <FooterStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Job No" ItemStyle-HorizontalAlign="right" SortExpression="jobno">
                                            <ItemTemplate>
                                                <asp:Label ID="lblJobNo" runat="server" Width="" Text='<%# Bind("JobNo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:CommandField ShowDeleteButton="True" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" />
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

                <div class="modal fade" id="myModal" role="dialog">
                    <div class="modal-dialog">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Production Transfer Update</h4>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-md-6 col-sm-6">
                                        <asp:Label ID="Label22" runat="server" Text="Transection Id"></asp:Label>
                                        <asp:TextBox ID="txtTransectionId" Enabled="False" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Transection Id"></asp:TextBox>

                                    </div>
                                    <div class="col-md-6 col-sm-6">
                                        <asp:Label ID="Label14" runat="server" Text="Product Name"></asp:Label>
                                        <asp:TextBox ID="txtProductNameUpdate" Enabled="False" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Product Name"></asp:TextBox>

                                    </div>
                                    <div class="col-md-6 col-sm-6">
                                        <asp:Label ID="Label12" runat="server" Text="Actual Quantity"></asp:Label>
                                        <asp:TextBox ID="txtActualQtyUpdate" Enabled="False" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Actual Quantity"></asp:TextBox>

                                    </div>
                                    <div class="col-md-6 col-sm-6">
                                        <asp:Label ID="Label13" runat="server" Text="QC Quantity"></asp:Label>
                                        <asp:TextBox ID="txtQcUpdate" Enabled="False" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="QC Quantity"></asp:TextBox>

                                    </div>

                                    <div class="col-md-6 col-sm-6">
                                        <asp:Label ID="Label6" runat="server" Text="Prev. Send Store Quantity"></asp:Label>
                                        <span style="color: red; font-size: 14px; text-align: left">*</span>
                                        <asp:TextBox ID="txtSendToStorePrv" Enabled="False" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" autoComplete="off" placeholder="Prev. Sent To Store Quantity"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6 col-sm-6">
                                        <asp:Label ID="Label15" runat="server" Text="Sent To Store Quantity"></asp:Label>
                                        <span style="color: red; font-size: 14px; text-align: left">*</span>
                                        <asp:TextBox ID="txtSendToStoreUpdate" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" autoComplete="off" placeholder="Sent To Store Quantity"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <div class="col-md-12">
                                    <asp:Button ID="btnUpdate" runat="server" class="btn btn-primary form-control pull-right" Text="Update" OnClientClick="return ValidateUpdate();" OnClick="btnUpdate_OnClick" />
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnAdd" />
                <asp:PostBackTrigger ControlID="btnSaves" />
                <asp:PostBackTrigger ControlID="btnUpdate" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>

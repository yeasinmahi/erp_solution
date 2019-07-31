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
        <asp:UpdatePanel ID="UpdatePanel0" runat="server" UpdateMode="Conditional" style="padding-left: 10px; padding-right: 10px">
            <ContentTemplate>

                <div class="container">
                    <asp:HiddenField ID="hdnConfirm" runat="server" />
                    <asp:HiddenField ID="hdnUnit" runat="server" />
                    <asp:HiddenField ID="hdnIndentNo" runat="server" />
                    <asp:HiddenField ID="hdnIndentDate" runat="server" />
                    <asp:HiddenField ID="hdnDueDate" runat="server" />
                    <asp:HiddenField ID="hdnIndentType" runat="server" />
                    <asp:HiddenField ID="hfTotalQty" runat="server" />
                    <asp:HiddenField ID="hdnProductionId" runat="server" />
                    <asp:HiddenField ID="hdnItemId" runat="server" />
                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-xs-12 col-lg-12">
                            <div class="box">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Production Entry</h3>
                                    <div class="box-tools pull-right">
                                        <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                            <i class="fa fa-minus"></i>
                                        </button>
                                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                                    </div>
                                </div>
                                <div class="box-body">
                                    <div class="row">
                                        <div class="col-md-4 col-sm-4 col-xs-12">
                                            <asp:Label runat="server" Text="Date"></asp:Label>
                                            <asp:TextBox ID="txtDate" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" autocomplete="off" placeholder="yyyy/mm/dd"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4 col-sm-4 col-xs-12">
                                            <asp:Label runat="server" Text="Time"></asp:Label>
                                            <asp:TextBox ID="txtTime" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" autocomplete="off" placeholder="HH:MM"></asp:TextBox>
                                        </div>
                                        <div class="col-md-4 col-sm-4 col-xs-12">
                                            <asp:Label runat="server" Text="Job"></asp:Label>
                                            <asp:TextBox ID="txtJob" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" placeholder="Enter Job Here"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <div class="box box-primary">
                                                <div class="box-header with-border">
                                                    <h3 class="box-title">Production</h3>
                                                    <div class="box-tools pull-right">
                                                        <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                                            <i class="fa fa-minus"></i>
                                                        </button>
                                                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                                                    </div>
                                                </div>
                                                <div class="box-body">
                                                    <div class="row">
                                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                                            <asp:Label runat="server" Text="Order Item"></asp:Label>
                                                            <asp:TextBox ID="txtItem" runat="server" Enabled="false" CssClass="form-control col-md-12 col-sm-12 col-xs-12" placeholder="Item Name"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                                            <asp:Label runat="server" Text="Order Qty."></asp:Label>
                                                            <asp:TextBox ID="txtProductQty" runat="server" Enabled="false" CssClass="form-control col-md-12 col-sm-12 col-xs-12" placeholder="Order Quantity"></asp:TextBox>
                                                        </div>
                                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                                            <asp:Label runat="server" Text="Prod. Qty."></asp:Label>
                                                            <asp:TextBox ID="txtGoodsProductionQty" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" placeholder="Production Quantity"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="box-footer">
                                                    <div class="row">
                                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                                            <asp:Button ID="btnAddProduction" runat="server" Text="Add" CssClass="btn btn-primary" OnClientClick="return ValidationProduction()" OnClick="btnAddProduction_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <div class="box box-primary">
                                                <div class="box-header with-border">
                                                    <h3 class="box-title">Others</h3>
                                                    <div class="box-tools pull-right">
                                                        <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                                            <i class="fa fa-minus"></i>
                                                        </button>
                                                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                                                    </div>
                                                </div>
                                                <div class="box-body">
                                                    <div class="row">
                                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                                            <asp:Label runat="server" Text="Other Item"></asp:Label>
                                                            <asp:DropDownList ID="ddlWastageItem" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12"></asp:DropDownList>
                                                        </div>
                                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                                            <asp:Label runat="server" Text="Type"></asp:Label>
                                                            <asp:DropDownList ID="ddlWastageType" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12"></asp:DropDownList>
                                                        </div>
                                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                                            <asp:Label runat="server" Text="Prod. Qty."></asp:Label>
                                                            <asp:TextBox ID="txtWastageQuantity" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" placeholder="Production Quantity"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="box-footer">
                                                    <div class="row">
                                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                                            <asp:Button ID="btnAddOthers" runat="server" Text="Add" CssClass="btn btn-primary" OnClientClick="return ValidationWastage()" OnClick="btnAddOthers_Click"/>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="box-footer">
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success"  OnClick="btnSaves_Click"/>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12 col-sm-12 col-xs-12 col-lg-12">
                            <div class="box">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Previous Entry</h3>
                                    <div class="box-tools pull-right">
                                        <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                            <i class="fa fa-minus"></i>
                                        </button>
                                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                                    </div>
                                </div>
                                <div class="box-body">
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-xs-12">
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
                                                    <asp:TemplateField HeaderText="Production Type" ItemStyle-HorizontalAlign="left">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblProductionType" Width="200px" runat="server" Text='<%# Bind("strType") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="left" />
                                                    </asp:TemplateField>
                                                    <%--<asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="right">
                                            <ItemTemplate>
                                                <asp:Button ID="btnEdit" runat="server" Width="" Text="Edit" CssClass="btn btn-default" OnClick="btnEdit_OnClick"></asp:Button>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>--%>
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
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="box">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Production Entry Report</h3>
                                    <div class="box-tools pull-right">
                                        <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                            <i class="fa fa-minus"></i>
                                        </button>
                                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                                    </div>
                                </div>
                                <div class="box-body">
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <asp:GridView ID="gridViewProductionEntryAdd" runat="server" Width="100%" AutoGenerateColumns="False"
                                                OnRowDeleting="gridViewProductionEntryAdd_RowDeleting"
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
                                                            <asp:Label ID="lblTime" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Order Qty" ItemStyle-HorizontalAlign="right">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblOrderQty" runat="server" Text='<%# Bind("ProductQty","{0:n4}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" Width="65px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Production Qty" ItemStyle-HorizontalAlign="right" Visible="false">
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
                                                    <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" />
                                                </Columns>
                                                <HeaderStyle Height="25px" Font-Size="11pt" BackColor="#0099ff" VerticalAlign="Middle" />
                                                <RowStyle BorderStyle="Solid" BorderWidth="1px" Font-Size="10pt" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%--<div class="box">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Others Entry Report</h3>
                                    <div class="box-tools pull-right">
                                        <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                            <i class="fa fa-minus"></i>
                                        </button>
                                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                                    </div>
                                </div>
                                <div class="box-body">
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <asp:GridView ID="gridViewWastage" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="false" PageSize="8" ShowFooter="True"
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
                                        </div>
                                    </div>
                                </div>
                            </div>--%>
                        </div>
                    </div>
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
                <asp:PostBackTrigger ControlID="btnAddProduction" />
                <asp:PostBackTrigger ControlID="btnAddOthers" />
                <%--<asp:PostBackTrigger ControlID="btnSaves" />
                <asp:PostBackTrigger ControlID="btnUpdate" />--%>
            </Triggers>
        </asp:UpdatePanel>
    </form>
    <script type="text/javascript">
        $(function () {
            Init();
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(Init);
        });
        function Init() {
            $('#txtDate').datepicker({
                dateFormat: 'yy/mm/dd'
            });
            $('#txtTime').timepicker({
                 timeFormat: 'HH:mm'
            });
        }
    </script>
</body>
</html>

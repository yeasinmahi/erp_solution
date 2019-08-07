<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductionOrderNew.aspx.cs" Inherits="UI.SCM.BOM.ProductionOrderNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Production Order</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link href="../../Content/CSS/bootstrap.min.css" rel="stylesheet" />
    <script src="../../Content/JS/bootstrap.min.js"></script>
    <script src="../../Content/JS/jquery-3.3.1.js"></script>
    <link href="../../Content/font-awesome.min.css" rel="stylesheet" />
    <link href="../../Content/CSS/AdminLTE.css" rel="stylesheet" />
    <script src="../../Content/JS/adminlte.min.js"></script>
    <link href="../../Content/CSS/mainsite.css" rel="stylesheet" />
</head>
<body>
    <form id="frmProductionOrder" runat="server">
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
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <asp:HiddenField runat="server" ID="hfUnitID" />
                <asp:HiddenField runat="server" ID="hfConfirm" />
                <div class="container">
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title">Production Order</h3>
                            <div class="box-tools pull-right">
                                <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                    <i class="fa fa-minus"></i>
                                </button>
                                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                            </div>
                        </div>
                        <div class="box-body">
                            <div class="row">
                                <div class="col-md-4 col-sm-6 col-xs-6">
                                    <div class="form-group form-group-sm">
                                        <asp:Label runat="server" Text="Ware House :" CssClass="control-label col-sm-5 text-right"></asp:Label>
                                        <div class="col-sm-7 pl-0">
                                            <asp:DropDownList ID="ddlWareHouse" runat="server" CssClass="form-control dw-100" AutoPostBack="true" OnSelectedIndexChanged="ddlWareHouse_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-6 col-xs-6">
                                    <div class="form-group form-group-sm">
                                        <asp:Label runat="server" Text="Item :" CssClass="control-label col-sm-5 text-right"></asp:Label>
                                        <div class="col-sm-7 pl-0">
                                            <asp:TextBox ID="txtItem" runat="server" CssClass="form-control tw-100" AutoCompleteType="Search"
                                                AutoPostBack="true" OnTextChanged="txtItem_TextChanged" AutoComplete="off">
                                            </asp:TextBox>
                                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtItem"
                                                ServiceMethod="GetItemSerach" MinimumPrefixLength="1" CompletionSetCount="1"
                                                CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" 
                                                CompletionListCssClass="autocomplete_completionListElementBig"
                                                CompletionListItemCssClass="autocomplete_listItem" 
                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                            </cc1:AutoCompleteExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-6 col-xs-6">
                                    <div class="form-group form-group-sm">
                                        <asp:Label runat="server" Text="Batch No :" CssClass="control-label col-sm-5 text-right"></asp:Label>
                                        <div class="col-sm-7 pl-0">
                                            <asp:TextBox ID="txtBatchNo" runat="server" CssClass="form-control tw-100" AutoComplete="off"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-6 col-xs-6">
                                    <div class="form-group form-group-sm">
                                        <asp:Label runat="server" Text="Quantity :" CssClass="control-label col-sm-5 text-right"></asp:Label>
                                        <div class="col-sm-7 pl-0">
                                            <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control tw-100" AutoComplete="off"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-6 col-xs-6">
                                    <div class="form-group form-group-sm">
                                        <asp:Label runat="server" Text="BOM :" CssClass="control-label col-sm-5 text-right"></asp:Label>
                                        <div class="col-sm-7 pl-0">
                                            <asp:DropDownList ID="ddlBOM" runat="server" CssClass="form-control dw-100"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-6 col-xs-6">
                                    <div class="form-group form-group-sm">
                                        <asp:Label runat="server" Text="Line No :" CssClass="control-label col-sm-5 text-right"></asp:Label>
                                        <div class="col-sm-7 pl-0">
                                            <asp:DropDownList ID="ddlLineNo" runat="server" CssClass="form-control dw-100"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-6 col-xs-6">
                                    <div class="form-group form-group-sm">
                                        <asp:Label runat="server" Text="Date :" CssClass="control-label col-sm-5 text-right"></asp:Label>
                                        <div class="col-sm-7 pl-0">
                                            <asp:TextBox ID="txtDate" runat="server" CssClass="form-control tw-100" AutoComplete="off"></asp:TextBox>
                                            <cc1:CalendarExtender runat="server" ID="calen1" TargetControlID="txtDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-6 col-xs-6">
                                    <div class="form-group form-group-sm">
                                        <asp:Label runat="server" Text="Time :" CssClass="control-label col-sm-5 text-right"></asp:Label>
                                        <div class="col-sm-7 pl-0">
                                            <asp:DropDownList ID="ddlFromTime" runat="server" CssClass="form-control dw-50 fl"></asp:DropDownList>
                                            <asp:DropDownList ID="ddlToTime" runat="server" CssClass="form-control dw-49 fl"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-6 col-xs-6">
                                    <div class="form-group form-group-sm">
                                        <asp:Label runat="server" Text="Invoice :" CssClass="control-label col-sm-5 text-right"></asp:Label>
                                        <div class="col-sm-7 pl-0">
                                            <asp:TextBox ID="txtInvoice" runat="server" CssClass="form-control tw-100" AutoComplete="off"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="box-footer">
                            <div class="row" style="float: right">
                                <div class="col-md-12 col-sm-12 col-xs-12">
                                    <asp:Button ID="btnAddProductionOrder" runat="server" Text="ADD" CssClass="btn btn-success  btn-sm" OnClick="btnAddProductionOrder_Click" />
                                    <asp:Button ID="btnSubmitProductionOrder" runat="server" Text="Submit" CssClass="btn btn-primary btn-sm" OnClientClick="Confirms();" OnClick="btnSubmitProductionOrder_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="box box-info">
                        <div class="box box-body">
                            <asp:GridView ID="dgvBom" runat="server" AutoGenerateColumns="False"
                                OnRowDeleting="dgvBom_RowDeleting" CssClass="Grid" 
                                AlternatingRowStyle-CssClass="alt"
                                PagerStyle-CssClass="pgr">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SL No.">
                                        <ItemStyle HorizontalAlign="center" Width="30px" />
                                        <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Product ID" Visible="false" SortExpression="itemid">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemID" runat="server" Text='<%# Bind("itemID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="45px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Product Name" SortExpression="item">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("itemName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Start Time">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFromTime" runat="server" Text='<%# Bind("fromTime") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="End Time">
                                        <ItemTemplate>
                                            <asp:Label ID="lblToTime" runat="server" Text='<%# Bind("toTime" ) %>'></asp:Label>
                                        </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Left" Width="100px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="right" SortExpression="wasquantitytage">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQuantity" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("quantity") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="BOM Used" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="bomname">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBomUsed" runat="server" Text='<%# Bind("bomName") %>'></asp:Label>
                                        </ItemTemplate>
                                       <ItemStyle HorizontalAlign="Left" Width="250px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Batch" ItemStyle-HorizontalAlign="right" SortExpression="strCode">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBatch" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("batch") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Invoice No" ItemStyle-HorizontalAlign="right" SortExpression="strCinvoiceode">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInvoice" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("invoice") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Line/Process/Machine">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLine" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("lineName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:CommandField ShowDeleteButton="True" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" />
                                </Columns>
                                <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    <script type="text/javascript">
        function Confirms() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) {
                confirm_value.value = "Yes";
                document.getElementById("hfConfirm").value = "1";
            } else {
                confirm_value.value = "No";
                document.getElementById("hfConfirm").value = "0";
            }

        }
    </script>
</body>
</html>

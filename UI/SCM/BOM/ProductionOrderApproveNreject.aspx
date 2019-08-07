<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductionOrderApproveNreject.aspx.cs" Inherits="UI.SCM.BOM.ProductionOrderApproveNreject" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Production Order Approved & Reject</title>
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
    <form id="frmProductionOrderApprovedNreject" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1"
                            width="100%">
                            <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                        </marquee>
                    </div>
                </asp:Panel>
                <div style="height: 30px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <asp:HiddenField runat="server" ID="hfConfirm" />
                <asp:HiddenField runat="server" ID="hfUnitID" />
                <div class="container">
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title">Production Order Approved & Reject</h3>
                            <div class="box-tools pull-right">
                                <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                    <i class="fa fa-minus"></i>
                                </button>
                                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                            </div>
                        </div>
                        <div class="box-body">
                            <div class="row">
                                <div class="col-md-6 col-sm-6 col-xs-6">
                                    <div class="form-group form-group-sm">
                                        <asp:Label runat="server" Text="Ware House :" CssClass="control-label col-sm-5 text-right"></asp:Label>
                                        <div class="col-sm-7 pl-0">
                                            <asp:DropDownList ID="ddlWareHouse" runat="server" CssClass="form-control dw-100"
                                                AutoPostBack="true" OnSelectedIndexChanged="ddlWareHouse_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-6 col-xs-6">
                                    <div class="form-group form-group-sm">
                                        <asp:Label runat="server" Text="Data For :" CssClass="control-label col-sm-5 text-right"></asp:Label>
                                        <div class="col-sm-7 pl-0">
                                            <asp:DropDownList ID="ddlDataFor" runat="server" CssClass="form-control dw-100">
                                                <asp:ListItem Value="-1">--- Select Data For ---</asp:ListItem>
                                                <asp:ListItem Value="1">Approve</asp:ListItem>
                                                <asp:ListItem Value="2">Not Approve</asp:ListItem>
                                                <asp:ListItem Value="3">Reject</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-6 col-xs-6">
                                    <div class="form-group form-group-sm">
                                        <asp:Label runat="server" Text="From Date :" CssClass="control-label col-sm-5 text-right"></asp:Label>
                                        <div class="col-sm-7 pl-0">
                                            <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control tw-100" AutoComplete="off"></asp:TextBox>
                                            <cc1:CalendarExtender runat="server" ID="calen1" TargetControlID="txtFromDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6 col-sm-6 col-xs-6">
                                    <div class="form-group form-group-sm">
                                        <asp:Label runat="server" Text="To Date :" CssClass="control-label col-sm-5 text-right"></asp:Label>
                                        <div class="col-sm-7 pl-0">
                                            <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control tw-100" AutoComplete="off"></asp:TextBox>
                                            <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtToDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="box-footer">
                            <div class="row" style="float: right">
                                <div class="col-md-12 col-sm-12 col-xs-12">
                                    <asp:Button ID="btnShowProductionOrder" runat="server" Text="Show Production Order" CssClass="btn btn-success  btn-sm" OnClick="btnShowProductionOrder_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="box box-primary">
                        <div class="box box-body">
                            <asp:GridView ID="dgvBom" runat="server" AutoGenerateColumns="False" CssClass="Grid"
                                AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SL No.">
                                        <ItemStyle HorizontalAlign="center" Width="20px" />
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                            <asp:HiddenField ID="hfProductID" runat="server" Value='<%# Bind("intItemID") %>'/>
                                            <asp:HiddenField ID="hfUnitID" runat="server" Value='<%# Bind("intUnitID") %>'/>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Prod. ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProductiontID" runat="server" Text='<%# Bind("intPOID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="45px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnit" runat="server" Text='<%# Bind("strUnit") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="45px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Ware House">
                                        <ItemTemplate>
                                            <asp:Label ID="lblWareHouse" runat="server" Text='<%# Bind("strWareHoseName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="45px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Item Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("strItem") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="300px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="BOM Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBomName" runat="server" Text='<%# Bind("BoMName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Batch No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBatch" runat="server" Width="100px" Text='<%# Bind("strBatchNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Start Time">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStartTime" Width="100px" runat="server" Text='<%# Bind("dteStartTime") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="End Time">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEndTime" Width="100px" runat="server" Text='<%# Bind("dteEndTime" ) %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Invoice No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInvoice" runat="server" Width="60px" Text='<%# Bind("strInvoice" ) %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="SR NO" ItemStyle-HorizontalAlign="right" SortExpression="strCode">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSrNO" runat="server" Width="90px" Text='<%# Bind("strCode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="right" SortExpression="numOrderQty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQuantity" runat="server" Width="80px" Text='<%# Eval("numOrderQty","{0:n4}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Line/ Process/ Machine" ItemStyle-HorizontalAlign="right" SortExpression="strplantname">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLine" runat="server" Text='<%# Bind("strplantname") %>' Width="90px"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" Width="40px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Approve">
                                        <ItemTemplate>
                                            <asp:Button ID="btnApprove" ForeColor="Black" BackColor="#33cc33" runat="server" OnClientClick="return confirmMsg();" OnClick="btnApprove_Click" Text="Approve"></asp:Button><br />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Reject">
                                        <ItemTemplate>
                                            <asp:Button ID="btnReject" ForeColor="Red" runat="server" OnClientClick="return confirmMsg();" OnClick="btnReject_Click" Text="Reject"></asp:Button>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Details">
                                        <ItemTemplate>
                                            <asp:Button ID="btnShowDetails" ForeColor="Black" BackColor="#33cc33" runat="server" OnClick="btnShowDetails_Click" Text="Details"></asp:Button><br />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
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

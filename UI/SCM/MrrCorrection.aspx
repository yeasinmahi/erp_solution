<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MrrCorrection.aspx.cs" Inherits="UI.SCM.MrrCorrection" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html>
<head runat="server">
    <title>MRR Correction</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/updatedJs") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/updatedCss" />
</head>
<body>
    <form id="form1" runat="server">
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
                <%--=========== Start Code =====================================================================--%>
                <asp:HiddenField ID="hdnconfirm" runat="server" />
                <asp:HiddenField ID="hdnWHID" runat="server" />
                <asp:HiddenField ID="hdnMrrUnitID" runat="server" />
                <div class="container">
                    <asp:HiddenField runat="server" ID="hdnSearch" />
                    <asp:HiddenField runat="server" ID="hdnEmployeeName" />
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="MRR Correction" Font-Bold="true" Font-Size="16px"></asp:Label>

                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label20" runat="server" Text="MRR NO."></asp:Label>
                                    <span style="color: red; font-size: 14px; text-align: left">*</span>
                                    <asp:TextBox ID="txtMrrNo" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Write MRR no here"></asp:TextBox>

                                </div>
                                <div class="col-md-6 col-sm-6" style="padding-top: 16px">
                                    <asp:Button ID="btnShow" runat="server" class="btn btn-primary form-control pull-right" Text="Show" OnClick="btnShow_Click" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label8" runat="server" Text="Warehouse"></asp:Label>
                                    <asp:TextBox ID="txtWhName" Enabled="False" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Ware House"></asp:TextBox>

                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label9" runat="server" Text="Supplier"></asp:Label>
                                    <asp:TextBox ID="txtSupplierName" Enabled="False" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Supplier Name"></asp:TextBox>

                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label10" runat="server" Text="MRR Date"></asp:Label>
                                    <asp:TextBox ID="txtMrrDate" Enabled="False" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="MRR Date"></asp:TextBox>

                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label11" runat="server" Text="PO"></asp:Label>
                                    <asp:TextBox ID="txtPo" Enabled="False" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Purchase Order"></asp:TextBox>

                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label12" runat="server" Text="Voucher No"></asp:Label>
                                    <asp:TextBox ID="txtVoucherNo" Enabled="False" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" autoComplete="off" placeholder="Voucher No."></asp:TextBox>
                                </div>

                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label13" runat="server" Text="Status"></asp:Label>
                                    <asp:TextBox ID="txtStatus" Enabled="False" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Status"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="panel panel-info hidden" id="itemPanel">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="MRR Details" Font-Bold="true" Font-Size="16px"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <asp:GridView ID="dgvItem" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="8"
                                CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SL." ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ItemName" HeaderText="Item Name" ItemStyle-HorizontalAlign="Center" SortExpression="strItemName" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Left" Width="350px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="strUoM" HeaderText="UOM" ItemStyle-HorizontalAlign="Center" SortExpression="strUOM">
                                        <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="POQty" HeaderText="PO Quantity" ItemStyle-HorizontalAlign="Center" SortExpression="POQty" HeaderStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="POValue" HeaderText="PO Value" ItemStyle-HorizontalAlign="Center" SortExpression="POValue">
                                        <ItemStyle HorizontalAlign="Left" Width="130px" />
                                    </asp:BoundField>
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#808080" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#383838" />
                            </asp:GridView>
                        </div>

                    </div>

                    <div class="panel panel-info">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-4 col-sm-4 col-xs-4">
                                    <asp:Button ID="btnDeleteJv" runat="server" class="btn btn-primary form-control pull-left" Text="Delete JV" OnClick="btnDeleteJV_Click" />
                                </div>
                                <div class="col-md-4 col-sm-4 col-xs-4 text-center">
                                    <asp:Button ID="btnFreeMrr" runat="server" class="btn btn-primary form-control" Text="Free MRR" OnClick="btnFreeMRR_Click" />
                                </div>
                                <div class="col-md-4 col-sm-4 col-xs-4">
                                    <asp:Button ID="btnDeleteMrr" runat="server" class="btn btn-primary form-control pull-right" Text="Delete MRR" OnClick="btnDeleteMRR_Click" />
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <%--=========== End Code =====================================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    <script>
        function showPanel() {
            var itemPanel = document.getElementById("divItemInfo");
            itemPanel.classList.remove("hidden");
            return true;
        }
    </script>
</body>
</html>

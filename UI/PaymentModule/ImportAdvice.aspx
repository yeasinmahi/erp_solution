<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportAdvice.aspx.cs" Inherits="UI.PaymentModule.ImportAdvice" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Information</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/updatedJs") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/updatedCss" />
    <style>
        body {
            font-size: 12px
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel0" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                        <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                </asp:Panel>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <div style="height: 30px; width: 100%"></div>

                <%--=========================================Start My Code From Here===============================================--%>
                <div class="container">
                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-xs-12 col-lg-12">
                            <div class="box">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Import Advice</h3>
                                    <div class="box-tools pull-right">
                                        <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                            <i class="fa fa-minus"></i>
                                        </button>
                                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                                    </div>
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body">
                                    <div class="row">
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:Label runat="server" Text="Unit"></asp:Label>
                                            <asp:DropDownList ID="ddlUnit" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:Label runat="server" Text="Date"></asp:Label>
                                            <asp:TextBox ID="txtDate" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" autocomplete="off" placeholder="yyyy/MM/dd"></asp:TextBox>
                                        </div>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:Label runat="server" Text="Bank"></asp:Label>
                                            <asp:DropDownList ID="ddlbank" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" AutoPostBack="true" OnSelectedIndexChanged="ddlbank_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:Label runat="server" Text="Advice For"></asp:Label>
                                            <asp:DropDownList ID="ddlAdvice" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="box-footer">
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-primary" OnClientClick="return Validation()" OnClick="btnShow_Click" />
                                            <asp:Button ID="btnCreateVoucher" runat="server" Text="Create" CssClass="btn btn-success" OnClick="btnCreateVoucher_Click" />
                                            <asp:Button ID="btnPrintPreview" runat="server" Text="Print Preview" CssClass="btn btn-info" OnClick="btnPrintPreview_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12 col-sm-12 col-xs-12 col-lg-12">
                            <div class="box">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Import Advice Details</h3>
                                    <div class="box-tools pull-right">
                                        <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                            <i class="fa fa-minus"></i>
                                        </button>
                                        <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                                    </div>
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body">
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <asp:GridView ID="gridview" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" Width="100%" GridLines="Both">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SL">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Request Type">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblType" runat="server" Text='<%# Bind("strType") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Description">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("strDescription") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Debiting Amount">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("monAmount") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Request Id">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRequestId" runat="server" Text='<%# Bind("intReqID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Pay For">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPayFor" runat="server" Text='<%# Bind("intPayFor") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Voucher">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblVoucher" runat="server" Text='<%# Bind("strVoucher") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="100px" />
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
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12 col-sm-12 col-xs-12 col-lg-12">
                            <iframe runat="server" oncontextmenu="return false;" id="frame" name="frame" style="width: 100%; height: 1000px; border: 0px solid red;"></iframe>
                        </div>
                    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    <script type="text/javascript">
        $(function () {

            Init();
            //ShowHideGridviewPanels();
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(Init);
            //Sys.WebForms.PageRequestManager.getInstance().add_endRequest(ShowHideGridviewPanels);
        });
        function Init() {
            $('#txtDate').datepicker({
                dateFormat: 'yy/mm/dd'
            });
        }
        function Validation() {
            var txtDate = document.getElementById("txtDate").value;
            var ddlAdvice = document.getElementById("ddlAdvice");
            var advice = ddlAdvice.options[ddlAdvice.selectedIndex].value;

            if (txtDate === null || txtDate === "") {
                ShowNotification('Enter Date Properly', 'Import Advice', 'warning');
                return false;
            }
            if (advice === null || advice === "") {
                ShowNotification('Select An Advice Properly', 'Import Advice', 'warning');
                return false;
            }
        }
    </script>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarryingBillJV.aspx.cs" Inherits="UI.SAD.Sales.Report.CarryingBillJV" %>

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
                                    <h3 class="box-title">Carrying Bill &amp; JV</h3>
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
                                            <asp:Label runat="server" Text="Rate"></asp:Label>
                                            <asp:TextBox ID="txtRate" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" autocomplete="off" placeholder="Rate Entry"></asp:TextBox>
                                        </div>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:Label runat="server" Text="From Date"></asp:Label>
                                            <asp:TextBox ID="txtDate" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" autocomplete="off" placeholder="yyyy/MM/dd"></asp:TextBox>
                                        </div>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                           <asp:Label runat="server" Text="To Date"></asp:Label>
                                            <asp:TextBox ID="txttdate" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" autocomplete="off" placeholder="yyyy/MM/dd"></asp:TextBox>
                                        </div>
                                       
                                    </div>
                                </div>
                                <div class="box-footer">
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-primary"  OnClick="btnShow_Click" />
                                            <asp:Button ID="btnCreateVoucher" runat="server" Text="Create" CssClass="btn btn-success" OnClick="btnCreateVoucher_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12 col-sm-12 col-xs-12 col-lg-12">
                            <div class="box">
                                <div class="box-header with-border">
                                    <h3 class="box-title">&nbsp;</h3>
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
                                            
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12 col-sm-12 col-xs-12 col-lg-12">
                            <iframe runat="server" oncontextmenu="return false;" id="frame" name="frame" style="width: 100%; height: 1000px; border: 1px solid black;"></iframe>
                        </div>
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
             $('#txttdate').datepicker({
                dateFormat: 'yy/mm/dd'
            });
        }
      
    </script>
</body>
</html>

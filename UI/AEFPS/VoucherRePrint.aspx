<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VoucherRePrint.aspx.cs" Inherits="UI.AEFPS.VoucherRePrint" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Voucher Re-Print</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />

    <link href="../Content/CSS/bootstrap.min.css" rel="stylesheet" />

    
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel0" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                        <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                </asp:Panel>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <div style="height: 50px; width: 100% "></div>
                <%--=========================================Start My Code From Here===============================================--%>
                <div class="container">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Voucher Re-Print" Font-Bold="true" Font-Size="16px"></asp:Label> 
                            
                        </div>
                        <div class="panel-body">
                            <div class="row form-group">
                                <div class="col-md-6">
                                    <div class="col-md-12">
                                        <asp:Label ID="Label20" runat="server" Text="WareHouse Name"></asp:Label>
                                        <span style="color: red; font-size: 14px; text-align: left">*</span>
                                    </div>
                                    <div class="col-md-12">
                                        <asp:DropDownList ID="ddlWh" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-12">
                                        <asp:Label ID="Label1" runat="server" Text="Voucher Number"></asp:Label>
                                        <span style="color: red; font-size: 14px; text-align: left">*</span>
                                    </div>
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtSV" CssClass="form-control col-md-2 col-sm-2 col-xs-2" Enabled="False" runat="server" Text="SV"></asp:TextBox>
                                        <asp:TextBox ID="txtVoucherName" TextMode="Number" CssClass="form-control col-md-10 col-sm-10 col-xs-10" runat="server" placeholder="Please Input Voucher Number Here"></asp:TextBox>
                                    </div>
                                    
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-12 btn-toolbar">
                                        <asp:Button ID="btnClearPrint" runat="server" class="btn btn-primary form-control pull-right" Text="Clear Printer" OnClick="btnClearPrint_OnClick" />
                                        <asp:Button ID="btnRePrint" runat="server" class="btn btn-primary form-control pull-right" Text="Re-Print" OnClientClick="return Validate();" OnClick="btnRePrint_OnClick" />
                                    </div>
                                </div>
                                
                            </div>
                        </div>
                    </div>
                </div>
                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnRePrint" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnClearPrint" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>

    </form>
    <script>
        function Validate() {
            var txtVoucherName = document.getElementById("txtVoucherName").value;

            if (txtVoucherName === null || txtVoucherName === "") {
                alert("Voucher number can not be empty");
                return false;
            }
            return true;
        }

    </script>
</body>
</html>



<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vat_Print_Mushak.aspx.cs" Inherits="UI.Vat.Vat_Print_Mushak" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>Employee Information Report</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/updatedJs") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/updatedCss" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel0" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                        <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                </asp:Panel>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server"></cc1:AlwaysVisibleControlExtender>
                <div style="height: 50px; width: 100%"></div>
                <%--=========================================Start My Code From Here===============================================--%>
                <div class="container-fluid">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Vat Print Mushak 6.3 and 6.5" Font-Bold="true" Font-Size="16px"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <div class="row form-group">    
                                 <div class="col-md-3">
                                      <asp:Label ID="Label1" runat="server" Text="Unit" CssClass="col-md-12 col-sm-12 col-xs-12"></asp:Label>
                                      <asp:DropDownList ID="ddlUnit" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" AutoPostBack="True" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged">
                                       
                                      </asp:DropDownList>
                                 </div>
                                <div class="col-md-3">
                                    <asp:Label ID="Label3" runat="server" Text="Shipping Point" CssClass="col-md-12 col-sm-12 col-xs-12"></asp:Label>
                                    <asp:DropDownList ID="ddlShipPoint" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" AutoPostBack="True" OnSelectedIndexChanged="ddlShipPoint_OnSelectedIndexChanged">
                                       
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <asp:Label ID="Label4" runat="server" Text="Type" CssClass="col-md-12 col-sm-12 col-xs-12"></asp:Label>
                                    <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" AutoPostBack="True" OnSelectedIndexChanged="ddlType_OnSelectedIndexChanged"> 
                                        <asp:ListItem Value="0">--Select Type--</asp:ListItem>
                                        <asp:ListItem Value="1">Sales</asp:ListItem>
                                        <asp:ListItem Value="2">Transfer</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                      <asp:Label ID="Label2" runat="server" Text="Challan" CssClass="col-md-12 col-sm-12 col-xs-12"></asp:Label>
                                      <asp:DropDownList ID="ddlChallan" runat="server" CssClass="form-control col-md-6 col-sm-6 col-xs-6" AutoPostBack="True" OnSelectedIndexChanged="ddlChallan_OnSelectedIndexChanged">                                      
                                      </asp:DropDownList>
                                    <asp:TextBox runat="server" ID="txtChallanNo" CssClass="form-control col-md-6 col-sm-6 col-xs-6"></asp:TextBox>
                                 </div>
                                <div class="col-md-3 hidden">
                                    <asp:Label ID="Label5" runat="server" Text="Actual Delivery Date"></asp:Label>
                                    <asp:TextBox runat="server" ID="txtActualDeliveryDate" CssClass="form-control col-md-12 col-sm-12 col-xs-12" placeholder="Actual Delivery Date" autocomplete="off"></asp:TextBox>
                                </div>
                                <div class="col-md-3 hidden">
                                    <asp:Label ID="Label6" runat="server" Text="Customer BIN No"></asp:Label>
                                    <asp:TextBox runat="server" ID="txtCustomerBinNo" CssClass="form-control col-md-12 col-sm-12 col-xs-12" placeholder="Customer BIN No"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <asp:Label ID="Label7" runat="server" Text="Destination"></asp:Label>
                                    <asp:TextBox runat="server" ID="txtFinalAddress" CssClass="form-control col-md-12 col-sm-12 col-xs-12" placeholder="Destination"></asp:TextBox>
                                </div>
                                <div class="col-md-3 hidden">
                                    <asp:Label ID="Label8" runat="server" Text="Vehicle No"></asp:Label>
                                    <asp:TextBox runat="server" ID="txtVehicleNo" CssClass="form-control col-md-12 col-sm-12 col-xs-12" placeholder="Vehicle No"></asp:TextBox>
                                </div>
                                <div class="col-md-3 hidden">
                                    <asp:Label ID="Label9" runat="server" Text="Vat Challan No"></asp:Label>
                                    <asp:TextBox runat="server" ID="txtVatChallanNo" CssClass="form-control col-md-12 col-sm-12 col-xs-12" placeholder="Vat Challan No"></asp:TextBox>
                                </div>
                                <div class="col-md-3 hidden">
                                    <asp:Label ID="Label10" runat="server" Text="Customer Name"></asp:Label>
                                    <asp:TextBox runat="server" ID="txtCustomerName" CssClass="form-control col-md-12 col-sm-12 col-xs-12" placeholder="Customer Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3" >   
                                    <asp:Button ID="btnSave" runat="server" class="btn btn-primary form-control pull-left" OnClientClick="showLoader();" Text="Save" OnClick="btnSave_OnClick"/>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div>
                    <iframe runat="server" oncontextmenu="return false;" id="frame" name="frame" style="width: 100%; height: 1000px; border: 0px solid red;"></iframe>
                </div>

                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    <script>
        $(document).ready(function () {
            Init();
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_initializeRequest(Init);
        });
        function Init() {
            $("#txtActualDeliveryDate").datepicker({
                dateFormat: "yy-mm-dd"
            });
        }
        function validation() {
            var e = document.getElementById("ddlChallan");
            var value = e.options[e.selectedIndex].value;
            var challanNo = document.getElementById("txtchallanno").value;
            if ((value === null || value === "0") || challanNo === null || challanNo ==="") {
                ShowNotification('Select a challan or Write Manual challan no', 'Vat Print Mushak', 'warning');
                return false;
            }
            showLoader();
            return true;
        }
        function loadIframe(iframeName, url) {
            var $iframe = $('#' + iframeName);
            if ($iframe.length) {
                $iframe.attr('src', url);
                return false;
            }
            return true;
        }
    </script>
</body>
</html>


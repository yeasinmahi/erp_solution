<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryAdjustmentApproval.aspx.cs" Inherits="UI.SCM.Transfer.InventoryAdjustmentApproval" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>.:  :.</title>

    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/updatedJs") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/updatedCss" />
</head>
<body>
    <form id="frmattendancedetails" runat="server">
        <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server"></asp:ScriptManager>
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
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender2" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <%--=========================================Start My Code From Here===============================================--%>

                <div class="container pull-left">
                    <asp:HiddenField ID="hdnEnroll" runat="server" />
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Inventory Adjustment Approval" Font-Bold="true" Font-Size="16px"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <div class="row form-group">
                                <div class="col-md-3">
                                    <asp:Label ID="Label3" runat="server" Text="WH Name:" CssClass="row col-md-12 col-sm-12 col-xs-12"></asp:Label>
                                   <%-- <asp:DropDownList ID="ddlWH" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>--%>
                                    <asp:DropDownList ID="ddlWh" runat="server"  CssClass="form-control" OnSelectedIndexChanged="ddlWh_SelectedIndexChanged"
                                     AutoPostBack="True">
                                </asp:DropDownList>
                                </div>
                                <%--<div class="col-md-3">
                                    <asp:Label ID="Label1" runat="server" Text="From Date:" CssClass="row col-md-12 col-sm-12 col-xs-12"></asp:Label>
                                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" autocomplete="off" placeholder="yyyy-MM-dd"></asp:TextBox>
                                    <cc1:CalendarExtender ID="fd" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender>
                                </div>

                                <div class="col-md-3">
                                    <asp:Label ID="Label2" runat="server" Text="To Date:" CssClass="row col-md-12 col-sm-12 col-xs-12"></asp:Label>
                                    <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" autocomplete="off" placeholder="yyyy-MM-dd"></asp:TextBox>
                                    <cc1:CalendarExtender ID="td" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender>
                                </div>--%>
                                 <div class="col-md-3 hidden" id="levelPanel">
                                    <asp:Label ID="Label2" runat="server" Text="Select lavel:" CssClass="row col-md-12 col-sm-12 col-xs-12"></asp:Label>
                                    <asp:DropDownList ID="ddlLevel" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" >
                                        <asp:ListItem Text="Level1" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Level2" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                    
                                </div>
                                <div class="col-md-3" id="showbuttonDiv" style="padding-top: 20px;">
                                    <asp:Button ID="btnShow" runat="server" class="btn btn-primary form-control pull-left" Text="Show" OnClientClick="showLoader()" OnClick="btnShow_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-info hidden" id="panel">
                        <div class="panel-heading">
                            <asp:Label ID="lblHeader" runat="server" Text="Inventory Adjustment Approval" Font-Bold="true" Font-Size="16px"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2">

                                <Columns>
                                    <asp:TemplateField HeaderText="Auto ID" SortExpression="intautoid">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAutoID" runat="server" CssClass="lbl" Text='<%# Bind("intID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item ID" SortExpression="intproductionid">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItmId" runat="server" CssClass="lbl" Text='<%# Bind("intItemID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity" SortExpression="strItem">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNumQty" runat="server" CssClass="lbl" Text='<%# Bind("numQty") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rate" SortExpression="intItemID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMonRate" runat="server" CssClass="lbl" Text='<%# Bind("monRate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total" SortExpression="strUoM">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstrUoM" runat="server" CssClass="lbl" Text='<%# Bind("monTotal") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Location Id" Visible="False" SortExpression="strUoM">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIntLocationID" runat="server" CssClass="lbl" Text='<%# Bind("intLocationID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Location">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIntLocationName" runat="server" CssClass="lbl" Text='<%# Bind("strLocationName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ware House" Visible="False" SortExpression="strUoM">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIntWHID" runat="server" CssClass="lbl" Text='<%# Bind("intWHID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>

                                    <%-- <asp:TemplateField HeaderText="Quantity" SortExpression="strUoM">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNumQty" runat="server" CssClass="lbl" Text='<%# Bind("numQty") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>--%>
                                   

                                    <asp:TemplateField HeaderText="Unit" Visible="False" SortExpression="strUoM">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnitId" runat="server" CssClass="lbl" Text='<%# Bind("intUnitID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Store Qty" SortExpression="numSendStoreQty">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtSendStoreQty" runat="server" Text='<%# Bind("numSendStoreQty","{0:N4}") %>' Width="100%" CssClass="form-control input-xs text-right" onkeypress="if ( isNaN( String.fromCharCode(event.keyCode) )) return false;"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>--%>
                                    <%--<asp:TemplateField HeaderText="LastActionTime">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLastActionTime" runat="server" CssClass="lbl" Text='<%# Bind("Column1") %>' DataFormatString="{0:YYYY-MM-DD hh:mm:ss}"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>--%>
                                 
                                    <asp:TemplateField HeaderText="Remarks" SortExpression="strUoM">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstrReceiveRemarks" runat="server" CssClass="lbl" Text='<%# Bind("strReceiveRemarks") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="true" HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:Button ID="btnApprove" runat="server" OnClick="btnApprove_Click" OnClientClick="showLoader();" Text="Approve" CssClass="btn btn-success btn-xs"></asp:Button>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>

                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
        <script>
            $(document).ready(function () {
                Init();
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(Init);

            });
            function Init() {
                $("#txtFormTime").timepicker();
                $("#txtToTime").timepicker();
            }
            function Validation() {
                var txtFromDate = document.getElementById("txtFromDate").value;
                var txtToDate = document.getElementById("txtToDate").value;

                if (txtFromDate == "") {
                    ShowNotification("From date can not be blank", "FG Receive", "warning");
                    return false;
                } else if (txtToDate == "") {
                    ShowNotification("To date can not be blank", "FG Receive", "warning");
                    return false;
                }
                return true;
            }
        </script>
    </form>
</body>
</html>

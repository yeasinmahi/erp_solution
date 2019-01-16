<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Distribution_Receive.aspx.cs" Inherits="UI.SCM.Distribution_Receive" %>

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
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
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
                            <asp:Label runat="server" Text="Distribution Receive" Font-Bold="true" Font-Size="16px"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <div class="row form-group">
                                <div class="col-md-3">
                                    <asp:Label ID="Label3" runat="server" Text="Ware House" CssClass="row col-md-12 col-sm-12 col-xs-12"></asp:Label>
                                    <asp:DropDownList ID="ddlWH" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <div class="col-md-3">
                                    <asp:Label ID="Label1" runat="server" Text="From Date" CssClass="row col-md-12 col-sm-12 col-xs-12"></asp:Label>
                                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" autocomplete="off" placeholder="yyyy-MM-dd"></asp:TextBox>
                                    <cc1:CalendarExtender ID="fd" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender>
                                </div>

                                <div class="col-md-3">
                                    <asp:Label ID="Label2" runat="server" Text="To Date" CssClass="row col-md-12 col-sm-12 col-xs-12"></asp:Label>
                                    <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" autocomplete="off" placeholder="yyyy-MM-dd" onkeypress="if ( isNaN( String.fromCharCode(event.keyCode) )) return false;"></asp:TextBox>
                                    <cc1:CalendarExtender ID="td" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender>
                                </div>
                                <div class="col-md-3 btn-toolbar" id="showbuttonDiv" style="padding-top: 20px;">
                                    <asp:Button ID="btnShow" runat="server" class="btn btn-primary form-control pull-left" Text="Show" OnClick="btnShow_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Distribution Receive Report" Font-Bold="true" Font-Size="16px"></asp:Label></div>
                        <div class="panel-body">
                            <asp:GridView ID="Distribution_Grid" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="2">

                                <Columns>
                                    <asp:TemplateField HeaderText="Transfer ID" SortExpression="intTransferID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblintTransferID" runat="server" CssClass="lbl" Text='<%# Bind("intTransferID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item Name" SortExpression="strItem">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstrItem" runat="server" CssClass="lbl" Text='<%# Bind("strItem") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item ID" SortExpression="intItemID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblintItemID" runat="server" CssClass="lbl" Text='<%# Bind("intItemID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Value" SortExpression="monValue" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblmonValue" runat="server" CssClass="lbl" Text='<%# Bind("monValue") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="UoM" SortExpression="struom">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstrUoM" runat="server" CssClass="lbl" Text='<%# Bind("struom") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit ID" SortExpression="intUnitID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblintUnitID" runat="server" CssClass="lbl" Text='<%# Bind("intUnitID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="intOutWHID" SortExpression="intOutWHID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblintOutWHID" runat="server" CssClass="lbl" Text='<%# Bind("intOutWHID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Qty" SortExpression="Qty">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtQty" runat="server" Text='<%# Bind("Qty","{0:N2}") %>' CssClass="form-control input-xs " onkeypress="if ( isNaN( String.fromCharCode(event.keyCode) )) return false;"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Transaction Date" SortExpression="dteTransactionDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldteTransactionDate" runat="server" CssClass="lbl" Text='<%# Bind("dteTransactionDate") %>' DataFormatString="{0:YYYY-MM-DD hh:mm:ss}"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="true" HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" CssClass="btn btn-success btn-xs"></asp:Button>
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
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductionTransferReport.aspx.cs" Inherits="UI.SCM.Transfer.ProductionTransferReport" %>

<%@ Import Namespace="Utility" %>

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
                            <asp:Label runat="server" Text="FG Transfer" Font-Bold="true" Font-Size="16px"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <div class="row form-group">
                                <div class="col-md-3">
                                    <asp:Label ID="Label3" runat="server" Text="From WareHouse" CssClass="row col-md-12 col-sm-12 col-xs-12"></asp:Label>
                                    <asp:DropDownList ID="ddlWH" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <%--<div class="col-md-3">
                                    <asp:Label ID="Label4" runat="server" Text="To WareHouse" CssClass="row col-md-12 col-sm-12 col-xs-12"></asp:Label>
                                    <asp:DropDownList ID="ddlToWH" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>--%>
                                <div class="col-md-2">
                                    <asp:Label ID="Label1" runat="server" Text="From Date" CssClass="row col-md-12 col-sm-12 col-xs-12"></asp:Label>
                                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" autocomplete="off" placeholder="yyyy-MM-dd"></asp:TextBox>
                                    <cc1:CalendarExtender ID="fd" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender>
                                </div>

                                <div class="col-md-2">
                                    <asp:Label ID="Label2" runat="server" Text="To Date" CssClass="row col-md-12 col-sm-12 col-xs-12"></asp:Label>
                                    <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" autocomplete="off" placeholder="yyyy-MM-dd"></asp:TextBox>
                                    <cc1:CalendarExtender ID="td" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender>
                                </div>
                                <div class="col-md-2" id="showbuttonDiv" style="padding-top: 20px;">
                                    <asp:Button ID="btnShow" runat="server" class="btn btn-primary form-control pull-left" Text="Show" OnClientClick="return  Validation()" OnClick="btnShow_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="FG Transfer Report" Font-Bold="true" Font-Size="16px"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <asp:GridView ID="Grid" CssClass="Grid" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="Both" ShowFooter="True" OnRowDataBound="Grid_OnRowDataBound" >
                                <Columns>
                                    <asp:TemplateField HeaderText="SN" SortExpression="intautoid">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Prod. ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProductionID" runat="server" CssClass="lbl" Text='<%# Bind("intProductionID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item ID" SortExpression="intItemID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblintItemID" runat="server" CssClass="lbl" Text='<%# Bind("intItemID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item Name" SortExpression="strItem">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstrItem" runat="server" CssClass="lbl" Text='<%# Bind("strItem") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="UoM" SortExpression="strUoM">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstrUoM" runat="server" CssClass="lbl" Text='<%# Bind("strUoM") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            Total
                                        </FooterTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Prod. Qty" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblNumProdQty" runat="server" CssClass="lbl" Text='<%# Bind("numProdQty") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label runat="server" ID="lblNumProdQtyFooter"></asp:Label>
                                        </FooterTemplate>
                                        <ItemStyle HorizontalAlign="Right"/>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sent Qty" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblNumSendStoreQty" runat="server" CssClass="lbl" Text='<%# Bind("numSendStoreQty") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label runat="server" ID="lblNumSendStoreQtyFooter"></asp:Label>
                                        </FooterTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rcv. Qty" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblNumStoreReceiveQty" runat="server" CssClass="lbl" Text='<%# Bind("numStoreReceiveQty") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label runat="server" ID="lblNumStoreReceiveQtyFooter"></asp:Label>
                                        </FooterTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sent Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDteSentQuantityDate" runat="server" CssClass="lbl" Text='<%# Bind("dteSentQuantityDate") %>' DataFormatString="{0:YYYY-MM-DD hh:mm:ss}"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rcv. Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDteStoreReceiveDate" runat="server" CssClass="lbl" Text='<%# Bind("dteStoreReceiveDate") %>' DataFormatString="{0:YYYY-MM-DD hh:mm:ss}"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <%--<RowStyle BackColor="#F7F6F3" ForeColor="#333333" />--%>
                                <%--<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />--%>
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
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
                console.log("From :"+txtFromDate);
                if (txtFromDate === "") {
                    ShowNotification("From date can not be blank", "Transfer Report", "warning");
                    return false;
                } else if (txtToDate === "") {
                    ShowNotification("To date can not be blank", "Transfer Report", "warning");
                    return false;
                }
                showLoader();
                return true;
            }
        </script>
    </form>
</body>
</html>
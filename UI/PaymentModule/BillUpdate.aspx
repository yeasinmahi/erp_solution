<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillUpdate.aspx.cs" Inherits="UI.PaymentModule.BillUpdate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>.:  :.</title>

    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/updatedJs") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/updatedCss" />
    
    <script language="javascript" type="text/javascript">

        function Search_dgvservice(strKey, strGV) {

            var strData = strKey.value.toLowerCase().split(" ");
            var tblData = document.getElementById(strGV);
            var rowData;
            for (var i = 1; i < tblData.rows.length; i++) {
                rowData = tblData.rows[i].innerHTML;
                var styleDisplay = 'none';
                for (var j = 0; j < strData.length; j++) {
                    if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                        styleDisplay = '';
                    else {
                        styleDisplay = 'none';
                        break;
                    }
                }
                tblData.rows[i].style.display = styleDisplay;
            }
        }
    </script>
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
                    <asp:HiddenField ID="hdnLevel" runat="server" />
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Bill Update" Font-Bold="true" Font-Size="16px"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <div class="row form-group">
                                <div class="col-md-3">
                                    <asp:Label ID="Label3" runat="server" Text="Unit" CssClass="row col-md-12 col-sm-12 col-xs-12"></asp:Label>
                                    <asp:DropDownList ID="ddlUnit" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" AutoPostBack="false"></asp:DropDownList>
                                </div>
                                <div class="col-md-3">
                                    <asp:Label ID="Label1" runat="server" Text="From Date" CssClass="row col-md-12 col-sm-12 col-xs-12"></asp:Label>
                                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" autocomplete="off" placeholder="yyyy-MM-dd"></asp:TextBox>
                                    <cc1:CalendarExtender ID="fd" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender>
                                </div>

                                <div class="col-md-3">
                                    <asp:Label ID="Label2" runat="server" Text="To Date" CssClass="row col-md-12 col-sm-12 col-xs-12"></asp:Label>
                                    <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" autocomplete="off" placeholder="yyyy-MM-dd"></asp:TextBox>
                                    <cc1:CalendarExtender ID="td" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender>
                                </div>
                                <div class="col-md-3">
                                    <asp:Label ID="Label5" runat="server" Text="Action" CssClass="row col-md-12 col-sm-12 col-xs-12"></asp:Label>
                                    <asp:DropDownList ID="ddlAction" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" DataSourceID="odsActionType" DataTextField="strApproveType" DataValueField="intID" AutoPostBack="false"></asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsActionType" runat="server" SelectMethod="GetApproveType" TypeName="SCM_BLL.Billing_BLL"></asp:ObjectDataSource>
                                </div>
                                <div class="col-md-3" id="showbuttonDiv" style="padding-top: 20px;">
                                    <asp:Button ID="btnShow" runat="server" class="btn btn-primary form-control pull-left" Text="Show" OnClick="btnShow_Click" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <asp:Label ID="Label4" runat="server" Text="Bill Reg No" CssClass="row col-md-12 col-sm-12 col-xs-12"></asp:Label>
                                    <asp:TextBox ID="txtBillReg" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12"></asp:TextBox>
                                </div>
                                <div class="col-md-3" style="padding-top: 20px;">
                                    <asp:Button ID="btnBillRegister" runat="server" class="btn btn-primary form-control pull-left" Text="Go" OnClick="btnBillRegister_OnClick" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Bill Details" Font-Bold="true" Font-Size="16px"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="Both">

                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

                                <Columns>
                                    <asp:TemplateField HeaderText="SL">
                                        <ItemStyle HorizontalAlign="center" Width="10px" />
                                        <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Bill Id" SortExpression="intBill">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Bind("intBill") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center"/>
                                    </asp:TemplateField>

                                    <%--<asp:TemplateField HeaderText="Reg No" SortExpression="strBill">
                    <ItemTemplate><asp:Label ID="lblRegNo" runat="server" Text='<%# Bind("strBill") %>' Width="80px"></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px" /></asp:TemplateField>--%>

                                    <asp:TemplateField HeaderText="Reg No" Visible="true" ItemStyle-HorizontalAlign="left" SortExpression="strBill" HeaderStyle-Height="30px" HeaderStyle-VerticalAlign="Top" HeaderStyle-Wrap="true">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblRegNoL" runat="server" CssClass="lbl" Text="Reg No"></asp:Label>
                                            <asp:TextBox ID="TxtServiceConfg" ToolTip="Search Any Text" runat="server" Width="125" placeholder="Search" onkeyup="Search_dgvservice(this, 'dgvBillReport')"></asp:TextBox>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblRegNo" runat="server" Width="125px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strBill")) %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle Height="30px" VerticalAlign="Top" Wrap="True" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Party Name" SortExpression="strParty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPartyName" runat="server" Font-Bold="true" Text='<%# Bind("strParty") %>' Width="180px"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" Width="180px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Description" SortExpression="strItem">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDiscription" runat="server" Text='<%# Bind("strItem") %>' Width="180px"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" Width="180px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Last Price" SortExpression="monLastPtice">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLastPrice" runat="server" Text='<%# Bind("monLastPtice", "{0:n2}") %>' Width="80px"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" Width="80px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Ref" SortExpression="strReff">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReff" runat="server" Text='<%# Bind("strReff") %>' Width="70px"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" Width="70px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Rcv Date" SortExpression="dteBillRcvDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRcvDate" runat="server" Text='<%#Eval("dteBillRcvDate", "{0:yyyy-MM-dd}") %>' Width="80px"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" Width="80px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="MRR" SortExpression="strMRR">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMRRID" runat="server" Text='<%# Bind("strMRR") %>' Width="80px"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" Width="80px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Bill Amount" SortExpression="monbillAmount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBillAmount" runat="server" ForeColor="Blue" Text='<%# Bind("monbillAmount", "{0:n2}") %>' Width="80px"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="right" Width="80px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Net Amount" SortExpression="monNetAmount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNetAmount" runat="server" ForeColor="Blue" Text='<%# Bind("monNetAmount", "{0:n2}") %>' Width="80px"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="right" Width="80px" />
                                    </asp:TemplateField>

<%--                                    <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="right" SortExpression="strApproveType">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlActionStatus" runat="server" CssClass="ddList" Width="72px" DataSourceID="odsApproveType" DataTextField="strApproveType" DataValueField="intID"></asp:DropDownList>
                                            <asp:ObjectDataSource ID="odsApproveType" runat="server" SelectMethod="GetApproveType" TypeName="SCM_BLL.Billing_BLL"></asp:ObjectDataSource>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>--%>

                                   <%-- <asp:TemplateField HeaderText="Action Date" SortExpression="dteApproveDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblActionDate" runat="server" Text='<%#Eval("dteApproveDate", "{0:yyyy-MM-dd}") %>' Width="80px"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" Width="80px" />
                                    </asp:TemplateField>--%>

                                    <asp:TemplateField HeaderText="Approve Amount L1" SortExpression="monApproveL1">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApproveAmountL1" runat="server" Text='<%# Bind("monApproveL1", "{0:n2}") %>' Width="80px"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="right" Width="80px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Approve Amount L2" SortExpression="monApproveL2">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApproveAmountL2" runat="server" Text='<%# Bind("monApproveL2", "{0:n2}") %>' Width="80px"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="right" Width="80px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Show PO" ItemStyle-HorizontalAlign="Center" SortExpression="">
                                        <ItemTemplate>
                                            <asp:Button ID="btnShowPO" class="myButtonGrid" Font-Bold="true" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="S"
                                                Text="PO" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Show Details" ItemStyle-HorizontalAlign="Center" SortExpression="">
                                        <ItemTemplate>
                                            <asp:Button ID="btnShowDetails" class="myButtonGrid" Font-Bold="true" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="SD"
                                                Text="Details" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Approve Action" ItemStyle-HorizontalAlign="Center" SortExpression="">
                                        <ItemTemplate>
                                            <asp:Button ID="btnApproveAction" class="myButtonGrid" Font-Bold="true" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="A"
                                                Text="Action" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
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

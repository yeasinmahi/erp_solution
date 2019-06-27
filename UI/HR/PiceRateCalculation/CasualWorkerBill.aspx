<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CasualWorkerBill.aspx.cs" Inherits="UI.HR.PiceRateCalculation.CasualWorkerBill" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Overtime Entry</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/updatedJs") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/updatedCss" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel0" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                            <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                        </marquee>
                    </div>
                </asp:Panel>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <div style="height: 50px; width: 100%"></div>
                <%--=========================================Start My Code From Here===============================================--%>
                <div class="container">
                    <div class="row">
                        <div class="col-md-6 col-sm-6 col-lg-6 col-xs-12">
                            <div class="panel panel-info">
                                <div class="panel-heading">
                                    <asp:Label runat="server" Text="Casual Worker Bill Input" Font-Bold="true" Font-Size="16px"></asp:Label>

                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-md-6 col-sm-6">
                                            <asp:Label ID="Label20" runat="server" Text="Unit"></asp:Label>
                                            <asp:DropDownList ID="ddlUnit" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" Enabled="True">
                                                <asp:ListItem Selected="True" Text="AMFL" Value="10"></asp:ListItem>
                                            </asp:DropDownList>

                                        </div>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:Label ID="Label6" runat="server" Text="Date"></asp:Label>
                                            <span style="color: red; font-size: 14px; text-align: left">*</span>
                                            <asp:TextBox ID="txtDate" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" autoComplete="off" placeholder="Date"></asp:TextBox>
                                        </div>

                                        <div class="col-md-12 col-sm-12" style="padding-top: 10px">
                                            <asp:Button ID="btnShow" runat="server" class="btn btn-primary form-control pull-right" Text="Show" OnClientClick="return Validate();" OnClick="btnShow_OnClick" />
                                        </div>
                                    </div>


                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-6 col-lg-6 col-xs-12">
                            <div class="panel panel-info">
                                <div class="panel-heading">
                                    <asp:Label runat="server" Text="Casual Worker Bill Report" Font-Bold="true" Font-Size="16px"></asp:Label>

                                </div>
                                <div class="panel-body">
                                    <div class="row">

                                        <div class="col-md-6 col-sm-6">
                                            <asp:Label ID="Label3" runat="server" Text="Enroll"></asp:Label>
                                            <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                            <asp:TextBox ID="txtEnroll"  CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Enroll"></asp:TextBox>

                                        </div>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:Label ID="Label1" runat="server" Text="Employee Name"></asp:Label>
                                            <span style="color: red; font-size: 14px; text-align: left">*</span>
                                            <asp:TextBox ID="txtEmployeeName" Enabled="False" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Employee Name"></asp:TextBox>

                                        </div>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:Label ID="Label4" runat="server" Text="Designation"></asp:Label>
                                            <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                            <asp:TextBox ID="txtDesignation" Enabled="False" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Designation"></asp:TextBox>

                                        </div>
                                        <div class="col-md-6 col-sm-6">
                                            <asp:Label ID="Label5" runat="server" Text="Code"></asp:Label>
                                            <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                            <asp:TextBox ID="txtCode" Enabled="False" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Code"></asp:TextBox>

                                        </div>
                                        <div class="col-md-12 col-sm-12" style="padding-top: 10px">
                                            <asp:Button ID="Button1" runat="server" class="btn btn-primary form-control pull-right" Text="Show" OnClientClick="return Validate();" OnClick="btnShow_OnClick" />
                                        </div>
                                    </div>


                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-info" id="panel">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Casual Worker Bill Form" Font-Bold="true" Font-Size="16px"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" Width="100%"
                                DataKeyNames="intEmployeeID" OnRowDeleting="gridView_OnRowDeleting" OnRowDataBound="gridView_OnRowDataBound" GridLines="Both">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SL">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Enroll">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmpEnroll" runat="server" Text='<%# Bind("intEmployeeID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Emp. Code">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmpCode" runat="server" Text='<%# Bind("strEmployeeCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Emp. Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmpName" runat="server" Text='<%# Bind("strEmployeeName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <%--<ItemStyle HorizontalAlign="Left"></ItemStyle>--%>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Production Type">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlProductionType" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle Width="30px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="30px"></ItemStyle>
                                    </asp:TemplateField>

                                    <%-- <asp:TemplateField HeaderText="Action" ItemStyle-Width="80px">
                                        <ItemTemplate>
                                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger btn-xs" CommandName="Delete" OnClick="btnDelete_OnClick" />
                                        </ItemTemplate>
                                        <ItemStyle Width="80px" />
                                    </asp:TemplateField>--%>
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
                            <div class="col-md-12" style="padding-top: 15px;">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary form-control pull-right" OnClick="btnSubmit_OnClick" />
                            </div>
                        </div>

                    </div>

                    <%--                    <div class="panel panel-info" id="itemPanel">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Overtime Details Report" Font-Bold="true" Font-Size="16px"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <asp:GridView ID="GridViewEmployeeDetails" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" Width="100%"
                                DataKeyNames="intID" GridLines="Both">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SL">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Enroll" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmpEnroll" runat="server" Text='<%# Bind("intEmpID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Employee Name" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmployeeName" runat="server" Text='<%# Bind("strEmployeeName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Designation" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDesignation" runat="server" Text='<%# Bind("strDesignation") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDate" runat="server" Text='<%# Eval("dteDate","{0:MM/dd/yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Start Time">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStartTime" runat="server" Text='<%# Eval("dteStartTime") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="End Time">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEndTime" runat="server" Text='<%# Bind("dteEndTime") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Countable Hour">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHour" runat="server" Text='<%# Bind("monHour") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Gross Salary">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGross" runat="server" Text='<%# Eval("monSalary","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Basic Salary">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBasic" runat="server" Text='<%# Bind("monBasic","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Hourly Rate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHourRate" runat="server" Text='<%# Bind("monHourAmount","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("monDayTotalAmount","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Reson">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReson" runat="server" Text='<%# Bind("strPurpose") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("strRemarks") %>'>></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Insert By">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInsertBy" runat="server" Text='<%# Bind("intInsertBy") %>'>></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action" ItemStyle-Width="80px">
                                        <ItemTemplate>
                                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary btn-xs" OnClick="btnUpdate_OnClick" />

                                        </ItemTemplate>
                                        <ItemStyle Width="80px" />
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

                    </div>--%>
                </div>

                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                <asp:PostBackTrigger ControlID="btnSubmit" />
            </Triggers>
        </asp:UpdatePanel>
        <script type="text/javascript">
            function Validate() {
                var txtDate = document.getElementById("txtDate").value;

                if (txtDate === null || txtDate === "") {
                    ShowNotification('Date can not be blank', 'Casual Worker Bill', 'warning');
                    return false;
                }
                showLoader();
                return true;
            }
            $(function () {

                Init();
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(Init);
            });

            function Init() {
                $('#txtDate').datepicker({
                    dateFormat: 'dd/mm/yy'
                });

            }
        </script>
    </form>

    <style>
        table {
            max-width: 100%;
            background-color: transparent;
            text-align: center;
        }

        th {
            text-align: center;
        }

        .table {
            width: 100%;
            margin-bottom: 20px;
        }

        tr {
            font-size: 14px;
        }

        .datepicker {
            transform: translate(0, 3.1em);
        }
    </style>
</body>
</html>


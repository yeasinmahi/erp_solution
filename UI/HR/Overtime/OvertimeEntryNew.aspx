<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeBehind="OvertimeEntryNew.aspx.cs" Inherits="UI.HR.Overtime.OvertimeEntryNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Overtime Entry</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <%--<asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>--%>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

    <link href="../../Content/CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/CSS/jquery-ui.min.css" rel="stylesheet" />

    <script src="../../Content/JS/jquery-3.3.1.js"></script>
    <script src="../../Content/JS/jquery-ui.min.js"></script>
    <script src="../../Content/JS/bootstrap.min.js"></script>
    <script src="../../Content/JS/jquery.timepicker.js"></script>
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
                        <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                </asp:Panel>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <div style="height: 50px; width: 100%"></div>
                <%--=========================================Start My Code From Here===============================================--%>
                <div class="container">
                    <asp:HiddenField runat="server" ID="hdnSearch" />
                    <asp:HiddenField runat="server" ID="hdnEmployeeName" />
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Overtime Entry Form" Font-Bold="true" Font-Size="16px"></asp:Label>

                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label20" runat="server" Text="Unit"></asp:Label>
                                    <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                    <asp:DropDownList ID="ddlUnit" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" Enabled="True" AutoPostBack="True" OnSelectedIndexChanged="ddlUnit_OnSelectedIndexChanged"></asp:DropDownList>

                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label2" runat="server" Text="Job Station"></asp:Label>
                                    <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                    <asp:DropDownList ID="ddlJobStation" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" Enabled="True" OnSelectedIndexChanged="ddlJobStation_OnSelectedIndexChanged"></asp:DropDownList>

                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label1" runat="server" Text="Employee Name"></asp:Label>
                                    <span style="color: red; font-size: 14px; text-align: left">*</span>
                                    <asp:TextBox ID="txtEmployeeName" ClientIDMode="Static" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Employee Name"></asp:TextBox>

                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label3" runat="server" Text="Enroll"></asp:Label>
                                    <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                    <asp:TextBox ID="txtEnroll" Enabled="False" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Enroll"></asp:TextBox>

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
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label6" runat="server" Text="Date"></asp:Label>
                                    <span style="color: red; font-size: 14px; text-align: left">*</span>
                                    <asp:TextBox ID="txtDate" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" autoComplete="off" placeholder="Date"></asp:TextBox>
                                </div>

                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label8" runat="server" Text="Movement Hour"></asp:Label>
                                    <span style="color: red; font-size: 14px; text-align: left">*</span>
                                    <asp:TextBox ID="txtMove" Enabled="False" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="OverTime Hour"></asp:TextBox>

                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label9" runat="server" Text="Start Time"></asp:Label>
                                    <span style="color: red; font-size: 14px; text-align: left">*</span>
                                    <asp:TextBox ID="txtStrtTime" CssClass="form-control col-md-12 col-sm-12 col-xs-12" autoComplete="off" onchange="GetTimeSpan()" runat="server" placeholder="Start Time"></asp:TextBox>

                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label7" runat="server" Text="End Time"></asp:Label>
                                    <span style="color: red; font-size: 14px; text-align: left">*</span>
                                    <asp:TextBox ID="txtEndTime" CssClass="form-control col-md-12 col-sm-12 col-xs-12" autoComplete="off" onchange="GetTimeSpan()" runat="server" placeholder="End Time"></asp:TextBox>

                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label10" runat="server" Text="Purpose"></asp:Label>
                                    <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                    <asp:DropDownList ID="ddlPurpose" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" Enabled="True"></asp:DropDownList>

                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label11" runat="server" Text="Remarks"></asp:Label>
                                    <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                    <asp:TextBox ID="txtRemarks" TextMode="MultiLine" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Remarks"></asp:TextBox>

                                </div>
                                <div class="col-md-12" style="padding-top: 10px">
                                    <asp:Button ID="btnAdd" runat="server" class="btn btn-primary form-control pull-right" Text="Add" OnClientClick="return Validate();" OnClick="btnAdd_OnClick" />
                                </div>
                            </div>


                        </div>
                    </div>

                    <div class="panel panel-info" id="itemPanel">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Overtime Entry Form" Font-Bold="true" Font-Size="16px"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <asp:GridView ID="OvertimeEntryGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" Width="100%"
                                DataKeyNames="empEnroll" OnRowDeleting="OvertimeEntryGridView_OnRowDeleting" GridLines="Both">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SL">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Enroll">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmpEnroll" runat="server" Text='<%# Bind("empEnroll") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDate" runat="server" Text='<%# Bind("date") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Start Time">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStartTime" runat="server" Text='<%# Bind("startTime") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="End Time">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEndTime" runat="server" Text='<%# Bind("endTime") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Differance Time">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDiffTime" runat="server" Text='<%# Bind("diffTime") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Countable Hour">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHour" runat="server" Text='<%# Bind("hour") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Reson">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReson" runat="server" Text='<%# Bind("reason") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("remarks") %>'>></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="200px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action" ItemStyle-Width="80px">
                                        <ItemTemplate>
                                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger btn-xs" CommandName="Delete" OnClick="btnDelete_OnClick" />
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
                            <div class="col-md-12" style="padding-top: 15px;">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary form-control pull-right" OnClick="btnSubmit_OnClick" />
                            </div>
                        </div>

                    </div>

                    <div class="panel panel-info">
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
                                    <asp:TemplateField HeaderText="Enroll">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmpEnroll" runat="server" Text='<%# Bind("intEmpID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Employee Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmployeeName" runat="server" Text='<%# Bind("strEmployeeName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Designation">
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

                    </div>
                </div>
                <div class="modal fade" id="myModal" role="dialog">
                    <div class="modal-dialog">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Employee Overtime Update</h4>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-md-6 col-sm-6">
                                        <asp:Label ID="Label22" runat="server" Text="overtime Id"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtOvertimeId" Enabled="False" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Overtime Id"></asp:TextBox>

                                    </div>
                                    <div class="col-md-6 col-sm-6">
                                        <asp:Label ID="Label14" runat="server" Text="Employee Name"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtEmployeeNameUpdate" Enabled="False" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Employee Name"></asp:TextBox>

                                    </div>
                                    <div class="col-md-6 col-sm-6">
                                        <asp:Label ID="Label12" runat="server" Text="Enroll"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtEnrollUpdate" Enabled="False" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Enroll"></asp:TextBox>

                                    </div>
                                    <div class="col-md-6 col-sm-6">
                                        <asp:Label ID="Label13" runat="server" Text="Designation"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtDesignationUpdate" Enabled="False" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Designation"></asp:TextBox>

                                    </div>

                                    <div class="col-md-6 col-sm-6">
                                        <asp:Label ID="Label15" runat="server" Text="Date"></asp:Label>
                                        <span style="color: red; font-size: 14px; text-align: left">*</span>
                                        <asp:TextBox ID="txtDateUpdate" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" autoComplete="off" placeholder="Date"></asp:TextBox>
                                    </div>

                                    <div class="col-md-6 col-sm-6">
                                        <asp:Label ID="Label16" runat="server" Text="Movement Hour"></asp:Label>
                                        <span style="color: red; font-size: 14px; text-align: left">*</span>
                                        <asp:TextBox ID="txtMoveUpdate" Enabled="False" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="OverTime Hour"></asp:TextBox>

                                    </div>
                                    <div class="col-md-6 col-sm-6">
                                        <asp:Label ID="Label17" runat="server" Text="Start Time"></asp:Label>
                                        <span style="color: red; font-size: 14px; text-align: left">*</span>
                                        <asp:TextBox ID="txtStrtTimeUpdate" CssClass="form-control col-md-12 col-sm-12 col-xs-12" autoComplete="off" onchange="GetTimeSpanUpdate()" runat="server" placeholder="Start Time"></asp:TextBox>

                                    </div>
                                    <div class="col-md-6 col-sm-6">
                                        <asp:Label ID="Label18" runat="server" Text="End Time"></asp:Label>
                                        <span style="color: red; font-size: 14px; text-align: left">*</span>
                                        <asp:TextBox ID="txtEndTimeUpdate" CssClass="form-control col-md-12 col-sm-12 col-xs-12" autoComplete="off" onchange="GetTimeSpanUpdate()" runat="server" placeholder="End Time"></asp:TextBox>

                                    </div>
                                    <div class="col-md-6 col-sm-6">
                                        <asp:Label ID="Label19" runat="server" Text="Purpose"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:DropDownList ID="ddlPurposeUpdate" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" Enabled="True"></asp:DropDownList>

                                    </div>
                                    <div class="col-md-6 col-sm-6">
                                        <asp:Label ID="Label21" runat="server" Text="Remarks"></asp:Label>
                                        <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                        <asp:TextBox ID="txtRemarksUpdate" TextMode="MultiLine" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Remarks"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <div class="col-md-12">
                                    <asp:Button ID="btnUpdateFinal" runat="server" class="btn btn-primary form-control pull-right" Text="Update" OnClientClick="return ValidateUpdate();" OnClick="btnUpdateFinal_OnClick" />
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                <asp:PostBackTrigger ControlID="btnSubmit" />
                <asp:PostBackTrigger ControlID="btnUpdateFinal" />
            </Triggers>
        </asp:UpdatePanel>
        <script type="text/javascript">
            function showPanel() {
                //var txtItemName = document.getElementById("txtItemName").value;
                //if (txtItemName === null || txtItemName === "") {
                //    alert("Item Name can not be empty");
                //    return false;
                //}
                var itemPanel = document.getElementById("itemPanel");
                itemPanel.classList.remove("hidden");
                return true;
            }
            function hidePanel() {
                var itemPanel = document.getElementById("itemPanel");
                itemPanel.classList.add("hidden");

            }
            function Validate() {
                var txtEnroll = document.getElementById("txtEnroll").value;
                var txtDate = document.getElementById("txtDate").value;
                var txtMove = document.getElementById("txtMove").value;
                var txtStarTime = document.getElementById("txtStrtTime").value;
                var txtEndTime = document.getElementById("txtEndTime").value;

                if (txtEnroll === null || txtEnroll === "") {
                    alert("Enter Employee properly");
                    return false;
                }
                if (txtDate === null || txtDate === "") {
                    alert("Date can not be blank");
                    return false;
                }
                if (txtMove === null || txtMove === "") {
                    alert("Movement hour can not be blank");
                    return false;
                }
                if (txtStarTime === null || txtStarTime === "") {
                    alert("Start time can not be blank");
                    return false;
                }
                if (txtEndTime === null || txtEndTime === "") {
                    alert("End time can not be blank");
                    return false;
                }
                return true;
            }
            function ValidateUpdate() {
                var txtDate = document.getElementById("txtDateUpdate").value;
                var txtMove = document.getElementById("txtMoveUpdate").value;
                var txtStarTime = document.getElementById("txtStrtTimeUpdate").value;
                var txtEndTime = document.getElementById("txtEndTimeUpdate").value;

                if (txtDate === null || txtDate === "") {
                    alert("Date can not be blank");
                    return false;
                }
                if (txtMove === null || txtMove === "") {
                    alert("Movement hour can not be blank");
                    return false;
                }
                if (txtStarTime === null || txtStarTime === "") {
                    alert("Start time can not be blank");
                    return false;
                }
                if (txtEndTime === null || txtEndTime === "") {
                    alert("End time can not be blank");
                    return false;
                }
                return true;
            }
            $(function () {

                Init();
                //ShowHideGridviewPanels();
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(Init);
                //Sys.WebForms.PageRequestManager.getInstance().add_endRequest(ShowHideGridviewPanels);
            });

            function Init() {
                //autoCompleteItemName();
                SearchText();
                $('#txtDate').datepicker();
                $('#txtStrtTime').timepicker({
                    timeFormat: 'HH:mm'
                });
                $('#txtEndTime').timepicker({
                    timeFormat: 'HH:mm'
                });
                $('#txtDateUpdate').datepicker({
                    container: '#myModal',
                    beforeShow: function (input, inst) {
                        var rect = input.getBoundingClientRect();
                        setTimeout(function () {
                            inst.dpDiv.css({ top: rect.top+35, left: rect.left + 0 });
                        }, 0);
                    }
                });
                $('#txtStrtTimeUpdate').timepicker({
                    timeFormat: 'HH:mm',
                    beforeShow: function (input, inst) {
                        var rect = input.getBoundingClientRect();
                        setTimeout(function () {
                            inst.dpDiv.css({ top: rect.top+35, left: rect.left + 0 });
                        }, 0);
                    }
                });
                $('#txtEndTimeUpdate').timepicker({
                    timeFormat: 'HH:mm',
                    beforeShow: function (input, inst) {
                        var rect = input.getBoundingClientRect();
                        setTimeout(function () {
                            inst.dpDiv.css({ top: rect.top+35, left: rect.left + 0 });
                        }, 0);
                    }
                });
            }
            function GetTimeSpan() {
                var defaultDate = "1/1/1970 ";
                var end = document.getElementById('txtEndTime').value;
                var start = document.getElementById('txtStrtTime').value;
                console.log("start " + start);
                console.log("End " + end);
                var difference = new Date(new Date(defaultDate + end) - new Date(defaultDate + start)).toUTCString().split(" ")[4];
                console.log("Diff " + difference);
                document.getElementById("txtMove").innerText = difference;
                $('#txtMove').val(difference);
            }
            function GetTimeSpanUpdate() {
                var defaultDate = "1/1/1970 ";
                var end = document.getElementById('txtEndTimeUpdate').value;
                var start = document.getElementById('txtStrtTimeUpdate').value;
                var difference = new Date(new Date(defaultDate + end) - new Date(defaultDate + start)).toUTCString().split(" ")[4];
                document.getElementById("<%=txtMoveUpdate.ClientID%>").innerText = difference;
                $('#txtMoveUpdate').val(difference);
            }
            function openModal() {
                $('#myModal').modal('show');
            }
            function closeModal() {
                $('#myModal').modal('hide');
            }
            //var prm = Sys.WebForms.PageRequestManager.getInstance(); 

            //prm.add_endRequest(function() { 
            //    SearchText();
            //    $('#txtStrtTime').timepicker();
            //    $('#txtEndTime').timepicker();
            //    console.log("dom Ready Page Request Manager");
            //}); 
            //function pageLoad(sender, args) {
            //    $(document).ready(function () {
            //        SearchText();
            //        $('#txtStrtTime').timepicker();
            //        $('#txtEndTime').timepicker();
            //        console.log("dom Ready page preload");
            //    });
            //}
            //function Changed() {
            //    document.getElementById('hdfSearchBoxTextChange').value = 'true';
            //}
            function SearchText() {
                $("#txtEmployeeName").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            type: "POST",
                            contentType: "application/json;",
                            url: "OvertimeEntryNew.aspx/GetAutoCompleteData",
                            data: "{'strSearchKey':'" + document.getElementById('txtEmployeeName').value + "'}",
                            dataType: "json",
                            success: function (data) {
                                response(data.d);
                            },
                            error: function (result) {
                                console.log(result.responseText);
                            }
                        });
                    },
                    minLength: 3,
                    select: function (event, ui) {
                        console.log(ui.item.value);
                        var hdnSearchId = document.getElementById("<%=hdnSearch.ClientID%>");
                        hdnSearchId.value = 1;
                                            <%--var txtEmployeeName= document.getElementById("<%=txtEmployeeName.ClientID %>");  
                    txtEmployeeName.value = ui.item.val;--%>
                        document.getElementById('<%=txtEmployeeName.ClientID %>').value = ui.item.value;
                        __doPostBack('', ui.item.value);
                    }
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

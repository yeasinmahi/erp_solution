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

        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
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
                                            <asp:TextBox ID="txtDate" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" autoComplete="off" placeholder="Date" ></asp:TextBox>
                                        </div>

                                        <div class="col-md-12 col-sm-12" style="padding-top: 10px">
                                            <asp:Button ID="btnShow" runat="server"  class="btn btn-primary form-control pull-right" Text="Show" OnClientClick="return ValidateDate();" OnClick="btnShow_OnClick" />
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
                                        <%-- <div class="col-md-4 col-sm-4">
                                            <asp:Label ID="Label1" runat="server" Text="Select Month"></asp:Label>
                                            <span style="color: red; font-size: 14px; text-align: left">*</span>
                                            <asp:TextBox ID="txtMonth" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" autocomplete="off" placeholder="Select Month"></asp:TextBox>

                                        </div>--%>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:Label ID="Label1" runat="server" Text="From Date"></asp:Label>
                                            <span style="color: red; font-size: 14px; text-align: left">*</span>
                                            <asp:TextBox ID="txtFDate" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" autocomplete="off" placeholder="Select From Date"></asp:TextBox>

                                        </div>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:Label ID="Label2" runat="server" Text="To Date"></asp:Label>
                                            <span style="color: red; font-size: 14px; text-align: left">*</span>
                                            <asp:TextBox ID="txtTDate" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" autocomplete="off" placeholder="Select To Date"></asp:TextBox>

                                        </div>
                                        <div class="col-md-4 col-sm-4">
                                            <asp:Label ID="Label3" runat="server" Text="Employee Code"></asp:Label>
                                            <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                            <asp:TextBox ID="txtEnroll" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Employee Code"></asp:TextBox>

                                        </div>

                                        <div class="col-md-12 col-sm-12" style="padding-top: 10px">
                                            <asp:Button ID="btnShowIndividualReport" runat="server" class="btn btn-primary form-control pull-left" Text="Individual Report" OnClientClick="return ValidateEnrollAndMonth();" OnClick="btnShowIndividualReport_OnClick" />
                                            <asp:Button ID="btnShowAllReport"  runat="server" class="btn btn-primary form-control pull-right" Text="All Report" OnClientClick="return ValidateMonth();" OnClick="btnShowAllReport_OnClick" />
                                            <asp:Button ID="btnGenarateSalary"  runat="server" class="btn btn-primary form-control pull-right" Visible="false" Text="Salary Genarate" OnClick="btnGenarateSalary_Click" />
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
                    <div class="panel panel-info" id="itemPanel2">
                        <div class="panel-heading">
                            <asp:Label runat="server" ID="lblHeader" Text="Worker Bill Individual Report" Font-Bold="true" Font-Size="16px"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <iframe runat="server" oncontextmenu="return false;" id="frame" name="frame" style="width: 100%; height: 1000px; border: 0px solid red;"></iframe>
                        </div>

                    </div>
                </div>

                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
        <script type="text/javascript">
            function ValidateDate() {
                var txtDate = document.getElementById("txtDate").value;

                if (txtDate === null || txtDate === "") {
                    ShowNotification('Date can not be blank', 'Casual Worker Bill', 'warning');
                    return false;
                }
                showLoader();
                return true;
            }
            function ValidateMonth() {
                var txtMonth = document.getElementById("txtMonth").value;

                if (txtMonth === null || txtMonth === "") {
                    ShowNotification('Month can not be blank', 'Casual Worker Bill', 'warning');
                    return false;
                }
                showLoader();
                return true;
            }
            function ValidateEnrollAndMonth() {
                var txtEnroll = document.getElementById("txtEnroll").value;
                var txtFDate = document.getElementById("txtFDate").value;
                var txtTDate = document.getElementById("txtTDate").value;
                if (txtEnroll === null || txtEnroll === "") {
                    ShowNotification('Employee code can not be blank', 'Casual Worker Bill', 'warning');
                    return false;
                }
                if (txtFDate === null || txtFDate === "") {
                    ShowNotification('From date can not be blank', 'Casual Worker Bill', 'warning');
                    return false;
                }
                showLoader();
                return true;
            }
            $(function () {

                Init();
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(Init);
            });
            function stopRKey(evt) {
                var evt = (evt) ? evt : ((event) ? event : null);
                var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
                if ((evt.keyCode == 13) && (node.type == "text")) { return false; }
            }
            
            function Init() {
                $('#txtFDate').datepicker({
                    dateFormat: 'yy-mm-dd'
                });
                $('#txtTDate').datepicker({
                    dateFormat: 'yy-mm-dd'
                });
                $('#txtDate').datepicker({
                    dateFormat: 'dd/mm/yy'
                });
                $('#txtMonth').datepicker({
                    changeMonth: true,
                    changeYear: true,
                    showButtonPanel: true,
                    dateFormat: 'mm/yy',
                    onClose: function () {

                        //Get the selected month value
                        var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();

                        //Get the selected year value
                        var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();

                        //set month value to the textbox
                        $(this).datepicker('setDate', new Date(year, month, 1));
                    }
                });
                $("#txtMonth").focus(function () {
                    $(".ui-datepicker-calendar").hide();
                });
                document.onkeypress = stopRKey;
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


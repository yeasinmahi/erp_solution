<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OvertimeEntryNew.aspx.cs" Inherits="UI.HR.Overtime.OvertimeEntryNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Overtime Entry</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

    <link href="../../Content/CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/CSS/jquery-ui.min.css" rel="stylesheet" />

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
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Overtime Entry Form" Font-Bold="true" Font-Size="16px"></asp:Label>

                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label20" runat="server" Text="Unit : "></asp:Label>
                                    <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                    <asp:DropDownList ID="ddlUnit" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" Enabled="True" AutoPostBack="True" OnSelectedIndexChanged="ddlUnit_OnSelectedIndexChanged"></asp:DropDownList>

                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label2" runat="server" Text="Job Station : "></asp:Label>
                                    <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                    <asp:DropDownList ID="ddlJobStation" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" Enabled="True" OnSelectedIndexChanged="ddlJobStation_OnSelectedIndexChanged"></asp:DropDownList>

                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label1" runat="server" Text="Employee Name : "></asp:Label>
                                    <span style="color: red; font-size: 14px; text-align: left">*</span>
                                    <asp:TextBox ID="txtEmployeeName" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Employee Name"></asp:TextBox>

                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label3" runat="server" Text="Enroll : "></asp:Label>
                                    <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                    <asp:TextBox ID="txtEnroll" Enabled="False" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Enroll"></asp:TextBox>

                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label4" runat="server" Text="Designation : "></asp:Label>
                                    <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                    <asp:TextBox ID="txtDesignation" Enabled="False" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Designation"></asp:TextBox>

                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label5" runat="server" Text="Code : "></asp:Label>
                                    <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                    <asp:TextBox ID="txtCode" Enabled="False" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Code"></asp:TextBox>

                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label6" runat="server" Text="Date : "></asp:Label>
                                    <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                    <asp:TextBox ID="txtDate" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" autoComplete= "off" placeholder="Date"></asp:TextBox>
                                </div>

                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label8" runat="server" Text="Movement Hour :"></asp:Label>
                                    <asp:TextBox ID="txtMove" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="OverTime Hour"></asp:TextBox>

                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label9" runat="server" Text="Start Time : "></asp:Label>
                                    <span style="color: red; font-size: 14px; text-align: left">*</span>
                                    <asp:TextBox ID="txtStrtTime" CssClass="form-control col-md-12 col-sm-12 col-xs-12" autoComplete= "off" onchange="GetTimeSpan()" runat="server" placeholder="Start Time"></asp:TextBox>

                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label7" runat="server" Text="End Time : "></asp:Label>
                                    <span style="color: red; font-size: 14px; text-align: left">*</span>
                                    <asp:TextBox ID="txtEndTime" CssClass="form-control col-md-12 col-sm-12 col-xs-12" autoComplete= "off" onchange="GetTimeSpan()" runat="server" placeholder="End Time"></asp:TextBox>

                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label10" runat="server" Text="Purpose : "></asp:Label>
                                    <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                    <asp:DropDownList ID="ddlPurpose" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" Enabled="True"></asp:DropDownList>

                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label11" runat="server" Text="Remarks : "></asp:Label>
                                    <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                    <asp:TextBox ID="txtRemarks" TextMode="MultiLine" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Remarks"></asp:TextBox>

                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12 btn-toolbar">
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
                                DataKeyNames="intItemMasterID" OnRowDeleting="OvertimeEntryGridView_OnRowDeleting" GridLines="Both">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SL">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemid" runat="server" Text='<%# Bind("intItemMasterID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemName" runat="server" CssClass="pull-left" Text='<%# Bind("ItemName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="UOM">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUom" runat="server" Text='<%# Bind("strUoM") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Closing Stock">
                                        <ItemTemplate>
                                            <asp:Label ID="lblChallanNo" runat="server" CssClass="pull-right" Text='<%# Bind("ClosingStock") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLocation" runat="server" CssClass="pull-right" Text='<%# Bind("Rate","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CostAmount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMrrQty" runat="server" CssClass="pull-right" Text='<%# Bind("costAmount","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sales Rate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRate" runat="server" CssClass="pull-right" Text='<%# Bind("salesPrice","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sales Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCostAmount" runat="server" CssClass="pull-right" Text='<%# Bind("salesAmount","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Remarks" ItemStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRemarks" runat="server" CssClass="pull-left" Text='<%# Bind("strRemarks") %>'>></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="200px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action" ItemStyle-Width="80px">
                                        <ItemTemplate>
                                            <asp:Button ID="btnActive" runat="server" Text="Active" CssClass="btn btn-primary btn-xs" CommandName="Delete" OnClick="btnActive_OnClick" />
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
                        <div class="row">
                            <div class="col-md-12 btn-toolbar" style="padding-top: 15px;">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary form-control btn-sm pull-right hidden" OnClick="btnSubmit_OnClick" />
                            </div>
                        </div>
                    </div>
                </div>
                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                <asp:PostBackTrigger ControlID="btnSubmit" />
            </Triggers>
        </asp:UpdatePanel>

    </form>
    <script>
        function showPanel() {
            //var txtItemName = document.getElementById("txtItemName").value;
            //if (txtItemName === null || txtItemName === "") {
            //    alert("Item Name can not be empty");
            //    return false;
            //}
            var itemPanel = document.getElementById("btnInActive");
            itemPanel.classList.remove("hidden");
            return true;
        }
        function hidePanel() {
            var itemPanel = document.getElementById("btnInActive");
            itemPanel.classList.add("hidden");

        }
        function Validate() {
            var txtItemName = document.getElementById("txtItemName").value;

            if (txtItemName === null || txtItemName === "") {
                alert("Item Name can not be empty");
                return false;
            }
            return true;
        }
        
        function autoCompleteItemName() {
            $("#txtEmployeeName").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;",
                        url: "BlockItem.aspx/GetItem",
                        data: "{'prefix':'" + document.getElementById('txtItemName').value + "'}",
                        dataType: "json",
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (result) {
                            alert("Error");
                        }

                    });
                },
                minLength: 3
            });
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
        var prm = Sys.WebForms.PageRequestManager.getInstance(); 

        prm.add_endRequest(function() { 
            SearchText();
            $('#txtStrtTime').timepicker();
            $('#txtEndTime').timepicker();
            console.log("dom Ready Page Request Manager");
        }); 
        function pageLoad(sender, args) {
            $(document).ready(function () {
                SearchText();
                $('#txtStrtTime').timepicker();
                $('#txtEndTime').timepicker();
                console.log("dom Ready page preload");
            });
        }
        function Changed() {
            document.getElementById('hdfSearchBoxTextChange').value = 'true';
        }
        function SearchText() {
            $("#txtEmployeeName").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;",
                        url: "OvertimeEntry.aspx/GetAutoCompleteData",
                        data: "{'strSearchKey':'" + document.getElementById('txtFullName').value + "'}",
                        dataType: "json",
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (result) {
                            alert("Error");
                        }
                    });
                }
            });
        }
    </script>
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
    </style>
</body>
</html>

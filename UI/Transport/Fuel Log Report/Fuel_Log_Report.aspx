<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fuel_Log_Report.aspx.cs" Inherits="UI.Transport.Fuel_Log_Report.Fuel_Log_Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>.:  :.</title>

    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/updatedJs") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/updatedCss" />

    <script>
        function loadIframe(iframeName, url) {
            var $iframe = $('#' + iframeName);
            if ($iframe.length) {
                $iframe.attr('src', url);
                return false;
            }
            return true;
        }
    </script>
    <style type="text/css">
        
    </style>
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
                            <asp:Label runat="server" Text="Fuel Log Report" Font-Bold="true" Font-Size="16px"></asp:Label>

                        </div>
                        <div class="panel-body">
                            <div class="row form-group">
                                <div class="col-md-4">
                                    <asp:Label ID="Label3" runat="server" Text="Report Type"></asp:Label>
                                    <asp:DropDownList ID="ddlReport" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" OnSelectedIndexChanged="ddlReport_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Text="--Select Report Type--" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="MonthWise TopSheet" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="DateWise TopSheet" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Oil Summary Report" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Summary Report" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="CNG Report" Value="5"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <asp:Label ID="Label1" runat="server" Text="From Date" ></asp:Label>
                                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" autocomplete="off" placeholder="yyyy-MM-dd"></asp:TextBox>
                                    <cc1:CalendarExtender ID="fd" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender>
                                </div>

                                <div class="col-md-4">
                                    <asp:Label ID="Label2" runat="server" Text="To Date"></asp:Label>
                                    <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" autocomplete="off" placeholder="yyyy-MM-dd"></asp:TextBox>
                                    <cc1:CalendarExtender ID="td" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender>
                                </div>
                                
                                <div class="col-md-4 hidden" id="unit">

                                    <asp:Label ID="Label5" runat="server" Text="Unit"></asp:Label>
                                    <asp:DropDownList ID="ddlUnit" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12 " OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList>

                                </div>
                                <div class="col-md-4 hidden" id="jobstation">
                                    <asp:Label ID="Label6" runat="server" Text="Job Station"></asp:Label>
                                     <asp:DropDownList ID="ddlJobStation" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12 "></asp:DropDownList>

                                </div>
                                <div class="col-md-4 hidden" id="fuelCompany">
                                    <asp:Label ID="Label7" runat="server" Text="Fuel Company"></asp:Label>
                                    <asp:DropDownList ID="ddlFuelCompany" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12 "></asp:DropDownList>
                                </div>
                                <div class="col-md-4 hidden" id="vehicleNo">
                                    <asp:Label ID="Label4" runat="server" Text="Vehicle No"></asp:Label>
                                    <asp:DropDownList ID="ddlVehicleNo" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12 "></asp:DropDownList>
                                </div>
                                
                            </div>
                            <div class="row">
                                <div class="col-md-12 btn-toolbar" id="showbuttonDiv">
                                    <asp:Button ID="btnShow" runat="server" class="btn btn-primary form-control pull-right" OnClientClick="return Validation()" Text="Show" OnClick="btnShow_Click" />
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
        <script>
            $(document).ready(function () {
                Init();
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(Init);
                
            });
            function Init() {
                
            }
            function Validation() {
                var txtFromDate = document.getElementById("txtFromDate").value;
                var txtToDate = document.getElementById("txtToDate").value;
                var report = document.getElementById("ddlReport").value;
                if (report == 0) {
                    ShowNotification("Please Select Report Type", "", "warning");
                    return false;
                }
                else if (txtFromDate == "") {
                    ShowNotification("From date can not be blank", "", "warning");
                    return false;
                } else if (txtToDate == "") {
                    ShowNotification("To date can not be blank", "", "warning");
                    return false;
                }
                return true;

            }
            function showPanel() {
                console.log("show panel");

                var report = document.getElementById("ddlReport").value;

                var unit = document.getElementById("unit");
                var jobstation = document.getElementById("jobstation");
                var fuelCompany = document.getElementById("fuelCompany");
                var vehicleNo = document.getElementById("vehicleNo");
                var showbuttonDiv = document.getElementById("showbuttonDiv");

                //Monthwise TopSheet
                if (report == 1 || report == 2) {

                    vehicleNo.classList.remove("hidden");
                    //showbuttonDiv.classList.add('col-md-9');
                    //showbuttonDiv.classList.remove('col-md-12');
                }
                else if (report == 3 || report == 5) {
                    unit.classList.remove("hidden");
                    jobstation.classList.remove("hidden");
                    fuelCompany.classList.remove("hidden");
                    //showbuttonDiv.classList.add('col-md-9');
                    //showbuttonDiv.classList.remove('col-md-12');
                }
                else if (report == 4) {

                    unit.classList.remove("hidden");
                    jobstation.classList.remove("hidden");
                    //showbuttonDiv.classList.add('col-md-9');
                    //showbuttonDiv.classList.remove('col-md-12');


                }
                else {
                    unit.classList.add("hidden");
                    jobstation.classList.add("hidden");
                    fuelCompany.classList.add("hidden");
                    vehicleNo.classList.add("hidden");
                }

                return true;
            }


        </script>
    </form>

</body>
</html>


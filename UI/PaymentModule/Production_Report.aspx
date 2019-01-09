<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Production_Report.aspx.cs" Inherits="UI.PaymentModule.Production_Report" %>

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
                            <asp:Label runat="server" Text="Production Report" Font-Bold="true" Font-Size="16px"></asp:Label>

                        </div>
                        <div class="panel-body">
                            <div class="row form-group">
                                <div class="col-md-3">
                                    <asp:Label ID="Label1" runat="server" Text="From Date" CssClass="row col-md-12 col-sm-12 col-xs-12"></asp:Label>
                                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control col-md-8 col-sm-8 col-xs-8" autocomplete="off" placeholder="yyyy-MM-dd"></asp:TextBox>
                                    <cc1:CalendarExtender ID="fd" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender>
                                    <asp:TextBox ID="txtFormTime" runat="server" CssClass="form-control col-md-4 col-sm-4 col-xs-4" autocomplete="off" placeholder="HH:mm" Text="00:00"></asp:TextBox>
                                </div>

                                <div class="col-md-3">
                                    <asp:Label ID="Label2" runat="server" Text="To Date" CssClass="row col-md-12 col-sm-12 col-xs-12"></asp:Label>
                                    <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control col-md-8 col-sm-8 col-xs-8" autocomplete="off" placeholder="yyyy-MM-dd"></asp:TextBox>
                                    <cc1:CalendarExtender ID="td" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender>
                                    <asp:TextBox ID="txtToTime" runat="server" CssClass="form-control col-md-4 col-sm-4 col-xs-4" autocomplete="off" placeholder="HH:mm" Text="23:59"></asp:TextBox>


                                </div>
                                <div class="col-md-3">
                                    <asp:Label ID="Label3" runat="server" Text="Ware House"></asp:Label>
                                    <asp:DropDownList ID="ddlWH" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" ></asp:DropDownList>
                                </div>
                               <div class="col-md-3" style="padding-top:20px;">                                
                                <%--<div class="btn-toolbar col-md-12 col-sm-12 col-xs-12" id="showbuttonDiv">--%>
                                    <asp:Button ID="btnShow" runat="server" class="btn btn-primary form-control pull-left" OnClientClick="return Validation()" Text="Show" OnClick="btnShow_Click"/>
                                 <%-- </div>--%>
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
                $("#txtFormTime").timepicker();
                $("#txtToTime").timepicker();
            }
            function Validation() {
                var txtFromDate = document.getElementById("txtFromDate").value;
                var txtToDate = document.getElementById("txtToDate").value;

                if (txtFromDate == "") {
                    ShowNotification("From date can not be blank", "Production Report", "warning");
                    return false;
                } else if (txtToDate == "") {
                    ShowNotification("To date can not be blank", "Production Report", "warning");
                    return false;
                }
                return true;

            }
            


        </script>
    </form>

</body>
</html>


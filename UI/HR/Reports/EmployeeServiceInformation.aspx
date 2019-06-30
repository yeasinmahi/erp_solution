<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeServiceInformation.aspx.cs" Inherits="UI.HR.Reports.EmployeeServiceInformation" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>Employee Information Report</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/updatedJs") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/updatedCss" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel0" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                        <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                </asp:Panel>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server"></cc1:AlwaysVisibleControlExtender>
                <div style="height: 50px; width: 100%"></div>
                <%--=========================================Start My Code From Here===============================================--%>
                <div class="container-fluid">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Employee Information" Font-Bold="true" Font-Size="16px"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <div class="row form-group">    
                                 <div class="col-md-3">
                                      <asp:Label ID="Label1" runat="server" Text="Employee Search" CssClass="row col-md-12 col-sm-12 col-xs-12"></asp:Label>
                                      <asp:TextBox ID="txtEmployeeSearch" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12"></asp:TextBox>
                                 </div>
                                <div class="col-md-3">
                                      <asp:Label ID="Label2" runat="server" Text="Benifit" CssClass="row col-md-12 col-sm-12 col-xs-12"></asp:Label>
                                      <asp:DropDownList ID="ddlBenifit" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12">
                                          <asp:ListItem Value="true">Yes</asp:ListItem>
                                          <asp:ListItem Value="false">No</asp:ListItem>
                                      </asp:DropDownList>
                                 </div>
                                <div class="col-md-3">
                                      <asp:Label ID="Label3" runat="server" Text="Date" CssClass="row col-md-12 col-sm-12 col-xs-12"></asp:Label>
                                      <asp:TextBox ID="txtDate" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" AutoComplete="off"></asp:TextBox>
                                 </div>
                                 <div class="col-md-3" style="padding-top:20px;">   
                                    <asp:Button ID="btnShow" runat="server" class="btn btn-primary form-control pull-left" OnClientClick="return validation();" Text="Show" OnClick="btnShow_Click"/>
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
    </form>
    <script>
        $(function () {
            SetAutoComplete();
             $("#txtDate").datepicker({
                dateFormat: "yy-mm-dd"
            });
        });
        $(document).ready(function() {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_initializeRequest(InitializeRequest);
            prm.add_endRequest(EndRequest);
            SetAutoComplete();

            $("#txtDate").datepicker({
                dateFormat: "yyyy-MM-dd"
            });

        });
        function InitializeRequest(sender, args) {}

        function EndRequest(sender, args) {
              // after update occur on UpdatePanel re-init the Autocomplete
              SetAutoComplete();
        }
        function SetAutoComplete() {
            $("#txtEmployeeSearch").autocomplete({

                source: function (request, response) {
                    //debugger;
                    var param = { strSearchKey: $("#txtEmployeeSearch").val() };
                    $.ajax({
                        url: "All_Employee_Information_Report.aspx/GetAutoCompleteData",
                        data: JSON.stringify(param),
                        dataType:"json",
                        type: "post",
                        contentType: "application/json;charset=utf-8",
                        dataFilter: function (data) { return data; },
                        success: function (data) {
                            response($.map(data.d, function (item) { return {value:item}}))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {  
                             var err = eval("(" + XMLHttpRequest.responseText + ")");  
                            alert(err.Message);
                         } 
                    });
                },
                minLength:1
            });
        }
        function validation() {
            var emp = document.getElementById("txtEmployeeSearch").value;
            if (emp === null || emp === "") {
                ShowNotification('Employee search can not be blank', '', 'warning');
                return false;
            }
        }
    </script>
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
</body>
</html>

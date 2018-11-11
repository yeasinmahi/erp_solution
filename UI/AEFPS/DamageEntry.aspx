<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DamageEntry.aspx.cs" Inherits="UI.AEFPS.DamageEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Item Active/Inactive</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />

    <link href="../Content/CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/CSS/jquery-ui.min.css" rel="stylesheet" />

    <style type="text/css">
        .auto-style1 {
            left: 0px;
            top: 0px;
        }
    </style>

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
                            <asp:Label runat="server" Text="Damage Entry" Font-Bold="true" Font-Size="16px"></asp:Label>

                        </div>
                        <div class="panel-body">
                            <div class="row form-group">
                                <div class="col-md-6">
                                    <asp:Label ID="Label20" runat="server" Text="Warehouse Name" ></asp:Label>  <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                    <asp:DropDownList ID="ddlWh" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" Enabled="False"></asp:DropDownList>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="Label1" runat="server" Text="Item Name"></asp:Label>
                                    <span style="color: red; font-size: 14px; text-align: left">*</span>
                                    <asp:TextBox ID="txtItemName" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="input Item name or Item Id"></asp:TextBox>
                                </div>
                            </div>
                        <div class="row">
                            <div class="col-md-12 btn-toolbar">
                                <asp:Button ID="btnAdd" runat="server" class="btn btn-primary form-control pull-right" Text="Add" OnClientClick="return Validate();" OnClick="btnAdd_Click"/>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel panel-default" id="itemPanel">
                    <div class="panel-body">
                       
                        <div class="form-group pull-right">
                    </div>
                    </div>
                    <form id="frmOptions" method="post" class="span12">
    
</form>

                </div>

                </div>
                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>

    </form>
    <script>
        function showPanel() {
            var txtItemName = document.getElementById("txtItemName").value;
            if (txtItemName === null || txtItemName === "") {
                alert("Item Name can not be empty");
                return false;
            }
            var itemPanel = document.getElementById("itemPanel");
            itemPanel.classList.remove("hidden");
            return true;
        }
        function hidePanel() {
            var itemPanel = document.getElementById("itemPanel");
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

        $(function() {
            $("#txtItemName").autocomplete({
                source: function(request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;",
                        url: "BlockItem.aspx/GetItem",
                        data: "{'prefix':'" + document.getElementById('txtItemName').value + "'}",
                        dataType: "json",
                        success: function(data) {
                            response(data.d);
                        },
                        error: function(result) {
                            alert("Error");
                        }

                    });
                },
                minLength: 3
            });
        });
    </script>
</body>
</html>

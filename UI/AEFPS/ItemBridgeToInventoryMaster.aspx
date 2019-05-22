<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemBridgeToInventoryMaster.aspx.cs" Inherits="UI.AEFPS.ItemBridgeToInventoryMaster" %>

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

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server">
        </asp:ScriptManager>

     
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
                            <asp:Label runat="server" Text="Item Bridge Form" Font-Bold="true" Font-Size="16px"></asp:Label>

                        </div>
                        <div class="panel-body">
                            <div class="row form-group">
                                <div class="col-md-6">
                                    <asp:Label ID="Label20" runat="server" Text="Item Name"></asp:Label>
                                   
                                <asp:TextBox ID="txtItemname"  CssClass="form-control col-md-12 col-sm-12 col-xs-12" AutoPostBack="true" runat="server"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtItemname"
                                    ServiceMethod="ItemnameSearch" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                                </div>
                               
                            </div>
                            <div class="row">
                                <div class="col-md-12 btn-toolbar">
                                    <asp:Button ID="btnAdd" runat="server" class="btn btn-primary form-control pull-right" Text="Add"  OnClick="btnAdd_OnClick" />
                                </div>
                            </div>
                            <div style="height: 20px"></div>
                          
                        </div>
                    </div>
                 
                </div>
                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
          <%--  <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                <asp:PostBackTrigger ControlID="btnInActive" />
            </Triggers>--%>
       
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

       <%-- function ShowHideGridviewPanels() {
            var rowsCount = <%=InActiveItemGridView.Rows.Count %>;
            var itemPanel = document.getElementById("itemPanel");
            if (rowsCount != null && rowsCount > 0) {
                itemPanel.classList.remove("hidden");
            } else {
                itemPanel.classList.add("hidden");
            }
        }--%>
        function autoCompleteItemName() {
            $("#txtItemName").autocomplete({
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
            
            autoCompleteItemName();
            //ShowHideGridviewPanels();
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(autoCompleteItemName);
            //Sys.WebForms.PageRequestManager.getInstance().add_endRequest(ShowHideGridviewPanels);
        });
    </script>
    </form>
    
<style>
    table {
        max-width: 100%;
        background-color: transparent;
        text-align:center;
    }
    th {
        text-align: center;
    }

    .table {
        width: 100%;
        margin-bottom: 20px;
    } 
    tr
    {
        font-size: 14px;
    }
</style>
</body>
</html>


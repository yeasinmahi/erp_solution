<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BlockItem.aspx.cs" Inherits="UI.AEFPS.BlockItem" %>

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
                            <asp:Label runat="server" Text="Item Inactive Form" Font-Bold="true" Font-Size="16px"></asp:Label>

                        </div>
                        <div class="panel-body">
                            <div class="row form-group">
                                <div class="col-md-6">
                                    <asp:Label ID="Label20" runat="server" Text="Warehouse Name"></asp:Label>
                                    <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
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
                                    <asp:Button ID="btnAdd" runat="server" class="btn btn-primary form-control pull-right" Text="Add" OnClientClick="return Validate();" OnClick="btnAdd_OnClick" />
                                </div>
                            </div>
                            <div style="height: 20px"></div>
                            <div>
                                <asp:GridView ID="activeItemGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both" Width="100%"
                                    DataKeyNames="intItemMasterID" OnRowDeleting="activeItemGridView_OnRowDeleting">
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
                                                <asp:TextBox ID="txtRemarks" runat="server" Width="100%" CssClass="form-control input-sm" placeholder="Write remarks here...."></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action" ItemStyle-Width="80px">
                                            <ItemTemplate>
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger btn-xs" CommandName="Delete" />
                                            </ItemTemplate>
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
                                <div class="row">
                                    <div class="col-md-12 btn-toolbar">
                                        <asp:Button ID="btnInActive" runat="server" Text="Inactive" CssClass="btn btn-primary form-control btn-sm pull-right hidden" OnClick="btnInActive_OnClick" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default" id="itemPanel">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Item Active Form" Font-Bold="true" Font-Size="16px"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <asp:GridView ID="InActiveItemGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both" Width="100%"
                                DataKeyNames="intItemMasterID" OnRowDeleting="InActiveItemGridView_OnRowDeleting">
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
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action" ItemStyle-Width="80px">
                                        <ItemTemplate>
                                            <asp:Button ID="btnActive" runat="server" Text="Active" CssClass="btn btn-primary btn-xs" CommandName="Delete" />
                                        </ItemTemplate>
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
                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                <asp:PostBackTrigger ControlID="btnInActive" />
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

        function ShowHideGridviewPanels() {
            var rowsCount = <%=InActiveItemGridView.Rows.Count %>;
            var itemPanel = document.getElementById("itemPanel");
            if (rowsCount != null && rowsCount > 0) {
                itemPanel.classList.remove("hidden");
            } else {
                itemPanel.classList.add("hidden");
            }
        }
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
            ShowHideGridviewPanels();
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(autoCompleteItemName);
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(ShowHideGridviewPanels);
        });
    </script>
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


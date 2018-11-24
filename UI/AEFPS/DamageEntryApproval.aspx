<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DamageEntryApproval.aspx.cs" Inherits="UI.AEFPS.DamageEntryApproval" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Damage Approval</title>
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
                <asp:HiddenField ID="hdnconfirm" runat="server" />
                <div class="container">
                    <div class="panel panel-info">
                        <div class="panel-heading"> <asp:Label runat="server" Text="Damage Approval Form" Font-Bold="true" Font-Size="16px"></asp:Label></div>
                        <div class="panel-body">
                            <div class="row form-group">
                                <div class="col-md-6">
                                    <asp:Label ID="Label20" runat="server" Text="Warehouse Name" ></asp:Label>  <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                    <asp:DropDownList ID="ddlWh" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" style="left: 0px; top: 1px"></asp:DropDownList>
                                </div>
                                <div class="col-md-6 hidden" id="mainPanel">
                                    <asp:Label ID="Label1" runat="server" Text="Total Damage Amount"></asp:Label>
                                    <asp:TextBox ID="txtTotalDamageAmount" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" Enabled="False" style="left: 0px; top: 1px" ></asp:TextBox>
                                </div>
                                
                            </div>
                            <div class="row">
                                <div class="col-md-6" style="padding-top:10px;">
                                    <asp:Button ID="btnShow" runat="server" class="btn btn-primary btn-md form-control pull-left" Text="Show" OnClick="btnShow_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                     <div class="panel panel-info hidden" id="itemPanel">
                          <div class="panel-heading"> <asp:Label runat="server" Text="Damage Approval Details" Font-Bold="true" Font-Size="16px"></asp:Label></div>
                        <div class="panel-body ">
                            <asp:GridView ID="gvDamageEntryApproval" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Both" AutoGenerateColumns="False" DataKeyNames="intItemId" Width="100%" >
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SL">
                                        <ItemTemplate>
                                           <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Entry Date">                                       
                                        <ItemTemplate>
                                            <asp:Label ID="lblActionDate" runat="server" Text='<%# Convert.ToDateTime( Eval("dteActionDate")).ToShortDateString() %>'>' </asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="90px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Code">                                    
                                        <ItemTemplate>
                                            <asp:Label ID="lblVoucherCode" runat="server" Text='<%# Bind("strVoucherCode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item ID">                                       
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemID" runat="server" Text='<%# Bind("intItemId") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item Name">                                    
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("ItemName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="UoM">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUoM" runat="server" Text='<%# Bind("strUoM") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Closing Stock">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStock" runat="server" Text='<%# Bind("numStockQty") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRate" runat="server" Text='<%# Bind("monRate","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cost Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCostAmount" runat="server" Text='<%# Bind("costAmount","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sales Rate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSalesRate" runat="server" Text='<%# Bind("salesPrice","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sales Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSalesAmount" runat="server" Text='<%# Bind("salesAmount","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Damage Quantity">
                                        <ItemTemplate>
                                            <asp:Label ID="txtDamageQty" runat="server" Text='<%# Bind("numDamageQuantity") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="60px" />
                                        
                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Damage Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDamageAmount" runat="server" Text='<%# Bind("monDamageAmount","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks">
                                        <ItemTemplate>
                                            <asp:Label ID="txtRemarks" runat="server" Text='<%# Bind("strRemarks") %>'></asp:Label>
                                        </ItemTemplate>
                                       <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:Button ID="btnReject" runat="server" CssClass="btn btn-danger btn-xs" Text="Reject" CommandName="Reject" OnClientClick="return confirm('Are you sure you want to reject this item?');"  OnClick="btnReject_Click"></asp:Button>
                                             <asp:Button ID="btnApprove" runat="server" CssClass="btn btn-success btn-xs" Text="Approve" CommandName="Approve" OnClientClick="return confirm('Are you sure you want to approve this item?');" OnClick="btnApprove_OnClick"></asp:Button>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="120px"/>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                           <%-- <div class="form-group pull-right" style="padding-top:10px;">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary btn-md"/>
                            </div>--%>
                        </div>


                    </div>

                </div>
                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>

    </form>
   <script>
        function showPanel() {
            var itemPanel = document.getElementById("itemPanel");
            itemPanel.classList.remove("hidden");
            var mainPanel = document.getElementById("mainPanel");
            mainPanel.classList.remove("hidden");
            return true;
        }
        function hidePanel() {
            var itemPanel = document.getElementById("itemPanel");
            itemPanel.classList.add("hidden");
            var mainPanel = document.getElementById("mainPanel");
            mainPanel.classList.add("hidden");

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
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(autoCompleteItemName);
       });

        function ConfirmReject() {
            document.getElementById("hdnconfirm").value = "0";
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to Reject?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
            else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
        }
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
         #gridView tr
        {
            font-size: 10px;
        }
    </style>
</body>
</html>


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseReturn.aspx.cs" Inherits="UI.AEFPS.PurchaseReturn" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Purchase Return</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />

    <link href="../Content/CSS/bootstrap.min.css" rel="stylesheet" />


</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel0" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
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
                            <asp:Label runat="server" Text="Purchase Return Entry" Font-Bold="true" Font-Size="16px"></asp:Label>

                        </div>
                        <div class="panel-body">
                            <div class="row form-group">
                                <div class="col-md-6">
                                    <asp:Label ID="Label20" runat="server" Text="Warehouse Name" ></asp:Label>
                                    <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                    <asp:DropDownList ID="ddlWh" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" Enabled="False"></asp:DropDownList>

                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="Label1" runat="server" Text="MRR Number"></asp:Label>
                                    <span style="color: red; font-size: 14px; text-align: left">*</span>

                                    <asp:TextBox ID="txtMrrNumber" TextMode="Number" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Please Input MRR Number Here"></asp:TextBox>

                                </div>
                            </div>

                        <div class="row form-group hidden" id="infoPanel">
                            <div class="col-md-6">
                                <asp:Label ID="Label2" runat="server" Text="Supplier Name"></asp:Label>
                                <asp:TextBox ID="txtSupplierName" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" Enabled="false" placeholder="eg: Md. Yeasin Arafat"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="Label3" runat="server" Text="Total Return Amount"></asp:Label>
                                <asp:TextBox ID="txtTotalPurchaseReturnAmount" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" Enabled="false" placeholder="Total Purchase Return Amount"></asp:TextBox>

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12 btn-toolbar">
                                <asp:Button ID="btnShow" runat="server" class="btn btn-primary form-control pull-right" Text="Show" OnClientClick="return Validate();" OnClick="btnShow_OnClick" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel panel-default" id="itemPanel">

                    <div class="panel-body">
                        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both" Width="100%" DataKeyNames="intItemID" OnRowDataBound="gridView_RowDataBound" OnRowDeleting="gridView_RowDeleting">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="SL">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item ID">
                                    <ItemTemplate>
                                        <asp:Label ID="iblItemid" runat="server" Text='<%# Bind("intItemID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemName" runat="server" CssClass="pull-left" Text='<%# Bind("ItemName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="UOM">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUom" runat="server" CssClass="pull-left" Text='<%# Bind("strUoM") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Challan No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblChallanNo" runat="server" CssClass="pull-left" Text='<%# Bind("ChallanNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Store Location">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLocation" runat="server" CssClass="pull-left" Text='<%# Bind("strLocationName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MRR Quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMrrQty" runat="server" Text='<%# Bind("numReceiveQty") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Rate">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRate" runat="server" Text='<%# Bind("monRate","{0:n2}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cost Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCostAmount" runat="server" Text='<%# Bind("monBDTTotal","{0:n2}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Closing Stock">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStock" runat="server" CssClass="pull-left" Text='<%# Bind("closingStock") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Return Quantity" ItemStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtReturnQty" runat="server" Width="100%" CssClass="form-control input-sm" placeholder="Write quantity here" OnTextChanged="txtReturnQty_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Return Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblReturnAmount" runat="server" CssClass="pull-left" >></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              
                                <asp:TemplateField HeaderText="Remarks" ItemStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtRemarks" runat="server" Width="100%" CssClass="form-control input-sm" placeholder="Write remarks here...."></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action" ItemStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="Delete"/>
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
                    <div class="col-md-2 pull-right">
                        <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary form-control" Text="Submit" Height="30px" OnClick="btnSubmit_OnClick" />
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
            var txtMrrNumber = document.getElementById("txtMrrNumber").value;
            if (txtMrrNumber === null || txtMrrNumber === "") {
                alert("MRR number can not be empty");
                return false;
            }
            var infoPanel = document.getElementById("infoPanel");
            var itemPanel = document.getElementById("itemPanel");
            //infoPanel.style.visibility = 'visible';
            //itemPanel.style.visibility = 'visible';
            infoPanel.classList.remove("hidden");
            itemPanel.classList.remove("hidden");
            return true;
        }
        function hidePanel() {
            var infoPanel = document.getElementById("infoPanel");
            var itemPanel = document.getElementById("itemPanel");
            infoPanel.classList.add("hidden");
            itemPanel.classList.add("hidden");

        }
        function Validate() {
            var txtMrrNumber = document.getElementById("txtMrrNumber").value;

            if (txtMrrNumber === null || txtMrrNumber === "") {
                alert("MRR number can not be empty");
                return false;
            }
            return true;
        }

    </script>
</body>
</html>


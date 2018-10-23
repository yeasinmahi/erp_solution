<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CostCenterCorrection.aspx.cs" Inherits="UI.BudgetPlan.CostCenterCorrection" %>


<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Cost Center Correction</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <%--<asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>--%>

    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />

    <link href="../Content/CSS/bootstrap.min.css" rel="stylesheet" />
 <%--  <link href="../Content/CSS/bootstrap-datepicker.min.css" rel="stylesheet" />--%>
    <link href="../Content/font-awesome.min.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>

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

                <%--=========================================Start My Code From Here===============================================--%>
                <div class="container">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Cost Center Correction" Font-Bold="true" Font-Size="16px"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-12">
                                        <asp:Label ID="Label20" runat="server" Text="Unit"></asp:Label>
                                        <span style="color: red; font-size: 14px; text-align: left">*</span>
                                    </div>
                                    <div class="col-md-12">
                                        <asp:DropDownList runat="server" ID="ddlUnit" CssClass="form-control col-md-12" AutoPostBack="True" OnSelectedIndexChanged="ddlUnit_OnSelectedIndexChanged"/>
                                        <%--<asp:TextBox ID="txtEnroll" TextMode="Number" CssClass="form-control col-md-12" runat="server" placeholder="Enroll"></asp:TextBox>--%>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-12">
                                        <asp:Label ID="Label1" runat="server" Text="Cost Center"></asp:Label>
                                        <span style="color: red; font-size: 14px; text-align: left">*</span>
                                    </div>
                                    <div class="col-md-12">
                                        <asp:DropDownList runat="server" ID="ddlCostCenter" CssClass="form-control col-md-12"/>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-12">
                                        <asp:Label ID="Label2" runat="server" Text="From Date"></asp:Label>
                                        <span style="color: red; font-size: 14px; text-align: left">*</span>
                                    </div>
                                    <div class="col-md-12">
                                         <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control col-md-12" AutoPostBack="false"   Enabled="true" ></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender></td>

                                        
                                    </div>
                                      
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-12">
                                        <asp:Label ID="Label3" runat="server" Text="From Date"></asp:Label>
                                        <span style="color: red; font-size: 14px; text-align: left">*</span>
                                    </div>
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control col-md-12" AutoPostBack="false"   Enabled="true" ></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender></td>

                                         
                                    </div>
                                </div>
                                <br />
                                <div class="col-md-12 py-3">
                                    <div class="col-md-11"></div>
                                    <div class="col-md-1">
                                        <asp:Button ID="btnShow" runat="server" class="btn btn-primary form-control" Text="Show" OnClick="btnShow_OnClick" />
                                    </div>
                                </div>
                                <%--<div class="col-md-2">
                                    <asp:Button ID="btnAdd" runat="server" class="btn btn-primary form-control" Text="Add" OnClick="btnAdd_OnClick" />
                                </div>--%>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default" id="itemPanel">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Cost Center Details" Font-Bold="true" Font-Size="16px"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both" Width="100%">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>

                                    <asp:TemplateField HeaderText="SL">
                                        <ItemTemplate>
                                            <asp:HiddenField runat="server" ID="hdnSubledgerId" Value='<%# Bind("intSubLedgerID") %>' />
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Code">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtstrCode" runat="server" Text='<%# Bind("strCode") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblstrCode" runat="server" CssClass="pull-left" Text='<%# Bind("strCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Account Name">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtstrAccName" runat="server" Text='<%# Bind("strAccName") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblstrAccName" runat="server" Text='<%# Bind("strAccName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Entry Code">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtstrEntryCode" runat="server" Text='<%# Bind("strEntryCode") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblstrEntryCode" runat="server" Text='<%# Bind("strEntryCode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Narration">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtstrNarration" runat="server" Text='<%# Bind("strNarration") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblstrNarration" runat="server" Text='<%# Bind("strNarration") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtmonAmount" runat="server" Text='<%# Bind("monAmount") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblmonAmount" runat="server" Text='<%# Bind("monAmount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Transaction Date">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtdteTransactionDate" runat="server" Text='<%# Bind("dteTransactionDate") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbldteTransactionDate" runat="server" Text='<%# Bind("dteTransactionDate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action" ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:Button ID="btnUpdate" runat="server" class="btn btn-primary form-control col-md-12" Text="Update" OnClientClick="return ConfirmUpdate()" OnClick="btnUpdate_OnClick" />
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
                <%--<asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />--%>
            </Triggers>
        </asp:UpdatePanel>

    </form>

    <script src="../Content/JS/jquery-3.3.1.js"></script>
    <script src="../Content/JS/bootstrap.min.js"></script>
    <%--<script src="../Content/JS/bootstrap-datepicker.min.js"></script>--%>
     <script src="../Content/JS/datepickr.min.js"></script>

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

        #gridView tr {
            font-size: 14px !important;
        }

        .container {
            padding-top: 50px;
        }

        .full-screen {
            width: 90%;
            margin: 0;
            top: 0;
            left: 0;
        }
    </style>
    <script type="text/javascript">

        
      
        function ConfirmUpdate() {
            if (confirm("Are you want to remove?")) {
                return true;
            }
            return false;
        }

         
    </script>
</body>
</html>

﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodReceiveNote.aspx.cs" Inherits="UI.Inventory.GoodReceiveNote" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Good Receive Note </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../Content/JS/datepickr.min.js"></script>

    <link href="../Content/CSS/bootstrap.min.css" rel="stylesheet" />

    <script type="text/javascript">
        function Validate() {
            var txtPoNumber = document.getElementById("txtPoNumber").value;
            var txtSupplierName = document.getElementById("txtSupplierName").value;
            var txtSupplierAddress = document.getElementById("txtSupplierAddress").value;
            var txtChallanNo = document.getElementById("txtChallanNo").value;
            var txtVehicleNo = document.getElementById("txtVehicleNo").value;
            var txtDriverName = document.getElementById("txtDriverName").value;

            if (txtPoNumber === null || txtPoNumber === "") {
                alert("Po number can not be empty");
                return false;
            }
            else if (txtSupplierName === null || txtSupplierName === "") {
                alert("Supplier Namer can not be empty");
                return false;
            }
            else if (txtSupplierAddress === null || txtSupplierAddress === "") {
                alert("Supplier Address can not be empty");
                return false;
            }
            else if (txtChallanNo === null || txtChallanNo === "") {
                alert("Challan number can not be empty");
                return false;
            }
            else if (txtVehicleNo === null || txtVehicleNo === "") {
                alert("Vechicle number can not be empty");
                return false;
            }
            else if (txtDriverName === null || txtDriverName === "") {
                alert("Driver name can not be empty");
                return false;
            }

            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server">
            <CompositeScript>
                <Scripts>
                    <asp:ScriptReference Name="MicrosoftAjax.js" />
                    <asp:ScriptReference Name="MicrosoftAjaxWebForms.js" />
                    <asp:ScriptReference Name="Common.Common.js" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="Compat.Timer.Timer.js" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="Animation.Animations.js" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="ExtenderBase.BaseScripts.js" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="Common.DateTime.js" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="Animation.AnimationBehavior.js" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="PopupExtender.PopupBehavior.js" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="Common.Threading.js" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="Calendar.CalendarBehavior.js" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                </Scripts>
            </CompositeScript>
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel0" runat="server"  UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                        <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div>
                </asp:Panel>
                <div style="height: 100px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>

                <%--=========================================Start My Code From Here===============================================--%>
                <asp:HiddenField runat="server" ID="hdnSupplerId"/>
                <asp:HiddenField runat="server" ID="hdnshipmentSn"/>
                <div class="container">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Good Receive Note" Font-Bold="true" Font-Size="16px"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-6">
                                        <asp:Label ID="Label20" runat="server" Text="Po Number"></asp:Label>
                                        <span style="color: red; font-size: 14px; text-align: left">*</span>

                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtPoNumber" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-4">
                                        <asp:Button ID="btnShow" runat="server" class="btn btn-primary" Text="Show" Height="30px" CausesValidation="False" OnClick="btnShow_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-6">
                                        <asp:Label ID="Label1" runat="server" Text="Supplier Name"></asp:Label>

                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtSupplierName" CssClass="form-control" runat="server" Enabled="false" ></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-6">
                                        <asp:Label ID="Label2" runat="server" Text="Supplier Address"></asp:Label>

                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtSupplierAddress" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-6">
                                        <asp:Label ID="Label3" runat="server" Text="Challan No"></asp:Label>
                                        <span style="color: red; font-size: 14px; text-align: left">*</span>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtChallanNo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-6">
                                        <asp:Label ID="Label4" runat="server" Text="Vechicle No"></asp:Label>
                                        <span style="color: red; font-size: 14px; text-align: left">*</span>

                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtVehicleNo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-6">
                                        <asp:Label ID="Label5" runat="server" Text="Driver Name"></asp:Label>
                                        <span style="color: red; font-size: 14px; text-align: left">*</span>

                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtDriverName" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-6">
                                        <asp:Label ID="Label6" runat="server" Text="Driver Contact No"></asp:Label>

                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtDriverContact" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-6">
                                        <asp:Label ID="Label7" runat="server" Text="Meterial Description"></asp:Label>

                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtMeterialDes" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>


                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Items Received" Font-Bold="true" Font-Size="14px"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both" Width="100%">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SN">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item Id">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtItem" runat="server" Text='<%# Bind("intItem") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="iblItem" runat="server" Text='<%# Bind("intItem") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item Name">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtItemName" runat="server" Text='<%# Bind("strItem") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("strItem") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Description">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDes" runat="server" Text='<%# Bind("strDes") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblDsc" runat="server" Text='<%# Bind("strDes") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="UoM">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtUoM" runat="server" Text='<%# Bind("strUoM") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblUoM" runat="server" Text='<%# Bind("strUoM") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Po Quantity">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPoQnt" runat="server" Text='<%# Bind("numPOQty") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPoQnt" runat="server" Text='<%# Bind("numPOQty") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Previous Receive">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPreRcvQnt" runat="server" Text='<%# Bind("monPreRcvQty") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPreRcvQnt" runat="server" Text='<%# Bind("monPreRcvQty") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remaining Quantity">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtRemainingQnt" runat="server" Text='<%# Convert.ToDecimal(Eval("numPOQty")) - Convert.ToDecimal(Eval("monPreRcvQty")) %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblRemainingQnt" runat="server" Text='<%# Convert.ToDecimal(Eval("numPOQty")) - Convert.ToDecimal(Eval("monPreRcvQty")) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Receive Quantity">
                                        <ItemTemplate>
                                            <asp:TextBox ID="receiveQuantity" runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks">
                                        <ItemTemplate>
                                            <asp:TextBox ID="receiveRemarks" runat="server" ></asp:TextBox>
                                        </ItemTemplate>
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
                            
                        </div>
                        <div class="col-md-2 pull-right">
                            <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary form-control" Text="Submit" Height="30px" OnClick="btnSubmit_Click" OnClientClick="return Validate()" />
                        </div>
                        
                    </div>
                </div>
                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click"/> 
            <asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click"/> 
        </Triggers>
        </asp:UpdatePanel>

    </form>
</body>
</html>


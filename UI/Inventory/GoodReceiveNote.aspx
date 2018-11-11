<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodReceiveNote.aspx.cs" Inherits="UI.Inventory.GoodReceiveNote" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Goods Receive Note </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script src="../Content/JS/datepickr.min.js"></script>

    <link href="../Content/CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/font-awesome.min.css" rel="stylesheet" />

    <style type="text/css">
        .my-float{
            padding-top: 20px;
            padding-right: 20px;
        }
        .full-screen {
            width: 90%;
            margin: 0;
            top: 0;
            left: 0;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server">
            <CompositeScript>
               <%-- <Scripts>
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
                </Scripts>--%>
            </CompositeScript>
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel0" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                        <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                </asp:Panel>
                <div style="height: 50px; width: 100% ">
                    <a href="https://video.akij.net/watch/6rwsDUwNYKPD1ZK" target="_blank" class="pull-right" data-toggle="tooltip" data-placement="top" title="Tutorial">
                        <i class="fa fa-question-circle fa-3x my-float"></i>
                    </a>
                </div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>

                <%--=========================================Start My Code From Here===============================================--%>
                <asp:HiddenField runat="server" ID="hdnSupplerId" />
                <asp:HiddenField runat="server" ID="hdnshipmentSn" />
                <div class="container">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Goods Receive Note" Font-Bold="true" Font-Size="16px"></asp:Label> 
                            <asp:Label runat="server" ID=lblGrn Font-Bold="true"  Font-Size="16px" CssClass="pull-right" ForeColor="blue"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Label ID="Label20" runat="server" Text="PO Number"></asp:Label>
                                    <span style="color: red; font-size: 14px; text-align: left">*</span>
                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtPoNumber" TextMode="Number" CssClass="form-control col-md-8" runat="server" placeholder="PO Number"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="btnShow" runat="server" class="btn btn-primary form-control" Text="Show" OnClick="btnShow_Click" />
                                </div>
                            </div>
                            <div class="row" id ="infoPanel" style="visibility: hidden">
                                <div class="col-md-6">
                                    <asp:Label ID="Label1" runat="server" Text="Supplier Name"></asp:Label>
                                    <asp:TextBox ID="txtSupplierName" CssClass="form-control" runat="server" Enabled="false" placeholder="eg: Md. Yeasin Arafat"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="Label2" runat="server" Text="Supplier Address"></asp:Label>
                                    <asp:TextBox ID="txtSupplierAddress" runat="server" CssClass="form-control" Enabled="false" placeholder="eg: flat:4b; house: 41/43; Mohammadpur"></asp:TextBox>

                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="Label3" runat="server" Text="Challan No."></asp:Label>
                                    <span style="color: red; font-size: 14px; text-align: left">*</span>

                                    <asp:TextBox ID="txtChallanNo" CssClass="form-control" runat="server" placeholder="Challan No."></asp:TextBox>

                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="Label8" runat="server" Text="Challan Date"></asp:Label>
                                    <span style="color: red; font-size: 14px; text-align: left">*</span>
                                    <asp:TextBox ID="txtChallanDate" CssClass="form-control" runat="server" placeholder="dd/MM/yyyy"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="Label9" runat="server" Text="Shipment/Invoice No."></asp:Label>
                                    <asp:TextBox ID="txtShipmentNo" CssClass="form-control" runat="server" placeholder="Shipment/Invoice No."></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="Label4" runat="server" Text="Vehicle No."></asp:Label>
                                    <span style="color: red; font-size: 14px; text-align: left">*</span>

                                    <asp:TextBox ID="txtVehicleNo" CssClass="form-control" runat="server" placeholder="Vehicle No."></asp:TextBox>

                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="Label5" runat="server" Text="Driver Name"></asp:Label>

                                    <asp:TextBox ID="txtDriverName" CssClass="form-control" runat="server" placeholder="Driver Name"></asp:TextBox>

                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="Label6" runat="server" Text="Driver Contact No."></asp:Label>

                                    <asp:TextBox ID="txtDriverContact" CssClass="form-control" runat="server" placeholder="Contact No."></asp:TextBox>

                                </div>
                                <%--<div class="col-md-12">
                                    <asp:Label ID="Label7" runat="server" Text="Product Description"></asp:Label>

                                    <asp:TextBox ID="txtMeterialDes" TextMode="MultiLine" CssClass="form-control" runat="server" placeholder="Write product description"></asp:TextBox>

                                </div>--%>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default" id="itemPanel" style="visibility: hidden">
                        
                        <div class="panel-body">
                            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both" Width="100%" >
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SL">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item ID">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtItem" runat="server"  Text='<%# Bind("intItem") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="iblItem" runat="server"  Text='<%# Bind("intItem") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item Name">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtItemName" runat="server" Text='<%# Bind("strItem") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemName" runat="server" CssClass="pull-left" Text='<%# Bind("strItem") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Description">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDes" runat="server" Text='<%# Bind("strDes") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblDsc" runat="server" CssClass="pull-left" Text='<%# Bind("strDes") %>'></asp:Label>
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
                                    <asp:TemplateField HeaderText="PO Quantity">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPoQnt" runat="server" Text='<%# Bind("numPOQty","{0:n2}") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPoQnt" runat="server" Text='<%# Bind("numPOQty","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Previous Receive">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPreRcvQnt" runat="server" Text='<%# Bind("monPreRcvQty","{0:n2}") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblPreRcvQnt" runat="server" Text='<%# Bind("monPreRcvQty","{0:n2}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remaining Quantity">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtRemainingQnt" runat="server" Text='<%# Convert.ToDecimal(Eval("numPOQty","{0:n2}")) - Convert.ToDecimal(Eval("monPreRcvQty","{0:n2}")) %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblRemainingQnt" runat="server" Text='<%# Convert.ToDecimal(Eval("numPOQty","{0:n2}")) - Convert.ToDecimal(Eval("monPreRcvQty","{0:n2}")) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Challan Quantity" ItemStyle-Width="100px" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="receiveQuantity" runat="server" Width="100%" placeholder="Quantity"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks" ItemStyle-Width="200px" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="receiveRemarks" runat="server" Width="100%" placeholder="Write remarks here...."></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"/>
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
                            <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary form-control" Text="Submit" Height="30px" OnClick="btnSubmit_Click" OnClientClick="return Validate()" />
                        </div>

                    </div>
                    
                    <%--<button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Video</button>
                    <!-- Modal -->
                    <div id="myModal" class="modal fade" role="dialog">
                        <div class="full-screen">

                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title">How to input GRN</h4>
                                </div>
                                <div class="modal-body">
                                    <video width="100%" src="https://video.akij.net/upload/videos/2018/10/Ry8c4EwTTI7cbdubGF99_04_1d12cdea8de37393d3119d46780bb66d_video_720p_converted.mp4" controls>
                                        <!-- The msg if browser doesn't have HTML5 video support -->
                                    </video>
                                    
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                </div>
                            </div>

                        </div>
                    </div>--%>
                </div>
                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>

    </form>
    
    
    <script type="text/javascript">
       
        function showPanel() {
            var txtPoNumber = document.getElementById("txtPoNumber").value;
            if (txtPoNumber === null || txtPoNumber === "") {
                alert("Po number can not be empty");
                return false;
            }
            var infoPanel = document.getElementById("infoPanel");
            var itemPanel = document.getElementById("itemPanel");
            infoPanel.style.visibility = 'visible'; 
            itemPanel.style.visibility = 'visible'; 

            return true;
        }
        function hidePanel() {
            var infoPanel = document.getElementById("infoPanel");
            var itemPanel = document.getElementById("itemPanel");
            infoPanel.style.visibility = 'hidden'; 
            itemPanel.style.visibility = 'hidden'; 
            
        }
        function Validate() {
            var txtPoNumber = document.getElementById("txtPoNumber").value;
            var txtSupplierName = document.getElementById("txtSupplierName").value;
            var txtSupplierAddress = document.getElementById("txtSupplierAddress").value;
            var txtChallanNo = document.getElementById("txtChallanNo").value;
            var txtChallanDate = document.getElementById("txtChallanDate").value;
            var txtVehicleNo = document.getElementById("txtVehicleNo").value;

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
            else if (txtChallanDate === null || txtChallanDate === "") {
                alert("Challan date can not be empty");
                return false;
            }
            else if (txtVehicleNo === null || txtVehicleNo === "") {
                alert("Vechicle number can not be empty");
                return false;
            }
            if (confirm("Are you want to process?"))
            {
                return true;
            }
            return false;
        }

        $(document).ready(function () {
            $("#txtChallanDate").datepicker(
                { dateFormat: 'dd/mm/yy' }
            );
        });

        //Re-bind for callbacks
        var prm = Sys.WebForms.PageRequestManager.getInstance(); 

        prm.add_endRequest(function() { 
            $("#txtChallanDate").datepicker(
                { dateFormat: 'dd/mm/yy' }
            );
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
         #gridView tr
        {
            font-size: 10px;
        }
    </style>
</body>
</html>


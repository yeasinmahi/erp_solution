<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportFileManagement.aspx.cs" Inherits="UI.Import.ImportFileManagement" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Import File Manager</title>
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
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                        <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                </asp:Panel>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>

                <div style="height: 50px; width: 100%"></div>
                <%--=========================================Start My Code From Here===============================================--%>
                <asp:HiddenField runat="server" ID="hdLcId" />
                <div class="container">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Import File Manager" Font-Bold="true" Font-Size="16px"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-6 col-sm-6 col-sm-6">
                                    <asp:Label ID="Label5" runat="server" Text="PO Number"></asp:Label>
                                    <asp:TextBox ID="txtPoNumber" TextMode="Number" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="PO Number"></asp:TextBox>

                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label6" runat="server" Text="LC Number"></asp:Label>
                                    <asp:TextBox ID="txtLcNumber" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="LC Number"></asp:TextBox>
                                </div>
                                <div class="col-md-12 col-sm-12" style="padding-top: 10px;">
                                    <asp:Button ID="btnShow" runat="server" class="btn btn-primary form-control" Text="Show" OnClick="btnShow_Click" />
                                </div>
                            </div>
                            <div class="row" id="infoPanel" style="visibility: hidden">
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label8" runat="server" Text="Unit Name"></asp:Label>
                                    <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                    <asp:DropDownList ID="ddlUnitName" CssClass="form-control col-md-12 col-sm-12 col-xs-12" Enabled="False" runat="server"></asp:DropDownList>
                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label9" runat="server" Text="Shipment Number"></asp:Label>
                                    <asp:DropDownList ID="ddlShipment" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server"></asp:DropDownList>
                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label1" runat="server" Text="File Group"></asp:Label>
                                    <asp:DropDownList ID="ddlFileGroup" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFileGroup_OnSelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label2" runat="server" Text="Remarks"></asp:Label>
                                    <asp:TextBox ID="txtNote" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" placeholder="Remarks"></asp:TextBox>

                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label3" runat="server" Text="Upload"></asp:Label>
                                    <span style="color: red; font-size: 14px; text-align: left">*</span>
                                    <asp:FileUpload ID="fileUpload" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" ClientIDMode="Static" EnableViewState="true"></asp:FileUpload>
                                </div>
                                
                                <div class="col-md-12 col-sm-12" style="padding-top: 15px;">
                                    <asp:Button ID="btnAddNewFile" runat="server" class="btn btn-primary form-control"  Text="Submit" OnClick="btnAddNewFile_OnClick" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default" id="itemPanel" style="visibility: hidden">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Import File Details" Font-Bold="true" Font-Size="16px"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both" Width="100%" OnRowCommand="gridView_OnRowCommand" OnRowDataBound="gridView_OnRowDataBound">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SL">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="File Id">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtFileId" runat="server" Text='<%# Bind("intFileID") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="iblFileId" runat="server" Text='<%# Bind("intFileID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="File Group Name">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtFileName" runat="server" Text='<%# Bind("strFileName") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblFileName" runat="server" Text='<%# Bind("strFileName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtRemarks" runat="server" Text='<%# Bind("strRemarks") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("strRemarks") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="File Path">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtFtpPath" runat="server" Text='<%# Bind("strFtpPath") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblFtpPath" runat="server" Text='<%# Bind("strFtpPath") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action" ItemStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:Button ID="btnDownload" runat="server" class="btn btn-primary form-control" Text="Download" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Download" />
                                            <asp:Button ID="btnView" runat="server" class="btn btn-primary form-control" Text="View File" CommandArgument="<%# Container.DataItemIndex %>" CommandName="View" />
                                        </ItemTemplate>
                                        <ItemStyle Width="200px" />
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
                    <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                <asp:PostBackTrigger ControlID="btnAddNewFile" />
            </Triggers>
        </asp:UpdatePanel>



    <style>
        table {
            max-width: 100%;
            background-color: transparent;
            text-align: center;
        }

        th {
            text-align: center;
            font-size: 14px;
        }

        .table {
            width: 100%;
            margin-bottom: 20px;
        }

        tr {
            font-size: 14px;
        }

    </style>
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
        
    </script>
   
    </form>
</body>
</html>


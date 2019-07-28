<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AGLandTrxGeneralED.aspx.cs" Inherits="UI.Property.AGLandTrxGeneralED" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AG Land Trx. General Edit & Delete</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/CommonStyle.css" rel="stylesheet" />
    <link href="../Content/CSS/PropertyStyle.css" rel="stylesheet" />
       <link href="../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script src="../Content/JS/datepickr.min.js"></script>
    <script src="../Content/JS/JSSettlement.js"></script>
    <link href="../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../Content/CSS/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="frmAGLandTrxGeneralEditDelete" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                            <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                        </marquee>
                    </div>
                </asp:Panel>
                <div style="height: 30px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <asp:HiddenField ID="hfConfirm" runat="server" />
                <asp:HiddenField ID="hdnconfirm" runat="server" />
                <div class="divbody" style="padding-right: 10px;">
                    <div class="tabs_container" style="background-color: #dcdbdb; padding-top: 10px; padding-left: 5px; padding-right: -50px; border-radius: 5px;">
                        Existing AG Land Edit & Delete<hr />
                    </div>
                    <div style="margin-top: 2px">
                        <table class="table2" style="width: 70%">
                            <tr>
                                <td class="td-lbl2">
                                    <asp:Label ID="Label45" CssClass="lbl-txt" runat="server" Text="From Date :"></asp:Label>
                                </td>
                                <td class="td-txt-ddl2">
                                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="txt-field"></asp:TextBox>
                                    <cc1:CalendarExtender runat="server" ID="CalendarExtender11" TargetControlID="txtFromDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                </td>
                                <td class="td-lbl2">
                                    <asp:Label ID="Label46" CssClass="lbl-txt" runat="server" Text="To Date :"></asp:Label>
                                </td>
                                <td class="td-txt-ddl2">
                                    <asp:TextBox ID="txtToDate" runat="server" CssClass="txt-field"></asp:TextBox>
                                    <cc1:CalendarExtender runat="server" ID="CalendarExtender2" TargetControlID="txtToDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="td-lbl2">
                                    <asp:Label ID="Label40" CssClass="lbl-txt" runat="server" Text="Deed No :"></asp:Label></td>
                                <td class="td-txt-ddl2">
                                    <asp:TextBox ID="txtShowDeedNo" runat="server" CssClass="txt-field"></asp:TextBox>
                                </td>
                                <td colspan="2">
                                    <asp:Button ID="btnDeedDataShow" runat="server" class="btn btn-add" Font-Bold="true" Style="float: right" Text="Show" OnClick="btnDeedDataShow_Click" />
                                </td>
                            </tr>

                        </table>
                        <div style="margin-top: 5px"></div>
                        <div style="height: 400px; overflow: scroll">
                            <asp:GridView ID="dgvDeedDataShow" runat="server" AutoGenerateColumns="False" 
                                Font-Size="11px" BackColor="White"
                                BorderColor="#999999" BorderStyle="Solid"
                                BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SL No.">
                                        <ItemStyle HorizontalAlign="center" Width="15px" />
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                            <asp:HiddenField runat="server" ID="hfLandGeneralPK"  Value='<%# Bind("intLandGeneralPK") %>'/>
                                            <asp:HiddenField runat="server" ID="hfUnitID" Value='<%# Bind("intUnitId") %>' />
                                            <asp:HiddenField runat="server" ID="hfMouzaID" Value='<%# Bind("intMouzaId") %>' />
                                            <asp:HiddenField runat="server" ID="hfPlotTypeID" Value='<%# Bind("intPlotTypeId") %>'/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Unit">
                                        <ItemTemplate>
                                            <asp:Label ID="lblgvUnit" runat="server" Text='<%# Bind("strUnit") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="35px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mouza">
                                        <ItemTemplate>
                                            <asp:Label ID="lblgvMouza" runat="server" Text='<%# Bind("strMouza") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="65px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Deed No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblgvDeedNo" runat="server" Text='<%# Bind("strDeedNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Seller">
                                        <ItemTemplate>
                                            <asp:Label ID="lblgvSeller" runat="server" Text='<%# Bind("strSellerName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="150px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Plot Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblgvPlotType" runat="server" Text='<%# Bind("strPlotType") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Plot No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblgvPlotNo" runat="server" Text='<%# Bind("strPlotNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Purchase Plot">
                                        <ItemTemplate>
                                            <asp:Label ID="lblgvPurchasePlot" runat="server" Text='<%# Bind("numPurchasedPlotArea") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="LDTR">
                                        <ItemTemplate>
                                            <asp:Label ID="lblgvLDTR" runat="server" Text='<%# Bind("intBanglaYear") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="File Name" SortExpression="strFileName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblgvFileName" runat="server" Text='<%# Bind("strFilePath") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="250px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblgvInsertDate" runat="server" Text='<%# Bind("dteInsertDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Submit BY">
                                        <ItemTemplate>
                                            <asp:Label ID="lblgvqSubmitBY" runat="server" Text='<%# Bind("Employee") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:Button runat="server" ID="btnGVDelete" OnClientClick="Confirms();" OnClick="btnGVDelete_Click" Text="Delete" />
                                            <asp:Button runat="server" ID="btnGVEdit" OnClick="btnGVEdit_Click" Text="Edit" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left"/>
                                    </asp:TemplateField>

                                </Columns>
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" Font-Size="15px" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            </asp:GridView>
                        </div>

                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>

    </form>

    <script type="text/javascript">
        function Confirms() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) {
                confirm_value.value = "Yes";
                document.getElementById("hdnconfirm").value = "1";
            } else {
                confirm_value.value = "No";
                document.getElementById("hdnconfirm").value = "0";
            }

        }
    </script>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportAdjustment.aspx.cs" Inherits="UI.Accounts.Import.ImportAdjustment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Import Adjustment for CnF & Maturity Payment</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/jquery-ui.css" rel="stylesheet" />
    <link href="../../Content/CSS/Application.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" />
    <link href="../../Content/CSS/Gridstyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <script src="../../Content/JS/JQUERY/jquery.min.js"></script>
    <script src="../../Content/JS/JQUERY/jquery-ui.min.js"></script>
    <script src="../../Content/JS/CustomizeScript.js"></script>
</head>
<body>
    <form id="frmImportAdjustment" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:HiddenField ID="hdnconfirm" runat="server" />
                <asp:HiddenField ID="hdnEnroll" runat="server" />
                <asp:HiddenField ID="hdnUnit" runat="server" />

                <div class="divbody" style="padding-right: 10px;">
                    <div id="divLevel1" class="tabs_container"
                        style="background-color: #dcdbdb; padding-top: 10px; 
                        padding-left: 5px; padding-right: -50px; border-radius: 5px;padding-bottom: 5px;">
                        <asp:Label ID="lblHeading" runat="server" CssClass="lbl" Text="Import Adjustment for CnF & Maturity Payment" Font-Bold="true" Font-Size="16px"></asp:Label>
                        <hr />
                        <table class="tbldecoration" style="width: auto; float: left;">
                            <tr>
                                <td style="text-align: right;">
                                    <asp:Label ID="lblUnit" runat="server" Text="Unit : "></asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="23px"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td style="text-align: right;">
                                    <asp:Label ID="Label13" runat="server" Text="From Date :"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="lbl" style="text-align:left;font-size:12px"></asp:TextBox>
                                    <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtFromDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                </td>
                                <td style="text-align: right;">
                                    <asp:Label ID="Label2" runat="server" Text="To date : "></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtToDate" runat="server" CssClass="lbl" style="text-align:left;font-size:12px"></asp:TextBox>
                                    <cc1:CalendarExtender runat="server" ID="CalendarExtender2" TargetControlID="txtToDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                </td>
                                <td style="text-align: right;">
                                    <asp:Button runat="server" ID="btnReportShow" Text="Show" CssClass="btnstyle-sm" OnClick="btnReportShow_Click" />
                                    <asp:Button runat="server" ID="btnSubmit" Text="Update" CssClass="btnstyle-sm" OnClientClick = "ConfirmAll()" OnClick="btnSubmit_Click"  />
                                </td>
                            </tr>
                            <tr></tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="dgvReportForImportVoucher" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
                                        CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" Font-Size="10px" BackColor="White" 
                                        BorderColor="#999999" BorderStyle="Solid" ForeColor="Black" GridLines="Vertical" >
                                        <AlternatingRowStyle BackColor="#CCCCCC" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="SL No.">
                                                <ItemStyle HorizontalAlign="center" Width="60px" />
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                    <asp:HiddenField runat="server" ID="hfGVLCType" Value='<%# Bind("intLcType") %>' />
                                                    <asp:HiddenField runat="server" ID="hfGVShipID" Value='<%# Bind("intShipId") %>' />
                                                    <asp:HiddenField runat="server" ID="hfGVCostGroup" Value='<%# Bind("intCostGroup") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="LC No." SortExpression="strLc">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLcNo" runat="server" Text='<%# Bind("strLc") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" Width="150px" />
                                            </asp:TemplateField>

                                            <%--<asp:TemplateField HeaderText="LC Type" SortExpression="intLcType">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLCType" runat="server" Text='<%# Bind("intLcType") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="center" Width="80px" />
                                            </asp:TemplateField>--%>

                                            <asp:TemplateField HeaderText="Ship No" SortExpression="intShipNo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblShipNo" runat="server" Text='<%# Bind("intShipNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="center" Width="80px" />
                                            </asp:TemplateField>

                                            <%--<asp:TemplateField HeaderText="Ship ID" ItemStyle-HorizontalAlign="left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblShipID" runat="server" Text='<%# Bind("intShipId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>

                                            <asp:TemplateField HeaderText="Cost Group" SortExpression="strCostGroup">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCostGroup" runat="server" Text='<%# Bind("strCostGroup") %>' Width="150px"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="center" Width="80px" />
                                            </asp:TemplateField>

                                            <%--<asp:TemplateField HeaderText="Cost Group ID" SortExpression="intCostGroup">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCostGroupID" runat="server" Text='<%# Bind("intCostGroup") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" Width="150px" />
                                            </asp:TemplateField>--%>

                                            <asp:TemplateField HeaderText="Prov Tk." SortExpression="monProvTk">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProvTk" runat="server" Text='<%# Bind("monProvTk", "{0:n2}") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Right" Width="100px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Prov Date" SortExpression="dteProvDate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblProvDate" runat="server" Text='<%# Bind("dteProvDate","{0:dd/MM/yyyy}") %>' Width="80px"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="left" Width="80px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Actual Value" SortExpression="monActual">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblActualValue" runat="server" Text='<%# Bind("monActual", "{0:n2}") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Right" Width="100px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Actual Date" SortExpression="dteActualDate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblActualDate" runat="server" Text='<%# Bind("dteActualDate","{0:dd/MM/yyyy}") %>' Width="100px"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkHeader" runat="server" /></HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkRow" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>

    <script type="text/javascript">
         $("[id*=chkHeader]").live("click", function () {
             var chkHeader = $(this);
             var grid = $(this).closest("table");
             $("input[type=checkbox]", grid).each(function () {
                 if (chkHeader.is(":checked")) {
                     $(this).attr("checked", "checked");
                     $("td", $(this).closest("tr")).addClass("selected");
                 } else {
                     $(this).removeAttr("checked");
                     $("td", $(this).closest("tr")).removeClass("selected");
                 }
             });
         });
         $("[id*=chkRow]").live("click", function () {
             var grid = $(this).closest("table");
             var chkHeader = $("[id*=chkHeader]", grid);
             if (!$(this).is(":checked")) {
                 $("td", $(this).closest("tr")).removeClass("selected");
                 chkHeader.removeAttr("checked");
             } else {
                 $("td", $(this).closest("tr")).addClass("selected");
                 if ($("[id*=chkRow]", grid).length == $("[id*=chkRow]:checked", grid).length) {
                     chkHeader.attr("checked", "checked");
                 }
             }
         });
    </script>
</body>
</html>

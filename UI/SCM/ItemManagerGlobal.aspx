<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemManagerGlobal.aspx.cs" Inherits="UI.SCM.ItemManagerGlobal" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%--<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

        </div>
    </form>
</body>
</html>--%>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/updatedJs") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/updatedCss" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/GridView.css" rel="stylesheet" />
    <%--<link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />--%>

    <script type="text/javascript">
        function funConfirmAll() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnConfirm").value = "1"; }
            else { confirm_value.value = "No"; document.getElementById("hdnConfirm").value = "0"; }
        }
    </script>
</head>

<body>

    <form id="frmselfresign" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                </asp:Panel>
                <div style="height: 30px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>

                <%--=========================================Start My Code From Here===============================================--%>

                <div class="leaveApplication_container">
                    <asp:HiddenField ID="hdnConfirm" runat="server" />
                    <asp:HiddenField ID="hdnUnit" runat="server" />
                    <asp:HiddenField ID="hdnIndentNo" runat="server" />
                    <asp:HiddenField ID="hdnIndentDate" runat="server" />

                    <div class="tabs_container" style="text-align: center;text-decoration: underline">Item Manager
                    </div>
                    <table>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Ware House"></asp:Label></td>
                            <td style="text-align: left; Width:250px">
                                <asp:DropDownList ID="ddlWh" CssClass="ddList" Font-Bold="False" AutoPostBack="true" Width="250px" runat="server" OnSelectedIndexChanged="ddlWh_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: right;">Item List</td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtItem" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" Width="250px"></asp:TextBox></td>
                            <td colspan="1" style="text-align: left;">
                                <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <asp:ListBox ID="ListDatas" Width="800px" Height="200px" DataMember="s" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ListDatas_SelectedIndexChanged"></asp:ListBox>
                            </td>
                        </tr>
                        <%--<tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Store Location"></asp:Label></td>
                            <td colspan="3" style="text-align: left;">
                                <asp:DropDownList ID="ddlLocation" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server">
                                </asp:DropDownList></td>
                            <td  style="text-align: left;">
                                <asp:Button ID="btnAdd" runat="server" Text="Add Item" OnClick="btnAdd_Click" /></td>
                        </tr>--%>
                    </table>
                    
                    <div style="width: 100%">
                        <asp:GridView runat="server" ID="gridView" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both" 
                            OnRowDataBound="gridView_OnRowDataBound">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="SL">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Master Id">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblMasterId" Text='<%# Bind("intMasterId") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item Name">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblItemName" Text='<%# Bind("strItemName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="UoM">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblUom" Text='<%# Bind("strUom") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Store Location">
                                    <ItemTemplate>
                                        <asp:DropDownList runat="server" ID="ddlStoreLocation"></asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Type">
                                    <ItemTemplate>
                                        <asp:DropDownList runat="server" ID="ddlType"></asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Groupe">
                                    <ItemTemplate>
                                        <asp:DropDownList runat="server" ID="ddlGroupe"></asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Category">
                                    <ItemTemplate>
                                        <asp:DropDownList runat="server" ID="ddlCategory"></asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Minor Category">
                                    <ItemTemplate>
                                        <asp:DropDownList runat="server" ID="ddlMinorCategory"></asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="btnAdd" Text="Add" OnClick="btnAdd_OnClick"></asp:Button>
                                        <asp:Button runat="server" ID="btnRemove" Text="Remove" OnClick="btnRemove_OnClick"></asp:Button>
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
                </div>
                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

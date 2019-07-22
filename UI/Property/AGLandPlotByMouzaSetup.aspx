<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AGLandPlotByMouzaSetup.aspx.cs" Inherits="UI.Property.AGLandPlotByMouzaSetup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AG Land Plot By Mouza</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
        <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
    </asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../Content/CSS/AutoComplete.css" rel="stylesheet" />
    <script src="../Content/JS/datepickr.min.js"></script>
    <script src="../Content/JS/JSSettlement.js"></script>
    <link href="../Content/CSS/jquery-ui.css" rel="stylesheet" />
    <link href="../Content/CSS/Application.css" rel="stylesheet" />
    <script src="../Content/JS/jquery-3.3.1.js"></script>
    <script src="../Content/JS/jquery-ui.min.js"></script>
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />
</head>
<body>
    <form id="frmAGLandPlotByMouza" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                        <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div>
                </asp:Panel>
                <div style="height: 100px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <asp:HiddenField ID="hdnconfirm" runat="server" />
                <div class="divbody" style="padding-right: 10px;">
                    <div class="tabs_container" style="background-color: #dcdbdb; padding-top: 10px; padding-left: 5px; padding-right: -50px; border-radius: 5px;">
                        AG Land Plot By Mouza Setup<hr />
                    </div>
                    <table style="width: auto; float: left;">
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblMouzaName" runat="server" CssClass="lbl" Text="Mouza Name :"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlMouzaName" CssClass="ddList" runat="server" Width="220px" Height="23px">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblPlotType" runat="server" CssClass="lbl" Text="Plot Type : "></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlPlotType" CssClass="ddList" runat="server" Width="220px" Height="23px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblPlotNo" runat="server" CssClass="lbl" Text="Plot No : "></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtPlotNo" CssClass="txtBox1" runat="server"></asp:TextBox>
                                <asp:HiddenField runat="server" ID="hfPlotID" />
                            </td>
                            <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Plot Area : "></asp:Label>
                            </td>
                            <td>
                                 <asp:TextBox ID="txtPlotArea" CssClass="txtBox1" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Is Active :"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlIsActive" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="23px">
                                </asp:DropDownList>
                            </td>
                            <td colspan="3">
                                 <asp:Button ID="btnShow" runat="server" Style="float: right" class="myButton" Text="Show" Width="100px" OnClick="btnShow_Click" />
                                <asp:Button ID="btnAdd" runat="server" Style="float: right" class="myButton" Text="Add" Width="100px" OnClick="btnAdd_Click" />
                                <asp:Button ID="btnPlotByMouzaSubmit" runat="server" Style="float: right" class="myButton" Text="Submit" Width="100px" OnClientClick="ConfirmAll()" OnClick="btnPlotByMouzaSubmit_Click" />
                                <asp:Button ID="btnUpdate" runat="server" Style="float: right" class="myButton" Text="Update" Width="100px" OnClientClick="ConfirmAll()" OnClick="btnUpdate_Click" />
                            </td>
                        </tr>

                    </table>

                    <div style="margin-top:5px">
                        <asp:GridView ID="dgvPlotByMouzaSetup" runat="server" AutoGenerateColumns="False" Font-Size="11px" BackColor="White"
                            BorderColor="#999999" BorderStyle="Solid"
                            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"
                            OnRowDeleting="dgvPlotByMouzaSetup_RowDeleting">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:TemplateField HeaderText="SL No.">
                                    <ItemStyle HorizontalAlign="center" Width="15px" />
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Mouza">
                                    <ItemTemplate>
                                        <asp:Label ID="label1" runat="server" Text='<%# Bind("strMouza") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Plot Type">
                                    <ItemTemplate>
                                        <asp:Label ID="label2" runat="server" Text='<%# Bind("strPlotType") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Plot No">
                                    <ItemTemplate>
                                        <asp:Label ID="label3" runat="server" Text='<%# Bind("strPlotNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Plot Area">
                                    <ItemTemplate>
                                        <asp:Label ID="label4" runat="server" Text='<%# Bind("strPlotArea") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                                <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" />

                            </Columns>
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        </asp:GridView>
                    </div>
                    <div style="margin-top:15px">
                        <h3>Existing Plot By Mouza List</h3>
                        <asp:GridView ID="dgvPlotByMouzaList" runat="server" AutoGenerateColumns="False" 
                            Font-Size="11px" BackColor="White" DataKeyNames="ID"
                            BorderColor="#999999" BorderStyle="Solid"
                            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"
                            OnSelectedIndexChanged="dgvPlotByMouzaList_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:TemplateField HeaderText="SL No.">
                                    <ItemStyle HorizontalAlign="center" Width="15px" />
                                    <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                    
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Mouza">
                                    <ItemTemplate>
                                        <asp:Label ID="label10" runat="server" Text='<%# Bind("strMouza") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Plot Type">
                                    <ItemTemplate>
                                        <asp:Label ID="label11" runat="server" Text='<%# Bind("strPlotType") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Plot No">
                                    <ItemTemplate>
                                        <asp:Label ID="label12" runat="server" Text='<%# Bind("strPlotNo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Plot Area">
                                    <ItemTemplate>
                                        <asp:Label ID="label13" runat="server" Text='<%# Bind("numPlotArea") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="Is Active">
                                    <ItemTemplate>
                                        <asp:Label ID="label14" runat="server" Text='<%# Bind("isActive") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>--%>

                                <asp:CommandField HeaderText="Action" ButtonType="Button" ShowSelectButton="true" />

                            </Columns>
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        </asp:GridView>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

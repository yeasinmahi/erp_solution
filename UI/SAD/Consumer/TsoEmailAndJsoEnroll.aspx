<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TsoEmailAndJsoEnroll.aspx.cs" Inherits="UI.SAD.Consumer.TsoEmailAndJsoEnroll" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

</head>
<body>
    <form id="frmpdv" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                            <span class="message-text" id="msg">
                                <%# UI.ClassFiles.CommonClass.GetGlobalMessage() %>
                            </span>
                        </marquee>
                    </div>
                    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div>
                </asp:Panel>
                <div style="height: 100px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>

                <%--=========================================Start My Code From Here===============================================--%>

                <div class="leaveApplication_container">
                    <div class="tabs_container">
                        Tso Email & JSO Enrol Update :
                        <asp:HiddenField ID="hdCustomerIdEnterprise" runat="server" />
                    </div>
                    <table border="0" style="width: Auto">
                        <tr class="tblroweven">
                            <td style="text-align: right;">
                                <asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Region"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlRegion" CssClass="ddList" runat="server" EnableViewState="true" AutoPostBack="True" OnSelectedIndexChanged="ddlRegion_OnSelectedIndexChanged"></asp:DropDownList>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Area"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlArea" CssClass="ddList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlArea_OnSelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr class="tblroweven">
                            <td style="text-align: right;">
                                <asp:Label ID="Label4" CssClass="lbl" runat="server" Text="Teritory"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlTerritory" CssClass="ddList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTerritory_OnSelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr class="tblroweven">
                            <td>
                                <asp:Button ID="show" runat="server" BackColor="#ffcccc" Font-Bold="true" Text="Show" OnClick="show_OnClick" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="leaveApplication_container">
                    <table>
                        <tr class="tblroweven">
                            <td>
                                <asp:GridView ID="grdvCustomerWithIhb" runat="server" AutoGenerateColumns="false" RowStyle-Wrap="true" HeaderStyle-Wrap="true">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL.">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                                <asp:HiddenField ID="intID" runat="server" Value='<%# Bind("intID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="strText" HeaderText="Territory Name" SortExpression="strText" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="strEmailAddress" HeaderText="Previous TSO Email" SortExpression="strEmailAddress" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="intJSOid" HeaderText="Previous JSO Enroll" SortExpression="intJSOid" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:TemplateField HeaderText="New Territory Sales Office Email">
                                            <ItemTemplate>
                                                <asp:TextBox ID="strEmailAddressNew" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="New JSO Enroll">
                                            <ItemTemplate>
                                                <asp:TextBox ID="intJSOidNew" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:Button ID="update" runat="server" BackColor="#ffcccc" Font-Bold="true" Text="Update" OnClick="update_OnClick" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:CommandField ControlStyle-BackColor="#ff9900" ShowDeleteButton="True" />--%>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GhatEntry.aspx.cs" Inherits="UI.SAD.Consumer.GhatEntry" %>
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
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div>
                </asp:Panel>
                <div style="height: 100px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>

                <%--=========================================Start My Code From Here===============================================--%>

                <div class="leaveApplication_container">
                    <div class="tabs_container">
                        Star Consumer Bill Entry :
                    </div>
                    <table border="0" style="width: Auto">
                        <tr class="tblroweven">
                            <td style="text-align: right;">
                                <asp:Label ID="lbl1" CssClass="lbl" runat="server" Text="Ghat Name"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="ghatNameTextBox" AutoPostBack="false" runat="server" CssClass="txtBox"></asp:TextBox>
                            </td>
                            
                            <td style="text-align: right;">
                                <asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Address"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="addressTextBox" AutoPostBack="false" runat="server" CssClass="txtBox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="tblroweven">
                            <td style="text-align: right;">
                                <asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Contact Person"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="contactPersonTextBox" AutoPostBack="false" runat="server" CssClass="txtBox"></asp:TextBox>
                            </td>
                            
                            <td style="text-align: right;">
                                <asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Contact Number"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="contactNumberTextBox" AutoPostBack="false" runat="server" CssClass="txtBox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="tblroweven">
                            <td>
                                <asp:Button ID="submit" runat="server" BackColor="#ffcccc" Font-Bold="true" Text="Submit" OnClick="submit_OnClick" />
                            </td>
                            <td>
                                <asp:Button ID="showReport" runat="server" BackColor="#ffcccc" Font-Bold="true" Text="Report" OnClick="showReport_OnClick" OnClientClick="aspnetForm.target ='_blank'" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="leaveApplication_container grid">
                    <table>
                        <tr class="tblroweven">
                            <td>
                                <asp:GridView ID="grdv" runat="server" AutoGenerateColumns="false" RowStyle-Wrap="true" HeaderStyle-Wrap="true">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL.">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                                <asp:HiddenField ID="intId" runat="server" Value='<%# Bind("intId") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="strName" HeaderText="Ghat Name" SortExpression="strName" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="strAddress" HeaderText="Address" SortExpression="strAddress" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
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



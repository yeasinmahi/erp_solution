<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChartOfAccountUpdate.aspx.cs" Inherits="UI.Accounts.ChartOfAccount.ChartOfAccountUpdate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Supplier COA </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/updatedJs") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/updatedCss" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="frmSupplierCOA" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>

                <%--=========================================Start My Code From Here===============================================--%>

                <div class="divbody" style="padding-right: 10px;">
                    <div id="divLevel1" class="tabs_container" style="background-color: #dcdbdb; padding-top: 10px; padding-left: 5px; padding-right: -50px; border-radius: 5px;">
                        <asp:Label ID="lblHeading" runat="server" CssClass="lbl" Text="Chart of Account Update" Font-Bold="true" Font-Size="16px"></asp:Label><hr />
                    </div>
                    <table class="tbldecoration" style="width: auto; float: left;">

                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblLoanType" runat="server" CssClass="lbl" Text="Unit"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlUnit" CssClass="ddList"
                                    Font-Bold="False" runat="server" onchange="showLoader()"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged1">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="dgvItemList" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8" Font-Size="10px"
                                    CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                                    HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="10px" HeaderStyle-Font-Bold="true"
                                    ForeColor="Black" GridLines="Vertical">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SN">
                                            <ItemStyle HorizontalAlign="center" Width="30px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Acc Id" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAccountId" runat="server" Text='<%# Bind("intAccID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Parent Code 1">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCode1" runat="server" Text='<%# Bind("strCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Parent Name 1" SortExpression="strItem">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAccountName1" runat="server" Text='<%# Bind("strAccName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Parent Code 2" SortExpression="strReqItemCategory">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCode2" runat="server" Text='<%# Bind("strCode1") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Parent Name 2" SortExpression="strSubCategory">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAccountName2" runat="server" Text='<%# Bind("strAccName1") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Sub-Leager Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCode3" runat="server" Text='<%# Bind("strCode2") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Sub-Leager Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAccountName3" runat="server" Text='<%# Bind("strAccName2") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sub Leadger">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtCOA" runat="server" AutoCompleteType="Search" CssClass="txtBox1"  Width="300px"></asp:TextBox>
                                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtCOA"
                                                    ServiceMethod="GetLedgerName" MinimumPrefixLength="3" CompletionSetCount="1" CompletionInterval="1"
                                                    FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                </cc1:AutoCompleteExtender>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" Width="70px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle Font-Size="11px" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
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

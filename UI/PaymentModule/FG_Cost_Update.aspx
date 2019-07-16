<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FG_Cost_Update.aspx.cs" Inherits="UI.PaymentModule.FG_Cost_Update" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Product Cost Sheet                            </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder2" runat="server"><%: Scripts.Render("~/Content/Bundle/updatedJs") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/updatedCss" />
</head>
<body>
    <form id="frmSupplierCOA" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>

                <%--=========================================Start My Code From Here===============================================--%>
                <asp:HiddenField ID="hdnconfirm" runat="server" />
                <asp:HiddenField ID="hdnEnroll" runat="server" />
                <asp:HiddenField ID="hdnUnit" runat="server" />
                <asp:HiddenField ID="hdnLevel" runat="server" />
                <asp:HiddenField ID="hdnysnPay" runat="server" />
                <asp:HiddenField ID="hdnysnDutyVoucher" runat="server" />
                <asp:HiddenField ID="hdnEmail" runat="server" />

                <div class="container divbody" style="padding-right: 10px; width:950px;">
                    <div id="divLevel1" class="tabs_container" style="background-color: #dcdbdb; padding-top: 10px; padding-left: 5px; padding-right: -50px; border-radius: 5px;">
                        <asp:Label ID="lblHeading" runat="server" CssClass="lbl" Text="Product Cost Sheet" Font-Bold="true" Font-Size="16px"></asp:Label><hr />
                    </div>
                    <table class="tbldecoration" style="width: 920px; float: left;">

                        <tr class="row">
                            <td style="text-align: right;">
                                <asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Unit"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" Width="120px" Height="23px" AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Item Type"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlItemType" CssClass="ddList" Font-Bold="False" runat="server" Width="120px" Height="23px" AutoPostBack="true" OnSelectedIndexChanged="ddlItemType_SelectedIndexChanged">
                                    <%--<asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="1">Trading</asp:ListItem>
                                    <asp:ListItem Value="2">Manufacturing</asp:ListItem>--%>
                                </asp:DropDownList></td>

                            <td style="text-align: right;">
                                <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Cost Group"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlCostGroup" CssClass="ddList" Font-Bold="False" runat="server" Width="110px" Height="23px" AutoPostBack="true" OnSelectedIndexChanged="ddlCostGroup_SelectedIndexChanged"></asp:DropDownList></td>

                        </tr>
                        <tr class="row">
                            <td style="text-align: right;">
                                <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="GL"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlGL" CssClass="ddList" Font-Bold="False" runat="server" Width="180px" Height="23px" AutoPostBack="true"></asp:DropDownList></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Item"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlItem" CssClass="ddList" Font-Bold="False" runat="server" Width="300px" Height="23px"></asp:DropDownList></td>
                        </tr>
                        <tr class="row">
                            <td style="text-align: right;">
                                <asp:Label ID="Label6" runat="server" CssClass="lbl" Text="Effective Date:"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtEffectDate" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="110px" placeholder="click here" AutoComplete="off"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="txtEffectDate"></cc1:CalendarExtender>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label7" runat="server" CssClass="lbl" Text="Value"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtValue" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="110px" TextMode="Number"></asp:TextBox><%--<div style="padding-right:10px;"></div>--%>
                                
                            </td>
                        </tr>
                        <tr>
                            <td  colspan="9">
                                <div style="float:right">
                                    <asp:Button ID="btnAdd" runat="server" class="btn btn-primary" Text="Add" OnClick="btnAdd_Click" OnClientClick="return Validation();" />
                                <asp:Button ID="btnSubmit" runat="server" class="btn btn-success" Text="Submit" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnShow" runat="server" class="btn btn-primary" Text="Show" OnClick="btnShow_Click" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="9">
                                <table>
                                    <tr>
                                        <td style="text-align: center;">
                                            <asp:Label ID="lblUnitName" runat="server" Font-Bold="true" Font-Size="20px" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center;">
                                            <asp:Label ID="lblReportName" runat="server" Font-Bold="true" Font-Size="16px" Text="Product Cost Limit" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="dgvReport" runat="server" AllowPaging="false" DataKeyNames="ItemId" AutoGenerateColumns="False" FooterStyle-Font-Size="11px" ForeColor="Black" GridLines="Vertical" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="10px" OnRowDeleting="dgvReport_RowDeleting">
                                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SL No.">
                                                        <ItemStyle HorizontalAlign="center" Width="50px" />
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Item ID" SortExpression="ItemId">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblItemID" runat="server" Text='<%# Bind("ItemId") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Item Name" SortExpression="ItemName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblstrItem" runat="server" Text='<%# Bind("ItemName") %>' Width="250px"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="left" Width="250px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Item Name" SortExpression="ItemType" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblItemTypeId" runat="server" Text='<%# Bind("ItemTypeID") %>' Width="250px"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="left" Width="250px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cost Group" SortExpression="costGroup">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblstrCostGroup" runat="server" Text='<%# Bind("costGroup") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Acc Code" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAccCode" runat="server" Text='<%# Bind("code") %>' Width="80px"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="GL" SortExpression="GLName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblGL" runat="server" Text='<%# Bind("GLName") %>' Width="180px"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="left" Width="180px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Value" SortExpression="value">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblmonValue" runat="server" Text='<%# Bind("value", "{0:n2}") %>' Width="80px"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="right" Width="80px" />
                                                    </asp:TemplateField>
                                                    <asp:CommandField ControlStyle-Font-Bold="true" ControlStyle-ForeColor="Red" HeaderText="Action" ShowDeleteButton="True">
                                                        <ControlStyle Font-Bold="True" ForeColor="Red" />
                                                    </asp:CommandField>
                                                </Columns>
                                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr id="report" runat="server" visible="false">
                                        <td>
                                            <asp:GridView ID="dgvShowReport" runat="server" AutoGenerateColumns="False" ShowFooter="True" FooterStyle-Font-Size="11px" ForeColor="Black" GridLines="Vertical" HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="10px" OnRowDeleting="dgvReport_RowDeleting" OnRowDataBound="dgvShowReport_RowDataBound">
                                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SL No.">
                                                        <ItemStyle HorizontalAlign="center" Width="50px" />
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Item ID" SortExpression="intItemID">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblItemID" runat="server" Text='<%# Bind("intItemID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cost Element Group" SortExpression="intCostElementGroup">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblstrItem" runat="server" Text='<%# Bind("intCostElementGroup") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="COAID" SortExpression="intCoAID">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblstrCostGroup" runat="server" Text='<%# Bind("intCoAID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cost Group" SortExpression="strCostGroup">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblGL" runat="server" Text='<%# Bind("strCostGroup") %>' Width="150px"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="left" Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Acc Code" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAccCode" runat="server" Text='<%# Bind("strcode") %>' Width="80px"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Account Name" SortExpression="strAccName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblGL" runat="server" Text='<%# Bind("strAccName") %>' Width="150px"></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblTotalText" runat="server" ForeColor="Red" CssClass="align" Text="Total"></asp:Label>
                                                        </FooterTemplate>
                                                        <FooterStyle HorizontalAlign="right" Font-Bold="True" ForeColor="Red" />
                                                        <ItemStyle HorizontalAlign="left" Width="250px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Value" SortExpression="monCost" FooterText="Total">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblmonValue" runat="server" Text='<%# Bind("monCost", "{0:n2}") %>' Width="100px"></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblTotal" runat="server" ForeColor="Red" CssClass="align"></asp:Label>
                                                        </FooterTemplate>
                                                        <FooterStyle HorizontalAlign="right" Font-Bold="True" ForeColor="Red" />
                                                        <ItemStyle HorizontalAlign="right" Width="100px"/>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle Font-Size="12px"/>
                                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />

                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>

                    </table>
                </div>





                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>


    <script type="text/javascript">
        function Validation() {
            var effectdate = document.getElementById("txtEffectDate").value;
            var value = document.getElementById("txtValue").value;
            if (effectdate === null || effectdate === "") {
                ShowNotification('Date can not be blank', 'Product Cost', 'warning');
                return false;
            }
            else if (value === null || value === "") {
                ShowNotification('Value can not be blank', 'Product Cost', 'warning');
                return false;
            }
            return true;
        }
    </script>
</body>
</html>

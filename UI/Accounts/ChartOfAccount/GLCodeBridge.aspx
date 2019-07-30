<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GLCodeBridge.aspx.cs" Inherits="UI.Accounts.ChartOfAccount.GLCodeBridge" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GL Code Bridge</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/CommonStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/PropertyStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="frmGLCodeBridge" runat="server">
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
                <cc1:alwaysvisiblecontrolextender targetcontrolid="pnlUpperControl" id="AlwaysVisibleControlExtender1" runat="server">
                </cc1:alwaysvisiblecontrolextender>
                <asp:HiddenField ID="hfConfirm" runat="server" />

                <table class="table70">
                    <tr>
                        <td class="td-lbl2">
                            <asp:Label ID="Label1" runat="server" CssClass="lbl-txt" Text="Employee Search:"></asp:Label>
                        </td>
                        <td class="td-txt-ddl2">
                            <asp:TextBox ID="txtEmployeeSearch" runat="server" CssClass="txt-field"></asp:TextBox>
                        </td>
                        <td class="td-lbl2">
                            <asp:Label ID="Label2" CssClass="lbl-txt" runat="server" Text="Employee Name:"></asp:Label>
                        </td>
                        <td class="td-txt-ddl2">
                            <asp:Label ID="lblEmpName" runat="server" CssClass="txt-field"></asp:Label>
                        </td>
                        <td class="td-lbl2">
                            <asp:Label ID="Label3" CssClass="lbl-txt" runat="server" Text="E-Mail:"></asp:Label>
                        </td>
                        <td class="td-txt-ddl2">
                            <asp:Label ID="lblEmpEmail" runat="server" CssClass="txt-field"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-lbl2">
                            <asp:Label ID="Label4" runat="server" CssClass="lbl-txt" Text="Designation:"></asp:Label>
                        </td>
                        <td class="td-txt-ddl2">
                            <asp:Label ID="lblEmpDesignation" runat="server" CssClass="txt-field"></asp:Label>
                        </td>
                        <td class="td-lbl2">
                            <asp:Label ID="Label5" CssClass="lbl-txt" runat="server" Text="Department:"></asp:Label>
                        </td>
                        <td class="td-txt-ddl2">
                            <asp:Label ID="lblEmpDepartment" runat="server" CssClass="txt-field"></asp:Label>
                        </td>
                        <td class="td-lbl2">
                            <asp:Label ID="Label7" CssClass="lbl-txt" runat="server" Text="Unit:"></asp:Label>
                        </td>
                        <td class="td-txt-ddl2">
                            <asp:Label ID="lblEmpUnit" runat="server" CssClass="txt-field"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-lbl2">
                            <asp:Label ID="Label6" runat="server" CssClass="lbl-txt" Text="Job Station:"></asp:Label>
                        </td>
                        <td class="td-txt-ddl2">
                            <asp:Label ID="lblJobStation" runat="server" CssClass="txt-field"></asp:Label>
                        </td>
                        <td class="td-lbl2">
                            <asp:Label ID="Label9" CssClass="lbl-txt" runat="server" Text="Status:"></asp:Label>
                        </td>
                        <td class="td-txt-ddl2">
                            <asp:Label ID="lblEmpStatus" runat="server" CssClass="txt-field"></asp:Label>
                        </td>
                        <td class="td-lbl2"></td>
                        <td class="td-txt-ddl2"></td>
                    </tr>
                    <tr>
                        <td class="td-lbl2">
                            <asp:Label ID="Label8" runat="server" CssClass="lbl-txt" Text="Loan Credit:"></asp:Label>
                        </td>
                        <td class="td-txt-ddl2">
                            <asp:TextBox ID="txtLoanCredit" runat="server" CssClass="txt-field"></asp:TextBox>
                        </td>
                        <td class="td-lbl2">
                            <asp:Label ID="Label11" CssClass="lbl-txt" runat="server" Text="Loan Debit:"></asp:Label>
                        </td>
                        <td class="td-txt-ddl2">
                            <asp:TextBox ID="txtLoanDebit" runat="server" CssClass="txt-field"></asp:TextBox>
                        </td>
                        <td colspan="2">
                            <asp:Button runat="server" ID="btnSubmit" CssClass="btnn" Text="Submit" OnClientClick="Confirms();" OnClick="btnSubmit_Click" />
                        </td>
                    </tr>
                </table>
                <div style="margin-top: 5px"></div>
                <div style="height: 400px; overflow: scroll">
                    <asp:GridView ID="dgvGLCodeBridge" runat="server" AutoGenerateColumns="False" Font-Size="11px" BackColor="White"
                        BorderColor="#999999" BorderStyle="Solid"
                        BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>
                            <asp:TemplateField HeaderText="SL No.">
                                <ItemStyle HorizontalAlign="center" Width="15px" />
                                <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="GL Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblGLName" runat="server" Text='<%# Bind("strGLName") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="150px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="GL Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblGLCode" runat="server" Text='<%# Bind("strGLCode") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="GL Account Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblGLAccountName" runat="server" Text='<%# Bind("strGLAccountName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    </asp:GridView>
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
                document.getElementById("hfConfirm").value = "1";
            } else {
                confirm_value.value = "No";
                document.getElementById("hfConfirm").value = "0";
            }

        }
    </script>
</body>
</html>

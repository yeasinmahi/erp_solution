<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesOrderConditionForReport.aspx.cs" Inherits="UI.Wastage.SalesOrderConditionForReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>::. Sales Order Condition .:: </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../Content/JS/datepickr.min.js"></script>
    <script src="../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

</head>
<body>
    <form id="frmIssue" runat="server">
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
                <asp:HiddenField ID="hdnconfirm" runat="server" />
                <asp:HiddenField ID="hdnEnroll" runat="server" />
                <asp:HiddenField ID="hdncustomerid" runat="server" />
                <asp:HiddenField ID="hdnUnit" runat="server" />
                <asp:HiddenField ID="hdnLoanID" runat="server" />
                <div class="divbody" style="padding-right: 10px;">
                    <div class="tabs_container" style="background-color: #dcdbdb; padding-top: 10px; padding-left: 5px; padding-right: -50px; border-radius: 5px;">
                        ISSUE FORM<hr />
                    </div>
                    <table class="tbldecoration" style="width: auto; float: left;">
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="WH Name"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlWHName" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="23px" AutoPostBack="True" OnSelectedIndexChanged="ddlWHName_SelectedIndexChanged"></asp:DropDownList></td>
                            <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label13" runat="server" Text=""></asp:Label></td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblWH" runat="server" CssClass="lbl" Text="Sales Order NO"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlSO" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="23px" AutoPostBack="False"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblSOCondition" runat="server" CssClass="lbl" Text="Work Order Condition"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtSOCondition" runat="server" CssClass="txtBox1" TextMode="MultiLine" Rows="3" Width="220px" Height="60px"></asp:TextBox></td>
                            <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:Button ID="btnAdd" runat="server" class="myButtonGrey" Text="Add" Width="90px" OnClick="btnAdd_Click" />
                            </td>
                        </tr>

                        <tr>
                            <td colspan="5">
                                <hr />
                            </td>
                        </tr>

                        <tr>
                            <td colspan="5" style="text-align: right; padding: 0px 0px 0px 0px">&nbsp&nbsp
                                <asp:Button ID="btnSubmit" runat="server" class="myButtonNew" Text="Submit" OnClick="btnSubmit_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <table>
                    <tr>
                        <td>
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="dgvWOCond" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
                                CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true"
                                HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
                                FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" 
                                ForeColor="Black" GridLines="Vertical" OnRowDataBound="dgvWOCond_RowDataBound"
                                OnRowDeleting="dgvWOCond_RowDeleting">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SL No.">
                                        <ItemStyle HorizontalAlign="center" Width="60px" />
                                        <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Warehouse ID" SortExpression="WareHouseId">
                                        <ItemTemplate>
                                            <asp:Label ID="lblWHId" runat="server" Text='<%# Bind("WareHouseId") %>' Width="60px"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" Width="60px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Sales Order ID" SortExpression="SalesOrderId">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSalesOrder" runat="server" Text='<%# Bind("SalesOrderId") %>' Width="100px"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" Width="100px" />
                                    </asp:TemplateField>       
                                  
                                    <asp:TemplateField HeaderText="Work Order Condition" SortExpression="Condition">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCondition" runat="server" Text='<%# Bind("Condition") %>' Width="350px"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="350px" />
                                    </asp:TemplateField>

                                    <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" />

                                </Columns>
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; padding: 0px 0px 0px 0px"></td>
                    </tr>
                </table>
                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

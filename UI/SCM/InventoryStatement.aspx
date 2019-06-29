<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryStatement.aspx.cs" Inherits="UI.SCM.InventoryStatement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Loan Application </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/Gridstyle.css" rel="stylesheet" />

    <script language="javascript" type="text/javascript">
        function onlyNumbers(evt) {
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;

            if ((charCode > 57))
                return false;
            return true;
        }
        function ViewPopup(Id) {
            window.open('LoanScheduleDetailsN.aspx?ID=' + Id, 'sub', "height=500, width=650, scrollbars=yes, left=100, top=25, resizable=no, title=Preview");
        }
    </script>
    <!-- Global site tag (gtag.js) - Google Analytics -->
    <script async src="https://www.googletagmanager.com/gtag/js?id=UA-125570863-1"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());
        gtag('config', 'UA-125570863-1');
    </script>
</head>
<body>
    <form id="frmLoanApplication" runat="server">
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
                <asp:HiddenField ID="hdnUnit" runat="server" />
                <asp:HiddenField ID="hdnWHID" runat="server" />
                <asp:HiddenField ID="hdnGroupID" runat="server" />
                <asp:HiddenField ID="hdnCategoryID" runat="server" />
                <div class="divbody" style="padding-right: 10px;">
                    <table>
                        <tr>
                            <td>
                                <div class="tabs_container" style="background-color: #dcdbdb; padding-top: 10px; padding-left: 5px; padding-right: -50px; border-radius: 5px;">INVENTORY STATEMENT<hr />
                                </div>
                                <table class="tbldecoration" style="width: auto; float: left;">
                                    <tr>
                                        <td colspan="4" style="text-align: center;">
                                            <asp:Label ID="Label14" runat="server" Text="WH Name " CssClass="lbl"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span><%--</td>--%><%--<td style="text-align:left;">--%><asp:DropDownList ID="ddlWH" runat="server" CssClass="ddList" Font-Bold="false" Width="220px" Height="24px" BackColor="WhiteSmoke" AutoPostBack="true" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"></asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right;">
                                            <asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date :"></asp:Label></td>
                                        <td style="text-align: left;">
                                            <asp:TextBox ID="txtdteFrom" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox>
                                            <cc1:CalendarExtender ID="CalendarExtender9" runat="server" SelectedDate="<%# DateTime.Today %>" Format="yyyy-MM-dd" TargetControlID="txtdteFrom">
                                            </cc1:CalendarExtender>
                                        </td>

                                        <td style="text-align: right;">
                                            <asp:Label ID="lbldteTo" CssClass="lbl" runat="server" Text="To Date :"></asp:Label></td>
                                        <td style="text-align: left;">
                                            <asp:TextBox ID="txtdteTo" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox>
                                            <cc1:CalendarExtender ID="CalendarExtender6" runat="server" SelectedDate="<%# DateTime.Today %>" Format="yyyy-MM-dd" TargetControlID="txtdteTo">
                                            </cc1:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label1" runat="server" Text="From Time :" CssClass="lbl"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txtFTime" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox></td>
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label3" runat="server" Text="To Time :" CssClass="lbl"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txtTTime" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label5" runat="server" Text="Search By " CssClass="lbl"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
                                        <td>
                                            <asp:DropDownList ID="ddlSearchBy" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="24px" BackColor="WhiteSmoke" AutoPostBack="true" OnSelectedIndexChanged="ddlSearchBy_SelectedIndexChanged">
                                                <asp:ListItem Value="1" Text="Item"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Group"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Category"></asp:ListItem>
                                                <asp:ListItem Value="4" Text="Sub Category"></asp:ListItem>
                                                <asp:ListItem Value="5" Text="Minor Category"></asp:ListItem>
                                                <asp:ListItem Value="6" Text="Store Location"></asp:ListItem>
                                                <asp:ListItem Value="7" Text="Plant"></asp:ListItem>
                                                <asp:ListItem Value="8" Text="Purchase Type"></asp:ListItem>
                                                <asp:ListItem Value="9" Text="ABC Classification"></asp:ListItem>
                                                <asp:ListItem Value="10" Text="FSN Classification"></asp:ListItem>
                                                <asp:ListItem Value="11" Text="VDE Classification"></asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td style="text-align: right;">
                                            <asp:Label ID="lblGroup" runat="server" CssClass="lbl"></asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="ddlGroup" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="24px" BackColor="WhiteSmoke" AutoPostBack="true" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged"></asp:DropDownList><asp:TextBox ID="txtItem" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right;">
                                            <asp:Label ID="lblCategory" runat="server" CssClass="lbl"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="txtItemID" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox><asp:DropDownList ID="ddlCategory" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="24px" BackColor="WhiteSmoke" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList></td>
                                        <td style="text-align: right;">
                                            <asp:Label ID="lblSubCategory" runat="server" CssClass="lbl"></asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="ddlSubCategory" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="24px" BackColor="WhiteSmoke"></asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="text-align: right; padding: 0px 0px 0px 0px">
                                            <asp:Button ID="btnShow" runat="server" class="myButtonGrey" Text="Show" Width="100px" OnClick="btnShow_Click" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <hr />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="dgvInvnetory" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
                                                CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                                                HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
                                                ForeColor="Black" GridLines="Vertical">
                                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S/N">
                                                        <ItemStyle HorizontalAlign="center" />
                                                        <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Item ID" SortExpression="intItem">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblItemId" runat="server" Text='<%# Bind("intItem") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="center" Width="50px" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Item Name" ItemStyle-HorizontalAlign="right" SortExpression="strMaterialName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("strMaterialName") %>'></asp:Label></ItemTemplate>
                                                        <ItemStyle HorizontalAlign="left" Width="250px" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="UOM" ItemStyle-HorizontalAlign="right" SortExpression="strUoM">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUom" runat="server" Text='<%# Bind("strUoM") %>'></asp:Label></ItemTemplate>
                                                        <ItemStyle HorizontalAlign="center" Width="20px" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Opening Qty" ItemStyle-HorizontalAlign="right" SortExpression="monOpenQty">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblOpenQty" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("monOpenQty","{0:n2}") %>'></asp:Label></ItemTemplate>
                                                        <ItemStyle HorizontalAlign="right" Width="60px" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Opening Value" ItemStyle-HorizontalAlign="right" SortExpression="monOpenValue">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblOpenValue" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("monOpenValue","{0:n2}") %>'></asp:Label></ItemTemplate>
                                                        <ItemStyle HorizontalAlign="right" Width="60px" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="RecQty" ItemStyle-HorizontalAlign="right" SortExpression="monRcvQty">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRecQty" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("monRcvQty","{0:n2}") %>'></asp:Label></ItemTemplate>
                                                        <ItemStyle HorizontalAlign="right" Width="60px" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="RecValue" ItemStyle-HorizontalAlign="right" SortExpression="monRcvValue">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRecValue" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("monRcvValue","{0:n2}") %>'></asp:Label></ItemTemplate>
                                                        <ItemStyle HorizontalAlign="right" Width="60px" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Issue Qty" ItemStyle-HorizontalAlign="right" SortExpression="monIssueQty">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIssueQty" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("monIssueQty","{0:n2}") %>'></asp:Label></ItemTemplate>
                                                        <ItemStyle HorizontalAlign="right" Width="60px" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Issue Value" ItemStyle-HorizontalAlign="right" SortExpression="issueValue">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIssueValue" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("issueValue","{0:n2}") %>'></asp:Label></ItemTemplate>
                                                        <ItemStyle HorizontalAlign="right" Width="60px" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Closing Qty" ItemStyle-HorizontalAlign="right" SortExpression="ClosingvQty">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblClosingQty" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("ClosingvQty","{0:n2}") %>'></asp:Label></ItemTemplate>
                                                        <ItemStyle HorizontalAlign="right" Width="60px" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Closing Value" ItemStyle-HorizontalAlign="right" SortExpression="monCloseValue">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblClosingValue" Width="60px" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("monCloseValue","{0:n2}") %>'></asp:Label></ItemTemplate>
                                                        <ItemStyle HorizontalAlign="right" Width="60px" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Store Location" ItemStyle-HorizontalAlign="right" SortExpression="strLocation">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblLocation" runat="server" Text='<%# Bind("strLocation") %>'></asp:Label></ItemTemplate>
                                                        <ItemStyle HorizontalAlign="left" Width="220px" />
                                                    </asp:TemplateField>


                                                    <%--<asp:TemplateField HeaderText="Detalis">
            <ItemTemplate>   <asp:Button ID="btnDetalis" runat="server" Text="Detalis"    /> </ItemTemplate> 
            </asp:TemplateField>--%>
                                                </Columns>
                                                <FooterStyle Font-Size="11px" />
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
</body>
</html>

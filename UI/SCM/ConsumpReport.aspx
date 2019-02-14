<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsumpReport.aspx.cs" Inherits="UI.SCM.ConsumpReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

    <link href="../Content/CSS/GridView.css" rel="stylesheet" />
    <link href="../Content/CSS/CommonStyle.css" rel="stylesheet" />

    <script type="text/javascript">
        function Print() {
            document.getElementById("btnprint").style.display = "none";
            window.print();
        }
        function validation() {
            var fromDate = document.getElementById("txtDteFrom").value;
            var toDate = document.getElementById("txtdteTo").value;

            if (fromDate === "") {
                ShowNotification("From Date can not be blanck", "Consumption Report", "warning");
                return false;
            } else if (toDate === "") {
                ShowNotification("To Date can not be blanck", "Consumption Report", "warning");
                return false;
            }
            return true;
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

                    <table style="width: 650px">
                        <tr>
                            <td rowspan="3" style="width: 70px"><asp:Image ID="imgUnit" runat="server" ImageUrl="~/Content/images/img/ag.png"  Width="70px" /></td>
                            <td style="text-align: center; font-size: medium; font-weight: bold;">
                                <asp:Label ID="lblUnitName" runat="server" Text="Akij Group" Font-Underline="true"></asp:Label>
                            </td>
                            <td rowspan="3">
                                <a id="btnprint" href="#" class="nextclick" style="cursor: pointer" onclick="Print()">Print</a>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                <asp:Label ID="lblbill" Font-Size="Small" Font-Bold="true" forrecolor="blue" Text="CONSUMPTION STATEMENT" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                <asp:DropDownList ID="ddlWh" Font-Size="Small" CssClass="ddList" Font-Bold="true" runat="server" Font-Underline="true" OnSelectedIndexChanged="ddlWh_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <hr />
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date: "></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtDteFrom" runat="server" autocomplete="off" CssClass="txtBox"></asp:TextBox>
                                <span style="color: red">*</span>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" SelectedDate="<%# DateTime.Today %>" Format="yyyy-MM-dd" TargetControlID="txtDteFrom">
                                </cc1:CalendarExtender>
                            </td>

                            <td style="text-align: right;">
                                <asp:Label ID="lbldteTo" CssClass="lbl" runat="server" Text="To Date: "></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtdteTo" runat="server" autocomplete="off" CssClass="txtBox"></asp:TextBox>
                                <span style="color: red">*</span>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" SelectedDate="<%# DateTime.Today %>" Format="yyyy-MM-dd" TargetControlID="txtdteTo">
                                </cc1:CalendarExtender>
                            </td>

                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Department:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlDepartment" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server">
                                </asp:DropDownList>
                                <asp:Button ID="btnDept" runat="server" Text="Show" OnClick="btnDept_OnClick" OnClientClick="return validation()" />

                            </td>


                            <td style="text-align: right;">
                                <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Section:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlSection" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"></asp:DropDownList>
                                <asp:Button ID="btnSection" runat="server" Text="Show" OnClick="btnSection_OnClick" OnClientClick="return validation()" />
                            </td>

                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Cost Center:"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlCostCenter" CssClass="ddList" Font-Bold="False" runat="server"></asp:DropDownList>
                                <asp:Button ID="btnCostCenter" runat="server" Text="Show" OnClick="btnCostCenter_OnClick" OnClientClick="return validation()" />
                            </td>
                            
                            <td style="text-align: right;">
                                <asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Com Group:"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlComGroup" CssClass="ddList" Font-Bold="False" runat="server"></asp:DropDownList>
                                <asp:Button ID="btnComGroup" runat="server" Text="Show" OnClick="btnComGroup_OnClick" OnClientClick="return validation()" />
                            </td>
                        </tr>
                        <tr>

                            <td colspan="4" style="text-align: right;"></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" ShowFooter="true" ShowHeader="true" Width="700px" CssClass="GridViewStyle">
                                    <HeaderStyle CssClass="HeaderStyle" />
                                    <FooterStyle CssClass="FooterStyle" />
                                    <RowStyle CssClass="RowStyle" />
                                    <PagerStyle CssClass="PagerStyle" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL">
                                            <ItemStyle HorizontalAlign="center" Width="15px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Product Name" SortExpression="strItem">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItem" runat="server" Text='<%# Bind("strItem") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Uom" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="strUoM">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUom" runat="server" Text='<%# Bind("strUoM") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Sub Category" ItemStyle-HorizontalAlign="right" SortExpression="strSubCategory">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSubcegory" runat="server" Text='<%# Bind("strSubCategory") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Minor Category" ItemStyle-HorizontalAlign="right" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblMinorCategory" runat="server" Text='<%# Bind("strMinorCategory") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Master Comb Group" ItemStyle-HorizontalAlign="right" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblMasterComGroup" runat="server" Text='<%# Bind("MasterComGroup") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Master Category" ItemStyle-HorizontalAlign="right">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMasterCategory" runat="server" Text='<%# Bind("MasterCategory") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="ACC Name" ItemStyle-HorizontalAlign="right">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAccNama" runat="server" Text='<%# Bind("strAccName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Used Qty" ItemStyle-HorizontalAlign="right" SortExpression="usedQty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUsedQty" runat="server" Text='<%# Bind("usedQty","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Used Value" ItemStyle-HorizontalAlign="right" SortExpression="usedValue">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUsedValue" runat="server" Text='<%# Bind("usedValue","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
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

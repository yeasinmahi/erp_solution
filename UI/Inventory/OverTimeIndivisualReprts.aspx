<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OverTimeIndivisualReprts.aspx.cs" Inherits="UI.Inventory.OverTimeIndivisualReprts" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script src="../../../../Content/JS/datepickr.min.js"></script>
    <script type="text/javascript" src="../../Content/JS/scriptEmployeeUpdate.js"></script>

    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $('#txtMonth').datepicker({
                    changeMonth: true,
                    changeYear: true,
                    showButtonPanel: true,
                    dateFormat: 'yy-MM',
                    onClose: function (dateText, inst) {
                        $(this).datepicker('setDate', new Date(inst.selectedYear, inst.selectedMonth, 1));
                    }
                });
            });
        }
    </script>

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
                        Over Time Report Checking  :
                    </div>
                    <table border="0" style="width: Auto">
                        <tr class="tblrowodd">
                            <td style="text-align: right;">
                                <asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="Month :"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtMonth" runat="server" CssClass="txtBox" placeholder="Click  for date" Enabled="true"></asp:TextBox>
                                <span style="color: red">*</span></td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblfullname" CssClass="lbl" runat="server" Text="Enroll : "></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtFullName" runat="server" Wrap="true" placeholder="Type  Enroll" Font-Bold="true" CssClass="txtBox" AutoPostBack="false" OnTextChanged="txtFullName_TextChanged"></asp:TextBox><span style="color: red">*</span></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Employee name : "></asp:Label></td>
                            <td>
                                <asp:Label ID="lblEmployeeName" CssClass="lbl" runat="server" Font-Bold="False" Font-Size="Medium"></asp:Label></td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblDrdlReportType" CssClass="lbl" runat="server" Text="Report TYpe: "></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="drdlReportType" CssClass="drdl" runat="server" DataSourceID="odsreportty" DataTextField="strReportType" DataValueField="intID"></asp:DropDownList>
                                <asp:ObjectDataSource ID="odsreportty" runat="server" SelectMethod="getReportType" TypeName="SAD_BLL.Customer.Report.StatementC"></asp:ObjectDataSource>
                            </td>

                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Unit Name: "></asp:Label></td>
                            <td>
                                 <asp:Label ID="lblUnit" CssClass="lbl" runat="server" Font-Bold="False" Font-Size="Medium"></asp:Label></td>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Jobstation Name: "></asp:Label></td>
                            <td>
                               <asp:Label ID="lblJobStation" CssClass="lbl" runat="server" Font-Bold="False" Font-Size="Medium"></asp:Label>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnShowReport" runat="server" Text="Show" BackColor="#ff9999" OnClick="btnShowReport_Click" />
                            </td>
                        </tr>
                    </table>
                </div>

                <div class="leaveApplication_container">
                    <table>
                        <tr class="tblroweven">
                            <td>
                                <asp:GridView ID="grdvOverTimeReports" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowDataBound="grdvOverTimeReports_RowDataBound" ForeColor="Black" OnPageIndexChanging="grdvOverTimeReports_PageIndexChanging" GridLines="Vertical">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>


                                        <asp:BoundField DataField="dteDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Date" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="dteStartTime" HeaderText="Start Time" SortExpression="starttime" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="dteEndTime" HeaderText="End Time" SortExpression="endtime" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="monSalary" HeaderText="Gross Salary" SortExpression="monsalary" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="monBasic" HeaderText="Basic Salary">
                                        </asp:BoundField>


                                        <asp:BoundField DataField="monHour" HeaderText="Total hour" SortExpression="dechour" ItemStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>


                                        <asp:BoundField DataField="intOTCount" HeaderText="OT count" SortExpression="Otcount" ItemStyle-HorizontalAlign="Center">
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="monHourAmount" HeaderText="Rate Per Hour" SortExpression="monhramount" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="monDayTotalAmount" HeaderText="Day Total Amount" SortExpression="mondailyamnt" ItemStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>

                                    </Columns>
                                    <FooterStyle BackColor="#CCCC99" />
                                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                    <RowStyle BackColor="#F7F7DE" />
                                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                    <SortedAscendingHeaderStyle BackColor="#848384" />
                                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                    <SortedDescendingHeaderStyle BackColor="#575357" />
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

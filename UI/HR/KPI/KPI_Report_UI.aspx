<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KPI_Report_UI.aspx.cs" Inherits="UI.HR.KPI.KPI_Report_UI" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>


    <script type="text/javascript">
        function Search_dgvservice(strKey, strGV) {

            var strData = strKey.value.toLowerCase().split(" ");
            var tblData = document.getElementById(strGV);
            var rowData;
            for (var i = 1; i < tblData.rows.length; i++) {
                rowData = tblData.rows[i].innerHTML;
                var styleDisplay = 'none';
                for (var j = 0; j < strData.length; j++) {
                    if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                        styleDisplay = '';
                    else {
                        styleDisplay = 'none';
                        break;
                    }
                }
                tblData.rows[i].style.display = styleDisplay;
            }

        }
    </script>


















    <script>
        function Save() {
            document.getElementById("hdnField").value = "1";
            __doPostBack();
        }

    </script>



    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }

        .ddList {
        }

        .txtBox {
        }
    </style>
</head>
<body>
    <form id="frmaccountsrealize" runat="server">
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
                <asp:HiddenField ID="hdnEnroll" runat="server" />
                <asp:HiddenField ID="hdnsearch" runat="server" />
                <asp:HiddenField ID="hdnEnrollUnit" runat="server" />
                <asp:HiddenField ID="hdnUnitIDByddl" runat="server" />
                <asp:HiddenField ID="hdnBankID" runat="server" />
                <asp:HiddenField ID="hfEmployeeIdp" runat="server" />
                <asp:HiddenField ID="hdnwh" runat="server" />
                <asp:HiddenField ID="HdnServiceCost" runat="server" />
                <asp:HiddenField ID="hdnRepairsCost" runat="server" />
                <div class="leaveApplication_container">
                    <div class="tabs_container" align="Center">Employee Performance Assessment Through KPI</div>

                    <table class="tblrowodd">
                        <tr>

                            <td style="text-align: right;">
                                <asp:Label ID="Label3" runat="server" CssClass="lbl" Font-Size="small" Font-Bold="true" Text="Unit-:"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlunit" runat="server" AutoPostBack="True" CssClass="ddList" Font-Bold="true" OnSelectedIndexChanged="ddlunit_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label1" runat="server" CssClass="lbl" Font-Size="small" Font-Bold="true" Text="JobStation-:"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlJobstation" runat="server" AutoPostBack="True" CssClass="ddList" Font-Bold="true">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="LblDtePO" runat="server" CssClass="lbl" Font-Bold="true"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtDte" runat="server" Font-Bold="true" CssClass="txtBox"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtenderMonthly" runat="server" Format="yyyy-MMMM" TargetControlID="TxtDte">
                                </cc1:CalendarExtender>




                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label2" runat="server" CssClass="lbl" Font-Size="small" Font-Bold="true" Text="Type-:"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddltype" runat="server" AutoPostBack="True" CssClass="ddList" Font-Bold="true" OnSelectedIndexChanged="ddltype_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:RadioButton ID="RadioEmp" runat="server" GroupName="dti" Text="Employee" />
                            </td>
                            <td>
                                <asp:RadioButton ID="RadioSuper" runat="server" GroupName="dti" Text="Supervisor" /></td>

                            <td style="text-align: right;">
                                <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />




                            </td>
                        </tr>
                    </table>

                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="dgvGridView" runat="server" AutoGenerateColumns="False" OnRowDataBound="OnRowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL.N">
                                            <HeaderTemplate>
                                                <asp:TextBox ID="TxtServiceConfg" runat="server" Width="70" placeholder="Search" onkeyup="Search_dgvservice(this, 'dgvGridView')"></asp:TextBox>

                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="EmpID">
                                            <ItemTemplate>
                                                <asp:Label ID="intEmployeeID" runat="server" Text='<%# Eval("intEmployeeID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="strEmployeeName" HeaderText="EmpName" SortExpression="strEmployeeName" />
                                        <asp:BoundField DataField="strJobStationName" HeaderText="Jobstation" SortExpression="strJobStationName" />
                                        <asp:BoundField DataField="strDepatrment" HeaderText="Department" SortExpression="strDepatrment" />
                                        <asp:BoundField DataField="strDesignation" HeaderText="Designation" SortExpression="strDesignation" />
                                        <asp:BoundField DataField="strSupervisor" HeaderText="Superviser" SortExpression="strSupervisor" />
                                        <asp:BoundField DataField="kptypes" HeaderText="KPI Type" SortExpression="kptypes" />
                                        <asp:TemplateField HeaderText="Marks">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGradeNumber" runat="server" Width="100px" Text='<%# Bind("decGradeNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" Width="45px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grade" ItemStyle-HorizontalAlign="center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrade" runat="server" Text='<%# Bind("strGrade") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" Width="40px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>


                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="dgvSupervisor" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                                    BorderWidth="0px" CellPadding="1" ForeColor="Black" GridLines="Vertical">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>


                                        <asp:TemplateField HeaderText="SL.N">

                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="intSupID" HeaderText="SupervisorID" SortExpression="intSupID" />
                                        <asp:BoundField DataField="strSupervisor" HeaderText="Supervisor Name" SortExpression="strSupervisor" />

                                        <asp:BoundField DataField="strJobStationName" HeaderText="Jobstation" SortExpression="strJobStationName" />
                                        <asp:BoundField DataField="Assesment" HeaderText="Assessed" SortExpression="Assesment" />

                                        <asp:BoundField DataField="Remaining" HeaderText="Remaining" SortExpression="Remaining" />
                                        <asp:BoundField DataField="total" HeaderText="Total" SortExpression="total" />






                                    </Columns>
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                </asp:GridView>
                            </td>


                        </tr>
                    </table>
                </div>
                <div class="leaveSummary_container">
                    <div class="tabs_container">Grading Charts :<hr />
                    </div>
                    <asp:GridView ID="dgvlist" runat="server" AutoGenerateColumns="False" Font-Size="11px" BackColor="White" BorderStyle="Solid"
                        BorderWidth="0px" CellPadding="1" ForeColor="Black" GridLines="Vertical">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>
                            <asp:TemplateField HeaderText="SL">
                                <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="strGrade" HeaderText="Grade" ItemStyle-HorizontalAlign="Center" SortExpression="strGrade">
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </asp:BoundField>

                            <asp:BoundField DataField="marks" HeaderText="Marks" ItemStyle-HorizontalAlign="Center" SortExpression="marks">
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </asp:BoundField>



                        </Columns>
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    </asp:GridView>

                </div>



                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>



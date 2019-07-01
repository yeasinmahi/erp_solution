<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PLLeaveEntry.aspx.cs" Inherits="UI.HR.Leave.PLLeaveEntry" %>

<%@ Register Assembly="ScriptReferenceProfiler" Namespace="ScriptReferenceProfiler" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>::. PL Leave Entry </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
   <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/CommonStyle.css" rel="stylesheet" />
    <link href="../Content/CSS/GridView.css" rel="stylesheet" />
</head>
<body>
    <form id="frmPLLeaveEntry" runat="server">
        <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="up" runat="server">
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
                <div class="leaveApplication_container">
                    <div class="tabs_container">
                        <center>Leave schedule of P/L & Payment of LFA against P/L</center>
                        <hr />
                    </div>
                    <table border="0" style="width: Auto;">
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblJobStation" CssClass="lbl" runat="server" Text="Job Station : "></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtJobStation" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox>
                                <asp:HiddenField runat="server" ID="hfJobStationId" />
                            </td>
                            <td style="text-align: right;">
                                <asp:Button runat="server" ID="btnChangePLDate" CssClass="" Text="Change PL Date" OnClick="btnChangePLDate_Click" />
                                <asp:Button runat="server" ID="btnClose" CssClass="" Text="Close" OnClick="btnClose_Click" />
                            </td>

                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:GridView ID="dgvPLLeave" runat="server" AutoGenerateColumns="False" SkinID="sknGrid2" Font-Size="10px" BackColor="White"
                                    OnRowDataBound="dgvPLLeave_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SI.No.">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="15px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Emp. Enroll" SortExpression="intEmployeeID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmployeeEnroll" runat="server" Text='<%# Bind("intEmployeeID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" Width="40px" />
                                        </asp:TemplateField>

                                        <%--<asp:BoundField DataField="intEmployeeID" HeaderText="Emp. Enroll" ItemStyle-HorizontalAlign="Center" SortExpression="intEmployeeID">
                                            <ItemStyle HorizontalAlign="Left" Width="67px" />
                                        </asp:BoundField>--%>

                                        <asp:TemplateField HeaderText="Emp. Code" SortExpression="strEmployeeCode">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmployeeCode" runat="server" Text='<%# Bind("strEmployeeCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" Width="40px" />
                                        </asp:TemplateField>

                                        <%-- <asp:BoundField DataField="strEmployeeCode" HeaderText="Emp. Code" ItemStyle-HorizontalAlign="Center" SortExpression="strEmployeeCode">
                                            <ItemStyle HorizontalAlign="Left" Width="40px" />
                                        </asp:BoundField>--%>
                                        <asp:BoundField DataField="strEmployeeName" HeaderText="Emp. Name" SortExpression="strEmployeeName">
                                            <ItemStyle Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="strUnit" HeaderText="Unit" ItemStyle-HorizontalAlign="Center" SortExpression="strUnit">
                                            <ItemStyle Width="40px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Joining Date" SortExpression="dteJoiningDate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblJoiningDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"dteJoiningDate","{0:dd/MM/yyyy}")%>' DataFormatString="{0:yyyy-MM-dd}"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" Width="67px" />
                                        </asp:TemplateField>
                                        <%--<asp:BoundField DataField="dteJoiningDate" HeaderText="Joining Date" ItemStyle-HorizontalAlign="Center" SortExpression="dteJoiningDate" DataFormatString="{0:yyyy-MM-dd}">
                                            <ItemStyle Width="67px" />
                                        </asp:BoundField>--%>
                                        <asp:BoundField DataField="strJobStationName" HeaderText="Job Station" ItemStyle-HorizontalAlign="Center" SortExpression="strJobStationName">
                                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="strDesignation" HeaderText="Designation" ItemStyle-HorizontalAlign="Center" SortExpression="strDesignation">
                                            <ItemStyle HorizontalAlign="Left" Width="120px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="strDepatrment" HeaderText="Department" ItemStyle-HorizontalAlign="Center" SortExpression="strDepatrment">
                                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                                        </asp:BoundField>
                                        <asp:TemplateField ShowHeader="true" HeaderText="Leave Taken Date">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtLeaveDate" Text='<%#DataBinder.Eval(Container.DataItem,"dteLeaveTakenDate","{0:dd/MM/yyyy}")%>' DataFormatString="{0:yyyy-MM-dd}"></asp:TextBox>
                                                <cc1:CalendarExtender runat="server" TargetControlID="txtLeaveDate" Format="dd/MM/yyyy" />
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <%-- <asp:BoundField DataField="dteLeaveTakenDate" HeaderText="Leave Taken Date" ItemStyle-HorizontalAlign="Center" SortExpression="dteLeaveTakenDate" DataFormatString="{0:yyyy-MM-dd}">
                                            <ItemStyle Width="67px" />
                                        </asp:BoundField>--%>

                                        <asp:TemplateField ShowHeader="true" HeaderText="Received Date">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblTakenDate" Text='<%#DataBinder.Eval(Container.DataItem,"dteTakenDate","{0:dd/MM/yyyy}")%>' DataFormatString="{0:yyyy-MM-dd}"></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="status" HeaderText="Status" ItemStyle-HorizontalAlign="Center" SortExpression="status">
                                            <ItemStyle Width="67px" />
                                        </asp:BoundField>
                                        <%-- <asp:BoundField DataField="dteTakenDate" HeaderText="Received Date" ItemStyle-HorizontalAlign="Center" SortExpression="dteTakenDate" DataFormatString="{0:yyyy-MM-dd}">
                                            <ItemStyle Width="67px" />
                                        </asp:BoundField>--%>
                                        <asp:TemplateField ShowHeader="true" HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:Button ID="btnSubmitPL" runat="server" OnClick="btnSubmitPL_Click" Text="Submit PL" CssClass="btn btn-success btn-xs"></asp:Button>
                                                <asp:Button ID="btnChangePLDate" runat="server" OnClick="btnChangePLDate_Click1" Text="Change PL Date" CssClass="btn btn-success btn-xs"></asp:Button>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>


            </ContentTemplate>
        </asp:UpdatePanel>

    </form>

    <script>
        function Viewdetails(PLLeaveEmpId) {
            //alert(PLLeaveEmpId);
            window.open('PLLeaveUpdate.aspx?PLLeaveEmpID=' + PLLeaveEmpId, 'sub',
                "scrollbars=yes,toolbar=0,height=500,width=950,top=100,left=200, resizable=yes, directories=no,location=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no, addressbar=no");
        }
    </script>
</body>
</html>

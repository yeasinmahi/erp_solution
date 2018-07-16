<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="UI.HR.Reports.EmployeeAttendanceDateWise" Codebehind="EmployeeAttendanceDateWise.aspx.cs" %>

<%@ Register Assembly="ScriptReferenceProfiler" Namespace="ScriptReferenceProfiler" TagPrefix="cc1" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html >
<head runat="server">
    <title>Employee Attendance DateWise</title>

    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

     <asp:PlaceHolder ID="PlaceHolder1" runat="server">     
          <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
    </asp:PlaceHolder>  

    <script type="text/javascript">

        $(document).ready(function () {

            SearchText();
        });
        function SearchText() {
            $("#txtEmpNameCode").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;",
                        url: "EmployeeAttendanceDateWise.aspx/GetAutoCompleteData",
                        data: "{'strSearchKey':'" + document.getElementById('txtEmpNameCode').value + "'}",
                        dataType: "json",
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (result) {
                            alert("Error");
                        }
                    });
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                        scrolldelay="-1" width="100%">
                    	<span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                	</marquee>
                </div>
                <div id="divControl" class="divPopUp2" style="width: 100%; height: Auto; float: right;">
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 150px; text-align: right;">
                                <asp:Label ID="lblUnit" runat="server" Text="Unit Name"></asp:Label>
                            </td>
                            <td style="width: 10px; text-align: center;">
                                :
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlUnit" runat="server" Width="250px" AutoPostBack="True" DataSourceID="odsUnit"
                                    DataTextField="Text" DataValueField="Value">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetAllUnitIdAndName"
                                    TypeName="HR_BLL.Global.Unit"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 150px; text-align: right;">
                                <asp:Label ID="lblJobStation" runat="server" Text="JobStation"></asp:Label>
                            </td>
                            <td style="width: 10px; text-align: center;">
                                :
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlJobStation" runat="server" Width="250px" DataSourceID="odsJobstationByUnit"
                                    DataTextField="Text" DataValueField="Value">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsJobstationByUnit" runat="server" SelectMethod="GetJobStationIdAndNameByUnitID"
                                    TypeName="HR_BLL.Global.JobStation" OldValuesParameterFormatString="original_{0}">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlUnit" Name="intUnitID" PropertyName="SelectedValue"
                                            Type="Int32" />
                                        <asp:SessionParameter Name="intLoginId" SessionField="sesUserId" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblPrntEmp" runat="server" Text="Employee Name"></asp:Label>
                            </td>
                            <td style="width: 10px; text-align: center;">
                                :
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmpNameCode" runat="server"  AutoPostBack="true" CssClass="name"
                                    Width="245px"></asp:TextBox>
                               <%-- <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtEmpNameCode"
                                    ServiceMethod="GetEmployeeList" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </ajaxToolkit:AutoCompleteExtender>--%>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 150px; text-align: right;">
                                <asp:Label ID="lblFrmDate" runat="server" Text="From-Date"></asp:Label>
                            </td>
                            <td style="width: 10px; text-align: center;">
                                :
                            </td>
                            <td>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="cal_Theme1"
                                    EnableViewState="true" Format="yyyy/MM/dd" PopupButtonID="img133" TargetControlID="txtFrmDate">
                                </ajaxToolkit:CalendarExtender>
                                <asp:TextBox ID="txtFrmDate" runat="server" CssClass="dte" BackColor="White"></asp:TextBox>
                                <img id="img133" src="../../App_Themes/Default/images/calbtn.gif" style="border: 0px;
                                    width: 25px; height: 25px; vertical-align: top;" />
                                &nbsp; To-Date :
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="cal_Theme1"
                                    EnableViewState="true" Format="yyyy/MM/dd" PopupButtonID="img1" TargetControlID="txtToDate">
                                </ajaxToolkit:CalendarExtender>
                                <asp:TextBox ID="txtToDate" runat="server" CssClass="dte" BackColor="White"></asp:TextBox>
                                <img id="img1" src="../../App_Themes/Default/images/calbtn.gif" style="border: 0px;
                                    width: 25px; height: 25px; vertical-align: top;" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rdoType" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True">Summary</asp:ListItem>
                                    <asp:ListItem>Attendance Details</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td style="text-align: justify;">
                                <asp:Button ID="btnShowReport" runat="server" CssClass="button" Text="Show Report"
                                    OnClick="btnShowReport_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <div style="height: 170px;">
            </div>
            <ajaxToolkit:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </ajaxToolkit:AlwaysVisibleControlExtender>
            <%--=========================================Start My Code From Here======================================================--%>
            <div id="div1" runat="server">
                <rsweb:ReportViewer ID="DateWiseAttendanceReportViewer" runat="server" Font-Names="Verdana"
                    Font-Size="8pt" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"
                    WaitMessageFont-Size="14pt" Width="1050px" Height="766px">
                </rsweb:ReportViewer>
            </div>
            <%--=========================================End My Code From Here========================================================--%>
        </ContentTemplate>
    </asp:UpdatePanel>
        <cc1:ScriptReferenceProfiler ID="ScriptReferenceProfiler1" runat="server" />
    </form>
</body>
</html>

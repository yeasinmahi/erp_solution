<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalenderView.aspx.cs" Inherits="UI.HR.Attendance.CalenderView" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.: Calender View Attendance :.</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder0" runat="server">     
          <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
    </asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference0" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script>
        $(document).ready(function () {
            SearchText();
        });
        function Changed() {
            document.getElementById('hdfSearchBoxTextChange').value = 'true';
        }
        function SearchText() {
            $("#txtEmployeeSearch").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;",
                        url: "CalenderView.aspx/GetAutoCompleteData",
                        data: "{'strSearchKey':'" + document.getElementById('txtEmployeeSearch').value + "'}",
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
        function Print() { Show(); window.print(); self.close(); }
        function Show() {
            var dv = document.getElementById("print");
            dv.style.display = "block";
            dv = document.getElementById("btn");
            dv.style.display = "none";
        }
    </script>
</head>
<body>
    <form id="frmcalenderview" runat="server">
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
    <div class="divs_content_container"><b>Attendance Calendar View: </b><asp:HiddenField ID="hdnconfirm" runat="server" /> 
    <asp:HiddenField ID="hdnempid" runat="server" /><hr />
    <table border="0" style="width:Auto";>
        <tr><td style="text-align:right;"><asp:Label ID="lblemployeesearch" CssClass="lbl" runat="server" Text="Search-Employee : "></asp:Label></td>
        <td>
        <asp:TextBox ID="txtEmployeeSearch" runat="server" CssClass="txtBox" AutoPostBack="true" onchange="javascript: Changed();"></asp:TextBox>
        <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" />
        </td>
        </tr>

        <tr>
        <td colspan="2"><br /><hr /><div  id="print">        
        <asp:Panel ID="pnlpersonalinformation" runat="server"><%# strinformation %></asp:Panel>  
        <asp:Calendar ID="Calendar1" runat="server" ShowTitle="False" ShowNextPrevMonth="False" DayNameFormat="Full" FirstDayOfWeek="Sunday">
        <TodayDayStyle Font-Bold="True" ForeColor="White" BackColor="#990000"></TodayDayStyle>
        <DayStyle BorderWidth="2px" ForeColor="#000" BorderStyle="Solid" BorderColor="White" BackColor="#EAEAEA"></DayStyle>
        <DayHeaderStyle ForeColor="#000"></DayHeaderStyle><SelectedDayStyle Font-Bold="True" ForeColor="#333333"
        BackColor="#FAAD50"></SelectedDayStyle>
        <WeekendDayStyle ForeColor="Black" BackColor="#BBBBBB"></WeekendDayStyle>
        <OtherMonthDayStyle ForeColor="#666666" BackColor="White"></OtherMonthDayStyle>
        </asp:Calendar>
        </div><br />
        <div id="btn" style="text-align:center;"><a class="nextclick" style="cursor:pointer; font-size:10px;" href="#" onclick="Print()">Print</a></div>
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

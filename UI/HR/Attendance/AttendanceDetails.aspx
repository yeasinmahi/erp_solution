<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttendanceDetails.aspx.cs" Inherits="UI.HR.Attendance.AttendanceDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.: Employee Attendance Details :.</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" /> 
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" /> 
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
                        url: "AttendanceDetails.aspx/GetAutoCompleteData",
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
        function Confirm() {
            document.getElementById("hdnconfirm").value = "0";
            var txtEmployeeSearch = document.forms["frmattendancedetails"]["txtEmployeeSearch"].value;
            if (txtEmployeeSearch == null || txtEmployeeSearch == "") {
                alert("Please select a valid employee.");
                document.getElementById("txtEmployeeSearch").focus();
            }
            else {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
            }
        }
        function ViewPunchDetails(enroll, AttendanceDate, vwtype)
        {
            window.open('AttendanceDetailsView.aspx?ENROLL=' + enroll + '&ATTDATE=' + AttendanceDate + '&VTP=' + vwtype, '', "height=375, width=350, scrollbars=yes, left=250, top=200, resizable=no, title=Preview");
        }
         function loadIframe(iframeName, url) {
            var $iframe = $('#' + iframeName);
            if ($iframe.length) {
                $iframe.attr('src', url); 
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="frmattendancedetails" runat="server">
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
     <div id="divLevel1" class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> <asp:Label ID="lblHeading" runat="server" CssClass="lbl" Text="Employee Attendance Details" Font-Bold="true" Font-Size="16px"></asp:Label><hr /></div>
    <asp:HiddenField ID="hdnconfirm" runat="server" /> 
    <asp:HiddenField ID="hdnempid" runat="server" /><hr />
                
    
    <%--<table border="0" style="width:Auto;";>
        <tr><td style="text-align:right;"><asp:Label ID="lblemployeesearch" CssClass="lbl" runat="server" Text="Search-Employee : "></asp:Label></td>
        <td>
        <asp:TextBox ID="txtEmployeeSearch" runat="server" CssClass="txtBox" AutoPostBack="true" onchange="javascript: Changed();"></asp:TextBox>
        <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" />
        </td>
        <td style="text-align:right;"><asp:Label ID="lbljoindate" CssClass="lbl" runat="server" Text="Select-Month : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True" CssClass="dropdownList" DataSourceID="odsmonthlist" DataValueField="intMonthId" DataTextField="strMonthName"></asp:DropDownList>
        <asp:ObjectDataSource ID="odsmonthlist" runat="server" SelectMethod="GetMonthList" TypeName="HR_BLL.Attendance.EmployeeAttendance"></asp:ObjectDataSource>
        </td>
        </tr>

        <tr>                     
        <td style="text-align:right" colspan="4">              
        <asp:Button ID="btnSubmit" runat="server" class="nextclick" style="font-size:11px;" Text="Show Details" OnClick="btnSubmit_Click"  OnClientClick = "Confirm()"/> 
        <asp:Button ID="btnMonthly" runat="server" class="nextclick" style="font-size:11px;" Text="Monthly Punch" OnClick="btnMonthly_Click"  OnClientClick = "Confirm()"/> 
        </td>                    
       </tr>
    </table>
    </div>
    <asp:GridView ID="dgvattendancedetails" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White">
    <Columns>
    <asp:BoundField DataField="AttendanceDate" HeaderText="AttendanceDate" ItemStyle-HorizontalAlign="Center" SortExpression="AttendanceDate">
    <ItemStyle HorizontalAlign="Left" Width="75px"/></asp:BoundField>                
    <asp:BoundField DataField="ysnPresent" HeaderText="Present" ItemStyle-HorizontalAlign="Center" SortExpression="ysnPresent">
    <ItemStyle HorizontalAlign="Left" Width="50px"/></asp:BoundField>
    <asp:BoundField DataField="ysnAbsent" HeaderText="Absent" ItemStyle-HorizontalAlign="Center" SortExpression="ysnAbsent">
    <ItemStyle HorizontalAlign="Left" Width="50px"/></asp:BoundField>
    <asp:BoundField DataField="ysnLeave" HeaderText="Leave" ItemStyle-HorizontalAlign="Center" SortExpression="ysnLeave">
    <ItemStyle HorizontalAlign="Left" Width="50px"/></asp:BoundField>
    <asp:BoundField DataField="ysnMovement" HeaderText="Movement" ItemStyle-HorizontalAlign="Center" SortExpression="ysnMovement">
    <ItemStyle HorizontalAlign="Left" Width="50px" /></asp:BoundField>
    <asp:BoundField DataField="ysnHoliday" HeaderText="Holiday" ItemStyle-HorizontalAlign="Center" SortExpression="ysnHoliday">
    <ItemStyle HorizontalAlign="Left" Width="50px" /></asp:BoundField>
    <asp:BoundField DataField="ysnOffday" HeaderText="Offday" ItemStyle-HorizontalAlign="Center" SortExpression="ysnOffday">
    <ItemStyle HorizontalAlign="Left" Width="50px" /></asp:BoundField>
    <asp:BoundField DataField="ysnLate" HeaderText="Late" ItemStyle-HorizontalAlign="Center" SortExpression="ysnLate">
    <ItemStyle HorizontalAlign="Left" Width="50px" /></asp:BoundField>
    <asp:TemplateField HeaderText="DetailsPunch"><ItemTemplate>
    <input id="btnViewPunch" type="button" class="nextclick" style="cursor:pointer; font-size:10px;" value="ViewPunch" onclick="<%# ViewPunchDetails(Eval("intEmployeeId"), Eval("AttendanceDate"), "daily") %>" />
    </ItemTemplate></asp:TemplateField>
    </Columns>
    </asp:GridView>--%>

   <div>
                   
        <table class="tbldecoration" style="width:auto; float:left;">
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblemployeesearch" CssClass="lbl" runat="server" Text="Search-Employee : "></asp:Label></td>
            <td>
            <asp:TextBox ID="txtEmployeeSearch" runat="server" CssClass="txtBox1" AutoPostBack="true" onchange="javascript: Changed();" Width="250px"></asp:TextBox>
            <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" />
            </td>
            <td style="text-align:right;"><asp:Label ID="lbldate" CssClass="lbl" runat="server" Text="From Date : "></asp:Label></td>
             <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox1" Enabled="true" autocomplete="off"></asp:TextBox>
                <cc1:CalendarExtender ID="fd" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender>                                                        
             </td>
             <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date : "></asp:Label></td>
             <td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox1" Enabled="true" autocomplete="off"></asp:TextBox>
                  <cc1:CalendarExtender ID="td" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender>                                                        
            </td>
            <td> 
                <asp:Button ID="btnSubmit" runat="server" class="myButton" Style="font-size: 12px; cursor: pointer;" Text="Show" OnClick="btnSubmit_Click" OnClientClick="Confirm()"/>
            </td>
        </tr>
        <tr>                     
        <td style="text-align:right" colspan="6">              
       <%-- <asp:Button ID="btnSubmit" runat="server" class="myButton" Style="font-size: 11px; cursor: pointer;"  Text="Show" OnClick="btnSubmit_Click"  OnClientClick = "Confirm()"/>--%> 
        <%--<asp:Button ID="btnMonthly" runat="server" class="nextclick" style="font-size:11px;" Text="Monthly Punch" OnClick="btnMonthly_Click"  OnClientClick = "Confirm()"/>--%> 
        </td>                    
       </tr>
    </table>
       </div>
        <iframe runat="server" oncontextmenu="return false;" id="frame" name="frame" style="width:100%; height:500px; border:0px solid red;"></iframe>
    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OvertimeEntry.aspx.cs" Inherits="UI.Inventory.OvertimeEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    
    <link href="../Content/CSS/morris.css" rel="stylesheet" />
    <script src="../Content/JS/raphael.min.js"></script>
    <script src="../Content/JS/morris.min.js"></script>

    <script>
        if (!$.browser.msie || $.browser.version > 7) {
            this.attr("novalidate", "novalidate");
        }
        function GetTimeSpan() {
            var defaultDate = "1/1/1970 ";
            var end = document.getElementById('txtend').value;
            var start = document.getElementById('txtstrt').value;
            console.log("start " + start);
            console.log("End " + end);
            var difference = new Date(new Date(defaultDate + end) - new Date(defaultDate + start)).toUTCString().split(" ")[4];
            console.log("Diff " + difference);
            document.getElementById("txtMovDuration").innerText = difference;
            $('#txtMovDuration').val(difference);
        }
    </script>
    
</head>
<body>
    <form id="frmpdv" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" EnablePartialRendering="true" runat="server"></asp:ScriptManager>
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
                        Overtime entry (Driver & Office Assistants) :
                        <asp:HiddenField ID="hdUnitId" runat="server" />
                        <asp:HiddenField ID="hdnApplicantEnrol" runat="server" />
                        <asp:HiddenField ID="hdnstation" runat="server" />
                        <asp:HiddenField ID="hdnsearch" runat="server" />
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <asp:HiddenField ID="HiddenField3" runat="server" />
                        <asp:HiddenField ID="ApproverEnrol" runat="server" />
                        <asp:HiddenField ID="hdnAreamanagerEnrol" runat="server" />
                        <asp:HiddenField ID="hdnAction" runat="server" />
                        <asp:HiddenField ID="HiddenUnit" runat="server" />
                        <asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" />
                        <asp:HiddenField ID="hdnmiute" runat="server" />
                        <hr />
                    </div>
                    <table border="0" style="width: Auto">
                        <tr class="tblroweven">
                            <td style="text-align: right;">
                                <asp:Label ID="lbl1" CssClass="lbl" runat="server" Text="Unit Name"></asp:Label>
                            </td>
                            <%--<td>
                                <asp:Label ID="lblUnitName" CssClass="lbl" runat="server" Text="Unit Name"></asp:Label>
                            </td>--%>
                            <td>
                                <asp:DropDownList ID="ddlUnit" CssClass="ddList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                            
                            <td style="text-align: right">
                                <asp:Label ID="lblJobStation" CssClass="lbl" runat="server" Text="Job Station Name"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlJobStation" CssClass="ddList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlJobStation_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr class="tblrowodd">
                            <td style="text-align: right;">
                                <asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Start-Time : "></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtstrt" runat="server" CssClass="txtBox" onchange="GetTimeSpan()"></asp:TextBox><script>$('#txtstrt').timepicker();</script></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label3" CssClass="lbl" runat="server" Text="End-Time : "></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtend" runat="server" CssClass="txtBox" onchange="GetTimeSpan()"></asp:TextBox><script>$('#txtend').timepicker();</script></td>
                        </tr>
                        <tr class="tblroweven">
                            <td style="text-align: right">
                                <asp:Label ID="lblTotalMovementDuraion" CssClass="lbl" runat="server" Text="Movement.D (Hour) "></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtMovDuration" AutoPostBack="false" runat="server" Enabled="false" CssClass="txtBox"></asp:TextBox></td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="Date:  "></asp:Label><span style="color: red">*</span></td>
                            <td>
                                <asp:TextBox ID="txtFromDate" placeholder="Click for date selection" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true"></asp:TextBox>
                                <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender>
                            </td>
                        </tr>
                        <tr class="tblrowodd">
                            <td style="text-align: right;">
                                <asp:Label ID="lblfullname" CssClass="lbl" runat="server" Text="Employee Name: "></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtFullName" runat="server" placeholder="Type  Name" AutoCompleteType="Search" Font-Bold="true" CssClass="txtBox" AutoPostBack="true"></asp:TextBox>
                                <span style="color: red">*</span> </td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblEnrol" CssClass="lbl" runat="server" Text="Code: "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="textEnrol" runat="server" Font-Bold="true" AutoPostBack="false" BackColor="#ffffcc" CssClass="txtBox" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="tblroweven">
                            <td style="text-align: right;">
                                <asp:Label ID="lblEnrolNumber" CssClass="lbl" runat="server" Text="Enrol: "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAplicnEnrol" runat="server" Font-Bold="true" BackColor="#ffffcc" CssClass="txtBox" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblDesignation" CssClass="lbl" runat="server" Text="Designation: "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDesignation" runat="server" Font-Bold="true" AutoPostBack="false" BackColor="#ffffcc" CssClass="txtBox" Enabled="false"></asp:TextBox>
                            </td>

                        </tr>
                        <tr class="tblrowodd">
                            <td>
                                <asp:Label ID="lblPurpouse" CssClass="lbl" runat="server" Text="Purpouse: "></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="drdlPurpouse" CssClass="ddList" runat="server" AutoPostBack="True" DataSourceID="odsOvertimepurpouse" DataTextField="strPurpouse" DataValueField="intID"></asp:DropDownList>
                                <asp:ObjectDataSource ID="odsOvertimepurpouse" runat="server" SelectMethod="getOvertimePurpouse" TypeName="HR_BLL.TourPlan.TourPlanning"></asp:ObjectDataSource>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblRemarks" CssClass="lbl" runat="server" Text="Remarks: "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRemarks" runat="server" Font-Bold="true" CssClass="txtBox" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <%--<td style="text-align:right;"><asp:Label ID="lblDepartment" CssClass="lbl" runat="server" Text="Department: "></asp:Label> </td>--%>
                            <%--<td><asp:TextBox ID="txtDepartment" runat="server" Font-Bold="true" AutoPostBack="false" BackColor="#ffffcc"  CssClass="txtBox" Enabled="false"></asp:TextBox> </td>
            <td style="text-align:right;"><asp:Label ID="lblUnitid" CssClass="lbl" runat="server" Text="Unitid: "></asp:Label> </td>
            <td ><asp:TextBox ID="txtUnitid" runat="server" Font-Bold="true" BackColor="#ffffcc"   CssClass="txtBox" ReadOnly="true"></asp:TextBox> </td><asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="HiddenField2" runat="server" />
            </tr>--%>
                        </tr>
                        <tr class="tblroweven">

                            <td>
                                <asp:Button ID="btnAddBikeCarUser" runat="server" OnClick="btnAddBikeCarUser_Click" Text="Add" BackColor="#ffffcc" /></td>
                            <td>
                                <asp:Button ID="btnSubmitBikeCar" runat="server" BackColor="#ffcccc" Font-Bold="true" Text="Submit" OnClick="btnSubmitBikeCar_Click" />
                            </td>

                            <%--<td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Jobstationid: "></asp:Label> </td>
            <td ><asp:TextBox ID="txtJobstationid" runat="server" Font-Bold="true" BackColor="#ffffcc"   CssClass="txtBox" ReadOnly="true"></asp:TextBox> </td>--%>
                        </tr>
                    </table>
                </div>

                <div class="leaveApplication_container">
                    <table>
                        <tr class="tblrowodd">
                            <td>
                                <asp:GridView ID="grdvOvertimeEntry" runat="server" AutoGenerateColumns="false" RowStyle-Wrap="true" HeaderStyle-Wrap="true" OnSelectedIndexChanged="grdvOvertimeEntry_SelectedIndexChanged" OnRowDeleting="grdvOvertimeEntry_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL.">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %><asp:HiddenField ID="hdnSL" runat="server" Value='<%# Bind("BillDate") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="BillDate" HeaderText="Bill Date" SortExpression="dteBillDate" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="txtstrtwihtHMS" HeaderText="StartTime" SortExpression="tmstartwihtHMS" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="tmendwithHMS" HeaderText="EndtTime" SortExpression="tmendwithHMS" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="tmdifferencewithHMS" HeaderText="Diffrence" SortExpression="tmdifferencewithHMS" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />

                                        <asp:BoundField DataField="starttime" HeaderText="Start" SortExpression="starttime" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="endtime" HeaderText="End" SortExpression="endtime" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="MovDuration" HeaderText="Hour" SortExpression="decDur" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="purpouse" HeaderText="Reason" SortExpression="purpouse" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="remarks" HeaderText="Remarks" SortExpression="remarks" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />

                                        <asp:BoundField DataField="purpouseid" HeaderText="Purpouseid" SortExpression="purpouseid" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <asp:BoundField DataField="applicantenrol" HeaderText="Enrol" SortExpression="applicantenrol" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                                        <%--<asp:BoundField DataField="unitid" HeaderText="Unitid" SortExpression="unitid" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                <asp:BoundField DataField="jobstationid" HeaderText="Jobstationid" SortExpression="jobstationid" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />--%>
                                        <asp:CommandField ControlStyle-BackColor="#ff9900" ShowDeleteButton="True" />
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
<script type="text/javascript">
    var prm = Sys.WebForms.PageRequestManager.getInstance(); 

    prm.add_endRequest(function() { 
        SearchText();
        $('#txtstrt').timepicker();
        $('#txtend').timepicker();
        console.log("dom Ready Page Request Manager");
    }); 
    function pageLoad(sender, args) {
        $(document).ready(function () {
            SearchText();
            $('#txtstrt').timepicker();
            $('#txtend').timepicker();
            console.log("dom Ready page preload");
        });
    }
    function Changed() {
        document.getElementById('hdfSearchBoxTextChange').value = 'true';
    }
    function SearchText() {
        $("#txtFullName").autocomplete({
            source: function (request, response) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json;",
                    url: "OvertimeEntry.aspx/GetAutoCompleteData",
                    data: "{'strSearchKey':'" + document.getElementById('txtFullName').value + "'}",
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
    
    
</body>
</html>

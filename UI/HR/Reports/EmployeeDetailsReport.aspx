<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeDetailsReport.aspx.cs" Inherits="UI.HR.Reports.EmployeeDetailsReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Employee Attendance</title>

    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
     <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    <style>
        .Division { background-color: #EFEFEF; position:absolute;z-index:1; border:1px black; text-align:center;
    width:auto; height: auto; margin-left:auto; margin-right:auto; overflow-y:scroll; }
    </style> 
   
    <script type="text/javascript">
       
        //function submit()
        //{
        //        alert('ok');
        //        var date = document.getElementById('txtDate');
        //        //debugger;
        //        if (date == null)
        //        {
        //            alert("Insert Date");
        //            return false;
        //        }
        //        return true;
        //}
            
        function checkAllRow(objRef)
        {          
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++)
            {
               
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i])
                {
                    if (objRef.checked) {
                       
                        row.style.backgroundColor = "#5CADFF";
                        inputList[i].checked = true;
                    }
                    else {                      
                        row.style.backgroundColor = "white"; 
                        inputList[i].checked = false;
                    }
                }
            }
        }

        function CheckRow(objRef) {
          
            var row = objRef.parentNode.parentNode;
            if (objRef.checked)
            {
               
                row.style.backgroundColor = "#5CADFF";
            }
            else
            { 
                    row.style.backgroundColor = "white";               
            } 
            
            var GridView = row.parentNode;           
            var inputList = GridView.getElementsByTagName("input"); 
            for (var i = 0; i < inputList.length; i++)
            {
               
                var headerCheckBox = inputList[0];                
                var checked = true;
                if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox)
                {
                    if (!inputList[i].checked)
                    {
                        checked = false;
                        break;
                    }
                }
            }
            headerCheckBox.checked = checked; 
        } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" LoadScriptsBeforeUI="false"></asp:ScriptManager>
        <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
        <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
        <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
        <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">


             <%-- =============================================My code start Here===================== --%>
            <table>
                   <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Unit"></asp:Label>
                                </td>

                                <td colspan="2">

                                    <asp:DropDownList ID="ddlUnit" runat="server" DataSourceID="odsUnit" DataTextField="strUnit" DataValueField="intUnitID"></asp:DropDownList>

                                    <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetData" TypeName="HR_DAL.Global.UnitTDSTableAdapters.SprGetUnitTableAdapter">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="intUserID" SessionField="sesUserID" Type="Int32" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>

                                </td>
                                <td>&nbsp</td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Job Station"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlJobStation" runat="server" DataSourceID="odsJobstationByUnit" DataTextField="Text" DataValueField="Value" Width="200px">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsJobstationByUnit" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetJobStationIdAndNameByUnitID" TypeName="HR_BLL.Global.JobStation">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlUnit" Name="intUnitID" PropertyName="SelectedValue" Type="Int32" />
                                            <asp:SessionParameter Name="intLoginId" SessionField="sesUserID" Type="Int32" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                                <td>&nbsp</td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Department"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDepartment" runat="server" DataSourceID="odsDepartment" DataTextField="strDepatrment" DataValueField="intDepartmentID" OnDataBound="ddlDepartment_DataBound">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsDepartment" runat="server" SelectMethod="GetDepartmentDataByJobStation" TypeName="HR_DAL.Reports.EmployeeDetailsReportTableAdapters.GetDepartmentTableAdapter"></asp:ObjectDataSource>
                                </td>
                                <td>&nbsp</td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Designation"></asp:Label>
                                </td>

                                <td>
                                    <asp:DropDownList ID="ddlDesignation" runat="server" DataSourceID="odsDesignation" DataTextField="strDesignation" DataValueField="intDesignationID" OnDataBound="ddlDesignation_DataBound"></asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsDesignation" runat="server" SelectMethod="GetDesignationData" TypeName="HR_DAL.Reports.EmployeeDetailsReportTableAdapters.GetDesignationTableAdapter" OldValuesParameterFormatString="original_{0}">
                                        <SelectParameters><asp:ControlParameter ControlID="ddlJobStation" Name="intJobStation" PropertyName="SelectedValue" Type="Int32" /></SelectParameters>
                                    </asp:ObjectDataSource>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Select Date"></asp:Label>
                                </td>
                        
                                <td>
                                    <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                                    <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtDate" Format="dd/MM/yyyy" PopupButtonID="imgCal_1" ID="CalendarExtender1" runat="server" EnableViewState="true"></cc1:CalendarExtender>
                                    <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px; width: 34px; height: 23px; vertical-align: bottom;" />
                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnShowReport" runat="server" Text="Show Report" OnClick="btnShowReport_Click"/> <%--OnClientClick="javascript: return submit();"--%>
                                </td>
                                <td>
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit"  OnClick="btnSubmit_Click"/>
                                </td>

                            </tr>

                        </table>
        </div></asp:Panel>
        <div style="height: 100px;"></div><cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
        </cc1:AlwaysVisibleControlExtender>

        <div>

                        <table class="Division">
                            <tr>
                                <br/><asp:Label ID="lblAttendance" runat="server" Text="Attendance Report:"></asp:Label>
                                <asp:GridView ID="GVEmpAttendance" runat="server" AutoGenerateColumns="false" DataKeyNames="intEmployeeID">
                            
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL">
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="intEmployeeID" HeaderText="Employee ID" InsertVisible="False" ReadOnly="True" SortExpression="intEmployeeID" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                                        <asp:BoundField DataField="strEmployeeCode" HeaderText="Employee Code" SortExpression="strEmployeeCode" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                                        <asp:BoundField DataField="strEmployeeName" HeaderText="Employee Name" SortExpression="strEmployeeName" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                                        <asp:BoundField DataField="strDesignation" HeaderText="Designation" SortExpression="strDesignation" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                                        <asp:BoundField DataField="strDepatrment" HeaderText="Department" SortExpression="strDepatrment" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                                        <asp:BoundField DataField="JoiningDate" HeaderText="Joining Date" DataFormatString="{0:dd/MM/yyyy}" SortExpression="JoiningDate"><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                                        <asp:BoundField DataField="AttendanceInTime" HeaderText="Attendance InTime" SortExpression="AttendanceInTime" ReadOnly="True" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                                        <asp:BoundField DataField="AttendanceOutTime" HeaderText="Attendance OutTime" SortExpression="AttendanceOutTime" ReadOnly="True" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkHeader" runat="server" onclick="checkAllRow(this);"  />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkRow" runat="server" onclick="CheckRow(this);"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </tr>
                </table>

        </div>

        <%-- =========================================End My code here====================================================== --%>
        
            
<%--            </ContentTemplate>
        </asp:UpdatePanel>--%>
        










    </form>
</body>
</html>


<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="UI.HR.PaySlip.PayslipGenerator" Codebehind="PayslipGenerator.aspx.cs" %>

<%@ Register Assembly="ScriptReferenceProfiler" Namespace="ScriptReferenceProfiler" TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html >
<head runat="server">
    <title>Pay slip generator</title>
      <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script type="text/javascript">
        function GotoNextFocus(ControlName, e) {
            var unicode = e.keyCode ? e.keyCode : e.charCode
            if (unicode == 13) {
            var control = document.getElementById(ControlName);
            if (control != null) {
                control.focus();
                window.event.returnValue = false
               }
             }
         }

         function GeneratePayslipByEmployeeID(intEmployeeID, intUnitID, intEmployeeJobStationId, dtePayrollGenerationDate) {
             window.showModalDialog('ALLPaySlipByUnitAndJobSation.aspx?intEmployeeID=' + intEmployeeID + '&intUnitID=' + intUnitID + '&intEmployeeJobStationId=' + intEmployeeJobStationId + '&dtePayrollGenerationDate=' + dtePayrollGenerationDate, null, 'status:no;dialogWidth:564px;dialogHeight:800px;dialogHide:true;help:no;scroll:auto');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                        scrolldelay="-1" width="100%">
                    	<span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                	</marquee>
                </div>
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">
                    &nbsp;
                </div>
            </asp:Panel>
            <div style="height: 100px;">
            </div>
            <ajaxToolkit:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </ajaxToolkit:AlwaysVisibleControlExtender>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblUnit" runat="server" CssClass="label" Text="Select Unit"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlUnit" runat="server" CssClass="DropDown" 
                            Width="200px"
                            AutoPostBack="True" DataSourceID="odsUnitData" DataTextField="Text" 
                            DataValueField="Value">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:ObjectDataSource ID="odsUnitData" runat="server" 
                            SelectMethod="GetAllUnitIdAndName" TypeName="HR_BLL.Global.Unit">
                        </asp:ObjectDataSource>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblUnit0" runat="server" CssClass="label" Text="Job station"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddljobstation" runat="server" CssClass="DropDown" Width="200px"
                            DataSourceID="odsJobstationByUnit" DataTextField="Text" 
                            DataValueField="Value" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:ObjectDataSource ID="odsJobstationByUnit" runat="server" SelectMethod="GetJobStationIdAndNameByUnitID"
                            TypeName="HR_BLL.Global.JobStation" 
                            OldValuesParameterFormatString="original_{0}">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlUnit" Name="intUnitID" PropertyName="SelectedValue"
                                    Type="Int32" />
                                <asp:SessionParameter Name="intLoginId" SessionField="sesUserId" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblUnit1" runat="server" CssClass="label" Text="Payroll Date"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate" runat="server" AutoPostBack="false" Width="60px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CE1" runat="server" CssClass="cal_Theme1" Format="MM/dd/yyyy"
                            TargetControlID="txtDate">
                        </ajaxToolkit:CalendarExtender>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnLoad" runat="server" CssClass="button"  Width="150px"
                             Text="Load" onclick="btnLoad_Click" />
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <asp:Panel ID="panDataGrid" runat="server" ScrollBars="Auto">
                <div class="GridviewDiv" style="width: 750px">
                    <table style="width: 750px">
                        <tr>
                            <td style="width: 125px">
                            </td>
                            <td style="width: 125px">
                            </td>
                            <td style="width: 125px">
                            </td>
                            <td style="width: 125px">
                            </td>
                            <td style="width: 125px">
                            </td>
                            <td style="width: 125px; text-align: right">
                                <asp:Button ID="btnPrintAll" runat="server" Text="Print all Payslip" CssClass="button" Width="150px"
                                    OnClick="btnPrintAll_Click" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="dgvPayslip" runat="server" AutoGenerateColumns="False" DataKeyNames="intEmployeeID"
                        AllowSorting="True" Width="750px" SkinID="sknGrid2" 
                        DataSourceID="odsPayslipDataGrid" onrowdatabound="dgvPayslip_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Employee Name" SortExpression="strEmployeeName">
                                <HeaderTemplate>
                                    <asp:Label ID="Label8" runat="server" Text="Employee Name"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblEmployeeName" runat="server" Text='<%# Bind("strEmployeeName") %>'></asp:Label>
                                    <asp:HiddenField ID="hdnEmpID" runat="server" Value='<%# Bind("intEmployeeID") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="150px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Designation" SortExpression="strDesignation">
                                <HeaderTemplate>
                                    <asp:Label ID="Label11" runat="server" Text="Designation"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("strDesignation") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="150px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Job Station" SortExpression="strJobStationName">
                                <HeaderTemplate>
                                    <asp:Label ID="Label1111" runat="server" Text="Job Station"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1141" runat="server" Text='<%# Bind("strJobStationName") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Payable Salary" SortExpression="monTotalPayableSalary">
                                <HeaderTemplate>
                                    <asp:Label ID="Label1143" runat="server" Text="Payable Salary"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label451" runat="server" Text='<%# Bind("monTotalPayableSalary") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Print Payslip">
                                <HeaderTemplate>
                                    <asp:Label ID="Label1531" runat="server" Text="Print Payslip"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <input id="Button1" type="button" style="width: 100px;cursor:pointer" value="Print Payslip" onclick="<%# GetStr( Eval("intEmployeeID"),Eval("intUnitID"),Eval("intEmployeeJobStationId"),Eval("dtePayrollGenerationDate")) %>" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                                    <tr style="background-color: Green;">
                                        <th scope="col">
                                            Employee Name
                                        </th>
                                        <th scope="col">
                                            Designation
                                        </th>
                                        <th scope="col">
                                            Job Station
                                        </th>
                                        <th scope="col">
                                            Payable Salary
                                        </th>
                                        <th scope="col">
                                            Print Payslip
                                        </th>
                                    </tr>
                                </EmptyDataTemplate>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="odsPayslipDataGrid" runat="server" 
                        SelectMethod="GetDataForGeneratePaySlip" 
                        TypeName="HR_BLL.PaySlip.PayslipGenerator">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlUnit" Name="unitID" 
                                PropertyName="SelectedValue" Type="Int32" />
                            <asp:ControlParameter ControlID="ddljobstation" Name="jobSationID" 
                                PropertyName="SelectedValue" Type="Int32" />
                            <asp:ControlParameter ControlID="txtDate" Name="dtePayrollGenerationdate" 
                                PropertyName="Text" Type="DateTime" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
        <cc1:ScriptReferenceProfiler ID="ScriptReferenceProfiler1" runat="server" />
    </form>
</body>
</html>

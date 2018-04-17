<%@ Page Language="C#" Theme="Theme1" AutoEventWireup="true" CodeBehind="Absent.aspx.cs" Inherits="UI.HR.Reports.Absent" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Absent List</title>

    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

    <style type="text/css">
      
        .reasonHeight
        {
            
            height: 30px;
            font-weight:bold;
            vertical-align:central;
            
            
        }

        .presentDiv
        {
            display:none;
            width:450px;
            background-color:#f0f0ff;
	        border: 3px outset #00367B;
            position:absolute;
            z-index:1;
	        left:300px;
	        top: 150px
        }
    </style>

    <script type="text/javascript">
        function ShowReasonDiv(empId,empCode,empName) {
            
            
            document.getElementById("lblEmpCode").innerText = empCode;
            document.getElementById("lblEmpName").innerText = empName;
            document.getElementById("hdnEmpIDForPresent").value = empId;
            document.getElementById("lblAbDate").innerText = document.getElementById("txtDate").value;
            document.getElementById("reasonDiv").style.display = "block";

        }

        function HideReasonDiv() {


            document.getElementById("lblEmpCode").innerText = "";
            document.getElementById("lblEmpName").innerText = "";
            document.getElementById("hdnEmpIDForPresent").value = "";
            document.getElementById("lblAbDate").innerText = "";
            document.getElementById("reasonDiv").style.display = "none";

        }

        function ShowReasonDiv2() {
            alert('himadri')
        }




    </script>
</head>
<body>
    <form id="form1" runat="server">
   <asp:ScriptManager ID="ScriptManager1" runat="server">
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
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 110px; float: right;">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Unit " CssClass="label"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlUnit" runat="server" Width="250px" AutoPostBack="True" DataSourceID="odsUnit"
                                    DataTextField="Text" DataValueField="Value">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlUnit"
                                    ErrorMessage="*" ForeColor="#FF5050" ValidationGroup="VG"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetAllUnitIdAndName"
                                    TypeName="HR_BLL.Global.Unit"></asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Job Station " CssClass="label"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlJobStation" runat="server" Width="250px" DataSourceID="odsJobstationByUnit"
                                    DataTextField="Text" DataValueField="Value">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlJobStation"
                                    ErrorMessage="*" ForeColor="#FF5050" ValidationGroup="VG"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:ObjectDataSource ID="odsJobstationByUnit" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetJobStationIdAndNameByUnitID" TypeName="HR_BLL.Global.JobStation">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlUnit" Name="intUnitID" PropertyName="SelectedValue"
                                            Type="Int32" />
                                        <asp:ControlParameter ControlID="hdnLoginUserID" Name="intLoginId" PropertyName="Value"
                                            Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        

                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" CssClass="label" Text="Date"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CE1" runat="server" TargetControlID="txtDate"  Format="dd/MM/yyyy">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDate"
                                    ErrorMessage="*" ForeColor="#FF5050" ValidationGroup="VG"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnShowReport" runat="server" CssClass="button" Text="Show Report"
                                    OnClick="btnShowReport_Click" ValidationGroup="VG" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnLoginUserID" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <div style="height: 130px;">
            </div>
            <ajaxToolkit:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </ajaxToolkit:AlwaysVisibleControlExtender>

            <div id="GridAbsent">
                <asp:GridView ID="GridView1" SkinID="sknGrid1" runat="server" PageSize="25" AutoGenerateColumns="False" DataSourceID="odsAbsent" AllowPaging="True">
                    <Columns>
                        <asp:TemplateField HeaderText="Employee Code" SortExpression="strEmployeeCode">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("strEmployeeCode") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("strEmployeeCode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Employee Name" SortExpression="strEmployeeName">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("strEmployeeName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("strEmployeeName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Designation" SortExpression="strDesignation">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("strDesignation") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("strDesignation") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Depatrment" SortExpression="strDepatrment">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("strDepatrment") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("strDepatrment") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Punch" SortExpression="totalPunch">
                            <EditItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("totalPunch") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("totalPunch") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Problem" SortExpression="Problem">
                            <EditItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Problem") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("Problem") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <a href="#" onclick="<%#  GetJSFunctionString(""+Eval("intEmployeeId"),""+Eval("strEmployeeCode"),""+Eval("strEmployeeName"))  %>">Present</a>
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <asp:Label ID="Label8" runat="server" Font-Bold="True" ForeColor="#990000" Text="! Sorry No data against this qurey"></asp:Label>
                    </EmptyDataTemplate>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsAbsent" runat="server" SelectMethod="GetAbsentDataByJobStation" TypeName="HR_BLL.Reports.AbsentReport" OldValuesParameterFormatString="original_{0}">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlJobStation" Name="jobstationID" PropertyName="SelectedValue" Type="Int32" />
                        <asp:ControlParameter ControlID="txtDate" Name="date" PropertyName="Text" Type="string" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
            <div id="reasonDiv" class="presentDiv">

                            <table align="center" border="0" style="padding:0px">
                                <tr class="reasonHeight">
                                    <td  >
                                        Employee Code
                                    </td>
                                    <td >&nbsp&nbsp</td>
                                    <td >
                                        <asp:Label ID="lblEmpCode" runat="server" style="color: #990000" ></asp:Label>
                                    </td>
                                </tr>
                                <tr class="reasonHeight">
                                    <td  >
                                        Employee Name
                                    </td>
                                    <td >&nbsp&nbsp</td>
                                    <td >
                                        <asp:Label ID="lblEmpName" runat="server" style=" color: #990000" ></asp:Label>
                                    </td>
                                </tr>
                                <tr class="reasonHeight">
                                    <td >
                                        Absent Date
                                    </td>
                                    <td >&nbsp&nbsp</td>
                                    <td >
                                        <asp:Label ID="lblAbDate" runat="server" style=" color: #990000" ></asp:Label>
                                    </td>
                                </tr>
                                <tr class="reasonHeight">
                                    <td >
                                        Reason
                                    </td>
                                    <td>&nbsp&nbsp</td>
                                    <td>
                                        <asp:HiddenField ID="hdnEmpIDForPresent" runat="server" />
                                        <asp:DropDownList ID="ddlAbsentReason" runat="server">
                                            <asp:ListItem>Forget</asp:ListItem>
                                            <asp:ListItem>Skin Problem</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr class="reasonHeight" align="center">
                                     <td colspan="3">
                                        &nbsp
                                     </td>
                                     </tr>
                                 <tr class="reasonHeight"  align="center" >
                                     <td colspan="3">
                                         <div>
                                         <asp:Button ID="btnMakePresent" runat="server" Text="Give Present" OnClick="btnMakePresent_Click" />
                                         &nbsp&nbsp
                             
                                         <a href="#" style="text-decoration:none; vertical-align:top" onclick="HideReasonDiv()">cancel</a>
                                         </div>    
                                     </td>
                                     </tr>
                            </table>

                        </div>

        </ContentTemplate>
    </asp:UpdatePanel>

            


    </form>
</body>
</html>

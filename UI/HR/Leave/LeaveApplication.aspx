<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveApplication.aspx.cs" Inherits="UI.HR.Leave.LeaveApplication" %>

<%@ Register Assembly="ScriptReferenceProfiler" Namespace="ScriptReferenceProfiler" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>::. Apply Leave Application </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">     
          <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
    </asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script src="http://maps.googleapis.com/maps/api/js?key=AIzaSyAaczGkYJhz_uP1Xo03sWxYnBB7R1NXzZE&sensor=false&libraries=places&language=eng&types=establishment" type="text/javascript"></script>
    <script type="text/javascript" src="../../Content/JS/scriptLeaveApplication.js"></script>
    
</head>
<body>
    <form id="frmLeaveApplication" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
        <CompositeScript>
            <Scripts>
                <asp:ScriptReference name="MicrosoftAjax.js"/>
		        <asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
		        <asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		        <asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		        <asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		        <asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		        <asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		        <asp:ScriptReference name="Common.DateTime.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		        <asp:ScriptReference name="Animation.AnimationBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		        <asp:ScriptReference name="PopupExtender.PopupBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		        <asp:ScriptReference name="Common.Threading.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		        <asp:ScriptReference name="Calendar.CalendarBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
            </Scripts>
        </CompositeScript>
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
   
    <div class="leaveApplication_container"> 
        <div class="tabs_container"> Apply Leave Application :<hr /></div>
        <table border="0px"; style="width:Auto;"; align="center" >

            <tr>
            <td style="text-align:right;"><asp:Label ID="lblemployeename" CssClass="lbl" runat="server" Text="Employee-Name : "></asp:Label></td>
            <td ><asp:TextBox ID="txtEmployeeName" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
            <td style="text-align:right;"><asp:Label ID="lblunit" CssClass="lbl" runat="server" Text="Unit-Name : "></asp:Label></td>
            <td class="auto-style1"><asp:TextBox ID="txtUnit" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
            </tr>
            
            <tr>
            <td style="text-align:right;"><asp:Label ID="lbldept" CssClass="lbl" runat="server" Text="Department : "></asp:Label></td>
            <td><asp:TextBox ID="txtDept" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
            <td style="text-align:right;"><asp:Label ID="lbldesig" CssClass="lbl" runat="server" Text="Designation : "></asp:Label></td>
            <td class="auto-style1"><asp:TextBox ID="txtDesig" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
            </tr>

            <tr>
            <td style="text-align:right;"><asp:Label ID="lbljobstatus" CssClass="lbl" runat="server" Text="Job-Status : "></asp:Label></td>
            <td><asp:TextBox ID="txtJobStatus" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
            <td style="text-align:right;"><asp:Label ID="lblphone" CssClass="lbl" runat="server" Text="Contact-No : "></asp:Label></td>
            <td class="auto-style1"><asp:TextBox ID="txtContact" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
            </tr>

            <tr>
                <td style="text-align:right;"><asp:Label ID="lblstation" CssClass="lbl" runat="server" Text="Job-Station : "></asp:Label></td>
                <td><asp:TextBox ID="txtStation" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="lblleavetype" CssClass="lbl" runat="server" Text="Leave-Type : "></asp:Label></td>
                <td class="auto-style1"><asp:DropDownList ID="ddlLvType" runat="server" CssClass="dropdownList" DataSourceID="odsLeaveType" DataTextField="strLeaveType" DataValueField="intLeaveTypeID"></asp:DropDownList>
                <asp:ObjectDataSource ID="odsLeaveType" runat="server" SelectMethod="GetLeaveType" TypeName="HR_BLL.Leave.LeaveApplicationProcess">
                    <SelectParameters>
                        <asp:SessionParameter Name="strEmployeeCode" SessionField="sesUserCode" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                </td>
                               
            </tr>

            <tr>
            <td style="text-align:right;"><asp:Label ID="lbldteFrom" CssClass="lbl" runat="server" Text="From-Date : "></asp:Label></td>
            <td><asp:TextBox ID="txtDteFrom" runat="server" CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="CEJ" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDteFrom"></cc1:CalendarExtender>                                                        
            </td>
            <td style="text-align:right;"><asp:Label ID="lbldteto" CssClass="lbl" runat="server" Text="To-Date : "></asp:Label></td>
            <td class="auto-style1">
                <asp:TextBox ID="txtDteTo" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CEA" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDteTo"></cc1:CalendarExtender>
            </td>
            </tr>

            <tr>
            <td style="text-align:right;"><asp:Label ID="lblreason" CssClass="lbl" runat="server" Text="Reason : "></asp:Label></td>
            <td><asp:TextBox ID="txtReason" runat="server" CssClass="txtBox" TextMode="MultiLine"></asp:TextBox></td> 
            <td style="text-align:right;"><asp:Label ID="lbladdress" CssClass="lbl" runat="server" Text="Address : "></asp:Label></td>
            <td class="auto-style1"><asp:TextBox ID="txtAddress" runat="server" CssClass="txtBox" TextMode="MultiLine"></asp:TextBox></td> 
            </tr>

            <tr><td colspan="4"><hr /><asp:HiddenField ID="hdnAction" runat="server"/><asp:HiddenField ID="hdnAppId" runat="server"/>
            <a class="nextclick" onclick="DeleteApplication()">Delete</a>
            <a class="nextclick" onclick="UpdateApplication()">Edit</a>
            <a class="nextclick" onclick="Confirm()">Submit</a>
            </td></tr>

            <tr><td colspan="4">
            <asp:GridView ID="dgvApplicationSummary" runat="server" PageSize="15" AutoGenerateColumns="False" AllowPaging="True" SkinID="sknGrid2" Font-Size="10px" DataSourceID="odsApplicationSummary" BackColor="White">
              <Columns>
                <asp:BoundField DataField="intApplicationId" HeaderText="Serial" ItemStyle-HorizontalAlign="Center" SortExpression="intApplicationId">
                <ItemStyle HorizontalAlign="Left" Width="47px"/></asp:BoundField>
                <asp:BoundField DataField="strLeaveType" HeaderText="Leave-Type" ItemStyle-HorizontalAlign="Center" SortExpression="strLeaveType">
                <ItemStyle HorizontalAlign="Left" Width="120px"/></asp:BoundField>
                <asp:BoundField DataField="dateApplicationDate" HeaderText="Submit" ItemStyle-HorizontalAlign="Center" SortExpression="dateApplicationDate" DataFormatString="{0:yyyy-MM-dd}">
                <ItemStyle Width="67px"/></asp:BoundField>
                <asp:BoundField DataField="dateAppliedFromDate" HeaderText="From-Date" ItemStyle-HorizontalAlign="Center" SortExpression="dateAppliedFromDate" DataFormatString="{0:yyyy-MM-dd}">
                <ItemStyle Width="67px" /></asp:BoundField>
                <asp:BoundField DataField="dateAppliedToDate" HeaderText="To-Date" ItemStyle-HorizontalAlign="Center" SortExpression="dateAppliedToDate" DataFormatString="{0:yyyy-MM-dd}">
                <ItemStyle HorizontalAlign="Left" Width="67px" /></asp:BoundField>
                <asp:BoundField DataField="strLeaveReason" HeaderText="Reason" ItemStyle-HorizontalAlign="Center" SortExpression="strLeaveReason">
                <ItemStyle HorizontalAlign="Left" Width="155px" /></asp:BoundField>
                
                <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center" SortExpression="srtApprovedStatus">
                <ItemTemplate>
                   <asp:Button ID="btnAction" class="nextclick" OnCommand="btnAction_OnCommand" runat="server" CommandName="PROCESS" Font-Size="9px" 
                   CommandArgument='<%#GetJSFunctionString( Eval("srtApprovedStatus"),Eval("intLeaveTypeID"),Eval("intApplicationId"),Eval("dateAppliedFromDate"),Eval("dateAppliedToDate"),Eval("strLeaveReason"),Eval("strAddressDuetoLeave")) %>'
                   Text='<%# Bind("srtApprovedStatus") %>' />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField>
                                 
              </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="odsApplicationSummary" runat="server" SelectMethod="GetApplicationSummary" TypeName="HR_BLL.Leave.LeaveApplicationProcess">
            <SelectParameters><asp:Parameter Name="strEmployeeCode" Type="String" /><asp:SessionParameter Name="employeeid" SessionField="sesUserID" Type="Int32" />
            </SelectParameters></asp:ObjectDataSource>
            </td></tr>

       </table>

    </div> 
         
    <div class="leaveSummary_container"> 
        <div class="tabs_container">Leave Summary :<hr /></div>
        <asp:GridView ID="dgvLeaveSummary" runat="server" AutoGenerateColumns="False" SkinID="sknGrid2" Font-Size="10px" DataSourceID="odsLeaveSummary" BackColor="White">
          <Columns><asp:BoundField DataField="strLeaveType" HeaderText="Leave-Type" ItemStyle-HorizontalAlign="Center" SortExpression="strLeaveType">
            <ItemStyle HorizontalAlign="Left" Width="120px"/></asp:BoundField>
            <asp:BoundField DataField="intLeaveTakenDays" HeaderText="Taken" ItemStyle-HorizontalAlign="Center" SortExpression="intLeaveTakenDays">
            <ItemStyle Width="48px"/></asp:BoundField>
            <asp:BoundField DataField="intRemainingDays" HeaderText="Blance" ItemStyle-HorizontalAlign="Center" SortExpression="intRemainingDays">
            <ItemStyle Width="48px" /></asp:BoundField>
            <asp:BoundField DataField="strRemarks" HeaderText="Remarks" ItemStyle-HorizontalAlign="Center" SortExpression="strLeaveType">
            <ItemStyle HorizontalAlign="Left" Width="270px" /></asp:BoundField>
          </Columns></asp:GridView>
        <asp:ObjectDataSource ID="odsLeaveSummary" runat="server" SelectMethod="GetLeaveSummary" TypeName="HR_BLL.Leave.LeaveApplicationProcess">
            <SelectParameters>
                <asp:Parameter Name="employeecode" Type="String" />
                <asp:SessionParameter Name="employeeid" SessionField="sesUserID" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>  

    
   
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

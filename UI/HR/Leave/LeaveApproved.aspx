<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeaveApproved.aspx.cs" Inherits="UI.HR.Leave.LeaveApproved" %>

<%@ Register Assembly="ScriptReferenceProfiler" Namespace="ScriptReferenceProfiler" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>::. Leave Application Process</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">     
          <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
    </asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script type="text/javascript" src="../../Content/JS/scriptLeaveProcess.js"></script>

    
</head>
<body>
    <form id="frmLeaveApproveProcess" runat="server">
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
<%--===========================Start My Code From Here======== DataFormatString="{0:yyyy-MM-dd}"=====================--%>
   
    <div class="divs_content_container"> 
    <div class="tabs_container"> Employee Leave Application Process :<hr /></div>
        <table border="0px"; style="width:auto"; align="center" >

        <tr><td style="text-align:right;"><asp:Label ID="lblleavelist" CssClass="lbl" runat="server" Text="Select Application Type : ">
        </asp:Label></td>
        <td><asp:DropDownList ID="ddlist" runat="server" CssClass="dropdownList" AutoPostBack="True" OnSelectedIndexChanged="ddlist_SelectedIndexChanged">
            <asp:ListItem Text="New Application" Value="0"></asp:ListItem>
            <asp:ListItem Text="Approved Application" Value="1"></asp:ListItem>
            <asp:ListItem Text="Rejected Application" Value="2"></asp:ListItem></asp:DropDownList>
        </td>
        </tr>
         
        <tr><td colspan="2">
            
            <asp:GridView ID="dgvUPLeaveApplication" runat="server" AutoGenerateColumns="False" PageSize="25" AllowPaging="True" SkinID="sknGrid2" Font-Size="10px" DataSourceID="odsunapproved" BackColor="White">
              <Columns>
                <asp:BoundField DataField="strEmployeeName" HeaderText="Name" ItemStyle-HorizontalAlign="Center" SortExpression="strEmployeeName" Visible="true">
                <ItemStyle HorizontalAlign="Left" Width="325px" /></asp:BoundField>
                <asp:BoundField DataField="dateAppliedFromDate" HeaderText="From-Date" ItemStyle-HorizontalAlign="Center" SortExpression="dateAppliedFromDate" DataFormatString="{0:yyyy-MM-dd}">
                <ItemStyle Width="100px" /></asp:BoundField>
                <asp:BoundField DataField="dateAppliedToDate" HeaderText="To-Date" ItemStyle-HorizontalAlign="Center" SortExpression="dateAppliedToDate" DataFormatString="{0:yyyy-MM-dd}">
                <ItemStyle HorizontalAlign="Left" Width="100px" /></asp:BoundField>
                <asp:BoundField DataField="strLeaveType" HeaderText="Leave Type" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" SortExpression="strLeaveType">
                <ItemStyle HorizontalAlign="Left" Width="150px" /></asp:BoundField>
                <asp:BoundField DataField="TotalDays" HeaderText="Total Days" ReadOnly="True" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="35px" SortExpression="TotalDays">
                <ItemStyle HorizontalAlign="Left" Width="100px" /></asp:BoundField>                
                <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                <a class="nextclick" href="#" onclick="<%#  GetJSFunctionString(""+Eval("intApplicationId"),""+Eval("strEmployeeCode"),""+Eval("strEmployeeName"),""+
                Eval("dateAppliedFromDate"),""+Eval("dateAppliedToDate"),""+Eval("intLeaveTypeID"),""+Eval("strLeaveType"),""+Eval("TotalDays"),""+Eval("strJobType"),""+Eval("intRemainingDays"))  %>">
                Process</a></ItemTemplate>
               </asp:TemplateField>                                 
              </Columns>
            </asp:GridView>


            <asp:ObjectDataSource ID="odsunapproved" runat="server" SelectMethod="GetUnapprovedLeaveApplication" TypeName="HR_BLL.Leave.LeaveApplicationProcess">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlist" Name="appstatus" PropertyName="SelectedValue" Type="Int32" />
                    <asp:SessionParameter Name="userid" SessionField="sesUserID" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>


       </td></tr>

        </table>
    </div>

    <div id="approvedDiv">
       <table border="0px"; style="width:Auto"; align="center" >

        <tr>
        <td style="text-align:right;"><asp:Label ID="lblcode" CssClass="lbl" runat="server" Text="Card-No : "></asp:Label></td>
        <td><asp:TextBox ID="txtCode" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="lblemployeename" CssClass="lbl" runat="server" Text="Employee-Name : "></asp:Label></td>
        <td><asp:TextBox ID="txtEmployeeName" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
        </tr>

        <tr>
        <td style="text-align:right;"><asp:Label ID="lbljobstatus" CssClass="lbl" runat="server" Text="Job-Status : "></asp:Label></td>
        <td><asp:TextBox ID="txtJobStatus" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="lblleavetype" CssClass="lbl" runat="server" Text="Leave-Type : "></asp:Label></td>
        <td><asp:TextBox ID="txtLeaveType" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
       </tr>

        <tr>
        <td style="text-align:right;"><asp:Label ID="lbldteFrom" CssClass="lbl" runat="server" Text="From-Date : "></asp:Label></td>
        <td><asp:TextBox ID="txtDteFrom" runat="server" CssClass="txtBox"></asp:TextBox>
        <cc1:CalendarExtender ID="CEJ" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDteFrom"></cc1:CalendarExtender>                                                        
        </td>
        <td style="text-align:right;"><asp:Label ID="lbldteto" CssClass="lbl" runat="server" Text="To-Date : "></asp:Label></td>
        <td>
            <asp:TextBox ID="txtDteTo" runat="server" CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="CEA" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDteTo"></cc1:CalendarExtender>
        </td>
        </tr>
                
        <tr>
        <td style="text-align:right;"><asp:Label ID="remaining" CssClass="lbl" runat="server" Text="Remaining-Days : "></asp:Label></td>
        <td><asp:TextBox ID="txtRemainingDays" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="lblappsts" CssClass="lbl" runat="server" Text="Pay-Status : "></asp:Label></td>
        <td>
            <asp:RadioButton ID="rdoWithpay" runat="server" Text="With-Pay" GroupName="PaymentStatus"/>
            <asp:RadioButton ID="rdoLWP" runat="server" Text="WithOut-Pay" GroupName="PaymentStatus"/>
        </td>      
        </tr>

        <tr>
           <td colspan="4"><hr /><asp:HiddenField ID="hdnReject" runat="server"/>
           <asp:HiddenField ID="hdnAppID" runat="server"/><a class="nextclick" onclick="HideReasonDiv()">Cancel</a> 
           <a class="nextclick" onclick="Reject()">Reject</a><a class="nextclick" onclick="Confirm()">Approved</a> 
           <asp:HiddenField ID="hdnAction" runat="server"/> <asp:HiddenField ID="hdnApproved" runat="server"/>         
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

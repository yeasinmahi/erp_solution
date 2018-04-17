<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportHallBooking.aspx.cs" Inherits="UI.HR.TourPlan.ReportHallBooking" %>

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
    <script type="text/javascript">
        function Confirm() {
            document.getElementById("hdnconfirm").value = "0";
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
            else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
        }


    </script>

    
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
    <div class="tabs_container"> Conference Room Booking Application Report :<hr /></div>
        <table border="0px"; style="width:auto"; align="center" >

        <tr><td style="text-align:right;"><asp:Label ID="lblleavelist" CssClass="lbl" runat="server" Text="Select Application Type : ">
        </asp:Label></td>
        <td><asp:DropDownList ID="ddlist" runat="server" CssClass="dropdownList" AutoPostBack="True" OnSelectedIndexChanged="ddlist_SelectedIndexChanged">
            <asp:ListItem Text="New Application" Value="3"></asp:ListItem>
            <asp:ListItem Text="Approved Application" Value="4"></asp:ListItem>
            <asp:ListItem Text="Rejected Application" Value="5"></asp:ListItem></asp:DropDownList>
            <asp:HiddenField ID="hdnReject" runat="server"/>
           <asp:HiddenField ID="hdnconfirm" runat="server"/><asp:HiddenField ID="hdnAction" runat="server"/>
        </td>
        </tr>
         
        <tr><td colspan="2">
            
            <asp:GridView ID="dgvHallbookingUnapproveddata" runat="server" AutoGenerateColumns="False" PageSize="25" AllowPaging="True" SkinID="sknGrid2" Font-Size="10px" BackColor="White">
              <Columns>
                  <asp:BoundField DataField="intapplicationid" HeaderText="id" ItemStyle-HorizontalAlign="Center" SortExpression="intapplicationid" Visible="true">
                <ItemStyle HorizontalAlign="Left" Width="50px" /></asp:BoundField>
                <asp:BoundField DataField="strName" HeaderText="Name" ItemStyle-HorizontalAlign="Center" SortExpression="strName" Visible="true">
                <ItemStyle HorizontalAlign="Left" Width="600px" /></asp:BoundField>
                <asp:BoundField DataField="bookingdate" HeaderText="From-Date" ItemStyle-HorizontalAlign="Center" SortExpression="bookingdate" DataFormatString="{0:yyyy-MM-dd}">
                <ItemStyle Width="350px" /></asp:BoundField>
                <asp:BoundField DataField="startime" HeaderText="startime" ItemStyle-HorizontalAlign="Center" SortExpression="startime" DataFormatString="{0:t}">
                <ItemStyle Width="100px" /></asp:BoundField>
                  <asp:BoundField DataField="endtime" HeaderText="endtime" ItemStyle-HorizontalAlign="Center" SortExpression="endtime" DataFormatString="{0:t}">
                <ItemStyle Width="100px" /></asp:BoundField>
                  <asp:BoundField DataField="duration" HeaderText="Durtn." ItemStyle-HorizontalAlign="Center" SortExpression="duration" DataFormatString="{0:t}">
                <ItemStyle Width="100px" /></asp:BoundField>
                <asp:BoundField DataField="strdept" HeaderText="Dept." ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" SortExpression="strdept">
                <ItemStyle HorizontalAlign="Left" Width="150px" /></asp:BoundField>
                <asp:BoundField DataField="strunit" HeaderText="Unit" ReadOnly="True" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="35px" SortExpression="strunit">
                <ItemStyle HorizontalAlign="Left" Width="100px" /></asp:BoundField>  
                   <asp:BoundField DataField="SeatCapacity" HeaderText="Persons" ReadOnly="True" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="35px" SortExpression="SeatCapacity">
                <ItemStyle HorizontalAlign="Left" Width="100px" /></asp:BoundField> 
                      <asp:BoundField DataField="strEmployeeName" HeaderText="Apply By" ReadOnly="True" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="35px" SortExpression="strEmployeeName">
                <ItemStyle HorizontalAlign="Left" Width="700px" /></asp:BoundField>
                   <asp:TemplateField HeaderText="Approve">
                    <ItemTemplate>
                     <asp:Button ID="btnApprove" runat="server" Text="Approve" class="button" CommandName="complete" OnClientClick="Confirm()" OnClick="btnApprove_Click" CommandArgument='<%# Eval("intapplicationid")%>' /></ItemTemplate>
                   </asp:TemplateField>
                  <asp:TemplateField HeaderText="Reject">
                    <ItemTemplate>
                     <asp:Button ID="btnReject" runat="server" Text="Reject" class="button" CommandName="complete" OnClientClick="Confirm()" OnClick="btnReject_Click" CommandArgument='<%# Eval("intapplicationid")%>' /></ItemTemplate>
                   </asp:TemplateField>                          
              </Columns>
            </asp:GridView> </td>
      </tr>
 </table>
    </div>

    


<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

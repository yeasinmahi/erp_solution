<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisitorReport.aspx.cs" Inherits="UI.HR.Visitors.VisitorReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>    
    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .Textbox {}
        </style>
    </head>
    <body> 

    <form id="frmaccountsrealize" runat="server">
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
     <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnsearch" runat="server" />
    <asp:HiddenField ID="hdnEnrollUnit" runat="server" /><asp:HiddenField ID="hdnUnitIDByddl" runat="server" /><asp:HiddenField ID="hdnBankID" runat="server" />
    <div class="tabs_container" align="Center">Visitor Report</div>        
        
         <table>                             
            <tr><td style="text-align:right;"><asp:Label ID="Lblunit" runat="server" CssClass="lbl" Text="JobStation :"></asp:Label></td>
            <td style="text-align:left;" ><asp:DropDownList ID="DdlJobStation" CssClass="ddList"  Font-Bold="False" runat="server" AutoPostBack="True" > 
            </asp:DropDownList> </tr>                     
             
            <tr><td style="text-align:right;"><asp:Label ID="LbldteFrom"  runat="server" CssClass="lbl" Text="From Date:"></asp:Label></td>
            <td><asp:TextBox ID="TxtDteFrom" runat="server" CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="txtDte" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDteFrom"></cc1:CalendarExtender> </td>

            <td style="text-align:right;"><asp:Label ID="LblDteTo" runat="server" CssClass="lbl" Text="To Date:"></asp:Label></td>
            <td><asp:TextBox ID="TxtDteTo" runat="server" CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDteTo"></cc1:CalendarExtender> </td>
            <td><asp:Button ID="BtnReport" runat="server" Text="Report" OnClick="BtnReport_Click" /></td></tr>               
         
         </table>
         <table>
             <tr> <td><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                 <asp:TemplateField HeaderText="Sl.N"> <ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate> </asp:TemplateField>
                      
                    <asp:TemplateField HeaderText="Date">                                 
                     <ItemTemplate><asp:Label ID="Label1" runat="server" Text='<%# Bind("dteVisiting","{0:MMMM d, yyyy}")  %>'></asp:Label></ItemTemplate></asp:TemplateField>
                    <asp:BoundField DataField="tmIn" HeaderText="In Time" SortExpression="tmIn" />
                    <asp:BoundField DataField="tmOut" HeaderText="Out Time" SortExpression="tmOut" />
                    <asp:BoundField DataField="strEmployeeName" HeaderText="Employee Name" SortExpression="strEmployeeName" />
                    <asp:BoundField DataField="strDesignation" HeaderText="Degisnation" SortExpression="strDesignation" />
                    <asp:BoundField DataField="strDepatrment" HeaderText="Department" SortExpression="strDepatrment" />
                    <asp:BoundField DataField="strGName" HeaderText="Guest Name" SortExpression="strGName" />
                    <asp:BoundField DataField="strUnit" HeaderText="Unit" SortExpression="strUnit" />
                    <asp:BoundField DataField="strJobStationName" HeaderText="Jobstation" SortExpression="strJobStationName" />
                    </Columns>
                     </asp:GridView></td></tr>                
             
         </table>
           

         <%--=========================================End My Code From Here=================================================--%>
           </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

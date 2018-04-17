<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HRClearange.aspx.cs" Inherits="UI.HR.Settlement.HRClearange" %>
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
</head>
<body>
    <form id="frmhrClearance" runat="server">
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

<div id="divcontentholder">

    <table class="tbldecoration" style="width:auto; float:left;">
    <tr class="tblheader"><td colspan="4"> HR Clearance :</td></tr>
                 
            <tr><td colspan="4"> <asp:HiddenField ID="hdnID" runat="server" /> <%--<asp:HiddenField ID="hdnconfirm" runat="server" />--%>
            <asp:GridView ID="dgvReport" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" 
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                                
            <asp:BoundField DataField="strEmployeeCode" HeaderText="Employee Code" ItemStyle-HorizontalAlign="Center" SortExpression="strEmployeeCode">
            <ItemStyle HorizontalAlign="Center" Width="75px"/></asp:BoundField>

            <asp:BoundField DataField="intEmployeeID" HeaderText="Employee ID" ItemStyle-HorizontalAlign="Center" SortExpression="intEmployeeID">
            <ItemStyle HorizontalAlign="Center" Width="75px"/></asp:BoundField>

            <asp:BoundField DataField="strEmployeeName" HeaderText="Employee Name" ItemStyle-HorizontalAlign="Center" SortExpression="strEmployeeName">
            <ItemStyle HorizontalAlign="left" Width="300px"/></asp:BoundField>

            <asp:BoundField DataField="strDesignation" HeaderText="Designation" ItemStyle-HorizontalAlign="Center" SortExpression="strDesignation">
            <ItemStyle HorizontalAlign="left" Width="150px"/></asp:BoundField>

            <asp:BoundField DataField="strDepatrment" HeaderText="Depatrment" ItemStyle-HorizontalAlign="Center" SortExpression="strDepatrment">
            <ItemStyle HorizontalAlign="left" Width="150px"/></asp:BoundField>

            <asp:BoundField DataField="strUnit" HeaderText="Unit Name" ItemStyle-HorizontalAlign="Center" SortExpression="strUnit">
            <ItemStyle HorizontalAlign="left" Width="150px"/></asp:BoundField>

            <asp:BoundField DataField="strJobStationName" HeaderText="Job Station Name" ItemStyle-HorizontalAlign="Center" SortExpression="strJobStationName">
            <ItemStyle HorizontalAlign="left" Width="225px"/></asp:BoundField>

            <asp:BoundField DataField="dteJoiningDate" HeaderText="Joining Date" ItemStyle-HorizontalAlign="Center" SortExpression="dteJoiningDate" DataFormatString="{0:yyyy-MM-dd}">
            <ItemStyle HorizontalAlign="Center" Width="75px"/></asp:BoundField>

            <asp:BoundField DataField="dteLastOfficeDate" HeaderText="Last Office Date" ItemStyle-HorizontalAlign="Center" SortExpression="dteLastOfficeDate" DataFormatString="{0:yyyy-MM-dd}">
            <ItemStyle HorizontalAlign="Center" Width="75px"/></asp:BoundField>

            <asp:BoundField DataField="dteLastOfficeDateByUser" HeaderText="Last Office Date By User" ItemStyle-HorizontalAlign="Center" SortExpression="dteLastOfficeDateByUser" DataFormatString="{0:yyyy-MM-dd}">
            <ItemStyle HorizontalAlign="Center" Width="75px"/></asp:BoundField>

            <asp:BoundField DataField="dteLastOfficeDateByAuthority" HeaderText="Last Office Date By Authority" ItemStyle-HorizontalAlign="Center" SortExpression="dteLastOfficeDateByAuthority" DataFormatString="{0:yyyy-MM-dd}">
            <ItemStyle HorizontalAlign="Center" Width="75px"/></asp:BoundField>

            <asp:BoundField DataField="monSalary" Visible="false" HeaderText="Salary" ItemStyle-HorizontalAlign="Center" SortExpression="monSalary" DataFormatString="{0:0.00}">
            <ItemStyle HorizontalAlign="right" Width="100px"/></asp:BoundField>

            <asp:BoundField DataField="dteResignationDate" Visible="false" HeaderText="Resignation Date" ItemStyle-HorizontalAlign="Center" SortExpression="dteResignationDate" DataFormatString="{0:yyyy-MM-dd}">
            <ItemStyle HorizontalAlign="Center" Width="75px"/></asp:BoundField>

            <asp:BoundField DataField="strSeparateName" Visible="false" HeaderText="Separatation Type" ItemStyle-HorizontalAlign="Center" SortExpression="strSeparateName">
            <ItemStyle HorizontalAlign="left" Width="225px"/></asp:BoundField>

            <asp:BoundField DataField="strSeparateReason" Visible="false" HeaderText="Separate Reason" ItemStyle-HorizontalAlign="Center" SortExpression="strSeparateReason">
            <ItemStyle HorizontalAlign="left" Width="225px"/></asp:BoundField>
                
            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" SortExpression="">
            <ItemTemplate><asp:Button ID="btnAction" class="button" runat="server" Font-Size="9px" OnClick="Details_Click"
            CommandArgument='<%# Eval("intEmployeeID") %>' Text="View" /></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField>
                                              
            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>

    </table>
       
    </div>

   <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

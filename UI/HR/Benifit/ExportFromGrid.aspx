<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExportFromGrid.aspx.cs" Inherits="UI.HR.Benifit.ExportFromGrid" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html><head runat="server"><title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
</head>
<body>
    <form id="frmexpgrd" runat="server">
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="false" runat="server"></asp:ScriptManager>
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
    <div class="leaveApplication_container"><b>Export to excell: </b>
    <table style="width:Auto";>        
        <tr>
        <td style="text-align:right;"><asp:Label ID="lbldteFrom" CssClass="lbl" runat="server" Text="From-Date : "></asp:Label></td>
        <td><asp:TextBox ID="txtDteFrom" runat="server" CssClass="txtBox" autocomplete="off"></asp:TextBox>
        <cc1:CalendarExtender ID="CEJ" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDteFrom"></cc1:CalendarExtender>                                                        
        </td>
        <td style="text-align:right;"><asp:Label ID="lbldteto" CssClass="lbl" runat="server" Text="To-Date : "></asp:Label></td>
        <td><asp:TextBox ID="txtDteTo" runat="server" CssClass="txtBox" autocomplete="off"></asp:TextBox>
        <cc1:CalendarExtender ID="CEA" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDteTo"></cc1:CalendarExtender>
        </td>
        </tr>
        <tr><td colspan="4"><asp:Button ID="btnShow" runat="server" class="nextclick" style="font-size:11px;" Text="Show" OnClick="btnShow_Click"/>
        <asp:Button ID="btnExcell" runat="server" class="nextclick" style="font-size:11px;" Text="Export" OnClick="btnExcell_Click"/></td></tr>

        <tr><td colspan="4">
            <asp:GridView ID="dgvSummary" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White">
            <Columns><asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-HorizontalAlign="Center" SortExpression="Name"><ItemStyle HorizontalAlign="Left" Width="120px"/></asp:BoundField>
            <asp:BoundField DataField="Code" HeaderText="Code" ItemStyle-HorizontalAlign="Center" SortExpression="Code"><ItemStyle HorizontalAlign="Left" Width="100px"/></asp:BoundField>
            <asp:BoundField DataField="Designation" HeaderText="Designation" ItemStyle-HorizontalAlign="Center" SortExpression="Designation"><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:BoundField>
            <asp:BoundField DataField="Department" HeaderText="Department" ItemStyle-HorizontalAlign="Center" SortExpression="Department"><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:BoundField>
          </Columns></asp:GridView>
        </td></tr>
    </table>
    </div>
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

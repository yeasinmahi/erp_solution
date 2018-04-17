<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisitedList.aspx.cs" Inherits="UI.HR.Visitors.VisitedList" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

</head>
<body>
    <form id="frmvlistbk" runat="server">
   <asp:ScriptManager ID="ScriptManager0" runat="server"></asp:ScriptManager>
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

    <table border="0"; style="width:Auto"; ><tr><td colspan="4"><div class="tblheader"> Visited List :</div>
    <asp:GridView ID="dgvprb" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="Red" 
    BorderStyle="Solid" BorderWidth="0px" CellPadding="1" ForeColor="Black"><AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
    <asp:TemplateField HeaderText="Visiting" SortExpression="DOV" >
    <ItemTemplate><asp:Label ID="lblvdt" runat="server" Text='<%# Eval("DOV", "{0:yyyy-MM-dd}") %>' ></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="70px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="Code" SortExpression="Code">
    <ItemTemplate><asp:Label ID="lblcd" runat="server" Text='<%# Bind("Code") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="115px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="Guest Name" SortExpression="Visitors">
    <ItemTemplate><asp:Label ID="lblguest" runat="server" Text='<%# Bind("Visitors") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="200px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="Contact" SortExpression="Contact">
    <ItemTemplate><asp:Label ID="lblphn" runat="server" Text='<%# Bind("Contact") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="85px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="Host" SortExpression="Host">
    <ItemTemplate><asp:Label ID="lblhost" runat="server" Text='<%# Bind("Host") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="200px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="TimeIn" SortExpression="TimeIn">
    <ItemTemplate><asp:Label ID="lbltmin" runat="server" Text='<%# Bind("TimeIn") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="left" Width="70px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="TimeOut" SortExpression="TimeOuts">
    <ItemTemplate><asp:Label ID="lbltmout" runat="server" Text='<%# Bind("TimeOuts") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="left" Width="70px" /></asp:TemplateField>                 

    <asp:TemplateField HeaderText="Total" SortExpression="Messages">
    <ItemTemplate><asp:Label ID="lbltmttl" runat="server" Text='<%# Bind("Messages") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="left" Width="70px" /></asp:TemplateField>   

    </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
    </asp:GridView>
    </td></tr>
    </table>


<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

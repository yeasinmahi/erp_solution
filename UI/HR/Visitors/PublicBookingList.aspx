<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PublicBookingList.aspx.cs" Inherits="UI.HR.Visitors.PublicBookingList" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.: Allowance Insertion :.</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

</head>
<body>
    <form id="frmalllistbk" runat="server">
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

    <table border="0"; style="width:Auto"; >
    <tr class="tblheader"><td>Booking List :</td><td style="text-align:right;"><asp:Button ID="btnRefresh" 
    runat="server" class="nextclick" style="font-size:11px;" Text="Refresh" OnClick="btnRefresh_Click" /></tr>

    <tr><td colspan="2">
    <asp:GridView ID="dgvprb" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="Red" 
    BorderStyle="Solid" BorderWidth="0px" CellPadding="1" ForeColor="Black" OnRowDataBound="dgvprb_RowDataBound"><AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
    <asp:TemplateField HeaderText="Visiting" SortExpression="DOV" >
    <ItemTemplate><asp:Label ID="lblvdt" runat="server" Text='<%# Eval("DOV", "{0:yyyy-MM-dd}") %>' ></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="70px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="Code" SortExpression="Code">
    <ItemTemplate><asp:Label ID="lblcd" runat="server" Text='<%# Bind("Code") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="110px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="Guest Name" SortExpression="Visitors">
    <ItemTemplate><asp:Label ID="lblguest" runat="server" Text='<%# Bind("Visitors") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="200px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="Contact">
    <ItemTemplate><asp:TextBox ID="txtphn" runat="server" CssClass="txtBox" Text='<%# Bind("Contact") %>' DataFormatString="{0:0.00}" Width="80px"></asp:TextBox></ItemTemplate>
    <ItemStyle HorizontalAlign="right" Width="80px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="Host" SortExpression="Host">
    <ItemTemplate><asp:Label ID="lblhost" runat="server" Text='<%# Bind("Host") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="200px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="TimeIn" SortExpression="Contact">
    <ItemTemplate><asp:Label ID="tpkIn" runat="server" Text='<%# Bind("TimeIn") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="75px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="TimeOut" SortExpression="Contact">
    <ItemTemplate><asp:Label ID="tpkOut" runat="server" Text='<%# Bind("TimeOuts") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="75px" /></asp:TemplateField>

    <%--<asp:TemplateField HeaderText="TimeIn">
    <ItemTemplate><MKB:TimeSelector ID="tpkIn" runat="server" SelectedTimeFormat="Twelve"></MKB:TimeSelector></ItemTemplate>
    <ItemStyle HorizontalAlign="left" Width="115px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="TimeOut">
    <ItemTemplate><MKB:TimeSelector ID="tpkOut" runat="server" SelectedTimeFormat="Twelve"></MKB:TimeSelector></ItemTemplate>
    <ItemStyle HorizontalAlign="left" Width="115px" /></asp:TemplateField>--%> 
        
    <asp:TemplateField HeaderText="V. Card No.">
    <ItemTemplate><asp:TextBox ID="txtVCardNo" runat="server" CssClass="txtBox" Text='<%# Bind("VCard") %>' DataFormatString="{0:0.00}" Width="80px"></asp:TextBox></ItemTemplate>
    <ItemStyle HorizontalAlign="right" Width="80px" /></asp:TemplateField>
        
    <asp:TemplateField HeaderText="Location">
    <ItemTemplate><asp:TextBox ID="txtLocation" runat="server" CssClass="txtBox" Text='<%# Bind("strLoca") %>' DataFormatString="{0:0.00}" Width="80px"></asp:TextBox></ItemTemplate>
    <ItemStyle HorizontalAlign="right" Width="80px" /></asp:TemplateField>  

    <%--<asp:TemplateField HeaderText="Floor"> <ItemTemplate>                                
    <asp:DropDownList ID="ddlFloor" runat="server">
    <asp:ListItem   Value="0">Select</asp:ListItem><asp:ListItem Value="1">Lavel 1</asp:ListItem>
    <asp:ListItem Value="2">Lavel 2</asp:ListItem><asp:ListItem Value="3">Lavel 3</asp:ListItem>
    </asp:DropDownList></ItemTemplate> </asp:TemplateField>--%>  
                
    <asp:TemplateField HeaderText="C.Generate" ItemStyle-HorizontalAlign="Center" SortExpression="Createcard">
    <ItemTemplate><asp:Button ID="btnCGenerate" class="nextclick" runat="server" Font-Size="9px" OnClick="CGenerate_Click"
    CommandArgument='<%# Container.DataItemIndex +"^"+ Eval("RId") +"^"+ Eval("Response") +"^"+ Eval("Createcard") %>' Text='<%# Bind("Createcard") %>' /></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="75px" /></asp:TemplateField>
        
    <asp:TemplateField HeaderText="Close" ItemStyle-HorizontalAlign="Center" SortExpression="Close">
    <ItemTemplate><asp:Button ID="btnComplete" class="nextclick" runat="server" Font-Size="9px" OnClick="Complete_Click"
    CommandArgument='<%# Container.DataItemIndex +"^"+ Eval("RId") +"^"+ Eval("Createcard") +"^"+ Eval("Complete") %>' Text='<%# Bind("Complete") %>' /></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="75px" /></asp:TemplateField>
        
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

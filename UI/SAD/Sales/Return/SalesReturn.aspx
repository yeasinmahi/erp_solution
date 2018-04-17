<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesReturn.aspx.cs" Inherits="UI.SAD.Sales.Return.SalesReturn" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> <%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<!DOCTYPE html>

<html><head runat="server"><title></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder0" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
<webopt:BundleReference ID="BundleReference0" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/hrCSS" />
<script>
    function Confirm() {
        document.getElementById("hdnconfirm").value = "0";        
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
        if (confirm("Do you want to submit?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
        else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }

    }
</script>
</head>
<body>
    <form id="frmsrtn" runat="server">
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
    <div class="leaveApplication_container"><b>Sales Return Entry: </b><asp:HiddenField ID="hdnconfirm" runat="server" /><hr />
    <table style="width:Auto";>
    <tr><td style="text-align:right;"><asp:Label ID="lblsrch" CssClass="lbl" runat="server" Text="Search : "></asp:Label></td>
    <td><asp:TextBox ID="txtSearch" runat="server" CssClass="txtBox" AutoPostBack="false"></asp:TextBox></td>
    <td style="text-align:right;" colspan="2"><asp:Button ID="btnShow" runat="server" class="nextclick" style="font:bold 12px verdana;" Text="GO" OnClick="btnShow_Click"/><hr />
    <asp:Label ID="lblcdt" CssClass="lbl" Font-Bold="true" ForeColor="Blue" runat="server" Text=""></asp:Label></td>
    </tr>
    <tr><td style="text-align:right;"><asp:Label ID="lblc" CssClass="lbl" runat="server" Text="Customer : "></asp:Label></td>
    <td><asp:TextBox ID="txtCustomer" runat="server" CssClass="txtBox" AutoPostBack="false" Enabled="false"></asp:TextBox></td>
    <td style="text-align:right;"><asp:Label ID="lblcn" CssClass="lbl" runat="server" Text="Challan No : "></asp:Label></td>
    <td><asp:TextBox ID="txtChallan" runat="server" CssClass="txtBox" AutoPostBack="false" Enabled="false"></asp:TextBox></td>
    </tr>

    <tr><td colspan="4"><asp:Label ID="lblitmdtls" CssClass="lbl" Font-Bold="true" ForeColor="Blue" Font-Underline="true" runat="server" Text="Item Details : "></asp:Label></td></tr>
    <tr><td colspan="4">
    <asp:GridView ID="dgvrtn" runat="server" AutoGenerateColumns="False" Font-Size="9px" BackColor="White" 
    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical">
    <AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>   
    <asp:TemplateField HeaderText="Product Name" SortExpression="strProductName"><ItemTemplate><asp:HiddenField ID="hdnuom" runat="server" Value='<%# Eval("intUom") %>' />
    <asp:HiddenField ID="itmid" runat="server" Value='<%# Eval("intProductId") %>' /><asp:HiddenField ID="hdnrate" runat="server" Value='<%# Eval("monPrice") %>'/>
    <asp:HiddenField ID="hdncust" runat="server" Value='<%# Eval("intCustomerId") %>'/><asp:HiddenField ID="hdnid" runat="server" Value='<%# Eval("intId") %>'/>
    <asp:Label ID="lblitem" runat="server" Text='<%# Bind("strProductName") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="300px"/></asp:TemplateField>
    <asp:TemplateField HeaderText="Quantity" SortExpression="numQuantity">
    <ItemTemplate><asp:Label ID="lblqnt" runat="server" Text='<%# Bind("numQuantity") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Center" Width="65px" /></asp:TemplateField>
    <asp:TemplateField HeaderText="Uom" SortExpression="strUOMShow">
    <ItemTemplate><asp:Label ID="lbluom" runat="server" Text='<%# Bind("strUOMShow") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="right" Width="65px" /></asp:TemplateField>
    <asp:TemplateField HeaderText="Rtn. Quantity" SortExpression="">
    <ItemTemplate><asp:TextBox ID="txtRtnqnt" CssClass="txtBox" Width="75px" runat="server" TextMode="Number" Text="0"></asp:TextBox></ItemTemplate>
    <ItemStyle HorizontalAlign="Right" Width="75px"/></asp:TemplateField>
    </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" /></asp:GridView>
    </td></tr>
    <tr><td style="text-align:right;" colspan="4"><asp:Button ID="btvSubmit" runat="server" class="nextclick" style="font:bold 12px verdana;" Text="Submit" OnClick="btvSubmit_Click"/></tr>
    </table>
    </div>
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BrandItemReceivingConfirmation.aspx.cs" Inherits="UI.Inventory.BrandItemReceivingConfirmation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html> <head runat="server"><title></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
<webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script>
        function Confirm() {
            document.getElementById("hdnconfirm").value = "0";
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
            else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
        }
        //$(document).ready(function () {
        //    document.getElementById("approvedDiv").style.display = "none";
        //    document.getElementById("itmdtlsDiv").style.display = "none";
        //});
        //function Viewdetails() { $("#approvedDiv").fadeIn("slow"); }
        //function ItemDetails(item, user) {
        //    Closediv(1);
        //    $("#itmdtlsDiv").fadeIn("slow");
        //}
        //function CloseItem() {
        //    $("#itmdtlsDiv").fadeOut("slow"); $("#approvedDiv").fadeIn("slow");
        //}

        function Closediv(sts) {
            if (sts == '1') { $("#approvedDiv").fadeOut("slow"); }
            else { alert(sts); $("#approvedDiv").fadeOut("slow"); }
        }
    </script>
</head>
<body>
    <form id="frmapp" runat="server">
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate><asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server"></cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
         <div class="leaveApplication_container"> <div class="tabs_container"> Brand Item Receive confirmation  by user : <asp:HiddenField ID="hdnuserid" runat="server"/><asp:HiddenField ID="hdnconfirm" runat="server" /><hr /></div>
        <table border="0"; style="width:Auto"; >
        <tr class="tblrowodd">
        <td style="text-align:right;"><asp:Label ID="lblfdt" CssClass="lbl" runat="server" Text="From Date : "></asp:Label></td>
        <td><asp:TextBox ID="txtFDate" runat="server" CssClass="txtBox" Width="100px"></asp:TextBox>
        <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFDate"></cc1:CalendarExtender></td>
        <td style="text-align:right;"><asp:Label ID="lbltdt" CssClass="lbl" runat="server" Text="To Date : "></asp:Label></td>
        <td><asp:TextBox ID="txtTDate" runat="server" CssClass="txtBox"  Width="100px"></asp:TextBox>
        <cc1:CalendarExtender ID="tdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtTDate"></cc1:CalendarExtender></td>            
        </tr>
        <tr><td style="text-align:right;" colspan="4"><asp:Button ID="btnShow" runat="server" Text="Show" Font-Bold="true" OnClick="btnShow_Click"></asp:Button></td></tr>

        <tr class=""><td style="text-align:justify;" colspan="4">
        <asp:GridView ID="dgvBrandItemReceiveStatus" runat="server" AutoGenerateColumns="False" Font-Size="11px" BackColor="White" BorderStyle="None" 
        BorderWidth="1px" CellPadding="3" GridLines="Vertical" BorderColor="#999999"><AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
        <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
        <asp:BoundField DataField="Req" HeaderText="IssueNumber" ItemStyle-HorizontalAlign="Center" SortExpression="Req">
        <ItemStyle HorizontalAlign="Left" Width="90px"/></asp:BoundField>

        <asp:BoundField DataField="Code" HeaderText="Req. Code" ItemStyle-HorizontalAlign="Center" SortExpression="Code">
        <ItemStyle HorizontalAlign="Left" Width="90px"/></asp:BoundField>
        <asp:BoundField DataField="Items" HeaderText="Item" ItemStyle-HorizontalAlign="Center" SortExpression="Code">
        <ItemStyle HorizontalAlign="Left" Width="90px"/></asp:BoundField>
       <%-- <asp:BoundField DataField="Section" HeaderText="Section" ItemStyle-HorizontalAlign="Center" SortExpression="Section">
        <ItemStyle HorizontalAlign="Left" Width="120px"/></asp:BoundField>--%>
       <%-- <asp:BoundField DataField="WHouse" HeaderText="WHouse" ItemStyle-HorizontalAlign="Center" SortExpression="WHouse">
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:BoundField>--%>
        <%--<asp:BoundField DataField="Department" HeaderText="Department" ItemStyle-HorizontalAlign="Center" SortExpression="Department">
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:BoundField>--%>
        <asp:BoundField DataField="DDate" HeaderText="Entry Date" ItemStyle-HorizontalAlign="Center" SortExpression="Edate" DataFormatString="{0:yyyy-MM-dd}">
        <ItemStyle HorizontalAlign="Left" Width="70px" /></asp:BoundField> 

        <asp:BoundField DataField="AppQuantity" HeaderText="IssuedQnt" ItemStyle-HorizontalAlign="Center" SortExpression="AppQuantity">
        <ItemStyle HorizontalAlign="Left" Width="70px" /></asp:BoundField> 

        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Recv" ControlStyle-BackColor="#66ffcc" ><ItemTemplate>
        <asp:Button ID="btnReceive" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" Text="Receive"  OnClick="btnReceive_Click" CommandArgument='<%# Eval("Req")%>'/>
        </ItemTemplate>
            <ControlStyle BackColor="#FF9999" />
            <ItemStyle HorizontalAlign="Left" /></asp:TemplateField>
                         
        </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
        </td></tr>
        </table>
     </div>






 <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>


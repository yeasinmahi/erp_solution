<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequisitionApproval.aspx.cs" Inherits="UI.Inventory.RequisitionApproval" %>
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
        $(document).ready(function () {
            document.getElementById("approvedDiv").style.display = "none";
            document.getElementById("itmdtlsDiv").style.display = "none";
        });
        function Viewdetails() { $("#approvedDiv").fadeIn("slow"); }
        function ItemDetails(item, user)
        {
            Closediv(1);
            $("#itmdtlsDiv").fadeIn("slow");
        }
        function CloseItem() {
            $("#itmdtlsDiv").fadeOut("slow"); $("#approvedDiv").fadeIn("slow");
        }

        function Closediv(sts)
        {
            if (sts == '1') {$("#approvedDiv").fadeOut("slow"); }
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

    <div class="leaveApplication_container"> <div class="tabs_container"> Store Requisition Information : <asp:HiddenField ID="hdnuserid" runat="server"/><asp:HiddenField ID="hdnconfirm" runat="server" /><hr /></div>
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
        <asp:GridView ID="dgvlist" runat="server" AutoGenerateColumns="False" Font-Size="11px" BackColor="White" BorderStyle="Solid" 
        BorderWidth="0px" CellPadding="1" ForeColor="Black" GridLines="Vertical" AllowPaging="false"><AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
        <asp:BoundField DataField="Edate" HeaderText="Entry Date" ItemStyle-HorizontalAlign="Center" SortExpression="Edate" DataFormatString="{0:yyyy-MM-dd}">
        <ItemStyle HorizontalAlign="Left" Width="70px" /></asp:BoundField> 
        <asp:BoundField DataField="Code" HeaderText="Req. Code" ItemStyle-HorizontalAlign="Center" SortExpression="Code">
        <ItemStyle HorizontalAlign="Left" Width="90px"/></asp:BoundField>
        <asp:BoundField DataField="Section" HeaderText="Section" ItemStyle-HorizontalAlign="Center" SortExpression="Section">
        <ItemStyle HorizontalAlign="Left" Width="120px"/></asp:BoundField>
        <asp:BoundField DataField="WHouse" HeaderText="WHouse" ItemStyle-HorizontalAlign="Center" SortExpression="WHouse">
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:BoundField>
        <asp:BoundField DataField="Department" HeaderText="Department" ItemStyle-HorizontalAlign="Center" SortExpression="Department">
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:BoundField>
        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Details" ><ItemTemplate>
        <asp:Button ID="btnDetails" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" CommandArgument='<%# Eval("Req") %>' Text="Details"  OnClick="Dtls_Click"/>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>
                         
        </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
        </td></tr>
        </table>
     </div>

     <div id="approvedDiv" style="margin-top:25px;">
        <table border="0";>
          <tr><td style="text-align:left; width:100px;"><img src="../Content/images/img/ag.png" /></td>
         <td style="text-align:center;font:bold 14px verdana;" colspan="3"><b><u>Store Requisition</u></b><br />
             <asp:Label ID="lblpoint" CssClass="lbl" runat="server" style="font:bold 12px verdana;"></asp:Label><br />
             <asp:Label ID="lblwh" CssClass="lbl" runat="server" style="font:bold 10px verdana;"></asp:Label>
         </td>
        </tr>

        <tr style="font:bold 10px verdana;"><td style="text-align:right; width:100px;"><asp:Label ID="lblc"  runat="server" Text="Requisition No: "></asp:Label></td>
        <td><asp:Label ID="lblRN" runat="server"></asp:Label></td><td style="text-align:right;"><asp:Label ID="lbldt" runat="server"></asp:Label></td></tr>

        <tr><td colspan="4" style="font:normal 10px verdana;">
        <asp:GridView ID="dgv" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" 
        BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Both"><AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
        <asp:BoundField DataField="Items" HeaderText="Description" ItemStyle-HorizontalAlign="Center" SortExpression="Items">
        <ItemStyle HorizontalAlign="Left" Width="225px" /></asp:BoundField>
        <asp:BoundField DataField="DDate" HeaderText="Req. Date" ItemStyle-HorizontalAlign="Center" SortExpression="DDate" DataFormatString="{0:yyyy-MM-dd}">
        <ItemStyle HorizontalAlign="Left" Width="70px" /></asp:BoundField>
        <asp:BoundField DataField="Quantity" HeaderText="Quantity" ItemStyle-HorizontalAlign="Center" SortExpression="Quantity" DataFormatString="{0:0.0000}">
        <ItemStyle HorizontalAlign="Center" Width="70px"/></asp:BoundField> 
        <asp:BoundField DataField="Remarks" HeaderText="Remarks" ItemStyle-HorizontalAlign="Center" SortExpression="Remarks">
        <ItemStyle HorizontalAlign="Left" Width="200px"/></asp:BoundField>
        <asp:TemplateField HeaderText="App. Quantity">
        <ItemTemplate><asp:HiddenField ID="hdnitemid" runat="server" Value='<%# Eval("Item") %>'/><asp:HiddenField ID="hdnreq" runat="server" Value='<%# Eval("Quantity") %>'/>
        <asp:HiddenField ID="hdnreqid" runat="server" Value='<%# Eval("Req") %>'/><asp:TextBox ID="txtAppQuantity" CssClass="txtBox" runat="server" Width="100px"></asp:TextBox></ItemTemplate>
        <ItemStyle HorizontalAlign="Center" Width="100px" /></asp:TemplateField>
        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Histry" ><ItemTemplate>
        <asp:Button ID="btnItemDtls" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" CommandArgument='<%# Container.DataItemIndex +"^"+ Eval("Req") + "^"+Eval("Item")+"^"+Eval("Quantity")+"^"+Eval("Section") %>' Text="Histry" OnClick="ItemDtls_Click"/>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>
        <%--<asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="" ><ItemTemplate>
        <asp:Button ID="btnApp" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" CommandArgument='<%# Container.DataItemIndex +"^"+ Eval("Req") + "^"+Eval("Item")+"^"+Eval("Quantity")+"^"+Eval("Section") %>' Text="Approved" OnClientClick="Confirm()"  OnClick="App_Click"/>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>--%>
        </Columns>
        <HeaderStyle BorderStyle="Solid" BorderColor="Black" BorderWidth="1px" Font-Bold="True"/><PagerStyle BackColor="#999999" ForeColor="Black" BorderStyle="Solid" BorderWidth="1px" BorderColor="Black" HorizontalAlign="Center" />
        </asp:GridView></td></tr>
        <tr><td style="text-align:right;" colspan="4"><asp:Button ID="btnApp" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" Text="Approved" OnClientClick="Confirm()" OnClick="btnApp_Click"/><br /></td>
        <tr><td style="text-align:left;" colspan="3"><br /><asp:Label ID="issby" runat="server"></asp:Label></td>
        <td style="text-align:right;"><a onclick="Closediv(1);" title="Close" style="cursor:pointer;text-align:right; color:red; font:bold 15px verdana;">X</a></td></tr>
        </table>
     </div>

    <div id="itmdtlsDiv" style="margin-top:25px;"><table><tr><td style="text-align:right;">
    <a onclick="CloseItem();" title="Close" style="cursor:pointer;text-align:right; color:red; font:bold 8px verdana;">X</a></td></tr>
    <tr><td><div id="report" runat="server" style="padding:1%;"></div></td></tr></table></div>

 <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

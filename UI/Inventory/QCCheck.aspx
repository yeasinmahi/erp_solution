﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QCCheck.aspx.cs" Inherits="UI.Inventory.QCCheck" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html> <head runat="server"><title></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
<webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
<webopt:BundleReference ID="bundleReference1" runat="server" Path="~/Content/Bundle/ProgressCSS"/>
    <script>
        $(document).ready(function () {
            document.getElementById("approvedDiv").style.display = "none";
        });
        function ShowDetailsDiv(poid) {
            document.getElementById("hdnpoid").value = poid;
            document.getElementById("lblpo").innerText = "PO. No: " + poid;
            $("#approvedDiv").fadeIn("slow");
        }
        function HideReasonDiv(msg) {
            $("#approvedDiv").fadeOut("slow");
            document.getElementById("hdnpoid").value = "";            
            if (msg.length > 0)
            { alert(msg); }
        }
        function ConfirmAll() {
            document.getElementById("hdnconfirm").value = "0";
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
            else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
        }
    </script>
</head>
<body>
    <form id="frmrequisition" runat="server">
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
    <div class="leaveApplication_container"> <div class="tabs_container"> Pending Material Inspection : <asp:HiddenField ID="hdnenroll" runat="server"/><hr /></div>
    <asp:GridView ID="dgvlist" runat="server" AutoGenerateColumns="False" Font-Size="11px" BackColor="White" BorderStyle="Solid" 
        BorderWidth="0px" CellPadding="1" ForeColor="Black" GridLines="Vertical" AllowPaging="True" PageSize="35" DataSourceID="odsmrpnding"><AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
        <asp:BoundField DataField="intPO" HeaderText="PO. No" ItemStyle-HorizontalAlign="Center" SortExpression="intPO">
        <ItemStyle HorizontalAlign="Center" Width="100px"/></asp:BoundField>
        <asp:BoundField DataField="dtePODate" HeaderText="PO.Date" ItemStyle-HorizontalAlign="Center" SortExpression="dtePODate" DataFormatString="{0:yyyy-MM-dd}">
        <ItemStyle HorizontalAlign="Center" Width="100px" /></asp:BoundField> 
        <asp:BoundField DataField="Column1" HeaderText="No Of Item" ItemStyle-HorizontalAlign="Center" SortExpression="Column1">
        <ItemStyle HorizontalAlign="Center" Width="100px" /></asp:BoundField>
        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="" >
        <ItemTemplate><asp:Button ID="btnAction" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" 
        CommandArgument='<%# Eval("intPO") %>' Text="Details" OnClick="Action_Click"/>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>  
        </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
    <asp:ObjectDataSource ID="odsmrpnding" runat="server" SelectMethod="GetPOPendingList" TypeName="HR_BLL.Global.DaysOfWeek">
    <SelectParameters><asp:ControlParameter ControlID="hdnenroll" Name="enroll" PropertyName="Value" Type="Int32" /></SelectParameters>
    </asp:ObjectDataSource>
    </div>

    <div id="approvedDiv">
       <table border="0"; style="width:Auto"; >
        <tr><td><asp:Label ID="lblpo" runat="server" Font-Bold="true"></asp:Label><br />
        <asp:GridView ID="dgv" runat="server" AutoGenerateColumns="False" Font-Size="12px" BackColor="White" BorderColor="#999999" 
        BorderStyle="Solid" BorderWidth="0px" CellPadding="1" ForeColor="Black" GridLines="Vertical"><AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:TemplateField HeaderText="Item No." SortExpression="intItemID">
        <ItemTemplate><asp:Label ID="lblitmno" runat="server" Text='<%# Bind("intItemID") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>
                                             
        <asp:TemplateField HeaderText="Item Name" SortExpression="strItem">
        <ItemTemplate><asp:Label ID="lblitem" runat="server" Text='<%# Bind("strItem") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Center" Width="250px" /></asp:TemplateField>

        <asp:BoundField DataField="strSpecification" HeaderText="Specification" ItemStyle-HorizontalAlign="Center" SortExpression="strSpecification">
        <ItemStyle HorizontalAlign="Center" Width="100px" /></asp:BoundField>

        <asp:TemplateField HeaderText="PO Quantity" SortExpression="numQty">
        <ItemTemplate><asp:Label ID="lblpoqnty" runat="server" Text='<%# Bind("numQty", "{0:0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Center" Width="95px" /></asp:TemplateField>

        <asp:BoundField DataField="Column1" HeaderText="Checked" ItemStyle-HorizontalAlign="Center" SortExpression="Column1" DataFormatString="{0:0}" >
        <ItemStyle HorizontalAlign="Center" Width="80px" /></asp:BoundField> 

        <asp:TemplateField HeaderText="Checking">
        <ItemTemplate><asp:TextBox ID="txtChkQuantity" CssClass="txtBox" runat="server" TextMode="Number" Width="100px"></asp:TextBox></ItemTemplate>
        <ItemStyle HorizontalAlign="Center" Width="100px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Remarks">
        <ItemTemplate><asp:TextBox ID="txtRemarks" CssClass="txtBox" runat="server" Width="100px"></asp:TextBox></ItemTemplate>
        <ItemStyle HorizontalAlign="Center" Width="100px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Proceed"><EditItemTemplate><asp:CheckBox ID="chkbx" runat="server" Checked="false"/></EditItemTemplate>
        <ItemTemplate><asp:CheckBox ID="chkbx" runat="server" Checked="false"/></ItemTemplate><ItemStyle HorizontalAlign="Center"/></asp:TemplateField>

        </Columns>
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>            
        </td></tr>
        <tr><td style="text-align:right;"><asp:HiddenField ID="hdnpoid" runat="server"/><asp:HiddenField ID="hdnconfirm" runat="server"/><a class="nextclick" onclick="HideReasonDiv('')">Cancel</a>
        <asp:Button ID="btnSubmit" runat="server" CssClass="nextclick" Text="Submit" OnClientClick="ConfirmAll()" OnClick="btnSubmit_Click"/></td></tr>
        </table>
    </div>


<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

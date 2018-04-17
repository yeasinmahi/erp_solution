<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeTax.aspx.cs" Inherits="UI.HR.Tax.EmployeeTax" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>.:: Employee Tax Information ::.</title>
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
   </script>

</head>
<body>
    <form id="frmtax" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate> <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
    <div class="tabs_container">Employee Tax Information :<hr />
        <table><tr>
        <td style="text-align:right;"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit-Name : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" CssClass="dropdownList" 
        DataSourceID="ODSUnit" DataTextField="strUnit" DataValueField="intUnitID" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged" OnDataBound="ddlUnit_DataBound"></asp:DropDownList>
        <asp:ObjectDataSource ID="ODSUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit" OldValuesParameterFormatString="original_{0}">
        <SelectParameters><asp:SessionParameter Name="userid" SessionField="sesUserID" Type="String"/></SelectParameters></asp:ObjectDataSource>
        </td>
        <td style="text-align:right;"><asp:HiddenField ID="hdnconfirm" runat="server" />
        <asp:CheckBox ID="chkAll" runat="server" Text="All Employee" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged"/>
        <asp:Button ID="btnRequest" runat="server" class="nextclick" style="font-size:10px;" Text="Request For Payment" OnClientClick="Confirm()" OnClick="btnRequest_Click"/>
        </td></tr></table>
    </div>

        <asp:GridView ID="dgvtax" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" FooterStyle-HorizontalAlign="Right" 
        BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" ShowFooter="true" FooterStyle-BackColor="#99ccff" FooterStyle-Font-Bold="true" FooterStyle-ForeColor="Blue">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
        <EditItemTemplate><asp:CheckBox ID="chkbx" runat="server"/></EditItemTemplate>
        <ItemTemplate><asp:CheckBox ID="chkbx" runat="server"/>
        <asp:HiddenField ID="hdnenroll" runat="server" Value='<%# Eval("intEmployeeID") %>' />
        </ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>

        <asp:BoundField DataField="strEmployeeName" HeaderText="Employee-Name" ItemStyle-HorizontalAlign="Center" SortExpression="strEmployeeName">
        <ItemStyle Width="275px" HorizontalAlign="Left"/></asp:BoundField>

        <asp:BoundField DataField="strDesignation" HeaderText="Designation" ItemStyle-HorizontalAlign="Center" SortExpression="strDesignation">
        <ItemStyle Width="100px" HorizontalAlign="Left"/></asp:BoundField>

        <asp:BoundField DataField="strDepatrment" HeaderText="Department" ItemStyle-HorizontalAlign="Center" SortExpression="strDepatrment">
        <ItemStyle Width="100px" HorizontalAlign="Left"/></asp:BoundField>       
            
        <asp:BoundField DataField="strJobStationName" HeaderText="Station" ItemStyle-HorizontalAlign="Center" SortExpression="strJobStationName" FooterText="Total : " >
        <ItemStyle Width="125px" HorizontalAlign="Left"/></asp:BoundField> 

        <asp:BoundField DataField="monTaxAmount" HeaderText="Tax-Amount" ItemStyle-HorizontalAlign="Center" SortExpression="monTaxAmount" DataFormatString="{0:0.00}">
        <ItemStyle Width="100px" HorizontalAlign="right"/></asp:BoundField> 

        </Columns>
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

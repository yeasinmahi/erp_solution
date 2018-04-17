<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductionEntry.aspx.cs" Inherits="UI.Vat.ProductionEntry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>.:: Production Entry ::.</title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>  
<webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

    <script>
        function Confirm() {
            document.getElementById("hdnconfirm").value = "0";
            var monQuantity = document.forms["frmproductentry"]["monQuantity"].value;
            var txtDate = document.forms["frmproductentry"]["txtDate"].value;

            if (monQuantity == null || monQuantity == "") {
                alert("Quantity must be filled by valid value.");
            }else 
            if (txtDate == null || txtDate == "") {
                alert("Date must be filled by valid formate (year-month-day).");
            }
            else {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
            }
        }
    </script>
</head>
<body>
    <form id="frmproductentry" runat="server">
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
    <div class="divs_content_container"> 
    <div class="tabs_container">Production Entry: <asp:HiddenField ID="hdnvtacc" runat="server" /><asp:HiddenField ID="hdnconfirm" runat="server" /><hr />

        <table>
        <tr>
        <td style="text-align:right;"><asp:Label ID="lblvatacc" CssClass="lbl" runat="server" Text="Vat-Account : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlVatAcc" runat="server" AutoPostBack="True" CssClass="dropdownList" DataTextField="strVatAccountName" DataValueField="intVatAccountID"
        DataSourceID="odsvatacc" OnSelectedIndexChanged="ddlVatAcc_SelectedIndexChanged"></asp:DropDownList>
        <asp:ObjectDataSource ID="odsvatacc" runat="server" SelectMethod="GetVatAccountList" TypeName="BLL.Accounts.PartyPayment.PartyBill">
        <SelectParameters><asp:SessionParameter Name="userid" SessionField="sesUserID" Type="Int32" />
        <asp:SessionParameter Name="unitid" SessionField="sesUnit" Type="Int32" /></SelectParameters></asp:ObjectDataSource>        
        </td>
        <td style="text-align:right;"><asp:Label ID="lblproduct" runat="server" CssClass="lbl" Text="Vat-Product : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlProduct" runat="server" AutoPostBack="True" CssClass="dropdownList" DataSourceID="odsproductlist" 
         DataTextField="strVatProductName" DataValueField="intID"></asp:DropDownList>
        <asp:ObjectDataSource ID="odsproductlist" runat="server" SelectMethod="GetVatItemList" TypeName="BLL.Accounts.PartyPayment.PartyBill" OldValuesParameterFormatString="original_{0}">
        <SelectParameters><asp:ControlParameter ControlID="ddlVatAcc" Name="vatacc" PropertyName="SelectedValue" Type="Int32" /></SelectParameters>
        </asp:ObjectDataSource>
        </td>
        </tr>

        <tr>
        <td style="text-align:right;"><asp:Label ID="lblquantity" CssClass="lbl" runat="server" Text="Quantity : "></asp:Label></td>
        <td><asp:TextBox ID="monQuantity" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="lbldate" CssClass="lbl" runat="server" Text="Date : "></asp:Label></td>
        <td><asp:TextBox ID="txtDate" runat="server" CssClass="txtBox"></asp:TextBox>
        <cc1:CalendarExtender ID="CEA" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDate"></cc1:CalendarExtender></td>
        </tr>
        <tr>
        <td style="text-align:right;" colspan="4">
        <asp:Button ID="btnAdd" runat="server" class="nextclick" style="font-size:11px;" Text="ADD" OnClientClick="Confirm()" OnClick="btnAdd_Click"/>
        <asp:Button ID="btnSubmit" runat="server" class="nextclick" style="font-size:11px;" Text="Submit" OnClientClick="Confirm()" OnClick="btnSubmit_Click"/>
        </td>
       </tr> 

        <tr><td colspan="4">
        <asp:GridView ID="dgvViewproduction" runat="server" AutoGenerateColumns="False" SkinID="sknGrid2" Font-Size="11px" BackColor="White">
        <Columns>
        <asp:TemplateField HeaderText="" Visible="false"><ItemStyle HorizontalAlign="Left" Width="50px"/>
        <ItemTemplate><asp:Label ID="lblitemid" runat="server" Text='<%# Bind("itemid") %>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Product Name"><ItemStyle HorizontalAlign="Left" Width="350px"/>
        <ItemTemplate><asp:Label ID="lblproduct" runat="server" Text='<%# Bind("product") %>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Production Quantity"><ItemStyle HorizontalAlign="Right"/>
        <ItemTemplate><asp:Label ID="lblquantity" runat="server" Text='<%# Bind("quantity") %>'></asp:Label></ItemTemplate>   
        </asp:TemplateField>
        <asp:BoundField DataField="date" HeaderText="Date" ItemStyle-HorizontalAlign="Center" SortExpression="date" DataFormatString="{0:yyyy-MM-dd}">
        <ItemStyle Width="100px" HorizontalAlign="Left"/></asp:BoundField>
        </Columns>
        </asp:GridView>
        </td></tr>
        </table>
    </div>
    </div>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

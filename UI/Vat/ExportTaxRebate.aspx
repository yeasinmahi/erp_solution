<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExportTaxRebate.aspx.cs" Inherits="UI.Vat.ExportTaxRebate" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>.:: Treasury Entry ::.</title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>  
<webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

    <script>
        function Confirm() {
            document.getElementById("hdnconfirm").value = "0";
            var txtboeDate = document.forms["frmexptaxrbt"]["txtboeDate"].value;
            var purAmount = document.forms["frmexptaxrbt"]["purAmount"].value;
            var rbtAmount = document.forms["frmexptaxrbt"]["rbtAmount"].value;
            var txtBOENo = document.forms["frmexptaxrbt"]["txtBOENo"].value;

            if (txtboeDate == null || txtboeDate == "") {
                alert("Date must be filled by valid formate (year-month-day).");
            }
            else if (purAmount == null || purAmount == "" || isNaN(purAmount)) {
                alert("Purchase amount must be filled by numeric value.");
            }
            else if (rbtAmount == null || rbtAmount == "" || isNaN(rbtAmount)) {
                alert("Tax rebate must be filled by numeric value.");
            }
            else if (txtBOENo == null || txtBOENo == "") {
                alert("Bill of entry must be filled.");
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
    <form id="frmexptaxrbt" runat="server">
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
    <div class="tabs_container">Other Tax Rebate For Export: <asp:HiddenField ID="hdnvtacc" runat="server" /> 
    <asp:HiddenField ID="hdnconfirm" runat="server" /><hr /></div>
    <table>
        <tr>
        <td style="text-align:right;"><asp:Label ID="lblvatacc" CssClass="lbl" runat="server" Text="Vat-Account : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlVatAcc" runat="server" AutoPostBack="True" CssClass="dropdownList" DataTextField="strVatAccountName" DataValueField="intVatAccountID"
        DataSourceID="odsvatacc"></asp:DropDownList>
        <asp:ObjectDataSource ID="odsvatacc" runat="server" SelectMethod="GetVatAccountList" TypeName="BLL.Accounts.PartyPayment.PartyBill">
        <SelectParameters><asp:SessionParameter Name="userid" SessionField="sesUserID" Type="Int32" />
        <asp:SessionParameter Name="unitid" SessionField="sesUnit" Type="Int32" /></SelectParameters></asp:ObjectDataSource>        
        </td>
        </tr>

        <tr>
        <td style="text-align:right;"><asp:Label ID="lblquantity" CssClass="lbl" runat="server" Text="Amount (Without Vat) :"></asp:Label></td>
        <td><asp:TextBox ID="purAmount" runat="server" CssClass="txtBox" TextMode="Number" Enabled="true"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Vat Amount :"></asp:Label></td>
        <td><asp:TextBox ID="rbtAmount" runat="server" CssClass="txtBox" TextMode="Number" Enabled="true"></asp:TextBox></td>
        </tr>

        <tr>
        <td style="text-align:right;"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="BOE No. : "></asp:Label></td>
        <td><asp:TextBox ID="txtBOENo" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="lbldate" CssClass="lbl" runat="server" Text="BOE Date : "></asp:Label></td>
        <td><asp:TextBox ID="txtboeDate" runat="server" CssClass="txtBox"></asp:TextBox>
        <cc1:CalendarExtender ID="CEA" runat="server" Format="yyyy-MM-dd" TargetControlID="txtboeDate"></cc1:CalendarExtender></td>        
        </tr>
        <tr>
        <td style="text-align:right;" colspan="4">
        <asp:Button ID="btnSubmit" runat="server" class="nextclick" style="font-size:11px;" Text="Submit" OnClientClick="Confirm()" OnClick="btnSubmit_Click"/>
        </td></tr>
    </table>
   </div>
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

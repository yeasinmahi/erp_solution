<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CurrentRegisterM18.aspx.cs" Inherits="UI.Vat.CurrentRegisterM18" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>.:: Current Register ::.</title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>  
<webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script>
        function Confirm() {
            document.getElementById("hdnconfirm").value = "0";
            var txtFromDte = document.forms["frmcurrentsregister"]["txtFromDte"].value;
            var txtDteTo = document.forms["frmcurrentsregister"]["txtDteTo"].value;

            if (txtFromDte == null || txtFromDte == "") {
                alert("From Date must be filled by valid formate (year-month-day).");
            }
            else if (txtDteTo == null || txtDteTo == "") {
                alert("To Date must be filled by valid formate (year-month-day).");
            }
            else if (txtDteTo < txtFromDte) {
                alert("To Date must be greater than from date.");
            }
            else {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
            }
        }
        function ShowReport(vtacc, frmdte, todte, type_) {
            var url = 'PrintM18.aspx?VATACC=' + vtacc + '&FROMDATE=' + frmdte + '&TODATE=' + todte + '&TYPE=' + type_;
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,top=10,left=100, width=1180px');
            if (window.focus) { newwindow.focus() }
        }
    </script>
</head>
<body>
    <form id="frmcurrentsregister" runat="server">
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
    <div class="tabs_container">Current Register: <asp:HiddenField ID="hdnvtacc" runat="server" /> <asp:HiddenField ID="hdnconfirm" runat="server" /><hr />

        <table>
        <tr><td style="text-align:right;"><asp:Label ID="lblproduct" runat="server" CssClass="lbl" Text="Vat-Product : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" CssClass="dropdownList">
            <asp:ListItem Selected="True" Value="2">VAT</asp:ListItem><asp:ListItem Value="1">SD</asp:ListItem>
            <asp:ListItem Value="0">ALL</asp:ListItem></asp:DropDownList>
        </td>
        <td style="text-align:right;"><asp:Label ID="lblvatacc" CssClass="lbl" runat="server" Text="Vat-Account : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlVatAcc" runat="server" AutoPostBack="True" CssClass="dropdownList" DataTextField="strVatAccountName" DataValueField="intVatAccountID"
        DataSourceID="odsvatacc" OnSelectedIndexChanged="ddlVatAcc_SelectedIndexChanged"></asp:DropDownList>
        <asp:ObjectDataSource ID="odsvatacc" runat="server" SelectMethod="GetVatAccountList" TypeName="BLL.Accounts.PartyPayment.PartyBill">
        <SelectParameters><asp:SessionParameter Name="userid" SessionField="sesUserID" Type="Int32" />
        <asp:SessionParameter Name="unitid" SessionField="sesUnit" Type="Int32" /></SelectParameters></asp:ObjectDataSource>        
        </td>
        </tr>
        <tr>        
        <td style="text-align:right;"><asp:Label ID="lbldteFrom" CssClass="lbl" runat="server" Text="From-Date : "></asp:Label></td>
        <td><asp:TextBox ID="txtFromDte" runat="server" CssClass="txtBox"></asp:TextBox>
        <cc1:CalendarExtender ID="CEJ" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDte"></cc1:CalendarExtender>                                                        
        </td>
        <td style="text-align:right;"><asp:Label ID="lbldteto" CssClass="lbl" runat="server" Text="To-Date : "></asp:Label></td>
        <td style="text-align:right;"><asp:TextBox ID="txtDteTo" runat="server" CssClass="txtBox"></asp:TextBox>
        <cc1:CalendarExtender ID="CEA" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDteTo"></cc1:CalendarExtender>
        </td></tr>
        <tr>
        <td style="text-align:right;" colspan="4">
        <asp:Button ID="btnShow" runat="server" class="nextclick" style="font-size:11px;" Text="Show" OnClientClick="Confirm()" OnClick="btnShow_Click"/>
        <asp:Button ID="btnShowReport" runat="server" class="nextclick" style="font-size:11px;" Text="PrintReport" OnClientClick="Confirm()" OnClick="btnShowReport_Click"/>
        </td></tr>
        </table> </div>

<asp:GridView ID="dgvcurrentregister" runat="server" AutoGenerateColumns="False" SkinID="sknGrid2" Font-Size="11px" BackColor="White">
        <Columns>
        <asp:TemplateField HeaderText="intRowID"><ItemStyle HorizontalAlign="Left" Width="25px"/>
        <ItemTemplate><asp:Label ID="lblsl" runat="server" Text='<%# Bind("intRowID") %>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Date_" HeaderText="Date" ItemStyle-HorizontalAlign="Center" SortExpression="Date_" DataFormatString="{0:yyyy-MM-dd}">
        <ItemStyle Width="67px" HorizontalAlign="Left"/></asp:BoundField>

        <asp:TemplateField HeaderText="TransactionDescription"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lblquantity" runat="server" Text='<%# Bind("TransactionDescription") %>'></asp:Label></ItemTemplate>   
        </asp:TemplateField>

        <asp:TemplateField HeaderText="RefferenceSL"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lbldate" runat="server" Text='<%# Bind("RefferenceSL") %>'></asp:Label></ItemTemplate>   
        </asp:TemplateField>        

        <asp:BoundField DataField="RefferenceDate" HeaderText="RefferenceDate" ItemStyle-HorizontalAlign="Center" SortExpression="RefferenceDate" DataFormatString="{0:yyyy-MM-dd}">
        <ItemStyle HorizontalAlign="Left"/></asp:BoundField>

        <asp:TemplateField HeaderText="TreasuryDeposit"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lblproduct" runat="server" Text='<%# Bind("TreasuryDeposit") %>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Rebate"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lblquantity" runat="server" Text='<%# Bind("Rebate") %>'></asp:Label></ItemTemplate>   
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Adjust"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lbladjust" runat="server" Text='<%# Bind("Adjust") %>'></asp:Label></ItemTemplate>   
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Payable"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lbldate" runat="server" Text='<%# Bind("Payable") %>'></asp:Label></ItemTemplate>   
        </asp:TemplateField>

        <asp:TemplateField HeaderText="RunningBalance"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lblsl" runat="server" Text='<%# Bind("RunningBalance") %>'></asp:Label></ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Remarks"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lbldate" runat="server" Text='<%# Bind("Remarks") %>'></asp:Label></ItemTemplate>   
        </asp:TemplateField>

        </Columns>
        </asp:GridView>



<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

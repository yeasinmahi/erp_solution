<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FirstAuthorizationView.aspx.cs" Inherits="UI.Accounts.PartyPayment.FirstAuthorizationView" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.:: Party Bank Voucher First Authorization ::.</title>
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
            document.forms[0].appendChild(confirm_value);
        }
        function ShowVoucher(voucher, type, debit) {
            var rand_no = Math.floor(11 * Math.random());
            var url = 'PrintVoucher.aspx?id=' + voucher + '&type=' + type + '&isDr=' + debit + '&rnd=' + rand_no;
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=580,width=900,top=50,left=200');
            if (window.focus) { newwindow.focus() }
        }
        function ShowBillVatPOMRR(intbillid, intpoid, intshipmentid, vwtype) {
            window.open('Previewall.aspx?BILLID=' + intbillid + '&POID=' + intpoid + '&SHPID=' + intshipmentid + '&VTP=' + vwtype, '', "height=auto, width=auto, scrollbars=yes, left=250, top=100, resizable=yes, title=Preview");
        }
    </script>
</head>
<body>
    <form id="frmbankvoucherfirstauthorization" runat="server">
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
<div class="tabs_container">Voucher List For Cheque Authorization:<hr /><asp:HiddenField ID="hdnuserid" runat="server" /><asp:HiddenField ID="hdnconfirm" runat="server" /></div>
     <table border="0"; style="width:Auto";>
     <tr>
        <td style="text-align:right;"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit-Name : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" CssClass="dropdownList" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged" OnDataBound="ddlUnit_DataBound" DataSourceID="odsunit" DataTextField="strUnit" DataValueField="intUnitID"></asp:DropDownList>
        <asp:ObjectDataSource ID="odsunit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
        <SelectParameters><asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String" /></SelectParameters>
        </asp:ObjectDataSource>
        </td>
        <td style="text-align:right;"><asp:Label ID="lblsearchgo" CssClass="lbl" runat="server" Text="Search : "></asp:Label></td>
        <td><asp:TextBox ID="txtCode" runat="server" CssClass="txtBox"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" class="nextclick" style="font-size:11px;" Text="Go" OnClick="btnSearch_Click"/>
        <asp:HiddenField ID="hdngobycode" runat="server" />     
        </td>
     </tr>

     <tr><td colspan="4" style="font-size:11px; text-align:right;"><asp:CheckBox ID="chkAll" runat="server" Text="All Voucher" OnCheckedChanged="chkAll_CheckedChanged" AutoPostBack="true"/><br />
     <asp:Button ID="btnAllAuthorize" runat="server" Text="All Authorize" OnClick="btnAllAuthorize_Click" OnClientClick = "Confirm()"/><asp:HiddenField ID="hdnprinted" runat="server" /> </td>
     </tr>
    </table>
</div>

<asp:GridView ID="dgvViewVoucher" runat="server" AutoGenerateColumns="False" SkinID="sknGrid2" AllowPaging="True" PageSize="20" Font-Size="11px"
        BackColor="White" DataSourceID="odspartybnkvoucher">
        <Columns>    
          <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
          <EditItemTemplate><asp:CheckBox ID="chkbx" runat="server" /></EditItemTemplate>
          <ItemTemplate><asp:CheckBox ID="chkbx" runat="server" />
          <asp:HiddenField ID="hdnvoucherid" runat="server" Value='<%# Eval("intBankVoucherID") %>' />
          <asp:HiddenField ID="hdnbillno" runat="server" Value='<%# Eval("intBillNo") %>'/>
          <asp:HiddenField ID="hdnpoid" runat="server" Value='<%# Eval("intPOID") %>' />
          <asp:HiddenField ID="hdnshipmentid" runat="server" Value='<%# Eval("intShipmentID") %>' />
          <asp:HiddenField ID="hdnamount" runat="server" Value='<%# Eval("monAmount") %>' />
          </ItemTemplate>  <ItemStyle HorizontalAlign="Center" />
          </asp:TemplateField>    

          <asp:BoundField DataField="strCode" ItemStyle-HorizontalAlign="Center" HeaderText="Voucher Code" SortExpression="strCode">
          <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:BoundField>       

          <asp:BoundField DataField="strBankName" ItemStyle-HorizontalAlign="Center" HeaderText="Bank Name" SortExpression="strBankName">
          <ItemStyle HorizontalAlign="Left" Width="200px"/></asp:BoundField> 
            
          <asp:BoundField DataField="strAccountNo" ItemStyle-HorizontalAlign="Center" HeaderText="Account No" SortExpression="strAccountNo">
          <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:BoundField>
              
          <asp:BoundField DataField="strUsedChequeNoList" ItemStyle-HorizontalAlign="Center" HeaderText="Cheque No" SortExpression="strUsedChequeNoList">
          <ItemStyle HorizontalAlign="Left" Width="90px"/></asp:BoundField>

          <asp:BoundField DataField="monAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Amount" SortExpression="monAmount" DataFormatString="{0:0,000.00}">
          <ItemStyle HorizontalAlign="Right" /></asp:BoundField>

          <asp:BoundField DataField="strPayToPrint" ItemStyle-HorizontalAlign="Center" HeaderText="Pay To" SortExpression="strPayToPrint">
          <ItemStyle HorizontalAlign="Left" Width="200px"/></asp:BoundField> 

          <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Bill" >
          <ItemTemplate> <input id="btnShowBill" type="button" class="nextclick" style="cursor:pointer; font-size:10px;" value="Preview" onclick="<%# GetJSShowBillVATPOMRR(  Eval("intBillNo"), Eval("intPOID"), Eval("intShipmentID"), "Bill") %>" />
          </ItemTemplate> <ItemStyle HorizontalAlign="Left" /></asp:TemplateField> 
          <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Adjust" >
          <ItemTemplate> <input id="btnShowAdjust" type="button" class="nextclick" style="cursor:pointer; font-size:10px;" value="Preview" onclick="<%# GetJSShowBillVATPOMRR(  Eval("intBillNo"), Eval("intPOID"), Eval("intShipmentID"), "Adjust") %>" />
          </ItemTemplate> <ItemStyle HorizontalAlign="Left" /></asp:TemplateField> 
          <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="PO" >
          <ItemTemplate> <input id="btnShowPO" type="button" class="nextclick" style="cursor:pointer; font-size:10px;" value="Preview" onclick="<%# GetJSShowBillVATPOMRR(  Eval("intBillNo"), Eval("intPOID"), Eval("intShipmentID"), "Po") %>" />
          </ItemTemplate> <ItemStyle HorizontalAlign="Left" /></asp:TemplateField>         
          <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="VAT" >
          <ItemTemplate> <input id="btnShowVat" type="button" class="nextclick" style="cursor:pointer; font-size:10px;" value="Preview" onclick="<%# GetJSShowBillVATPOMRR(  Eval("intBillNo"), Eval("intPOID"), Eval("intShipmentID"), "Vat") %>" />
          </ItemTemplate> <ItemStyle HorizontalAlign="Left" /></asp:TemplateField> 
          <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="MRR" >
          <ItemTemplate> <input id="btnShowMRR" type="button" class="nextclick" style="cursor:pointer; font-size:10px;" value="Preview" onclick="<%# GetJSShowBillVATPOMRR(  Eval("intBillNo"), Eval("intPOID"), Eval("intShipmentID"), "Mrr") %>" />
          </ItemTemplate> <ItemStyle HorizontalAlign="Left" /></asp:TemplateField>  
          
           <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Voucher" >
          <ItemTemplate><input id="btnShowVoucher" type="button" class="nextclick" style="cursor:pointer; font-size:10px;" value="Preview" onclick="<%# GetJSShowVoucher( Eval("intBankVoucherID"), "bn", "true") %>" />
          </ItemTemplate> <ItemStyle HorizontalAlign="Left" /></asp:TemplateField>  
          
           <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Signature" >
          <ItemTemplate> <asp:Button ID="btnsign" runat="server" class="nextclick" style="cursor:pointer; font-size:10px;" CommandArgument='<%# Eval("intBankVoucherID") %>'
          Text="Clickme" OnClick="Sign_Click" OnClientClick = "Confirm()"/></ItemTemplate> <ItemStyle HorizontalAlign="Left" /></asp:TemplateField>
       </Columns>
</asp:GridView>
<asp:ObjectDataSource ID="odspartybnkvoucher" runat="server" SelectMethod="GetPartyBankVoucher" TypeName="BLL.Accounts.PartyPayment.PartyBill" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlUnit" Name="unitid" PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="hdngobycode" Name="vouchercode" PropertyName="Value" Type="String" />
                <asp:SessionParameter Name="userid" SessionField="sesUserID" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>


<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

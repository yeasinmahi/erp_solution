<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountsVoucherStatusReport.aspx.cs" Inherits="UI.Accounts.PartyPayment.AccountsVoucherStatusReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.:: Party Bank Voucher Status Report ::.</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>  
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script>
        function Confirm() {
            document.getElementById("hdnconfirm").value = "0";
            var frmDt = document.forms["frmvoucherstatus"]["txtFromDate"].value;
            var toDt = document.forms["frmvoucherstatus"]["txtToDate"].value;
            if (frmDt == null || frmDt == "") {
                alert("From date must be filled by valid formate (year-month-day).");
            }
            else if (toDt == null || toDt == "") {
                alert("To date must be filled by valid formate (year-month-day).");
            }
            else
            {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
            }
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
    <form id="frmvoucherstatus" runat="server">
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

<div class="divs_content_container" style="width:590px;">
<div class="tabs_container">Voucher Status :<hr /><asp:HiddenField ID="hdnuserid" runat="server" /><asp:HiddenField ID="hdnconfirm" runat="server"/></div>
     <table border="0";>
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
     <tr>
        <td style="text-align:right;"><asp:Label ID="lblfromdate" CssClass="lbl" runat="server" Text="From-Date : "></asp:Label></td>
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox"></asp:TextBox>
        <cc1:CalendarExtender ID="CES" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender>                                                        
        </td>
        <td style="text-align:right;"><asp:Label ID="lbltodate" CssClass="lbl" runat="server" Text="To-Date : "></asp:Label></td>
        <td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox"></asp:TextBox>
        <cc1:CalendarExtender ID="CEE" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender> 
        </td>
     </tr>

     <tr>
         <td colspan="2" style="font-size:11px;"><asp:HiddenField ID="hdncompleteded" runat="server" /> 
         <asp:RadioButtonList ID="rdocompletestatus" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdocompletestatus_SelectedIndexChanged">
         <asp:ListItem Selected="True" Value="false">Not Completed</asp:ListItem><asp:ListItem Value="true">Completed</asp:ListItem></asp:RadioButtonList> 
         </td>
         <td colspan="2" style="text-align:right;">
         <%--<asp:Button ID="btnShowAll" runat="server" CssClass="nextclick" font-size="11px" Text="Show" OnClientClick = "Confirm()" OnClick="btnShowAll_Click"/>--%>
         </td>
     </tr>

    </table>
</div>


<asp:GridView ID="dgvViewVoucher" runat="server" AutoGenerateColumns="False" SkinID="sknGrid2" AllowPaging="True" PageSize="20" Font-Size="11px" BackColor="White" DataSourceID="odsvoucherstatus">
        <Columns>    
          <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" Visible="false">
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

       </Columns>
</asp:GridView>

        

        <asp:ObjectDataSource ID="odsvoucherstatus" runat="server" SelectMethod="GetVoucherStatusReport" TypeName="BLL.Accounts.PartyPayment.PartyBill">
            <SelectParameters>
                <asp:ControlParameter ControlID="hdngobycode" Name="vouchercode" PropertyName="Value" Type="String" />
                <asp:ControlParameter ControlID="ddlUnit" Name="unitid" PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="txtFromDate" Name="fromdate" PropertyName="Text" Type="DateTime" />
                <asp:ControlParameter ControlID="txtToDate" Name="todate" PropertyName="Text" Type="DateTime" />
                <asp:ControlParameter ControlID="hdncompleteded" Name="completed" PropertyName="Value" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>

        

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

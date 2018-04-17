<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuthorizedPartyCheque.aspx.cs" Inherits="UI.Accounts.PartyPayment.AuthorizedPartyCheque" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.:: Authorized Party Cheque ::.</title>
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
        /*function Confirmation() {
            var txtcode1 = document.forms["frmauthorizedpartycheque"]["txtCode1"].value;
            var txtcode2 = document.forms["frmauthorizedpartycheque"]["txtCode2"].value;

            if (txtcode1 == null || txtcode1 == "") {
                alert("Must be filled by valid voucher code.");
            }
            else if (txtcode2 == null || txtcode2 == "") {
                alert("Must be filled by valid voucher code.");
            }
            else
            {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; }
                else { confirm_value.value = "No"; }
                document.forms[0].appendChild(confirm_value);
            }
        }*/
        function ShowSingleChequePrint(voucherid)
        {
            var url = '../Print/PrintCheck.aspx?id=' + voucherid + '&type=bn';
            var rand_no = Math.floor(11 * Math.random());
            url = url + '&rnd=' + rand_no;
            newwindow = window.open(url, 'sub', 'toolbar=0,height=500,width=1058,top=50,left=200, scrollbars=1, resizable=yes');
            if (window.focus) { newwindow.focus() }
        }
        function ShowMultipleChequePrint(selectedvouchers, paytype) {
            var url = 'MultipleChequePrint.aspx?selectedvouchers=' + selectedvouchers + '&paytype=' + paytype + '';
            var rand_no = Math.floor(11 * Math.random());
            url = url + '&rnd=' + rand_no;
            newwindow = window.open(url, 'sub', 'toolbar=0,height=500,width=1058,top=50,left=200, scrollbars=1, resizable=yes');
            if (window.focus) { newwindow.focus() }
        }
   </script>
</head>
<body>
    <form id="frmauthorizedpartycheque" runat="server">
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

    <div class="divs_content_container" style="width:600px"> <div class="tabs_container">Authorized Cheque List :<hr /><asp:HiddenField ID="hdnconfirm" runat="server"/></div>
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

         <%--<tr>
         <td colspan="4"><asp:Label ID="lblchange" CssClass="lbl" runat="server" Text="Interchange : "></asp:Label>
         <asp:TextBox ID="txtCode1" CssClass="txtBox" runat="server"></asp:TextBox><asp:TextBox ID="txtCode2" CssClass="txtBox" runat="server"></asp:TextBox>
         <asp:Button ID="btnMChange" runat="server" Text="Make Change" Font-Size="11px" OnClick="btnMChange_Click" OnClientClick = "Confirmation()"/><br />
         <asp:Label ID="lblStatus" runat="server" Text="" ForeColor="Maroon" Font-Size="12px"></asp:Label></td>
         </tr>--%>

         <tr>
         <td style="text-align:right;"><asp:Label ID="lblbanklist" CssClass="lbl" runat="server" Text="BankList : "></asp:Label></td>
         <td><asp:DropDownList ID="ddlBank" runat="server" AutoPostBack="true" CssClass="dropdownList" DataSourceID="odsBank"
         DataTextField="strBankName" DataValueField="intBankID"></asp:DropDownList>
         <asp:ObjectDataSource ID="odsBank" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetActiveForDDL" 
         TypeName="BLL.Accounts.Bank.BankInfo"></asp:ObjectDataSource></td>
         <td style="text-align:right;"><asp:Label ID="lblbnkaccount" CssClass="lbl" runat="server" Text="Account No. : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlAccount" runat="server" AutoPostBack="True" CssClass="dropdownList" DataSourceID="odsaccountlist" 
        DataTextField="strAccountNo" DataValueField="intAccountID"></asp:DropDownList>
         <asp:ObjectDataSource ID="odsaccountlist" runat="server" SelectMethod="GetBankAccountBy" TypeName="BLL.Accounts.PartyPayment.PartyBill" OldValuesParameterFormatString="original_{0}">
             <SelectParameters>
                 <asp:ControlParameter ControlID="ddlBank" Name="bankID" PropertyName="SelectedValue" Type="String" />
                 <asp:ControlParameter ControlID="ddlUnit" Name="unitID" PropertyName="SelectedValue" Type="String" />
             </SelectParameters>
         </asp:ObjectDataSource>
        </td>
        </tr>

         <tr><td colspan="2" style="font-size:11px;"><asp:HiddenField ID="hdnprinted" runat="server" /> 
         <asp:RadioButtonList ID="rdoprintstatus" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdoprintstatus_SelectedIndexChanged" >
         <asp:ListItem Selected="True" Value="False">Not Printed</asp:ListItem><asp:ListItem Value="True">Printed</asp:ListItem></asp:RadioButtonList> 
         </td>
         <td colspan="2" style="font-size:11px; text-align:right"><asp:HiddenField ID="hdnaccountpay" runat="server" /> 
         <asp:CheckBox ID="chkAccountpay" runat="server" Text="Account Pay" AutoPostBack="true" OnCheckedChanged="chkAccountpay_CheckedChanged"/>   
         <asp:CheckBox ID="chkAll" runat="server" Text="All Cheque" OnCheckedChanged="chkAll_CheckedChanged" AutoPostBack="true"/>
         <asp:Button ID="btnPrintAll" runat="server" font-size="11px" Text="Print All" OnClick="btnPrintAll_Click" OnClientClick = "Confirm()"/>
         </td>
         
         </tr>
        </table>
    </div>

    <asp:GridView ID="dgvAuthorizedPartyCheque" runat="server" AutoGenerateColumns="False" SkinID="sknGrid2" AllowPaging="True" PageSize="20" 
        Font-Size="11px" BackColor="White" DataSourceID="odsautorizedcheque">
        <Columns>    
          <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
          <EditItemTemplate><asp:CheckBox ID="chkbx" runat="server" /></EditItemTemplate>
          <ItemTemplate><asp:CheckBox ID="chkbx" runat="server" />
          <asp:HiddenField ID="hdnvoucherid" runat="server" Value='<%# Eval("intBankVoucherID") %>' />
          </ItemTemplate>  <ItemStyle HorizontalAlign="Center" />
          </asp:TemplateField>    

          <asp:BoundField DataField="strCode" ItemStyle-HorizontalAlign="Center" HeaderText="Voucher Code" SortExpression="strCode">
          <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:BoundField>       

          <asp:BoundField DataField="strBankName" ItemStyle-HorizontalAlign="Center" HeaderText="Bank Name" SortExpression="strBankName">
          <ItemStyle HorizontalAlign="Left" Width="200px"/></asp:BoundField> 
            
          <asp:BoundField DataField="strAccountNo" ItemStyle-HorizontalAlign="Center" HeaderText="Account No" SortExpression="strAccountNo">
          <ItemStyle HorizontalAlign="Left" Width="150px"/></asp:BoundField>
              
          <asp:BoundField DataField="strUsedChequeNoList" ItemStyle-HorizontalAlign="Center" HeaderText="Cheque No" SortExpression="strUsedChequeNoList">
          <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:BoundField>

          <asp:BoundField DataField="strPayToPrint" ItemStyle-HorizontalAlign="Center" HeaderText="Pay To" SortExpression="strPayToPrint">
          <ItemStyle HorizontalAlign="Left" Width="220px"/></asp:BoundField> 

          <asp:BoundField DataField="monAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Amount" SortExpression="monAmount" DataFormatString="{0:0,000.00}">
          <ItemStyle HorizontalAlign="Right"/></asp:BoundField>
          
          <asp:TemplateField HeaderText="Cheque Date" SortExpression="dteChequeDate">
          <ItemTemplate><asp:Label ID="chqdate" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetShortDateAtLocalDateFormat(Eval("dteChequeDate")) %>'></asp:Label>
          </ItemTemplate><ItemStyle HorizontalAlign="Right"/></asp:TemplateField>
              
          <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Action" >
          <ItemTemplate> <asp:Button ID="btnsign" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" CommandArgument='<%# Eval("intBankVoucherID") %>'
          Text="Print" OnClick="Print_Click" OnClientClick = "Confirm()"/></ItemTemplate> <ItemStyle HorizontalAlign="Left" /></asp:TemplateField>
       </Columns>
    </asp:GridView>

    <asp:ObjectDataSource ID="odsautorizedcheque" runat="server" SelectMethod="GetAuthorizedPartyCheque" TypeName="BLL.Accounts.PartyPayment.PartyBill" OldValuesParameterFormatString="original_{0}">
    <SelectParameters>
    <asp:ControlParameter ControlID="ddlUnit" Name="unitid" PropertyName="SelectedValue" Type="Int32" />
    <asp:ControlParameter ControlID="hdngobycode" Name="vouchercode" PropertyName="Value" Type="String" />
    <asp:ControlParameter ControlID="ddlBank" Name="bankID" PropertyName="SelectedValue" Type="Int32" />
        <asp:ControlParameter ControlID="ddlAccount" Name="bankaccID" PropertyName="SelectedValue" Type="Int32" />
    <asp:ControlParameter ControlID="hdnprinted" Name="printed" PropertyName="Value" Type="Boolean" />
    </SelectParameters>
    </asp:ObjectDataSource>


<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

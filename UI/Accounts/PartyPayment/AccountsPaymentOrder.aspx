<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountsPaymentOrder.aspx.cs" Inherits="UI.Accounts.PartyPayment.AccountsPaymentOrder" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.:: Management View ::.</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>  
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script>
        function Confirm() {
            document.getElementById("hdnAction").value = "0";
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            var remarks = document.forms["frmpaymentorder"]["txtRemarks"].value;
            if (remarks == null || remarks == "") {
                alert("Must be filled by valid remarks.");
            }
            else {                
                if (confirm("Do you want to proceed?"))
                { confirm_value.value = "Yes"; document.getElementById("hdnAction").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnAction").value = "0"; }
            }
        }
        function ShowBillVatPOMRR(intbillid, intpoid, intshipmentid, vwtype) {
            window.open('Previewall.aspx?BILLID=' + intbillid + '&POID=' + intpoid + '&SHPID=' + intshipmentid + '&VTP=' + vwtype, '', "height=auto, width=auto, scrollbars=yes, left=250, top=100, resizable=yes, title=Preview");
        }
    </script>
</head>
<body>
    <form id="frmpaymentorder" runat="server">
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
    <div class="tabs_container">View Payment Order :<hr /><asp:HiddenField ID="hdnAction" runat="server" /></div>
    <table border="0px"; align="center" >
     <tr>
        <td><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit-Name : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" CssClass="dropdownList" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged" OnDataBound="ddlUnit_DataBound" DataSourceID="odsunit" DataTextField="strUnit" DataValueField="intUnitID"></asp:DropDownList>
            <asp:ObjectDataSource ID="odsunit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
            <SelectParameters><asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String" /></SelectParameters>
            </asp:ObjectDataSource>
        </td>
        <td colspan="2"><asp:HiddenField ID="hdntype" runat="server" />
        <asp:RadioButtonList ID="rdoviewtype" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" CssClass="nextclick" OnSelectedIndexChanged="rdoviewtype_SelectedIndexChanged" >
        <asp:ListItem Selected="True" Value="CashCredit">Cash/Credit</asp:ListItem><asp:ListItem Value="Adjustment">Adjustment</asp:ListItem></asp:RadioButtonList>
        </td>
     </tr>
    
     <tr>
         <td><asp:Label ID="lblremarks" CssClass="lbl" runat="server" Text="Remarks :"></asp:Label></td>
         <td><asp:TextBox ID="txtRemarks" runat="server" CssClass="txtBox" TextMode="MultiLine"></asp:TextBox></td>
         <td><asp:CheckBox ID="chkAll" runat="server" Text="Select All" CssClass="nextclick" OnCheckedChanged="chkAll_CheckedChanged" AutoPostBack="true"/></td>
         <td><asp:Button ID="btnApproveAll" runat="server" CssClass="nextclick" Text="Approve All" OnClick="btnApproveAll_Click" OnClientClick = "Confirm()"/>
         <asp:Button ID="btnRejectAll" runat="server" CssClass="nextclick" Text="Reject All" OnClick="btnRejectAll_Click" OnClientClick = "Confirm()"/>
         </td>
     </tr>
    </table>
    </div>
      <asp:GridView ID="dgvPaymentOrder" runat="server" AutoGenerateColumns="False" SkinID="sknGrid2" AllowPaging="True" PageSize="20" 
        Font-Size="10px" ShowFooter="True" OnRowDataBound="dgvPaymentOrder_OnRowDataBound" BackColor="White" DataSourceID="odspaymentorderlist">
        <Columns>    
          <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="Center">
          <EditItemTemplate><asp:CheckBox ID="chkbx" runat="server" /></EditItemTemplate>
          <ItemTemplate><asp:CheckBox ID="chkbx" runat="server" /><asp:HiddenField ID="hdnbillno" runat="server" Value='<%# Eval("intBillID") %>'/>
          </ItemTemplate>  <ItemStyle HorizontalAlign="Center" /></asp:TemplateField>           

          <%--<asp:BoundField DataField="strSupplierName" ItemStyle-HorizontalAlign="Center" HeaderText="Party Name" SortExpression="strSupplierName">
          <ItemStyle HorizontalAlign="Left" Width="450px"/></asp:BoundField> 
          <asp:BoundField DataField="monAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Amount" SortExpression="monAmount" DataFormatString="{0:0,000.00}">
          <ItemStyle HorizontalAlign="Right" Width="100px"/></asp:BoundField>
          <asp:BoundField DataField="monTotalAdvance" ItemStyle-HorizontalAlign="Center" HeaderText="Advance" SortExpression="monTotalAdvance" DataFormatString="{0:0,000.00}">
          <ItemStyle HorizontalAlign="Right" Width="100px"/></asp:BoundField>
          <asp:BoundField DataField="monThisbill" ItemStyle-HorizontalAlign="Center" HeaderText="ThisBill" SortExpression="monThisbill" DataFormatString="{0:0,000.00}">
          <ItemStyle HorizontalAlign="Right" Width="100px"/></asp:BoundField>--%>
          
          <asp:TemplateField HeaderText="Pay To">
          <ItemTemplate><asp:Label ID="lblSupplier" runat="server" Text='<%# Eval("strSupplierName") %>'></asp:Label></ItemTemplate>
          <ItemStyle HorizontalAlign="Left" Width="350px"/><FooterTemplate><asp:Label ID="totalLabel" runat="server" Text="Total : "></asp:Label>
          </FooterTemplate><FooterStyle HorizontalAlign="Right" Font-Size="12px" ForeColor="Red" /></asp:TemplateField>
          
          <asp:TemplateField HeaderText="Amount">
          <ItemTemplate><asp:Label ID="lblAmount" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetFormettingNumber(Math.Abs(double.Parse(""+Eval("monAmount")))) %>'></asp:Label></ItemTemplate>
          <ItemStyle HorizontalAlign="Right" Width="100px"/>
          <FooterTemplate><asp:Label ID="grdTotalLabel" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetFormettingNumber(Math.Abs(grdTotal)) %>'></asp:Label></FooterTemplate>
          <FooterStyle HorizontalAlign="Right" Font-Size="12px" ForeColor="Red" />
          </asp:TemplateField>

          <asp:TemplateField HeaderText="Advance">
          <ItemTemplate><asp:Label ID="lblAdvance" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetFormettingNumber(Math.Abs(double.Parse(""+Eval("monTotalAdvance")))) %>'></asp:Label></ItemTemplate>
          <ItemStyle HorizontalAlign="Right" Width="100px"/>
          <FooterTemplate><asp:Label ID="grdTotalAdvance" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetFormettingNumber(Math.Abs(grdAdvance)) %>'></asp:Label></FooterTemplate>
          <FooterStyle HorizontalAlign="Right" Font-Size="12px" ForeColor="Red" />
          </asp:TemplateField>
                  
          <asp:TemplateField HeaderText="ThisBill">
          <ItemTemplate><asp:Label ID="lblThisbill" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetFormettingNumber(Math.Abs(double.Parse(""+Eval("monThisbill")))) %>'></asp:Label></ItemTemplate>
          <ItemStyle HorizontalAlign="Right" Width="100px"/>
          <FooterTemplate><asp:Label ID="grdTotalThisbill" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetFormettingNumber(Math.Abs(grdThisbill)) %>'></asp:Label></FooterTemplate>
          <FooterStyle HorizontalAlign="Right" Font-Size="12px" ForeColor="Red" />
          </asp:TemplateField>

          <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Bill" >
          <ItemTemplate> <input id="btnShowBill" type="button" class="nextclick" style="cursor:pointer; font-size:10px;" value="Preview" onclick="<%# GetJSShowBillADJUSTMENTVATPOMRR(Eval("intBillID"), Eval("intPOID"), Eval("intShipmentID"), "Bill") %>" />
          </ItemTemplate> <ItemStyle HorizontalAlign="Left" /></asp:TemplateField> 
          <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Adjust" >
          <ItemTemplate> <input id="btnShowAdjust" type="button" class="nextclick" style="cursor:pointer; font-size:10px;" value="Preview" onclick="<%# GetJSShowBillADJUSTMENTVATPOMRR(Eval("intBillID"), Eval("intPOID"), Eval("intShipmentID"), "Adjust") %>" />
          </ItemTemplate> <ItemStyle HorizontalAlign="Left" /></asp:TemplateField> 
          <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="PO" >
          <ItemTemplate> <input id="btnShowPO" type="button" class="nextclick" style="cursor:pointer; font-size:10px;" value="Preview" onclick="<%# GetJSShowBillADJUSTMENTVATPOMRR(Eval("intBillID"), Eval("intPOID"), Eval("intShipmentID"), "Po") %>" />
          </ItemTemplate> <ItemStyle HorizontalAlign="Left" /></asp:TemplateField>         
          <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="VAT" >
          <ItemTemplate> <input id="btnShowVat" type="button" class="nextclick" style="cursor:pointer; font-size:10px;" value="Preview" onclick="<%# GetJSShowBillADJUSTMENTVATPOMRR(Eval("intBillID"), Eval("intPOID"), Eval("intShipmentID"), "Vat") %>" />
          </ItemTemplate> <ItemStyle HorizontalAlign="Left" /></asp:TemplateField> 
          <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="MRR" >
          <ItemTemplate> <input id="btnShowMRR" type="button" class="nextclick" style="cursor:pointer; font-size:10px;" value="Preview" onclick="<%# GetJSShowBillADJUSTMENTVATPOMRR(  Eval("intBillID"), Eval("intPOID"), Eval("intShipmentID"), "Mrr") %>" />
          </ItemTemplate> <ItemStyle HorizontalAlign="Left" /></asp:TemplateField>   
         
          <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Approve" >
          <ItemTemplate> <asp:Button ID="btnApprove" runat="server" class="nextclick" style="cursor:pointer; font-size:10px;" CommandArgument='<%# Eval("intBillID") %>'
          Text="Clickme" OnClick="Approve_Click" OnClientClick = "Confirm()"/></ItemTemplate> <ItemStyle HorizontalAlign="Left" /></asp:TemplateField>
          <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Reject" >
          <ItemTemplate> <asp:Button ID="btnReject" runat="server" class="nextclick" style="cursor:pointer; font-size:10px;" CommandArgument='<%# Eval("intBillID") %>'
          Text="Clickme" OnClick="Reject_Click" OnClientClick = "Confirm()"/></ItemTemplate> <ItemStyle HorizontalAlign="Left" /></asp:TemplateField>
      </Columns>
      </asp:GridView>            
      <asp:ObjectDataSource ID="odspaymentorderlist" runat="server" SelectMethod="GetPaymentOrderList" TypeName="BLL.Accounts.PartyPayment.PartyBill">
      <SelectParameters><asp:ControlParameter ControlID="ddlUnit" Name="unitid" PropertyName="SelectedValue" Type="Int32" />
      <asp:ControlParameter ControlID="hdntype" Name="viewtype" PropertyName="Value" Type="String" /></SelectParameters></asp:ObjectDataSource>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

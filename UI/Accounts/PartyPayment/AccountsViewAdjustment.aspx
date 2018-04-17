<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountsViewAdjustment.aspx.cs" Inherits="UI.Accounts.PartyPayment.AccountsViewAdjustment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.:: Accounts View ::.</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>  
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script>
        function Confirm() {
            document.getElementById("hdnconfirm").value = "0";
            var txtbox = document.forms["frmadjustment"]["txtChkNo"].value;
            var chequedate = document.forms["frmadjustment"]["dteCheque"].value;
            var actualpaydate = document.forms["frmadjustment"]["dteActualPay"].value;

            if (txtbox == null || txtbox == "") { 
                alert("Must be filled by valid paytype.");
            }
            else if (chequedate == null || chequedate == "") { 
                alert("Cheque date must be filled by valid formate (year-month-day).");
            }
            else if (actualpaydate == null || actualpaydate == "") { 
                alert("Actualpay date date must be filled by valid formate (year-month-day).");
            }
            else {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
            }
        }
        function ShowBillVatPOMRR(intbillid, intpoid, intshipmentid, vwtype) {
            window.open('Previewall.aspx?BILLID=' + intbillid + '&POID=' + intpoid + '&SHPID=' + intshipmentid + '&VTP=' + vwtype, '', "height=auto, width=auto, scrollbars=yes, left=250, top=100, resizable=yes, title=Preview");
        }
        $(document).ready(function () {
            $("[id*=txtExpense]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "AutoComplete.asmx/GetWithoutExpenceList",
                        data: "{ 'strSearchKey': '" + request.term + "','struserid': '" + document.getElementById('hdnuserid').value + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id*=hfaccId]", $(e.target).closest("td")).val(i.item.val);
                },
                minLength: 1
            });
        });

    </script>
</head>
<body>
    <form id="frmadjustment" runat="server">
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
<%--=========================================Start My Code From Here=======================================AllowPaging="True" PageSize="20"========--%>

    <div class="tabs_container">View Adjustment Bill :<hr /><asp:HiddenField ID="hdnuserid" runat="server"/><asp:HiddenField ID="hdnconfirm" runat="server"/></div>
        <asp:GridView ID="dgvViewBill" runat="server" AutoGenerateColumns="False" SkinID="sknGrid2" Font-Size="11px" OnRowDataBound="dgvViewBill_OnRowDataBound" BackColor="White" DataSourceID="odsloadgrid" ShowFooter="True">
                <Columns>    
                  <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                  <EditItemTemplate><asp:CheckBox ID="chkbx" runat="server" /></EditItemTemplate>
                  <ItemTemplate><asp:CheckBox ID="chkbx" runat="server" />
                  <asp:HiddenField ID="hdnsupname" runat="server" Value='<%# Eval("strSupplierName") %>' />
                  <asp:HiddenField ID="hdnbillno" runat="server" Value='<%# Eval("intBillID") %>'/>
                  <asp:HiddenField ID="hdnreff" runat="server" Value='<%# Eval("strOtherReff") %>'/>
                  <asp:HiddenField ID="hdnpoid" runat="server" Value='<%# Eval("intPOID") %>' />
                  <asp:HiddenField ID="hdnshipmentid" runat="server" Value='<%# Eval("intShipmentID") %>' />
                  <asp:HiddenField ID="hdnamount" runat="server" Value='<%# Eval("monAmount") %>' />
                  <asp:HiddenField ID="hdntotaladjusment" runat="server" Value='<%# Eval("monTotalAdvance") %>' />
                  <asp:HiddenField ID="hdnthisbill" runat="server" Value='<%# Eval("monThisbill") %>' />
                  <asp:HiddenField ID="hdnunit" runat="server" Value='<%# Eval("intUnitID") %>' />
                  </ItemTemplate><ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField> 

                  <asp:TemplateField  HeaderText="Party Head" ItemStyle-HorizontalAlign="Center"> 
                  <ItemTemplate><asp:TextBox ID="txtExpense" runat="server" CssClass="txtBox" ></asp:TextBox> 
                  <asp:HiddenField ID="hfaccId" runat="server"/></ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                  <%--<asp:BoundField DataField="strSupplierName" ItemStyle-HorizontalAlign="Center" HeaderText="Pay To" SortExpression="strSupplierName">
                  <ItemStyle HorizontalAlign="Left" Width="350px"/></asp:BoundField> 
                  <asp:BoundField DataField="monAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Amount" SortExpression="monAmount" DataFormatString="{0:0,000.00}">
                  <ItemStyle HorizontalAlign="Right" Width="100px"/></asp:BoundField>
                  <asp:BoundField DataField="monTotalAdvance" ItemStyle-HorizontalAlign="Center" HeaderText="Advance" SortExpression="monTotalAdvance" DataFormatString="{0:0,000.00}">
                  <ItemStyle HorizontalAlign="Right" Width="100px"/></asp:BoundField>
                  <asp:BoundField DataField="monThisbill" ItemStyle-HorizontalAlign="Center" HeaderText="ThisBill" SortExpression="monThisbill" DataFormatString="{0:0,000.00}">
                  <ItemStyle HorizontalAlign="Right" Width="100px"/></asp:BoundField>--%>
                   
                  <asp:TemplateField HeaderText="Pay To">
                  <ItemTemplate><asp:Label ID="lblSupplier" runat="server" Text='<%# Eval("strSupplierName") %>'></asp:Label></ItemTemplate>
                  <ItemStyle HorizontalAlign="Left" Width="350px"/>
                  <FooterTemplate><asp:Label ID="totalLabel" runat="server" Text="Total : "></asp:Label></FooterTemplate>
                  <FooterStyle HorizontalAlign="Right" Font-Size="12px" ForeColor="Red" />
                  </asp:TemplateField>

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

                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Bill/Vat" >
                  <ItemTemplate> <input id="btnShowAdjust" type="button" class="nextclick" style="cursor:pointer" value="Preview" onclick="<%# GetJSShowBillVATPOMRR(  Eval("intBillID"), Eval("intPOID"), Eval("intShipmentID"), "Adjust") %>" />
                  </ItemTemplate> <ItemStyle HorizontalAlign="Left" /></asp:TemplateField>   
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="PO" >
                  <ItemTemplate> <input id="btnShowPO" type="button" class="nextclick" style="cursor:pointer" value="Preview" onclick="<%# GetJSShowBillVATPOMRR(  Eval("intBillID"), Eval("intPOID"), Eval("intShipmentID"), "Po") %>" />
                  </ItemTemplate> <ItemStyle HorizontalAlign="Left" /></asp:TemplateField> 
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="MRR" >
                  <ItemTemplate> <input id="btnShowMRR" type="button" class="nextclick" style="cursor:pointer" value="Preview" onclick="<%# GetJSShowBillVATPOMRR(  Eval("intBillID"), Eval("intPOID"), Eval("intShipmentID"), "Mrr") %>" />
                  </ItemTemplate> <ItemStyle HorizontalAlign="Left" /></asp:TemplateField>   

              </Columns>
              </asp:GridView>             
        <asp:ObjectDataSource ID="odsloadgrid" runat="server" SelectMethod="GetPartyAdjustmentBill" TypeName="BLL.Accounts.PartyPayment.PartyBill">
            <SelectParameters><asp:SessionParameter Name="userid" SessionField="sesUserID" Type="Int32" /></SelectParameters>
            </asp:ObjectDataSource>

    <div class="divs_content_container">        
    <table border="0" style="text-align:justify;">
     <tr><td style="text-align:left;">
     <asp:Button ID="btnSelectAll" runat="server" Visible="false" class="nextclick" style="font-size:11px;" Text="" OnClick="btnSelectAll_Click"/></td></tr>

     <tr>        
     <td style="text-align:right;"><asp:Label ID="lblbanklist" CssClass="lbl" runat="server" Text="BankList : "></asp:Label></td>
     <td><asp:DropDownList ID="ddlBank" runat="server" AutoPostBack="true" CssClass="dropdownList" DataSourceID="odsBank"
     DataTextField="strBankName" DataValueField="intBankID" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged" OnDataBound="ddlBank_DataBound" ></asp:DropDownList>
     <asp:ObjectDataSource ID="odsBank" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetActiveForDDL" 
     TypeName="BLL.Accounts.Bank.BankInfo"></asp:ObjectDataSource></td>
     <td style="text-align:right;"><asp:Label ID="lblbnkaccount" CssClass="lbl" runat="server" Text="Account No. : "></asp:Label></td>
     <td><asp:DropDownList ID="ddlAccount" runat="server" AutoPostBack="True" CssClass="dropdownList" OnDataBound="ddlAccount_DataBound" 
         OnSelectedIndexChanged="ddlAccount_SelectedIndexChanged" DataSourceID="odsaccountlist" DataTextField="strAccountNo" DataValueField="intAccountID"></asp:DropDownList>
         <asp:ObjectDataSource ID="odsaccountlist" runat="server" SelectMethod="GetBankAccount" TypeName="BLL.Accounts.PartyPayment.PartyBill" OldValuesParameterFormatString="original_{0}">
             <SelectParameters>
                 <asp:ControlParameter ControlID="ddlBank" Name="bankID" PropertyName="SelectedValue" Type="String" />
                 <asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String" />
             </SelectParameters>
         </asp:ObjectDataSource>
     </td>
         
     </tr>
        
     <tr>      
            <td style="text-align:right;"><asp:Label ID="lblpaytype" CssClass="lbl" runat="server" Text="Type : "></asp:Label></td>
            <td ><asp:DropDownList ID="ddlPaytype" runat="server" AutoPostBack="true" CssClass="dropdownList" OnDataBound="ddlPaytype_DataBound" 
            OnSelectedIndexChanged="ddlPaytype_SelectedIndexChanged">
            <asp:ListItem Selected="True" Value="1">Cheque</asp:ListItem> <asp:ListItem Value="2">Advice</asp:ListItem>
            <asp:ListItem Value="3">Online</asp:ListItem></asp:DropDownList>
            </td> 
            <td style="text-align:right;"><asp:Label ID="lblcurchk" CssClass="lbl" runat="server" Text="ChequeNo : "></asp:Label></td>
            <td><asp:TextBox ID="txtChkNo" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
            </tr>

     <tr>
            <td style="text-align:right;"><asp:Label ID="lblchkdte" CssClass="lbl" runat="server" Text="Cheq. Date : "></asp:Label></td>
            <td><asp:TextBox ID="dteCheque" runat="server" CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="chequedate" runat="server" Format="yyyy-MM-dd" TargetControlID="dteCheque"></cc1:CalendarExtender>  
            </td>
            <td style="text-align:right;"><asp:Label ID="lblactpaydte" CssClass="lbl" runat="server" Text="ActualPay-Date : "></asp:Label></td>
            <td><asp:TextBox ID="dteActualPay" runat="server" CssClass="txtBox"></asp:TextBox> 
            <cc1:CalendarExtender ID="actualpaydate" runat="server" Format="yyyy-MM-dd" TargetControlID="dteActualPay"></cc1:CalendarExtender>                                                     
            </td>
            </tr>

     <tr>
            <td style="text-align:right;" colspan="4">
            <asp:Button ID="btnSubmit" runat="server" class="nextclick" style="font-size:11px;" Text="Submit" OnClick="btnSubmit_Click"  OnClientClick = "Confirm()"/>        
            <asp:HiddenField ID="hdnbnkid" runat="server" /><asp:HiddenField ID="hdnbnkaccid" runat="server" /><asp:HiddenField ID="hdnchequeno" runat="server" />
            </td>
            </tr>
     </table>
</div>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

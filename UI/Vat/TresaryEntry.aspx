<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TresaryEntry.aspx.cs" Inherits="UI.Vat.TresaryEntry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.:: Treasury Entry ::.</title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>  
<webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <style>
        .completeDiv
        {
            display:none;
            width:620px;
            background-color:#f0f0ff;
	        border: 3px outset #00367B;
            position:absolute;
            z-index:1;
	        left:1px;
	        top: 230px;
        }
    </style>

    <script>
        function Confirm() {
            document.getElementById("hdnconfirm").value = "0";
            var monAmount = document.forms["frmtresaryentry"]["monAmount"].value;

            if (monAmount == null || monAmount == "" || isNaN(monAmount)) {
                alert("Amount must be filled by numeric value.");
            }
            else {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
            }
        }
        function ConfirmComplete() {
            document.getElementById("hdnconfirmcomplete").value = "0";
            var txtChallanno = document.forms["frmtresaryentry"]["txtChallanno"].value;
            var txtChallanDate = document.forms["frmtresaryentry"]["txtChallanDate"].value;
            var txtInstrumentno = document.forms["frmtresaryentry"]["txtInstrumentno"].value;
            var txtInstrumentDate = document.forms["frmtresaryentry"]["txtInstrumentDate"].value;

            if (txtChallanno == null || txtChallanno == "") {
                alert("Challanno must be filled by valid value.");
            }
            else if (txtChallanDate == null || txtChallanDate == "") {
                alert("Challan date must be filled by valid formate (year-month-day).");
            }
            else if (txtInstrumentno == null || txtInstrumentno == "") {
                alert("Instrumentno must be filled by valid value.");
            }
            else if (txtInstrumentDate == null || txtInstrumentDate == "") {
                alert("Instrument date must be filled by valid formate (year-month-day).");
            }
            else {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirmcomplete").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnconfirmcomplete").value = "0";}
            }
        }

        function PrintTreasury(autoid, vtacc) {
            var url = 'PrintTreasury.aspx?VTACC=' + vtacc + '&AUTOID=' + autoid;
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,top=50,left=200');
            if (window.focus) { newwindow.focus() }
        }

        function CompleteTreasury() {
            document.getElementById("complete").style.display = "block";
        }

        function HideCompleteDiv() {
            document.getElementById("txtChallanno").innerText = "";
            document.getElementById("txtChallanDate").innerText = "";
            document.getElementById("hdnconfirmcomplete").value = "";
            document.getElementById("hdndepositidForcomplete").value = "";
            document.getElementById("txtInstrumentno").innerText = "";
            document.getElementById("txtInstrumentDate").innerText = "";
            document.getElementById("complete").style.display = "none";

        }
    </script>
</head>
<body>
    <form id="frmtresaryentry" runat="server">
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
    <div class="tabs_container">Treasury Entry: <asp:HiddenField ID="hdnvtacc" runat="server" /> 
    <asp:HiddenField ID="hdnconfirm" runat="server" /><hr /></div>
    <table>
        <tr>
        <td style="text-align:right;"><asp:Label ID="lblproduct" runat="server" CssClass="lbl" Text="Treasury Deposit : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlTreasurylist" runat="server" AutoPostBack="True" CssClass="dropdownList" DataSourceID="odstreasurydepositlist"
        DataTextField="strTreasuryDepositDescription" DataValueField="intTreasuryDepositID"></asp:DropDownList>
        <asp:ObjectDataSource ID="odstreasurydepositlist" runat="server" SelectMethod="GetTreasuryDepositList" TypeName="BLL.Accounts.PartyPayment.PartyBill"></asp:ObjectDataSource>
        </td>
        <td style="text-align:right;"><asp:Label ID="lblquantity" CssClass="lbl" runat="server" Text="Amount : "></asp:Label></td>
        <td><asp:TextBox ID="monAmount" runat="server" CssClass="txtBox" TextMode="Number" Enabled="true"></asp:TextBox></td>
        </tr>

        <tr>
       <td style="text-align:right;"><asp:Label ID="lblvatacc" CssClass="lbl" runat="server" Text="Vat-Account : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlVatAcc" runat="server" AutoPostBack="True" CssClass="dropdownList" DataTextField="strVatAccountName" DataValueField="intVatAccountID"
        DataSourceID="odsvatacc" OnSelectedIndexChanged="ddlVatAcc_SelectedIndexChanged"></asp:DropDownList>
        <asp:ObjectDataSource ID="odsvatacc" runat="server" SelectMethod="GetVatAccountList" TypeName="BLL.Accounts.PartyPayment.PartyBill">
        <SelectParameters><asp:SessionParameter Name="userid" SessionField="sesUserID" Type="Int32" />
        <asp:SessionParameter Name="unitid" SessionField="sesUnit" Type="Int32" /></SelectParameters></asp:ObjectDataSource>        
        </td>
        <td colspan="2" style="font-size:11px;"><asp:HiddenField ID="hdncompleteded" runat="server" />
         <asp:RadioButtonList ID="rdocompletestatus" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdocompletestatus_SelectedIndexChanged">
         <asp:ListItem Selected="True" Value="false">Not Completed</asp:ListItem><asp:ListItem Value="true">Completed</asp:ListItem></asp:RadioButtonList> 
         </td></tr>
        <tr>
        <td style="text-align:right;" colspan="4">
        <asp:Button ID="btnSubmit" runat="server" class="nextclick" style="font-size:11px;" Text="Submit" OnClientClick="Confirm()" OnClick="btnSubmit_Click"/>
        </td></tr> 
    
    </table>
    </div>


        <asp:GridView ID="dgvViewtreasury" runat="server" AutoGenerateColumns="False" SkinID="sknGrid2" Font-Size="11px" BackColor="White" DataSourceID="odsviewtreasury">
        <Columns>
        <asp:TemplateField HeaderText="" Visible="false"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lbl0" runat="server" Text='<%# Bind("intAutoID") %>'></asp:Label>
        </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Deposit Description"><ItemStyle HorizontalAlign="Left" Width="205px"/>
        <ItemTemplate><asp:Label ID="lbl1" runat="server" Text='<%# Bind("strTreasuryDepositDescription") %>'></asp:Label></ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Challan No"><ItemStyle HorizontalAlign="Left" Width="135px"/>
        <ItemTemplate><asp:Label ID="lbl2" runat="server" Text='<%# Bind("strTrChallanNo") %>'></asp:Label></ItemTemplate>   
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Instument No"><ItemStyle HorizontalAlign="Left" Width="115px"/>
        <ItemTemplate><asp:Label ID="lbl3" runat="server" Text='<%# Bind("strInstumentNo") %>'></asp:Label></ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Amount"><ItemStyle HorizontalAlign="Right" Width="75px"/>
        <ItemTemplate><asp:Label ID="lbl4" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetFormettingNumber(Math.Abs(double.Parse(""+Eval("monAmount"))))  %>'></asp:Label></ItemTemplate>   
        </asp:TemplateField>

        <asp:BoundField DataField="dtePrepareDate" HeaderText="Prepared Date" ItemStyle-HorizontalAlign="Center" SortExpression="dtePrepareDate" DataFormatString="{0:yyyy-MM-dd}">
        <ItemStyle HorizontalAlign="Left"/></asp:BoundField>
        <asp:BoundField DataField="dteCompleteDate" HeaderText="Complete Date" ItemStyle-HorizontalAlign="Center" SortExpression="dteCompleteDate" DataFormatString="{0:yyyy-MM-dd}">
        <ItemStyle HorizontalAlign="Left"/></asp:BoundField>

        <%--<asp:TemplateField HeaderText="Prepared Date"><ItemStyle HorizontalAlign="Right" Width="90px"/>
        <ItemTemplate><asp:Label ID="lbl5" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetShortDateAtLocalDateFormat(Eval("dtePrepareDate"))%>'></asp:Label></ItemTemplate>   
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Complete Date"><ItemStyle HorizontalAlign="Right" Width="90px"/>
        <ItemTemplate><asp:Label ID="lbl6" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetShortDateAtLocalDateFormat(Eval("dteCompleteDate")) %>'></asp:Label></ItemTemplate>   
        </asp:TemplateField>--%>

        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Print" >
        <ItemTemplate> 
        <asp:Button ID="btnPrint" runat="server" class="nextclick" style="cursor:pointer; font-size:10px;" CommandArgument='<%# Eval("intAutoID") %>'
        Text="Print" OnClick="btnPrint_Click"/>
        </ItemTemplate> <ItemStyle HorizontalAlign="Left" /></asp:TemplateField> 
        
        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Complete" >
        <ItemTemplate> <asp:Button ID="btnCompleteTreasury" runat="server" class="nextclick" style="cursor:pointer; font-size:10px;" CommandArgument='<%# Eval("intAutoID") %>'
        Text="Complete" OnClick="CompleteCompleteTreasury_Click"/></ItemTemplate> <ItemStyle HorizontalAlign="Left" /></asp:TemplateField> 
        

        </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="odsviewtreasury" runat="server" SelectMethod="GetTreasuryDepositInformation" TypeName="BLL.Accounts.PartyPayment.PartyBill" OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
        <asp:ControlParameter ControlID="ddlVatAcc" Name="vatacc" PropertyName="SelectedValue" Type="Int32" />
        <asp:ControlParameter ControlID="hdncompleteded" Name="ysnComplete" PropertyName="Value" Type="Boolean" />
        </SelectParameters>
        </asp:ObjectDataSource>

    <div id="complete" class="completeDiv">
        <table>
        <tr>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Challan No : "></asp:Label></td>
        <td><asp:TextBox ID="txtChallanno" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="lbldate" CssClass="lbl" runat="server" Text="Challan Date : "></asp:Label></td>
        <td><asp:TextBox ID="txtChallanDate" runat="server" CssClass="txtBox"></asp:TextBox>
        <cc1:CalendarExtender ID="CEA" runat="server" Format="yyyy-MM-dd" TargetControlID="txtChallanDate"></cc1:CalendarExtender></td>
        </tr>

        <tr>
        <td style="text-align:right;"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Instrument No : "></asp:Label></td>
        <td><asp:TextBox ID="txtInstrumentno" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Instrument Date : "></asp:Label></td>
        <td><asp:TextBox ID="txtInstrumentDate" runat="server" CssClass="txtBox"></asp:TextBox>
        <cc1:CalendarExtender ID="CEI" runat="server" Format="yyyy-MM-dd" TargetControlID="txtInstrumentDate"></cc1:CalendarExtender></td>
        </tr>
        
        <tr><td style="text-align:right;" colspan="4"><asp:HiddenField ID="hdnconfirmcomplete" runat="server" /><asp:HiddenField ID="hdndepositidForcomplete" runat="server" />
        <asp:Button ID="btnComplete" runat="server" class="nextclick" style="font-size:11px;" Text="Complete-Deposit" OnClientClick="ConfirmComplete()" OnClick="btnComplete_Click"/>
        <asp:Button ID="btnCancel" runat="server" class="nextclick" style="font-size:11px;" Text="Cancel" OnClick="btnCancel_Click"/>
        </td></tr> 
    
    </table>
    </div>
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

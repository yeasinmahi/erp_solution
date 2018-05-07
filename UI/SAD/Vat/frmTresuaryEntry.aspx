<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmTresuaryEntry.aspx.cs" Inherits="UI.SAD.Vat.frmTresuaryEntry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head runat="server"><title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />  
    <script>
        function ValidationBasicInfo() {
            document.getElementById("hdnconfirm").value = "0";
            var ChallanNo = document.forms["frmPurchase"]["txtChallanNo"].value;
            var Amount = document.forms["frmPurchase"]["txtAmount"].value;
          
            var Instrument = document.forms["frmPurchase"]["txtInstrument"].value;
            var ChallanDate = document.forms["frmPurchase"]["txtChallandate"].value;
            var Depositdate = document.forms["frmPurchase"]["txtDepositdate"].value;
           var Installmentdate = document.forms["frmPurchase"]["txtInstallmentdate"].value;

            if (ChallanNo == null || ChallanNo == "") {
                alert("Please Fill-Up Challan No !");
            }

            else if (Amount == null || Amount == "") {
                alert("Purchase Fill-up  Amount !");
            }
            else if (Instrument == null || Instrument == "") {
                alert("Please Fill-up  Instrument !");
            }

            else if (ChallanDate == null || ChallanDate == "") {
                alert("Please Fill-up Challan Date!");
            }

            else if (Installmentdate == null || Installmentdate == "") {
                alert("Please Fill-up Installment date!");
            }
          
            else {  document.getElementById("hdnconfirm").value = "1"; }
        }
    </script>
</head>
<body>
    <form id="frmPurchase" runat="server">
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>

<%--=========================================Start My Code From Here===============================================--%>
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnconfirm" runat="server" />
    <asp:HiddenField ID="hdnVatAccount" runat="server" /><asp:HiddenField ID="hdnVatRegNo" runat="server" />
    <asp:HiddenField ID="hdnAccno" runat="server" /> <asp:HiddenField ID="hdnysnFactory" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" />
    <div class="tabs_container"> TREASURY ENTRY <hr /></div>
    <table><tr><td>
    <table  class="tbldecoration" style="width:auto; float:left;">                              
     <tr><td>Deposit For</td>
        <td> <asp:DropDownList ID="ddlTCode" runat="server"> </asp:DropDownList> </td>
        <td>Amount</td>
        <td><asp:TextBox ID="txtAmount" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox> </td>
        <td>Deposit Date</td>
        <td><asp:TextBox ID="txtDepositdate" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtDepositdate" Format="dd/MM/yyyy" PopupButtonID="imgCal_12"
            ID="CalendarExtender2" runat="server" EnableViewState="true">
            </cc1:CalendarExtender>
            <img id="imgCal_12" src="../../Content/images/img/calbtn.gif" style="border: 0px;
            width: 34px; height: 23px; vertical-align: bottom;" /></td>
     </tr> 
     <tr><td>Challan No </td>
        <td><asp:TextBox ID="txtChallanNo" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>
        <td>Challan Date</td>
        <td><asp:TextBox ID="txtChallandate" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtChallandate" Format="dd/MM/yyyy" PopupButtonID="imgCal_1"
            ID="CalendarExtender1" runat="server" EnableViewState="true">
            </cc1:CalendarExtender>
            <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px;
            width: 34px; height: 23px; vertical-align: bottom;" /> </td>
            <td>Instrument No</td>
            <td><asp:TextBox ID="txtInstrument" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>
     </tr>
     <tr><td> Instrument Date</td>
            <td><asp:TextBox ID="txtInstallmentdate" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtInstallmentdate" Format="dd/MM/yyyy" PopupButtonID="imgCal_14"
            ID="CalendarExtender5" runat="server" EnableViewState="true">
            </cc1:CalendarExtender>
            <img id="imgCal_14" src="../../Content/images/img/calbtn.gif" style="border: 0px;
            width: 34px; height: 23px; vertical-align: bottom;" /></td>
            <td> <asp:Button ID="btnSave" runat="server" OnClientClick="ValidationBasicInfo()" OnClick="btnSave_Click" Text="Save" />  </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
     </tr>
     <tr><td colspan="6"><hr /></td></tr>                             
    </table>
    </td></tr>
    <tr><td>
    <table  class="tbldecoration" style="width:auto; float:left;"> 
    <tr><td colspan="5" class="auto-style1">TREASURY REPORT</td>  
    <tr><td>From Date</td>
        <td><asp:TextBox ID="txtfdate" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
        <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtfdate" Format="dd/MM/yyyy" PopupButtonID="imgCal_123"
        ID="CalendarExtender3" runat="server" EnableViewState="true">
        </cc1:CalendarExtender>
        <img id="imgCal_123" src="../../Content/images/img/calbtn.gif" style="border: 0px;
        width: 34px; height: 23px; vertical-align: bottom;" /></td><td>To Date</td>
        <td><asp:TextBox ID="txttdate" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
        <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txttdate" Format="dd/MM/yyyy" PopupButtonID="imgCal_2"
        ID="CalendarExtender4" runat="server" EnableViewState="true">
        </cc1:CalendarExtender>
        <img id="imgCal_2" src="../../Content/images/img/calbtn.gif" style="border: 0px;
        width: 34px; height: 23px; vertical-align: bottom;" /></td>
    </tr> 
    <tr><td>SHORT BY</td>
        <td><asp:DropDownList ID="ddlShorby" runat="server">
            <asp:ListItem Value="1">ALL</asp:ListItem>
            <asp:ListItem Value="2">SD</asp:ListItem>
            <asp:ListItem Value="3">VAT</asp:ListItem>
            <asp:ListItem Value="4">Sur Charge</asp:ListItem>
            </asp:DropDownList> </td>
        <td colspan="2" style="text-align:left"> <asp:Button ID="btnReport" runat="server" Text="Report" OnClick="btnReport_Click1" /></td>           
     </tr> 
    <tr><td colspan="5" style="text-align:right"></td>                                     
     <tr><td colspan="5"><hr /></td></tr> 
     <tr><td colspan="5">
        <asp:GridView ID="dgvTresuryRpt" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
        CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
        HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
        FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical"  OnRowDataBound="dgvTresuryRpt_RowDataBound"
        >
        <AlternatingRowStyle BackColor="#CCCCCC" />    
        <Columns>
        <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="40px" /><ItemTemplate>  <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
 
        <asp:TemplateField HeaderText="ID" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblId" runat="server" Text='<%# Bind("intAutoID") %>' Width="50px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Type" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblshort" runat="server" Text='<%# Bind("short") %>' Width="50px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Code" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblstrCode" runat="server" Text='<%# Bind("strCode") %>' Width="50px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Date" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lbldteCompleteDate" runat="server" Text='<%# Bind("dteCompleteDate") %>' Width="50px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="TrChallan" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblstrTrChallanNo" runat="server" Text='<%# Bind("strTrChallanNo") %>' Width="50px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Deposit Amount" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblmonAmount" runat="server" Text='<%# Bind("monAmount") %>' Width="50px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Delete"><ItemTemplate> 
        <asp:Button ID="btndelete" ForeColor="Red" runat="server" Text="Delete" CommandName="complete"  OnClick="btnDelete" Font-Bold="true" BackColor="#00ccff"  CommandArgument='<%# Eval("intAutoID")%>' />
        </ItemTemplate> </asp:TemplateField>

        </Columns>
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
        </td></tr>  
    </tr>             
    </table>
    </td></tr></table>
    </div>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

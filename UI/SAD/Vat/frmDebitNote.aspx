<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDebitNote.aspx.cs" Inherits="UI.SAD.Vat.frmDebitNote" %>
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
    <script type="text/javascript">
      $("[id*=lblsd]").live("keyup", function () {
          if (!jQuery.trim($(this).val()) == '') {

              if (!isNaN(parseFloat($(this).val()))) {
                  var row = $(this).closest("tr");
                  var m11 = parseFloat($("[id*=lblM11]", row).val());
                  var surCharge = parseFloat($("[id*=lblSurCharge]", row).val());
                  var sd = parseFloat($(this).val());
                
                   $("[id*=lblDecrateOthervat]", row).html((m11- sd-surCharge));
              }
          } else {
              $(this).val('');
          }
        });
         $("[id*=lblSurCharge]").live("keyup", function () {
          if (!jQuery.trim($(this).val()) == '') {

              if (!isNaN(parseFloat($(this).val()))) {
                  var row = $(this).closest("tr");
                  var sd = parseFloat($("[id*=lblsd]", row).val());
                  var m11 = parseFloat($("[id*=lblM11]", row).val());
                  var surCharge = parseFloat($(this).val());
              
                  $("[id*=lblDecrateOthervat]", row).html((m11- sd-surCharge));
              }
          } else {
              $(this).val('');
          }
        });
         $("[id*=lblvat]").live("keyup", function () {
          if (!jQuery.trim($(this).val()) == '') {

              if (!isNaN(parseFloat($(this).val()))) {
                  var row = $(this).closest("tr");
                  var m11 = parseFloat($("[id*=lblM11]", row).val());              
                  var vat = parseFloat($(this).val());               
                   $("[id*=Decratevat]", row).html((m11- vat));
              }
          } else {
              $(this).val('');
          }
        });
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnCustid" runat="server" /><asp:HiddenField ID="hdnconfirm" runat="server" />
    <asp:HiddenField ID="hdnVatAccount" runat="server" /><asp:HiddenField ID="hdnVatRegNo" runat="server" />
    <asp:HiddenField ID="hdnAccno" runat="server" /> <asp:HiddenField ID="hdnysnFactory" runat="server" />
    <asp:HiddenField ID="hdnEnroll" runat="server" /> <asp:HiddenField ID="hdnCustname" runat="server" /> <asp:HiddenField ID="hdnCustAddress" runat="server" />
    <div class="tabs_container"> DEBIT NOTE ENTRY <hr /></div>
    <table><tr><td>
    <table  class="tbldecoration" style="width:auto; float:left;">                              
     <tr><td>Material Name</td>
        <td><asp:TextBox ID="txtMatrialName" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" OnTextChanged="txtMatrialName_TextChanged" ></asp:TextBox>
        <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtMatrialName"
        ServiceMethod="ItemnameSearchMatrial" MinimumPrefixLength="1" CompletionSetCount="1"
        CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
        </cc1:AutoCompleteExtender> </td>
        <td>All Purchase</td>
        <td><asp:DropDownList ID="ddlAllPurchase" CssClass="ddList" runat="server" OnSelectedIndexChanged="ddlAllPurchase_SelectedIndexChanged"></asp:DropDownList> </td>
        <td>&nbsp;</td>
        <td>
            &nbsp;</td>
     </tr> 
     <tr><td>Supplier Vat Reg </td>
        <td><asp:TextBox ID="txtsuppVatReg" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>
        <td>Vehicle Type No</td>
        <td><asp:TextBox ID="txtVehicletypeno" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>
            <td>Debit Note No</td>
            <td><asp:Label ID="lblm12no" runat="server"></asp:Label></td>
     </tr>
     <tr><td> Debit Note Date</td>
            <td><asp:Label ID="lblm12date" runat="server"></asp:Label> </td>
            <td>   Reason</td>
            <td><asp:TextBox ID="txtReason" runat="server" CssClass="txtBox"  TextMode="MultiLine"  MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>
            <td><asp:Button ID="btnSave" runat="server" OnClientClick="ValidationBasicInfo()" OnClick="btnSave_Click" Text="Save Debit Note" /></td>
            <td>&nbsp;</td>
     </tr>
     <tr><td colspan="6"><hr /></td></tr>                             
    </table>
    </td></tr>
    <tr><td>
    <table  class="tbldecoration" style="width:auto; float:left;"> 
   
    <tr><td style="text-align:right"></td>                                     
     <tr><td><hr /></td></tr> 
     <tr><td>
        <asp:GridView ID="dgvVatProduct" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
        CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
        HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
        FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical"  OnRowDataBound="dgvTresuryRpt_RowDataBound"
        >
        <AlternatingRowStyle BackColor="#CCCCCC" />    
        <Columns>

        <asp:TemplateField HeaderText="Challan No" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblstrChallanNo" runat="server" Text='<%# Bind("strChallanNo") %>' Width="50px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Challan Date" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lbldtedate" runat="server" Text='<%# Bind("dteChallanDate") %>' Width="50px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Product Name" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblstrVatProductName" runat="server" Text='<%# Bind("strMaterialName") %>' Width="50px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Quantity" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("numQuantity") %>' Width="50px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>

         <asp:TemplateField HeaderText="Am. Without SD VAT" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblsdvat" runat="server" Text='<%# Bind("monAmountWithoutVATnSD") %>' Width="50px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="SD" SortExpression="sd">
        <ItemTemplate><asp:Label ID="lblsd" runat="server" Text='<%# Bind("monSD") %>' Width="50px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="SurCharge" SortExpression="SurCharge">
        <ItemTemplate><asp:Label ID="lblSurCharge" runat="server" Text='<%# Bind("monVAT") %>' Width="50px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>

         <asp:TemplateField HeaderText="Decrease Quantity" SortExpression="Decrea Quantity">
        <ItemTemplate><asp:TextBox ID="txtDQ" runat="server" Text='<%# Bind("DQ") %>' Width="50px"></asp:TextBox>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Decrease SD" SortExpression="VAT">
        <ItemTemplate><asp:TextBox ID="lblDSD" runat="server" Text='<%# Bind("DSD") %>' Width="50px"></asp:TextBox>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Decrease VAT" SortExpression="VAT">
        <ItemTemplate><asp:TextBox ID="lblDVAT" runat="server" Text='<%# Bind("DVAT") %>' Width="50px"></asp:TextBox>
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

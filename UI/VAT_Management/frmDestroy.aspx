<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDestroy.aspx.cs" Inherits="UI.VAT_Management.frmDestroy" %>
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
     <link href="../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../Content/JS/datepickr.min.js"></script>
    <script src="../Content/JS/JSSettlement.js"></script>   
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />
    
    <script>
        function ValidationBasicInfo() {
            document.getElementById("hdnconfirm").value = "0";
            var txtCreditqty = document.forms["frmPurchase"]["txtCreditqty"].value;
           
            if (txtCreditqty == null || txtCreditqty == "") {
                alert("Please Entry Qty !");
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
    <asp:HiddenField ID="hdndtechallandate" runat="server" />
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnperVat" runat="server" /><asp:HiddenField ID="hdnconfirm" runat="server" />
    <asp:HiddenField ID="hdnVatAccount" runat="server" /><asp:HiddenField ID="hdnVatRegNo" runat="server" />
    <asp:HiddenField ID="hdnAccno" runat="server" /><asp:HiddenField ID="hdnuom" runat="server" /> <asp:HiddenField ID="hdnysnFactory" runat="server" />
    <asp:HiddenField ID="hdnEnroll" runat="server" /> <asp:HiddenField ID="hdnitemid" runat="server" /> <asp:HiddenField ID="hdnCustAddress" runat="server" />
    <div class="tabs_container"> <asp:Label ID="lblVatacc" runat="server" CssClass="lbl" Text="VAT Account :"></asp:Label>
    <asp:DropDownList ID="ddlVatAccount" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="true" OnSelectedIndexChanged="ddlVatAccount_SelectedIndexChanged"></asp:DropDownList>                                                                                       
    <hr /></div>
    <table>
     <tr><td style="text-align:center; padding: 0px 0px 5px 0px;"><asp:Label ID="lblVatAccount" runat="server" Text="" CssClass="lbl" Font-Size="20px" Font-Bold="true" Font-Underline="true"></asp:Label></td></tr>
     <tr><td style="text-align:center; padding: 0px 0px 20px 0px;"><asp:Label ID="lblHeading" runat="server" Text="Desteroy Note Create" CssClass="lbl" Font-Size="16px"></asp:Label></td></tr><tr><td>
     <table  class="tbldecoration" style="width:auto; float:left;">                              
     <tr><td>Product Name</td>
        <td><asp:TextBox ID="txtVatItemList" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" OnTextChanged="txtVatItemList_TextChanged" ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtVatItemList"
            ServiceMethod="ItemnameSearch" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender> </td>
        <td>Material Name </td>
        <td><asp:DropDownList ID="ddlMaterialList" CssClass="ddllist" runat="server" OnSelectedIndexChanged="ddlMaterialList_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList> </td>
        <td>Standard Use </td>
        <td> <asp:Label ID="lblMaterialUserStandard" runat="server" CssClass="lbl"   MaxLength="10" AutoPostBack="true" ></asp:Label></td>
     </tr> 
     <tr><td>Challan No</td>
        <td><asp:DropDownList ID="ddlChallanNo" CssClass="ddllist" runat="server" OnSelectedIndexChanged="ddlChallanNo_SelectedIndexChanged1" AutoPostBack="True" ></asp:DropDownList></td>
        <td>Quantity</td>
        <td><asp:Label ID="lblQty" runat="server" CssClass="lbl"   MaxLength="10" AutoPostBack="true" ></asp:Label></td>
        <td>Vat </td>
        <td><asp:Label ID="lblVat" CssClass="lbl" runat="server"></asp:Label></td>
     </tr>
     <tr><td> SD</td>
            <td><asp:Label ID="lblSD" CssClass="lbl" runat="server"></asp:Label> </td>
            <td>   SD Chargeable Value</td>
            <td><asp:Label ID="lblWithouthvalue" CssClass="lbl" runat="server"></asp:Label></td>
            <td></td>
            <td><asp:Button ID="btnSave" runat="server" OnClientClick="ValidationBasicInfo()" class="myButton" OnClick="btnSave_Click" Text="Save" /></td>
    </tr>
    <tr><td colspan="6"><hr /></td></tr> 
    <tr>
        <td>Destroy Qty:</td>
        <td><asp:TextBox ID="txtCreditqty" CssClass="txtBox"   MaxLength="10" runat="server" AutoPostBack="true" OnTextChanged="txtCreditqty_TextChanged"></asp:TextBox></td>
        <td>SD Chargeable Value:</td>
        <td><asp:TextBox ID="txtSDCharableValue" CssClass="txtBox"   MaxLength="10" runat="server"></asp:TextBox></td>
        <td>SD :</td>
        <td><asp:TextBox ID="txtSD" CssClass="txtBox"   MaxLength="10" runat="server"></asp:TextBox></td>  
    </tr>
    <tr>
        <td>Use Material:</td>
        <td><asp:TextBox ID="txtNuse" CssClass="txtBox"   MaxLength="10" runat="server"></asp:TextBox></td>
        <td>Vat</td>
        <td><asp:TextBox ID="txtNewVat" CssClass="txtBox"   MaxLength="10" runat="server"></asp:TextBox></td>
        <td> Remarks:</td>
        <td><asp:TextBox ID="txtRemarks" CssClass="txtBox" TextMode="MultiLine"  MaxLength="10" runat="server"></asp:TextBox></td>  
    </tr>
    <tr><td><asp:Button ID="btnAdd" runat="server" OnClientClick="ValidationBasicInfo()" class="myButton" OnClick="btnAdd_Click" Text="Add" /></td></tr>
    </table>
    </td></tr>
    <tr><td>
    <table  class="tbldecoration" style="width:auto; float:left;"> 
   
    <tr><td style="text-align:right"></td>                                     
     <tr><td><hr /></td></tr> 
     <tr><td>
        <asp:GridView ID="dgvVatProduct" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
        CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
        HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true" OnRowDeleting="dgvPurchaseEntry_RowDeleting"
        FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical"  
        >
        <AlternatingRowStyle BackColor="#CCCCCC" />    
        <Columns>
       
        <asp:TemplateField HeaderText="Matrial Id" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblMatrialid" runat="server" Text='<%# Bind("mid") %>' Width="50px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>

      
         <asp:TemplateField HeaderText="Material Name" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblstrVatProductName" runat="server" Text='<%# Bind("MaterialName") %>' Width="50px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="UOM" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblUoms" runat="server" Text='<%# Bind("uom") %>' Width="50px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>


        <asp:TemplateField HeaderText="Quantity" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("qty","{0:n0}") %>' Width="50px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>

        
                  
       
         <asp:TemplateField HeaderText="Per use" SortExpression="VAT">
        <ItemTemplate><asp:Label ID="lblUseper" runat="server" Text='<%# Bind("Usepar","{0:n0}") %>' Width="50px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>

      
        <asp:TemplateField HeaderText="Total Use" SortExpression="VAT">
        <ItemTemplate><asp:Label ID="lbltotaluse" runat="server" Text='<%# Bind("totaluse","{0:n0}") %>' Width="50px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Challan No" SortExpression="VAT">
        <ItemTemplate><asp:Label ID="lblChallanno" runat="server" Text='<%# Bind("Challanno") %>' Width="50px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>

         <asp:TemplateField HeaderText="Challan Date" SortExpression="VAT">
        <ItemTemplate><asp:Label ID="lblChallandate" runat="server" Text='<%# Bind("dtechallandate") %>' Width="50px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>

       
        <asp:TemplateField HeaderText="Purchase Qty" SortExpression="VAT">
        <ItemTemplate><asp:Label ID="lblpqty" runat="server" Text='<%# Bind("pqty","{0:n0}") %>' Width="50px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>
       
      
         <asp:TemplateField HeaderText="SD Chargeable Value" SortExpression="rate">
        <ItemTemplate><asp:Label ID="lblsdv" runat="server"   Text='<%# Bind("sdv","{0:n0}") %>' Width="120px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="120px" />
        <FooterTemplate><asp:Label ID="lblsdvss" runat="server" DataFormatString="{0:0.0}" Text="<%# totalsdv %>" /></FooterTemplate>
        </asp:TemplateField>

       
        <asp:TemplateField HeaderText="SD" SortExpression="sd">
        <ItemTemplate><asp:Label ID="lblsd" runat="server" Text='<%# Bind("sdnew","{0:0.0}") %>' Width="50px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>

  

         <asp:TemplateField HeaderText="Total Vat" SortExpression="rate">
        <ItemTemplate><asp:Label ID="lblTvat" runat="server"   Text='<%# Bind("totalvat","{0:n0}") %>' Width="120px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="120px" />
        <FooterTemplate><asp:Label ID="lblllblTvats" runat="server" DataFormatString="{0:n0}" Text="<%# totalvat %>" /></FooterTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Per Vat" SortExpression="VAT">
        <ItemTemplate><asp:Label ID="lblpervat" runat="server" Text='<%# Bind("pervat","{0:n0}") %>' Width="50px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>

       
        <asp:TemplateField HeaderText="Total Rebit" SortExpression="rate">
        <ItemTemplate><asp:Label ID="lblpervat" runat="server"   Text='<%# Bind("rbit","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lbllblpervats" runat="server" DataFormatString="{0:n0}" Text="<%# totalrbit %>" /></FooterTemplate>
        </asp:TemplateField>

       <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" /> 


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

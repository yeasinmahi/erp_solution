<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmMushok11.aspx.cs" Inherits="UI.SAD.Vat.frmMushok11" %>
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
        function ShowPopUpCust(url) {            
            url = url +  '&Challanno=' + document.getElementById("hdnChallanno").value + '&userEnroll=' + document.getElementById("hdnEnroll").value;
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=900,top=70,left=50');
            if (window.focus) { newwindow.focus() }
         }
          function ShowPopUpCustExport(url) {            
            url = url +  '&year=' + document.getElementById("hdnyear").value;
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=900,top=70,left=50');
            if (window.focus) { newwindow.focus() }
        }
    </script>
    <style type="text/css">
        .auto-style1 {
            height: 22px;
        }
    </style>
</head>
<body>
    <form id="frmItemMatrialAdd" runat="server">
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnYear" runat="server" /><asp:HiddenField ID="hdnChallanno" runat="server" /><asp:HiddenField ID="hdnCount" runat="server" />
       <asp:HiddenField ID="hdnVatAccount" runat="server" /><asp:HiddenField ID="hdnVatRegNo" runat="server" />
        <asp:HiddenField ID="hdnAccno" runat="server" /> 
        <asp:HiddenField ID="strDescription" runat="server" /><asp:HiddenField ID="hdnysnFactory" runat="server" />
        <asp:HiddenField ID="hdnUnit" runat="server" />
       <div class="tabs_container"> &nbsp;MUSHOK-11 <hr /></div>
        <table><tr><td>
        <table  class="tbldecoration" style="width:auto; float:left;">                           
        <tr><td colspan="6"><b>Account Create</b> </td>                                  
        <tr><td><asp:Label ID="lblaccName" runat="server" Width="150">Vat Account Name</asp:Label></td>
            <td>:</td>
            <td colspan="4"><asp:Label ID="lblVatAccNametxt" runat="server" Width="150"></asp:Label></td>
        </tr> 
        <tr><td><asp:Label ID="lbladdress" runat="server" Width="150" Text="Address"></asp:Label></td>
            <td>:</td>
            <td colspan="4"><asp:Label ID="lblAddresstxt" runat="server" Width="150"></asp:Label></td>        
         </tr> 
        <tr><td><asp:Label ID="lblReg" runat="server" Width="150" Text="Vat Reg: No"></asp:Label></td>
            <td>:</td>        
            <td><asp:Label ID="lblVatregtxt" runat="server" Width="150"></asp:Label></td>             
        </tr> 
        <tr><td><asp:RadioButton ID="rbVat" GroupName="vat" Text="Local" AutoPostBack="true" runat="server" OnCheckedChanged="rbVat_CheckedChanged" />
            <asp:RadioButton ID="rbExport" GroupName="vat" Text="Export" AutoPostBack="true" runat="server" OnCheckedChanged="rbExport_CheckedChanged" /></td>                  
        </tr>
        </table>
        </td></tr>
        <tr><td>

        <asp:Panel ID="Panel3" runat="server">
        <table  class="tbldecoration" style="width:auto; float:left;">  
        <tr><td colspan="6"><hr /></td></tr>
        <tr><td>
        <tr><td colspan="4" style="text-align:center"><b>Mushok 11 Print</b> </td>
            <td><asp:Button ID="btnMushok" Text="Mushok-11" runat="server" OnClick="btnMushok_Click" /></td>
        </tr> 
        <tr><td>Challan No </td>
            <td>:</td>    
            <td><asp:DropDownList ID="ddlChallan" CssClass="ddList" runat="server"></asp:DropDownList></td>
            <td></td>
        </tr>
        <tr><td>Customer Name </td>
            <td>:</td>    
            <td colspan="2"> <asp:TextBox ID="txtCustomer" runat="server" AutoPostBack="true" CssClass="txtBox" MaxLength="10"></asp:TextBox> </td>
            <td></td>
        </tr>
        <tr><td>Challan Paid Date & Time <br />
            (YYYY-MM-DD H:MM:SS) </td> <td>:</td>    
            <td colspan="2"> <asp:TextBox ID="txtFrom" runat="server" Enabled="false"  Height="22px" autocomplete="off"></asp:TextBox>
            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFrom" Format="dd/MM/yyyy" PopupButtonID="imgCal_1"
            ID="CalendarExtender1" runat="server" EnableViewState="true">
            </cc1:CalendarExtender>
            <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px;
            width: 34px; height: 23px; vertical-align: bottom;" /> </td>           
        </tr>
        <tr><td>Vehicle No </td>
            <td>:</td>    
            <td colspan="2"> <asp:TextBox ID="txtVehicleNo" runat="server" AutoPostBack="true" CssClass="txtBox" MaxLength="10"></asp:TextBox> </td>
            <td></td>
        </tr>
        <tr><td>Customer Vat </td>
            <td>:</td>    
            <td colspan="2"> <asp:TextBox ID="txtCustomerVat" runat="server" AutoPostBack="true" CssClass="txtBox" MaxLength="10"></asp:TextBox> </td>
            <td></td>
        </tr>
        <tr><td>Final Destination </td>
            <td>:</td>    
            <td colspan="2"> <asp:TextBox ID="txtFinalDestination" runat="server" AutoPostBack="true" CssClass="txtBox" MaxLength="10"></asp:TextBox> </td>
            <td></td>
        </tr>
        <tr><td colspan="5"><hr /></td></tr>                         
        <tr><td colspan="5"><hr /></td></tr> 
        <tr><td colspan="6">&nbsp;</td></tr>        
        </table>
        </asp:Panel>
        </td></tr>
        <tr><td>

        <asp:Panel ID="PanelExport" runat="server">
        <table  class="tbldecoration" style="width:auto; float:left;">  
        <tr><td colspan="6"><hr /></td></tr>
        <tr><td>
        <tr><td colspan="4" style="text-align:center"><b>Mushok 11 Print</b> </td>
            <td><asp:Button ID="Button1" Text="Mushok-11" runat="server" OnClick="btnMushok_Click" /></td>
        </tr> 
        <tr><td>Customer Name </td>
            <td>:</td>    
            <td colspan="2"> <asp:TextBox ID="txtCustomerExp" runat="server" AutoPostBack="true" CssClass="txtBox" MaxLength="10"></asp:TextBox> </td>
            <td></td>
        </tr>
        <tr><td>Address </td>
            <td>:</td>    
            <td colspan="2"> <asp:TextBox ID="txtAddressExp" runat="server" AutoPostBack="true" CssClass="txtBox" MaxLength="10"></asp:TextBox> </td>
            <td></td>
        </tr>
         <tr><td>Vat ID </td>
            <td>:</td>    
            <td colspan="2"> <asp:TextBox ID="txtVatIDExp" runat="server" AutoPostBack="true" CssClass="txtBox" MaxLength="10"></asp:TextBox> </td>
            <td></td>
        </tr>
        <tr><td>Challan Paid Date & Time <br />
            (YYYY-MM-DD H:MM:SS) </td> <td>:</td>    
            <td colspan="2"> <asp:TextBox ID="txtFromExp" runat="server" Enabled="false"  Height="22px" autocomplete="off"></asp:TextBox>
            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFromExp" Format="dd/MM/yyyy" PopupButtonID="imgCal_1"
            ID="CalendarExtender2" runat="server" EnableViewState="true">
            </cc1:CalendarExtender>
            <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px;
            width: 34px; height: 23px; vertical-align: bottom;" /> </td>           
        </tr>
        <tr><td>Destination </td>
            <td>:</td>    
            <td colspan="2"> <asp:TextBox ID="txtDestination" runat="server" AutoPostBack="true" CssClass="txtBox" MaxLength="10"></asp:TextBox> </td>
            <td></td>
        </tr>
        <tr><td>Vehicle No </td>
            <td>:</td>    
            <td colspan="2"> <asp:TextBox ID="txtVehicleNoExp" runat="server" AutoPostBack="true" CssClass="txtBox" MaxLength="10"></asp:TextBox> </td>
            <td></td>
        </tr>
        <tr><td class="auto-style1">Dollar To BDT. Conversion </td>
            <td class="auto-style1">:</td>    
            <td colspan="2" class="auto-style1"> <asp:TextBox ID="txtDollar" runat="server" AutoPostBack="true" CssClass="txtBox" MaxLength="10"></asp:TextBox> </td>
            <td class="auto-style1"></td>
        </tr>
       <tr><td class="auto-style1">Product name </td>
            <td class="auto-style1">:</td>    
            <td colspan="2" class="auto-style1"> <asp:TextBox ID="txtVatItem" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtVatItem"
            ServiceMethod="ItemnameSearch" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender> </td>
            <td class="auto-style1"></td>
        </tr>
        <tr><td>Entry Qty </td>
            <td>:</td>    
            <td colspan="2" class="auto-style1"> <asp:TextBox ID="txtQty" runat="server" AutoPostBack="true" CssClass="txtBox" MaxLength="10"></asp:TextBox> </td>
            <td></td>
        </tr>
        <tr><td class="auto-style1">Amount </td>
            <td class="auto-style1">:</td>    
            <td colspan="2" class="auto-style1"> <asp:TextBox ID="txtAmount" runat="server" AutoPostBack="true" CssClass="txtBox" MaxLength="10"></asp:TextBox> </td>
            <td>&nbsp<asp:Button ID="btnSave" runat="server" CssClass="button"  Text="Save" OnClick="btnSave_Click"/>&nbsp<asp:Button ID="btnAdd" runat="server" CssClass="button"  Text="Add" OnClick="btnAdd_Click1"/></td>
        </tr>
        <tr><td colspan="5"><hr /></td></tr>                         
        
        <tr><td colspan="6">
            
        </td></tr>        
        </table>
        </asp:Panel>
        </td></tr>
        </div>
        <table><tr>           
            <td><asp:Panel ID="PanelProductAdd" runat="server"> <asp:GridView ID="dgvExportVat" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
            HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
            FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical"  OnRowDataBound="dgvExportVat_RowDataBound"
            OnRowDeleting="dgvExportVat_RowDeleting">
            <AlternatingRowStyle BackColor="#CCCCCC" />    
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate>  <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
 
            <asp:TemplateField HeaderText="Item Name" SortExpression="itemname">
            <ItemTemplate><asp:HiddenField ID="hdnitemid" Value='<%# Bind("intItemid") %>' runat="server" /> <asp:Label ID="lblintItemnames" runat="server" Text='<%# Bind("strItemname") %>' Width="200px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="200px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Quantity" SortExpression="qty">
            <ItemTemplate><asp:Label ID="lblQty" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Qty") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblQtyTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# totalQty %>" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="" SortExpression="rate">
            <ItemTemplate><asp:Label ID="lblsdchar" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("sdchar") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" /></asp:TemplateField>
            
            <asp:TemplateField HeaderText="" SortExpression="rate">
            <ItemTemplate><asp:Label ID="lblsdchars" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("sdchar") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" /></asp:TemplateField>


            <asp:TemplateField HeaderText="" SortExpression="value">
            <ItemTemplate><asp:Label ID="lblValue" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("DolarAmount") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblValueTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# totalvalue %>" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="" SortExpression="remarks">
            <ItemTemplate><asp:Label ID="lblsdper" runat="server" Text='<%# Bind("sdper") %>' Width="200px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="200px" /></asp:TemplateField>

             <asp:TemplateField HeaderText="Amount" SortExpression="value">
            <ItemTemplate><asp:Label ID="lblAmount" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Amount") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblValueTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# totalAmount %>" /></FooterTemplate></asp:TemplateField>


            <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" />
            
            </Columns>
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></asp:Panel></td></tr>
            
        </table>
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

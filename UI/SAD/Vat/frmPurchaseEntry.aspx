<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPurchaseEntry.aspx.cs" Inherits="UI.SAD.Vat.frmPurchaseEntry" %>
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
            var Matrialname = document.forms["frmPurchase"]["txtMatrialName"].value;
            var PurDate = document.forms["frmPurchase"]["txtFrom"].value;
            var SuppName = document.forms["frmPurchase"]["txtSupplierName"].value;           
            var ChallanNo = document.forms["frmPurchase"]["txtChallanNo"].value;
            var ChallanDate = document.forms["frmPurchase"]["txtChallandate"].value;
            var txtQty = document.forms["frmPurchase"]["txtQty"].value;
            var txtwithoutSDVat = document.forms["frmPurchase"]["txtwithoutSDVat"].value;
            var txtVat = document.forms["frmPurchase"]["txtVat"].value;
            var txtSDAmount = document.forms["frmPurchase"]["txtSDAmount"].value;

            if (Matrialname == null || Matrialname == "") {
                alert("Please Matrial Fill-Up !");
            }

            else if (PurDate == null || PurDate == "") {
                alert("Purchase Date Select !");
            }
            else if (SuppName == null || SuppName == "") {
                alert("Please Select Supplier !");
            }

            else if (ChallanNo == null || ChallanNo == "") {
                alert("Please Fill-up Challan No!");
            }

            else if (ChallanDate == null || ChallanDate == "") {
                alert("Please Fill-up Challan Date!");
            }
            else if (txtQty == null || txtQty == "") {
                alert("Please Entry Quantity.");
            }
           else if (txtwithoutSDVat == null || txtwithoutSDVat == "") {
                alert("Please Entry Without SD Vat.");
            }
                else if (txtVat == null || txtVat == "") {
                alert("Please Entry Vat.");
            }
                 else if (txtSDAmount == null || txtSDAmount == "") {
                alert("Please SD Amount.");
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
    <div class="tabs_container"> PURCHASE&nbsp; ENTRY <hr /></div>
    <table><tr><td>
    <table  class="tbldecoration" style="width:auto; float:left;">                            
       <tr><td>Production Date</td>
            <td><asp:TextBox ID="txtFrom" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFrom" Format="dd/MM/yyyy" PopupButtonID="imgCal_1"
            ID="CalendarExtender1" runat="server" EnableViewState="true">
            </cc1:CalendarExtender>
            <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px;
            width: 34px; height: 23px; vertical-align: bottom;" /></td>
        </tr> 
         
        <tr><td>Matrial Name</td>
        <td><asp:TextBox ID="txtMatrialName" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtMatrialName"
            ServiceMethod="ItemnameSearchMatrial" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender></td>
        <td>Supplier name </td>
        <td><asp:TextBox ID="txtSupplierName" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSupplierName"
            ServiceMethod="SupplierSearch" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender></td><td>Type</td>
        <td><asp:DropDownList ID="ddltype" runat="server"  AutoPostBack="True"></asp:DropDownList></td>
   
        </tr> 
        <tr><td>Challan</td>
        <td><asp:TextBox ID="txtChallanNo" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>
        <td>Challan Date</td>
        <td><asp:TextBox ID="txtChallandate" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtChallandate" Format="dd/MM/yyyy" PopupButtonID="imgCal_12"
            ID="CalendarExtender2" runat="server" EnableViewState="true">
            </cc1:CalendarExtender>
            <img id="imgCal_12" src="../../Content/images/img/calbtn.gif" style="border: 0px;
            width: 34px; height: 23px; vertical-align: bottom;" /> </td>
            <td>Qty</td>
            <td><asp:TextBox ID="txtQty" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>
        </tr>
        <tr><td> Without SD/Vat</td>
            <td><asp:TextBox ID="txtwithoutSDVat" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>
            <td>SD</td>
            <td><asp:TextBox ID="txtSDAmount" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>
            <td>Vat</td>
            <td><asp:TextBox ID="txtVat" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>

        </tr>
        <tr><td><asp:Label ID="lblbandroll" runat="server">Exempted</asp:Label></td> <td><asp:DropDownList ID="ddlExam" runat="server">
            <asp:ListItem Value="0">--Select--</asp:ListItem>
            <asp:ListItem Value="1">Yes</asp:ListItem>
            <asp:ListItem Value="2">No</asp:ListItem>
            </asp:DropDownList></td>
        <td style="margin-left: 40px"><asp:Button ID="btnAdd" runat="server" Text="Add"  OnClientClick="ValidationBasicInfo()" OnClick="btnAdd_Click" /><asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /></td>
        <td colspan="2">&nbsp;</td>                   
        </tr>
                                          
        <tr><td colspan="6"><hr /></td></tr>          
                   
    </table>
    </td></tr>
    <tr><td>
    <table  class="tbldecoration" style="width:auto; float:left;"> 
    <tr><td colspan="5" class="auto-style1">PURCHASE REPORT</td>  
    <tr><td>Production Date</td>
        <td><asp:TextBox ID="txtfdate" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
        <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtfdate" Format="dd/MM/yyyy" PopupButtonID="imgCal_123"
        ID="CalendarExtender3" runat="server" EnableViewState="true">
        </cc1:CalendarExtender>
        <img id="imgCal_123" src="../../Content/images/img/calbtn.gif" style="border: 0px;
        width: 34px; height: 23px; vertical-align: bottom;" /></td>
        <td><asp:TextBox ID="txttdate" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
        <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txttdate" Format="dd/MM/yyyy" PopupButtonID="imgCal_2"
        ID="CalendarExtender4" runat="server" EnableViewState="true">
        </cc1:CalendarExtender>
        <img id="imgCal_2" src="../../Content/images/img/calbtn.gif" style="border: 0px;
        width: 34px; height: 23px; vertical-align: bottom;" /></td>
    </tr> 
    <tr><td>Summarized by</td>
        <td><asp:DropDownList ID="ddlShorby" runat="server">
        <asp:ListItem Value="1">Day</asp:ListItem>
        <asp:ListItem Value="2">Challan</asp:ListItem>
        <asp:ListItem Value="3">Material</asp:ListItem>
        <asp:ListItem Value="4">Material Total</asp:ListItem>
        </asp:DropDownList> </td>
        <td style="text-align:left"><asp:Button ID="btnReport" runat="server" Text="Report" OnClick="btnReport_Click" /></td>
            
     </tr> 
     <tr><td colspan="5" style="text-align:right"></td>                                     
     <tr><td colspan="5"><hr /></td></tr> 
     <tr><td colspan="5"><asp:GridView ID="dgvPurChaseRpt" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
        CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
        HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
        FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical"  OnRowDataBound="dgvProductRpt_RowDataBound"
        >
        <AlternatingRowStyle BackColor="#CCCCCC" />    
        <Columns>
        <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="40px" /><ItemTemplate>  <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
 
        <asp:TemplateField HeaderText="Date" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lbldate" runat="server" Text='<%# Bind("dtePurchaseDate","{0:d}") %>' Width="100px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Material Name" SortExpression="itemname">
        <ItemTemplate> <asp:Label ID="lblintItemnames" runat="server" Text='<%# Bind("Column3") %>' Width="200px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="200px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Challan/BoE No" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblItemid" runat="server" Text='<%# Bind("Column4") %>' Width="30px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Quantity" SortExpression="qty">
        <ItemTemplate><asp:Label ID="lblQty" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column5","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblQtyTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalQty %>" /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="Without SD/Vat" SortExpression="qty">
        <ItemTemplate><asp:Label ID="lblSDVATQty" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column6","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblsdvatTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalSDVAT %>" /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="SD" SortExpression="qty">
        <ItemTemplate><asp:Label ID="lblsd" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column7","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblsdTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalSD %>" /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="VAT" SortExpression="qty">
        <ItemTemplate><asp:Label ID="lblvatQty" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column8","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblQtyTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalVAT %>" /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="Amount" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblAmount" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column9","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblValueTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalValue %>" /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="Delete"><ItemTemplate> 
        <asp:Button ID="btndelete" ForeColor="Red" runat="server" Text="Delete" CommandName="complete"  OnClick="btnDelete" Font-Bold="true" BackColor="#00ccff"  CommandArgument='<%# Eval("intID")%>' />
        </ItemTemplate> </asp:TemplateField>

        </Columns>
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
        <asp:GridView ID="dgvPurchase" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
        CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
        HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
        FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" 
        OnRowDeleting="dgvPurchase_RowDeleting">
        <AlternatingRowStyle BackColor="#CCCCCC" />    
        <Columns>
           
        <asp:TemplateField HeaderText="MaterialID" SortExpression="itemname">
        <ItemTemplate><asp:HiddenField ID="hdnitemid" Value='<%# Bind("IntItemid") %>' runat="server" /> <asp:Label ID="lblintItemnames" runat="server" Text='<%# Bind("strItemname") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Matrial Name" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblItemname" runat="server" Text='<%# Bind("strVatMatrialname") %>' Width="100px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="200px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Supplier ID" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblintSuppId" runat="server" Text='<%# Bind("intSuppId") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>


        <asp:TemplateField HeaderText="ChallanNo" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblChallanNo" runat="server" Text='<%# Bind("Challanno") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="20px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="ChallanDate" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblChallanDate" runat="server" Text='<%# Bind("dtedate") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Quantity" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("qty") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Without SD and VAT" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblPrice" runat="server" Text='<%# Bind("monPrice") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="SD" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblSD" runat="server" Text='<%# Bind("SD") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="SD" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblVat" runat="server" Text='<%# Bind("Vat") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>


        <asp:TemplateField HeaderText="VAT" SortExpression="">
        <ItemTemplate><asp:Label ID="lblVAT" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("VAT") %>' Width="30px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="30px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Total" SortExpression="rate">
        <ItemTemplate><asp:Label ID="lblTotal" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("totalAmount") %>' Width="50px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="50px" /></asp:TemplateField>
            
        <asp:TemplateField HeaderText="Exempted" SortExpression="rate">
        <ItemTemplate><asp:Label ID="lblExempted" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("ysnexamp") %>' Width="30px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="30px" /></asp:TemplateField>
           
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

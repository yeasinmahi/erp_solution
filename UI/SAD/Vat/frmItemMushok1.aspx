<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmItemMushok1.aspx.cs" Inherits="UI.SAD.ExcelChallan.frmItemMushok1" %>
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
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />
    <link href="../Content/CSS/Application.css" rel="stylesheet" />
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" />
       <asp:HiddenField ID="hdnVatAccount" runat="server" /><asp:HiddenField ID="hdnVatRegNo" runat="server" />
        <asp:HiddenField ID="hdnAccno" runat="server" /> <asp:HiddenField ID="hdnysnFactory" runat="server" />
        <asp:HiddenField ID="hdnUnit" runat="server" />
       <div class="tabs_container"> PRICE DECLARATION MUSHOK-1 <hr /></div>
        <table  class="tbldecoration" style="width:auto; float:left;">                           
        <tr><td colspan="6"><hr /></td></tr>   
        <tr><td colspan="6">Vat Item Create</td>                                  
        <tr><td class="auto-style1">Product Name</td>
            <td class="auto-style1"><asp:TextBox ID="txtItemMatrial" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtItemMatrial"
            ServiceMethod="ItemnameSearch" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender></td>
            <td class="auto-style1">Mushok Type</td>
            <td class="auto-style1"><asp:DropDownList ID="ddlMType" runat="server"></asp:DropDownList>&nbsp<asp:Button ID="btnShow" class="myButton" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
            <td class="auto-style2"> Valid From</td>
            <td class="auto-style1">
            <asp:TextBox ID="txtFrom" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFrom" Format="dd/MM/yyyy" PopupButtonID="imgCal_1"
            ID="CalendarExtender1" runat="server" EnableViewState="true">
            </cc1:CalendarExtender>
            <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px;
            width: 34px; height: 23px; vertical-align: bottom;" /> </td>
        </tr> 
        <tr><td>SD Chargeable</td>
            <td><asp:TextBox ID="txtSDCharge" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>
            <td>SD(%)</td>
            <td><asp:TextBox ID="txtSDPer" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox> </td>
            <td class="auto-style3">VAT(%)</td>
            <td><asp:TextBox ID="txtVatper" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox> </td>
         </tr> 
        <tr> <td>SurCharge(%)</td>
            <td><asp:TextBox ID="txtSurCharge" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox> </td>        
            <td>Whole Sale</td>
            <td><asp:TextBox ID="txtwholeSales" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>
            <td class="auto-style3">MRP</td>
            <td><asp:TextBox ID="txtMRR" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox> </td>    
         </tr> 
        <tr><td colspan="6"><hr /></td></tr>
         <tr><td>Matrial Name</td>
            <td><asp:TextBox ID="txtVatMatrialname" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtVatMatrialname"
            ServiceMethod="ItemnameSearchMatrial" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender></td>
            <td>Total Qty </td>
            <td><asp:TextBox ID="txtTotalQty" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>
            <td>Wastage </td>
            <td><asp:TextBox ID="txtWastage" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>
         </tr> 
        <tr><td>Rate </td>
            <td><asp:TextBox ID="txtRate" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox> </td>    
            <td colspan="2"><asp:Button ID="btnAdd" runat="server" class="myButton" Text="Add" OnClick="btnAdd_Click" />&nbsp<asp:Button ID="btnSave" class="myButton" runat="server" Text="Save" OnClick="btnSave_Click" /></td>
        </tr>
        <tr><td colspan="5"><hr /></td></tr>                         
       
        <tr><td colspan="6">
           <asp:GridView ID="dgvMatrialItem" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="Small" OnRowDataBound="dgvMatrialItem_RowDataBound" ShowFooter="True">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns> 

            <asp:TemplateField HeaderText="Matrial Id" SortExpression=""><ItemTemplate><asp:Label ID="lblCustid" runat="server" Text='<%# Bind("intVATMaterialID") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="70px"/><FooterTemplate><div style="padding:0 0 5px 0"><asp:Label ID="lbl" Width="100px"  runat="server" Text="Grand-Total :" /></div>
            </FooterTemplate></asp:TemplateField> 
                           
            <asp:BoundField DataField="strMaterialName" HeaderText="Matrial Name" ReadOnly="True" SortExpression="strline"/>
            <asp:BoundField DataField="strUom" HeaderText="UOM" ReadOnly="True" SortExpression="strregion"/>
            <asp:BoundField DataField="numQty" HeaderText="Qty" ReadOnly="True" SortExpression="strarea"/>
            <asp:BoundField DataField="numWastage" HeaderText="Wastage" ReadOnly="True" SortExpression="strTerritory"/>
            <asp:BoundField DataField="Column1" HeaderText="Rate (TK)" ReadOnly="True" SortExpression="Point"/>
                 
            <asp:TemplateField HeaderText="Total (TK)" SortExpression="Pending">
            <ItemTemplate><asp:Label ID="lblqty" runat="server" Text='<%# (""+Eval("monValue","{0:n0}")) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lblPending" runat="server" Text='<%# PendingmonValue %>' /></FooterTemplate>
            </asp:TemplateField>
           
           
            </Columns>
            <FooterStyle BackColor="#F3CCC2" BorderStyle="None" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>

           <asp:GridView ID="dgvMatrialAdd" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
            HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
            FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" OnRowDataBound="dgvMatrialAdd_RowDataBound"
            OnRowDeleting="dgvAdd_RowDeleting"   >
            <AlternatingRowStyle BackColor="#CCCCCC" />    
            <Columns>
            <asp:TemplateField HeaderText="Matrial ID" SortExpression="itemid">
            <ItemTemplate><asp:Label ID="lblintItemid" runat="server" Text='<%# Bind("intItemid") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>
                
            <asp:TemplateField HeaderText="Matrial Name" SortExpression="itemname">
            <ItemTemplate><asp:Label ID="lblItemName" runat="server" Text='<%# Bind("strItemMatrial") %>' Width="200px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="200px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="TotalQty" SortExpression="uom">
            <ItemTemplate><asp:Label ID="lblTotalQty" runat="server" Text='<%# Bind("TotalQty") %>' Width="60px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="60px" />
            <FooterTemplate><asp:Label ID="lblT" runat="server" Text="Total" /></FooterTemplate></asp:TemplateField>
                                
            <asp:TemplateField HeaderText="Wastage" SortExpression="rate">
            <ItemTemplate><asp:Label ID="lblWastage" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Wastage") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Rate" SortExpression="rate">
            <ItemTemplate><asp:Label ID="lblRate" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("rate") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Value" SortExpression="value">
            <ItemTemplate><asp:Label ID="lblValue" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("value") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblValueTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# totalvalue %>" /></FooterTemplate></asp:TemplateField>
          
            <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" />
            
            </Columns>
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
           </td></tr>
                
        </table>
        </div>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

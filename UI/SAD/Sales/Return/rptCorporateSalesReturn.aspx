<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptCorporateSalesReturn.aspx.cs" Inherits="UI.SAD.Sales.Return.rptCorporateSalesReturn" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><title></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
<webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
<link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
<script src="../Content/JS/datepickr.min.js"></script>
<script src="../../Content/JS/JSSettlement.js"></script>   
<link href="jquery-ui.css" rel="stylesheet" />
<script src="jquery.min.js"></script>
<script src="jquery-ui.min.js"></script>    
<script src="../Content/JS/CustomizeScript.js"></script>
<script src="../../Content/JS/CustomizeScript.js"></script>
<link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
<link href="../../Content/CSS/Application.css" rel="stylesheet" />
<script src="../../../../Content/JS/JQUERY/GridviewScroll.min.js"></script>
<link href="../Content/CSS/Lstyle.css" rel="stylesheet" />

<script>
    function ExportDivDataToExcel() {
        var html = $("#divinfo").html();
        html = $.trim(html);
        html = html.replace(/>/g, '&gt;');
        html = html.replace(/</g, '&lt;');
        $("input[id$='HdnValue']").val(html);
        }
    function funvalidate() {
        if ((document.getElementById("txtfrmdte").value).length == 0)
        { alert("From date can't be empty"); return false; }
        if ((document.getElementById("txttodte").value).length == 0)
        { alert("To date can't be empty"); return false; }
        }
</script> 
</head>
<body>
    <form id="frmcorpsalesreturninput" runat="server">
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
   <%-- <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>--%>
<%--=========================================Start My Code From Here===============================================--%>
    <div class="leaveApplication_container"><b>Corporate Sales Return Report: </b><asp:HiddenField ID="hdnconfirm" runat="server" /><hr />
    <table style="width:1000px";>
    <tr>
    <td style="text-align:right;" colspan="1"><asp:Label ID="lblfrmdte" CssClass="lbl" runat="server" Text="From Date : "></asp:Label></td>
    <td><asp:TextBox ID="txtfrmdte" runat="server" CssClass="txtBox" Width="120px" autocomplete="off"></asp:TextBox><cc1:CalendarExtender ID="cefrmdte" runat="server" Format="yyyy-MM-dd" TargetControlID="txtfrmdte"></cc1:CalendarExtender><%--</td>--%>
    <%--<td style="text-align:right;" colspan="1">--%><asp:Label ID="lbltodte" CssClass="lbl" runat="server" Text="To Date : "></asp:Label><%--</td>--%>
    <%--<td>--%><asp:TextBox ID="txttodte" runat="server" CssClass="txtBox" Width="120px" autocomplete="off"></asp:TextBox><cc1:CalendarExtender ID="cetodte" runat="server" Format="yyyy-MM-dd" TargetControlID="txttodte"></cc1:CalendarExtender></td>
    </tr>
    <tr><td style="text-align:right;"><asp:Label ID="lblsrch" CssClass="lbl" runat="server" Text="Customer Name : "></asp:Label></td>
    <td style="text-align:left;"><asp:TextBox ID="txtSearch" runat="server" AutoPostBack="true" Width="350px"  CssClass="txtBox" AutoCompleteType="Search"   Enabled="true" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
    <asp:HiddenField ID="hdncustid" runat="server" /><cc1:AutoCompleteExtender ID="AutoCompleteCustomer" runat="server" TargetControlID="txtSearch"
    ServiceMethod="GetCustomer" MinimumPrefixLength="1" CompletionSetCount="1"
    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElement"
    CompletionListItemCssClass="autocomplete_listItem"  CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
    </cc1:AutoCompleteExtender></td>
    </tr>
    <tr><td style="text-align:right;"><asp:Label ID="lblc" CssClass="lbl" runat="server" Text="Product Name : "></asp:Label></td>
    <td><asp:TextBox ID="txtprod" runat="server" AutoCompleteType="Search"  CssClass="txtBox" style="width:300px" AutoPostBack="true" OnTextChanged="txtprod_TextChanged"></asp:TextBox>
    <cc1:AutoCompleteExtender ID="AutoCompleteProduct" runat="server" TargetControlID="txtprod" ServiceMethod="GetProduct" MinimumPrefixLength="1" CompletionSetCount="1"
    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElement"
    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"></cc1:AutoCompleteExtender>  
    <asp:HiddenField ID="hdnprodid" runat="server" /></td>
    </tr>
    <tr><td colspan="2" style="text-align:right"><asp:Button ID="btvSubmit" runat="server" class="nextclick" style="font:bold 12px verdana;" Text="Show" OnClientClick="funvalidate()" OnClick="btnshow_Click"/><asp:Button ID="btnExport" runat="server" CssClass="nextclick" ForeColor="Green" Font-Bold="true" Text="Export To Excel" OnClick="btnExport_Click" OnClientClick="ExportDivDataToExcel()"/></td></tr>
    <tr><td colspan="2">
    <div ID="divinfo" runat="server" >
    <table style="width:100%">
    <tr><td colspan="4" style="text-align:center"><asp:Label runat="server" CssClass="lbl" ID="lblhead" Text="Corporate Sales Dept. Sales Return Report" /></td></tr>
    <tr><td style="text-align:right;"><asp:Label ID="lblcustname1" CssClass="lbl" runat="server" Text="Customer Name : "/></td><td colspan="3"><asp:Label ID="lblcustname2" CssClass="lbl" runat="server"/> </td></tr>
    <tr>
    <td style="text-align:right;"><asp:Label CssClass="lbl" runat="server" ID="lblfromdatename" Text="Period: " /></td>
    <td style="text-align:left;"><asp:Label CssClass="lbl" runat="server" ID="lblfromdate" /><asp:Label CssClass="lbl" runat="server" ID="lbltodatename" Text=" to " /><asp:Label CssClass="lbl" runat="server" ID="lbltodate" /></td>
    <td colspan="2"></td>
    </tr>
    <tr><td style="text-align:right;"><asp:Label ID="lblprodname1" CssClass="lbl" runat="server" Text="Product Name : "/></td><td  colspan="3"><asp:Label ID="lblprodname2" CssClass="lbl" runat="server"/>
    </table>
    <table>
    <tr><td colspan="2">  
    <asp:GridView ID="dgvrpt1" runat="server"  AutoGenerateColumns="False" Font-Size="9px" BackColor="White" OnRowDataBound="dgvrpt1_RowDataBound"
    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical"  ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Center">
    <AlternatingRowStyle BackColor="#CCCCCC"/>
    <Columns>
     <asp:TemplateField HeaderText="SL."><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
     <asp:TemplateField HeaderText="Customer Name" ItemStyle-Width="300px"><ItemTemplate ><asp:Label ID="lblcustname" runat="server" Text='<%# Bind("strName") %>'></asp:Label></ItemTemplate>
     <ItemStyle Width="300px" HorizontalAlign="Left" /><FooterTemplate><asp:Label ID="lblttlcustname" runat="server" Text="Total" /></FooterTemplate></asp:TemplateField>
     <asp:TemplateField HeaderText="Sales Value"><ItemTemplate ><asp:Label ID="lblsalesvalue" runat="server" Text='<%# Bind("salesvalue") %>'></asp:Label></ItemTemplate>
     <ItemStyle Width="80px" HorizontalAlign="Right" /><FooterTemplate><asp:Label ID="lblttlsalesvalue" runat="server" Text='<%# ttlsalesvalue %>' /></FooterTemplate></asp:TemplateField>
     <asp:TemplateField HeaderText="Damage Value"><ItemTemplate ><asp:Label ID="lbldamagevalue" runat="server" Text='<%# Bind("damagevalue") %>'></asp:Label></ItemTemplate>
     <ItemStyle Width="80px" HorizontalAlign="Right"/><FooterTemplate><asp:Label ID="lblttldamagevalue" runat="server" Text='<%# ttldamagevalue %>' /></FooterTemplate></asp:TemplateField>
     <asp:TemplateField HeaderText="Damage %"><ItemTemplate ><asp:Label ID="lblpercent" runat="server" Text='<%# Bind("dampercent") %>'></asp:Label></ItemTemplate>
     <ItemStyle Width="80px" HorizontalAlign="Center" /><FooterTemplate><asp:Label ID="lblttlpercent" runat="server" Text='<%# ttlpercent %>' /></FooterTemplate></asp:TemplateField>
     <asp:TemplateField HeaderText="Client Return"><ItemTemplate ><asp:Label ID="lblclientrtn" runat="server" Text='<%# Bind("creturnqty") %>'></asp:Label></ItemTemplate>
     <ItemStyle Width="80px" HorizontalAlign="Center" /><FooterTemplate><asp:Label ID="lblttlclientrtn" runat="server" Text='<%# ttlclientrtn %>' /></FooterTemplate></asp:TemplateField>
     <asp:TemplateField HeaderText="WH Receive"><ItemTemplate ><asp:Label ID="lblwhrcv" runat="server" Text='<%# Bind("wrrcvqty") %>'></asp:Label></ItemTemplate>
     <ItemStyle Width="80px" HorizontalAlign="Center" /><FooterTemplate><asp:Label ID="lblttlwhrcv" runat="server" Text='<%# ttlwhrcv %>' /></FooterTemplate></asp:TemplateField>
     <asp:TemplateField HeaderText="Client WH Var"><ItemTemplate ><asp:Label ID="lblcntwhvar" runat="server" Text='<%# Bind("whvariation") %>'></asp:Label></ItemTemplate>
     <ItemStyle Width="80px" HorizontalAlign="Center" /><FooterTemplate><asp:Label ID="lblttlcntwhvr" runat="server" Text='<%# ttlcntwhvr %>' />
     <asp:Label ID="Label2" runat="server" Text=' Percent: ' /><asp:Label ID="lblttlcntwhvrper" runat="server" Text='<%# ttlcntwhvrper %>' /></FooterTemplate></asp:TemplateField>
     <asp:TemplateField HeaderText="Fty Recieve"><ItemTemplate ><asp:Label ID="lblftyrcv" runat="server" Text='<%# Bind("ftyrcvqty") %>'></asp:Label></ItemTemplate>
     <ItemStyle Width="80px" HorizontalAlign="Center" /><FooterTemplate><asp:Label ID="lblttlftyrcv" runat="server" Text='<%# ttlftyrcv %>' /></FooterTemplate></asp:TemplateField>
     <asp:TemplateField HeaderText="WH Fty Var"><ItemTemplate ><asp:Label ID="lblwhftyvar" runat="server" Text='<%# Bind("ftyvariation") %>'></asp:Label></ItemTemplate>
     <ItemStyle Width="80px" HorizontalAlign="Center" /><FooterTemplate><asp:Label ID="lblttlwhftyvar" runat="server" Text='<%# ttlwhftyvar %>' />
     <asp:Label ID="Label1" runat="server" Text=' Percent: ' /><asp:Label ID="lblttlwhftyvarper" runat="server" Text='<%# ttlwhftyvarper %>' /></FooterTemplate></asp:TemplateField>
     </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White"/> <FooterStyle BackColor="#F3CCC2" BorderStyle="None" />
     <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" /></asp:GridView>
     </td></tr></table></div><asp:HiddenField ID="HdnValue" runat="server" /></td></tr>
     <tr><td style="text-align:right;" colspan="3"></tr>
     </table> 
     </div>
<%--=========================================End My Code From Here=================================================--%>
   <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>
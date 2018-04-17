<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoteProductDelivery.aspx.cs" Inherits="UI.SAD.Sales.Report.RptRemoteSales.RemoteProductDelivery" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script src="../../../../Content/JS/datepickr.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtFullName.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/ClassFiles/AutoCompleteSearch.asmx/GetTerritoryCustomer") %>',
                        data: '{"tsoenrol":"' + $("#hdnenroll").val() + '","prefix":"' + request.term + '"}',
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) { response($.map(data.d, function (item) { return { label: item.split('^')[0], val: item.split(',')[1] } })) },
                        error: function (response) { },
                        failure: function (response) { }
                    });
                },
                select: function (e, i) {
                    $("#<%=hdnsearch.ClientID %>").val(i.item.val);
                }, minLength: 1
            });
        });
</script>
</head>
<body>
    <form id="frmpdv" runat="server">
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
    <div class="leaveApplication_container"> 
    <div class="tabs_container"> Product Delivery Report :<asp:HiddenField ID="hdnenroll" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/><hr /></div>
        <table border="0"; style="width:Auto"; >    
        <tr class="tblrowodd">
        <td style="text-align:right;"><asp:Label ID="lblfullname" CssClass="lbl" runat="server" Text="Customer Name: "></asp:Label></td>
        <td><asp:TextBox ID="txtFullName" runat="server" CssClass="txtBox" AutoPostBack="false"></asp:TextBox></td>
        <td style="text-align:right;" colspan="2"></td>
        </tr>


        <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtToDate', { 'dateFormat': 'Y-m-d' });</script></td>          
        </tr>

        <tr><td style="text-align:right" colspan="4"><asp:Button ID="btnShowDelvRepot" runat="server" Text="Show Report" CssClass="button" OnClick="btnShowDelvRepot_Click"  /></td></tr>
             
        <tr class="tblrowodd">
              <td colspan="4">
              <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging"  >
              
                  <AlternatingRowStyle BackColor="#CCCCCC" />
              
              <Columns>
                   <asp:BoundField DataField="Column1" HeaderText="Tr. Date" SortExpression="trnDate" />
                   <asp:BoundField DataField="strName" HeaderText="Shop Name" SortExpression="strShopname" />
                    <asp:BoundField DataField="intDisPointId" HeaderText="Shop id" SortExpression="intShopid" />
                  <asp:BoundField DataField="Column2" HeaderText="Delv. Qnt." SortExpression="decDelv" />
                     <asp:BoundField DataField="Column3" HeaderText="Prom. Qnt." SortExpression="decProm" />
                   <asp:BoundField DataField="strCode" HeaderText="Challan" SortExpression="strChallan" />
                   <asp:BoundField DataField="strCode1" HeaderText="D.O " SortExpression="strDO" />
                  <asp:BoundField DataField="strProductName" HeaderText="Item" SortExpression="strItem" />
                  <asp:BoundField DataField="strName1" HeaderText="Customer Name" SortExpression="strCustomer" />
                   <asp:BoundField DataField="strText" HeaderText="Territory" SortExpression="strTerritory" />
                  </Columns>
                  <FooterStyle BackColor="#CCCCCC" />
                  <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                  <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                  <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                  <SortedAscendingCellStyle BackColor="#F1F1F1" />
                  <SortedAscendingHeaderStyle BackColor="#808080" />
                  <SortedDescendingCellStyle BackColor="#CAC9C9" />
                  <SortedDescendingHeaderStyle BackColor="#383838" />
                  </asp:GridView>
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

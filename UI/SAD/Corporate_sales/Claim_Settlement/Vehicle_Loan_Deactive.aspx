<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vehicle_Loan_Deactive.aspx.cs" Inherits="UI.SAD.Corporate_sales.Claim_Settlement.Vehicle_Loan_Deactive" %>

    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server"><title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script src="../Content/JS/datepickr.min.js"></script>
    <script>
    $(document).ready(function () {
    $("#<%=txtcustomer.ClientID %>").autocomplete({
    source: function (request, response) {
    $.ajax({
    url: '<%=ResolveUrl("Vehicle_Loan_Deactive.aspx/GetCust") %>',
    data: '{"customer":"' + request.term + '"}',dataType: "json",type: "POST",
    contentType: "application/json; charset=utf-8",
    success: function (data) {
    response($.map(data.d, function (item) {
    return {label: item.split('^')[0], val: item.split('^')[1]}
    })) },
    error: function (response) { alert('Error'); },
    failure: function (response) { alert('fail'); }
    }); },
    select: function (e, i) {
    e.preventDefault()
    $("[id$=hdfcustid]").val(i.item.val);
    }, minLength: 2
    }); });
    </script>
    <style>
    .hidden {display:none}
    .lap{display:none;z-index:0  }
    .right {padding:90px 0px 0px 900px; }
    </style>
    </head>
    <body>
    <form id="frmrtn" runat="server">
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
   <%-- <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>--%>
<%--=========================================Start My Code From Here===============================================--%>
    <div class="leaveApplication_container">
    <table border="0"; style="width:Auto"; >
    <tr><td colspan="4" class="tblheader">Vehicle Loan Final Settlement Status :</td></tr>
    <tr class="tblrowodd">     
    <td style="text-align:right;" ><asp:Label ID="lbldpt" CssClass="lbl" runat="server" Text="Customer Name : "></asp:Label></td>
    <td colspan="3"><asp:TextBox ID="txtcustomer" runat="server" CssClass="txtBox" style="width:500px" ></asp:TextBox>
    <asp:HiddenField ID="hdfcustid" runat="server" /></td>  
    </tr>
    <tr class="tblroweven">
    <td style="text-align:right;" class="auto-style1"><asp:Label ID="lblhndovrtype" runat="server" Text="Vehicle Handover Type: " /></td>
    <td colspan="1" style="text-align:left;padding:0,0,0,50px;width:400px">  
    <asp:RadioButtonList ID="rdhndovrtype" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" >
    <asp:ListItem Text="To Customer" Value="1"></asp:ListItem>
    <asp:ListItem Text="To Company" Value="2"></asp:ListItem>
    </asp:RadioButtonList></td >
    </tr> 
    <tr class='tblrowodd'>
    <td colspan="1" style="text-align:right;"><asp:Button ID="reset" runat="server" Text="Reset" Font-Bold="true" OnClick="reset_Click"  /></td>
    <td colspan="5" style="text-align:right;"><asp:Button ID="status" runat="server" Text="Status" Font-Bold="true" OnClick="status_Click"  />
    </tr></table></div>
    <div class="right" id="rightdiv" runat="server">
    <table><tr>
    <td><asp:Label ID="custblnc" runat="server" Text="Customer Balance" /><asp:TextBox ID="tbxcustblnc" runat="server" style="width:120px" ReadOnly="true"></asp:TextBox></td>
    </tr></table></div> 
    <div>
    <table class="" style="width:100%; height:2px ">  
    <tr style="width:100%" >       
    <td style="text-align:justify;font-size:12px; background-color:white;">
        <asp:GridView ID="gvfnlsttl" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Inset" Font-Names="Calibri" Font-Size="Small" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:TemplateField HeaderText="SL.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <ItemStyle Height="5px" HorizontalAlign="Left" Width="50px" />
                </asp:TemplateField>
                <asp:TemplateField ControlStyle-CssClass="hidden" FooterStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" HeaderText="Customer ID" ItemStyle-CssClass="hidden" SortExpression="intCustid">
                    <ItemTemplate>
                        <asp:Label ID="lblintCustid" runat="server" Text='<%# Bind("icustid") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Height="5px" HorizontalAlign="Left" Width="100px" />
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField ControlStyle-CssClass="hidden" FooterStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" HeaderText="COA ID" ItemStyle-CssClass="hidden" SortExpression="intCOAid">
                    <ItemTemplate>
                        <asp:Label ID="lblintCOAid" runat="server" Text='<%# Bind("icustcoaid") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Height="5px" HorizontalAlign="Left" Width="100px" />
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField ControlStyle-CssClass="hidden" FooterStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" HeaderText="Acc Name" ItemStyle-CssClass="hidden" SortExpression="strAccName">
                    <ItemTemplate>
                        <asp:Label ID="lblstrAccName" runat="server" Text='<%# Bind("scustname") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Height="5px" HorizontalAlign="Left" Width="100px" />
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Customer Loan Name" SortExpression="strvehiclename">
                    <ItemTemplate>
                        <asp:Label ID="lblstrvehiclename" runat="server" Text='<%# Bind("scustnamel") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Height="5px" HorizontalAlign="Left" Width="300px" />
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delivery Date" SortExpression="dtdeliverydate">
                    <ItemTemplate>
                        <asp:Label ID="lbldtdeliverydate" runat="server" Text='<%# Bind("dtdeliverydate","{0:d}") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Height="5px" HorizontalAlign="Left" Width="100px" />
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price" SortExpression="monvehicleprice">
                    <ItemTemplate>
                        <asp:Label ID="lblmonvehicleprice" runat="server" Text='<%# Bind("monvehicleprice","{0:n0}") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Height="5px" HorizontalAlign="Left" Width="100px" />
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Down Payment" SortExpression="downpayment">
                    <ItemTemplate>
                        <asp:Label ID="lbldownpayment" runat="server" Text='<%# Bind("mondownpayment","{0:n0}") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Height="5px" HorizontalAlign="Left" Width="100px" />
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Useful Period" SortExpression="monusefullife">
                    <ItemTemplate>
                        <asp:Label ID="lblmonusefullife" runat="server" Text='<%# Bind("monusefullife","{0:n0}") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Height="5px" HorizontalAlign="Left" Width="100px" />
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Depreciation Per Month" SortExpression="mondepreciation">
                    <ItemTemplate>
                        <asp:Label ID="lblmondepreciation" runat="server" Text='<%# Bind("mondepreciation","{0:n0}") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Height="5px" HorizontalAlign="Left" Width="100px" />
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Loan Period" SortExpression="monloanperiod">
                    <ItemTemplate>
                        <asp:Label ID="lblmonloanperiod" runat="server" Text='<%# Bind("monloanperiod","{0:n0}") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Height="5px" HorizontalAlign="Left" Width="100px" />
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Monthly Instalment" SortExpression="monemi">
                    <ItemTemplate>
                        <asp:Label ID="lblmonemi" runat="server" Text='<%# Bind("monemi","{0:n0}") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Height="5px" HorizontalAlign="Left" Width="100px" />
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Used Period" SortExpression="usedperiod">
                    <ItemTemplate>
                        <asp:Label ID="lblusedperiod" runat="server" Text='<%# Bind("usedperiod","{0:n0}") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Height="5px" HorizontalAlign="Left" Width="100px" />
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cumulative Depreciation" SortExpression="cumdepreciation">
                    <ItemTemplate>
                        <asp:Label ID="lblcumdepreciation" runat="server" Text='<%# Bind("cumdepreciation","{0:n0}") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Height="5px" HorizontalAlign="Left" Width="100px" />
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Paid" SortExpression="paid">
                    <ItemTemplate>
                        <asp:Label ID="lblpaid" runat="server" Text='<%# Bind("paid","{0:n0}") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Height="5px" HorizontalAlign="Left" Width="100px" />
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Payable" SortExpression="payable">
                    <ItemTemplate>
                        <asp:Label ID="lblpayable" runat="server" Text='<%# Bind("payable","{0:n0}") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Height="5px" HorizontalAlign="Left" Width="100px" />
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Stop Getting EMI" SortExpression="payable">
                    <ItemTemplate>
                        <asp:Button ID="btnclose" runat="server" CommandArgument='<%#Eval("icustid") + "," +Eval("intvehiclepaymentid") + "," +Eval("payable")%>' OnClick="close_Click" Text="Stop" />
                    </ItemTemplate>
                    <ItemStyle Height="5px" HorizontalAlign="Left" Width="100px" />
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#999999" Font-Bold="false" Font-Size="Small" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
    </td></tr> 
    <%--<tr style="text-align:justify">
    <td style="padding:0 0 0 500px">
    <asp:Button ID="close" runat="server" Text="Stop Geting EMI" OnClick="close_Click" /></td>
    </tr>--%>
    </table></div>  
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    </body>
    </html>

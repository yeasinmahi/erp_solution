<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GhatTransferChallanReceive.aspx.cs" Inherits="UI.SAD.Order.GhatTransferChallanReceive" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script src="../../../../Content/JS/datepickr.min.js"></script>
    
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
    <div class="tabs_container"> Transfer Challan pending status :<asp:HiddenField ID="hdnenroll" runat="server"/>
        <asp:HiddenField ID="hdnunitid" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
        <asp:HiddenField ID="hdnEmail" runat="server"/>
        <hr /></div>
        <table border="0"; style="width:Auto"; >    
        


        <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtToDate', { 'dateFormat': 'Y-m-d' });</script></td>          
        </tr>
         <tr class="tblrowodd">
        <td style="text-align:right;"><asp:Label ID="ProductName" CssClass="lbl" runat="server" Text="Product Name: "></asp:Label></td>
        <td><asp:DropDownList ID="drdlProductName" runat="server" DataSourceID="odsProductList" DataTextField="strProductName" DataValueField="intID"></asp:DropDownList>
            <asp:ObjectDataSource ID="odsProductList" runat="server" SelectMethod="getProductList" TypeName="SAD_BLL.Customer.Report.StatementC"></asp:ObjectDataSource>
             </td>

        <td style="text-align:right;"><asp:Label ID="lblGhatName" CssClass="lbl" runat="server" Text="Ghat Name: "></asp:Label></td>
        <td> <asp:DropDownList ID="drdlGhat" runat="server" DataSourceID="odsShipping" DataTextField="strName" DataValueField="intShipPointId"></asp:DropDownList>
            <asp:ObjectDataSource ID="odsShipping" runat="server" SelectMethod="getShippingPoint" TypeName="SAD_BLL.Customer.Report.StatementC">
                <SelectParameters>
                    <asp:SessionParameter Name="officeemail" SessionField="sesEmail" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
             </td>


        </tr>
            <tr>
                <td><asp:Label ID="lblUnit" Text="Unit" runat="server"></asp:Label></td>
                <td colspan="3"><asp:DropDownList ID="drdlUnit" runat="server" DataSourceID="odsUnitName" DataTextField="strUnit" DataValueField="intUnitID"></asp:DropDownList>
                    <asp:ObjectDataSource ID="odsUnitName" runat="server" SelectMethod="getUnitName" TypeName="SAD_BLL.Customer.Report.StatementC"></asp:ObjectDataSource>
                </td>

            </tr>
            


        <tr><td style="text-align:right" colspan="4"><asp:Button ID="btnShowDelvRepot" runat="server" Text="Show Report" CssClass="button" OnClick="btnShowDelvRepot_Click"  /></td></tr>
            <div>
                <table>
        <tr class="tblrowodd">
              <td colspan="3">
              <asp:GridView ID="grdvTransferChallanReceive" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="50" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical"  OnPageIndexChanging="grdvTransferChallanReceive_PageIndexChanging"  >
              
                  <AlternatingRowStyle BackColor="#CCCCCC" />
              
              <Columns>
                    
                   <asp:BoundField DataField="intsl" HeaderText="Sl" SortExpression="intsl" />
                  <asp:BoundField DataField="intid" HeaderText="intid" SortExpression="intid" />
                   <asp:BoundField DataField="intProductid" HeaderText="pid" SortExpression="intProductid" />
                   <asp:BoundField DataField="intGhatid" HeaderText="Ghatid" SortExpression="intGhatid" />
                   <asp:BoundField DataField="dtedate" HeaderText="Date" SortExpression="dtedate" />
                   <asp:BoundField DataField="strphone" HeaderText="Phone" SortExpression="strphone" />
                   <asp:BoundField DataField="strDriver" HeaderText="Driver" SortExpression="strDriver" />
                     <asp:BoundField DataField="strvhc" HeaderText="Vheicle" SortExpression="strvhc" />
                  <asp:BoundField DataField="strProduct" HeaderText="Product" SortExpression="strProduct" />
                   <asp:BoundField DataField="strChallan" HeaderText="Challan" SortExpression="strChallan" />
                  <asp:BoundField DataField="decQnt" HeaderText="Qnt" SortExpression="decQnt" />
                  <asp:BoundField DataField="strGhatname" HeaderText="Ghat Name" SortExpression="strGhatname" />
              
                <asp:TemplateField HeaderText="Det.">
                <ItemTemplate>
                <asp:Button ID="btnRecieve" runat="server" Text="Receive" class="button" CommandName="complete" OnClick="btnRecieve_Click"  CommandArgument='<%# Eval("intid")+","+Eval("dtedate")+","+Eval("strChallan")%>' /></ItemTemplate>
                </asp:TemplateField>  
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




        </table>



    </div>
   <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

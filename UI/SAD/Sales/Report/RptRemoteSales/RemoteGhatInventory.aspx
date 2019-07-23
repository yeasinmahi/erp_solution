<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoteGhatInventory.aspx.cs" Inherits="UI.SAD.Sales.Report.RptRemoteSales.RemoteGhatInventory" %>

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
    <div class="tabs_container"> ACCL Ghat/Depot Inventory :<asp:HiddenField ID="hdnenroll" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
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
        <tr><td style="text-align:right" colspan="4"><asp:Button ID="btnGhatInventory" runat="server" Text="GhatInventory" CssClass="button" OnClick="btnGhatInventory_Click"  /></td></tr>
             <%--SL , decOpeningQntfianl ,dteTransactionfianl , Productidfianl ,strProductNamefianl ,decDeliverdFromDepotActualfianl ,decDeliverdFromDepotPromotionfianl ,decDeliverdFromDepotTotalfianl  ,decDeliverdFromFactoryTransistfianl ,decDeliverdFromFactoryReceivefianl ,decDeliverdFromFactoryTotalfianl ,decClosingFianl--%> 
        <tr class="tblrowodd">
             <td colspan="4">
                 <asp:GridView ID="grdvGhatInventorySingleProduct" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="grdvGhatInventorySingleProduct_PageIndexChanging" CellPadding="4" Width="100%" PageSize="32" AllowPaging="True" HeaderStyle-BackColor="#666699" RowStyle-Wrap="true" GridLines="None" ForeColor="#333333">

                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

                                            <Columns>
                                                <asp:BoundField DataField="Sl" HeaderText=" Sl" SortExpression="Sl" ControlStyle-Width="15%" >
                                                 <ControlStyle Width="15%" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="dteTransactionfianl" HeaderText="Date" SortExpression="dteTransactionfianl"  ControlStyle-Width="10%" >
                                                <ControlStyle Width="15%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="strProductNamefianl" HeaderText="Product" SortExpression="strProductNamefianl" ControlStyle-Width="40%" >
                                                 <ControlStyle Width="40%" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="decOpeningQntfianl" HeaderText="OpeningQnt" SortExpression="decOpeningQntfianl" ControlStyle-Width="13%" >

                                                 <ControlStyle Width="10%" />
                                                </asp:BoundField>

                                                 <asp:BoundField DataField="decDeliverdFromDepotActualfianl" HeaderText="DepotDelv." SortExpression="decDeliverdFromDepotActualfianl" ControlStyle-Width="10%" >
                                                 <ControlStyle Width="10%" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="decDeliverdFromDepotPromotionfianl" HeaderText="DepotProm" SortExpression="decDeliverdFromDepotPromotionfianl" ControlStyle-Width="10%" >
                                                <ControlStyle Width="10%" />
                                                </asp:BoundField>


                                                <asp:BoundField DataField="decDeliverdFromDepotTotalfianl" HeaderText="DepotTotalDelv" SortExpression="decDeliverdFromDepotTotalfianl"  ControlStyle-Width="10%" >
                                                <ControlStyle Width="15%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="decDeliverdFromFactoryTransistfianl" HeaderText="FactoryTransit" SortExpression="decDeliverdFromFactoryActualfianl" ControlStyle-Width="40%" >
                                                 <ControlStyle Width="40%" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="decDeliverdFromFactoryReceivefianl" HeaderText="FactoryReceive" SortExpression="decDeliverdFromFactoryReceivefianl" ControlStyle-Width="13%" >

                                                 <ControlStyle Width="10%" />
                                                </asp:BoundField>

                                                 <asp:BoundField DataField="FactTotalTransf" HeaderText="FactoryRecvTotal" SortExpression="FactTotalTransf" ControlStyle-Width="10%" >
                                                 <ControlStyle Width="10%" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="ClosingStock" HeaderText="ClosingStock" SortExpression="ClosingStock" ControlStyle-Width="10%" >
                                                <ControlStyle Width="10%" />
                                                </asp:BoundField>



                                            </Columns>


                                            <EditRowStyle BackColor="#999999" />


                                            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />


                                        </asp:GridView>


              </tr>



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
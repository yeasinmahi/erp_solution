<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RptLastTransactionDateAndDelv.aspx.cs" Inherits="UI.SAD.Sales.Report.RptRemoteSales.RptLastTransactionDateAndDelv" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
   <%--<script src="../../../../Content/JS/datepickr.min.js"></script>--%>

     <link href="../../../../Content/CSS/GridHEADER.css" rel="stylesheet" />
    <script src="../../../../Content/JS/JQUERY/jquery-1.10.2.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/jquery-ui.min.js"></script>
    <script src="../../../../Content/JS/datepickr.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/MigrateJS.js"></script>
    <script src="../../../../Content/JS/JQUERY/GridviewScroll.min.js"></script>
    <script src="../../../../Content/JS/datepickr.min.js"></script>
 
    

</head>
<body>
    <form id="frmpdv" runat="server">
   <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
   
<%--=========================================Start My Code From Here===============================================--%>
        
               <div class="leaveApplication_container"> 
    <div class="tabs_container"> Customer  Transaction Exceed days Report :<asp:HiddenField ID="hdnenroll" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/><hr /></div>
        <table border="0"; style="width:Auto"; >    
        


        <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtToDate', { 'dateFormat': 'Y-m-d' });</script></td>          
        </tr>
         <tr class="tblrowodd">

          

             <td style="text-align:right"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit Name:  "></asp:Label></td>
                         
                         <td><asp:DropDownList ID="drdlUnitName"  runat="server" AutoPostBack="true" DataSourceID="odsUnitNameByEnrol" DataTextField="strUnit" DataValueField="intUnitID"></asp:DropDownList>
            
                 <asp:ObjectDataSource ID="odsUnitNameByEnrol" runat="server" SelectMethod="getUnitNamebyEnrol" TypeName="HR_BLL.TourPlan.TourPlanning">
                     <SelectParameters>
                         <asp:SessionParameter Name="Enrol" SessionField="sesUserID" Type="Int32" />
                     </SelectParameters>
                 </asp:ObjectDataSource>
            </td>
                <td style="text-align:right;"><asp:Label ID="lbl" CssClass="lbl" runat="server" Text="Sales Office:  "></asp:Label></td>
        <td><asp:DropDownList ID="drdlSalesoffice" runat="server" AutoPostBack="true" DataSourceID="odsSalesOffice" DataTextField="strName" DataValueField="intId"></asp:DropDownList>
            <asp:ObjectDataSource ID="odsSalesOffice" runat="server" SelectMethod="getSalesofficeList" TypeName="SAD_BLL.Customer.Report.StatementC">
                <SelectParameters>
                    <asp:ControlParameter ControlID="drdlUnitName" Name="unit" PropertyName="SelectedValue"  Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
             </td>
             </tr>

             <tr class="tblroweven">

                  <td style="text-align:right;"><asp:Label ID="lblLimitDays" CssClass="lbl" runat="server" Text="Limit (Days):  "></asp:Label></td>
        <td colspan="3"><asp:DropDownList ID="drdlLimitDays" runat="server" DataSourceID="odsCreditLimitIndays" DataTextField="intDaysOfCrLim" DataValueField="intSalesOffId"></asp:DropDownList>
            <asp:ObjectDataSource ID="odsCreditLimitIndays" runat="server" SelectMethod="getCreditLimitDayslist"  TypeName="SAD_BLL.Customer.Report.StatementC">
                <SelectParameters>
                    <asp:ControlParameter ControlID="drdlSalesoffice" Name="salesoffid" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
                  </td>


             </tr>

        <tr>
            <td style="text-align:right"><asp:Button ID="btnLastTransaction" runat="server" Text="Show Report" CssClass="button" OnClick="btnLastTransaction_Click" /></td>
            <td style="text-align:right"><asp:Button ID="btnExporttoExcel" runat="server" Text="Export" CssClass="button" OnClick="btnExporttoExcel_Click" /></td>
        </tr>
             
            </table>
                   </div>

        <div>
            <table>
             <tr>
                <td>
                    <asp:GridView ID="grdvLastTransactionDate" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000"  OnPageIndexChanging="grdvLastTransactionDate_PageIndexChanging" OnRowDataBound="grdvLastTransactionDate_RowDataBound" CellPadding="3" HeaderStyle-BackColor="#ffcc99"  BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" GridLines="Vertical">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>
                            
                             <asp:BoundField DataField="SL" HeaderText="Sl"  SortExpression="intSL" />
                           
                            <asp:BoundField DataField="strName" HeaderText="Name"  SortExpression="strName" />
                             <asp:BoundField DataField="intCustid" HeaderText="Custid"  SortExpression="intCustid" />
                            <asp:BoundField DataField="intCreditlimitday" HeaderText="Day"  SortExpression="intCreditlimitday" />
                            <asp:BoundField DataField="monPereopen" HeaderText="Balance"  SortExpression="monPereopen" />
                            <asp:BoundField DataField="dteLastdateDelv" HeaderText="LastDelvDate"  SortExpression="dteLastdateDelv" />
                             <asp:BoundField DataField="dteLastPaymentdate" HeaderText="LastPayment"  SortExpression="dteLastPaymentdate" />
                             <asp:BoundField DataField="dteDifferenceLastDelv" HeaderText="DelvDiffDay"  SortExpression="dteDifferenceLastDelv" />
                            <asp:BoundField DataField="dteDifflastpayment" HeaderText="TransDifDay"  SortExpression="dteDifflastpayment" />
                            <asp:BoundField DataField="exceeddays" HeaderText="ExceedDays"  SortExpression="exceeddays" />
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
  
    </form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoteCustomerStatement.aspx.cs" Inherits="UI.SAD.Sales.Report.RptRemoteSales.RemoteCustomerStatement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script src="../../../../Content/JS/datepickr.min.js"></script>
  <link href="../../../../Content/CSS/GridHEADER.css" rel="stylesheet" />
    <script src="../../../../Content/JS/JQUERY/jquery-1.10.2.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/jquery-ui.min.js"></script>
    <script src="../../../../Content/JS/datepickr.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/MigrateJS.js"></script>
    <script src="../../../../Content/JS/JQUERY/GridviewScroll.min.js"></script>
    
       <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtFullName.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/ClassFiles/AutoCompleteSearch.asmx/GetTerCustomerCOAid") %>',
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
  
<%--=========================================Start My Code From Here===============================================--%>



         
               <div class="leaveApplication_container"> 
    <div class="tabs_container"> Customer Statement Report :<asp:HiddenField ID="hdnenroll" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/><hr /></div>
        <table border="0"; style="width:Auto"; >    
        <tr class="tblrowodd">
        <td style="text-align:right;"><asp:Label ID="lblfullname" CssClass="lbl" runat="server" Text="Customer Name: "></asp:Label></td>
        <td><asp:TextBox ID="txtFullName" runat="server" CssClass="txtBox" AutoPostBack="false"></asp:TextBox></td>
        <td style="text-align:right;" colspan="2"></td>
        </tr>


        <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtToDate', { 'dateFormat': 'Y-m-d' });</script></td>          
        </tr>

        <tr><td style="text-align:right" colspan="3"><asp:Button ID="btnCustomerStatementRepot" runat="server" Text="Show Report" CssClass="button" OnClick="btnCustomerStatementRepot_Click"  /></td>
              <td> <asp:Button ID="btnExportToExcel" runat="server" Text="Download" OnClick="btnExportToExcel_Click" /></td>
       </tr>
             <tr class="tblrowodd">
             <td colspan="4">
                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" ForeColor="Black" Width="100%" PageSize="1000" AllowPaging="True" HeaderStyle-BackColor="#666699" CellSpacing="2" RowStyle-Wrap="true">

                                            <Columns>
                                                <asp:BoundField DataField="TransactionDate" HeaderText=" Transaction Date" SortExpression="dtedate" ControlStyle-Width="15%" >
                                                 <ControlStyle Width="15%" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="NameCode" HeaderText="Challan No." SortExpression="strChal"  ControlStyle-Width="10%" >
                                                <ControlStyle Width="15%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Descriptions" HeaderText="Description" SortExpression="strDES" ControlStyle-Width="40%" >
                                                 <ControlStyle Width="40%" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="Debit" HeaderText="Debit" SortExpression="monDeb" ControlStyle-Width="13%" >

                                                 <ControlStyle Width="10%" />
                                                </asp:BoundField>

                                                 <asp:BoundField DataField="Credit" HeaderText="Credit" SortExpression="monCredi" ControlStyle-Width="10%" >
                                                 <ControlStyle Width="10%" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="OutstandingBalance" HeaderText="Outstanding" SortExpression="monOuts" ControlStyle-Width="10%" >


                                                <ControlStyle Width="10%" />
                                                </asp:BoundField>


                                            </Columns>


                                            <FooterStyle BackColor="#CCCCCC" />
                                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                                            <RowStyle BackColor="White" />
                                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#808080" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#383838" />


                                        </asp:GridView>


              </tr>



             </td>
          </tr>





        </table>



    </div>

<%--=========================================End My Code From Here=================================================--%>
  <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>
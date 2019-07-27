<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RetaillerMonthlyTargetInput.aspx.cs" Inherits="UI.SAD.Sales.Report.RptRemoteSales.RetaillerMonthlyTargetInput" %>

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
                SearchText();
            });
            function Changed() {
                document.getElementById('hdfSearchBoxTextChange').value = 'true';
            }
            function SearchText() {
                $("#txtcus").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            type: "POST",
                            contentType: "application/json;",
                            url: "RetaillerMonthlyTargetInput.aspx/GetAutoCompletecustomer",
                            data: "{'strSearchKey':'" + document.getElementById('txtcus').value + "'}",
                            dataType: "json",
                            success: function (data) {
                                response(data.d);
                            },
                            error: function (result) {
                                alert("Error");
                            }
                        });
                    }
                });
            }


    </script>
    
</head>
<body>
    <form id="frmpdv" runat="server">
     <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>

  
<%--=========================================Start My Code From Here===============================================--%>



         
               <div class="leaveApplication_container"> 
    <div class="tabs_container"> Retailler Target Input :<asp:HiddenField ID="hdnenroll" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
        <asp:HiddenField ID="hdnemail" runat="server"/><asp:HiddenField ID="hdnconfirm" runat="server" />
        <hr /></div>
        <table border="0"; style="width:Auto"; >    
        <tr class="tblrowodd">
        <td style="text-align:right;"><asp:Label ID="lblfullname" CssClass="lbl" runat="server" Text="Customer Name: "></asp:Label></td>
        <td colspan="4"><asp:TextBox ID="txtcus" runat="server" BackColor="#ff6666" AutoPostBack="True" CssClass="txtBox"  Width="200px" ></asp:TextBox>
            </td>
        </tr>


        <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtToDate', { 'dateFormat': 'Y-m-d' });</script></td>          
        </tr>

        <tr><td style="text-align:right" colspan="2"><asp:Button ID="btnShopTargetInput" runat="server" Text="Shop information" CssClass="button" OnClick="btnShopTargetInput_Click"  /></td>
              <td> <asp:Button ID="btnExportToExcel" runat="server" Text="Download" OnClick="btnExportToExcel_Click" /></td>
            <td> <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" OnClientClick="Confirm()" /></td>
        </tr>
             <tr class="tblrowodd">
             <td colspan="4">
                 <asp:GridView ID="grdvShopTargetinput" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="grdvShopTargetinput_PageIndexChanging" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" Width="100%"  HeaderStyle-BackColor="#666699" RowStyle-Wrap="true" GridLines="Vertical">

                     <AlternatingRowStyle BackColor="#CCCCCC" />

                <Columns>
                
                <asp:TemplateField><HeaderTemplate>    
                <asp:CheckBox ID="chkbx" runat="server" onclick="CheckAll(this);" />   
                </HeaderTemplate>  
                <ItemTemplate><asp:CheckBox ID="chkbx" runat="server"/></ItemTemplate></asp:TemplateField>
                 <asp:BoundField DataField="intshopid" HeaderText="Shop id" SortExpression="intshopid" />
                <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %>
                 <asp:HiddenField runat="server" ID="hdnshopid" Value='<%# Eval("intshopid") %>' />
                <asp:HiddenField runat="server" ID="hdnCustomerID" Value='<%# Eval("intcustomerid") %>' />
                <asp:HiddenField runat="server" ID="hdnTerritoryid" Value='<%# Eval("intterritoryid") %>' />
                <asp:HiddenField runat="server" ID="hdnSalesoffid" Value='<%# Eval("intsalesofficeid") %>' />
                <asp:HiddenField runat="server" ID="hdnunitid" Value='<%# Eval("intunitid") %>' />
                </ItemTemplate></asp:TemplateField>            
                <asp:BoundField DataField="strShopname" HeaderText="Shop Name" SortExpression="strShopname" />
                <asp:TemplateField HeaderText="Target Qnt" SortExpression="CostRation">
                <ItemTemplate>
                <asp:HiddenField  ID="hddecTarget"  runat="server" Value='<%# Bind("decTarget", "{0:0.0}") %>'></asp:HiddenField>
                <asp:TextBox ID="txtdecTarget"  CssClass="txtBox" runat="server" Width="60"  Text='<%# Bind("decTarget") %>'></asp:TextBox></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="35" />
                </asp:TemplateField>
                 <asp:BoundField DataField="decSales" HeaderText="Sales Qnt" SortExpression="decSales" />
                <asp:BoundField DataField="strshopaddress" HeaderText="Shop Address" SortExpression="strshopaddress" />
              <asp:BoundField DataField="strTer" HeaderText="Territory" SortExpression="strTerrit" />
              
   
                  </Columns>
                   <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
               <HeaderStyle CssClass="GridviewScrollHeader"/><PagerStyle CssClass="GridviewScrollPager"/>  </asp:GridView>
                 </tr>
                </table>



    </div>

<%--=========================================End My Code From Here=================================================--%>
  <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>
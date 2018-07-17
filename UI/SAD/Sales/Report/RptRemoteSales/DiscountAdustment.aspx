<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DiscountAdustment.aspx.cs" Inherits="UI.SAD.Sales.Report.RptRemoteSales.DiscountAdustment" %>

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
    $(document).ready(function () { GridviewScroll(); });
    function GridviewScroll() {
        $('#<%=grdvDiscountAdjustment.ClientID%>').gridviewScroll({
        width: 1024,
        height: 500,
        startHorizontal: 0,
        wheelstep: 10,
        barhovercolor: "#3399FF",
        barcolor: "#3399FF"
    });
}
    function ViewConfirm(id) { document.getElementById('hdnDivision').style.visibility = 'visible'; }
   function CheckAll(Checkbox) {
        var GridVwHeaderCheckbox = document.getElementById("<%=grdvDiscountAdjustment.ClientID %>");
        for (i = 1; i < GridVwHeaderCheckbox.rows.length; i++) {
            GridVwHeaderCheckbox.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
            
        }
    }
       function Confirm() {
           document.getElementById("hdnconfirm").value = "0";
           var confirm_value = document.createElement("INPUT");
               confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
               if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
               else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
           }
       
</script>
      
</head>
<body>
    <form id="frmpdv" runat="server">
   <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
   

<%--=========================================Start My Code From Here===============================================--%>
          <div class="leaveApplication_container"> 
    <div class="tabs_container"> Discount Adjustment Commission :<asp:HiddenField ID="hdnenroll" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
        <asp:HiddenField ID="hdnemail" runat="server"/><asp:HiddenField ID="hdnconfirm" runat="server" />
        <hr /></div>
        <table border="0"; style="width:Auto"; >    


        <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtToDate', { 'dateFormat': 'Y-m-d' });</script></td>          
        </tr>
       <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblTotalcom" CssClass="lbl" runat="server" Text="Total Commission:  "></asp:Label></td>
        <td><asp:Label ID="lbltotalcomamount" CssClass="lbl" runat="server" Text=""></asp:Label></td>
          <td style="text-align:right;"><asp:Label ID="lblTotalcashdoqnt" CssClass="lbl" runat="server" Text="Cash D.O Qnt:  "></asp:Label></td>
        <td><asp:Label ID="lblcashdoqnt" CssClass="lbl" runat="server" Text=""></asp:Label></td>

         <tr class="tblrowOdd">
      <td style="text-align:right"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit Name:  "></asp:Label></td>
                         
                         <td><asp:DropDownList ID="drdlUnitName"  runat="server" DataSourceID="odsUnitNameByEnrol" AutoPostBack="true" DataTextField="strUnit" DataValueField="intUnitID" OnSelectedIndexChanged="drdlUnitName_SelectedIndexChanged"></asp:DropDownList>
            
                 <asp:ObjectDataSource ID="odsUnitNameByEnrol" runat="server" SelectMethod="getUnitNamebyEnrol" TypeName="HR_BLL.TourPlan.TourPlanning">
                     <SelectParameters>
                         <asp:SessionParameter Name="Enrol" SessionField="sesUserID" Type="Int32" />
                     </SelectParameters>
                 </asp:ObjectDataSource>
            </td>
             <td style="text-align:right"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="COA Name:  "></asp:Label></td>
                                <td><asp:DropDownList ID="ddlcoa" runat="server" DataSourceID="odscoa" DataTextField="strAccName" DataValueField="intAccID"></asp:DropDownList>
                                  
                                    <asp:ObjectDataSource ID="odscoa" runat="server" SelectMethod="getdataChartofAccountHead" TypeName="SAD_BLL.Customer.Report.StatementC">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="drdlUnitName" DefaultValue="4" Name="unitid" PropertyName="SelectedValue" Type="Int32" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                  
             </td>
                          
              </tr>
           <tr class="tblrowOdd">
    
             <td style="text-align:right"><asp:Label ID="lblsalesviewtype" CssClass="lbl" runat="server" Text="Sales View:  "></asp:Label></td>
                                <td><asp:DropDownList ID="drdlSalesview" runat="server" DataSourceID="odsSalesviewType" DataTextField="strReportType" DataValueField="intID"></asp:DropDownList>
                                 <asp:ObjectDataSource ID="odsSalesviewType" runat="server" SelectMethod="getdataSalesCommissionReportType" TypeName="SAD_BLL.Customer.Report.StatementC"></asp:ObjectDataSource></td>

               <td style="text-align:right"><asp:Label ID="lblSalesOfficetype" CssClass="lbl" runat="server" Text="Sales Office:  "></asp:Label></td>
                                <td> <asp:DropDownList ID="ddlSo" runat="server" AutoPostBack="True" DataSourceID="ods2"
                                    DataTextField="strName" DataValueField="intSalesOffId" OnDataBound="ddlSo_DataBound"
                                    OnSelectedIndexChanged="ddlSo_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ods2" runat="server" SelectMethod="GetSalesOfficeWithAll" TypeName="SAD_BLL.Global.SalesOffice"
                                    OldValuesParameterFormatString="original_{0}">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="userId" SessionField="sesUserID" Type="String" />
                                        <asp:ControlParameter ControlID="drdlUnitName" Name="unitId" PropertyName="SelectedValue"
                                            Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource> </td>  </tr>


             <tr class="tblrowOdd">
    
             
                <td style="text-align:right"><asp:Label ID="lblcreatedjv" CssClass="lbl" runat="server" Text="Journal Voucher No.:  "></asp:Label></td>                   
                <td style="text-align:right"><asp:Label ID="lblCreatedjvnumber" CssClass="lbl" runat="server"></asp:Label></td> 

                </tr>

         
            <tr class="tblrowOdd"><td style="text-align:right" > <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                <td style="text-align:right"> <asp:Button ID="btnJVCreation" runat="server" Text="JV Creation" OnClick="btnJVCreation_Click" OnClientClick="Confirm()" /></td>
            </tr>
            </table>
                      
            </div>
         <div class="leaveApplication_container"> 
             <table>
                 <tr class="tblroweven"><td>
              <asp:GridView ID="grdvDiscountAdjustment" runat="server" AutoGenerateColumns="False" AllowPaging="false"  BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdvDiscountAdjustment_PageIndexChanging" OnRowDataBound="grdvDiscountAdjustment_RowDataBound" >
                  <AlternatingRowStyle BackColor="#CCCCCC" />
                  <Columns>
                     
                      <asp:TemplateField><HeaderTemplate>    
                <asp:CheckBox ID="chkbx" runat="server" onclick="CheckAll(this);" />   
                </HeaderTemplate>  
                <ItemTemplate><asp:CheckBox ID="chkbx" runat="server"/></ItemTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="Sl"> <ItemTemplate> <%#Container.DataItemIndex+1 %> 
                    <asp:HiddenField ID="hdncustid" runat="server" Value='<%# Eval("intCustid") %>' />
                    <asp:HiddenField ID="hdncustcoaid" runat="server" Value='<%# Eval("intCOId1") %>' />
                     <asp:HiddenField ID="hdncustnarrationindividual" runat="server" Value='<%# Eval("Narration1") %>' />
                    <asp:HiddenField ID="hdncustomercommissionndividual" runat="server" Value='<%# Eval("monCashCommission1") %>' />
                    <asp:HiddenField ID="hdncustname" runat="server" Value='<%# Eval("strCustName1") %>' />
                    </ItemTemplate></asp:TemplateField>
                    <asp:BoundField DataField="strCustName1" HeaderText="Name" SortExpression="strCustName" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="intTotalNumberDO1" HeaderText="TotalNumberDO" SortExpression="intTotalNumberDO" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="decTotalDelv1" HeaderText="TotalDelv" SortExpression="decTotalDelv" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                  
                    <asp:BoundField DataField="monCashCommission1" HeaderText="AdjustableAmount" SortExpression="monCashCommission" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                   
                       <asp:BoundField DataField="Narration1" HeaderText="Narration" SortExpression="Narration1" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                    <HeaderStyle CssClass="GridviewScrollHeader"/><PagerStyle CssClass="GridviewScrollPager"/>
                        </asp:GridView> </td></tr>   
                    </table>
             </div>



<%--=========================================End My Code From Here=================================================--%>
       
    </form>
</body>
</html>
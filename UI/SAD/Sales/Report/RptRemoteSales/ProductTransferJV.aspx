<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductTransferJV.aspx.cs" Inherits="UI.SAD.Sales.Report.RptRemoteSales.ProductTransferJV" %>

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
        $('#<%=grdvcommoncommission.ClientID%>').gridviewScroll({
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
        var GridVwHeaderCheckbox = document.getElementById("<%=grdvcommoncommission.ClientID %>");
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
    <div class="tabs_container">Commission  Adjustment  :<asp:HiddenField ID="hdnenroll" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
        <asp:HiddenField ID="hdnemail" runat="server"/><asp:HiddenField ID="hdnconfirm" runat="server" />
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
                                <td> <asp:DropDownList ID="ddlSo" runat="server" AutoPostBack="True" DataSourceID="odsTransferProductSOF" DataTextField="strSalesOffice" DataValueField="intID">
                                </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsTransferProductSOF" runat="server" SelectMethod="getTransferProductSalesOffice" TypeName="SAD_BLL.Sales.SalesView"></asp:ObjectDataSource>
                              </td>  </tr>

           <tr class="tblrowOdd">
    
             <td style="text-align:right"><asp:Label ID="lblFactrate" CssClass="lbl" runat="server" Text="Factory Rate:  "></asp:Label></td>
                                <td><asp:TextBox ID="txtfactrate" CssClass="txtbox" runat="server"></asp:TextBox></td>

              <td style="text-align:right"><asp:Label ID="lblGhatRate" CssClass="lbl" runat="server" Text="Ghat Rate:  "></asp:Label></td>
                                <td><asp:TextBox ID="txtghatRate" runat="server" CssClass="txtbox" ></asp:TextBox></td>  </tr>




             <tr class="tblrowOdd">
       <td style="text-align:right"><asp:Label ID="lbltype" CssClass="lbl" runat="server" Text="Report type:  "></asp:Label></td>
                                <td><asp:DropDownList ID="ddldettopsheet" runat="server">
                                    <asp:ListItem Text="Detaills " Value="1"></asp:ListItem>
                                    <asp:ListItem Text="TopSheet" Value="2"></asp:ListItem>
                                    
                                    </asp:DropDownList>
                                </td>
             
                <td style="text-align:right"><asp:Label ID="lblcreatedjv" CssClass="lbl" runat="server" Text="Journal Voucher No.:  "></asp:Label></td>                   
                <td style="text-align:right"><asp:Label ID="lblCreatedjvnumber" CssClass="lbl" runat="server"></asp:Label></td> 

                </tr>

         
            <tr class="tblrowOdd"><td style="text-align:right" > <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                <td style="text-align:right"> <asp:Button ID="btnJVCreation" runat="server" Text="JV Creation" OnClick="btnJVCreation_Click" OnClientClick="Confirm()" /></td>
  
                <td style="text-align:right"> <asp:Button ID="btnExportToExcel" runat="server" Text="Export" OnClick="btnExportToExcel_Click" /></td>
            </tr>
            </table>
                      
            </div>
         <div class="leaveApplication_container"> 
             <table>
                 <tr class="tblroweven"><td>
              <asp:GridView ID="grdvcommoncommission" runat="server" AutoGenerateColumns="False" AllowPaging="false"  BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdvcommoncommission_PageIndexChanging" OnRowDataBound="grdvcommoncommission_RowDataBound" >
                  <AlternatingRowStyle BackColor="#CCCCCC" />
               <Columns>
                     
                      <asp:TemplateField><HeaderTemplate>    
                <asp:CheckBox ID="chkbx" runat="server" onclick="CheckAll(this);" />   
                </HeaderTemplate>  
                <ItemTemplate><asp:CheckBox ID="chkbx" runat="server"/></ItemTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="Sl"> <ItemTemplate> <%#Container.DataItemIndex+1 %> 
                    <asp:HiddenField ID="hdncustid" runat="server" Value='<%# Eval("intCustid") %>' />
                    <asp:HiddenField ID="hdncustcoaid" runat="server" Value='<%# Eval("intCOId1") %>' />
                     <asp:HiddenField ID="hdncustnarrationindividual" runat="server" Value='<%# Eval("strnarration") %>' />
                    <asp:HiddenField ID="hdncustomercommissionndividual" runat="server" Value='<%# Eval("commissonamount") %>' />
                    <asp:HiddenField ID="hdncustname" runat="server" Value='<%# Eval("strname1") %>' />
                    </ItemTemplate></asp:TemplateField>
                    <asp:BoundField DataField="strname1" HeaderText="Name" SortExpression="strCustName" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="factory1" HeaderText="Factory Delv" SortExpression="factory1" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="total1" HeaderText="TotalDelv" SortExpression="total1" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                  
                    <asp:BoundField DataField="commissonamount" HeaderText="AdjustableAmount" SortExpression="monCashCommission" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                   
                       <asp:BoundField DataField="strnarration" HeaderText="Narration" SortExpression="strnarration" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
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
         <div class="leaveApplication_container"> 
             <table>
                 <tr class="tblroweven"><td>
              <asp:GridView ID="grdvDetaillsReport" runat="server" AutoGenerateColumns="False"  BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnPageIndexChanging="grdvDetaillsReport_PageIndexChanging" ShowFooter="True" OnRowDataBound="grdvDetaillsReport_RowDataBound" GridLines="Vertical" >
                  <AlternatingRowStyle BackColor="#DCDCDC" />
                  <Columns>
                     
                
                    <asp:TemplateField HeaderText="Sl"> <ItemTemplate> <%#Container.DataItemIndex+1 %> 
                    
                    </ItemTemplate></asp:TemplateField>
                    <asp:BoundField DataField="strname1" HeaderText="Name" SortExpression="strCustName" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strterritory1" HeaderText="Territory" SortExpression="strterritory1" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="strarea1" HeaderText="Area" SortExpression="strarea1" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                  
                    <asp:BoundField DataField="strregion1" HeaderText="Region" SortExpression="strregion1" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                   
                    <asp:BoundField DataField="total1" HeaderText="Total Delv. Qnt" SortExpression="total1" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="factory1" HeaderText="Fact. Delv Qnt" SortExpression="factory1" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="ghat1" HeaderText="Ghat Delv Qnt" SortExpression="ghat1" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="commissonamount" HeaderText="Commisson amount" SortExpression="commissonamount" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                 
                  
                  
                  
                  </Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle ForeColor="Black" BackColor="#EEEEEE" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                    <HeaderStyle CssClass="GridviewScrollHeader"/><PagerStyle CssClass="GridviewScrollPager"/>
                        </asp:GridView> </td></tr>   
                    </table>
             </div>
        <div class="leaveApplication_container"> 
             <table>
                 <tr class="tblroweven"><td>
              <asp:GridView ID="grdvDetDistIHB" runat="server" AutoGenerateColumns="False"  BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnPageIndexChanging="grdvDetaillsReport_PageIndexChanging" ShowFooter="True" OnRowDataBound="grdvDetaillsReport_RowDataBound" CellSpacing="2" >
                  <Columns>
                     
                
                    <asp:TemplateField HeaderText="Sl"> <ItemTemplate> <%#Container.DataItemIndex+1 %> 
                    
                    </ItemTemplate></asp:TemplateField>
                    <asp:BoundField DataField="strName1" HeaderText="Name" SortExpression="strCustName" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strTerritory1" HeaderText="Territory" SortExpression="strterritory1" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="strArea1" HeaderText="Area" SortExpression="strarea1" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                  
                    <asp:BoundField DataField="strRegion1" HeaderText="Region" SortExpression="strregion1" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                   
                    <asp:BoundField DataField="EntpDelv" HeaderText="Enterprise Delv Qnt" SortExpression="total1" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="IHBDelv" HeaderText="IHB Delv Qnt" SortExpression="IHBDelv" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="decTarget1" HeaderText="Target Qnt" SortExpression="decTarget1" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="totalsales" HeaderText="Total Delv Qnt" SortExpression="totalsales" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    
                      <asp:BoundField DataField="percentag" HeaderText="Achievement" SortExpression="IHBDelv" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="Commission rate" HeaderText="Commission Rate" SortExpression="Commission rate" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="Commission Total" HeaderText="Commission Total" SortExpression="Commission Total" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                 
                  
                  
                  
                  </Columns>
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                    <HeaderStyle CssClass="GridviewScrollHeader"/><PagerStyle CssClass="GridviewScrollPager"/>
                        </asp:GridView> </td></tr>   
                    </table>
             </div>
      




<%--=========================================End My Code From Here=================================================--%>
       
    </form>
</body>
</html>

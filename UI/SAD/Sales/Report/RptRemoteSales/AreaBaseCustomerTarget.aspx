<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AreaBaseCustomerTarget.aspx.cs" Inherits="UI.SAD.Sales.Report.RptRemoteSales.AreaBaseCustomerTarget" %>

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
        $('#<%=grdvCustomerTarget.ClientID%>').gridviewScroll({
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
        var GridVwHeaderCheckbox = document.getElementById("<%=grdvCustomerTarget.ClientID %>");
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
    <div class="tabs_container"> Customer Target Input :<asp:HiddenField ID="hdnenroll" runat="server"/>
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
            <tr class="tblrowodd">
                <td style="text-align:right;"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit Name:  "> </asp:Label>
                   

                         
                         <td style="text-align:right;"><asp:DropDownList ID="drdlUnitName"  runat="server" CssClass="ddList" DataSourceID="odsUnitNameByEnrol" AutoPostBack="true" DataTextField="strUnit" DataValueField="intUnitID" OnSelectedIndexChanged="drdlUnitName_SelectedIndexChanged"></asp:DropDownList>
            
                 <asp:ObjectDataSource ID="odsUnitNameByEnrol" runat="server" SelectMethod="getUnitNamebyEnrol" TypeName="HR_BLL.TourPlan.TourPlanning">
                     <SelectParameters>
                         <asp:SessionParameter Name="Enrol" SessionField="sesUserID" Type="Int32" />
                     </SelectParameters>
                 </asp:ObjectDataSource>
                            
            </td>


            <td style="text-align:right;"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Region : "></asp:Label></td>
               <td>
                    <asp:DropDownList ID="drdlRegionName" runat="server" CssClass="ddList" AutoPostBack="True" DataSourceID="odsUnitvsRegion" DataTextField="strText" DataValueField="intID"></asp:DropDownList>
                  <asp:ObjectDataSource ID="odsUnitvsRegion" runat="server" SelectMethod="GetRegionbyUnit" TypeName="SAD_BLL.Sales.SalesConfig">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="drdlUnitName" Name="unit" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>


                        

                </td>
    
           
               </tr>

            <tr class="tblroweven">
                 <td style="text-align:right;"><asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Area / Zone : "></asp:Label>
                                
                 </td>
                <td><asp:DropDownList ID="drdlArea" runat="server" CssClass="ddList" AutoPostBack="True" DataSourceID="odsAreaName" DataTextField="strText" DataValueField="intID"></asp:DropDownList>

                       

                    <asp:ObjectDataSource ID="odsAreaName" runat="server" SelectMethod="GetAreaName" TypeName="SAD_BLL.Sales.SalesConfig">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="drdlUnitName" Name="unit" PropertyName="SelectedValue" Type="Int32" />
                            <asp:ControlParameter ControlID="drdlRegionName" Name="Region" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>

                       
                 

                       
                </td>
                
                <td><asp:Label ID="Label4" CssClass="lbl" runat="server" Text="Teritory / Base : "></asp:Label>
                    



                        
                 </td>
                <td><asp:DropDownList ID="drdlTerritory" runat="server" CssClass="ddList" DataSourceID="odsAreavsTerritory" DataTextField="strText" DataValueField="intID"></asp:DropDownList>


                        
                    <asp:ObjectDataSource ID="odsAreavsTerritory" runat="server" SelectMethod="GetTerritoryName" TypeName="SAD_BLL.Sales.SalesConfig">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="drdlUnitName" Name="unit" PropertyName="SelectedValue" Type="Int32" />
                            <asp:ControlParameter ControlID="drdlArea" Name="Area" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>

                 </td>
                 </tr>
              <tr class="tblrowodd">
                     <td>
                         <asp:Label id="lblrptytpe" runat="server" Text="Report Type"></asp:Label>
                     </td>
                     <td>
                         <asp:DropDownList ID="drdlrpttype" runat="server" CssClass="ddList">
                             <asp:ListItem Selected="True" Text="Customer Target Entry" Value="1"></asp:ListItem>
                                <asp:ListItem  Text="Customer Target Submit" Value="2"></asp:ListItem>
                              <asp:ListItem  Text="Customer Target Report" Value="3"></asp:ListItem>
                              



                         </asp:DropDownList>
                     </td>
                    <td>
                      <asp:Label ID="lblSalesoffice" runat="server" Text="SalesOffice"></asp:Label>
                      <td>
                                <asp:DropDownList ID="ddlSo" runat="server" AutoPostBack="True" DataSourceID="ods2"
                                    DataTextField="strName" DataValueField="intSalesOffId" 
                                    OnSelectedIndexChanged="ddlSo_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ods2" runat="server" SelectMethod="GetSalesOfficeWithAll" TypeName="SAD_BLL.Global.SalesOffice"
                                    OldValuesParameterFormatString="original_{0}">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="userId" SessionField="sesUserID" Type="String" />
                                        <asp:ControlParameter ControlID="drdlUnitName" Name="unitId" PropertyName="SelectedValue"
                                            Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                  </td>
                  </tr>
        <tr><td style="text-align:right" colspan="2"><asp:Button ID="btncustomertarget" runat="server" Text="Show" CssClass="button" OnClick="btncustomertarget_Click"  /></td>
             
            <td> <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" OnClientClick="Confirm()" /></td>
        </tr>
             <tr class="tblrowodd">
             <td colspan="4">
                 <asp:GridView ID="grdvCustomerTarget" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="grdvCustomerTarget_PageIndexChanging" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" Width="100%"  HeaderStyle-BackColor="#666699" RowStyle-Wrap="true" GridLines="Vertical">

                     <AlternatingRowStyle BackColor="#CCCCCC" />

                <Columns>
                
                <asp:TemplateField><HeaderTemplate>    
                <asp:CheckBox ID="chkbx" runat="server" onclick="CheckAll(this);" />   
                </HeaderTemplate>  
                <ItemTemplate><asp:CheckBox ID="chkbx" runat="server"/></ItemTemplate></asp:TemplateField>
                
                <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %>
                
                <asp:HiddenField runat="server" ID="hdnCustomerID" Value='<%# Eval("custid") %>' />
                <asp:HiddenField runat="server" ID="hdnTerritoryid" Value='<%# Eval("intTerritory") %>' />
                <asp:HiddenField runat="server" ID="hdnAreaid" Value='<%# Eval("intArea") %>' />
                 <asp:HiddenField runat="server" ID="hdncustname" Value='<%# Eval("custname") %>' />
                <asp:HiddenField runat="server" ID="hdnSalesoffid" Value='<%# Eval("intsalesofficeid") %>' />
                <asp:HiddenField runat="server" ID="hdnunitid" Value='<%# Eval("intunitid") %>' />
                </ItemTemplate></asp:TemplateField>   
                     <asp:BoundField DataField="custid" HeaderText="Customer ID" SortExpression="custname" />
                <asp:BoundField DataField="custname" HeaderText="Customer Name" SortExpression="custname" />
                <asp:TemplateField HeaderText="Target Qnt" SortExpression="CostRation">
                <ItemTemplate>
                <asp:HiddenField  ID="hddecTarget"  runat="server" Value='<%# Bind("decTarget", "{0:0.0}") %>'></asp:HiddenField>
                <asp:TextBox ID="txtdecTarget"  CssClass="txtBox" runat="server" Width="60"  Text='<%# Bind("decTarget") %>'></asp:TextBox></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="35" />
                </asp:TemplateField>
                 <asp:BoundField DataField="straddress" HeaderText="Address" SortExpression="straddress" />
                    <asp:BoundField DataField="strterritory" HeaderText="Territory" SortExpression="strTerrit" />
                <asp:BoundField DataField="strArea" HeaderText="Area" SortExpression="strArea" />
              
              
   
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

            <tr class="tblrowodd">
             <td colspan="4">
                 <asp:GridView ID="grdvTargetinserted" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="grdvTargetinserted_PageIndexChanging" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" ForeColor="Black" Width="100%"  HeaderStyle-BackColor="#666699" RowStyle-Wrap="true" CellSpacing="2">

                <Columns>
                
           
                
                <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %>
                
                <asp:HiddenField runat="server" ID="hdnCustomerID" Value='<%# Eval("custid") %>' />
                <asp:HiddenField runat="server" ID="hdnTerritoryid" Value='<%# Eval("intTerritory") %>' />
                <asp:HiddenField runat="server" ID="hdnAreaid" Value='<%# Eval("intArea") %>' />
                 <asp:HiddenField runat="server" ID="hdncustname" Value='<%# Eval("custname") %>' />
                <asp:HiddenField runat="server" ID="hdnSalesoffid" Value='<%# Eval("intsalesofficeid") %>' />
                <asp:HiddenField runat="server" ID="hdnunitid" Value='<%# Eval("intunitid") %>' />
                </ItemTemplate></asp:TemplateField>   
                     <asp:BoundField DataField="custid" HeaderText="Customer ID" SortExpression="custname" />
                <asp:BoundField DataField="custname" HeaderText="Customer Name" SortExpression="custname" />
                 <asp:BoundField DataField="decTarget" HeaderText="Target Qnt" SortExpression="custname" />
                 <%--<asp:BoundField DataField="straddress" HeaderText="Address" SortExpression="straddress" />--%>
                    <asp:BoundField DataField="strterritory" HeaderText="Territory" SortExpression="strTerrit" />
                <asp:BoundField DataField="strArea" HeaderText="Area" SortExpression="strArea" />
              
              
   
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
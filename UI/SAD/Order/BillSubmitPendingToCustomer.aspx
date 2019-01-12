<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillSubmitPendingToCustomer.aspx.cs" Inherits="UI.SAD.Order.BillSubmitPendingToCustomer" %>

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
        $('#<%=dgvCustomervsReturnqnt.ClientID%>').gridviewScroll({
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
        var GridVwHeaderCheckbox = document.getElementById("<%=dgvCustomervsReturnqnt.ClientID %>");
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
         <script type="text/javascript">
         function Registration(url) {
             window.open('BillSubmitPendingToCustomerDet.aspx?ID=' + url, '', "height=2024, width=750, scrollbars=yes, left=50, top=10, resizable=yes, title=Preview");
                  }
</script>
      <%--  <script type="text/javascript">
    $(document).ready(function () {    
    SearchText();
});
function Changed() {
    document.getElementById('hdfSearchBoxTextChange').value = 'true';
}
function SearchText() {
    $("#txtCus").autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json;",
                url: "BillSubmitPendingToCustomer.aspx/GetAutoserachingAssetName",
                data: "{'strSearchKey':'" + document.getElementById('txtCus').value + "'}",
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


    </script>--%>
</head>
<body>
    <form id="frmpdv" runat="server">
     <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>

  
<%--=========================================Start My Code From Here===============================================--%>



         
               <div class="leaveApplication_container"> 
    <div class="tabs_container"> Customer Return Qnt  :<asp:HiddenField ID="hdnenroll" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
        <asp:HiddenField ID="hdnemail" runat="server"/><asp:HiddenField ID="hdnconfirm" runat="server" />
        <asp:HiddenField ID="hdncustomerid" runat="server" />
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
            <tr class="tblrowodd">
                <td style="text-align:right;"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit Name:  "> </asp:Label>
                   
                     <%--DataSourceID="odsUnit" DataTextField="strUnit" DataValueField="intUnitID"--%>
                         
                         <td style="text-align:right;"> <asp:DropDownList ID="drdlUnitName" runat="server" AutoPostBack="True" 
                                                OnDataBound="drdlUnitName_DataBound" 
                                                onselectedindexchanged="drdlUnitName_SelectedIndexChanged" DataSourceID="odsunitname" DataTextField="strUnit" DataValueField="intUnitID">
                                            </asp:DropDownList>
                                           <asp:ObjectDataSource ID="odsunitname" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
                                               <SelectParameters>
                                                   <asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String" />
                                               </SelectParameters>
                             </asp:ObjectDataSource>
                                           <%-- <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
                                                <SelectParameters>
                                                    <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>--%>
                            
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
                         <asp:DropDownList ID="drdlrpttype" runat="server" CssClass="ddList" OnSelectedIndexChanged="drdlrpttype_SelectedIndexChanged">
                             <asp:ListItem Selected="True" Text="Customer Return Qnt Entry" Value="1"></asp:ListItem>
                                <asp:ListItem  Text="Customer Return Qnt Submit" Value="2"></asp:ListItem>
                              <asp:ListItem  Text="Customer Return Qnt Report" Value="3"></asp:ListItem>
                                <asp:ListItem  Text="Customer Bill Copy Topsheet" Value="4"></asp:ListItem>



                         </asp:DropDownList>
                     </td>
                    <td>
                      <asp:Label ID="lblSalesoffice" runat="server" Text="SalesOffice"></asp:Label> </td>
                             
                      <td>
                                <asp:DropDownList ID="ddlSo" runat="server" AutoPostBack="True" DataSourceID="ods2"
                                    DataTextField="strName" DataValueField="intSalesOffId" 
                                    OnSelectedIndexChanged="ddlSo_SelectedIndexChanged" OnDataBound="ddlSo_DataBound">
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
                 
                  </tr>

            <tr>
                <td>
                                Customer
                            </td>
                           <td colspan="3"> <asp:TextBox ID="txtCus" runat="server" BackColor="#fffff6" AutoPostBack="false" CssClass="txtBox"  Width="400px" ></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtCus"
                                            ServiceMethod="GetCustomerListunitbase" MinimumPrefixLength="1" CompletionSetCount="1"
                                            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                        </cc1:AutoCompleteExtender>

                           </td>


            </tr>
        <tr><td style="text-align:right" colspan="2"><asp:Button ID="btncustomertarget" runat="server" Text="Show" CssClass="button" OnClick="btncustomertarget_Click"  /></td>
             
            <td> <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" OnClientClick="Confirm()" /></td>
        </tr>
            </table>
                   </div>
        <div>
            <table>
             <tr class="tblrowodd">
             <td colspan="4">
                 <asp:GridView ID="dgvCustomervsReturnqnt" runat="server"  AllowPaging="false" PageSize="11125" OnPageIndexChanging="dgvCustomervsReturnqnt_PageIndexChanging"  AutoGenerateColumns="false" CellPadding="5" ShowFooter="true">
                          
                    <Columns>
                        <asp:TemplateField><HeaderTemplate>    
                <asp:CheckBox ID="chkbx" runat="server" onclick="CheckAll(this);" />   
                </HeaderTemplate>  
                <ItemTemplate><asp:CheckBox ID="chkbx" runat="server"/></ItemTemplate></asp:TemplateField>
                       <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %>
                            <asp:HiddenField ID="hdndonum" value='<%# Bind("strDONumber") %>' runat="server"  />
                            <asp:HiddenField ID="hdnchallan" value='<%# Bind("strchalallanumber") %>' runat="server" />
                            <asp:HiddenField ID="hdnprimarychallanq" Value='<%# Bind("challanqntprimary") %>' runat="server" />
                             <asp:HiddenField ID="hdnCustomerID" value='<%# Bind("intcustid") %>' runat="server"  />
                         </ItemTemplate></asp:TemplateField>
            
                       
                         <asp:BoundField DataField="intcustid" HeaderText="CustomerId" SortExpression="intCustomerId" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="strcustname" HeaderText="CustName" SortExpression="strCustName" ItemStyle-HorizontalAlign="Center" />
                          <asp:BoundField DataField="strDONumber" HeaderText="D.O Number" SortExpression="strDONumber" ItemStyle-HorizontalAlign="Center" />
                         <asp:BoundField DataField="strchalallanumber" HeaderText="Challan Number" SortExpression="strchalallanumber" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="strItmname" HeaderText="Item Name" SortExpression="strItmname" ItemStyle-HorizontalAlign="Center" />
                         <asp:BoundField DataField="rate" HeaderText="Rate" SortExpression="rate" ItemStyle-HorizontalAlign="Center" />
                         <asp:BoundField DataField="challanqntprimary" HeaderText="PrimaryChallanQnt" SortExpression="challanqntprimary" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="challanamoutnprim" HeaderText="ChallanAmountPrimary" SortExpression="challanamoutnprim" ItemStyle-HorizontalAlign="Center" />
                         

                        <asp:TemplateField HeaderText="Bill Qnt">
                            <ItemTemplate>
                                <asp:HiddenField ID="hdnreturnqnt" runat="server" Value='<%# Bind("billqnt","{0:0.0}") %>'></asp:HiddenField>
                                <asp:TextBox ID="txtretqnt" runat="server" CssClass="txtBox" Width="60" Text='<%# Bind("billqnt","0.00") %>'></asp:TextBox>
                            </ItemTemplate>
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


                 </tr>
                </table>
            </div>
        <div>
            <table>
               <tr class="tblrowodd">
             <td colspan="4">
                 <asp:GridView ID="grdvBillpendingtopsheet" runat="server" PageSize="11125" OnPageIndexChanging="grdvBillpendingtopsheet_PageIndexChanging" OnRowDataBound="grdvBillpendingtopsheet_RowDataBound"  AutoGenerateColumns="False" CellPadding="4" ShowFooter="True" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2" ForeColor="Black">
                          
                    <Columns>
               
                       <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %>
                            <asp:HiddenField ID="hdndonum" value='<%# Bind("strDONumber") %>' runat="server"  />
                            <asp:HiddenField ID="hdnchallan" value='<%# Bind("strchalallanumber") %>' runat="server" />
                            <asp:HiddenField ID="hdnprimarychallanq" Value='<%# Bind("challanqntprimary") %>' runat="server" />
                             <asp:HiddenField ID="hdnCustomerID" value='<%# Bind("intcustid") %>' runat="server"  />
                         </ItemTemplate></asp:TemplateField>
            
                       
                        <asp:BoundField DataField="intcustid" HeaderText="CustomerId" SortExpression="intCustomerId" ItemStyle-HorizontalAlign="Center" >
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="strcustname" HeaderText="CustName" SortExpression="strCustName" ItemStyle-HorizontalAlign="Center" >
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="strDONumber" HeaderText="D.O Number" SortExpression="strDONumber" ItemStyle-HorizontalAlign="Center" >
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="strchalallanumber" HeaderText="Challan Number" SortExpression="strchalallanumber" ItemStyle-HorizontalAlign="Center" >
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="strItmname" HeaderText="Item Name" SortExpression="strItmname" ItemStyle-HorizontalAlign="Center" >
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="rate" HeaderText="Rate" SortExpression="rate" ItemStyle-HorizontalAlign="Center" >
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="challanqntprimary" HeaderText="PrimaryChallanQnt" SortExpression="challanqntprimary" ItemStyle-HorizontalAlign="Center" >
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="challanamoutnprim" HeaderText="ChallanAmountPrimary" SortExpression="challanamoutnprim" ItemStyle-HorizontalAlign="Center" >
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="decrtnqnt" HeaderText="Returnqnt" SortExpression="challanqntprimary" ItemStyle-HorizontalAlign="Center" >
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="billqnt" HeaderText="BillqntNet" SortExpression="challanamoutnprim" ItemStyle-HorizontalAlign="Center" >
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="billamount" HeaderText="BillamountNet" SortExpression="challanqntprimary" ItemStyle-HorizontalAlign="Center" >
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        


                       <asp:TemplateField HeaderText="Det.">
                              <ItemTemplate>                                                                                                          
             <asp:Button ID="Complete" runat="server" Text="Deaills" class="button" CommandName="complete" OnClick="Complete_Click"   CommandArgument='<%# Eval("intcustid")+","+Eval("dtfromdate")+","+Eval("dtetodate")+","+Eval("intsalesoffice")%>' /></ItemTemplate>
             </asp:TemplateField> 
                        
                         <%--@intReportType int,@intUnitid int, @dteFromdate date,@dteTodate date,@Salesofficeid int,@intcustomerid int,@xml xml,@id int--%>
                          
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


                </table>



    </div>

        <div>
            <table>
               <tr class="tblrowodd">
             <td colspan="4">
                 <asp:GridView ID="grdvCustomerlistforbill" runat="server" PageSize="11125" OnPageIndexChanging="grdvCustomerlistforbill_PageIndexChanging"   AutoGenerateColumns="False" CellPadding="3" ShowFooter="True" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellSpacing="1" GridLines="None">
                          
                    <Columns>
               
                       <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %>
                            <asp:HiddenField ID="hdndonum" value='<%# Bind("strDONumber") %>' runat="server"  />
                            <asp:HiddenField ID="hdnchallan" value='<%# Bind("strchalallanumber") %>' runat="server" />
                            <asp:HiddenField ID="hdnprimarychallanq" Value='<%# Bind("challanqntprimary") %>' runat="server" />
                             <asp:HiddenField ID="hdnCustomerID" value='<%# Bind("intcustid") %>' runat="server"  />
                         </ItemTemplate></asp:TemplateField>
            
                       
                        <asp:BoundField DataField="intcustid" HeaderText="CustomerId" SortExpression="intCustomerId" ItemStyle-HorizontalAlign="Center" >
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="strcustname" HeaderText="CustName" SortExpression="strCustName" ItemStyle-HorizontalAlign="Center" >
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="challanqntprimary" HeaderText="PrimaryChallanQnt" SortExpression="challanqntprimary" ItemStyle-HorizontalAlign="Center" >
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="challanamoutnprim" HeaderText="ChallanAmountPrimary" SortExpression="challanamoutnprim" ItemStyle-HorizontalAlign="Center" >
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="decrtnqnt" HeaderText="Returnqnt" SortExpression="challanqntprimary" ItemStyle-HorizontalAlign="Center" >
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="billqnt" HeaderText="BillqntNet" SortExpression="challanamoutnprim" ItemStyle-HorizontalAlign="Center" >
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                       
                        


                       <asp:TemplateField HeaderText="Det.">
                              <ItemTemplate>                                                                                                          
             <asp:Button ID="Complete" runat="server" Text="Deaills" class="button" CommandName="complete" OnClick="Complete_Click"   CommandArgument='<%# Eval("intcustid")%>' /></ItemTemplate>
             </asp:TemplateField> 
                        
                         <%--@intReportType int,@intUnitid int, @dteFromdate date,@dteTodate date,@Salesofficeid int,@intcustomerid int,@xml xml,@id int--%>
                          
                    </Columns>
                     <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                  <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                  <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                     <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                  <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                  <SortedAscendingCellStyle BackColor="#F1F1F1" />
                  <SortedAscendingHeaderStyle BackColor="#594B9C" />
                  <SortedDescendingCellStyle BackColor="#CAC9C9" />
                  <SortedDescendingHeaderStyle BackColor="#33276A" />

                    </asp:GridView>


                 </tr>


                </table>



    </div>



<%--=========================================End My Code From Here=================================================--%>
  <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>
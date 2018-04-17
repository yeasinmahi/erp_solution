<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DOQntVsChallaQnt.aspx.cs" Inherits="UI.SAD.Sales.Report.DOQntVsChallaQnt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
     <link href="../../../../Content/CSS/GridHEADER.css" rel="stylesheet" />
    <script src="../../../../Content/JS/JQUERY/jquery-1.10.2.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/jquery-ui.min.js"></script>
    <script src="../../../../Content/JS/datepickr.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/MigrateJS.js"></script>
    <script src="../../../../Content/JS/JQUERY/GridviewScroll.min.js"></script>
 
</head>
<body>
    <form id="frmpdv" runat="server">
   <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
 
<%--=========================================Start My Code From Here===============================================--%>
    <div class="leaveApplication_container"> 
    <div class="tabs_container"> Product Delivery Report :<asp:HiddenField ID="hdnenroll" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/><hr /></div>
        <table border="0"; style="width:Auto"; >  
            <tr class="tblrowodd">
                 <td>
                               Unit
                               
                            </td>
                <td>
                     <asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" DataSourceID="odsUnit"
                                    DataTextField="strUnit" DataValueField="intUnitID" OnDataBound="ddlUnit_DataBound"
                                    OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
                                    <SelectParameters>
                                        <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                </td>
            </tr>
             <tr class="tblroweven">
       
                   <td>
                                From
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnFrm" runat="server" />
                                <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFrom" Format="dd/MM/yyyy"
                                    PopupButtonID="imgCal_1" ID="CalendarExtender1" runat="server" EnableViewState="true">
                                </cc1:CalendarExtender>
                                <img id="imgCal_1" src="../../../Content/images/img/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />
                                <asp:DropDownList ID="ddlFHour" runat="server">                                                                        
                                   
                                    <asp:ListItem>06 AM</asp:ListItem>
                                    <asp:ListItem>07 AM</asp:ListItem>
                                    <asp:ListItem>08 AM</asp:ListItem>
                                    <asp:ListItem>09 AM</asp:ListItem>
                                    <asp:ListItem>10 AM</asp:ListItem>
                                    <asp:ListItem>11 AM</asp:ListItem>
                                    <asp:ListItem>12 PM</asp:ListItem>
                                    <asp:ListItem>01 PM</asp:ListItem>
                                    <asp:ListItem>02 PM</asp:ListItem>
                                    <asp:ListItem>03 PM</asp:ListItem>
                                    <asp:ListItem>04 PM</asp:ListItem>
                                    <asp:ListItem>05 PM</asp:ListItem>
                                    <asp:ListItem>06 PM</asp:ListItem>
                                    <asp:ListItem>07 PM</asp:ListItem>
                                    <asp:ListItem>08 PM</asp:ListItem>
                                    <asp:ListItem>09 PM</asp:ListItem>
                                    <asp:ListItem>10 PM</asp:ListItem>
                                    <asp:ListItem>11 PM</asp:ListItem>
                                    <asp:ListItem>12 AM</asp:ListItem>
                                </asp:DropDownList>                                
                            </td>
                            <td>
                                To
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnTo" runat="server" />
                                <asp:TextBox ID="txtTo" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtTo" Format="dd/MM/yyyy"
                                    PopupButtonID="imgCal_2" ID="CalendarExtender2" runat="server" EnableViewState="true">
                                </cc1:CalendarExtender>
                                <img id="imgCal_2" src="../../../Content/images/img/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />
                                <asp:DropDownList ID="ddlTHour" runat="server">                                    
                                    <asp:ListItem>06 AM</asp:ListItem>
                                    <asp:ListItem>08 AM</asp:ListItem>
                                    <asp:ListItem>10 AM</asp:ListItem>
                                    <asp:ListItem>12 AM</asp:ListItem>
                                    <asp:ListItem>02 AM</asp:ListItem>
                                    <asp:ListItem>04 AM</asp:ListItem>
                                    <asp:ListItem>06 PM</asp:ListItem>
                                    <asp:ListItem>08 PM</asp:ListItem>
                                    <asp:ListItem>10 PM</asp:ListItem>
                                    <asp:ListItem>12 PM</asp:ListItem>
                                    <asp:ListItem>02 PM</asp:ListItem>
                                    <asp:ListItem>04 PM</asp:ListItem>
                                </asp:DropDownList>                               
                            </td>
        </tr>
            <tr>
                 <td>
                                Sales Office
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSo" runat="server" AutoPostBack="True" DataSourceID="ods2"
                                    DataTextField="strName" DataValueField="intSalesOffId" OnDataBound="ddlSo_DataBound"
                                    OnSelectedIndexChanged="ddlSo_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ods2" runat="server" SelectMethod="GetSalesOfficeWithAll" TypeName="SAD_BLL.Global.SalesOffice"
                                    OldValuesParameterFormatString="original_{0}">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="userId" SessionField="sesUserID" Type="String" />
                                        <asp:ControlParameter ControlID="ddlUnit" Name="unitId" PropertyName="SelectedValue"
                                            Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>

                  <%-- <td align="left">
                                Customer Type
                            </td>
                   <td colspan="2" align="left">
                                <asp:DropDownList ID="ddlCusType" runat="server" AutoPostBack="true" DataSourceID="ods3"
                                    DataTextField="strTypeName" DataValueField="intTypeID" OnDataBound="ddlCusType_DataBound"
                                    OnSelectedIndexChanged="ddlCusType_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetCustomerTypeBySOForDOWithAll"
                                    TypeName="SAD_BLL.Customer.CustomerType" OldValuesParameterFormatString="original_{0}">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlSo" Name="soId" PropertyName="SelectedValue"
                                            Type="String" />
                                        <asp:ControlParameter ControlID="ddlUnit" Name="unitId" 
                                            PropertyName="SelectedValue" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>--%>
            </tr>


        <tr class="tblrowodd">
        <td style="text-align:right;"><asp:Label ID="lblfullname" CssClass="lbl" runat="server" Text="Customer Name: "></asp:Label></td>
    
                            <td>
                                <asp:HiddenField ID="hdnCustomer" runat="server" />
                                <asp:HiddenField ID="hdnCustomerText" runat="server" />
                                <asp:TextBox ID="txtCus" runat="server" AutoCompleteType="Search" Width="350px"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtCus"
                                    ServiceMethod="GetCustomerList" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>
      
            <td style="text-align:right;">
                <asp:Label runat="server" Text="ReportType" AutoPostBack="true"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="drdlreporttype" runat="server">
                    <asp:ListItem Text="Details" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Topsheet" Value="2"></asp:ListItem>
                     <asp:ListItem Text="D.O Number Basis(all)" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Qnt vs Sales Volue" Value="4"></asp:ListItem>
                   
                   <asp:ListItem Text="D.O Number Basis(Specific Salesoffice)" Value="5"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
             <td align="left">
                          <asp:Label ID="lblCustomerType" runat="server" Visible="false" Text=" Customer Type"></asp:Label>    
                            </td>
                   <td colspan="2" align="left">
                                <asp:DropDownList ID="ddlCusType" runat="server" Visible="false" AutoPostBack="true" DataSourceID="ods3"
                                    DataTextField="strTypeName" DataValueField="intTypeID" OnDataBound="ddlCusType_DataBound"
                                    OnSelectedIndexChanged="ddlCusType_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetCustomerTypeBySOForDOWithAll"
                                    TypeName="SAD_BLL.Customer.CustomerType" OldValuesParameterFormatString="original_{0}">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlSo" Name="soId" PropertyName="SelectedValue"
                                            Type="String" />
                                        <asp:ControlParameter ControlID="ddlUnit" Name="unitId" 
                                            PropertyName="SelectedValue" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
        </tr>

       
        <tr><td style="text-align:right" colspan="3">
            <asp:Button ID="btnShowDelvRepot" runat="server" Text="Show Report" CssClass="button" OnClick="btnShowDelvRepot_Click"  /></td>
             <td style="text-align:right"> <asp:Button ID="btnExportToExcel" runat="server" Text="Export" OnClick="btnExportToExcel_Click" /></td>

        </tr>
            </div>
            <div>
                <table>
        <tr class="tblrowodd">
              <td colspan="4">
              <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="false"  BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging"  >
              
                  <AlternatingRowStyle BackColor="#CCCCCC" />
            
              <Columns>
                <asp:TemplateField HeaderText="Serial No">
                <ItemTemplate>
                <%#((GridViewRow)Container).RowIndex +1 %>
                </ItemTemplate>
                </asp:TemplateField>
               
                 <asp:BoundField DataField="strdonumber" HeaderText="DO Number" SortExpression="strShopname" />
                    <asp:BoundField DataField="strchallannumbr" HeaderText="Challan No" SortExpression="intShopid" />
                  <asp:BoundField DataField="dtechallandate" HeaderText="Challan Date" SortExpression="decDelv" DataFormatString="{0:d}" />
                     <asp:BoundField DataField="numdoqnt" HeaderText="DO. Qnt." SortExpression="decProm" />
                   <asp:BoundField DataField="numchallanqnt" HeaderText="Challan Qnt" SortExpression="strChallan" />
                   <asp:BoundField DataField="numrestpice" HeaderText="Rest Qnt " SortExpression="strDO" />
                  <asp:BoundField DataField="monprice" HeaderText="Rate" SortExpression="strItem" />
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
          </tr></table>
 </div>
<div>
    <table >
        <tr class="tblrowodd">
              <td colspan="4">
              <asp:GridView ID="grdvDelvVSPendingTopsheet" runat="server" AutoGenerateColumns="False"  BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Vertical" OnRowDataBound="grdvDelvVSPendingTopsheet_RowDataBound" OnPageIndexChanging="grdvDelvVSPendingTopsheet_PageIndexChanging" ForeColor="Black"  >
              
                  <AlternatingRowStyle BackColor="White" />
            
              <Columns>
                <asp:TemplateField HeaderText="Serial No">
                <ItemTemplate>
                <%#((GridViewRow)Container).RowIndex +1 %>
                </ItemTemplate>
                </asp:TemplateField>
            
                 <asp:BoundField DataField="strcustname" HeaderText="Customer" SortExpression="strcustname" />
                    <asp:BoundField DataField="intcustomerid" HeaderText="Customerid"  SortExpression="decDelv" />
                    <asp:BoundField DataField="strsalesoffice" HeaderText="Sales Office" SortExpression="strsalesoffice" />
                
                     <asp:BoundField DataField="numdoqnt" HeaderText="DO. Qnt." SortExpression="decProm" />
                   <asp:BoundField DataField="numchallanqnt" HeaderText="Challan Qnt" SortExpression="strChallan" />
                   <asp:BoundField DataField="dectotaldoqnt" HeaderText="Total D.O Qnt " SortExpression="strDO" />
                   <asp:BoundField DataField="decTotalchallanqnt" HeaderText="Total Challan Qnt " SortExpression="decTotalchallanqnt" />


                  <asp:BoundField DataField="numrestpice" HeaderText="Remaingin Qnt" SortExpression="numrestpice" />
                  </Columns>
                  <FooterStyle BackColor="#CCCC99" />
                  <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                  <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                  <RowStyle BackColor="#F7F7DE" />
                  <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                  <SortedAscendingCellStyle BackColor="#FBFBF2" />
                  <SortedAscendingHeaderStyle BackColor="#848384" />
                  <SortedDescendingCellStyle BackColor="#EAEAD3" />
                  <SortedDescendingHeaderStyle BackColor="#575357" />
                  </asp:GridView>
                  </td>
          </tr>



    </table>



</div>

<div>
    <table >
        <tr class="tblrowodd">
              <td colspan="4">
              <asp:GridView ID="grdUndelvQntwithDONumber" runat="server" AutoGenerateColumns="False" CellPadding="3" GridLines="Vertical" OnRowDataBound="grdUndelvQntwithDONumber_RowDataBound"  ForeColor="Black" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"  >
              
                  <AlternatingRowStyle BackColor="#CCCCCC" />
           <%--intsl,intCustomerId,strcustmname,dtedoDate,donumber,doqnt,doamount,challandate,challannumber,challanqnt,challanamount,isnull(pedingqnt,0)as pedingqnt,pendingamount,strsalesoffice,strshippoint--%>
              <Columns>
               
                    <asp:BoundField DataField="intsl" HeaderText="Sl" SortExpression="intsl" />
                    <asp:BoundField DataField="strcustmname" HeaderText="Customer" SortExpression="strcustmname" />
                    <asp:BoundField DataField="intCustomerId" HeaderText="Customerid"  SortExpression="intcustmid" />
                    <asp:BoundField DataField="strsalesoffice" HeaderText="Sales Office" SortExpression="strsalesoffice" />
                    <asp:BoundField DataField="donumber" HeaderText="D.O Number" SortExpression="donumber" />
                    <asp:BoundField DataField="dtedoDate" HeaderText="DOCreationDate" SortExpression="dtedoDate" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="doqnt" HeaderText="DO. Qnt." SortExpression="doqnt" />
                    <asp:BoundField DataField="doamount" HeaderText="DO. Amount" SortExpression="doamount" />
                    <asp:BoundField DataField="challandate" HeaderText="ChallanCreationDate" SortExpression="challandate" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="challannumber" HeaderText="Challan Number" SortExpression="challannumber" />
                    <asp:BoundField DataField="challanqnt" HeaderText="Challan Qnt" SortExpression="challanqnt" />
                    <asp:BoundField DataField="challanamount" HeaderText="Challan Amount" SortExpression="challanamount" />
                    <asp:BoundField DataField="pedingqnt" HeaderText="Restqnt" SortExpression="pedingqnt"    />
                    <asp:BoundField DataField="strshippoint" HeaderText="Shipping point" SortExpression="strshippoint" />
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
          </tr></table>
</div>

     <div>
                <table>
        <tr class="tblrowodd">
              <td colspan="4">
              <asp:GridView ID="grdvundelvqnwithsalesamount" runat="server" AutoGenerateColumns="False" AllowPaging="false"  BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging"  >
              
                  <AlternatingRowStyle BackColor="#CCCCCC" />
            <%--intcustid,custname,strdonumber,intprdid,strproductname,numdoqnt,numchallanqnt,numrestpice,doamount,monprice--%>
              <Columns>
                <asp:TemplateField HeaderText="Serial No">
                <ItemTemplate>
                <%#((GridViewRow)Container).RowIndex +1 %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="intcustid" HeaderText="Cust. ID" SortExpression="strShopname" />
                    <asp:BoundField DataField="custname" HeaderText="Custname" SortExpression="custname" />
                 <asp:BoundField DataField="strdonumber" HeaderText="DO Number" SortExpression="strShopname" />
                    <asp:BoundField DataField="intprdid" HeaderText="Item ID" SortExpression="intprdid" />
                  <asp:BoundField DataField="strproductname" HeaderText="Item" SortExpression="strproductname" DataFormatString="{0:d}" />
                     <asp:BoundField DataField="numdoqnt" HeaderText="DO. Qnt" SortExpression="numdoqnt" />
                  <asp:BoundField DataField="doamount" HeaderText="DO. Sales Value(Tk.)" SortExpression="doamount" />
                   <asp:BoundField DataField="numchallanqnt" HeaderText="Challan Qnt" SortExpression="numchallanqnt" />
                   <asp:BoundField DataField="numrestpice" HeaderText="Rest Qnt " SortExpression="numrestpice" />
                  <asp:BoundField DataField="monprice" HeaderText="Challan Sales Value (Tk.)" SortExpression="monprice" />
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
          </tr></table>
 </div>

        

   <%--=========================================End My Code From Here=================================================--%>
   <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>
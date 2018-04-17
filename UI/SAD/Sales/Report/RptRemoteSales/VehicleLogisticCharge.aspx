<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VehicleLogisticCharge.aspx.cs" Inherits="UI.SAD.Sales.Report.RptRemoteSales.VehicleLogisticCharge" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
      <link href="../../../../Content/CSS/GridHEADER.css" rel="stylesheet" />
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
    <div class="tabs_container"> Vheicle  :<asp:HiddenField ID="hdnenroll" runat="server"/>
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
                <td>
                    <asp:Label ID="lblreporttype" runat="server" Text="Repor Tytpe"></asp:Label>
                </td>
                <td>
                <asp:DropDownList ID="ddlreporttype" runat="server" AutoPostBack="True">
                <asp:ListItem Text="All" Value="1"></asp:ListItem>                 
                <asp:ListItem Text="Challan" Value="2"></asp:ListItem>
                <asp:ListItem Text="Delv. Order" Value="3"></asp:ListItem>

                </asp:DropDownList>
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

                   <td align="left">
                                Type
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
                            </td>
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
                <asp:Label ID="lblchallordo" runat="server" Text="Challan/D.O Number"></asp:Label>

            </td>
                <td>
                    <asp:TextBox ID="txtchallanordo" runat="server" BackColor="#ffff99"></asp:TextBox>
                </td>
           
        </tr>
            

       
        <tr><td style="text-align:right" colspan="4">
            <asp:Button ID="btnShowDelvRepot" runat="server" Text="Show Report" CssClass="button" OnClick="btnShowDelvRepot_Click"  /></td>
          

        </tr>
             
        <tr class="tblrowodd">
              <td colspan="4">
              <asp:GridView ID="grdvVheicleLogisticchargedetaills" runat="server" AutoGenerateColumns="False" AllowPaging="false"  BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnRowDataBound="grdvVheicleLogisticchargedetaills_RowDataBound" OnPageIndexChanging="grdvVheicleLogisticchargedetaills_PageIndexChanging"  >
              
                  <AlternatingRowStyle BackColor="#CCCCCC" />
             
              <Columns>
                 <asp:TemplateField HeaderText="Serial No">
                                                             <ItemTemplate>
                                                                 <%#((GridViewRow)Container).RowIndex +1 %>
                                                             </ItemTemplate>
                                                         </asp:TemplateField>
                 
                
                   <asp:BoundField DataField="dtechallandate" HeaderText="Challan Date" SortExpression="decDelv" DataFormatString="{0:d}" />
                <asp:BoundField DataField="strvhclname" HeaderText="Vheicle Name" SortExpression="Vheicle" />
                <asp:BoundField DataField="strchallannumbr" HeaderText="Challan No" SortExpression="intShopid" />
                <asp:BoundField DataField="strdonumber" HeaderText="DO Number" SortExpression="strShopname" />
                <asp:BoundField DataField="strcustname" HeaderText="Customer" SortExpression="intShopid" />
                <asp:BoundField DataField="straddress" HeaderText="Address" SortExpression="straddress" />
                <asp:BoundField DataField="strrentcatg" HeaderText="Logistic By" SortExpression="strrentcatg" />
                <asp:BoundField DataField="numdoqnt" HeaderText="DO. Qnt." SortExpression="decProm" />
                <asp:BoundField DataField="numchallanqnt" HeaderText="Challan Qnt" SortExpression="strChallan" />
                <asp:BoundField DataField="numrestpice" HeaderText="Rest Qnt " SortExpression="strDO" />
                <asp:BoundField DataField="decthanarate" HeaderText="Logistic Rate" SortExpression="decthanarate" />
                <asp:BoundField DataField="dectotallogisticcharge" HeaderText="Total Logistic" SortExpression="dectotallogisticcharge" />
                <asp:BoundField DataField="dectotalproductprice" HeaderText="Ledger Amount" SortExpression="dectotalproductprice" />
                <asp:BoundField DataField="monprice" HeaderText="Rate" SortExpression="monprice" />







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
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
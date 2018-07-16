<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OperationalSetupBaseStatus.aspx.cs" Inherits="UI.SAD.Sales.Report.OperationalSetupBaseStatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html >
<html >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
     <asp:PlaceHolder ID="PlaceHolder1" runat="server">     
          <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
        </asp:PlaceHolder>  
    
    <webopt:BundleReference ID="BundleReference4" runat="server" Path="~/Content/Bundle/hrCSS" />
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
</head>
<body>
    <form id="frmshvssls" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
       <CompositeScript>
           <Scripts>
               <asp:ScriptReference name="MicrosoftAjax.js"/>
		<asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
		<asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Common.DateTime.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Animation.AnimationBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="PopupExtender.PopupBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Common.Threading.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Calendar.CalendarBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>

           </Scripts>
       </CompositeScript>

    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
         <div>
        <table><tr class="tblroweven">
            <td style="text-align:right;"><asp:Label ID="lblappointment" CssClass="lbl" runat="server" Text="From-Date : "> </asp:Label></td>
               
            <td style="text-align:right;">
                <asp:TextBox ID="txtFDate" runat="server" CssClass="txtBox"></asp:TextBox>
                    <cc1:CalendarExtender ID="FD" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFDate">
                    </cc1:CalendarExtender> 
                </td>
             

            <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To-Date : "></asp:Label></td>
                
            <td>
                <asp:TextBox ID="txtTo" runat="server" CssClass="txtBox"></asp:TextBox>
                    <cc1:CalendarExtender ID="TD" runat="server" Format="yyyy-MM-dd" TargetControlID="txtTo">
                    </cc1:CalendarExtender> 
                </td>
             

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
                 <td><asp:Label ID="lblShipPoint" runat="server" Text="Shipping Point"></asp:Label></td> 
                <td>
                                            <asp:DropDownList ID="ddlShip" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1"
                                                DataTextField="strName" DataValueField="intShipPointId" 
                                                
                                                onselectedindexchanged="ddlShip_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetShipPoint"
                                                TypeName="SAD_BLL.Global.ShipPoint" 
                                                OldValuesParameterFormatString="original_{0}">
                                                <SelectParameters>
                                                    <asp:SessionParameter Name="userId" SessionField="sesUserID" Type="String" />
                                                    <asp:ControlParameter ControlID="drdlUnitName" Name="unitId" PropertyName="SelectedValue"
                                                        Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
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

                 <tr class="tblrowodd">
                     <td>
                         <asp:Label id="lblrptytpe" runat="server" Text="Report Type"></asp:Label>
                     </td>
                     <td>
                         <asp:DropDownList ID="drdlrpttype" runat="server" CssClass="ddList">
                             <asp:ListItem Selected="True" Text="Territory Basis (Delv.)" Value="1"></asp:ListItem>
                                <asp:ListItem  Text="Area Basis (Delv.)" Value="2"></asp:ListItem>
                              <asp:ListItem  Text="Region Basis (Delv.)" Value="3"></asp:ListItem>
                              <asp:ListItem  Text="National (Delv.)" Value="4"></asp:ListItem>
                             <asp:ListItem  Text="National Detaills (UnDelv.)" Value="11"></asp:ListItem>
                              <asp:ListItem  Text="National  Top Sheet(UnDelv.)" Value="12"></asp:ListItem>
                                <asp:ListItem  Text="Territory Basis (UnDelv.)" Value="13"></asp:ListItem>
                                <asp:ListItem  Text="Area Basis (UnDelv.)" Value="14"></asp:ListItem>
                              <asp:ListItem  Text="Region Basis (UnDelv.)" Value="15"></asp:ListItem>
                               <asp:ListItem  Text="Specifice ShippingPoint(UnDelv.)" Value="16"></asp:ListItem>
                              <asp:ListItem  Text="Specifice SalesOffice (UnDelv.)" Value="17"></asp:ListItem>
                             <asp:ListItem  Text="Territory base collection" Value="18"></asp:ListItem>
                             <asp:ListItem  Text="Area base collection" Value="19"></asp:ListItem>
                             <asp:ListItem  Text="Region base collection" Value="20"></asp:ListItem>
                             <asp:ListItem  Text="Specific Sales office collection" Value="21"></asp:ListItem>
                              <asp:ListItem  Text="Specific Sales office collection" Value="22"></asp:ListItem>
                         </asp:DropDownList>
                     </td>
                     <td>
                         <asp:Label ID="lblcustype" runat="server" Text="Customer Type"></asp:Label>
                     </td>

                            <td align="left">
                                <asp:DropDownList ID="ddlCusType" runat="server" AutoPostBack="true" DataSourceID="ods3"
                                    DataTextField="strTypeName" DataValueField="intTypeID" OnDataBound="ddlCusType_DataBound"
                                    OnSelectedIndexChanged="ddlCusType_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetCustomerTypeBySOForDO"
                                    TypeName="SAD_BLL.Customer.CustomerType" OldValuesParameterFormatString="original_{0}">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlSo" Name="soId" PropertyName="SelectedValue"
                                            Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>




                    
                 </tr>
            <tr>
                  <td colspan="4">
                          <asp:Button ID="btnShow" runat="server" Text="Show Report" CssClass="button" OnClick="btnShow_Click"/></td>
            </tr>
           </table>
             </div>
        <div>
            <table>
              <tr><td>
    <asp:GridView ID="dgvDOAndChallanqnt" runat="server" AllowPaging="True" PageSize="111125" OnPageIndexChanging="dgvDOAndChallanqnt_PageIndexChanging" OnRowDataBound="dgvDOAndChallanqnt_RowDataBound" AutoGenerateColumns="False" CellPadding="4" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Vertical" ShowFooter="true">

                    <AlternatingRowStyle BackColor="White" />

                    <Columns>
                      <asp:TemplateField HeaderText="Serial No">
                <ItemTemplate>
                <%#((GridViewRow)Container).RowIndex +1 %>
                </ItemTemplate>
                </asp:TemplateField>
                       

                        <asp:BoundField DataField="intcustid" HeaderText="custid" SortExpression="intcustid" ItemStyle-HorizontalAlign="Center" >

                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="strcustname" HeaderText="Customer Name" SortExpression="strCustm" ItemStyle-HorizontalAlign="Center" >

                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="strTer" HeaderText="Territroy" SortExpression="strTerritory" ItemStyle-HorizontalAlign="Center" >

                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                    <asp:BoundField DataField="strArea" HeaderText="Area" SortExpression="strArea" ItemStyle-HorizontalAlign="Center" >

                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="strReg" HeaderText="Region" SortExpression="strRegion" ItemStyle-HorizontalAlign="Center" >

                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="strSalesOff" HeaderText="Salesoffice" SortExpression="strSalesOff" ItemStyle-HorizontalAlign="Center" >

                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="decOrderqnt" HeaderText="D.O Qnt" SortExpression="decOrderqnt" ItemStyle-HorizontalAlign="Center" >

                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="totalorderamount" HeaderText="D.O Amount" SortExpression="totalorderamount" ItemStyle-HorizontalAlign="Center" >

                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="decchallanqnt" HeaderText="Challan Qnt" SortExpression="decchallanqnt" ItemStyle-HorizontalAlign="Center" >

                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="totalchallanamount" HeaderText="Challan Amount" SortExpression="totalchallanamount" ItemStyle-HorizontalAlign="Center" >





                    
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>





                    
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
    </td></tr>

        </table>
            </div>

        <div>
            <table>
              <tr><td>
                 


    <asp:GridView ID="grdvUndelvQntAndAmount" runat="server" AllowPaging="True" PageSize="1125" OnPageIndexChanging="grdvUndelvQntAndAmount_PageIndexChanging" OnRowDataBound="grdvUndelvQntAndAmount_RowDataBound" AutoGenerateColumns="False" CellPadding="3" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" GridLines="Vertical" ShowFooter="True">

                    <AlternatingRowStyle BackColor="#CCCCCC" />

                    <Columns>
                      
                       <asp:TemplateField HeaderText="Serial No">
                <ItemTemplate>
                <%#((GridViewRow)Container).RowIndex +1 %>
                </ItemTemplate>
                </asp:TemplateField>

                        <asp:BoundField DataField="intcustmid" HeaderText="custid" SortExpression="intcustmid" ItemStyle-HorizontalAlign="Center" >

                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="strname" HeaderText="Customer Name" SortExpression="strname" ItemStyle-HorizontalAlign="Center" >

                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="stritemname" HeaderText="Item Name" SortExpression="stritemname" ItemStyle-HorizontalAlign="Center" >

                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>



                        <asp:BoundField DataField="strTerritory" HeaderText="Territroy" SortExpression="strTerritory" ItemStyle-HorizontalAlign="Center" >

                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                    <asp:BoundField DataField="strArea" HeaderText="Area" SortExpression="strArea" ItemStyle-HorizontalAlign="Center" >

                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="strRegion" HeaderText="Region" SortExpression="strRegion" ItemStyle-HorizontalAlign="Center" >

                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="strDONumber" HeaderText="D.O Number" SortExpression="strDONumber" ItemStyle-HorizontalAlign="Center" >

                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>


                        <asp:BoundField DataField="numrestqnt" HeaderText="Pending Qnt" SortExpression="numrestqnt" ItemStyle-HorizontalAlign="Center" >

                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="monrestamount" HeaderText="Pending Amount" SortExpression="monrestamount" ItemStyle-HorizontalAlign="Center" >

                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        



                    




                    
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
    </td></tr>

        </table>
            </div>
   
          <div>
            <table>
              <tr><td>
                 


    <asp:GridView ID="grdvUndelvTopsheet" runat="server" AllowPaging="True" PageSize="1125" OnPageIndexChanging="grdvUndelvTopsheet_PageIndexChanging" OnRowDataBound="grdvUndelvTopsheet_RowDataBound" AutoGenerateColumns="False" CellPadding="3" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" GridLines="Vertical" ShowFooter="True">

                    <AlternatingRowStyle BackColor="#DCDCDC" />

                    <Columns>
                      
                       <asp:TemplateField HeaderText="Serial No">
                <ItemTemplate>
                <%#((GridViewRow)Container).RowIndex +1 %>
                </ItemTemplate>
                </asp:TemplateField>

                       <%-- insl ,dteDate  ,strCode  ,strCustName ,intCustomerId ,strContactAt ,strAddress ,strPhone ,intPriceVarId 
,strName  ,strNarration  ,   rate  , numPieces ,challanqnt , remainingqnt  ,monTotalAmount ,dteInsertionTime  ,ysnLogistic 
,numRestPieces ,ysnChallanCompleted,strchallan ,strProductName ,intproductid ,pkid,intshippingpointid ,intsalesoficeid ,pendingqntpricevalue 
,strTerritory,strArea ,strRegion ,intterritoryid ,areaid ,regionid --%>






                        <asp:BoundField DataField="intCustomerId" HeaderText="custid" SortExpression="intCustomerId" ItemStyle-HorizontalAlign="Center" >

                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="strCustName" HeaderText="Customer Name" SortExpression="strCustName" ItemStyle-HorizontalAlign="Center" >

                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                     


                        <asp:BoundField DataField="strTerritory" HeaderText="Territroy" SortExpression="strTerritory" ItemStyle-HorizontalAlign="Center" >

                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                    <asp:BoundField DataField="strArea" HeaderText="Area" SortExpression="strArea" ItemStyle-HorizontalAlign="Center" >

                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="strRegion" HeaderText="Region" SortExpression="strRegion" ItemStyle-HorizontalAlign="Center" >

                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                         <asp:BoundField DataField="strCode" HeaderText="D.O Number" SortExpression="strCode" ItemStyle-HorizontalAlign="Center" >

                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="strProductName" HeaderText="ProductName" SortExpression="strProductName" ItemStyle-HorizontalAlign="Center" >

                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                      

                        <asp:BoundField DataField="numRestPieces" HeaderText="Pending Qnt" SortExpression="remainingqnt" ItemStyle-HorizontalAlign="Center" >

                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="pendingqntpricevalue" HeaderText="Pending Amount" SortExpression="pendingqntpricevalue" ItemStyle-HorizontalAlign="Center" >

                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        
                        


                    




                    
                    </Columns>


                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />


                    </asp:GridView>
    </td></tr>

        </table>
            </div>

          <div>
            <table>
              <tr><td>
                 


    <asp:GridView ID="grdvcollectionreport" runat="server" AllowPaging="True" PageSize="1125" OnPageIndexChanging="grdvcollectionreport_PageIndexChanging"  AutoGenerateColumns="False" CellPadding="3" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" GridLines="Vertical" ShowFooter="True">

                    <AlternatingRowStyle BackColor="#DCDCDC" />

                    <Columns>
                      
                     

<%--intsl,strterrity,strare,strregion,strsalesof,dtedate,intcustid,strcustname,openinging,debit,credit,balance
	,intterritoryid ,intarea ,intregion ,intsalesoffice--%>
                    <asp:BoundField DataField="intsl" HeaderText="SL" SortExpression="strTerritory" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="strterrity" HeaderText="Territroy" SortExpression="strTerritory" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="strare" HeaderText="Area" SortExpression="strare" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="strregion" HeaderText="Region" SortExpression="strregion" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

                    <asp:BoundField DataField="strsalesof" HeaderText="Sales Office" SortExpression="strsalesof" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="intcustid" HeaderText="Customer ID" SortExpression="intcustid" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="strcustname" HeaderText="Customer" SortExpression="strare" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="openinging" HeaderText="openinging" SortExpression="openinging" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

                    <asp:BoundField DataField="debit" HeaderText="Debit Amount" SortExpression="strsalesof" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="credit" HeaderText="Credit" SortExpression="credit" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="balance" HeaderText="balance" SortExpression="balance" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
             


                    
                    </Columns>


                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />


                    </asp:GridView>
    </td></tr>

        </table>
            </div>
 <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>   
    </form>
</body>
</html>

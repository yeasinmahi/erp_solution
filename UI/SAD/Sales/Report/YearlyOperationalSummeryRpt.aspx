<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YearlyOperationalSummeryRpt.aspx.cs" Inherits="UI.SAD.Sales.Report.YearlyOperationalSummeryRpt" %>

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
                   

                         
                         <td style="text-align:right;"><asp:DropDownList ID="drdlUnitName"  runat="server" CssClass="ddList" DataSourceID="odsUnitNameByEnrol" AutoPostBack="true" DataTextField="strUnit" DataValueField="intUnitID"></asp:DropDownList>
            
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
                                                DataTextField="strName" DataValueField="intShipPointId">
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
                                    DataTextField="strName" DataValueField="intSalesOffId">
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
                         <asp:DropDownList ID="drdlrpttype" runat="server" CssClass="ddList" OnSelectedIndexChanged="drdlrpttype_SelectedIndexChanged">
                             <asp:ListItem Selected="True" Text="All Sales Office(With Customer)" Value="1"></asp:ListItem>
                                <asp:ListItem  Text="Specific Territory(With Customer)" Value="2"></asp:ListItem>
                              <asp:ListItem  Text="Specific Area(With Customer)" Value="3"></asp:ListItem>
                              <asp:ListItem  Text="Specific Region(With Customer)" Value="4"></asp:ListItem>
                             <asp:ListItem  Text="Specific Sales Office(With Customer)" Value="5"></asp:ListItem>
                              <asp:ListItem  Text="Specific Territory(Without Customer)" Value="6"></asp:ListItem>
                              <asp:ListItem  Text="Specific Area(Without Customer)" Value="7"></asp:ListItem>
                              <asp:ListItem  Text="Specific Region(Without Customer)" Value="8"></asp:ListItem>
                             <asp:ListItem  Text="Specific Sales Office(Without Customer)" Value="9"></asp:ListItem>
                             <asp:ListItem  Text="Specific Territory(Item Catg Basis)" Value="10"></asp:ListItem>
                              <asp:ListItem  Text="Specific Area(Item Catg Basis)" Value="11"></asp:ListItem>
                              <asp:ListItem  Text="Specific Region(Item Catg Basis)" Value="12"></asp:ListItem>
                             <asp:ListItem  Text="Specific Sales Office(Item Catg Basis)" Value="13"></asp:ListItem>
                              <asp:ListItem  Text="All Sales Office Top sheet(DO CH PEND.)" Value="14"></asp:ListItem>
                               <asp:ListItem  Text="All Sales Office Detaills(DO CH PEND.)" Value="15"></asp:ListItem>
                         </asp:DropDownList>
                     </td>

                      <td colspan="2">
                          <asp:Button ID="btnShow" runat="server" Text="Show Report" CssClass="button" OnClick="btnShow_Click"/></td>
                 </tr>
           </table>
             </div>
        <div>
            <table>
              <tr><td>
    <asp:GridView ID="dgvYearlysDOSummery" runat="server" AllowPaging="True" PageSize="111125"  OnRowDataBound="dgvYearlysDOSummery_RowDataBound" AutoGenerateColumns="False" CellPadding="4" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Vertical" ShowFooter="true">

                    <AlternatingRowStyle BackColor="White" />
      
                    <Columns>
<asp:BoundField DataField="insl" HeaderText="SL" SortExpression="insl" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
 <asp:BoundField DataField="intCustomerId" HeaderText="custid" SortExpression="intcustid" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

<asp:BoundField DataField="strCustName" HeaderText="Customer Name" SortExpression="strCustName" ItemStyle-HorizontalAlign="Center" >

<ItemStyle HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="strTerritory" HeaderText="Territroy" SortExpression="strTerritory" ItemStyle-HorizontalAlign="Center" >

<ItemStyle HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="strArea" HeaderText="Area" SortExpression="strArea" ItemStyle-HorizontalAlign="Center" >

<ItemStyle HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="strRegion" HeaderText="Region" SortExpression="strRegion" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

<asp:BoundField DataField="strName" HeaderText="Salesoffice" SortExpression="strName" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

<asp:BoundField DataField="decQntFirstMonth" HeaderText="Qnt1st" SortExpression="decQntFirstMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
<asp:BoundField DataField="amounttFirstMonth" HeaderText="Amount1st" SortExpression="amounttFirstMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

<asp:BoundField DataField="decQntSecondMonth" HeaderText="Qnt2nd" SortExpression="decQntSecondMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
<asp:BoundField DataField="amounttSecondMonth" HeaderText="Amount2nd" SortExpression="amounttFirstMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

<asp:BoundField DataField="decQntThirdMonth" HeaderText="Qnt3rd" SortExpression="decQntFirstMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
<asp:BoundField DataField="amounttThirdMonth" HeaderText="Amount3rd" SortExpression="amounttFirstMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

<asp:BoundField DataField="decQntFourthMonth" HeaderText="Qnt4th" SortExpression="decQntFirstMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
<asp:BoundField DataField="amounttFourthMonth" HeaderText="Amount4th" SortExpression="amounttFirstMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>


<asp:BoundField DataField="decQntFifthMonth" HeaderText="Qnt5th" SortExpression="decQntFirstMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
<asp:BoundField DataField="amounttFifthMonth" HeaderText="Amount5th" SortExpression="amounttFirstMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

<asp:BoundField DataField="decQntSixthMonth" HeaderText="Qnt6th" SortExpression="decQntFirstMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
<asp:BoundField DataField="amounttSixthMonth" HeaderText="Amount6th" SortExpression="amounttFirstMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

<asp:BoundField DataField="decQntSeventhMonth" HeaderText="Qnt7th" SortExpression="decQntFirstMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
<asp:BoundField DataField="amounttSeventhMonth" HeaderText="Amount7th" SortExpression="amounttFirstMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

<asp:BoundField DataField="decQntEighthMonth" HeaderText="Qnt8th" SortExpression="decQntEighthMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
<asp:BoundField DataField="amounttEighthMonth" HeaderText="Amount8th" SortExpression="amounttEighthMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>



<asp:BoundField DataField="decQntNinthMonth" HeaderText="Qnt9th" SortExpression="decQntNinthMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
<asp:BoundField DataField="amounttNinthMonth" HeaderText="Amount9th" SortExpression="amounttNinthMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

<asp:BoundField DataField="decQntTenthMonth" HeaderText="Qnt9th" SortExpression="decQntTenthMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
<asp:BoundField DataField="amounttTenthMonth" HeaderText="Amount10th" SortExpression="amounttTenthMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

<asp:BoundField DataField="decQntEleventhMonth" HeaderText="Qnt11th" SortExpression="amounttEleventhMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
<asp:BoundField DataField="amounttEleventhMonth" HeaderText="Amount11th" SortExpression="amounttEleventhMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

<asp:BoundField DataField="decQntTwelvethMonth" HeaderText="Qnt12th" SortExpression="decQntTwelvethMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
<asp:BoundField DataField="amounttTwelvethMonth" HeaderText="Amount12th" SortExpression="amounttTwelvethMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>


                    
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
    <asp:GridView ID="grdvItemCatgBasis" runat="server" AllowPaging="True" PageSize="111125"   AutoGenerateColumns="False" CellPadding="4" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Vertical" ShowFooter="true">

                    <AlternatingRowStyle BackColor="White" />
      
                    <Columns>
<asp:BoundField DataField="insl" HeaderText="SL" SortExpression="insl" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>


<asp:BoundField DataField="strTerritory" HeaderText="Territroy" SortExpression="strTerritory" ItemStyle-HorizontalAlign="Center" >

<ItemStyle HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="strArea" HeaderText="Area" SortExpression="strArea" ItemStyle-HorizontalAlign="Center" >

<ItemStyle HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="strRegion" HeaderText="Region" SortExpression="strRegion" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

<asp:BoundField DataField="itmcatgname1" HeaderText="Item Category" SortExpression="itmcatgname1" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

<asp:BoundField DataField="decQntFirstMonth" HeaderText="Qnt1st" SortExpression="decQntFirstMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
<asp:BoundField DataField="amounttFirstMonth" HeaderText="Amount1st" SortExpression="amounttFirstMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

<asp:BoundField DataField="decQntSecondMonth" HeaderText="Qnt2nd" SortExpression="decQntSecondMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
<asp:BoundField DataField="amounttSecondMonth" HeaderText="Amount2nd" SortExpression="amounttFirstMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

<asp:BoundField DataField="decQntThirdMonth" HeaderText="Qnt3rd" SortExpression="decQntFirstMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
<asp:BoundField DataField="amounttThirdMonth" HeaderText="Amount3rd" SortExpression="amounttFirstMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

<asp:BoundField DataField="decQntFourthMonth" HeaderText="Qnt4th" SortExpression="decQntFirstMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
<asp:BoundField DataField="amounttFourthMonth" HeaderText="Amount4th" SortExpression="amounttFirstMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>


<asp:BoundField DataField="decQntFifthMonth" HeaderText="Qnt5th" SortExpression="decQntFirstMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
<asp:BoundField DataField="amounttFifthMonth" HeaderText="Amount5th" SortExpression="amounttFirstMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

<asp:BoundField DataField="decQntSixthMonth" HeaderText="Qnt6th" SortExpression="decQntFirstMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
<asp:BoundField DataField="amounttSixthMonth" HeaderText="Amount6th" SortExpression="amounttFirstMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

<asp:BoundField DataField="decQntSeventhMonth" HeaderText="Qnt7th" SortExpression="decQntFirstMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
<asp:BoundField DataField="amounttSeventhMonth" HeaderText="Amount7th" SortExpression="amounttFirstMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

<asp:BoundField DataField="decQntEighthMonth" HeaderText="Qnt8th" SortExpression="decQntEighthMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
<asp:BoundField DataField="amounttEighthMonth" HeaderText="Amount8th" SortExpression="amounttEighthMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>



<asp:BoundField DataField="decQntNinthMonth" HeaderText="Qnt9th" SortExpression="decQntNinthMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
<asp:BoundField DataField="amounttNinthMonth" HeaderText="Amount9th" SortExpression="amounttNinthMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

<asp:BoundField DataField="decQntTenthMonth" HeaderText="Qnt9th" SortExpression="decQntTenthMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
<asp:BoundField DataField="amounttTenthMonth" HeaderText="Amount10th" SortExpression="amounttTenthMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

<asp:BoundField DataField="decQntEleventhMonth" HeaderText="Qnt11th" SortExpression="amounttEleventhMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
<asp:BoundField DataField="amounttEleventhMonth" HeaderText="Amount11th" SortExpression="amounttEleventhMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

<asp:BoundField DataField="decQntTwelvethMonth" HeaderText="Qnt12th" SortExpression="decQntTwelvethMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
<asp:BoundField DataField="amounttTwelvethMonth" HeaderText="Amount12th" SortExpression="amounttTwelvethMonth" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>


                    
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

    <asp:GridView ID="grdvDOCHPENDING" runat="server" AllowPaging="True" PageSize="111125"   AutoGenerateColumns="False" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" ShowFooter="True">

                    <Columns>
<asp:BoundField DataField="intCustomerId" HeaderText="CustomerID" SortExpression="intCustomerId" ItemStyle-HorizontalAlign="Center" >

<ItemStyle HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="strCustName" HeaderText="CustomerName" SortExpression="strCustName" ItemStyle-HorizontalAlign="Center" >

<ItemStyle HorizontalAlign="Center" />
</asp:BoundField>


<asp:BoundField DataField="strTerritory" HeaderText="Territroy" SortExpression="strTerritory" ItemStyle-HorizontalAlign="Center" >

<ItemStyle HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="strArea" HeaderText="Area" SortExpression="strArea" ItemStyle-HorizontalAlign="Center" >

<ItemStyle HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="strRegion" HeaderText="Region" SortExpression="strRegion" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>


<asp:BoundField DataField="strName" HeaderText="Sales Office" SortExpression="strName" ItemStyle-HorizontalAlign="Center" >

<ItemStyle HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="numPieces" HeaderText="DOQnt" SortExpression="numPieces" ItemStyle-HorizontalAlign="Center" >

<ItemStyle HorizontalAlign="Center" />
</asp:BoundField>

<asp:BoundField DataField="monTotalAmount" HeaderText="D.O Amount" SortExpression="monTotalAmount" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

<asp:BoundField DataField="challanqnt" HeaderText="ChallanQnt" SortExpression="challanqnt" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

<asp:BoundField DataField="challanamount" HeaderText="ChallanAmount" SortExpression="challanamount" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
<asp:BoundField DataField="openingpedningdoqnt" HeaderText="Opn. Pending DO" SortExpression="openingpedningdoqnt" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

<asp:BoundField DataField="openingpendingdoamount" HeaderText="Opn Pend Amount" SortExpression="openingpendingdoamount" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
<asp:BoundField DataField="currentlypendingdoqnt" HeaderText="CP DOQNT" SortExpression="currentlypendingdoqnt" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

<asp:BoundField DataField="currentlypendingdoamount" HeaderText="CP DOAmount" SortExpression="currentlypendingdoamount" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
<asp:BoundField DataField="remainingqnt" HeaderText="Pending Qnt" SortExpression="remainingqnt" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

<asp:BoundField DataField="pendingqntpricevalue" HeaderText="Pending Value" SortExpression="pendingqntpricevalue" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

                    
</Columns>


<FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
<HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
<PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
<RowStyle BackColor="White" ForeColor="#003399" />
<SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
<SortedAscendingCellStyle BackColor="#EDF6F6" />
<SortedAscendingHeaderStyle BackColor="#0D4AC4" />
<SortedDescendingCellStyle BackColor="#D6DFDF" />
<SortedDescendingHeaderStyle BackColor="#002876" />


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
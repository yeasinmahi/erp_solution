<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeliveryRequestAccess.aspx.cs" Inherits="UI.Inventory.DeliveryRequestAccess" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html >
<html >
<style type="text/css">
    .auto-style1 {
        margin-top: 0px; 
    }
</style>

<<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script src="../../../../Content/JS/datepickr.min.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <CompositeScript>
            <Scripts>
                <asp:ScriptReference name="MicrosoftAjax.js"/>
	<asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
	<asp:ScriptReference name="MicrosoftAjaxTimer.js" assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"/>
	<asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Common.DateTime.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.AnimationBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="PopupExtender.PopupBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Common.Threading.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Calendar.CalendarBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="AutoComplete.AutoCompleteBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
            </Scripts>
        </CompositeScript>
    </asp:ScriptManager>
   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                <asp:Panel ID="pnlMarque" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;
                        z-index: 1; position: absolute;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                            scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </marquee>
                    </div>
                </asp:Panel>
             <div class="leaveApplication_container"> 
    <div class="tabs_container"> Stock status :<asp:HiddenField ID="hdnenroll" runat="server"/>
        <asp:HiddenField ID="hdnunitid" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
        <asp:HiddenField ID="hdnEmail" runat="server"/>
        <hr /></div>
        <table border="0"; style="width:Auto"; >    
        
  
                       <tr class="tblrowodd">
                            
                             <td align="right">
                             <asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit  "></asp:Label>
                                 </td>
                           <td>
                                <asp:DropDownList ID="ddlUnit" runat="server" CssClass="ddl" AutoPostBack="True" DataSourceID="odsUnit"
                                    DataTextField="strUnit" DataValueField="intUnitID" 
                                    OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
                                    <SelectParameters>
                                        <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                         <td>
                             <asp:Label ID="lblWareHouse" CssClass="lbl" runat="server" Text="ShippingPoint:  "></asp:Label>
                            </td>
                   
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
                                                    <asp:ControlParameter ControlID="ddlUnit" Name="unitId" PropertyName="SelectedValue"
                                                        Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>

                           </td>




                        </tr>
                       <tr class="tblroweven">
                          
                       
                            <td>  
                              <asp:Label ID="lblrpt" runat="server" Text="Report Type" Visible="false"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drdlrpt" runat="server" CssClass="ddl" Visible="false">
                                    <asp:ListItem Text="Closing Stock" Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Opening Stock" Value="2" ></asp:ListItem>


                                </asp:DropDownList>
                            </td>
                           
                             <td>  
                               <asp:Label ID="lblrpttype" runat="server"  Text="Category" Visible="false"></asp:Label> 
                            </td>
                            <td>
                                <asp:DropDownList ID="ddltypeofrPT"  runat="server" CssClass="ddl" Visible="false">
                                    <asp:ListItem Text="Detaills" Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Top Sheet" Value="2" ></asp:ListItem>


                                </asp:DropDownList>
                            </td>
                        </tr>
             <tr class="tblrowodd">
                  <td align="right" colspan="4">
                                <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                            </td>
             </tr>
                    </table>
                </div>
            </asp:Panel>
            <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </cc1:AlwaysVisibleControlExtender>
            <div style="height: 150px;">
            </div>
           

             <div class="leaveApplication_container"> 
             <table>
                 <tr class="tblroweven"><td>
              <asp:GridView ID="grdvStock" runat="server" AutoGenerateColumns="False"  BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnPageIndexChanging="grdvStock_PageIndexChanging" OnRowDataBound="grdvStock_RowDataBound" CellSpacing="2">
                  <Columns>
                  
                    <asp:TemplateField HeaderText="Sl"> <ItemTemplate> <%#Container.DataItemIndex+1 %> 
                    
                    </ItemTemplate></asp:TemplateField>
                  
                      <%--intsaditem,stritem,struom,shippingpointname,openingqnt, challanqnt, closingqnt,pendingorderqnt, pendingqntpricevalue,shortage--%>
                      <asp:BoundField DataField="intsaditem" HeaderText="Item ID" SortExpression="intsaditem" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                        <asp:BoundField DataField="converteditemcode" HeaderText="Item Code" SortExpression="converteditemcode" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                      <asp:BoundField DataField="stritem" HeaderText="Item Name" SortExpression="stritem" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                
                     <asp:BoundField DataField="shippingpointname" HeaderText="Point" SortExpression="shippingpointname" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>                     
                         <asp:BoundField DataField="pendingorderqnt" HeaderText="Pending Qnt" SortExpression="pendingorderqnt" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                        <asp:BoundField DataField="pendingqntpricevalue" HeaderText="Pendingqntpricevalue" SortExpression="pendingqntpricevalue" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                      
                      <asp:BoundField DataField="openingqnt" HeaderText="Opening Qnt" Visible="false" SortExpression="openingqnt" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                        <asp:BoundField DataField="challanqnt" HeaderText="Challan Qnt" Visible="false" SortExpression="challanqnt" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                     <asp:BoundField DataField="closingqnt" HeaderText="Closing Stock" SortExpression="closingqnt" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                      
                  
                     <asp:BoundField DataField="shortage" HeaderText="Shortage" SortExpression="shortage" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                      <asp:BoundField DataField="transferqntpending" HeaderText="Rest of Transfer" SortExpression="transferqntpending" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>

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
                    <HeaderStyle CssClass="GridviewScrollHeader" /><PagerStyle CssClass="GridviewScrollPager" />
                   </asp:GridView> </td></tr>   
                    </table>
             </div>


        </ContentTemplate>
    </asp:UpdatePanel>
       
    </form>
</body>
</html>

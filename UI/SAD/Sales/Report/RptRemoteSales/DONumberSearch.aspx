<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DONumberSearch.aspx.cs" Inherits="UI.SAD.Sales.Report.RptRemoteSales.DONumberSearch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html >
<head id="Head1" runat="server">
    <title>Untitled Page</title>

     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />   

     <link href="../../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css"/> 

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
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 100px; float: right;">
                    <table style="width: 800px;">
                        <tr>
                                          <%--DATE FORMAT--%>  
                            <td>

                                D.O Number 

                            </td>
                               <td>
                                   <asp:TextBox ID="txtDO" runat="server"></asp:TextBox>
                               </td>
                        </tr>
                       
                        <tr>
                            
                            <td colspan="2" align="right">
                                <table>
                                    <tr>
                                       

                                        <td>
                                            <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />

                                        </td>
                                            
                                       
                                    </tr>


                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
          
 <div style="height: 120px;">
            </div>
            <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </cc1:AlwaysVisibleControlExtender>
            
<%--=========================================Start My Code From Here===============================================--%>



         
                
                 <table>
                     <tr>
                         <td>
                             <asp:Label ID="lblProductDelv" runat="server" Font-Bold="true" Font-Italic="true" Font-Size="Large"> Customer support by Challan number and other informations</asp:Label>

                         </td>


                     </tr>
              <tr>

                  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%" PageSize="15" AllowPaging="True" HeaderStyle-BackColor="#666699" GridLines="Vertical" OnPageIndexChanging="GridView1_PageIndexChanging">

                                            <AlternatingRowStyle BackColor="#DCDCDC" />

                                            <Columns>
                                                <asp:BoundField DataField="Column1" HeaderText=" Transaction Date" SortExpression="dtedate" ControlStyle-Width="5%" >
                                                 <ControlStyle Width="10%" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="strCode" HeaderText="TripCode" SortExpression="strTrip"  ControlStyle-Width="10%" >
                                                <ControlStyle Width="10%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="numQuantity" HeaderText="Qnt" SortExpression="decQnt" ControlStyle-Width="10%" >
                                                 <ControlStyle Width="10%" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="numPromotion" HeaderText="PromQ" SortExpression="decProm" ControlStyle-Width="10%" >

                                                 <ControlStyle Width="10%" />
                                                </asp:BoundField>

                                                 <asp:BoundField DataField="strAddress"  HeaderText="Address" SortExpression="strAddress" ControlStyle-Width="10%" >
                                                 
                                                
                                                <ControlStyle Width="10%" />
                                                </asp:BoundField>
                                                 
                                                 <asp:BoundField DataField="strProductName"  HeaderText="Item" SortExpression="strItem" ControlStyle-Width="10%" >
                                                 
                                                
                                                <ControlStyle Width="5%" />
                                                </asp:BoundField>
                                                 
                                              
                                                 <asp:BoundField DataField="strName"  HeaderText="Sales office" SortExpression="strSalesoff" ControlStyle-Width="10%" >
                                                 
                                                
                                                <ControlStyle Width="10%" />
                                                </asp:BoundField>

                                                 <asp:BoundField DataField="strVehicleRegNo"  HeaderText="Vehicle No." SortExpression="strSalesoff" ControlStyle-Width="10%" >
                                                 
                                                
                                                <ControlStyle Width="10%" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="strDriver"  HeaderText="Driver Name" SortExpression="strDrive" ControlStyle-Width="10%" >
                                                 
                                                
                                                <ControlStyle Width="5%" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="strDriverContact"  HeaderText="Driv. Ph." SortExpression="strDriver" ControlStyle-Width="10%" >
                                                 
                                                
                                                <ControlStyle Width="10%" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="strName1"  HeaderText="Shift. point" SortExpression="strShip" ControlStyle-Width="10%" >
                                                 
                                                
                                                <ControlStyle Width="10%" />
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


              </tr>


          </table>
             <FooterStyle BackColor="#CCCCCC" />
                                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                                            <RowStyle BackColor="White" />
                                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#808080" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#383838" />
                 
                 
                 
                            
          

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>   
    </form>
</body>
</html>


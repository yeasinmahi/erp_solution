<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DODetails.aspx.cs" Inherits="UI.SAD.Sales.Report.RptRemoteSales.DODetails" %>

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
          <table><tr>
            <td style="text-align:right;"><asp:Label ID="lblappointment" CssClass="lbl" runat="server" Text="From-Date : "></asp:Label></td>
                <td><asp:TextBox ID="txtFDate" runat="server" CssClass="txtBox"></asp:TextBox>
                    <cc1:CalendarExtender ID="FD" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFDate">
                    </cc1:CalendarExtender> 
                </td>
            <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To-Date : "></asp:Label></td>
                <td><asp:TextBox ID="txtTo" runat="server" CssClass="txtBox"></asp:TextBox>
                    <cc1:CalendarExtender ID="TD" runat="server" Format="yyyy-MM-dd" TargetControlID="txtTo">
                    </cc1:CalendarExtender> 
                </td>
               </tr>
            <tr>
            <td style="text-align:right;"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Region : "></asp:Label></td>
                <td><asp:DropDownList ID="drdlRegionName" runat="server" CssClass="ddList" DataSourceID="odsRegionShpvsSale" DataTextField="strText" DataValueField="intID" AutoPostBack="true"></asp:DropDownList>


                         <asp:ObjectDataSource ID="odsRegionShpvsSale" runat="server" SelectMethod="GetRegionbyUnit" TypeName="SAD_BLL.Sales.SalesConfig">
                             <SelectParameters>
                                 <asp:SessionParameter Name="unit" SessionField="sesUnit" Type="Int32" />
                             </SelectParameters>
                    </asp:ObjectDataSource>


                </td>
            <td style="text-align:right;"><asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Area : "></asp:Label></td>
                <td><asp:DropDownList ID="drdlArea" runat="server" CssClass="ddList" DataSourceID="odsAreaShpvsSale" DataTextField="strText" DataValueField="intID" AutoPostBack="true"></asp:DropDownList>

                        <asp:ObjectDataSource ID="odsAreaShpvsSale" runat="server" SelectMethod="GetAreaName" TypeName="SAD_BLL.Sales.SalesConfig">
                            <SelectParameters>
                                <asp:SessionParameter Name="unit" SessionField="sesUnit" Type="Int32" />
                                <asp:ControlParameter ControlID="drdlRegionName" Name="Region" PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                </td>
               </tr>

            <tr><td style="text-align:right;"><asp:Label ID="Label4" CssClass="lbl" runat="server" Text="Teritory : "></asp:Label></td>
                <td><asp:DropDownList ID="drdlTerritory" runat="server" CssClass="ddList" DataSourceID="odsTerritoryShpvsSales" DataTextField="strText" DataValueField="intID"></asp:DropDownList>


                        <asp:ObjectDataSource ID="odsTerritoryShpvsSales" runat="server" SelectMethod="GetTerritoryName" TypeName="SAD_BLL.Sales.SalesConfig">
                            <SelectParameters>
                                <asp:SessionParameter Name="unit" SessionField="sesUnit" Type="Int32" />
                                <asp:ControlParameter ControlID="drdlArea" Name="Area" PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                </td>
                <td colspan="2" style="text-align:right">
                          <asp:Button ID="btnShow" runat="server" Text="Show Report" CssClass="button" OnClick="btnShow_Click" /></td></tr>

              <tr><td colspan="4">
    <asp:GridView ID="dgvdodtls" runat="server" AllowPaging="true" PageSize="25" OnPageIndexChanging="dgvdodtls_PageIndexChanging" OnRowDataBound="dgvdodtls_RowDataBound" AutoGenerateColumns="false" CellPadding="5">

                    <Columns>

                        <%--<asp:BoundField DataField="strName" HeaderText="Shop Name" SortExpression="expShopname" ItemStyle-HorizontalAlign="Center" />--%>

                        <asp:BoundField DataField="Expr1" HeaderText="CreationDate" SortExpression="dteCreatedate" ItemStyle-HorizontalAlign="Center" />

                        <asp:BoundField DataField="strName" HeaderText="Customer Name" SortExpression="strCustm" ItemStyle-HorizontalAlign="Center" />

                        <asp:BoundField DataField="strText" HeaderText="Territroy" SortExpression="strTerritory" ItemStyle-HorizontalAlign="Center" />

                    <asp:BoundField DataField="Expr2" HeaderText="Area" SortExpression="strArea" ItemStyle-HorizontalAlign="Center" />

                        <asp:BoundField DataField="Expr3" HeaderText="Region" SortExpression="strRegion" ItemStyle-HorizontalAlign="Center" />

                        <asp:BoundField DataField="Expr4" HeaderText="Salesoffice" SortExpression="strSalesOffice" ItemStyle-HorizontalAlign="Center" />

                    
                     <asp:BoundField DataField="strCode" HeaderText="D.O Nmuber" SortExpression="strDO" ItemStyle-HorizontalAlign="Center" />

                        <asp:BoundField DataField="Expr5" HeaderText="Point Name" SortExpression="strPoint" ItemStyle-HorizontalAlign="Center" />

                        <asp:BoundField DataField="intDisPointId" HeaderText="Shop ID" SortExpression="strShop" ItemStyle-HorizontalAlign="Center" />

                    
                         <asp:BoundField DataField="Expr6" HeaderText="Shop Name" SortExpression="strShop" ItemStyle-HorizontalAlign="Center" />

                        <asp:BoundField DataField="numPieces" HeaderText="Numpieces" SortExpression="decNump" ItemStyle-HorizontalAlign="Center" />

                        <asp:BoundField DataField="monTotalAmount" HeaderText="Total Price" SortExpression="monPrice" ItemStyle-HorizontalAlign="Center" />

                        <asp:BoundField DataField="numRestPieces" HeaderText="Rest Qnt" SortExpression="decRestqnt" ItemStyle-HorizontalAlign="Center" />

                        <asp:BoundField DataField="ysnChallanCompleted" HeaderText="Challan status" SortExpression="strChallanStatus" ItemStyle-HorizontalAlign="Center" />




                    
                    </Columns>


                    </asp:GridView>
    </td></tr>

        </table>
 <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>   
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShopList.aspx.cs" Inherits="UI.SAD.Sales.Report.RptRemoteSales.ShopList" %>
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
         <table style="width: 90%;background-color:#ede9e9;">
               
                <tr>
                    <td align="left" colspan="1">
                        <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text=" Shop list (All) " />
                    </td>
                </tr>
                <tr>
                    <td>
                         <asp:Label ID="lbly" runat="server" Font-Bold="true" BackColor="#ffcccc"> All shop list - Territory basis </asp:Label>

                    </td>
                   

                </tr>
             <tr>
                 <td colspan="4">
                    <asp:GridView id="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging" AllowPaging="True" CellPadding="3"  PageSize="15" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" GridLines="Vertical" Width="100%" >

                        <AlternatingRowStyle BackColor="#CCCCCC" />

                        <Columns>
                            <asp:BoundField DataField="intSl" HeaderText="Sl" SortExpression="intSl" />
                            <asp:BoundField DataField="intShopid" HeaderText="Shop Id" SortExpression="intShopid" />

                            <asp:BoundField DataField="strShopname" HeaderText="Shop Name" SortExpression="strShopN" />

                            <asp:BoundField DataField="strTerritory" HeaderText="Territory" SortExpression="strTerritory" />
                            <asp:BoundField DataField="StrPropitor" HeaderText="Propitor" SortExpression="strContactp" />
                            <asp:BoundField DataField="strPhone" HeaderText="Phone" SortExpression="strPhone" />
                            <asp:BoundField DataField="strThana" HeaderText="Thana" SortExpression="strThana" />
                            <asp:BoundField DataField="strDistributor" HeaderText="Distributor" SortExpression="strDistributor" />
                            <asp:BoundField DataField="strSalesoffice" HeaderText="Sales Office" SortExpression="strSalesOffice" />
                             <asp:BoundField DataField="strEmail" HeaderText="Distributor Email" SortExpression="strEmail" />

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










<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>   
    </form>
</body>
</html>
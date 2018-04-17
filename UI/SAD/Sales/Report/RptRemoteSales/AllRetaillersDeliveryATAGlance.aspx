<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllRetaillersDeliveryATAGlance.aspx.cs" Inherits="UI.SAD.Sales.Report.RptRemoteSales.AllRetaillersDeliveryATAGlance" %>
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
                    <td>From Date</td>
                    <td>
                        <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="cal_Theme1" EnableViewState="true" Format="dd/MM/yyyy" PopupButtonID="imgCal_1" TargetControlID="txtFrom">
                        </cc1:CalendarExtender>
                        <img id="imgCal_1" src="../../../Content/images/img/calbtn.gif" style="border: 0px;
        width: 34px; height: 23px; vertical-align: bottom;" />
                    </td>
                    <td>To Date</td>
                    <td>
                        <asp:TextBox ID="txtTo" runat="server"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="cal_Theme1" EnableViewState="true" Format="dd/MM/yyyy" PopupButtonID="imgCal_2" TargetControlID="txtTo">
                        </cc1:CalendarExtender>
                        <img id="imgCal_2" src="../../../Content/images/img/calbtn.gif" style="border: 0px;
        width: 34px; height: 23px; vertical-align: bottom;" />
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="1">
                        <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text="Active or InActive " />
                    </td>
                </tr>
                <tr>
                    <td>
                         <asp:Label ID="lbly" runat="server" Font-Bold="true" BackColor="#ffcccc"> Active or InActive Retailer Sales Report - AT A Glance  </asp:Label>

                    </td>
                   

                </tr>
                <tr> <td colspan="4">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="True" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging" HeaderStyle-BackColor="#339966" HeaderStyle-Font-Bold="true" PageSize="15" CellPadding="1">
                        <Columns>
                            <asp:BoundField DataField="intshopid" HeaderText="Shop id" SortExpression="intshopid" />
                            <asp:BoundField DataField="strShopname" HeaderText="Shop Name" SortExpression="strSnam" />
                            <asp:BoundField DataField="strTer" HeaderText="Territory" SortExpression="strTerrit" />
                          
                             <asp:BoundField DataField="strContact" HeaderText="Contact" SortExpression="strContact" />
                            <asp:BoundField DataField="strphone" HeaderText="Phone" SortExpression="strSnam" />
                            <asp:BoundField DataField="strDist" HeaderText="Distributor" SortExpression="strDistr" />
                          

                            <asp:BoundField DataField="strSalesoffice" HeaderText="Sales Office" SortExpression="strSalesOf" />
                            <asp:BoundField DataField="decSales" HeaderText="Sales Qnt" SortExpression="decSales" />
                            <asp:BoundField DataField="decTarget" HeaderText="Target" SortExpression="decTarget" />

                            <asp:BoundField DataField="decAch" HeaderText="Achievement%" SortExpression="decAch" />

                        </Columns>



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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RetaillerYearlySales.aspx.cs" Inherits="UI.SAD.Sales.Report.RptRemoteSales.RetaillerYearlySales" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html >
<html >
<head id="Head1" runat="server">
    <title>Untitled Page</title>

     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    
    <link href="../../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css"/>   

</head>
<body>
    <form id="frmtcachv" runat="server">
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
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;"></div>
    </asp:Panel><div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender2" runat="server">
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
                    <%--<td>To Date</td>
                    <td>
                        <asp:TextBox ID="txtTo" runat="server"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="cal_Theme1" EnableViewState="true" Format="dd/MM/yyyy" PopupButtonID="imgCal_2" TargetControlID="txtTo">
                        </cc1:CalendarExtender>
                        <img id="imgCal_2" src="../../../Content/images/img/calbtn.gif" style="border: 0px;
        width: 34px; height: 23px; vertical-align: bottom;" />
                    </td>--%>
                </tr>
                <tr>
                    <td align="right" colspan="2">
                        <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text="Y.Retail Sales" />
                    </td>
                </tr>
                <tr>
                    <td>
                         <asp:Label ID="lbly" runat="server" Font-Bold="true" BackColor="#ffcccc"> Retailler yearly sales  </asp:Label>

                    </td>
                   

                </tr>
                

                <tr>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging"  Font-Names="Verdana" PageSize="15" AllowPaging="true" HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="YellowGreen" RowStyle-BorderColor="#999966" BackColor="White" BorderColor="#999999" BorderStyle="Solid" 
                BorderWidth="1px" CellPadding="1" ForeColor="Black">
                        <Columns>
                            <asp:BoundField DataField="intDispid" HeaderText="Shop ID" SortExpression="intShopid" />

                            <asp:BoundField DataField="strDispointName" HeaderText="Shop Name" SortExpression="strShop" />
                            <asp:BoundField DataField="strTerritory" HeaderText="Territory" SortExpression="strTerr" />
                            <asp:BoundField DataField="strDistr" HeaderText="Distributor" SortExpression="strDistr" />
                            <asp:BoundField DataField="strSalesOffice" HeaderText="SalesOffice" SortExpression="strSales" />
                            <asp:BoundField DataField="fst" HeaderText="January" SortExpression="decJan" />
                             <asp:BoundField DataField="sec" HeaderText="February" SortExpression="decFeb" />
                            <asp:BoundField DataField="thrd" HeaderText="March." SortExpression="decMar" />

                            <asp:BoundField DataField="fourth" HeaderText="April" SortExpression="decApr" />
                             <asp:BoundField DataField="fifth" HeaderText="May." SortExpression="decMay" />
                            <asp:BoundField DataField="sixth" HeaderText="June" SortExpression="decJune" />


                            <asp:BoundField DataField="sev" HeaderText="July" SortExpression="decJuly" />
                             <asp:BoundField DataField="eight" HeaderText="Augest" SortExpression="decAugest" />
                            <asp:BoundField DataField="Ninth" HeaderText="Sept." SortExpression="decSept." />


                             <asp:BoundField DataField="tenth" HeaderText="October" SortExpression="decJuly" />
                             <asp:BoundField DataField="Eleventh" HeaderText="November" SortExpression="decAugest" />
                            <asp:BoundField DataField="Twelveth" HeaderText="December" SortExpression="decSept." />
                              <asp:BoundField DataField="Column1" HeaderText="Grand Delv." SortExpression="decGrand." />




                        </Columns>







                    </asp:GridView>



                </tr>



            <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

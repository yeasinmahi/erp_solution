<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RetailerSalesDayByDayBasis.aspx.cs" Inherits="UI.SAD.Sales.Report.RptRemoteSales.RetailerSalesDayByDayBasis" %>

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
                        <asp:TextBox ID="txtFrom" runat="server" autocomplete="off"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="cal_Theme1" EnableViewState="true" Format="dd/MM/yyyy" PopupButtonID="imgCal_1" TargetControlID="txtFrom">
                        </cc1:CalendarExtender>
                        <img id="imgCal_1" src="../../../Content/images/img/calbtn.gif" style="border: 0px;
        width: 34px; height: 23px; vertical-align: bottom;" />
                    </td>
                    <td>To Date</td>
                    <td>
                        <asp:TextBox ID="txtTo" runat="server" autocomplete="off"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="cal_Theme1" EnableViewState="true" Format="dd/MM/yyyy" PopupButtonID="imgCal_2" TargetControlID="txtTo">
                        </cc1:CalendarExtender>
                        <img id="imgCal_2" src="../../../Content/images/img/calbtn.gif" style="border: 0px;
        width: 34px; height: 23px; vertical-align: bottom;" />
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="2">
                        <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text="Daily Retail Sales" />
                    </td>
                </tr>
                <tr>
                    <td>
                         <asp:Label ID="lbly" runat="server" Font-Bold="true" BackColor="#ffcc99" Font-Italic="true" > Retailer Sales (Day by Day basis)  </asp:Label>

                    </td>
                   

                </tr>
             <tr>

                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" Width="100%" PageSize="15" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">

                     <AlternatingRowStyle BackColor="#CCCCCC" />

                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Sl" SortExpression="intSl"  ControlStyle-Width="1%">
                         <ControlStyle Width="1%" />
                        </asp:BoundField>
                         <asp:BoundField DataField="intDispid" HeaderText="Shop id" SortExpression="intShopid"  ControlStyle-Width="2.5%">
                            <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                            <asp:BoundField DataField="strDispointName" HeaderText="Shop Name" SortExpression="intShopid"  ControlStyle-Width="7%">

                             <ControlStyle Width="7%" />
                        </asp:BoundField>

                             <asp:BoundField DataField="strTerritory" HeaderText="Territory" SortExpression="strTerr"  ControlStyle-Width="2.5%">
                               <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                               <asp:BoundField DataField="strDistr" HeaderText="Distributor Name" SortExpression="strCust"  ControlStyle-Width="10%">
                                 <ControlStyle Width="10%" />
                        </asp:BoundField>
                                 <asp:BoundField DataField="strSalesOffice" HeaderText="Sales Office" SortExpression="strSalesOFF"  ControlStyle-Width="5%">   
                                  
                          <ControlStyle Width="5%" />
                        </asp:BoundField>
                                  
                          <asp:BoundField DataField="fst" HeaderText="1ST" SortExpression="decIst"  ControlStyle-Width="2.5%">
                          <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                          <asp:BoundField DataField="sec" HeaderText="2nd" SortExpression="decSec"  ControlStyle-Width="2.5%">
                           <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                           <asp:BoundField DataField="thrd" HeaderText="3rd " SortExpression="decrd"  ControlStyle-Width="2.5%">   
                                  
                        <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                                  
                        <asp:BoundField DataField="fourth" HeaderText="4th" SortExpression="dec4"  ControlStyle-Width="2.5%">
                          <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                          <asp:BoundField DataField="fifth" HeaderText="5th" SortExpression="dec5"  ControlStyle-Width="2.5%">
                           <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                           <asp:BoundField DataField="sixth" HeaderText="6th " SortExpression="dec6"  ControlStyle-Width="2.5%">   
                                

                        <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                                

                        <asp:BoundField DataField="sev" HeaderText="7th" SortExpression="dec7"  ControlStyle-Width="2.5%">
                          <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                          <asp:BoundField DataField="eight" HeaderText="8th" SortExpression="dec8"  ControlStyle-Width="2.5%">
                           <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                           <asp:BoundField DataField="Ninth" HeaderText="9th " SortExpression="dec9"  ControlStyle-Width="2.5%">   
                                
                        <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                                
                        <asp:BoundField DataField="tenth" HeaderText="10th" SortExpression="dec10"  ControlStyle-Width="2.5%">
                          <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                          <asp:BoundField DataField="Eleventh" HeaderText="11th" SortExpression="dec11"  ControlStyle-Width="2.5%">
                           <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                           <asp:BoundField DataField="Twelveth" HeaderText="12th " SortExpression="dec12"  ControlStyle-Width="2.5%">   
                             
                         <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                             
                         <asp:BoundField DataField="thirten" HeaderText="13th" SortExpression="dec13"  ControlStyle-Width="2.5%">
                          <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                          <asp:BoundField DataField="fourten" HeaderText="14th" SortExpression="dec14"  ControlStyle-Width="2.5%">
                           <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                           <asp:BoundField DataField="fiften" HeaderText="15th " SortExpression="decr15"  ControlStyle-Width="2.5%">   
                             
                         <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                             
                         <asp:BoundField DataField="sixten" HeaderText="16th" SortExpression="dec16"  ControlStyle-Width="2.5%">
                          <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                          <asp:BoundField DataField="sevent" HeaderText="17th" SortExpression="dec17"  ControlStyle-Width="2.5%">
                           <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                           <asp:BoundField DataField="eighten" HeaderText="18th " SortExpression="dec18"  ControlStyle-Width="2.5%">   
                           
                        <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                           
                        <asp:BoundField DataField="ninetenn" HeaderText="19th" SortExpression="dec19"  ControlStyle-Width="2.5%">
                          <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                          <asp:BoundField DataField="twenty" HeaderText="20th" SortExpression="dec20"  ControlStyle-Width="2.5%">
                           <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                           <asp:BoundField DataField="twenty1" HeaderText="21th " SortExpression="dec21"  ControlStyle-Width="2.5%">   
                           

                         <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                           

                         <asp:BoundField DataField="twenty2" HeaderText="22th" SortExpression="dec22"  ControlStyle-Width="2.5%">
                          <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                          <asp:BoundField DataField="twent3" HeaderText="23th" SortExpression="dec23"  ControlStyle-Width="2.5%">
                           <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                           <asp:BoundField DataField="t24" HeaderText="24th " SortExpression="dec24"  ControlStyle-Width="2.5%">   
                           

                         <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                           

                         <asp:BoundField DataField="t25" HeaderText="25th" SortExpression="dec25"  ControlStyle-Width="2.5%">
                          <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                          <asp:BoundField DataField="t26" HeaderText="26th" SortExpression="dec26"  ControlStyle-Width="2.5%">
                           <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                           <asp:BoundField DataField="t27" HeaderText="27th " SortExpression="dec27"  ControlStyle-Width="2.5%">   
                           

                        <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                           

                        <asp:BoundField DataField="t28" HeaderText="28th" SortExpression="dec28"  ControlStyle-Width="2.5%">
                          <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                          <asp:BoundField DataField="t29" HeaderText="29th" SortExpression="dec29"  ControlStyle-Width="2.5%">
                           <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                           <asp:BoundField DataField="t30" HeaderText="30th " SortExpression="dec30"  ControlStyle-Width="2.5%">   
                           

                         <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                           

                         <asp:BoundField DataField="t31" HeaderText="31th" SortExpression="dec31"  ControlStyle-Width="2.5%">
                          <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                          <asp:BoundField DataField="targ" HeaderText="Target Qnt." SortExpression="decTarg"  ControlStyle-Width="2.5%">
                           <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                           <asp:BoundField DataField="Grandsales" HeaderText="Grand " SortExpression="decGrand"  ControlStyle-Width="2.5%">   
                           
                        <ControlStyle Width="2.5%" />
                        </asp:BoundField>
                           
                        <asp:BoundField DataField="Column1" HeaderText="Achieve% " SortExpression="decAch."  ControlStyle-Width="2.5%">   


                        <ControlStyle Width="2.5%" />
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


             </tr>




             </table>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>   
    </form>
</body>
</html>

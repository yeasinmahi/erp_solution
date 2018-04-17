<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoteRptDistributorCoverage.aspx.cs" Inherits="UI.SAD.Sales.Report.RptRemoteSales.RemoteRptDistributorCoverage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html >
<html >
<head runat="server">
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
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
      <table style="width: 90%;background-color:#ede9e9;">
        <tr><td>From Date</td><td><asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
        <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFrom" Format="dd/MM/yyyy"
        PopupButtonID="imgCal_1" ID="CalendarExtender2" runat="server" EnableViewState="true">
        </cc1:CalendarExtender><img id="imgCal_1" src="../../../Content/images/img/calbtn.gif" style="border: 0px;
        width: 34px; height: 23px; vertical-align: bottom;" /></td>

        <td>To Date</td><td><asp:TextBox ID="txtTo" runat="server"></asp:TextBox>
        <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtTo" Format="dd/MM/yyyy"
        PopupButtonID="imgCal_2" ID="CalendarExtender1" runat="server" EnableViewState="true">
        </cc1:CalendarExtender><img id="imgCal_2" src="../../../Content/images/img/calbtn.gif" style="border: 0px;
        width: 34px; height: 23px; vertical-align: bottom;" /></td></tr>

    <tr><td align="right" colspan="4">
                                <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                            </td>
                        </tr>

          <tr>
              <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" AutoGenerateColumns="false" AllowPaging="true" CellPadding="5" HeaderStyle-BackColor="#ccccff">

               <Columns>
                   <asp:BoundField DataField="strCustname" HeaderText="Customer Name" SortExpression="strname" />
                   <asp:BoundField DataField="strTerritory" HeaderText="Territory" SortExpression="strTer" />
                   <asp:BoundField DataField="Totaldelv" HeaderText="Sales" SortExpression="decDelv" />
                   <asp:BoundField DataField="targets" HeaderText="Targets" SortExpression="decTarget" />
                   <asp:BoundField DataField="salesachive" HeaderText="Achieve%" SortExpression="decAC" />

                   <asp:BoundField DataField="Totalshop" HeaderText="T. Shop" SortExpression="intTShop" />
                   <asp:BoundField DataField="Soldshop" HeaderText="S. Shop" SortExpression="intSolds" />
                   <asp:BoundField DataField="Column1" HeaderText="Covr%" SortExpression="decCov" />
                   <asp:BoundField DataField="Column2" HeaderText="Minm.Cov" SortExpression="decMinCov" />
            
                   <asp:BoundField DataField="MINCOM" HeaderText="Allowable" SortExpression="decAllowable" />
                   <asp:BoundField DataField="Total comm" HeaderText="Covr. Comm." SortExpression="decCoveragecom" />


               </Columns>



              </asp:GridView>





          </tr>

 <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

<%@ Control Language="C#" AutoEventWireup="true" Inherits=" UI.Components.Calender" Codebehind="Calender.ascx.cs" %>

<asp:Panel ID="pnlCompAkramCalendar" runat="server">
    
    <link href="~/Content/CSS/CalendarComponemt.css" rel="stylesheet" type="text/css"/>
    <script type="text/javascript" src="~/Content/JS/calendar/CalendarPopup.js"></script>
    <script type="text/javascript" src="~/Content/JS/calendar/PopupWindow.js"></script>
    <script type="text/javascript" src="~/Content/JS/calendar/AnchorPosition.js"></script>
    <script type="text/javascript" src="~/Content/JS/calendar/date.js"></script>
    
    <script type="text/javascript">
        var calPopCal = new CalendarPopup("<%# this.ID %>$testdiv1");
        calPopCal.showNavigationDropdowns();
    </script>   
    <table width="150" style="height:20px;">
        <tr>
            <td style="text-align: right" colspan="2">
                <div id="<%# this.ID %>$testdiv1" style="position: absolute;z-index:10; visibility: hidden; background-color: #F0F0F0;">
                </div>
            </td>
        </tr>
        <tr>
            <td>                
                <asp:TextBox ID="txtDate" ReadOnly="true" runat="server" Width="150px" ></asp:TextBox></td>
            <td>
                <a name="<%# this.ID %>$aSelect" id="<%# this.ID %>$aSelect" href="#" onclick="calPopCal.select(document.forms[0].<%# this.ID %>$txtDate,'<%# this.ID %>$aSelect','dd/MM/yyyy'); return false;">
                    <img src="<%# pre %>images/calbtn.gif" style="border: 0px;
                        width: 34px; height: 23px;" />
                </a>
            </td>
        </tr>        
    </table>
    
</asp:Panel>

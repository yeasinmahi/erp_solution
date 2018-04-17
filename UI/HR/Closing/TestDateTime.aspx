<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestDateTime.aspx.cs" Inherits="UI.HR.Closing.TestDateTime" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %><%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<!DOCTYPE html>

<html><head runat="server"><title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script>
        function GetTimeSpan() {
            var st = document.getElementById('txtstrt').value;
            //alert(st);
            var date1 = new Date();
            var datediff = date1.getTime() / (1000 * 3600 * 24);
            document.getElementById("txtend").innerText = datediff.getHours();
        }
    </script>
</head>
<body>
    <form id="frmtsttmdt" runat="server">
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
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
    <div class="divs_content_container"><b>Employee Official Movement: </b><hr />
    <table border="0" style="width:Auto";>   
    <tr>
    <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Start-Time : "></asp:Label></td>
    <td><asp:TextBox ID="txtstrt" runat="server" onchange="GetTimeSpan()"></asp:TextBox><script>$('#txtstrt').timepicker();</script></td>
    <td style="text-align:right;"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="End-Time : "></asp:Label></td>
    <td><asp:TextBox ID="txtend" runat="server"></asp:TextBox></td>
    </tr>

    <tr>
    <td style="text-align:right;"><asp:Label ID="lblstrt" CssClass="lbl" runat="server" Text="Start-Time : "></asp:Label></td>
    <td><MKB:TimeSelector ID="tmStart" runat="server"  SelectedTimeFormat="TwentyFour" OnDataBinding="tmStart_DataBinding" OnDisposed="tmStart_Disposed" OnInit="tmStart_Init" OnLoad="tmStart_Load" OnPreRender="tmStart_PreRender" OnUnload="tmStart_Unload"></MKB:TimeSelector></td>
    <td style="text-align:right;"><asp:Label ID="lblend" CssClass="lbl" runat="server" Text="End-Time : "></asp:Label></td>
    <td><MKB:TimeSelector ID="tmEnd" runat="server" SelectedTimeFormat="TwentyFour"></MKB:TimeSelector></td>
    </tr>
    </table>
    </div>

     <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

<%@ Page Language="C#"  AutoEventWireup="true" Inherits="UI.Footer" Codebehind="Footer.aspx.cs" %>


<!DOCTYPE html>
<html  >
<head runat="server">
    <title>Welcome to Akij Group</title>
    
    <link href="Content/CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<script type="text/javascript">
    function scrollPanel()
        {
            //var panel = document.getElementById("pnlJSScroll");
            //panel.scrollTop=panel.scrollHeight;
           // alert('ok');
        }
</script>
<body style="background-color: #000000">
    <form id="form1" runat="server">    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <div style="text-align:left; padding-left:215px;">
        <span class="groupAddr">Akij Chamber, 73, Dilkusha Commercial Area, Dhaka- 1000, Bangladesh PABX: 880-2-9563008, 880-2-7169017-8, Fax: 880-2-9564519, Email: info@akij.net. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; © 2010 Software Dept. Akij Group</span>
    </div>
    <%--<asp:Panel ID="pnlJSScroll" runat="server" Height="250px" ScrollBars="Vertical">
    
    </asp:Panel>
    <asp:Timer ID="Timer1" runat="server" ontick="Timer1_Tick" Enabled="False">
    </asp:Timer>--%>        
    </form>    
</body>
</html>


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttendanceDetailsView.aspx.cs" Inherits="UI.HR.Attendance.AttendanceDetailsView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder0" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>  
    <webopt:BundleReference ID="BundleReference0" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/hrCSS" />
    <style type="text/css">
    .attendancedetails {width: Auto; height: auto; background-color:#FFFFFF; border: solid 1px #c0c0c0;
     font-size: 11px; font-family: verdana; color: #000; padding: 5px 5px 5px 5px; }
    </style>

    <script>
        function Print() { document.getElementById("btnprint").style.display = "none"; window.print(); self.close();}
    </script>

</head>
<body>
    <form id="frmprevwattendancedetails" runat="server">
    <a id="btnprint" href="#" class="nextclick" style="cursor:pointer" onclick="Print()">Print</a>
    </form>
</body>
</html>

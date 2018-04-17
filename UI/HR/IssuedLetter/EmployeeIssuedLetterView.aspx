<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.HR.IssuedLetter.EmployeeIssuedLetterView" Codebehind="EmployeeIssuedLetterView.aspx.cs" %>

<!DOCTYPE html>

<html >
<head runat="server">
<title></title>
<script type="text/javascript">
    function Print() {
        Show();
        window.print();
        self.close();
    }
    function Show() {
        var dv = document.getElementById("viewDiv");
        dv.style.display = "block";

        dv = document.getElementById("btnPrint");
        dv.style.display = "none";
    }   

</script>
</head>
<body>
    <form id="frmIssuedLetterView" runat="server">
    <div id="viewDiv" width="100%" runat="server"></div>
    <div id="print" width="100%" runat="server" style="text-align:center;">
    <input id="btnPrint" type="submit" value="Print" onclick="Print()" />
    </div>
    </form>
</body>
</html>

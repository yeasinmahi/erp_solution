<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowSupporting.aspx.cs" Inherits="UI.HR.Salary.ShowSupporting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .dynamicDivbn {
            margin: 5px 5px 5px 5px;  
    	    width: Auto; 
    	    height: auto;
            background-color:#FFFFFF;
            font-size: 11px;
            font-family: verdana;
            color: #000;
            padding: 5px 5px 5px 5px;
        }
    </style>

    <script>
        function Print() {
            document.getElementById("btnprint").style.display = "none";
            window.print();
            self.close();
        }
    </script>
</head>
<body>
    <form id="frmShowSupporting" runat="server">
    <a id="btnprint" href="#" class="nextclick" style="cursor:pointer" onclick="Print()">Print</a>
    </form>
</body>
</html>

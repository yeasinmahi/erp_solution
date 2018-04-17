<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageView.aspx.cs" Inherits="UI.Document_Inventory.ImageView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .dynamicDivbn {
            margin: 5px 5px 5px 5px;    width: Auto; 
           height: auto;
            background-color:#FFFFFF;
            font-size: 11px;
            font-family: verdana;
            color: #000;
            padding: 5px 5px 5px 5px;
        }
        .frame { width: 99%; height: 550px; border: 0px; }
    .frame {zoom: 0.99;-moz-transform: scale(0.99);-moz-transform-origin: 0 0;-o-transform: scale(0.99);-o-transform-origin: 0 0;
    -webkit-transform: scale(0.99);-webkit-transform-origin: 0 0}
    </style>

</head>
<body>
    <form id="form1" runat="server"><asp:PlaceHolder ID="myPanel" runat="server"></asp:PlaceHolder></form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentView.aspx.cs" Inherits="UI.Other.DocumentView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="imageDiv">
            <asp:Image runat="server" ID="image" class="image" width="850" />
        </div>
        <div id="pdfDiv">
            <embed runat="server" id="embad" alt="Pdf viewer" width="850" height="480"/>
        </div>
    </form>
</body>
</html>

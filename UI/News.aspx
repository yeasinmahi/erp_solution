<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.News" Codebehind="News.aspx.cs" %>

<!DOCTYPE html>
<html >
<head runat="server">
    <title>Welcome to Akij Group</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divMain">
    <table width="100%" style="height:360px; background-color:#000000; color:#FFFFFF;" >
        <tr>
            <td style="vertical-align:top; width:110px;">
            <img alt="" src="App_Themes/Default/images/tech.gif" style="width: 109px; height: 110px" />
            </td>
            <td align="left" style="font-size: 12px; padding-top:30px; padding-left:200px;">                
                News
            </td>
        </tr>
    </table>
    </div>
    </form>
    
    <script type="text/javascript">        
        parent.SetInfo(document.getElementById("divMain").innerHTML,4);
    </script>
</body>
</html>

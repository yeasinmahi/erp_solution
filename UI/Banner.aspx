<%@ Page Language="C#"  AutoEventWireup="true" Inherits="UI.Banner" Codebehind="Banner.aspx.cs" %>

<!DOCTYPE html>

<html  >
<head id="Head1" runat="server">
    <title>Welcome to Akij Group</title>  
     
     <link href="Content/CSS/Banner.css" rel="stylesheet" type="text/css" />
    <!-- Global site tag (gtag.js) - Google Analytics -->
<script async src="https://www.googletagmanager.com/gtag/js?id=UA-125570863-1"></script>
<script>
  window.dataLayer = window.dataLayer || [];
  function gtag(){dataLayer.push(arguments);}
  gtag('js', new Date());
  gtag('config', 'UA-125570863-1');
</script> 
</head>
<body class="body">
    <form id="form2" runat="server">       
    <table width="100%">
            <tr style="height:40px;">
                <td align="left" style="vertical-align:bottom; padding-left:10px; width:200px;">
                    <asp:Label CssClass="hellouser" ID="lblName" runat="server" Text=""></asp:Label>
                </td>
                <td align="center" style="vertical-align:top;">
                    <span class="groupName">A K I J &nbsp;&nbsp;G r o u p</span>                    
                </td>
                
                <td align="right" style="vertical-align:top;">
                    <a class="signout" href="Logout.aspx" title="Sign Out" style="padding-right:20px; width:200px;">Sign Out</a>                     
                </td>
                
            </tr>            
        </table>        
    </form>
</body>
</html>


<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.HomePage" Codebehind="HomePage.aspx.cs" %>

<!DOCTYPE html>
<html  >
<head id="Head1" runat="server">
    <title>Welcome to Akij Group</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
      <asp:PlaceHolder ID="PlaceHolder1" runat="server">     
          <%: Scripts.Render("~/Content/Bundle/frmJS") %>
           <%: Scripts.Render("~/Content/Bundle/menuJS") %>
    </asp:PlaceHolder>   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/frmCSS" />

    <script type="text/javascript">
         window.dataLayer = window.dataLayer || [];
  function gtag(){dataLayer.push(arguments);}
  gtag('js', new Date());
        gtag('config', 'UA-125570863-1');

        //window.open("Banner.aspx", "mainWin","toolbar=0,location=0,directories=0,status=0,menubar=0,scrollbars=0,resizable=1,width=1011,height=710");    
        //window.location('address_goes_here');
        //alert('ol');
        //var curUrl = document.location.href;
        //document.location = ";;;";	    
        //alert(curUrl); 
        //top.window.moveTo(0,0);
        //top.window.resizeTo(screen.availWidth,screen.availHeight);        
    </script> 
     <!-- Global site tag (gtag.js) - Google Analytics -->
<%--<script async src="https://www.googletagmanager.com/gtag/js?id=UA-125570863-1"></script>
<script>
  window.dataLayer = window.dataLayer || [];
  function gtag(){dataLayer.push(arguments);}
  gtag('js', new Date());
    gtag('config', 'UA-125570863-1');


</script> --%>
</head>    

<frameset border="0" frameborder="no" framespacing="0" name="Akij" rows="50,*,15">
    <frame id="banner" marginheight="0" marginwidth="0" name="banner" noresize="noresize" scrolling="no" src="Banner.aspx"></frame>    
    <frameset border="0" frameborder="no" framespacing="0" name="AkijMain" cols="200,15,*">
        <frame id="left" marginheight="0" marginwidth="0" name="left" noresize="noresize" scrolling="no" src="Left.aspx"></frame>                    
        <frame id="slide" marginheight="0" marginwidth="0" name="slide" noresize="noresize" scrolling="no" src="Slide.aspx"></frame>                    
        <frame id="filter" marginheight="0" marginwidth="0" name="filter" noresize="noresize" scrolling="yes" src="Personal/Default.aspx"></frame>        
    </frameset>    
    <frame id="footer" marginheight="0" marginwidth="0" name="footer" noresize="noresize" scrolling="no" src="Footer.aspx"></frame>
</frameset>
<noframes>
    Please enable frame at your web browser.
</noframes>
<body>

</body>
</html>


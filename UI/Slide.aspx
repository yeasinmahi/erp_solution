<%@ Page Language="C#"  AutoEventWireup="true"
    Inherits="UI.Slide" Codebehind="Slide.aspx.cs" %>

<!DOCTYPE html>
<html >
<head id="Head1" runat="server">
    <title>Welcome to Akij Group</title>
    
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <script type="text/javascript"> 
    var flag=true;
    function Slider(){
        if(flag){            
            parent.frames["AkijMain"].setAttribute('cols', '0,15,*', 0);   
            document.getElementById("islide").src = "Content/images/icons/131.png";
            document.getElementById("islide").alt="Show Menu"
        }
        else{            
            parent.frames["AkijMain"].setAttribute('cols', '200,15,*', 0);                        
            document.getElementById("islide").src = "Content/images/icons/132.png";
            document.getElementById("islide").alt="Hide Menu"
        }
        flag = !flag;             
    }
    </script>
     <!-- Global site tag (gtag.js) - Google Analytics -->
<script async src="https://www.googletagmanager.com/gtag/js?id=UA-125570863-1"></script>
<script>
  window.dataLayer = window.dataLayer || [];
  function gtag(){dataLayer.push(arguments);}
  gtag('js', new Date());
  gtag('config', 'UA-125570863-1');
</script> 
</head>
<body style="background-color: #EEF1FB">
    <form id="form1" runat="server">
        <asp:Panel ID="pnlUpperControl" runat="server">
            <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
            
            <div style="vertical-align: middle; position: absolute; left: 0px; top:300px;">
            <a class="link" href="#" onclick="Slider()">
                <img alt="Hide Menu" style="border:none;" id="islide" src="Content/images/icons/132.png"/>
            </a>
            </div>
            </div>
            <%--<div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">
            </div>--%>
        </asp:Panel>        
    </form>
</body>
</html>

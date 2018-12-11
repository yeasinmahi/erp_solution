<%@ Page Language="C#" AutoEventWireup="true"  Inherits="UI.Default" Codebehind="Default.aspx.cs" %>
<!DOCTYPE html>
<html >
<head runat="server">
    <title>Welcome to Akij Group</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
 <!-- Global site tag (gtag.js) - Google Analytics -->
<script async src="https://www.googletagmanager.com/gtag/js?id=UA-125570863-1"></script>
<script>
    window.dataLayer = window.dataLayer || [];
    function gtag(){dataLayer.push(arguments);}
    gtag('js', new Date());
    gtag('config', 'UA-125570863-1');
</script> 
</head>
<body style="margin: 0px;"  >
    <!--
    <iframe height="0" id="uploadInfo" name="uploadInfo" src="" width="0"></iframe>
    <form name="mform" action="LoginProcess.aspx" method="post" target="thepopup" >
   
    <div id="loginDiv" 
        style=" display:none;   font-family: Verdana; color: #000000; position:relative; top: 50%; left: 50%; margin-top:100px ; margin-left:-100px;
        width:700px;" >
    
       <span class="style3"><strong>A K I J &nbsp&nbsp G R O U P
      </strong></span>
      <div style="border: 1px solid Black; width:653px; margin-right: 308px;">
      <table cellpadding="0" cellspacing="0" border="0px" style="width: 653px">
      <tr >
      <td style="border-color:White; height:40px; vertical-align:middle" class="fColumn" ><font size="4pt"> &nbsp;Sign In Your Domain Account</font></td>
      <td style="height:40px; vertical-align:middle"  class="sColumn" ><font size="4pt">&nbsp; Instructions</font></td>
      </tr>
      <tr>
      <td style="border-color:White; vertical-align:top" class="fColumn" >&nbsp;&nbsp;&nbsp;______________________________________</td>
      <td style="vertical-align:top" class="sColumn" >&nbsp;&nbsp;&nbsp;__________________________________</td>
      </tr>
      <tr>
      <td >&nbsp&nbsp</td>
      <td class="sColumn">&nbsp&nbsp</td>
      </tr>
      <tr>
        <td style="border-color:White" class="fColumn">
        <table>
        <tr>
        <td > E-mail</td>
        <td>&nbsp&nbsp</td>
        <td><input name="txtUserID" id="txtUserID"   /></td>
        </tr>
        <tr>
        <td colspan="3">&nbsp;</td>
        </tr>
        <tr>
        <td >Password
        </td>
        <td>&nbsp&nbsp</td>
        <td> <input type="password" name="txtPass" id="txtPass"  />
        </td>
        </tr>
        <tr>
        <td colspan="3">&nbsp;</td>
        </tr>
        <tr>
       <td colspan="3" align="right">
       <input type="submit" name="Log IN" title="Log In" value="Log In" 
               style="width: 80px; color:Navy" onclick="LoginOutOfDomain()" />
       </td>
        </tr>
        </table>
            
        
            
            
        </td>
        <td  class="sColumn" valign="top" >
        You are not loged in at akij Domain. To Get Access to ERP
        please get authentication from Akij Domain.<br />
        
        <ol>
        <li>
            Please Enter your email and password
            </li>
            <li>
                Or you Can Log off from your Current User of Windows and log in as Domain user.
                and Come back at ERP for Auto Login Solution
            </li>
        </ol>
        
        </td>
      </tr>
      </table>
      </div>
     
      </div>

    </form>
    <form name="frmUploadInfo" action="" id="frmUploadInfo" method="post" target="uploadInfo"
    style="display: none">
    </form>

    <script type="text/javascript"  >
        if (navigator.appName == 'Microsoft Internet Explorer') 
        {
            //var win = window.open('', 'thepopup', 'toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,top=0,left=0,fullscreen=yes,height=screen.height,width=screen.width');
            document.mform.submit();

            function LoginOutOfDomain() {
                var win = window.open('', 'thepopup', 'toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,top=0,left=0,fullscreen=yes,height=screen.height,width=screen.width');
                document.mform.submit();

            }

            function ActiveLogInForm() {

                document.getElementById('loginDiv').style.display = "block";

            }
        }
    </script> 


    <p style="text-align: center">
        &nbsp;</p>
        -->
    
</body>
</html>

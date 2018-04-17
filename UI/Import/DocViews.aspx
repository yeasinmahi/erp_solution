<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocViews.aspx.cs" Inherits="UI.Import.DocViews" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

     <script>   function CloseWindow() { window.close();  }
         //function RefreshParent() {
         //    if (window.opener != null && !window.opener.closed) {
         //        window.opener.location.reload();
         //    }
         //}

    </script> 
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
  
       <form id="form1" runat="server">
           
           <table> <tr><td><asp:Button ID="Button1" runat="server" BorderColor="Green" Text="Download" OnClick="Button1_Click" />
               </td>  </tr> 
           </table>   
           <asp:PlaceHolder ID="myPanel" runat="server"></asp:PlaceHolder></form> 
          
             
      
</body>
</html>

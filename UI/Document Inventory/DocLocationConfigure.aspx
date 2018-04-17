<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocLocationConfigure.aspx.cs" Inherits="UI.Document_Inventory.DocLocationConfigure" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
 <html xmlns="http://www.w3.org/1999/xhtml">   
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
      <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
       
    <script>
        function Save() {
            document.getElementById("hdnField").value = "1";
            __doPostBack();
        }

</script>
   

  
    
   
   

    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .ddList {}
        .txtBox {}
        </style>

     

   
    </head>
<body>
    <form id="frmaccountsrealize" runat="server">
   <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>






<%--=========================================Start My Code From Here===============================================--%>
    <div class="leaveApplication_container">
    <asp:HiddenField ID="hdnEnrollUnit" runat="server" /><asp:HiddenField ID="hdnCheck" runat="server" />
    <asp:HiddenField ID="hdnconfirm" runat="server" />
       
    <div class="tabs_container" align="Center" >Document Tracking System</div>
   
       <table  >
              <tr  >
                  
       <td style="text-align:right;" > <asp:Label ID="LblAsset" runat="server" CssClass="lbl" font-size="small" Text="Location:"></asp:Label></td>
          <td style="text-align: left;"><asp:DropDownList ID="ddlLocation" runat="server" CssClass="ddList" Font-Bold="True"  >
          
           </asp:DropDownList></td>
                            
                      
         <td style="text-align:right;"> <asp:Label ID="LblUnit" runat="server" CssClass="lbl" font-size="small" Text="File:"></asp:Label></td>
         <td style="text-align: left;"><asp:DropDownList ID="ddlFile" runat="server" CssClass="ddList" Font-Bold="True"  >
         </asp:DropDownList></td>
       
          </tr>
          <tr >
           <td style="text-align:right;"> <asp:Label ID="LblName" font-size="small" runat="server" CssClass="lbl" Text="Document Scan:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="txtDocID" runat="server" CssClass="txtBox" AutoPostBack="true" Font-Bold="False" OnTextChanged="txtDocID_TextChanged"></asp:TextBox>
         <td style="text-align:right;"> <asp:Label ID="LblStation" runat="server" font-size="small"  CssClass="lbl" Text="Narration:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TxtStation" runat="server" TextMode="MultiLine" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
           </tr>            
           
           <tr >
                 <td style="text-align:left" colspan="1"><asp:Label ID="lblDoc" runat="server"  /> </td>
                <td style="text-align:left" colspan="1"><asp:Label ID="docName" runat="server"  /> </td>
                   <td style="text-align:right" colspan="4" ><asp:Button ID="btnSubmit" runat="server" AutoPostBack="false" Text="Submit"  OnClientClick="ConfirmAll()" OnClick="btnSubmit_Click" /> </td>
             </tr>
           </table>
        <table>
          

         </table>
          
        
            
        </div>
         
            
<%--=========================================End My Code From Here=================================================--%>
      
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>


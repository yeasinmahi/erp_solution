<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateLocationAndFolder.aspx.cs" Inherits="UI.HR.DocumentTracking.CreateLocationAndFolder" %>

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
    <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnCheck" runat="server" />
    <asp:HiddenField ID="hdnconfirm" runat="server" />
       
    <div class="tabs_container" align="Center" >Create Location / Folder</div>
   
       <table  >
         <tr  >
                <td style="text-align:right;"><asp:Label ID="lblType" runat="server" CssClass="lbl" font-size="small" Text="Select Type:"></asp:Label></td>     
                <td style="text-align:left"><asp:DropDownList ID="ddlType" runat="server" CssClass="ddList" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" AutoPostBack="true"><asp:ListItem Selected="True" Value="1">Division</asp:ListItem>
                <asp:ListItem Value="2">Department</asp:ListItem><asp:ListItem Value="3">Section</asp:ListItem><asp:ListItem Value="4">Location</asp:ListItem>
                <asp:ListItem Value="5">Folder</asp:ListItem></asp:DropDownList></td>
           </tr>
           <tr>
             <td style="text-align:right;" > <asp:Label ID="lblDivision" runat="server" CssClass="lbl" font-size="small" Text="Division:"></asp:Label></td>
             <td style="text-align:left;"><asp:DropDownList ID="ddlDivision" runat="server" CssClass="ddList" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>                    
            </tr>
           
           <tr>
             <td style="text-align:right;" > <asp:Label ID="lblDepartment" runat="server" CssClass="lbl" font-size="small" Text="Department:"></asp:Label></td>
             <td style="text-align:left;"><asp:DropDownList ID="ddlDepartment" runat="server" CssClass="ddList" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged"></asp:DropDownList></td>                    
            </tr>
           <tr> 
               <td style="text-align:right;" > <asp:Label ID="lblSection" runat="server" CssClass="lbl" font-size="small" Text="Section:"></asp:Label></td>
                <td style="text-align:left;"><asp:DropDownList ID="ddlSection" runat="server" CssClass="ddList" OnSelectedIndexChanged="ddlSection_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
           </tr>
           <tr>
                     
               <td style="text-align:right;"> <asp:Label ID="lblLocation" runat="server" CssClass="lbl" font-size="small" Text="Location:"></asp:Label></td>
               <td style="text-align: left;"><asp:DropDownList ID="ddlLocation" runat="server" CssClass="ddList" Font-Bold="True" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged"  >
           </asp:DropDownList></td>
         </tr>
           <tr>
               <td style="text-align:right;"> <asp:Label ID="lblParam" runat="server" CssClass="lbl" font-size="small" Text=":"></asp:Label></td>
               <td style="text-align: left;"><asp:TextBox ID="txtParam" runat="server" CssClass="txtBox"></asp:TextBox></td>

           </tr>
          
                    
           
           <tr >
               
               <td style="text-align:right" colspan="2" ><asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" /> </td>
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


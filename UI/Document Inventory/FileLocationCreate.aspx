<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileLocationCreate.aspx.cs" Inherits="UI.Document_Inventory.FileLocationCreate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server"><title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>   
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
        <style type="text/css">
            .auto-style1 {
                height: 26px;
            }
            .auto-style2 {
                height: 20px;
            }
            .auto-style3 {
                width: 524px;
            }
            .auto-style4 {
                height: 23px;
            }
            .auto-style5 {
                height: 30px;
            }
        </style>
 
</head>
<body>
    <form id="frmreq" runat="server">
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
     <asp:HiddenField ID="hdnsearch" runat="server"/><asp:HiddenField ID="hdnUom" runat="server" /><asp:HiddenField ID="hdnupdate" runat="server" />
    <div class="leaveApplication_container"><table class="tbldecoration" border="0"; style="width:1000PX"; >
    <tr> 
    <td  colspan="2" style="color:forestgreen;height:20px;text-align:center" class="tblheader"><h2> File Location Create</h2></td>
    </tr>
    <tr>

    <td style="vertical-align:top;border-bottom:double;border-right:double;border-radius:6px;border-left:double;border-top:double"  class="auto-style3"> 
    <table style="vertical-align:top" width="100%">
    <tr class="tblrowodd">
    <td style="text-align:right;font-size:20px"><asp:Label ID="Label8" CssClass="lbl" Font-Size="14px" runat="server" Text="Type :"></asp:Label></td>
    <td class="auto-style1"><asp:DropDownList ID="ddllocationtype" runat="server" CssClass="ddList" >
        <asp:ListItem Value="1">Location Directory</asp:ListItem>
        <asp:ListItem Value="2">File Directory</asp:ListItem>
      
        </asp:DropDownList>   </td>  
    </tr>
    <tr class="tblrowodd">
    <td style="text-align:right;"><asp:Label ID="Label4" CssClass="lbl" Font-Size="13px" runat="server" Text="Name :"></asp:Label></td>
    <td class="auto-style1"><asp:TextBox ID="txtLocationName" runat="server" CssClass="txtBox"></asp:TextBox></td>  
    </tr>
    <tr class='tblrowodd'><td style="text-align:right;" class="auto-style5"></td>
    <td style="text-align:right" class="auto-style5" >
    <asp:Button ID="btnSearch" runat="server"  ForeColor="Green" Font-Bold="true" Text="Submit" OnClick="btnSearch_Click" />
    </td>   
    </tr>
    <tr class='tblrowodd'><td style="text-align:right;">&nbsp;</td>
    <td class="auto-style1">&nbsp;</td>  
    </tr>
    
   
    </table>
    </td>
    </tr>
       
      
    
        </td>
        </tr>
        <table>
        </table>
    </div>


<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

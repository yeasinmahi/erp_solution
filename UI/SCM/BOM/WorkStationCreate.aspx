<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkStationCreate.aspx.cs" Inherits="UI.SCM.BOM.WorkStationCreate" %>

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
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
        
    <script type="text/javascript">
        function OpenHdnDiv() {
            $("#hdnDivision").fadeIn("slow");
            document.getElementById('hdnDivision').style.visibility = 'visible';
        } 
        function ClosehdnDivision() {
           
           $("#hdnDivision").fadeOut("slow"); 
        }
    </script>
    <style type="text/css"> 
        .rounds {
            height: 50px;
            width: 50px;
           -moz-border-colors:25px;
           border-radius:25px;
    }  
    .HyperLinkButtonStyle { float:left; text-align:left; border: none; background: none; 
    color: blue; text-decoration: underline; font: normal 10px verdana;} 
    .hdnDivision { background-color: #EFEFEF; position:absolute;z-index:1; visibility:hidden; border:10px double black; text-align:center;
    width:10%; height: 10%; margin-left:auto; margin-right:auto; padding: 20px; overflow-y:scroll; }
    </style> 
    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
            background: white;
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
    <td><asp:HiddenField ID="hdn1" runat="server" /><asp:HiddenField ID="hdn2" runat="server" /><asp:HiddenField ID="hdn3" runat="server" />
    <asp:HiddenField ID="hdn4" runat="server" /><asp:HiddenField ID="hdn5" runat="server" /><asp:HiddenField ID="hdn6" runat="server" />
    <asp:HiddenField ID="hdn7" runat="server" /><asp:HiddenField ID="hdn8" runat="server" /><asp:HiddenField ID="hdn9" runat="server" />
    <asp:HiddenField ID="hdn10" runat="server" /><asp:HiddenField ID="hdnOpID" runat="server" /><asp:HiddenField ID="hdnOpName" runat="server" />
    
            <div class="tabs_container" align="left" >Process Workstation Create Form </div>
            <div class="leaveApplication_container">
            <table style="width:700px; outline-color:blue;table-layout:auto;vertical-align: top"  >
            <tr>
            <td style="text-align:left;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="WH Name : "></asp:Label>  
            <asp:DropDownList ID="ddlWH" runat="server" AutoPostBack="True" CssClass="ddList" Font-Bold="False" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"> </asp:DropDownList>   
            </td>
            </tr>
            <tr>
            <td><asp:LinkButton ID="LinkButton1" runat="server" Font-Size="Small" OnCommand="LinkButton1_Click" Text="0"></asp:LinkButton>
            <asp:LinkButton ID="LinkButton2" runat="server" Font-Size="Small" OnCommand="LinkButton2_Click" Text=""></asp:LinkButton>
            <asp:LinkButton ID="LinkButton3" runat="server" Font-Size="Small" OnCommand="LinkButton3_Click" Text=""></asp:LinkButton>
            <asp:LinkButton ID="LinkButton4" runat="server" Font-Size="Small" OnCommand="LinkButton4_Click" Text=""></asp:LinkButton>
            <asp:LinkButton ID="LinkButton5" runat="server" Font-Size="Small"  OnCommand="LinkButton5_Click" Text=""></asp:LinkButton>
            <asp:LinkButton ID="LinkButton6" runat="server" Font-Size="Small" OnCommand="LinkButton6_Click" Text=""></asp:LinkButton>
            <asp:LinkButton ID="LinkButton7" runat="server" Font-Size="Small" OnCommand="LinkButton7_Click" Text=""></asp:LinkButton>
            <asp:LinkButton ID="LinkButton8" runat="server" Font-Size="Small" OnCommand="LinkButton8_Click" Text=""></asp:LinkButton>
            <asp:LinkButton ID="LinkButton9" runat="server" Font-Size="Small" OnCommand="LinkButton9_Click" Text=""></asp:LinkButton>
            <asp:LinkButton ID="LinkButton10" runat="server" Font-Size="Small" OnCommand="LinkButton10_Click" ></asp:LinkButton> 
            <asp:Button ID="BtnAddParent"  Font-Bold="true" Font-Size="Small" b AutoPostback="true"  runat="server" Text="Add" OnClick="BtnAddParent_Click" ToolTip="Add WH Location" /> </td>                  
            </tr> 
            </table>
            <table>
            <tr class="tblrowodd">
            <td > Workstation-:</td> 
            <td ><asp:ListBox ID="ListBox1" runat="server" Width="500px" Height="200px" AutoPostBack="True" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"></asp:ListBox></td>                    
            </tr>
            </table> 
            </div> 
            <div id="hdnDivision" class="hdnDivision" style="width:auto;">
            <table style="width:auto; float:left; " > 
            <tr><td></td></tr> 
            <tr class="tblrowodd">
                 
            <td style="text-align:right;"><asp:Label ID="lbldoc" CssClass="lbl" runat="server" Text="Name : "></asp:Label></td> 
            <td style="text-align:left;"> <asp:TextBox ID="Txtname" Width="200" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="tblrowodd"> 
                <td></td>
            <td style="text-align:right;"> <asp:Button ID="btnSaves" runat="server" BackColor="GreenYellow"  OnClick="BtnSaves_Click" Text="Save" />
            <asp:Button ID="btnCancel" runat="server"  OnClick="BtnCancel_Click" BackColor="GreenYellow" Text="Cancel" /></td> 
            </tr>
            <tr>
            <td></td>
            </tr>
            </table>
            </div>
          
         
            
<%--=========================================End My Code From Here=================================================--%>
      
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

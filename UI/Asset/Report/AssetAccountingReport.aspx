<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetAccountingReport.aspx.cs" Inherits="UI.Asset.Report.AssetAccountingReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>  
    

    <script>
        function loadIframe(iframeName, url) {
            var $iframe = $('#' + iframeName);
            if ($iframe.length) {
                $iframe.attr('src', url); 
                return false;
            }
            return true;
        }
    </script>

    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .Textbox {}
        </style>

   

    <style type="text/css">
    .Initial
{
  display: block;
  padding: 4px 18px 4px 18px;
  float: left;
  background: url("../Images/InitialImage.png") no-repeat right top;
  color: Black;
  font-weight: bold;
}
     .Initial:hover
     {
  color: White;
  background:#eeeeee;
   }
     .Clicked
     {
  float: left;
  display: block;
  background:padding-box;
  padding: 4px 18px 4px 18px;
  color: Black;
  font-weight: bold;
  color:Green;
}
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
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1s" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
     <div class="leaveApplication_container">   
        
    <td>
          <asp:Button Text="Depreciation" BorderStyle="Solid" ID="Tab1" CssClass="Initial" runat="server"
              OnClick="Tab1_Click" BackColor="#FFCC99" />
          <asp:Button Text="Disposal/Retirement" BorderStyle="Solid" ID="Tab2" CssClass="Initial" runat="server"
                 BackColor="#FFCC99" OnClick="Tab2_Click"/>
          <asp:Button Text="Revaluation" BorderStyle="Solid" ID="Tab3" CssClass="Initial" runat="server"
            OnClick="Tab3_Click"  BackColor="#FFCC99" />
         <asp:Button Text="Transection" BorderStyle="Solid" ID="Tab4" CssClass="Initial" runat="server"
            OnClick="Tab4_Click"  BackColor="#FFCC99" />
         <asp:Button Text="Schedule" BorderStyle="Solid" ID="Tab5" CssClass="Initial" runat="server"
            OnClick="Tab5_Click"  BackColor="#FFCC99" />
          <asp:MultiView ID="MainView"   runat="server">
            <asp:View ID="View1"  runat="server">
            <table style="width: 1200px; border-width: 1px; border-color: #666; border-style: solid">
            <iframe runat="server" oncontextmenu="return false;" id="frmDepreciation" name="frame" style="width:100%;height:500px;   border:0px solid red;"></iframe>
            </table>
            </span> 

            <%--//Vehicle Registration TAB--%>
               
                
            </asp:View>
            <asp:View ID="View2" runat="server">
            <table style="width:1200px;">
                
            <%--//**********************************************Vehicle Registration TAB***********************************************************--%>
            <iframe runat="server" oncontextmenu="return false;" id="FrmDisposal" name="frame" style="width:100%; font-size:small;  height:500px;  border:0px solid red;"></iframe>
                
            </table>
                   
            </asp:View>
              
            <asp:View ID="View3" runat="server">
            <table style="width: 1200px; border-width: 1px; border-color: #666; border-style: solid">
            <tr>
            <td>
            <h3>
            <span>
                     
            <%--//**********************************************Land Registration TAB***********************************************************--%>  

            <table> 
            <iframe runat="server" oncontextmenu="return false;" id="FrmRevaluation" name="frame" style="width:100%; height:500px; border:0px solid red;"></iframe>
            </table> 
            </span>
                     
            </td>
            </tr>
            </table>
            </asp:View>

            <asp:View ID="View4" runat="server">
            <table style="width:1200px; border-width: 1px; border-color: #666; border-style: solid">
            <tr>
            <td>
            <h3>
            <span>      
          
        
            <%--//**********************************************Building Registration TAB***********************************************************--%>
          
            <iframe runat="server" oncontextmenu="return false;" id="FrmTransection" name="frame" style="width:100%; height:500px; border:0px solid red;"></iframe>

            <table> 
        
            </table>
            </span>
            </h3>
            </td>
            </tr>
            </table>
            </asp:View>

            <asp:View ID="View5"  runat="server">
              <table style="width: 1050px; border-width: 1px; border-color: #666; border-style: solid">
               <iframe runat="server" oncontextmenu="return false;" id="FrmSchedule" name="frame" style="width:100%;height:500px;   border:0px solid red;"></iframe>
              </table>
                </span> 
               </asp:View>
          </asp:MultiView>
     
          </formview> 
              
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

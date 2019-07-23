<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Template.aspx.cs" Inherits="UI.Vehicle_Registration_Renewal.Template" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
     <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference4" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />

    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>

  
    


    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>

    <script> function CloseWindow() { window.close(); window.onbeforeunload = RefreshParent(); }
        function RefreshParent() {
            if (window.opener != null && !window.opener.closed) {
                window.opener.location.reload();
            }
        }

    </script> 
    
    <style type="text/css">
        #divFile p { 
            font:15px tahoma, arial; 
        }
        #divFile h3 { 
            font:16px arial, tahoma; 
            font-weight:bold;
        }
        .auto-style1 {
            height: 25px;
        }
    </style>

    

          
</head>
<body>
    <form id="frmselfresign" runat="server">
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <%--<asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>--%>
<%--=========================================Start My Code From Here===============================================--%>
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />        
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnDieselTotalTk" runat="server" /><asp:HiddenField ID="hdnCNGTotalTk" runat="server" />
    <asp:HiddenField ID="hdnMillage" runat="server" /><asp:HiddenField ID="hdnHightMilage" runat="server" />
      
        
        <div class="tabs_container">Tax Token Renewal<hr /></div>
        <asp:Panel ID="pnlTextBoxes" runat="server">

</asp:Panel>
        <table  class="tbldecoration" style="width:auto; float:left;">
        <tr>
           
            <td style="text-align:right;">
                <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Late Fine:"></asp:Label>
            </td>
            <td style="text-align:left;">
                <asp:TextBox ID="TxtLateFine" runat="server" BorderColor="green" CssClass="txtBox" Width="190px"></asp:TextBox>
            </td>
            <td style="text-align:right;">
                <asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Exp.Date:"></asp:Label>
            </td>
            <td style="text-align:left;">
                <asp:TextBox ID="TxtDteExpDate" runat="server" BorderColor="green" CssClass="txtBox" Width="190px" autocomplete="off"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDteExpDate">
                </cc1:CalendarExtender>
            </td>
            <tr>
                <td class="auto-style1" style="text-align:right;">
                    <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Renewal Date:"></asp:Label>
                </td>
                <td class="auto-style1" style="text-align:left;">
                    <asp:TextBox ID="TxtDteRenewal" runat="server" BorderColor="green" CssClass="txtBox" Width="190px" autocomplete="off"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDteRenewal">
                    </cc1:CalendarExtender>
                    <td class="auto-style1" style="text-align:right;">
                        <asp:Label ID="Label6" runat="server" CssClass="lbl" Text="Next ExpDate :"></asp:Label>
                    </td>
                    <td class="auto-style1" style="text-align:left;">
                        <asp:TextBox ID="TxtNextExpDte" runat="server" BorderColor="green" CssClass="txtBox" Width="190px" autocomplete="off"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtNextExpDte">
                        </cc1:CalendarExtender>
                    </td>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;"></td>
                <td></td>
                <td></td>
                <td>
                    <asp:Button ID="BtnCreateBox" runat="server"  Text="Save" OnClick="BtnCreateBox_Click" />
                    <asp:Button ID="BtnLabel" runat="server" Text="Create Label" OnClick="BtnLabel_Click" />
                </td>
            </tr>
          


       
                                  
       
       </table>
        </div>



<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

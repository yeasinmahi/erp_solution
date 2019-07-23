<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmTransfer.aspx.cs" Inherits="UI.Wastage.frmTransfer" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Transfer </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../Content/JS/datepickr.min.js"></script>
    <script src="../Content/JS/JSSettlement.js"></script>   
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script language="javascript" type="text/javascript">        
        function onlyNumbers(evt) {
            var e = event || evt;
            var charCode = e.which || e.keyCode;

            if ((charCode > 57))
                return false;
            return true;
        }  
    </script>
    <script>
       function Add() {
           var a, b, c;
            var a = document.forms["frmTransfer"]["txtQty"].value;           
            if (isNaN(a) == true) { a = 0; }
              var b = document.forms["frmTransfer"]["txtRate"].value;
            if (isNaN(b) == true) { b = 0; }            
            document.forms["frmTransfer"]["txtValue"].value = (a*b).toFixed(0);
        }
  </script>          
</head>
<body>
    <form id="frmTransfer" runat="server">        
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
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hdnLoanID" runat="server" /> <asp:HiddenField ID="hdnOpening" runat="server" />     
    <div class="divbody" style="padding-right:10px;">
    <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> TRANSFER<hr /></div>
    <table class="tbldecoration" style="width:auto; float:left;">
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblunit" runat="server" CssClass="lbl" Text="Transfer Date"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
            <td style="text-align:left;"><asp:TextBox ID="txtSODate" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" autocomplete="off"></asp:TextBox>
            <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtSODate"></cc1:CalendarExtender></td>
            <td style="text-align:right; width:15px;"><asp:Label ID="Label13" runat="server" Text=""></asp:Label></td>
            <td style="text-align:right;"><asp:Label ID="lblDept" runat="server" CssClass="lbl" Text="Department"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
            <td style="text-align:left;"><asp:DropDownList ID="ddlDpt" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList> </td>
         </tr>
         <tr>               
            <td style="text-align:right;"><asp:Label ID="lblWH" runat="server" CssClass="lbl" Text="WH Name"></asp:Label>]<span style="color:red; font-size:14px;">*</span><span> :</span></td>                
            <td><asp:DropDownList ID="ddlWHName" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList></td>
            <td style="text-align:right; width:15px;"><asp:Label ID="Label3" runat="server" Text=""></asp:Label></td> 
            <td style="text-align:right;">Transfer WH</td>
            <td style="text-align:left;"><asp:DropDownList ID="ddltowh" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList></td>
          </tr>
         <tr><td colspan="5"><hr /></td></tr> 
         <tr>
            <td style="text-align:right;"><asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Item Name"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
            <td style="text-align:left;">
            <asp:DropDownList ID="ddlItem" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="True" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged"></asp:DropDownList></td>
            <td style="text-align:right; width:15px;"><asp:Label ID="Label5" runat="server" Text=""></asp:Label></td>
            <td style="text-align:right;"><asp:Label ID="Label7" runat="server" Text="Quantity" CssClass="lbl" ></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
            <td><asp:TextBox ID="txtQty" runat="server" CssClass="txtBox1" AutoPostBack="true"  onKeyUp="javascript:Add();" ></asp:TextBox></td>                 
         </tr>
         <tr>
            <td style="text-align:right;"><asp:Label ID="Label6" runat="server" Text="UOM :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtUOM" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td> 
            <td style="text-align:right; width:15px;"><asp:Label ID="Label11" runat="server" Text=""></asp:Label></td>
            <td style="text-align:right;"><asp:Label ID="Label12" runat="server" Text="Rate" CssClass="lbl"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
            <td><asp:TextBox ID="txtRate" runat="server" CssClass="txtBox1" Enabled="false" onkeypress="return onlyNumbers();"></asp:TextBox></td>                
         </tr>
         <tr>
            <td style="text-align:right;"><asp:Label ID="Label15" runat="server" Text="Remarks :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtRemarks" runat="server" CssClass="txtBox1" TextMode="MultiLine" Height="30px"></asp:TextBox></td>
            <td style="text-align:right; width:15px;"><asp:Label ID="Label16" runat="server" Text=""></asp:Label></td>
            <td style="text-align:right;"><asp:Label ID="Label14" runat="server" Text="Value :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtValue" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td> 
          </tr>
          <tr><td>Requisition No</td>
             <td><asp:TextBox ID="txtRequNo" runat="server" CssClass="txtBox1"  BackColor="WhiteSmoke"></asp:TextBox></td>
             <td colspan="3" style="text-align:right; padding: 0px 0px 0px 0px">&nbsp&nbsp <asp:Button ID="btnSubmit" runat="server" class="myButtonGrey" Text="Submnit" OnClick="btnSubmit_Click" /> </td>        
          </tr>
    </table>
    </div>
    <table>
        <tr><td><hr /></td></tr>
        <tr><td>   
            &nbsp;</td></tr>  
        <tr><td><hr /></td></tr> 
        <tr>
            <td style="text-align:right; padding: 0px 0px 0px 0px"></td>        
        </tr>
    </table>   

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
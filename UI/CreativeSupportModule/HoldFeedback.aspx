<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HoldFeedback.aspx.cs" Inherits="UI.CreativeSupportModule.HoldFeedback" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. CUSTOMERS VIEW </title>
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

    <style type="text/css"> 
    .rounds { height: 500px; width: 60px; -moz-border-colors:25px; border-radius:25px;} 
    .hdnDivision { background-color: #ffffff; position:absolute;z-index:1; visibility:hidden; border:10px double black; text-align:center;
    width:50%; height: 100%; margin-left:5px; margin-top: 120px; margin-right:50px; padding: 15px; }    
    </style>
    
</head>
<body>
    <form id="frmBillRegistration" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    
    <%--=========================================Start My Code From Here===============================================--%>
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hdnLoanID" runat="server" />            
    <div style="padding-right:10px;">
        <%--<div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> BILL REGISTRATION<hr /></div>--%>
        <table class="tbldecoration" style="width:auto; float:left;">
            <tr><td colspan="5"><img src="img/Banner.png" width="950px"; height="120px" /></td></tr> 
         </table>
    </div>
    
    <div class="divbody" style="margin-left:110px; margin-top:20px; padding-left:15px;">
        <table class="tbldecoration" style="width:auto; float:left; ">
            <tr>
                <td style="text-align:right; padding-top:10px"><asp:Label ID="lblJobDesc" runat="server" CssClass="lbl" Text="Status"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="text-align:left; padding-top:10px">
                <asp:DropDownList ID="ddlStatus" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList></td>
                <td style="text-align:right; "><asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label8" runat="server" Text="Job Code" CssClass="lbl" ></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td><asp:TextBox ID="txtJobCode" runat="server" CssClass="txtBox1"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label1" runat="server" Text="Sender" CssClass="lbl" ></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td><asp:TextBox ID="TextBox2" runat="server" CssClass="txtBox1"></asp:TextBox></td>
                <td style="text-align:right; "><asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label4" runat="server" Text="Receiver" CssClass="lbl" ></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td><asp:TextBox ID="TextBox1" runat="server" CssClass="txtBox1"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label5" runat="server" Text="Job Description" CssClass="lbl" ></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td><asp:TextBox ID="TextBox3" runat="server" CssClass="txtBox1"></asp:TextBox></td>
                <td style="text-align:right; "><asp:Label ID="Label6" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label7" runat="server" Text="Attachment" CssClass="lbl" ></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>                
                <td colspan="5" style="text-align:left;"><asp:FileUpload ID="txtWorkOrderUpload" runat="server" AllowMultiple="true" Height="25px" CssClass="txtBox1"/></td>
            </tr>
            <tr>
                <td style="text-align:right; padding-top:10px"><asp:Label ID="Label9" runat="server" Text="Remarks :" CssClass="lbl"></asp:Label></td>
                <td colspan="5" style="padding-top:10px"><asp:TextBox ID="TextBox4" runat="server" CssClass="txtBox1" TextMode="MultiLine" Width="547px" Height="100px"></asp:TextBox></td>                
            </tr> 
            <tr>
                <td colspan="6" style="text-align:right; padding: 15px 26px 8px 10px">
                <span ><asp:Button ID="Button1" runat="server" class="myButton" Text="Close" Height="30px"/></span>
                <span style="padding-left:50px"><asp:Button ID="Button2" runat="server" class="myButton" Text="Clear" Height="30px"/></span>
                <span style="padding-left:50px"><asp:Button ID="Button3" runat="server" class="myButton" Text="Send" Height="30px"/></span></td>
            </tr>
            
        </table>
    </div>

    <div id="Footer" class="footer">
        <img height="40px" width="100%" src="img/20171103%20_%20CREATIVE%20SUPPORT%20UI%20DASHBOARD%20_%20FOOTER.png" /> 
    </div>
   

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
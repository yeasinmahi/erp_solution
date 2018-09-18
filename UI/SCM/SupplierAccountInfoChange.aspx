<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierAccountInfoChange.aspx.cs" Inherits="UI.SCM.SupplierAccountInfoChange" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head runat="server">
     <title>::. Supplier Account Info Change </title>
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
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                        <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div>
                </asp:Panel>
                <div style="height: 100px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>

                <%--=========================================Start My Code From Here===============================================--%>
                 <div class="divbody" style="padding-right:10px;">
        <div id="divLevel1" class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> <asp:Label ID="lblHeading" runat="server" CssClass="lbl" Text="Supplier Account Info Change" Font-Bold="true" Font-Size="16px"></asp:Label><hr /></div>
        <table class="tbldecoration" style="width:auto; float:left;">
            <tr>
                <td style="text-align:Left; width:300px;"><asp:Label ID="lblUnit" runat="server" Text="Requester Name "></asp:Label><span style="color:red; font-size:14px; text-align:left">*</span></td>
                <td style="text-align:right; "><asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>  
                <td style="text-align:Left; width:300px;"><asp:Label ID="Label1" runat="server" Text="Requester Designation "></asp:Label><span style="color:red; font-size:14px; text-align:left">*</span></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="TextBox1" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="300px"></asp:TextBox></td>
                <td style="text-align:right; "><asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                <td><asp:TextBox ID="TextBox2" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="300px"></asp:TextBox></td>
            </tr>
             <tr>
                <td style="text-align:Left; width:300px;"><asp:Label ID="Label4" runat="server" Text="Supplier Name "></asp:Label></td>
                <td style="text-align:right; "><asp:Label ID="Label5" runat="server" Text=""></asp:Label></td>  
                <td style="text-align:Left; width:300px;"><asp:Label ID="Label6" runat="server" Text="Supplier Address "></asp:Label></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="TextBox3" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="300px"></asp:TextBox></td>
                <td style="text-align:right; "><asp:Label ID="Label7" runat="server" Text=""></asp:Label></td>
                <td><asp:TextBox ID="TextBox4" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="300px"></asp:TextBox></td>
            </tr>
             <tr>
                <td style="text-align:Left; width:300px;"><asp:Label ID="Label8" runat="server" Text="New Account Number (13 Digit MICR) "></asp:Label><span style="color:red; font-size:14px; text-align:left">*</span></td>
                <td style="text-align:right; "><asp:Label ID="Label9" runat="server" Text=""></asp:Label></td>  
                <td style="text-align:Left; width:300px;"><asp:Label ID="Label10" runat="server" Text="New Routing Number (9 Digit)/Branch Name "></asp:Label><span style="color:red; font-size:14px; text-align:left">*</span></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="TextBox5" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="300px"></asp:TextBox></td>
                <td style="text-align:right; "><asp:Label ID="Label11" runat="server" Text=""></asp:Label></td>
                <td><asp:TextBox ID="TextBox6" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="300px"></asp:TextBox></td>
            </tr>
             <tr>
                <td style="text-align:Left; width:300px;"><asp:Label ID="Label12" runat="server" Text="Requester Signature "></asp:Label><span style="color:red; font-size:14px; text-align:left">*</span></td>
                <td style="text-align:right; "><asp:Label ID="Label13" runat="server" Text=""></asp:Label></td>  
                <td style="text-align:Left; width:300px;"><asp:Label ID="Label14" runat="server" Text="Supervisor Signature "></asp:Label><span style="color:red; font-size:14px; text-align:left">*</span></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="TextBox7" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="300px"></asp:TextBox></td>
                <td style="text-align:right; "><asp:Label ID="Label15" runat="server" Text=""></asp:Label></td>
                <td><asp:TextBox ID="TextBox8" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                
                <td style="text-align:right; padding: 5px 0px 5px 0px" colspan="3">
                    <asp:Button ID="Button1" runat="server" class="myButton" Text="Show" Height="30px"/>
                    <asp:Button ID="Button2" runat="server" class="myButton" Text="Print" Height="30px"/>
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

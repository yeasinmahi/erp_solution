<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemCreateAndPointSet.aspx.cs" Inherits="UI.CreativeSupportModule.ItemCreateAndPointSet" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. HOLD & FEEDBACK </title>
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
    <form id="frmBillRegistration" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    
    <%--=========================================Start My Code From Here===============================================--%>
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hdnJobID" runat="server" /><asp:HiddenField ID="hdnJobStatusID" runat="server" />            
    <div style="padding-right:10px;">
        <%--<div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> BILL REGISTRATION<hr /></div>--%>
        <table class="tbldecoration" style="width:auto; float:left;">
            <tr><td colspan="2"><img src="img/Banner.png" width="100%"; height="120px" /></td></tr>            
                       
         </table>
     </div>     
            
    <div class="divbody" style="margin-left:50px; margin-top:20px; padding-left:15px;">
        
        <table class="tbldecoration" style="width:auto; float:left; ">
            <div style="text-align:center; padding-bottom:20px; padding-top:20px;">
                    <caption>
                        <span style="font-size: 20px; text-align: center; font-weight: bold;">Item Create &amp; Update With Point Set </span>
                    </caption>
            </div>
            <tr><td colspan="6" style="font-weight:bold; font-size:11px; ">Item Create :<hr /></td></tr>
            <tr>
                <td style="text-align:right; "><asp:Label ID="lblJobDesc" runat="server" CssClass="lbl" Text="Item"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td><asp:TextBox ID="txtItem" runat="server" CssClass="txtBox1" Width="300px" ></asp:TextBox></td>
                <td style="text-align:right; "><asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label8" runat="server" Text="Point" CssClass="lbl" ></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="padding-right:10px"><asp:TextBox ID="txtPoint" runat="server" CssClass="txtBox1" Width="200px"></asp:TextBox></td>
                <td><asp:Button ID="btnSubmit" runat="server" class="myButton" Text="Create" Height="30px" OnClientClick="ConfirmAll()" OnClick="btnSubmit_Click"/></td>
            </tr>
            <tr><td colspan="6" style="font-weight:bold; font-size:11px; padding-top:20px;">Point Set :<hr /></td></tr>
            <tr>
                <td style="text-align:right; width:100px; "><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Item Name"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td ><asp:DropDownList ID="ddlItem" CssClass="ddList" Font-Bold="False" runat="server" width="300px" height="23px"></asp:DropDownList></td> 
                <td style="text-align:right;"><asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;" ><asp:Label ID="Label4" runat="server" Text="Point" CssClass="lbl" ></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="padding-right:10px;"><asp:TextBox ID="txtPointUpdate" runat="server" CssClass="txtBox1" Width="200px"></asp:TextBox></td>
                <td><asp:Button ID="btnPointUpdate" runat="server" class="myButton" Text="Update" Height="30px" OnClientClick="ConfirmAll()" OnClick="btnPointUpdate_Click"/></td>
            </tr>
            <tr><td colspan="6" style="font-weight:bold; font-size:11px; padding-top:20px;">Item Name Update :<hr /></td></tr>
            <tr>
                <td style="text-align:right; width:120px; padding-bottom:25px"><asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Old Item Name"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="padding-bottom:25px; "><asp:DropDownList ID="ddlItemForUpdate" CssClass="ddList" Font-Bold="False" runat="server" width="300px" height="23px"></asp:DropDownList></td> 
                <td style="text-align:right; padding-bottom:25px"><asp:Label ID="Label6" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right; padding-bottom:25px"><asp:Label ID="Label7" runat="server" Text="New Item Name" CssClass="lbl" ></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="padding-right:10px; padding-bottom:25px"><asp:TextBox ID="txtNewItemName" runat="server" CssClass="txtBox1" Width="200px"></asp:TextBox></td>
                <td style="padding-bottom:25px"><asp:Button ID="btnItemNameUpdate" runat="server" class="myButton" Text="Update" Height="30px" OnClientClick="ConfirmAll()" OnClick="btnItemNameUpdate_Click" /></td>
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

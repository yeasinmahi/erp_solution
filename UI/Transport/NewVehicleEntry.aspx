<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewVehicleEntry.aspx.cs" Inherits="UI.Transport.NewVehicleEntry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head runat="server"><title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" /> 
     <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>   
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../../Content/JS/CustomizeScript.js"></script>
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/Gridstyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/Application.css" rel="stylesheet" />
    <script>
        function ValidationBasicInfoRegion() {
            document.getElementById("hdnconfirm").value = "0";
            var txtRegion = document.forms["frmPurchase"]["txtRegion"].value;
            if (txtRegion == null || txtRegion == "") {
                document.getElementById("hdnconfirm").value = "0";
                alert("Please Entry Region Name !");
            }
            else {  document.getElementById("hdnconfirm").value = "1"; }
        }
        function ValidationBasicInfoArea() {
            document.getElementById("hdnconfirm").value = "0";
            var txtArea = document.forms["frmPurchase"]["txtArea"].value;
            if (txtArea == null || txtArea == "") {
                document.getElementById("hdnconfirm").value = "0";
                alert("Please Entry Region Name !");
            }
            else {  document.getElementById("hdnconfirm").value = "1"; }
        }
        function ValidationBasicInfoTerritory() {
            document.getElementById("hdnconfirm").value = "0";
            var txtTerritory = document.forms["frmPurchase"]["txtTerritory"].value;
            if (txtTerritory == null || txtTerritory == "") {
                document.getElementById("hdnconfirm").value = "0";
                alert("Please Entry Territory Name !");
            }
            else {  document.getElementById("hdnconfirm").value = "1"; }
        }
         function ValidationBasicInfoSave() {
            document.getElementById("hdnconfirm").value = "0";
             var txtEmail = document.forms["frmPurchase"]["txtEmail"].value;
             var txtContact = document.forms["frmPurchase"]["txtContact"].value;
            if (txtEmail == null || txtEmail == "") {
                document.getElementById("hdnconfirm").value = "0";
                alert("Please Entry Email Address !");
            }
             else if (txtContact == null || txtContact == "") {
                document.getElementById("hdnconfirm").value = "0";
                alert("Please Entry Contact No !");
            }
            else {  document.getElementById("hdnconfirm").value = "1"; }
        }

    </script>
  
    <style type="text/css">
        .auto-style1 {
            height: 21px;
        }
    </style>
  
    </head>
<body>
    <form id="frmPurchase" runat="server">
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hdndtechallandate" runat="server" /><asp:HiddenField ID="hdnid" runat="server" />
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnperVat" runat="server" /><asp:HiddenField ID="hdnconfirm" runat="server" />
    <asp:HiddenField ID="hdnVatAccount" runat="server" /><asp:HiddenField ID="hdnVatRegNo" runat="server" />
    <asp:HiddenField ID="hdnAccno" runat="server" /><asp:HiddenField ID="hdnuom" runat="server" /> <asp:HiddenField ID="hdnysnFactory" runat="server" />
    <asp:HiddenField ID="hdnEnroll" runat="server" /> <asp:HiddenField ID="hdnitemid" runat="server" /> <asp:HiddenField ID="hdnCustAddress" runat="server" />
   
    <table>
     <tr><td style="text-align:center; padding: 0px 0px 5px 0px;">&nbsp;</td></tr>
     <tr><td style="text-align:center; padding: 0px 0px 20px 0px;"><asp:Label ID="lblHeading" runat="server" Text="New Vehicle Setup" CssClass="lbl" Font-Size="16px"></asp:Label>                                                                                       
    <hr /> </td></tr><tr><td>
     <table  class="tbldecoration" style="width:auto; float:left;">  
     <tr>
        <td>Unit</td><td>:</td>
        <td> <asp:DropDownList ID="ddlunit" CssClass="ddllist" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="ddlunit_SelectedIndexChanged" ></asp:DropDownList></td>
        <td>Vehicle Type</td>
        <td>:</td>
        <td><asp:DropDownList ID="ddlType" CssClass="ddllist" runat="server"  ></asp:DropDownList></td>
        <td>Location</td>
        <td>:</td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="ddllist">
            </asp:DropDownList>
         </td>
     </tr>
     <tr><td>Vehicle No</td><td class="auto-style1">:</td>
        <td >
            <asp:TextBox ID="txtVehicleNo" runat="server" AutoPostBack="true" CssClass="txtBox" MaxLength="50"></asp:TextBox>
         </td>
        <td >Driver Name</td>
         <td >:</td>
        <td ><asp:TextBox ID="txtDriverName" CssClass="txtBox"   MaxLength="10" runat="server" AutoPostBack="true" ></asp:TextBox></td>
        <td >Driver Contact</td>  
         <td>:</td>
        <td ><asp:TextBox ID="txtDriverContact" CssClass="txtBox"   MaxLength="10" runat="server" AutoPostBack="true" ></asp:TextBox></td>
     </tr> 
     <tr><td>Driver NID</td><td class="auto-style1">:</td>
         <td><asp:TextBox ID="txtDriveNId" runat="server" AutoPostBack="true" CssClass="txtBox" MaxLength="50"></asp:TextBox></td>
        
        <td>Helper Name</td>
         <td>:</td>
        <td><asp:TextBox ID="txthelperName" runat="server" AutoPostBack="true" CssClass="txtBox" MaxLength="50"></asp:TextBox></td>
        <td>Lisence No</td>
         <td>:</td>
        <td><asp:TextBox ID="txtLisence" CssClass="txtBox"   MaxLength="10" runat="server" AutoPostBack="true" ></asp:TextBox></td>
     </tr>
     <tr><td> Driver DA</td><td>:</td>
        <td><asp:TextBox ID="txtDriverDA" runat="server" AutoPostBack="true" CssClass="txtBox" MaxLength="50"></asp:TextBox></td>
        <td>   Helper DA</td>
         <td>:</td>
        <td><asp:TextBox ID="txtHelperdA" runat="server" AutoPostBack="true" CssClass="txtBox" MaxLength="50"></asp:TextBox></td>
        <td>Down Trip Allowance</td> 
         <td>:</td>
        <td><asp:TextBox ID="txtDowntripAllowance" runat="server" AutoPostBack="true" CssClass="txtBox" MaxLength="50"></asp:TextBox></td>
    </tr>
     <tr><td> Down Trip DA</td><td>:</td>
        <td><asp:TextBox ID="txtDownTripDA" runat="server" AutoPostBack="true" CssClass="txtBox" MaxLength="50"></asp:TextBox></td>
        <td>   Millage Allowance 100KM</td>
         <td>:</td>
        <td><asp:TextBox ID="MA100KM" runat="server" AutoPostBack="true" CssClass="txtBox" MaxLength="50"></asp:TextBox></td>
        <td>Millage Allowance 100KM Above</td> 
         <td>:</td>
        <td><asp:TextBox ID="txtMillageAllowance100KMAbove" runat="server" AutoPostBack="true" CssClass="txtBox" MaxLength="50"></asp:TextBox></td>
    </tr>
     <tr><td> Millage Local</td><td>:</td>
        <td><asp:TextBox ID="txtMillageLocal" runat="server" AutoPostBack="true" CssClass="txtBox" MaxLength="50"></asp:TextBox></td>
        <td>   Millage Outstation</td>
         <td>:</td>
        <td><asp:TextBox ID="txtOutstation" runat="server" AutoPostBack="true" CssClass="txtBox" MaxLength="50"></asp:TextBox></td>
        <td>Millage Allowance 100KM Above</td> 
         <td>:</td>
        <td><asp:TextBox ID="TextBox3" runat="server" AutoPostBack="true" CssClass="txtBox" MaxLength="50"></asp:TextBox></td>
    </tr>
         <tr><td> Disel Per KM Outstation</td><td>:</td>
        <td><asp:TextBox ID="txtDieselPerKMOutsation" runat="server" AutoPostBack="true" CssClass="txtBox" MaxLength="50"></asp:TextBox></td>
        <td> Disel Per KM Local</td>
         <td>:</td>
        <td><asp:TextBox ID="txtDiselPerKMLocal" runat="server" AutoPostBack="true" CssClass="txtBox" MaxLength="50"></asp:TextBox></td>
        <td>UOM</td> 
         <td>:</td>
        <td><asp:DropDownList ID="ddlUOM" runat="server" CssClass="ddllist">
            <asp:ListItem Value="1049">Ton</asp:ListItem>
            <asp:ListItem Value="1050">KG</asp:ListItem>
            <asp:ListItem Value="1055">SFT</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
     <tr><td colspan="10"><hr /></td></tr> 
     <tr>
        <td>Email Address:</td><td>:</td>
        <td><asp:TextBox ID="txtEmail" CssClass="txtBox"   MaxLength="10" runat="server" AutoPostBack="true" ></asp:TextBox></td>
        <td>Contact No:</td>
         <td>:</td>
        <td><asp:TextBox ID="txtContact" CssClass="txtBox"   MaxLength="10" runat="server"></asp:TextBox></td>
        <td>&nbsp;</td>  
         <td>:</td>
        <td></td>
    </tr>
   
    <tr><td>&nbsp;</td>
        <td></td><asp:Button ID="btnSave" runat="server" OnClientClick="ValidationBasicInfoSave()" class="myButton" OnClick="btnSave_Click" Text="Save" />
    </tr>
    </table>
    </td></tr>
    <tr><td>
    
    </td></tr></table>
    </div>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>


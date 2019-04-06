<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeoMarketSetup.aspx.cs" Inherits="UI.SAD.Setup.GeoMarketSetup" %>
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
     <tr><td style="text-align:center; padding: 0px 0px 20px 0px;"><asp:Label ID="lblHeading" runat="server" Text="Market Setup" CssClass="lbl" Font-Size="16px"></asp:Label>                                                                                       
    <hr /> </td></tr><tr><td>
     <table  class="tbldecoration" style="width:auto; float:left;">  
         <tr><td colspan="5">
             <asp:RadioButton ID="rtnmarket" GroupName="group" Text="Market Setup" AutoPostBack="true" runat="server" OnCheckedChanged="rtnmarket_CheckedChanged" /><asp:RadioButton GroupName="group" ID="rtnemployee" Text="Employee Setup" runat="server" AutoPostBack="true" OnCheckedChanged="rtnemployee_CheckedChanged" />
             </td></tr>
     <tr>
        <td>Unit:</td>
        <td> <asp:DropDownList ID="ddlunit" CssClass="ddllist" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="ddlunit_SelectedIndexChanged" ></asp:DropDownList></td>
        <td>Lavel Type</td>
        <td><asp:DropDownList ID="ddlType" CssClass="ddllist" runat="server"  AutoPostBack="True" >
        <asp:ListItem Value="1">Region</asp:ListItem>
        <asp:ListItem Value="2">Area</asp:ListItem>
        <asp:ListItem Value="3">Territory</asp:ListItem>
        </asp:DropDownList></td>
     </tr>
     <tr><td>Region Name</td>
        <td><asp:DropDownList ID="ddlRegion" CssClass="ddllist" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged" ></asp:DropDownList> </td>
        <td>New Region</td>
        <td><asp:TextBox ID="txtRegion" CssClass="txtBox"   MaxLength="10" runat="server" AutoPostBack="true" ></asp:TextBox></td>
        <td><asp:Button ID="btnAddRegion" runat="server" OnClientClick="ValidationBasicInfoRegion()" class="myButton" OnClick="btnAddRegion_Click" Text="Add" /> </td>        
     </tr> 
     <tr><td>Area Name</td>
        <td><asp:DropDownList ID="ddlArea" CssClass="ddllist" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged" ></asp:DropDownList></td>
        <td>New Area</td>
        <td><asp:TextBox ID="txtArea" CssClass="txtBox"   MaxLength="10" runat="server" AutoPostBack="true" ></asp:TextBox></td>
        <td><asp:Button ID="btnAddArea" runat="server" OnClientClick="ValidationBasicInfoArea()" class="myButton" OnClick="btnAddArea_Click" Text="Add" /></td>
     </tr>
     <tr><td> Territory</td>
        <td><asp:DropDownList ID="ddlTerritory" CssClass="ddllist" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="ddlTerritory_SelectedIndexChanged" ></asp:DropDownList> </td>
        <td>   New Territory</td>
        <td><asp:TextBox ID="txtTerritory" CssClass="txtBox"   MaxLength="10" runat="server" AutoPostBack="true"></asp:TextBox></td>
        <td><asp:Button ID="btnAddTerritory" runat="server" OnClientClick="ValidationBasicInfoTerritory()" class="myButton" OnClick="btnAddTerritory_Click" Text="Add" /></td>          
    </tr>
     <tr><td colspan="5"><hr /></td></tr> 
     <tr>
        <td>Email Address:</td>
        <td><asp:TextBox ID="txtEmail" CssClass="txtBox"    runat="server" AutoPostBack="true" ></asp:TextBox></td>
        <td>Contact No:</td>
        <td><asp:TextBox ID="txtContact" CssClass="txtBox"   MaxLength="11" runat="server"></asp:TextBox></td>
        <td>&nbsp;</td>         
    </tr>
   
    <tr><td>&nbsp;</td>
        <td><asp:Button ID="btnSave" runat="server" OnClientClick="ValidationBasicInfoSave()" class="myButton" OnClick="btnSave_Click" Text="Save" />
            <asp:Button ID="btnupdate" runat="server"  class="myButton" OnClick="btnupdate_Click" Text="Update" />
            <asp:Button ID="btnshow" runat="server"  class="myButton" OnClick="btnshow_Click" Text="Show" />
        </td>
    </tr>
    </table>
    </td></tr>
    <tr><td colspan="5">
         <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                SkinID="sknGrid1" CaptionAlign="Top" Caption="Market Setup Info" 
                                
                               >
                                <Columns>
                                    
                                    <asp:BoundField DataField="strText" HeaderText="Location" SortExpression="strNarration" />
                                    <asp:BoundField DataField="strEmailAddress" HeaderText="Email" SortExpression="strBankName" />
                                     <asp:BoundField DataField="strContactNo" HeaderText="Contact No" SortExpression="strBankName" />
                                  
                                </Columns>
                            </asp:GridView>
    </td></tr></table>
    </div>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>


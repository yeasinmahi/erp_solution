<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryFGReceive.aspx.cs" Inherits="UI.SCM.Transfer.InventoryFGReceive" %>

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
    <script src="../../Content/JS/datepickr.min.js"></script> 
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" /> 
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" /> 
    <script src="jquery.min.js"></script> 
    <script src="jquery-ui.min.js"></script> 
    <link href="../Content/CSS/GridView.css" rel="stylesheet" />
    <%--<link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />--%> 
  
    
   
    <script type="text/javascript"> 
         
        function Confirms() {
          
            var e = document.getElementById("ddlProductId");
            var recProductID = e.options[e.selectedIndex].value;
            var e = document.getElementById("ddlLcation");
            var locationId = e.options[e.selectedIndex].value; 

            var e = document.getElementById("ddlProduct");
            var priduct = e.options[e.selectedIndex].value; 
            var quantity = document.getElementById("txtReceQty").value;
             var inQty = parseFloat(document.getElementById("hdnInQty").value);
      
            if ($.trim(recProductID) == 0 || $.trim(recProductID) == "" || $.trim(recProductID) == null || $.trim(recProductID) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please select Receive Product Id'); }
            else if ($.trim(priduct) == 0 || $.trim(priduct) == "" || $.trim(priduct) == null || $.trim(priduct) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please select Product'); }
            else if ($.trim(locationId) == 0 || $.trim(locationId) == "" || $.trim(locationId) == null || $.trim(locationId) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please select Location'); }
           else if ($.trim(quantity) == 0 || $.trim(quantity) == "" || $.trim(quantity) == null || $.trim(quantity) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please input Quantity'); }
            else if ( parseFloat(inQty)<parseFloat(quantity)){ document.getElementById("hdnPreConfirm").value = "0"; alert('input Quantity greater then Transfer In Quantity'); }
                else {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnPreConfirm").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnPreConfirm").value = "0"; } 

               // document.getElementById("hdnPreConfirm").value = "1";
            }
             
           
        }
    </script> 
</head>
<body>
<form id="frmTransferOrder" runat="server">
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnAutoId" runat="server" />
        <asp:HiddenField ID="hdnPreConfirm" runat="server" /><asp:HiddenField ID="hdnTransfromValue" runat="server" /><asp:HiddenField ID="hdnInQty" runat="server" />
       <div class="tabs_container">INVENTORY TRANSFER <hr /></div>
        
        <table    style="width:750px; text-align:center ">   
            <tr>
             <td></td><td></td>  <td></td><td></td> 
            <td style="text-align:right;">WH Name:</td>
            <td style="text-align:left;"> <asp:DropDownList ID="ddlWh"  CssClass="ddList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlWh_SelectedIndexChanged"></asp:DropDownList>  </td> 
        </tr>
            <tr>
                <td></td>
            </tr>
         </table>
        <table style="border-radius:10px; width:700px; border-style:groove">
            <caption style="text-align:left">FG Receive</caption>
        <tr>
            <td style='text-align: left;'>Product ID</td>
            <td style='text-align: left;'><asp:DropDownList ID="ddlProductId" CssClass="ddList"   runat="server"  AutoPostBack="True" OnSelectedIndexChanged="ddlProductId_SelectedIndexChanged"   ></asp:DropDownList></td>  
            <td style='text-align: left; width:120px'>Product Name</td>
            <td style='text-align: left;'><asp:DropDownList ID="ddlProduct" CssClass="ddList"   runat="server"  AutoPostBack="True" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged"   ></asp:DropDownList></td>  
          
        </tr>
       <tr>
             
           <td style='text-align: left;'>Location</td>
            <td style='text-align: left;'><asp:DropDownList ID="ddlLcation" runat="server" CssClass="ddList"  AutoPostBack="True" ></asp:DropDownList></td>  
           <td ><asp:Label ID="Label1" Text="Receive Qty"  runat="server"></asp:Label></td>
           <td  ><asp:TextBox ID="txtReceQty" CssClass="txtBox" Width="130px"  TextMode="Number" runat="server"></asp:TextBox>  
            <asp:Label ID="lblUom" runat="server" ForeColor="Blue"></asp:Label>
           </td>
                
         </tr>
            <tr>
                <td style="text-align:right" colspan="4">
                <asp:Label ID="lblDate" runat="server" ForeColor="Blue" ></asp:Label>
                <asp:Button  ID="btnReceive" runat="server" Text="Receive" OnClientClick="Confirms();" OnClick="btnReceive_Click"/></td>
            </tr>
            <tr>
                <td colspan="4"><asp:Label ID="lblDetalis"  ForeColor="Blue" runat="server" ></asp:Label></td>
            </tr>
            </table>
          <table style="width:700px; border-color:slateblue;border-style:double; border-radius:5px;">
            <tr>
                <td ><asp:Label ID="lblProduct" Text="ProductID" runat="server"></asp:Label></td>
                <td><asp:TextBox ID="txtProductId" CssClass="txtBox"   runat="server"></asp:TextBox></td>
               <td c> <asp:Button ID="btnActive" runat="server"  ForeColor="Green"   Text="Active" OnClick="btnActive_Click"/> <asp:Button ID="btnInActive" ForeColor="Red" runat="server"   Text="In Active" OnClick="btnInActive_Click"   /></td>
            </tr>

          
        </table>
        </div>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
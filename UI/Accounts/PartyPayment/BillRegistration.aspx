<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillRegistration.aspx.cs" Inherits="UI.Accounts.PartyPayment.BillRegistration" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.:: Authorized Party Cheque ::.</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>  
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script src="../../Content/JS/CustomizeScript.js"></script>
    <script>
        function Confirm() {
            document.getElementById("hdnconfirm").value = "0";
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
            else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
            document.forms[0].appendChild(confirm_value);
        }
   </script>

    <script>
       function Print() {
    $('#div1st').hide();
    var dv = document.getElementById("hdnDivision");
    document.getElementById('hdnDivision').style.display = "block";
        dv.getElementsByID
        dv.style.display = "block";
        dv = document.getElementById("btnprint");
        dv.style.display = "none";
        window.print();
        self.close();
        $('#showdiv').show();
    }         
    </script>
    <script>
        function ViewQRCode(reqsid) {
        window.open('QRCodePrint.aspx?intID=' + reqsid, 'sub', "height=500, width=850, scrollbars=yes, left=50, top=45, resizable=no, title=Preview");
    }

</script>

 
    <%--<style type="text/css"> 
    .rounds { height: 200px; width: 150px; -moz-border-colors:25px; border-radius:25px;} 
    .hdnDivision { background-color: #FFFFFF; position:absolute;z-index:1; visibility:hidden; border:10px double black; text-align:center;
    width:650%; height: 18%; margin-left:50px; margin-top: 00px; margin-right:00px; padding: 15px; overflow-y:scroll;}    
    </style>--%>
    
</head>
<body>
    <form id="frmauthorizedpartycheque" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate> <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
    
    <div id="div1st" class="leaveApplication_container">
    <div  class="tabs_container"><asp:HiddenField ID="hdnconfirm" runat="server"/></div>
        <table class="tbldecoration" style="width:auto; float:left;">
        <tr class="tblheader"><td colspan="4" style=" text-align:center; font-size:18px"> Bill Registration </td></tr>
           
        <tr class="tblrowodd">
            <td style="text-align:right;"><asp:Label ID="lblRefference" runat="server" CssClass="lbl" Text="Refference :"></asp:Label></td>            
            <td><asp:DropDownList ID="ddlRefference" runat="server" CssClass="ddList" Font-Bold="false" AutoPostBack="false" Width="205px">
                <asp:ListItem Selected="True" Value="1">PO</asp:ListItem><asp:ListItem Value="2">Others</asp:ListItem></asp:DropDownList>
            </td>                
            <td style="text-align:right;"><asp:Label ID="lblReffNo" runat="server" CssClass="lbl" Text="Reff. No. :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtReffNo" Width="200" runat="server" CssClass="txtBox"></asp:TextBox></td>
        </tr>
        <tr class="tblrowodd">
            <td colspan="4"><asp:Button ID="btnGo" runat="server" CssClass="nextclick" Text="   Go   "/></td>      
        </tr>
        <tr><td colspan="4"><hr /></td></tr> 
        <tr class="tblrowodd">
            <td style="text-align:right;"><asp:Label ID="lblBillingUnit" runat="server" CssClass="lbl" Text="Billing Unit:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlBillingUnit" CssClass="ddList" Font-Bold="False" runat="server" Width="205px"></asp:DropDownList>                                                                                       
            </td>

            <td style="text-align:right;"><asp:Label ID="lblPartyType" runat="server" CssClass="lbl" Text="Party Type :"></asp:Label></td>            
            <td><asp:DropDownList ID="ddlPartyType" runat="server" CssClass="ddList" Font-Bold="false" AutoPostBack="false" Width="205px">
                <asp:ListItem Selected="True" Value="1">Supplier</asp:ListItem><asp:ListItem Value="2">Employee</asp:ListItem>
                <asp:ListItem Value="3">Customer</asp:ListItem><asp:ListItem Value="4">Other</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr class="tblrowodd">
            <td style="text-align:right;"><asp:Label ID="lblPartyName" runat="server" CssClass="lbl" Text="Party Name :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtPartyName" Width="200" TextMode="MultiLine" runat="server" CssClass="txtBox"></asp:TextBox></td>
            <td></td>
            <td><asp:CheckBox ID="cbAdjustment" runat="server" CssClass="lbl" Text="Adjustment" AutoPostBack="false" /></td>
        </tr>
        <tr class="tblrowodd">
            <td style="text-align:right;"><asp:Label ID="lblBillNo" runat="server" CssClass="lbl" Text="Bill No. :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtBillNo" Width="200" runat="server" CssClass="txtBox"></asp:TextBox></td>

            <td style="text-align:right;"><asp:Label ID="lblBillDate" runat="server" CssClass="lbl" Text="Bill Date :"></asp:Label></td>                
            <td><asp:TextBox ID="txtBillDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="200px" autocomplete="off"></asp:TextBox>
            <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtBillDate"></cc1:CalendarExtender></td>                                
        </tr>
        <tr class="tblrowodd">            
            <td style="text-align:right;"><asp:Label ID="lblAdjustAmount" runat="server" CssClass="lbl" Text="Adjust Amount :"></asp:Label></td>
            <td><asp:TextBox ID="txtAdjustAmount" runat="server" CssClass="txtBox" Width="200"></asp:TextBox></td>            

            <td style="text-align:right;"><asp:Label ID="lblAmount" runat="server" CssClass="lbl" Text="Amount :"></asp:Label></td>
            <td><asp:TextBox ID="txtAmount" runat="server" CssClass="txtBox" Width="200"></asp:TextBox></td>            
         </tr>
        <tr class="tblrowodd">
            <td style="text-align:right;"><asp:Label ID="lblRemarks" runat="server" CssClass="lbl" Text="Remarks :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtRemarks" Width="200" TextMode="MultiLine" runat="server" CssClass="txtBox"></asp:TextBox></td>
            
            <td colspan="2"><asp:Button ID="btnSave" runat="server" CssClass="nextclick" Text="Save" OnClick="btnSave_Click"/></td>
            <td style="width:5px;"><a id="btnprint" href="#" style="cursor:pointer" onclick="Print()">Print</a></td>
        </tr>
    </table>
    </div>

    
        
    
    


<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

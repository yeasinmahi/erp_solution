<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Milk_Supplier_Registration.aspx.cs" Inherits="UI.Dairy.Milk_Supplier_Registration" %>
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
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/Lstyle.css" rel="stylesheet" />
   

    <script language="javascript" type="text/javascript">
        function onlyNumbers(evt) {
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;

            if ((charCode > 57))
                return false;
            return true;
        }        
</script>
                  
</head>
<body>
    <form id="frmselfresign" runat="server">        
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" />
    <asp:HiddenField ID="hdnconfirm" runat="server" /> <asp:HiddenField ID="hdnJobStation" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" /> <asp:HiddenField ID="hdnFTP" runat="server" />
    <asp:HiddenField ID="hdnCmComm" runat="server" />
          
        <div class="tabs_container"> SUPPLIER REGISTRATION FROM <hr /></div>

        <table class="tbldecoration" style="width:auto; float:left;">        
        
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Unit:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlUnit" BorderColor="DimGray"  CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td>
            
            <td style="text-align:right;"><asp:Label ID="lblSuppCode" runat="server" CssClass="lbl" Text="Supplier Code:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtSuppCode" runat="server"  BorderColor="DimGray"  CssClass="txtBox" Width="210px"></asp:TextBox></td>                                                   
        </tr>  
        <tr>  
            <td style="text-align:right;"><asp:Label ID="lblChillingCenter" runat="server" CssClass="lbl" Text="Chilling Center :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlChillingCenter" BorderColor="DimGray"  CssClass="ddList" Font-Bold="False" runat="server"></asp:DropDownList>                                                                                       
            </td>
            
            <td style="text-align:right;"><asp:Label ID="lblSuppName" runat="server" CssClass="lbl" Text="Supplier Name:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtSuppName" runat="server"  BorderColor="DimGray"  CssClass="txtBox" Width="210px"></asp:TextBox></td>                                                   
        </tr>  
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblBank" runat="server" CssClass="lbl" Text="Bank Name:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlBank" BorderColor="DimGray"  CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td> 
            
            <td style="text-align:right;"><asp:Label ID="lblAddress" runat="server" CssClass="lbl" Text="Supplier Address:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtAddress" runat="server"  BorderColor="DimGray"  CssClass="txtBox" Width="210px"></asp:TextBox></td>                                                   
        </tr> 
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblDistrict" runat="server" CssClass="lbl" Text="District Name:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlDistrict" BorderColor="DimGray"  CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td>
                        
            <td style="text-align:right;"><asp:Label ID="lblMobileNo" runat="server" CssClass="lbl" Text="Mobile No.:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtMobileNo" runat="server"  BorderColor="DimGray"  onkeypress="return onlyNumbers();" CssClass="txtBox" Width="210px"></asp:TextBox></td>                                                               
        </tr> 
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblBrach" runat="server" CssClass="lbl" Text="Branch Name:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlBranch" BorderColor="DimGray"  CssClass="ddList" Font-Bold="False" runat="server"></asp:DropDownList>                                                                                       
            </td>
            
            <td style="text-align:right;"><asp:Label ID="lblNID" runat="server" CssClass="lbl" Text="National ID:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtNID" runat="server"  BorderColor="DimGray" onkeypress="return onlyNumbers();" CssClass="txtBox" Width="210px"></asp:TextBox></td>                                                                           
        </tr>  
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblAccountNo" runat="server" CssClass="lbl" Text="Account No.:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtAccountNo" runat="server"  BorderColor="DimGray" onkeypress="return onlyNumbers();"  CssClass="txtBox" Width="210px"></asp:TextBox></td>                                                   

            <td colspan="2"  style="text-align:left;"><asp:Button ID="btnSubmit" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Submit"  OnClientClick="ConfirmAll()" OnClick="btnSubmit_Click"/></td>            
        </tr>


        </table>
    </div>

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

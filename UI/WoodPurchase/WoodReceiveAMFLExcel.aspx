<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WoodReceiveAMFLExcel.aspx.cs" Inherits="UI.WoodPurchase.WoodReceiveAMFLExcel" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Loan Application </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>   
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/Gridstyle.css" rel="stylesheet" />
   
</head>
<body>
    <form id="frmLoanApplication" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <%--=========================================Start My Code From Here===============================================--%>
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" /><asp:HiddenField ID="hdnPOAmount" runat="server" />
    <asp:HiddenField ID="hdnSupplierID" runat="server" /> <asp:HiddenField ID="hdnJobStaion" runat="server" />      
    <div class="divbody" style="padding-right:10px;">
        <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> Wood Receive<hr /></div>
        <table><tr><td>
        <table class="tbldecoration" style="width:auto; float:left;">
            <tr><td colspan="4" style="text-align:center"><asp:Label ID="lblWH" runat="server" CssClass="label" Text="Weare House :"></asp:Label>
            <asp:DropDownList ID="ddlWHList" runat="server" CssClass="ddList" width="220px" height="23px" BackColor="WhiteSmoke" AutoPostBack="true" OnSelectedIndexChanged="ddlWHList_SelectedIndexChanged"></asp:DropDownList></td></tr>
            <tr><td colspan="4"><hr /></td></tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label14" runat="server" Text="Supplier/PO :" CssClass="lbl"></asp:Label></td>
                <td><asp:DropDownList ID="ddlPOList" runat="server" CssClass="ddList"  width="220px" height="23px" BackColor="White" OnSelectedIndexChanged="ddlPOList_SelectedIndexChanged"></asp:DropDownList></td>
                <td style="text-align:right;"><asp:Label ID="Label10" runat="server" Text="Vehicle No :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtVehicleNo" runat="server" CssClass="txtBox1" BackColor="White"></asp:TextBox></td> 
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label3" runat="server" Text="Gate Entry No :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtGateEntry" runat="server" CssClass="txtBox1" BackColor="White"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="Label9" runat="server" Text="Mokam :" CssClass="lbl"></asp:Label></td>
                <td><asp:DropDownList ID="ddlMokam" runat="server" CssClass="ddList"  width="220px" height="23px" BackColor="White"></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label13" runat="server" Text="Type Of Wood :" CssClass="lbl"></asp:Label></td>
                <td><asp:DropDownList ID="ddlWoodType" runat="server" CssClass="ddList"  width="220px" height="23px" BackColor="White"></asp:DropDownList></td>

                <td style="text-align:right;"><asp:Label ID="lblTag" runat="server" Text="Tag No :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtTag" runat="server" CssClass="txtBox1" BackColor="White"></asp:TextBox></td>
            </tr>
            
            </table>
            </td></tr><tr><td>
            <table>
            <div>        
                Import Excel File:   
                <asp:FileUpload ID="FileUpload1" runat="server"></asp:FileUpload>
                <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload" style="height: 26px" />
                <br /> <br /> 
                 
                <asp:Label ID="Label1" runat="server"></asp:Label>   
                <br />   
                <asp:GridView ID="gvExcelFile" runat="server"  CellPadding="4" ForeColor="#333333" GridLines="None">   
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />   
                    <EditRowStyle BackColor="#999999" />   
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />   
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />   
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />   
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />   
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />   
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />   
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />   
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />   
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />   
                </asp:GridView>   
            </div>  
        </table>
        </td></tr></table>
    </div>
    
  
        
                
    <%--=========================================End My Code From Here=================================================--%>
   
    </form>
</body>
</html>
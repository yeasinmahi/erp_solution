<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="POEntry.aspx.cs" Inherits="UI.WoodPurchase.POEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
    <form id="frmLoanApplication" runat="server">        
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
    <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hdnJobStaion" runat="server" />      
    <div class="divbody" style="padding-right:10px;">
        <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> PO Entry<hr /></div>
        <table class="tbldecoration" style="width:auto; float:left;">
            <tr><td style="text-align:center"><asp:Label ID="lblWH" runat="server" CssClass="label" Text="Weare House :"></asp:Label></td>
            <td><asp:DropDownList ID="ddlWHList" runat="server" CssClass="ddList" AutoPostBack="true" width="220px" height="23px" BackColor="WhiteSmoke" OnSelectedIndexChanged="ddlWHList_SelectedIndexChanged"></asp:DropDownList></td></tr>
            
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label12" runat="server" Text="PO No. :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtPO" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" onkeypress="return onlyNumbers();"></asp:TextBox></td>
            
                <td style="text-align:right; padding: 0px 0px 0px 0px"><asp:Button ID="btnSubmit" runat="server" class="myButtonGrey" Text="Submit" Width="100px" OnClick="btnSubmit_Click"/></td>        
            </tr>            
        
        <tr><td colspan="3"><hr /></td></tr>
        <tr><td colspan="3">   
            <asp:GridView ID="dgvPOList" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
            HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
            FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />    
            <Columns>
            
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="50px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
                        
            <asp:TemplateField HeaderText="PO NO." SortExpression="intPOID">
            <ItemTemplate><asp:Label ID="lblPO" runat="server" Text='<%# Bind("intPOID") %>' Width="200px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="200px"/></asp:TemplateField>
             
            <asp:TemplateField HeaderText="Active" SortExpression="ysnActive">
            <ItemTemplate><asp:CheckBox ID="chkActive" runat="server" Checked='<%# Bind("ysnActive") %>'/></ItemTemplate><ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>

            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Update" >
            <ItemTemplate><asp:Button ID="btnUpdate" runat="server" Cssclass="myButtonGrey" style="cursor:pointer; font-size:11px;" 
            CommandArgument='<%# Eval("intPOID")+","+ Container.DataItemIndex %>' Text="Update" OnClick="btnUpdate_Click"/>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="120px" /></asp:TemplateField>
                       
            </Columns>
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
        </td></tr>  
    </table>       
    </div>
  
        
                
    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
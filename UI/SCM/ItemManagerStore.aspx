<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemManagerStore.aspx.cs" Inherits="UI.SCM.ItemManagerNew" %>

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
          function ViewPopup(Id) {
            window.open('LoanScheduleDetailsN.aspx?ID=' + Id, 'sub', "height=500, width=650, scrollbars=yes, left=100, top=25, resizable=no, title=Preview");
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
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hdnWHID" runat="server" /> <asp:HiddenField ID="hdnGroupID" runat="server" /><asp:HiddenField ID="hdnCategoryID" runat="server" />      
    <div class="divbody" style="padding-right:10px;">
        <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> ITEM ADD FORM <font color="red">[LEVEL-1] [STORE PART]</font><hr /></div>
        <table class="tbldecoration" style="width:auto; float:left;">
            <tr>
                <td colspan="4" style="text-align:center;"><asp:Label ID="Label14" runat="server" Text="WH Name " CssClass="lbl"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span><%--</td>--%>
                <%--<td style="text-align:left;">--%><asp:DropDownList ID="ddlWH" runat="server" CssClass="ddList" Font-Bold="false" Width="220px" Height="24px" BackColor="WhiteSmoke" AutoPostBack="true" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="lblBaseName" runat="server" Text="Product Base Name " CssClass="lbl"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td><asp:TextBox ID="txtBaseName" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="lblDescription" runat="server" Text="Description :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtDescription" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label2" runat="server" Text="Part :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtPart" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="Label18" runat="server" Text="Model :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtModel" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label19" runat="server" Text="Serial :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtSerial" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="Label4" runat="server" Text="Brand :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtBrand" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label20" runat="server" Text="Specification :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtSpecification" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="Label21" runat="server" Text="Origin :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtOrigin" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label22" runat="server" Text="HS Code :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtHSCode" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="Label11" runat="server" Text="Re-Order Level :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtReOrder" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" onkeypress="return onlyNumbers();"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label12" runat="server" Text="Minimum Stock Level :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtMinimum" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" onkeypress="return onlyNumbers();"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="Label13" runat="server" Text="Maximum Order Level :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtMaximum" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" onkeypress="return onlyNumbers();"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label15" runat="server" Text="Safety Stock Level :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtSafety" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" onkeypress="return onlyNumbers();"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="Label23" runat="server" Text="Self Time :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtSelfTime" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" onkeypress="return onlyNumbers();"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label5" runat="server" Text="UOM " CssClass="lbl"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td><asp:DropDownList ID="ddlUOM" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="24px" BackColor="WhiteSmoke"></asp:DropDownList></td>
                <td style="text-align:right;"><asp:Label ID="Label17" runat="server" Text="Location " CssClass="lbl"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td><asp:DropDownList ID="ddlLocation" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="24px" BackColor="WhiteSmoke"></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label1" runat="server" Text="Group " CssClass="lbl"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td><asp:DropDownList ID="ddlGroup" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="24px" BackColor="WhiteSmoke" AutoPostBack="true" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged"></asp:DropDownList></td>
                <td style="text-align:right;"><asp:Label ID="Label3" runat="server" Text="Category " CssClass="lbl"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td><asp:DropDownList ID="ddlCategory" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="24px" BackColor="WhiteSmoke" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label6" runat="server" Text="Sub-Category " CssClass="lbl"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td><asp:DropDownList ID="ddlSubCategory" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="24px" BackColor="WhiteSmoke"></asp:DropDownList></td>
                <td style="text-align:right;"><asp:Label ID="Label7" runat="server" Text="Minor Category :" CssClass="lbl"></asp:Label></td>
                <td><asp:DropDownList ID="ddlMinorCategory" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="24px" BackColor="WhiteSmoke"></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label8" runat="server" Text="Plant :" CssClass="lbl"></asp:Label></td>
                <td><asp:DropDownList ID="ddlPlant" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="24px" BackColor="WhiteSmoke"></asp:DropDownList></td>
                <td style="text-align:right;"><asp:Label ID="Label9" runat="server" Text="ABC Classification " CssClass="lbl"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td><asp:DropDownList ID="ddlABC" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="24px" BackColor="WhiteSmoke"><asp:ListItem Selected="True" Value="1">A</asp:ListItem><asp:ListItem Value="2">B</asp:ListItem>
                <asp:ListItem Value="3">C</asp:ListItem></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label10" runat="server" Text="FSN Classification " CssClass="lbl"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td><asp:DropDownList ID="ddlFSN" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="24px" BackColor="WhiteSmoke"><asp:ListItem Selected="True" Value="1">Fast</asp:ListItem><asp:ListItem Value="2">Slow</asp:ListItem>
                <asp:ListItem Value="3">Non-Moving</asp:ListItem></asp:DropDownList></td>
                <td style="text-align:right;"><asp:Label ID="Label16" runat="server" Text="VDE Classification " CssClass="lbl"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td><asp:DropDownList ID="ddlVDE" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="24px" BackColor="WhiteSmoke"><asp:ListItem Selected="True" Value="1">Vital</asp:ListItem><asp:ListItem Value="2">Essential</asp:ListItem>
                <asp:ListItem Value="3">Desireable</asp:ListItem></asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="4" style="text-align:right; padding: 0px 0px 0px 0px"><asp:Button ID="btnSubmit" runat="server" class="myButtonGrey" Text="Submit" Width="100px" OnClick="btnSubmit_Click"/></td>        
            </tr>            
        </table>
    </div>
  
                
    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
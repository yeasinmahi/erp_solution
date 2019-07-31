<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AfblEmployeeSearch.aspx.cs" Inherits="UI.SAD.Customer.AfblEmployeeSearch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>AFBL Employee Search</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
        <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
    </asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../Content/CSS/AutoComplete.css" rel="stylesheet" />
    <script src="../Content/JS/datepickr.min.js"></script>
    <script src="../Content/JS/JSSettlement.js"></script>
    <link href="../Content/CSS/jquery-ui.css" rel="stylesheet" />
    <link href="../Content/CSS/Application.css" rel="stylesheet" />
    <script src="../Content/JS/jquery-3.3.1.js"></script>
    <script src="../Content/JS/jquery-ui.min.js"></script>
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />
</head>
<body>
   <form id="frmEmployeeSearch" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                        <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div>
                </asp:Panel>
                <div style="height: 100px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <asp:HiddenField ID="hdnLevelId" runat="server" />
                <div class="divbody" style="padding-right: 10px;">
                    <div class="tabs_container" style="background-color: #dcdbdb; padding-top: 10px; padding-left: 5px; padding-right: -50px; border-radius: 5px;">
                        AFBL Employee Search<hr />
                    </div>
                    <table style="width: auto; float: left;">
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblEnroll" runat="server"  Text="Enroll :"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlEnroll" CssClass="ddList" runat="server" Width="220px" Height="23px"
                                   AutoPostBack="true" OnSelectedIndexChanged="ddlEnroll_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label6" runat="server"  Text=""></asp:Label></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label8" runat="server" BackColor="WhiteSmoke"  Text="Resign Date"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                               <asp:TextBox ID="txtResignDte" CssClass="txtBox1" Width="220px" Height="23px" ReadOnly="true" runat="server"></asp:TextBox>
                            </td>
                        </tr>                    
                        <tr>
                             <td style="text-align: right;">
                                <asp:Label ID="lblEmpName" runat="server" Text="Employee Name"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtEmpName" CssClass="txtBox1" BackColor="WhiteSmoke" Width="220px" Height="23px" ReadOnly="true" runat="server"></asp:TextBox>
                            </td>
                              <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
                             <td style="text-align: right;">
                                <asp:Label ID="lblDesignation" runat="server"   Text="Designation"></asp:Label>
                            </td>
                             <td style="text-align: left;">
                                 <asp:TextBox ID="txtDesignation" CssClass="txtBox1" BackColor="WhiteSmoke" ReadOnly="true" Width="220px" Height="23px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                             <td style="text-align: right;">
                                <asp:Label ID="lblLine" runat="server"  Text="Line"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtLine" CssClass="txtBox1" BackColor="WhiteSmoke" Width="220px" Height="23px" ReadOnly="true" runat="server"></asp:TextBox>
                            </td>
                              <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
                             <td style="text-align: right;">
                                <asp:Label ID="lblRegion" runat="server"  Text="Region"></asp:Label>
                            </td>
                             <td style="text-align: left;">
                                 <asp:TextBox ID="txtRegion" BackColor="WhiteSmoke" CssClass="txtBox1" Width="220px" Height="23px" ReadOnly="true" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                           <tr>
                             <td style="text-align: right;">
                                <asp:Label ID="Label2" runat="server"  Text="Area"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtArea" CssClass="txtBox1" BackColor="WhiteSmoke" Width="220px" Height="23px" ReadOnly="true" runat="server"></asp:TextBox>
                            </td>
                              <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label4" runat="server" Text=""></asp:Label></td>
                             <td style="text-align: right;">
                                <asp:Label ID="Label5" runat="server"  Text="Territory"></asp:Label>
                            </td>
                             <td style="text-align: left;">
                                 <asp:TextBox ID="txtTerrotory" BackColor="WhiteSmoke" CssClass="txtBox1" Width="220px" Height="23px" ReadOnly="true" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                          
                           <tr>
                             <td style="text-align: right;">
                                <asp:Label ID="Label7" runat="server"  Text="Point"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtPoint" BackColor="WhiteSmoke" CssClass="txtBox1" Width="220px" Height="23px" ReadOnly="true" runat="server"></asp:TextBox>
                            </td>
                              <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label9" runat="server" Text=""></asp:Label></td>
                             <td style="text-align: right;">
                                <asp:Label ID="Label10" runat="server"  Text=""></asp:Label>
                            </td>
                             <td style="text-align: left;">
                                  <asp:Label ID="Label11" runat="server"  Text=""></asp:Label>
                            </td>
                        </tr>
                          <tr>
                            <td>
                                <asp:Label ID="Label12" runat="server" CssClass="lbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label13" runat="server" CssClass="lbl" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label14" runat="server" CssClass="lbl" Text=""></asp:Label>
                            </td>
                            <td colspan="3">
                                <asp:Button ID="btnClear" runat="server" Style="float: right" class="myButton" Text="Clear" Width="100px" OnClick="btnClear_Click" />
                                <asp:Button ID="btnResign" runat="server" Style="float: right" class="myButton" Text="Update Resign" Width="100px" OnClick="btnResign_Click" />
                            </td>
                        </tr>
                    </table>
                </div>             

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

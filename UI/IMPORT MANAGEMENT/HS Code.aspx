<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HS Code.aspx.cs" Inherits="UI.IMPORT_MANAGEMENT.HS_Code" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head runat="server">
     <title>::. HS Code </title>
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
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                        <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div>
                </asp:Panel>
                <div style="height: 100px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>

                <%--=========================================Start My Code From Here===============================================--%>
                 <div class="divbody" style="padding-right:10px;">
                 <div id="divLevel1" class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> <asp:Label ID="lblHeading" runat="server" CssClass="lbl" Text="Input HS CODE" Font-Bold="true" Font-Size="16px"></asp:Label><hr /></div>
                    <table>
                        <tr>
                            <th>HS CODE</th>
                            <th>Description</th>
                            <th>CD</th>
                            <th>RD</th>
                            <th>SD</th>
                            <th>VAT</th>
                            <th>AIT</th>
                            <th>ATV</th>
                            <th>PSI</th>
                            <th>UNIT</th>
                            <th>TTI</th>
                            <th>EXD</th>
                        </tr>
                        <tr>
                            <td><asp:TextBox ID="txtHsCode" runat="server" CssClass="txtBox" Width="100px"></asp:TextBox></td>
                            <td><asp:TextBox ID="txtDescription" runat="server" CssClass="txtBox"></asp:TextBox></td>
                            <td><asp:TextBox ID="txtCD" runat="server" CssClass="txtBox" Width="80px"></asp:TextBox></td>
                            <td><asp:TextBox ID="txtRD" runat="server" CssClass="txtBox" Width="80px"></asp:TextBox></td>
                            <td><asp:TextBox ID="txtSD" runat="server" CssClass="txtBox" Width="80px"></asp:TextBox></td>
                            <td><asp:TextBox ID="txtVAT" runat="server" CssClass="txtBox" Width="80px"></asp:TextBox></td>
                            <td><asp:TextBox ID="txtAIT" runat="server" CssClass="txtBox" Width="80px"></asp:TextBox></td>
                            <td><asp:TextBox ID="txtATV" runat="server" CssClass="txtBox" Width="80px"></asp:TextBox></td>
                            <td><asp:TextBox ID="txtPSI" runat="server" CssClass="txtBox" Width="80px"></asp:TextBox></td>
                            <td><asp:TextBox ID="txtUnit" runat="server" CssClass="txtBox" Width="80px"></asp:TextBox></td>
                            <td><asp:TextBox ID="txtTTI" runat="server" CssClass="txtBox" Width="80px"></asp:TextBox></td>
                            <td><asp:TextBox ID="txtEXD" runat="server" CssClass="txtBox" Width="80px"></asp:TextBox></td>
                            <td style="text-align:right; padding: 5px 0px 5px 0px"><asp:Button ID="btnSubmit" runat="server" class="myButton" Text="Submit" Height="28px" OnClick="btnSubmit_Click"/></td>
                        </tr>
                    </table>
                </div>
                 <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

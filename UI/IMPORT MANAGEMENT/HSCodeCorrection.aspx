<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HSCodeCorrection.aspx.cs" Inherits="UI.IMPORT_MANAGEMENT.HSCodeCorrection" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>::. HS Code </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />  
    <link href="../Content/CSS/bootstrap.min.css" rel="stylesheet" />
    <script src="../Content/JS/jquery-3.3.1.js"></script>
    <style>
        .lbl{text-align:right;}
        .mrg-left{margin-left:7px}
        .ddl{width:250px}
        .td-lbl-width{width:11%;text-align:right}
        .td-txt-width{width:20%}
        .td-button{width:34%;margin-left:1%}
        .mrg-btn{margin-left:2%}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="pnl_hscode">
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


                <div class="container" style="margin-top: 1%;">
                    <div class="panel panel-group">
                        <div class="panel panel-primary">
                            <div class="panel panel-body">
                                <table>
                                    <tr>
                                        <td class="td-lbl-width"><asp:Label ID="Label2" runat="server" Text="Unit :"></asp:Label></td>
                                        <td class="td-txt-width"><asp:DropDownList ID="ddlUnit" CssClass="form-control mrg-left ddl" runat="server"></asp:DropDownList></td>

                                        <td class="td-lbl-width"><asp:Label ID="Label1" runat="server" Text="Item ID :"></asp:Label></td>
                                        <td class="td-txt-width"><asp:TextBox ID="txtItemId" CssClass="form-control mrg-left ddl" runat="server"></asp:TextBox></td>

                                        <td class="td-button"><asp:Button runat="server" ID="btnShowItem" Text="Show" CssClass="btn btn-primary btn-sm mrg-btn" Style="float: left" OnClick="btnShowItem_Click" /></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="panel panel-primary">
                                <div class="panel panel-body">
                                    <table>
                                        <tr>
                                            <td class="td-lbl-width"><asp:Label ID="Label3" runat="server" Text="Item Name :"></asp:Label></td>
                                            <td class="td-txt-width"><asp:TextBox ID="txtItemName" CssClass="form-control mrg-btn ddl" runat="server"></asp:TextBox></td>

                                            <td class="td-lbl-width"><asp:Label ID="Label4" runat="server" Text="Description :"></asp:Label></td>
                                            <td class="td-txt-width"><asp:TextBox ID="txtItemDescription" CssClass="form-control mrg-btn ddl" runat="server" TextMode="MultiLine" Height="35px"></asp:TextBox></td>

                                            <td class="td-lbl-width"><asp:Label ID="Label5" runat="server" Text="Item UoM :"></asp:Label></td>
                                            <td class="td-txt-width"><asp:TextBox ID="txtItemUoM" CssClass="form-control mrg-btn ddl" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="td-lbl-width"><asp:Label ID="Label6" runat="server" Text="HS Code :"></asp:Label></td>
                                            <td class="td-txt-width"><asp:TextBox ID="txtHSCode" CssClass="form-control mrg-btn ddl" runat="server"></asp:TextBox></td>
                                            <td class="td-lbl-width"></td>
                                            <td class="td-txt-width">
                                                <asp:HiddenField runat="server" ID="hfHSCode" />
                                                <asp:HiddenField runat="server" ID="hfUnitId" />
                                                <asp:HiddenField runat="server" ID="hfItemId" />
                                                <asp:HiddenField runat="server" ID="hdnconfirm" />
                                            </td>
                                            <td class="td-button" colspan="2"><asp:Button runat="server" ID="btnHSCodeUpdate" Text="Update" CssClass="btn btn-success btn-sm" Style="float: right" OnClick="btnHSCodeUpdate_Click" /></td>
                                        </tr>
                                    </table>
                                    
                                </div>
                            </div>
                    </div>

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>

    <script>
       function Confirm() {
           var confirm_value = document.createElement("INPUT");
           confirm_value.type = "hidden";
           confirm_value.name = "confirm_value";
           if (confirm("Do you want to proceed?"))
           {
               confirm_value.value = "Yes";
               document.getElementById("hdnconfirm").value = "1";
           }
           else
           {
               confirm_value.value = "No";
               document.getElementById("hdnconfirm").value = "0";
           }
       }

   </script>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HSCodeCorrection.aspx.cs" Inherits="UI.IMPORT_MANAGEMENT.HSCodeCorrection" %>

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
    <link href="../Content/CSS/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="pnl_hscode">
            <ContentTemplate>
                <div class="container">
                    <div class="panel panel-group">
                        <div class="panel panel-primary">
                            <div class="panel panel-body">
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group form-group-sm">
                                            <label class="col-sm-5 control-label text-right">WH Name :</label>
                                            <div class="col-sm-7">
                                                <asp:DropDownList ID="ddlUnit" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group form-group-sm">
                                            <label class="col-sm-5 control-label text-right">Item ID :</label>
                                            <div class="col-sm-7">
                                                <asp:TextBox runat="server" ID="txtItemId" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Button runat="server" ID="btnShowItem" Text="Show" CssClass="btn btn-primary btn-sm" Style="float: left" OnClick="btnShowItem_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="panel panel-primary">
                                <div class="panel panel-body">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group form-group-sm">
                                                <label class="col-sm-5 control-label text-right">Item Name :</label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="txtItemName" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group form-group-sm">
                                                <label class="col-sm-5 control-label text-right">Description :</label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="txtItemDescription" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                          <div class="col-md-4">
                                            <div class="form-group form-group-sm">
                                                <label class="col-sm-5 control-label text-right">Item UoM :</label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="txtItemUoM" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group form-group-sm">
                                                <label class="col-sm-5 control-label text-right">HS Code :</label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="txtHSCode" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            
                                        </div>
                                          <div class="col-md-4">
                                            <asp:Button runat="server" ID="btnHSCodeUpdate" Text="Update" CssClass="btn btn-success btn-sm" Style="float: left" OnClick="btnHSCodeUpdate_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

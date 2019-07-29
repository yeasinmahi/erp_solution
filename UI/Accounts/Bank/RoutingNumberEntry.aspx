<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoutingNumberEntry.aspx.cs" Inherits="UI.Accounts.Bank.RoutingNumberEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/updatedJs") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/updatedCss" />

</head>

<body>
        <form id="form1" runat="server">

    <div class="panel panel-info" id="panel">
        <div class="col-md-12" style=" padding-top:5px";>
            <asp:Label ID="lblRouting" runat="server" Text="Routing Number" CssClass="form-control col-md-12 col-sm-12 col-xs-12" Font-Bold="true"></asp:Label>
            <asp:TextBox ID="txtRouting" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12"></asp:TextBox>
            <asp:Button ID="btnCancel" Text="Reset" runat="server" class="btn btn-primary form-control pull-right"  OnClick="btnReset_Click" />
            <asp:Button ID="txtSearch" Text="Search" runat="server" class="btn btn-primary form-control pull-right"  OnClick="btnSearch_Click" />
        </div>
    </div>
        

        <div class="panel panel-info">
            <div class="panel-heading">
                <asp:Label runat="server" Text="Bank Information Form" Font-Bold="true" Font-Size="16px"></asp:Label>

            </div>

            <div class="panel-body">
                <div class="row">

                    <div class="col-md-6 col-sm-6">
                        <asp:Label ID="lblBank" runat="server" Text="Bank"></asp:Label>
                        <asp:DropDownList ID="ddlBank" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12"></asp:DropDownList>
                    </div>

                    <div class="col-md-6 col-sm-6">
                        <asp:Label runat="server" ID="lblBankBranch" Text="Branch"></asp:Label>
                        <asp:DropDownList ID="ddlBankBranch" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12"></asp:DropDownList>

                    </div>

                    <div class="col-md-6 col-sm-6">
                        <asp:Label runat="server" ID="lblBankDistrict" Text="District"></asp:Label>
                        <asp:DropDownList ID="ddlBankDistrict" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12"></asp:DropDownList>
                    </div>

                    <div class="col-md-6 col-sm-6">
                        <asp:Label runat="server" ID="lblBankBranchCode" Text="Baranch Code"></asp:Label>
                        <asp:TextBox ID="txtBankBranchCode" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" Enabled="true"></asp:TextBox>
                    </div>

                    <div class="col-md-12 col-sm-12" style="padding-top: 10px">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary form-control pull-right" OnClick="btnSubmit_Click" />
                    </div>

                </div>
            </div>
        </div>

            
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Farmer_Setup.aspx.cs" Inherits="UI.SAD.Sales.Farmer_Setup" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, heigth=device-heigth, initial-scale=1.0, user-scalable=yes" />
    <%--<asp:PlaceHolder ID="PlaceHolder0" runat="server"><%: Scripts.Render("~/Content/Bundle/Jquery") %></asp:PlaceHolder>--%>
    <webopt:BundleReference ID="BundleReference0" runat="server" Path="~/Content/Bundle/DefaultCss" />
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/jquery-ui-1.12.1.min.js"></script>

    <style type="text/css">
        .rounds {
            height: 200px;
            width: 150px;
            -moz-border-colors: 25px;
            -ms-border-radius: 25px;
            border-radius: 25px;
        }

        .hdnDivision {
            background-color: #EFEFEF;
            position: absolute;
            z-index: 1;
            visibility: hidden;
            border: 10px double black;
            text-align: center;
            width: 500%;
            height: 18%;
            margin-left: 50px;
            margin-top: 00px;
            margin-right: 00px;
            padding: 15px;
            overflow-y: scroll;
        }

        .auto-style1 {
            height: 23px;
        }
    </style>

</head>
<%--oncontextmenu="return false;"--%>
<body>
    <form id="frmhome" runat="server">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:ScriptManager runat="server" ID="scriptManager" EnablePageMethods="true"></asp:ScriptManager>
        <div>
            <table>
                <asp:HiddenField ID="hdnCheck" runat="server" />
                <asp:HiddenField ID="hdnConfirm" runat="server" />
                
                <tr class="tblheader">
                    <td colspan="4" style="text-align: center" class="auto-style1">Setup </td>
                </tr>

                <tr class="tblroweven">
                    <td style="text-align: right;">
                        <asp:Label ID="lblline" CssClass="lbl" runat="server" Text="Unit : "></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlUnit" runat="server" CssClass="ddList" AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_OnSelectedIndexChanged"></asp:DropDownList></td>
                    <td style="text-align: right;">
                        <asp:Label ID="Label7" CssClass="lbl" runat="server" Text="Level : "></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlLevel" runat="server" CssClass="ddList"></asp:DropDownList></td>
                </tr>
                <tr class="tblrowodd">
                    <td style="text-align: right;">
                        <asp:Label ID="lblrgn" CssClass="lbl" runat="server" Text="Region : "></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlRegion" runat="server" CssClass="ddList" AutoPostBack="true" OnSelectedIndexChanged="ddlRegion_OnSelectedIndexChanged"></asp:DropDownList></td>
                    <td style="text-align: right;">
                        <asp:Label ID="Label2" CssClass="lbl" runat="server" Text="New : "></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtRegion" runat="server" CssClass="ddList"></asp:TextBox></td>
                    <td style="text-align: Left;">
                        <asp:Button ID="btnAddRegion" runat="server" OnClientClick="funConfirmAll()" Text="Add" OnClick="btnAddRegion_OnClick" /></td>
                </tr>
                <tr class="tblroweven">
                    <td style="text-align: right;" class="auto-style1">
                        <asp:Label ID="lblara" CssClass="lbl" runat="server" Text="Area : "></asp:Label></td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="ddlArea" runat="server" CssClass="ddList" AutoPostBack="true" OnSelectedIndexChanged="ddlArea_OnSelectedIndexChanged"></asp:DropDownList></td>
                    <td style="text-align: right;">
                        <asp:Label ID="Label3" CssClass="lbl" runat="server" Text="New : "></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtArea" runat="server" CssClass="ddList"></asp:TextBox></td>
                    <td style="text-align: Left;">
                        <asp:Button ID="btnAddArea" runat="server" OnClientClick="funConfirmAll()" Text="Add" OnClick="btnAddArea_OnClick" /></td>
                </tr>
                <tr class="tblrowodd">
                    <td style="text-align: right;" class="auto-style1">
                        <asp:Label ID="lbltrtry" CssClass="lbl" runat="server" Text="Territory : "></asp:Label></td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="ddlTerritory" runat="server" CssClass="ddList" AutoPostBack="true" OnSelectedIndexChanged="ddlTerritory_OnSelectedIndexChanged"></asp:DropDownList></td>
                    <td style="text-align: right;">
                        <asp:Label ID="Label4" CssClass="lbl" runat="server" Text="New : "></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtTerritory" runat="server" CssClass="ddList"></asp:TextBox></td>
                    <td style="text-align: Left;">
                        <asp:Button ID="btnTerritory" runat="server" OnClientClick="funConfirmAll()" Text="Add" OnClick="btnTerritory_OnClick" /></td>
                </tr>
                <tr class="tblroweven">
                    <td style="text-align: right;">
                        <asp:Label ID="lblcust" CssClass="lbl" runat="server" Text="Ceiling Center : "></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlCelingCenterNew" runat="server" CssClass="ddList" OnSelectedIndexChanged="ddlCelingCenterNew_OnSelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    <td style="text-align: right;">
                        <asp:Label ID="Label5" CssClass="lbl" runat="server" Text="New : "></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlCelingCenterOld" runat="server" CssClass="ddList" ></asp:DropDownList></td>
                    </td>
                    <td style="text-align: Left;">
                        <asp:Button ID="btnAddCellingCenter" runat="server" OnClientClick="funConfirmAll()" Text="Add" OnClick="btnAddCellingCenter_OnClick" /></td>
                </tr>
                <tr class="tblrowodd">
                    <td style="text-align: right;">
                        <asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Zone : "></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlZone" runat="server" CssClass="ddList"></asp:DropDownList></td>
                    <td style="text-align: right;">
                        <asp:Label ID="Label6" CssClass="lbl" runat="server" Text="New : "></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtZone" runat="server" CssClass="ddList"></asp:TextBox></td>
                    <td style="text-align: Left;">
                        <asp:Button ID="btnZone" runat="server" OnClientClick="funConfirmAll()" Text="Add" OnClick="btnZone_OnClick" /></td>
                </tr>

                <tr class="tblroweven">
                    <td style="text-align: right;">
                        <asp:Label ID="lblttloutlet" CssClass="lbl" runat="server" Text="Farmer List:" /></td>
                    <td colspan="4">
                        <asp:TextBox ID="txtFarmer" runat="server" CssClass="txtBox" Enabled="true"/></td>

                </tr>
                <tr class="tblrowodd">
                    <td style="text-align: right;" >
                        <asp:Label ID="lblnomenu" CssClass="lbl" runat="server" Text="Farmer Profile:" /></td>
                    <td colspan="4">
                        <asp:TextBox ID="txtFarmerProfile" runat="server" CssClass="txtBox" Enabled="true" /></td>

                </tr>
                <tr class="tblroweven">
                    <td style="text-align: right;">
                        <asp:Label ID="lbldate" CssClass="lbl" runat="server" Text="Employee : "></asp:Label></td>
                    <td colspan="4">
                        <asp:TextBox ID="txtEmployee" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
                    </td>

                </tr>
                <tr class="tblrowodd">
                    <td colspan="4"></td>
                    <td style="text-align: Right;">&nbsp;</td>
                    <td style="text-align: Left;">
                        <asp:Button ID="btnSave" runat="server" OnClientClick="funConfirmAll()" Text="Save" OnClick="btnSave_OnClick" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
<script>
    $(function() {
        $("#txtEmployee").autocomplete({
            source: function (request, response) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json;",
                    url: "SetupFarmer.aspx/GetAutoCompleteEmployee",
                    data: "{'prefix':'" + document.getElementById('txtEmployee').value + "'}",
                    dataType: "json",
                    success: function (data) {
                        response(data.d);
                    },
                    error: function (result) {
                        alert("Error");
                    }
                    
                });
            },
            minLength: 3
        });
        $("#txtFarmerProfile").autocomplete({
            source: function (request, response) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json;",
                    url: "SetupFarmer.aspx/GetAutoCompleteFarmerProfile",
                    data: "{'prefix':'" + document.getElementById('txtFarmerProfile').value + "'}",
                    dataType: "json",
                    success: function (data) {
                        response(data.d);
                    },
                    error: function (result) {
                        alert("Error");
                    }
                    
                });
            },
            minLength: 3
        });
        $("#txtFarmer").autocomplete({
            source: function (request, response) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json;",
                    url: "SetupFarmer.aspx/GetAutoCompleteFarmer",
                    data: "{'prefix':'" + document.getElementById('txtFarmer').value + "'}",
                    dataType: "json",
                    success: function (data) {
                        response(data.d);
                    },
                    error: function (result) {
                        alert("Error");
                    }
                    
                });
            },
            minLength: 3
        });
    });
</script>
</body>
</html>


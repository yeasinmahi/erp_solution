<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.SAD.Logistic.UpdateTrip" Codebehind="UpdateTrip.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html >

<html >
<head runat="server">
    <title></title>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />

    <link href="../../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css"/>

    <script type="text/javascript">
        function ValidateDo(sender, args) {
            if (document.getElementById("hdnVehicle").value == '') {
                alert('Please enter a vehicle');
                args.IsValid = false;
                isProceed = false;
            }
            else if (document.getElementById("hdnDo").value == '') {
                alert('Please enter a valid DO');
                args.IsValid = false;
                isProceed = false;
            }
            else if (!confirm('Do you want to continue?')) {
                args.IsValid = false;
                isProceed = false;
            }
        }

        function ValidateReg(sender, args) {
            if (document.getElementById("hdnVehicle").value == '') {
                alert('Please enter a vehicle');
                args.IsValid = false;
                isProceed = false;
            }
            else if (document.getElementById("txtReg").value == '') {
                alert('Please enter a reg. no');
                args.IsValid = false;
                isProceed = false;
            }
            else if (!confirm('Do you want to continue?')) {
                args.IsValid = false;
                isProceed = false;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlMarque" runat="server" Width="100%">
                <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                        scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </marquee>
                </div>
            </asp:Panel>
            <br />
            <table align="center" style="width: 550px; vertical-align: top;">
                <tr>
                    <td align="left">
                        Unit
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlUnit" runat="server" DataSourceID="ObjectDataSource2" DataTextField="strUnit"
                            DataValueField="intUnitID" AutoPostBack="True" OnDataBound="ddlUnit_DataBound"
                            OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetUnits"
                            TypeName="HR_BLL.Global.Unit">
                            <SelectParameters>
                                <asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                    <td align="right">
                        Ship Point
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlShip" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource4"
                            DataTextField="strName" DataValueField="intShipPointId" OnDataBound="ddlShip_DataBound"
                            OnSelectedIndexChanged="ddlShip_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="GetShipPoint"
                            TypeName="SAD_BLL.Global.ShipPoint" OldValuesParameterFormatString="original_{0}">
                            <SelectParameters>
                                <asp:SessionParameter Name="userId" SessionField="sesUserID" Type="String" />
                                <asp:ControlParameter ControlID="ddlUnit" Name="unitId" PropertyName="SelectedValue"
                                    Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        Vehicle
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnVehicle" runat="server" />
                        <asp:TextBox ID="txtVehicle" AutoPostBack="true" runat="server" Width="200px" OnTextChanged="txtVehicle_TextChanged"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtVehicle"
                            ServiceMethod="GetVehicleOutList" MinimumPrefixLength="1" CompletionSetCount="1"
                            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                        </cc1:AutoCompleteExtender>
                    </td>
                </tr>                
                <tr style="background-color: #C0C0C0;">
                    <td>
                        Change DO No:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDo" Width="200px" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnDo" runat="server" Value="" />
                        <asp:LinkButton ID="lnkChk" runat="server" OnClick="lnkChk_Click">Check</asp:LinkButton>
                        &nbsp;&nbsp;<asp:Image ID="imgChk" Visible="false" Width="16px" Height="16px" runat="server" />
                    </td>
                    <td align="right">
                        <asp:Button ID="btnDo" ValidationGroup="valDo" runat="server" Text="Set DO To Vhl" Width="150px" OnClick="btnDo_Click" />
                    </td>
                </tr>
                <tr style="background-color: #F0F0FF">
                    <td>
                        Change Reg. No
                    </td>
                    <td>
                        <asp:TextBox ID="txtReg" Width="200px" runat="server"></asp:TextBox>
                    </td>
                    <td align="right" colspan="2">
                        <asp:Button ID="btnReg" ValidationGroup="valReg" runat="server" Text="Change Reg No" Width="150px" OnClick="btnReg_Click" />
                    </td>
                </tr>
                <tr>
                <td colspan="4">
                    <asp:Label ID="lblStat" runat="server" Text="" ForeColor="Maroon"></asp:Label></td>
                </tr>
            </table>
            <asp:CustomValidator ID="cvtDo" runat="server" ClientValidationFunction="ValidateDo"
                ValidationGroup="valDo"></asp:CustomValidator>
            <asp:CustomValidator ID="cvtReg" runat="server" ClientValidationFunction="ValidateReg"
                ValidationGroup="valReg"></asp:CustomValidator>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

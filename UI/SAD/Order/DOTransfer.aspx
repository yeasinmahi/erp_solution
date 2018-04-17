<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.SAD.Order.DOTransfer" Codebehind="DOTransfer.aspx.cs" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html >
<html >
<head runat="server">
    <title></title>
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function RemoveRecon(sender, args) {
            if (document.getElementById("txtDo").value == '') {
                alert('Please enter a DO number');
                args.IsValid = false;
                isProceed = false;
            }
            else if (!confirm('Do you want to transfer this DO?')) {
                args.IsValid = false;
                isProceed = false;
            }

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <CompositeScript>
            <Scripts>
                <asp:ScriptReference name="MicrosoftAjax.js"/>
	<asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
	<asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
            </Scripts>
        </CompositeScript>
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                <asp:Panel ID="pnlMarque" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                            scrolldelay="-1" width="100%">
                            <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                        </marquee>
                    </div>
                </asp:Panel>
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 100px; float: right;">
                    <asp:HiddenField ID="hdnUnit" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnDDLChangedSelectedIndexV" Value="" runat="server" />
                    <table style="width: 850px; background-color: #E0E0E0;">
                        <tr>
                            <td style="width: 80px;">
                                Unit
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" DataSourceID="odsUnit"
                                    DataTextField="strUnit" DataValueField="intUnitID" OnDataBound="ddlUnit_DataBound">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
                                    <SelectParameters>
                                        <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                            <td align="right">
                                From
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlShip" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource4"
                                    DataTextField="strName" DataValueField="intShipPointId">
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
                            <td align="right">
                                To
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlShipOther" runat="server" AutoPostBack="True" DataSourceID="ods2"
                                    DataTextField="strName" DataValueField="intId" OnDataBound="ddlShipOther_DataBound">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ods2" runat="server" SelectMethod="GetShipPointExceptThis"
                                    TypeName="SAD_BLL.Global.ShipPoint" OldValuesParameterFormatString="original_{0}">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlUnit" Name="unitId" PropertyName="SelectedValue"
                                            Type="String" />
                                        <asp:ControlParameter ControlID="ddlShip" Name="shipPointId" PropertyName="SelectedValue"
                                            Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <div style="height: 120px;">
            </div>
            <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </cc1:AlwaysVisibleControlExtender>
            <table>
                <tr>
                    <td>
                        DO Code
                    </td>
                    <td>
                        <asp:TextBox ID="txtDo" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Transfer" ValidationGroup="val" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="right">
                        <asp:Label ID="lblStatus" ForeColor="Maroon" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:CustomValidator ID="cvt" runat="server" ClientValidationFunction="RemoveRecon"
        ValidationGroup="val"></asp:CustomValidator>
        
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.SAD.Logistic.MaintainInOut" Codebehind="MaintainInOut.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<!DOCTYPE html >
<html >
<head id="Head1" runat="server">
    <title></title>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function ShowPopUpE(url) {
            var rand_no = Math.floor(11 * Math.random());
            url = url + '&rnd=' + rand_no;
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=550,width=750,top=70,left=220');
            if (window.focus) { newwindow.focus() }
        }        
        function ValidateComplete(sender, args) {
         if (!confirm('Do you want to continue?')) {
                args.IsValid = false;
                isProceed = false;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>            
             <asp:Panel ID="pnlMarque" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;
                        z-index: 1; position: absolute;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                            scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </marquee>
                    </div>
                </asp:Panel>
            <br /><br />
            <asp:HiddenField ID="hdnVehicle" runat="server" Value="" />
            <asp:HiddenField ID="hdnIn" runat="server" Value="true" />
            <table align="center" style="width: 500px; vertical-align: top;">
                <tr>
                    <td align="left">
                        Unit
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
            </table>
            <br />
            <table align="center" style="width: 500px; vertical-align: top; background-color: #E0E0FF">
                <tr>
                    <td colspan="2" align="center">
                        <b style="color: Navy; font-size: 20px;">MAINTANANCE</b>
                    </td>
                </tr>
                <tr>
                    <td style="width: 130px;">
                        <b style="color: Maroon">Vehicle No</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtVehicleOut" AutoPostBack="true" runat="server" AutoCompleteType="Search"
                            Width="365px" OnTextChanged="txtVehicleOut_TextChanged"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtVehicleOut"
                            ServiceMethod="GetVehicleOutList" MinimumPrefixLength="1" CompletionSetCount="1"
                            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                        </cc1:AutoCompleteExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b style="color: Maroon">Trip No</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTrip" ReadOnly="true" runat="server" Width="365px" AutoPostBack="True" OnTextChanged="txtTrip_TextChanged"></asp:TextBox>                        
                    </td>
                </tr>
                <tr>
                    <td>
                        <b style="color: Maroon">Driver</b>
                    </td>
                    <td style="background-color: #FFFFFF">
                        <asp:Label ID="lblDriver" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b style="color: Maroon">Healper</b>
                    </td>
                    <td style="background-color: #FFFFFF">
                        <asp:Label ID="lblHealper" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b style="color: Maroon">Status</b>
                    </td>
                    <td style="background-color: #FFFFFF">
                        <asp:Label ID="lblError" Font-Bold="true" ForeColor="Red" runat="server" Text=""></asp:Label>                     
                    </td>
                </tr>
                <tr>
                <td><br /><asp:Image ID="imgSignal" ImageUrl="" Width="70px" Height="70px" runat="server" Visible="false" /></td>
                 <td>
                    <asp:Button ID="btnInOut" ValidationGroup="valCom" runat="server" Text="" Visible="false"
                        OnClick="btnInOut_Click" />
                </td>
                </tr>                
            </table>        
            <asp:CustomValidator ID="cvtCom" runat="server" ClientValidationFunction="ValidateComplete"
                ValidationGroup="valCom"></asp:CustomValidator>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

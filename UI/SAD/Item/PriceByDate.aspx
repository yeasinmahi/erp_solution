<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.SAD.Item.PriceByDate" Codebehind="PriceByDate.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html >
<head id="Head1" runat="server">
    <title>Untitled Page</title>

    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />

    <script type="text/javascript">        
     function DDLChange(ddlID)
     {     
        document.getElementById("hdnDDLChangedSelectedIndex").value = document.getElementById(ddlID).options.value;        
     }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                        scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </marquee>
                </div>
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">
                    <table style="width: 100%;">
                        <tr style="background-color: #E0E0FF;">
                            <td align="center">
                                <asp:HiddenField ID="hdnLevel" runat="server" Value="1" />
                                <asp:HiddenField ID="hdnSubLevel" runat="server" Value="1" />
                                <asp:HiddenField ID="hdnMode" runat="server" />
                                <asp:HiddenField ID="hdnParent" runat="server" />
                                <asp:HiddenField ID="hdnDDLChangedSelectedIndex" runat="server" />
                                Type
                                <asp:DropDownList ID="ddlType" runat="server" DataSourceID="ObjectDataSource1" DataTextField="strType"
                                    DataValueField="intID" AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetActiveItemType"
                                    TypeName="SAD_BLL.Item.Item" OldValuesParameterFormatString="original_{0}">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlUnit" Name="unitID" PropertyName="SelectedValue"
                                            Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                            <td>
                                Unit:
                                <asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" DataSourceID="odsUnit"
                                    DataTextField="strUnit" DataValueField="intUnitID" OnDataBound="ddlUnit_DataBound">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
                                    <SelectParameters>
                                        <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlMain" runat="server">
                                </asp:Panel>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <div style="height: 100px;">
            </div>
            <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </cc1:AlwaysVisibleControlExtender>
            <table width="500px;">
                <tr>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Show Item List" />
                        <asp:HiddenField ID="hdnL1" runat="server" />
                        <asp:HiddenField ID="hdnId" runat="server" />
                        <asp:HiddenField ID="hdnSub" runat="server" />
                    </td>
                    <td>
                        Date
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnFrm" runat="server" />
                        <asp:TextBox ID="txtFrom" runat="server" Enabled="false"></asp:TextBox>
                        <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFrom" Format="dd/MM/yyyy" PopupButtonID="imgCal_1"
                            ID="CalendarExtender1" runat="server" EnableViewState="true">
                        </cc1:CalendarExtender>
                        <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                            width: 34px; height: 23px; vertical-align: bottom;" />
                    </td>                                     
                </tr>
                <tr><td colspan="3" align="right">
                    <asp:Label ID="lblError" runat="server" ForeColor="#CC0000"></asp:Label>
                </td></tr>
                <tr>
                    <td colspan="7" style="padding-top: 20px;">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                            DataSourceID="ObjectDataSource2" SkinID="sknGrid1" CaptionAlign="Top" 
                            Caption="Product Price">
                            <Columns>
                                <asp:BoundField DataField="strProductName" HeaderText="Product Name" 
                                    SortExpression="strProductName" />
                                <asp:TemplateField HeaderText="Price" SortExpression="monPrice">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetFormettingNumber(Eval("monPrice")) %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>                               
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetProductListWithPriceByDate"
                            TypeName="SAD_BLL.Item.ItemPrice" 
                            OldValuesParameterFormatString="original_{0}">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="hdnL1" Name="levelOneId" PropertyName="Value" Type="String" />
                                <asp:ControlParameter ControlID="hdnId" Name="idList" PropertyName="Value" Type="String" />
                                <asp:ControlParameter ControlID="hdnSub" Name="subLevelList" PropertyName="Value"
                                    Type="String" />
                                <asp:ControlParameter ControlID="hdnFrm" Name="date" PropertyName="Value" 
                                    Type="DateTime" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
            </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>


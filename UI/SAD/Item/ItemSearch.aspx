<%@ Page Language="C#" Theme="Theme1" AutoEventWireup="true" Inherits="UI.SAD.Item.ItemSearch" Codebehind="ItemSearch.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html >
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
                        <tr style="background-color:#E0E0FF;">
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
            <table width="100%">
                <tr>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
                        <asp:HiddenField ID="hdnL1" runat="server" />
                        <asp:HiddenField ID="hdnId" runat="server" />
                        <asp:HiddenField ID="hdnSub" runat="server" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="intID"
                            DataSourceID="ObjectDataSource2" SkinID="sknGrid1" CaptionAlign="Top" Caption="Item List">
                            <Columns>
                                <%--<asp:BoundField DataField="intID" HeaderText="intID" InsertVisible="False" 
                                ReadOnly="True" SortExpression="intID" />
                            <asp:BoundField DataField="intUnitID" HeaderText="intUnitID" 
                                SortExpression="intUnitID" />
                            <asp:BoundField DataField="intTypeID" HeaderText="intTypeID" 
                                SortExpression="intTypeID" />
                            <asp:BoundField DataField="intLevelOneID" HeaderText="intLevelOneID" 
                                SortExpression="intLevelOneID" />--%>
                                <asp:BoundField DataField="strProductName" HeaderText="Product Name" SortExpression="strProductName" />
                                <%--<asp:CheckBoxField DataField="ysnActive" HeaderText="ysnActive" 
                                SortExpression="ysnActive" />
                            <asp:BoundField DataField="intDetailsCount" HeaderText="intDetailsCount" 
                                SortExpression="intDetailsCount" />--%>
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetActiveItems"
                            TypeName="SAD_BLL.Item.Item">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="hdnL1" Name="levelOneId" PropertyName="Value" Type="String" />
                                <asp:ControlParameter ControlID="hdnId" Name="idList" PropertyName="Value" Type="String" />
                                <asp:ControlParameter ControlID="hdnSub" Name="subLevelList" PropertyName="Value"
                                    Type="String" />
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

<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.HR.Closing.HR_Closing" Codebehind="HR_Closing.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html >
<head runat="server">
    <title>HR CLOSING</title>
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
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
                    <br />
                    <br />
                    <br />
                    <table width="100%">
                        <tr style="text-align: center">
                            <td>
                                <b>HR Closing</b>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <div style="height: 100px;">
            </div>
            <ajaxToolkit:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </ajaxToolkit:AlwaysVisibleControlExtender>
            <asp:Panel ID="panDetails" runat="server" ScrollBars="None" Width="460px">
                <div>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblUnit" runat="server" CssClass="label" Text="Select Unit" Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" CssClass="DropDown"
                                    DataSourceID="odsUnitData" DataTextField="Text" DataValueField="Value" Width="200px"
                                    OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:ObjectDataSource ID="odsUnitData" runat="server" SelectMethod="GetAllUnitIdAndName"
                                    TypeName="HR_BLL.Global.Unit"></asp:ObjectDataSource>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="dgvHRClosing" runat="server" AutoGenerateColumns="False" DataKeyNames="intUnitId"
                        AllowSorting="True" Width="352px" SkinID="sknGrid2" OnRowDataBound="dgvPayslip_RowDataBound"
                        DataSourceID="odsHR_Period">
                        <Columns>
                            <asp:TemplateField HeaderText="Starting" SortExpression="dteHRStartingYear">
                                <HeaderTemplate>
                                    <asp:Label ID="Label8" runat="server" Text="Starting"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblEmployeeName" runat="server" Text='<%# Bind("dteHRStartingYear") %>'></asp:Label>
                                    <asp:HiddenField ID="hdnUnitID" runat="server" Value='<%# Bind("intUnitId") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="150px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ending" SortExpression="dteHREndingYear">
                                <HeaderTemplate>
                                    <asp:Label ID="Label11" runat="server" Text="Ending"></asp:Label>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("dteHREndingYear") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="150px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Close">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnClose" runat="server" CausesValidation="false" CommandName=""
                                        Text="Close" OnClick="btnClose_Click"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <tr style="background-color: Green;">
                                <th scope="col">
                                    Starting
                                </th>
                                <th scope="col">
                                    Ending
                                </th>
                                <th scope="col">
                                    Close
                                </th>
                            </tr>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="odsHR_Period" runat="server" SelectMethod="GetHRPeriodByUnitID"
                        TypeName="HR_BLL.Closing.HR_Closing" 
                        OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ddlUnit" Name="intUnitID" PropertyName="SelectedValue"
                                Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

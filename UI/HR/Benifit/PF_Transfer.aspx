<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.HR.Benifit.PF_Transfer" ValidateRequest="false"
    EnableEventValidation="false" Codebehind="PF_Transfer.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html ?
<html >
<head id="Head1" runat="server">
    <title>Provident Fund Investment</title>
    
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
                                Transfer
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
            <div id="divInvestment">
                <table>
                    <tr>
                        <td colspan="5" style="border: 2px solid black">
                            <asp:GridView ID="dgvPfTransfer" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                DataKeyNames="intUnitId" DataSourceID="odsNonTransferredTransactionDataSet" OnRowDataBound="dgvPfTransfer_RowDataBound"
                                SkinID="sknGrid2" Width="399px">
                                <Columns>
                                    <asp:TemplateField HeaderText="Unit Id" SortExpression="intUnitId" Visible="false">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnUnitId" runat="server" Value='<%# Bind("intUnitId") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField SortExpression="ysnChecked">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" Enabled="true" Checked='<%# Convert.ToBoolean(Eval("ysnChecked")) %>'
                                                OnCheckedChanged="CheckBox1_CheckedChanged" />
                                        </ItemTemplate>
                                        <ControlStyle Width="25px" />
                                        <ItemStyle HorizontalAlign="Left" Width="25px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="monEmployeeContribution" HeaderText="Employee's Contribution"
                                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" SortExpression="monEmployeeContribution"
                                        Visible="true" DataFormatString="{0:0.00}">
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="monEmployerContribution" HeaderText="Employer Contribution"
                                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" SortExpression="monEmployerContribution"
                                        Visible="true" DataFormatString="{0:0.00}">
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="totalPFAmountPerMonth" HeaderText="Amount" ItemStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="100px" SortExpression="totalPFAmountPerMonth" Visible="true"
                                        DataFormatString="{0:0.00}">
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Month Name" SortExpression="strMonthName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMonthName" runat="server" Text='<%# Bind("strMonthName") %>'></asp:Label>
                                            <asp:HiddenField ID="hdnMonthID" runat="server" Value='<%# Bind("intMonthId") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="intYearId" HeaderText="Year" ItemStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="100px" SortExpression="intYearId">
                                        <ItemStyle Width="100px" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <tr style="background-color: Green;">
                                        <th scope="col" style="width: 100px">
                                            Select
                                        </th>
                                        <th scope="col" style="width: 100px">
                                            Amount
                                        </th>
                                        <th scope="col" style="width: 120px">
                                            Month Name
                                        </th>
                                        <th scope="col" style="width: 100px">
                                            Year
                                        </th>
                                    </tr>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnTransfer" runat="server" Text="Transfer" CssClass="button" OnClick="btnTransfer_Click" />
                        </td>
                        <td>
                        </td>
                        <td colspan="2">
                            <asp:Label ID="lblTotalSelectedAmount" runat="server" Text="" CssClass="label"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <asp:HiddenField ID="hdnSoftwareLoginUserId" runat="server" />
            <asp:ObjectDataSource ID="odsNonTransferredTransactionDataSet" runat="server" SelectMethod="GetAllNonTransferredTransactionForDatagrid"
                TypeName="HR_BLL.Benifit.PF_Transfer_BLL" 
                OldValuesParameterFormatString="original_{0}">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hdnSoftwareLoginUserId" Name="intSoftwareLoginUserID"
                        PropertyName="Value" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

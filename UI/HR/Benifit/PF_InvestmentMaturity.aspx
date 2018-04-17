<%@ Page Language="C#" AutoEventWireup="true"
    EnableEventValidation="false" Inherits="UI.HR.Benifit.PF_InvestmentMaturity" Codebehind="PF_InvestmentMaturity.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html >
<head id="Head1" runat="server">
    <title>Invesetment Maturity</title>
      <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script type="text/javascript">
        function GotoNextFocus(ControlName, e) {
            var unicode = e.keyCode ? e.keyCode : e.charCode
            if (unicode == 13) {
                var control = document.getElementById(ControlName);
                if (control != null) {
                    control.focus();
                    window.event.returnValue = false
                }
            }
        }

//        function ShowInvestmentDetailsForMaturity(intInvestmentID, numInvestmentDuration, numInterestRate, intLoginUserId) {
//            window.showModalDialog('PF_InvestmentMaturityDetails.aspx?intInvestmentID=' + intInvestmentID + '&numInvestmentDuration=' + numInvestmentDuration + '&numInterestRate=' + numInterestRate + '&intLoginUserId=' + intLoginUserId, null, 'status:no;dialogWidth:375px;dialogHeight:250px;dialogHide:true;help:no;scroll:auto');
        //        }
        function ShowInvestmentDetailsForMaturity(intInvestmentID, numInvestmentDuration, numInterestRate, intLoginUserId) {
            window.open('PF_InvestmentMaturityDetails.aspx?intInvestmentID=' + intInvestmentID + '&numInvestmentDuration=' + numInvestmentDuration + '&numInterestRate=' + numInterestRate + '&intLoginUserId=' + intLoginUserId, null, 'status:no;dialogWidth:375px;dialogHeight:250px;dialogHide:true;help:no;scroll:auto');
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
                </div>
            </asp:Panel>
            <div style="height: 100px;">
            </div>
            <ajaxToolkit:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </ajaxToolkit:AlwaysVisibleControlExtender>
            <div>
                <table style="width: 750px">
                    <tr>
                        <td>
                            <asp:GridView ID="dgvInvestmentMaturity" runat="server" AutoGenerateColumns="False"
                                AllowSorting="True" Width="750px" SkinID="sknGrid2" OnRowDataBound="dgvInvestmentMaturity_RowDataBound"
                                Style="z-index: -5" DataSourceID="odsInvestmentMaturity">
                                <Columns>
                                    <asp:BoundField HeaderText="InvestmentId" SortExpression="intInvestmentID" DataField="intInvestmentID"
                                        Visible="true">
                                        <HeaderStyle ForeColor="Black" />
                                        <ItemStyle Width="80px" CssClass="gridItem"/>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Duration" SortExpression="numInvestmentDuration" DataField="numInvestmentDuration"
                                        Visible="true" DataFormatString="{0:0.00}">
                                        <HeaderStyle ForeColor="Black" />
                                        <ItemStyle Width="80px" CssClass="gridItem"/>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Rate" SortExpression="numInterestRate" DataField="numInterestRate"
                                        Visible="true" DataFormatString="{0:0.00}">
                                        <HeaderStyle ForeColor="Black" />
                                        <ItemStyle Width="80px" CssClass="gridItem"/>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Amount" SortExpression="monInvestmentAmount" DataField="monInvestmentAmount"
                                        Visible="true" DataFormatString="{0:0.00}" HeaderStyle-ForeColor="Black" 
                                        ItemStyle-Width="120px" >
                                        <HeaderStyle ForeColor="Black" />
                                        <ItemStyle Width="120px" CssClass="gridItem"/>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Account No." SortExpression="strAccountNo" DataField="strAccountNo"
                                        Visible="true"  HeaderStyle-ForeColor="Black" 
                                        ItemStyle-Width="120px" >
                                        <HeaderStyle ForeColor="Black" />
                                        <ItemStyle Width="120px" CssClass="gridItem"/>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Bank Name" SortExpression="strBankCode" DataField="strBankCode"
                                        Visible="true"  HeaderStyle-ForeColor="Black" 
                                        ItemStyle-Width="120px" >
                                        <HeaderStyle ForeColor="Black" />
                                        <ItemStyle Width="120px" CssClass="gridItem"/>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Branch Name" SortExpression="strBranchName" DataField="strBranchName"
                                        Visible="true"  HeaderStyle-ForeColor="Black" 
                                        ItemStyle-Width="120px" >
                                        <HeaderStyle ForeColor="Black" />
                                        <ItemStyle Width="120px" CssClass="gridItem"/>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Unit Name" SortExpression="strUnit" DataField="strUnit"
                                        Visible="true"  HeaderStyle-ForeColor="Black" 
                                        ItemStyle-Width="120px" >
                                        <HeaderStyle ForeColor="Black" />
                                        <ItemStyle Width="120px" CssClass="gridItem"/>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Matured">
                                        <ItemTemplate>
                                            <input id="btnMatured" type="button" style="width: 80px; cursor: pointer" value="Matured"
                                                onclick="<%# GetStr( Eval("intInvestmentID"),Eval("numInvestmentDuration"),Eval("numInterestRate")) %>" />
                                        </ItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="Label16" runat="server" Text="Matured"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <tr style="background-color: Green;">
                                        <th scope="col">
                                            InvestmentId
                                        </th>
                                        <th scope="col">
                                            Duration
                                        </th>
                                        <th scope="col">
                                            Investment Amount
                                        </th>
                                        <th scope="col">
                                            Pf Account No.
                                        </th>
                                        <th scope="col">
                                            Bank Name
                                        </th>
                                        <th scope="col">
                                            Branch Name
                                        </th>
                                        <th scope="col">
                                            Unit Name
                                        </th>
                                        <th scope="col" style="width:80px">
                                            Matured
                                        </th>
                                    </tr>
                                </EmptyDataTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:GridView>
                            <asp:ObjectDataSource ID="odsInvestmentMaturity" runat="server" SelectMethod="GetNonMaturedInvestmentDetailsForDatagridByUnitId"
                                TypeName="HR_BLL.Benifit.PF_Maturity_BLL" 
                                OldValuesParameterFormatString="original_{0}">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="hdnPfUnitId" Name="intUnitID" PropertyName="Value"
                                        Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:HiddenField ID="hdnLoginUserId" runat="server" />
                            <asp:HiddenField ID="hdnPfUnitId" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

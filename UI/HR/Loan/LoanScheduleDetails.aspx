<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="UI.HR.Loan.LoanScheduleDetails" Codebehind="LoanScheduleDetails.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html >
<head id="Head1" runat="server">
    <title>Loan schedule details</title>
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
                    <br />
                    <br />
                    <br />
                    <table width="100%">
                        <tr style="text-align: center">
                            <td>
                                <b>Loan Schedule Details</b>
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
            <asp:Panel ID="panDetails" runat="server" ScrollBars="Auto" Width="650px" Height="320px">
                <div style="text-align:center">
                    <table width="650px">
                        <tr style="text-align: center">
                            <td>
                                <asp:GridView ID="dgvLoanScheduleDetails" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    Width="630px" SkinID="sknGrid2" DataSourceID="dgvLoanScheduleDetailsObjectDataSource">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Schedule Number" SortExpression="intScheduleId">
                                            <ItemTemplate>
                                                <asp:Label ID="Label61" runat="server" Text='<%# Bind("intScheduleId") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Installment Month" SortExpression="intMonth">
                                            <ItemTemplate>
                                                <asp:Label ID="Label71" runat="server" Text='<%# Bind("intMonth") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Installment Year" SortExpression="intYear">
                                            <ItemTemplate>
                                                <asp:Label ID="Label18" runat="server" Text='<%# Bind("intYear") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Installment Amount" SortExpression="intInstallmentAmount">
                                            <ItemTemplate>
                                                <asp:Label ID="Label51" runat="server" Text='<%# Bind("intInstallmentAmount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="250px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Installment Status" SortExpression="strInstallmentStatus">
                                            <ItemTemplate>
                                                <asp:Label ID="Label11" runat="server" Text='<%# Bind("strInstallmentStatus") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="250px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:ObjectDataSource ID="dgvLoanScheduleDetailsObjectDataSource" 
                                    runat="server" SelectMethod="GetLoanScheduleDetailsByLoanApplicationID" 
                                    TypeName="HR_BLL.Loan.Loan">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="hdnLoanApplicationId" 
                                            Name="intLoanApplicationId" PropertyName="Value" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField ID="hdnLoanApplicationId" runat="server" />
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

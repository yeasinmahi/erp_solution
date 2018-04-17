﻿<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="UI.HR.Salary.UnitwiseSalarySubmittedToBank" Codebehind="UnitwiseSalarySubmittedToBank.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html >
<head runat="server">
    <title>Unitwise salary submitted to bank</title>
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

        function ShowSalaryAdviceToBank(intUnitID) {
            window.open('SalaryAdviceToBank.aspx?intUnitID=' + intUnitID, null, 'status:no;dialogWidth:750px;dialogHeight:950px;dialogHide:true;help:no;scroll:auto');
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
                <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                        scrolldelay="-1" width="100%">
                    	<span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                	</marquee>
                </div>
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">
                    &nbsp;
                </div>
            </asp:Panel>
            <div style="height: 100px;">
            </div>
            <ajaxToolkit:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </ajaxToolkit:AlwaysVisibleControlExtender>
            <div>
                
                <table>

                    <tr>
                        <td>
                            <asp:GridView ID="dgvUnitwiseSalarySubmittedToBank" runat="server" AutoGenerateColumns="False"
                                AllowSorting="True" Width="750px" SkinID="sknGrid2" 
                                OnRowDataBound="dgvUnitwiseSalarySubmittedToBank_RowDataBound" 
                                Style="z-index: -5" DataSourceID="odsUnitwiseSalaryDetailsData">
                                <Columns>
                                    <asp:TemplateField HeaderText="Unit Name" SortExpression="UnitName">
                                        <HeaderTemplate>
                                            <asp:Label ID="Label8" runat="server" Text="Unit Name"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmployeeName" runat="server" Text='<%# Bind("UnitName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CD Account No." SortExpression="CDAcountNo">
                                        <HeaderTemplate>
                                            <asp:Label ID="Label11" runat="server" Text="CD Account No."></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("CDAcountNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="120px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total Amount" SortExpression="TotalPayableSalary">
                                        <HeaderTemplate>
                                            <asp:Label ID="Label12" runat="server" Text="Total Amount"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1A" runat="server" Text='<%# Bind("TotalPayableSalary") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="150px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Print Advice">
                                        <ItemTemplate>
                                        <input id="btnPrintAdvice" type="button" style="width: 150px;cursor:pointer" value="Advice" onclick="<%# GetStr( Eval("intUnitID")) %>" />
                                        </ItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="Label9" runat="server" Text="Print Advice"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="150px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Submitted To Bank">
                                        <ItemTemplate>
                                            <asp:Button ID="btnSubmittedToBank" runat="server" CommandArgument='<%# Eval("CDAcountNo") %>' CssClass = "btnGridCursor"
                                                CommandName="SubmittedToBank" OnCommand="btnSubmittedToBank_OnCommand" Text="Submitted To Bank" Width="150px" />
                                        </ItemTemplate>
                                        <HeaderTemplate>
                                            <asp:Label ID="Label10" runat="server" Text="Submitted To Bank"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="150px" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <tr style="background-color: Green;">
                                        <th scope="col">
                                            Unit Name
                                        </th>
                                        <th scope="col">
                                            CD Account No.
                                        </th>
                                        <th scope="col">
                                            Total Amount
                                        </th>
                                        <th scope="col">
                                            Print Advice
                                        </th>
                                        <th scope="col">
                                            Submitted To Bank
                                        </th>
                                    </tr>
                                </EmptyDataTemplate>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="odsUnitwiseSalaryDetailsData" runat="server" 
                                SelectMethod="GetUnitwiseSalaryDetails" 
                                TypeName="HR_BLL.Salary.SalaryInfo" 
                                OldValuesParameterFormatString="original_{0}">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="hdnLoginUserId" Name="intLoginUserId" 
                                        PropertyName="Value" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:HiddenField ID="hdnLoginUserId" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
        
    </form>
</body>
</html>

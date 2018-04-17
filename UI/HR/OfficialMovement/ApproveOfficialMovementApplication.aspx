<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="UI.HR.OfficialMovement.ApproveOfficialMovementApplication" Codebehind="ApproveOfficialMovementApplication.aspx.cs" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html >
<head runat="server">
    <title>Official Movement Application Approve</title>
   
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
                    <br />
                    <br />
                    <br />
                    <table width="100%">
                        <tr style="text-align: center">
                            <td>
                                <b>Official Movement Application Approve</b>
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
            <asp:Panel ID="panDetails" runat="server" ScrollBars="None" Width="100%">
                <div>
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="dgvApproveOfficialMovementApplication" runat="server" AllowSorting="True"
                                    AutoGenerateColumns="False" SkinID="sknGrid2" Width="750px" DataSourceID="dgdApproveOfficialMovementApplicationObjectDataSource">
                                    <Columns>
                                        <asp:BoundField DataField="strEmployeeName" HeaderText="EMployeee Name" ItemStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="100px" SortExpression="strEmployeeName" Visible="true">
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Movement Type" SortExpression="strMoveType">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLeaveType" runat="server" Text='<%# Bind("strMoveType") %>'></asp:Label>
                                                <%--<asp:HiddenField ID="hdnApplicationId" runat="server" Value='<%# Bind("intId") %>' />--%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="dteAppliedTime" HeaderText="Applied Date" DataFormatString="{0:MM/dd/yyyy}"
                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" SortExpression="dteAppliedTime"
                                            Visible="true">
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="dteStartTime" HeaderText="From Date" DataFormatString="{0:MM/dd/yyyy}"
                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" SortExpression="dteStartTime">
                                            <ItemStyle Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="dteEndTime" HeaderText="To Date" DataFormatString="{0:MM/dd/yyyy}"
                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" SortExpression="dteEndTime">
                                            <ItemStyle Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="strReason" HeaderText="Reason" ItemStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="150px" SortExpression="strReason">
                                            <ItemStyle Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="strAddress" HeaderText="Address" ItemStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="100px" SortExpression="strAddress">
                                            <ItemStyle Width="100px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Approve">
                                            <ItemTemplate>
                                                <asp:Button ID="btnApprove" runat="server" CommandArgument='<%# Eval("intId") %>'
                                                    CommandName="Approve" OnCommand="btnApprove_OnCommand" Text="Approve" Width="100px" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <tr style="background-color: Green;">
                                            <th scope="col" style="width: 100px">
                                                Employee Name
                                            </th>
                                            <th scope="col" style="width: 100px">
                                                Movement Type
                                            </th>
                                            <th scope="col" style="width: 100px">
                                                Application Date
                                            </th>
                                            <th scope="col" style="width: 100px">
                                                From Date
                                            </th>
                                            <th scope="col" style="width: 100px">
                                                To Date
                                            </th>
                                            <th scope="col" style="width: 150px">
                                                Reason
                                            </th>
                                            <th scope="col" style="width: 100px">
                                                Address
                                            </th>
                                            <th scope="col" style="width: 100px">
                                                Approve
                                            </th>
                                        </tr>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                                <asp:ObjectDataSource ID="dgdApproveOfficialMovementApplicationObjectDataSource" 
                                    runat="server" 
                                    SelectMethod="GetAllUnapproveOfficialMovementApplicationForApproveByUserID" 
                                    TypeName="HR_BLL.OfficialMovement.OfficialMovement" 
                                    OldValuesParameterFormatString="original_{0}">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="hdnUserID" Name="intUserID" 
                                            PropertyName="Value" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                    <asp:HiddenField ID="hdnUserID" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

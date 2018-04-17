<%@ Page Language="C#" AutoEventWireup="true"
    EnableEventValidation="false" Inherits="UI.HR.HolidayCalendar.HolidaySetupPopup" Codebehind="HolidaySetupPopup.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html >
<head runat="server">
    <title>Holiday Setup</title>
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
        function refreshParent() {
//            window.opener.location.href = window.opener.location.href;
            this.close();
        }
    </script>
</head>
<body onunload=refreshParent();>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="divMain" runat="server" style="width: 571px;">
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
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 80px; text-align: right">
                                <asp:Label ID="Label1" runat="server" CssClass="label" Text="Holiday Name"></asp:Label>
                            </td>
                            <td style="width: 300px">
                                <asp:TextBox ID="txtHolidayName" runat="server" Width="300px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtHolidayName"
                                    ErrorMessage="*" ForeColor="#FF5050" ValidationGroup="VG"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Button ID="btnBackToSetupPage" runat="server" Width="142px"
                                    OnClientClick="refreshParent();" Text="Back To Permission Setup" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 80px; text-align: right">
                                <asp:Label ID="Label2" runat="server" CssClass="label" Text="Description" Width="80px"></asp:Label>
                            </td>
                            <td style="width: 300px">
                                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="300px"
                                    Height="34px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDescription"
                                    ErrorMessage="*" ForeColor="#FF5050" ValidationGroup="VG"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="width: 80px;">
                            </td>
                            <td style="width: 60px">
                                <asp:Button ID="btnAdd" runat="server" CssClass="button" Text="Add" Width="60px"
                                    OnClick="btnAdd_Click" ValidationGroup="VG" />
                            </td>
                            <td style="width: 60px">
                                <asp:Button ID="btnEdit" runat="server" CssClass="button" Text="Edit" Width="60px"
                                    OnClick="btnEdit_Click" ValidationGroup="VG" />
                            </td>
                            <td style="width: 60px">
                                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" Width="60px"
                                    OnClick="btnDelete_Click" />
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnHolidayId" runat="server" />
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnUserId" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <asp:Panel ID="panHolidayGrid" runat="server" Width="571px"  ScrollBars="Auto">
                        <table>
                            <tr>
                                <td>
                                    <asp:GridView ID="dgvHolliday" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                        DataKeyNames="intHolidayID" SkinID="sknGrid2" Width="547px" OnRowDataBound="dgvHolliday_RowDataBound"
                                        OnSelectedIndexChanged="dgvHolliday_SelectedIndexChanged" 
                                        DataSourceID="odsHoliday">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Holiday Name" SortExpression="strHolidayName" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblHolidayName" runat="server" Text='<%# Bind("strHolidayName") %>'></asp:Label>
                                                    <asp:HiddenField ID="hdnHoliday" runat="server" Value='<%# Bind("intHolidayID") %>' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="strDescription" HeaderText="Description" ItemStyle-HorizontalAlign="Center"
                                                ItemStyle-Width="447px" SortExpression="strDescription">
                                                <ItemStyle Width="447px" />
                                            </asp:BoundField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <tr style="background-color: Green;">
                                                <th scope="col" style="width: 100px; text-align: left">
                                                    Holiday Name
                                                </th>
                                                <th scope="col" style="width: 447px; text-align: center">
                                                    Description
                                                </th>
                                            </tr>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    <asp:ObjectDataSource ID="odsHoliday" runat="server" SelectMethod="GetAllHoliday"
                                        TypeName="HR_BLL.HolidayCalendar.HolidaySetup"></asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

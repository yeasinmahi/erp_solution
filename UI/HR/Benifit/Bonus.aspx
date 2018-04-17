<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.HR.Benifit.Bonus" Codebehind="Bonus.aspx.cs" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html >
<head id="Head1" runat="server">
    <title>Bonus Calculation</title>
   
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

   <asp:PlaceHolder ID="PlaceHolder1" runat="server">     
          <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
    </asp:PlaceHolder>  
    
    
    <script type="text/javascript">

//        jQuery(document).ready(function () {
//            $("#dgvBonusDetails").tablesorter({ debug: false, widgets: ['zebra'], sortList: [[0, 0]] });
//        });

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
	<asp:ScriptReference name="Common.DateTime.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.AnimationBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="PopupExtender.PopupBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Common.Threading.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Calendar.CalendarBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="TextboxWatermark.TextboxWatermark.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
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
                                <b>Calaculate Bonus</b>
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
            <asp:Panel ID="panDetails" runat="server" ScrollBars="None">
                <div style="border: 2px solid black; width: 750px">
                    <table>
                        <tr>
                            <td style="border: 1px solid gray">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblBonusType" runat="server" CssClass="label" Text="Bonus Type"></asp:Label>
                                        </td>
                                        <td colspan="2" style="width: 125px">
                                            <asp:DropDownList ID="ddlBonusType" runat="server" CssClass="DropDown" Width="120px"
                                                DataSourceID="odsBonusType" DataTextField="Text" DataValueField="Value">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlBonusType"
                                                ErrorMessage="*" ForeColor="Red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="Effected Date" CssClass="label"></asp:Label>
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtEffectedDate" runat="server" Width="100px" CssClass="txt"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CDX" runat="server" TargetControlID="txtEffectedDate">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red"
                                                ControlToValidate="txtEffectedDate" ValidationGroup="VG" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEffectedDate"
                                                ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationExpression="^[0-9m]{1,2}/[0-9d]{1,2}/[0-9y]{4}$"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td colspan="2">
                                            <asp:Button ID="btnGenerateBonus" runat="server" CssClass="button" OnClick="btnGenerateBonus_Click"
                                                Text="Generate Bonus" Width="120px" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td style="width: 55px">
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:ObjectDataSource ID="odsBonusGridData" runat="server" OldValuesParameterFormatString="original_{0}"
                                                SelectMethod="GetBonusDetailsForDataGrid" TypeName="HR_BLL.Benifit.Bonus_BLL"
                                                FilterExpression="strEmployeeName like '%{0}%' or strUnit like '%{0}%' or strBonusName like '%{0}%'">
                                                <FilterParameters>
                                                    <asp:ControlParameter Name="strEmployeeName" ControlID="txtSearch" PropertyName="Text" />
                                                    <asp:ControlParameter Name="strUnit" ControlID="txtSearch" PropertyName="Text" />
                                                    <asp:ControlParameter Name="strBonusName" ControlID="txtSearch" PropertyName="Text" />
                                                </FilterParameters>
                                            </asp:ObjectDataSource>
                                            <asp:ObjectDataSource ID="odsBonusType" runat="server" OldValuesParameterFormatString="original_{0}"
                                                SelectMethod="GetBonusType" TypeName="HR_BLL.Benifit.Bonus_BLL"></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="border: 1px solid gray">
                                <asp:TextBox ID="txtSearch" runat="server" OnTextChanged="txtSearch_TextChanged"
                                    CssClass="txt" AutoPostBack="True" Width="280px" />
                                <ajaxToolkit:TextBoxWatermarkExtender ID="TBWE2" runat="server" TargetControlID="txtSearch"
                                    WatermarkText="Search by Name(code) or Unit or Bonus Name" WatermarkCssClass="txt" />
                            </td>
                        </tr>
                        <tr>
                            <td style="border: 1px solid black">
                                <asp:GridView ID="dgvBonusDetails" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    DataKeyNames="intEmployeeId" SkinID="sknGrid2" Width="750px" DataSourceID="odsBonusGridData"
                                    AllowPaging="True" PageSize="20">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Employee Name" SortExpression="strEmployeeName">
                                            <ItemStyle Width="230px" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblFirstname" Text='<%# HighlightText(Eval("strEmployeeName").ToString()) %>'
                                                    runat="server" CssClass="txt" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="strUnit" HeaderText="Unit Name" ItemStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="100px" SortExpression="strUnit">
                                            <ItemStyle Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="strBonusName" HeaderText="Bonus Name" ItemStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="100px" SortExpression="strBonusName">
                                            <ItemStyle Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="monBonusAmount" DataFormatString="{0:0.00}" HeaderText="Bonus Amount"
                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" SortExpression="monBonusAmount"
                                            Visible="true">
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="strMonthName" HeaderText="Effected Month" ItemStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="100px" SortExpression="strMonthName">
                                            <ItemStyle Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="intYearId" HeaderText="Year" ItemStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="100px" SortExpression="intYearId">
                                            <ItemStyle Width="100px" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <tr style="background-color: Green;">
                                            <th scope="col" style="width: 230px">
                                                Employee Name
                                            </th>
                                            <th scope="col" style="width: 100px">
                                                Unit Name
                                            </th>
                                            <th scope="col" style="width: 100px">
                                                Bonus Name
                                            </th>
                                            <th scope="col" style="width: 100px">
                                                Bonus Amount
                                            </th>
                                            <th scope="col" style="width: 100px">
                                                Effected Month
                                            </th>
                                            <th scope="col" style="width: 100px">
                                                Year
                                            </th>
                                        </tr>
                                    </EmptyDataTemplate>
                                </asp:GridView>
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

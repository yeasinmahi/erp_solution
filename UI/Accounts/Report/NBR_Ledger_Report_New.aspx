<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NBR_Ledger_Report_New.aspx.cs" Inherits="UI.Accounts.Report.NBR_Ledger_Report_New" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html >
<head id="Head1" runat="server">
    <title>Welcome to Akij Group</title>

     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/AutoCompleteCSS" />

    <script type="text/javascript">
        function ShowHide() {

            if (document.getElementsByName("rdoCodeRange") != null) {

                var rad_val = '';

                for (var i = 0; i < document.getElementsByName("rdoCodeRange").length; i++) {
                    if (document.getElementsByName("rdoCodeRange").item(i).checked) {
                        rad_val = document.getElementsByName("rdoCodeRange").item(i).value;
                    }
                }

                if (rad_val == 'range') {
                    document.getElementById("tdA1").style.display = "none";
                    document.getElementById("tdA2").style.display = "none";
                    document.getElementById("tdP1").style.display = "none";

                    document.getElementById("tdC1").style.display = "block";
                    document.getElementById("tdC2").style.display = "block";
                }
                else if (rad_val == 'one') {
                    document.getElementById("tdA1").style.display = "block";
                    document.getElementById("tdA2").style.display = "block";

                    document.getElementById("tdC1").style.display = "none";
                    document.getElementById("tdC2").style.display = "none";
                    document.getElementById("tdP1").style.display = "none";
                }
                else if (rad_val == 'parent') {
                    document.getElementById("tdP1").style.display = "block";

                    document.getElementById("tdA1").style.display = "none";
                    document.getElementById("tdA2").style.display = "none";

                    document.getElementById("tdC1").style.display = "none";
                    document.getElementById("tdC2").style.display = "none";
                }
                else {
                    document.getElementById("tdP1").style.display = "none";

                    document.getElementById("tdA1").style.display = "block";
                    document.getElementById("tdA2").style.display = "block";

                    document.getElementById("tdC1").style.display = "none";
                    document.getElementById("tdC2").style.display = "none";
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                <asp:Panel ID="pnlMarque" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;
                        z-index: 1; position: absolute;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                            scrolldelay="-1" width="100%">
                            <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                        </marquee>
                    </div>
                </asp:Panel>
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 120px; float: right;">
                    <table style="height: 120px;">
                        <tr>
                            <td colspan="2" align="left" class="PageHeader">
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"
                                    RepeatDirection="Horizontal" OnLoad="RadioButtonList1_Load">
                                    <asp:ListItem Value="led" Enabled="false">Schedule</asp:ListItem>
                                    <asp:ListItem Value="conLed" Enabled="false">Sub Schedule</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="sub">Sub Ledger</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td colspan="3" align="left" style="color: Green;">
                                <asp:RadioButtonList ID="rdoCodeRange" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="one">Sub Acc</asp:ListItem>
                                    <asp:ListItem Value="range">Code Range</asp:ListItem>
                                    <asp:ListItem Value="parent">All Sub</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RadioButtonList ID="RadioButtonList2" runat="server" Visible="false" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="gen">General</asp:ListItem>
                                    <asp:ListItem Value="drcr">Debit Credit</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td colspan="3" align="right">
                                Unit:
                                <asp:DropDownList ID="ddlUnit" runat="server" DataSourceID="odsUnit" DataTextField="strUnit"
                                    DataValueField="intUnitID" AutoPostBack="True" OnDataBound="ddlUnit_DataBound"
                                    OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
                                    <SelectParameters>
                                        <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td id="tdA1" style="color: Green;">
                                Select Account
                            </td>
                            <td id="tdA2">
                                <asp:TextBox ID="txtCOA" runat="server" AutoCompleteType="Search" Width="255px"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtCOA"
                                    ServiceMethod="GetCOAList" MinimumPrefixLength="1" CompletionSetCount="1" CompletionInterval="1"
                                    DelimiterCharacters="%" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElement"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>
                            <td id="tdC1" style="display: none; color: Green;">
                                From
                                <asp:TextBox ID="txtCrFr" runat="server"></asp:TextBox>
                            </td>
                            <td id="tdC2" style="display: none; color: Green;">
                                To
                                <asp:TextBox ID="txtCrTo" runat="server"></asp:TextBox>
                            </td>
                            <td id="tdP1" style="display: none; color: Green;" colspan="2">
                                Control Acc
                                <asp:TextBox ID="txtP" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;&nbsp;From
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnFrm" runat="server" />
                                <asp:TextBox ID="txtFrom" runat="server" autocomplete="off"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFrom" Format="dd/MM/yyyy"
                                    PopupButtonID="imgCal_1" ID="CalendarExtender1" runat="server" EnableViewState="true">
                                </cc1:CalendarExtender>
                                <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />
                            </td>
                            <td>
                                &nbsp;&nbsp;To
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnTo" runat="server" />
                                <asp:TextBox ID="txtTo" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtTo" Format="dd/MM/yyyy"
                                    PopupButtonID="imgCal_2" ID="CalendarExtender2" runat="server" EnableViewState="true">
                                </cc1:CalendarExtender>
                                <img id="imgCal_2" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />
                            </td>
                            <td align="right">
                                <asp:Button ID="btnSubmit" runat="server" Text="Show" OnClick="btnSubmit_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <div style="height: 140px;">
            </div>
            <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </cc1:AlwaysVisibleControlExtender>
            <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" Style="z-index: 0;
                left: 0px; position: absolute; top: 140px" HasCrystalLogo="False" HasDrillUpButton="False"
                HasRefreshButton="False" ToolPanelView="None" OnUnload="CrystalReportViewer1_Unload" />--%>
            <div id="divReportViewer" runat="server" style="width: 800px">
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                    InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
                    Width="1050px" Height="766px" BackColor="#EEF1FB" EnableTheming="true">
                </rsweb:ReportViewer>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        ShowHide();        
    </script>
    </form>
</body>
</html>

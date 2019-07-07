<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="UI.Accounts.Banking.Report.AccountReconcile" Codebehind="AccountReconcile.aspx.cs" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html >
<html >
<head id="Head1" runat="server">
    <title>Welcome to Akij Group</title>
    <asp:PlaceHolder ID="PlaceHolder0" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" /> 
    <script>
         function loadIframe(iframeName, url) {
            var $iframe = $('#' + iframeName);
            if ($iframe.length) {
                $iframe.attr('src', url); 
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
        <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;
            z-index: 1; position: absolute;">
            <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </marquee>
        </div>
        <div id="divControl" class="divPopUp2" style="width: 100%; height: 100px; float: right;">
            <table width="90%">
                <tr>
                    <td align="left" class="PageHeader">
                        Account Reconcile
                    </td>
                    <td colspan="2">
                        Up to Date
                        <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
                        <cc1:CalendarExtender CssClass="cal_Theme1" ID="CalendarExtender1" runat="server"
                            EnableViewState="true" Format="yyyy-MM-dd" PopupButtonID="imgCal_1" TargetControlID="txtFrom">
                        </cc1:CalendarExtender>
                        <img id="imgCal_1" src="../../../Content/images/img/calbtn.gif" style="border: 0px;
                            width: 34px; height: 23px; vertical-align: bottom;" />
                    </td>
                    <td align="right">
                        Unit
                        <asp:DropDownList ID="ddlUnit" runat="server" DataSourceID="odsUnit" DataTextField="strUnit"
                            DataValueField="intUnitID" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
                <tr style="height: 70px;">
                    <td>
                        Bank
                        <asp:DropDownList ID="ddlBank" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource2"
                            DataTextField="strBankName" DataValueField="intBankID" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetActiveForDDLWithAll"
                            TypeName="BLL.Accounts.Bank.BankInfo" OldValuesParameterFormatString="original_{0}">
                        </asp:ObjectDataSource>
                    </td>
                    <td>
                        Branch
                        <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource3"
                            DataTextField="strBranchName" DataValueField="intBranchID" OnDataBound="ddlBranch_DataBound"
                            OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetActiveForDDL"
                            TypeName="BLL.Accounts.Bank.BankBranch" OldValuesParameterFormatString="original_{0}">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlBank" Name="bankID" PropertyName="SelectedValue"
                                    Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                    <td>
                        A/C No.
                        <asp:DropDownList ID="ddlAccount" runat="server" DataSourceID="ObjectDataSource4"
                            DataTextField="strAccountNo" DataValueField="intAccountID">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="GetActiveForDDLByBranch"
                            TypeName="BLL.Accounts.Bank.BankAccount" OldValuesParameterFormatString="original_{0}">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlBranch" Name="branchID" PropertyName="SelectedValue"
                                    Type="String" />
                                <asp:ControlParameter ControlID="ddlUnit" Name="unitID" PropertyName="SelectedValue"
                                    Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                    <td align="right">
                        <asp:Button ID="btnSubmit" runat="server" Text="Show" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <div style="height: 120px;">
    </div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
        runat="server">
    </cc1:AlwaysVisibleControlExtender>
  
    <%--<div id="divReportViewer">--%>
       <%-- <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
            InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
            Width="900px" Height="750px" BackColor="#EEF1FB" EnableTheming="true">
        </rsweb:ReportViewer>--%>
         <iframe runat="server" oncontextmenu="return false;" id="frame" name="frame" style="width:100%; height:1000px; border:0px solid red;"></iframe>
    <%--</div>--%>
    </form>
</body>
</html>

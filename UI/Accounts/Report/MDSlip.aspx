<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.Accounts.Report.MDSlip" Codebehind="MDSlip.aspx.cs" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html >
<head id="Head1" runat="server">
    <title>Welcome to Akij Group</title>

     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" LoadScriptsBeforeUI="false">
    </asp:ScriptManager>    
            <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top; z-index:1; position:absolute;">
                    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                        scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </marquee>
                </div>
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">
                    <table width="90%">
                        <tr>
                            <td align="left" class="PageHeader">
                                MD Slip
                            </td>
                            <td align="left">
                                Unit
                                <asp:DropDownList ID="ddlUnit" runat="server" DataSourceID="ObjectDataSource1" DataTextField="strUnit"
                                    DataValueField="intUnitID" AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetUnits"
                                    TypeName="HR_BLL.Global.Unit" 
                                    OldValuesParameterFormatString="original_{0}">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                            <td align="center">
                                Date
                                <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" ID="CalendarExtender1" runat="server" EnableViewState="true"
                                    Format="dd/MM/yyyy" PopupButtonID="imgCal_1" TargetControlID="txtFrom">
                                </cc1:CalendarExtender>
                                <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />
                            </td>
                            <td align="right">
                                <asp:Button ID="btnSubmit" runat="server" Text="Show" OnClick="btnSubmit_Click" />
                            </td>
                            <td align="left">                                
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <div style="height: 100px;">
            </div>
            <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </cc1:AlwaysVisibleControlExtender>
            
       

         <div id="divReportViewer" runat="server" >
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                    InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
                    Width="1024px" Height="766px" BackColor="#EEF1FB" EnableTheming="true">
                </rsweb:ReportViewer>
                
            </div>
     
    </form>
</body>
</html>

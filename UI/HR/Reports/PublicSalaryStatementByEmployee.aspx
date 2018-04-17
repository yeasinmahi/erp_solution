<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="UI.HR.Reports.PublicSalaryStatementByEmployee" Codebehind="PublicSalaryStatementByEmployee.aspx.cs" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>

<html >
<head id="Head1" runat="server">
    <title>Daily Attendance Summary Calenderview</title>
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">     
          <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
    </asp:PlaceHolder>  
    
    <!--
    <script type="text/javascript">
        function KeySelected(source, eventArgs) {
            if (event.keyCode == '13') {
                var searchString = document.getElementById('txtSearchByName').value;
                var word = searchString.split(",");
                document.getElementById('hdfEmpCode').value = word[1];
                //PageMethods.ClientMethodCalledByJavaScript(word[1]);
                //                alert(word[1]);
            }
        }

    </script>

        -->

    <script type="text/javascript">

        $(document).ready(function () {

            SearchText();
        });
        function SearchText() {
            $("#txtSearchByName").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;",
                        url: "PublicSalaryStatementByEmployee.aspx/GetAutoCompleteData",
                        data: "{'strSearchKey':'" + document.getElementById('txtSearchByName').value + "'}",
                        dataType: "json",
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (result) {
                            alert("Error");
                        }
                    });
                }
            });
        }


    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        <CompositeScript>
            <Scripts>
                <asp:ScriptReference name="MicrosoftAjax.js"/>
	<asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
	<asp:ScriptReference name="MicrosoftAjaxTimer.js" assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"/>
	<asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="TextboxWatermark.TextboxWatermark.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.AnimationBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="PopupExtender.PopupBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="AutoComplete.AutoCompleteBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
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
                    <div>
                        <table>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td class="style5">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td class="style5">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td class="style5">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label15" runat="server" CssClass="label" Text="Search By Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSearchByName"  CssClass="name"  runat="server" Width="200px" Height="20px"></asp:TextBox>
                                    <ajaxToolkit:TextBoxWatermarkExtender ID="TBWE2" runat="server" TargetControlID="txtSearchByName"
                                    WatermarkText="Type Employee Name Here" WatermarkCssClass="watermarked" />
                                   <%--<telerik:RadAutoCompleteBox runat="server" ID="AutoCompleteBox" DropDownHeight="200px" DropDownWidth="200px" DataSourceID="odssearchapplicant" 
                                DataValueField="intEmployeeID" DataTextField="searchcomponent" TextSettings-SelectionMode="Single" LabelWidth="300px" Width="350px" Delimiter="," > 
                                </telerik:RadAutoCompleteBox >                            
                                <asp:ObjectDataSource ID="odssearchapplicant" runat="server" SelectMethod="SearchInformation" TypeName="HR_BLL.Global.AutoSearch_BLL" OldValuesParameterFormatString="original_{0}">
                                <SelectParameters><asp:SessionParameter Name="intLoginId" SessionField="sesUserId" Type="Int32" /></SelectParameters>
                                </asp:ObjectDataSource> --%>
                                    <asp:Button ID="btnShowReport" runat="server" OnClick="btnShowReport_Click" Text="Show Report"
                                        CssClass="button" />
                                </td>
                                <td colspan="2">
                                    <asp:HiddenField ID="hdfEmpCode" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </asp:Panel>
            <div style="height: 100px;">
            </div>
            <ajaxToolkit:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </ajaxToolkit:AlwaysVisibleControlExtender>
            <asp:Panel ID ="panReportViewer" runat="server" ScrollBars="None" Height="550px">
            <div id="divReportViewer" runat="server">
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                    InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
                    Width="1050px" Height="766px">
                </rsweb:ReportViewer>
            </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
        
    </form>
</body>
</html>

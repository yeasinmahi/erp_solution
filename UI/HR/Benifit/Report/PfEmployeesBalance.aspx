<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="UI.HR.Benifit.Report.PfEmployeesBalance" Codebehind="PfEmployeesBalance.aspx.cs" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Employee's PF Statement</title>

     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
   
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">     
          <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
    </asp:PlaceHolder>  
   
    <script type="text/javascript">
        $(document).ready(function () {
            SearchText();
        });
        function SearchText() {
            $("#txtSearchEmployee").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "PfEmployeesBalance.aspx/GetAutoCompleteData",
                        data: "{'strSearchKey':'" + document.getElementById('txtSearchEmployee').value + "'}",
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
                    <table>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 150px">
                                <asp:Label ID="Label6" runat="server" CssClass="label" Text="Search Employee"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSearchEmployee" AutoCompleteType="Search" runat="server" AutoPostBack="true"
                                    Width="200px" Height="20px"></asp:TextBox>
                                <ajaxToolkit:TextBoxWatermarkExtender ID="TBWE2" runat="server" TargetControlID="txtSearchEmployee"
                                    WatermarkText="Type Name / Code Here" WatermarkCssClass="watermarked" />
                                <asp:Button ID="btnShowReport" runat="server" CssClass="button" OnClick="btnShowReport_Click"
                                    Text="Show Report" />
                            </td>
                            <td>
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
            <div>
                <table>
                    <tr>
                        <td style="width: 85px">
                        </td>
                        <td style="width: 350px;">
                            <asp:HiddenField ID="hdnEmployeeID" runat="server" />
                        </td>
                        <td>
                            <asp:HiddenField ID="hdfEmpCode" runat="server" />
                            <asp:HiddenField ID="hdnName" runat="server" />
                            <asp:HiddenField ID="hdnUnitName" runat="server" />
                            <asp:HiddenField ID="hdnDepartmentName" runat="server" />
                            <asp:HiddenField ID="hdnDesignation" runat="server" />
                            <asp:HiddenField ID="hdnJoiningDate" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divReportViewer" runat="server" style="border: 3 solid red inherit">
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                    InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
                    Width="100%" Height="100%">
                </rsweb:ReportViewer>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

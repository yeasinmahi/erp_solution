<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HRResignStatus.aspx.cs" Inherits="UI.HR.Settlement.HRResignStatus" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
<link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    <script>
        $(document).ready(function () {
            SearchText();
        });
        function Changed() {
            document.getElementById('hdfSearchBoxTextChange').value = 'true';
        }
        function SearchText() {
            $("#txtEmployeeSearch").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;",
                        url: "HRResignStatus.aspx/GetAutoCompleteData",
                        data: "{'strSearchKey':'" + document.getElementById('txtEmployeeSearch').value + "'}",
                        dataType: "json",
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (result) {
                            //alert("Error");
                        }
                    });
                }
            });
        }
</script>
    
</head>
<body>
    <form id="frminformation" runat="server">
   <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
    <div id="divcontentholder">
    <table class="tbldecoration" style="width:auto; float:left;">
    <tr class="tblheader"><td colspan="4"> HR Resign Status :</td></tr>
         
       <%--<tr class="tblroweven"> 
        <td style="text-align:right;"><asp:Label ID="lblUnitList" CssClass="lbl" runat="server" Text="Unit Name : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlUnitList" runat="server" CssClass="ddList" AutoPostBack="True" DataSourceID="odsUnitForLogin" DataTextField="strUnit" DataValueField="intUnitID" ></asp:DropDownList>            
            <asp:ObjectDataSource ID="odsUnitForLogin" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetUnitListForSeparation" TypeName="HR_BLL.Settlement.GlobalClass">
                <SelectParameters>
                    <asp:SessionParameter Name="intEnroll" SessionField="sesUserID" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td> 

            <td style="text-align:right;"><asp:Label ID="lblJobStationList" CssClass="lbl" runat="server" Text="Job Station Name : "></asp:Label></td>
            <td><asp:DropDownList ID="ddlJobStationList" runat="server" CssClass="ddList" AutoPostBack="True" DataSourceID="odsJobStation" DataTextField="strJobStationName" DataValueField="intEmployeeJobStationId"></asp:DropDownList>
                <asp:ObjectDataSource ID="odsJobStation" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetJobStationList" TypeName="HR_BLL.Settlement.HRClass">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlUnitList" Name="intUnitID" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>  
        </tr> --%>

       <tr class="tblroweven">    
            <td style="text-align:right;">
            <asp:Label ID="lblEmployeeSearch" CssClass="lbl" runat="server" Text="Employee-Search : "></asp:Label>
            <asp:HiddenField ID="hdnstation" runat="server" /><asp:HiddenField ID="hdnenroll" runat="server" />
            </td>
            <td><asp:TextBox ID="txtEmployeeSearch" runat="server" CssClass="txtBox" AutoPostBack="true" onchange="javascript: Changed();"></asp:TextBox>
            <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" /></td>
           
            <%--<td style="text-align:right;"><asp:Label ID="lblRefNo" CssClass="lbl" runat="server" Text="Ref No. : "></asp:Label></td>
            <td><asp:TextBox ID="txtRefNo" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox></td>--%>
        </tr>      
                        
    </table>
    </div>

     <asp:Panel ID="pnlhrresignstatus1" runat="server"><%# strhrresignstatus1 %></asp:Panel><br /> 
     <asp:Panel ID="pnlhrresignstatus2" runat="server"><%# strhrresignstatus2 %></asp:Panel><br /> 
   <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dispatch.aspx.cs" Inherits="UI.HR.Dispatch.Dispatch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Dispatch Register </title>
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
    <script src="../Content/JS/CustomizeScript.js"></script>

    <script>    
    function DispatchSubmit() {
        document.getElementById("hdnconfirm").value = "0";
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
        if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "3"; }
        else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
        __doPostBack();        
    }
    </script>

</head>
<body>
    <form id="frmdispatch" runat="server">        
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
        <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
        <div class="leaveApplication_container">        
        <table class="tbldecoration" style="width:auto; float:left;">
        <tr class="tblheader"><td colspan="4" style="color:green; text-align:center; font-size:18px"> Register of Letter Dispatched </td></tr>
            
        <tr>
        <td style="text-align:right;"><asp:Label ID="lblDate" runat="server" CssClass="lbl" Text="Date:"></asp:Label></td>
        <td style="text-align:left;"><asp:TextBox ID="txtDate" runat="server" ReadOnly="true" CssClass="txtBox" Width="210px"></asp:TextBox></td> 

        <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Upload:"></asp:Label></td>
        <td style='text-align: left;'><asp:FileUpload ID="txtDocUpload" runat="server" CssClass="txtBox" Width="210px"/></td>        
        </tr>
            
        <tr>                
        <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Unit:"></asp:Label></td>
        <td style="text-align:left;"><asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="True" DataSourceID="odsunt" DataTextField="strUnit" DataValueField="intUnitID"></asp:DropDownList>
        <asp:ObjectDataSource ID="odsunt" runat="server" SelectMethod="GetUnitListForTransport" TypeName="SAD_BLL.Transport.InternalTransportBLL">
        <SelectParameters><asp:SessionParameter Name="Enroll" SessionField="sesUserID" Type="Int32" /></SelectParameters> </asp:ObjectDataSource>
        </td>

        <td style="text-align:right;"><asp:Label ID="lblJobStation" runat="server" CssClass="lbl" Text="Job Station:"></asp:Label></td>
        <td style="text-align:left;"><asp:DropDownList ID="ddlJobStation" CssClass="ddList" Font-Bold="False" runat="server" DataSourceID="odsstation" DataTextField="strJobStationName" DataValueField="intEmployeeJobStationId"></asp:DropDownList>
        <asp:ObjectDataSource ID="odsstation" runat="server" SelectMethod="GetJobStation" TypeName="HR_BLL.Dispatch.DispatchBLL">
        <SelectParameters><asp:ControlParameter ControlID="ddlUnit" Name="intUnitID" PropertyName="SelectedValue" Type="Int32" /></SelectParameters></asp:ObjectDataSource>
        </td>                                                                        
        </tr>             
        <tr class="tblheader"><td colspan="4"> To whom Dispatched (Name & Address) : </td></tr>
        <tr class="tblroweven">
        <td colspan="4" style="text-align:left;"><asp:TextBox ID="txtNameAndAddress" runat="server" CssClass="txtBox" Width="535px" TextMode="MultiLine" Height="60"></asp:TextBox></td> 
        </tr>
        <tr class="tblheader"><td colspan="4"> Subject : </td></tr>
        <tr class="tblroweven">
        <td colspan="4" style="text-align:left;"><asp:TextBox ID="txtSubject" runat="server" CssClass="txtBox" Width="535px" TextMode="MultiLine" Height="60"></asp:TextBox></td> 
        </tr>
        <tr class="tblheader"><td colspan="4"> Remarks : </td></tr>
        <tr class="tblroweven">
        <td colspan="4" style="text-align:left;"><asp:TextBox ID="txtRemarks" runat="server" CssClass="txtBox" Width="535px" TextMode="MultiLine" Height="60"></asp:TextBox></td> 
        </tr>         
        <tr class="tblroweven">
        <td colspan="4"><asp:Button ID="btnSubmit" runat="server" CssClass="nextclick" OnClientClick="DispatchSubmit()" Text="Submit"/></td>        
        </tr>        
        </table>            
        </div>
                
    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
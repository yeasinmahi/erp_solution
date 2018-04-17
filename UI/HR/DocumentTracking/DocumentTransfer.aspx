<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentTransfer.aspx.cs" Inherits="UI.HR.DocumentTracking.DocumentTransfer" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
 <html xmlns="http://www.w3.org/1999/xhtml">   
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
      <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
       
    <script>
        function Save() {
            document.getElementById("hdnField").value = "1";
            __doPostBack();
        }

</script>

    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .ddList {}
        .txtBox {}
     </style>
</head>

<body>
    <form id="frmaccountsrealize" runat="server">
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
    <div class="leaveApplication_container">
    <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnCheck" runat="server" />
    <asp:HiddenField ID="hdnconfirm" runat="server" />
       
    <div class="tabs_container" align="Center" >Document Transfer</div>
   
       <table  >
            <tr>
               <td style="text-align:right;" > <asp:Label ID="lblQRCode" runat="server" CssClass="lbl" font-size="small" Text="Scan QR Code:"></asp:Label></td>
               <td style="text-align:left;"><asp:TextBox ID="txtQRCode" runat="server" CssClass="txtBox"></asp:TextBox></td>                    
               <td style="text-align:right;"><asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
            </tr>
            
           
        </table>

        <table>
             <tr><td colspan="5"><hr /></td></tr>
             <tr>
                 <td style="text-align:right;"><asp:Label ID="lblFUnit" runat="server" CssClas="lbl" Text="Unit Name:"></asp:Label></td>
                 <td style="text-align:left;"><asp:TextBox ID="txtFUnitName" runat="server" CssClass="txtBox"></asp:TextBox></td>
                 <td style="text-align:center;"><asp:Label ID="lblTransferTo" runat="server" CssClass="lbl" Text="Transfer To =>"></asp:Label></td>
                 <td style="text-align:right;"><asp:Label ID="lblTUnit" runat="server" CssClas="lbl" Text="Unit Name:"></asp:Label></td>
                 <td style="text-align:left;"><asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="True" DataSourceID="odsunt" DataTextField="strUnit" DataValueField="intUnitID"></asp:DropDownList>
                     <asp:ObjectDataSource ID="odsunt" runat="server" SelectMethod="GetUnitListForTransport" TypeName="SAD_BLL.Transport.InternalTransportBLL">
                    <SelectParameters><asp:SessionParameter Name="Enroll" SessionField="sesUserID" Type="Int32" /></SelectParameters> </asp:ObjectDataSource>
                 </td>
             </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="lblFJobStation" runat="server" CssClas="lbl" Text="Job Station Name:"></asp:Label></td>
                 <td style="text-align:left;"><asp:TextBox ID="txtFJobStation" runat="server" CssClass="txtBox"></asp:TextBox></td>
                <td></td>
                <td style="text-align:right;"><asp:Label ID="lblTJobStation" runat="server" CssClas="lbl" Text="Job Station Name:"></asp:Label></td>
                 <td style="text-align:left;"><asp:DropDownList ID="ddlJobStation" CssClass="ddList" Font-Bold="False" runat="server" DataSourceID="odsstation" DataTextField="strJobStationName" DataValueField="intEmployeeJobStationId"></asp:DropDownList>
                <asp:ObjectDataSource ID="odsstation" runat="server" SelectMethod="GetJobStation" TypeName="HR_BLL.Dispatch.DispatchBLL">
                <SelectParameters><asp:ControlParameter ControlID="ddlUnit" Name="intUnitID" PropertyName="SelectedValue" Type="Int32" /></SelectParameters></asp:ObjectDataSource>
                </td>     
            </tr>

           <tr>
                 <td style="text-align:right;"><asp:Label ID="lblFDivision" runat="server" CssClas="lbl" Text="Division:"></asp:Label></td>
                 <td style="text-align:left;"><asp:TextBox ID="txtFDivision" runat="server" CssClass="txtBox"></asp:TextBox></td>
               <td></td>
                 <td style="text-align:right;"><asp:Label ID="lblTDivision" runat="server" CssClas="lbl" Text="Division:"></asp:Label></td>
                 <td style="text-align:left;"><asp:DropDownList ID="ddlDivision" runat="server" CssClass="ddList"></asp:DropDownList></td>
             </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="lblFDepartment" runat="server" CssClas="lbl" Text="Department:"></asp:Label></td>
                 <td style="text-align:left;"><asp:TextBox ID="txtFDepartment" runat="server" CssClass="txtBox"></asp:TextBox></td>
                <td></td>
                <td style="text-align:right;"><asp:Label ID="lblTDepartment" runat="server" CssClas="lbl" Text="Department:"></asp:Label></td>
                 <td style="text-align:left;"><asp:DropDownList ID="ddlDepartment" runat="server" CssClass="ddList"></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="lblFSection" runat="server" CssClas="lbl" Text="Section:"></asp:Label></td>
                 <td style="text-align:left;"><asp:TextBox ID="txtFSection" runat="server" CssClass="txtBox"></asp:TextBox></td>
                <td></td>
                <td style="text-align:right;"><asp:Label ID="lblSection" runat="server" CssClas="lbl" Text="Section:"></asp:Label></td>
                 <td style="text-align:left;"><asp:DropDownList ID="ddlSection" runat="server" CssClass="ddList"></asp:DropDownList></td>
            </tr>

           <tr>
                 <td style="text-align:right;"><asp:Label ID="lblFLocation" runat="server" CssClas="lbl" Text="Location Name:"></asp:Label></td>
                 <td style="text-align:left;"><asp:TextBox ID="txtFLocation" runat="server" CssClass="txtBox"></asp:TextBox></td>
               <td></td>
                 <td style="text-align:right;"><asp:Label ID="lblTLocation" runat="server" CssClas="lbl" Text="Location Name:"></asp:Label></td>
                 <td style="text-align:left;"><asp:DropDownList ID="ddlLocation" runat="server" CssClass="ddList"></asp:DropDownList></td>
             </tr>
           
           <tr>
                 <td style="text-align:right;"><asp:Label ID="lblFFolder" runat="server" CssClas="lbl" Text="Folder Name:"></asp:Label></td>
                 <td style="text-align:left;"><asp:TextBox ID="txtFFolder" runat="server" CssClass="txtBox"></asp:TextBox></td>
               <td></td>
                 <td style="text-align:right;"><asp:Label ID="lblTFolder" runat="server" CssClas="lbl" Text="Folder Name:"></asp:Label></td>
                 <td style="text-align:left;"><asp:DropDownList ID="ddlFolder" runat="server" CssClass="ddList"></asp:DropDownList></td>
             </tr>
           <tr>
                 <td style="text-align:right;"><asp:Label ID="lblFDocInfo" runat="server" CssClas="lbl" Text="Document Info:"></asp:Label></td>
                 <td style="text-align:left;"><asp:TextBox ID="txtFDocInfo" runat="server" CssClass="txtBox"></asp:TextBox></td>
               <td></td>
                 <td style="text-align:right;"><asp:Label ID="lblTDocInfo" runat="server" CssClas="lbl" Text="Document Info:"></asp:Label></td>
                 <td style="text-align:left;"><asp:TextBox ID="txtTDocInfo" runat="server" CssClass="txtBox"></asp:TextBox></td>
             </tr>
           
           <tr >
               <td style="text-align:left" colspan="1"></td>
               <td style="text-align:left" colspan="1"></td>
               <td style="text-align:right" colspan="3" ><asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" /> </td>
             </tr>
           
           </table>


        <table>
          

        </table>
          
        
            
        </div>
         
            
<%--=========================================End My Code From Here=================================================--%>
      
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>


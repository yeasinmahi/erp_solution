<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocRegistration.aspx.cs" Inherits="UI.HR.DocumentTracking.DocRegistration" %>

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

<script>
    function FTPUpload() {
        document.getElementById("hdnconfirm").value = "2";
        __doPostBack();
    }
    function FTPUpload1() {
        document.getElementById("hdnconfirm").value = "0";
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
        if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "3"; }
        else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
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
    <asp:HiddenField ID="hdnEnrollUnit" runat="server" /><asp:HiddenField ID="hdnCheck" runat="server" />
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" />
    <div class="tabs_container" align="Center" >New Document Registration</div>
   
       <table  >
         <tr  >
                  
           <td style="text-align:right;" > <asp:Label ID="lblDocType" runat="server" CssClass="lbl" font-size="small" Text="Document Type:"></asp:Label></td>
              <%--<td style="text-align: left;"><asp:DropDownList ID="ddlLocation" runat="server" CssClass="ddList" Font-Bold="True"  >
               </asp:DropDownList></td>--%>
           <td style="text-align:left;"><asp:DropDownList ID="ddlDocType" runat="server" CssClass="ddList"></asp:DropDownList></td>                    
                      
           <td style="text-align:right;"> <asp:Label ID="Label1" font-size="small" runat="server" CssClass="lbl" Text="Document Validity:"></asp:Label></td>
           <td style="text-align:left;"><asp:CheckBox ID="chkValidity" runat="server" AutoPostBack="true" Text=" Not Necessary" OnCheckedChanged="chkValidity_CheckedChanged" /></td>
         </tr>

           <tr >
               <td style="text-align:right;"><asp:Label ID="lblFromDate" runat="server" Text="Valid From:"></asp:Label></td>
              <td class="auto-style1">
                <asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="dtpFromDate" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender>
             </td>
               <td style="text-align:right;"><asp:Label ID="lblToDate" runat="server" Text="Valid To:"></asp:Label></td>
               <td class="auto-style1">
                <asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender>
             </td>
             </tr>
            
            <tr><td colspan="4"><hr /></td></tr>
             <%--<tr>
                 <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClas="lbl" Text="Unit Name:"></asp:Label></td>
                 <td style="text-align:left;"><asp:DropDownList ID="ddlUnit" runat="server" CssClass="ddList"></asp:DropDownList></td>
                 <td style="text-align:right;"><asp:Label ID="lblJobStation" runat="server" CssClas="lbl" Text="Job Station Name:"></asp:Label></td>
                 <td style="text-align:left;"><asp:DropDownList ID="ddlJobStation" runat="server" CssClass="ddList"></asp:DropDownList></td>
             </tr>--%>

           <tr>
         <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Unit:"></asp:Label></td>
        <td style="text-align:left;"><asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="True" DataSourceID="odsunt" DataTextField="strUnit" DataValueField="intUnitID"></asp:DropDownList>
        <asp:ObjectDataSource ID="odsunt" runat="server" SelectMethod="GetUnitListForTransport" TypeName="SAD_BLL.Transport.InternalTransportBLL">
        <SelectParameters><asp:SessionParameter Name="Enroll" SessionField="sesUserID" Type="Int32" /></SelectParameters> </asp:ObjectDataSource>
        </td>

                 <td style="text-align:right;"><asp:Label ID="lblDivision" runat="server" CssClas="lbl" Text="Division:"></asp:Label></td>
                 <td style="text-align:left;"><asp:DropDownList ID="ddlDivision" runat="server" AutoPostBack="true" CssClass="ddList" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged"></asp:DropDownList></td>
                 
             </tr>

           <tr>
               <td style="text-align:right;"><asp:Label ID="lblJobStation" runat="server" CssClass="lbl" Text="Job Station:"></asp:Label></td>
                <td style="text-align:left;"><asp:DropDownList ID="ddlJobStation" CssClass="ddList" Font-Bold="False" runat="server" DataSourceID="odsstation" DataTextField="strJobStationName" DataValueField="intEmployeeJobStationId"></asp:DropDownList>
                <asp:ObjectDataSource ID="odsstation" runat="server" SelectMethod="GetJobStation" TypeName="HR_BLL.Dispatch.DispatchBLL">
                <SelectParameters><asp:ControlParameter ControlID="ddlUnit" Name="intUnitID" PropertyName="SelectedValue" Type="Int32" /></SelectParameters></asp:ObjectDataSource>
                </td>     

                <td style="text-align:right;"><asp:Label ID="lblDepartment" runat="server" CssClas="lbl" Text="Department:"></asp:Label></td>
                 <td style="text-align:left;"><asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="true" CssClass="ddList" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged"></asp:DropDownList></td>
                                
             </tr>
           <tr>
               <td style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClas="lbl" Text=""></asp:Label></td>
                 <td style="text-align:right;"><asp:Label ID="Label3" runat="server" CssClas="lbl" Text=""></asp:Label></td>

               <td style="text-align:right;"><asp:Label ID="lblSection" runat="server" CssClas="lbl" Text="Section:"></asp:Label></td>
                 <td style="text-align:left;"><asp:DropDownList ID="ddlSection" runat="server" CssClass="ddList"></asp:DropDownList></td>
           </tr>
           <tr><td colspan="4"><hr /></td></tr>
           <tr>
                 <td style="text-align:right;"><asp:Label ID="lblLocation" runat="server" CssClas="lbl" Text="Location:"></asp:Label></td>
                 <td style="text-align:left;"><asp:DropDownList ID="ddlLocation" runat="server" CssClass="ddList" AutoPostBack="true" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged"></asp:DropDownList></td>
                 <td style="text-align:right;"><asp:Label ID="lblFolder" runat="server" CssClas="lbl" Text="Folder Name:"></asp:Label></td>
                 <td style="text-align:left;"><asp:DropDownList ID="ddlFolder" runat="server" CssClass="ddList"></asp:DropDownList></td>
             </tr>
           <tr>
                 <td style="text-align:right;"><asp:Label ID="lblDocCode" runat="server" CssClas="lbl" Text="Document Code:"></asp:Label></td>
                 <td style="text-align:left;"><asp:TextBox ID="txtDocCode" runat="server" CssClass="txtBox"></asp:TextBox></td>
                 
                <td style="text-align:right;"><asp:Label ID="lblDocInfo" runat="server" CssClas="lbl" Text="Document Info:"></asp:Label></td>
                 <td style="text-align:left"><asp:TextBox ID="txtDocInfo" runat="server" CssClass="txtBox" Width="100%"></asp:TextBox></td>
             </tr>

          
           <tr><td colspan="4"><hr /></td></tr>
           <tr class="tblrowodd">          
           
            <td style='text-align: right; width:120px;'>Document Upload : </td>
            <td style='text-align: center;'>
                <asp:FileUpload ID="txtDocUpload" runat="server" AllowMultiple="true"/>                
            </td>          
            <td style="text-align:right;"> 
            <a class="nextclick" onclick="FTPUpload()">Add</a> </td>
        </tr>    
        <tr><td colspan="4"> 
            <asp:GridView ID="dgvDocUp" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgvDocUp_RowDeleting1">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
                    
            <asp:TemplateField HeaderText="File Name" SortExpression="strFileName"><ItemTemplate>            
            <asp:Label ID="lblFileName" runat="server" Text='<%# Bind("strFileName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="530px"/></asp:TemplateField>
                        
            <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" /> 

            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
        </tr> 

           <tr>
               <td colspan="4"><asp:Button ID="btnSubmit" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Generate" OnClientClick="FTPUpload1()"/></td>                        
           </tr>

           <%--<tr >
               <td style="text-align:left" colspan="1"></td>
               <td style="text-align:left" colspan="1"></td>
               <td style="text-align:right" colspan="2" ><asp:Button ID="btnUpload" runat="server" Text="File Upload" /> </td>
             </tr>
           <tr >
               <td style="text-align:left" colspan="1"></td>
               <td style="text-align:left" colspan="1"></td>
               <td style="text-align:right" colspan="2" ><asp:Button ID="btnGenerate" runat="server" Text="File Generate" /> </td>
             </tr>--%>

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


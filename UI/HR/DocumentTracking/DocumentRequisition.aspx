<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentRequisition.aspx.cs" Inherits="UI.HR.DocumentTracking.DocumentRequisition" %>

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
       
    <div class="tabs_container" align="Center" >Document Requisition</div>
   
       <table>
           <tr >                  
               <td style="text-align:right;"> <asp:Label ID="lblSearchBy" runat="server" CssClass="lbl" font-size="small" Text="Search By:"></asp:Label></td>
               <td style="text-align:left;"><asp:DropDownList ID="ddlSearchType" runat="server" CssClass="ddList"><asp:ListItem Selected="True" Value ="1">QR Code</asp:ListItem>
                <asp:ListItem Value="2">Document Code</asp:ListItem><asp:ListItem Value="3">Document Type</asp:ListItem></asp:DropDownList></td>                    
           </tr>

           <tr>                 
               <td style="text-align:right;"> <asp:Label ID="lblSearch" runat="server" CssClass="lbl" font-size="small" Text="Search Document:"></asp:Label></td>
               <td style="text-align:left;"><asp:TextBox ID="txtSearch" runat="server" CssClass="txtBox"></asp:TextBox></td>
               <td style="text-align:right;"> <asp:Label ID="lblPeriod" font-size="small" runat="server" CssClass="lbl" Text="Inclue Date:"></asp:Label></td>
               <td style="text-align:left;"><asp:CheckBox ID="chkDate" runat="server" AutoPostBack="true" Text=" Yes" OnCheckedChanged="chkDate_CheckedChanged" /></td>
            </tr>

           <tr >
               <td style="text-align:right;"><asp:Label ID="lblFromDate" runat="server" Text="From Date:"></asp:Label></td>
               <td class="auto-style1">
                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox"></asp:TextBox>
                    <cc1:CalendarExtender ID="dtpFromDate" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender>
                </td>
               <td style="text-align:right;"><asp:Label ID="lblToDate" runat="server" Text="To Date:"></asp:Label></td>
               <td class="auto-style1">
                    <asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender>
             </td>
             </tr>

            <tr>
                <td style="text-align:right;"><asp:Label ID="lblReturnable" runat="server" CssClass="lbl" Text="Doc. Returnable:"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlReturnable" runat="server" CssClass="ddList">
                    <asp:ListItem Selected="True" Value="1">Yes</asp:ListItem><asp:ListItem Value="2">No</asp:ListItem></asp:DropDownList>
                </td>
                <td style="text-align:right;"><asp:Label ID="lblRequre" runat="server" CssClass="lbl" Text="Requred Doc.:"></asp:Label></td>
                <td><asp:DropDownList ID="ddlRequire" runat="server" CssClass="ddList">
                    <asp:ListItem Selected="True" Value="1">Soft Copy</asp:ListItem><asp:ListItem Value="2">Hard Copy</asp:ListItem><asp:ListItem Value="3">View</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="lblReqTime" runat="server" CssClass="lbl" Text="Required Time:"></asp:Label></td>
                <td class="auto-style1">
                <asp:TextBox ID="txtReqDate" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="dtpReqDate" runat="server" Format="yyyy-MM-dd" TargetControlID="txtReqDate"></cc1:CalendarExtender>
                </td>
               <td style="text-align:right" colspan="2"><asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
            </tr>
           
        </table>


        <table>
              <tr>
                   <td>
                       <asp:GridView ID="dgvDocReq" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
                        BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical">
                        <AlternatingRowStyle BackColor="#CCCCCC" />

                        <Columns>

                        <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              

                        <asp:TemplateField HeaderText="Doc Reg ID" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="intDocRegID" >
                        <ItemTemplate><asp:Label ID="lblDocID" runat="server" DataFormatString="{0:0.00}" Text='<%# (""+Eval("intDocRegID")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                    
                        <asp:TemplateField HeaderText="Code" SortExpression="strDocumentCode"><ItemTemplate>            
                        <asp:Label ID="lblCode" runat="server" Text='<%# Bind("strDocumentCode") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left"/></asp:TemplateField>

                        <asp:TemplateField HeaderText="Unit Name" SortExpression="strUnit"><ItemTemplate>            
                        <asp:Label ID="lblUnitName" runat="server" Text='<%# Bind("strUnit") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left"/></asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Job Station" SortExpression="strJobStationName"><ItemTemplate>            
                        <asp:Label ID="lblJobStation" runat="server" Text='<%# Bind("strJobStationName") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left"/></asp:TemplateField>

                        <asp:TemplateField HeaderText="Division" SortExpression="strDivision"><ItemTemplate>            
                        <asp:Label ID="lblDivision" runat="server" Text='<%# Bind("strDivision") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left"/></asp:TemplateField>

                        <asp:TemplateField HeaderText="Department" SortExpression="strDepartment"><ItemTemplate>            
                        <asp:Label ID="lblDepartment" runat="server" Text='<%# Bind("strDepartment") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left"/></asp:TemplateField>

                        <asp:TemplateField HeaderText="Section" SortExpression="strSection"><ItemTemplate>            
                        <asp:Label ID="lblSection" runat="server" Text='<%# Bind("strSection") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left"/></asp:TemplateField>

                        <asp:TemplateField HeaderText="Document Type" SortExpression="TypeName"><ItemTemplate>            
                        <asp:Label ID="lblDocType" runat="server" Text='<%# Bind("TypeName") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left"/></asp:TemplateField>

                        <asp:TemplateField HeaderText="Location" SortExpression="strLocation"><ItemTemplate>            
                        <asp:Label ID="lblLocation" runat="server" Text='<%# Bind("strLocation") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left"/></asp:TemplateField>

                        <asp:TemplateField HeaderText="Folder Name" SortExpression="strFolder"><ItemTemplate>            
                        <asp:Label ID="lblFolder" runat="server" Text='<%# Bind("strFolder") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left"/></asp:TemplateField>

                        <asp:TemplateField HeaderText="Document Info." SortExpression="strDocumentInfo"><ItemTemplate>            
                        <asp:Label ID="lblDocInfo" runat="server" Text='<%# Bind("strDocumentInfo") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left"/></asp:TemplateField>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Submit" >
                        <ItemTemplate><asp:Button ID="btnSubmit" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" 
                        CommandArgument='<%# Eval("intDocRegID") %>'    Text="Submit" OnClick="btnSubmit_Click"/>
                        </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>
                        

                        </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        </asp:GridView>
                   </td>
               </tr>

        </table>
          
        
            
        </div>
         
            
<%--=========================================End My Code From Here=================================================--%>
      
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>


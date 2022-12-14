<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentReport.aspx.cs" Inherits="UI.HR.DocumentTracking.DocumentReport" %>

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
       
    <div class="tabs_container" align="Center" >Document Reports</div>
        <table>
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

            <tr>
                    <td style="text-align:right;" colspan="2"><asp:Button ID="btnPendingReport" runat="server" Text="Pending List" Width="210px" OnClick="btnPendingReport_Click" /></td>
                    <td style="text-align:left;" colspan="2"><asp:Button ID="bltAllReport" runat="server" Text="All List" Width="210px" OnClick="bltAllReport_Click" /></td>
            </tr>

        </table>
        <table>
              <tr>
                   <td>
                       <asp:GridView ID="dgvDocPending" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
                        BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical">
                        <AlternatingRowStyle BackColor="#CCCCCC" />

                        <Columns>

                        <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              

                        <asp:TemplateField HeaderText="ID" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="intID" >
                        <ItemTemplate><asp:Label ID="lblID" runat="server" DataFormatString="{0:0.00}" Text='<%# (""+Eval("intID")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                    
                        <asp:TemplateField HeaderText="Code" SortExpression="strDocumentCode"><ItemTemplate>            
                        <asp:Label ID="lblCode" runat="server" Text='<%# Bind("strDocumentCode") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left"/></asp:TemplateField>

                        <asp:TemplateField HeaderText="Retrurn Date" SortExpression="dteReturnDate"><ItemTemplate>            
                        <asp:Label ID="lblReturnDate" runat="server" Text='<%# Eval("dteReturnDate", "{0:dd-MM-yyyy}") %>'></asp:Label></ItemTemplate>
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

                        <asp:TemplateField HeaderText="Required By" SortExpression="strRequiredBy"><ItemTemplate>            
                        <asp:Label ID="lblRequiredBy" runat="server" Text='<%# Bind("strRequiredBy") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left"/></asp:TemplateField>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Reminder" >
                        <ItemTemplate><asp:Button ID="btnReminder" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" 
                        CommandArgument='<%# Eval("intID") %>'    Text="Reminder" OnClick="btnReminder_Click"/>
                        </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>

                        </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        </asp:GridView>
                   </td>
               </tr>

        </table>
        <table>
              <tr>
                   <td>
                       <asp:GridView ID="dgvAllReport" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
                        BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical">
                        <AlternatingRowStyle BackColor="#CCCCCC" />

                        <Columns>

                        <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              

                        <asp:TemplateField HeaderText="ID" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="intID" >
                        <ItemTemplate><asp:Label ID="lblID" runat="server" DataFormatString="{0:0.00}" Text='<%# (""+Eval("intID")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                    
                        <asp:TemplateField HeaderText="Code" SortExpression="strDocumentCode"><ItemTemplate>            
                        <asp:Label ID="lblCode" runat="server" Text='<%# Bind("strDocumentCode") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left"/></asp:TemplateField>

                        <asp:TemplateField HeaderText="Retrurn Date" SortExpression="dteReturnDate"><ItemTemplate>            
                        <asp:Label ID="lblReturnDate" runat="server" Text='<%# Eval("dteReturnDate", "{0:dd-MM-yyyy}") %>'></asp:Label></ItemTemplate>
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

                        <asp:TemplateField HeaderText="Required By" SortExpression="strRequiredBy"><ItemTemplate>            
                        <asp:Label ID="lblRequiredBy" runat="server" Text='<%# Bind("strRequiredBy") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left"/></asp:TemplateField>

                        <asp:TemplateField HeaderText="Return Back" SortExpression="ysnReturnBack"><ItemTemplate>            
                        <asp:Label ID="lblReturnBack" runat="server" Text='<%# Bind("ysnReturnBack") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left"/></asp:TemplateField>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Reminder" >
                        <ItemTemplate><asp:Button ID="btnReminder" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" 
                        CommandArgument='<%# Eval("intID") %>'    Text="Reminder" OnClick="btnReminder_Click"/>
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
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoteTADAApproveBySupervisorV2.aspx.cs" Inherits="UI.SAD.Order.RemoteTADAApproveBySupervisorV2" %>



<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../../../Content/CSS/GridHEADER.css" rel="stylesheet" />
    <script src="../../../../Content/JS/JQUERY/jquery-1.10.2.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/jquery-ui.min.js"></script>
    <script src="../../../../Content/JS/datepickr.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/MigrateJS.js"></script>
    <script src="../../../../Content/JS/JQUERY/GridviewScroll.min.js"></script>

     <script type="text/javascript">
         $(document).ready(function () {
             GridviewScroll();
         });
         function GridviewScroll() {

             $('#<%=grdvForTADAApproveBYimmediateSupervisorV2.ClientID%>').gridviewScroll({
                 width: 725,
                 height: 340,
                 startHorizontal: 0,
                 wheelstep: 10,
                 barhovercolor: "#3399FF",
                 barcolor: "#3399FF"
             });
         }
   
     function Registration(url) {
          window.open('TADAAprvSingleEmployeeByImsSuperv.aspx?ID=' + url, '', "height=600, width=1350, scrollbars=yes, left=50, top=100, resizable=yes, title=Preview");
                  }
</script>


    










</head>
<body>
    <form id="frmpdv" runat="server">
 <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>

<%--=========================================Start My Code From Here===============================================--%>

           <div class="leaveApplication_container"> 
    <div class="tabs_container">  TA - DA information Approve by Immediate Supervisor (Both Category user)  :<asp:HiddenField ID="hdnAreamanagerEnrol" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
        
        <asp:HiddenField ID="HiddenUnit" runat="server"/><asp:HiddenField ID="hdnData" runat="server"/>
       
        <hr /></div>
        <table border="0"; style="width:Auto"; >    


        <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
        <td colspan="2"><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtToDate', { 'dateFormat': 'Y-m-d' });</script></td>          
        </tr>
         <tr>
    <td colspan="3" style="text-align:right"><asp:Label ID="lblReportType" CssClass="lbl" runat="server" Text="Report Type:  "></asp:Label></td>
    <td>
    <asp:DropDownList ID="drdlReportType" CssClass="ddList" runat="server" DataSourceID="odsRptType" DataTextField="strReportType" DataValueField="intID"></asp:DropDownList>
    <asp:ObjectDataSource ID="odsRptType" runat="server" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="taRemoteTaDaReportType" TypeName="SAD_DAL.Customer.Report.StatementTDSTableAdapters.tblRemoteTADAReportTypeTableAdapter">
    <InsertParameters>
    <asp:Parameter Name="strReportType" Type="String" />
    </InsertParameters>
    </asp:ObjectDataSource>
    </td>
   
    </tr>
    <tr class="tblrowOdd">
        <td colspan="3"> <asp:Button ID="btnShow" runat="server" Text="Show Bill Info" Width="100px" OnClick="btnShow_Click" /></td> 
   
    
    </tr>


</table>               
</div>
        
        <div class="leaveApplication_container">
              <table>        
          <tr class="tblroweven"><td colspan="4">
              </td>
         </tr>          
                   <tr class="tblrowodd">
                <td>
                  

                    <asp:GridView ID="grdvForTADAApproveBYimmediateSupervisorV2" runat="server" AutoGenerateColumns="False" AllowPaging="false"  BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdvForTADAApproveBYimmediateSupervisorV2_PageIndexChanging" OnRowDataBound="grdvForTADAApproveBYimmediateSupervisorV2_RowDataBound">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>

                   

                         <asp:BoundField DataField="Si" HeaderText="Sl" SortExpression="Si" />
                   <asp:BoundField DataField="strEmplName" HeaderText="Employee Name " SortExpression="strEmplName" />
                    <asp:BoundField DataField="intEmployeeid" HeaderText="Enrol" SortExpression="intEmployeeid" />
                  <asp:BoundField DataField="LMAudit" HeaderText="LM Audit" SortExpression="LMAudit" />
                     <asp:BoundField DataField="CMApplicant" HeaderText="CM Applicant" SortExpression="CMApplicant" />
                   <asp:BoundField DataField="decCMSupervisor" HeaderText="CM Supervisor" SortExpression="decCMSupervisor" />
                   <asp:BoundField DataField="strJobstation" HeaderText="Job Station" SortExpression="strJobstation" />
                  <asp:BoundField DataField="strunit" HeaderText="Unit" SortExpression="strunit" />
                  

                         <asp:TemplateField HeaderText="Det.">
             <ItemTemplate>
             <asp:Button ID="Complete" runat="server" Text="Deaills" class="button" CommandName="complete" OnClick="Complete_Click"   CommandArgument='<%# Eval("intEmployeeid") %>' /></ItemTemplate>
             </asp:TemplateField>  


     
                            </Columns>
                            <FooterStyle BackColor="Tan" />
                            <HeaderStyle BackColor="Tan" Font-Bold="True" />
                            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                            <SortedAscendingCellStyle BackColor="#FAFAE7" />
                            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                            <SortedDescendingCellStyle BackColor="#E1DB9C" />
                            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                         <HeaderStyle CssClass="GridviewScrollHeader" /><PagerStyle CssClass="GridviewScrollPager" />
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
            
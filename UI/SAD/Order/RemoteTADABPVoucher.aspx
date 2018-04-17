<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoteTADABPVoucher.aspx.cs" Inherits="UI.SAD.Order.RemoteTADABPVoucher" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
    <script src="../../../../Content/JS/JQUERY/GridviewScroll.min.js"></script>    <script type="text/javascript">


        function ConfirmAll() {
            var txtins = document.getElementById('txtInstrumentDate').value;
            if (txtins == null || txtins == "") {
                alert("Instrument Date must be filled by valid format(yyyy-mm-dd). ");
                    document.getElementById("txtInstrumentDate").focus();
                                                                }
            else{

            document.getElementById("hdnconfirm").value = "0";
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
            else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
        }
            }

     
      </script>

     <script>
         function ViewConfirm(id) { document.getElementById('hdnDivision').style.visibility = 'visible'; }
         function CheckAll(Checkbox) {
             var GridVwHeaderCheckbox = document.getElementById("<%=grdvBPReport.ClientID %>");
        for (i = 1; i < GridVwHeaderCheckbox.rows.length; i++) {
            GridVwHeaderCheckbox.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
        }
    }
       </script>


    </head>
<body>
    <form id="frmpdv" runat="server">
 <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>


<%--=========================================Start My Code From Here===============================================--%>

        <div id="divcontentholder"><asp:HiddenField ID="hdnID" runat="server" /><asp:HiddenField ID="hdnconfirm" runat="server" />
            <asp:HiddenField ID="hdnAreamanagerEnrol" runat="server"/>
            <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/><asp:HiddenField ID="hdnenroll" runat="server" />
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:HiddenField ID="HiddenField2" runat="server" /><asp:HiddenField ID="hdntotalAudit" runat="server"/><asp:HiddenField ID="hdntotalBP" runat="server"/><asp:HiddenField ID="hdnadvancetotal" runat="server"/>
            <asp:HiddenField ID="hdnAdjustableadv" runat="server"/>
            <asp:HiddenField ID="hdnDepartment" runat="server" />
            <table class="tbldecoration" style="width:auto; float:left;">
                        
           <%-- <tr class="tblroweven">
                <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date : "></asp:Label></td>
                <td ><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
                <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>   

                <td style="text-align:right;"><asp:Label ID="lblToDate" CssClass="lbl" runat="server" Text="To Date : "></asp:Label></td>
                <td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
                <script type="text/javascript"> new datepickr('txtToDate', { 'dateFormat': 'Y-m-d' });</script></td>   
            </tr>  --%>
 <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
        <td colspan="2"><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtToDate', { 'dateFormat': 'Y-m-d' });</script></td>          
        </tr>
            <tr class="tblrowOdd"> 
                <td style="text-align:right;"><asp:Label ID="lblInstrumentDate" CssClass="lbl" runat="server" Text="Instrument Date : "></asp:Label></td>
                <td ><asp:TextBox ID="txtInstrumentDate" runat="server" CssClass="txtBox" BackColor="#ffffcc" Enabled="true"></asp:TextBox>
                <script type="text/javascript"> new datepickr('txtInstrumentDate', { 'dateFormat': 'Y-m-d' });</script></td>   
                <td style="text-align:right;"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit Name : "></asp:Label></td>
                <td>
                <asp:DropDownList ID="drdlUnit" runat="server" CssClass="ddList"  AutoPostBack="True" OnSelectedIndexChanged="drdlUnit_SelectedIndexChanged" DataSourceID="odsunitpermissionhr" DataTextField="strUnit" DataValueField="intUnitID"></asp:DropDownList>
                <asp:ObjectDataSource ID="odsunitpermissionhr" runat="server" SelectMethod="getUnitPermission" TypeName="SAD_BLL.Customer.Report.StatementC">
                <SelectParameters>
                <asp:SessionParameter Name="Enrol" SessionField="sesUserID" Type="Int32" />
                </SelectParameters>
                </asp:ObjectDataSource></td>
                                
                
            </tr>
    
                
            <tr class="tblroweven">
                <td style="text-align:right;"><asp:Label ID="lblPaymentFor" CssClass="lbl" runat="server" Text="Payment For : "></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlPaymentFor" runat="server" CssClass="ddList" DataSourceID="odsBankNamelist" DataTextField="strBankName" DataValueField="intID"></asp:DropDownList>
                    <asp:ObjectDataSource ID="odsBankNamelist" runat="server" SelectMethod="BankNameList" TypeName="SAD_BLL.Customer.Report.StatementC"></asp:ObjectDataSource>
                  
                  </td>  
                <td style="text-align:right;"><asp:Label ID="lblReportType" CssClass="lbl" runat="server" Text="Report Type : "></asp:Label></td>
                <td>
                       <asp:DropDownList ID="ddlAccountReportType" runat="server" AutoPostBack="false" CssClass="ddList" DataSourceID="odsAccountReportType" DataTextField="strReportType" DataValueField="intID"></asp:DropDownList>
                       <asp:ObjectDataSource ID="odsAccountReportType" runat="server" SelectMethod="getAccountDeptTADAReportType" TypeName="SAD_BLL.Customer.Report.StatementC"></asp:ObjectDataSource>
                 </td>
                <tr class="tblrowOdd">  
                <td style="text-align:right;"><asp:Label ID="lblTravelandConvey" CssClass="lbl" runat="server" Text="COA Name : "></asp:Label></td>
                <td colspan="3">
                <asp:DropDownList ID="drdlTravelandconvey" runat="server" CssClass="ddList" DataSourceID="odsTravelconveycoalist" DataTextField="strTravelConveyName" DataValueField="intTravlconveyid"></asp:DropDownList>
                    
                    <asp:ObjectDataSource ID="odsTravelconveycoalist" runat="server" SelectMethod="travellingandconvey" TypeName="SAD_BLL.Customer.Report.StatementC">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="drdlUnit" Name="unitid" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                </td>

                
             </tr>
                <tr class="tblrowOdd">
                    <td colspan="3"> <asp:Button ID="btnShow" runat="server" CssClass="button" Text="Show Report" OnClick="btnShow_Click"/></td>
                     <td> <asp:Button ID="btnVoucherCreateallEmployee" runat="server" CssClass="button" Text="Prepare Voucher (All)" OnClientClick="ConfirmAll()" OnClick="btnVoucherCreateallEmployee_Click"/></td>
                </tr>
                 <div class="leaveApplication_container">
                     <table>
          <tr><td> 
               

              
               <asp:GridView ID="grdvBPReport" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdvBPReport_PageIndexChanging" OnRowDataBound="grdvBPReport_RowDataBound">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                <asp:TemplateField><HeaderTemplate>    
                <asp:CheckBox ID="chkbx" runat="server" onclick="CheckAll(this);" />   
                </HeaderTemplate>  
                <ItemTemplate><asp:CheckBox ID="chkbx" runat="server"/></ItemTemplate></asp:TemplateField>

                <asp:BoundField DataField="Si" HeaderText="Sl" SortExpression="Si" ItemStyle-HorizontalAlign="Center" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="strEmplName" HeaderText="Employee Name" SortExpression="strEmplName" ItemStyle-HorizontalAlign="Center" >
                <ItemStyle HorizontalAlign="Center"  />
                </asp:BoundField>
                <asp:BoundField DataField="intEmployeeid" HeaderText="Enrol" SortExpression="intEmployeeid" ItemStyle-HorizontalAlign="Center" >
                <ItemStyle HorizontalAlign="Center"  />
                </asp:BoundField>
             
                <asp:TemplateField HeaderText="CMAudit" SortExpression="CMAudit"><ItemTemplate>
                <asp:Label ID="lblCMAuditt" runat="server" Text='<%# Bind("CMAudit") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="right" Width="60px"/><FooterTemplate><asp:Label ID="lblCMAudit11" runat="server" Text='<%# totalCMAudit %>' /></FooterTemplate></asp:TemplateField>
                <asp:BoundField DataField="strBankAccountNo"  HeaderText="AccountNo." SortExpression="strBankAccountNo" ItemStyle-HorizontalAlign="Center"  >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
               
               <asp:TemplateField HeaderText="Advance Amnt" SortExpression="Advance Amnt"><ItemTemplate>
                <asp:Label ID="lbldecAdvanceAmount" runat="server" Text='<%# Bind("decAdvanceAmount") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="right" Width="60px"/><FooterTemplate><asp:Label ID="lbldecAdvanceAmount" runat="server" Text='<%# totalAdvanceAmount %>' /></FooterTemplate></asp:TemplateField>
                 
                <asp:TemplateField HeaderText="BPAmount" SortExpression="BPAmount"><ItemTemplate>
                <asp:Label ID="lblBPAmount" runat="server" Text='<%# Bind("BPAmount") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="right" Width="60px"/><FooterTemplate><asp:Label ID="lblBPAmount" runat="server" Text='<%# totalBPAmount %>' /></FooterTemplate></asp:TemplateField>
               
                  <asp:TemplateField HeaderText="Adjustable Adv." SortExpression="Adjustable Adv."><ItemTemplate>
                <asp:Label ID="lbldecadjustableadvance" runat="server" Text='<%# Bind("decadjustableadvance") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="right" Width="60px"/><FooterTemplate><asp:Label ID="lbldecadjustableadvance" runat="server" Text='<%# totaldecadjustableadvance %>' /></FooterTemplate></asp:TemplateField>

                          <asp:BoundField DataField="strBankACName" HeaderText="Bank" SortExpression="strBankACName" ItemStyle-HorizontalAlign="Center" >
                <ItemStyle HorizontalAlign="Center"  />
                </asp:BoundField>
                <asp:BoundField DataField="strBranchName" HeaderText="BranchName" SortExpression="strBranchName" ItemStyle-HorizontalAlign="Center" >
                <ItemStyle HorizontalAlign="Center"  />
                </asp:BoundField>
                <asp:BoundField DataField="strRoutingNumber" HeaderText="RoutingNumber" SortExpression="strRoutingNumber" ItemStyle-HorizontalAlign="Center" >
                <ItemStyle HorizontalAlign="Center"  />
                </asp:BoundField>
                <asp:BoundField DataField="ysnSalaryhold"  HeaderText="Salaryhold" SortExpression="ysnSalaryhold" ItemStyle-HorizontalAlign="Center"  >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="strJobstation" HeaderText="Jobstation" SortExpression="strJobstation" ItemStyle-HorizontalAlign="Center" >
                <ItemStyle HorizontalAlign="Center"  />
                </asp:BoundField>
              
                <asp:BoundField DataField="strunit" HeaderText="Unit" SortExpression="strunit" ItemStyle-HorizontalAlign="Center" >
                <ItemStyle HorizontalAlign="Center"  />
                </asp:BoundField>

                     </Columns>


                     <FooterStyle BackColor="#CCCCCC" /> 
                     <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                     <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
                     <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                     <SortedAscendingCellStyle BackColor="#F1F1F1" />
                     <SortedAscendingHeaderStyle BackColor="#808080" />
                     <SortedDescendingCellStyle BackColor="#CAC9C9" />
                     <SortedDescendingHeaderStyle BackColor="#383838" />
                  


                 </asp:GridView>




            </td>

          </tr> 
           </table>  
          </div>
                
           </table>
            </div>
       
  









<%--=========================================End My Code From Here=================================================--%>
   
    </form>
</body>
</html>  
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoteTADAAdvPerpareVoucher.aspx.cs" Inherits="UI.SAD.Order.RemoteTADAAdvPerpareVoucher" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

    <script src="../../../../Content/JS/datepickr.min.js"></script>
    <script type="text/javascript">
        

        function ConfirmAll() {
            document.getElementById("hdnconfirm").value = "0";
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
            else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
        }


         //-->
      </script>




    </head>
<body>
    <form id="frmpdv" runat="server">
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

        <div id="divcontentholder"><asp:HiddenField ID="hdnID" runat="server" /><asp:HiddenField ID="hdnconfirm" runat="server" />
            <asp:HiddenField ID="hdnAreamanagerEnrol" runat="server"/>
            <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
            <table class="tbldecoration" style="width:auto; float:left;">
                        
            <tr class="tblroweven">
                <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date : "></asp:Label></td>
                <td ><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
                <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>   

                <td style="text-align:right;"><asp:Label ID="lblToDate" CssClass="lbl" runat="server" Text="To Date : "></asp:Label></td>
                <td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
                <script type="text/javascript"> new datepickr('txtToDate', { 'dateFormat': 'Y-m-d' });</script></td>   
            </tr>  

            <tr class="tblrowOdd">  
                <td style="text-align:right;"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit Name : "></asp:Label></td>
                <td>
                    <%--<asp:DropDownList ID="drdlunit" runat="server" CssClass="ddList" DataSourceID="odsUnitvsAuditp" DataTextField="strUnit" DataValueField="intUnitID" ></asp:DropDownList>
                   
                    <asp:ObjectDataSource ID="odsUnitvsAuditp" runat="server" SelectMethod="getHRunitPermissionforTADA" TypeName="SAD_BLL.Customer.Report.StatementC">
                        <SelectParameters>
                            <asp:SessionParameter Name="Enrol" SessionField="sesUserID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>--%>


                <asp:DropDownList ID="drdlUnit" runat="server" CssClass="ddList"  AutoPostBack="True" OnSelectedIndexChanged="drdlUnit_SelectedIndexChanged" DataSourceID="odsunitpermissionhr" DataTextField="strUnit" DataValueField="intUnitID"></asp:DropDownList>
                <asp:ObjectDataSource ID="odsunitpermissionhr" runat="server" SelectMethod="getUnitPermission" TypeName="SAD_BLL.Customer.Report.StatementC">
                <SelectParameters>
                <asp:SessionParameter Name="Enrol" SessionField="sesUserID" Type="Int32" />
                </SelectParameters>
                </asp:ObjectDataSource>

                   
                </td>
                                
                <td style="text-align:right;"><asp:Label ID="lblInstrumentDate" CssClass="lbl" runat="server" Text="Instrument Date : "></asp:Label></td>
                <td ><asp:TextBox ID="txtInstrumentDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
                <script type="text/javascript"> new datepickr('txtInstrumentDate', { 'dateFormat': 'Y-m-d' });</script></td>   
            </tr>
       <%--         decApproveAmount--%>
                
            <tr class="tblroweven">
                <td style="text-align:right;"><asp:Label ID="lblPaymentFor" CssClass="lbl" runat="server" Text="Payment For : "></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlPaymentFor" runat="server" AutoPostBack="false" CssClass="ddList">
                    <asp:ListItem Selected="True" Value="23">IBBL</asp:ListItem><asp:ListItem Value="0">Others Bank</asp:ListItem></asp:DropDownList>
                  </td>  
                <td style="text-align:right;"><asp:Label ID="lblReportType" CssClass="lbl" runat="server" Text="Report Type : "></asp:Label></td>
                <td>
                       <asp:DropDownList ID="ddlAccountReportType" runat="server" AutoPostBack="false" CssClass="ddList" DataSourceID="odsAccountReportType" DataTextField="strReportType" DataValueField="intID"></asp:DropDownList>
                       <asp:ObjectDataSource ID="odsAccountReportType" runat="server" SelectMethod="getAccountDeptTADAReportType" TypeName="SAD_BLL.Customer.Report.StatementC"></asp:ObjectDataSource>
                 </td>

             </tr>
                <tr class="tblrowOdd">
                    <td colspan="3"> <asp:Button ID="btnShow" runat="server" CssClass="button" Text="Show Report" OnClick="btnShow_Click"/></td>
                     <td> <asp:Button ID="btnExportToExcels" runat="server" CssClass="button" Text="Export" OnClick="btnExportToExcels_Click"/></td>
                </tr>
                 <div class="leaveApplication_container">
                     <table>
          <tr><td colspan="4"> 
                <asp:GridView ID="dvgReport" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" 
                BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"  ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="dvgReport_RowDataBound">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                <asp:BoundField DataField="sl" HeaderText="SL No." ItemStyle-HorizontalAlign="Center" SortExpression="sl">
                <ItemStyle HorizontalAlign="center" Width="75px"/></asp:BoundField>

                <asp:TemplateField HeaderText="Application ID" ItemStyle-HorizontalAlign="Center" SortExpression="applicationid">
                <ItemTemplate ><asp:Label ID="lblAppID" runat="server" Text='<%# (int.Parse(""+Eval("applicationid"))) %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="center" Width="90px"/><FooterTemplate><asp:Label ID="lblGT" runat="server" Text ="Grand Total" /></FooterTemplate></asp:TemplateField>
                
                <asp:BoundField DataField="strAccountHolder" HeaderText="Applicant Name" ItemStyle-HorizontalAlign="Center" SortExpression="strAccountHolder">
                <ItemStyle HorizontalAlign="Left" Width="225px"/></asp:BoundField>
       
                    <asp:BoundField DataField="Detaills" HeaderText="Detaills" ItemStyle-HorizontalAlign="Center" SortExpression="Detaills">
                <ItemStyle HorizontalAlign="center" Width="75px"/></asp:BoundField>
                    <asp:BoundField DataField="strJobstation" HeaderText="Jobstation" ItemStyle-HorizontalAlign="Center" SortExpression="strJobstation">
                <ItemStyle HorizontalAlign="center" Width="75px"/></asp:BoundField>
             
                       <asp:TemplateField HeaderText="Payment Amount" ItemStyle-HorizontalAlign="right" SortExpression="decApproveAmount" >
                <ItemTemplate><asp:Label ID="lblGrandTotal" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("decApproveAmount"))) %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="right" Width="90px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# grandtotal %>' /></FooterTemplate></asp:TemplateField>
                    
                        <asp:BoundField DataField="dteTourStartdate" HeaderText="Payment Date" ItemStyle-HorizontalAlign="Center" SortExpression="dteTourStartdate" DataFormatString="{0:yyyy-MM-dd}">
                <ItemStyle HorizontalAlign="center" Width="75px"/></asp:BoundField>
                    <asp:BoundField DataField="intApplicantEnrol" HeaderText="Enrol" ItemStyle-HorizontalAlign="Center" SortExpression="intApplicantEnrol">
                <ItemStyle HorizontalAlign="center" Width="75px"/></asp:BoundField>
                    
                     <asp:BoundField DataField="strTourArea" HeaderText="TourArea" ItemStyle-HorizontalAlign="Center" SortExpression="strTourArea">
                <ItemStyle HorizontalAlign="center" Width="75px"/></asp:BoundField>

                    <asp:BoundField DataField="intECoaid" HeaderText="CoA id" ItemStyle-HorizontalAlign="Center" SortExpression="intECoaid">
                <ItemStyle HorizontalAlign="center" Width="75px"/></asp:BoundField>

                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" SortExpression="">          
                <ItemTemplate> <asp:Button ID="PrepareVoucher" class="button" runat="server" Font-Size="9px" OnClick="PrepareVoucher_Click1" OnClientClick="ConfirmAll();" 
                CommandArgument='<%# Eval("applicationid") +"^"+ Eval("strAccountHolder") +"^"+ Eval("decApproveAmount") +"^"+ Eval("dteTourStartdate")+"^"+ Eval("intApplicantEnrol")+"^"+ Eval("strTourArea") %>' Text="PrepareVoucher" /></ItemTemplate>                                    
                <ItemStyle HorizontalAlign="Left" Width="50px" /> </asp:TemplateField>
                    


                </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                </asp:GridView>

            </td>

          </tr> 
           </table>  
          </div>
                 <div class="leaveApplication_container">
                     <table>
                      <tr><td colspan="4"> 
                          <asp:GridView ID="grdvTADAAdvanceDetaills" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdvTADAAdvanceDetaills_PageIndexChanging">
                  <AlternatingRowStyle BackColor="#CCCCCC" />
                  <Columns>
                      <asp:BoundField DataField="Sl" HeaderText="Sl" SortExpression="Sl" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="intApplicationid"  HeaderText="App.id" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       
                     

                      <asp:BoundField DataField="strApplicantName" HeaderText="Employee  Name" SortExpression="strApplicantName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                        <asp:BoundField DataField="dteBillsubmitdate" HeaderText="Insertion" DataFormatString="{0:dd/MM/yyyy}" SortExpression="dteBillsubmitdate" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="strTourPurpouse" HeaderText="Tour Purpouse" SortExpression="strTourPurpouse" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       
                       <asp:BoundField DataField="decApplicantAmount" HeaderText="ApplicantAmount" SortExpression="decApplicantAmount" ItemStyle-HorizontalAlign="Center" >

                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="strSupervisro" HeaderText="Supervisor" SortExpression="strSupervisro" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="decSupervisroApprove" HeaderText="SupervisorApprove" SortExpression="decSupervisroApprove" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="strAccountsPerson" HeaderText="Accounts" SortExpression="strAccountsPerson" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                        
                       <asp:BoundField DataField="decAcountApprove" HeaderText="AprvBy Accounts" SortExpression="decAcountApprove" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                         <asp:BoundField DataField="dtePaymentDate" HeaderText="Payment Date" DataFormatString="{0:dd/MM/yyyy}" SortExpression="dtePaymentDate" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="dteVoucherDate" HeaderText="Voucher Date" DataFormatString="{0:dd/MM/yyyy}" SortExpression="dteVoucherDate" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                        <asp:BoundField DataField="strVoucherNumber" HeaderText="VoucherNo." SortExpression="strVoucherNumber" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="strSlip" HeaderText="Info" SortExpression="strSlip" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                     
                      

                  </Columns>
                  <FooterStyle BackColor="#CCCCCC" />
                  <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                  <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
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
   </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RmtTADACreditStationBill.aspx.cs" Inherits="UI.SAD.Sales.Report.RptRemoteSales.RmtTADACreditStationBill" %>
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
    <script src="../../../../Content/JS/JQUERY/GridviewScroll.min.js"></script>





</head>
<body>
    <form id="frmpdv" runat="server">
   <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>

<%--=========================================Start My Code From Here===============================================--%>
        <div class="leaveApplication_container"> 
         <div class="tabs_container"> TA DA Credit station Bill :<asp:HiddenField ID="hdnenroll" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
        <asp:HiddenField ID="ApproverEnrol" runat="server"/><asp:HiddenField ID="hdnAreamanagerEnrol" runat="server"/>
        <asp:HiddenField ID="hdfSearchBoxTextChange" runat="server"/><asp:HiddenField ID="hdnAction" runat="server"/>
        <asp:HiddenField ID="HiddenField1" runat="server"/><asp:HiddenField ID="hdnInsertbyenrol" runat="server"/><asp:HiddenField ID="HiddenUnit" runat="server"/>
       <asp:HiddenField ID="hdfEmpCode" runat="server"/>
              <hr /></div>
        <table border="0"; style="width:Auto"; >    
        
            <tr class="tblroweven">
       
                   <td>
                                From
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnFrm" runat="server" />
                                <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFrom" Format="dd/MM/yyyy"
                                    PopupButtonID="imgCal_1" ID="CalendarExtender1" runat="server" EnableViewState="true">
                                </cc1:CalendarExtender>
                                <img id="imgCal_1" src="../../../Content/images/img/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />
                                                     
                            </td>
                            <td>
                                To
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnTo" runat="server" />
                                <asp:TextBox ID="txtTo" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtTo" Format="dd/MM/yyyy"
                                    PopupButtonID="imgCal_2" ID="CalendarExtender2" runat="server" EnableViewState="true">
                                </cc1:CalendarExtender>
                                <img id="imgCal_2" src="../../../Content/images/img/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />
                                                   
                            </td>
        </tr>
               <tr> <td style="text-align:right;"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit Name: "></asp:Label></td>
             
                 
                  <td style="text-align:right"> <asp:DropDownList ID="drdlUnit" runat="server" CssClass="ddList"  AutoPostBack="True" OnSelectedIndexChanged="drdlUnit_SelectedIndexChanged" DataSourceID="odsunitpermissionhr" DataTextField="strUnit" DataValueField="intUnitID"></asp:DropDownList>
  <asp:ObjectDataSource ID="odsunitpermissionhr" runat="server" SelectMethod="getUnitPermission" TypeName="SAD_BLL.Customer.Report.StatementC">
                  <SelectParameters>
                      <asp:SessionParameter Name="Enrol" SessionField="sesUserID" Type="Int32" />
                  </SelectParameters>
           </asp:ObjectDataSource>
    
   </td>


                 <td style="text-align:right;"><asp:Label ID="lblArea" CssClass="lbl" runat="server" Text="Job Station: "></asp:Label></td>
         <td style="text-align:left;"><asp:DropDownList ID="ddlJobStation" CssClass="ddList" Font-Bold="False" runat="server" DataSourceID="Odsjobstation" DataTextField="strJobStationName" DataValueField="intEmployeeJobStationId"></asp:DropDownList>
       
             <asp:ObjectDataSource ID="Odsjobstation" runat="server" SelectMethod="GetJobStation" TypeName="HR_BLL.Dispatch.DispatchBLL">
                 <SelectParameters>
                     <asp:ControlParameter ControlID="drdlUnit" DefaultValue="4" Name="intUnitID" PropertyName="SelectedValue" Type="Int32" />
                 </SelectParameters>
             </asp:ObjectDataSource>
       
        </td>   

            </tr>
         <tr>
             <td style="text-align:right;"><asp:Label ID="lblfullname" CssClass="lbl" runat="server" onchange="javascript: Changed();" Text="Employee Name: "></asp:Label></td>
         <td><asp:TextBox ID="txtEmployeeSearch" runat="server" Wrap="true" placeholder="Type  Name"  Font-Bold="true" CssClass="txtBox" AutoPostBack="false"></asp:TextBox><span style="color:red">*</span></td>
             <td style="text-align:right;"><asp:Label ID="lblDrdlReportType" CssClass="lbl" runat="server" Text="Report TYpe: "></asp:Label></td>
             <td><asp:DropDownList ID="drdlReportType" CssClass="drdl" runat="server" DataSourceID="odsreportty" DataTextField="strReportType" DataValueField="intID"></asp:DropDownList>
                 <asp:ObjectDataSource ID="odsreportty" runat="server" SelectMethod="getReportType" TypeName="SAD_BLL.Customer.Report.StatementC"></asp:ObjectDataSource> </td>
             
         </tr>
         
             <tr>
                 <td><asp:Label ID="lblSupplierName" CssClass="lbl" runat="server" Text="Oil station: "></asp:Label></td>
                 <td colspan="3">
                        <asp:DropDownList ID="drdlSupplierName" CssClass="ddList" runat="server" AutoPostBack="True" DataSourceID="odsFuelstation" DataTextField="strFuelStationName" DataValueField="intFuelStationID"></asp:DropDownList>
                        
                        <asp:ObjectDataSource ID="odsFuelstation" runat="server" SelectMethod="getFuelStationList" TypeName="SAD_BLL.Customer.Report.StatementC">
                            <SelectParameters>
                                <asp:SessionParameter Name="Unit" SessionField="sesUnit" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        
                    </td>

            </tr>
            <tr>
                <td> <asp:Button ID="btnShowReport" runat="server" Text="Show"  OnClick="btnShowReport_Click" /> </td>
            </tr>
           
       </table>
            </div>
       
             

       


         <div class="leaveApplication_container"> 
             <table>
                   <tr class="tblrowodd">
                <td>
               
            
                    <asp:GridView ID="grdvFuelCreditStationbillvsEmployee" ShowFooter="true" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" CellPadding="3" ForeColor="Black" GridLines="Vertical"  BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                       
                        <asp:TemplateField HeaderText="Sl.">
                <ItemTemplate>
                <%#((GridViewRow)Container).RowIndex +1 %>
                </ItemTemplate>
                </asp:TemplateField>


                         <asp:BoundField DataField="emplname" HeaderText="Employe Name" SortExpression="strEmploye" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                         

                      <asp:BoundField DataField="intenrol" HeaderText="Enrol Number" SortExpression="intenrol" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                    
                     

                          <asp:BoundField DataField="desg" HeaderText="Employee Designation" SortExpression="strDesignation" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                           <asp:BoundField DataField="months"  HeaderText="Months" SortExpression="months" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                          <asp:BoundField DataField="strstationname"  HeaderText="Station name" SortExpression="strstationname" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                    
                      <asp:BoundField DataField="decbill"  HeaderText="Bill" SortExpression="decbill" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="jobstation"  HeaderText="Jobstation" SortExpression="jobstation" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                         <asp:BoundField DataField="unit"  HeaderText="Unit" SortExpression="unit" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
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

        <div class="leaveApplication_container"> 
             <table>
                   <tr class="tblrowodd">
                <td>
               
            
                    <asp:GridView ID="grdvStationvsAllunit" ShowFooter="true" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" CellPadding="3" ForeColor="Black" GridLines="Vertical"   BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                       
                        <asp:TemplateField HeaderText="Sl.">
                <ItemTemplate>
                <%#((GridViewRow)Container).RowIndex +1 %>
                </ItemTemplate>
                </asp:TemplateField>
                         <%--strstationname ,instationid ,decbill ,intenrol ,employename ,desgnation ),strdept ,strjob ,strunit ,intjobstation ,intunitid--%> 

                         <asp:BoundField DataField="employename" HeaderText="Employe Name" SortExpression="strEmploye" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                         <asp:BoundField DataField="intenrol" HeaderText="Enrol Number" SortExpression="intenrol" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                         <asp:BoundField DataField="desgnation" HeaderText="Employee Designation" SortExpression="strDesignation" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                      
                          <asp:BoundField DataField="strstationname"  HeaderText="Station name" SortExpression="strstationname" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                    
                      <asp:BoundField DataField="decbill"  HeaderText="Bill" SortExpression="decbill" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="strjob"  HeaderText="Jobstation" SortExpression="strjob" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                         <asp:BoundField DataField="strunit"  HeaderText="Unit" SortExpression="strunit" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
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

       



         <%--=========================================End My Code From Here=================================================--%>
     </form>
</body>
</html>
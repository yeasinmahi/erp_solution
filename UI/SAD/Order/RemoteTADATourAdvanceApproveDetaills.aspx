<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoteTADATourAdvanceApproveDetaills.aspx.cs" Inherits="UI.SAD.Order.RemoteTADATourAdvanceApproveDetaills" EnableEventValidation="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
 <script src="../../../../Content/JS/datepickr.min.js"></script>

    <script type="text/javascript">
        function Showalert() {
            alert('Are you want to close the page ? ');
            window.close();
        }
</script>

</head>
<body>
    <form id="frmpdv" runat="server">
   <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
   
<%--=========================================Start My Code From Here===============================================--%>
          <div class="tabs_container">  Advance   TA - DA information Approve by Immediate Supervisor(Single Employee) :<asp:HiddenField ID="hdnAreamanagerEnrol" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
        
        <asp:HiddenField ID="HiddenUnit" runat="server"/><asp:HiddenField ID="hdnData" runat="server"/>
       
        <hr /></div>
     
                <div class="leaveApplication_container">
              <table>        
          <tr class="tblroweven">
              <td colspan="1">
                  <asp:Button ID="btnApprove" runat="server" Text="Approve" class="button" OnClick="btnApprove_Click" />
                  <asp:Button ID="btnReject" runat="server" Text="Reject" ForeColor="Yellow" class="button" OnClick="btnReject_Click" />


              </td>
         </tr>          
                   <tr class="tblrowodd">
                <td>
         

                    <asp:GridView ID="grdvIDBasisPendingTADAShow" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdvIDBasisPendingTADAShow_PageIndexChanging" OnRowDataBound="grdvIDBasisPendingTADAShow_RowDataBound">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                  

                         <asp:TemplateField HeaderText="ID" SortExpression="intidDet">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdintidDet" runat="server"  Value='<%# Bind("intidDet", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtintidDet" CssClass="txtBox" ReadOnly="true" runat="server" Width="75" TextMode="Number" Text='<%# Bind("intidDet") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="75" />
                            </asp:TemplateField>
                   

                         <asp:BoundField DataField="strEmplNameDet" HeaderText="EmployeName" SortExpression="strEmplNameDet" ControlStyle-Width="10%" >
                                                 <ControlStyle Width="250%" />
                                                </asp:BoundField>



                         <asp:TemplateField HeaderText="Enrol" SortExpression="intEnrolDet">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdintEnrolDet" runat="server"  Value='<%# Bind("intEnrolDet", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtintEnrolDet" CssClass="txtBox" runat="server" ReadOnly="true" Width="75" TextMode="Number" Text='<%# Bind("intEnrolDet") %>' AutoPostBack="false"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="75" />
                            </asp:TemplateField>



                            <asp:TemplateField HeaderText="Tour Start" SortExpression="dteTourStartdateDet">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hddteTourStartdateDet" runat="server"  Value='<%# Bind("dteTourStartdateDet", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdteTourStartdateDet" CssClass="txtBox" runat="server" Width="75" TextMode="Date" Text='<%# Bind("dteTourStartdateDet") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="75" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tour End" SortExpression="dteTourEndDateDet">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hddteTourEndDateDet" runat="server"  Value='<%# Bind("dteTourEndDateDet", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdteTourEndDateDet" CssClass="txtBox" runat="server" Width="75" TextMode="Date" Text='<%# Bind("dteTourEndDateDet") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="75" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Day" SortExpression="intTotaldayDet">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdintTotaldayDet" runat="server"  Value='<%# Bind("intTotaldayDet", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtintTotaldayDet" CssClass="txtBox" runat="server" Width="35" TextMode="Number" Text='<%# Bind("intTotaldayDet") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="35" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tour Areas" SortExpression="strMoveSportDet">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdstrMoveSportDet" runat="server"  Value='<%# Bind("strMoveSportDet", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtstrMoveSportDet" CssClass="txtBox" runat="server" Width="70" TextMode="MultiLine" Text='<%# Bind("strMoveSportDet") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="70" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tour Purpouse" SortExpression="strPurpouseDet">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdstrPurpouseDet" runat="server"  Value='<%# Bind("strPurpouseDet", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtstrPurpouseDet" CssClass="txtBox" runat="server" Width="70" TextMode="MultiLine" Text='<%# Bind("strPurpouseDet") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="70" />
                            </asp:TemplateField>
                         
           

                          <asp:BoundField DataField="decAdvAmountDet" HeaderText="Advance Tk." SortExpression="decAdvAmountDet" ControlStyle-Width="10%" >
                           <ControlStyle Width="10%" />
                                                </asp:BoundField>



                          <asp:TemplateField HeaderText="Approve Tk." SortExpression="decApproveAmount">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hddecApproveAmountDet" runat="server"  Value='<%# Bind("decApproveAmountDet", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtdecApproveAmountDet" CssClass="txtBox" runat="server" Width="60" TextMode="Number" Text='<%# Bind("decApproveAmountDet") %>' AutoPostBack="false"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="60" />
                            </asp:TemplateField>
                           
                                <asp:TemplateField HeaderText="Remarks" SortExpression="strRemarksDet">
                            <ItemTemplate>
                            <asp:HiddenField  ID="hdnstrRemarksDet" runat="server"  Value='<%# Bind("strRemarksDet", "{0:0.0}") %>'></asp:HiddenField>
                            <asp:TextBox ID="txtstrRemarksDet" CssClass="txtBox" runat="server" Width="75" TextMode="SingleLine" Text='<%# Bind("strRemarksDet") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="75" />
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
                            </asp:GridView>



                </td>


            </tr>

    </table>
 </div>






 <%--=========================================End My Code From Here=================================================--%>
 <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>  
            
            
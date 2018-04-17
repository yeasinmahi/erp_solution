<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TADATopsheetForSingleEmployee.aspx.cs" Inherits="UI.SAD.Order.TADATopsheetForSingleEmployee" EnableEventValidation="false" %>

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
     
    
    
    <style>
        .nextclick { border: none; text-decoration: underline; background: none; width:100%; text-align:right; font:normal 10px verdana; 
        cursor:pointer; float:right; color:blue;}
        
    </style>
    <script>
        function Registration() {
            window.open('AuditAttahmentChecking.aspx','', "scrollbars=yes,toolbar=0,height=600,width=800,top=50,left=50, resizable=yes, title=Preview");





        }


</script>

     <script type="text/javascript">
         $(document).ready(function () {
             GridviewScroll();
         });
         function GridviewScroll() {

             $('#<%=grdvTopsheetorDetaills.ClientID%>').gridviewScroll({
                 width: 2048,
                 height: 600,
                 startHorizontal: 0,
                 wheelstep: 10,
                 barhovercolor: "#3399FF",
                 barcolor: "#3399FF"
             });
         }
    </script>


</head>
<body>
    <form id="frmpdv" runat="server">
   <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
  



<%--=========================================Start My Code From Here===============================================--%>



         <div id="divcontentholder">
        <table class="tbldecoration" style="width:auto; float:left;">
        <tr class="tblheader"><td colspan="4"> Employee base Detaills :<asp:HiddenField ID="hdnSeprationID" runat="server" /></td></tr>
            <tr class="tblroweven">
                <td><asp:Label ID="lblName" runat="server" Text="Name"></asp:Label></td>
                <td ><asp:TextBox ID="txtName" BackColor="#ffffcc" runat="server"></asp:TextBox></td>
                <td><asp:Label ID="dsg" runat="server" Text="Designation"></asp:Label></td>
                <td><asp:TextBox ID="textDesg" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lblDepartment" runat="server" Text="Dept."></asp:Label></td>
                <td><asp:TextBox ID="txtDept" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lbLastMonthAudit" runat="server" Text="LM Bill"></asp:Label></td>
                <td><asp:TextBox ID="txtLMbILL" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lblCMBill" runat="server" Text="CM Bill"></asp:Label></td>
                <td><asp:TextBox ID="txtcmbill" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lblIdealMilage" runat="server" Text="Ideal Milage"></asp:Label></td>
                <td><asp:TextBox ID="txtIdealMilage" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
             </tr>
             <tr class="tblrowodd">
                
                <td><asp:Label ID="lblConsMilage" runat="server" Text="Cons Milge"></asp:Label></td>
                <td><asp:TextBox ID="txtConsMilage" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lblQnt" runat="server" Text="Qnt"></asp:Label></td>
                <td><asp:TextBox ID="txtQnt" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lblRatio" runat="server" Text="Cons Ratio"></asp:Label></td>
                <td><asp:TextBox ID="txtRation" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lblPresentDay" runat="server" Text="Present"></asp:Label></td>
                <td><asp:TextBox ID="txtPresent" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lblBillday" runat="server" Text="Bill day"></asp:Label></td>
                <td><asp:TextBox ID="txtBillday" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
               
                 
            </tr>
                
            
            
            </div>
            <div>
                <table>
                    <tr>
                        <%-- <td style="text-align:right"> <asp:Button ID="btnExportToExcel" runat="server" Text="Export" OnClick="btnExportToExcel_Click"/></td>--%>
                    </tr>
            <tr><td>
            <asp:GridView ID="grdvTopsheetorDetaills" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" 
            BorderWidth="1px" CellPadding="4" GridLines="Vertical" ForeColor="Black">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
             

     
                     <asp:BoundField DataField="Id" HeaderText="Sl" SortExpression="Id" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
                    <asp:BoundField DataField="dteFromdate" HeaderText="Date" SortExpression="dteFromdate" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="dtIns" HeaderText="Insertion date" SortExpression="dtIns" DataFormatString="{0:MMMM d, yyyy}" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
                   
                    <asp:BoundField DataField="decMovementDurationT" HeaderText="MovD" SortExpression="decMovementDurationT" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
                    <asp:BoundField DataField="strFromAddressT" HeaderText="From Address" SortExpression="strFromAddressT" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="strMovementAreaT" HeaderText="Movement" SortExpression="strMovementAreaT" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
                    <asp:BoundField DataField="strToAddressT" HeaderText="To Address" SortExpression="strToAddressT" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
                    <asp:BoundField DataField="strNightStayT" HeaderText="Night" SortExpression="strNightStayT" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
                    <asp:BoundField DataField="decStartMilageT" HeaderText="S Milage" SortExpression="decStartMilageT" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                     <asp:BoundField DataField="decEndMilageT" HeaderText="End Milage" SortExpression="decEndMilageT" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
                    <asp:BoundField DataField="decConsumedKmT" HeaderText="Cons. Mlg" SortExpression="decConsumedKmT" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                   
                   <asp:BoundField DataField="strSupportingNoT" HeaderText="Support." SortExpression="strSupportingNoT"  ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
                    <asp:BoundField DataField="decQntPetrolT" HeaderText="Q.Petr." SortExpression="decQntPetrolT" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
                   
                  
                    <asp:TemplateField HeaderText="C.Petr" ItemStyle-HorizontalAlign="Center"><ItemTemplate>
                    <asp:Button ID="btnPetrCst" class="nextclick" OnCommand="Attach_OnCommand" runat="server" CommandName="obl2" Font-Size="9px" 
                    CommandArgument='<%#GetJSFunctionString( Eval("intApplicantEnrol"),Eval("dteFromdate"),Eval("intApplicantUnit")) %>'
                    Text='<%# Bind("decCostPetrolT") %>' /></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField>

                 
                    <%--<asp:BoundField DataField="decCostOctenT" HeaderText="Cost Oct." SortExpression="decCostOctenT" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>--%>
                    
                    <asp:BoundField DataField="decQntOctenT" HeaderText="Q.Oct." SortExpression="decQntOctenT" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" Width="50px" /> </asp:BoundField>
                 
                    <asp:TemplateField HeaderText="C.Oct" ItemStyle-HorizontalAlign="Center"><ItemTemplate>
                    <asp:Button ID="btnOctCst" class="nextclick" OnCommand="Attach_OnCommand" runat="server" CommandName="obl3" Font-Size="9px" 
                    CommandArgument='<%#GetJSFunctionString( Eval("intApplicantEnrol"),Eval("dteFromdate"),Eval("intApplicantUnit")) %>'
                    Text='<%# Bind("decCostOctenT") %>' /></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField>

                   <asp:BoundField DataField="decQntCarbonNitGasT" HeaderText="Q.Cng" SortExpression="decQntCarbonNitGasT" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
                    <%--<asp:BoundField DataField="decCostCarbonNitGasT" HeaderText="Cost Cng" SortExpression="decCostCarbonNitGasT" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>--%>

                 <asp:TemplateField HeaderText="C.CNG" ItemStyle-HorizontalAlign="Center"><ItemTemplate>
                    <asp:Button ID="btnCNGCst" class="nextclick" OnCommand="Attach_OnCommand" runat="server" CommandName="obl4" Font-Size="9px" 
                    CommandArgument='<%#GetJSFunctionString( Eval("intApplicantEnrol"),Eval("dteFromdate"),Eval("intApplicantUnit")) %>'
                    Text='<%# Bind("decCostCarbonNitGasT") %>' /></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField>
                   <asp:BoundField DataField="decLubricantQnt" HeaderText="Qnt Lubr." SortExpression="decLubricantQnt" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /></asp:BoundField>

                   <%--  <asp:BoundField DataField="lubricantcost" HeaderText="Cost Lubr." SortExpression="lubricantcost" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>--%>

                 <asp:TemplateField HeaderText="C.Lbur" ItemStyle-HorizontalAlign="Center"><ItemTemplate>
                    <asp:Button ID="btnLubricantCst" class="nextclick" OnCommand="Attach_OnCommand" runat="server" CommandName="obl5" Font-Size="9px" 
                    CommandArgument='<%#GetJSFunctionString( Eval("intApplicantEnrol"),Eval("dteFromdate"),Eval("intApplicantUnit")) %>'
                    Text='<%# Bind("lubricantcost") %>' /></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField>
                    <%--<asp:BoundField DataField="decFareBusAmountT" HeaderText="Bus" SortExpression="decFareBusAmountT" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /></asp:BoundField>--%>
                  <asp:TemplateField HeaderText="Bus" ItemStyle-HorizontalAlign="Center"><ItemTemplate>
                    <asp:Button ID="btnBusCst" class="nextclick" OnCommand="Attach_OnCommand" runat="server" CommandName="obl6" Font-Size="9px" 
                    CommandArgument='<%#GetJSFunctionString( Eval("intApplicantEnrol"),Eval("dteFromdate"),Eval("intApplicantUnit")) %>'
                    Text='<%# Bind("decFareBusAmountT") %>' /></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField>




                    <asp:BoundField DataField="decFareRickshawAmountT" HeaderText="Rick" SortExpression="decFareRickshawAmountT"  ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" Width="50px" /> </asp:BoundField>
                    <asp:BoundField DataField="decFareCNGAmountT" HeaderText="CNG" SortExpression="decFareCNGAmountT" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Left" Width="50px" /> </asp:BoundField>

                    <%--<asp:BoundField DataField="decFareTrainAmountT" HeaderText="Train" SortExpression="decFareTrainAmountT" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>--%>

                    <asp:TemplateField HeaderText="Train" ItemStyle-HorizontalAlign="Center"><ItemTemplate>
                    <asp:Button ID="btnTrainCst" class="nextclick" OnCommand="Attach_OnCommand" runat="server" CommandName="obl7" Font-Size="9px" 
                    CommandArgument='<%#GetJSFunctionString( Eval("intApplicantEnrol"),Eval("dteFromdate"),Eval("intApplicantUnit")) %>'
                    Text='<%# Bind("decFareTrainAmountT") %>' /></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField>

                <%--decFareBoatAmountT--%>
                    <%--<asp:BoundField DataField="decFareAirPlaneT" HeaderText="Air" SortExpression="decFareAirPlaneT" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /></asp:BoundField>--%>
                    
                     <asp:TemplateField HeaderText="Boat" ItemStyle-HorizontalAlign="Center"><ItemTemplate>
                    <asp:Button ID="btnBoatcst" class="nextclick" OnCommand="Attach_OnCommand" runat="server" CommandName="obl19" Font-Size="9px" 
                    CommandArgument='<%#GetJSFunctionString( Eval("intApplicantEnrol"),Eval("dteFromdate"),Eval("intApplicantUnit")) %>'
                    Text='<%# Bind("decFareBoatAmountT") %>' /></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField>



                    <asp:TemplateField HeaderText="Air" ItemStyle-HorizontalAlign="Center"><ItemTemplate>
                    <asp:Button ID="btnAirCst" class="nextclick" OnCommand="Attach_OnCommand" runat="server" CommandName="obl8" Font-Size="9px" 
                    CommandArgument='<%#GetJSFunctionString( Eval("intApplicantEnrol"),Eval("dteFromdate"),Eval("intApplicantUnit")) %>'
                    Text='<%# Bind("decFareAirPlaneT") %>' /></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField>



                    <asp:BoundField DataField="decFareOtherVheicleAmountT" HeaderText="Oth Vhc" SortExpression="decFareOtherVheicleAmountT"  ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
                    <%--<asp:BoundField DataField="decCostAmountMaintenaceT" HeaderText="Mnt" SortExpression="decCostAmountMaintenaceT" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>--%>
                    <asp:TemplateField HeaderText="Mnt" ItemStyle-HorizontalAlign="Center"><ItemTemplate>
                    <asp:Button ID="btnMntCst" class="nextclick" OnCommand="Attach_OnCommand" runat="server" CommandName="obl9" Font-Size="9px" 
                    CommandArgument='<%#GetJSFunctionString( Eval("intApplicantEnrol"),Eval("dteFromdate"),Eval("intApplicantUnit")) %>'
                    Text='<%# Bind("decCostAmountMaintenaceT") %>' /></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField>



                   <%-- <asp:BoundField DataField="decFeryTollCostT" HeaderText="Ferry" SortExpression="decFeryTollCostT" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>--%>

                <asp:TemplateField HeaderText="Ferry" ItemStyle-HorizontalAlign="Center"><ItemTemplate>
                    <asp:Button ID="btnFerryCst" class="nextclick" OnCommand="Attach_OnCommand" runat="server" CommandName="obl10" Font-Size="9px" 
                    CommandArgument='<%#GetJSFunctionString( Eval("intApplicantEnrol"),Eval("dteFromdate"),Eval("intApplicantUnit")) %>'
                    Text='<%# Bind("decFeryTollCostT") %>' /></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField>



                    <%--<asp:BoundField DataField="decDAAmountT" HeaderText="Own Da" SortExpression="decDAAmountT" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /></asp:BoundField>--%>

                  <asp:TemplateField HeaderText="Own Da" ItemStyle-HorizontalAlign="Center"><ItemTemplate>
                    <asp:Button ID="btnOwnDACst" class="nextclick" OnCommand="Attach_OnCommand" runat="server" CommandName="obl13" Font-Size="9px" 
                    CommandArgument='<%#GetJSFunctionString( Eval("intApplicantEnrol"),Eval("dteFromdate"),Eval("intApplicantUnit")) %>'
                    Text='<%# Bind("decDAAmountT") %>' /></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField>

                    <%--<asp:BoundField DataField="decDriverDACostT" HeaderText="Drv. DA" SortExpression="decDriverDACostT"  ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>--%>
                <asp:TemplateField HeaderText="Drv. DA" ItemStyle-HorizontalAlign="Center"><ItemTemplate>
                    <asp:Button ID="btnDrvDACst" class="nextclick" OnCommand="Attach_OnCommand" runat="server" CommandName="obl13" Font-Size="9px" 
                    CommandArgument='<%#GetJSFunctionString( Eval("intApplicantEnrol"),Eval("dteFromdate"),Eval("intApplicantUnit")) %>'
                    Text='<%# Bind("decDriverDACostT") %>' /></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField>


                    <%--<asp:BoundField DataField="decHotelBillAmountT" HeaderText="Own Hotel" SortExpression="decHotelBillAmountT" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>--%>
                   <asp:TemplateField HeaderText="Own.Htl" ItemStyle-HorizontalAlign="Center"><ItemTemplate>
                    <asp:Button ID="btnOwnHotelCst" class="nextclick" OnCommand="Attach_OnCommand" runat="server" CommandName="obl12" Font-Size="9px" 
                    CommandArgument='<%#GetJSFunctionString( Eval("intApplicantEnrol"),Eval("dteFromdate"),Eval("intApplicantUnit")) %>'
                    Text='<%# Bind("decHotelBillAmountT") %>' /></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField>


                   
                 
                    <asp:TemplateField HeaderText="Drv.Htl" ItemStyle-HorizontalAlign="Center"><ItemTemplate>
                    <asp:Button ID="btnDrverHotelCst" class="nextclick" OnCommand="Attach_OnCommand" runat="server" CommandName="obl14" Font-Size="9px" 
                    CommandArgument='<%#GetJSFunctionString( Eval("intApplicantEnrol"),Eval("dteFromdate"),Eval("intApplicantUnit")) %>'
                    Text='<%# Bind("decDriverHotelBillAmountT") %>' /></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField>


                   <%-- <asp:BoundField DataField="decPhotoCopyCostT" HeaderText="Phto Copy" SortExpression="decPhotoCopyCostT" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /></asp:BoundField>--%>

                 <asp:TemplateField HeaderText="Ph.Copy" ItemStyle-HorizontalAlign="Center"><ItemTemplate>
                    <asp:Button ID="btnPhotocopyCst" class="nextclick" OnCommand="Attach_OnCommand" runat="server" CommandName="obl15" Font-Size="9px" 
                    CommandArgument='<%#GetJSFunctionString( Eval("intApplicantEnrol"),Eval("dteFromdate"),Eval("intApplicantUnit")) %>'
                    Text='<%# Bind("decPhotoCopyCostT") %>' /></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField>


                   <%-- <asp:BoundField DataField="decCourierCostT" HeaderText="Cour." SortExpression="decCourierCostT"  ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>--%>

                <asp:TemplateField HeaderText="Cour." ItemStyle-HorizontalAlign="Center"><ItemTemplate>
                    <asp:Button ID="btnCourierCst" class="nextclick" OnCommand="Attach_OnCommand" runat="server" CommandName="obl16" Font-Size="9px" 
                    CommandArgument='<%#GetJSFunctionString( Eval("intApplicantEnrol"),Eval("dteFromdate"),Eval("intApplicantUnit")) %>'
                    Text='<%# Bind("decCourierCostT") %>' /></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField>


                    <%--<asp:BoundField DataField="decOtherBillAmountT" HeaderText="Oth. Bill" SortExpression="decOtherBillAmountT" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>--%>

                <asp:TemplateField HeaderText="Oth.B" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate><asp:Button ID="btnObl" class="nextclick" OnCommand="Attach_OnCommand" runat="server" CommandName="obl17" Font-Size="9px" 
                CommandArgument='<%#GetJSFunctionString( Eval("intApplicantEnrol"),Eval("dteFromdate"),Eval("intApplicantUnit")) %>'
                Text='<%# Bind("decOtherBillAmountT") %>' /></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField>


          
                 
                  <asp:BoundField DataField="decRowTotalT" HeaderText="Total" SortExpression="decRowTotalT" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
                    
                <%--<asp:BoundField DataField="intApplicantEnrol" HeaderText="Enrol" SortExpression="intApplicantEnrol" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>--%>

                <asp:TemplateField HeaderText="Enrol" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate><asp:Button ID="btnEnrbl" class="nextclick" OnCommand="Attach_OnCommand" runat="server" CommandName="obl18" Font-Size="9px" 
                CommandArgument='<%#GetJSFunctionString( Eval("intApplicantEnrol"),Eval("dteFromdate"),Eval("intApplicantUnit")) %>'
                Text='<%# Bind("intApplicantEnrol") %>' /></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField>

               


                <asp:BoundField DataField="intApplicantUnit" HeaderText="unit" SortExpression="intApplicantUnit" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>



                

                  <asp:TemplateField HeaderText="Det.">
             <ItemTemplate>
             <asp:Button ID="CompleteAttachment" runat="server" Text="Attachment" class="button" CommandName="complete" OnClick="CompleteAttachment_Click"   CommandArgument='<%# Eval("intApplicantEnrol")+","+Eval("dteFromdate")+","+Eval("intApplicantUnit")%>' /></ItemTemplate>
             </asp:TemplateField>  


                    </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
                     <HeaderStyle CssClass="GridviewScrollHeader" /><PagerStyle CssClass="GridviewScrollPager" />
                  </asp:GridView>


          

        </table>       
    </div>
     <%--=========================================End My Code From Here=================================================--%>

    </form>
</body>
</html>  
            
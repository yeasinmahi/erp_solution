<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransPortCostApprovebyHead.aspx.cs" Inherits="UI.Vehicle_Registration_Renewal.TransPortCostApprovebyHead" %>
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
    SearchText();
});
function Changed() {
    document.getElementById('hdfSearchBoxTextChange').value = 'true';
}
function SearchText() {
    $("#txtVheicleNumber").autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json;",
                url: "TransPortCostApprovebyHead.aspx/GetAutoserachingAssetNameforHeadaprv",
                data: "{'strSearchKey':'" + document.getElementById('txtVheicleNumber').value + "'}",
                dataType: "json",
                success: function (data) {
                    response(data.d);
                },
                error: function (result) {
                    alert("Error");
                }
            });
        }
    });
}


    </script>


     <script>
         function Registration(url) {
            window.open('Detalis_Registration_UI.aspx', 'sub', "scrollbars=yes,toolbar=0,height=550,width=500,top=5,left=0, resizable=yes, title=Preview");
            //window.location.href("Detalis_Registration_UI.aspx")
        }

        function TaxToken() {
            window.open('Detalis_TaxToken_UI.aspx', 'sub', "scrollbars=yes,toolbar=0,height=550,width=500,top=5,left=0, resizable=yes, title=Preview");

        }
        function Fitness() {
            window.open('Detalis_FitnessAIT_UI.aspx', 'sub', "scrollbars=yes,toolbar=0,height=550,width=500,top=5,left=0, resizable=yes, title=Preview");

        }
        function RoutePermit() {
            window.open('Detalis_Rootpermit_UI.aspx', 'sub', "scrollbars=yes,toolbar=0,height=550,width=500,top=5,left=0, resizable=yes, title=Preview");

        }
        function Insurance() {
            window.open('Detalis_Insurance_UI.aspx', 'sub', "scrollbars=yes,toolbar=0,height=550,width=550,top=5,left=0, resizable=yes, title=Preview");

        }
        function NamePlate() {
            window.open('Detalis_NamePlate_UI.aspx', 'sub', "scrollbars=yes,toolbar=0,height=550,width=500,top=5,left=0, resizable=yes, title=Preview");

        }
        function DRC() {
            window.open('Detalis_DRC_UI.aspx', 'sub', "scrollbars=yes,toolbar=0,height=550,width=500,top=5,left=0, resizable=yes, title=Preview");

        }
        function Confirm() {
             var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
            }
          
</script>


    
</head>
<body>
    <form id="frmpdv" runat="server">
 <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
<%--=========================================Start My Code From Here===============================================--%>
 <div class="leaveApplication_container"> 
    <div class="tabs_container"> Vheicle renewal Cost Approve by Department Head :<asp:HiddenField ID="hdnAreamanagerEnrol" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
        
        <asp:HiddenField ID="HiddenUnit" runat="server"/><asp:HiddenField ID="hdnData" runat="server"/>
       
        <hr /></div>
        <table border="0"; style="width:Auto"; >  
         <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtToDate', { 'dateFormat': 'Y-m-d' });</script></td>          
        </tr>
 <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblReportType" CssClass="lbl" runat="server" Text="Report Type:  "></asp:Label></td>
        <td><asp:DropDownList ID="drdlreportype" runat="server">
             <asp:ListItem Value="0">Pending</asp:ListItem>
                     <asp:ListItem Value="1">Aproved</asp:ListItem>
                        </asp:DropDownList></td>
                <td style="text-align:right"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit Name:  "></asp:Label></td>
                         
                         <td><asp:DropDownList ID="drdlUnitName"  runat="server" DataSourceID="odsUnitNameByEnrol" DataTextField="strUnit" DataValueField="intUnitID" OnSelectedIndexChanged="drdlUnitName_SelectedIndexChanged"></asp:DropDownList>
            
                 <asp:ObjectDataSource ID="odsUnitNameByEnrol" runat="server" SelectMethod="getUnitNamebyEnrol" TypeName="HR_BLL.TourPlan.TourPlanning">
                     <SelectParameters>
                         <asp:SessionParameter Name="Enrol" SessionField="sesUserID" Type="Int32" />
                     </SelectParameters>
                 </asp:ObjectDataSource>
            </td>
              </tr>

            <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblcategorytype" CssClass="lbl" runat="server" Text="Report Type:  "></asp:Label></td>
        <td><asp:DropDownList ID="drdlcategory" runat="server">
             <asp:ListItem Value="1">Renewal</asp:ListItem>
                     <asp:ListItem Value="2">Registraion</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
  


    <tr class="tblrowOdd">
        <td colspan="2"> <asp:Button ID="btnShow" runat="server" Text="Show Bill Info" Width="100px" OnClick="btnShow_Click" /></td> 
       <td colspan="2"> <asp:Button ID="btnApprove" runat="server" Text="Approve" Width="100px" OnClick="btnApprove_Click" /></td> 
    
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
       
                    <asp:GridView ID="grdvForTransportcostaprvbyHead" runat="server" Font-Size="Smaller" ShowFooter="true" AutoGenerateColumns="False" AllowPaging="false"  BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" HeaderStyle-Wrap="true" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdvForTransportcostaprvbyHead_PageIndexChanging" OnRowDataBound="grdvForTransportcostaprvbyHead_RowDataBound" style="margin-top: 21px">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                         <asp:TemplateField HeaderText="Sl"> <ItemTemplate> <%#Container.DataItemIndex+1 %> </ItemTemplate></asp:TemplateField>
                         <asp:BoundField DataField="strassetid" HeaderText="strassetid" ItemStyle-Width="700px" SortExpression="strjobstation" ItemStyle-HorizontalAlign="Center" />
                           <asp:BoundField DataField="strAssetName" HeaderText="strNameOfAsset" ItemStyle-Width="700px" SortExpression="strjobstation" ItemStyle-HorizontalAlign="Center" />
                        <%--<asp:BoundField DataField="strJobStationName" HeaderText="Jobstation Name" ItemStyle-Width="700px" SortExpression="strjobstation" ItemStyle-HorizontalAlign="Center" />--%>
                         <%--intRowID, strAssetName,strassetID,dteregistrationdate,  monRegtration,intRegtration
                             ,dtetaxtokendate,monTaxToken,intTaxToken
                             ,dtefitnessdate,monFitness,intFitness
                            --%>
                        <asp:BoundField DataField="dteregistrationdate" HeaderText="Registration   Date" SortExpression="dteDate78" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:yyyy-MM-dd}" />
                        <asp:BoundField DataField="intRegtration" HeaderText="Regsid" Visible="false" SortExpression="310078" />
                         
                       
                      
                         <asp:BoundField DataField="monRegtration" HeaderText="Registation Cost" SortExpression="Registration" ItemStyle-HorizontalAlign="Center" />
                        <asp:TemplateField HeaderText="Det.">
                        <ItemTemplate><asp:Button ID="btnDetRegistration" runat="server" class="button" CommandName="complete" OnClick="btnDetRegistration_Click"   CommandArgument='<%# Eval("intRegtration") %>'  Text="Detaills" /></ItemTemplate></asp:TemplateField>  
                           <asp:TemplateField HeaderText="Reject.">
                        <ItemTemplate><asp:Button ID="btnReject" runat="server" class="button" CommandName="complete" OnClick="btnReject_Click"   CommandArgument='<%# Eval("intRegtration") %>'  Text="Reject" /></ItemTemplate></asp:TemplateField>  
                         <asp:BoundField DataField="dtetaxtokendate" HeaderText="Date of Taxtoken" ItemStyle-Width="120px" SortExpression="dteDate79" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Center"  />
                        <asp:BoundField DataField="intTaxToken" HeaderText="idTaxtoken" Visible="false" SortExpression="310079" />
                        <asp:BoundField DataField="monTaxToken" HeaderText="TAX Token Cost" SortExpression="TAXToken" ItemStyle-HorizontalAlign="Center" />
                    

                          <asp:TemplateField HeaderText="Det.">
                        <ItemTemplate>
                        <asp:Button ID="btnDetTaxToken" runat="server"  class="button" CommandName="complete" OnClick="btnDetTaxToken_Click"  CommandArgument='<%# Eval("intTaxToken") %>' Text="Detaills" /></ItemTemplate>
                        </asp:TemplateField>  
                           <asp:TemplateField HeaderText="Reject.">
                        <ItemTemplate><asp:Button ID="btnRejecttaxtoken" runat="server" class="button" CommandName="complete" OnClick="btnRejecttaxtoken_Click"  CommandArgument='<%# Eval("intTaxToken") %>'  Text="Reject" /></ItemTemplate></asp:TemplateField>  
                          <asp:BoundField DataField="dtefitnessdate" HeaderText="Date of  Fitness" SortExpression="dteDate80" ItemStyle-Width="120px" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="intFitness" HeaderText="idFitness" Visible="false" SortExpression="310080" />
                        <asp:BoundField DataField="monFitness" HeaderText="Fitness Cost" SortExpression="Fitness" ItemStyle-HorizontalAlign="Center" />
                     
                          <asp:TemplateField HeaderText="Det.">
                        <ItemTemplate>
                        <asp:Button ID="btnDetFitness" runat="server"  class="button" CommandName="complete" OnClick="btnDetFitness_Click"  CommandArgument='<%# Eval("intFitness") %>'  Text="Detaills" /></ItemTemplate>
                        </asp:TemplateField>  
                           <asp:TemplateField HeaderText="Reject.">
                        <ItemTemplate><asp:Button ID="btnRejectfitness" runat="server" class="button" CommandName="complete" OnClick="btnRejectfitness_Click"   CommandArgument='<%# Eval("intFitness") %>'  Text="Reject" /></ItemTemplate></asp:TemplateField>  
                          <%--,dteroutepermitdate,monRoutePermit,intRoutePermit,dteinsurancedate,totalinsurance,intinsuranceid
                              ,nameplatedate,totalnameplate,intnameplateid,dtedrcdate,totaldrc,intdrcid,monTotal--%>
                         
                          <asp:BoundField DataField="dteroutepermitdate" HeaderText="Date Route Permit" SortExpression="dteDate81" ItemStyle-Width="120px" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="intRoutePermit" HeaderText="idRoutePermit" Visible="false" SortExpression="310081" />
                        <asp:BoundField DataField="monRoutePermit" HeaderText="RoutePermit Cost" SortExpression="Route Permit" ItemStyle-HorizontalAlign="Center" />
                       
                         <asp:TemplateField HeaderText="Det.">
                        <ItemTemplate>
                        <asp:Button ID="btnDetRoutePermit" runat="server"  class="button" CommandName="complete" OnClick="btnDetRoutePermit_Click"   CommandArgument='<%# Eval("intRoutePermit") %>'  Text="Detaills" /></ItemTemplate>
                        </asp:TemplateField> 
                           <asp:TemplateField HeaderText="Reject.">
                        <ItemTemplate><asp:Button ID="btnRejectRoutePermit" runat="server" class="button" CommandName="complete" OnClick="btnRejectRoutePermit_Click"   CommandArgument='<%# Eval("intRoutePermit") %>'  Text="Reject" /></ItemTemplate></asp:TemplateField>   
                         <asp:BoundField DataField="dteinsurancedate" HeaderText="Date of Insurance" SortExpression="dteDate82" ItemStyle-Width="120px" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="intinsuranceid" HeaderText="idInsurance" Visible="false" SortExpression="310082" />
                        <asp:BoundField DataField="totalinsurance" HeaderText="Insurance Cost" SortExpression="Insurance" ItemStyle-HorizontalAlign="Center" />
                        
                         <asp:TemplateField HeaderText="Det.">
                        <ItemTemplate>
                        <asp:Button ID="btnDetInsurance" runat="server" class="button" CommandName="complete" OnClick="btnDetInsurance_Click"   CommandArgument='<%# Eval("intinsuranceid") %>'  Text="Detaills" /></ItemTemplate>
                        </asp:TemplateField>  
                           <asp:TemplateField HeaderText="Reject.">
                        <ItemTemplate><asp:Button ID="btnRejectInsurance" runat="server" class="button" CommandName="complete" OnClick="btnRejectInsurance_Click"  CommandArgument='<%# Eval("intinsuranceid") %>'  Text="Reject" /></ItemTemplate></asp:TemplateField>  
                          <asp:BoundField DataField="nameplatedate" HeaderText="Date of NamePlate" SortExpression="dteDate83" ItemStyle-Width="120px" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="intnameplateid" HeaderText="idNamePlate" Visible="false" SortExpression="310083" />
                        <asp:BoundField DataField="totalnameplate" HeaderText="NamePlate Cost" SortExpression="Name Plate" ItemStyle-HorizontalAlign="Center" />
                       <asp:TemplateField HeaderText="Status" Visible="false" ControlStyle-Width="75px" >
                        <ItemTemplate><asp:Label ID="Label83" runat="server" Text='<%# Eval("intnameplateid") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Det.">
                        <ItemTemplate>
                        <asp:Button ID="btnDetNamePlate" runat="server"  class="button" CommandName="complete" OnClick="btnDetNamePlate_Click"   CommandArgument='<%# Eval("intnameplateid") %>'  Text="Detaills" /></ItemTemplate>
                        </asp:TemplateField>  
                           <asp:TemplateField HeaderText="Reject.">
                        <ItemTemplate><asp:Button ID="btnRejectNameplate" runat="server" class="button" CommandName="complete" OnClick="btnRejectNameplate_Click"   CommandArgument='<%# Eval("intnameplateid") %>'  Text="Reject" /></ItemTemplate></asp:TemplateField>  
                          <asp:BoundField DataField="dtedrcdate" HeaderText="Date of DRC" SortExpression="dteDate108" ItemStyle-Width="120px" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="intdrcid" HeaderText="idDRC" Visible="false" SortExpression="310108" />
                        <asp:BoundField DataField="totaldrc" HeaderText="DRC Cost" SortExpression="DRC" ItemStyle-HorizontalAlign="Center" />
                        
                        <asp:TemplateField HeaderText="Det."><ItemTemplate>
                        <asp:Button ID="btnDRC" runat="server" class="button" CommandName="complete" OnClick="btnDRC_Click"  CommandArgument='<%# Eval("intdrcid") %>'   Text="Detaills" /></ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Reject."><ItemTemplate>
                        <asp:Button ID="btnRejectDRC" runat="server" class="button" CommandName="complete" OnClick="btnRejectDRC_Click"   CommandArgument='<%# Eval("intdrcid") %>'  Text="Reject" /></ItemTemplate></asp:TemplateField>  
                        
                         <%--<asp:TemplateField HeaderText="Details."><ItemTemplate>
                        <asp:Button ID="btnInsurance" runat="server" class="button" CommandName="complete" OnClick="btnInsurance_Click"  CommandArgument='<%# Eval("intdrcid") %>'   Text="Detaills" /></ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Reject."><ItemTemplate>
                        <asp:Button ID="btnRejectDRC" runat="server" class="button" CommandName="complete" OnClick="btnRejectDRC_Click"   CommandArgument='<%# Eval("intdrcid") %>'  Text="Reject" /></ItemTemplate></asp:TemplateField>  
                        --%>
                         <asp:BoundField DataField="monTotal" HeaderText="Total Cost" SortExpression="deccost" ItemStyle-HorizontalAlign="Center" />
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

         <div class="leaveApplication_container">
              <table>        
          <tr class="tblroweven"><td colspan="4">
              </td>
         </tr>          
                   <tr class="tblrowodd">
                <td>
            <asp:GridView ID="grdvaprvrenewaltransportcost" runat="server" Font-Size="Smaller" ShowFooter="True" AutoGenerateColumns="False"  BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" HeaderStyle-Wrap="true" CellPadding="3" GridLines="Vertical" OnPageIndexChanging="grdvForTransportcostaprvbyHead_PageIndexChanging" OnRowDataBound="grdvForTransportcostaprvbyHead_RowDataBound" style="margin-top: 21px">
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                     <Columns>
                         <asp:TemplateField HeaderText="Sl"> <ItemTemplate> <%#Container.DataItemIndex+1 %> </ItemTemplate></asp:TemplateField>
                         <asp:BoundField DataField="strassetID" HeaderText="strassetid" ItemStyle-Width="700px" SortExpression="strjobstation" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center" Width="700px"></ItemStyle>
                         </asp:BoundField>
                           <asp:BoundField DataField="strAssetName" HeaderText="strNameOfAsset" ItemStyle-Width="700px" SortExpression="strjobstation" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center" Width="700px"></ItemStyle>
                         </asp:BoundField>
                        <%--<asp:BoundField DataField="strJobStationName" HeaderText="Jobstation Name" ItemStyle-Width="700px" SortExpression="strjobstation" ItemStyle-HorizontalAlign="Center" />--%>
                         
                        <asp:BoundField DataField="dteregistrationdate" HeaderText="Registration   Date" SortExpression="dteDate78" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:yyyy-MM-dd}" >
<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
                         </asp:BoundField>
                        <asp:BoundField DataField="intRegtration" HeaderText="Regsid" Visible="false" SortExpression="310078" />
                       
                      
                      
                         <asp:BoundField DataField="monRegtration" HeaderText="Registation Cost" SortExpression="Registration" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                         </asp:BoundField>
                        <asp:TemplateField HeaderText="Det.">
                        <ItemTemplate><asp:Button ID="btnDetRegistration" runat="server" class="button" CommandName="complete" OnClick="btnDetRegistration_Click"   CommandArgument='<%# Eval("intRegtration") %>'  Text="Detaills" /></ItemTemplate></asp:TemplateField>  
                           <asp:TemplateField HeaderText="Reject.">
                        <ItemTemplate><asp:Button ID="btnReject" runat="server" class="button" CommandName="complete" OnClick="btnReject_Click"   CommandArgument='<%# Eval("intRegtration") %>'  Text="Reject" /></ItemTemplate></asp:TemplateField>  
                         <asp:BoundField DataField="dtetaxtokendate" HeaderText="Date of Taxtoken" ItemStyle-Width="120px" SortExpression="dteDate79" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Center"  >
<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
                         </asp:BoundField>
                        <asp:BoundField DataField="id79" HeaderText="idTaxtoken" Visible="false" SortExpression="310079" />
                        <asp:BoundField DataField="monTaxToken" HeaderText="TAX Token Cost" SortExpression="TAXToken" ItemStyle-HorizontalAlign="Center" >
                   

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                         </asp:BoundField>
                   

                            <%-- strAssetName ,strassetID ,monRegtration ,intRegtration ,monTaxToken ,intTaxToken ,monFitness ,intFitness ,monRoutePermit ,intRoutePermit ,totalinsurance ,intinsuranceid  ,totalnameplate ,intnameplateid ,totaldrc ,intdrcid ,monTotal  
,dteregistrationdate ,dtetaxtokendate ,dtefitnessdate ,dteroutepermitdate ,dteinsurancedate ,nameplatedate ,dtedrcdate
         --%>  

                          <asp:TemplateField HeaderText="Det.">
                        <ItemTemplate>
                        <asp:Button ID="btnDetTaxToken" runat="server"  class="button" CommandName="complete" OnClick="btnDetTaxToken_Click"  CommandArgument='<%# Eval("intTaxToken") %>' Text="Detaills" /></ItemTemplate>
                        </asp:TemplateField>  
                           <asp:TemplateField HeaderText="Reject.">
                        <ItemTemplate><asp:Button ID="btnRejecttaxtoken" runat="server" class="button" CommandName="complete" OnClick="btnRejecttaxtoken_Click"  CommandArgument='<%# Eval("intTaxToken") %>'  Text="Reject" /></ItemTemplate></asp:TemplateField>  
                          <asp:BoundField DataField="dtefitnessdate" HeaderText="Date of  Fitness" SortExpression="dteDate80" ItemStyle-Width="120px" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Center" >
                        
<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
                         </asp:BoundField>
                        
                        <asp:BoundField DataField="monFitness" HeaderText="Fitness Cost" SortExpression="Fitness" ItemStyle-HorizontalAlign="Center" >
                     
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                         </asp:BoundField>
                     
                          <asp:TemplateField HeaderText="Det.">
                        <ItemTemplate>
                        <asp:Button ID="btnDetFitness" runat="server"  class="button" CommandName="complete" OnClick="btnDetFitness_Click"  CommandArgument='<%# Eval("intFitness") %>'  Text="Detaills" /></ItemTemplate>
                        </asp:TemplateField>  
                           <asp:TemplateField HeaderText="Reject.">
                        <ItemTemplate><asp:Button ID="btnRejectfitness" runat="server" class="button" CommandName="complete" OnClick="btnRejectfitness_Click"   CommandArgument='<%# Eval("intFitness") %>'  Text="Reject" /></ItemTemplate></asp:TemplateField>  
                          <asp:BoundField DataField="dteroutepermitdate" HeaderText="Date of RoutePermit  " SortExpression="dteDate81" ItemStyle-Width="120px" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Center" >
                       
<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
                         </asp:BoundField>
                       
                        <asp:BoundField DataField="monRoutePermit" HeaderText="RoutePermit Cost" SortExpression="Route Permit" ItemStyle-HorizontalAlign="Center" >
                      
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                         </asp:BoundField>
                      
                         <asp:TemplateField HeaderText="Det.">
                        <ItemTemplate>
                        <asp:Button ID="btnDetRoutePermit" runat="server"  class="button" CommandName="complete" OnClick="btnDetRoutePermit_Click"   CommandArgument='<%# Eval("intRoutePermit") %>'  Text="Detaills" /></ItemTemplate>
                        </asp:TemplateField> 
                           <asp:TemplateField HeaderText="Reject.">
                        <ItemTemplate><asp:Button ID="btnRejectRoutePermit" runat="server" class="button" CommandName="complete" OnClick="btnRejectRoutePermit_Click"   CommandArgument='<%# Eval("intRoutePermit") %>'  Text="Reject" /></ItemTemplate></asp:TemplateField>   
                         <asp:BoundField DataField="dteinsurancedate" HeaderText="Date of Insurance" SortExpression="dteDate82" ItemStyle-Width="120px" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Center" >
                        
<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
                         </asp:BoundField>
                        
                        <asp:BoundField DataField="totalinsurance" HeaderText="Insurance Cost" SortExpression="Insurance" ItemStyle-HorizontalAlign="Center" >
                       
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                         </asp:BoundField>
                       
                         <asp:TemplateField HeaderText="Det.">
                        <ItemTemplate>
                        <asp:Button ID="btnDetInsurance" runat="server" class="button" CommandName="complete" OnClick="btnDetInsurance_Click"   CommandArgument='<%# Eval("intinsuranceid") %>'  Text="Detaills" /></ItemTemplate>
                        </asp:TemplateField>  
                           <asp:TemplateField HeaderText="Reject.">
                        <ItemTemplate><asp:Button ID="btnRejectInsurance" runat="server" class="button" CommandName="complete" OnClick="btnRejectInsurance_Click"  CommandArgument='<%# Eval("intinsuranceid") %>'  Text="Reject" /></ItemTemplate></asp:TemplateField>  
                          <asp:BoundField DataField="nameplatedate" HeaderText="Date of NamePlate" SortExpression="dteDate83" ItemStyle-Width="120px" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Center" >
                       
<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
                         </asp:BoundField>
                       
                        <asp:BoundField DataField="totalnameplate" HeaderText="NamePlate Cost" SortExpression="Name Plate" ItemStyle-HorizontalAlign="Center" >
                      
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                         </asp:BoundField>
                      
                         <asp:TemplateField HeaderText="Det.">
                        <ItemTemplate>
                        <asp:Button ID="btnDetNamePlate" runat="server"  class="button" CommandName="complete" OnClick="btnDetNamePlate_Click"   CommandArgument='<%# Eval("intnameplateid") %>'  Text="Detaills" /></ItemTemplate>
                        </asp:TemplateField>  
                           <asp:TemplateField HeaderText="Reject.">
                        <ItemTemplate><asp:Button ID="btnRejectNameplate" runat="server" class="button" CommandName="complete" OnClick="btnRejectNameplate_Click"   CommandArgument='<%# Eval("intnameplateid") %>'  Text="Reject" /></ItemTemplate></asp:TemplateField>  
                          <asp:BoundField DataField="dtedrcdate" HeaderText="Date of DRC" SortExpression="dteDate108" ItemStyle-Width="120px" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Center" >
                       
<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
                         </asp:BoundField>
                       
                        <asp:BoundField DataField="totaldrc" HeaderText="DRC Cost" SortExpression="DRC" ItemStyle-HorizontalAlign="Center" >
                         
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                         </asp:BoundField>
                         
                         <asp:TemplateField HeaderText="Det.">
                          <ItemTemplate>
                        <asp:Button ID="btnDRC" runat="server" class="button" CommandName="complete" OnClick="btnDRC_Click"  CommandArgument='<%# Eval("intdrcid") %>'   Text="Detaills" /></ItemTemplate>
                        </asp:TemplateField> 
                           <asp:TemplateField HeaderText="Reject.">
                        <ItemTemplate><asp:Button ID="btnRejectDRC" runat="server" class="button" CommandName="complete" OnClick="btnRejectDRC_Click"   CommandArgument='<%# Eval("intdrcid") %>'  Text="Reject" /></ItemTemplate></asp:TemplateField>  
                          <asp:BoundField DataField="monTotal" HeaderText="Total Cost" SortExpression="monTotal" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                         </asp:BoundField>
                          </Columns>
                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                            <SelectedRowStyle BackColor="#008A8C" ForeColor="White" Font-Bold="True" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#0000A9" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#000065" />
                         <HeaderStyle CssClass="GridviewScrollHeader" /><PagerStyle CssClass="GridviewScrollPager" />
                            </asp:GridView>



                </td>


            </tr>

    </table>
                            </div>   


 <%--=========================================End My Code From Here=================================================--%>
  
    </form>
</body>
</html>  
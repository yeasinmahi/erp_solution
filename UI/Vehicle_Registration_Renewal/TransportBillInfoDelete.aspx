<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransportBillInfoDelete.aspx.cs" Inherits="UI.Vehicle_Registration_Renewal.TransportBillInfoDelete" %>

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
                url: "TransportYearlyCostDetaills.aspx/GetAutoserachingAssetName",
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
   <%-- <script> function CloseWindow() {
     window.close();      
 } </script>

<script type="text/javascript">
    function RefreshParent() {
        if (window.opener != null && !window.opener.closed) {
            //window.opener.location.reload();
            window.opener.location.href = window.opener.location.href;
        }
    }
    window.onbeforeunload = RefreshParent;
</script>    --%>

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
            window.open('Detalis_Insurance_UI.aspx', 'sub', "scrollbars=yes,toolbar=0,height=550,width=500,top=5,left=0, resizable=yes, title=Preview");

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
    <div class="tabs_container"> Transport Bill info Inactive :<asp:HiddenField ID="hdnAreamanagerEnrol" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
        
        <asp:HiddenField ID="HiddenUnit" runat="server"/><asp:HiddenField ID="hdnData" runat="server"/>
       
        <hr /></div>
        <table border="0"; style="width:Auto"; >  
        <tr class="tblrowOdd">
        <td colspan="3" style="text-align:right"><asp:Label ID="lblVheicleNumber" CssClass="lbl" runat="server" Text="Vheicle No.:  "></asp:Label></td>
        <td> <asp:TextBox ID="txtVheicleNumber" runat="server" BackColor="#ff6666" AutoPostBack="false" CssClass="txtBox"  Width="200px" ></asp:TextBox></td>
        <td colspan="3" style="text-align:right"><asp:Label ID="lblVheicleCatg" CssClass="lbl" runat="server" Text="Vheicle Category:  "></asp:Label></td>
        <td> <asp:TextBox ID="txtVheicleCatg"  runat="server" ReadOnly="true" AutoPostBack="false" CssClass="txtBox" Width="200px"></asp:TextBox></td>
   
        </tr>
        <tr class="tblroweven">
        <td colspan="3" style="text-align:right"><asp:Label ID="lblAssedCOde" CssClass="lbl" runat="server" Text="Asset Code:  "></asp:Label></td>
        <td> <asp:TextBox ID="txtAssetCode" runat="server" ReadOnly="true"  AutoPostBack="false" CssClass="txtBox" Width="200px"></asp:TextBox></td>
        <td colspan="3" style="text-align:right"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit:  "></asp:Label></td>
        <td><asp:TextBox ID="txtUnit" runat="server" ReadOnly="true"  AutoPostBack="false" CssClass="txtBox" Width="200px"></asp:TextBox></td>
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
       
                    <asp:GridView ID="grdvForRouteTransportcostDet" runat="server" Font-Size="Smaller" AutoGenerateColumns="False" AllowPaging="false"  BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" HeaderStyle-Wrap="true" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdvForRouteTransportcostDet_PageIndexChanging" OnRowDataBound="grdvForRouteTransportcostDet_RowDataBound" style="margin-top: 21px">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                        <asp:BoundField DataField="intsl" HeaderText="Sl" SortExpression="Si" />
                        <asp:BoundField DataField="strjobstation" HeaderText="Jobstation Name" ItemStyle-Width="700px" SortExpression="strjobstation" ItemStyle-HorizontalAlign="Center" />
                         <asp:BoundField DataField="dteRenewaldate" HeaderText="Year" SortExpression="dteRenewaldate" />
                        <asp:BoundField DataField="dteDate78" HeaderText="Registration   Date" SortExpression="dteDate78" ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:yyyy-MM-dd}" />
                        <asp:BoundField DataField="id78" HeaderText="Regsid" Visible="false" SortExpression="310078" />
                          <asp:BoundField DataField="aprv78" HeaderText="f" Visible="false" SortExpression="aprv78" />
                        <asp:TemplateField HeaderText="Status" Visible="true" ControlStyle-Width="75px" >
                        <ItemTemplate><asp:Label ID="Label78" runat="server" Text='<%# Eval("ysnActive78") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                         <asp:BoundField DataField="Registration" HeaderText="Registation Cost" SortExpression="Registration" ItemStyle-HorizontalAlign="Center" />
                        <asp:TemplateField HeaderText="Det.">
                        <ItemTemplate>
                        <asp:Button ID="btnDetRegistration" runat="server" class="button" CommandName="complete" OnClick="btnDetRegistration_Click"   CommandArgument='<%# Eval("id78") %>'  Text='<%# Bind("ysnActive78") %>' /></ItemTemplate>
                        </asp:TemplateField>  
                           
                         <asp:BoundField DataField="dteDate79" HeaderText="Date of Taxtoken" ItemStyle-Width="120px" SortExpression="dteDate79" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Center"  />
                        <asp:BoundField DataField="id79" HeaderText="idTaxtoken" Visible="true" SortExpression="310079" />
                        <asp:BoundField DataField="TAXToken" HeaderText="TAX Token Cost" SortExpression="TAXToken" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="Status" Visible="false" ControlStyle-Width="75px" >
                        <ItemTemplate><asp:Label ID="Label79" runat="server" Text='<%# Eval("ysnActive79") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Det.">
                        <ItemTemplate>
                        <asp:Button ID="btnDetTaxToken" runat="server"  class="button" CommandName="complete" OnClick="btnDetTaxToken_Click"   CommandArgument='<%# Eval("id79") %>'  Text='<%# Bind("ysnActive79") %>' /></ItemTemplate>
                        </asp:TemplateField>  
                          <asp:BoundField DataField="dteDate80" HeaderText="Date of  Fitness" SortExpression="dteDate80" ItemStyle-Width="120px" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="id80" HeaderText="idFitness" Visible="false" SortExpression="310080" />
                        <asp:BoundField DataField="Fitness" HeaderText="Fitness Cost" SortExpression="Fitness" ItemStyle-HorizontalAlign="Center" />
                      <asp:TemplateField HeaderText="Status" Visible="false" ControlStyle-Width="75px" >
                        <ItemTemplate><asp:Label ID="Label80" runat="server" Text='<%# Eval("ysnActive80") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Det.">
                        <ItemTemplate>
                        <asp:Button ID="btnDetFitness" runat="server"  class="button" CommandName="complete" OnClick="btnDetFitness_Click"   CommandArgument='<%# Eval("id80") %>'  Text='<%# Bind("ysnActive80") %>' /></ItemTemplate>
                        </asp:TemplateField>  
                          <asp:BoundField DataField="dteDate81" HeaderText="Date Route Permit" SortExpression="dteDate81" ItemStyle-Width="120px" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="id81" HeaderText="idRoutePermit" Visible="true" SortExpression="310081" />
                        <asp:BoundField DataField="Route Permit" HeaderText="RoutePermit Cost" SortExpression="Route Permit" ItemStyle-HorizontalAlign="Center" />
                        <asp:TemplateField HeaderText="Status" Visible="false" ControlStyle-Width="75px" >
                        <ItemTemplate><asp:Label ID="Label81" runat="server" Text='<%# Eval("ysnActive81") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Det.">
                        <ItemTemplate>
                        <asp:Button ID="btnDetRoutePermit" runat="server"  class="button" CommandName="complete" OnClick="btnDetRoutePermit_Click"   CommandArgument='<%# Eval("id81") %>'  Text='<%# Bind("ysnActive81") %>' /></ItemTemplate>
                        </asp:TemplateField>  
                         <asp:BoundField DataField="dteDate82" HeaderText="Date of Insurance" SortExpression="dteDate82" ItemStyle-Width="120px" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="id82" HeaderText="idInsurance" Visible="false" SortExpression="310082" />
                        <asp:BoundField DataField="Insurance" HeaderText="Insurance Cost" SortExpression="Insurance" ItemStyle-HorizontalAlign="Center" />
                        <asp:TemplateField HeaderText="Status" Visible="false" ControlStyle-Width="75px" >
                        <ItemTemplate><asp:Label ID="Label82" runat="server" Text='<%# Eval("ysnActive82") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Det.">
                        <ItemTemplate>
                        <asp:Button ID="btnDetInsurance" runat="server" class="button" CommandName="complete" OnClick="btnDetInsurance_Click"   CommandArgument='<%# Eval("id82") %>'  Text='<%# Bind("ysnActive82") %>' /></ItemTemplate>
                        </asp:TemplateField>  
                          <asp:BoundField DataField="dteDate83" HeaderText="Date of NamePlate" SortExpression="dteDate83" ItemStyle-Width="120px" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="id83" HeaderText="idNamePlate" Visible="false" SortExpression="310083" />
                        <asp:BoundField DataField="Name Plate" HeaderText="NamePlate Cost" SortExpression="Name Plate" ItemStyle-HorizontalAlign="Center" />
                       <asp:TemplateField HeaderText="Status" Visible="false" ControlStyle-Width="75px" >
                        <ItemTemplate><asp:Label ID="Label83" runat="server" Text='<%# Eval("ysnActive83") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Det.">
                        <ItemTemplate>
                        <asp:Button ID="btnDetNamePlate" runat="server"  class="button" CommandName="complete" OnClick="btnDetNamePlate_Click"   CommandArgument='<%# Eval("id83") %>'  Text='<%# Bind("ysnActive83") %>' /></ItemTemplate>
                        </asp:TemplateField>  

                          <asp:BoundField DataField="dteDate108" HeaderText="Date of DRC" SortExpression="dteDate108" ItemStyle-Width="120px" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="id108" HeaderText="idDRC" Visible="false" SortExpression="310108" />
                        <asp:BoundField DataField="DRC" HeaderText="DRC Cost" SortExpression="DRC" ItemStyle-HorizontalAlign="Center" />
                         <asp:TemplateField HeaderText="Status" Visible="false" ControlStyle-Width="75px" >
                        <ItemTemplate><asp:Label ID="Label108" runat="server" Text='<%# Eval("ysnActive108") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Det.">
                          <ItemTemplate>
                        <asp:Button ID="btnDRC" runat="server" class="button" CommandName="complete" OnClick="btnDRC_Click"   CommandArgument='<%# Eval("id108") %>'   Text='<%# Bind("ysnActive108") %>' /></ItemTemplate>
                        </asp:TemplateField> 
                          <asp:BoundField DataField="deccost" HeaderText="Total Cost" SortExpression="deccost" ItemStyle-HorizontalAlign="Center" />
                         
                        
                
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
  
    </form>
</body>
</html>  

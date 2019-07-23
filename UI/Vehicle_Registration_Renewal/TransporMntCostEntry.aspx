<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransporMntCostEntry.aspx.cs" Inherits="UI.Vehicle_Registration_Renewal.TransporMntCostEntry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="ScriptReferenceProfiler" Namespace="ScriptReferenceProfiler" TagPrefix="cc2" %>
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
                url: "TransporMntCostEntry.aspx/GetAutoserachingVheicleName",
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
    <script type="text/javascript">
       
        function Confirm() {
            document.getElementById("hdnconfirm").value = "0";
           
            var txtDteFrom = document.forms["frmpdv"]["txtEffectiveDate"].value;
            var txtvhcl = document.forms["frmpdv"]["txtVheicleNumber"].value;

            if (txtDteFrom == null || txtDteFrom == "") {
                alert("From date must be filled by valid formate (yyyy-MM-dd).");
                document.getElementById("txtEffectiveDate").focus();
            }
            else if (txtvhcl == null || txtvhcl == "") {
                alert("From date must be filled by valid formate (yyyy-MM-dd).");
                document.getElementById("txtVheicleNumber").focus();
            }
           

            else {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
            }
        }
            
          
</script>
    <script type="text/javascript">
            function isNumber(evt) {
                var iKeyCode = (evt.which) ? evt.which : evt.keyCode
                if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57))
                    return false;

                return true;
            }
            function RemoveRow(item) {
                var table = document.getElementById('GridView1');
                table.deleteRow(item.parentNode.parentNode.rowIndex);
                return false;
            }
            function sum() {
                var txtDriverAllowance1 = document.getElementById('txtDriverAllowance').value;
                var txtMntcostfactory1 = document.getElementById('txtMntcostfactory').value;
                var txtMntcostHO1 = document.getElementById('txtMntcostHO').value;
                var txtMntWSHP1 = document.getElementById('txtMntWSHP').value;

                if (txtDriverAllowance1 == "")
                    txtDriverAllowance1 = 0;
                if (txtMntcostfactory1 == "")
                    txtMntcostfactory1 = 0;
                if (txtMntcostHO1 == "")
                    txtMntcostHO1 = 0;
                if (txtMntWSHP1 == "")
                    txtMntWSHP1 = 0;
                var result = parseInt(txtDriverAllowance1) + parseInt(txtMntcostfactory1) + parseInt(txtMntcostHO1) + parseInt(txtMntWSHP1);
                if (!isNaN(result)) {
                    document.getElementById('txtTotal').value = result;
                }
            }



            </script>

    
</head>
<body>
    <form id="frmpdv" runat="server">
  <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
        <CompositeScript><Scripts>
        <asp:ScriptReference name="MicrosoftAjax.js"/>
		<asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
		<asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Common.DateTime.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Animation.AnimationBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="PopupExtender.PopupBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Common.Threading.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Calendar.CalendarBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
        </Scripts></CompositeScript>
    </asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate> <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
          <div class="leaveApplication_container"> 
    <div class="tabs_container"> Transport Bill info Inactive :<asp:HiddenField ID="hdnAreamanagerEnrol" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
        <asp:HiddenField ID="hdnconfirm" runat="server" />
        <asp:HiddenField ID="HiddenUnit" runat="server"/><asp:HiddenField ID="hdnData" runat="server"/>
       
        <hr /></div>
        <table border="0"; style="width:Auto"; >  
            <tr>
                 <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date:  "></asp:Label></td>
                <td>
          <asp:TextBox ID="txtEffectiveDate" runat="server" CssClass="txtBox" Width="200px" Enabled="true" autocomplete="off"></asp:TextBox>
         <cc1:CalendarExtender ID="CFD" runat="server" Format="yyyy-MM-dd" TargetControlID="txtEffectiveDate"></cc1:CalendarExtender>
            </td>
                 <td style="text-align:right"><asp:Label ID="lblVheicleNumber" CssClass="lbl" runat="server" Text="Vheicle No.:  "></asp:Label></td>
        <td> <asp:TextBox ID="txtVheicleNumber" runat="server" BackColor="#ff6666" AutoPostBack="false" CssClass="txtBox"  Width="200px" ></asp:TextBox></td>
                    </tr>
            <tr class="tblroweven">
        <td style="text-align:right"><asp:Label ID="lbltype" CssClass="lbl" runat="server" Text="Type:  "></asp:Label></td>
        <td> <asp:TextBox ID="txttype" runat="server" ReadOnly="true"  AutoPostBack="false" CssClass="txtBox" Width="200px"></asp:TextBox></td>
        <td  style="text-align:right"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit:  "></asp:Label></td>
        <td><asp:TextBox ID="txtUnit" runat="server" ReadOnly="true"  AutoPostBack="false" CssClass="txtBox" Width="200px"></asp:TextBox></td>
        </tr>
        <tr class="tblrowOdd">
       
        <td  style="text-align:right"><asp:Label ID="lblDriverAllowancce" CssClass="lbl" runat="server" Text="Driver Allowance:  "></asp:Label></td>
        <td> <asp:TextBox ID="txtDriverAllowance"  runat="server" AutoPostBack="false" CssClass="txtBox" Width="200px"></asp:TextBox></td>
   <td style="text-align:right"> <asp:Label ID="lblBusFair" runat="server" CssClass="lbl" Text="Factory Mnt. Cost:  "></asp:Label> </td>
                 <td><asp:TextBox ID="txtMntcostfactory" runat="server" onkeyup="sum();" AutoPostBack="false" CssClass="txtBox"  TextMode="Number" Width="200px" onkeypress="javascript:return isNumber (event)"></asp:TextBox></td>
        </tr>
        
            <tr class="tblroweven">
                 
                 
                 <td style="text-align:right"><asp:Label ID="lblRickshaw" runat="server" CssClass="lbl" Text="H.O Mnt. Cost:  "></asp:Label> </td>
                 <td><asp:TextBox ID="txtMntcostHO" runat="server" onkeyup="sum();" AutoPostBack="false" CssClass="txtBox"  TextMode="Number" Width="200px" onkeypress="javascript:return isNumber (event)"></asp:TextBox></td>
                 <td style="text-align:right"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="C.Workshop Mnt.Cost:  "></asp:Label></td>
                 <td><asp:TextBox ID="txtMntWSHP" runat="server" onkeyup="sum();" AutoPostBack="false" CssClass="txtBox" TextMode="Number" Width="200px" onkeypress="javascript:return isNumber (event)"></asp:TextBox> </td>
             </tr>
            <tr>
                 
               <td style="text-align:right"><asp:Label ID="lblRemarks" runat="server" CssClass="lbl" Text="Remarks:  "></asp:Label> </td>
                 <td> <asp:TextBox ID="textremarks" runat="server" CssClass="txtBox" TextMode="MultiLine" Width="200px"></asp:TextBox> </td>
                <td style="text-align:right"> <asp:Label ID="lblTotal" runat="server" CssClass="lbl" Text="Total Cost :  "></asp:Label> </td>
                 <td><asp:TextBox ID="txtTotal" runat="server" onkeyup="sum();" AutoPostBack="false" CssClass="txtBox" Enabled="false" TextMode="Number" Width="200px" onkeypress="javascript:return isNumber (event)" ></asp:TextBox></td>
            </tr>


    <tr class="tblrowOdd">
        <td> <asp:Button ID="btnAdd" runat="server" Text="Add" Width="100px" OnClientClick = "Confirm()" OnClick="btnAdd_Click" /></td> 
    <td> <asp:Button ID="btnSubmit" runat="server" BackColor="#ffcccc" Font-Bold="true" Text="Submit" OnClick="btnSubmit_Click" OnClientClick = "Confirm()" /> </td>
    
    </tr>


</table>               
</div>

        <div class="leaveApplication_container">
            <table>
             <tr class="tblroweven">
                <td>
                    <asp:GridView ID="grdvMntcostentry" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
                    BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="grdvMntcostentry_RowDataBound" OnRowDeleting="grdvMntcostentry_RowDeleting">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                        
                        <Columns>
                            <asp:TemplateField  HeaderText="SL."><ItemTemplate><%# Container.DataItemIndex + 1 %><asp:HiddenField ID="hdnSL" runat="server" Value='<%# Bind("BillDate") %>' /></ItemTemplate></asp:TemplateField> 
                            <asp:BoundField DataField="BillDate" HeaderText="Bill Date" SortExpression="dteBillDate" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            <asp:TemplateField HeaderText="Driver Allowance" HeaderStyle-HorizontalAlign="Center" SortExpression="busfair">
                            <ItemTemplate><asp:Label ID="lbldrvallownce" runat="server" Text='<%# (""+Eval("drvallown")) %>'></asp:Label></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="120px"/><FooterTemplate><asp:Label ID="lbldrvallownce1" runat="server" Font-Bold="true"  Text='<%# drvallow %>'  /></FooterTemplate></asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Factory Mnt." HeaderStyle-HorizontalAlign="Center" SortExpression="Rickfai">
                            <ItemTemplate><asp:Label ID="lblfactorymnt" runat="server" Text='<%# (""+Eval("factmnt")) %>'></asp:Label></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="120px"/><FooterTemplate><asp:Label ID="lblfactorymnt1" runat="server" Font-Bold="true"  Text='<%# factmnt %>'  /></FooterTemplate></asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="H.O Mnt. Cost" HeaderStyle-HorizontalAlign="Center" SortExpression="cngfair">
                            <ItemTemplate><asp:Label ID="lblhomnt" runat="server" Text='<%# (""+Eval("homnt")) %>'></asp:Label></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="120px"/><FooterTemplate><asp:Label ID="lblhomnt1" runat="server" Font-Bold="true" Text='<%# homnts %>' /></FooterTemplate></asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Central W. Shop" HeaderStyle-HorizontalAlign="Center" SortExpression="trainfair">
                            <ItemTemplate><asp:Label ID="lblcworkshp" runat="server" Text='<%# (""+Eval("workmnt")) %>'></asp:Label></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="120px"/><FooterTemplate><asp:Label ID="lblcworkshp1" runat="server" Font-Bold="true"   Text='<%# workshpmnt %>'/></FooterTemplate></asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="remarks" SortExpression="remarks"><ItemTemplate><asp:Label ID="lblremarkst" runat="server" Text='<%# Bind("remarks") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="200px"/><FooterTemplate><div style="padding:0 0 5px 0"><asp:Label ID="lbl" runat="server" Text="Grand-Total :" /></div>
                       </FooterTemplate></asp:TemplateField>     
                      <asp:TemplateField HeaderText="totalcost" ItemStyle-HorizontalAlign="right" SortExpression="totalcost" >
                            <ItemTemplate><asp:Label ID="lblGrandTotal" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("grandtototal"))) %>'></asp:Label></ItemTemplate>
                            <ItemStyle HorizontalAlign="right" Width="90px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# grandtotal %>' /></FooterTemplate></asp:TemplateField>
                            
                            <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" /> 

                        </Columns>




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
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransportVheicleInfoUpdate.aspx.cs" Inherits="UI.Transport.TransportVheicleInfoUpdate" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head runat="server"><title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" /> 
     <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>   
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../../Content/JS/CustomizeScript.js"></script>
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/Gridstyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/Application.css" rel="stylesheet" />
  
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
                url: "TransportVheicleInfoUpdate.aspx/GetAutoserachingAssetName",
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
        function ValidationBasicInfoRegion() {
            document.getElementById("hdnconfirm").value = "0";
            var txtRegion = document.forms["frmPurchase"]["txtVheicleNumber"].value;
            if (txtRegion == null || txtRegion == "") {
                document.getElementById("hdnconfirm").value = "0";
                alert("Please Vehicle No Entry !");
            }
            else {  document.getElementById("hdnconfirm").value = "1"; }
        }

    </script>

    </head>
<body>
    <form id="frmPurchase" runat="server">
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hdndtechallandate" runat="server" /><asp:HiddenField ID="hdnid" runat="server" />
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnperVat" runat="server" /><asp:HiddenField ID="hdnconfirm" runat="server" />
    <asp:HiddenField ID="hdnVatAccount" runat="server" /><asp:HiddenField ID="hdnVatRegNo" runat="server" />
    <asp:HiddenField ID="hdnAccno" runat="server" /><asp:HiddenField ID="hdnuom" runat="server" /> <asp:HiddenField ID="hdnysnFactory" runat="server" />
    <asp:HiddenField ID="hdnEnroll" runat="server" /> <asp:HiddenField ID="hdnitemid" runat="server" /> <asp:HiddenField ID="hdnCustAddress" runat="server" />
   
    <table>
     <tr><td style="text-align:center; padding: 0px 0px 5px 0px;">&nbsp;</td></tr>
     <tr><td style="text-align:center; padding: 0px 0px 20px 0px;"><asp:Label ID="lblHeading" runat="server" Text="Vheicle Info Update" CssClass="lbl" Font-Size="16px"></asp:Label>                                                                                       
    <hr /> </td></tr><tr><td>
     <table  class="tbldecoration" style="width:auto; float:left;">  
     <tr>
        <td>Unit</td><td>:</td>
        <td>    <asp:DropDownList ID="drdlUnit" runat="server" DataSourceID="odsUnit" DataTextField="strUnit" CssClass="ddList" DataValueField="intUnitID" OnSelectedIndexChanged="drdlUnit_SelectedIndexChanged"></asp:DropDownList> 
                
                <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="getUnitName" TypeName="SAD_BLL.Customer.Report.StatementC"></asp:ObjectDataSource></td>
        <td>Vehicle Type</td>
        <td>:</td>
        <td><asp:DropDownList ID="ddlType" CssClass="ddllist" runat="server" DataSourceID="odsVhclType" DataTextField="strType" DataValueField="intTypeId"  ></asp:DropDownList>
            <asp:ObjectDataSource ID="odsVhclType" runat="server" SelectMethod="getVehicletype" TypeName="SAD_BLL.Transport.NewVehicleBLL">
                <SelectParameters>
                    <asp:ControlParameter ControlID="drdlUnit" Name="unitid" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
         </td>
        <td>Location</td>
        <td>:</td>
        <td><asp:DropDownList ID="ddlLocation" runat="server" CssClass="ddllist" DataSourceID="odslocationid" DataTextField="strName" DataValueField="intid"> </asp:DropDownList> 
            <asp:ObjectDataSource ID="odslocationid" runat="server" SelectMethod="getLocation" TypeName="SAD_BLL.Transport.NewVehicleBLL">
                <SelectParameters>
                    <asp:ControlParameter ControlID="drdlUnit" Name="unitid" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
         </td>
     </tr>
     <tr><td>Vehicle No</td><td class="auto-style1">:</td>
        <td > 
            <asp:TextBox ID="txtVheicleNumber" runat="server"  BackColor="#ffff99"  AutoPostBack="true" CssClass="txtBox"  Width="200px" OnTextChanged="txtVheicleNumber_TextChanged"></asp:TextBox> </td>
        <td >Driver Name</td>
        <td >:</td>
       <%-- <td > <asp:TextBox ID="txtDriverName" runat="server"  Width="180px" ></asp:TextBox>
       
        </td>--%>
          <td > <asp:TextBox ID="txtDriverName" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" Width="180px" ></asp:TextBox>
        <cc1:AutoCompleteExtender ID="empsearch" runat="server" TargetControlID="txtdrivername"
        ServiceMethod="EmployeeSearch" MinimumPrefixLength="1" CompletionSetCount="1"
        CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
        </cc1:AutoCompleteExtender>
        </td>


        <td >Driver Contact</td>  
        <td>:</td>
        <td ><asp:TextBox ID="txtDriverContact" CssClass="txtBox" runat="server"></asp:TextBox></td>
     </tr> 
     <tr><td>Driver NID</td><td class="auto-style1">:</td>
        <td><asp:TextBox ID="txtDriverNId" runat="server" AutoPostBack="true" CssClass="txtBox" MaxLength="50"></asp:TextBox></td>       
        <td>Helper Name</td>
        <td>:</td>
        <td><asp:TextBox ID="txthelperName" runat="server" CssClass="txtBox" MaxLength="50"></asp:TextBox>
      
        </td>
        <td>Lisence No</td>
        <td>:</td>
        <td><asp:TextBox ID="txtLisence" CssClass="txtBox"   MaxLength="10" runat="server"></asp:TextBox></td>
     </tr>
     <tr><td> Driver DA</td><td>:</td>
        <td><asp:TextBox ID="txtDriverDA" runat="server"  CssClass="txtBox" MaxLength="50"></asp:TextBox></td>
        <td> Helper DA</td>
        <td>:</td>
        <td><asp:TextBox ID="txtHelperdA" runat="server"  CssClass="txtBox" MaxLength="50"></asp:TextBox></td>
        <td>Down Trip Allowance</td> 
        <td>:</td>
        <td><asp:TextBox ID="txtDowntripAllowance" runat="server"  CssClass="txtBox" MaxLength="50"></asp:TextBox></td>
    </tr>
     <tr><td> Down Trip DA</td><td>:</td>
        <td><asp:TextBox ID="txtDownTripDA" runat="server"  CssClass="txtBox" MaxLength="50"></asp:TextBox></td>
        <td>   Millage Allowance 100KM</td>
        <td>:</td>
        <td><asp:TextBox ID="MA100KM" runat="server" CssClass="txtBox" MaxLength="50"></asp:TextBox></td>
        <td>Millage Allowance 100KM Above</td> 
        <td>:</td>
        <td><asp:TextBox ID="txtMillageAllowance100KMAbove" runat="server"  CssClass="txtBox" MaxLength="50"></asp:TextBox></td>
    </tr>
     <tr><td> Millage Local</td><td>:</td>
        <td><asp:TextBox ID="txtMillageLocal" runat="server"  CssClass="txtBox" MaxLength="50"></asp:TextBox></td>
        <td>   Millage Outstation</td>
         <td>:</td>
        <td><asp:TextBox ID="txtOutstation" runat="server"  CssClass="txtBox" MaxLength="50"></asp:TextBox></td>
        <td>CNG Allowance</td> 
        <td>:</td>
        <td><asp:TextBox ID="txtCNGAllowance" runat="server"  CssClass="txtBox" MaxLength="50"></asp:TextBox></td>
    </tr>
     <tr><td> Disel Per KM Outstation</td><td>:</td>
        <td><asp:TextBox ID="txtDieselPerKMOutsation" runat="server"  CssClass="txtBox" MaxLength="50"></asp:TextBox></td>
        <td> CNG Per KM Outstation</td>
        <td>:</td>
        <td><asp:TextBox ID="txtcngperkmoutstation" runat="server" CssClass="txtBox" MaxLength="50"></asp:TextBox></td>
        <td>UOM</td> 
        <td>:</td>
        <td><asp:DropDownList ID="ddlUOM" runat="server" CssClass="ddllist">
        <asp:ListItem Value="1049">Ton</asp:ListItem>
        <asp:ListItem Value="1050">KG</asp:ListItem>
        <asp:ListItem Value="1055">SFT</asp:ListItem>
        </asp:DropDownList></td>
    </tr>
     <tr><td> Disel Per KM Litter</td><td>:</td>
        <td><asp:TextBox ID="txtDiselPerKMLitter" runat="server"  CssClass="txtBox" MaxLength="50"></asp:TextBox></td>
        <td> Down Trip Disel Per KM</td>
        <td>:</td>
        <td><asp:TextBox ID="txtDownTripDiselPerKM" runat="server" CssClass="txtBox" MaxLength="50"></asp:TextBox></td>
        <td>CNG Per KM</td> 
        <td>:</td>
        <td><asp:TextBox ID="txtCNGPerKM" runat="server" CssClass="txtBox" MaxLength="50"></asp:TextBox></td>
    </tr>
     <tr>
       
     <td>
       
        <asp:Button ID="btnUpdate"  class="myButton" Font-Bold="true" runat="server" OnClientClick="return Validation();" Text="Updae Info" OnClick="btnUpdate_Click" /></td>
    </tr>
     <tr><td colspan="9"><hr /></td></tr> 
     <tr><td>&nbsp;</td><td></td>
     </tr>
     </table>
     </td></tr>
     <tr><td>
    
    </td></tr></table>
    </div>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script type="text/javascript">
        function Validation() {
            var vheicleNumber = document.getElementById("txtVheicleNumber").value;
            var driverName = document.getElementById("txtDriverName").value;
            if (vheicleNumber == null || vheicleNumber == '') {
                alert("vehicle number can not be empty");
                return false;
            }
            if (driverName == null || driverName == '') {
                alert("driver name can not be empty");
                return false;
            }
            return true;
        }
    </script>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoteTADAInformationUpdate.aspx.cs" Inherits="UI.SAD.Order.RemoteTADAInformationUpdate"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="ScriptReferenceProfiler" Namespace="ScriptReferenceProfiler" TagPrefix="cc2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>  
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
  

     <script type="text/javascript">
         $(document).ready(function () {
             SearchText();
         });
         function Changed() {
             document.getElementById('hdfSearchBoxTextChange').value = 'true';
         }
         function SearchText() {
             $("#txtEmployeeSearch").autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         type: "POST",
                         contentType: "application/json;",
                         url: "RemoteTADAInformationUpdate.aspx/getemplontadasupervisor",
                         data: "{'strSearchKey':'" + document.getElementById('txtEmployeeSearch').value + "'}",
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
    <div class="tabs_container"> TA - DA information update (Before approve by Supervisor)  :  <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
        <asp:HiddenField ID="ApproverEnrol" runat="server"/><asp:HiddenField ID="hdnAreamanagerEnrol" runat="server"/>
        <asp:HiddenField ID="hdfSearchBoxTextChange" runat="server"/><asp:HiddenField ID="hdnAction" runat="server"/>
        <asp:HiddenField ID="HiddenField1" runat="server"/><asp:HiddenField ID="hdnInsertbyenrol" runat="server"/><asp:HiddenField ID="HiddenUnit" runat="server"/>
        <asp:HiddenField ID="hdnJobstationid" runat="server"/>
    </div>

        <table border="0"; style="width:Auto"; >    

         <tr>
                <td style="text-align:right;"><asp:Label ID="lbltype" CssClass="lbl" runat="server" Text="User Type:  "></asp:Label>
                <td><asp:RadioButtonList ID="rdbUserOption" runat="server" OnSelectedIndexChanged="rdbUserOption_SelectedIndexChanged"
                RepeatDirection="Horizontal" AutoPostBack="true">
                <asp:ListItem Text="Own" Value="0" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Other" Value="1"></asp:ListItem>
                 
                </asp:RadioButtonList>
                </td>  

                </tr>
        <tr class="tblroweven">
       
            <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" autocomplete="off"></asp:TextBox>
                    <cc1:CalendarExtender ID="CES" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender>                                                        
                </td>
 
        </tr>
        </tr>
                

         <tr class="tblrowOdd"><td style="text-align:right;"><asp:Label ID="lblfullname" CssClass="lbl" runat="server"  Text="Employee Name: "></asp:Label></td>
          <td>  <asp:TextBox ID="txtEmployeeSearch" runat="server" CssClass="txtBox" Width="350px" AutoPostBack="true" onchange="javascript: Changed();"></asp:TextBox>
            <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="HiddenField2" runat="server" />
        </td>
           

        <tr class="tblrowOdd"><td style="text-align:right" colspan="2"> <asp:Button ID="btnApprTADAFoBikeCarUser" runat="server" Text="Show Bill Info" OnClick="btnApprTADAFoBikeCarUser_Click"/></td> 
           
                                                                                                                        
        </tr>
            </table>
            

           </div>
             <div class="leaveApplication_container"> 
                 <table>
              
          <tr class="tblroweven"><td>
              </td>
         </tr>          
         <tr class="tblrowOdd" >
             <td>
                 <asp:GridView ID="grdvForUpdateTADABikeCarUser" runat="server" AutoGenerateColumns="False" PageSize="3000" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" HeaderStyle-Wrap="true" OnRowDataBound="grdvForUpdateTADABikeCarUser_RowDataBound" GridLines="Vertical">
                     <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                       
                    <asp:TemplateField HeaderText="">
                    <EditItemTemplate><asp:CheckBox ID="chkbx" runat="server" Checked="false"/></EditItemTemplate>
                    <ItemTemplate><asp:CheckBox ID="chkbx" runat="server" Checked="false"/>
                    <asp:HiddenField ID="hdnenroll" runat="server" Value='<%# Eval("pkrowsl") %>'/>
                    </ItemTemplate></asp:TemplateField>

                   <%-- <asp:BoundField DataField="Id" HeaderText="Sl" SortExpression="intid" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>--%>


                    <asp:TemplateField HeaderText="PK ID" SortExpression="PkID">
                    <ItemTemplate>
                    <asp:HiddenField   ID="hdBillDate"   runat="server" Value='<%# Bind("PkID", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtPkID"   CssClass="txtBox" runat="server" Width="35px" TextMode="SingleLine" ReadOnly="true"  Text='<%# Bind("PkID") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="From Date" SortExpression="dteFromDate">
                    <ItemTemplate>
                    <asp:HiddenField   ID="hddteFromdateNoBikeDet"   runat="server" Value='<%# Bind("dteFromdate", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="dteFromdateNoBikeDet"   CssClass="txtBox" runat="server" Width="150px" TextMode="Date"  Text='<%# Bind("dteFromdate") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="70px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Employee  Name" SortExpression="strEmplName">
                    <ItemTemplate>
                    <asp:HiddenField  ID="hdEmpName" runat="server"  Value='<%# Bind("strNam", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="strNamNoBikeDet" CssClass="txtBox" runat="server" Width="70px" TextMode="SingleLine" Text='<%# Bind("strNam") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="70px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Start Mlg" SortExpression="decstarmil">
                    <ItemTemplate>

                    <asp:HiddenField  ID="hdstartmilage"  runat="server" Value='<%# Bind("decStartMilageT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecStartMilageT"  CssClass="txtBox" runat="server" Width="50px"  Text='<%# Bind("decStartMilageT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                    </asp:TemplateField>
                      
                    <asp:TemplateField HeaderText="End Mlg" SortExpression="decEndmil">
                    <ItemTemplate>
                    <asp:HiddenField  ID="hdEndmilage" runat="server" Value='<%# Bind("decEndMilageT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecEndMilageT"   CssClass="txtBox" runat="server" Width="50px"  Text='<%# Bind("decEndMilageT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cons Mlg" SortExpression="consumedkm">
                    <ItemTemplate>
                    <asp:HiddenField  ID="hdConsumedkm" runat="server" Value='<%# Bind("decConsumedKmT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecConsumedKmT"   CssClass="txtBox" runat="server" Width="35px"  Text='<%# Bind("decConsumedKmT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Supporting" SortExpression="strsuppor">

                    <ItemTemplate>
                    <asp:HiddenField  ID="hdstrsuppor" runat="server" Value='<%# Bind("strSupportingNoT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtstrSupportingNoT"  CssClass="txtBox" runat="server" Width="50px" TextMode="MultiLine" Text='<%# Bind("strSupportingNoT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qnt Petrol" SortExpression="decpet">
                    <ItemTemplate>
                    <asp:HiddenField  ID="hdQpetr"  runat="server" Value='<%# Bind("decQntPetrolT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecQntPetrolT"   CssClass="txtBox" runat="server" Width="35px"  Text='<%# Bind("decQntPetrolT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cost Petrol" SortExpression="costpet">
                    <ItemTemplate>
                    <asp:HiddenField  ID="hdnCostpetr" runat="server" Value='<%# Bind("decCostPetrolT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecCostPetrolT"  OnTextChanged="txtdecCostPetrolT_TextChanged"  CssClass="txtBox" runat="server" Width="35px"  Text='<%# Bind("decCostPetrolT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qnt Octen" SortExpression="decQntOcten">
                    <ItemTemplate>
                    <asp:HiddenField  ID="hdQntOcten" runat="server" Value='<%# Bind("decQntOctenT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecQntOctenT"   CssClass="txtBox" runat="server" Width="35px"  Text='<%# Bind("decQntOctenT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cost Octen" SortExpression="decCostOcten">
                    <ItemTemplate>
                    <asp:HiddenField  ID="hdCostocte" runat="server" Value='<%# Bind("decCostOctenT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecCostOctenT" OnTextChanged="txtdecCostOctenT_TextChanged"  CssClass="txtBox" runat="server" Width="35px"  Text='<%# Bind("decCostOctenT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qnt CNG" SortExpression="decQntCNG">

                    <ItemTemplate>
                    <asp:HiddenField  ID="hdQCNG" runat="server" Value='<%# Bind("decQntCarbonNitGasT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecQntCarbonNitGasT"  CssClass="txtBox" runat="server" Width="35px"  Text='<%# Bind("decQntCarbonNitGasT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Cost CNG." SortExpression="CostCNG">

                    <ItemTemplate>
                    <asp:HiddenField  ID="hdCostcng" runat="server" Value='<%# Bind("decCostCarbonNitGasT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecCostCarbonNitGasT" OnTextChanged="txtdecCostCarbonNitGasT_TextChanged"  CssClass="txtBox" runat="server" Width="35px"  Text='<%# Bind("decCostCarbonNitGasT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Qnt lubr" SortExpression="decQntLubricant">
                    <ItemTemplate>
                    <asp:HiddenField  ID="hdQlubricantt" runat="server" Value='<%# Bind("decLubricantQnt", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecQntLubricant"  CssClass="txtBox" runat="server" Width="35px"  Text='<%# Bind("decLubricantQnt") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Cost Lubr." SortExpression="decCostLubricant">

                    <ItemTemplate>
                    <asp:HiddenField  ID="hdCostLubricant" runat="server" Value='<%# Bind("lubricantcost", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecCostLubricant" OnTextChanged="txtdecCostLubricant_TextChanged"  CssClass="txtBox" runat="server" Width="35px"  Text='<%# Bind("lubricantcost") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Bus" SortExpression="decBus">
                    <ItemTemplate>

                    <asp:HiddenField  ID="hdBus"  runat="server" Value='<%# Bind("decFareBusAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFareBusAmountT" OnTextChanged="txtdecFareBusAmountT_TextChanged"   CssClass="txtBox" runat="server" Width="35px"  Text='<%# Bind("decFareBusAmountT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                    </asp:TemplateField>
                      
                    <asp:TemplateField HeaderText="Rick" SortExpression="decRick">
                    <ItemTemplate>
                    <asp:HiddenField  ID="hdnRick" runat="server" Value='<%# Bind("decFareRickshawAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFareRickshawAmountT" OnTextChanged="txtdecFareRickshawAmountT_TextChanged"  CssClass="txtBox" runat="server" Width="35px"  Text='<%# Bind("decFareRickshawAmountT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Taxi Cab" SortExpression="decTaxiCab">
                    <ItemTemplate>
                    <asp:HiddenField  ID="hdtaxicab" runat="server" Value='<%# Bind("decFareCNGAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFareCNGAmountT" OnTextChanged="txtdecFareCNGAmountT_TextChanged"  CssClass="txtBox" runat="server" Width="35px"  Text='<%# Bind("decFareCNGAmountT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                    </asp:TemplateField>

                   
                    <asp:TemplateField HeaderText="Other Vhc." SortExpression="decOtherVhc">

                    <ItemTemplate>
                    <asp:HiddenField  ID="hdothevh" runat="server" Value='<%# Bind("decFareOtherVheicleAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFareOtherVheicleAmountT" OnTextChanged="txtdecFareOtherVheicleAmountT_TextChanged"  CssClass="txtBox" runat="server" Width="35px"  Text='<%# Bind("decFareOtherVheicleAmountT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                    </asp:TemplateField>

                  
           
                    <asp:TemplateField HeaderText="Mnt. Cost" SortExpression="decMnt">

                    <ItemTemplate>
                    <asp:HiddenField  ID="hdMntcost" runat="server" Value='<%# Bind("decCostAmountMaintenaceT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecCostAmountMaintenaceT" OnTextChanged="txtdecCostAmountMaintenaceT_TextChanged"  CssClass="txtBox" runat="server" Width="35px"  Text='<%# Bind("decCostAmountMaintenaceT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Ferry Toll." SortExpression="ferytol">

                    <ItemTemplate>
                    <asp:HiddenField  ID="hdoFerrytoll" runat="server" Value='<%# Bind("decFeryTollCostT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFeryTollCostT" OnTextChanged="txtdecFeryTollCostT_TextChanged"  CssClass="txtBox" runat="server" Width="35px"  Text='<%# Bind("decFeryTollCostT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                    </asp:TemplateField>
              
                         
                         
                                   

                    <asp:TemplateField HeaderText="Own DA." SortExpression="decownda">

                    <ItemTemplate>
                    <asp:HiddenField  ID="hddecownda" runat="server" Value='<%# Bind("decDAAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecDAAmountT" OnTextChanged="txtdecDAAmountT_TextChanged"  CssClass="txtBox" runat="server" Width="35px"  Text='<%# Bind("decDAAmountT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Driver DA." SortExpression="decDriver">

                    <ItemTemplate>
                    <asp:HiddenField  ID="hddecOtherda" runat="server" Value='<%# Bind("decDriverDACostT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecDriverDACostT" OnTextChanged="txtdecDriverDACostT_TextChanged"  CssClass="txtBox" runat="server" Width="35px"  Text='<%# Bind("decDriverDACostT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Own Hotel" SortExpression="decownhotel">

                    <ItemTemplate>
                    <asp:HiddenField  ID="hddechotel" runat="server" Value='<%# Bind("decHotelBillAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecHotelBillAmountT" OnTextChanged="txtdecHotelBillAmountT_TextChanged"  CssClass="txtBox" runat="server" Width="35px"  Text='<%# Bind("decHotelBillAmountT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Driver Hotel" SortExpression="decdrivhotel">

                    <ItemTemplate>
                    <asp:HiddenField  ID="hddrivehote" runat="server" Value='<%# Bind("decDriverHotelBillAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecDriverHotelBillAmountT" OnTextChanged="txtdecDriverHotelBillAmountT_TextChanged"  CssClass="txtBox" runat="server" Width="35px"  Text='<%# Bind("decDriverHotelBillAmountT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                    </asp:TemplateField>

                   
                    <asp:TemplateField HeaderText="Photo copy" SortExpression="decPhotocopy">

                    <ItemTemplate>
                    <asp:HiddenField  ID="hdPhotocpy" runat="server" Value='<%# Bind("decPhotoCopyCostT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecPhotoCopyCostT" OnTextChanged="txtdecPhotoCopyCostT_TextChanged" CssClass="txtBox" runat="server" Width="35px"  Text='<%# Bind("decPhotoCopyCostT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Courier" SortExpression="decCourier">

                    <ItemTemplate>
                    <asp:HiddenField  ID="hddCourier" runat="server" Value='<%# Bind("decCourierCostT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecCourierCostT" OnTextChanged="txtdecCourierCostT_TextChanged"  CssClass="txtBox" runat="server" Width="35px"  Text='<%# Bind("decCourierCostT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                    </asp:TemplateField>


                     
                    <asp:TemplateField HeaderText="Other Cost" SortExpression="decOtherCostAmount">

                    <ItemTemplate>
                    <asp:HiddenField  ID="hddecOtherCostAmount" runat="server" Value='<%# Bind("decOtherBillAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecOtherBillAmountT" OnTextChanged="txtdecOtherBillAmountT_TextChanged" CssClass="txtBox" runat="server" Width="35px"  Text='<%# Bind("decOtherBillAmountT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                    </asp:TemplateField>

                     
                    <asp:TemplateField HeaderText="Row Total" SortExpression="decrowtotal">

                    <ItemTemplate>
                    <asp:HiddenField  ID="hddecrowtotal" runat="server" Value='<%# Bind("decRowTotalT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecRowTotalT" OnTextChanged="txtdecRowTotalT_TextChanged" CssClass="txtBox" runat="server" Width="35px"  Text='<%# Bind("decRowTotalT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="RowSl" SortExpression="pkrowsl">
                    <ItemTemplate>
                    <asp:HiddenField   ID="hdRowSl"   runat="server" Value='<%# Bind("pkrowsl", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtRowSl"   CssClass="txtBox" runat="server" Width="35px" TextMode="SingleLine" ReadOnly="true"  Text='<%# Bind("pkrowsl") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                    </asp:TemplateField>

              
                  
                    <asp:TemplateField HeaderText="CNG Credit1 Amount" SortExpression="decCngCredit1Amont">

                    <ItemTemplate>
                    <asp:HiddenField  ID="hdndecCngCredit1Amont" runat="server" Value='<%# Bind("decCngCredit1Amont", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecSupplierCNG" OnTextChanged="txtdecSupplierCNG_TextChanged" CssClass="txtBox" runat="server" Width="35px"  Text='<%# Bind("decCngCredit1Amont") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                    </asp:TemplateField>

                     
             
                   <asp:BoundField DataField="strCredit1StationName" HeaderText="CNG Credit1 StationName" SortExpression="strCredit1StationName" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                      <asp:TemplateField HeaderText="Gas Station 1"><ItemTemplate><asp:DropDownList ID="ddlCreditFuelStation1List" runat="server" CssClass="ddList" Width="150px" AutoPostBack="false">
                </asp:DropDownList></ItemTemplate></asp:TemplateField>


                   <asp:TemplateField HeaderText="CNG Credit2 Amount" SortExpression="decCngCredit2Amont">

                    <ItemTemplate>
                    <asp:HiddenField  ID="hdnCNGCredit2Amount" runat="server" Value='<%# Bind("decCngCredit2Amont", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtCNGCredit2AMNT" OnTextChanged="txtdecSupplierCNG_TextChanged" CssClass="txtBox" runat="server" Width="35px"  Text='<%# Bind("decCngCredit2Amont") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                    </asp:TemplateField>

                     
                  

                    <asp:BoundField DataField="strCredit2StationName" HeaderText="CNG Credit2 StationName" SortExpression="strCredit2StationName" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="Gas Station 2"><ItemTemplate><asp:DropDownList ID="ddlCreditFuelStation2List" runat="server" CssClass="ddList" Width="150px" AutoPostBack="false">
                </asp:DropDownList></ItemTemplate></asp:TemplateField>


                   <asp:TemplateField HeaderText="Oil Credit1 Amount" SortExpression="decOilCreditAmount">

                    <ItemTemplate>
                    <asp:HiddenField  ID="hdndecOilCreditAmount" runat="server" Value='<%# Bind("decOilCreditAmount", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtOilCreditAmnt" OnTextChanged="txtdecSupplierCNG_TextChanged" CssClass="txtBox" runat="server" Width="35px"  Text='<%# Bind("decOilCreditAmount") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                    </asp:TemplateField>

                   <asp:BoundField DataField="strOilCreditStationName" HeaderText="Oil Credit StationName" SortExpression="strOilCreditStationName" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>


                <asp:TemplateField HeaderText="Oil Station"><ItemTemplate><asp:DropDownList ID="ddlCreditFuelStation3List" runat="server" CssClass="ddList" Width="150px" AutoPostBack="false">
                </asp:DropDownList></ItemTemplate></asp:TemplateField>

                  <asp:TemplateField HeaderText="PMlg Qnt" SortExpression="decPersonalMilage">

                    <ItemTemplate>
                    <asp:HiddenField  ID="hdndecPersonalMilage" runat="server" Value='<%# Bind("decPersonalMilage", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecPersonalMilage" OnTextChanged="txtdecPersonalMilage_TextChanged" CssClass="txtBox" runat="server" Width="35px"  Text='<%# Bind("decPersonalMilage") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                    </asp:TemplateField>
                         

                    <asp:TemplateField HeaderText=" Mlg. Rate" SortExpression="decMlgRate">

                    <ItemTemplate>
                    <asp:HiddenField  ID="hdndecMlgRate" runat="server" Value='<%# Bind("decMlgRate", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecMlgRate" OnTextChanged="txtdecMlgRate_TextChanged" CssClass="txtBox" runat="server" Width="35px"  Text='<%# Bind("decMlgRate") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                    </asp:TemplateField>

                         
                    


                    <asp:TemplateField HeaderText="P Mlag Total" SortExpression="decPersonalTotalcost">

                    <ItemTemplate>
                    <asp:HiddenField  ID="hdndecPersonalTotalcost" runat="server" Value='<%# Bind("decPersonalTotalcost", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecPersonalTotalcost" OnTextChanged="txtdecPersonalTotalcost_TextChanged" CssClass="txtBox" runat="server" Width="35px"  Text='<%# Bind("decPersonalTotalcost") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="35px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Det.">
                    <ItemTemplate>
                 
                     <asp:Button ID="btnUpdateinf" runat="server" Text="Update" class="button" CommandName="complete" OnClick="btnUpdateinf_Click1"  CommandArgument='<%# Eval("pkrowsl")+","+Eval("PkID")%>'   /></ItemTemplate>
                        
                         </asp:TemplateField>  
                    
                       
                         
                         
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

<%--=========================================End My Code From Here=================================================--%>
   </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

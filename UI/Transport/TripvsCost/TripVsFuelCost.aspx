<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TripVsFuelCost.aspx.cs" Inherits="UI.Transport.TripvsCost.TripVsFuelCost" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html> 
<html> 
<head runat="server"> 
    <title></title> 
    <meta http-equiv="X-UA-Compatible" content="IE=edge" /> 
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" /> 
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" /> 
    <script src="../../Content/JS/datepickr.min.js"></script> 
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" /> 
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" /> 
    <script src="jquery.min.js"></script> 
    <script src="jquery-ui.min.js"></script> 
    <link href="../Content/CSS/GridView.css" rel="stylesheet" />
    <%--<link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />--%> 

    <script type="text/javascript"> 
        function funConfirmAll() { 
            var confirm_value = document.createElement("INPUT"); 
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value"; 
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnConfirm").value = "1"; } 
            else { confirm_value.value = "No"; document.getElementById("hdnConfirm").value = "0"; } 
        }

</script> 
 <%--<script type="text/javascript">
      
    $("[id*=txtAdditional]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') { 
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                    var initialcost = parseFloat($("[id*=lbldecinitialcost]", row).html());
                    var additional = parseFloat($(this).val());
               
                    //if (isssueqty > returnQty) {
                    //     $("[id*=txtReturnQty]", row).val('0'); 
                    //   alert('Please PO Qty Grather then Return Qty');
                    //}
                    //else {
                      
                    //}

                    var finalbill = initialcost + additional;

                }
            } else {
                $(this).val('');
            } 

        });
    </script> --%>

   
    <style type="text/css">
        .auto-style1 {
            height: 59px;
        }
    </style>

   
</head>

<body>

    <form id="frmselfresign" runat="server">

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

    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnConfirm" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
     <asp:HiddenField ID="hdnMrrNo" runat="server" /><asp:HiddenField ID="hdnIndentDate" runat="server" /> 
       <div class="tabs_container" style="text-align:left">Trip Vs Fuel Cost<hr /></div> 
       <table>
        <tr> 
        <td style="text-align:right" class="auto-style1"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit Name:  "></asp:Label></td>
                         
                         <td class="auto-style1"><asp:DropDownList ID="drdlUnitName"  runat="server" DataSourceID="odsUnitNameByEnrol" DataTextField="strUnit" DataValueField="intUnitID" AutoPostBack="true" OnSelectedIndexChanged="drdlUnitName_SelectedIndexChanged"></asp:DropDownList>
            
                 <asp:ObjectDataSource ID="odsUnitNameByEnrol" runat="server" SelectMethod="getUnitNamebyEnrol" TypeName="HR_BLL.TourPlan.TourPlanning">
                     <SelectParameters>
                         <asp:SessionParameter Name="Enrol" SessionField="sesUserID" Type="Int32" />
                     </SelectParameters>
                 </asp:ObjectDataSource>
            </td>
        <td style="text-align:right;" class="auto-style1"><asp:Label ID="lblTripCode" CssClass="lbl" runat="server" Text="Trip No"></asp:Label></td>            
        <td style="text-align:left;" class="auto-style1"  ><asp:TextBox ID="txtTripCode" runat="server"  CssClass="txtBox"   ></asp:TextBox> 
        <asp:Button ID="btnShow" runat="server" Text="Show "  OnClick="btnShow_Click"   /></td>
        
        </tr>  
        <tr><td><asp:Label ID="lblSupp" runat="server"></asp:Label></td></tr>
       </table>
       <table> 
         <tr> 
             <%--tripcode ,strRegno ,dteinsertime ,strdiver ,strhelper ,strcustname ,straddre , declitpertrip ,monpertripcost , dispointid , decdistance ,literround ,decinitialcost--%>
            <td><asp:GridView ID="dgvTripVSFuelCost" runat="server" AutoGenerateColumns="False" ShowFooter="true" ShowHeader="true"  Width="600px"  
            CssClass="GridViewStyle">            
            <HeaderStyle CssClass="HeaderStyle" />  <FooterStyle CssClass="FooterStyle" /> <RowStyle CssClass="RowStyle" />  <PagerStyle CssClass="PagerStyle" /> 
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
  
            <asp:TemplateField HeaderText="Tripcode" SortExpression="tripcode"><ItemTemplate>
            <asp:Label ID="lbltripcode" runat="server" Width="50px" Text='<%# Bind("tripcode") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>
                
            <asp:TemplateField HeaderText="Vheicle" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="strName" >
            <ItemTemplate><asp:Label ID="lblstrRegno" runat="server"  Width="150px" Text='<%# Bind("strRegno") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>  

            <asp:TemplateField HeaderText="Insertime" ItemStyle-HorizontalAlign="right" SortExpression="strUoM" >
            <ItemTemplate><asp:Label ID="lbldteinsertime" runat="server"  Width="90px" Text='<%# Bind("dteinsertime") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Driver" ItemStyle-HorizontalAlign="right" SortExpression="strdiver" >
            <ItemTemplate><asp:Label ID="lblstrdiver" runat="server" Width="50px"  Text='<%# Bind("strdiver") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>

            <asp:TemplateField HeaderText="Helper" ItemStyle-HorizontalAlign="right" SortExpression="strhelper" >
            <ItemTemplate><asp:Label ID="lblstrhelper" runat="server"  Text='<%# Bind("strhelper") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Customer name" ItemStyle-HorizontalAlign="right" SortExpression="intLocationID" >
            <ItemTemplate><asp:Label ID="lblstrcustname" runat="server" Text='<%# Bind("strcustname") %>' ></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 

            <asp:TemplateField HeaderText="Address" ItemStyle-HorizontalAlign="right" SortExpression="returnQty" >
            <ItemTemplate><asp:Label ID="lblstraddre" runat="server" Text='<%# Bind("straddre") %>' ></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 
                 <%--declitpertrip ,monpertripcost , dispointid , decdistance ,literround ,decinitialcost--%>

           <asp:TemplateField HeaderText="declitpertrip" ItemStyle-HorizontalAlign="right" SortExpression="declitpertrip" >
            <ItemTemplate><asp:Label ID="lbldeclitpertrip" runat="server" Text='<%# Bind("declitpertrip") %>' ></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>

                <asp:TemplateField HeaderText="monpertripcost" ItemStyle-HorizontalAlign="right" SortExpression="monpertripcost" >
            <ItemTemplate><asp:Label ID="lblmonpertripcost" runat="server" Text='<%# Bind("monpertripcost") %>' ></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>


              <asp:TemplateField HeaderText="dispointid" ItemStyle-HorizontalAlign="right" SortExpression="dispointid" >
            <ItemTemplate><asp:Label ID="lbldispointid" runat="server" Text='<%# Bind("dispointid") %>' ></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>



                <asp:TemplateField HeaderText="decdistance" ItemStyle-HorizontalAlign="right" SortExpression="decdistance" >
            <ItemTemplate><asp:Label ID="lbldecdistance" runat="server" Text='<%# Bind("decdistance") %>' ></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>



              <asp:TemplateField HeaderText="Initial Cost" ItemStyle-HorizontalAlign="right" SortExpression="decinitialcost" >
            <ItemTemplate><asp:Label ID="lbldecinitialcost" runat="server" Width="50px"  Text='<%# Bind("decinitialcost") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>



             <%--<asp:BoundField DataField="decinitialcost" HeaderText="Initial Cost" SortExpression="decinitialcost" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>--%>
             
                <asp:TemplateField HeaderText="Additional Amount" ItemStyle-HorizontalAlign="right" SortExpression="strCurrencyName" >
            <ItemTemplate><asp:TextBox ID="txtAdditional" runat="server" CssClass="txtBox" Width="50px"   ></asp:TextBox></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 

                <asp:TemplateField HeaderText="Deductional Amount" ItemStyle-HorizontalAlign="right" SortExpression="strCurrencyName" >
            <ItemTemplate><asp:TextBox ID="txtDeductional" runat="server" CssClass="txtBox" Width="50px"   ></asp:TextBox></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 

                <asp:TemplateField HeaderText="Final Cost" ItemStyle-HorizontalAlign="right" SortExpression="strCurrencyName" >
            <ItemTemplate><asp:TextBox ID="txtfinalcost" runat="server" CssClass="txtBox" Width="50px"   ></asp:TextBox></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 

            <asp:TemplateField HeaderText="Resson" ItemStyle-HorizontalAlign="right" SortExpression="strEmployeeName" >
            <ItemTemplate><asp:TextBox ID="txtReson" runat="server" Width="150px"  CssClass="txtBox"   ></asp:TextBox></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 
            <asp:TemplateField HeaderText="Submit">  <ItemTemplate>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit Bill" OnClientClick="funConfirmAll();" OnClick="btnSubmit_Click"    /></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>
            </Columns> 
            </asp:GridView></td> 
        </tr>  
       </table> 
        </div> 
<%--=========================================End My Code From Here=================================================--%>

    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

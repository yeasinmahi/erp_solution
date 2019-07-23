<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepreciationCalculation.aspx.cs" Inherits="UI.Asset.DepreciationCalculation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
 <html xmlns="http://www.w3.org/1999/xhtml">   
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
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
 
    <script>
        function Save() {
            document.getElementById("hdnField").value = "1";
            __doPostBack();
        }

</script>  
    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .ddList {}
        .auto-style1 {
            height: 24px;
        }
        .auto-style2 {
            height: 139px;
        }
        .txtBox {}
        </style>
    </head>
    <body>
    <form id="frmaccountsrealize" runat="server">
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
      <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnsearch" runat="server" />
    <asp:HiddenField ID="hdnEnrollUnit" runat="server" /><asp:HiddenField ID="hdnUnitIDByddl" runat="server" /><asp:HiddenField ID="hdnBankID" runat="server" />
    <asp:HiddenField ID="hfEmployeeIdp" runat="server" /><asp:HiddenField ID="hdnwh" runat="server" />       
    <asp:HiddenField ID="HdnServiceCost" runat="server" />   <asp:HiddenField ID="hdnRhdfSearchBox" runat="server" />   
    <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="yt" runat="server" /></td>

             
    <div class="tabs_container" align="Center" >Asset Dpreciation </div>
   
                <table class="tblrowodd" >                       
                <tr><td style="text-align:right;"><asp:Label ID="LblContryOrigin" CssClass="lbl" runat="server" Text="Unit : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" CssClass="ddList" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged" ></asp:DropDownList> </td>
                <td style="text-align:right;"><asp:Label ID="LblDtePO" runat="server" CssClass="lbl" Text="From Date"  Font-Bold="true"></asp:Label></td>
                <td> <asp:TextBox ID="TxtDteStart" runat="server" Font-Bold="true"  CssClass="txtBox" autocomplete="off" ></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender8" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDteStart"> </cc1:CalendarExtender>                          
                             
                <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="To Date"  Font-Bold="true"></asp:Label></td>
                <td><asp:TextBox ID="TxtDteEnd" runat="server" Font-Bold="true"  CssClass="txtBox" autocomplete="off"  ></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDteEnd"> </cc1:CalendarExtender></td></tr> 
               <tr><td></td><td></td><td></td><td></td><td></td>                 
               <td><asp:Button ID="BtnShow" runat="server" Text="Show" OnClick="BtnShow_Click"  />
               <asp:Button ID="BtnSumbit" runat="server" Text="Submit" OnClick="BtnSumbit_Click" /></td></tr>
               </table>
                <table>             
                <tr> <td style=" text-align:start; vertical-align:top"><asp:GridView ID="dgvGridView" OnDataBound = "OnDataBound" runat="server" AutoGenerateColumns="False"  Font-Size="12px"  >
                
                <Columns>
                 <asp:TemplateField HeaderText="SL.N"> 
                 <ItemTemplate>  <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>  
                <asp:TemplateField HeaderText="COAName" Visible="True">                                 
                <ItemTemplate><asp:Label ID="strCOACode" runat="server" Text='<%# Eval("strGlobalCOACode") %>'></asp:Label></ItemTemplate> </asp:TemplateField>
                <asp:TemplateField HeaderText="COACode" Visible="true">                                 
                <ItemTemplate><asp:Label ID="lblGlobalCOAID" runat="server" Text='<%# Eval("intGlobalCOAID") %>'></asp:Label></ItemTemplate> </asp:TemplateField>                       
                <asp:BoundField DataField="intCOAP" HeaderText="COAParrent" Visible="false" SortExpression="intCOAP"/>  
                
                <asp:BoundField DataField="TAccumuBlance" HeaderText="OpeningBlance" SortExpression="TAccumuBlance"/>      
                <asp:BoundField DataField="additionyearcost" HeaderText="AdditionThePeriod" SortExpression="additionyearcost"/>
                <asp:BoundField DataField="Retirement" HeaderText="AdjustmentDisposal" SortExpression="Retirement"/>  
                <asp:BoundField DataField="ActualBlance" HeaderText="ClosingBalance" SortExpression="ActualBlance"/> 
                 <asp:BoundField DataField="Revalued" HeaderText="RevaluedAmount" SortExpression="Revalued"/> 
                <asp:BoundField DataField="Revalued" HeaderText="RateRange" SortExpression="Revalued"/> 
                <asp:BoundField DataField="depOpenBlance" HeaderText="OpeningBalance" SortExpression="depOpenBlance"/>                           
                <asp:BoundField DataField="Dep" HeaderText="ChargeThePeriod" SortExpression="Dep"/>  
                 <asp:BoundField DataField="Adjustment" HeaderText="Adjustment" SortExpression="Adjustment"/>  
                <%--<asp:BoundField DataField="depOpenBlance" HeaderText="ClossingBlance" SortExpression="depOpenBlance"/>  --%>
                <asp:BoundField DataField="calAccDep" HeaderText="ClosingBalance" SortExpression="calAccDep"/>  
                <asp:BoundField DataField="WrittenDownValue" HeaderText="CA(CarryingAmount)" SortExpression="WrittenDownValue"/>  
                </Columns>                   
                
                </asp:GridView></td>
              </tr>
          </table>
         
            
<%--=========================================End My Code From Here=================================================--%>
      
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

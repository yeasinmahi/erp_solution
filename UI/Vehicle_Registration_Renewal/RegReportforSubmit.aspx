<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegReportforSubmit.aspx.cs" Inherits="UI.Vehicle_Registration_Renewal.RegReportforSubmit" %>
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
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/Lstyle.css" rel="stylesheet" />
        

    <script>
       
        function Viewdetails() {
            window.open('Registration_UI.aspx?ID=' + ID , "height=375, width=730, scrollbars=yes, left=250, top=200, resizable=no, title=Preview");
        }
</script>
     <script type="text/javascript">
         function Search_dgvservice(strKey, strGV) {

             var strData = strKey.value.toLowerCase().split(" ");
             var tblData = document.getElementById(strGV);
             var rowData;
             for (var i = 1; i < tblData.rows.length; i++) {
                 rowData = tblData.rows[i].innerHTML;
                 var styleDisplay = 'none';
                 for (var j = 0; j < strData.length; j++) {
                     if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                         styleDisplay = '';
                     else {
                         styleDisplay = 'none';
                         break;
                     }
                 }
                 tblData.rows[i].style.display = styleDisplay;
             }

         }

         
         
         
        </script>
    
     <script>
         function RegistrationReg(url) {
             newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=500,width=600,top=150,left=350, close=no');
             if (window.focus) { newwindow.focus() }
         } 
         function RegistrationTax(url) {
             newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=500,width=600,top=150,left=350, close=no');
             if (window.focus) { newwindow.focus() }
         }
         function RegistrationFetness(url) {
             newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=500,width=600,top=150,left=350, close=no');
             if (window.focus) { newwindow.focus() }
         }
             function RegistrationRoot(url) {
                 newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=500,width=600,top=150,left=350, close=no');
                 if (window.focus) { newwindow.focus() }
             }
             function RegistrationDRC(url) {
                 newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=500,width=600,top=150,left=350, close=no');
                 if (window.focus) { newwindow.focus() }
             }
             function RegistrationInsurance(url) {
                 newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=500,width=600,top=150,left=350, close=no');
                 if (window.focus) { newwindow.focus() }

             }
             
             function RegistrationRoot(url) {
                 newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=500,width=600,top=150,left=350, close=no');
                 if (window.focus) { newwindow.focus() }

             }
             function RegistrationName(url) {
                 newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=500,width=600,top=150,left=350, close=no');
                 if (window.focus) { newwindow.focus() }

             }
             function RegistrationDRC(url) {
                 newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=500,width=600,top=150,left=350, close=no');
                 if (window.focus) { newwindow.focus() }

             }
         </script> 
          
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" /><asp:HiddenField ID="hdnTopSheetCount" runat="server" />
   
        
        <div class="tabs_container"> VEHICLE RENEWAL REGISTRATION REPORT <hr /></div>
        
        <table >
        <tr>                
            <td style="text-align:right;">
                <%--<asp:Label ID="lblUnit" runat="server" CssClass="lbl" Visible="false" Text="Owner Name:"></asp:Label>--%>
                <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Vehicle No:"></asp:Label>
            </td>
            <td style="text-align:left;">
           <asp:TextBox ID="TxtAsset" runat="server" CssClass="txtBox"  Font-Bold="False" AutoPostBack="true"  ></asp:TextBox>
                     <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="TxtAsset"
                                     ServiceMethod="GetAssetNumber" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
    <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" />
                
                     <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" Visible="false" AutoPostBack="true" ></asp:DropDownList>                                                                                       
            </td>

            <td style="text-align:right;"><asp:Label ID="lblShipPoint" runat="server"  CssClass="lbl" Text="Renewal Type"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlShipPoint" CssClass="ddList" AutoPostBack="true"  Font-Bold="False" runat="server" OnSelectedIndexChanged="ddlShipPoint_SelectedIndexChanged" >
                    <asp:ListItem Value="310078">Registration</asp:ListItem>
                     <asp:ListItem Value="310079">TAX Token</asp:ListItem>
                     <asp:ListItem Value="310080">Fitness&AIT</asp:ListItem>
                     <asp:ListItem Value="310081">Route Permit</asp:ListItem>
                    <asp:ListItem Value="310082">Insurance</asp:ListItem>
                    <asp:ListItem Value="310083">Name Plate</asp:ListItem>
                    <asp:ListItem Value="310108">DRC</asp:ListItem>
                   
                </asp:DropDownList>                                                                       
            </td>                                                                         

            <%--<td style="text-align:right;"><asp:Label ID="lblSearchBuyerReff" runat="server" CssClass="lbl" Text="Trip SL No. :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtSearchTripSLNo" runat="server" CssClass="txtBox"></asp:TextBox></td>              --%>
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblFromDate" runat="server" Visible="false" CssClass="lbl" Text="From Date :"></asp:Label></td>                
            <td><asp:TextBox ID="txtFromDate" runat="server" Visible="false" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="210px" autocomplete="off"></asp:TextBox>
            <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender></td> 
            
            <td style="text-align:right;"><asp:Label ID="lblToDate" runat="server" Visible="false" CssClass="lbl" Text="To Date :"></asp:Label></td>                
            <td><asp:TextBox ID="txtToDate" runat="server" Visible="false" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="210px" autocomplete="off"></asp:TextBox>
            <cc1:CalendarExtender ID="tdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender></td>  
        </tr>
        
       
       
        <tr>
             <%-- <td style="text-align:right;"></td>                
              <td style="text-align:left;"> </td>--%>
       <td></td>
            <td style="text-align:left;"><asp:Button ID="btnShowReport" runat="server" Font-Bold="true" class="nextclick" Text="Show Report" OnClick="btnShowReport_Click" /></td>
        </tr>
</table>
       
             
        <table > 
             <tr>
                <td>
                    <asp:GridView ID="dgvReport" runat="server" AutoGenerateColumns="False" OnRowDataBound = "OnRowDataBound">
                        <Columns>
                           <%-- <asp:TemplateField HeaderText="SL.N">
                                 <HeaderTemplate>
                                       
                         <asp:TextBox ID="TxtServiceConfg" runat="server"  width="70"  placeholder="Search" onkeyup="Search_dgvservice(this, 'dgvReport')"></asp:TextBox>
                               
                                    
                                    </HeaderTemplate>
                           <ItemTemplate>
                                             <%# Container.DataItemIndex + 1 %>
                                         </ItemTemplate>
                      </asp:TemplateField>--%>
                             <asp:BoundField HeaderText="ID" DataField="AutoID"   Visible="false" SortExpression="AutoID"/>
                           <%-- <asp:BoundField HeaderText="RegisterTo" DataField="strUnit"   SortExpression="strUnit"/>
                             <asp:BoundField HeaderText="Jobstation" DataField="strJobstation"   SortExpression="strJobstation"/>
                              <asp:BoundField HeaderText="AssetID" DataField="strAssetID" SortExpression="strAssetID"/>
                             <asp:BoundField HeaderText="VehicleName" DataField="strVehicleName" SortExpression="strVehicleName" />
                             <asp:BoundField HeaderText="VehicleType" DataField="strVehicleType" SortExpression="VehicleType" />--%>
                              <asp:TemplateField HeaderText="No.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                                <asp:BoundField HeaderText="AssetID" DataField="strAssetID" SortExpression="strAssetID"/>
                             <asp:BoundField HeaderText="AssetName" DataField="strAssetName" SortExpression="strAssetName"/>
                             <asp:BoundField HeaderText="RegisterTo" DataField="strUnit"   SortExpression="strUnit"/>
                             <asp:BoundField HeaderText="Jobstation" DataField="strJobstation"   SortExpression="strJobstation"/>
                          
                             


                            <%--  <asp:TemplateField HeaderText="Service Name">
                                  <ItemTemplate>
                                      <asp:Label ID="lblServiceName" runat="server" Text='<%# Eval("strServiceName") %>'></asp:Label>
                                  </ItemTemplate>
                        </asp:TemplateField>
                       
                           <asp:BoundField HeaderText="Total" DataField="monTotal" SortExpression="monTotal" />
                           <asp:BoundField HeaderText="Renewal Date" DataField="dteRenewalDate" SortExpression="dteRenewalDate" />
                            <asp:BoundField HeaderText="Expire Date" DataField="DteExpireDate" SortExpression="DteExpireDate" />
                              --%>
                            <asp:TemplateField HeaderText="Details">
                                <ItemTemplate>
                                    <asp:Button ID="BtnDetails" CommandName="Submit"  CommandArgument='<%#GetJSFunctionString( Eval("strAssetID"),Eval("strAssetID")) %>' runat="server" Text="Submit" OnClick="BtnDetails_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                        </Columns>
                        
                    </asp:GridView>
                </td>
                
            </tr> 
         
            
        </table>
       
        
        <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

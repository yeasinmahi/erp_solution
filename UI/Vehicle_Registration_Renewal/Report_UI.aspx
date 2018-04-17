<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report_UI.aspx.cs" Inherits="UI.Vehicle_Registration_Renewal.Report_UI" %>


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
        
        <table class="tbldecoration" style="width:auto; " >
        <tr>                
            <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Owner Name:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true" ></asp:DropDownList>                                                                                       
            </td>

            <td style="text-align:right;"><asp:Label ID="lblShipPoint" runat="server" CssClass="lbl" Text="Renewal Type"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlShipPoint" CssClass="ddList" AutoPostBack="true" Font-Bold="False" runat="server" >
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
            <td style="text-align:right;"><asp:Label ID="lblFromDate" runat="server" CssClass="lbl" Text="From Date :"></asp:Label></td>                
            <td><asp:TextBox ID="txtFromDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="210px"></asp:TextBox>
            <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender></td> 
            
            <td style="text-align:right;"><asp:Label ID="lblToDate" runat="server" CssClass="lbl" Text="To Date :"></asp:Label></td>                
            <td><asp:TextBox ID="txtToDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="210px"></asp:TextBox>
            <cc1:CalendarExtender ID="tdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender></td>  
        </tr>
        
       
       
        <tr>
            <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Vehicle Name"></asp:Label></td>                
            
          <td style="text-align:left;"> <asp:TextBox ID="TxtName" runat="server" CssClass="txtBox"  Font-Bold="False" AutoPostBack="true"  ></asp:TextBox>
                     <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="TxtName"
                                     ServiceMethod="GetAssetNumber" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
    <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" /></td>
            <td></td>
            <td style="text-align:left;"><asp:Button ID="btnShowReport" runat="server" Font-Bold="true" class="nextclick" Text="Show Report" OnClick="btnShowReport_Click" /></td>
        </tr>
</table>
        </div>
             
        <table class="tbldecoration" style="width:auto; ">  
          <tr>
                <td>
                    <asp:GridView ID="dgvReport" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField HeaderText="SL.N">
                                 <HeaderTemplate>
                                       
                         <asp:TextBox ID="TxtServiceConfg" runat="server"  width="70"  placeholder="Search" onkeyup="Search_dgvservice(this, 'dgvGridView')"></asp:TextBox>
                               
                                    
                                    </HeaderTemplate>
                           <ItemTemplate>
                                             <%# Container.DataItemIndex + 1 %>
                                         </ItemTemplate>
                      </asp:TemplateField>
                            <asp:BoundField HeaderText="ID" DataField="AutoID" SortExpression="AutoID"/>
                              <asp:BoundField HeaderText="Unit" DataField="strUnit" SortExpression="strUnit"/>
                             <asp:BoundField HeaderText="AssetID" DataField="strAssetID" SortExpression="strassetID" />
                            <asp:BoundField HeaderText="VehicleName" DataField="strNameOfAsset" SortExpression="strNameOfAsset" />
                             <asp:BoundField HeaderText="VehicleType" DataField="strNameOfAsset" SortExpression="strNameOfAsset" />
                       <asp:BoundField HeaderText="Service Name" DataField="strItemName" SortExpression="strItemName" />
                                  <asp:BoundField HeaderText="ServiceID" DataField="intServiceID"  Visible="false" SortExpression ="intServiceID" />
                           <asp:BoundField HeaderText="Total" DataField="monTotalTaka" SortExpression="monTotalTaka" />
                           <asp:BoundField HeaderText="Renewal Date" DataField="dteRenewalDate" SortExpression="dteRenewalDate" />
                            <asp:BoundField HeaderText="Expire Date" DataField="dteExpireDate" SortExpression="dteExpireDate" />
                            <asp:BoundField HeaderText="Next Expire Date" DataField="dteNextSubmitDate" SortExpression="dteNextSubmitDate" />
                            
                            <asp:TemplateField HeaderText="Approve By"></asp:TemplateField>
                              <asp:BoundField HeaderText="Insert Date" DataField="dteInsertDate" SortExpression="dteNextSubmitDate" />
                          
                              <asp:BoundField HeaderText="Doc Det." DataField="strCertificateNo" SortExpression="dteNextSubmitDate" />
                          

                            <asp:TemplateField HeaderText="Details">
                                <ItemTemplate>
                                    <asp:Button ID="BtnDetails" runat="server" Text="Details View" CommandArgument='<%#GetJSFunctionString( Eval("AutoID"),Eval("intServiceID")) %>' OnClick="BtnDetails_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Print">
                                <ItemTemplate>
                                    <asp:Button ID="BtnPrint" runat="server" Text="PrintView" CommandArgument='<%#GetJSFunctionString( Eval("AutoID"),Eval("intServiceID")) %>' OnClick="BtnPrint_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
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


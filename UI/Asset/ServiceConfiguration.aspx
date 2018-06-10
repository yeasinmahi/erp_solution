<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceConfiguration.aspx.cs" Inherits="UI.Asset.ServiceConfiguration" %>
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
       
    <script src="jquery-1.8.3.min.js"></script>
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
        function Save() {
            document.getElementById("hdnField").value = "1";
            __doPostBack();
        }

</script>
   <script type="text/javascript">

        function funConfirmAll() {
             var asset = document.getElementById("TxtAsset").value;
             var problem = document.getElementById("TxtProblem").value;
      
            if ($.trim(asset).length < 3 ||$.trim(asset) == 0 || $.trim(asset) == "" || $.trim(asset) == null || $.trim(asset) == undefined) { document.getElementById("hdnConfirm").value = "0"; alert('Please input Asset ID'); }
            else  if ($.trim(problem).length < 3||$.trim(problem) == 0 || $.trim(problem) == "" || $.trim(problem) == null || $.trim(problem) == undefined) { document.getElementById("hdnConfirm").value = "0"; alert('Please describe problem'); }

            else {
                 var confirm_value = document.createElement("INPUT"); 
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";

                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnConfirm").value = "1"; }

                else { confirm_value.value = "No"; document.getElementById("hdnConfirm").value = "0"; }

            } 
        }

</script> 
     <script>
         function Registration(url) {
             newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=900,top=50,left=230, close=no');
             if (window.focus) { newwindow.focus() }
         }
          
         function Registrationparts(url) {
             newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=1000,top=50,left=200, close=no');
             if (window.focus) { newwindow.focus() }
         }
             function RegistrationSchedule(url) {
                 newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=900,top=50,left=230, close=no');
                 if (window.focus) { newwindow.focus() }
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
    <asp:HiddenField ID="hdnEnrollUnit" runat="server" /><asp:HiddenField ID="hdnConfirm" runat="server" /><asp:HiddenField ID="hdnBankID" runat="server" />
    <asp:HiddenField ID="hfEmployeeIdp" runat="server" /><asp:HiddenField ID="hdnstation" runat="server" />       
          <asp:HiddenField ID="HdnServiceCost" runat="server" />   <asp:HiddenField ID="hdnRepairsCost" runat="server" />   
            
    <div class="tabs_container" align="Center" >Maintenance Service Configuration </div>
   
       <table style="width:700px; outline-color:blue;table-layout:auto;vertical-align: top; background-color: #996633;"class="tblrowodd" >
            <tr  class="tblrowodd">
                  
            <td style="text-align:right;" > <asp:Label ID="LblAsset" runat="server" CssClass="lbl" font-size="small" Text="Asset Number:"></asp:Label></td>
            <td style="text-align:left;"> <asp:TextBox ID="TxtAsset" runat="server" CssClass="txtBox" Font-Bold="False" AutoPostBack="true" OnTextChanged="TxtAsset_TextChanged"  ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="TxtAsset"
            ServiceMethod="GetWearHouseRequesision" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender>
            <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" /></td>
                      
            <td style="text-align:right;"> <asp:Label ID="LblUnit" runat="server" CssClass="lbl" font-size="small" Text="Unit:"></asp:Label></td>
            <td style="text-align:left;"> <asp:TextBox ID="TxtUnit" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
       
            </tr>
            <tr>
            <td style="text-align:right;"> <asp:Label ID="LblName" font-size="small" runat="server" CssClass="lbl" Text="Name of Asset:"></asp:Label></td>
            <td style="text-align:left;"> <asp:TextBox ID="TxtName" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
            <td style="text-align:right;"> <asp:Label ID="LblStation" runat="server" font-size="small" CssClass="lbl" Text="JobStation:"></asp:Label></td>
            <td style="text-align:left;"> <asp:TextBox ID="TxtStation" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
       
            </tr>
           </Table>
         <tr>
         <td>Request and Service Type</td><td><asp:RadioButton ID="RadioButton1" Text="Preventive"  autopostback="true" runat="server" OnCheckedChanged="RadioButton1_CheckedChanged" /></td><td><asp:RadioButton ID="RadioButton2" autopostback="true" Text="Corrective Maintenance" runat="server" OnCheckedChanged="RadioButton2_CheckedChanged" /></td>
             </tr>
         <table style="width:700px; outline-color:blue;table-layout:auto;vertical-align: top; background-color: #996633;"class="tblrowodd" >
            <tr>
            <%-- <td style="text-align: right;">
            <asp:Label ID="LblSchedule" runat="server" font-size="small"  CssClass="lbl" Text="Schedule:"></asp:Label></td>

            <td style="text-align: left;">
            <asp:DropDownList ID="DdlSchedule" runat="server" CssClass="ddList" Font-Bold="False" AutoPostBack="True" OnSelectedIndexChanged="DdlSchedule_SelectedIndexChanged">
            </asp:DropDownList><asp:Button ID="btnschedule" autopostback="true" BackColor="Wheat" ForeColor="red" runat="server" Text="+" OnClick="btnschedule_Click" />--%>

            <td style="text-align: right;">
            <asp:Label ID="LblService"  runat="server" font-size="small"  CssClass="lbl" Text="Service:"></asp:Label></td>
            <td style="text-align: left;">
            <asp:DropDownList ID="DdlService" runat="server" CssClass="ddList" Font-Bold="False" AutoPostBack="true" OnSelectedIndexChanged="DdlService_SelectedIndexChanged">
            </asp:DropDownList><asp:Button ID="btnservice" autopostback="true" BackColor="Wheat" ForeColor="red" runat="server" Text="+" OnClick="btnservice_Click" />
            
            <td style="text-align: right;">
            <asp:Label ID="LblPriority"  runat="server" font-size="small"  CssClass="lbl" Text="Service Priority:"></asp:Label></td>
            <td style="text-align: left;">
            <asp:DropDownList ID="DdlPrePriority" runat="server" CssClass="ddList" Font-Bold="False" AutoPostBack="True">
            <asp:ListItem>Low</asp:ListItem>
            <asp:ListItem>Medium</asp:ListItem>
            <asp:ListItem>High</asp:ListItem>
            </asp:DropDownList>   
            </tr> 
            <tr> 
            <td style="text-align: right;">
            <asp:Label ID="LblHour" font-size="small"  runat="server" CssClass="lbl" Text="Require Period"></asp:Label></td>
            <td style="text-align: left;">
            <asp:DropDownList ID="DdlRequred" runat="server" CssClass="ddList" Font-Bold="False" AutoPostBack="True" OnSelectedIndexChanged="DdlSchedule_SelectedIndexChanged">
            <asp:ListItem>Day</asp:ListItem>
            <asp:ListItem>Hour</asp:ListItem>
                  
            </asp:DropDownList>
            <td style="text-align: right;">
            <asp:Label ID="LblRequare" font-size="small"  runat="server" CssClass="lbl"  Text="Require(Hour/Day)"></asp:Label></td>
               
            <td><asp:TextBox ID="TxtDayHour" runat="server" CssClass="txtBox" ></asp:TextBox>
                    
            </tr>
            <tr>
                
            <td style="text-align: right;">
            <asp:Label ID="LblProvide" font-size="small"  runat="server" CssClass="lbl" Text="Service Provide By"></asp:Label></td>
                     
            <td style="text-align: left;">
            <asp:DropDownList ID="DdlProvide" runat="server" CssClass="ddList" Font-Bold="False" AutoPostBack="True" >
            <asp:ListItem>In House</asp:ListItem>
            <asp:ListItem>Vendor</asp:ListItem> 
                     
            </asp:DropDownList></td>
                   
                    
                 
            <td style="text-align: right;">
            <asp:Label ID="LbldteStart" runat="server" CssClass="lbl" font-size="small"  Text="Fixed Date:"></asp:Label></td>
            <td>
            <asp:TextBox ID="TxtdteFixed" runat="server" CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="CEA" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtdteFixed"></cc1:CalendarExtender>


         
            </tr> 
         </table>
        <table  width="700"  class="tblroweven" style="background-color: #FFCCFF; background-repeat: inherit; background-attachment: inherit; background-position: center center">
        <tr>

        <td style="text-align:right;"><asp:Label ID="LblCommonRepair" runat="server" font-size="small"  CssClass="lbl" Text="Common Repair:"></asp:Label></td>
        <td style="text-align:left;"><asp:DropDownList ID="DdlCommonRepair" runat="server" CssClass="ddList" Font-Bold="False" OnSelectedIndexChanged="DdlCommonRepair_SelectedIndexChanged">
        </asp:DropDownList><asp:Button ID="btnRepair" BackColor="Wheat" ForeColor="red" runat="server" Text="+" OnClick="btnRepair_Click" /> 
             
        <td style="text-align:right;"><asp:Label ID="LbldteRepair" runat="server" font-size="small"  CssClass="lbl" Text="Repair Date:"></asp:Label></td>
        <td><asp:TextBox ID="TxtdteRepair" runat="server" CssClass="txtBox" ></asp:TextBox>
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtdteRepair"></cc1:CalendarExtender> 
            
        </tr>
        <tr> 
        <td style="text-align:right;"><asp:Label ID="LblPrioritys" runat="server" font-size="small"  CssClass="lbl" Text="Priority:"></asp:Label></td>
      
        <td style="text-align:left;"><asp:DropDownList ID="DdlREPriotiyyd" runat="server" CssClass="ddList" Font-Bold="False">
        <asp:ListItem>Low</asp:ListItem>
        <asp:ListItem>Medium</asp:ListItem>
        <asp:ListItem>High</asp:ListItem> 
        </asp:DropDownList>   
        </td>
        <td style="text-align:right;"> <asp:Label ID="LblProblem" runat="server"  font-size="small"  CssClass="lbl" Text="Problem:"></asp:Label></td>
        <td style="text-align:left;"> <asp:TextBox ID="TxtProblem" runat="server" CssClass="txtBox" Font-Bold="False" ></asp:TextBox>
      
        </tr> 
     

          </table>
        <table width="700" class="tblroweven"> 
        <tr> 
                     
        <td style="text-align:right;">
        <asp:Button ID="BtnConfigure" runat="server" Text="Configure"  OnClick="BtnIssue_Click" OnClientClick="funConfirmAll();"  style="height: 26px"/></td>
        </tr>
        </table> 
         <table>
            <tr>
            <td>
            <asp:GridView ID="dgvservice" runat="server" AutoGenerateColumns="False">
            <Columns>
            <asp:TemplateField HeaderText="SL.N">
            <HeaderTemplate>        
            <asp:TextBox ID="TxtServiceConfg" runat="server"  width="70"  placeholder="Search" onkeyup="Search_dgvservice(this, 'dgvservice')"></asp:TextBox>
                                 
            </HeaderTemplate>
            <ItemTemplate>
            <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
            </asp:TemplateField> 
            <asp:BoundField HeaderText="Asset Code" DataField="strAssetNumber" SortExpression="strAssetNumber" />
            <asp:BoundField DataField="strNameOfAsset" HeaderText="Asset Name" SortExpression="strNameOfAsset" />
            <asp:BoundField HeaderText="ServiceName" DataField="strServiceName" SortExpression="strServiceName" />
            <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="YesnServiceType" />
            <asp:BoundField DataField="strPriroty" HeaderText="Priority" SortExpression="strPriroty" />
            <asp:BoundField DataField="dteFixed/Repair" HeaderText="Date" SortExpression="dteFixed/Repair" />
            <asp:BoundField DataField="dteNextServiceDate" HeaderText="NextPMDate" SortExpression="dteNextServiceDate" />
            <asp:BoundField DataField="strServiceProvideBy" HeaderText="Provide By" SortExpression="strServiceProvideBy" />
            <asp:TemplateField HeaderText="Spare">
            <ItemTemplate>
            <asp:Button ID="BtnAdd" runat="server" Text="Parts"  CommandName="Parts"  CommandArgument='<%# Eval("intID")%>' OnClick="BtnAdd_Click"  />
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

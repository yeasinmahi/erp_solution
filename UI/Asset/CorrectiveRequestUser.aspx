<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CorrectiveRequestUser.aspx.cs" Inherits="UI.Asset.CorrectiveRequestUser" %>

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
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
       
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
         
         function Viewdetails(id, status) {
             window.open('CorrectiveRequestUserPopUP.aspx?ID=' + id , '', "height=600, width=750, scrollbars=yes, left=150, top=50, resizable=no, title=Preview");
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
      <asp:HiddenField ID="hdnConfirm" runat="server" />
           
    <div class="tabs_container" align="left" >Maintenance Service Request</div>
   
       <table style="width:600px; outline-color:blue;table-layout:auto;vertical-align: top; background-color: #996633;"class="tblrowodd" >
           <tr  class="tblrowodd">
                  
       <td style="text-align:right;" > <asp:Label ID="LblAsset" runat="server" CssClass="lbl" font-size="small" Text="Asset Number:"></asp:Label></td>
        <td style="text-align:left;"> <asp:TextBox ID="TxtAsset" runat="server" CssClass="txtBox" Font-Bold="False" AutoPostBack="true" OnTextChanged="TxtAsset_TextChanged"  ></asp:TextBox>
        <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="TxtAsset"
        ServiceMethod="GetAssetData" MinimumPrefixLength="1" CompletionSetCount="1"
        CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
        </cc1:AutoCompleteExtender>
        <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" /></td>                
           <td style="text-align:right;"> <asp:Label ID="LblUnit" runat="server" CssClass="lbl" font-size="small" Text="Unit:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TxtUnit" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
       
                    </tr>
               <tr  class="tblrowodd">
                     <td style="text-align:right;"> <asp:Label ID="LblName" font-size="small" runat="server" CssClass="lbl" Text="Name of Asset:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TxtName" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
        <td style="text-align:right;"> <asp:Label ID="LblStation" runat="server" font-size="small" CssClass="lbl" Text="JobStation:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TxtStation" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
        </tr>
            <tr  class="tblrowodd"> 
            <td style="text-align:right;"><asp:Label ID="LblPrioritys" runat="server" font-size="small"  CssClass="lbl" Text="Priority:"></asp:Label></td>
      
            <td style="text-align:left;"><asp:DropDownList ID="DdlREPriotiy" runat="server" CssClass="ddList" Font-Bold="False">
            <asp:ListItem>Low</asp:ListItem>
            <asp:ListItem>Medium</asp:ListItem>
            <asp:ListItem>High</asp:ListItem> 
            </asp:DropDownList>  
                    
            <td style="text-align:right;"><asp:Label ID="LblCommonRepair" runat="server" font-size="small"  CssClass="lbl" Text="Service Type:"></asp:Label></td>
            <td style="text-align:left;"><asp:DropDownList ID="ddlType" runat="server" CssClass="ddList" Font-Bold="False">
            </asp:DropDownList></td> 
            </tr>
            <tr  class="tblrowodd">
            <td style="text-align:right;"> <asp:Label ID="Label1" runat="server"  font-size="small"  CssClass="lbl" Text="Request Workstation:"></asp:Label></td>
            <td style="text-align:left;"> <asp:DropDownList ID="ddlLocation" runat="server" CssClass="ddList" Font-Bold="False" AutoPostBack="true" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged" ></asp:DropDownList>
           
            <td style="text-align:right;"><asp:Label ID="Label2" runat="server" font-size="small"  CssClass="lbl" Text="Service Department:"></asp:Label></td>
            <td style="text-align:left;"><asp:DropDownList ID="DdlDept" runat="server" CssClass="ddList" Font-Bold="False">
            </asp:DropDownList> 
                      
            </tr> 
            <tr  class="tblrowodd">
            <td style="text-align:right;"> <asp:Label ID="LblProblem" runat="server"  font-size="small"  CssClass="lbl" Text="Problem:"></asp:Label></td>
            <td style="text-align:left;" colspan="3"> <asp:TextBox ID="TxtProblem" runat="server" Width="500px" CssClass="txtBox" Font-Bold="False" ></asp:TextBox>     
            </tr>
            <tr  class="tblrowodd">
            <td style="text-align:right;"> <asp:Label ID="Label3" runat="server"  font-size="small"  CssClass="lbl" Text="Others:"></asp:Label></td>
            <td style="text-align:left;" colspan="3"> <asp:TextBox ID="txtUrgent" runat="server" Width="500px" CssClass="txtBox" Font-Bold="False" ></asp:TextBox>     
            </tr>
            <tr> 
            <td></td> 
            <td></td> <td></td>    
            <td style="text-align:right;">
            <asp:Button ID="BtnRequest" runat="server" Text="Save" OnClick="BtnRequest_Click" OnClientClick="funConfirmAll();"   /></td>
            </tr>
           </table>
          </div>
           <div class="leaveSummary_container"> 
        <div class="tabs_container">Service Requesition Summary :<hr /></div> 
        
                     <asp:GridView ID="dgvView" runat="server" AutoGenerateColumns="False">
                         <Columns>
                             <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
                             <asp:BoundField DataField="intID" HeaderText="ID" SortExpression="intID" Visible="False" />
                             <asp:BoundField DataField="strAssetNumber"  HeaderText="Asset Code" SortExpression="strAssetNumber" Visible="False" />
                             <asp:BoundField DataField="strNameOfAsset" HeaderText="Name of Asset" SortExpression="strNameOfAsset" />
                             <asp:BoundField DataField="strPriroty" HeaderText="Priority" SortExpression="strPriroty" Visible="False" />
 
                             <asp:BoundField DataField="dteFixed/Repair" HeaderText="DateTime" SortExpression="dteFixed/Repair" />
                             <asp:BoundField DataField="strProblem" ItemStyle-Width="100PX" HeaderText="Problem" SortExpression="strProblem" />
                             <asp:BoundField DataField="strLocation" HeaderText="Location" SortExpression="strLocation" Visible="False" />
                             <asp:BoundField DataField="strDepatrment" HeaderText="Request to Dept" SortExpression="strDepatrment" Visible="False" />
                             <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" Visible="False" />
                             <asp:TemplateField HeaderText="Detalis">
                                 <ItemTemplate>
                                     <asp:Button ID="BtnDetalis" runat="server" Text='<%# Bind("status") %>'  CommandName="Detalis"  CommandArgument='<%# Eval("intID") %>' OnClick="BtnDetalis_Click"/>
                                 </ItemTemplate>
                             </asp:TemplateField>
                         </Columns>
                     </asp:GridView>
                </div>
         
            
<%--=========================================End My Code From Here=================================================--%>
      
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BudgetDetalis_UI.aspx.cs" Inherits="UI.BudgetPlan.BudgetDetalis_UI" %>

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
    <script>   function CloseWindow() { window.close(); window.onbeforeunload = RefreshParent(); }
         function RefreshParent() {
             if (window.opener != null && !window.opener.closed) {
                 window.opener.location.reload();
             }
         }

    </script> 
    

    <script>
        $(document).ready(function () {
            SearchTextemp();
        });
        function Changeds() {
            document.getElementById('HdfTechnicinSearchbox').value = 'true';
        }
        function SearchTextemp() {
            $("#TxtTechnichinSearch").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;",
                        url: "WorkOrderPartsPopUp.aspx/GetAutoCompleteDataemp",
                        data: "{'strSearchKeyemp':'" + document.getElementById('TxtTechnichinSearch').value + "'}",
                        dataType: "json",
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (result) {

                        }
                    });
                }
            });
        }

    </script>
    <script>
            $(document).ready(function () {
                SearchTextVendor();
            });
            function ChangedVendor() {
                document.getElementById('HiddenVendor').value = 'true';
            }
            function SearchTextVendor() {
                $("#TxtTechnichinSearch").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            type: "POST",
                            contentType: "application/json;",
                            url: "WorkOrderPartsPopUp.aspx/GetAutoCompleteDataVendor",
                            data: "{'strSearchKeyVendor':'" + document.getElementById('TxtTechnichinSearch').value + "'}",
                            dataType: "json",
                            success: function (data) {
                                response(data.d);
                            },
                            error: function (result) {

                            }
                        });
                    }
                });
            }

    </script>
     <script>
         $(document).ready(function () {
             SearchTextTools();
         });
         function ChangedTolls() {
             document.getElementById('HiddenTools').value = 'true';
         }
         function SearchTextTools() {
             $("#SearchToolsBox").autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         type: "POST",
                         contentType: "application/json;",
                         url: "WorkOrderPartsPopUp.aspx/GetAutoCompleteDataTools",
                         data: "{'strSearchTextTools':'" + document.getElementById('SearchToolsBox').value + "'}",
                         dataType: "json",
                         success: function (data) {
                             response(data.d);
                         },
                         error: function (result) {

                         }
                     });
                 }
             });
         }

    </script>
     <script>
         function Registration(url) {
             newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=500,width=1000,top=150,left=350, close=no');
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
    <asp:HiddenField ID="hfEmployeeIdp" runat="server" /><asp:HiddenField ID="hdnstation" runat="server" /> <asp:HiddenField ID="hdnR" runat="server" />           
    <div class="tabs_container" align="Center">Budget Planning Requesition Detalis </div>        
         
        <div class="tabs_container" >Supplies(Items) </div>
         <tr>
                   <td style="text-align: right;">
                         <asp:Label ID="LblService"  runat="server" font-size="small"  CssClass="lbl" Text="Ware House:"></asp:Label>
                       <asp:HiddenField ID="hdntp" runat="server" /><asp:HiddenField ID="hdnwh" runat="server" /></td>
                     <td style="text-align: left;">
                         <asp:DropDownList ID="DdlWareHouse" runat="server" CssClass="ddList" Font-Bold="False" AutoPostBack="True" DataSourceID="odswhlst" DataTextField="WH" DataValueField="intWHID" OnDataBound="DdlWareHouse_DataBound" OnSelectedIndexChanged="DdlWareHouse_SelectedIndexChanged" >
                         </asp:DropDownList>
                         <asp:ObjectDataSource ID="odswhlst" runat="server" SelectMethod="warehousename" TypeName="Purchase_BLL.Asset.AssetMaintenance">
                             <SelectParameters>
                                 <asp:SessionParameter Name="enroll" SessionField="sesUserID" Type="Int32" />
                                 <asp:ControlParameter ControlID="hdntp" Name="type" PropertyName="Value" Type="Int32" />
                             </SelectParameters>
                         </asp:ObjectDataSource>
             </tr> 
          <td><asp:RadioButton ID="SNew" Text="New"  GroupName="Perform" AutoPostBack="true" runat="server" OnCheckedChanged="SNew_CheckedChanged"   /></td>
         <td><asp:RadioButton ID="SExis" Text="Existing" GroupName="Perform" runat="server"  AutoPostBack="true" OnCheckedChanged="SExis_CheckedChanged"  /></td>
        
         <table   width="900" border="1px";>
                
           
            
              <tr>
        <td style="text-align:right;"><asp:Label ID="Label9" runat="server" CssClass="lbl" Text="Supplies:"></asp:Label> </td>
         <td><asp:TextBox ID="txtSupplies" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true"  ></asp:TextBox>
             <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtSupplies"
                                     ServiceMethod="GetItemsName" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                 <asp:HiddenField ID="hdfItems" runat="server" /></td>
                        
               
                                      
        <td style="text-align:right;"><asp:Label ID="LblPqty" runat="server"  CssClass="lbl" Text="Quantity:"></asp:Label> </td>
       <td style="text-align:left;"> <asp:TextBox ID="TxtPqty" runat="server"  CssClass="txtBox" Font-Bold="False"></asp:TextBox>  
     <td style="text-align:right;"> <asp:Label ID="LblRemarks" runat="server" CssClass="lbl" Text="Remarks:"></asp:Label></td>
     <td style="text-align:left;"> <asp:TextBox ID="TxtRemarks" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
          <%--<td class="auto-style1"><asp:CheckBox ID="CheckBox3" Text="Warranty" runat="server" /></td>--%>
         </tr>
         <tr>
        <td colspan="6" style="text-align:right;"><asp:Button ID="Btnsupplies" runat="server" autopostback="true" BackColor="YellowGreen" Text="Add" OnClick="Btnsupplies_Click"   /> </td>    
           </tr>
            <tr> <td colspan="3"> <asp:GridView ID="dgvSupplies" runat="server" AutoGenerateColumns="False" OnRowDeleting="dgvSupplies_RowDeleting" BackColor="#FFCCFF">
            <Columns>
            <asp:BoundField DataField="suppid" HeaderText="ID" SortExpression="suppid" />
            <asp:BoundField DataField="supname" HeaderText="SuppliesName" SortExpression="supname" />
            <asp:BoundField DataField="remarks" HeaderText="Remarks" SortExpression="remarks" />
            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
            </Columns>
            </asp:GridView></td></tr>                    
             </table>      
       <div class="tabs_container" >Employee(Personal)</div>
         <td><asp:RadioButton ID="EmployeeNew" Text="New"  GroupName="Employee" AutoPostBack="true" runat="server" OnCheckedChanged="EmployeeNew_CheckedChanged"   /></td>
         <td><asp:RadioButton ID="EmployeeExix" Text="Exisitng"  GroupName="Employee" runat="server"  AutoPostBack="true" OnCheckedChanged="EmployeeExix_CheckedChanged"  /></td>
        
         
         <table border="1px" width="900" class="tblrowodd" >
             <tr>
                 
        <td  style="text-align:left;"><asp:Label ID="LblTechnichin" runat="server" CssClass="lbl" Text="Performer Name:"></asp:Label> </td>
          <td  style="text-align:left;"> <asp:TextBox ID="TxtEmpSearch" AutoCompleteType="Search" runat="server" CssClass="txtBox" AutoPostBack="true"  placeholder="Please Search Enroll" Font-Bold="False"></asp:TextBox>  
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" TargetControlID="TxtEmpSearch"
            ServiceMethod="GetEmployeeName" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
        </cc1:AutoCompleteExtender>
           
                <asp:HiddenField ID="HdfTechnicinCode" runat="server" /><asp:HiddenField ID="HdfTechnicinSearchbox" runat="server" />
            
              <asp:HiddenField ID="HiddenVendor" runat="server" /><asp:HiddenField ID="HiddenVendorCode" runat="server" /></td>
            
                                 
        <td   style="text-align:right;"><asp:Label ID="LblDescription" runat="server" CssClass="lbl" Text="Descripton:"></asp:Label> </td>
       <td  style="text-align:left;"> <asp:TextBox ID="TxtDescription" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>  
     <td  style="text-align:right;"> <asp:Label ID="LblLabor" runat="server" Visible="false" CssClass="lbl" Text="Labor Rate:"></asp:Label></td>
    <td  style="text-align:left;"> <asp:TextBox ID="TxtLabor" runat="server" Visible="false" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
         </tr>
             
        
               <tr>
            <td colspan="6" style="text-align:right;"><asp:Button ID="BtnEmp" runat="server" autopostback="true" BackColor="YellowGreen" Text="Add" OnClick="BtnEmp_Click"   /> </td>    
           </tr>
             <tr>
               

                    <td colspan="3"> <asp:GridView ID="dgvEmp" runat="server" AutoGenerateColumns="False"  BackColor="#FFCCFF" OnRowDeleting="dgvEmp_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="empid" HeaderText="ID" SortExpression="empid" />
                            <asp:BoundField DataField="empname" HeaderText="EmpName" SortExpression="empname" />
                            <asp:BoundField DataField="remarks" HeaderText="Remarks" SortExpression="remarks" />
                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                        </Columns>
                        </asp:GridView></td>
                 </tr>
            
             </table>
         
         <div class="tabs_container" >Fixed Asset(Equipments)</div>
        <td><asp:RadioButton ID="ETNew" Text="New"  GroupName="Asset" AutoPostBack="true" runat="server" OnCheckedChanged="ETNew_CheckedChanged"   /></td>
         <td><asp:RadioButton ID="ETExis" Text="Existing"  GroupName="Asset" runat="server"  AutoPostBack="true" OnCheckedChanged="ETExis_CheckedChanged"  /></td>
        
         <table border="1px" width="900" class="tblrowodd" >
             <tr>
                 
        <td  style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Tools Name:"></asp:Label> </td>
          <td  style="text-align:left;"> <asp:TextBox ID="txtTools" AutoCompleteType="Search" runat="server" CssClass="txtBox" AutoPostBack="true" Font-Bold="False"></asp:TextBox>  
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtTools"
            ServiceMethod="GetToolsName" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
        </cc1:AutoCompleteExtender>
               <asp:HiddenField ID="HiddenToolsCode" runat="server" /><asp:HiddenField ID="HiddenTools" runat="server" /></td>
               
                                 
        <td   style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Descripton:"></asp:Label> </td>
       <td  style="text-align:left;"> <asp:TextBox ID="TxtTollsDescription" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>  
   
            <td style="text-align:right;"> <asp:Label ID="Label4"  runat="server" CssClass="lbl" Text="Qty:"></asp:Label></td>
    <td style="text-align:left;"> <asp:TextBox ID="txtToolqty" runat="server" CssClass="txtBox" Font-Bold="False" BackColor="White"></asp:TextBox>
    
            </tr>
        
            <tr>
 <td colspan="6" style="text-align:right;"><asp:Button ID="BtnTools" runat="server" autopostback="true" BackColor="YellowGreen" Text="Add" OnClick="BtnTools_Click"    /> </td>    
           </tr>
            <tr>
                   <td colspan="3"> <asp:GridView ID="dgvTools" runat="server" AutoGenerateColumns="False"  BackColor="#FFCCFF" OnRowDeleting="dgvTools_RowDeleting" >
                        <Columns>
                            <asp:BoundField DataField="tnameid" HeaderText="ID" SortExpression="tnameid" />
                            <asp:BoundField DataField="tname" HeaderText="ToolsName" SortExpression="tname" />
                            <asp:BoundField DataField="tqty" HeaderText="Qty" SortExpression="tqty" />
                             <asp:BoundField DataField="tdec" HeaderText="Description" SortExpression="tdec" />
                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                        </Columns>
                        </asp:GridView></td>
                 </tr>
            
             </table>   
         <div class="tabs_container" >Expance</div>
       
         <table border="1px" width="900" class="tblrowodd" >
             <tr>
                 
        <td  style="text-align:right;"><asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Expance Name:"></asp:Label> </td>
          <td  style="text-align:left;"> <asp:TextBox ID="TxtExpance" runat="server" CssClass="txtBox" AutoPostBack="false"  Font-Bold="False"></asp:TextBox>  
             <asp:HiddenField ID="HiddenField1" runat="server" /><asp:HiddenField ID="HiddenField2" runat="server" /></td>
               
                                 
        <td   style="text-align:right;"><asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Descripton:"></asp:Label> </td>
       <td  style="text-align:left;"> <asp:TextBox ID="TxtDec" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>  
   
            <td style="text-align:right;"> <asp:Label ID="Label6"  runat="server" CssClass="lbl" Text="Approx Amount:"></asp:Label></td>
    <td style="text-align:left;"> <asp:TextBox ID="TxtAmount" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
    
            </tr>
        
           <tr>
 <td colspan="6" style="text-align:right;"><asp:Button ID="btnExpance" runat="server" BackColor="YellowGreen" autopostback="true" Text="Add" OnClick="btnExpance_Click"   /> </td>    
           </tr>
            <tr>
                   <td colspan="3"> <asp:GridView ID="dgvExpance" runat="server" AutoGenerateColumns="False"  BackColor="#FFCCFF" OnRowDeleting="dgvExpance_RowDeleting"  >
                        <Columns>
                         
                            <asp:BoundField DataField="exname" HeaderText="ExpanceName" SortExpression="exname" />
                            <asp:BoundField DataField="amount" HeaderText="Amount" SortExpression="amount" />
                             <asp:BoundField DataField="exdec" HeaderText="Description" SortExpression="exdec" />
                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                        </Columns>
                        </asp:GridView></td>
                 </tr>
            
             </table>        
             <div class="tabs_container" >Document Procudure</div>
        
         <table  border="1px" width="900" class="tblroweven">
             <tr>
                 
        
          <td style="text-align:right;"><asp:Label ID="LblUplaod" runat="server" CssClass="lbl" Text="Upload File :"></asp:Label>
          <td class="auto-style1"><asp:FileUpload ID="DUpload" runat="server" />     
                              
        <td style="text-align:right;"><asp:Label ID="Label18" runat="server" CssClass="lbl" Text="Descripton:"></asp:Label> </td>
        <td style="text-align:left;"> <asp:TextBox ID="TxtDocDescription" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>  
       
    
   <%--  <td>
                     <td style="text-align:right;">        <asp:HiddenField ID="hdnField" runat="server" />
                       <a class="nextclick" onclick="Save()">Submit</a> </td>--%>
   
           </tr>
             </table>  
        
         
         <table border="1px" width="900" class="tblrowodd" >
             <tr> <td style="text-align:right;"><asp:Button ID="BtnClose" BackColor="YellowGreen" runat="server" Text="Back" OnClick="BtnClose_Click"    />
                 <asp:Button ID="BtnSave" BackColor="YellowGreen" runat="server" Text="Submit" OnClick="BtnSave_Click"   />   
                 </td>    

                     </tr>
         </table> 
          
        
         
           
            
        
         
            
<%--=========================================End My Code From Here=================================================--%>
      
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

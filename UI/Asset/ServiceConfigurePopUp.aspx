<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceConfigurePopUp.aspx.cs" Inherits="UI.Asset.ServiceConfigurePopUp" %>
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
       
    <script> function CloseWindow() {
     window.close();
 } </script> 
    <script>
        function Save() {
            document.getElementById("hdnField").value = "1";
            __doPostBack();
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
                        url: "ServiceConfigurePopUp.aspx/GetAutoCompleteDataemp",
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
         function Registration(url) {
             newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=500,width=1000,top=150,left=350, close=no');
             if (window.focus) { newwindow.focus() }
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
    <asp:HiddenField ID="hfEmployeeIdp" runat="server" /><asp:HiddenField ID="hdnstation" runat="server" />         
    <div class="tabs_container" align="Center">Service Configuration </div>
   
        
         
        <div class="tabs_container" >Spare Parts </div>
         <table  border="1px" width="900" class="tblroweven">
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
             
              <tr>
<%--<td class="auto-style1">Main Type</td><td class="auto-style1"></td>   <td class="auto-style1"><asp:CheckBox ID="CheckBox3" Text="Preventive" runat="server" /></td>   <td class="auto-style1"><asp:CheckBox ID="CheckBox4" Text="Repair" runat="server" /></td>--%> 
        <td style="text-align:right;"><asp:Label ID="Label9" runat="server" CssClass="lbl" Text="Parts:"></asp:Label> </td>
        <%-- <td><asp:TextBox ID="txtPartsSearch" runat="server" CssClass="txtBox" AutoPostBack="false" onchange="javascript: Changed();" ></asp:TextBox>--%>
         <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" />

          <td><asp:TextBox ID="txtPartsSearch" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true"  ></asp:TextBox>
             <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtPartsSearch"
                                     ServiceMethod="GetWearHouseRequesision" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>

                        
               
                                      
        <td style="text-align:right;"><asp:Label ID="LblPqty" runat="server" CssClass="lbl" Text="Quantity:"></asp:Label> </td>
       <td style="text-align:left;"> <asp:TextBox ID="TxtPqty" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>  
     <td style="text-align:right;"> <asp:Label ID="LblRemarks" runat="server" CssClass="lbl" Text="Remarks:"></asp:Label></td>
     <td style="text-align:left;"> <asp:TextBox ID="TxtRemarks" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
          <%--<td class="auto-style1"><asp:CheckBox ID="CheckBox3" Text="Warranty" runat="server" /></td>--%>
         </tr>
         <tr>
 <td colspan="6" style="text-align:right;"><asp:Button ID="BtnParts" runat="server" Text="Add" OnClick="BtnParts_Click"  /> </td>    
           </tr>
             <tr>
                 
                    <td colspan="5"> <asp:GridView ID="GridViewParts" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="strSpareParts" HeaderText="Spare Parts" SortExpression="strSpareParts" />
                            <asp:BoundField DataField="intqty" HeaderText="Qty" SortExpression="intqty" />
                            <asp:BoundField />
                        </Columns>
                        </asp:GridView> </td>
             </tr>
             </table>      
       <div class="tabs_container" >Labor Cost</div>
        <%-- <td><asp:RadioButton ID="RadioButton1" Text="Employee" runat="server" /></td>
         <td><asp:RadioButton ID="RadioButton2" Text="Vendor" runat="server" /></td>--%>
         <table border="1px" width="900" class="tblrowodd" >
             <tr>
                 
                  
        <td  style="text-align:right;"><asp:Label ID="LblTechnichin" runat="server" CssClass="lbl" Text="Performer by:"></asp:Label> </td>
          <td  style="text-align:left;"> <asp:TextBox ID="TxtTechnichinSearch" runat="server" CssClass="txtBox" AutoPostBack="false" onchange="javascript: Changeds();"  placeholder="Please Search Enroll" Font-Bold="False"></asp:TextBox>  
             <asp:HiddenField ID="HdfTechnicinCode" runat="server" /><asp:HiddenField ID="HdfTechnicinSearchbox" runat="server" /></td>
                          
                                   
        <td   style="text-align:right;"><asp:Label ID="LblDescription" runat="server" CssClass="lbl" Text="Descripton:"></asp:Label> </td>
       <td  style="text-align:left;"> <asp:TextBox ID="TxtDescription" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>  
     <td  style="text-align:right;"> <asp:Label ID="LblLabor" runat="server" CssClass="lbl" Text="Labor Rate:"></asp:Label></td>
    <td  style="text-align:left;"> <asp:TextBox ID="TxtLabor" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
         </tr>
        
             <tr>
     <td style="text-align:right;"> <asp:Label ID="LblHour" runat="server" CssClass="lbl" Text="Hour:"></asp:Label></td>
    <td style="text-align:left;"> <asp:TextBox ID="TxtHour" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
    <td style="text-align:right;"> <asp:Label ID="Label16" runat="server" CssClass="lbl" Text="Total Cost:"></asp:Label></td>
    <td style="text-align:left;"> <asp:TextBox ID="TxtTCost" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
   
       <%--<td class="auto-style1"><asp:CheckBox ID="CheckBox4" Text="Warranty" runat="server" /></td>--%>
        <td></td>
      <td style="text-align:right;"><asp:Button ID="BtnLabor" runat="server" Text="Add" OnClick="BtnLabor_Click" /> </td>    
           </tr>
             <tr>
                 
                    <td colspan="5"> <asp:GridView ID="GridViewLabor" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="strEmployeeName" HeaderText="Technichian" SortExpression="strEmployeeName" />
                            <asp:BoundField DataField="strDescription" HeaderText="Description" SortExpression="strDescription" />
                            <asp:BoundField DataField="strHour" HeaderText="Hour" SortExpression="strHour" />
                        </Columns>
                       </asp:GridView> </td>
             </tr>
             </table>  
         <div class="tabs_container" >Tools And Equipment</div>
        <%-- <td><asp:RadioButton ID="RadioButton1" Text="Employee" runat="server" /></td>
         <td><asp:RadioButton ID="RadioButton2" Text="Vendor" runat="server" /></td>--%>
         <table border="1px" width="900" class="tblrowodd" >
             <tr>
                 
        <td  style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Tools Name:"></asp:Label> </td>
          <td  style="text-align:left;"> <asp:TextBox ID="SearchToolsBox" runat="server" CssClass="txtBox" AutoPostBack="false" onchange="javascript: ChangedTolls();" Font-Bold="False"></asp:TextBox>  
             <asp:HiddenField ID="HiddenToolsCode" runat="server" /><asp:HiddenField ID="HiddenTools" runat="server" /></td>
               
                                 
        <td   style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Descripton:"></asp:Label> </td>
       <td  style="text-align:left;"> <asp:TextBox ID="TxtTollsDescription" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>  
    <%-- <td  style="text-align:right;"> <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Labor Rate:"></asp:Label></td>
    <td  style="text-align:left;"> <asp:TextBox ID="TextBox3" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
   --%>    
            <td style="text-align:right;"> <asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Hour:"></asp:Label></td>
    <td style="text-align:left;"> <asp:TextBox ID="txtToolsHour" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
    
            </tr>
        
             <tr>
    <%-- <td style="text-align:right;"> <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Total Cost:"></asp:Label></td>
    <td style="text-align:left;"> <asp:TextBox ID="TextBox5" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
   --%>
       <%--<td class="auto-style1"><asp:CheckBox ID="CheckBox4" Text="Warranty" runat="server" /></td>--%>
        <td></td><td></td><td></td><td></td><td></td>
      <td style="text-align:right;"><asp:Button ID="BtnTools" runat="server" Text="Add" OnClick="BtnTools_Click"  /> </td>    
           </tr>
            <tr>
                <td colspan="5">
                    <asp:GridView ID="dgvPMTools" runat="server" AutoGenerateColumns="False" OnRowDeleting="dgvPMTools_RowDeleting">
                        <Columns>
                            <asp:BoundField HeaderText="ToolsName" DataField="Item" SortExpression="Item" />
                            <asp:BoundField HeaderText="Description" DataField="strDescription" SortExpression="strDescription" />
                            <asp:BoundField HeaderText="Hour" DataField="decHour" SortExpression="decHour" />
                        </Columns>
                    </asp:GridView>
                </td>
                
            
             </table>     
             
             <div class="tabs_container" >Document Procudure</div>
        
         <table  border="1px" width="900" class="tblroweven">
             <tr>
                 
        
          <td style="text-align:right;"><asp:Label ID="LblUplaod" runat="server" CssClass="lbl" Text="Upload File :"></asp:Label>
          <td class="auto-style1"><asp:FileUpload ID="DUpload" runat="server" />     
                              
        <td style="text-align:right;"><asp:Label ID="Label18" runat="server" CssClass="lbl" Text="Descripton:"></asp:Label> </td>
        <td style="text-align:left;"> <asp:TextBox ID="TxtDocDescription" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>  
       
    
     <td>
                     <td style="text-align:right;">        <asp:HiddenField ID="hdnField" runat="server" />
                              <a class="nextclick" onclick="Save()">Submit</a> </td>
    <%--<td style="text-align:right;" ><asp:Button ID="Button4" runat="server" Text="Add" Height="25px" style="margin-left: 0px" Width="40px" /> </td>--%>    
           </tr>
             </table>  
        
         
         <table border="1px" width="900" class="tblrowodd" >
       <tr> <td style="text-align:right;"><asp:Button ID="BtnSave" runat="server" Text="Close" OnClick="BtnSave_Click"   /> </td> 

                     </tr>
         </table> 
          <table border="1px" width="900">
     <tr>
    <td><asp:GridView ID="GridViewDoc" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="strpath" HeaderText="Path" SortExpression="strpath" />
            <asp:BoundField DataField="strDescription" HeaderText="Description" SortExpression="strDescription" />
            <asp:BoundField DataField="dtedate" HeaderText="Date" SortExpression="dtedate" />
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

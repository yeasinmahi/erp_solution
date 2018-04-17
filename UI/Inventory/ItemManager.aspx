<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemManager.aspx.cs" Inherits="UI.Inventory.ItemManager" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><title></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
<webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
 <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
<script src="../Content/JS/datepickr.min.js"></script>

<script type="text/javascript">
    

function Confirm() {
    document.getElementById("hdnconfirm").value = "0";
    var txtItem = document.forms["frmreq"]["txtItem"].value;
    var txtmasterid = document.forms["frmreq"]["txtmasterid"].value;
    if (txtItem == null || txtmasterid == "") { alert("Please enter ItemName"); }
   
    else {
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
        if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
        else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
    }
}

</script>


</head>
<body>
    <form id="frmreq" runat="server">
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
        <div class="leaveApplication_container"><table border="0"; style="width:Auto"; >
    <tr><td colspan="4" class="tblheader">Item Manager Detaills :<asp:HiddenField ID="hdnsearch" runat="server"/><asp:HiddenField ID="hdnpoint" runat="server" /><asp:HiddenField ID="hdnunit" runat="server" /></td></tr>
    
    <tr class='tblroweven'>
       
          <td style="text-align:right"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit Name:  "></asp:Label></td>
                         
                         <td><asp:DropDownList ID="drdlUnitName"  runat="server" DataSourceID="odsUnitNameByEnrol" DataTextField="strUnit" DataValueField="intUnitID" OnSelectedIndexChanged="drdlUnitName_SelectedIndexChanged"></asp:DropDownList>
            
                 <asp:ObjectDataSource ID="odsUnitNameByEnrol" runat="server" SelectMethod="getUnitNamebyEnrol" TypeName="HR_BLL.TourPlan.TourPlanning">
                     <SelectParameters>
                         <asp:SessionParameter Name="Enrol" SessionField="sesUserID" Type="Int32" />
                     </SelectParameters>
                 </asp:ObjectDataSource>
            </td>
         <td style="text-align:right;"><asp:Label ID="lblWareHouseName" CssClass="lbl" runat="server" Text="Ware House :"></asp:Label></td>
        <td ><asp:DropDownList ID="drdlwhlist" runat="server" AutoPostBack="True" DataSourceID="odswhlistperm" DataTextField="strWareHoseName" DataValueField="intWHID"></asp:DropDownList> 
            <asp:ObjectDataSource ID="odswhlistperm" runat="server" SelectMethod="Getwarehouselistpermission" TypeName="Purchase_BLL.SupplyChain.CSM">
                <SelectParameters>
                    <asp:SessionParameter Name="enrol" SessionField="sesUserID" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="odswhlistpermission" runat="server" SelectMethod="Getwarehouselistpermission" TypeName="Purchase_BLL.SupplyChain.CSM">
                <SelectParameters>
                    <asp:SessionParameter Name="enrol" SessionField="sesEnroll" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
                 </td>
    </tr>
             <tr class='tblrowodd'>
        <td style="text-align:right;"><asp:Label ID="lblClusterName" CssClass="lbl" runat="server" Text="Cluster Name :"></asp:Label></td>
        <td><asp:DropDownList ID="drdlcluster" runat="server" AutoPostBack="True" DataSourceID="odsclusterlist" DataTextField="strname" DataValueField="intid" OnSelectedIndexChanged="drdlcluster_SelectedIndexChanged"></asp:DropDownList> 
           
                 <asp:ObjectDataSource ID="odsclusterlist" runat="server" SelectMethod="GetClusterList" TypeName="Purchase_BLL.SupplyChain.CSM"></asp:ObjectDataSource>
           
                 </td>
       
              <td style="text-align:right;"><asp:Label ID="lblProcureType" CssClass="lbl" runat="server" Text="Procure Type :"></asp:Label></td>
        <td ><asp:DropDownList ID="drdlProcureType" runat="server" AutoPostBack="true">
            <asp:ListItem Value="0">Local</asp:ListItem>
            <asp:ListItem Value="1">Foreign</asp:ListItem>
            <asp:ListItem Value="2">Fabrication</asp:ListItem>
             </asp:DropDownList> </td>
             </tr>
               <tr class='tblrowodd'>
        <td style="text-align:right;"><asp:Label ID="lblSearchItem" CssClass="lbl" runat="server" Text="SearchItem :"></asp:Label></td>
        <td colspan="3"><asp:TextBox ID="txtItem" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" Width="500px" OnTextChanged="txtItem_TextChanged" ></asp:TextBox>
    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtItem"
    ServiceMethod="Getitemmanageritemlist" MinimumPrefixLength="1" CompletionSetCount="1"
    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
    </cc1:AutoCompleteExtender>
    <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" /><asp:HiddenField ID="hdnconfirm" runat="server" />
    </td></td>
        
               </tr>
             <tr class='tblrowodd'>
        <td style="text-align:right;"><asp:Label ID="lblSubCategory" CssClass="lbl" runat="server" Text="SubCategory :"></asp:Label></td>
        <td><asp:DropDownList ID="drdlSubCategory" runat="server" AutoPostBack="True" DataSourceID="odsSub" DataTextField="strSubCatName" DataValueField="intAutoID" ></asp:DropDownList> 
            
              <asp:ObjectDataSource ID="odsSub" runat="server" SelectMethod="GetItemSubcategorylist" TypeName="Purchase_BLL.SupplyChain.CSM">
                  <SelectParameters>
                      <asp:SessionParameter Name="unitid" SessionField="sesUnit" Type="Int32" />
                  </SelectParameters>
            </asp:ObjectDataSource>
            
              </td>
         <td style="text-align:right;"><asp:Label ID="lblVatApplicable" CssClass="lbl" runat="server" Text="Vat Applicable  :"></asp:Label></td>
        <td><asp:DropDownList ID="drdlVatApplicable" runat="server" AutoPostBack="true">
            <asp:ListItem Value="0">VAT Applicable</asp:ListItem>
            <asp:ListItem Value="1">Not Applicable</asp:ListItem>
          

            </asp:DropDownList> </td>
       
             
             </tr>
            <tr class='tblrowodd'>
        <td style="text-align:right;"><asp:Label ID="lblMasterid" CssClass="lbl" runat="server" Text="Master Id :"></asp:Label></td>
        <td><asp:TextBox ID="txtmasterid" runat="server" CssClass="txtBox"  ></asp:TextBox></td>
       <td style="text-align:right;"><asp:Label ID="lbluom" CssClass="lbl" runat="server" Text="UOM :"></asp:Label></td>
        <td><asp:TextBox ID="txtUOM" runat="server" CssClass="txtBox"  ></asp:TextBox></td>

        </tr>
             
     <tr class="tblrowOdd">
                 <td><asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" OnClientClick = "Confirm()" Text="Add" /> </td>
                 <td> <asp:Button ID="btnSubmit" runat="server" BackColor="#ffcccc" Font-Bold="true" Text="Submit" OnClick="btnSubmit_Click" OnClientClick = "Confirm()" /> </td>
             </tr>

      </div>
        <div class="leaveApplication_container">
            <table>
             <tr class="tblroweven">
                <td>
                    



                   
                         <asp:GridView ID="grdvItemManagerDetaills" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
                        BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="grdvItemManagerDetaills_RowDataBound" OnRowDeleting="grdvItemManagerDetaills_RowDeleting">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        
                        <Columns>
                        <asp:TemplateField  HeaderText="SL."><ItemTemplate><%# Container.DataItemIndex + 1 %><asp:HiddenField ID="hdnSL" runat="server" Value='<%# Bind("fromAddress") %>' /></ItemTemplate></asp:TemplateField> 
                        <asp:BoundField DataField="itemname" HeaderText="Item Name" SortExpression="aplName" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                        <asp:BoundField DataField="itemid" HeaderText="Master Id" SortExpression="AplEnrol" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                        <asp:BoundField DataField="uom" HeaderText="UOM" SortExpression="decDur" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                        <asp:BoundField DataField="subcategory" HeaderText="subCategory" SortExpression="subcategory" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                        <asp:BoundField DataField="procuretype" HeaderText="ProcureType" SortExpression="procuretype" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                        <asp:BoundField DataField="vat" HeaderText="VAT" SortExpression="VAT " ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                        <asp:BoundField DataField="unit" HeaderText="Unit" SortExpression="Unit" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                        <asp:BoundField DataField="warehouse" HeaderText="WareHouse" SortExpression="warehouse" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                        <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" /> 

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

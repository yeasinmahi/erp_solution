<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BudgetInfoModification.aspx.cs" Inherits="UI.BudgetPlan.BudgetInfoModification" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html >
<html >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
     <asp:PlaceHolder ID="PlaceHolder1" runat="server">     
          <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
        </asp:PlaceHolder>  
    
    <webopt:BundleReference ID="BundleReference4" runat="server" Path="~/Content/Bundle/hrCSS" />
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
     <script src="../../../../Content/JS/datepickr.min.js"></script>
  <link href="../../../../Content/CSS/GridHEADER.css" rel="stylesheet" />
    <script src="../../../../Content/JS/JQUERY/jquery-1.10.2.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/jquery-ui.min.js"></script>
    <script src="../../../../Content/JS/datepickr.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/MigrateJS.js"></script>
    <script src="../../../../Content/JS/JQUERY/GridviewScroll.min.js"></script>
        
    
    
  <script type="text/javascript">
    $(document).ready(function () { GridviewScroll(); });
    function GridviewScroll() {
        $('#<%=grdvBudgetInfoModification.ClientID%>').gridviewScroll({
        width: 1024,
        height: 500,
        startHorizontal: 0,
        wheelstep: 10,
        barhovercolor: "#3399FF",
        barcolor: "#3399FF"
    });
}
    function ViewConfirm(id) { document.getElementById('hdnDivision').style.visibility = 'visible'; }
   function CheckAll(Checkbox) {
        var GridVwHeaderCheckbox = document.getElementById("<%=grdvBudgetInfoModification.ClientID %>");
        for (i = 1; i < GridVwHeaderCheckbox.rows.length; i++) {
            GridVwHeaderCheckbox.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
            
        }
    }
       function Confirm() {
           document.getElementById("hdnconfirm").value = "0";
           var confirm_value = document.createElement("INPUT");
               confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
               if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
               else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
           }
       
</script>



    <script type="text/javascript">
        function Validation() {
            var txtProduct = document.getElementById("txtProduct").value;
            var txtjan = document.getElementById("txtjan").value;
            var txtFeb= document.getElementById("txtFeb").value;

            if (txtProduct == null || txtProduct == '') {
                alert("Product can not be empty");
                return false;
            }
            if (txtjan == null || txtjan == '') {
                alert("January qnt can not be empty");
                return false;
            }
              if (txtFeb == null || txtFeb == '') {
                alert("February qnt can not be empty");
                return false;
            }


            return true;
        }
    </script>


</head>
<body>
    <form id="frmshvssls" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <CompositeScript>
            <Scripts>
                <asp:ScriptReference name="MicrosoftAjax.js"/>
	<asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
	<asp:ScriptReference name="MicrosoftAjaxTimer.js" assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"/>
	<asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Common.DateTime.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.AnimationBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="PopupExtender.PopupBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Common.Threading.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Calendar.CalendarBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="AutoComplete.AutoCompleteBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
            </Scripts>
        </CompositeScript>
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
             <div class="tabs_container">Budget Info Modification<asp:HiddenField ID="hdnApplicantEnrol" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/> <asp:HiddenField ID="hdnconfirm" runat="server" />
        <asp:HiddenField ID="HiddenUnit" runat="server"/>
       <input type="hidden" id="DATE" name="DATE" value="WOULD_LIKE_TO_ADD_DATE_HERE">
        <hr /></div>
        
        <div>
        <table>
             <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtToDate', { 'dateFormat': 'Y-m-d' });</script></td>          
        </tr>
            <tr>
                  <td style="text-align:right;"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit Name:  "> </asp:Label>
                   

                         
                         <td>
                 <asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" DataSourceID="odsUnit"
                                    DataTextField="strUnit" DataValueField="intUnitID" OnDataBound="ddlUnit_DataBound"
                                    OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
                                    <SelectParameters>
                                        <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            
            </td>
                  <td><asp:Label ID="lblcustype" runat="server" CssClass="lbl" Text="Budget Type"></asp:Label> </td>
                    <td> <asp:DropDownList ID="ddlBudgetType" runat="server" AutoPostBack="True" DataSourceID="odsBudgetType" DataTextField="strBudgetType" DataValueField="intBudgetTypeID" OnSelectedIndexChanged="ddlBudgetType_SelectedIndexChanged" > </asp:DropDownList> 
                        <asp:ObjectDataSource ID="odsBudgetType" runat="server" SelectMethod="GetBudgetType" TypeName="Budget_BLL.Budget.Budget_Entry_BLL"></asp:ObjectDataSource>
                      </td>


            </tr>
        
            <tr class="tblrowodd">
                  <td>
                     <asp:Label ID="lblRowItem" runat="server" CssClass="lbl" Text="Row Item"></asp:Label>
                 </td>
         
                  <td> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
                                <asp:HiddenField ID="hdnProduct" runat="server" />
                        
                                <asp:HiddenField ID="hdnProductText" runat="server" />
                                <asp:TextBox ID="txtProduct" runat="server" AutoCompleteType="Search" Width="250px"
                                    AutoPostBack="true" OnTextChanged="txtProduct_TextChanged"></asp:TextBox>

                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtProduct"
                                    ServiceMethod="GetProductList" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
               <%--       <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtProduct"
            ServiceMethod="GetProductList" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender>--%>
                            </td>  

                 <td><asp:Label ID="lblSalesOffice" runat="server" CssClass="lbl" Text="Action Type"></asp:Label> </td>
                    <td> <asp:DropDownList ID="ddlActionType" runat="server" AutoPostBack="True"> 
                        <asp:ListItem Value="1">Show Report</asp:ListItem>
             <asp:ListItem Value="2">Update</asp:ListItem>
             <asp:ListItem Value="3">Delete</asp:ListItem>
                        </asp:DropDownList> 
                       
                  </td>

            </tr>
           
            </div>
        <div id="content">
            <table>
         


                    </table>
</div>
        <div>
     
                 
            <tr>
                  <td colspan="4">
                          <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="button" OnClientClick = "Confirm()" OnClick="btnShow_Click"/>
                      <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="button" OnClientClick = "Confirm()" OnClick="btnSubmit_Click" />
                  </td>
            </tr>
          


           </table>
             </div>

         <div class="leaveApplication_container"> 
             <table>
                 <tr class="tblroweven"><td>
              <asp:GridView ID="grdvBudgetInfoModification" runat="server" AutoGenerateColumns="False" AllowPaging="false"  BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" >
                  <AlternatingRowStyle BackColor="#CCCCCC" />
                  <Columns>
                     
                      <asp:TemplateField><HeaderTemplate>    
                <asp:CheckBox ID="chkbx" runat="server" onclick="CheckAll(this);" />   
                </HeaderTemplate>  
                <ItemTemplate><asp:CheckBox ID="chkbx" runat="server"/></ItemTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="Sl"> <ItemTemplate> <%#Container.DataItemIndex+1 %> 
                    <asp:HiddenField ID="hdnintBudgetId" runat="server" Value='<%# Eval("intBudgetId") %>' />
                    <asp:HiddenField ID="hdnintTypeId" runat="server" Value='<%# Eval("intTypeId") %>' />
                     
                    </ItemTemplate></asp:TemplateField>
                    <asp:BoundField DataField="strBudgetType" HeaderText="BudgetType" SortExpression="strBudgetType" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strRowName" HeaderText="Product Name" SortExpression="strRowName" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="intYear" HeaderText="Year" SortExpression="intYear" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="Monthnames" HeaderText="Monthnames" SortExpression="Monthnames" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                     <asp:BoundField DataField="dteInsertionTime" HeaderText="InsertionTime" SortExpression="dteInsertionTime" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                   
                     <%-- <asp:BoundField DataField="decQnt" HeaderText="Qnt" SortExpression="decQnt" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="monProductRate" HeaderText="ProductRate" SortExpression="monProductRate" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                     <asp:BoundField DataField="monBudget" HeaderText="Amount" SortExpression="monBudget" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    --%>
                        <asp:TemplateField HeaderText="Qnt" HeaderStyle-HorizontalAlign="Center"  SortExpression="Quantity">
                        <ItemTemplate><asp:HiddenField ID="hdndecQnt" runat="server" Value='<%# Bind("decQnt", "{0:0.00}") %>'></asp:HiddenField>  
                        <asp:Label ID="lbldecQnt" runat="server" Visible="false" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("decQnt", "{0:0.00}"))) %>'></asp:Label>
                        <asp:TextBox ID="txtdecQnt"  runat="server" onblur="" CssClass="txtBox" Width="75px" TextMode="Number" Text='<%# Bind("decQnt", "{0:0}") %>' AutoPostBack="false"></asp:TextBox>
                        </ItemTemplate></asp:TemplateField>

                        <asp:TemplateField HeaderText="ProductRate" HeaderStyle-HorizontalAlign="Center"  SortExpression="monProductRate">
                        <ItemTemplate><asp:HiddenField ID="hdnmonProductRate" runat="server" Value='<%# Bind("monProductRate", "{0:0.00}") %>'></asp:HiddenField>  
                        <asp:Label ID="lblmonProductRate" runat="server" Visible="false" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monProductRate", "{0:0.00}"))) %>'></asp:Label>
                        <asp:TextBox ID="txtProductRate"  runat="server" onblur="" CssClass="txtBox" Width="75px" TextMode="Number" Text='<%# Bind("monProductRate", "{0:0}") %>' AutoPostBack="false"></asp:TextBox>
                        </ItemTemplate></asp:TemplateField>


                        <asp:TemplateField HeaderText="Amount" HeaderStyle-HorizontalAlign="Center"  SortExpression="monProductRate">
                        <ItemTemplate><asp:HiddenField ID="hdnmonBudget" runat="server" Value='<%# Bind("monBudget", "{0:0.00}") %>'></asp:HiddenField>  
                        <asp:Label ID="lblmonBudget" runat="server" Visible="false" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monBudget", "{0:0.00}"))) %>'></asp:Label>
                        <asp:TextBox ID="txtmonBudget"  runat="server" onblur="" CssClass="txtBox" Width="75px" TextMode="Number" Text='<%# Bind("monBudget", "{0:0}") %>' AutoPostBack="false"></asp:TextBox>
                        </ItemTemplate></asp:TemplateField>



                      
                      
                      <asp:BoundField DataField="line" HeaderText="Line" SortExpression="line" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="Area" HeaderText="Area" SortExpression="Area" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                     <asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    
                  
                  
                  
                  </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                    <HeaderStyle CssClass="GridviewScrollHeader"/><PagerStyle CssClass="GridviewScrollPager"/>
                        </asp:GridView> </td></tr>   
                    </table>
             </div>
       
     
 <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>   
    </form>
</body>
</html>

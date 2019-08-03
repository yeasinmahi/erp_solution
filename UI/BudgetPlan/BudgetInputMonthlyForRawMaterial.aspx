<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BudgetInputMonthlyForRawMaterial.aspx.cs" Inherits="UI.BudgetPlan.BudgetInputMonthlyForRawMaterial" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
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
        $('#<%=grdvFGVsRawMaterialMonthly.ClientID%>').gridviewScroll({
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
        var GridVwHeaderCheckbox = document.getElementById("<%=grdvFGVsRawMaterialMonthly.ClientID %>");
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
      
</head>
<body>
    <form id="frmpdv" runat="server">
   <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
   

<%--=========================================Start My Code From Here===============================================--%>
          <div class="leaveApplication_container"> 
    <div class="tabs_container"> <asp:HiddenField ID="hdnenroll" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
        <asp:HiddenField ID="hdnemail" runat="server"/><asp:HiddenField ID="hdnconfirm" runat="server" />
        <hr /></div>
               <div class="tabs_container">Material Budget Input(Monthly)<asp:HiddenField ID="hdnApplicantEnrol" runat="server"/>
        <asp:HiddenField ID="HiddenField1" runat="server"/><asp:HiddenField ID="HiddenField2" runat="server"/> <asp:HiddenField ID="HiddenField3" runat="server" />
        <asp:HiddenField ID="HiddenUnit" runat="server"/>
       <input type="hidden" id="DATE" name="DATE" value="WOULD_LIKE_TO_ADD_DATE_HERE">
        <hr /></div>
        
        <div>
        <table>
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
                    <td> <asp:DropDownList ID="ddlBudgetType" runat="server" AutoPostBack="True" DataSourceID="odsBudgetType" DataTextField="strBudgetType" DataValueField="intBudgetTypeID" OnSelectedIndexChanged="ddlBudgetType_SelectedIndexChanged"> </asp:DropDownList> 
                        <asp:ObjectDataSource ID="odsBudgetType" runat="server" SelectMethod="GetBudgetType" TypeName="Budget_BLL.Budget.Budget_Entry_BLL"></asp:ObjectDataSource>
                      </td>


            </tr>
        
         
            <tr>
            <td style="text-align:right;"><asp:Label ID="lblYear" runat="server" CssClass="lbl" Text="Year:"></asp:Label></td> 
            <td style="text-align:left;"><asp:DropDownList ID="ddlYear" CssClass="ddList" Font-Bold="False" Width="120px" runat="server" DataSourceID="odsCombindBudgetYear" DataTextField="strYearList" DataValueField="intCombindyear"></asp:DropDownList>                                                                       
             
                <asp:ObjectDataSource ID="odsCombindBudgetYear" runat="server" SelectMethod="GetBudgetYearCombindly" TypeName="Budget_BLL.Budget.Budget_Entry_BLL"></asp:ObjectDataSource>
             
            </td>

        <td>
              <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Budget Month"></asp:Label>  </td>
                    <td> <asp:DropDownList ID="ddlBudgetMonth" runat="server" AutoPostBack="True" DataSourceID="odsMonthName" DataTextField="monthnames" DataValueField="intmonthid" > </asp:DropDownList> 
                        
                        <asp:ObjectDataSource ID="odsMonthName" runat="server" SelectMethod="GetMonthandID" TypeName="Budget_BLL.Budget.Budget_Entry_BLL"></asp:ObjectDataSource>
                        
                      </td>
       

            </tr>
             <tr class="tblrowOdd"><td style="text-align:right" > <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                <td style="text-align:right"> <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" OnClientClick="Confirm()" /></td>
            </tr>
            </div>
                      
            </div>
         <div class="leaveApplication_container"> 
             <table>
                 <tr class="tblroweven"><td>
              <asp:GridView ID="grdvFGVsRawMaterialMonthly" runat="server" AutoGenerateColumns="False" AllowPaging="false"  BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdvFGVsRawMaterialMonthly_PageIndexChanging" OnRowDataBound="grdvFGVsRawMaterialMonthly_RowDataBound"  >
                  <AlternatingRowStyle BackColor="#CCCCCC" />
                  <Columns>
                     
                      <asp:TemplateField><HeaderTemplate>    
                <asp:CheckBox ID="chkbx" runat="server" onclick="CheckAll(this);" />   
                </HeaderTemplate>  
                <ItemTemplate><asp:CheckBox ID="chkbx" runat="server"/></ItemTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="Sl"> <ItemTemplate> <%#Container.DataItemIndex+1 %> 
                    <asp:HiddenField ID="hdnintBudgetYear" runat="server" Value='<%# Eval("intBudgetYear") %>' />
                    <asp:HiddenField ID="hdnintYearid" runat="server" Value='<%# Eval("intYearid") %>' />
                    <asp:HiddenField ID="hdnintMonth" runat="server" Value='<%# Eval("intMonth") %>' />
                    <asp:HiddenField ID="hdnintMatID" runat="server" Value='<%# Eval("intMatID") %>' />
                    <asp:HiddenField ID="hdnstrItemName" runat="server" Value='<%# Eval("strItemName") %>' />
                    </ItemTemplate></asp:TemplateField>
                    <asp:BoundField DataField="intYearid" HeaderText="Year" SortExpression="intYearid" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="intMatID" HeaderText="MatID" SortExpression="intMatID" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="strItemName" HeaderText="ItemName" SortExpression="strItemName" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField> 
                   
                                      
                 
                     <asp:TemplateField HeaderText="Material Qnt" HeaderStyle-HorizontalAlign="Center"  SortExpression="Quantity">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdndecMatQnt" runat="server" Value='<%# Bind("decMatQnt", "{0:0.0}") %>'></asp:HiddenField>  
                                       <asp:Label ID="lbldecMatQnt" runat="server" Visible="false" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("decMatQnt", "{0:0.00}"))) %>'></asp:Label>
                                      <asp:TextBox ID="txtdecMatQnt"  runat="server" onblur="" CssClass="txtBox" Width="125px" TextMode="Number" Text='<%# Bind("decMatQnt", "{0:0}") %>' AutoPostBack="false"></asp:TextBox>
                                     </ItemTemplate>
                                
                                </asp:TemplateField>
                      
   
                           <asp:TemplateField HeaderText="Material Amount" HeaderStyle-HorizontalAlign="Center"  SortExpression="Quantity">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdndecMatAmount" runat="server" Value='<%# Bind("decMatAmount") %>'></asp:HiddenField>  
                                       <asp:Label ID="lbldecMatAmount" runat="server" Visible="false" Text='<%# (""+Eval("decMatAmount")) %>'></asp:Label>
                                      <asp:TextBox ID="txtdecMatAmount"  runat="server" onblur="" CssClass="txtBox" Width="125px"  Text='<%# Bind("decMatAmount") %>' AutoPostBack="false"></asp:TextBox>
                                     </ItemTemplate>
                                
                                </asp:TemplateField>
                  
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
       
    </form>
</body>
</html>

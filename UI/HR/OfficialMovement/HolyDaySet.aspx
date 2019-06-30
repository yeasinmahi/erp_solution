<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HolyDaySet.aspx.cs" Inherits="UI.HR.OfficialMovement.HolyDaySet" %>

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
        $('#<%=grdvHolyDayAllJobstation.ClientID%>').gridviewScroll({
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
        var GridVwHeaderCheckbox = document.getElementById("<%=grdvHolyDayAllJobstation.ClientID %>");
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
        <div class="tabs_container"> Holyday Setup for All Job Station :<hr />
            <asp:HiddenField ID="hdnenroll" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
        <asp:HiddenField ID="hdnemail" runat="server"/><asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:HiddenField ID="hdnconfirm" runat="server"/>
        
        </div>
            <div>
        <table border="0"; style="width:Auto;";>

            <tr>
            <td style="text-align:right;"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit-Name : "></asp:Label></td>
            <td><asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" CssClass="dropdownList" 
                DataSourceID="ODSUnit" DataTextField="strUnit" DataValueField="intUnitID" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList>
                <asp:ObjectDataSource ID="ODSUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit"
                OldValuesParameterFormatString="original_{0}"><SelectParameters>
                <asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String"/>
                </SelectParameters></asp:ObjectDataSource>
            </td>
                  <td style="text-align:right;"><asp:Label ID="lblholiday" CssClass="lbl" runat="server" Text="Holiday List : "></asp:Label></td>
            <td><asp:DropDownList ID="ddlHoliday" runat="server" CssClass="dropdownList" DataSourceID="odsholidaylist" 
            DataValueField="intHolidayID" DataTextField="strHolidayName"></asp:DropDownList><asp:ObjectDataSource ID="odsholidaylist" 
            runat="server" SelectMethod="GetHolidayList" TypeName="HR_BLL.Global.Holiday"></asp:ObjectDataSource></td>
        
            </tr>

        

             <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtToDate', { 'dateFormat': 'Y-m-d' });</script></td>          
        </tr>
            
            <tr class="tblrowOdd"><td style="text-align:right" > <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                <td style="text-align:right"> <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" OnClientClick="Confirm()"  /></td>
            </tr>

            </table>
            </div>
         <div class="leaveApplication_container"> 
             <table>
                 <tr class="tblroweven"><td>
              <asp:GridView ID="grdvHolyDayAllJobstation" runat="server" AutoGenerateColumns="False" AllowPaging="false"  BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdvHolyDayAllJobstation_PageIndexChanging" OnRowDataBound="grdvHolyDayAllJobstation_RowDataBound" >
                  <AlternatingRowStyle BackColor="#CCCCCC" />
                  <Columns>
                     
                      <asp:TemplateField><HeaderTemplate>    
                <asp:CheckBox ID="chkbx" runat="server" onclick="CheckAll(this);" />   
                </HeaderTemplate>  
                <ItemTemplate><asp:CheckBox ID="chkbx" runat="server"/></ItemTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="Sl"> <ItemTemplate> <%#Container.DataItemIndex+1 %> 
                    <asp:HiddenField ID="hdnintReligionId" runat="server" Value='<%# Eval("intReligionId") %>' />
                    <asp:HiddenField ID="hdnintGroupID" runat="server" Value='<%# Eval("intGroupID") %>' />
                     <asp:HiddenField ID="hdnintJobTypeId" runat="server" Value='<%# Eval("intJobTypeId") %>' />
                    <asp:HiddenField ID="hdnintJobStationID" runat="server" Value='<%# Eval("intJobStationID") %>' />
                    
                    </ItemTemplate></asp:TemplateField>
                    <asp:BoundField DataField="strjobstation" HeaderText="strjobstation" SortExpression="strjobstation" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strGroup" HeaderText="strGroup" SortExpression="strGroup" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="strJobtype" HeaderText="strJobtype" SortExpression="strJobtype" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                  
                
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

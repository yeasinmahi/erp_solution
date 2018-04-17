<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TripCostDetaills.aspx.cs" Inherits="UI.Transport.TripvsCost.TripCostDetaills" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
 <script src="../../../../Content/JS/datepickr.min.js"></script>

    <script>
        
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

         <div class="leaveApplication_container"> 
             <table>
        
             
          <tr class="tblroweven"><td>
            <asp:GridView ID="grdvTripvsChallanDetindividually" runat="server" ShowFooter="True" AutoGenerateColumns="False" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnRowDataBound="grdvTripvsChallanDetindividually_RowDataBound" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <%--strtripcode ,strchallan ,dteintime ,dteouttime ,decqntcft ,strdriver,strcontact ,strhelper--%>
            <asp:TemplateField HeaderText="Sl"> <ItemTemplate> <%#Container.DataItemIndex+1 %> </ItemTemplate></asp:TemplateField>
            <asp:BoundField DataField="strtripcode" HeaderText="strtripcode" SortExpression="strtripcode" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            <asp:BoundField DataField="strchallan" HeaderText="strchallan" SortExpression="strchallan" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            <asp:BoundField DataField="dteintime" HeaderText="dteintime" SortExpression="dteintime"  DataFormatString="{0:dd/MM/yyyy}"  ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
            <asp:BoundField DataField="dteouttime" HeaderText="dteouttime" SortExpression="dteouttime"  DataFormatString="{0:dd/MM/yyyy}"  ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
            <asp:BoundField DataField="decqntcft" HeaderText="decqntcft" SortExpression="decqntcft" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            <asp:BoundField DataField="strdriver" HeaderText="strdriver" SortExpression="strdriver" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
           <asp:BoundField DataField="strhelper" HeaderText="strhelper" SortExpression="strhelper" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            <asp:BoundField DataField="strcontact" HeaderText="strcontact" SortExpression="strcontact" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
            <HeaderStyle CssClass="GridviewScrollHeader" /><PagerStyle CssClass="GridviewScrollPager" />
            </asp:GridView> </td>
            </tr>  
            </table>

            </div>





 <%--=========================================End My Code From Here=================================================--%>
  </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>  
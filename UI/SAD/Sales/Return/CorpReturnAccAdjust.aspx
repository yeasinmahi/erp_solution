<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CorpReturnAccAdjust.aspx.cs" Inherits="UI.SAD.Sales.Return.CorpReturnAccAdjust" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> <%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<!DOCTYPE html>

<html><head runat="server"><title></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder0" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
<webopt:BundleReference ID="BundleReference0" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/hrCSS" />
<script>
    function Confirm() {
        document.getElementById("hdnconfirm").value = "0";        
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
        if (confirm("Do you want to submit?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
        else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
    }

    function Registration(url) {
        newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=400,width=480,top=50,left=150, close=no');
        if (window.focus) { newwindow.focus() }
    }
    </script>
</head>
<body>
    <form id="frmACCAdjust" runat="server">
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
    <div class="leaveApplication_container"><b>Corporate Sales Return Amount Adjust: </b><asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnenroll" runat="server" /><hr />
    <table >
    <tr id="trdate" runat="server"><td style="text-align:left;"><asp:Label ID="lbldate" CssClass="lbl" runat="server" Text="JV Create Date : "></asp:Label></td>
    <td ><asp:TextBox ID="txtdate" runat="server"  CssClass="txtBox" Width="120px" ></asp:TextBox>
    <cc1:CalendarExtender ID="tdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtdate"></cc1:CalendarExtender></td></tr>
     </table>      
    <table>
    <tr><td><asp:GridView ID="dgvcorrtnaccapp" runat="server" AutoGenerateColumns="False" Font-Size="9px" BackColor="White" 
    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" EmptyDataText="No Bill Available for Adjust.">
    <AlternatingRowStyle BackColor="#CCCCCC"/>
    <Columns>   
    <asp:TemplateField HeaderText="SL." ><ItemTemplate><%# Container.DataItemIndex + 1 %>
     <asp:HiddenField id="hdncustid" Value='<%# Bind("intCustId")%>' runat="server" />
     <asp:HiddenField id="hdnttlamnt" Value='<%# Bind("Total")%>' runat="server" />
     <asp:HiddenField id="hdnchallanno" Value='<%# Bind("strChallanNo")%>' runat="server" />
     <asp:HiddenField id="hdnpk" Value='<%# Bind("pk")%>' runat="server" />
     </ItemTemplate></asp:TemplateField>
    <asp:TemplateField HeaderText="Customer Name" SortExpression="strCustName"><ItemTemplate>
    <asp:Label ID="lblcust" runat="server" Text='<%# Bind("Customer") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="200px" Wrap="true"/></asp:TemplateField>
        
    <asp:TemplateField HeaderText="Return Description" SortExpression="intchallan">
    <ItemTemplate><asp:Label ID="lblchallan" runat="server" Text='<%# Bind("strChallanNo") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Center" Width="65px" /></asp:TemplateField>
     <asp:TemplateField HeaderText="Return Cost" SortExpression="decAmount">
    <ItemTemplate><asp:Label ID="lblamount" runat="server" Text='<%# Bind("Total","{0:n}") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Center" Width="85px" /></asp:TemplateField>
    <asp:TemplateField HeaderText="View"><ItemTemplate><asp:Button ID="btnView" runat="server" Text="View"   CommandArgument='<%#Eval("intCustId") + "," +Eval("strChallanNo")%>' OnClick="btnView_Click" />
    </ItemTemplate></asp:TemplateField>  
    <asp:TemplateField HeaderText="Create JV"><ItemTemplate><asp:Button ID="btnACCApp" runat="server" Text="Create" OnClientClick="Confirm();"  CommandArgument='<%#Eval("intCustId") + "," +Eval("strChallanNo")+ "," +Eval("Total")%>' OnClick="btnACCapp_Click" />
    </ItemTemplate></asp:TemplateField>  
    </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White"/>
    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" /></asp:GridView>
    </td></tr>
   
    </table>
    </div>
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

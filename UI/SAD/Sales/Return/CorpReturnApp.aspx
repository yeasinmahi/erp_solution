<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CorpReturnApp.aspx.cs" Inherits="UI.SAD.Sales.Return.CorpReturnApp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> <%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<!DOCTYPE html>

<html><head runat="server"><title></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder0" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
<webopt:BundleReference ID="BundleReference0" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script>
        function Registration(url) {
            newwindow = window.open(url,"sub","height=400, width=800, scrollbars=yes, left=350, top=200, resizable=no, title=Preview,close=no");
            if (window.focus) {
                newwindow.focus()
            }
            //newwindow.onbeforeunload = function () {
            //    window.location.href='CorpReturnAccAdjust.aspx';
            //}
        }
    </script>
    <script>
        //function Confirm() {
        //document.getElementById("hdnconfirm").value = "0";        
        //var confirm_value = document.createElement("INPUT");
        //confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
        //if (confirm("Do you want to submit?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
        //else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }

        //}
        function ConfirmDelete() {
            document.getElementById("hdnconfirm").value = "0";
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to Delete?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
            else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
        }
  </script>
</head>
<body>
    <form id="frmRetnApp" runat="server">
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
    <div class="leaveApplication_container"><b>Corporate Sales Return Review: </b><asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnenroll" runat="server" /><hr />
    <table style="width:auto";>
   <tr><td style="text-align:center"><asp:Button ID="btnshow" runat="server" Text="Show" OnClick="btnshow_Click" /></td></tr>
    <tr><td>
    <asp:GridView ID="dgvcorrtnacc" runat="server" AutoGenerateColumns="False" Font-Size="9px" BackColor="White" 
    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical">
    <AlternatingRowStyle BackColor="#CCCCCC"/>
    <Columns>   
    <asp:TemplateField HeaderText="SL." ><ItemTemplate><%# Container.DataItemIndex + 1 %>
     <asp:HiddenField id="hdncustid" Value='<%# Bind("intCustId")%>' runat="server" />
     <asp:HiddenField id="hdnttlamnt" Value='<%# Bind("Total")%>' runat="server" />
     <asp:HiddenField id="hdnchallanno" Value='<%# Bind("ChallanNo")%>' runat="server" />
     <asp:HiddenField id="hdnpk" Value='<%# Bind("pk")%>' runat="server" />
     </ItemTemplate></asp:TemplateField>
  
    <asp:TemplateField HeaderText="Customer Name" SortExpression="strCustName"><ItemTemplate>
    <asp:Label ID="lblcust" runat="server" Text='<%# Bind("Customer") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="320px" Wrap="true"/></asp:TemplateField>
    <asp:TemplateField HeaderText="Product Description" SortExpression="strdesc">
    <ItemTemplate><asp:Label ID="lblDesc" runat="server" Text='<%# Bind("Descrip") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="left" Width="265px" Wrap="true" /></asp:TemplateField>
         <asp:TemplateField HeaderText="Return Description" SortExpression="intchallan">
    <ItemTemplate><asp:Label ID="lblchallan" runat="server" Text='<%# Bind("strChallanNo") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Center" Width="65px" /></asp:TemplateField>
    <asp:TemplateField HeaderText="Return Cost" SortExpression="decAmount">
    <ItemTemplate><asp:Label ID="lblamount" runat="server" Text='<%# Bind("Total","{0:n}") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Center" Width="85px" /></asp:TemplateField>
    <asp:TemplateField HeaderText="Edit"><ItemTemplate><asp:Button ID="btnedit" runat="server" Text="Edit"  CommandArgument='<%#Eval("intCustId") + "," +Eval("ChallanNo")+ "," +Eval("pk")+ "," +Eval("Total")%>' OnClick="btnedit_Click" />
    </ItemTemplate></asp:TemplateField>
        <asp:TemplateField HeaderText="Delete"><ItemTemplate><asp:Button ID="btndelete" runat="server" Text="Delete"  CommandArgument='<%#Eval("intCustId") + "," +Eval("ChallanNo")+","+Eval("pk")%>' OnClick="btndelete_Click" OnClientClick="ConfirmDelete();" />
    </ItemTemplate></asp:TemplateField> 
   <%-- <asp:TemplateField HeaderText="Review"><ItemTemplate><asp:Button ID="App" runat="server" Text="Review" OnClientClick="Confirm();"  CommandArgument='<%#Eval("intCustId") + "," +Eval("ChallanNo")+ "," +Eval("pk")+ "," +Eval("Total")%>' OnClick="App_Click" />
    </ItemTemplate></asp:TemplateField> --%> 
    </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White"/>
    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" /></asp:GridView>
    </td></tr>
    <tr><td style="text-align:right;"></tr>
    </table>
    </div>
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script >
        function test() {
            var new_window = window.open('some url')
            new_window.onbeforeunload = function () {
                window.open('')
            }
        }
    </script>
</body>
</html>

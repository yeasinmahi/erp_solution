<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DispatchDocView.aspx.cs" Inherits="UI.HR.Dispatch.DispatchDocView" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
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
    <script src="../Content/JS/CustomizeScript.js"></script>

    <style type="text/css">
        .dynamicDivbn {
            margin: 5px 5px 5px 5px;    width: Auto; 
    	    height: auto;
            background-color:#FFFFFF;
            font-size: 11px;
            font-family: verdana;
            color: #000;
            padding: 5px 5px 5px 5px;
        }
     </style>
   
</head>
<body>
    <form id="frmselfresign" runat="server">
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>   
    <%--=========================================Start My Code From Here===============================================--%>
    
    <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
    
    <div class="leaveApplication_container">
    <table class="tbldecoration" style="width:auto; float:left;">
    <tr class="tblheader"><td colspan="4"> DISPATCH DOCUMENT LIST :</td></tr>
    <tr><td>
    <asp:GridView ID="dgvDocPath" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" 
    BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical">
    <AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
    <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="20px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
    
    <asp:BoundField DataField="strDocName" HeaderText="File Name" ItemStyle-HorizontalAlign="Center" SortExpression="strDocName">
    <ItemStyle HorizontalAlign="left" Width="500px"/></asp:BoundField>

    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" SortExpression="">
    <ItemTemplate><asp:Button ID="btnDocDownload" class="nextclick" runat="server" Font-Size="9px" OnClick="btnDocDownload_Click"
    CommandArgument='<%# Eval("strDocName") %>' Text="Download Document" /></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField>

    </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
    </asp:GridView>
    </td></tr>
    <tr><td colspan="4"><hr /></td></tr> 
    </table>       
    </div>
    <br/><br/><br/>

       
   <%--=========================================End My Code From Here=================================================--%>     
    </form>
</body>
</html>
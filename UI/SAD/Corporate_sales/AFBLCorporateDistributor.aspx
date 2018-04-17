<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AFBLCorporateDistributor.aspx.cs" Inherits="UI.SAD.Corporate_sales.AFBLCorporateDistributor"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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


    </head>
<body>
    <form id="frmselfresign" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
   <%-- <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>--%>
   <%-- <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>--%>
    <%--<div style="height: 100px;"></div>--%>
    <%--<cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>--%>
<%--=========================================Start My Code From Here===============================================--%>
   <%-- <table  style="width:100%;height:2px">
    <tr class="tblroweven" > 
    <td style="text-align:justify;width:100%; font-size:12px; background-color:white;" " >
    <div id="topbox">  
      <h3 class="td">Corporate Sales Product Information</h3>      
    </div>
            </td>
    </tr> 
    </table>--%>
    <div style="width:100%">
          <h3 class="td">Corporate Sales Distributor Information</h3>      
        <table style="width:60%">
<tr style="height:15px">
                <td style="text-align:center">     
                <asp:Button ID="Button1" runat="server" Text="Show" OnClick="Button1_Click" Width="70px" />
                    &nbsp;</td>
               </tr>
        </table>    
      </div> 
       <table class="" style="width:100%; height:2px ">  
    <tr style="width:100%" >       
    <td style="text-align:justify;font-size:16px; background-color:white;" class="auto-style1">
  <p class="MsoNormal">
         <asp:GridView ID="gvdistlist" runat="server"  BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"  ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" Font-Names="Calibri">
               <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:TemplateField HeaderText="SL." ><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate><HeaderStyle Width="100px" Wrap="true" Height="20px" Font-Size="Large" /><ItemStyle Width="100px" Wrap="true"></ItemStyle></asp:TemplateField>
                <asp:BoundField DataField="strarea" HeaderText="Area Name" SortExpression="Area" ControlStyle-Width="100px"><ControlStyle Width="100px" /><HeaderStyle Width="100px" Wrap="true"  Height="20px" Font-Size="Large"/><ItemStyle Width="100px" Wrap="true"></ItemStyle></asp:BoundField>
                <asp:BoundField DataField="strterritory" HeaderText="Territory Name" SortExpression="Terr"  ControlStyle-Width="100px"><ControlStyle Width="100px" /><HeaderStyle Width="100px" Wrap="true" Height="100px" Font-Size="Large" /><ItemStyle Width="100px" Wrap="true"></ItemStyle></asp:BoundField>
                <asp:BoundField DataField="strpoint" HeaderText="Point Name" SortExpression="Point" ControlStyle-Width="100px"><HeaderStyle Width="100px" Wrap="true" Height="20px" Font-Size="Large" /><ItemStyle Width="100px" Wrap="true"></ItemStyle></asp:BoundField> 
                <asp:BoundField DataField="strName" HeaderText="Distributor Name" SortExpression="Distributor" ControlStyle-Width="450px"><ControlStyle Width="400px" /><HeaderStyle Width="400px" Wrap="true"  Height="20px" Font-Size="Large"/><ItemStyle Width="100px" Wrap="true"></ItemStyle></asp:BoundField>
                <asp:BoundField DataField="strAddress" HeaderText="Address" SortExpression="Address"  ControlStyle-Width="480px"><ControlStyle Width="400px" /><HeaderStyle Width="400px" Wrap="true" Height="20px" Font-Size="Large" /><ItemStyle Width="400px" Wrap="true"></ItemStyle></asp:BoundField>
                <asp:BoundField DataField="strPhone" HeaderText="Distributor Contact" SortExpression="Phone" ControlStyle-Width="120px"><HeaderStyle Width="100px" Wrap="true" Height="20px" Font-Size="Large" /><ItemStyle Width="100px" Wrap="true"></ItemStyle></asp:BoundField>   
                <asp:BoundField DataField="strEmployeeName" HeaderText="Sales Person" SortExpression="Person" ControlStyle-Width="200px"><ControlStyle Width="200px" /><HeaderStyle Width="200px" Wrap="true"  Height="20px" Font-Size="Large"/><ItemStyle Width="100px" Wrap="true"></ItemStyle></asp:BoundField>
                <asp:BoundField DataField="strDesignation" HeaderText="Designation" SortExpression="PersonDesignation"  ControlStyle-Width="200px"><ControlStyle Width="200px" /><HeaderStyle Width="200px" Wrap="true" Height="20px" Font-Size="Large" /><ItemStyle Width="100px" Wrap="true"></ItemStyle></asp:BoundField>
                        
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" Font-Size="Large" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>    
        </p>
            </td>
    </tr> 
    </table>

    <%--=========================================End My Code From Here=================================================--%>
   <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>

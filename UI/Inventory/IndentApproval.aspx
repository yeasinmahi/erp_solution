<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndentApproval.aspx.cs" Inherits="UI.Inventory.IndentApproval" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="../Content/CSS/Suppliercss.css" rel="stylesheet" />
    

    <%--<script>
        function SupApproval(reqsid) {
            window.open('IndentDetail.aspx?intIndent=' + reqsid, 'sub', "height=600, width=900, scrollbars=yes, left=200, top=45, resizable=no, title=Preview");
        }
    </script>--%>
    
      <script>
          function Registration(url) {
              newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=500,width=800,top=150,left=350, close=no');
              if (window.focus) { newwindow.focus() }
          }
         </script>
    
    
    
    
</head>
<body>
    <form id="frmauditdeptrealize" runat="server">
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


<tr><td class="auto-style13"> 
            
        <h1 class="auto-style2">Indent Approval</h1>
   </td>
</tr>
        <table>
         <caption style="width: 655px">
            
        </caption>
        </table>
       

<table>
    <tr>
        <%--<tdclass="auto-style4"></tdclass="auto-style2">--%>

         <td class="auto-style15"></td>

        <td>
            <asp:Label ID="Label3" runat="server" Text="Ware House :"></asp:Label>
        </td>

       <td class="auto-style5">
                        <asp:DropDownList ID="ddlWNName" runat="server" Height="20px" Width="175px" OnSelectedIndexChanged="ddlWNName_SelectedIndexChanged">
                            
                        </asp:DropDownList>
                    </td>
   </tr>
    </table>

<table>


    <tr>
        <td>
            <asp:Label ID="Label15" runat="server" Text="Sttatus :"></asp:Label>
            <%--//<asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="175px">--%>
            <td>
                <asp:DropDownList ID="ddlStatus" runat="server" Height="20px" Width="120px">
                    <asp:ListItem Value="1">Pending</asp:ListItem>
                    <asp:ListItem Value="2">Approved</asp:ListItem>
                    <asp:ListItem Value="3">Rejected</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="Label1" runat="server"  Text="From Date :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFromDate" runat="server" AutoPostBack="false" BorderStyle="Solid" CssClass="txtBox" Enabled="true" Height="18px" TabIndex="1117" Width="100px"></asp:TextBox>
                <cc1:CalendarExtender ID="PIValidityDate" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate">
                </cc1:CalendarExtender>
            </td>
        </td>
        <td>
            <asp:Label ID="Label2" runat="server" Text="To Date :"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtTodate" runat="server" AutoPostBack="false" BorderStyle="Solid" CssClass="txtBox" Enabled="true" Height="18px" TabIndex="1117" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtTodate">
            </cc1:CalendarExtender>
        </td>
        <td>

        </td>
        <td class="auto-style6">
         <asp:Button ID="btnShow" runat="server" Height="30px"  OnClick="submit_Click" style="text-align: center" Text="Show" Width="117px" />
         </td>

        <caption style="width: 657px">
            
        </caption>
</tr>
    </table>
    
    <table>
            <asp:GridView ID="dgvReport" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" Font-Bold="false" Font-Size="10px" FooterStyle-BackColor="#999999" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" ShowFooter="true" >
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:BoundField DataField="intIndentID" HeaderText="Indent ID" ItemStyle-HorizontalAlign="Center" SortExpression="intIndentID">
                    <ItemStyle HorizontalAlign="center" Width="50px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="dteIndentDate" HeaderText="Indent Date" ItemStyle-HorizontalAlign="Center" SortExpression="dteIndentDate" DataFormatString="{0:d}">
                    <ItemStyle HorizontalAlign="center" Width="75px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="dteDueDate" HeaderText="Due Date" ItemStyle-HorizontalAlign="Center" SortExpression="dteDueDate" DataFormatString="{0:d}">
                    <ItemStyle HorizontalAlign="center" Width="75px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strIndentType" HeaderText="Indent Type" ItemStyle-HorizontalAlign="Center" SortExpression="strIndentType">
                    <ItemStyle HorizontalAlign="center" Width="90px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strEmployeeName" HeaderText="Indent by" ItemStyle-HorizontalAlign="Center" SortExpression="strEmployeeName">
                    <ItemStyle HorizontalAlign="center" Width="200px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Indent Detail">
                    <ItemTemplate>
                    <asp:Button ID="Complete" runat="server" Text="View Detail" CommandName="complete" OnClick="Complete_Click" CommandArgument='<%# Eval("intIndentID") %>' /></ItemTemplate>
                    </asp:TemplateField> 


              <%--<asp:TemplateField HeaderText="Complete">
             <ItemTemplate>
             <asp:Button ID="Complete" runat="server" Text="Approve" CommandName="complete" OnClick="Complete_Click"   CommandArgument='<%# Eval("strOrgMail") %>' /></ItemTemplate>
             </asp:TemplateField> --%>

                </Columns>
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
        </td>
    </tr>
    </tr>
        </table>



          
   <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
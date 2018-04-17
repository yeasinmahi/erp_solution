 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndentDetail.aspx.cs" Inherits="UI.Inventory.IndentDetail" %>
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
    <style type="text/css">
        .auto-style15 {
            width: 154px;
        }
        .auto-style16 {
            width: 650px;
        }
        .auto-style17 {
            color: #333333;
            width: 650px;
            font-weight: normal;
            font-size: large;
            text-align: center;
        }
    </style>
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
    <div style="height: 6px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>

<table>

<tr><td> 
    <h1 class="auto-style17"><strong>Indent Detail</strong></h1>
</td>


</tr>
</table>


<table style="width: 691px">
<tr><td> 
    <%--<h1 class="auto-style17"></h1>--%>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

</td>

</tr>
</table>



    <tr><td>
        <h1 class="auto-style18">Indent Detail</h1>
   </td>
</tr>
        <%--<table>
         <caption style="width: 655px">
            
        </caption>
        </table>--%>
       

<table>

            <tr>
                <td class="auto-style6">
                    <asp:Button ID="btnReject" runat="server" Height="30px" OnClick="submitReject_Click" style="text-align: center" Text="Reject" Width="117px" />
                </td>
       

    
                    <td class="auto-style6">
                      <asp:Button ID="btnCancelSelected" runat="server" Height="30px" OnClick="submitClear_Click" style="text-align: center" Text="Cancel Selected" Width="117px" />
                     </td>
                
                        </td>
                        <td class="auto-style6">
                            <asp:Button ID="btnApprove" runat="server" Height="30px" OnClick="submitApprove_Click" style="text-align: center" Text="Approve" Width="117px" />
                        </td>
                        <td>
                            <caption style="width: 689px">
                            </caption>
                        </td>
                    </tr>

            </tr>
    </table>
    
 
            <asp:GridView ID="dgvDetailIndent" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" Font-Bold="false" Font-Size="10px" FooterStyle-BackColor="#999999" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" ShowFooter="true" OnRowDeleting="dgvDetailIndent_RowDeleting" >
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                  <%--  <asp:BoundField DataField="intItemID" HeaderText="Item ID" ItemStyle-HorizontalAlign="Center" SortExpression="intIttemID">
                    <ItemStyle HorizontalAlign="center" Width="50px" />
                    </asp:BoundField>--%>

                     <asp:TemplateField HeaderText="intItemID" SortExpression="strChallanNo"><ItemTemplate>
        <asp:HiddenField ID="itemid1" runat="server" Value='<%# Eval("intItemID") %>' /><asp:HiddenField ID="iname10" runat="server" Value='<%# Eval("intItemID") %>' />
        <asp:Label ID="itemid" runat="server" Text='<%# Bind("intItemID") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="200px"/></asp:TemplateField>   


                    <asp:BoundField DataField="strItem" HeaderText="Item Name" ItemStyle-HorizontalAlign="Center" SortExpression="strItem">
                    <ItemStyle HorizontalAlign="Left" Width="220px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strUoM" HeaderText="UoM" ItemStyle-HorizontalAlign="Center" SortExpression="strUoM">
                    <ItemStyle HorizontalAlign="center" Width="65px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="currentStock" HeaderText="Current Stock" ItemStyle-HorizontalAlign="Center" SortExpression="currentStock">
                    <ItemStyle HorizontalAlign="center" Width="90px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="numSafetyStock" HeaderText="Safety Stock" ItemStyle-HorizontalAlign="Center" SortExpression="numSafetyStock">
                    <ItemStyle HorizontalAlign="center" Width="90px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Purpose" HeaderText="Purpose/Use For" ItemStyle-HorizontalAlign="Center" SortExpression="Purpose">
                    <ItemStyle HorizontalAlign="center" Width="220px" />
                    <%--</asp:BoundField>--%>
<%--                    <asp:BoundField DataField="status" HeaderText="Status" ItemStyle-HorizontalAlign="Center" SortExpression="status">
                    <ItemStyle HorizontalAlign="center" Width="80px" />--%>
                    
                   <%-- <asp:TemplateField HeaderText="Clear">--%>
<%--                    <ItemTemplate>
                    <asp:Button ID="Delete" runat="server" Text="Delete" CommandName="complete" OnClick="Complete_Click" CommandArgument='<%# Eval("intItemID") %>' /></ItemTemplate>
                    </asp:TemplateField> --%>
                       </asp:BoundField>
                        <asp:CommandField ShowDeleteButton="true"  ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true"> 
                            <ControlStyle Font-Bold="True" ForeColor="Red"></ControlStyle>
                           </asp:CommandField>


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

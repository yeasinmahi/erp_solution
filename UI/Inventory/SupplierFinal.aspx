<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierFinal.aspx.cs" Inherits="UI.Inventory.SupplierFinal" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
   <%-- <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />--%>
    <%--<link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>--%>
     <link href="../Content/CSS/Suppliercss.css" rel="stylesheet" />

   <%-- <script>
        function SupApproval(reqsid) {
            window.open('SupplierEnlistment.aspx?intSuppMasterID=' + reqsid, 'sub', "height=600, width=900, scrollbars=yes, left=200, top=45, resizable=no, title=Preview");
        }
    </script>--%>
  <script>
      function Registration(url, msid) {
          newwindow = window.open(url + '?intSuppMasterID=' + msid, 'sub', 'scrollbars=yes,toolbar=0,height=500,width=800,top=150,left=350, close=no');
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
    <div id="navbar"  style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>


<td class="auto-style2"> 
            
<h1 class="auto-style3">Supplier Enlistment Request</h1>

     <hr/>

<%--<asp:Button ID="submit" runat="server" Height="30px" OnClick="submit_Click" Text="Show" Width="153px" />--%>
   

  
       
</table>
 </td>
        <td>
        
                  <asp:GridView ID="dgvlist" runat="server" AutoGenerateColumns="False"   BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" Font-Bold="False" Font-Size="11px" FooterStyle-BackColor="#999999" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" GridLines="None" ShowFooter="True" BorderColor="White" OnSelectedIndexChanged="dgvlist_SelectedIndexChanged" CellSpacing="1" onrowdatabound="dgvlist_RowDataBound1" >
                  <Columns>
                    <asp:BoundField DataField="intSuppMasterID" HeaderText="ID" Visible="true" ItemStyle-HorizontalAlign="Center" SortExpression="intSuppMasterID">
                    <ItemStyle HorizontalAlign="center" Width="40px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strSuppMasterName" HeaderText="Name" ItemStyle-HorizontalAlign="Center" SortExpression="strReffNo">
                    <ItemStyle HorizontalAlign="center" Width="200px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strOrgAddress" HeaderText="Address" ItemStyle-HorizontalAlign="Center" SortExpression="strOrgAddress">
                    <ItemStyle HorizontalAlign="center" Width="250px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strOrgMail" HeaderText="Mail" ItemStyle-HorizontalAlign="Center" SortExpression="strOrgMail">
                    <ItemStyle HorizontalAlign="center" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strOrgContactNo" HeaderText="Contact" ItemStyle-HorizontalAlign="Center" SortExpression="strOrgContactNo">
                    <ItemStyle HorizontalAlign="center" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strOrgFAXNo" HeaderText="Fax" ItemStyle-HorizontalAlign="Center" SortExpression="strOrgFAXNo">
                    <ItemStyle HorizontalAlign="center" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strBusinessType" HeaderText="Business" ItemStyle-HorizontalAlign="Center" SortExpression="strBusinessType">
                    <ItemStyle HorizontalAlign="center" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strServiceType" HeaderText="Service" ItemStyle-HorizontalAlign="Center" SortExpression="strServiceType">
                    <ItemStyle HorizontalAlign="center" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strBIN" HeaderText="Bin" ItemStyle-HorizontalAlign="Center" SortExpression="strBIN">
                    <ItemStyle HorizontalAlign="center" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strTIN" HeaderText="Tin" ItemStyle-HorizontalAlign="Center" SortExpression="strTIN">
                    <ItemStyle HorizontalAlign="center" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strVATRegNo" HeaderText="VatR" ItemStyle-HorizontalAlign="Center" SortExpression="strVATRegNo">
                    <ItemStyle HorizontalAlign="center" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strTradeLisenceNo" HeaderText="Trade Lic" ItemStyle-HorizontalAlign="Center" SortExpression="strTradeLisenceNo">
                    <ItemStyle HorizontalAlign="center" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strReprName" HeaderText="CP Name" ItemStyle-HorizontalAlign="Center" SortExpression="strReprName">
                    <ItemStyle HorizontalAlign="center" Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strPayToName" HeaderText="PayTo" ItemStyle-HorizontalAlign="Center" SortExpression="strPayToName">
                    <ItemStyle HorizontalAlign="center" Width="200px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strSupplierType" HeaderText="SType" ItemStyle-HorizontalAlign="Center" SortExpression="strSupplierType">
                    <ItemStyle HorizontalAlign="center" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="dteEnlistmentDate" HeaderText="Enl Date" ItemStyle-HorizontalAlign="Center" SortExpression="dteEnlistmentDate">
                    <ItemStyle HorizontalAlign="center" Width="75px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="dteLastActionTime" HeaderText="LastAct" ItemStyle-HorizontalAlign="Center" SortExpression="dteLastActionTime">
                    <ItemStyle HorizontalAlign="center" Width="75px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ysnActive" HeaderText="Active" ItemStyle-HorizontalAlign="Center" SortExpression="ysnActive">
                    <ItemStyle HorizontalAlign="center" Width="75px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="intRequestBy" HeaderText="Enroll" ItemStyle-HorizontalAlign="Center" SortExpression="intRequestBy">
                    <ItemStyle HorizontalAlign="center" Width="75px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strShortName" HeaderText="ShortN" ItemStyle-HorizontalAlign="Center" SortExpression="strShortName">
                    <ItemStyle HorizontalAlign="center" Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="intMasterSupplierType" HeaderText="Type" ItemStyle-HorizontalAlign="Center" SortExpression="intMasterSupplierType">
                    <ItemStyle HorizontalAlign="center" Width="50px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="intPreferedInstrument" HeaderText="Inst." ItemStyle-HorizontalAlign="Center" SortExpression="intPreferedInstrument">
                    <ItemStyle HorizontalAlign="center" Width="50px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strACNO" HeaderText="A/C No" ItemStyle-HorizontalAlign="Center" SortExpression="strACNO">
                    <ItemStyle HorizontalAlign="center" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="strRoutingNo" HeaderText="Routing" ItemStyle-HorizontalAlign="Center" SortExpression="strRoutingNo">
                    <ItemStyle HorizontalAlign="center" Width="75px" />
                    </asp:BoundField>
                    
                    <asp:BoundField DataField="strBank" HeaderText="Bank" ItemStyle-HorizontalAlign="Center" SortExpression="strBank">
                    <ItemStyle HorizontalAlign="center" Width="100px" />
                    </asp:BoundField>
                    
                    <asp:BoundField DataField="strBranch" HeaderText="Branch" ItemStyle-HorizontalAlign="Center" SortExpression="strBranch">
                    <ItemStyle HorizontalAlign="center" Width="75px" />
                    </asp:BoundField>


                    <%--<asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" SortExpression="">
                    <ItemTemplate><asp:Button ID="btnComplete" class="button" runat="server" Font-Size="10px" ForeColor="Red" OnClick="Cancel_Click"
                    CommandArgument='<%# Eval("intSuppMasterID")  %>' Text="Approved" /></ItemTemplate></asp:TemplateField>--%>

                    <asp:TemplateField HeaderText="Complete">
                    <ItemTemplate>
                    <asp:Button ID="Complete" runat="server" Text="Approve" CommandName="complete" style="text-align: center; background-color: #CEEFB8;" ForeColor="blue" OnClick="Complete_Click" CommandArgument='<%# Eval("intSuppMasterID") %>' /></ItemTemplate>
                    </asp:TemplateField> 
                </Columns>
                      <FooterStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                      <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                      <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                      <SortedAscendingCellStyle BackColor="#F1F1F1" />
                      <SortedAscendingHeaderStyle BackColor="#594B9C" />
                      <SortedDescendingCellStyle BackColor="#CAC9C9" />
                      <SortedDescendingHeaderStyle BackColor="#33276A" />
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
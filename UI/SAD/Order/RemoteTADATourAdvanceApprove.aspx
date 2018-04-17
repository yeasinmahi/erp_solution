<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoteTADATourAdvanceApprove.aspx.cs" Inherits="UI.SAD.Order.RemoteTADATourAdvanceApprove" %>

<%@ Register Assembly="AjaxControlToolkit"  Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script src="../../../../Content/JS/datepickr.min.js"></script>


    <script>
        function Registration(url) {
            newwindow = window.open('RemoteTADATourAdvanceApproveDetaills.aspx', 'sub', 'scrollbars=yes,toolbar=0,height=500,width=800,top=150,left=350, close=no');
            if (window.focus) { newwindow.focus() }
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

        
    <div class="tabs_container">Advance   TA - DA information Approve by Immediate Supervisor  :<asp:HiddenField ID="hdnAreamanagerEnrol" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
        
        <asp:HiddenField ID="HiddenUnit" runat="server"/><asp:HiddenField ID="hdnData" runat="server"/>
       
        <hr /></div>
     
                <div class="leaveApplication_container">
              <table>        
          <tr class="tblroweven"><td colspan="4">
              </td>
         </tr>          
                   <tr class="tblrowodd">
                <td>
       

                    <asp:GridView ID="grdvForPendingTADAShow" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdvForPendingTADAShow_PageIndexChanging" OnRowDataBound="grdvForPendingTADAShow_RowDataBound">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>

                    <asp:BoundField DataField="intid" HeaderText="intid" SortExpression="intid" ControlStyle-Width="10%" > <ControlStyle Width="10%" /></asp:BoundField>
                    <asp:BoundField DataField="strEmplName" HeaderText="EmployeName" SortExpression="strEmplName" ControlStyle-Width="10%" > <ControlStyle Width="250%" /> </asp:BoundField>
                    <asp:BoundField DataField="intEnrol" HeaderText="Enrol" SortExpression="intEnrol" ControlStyle-Width="10%" ><ControlStyle Width="10%" />  </asp:BoundField>
                    <asp:BoundField DataField="intTotalday" HeaderText="Total Day" SortExpression="intTotalday" ControlStyle-Width="10%" > <ControlStyle Width="10%" /> </asp:BoundField>
                    <asp:BoundField DataField="decAdvAmount" HeaderText="Advance Tk." SortExpression="decAdvAmount" ControlStyle-Width="10%" ><ControlStyle Width="10%" /> </asp:BoundField>
                    <asp:BoundField DataField="strJobTpe" HeaderText="Job Type" SortExpression="strJobTpe" ControlStyle-Width="10%" > <ControlStyle Width="250%" /> </asp:BoundField>
                    <asp:TemplateField HeaderText="Det.">
                     <ItemTemplate>
                     <asp:Button ID="Complete" runat="server" Text="Deaills" class="button" CommandName="complete" OnClick="Complete_Click"   CommandArgument='<%# Eval("intid") %>' /></ItemTemplate>
                     </asp:TemplateField>  

     
                            </Columns>
                            <FooterStyle BackColor="Tan" />
                            <HeaderStyle BackColor="Tan" Font-Bold="True" />
                            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                            <SortedAscendingCellStyle BackColor="#FAFAE7" />
                            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                            <SortedDescendingCellStyle BackColor="#E1DB9C" />
                            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                            </asp:GridView>



                </td>


            </tr>

    </table>
 </div>

                    <%--=========================================End My Code From Here=================================================--%>
   </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>  


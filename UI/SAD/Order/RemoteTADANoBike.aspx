<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoteTADANoBike.aspx.cs" Inherits="UI.SAD.Order.RemoteTADANoBike" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

 
    <script src="../../Content/JS/datepickr.min.js"></script>




      
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
    <div class="tabs_container"> TA - DA information input (None Bike User)  :<asp:HiddenField ID="hdnenroll" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/><hr /></div>
        <table border="0"; style="width:Auto"; >    


        <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtToDate', { 'dateFormat': 'Y-m-d' });</script></td>          
        </tr>

        <tr><td style="text-align:right" colspan="2"> <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
            <td><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td>

        </tr>
             
        <tr class="tblrowodd">
             <td colspan="4">
                 <asp:GridView ID="grvStudentDetails" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" OnRowDeleting="grvStudentDetails_RowDeleting"  OnSelectedIndexChanged="grvStudentDetails_SelectedIndexChanged" ShowFooter="True"   >
                         <Columns>
                             <asp:BoundField DataField="RowNumber" HeaderText="SNo" SortExpression="intSn" HeaderStyle-Width="50px" />
                             <asp:TemplateField HeaderText=" From Address " SortExpression="strFromadr">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtFromAddress" runat="server" TextMode="MultiLine" ></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText=" TO Address " SortExpression="strToadr">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtToAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Transport Mode" SortExpression="strTransport">
                                 <ItemTemplate>
                                     <asp:DropDownList ID="drpTransportMode" runat="server">
                                         <asp:ListItem Value="RICK"> Rickshaw </asp:ListItem>
                                         <asp:ListItem Value="BUS"> Bus </asp:ListItem>
                                         <asp:ListItem Value="CNG"> C.N.G </asp:ListItem>
                                         <asp:ListItem Value="MOTBIKE">Air </asp:ListItem>
                                         <asp:ListItem Value="Train"> Train </asp:ListItem>
                                     </asp:DropDownList>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText=" Movement Duration " SortExpression="decMovDuration">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtDuration" runat="server" Width="45px" ></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText=" Fare (Tk.) " SortExpression="monFaretk" >
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtFare" runat="server" Width="45px" ></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText=" Remarks " SortExpression="strSupportno">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtSupportingNo" runat="server" TextMode="MultiLine" ></asp:TextBox>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                                 
                                 
                                  <asp:TemplateField HeaderText=" D.A (Tk.) " SortExpression="monDATk">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtDa" runat="server" Width="45px"></asp:TextBox>
                                 </ItemTemplate>
                                  </asp:TemplateField>
                                 
                                 <asp:TemplateField HeaderText=" HotelBill (Tk.) " SortExpression="monHoteltk">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtHotelBill" runat="server" Width="45px" ></asp:TextBox>
                                 </ItemTemplate>
                                 </asp:TemplateField>

                                 <asp:TemplateField HeaderText=" Others (Tk.) " SortExpression="monOthertk">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtOthers" runat="server" Width="45px" ></asp:TextBox>
                                 </ItemTemplate>
                                  </asp:TemplateField>
                             <asp:TemplateField HeaderText=" D. Total (Tk.) " SortExpression="monTotaltk" >
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtDTotal" runat="server"  ReadOnly="true" Enabled="false"></asp:TextBox>
                                 </ItemTemplate>




                                 
                                  <FooterStyle HorizontalAlign="Right" />
                                 <FooterTemplate>
                                     <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" Text="Add New Row" Font-Bold="true" BackColor="#66ff99" />
                                 </FooterTemplate>
                             </asp:TemplateField>
                             <asp:CommandField ControlStyle-BackColor="#ff9900" ShowDeleteButton="True" />
                         </Columns>
                         <FooterStyle BackColor="#CCCCCC" />
                         <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                         <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                         <RowStyle BackColor="White" />
                         <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                         <SortedAscendingCellStyle BackColor="#F1F1F1" />
                         <SortedAscendingHeaderStyle BackColor="#808080" />
                         <SortedDescendingCellStyle BackColor="#CAC9C9" />
                         <SortedDescendingHeaderStyle BackColor="#383838" />
                     </asp:GridView>
                  

             </td>
                 


              </tr>

           

            





        </table>

 <caption >
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;  Grand Total: 
                         <asp:Label ID="lblGrandTotal" runat="server" Text="0" Font-Bold="true" BackColor="#ccffcc"></asp:Label>
                     </caption>

    </div>

<%--=========================================End My Code From Here=================================================--%>
   </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
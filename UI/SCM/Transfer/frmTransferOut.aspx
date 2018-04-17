<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmTransferOut.aspx.cs" Inherits="UI.SCM.Transfer.frmTransferOut" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head runat="server"><title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />  
</head>
<body>
<form id="frmTransferOrder" runat="server">
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
       <div class="tabs_container"> TRANSFER ORDER<hr /></div>
        <table  class="tbldecoration" style="width:auto; float:left;">                           
        <tr><td colspan="5"><hr /></td></tr>                              
        <tr class="tblrowodd">           
            <td style="text-align:left;">Shippoint Name:</td>
            <td style="text-align:left;"> <asp:DropDownList ID="ddlshippoint" runat="server"></asp:DropDownList>  </td>
            <td style='text-align: left; width:120px;'>Office Name: </td>
            <td style='text-align: left;'><asp:DropDownList ID="ddlOfficeName" CssClass="ddllist" runat="server"></asp:DropDownList></td> 
            <td style="text-align:right;"> 
                &nbsp;</td>
        </tr>           
        <tr><td>&nbsp;</td>
            <td><asp:TextBox ID="txtItemName" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtItemName"
            ServiceMethod="ItemnameSearch" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender> </td>
            <td>&nbsp;</td>
            <td colspan="2">&nbsp;</td></tr> 
         <tr>
            <td colspan="3">&nbsp &nbsp 
            <asp:Button ID="tbnshow" runat="server" Text="Show" OnClick="btnShow_Click" />  </td>
        </tr>                        
        <tr><td colspan="5"><hr />


            <asp:GridView ID="dgvExcelOrder" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="Small"  ShowFooter="True">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns> 
                 
            <asp:TemplateField><HeaderTemplate><asp:CheckBox ID="chkHeader" runat="server" />
            </HeaderTemplate><ItemTemplate><asp:CheckBox ID="chkRow" runat="server" /></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Custid" SortExpression="Custid"><ItemTemplate><asp:Label ID="lblCustid" runat="server" Text='<%# Bind("intCustid") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="70px"/><FooterTemplate><div style="padding:0 0 5px 0"><asp:Label ID="lbl" Width="100px"  runat="server" Text="Grand-Total :" /></div>
            </FooterTemplate></asp:TemplateField> 
                           
            <asp:BoundField DataField="strLine" HeaderText="line" ReadOnly="True" SortExpression="strline"/>
            <asp:BoundField DataField="strregion" HeaderText="Region" ReadOnly="True" SortExpression="strregion"/>
            <asp:BoundField DataField="strarea" HeaderText="Area" ReadOnly="True" SortExpression="strarea"/>
            <asp:BoundField DataField="strTerritory" HeaderText="Territory" ReadOnly="True" SortExpression="strTerritory"/>
            <asp:BoundField DataField="strPoint" HeaderText="Point" ReadOnly="True" SortExpression="Point"/>
            <asp:BoundField DataField="strName" HeaderText="strName" ReadOnly="True" SortExpression="strName"/>             
                
           <%-- <asp:TemplateField HeaderText="Qty" SortExpression="Pending">
            <ItemTemplate><asp:Label ID="lblqty" runat="server" Text='<%# (""+Eval("qty","{0:n0}")) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lblPending" runat="server" Text='<%# Pendingtotal %>' /></FooterTemplate>
            </asp:TemplateField>--%>
           
             <asp:TemplateField HeaderText="View">
            <ItemTemplate> 
            <asp:Button ID="Complete" runat="server" Text="View" CommandName="complete"  OnClick="btnDelete" Font-Bold="true" BackColor="#00ccff"  CommandArgument='<%# Eval("intCustid")+ "^" +Eval("intvid") %>' />
            </ItemTemplate> </asp:TemplateField>

            </Columns>
            <FooterStyle BackColor="#F3CCC2" BorderStyle="None" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>

            <%--<asp:GridView ID="dgvVehicle" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="Small" ShowFooter="True">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>  
         
            <asp:TemplateField HeaderText="Custid" SortExpression="Custid"><ItemTemplate><asp:Label ID="lblCustid" runat="server" Text='<%# Bind("intCustid") %>'></asp:Label>
            <asp:HiddenField ID="hdnvid" runat="server" Value='<%# Bind("intVid") %>' /></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="70px"/><FooterTemplate><div style="padding:0 0 5px 0"><asp:Label ID="lbl" Width="100px"  runat="server" Text="Grand-Total :" /></div>
            </FooterTemplate></asp:TemplateField>   

            <asp:BoundField DataField="strName" HeaderText="strName" ReadOnly="True" SortExpression="strName"/>                                 
            <asp:BoundField DataField="strVno" HeaderText="Vehicle No" ReadOnly="True" SortExpression="strline"/>
            <asp:BoundField DataField="stremployeename" HeaderText="Driver Name" ReadOnly="True" SortExpression="strregion"/>
            <asp:BoundField DataField="dtedate" HeaderText="Date" ReadOnly="True" DataFormatString="{0:d}" SortExpression="strarea"/>
                     
            <asp:TemplateField HeaderText="Delete">
            <ItemTemplate> 
            <asp:Button ID="Complete" runat="server" Text="Delete" CommandName="complete"  OnClick="btnDelete" Font-Bold="true" BackColor="#00ccff"  CommandArgument='<%# Eval("intCustid")+ "^" +Eval("intvid") %>' />
            </ItemTemplate> </asp:TemplateField>

            </Columns>
            <FooterStyle BackColor="#F3CCC2" BorderStyle="None" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>--%>
            </td></tr>          
        </tr>             
        </table>
        </div>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
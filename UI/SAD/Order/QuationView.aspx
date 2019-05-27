<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuationView.aspx.cs" Inherits="UI.SAD.Order.QuationView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html >

<html >
<head id="Head1" runat="server">
    <title>Untitled Page</title>

    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference4" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../../../Content/CSS/GridHEADER.css" rel="stylesheet" />
    <script src="../../../../Content/JS/JQUERY/jquery-1.10.2.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/jquery-ui.min.js"></script>
    <script src="../../../../Content/JS/datepickr.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/MigrateJS.js"></script>
    <script src="../../../../Content/JS/JQUERY/GridviewScroll.min.js"></script>
    <script type="text/javascript">
        function ShowPopUpC(url) {
            var rand_no = Math.floor(11 * Math.random());
            url = url + '&rnd=' + rand_no;
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,scroll=1,height=1000,width=600,top=70,left=5,right=20');
            if (window.focus) { newwindow.focus() }
        }
        function ShowPopUpE(url) {
            var rand_no = Math.floor(11 * Math.random());
            url = url + '&rnd=' + rand_no;
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=550,width=1000,top=70,left=220');
            if (window.focus) { newwindow.focus() }
        }
        function ValidateComplete(sender, args) {
            if (!confirm('Do you want to complete this voucher?')) {
                args.IsValid = false;
                isProceed = false;
            }
        }
    </script>
     <script type="text/javascript">
         function Registration(url) {
             window.open('QuatationToDOCreate.aspx?ID=' + url, '', "height=2024, width=750, scrollbars=yes, left=50, top=10, resizable=yes, title=Preview");
                  }
</script>
         <script type="text/javascript">
         function EditPageQuotation(url) {
           
                window.open( url,'', "height=2024, width=750, scrollbars=yes, left=50, top=10, resizable=yes, title=Preview");
                  }
</script>

    <style type="text/css">
        .hide
        {
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" LoadScriptsBeforeUI="false">
       <CompositeScript>
           <Scripts>
               <asp:ScriptReference name="MicrosoftAjax.js"/>
	<asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
	<asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.AnimationBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="PopupExtender.PopupBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="AutoComplete.AutoCompleteBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Common.DateTime.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Common.Threading.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Calendar.CalendarBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
           </Scripts>
       </CompositeScript>
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                <asp:Panel ID="pnlMarque" runat="server" Width="100%">    
                <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                        scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </marquee>
                </div>
                </asp:Panel>
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 140px; float: right;">
                    <table style="width: 100%;">
                        <tr>                            
                            <td colspan="6">
                                <table width="100%" style="background-color:#C0C0C0">
                                    <tr>
                                        <td>
                                            Unit
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlUnit" runat="server" DataSourceID="ObjectDataSource2" DataTextField="strUnit"
                                                DataValueField="intUnitID" AutoPostBack="True" 
                                                OnDataBound="ddlUnit_DataBound" 
                                                onselectedindexchanged="ddlUnit_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetUnits"
                                                TypeName="HR_BLL.Global.Unit">
                                                <SelectParameters>
                                                    <asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td style="width: 30px;">
                                        </td>
                                        <td style="text-align:right;">
                                            Ship Point
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlShip" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource4"
                                                DataTextField="strName" DataValueField="intShipPointId" 
                                                ondatabound="ddlShip_DataBound" 
                                                onselectedindexchanged="ddlShip_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="GetShipPoint"
                                                TypeName="SAD_BLL.Global.ShipPoint" 
                                                OldValuesParameterFormatString="original_{0}">
                                                <SelectParameters>
                                                    <asp:SessionParameter Name="userId" SessionField="sesUserID" Type="String" />
                                                    <asp:ControlParameter ControlID="ddlUnit" Name="unitId" PropertyName="SelectedValue"
                                                        Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td style="width: 30px;">
                                        </td>
                                        <td style="text-align:right;">
                                            Sales Office
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSo" runat="server" AutoPostBack="True" DataSourceID="ods2"
                                                DataTextField="strName" DataValueField="intSalesOfficeId" OnDataBound="ddlSo_DataBound"
                                                OnSelectedIndexChanged="ddlSo_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ods2" runat="server" SelectMethod="GetSalesOfficeByShipPoint"
                                                TypeName="SAD_BLL.Global.SalesOffice" OldValuesParameterFormatString="original_{0}">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="ddlShip" Name="shipPoint" PropertyName="SelectedValue"
                                                        Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td style="width: 30px;">
                                        </td>
                                        <td style="text-align:right;">
                                            Type
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCusType" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource7"
                                                DataTextField="strTypeName" DataValueField="intTypeID" 
                                                ondatabound="ddlCusType_DataBound" 
                                                onselectedindexchanged="ddlCusType_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjectDataSource7" runat="server" SelectMethod="GetCustomerTypeBySOForDO"
                                                TypeName="SAD_BLL.Customer.CustomerType" OldValuesParameterFormatString="original_{0}">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="ddlSo" Name="soId" PropertyName="SelectedValue"
                                                        Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Customer</td>
                            <td>
                                <asp:HiddenField ID="hdnCustomer" runat="server" />
                                <asp:TextBox ID="txtCus" runat="server" AutoCompleteType="Search" Width="355px" OnTextChanged="txtCus_TextChanged"
                                    AutoPostBack="true"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtCus"
                                    ServiceMethod="GetCustomerList" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender> 
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td align="right">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp
                            </td>
                            <td align="right">
                                From
                            </td>
                            <td>
                                <asp:TextBox ID="txtFrom" runat="server" Enabled="false"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFrom" Format="dd/MM/yyyy" PopupButtonID="imgCal_1"
                                    ID="CalendarExtender1" runat="server" EnableViewState="true">
                                </cc1:CalendarExtender>
                                <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />
                            </td>
                            <td align="right">
                                To
                            </td>
                            <td>
                                <asp:TextBox ID="txtTo" runat="server" Enabled="false"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtTo" Format="dd/MM/yyyy" PopupButtonID="imgCal_2"
                                    ID="CalendarExtender2" runat="server" EnableViewState="true">
                                </cc1:CalendarExtender>
                                <img id="imgCal_2" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />
                            </td>
                            <td>
                                Quot. No
                                <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                                <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" Style="height: 26px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td align="right">
                                &nbsp;</td>
                            <td colspan="3">
                                <asp:RadioButtonList ID="rdoComplete" runat="server" AutoPostBack="True" 
                                    RepeatDirection="Horizontal">
                                     <asp:ListItem Value="true" >Confirmed</asp:ListItem>
                                    <asp:ListItem  Value="false" Selected="True">Not  Confirmed</asp:ListItem>
                                   
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <div style="height: 170px;">
            </div>
            <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </cc1:AlwaysVisibleControlExtender>
            <asp:HiddenField ID="hdnFrom" runat="server" />
            <asp:HiddenField ID="hdnTo" runat="server" />

                      <asp:GridView ID="dgvCustomerVSPendingQnt" runat="server" PageSize="11125" OnPageIndexChanging="dgvCustomerVSPendingQnt_PageIndexChanging"  AutoGenerateColumns="False" CellPadding="5" ShowFooter="True" DataSourceID="odsSalesQTN" OnDataBound="dgvCustomerVSPendingQnt_DataBound" OnRowDataBound="dgvCustomerVSPendingQnt_RowDataBound">
                          
                    <Columns>
                       <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %>
                      
                         </ItemTemplate></asp:TemplateField>
                       <%--intcustmid,strname,stritemname,strDONumber,numrestqnt,monrestamount--%>
                          <asp:BoundField DataField="strCode" HeaderText=" Quatation Code" SortExpression="strCode" ItemStyle-HorizontalAlign="Center" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                         <asp:BoundField DataField="intCustomerId" HeaderText="CustomerId" SortExpression="intCustomerId" ItemStyle-HorizontalAlign="Center" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="strName" HeaderText="CustName" SortExpression="strCustName" ItemStyle-HorizontalAlign="Center" >
                          <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                         <asp:BoundField DataField="strAddress" HeaderText="Address" SortExpression="strAddress" ItemStyle-HorizontalAlign="Center" >
                          <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                          <asp:BoundField DataField="numTotalPice" HeaderText="Quatation Qnt" SortExpression="numPieces" ItemStyle-HorizontalAlign="Center" >
                         <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                         <asp:BoundField DataField="monTotalAmount" HeaderText="Quatition  Amount" SortExpression="challanqnt" ItemStyle-HorizontalAlign="Center" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="intid" HeaderText="id" SortExpression="intid" ItemStyle-HorizontalAlign="Center" >
                         
                          <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                           <asp:BoundField DataField="ysnCompleted" HeaderText="Status" SortExpression="intid" ItemStyle-HorizontalAlign="Center" >
                         
                          <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                          <asp:TemplateField HeaderText="D.O Creation">
            
                              <ItemTemplate>                                                                                                          
             <asp:Button ID="Complete" runat="server" Text="Create D.O" class="button" Font-Bold="true" CommandName="complete" OnClick="Complete_Click"   CommandArgument='<%# Eval("intCustomerId")+","+Eval("intid")%>' /></ItemTemplate>
             </asp:TemplateField> 

                         <asp:TemplateField HeaderText="Edit">
            
                              <ItemTemplate>                                                                                                          
             <asp:Button ID="btneditqotn" runat="server" Text="Edit Qotn" class="button"  CommandName="complete" OnClick="btneditqotn_Click"   CommandArgument='<%# Eval("intCustomerId")+","+Eval("intid")%>' /></ItemTemplate>
             </asp:TemplateField> 


                                
                    </Columns>
                     <FooterStyle BackColor="#CCCCCC" />
                  <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                  <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                  <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                  <SortedAscendingCellStyle BackColor="#F1F1F1" />
                  <SortedAscendingHeaderStyle BackColor="#808080" />
                  <SortedDescendingCellStyle BackColor="#CAC9C9" />
                  <SortedDescendingHeaderStyle BackColor="#383838" />

                    </asp:GridView>

         


    

         


            <asp:ObjectDataSource ID="odsSalesQTN" runat="server" SelectMethod="GetSalesQuation" TypeName="SAD_BLL.Sales.SalesOrderView">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hdnFrom" Name="fromDate" PropertyName="Value" Type="DateTime" />
                    <asp:ControlParameter ControlID="hdnTo" Name="toDate" PropertyName="Value" Type="DateTime" />
                    <asp:ControlParameter ControlID="txtCode" Name="code" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="ddlUnit" Name="unitID" PropertyName="SelectedValue" Type="String" />
                    <asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String" />
                    <asp:ControlParameter ControlID="hdnCustomer" Name="customerId" PropertyName="Value" Type="String" />
                    <asp:ControlParameter ControlID="ddlCusType" Name="customerType" PropertyName="SelectedValue" Type="String" />
                    <asp:ControlParameter ControlID="rdoComplete" Name="isCompleted" PropertyName="SelectedValue" Type="Boolean" />
                    <asp:ControlParameter ControlID="ddlShip" Name="shippingPoint" PropertyName="SelectedValue" Type="String" />
                    <asp:ControlParameter ControlID="ddlSo" Name="salesOffice" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>

         


    

         


            <asp:CustomValidator ID="cvtCom" runat="server" ClientValidationFunction="ValidateComplete"
            ValidationGroup="valCom"></asp:CustomValidator>
        </ContentTemplate>
    </asp:UpdatePanel>
       
    </form>
</body>
</html>

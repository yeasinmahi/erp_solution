<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="UI.SAD.Delivery.Invoice" %>
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
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/JSSettlement.js"></script>
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
         function Delivery(intid, intCusID, strReportType, ShipPointID, PopupType) {
            window.open('Test.aspx?intid=' + intid + '&intCusID=' + intCusID + '&strReportType=' + strReportType + '&ShipPointID=' + ShipPointID + '&PopupType=' + PopupType, 'sub', "height=570, width=720, scrollbars=yes, left=50, top=45, resizable=no, title=Preview");
         }

         function Picking_Edit(intid, intCusID, strReportType, ShipPointID, PopupType) {
            window.open('DeliveryEntry.aspx?intid=' + intid + '&intCusID=' + intCusID + '&strReportType=' + strReportType + '&ShipPointID=' + ShipPointID + '&PopupType=' + PopupType, 'sub', "height=570, width=720, scrollbars=yes, left=50, top=45, resizable=no, title=Preview");
        }
</script>

    <script language="javascript" type="text/javascript">
   
    function Search_dgvservice(strKey, strGV) {

        var strData = strKey.value.toLowerCase().split(" ");
        var tblData = document.getElementById(strGV);
        var rowData;
        for (var i = 1; i < tblData.rows.length; i++) {
            rowData = tblData.rows[i].innerHTML;
            var styleDisplay = 'none';
            for (var j = 0; j < strData.length; j++) {
                if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                    styleDisplay = '';
                else {
                    styleDisplay = 'none';
                    break;
                }
            }
            tblData.rows[i].style.display = styleDisplay;
        }

    }

</script>
<script type="text/javascript">
        $("[id*=chkHeader]").live("click", function () {
            var chkHeader = $(this);
            var grid = $(this).closest("table");
            $("input[type=checkbox]", grid).each(function () {
                if (chkHeader.is(":checked")) {
                    $(this).attr("checked", "checked");
                    $("td", $(this).closest("tr")).addClass("selected");
                } else {
                    $(this).removeAttr("checked");
                    $("td", $(this).closest("tr")).removeClass("selected");
                }
            });
        });
        $("[id*=chkRow]").live("click", function () {
            var grid = $(this).closest("table");
            var chkHeader = $("[id*=chkHeader]", grid);
            if (!$(this).is(":checked")) {
                $("td", $(this).closest("tr")).removeClass("selected");
                chkHeader.removeAttr("checked");
            } else {
                $("td", $(this).closest("tr")).addClass("selected");
                if ($("[id*=chkRow]", grid).length == $("[id*=chkRow]:checked", grid).length) {
                    chkHeader.attr("checked", "checked");
                }
            }
        });
    </script>
<style>
    .header-ta{
        z-index:-1;
    }
</style>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" LoadScriptsBeforeUI="false">
    <CompositeScript><Scripts>
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
    </Scripts></CompositeScript>
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <asp:Panel ID="pnlMarque" runat="server" Width="100%">    
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
    scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
    </marquee></div></asp:Panel>
                
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" />
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 140px; float: right;">       
        <table width="100%" style="background-color:#C0C0C0">
            <tr>
                <td align="right">Unit</td>
                <td>
                    <asp:DropDownList ID="ddlUnit" runat="server" DataSourceID="ObjectDataSource2" DataTextField="strUnit"
                    DataValueField="intUnitID" AutoPostBack="True" OnDataBound="ddlUnit_DataBound" onselectedindexchanged="ddlUnit_SelectedIndexChanged">
                    </asp:DropDownList><asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
                    <SelectParameters><asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String" /></SelectParameters>
                    </asp:ObjectDataSource>
                </td>
                <td style="text-align:right;">Ship Point</td>
                <td>
                    <asp:DropDownList ID="ddlShip" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource4" DataTextField="strName" DataValueField="intShipPointId"  OnDataBound="ddlShip_DataBound" OnSelectedIndexChanged="ddlShip_SelectedIndexChanged"></asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="GetShipPoint" TypeName="SAD_BLL.Global.ShipPoint" OldValuesParameterFormatString="original_{0}">
                    <SelectParameters><asp:SessionParameter Name="userId" SessionField="sesUserID" Type="String" /><asp:ControlParameter ControlID="ddlUnit" Name="unitId" PropertyName="SelectedValue" Type="String" />
                    </SelectParameters></asp:ObjectDataSource>
                </td>
                    
                <td style="text-align:right;">Sales Office</td>
                <td>
                    <asp:DropDownList ID="ddlSo" runat="server" AutoPostBack="True" DataSourceID="ods2" DataTextField="strName" DataValueField="intSalesOfficeId" OnDataBound="ddlSo_DataBound"
                    OnSelectedIndexChanged="ddlSo_SelectedIndexChanged"></asp:DropDownList> <asp:ObjectDataSource ID="ods2" runat="server" SelectMethod="GetSalesOfficeByShipPoint" TypeName="SAD_BLL.Global.SalesOffice" OldValuesParameterFormatString="original_{0}">
                    <SelectParameters><asp:ControlParameter ControlID="ddlShip" Name="shipPoint" PropertyName="SelectedValue" Type="String" /></SelectParameters></asp:ObjectDataSource>
                </td>
                <td style="text-align:right;">Type</td>
                <td>
                    <asp:DropDownList ID="ddlCusType" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource7" DataTextField="strTypeName" DataValueField="intTypeID" ondatabound="ddlCusType_DataBound" 
                    onselectedindexchanged="ddlCusType_SelectedIndexChanged"></asp:DropDownList><asp:ObjectDataSource ID="ObjectDataSource7" runat="server" SelectMethod="GetCustomerTypeBySOForDO"
                    TypeName="SAD_BLL.Customer.CustomerType" OldValuesParameterFormatString="original_{0}"><SelectParameters><asp:ControlParameter ControlID="ddlSo" Name="soId" PropertyName="SelectedValue" Type="String" />
                    </SelectParameters></asp:ObjectDataSource>
                </td>
            </tr>

            <tr>
            <td align="right">From</td>
            <td><asp:TextBox ID="txtFrom" runat="server" Enabled="false" Width="120px"></asp:TextBox>
                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFrom" Format="dd/MM/yyyy" PopupButtonID="imgCal_1"
                ID="CalendarExtender1" runat="server" EnableViewState="true"></cc1:CalendarExtender>
                <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px; width: 34px; height: 23px; vertical-align: bottom;" />
            </td>
            <td align="right">To</td>
            <td>
                <asp:TextBox ID="txtTo" runat="server" Enabled="false" Width="120px"></asp:TextBox>
                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtTo" Format="dd/MM/yyyy" PopupButtonID="imgCal_2"
                ID="CalendarExtender2" runat="server" EnableViewState="true"></cc1:CalendarExtender>
                <img id="imgCal_2" src="../../Content/images/img/calbtn.gif" style="border: 0px; width: 34px; height: 23px; vertical-align: bottom;" />
                <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" Style="height: 26px" />
            </td>
            <td align="right"></td>
            <td>
                <asp:TextBox ID="txtCode" runat="server" Width="160px" Visible="false"></asp:TextBox>                        
            </td>   
            <td align="right"></td>
            <td>
                <asp:HiddenField ID="hdnCustomer" runat="server" />
                <asp:TextBox ID="txtCus" runat="server" AutoCompleteType="Search" Width="255px" OnTextChanged="txtCus_TextChanged" AutoPostBack="true" Visible="false"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtCus"
                ServiceMethod="GetCustomerList" MinimumPrefixLength="1" CompletionSetCount="1"
                CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"></cc1:AutoCompleteExtender> 
                
            </td>
                                     
            </tr>
            <tr>
                <td align="right">Report Type </td>
                <td colspan="2">
                    <asp:RadioButtonList ID="rdoComplete" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="true"> Delivered </asp:ListItem>
                    <asp:ListItem Value="false"> Undelivered</asp:ListItem>
                    </asp:RadioButtonList>
                </td>   
                
                <td style="text-align: left; padding: 15px 0px 5px 0px">   
                <asp:Button ID="btnSingle" runat="server" class="myButton" Text="Single Invoice" Height="30px" OnClientClick="ConfirmAll()" OnClick="btnSingle_Click" />
                <asp:Label ID="label" runat="server" Width="15px" />
                <asp:Button ID="btnGroup" runat="server" class="myButton" Text="Group Invoice" Height="30px" OnClientClick="ConfirmAll()" />                
            </td>
            </tr>                
        </table>
    </div>

    </asp:Panel>

    <div style="height: 170px;"></div>
    
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server"></cc1:AlwaysVisibleControlExtender>
    <asp:HiddenField ID="hdnFrom" runat="server" /><asp:HiddenField ID="hdnTo" runat="server" />
    <asp:GridView ID="dgvInvoice" runat="server" PageSize="11125" OnPageIndexChanging="dgvInvoice_PageIndexChanging"  AutoGenerateColumns="False" CellPadding="5" DataSourceID="odsInvoice">
                          
    <Columns>
    <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
    
    <asp:TemplateField HeaderText="intId" SortExpression="intId" Visible="false">
    <ItemTemplate><asp:Label ID="lblID" runat="server" Text='<%# Bind("intId") %>' Width="80px"></asp:Label></ItemTemplate>                            
    <ItemStyle HorizontalAlign="center" Width="80px" /></asp:TemplateField>

    <%--<asp:BoundField DataField="strLoadingSlipno" HeaderText=" Number" SortExpression="strLoadingSlipno" ItemStyle-HorizontalAlign="Center" >
    <ItemStyle HorizontalAlign="Center" /></asp:BoundField>--%>

    <asp:TemplateField HeaderText="Number" Visible="true" ItemStyle-HorizontalAlign="left" SortExpression="strTaskTitle" HeaderStyle-Height="30px" HeaderStyle-VerticalAlign="Top" HeaderStyle-Wrap="true">
    <HeaderTemplate>
    <asp:Label ID="lblNumberHeader" runat="server" CssClass="lbl" Text="Number"></asp:Label>
    <asp:TextBox ID="TxtServiceConfg" ToolTip="Search Any Field" runat="server"  width="200" TextMode="MultiLine"  placeholder="Search any column" onkeyup="Search_dgvservice(this, 'dgvInvoice')"></asp:TextBox></HeaderTemplate>
    <ItemTemplate><asp:Label ID="lblNumber" runat="server" Width="100px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strCode")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
            
    
    <asp:BoundField DataField="dtedate" HeaderText="Challan Date" SortExpression="dtedate" ItemStyle-HorizontalAlign="left" DataFormatString="{0:dd/MM/yyyy}" >
    <ItemStyle HorizontalAlign="left" /></asp:BoundField> 

    <asp:TemplateField HeaderText="Party ID" SortExpression="intCusID" Visible="false">
    <ItemTemplate><asp:Label ID="lblCusID" runat="server" Text='<%# Bind("intCusID") %>' Width="80px"></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="center" Width="80px" /></asp:TemplateField>

    <asp:BoundField DataField="strName" HeaderText="Sold To Party" SortExpression="strName" ItemStyle-HorizontalAlign="left" >
    <ItemStyle HorizontalAlign="left" /></asp:BoundField>    

    <asp:BoundField DataField="monTotalAmount" HeaderText="Challan Total" SortExpression="monTotalAmount" ItemStyle-HorizontalAlign="right" DataFormatString="{0:0.00}">
    <ItemStyle HorizontalAlign="right" /></asp:BoundField>
        
    <asp:TemplateField><HeaderTemplate><asp:CheckBox ID="chkHeader" runat="server" /></HeaderTemplate>
    <ItemTemplate><asp:CheckBox ID="chkRow" runat="server" /></ItemTemplate></asp:TemplateField>
   
    </Columns>
    <FooterStyle BackColor="#CCCCCC" />
    <HeaderStyle Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#F1F1F1" />
    <SortedAscendingHeaderStyle BackColor="#808080" />
    <SortedDescendingCellStyle BackColor="#CAC9C9" />
    <SortedDescendingHeaderStyle BackColor="#383838" />

    </asp:GridView>
        
    <asp:ObjectDataSource ID="odsInvoice" runat="server" SelectMethod="GetDataForInvoice" TypeName="SAD_BLL.Sales.SalesOrderView">
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
    </SelectParameters></asp:ObjectDataSource>
    <asp:CustomValidator ID="cvtCom" runat="server" ClientValidationFunction="ValidateComplete"
    ValidationGroup="valCom"></asp:CustomValidator>
    </ContentTemplate></asp:UpdatePanel>
       
    </form>
    </body>
    </html>

       


    <%--<table>
        <tr>
            <td style="text-align: right; padding: 15px 0px 5px 0px">   
                <asp:Button ID="btnSingle" runat="server" class="myButton" Text="Single Invoice" Height="30px" OnClientClick="ConfirmAll()" />
                <asp:Label ID="label" runat="server" Width="15px" />
                <asp:Button ID="btnGroup" runat="server" class="myButton" Text="Group Invoice" Height="30px" OnClientClick="ConfirmAll()" />
                <hr />
            </td>
        </tr>
        <tr>
            <td>                
                <asp:GridView ID="dgvInvoice" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"  DataSourceID="odsForInvoice"
                    CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                    HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
                    ForeColor="Black" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:TemplateField HeaderText="SL No."> <ItemStyle HorizontalAlign="center" Width="60px" /> 
                        <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>

                        <asp:TemplateField HeaderText="intId" SortExpression="intId" Visible="false">
                        <ItemTemplate><asp:Label ID="lblID" runat="server" Text='<%# Bind("intId") %>' Width="80px"></asp:Label></ItemTemplate>                            
                        <ItemStyle HorizontalAlign="center" Width="80px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="Code" SortExpression="strCode">
                        <ItemTemplate><asp:Label ID="lblCode" runat="server" Text='<%# Bind("strCode") %>' Width="120px"></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="center" Width="120px" /></asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Date" SortExpression="dteDate">
                        <ItemTemplate><asp:Label ID="lblDate" runat="server" Text='<%#Eval("dteDate", "{0:yyyy-MM-dd}") %>' Width="80px"></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="center" Width="80px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="Party ID" SortExpression="intCusID" Visible="false">
                        <ItemTemplate><asp:Label ID="lblintCusID" runat="server" Text='<%# Bind("intCusID") %>' Width="80px"></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="center" Width="80px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="Sold To Party" SortExpression="strName">
                        <ItemTemplate><asp:Label ID="lblstrName" runat="server" Text='<%# Bind("strName") %>' Width="265px"></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="left" Width="265px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="Total Amount" SortExpression="monTotalAmount">
                        <ItemTemplate><asp:Label ID="lblTotalAmount" runat="server" Text='<%# Bind("monTotalAmount", "{0:n2}") %>' Width="100px"></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="right" Width="100px" /></asp:TemplateField>
                        
                        <asp:TemplateField><HeaderTemplate><asp:CheckBox ID="chkHeader" runat="server" /></HeaderTemplate>
                        <ItemTemplate><asp:CheckBox ID="chkRow" runat="server" /></ItemTemplate></asp:TemplateField>
                    </Columns>
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                </asp:GridView>
                <asp:ObjectDataSource ID="odsForInvoice" runat="server" SelectMethod="GetDataForInvoice" TypeName="SAD_BLL.Sales.SalesOrderView">
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
                </SelectParameters></asp:ObjectDataSource>
            </td>
        </tr>
    </table>
    
    </ContentTemplate></asp:UpdatePanel>--%>
       
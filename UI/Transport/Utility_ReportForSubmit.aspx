<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Utility_ReportForSubmit.aspx.cs" Inherits="UI.Transport.Utility_ReportForSubmit" %>
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

    <script>        
        function ReportForSubmit(reqsid) {
            window.open('Utility_SubReportForSubmit.aspx?intID=' + reqsid, 'sub', "height=450, width=750, scrollbars=yes, left=150, top=50, resizable=no, title=Preview");
        }        
    </script>
          
</head>
<body>
    <form id="frmselfresign" runat="server">
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
    <asp:HiddenField ID="hdnconfirm" runat="server" />
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" />
        <asp:HiddenField ID="hdnUnit" runat="server" /><asp:HiddenField ID="hdnJobStation" runat="server" />
        
        <div class="tabs_container"> UTILITY REPORT FOR SUBMIT <hr /></div>

        <table  class="tbldecoration" style="width:auto; float:left;">
        <tr>                
            <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Unit :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server"></asp:DropDownList>                                                                                       
            </td>   
            
            <td style="text-align:right;"><asp:Label ID="lblServiceList" runat="server" CssClass="lbl" Text="Service Name :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlServiceList" CssClass="ddList" Font-Bold="False" runat="server"></asp:DropDownList>                                                                                       
            </td>           
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblFromDate" runat="server" CssClass="lbl" Text="From Date :"></asp:Label></td>                
            <td><asp:TextBox ID="txtFromDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="210px"></asp:TextBox>
            <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender></td> 
            
            <td style="text-align:right;"><asp:Label ID="lblToDate" runat="server" CssClass="lbl" Text="To Date :"></asp:Label></td>                
            <td><asp:TextBox ID="txtToDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="210px"></asp:TextBox>
            <cc1:CalendarExtender ID="tdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender></td>  
        </tr>        
        <tr>
            <td colspan="4" style="text-align:left;"><asp:Button ID="btnShowReport" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Show Report" OnClick="btnShowReport_Click"/></td>                          
        </tr>


    </table>
        </div>


<div >  
        <table  class="tbldecoration" style="width:auto; float:left;">  
            <tr><td> 
            <asp:GridView ID="dgvReport" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"  ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="dgvReport_RowDataBound"> 
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>            
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="20px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
                     
            <asp:TemplateField HeaderText="intUtilityID" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="intUtilityID" >
            <ItemTemplate><asp:Label ID="lblUtilityID" runat="server" DataFormatString="{0:0.00}" Text='<%# (""+Eval("intUtilityID")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                                          
            <asp:BoundField DataField="strUnit" HeaderText="Unit Name" ItemStyle-HorizontalAlign="Center" SortExpression="strUnit">
            <ItemStyle HorizontalAlign="left" Width="150px"/></asp:BoundField>

            <asp:BoundField DataField="strJobStationName" HeaderText="Job Station" ItemStyle-HorizontalAlign="Center" SortExpression="strJobStationName">
            <ItemStyle HorizontalAlign="left" Width="150px"/></asp:BoundField>

            <asp:BoundField DataField="strStationAddress" HeaderText="Job Station Address" ItemStyle-HorizontalAlign="Center" SortExpression="strStationAddress">
            <ItemStyle HorizontalAlign="left" Width="150px"/></asp:BoundField>

            <asp:BoundField DataField="strServiceName" HeaderText="Service Name" ItemStyle-HorizontalAlign="Center" SortExpression="strServiceName">
            <ItemStyle HorizontalAlign="left" Width="150px"/></asp:BoundField>

            <asp:BoundField DataField="strLicenseAuthWithAddr" HeaderText="License Authority With Adress" ItemStyle-HorizontalAlign="Center" SortExpression="strLicenseAuthWithAddr">
            <ItemStyle HorizontalAlign="left" Width="150px"/></asp:BoundField>

            <asp:BoundField DataField="strCategory" HeaderText="Category" ItemStyle-HorizontalAlign="Center" SortExpression="strCategory">
            <ItemStyle HorizontalAlign="left" Width="150px"/></asp:BoundField>

            <asp:BoundField DataField="strLicenseAppNo" HeaderText="License/App No." ItemStyle-HorizontalAlign="Center" SortExpression="strLicenseAppNo">
            <ItemStyle HorizontalAlign="left" Width="150px"/></asp:BoundField>

            <asp:BoundField DataField="dteValidFrom" HeaderText="   Valid From   " ItemStyle-HorizontalAlign="Center" SortExpression="dteValidFrom">
            <ItemStyle HorizontalAlign="left" Width="200px"/></asp:BoundField>

            <asp:BoundField DataField="dteValidTo" HeaderText="   Valid To   " ItemStyle-HorizontalAlign="Center" SortExpression="dteValidTo">
            <ItemStyle HorizontalAlign="left" Width="200px"/></asp:BoundField>

            <asp:BoundField DataField="dteExpireDate" HeaderText="Expire Date" ItemStyle-HorizontalAlign="Center" SortExpression="dteExpireDate">
            <ItemStyle HorizontalAlign="left" Width="200px"/></asp:BoundField>

            <asp:BoundField DataField="dteNextSubmited" HeaderText="Next Submited Date" ItemStyle-HorizontalAlign="Center" SortExpression="dteNextSubmited">
            <ItemStyle HorizontalAlign="left" Width="200px"/></asp:BoundField>

            <asp:TemplateField HeaderText="Gov-Fee" ItemStyle-HorizontalAlign="right" Visible="false" SortExpression="monGovFee" >
            <ItemTemplate><asp:Label ID="lblGovFee" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monGovFee"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalgovfee %>' /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Incidental Cost" ItemStyle-HorizontalAlign="right" Visible="false" SortExpression="monIncidentalCost" >
            <ItemTemplate><asp:Label ID="lblIncidentalCost" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monIncidentalCost"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalincidentalcost %>' /></FooterTemplate></asp:TemplateField>
                 
            <asp:TemplateField HeaderText="Total Cost" ItemStyle-HorizontalAlign="right" Visible="false" SortExpression="monTotalCost" >
            <ItemTemplate><asp:Label ID="lblTotalCost" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monTotalCost"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalcost %>' /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="For Submit" >
            <ItemTemplate><asp:Button ID="btnAction" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" 
            CommandArgument='<%# Eval("intUtilityID") %>' Text="For Submit" OnClick="btnAction_Click"/>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField> 
            
            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
            </tr>

         </table>     
    </div>




<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
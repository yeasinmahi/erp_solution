<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CafeteriaReport.aspx.cs" Inherits="UI.HR.Cafeteria.CafeteriaReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><title></title>
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
    <script src="../../Content/JS/CustomizeScript.js"></script>
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/Application.css" rel="stylesheet" />
    <script src="../../../../Content/JS/JQUERY/GridviewScroll.min.js"></script>

    <script language="javascript" type="text/javascript">
    function ExportDivDataToExcel() {
        var html = $("#divExport").html();
        html = $.trim(html);
        html = html.replace(/>/g, '&gt;');
        html = html.replace(/</g, '&lt;');
        $("input[id$='HdnValue']").val(html);
    }
 </script>
<%--<script type="text/javascript">       
        $(document).ready(function () {
            GridviewScroll();
        });
        function GridviewScroll() {
            
            $('#<%=dgvReport.ClientID%>').gridviewScroll({
                 width: 925,
                 height: 300,
                 startHorizontal: 0,
                 wheelstep: 10,
                 barhovercolor: "#3399FF",
                 barcolor: "#3399FF"
             });
         }
    </script> --%>   
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
</head>
<body>
    <form id="frmcafr" runat="server">
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <%--<asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>--%>
    <%--=========================================Start My Code From Here===============================================--%>
    <%--<br /><br /><br /><br /><br /><br /><br />--%>
    <asp:HiddenField ID="hdnEnroll" runat="server" />
    <table style="width:auto; float:left;">
    <tr><td>        
        <div class="leaveApplication_container">
        <table class="tbldecoration" style="width:auto; float:left;">
        <tr class="tblheader"><td colspan="4" style="color:black; text-align:center; font-size:18px"> CAFETERIA DETAILS REPORT </td></tr>

        <%--<tr class="tblrowodd">
        <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Unit:"></asp:Label></td>
        <td style="text-align:left;">
            <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="false"></asp:DropDownList>                                                                                       
        </td>
        <td colspan="2" style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text=""></asp:Label></td>
        </tr>--%>

        <tr class="tblrowodd">
        <td style="text-align:right;"><asp:Label ID="lblDate" runat="server" CssClass="lbl" Text="From Date :"></asp:Label></td>                
        <td><asp:TextBox ID="txtFDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
        <cc1:CalendarExtender ID="tdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFDate"></cc1:CalendarExtender></td>  
            
        <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="To Date :"></asp:Label></td>                
        <td><asp:TextBox ID="txtTDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtTDate"></cc1:CalendarExtender></td>  
        </tr> 
        <tr class="tblrowodd">
            <td style="text-align:right;"><asp:Label ID="Label16" runat="server" CssClass="lbl" Text="Report Type:"></asp:Label></td>                
            <td><asp:RadioButton ID="rdoAll" runat="server" Checked="true" Text="All" AutoPostBack="true" OnCheckedChanged="rdoAll_CheckedChanged"/>
            <asp:RadioButton ID="rdoPunch" runat="server" Text="Punch" AutoPostBack="true" OnCheckedChanged="rdoPunch_CheckedChanged"/>
            <asp:RadioButton ID="rdoNonPunch" runat="server" Text="Non Punch" AutoPostBack="true" OnCheckedChanged="rdoNonPunch_CheckedChanged"/>
            </td>
        </tr>
        <tr class="tblrowodd">
            <td colspan="2" style="text-align:right;"><asp:Button ID="btnExport" runat="server" CssClass="nextclick" ForeColor="Black" Text="Export To Excel" OnClick="btnExport_Click" OnClientClick="ExportDivDataToExcel()"/></td>   
            <td colspan="2" style="text-align:right;"><asp:Button ID="btnShow" runat="server" CssClass="nextclick" ForeColor="Black" Text="Show" OnClientClick="LoaderBusy()" OnClick="btnShow_Click"/></td>   
        </tr>
        </table>
        </div>
    </td></tr>
    <tr><td>    
        <div id="divExport">  
        <table>  
        <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="lblUnitName" runat="server"></asp:Label></td></tr>
        <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="lblReportName" runat="server"></asp:Label></td></tr>
        <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="lblFromToDate" runat="server"></asp:Label></td></tr>
                     
        <tr><td  style="text-align:justify;"><hr />
        <asp:GridView ID="dgvReport" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" Font-Size="10px" ForeColor="Black" GridLines="Vertical"
        ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="dgvReport_RowDataBound">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px" /><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
       
        <asp:TemplateField HeaderText="Enroll" SortExpression="Enrollment">
        <ItemTemplate><asp:Label ID="lblEnroll" runat="server" Text='<%# Bind("Enrollment") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="center" Width="75px"/></asp:TemplateField>
        
        <asp:TemplateField HeaderText="Name Of Employees" SortExpression="NameOfEmployees">
        <ItemTemplate><asp:Label ID="lblName" runat="server" Text='<%# Bind("NameOfEmployees") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="145px"/></asp:TemplateField>

        <asp:TemplateField HeaderText="Designation" SortExpression="Designation">
        <ItemTemplate><asp:Label ID="lblDesig" runat="server" Text='<%# Bind("Designation") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="140px"/></asp:TemplateField>

        <asp:TemplateField HeaderText="Department" SortExpression="Dept">
        <ItemTemplate><asp:Label ID="lblDept" runat="server" Text='<%# Bind("Dept") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="145px"/></asp:TemplateField>

        <asp:TemplateField HeaderText="Unit Name" SortExpression="Unit">
        <ItemTemplate><asp:Label ID="lblUnit" runat="server" Text='<%# Bind("Unit") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="60px"/></asp:TemplateField>

        <asp:TemplateField HeaderText="Job Station" SortExpression="JobStation">
        <ItemTemplate><asp:Label ID="lblJobStation" runat="server" Text='<%# Bind("JobStation") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="145px"/></asp:TemplateField>

        <asp:TemplateField HeaderText="Rate" SortExpression="Rate">
        <ItemTemplate><asp:Label ID="lblRate" runat="server" Text='<%# (decimal.Parse(""+Eval("Rate"))) %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="right" Width="35px"/></asp:TemplateField>

        <asp:TemplateField HeaderText="Own Meal" SortExpression="Own">
        <ItemTemplate><asp:Label ID="lblOwn" runat="server" Text='<%# Bind("Own") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="right" Width="35px"/>
        <FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# tqtyown %>' /></FooterTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Guest Meal" SortExpression="Guest">
        <ItemTemplate><asp:Label ID="lblGuest" runat="server" Text='<%# Bind("Guest") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="right" Width="35px"/>
        <FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# tqtyguest %>' /></FooterTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Total Meal" SortExpression="Total">
        <ItemTemplate><asp:Label ID="lblTotal" runat="server" Text='<%# Bind("Total") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="right" Width="35px"/>
        <FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# tqtytotal %>' /></FooterTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Own Tk" SortExpression="OwnTk">
        <ItemTemplate><asp:Label ID="lblOwnTk" runat="server" Text='<%# Bind("OwnTk") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="right" Width="35px"/>
        <FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# ttkown %>' /></FooterTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Company Subsidy" SortExpression="CompanyPay">
        <ItemTemplate><asp:Label ID="lblCompanyPay" runat="server" Text='<%# Bind("CompanyPay") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="right" Width="35px"/>
        <FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# ttkcom %>' /></FooterTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Guest Tk" SortExpression="GuestTk">
        <ItemTemplate><asp:Label ID="lblGuestTk" runat="server" Text='<%# Bind("GuestTk") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="right" Width="35px"/>
        <FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# ttkguest %>' /></FooterTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Total Tk" SortExpression="TotalTk">
        <ItemTemplate><asp:Label ID="lblTotalTk" runat="server" Text='<%# Bind("TotalTk") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="right" Width="35px"/>
        <FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# ttktotal %>' /></FooterTemplate>
        </asp:TemplateField>

        </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView></td>
        </tr>         
        </table>
        <asp:HiddenField ID="HdnValue" runat="server" />
        </div>
    </td></tr>
    </table>

    <div class="loading" align="center">
        <%--Loading. Please wait.</hr><br />--%> 
        <%--<img src="../Content/Images/imagesCAAL9MHY.jpg" /> --%>
        <%--<img src="../Content/Images/imagesCAU8JX1Y.png" />--%>
        <%--<img src="../Content/Images/imagesCA35MWNI.png" /> --%>         
        <%--<img src="../../Content/images/gicon/loader.gif" />--%>
        <img src="../../Content/images/gicon/Final-Product-2.GIF" />
    </div>
    

    <%--=========================================End My Code From Here=================================================--%>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>

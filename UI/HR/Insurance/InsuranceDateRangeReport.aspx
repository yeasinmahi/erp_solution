<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsuranceDateRangeReport.aspx.cs" Inherits="UI.HR.Insurance.InsuranceDateRangeReport" %>
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
        <tr class="tblheader"><td colspan="4" style="color:black; text-align:center; font-size:18px"> PERIODICAL INSURANCE REPORT </td></tr>

        <tr class="tblrowodd">
            <td style="text-align:right;"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit-Name : "></asp:Label></td>
            <td><asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" CssClass="dropdownList" 
            DataSourceID="ODSUnit" DataTextField="strUnit" DataValueField="intUnitID" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList>
            <asp:ObjectDataSource ID="ODSUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit"
            OldValuesParameterFormatString="original_{0}"><SelectParameters>
            <asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String"/>
            </SelectParameters></asp:ObjectDataSource>
            </td>
            
            <td style="text-align:right;"><asp:Label ID="lblstation" CssClass="lbl" runat="server" Text="Job-Station : "></asp:Label></td>
            <td><asp:DropDownList ID="ddlJobStation" runat="server" AutoPostBack="True" CssClass="dropdownList"
            DataSourceID="ODSJobStation" DataTextField="Text" DataValueField="value" OnSelectedIndexChanged="ddlJobStation_SelectedIndexChanged"></asp:DropDownList>
            <asp:ObjectDataSource ID="ODSJobStation" runat="server" SelectMethod="GetJobStationIdAndNameByUnitID"
            TypeName="HR_BLL.Global.JobStation" OldValuesParameterFormatString="original_{0}">
            <SelectParameters><asp:ControlParameter ControlID="ddlUnit" Name="intUnitID" PropertyName="SelectedValue"
            Type="Int32" /><asp:SessionParameter Name="intLoginId" SessionField="sesUserId" Type="Int32" />
            </SelectParameters></asp:ObjectDataSource>
            </td>            
        </tr>

        <tr class="tblrowodd">
        <td style="text-align:right;"><asp:Label ID="lblDate" runat="server" CssClass="lbl" Text="From Date :"></asp:Label></td>                
        <td><asp:TextBox ID="txtFDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <cc1:CalendarExtender ID="tdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFDate"></cc1:CalendarExtender></td>  
            
        <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="To Date :"></asp:Label></td>                
        <td><asp:TextBox ID="txtTDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtTDate"></cc1:CalendarExtender></td>  
        </tr> 
        <tr class="tblrowodd">
            <td style="text-align:right;"><asp:Label ID="Label16" runat="server" CssClass="lbl" Text="Report Type:"></asp:Label></td>                
            <td><asp:RadioButton ID="rdoActive" runat="server" Checked="true" Text="Active" AutoPostBack="true" OnCheckedChanged="rdoActive_CheckedChanged"/>            
            <asp:RadioButton ID="rdoInactive" runat="server" Text="Inactive" AutoPostBack="true" OnCheckedChanged="rdoInactive_CheckedChanged"/>
            </td>

            <td style="text-align:right;"> <asp:Label ID="Label2" font-size="small" runat="server" CssClass="lbl" Text=""></asp:Label></td>
            <td style="text-align:left;"><asp:CheckBox ID="cbAll" runat="server" Text=" All Report" /></td>
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
                     
        <tr><td> 
            <asp:GridView ID="dgvDependant" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="50000" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"  ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
                        
            <asp:TemplateField HeaderText="Enrolll" SortExpression="Enroll"><ItemTemplate>            
            <asp:Label ID="lblEnroll" runat="server" Text='<%# Bind("Enroll") %>' Width="50px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="250px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Employee Name/Depandency" SortExpression="Empname"><ItemTemplate>            
            <asp:Label ID="lblEmpname" runat="server" Text='<%# Bind("Empname") %>' Width="150px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="250px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Designation/Relation" SortExpression="strRegNo"><ItemTemplate>            
            <asp:Label ID="lblDesig" runat="server" Text='<%# Bind("Desig") %>' Width="150px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="250px"/></asp:TemplateField>
              
            <asp:TemplateField HeaderText="Department" SortExpression="Dept"><ItemTemplate>            
            <asp:Label ID="lblDept" runat="server" Text='<%# Bind("Dept") %>' Width="150px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="250px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Unit" SortExpression="Unit"><ItemTemplate>            
            <asp:Label ID="lblUnit" runat="server" Text='<%# Bind("Unit") %>' Width="50px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="250px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Job Station" SortExpression="JobS"><ItemTemplate>            
            <asp:Label ID="lblJobS" runat="server" Text='<%# Bind("JobS") %>' Width="150px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="250px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Job Type" SortExpression="JobT"><ItemTemplate>            
            <asp:Label ID="lblJobT" runat="server" Text='<%# Bind("JobT") %>' Width="50px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="250px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Joining Date" SortExpression="JoinDate"><ItemTemplate>            
            <asp:Label ID="lblJDate" runat="server" Text='<%# Bind("JoinDate") %>' Width="80px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="250px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Date Of Birth" SortExpression="BirthD"><ItemTemplate>            
            <asp:Label ID="lblDTB" runat="server" Text='<%# Bind("BirthD") %>' Width="80px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="250px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Gross Salary" SortExpression="GSalary"><ItemTemplate>            
            <asp:Label ID="lblGross" runat="server" Text='<%# Bind("GSalary") %>' Width="50px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="250px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Basic" SortExpression="BSalary"><ItemTemplate>            
            <asp:Label ID="lblBasic" runat="server" Text='<%# Bind("BSalary") %>' Width="50px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="250px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Group" SortExpression="strGroup"><ItemTemplate>            
            <asp:Label ID="lblGroup" runat="server" Text='<%# Bind("strGroup") %>' Width="50px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="250px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Medical" SortExpression="strMedical"><ItemTemplate>            
            <asp:Label ID="lblMedical" runat="server" Text='<%# Bind("strMedical") %>' Width="100px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="250px"/></asp:TemplateField>
            
           <%--<asp:TemplateField HeaderText="Parent" SortExpression="SlParent"><ItemTemplate>            
            <asp:Label ID="lblsiparent" runat="server" Text='<%# Bind("SlParent") %>' Width="150px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="250px"/></asp:TemplateField>--%>

             <asp:TemplateField HeaderText="Medical Type" SortExpression="strMedicaltype"><ItemTemplate>            
            <asp:Label ID="lblMedicaltype" runat="server" Text='<%# Bind("strMedicaltype") %>' Width="50px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="50px"/></asp:TemplateField>

            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
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

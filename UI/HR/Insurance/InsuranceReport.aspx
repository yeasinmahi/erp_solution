<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsuranceReport.aspx.cs" Inherits="UI.HR.Insurance.InsuranceReport" %>
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
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/Lstyle.css" rel="stylesheet" />
      <link href="../../../../Content/CSS/GridHEADER.css" rel="stylesheet" />
    
    <script src="../../../../Content/JS/JQUERY/MigrateJS.js"></script>
    <script src="../../../../Content/JS/JQUERY/GridviewScroll.min.js"></script>
</head>
<body>
    <form id="frmselfresign" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
   
<%--=========================================Start My Code From Here===============================================--%>
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" />

    <div class="tabs_container"> Insurance Report <hr /></div>
        <table>
            <tr>
               <%-- <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Unit:"></asp:Label></td>
                <td style="text-align:left;"><asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="True" DataSourceID="odsunt" DataTextField="strUnit" DataValueField="intUnitID"></asp:DropDownList>
                <asp:ObjectDataSource ID="odsunt" runat="server" SelectMethod="GetUnitListForTransport" TypeName="SAD_BLL.Transport.InternalTransportBLL">
                <SelectParameters><asp:SessionParameter Name="Enroll" SessionField="sesUserID" Type="Int32" /></SelectParameters> </asp:ObjectDataSource>
                </td>

                <td style="text-align:right;"><asp:Label ID="lblJobStation" runat="server" CssClass="lbl" Text="Job Station:"></asp:Label></td>
                <td style="text-align:left;"><asp:DropDownList ID="ddlJobStation" CssClass="ddList" Font-Bold="False" runat="server" DataSourceID="odsstation" DataTextField="strJobStationName" DataValueField="intEmployeeJobStationId"></asp:DropDownList>
                <asp:ObjectDataSource ID="odsstation" runat="server" SelectMethod="GetJobStation" TypeName="HR_BLL.Dispatch.DispatchBLL">
                <SelectParameters><asp:ControlParameter ControlID="ddlUnit" Name="intUnitID" PropertyName="SelectedValue" Type="Int32" /></SelectParameters></asp:ObjectDataSource>
                </td>--%>
             <tr>
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
                  <td style="text-align:right;"> <asp:Label ID="Label1" font-size="small" runat="server" CssClass="lbl" Text=""></asp:Label></td>
                <td style="text-align:left;"><asp:CheckBox ID="chkValidity" runat="server" Text=" All Report" /></td>
             </tr>

               
            </tr>

            <tr>                
                <td colspan="4" style="text-align:left;"><asp:Button ID="btnShowReport" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Show Report" OnClick="btnShowReport_Click"/></td>
             <td style="text-align:right"> <asp:Button ID="btnExportToExcel" runat="server" Text="Export" OnClick="btnExportToExcel_Click"/></td>
            </tr>
        </table>

        <div id="divExport">          
        <table  class="tbldecoration" style="width:auto; float:left;">  
            <%--===========Summary Report============--%>
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
    </div>




        <%--=========================================End My Code From Here=================================================--%>
      
    
    </form>
</body>
</html>
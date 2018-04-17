<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResignRealizeDeptHead.aspx.cs" Inherits="UI.HR.Settlement.ResignRealizeDeptHead" %>
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
<script>$(document).ready(function () {
    document.getElementById("hiddenbox2").style.display = "none";
});</script>

</head>
<body>    
    <form id="frmrealizedepthead" runat="server">
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
    <div id="divcontentholder">

    <table class="tbldecoration" style="width:auto; float:left;">
    <tr class="tblheader"><td colspan="4"> Resign Realize By Department Head :</td></tr>
 
                
            <tr><td colspan="4"> <%--<asp:HiddenField ID="hdnconfirm" runat="server" />--%>
            <asp:GridView ID="dgvReport" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" 
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                
            <asp:BoundField DataField="strEmployeeCode" HeaderText="Employee Code" ItemStyle-HorizontalAlign="Center" SortExpression="strEmployeeCode">
            <ItemStyle HorizontalAlign="Center" Width="75px"/></asp:BoundField>

            <asp:BoundField DataField="intEmployeeID" HeaderText="Employee ID" ItemStyle-HorizontalAlign="Center" SortExpression="intEmployeeID">
            <ItemStyle HorizontalAlign="Center" Width="75px"/></asp:BoundField>

            <asp:BoundField DataField="strEmployeeName" HeaderText="Employee Name" ItemStyle-HorizontalAlign="Center" SortExpression="strEmployeeName">
            <ItemStyle HorizontalAlign="left" Width="300px"/></asp:BoundField>

            <asp:BoundField DataField="strDesignation" HeaderText="Designation" ItemStyle-HorizontalAlign="Center" SortExpression="strDesignation">
            <ItemStyle HorizontalAlign="left" Width="150px"/></asp:BoundField>

            <asp:BoundField DataField="strDepatrment" HeaderText="Depatrment" ItemStyle-HorizontalAlign="Center" SortExpression="strDepatrment">
            <ItemStyle HorizontalAlign="left" Width="150px"/></asp:BoundField>

            <asp:BoundField DataField="strUnit" HeaderText="Unit Name" ItemStyle-HorizontalAlign="Center" SortExpression="strUnit">
            <ItemStyle HorizontalAlign="left" Width="150px"/></asp:BoundField>

            <asp:BoundField DataField="strJobStationName" HeaderText="Job Station Name" ItemStyle-HorizontalAlign="Center" SortExpression="strJobStationName">
            <ItemStyle HorizontalAlign="left" Width="225px"/></asp:BoundField>

            <asp:BoundField DataField="dteJoiningDate" HeaderText="Joining Date" ItemStyle-HorizontalAlign="Center" SortExpression="dteJoiningDate" DataFormatString="{0:yyyy-MM-dd}">
            <ItemStyle HorizontalAlign="Center" Width="75px"/></asp:BoundField>

            <asp:BoundField DataField="dteLastOfficeDate" HeaderText="Last Office Date" ItemStyle-HorizontalAlign="Center" SortExpression="dteLastOfficeDate" DataFormatString="{0:yyyy-MM-dd}">
            <ItemStyle HorizontalAlign="Center" Width="75px"/></asp:BoundField>

            <asp:BoundField DataField="dteLastOfficeDateByUser" HeaderText="Last Office Date By User" ItemStyle-HorizontalAlign="Center" SortExpression="dteLastOfficeDateByUser" DataFormatString="{0:yyyy-MM-dd}">
            <ItemStyle HorizontalAlign="Center" Width="75px"/></asp:BoundField>

            <asp:BoundField DataField="dteLastOfficeDateByAuthority" HeaderText="Last Office Date By Authority" ItemStyle-HorizontalAlign="Center" SortExpression="dteLastOfficeDateByAuthority" DataFormatString="{0:yyyy-MM-dd}">
            <ItemStyle HorizontalAlign="Center" Width="75px"/></asp:BoundField>

            <asp:BoundField DataField="monSalary" Visible="false" HeaderText="Salary" ItemStyle-HorizontalAlign="Center" SortExpression="monSalary" DataFormatString="{0:0.00}">
            <ItemStyle HorizontalAlign="right" Width="100px"/></asp:BoundField>

            <asp:BoundField DataField="dteResignationDate" Visible="false" HeaderText="Resignation Date" ItemStyle-HorizontalAlign="Center" SortExpression="dteResignationDate" DataFormatString="{0:yyyy-MM-dd}">
            <ItemStyle HorizontalAlign="Center" Width="75px"/></asp:BoundField>

            <asp:BoundField DataField="strSeparateName" Visible="false" HeaderText="Separatation Type" ItemStyle-HorizontalAlign="Center" SortExpression="strSeparateName">
            <ItemStyle HorizontalAlign="left" Width="225px"/></asp:BoundField>

            <asp:BoundField DataField="strSeparateReason" Visible="false" HeaderText="Separate Reason" ItemStyle-HorizontalAlign="Center" SortExpression="strSeparateReason">
            <ItemStyle HorizontalAlign="left" Width="225px"/></asp:BoundField>
                
            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" SortExpression="">
            <ItemTemplate><a class="button" style="Font-Size:10px; color:green" href="#" onclick="<%#  FilterControlsRealizeDeptHead(""+Eval("strEmployeeCode"),""+Eval("intEmployeeID"),""+Eval("strEmployeeName"),""+
            Eval("strDesignation"),""+Eval("monSalary"),""+Eval("dteResignationDate"),""+Eval("dteLastOfficeDate"),""+Eval("dteLastOfficeDateByUser"),""+Eval("dteLastOfficeDateByAuthority"),""+Eval("strSeparateName"),""+Eval("strSeparateReason")) %>">View</a></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="35px" /></asp:TemplateField>
                
            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>

    </table>
       
    </div>

    <div id="hiddenbox2" style="margin-top:250px;"><asp:HiddenField ID="hdnID" runat="server" /><asp:HiddenField ID="hdnconfirm" runat="server" />
    <table style="width:Auto";>
           
    <tr class="tblheader"><td colspan="4"> Resign Realize By Department Head :</td></tr>
    
    <tr>
        <td style="text-align:right;"><asp:Label ID="lblRemarks" CssClass="lbl" runat="server" Text="Remarks : "></asp:Label></td>
        <td>
            <asp:DropDownList ID="ddlRemarks" runat="server" AutoPostBack="false" CssClass="ddList">
            <asp:ListItem Selected="True" Value="1">Perfectly handover job responsibility</asp:ListItem><asp:ListItem Value="2">Handover partial job responsibility</asp:ListItem><asp:ListItem Value="3">Lackings of Departmental head job handover cannot check properly</asp:ListItem></asp:DropDownList>
        </td>  
        
        <td style="text-align:right;"><asp:Label ID="lblDeductSalary" CssClass="lbl" runat="server" Text="Deduct Salary : "></asp:Label></td>
        <td><asp:TextBox ID="txtDeductSalary" runat="server" CssClass="txtBox"></asp:TextBox></td>
    </tr> 
        
    <tr>
        <td colspan="4" style="text-align:right;">            
            <a class="button" onclick="DeptHeadRealize()">Realize</a>            
        </td>
    </tr>

    <tr class="tblheader"><td colspan="4"> </td></tr>

    <tr class="tblheader"><td colspan="4"> Employee Information :</td></tr>

    <tr>        
        <td style="text-align:right;"><asp:Label ID="lblEmpCode" CssClass="lbl" runat="server" Text="Employee Code : "></asp:Label></td>
        <td><asp:TextBox ID="txtEmpCode" ReadOnly ="true" runat="server" CssClass="txtBox"></asp:TextBox></td>

        <td style="text-align:right;"><asp:Label ID="lblEnroll" CssClass="lbl" runat="server" Text="Enroll : "></asp:Label></td>
        <td><asp:TextBox ID="txtEnroll" ReadOnly ="true" runat="server" CssClass="txtBox"></asp:TextBox></td>           
    </tr>

    <tr>        
        <td style="text-align:right;"><asp:Label ID="lblEmpName" CssClass="lbl" runat="server" Text="Employee Name : "></asp:Label></td>
        <td><asp:TextBox ID="txtEmpName" ReadOnly ="true" runat="server" CssClass="txtBox"></asp:TextBox></td>

        <td style="text-align:right;"><asp:Label ID="lblDesignation" CssClass="lbl" runat="server" Text="Designation : "></asp:Label></td>
        <td><asp:TextBox ID="txtDesignation" ReadOnly ="true" runat="server" CssClass="txtBox"></asp:TextBox></td>           
    </tr>

    <tr>        
        <td style="text-align:right;"><asp:Label ID="lblSalary" CssClass="lbl" runat="server" Text="Gross Salary : "></asp:Label></td>
        <td><asp:TextBox ID="txtSalary" ReadOnly ="true" runat="server" CssClass="txtBox"></asp:TextBox></td>

        <td style="text-align:right;"><asp:Label ID="lblResignationDate" CssClass="lbl" runat="server" Text="Resignation Date : "></asp:Label></td>
        <td><asp:TextBox ID="txtResignationDate" ReadOnly ="true" runat="server" CssClass="txtBox"></asp:TextBox></td>           
    </tr>
        
    <tr>        
        <td style="text-align:right;"><asp:Label ID="lblLastWorkingDate" CssClass="lbl" runat="server" Text="Last Working Date : "></asp:Label></td>
        <td><asp:TextBox ID="txtLastWorkingDate" ReadOnly ="true" runat="server" CssClass="txtBox"></asp:TextBox></td>

        <td style="text-align:right;"><asp:Label ID="lblLastWorkingDateByUser" CssClass="lbl" runat="server" Text="Last Working Date By User : "></asp:Label></td>
        <td><asp:TextBox ID="txtLastWorkingDateByUser" ReadOnly ="true" runat="server" CssClass="txtBox"></asp:TextBox></td>           
    </tr>
                
    <tr>        
        <td style="text-align:right;"><asp:Label ID="lblReason" CssClass="lbl" runat="server" Text="Reason : "></asp:Label></td>
        <td><asp:TextBox ID="txtReason" ReadOnly ="true" runat="server" CssClass="txtBox" TextMode="MultiLine"></asp:TextBox></td>         

        <td style="text-align:right;"><asp:Label ID="lblSeparateType" CssClass="lbl" runat="server" Text="Separate Type : "></asp:Label></td>
        <td><asp:TextBox ID="txtSeparateType" ReadOnly ="true" runat="server" CssClass="txtBox"></asp:TextBox></td>
    </tr>

    <tr>  
        <td style="text-align:right;"><asp:Label ID="lblLastWorkingDateByAuthority" CssClass="lbl" runat="server" Text="Last Working Date By Authority : "></asp:Label></td>
        <td><asp:TextBox ID="txtLastWorkingDateByAuthority" ReadOnly ="true" runat="server" CssClass="txtBox"></asp:TextBox>
        </td>
              
        <td style="text-align:right;" colspan="2">   
            <a class="button" style="text-align:left;" onclick="ClearControlsRealizeDeptHead()">Close</a>
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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelfResign.aspx.cs" Inherits="UI.HR.Settlement.SelfResign" %>
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

<div id="divcontentholder">

    <table class="tbldecoration" style="width:auto; float:left;">
    <tr class="tblheader"><td colspan="4"> Self Resign :</td></tr>

    <tr class="tblroweven">  
        <td style="text-align:right;"><asp:Label ID="lblReason" CssClass="lbl" runat="server" Text="Reason : "></asp:Label></td>
        <td><asp:TextBox ID="txtReason" runat="server" CssClass="txtBox" Enabled="true" TextMode="MultiLine"></asp:TextBox></td>
        
        <td style="text-align:right;"><asp:Label ID="lblLastOfficeDateByUser" CssClass="lbl" runat="server" Text="Last Office Date provide by user : "></asp:Label></td>
        <td ><asp:TextBox ID="txtLastOfficeDateByUser" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtLastOfficeDateByUser', { 'dateFormat': 'Y-m-d' });</script></td>   
                   
        <%--<td style="text-align:right;"><asp:Label ID="lblLastOfficeDateByUser" CssClass="lbl" runat="server" Text="Last Office Date provide by user : "></asp:Label></td>
        <td ><asp:TextBox ID="txtLastOfficeDateByUser" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtLastOfficeDateByUser', { 'dateFormat': 'Y-m-d' });</script></td>   --%>
    </tr>

    <tr class="tblrowodd">           
        <td colspan="4"><asp:HiddenField ID="hdnconfirm" runat="server" />
        <asp:Button ID="btnSubmit" runat="server" CssClass="button" Text="Submit" OnClientClick="ConfirmAll()" OnClick="btnSubmit_Click"/></td>
    </tr>

    <tr class="tblheader"><td colspan="4">Employee Information :</td></tr>

    <tr class="tblroweven">  
        <td style="text-align:right;"><asp:Label ID="lblSupervisorName" CssClass="lbl" runat="server" Text="Supervisor Name : "></asp:Label></td>
        <td><asp:TextBox ID="txtSupervisorName" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true" ></asp:TextBox></td>
               
        <td style="text-align:right;"><asp:Label ID="lblSupervisorDesignation" CssClass="lbl" runat="server" Text="Supervisor Designation : "></asp:Label></td>
        <td><asp:TextBox ID="txtSupervisorDesignation" BackColor="LightGray" runat="server" CssClass="txtBox" Enabled="true" ReadOnly="true" ></asp:TextBox></td>               
    </tr>

    <tr class="tblroweven">  
        <td style="text-align:right;"><asp:Label ID="lblEmpCode" CssClass="lbl" runat="server" Text="Employee Code : "></asp:Label></td>
        <td><asp:TextBox ID="txtEmpCode" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true" ></asp:TextBox></td>
               
        <td style="text-align:right;"><asp:Label ID="lblBasic" CssClass="lbl" runat="server" Text="Basic Salary : "></asp:Label></td>
        <td><asp:TextBox ID="txtBasic" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true" ></asp:TextBox></td>               
    </tr>
         
    <tr class="tblroweven">  
        <td style="text-align:right;"><asp:Label ID="lblEmpEnroll" CssClass="lbl" runat="server" Text="Enroll : "></asp:Label></td>
        <td><asp:TextBox ID="txtEmpEnroll" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true" ></asp:TextBox></td>       

        <td style="text-align:right;"><asp:Label ID="lblGross" CssClass="lbl" runat="server" Text="Gross Salary : "></asp:Label></td>
        <td><asp:TextBox ID="txtGross" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true" ></asp:TextBox></td>
                               
    </tr> 
        
    <tr class="tblroweven">  
        <td style="text-align:right;"><asp:Label ID="lblName" CssClass="lbl" runat="server" Text="Employee Name : "></asp:Label></td>
        <td><asp:TextBox ID="txtName" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true" ></asp:TextBox></td>

        <td style="text-align:right;"><asp:Label ID="lblJoiningDate" CssClass="lbl" runat="server" Text="Joining Date : "></asp:Label></td>
        <td><asp:TextBox ID="txtJoiningDate" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true" ></asp:TextBox></td>       
              
    </tr>  
        
    <tr class="tblroweven">  
        <td style="text-align:right;"><asp:Label ID="lblDesignation" CssClass="lbl" runat="server" Text="Designation : "></asp:Label></td>
        <td><asp:TextBox ID="txtDesignation" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true" ></asp:TextBox></td>       

        <td style="text-align:right;"><asp:Label ID="lblLastOfficeDateWillbe" CssClass="lbl" runat="server" Text="Last Office Date Will be : "></asp:Label></td>
        <td><asp:TextBox ID="txtLastOfficeDateWillbe" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true" ></asp:TextBox></td>       

    </tr> 
       
    <tr class="tblroweven">  
        <td style="text-align:right;"><asp:Label ID="lblDept" CssClass="lbl" runat="server" Text="Department : "></asp:Label></td>
        <td><asp:TextBox ID="txtDept" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true" ></asp:TextBox></td>

         <td style="text-align:right;"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit Name : "></asp:Label></td>
        <td><asp:TextBox ID="txtUnit" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true" ></asp:TextBox></td>       
    </tr>   

    <tr class="tblroweven">  
        <td style="text-align:right;"><asp:Label ID="lblJobType" CssClass="lbl" runat="server" Text="Job Type : "></asp:Label></td>
        <td><asp:TextBox ID="txtJobType" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true" ></asp:TextBox></td>       
        
        <td style="text-align:right;"><asp:Label ID="lblJobStation" CssClass="lbl" runat="server" Text="Job Station : "></asp:Label></td>
        <td><asp:TextBox ID="txtJobStation" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true" ></asp:TextBox></td>       
    </tr> 


    </table>
       
    </div>


   <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HRResign.aspx.cs" Inherits="UI.HR.Settlement.HRResign" %>
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
        $(document).ready(function () {
            SearchText();
        });
        function Changed() {
            document.getElementById('hdfSearchBoxTextChange').value = 'true';
        }
        function SearchText() {
            $("#txtEmployeeSearch").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;",
                        url: "HRResign.aspx/GetAutoCompleteData",
                        data: "{'strSearchKey':'" + document.getElementById('txtEmployeeSearch').value + "'}",
                        dataType: "json",
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (result) {
                            //alert("Error");
                        }
                    });
                }
            });
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
    
    <div id="divcontentholder"> <asp:HiddenField ID="hdnEnrollUnit" runat="server" /> 

    <table class="tbldecoration" style="width:auto; float:left;">
    <tr class="tblheader"><td colspan="4"> HR Resign :</td></tr>
   
    <%--<tr class="tblroweven"> 
        <td style="text-align:right;"><asp:Label ID="lblUnitList" CssClass="lbl" runat="server" Text="Unit Name : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlUnitList" runat="server" CssClass="ddList" AutoPostBack="True" DataSourceID="odsUnitForLogin" DataTextField="strUnit" DataValueField="intUnitID" ></asp:DropDownList>            
            <asp:ObjectDataSource ID="odsUnitForLogin" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetUnitListForSeparation" TypeName="HR_BLL.Settlement.GlobalClass">
                <SelectParameters>
                    <asp:SessionParameter Name="intEnroll" SessionField="sesUserID" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>  

        <td style="text-align:right;"><asp:Label ID="lblJobStationList" CssClass="lbl" runat="server" Text="Job Station Name : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlJobStationList" runat="server" CssClass="ddList" AutoPostBack="True" DataSourceID="odsJobStation" DataTextField="strJobStationName" DataValueField="intEmployeeJobStationId"></asp:DropDownList>
            <asp:ObjectDataSource ID="odsJobStation" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetJobStationList" TypeName="HR_BLL.Settlement.HRClass">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlUnitList" Name="intUnitID" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>  
    </tr> --%>
              
    
    <tr class="tblroweven">    
        <td style="text-align:right;">
        <asp:Label ID="lblEmployeeSearch" CssClass="lbl" runat="server" Text="Employee-Search : "></asp:Label>
        <asp:HiddenField ID="hdnstation" runat="server" /><asp:HiddenField ID="hdnenroll" runat="server" />
        </td>
        <td><asp:TextBox ID="txtEmployeeSearch" runat="server" CssClass="txtBox" AutoPostBack="true" onchange="javascript: Changed();"></asp:TextBox>
            <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" /></td>        
                                 
        <td style="text-align:right;"><asp:Label ID="lblSeparateType" CssClass="lbl" runat="server" Text="Separate Type : "></asp:Label></td>
        <td>
            <asp:DropDownList ID="ddlSeparateType" runat="server" AutoPostBack="true" CssClass="ddList">
            <asp:ListItem Selected="True" Value="1">Resignation</asp:ListItem>
            <asp:ListItem Value="2">Dismissal</asp:ListItem>
            <asp:ListItem Value="3">Termination</asp:ListItem>
            </asp:DropDownList>            
        </td>        
    </tr>        
         
    <tr class="tblroweven">  
        <td style="text-align:right;"><asp:Label ID="lblReason" CssClass="lbl" runat="server" Text="Reason : "></asp:Label></td>
        <td><asp:TextBox ID="txtReason" runat="server" CssClass="txtBox" Enabled="true" TextMode="MultiLine"></asp:TextBox></td>
        
        <td style="text-align:right;"><asp:Label ID="lblSeparationDate" CssClass="lbl" runat="server" Text="Separation Date : "></asp:Label></td>
        <td ><asp:TextBox ID="txtSeparationDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtSeparationDate', { 'dateFormat': 'Y-m-d' });</script></td>                
    </tr>

    <tr class="tblrowodd">                                     
        <td style="text-align:right;"><asp:Label ID="lblLastOfficeDateByUser" CssClass="lbl" runat="server" Text="Last Office Date provide by user : "></asp:Label></td>
        <td ><asp:TextBox ID="txtLastOfficeDateByUser" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtLastOfficeDateByUser', { 'dateFormat': 'Y-m-d' });</script></td>
                
        <td colspan="2"><asp:HiddenField ID="hdnconfirm" runat="server" />
        <asp:Button ID="btnSubmit" runat="server" CssClass="button" Text="Submit" OnClientClick="ConfirmAll()" OnClick="btnSubmit_Click"/></td>
    </tr>

    <tr class="tblheader"><td colspan="4">Employee Information :</td></tr>

    <tr class="tblroweven">  
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Supervisor Name : "></asp:Label></td>
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
        
        <td style="text-align:right; "><asp:Label ID="lblJobStation" CssClass="lbl" runat="server" Text="Job Station : "></asp:Label></td>
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
